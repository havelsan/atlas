//$4DC0B7CE
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
    public partial class ManipulationRequestServiceController : Controller
    {
        public class GetManipulationRequestQuery_Input
        {
            public string REPORTNO
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<ManipulationRequest.GetManipulationRequestQuery_Class> GetManipulationRequestQuery(GetManipulationRequestQuery_Input input)
        {
            var ret = ManipulationRequest.GetManipulationRequestQuery(input.REPORTNO);
            return ret;
        }
    }
}