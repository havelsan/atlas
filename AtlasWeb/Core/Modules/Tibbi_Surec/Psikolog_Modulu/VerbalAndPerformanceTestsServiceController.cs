//$853472B2
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
    public partial class VerbalAndPerformanceTestsServiceController : Controller
    {
        public class VerbalAndPerformanceTestsFormList_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<VerbalAndPerformanceTests.VerbalAndPerformanceTestsFormList_Class> VerbalAndPerformanceTestsFormList(VerbalAndPerformanceTestsFormList_Input input)
        {
            var ret = VerbalAndPerformanceTests.VerbalAndPerformanceTestsFormList(input.EPISODE);
            return ret;
        }
    }
}