//$7AAB4E49
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
    public partial class DischargeTypeDefinitionServiceController : Controller
    {
        public class GetDischargeTypeDefinitionList_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<DischargeTypeDefinition.GetDischargeTypeDefinitionList_Class> GetDischargeTypeDefinitionList(GetDischargeTypeDefinitionList_Input input)
        {
            var ret = DischargeTypeDefinition.GetDischargeTypeDefinitionList(input.injectionSQL);
            return ret;
        }
    }
}