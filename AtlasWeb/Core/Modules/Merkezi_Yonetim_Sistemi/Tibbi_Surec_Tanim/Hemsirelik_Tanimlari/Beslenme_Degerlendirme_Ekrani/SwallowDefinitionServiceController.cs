//$39D34F4E
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
    public partial class SwallowDefinitionServiceController : Controller
    {
        public class GetSwallowList_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<SwallowDefinition.GetSwallowList_Class> GetSwallowList(GetSwallowList_Input input)
        {
            var ret = SwallowDefinition.GetSwallowList(input.injectionSQL);
            return ret;
        }
    }
}