//$7FF0E9A4
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
    public partial class PanoramaDefinitionServiceController : Controller
    {
        public class GetPanoramaList_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<PanoramaDefinition.GetPanoramaList_Class> GetPanoramaList(GetPanoramaList_Input input)
        {
            var ret = PanoramaDefinition.GetPanoramaList(input.injectionSQL);
            return ret;
        }
    }
}