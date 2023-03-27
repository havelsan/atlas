//$DC37CF3E
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class PatientInterviewFormServiceController
    {
        partial void PreScript_SocialServicesPatientInterviewForm(SocialServicesPatientInterviewFormViewModel viewModel, PatientInterviewForm patientInterviewForm, TTObjectContext objectContext)
        {
            /*Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            if (viewModel._PatientInterviewForm.Episode == null)
            {
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    viewModel._PatientInterviewForm.Episode = episodeAction.Episode;
                    viewModel._PatientInterviewForm.MasterAction = episodeAction;
                    viewModel.ResUsers = patientInterviewForm.ObjectContext.LocalQuery<ResUser>().ToArray();
                }
            }*/
            if(patientInterviewForm.Episode.Patient.SKRSMaritalStatus != null && viewModel._PatientInterviewForm.MaritalStatus == null)
            {
                //todo my 
                //viewModel._PatientInterviewForm.MaritalStatus = patientInterviewForm.Episode.Patient.SKRSMaritalStatus.ADI;
            }
            if(patientInterviewForm.SubEpisode.PatientAdmission.PA_Address.MobilePhone != null && viewModel._PatientInterviewForm.PatientPhoneNum == null)
            {
                viewModel._PatientInterviewForm.PatientPhoneNum = patientInterviewForm.SubEpisode.PatientAdmission.PA_Address.MobilePhone;
            }
            if (patientInterviewForm.SubEpisode.PatientAdmission.PA_Address.HomeAddress != null && viewModel._PatientInterviewForm.PatientAddress == null)
            {
                viewModel._PatientInterviewForm.PatientAddress = patientInterviewForm.SubEpisode.PatientAdmission.PA_Address.HomeAddress;
            }

            DiagnosisGrid[] episodeDiagnosis = patientInterviewForm.Episode.Diagnosis.ToArray();
            if (episodeDiagnosis.Length > 0)
            {
                foreach (DiagnosisGrid dG in episodeDiagnosis)
                {
                    viewModel.Diagnosis +=  dG.Diagnose.Name + "-- ";
                }
                viewModel.Diagnosis = viewModel.Diagnosis.Remove(viewModel.Diagnosis.Length - 3);
                if(patientInterviewForm.SocServPatientFamilyInfo != null)
                    patientInterviewForm.SocServPatientFamilyInfo.PatientDiagnosis = viewModel.Diagnosis;

            }
            if(patientInterviewForm.Episode.Payer != null)
            {
                viewModel.PayerName = patientInterviewForm.Episode.Payer.Name.ToString();
            }
            if (patientInterviewForm.SubEpisode.InpatientAdmission!= null && patientInterviewForm.SubEpisode.InpatientAdmission.Bed != null)
            {
                viewModel.RoomName = patientInterviewForm.SubEpisode.InpatientAdmission.Bed.Room.Name;
            }
            else
            {
                viewModel.RoomName = "";
            }
            CompanionApplication companionApplication = patientInterviewForm.Episode.GetActiveCompanionApplication();
            
            if (companionApplication != null)
            {
                viewModel.CompanionName = companionApplication.CompanionName;
                //viewModel.CompanionPhoneNumber = companionApplication.CompanionPhoneNum;

                if(viewModel._PatientInterviewForm.SocServPatientFamilyInfo != null)
                { 
                    viewModel._PatientInterviewForm.SocServPatientFamilyInfo.Companion = companionApplication.CompanionName;
                    //viewModel._PatientInterviewForm.SocServPatientFamilyInfo.CompanionPhoneNumber = companionApplication.CompanionPhoneNum;
                }
            }


            ContextToViewModel(viewModel, objectContext);
            if (viewModel._PatientInterviewForm.ExaminationDate == null)
                viewModel._PatientInterviewForm.ExaminationDate = Common.RecTime();
        }

        partial void PostScript_SocialServicesPatientInterviewForm(SocialServicesPatientInterviewFormViewModel viewModel, PatientInterviewForm patientInterviewForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            patientInterviewForm.WorkListDate = Common.RecTime();
        }
    }
}

namespace Core.Models
{
    public partial class SocialServicesPatientInterviewFormViewModel
    {
        public string CompanionName;
        public string CompanionPhoneNumber;
        public string RoomName;
        public string Diagnosis;
        public string PayerName;
        public ResUser ReportSelectedUser { get; set; }

    }
}