//$3812B1C5
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
    public partial class IQIntelligenceTestReportServiceController : Controller
    {
        public class IQIntelligenceTestReportFormList_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<IQIntelligenceTestReport.IQIntelligenceTestReportFormList_Class> IQIntelligenceTestReportFormList(IQIntelligenceTestReportFormList_Input input)
        {
            var ret = IQIntelligenceTestReport.IQIntelligenceTestReportFormList(input.EPISODE);
            return ret;
        }
    }
}