
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;


namespace Infrastructure.Helpers
{
    public static class MultipartRequestHelper
    {
        private static readonly FormOptions _defaultFormOptions = new FormOptions();

        public static async Task<IActionResult> BindMultiPartFormDataToViewModel<T>(this ControllerBase controller) where T : class, new()
        {
            var httpContext = controller.ControllerContext.HttpContext;
            var request = controller.ControllerContext.HttpContext.Request;

            //var streamList = new List<Tuple<ContentDispositionHeaderValue, MemoryStream>>();
            var fileList = new List<FormFile>();

            if (!MultipartRequestHelper.IsMultipartContentType(request.ContentType))
            {
                return new EmptyResult();
            }

            // Used to accumulate all the form url encoded key value pairs in the 
            // request.
            var formAccumulator = new KeyValueAccumulator();

            var boundary = MultipartRequestHelper.GetBoundary(
                MediaTypeHeaderValue.Parse(request.ContentType),
                _defaultFormOptions.MultipartBoundaryLengthLimit);
            var reader = new MultipartReader(boundary, httpContext.Request.Body);

            var section = await reader.ReadNextSectionAsync();
            while (section != null)
            {
                ContentDispositionHeaderValue contentDisposition;
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out contentDisposition);

                if (hasContentDispositionHeader)
                {
                    if (MultipartRequestHelper.HasFileContentDisposition(contentDisposition))
                    {
                        var targetStream = new MemoryStream();

                        await section.Body.CopyToAsync(targetStream);
                        //streamList.Add(Tuple.Create(contentDisposition, targetStream));
                        var formFile = new FormFile(targetStream, 0, targetStream.Length, contentDisposition.Name.ToString(), contentDisposition.FileName.ToString());
                        // var buffer = targetStream.ToArray();
                        fileList.Add(formFile);

                    }
                    else if (MultipartRequestHelper.HasFormDataContentDisposition(contentDisposition))
                    {
                        // Content-Disposition: form-data; name="key"
                        // value
                        // Do not limit the key name length here because the 
                        // multipart headers length limit is already in effect.
                        var key = HeaderUtilities.RemoveQuotes(contentDisposition.Name);
                        var encoding = EncodingHelper.GetEncoding(section);
                        using (var streamReader = new StreamReader(
                            section.Body,
                            encoding,
                            detectEncodingFromByteOrderMarks: true,
                            bufferSize: 1024,
                            leaveOpen: true))
                        {
                            // The value length limit is enforced by MultipartBodyLengthLimit
                            var value = await streamReader.ReadToEndAsync();
                            if (String.Equals(value, "undefined", StringComparison.OrdinalIgnoreCase))
                            {
                                value = String.Empty;
                            }
                            formAccumulator.Append(key.ToString(), value);

                            if (formAccumulator.ValueCount > _defaultFormOptions.ValueCountLimit)
                            {
                                throw new InvalidDataException($"Form key count limit {_defaultFormOptions.ValueCountLimit} exceeded.");
                            }
                        }
                    }
                }

                // Drains any remaining section body that has not been consumed and
                // reads the headers for the next section.
                section = await reader.ReadNextSectionAsync();
            }

            var targetViewModel = new T();

            // Bind form data to a model

            var formValueProvider = new FormValueProvider(
                BindingSource.Form,
                new FormCollection(formAccumulator.GetResults()),
                CultureInfo.CurrentCulture);

            var bindingSuccessful = await controller.TryUpdateModelAsync(targetViewModel, prefix: "", valueProvider: formValueProvider);
            if (!bindingSuccessful)
            {
                if (!controller.ModelState.IsValid)
                {
                    return controller.BadRequest(controller.ModelState);
                }
            }

            //foreach (var streamItem in streamList)
            //{
            //    var contentDisposition = streamItem.Item1;
            //    var targetStream = streamItem.Item2;

            //    var formFile = new FormFile(targetStream, 0, targetStream.Length, contentDisposition.Name, contentDisposition.FileName);
            //    fileList.Add(formFile);
            //}


            var targetProperty = typeof(T).GetProperties().Where(p => p.PropertyType.IsAssignableFrom(typeof(IList<FormFile>))).FirstOrDefault();
            if (targetProperty != null)
            {
                targetProperty.SetValue(targetViewModel, fileList);
            }

            return new ObjectResult(targetViewModel);
        }

        // Content-Type: multipart/form-data; boundary="----WebKitFormBoundarymx2fSWqWSd0OxQqq"
        // The spec says 70 characters is a reasonable limit.
        public static string GetBoundary(MediaTypeHeaderValue contentType, int lengthLimit)
        {
            var boundary = HeaderUtilities.RemoveQuotes(contentType.Boundary);
            if (boundary.HasValue == false)
            {
                throw new InvalidDataException("Missing content-type boundary.");
            }

            if (boundary.Length > lengthLimit)
            {
                throw new InvalidDataException(
                    $"Multipart boundary length limit {lengthLimit} exceeded.");
            }

            return boundary.Value;
        }

        public static bool IsMultipartContentType(string contentType)
        {
            return !string.IsNullOrEmpty(contentType)
                   && contentType.IndexOf("multipart/", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static bool HasFormDataContentDisposition(ContentDispositionHeaderValue contentDisposition)
        {
            // Content-Disposition: form-data; name="key";
            return contentDisposition != null
                   && contentDisposition.DispositionType.Equals("form-data")
                   && contentDisposition.FileName.HasValue == false
                   && contentDisposition.FileNameStar.HasValue == false;
        }

        public static bool HasFileContentDisposition(ContentDispositionHeaderValue contentDisposition)
        {
            // Content-Disposition: form-data; name="myfile1"; filename="Misc 002.jpg"
            return contentDisposition != null
                   && contentDisposition.DispositionType.Equals("form-data")
                   && (contentDisposition.FileName.HasValue
                       || contentDisposition.FileNameStar.HasValue);
        }
    }
}
