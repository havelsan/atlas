//$FA93136D
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
    public partial class HealthCommitteeServiceController : Controller
    {
        public class CalculateFunctionRatio_Input
        {
            public TTObjectClasses.HealthCommittee healthCommittee
            {
                get;
                set;
            }
        }

        [HttpPost]
        public double ? CalculateFunctionRatio(CalculateFunctionRatio_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.healthCommittee != null)
                    input.healthCommittee = (TTObjectClasses.HealthCommittee)objectContext.AddObject(input.healthCommittee);
                var ret = HealthCommittee.CalculateFunctionRatio(input.healthCommittee);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class UnCompletedExaminationExists_Input
        {
            public TTObjectClasses.HealthCommittee healthCommittee
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool UnCompletedExaminationExists(UnCompletedExaminationExists_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.healthCommittee != null)
                    input.healthCommittee = (TTObjectClasses.HealthCommittee)objectContext.AddObject(input.healthCommittee);
                var ret = HealthCommittee.UnCompletedExaminationExists(input.healthCommittee);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class CheckIfAllCancelledOrNotExists_Input
        {
            public TTObjectClasses.HealthCommittee healthCommittee
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool CheckIfAllCancelledOrNotExists(CheckIfAllCancelledOrNotExists_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.healthCommittee != null)
                    input.healthCommittee = (TTObjectClasses.HealthCommittee)objectContext.AddObject(input.healthCommittee);
                var ret = HealthCommittee.CheckIfAllCancelledOrNotExists(input.healthCommittee);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class SendToLab_Input
        {
            public TTObjectClasses.HealthCommittee healthCommittee
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Saglik_Kurulu_Yeni_RU, TTRoleNames.Saglik_Kurulu_Yeni_RUW, TTRoleNames.Saglik_Kurulu_Yeni_ruw)]
        public void SendToLab(SendToLab_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.healthCommittee != null)
                    input.healthCommittee = (TTObjectClasses.HealthCommittee)objectContext.AddObject(input.healthCommittee);
                HealthCommittee.SendToLab(input.healthCommittee);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class GetCurrentHealthCommittee_Input
        {
            public Guid OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommittee.GetCurrentHealthCommittee_Class> GetCurrentHealthCommittee(GetCurrentHealthCommittee_Input input)
        {
            var ret = HealthCommittee.GetCurrentHealthCommittee(input.OBJECTID);
            return ret;
        }

        public class OLAP_GetHealthCommitteeByEpisode_Input
        {
            public string EPISODEID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommittee.OLAP_GetHealthCommitteeByEpisode_Class> OLAP_GetHealthCommitteeByEpisode(OLAP_GetHealthCommitteeByEpisode_Input input)
        {
            var ret = HealthCommittee.OLAP_GetHealthCommitteeByEpisode(input.EPISODEID);
            return ret;
        }

        public class GetHealthCommittees_Input
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
        public BindingList<HealthCommittee.GetHealthCommittees_Class> GetHealthCommittees(GetHealthCommittees_Input input)
        {
            var ret = HealthCommittee.GetHealthCommittees(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetAllHealthCommiteesOfPatient_Input
        {
            public string PATIENTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommittee> GetAllHealthCommiteesOfPatient(GetAllHealthCommiteesOfPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = HealthCommittee.GetAllHealthCommiteesOfPatient(objectContext, input.PATIENTOBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetXXXXXXApprovalHCsByDate_Input
        {
            public DateTime PARAMSTARTDATE
            {
                get;
                set;
            }

            public DateTime PARAMENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommittee.GetXXXXXXApprovalHCsByDate_Class> GetXXXXXXApprovalHCsByDate(GetXXXXXXApprovalHCsByDate_Input input)
        {
            var ret = HealthCommittee.GetXXXXXXApprovalHCsByDate(input.PARAMSTARTDATE, input.PARAMENDDATE);
            return ret;
        }

        public class OLAP_GetCancelledHealthCommittees_Input
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
        public BindingList<HealthCommittee.OLAP_GetCancelledHealthCommittees_Class> OLAP_GetCancelledHealthCommittees(OLAP_GetCancelledHealthCommittees_Input input)
        {
            var ret = HealthCommittee.OLAP_GetCancelledHealthCommittees(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class OLAP_GetHealthCommittesByDate_Input
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
        public BindingList<HealthCommittee.OLAP_GetHealthCommittesByDate_Class> OLAP_GetHealthCommittesByDate(OLAP_GetHealthCommittesByDate_Input input)
        {
            var ret = HealthCommittee.OLAP_GetHealthCommittesByDate(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class GetHCsByDateAndUniqueRefNo_Input
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

            public string UNIQUEREFNO
            {
                get;
                set;
            }

            public int UNIQUEREFNOFLAG
            {
                get;
                set;
            }

            public int HEALTHCOMITEETYPEFLAG
            {
                get;
                set;
            }

            public HealthCommitteeTypeEnum HEALTHCOMITEETYPE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommittee.GetHCsByDateAndUniqueRefNo_Class> GetHCsByDateAndUniqueRefNo(GetHCsByDateAndUniqueRefNo_Input input)
        {
            var ret = HealthCommittee.GetHCsByDateAndUniqueRefNo(input.STARTDATE, input.ENDDATE, input.UNIQUEREFNO, input.UNIQUEREFNOFLAG, input.HEALTHCOMITEETYPEFLAG, input.HEALTHCOMITEETYPE);
            return ret;
        }

        public class GetMSBApprovalHCsByDate_Input
        {
            public DateTime PARAMSTARTDATE
            {
                get;
                set;
            }

            public DateTime PARAMENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommittee.GetMSBApprovalHCsByDate_Class> GetMSBApprovalHCsByDate(GetMSBApprovalHCsByDate_Input input)
        {
            var ret = HealthCommittee.GetMSBApprovalHCsByDate(input.PARAMSTARTDATE, input.PARAMENDDATE);
            return ret;
        }

        public class GetHCReportGroupNameByPatient_Input
        {
            public string PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommittee.GetHCReportGroupNameByPatient_Class> GetHCReportGroupNameByPatient(GetHCReportGroupNameByPatient_Input input)
        {
            var ret = HealthCommittee.GetHCReportGroupNameByPatient(input.PATIENT);
            return ret;
        }

        public class GetByWLFilterExpression_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommittee> GetByWLFilterExpression(GetByWLFilterExpression_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = HealthCommittee.GetByWLFilterExpression(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetHealthCommitteeWL_Input
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

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommittee> GetHealthCommitteeWL(GetHealthCommitteeWL_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = HealthCommittee.GetHealthCommitteeWL(objectContext, input.STARTDATE, input.ENDDATE, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetHealthCommitteesByDate_Input
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
        public BindingList<HealthCommittee.GetHealthCommitteesByDate_Class> GetHealthCommitteesByDate(GetHealthCommitteesByDate_Input input)
        {
            var ret = HealthCommittee.GetHealthCommitteesByDate(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetHealthCommiteesOfEpisode_Input
        {
            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommittee> GetHealthCommiteesOfEpisode(GetHealthCommiteesOfEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = HealthCommittee.GetHealthCommiteesOfEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetHcBySlice_Input
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

            public int SLICEORDER
            {
                get;
                set;
            }

            public int SLICEFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommittee.GetHcBySlice_Class> GetHcBySlice(GetHcBySlice_Input input)
        {
            var ret = HealthCommittee.GetHcBySlice(input.STARTDATE, input.ENDDATE, input.SLICEORDER, input.SLICEFLAG);
            return ret;
        }

        public class GetNotCollectedInvoicableHealthCommitteeRQ_Input
        {
            public Guid EPISODEID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommittee.GetNotCollectedInvoicableHealthCommitteeRQ_Class> GetNotCollectedInvoicableHealthCommitteeRQ(GetNotCollectedInvoicableHealthCommitteeRQ_Input input)
        {
            var ret = HealthCommittee.GetNotCollectedInvoicableHealthCommitteeRQ(input.EPISODEID);
            return ret;
        }

        public class GetByPatientHProtNoAndActionID_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }

            public int EPISODEHOSPROTOCOLNO
            {
                get;
                set;
            }

            public int ACTIONID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommittee> GetByPatientHProtNoAndActionID(GetByPatientHProtNoAndActionID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = HealthCommittee.GetByPatientHProtNoAndActionID(objectContext, input.PATIENT, input.EPISODEHOSPROTOCOLNO, input.ACTIONID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetHealthCommitteesByType_Input
        {
            public DateTime ENDDATE
            {
                get;
                set;
            }

            public HealthCommitteeTypeEnum HEALTHCOMITEETYPE
            {
                get;
                set;
            }

            public int HEALTHCOMITEETYPEFLAG
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommittee.GetHealthCommitteesByType_Class> GetHealthCommitteesByType(GetHealthCommitteesByType_Input input)
        {
            var ret = HealthCommittee.GetHealthCommitteesByType(input.ENDDATE, input.HEALTHCOMITEETYPE, input.HEALTHCOMITEETYPEFLAG, input.STARTDATE);
            return ret;
        }

        public class GetHCsForPeriodicExaminationResultReport_Input
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
        public BindingList<HealthCommittee.GetHCsForPeriodicExaminationResultReport_Class> GetHCsForPeriodicExaminationResultReport(GetHCsForPeriodicExaminationResultReport_Input input)
        {
            var ret = HealthCommittee.GetHCsForPeriodicExaminationResultReport(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetHCsForAdditionalReport_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommittee.GetHCsForAdditionalReport_Class> GetHCsForAdditionalReport(GetHCsForAdditionalReport_Input input)
        {
            var ret = HealthCommittee.GetHCsForAdditionalReport(input.injectionSQL);
            return ret;
        }

        public class GetSuccessfulHCsByDateTypePatientGroup_Input
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

            public HealthCommitteeTypeEnum HEALTHCOMITEETYPE
            {
                get;
                set;
            }

            public int HEALTHCOMITEETYPEFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommittee.GetSuccessfulHCsByDateTypePatientGroup_Class> GetSuccessfulHCsByDateTypePatientGroup(GetSuccessfulHCsByDateTypePatientGroup_Input input)
        {
            var ret = HealthCommittee.GetSuccessfulHCsByDateTypePatientGroup(input.STARTDATE, input.ENDDATE, input.HEALTHCOMITEETYPE, input.HEALTHCOMITEETYPEFLAG);
            return ret;
        }

        public class GetHCsToSendSummary_Input
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
        public BindingList<HealthCommittee> GetHCsToSendSummary(GetHCsToSendSummary_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = HealthCommittee.GetHCsToSendSummary(objectContext, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetUncompletedHCsToSend_Input
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
        public BindingList<HealthCommittee> GetUncompletedHCsToSend(GetUncompletedHCsToSend_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = HealthCommittee.GetUncompletedHCsToSend(objectContext, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetUnsuccessfulHCsByDateTypePatientGroup_Input
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

            public HealthCommitteeTypeEnum HEALTHCOMITEETYPE
            {
                get;
                set;
            }

            public int HEALTHCOMITEETYPEFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<HealthCommittee.GetUnsuccessfulHCsByDateTypePatientGroup_Class> GetUnsuccessfulHCsByDateTypePatientGroup(GetUnsuccessfulHCsByDateTypePatientGroup_Input input)
        {
            var ret = HealthCommittee.GetUnsuccessfulHCsByDateTypePatientGroup(input.STARTDATE, input.ENDDATE, input.HEALTHCOMITEETYPE, input.HEALTHCOMITEETYPEFLAG);
            return ret;
        }

        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Saglik_Kurulu_Islem_Geri_Alma,TTRoleNames.Saglik_Kurulu_Tamamlanan_Islem_Geri_Alma)]
        public EpisodeActionData[] UndoHCExamination(string ObjectId)
        {
            HealthCommittee hc = null;
            using (var objectContext = new TTObjectContext(false))
            {
                hc = objectContext.GetObject(new Guid(ObjectId), "HealthCommittee") as HealthCommittee;
            }

            if (hc.CurrentStateDefID == HealthCommittee.States.Report)//report aşamasında ise 2 adım geri al. aradaki state kullanılmıyor
            {
                MainPatientFolderServiceController mpfsc1 = new MainPatientFolderServiceController();
                mpfsc1.UndoLastTransitionEAorSPFlowableByObjectId(ObjectId);
            }

            MainPatientFolderServiceController mpfsc = new MainPatientFolderServiceController();
            return mpfsc.UndoLastTransitionEAorSPFlowableByObjectId(ObjectId);
           
        }
    }
}