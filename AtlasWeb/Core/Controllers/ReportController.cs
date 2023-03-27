using Core.Models;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class ReportController : Controller
    {
        static Dictionary<ReportExportTargetType, string> ExportTargetMIMETypes = new Dictionary<ReportExportTargetType, string>()
        {
            {ReportExportTargetType.Excel, "application/vnd.ms-excel"},
            {ReportExportTargetType.Pdf, "application/pdf"},
            {ReportExportTargetType.XPS, "application/vnd.ms-xpsdocument"},
            {ReportExportTargetType.PlainText, "text/plain"},
            {ReportExportTargetType.HTML, "text/html"},
            {ReportExportTargetType.Word, "application/msword"},
            {ReportExportTargetType.Access, "application/x-msaccess"}
        };

        private byte[] RenderReportToPdfByteArray(TTReportDef reportDef, IDictionary<string, IQueryParam> reportParameters)
        {
            byte[] pdfContentBuffer = null;
            using (var memoryStream = RenderReportToStream(ReportExportTargetType.Pdf, reportDef, reportParameters))
            {
                pdfContentBuffer = memoryStream.ToArray();
            }

            return pdfContentBuffer;
        }

        private MemoryStream RenderReportToStream(ReportExportTargetType exportTargetType, TTReportDef reportDef, IDictionary<string, IQueryParam> reportParameters)
        {
            var  convertedParameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            if ( reportParameters != null)
            {
                foreach(var reportParameter in reportParameters)
                {
                    var convertedParam = new TTReportTool.PropertyCache<object>();
                    convertedParam.Add("VALUE", reportParameter.Value.paramValue);
                    convertedParameters.Add(reportParameter.Key, convertedParam);
                }
            }

            Type reportType = reportDef.ModuleDef.AssemblyDef.ReportAssembly.GetType("TTReportClasses." + reportDef.CodeName);
            var memoryStream = new TTUnclosableMemoryStream();
            switch (exportTargetType)
            {
                case ReportExportTargetType.Pdf:
                    TTReportTool.TTReport.ExportReportToPdf(reportType, convertedParameters, memoryStream);
                    break;
                case ReportExportTargetType.Excel:
                    TTReportTool.TTReport.ExportReportToExcel(reportType, convertedParameters, memoryStream);
                    break;
                case ReportExportTargetType.XPS:
                    TTReportTool.TTReport.ExportReportToXPS(reportType, convertedParameters, memoryStream);
                    break;
                case ReportExportTargetType.PlainText:
                    TTReportTool.TTReport.ExportReportToPlaintText(reportType, convertedParameters, memoryStream);
                    break;
                case ReportExportTargetType.HTML:
                    TTReportTool.TTReport.ExportReportToHTML(reportType, convertedParameters, memoryStream);
                    break;
                case ReportExportTargetType.Word:
                    TTReportTool.TTReport.ExportReportToWord(reportType, convertedParameters, memoryStream);
                    break;

            }

            memoryStream.SetClosable();
            return memoryStream;
        }

        [HttpPost]
        public byte[] RenderReportToPdf(ReportDefinition reportDefinition)
        {
            var reportDef = TTObjectDefManager.Instance.ReportDefs[reportDefinition.ReportDefID];
            return RenderReportToPdfByteArray(reportDef, null);
        }

        public class RenderReportWithReportNameInput
        {
            public string ReportName { get; set; }
            public IDictionary<string, IQueryParam> Parameters { get; set; }
        }

        [HttpPost]
        public IActionResult RenderReportToPdfWithReportName(RenderReportWithReportNameInput input)
        {
            var reportDef = TTObjectDefManager.Instance.ReportDefs[input.ReportName];
            var memoryStream = RenderReportToStream(ReportExportTargetType.Pdf, reportDef, input.Parameters);
            memoryStream.Position = 0;
            var response = new FileStreamResult(memoryStream, ExportTargetMIMETypes[ReportExportTargetType.Pdf]);
            return response;
        }

        [HttpPost]
        public IActionResult RenderReportToExcelWithReportName(RenderReportWithReportNameInput input)
        {
            var reportDef = TTObjectDefManager.Instance.ReportDefs[input.ReportName];
            var memoryStream = RenderReportToStream(ReportExportTargetType.Pdf, reportDef, input.Parameters);
            memoryStream.Position = 0;
            var response = new FileStreamResult(memoryStream, ExportTargetMIMETypes[ReportExportTargetType.Excel]);
            return response;
        }

        public class RenderReportWithReportNameAndFileTypeInput
        {
            public string ReportName { get; set; }
            public ReportExportTargetType ExportTargetType { get; set; }
            public IDictionary<string, IQueryParam> Parameters { get; set; }
        }

        [HttpPost]
        public IActionResult RenderReportWithReportNameAndFileType(RenderReportWithReportNameAndFileTypeInput input)
        {
            var reportDef = TTObjectDefManager.Instance.ReportDefs[input.ReportName];
            var memoryStream = RenderReportToStream(input.ExportTargetType, reportDef, input.Parameters);
            memoryStream.Position = 0;
            var response = new FileStreamResult(memoryStream, ExportTargetMIMETypes[input.ExportTargetType]);
            return response;
        }
    }
}