//$1DA2D7D1
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
    public partial class GlaskowComaScaleDefinitionServiceController : Controller
    {
        public class GetGlaskowComaScaleDefinition_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<GlaskowComaScaleDefinition.GetGlaskowComaScaleDefinition_Class> GetGlaskowComaScaleDefinition(GetGlaskowComaScaleDefinition_Input input)
        {
            var ret = GlaskowComaScaleDefinition.GetGlaskowComaScaleDefinition(input.injectionSQL);
            return ret;
        }

        public class GetGlasComaScaleDefByLastUpdateDate_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<GlaskowComaScaleDefinition> GetGlasComaScaleDefByLastUpdateDate(GetGlasComaScaleDefByLastUpdateDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = GlaskowComaScaleDefinition.GetGlasComaScaleDefByLastUpdateDate(objectContext, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}