//$C3799A6A
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
    public partial class NursingAppliProgressServiceController : Controller
    {
        public class GetNursingApplicationProgress_Input
        {
            public Guid TTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<NursingAppliProgress.GetNursingApplicationProgress_Class> GetNursingApplicationProgress(GetNursingApplicationProgress_Input input)
        {
            var ret = NursingAppliProgress.GetNursingApplicationProgress(input.TTOBJECTID);
            return ret;
        }
    }
}