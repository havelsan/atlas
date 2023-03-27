using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;
using System.Reflection.Emit;
using Infrastructure.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using TTInstanceManagement;
using TTObjectClasses;
using System.Collections.Generic;
using System.Data.OracleClient;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Http;
using AtlasDataModel;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DynamicForms.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public partial class DynamicFormController : Controller
    {

        [HvlResult]
        [HttpPost]
        public bool SaveForm(DynamicFormDto FormDto)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                DynamicForm dynamicForm = new DynamicForm(_context);

                dynamicForm.IsEnable = true;
                dynamicForm.Name = FormDto.Name;
                dynamicForm.Code = FormDto.Code;
                dynamicForm.ClassName = FormDto.ClassName;
                dynamicForm.CheckClassName = FormDto.CheckClassName;
                _context.Save();
                return true;
            }
        }

        [HvlResult]
        [HttpPost]
        public bool SaveFormRevision(DynamicFormRevisionDto FormRevisionDto)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var dynamicForm = _context.QueryObjects<DynamicForm>("ObjectID = '" + FormRevisionDto.DynamicFormId + "'").FirstOrDefault();
                if (dynamicForm == null)
                {
                    //Form Not Found
                    return false;
                }
                var lastRevisionNumber = _context.QueryObjects<DynamicFormRevision>("DynamicFormId = '" + FormRevisionDto.DynamicFormId + "'").OrderByDescending(x => x.RevisionNumber).Select(x => x.RevisionNumber).FirstOrDefault();
                if (lastRevisionNumber == null)
                {
                    lastRevisionNumber = 0;
                }
                lastRevisionNumber++;
                DynamicFormRevision FormRevision = new DynamicFormRevision(_context);
                FormRevision.ResUser = Common.CurrentResource;
                FormRevision.UpdateDate = Common.RecTime();
                FormRevision.IsMain = lastRevisionNumber == 1 ? true : false;
                FormRevision.DynamicFormId = dynamicForm;
                FormRevision.Comment = FormRevisionDto.Comment;
                FormRevision.JsonTemplate = FormRevisionDto.JsonTemplate;
                FormRevision.RevisionNumber = lastRevisionNumber;
                _context.Save();

                var formParams = _context.QueryObjects<FormParam>("DynamicFormID = '" + dynamicForm.ObjectID + "'").ToList();
                if(FormRevisionDto.Parameters != null)
                {
                    foreach (var param in FormRevisionDto.Parameters)
                    {
                        var formParam = formParams.FirstOrDefault(x => x.ParamKey == param.Key);
                        if (formParam == null)
                        {
                            formParam = new FormParam(_context);
                            formParam.DynamicFormID = dynamicForm;
                            formParam.IsRequired = param.IsRequired;
                            formParam.IsFilter = param.IsFilter;
                            formParam.ParamKey = param.Key;
                            _context.Save();
                        }

                        DynamicFormRevisionParam revisionParam = new DynamicFormRevisionParam(_context);
                        revisionParam.DynamicFormRevision = FormRevision;
                        revisionParam.FormParam = formParam;
                        _context.Save();
                    }
                }
     
                dynamic jsonTemplate = JsonConvert.DeserializeObject(FormRevisionDto.JsonTemplate);

                var components = jsonTemplate.components;
                if (components == null)
                {
                    return false;
                }

                var formFields = _context.QueryObjects<FormField>("DynamicFormID = '" + dynamicForm.ObjectID + "'").ToList();
                List<FormField> fields = new List<FormField>();

                foreach (var item in components)
                {
                    var formField = formFields.FirstOrDefault(x => x.Name == item.key.ToString());

                    if (formField == null)
                    {
                        formField = new FormField(_context);
                        formField.Label = item.label;
                        formField.Name = item.key.ToString();
                        formField.DynamicFormID = dynamicForm;
                        if (item.components != null)
                        {
                            GetComponents(fields, item, _context, formField.DynamicFormID.ObjectID);
                            foreach (var field in fields)
                            {
                                DynamicFormRevisionField subDynamicFormRevisionField = new DynamicFormRevisionField(_context);
                                subDynamicFormRevisionField.DynamicFormRevisionID = FormRevision;
                                subDynamicFormRevisionField.FormFieldID = field;
                            }
                        }
                        if (item.data != null)
                        {
                            DynamicDataSource newDynamicDataSource = new DynamicDataSource(_context);
                            newDynamicDataSource.Name = formField.Name;
                            //TODO:CORE type enum
                            newDynamicDataSource.Type = 0;
                            if (item.data.url != null)
                            {
                                newDynamicDataSource.ApiConfig = item.data.url.ToString();
                            }
                            _context.Save();
                            formField["DynamicDataSourceID"] = newDynamicDataSource.ObjectID;

                        }
                        _context.Save();

                    }
                    else
                    {
                        formField.Label = item.label;

                    }

                    DynamicFormRevisionField dynamicFormRevisionField = new DynamicFormRevisionField(_context);
                    dynamicFormRevisionField.DynamicFormRevisionID = FormRevision;
                    dynamicFormRevisionField.FormFieldID = formField;

                }

                _context.Save();
                return true;
            }
        }


        private void GetComponents(List<FormField> fields, dynamic item, TTObjectContext context, Guid dynamicFormID)
        {
            foreach (var comp in item.components)
            {
                if(comp.columns != null)
                {
                    foreach (var column in comp.columns)
                    {
                        GetComponents(fields, column, context, dynamicFormID);
                    }
                }
                if (comp.components != null)
                {
                    GetComponents(fields, comp, context, dynamicFormID);
                }
                var formField = new FormField(context);
                formField.Label = comp.label.ToString();
                formField.Name = comp.key.ToString();
                formField["DynamicFormID"] = dynamicFormID;
                fields.Add(formField);
                
            }
        }

        [HvlResult]
        [HttpGet]
        public bool SetEnableDisable(string objectID, bool enable)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var dynamicForm = _context.QueryObjects<TTObjectClasses.DynamicForm>("ObjectID = '" + objectID + "'").FirstOrDefault();
                dynamicForm.IsEnable = enable;
                _context.Save();
            }
            return true;
        }

        [HvlResult]
        [HttpGet]
        public bool SetAsMainRevision(string objectID)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var newMain = _context.QueryObjects<DynamicFormRevision>("ObjectID = '" + objectID + "'").FirstOrDefault();

                if (newMain == null)
                {
                    throw new Exception("DynamicFormRevision not found");
                }

                var oldMains = _context.QueryObjects<DynamicFormRevision>("DynamicFormId = '" + newMain.DynamicFormId.ObjectID + "' AND IsMain = 1").ToList();

                if (oldMains != null && oldMains.Count > 0)
                {
                    foreach (var oldMain in oldMains)
                    {
                        oldMain.IsMain = false;

                    }
                }
                newMain.IsMain = true;
                _context.Save();
            }
            return true;
        }

        [HvlResult]
        [HttpGet]
        public List<DynamicFormDto> GetForms(bool getAll)
        {
            string injection = "IsEnable = 1";
            if (getAll == true)
            {
                injection = string.Empty;
            }

            using (TTObjectContext _context = new TTObjectContext(false))
            {
                return _context.QueryObjects<DynamicForm>(injection).Select(x => new DynamicFormDto() { ObjectID = x.ObjectID, Name = x.Name, IsEnable = x.IsEnable, Code = x.Code }).ToList();
            }
        }

        [HvlResult]
        [HttpGet]
        public List<DynamicParameterDto> GetParamsForRevision(string dynamicFormID)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                return _context.QueryObjects<DynamicFormRevisionParam>("DYNAMICFORMREVISION = '" + dynamicFormID + "'").Select(x => new DynamicParameterDto()
                {
                    IsRequired = x.FormParam?.IsRequired == true,
                    IsFilter = x.FormParam?.IsFilter == true,
                    Key = x.FormParam?.ParamKey
                }).ToList();
            }
        }

        [HvlResult]
        [HttpGet]
        public List<DynamicFormRevisionDto> GetRevisionForms(string dynamicFormID)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                return _context.QueryObjects<DynamicFormRevision>("DynamicFormId = '" + dynamicFormID + "'").OrderByDescending(x => x.RevisionNumber).Select(x => new DynamicFormRevisionDto() { ObjectID = x.ObjectID, Comment = (x.IsMain == true ? "(A) " : "v." + x.RevisionNumber) + " - " + x.Comment, JsonTemplate = x.JsonTemplate != null ? x.JsonTemplate.ToString() : "" }).ToList();
            }
        }


        [HvlResult]
        [HttpGet]
        public DynamicFormExporter DownloadFormRevision(string revisionID)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                DynamicFormExporter dynamicFormExporter = new DynamicFormExporter();

                dynamicFormExporter.DynamicFormRevision = _context.QueryObjects<DynamicFormRevision>("ObjectID = '" + revisionID + "'").FirstOrDefault();

                dynamicFormExporter.DynamicForm = _context.QueryObjects<DynamicForm>("ObjectID = '" + dynamicFormExporter.DynamicFormRevision.DynamicFormId.ObjectID + "'").FirstOrDefault();

                dynamicFormExporter.DynamicFormRevisionParam = _context.QueryObjects<DynamicFormRevisionParam>("DYNAMICFORMREVISION = '" + revisionID + "'").ToList();
                return dynamicFormExporter;
            }
        }

        public class UploadViewModel
        {
            public IList<FormFile> Attachments { get; set; }
        }


        [HttpPost]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> UploadForm()
        {
            DynamicFormExporter export = null;
            try
            {
                var result = await MultipartRequestHelper.BindMultiPartFormDataToViewModel<UploadViewModel>(this);
                var objectResult = result as ObjectResult;
                var viewModel = objectResult.Value as UploadViewModel;

                if (viewModel.Attachments != null && viewModel.Attachments.Count > 0)
                {
                    var formFile = viewModel.Attachments.FirstOrDefault();
                    var content = StreamHelpers.ToByteArray(formFile.OpenReadStream());
                    var contentJson = System.Text.Encoding.UTF8.GetString(content, 0, content.Length);
                    export = JsonConvert.DeserializeObject<DynamicFormExporter>(contentJson);
                }
            }
            catch
            {

            }


            if (export == null)
            {
                throw new Exception("Cant parse uplodad Form.json file");
            }


            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var checkIfAlreadyExist = _context.QueryObjects<DynamicForm>("Code = '" + export.DynamicForm.Code + "'").ToList();

                if (checkIfAlreadyExist.Count > 0)
                {
                    foreach (var item in checkIfAlreadyExist)
                    {
                        item.Code = null;
                        item.IsEnable = false;
                    }
                    _context.Save();
                }

                this.SaveForm(new DynamicFormDto()
                {
                    Code = export.DynamicForm.Code,
                    IsEnable = true,
                    Name = export.DynamicForm.Name
                });

                var dynamicForm = _context.QueryObjects<DynamicForm>("Code = '" + export.DynamicForm.Code + "'").FirstOrDefault();
              
                var parameters = new List<DynamicParameterDto>();    
                if(export.DynamicFormRevisionParam.Any())
                {
                    var parameterKeys = string.Join(",", export.DynamicFormRevisionParam.Select(p => "'" + p.ObjectID + "'"));
                    parameters = _context.QueryObjects<DynamicFormRevisionParam>("OBJECTID IN (" + parameterKeys + ")").Select(p => new DynamicParameterDto()
                    {
                        Key = p.FormParam.ParamKey,
                        IsFilter = p.FormParam.IsFilter,
                        IsRequired = p.FormParam.IsRequired
                    }).ToList();
                }
                
                this.SaveFormRevision(new DynamicFormRevisionDto()
                {
                    DynamicFormId = dynamicForm.ObjectID.ToString(),
                    Comment = export.DynamicFormRevision.Comment,
                    JsonTemplate = export.DynamicFormRevision.JsonTemplate.ToString(),
                    RevisionNumber = export.DynamicFormRevision.RevisionNumber,
                    Parameters = parameters
                });

            }


            return Ok();
        }
        [HvlResult]
        [HttpGet]
        public DynamicFormDetails ResolveMainRevision(string code)
        {
            DynamicFormDetails dynamicFormDetails = new DynamicFormDetails();
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                dynamicFormDetails.DynamicForm = _context.QueryObjects<DynamicForm>("Code = '" + code + "' and IsEnable = 1")
                    .Select(x => new DynamicFormDto()
                    {
                        Name = x.Name,
                        Code = x.Code,
                        ObjectID = x.ObjectID,
                        IsEnable = x.IsEnable,
                        ClassName = x.ClassName,
                        CheckClassName = x.CheckClassName
                    })
                    .FirstOrDefault();
                dynamicFormDetails.DynamicFormRevision = _context.QueryObjects<DynamicFormRevision>("DynamicFormId = '" + dynamicFormDetails.DynamicForm.ObjectID + "' and IsMain = 1")
                       .Select(x => new DynamicFormRevisionDto()
                       {
                           DynamicFormId = x.DynamicFormId.ObjectID.ToString(),
                           Comment = x.Comment,
                           JsonTemplate = x.JsonTemplate.ToString(),
                           ObjectID = x.ObjectID,

                       })
                    .FirstOrDefault();

                dynamicFormDetails.DynamicFormRevisionParams = _context.QueryObjects<DynamicFormRevisionParam>("DynamicFormRevision = '" + dynamicFormDetails.DynamicFormRevision.ObjectID.ToString() + "'").Select(x => new DynamicParameterDto()
                {
                    IsRequired = x.FormParam.IsRequired,
                    IsFilter = x.FormParam.IsFilter,
                    Key = x.FormParam.ParamKey,
                }).ToList();

                return dynamicFormDetails;
            }

        }

        [HvlResult]
        [HttpGet]
        public DynamicFormDetails GetDynamicFormDetails(string dynamicFormRevisionID)
        {
            DynamicFormDetails dynamicFormDetails = new DynamicFormDetails();
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                dynamicFormDetails.DynamicFormRevision = _context.QueryObjects<DynamicFormRevision>("ObjectId = '" + dynamicFormRevisionID + "'")
               .Select(x => new DynamicFormRevisionDto()
               {
                   DynamicFormId = x.DynamicFormId.ObjectID.ToString(),
                   Comment = x.Comment,
                   JsonTemplate = x.JsonTemplate.ToString(),
                   ObjectID = x.ObjectID,

               })
            .FirstOrDefault();

                dynamicFormDetails.DynamicForm = _context.QueryObjects<DynamicForm>("ObjectId = '" + dynamicFormDetails.DynamicFormRevision.DynamicFormId + "'")
                    .Select(x => new DynamicFormDto()
                    {
                        Name = x.Name,
                        Code = x.Code,
                        ObjectID = x.ObjectID,
                        IsEnable = x.IsEnable,
                        ClassName = x.ClassName,
                        CheckClassName = x.CheckClassName
                    })
                    .FirstOrDefault();


                dynamicFormDetails.DynamicFormRevisionParams = _context.QueryObjects<DynamicFormRevisionParam>("DynamicFormRevision = '" + dynamicFormRevisionID + "'").Select(x => new DynamicParameterDto()
                {
                    IsRequired = x.FormParam.IsRequired,
                    IsFilter = x.FormParam.IsFilter,
                    Key = x.FormParam.ParamKey,
                }).ToList();

                return dynamicFormDetails;
            }

        }

        [HttpPost]
        [HvlResult]
        public dynamic SaveFormSubmission(FormSubmissionDto formSubmissionDto)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {

                var formData = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(formSubmissionDto.FormDataJson);

                var revision = _context.QueryObjects<DynamicFormRevision>("ObjectID = '" + formSubmissionDto.DynamicReportRevisionID + "'").FirstOrDefault();

                var revisionFields = _context.QueryObjects<DynamicFormRevisionField>("DynamicFormRevisionID = '" + formSubmissionDto.DynamicReportRevisionID + "'").ToList();

                var savedParams = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(formSubmissionDto.FormParamsJson);

                var revisionParams = _context.QueryObjects<DynamicFormRevisionParam>("DynamicFormRevision = '" + formSubmissionDto.DynamicReportRevisionID + "'").ToList();

                foreach (var param in revisionParams)
                {
                    string paramValue = null;
                    try
                    {
                        paramValue = savedParams[param.FormParam.ParamKey];
                    }
                    catch
                    { }

                    if (param.FormParam.IsRequired == true && paramValue == null)
                    {
                        return (new
                        {
                            success = false
                        });
                    }
                }

                DynamicFormSubmission dynamicFormSubmission = null;
                //if (string.IsNullOrEmpty(formSubmissionDto.SubmissionID))
                //{
                if(formSubmissionDto.Action == true && !string.IsNullOrEmpty(formSubmissionDto.SubmissionID))
                {
                    dynamicFormSubmission = _context.QueryObjects<DynamicFormSubmission>("OBJECTID = '" + formSubmissionDto.SubmissionID + "'").FirstOrDefault();
                }
                else
                {
                    dynamicFormSubmission = new DynamicFormSubmission(_context);
                }
                
                dynamicFormSubmission.DynamicFormRevision = revision;
                dynamicFormSubmission.UpdateDate = DateTime.Now;
                dynamicFormSubmission.CreatedBy = Common.CurrentResource;
                _context.Save();

                //Update
                if (formSubmissionDto.FormMode == 1)
                {
                    var filterParams = revisionParams.Where(x => x.FormParam.IsFilter == true).Select(x => new FilterParamDto() { ObjectID = x.FormParam.ObjectID, ParamKey = x.FormParam.ParamKey }).ToList();
                    using (var context = AtlasDbContextFactory.Instance.CreateDbContext())
                    {


                        List<Guid> foundSubmissions = FindSubmissions(filterParams, savedParams, revision.DynamicFormId.ObjectID, context);

                        var latestSubmission = context.DynamicFormSubmission.Where(x => foundSubmissions.Contains(x.ObjectId)).OrderByDescending(x => x.UpdateDate).FirstOrDefault();
                        if (latestSubmission != null)
                        {
                            latestSubmission.IsEnable = false;
                        }

                        context.SaveChanges();
                    }

                }
                //}
                //else
                //{
                //    dynamicFormSubmission = _context.QueryObjects<DynamicFormSubmission>("ObjectID = '" + formSubmissionDto.SubmissionID + "'").FirstOrDefault();
                //}
                if (formSubmissionDto.Action == true)
                {
                    List<DynamicFormSavedValue> savedValues = _context.QueryObjects<DynamicFormSavedValue>("DynamicFormSubmission = '" + dynamicFormSubmission.ObjectID + "'").ToList();
                    foreach(var savedValue in savedValues)
                    {
                        ((ITTObject)savedValue).Delete();
                    }
                }

                foreach (var revisionField in revisionFields.ToList())
                {
                    List<string> resultSet = new List<string>();
                    FindValue(formData, revisionField.FormFieldID.Name, ref resultSet);
                    foreach (var value in resultSet)
                    {   
                        DynamicFormSavedValue dynamicFormSavedValue = new DynamicFormSavedValue(_context);
                        dynamicFormSavedValue.Value = value;
                        dynamicFormSavedValue.DynamicFormRevisionID = revision;
                        dynamicFormSavedValue.DynamicFormRevisionFieldID = revisionField;
                        dynamicFormSavedValue.DynamicFormID = revision.DynamicFormId;
                        dynamicFormSavedValue.DynamicFormSubmission = dynamicFormSubmission;
                        dynamicFormSavedValue.FormFieldID = revisionField.FormFieldID;
                    }
                    _context.Save();

                }

                DynamicFormSavedJSON dynamicFormSavedJSON = new DynamicFormSavedJSON(_context);
                dynamicFormSavedJSON.Value = formSubmissionDto.FormDataJson;
                dynamicFormSavedJSON.DynamicFormID = revision.DynamicFormId;
                dynamicFormSavedJSON.DynamicFormRevisionID = revision;
                dynamicFormSavedJSON.DynamicFormSubmission = dynamicFormSubmission;
                _context.Save();
                foreach (var param in revisionParams)
                {
                    string paramValue = null;
                    try
                    {
                        paramValue = savedParams[param.FormParam.ParamKey];
                        DynamicFormSavedParam dynamicFormSavedParam = new DynamicFormSavedParam(_context);
                        dynamicFormSavedParam.Value = paramValue;
                        dynamicFormSavedParam.DynamicFormRevisionParam = param;
                        dynamicFormSavedParam.DynamicFormSubmission = dynamicFormSubmission;

                    }
                    catch
                    { }
                }
                _context.Save();

                return (new
                {
success = true
                });
            }

        }

        private List<Guid> FindSubmissions(List<FilterParamDto> filterParams, dynamic savedParams, Guid dynamicFormID, AtlasContext context)
        {
            IQueryable<AtlasModel.DynamicFormSavedParam> query = context.DynamicFormSavedParam.Where(x => x.DynamicFormRevisionParam.DynamicFormRevision.DynamicFormIdRef == dynamicFormID); ;

            List<Guid> submissionList = new List<Guid>();
            foreach (var filterParam in filterParams)
            {
                query = context.DynamicFormSavedParam.Where(x => x.DynamicFormRevisionParam.DynamicFormRevision.DynamicFormIdRef == dynamicFormID);
                var filterValue = savedParams[filterParam.ParamKey];

                if (filterValue == null)
                {
                    continue;
                }
                string filterItem = filterValue.ToString();
                query = query.Where(x => x.Value == filterItem && x.DynamicFormRevisionParam.FormParam.ObjectId == filterParam.ObjectID);
                var foundSubmissions = query.Where(x => x != null).Select(x => x.DynamicFormSubmissionRef.Value).Distinct().ToList();

                submissionList.AddRange(foundSubmissions);
            }

            if (filterParams == null || filterParams.Count == 0)
            {
                submissionList = context.DynamicFormSubmission.Where(x => x.DynamicFormRevision.DynamicFormIdRef == dynamicFormID).Select(x => x.ObjectId).ToList();  //query.Where(x => x.DynamicFormSubmissionRef.HasValue).Select(x => x.DynamicFormSubmissionRef.Value).Distinct().ToList();
            }

            return submissionList;
        }

        [HvlResult]
        [HttpPost]
        public bool DeleteDynamicFormSubmission(RevisionDto dto)
        {
            using(var context = AtlasDbContextFactory.Instance.CreateDbContext())
            {
                var submission = context.DynamicFormSubmission.FirstOrDefault(p => p.ObjectId == Guid.Parse(dto.RevisionId));
                context.Remove(submission);
                return context.SaveChanges() > 0;
            }
        }

        [HvlResult]
        public DynamicFormGridResultDto GetDynamicFormGrid(DynamicFormGridDto dto)
        {
            DynamicFormGridResultDto dynamicFormGridResultDto = new DynamicFormGridResultDto();
            using (var _context = AtlasDbContextFactory.Instance.CreateDbContext())
            {

                var fields = _context.FormField.Where(x => x.DynamicFormIDRef == new Guid(dto.DynamicFormID)).ToList();
                var formParams = _context.DynamicFormRevisionParam.Include(x => x.FormParam).Where(x => x.DynamicFormRevision.DynamicFormIdRef == new Guid(dto.DynamicFormID)).Select(x => x.FormParam.ObjectId).Distinct();

                var param = _context.FormParam.Where(x => formParams.Contains(x.ObjectId)).ToList();

                var filterParams = param.Where(x => x != null && x.IsFilter == true).Select(x => new FilterParamDto() { ObjectID = x.ObjectId, ParamKey = x.ParamKey }).ToList();
                var savedParams = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(dto.FormParamsJson);

                List<Guid> submissions = FindSubmissions(filterParams, savedParams, new Guid(dto.DynamicFormID), _context);
                var savedValues = _context.DynamicFormSavedValue.Include(x => x.DynamicFormRevisionFieldID).Include(x => x.DynamicFormRevisionFieldID.FormFieldID).Where(x => submissions.Contains(x.DynamicFormSubmissionRef.Value)).Select(x => new DynamicFormFormFieldSelector { Value = x.Value, DynamicFormSubmissionRef = x.DynamicFormSubmissionRef, FormFieldIDRef = x.DynamicFormRevisionFieldID.FormFieldIDRef }).ToList();
                var savedParamValues = _context.DynamicFormSavedParam.Include(x => x.DynamicFormRevisionParam).Include(x => x.DynamicFormRevisionParam.FormParam).Where(x => submissions.Contains(x.DynamicFormSubmissionRef.Value)).Select(x => new DynamicFormParamSelector { DynamicFormSubmissionRef = x.DynamicFormSubmissionRef, Value = x.Value, FormParamRef = x.DynamicFormRevisionParam.FormParamRef }).ToList();

                var submissionsArray = _context.DynamicFormSubmission.Where(x => submissions.Contains(x.ObjectId)).OrderByDescending(x=> x.UpdateDate).ToList();

                List<dynamic> resultSet = new List<dynamic>();
                for (int i = 0; i < submissionsArray.Count; i++)
                {
                    var submission = submissionsArray[i].ObjectId;
                    dynamic item = new ExpandoObject();
                    var item1 = (IDictionary<string, object>)item;


                    item1["dynamicFormRevisionId"] = submissionsArray[i].DynamicFormRevisionRef;
                    item1["dynamicFormSubmissionId"] = submission;
                    item1["UpdateDate"] = submissionsArray[i].UpdateDate.Value.ToString("dd/MM/yyyy HH:mm");
                    for (int y = 0; y < fields.Count; y++)
                    {
                        var field = fields[y];
                        item1[field.Name] = savedValues.Where(x => x.DynamicFormSubmissionRef == submission && x.FormFieldIDRef == field.ObjectId).Select(x => x.Value).FirstOrDefault();
                    }
                    for (int y = 0; y < param.Count; y++)
                    {
                        var _param = param[y];

                        item1[_param.ParamKey] = savedParamValues.Where(x => x.DynamicFormSubmissionRef == submission && x.FormParamRef == _param.ObjectId).Select(x => x.Value).FirstOrDefault();
                    }

                    resultSet.Add(item);
                }



                dynamicFormGridResultDto.Columns = fields.Select(x => new GridColumnDto() { caption = x.Label, dataField = x.Name }).ToList();

                var paramColumns = param.Select(x => new GridColumnDto() { caption = x.ParamKey, dataField = x.ParamKey }).ToList();
                dynamicFormGridResultDto.Columns.AddRange(paramColumns);
                dynamicFormGridResultDto.Columns.Insert(0, new GridColumnDto() {
                    caption = "Kayıt Tarihi",
                    dataField = "UpdateDate"
                });

                dynamicFormGridResultDto.ResultSet = resultSet;
                return dynamicFormGridResultDto;
            }
        }


        [HvlResult]
        public FormSubmissionDto GetSavedForm(FormSubmissionDto formSubmissionDto)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                if (!string.IsNullOrEmpty(formSubmissionDto.SubmissionID))
                {
                    return _context.QueryObjects<DynamicFormSavedJSON>("DynamicFormSubmission = '" + formSubmissionDto.SubmissionID + "'").Select(x => new FormSubmissionDto() { FormDataJson = x.Value.ToString(), DynamicReportRevisionID = x.DynamicFormRevisionID.ObjectID.ToString(), FormJsonTemplate = x.DynamicFormRevisionID.JsonTemplate.ToString() }).FirstOrDefault();
                }
                else
                {
                    var revision = _context.QueryObjects<DynamicFormRevision>("ObjectID = '" + formSubmissionDto.DynamicReportRevisionID + "'").FirstOrDefault();
                    var revisionParams = _context.QueryObjects<DynamicFormRevisionParam>("DynamicFormRevision = '" + formSubmissionDto.DynamicReportRevisionID + "'").ToList();

                    var filterParams = revisionParams.Where(x => x.FormParam.IsFilter == true).Select(x => new FilterParamDto() { ObjectID = x.FormParam.ObjectID, ParamKey = x.FormParam.ParamKey }).ToList();
                    var savedParams = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(formSubmissionDto.FormParamsJson);
                    using (var context = AtlasDbContextFactory.Instance.CreateDbContext())
                    {

                        List<Guid> foundSubmissions = FindSubmissions(filterParams, savedParams, revision.DynamicFormId.ObjectID, context);

                        var latestSubmission = context.DynamicFormSubmission.Where(x => foundSubmissions.Contains(x.ObjectId)).OrderByDescending(x => x.UpdateDate).FirstOrDefault();

                        if (latestSubmission != null)
                        {
                            var data = _context.QueryObjects<DynamicFormSavedJSON>("DynamicFormSubmission = '" + latestSubmission.ObjectId + "'").Select(x => new FormSubmissionDto() { FormDataJson = x.Value.ToString(), DynamicReportRevisionID = x.DynamicFormRevisionID.ObjectID.ToString(), FormJsonTemplate = x.DynamicFormRevisionID.JsonTemplate.ToString() }).FirstOrDefault();

                            return data;
                        }
                        return null;
                    }
                }


            }
        }

        [HttpPost]
        [HvlResult]
        public object ExecutePostScript(ScriptDto dto)
        {
            Type type = Type.GetType($"DynamicForms.PostScript.{dto.ClassName}");
            object classInstance = Activator.CreateInstance(type, null);
            try
            {
                var result = type.GetMethod("PostScript").Invoke(classInstance, new object[] { dto.Params });
                return result;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(dto.ClassName + " not implemented.");
            }
        }

        [HttpGet]
        [HvlResult]
        public List<DataSourceDto> GetDataSources(int? type)
        {
            using(var context = AtlasDbContextFactory.Instance.CreateDbContext())
            {
                var list = context.DynamicDataSource.Where(p => (!type.HasValue || p.Type == type) && p.IsActive == true).Select(p => new DataSourceDto()
                {
                    ApiConfig = p.ApiConfig,
                    Description = p.Description,
                    ObjectID = p.ObjectId,
                    Name = p.Name,
                    Type = p.Type.Value
                }).ToList();
                var dynamicSourceIds = list.Select(p => p.ObjectID).ToList();
                var dataSourceParams = context.DynamicDataSourceParam.Where(p => dynamicSourceIds.Contains(p.DynamicDataSourceRef.Value)).ToList();
                list.ForEach(p =>
                {
                    p.Parameters = dataSourceParams.Where(t => t.DynamicDataSourceRef.Value == p.ObjectID).Select(t => new DynamicParameterDto()
                    {
                        Key = t.ParamKey,
                        ObjectID = t.ObjectId
                    }).ToList();
                });
                return list;
            }
        }
        [HttpPost]
        [HvlResult]
        public bool DeleteDataSource([FromBody]DataSourceDto dto)
        {
            using (var context = AtlasDbContextFactory.Instance.CreateDbContext())
            {
                var entity = context.DynamicDataSource.FirstOrDefault(p => p.ObjectId == dto.ObjectID);
                entity.IsActive = false;
                return context.SaveChanges() > 0;
            }
        }

        [HttpGet]
        [HvlResult]
        public DataSourceDto GetDataSource(string id)
        {
            using (var context = AtlasDbContextFactory.Instance.CreateDbContext())
            {
                var dto = context.DynamicDataSource.Where(p => p.ObjectId == Guid.Parse(id)).Select(p => new DataSourceDto()
                {
                    ApiConfig = p.ApiConfig,
                    Description = p.Description,
                    ObjectID = p.ObjectId,
                    Name = p.Name,
                    Type = p.Type.Value
                }).FirstOrDefault();
                dto.Parameters = context.DynamicDataSourceParam.Where(p => p.DynamicDataSourceRef == dto.ObjectID).Select(p => new DynamicParameterDto() { 
                    ObjectID = p.ObjectId,
                    Key = p.ParamKey
                }).ToList();
                return dto;
            }
        }

        [HttpPost]
        [HvlResult] 
        public bool AddDataSourceParams([FromQuery]Guid dataSourceId, [FromBody]List<DynamicDataSourceParamDto> dtos)
        {
            using(var context = AtlasDbContextFactory.Instance.CreateDbContext())
            {
                var existingParams = context.DynamicDataSourceParam.Where(p => p.DynamicDataSourceRef == dataSourceId).ToList();

                var list = new List<AtlasModel.DynamicDataSourceParam>();
                dtos.Where(p => !existingParams.Any(t => t.ParamKey == p.ParamKey)).ToList().ForEach(p => list.Add(new AtlasModel.DynamicDataSourceParam()
                {
                    ObjectId = Guid.NewGuid(),
                    ParamKey = p.ParamKey,
                    DynamicDataSourceRef = p.DataSourceId
                }));
                var removedParams = existingParams.Where(p => !dtos.Any(t => t.ParamKey == p.ParamKey)).ToList();
                context.RemoveRange(removedParams);
                context.AddRange(list);
                return context.SaveChanges() == (list.Count + removedParams.Count);
            }
        }
        [HttpPost]
        [HvlResult]
        public object ExecuteCheckScript(ScriptDto dto)
        {
            Type type = Type.GetType($"DynamicForms.CheckScript.{dto.ClassName}");
            object classInstance = Activator.CreateInstance(type, null);
            try
            {
                var result = type.GetMethod("CheckScript").Invoke(classInstance, new object[] { dto.Params });
                return result;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(dto.ClassName + " not implemented.");
            }
        }

        [HttpPost]
        [HvlResult]
        public string UpdateDataSource(DataSourceDto dto)
        {
            using(var context = AtlasDbContextFactory.Instance.CreateDbContext())
            {
                var item = context.DynamicDataSource.Find(dto.ObjectID);
                item.ApiConfig = dto.ApiConfig;
                item.Description = dto.Description;
                item.Name = dto.Name;
                item.Type = dto.Type;
                item.IsActive = true;
                context.SaveChanges();
                return item.ObjectId.ToString();
            }
        }

        [HttpPost]
        [HvlResult]
        public string AddDataSource(DataSourceDto dto)
        {
            using (var context = AtlasDbContextFactory.Instance.CreateDbContext())
            {
                var item = new AtlasModel.DynamicDataSource()
                {
                    ApiConfig = dto.ApiConfig,
                    Description = dto.Description,
                    Name = dto.Name,
                    Type = dto.Type,
                    ObjectId = Guid.NewGuid(),
                    IsActive = true
                };
                context.Add(item);
                context.SaveChanges();
                return item.ObjectId.ToString();
            }
        }



        private void FindValue(dynamic formData, string fieldName, ref List<string> result)
        {
            foreach (dynamic key1 in ((Newtonsoft.Json.Linq.JObject)formData).Children())
            {
                var key = key1.Name;
                var item = formData[key];
                if (fieldName == key)
                {
                    result.Add(item.ToString());
                }

                if (item is Newtonsoft.Json.Linq.JArray)
                {
                    foreach (var subItem in item)
                    {
                        FindValue(subItem, fieldName, ref result);
                    }
                }
            }
        }


    }

    public class DynamicFormDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid ObjectID { get; set; }
        public bool? IsEnable { get; set; }
        public string ClassName { get; set; }
        public string CheckClassName { get; set; }
        public string LongName
        {
            get
            {
                return this.Name + " (Code = " + (string.IsNullOrEmpty(this.Code) ? "NULL" : this.Code) + ")";
            }
        }
    }
    public class DynamicFormRevisionDto
    {
        public string DynamicFormId { get; set; }
        public string Comment { get; set; }
        public string JsonTemplate { get; set; }
        public Guid? ObjectID { get; set; }
        public int? RevisionNumber { get; set; }
        public List<DynamicParameterDto> Parameters { get; set; }

    }
    public class DynamicFormExporter
    {
        public DynamicForm DynamicForm { get; set; }

        public DynamicFormRevision DynamicFormRevision { get; set; }

        public List<DynamicFormRevisionParam> DynamicFormRevisionParam { get; set; }
    }

    public class DynamicParameterDto
    {
        public string Key { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsFilter { get; set; }
        public Guid? ObjectID { get; set; }
    }

    public class DynamicDataSourceParamDto
    {
        public string ParamKey { get; set; }
        public Guid DataSourceId { get; set; }
    }

    public class DynamicFormDetails
    {
        public DynamicFormDto DynamicForm { get; set; }

        public DynamicFormRevisionDto DynamicFormRevision { get; set; }

        public List<DynamicParameterDto> DynamicFormRevisionParams { get; set; }
    }

    public class FormSubmissionDto
    {
        public string FormDataJson { get; set; }
        public string FormParamsJson { get; set; }
        public string FormJsonTemplate { get; set; }
        public int FormMode { get; set; }
        public bool? Action { get; set; }
        public string SubmissionID { get; set; }
        public string DynamicReportRevisionID { get; set; }
    }

    public class DynamicFormGridDto
    {
        public string DynamicFormID { get; set; }

        public string FormParamsJson { get; set; }
    }
    public class DynamicFormGridResultDto
    {
        public List<GridColumnDto> Columns { get; set; }

        public List<dynamic> ResultSet { get; set; }
    }

    public class FilterParamDto
    {
        public string ParamKey { get; set; }
        public Guid ObjectID { get; set; }
    }

    public class GridColumnDto
    {
        public string caption { get; set; }

        public string dataField { get; set; }
    }

    public class DynamicFormFormFieldSelector
    {
        public Guid? DynamicFormSubmissionRef { get; set; }
        public string Value { get; set; }
        public Guid? FormFieldIDRef { get; set; }
    }
    public class DynamicFormParamSelector
    {
        public Guid? DynamicFormSubmissionRef { get; set; }
        public string Value { get; set; }
        public Guid? FormParamRef { get; set; }
    }

    public class ScriptDto
    {
        public string ClassName { get; set; }
        public object ReportParams { get; set; }
        public string Params
        {
            get
            {
                if (ReportParams != null)
                {
                    return ReportParams.ToString();
                }
                return null;
            }
        }
    }

    public class DataSourceDto
    {
        public Guid? ObjectID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ApiConfig { get; set; }
        public int Type { get; set; }
        public List<DynamicParameterDto> Parameters { get; set; }
    }

    public class RevisionDto
    {
        public string RevisionId { get; set; }
    }

}