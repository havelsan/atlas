//$D3C7A46B
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
    public partial class DentalProsthesisRequestSuggestedProsthesisServiceController : Controller
    {
        public class GetAllProsthesisByTechnician_Input
        {
            public Guid TECHNICIAN
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DentalProsthesisRequestSuggestedProsthesis> GetAllProsthesisByTechnician(GetAllProsthesisByTechnician_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DentalProsthesisRequestSuggestedProsthesis.GetAllProsthesisByTechnician(objectContext, input.TECHNICIAN);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class OLAP_GetSuggestedDentalProsthesis_Input
        {
            public string MA
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<DentalProsthesisRequestSuggestedProsthesis.OLAP_GetSuggestedDentalProsthesis_Class> OLAP_GetSuggestedDentalProsthesis(OLAP_GetSuggestedDentalProsthesis_Input input)
        {
            var ret = DentalProsthesisRequestSuggestedProsthesis.OLAP_GetSuggestedDentalProsthesis(input.MA);
            return ret;
        }
    }
}