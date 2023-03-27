//$50775B2B
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Infrastructure.Helpers;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    public partial class StatusNotificationReportServiceController
    {
        partial void PreScript_StatusNotificationReportForm(StatusNotificationReportFormViewModel viewModel, StatusNotificationReport statusNotificationReport, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();

            if (selectedEpisodeActionObjectID.HasValue && viewModel._StatusNotificationReport.MasterAction == null)
            {
                EpisodeAction episodeAction = statusNotificationReport.ObjectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                viewModel._StatusNotificationReport.MasterAction = episodeAction;
                viewModel._StatusNotificationReport.MasterResource = episodeAction.MasterResource;
                viewModel._StatusNotificationReport.FromResource = episodeAction.MasterResource;
                viewModel._StatusNotificationReport.Episode = episodeAction.Episode;
                var P = viewModel._StatusNotificationReport.Episode.Patient; //Contexe patient ı yüklemediği için yazıldı silmeyin                
                viewModel._StatusNotificationReport.ProcedureDoctor = episodeAction.ProcedureDoctor;
                viewModel._StatusNotificationReport.SubEpisode = episodeAction.SubEpisode;
                viewModel._StatusNotificationReport.ActionDate = System.DateTime.Now;
                if (episodeAction is PatientExamination)
                    viewModel._StatusNotificationReport.ExaminationDate = ((PatientExamination)episodeAction).ProcessDate;
                else
                    viewModel._StatusNotificationReport.ExaminationDate = episodeAction.ActionDate;

                //if (episodeAction is InPatientPhysicianApplication)
                //{
                //    if (((InPatientPhysicianApplication)episodeAction).SubEpisode.InpatientAdmission != null)
                //    {
                //        viewModel._StatusNotificationReport.StartDate= ((InPatientPhysicianApplication)episodeAction).SubEpisode.InpatientAdmission.HospitalInPatientDate;
                //    }
                //}  
            }

            if (viewModel._StatusNotificationReport.MasterAction is InPatientPhysicianApplication)
            {
                if (((InPatientPhysicianApplication)viewModel._StatusNotificationReport.MasterAction).SubEpisode.InpatientAdmission != null)
                {
                    //viewModel._MedulaTreatmentReport.StartDate = ((InPatientPhysicianApplication)episodeAction).SubEpisode.InpatientAdmission.HospitalInPatientDate;
                    viewModel.minReportDate = ((DateTime)((InPatientPhysicianApplication)viewModel._StatusNotificationReport.MasterAction).SubEpisode.InpatientAdmission.HospitalInPatientDate).ToString("MM.dd.yyyy");
                }
            }
            else
            {
                viewModel.minReportDate = Common.RecTime().ToString("MM.dd.yyyy");
            }

            viewModel.maxReportDate = Common.RecTime().ToString("MM.dd.yyyy");


            if (statusNotificationReport.Episode != null && ((ITTObject)statusNotificationReport).IsNew == true && statusNotificationReport.SubEpisode != null && statusNotificationReport.SubEpisode.IsInvoicedCompletely)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25840", "Hastanın faturası kesilmiştir, Rapor yazamazsınız!"));

            //tanı kontrolü
            statusNotificationReport.CheckForDiagnosis();

            if (viewModel._StatusNotificationReport.StartDate == null)
                viewModel._StatusNotificationReport.StartDate = DateTime.Now;
            if (viewModel._StatusNotificationReport.ReportDurationType != PeriodUnitTypeWithUndefiniteEnum.Undefinite && viewModel._StatusNotificationReport.EndDate == null)
                viewModel._StatusNotificationReport.EndDate = DateTime.Now;

            if (Common.CurrentUser.IsSuperUser != true)
            {
                viewModel.IsSuperUser = false;
                if (Common.CurrentResource.UserType == UserTypeEnum.Doctor || Common.CurrentResource.UserType == UserTypeEnum.Dentist)
                {
                    if (viewModel._StatusNotificationReport.ProcedureDoctor == null)
                    {
                        viewModel._StatusNotificationReport.ProcedureDoctor = Common.CurrentResource;
                    }
                }
            }
            else
                viewModel.IsSuperUser = true;

            if (viewModel._StatusNotificationReport.MasterAction is PatientExamination)
            {
                viewModel.Complaint = ((PatientExamination)viewModel._StatusNotificationReport.MasterAction).Complaint != null ? TTReportTool.TTReport.HTMLtoText(((PatientExamination)viewModel._StatusNotificationReport.MasterAction).Complaint.ToString()) : null;
                viewModel.PhysicalExamination = ((PatientExamination)viewModel._StatusNotificationReport.MasterAction).PhysicalExamination != null ? TTReportTool.TTReport.HTMLtoText(((PatientExamination)viewModel._StatusNotificationReport.MasterAction).PhysicalExamination.ToString()) : null;
                viewModel.PatientHistory = ((PatientExamination)viewModel._StatusNotificationReport.MasterAction).PatientHistory != null ? TTReportTool.TTReport.HTMLtoText(((PatientExamination)viewModel._StatusNotificationReport.MasterAction).PatientHistory.ToString()) : null;
                viewModel.MTSConclusion = ((PatientExamination)viewModel._StatusNotificationReport.MasterAction).MTSConclusion != null ? TTReportTool.TTReport.HTMLtoText(((PatientExamination)viewModel._StatusNotificationReport.MasterAction).MTSConclusion.ToString()) : null;
            }
            else if (viewModel._StatusNotificationReport.MasterAction is InPatientPhysicianApplication)
            {
                viewModel.Complaint = ((InPatientPhysicianApplication)viewModel._StatusNotificationReport.MasterAction).Complaint != null ? TTReportTool.TTReport.HTMLtoText(((InPatientPhysicianApplication)viewModel._StatusNotificationReport.MasterAction).Complaint.ToString()) : null;
                viewModel.PhysicalExamination = ((InPatientPhysicianApplication)viewModel._StatusNotificationReport.MasterAction).PhysicalExamination != null ? TTReportTool.TTReport.HTMLtoText(((InPatientPhysicianApplication)viewModel._StatusNotificationReport.MasterAction).PhysicalExamination.ToString()) : null;
                viewModel.PatientHistory = ((InPatientPhysicianApplication)viewModel._StatusNotificationReport.MasterAction).PatientHistory != null ? TTReportTool.TTReport.HTMLtoText(((InPatientPhysicianApplication)viewModel._StatusNotificationReport.MasterAction).PatientHistory.ToString()) : null;
                viewModel.MTSConclusion = ((InPatientPhysicianApplication)viewModel._StatusNotificationReport.MasterAction).MTSConclusion != null ? TTReportTool.TTReport.HTMLtoText(((InPatientPhysicianApplication)viewModel._StatusNotificationReport.MasterAction).MTSConclusion.ToString()) : null;
            }


            if (statusNotificationReport.CurrentStateDefID == StatusNotificationReport.States.Saved)
            {
                viewModel.ToState = StatusNotificationReport.States.Saved;
                viewModel.ReadOnly = false;
            }
                if (statusNotificationReport.CurrentStateDefID == StatusNotificationReport.States.Completed)
            {
                viewModel.ToState = StatusNotificationReport.States.Completed;
                viewModel.ReadOnly = true;
            }
            ContextToViewModel(viewModel, objectContext);

        }
        partial void PostScript_StatusNotificationReportForm(StatusNotificationReportFormViewModel viewModel, StatusNotificationReport statusNotificationReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (statusNotificationReport.Episode != null && ((ITTObject)statusNotificationReport).IsNew == false && statusNotificationReport.Episode.IsInvoicedCompletely)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25839", "Hastanın faturası kesilmiştir, Rapor düzenleyemezsiniz!"));

            if (statusNotificationReport.ProcedureDoctor != null && statusNotificationReport.CommitteeReport == true)
            {
                if(statusNotificationReport.ProcedureDoctor.ObjectID == statusNotificationReport.SecondDoctor.ObjectID)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M30211", "1.Doktor ve 2.Doktor aynı kişiler olamaz."));
                if (statusNotificationReport.ProcedureDoctor.ObjectID == statusNotificationReport.ThirdDoctor.ObjectID)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M30212", "1.Doktor ve 3.Doktor aynı kişiler olamaz."));
                if (statusNotificationReport.ThirdDoctor.ObjectID == statusNotificationReport.SecondDoctor.ObjectID)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M30213", "2.Doktor ve3.Doktor aynı kişiler olamaz."));
            }
               

            if (statusNotificationReport.MasterAction == null)
            {
                statusNotificationReport.MasterAction = statusNotificationReport.SubEpisode.StarterEpisodeAction;
                statusNotificationReport.MasterResource = statusNotificationReport.SubEpisode.StarterEpisodeAction.MasterResource;
                statusNotificationReport.FromResource = statusNotificationReport.SubEpisode.StarterEpisodeAction.MasterResource;
                statusNotificationReport.Episode = statusNotificationReport.Episode;
                statusNotificationReport.SubEpisode = statusNotificationReport.SubEpisode;
                statusNotificationReport.ActionDate = Common.RecTime();
                viewModel.reportDiagnosisFormViewModel.episode = statusNotificationReport.Episode.ObjectID;
            }


            if (viewModel.reportDiagnosisFormViewModel.episode == null)
                viewModel.reportDiagnosisFormViewModel.episode = statusNotificationReport.Episode.ObjectID;

            if (statusNotificationReport.ProcedureByUser == null)//rapru ilk oluşturan kişi
            {
                statusNotificationReport.ProcedureByUser = Common.CurrentResource;
            }
            
            ReportDiagnosisServiceController a = new ReportDiagnosisServiceController();
            a.SaveDiagnosis(viewModel.reportDiagnosisFormViewModel, statusNotificationReport);

            objectContext.Save();

            if (viewModel.ToState == StatusNotificationReport.States.Saved)
                statusNotificationReport.CurrentStateDefID = StatusNotificationReport.States.Saved;
            if (viewModel.ToState == StatusNotificationReport.States.Completed)
                statusNotificationReport.CurrentStateDefID = StatusNotificationReport.States.Completed;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Durum_Bildirir_Raporu_Rapor_Muayene_Sebebi)]
        public StatusNotificationReportFormViewModel StatusNotificationReportFormEmpty()
        {
            var formDefID = Guid.Parse("1a563a40-3951-4d92-9e68-df9b976edc99");
            var objectDefID = Guid.Parse("1ddbfd97-104e-4845-8e1e-d3cb8ed45adb");
            var viewModel = new StatusNotificationReportFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._StatusNotificationReport = new StatusNotificationReport(objectContext);

                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._StatusNotificationReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._StatusNotificationReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._StatusNotificationReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._StatusNotificationReport);

                ContextToViewModel(viewModel, objectContext);

                PreScript_StatusNotificationReportForm(viewModel, viewModel._StatusNotificationReport, objectContext);

                viewModel.ToState = StatusNotificationReport.States.New;
                viewModel._StatusNotificationReport.CurrentStateDefID = StatusNotificationReport.States.New;

                if (viewModel._StatusNotificationReport.ProcedureDoctor == null)
                {
                    viewModel._StatusNotificationReport.ProcedureDoctor = Common.CurrentResource;
                }
                ContextToViewModel(viewModel, objectContext);

                objectContext.FullPartialllyLoadedObjects();
            }

            return viewModel;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Durum_Bildirir_Raporu_Rapor_Muayene_Sebebi)]
        public StatusNotificationReportFormViewModel StatusNotificationReportFormPre(Guid? id)
        {
            var formDefID = Guid.Parse("1a563a40-3951-4d92-9e68-df9b976edc99");
            var objectDefID = Guid.Parse("1ddbfd97-104e-4845-8e1e-d3cb8ed45adb");
            var viewModel = new StatusNotificationReportFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._StatusNotificationReport = objectContext.GetObject(id.Value, objectDefID) as StatusNotificationReport;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._StatusNotificationReport, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._StatusNotificationReport, formDefID);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    PreScript_StatusNotificationReportForm(viewModel, viewModel._StatusNotificationReport, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Durum_Bildirir_Raporu_Rapor_Muayene_Sebebi)]
        public ReasonForExaminationDefinition GetReasonForExamination(Guid requestReasonObjectID)
        {
            ReasonForExaminationDefinition reasonForExamination = new ReasonForExaminationDefinition();
            using (TTObjectContext context = new TTObjectContext(false))
            {
                HCRequestReason hcRequestReason = context.GetObject(requestReasonObjectID, typeof(HCRequestReason)) as HCRequestReason;
                reasonForExamination = hcRequestReason.ReasonForExamination;
            }
            return reasonForExamination;

        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Durum_Bildirir_Raporu_Yeni)]
        public void Undo(StatusNotificationReport statusNotificationReport)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                statusNotificationReport = objectContext.GetObject(statusNotificationReport.ObjectID, typeof(StatusNotificationReport)) as StatusNotificationReport;

                if (statusNotificationReport.CurrentStateDefID == StatusNotificationReport.States.Completed)
                    statusNotificationReport.CurrentStateDefID = StatusNotificationReport.States.Saved;

                objectContext.Save();
            }
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Durum_Bildirir_Raporu_Yeni)]
        public void Cancel(StatusNotificationReport statusNotificationReport)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                statusNotificationReport = objectContext.GetObject(statusNotificationReport.ObjectID, typeof(StatusNotificationReport)) as StatusNotificationReport;

                if (statusNotificationReport.CurrentStateDefID == StatusNotificationReport.States.Saved)
                    statusNotificationReport.CurrentStateDefID = StatusNotificationReport.States.Cancelled;

                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public partial class StatusNotificationReportFormViewModel
    {
        public int txtRaporSuresi
        {
            get;
            set;
        }
        public PeriodUnitTypeWithUndefiniteEnum cmbRaporSureTuru
        {
            get;
            set;
        }
        public bool IsSuperUser
        {
            get;
            set;
        }
        public Guid ToState
        {
            get;
            set;
        }
        public ReportDiagnosisFormViewModel reportDiagnosisFormViewModel = new ReportDiagnosisFormViewModel();
        public string Complaint
        {
            get;
            set;
        }
        public string PatientHistory
        {
            get;
            set;
        }
        public string PhysicalExamination
        {
            get;
            set;
        }
        public string MTSConclusion
        {
            get;
            set;
        }

        public string maxReportDate { get; set; }
        public string minReportDate { get; set; }
    }
}
