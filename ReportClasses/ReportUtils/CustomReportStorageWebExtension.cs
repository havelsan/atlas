using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReportClasses.Controllers
{
    public class CustomReportStorageWebExtension : ReportStorageWebExtension
    {
        public override string SetNewData(XtraReport report, string defaultUrl)
        {
            return base.SetNewData(report, defaultUrl);
        }
    }
}
