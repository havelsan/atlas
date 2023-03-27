//$7AF39FE0
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
    public partial class NursingOrderDetailServiceController : Controller
    {
        public class GetByNursingOrderDetail_Input
        {
            public Guid TTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<NursingOrderDetail.GetByNursingOrderDetail_Class> GetByNursingOrderDetail(GetByNursingOrderDetail_Input input)
        {
            var ret = NursingOrderDetail.GetByNursingOrderDetail(input.TTOBJECTID);
            return ret;
        }

        public class GetNODByNursingApplication_RQ_Input
        {
            public string NURSINGAPPLICATION
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<NursingOrderDetail.GetNODByNursingApplication_RQ_Class> GetNODByNursingApplication_RQ(GetNODByNursingApplication_RQ_Input input)
        {
            var ret = NursingOrderDetail.GetNODByNursingApplication_RQ(input.NURSINGAPPLICATION, input.injectionSQL);
            return ret;
        }

        public class GetNODByInPatientPhysicianApplication_Input
        {
            public string INPATIENTPHYAPP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<NursingOrderDetail> GetNODByInPatientPhysicianApplication(GetNODByInPatientPhysicianApplication_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = NursingOrderDetail.GetNODByInPatientPhysicianApplication(objectContext, input.INPATIENTPHYAPP);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetNODByPhysicianApplication_RQ_Input
        {
            public string INPATIENTPHYAPP
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<NursingOrderDetail.GetNODByPhysicianApplication_RQ_Class> GetNODByPhysicianApplication_RQ(GetNODByPhysicianApplication_RQ_Input input)
        {
            var ret = NursingOrderDetail.GetNODByPhysicianApplication_RQ(input.INPATIENTPHYAPP, input.injectionSQL);
            return ret;
        }
    }
}