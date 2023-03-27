using DevExpress.XtraReports.UI;
using ReportClasses.Controllers.DynamicReporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportClasses.Controllers
{
    public interface IDevexpressReport
    {
        Dictionary<string, object> GetDataSources(ReportParameters parameters);

        XtraReport GetXtraReport(string reportGuid, string parameters);

    }
}
