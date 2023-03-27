//$C9B34657
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
    public partial class RadiologyRejectReasonDefinitionServiceController : Controller
    {
        public class GetRadiologyRejectReasonDefinition_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<RadiologyRejectReasonDefinition.GetRadiologyRejectReasonDefinition_Class> GetRadiologyRejectReasonDefinition(GetRadiologyRejectReasonDefinition_Input input)
        {
            var ret = RadiologyRejectReasonDefinition.GetRadiologyRejectReasonDefinition(input.injectionSQL);
            return ret;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<RadiologyRejectReasonDefinition> GetAll()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = RadiologyRejectReasonDefinition.GetAll(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}