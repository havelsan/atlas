//$5764F08B
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
    public partial class ToothDefinitionServiceController : Controller
    {
        public class GetToothList_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<ToothDefinition.GetToothList_Class> GetToothList(GetToothList_Input input)
        {
            var ret = ToothDefinition.GetToothList(input.injectionSQL);
            return ret;
        }
    }
}