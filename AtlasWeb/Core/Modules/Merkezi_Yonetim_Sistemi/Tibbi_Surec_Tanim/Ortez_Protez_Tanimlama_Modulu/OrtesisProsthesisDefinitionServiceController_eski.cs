//$992C8ECE
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class OrtesisProsthesisDefinitionServiceController_eski : Controller
    {
        public class GetOrtesisProsthesisDefinitions_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<OrtesisProsthesisDefinition.GetOrtesisProsthesisDefinitions_Class> GetOrtesisProsthesisDefinitions(GetOrtesisProsthesisDefinitions_Input input)
        {
            var ret = OrtesisProsthesisDefinition.GetOrtesisProsthesisDefinitions(input.injectionSQL);
            return ret;
        }

        public class GetOrtesisProsthesisDefinitionByID_Input
        {
            public string OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<OrtesisProsthesisDefinition.GetOrtesisProsthesisDefinitionByID_Class> GetOrtesisProsthesisDefinitionByID(GetOrtesisProsthesisDefinitionByID_Input input)
        {
            var ret = OrtesisProsthesisDefinition.GetOrtesisProsthesisDefinitionByID(input.OBJECTID);
            return ret;
        }

        public class GetOrtesisProsthesisDefByLastUpdateDate_Input
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
        public BindingList<OrtesisProsthesisDefinition> GetOrtesisProsthesisDefByLastUpdateDate(GetOrtesisProsthesisDefByLastUpdateDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = OrtesisProsthesisDefinition.GetOrtesisProsthesisDefByLastUpdateDate(objectContext, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}