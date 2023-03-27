//$377131C1
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
    public partial class DentalTreatmentRequestSuggestedTreatmentServiceController : Controller
    {
        public class OLAP_GetSuggestedDentalTreatments_Input
        {
            public string MA
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<DentalTreatmentRequestSuggestedTreatment.OLAP_GetSuggestedDentalTreatments_Class> OLAP_GetSuggestedDentalTreatments(OLAP_GetSuggestedDentalTreatments_Input input)
        {
            var ret = DentalTreatmentRequestSuggestedTreatment.OLAP_GetSuggestedDentalTreatments(input.MA);
            return ret;
        }
    }
}