//$1DC68E86
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
    public partial class PainQualityDefinitionServiceController : Controller
    {
        public class GetPainQuality_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<PainQualityDefinition.GetPainQuality_Class> GetPainQuality(GetPainQuality_Input input)
        {
            var ret = PainQualityDefinition.GetPainQuality(input.injectionSQL);
            return ret;
        }
    }
}