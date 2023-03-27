//$52B73E47
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
    public partial class LaboratoryRequestServiceController : Controller
    {
        public class SendToLabLIS_Input
        {
            public TTObjectClasses.LaboratoryRequest laboratoryRequest
            {
                get;
                set;
            }
        }

        //[HttpPost]
        //public void SendToLabLIS(SendToLabLIS_Input input)
        //{
        //    using (var objectContext = new TTObjectContext(false))
        //    {
        //        if (input.laboratoryRequest != null)
        //            input.laboratoryRequest = (TTObjectClasses.LaboratoryRequest)objectContext.AddObject(input.laboratoryRequest);
        //        LaboratoryRequest.SendToLabLIS(input.laboratoryRequest);
        //        objectContext.FullPartialllyLoadedObjects();
        //    }
        //}

        public class SendToLabASync_Input
        {
            public TTObjectClasses.LaboratoryRequest laboratoryRequest
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Laboratuvar_Islemde_Kullanilmiyor, TTRoleNames.Laboratuvar_R_Kullanilmiyor, TTRoleNames.Laboratuvar_Islemde_R__Kullanilmiyor, TTRoleNames.Laboratuvar_Manuel_Sonuc_Girme, TTRoleNames.Laboratuvar_Istek_Kabul, TTRoleNames.Laboratuvar_Iptal_Kullanilmiyor)]
        public System.Guid SendToLabASync(SendToLabASync_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.laboratoryRequest != null)
                    input.laboratoryRequest = (TTObjectClasses.LaboratoryRequest)objectContext.AddObject(input.laboratoryRequest);
                var ret = LaboratoryRequest.SendToLabASync(input.laboratoryRequest);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class RollbackCancelLabSubProcedure_Input
        {
            public TTObjectClasses.LaboratorySubProcedure labProcedure
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void RollbackCancelLabSubProcedure(RollbackCancelLabSubProcedure_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.labProcedure != null)
                    input.labProcedure = (TTObjectClasses.LaboratorySubProcedure)objectContext.AddObject(input.labProcedure);
                LaboratoryRequest.RollbackCancelLabSubProcedure(input.labProcedure);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class CancelLabSubProcedure_Input
        {
            public TTObjectClasses.LaboratorySubProcedure labProcedure
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void CancelLabSubProcedure(CancelLabSubProcedure_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.labProcedure != null)
                    input.labProcedure = (TTObjectClasses.LaboratorySubProcedure)objectContext.AddObject(input.labProcedure);
                LaboratoryRequest.CancelLabSubProcedure(input.labProcedure);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class RollbackCancelLabProcedure_Input
        {
            public TTObjectClasses.LaboratoryProcedure labProcedure
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void RollbackCancelLabProcedure(RollbackCancelLabProcedure_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.labProcedure != null)
                    input.labProcedure = (TTObjectClasses.LaboratoryProcedure)objectContext.AddObject(input.labProcedure);
                LaboratoryRequest.RollbackCancelLabProcedure(input.labProcedure);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class CancelLabProcedure_Input
        {
            public TTObjectClasses.LaboratoryProcedure labProcedure
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void CancelLabProcedure(CancelLabProcedure_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.labProcedure != null)
                    input.labProcedure = (TTObjectClasses.LaboratoryProcedure)objectContext.AddObject(input.labProcedure);
                LaboratoryRequest.CancelLabProcedure(input.labProcedure);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class HISKabul_Input
        {
            public TTObjectClasses.LaboratoryRequest.HISKabulInfo hisKabul
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void HISKabul(HISKabul_Input input)
        {
            LaboratoryRequest.HISKabul(input.hisKabul);
        }

        public class LaboratoryReportNQL_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryRequest.LaboratoryReportNQL_Class> LaboratoryReportNQL(LaboratoryReportNQL_Input input)
        {
            var ret = LaboratoryRequest.LaboratoryReportNQL(input.PARAMOBJID);
            return ret;
        }

        public class GetLastTwoLaboratoryRequests_Input
        {
            public Guid PATIENTID
            {
                get;
                set;
            }

            public Guid MASTERRESOURCE
            {
                get;
                set;
            }

            public DateTime WORKLISTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryRequest.GetLastTwoLaboratoryRequests_Class> GetLastTwoLaboratoryRequests(GetLastTwoLaboratoryRequests_Input input)
        {
            var ret = LaboratoryRequest.GetLastTwoLaboratoryRequests(input.PATIENTID, input.MASTERRESOURCE, input.WORKLISTDATE);
            return ret;
        }

        public class GetLaboratoryRequestByBarcode_Input
        {
            public long BARCODEID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryRequest.GetLaboratoryRequestByBarcode_Class> GetLaboratoryRequestByBarcode(GetLaboratoryRequestByBarcode_Input input)
        {
            var ret = LaboratoryRequest.GetLaboratoryRequestByBarcode(input.BARCODEID);
            return ret;
        }

        public class LaboratoryResultsTrackingScreenNQL_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryRequest.LaboratoryResultsTrackingScreenNQL_Class> LaboratoryResultsTrackingScreenNQL(LaboratoryResultsTrackingScreenNQL_Input input)
        {
            var ret = LaboratoryRequest.LaboratoryResultsTrackingScreenNQL(input.injectionSQL);
            return ret;
        }

        public class GetLaboratoryRequestByFilter_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryRequest.GetLaboratoryRequestByFilter_Class> GetLaboratoryRequestByFilter(GetLaboratoryRequestByFilter_Input input)
        {
            var ret = LaboratoryRequest.GetLaboratoryRequestByFilter(input.injectionSQL);
            return ret;
        }

        public class LaboratoryTripleTestInfoNQL_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryRequest.LaboratoryTripleTestInfoNQL_Class> LaboratoryTripleTestInfoNQL(LaboratoryTripleTestInfoNQL_Input input)
        {
            var ret = LaboratoryRequest.LaboratoryTripleTestInfoNQL(input.PARAMOBJID);
            return ret;
        }

        public class LaboratoryBinaryScanInfoNQL_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<LaboratoryRequest.LaboratoryBinaryScanInfoNQL_Class> LaboratoryBinaryScanInfoNQL(LaboratoryBinaryScanInfoNQL_Input input)
        {
            var ret = LaboratoryRequest.LaboratoryBinaryScanInfoNQL(input.PARAMOBJID);
            return ret;
        }
    }
}