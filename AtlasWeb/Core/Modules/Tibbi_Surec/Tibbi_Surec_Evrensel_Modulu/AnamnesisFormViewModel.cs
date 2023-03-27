//$1AD0FC82
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Core.Security;

namespace Core.Controllers
{
    public partial class PhysicianApplicationServiceController
    {
        partial void PreScript_AnamnesisForm(AnamnesisFormViewModel viewModel, PhysicianApplication physicianApplication, TTObjectContext objectContext)
        {


            var episode = (Episode)objectContext.GetLoadedObject(physicianApplication.Episode.ObjectID);

            viewModel.PatientID = episode.Patient.ObjectID;
          
            //Guid? selectedEpisodeActionID = Request.Headers.GetSelectedEpisodeActionID();
            //if (selectedEpisodeActionID.HasValue)
            //{
            //    EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
            //    if (episodeAction is PatientExamination)
            //        physicianApplication = (PhysicianApplication)episodeAction;
            //}


        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Anamnez_Gecmis_Goruntuleme, TTRoleNames.Saglik_Kurulu_Yeni_RUW, TTRoleNames.Saglik_Kurulu_Rapor_RUW, TTRoleNames.Saglik_Kurulu_Tamamlandi_R)]
        public AnamnesisListInfo[] GetAnamnesisHistory([FromQuery] Guid PatientID, [FromQuery] Guid EpisodeActionID,string ListType)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            List<AnamnesisListInfo> result = new List<AnamnesisListInfo>();
            Guid DoctorID = Guid.Empty, BranchID = Guid.Empty;

            if (Common.CurrentResource.TakesPerformanceScore == true)
            {
                DoctorID = Common.CurrentResource.ObjectID;
                if (Common.CurrentResource.ResourceSpecialities.Count > 0)
                    BranchID = Common.CurrentResource.ResourceSpecialities[0].Speciality.ObjectID;
            }
            else
            {
               
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(EpisodeActionID);
                if (!(episodeAction is HealthCommittee))//sağlık kurulundanda muayene anamnez listesini görüntülüyoruz. Ama bunların ProcedureDoctoru yok
                {
                    DoctorID = episodeAction.ProcedureDoctor.ObjectID;
                    if (episodeAction.ProcedureDoctor.ResourceSpecialities.Count > 0)
                        BranchID = episodeAction.ProcedureDoctor.ResourceSpecialities[0].Speciality.ObjectID;
                }
               
            }


            TTObjectContext objContext = new TTObjectContext(false);

            BindingList<PhysicianApplication.GetPhysicianApplicationWithAnamnesis_Class> anamnesisList = TTObjectClasses.PhysicianApplication.GetPhysicianApplicationWithAnamnesis(objContext, PatientID);
            foreach (PhysicianApplication.GetPhysicianApplicationWithAnamnesis_Class anamnesis in anamnesisList.ToList())
            {
                if (anamnesis.IsPrivate == true && Common.CurrentResource.TakesPerformanceScore == true)
                {
                    bool found = false;
                    foreach (ResourceSpecialityGrid specialityGrid in Common.CurrentResource.ResourceSpecialities)
                    {
                        if (specialityGrid.Speciality.ObjectID == anamnesis.Branchid)
                            found = true;
                        if (found)
                            break;
                    }

                    if (found)
                    {
                        if (ListType == TTUtils.CultureService.GetText("M27124", "Tüm Branşlar"))
                        {
                            AnamnesisListInfo info = new AnamnesisListInfo();
                            info.ObjectID = (Guid)anamnesis.ObjectID;
                            if (anamnesis.ProcessDate != null)
                                info.ProcessDate = Convert.ToDateTime(anamnesis.ProcessDate).ToString("dd.MM.yyyy");
                            else
                                info.ProcessDate = "";
                            info.UnitName = anamnesis.Unit;
                            info.DoctorName = anamnesis.Doctor;

                            result.Add(info);
                        }
                        else if (ListType == TTUtils.CultureService.GetText("M26292", "Kendi Kabullerim"))
                        {
                            if (DoctorID == anamnesis.Doctorid)
                            {
                                AnamnesisListInfo info = new AnamnesisListInfo();
                                info.ObjectID = (Guid)anamnesis.ObjectID;
                                if (anamnesis.ProcessDate != null)
                                    info.ProcessDate = Convert.ToDateTime(anamnesis.ProcessDate).ToString("dd.MM.yyyy");
                                else
                                    info.ProcessDate = "";
                                info.UnitName = anamnesis.Unit;
                                info.DoctorName = anamnesis.Doctor;

                                result.Add(info);
                            }

                        }
                        else if (ListType == TTUtils.CultureService.GetText("M26291", "Kendi Branşım"))
                        {
                            if (BranchID == anamnesis.Branchid)
                            {
                                AnamnesisListInfo info = new AnamnesisListInfo();
                                info.ObjectID = (Guid)anamnesis.ObjectID;
                                if (anamnesis.ProcessDate != null)
                                    info.ProcessDate = Convert.ToDateTime(anamnesis.ProcessDate).ToString("dd.MM.yyyy");
                                else
                                    info.ProcessDate = "";
                                info.UnitName = anamnesis.Unit;
                                info.DoctorName = anamnesis.Doctor;

                                result.Add(info);
                            }
                        }
                    }//Uzmanlıkları içinde o branş yoksa anamnezi eklemeyecek
                }
                else
                {
                    if (ListType == TTUtils.CultureService.GetText("M27124", "Tüm Branşlar"))
                    {
                        AnamnesisListInfo info = new AnamnesisListInfo();
                        info.ObjectID = (Guid)anamnesis.ObjectID;
                        if (anamnesis.ProcessDate != null)
                            info.ProcessDate = Convert.ToDateTime(anamnesis.ProcessDate).ToString("dd.MM.yyyy");
                        else
                            info.ProcessDate = "";
                        info.UnitName = anamnesis.Unit;
                        info.DoctorName = anamnesis.Doctor;

                        result.Add(info);
                    }
                    else if (ListType == TTUtils.CultureService.GetText("M26292", "Kendi Kabullerim"))
                    {
                        if (DoctorID == anamnesis.Doctorid)
                        {
                            AnamnesisListInfo info = new AnamnesisListInfo();
                            info.ObjectID = (Guid)anamnesis.ObjectID;
                            if (anamnesis.ProcessDate != null)
                                info.ProcessDate = Convert.ToDateTime(anamnesis.ProcessDate).ToString("dd.MM.yyyy");
                            else
                                info.ProcessDate = "";
                            info.UnitName = anamnesis.Unit;
                            info.DoctorName = anamnesis.Doctor;

                            result.Add(info);
                        }

                    }
                    else if (ListType == TTUtils.CultureService.GetText("M26291", "Kendi Branşım"))
                    {
                        if (BranchID == anamnesis.Branchid)
                        {
                            AnamnesisListInfo info = new AnamnesisListInfo();
                            info.ObjectID = (Guid)anamnesis.ObjectID;
                            if (anamnesis.ProcessDate != null)
                                info.ProcessDate = Convert.ToDateTime(anamnesis.ProcessDate).ToString("dd.MM.yyyy");
                            else
                                info.ProcessDate = "";
                            info.UnitName = anamnesis.Unit;
                            info.DoctorName = anamnesis.Doctor;

                            result.Add(info);
                        }
                    }
                }

            }
            return result.ToArray();
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Anamnez_Gecmis_Goruntuleme)]
        public AnamnesisPopUp GetOldAnamnesisInfo([FromQuery] Guid PhysicianApplicationID )
        {
            AnamnesisPopUp result = new AnamnesisPopUp();

            TTObjectContext objectContext = new TTObjectContext(false);

            var physicianApplication = (PhysicianApplication)objectContext.GetObject(PhysicianApplicationID, "PhysicianApplication");
            if (physicianApplication is PatientExamination)
            {
                var patientExamination = (PatientExamination)objectContext.GetObject(PhysicianApplicationID, "PatientExamination");

                result.Complaint = patientExamination.Complaint;
                result.PatientHistory = patientExamination.PatientHistory;
                result.PhysicalExamination = patientExamination.PhysicalExamination;
                result.MTSConclusion = patientExamination.MTSConclusion;
                result.vitalSingsViewModel = patientExamination.GetVitalSingsFormViewModel(objectContext);
            }

            if (physicianApplication is InPatientPhysicianApplication)
            {
                var inPatientPhysicianApplication = (InPatientPhysicianApplication)objectContext.GetObject(PhysicianApplicationID, "InPatientPhysicianApplication");

                result.Complaint = inPatientPhysicianApplication.Complaint;
                result.PatientHistory = inPatientPhysicianApplication.PatientHistory;
                result.PhysicalExamination = inPatientPhysicianApplication.PhysicalExamination;
                result.MTSConclusion = inPatientPhysicianApplication.MTSConclusion;
                result.vitalSingsViewModel = inPatientPhysicianApplication.GetVitalSingsFormViewModel(objectContext);
            }

            if (physicianApplication is FollowUpExamination)
            {
                var followUpExamination = (FollowUpExamination)objectContext.GetObject(PhysicianApplicationID, "FollowUpExamination");

                result.Complaint = followUpExamination.Complaint;
                result.PatientHistory = followUpExamination.PatientHistory;
                result.PhysicalExamination = followUpExamination.PhysicalExamination;
                result.MTSConclusion = followUpExamination.MTSConclusion;
                result.vitalSingsViewModel = followUpExamination.GetVitalSingsFormViewModel(objectContext);
            }

            if (physicianApplication is Consultation)
            {
                var consultation = (Consultation)objectContext.GetObject(PhysicianApplicationID, "Consultation");

                result.Complaint = consultation.Complaint;
                result.PatientHistory = consultation.PatientHistory;
                result.PhysicalExamination = consultation.PhysicalExamination;
                result.MTSConclusion = consultation.MTSConclusion;
                result.vitalSingsViewModel = consultation.GetVitalSingsFormViewModel(objectContext);
            }

            if (physicianApplication is DentalExamination)
            {
                var dentalExamination = (DentalExamination)objectContext.GetObject(PhysicianApplicationID, "DentalExamination");

                result.Complaint = dentalExamination.Complaint;
                result.PatientHistory = dentalExamination.PatientHistory;
                result.PhysicalExamination = dentalExamination.PhysicalExamination;
                result.MTSConclusion = dentalExamination.MTSConclusion;
                result.vitalSingsViewModel = dentalExamination.GetVitalSingsFormViewModel(objectContext);
            }

            return result;
        }

    }
}

namespace Core.Models
{
    public partial class AnamnesisFormViewModel
    {
        public TTObjectClasses.EpisodeAction.VitalSingsFormViewModel vitalSingsViewModel = new EpisodeAction.VitalSingsFormViewModel();
        public Guid PatientID;
     
 
    }

    public class AnamnesisListInfo
    {
        public Guid ObjectID;
        public string ProcessDate;
        public string UnitName;
        public string DoctorName;
    }

    public class AnamnesisPopUp
    {
        public object Complaint;
        public object PatientHistory;
        public object PhysicalExamination;
        public object MTSConclusion;
        public TTObjectClasses.EpisodeAction.VitalSingsFormViewModel vitalSingsViewModel = new EpisodeAction.VitalSingsFormViewModel();
    }
}
