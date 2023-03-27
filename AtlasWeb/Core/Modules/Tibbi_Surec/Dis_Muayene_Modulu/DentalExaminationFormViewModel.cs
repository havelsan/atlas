//$C079D331
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class DentalExaminationServiceController
    {
        partial void PostScript_DentalExaminationForm(DentalExaminationFormViewModel viewModel, DentalExamination dentalExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //foreach (DentalExaminationProcedure dentalExaminationProcedure in dentalExamination.DentalExaminationProcedures)
            //{
            //    dentalExaminationProcedure.SetPerformedDate();
            //}

            dentalExamination.AccountingOperation();

            //foreach (TTObjectClasses.DentalProcedure dp in dentalExamination.DentalProcedures)
            //{
            //    String disNo = "";
            //    foreach (ITTGridRow row in DentalProsthesis.Rows)
            //    {
            //        if (((TTObjectClasses.DentalProcedure)row.TTObject).Equals(dp))
            //        {
            //            disNo = row.Cells[4].Value.ToString();
            //            break;
            //        }
            //    }

            //    examinationRtf = Common.GetTextOfRTFString(this.DentalExaminationFile1.Rtf);
            //    String examinationText = dp.ProcedureObject.Code + "-" + dp.ProcedureObject.Description + " iþlemi " + Common.RecTime().Date.ToShortDateString() + " tarihinde " + disNo + " diþine yapýlmýþtýr.\n";

            //    if (!examinationRtf.Contains(examinationText))
            //    {
            //        examinationRtf += examinationText;
            //        this.DentalExaminationFile1.Rtf = Common.GetRTFOfTextString(examinationRtf);
            //    }
            //}

            bool found;
            foreach (DentalExaminationSuggestedProsthesis sp in dentalExamination.SuggestedProsthesis)
            {
                found = false;
                if (sp.DentalLaboratoryProcedure == null && sp.Department != null)
                {
                    foreach (DentalLaboratoryProcedure dp in dentalExamination.Laboratory)
                    {
                        if (dp.MasterResource.ObjectID == sp.Department.ObjectID)
                        {
                            if (dp.CurrentStateDefID != DentalLaboratoryProcedure.States.Completed)
                            {
                                sp.DentalLaboratoryProcedure = dp;
                                found = true;
                                break;
                            }
                            else
                            {
                                throw new TTException(dp.MasterResource.Name + " birimine ait Laboratuvar iþlemi tamamlandý durumunda olduðundan deðiþiklik yapamazsýnýz, önce laboratuvar iþlemini yeni adýmýna geçiriniz.");
                            }
                        }
                    }
                    if (!found)
                    {
                        DentalLaboratoryProcedure dentalLab = new DentalLaboratoryProcedure(objectContext, dentalExamination, sp);
                        sp.DentalLaboratoryProcedure = dentalLab;
                    }
                }
            }
            if (viewModel.createNewProcedure == true && (dentalExamination.CurrentStateDefID == DentalExamination.States.Examination || dentalExamination.CurrentStateDefID == DentalExamination.States.ExaminationCompleted))
                dentalExamination.CurrentStateDefID = DentalExamination.States.ProcedureRequested;
            else if (viewModel.createNewProcedure != true && (dentalExamination.CurrentStateDefID == DentalExamination.States.Examination))
                dentalExamination.CurrentStateDefID = DentalExamination.States.ExaminationCompleted;

            objectContext.AddToRawObjectList(viewModel.GrdConsultationGridList);
            objectContext.AddToRawObjectList(viewModel.GrdPatientInterviewFormGridList);
            objectContext.AddToRawObjectList(viewModel.GrdExternalConsultationGridList);
            objectContext.AddToRawObjectList(viewModel.GrdDentalExaminationGridList);

            if (viewModel.GrdConsultationGridList != null)
            {
                foreach (var item in viewModel.GrdConsultationGridList)
                {
                    var consultationsImported = (Consultation)objectContext.AddObject(item);
                    consultationsImported.PhysicianApplication = dentalExamination;
                }
            }

            if (viewModel.GrdPatientInterviewFormGridList != null)
            {
                foreach (var item in viewModel.GrdPatientInterviewFormGridList)
                {
                    var patientInterviewsImported = (PatientInterviewForm)objectContext.AddObject(item);
                    patientInterviewsImported.PhysicianApplication = dentalExamination;
                }
            }

            if (viewModel.GrdExternalConsultationGridList != null)
            {
                foreach (var item in viewModel.GrdExternalConsultationGridList)
                {
                    var externalConsultationsImported = (ConsultationFromExternalHospital)objectContext.AddObject(item);
                    externalConsultationsImported.PhysicianApplication = dentalExamination;
                }
            }

            if (viewModel.GrdDentalExaminationGridList != null)
            {
                foreach (var item in viewModel.GrdDentalExaminationGridList)
                {
                    var dentalExaminationsImported = (DentalExamination)objectContext.AddObject(item);
                    dentalExaminationsImported.MasterPhysicianApplication = dentalExamination;
                }
            }

            dentalExamination.SetVitalSingsFormViewModel(viewModel.anamnesisFormViewModel.vitalSingsViewModel);
            dentalExamination.Complaint = viewModel.anamnesisFormViewModel._PhysicianApplication.Complaint;
            dentalExamination.PatientHistory = viewModel.anamnesisFormViewModel._PhysicianApplication.PatientHistory;
            dentalExamination.PhysicalExamination = viewModel.anamnesisFormViewModel._PhysicianApplication.PhysicalExamination;
            dentalExamination.MTSConclusion = viewModel.anamnesisFormViewModel._PhysicianApplication.MTSConclusion;

    
            //TANI için
            dentalExamination.DiagnosisGrid_PostScript(viewModel.DiagnosisGridGridList);

            //ENabýz Kaydetmek için
            if (viewModel.ENabizViewModels != null)
            {
                foreach (var enabizViewModel in viewModel.ENabizViewModels)
                {
                    enabizViewModel.AddENabizObjectViewModelToContext(objectContext);
                }
            }

      

        }

        partial void PreScript_DentalExaminationForm(DentalExaminationFormViewModel viewModel, DentalExamination dentalExamination, TTObjectContext objectContext)
        {
            dentalExamination.SetProcedureDoctorAsCurrentResource();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            var episode = viewModel._DentalExamination.Episode;
            var patient = viewModel._DentalExamination.Episode.Patient;
            var dentalCommitment = viewModel._DentalExamination.DentalCommitment;
            //var deliveredBy = viewModel._Morgue.DeliveredBy;
            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
            viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
            viewModel.DentalCommitments = objectContext.LocalQuery<DentalCommitment>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserListDefinition", viewModel.ResUsers);

            BindingList<EpisodeAction> reportList = EpisodeAction.GetAllReportsOfPatient(objectContext, dentalExamination.Episode.Patient.ObjectID.ToString());
            if (reportList.Count > 0)
            {
                List<PatientReportInfo> patientReportInfoList = new List<PatientReportInfo>();
                foreach (EpisodeAction report in reportList)
                {
                    PatientReportInfo patientReportInfo = new PatientReportInfo();
                    patientReportInfo.ObjectID = report.ObjectID;
                    patientReportInfo.ObjectDefName = report.ObjectDef.Name;
                    patientReportInfo.ID = report.ID.ToString();
                    patientReportInfo.MasterResource = report.MasterResource.Name;

                    if (report.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient)
                    {
                        if (report.SubEpisode.InpatientAdmission != null)
                            patientReportInfo.AdmissionDate = report.SubEpisode.InpatientAdmission.HospitalInPatientDate.Value.ToShortDateString();
                        else
                            patientReportInfo.AdmissionDate = report.SubEpisode.OpeningDate.Value.ToShortDateString();
                    }
                    else if (report.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Outpatient)
                    {
                        patientReportInfo.AdmissionDate = report.SubEpisode.PatientAdmission.ActionDate.Value.ToShortDateString();
                    }

                    if (report is ParticipatnFreeDrugReport)
                    {
                        if (((ParticipatnFreeDrugReport)report).ReportStartDate.HasValue)
                            patientReportInfo.StartDate = ((ParticipatnFreeDrugReport)report).ReportStartDate.Value.ToShortDateString();
                        else
                            patientReportInfo.StartDate = null;
                        if (((ParticipatnFreeDrugReport)report).ReportEndDate.HasValue)
                            patientReportInfo.EndDate = ((ParticipatnFreeDrugReport)report).ReportEndDate.Value.ToShortDateString();
                        else
                            patientReportInfo.EndDate = null;
                        patientReportInfo.ReportName = ((ParticipatnFreeDrugReport)report).ObjectDef.ApplicationName;
                        patientReportInfo.CancelledReport = (((ParticipatnFreeDrugReport)report).CurrentStateDefID == ParticipatnFreeDrugReport.States.Cancelled) ? true : false;
                        patientReportInfo.RequestReason = "Ýlaç Raporu";
                    }

                    if (report is StatusNotificationReport)
                    {
                        if (((StatusNotificationReport)report).StartDate.HasValue)
                            patientReportInfo.StartDate = ((StatusNotificationReport)report).StartDate.Value.ToShortDateString();
                        else
                            patientReportInfo.StartDate = ((StatusNotificationReport)report).StartDate.Value.ToShortDateString();
                        if (((StatusNotificationReport)report).EndDate.HasValue)
                            patientReportInfo.EndDate = ((StatusNotificationReport)report).EndDate.Value.ToShortDateString();
                        else
                            patientReportInfo.EndDate = null;
                        patientReportInfo.ReportName = ((StatusNotificationReport)report).ObjectDef.ApplicationName;
                        patientReportInfo.CancelledReport = (((StatusNotificationReport)report).CurrentStateDefID == StatusNotificationReport.States.Cancelled) ? true : false;
                        patientReportInfo.RequestReason = ((StatusNotificationReport)report).HCRequestReason.ReasonName;
                    }
                    if (report is MedulaTreatmentReport)
                    {
                        if (((MedulaTreatmentReport)report).StartDate.HasValue)
                            patientReportInfo.StartDate = ((MedulaTreatmentReport)report).StartDate.Value.ToShortDateString();
                        else
                            patientReportInfo.StartDate = null;
                        if (((MedulaTreatmentReport)report).EndDate.HasValue)
                            patientReportInfo.EndDate = ((MedulaTreatmentReport)report).EndDate.Value.ToShortDateString();
                        else
                            patientReportInfo.EndDate = null;
                        patientReportInfo.ReportName = ((MedulaTreatmentReport)report).ObjectDef.ApplicationName;
                        patientReportInfo.CancelledReport = (((MedulaTreatmentReport)report).CurrentStateDefID == MedulaTreatmentReport.States.Cancelled) ? true : false;
                        patientReportInfo.RequestReason = Common.GetDisplayTextOfDataTypeEnum(((MedulaTreatmentReport)report).TedaviRaporTuru);
                    }

                    if (report is MedicalStuffReport)
                    {
                        if (((MedicalStuffReport)report).StartDate.HasValue)
                            patientReportInfo.StartDate = ((MedicalStuffReport)report).StartDate.Value.ToShortDateString();
                        else
                            patientReportInfo.StartDate = null;
                        if (((MedicalStuffReport)report).EndDate.HasValue)
                            patientReportInfo.EndDate = ((MedicalStuffReport)report).EndDate.Value.ToShortDateString();
                        else
                            patientReportInfo.EndDate = null;
                        patientReportInfo.ReportName = ((MedicalStuffReport)report).ObjectDef.ApplicationName;
                        patientReportInfo.CancelledReport = (((MedicalStuffReport)report).CurrentStateDefID == MedulaTreatmentReport.States.Cancelled) ? true : false;
                        patientReportInfo.RequestReason = "Týbbi Malzeme Raporu";
                    }
                    if (patientReportInfo.CancelledReport)
                        patientReportInfo.ReportName += patientReportInfo.ReportName + " ( ÝPTAL EDÝLDÝ )";

                    patientReportInfoList.Add(patientReportInfo);
                }

                viewModel.PatientReportInfoList = patientReportInfoList;
            }

            if (viewModel.GrdConsultationGridList == null)
            {
                viewModel.GrdConsultationGridList = new TTObjectClasses.Consultation[] { };
            }
            else
            {
                viewModel.GrdConsultationGridList = viewModel._DentalExamination.Consultations.OfType<Consultation>().ToArray();
            }

            if (viewModel.GrdPatientInterviewFormGridList == null)
            {
                viewModel.GrdPatientInterviewFormGridList = new TTObjectClasses.PatientInterviewForm[] { };
            }
            else
            {
                viewModel.GrdPatientInterviewFormGridList = viewModel._DentalExamination.PatientInteviewForms.OfType<PatientInterviewForm>().ToArray();
            }
            if (viewModel.GrdExternalConsultationGridList == null)
            {
                viewModel.GrdExternalConsultationGridList = new TTObjectClasses.ConsultationFromExternalHospital[] { };
            }
            else
            {
                viewModel.GrdExternalConsultationGridList = viewModel._DentalExamination.ExternalConsultations.OfType<ConsultationFromExternalHospital>().ToArray();
            }
            if (viewModel.GrdDentalExaminationGridList == null)
            {
                viewModel.GrdDentalExaminationGridList = new TTObjectClasses.DentalExamination[] { };
            }
            else
            {
                viewModel.GrdDentalExaminationGridList = viewModel._DentalExamination.LinkedDentalConsultations.OfType<DentalExamination>().ToArray();
            }

            if (viewModel._DentalExamination.Diagnosis != null && viewModel._DentalExamination.Diagnosis.Count > 0)
            {
                viewModel.hasSavedDiagnosis = true;
            }
            else
            {
                viewModel.hasSavedDiagnosis = false;
            }

            this.removeOutgoingTransitions(viewModel, dentalExamination);

            viewModel.includeDrugDefinition = false;
            if ((TTObjectClasses.SystemParameter.GetParameterValue("PATIENTEXAMINATIONINCLUDEDRUGS", "FALSE") == "TRUE"))
                viewModel.includeDrugDefinition = true;
            viewModel.ExaminationProcessAndEndDate = "";
            if (viewModel._DentalExamination.ProcessTime.HasValue == false)
                viewModel._DentalExamination.ProcessTime = Common.RecTime();
            if (viewModel._DentalExamination.ProcessDate.HasValue == false)
                viewModel._DentalExamination.ProcessDate = Common.RecTime();
            viewModel.ExaminationProcessAndEndDate = viewModel._DentalExamination.ProcessDate.Value.ToString("dd.MM.yyyy HH:mm");
            if (viewModel._DentalExamination.ProcessEndDate.HasValue)
                viewModel.ExaminationProcessAndEndDate += "    / " + viewModel._DentalExamination.ProcessEndDate.Value.ToString("dd.MM.yyyy HH:mm");

            viewModel.anamnesisFormViewModel._PhysicianApplication = new PhysicianApplication();
            viewModel.anamnesisFormViewModel._PhysicianApplication = (PhysicianApplication)dentalExamination;
            viewModel.anamnesisFormViewModel.vitalSingsViewModel = dentalExamination.GetVitalSingsFormViewModel(objectContext);
            viewModel.anamnesisFormViewModel.PatientID = dentalExamination.Episode.Patient.ObjectID;
            
            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalýþmamalý
            if (dentalExamination.ProcedureSpeciality != null)
                viewModel.IsAuthorizedToWriteTreatmentReport = EpisodeAction.IsAuthorizedToWriteTreatmentReport(dentalExamination.ProcedureSpeciality);
            else
                viewModel.IsAuthorizedToWriteTreatmentReport = false;

            //ContextToViewModel den sonra çaðýrýlmalý //TANI için
            ContextToViewModel(viewModel, objectContext);
            viewModel.DiagnosisGridGridList = dentalExamination.DiagnosisGrid_PreScript();
            viewModel.DentalProsthesisGridList = viewModel.DentalProsthesisGridList.Where(t => t.CurrentStateDefID != DentalProcedure.States.Cancelled).ToArray();
            viewModel.UsedMaterialsGridList = viewModel.UsedMaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
            viewModel.isNewMHRS = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE"));
        }

        void FillConsultationHistory(DentalExaminationFormViewModel viewModel)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            BindingList<Consultation> oldConsultations = viewModel._DentalExamination.GetConsultationsHistory();
            foreach (Consultation cons in oldConsultations)
            {
                OldConsultationInfo oldCons = new OldConsultationInfo();
                oldCons.consultationObjectID = cons.ObjectID;
                oldCons.consultationActionDate = Convert.ToDateTime(cons.ActionDate);
                oldCons.consultationRequesterResource = (cons.RequesterResource == null ? "" : cons.RequesterResource.Name);
                oldCons.consultationMasterResource = (cons.MasterResource == null ? "" : cons.MasterResource.Name);
                oldCons.consultationRequestDescription = (cons.RequestDescription == null ? "" : Common.GetTextOfRTFString(cons.RequestDescription.ToString()));
                oldCons.consultationResult = (cons.ConsultationResultAndOffers == null ? "" : Common.GetTextOfRTFString(cons.ConsultationResultAndOffers.ToString()));
                oldCons.consultationDiagnosis = new List<ConsultationDiagnosis>();
                foreach (DiagnosisGrid diagnosis in cons.Diagnosis)
                {
                    ConsultationDiagnosis cDiagnosis = new ConsultationDiagnosis();
                    cDiagnosis.consultationDiagnose = diagnosis.Diagnose.Code + " " + diagnosis.Diagnose.Name;
                    cDiagnosis.consultationFreeDiagnose = diagnosis.FreeDiagnosis;
                    oldCons.consultationDiagnosis.Add(cDiagnosis);
                }

                oldCons.consultationStateStatus = Convert.ToInt32(cons.CurrentStateDef.Status);
                oldCons.consultationState = cons.CurrentStateDef.DisplayText;
                viewModel.ConsultationsHistory.Add(oldCons);
            }
        }

        protected void removeOutgoingTransitions(DentalExaminationFormViewModel viewModel, DentalExamination dentalExamination)
        {
            List<TTObjectStateTransitionDef> removedOutgoingTransitions = new List<TTObjectStateTransitionDef>();
            if (viewModel._DentalExamination.IsConsultation != null && viewModel._DentalExamination.IsConsultation == true)
            {
                foreach (var trans in viewModel.OutgoingTransitions)
                {
                    if (!(trans.ToStateDefID == DentalExamination.States.Cancelled || trans.ToStateDefID == DentalExamination.States.Completed))
                    {
                        removedOutgoingTransitions.Add(trans);
                    }

                }
            }
            else
            {
                foreach (var trans in viewModel.OutgoingTransitions)
                {
                    removedOutgoingTransitions.Add(trans);
                }
            }

            foreach (var removedtrans in removedOutgoingTransitions)
            {
                viewModel.OutgoingTransitions.Remove(removedtrans);
            }
        }

        partial void AfterContextSaveScript_DentalExaminationForm(DentalExaminationFormViewModel viewModel, DentalExamination dentalExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            this.removeOutgoingTransitions(viewModel, dentalExamination);
        }

        [HttpGet]
        public bool CheckProtesisPocedures(Guid DentalExaminationID)
        {
            bool result = false;

            BindingList<DentalProcedure.GetDentalProtesisProcedures_Class> list = DentalProcedure.GetDentalProtesisProcedures(DentalExaminationID.ToString());
            if (list.ToArray().Length > 0)
                result = true;
            return result;
        }
    }
}

namespace Core.Models
{
    public partial class DentalExaminationFormViewModel
    {
        public AnamnesisFormViewModel anamnesisFormViewModel = new AnamnesisFormViewModel();
        public List<OldConsultationInfo> ConsultationsHistory = new List<OldConsultationInfo>();
        public NewConsultationRequestInfo[] NewConsultationRequests;
        public Boolean IsAuthorizedToWriteTreatmentReport { get; set; }
        public ReportTypeEnum reportType
        {
            get;
            set;
        }

        public List<PatientReportInfo> PatientReportInfoList = new List<PatientReportInfo>();

        public bool createNewProcedure
        {
            get;
            set;
        }

        public TTObjectClasses.Consultation[] GrdConsultationGridList
        {
            get;
            set;
        }

        public TTObjectClasses.PatientInterviewForm[] GrdPatientInterviewFormGridList
        {
            get;
            set;
        }


        public TTObjectClasses.ConsultationFromExternalHospital[] GrdExternalConsultationGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DentalExamination[] GrdDentalExaminationGridList
        {
            get;
            set;
        }

        public bool hasSavedDiagnosis
        {
            get;
            set;
        }
        public bool includeDrugDefinition { get; set; }
        public string ExaminationProcessAndEndDate { get; set; }

        public IENabizViewModel[] ENabizViewModels
        {
            get; set;
        }

        public TTObjectClasses.DentalCommitment[] DentalCommitments { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }

        public bool isNewMHRS
        {
            get;
            set;
        }
    }
}

