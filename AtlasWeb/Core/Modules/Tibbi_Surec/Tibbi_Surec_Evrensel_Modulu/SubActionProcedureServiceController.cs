//$3E6A4995
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
    public partial class SubActionProcedureServiceController : Controller
    {
        public class GetMyNewAppointments_Input
        {
            public System.Guid objectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Radyoloji_Test_Randevu, TTRoleNames.Radyoloji_Test_R)]
        public System.ComponentModel.BindingList<TTObjectClasses.Appointment> GetMyNewAppointments(GetMyNewAppointments_Input input)
        {
            var ret = SubActionProcedure.GetMyNewAppointments(input.objectID);
            return ret;
        }

        public class GetMyCompletedAppointments_Input
        {
            public System.Guid objectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.ComponentModel.BindingList<TTObjectClasses.Appointment> GetMyCompletedAppointments(GetMyCompletedAppointments_Input input)
        {
            var ret = SubActionProcedure.GetMyCompletedAppointments(input.objectID);
            return ret;
        }

        public class GetMyCancelledAppointments_Input
        {
            public System.Guid objectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.ComponentModel.BindingList<TTObjectClasses.Appointment> GetMyCancelledAppointments(GetMyCancelledAppointments_Input input)
        {
            var ret = SubActionProcedure.GetMyCancelledAppointments(input.objectID);
            return ret;
        }

        public class MyNotApprovedAppointments_Input
        {
            public System.Guid objectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.ComponentModel.BindingList<TTObjectClasses.Appointment> MyNotApprovedAppointments(MyNotApprovedAppointments_Input input)
        {
            var ret = SubActionProcedure.MyNotApprovedAppointments(input.objectID);
            return ret;
        }

        public class GetFullAppointmentDescription_Input
        {
            public TTObjectClasses.SubActionProcedure subactionProcedure
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetFullAppointmentDescription(GetFullAppointmentDescription_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.subactionProcedure != null)
                    input.subactionProcedure = (TTObjectClasses.SubActionProcedure)objectContext.AddObject(input.subactionProcedure);
                var ret = SubActionProcedure.GetFullAppointmentDescription(input.subactionProcedure);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllConsultationProceduresOfPatient_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure> GetAllConsultationProceduresOfPatient(GetAllConsultationProceduresOfPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubActionProcedure.GetAllConsultationProceduresOfPatient(objectContext, input.PATIENT);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllConsultationProcOfEpisode_Input
        {
            public string EPISODEOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure> GetAllConsultationProcOfEpisode(GetAllConsultationProcOfEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubActionProcedure.GetAllConsultationProcOfEpisode(objectContext, input.EPISODEOBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllConsultationProcOfPatient_Input
        {
            public string PATIENTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure> GetAllConsultationProcOfPatient(GetAllConsultationProcOfPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubActionProcedure.GetAllConsultationProcOfPatient(objectContext, input.PATIENTOBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllConsultationProcOfSubEpisode_Input
        {
            public string EPISODE
            {
                get;
                set;
            }

            public string SUBEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure> GetAllConsultationProcOfSubEpisode(GetAllConsultationProcOfSubEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubActionProcedure.GetAllConsultationProcOfSubEpisode(objectContext, input.EPISODE, input.SUBEPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByObjectID_Input
        {
            public string PARAMOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure> GetByObjectID(GetByObjectID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubActionProcedure.GetByObjectID(objectContext, input.PARAMOBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetSubActionsByDate_Input
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
        public BindingList<SubActionProcedure> GetSubActionsByDate(GetSubActionsByDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubActionProcedure.GetSubActionsByDate(objectContext, input.PARAMSTARTDATE, input.PARAMENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTestsByPatient_Input
        {
            public string PATIENTID
            {
                get;
                set;
            }

            public DateTime MINDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure> GetTestsByPatient(GetTestsByPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubActionProcedure.GetTestsByPatient(objectContext, input.PATIENTID, input.MINDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTestsByPatientByTestByDate_Input
        {
            public string PATIENTID
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

            public string TESTID
            {
                get;
                set;
            }

            public string OBJECTDEFNAME
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure> GetTestsByPatientByTestByDate(GetTestsByPatientByTestByDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubActionProcedure.GetTestsByPatientByTestByDate(objectContext, input.PATIENTID, input.STARTDATE, input.ENDDATE, input.TESTID, input.OBJECTDEFNAME);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetSubActionProcedureByPObject_Input
        {
            public string POBJECT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure> GetSubActionProcedureByPObject(GetSubActionProcedureByPObject_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubActionProcedure.GetSubActionProcedureByPObject(objectContext, input.POBJECT);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetExaminationTestListNQL_Input
        {
            public IList<string> OBJECTIDS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure.GetExaminationTestListNQL_Class> GetExaminationTestListNQL(GetExaminationTestListNQL_Input input)
        {
            var ret = SubActionProcedure.GetExaminationTestListNQL(input.OBJECTIDS);
            return ret;
        }

        public class GetTestsByEpisode_Input
        {
            public string OBJECTDEFNAME
            {
                get;
                set;
            }

            public string TESTID
            {
                get;
                set;
            }

            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure> GetTestsByEpisode(GetTestsByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubActionProcedure.GetTestsByEpisode(objectContext, input.OBJECTDEFNAME, input.TESTID, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllTestsByEpisode_Input
        {
            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure> GetAllTestsByEpisode(GetAllTestsByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubActionProcedure.GetAllTestsByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByEpisodeAndSEP_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }

            public Guid SEP
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
        public BindingList<SubActionProcedure> GetByEpisodeAndSEP(GetByEpisodeAndSEP_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubActionProcedure.GetByEpisodeAndSEP(objectContext, input.EPISODE, input.SEP, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class OLAP_SGKStatisticQuery1_SECount_Input
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
        public BindingList<SubActionProcedure.OLAP_SGKStatisticQuery1_SECount_Class> OLAP_SGKStatisticQuery1_SECount(OLAP_SGKStatisticQuery1_SECount_Input input)
        {
            var ret = SubActionProcedure.OLAP_SGKStatisticQuery1_SECount(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class OLAP_SGKStatisticQuery1_PatientCount_Input
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
        public BindingList<SubActionProcedure.OLAP_SGKStatisticQuery1_PatientCount_Class> OLAP_SGKStatisticQuery1_PatientCount(OLAP_SGKStatisticQuery1_PatientCount_Input input)
        {
            var ret = SubActionProcedure.OLAP_SGKStatisticQuery1_PatientCount(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class OLAP_SGKStatisticQuery2_PatientCount_Input
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
        public BindingList<SubActionProcedure.OLAP_SGKStatisticQuery2_PatientCount_Class> OLAP_SGKStatisticQuery2_PatientCount(OLAP_SGKStatisticQuery2_PatientCount_Input input)
        {
            var ret = SubActionProcedure.OLAP_SGKStatisticQuery2_PatientCount(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetByEpisode_Input
        {
            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure> GetByEpisode(GetByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubActionProcedure.GetByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class OLAP_GetDentalTreatments_Input
        {
            public string EID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure.OLAP_GetDentalTreatments_Class> OLAP_GetDentalTreatments(OLAP_GetDentalTreatments_Input input)
        {
            var ret = SubActionProcedure.OLAP_GetDentalTreatments(input.EID);
            return ret;
        }

        public class OLAP_SGKStatisticQuery2_SECount_Input
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
        public BindingList<SubActionProcedure.OLAP_SGKStatisticQuery2_SECount_Class> OLAP_SGKStatisticQuery2_SECount(OLAP_SGKStatisticQuery2_SECount_Input input)
        {
            var ret = SubActionProcedure.OLAP_SGKStatisticQuery2_SECount(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetByEpisodeAndMasterPackage_Input
        {
            public string EPISODE
            {
                get;
                set;
            }

            public string MASTERPACKAGESP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure> GetByEpisodeAndMasterPackage(GetByEpisodeAndMasterPackage_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubActionProcedure.GetByEpisodeAndMasterPackage(objectContext, input.EPISODE, input.MASTERPACKAGESP);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetProcedureNameAndCode_Input
        {
            public Guid OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure.GetProcedureNameAndCode_Class> GetProcedureNameAndCode(GetProcedureNameAndCode_Input input)
        {
            var ret = SubActionProcedure.GetProcedureNameAndCode(input.OBJECTID);
            return ret;
        }

        public class GetOldInfoForRequestedProcedures_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure.GetOldInfoForRequestedProcedures_Class> GetOldInfoForRequestedProcedures(GetOldInfoForRequestedProcedures_Input input)
        {
            var ret = SubActionProcedure.GetOldInfoForRequestedProcedures(input.PATIENT);
            return ret;
        }

        public class GetOldInfoCountForRequestedProcedures_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubActionProcedure.GetOldInfoCountForRequestedProcedures_Class> GetOldInfoCountForRequestedProcedures(GetOldInfoCountForRequestedProcedures_Input input)
        {
            var ret = SubActionProcedure.GetOldInfoCountForRequestedProcedures(input.PATIENT);
            return ret;
        }

        public class GetSubActionProcedureByTimeInterval_Input
        {
            public Guid PATIENTID
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
        public BindingList<SubActionProcedure.GetSubActionProcedureByTimeInterval_Class> GetSubActionProcedureByTimeInterval(GetSubActionProcedureByTimeInterval_Input input)
        {
            var ret = SubActionProcedure.GetSubActionProcedureByTimeInterval(input.PATIENTID, input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetRequestedProceduresBySubEpisode_Input
        {
            public string SUBEPISODE
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
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<SubActionProcedure.GetRequestedProceduresBySubEpisode_Class> GetRequestedProceduresBySubEpisode(GetRequestedProceduresBySubEpisode_Input input)
        {
            var ret = SubActionProcedure.GetRequestedProceduresBySubEpisode(input.SUBEPISODE, input.STARTDATE, input.ENDDATE);
            return ret;
        }
    }
}