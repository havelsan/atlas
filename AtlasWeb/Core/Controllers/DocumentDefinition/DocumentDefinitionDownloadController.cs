using TTInstanceManagement;

using System;
using TTObjectClasses;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    public class DocumentDefinitionDownloadController : Controller
    {
        public class DownloadFileInput
        {
            public Guid id { get; set; }
        }

        [HttpPost]
        public IActionResult DownloadFile(DownloadFileInput input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                try
                {
                    DocumentDefinition doc = (DocumentDefinition)objectContext.GetObject(input.id, typeof(DocumentDefinition));
                    if (doc.File != null)
                    {
                        Byte[] memoryStream = (byte[])doc.File;
                        Stream myInputStream = new MemoryStream(memoryStream);
                        myInputStream.Position = 0;
                        var response = new FileStreamResult(myInputStream, "application/doc");
                        objectContext.FullPartialllyLoadedObjects();
                        return response;
                    }
                    else
                    {
                        throw new FileNotFoundException("Document ilgili input ile bulunamadı. Input Body : "+ JSONHelper.ToJSON(input));
                    }
                }
                catch (Exception f)
                {
                    throw f;
                }

            }
        }
    }
}