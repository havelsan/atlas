//$1DEFADEE
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
    public partial class PhysiotherapyRequestServiceController : Controller
    {
        public class GetTotalRoboticOrdersCount_Input
        {
            public System.Guid patientID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public int GetTotalRoboticOrdersCount(GetTotalRoboticOrdersCount_Input input)
        {
            var ret = PhysiotherapyRequest.GetTotalRoboticOrdersCount(input.patientID);
            return ret;
        }

        public class GetPhysiotheraphyHealthReport_Input
        {
            public string OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PhysiotherapyRequest.GetPhysiotheraphyHealthReport_Class> GetPhysiotheraphyHealthReport(GetPhysiotheraphyHealthReport_Input input)
        {
            var ret = PhysiotherapyRequest.GetPhysiotheraphyHealthReport(input.OBJECTID);
            return ret;
        }

        public class GetPhysiotherapyReport_Input
        {
            public string REPORTNO
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<PhysiotherapyRequest.GetPhysiotherapyReport_Class> GetPhysiotherapyReport(GetPhysiotherapyReport_Input input)
        {
            var ret = PhysiotherapyRequest.GetPhysiotherapyReport(input.REPORTNO);
            return ret;
        }
    }
}