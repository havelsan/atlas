//$4A7E0508
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{

    public partial class CreatingEpicrisisServiceController
    {
        partial void PreScript_CreatingEpicrisisForm(CreatingEpicrisisFormViewModel viewModel, CreatingEpicrisis creatingEpicrisis, TTObjectContext objectContext)
        {
            //yeni form açıldığında rtf alanların temizlenmesi için geçici çözüm
            if (viewModel._CreatingEpicrisis.PHYSICALEXAMINATION == null)
                viewModel._CreatingEpicrisis.PHYSICALEXAMINATION = "";
            if (viewModel._CreatingEpicrisis.COMPLAINTANDSTORY == null)
                viewModel._CreatingEpicrisis.COMPLAINTANDSTORY = "";
            if (viewModel._CreatingEpicrisis.PROCEDURE == null)
                viewModel._CreatingEpicrisis.PROCEDURE = "";
            if (viewModel._CreatingEpicrisis.STORY == null)
                viewModel._CreatingEpicrisis.STORY = "";
            if (viewModel._CreatingEpicrisis.SYMPTOM == null)
                viewModel._CreatingEpicrisis.SYMPTOM = "";
            if (viewModel._CreatingEpicrisis.AUTOBIOGRAPHY == null)
                viewModel._CreatingEpicrisis.AUTOBIOGRAPHY = "";
            if (viewModel._CreatingEpicrisis.Suggestion == null)
                viewModel._CreatingEpicrisis.Suggestion = "";

            
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionObjectID != null)
            {
                InPatientPhysicianApplication activeEa = objectContext.GetObject<InPatientPhysicianApplication>(selectedEpisodeActionObjectID.Value);
                SubEpisode subEpisode = activeEa.SubEpisode;

                if (viewModel._CreatingEpicrisis.SubEpisode == null)
                {
                    viewModel._CreatingEpicrisis.MasterResource = activeEa.MasterResource;
                    viewModel._CreatingEpicrisis.SubEpisode = subEpisode;

                    if (viewModel._CreatingEpicrisis.ProcedureDoctor == null && Common.CurrentUser.HasRole(TTRoleNames.Tabip) && Common.CurrentUser.IsSuperUser == false)
                    {
                        viewModel._CreatingEpicrisis.ProcedureDoctor = Common.CurrentResource;
                    }

                    if (viewModel._CreatingEpicrisis.MasterResource == null && Common.CurrentUser.HasRole(TTRoleNames.Tabip) && Common.CurrentUser.IsSuperUser == false)
                    {
                        viewModel._CreatingEpicrisis.MasterResource = activeEa.MasterResource;
                    }

                    viewModel._CreatingEpicrisis.FromResource = activeEa.FromResource;
                    viewModel._CreatingEpicrisis.MasterAction = activeEa;
                    viewModel._CreatingEpicrisis.Episode = activeEa.Episode;
                    viewModel._CreatingEpicrisis.RequestDate = Common.RecTime();
                    if(activeEa.Complaint != null)
                    {
                        viewModel._CreatingEpicrisis.COMPLAINTANDSTORY = activeEa.Complaint.ToString(); 
                    }
                    if(activeEa.PatientHistory != null)
                    {
                        viewModel._CreatingEpicrisis.AUTOBIOGRAPHY = activeEa.PatientHistory.ToString();
                    }
                    if(activeEa.PhysicalExamination != null)
                    {
                        viewModel._CreatingEpicrisis.PHYSICALEXAMINATION = activeEa.PhysicalExamination.ToString();
                    }

                }

            }

            viewModel.actionId = viewModel._CreatingEpicrisis.MasterAction.ObjectID;
            viewModel.Clinic = viewModel._CreatingEpicrisis.MasterResource;
            viewModel.DepartmentName = viewModel.Clinic.Name;
            BindingList<ResUser> ClinicDoctorList = ResUser.GetClinicDoctorList(objectContext, " AND" + " USERRESOURCES(RESOURCE = '" + viewModel.Clinic.ObjectID.ToString() + "').EXISTS");
            viewModel.DoctorList = ClinicDoctorList.ToList();

            viewModel.Doctor = viewModel._CreatingEpicrisis.ProcedureDoctor;
         //   var ea = objectContext.GetObject<EpisodeAction>(viewModel.ActiveIDsModel.EpisodeActionId.Value);

          
            if (Common.CurrentUser.HasRole(TTRoleNames.Hemsire))
            {
                viewModel.NurseAuthority = true;
            }
            else if (Common.CurrentUser.HasRole(TTRoleNames.Tabip) == true && viewModel.Doctor == viewModel._CreatingEpicrisis.ProcedureDoctor)
            {
                viewModel.DoctorAuthority = true;
            }

            viewModel.DoctorName = ((InPatientPhysicianApplication)creatingEpicrisis.MasterAction).ProcedureDoctor.Name;
            //viewModel.DayNumber = subEpisode.ClosingDate
            //Hastanin bir kabulu icinde bulunan yatislardaki birim bilgisini tutar.
            viewModel.ClinicList = new List<ResSection>();
            viewModel.InpatientClinicList = new List<ResSection>();
            BaseInpatientAdmission baseInpatientAdmission = ((InPatientPhysicianApplication)viewModel._CreatingEpicrisis.MasterAction).InPatientTreatmentClinicApp.BaseInpatientAdmission; // InPatientTreatmentClinicApp.BaseInpatientAdmission;
            foreach (InPatientTreatmentClinicApplication clinicApplication in baseInpatientAdmission.InPatientTreatmentClinicApplications.OrderBy(t => t.ClinicInpatientDate))
            {
                foreach (InPatientPhysicianApplication physicianApplication in clinicApplication.InPatientPhysicianApplication.Where(t => t.CurrentStateDefID != InPatientPhysicianApplication.States.Cancelled))
                {
                    viewModel.ClinicList.Add(physicianApplication.MasterResource);
                }

            }


            foreach (InPatientTreatmentClinicApplication clinicApplication in baseInpatientAdmission.InPatientTreatmentClinicApplications.OrderBy(t => t.ClinicInpatientDate))
            {
                foreach (InPatientPhysicianApplication physicianApplication in clinicApplication.InPatientPhysicianApplication.Where(t => t.CurrentStateDefID != InPatientPhysicianApplication.States.Cancelled))
                {
                    viewModel.InpatientClinicList.Add(physicianApplication.MasterResource);
                }

            }


            viewModel.StayLength = baseInpatientAdmission.EstimatedInpatientDateCount;
            EpisodeAction starterEpisodeAction = viewModel._CreatingEpicrisis.SubEpisode.StarterEpisodeAction;
            if (starterEpisodeAction != null && starterEpisodeAction is InPatientTreatmentClinicApplication)
            {
                InPatientTreatmentClinicApplication TreatmentClinicApp = (InPatientTreatmentClinicApplication)starterEpisodeAction;

                if (starterEpisodeAction.SubEpisode.InpatientStatus != null)
                {
                    if (starterEpisodeAction.SubEpisode.InpatientStatus.Value == InpatientStatusEnum.Discharged
                        || starterEpisodeAction.SubEpisode.InpatientStatus.Value == InpatientStatusEnum.Predischarged)
                    {
                        if (TreatmentClinicApp.ClinicDischargeDate != null && TreatmentClinicApp.ClinicInpatientDate != null)
                        {
                            viewModel.DayNumber = (TreatmentClinicApp.ClinicDischargeDate.Value - TreatmentClinicApp.ClinicInpatientDate.Value).Days;
                        }
                    }

                    else if (starterEpisodeAction.SubEpisode.InpatientStatus.Value == InpatientStatusEnum.Inpatient)
                    {
                        if (TreatmentClinicApp.ClinicInpatientDate != null)
                            viewModel.DayNumber = (Common.RecTime() - TreatmentClinicApp.ClinicInpatientDate.Value).Days + 1;

                    }
                }

                else
                {
                    if (TreatmentClinicApp.TreatmentDischarge != null && TreatmentClinicApp.TreatmentDischarge.CurrentStateDefID == TreatmentDischarge.States.Discharged)
                    {
                        if (TreatmentClinicApp.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Transferred)
                        {
                            if (TreatmentClinicApp.ClinicDischargeDate != null && TreatmentClinicApp.ClinicInpatientDate != null)//yat�� ve taburcu tarihi var ise yat�� g�n say�s� hesaplama
                            {
                                viewModel.DayNumber = (TreatmentClinicApp.ClinicDischargeDate.Value - TreatmentClinicApp.ClinicInpatientDate.Value).Days;
                            }
                        }

                        else
                        {
                            if (TreatmentClinicApp.ClinicDischargeDate != null && TreatmentClinicApp.ClinicInpatientDate != null)//yat�� ve taburcu tarihi var ise yat�� g�n say�s� hesaplama
                            {
                                viewModel.DayNumber = (TreatmentClinicApp.ClinicDischargeDate.Value - TreatmentClinicApp.ClinicInpatientDate.Value).Days;
                            }
                        }
                    }

                    else if (TreatmentClinicApp.TreatmentDischarge != null && TreatmentClinicApp.TreatmentDischarge.CurrentStateDefID == TreatmentDischarge.States.PreDischarge)
                    {
                        if (TreatmentClinicApp.ClinicDischargeDate != null && TreatmentClinicApp.ClinicInpatientDate != null)//yat�� ve taburcu tarihi var ise yat�� g�n say�s� hesaplama
                        {
                            viewModel.DayNumber = (TreatmentClinicApp.ClinicDischargeDate.Value - TreatmentClinicApp.ClinicInpatientDate.Value).Days;
                        }
                    }
                    else
                    {
                        if (TreatmentClinicApp.ClinicInpatientDate != null)//yat�� tarihi var ise yat�� g�n say�s� hesaplama
                        {
                            viewModel.DayNumber = (Common.RecTime() - TreatmentClinicApp.ClinicInpatientDate.Value).Days + 1;
                        }
                    }
                }
            }
            viewModel.Epicrisises = new List<CreatingEpicrisis>();
            foreach (var action in viewModel._CreatingEpicrisis.SubEpisode.EpisodeActions)
            {
                if (action is CreatingEpicrisis)
                {
                    //  viewModel._CreatingEpicrisis = ((CreatingEpicrisis)action);
                    viewModel.Doctor = viewModel._CreatingEpicrisis.ProcedureDoctor;
                    viewModel.Epicrisises.Add((CreatingEpicrisis)action);
                }
            }

            if (viewModel._CreatingEpicrisis.CurrentStateDefID == CreatingEpicrisis.States.Completed)
            {
                viewModel.isReportConfirmByDoctor = true;
            }

            else
                viewModel.isReportConfirmByDoctor = false;

            if(viewModel._CreatingEpicrisis.CurrentStateDefID == CreatingEpicrisis.States.PreApproval)
            {
                viewModel.WaitConfirmation = true;
            }

            viewModel.IsNew = ((ITTObject)creatingEpicrisis).IsNew;
            var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, viewModel._CreatingEpicrisis.ObjectDef.ID, "EpicrisisReportTemplate").ToList();
            viewModel.userTemplateList = new List<UserTemplateModel>();
            foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList.Where(t => t.TAObjectID.ToString() != viewModel._CreatingEpicrisis.ObjectID.ToString()))
            {
                UserTemplateModel templateModel = new UserTemplateModel();
                templateModel.ObjectID = item.ObjectID;
                templateModel.TAObjectID = item.TAObjectID;
                templateModel.TAObjectDefID = item.TAObjectDefID;
                templateModel.Description = item.Description;
                viewModel.userTemplateList.Add(templateModel);
            }

        }

        partial void PostScript_CreatingEpicrisisForm(CreatingEpicrisisFormViewModel viewModel, CreatingEpicrisis creatingEpicrisis, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (creatingEpicrisis.ProcedureDoctor == null)
            {
                throw new Exception("'Doktor' alanı boş geçilemez");
            }
            if (creatingEpicrisis.MasterResource == null)
            {
                throw new Exception("'Birim' alanı boş geçilemez");
            }

            objectContext.Update();

            if (viewModel.isReportConfirmByDoctor == true)
            {
                creatingEpicrisis.CurrentStateDefID = CreatingEpicrisis.States.Completed;

            }

            else if (viewModel.isReportConfirmByOthers == true)
            {
                creatingEpicrisis.CurrentStateDefID = CreatingEpicrisis.States.PreApproval;
            }

            else if (viewModel.isRemoveConfirmation && creatingEpicrisis.CurrentStateDefID == CreatingEpicrisis.States.Completed)
            {
                creatingEpicrisis.CurrentStateDefID = CreatingEpicrisis.States.ReportEntry;
            }


        }

        partial void AfterContextSaveScript_CreatingEpicrisisForm(CreatingEpicrisisFormViewModel viewModel, CreatingEpicrisis creatingEpicrisis, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
   

        }

        [HttpGet]
        public List<ResUser> FillDoctorList(string input)
        {

            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                List<ResUser> UserList = ResUser.GetClinicDoctorList(objectContext, input).ToList();
                objectContext.FullPartialllyLoadedObjects();
                return UserList;
            }
        }

        [HttpPost]
        public CreatingEpicrisis CheckEpicrisisReport(CreatingEpicrisisFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {

                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);

                if (viewModel._CreatingEpicrisis != null)
                {
                    CreatingEpicrisis epicirisisReport = objectContext.GetObject<CreatingEpicrisis>(viewModel._CreatingEpicrisis.ObjectID);
                    objectContext.FullPartialllyLoadedObjects();
                    return epicirisisReport;
                }
                CreatingEpicrisis report = new CreatingEpicrisis(objectContext, episodeAction);
                return report;
            }

        }


        [HttpGet]
        public CreatingEpicrisis GetPatientEpicrisis(Guid episodeActionID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(episodeActionID);
                CreatingEpicrisis epicirisisReport = null;
                foreach (var action in episodeAction.SubEpisode.EpisodeActions)
                {
                    if (action is CreatingEpicrisis)
                    {
                        epicirisisReport = (CreatingEpicrisis)action;
                    }
                }
                objectContext.FullPartialllyLoadedObjects();
                return epicirisisReport;
            }

        }

        [HttpGet]
        public List<EpicrisisGridResultModel> GetPatientAllEpicrisisReport(string episodeInput)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                //    Episode episode = objectContext.GetObject<Episode>(new Guid(episodeInput));
                List<EpicrisisGridResultModel> EpicrisisList = new List<EpicrisisGridResultModel>();
                //    EpicrisisList = CreatingEpicrisis.GetPatientAllEpicrisisReport(objectContext, episode.Patient.ObjectID).ToList();

                BindingList<CreatingEpicrisis.GetAllEpicrisisReport_Class> epicrisisQuery = new BindingList<CreatingEpicrisis.GetAllEpicrisisReport_Class>();
                epicrisisQuery = CreatingEpicrisis.GetAllEpicrisisReport(new Guid(episodeInput));

                if (epicrisisQuery.Count != 0)
                {
                    foreach (CreatingEpicrisis.GetAllEpicrisisReport_Class epikriz in epicrisisQuery)
                    {
                        EpicrisisGridResultModel model = new EpicrisisGridResultModel();

                        model.ObjectID = epikriz.ObjectID;
                        model.Doctor = epikriz.Doctor;
                        model.Clinic = epikriz.Clinic;
                        model.Date = epikriz.ActionDate;
                        EpicrisisList.Add(model);
                    }
                }
                EpicrisisList = EpicrisisList.OrderByDescending(x => x.Date).ToList();
                return EpicrisisList;
            }
        }


        [HttpGet]
        public CreatingEpicrisis GetSelectedEpicrisis(string objectId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                CreatingEpicrisis epicrisis = objectContext.GetObject<CreatingEpicrisis>(new Guid(objectId));
                objectContext.FullPartialllyLoadedObjects();
                return epicrisis;
            }

        }

        [HttpGet]
        public CreatingEpicrisisFormViewModel EpicrisisReportFormPre(Guid? id)
        {
            var formDefID = Guid.Parse("8c5df8fc-5b93-42c1-b7c6-77933e4bb2e7");
            var objectDefID = Guid.Parse("233d73fe-04b4-4ab2-beec-808a4dd30262");
            var viewModel = new CreatingEpicrisisFormViewModel();

            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._CreatingEpicrisis = objectContext.GetObject(id.Value, objectDefID) as CreatingEpicrisis;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._CreatingEpicrisis, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CreatingEpicrisis, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._CreatingEpicrisis);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._CreatingEpicrisis);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    PreScript_CreatingEpicrisisForm(viewModel, viewModel._CreatingEpicrisis, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public List<UserTemplateModel> SaveEpicrisisReportUserTemplate(UserTemplateModel userTemplate)
        {
            List<UserTemplateModel> userTemplatesList = new List<UserTemplateModel>();

            using (var objectContext = new TTObjectContext(false))
            {
                if (userTemplate.ObjectID != null)
                {
                    UserTemplate oldUserTemplate = objectContext.GetObject<UserTemplate>((Guid)userTemplate.ObjectID);
                    oldUserTemplate.FiliterData = "DELETED-EpicrisisReportTemplate";
                }
                else
                {
                    UserTemplate newUserTemplate = new UserTemplate(objectContext);
                    newUserTemplate.TAObjectDefID = userTemplate.TAObjectDefID;
                    newUserTemplate.TAObjectID = userTemplate.TAObjectID;
                    newUserTemplate.FiliterData = "EpicrisisReportTemplate";
                    newUserTemplate.ResUser = Common.CurrentResource;
                    newUserTemplate.Description = userTemplate.Description;
                }

                objectContext.Save();
                var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, (Guid)userTemplate.TAObjectDefID, "EpicrisisReportTemplate").ToList();
                foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList)
                {
                    UserTemplateModel templateModel = new UserTemplateModel();
                    templateModel.ObjectID = item.ObjectID;
                    templateModel.TAObjectID = item.TAObjectID;
                    templateModel.TAObjectDefID = item.TAObjectDefID;
                    templateModel.Description = item.Description;
                    userTemplatesList.Add(templateModel);
                }
            }
            return userTemplatesList;
        }

        [HttpPost]
        public CreatingEpicrisisFormViewModel EpicrisisReportFormTemplate(CreatingEpicrisisFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (viewModel.selectedUserTemplate != null)
                {
                    CreatingEpicrisis templateEpicrisisReport = objectContext.GetObject<CreatingEpicrisis>((Guid)viewModel.selectedUserTemplate.TAObjectID);
                    CreatingEpicrisis reportObject = (CreatingEpicrisis)objectContext.AddObject(viewModel._CreatingEpicrisis);
                 //   var doctor1 = reportObject.ProcedureDoctor;
                    reportObject.COMPLAINTANDSTORY = templateEpicrisisReport.COMPLAINTANDSTORY;
                    reportObject.STORY = templateEpicrisisReport.STORY;
                    reportObject.SYMPTOM = templateEpicrisisReport.SYMPTOM;
                    reportObject.PHYSICALEXAMINATION = templateEpicrisisReport.PHYSICALEXAMINATION;
                    reportObject.AUTOBIOGRAPHY = templateEpicrisisReport.AUTOBIOGRAPHY;
                    reportObject.PROCEDURE = templateEpicrisisReport.PROCEDURE;
                    reportObject.Suggestion = templateEpicrisisReport.Suggestion;

                    viewModel._CreatingEpicrisis = reportObject;

                    }
                    viewModel.ListDefDisplayExpressions = new Dictionary<string, object>();
                    ContextToViewModel(viewModel, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
             }
            

            return viewModel;
        }


        [HttpGet]
        public bool ChangeEpicrisisState(Guid? id)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                CreatingEpicrisis epicrisis = objectContext.GetObject<CreatingEpicrisis>(id.Value);
                epicrisis.CurrentStateDefID = CreatingEpicrisis.States.ReportEntry;
                objectContext.Save();
            }


            return true;
        }
    }
}

namespace Core.Models
{
    public partial class CreatingEpicrisisFormViewModel : BaseViewModel
    {
        public ResSection Clinic { get; set; }
        public ResUser Doctor { get; set; }
        public List<CreatingEpicrisis> Epicrisises { get; set; }
        public bool DoctorAuthority { get; set; }
        public List<ResSection> ClinicList { get; set; }
        public List<ResUser> DoctorList { get; set; }
        public int? StayLength { get; set; }
        public int DayNumber { get; set; }
        public bool isReportConfirmByDoctor { get; set; }
        public bool isReportConfirmByOthers { get; set; }
        public List<ResSection> InpatientClinicList { get; set; } //Yaln�zca hastan�n yatt��� birimleri tutmak i�in
        public List<ResSection> RelatedDoctorList { get; set; } //Yaln�zca hastan�n yatt��� birimlerde g�revli doktorlar i�in.
        public string DoctorName { get; set; }
        public string DepartmentName { get; set; }
        public Guid? actionId { get; set; }
        public bool NurseAuthority { get; set; }
        public bool isRemoveConfirmation { get; set; }
        public bool IsNew { get; set; }
        public List<UserTemplateModel> userTemplateList { get; set; }
        public UserTemplateModel selectedUserTemplate { get; set; }
        public bool WaitConfirmation { get; set; }

    }

    public class EpicrisisGridResultModel
    {
        public Guid? ObjectID { get; set; }
        public string Doctor { get; set; }
        public string Clinic { get; set; }
        public DateTime? Date { get; set; }
    }
}
