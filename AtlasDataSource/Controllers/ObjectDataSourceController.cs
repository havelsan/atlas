using Newtonsoft.Json;
using System;
using System.Linq;
using ReportClasses.Controllers.DynamicReporting;
using System.Threading.Tasks;
using TTInstanceManagement;
using TTObjectClasses;
using ReportClasses.Modules.Core_Destek_Modulleri.Dinamik_Rapor_Modulu.ReportUtils;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Filters;
using System.Reflection;
using Microsoft.AspNet.OData;

namespace AtlasDataSource.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public partial class ObjectDataSourceController : Controller
    {
        

        [HttpPost]
        public object ResolveReportApi(ReportParameters reportParams)
        {
             
            var report = System.Reflection.Assembly.GetEntryAssembly().GetReferencedAssemblies().Where(x => x.Name.Contains("AtlasDataSource")).Select(System.Reflection.Assembly.Load).SelectMany(x => x.DefinedTypes).Where(p =>  p.Name == reportParams.ReportClassName).FirstOrDefault();
            if (report != null)
            {
                MethodInfo toInvoke = report.GetMethod(reportParams.ReportMethodName);
                string Str = reportParams.Params != null ? reportParams.Params : "Murat";
                return toInvoke.Invoke(report, new object[] { reportParams.Params });
            }
            else
            {
                throw new NotImplementedException(reportParams.ReportClassName + " not implemented.");
            }
        }
    
    }       
}