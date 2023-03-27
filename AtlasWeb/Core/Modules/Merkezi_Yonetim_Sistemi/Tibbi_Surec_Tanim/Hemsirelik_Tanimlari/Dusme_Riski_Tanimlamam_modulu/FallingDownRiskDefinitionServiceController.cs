//$A04DFB4A
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
    public partial class FallingDownRiskDefinitionServiceController : Controller
    {
        public class GetFallingDownRiskDefinition_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<FallingDownRiskDefinition.GetFallingDownRiskDefinition_Class> GetFallingDownRiskDefinition(GetFallingDownRiskDefinition_Input input)
        {
            var ret = FallingDownRiskDefinition.GetFallingDownRiskDefinition(input.injectionSQL);
            return ret;
        }

        public class GetFallingDownRiskDefByLastUpdateDate_Input
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
        public BindingList<FallingDownRiskDefinition> GetFallingDownRiskDefByLastUpdateDate(GetFallingDownRiskDefByLastUpdateDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = FallingDownRiskDefinition.GetFallingDownRiskDefByLastUpdateDate(objectContext, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}