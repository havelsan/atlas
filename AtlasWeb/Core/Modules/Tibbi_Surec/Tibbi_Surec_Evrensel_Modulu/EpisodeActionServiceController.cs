//$82B92BB5
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
using Infrastructure.Helpers;
using Core.Modules.Tibbi_Surec.Tetkik_Istem_Modulu;
using Core.Modules.Tibbi_Surec.Laboratuar_Is_Listesi;
using AtlasModel.Enterprise;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class EpisodeActionServiceController : Controller
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
        public System.ComponentModel.BindingList<TTObjectClasses.Appointment> GetMyNewAppointments(GetMyNewAppointments_Input input)
        {
            var ret = EpisodeAction.GetMyNewAppointments(input.objectID);
            return ret;
        }

        public class MyCompletedAppointments_Input
        {
            public System.Guid objectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.ComponentModel.BindingList<TTObjectClasses.Appointment> MyCompletedAppointments(MyCompletedAppointments_Input input)
        {
            var ret = EpisodeAction.MyCompletedAppointments(input.objectID);
            return ret;
        }

        public class DiagnosisIsRequired_Input
        {
            public TTObjectClasses.EpisodeAction episodeAction
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void DiagnosisIsRequired(DiagnosisIsRequired_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episodeAction != null)
                    input.episodeAction = (TTObjectClasses.EpisodeAction)objectContext.AddObject(input.episodeAction);
                EpisodeAction.DiagnosisIsRequired(input.episodeAction);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class GetProcedureDefinitionNames_Input
        {
            public string objectDefName
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetProcedureDefinitionNames(GetProcedureDefinitionNames_Input input)
        {
            var ret = EpisodeAction.GetProcedureDefinitionNames(input.objectDefName);
            return ret;
        }

        public class GetAvailableUserResourcesByAllocation_Input
        {
            public TTObjectClasses.Episode episode
            {
                get;
                set;
            }

            public TTObjectClasses.EpisodeAction episodeAction
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.List<TTObjectClasses.Resource> GetAvailableUserResourcesByAllocation(GetAvailableUserResourcesByAllocation_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episode != null)
                    input.episode = (TTObjectClasses.Episode)objectContext.AddObject(input.episode);
                if (input.episodeAction != null)
                    input.episodeAction = (TTObjectClasses.EpisodeAction)objectContext.AddObject(input.episodeAction);
                var ret = EpisodeAction.GetAvailableUserResourcesByAllocation(input.episode, input.episodeAction);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class AcionDefualtMasterResources_Input
        {
            public TTObjectClasses.ActionTypeEnum? actionType
            {
                get;
                set;
            }

            public TTObjectClasses.EpisodeAction episodeAction
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.List<TTObjectClasses.ResSection> AcionDefualtMasterResources(AcionDefualtMasterResources_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                if (input.episodeAction != null)
                    input.episodeAction = (TTObjectClasses.EpisodeAction)context.AddObject(input.episodeAction);
                var ret = EpisodeAction.AcionDefualtMasterResources(context, input.actionType, input.episodeAction);
                context.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class LimitedMasterResourceTypes_Input
        {
            public TTObjectClasses.EpisodeAction episodeAction
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.ArrayList LimitedMasterResourceTypes(LimitedMasterResourceTypes_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episodeAction != null)
                    input.episodeAction = (TTObjectClasses.EpisodeAction)objectContext.AddObject(input.episodeAction);
                var ret = EpisodeAction.LimitedMasterResourceTypes(input.episodeAction);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class SetProcedureSpecialtyBy_Input
        {
            public System.Guid objectDefID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string SetProcedureSpecialtyBy(SetProcedureSpecialtyBy_Input input)
        {
            var ret = EpisodeAction.SetProcedureSpecialtyBy(input.objectDefID);
            return ret;
        }

        public class GetLinkedEpisodeActions_Input
        {
            public TTObjectClasses.EpisodeAction episodeActionParam
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.ArrayList GetLinkedEpisodeActions(GetLinkedEpisodeActions_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episodeActionParam != null)
                    input.episodeActionParam = (TTObjectClasses.EpisodeAction)objectContext.AddObject(input.episodeActionParam);
                var ret = EpisodeAction.GetLinkedEpisodeActions(input.episodeActionParam);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class ForkHealthCommitteeExamination_Input
        {
            public TTObjectClasses.HospitalsUnitsGrid hospitalsUnits
            {
                get;
                set;
            }

            public TTObjectClasses.EpisodeAction episodeAction
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void ForkHealthCommitteeExamination(ForkHealthCommitteeExamination_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.hospitalsUnits != null)
                    input.hospitalsUnits = (TTObjectClasses.HospitalsUnitsGrid)objectContext.AddObject(input.hospitalsUnits);
                if (input.episodeAction != null)
                    input.episodeAction = (TTObjectClasses.EpisodeAction)objectContext.AddObject(input.episodeAction);
                EpisodeAction.ForkHealthCommitteeExamination(input.hospitalsUnits, input.episodeAction);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class CheckPaid_Input
        {
            public System.Guid episodeActionObjectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void CheckPaid(CheckPaid_Input input)
        {
            EpisodeAction.CheckPaid(input.episodeActionObjectID);
        }

        public class IsFiredByPatientAdmission_Input
        {
            public TTObjectClasses.EpisodeAction episodeAction
            {
                get;
                set;
            }
        }

        public class CheckProvision_Input
        {
            public System.Guid episodeActionObjectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool CheckProvision(CheckProvision_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                Guid? selectedEpisodeActionObjectID = input.episodeActionObjectID;
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                if (episodeAction != null)
                {
                    if (!String.IsNullOrEmpty(episodeAction.SubEpisode.SGKSEP.MedulaTakipNo))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }

        }

        public class CheckInvoicedCompletely_Input
        {
            public System.Guid episodeActionObjectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool CheckInvoicedCompletely(CheckInvoicedCompletely_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                Guid? selectedEpisodeActionObjectID = input.episodeActionObjectID;
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                if (episodeAction != null)
                {
                    return episodeAction.SubEpisode.IsInvoicedCompletely;
                }
                else
                {
                    return false;
                }
            }
        }


        [HttpPost]
        public bool IsFiredByPatientAdmission(IsFiredByPatientAdmission_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episodeAction != null)
                    input.episodeAction = (TTObjectClasses.EpisodeAction)objectContext.AddObject(input.episodeAction);
                var ret = EpisodeAction.IsFiredByPatientAdmission(input.episodeAction);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class CheckAndCloseEpisode_Input
        {
            public System.Guid episodeActionObjectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void CheckAndCloseEpisode(CheckAndCloseEpisode_Input input)
        {
            EpisodeAction.CheckAndCloseEpisode(input.episodeActionObjectID);
        }

        public class GetSpecialResourceForStore_Input
        {
            public TTObjectClasses.EpisodeAction episodeAction
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.Resource GetSpecialResourceForStore(GetSpecialResourceForStore_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episodeAction != null)
                    input.episodeAction = (TTObjectClasses.EpisodeAction)objectContext.AddObject(input.episodeAction);
                var ret = EpisodeAction.GetSpecialResourceForStore(input.episodeAction);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllExaminationsOfPatient_Input
        {
            public string PATIENTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetAllExaminationsOfPatient(GetAllExaminationsOfPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetAllExaminationsOfPatient(objectContext, input.PATIENTOBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetBirthEpisodeAction_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetBirthEpisodeAction_Class> GetBirthEpisodeAction(GetBirthEpisodeAction_Input input)
        {
            var ret = EpisodeAction.GetBirthEpisodeAction(input.injectionSQL);
            return ret;
        }

        public class GetPatientInfoByEpisodeAction_Input
        {
            public string EPISODEACTION
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetPatientInfoByEpisodeAction_Class> GetPatientInfoByEpisodeAction(GetPatientInfoByEpisodeAction_Input input)
        {
            var ret = EpisodeAction.GetPatientInfoByEpisodeAction(input.EPISODEACTION);
            return ret;
        }

        public class GetEpisodeActionsByEpisode_Input
        {
            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetEpisodeActionsByEpisode(GetEpisodeActionsByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetEpisodeActionsByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllConsFromOtherHospOfPatient_Input
        {
            public string PATIENTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetAllConsFromOtherHospOfPatient(GetAllConsFromOtherHospOfPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetAllConsFromOtherHospOfPatient(objectContext, input.PATIENTOBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetUnCompletedEAByActiondate_Input
        {
            public DateTime ACTIONDATE
            {
                get;
                set;
            }

            public string MASTERRESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetUnCompletedEAByActiondate(GetUnCompletedEAByActiondate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetUnCompletedEAByActiondate(objectContext, input.ACTIONDATE, input.MASTERRESOURCE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEpisodesNotExistsMTS_Input
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
        public BindingList<EpisodeAction.GetEpisodesNotExistsMTS_Class> GetEpisodesNotExistsMTS(GetEpisodesNotExistsMTS_Input input)
        {
            var ret = EpisodeAction.GetEpisodesNotExistsMTS(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetConsFromOtherHospOfSubEpisode_Input
        {
            public Guid SUBEPISODE
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
        public BindingList<EpisodeAction> GetConsFromOtherHospOfSubEpisode(GetConsFromOtherHospOfSubEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetConsFromOtherHospOfSubEpisode(objectContext, input.SUBEPISODE, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPoliclinicExaminationDetail_Input
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

            public Guid MASTERRESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetPoliclinicExaminationDetail_Class> GetPoliclinicExaminationDetail(GetPoliclinicExaminationDetail_Input input)
        {
            var ret = EpisodeAction.GetPoliclinicExaminationDetail(input.STARTDATE, input.ENDDATE, input.MASTERRESOURCE);
            return ret;
        }

        public class GetEmergencyAdmissionCount_Input
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
        public BindingList<EpisodeAction.GetEmergencyAdmissionCount_Class> GetEmergencyAdmissionCount(GetEmergencyAdmissionCount_Input input)
        {
            var ret = EpisodeAction.GetEmergencyAdmissionCount(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetByEpisodeOrderByRequestDate_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetByEpisodeOrderByRequestDate(GetByEpisodeOrderByRequestDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetByEpisodeOrderByRequestDate(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEpisodeActionsByRequestDate_Input
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

            public Guid MASTERRESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetEpisodeActionsByRequestDate_Class> GetEpisodeActionsByRequestDate(GetEpisodeActionsByRequestDate_Input input)
        {
            var ret = EpisodeAction.GetEpisodeActionsByRequestDate(input.STARTDATE, input.ENDDATE, input.MASTERRESOURCE);
            return ret;
        }

        public class GetByWorklistDate_Input
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

            public DateTime MINDATE
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
        public BindingList<EpisodeAction> GetByWorklistDate(GetByWorklistDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetByWorklistDate(objectContext, input.STARTDATE, input.ENDDATE, input.MINDATE, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetInpatientFolderInfoForIAandNA_Input
        {
            public Guid EPISODEACTION
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetInpatientFolderInfoForIAandNA_Class> GetInpatientFolderInfoForIAandNA(GetInpatientFolderInfoForIAandNA_Input input)
        {
            var ret = EpisodeAction.GetInpatientFolderInfoForIAandNA(input.EPISODEACTION);
            return ret;
        }

        public class GetAllPatientExaminationsOfPatient_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetAllPatientExaminationsOfPatient(GetAllPatientExaminationsOfPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetAllPatientExaminationsOfPatient(objectContext, input.PATIENT);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEHREpisodeActionSubactProcFlowablesTotalAmount_Input
        {
            public Guid PROCEDUREID
            {
                get;
                set;
            }

            public Guid EPISODEACTIONID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetEHREpisodeActionSubactProcFlowablesTotalAmount_Class> GetEHREpisodeActionSubactProcFlowablesTotalAmount(GetEHREpisodeActionSubactProcFlowablesTotalAmount_Input input)
        {
            var ret = EpisodeAction.GetEHREpisodeActionSubactProcFlowablesTotalAmount(input.PROCEDUREID, input.EPISODEACTIONID);
            return ret;
        }

        public class GetUnCompletedEpisodeActionsByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }

            public Guid EAOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetUnCompletedEpisodeActionsByEpisode_Class> GetUnCompletedEpisodeActionsByEpisode(GetUnCompletedEpisodeActionsByEpisode_Input input)
        {
            var ret = EpisodeAction.GetUnCompletedEpisodeActionsByEpisode(input.EPISODE, input.EAOBJECTID);
            return ret;
        }

        public class GetByEpisodeActionFilterExpressionReport_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetByEpisodeActionFilterExpressionReport_Class> GetByEpisodeActionFilterExpressionReport(GetByEpisodeActionFilterExpressionReport_Input input)
        {
            var ret = EpisodeAction.GetByEpisodeActionFilterExpressionReport(input.injectionSQL);
            return ret;
        }

        public class GetByFilterExpression_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetByFilterExpression(GetByFilterExpression_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetByFilterExpression(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEndOfDayPoliclinicReport_Input
        {
            public DateTime ENDDATE
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public Guid MASTERRESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetEndOfDayPoliclinicReport_Class> GetEndOfDayPoliclinicReport(GetEndOfDayPoliclinicReport_Input input)
        {
            var ret = EpisodeAction.GetEndOfDayPoliclinicReport(input.ENDDATE, input.STARTDATE, input.MASTERRESOURCE);
            return ret;
        }

        public class GetByEpisodeAndId_Input
        {
            public string EPISODE
            {
                get;
                set;
            }

            public IList<string> ID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetByEpisodeAndId(GetByEpisodeAndId_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetByEpisodeAndId(objectContext, input.EPISODE, input.ID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByEpisodeActionWorklistDateReport_Input
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

            public DateTime MINDATE
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
        public BindingList<EpisodeAction.GetByEpisodeActionWorklistDateReport_Class> GetByEpisodeActionWorklistDateReport(GetByEpisodeActionWorklistDateReport_Input input)
        {
            var ret = EpisodeAction.GetByEpisodeActionWorklistDateReport(input.STARTDATE, input.ENDDATE, input.MINDATE, input.injectionSQL);
            return ret;
        }

        public class GetEpisodeActionsCount_Input
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
        public BindingList<EpisodeAction.GetEpisodeActionsCount_Class> GetEpisodeActionsCount(GetEpisodeActionsCount_Input input)
        {
            var ret = EpisodeAction.GetEpisodeActionsCount(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetByMasterAction_Input
        {
            public string MASTERACTIONOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetByMasterAction_Class> GetByMasterAction(GetByMasterAction_Input input)
        {
            var ret = EpisodeAction.GetByMasterAction(input.MASTERACTIONOBJECTID);
            return ret;
        }

        public class GetEpisodeActionByID_Input
        {
            public string ID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetEpisodeActionByID(GetEpisodeActionByID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetEpisodeActionByID(objectContext, input.ID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetLaboratoryRequestActionOfEpisode_Input
        {
            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetLaboratoryRequestActionOfEpisode(GetLaboratoryRequestActionOfEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetLaboratoryRequestActionOfEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEHREpisodeActionSubactionProcedures_Input
        {
            public Guid PROCEDUREID
            {
                get;
                set;
            }

            public Guid EPISODEACTIONID
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
        public BindingList<EpisodeAction.GetEHREpisodeActionSubactionProcedures_Class> GetEHREpisodeActionSubactionProcedures(GetEHREpisodeActionSubactionProcedures_Input input)
        {
            var ret = EpisodeAction.GetEHREpisodeActionSubactionProcedures(input.PROCEDUREID, input.EPISODEACTIONID, input.injectionSQL);
            return ret;
        }

        public class GetAllAnesthesiaConsultationOfEpisode_Input
        {
            public string EPISODEOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetAllAnesthesiaConsultationOfEpisode(GetAllAnesthesiaConsultationOfEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetAllAnesthesiaConsultationOfEpisode(objectContext, input.EPISODEOBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPoliclinicAdmissionCount_Input
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
        public BindingList<EpisodeAction.GetPoliclinicAdmissionCount_Class> GetPoliclinicAdmissionCount(GetPoliclinicAdmissionCount_Input input)
        {
            var ret = EpisodeAction.GetPoliclinicAdmissionCount(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetEpisodeActionsByObjectIDs_Input
        {
            public IList<string> OBJECTIDS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetEpisodeActionsByObjectIDs_Class> GetEpisodeActionsByObjectIDs(GetEpisodeActionsByObjectIDs_Input input)
        {
            var ret = EpisodeAction.GetEpisodeActionsByObjectIDs(input.OBJECTIDS);
            return ret;
        }

        public class GetEHREpisodeActionDiagnosis_Input
        {
            public Guid EPISODEACTIONID
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
        public BindingList<EpisodeAction.GetEHREpisodeActionDiagnosis_Class> GetEHREpisodeActionDiagnosis(GetEHREpisodeActionDiagnosis_Input input)
        {
            var ret = EpisodeAction.GetEHREpisodeActionDiagnosis(input.EPISODEACTIONID, input.injectionSQL);
            return ret;
        }

        public class GetExaminationsOfEpisode_Input
        {
            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetExaminationsOfEpisode(GetExaminationsOfEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetExaminationsOfEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetConsFromOtherHospOfEpisode_Input
        {
            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetConsFromOtherHospOfEpisode(GetConsFromOtherHospOfEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetConsFromOtherHospOfEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllAnesthesiaConsultationOfPatient_Input
        {
            public string PATIENTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetAllAnesthesiaConsultationOfPatient(GetAllAnesthesiaConsultationOfPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetAllAnesthesiaConsultationOfPatient(objectContext, input.PATIENTOBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetOldInfoForEpisodeAction_Input
        {
            public Guid SUBEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetOldInfoForEpisodeAction_Class> GetOldInfoForEpisodeAction(GetOldInfoForEpisodeAction_Input input)
        {
            var ret = EpisodeAction.GetOldInfoForEpisodeAction(input.SUBEPISODE);
            return ret;
        }

        public class GetEpisodeActionsOfPatientToInsertIntoQueue_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetEpisodeActionsOfPatientToInsertIntoQueue(GetEpisodeActionsOfPatientToInsertIntoQueue_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetEpisodeActionsOfPatientToInsertIntoQueue(objectContext, input.PATIENT);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEHREpisodeActionSubactionMaterialsTotalAmount_Input
        {
            public Guid EPISODEACTIONID
            {
                get;
                set;
            }

            public Guid MATERIALID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetEHREpisodeActionSubactionMaterialsTotalAmount_Class> GetEHREpisodeActionSubactionMaterialsTotalAmount(GetEHREpisodeActionSubactionMaterialsTotalAmount_Input input)
        {
            var ret = EpisodeAction.GetEHREpisodeActionSubactionMaterialsTotalAmount(input.EPISODEACTIONID, input.MATERIALID);
            return ret;
        }

        public class GetEHREpisodeActionSubactionProceduresTotalAmount_Input
        {
            public Guid EPISODEACTIONID
            {
                get;
                set;
            }

            public Guid PROCEDUREID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetEHREpisodeActionSubactionProceduresTotalAmount_Class> GetEHREpisodeActionSubactionProceduresTotalAmount(GetEHREpisodeActionSubactionProceduresTotalAmount_Input input)
        {
            var ret = EpisodeAction.GetEHREpisodeActionSubactionProceduresTotalAmount(input.EPISODEACTIONID, input.PROCEDUREID);
            return ret;
        }

        public class GetClinicStatisticsByDateDiagnosisAndPoliclinics_Input
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

            public Guid MASTERRESOURCE
            {
                get;
                set;
            }

            public IList<string> DIAGNOSIS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetClinicStatisticsByDateDiagnosisAndPoliclinics_Class> GetClinicStatisticsByDateDiagnosisAndPoliclinics(GetClinicStatisticsByDateDiagnosisAndPoliclinics_Input input)
        {
            var ret = EpisodeAction.GetClinicStatisticsByDateDiagnosisAndPoliclinics(input.STARTDATE, input.ENDDATE, input.MASTERRESOURCE, input.DIAGNOSIS);
            return ret;
        }

        public class GetEpisodeActionByObjectID_Input
        {
            public Guid OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetEpisodeActionByObjectID_Class> GetEpisodeActionByObjectID(GetEpisodeActionByObjectID_Input input)
        {
            var ret = EpisodeAction.GetEpisodeActionByObjectID(input.OBJECTID);
            return ret;
        }

        public class GetAllExaminationsExceptCurrentExamination_Input
        {
            public Guid MASTERRESOURCE
            {
                get;
                set;
            }

            public string PATIENT
            {
                get;
                set;
            }

            public Guid OBJECTID
            {
                get;
                set;
            }

            public DateTime REQUESTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetAllExaminationsExceptCurrentExamination(GetAllExaminationsExceptCurrentExamination_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetAllExaminationsExceptCurrentExamination(objectContext, input.MASTERRESOURCE, input.PATIENT, input.OBJECTID, input.REQUESTDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllDentalExaminationsOfPatient_Input
        {
            public string PATIENTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetAllDentalExaminationsOfPatient(GetAllDentalExaminationsOfPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetAllDentalExaminationsOfPatient(objectContext, input.PATIENTOBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientFolderEpisodeActions_Input
        {
            public Guid EPISODEID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetPatientFolderEpisodeActions_Class> GetPatientFolderEpisodeActions(GetPatientFolderEpisodeActions_Input input)
        {
            var ret = EpisodeAction.GetPatientFolderEpisodeActions(input.EPISODEID);
            return ret;
        }

        public class GetOutPatientsByPatientObjectIDs_Input
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

            public IList<Guid> PATIENTOBJECTIDS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction> GetOutPatientsByPatientObjectIDs(GetOutPatientsByPatientObjectIDs_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetOutPatientsByPatientObjectIDs(objectContext, input.STARTDATE, input.ENDDATE, input.PATIENTOBJECTIDS);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllAnesthesiaConsultationOfSubEpisode_Input
        {
            public string SUBEPISODE
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
        public BindingList<EpisodeAction> GetAllAnesthesiaConsultationOfSubEpisode(GetAllAnesthesiaConsultationOfSubEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAction.GetAllAnesthesiaConsultationOfSubEpisode(objectContext, input.SUBEPISODE, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpGet]
        public string GetActiveUserUniqueRefNo()
        {
            return Common.CurrentResource.UniqueNo;
        }

        public class GetActionDetailNQLByEpisode_Input
        {
            public Guid RESOURCE
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
        public BindingList<EpisodeAction.GetActionDetailNQLByEpisode_Class> GetActionDetailNQLByEpisode(GetActionDetailNQLByEpisode_Input input)
        {
            var ret = EpisodeAction.GetActionDetailNQLByEpisode(input.RESOURCE, input.EPISODE);
            return ret;
        }

        public class GetEpisodeActionsGroupByHasApp_Input
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

            public Guid MASTERRESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAction.GetEpisodeActionsGroupByHasApp_Class> GetEpisodeActionsGroupByHasApp(GetEpisodeActionsGroupByHasApp_Input input)
        {
            var ret = EpisodeAction.GetEpisodeActionsGroupByHasApp(input.STARTDATE, input.ENDDATE, input.MASTERRESOURCE);
            return ret;
        }

        public class GetStockEpisodeActionWorkListNQL_Input
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

            public IList<Guid> EPISODEOBJDEFIDS
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
        public BindingList<EpisodeAction.GetStockEpisodeActionWorkListNQL_Class> GetStockEpisodeActionWorkListNQL(GetStockEpisodeActionWorkListNQL_Input input)
        {
            var ret = EpisodeAction.GetStockEpisodeActionWorkListNQL(input.STARTDATE, input.ENDDATE, input.EPISODEOBJDEFIDS, input.injectionSQL);
            return ret;
        }

        public DailyInpatientInfoModel ControlDailyInpatient(Guid episodeActionID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction _episodeAction = objectContext.GetObject<EpisodeAction>(episodeActionID);
                DailyInpatientInfoModel result = new DailyInpatientInfoModel();
                if (_episodeAction.Episode.GetActiveInpatientAdmission() != null)
                {
                    InpatientAdmission activeInpatient = _episodeAction.Episode.GetActiveInpatientAdmission();
                    if (activeInpatient.InPatientTreatmentClinicApplications[0].IsDailyOperation == true)
                    {
                        result.HasDailyInpatient = true;
                        result.DailyInpatientProtocolNo = activeInpatient.SubEpisode.ProtocolNo;
                        return result;
                    }

                    else if (activeInpatient.InPatientTreatmentClinicApplications[0].IsDailyOperation == null || activeInpatient.InPatientTreatmentClinicApplications[0].IsDailyOperation == false)
                    {
                        result.HasNormalInpatient = true;
                        return result;
                    }
                }


                result.HasDailyInpatient = false;
                result.DailyInpatientProtocolNo = null;
                result.HasNormalInpatient = false;
                return result;
            }

        }

        [HttpPost]
        public bool DailyInpatientOperations(DailyProvisionInputModel input)
        {

            var objectContext = new TTObjectContext(false);

            //Yatana tasinana procedure objectlerin 102 paketlerinin ayaktandan gonderilmesinin onlenmesi icin

            EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(input.EpisodeAction.ObjectID);
            List<SubActionProcedure> dailyProcedures = episodeAction.SubactionProcedures.Where(x => x.ProcedureObject.DailyMedulaProvisionNecessity == true && x.IsCancelled != true).ToList();
            //List<SendToENabiz> nabizList = SendToENabiz.GetBySubEpisodeAndPackage(objectContext, episodeAction.SubEpisode.ObjectID, "102").ToList();
            List<SubActionMaterial> dailyMaterials = episodeAction.SubEpisode.SubActionMaterials.Where(x => x.Material.DailyStay == true && x.IsCancelled != true).ToList();

            //foreach (SubActionProcedure procedure in dailyProcedures)
            //{
            //    foreach(SendToENabiz nabiz in nabizList)
            //    {
            //        if(nabiz.InternalObjectID == procedure.ObjectID)
            //        {
            //            if (nabiz.Status == SendToENabizEnum.ToBeSent || nabiz.Status  == SendToENabizEnum.UnableToSent || nabiz.Status == SendToENabizEnum.UnSuccessful)
            //                nabiz.Status = SendToENabizEnum.NotToBeSent;
            //            else if(nabiz.Status == SendToENabizEnum.Successful)
            //                new SendToENabiz(objectContext, procedure.SubEpisode, procedure.ObjectID, nabiz.InternalObjectDefName, "302", Common.RecTime());
            //        }
            //    }
            //}

            //objectContext.Save();


            if (input.DailyInpatientControl == true)
            {
                //   EpisodeAction _episodeAction = objectContext.GetObject<EpisodeAction>(input.EpisodeAction.ObjectID);
                InpatientAdmission activeInpatientAdmission = episodeAction.Episode.GetActiveInpatientAdmission();

                foreach (SubActionProcedure procedure in dailyProcedures)
                {
                    if (!(procedure is SubActionPackageProcedure))
                    {
                        SubActionProcedure newProcedure = new SubActionProcedure();
                        newProcedure = (SubActionProcedure)procedure.Clone();
                        newProcedure.EpisodeAction = activeInpatientAdmission.InPatientTreatmentClinicApplications[0].InPatientPhysicianApplication[0];
                        newProcedure.SubEpisode = activeInpatientAdmission.InPatientTreatmentClinicApplications[0].InPatientPhysicianApplication[0].SubEpisode;
                    }

                    procedure.CurrentStateDefID = SubActionProcedure.States.Cancelled;

                }

                // Günübirlik takip gerektiren malzemeler klinik doktor işlemleri action ına taşınır

                foreach (BaseTreatmentMaterial subActMaterial in dailyMaterials)
                {
                    StockActionDetail stockActionDetail = subActMaterial.StockActionDetail;
                    Store store = subActMaterial.StockActionDetail.StockAction.Store;
                    subActMaterial.CurrentStateDefID = BaseTreatmentMaterial.States.Cancelled;
                    subActMaterial.StockActionDetail = null;
                    objectContext.Update();

                    BaseTreatmentMaterial newMaterial = new BaseTreatmentMaterial(objectContext);
                    newMaterial.Store = store;
                    newMaterial.Eligible = subActMaterial.Eligible;
                    newMaterial.Material = subActMaterial.Material;
                    newMaterial.Amount = subActMaterial.Amount;
                    newMaterial.EpisodeAction = activeInpatientAdmission.InPatientTreatmentClinicApplications[0].InPatientPhysicianApplication[0];
                    newMaterial.StockActionDetail = stockActionDetail;
                    newMaterial.SubEpisode = activeInpatientAdmission.InPatientTreatmentClinicApplications[0].InPatientPhysicianApplication[0].SubEpisode;
                }

                objectContext.Save();
            }

            else if (input.DailyInpatientControl == false)
            {

                DateTime InpatientDate = input.InpatientDate;
                ResUser procedureDoctor = objectContext.GetObject<ResUser>(input.ProcedureDoctorID);
                InpatientAdmission DailyInpatient = new InpatientAdmission(objectContext);

                Guid? selectedEpisodeActionObjectID = input.EpisodeAction.ObjectID;
                DailyInpatient.CurrentStateDefID = InpatientAdmission.States.Request;
                //   var currenstate = DailyInpatient.CurrentStateDefID;


                if (selectedEpisodeActionObjectID.HasValue)
                {
                    //  EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    DailyInpatient.FromResource = episodeAction.MasterResource;
                    DailyInpatient.Episode = episodeAction.Episode;
                    DailyInpatient.SubEpisode = episodeAction.SubEpisode;
                    DailyInpatient.TreatmentClinic = objectContext.GetObject<ResClinic>(input.TreatmentClinic); // objectContext.GetObject<ResClinic>(new Guid("5592d13e-578a-47e9-b377-a74744f6c2b3"));
                    DailyInpatient.RequestDate = InpatientDate;
                    //  var diagnosis = episodeAction.SubEpisode.Diagnosis[0];
                    // DailyInpatient.Diagnosis[0] = diagnosis;

                    bool isEmergency = false;
                    if (episodeAction is PatientExamination && ((PatientExamination)episodeAction).EmergencyIntervention != null)
                        isEmergency = true;
                    /*      if (!isEmergency)
                              viewModel.TreatmentClinicFilter = GetTreatmentClinicListFilter(defaultTreatmentClinicList);
                          viewModel._InpatientAdmission.SetProcedureDoctorAsCurrentResource();

                             ////////////////////////////////////////////////////////////// //treatmentclinicfilter gunubirlik servisler icin gelecek birimlerle doldurulacak.


                  */

                    if (DailyInpatient.ProcedureDoctor == null)
                        DailyInpatient.ProcedureDoctor = procedureDoctor;

                    //DailyInpatient.RequestDate = Common.RecTime();

                    //  DailyInpatient.RequestDate = Common.RecTime();

                    DailyInpatient.EstimatedInpatientDate = DailyInpatient.RequestDate; // Default Değer olarak atanıyor
                    if (DailyInpatient.NeedCompanion == null)
                        DailyInpatient.NeedCompanion = true;



                    objectContext.Update();

                    if (DailyInpatient.CurrentStateDefID == InpatientAdmission.States.Request)
                    {
                        DailyInpatient.CurrentStateDefID = InpatientAdmission.States.ClinicProcedure;
                        objectContext.Update();
                    }

                    //Poliklinik modulunden verilerin alinip yatis istek yapilmasina kadar olan adimlar burda set edildi.

                    //----------------------------//


                    //Asagidaki adimlar yatis bekleyen hastalar islemiyle devam eder.

                    InPatientTreatmentClinicApplication DailyTreatmentClinicApp = DailyInpatient.InPatientTreatmentClinicApplications.Where(T => T.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Acception || T.CurrentStateDefID == InPatientTreatmentClinicApplication.States.PreAcception).FirstOrDefault();

                    DailyTreatmentClinicApp.CurrentStateDefID = InPatientTreatmentClinicApplication.States.Acception;
                    DailyTreatmentClinicApp.ClinicInpatientDate = InpatientDate; //Common.RecTime();
                    DailyTreatmentClinicApp.ProcedureDoctor = procedureDoctor;
                    DailyTreatmentClinicApp.MasterResource = DailyInpatient.TreatmentClinic; //input.TreatmentClinic; //////////////////////////////////// Bu alan yeniden yapılandırılacak.
                    DailyTreatmentClinicApp.IsDailyOperation = true;
                    DailyTreatmentClinicApp.RequestDate = InpatientDate;

                    objectContext.Update();

                    DailyTreatmentClinicApp.CurrentStateDefID = InPatientTreatmentClinicApplication.States.Procedure;
                    objectContext.Update();


                    InPatientPhysicianApplication DailyInPatientPhysicianApplication = DailyTreatmentClinicApp.InPatientPhysicianApplication[0];
                    //   DailyInPatientPhysicianApplication.Complaint = input.Epicrisis;
                    DailyInPatientPhysicianApplication.Complaint = "";
                    DailyInPatientPhysicianApplication.ProcedureDoctor = procedureDoctor;
                    DailyInPatientPhysicianApplication.RequestDate = InpatientDate;
                    DailyInPatientPhysicianApplication.VentilatorStatus = SKRSDurum.GetSkrsDurumObj(objectContext, "Where KODU=2").FirstOrDefault();

                    // Günübirlik takip gerektiren hizmetler klinik doktor işlemleri action ına taşınır
                    foreach (SubActionProcedure procedure in dailyProcedures)
                    {
                        if (!(procedure is SubActionPackageProcedure))
                        {
                            SubActionProcedure newProcedure = new SubActionProcedure();
                            newProcedure = (SubActionProcedure)procedure.Clone();
                            newProcedure.EpisodeAction = DailyInPatientPhysicianApplication;
                            newProcedure.SubEpisode = DailyInPatientPhysicianApplication.SubEpisode;
                        }

                        procedure.CurrentStateDefID = SubActionProcedure.States.Cancelled;

                    }

                    // Günübirlik takip gerektiren malzemeler klinik doktor işlemleri action ına taşınır
                    foreach (BaseTreatmentMaterial subActMaterial in dailyMaterials)
                    {
                        StockActionDetail stockActionDetail = subActMaterial.StockActionDetail;
                        Store store = subActMaterial.StockActionDetail.StockAction.Store;
                        subActMaterial.CurrentStateDefID = BaseTreatmentMaterial.States.Cancelled;
                        subActMaterial.StockActionDetail = null;
                        objectContext.Update();

                        BaseTreatmentMaterial newMaterial = new BaseTreatmentMaterial(objectContext);
                        newMaterial.Store = store;
                        newMaterial.Eligible = subActMaterial.Eligible;
                        newMaterial.Material = subActMaterial.Material;
                        newMaterial.Amount = subActMaterial.Amount;
                        newMaterial.EpisodeAction = DailyInPatientPhysicianApplication;
                        newMaterial.StockActionDetail = stockActionDetail;
                        newMaterial.SubEpisode = DailyInPatientPhysicianApplication.SubEpisode;
                        //    newMaterial.Store = subActMaterial.StockActionDetail.StockAction.Store;

                        //subActMaterial.StockActionDetail = null;
                        //subActMaterial.CurrentStateDefID = BaseTreatmentMaterial.States.Cancelled;
                    }

                    // Günübirlik takip gerektiren hizmetlerin içinde Gündüz Yatak hizmeti varsa, günübirlik takibin oluşturduğu DailyBedProcedure iptal edilir. 
                    // (2 tane Gündüz Yatak hizmeti olmasın diye) - Mustafa
                    if (dailyProcedures.Any(x => x.ProcedureObject.Code == ProcedureDefinition.DailyBedProcedureSUTCode))
                    {
                        List<SubActionProcedure> dailyProcList = DailyInPatientPhysicianApplication.SubEpisode.SubActionProcedures.Where(x => x is DailyBedProcedure && !x.IsCancelled).ToList();
                        foreach (SubActionProcedure dailyProc in dailyProcList)
                            dailyProc.CurrentStateDefID = SubActionProcedure.States.Cancelled;
                    }

                    DailyInPatientPhysicianApplication.CurrentStateDefID = InPatientPhysicianApplication.States.Application;
                    objectContext.Update();

                    NursingApplication DailyNursingApplication = DailyTreatmentClinicApp.NursingApplications[0];
                    DailyNursingApplication.CurrentStateDefID = NursingApplication.States.Application;
                    DailyNursingApplication.ProcedureDoctor = procedureDoctor;
                    DailyNursingApplication.RequestDate = InpatientDate;
                    //    DailyNursingApplication.MasterResource = input.TreatmentClinic;

                    InPatientPhysicianProgresses summaryEpicrisis = new InPatientPhysicianProgresses(objectContext);

                    summaryEpicrisis.Description = input.Epicrisis;
                    summaryEpicrisis.ProgressDate = InpatientDate; //Common.RecTime();
                    summaryEpicrisis.ProcedureDoctor = procedureDoctor;
                    summaryEpicrisis.SubEpisode = DailyInPatientPhysicianApplication.SubEpisode;
                    summaryEpicrisis.EntryEpisodeAction = DailyInPatientPhysicianApplication;
                    objectContext.Update();



                    TreatmentDischarge DailyTreatmentDischarge = new TreatmentDischarge(objectContext);
                    DailyTreatmentDischarge.SetTreatmentDischargePropertiesByMasterEpisodeAction(DailyInPatientPhysicianApplication);

                    //  var dischargeDate = new DateTime(((DateTime)InpatientDate).Year, ((DateTime)InpatientDate).Month, ((DateTime)InpatientDate).Day, 23, 59, 59);
                    var today = DateTime.Now;
                    // var dischargeDate = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59);
                    var dischargeDate = new DateTime(((DateTime)InpatientDate).Year, ((DateTime)InpatientDate).Month, ((DateTime)InpatientDate).Day, 23, 59, 59);
                    DailyTreatmentDischarge.DischargeDate = dischargeDate;
                    DailyTreatmentDischarge.RequestDate = InpatientDate;
                    DailyTreatmentDischarge.InPatientTreatmentClinicApp.ClinicDischargeDate = DailyTreatmentDischarge.DischargeDate;

                    var dischargeType = objectContext.GetObject<DischargeTypeDefinition>(new Guid("552daaa4-2261-4fd0-abd8-e6df553f91b1"));
                    DailyTreatmentDischarge.DischargeType = dischargeType;
                    DailyTreatmentDischarge.ProcedureDoctor = DailyInPatientPhysicianApplication.ProcedureDoctor;

                    objectContext.Update();

                    DailyTreatmentDischarge.CurrentStateDefID = TreatmentDischarge.States.PreDischarge;
                    objectContext.Save();


                }

            }
            else
            {
                throw new Exception("Yatış İşlemi ancak aktif bir hasta işlemi üzerinden başlatılabilir ");
            }

            return true;
        }

        public ChemotherapyRadiotherapyRequestResponse CreateChemotheraphyRadiotheraphyRequest(Guid actionId, string requestDescription, Guid protocolID)
        {
            ChemotherapyRadiotherapyRequestResponse response = new ChemotherapyRadiotherapyRequestResponse();
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(actionId);

                ChemotherapyRadiotherapy chemoRadio = new ChemotherapyRadiotherapy(objectContext);
                chemoRadio.MasterAction = episodeAction;
                chemoRadio.Episode = episodeAction.Episode;
                chemoRadio.SubEpisode = episodeAction.SubEpisode;
                chemoRadio.RequestDate = Common.RecTime(); //İsteğin yapılma tarihi
                chemoRadio.ProcedureDoctor = episodeAction.ProcedureDoctor;
                chemoRadio.ProcedureByUser = episodeAction.ProcedureDoctor;
                chemoRadio.CurrentStateDefID = ChemotherapyRadiotherapy.States.Request;
                chemoRadio.MasterResource = episodeAction.MasterResource;
                chemoRadio.FromResource = episodeAction.MasterResource;
                chemoRadio.Description = requestDescription;

                if (protocolID != null && protocolID != Guid.Empty)
                {
                    ChemoRadioCureProtocol cureProtocol = objectContext.GetObject<ChemoRadioCureProtocol>(protocolID,true);
                    ChemoRadioCureProtocol protocol = new ChemoRadioCureProtocol(objectContext );
                    ProcedureDefinition procedureObject = cureProtocol.ChemoRadioCureProtocolDet[0].ProcedureObject;
                    if (protocol.CurrentStateDefID == null)
                        protocol.CurrentStateDefID = ChemoRadioCureProtocol.States.New;
                    protocol.Amount = 1;
                    protocol.ChemotherapyRadiotherapy = chemoRadio;
                    protocol.MasterResource = protocol.ChemotherapyRadiotherapy.MasterResource;
                    protocol.Episode = protocol.ChemotherapyRadiotherapy.Episode;
                    protocol.SubEpisode = protocol.ChemotherapyRadiotherapy.SubEpisode;
                    protocol.AfterCureTime = cureProtocol.AfterCureTime;
                    protocol.CureCount = cureProtocol.CureCount;
                    protocol.CureDescription = cureProtocol.CureDescription;
                    protocol.CureTime = cureProtocol.CureTime;
                    protocol.DrugDose = cureProtocol.DrugDose;
                    protocol.IsRadiotherapyCure = cureProtocol.IsRadiotherapyCure;
                    protocol.PreCureMinute = cureProtocol.PreCureMinute;
                    protocol.RepetitiveDayCount = cureProtocol.RepetitiveDayCount;
                    protocol.SolventDose = cureProtocol.SolventDose;
                    protocol.Material = cureProtocol.Material;
                    protocol.EtkinMadde = cureProtocol.EtkinMadde;
                    protocol.ChemotherapyApplyMethod = cureProtocol.ChemotherapyApplyMethod;
                    protocol.ChemotherapyApplySubMethod = cureProtocol.ChemotherapyApplySubMethod;
                    protocol.RadiotherapyXRayTypeDef = cureProtocol.RadiotherapyXRayTypeDef;
                    protocol.Solvent = cureProtocol.Solvent;
                    for (int i = 0; i < protocol.CureCount; i++)
                    {
                        ChemoRadioCureProtocolDet chemoRadioCureProtocolDetail = new ChemoRadioCureProtocolDet(objectContext);

                        chemoRadioCureProtocolDetail.ChemoRadioCureProtocol = protocol;
                        chemoRadioCureProtocolDetail.CurrentStateDefID = ChemoRadioCureProtocolDet.States.Cure;
                        chemoRadioCureProtocolDetail.ProcedureObject = procedureObject;
                        chemoRadioCureProtocolDetail.EpisodeAction = protocol.ChemotherapyRadiotherapy;
                        chemoRadioCureProtocolDetail.SubEpisode = protocol.ChemotherapyRadiotherapy.SubEpisode;
                        chemoRadioCureProtocolDetail.Episode = protocol.ChemotherapyRadiotherapy.Episode;
                        chemoRadioCureProtocolDetail.MasterResource = protocol.ChemotherapyRadiotherapy.MasterResource;
                        chemoRadioCureProtocolDetail.ProcedureDoctor = chemoRadio.ProcedureDoctor;

                    }

                }

                objectContext.Save();
                response.chemotherapyRadiotherapy = chemoRadio;
                response.IsSuccess = true;
                return response;
            }
        }

        [HttpPost]
        public List<BirthTypeModel> GetBirthTypeList()
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<BirthTypeModel> BirthTypeModelList = new List<BirthTypeModel>();
                List<SKRSDogumYontemi.GetSKRSDogumYontemi_Class> BirthTypeList = SKRSDogumYontemi.GetSKRSDogumYontemi(null).ToList();
                foreach (SKRSDogumYontemi.GetSKRSDogumYontemi_Class item in BirthTypeList)
                {
                    BirthTypeModel model = new BirthTypeModel();
                    model.ObjectID = item.ObjectID;
                    model.Name = item.ADI;

                    BirthTypeModelList.Add(model);
                }
                return BirthTypeModelList;
            }
        }


        [HttpPost]
        public LaboratoryWorkListItemMasterModel QueryLaboratoryDetailItemByEpisodeAction(Guid EpisodeActionID)
        {

            LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = new LaboratoryWorkListItemMasterModel();
            List<LaboratoryWorkListItemDetailModel> laboratoryWorkListItemDetailModelList = new List<LaboratoryWorkListItemDetailModel>();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(EpisodeActionID);
                Patient p = episodeAction.Episode.Patient;
                laboratoryWorkListItemMasterModel.PatientObjectID = p.ObjectID.ToString();
                laboratoryWorkListItemMasterModel.PatientTCNo = p.UniqueRefNo.ToString();
                laboratoryWorkListItemMasterModel.PatientNameSurname = p.FullName;
                laboratoryWorkListItemMasterModel.PatientID = p.ID.ToString();
                laboratoryWorkListItemMasterModel.PatientBirthDate = Convert.ToDateTime(p.BirthDate).ToString("dd.MM.yyyy");
                laboratoryWorkListItemMasterModel.PatientBirthCity = p.BirthPlace;
                laboratoryWorkListItemMasterModel.PatientSex = p.Sex.ADI;

                if(episodeAction.SubEpisode.PatientStatus == 0)
                {
                    laboratoryWorkListItemMasterModel.PatientStatus = "A";
                }
                else
                {
                    laboratoryWorkListItemMasterModel.PatientStatus = "Y";
                    InpatientAdmission lastInpatientAdm = null;

                    foreach (Episode myEpisode in p.Episodes.OrderByDescending(dr => dr.OpeningDate))
                    {
                        foreach (InpatientAdmission inpatientAdmission in myEpisode.InpatientAdmissions.OrderByDescending(dr => dr.HospitalInPatientDate))
                        {
                            if (inpatientAdmission.IsCancelled != true)
                            {
                                lastInpatientAdm = inpatientAdmission;
                                break;
                            }
                        }
                        if (lastInpatientAdm != null)
                            break;
                    }

                    if (lastInpatientAdm != null)
                    {
                        laboratoryWorkListItemMasterModel.InPatientDate = Convert.ToDateTime(lastInpatientAdm.HospitalInPatientDate).ToString("dd.MM.yyyy");
                        if (lastInpatientAdm.HospitalDischargeDate != null)
                            laboratoryWorkListItemMasterModel.DischargeDate = Convert.ToDateTime(lastInpatientAdm.HospitalDischargeDate).ToString("dd.MM.yyyy");
                        laboratoryWorkListItemMasterModel.DefNo = lastInpatientAdm.QuarantineProtocolNo.ToString();  //TODO:kontrol edilecek
                    }

                }


                List<LaboratoryWorkListItemDetailModel> LaboratoryProcedureList = new List<LaboratoryWorkListItemDetailModel>();
                List<TubeInformation> TubeInformationList = new List<TubeInformation>();
                Dictionary<string, TubeInformation> LabProceduresTubeInfoList = new Dictionary<string, TubeInformation>();
                List<LaboratoryProcedure> laboratoryWorkList = LaboratoryProcedure.GetLaboratoryProcedureByEpisodeAction(objectContext, EpisodeActionID).ToList();

              //  bool hasWorkListRight = true;

                //TODO: WorkList Right kontrolu yapılıyor
                bool hasWorkListRight = true;
                List<LaboratoryProcedure> laboratoryWorkListObjects = new List<LaboratoryProcedure>();
                if (laboratoryWorkList.Count > 0)
                {

                    foreach (LaboratoryProcedure labProcedureObject in laboratoryWorkList)
                    {
                        if (Common.CurrentUser.HasRole(TTRoleNames.Farkli_Ekranlardan_Lab_Barkodu_Bas))
                        {
                            laboratoryWorkListObjects.Add(labProcedureObject);

                        }

                    }
                }

                Episode myFirstEpisode = null;
                if (hasWorkListRight)
                {
                    //foreach (LaboratoryProcedure.GetLaboratoryProcedureByEpisode_Class lp in laboratoryWorkList)
                    foreach (LaboratoryProcedure laboratoryTest in laboratoryWorkListObjects)
                    {
                        //LaboratoryProcedure laboratoryTest = (LaboratoryProcedure)objectContext.GetObject(lp.ObjectID.Value, "LABORATORYPROCEDURE");
                        LaboratoryWorkListItemDetailModel laboratoryWorkListItemDetailModel = new LaboratoryWorkListItemDetailModel();
                        laboratoryWorkListItemDetailModel.ObjectID = laboratoryTest.ObjectID;
                        laboratoryWorkListItemDetailModel.ObjectDefName = laboratoryTest.ObjectDef.Name;
                        laboratoryWorkListItemDetailModel.PatientNameSurname = laboratoryTest.Episode.Patient.FullName;

                        if (myFirstEpisode == null)
                        {
                            myFirstEpisode = laboratoryTest.SubEpisode.Episode;
                            laboratoryWorkListItemMasterModel.EpisodeID = myFirstEpisode.ObjectID.ToString();
                        }

                        laboratoryWorkListItemDetailModel.FromResourceName = laboratoryTest.EpisodeAction.FromResource.Name;
                        if (laboratoryWorkListItemMasterModel.FromResourceName == null)
                            laboratoryWorkListItemMasterModel.FromResourceName = laboratoryTest.EpisodeAction.FromResource.Name;

                        laboratoryWorkListItemDetailModel.LaboratoryTestName = laboratoryTest.ProcedureObject.Name.ToString();
                        laboratoryWorkListItemDetailModel.WorkListDate = (DateTime)laboratoryTest.WorkListDate.Value;
                        laboratoryWorkListItemDetailModel.RequestDate = Convert.ToDateTime(laboratoryTest.RequestDate).ToString("dd-MM-yyyy HH:mm");
                        laboratoryWorkListItemDetailModel.RequestedByUser = laboratoryTest.Laboratory.RequestDoctor.Name;
                        laboratoryWorkListItemDetailModel.StateName = laboratoryTest.CurrentStateDef.DisplayText;
                        laboratoryWorkListItemDetailModel.StateDefID = laboratoryTest.CurrentStateDefID.ToString();
                        if (laboratoryTest.Emergency == true)
                            laboratoryWorkListItemDetailModel.isLabTestEmergency = true;
                        laboratoryWorkListItemDetailModel.TestCode = laboratoryTest.ProcedureObject.Code;
                        //laboratoryWorkListItemDetailModel.TestLoincCode = laboratoryTest.ProcedureObject.SKRSLoincKodu?.LOINCNUMARASI;
                        laboratoryWorkListItemDetailModel.TestLoincCode = ((LaboratoryTestDefinition)laboratoryTest.ProcedureObject).FreeLOINCCode;
                        laboratoryWorkListItemDetailModel.BarcodeID = laboratoryTest.BarcodeId.ToString();
                        laboratoryWorkListItemDetailModel.SpecimenID = laboratoryTest.SpecimenId.ToString();
                        laboratoryWorkListItemDetailModel.LabRequestObjectID = laboratoryTest.Laboratory.ObjectID.ToString();
                        if (laboratoryWorkListItemMasterModel.LabRequestObjectID == null)
                            laboratoryWorkListItemMasterModel.LabRequestObjectID = laboratoryTest.Laboratory.ObjectID.ToString();

                        //Dis Istem oldugu bilgisi set ediliyor
                        Resource masterResource = (Resource)laboratoryTest.EpisodeAction.MasterResource;
                        laboratoryWorkListItemDetailModel.isExternalProcedureRequest = false;
                        if (masterResource is ResObservationUnit)
                        {
                            if (((ResObservationUnit)masterResource).IsExternalObservationUnit == true)
                                laboratoryWorkListItemDetailModel.isExternalProcedureRequest = true;
                        }
                        laboratoryWorkListItemDetailModel.EpisodeActionObjectId = laboratoryTest.EpisodeAction.ObjectID;


                        //Tetkik kategori bilgisi set ediliyor. Tetkik'in katolog tanımında karşılığı bulunmaması durumunu karşılamak için öncelikle Diğer olarak set ediliyor.
                        laboratoryWorkListItemDetailModel.ProcedureRequestFormCategoryName = TTUtils.CultureService.GetText("M12780", "Diğer");
                        bool categoryNameOK = false;
                        if (laboratoryTest.ProcedureObject.FormDetail != null)
                        {
                            //Tetkik Sık Kullanılanlar Kategorisinde ise o grup altında çıkması istenmiyor. ResUser ile eşlenmiş ProcedureRequestForm un kategori isminin çıkmaması için aşağıdaki kod yazıldı.
                            for (int i = 0; i < laboratoryTest.ProcedureObject.FormDetail.Count; i++)
                            {
                                ProcedureRequestFormDefinition procedureReqForm = laboratoryTest.ProcedureObject.FormDetail[i].ProcedureRequestCategory?.ProcedureRequestForm;
                                if (procedureReqForm != null)
                                {
                                    foreach (RequestUnitOfProcedureForm requestFormResource in procedureReqForm.RequestUnitsOfProcedureForm)
                                    {
                                        if (!(requestFormResource.Resource is ResUser))
                                        {
                                            laboratoryWorkListItemDetailModel.ProcedureRequestFormCategoryName = laboratoryTest.ProcedureObject.FormDetail[i].ProcedureRequestCategory?.CategoryName;
                                            categoryNameOK = true;
                                            break;
                                        }
                                    }
                                    if (categoryNameOK == true)
                                        break;
                                }
                            }
                        }


                        //Tetkigin bilgilendirme formu ve aciklamasi varda o yuklenecek
                        LaboratoryTestDefinition laboratoryTestDefinition;
                        laboratoryTestDefinition = (LaboratoryTestDefinition)laboratoryTest.ProcedureObject;

                        if (laboratoryTestDefinition.RequiresBinaryScanForm == true || laboratoryTestDefinition.RequiresTripleTestForm == true || laboratoryTestDefinition.RequiresUreaBreathTestReport == true || laboratoryTestDefinition.TestDescription != null)
                        {
                            string procedureInst = "";
                            string instReportName = "";
                            if (laboratoryTestDefinition.RequiresBinaryScanForm == true)
                            {
                                procedureInst = procedureInst + TTUtils.CultureService.GetText("M26037", "İkili Tarama Formu Gerektirir\n");
                                instReportName = instReportName + "LaboratoryBinaryScanInfoReport" + "|";
                            }

                            if (laboratoryTestDefinition.RequiresTripleTestForm == true)
                            {
                                procedureInst = procedureInst + TTUtils.CultureService.GetText("M27161", "Üçlü Test Formu Gerektirir\n");
                                instReportName = instReportName + "LaboratoryTripleTestInfoReport" + "|";
                            }

                            if (laboratoryTestDefinition.RequiresUreaBreathTestReport == true)
                            {
                                procedureInst = procedureInst + TTUtils.CultureService.GetText("M27164", "Üre Nefes Testi Hasta Talimat Raporunu Gerektirir\n");
                                instReportName = instReportName + "UreaBreathTestPatientInstructionReport" + "|";
                            }

                            if (laboratoryTestDefinition.TestDescription != null)
                            {
                                procedureInst = procedureInst + laboratoryTestDefinition.TestDescription;
                                instReportName = instReportName + "LaboratoryTestPatientInstructionReport" + "|";
                            }

                            laboratoryWorkListItemDetailModel.hasProcedureInstruction = true;
                            laboratoryWorkListItemDetailModel.ProcedureInstructions = procedureInst;
                            laboratoryWorkListItemDetailModel.ProcedureInstructionReportName = instReportName;
                        }
                        //

                        laboratoryWorkListItemDetailModelList.Add(laboratoryWorkListItemDetailModel);
                        if (laboratoryTest.TubeInformation != null)
                        {
                            TubeInformation tubeInfo = new TubeInformation();
                            string containerID = laboratoryTest.TubeInformation.ContainerID.ToString();
                            if (LabProceduresTubeInfoList.TryGetValue(containerID, out tubeInfo) == false)
                            {
                                if (tubeInfo == null)
                                    tubeInfo = new TubeInformation();
                                tubeInfo.FromResourceName = laboratoryTest.TubeInformation.FromResourceName;
                                tubeInfo.SpecimenID = laboratoryTest.TubeInformation.SpecimenID.ToString();
                                tubeInfo.ContainerID = laboratoryTest.TubeInformation.ContainerID.ToString();
                                tubeInfo.SpecialHandlingCode = laboratoryTest.TubeInformation.Description;
                                tubeInfo.OtherEnvFactor = laboratoryTest.TubeInformation.BarcodeType;
                                if (laboratoryTest.TubeInformation.RequestAcceptionDate != null)
                                    tubeInfo.RequestAcceptionDate = Convert.ToDateTime(laboratoryTest.TubeInformation.RequestAcceptionDate).ToString("dd-MM-yyyy HH:mm");
                                LabProceduresTubeInfoList.Add(containerID, tubeInfo);
                            }
                        }

                    }

                    foreach (KeyValuePair<string, TubeInformation> tubeInfo in LabProceduresTubeInfoList)
                    {
                        TubeInformationList.Add(tubeInfo.Value);
                    }

                    laboratoryWorkListItemMasterModel.LaboratoryProcedureList = laboratoryWorkListItemDetailModelList;
                    laboratoryWorkListItemMasterModel.TubeInformationList = TubeInformationList;

                    return laboratoryWorkListItemMasterModel;
                }
                else
                    return null;
            }
        }

    }
}

namespace Core.Models
{
    public class ChemotherapyRadiotherapyRequestResponse
    {
        public ChemotherapyRadiotherapy chemotherapyRadiotherapy { get; set; }
        public bool IsSuccess { get; set; }
    }
}