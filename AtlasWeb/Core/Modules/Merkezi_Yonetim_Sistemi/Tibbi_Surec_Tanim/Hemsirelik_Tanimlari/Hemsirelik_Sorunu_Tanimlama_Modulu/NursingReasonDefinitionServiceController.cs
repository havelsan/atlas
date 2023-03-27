//$D3BB1A58
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
    public partial class NursingReasonDefinitionServiceController : Controller
    {
        public class GetNursingReasonDefinition_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<NursingReasonDefinition.GetNursingReasonDefinition_Class> GetNursingReasonDefinition(GetNursingReasonDefinition_Input input)
        {
            var ret = NursingReasonDefinition.GetNursingReasonDefinition(input.injectionSQL);
            return ret;
        }
    }
}