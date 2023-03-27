//$15C61DC6
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
    public partial class DentalTreatmentRequestServiceController : Controller
    {
        public class OLAP_GetCancelledDentalTreatmentResuest_Input
        {
            public DateTime FIRSTDATE
            {
                get;
                set;
            }

            public DateTime LASTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DentalTreatmentRequest.OLAP_GetCancelledDentalTreatmentResuest_Class> OLAP_GetCancelledDentalTreatmentResuest(OLAP_GetCancelledDentalTreatmentResuest_Input input)
        {
            var ret = DentalTreatmentRequest.OLAP_GetCancelledDentalTreatmentResuest(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class OLAP_GetDentalTreatmentResuest_Input
        {
            public DateTime FIRSTDATE
            {
                get;
                set;
            }

            public DateTime LASTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<DentalTreatmentRequest.OLAP_GetDentalTreatmentResuest_Class> OLAP_GetDentalTreatmentResuest(OLAP_GetDentalTreatmentResuest_Input input)
        {
            var ret = DentalTreatmentRequest.OLAP_GetDentalTreatmentResuest(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }
    }
}