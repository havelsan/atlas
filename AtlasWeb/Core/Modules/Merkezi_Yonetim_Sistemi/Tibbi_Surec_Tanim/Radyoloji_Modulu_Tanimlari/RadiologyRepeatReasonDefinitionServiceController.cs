//$638D7C3A
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
    public partial class RadiologyRepeatReasonDefinitionServiceController : Controller
    {
        [HttpPost]
        public BindingList<RadiologyRepeatReasonDefinition> GetAll()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = RadiologyRepeatReasonDefinition.GetAll(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetRadiologyRepeatReasonDefinition_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<RadiologyRepeatReasonDefinition.GetRadiologyRepeatReasonDefinition_Class> GetRadiologyRepeatReasonDefinition(GetRadiologyRepeatReasonDefinition_Input input)
        {
            var ret = RadiologyRepeatReasonDefinition.GetRadiologyRepeatReasonDefinition(input.injectionSQL);
            return ret;
        }
    }
}