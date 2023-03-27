//$7B07B92A
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
    public partial class GeneralProductionActionServiceController : Controller
    {
        public class GeneralProductionReportQuery_Input
        {
            public Guid TTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<GeneralProductionAction.GeneralProductionReportQuery_Class> GeneralProductionReportQuery(GeneralProductionReportQuery_Input input)
        {
            var ret = GeneralProductionAction.GeneralProductionReportQuery(input.TTOBJECTID);
            return ret;
        }

        public class GeneralProductionReportQuery2_Input
        {
            public Guid TTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<GeneralProductionAction.GeneralProductionReportQuery2_Class> GeneralProductionReportQuery2(GeneralProductionReportQuery2_Input input)
        {
            var ret = GeneralProductionAction.GeneralProductionReportQuery2(input.TTOBJECTID);
            return ret;
        }
    }
}