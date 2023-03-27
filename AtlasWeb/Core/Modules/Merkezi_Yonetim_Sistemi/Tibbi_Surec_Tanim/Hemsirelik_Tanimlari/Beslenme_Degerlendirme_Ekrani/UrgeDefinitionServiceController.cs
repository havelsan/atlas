//$79D38823
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
    public partial class UrgeDefinitionServiceController : Controller
    {
        public class GetUrgeList_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<UrgeDefinition.GetUrgeList_Class> GetUrgeList(GetUrgeList_Input input)
        {
            var ret = UrgeDefinition.GetUrgeList(input.injectionSQL);
            return ret;
        }
    }
}