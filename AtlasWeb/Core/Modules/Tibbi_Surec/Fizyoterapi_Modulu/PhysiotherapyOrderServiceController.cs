//$6EF15D90
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
    public partial class PhysiotherapyOrderServiceController : Controller
    {
        public class GetPhysiotherapyOrders_Input
        {
            public string PHYSIOTHERAPYREQUEST
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PhysiotherapyOrder.GetPhysiotherapyOrders_Class> GetPhysiotherapyOrders(GetPhysiotherapyOrders_Input input)
        {
            var ret = PhysiotherapyOrder.GetPhysiotherapyOrders(input.PHYSIOTHERAPYREQUEST);
            return ret;
        }

        public class GetMySiblingObjectsForAppointment_Input
        {
            public string PARAMEPISODE
            {
                get;
                set;
            }

            public string PARAMCURRENTOBJECT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PhysiotherapyOrder> GetMySiblingObjectsForAppointment(GetMySiblingObjectsForAppointment_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = PhysiotherapyOrder.GetMySiblingObjectsForAppointment(objectContext, input.PARAMEPISODE, input.PARAMCURRENTOBJECT);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class PhysiotherapyAcceptionReportNQL_Input
        {
            public string PHYSIOTHERAPYORDER
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PhysiotherapyOrder.PhysiotherapyAcceptionReportNQL_Class> PhysiotherapyAcceptionReportNQL(PhysiotherapyAcceptionReportNQL_Input input)
        {
            var ret = PhysiotherapyOrder.PhysiotherapyAcceptionReportNQL(input.PHYSIOTHERAPYORDER);
            return ret;
        }

        public class GetPhysiotherapyOrderList_Input
        {
            public Guid PHYSIOTHERAPYREQUEST
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PhysiotherapyOrder.GetPhysiotherapyOrderList_Class> GetPhysiotherapyOrderList(GetPhysiotherapyOrderList_Input input)
        {
            var ret = PhysiotherapyOrder.GetPhysiotherapyOrderList(input.PHYSIOTHERAPYREQUEST);
            return ret;
        }

        public class GetPhysiotherapyOrderByRequest_Input
        {
            public Guid PHYSIOTHERAPYREQUEST
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<PhysiotherapyOrder> GetPhysiotherapyOrderByRequest(GetPhysiotherapyOrderByRequest_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = PhysiotherapyOrder.GetPhysiotherapyOrderByRequest(objectContext, input.PHYSIOTHERAPYREQUEST);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}