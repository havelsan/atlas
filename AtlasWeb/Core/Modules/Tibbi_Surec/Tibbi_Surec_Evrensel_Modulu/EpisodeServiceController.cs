//$652EA98C
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
    public partial class EpisodeServiceController : Controller
    {
        public class CalculatePatientDebt_Input
        {
            public TTObjectClasses.Episode episode
            {
                get;
                set;
            }

            public object serviceTotal
            {
                get;
                set;
            }

            public object advanceTotal
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.PatientEpisodePaymentDetail CalculatePatientDebt(CalculatePatientDebt_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episode != null)
                    input.episode = (TTObjectClasses.Episode)objectContext.AddObject(input.episode);
                var ret = Episode.CalculatePatientDebt(input.episode, input.serviceTotal, input.advanceTotal);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTransactionsForReceipt_Input
        {
            public TTObjectClasses.Episode episode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.IList GetTransactionsForReceipt(GetTransactionsForReceipt_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episode != null)
                    input.episode = (TTObjectClasses.Episode)objectContext.AddObject(input.episode);
                var ret = Episode.GetTransactionsForReceipt(input.episode);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GivenValuableMaterialsMsg_Input
        {
            public TTObjectClasses.Episode episode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GivenValuableMaterialsMsg(GivenValuableMaterialsMsg_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episode != null)
                    input.episode = (TTObjectClasses.Episode)objectContext.AddObject(input.episode);
                var ret = Episode.GivenValuableMaterialsMsg(input.episode);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class TakenValuableMaterialsMsg_Input
        {
            public TTObjectClasses.Episode episode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string TakenValuableMaterialsMsg(TakenValuableMaterialsMsg_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episode != null)
                    input.episode = (TTObjectClasses.Episode)objectContext.AddObject(input.episode);
                var ret = Episode.TakenValuableMaterialsMsg(input.episode);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class HasMainDiagnose_Input
        {
            public TTObjectClasses.Episode episode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool HasMainDiagnose(HasMainDiagnose_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episode != null)
                    input.episode = (TTObjectClasses.Episode)objectContext.AddObject(input.episode);
                var ret = Episode.HasMainDiagnose(input.episode);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMedulaTedaviTuruByPatientStatus_Input
        {
            public TTObjectClasses.SubEpisodeStatusEnum patientStatus
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.TedaviTuru GetMedulaTedaviTuruByPatientStatus(GetMedulaTedaviTuruByPatientStatus_Input input)
        {
            var ret = Episode.GetMedulaTedaviTuruByPatientStatus(input.patientStatus);
            return ret;
        }

        public class GetMyMedulaDiagnosisDefinitionICDCodes_Input
        {
            public TTObjectClasses.Episode episode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.List<string> GetMyMedulaDiagnosisDefinitionICDCodes(GetMyMedulaDiagnosisDefinitionICDCodes_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episode != null)
                    input.episode = (TTObjectClasses.Episode)objectContext.AddObject(input.episode);
                var ret = Episode.GetMyMedulaDiagnosisDefinitionICDCodes(input.episode);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class HasAnyEpisodePhysiotherapyOrderWithoutRobotikRehabilitasyon_Input
        {
            public TTObjectClasses.Episode episode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool HasAnyEpisodePhysiotherapyOrderWithoutRobotikRehabilitasyon(HasAnyEpisodePhysiotherapyOrderWithoutRobotikRehabilitasyon_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episode != null)
                    input.episode = (TTObjectClasses.Episode)objectContext.AddObject(input.episode);
                var ret = Episode.HasAnyEpisodePhysiotherapyOrderWithoutRobotikRehabilitasyon(input.episode);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class HasAnyEpisodeRobotikRehabilitasyon_Input
        {
            public TTObjectClasses.Episode episode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool HasAnyEpisodeRobotikRehabilitasyon(HasAnyEpisodeRobotikRehabilitasyon_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episode != null)
                    input.episode = (TTObjectClasses.Episode)objectContext.AddObject(input.episode);
                var ret = Episode.HasAnyEpisodeRobotikRehabilitasyon(input.episode);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByLastUpdateDate_Input
        {
            public DateTime DATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Episode> GetByLastUpdateDate(GetByLastUpdateDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Episode.GetByLastUpdateDate(objectContext, input.DATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class OLAP_GetInpatientDate_Input
        {
            public string EID
            {
                get;
                set;
            }
        }



        public class OLAP_GetEpisodeInformation_Input
        {
            public string EID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Episode.OLAP_GetEpisodeInformation_Class> OLAP_GetEpisodeInformation(OLAP_GetEpisodeInformation_Input input)
        {
            var ret = Episode.OLAP_GetEpisodeInformation(input.EID);
            return ret;
        }

        public class OLAP_GetEpisodeDiagnosis_Input
        {
            public string EID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Episode.OLAP_GetEpisodeDiagnosis_Class> OLAP_GetEpisodeDiagnosis(OLAP_GetEpisodeDiagnosis_Input input)
        {
            var ret = Episode.OLAP_GetEpisodeDiagnosis(input.EID);
            return ret;
        }

        public class OLAP_GetLastDiagnosis_Input
        {
            public string EID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Episode.OLAP_GetLastDiagnosis_Class> OLAP_GetLastDiagnosis(OLAP_GetLastDiagnosis_Input input)
        {
            var ret = Episode.OLAP_GetLastDiagnosis(input.EID);
            return ret;
        }

        public class OLAP_GetDailyInPatient_Input
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



        public class GetEpisodesByPatient_Input
        {
            public string PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Episode> GetEpisodesByPatient(GetEpisodesByPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Episode.GetEpisodesByPatient(objectContext, input.PATIENT, string.Empty);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class OLAP_GetEmergencyAdmission_Input
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
        public BindingList<Episode.OLAP_GetEmergencyAdmission_Class> OLAP_GetEmergencyAdmission(OLAP_GetEmergencyAdmission_Input input)
        {
            var ret = Episode.OLAP_GetEmergencyAdmission(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class OLAP_GetEpisodeResourceByStatus_Input
        {
            public string EPISODEID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Episode.OLAP_GetEpisodeResourceByStatus_Class> OLAP_GetEpisodeResourceByStatus(OLAP_GetEpisodeResourceByStatus_Input input)
        {
            var ret = Episode.OLAP_GetEpisodeResourceByStatus(input.EPISODEID);
            return ret;
        }

        public class GetDischargedPatientCount_Input
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
        public BindingList<Episode.GetDischargedPatientCount_Class> GetDischargedPatientCount(GetDischargedPatientCount_Input input)
        {
            var ret = Episode.GetDischargedPatientCount(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetInpatientAdmissionCount_Input
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


        public class GetByPatientAndDayLimitNQL_Input
        {
            public DateTime DAYLIMIT
            {
                get;
                set;
            }

            public Guid PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Episode.GetByPatientAndDayLimitNQL_Class> GetByPatientAndDayLimitNQL(GetByPatientAndDayLimitNQL_Input input)
        {
            var ret = Episode.GetByPatientAndDayLimitNQL(input.DAYLIMIT, input.PATIENT);
            return ret;
        }

        public class GetForCashOfficeSearch_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Episode.GetForCashOfficeSearch_Class> GetForCashOfficeSearch(GetForCashOfficeSearch_Input input)
        {
            var ret = Episode.GetForCashOfficeSearch(input.injectionSQL);
            return ret;
        }

        public class GetByDayLimitAndMainSpeciality_Input
        {
            public DateTime DAYLIMIT
            {
                get;
                set;
            }

            public IList<Guid> SPECIALITIES
            {
                get;
                set;
            }

            public string PATIENT
            {
                get;
                set;
            }

            public DateTime CURRENTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Episode> GetByDayLimitAndMainSpeciality(GetByDayLimitAndMainSpeciality_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Episode.GetByDayLimitAndMainSpeciality(objectContext, input.DAYLIMIT, input.SPECIALITIES, input.PATIENT, input.CURRENTDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }



        public class GetNotDiagnosisExistsByDateInterval_Input
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
        public BindingList<Episode.GetNotDiagnosisExistsByDateInterval_Class> GetNotDiagnosisExistsByDateInterval(GetNotDiagnosisExistsByDateInterval_Input input)
        {
            var ret = Episode.GetNotDiagnosisExistsByDateInterval(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class OLAP_GetCancelledEmergencyAdmission_Input
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
        public BindingList<Episode.OLAP_GetCancelledEmergencyAdmission_Class> OLAP_GetCancelledEmergencyAdmission(OLAP_GetCancelledEmergencyAdmission_Input input)
        {
            var ret = Episode.OLAP_GetCancelledEmergencyAdmission(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class GetByHospitalProtocolNo_Input
        {
            public string HPROTOCOLNO
            {
                get;
                set;
            }

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
        public BindingList<Episode> GetByHospitalProtocolNo(GetByHospitalProtocolNo_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Episode.GetByHospitalProtocolNo(objectContext, input.HPROTOCOLNO, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEpisodeInformation_RQ_Input
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
        public BindingList<Episode.GetEpisodeInformation_RQ_Class> GetEpisodeInformation_RQ(GetEpisodeInformation_RQ_Input input)
        {
            var ret = Episode.GetEpisodeInformation_RQ(input.STARTDATE, input.ENDDATE, input.injectionSQL);
            return ret;
        }

        public class GetEpisodesToSendEHRs_Input
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
        public BindingList<Episode.GetEpisodesToSendEHRs_Class> GetEpisodesToSendEHRs(GetEpisodesToSendEHRs_Input input)
        {
            var ret = Episode.GetEpisodesToSendEHRs(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetDiagnosisByPatientExamination_Input
        {
            public Guid PATIENTEXAMINATION
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Episode.GetDiagnosisByPatientExamination_Class> GetDiagnosisByPatientExamination(GetDiagnosisByPatientExamination_Input input)
        {
            var ret = Episode.GetDiagnosisByPatientExamination(input.PATIENTEXAMINATION);
            return ret;
        }

        public class GetByOpeningDate_Input
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
        public BindingList<Episode> GetByOpeningDate(GetByOpeningDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Episode.GetByOpeningDate(objectContext, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetOpenedOutPatientByDate_Input
        {
            public DateTime DATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Episode> GetOpenedOutPatientByDate(GetOpenedOutPatientByDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Episode.GetOpenedOutPatientByDate(objectContext, input.DATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEpisodes_Input
        {
            public IList<Guid> OBJECTIDS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Episode> GetEpisodes(GetEpisodes_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Episode.GetEpisodes(objectContext, input.OBJECTIDS);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetVeteransOfEpisodesByDate_Input
        {
            public DateTime OPENINGDATE
            {
                get;
                set;
            }

            public DateTime ENDOPENINGDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<Episode.GetVeteransOfEpisodesByDate_Class> GetVeteransOfEpisodesByDate(GetVeteransOfEpisodesByDate_Input input)
        {
            var ret = Episode.GetVeteransOfEpisodesByDate(input.OPENINGDATE, input.ENDOPENINGDATE);
            return ret;
        }

        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Kapali_Acik_Ek_Islemler)]
        public void OpenEpisode([FromQuery]Guid episodeId)
        {
            TTObjectContext context = new TTObjectContext(false);

            Episode episode = context.GetObject<Episode>(episodeId,false);
            if (episode != null)
            {
                //Vaka Zaten Açýk
                if (episode.CurrentStateDefID == Episode.States.Open)
                    throw new Exception(SystemMessage.GetMessage(959));
                if (episode.IsInvoicedCompletely == true)
                    throw new Exception("Faturasý kesilmiþ vaka açýlamaz.");
                episode.OpenEpisode();
                context.Save();
            }
            else
            {
                throw new Exception("Açýlacak vaka bulunamadý. Gönderilen parametre : " + episodeId.ToString());
            }
        }

        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Acik_Kapali_Ek_Islemler)]
        public void CloseEpisode([FromQuery]Guid episodeId)
        {
            TTObjectContext context = new TTObjectContext(false);

            Episode episode = context.GetObject<Episode>(episodeId, false);
            if (episode != null)
            {
                //Vaka Zaten Kapalý
                if (episode.CurrentStateDefID == Episode.States.Closed)
                    throw new Exception(SystemMessage.GetMessage(957));
                else if(episode.CurrentStateDefID == Episode.States.Open) //Açýksa Açýkdevama al
                    episode.CloseEpisodeToNew();
                else if(episode.CurrentStateDefID == Episode.States.ClosedToNew)//Açýkdevamsa kapalýya al
                    episode.CloseEpisode();
                context.Save();
            }
            else
            {
                throw new Exception("Açýlacak vaka bulunamadý. Gönderilen parametre : " + episodeId.ToString());
            }
        }
    }
}