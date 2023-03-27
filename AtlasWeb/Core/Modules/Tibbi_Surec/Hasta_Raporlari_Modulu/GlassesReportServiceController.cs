//$DA10073D
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class GlassesReportServiceController : Controller
    {
        public class ReceteKaydet_Input
        {
            public TTObjectClasses.GlassesReport _GlassesReport
            {
                get;
                set;
            }

            public bool ? vitrumFar
            {
                get;
                set;
            }

            public bool ? vitrumNear
            {
                get;
                set;
            }

            public bool ? vitrumCloseReading
            {
                get;
                set;
            }
        }

        

        public class GetGlassesReport_Input
        {
            public string OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<GlassesReport.GetGlassesReport_Class> GetGlassesReport(GetGlassesReport_Input input)
        {
            var ret = GlassesReport.GetGlassesReport(input.OBJECTID);
            return ret;
        }
    }
}