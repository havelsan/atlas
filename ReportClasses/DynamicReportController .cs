using DevExpress.XtraReports.Web.ReportDesigner;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Xml;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.ObjectBinding;
using System.Runtime.Serialization;

using System.Reflection.Emit;
using Infrastructure.Filters;
using System;
using System.Linq;
using ReportClasses.Controllers.DynamicReporting;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
using System.Threading.Tasks;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer.Native.Services;
using Microsoft.Net.Http.Headers;
using DevExpress.AspNetCore.Reporting.QueryBuilder;
using DevExpress.AspNetCore.Reporting.QueryBuilder.Native.Services;
using DevExpress.AspNetCore.Reporting.ReportDesigner.Native.Services;
using TTInstanceManagement;
using TTObjectClasses;
using ReportClasses.Modules.Core_Destek_Modulleri.Dinamik_Rapor_Modulu.ReportUtils;
using System.Collections.Generic;
using ReportClasses.ReportUtils;
using System.Data.OracleClient;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Http;

namespace ReportClasses.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public partial class DynamicReportController : Controller
    {
        public IActionResult GetReportDesignerModel([FromForm] string reportUrl)
        {
            var param = JsonConvert.DeserializeObject<ReportParameters>(reportUrl);

            DynamicReport dynamicReport = ResolveDynamicReport(param);
            param.ReportClassName = dynamicReport.ReportClassName;

            if (!string.IsNullOrEmpty(param.Code))
            {
                DynamicReportRevision dynamicReportRevision = ResolveMainRevision(dynamicReport.ObjectID.ToString());

                if (dynamicReportRevision != null)
                {
                    param.DynamicReportRevisionID = dynamicReportRevision.ObjectID.ToString();
                }
            }
            //string paramStr = JsonConvert.SerializeObject(param);
            if (ApiCaller.IISBaseUrl == null)
            {
                if (HttpContext != null && HttpContext.Request != null)
                {
                    ApiCaller.IISBaseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}";
                }
            }

            string modelJsonScript =
             new ReportDesignerClientSideModelGenerator(HttpContext.RequestServices)
             .GetJsonModelScript(
                 ReportResolver.GetXtraReport(param.DynamicReportRevisionID, param),// The URL of a report that is opened in the Report Designer when the application starts. 
                 ReportResolver.GetDataSources(param), // Available data sources in the Report Designer that can be added to reports. 
                 "ATLASDXXRD",   // The URI path of the controller action that processes requests from the Report Designer. 
                 "ATLASDXXRDV",// The URI path of the controller action that processes requests from the Web Document Viewer. 
                 "ATLASDXQB"      // The URI path of the controller action that processes requests from the Query Builder. 
             );
            return Content(modelJsonScript, "application/json");
        }

        //Dynamic Report From Code
        //or Dynamic Report From Report ID 


        public DynamicReport ResolveDynamicReport(ReportParameters param)
        {
            DynamicReport dynamicReport = null;
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                if (!string.IsNullOrEmpty(param.DynamicReportID))
                {
                    dynamicReport = _context.QueryObjects<DynamicReport>("ObjectID = '" + param.DynamicReportID + "'").FirstOrDefault();
                }
                else if (!string.IsNullOrEmpty(param.DynamicReportRevisionID))
                {
                    var revision = _context.QueryObjects<DynamicReportRevision>("ObjectID = '" + param.DynamicReportRevisionID + "'").FirstOrDefault();

                    if (revision == null)
                    {
                        throw new Exception("Couldnt found 'DynamicReportRevision' from 'ObjectID' = " + param.DynamicReportRevisionID);
                    }

                    dynamicReport = _context.QueryObjects<DynamicReport>("ObjectID = '" + revision.DynamicReport + "'").FirstOrDefault();

                }
                else if (!string.IsNullOrEmpty(param.Code))
                {
                    dynamicReport = _context.QueryObjects<DynamicReport>("Code = '" + param.Code + "' AND Enabled = 1").FirstOrDefault();
                }

                if (dynamicReport == null)
                {
                    throw new Exception("Couldnt found 'DynamicReport' from 'Code' = " + param.Code);
                }

                return dynamicReport;
            }
        }

        public DynamicReportRevision ResolveMainRevision(string dynamicReport)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var revision = _context.QueryObjects<DynamicReportRevision>("DynamicReport = '" + dynamicReport + "' and Enabled = 1 and IsMain = 1").FirstOrDefault();
                return revision;
            }
        }


        [HvlResult]
        [HttpPost]
        public object ResolveReportApi(ReportParameters reportParams)
        {
            var type = typeof(IDevexpressReport);
            var report = System.Reflection.Assembly.GetEntryAssembly().GetReferencedAssemblies().Where(x => x.Name.Contains("AtlasDataSource")).Select(System.Reflection.Assembly.Load).SelectMany(x => x.DefinedTypes).Where(p => type.IsAssignableFrom(p) && p.Name == reportParams.ReportClassName).FirstOrDefault();
            if (report != null)
            {
                return report.GetMethod(reportParams.ReportMethodName).Invoke(report, new object[] { reportParams.Params });
            }
            else
            {
                throw new NotImplementedException(reportParams.ReportClassName + " not implemented.");
            }
        }

        [HvlResult]
        [HttpPost]
        public bool SaveReport(ReportDto reportDto)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                DynamicReport dynamicReport = new DynamicReport(_context);
                dynamicReport.CreatedDate = Common.RecTime();
                dynamicReport.Enabled = true;
                dynamicReport.Name = reportDto.Name;
                dynamicReport.Code = reportDto.Code;
                dynamicReport.ReportClassName = reportDto.ReportClassName;
                _context.Save();
                return true;
            }
        }

        [HvlResult]
        [HttpGet]
        public bool SetEnableDisable(string objectID, bool enable)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var dashboard = _context.QueryObjects<TTObjectClasses.DynamicReport>("ObjectID = '" + objectID + "'").FirstOrDefault();
                dashboard.Enabled = enable;
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
                var newMain = _context.QueryObjects<DynamicReportRevision>("ObjectID = '" + objectID + "'").FirstOrDefault();

                if (newMain == null)
                {
                    throw new Exception("DynamicReportRevision not found");
                }

                var oldMains = _context.QueryObjects<DynamicReportRevision>("DynamicReport = '" + newMain.DynamicReport.ObjectID + "' AND IsMain = 1").ToList();

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
        public List<ReportDto> GetReports(bool getAll)
        {
            string injection = "Enabled = 1";
            if (getAll == true)
            {
                injection = string.Empty;
            }

            using (TTObjectContext _context = new TTObjectContext(false))
            {
                return _context.QueryObjects<DynamicReport>(injection).Select(x => new ReportDto() { ObjectID = x.ObjectID, Name = x.Name, ReportClassName = x.ReportClassName, Enabled = x.Enabled, Code = x.Code }).ToList();
            }
        }



        [HvlResult]
        [HttpGet]
        public List<string> GetDataSourceClasses(bool getAll)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                return _context.QueryObjects<DynamicReport>().Select(x => x.ReportClassName).GroupBy(x => x).Select(x => x.Key).ToList();
            }
        }

        [HvlResult]
        [HttpGet]
        public List<ReportRevisionDto> GetRevisionReports(string dynamicReportID)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                return _context.QueryObjects<DynamicReportRevision>("DynamicReport = '" + dynamicReportID + "' and Enabled = 1").OrderByDescending(x => x.RevisionNumber).Select(x => new ReportRevisionDto() { ObjectID = x.ObjectID, ReportComment = (x.IsMain == true ? "(A) " : "v." + x.RevisionNumber) + " - " + x.ReportComment }).ToList();
            }
        }


        [HvlResult]
        [HttpPost]
        public bool SaveReportRevision(ReportRevisionDto reportRevisionDto)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var dynamicReport = _context.QueryObjects<DynamicReport>("ObjectID = '" + reportRevisionDto.DynamicReport + "'").FirstOrDefault();
                if (dynamicReport == null)
                {
                    //Report Not Found
                    return false;
                }
                var lastRevisionNumber = _context.QueryObjects<DynamicReportRevision>("DynamicReport = '" + reportRevisionDto.DynamicReport + "'").OrderByDescending(x => x.RevisionNumber).Select(x => x.RevisionNumber).FirstOrDefault();
                if (lastRevisionNumber == null)
                {
                    lastRevisionNumber = 0;
                }
                lastRevisionNumber++;
                DynamicReportRevision reportRevision = new DynamicReportRevision(_context);
                reportRevision.CreatedBy = Common.CurrentResource;
                reportRevision.CreatedDate = Common.RecTime();
                reportRevision.DynamicReport = dynamicReport;
                reportRevision.Enabled = true;
                reportRevision.IsMain = lastRevisionNumber == 1 ? true : false;
                reportRevision.ReportComment = reportRevisionDto.ReportComment;
                reportRevision.ReportJSONContent = reportRevisionDto.ReportJSONContent;
                reportRevision.RevisionNumber = lastRevisionNumber;
                _context.Save();
                return true;
            }
        }

        [HvlResult]
        [HttpGet]
        public DynamicReportExporter DownloadReportRevision(string revisionID)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                DynamicReportExporter dynamicReportExporter = new DynamicReportExporter();

                dynamicReportExporter.DynamicReportRevision = _context.QueryObjects<DynamicReportRevision>("ObjectID = '" + revisionID + "'").FirstOrDefault();

                dynamicReportExporter.DynamicReport = _context.QueryObjects<DynamicReport>("ObjectID = '" + dynamicReportExporter.DynamicReportRevision.DynamicReport.ObjectID + "'").FirstOrDefault();

                return dynamicReportExporter;
            }
        }

        public class UploadViewModel
        {
            public IList<FormFile> Attachments { get; set; }
        }


        [HttpPost]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> UploadReport()
        {
            DynamicReportExporter export = null;
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
                    export = JsonConvert.DeserializeObject<DynamicReportExporter>(contentJson);
                }
            }
            catch
            {

            }


            if (export == null)
            {
                throw new Exception("Cant parse uplodad report.json file");
            }


            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var checkIfAlreadyExist = _context.QueryObjects<DynamicReport>("Code = '" + export.DynamicReport.Code + "'").ToList();

                if (checkIfAlreadyExist.Count > 0)
                {
                    foreach (var item in checkIfAlreadyExist)
                    {
                        item.Code = null;
                        item.Enabled = false;
                    }
                    _context.Save();
                }

                this.SaveReport(new ReportDto()
                {
                    Code = export.DynamicReport.Code,
                    Enabled = true,
                    Name = export.DynamicReport.Name,
                    ReportClassName = export.DynamicReport.ReportClassName
                });

                var dynamicReport = _context.QueryObjects<DynamicReport>("Code = '" + export.DynamicReport.Code + "'").FirstOrDefault();

                this.SaveReportRevision(new ReportRevisionDto()
                {
                    DynamicReport = dynamicReport.ObjectID.ToString(),
                    ReportComment = export.DynamicReportRevision.ReportComment,
                    ReportJSONContent = export.DynamicReportRevision.ReportJSONContent.ToString(),
                    RevisionNumber = export.DynamicReportRevision.RevisionNumber,
                });

            }


            return Ok();
        }

    }

    public class DynamicReportExporter
    {
        public DynamicReport DynamicReport { get; set; }

        public DynamicReportRevision DynamicReportRevision { get; set; }
    }

    [Route("ATLASDXXRDV")]
    public class CustomWebDocumentViewerController : WebDocumentViewerController
    {
        public CustomWebDocumentViewerController(IWebDocumentViewerMvcControllerService controllerService) : base(controllerService) { }

        public override Task<IActionResult> Invoke()
        {
            // Disable compression.
            Request.Headers[HeaderNames.AcceptEncoding] = "";

            return base.Invoke();
        }
    }


    [Route("ATLASDXQB")]
    public class CustomQueryBuilderController : QueryBuilderController
    {
        public CustomQueryBuilderController(IQueryBuilderMvcControllerService controllerService) : base(controllerService) { }
        public override Task<IActionResult> Invoke()
        {
            // Disable compression.
            Request.Headers[HeaderNames.AcceptEncoding] = "";

            return base.Invoke();
        }
    }

    [Route("ATLASDXXRD")]
    public class CustomReportDesignerController : DevExpress.AspNetCore.Reporting.ReportDesigner.ReportDesignerController
    {
        public CustomReportDesignerController(IReportDesignerMvcControllerService controllerService) : base(controllerService) { }
        public override Task<IActionResult> Invoke()
        {
            // Disable compression.
            Request.Headers[HeaderNames.AcceptEncoding] = "";

            return base.Invoke();
        }
    }
}