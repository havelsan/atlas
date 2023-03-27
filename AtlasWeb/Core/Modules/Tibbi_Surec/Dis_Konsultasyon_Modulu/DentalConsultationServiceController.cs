//$CA9701E2
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
    public partial class DentalConsultationServiceController : Controller
    {
        public class OLAP_GetDentalConsultation_Input
        {
            public DateTime DATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<DentalConsultation.OLAP_GetDentalConsultation_Class> OLAP_GetDentalConsultation(OLAP_GetDentalConsultation_Input input)
        {
            var ret = DentalConsultation.OLAP_GetDentalConsultation(input.DATE);
            return ret;
        }
    }
}