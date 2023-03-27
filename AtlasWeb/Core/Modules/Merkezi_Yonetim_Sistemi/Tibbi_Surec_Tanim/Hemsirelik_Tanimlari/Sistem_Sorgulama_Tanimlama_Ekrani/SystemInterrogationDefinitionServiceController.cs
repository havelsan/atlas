//$8FEAEB00
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
    public partial class SystemInterrogationDefinitionServiceController : Controller
    {
        public class GetSystemInterrogationDefinitionList_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<SystemInterrogationDefinition.GetSystemInterrogationDefinitionList_Class> GetSystemInterrogationDefinitionList(GetSystemInterrogationDefinitionList_Input input)
        {
            var ret = SystemInterrogationDefinition.GetSystemInterrogationDefinitionList(input.injectionSQL);
            return ret;
        }
    }
}