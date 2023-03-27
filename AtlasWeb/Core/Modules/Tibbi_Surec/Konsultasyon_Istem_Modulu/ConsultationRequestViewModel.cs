//$257CF98C
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class ConsultationRequestServiceController : Controller
    {
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Konsultasyon_Istek_Istek, TTRoleNames.Konsultasyon_Konsultasyon, TTRoleNames.Konsultasyon_Istek_Iptal_Et)]
        public ConsultationRequestViewModel FillConsultationHistory(ConsultationRequestViewModel viewModel)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(viewModel._EpisodeAction.ObjectID);
            BindingList<Consultation> oldConsultations = episodeAction.GetConsultationsHistory();
            viewModel = new ConsultationRequestViewModel();
            viewModel._EpisodeAction = episodeAction;
            viewModel.InPatientBedVisible = (episodeAction.Episode.PatientStatus == PatientStatusEnum.Inpatient || episodeAction.Episode.PatientStatus == PatientStatusEnum.PreDischarge);
            viewModel.PatientSexCode = episodeAction.Episode.Patient.Sex != null ? Convert.ToInt32(episodeAction.Episode.Patient.Sex.KODU) : 9;
            //BindingList<Consultation> oldConsultations = viewModel._EpisodeAction.GetConsultationsHistory();
            foreach (Consultation cons in oldConsultations)
            {
                ConsReqOldConsultationInfo oldCons = new ConsReqOldConsultationInfo();

                oldCons.consultationObjectID = cons.ObjectID;
                oldCons.consultationRequestDate = Convert.ToDateTime(cons.RequestDate);
                if (cons.ProcessDate.HasValue)
                    oldCons.consultationProcessDate = Convert.ToDateTime(cons.ProcessDate);
                else
                    oldCons.consultationProcessDate = null;
                if (cons.ProcessEndDate.HasValue)
                    oldCons.consultationProcessEndDate = Convert.ToDateTime(cons.ProcessEndDate);
                else
                    oldCons.consultationProcessEndDate = null;
                oldCons.consultationRequesterDoctor = (cons.RequesterDoctor == null ? "" : cons.RequesterDoctor.Name);
                oldCons.consultationMasterResource = (cons.MasterResource == null ? "" : cons.MasterResource.Name);
                oldCons.consultationRequestedResource = (cons.ProcedureDoctor == null ? "" : cons.ProcedureDoctor.Name);
                oldCons.consultationRequestDescription = (cons.RequestDescription == null ? "" : Common.GetTextOfRTFString(cons.RequestDescription.ToString()));
                if(cons.CurrentStateDef.Status != TTDefinitionManagement.StateStatusEnum.Cancelled)
                    oldCons.consultationResult = (cons.ConsultationResultAndOffers == null ? "" : Common.GetTextOfRTFString(cons.ConsultationResultAndOffers.ToString()));
                oldCons.consultationReasonOfCancel = cons.ReasonOfCancel;
                oldCons.consultationDiagnosis = new List<ConsultationDiagnosis>();
                oldCons.consObjectDefName = cons.ObjectDef.Name;
                oldCons.consReportDefName = "ConsultationReport";
                foreach (DiagnosisGrid diagnosis in cons.Diagnosis)
                {
                    ConsultationDiagnosis cDiagnosis = new ConsultationDiagnosis();
                    cDiagnosis.consultationDiagnose = diagnosis.Diagnose.Code + " " + diagnosis.Diagnose.Name;
                    cDiagnosis.consultationFreeDiagnose = diagnosis.FreeDiagnosis;
                    oldCons.consultationDiagnosis.Add(cDiagnosis);
                }

                oldCons.consultationStateStatus = Convert.ToInt32(cons.CurrentStateDef.Status);
                oldCons.consultationState = cons.CurrentStateDefID;
                oldCons.consultationStateDisplayText = cons.CurrentStateDef.DisplayText;
                viewModel.ConsultationsHistory.Add(oldCons);
            }

            BindingList<PatientInterviewForm> oldPatientInterviews = episodeAction.GetPatientInterviewsHistory();
            foreach (PatientInterviewForm patientInterviewForm in oldPatientInterviews)
            {
                ConsReqOldConsultationInfo oldCons = new ConsReqOldConsultationInfo();
                oldCons.consultationObjectID = patientInterviewForm.ObjectID;
                oldCons.consultationRequestDate = Convert.ToDateTime(patientInterviewForm.RequestDate);
                oldCons.consultationProcessDate = Convert.ToDateTime(patientInterviewForm.RequestDate);
                oldCons.consultationProcessEndDate = Convert.ToDateTime(patientInterviewForm.ActionDate);
                oldCons.consultationRequesterDoctor = (patientInterviewForm.PhysicianApplication == null ? "" : patientInterviewForm.PhysicianApplication.ProcedureDoctor == null ? "" : patientInterviewForm.PhysicianApplication.ProcedureDoctor.Name);
                oldCons.consultationMasterResource = (patientInterviewForm.MasterResource == null ? "" : patientInterviewForm.MasterResource.Name);
                oldCons.consultationRequestedResource = (patientInterviewForm.ProcedureByUser == null ? "" : patientInterviewForm.ProcedureByUser.Name);
                oldCons.consultationRequestDescription = (patientInterviewForm.MeetingReason == null ? "" : Common.GetTextOfRTFString(patientInterviewForm.MeetingReason.ToString()));
                if (patientInterviewForm.CurrentStateDef.Status != TTDefinitionManagement.StateStatusEnum.Cancelled)
                    oldCons.consultationResult = (patientInterviewForm.ResultsAndRecommendations == null ? "" : Common.GetTextOfRTFString(patientInterviewForm.ResultsAndRecommendations.ToString()));
                oldCons.consultationReasonOfCancel = patientInterviewForm.ReasonOfCancel;
                oldCons.consultationStateStatus = Convert.ToInt32(patientInterviewForm.CurrentStateDef.Status);
                oldCons.consultationState = patientInterviewForm.CurrentStateDefID;
                oldCons.consultationStateDisplayText = patientInterviewForm.CurrentStateDef.DisplayText;
                oldCons.consObjectDefName = patientInterviewForm.ObjectDef.Name;
                oldCons.consReportDefName = "";
                viewModel.ConsultationsHistory.Add(oldCons);
            }

            BindingList<ConsultationFromExternalHospital> oldExternalConsultations = episodeAction.GetExternalConsultationsHistory();
            foreach (ConsultationFromExternalHospital consultationFromExternalHospital in oldExternalConsultations)
            {
                ConsReqOldConsultationInfo oldCons = new ConsReqOldConsultationInfo();
                oldCons.consultationObjectID = consultationFromExternalHospital.ObjectID;
                oldCons.consultationRequestDate = Convert.ToDateTime(consultationFromExternalHospital.RequestDate);
                oldCons.consultationProcessDate = null;
                oldCons.consultationProcessEndDate = null;
                oldCons.consultationRequesterDoctor = (consultationFromExternalHospital.ProcedureDoctor == null ? "" : consultationFromExternalHospital.ProcedureDoctor.Name);
                oldCons.consultationMasterResource = (consultationFromExternalHospital.RequestedExternalHospital == null ? "" : consultationFromExternalHospital.RequestedExternalHospital.Name);
                oldCons.consultationRequestedResource = (consultationFromExternalHospital.RequestedExternalSpeciality == null ? "" : consultationFromExternalHospital.RequestedExternalSpeciality.Name);
                oldCons.consultationRequestDescription = (consultationFromExternalHospital.RequestDescription == null ? "" : Common.GetTextOfRTFString(consultationFromExternalHospital.RequestDescription.ToString()));
                oldCons.consultationResult = "";
                oldCons.consultationReasonOfCancel = consultationFromExternalHospital.ReasonOfCancel;
                oldCons.consultationStateStatus = Convert.ToInt32(consultationFromExternalHospital.CurrentStateDef.Status);
                oldCons.consultationState = consultationFromExternalHospital.CurrentStateDefID;
                oldCons.consultationStateDisplayText = consultationFromExternalHospital.CurrentStateDef.DisplayText;
                oldCons.consObjectDefName = consultationFromExternalHospital.ObjectDef.Name;
                oldCons.consReportDefName = "ConsultationFromExternalHospitalReport";
                viewModel.ConsultationsHistory.Add(oldCons);
            }

            BindingList<DentalExamination> oldDentalExaminations = DentalExamination.GetAllDentalExaminationConsultations(objectContext, episodeAction.Episode.ObjectID.ToString(), episodeAction.ObjectID.ToString());
            foreach (DentalExamination dentalExamination in oldDentalExaminations)
            {
                ConsReqOldConsultationInfo oldCons = new ConsReqOldConsultationInfo();
                oldCons.consultationObjectID = dentalExamination.ObjectID;
                oldCons.consultationRequestDate = Convert.ToDateTime(dentalExamination.RequestDate);

                if (dentalExamination.ProcessDate.HasValue)
                    oldCons.consultationProcessDate = Convert.ToDateTime(dentalExamination.ProcessDate);
                else
                    oldCons.consultationProcessDate = Convert.ToDateTime(dentalExamination.RequestDate);

                if (dentalExamination.ProcessEndDate.HasValue)
                    oldCons.consultationProcessEndDate = Convert.ToDateTime(dentalExamination.ProcessEndDate);
                else
                    oldCons.consultationProcessEndDate = Convert.ToDateTime(dentalExamination.ActionDate);

                oldCons.consultationRequesterDoctor = (dentalExamination.RequesterDoctor == null ? "" : dentalExamination.RequesterDoctor.Name);
                oldCons.consultationMasterResource = (dentalExamination.MasterResource == null ? "" : dentalExamination.MasterResource.Name);
                oldCons.consultationRequestedResource = (dentalExamination.ProcedureDoctor == null ? "" : dentalExamination.ProcedureDoctor.Name);
                oldCons.consultationRequestDescription = (dentalExamination.RequestDescription == null ? "" : Common.GetTextOfRTFString(dentalExamination.RequestDescription.ToString()));
                if (dentalExamination.CurrentStateDef.Status != TTDefinitionManagement.StateStatusEnum.Cancelled)
                    oldCons.consultationResult = (dentalExamination.ConsultationResultAndOffers == null ? "" : Common.GetTextOfRTFString(dentalExamination.ConsultationResultAndOffers.ToString()));
                oldCons.consultationReasonOfCancel = dentalExamination.ReasonOfCancel;
                oldCons.consultationStateStatus = Convert.ToInt32(dentalExamination.CurrentStateDef.Status);
                oldCons.consultationState = dentalExamination.CurrentStateDefID;
                oldCons.consultationStateDisplayText = dentalExamination.CurrentStateDef.DisplayText;
                oldCons.consObjectDefName = dentalExamination.ObjectDef.Name;
                oldCons.consReportDefName = "";
                viewModel.ConsultationsHistory.Add(oldCons);
            }

            return viewModel;
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Konsultasyon_Istek_Iptal_Et)]
        public bool cancelConsultationRequest([FromQuery]Guid consultationObjectID)
        {
            TTObjectContext context = new TTObjectContext(false);
            EpisodeAction consultation = context.GetObject<EpisodeAction>(consultationObjectID);

            if (consultation != null)
            {
                if (consultation is Consultation && consultation.CurrentStateDefID == Consultation.States.RequestAcception)
                {
                    consultation.CurrentStateDefID = Consultation.States.Cancelled;
                    context.Save();
                    return true;
                }
                else if (consultation is PatientInterviewForm && consultation.CurrentStateDefID == PatientInterviewForm.States.Procedure)
                {
                    consultation.CurrentStateDefID = PatientInterviewForm.States.Cancelled;
                    context.Save();
                    return true;
                }
                else if (consultation is ConsultationFromExternalHospital && consultation.CurrentStateDefID == ConsultationFromExternalHospital.States.Completed)
                {
                    consultation.CurrentStateDefID = ConsultationFromExternalHospital.States.Cancelled;
                    context.Save();
                    return true;
                }
                return false;
            }
            else
                throw new Exception(TTUtils.CultureService.GetText("M26778", "Sadece 'İstek Kabul' aşamasındaki konsültasyonlar silinebilir."));
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public EpisodeAction CreateNewConsultationRequest([FromQuery] ActionTypeEnum actionTypeEnum, [FromQuery] string episodeActionId)
        {
            using (var objectContext = new TTObjectContext(false))
            {

                EpisodeAction ConsultationEpisodeAction = null;
                if (actionTypeEnum == ActionTypeEnum.ConsultationFromExternalHospital)
                {
                    ConsultationEpisodeAction = new ConsultationFromExternalHospital(objectContext);
                }
                else if (actionTypeEnum == ActionTypeEnum.PatientInterviewForm)
                {
                    ConsultationEpisodeAction = new PatientInterviewForm(objectContext);
                }
                else if (actionTypeEnum == ActionTypeEnum.DentalExamination)
                {
                    ConsultationEpisodeAction = new DentalExamination(objectContext);
                }
                else
                {
                    ConsultationEpisodeAction = new Consultation(objectContext);
                }

                var RecTime = Common.RecTime();
                ConsultationEpisodeAction.ActionDate = RecTime;
                ConsultationEpisodeAction.RequestDate = RecTime;

                var episodeActionList = EpisodeAction.GetEpisodeActionByID(objectContext, episodeActionId);
                if (episodeActionList.Count > 0)
                {
                    EpisodeActionWithDiagnosis episodeAction = episodeActionList[0] as EpisodeActionWithDiagnosis;
                    if (episodeAction != null)
                    {
                        if (episodeAction.SubEpisode != null && episodeAction.SubEpisode.StarterEpisodeAction != null && episodeAction.SubEpisode.StarterEpisodeAction is InPatientTreatmentClinicApplication && ((InPatientTreatmentClinicApplication)episodeAction.SubEpisode.StarterEpisodeAction).IsDailyOperation == false)
                        {
                            if (((InPatientTreatmentClinicApplication)episodeAction.SubEpisode.StarterEpisodeAction).ClinicDischargeDate != null)
                                throw new Exception("Taburcu tarihi dolu olan hastaya yeni konsültasyon işlemi başlatılamaz.");
                            
                        }
                        if(episodeAction is InPatientPhysicianApplication)
                            ConsultationEpisodeAction.MasterAction = episodeAction;
                        ConsultationEpisodeAction.FromResource = episodeAction.MasterResource;
                        ConsultationEpisodeAction.SubEpisode = episodeAction.SubEpisode;
                        ConsultationEpisodeAction.Episode = episodeAction.Episode;
                    }
                }

                return ConsultationEpisodeAction;
            }

        }

        [HttpPost]
        public List<ResSection> FillConsultationResourceList(InputModelForQueries input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {

                List<ResSection> SectionList = ResSection.ConsultationRequestResourceList(objectContext,input.filter).OrderBy(T => T.Name).ToList();
                objectContext.FullPartialllyLoadedObjects();
                return SectionList;

            }
       /*     List<ResSection.ConsultationRequestResourceListNql_Class> ConsultationListFromQuery = ResSection.ConsultationRequestResourceListNql(input.filter).ToList();
            List<ConsRequestResourceModel> ConsultationList = new List<ConsRequestResourceModel>();
            foreach (ResSection.ConsultationRequestResourceListNql_Class cons in ConsultationListFromQuery)
            {
                ConsRequestResourceModel consModel = new ConsRequestResourceModel();

                consModel.Name = cons.Name;
                consModel.ObjectID = cons.ObjectID;

                ConsultationList.Add(consModel);
            }
            return ConsultationList;*/
        }

        [HttpPost]
        public List<ResUser> FillConsultationUserList(InputModelForQueries input)
        {

            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                List<ResUser> UserList = ResUser.GetConsultationUserList(objectContext, input.filter).ToList();
                objectContext.FullPartialllyLoadedObjects();
                return UserList;
            }
/*            List<ResUser.GetConsultationUserNQL_Class> ConsultationUserListFromQuery = ResUser.GetConsultationUserNQL(input.filter).ToList();
            List<ConsultationUserModel> UserList = new List<ConsultationUserModel>();
            foreach (ResUser.GetConsultationUserNQL_Class user in ConsultationUserListFromQuery)
            {
                ConsultationUserModel userModel = new ConsultationUserModel();

                userModel.Name = user.Name;
                userModel.ObjectID = user.ObjectID;

                UserList.Add(userModel);
            }
            return UserList;*/
        }
    }
}

namespace Core.Models
{
    public class ConsultationRequestViewModel
    {
        public TTObjectClasses.EpisodeAction _EpisodeAction
        {
            get;
            set;
        }

        public TTObjectClasses.Consultation[] GrdConsultationGridList
        {
            get;
            set;
        }

        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }

        public TTObjectClasses.Patient[] Patients
        {
            get;
            set;
        }

        public bool InPatientBedVisible
        {
            get;
            set;
        }

        public int PatientSexCode
        {
            get;
            set;
        }

        public Guid _EpisodeActionObjectId;
        public List<ConsReqOldConsultationInfo> ConsultationsHistory = new List<ConsReqOldConsultationInfo>();
        public ConsReqNewConsultationRequestInfo[] NewConsultationRequests;
        public ResSection ResourceValue;
        public ResUser RequestedUser;
    }

    public class ConsReqOldConsultationInfo
    {
        public Guid consultationObjectID;
        public DateTime consultationRequestDate;
        public string consultationRequesterDoctor;
        public string consultationMasterResource;
        public string consultationRequestedResource;
        public string consultationRequestDescription;
        public DateTime? consultationProcessDate;
        public DateTime? consultationProcessEndDate;
        public string consultationResult;
        public string consultationReasonOfCancel;
        public Guid? consultationState;
        public string consultationStateDisplayText;
        public int consultationStateStatus;
        public List<ConsultationDiagnosis> consultationDiagnosis;
        public string consObjectDefName;
        public string consReportDefName;
    }

    public class ConsReqNewConsultationRequestInfo
    {
        public ResSection consultationMasterResource;
        public ResUser consultationProcedureDoctor;
        public bool consultationEmergency;
        public bool consultationInBed;
    }

    public class ConsReqConsultationDiagnosis
    {
        public string consultationDiagnose;
        public string consultationFreeDiagnose;
    }

    public class ConsRequestResourceModel
    {
        public Guid? ObjectID { get; set; }
        public string Name { get; set; }
        public string Qref{ get; set; }
    }

    public class ConsultationUserModel
    {
        public Guid? ObjectID {get; set;}
        public string Name {get; set;}
    }

}