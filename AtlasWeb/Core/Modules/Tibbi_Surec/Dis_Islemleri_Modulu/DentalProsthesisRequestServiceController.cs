//$23BD3C33
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
    public partial class DentalProsthesisRequestServiceController : Controller
    {
        public class OLAP_GetCancelledDentalProsthesisRequest_Input
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
        public BindingList<DentalProsthesisRequest.OLAP_GetCancelledDentalProsthesisRequest_Class> OLAP_GetCancelledDentalProsthesisRequest(OLAP_GetCancelledDentalProsthesisRequest_Input input)
        {
            var ret = DentalProsthesisRequest.OLAP_GetCancelledDentalProsthesisRequest(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class OLAP_GetDentalProsthesisRequest_Input
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
        public BindingList<DentalProsthesisRequest.OLAP_GetDentalProsthesisRequest_Class> OLAP_GetDentalProsthesisRequest(OLAP_GetDentalProsthesisRequest_Input input)
        {
            var ret = DentalProsthesisRequest.OLAP_GetDentalProsthesisRequest(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }
    }
}