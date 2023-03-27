//$4E95850B
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
    public partial class RTFDefinitionsBySpecialityServiceController : Controller
    {
        public class GetBySpeciality_Input
        {
            public Guid SPECIALITY
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<RTFDefinitionsBySpeciality> GetBySpeciality(GetBySpeciality_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = RTFDefinitionsBySpeciality.GetBySpeciality(objectContext, input.SPECIALITY);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetRTFDefinitionsBySpecialityDefinition_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<RTFDefinitionsBySpeciality.GetRTFDefinitionsBySpecialityDefinition_Class> GetRTFDefinitionsBySpecialityDefinition(GetRTFDefinitionsBySpecialityDefinition_Input input)
        {
            var ret = RTFDefinitionsBySpeciality.GetRTFDefinitionsBySpecialityDefinition(input.injectionSQL);
            return ret;
        }
    }
}