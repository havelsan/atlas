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
using Infrastructure.Helpers;
using TTUtils;
using TTStorageManager.Security;
using TTStorageManager;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using Core.Security;
using TTDefinitionManagement;
using Newtonsoft.Json;
using static TTObjectClasses.SubEpisodeProtocol;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Core.Controllers
{
    public partial class PatientExaminationServiceController : Controller
    {
        [HttpGet]
        public PatientExaminationDoctorFormNewViewModel PatientExaminationDoctorFormNew(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return PatientExaminationDoctorFormNewLoadInternal(input);
        }

        [HttpPost]
        public PatientExaminationDoctorFormNewViewModel PatientExaminationDoctorFormNewLoad(FormLoadInput input)
        {
            return PatientExaminationDoctorFormNewLoadInternal(input);
        }

        private PatientExaminationDoctorFormNewViewModel PatientExaminationDoctorFormNewLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("92c5ba28-a5ba-4659-bfdf-17c453b14eab");
            var objectDefID = Guid.Parse("2a112388-5c95-40c2-b074-d40eab3c6a1b");
            var viewModel = new PatientExaminationDoctorFormNewViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._PatientExamination = objectContext.GetObject(id.Value, objectDefID) as PatientExamination;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientExamination, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientExamination, formDefID);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PatientExamination);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PatientExamination);
                    PreScript_PatientExaminationDoctorFormNew(viewModel, viewModel._PatientExamination, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._PatientExamination = new PatientExamination(objectContext);
                    var entryStateID = Guid.Parse("de3eaf04-75ee-4978-8f85-980be4bfabae");
                    viewModel._PatientExamination.CurrentStateDefID = entryStateID;
                    viewModel.DiagnosisHistoryGridList = new TTObjectClasses.DiagnosisGrid[] { };
                    viewModel.GridEpisodeDiagnosisGridList = new TTObjectClasses.DiagnosisGrid[] { };
                    //viewModel.GridAdditionalApplicationsGridList = new TTObjectClasses.PatientExaminationAdditionalApplication[] { };
                    //    viewModel.GridTreatmentMaterialsGridList = new TTObjectClasses.PatientExaminationTreatmentMaterial[] { };
                    viewModel.NewGridTreatmentMaterialsGridList = new TTObjectClasses.BaseTreatmentMaterial[] { };
                    viewModel.GrdConsultationGridList = new TTObjectClasses.Consultation[] { };
                    viewModel.GrdPatientInterviewFormGridList = new TTObjectClasses.PatientInterviewForm[] { };
                    viewModel.GrdDentalExaminationGridList = new TTObjectClasses.DentalExamination[] { };
                    viewModel.GrdExternalConsultationGridList = new TTObjectClasses.ConsultationFromExternalHospital[] { };
                    viewModel.ttgridSevkEdenDoktorlarGridList = new TTObjectClasses.DoctorGrid[] { };
                    viewModel.GridNursingOrdersGridList = new TTObjectClasses.SingleNursingOrder[] { };
                    viewModel.ForensicProceduresGridGridList = new TTObjectClasses.PatientExaminationForensicProcedure[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientExamination, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientExamination, formDefID);
                    viewModel.hasSavedDiagnosis = false;
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PatientExamination);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PatientExamination);
                    PreScript_PatientExaminationDoctorFormNew(viewModel, viewModel._PatientExamination, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        void FillConsultationHistory(PatientExaminationDoctorFormNewViewModel viewModel)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            BindingList<Consultation> oldConsultations = viewModel._PatientExamination.GetConsultationsHistory();
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

        void AddToContext(TTObjectContext objectContext, TTObject[] arrTTObject)
        {
            if (arrTTObject != null)
            {
                foreach (var item in arrTTObject)
                {
                    objectContext.AddObject(item);
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Muayenesi_Muayene)]
        public void CompleteExamination(bool IsExaminationCompleted, Guid peObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (IsExaminationCompleted == true)
                {
                    PatientExamination pe = objectContext.GetObject<PatientExamination>(peObjectID);
                    if (pe.CurrentStateDefID != PatientExamination.States.Completed)
                    {
                        //if (pe.PatientExaminationType == PatientExaminationEnum.HealthCommittee && pe.CurrentStateDefID == PatientExamination.States.ExaminationCompleted)
                        //{
                        //    pe.CurrentStateDefID = PatientExamination.States.Completed;
                        //}
                        pe.CurrentStateDefID = PatientExamination.States.Completed;
                        if (pe.PatientExaminationType == PatientExaminationEnum.HealthCommittee/* && pe.CurrentStateDefID == PatientExamination.States.ProcedureRequested*/ && pe.TreatmentResult != null)
                        {
                            if (pe.HCExaminationComponent != null && pe.MasterAction is HealthCommittee && ((HealthCommittee)pe.MasterAction).HCRequestReason?.ReasonForExamination?.HCReportTypeDefinition?.IsDisabled == true)
                            {
                                EDisabledReport eDisabledReport = null;
                                if (pe.HCExaminationComponent != null && pe.HCExaminationComponent.EDisabledReport != null)
                                {
                                    eDisabledReport = pe.HCExaminationComponent.EDisabledReport;
                                }
                                if (eDisabledReport != null)
                                {
                                    if (eDisabledReport.PatientAppId == null || eDisabledReport.PatientAppId == "0")
                                    {
                                        if (eDisabledReport.IsCozgerReport == null || eDisabledReport.IsCozgerReport == false)
                                            EDisabledReportServiceController.CreateEReportApplication(eDisabledReport, objectContext);
                                        else
                                            EDisabledReportServiceController.CreateCozgerApplication(eDisabledReport, objectContext);
                                    }
                                    else
                                    {
                                        if (eDisabledReport.IsCozgerReport == null || eDisabledReport.IsCozgerReport == false)
                                            EDisabledReportServiceController.UpdateEReportApplication(eDisabledReport, EngelliRaporuMuayeneAdimiEnum.PatientAppCreated, objectContext);
                                        else
                                            EDisabledReportServiceController.UpdateCozgerApplication(eDisabledReport, EngelliRaporuMuayeneAdimiEnum.PatientAppCreated, objectContext);
                                    }
                                    objectContext.Save();
                                    if (eDisabledReport.IsCozgerReport == null || eDisabledReport.IsCozgerReport == false)
                                        EDisabledReportServiceController.GetEReportPatientApp(eDisabledReport, objectContext);
                                    else
                                        EDisabledReportServiceController.GetCozgerReportPatientApp(eDisabledReport, objectContext);

                                }
                            }
                            else
                            {
                                EStatusNotRepCommitteeObj eStatusNotRepCommitteeObj = null;
                                if (pe.HCExaminationComponent != null && pe.HCExaminationComponent.EStatusNotRepCommitteeObj != null)
                                {
                                    eStatusNotRepCommitteeObj = pe.HCExaminationComponent.EStatusNotRepCommitteeObj;
                                }
                                string entegrasyonAktif = TTObjectClasses.SystemParameter.GetParameterValue("EDURUMBILDIRIRKURULENTAKTIF", "FALSE");

                                if (eStatusNotRepCommitteeObj != null && eStatusNotRepCommitteeObj.PatientApplicationID != null && entegrasyonAktif == "TRUE" && ((HealthCommittee)pe.MasterAction).HCRequestReason?.ReasonForExamination?.IntegratedReporting == true)
                                {
                                    EDurumBildirirKurulServiceController.SendEDurumBildirirKurulExamination(pe, eStatusNotRepCommitteeObj, objectContext);
                                }
                            }

                        }

                        objectContext.Save();
                    }
                }
            }
        }

        [HttpPost]
        public void PatientExaminationDoctorFormNew(PatientExaminationDoctorFormNewViewModel viewModel)
        {
            var formDefID = Guid.Parse("92c5ba28-a5ba-4659-bfdf-17c453b14eab");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.Episodes);
                objectContext.AddToRawObjectList(viewModel.Patients);
                objectContext.AddToRawObjectList(viewModel.DietMaterialDefinitions);
                objectContext.AddToRawObjectList(viewModel.ActiveIngredientDefinitions);
                objectContext.AddToRawObjectList(viewModel.ImportantMedicalInformations);
                objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
                objectContext.AddToRawObjectList(viewModel.ResUsers);
                objectContext.AddToRawObjectList(viewModel.OzelDurums);
                objectContext.AddToRawObjectList(viewModel.SKRSCikisSeklis);
                objectContext.AddToRawObjectList(viewModel.SpecialityDefinitions);
                objectContext.AddToRawObjectList(viewModel.ResSections);
                objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
                objectContext.AddToRawObjectList(viewModel.Materials);
                objectContext.AddToRawObjectList(viewModel.StockCards);
                objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
                objectContext.AddToRawObjectList(viewModel.SevkVasitasis);
                objectContext.AddToRawObjectList(viewModel.VitalSignAndNursingDefinitions);
                objectContext.AddToRawObjectList(viewModel.SingleNursingOrderDetails);
                objectContext.AddToRawObjectList(viewModel.DiagnosisHistoryGridList);
                objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
                //objectContext.AddToRawObjectList(viewModel.GridAdditionalApplicationsGridList);
                //objectContext.AddToRawObjectList(viewModel.GridTreatmentMaterialsGridList);
                objectContext.AddToRawObjectList(viewModel.NewGridTreatmentMaterialsGridList);
                objectContext.AddToRawObjectList(viewModel.GrdConsultationGridList);
                objectContext.AddToRawObjectList(viewModel.GrdPatientInterviewFormGridList);
                objectContext.AddToRawObjectList(viewModel.GrdDentalExaminationGridList);
                objectContext.AddToRawObjectList(viewModel.GrdExternalConsultationGridList);
                objectContext.AddToRawObjectList(viewModel.ttgridSevkEdenDoktorlarGridList);
                objectContext.AddToRawObjectList(viewModel.GridNursingOrdersGridList);
                objectContext.AddToRawObjectList(viewModel.ForensicProceduresGridGridList);
                objectContext.AddToRawObjectList(viewModel.HCExaminationComponents);
                objectContext.AddToRawObjectList(viewModel.HCExaminationDisabledRatios);
                objectContext.AddToRawObjectList(viewModel.EmergencyInterventions);
                var entryStateID = Guid.Parse("de3eaf04-75ee-4978-8f85-980be4bfabae");
                objectContext.AddToRawObjectList(viewModel._PatientExamination, entryStateID);
                objectContext.ProcessRawObjects(false);
                var patientExamination = (PatientExamination)objectContext.GetLoadedObject(viewModel._PatientExamination.ObjectID);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(patientExamination, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientExamination, formDefID);
                var episodeImported = patientExamination.Episode;
                if (episodeImported != null)
                {
                    var patientImported = episodeImported.Patient;
                    if (patientImported != null)
                    {
                        var importantMedicalInformationImported = patientImported.ImportantMedicalInformation;
                        if (importantMedicalInformationImported != null)
                        {
                            if (viewModel.DiagnosisHistoryGridList != null)
                            {
                                foreach (var item in viewModel.DiagnosisHistoryGridList)
                                {
                                    var diagnosisHistoryImported = (DiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                                    diagnosisHistoryImported.ImportantMedicalInformation = importantMedicalInformationImported;
                                }
                            }
                        }
                    }

                    if (viewModel.GridEpisodeDiagnosisGridList != null)
                    {
                        foreach (var item in viewModel.GridEpisodeDiagnosisGridList)
                        {
                            var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                            if (diagnosisImported == null)
                                throw new Exception("Sistemsel bir hata oluştu, Hata yönetime iletildi.", new Exception("diagnosisImported == null, item.ObjectID :" + item.ObjectID.ToString()));

                            if (((ITTObject)diagnosisImported).IsDeleted)
                                continue;
                            diagnosisImported.Episode = episodeImported;
                            if (diagnosisImported.EpisodeAction == null)
                                diagnosisImported.EpisodeAction = patientExamination;
                        }
                    }


                }

                //if (viewModel.GridAdditionalApplicationsGridList != null)
                //{
                //    foreach (var item in viewModel.GridAdditionalApplicationsGridList)
                //    {
                //        var patientExaminationAdditionalApplicationsImported = (PatientExaminationAdditionalApplication)objectContext.AddObject(item);
                //        patientExaminationAdditionalApplicationsImported.PatientExamination = patientExamination;
                //    }
                //}

                //if (viewModel.GridTreatmentMaterialsGridList != null)
                //{
                //    foreach (var item in viewModel.GridTreatmentMaterialsGridList)
                //    {
                //        var patientExaminationTreatmentMaterialsImported = (PatientExaminationTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                //        if (((ITTObject)patientExaminationTreatmentMaterialsImported).IsDeleted)
                //            continue;
                //        patientExaminationTreatmentMaterialsImported.EpisodeAction = patientExamination;
                //    }
                //}

                if (viewModel.NewGridTreatmentMaterialsGridList != null)
                {
                    foreach (var item in viewModel.NewGridTreatmentMaterialsGridList)
                    {
                        var patientExaminationTreatmentMaterialsImported = (BaseTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)patientExaminationTreatmentMaterialsImported).IsDeleted || patientExaminationTreatmentMaterialsImported.EpisodeAction != null)
                            continue;
                        patientExaminationTreatmentMaterialsImported.EpisodeAction = patientExamination;
                    }
                }

                if (viewModel.GrdConsultationGridList != null)
                {
                    foreach (var item in viewModel.GrdConsultationGridList)
                    {
                        var consultationsImported = (Consultation)objectContext.AddObject(item);
                        consultationsImported.PhysicianApplication = patientExamination;
                    }
                }

                if (viewModel.GrdPatientInterviewFormGridList != null)
                {
                    foreach (var item in viewModel.GrdPatientInterviewFormGridList)
                    {
                        var patientInterviewsImported = (PatientInterviewForm)objectContext.AddObject(item);
                        patientInterviewsImported.PhysicianApplication = patientExamination;
                    }
                }

                if (viewModel.GrdDentalExaminationGridList != null)
                {
                    foreach (var item in viewModel.GrdDentalExaminationGridList)
                    {
                        var dentalExaminationsImported = (DentalExamination)objectContext.AddObject(item);
                        dentalExaminationsImported.MasterPhysicianApplication = patientExamination;
                    }
                }

                if (viewModel.HCExaminationDisabledRatios != null)
                {
                    foreach (var item in viewModel.HCExaminationDisabledRatios)
                    {
                        var hcExaminationDisabledRatioImported = (HCExaminationDisabledRatio)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)hcExaminationDisabledRatioImported).IsDeleted)
                            continue;
                        hcExaminationDisabledRatioImported.HCExaminationComponent = patientExamination.HCExaminationComponent != null ? patientExamination.HCExaminationComponent : null;
                    }
                }

                if (viewModel.GrdExternalConsultationGridList != null)
                {
                    foreach (var item in viewModel.GrdExternalConsultationGridList)
                    {
                        var externalConsultationsImported = (ConsultationFromExternalHospital)objectContext.AddObject(item);
                        externalConsultationsImported.PhysicianApplication = patientExamination;
                    }
                }

                if (viewModel.ttgridSevkEdenDoktorlarGridList != null)
                {
                    foreach (var item in viewModel.ttgridSevkEdenDoktorlarGridList)
                    {
                        var doctorsGridImported = (DoctorGrid)objectContext.AddObject(item);
                        doctorsGridImported.PatientExamination = patientExamination;
                    }
                }

                if (viewModel.GridNursingOrdersGridList != null)
                {
                    foreach (var item in viewModel.GridNursingOrdersGridList)
                    {
                        var singleNursingOrdersImported = (SingleNursingOrder)objectContext.AddObject(item);
                        singleNursingOrdersImported.PhysicianApplication = patientExamination;
                    }
                }

                if (viewModel.ForensicProceduresGridGridList != null)
                {
                    foreach (var item in viewModel.ForensicProceduresGridGridList)
                    {
                        var patientExaminationForensicProcedureImported = (PatientExaminationForensicProcedure)objectContext.AddObject(item);
                        patientExaminationForensicProcedureImported.PatientExamination = patientExamination;
                    }
                }

                //Uzmanlık Kaydetmek için
                if (viewModel.SpecialityBasedObjectViewModels != null)
                {
                    foreach (var specialityBasedObjectViewModel in viewModel.SpecialityBasedObjectViewModels)
                    {
                        if (specialityBasedObjectViewModel is ISpecialityBasedObjectViewModel)
                        {
                            ((ISpecialityBasedObjectViewModel)specialityBasedObjectViewModel).AddSpecialityBasedObjectViewModelToContext(objectContext);
                        }
                    }
                }
                //BaseHCExaminationDynamicObject den oluşan Sağlık Kurulu Ek alanların kaydedilmesi
                if (viewModel.BaseHCExaminationDynamicObjectFormViewModelList != null)
                {
                    foreach (var baseHCExaminationDynamicObjectForm in viewModel.BaseHCExaminationDynamicObjectFormViewModelList)
                    {
                        ((BaseHCExaminationDynamicObjectFormViewModel)baseHCExaminationDynamicObjectForm).AddBaseHCExaminationDynamicObjectFormViewModelToContext(objectContext);
                    }
                }

                //ENabız Kaydetmek için
                if (viewModel.ENabizViewModels != null)
                {
                    foreach (var enabizViewModel in viewModel.ENabizViewModels)
                    {
                        enabizViewModel.AddENabizObjectViewModelToContext(objectContext);
                    }
                }

                //Fizyoterapi İsteği Başlatmak için
                if (viewModel.StartPhysiotherapyRequest == true && viewModel.HasAuthorityForPhysiotherapyRequest == true)
                {
                    bool isPhysiotherapyRequest = false;
                    foreach (var episodeaction in patientExamination.LinkedActions)
                    {
                        if (episodeaction is PhysiotherapyRequest)
                        {
                            isPhysiotherapyRequest = true;
                            break;
                        }
                    }

                    if (isPhysiotherapyRequest != true)
                    {
                        try
                        {
                            PhysiotherapyRequest physiotherapyRequest = new PhysiotherapyRequest(objectContext, patientExamination);
                            physiotherapyRequest.PhysiotherapyRequestDate = DateTime.Now;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }

                //var hcExaminationComponent = viewModel.HCExaminationComponents;
                //if (hcExaminationComponent != null && hcExaminationComponent.Length > 0)
                //{
                //    var hcExaminationComponentImported = hcExaminationComponent;
                //}

                // Anemlez Formdan yapılıyor
                //if (viewModel.Height != null)
                //{
                //    Height height = null;
                //    if (patientExamination.Heights.Count == 0)
                //    {
                //        height = new Height(objectContext);
                //        height.EpisodeAction = patientExamination;
                //    }
                //    else
                //    {
                //        height = patientExamination.Heights[0];
                //    }

                //    height.Value = Convert.ToInt32(viewModel.Height);
                //    height.ExecutionDate = Common.RecTime();
                //}

                //if (viewModel.Weight != null)
                //{
                //    Weight weight = null;
                //    if (patientExamination.Weights.Count == 0)
                //    {
                //        weight = new Weight(objectContext);
                //        weight.EpisodeAction = patientExamination;
                //    }
                //    else
                //    {
                //        weight = patientExamination.Weights[0];
                //    }

                //    weight.Value = Convert.ToInt32(viewModel.Weight);
                //    weight.ExecutionDate = Common.RecTime();
                //}

                if (patientExamination.PatientAdmission.PAStatus == PAStatusEnum.Sirada)
                    patientExamination.PatientAdmission.PAStatus = PAStatusEnum.Muayenede;
                if (patientExamination.PatientAdmission.CurrentStateDefID == null)
                    patientExamination.PatientAdmission.CurrentStateDefID = PatientAdmission.States.Open;
                if (viewModel.createNewProcedure == true && (patientExamination.CurrentStateDefID == PatientExamination.States.Examination || patientExamination.CurrentStateDefID == PatientExamination.States.ExaminationCompleted))
                    patientExamination.CurrentStateDefID = PatientExamination.States.ProcedureRequested;
                else if (viewModel.createNewProcedure != true && (patientExamination.CurrentStateDefID == PatientExamination.States.Examination))
                    patientExamination.CurrentStateDefID = PatientExamination.States.ExaminationCompleted;

                var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(patientExamination);
                PostScript_PatientExaminationDoctorFormNew(viewModel, patientExamination, transDef, objectContext);
                objectContext.AdvanceStateForNewObjects();
                objectContext.Save();
                AfterContextSaveScript_PatientExaminationDoctorFormNew(viewModel, patientExamination, transDef, objectContext);

            }
        }

        partial void PreScript_PatientExaminationDoctorFormNew(PatientExaminationDoctorFormNewViewModel viewModel, PatientExamination patientExamination, TTObjectContext objectContext);
        partial void PostScript_PatientExaminationDoctorFormNew(PatientExaminationDoctorFormNewViewModel viewModel, PatientExamination patientExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void AfterContextSaveScript_PatientExaminationDoctorFormNew(PatientExaminationDoctorFormNewViewModel viewModel, PatientExamination patientExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            List<ExaminationQueueItem> queueItem = ExaminationQueueItem.GetByEpisodeAction(objectContext, patientExamination.ObjectID).ToList();
            //ExaminationQueueItem queueItem = callPatientObjectContext.GetObject<ExaminationQueueItem>(param.examinationQueueItem.ObjectID);
            if (queueItem.Count > 0)
            {
                if (queueItem[0].CurrentStateDefID != ExaminationQueueItem.States.Completed)
                {
                    queueItem[0].CurrentStateDefID = ExaminationQueueItem.States.Completed;
                    objectContext.Save();
                }
            }

            ExaminationQueueDefinition queue = ExaminationQueueDefinition.GetQueueByResource(objectContext, patientExamination.MasterResource.ObjectID.ToString()).FirstOrDefault();
            if (queue != null)
            {
                List<Guid> doctorGUIDs = new List<Guid>();
                doctorGUIDs.Add(patientExamination.ProcedureDoctor.ObjectID);
                BindingList<ExaminationQueueItem> examinationQueues = ExaminationQueueItem.GetActiveQueueItemsOfPatientByQueueByDate(objectContext, doctorGUIDs, queue.ObjectID, Common.RecTime().Date.AddDays(1).AddSeconds(-1), Common.RecTime().Date, patientExamination.Episode.Patient.ObjectID);
                foreach (ExaminationQueueItem item in examinationQueues)
                {
                    if (item.CurrentStateDefID != ExaminationQueueItem.States.Completed)
                    {
                        item.CurrentStateDefID = ExaminationQueueItem.States.Completed;
                        objectContext.Save();
                    }
                }
            }
        }

        void ContextToViewModel(PatientExaminationDoctorFormNewViewModel viewModel, TTObjectContext objectContext)
        {
            var episode = viewModel._PatientExamination.Episode;
            if (episode != null)
            {
                var patient = episode.Patient;
                if (patient != null)
                {
                    viewModel.PatientId = patient.ObjectID;
                    var importantMedicalInformation = patient.ImportantMedicalInformation;
                    if (importantMedicalInformation != null)
                    {
                        viewModel.DiagnosisHistoryGridList = importantMedicalInformation.DiagnosisHistory.OfType<DiagnosisGrid>().ToArray();
                    }
                    //else
                    //{
                    //    patient.ImportantMedicalInformation = new ImportantMedicalInformation(objectContext);
                    //}
                }

                if (viewModel._PatientExamination.SubEpisode.PatientAdmission.EmergencyIntervention != null && viewModel._PatientExamination.SubEpisode.PatientAdmission.EmergencyIntervention.PatientExaminations.Count == 0)
                    viewModel._PatientExamination.EmergencyIntervention = viewModel._PatientExamination.SubEpisode.PatientAdmission.EmergencyIntervention;

                //if (episode.EpisodeActions[0] != null && episode.EpisodeActions[0].PatientAdmission != null && episode.EpisodeActions[0].PatientAdmission.EmergencyIntervention != null)
                //    viewModel._PatientExamination.EmergencyIntervention = episode.EpisodeActions[0].PatientAdmission.EmergencyIntervention;
                viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
            }

            //viewModel.GridAdditionalApplicationsGridList = viewModel._PatientExamination.PatientExaminationAdditionalApplications.OfType<PatientExaminationAdditionalApplication>().ToArray();
            //   viewModel.GridTreatmentMaterialsGridList = viewModel._PatientExamination.PatientExaminationTreatmentMaterials.OfType<PatientExaminationTreatmentMaterial>().ToArray();
            viewModel.GrdConsultationGridList = viewModel._PatientExamination.Consultations.OfType<Consultation>().ToArray();
            viewModel.GrdPatientInterviewFormGridList = viewModel._PatientExamination.PatientInteviewForms.OfType<PatientInterviewForm>().ToArray();
            viewModel.GrdDentalExaminationGridList = viewModel._PatientExamination.LinkedDentalConsultations.OfType<DentalExamination>().ToArray();
            viewModel.GrdExternalConsultationGridList = viewModel._PatientExamination.ExternalConsultations.OfType<ConsultationFromExternalHospital>().ToArray();
            viewModel.ttgridSevkEdenDoktorlarGridList = viewModel._PatientExamination.DoctorsGrid.OfType<DoctorGrid>().ToArray();
            viewModel.GridNursingOrdersGridList = viewModel._PatientExamination.SingleNursingOrders.OfType<SingleNursingOrder>().ToArray();
            viewModel.ForensicProceduresGridGridList = viewModel._PatientExamination.PatientExaminationForensicProcedure.OfType<PatientExaminationForensicProcedure>().ToArray();
            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
            viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
            viewModel.DietMaterialDefinitions = objectContext.LocalQuery<DietMaterialDefinition>().ToArray();
            viewModel.ActiveIngredientDefinitions = objectContext.LocalQuery<ActiveIngredientDefinition>().ToArray();
            viewModel.ImportantMedicalInformations = objectContext.LocalQuery<ImportantMedicalInformation>().ToArray();
            viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
            viewModel.EmergencyInterventions = objectContext.LocalQuery<EmergencyIntervention>().ToArray();
            var e = viewModel._PatientExamination.HCExaminationComponent; //Contexe HCExaminationComponent yüklemediği için yazıldı silmeyin
            viewModel.HCExaminationComponents = objectContext.LocalQuery<HCExaminationComponent>().ToArray();
            viewModel.SKRSCikisSeklis = objectContext.LocalQuery<SKRSCikisSekli>().ToArray();
            viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
            viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
            viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
            viewModel.PatientExaminations = objectContext.LocalQuery<PatientExamination>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
            viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
            viewModel.SevkVasitasis = objectContext.LocalQuery<SevkVasitasi>().ToArray();
            viewModel.VitalSignAndNursingDefinitions = objectContext.LocalQuery<VitalSignAndNursingDefinition>().ToArray();
            viewModel.SingleNursingOrderDetails = objectContext.LocalQuery<SingleNursingOrderDetail>().ToArray();
            viewModel.ExaminationProcessAndEndDate = "";
            if (viewModel._PatientExamination.CurrentStateDef.Status == StateStatusEnum.Uncompleted && viewModel._PatientExamination.ProcessDate.HasValue == false)
                viewModel._PatientExamination.ProcessDate = Common.RecTime();

            if (viewModel._PatientExamination.ProcessDate.HasValue)
                viewModel.ExaminationProcessAndEndDate = viewModel._PatientExamination.ProcessDate.Value.ToString("dd.MM.yyyy HH:mm");

            if (viewModel._PatientExamination.ProcessEndDate.HasValue)
                viewModel.ExaminationProcessAndEndDate += "    / " + viewModel._PatientExamination.ProcessEndDate.Value.ToString("dd.MM.yyyy HH:mm");
            if (viewModel._PatientExamination.Diagnosis != null && viewModel._PatientExamination.Diagnosis.Count > 0)
                viewModel.hasSavedDiagnosis = true;
            else
                viewModel.hasSavedDiagnosis = false;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hizmet_Tetkik_Giris)]
        public EpisodeActionFireRequestedProceduresResultInfo CreateActionForMyProcedureRequests(EpisodeActionRequestedProcedureInfo eaRequestedProcedureInfo)
        {
            EpisodeActionFireRequestedProceduresResultInfo resultInfo = new EpisodeActionFireRequestedProceduresResultInfo();
            var objectContext = new TTObjectContext(false);
            if (eaRequestedProcedureInfo == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26156", "İstekte bulunan parametre içeriği uygun değil"), new Exception("CreateActionForMyProcedureRequests methodunda eaRequestedProcedureInfo parametresi NULL!"));
            }
            var ea = objectContext.GetObject<EpisodeAction>(eaRequestedProcedureInfo.EpisodeActionObjectID);
            List<SubActionProcedure> createdSubActProcedures = new List<SubActionProcedure>();
            List<TTObjectClasses.EpisodeAction.RequestedProcedureRequestInfo> requestedProcedures = new List<TTObjectClasses.EpisodeAction.RequestedProcedureRequestInfo>();
            foreach (RequestedProcedureRequestInfo reqProcedureInfo in eaRequestedProcedureInfo.ProcedureRequestFormDetailDefinitions)
            {
                TTObjectClasses.EpisodeAction.RequestedProcedureRequestInfo reqProcInfo = new EpisodeAction.RequestedProcedureRequestInfo();
                reqProcInfo.ProcedureRequestFormDetailDefinition = (ProcedureRequestFormDetailDefinition)objectContext.GetObject(reqProcedureInfo.ProcedureRequestFormDetailDefinitionID, "ProcedureRequestFormDetailDefinition");
                reqProcInfo.RequestDate = reqProcedureInfo.RequestDate;
                reqProcInfo.ProcedureUserId = reqProcedureInfo.ProcedureUserId;
                reqProcInfo.RightLeftInformation = reqProcedureInfo.RightLeftInformation;
                reqProcInfo.ReasonForRepetition = reqProcedureInfo.ReasonForRepetition;
                requestedProcedures.Add(reqProcInfo);
            }

            List<TTObjectClasses.EpisodeAction.AdditionalApplicationRequestInfo> requestedAdditionalApplications = new List<TTObjectClasses.EpisodeAction.AdditionalApplicationRequestInfo>();
            foreach (AdditionalApplicationRequestInfo addApplication in eaRequestedProcedureInfo.ProcedureRequestAdditionalApplications)
            {
                if (addApplication.Amount > 50)
                    throw new Exception(TTUtils.CultureService.GetText("M25112", "Adet değeri 50 den büyük olamaz!"));
                else if (addApplication.Amount < 1)
                    throw new Exception(TTUtils.CultureService.GetText("M25111", "Adet değeri 1 den küçük olamaz!"));
                else
                {
                    TTObjectClasses.EpisodeAction.AdditionalApplicationRequestInfo addAppInfo = new TTObjectClasses.EpisodeAction.AdditionalApplicationRequestInfo();
                    addAppInfo.ProcedureObjectID = addApplication.ProcedureObjectID;
                    addAppInfo.Amount = addApplication.Amount;
                    addAppInfo.RequestDate = addApplication.RequestDate;
                    addAppInfo.ProcedureUserId = addApplication.ProcedureUserId;
                    addAppInfo.Description = addApplication.Description;
                    addAppInfo.MedulaReportNo = addApplication.MedulaReportNo;
                    addAppInfo.ReportApplicationArea = addApplication.ReportApplicationArea;
                    addAppInfo.RightLeftInformation = addApplication.RightLeftInformation;
                    // Ek Uygulama detay Formları için
                    if (addApplication.BaseAdditionalInfoFormViewModels != null)
                    {
                        foreach (BaseAdditionalInfoFormViewModel baseAdditionalInfoFormViewModel in addApplication.BaseAdditionalInfoFormViewModels)
                        {
                            var baseAdditionalInfoForm = baseAdditionalInfoFormViewModel.AddViewModelToContext(ea.ObjectContext);
                            addAppInfo.BaseAdditionalInfos.Add(baseAdditionalInfoForm);
                        }
                    }

                    requestedAdditionalApplications.Add(addAppInfo);

                }
            }

            List<TTObjectClasses.EpisodeAction.RequestedBloodBankProcedureInfo> requestedBloodProductsList = new List<EpisodeAction.RequestedBloodBankProcedureInfo>();
            foreach (vmRequestedBloodBankProcedureInfo bloodProduct in eaRequestedProcedureInfo.RequestedBloodProducts)
            {
                TTObjectClasses.EpisodeAction.RequestedBloodBankProcedureInfo requestedBloodProduct = new EpisodeAction.RequestedBloodBankProcedureInfo();
                requestedBloodProduct.procedureRequestFormDetailDefinitionID = bloodProduct.procedureRequestFormDetailDefinitionID;
                requestedBloodProduct.externalSystemBloodProductID = bloodProduct.externalSystemBloodProductID;
                requestedBloodProduct.procedureDefinitionID = bloodProduct.procedureDefinitionID;
                requestedBloodProductsList.Add(requestedBloodProduct);
            }

            createdSubActProcedures = ea.ProcessMyProcedureRequests(requestedProcedures, requestedAdditionalApplications, requestedBloodProductsList, eaRequestedProcedureInfo.Emergency);

            //Sut Validation
            EpisodeAction.SUTRuleResult sutRuleResult = new EpisodeAction.SUTRuleResult();
            resultInfo.SutRuleResult.validateSutRules = true;
            //Kullanıcı SUT kurallarını dikkate almayıp devam et secenegını sectıyse, Kural motoruna gıdılmeyecek.
            if (eaRequestedProcedureInfo.ignoreSUTRules == false)
            {
                sutRuleResult = this.ValidateSutRules(ea.Episode, createdSubActProcedures);
            }
            else
            {
                sutRuleResult.validateSutRules = true;
            }

            if (sutRuleResult.validateSutRules == false)
            {
                resultInfo.SutRuleResult.validateSutRules = false;
                resultInfo.SutRuleResult.SUTRuleViolateMessages = sutRuleResult.SUTRuleViolateMessages;
                resultInfo.SutRuleResult.BlockRequest = sutRuleResult.BlockRequest;
            }
            else // Sut validation dan geçti ise diğer Valicadtionlar burada yapılır
            {
                //General Validation
                resultInfo.GeneralValidationMsg = string.Empty;
                foreach (SubActionProcedure sp in createdSubActProcedures)
                {
                    Boolean requiredDiagnosisContains = false;
                    var requiredDiagnosisCodeName = string.Empty;
                    foreach (var requiredDiagnoseProcedures in sp.ProcedureObject.RequiredDiagnoseProcedures)
                    {
                        if (requiredDiagnosisContains == true)
                            break;
                        if (requiredDiagnoseProcedures.DiagnosisDefinition != null)
                        {
                            requiredDiagnosisContains = eaRequestedProcedureInfo.DiagnosisObjectIdList.Contains(requiredDiagnoseProcedures.DiagnosisDefinition.ObjectID);
                            if (!string.IsNullOrEmpty(requiredDiagnosisCodeName))
                                requiredDiagnosisCodeName += "<br/>";
                            requiredDiagnosisCodeName += requiredDiagnoseProcedures.DiagnosisDefinition.Code;
                        }
                    }
                    if (!string.IsNullOrEmpty(requiredDiagnosisCodeName) && requiredDiagnosisContains == false) // Zorunlu tanısı varsa 
                    {
                        //SUTRuleViolateMessage violateMessage = new SUTRuleViolateMessage();
                        //violateMessage.ProcedureCode = sp.ProcedureObject.Code;
                        //violateMessage.Message = "Aşağıdaki tanılardan en az birinin girişi yapılmalı.\n" + requiredDiagnosisCodeName;
                        //resultInfo.SutRuleResult.SUTRuleViolateMessages.Add(violateMessage);
                        //resultInfo.SutRuleResult.validateSutRules = false;
                        resultInfo.GeneralValidationMsg += sp.ProcedureObject.Code + "-" + sp.ProcedureObject.Name + " İstemi Yapabilmek İçin Aşağıdaki tanılardan en az birinin girişi yapılmalı.<br/>" + requiredDiagnosisCodeName;


                    }
                    // Tanı Kontrolü
                }
            }
            if (resultInfo.SutRuleResult.validateSutRules == true && string.IsNullOrEmpty(resultInfo.GeneralValidationMsg))
            {
                objectContext.Save();
                List<FiredProcedureRequestInfo> firedProcedureRequestList = new List<FiredProcedureRequestInfo>();
                foreach (SubActionProcedure sp in createdSubActProcedures)
                {
                    FiredProcedureRequestInfo procedureInfo = new FiredProcedureRequestInfo();
                    procedureInfo.SubActionProcedureObjectID = sp.ObjectID;
                    procedureInfo.ProcedureObjectDefinitionID = sp.ProcedureObject.ObjectDef.ID;
                    procedureInfo.ProcedureObjectID = sp.ProcedureObject.ObjectID;
                    procedureInfo.EpisodeActionObjectID = sp.EpisodeAction.ObjectID;
                    procedureInfo.isDescriptionNeeded = sp.ProcedureObject.IsDescriptionNeeded == null ? false : Convert.ToBoolean(sp.ProcedureObject.IsDescriptionNeeded);


                    if (sp.ProcedureObject is RadiologyTestDefinition)
                    {
                        if (((RadiologyTestDefinition)sp.ProcedureObject).TestType != null)
                            procedureInfo.TestTypeName = ((RadiologyTestDefinition)sp.ProcedureObject).TestType.Name;
                    }

                    firedProcedureRequestList.Add(procedureInfo);
                }

                //resultInfo.SutRuleResult.validateSutRules = true;
                resultInfo.FiredProcedureRequestInfoList = firedProcedureRequestList;
            }

            //if (ea.ActionType==ActionTypeEnum.PatientExamination)
            //{
            //    var labreqList = ea.SubactionProcedures[0].SubEpisode.EpisodeActions.Where(c => c.ActionType == ActionTypeEnum.LaboratoryRequest && (c as LaboratoryRequest).MasterAction == ea);
            //    //var labreq = labreqList.Where(x => (x as LaboratoryRequest).MasterAction == patientExamination);
            //    foreach (var labre in labreqList)
            //    {
            //        var dfd = labre.SubactionProcedures.Where(c => c.ProcedureObject.Code == "901260").FirstOrDefault();
            //    }
            //}

            return resultInfo;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Muayenesi_Muayene)]
        public Guid TakeInpatientObservation(EmergencyIntervention emergencyIntervention)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                emergencyIntervention = objectContext.GetObject(emergencyIntervention.ObjectID, typeof(EmergencyIntervention)) as EmergencyIntervention;
                EmergencyIntervention.TakeInpatientObservation(emergencyIntervention);
                objectContext.Save();
                if (emergencyIntervention.InPatientPhysicianApplications.Count > 0)
                    return emergencyIntervention.InPatientPhysicianApplications[0].ObjectID;
                throw new Exception("Müşahadeye alınırken Klinik Doktor İşlemleri oluşturulamadı.");
            }
        }

        //[HttpPost]
        //[AtlasRequiredRoles(TTRoleNames.Hasta_Muayenesi_Muayene)]
        //public void TakeInpatientObservation(EmergencyIntervention emergencyIntervention)
        //{
        //    using (var objectContext = new TTObjectContext(false))
        //    {
        //        emergencyIntervention = objectContext.GetObject(emergencyIntervention.ObjectID, typeof(EmergencyIntervention)) as EmergencyIntervention;
        //        EmergencyIntervention.TakeInpatientObservation(emergencyIntervention);
        //        objectContext.Save();
        //    }
        //}

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.E_Nabiz_Hasta_Bilgisi_Goruntuleme)]
        public ENabizButtonResponseModel ShowPatientENabizInfo(Guid episodeActionObjectID, Guid patientObjectID, Guid? subactionProcedureID = null) //Servisten dönen key ile hastanın enabiz sayfası açılır.
        {
            var objectContext = new TTObjectContext(false);
            ENabizButtonResponseModel result = new ENabizButtonResponseModel();
            long patientTC = 0, doctorTC = 0;
            Guid? selectedPatientID = patientObjectID;
            if (selectedPatientID.HasValue)
            {
                Patient patient = objectContext.GetObject<Patient>(selectedPatientID.Value);
                if (patient.UniqueRefNo != null)
                    patientTC = Convert.ToInt64(patient.UniqueRefNo);
            }

            if (Common.CurrentResource != null)
                doctorTC = Convert.ToInt64(Common.CurrentResource.Person.UniqueRefNo);
            else
            {
                if (subactionProcedureID.HasValue)
                {
                    SubActionProcedure subActionProcedure = objectContext.GetObject<SubActionProcedure>(subactionProcedureID.Value);
                    if (subActionProcedure.ProcedureDoctor != null)
                        doctorTC = Convert.ToInt64(subActionProcedure.ProcedureDoctor.Person.UniqueRefNo);
                }
                else
                {
                    Guid? selectedEpisodeActionID = episodeActionObjectID;
                    if (selectedEpisodeActionID.HasValue)
                    {
                        EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                        if (episodeAction.ProcedureDoctor != null)
                            doctorTC = Convert.ToInt64(episodeAction.ProcedureDoctor.Person.UniqueRefNo);
                    }
                }
            }

            if (patientTC == 0)
                throw new Exception(TTUtils.CultureService.GetText("M25801", "Hasta TC Kimlik No Bulunamadı."));
            if (doctorTC == 0)
                throw new Exception(TTUtils.CultureService.GetText("M25525", "Doktor TC Kimlik No Bulunamadı."));

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string username = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string applicationcode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");

            client.DefaultRequestHeaders.Add("KullaniciAdi", username);
            client.DefaultRequestHeaders.Add("Sifre", password);
            client.DefaultRequestHeaders.Add("UygulamaKodu", applicationcode);

            HttpResponseMessage message = client.GetAsync("http://xxxxxx.com/api/EnabizDoktorErisim/GetToken?HastaTc=" + patientTC + "&HekimTc=" + doctorTC).Result;

            if (message.IsSuccessStatusCode)
            {
                string rresult = message.Content.ReadAsStringAsync().Result;
                DoktorErisimResponse response = JsonConvert.DeserializeObject<DoktorErisimResponse>(rresult);
                if (response.Durum == 1)
                {
                    result.isResponseSuccess = true;
                    result.responseLink = response.Sonuc;
                }
                else
                {
                    result.isResponseSuccess = false;
                    result.responseMessage = response.Mesaj;
                }


            }

            //Eski Servis Kapatıldı
            //NabizHBYSServis.DoktorErisimTalep input = new NabizHBYSServis.DoktorErisimTalep();
            //SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
            //if (myTesisSKRSKurumlarDefinition != null)
            //    input.KURUM_KODU = myTesisSKRSKurumlarDefinition.KODU.ToString(); //İşlemin yapıldığı kurum veya birim ÇKYS kodu alanıdır.
            //else
            //    throw new Exception("Kurum Kodu Bulunamadı.");
            //input.HASTA_KIMLIK_NUMARASI = patientTC;
            //input.HEKIM_KIMLIK_NUMARASI = doctorTC;
            //Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            //NabizHBYSServis.DoktorErisimCevap output = NabizHBYSServis.WebMethods.DoktorEHRErisimiSync(Sites.SiteLocalHost, input);
            //if (output.IslemBasarisi)
            //    result = output.AccessKey;
            //else
            //    throw new Exception(output.ServisMesaji);



            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Muayenesi_Muayene)]
        public SpecialityDefinition[] getMinorSpecialities()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<SpecialityDefinition> minorSpecialities = new BindingList<SpecialityDefinition>();
                minorSpecialities = SpecialityDefinition.GetMinorSpecialities(objectContext);
                return minorSpecialities.ToArray();
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Muayenesi_Muayene)]
        public bool searchAddAproveMHRSGreenList(Guid episodeActionObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction episodeAction = objectContext.GetObject(episodeActionObjectID, typeof(EpisodeAction)) as EpisodeAction;
                int MHRSCode;
                if (!(episodeAction is PatientExamination || episodeAction is DentalExamination || episodeAction is Consultation))
                    throw new Exception("MHRS Yeşil Listeye sadece muayene üzerinden bildirim yapılabilir!");
                if (!(episodeAction.MasterResource is ResPoliclinic))
                    throw new Exception("MHRS Yeşil Liste işlemleri sadece Poliklinik kaynaklı muayenelerde yapılabilir!");
                else
                    MHRSCode = Convert.ToInt32(((ResPoliclinic)episodeAction.MasterResource).MHRSCode);
                if (TTObjectClasses.SystemParameter.GetParameterValue("MHRSYEBILDIR", "FALSE").ToUpper() == "TRUE")
                {
                    try
                    {
                        string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
                        string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
                        string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
                        string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");
                        MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                        MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
                        MHRSServis.YesilListeVatandasSorgulamaTalepType yesilListeVatandasSorgulama = new MHRSServis.YesilListeVatandasSorgulamaTalepType();
                        MHRSServis.YesilListeVatandasSorgulamaCevapType yesilListeVatandasSorgulamaCevap = new MHRSServis.YesilListeVatandasSorgulamaCevapType();
                        if (userName != null && password != null && MHRSKurumKodu != null)
                        {
                            yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                            yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                            yetkilendirmeGirisBilgileri.KulaniciTuru = 2;
                            yesilListeVatandasSorgulama.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                            kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(episodeAction.ProcedureDoctor.UniqueNo);
                            kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                            kurumBilgileri.KurumKoduSpecified = true;
                            kurumBilgileri.GonderenBirim = MHRSFirmaKodu;
                            yesilListeVatandasSorgulama.KurumBilgileri = kurumBilgileri;
                            yesilListeVatandasSorgulama.TCKimlikNo = episodeAction.Episode.Patient.UniqueRefNo.ToString();
                            yesilListeVatandasSorgulama.KlinikKodu = MHRSCode;
                            yesilListeVatandasSorgulama.KlinikKoduSpecified = true;
                            yesilListeVatandasSorgulamaCevap = MHRSServis.WebMethods.YesilListeVatandasSorgulamaSync(Sites.SiteLocalHost, yesilListeVatandasSorgulama);
                            if (yesilListeVatandasSorgulamaCevap != null && yesilListeVatandasSorgulamaCevap.TemelCevapBilgileri != null)
                            {
                                if (yesilListeVatandasSorgulamaCevap.TemelCevapBilgileri.ServisBasarisi == true)
                                {
                                    if (yesilListeVatandasSorgulamaCevap.YesilListeBilgileri == null || yesilListeVatandasSorgulamaCevap.YesilListeBilgileri.Length == 0)
                                    {
                                        bool result = this.addMHRSGreenList(MHRSCode, episodeAction.ObjectID);
                                        if (result)
                                        {
                                            bool result2 = this.aproveMHRSGreenList(MHRSCode, episodeAction.ObjectID);
                                            if (result2)
                                                return true;
                                            else
                                                return false;
                                        }
                                        else
                                            return false;
                                    }
                                    else
                                    {
                                        bool added = false;
                                        bool approved = false;
                                        foreach (MHRSServis.YesilListeBilgileriType yesilListeBilgi in yesilListeVatandasSorgulamaCevap.YesilListeBilgileri)
                                        {
                                            if (yesilListeBilgi.KlinikKodu == MHRSCode)
                                            {
                                                added = true;
                                                if (yesilListeBilgi.OnayDurumu == 1)
                                                    approved = true;
                                                else
                                                    approved = false;
                                                break;
                                            }
                                            else
                                                added = false;
                                        }

                                        if (!added)
                                        {
                                            bool result = this.addMHRSGreenList(MHRSCode, episodeAction.ObjectID);
                                            if (result)
                                            {
                                                bool result2 = this.aproveMHRSGreenList(MHRSCode, episodeAction.ObjectID);
                                                if (result2)
                                                    return true;
                                                else
                                                    return false;
                                            }
                                            else
                                                return false;
                                        }
                                        else if (added && !approved)
                                        {
                                            bool result = this.aproveMHRSGreenList(MHRSCode, episodeAction.ObjectID);
                                            return true;
                                        }
                                        else if (added && approved)
                                            return true;
                                        else
                                            return false;
                                    }
                                }
                                else
                                    throw new Exception("MHRS Bildirim Hatası: " + yesilListeVatandasSorgulamaCevap.TemelCevapBilgileri.Aciklama);
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                else
                    throw new Exception(TTUtils.CultureService.GetText("M25816", "XXXXXX MHRS bildirim kapalı!"));
            }
        }

        private bool aproveMHRSGreenList(int MHRSCode, Guid episodeActionObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction episodeAction = objectContext.GetObject(episodeActionObjectID, typeof(EpisodeAction)) as EpisodeAction;

                if (!(episodeAction is PatientExamination || episodeAction is DentalExamination))
                    throw new Exception("MHRS Yeşil Listeye sadece muayene üzerinden bildirim yapılabilir!");
                if (TTObjectClasses.SystemParameter.GetParameterValue("MHRSYEBILDIR", "FALSE").ToUpper() == "TRUE")
                {
                    try
                    {
                        string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
                        string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
                        string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
                        string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");
                        MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                        MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
                        MHRSServis.YesilListeVatandasEklemeTalepType yesilListeVatandasEkleme = new MHRSServis.YesilListeVatandasEklemeTalepType();
                        MHRSServis.YesilListeVatandasEklemeCevapType yesilListeVatandasEklemeCevap = new MHRSServis.YesilListeVatandasEklemeCevapType();
                        if (userName != null && password != null && MHRSKurumKodu != null)
                        {
                            yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                            yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                            yetkilendirmeGirisBilgileri.KulaniciTuru = 2;
                            yesilListeVatandasEkleme.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                            kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(episodeAction.ProcedureDoctor.UniqueNo);
                            kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                            kurumBilgileri.KurumKoduSpecified = true;
                            kurumBilgileri.GonderenBirim = MHRSFirmaKodu;
                            yesilListeVatandasEkleme.KurumBilgileri = kurumBilgileri;
                            yesilListeVatandasEkleme.TCKimlikNo = episodeAction.Episode.Patient.UniqueRefNo.ToString();
                            yesilListeVatandasEkleme.KlinikKodu = MHRSCode;
                            yesilListeVatandasEklemeCevap = MHRSServis.WebMethods.YesilListeVatandasEklemeSync(Sites.SiteLocalHost, yesilListeVatandasEkleme);
                            if (yesilListeVatandasEklemeCevap != null && yesilListeVatandasEklemeCevap.TemelCevapBilgileri != null)
                            {
                                if (yesilListeVatandasEklemeCevap.TemelCevapBilgileri.ServisBasarisi == true)
                                {
                                    //InfoBox.Alert(" Hasta Yeşil Listeye eklendi!");
                                    return true;
                                }
                                else
                                    throw new Exception("MHRS Bildirim Hatası : " + yesilListeVatandasEklemeCevap.TemelCevapBilgileri.Aciklama + " Hasta Yeşil Listeye eklenemedi! Muayeneyi tekrar kaydederek işlemi tekrar edebilirsiniz ! ");
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        // InfoBox.Alert(ex);
                        throw;
                    }
                }
                else
                    throw new Exception(TTUtils.CultureService.GetText("M25818", "XXXXXX MHRS bildirimi yapamıyor!"));
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Muayenesi_Muayene)]
        public bool addMHRSGreenList(int MHRSCode, Guid episodeActionObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction episodeAction = objectContext.GetObject(episodeActionObjectID, typeof(EpisodeAction)) as EpisodeAction;

                if (!(episodeAction is PatientExamination || episodeAction is DentalExamination))
                    throw new Exception("MHRS Yeşil Listeye sadece muayene üzerinden bildirim yapılabilir!");

                if (TTObjectClasses.SystemParameter.GetParameterValue("MHRSYEBILDIR", "FALSE").ToUpper() == "TRUE")
                {
                    try
                    {
                        string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
                        string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
                        string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
                        string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");
                        MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                        MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
                        MHRSServis.YesilListeVatandasEklemeTalepType yesilListeVatandasEkleme = new MHRSServis.YesilListeVatandasEklemeTalepType();
                        MHRSServis.YesilListeVatandasEklemeCevapType yesilListeVatandasEklemeCevap = new MHRSServis.YesilListeVatandasEklemeCevapType();
                        if (userName != null && password != null && MHRSKurumKodu != null)
                        {
                            yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                            yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                            yetkilendirmeGirisBilgileri.KulaniciTuru = 2;
                            yesilListeVatandasEkleme.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                            kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(episodeAction.ProcedureDoctor.UniqueNo);
                            kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                            kurumBilgileri.KurumKoduSpecified = true;
                            kurumBilgileri.GonderenBirim = MHRSFirmaKodu;
                            yesilListeVatandasEkleme.KurumBilgileri = kurumBilgileri;
                            yesilListeVatandasEkleme.TCKimlikNo = episodeAction.Episode.Patient.UniqueRefNo.ToString();
                            yesilListeVatandasEkleme.KlinikKodu = MHRSCode;
                            yesilListeVatandasEklemeCevap = MHRSServis.WebMethods.YesilListeVatandasEklemeSync(Sites.SiteLocalHost, yesilListeVatandasEkleme);
                            if (yesilListeVatandasEklemeCevap != null && yesilListeVatandasEklemeCevap.TemelCevapBilgileri != null)
                            {
                                if (yesilListeVatandasEklemeCevap.TemelCevapBilgileri.ServisBasarisi == true)
                                {
                                    //InfoBox.Alert(" Hasta Yeşil Listeye eklendi!");
                                    return true;
                                }
                                else
                                    throw new Exception("MHRS Bildirim Hatası : " + yesilListeVatandasEklemeCevap.TemelCevapBilgileri.Aciklama + " Hasta Yeşil Listeye eklenemedi! Muayeneyi tekrar kaydederek işlemi tekrar edebilirsiniz ! ");
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        // InfoBox.Alert(ex);
                        throw;
                    }
                }
                else
                {
                    TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25817", "XXXXXX MHRS bildirime kapalı!"));
                    return false;
                }
            }
        }

       

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Muayenesi_Muayene)]
        public bool AddMHRSGreenList_New(Guid specialityDefinitionObjectID, Guid episodeActionObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction episodeAction = objectContext.GetObject(episodeActionObjectID, typeof(EpisodeAction)) as EpisodeAction;

                SpecialityDefinition speciality = objectContext.GetObject(specialityDefinitionObjectID, typeof(SpecialityDefinition)) as SpecialityDefinition;

                if (!(episodeAction is PatientExamination || episodeAction is DentalExamination))
                    throw new Exception("MHRS Yeşil Listeye sadece muayene üzerinden bildirim yapılabilir!");
               
                string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
                string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");

                if (TTObjectClasses.SystemParameter.GetParameterValue("MHRSYEBILDIR", "FALSE").ToUpper() == "TRUE")
                {
                    try
                    {
                        if (MHRSKurumKodu == null)
                        {
                            TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25817", "XXXXXX MHRS bildirime kapalı!"));
                            return false;
                        }
                        else
                        {

                            BindingList<DiagnosisGrid.GetDiagnosisBySubEpisode_Class> diagnosis = DiagnosisGrid.GetDiagnosisBySubEpisode(episodeAction.SubEpisode.ObjectID.ToString(), episodeAction.SubEpisode.Episode.ObjectID.ToString());
                            List<string> tanilar = new List<string>();

                            foreach (DiagnosisGrid.GetDiagnosisBySubEpisode_Class d in diagnosis)
                            {
                               
                                tanilar.Add(d.Code);
                            }

                            if(tanilar.Count == 0 )
                            {
                                TTUtils.InfoMessageService.Instance.ShowMessage("Tanı kaydedilmeden hasta yeşil listeye eklenemez.");
                                return false;
                            }

                            MHRS_YesilListeEkle_Input input = new MHRS_YesilListeEkle_Input();
                            input.eklenmeSuresi = 180;
                            input.hastaKimlikNo = Convert.ToInt64(episodeAction.Episode.Patient.UniqueRefNo);
                            input.hekimAciklama = "";
                            input.icdTanilar = tanilar; 
                            input.islemYapanHekimTcKimlikNo = Convert.ToInt64(episodeAction.ProcedureDoctor.UniqueNo);
                            input.islemYapanKlinikKodu = Convert.ToInt32(episodeAction.ProcedureDoctor.ResourceSpecialities[0].Speciality.SKRSKlinik.KODU);
                            input.islemYapilanKlinikKodu = Convert.ToInt32(speciality.SKRSKlinik.KODU);
                            input.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                            input.islemYapanTcKimlikNo = Convert.ToInt64(Common.CurrentResource.UniqueNo);
                           
                            string serializedObj = JsonConvert.SerializeObject(input);

                            Schedule schedule = new Schedule();
                            string accessToken = schedule.LoginForMHRS();

                            Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/hasta-yesil-liste");

                            var client = new RestClient(uri);

                            var request = new RestSharp.RestRequest();
                            request.Method = Method.POST;
                            request.Parameters.Clear();

                            string bearerToken = "Bearer " + accessToken;
                            request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
                            request.AddHeader("Accept", "application/json");
                            request.AddParameter("application/json", serializedObj, ParameterType.RequestBody);

                            //IRestResponse response = client.Execute(request);
                            IRestResponse response = schedule.PostCallForMHRS(client, request);
                            if (response != null && response.ResponseStatus == ResponseStatus.Completed && response.IsSuccessful == false)
                            {
                                var errorMessage = response.Content;
                                var errorObject = JsonConvert.DeserializeObject(response.Content) as JObject;
                                string detailedError = "";

                                if (errorObject != null)
                                {
                                    var error = errorObject.Value<JArray>("errors");

                                    foreach (Newtonsoft.Json.Linq.JObject item in error)
                                    {
                                        detailedError += item.ToString();
                                    }
                                   
                                }
                                throw new TTException(detailedError);

                            }

                            if (response.IsSuccessful)
                            {
                                return true;
                            }else
                                return false;
                        }
                    
                    }
                    catch (Exception ex)
                    {
                      
                        throw;
                    }
                }
                else
                {
                    TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25817", "XXXXXX MHRS bildirime kapalı!"));
                    return false;
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Muayenesi_Muayene)]
        public bool ApproveMHRSGreenList_New(Guid specialityDefinitionObjectID, Guid episodeActionObjectID)
        {
            bool flag = false;
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction episodeAction = objectContext.GetObject(episodeActionObjectID, typeof(EpisodeAction)) as EpisodeAction;

                SpecialityDefinition speciality = objectContext.GetObject(specialityDefinitionObjectID, typeof(SpecialityDefinition)) as SpecialityDefinition;

               

                string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
                string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");

               
                    try
                    {
                        
                        

                            BindingList<DiagnosisGrid.GetDiagnosisBySubEpisode_Class> diagnosis = DiagnosisGrid.GetDiagnosisBySubEpisode(episodeAction.SubEpisode.ObjectID.ToString(), episodeAction.SubEpisode.Episode.ObjectID.ToString());
                            List<string> tanilar = new List<string>();

                            foreach (DiagnosisGrid.GetDiagnosisBySubEpisode_Class d in diagnosis)
                            {

                                tanilar.Add(d.Code);
                            }

                            if (tanilar.Count == 0)
                            {
                                TTUtils.InfoMessageService.Instance.ShowMessage("Tanı kaydedilmeden hasta yeşil listeye eklenemez.");
                              
                            }

                            MHRS_YesilListeOnayla_Input input = new MHRS_YesilListeOnayla_Input();
                            input.hastaKimlikNo = Convert.ToInt64(episodeAction.Episode.Patient.UniqueRefNo);
                            input.hekimAciklama = "Onayla";
                            input.icdTanilar = tanilar;
                            input.islemYapanHekimTcKimlikNo = Convert.ToInt64(episodeAction.ProcedureDoctor.UniqueNo);
                            input.islemYapanKlinikKodu = Convert.ToInt32(episodeAction.ProcedureDoctor.ResourceSpecialities[0].Speciality.SKRSKlinik.KODU);
                            input.islemYapilanKlinikKodu = Convert.ToInt32(speciality.SKRSKlinik.KODU);
                            input.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                            input.islemYapanTcKimlikNo = Convert.ToInt64(Common.CurrentResource.UniqueNo);

                            string serializedObj = JsonConvert.SerializeObject(input);

                            Schedule schedule = new Schedule();
                            string accessToken = schedule.LoginForMHRS();

                            Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/hasta-yesil-liste/onayla");

                            var client = new RestClient(uri);

                            var request = new RestSharp.RestRequest();
                            request.Method = Method.PUT;
                            request.Parameters.Clear();

                            string bearerToken = "Bearer " + accessToken;
                            request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
                            request.AddHeader("Accept", "application/json");
                            request.AddParameter("application/json", serializedObj, ParameterType.RequestBody);

                            //IRestResponse response = client.Execute(request);
                            IRestResponse response = schedule.PostCallForMHRS(client, request);
                    if (response != null && response.ResponseStatus == ResponseStatus.Completed && response.IsSuccessful == false)
                            {
                                var errorMessage = response.Content;
                                var errorObject = JsonConvert.DeserializeObject(response.Content) as JObject;
                                string detailedError = "";

                                if (errorObject != null)
                                {
                                    var error = errorObject.Value<JArray>("errors");

                                    foreach (Newtonsoft.Json.Linq.JObject item in error)
                                    {
                                        detailedError += item.ToString();
                                    }

                                }
                                throw new TTException(detailedError);

                            }

                            if (response.IsSuccessful)
                            {
                                flag = true;
                            }
                           
                        

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                return flag;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Muayenesi_Muayene)]
        public MHRS_YesilListeSorgula_OutPut SearchMHRSGreenList_New(Guid specialityDefinitionObjectID, Guid episodeActionObjectID)
        {
            MHRS_YesilListeSorgula_OutPut output = new MHRS_YesilListeSorgula_OutPut();
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction episodeAction = objectContext.GetObject(episodeActionObjectID, typeof(EpisodeAction)) as EpisodeAction;

                SpecialityDefinition speciality = objectContext.GetObject(specialityDefinitionObjectID, typeof(SpecialityDefinition)) as SpecialityDefinition;

                if (!(episodeAction is PatientExamination || episodeAction is DentalExamination))
                    throw new Exception("MHRS Yeşil Listeye sadece muayene üzerinden bildirim yapılabilir!");

                string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
                string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");

                if (TTObjectClasses.SystemParameter.GetParameterValue("MHRSYEBILDIR", "FALSE").ToUpper() == "TRUE")
                {
                    try
                    {
                        if (MHRSKurumKodu == null)
                        {
                            TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25817", "XXXXXX MHRS bildirime kapalı!"));
                       
                        }
                        else
                        {


                            MHRS_YesilListeSorgula_Input input = new MHRS_YesilListeSorgula_Input();
                            input.klinikKodu = Convert.ToInt32(speciality.SKRSKlinik.KODU);
                            input.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                            input.islemYapanTcKimlikNo = Convert.ToInt64(Common.CurrentResource.UniqueNo);
                            input.hastaKimlikNo = Convert.ToInt64(episodeAction.Episode.Patient.UniqueRefNo);

                            string serializedObj = JsonConvert.SerializeObject(input);

                            Schedule schedule = new Schedule();
                            string accessToken = schedule.LoginForMHRS();

                            Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/hasta-yesil-liste/sorgula");

                            var client = new RestClient(uri);

                            var request = new RestSharp.RestRequest();
                            request.Method = Method.POST;
                            request.Parameters.Clear();

                            string bearerToken = "Bearer " + accessToken;
                            request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
                            request.AddHeader("Accept", "application/json");
                            request.AddParameter("application/json", serializedObj, ParameterType.RequestBody);

                            //IRestResponse response = client.Execute(request);
                            IRestResponse response = schedule.PostCallForMHRS(client, request);
                            if (response != null && response.ResponseStatus == ResponseStatus.Completed && response.IsSuccessful == false)
                            {
                                var errorMessage = response.Content;
                                var errorObject = JsonConvert.DeserializeObject(response.Content) as JObject;
                                string detailedError = "";

                                if (errorObject != null)
                                {
                                    var error = errorObject.Value<JArray>("errors");

                                    foreach (Newtonsoft.Json.Linq.JObject item in error)
                                    {
                                        detailedError += item.ToString();
                                    }

                                }
                                throw new TTException(detailedError);

                            }

                            if (response.IsSuccessful)
                            {
                                var result1 = JsonConvert.DeserializeObject<MHRS_YesilListeSorgula_Response>(response.Content);
                                output.result = "";
                                foreach(MHRS_YesilListeSorgula_Data data in result1.data)
                                {
                                    output.result += "\nKlinik Kodu: " + data.klinikKodu.ToString();
                                    output.result +="\nKlinik Adı: " + data.klinikAdi.ToString();
                                    output.result += "\nKayıt Zamanı: " + data.kayitZamani.ToString();
                                    output.result += "\nGeçerlilik Tarihi: " + data.gecerlilikTarihi.ToString();
                                    
                                    output.yesilListeDurum = data.lyesilListeDurum;
                                    if (data.lyesilListeDurum == 1)
                                        output.result += "\n Yeşil Liste Durum: Geçici Süre İle Eklendi";
                                    else if (data.lyesilListeDurum == 2)
                                        output.result += "\n Yeşil Liste Durum: Onaylandı";
                        
                                    else if (data.lyesilListeDurum == 3)
                                        output.result += "\n Yeşil Liste Durum: Silindi";

                                    

                                }
                           
                            }
                            
                        }

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
                else
                {
                    TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25817", "XXXXXX MHRS bildirime kapalı!"));
               
                }
            }

            return output;
        }



        partial void PreScript_PatientExaminationDoctorFormNew(PatientExaminationDoctorFormNewViewModel viewModel, PatientExamination patientExamination, TTObjectContext objectContext)
        {
            //Uzmanlık için
            viewModel.SetHasSpecialityBasedObject(patientExamination);
            patientExamination.SetProcedureDoctorAsCurrentResource();

            Patient _patient = patientExamination.Episode.Patient;
            //if (patientExamination.ProcedureSpeciality != null && patientExamination.ProcedureSpeciality.SpecialityBasedObjectType == SpecialityBasedObjectEnum.WomanSpecialityObject)
            //{
            //    viewModel.IsWomanSpecialityExam = true;

            //    if (_patient.UniqueRefNo != null)
            //        viewModel.HighRiskPregnancyMessage = HasHighRiskPregnancy(viewModel.IsWomanSpecialityExam);
            //}
            if (patientExamination.CurrentStateDefID == PatientExamination.States.Examination &&
                ((patientExamination.ProcedureSpeciality == null) || (patientExamination.ProcedureSpeciality != null && patientExamination.ProcedureSpeciality.SpecialityBasedObjectType != SpecialityBasedObjectEnum.WomanSpecialityObject)))
            {
                viewModel.IsWomanSpecialityExam = false;

                if (_patient.UniqueRefNo != null && _patient.Sex != null && _patient.Sex.KODU == "2" && _patient.Age != null && _patient.Age > 15 && _patient.Age < 49)
                {
                    try
                    {
                        Sonuc _sonuc = HasHighRiskPregnancy(viewModel.IsWomanSpecialityExam, _patient.UniqueRefNo);
                        viewModel.HighRiskPregnancyMessage = _sonuc == null ? "" : _sonuc.returnMessage;
                    }
                    catch (Exception)
                    {
                        //do nothing
                        viewModel.HighRiskPregnancyMessage = "";
                    }
                }
            }

            if (patientExamination.CurrentStateDefID == PatientExamination.States.Examination && Common.PersonelIzinKontrol(patientExamination.ProcedureDoctor.ObjectID.ToString(), patientExamination.RequestDate.Value, objectContext))
                patientExamination.ProcedureDoctor = null;

            #region fizyoterapi

            //Fizyoterapi İsteği Yapma Yetkisi Kontrolü
            viewModel.HasAuthorityForPhysiotherapyRequest = false;
            foreach (ResourceSpecialityGrid resourceSpecialityGrid in patientExamination.MasterResource.ResourceSpecialities)
            {
                if (resourceSpecialityGrid.Speciality.Code == "1800" || resourceSpecialityGrid.Speciality.Code == "2600")
                {
                    viewModel.HasAuthorityForPhysiotherapyRequest = true;
                    break;
                }
            }

            viewModel.IsPhysiotherapyRequestFormUsing = TTObjectClasses.SystemParameter.GetParameterValue("USEPHYSIOTHERAPYREQUESTFORM", "") == "TRUE" ? true : false;

            //Fizyoterapi İsteği Var Mı?
            foreach (var episodeaction in patientExamination.LinkedActions)
            {
                if (episodeaction is PhysiotherapyRequest)
                {
                    viewModel.StartPhysiotherapyRequest = true;
                    break;
                }
            }

            #endregion fizyoterapi

            if (patientExamination.CurrentStateDefID == PatientExamination.States.Completed)
                viewModel.IsExaminationCompleted = true;

            //Hastanın var olan Raporları
            viewModel.includeDrugDefinition = false;
            if (patientExamination.EmergencyIntervention != null || (TTObjectClasses.SystemParameter.GetParameterValue("PATIENTEXAMINATIONINCLUDEDRUGS", "FALSE") == "TRUE"))
                viewModel.includeDrugDefinition = true;
            if (TTObjectClasses.SystemParameter.GetParameterValue("DOKTORKARARDESTEK", "TRUE") == "TRUE" && patientExamination.MasterResource.HimssRequired == true)
                viewModel.physicianSuggestionsIsActive = true;
            else
                viewModel.physicianSuggestionsIsActive = false;

            viewModel.PatientReportInfoList = this.GetPatientReport(patientExamination.Episode.Patient.ObjectID, patientExamination.SubEpisode.ObjectID, false, true);

            viewModel.isENabizActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("ISNABIZACTIVE", "TRUE"));
            viewModel.anamnesisFormViewModel._PhysicianApplication = new PhysicianApplication();
            viewModel.anamnesisFormViewModel._PhysicianApplication = (PhysicianApplication)patientExamination;
            viewModel.anamnesisFormViewModel.vitalSingsViewModel = patientExamination.GetVitalSingsFormViewModel(objectContext);
            viewModel.anamnesisFormViewModel.PatientID = patientExamination.Episode.Patient.ObjectID;
            //viewModel.DispatchToOtherHospitalOfExamination = GetDispatchsForExamination(patientExamination.ObjectID);
            viewModel.IsPatientAdmissionEmergengy = patientExamination.PatientAdmission.IsEmergency;
            viewModel.IsIndustrialAccident = patientExamination.PatientAdmission.AdmissionType.provizyonTipiKodu == "I" ? true : false;
            ContextToViewModel(viewModel, objectContext);

            viewModel.NewGridTreatmentMaterialsGridList = viewModel._PatientExamination.Episode.SubActionMaterials.OfType<BaseTreatmentMaterial>().ToArray();

            //Foreach bloğu local query ile materialler çekilirken tüm materialler alınamadığı için oluşturuldu.
            foreach (var item in viewModel.NewGridTreatmentMaterialsGridList)
            {
                var a = item.Material;
            }
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();

            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalışmamalı
            // viewModel.GridTreatmentMaterialsGridList = viewModel.GridTreatmentMaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();

            viewModel.SubEpisodeList = new List<SubEpisode>();
            viewModel.EpisodeActionList = new List<EpisodeAction>();
            viewModel.NewGridTreatmentMaterialsGridList = viewModel.NewGridTreatmentMaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
            viewModel.NewGridTreatmentMaterialsGridList = viewModel.NewGridTreatmentMaterialsGridList.Where(material => viewModel.ControlTreatmentMaterialActions(material) == true).ToArray();

            if (patientExamination.ProcedureSpeciality != null)
                viewModel.IsAuthorizedToWriteTreatmentReport = EpisodeAction.IsAuthorizedToWriteTreatmentReport(patientExamination.ProcedureSpeciality);
            else
                viewModel.IsAuthorizedToWriteTreatmentReport = false;

            viewModel.baseHCEComponentInfo = GetDynamicComponentHCEBasedObjectInfo(patientExamination);

            viewModel.hasDoctorKotaRole = TTUser.CurrentUser.HasRole(TTRoleNames.Doktor_Kota_Tanimlama) ? true : false;
            viewModel.hasDoctorEAthleteRole = TTUser.CurrentUser.HasRole(TTRoleNames.E_Sporcu_Raporu_Yazma) ? true : false;
            viewModel.hasDoctorEDriverRole = TTUser.CurrentUser.HasRole(TTRoleNames.E_Surucu_Raporu_Yazma) ? true : false;
            viewModel.hasDoctorEPsychotecnicsRole = EpisodeActionServiceController.GetEPsychotecnicReportIndexAuthorization();
            viewModel.hasOrthesisRequestRole = TTUser.CurrentUser.HasRole(TTRoleNames.Ortez_Protez_Istek_RUW) ? true : false;
            viewModel.hasGiveAppointmentRole = TTUser.CurrentUser.HasRole(TTRoleNames.Randevu_Verme) ? true : false;
            viewModel.hasOpenEpisodeRole = TTUser.CurrentUser.HasRole(TTRoleNames.Kapali_Acik_Ek_Islemler) ? true : false;
            viewModel.hasCloseEpisodeRole = TTUser.CurrentUser.HasRole(TTRoleNames.Acik_Kapali_Ek_Islemler) ? true : false;

            viewModel.GreenAreaExaminationProcedureObjectId = ProcedureDefinition.GreenAreaExaminationProcedureObjectId;
            viewModel.EmergencyExaminationProcedureObjectId = ProcedureDefinition.EmergencyExaminationProcedureObjectId;
            viewModel.FormattedRequestDate = patientExamination.RequestDate.Value.ToString("dd.MM.yyyy HH:mm:ss");
               
            
            #region Tek Hekim Raporı mu
            viewModel.ISSinglePhysicianReport = false;
            if (viewModel._PatientExamination.PatientExaminationType == PatientExaminationEnum.HealthCommittee && viewModel._PatientExamination.HCExaminationComponent != null
                && viewModel._PatientExamination.HCExaminationComponent.ReasonForExamination != null && viewModel._PatientExamination.HCExaminationComponent.ReasonForExamination.HCReportTypeDefinition != null
                && viewModel._PatientExamination.HCExaminationComponent.ReasonForExamination.HCReportTypeDefinition.SinglePhysicianReport != null
                && viewModel._PatientExamination.HCExaminationComponent.ReasonForExamination.HCReportTypeDefinition.SinglePhysicianReport.Value)
            {
                viewModel.ISSinglePhysicianReport = true;
            }
            #endregion


            //ContextToViewModel den sonra çağırılmalı //TANI için
            viewModel.GridEpisodeDiagnosisGridList = patientExamination.DiagnosisGrid_PreScript();
            viewModel.SubepisodeID = viewModel._PatientExamination.SubEpisode.ObjectID.ToString();
            if (Common.CurrentResource.TakesPerformanceScore == true)
            {
                viewModel.ProcedureDoctorObjectIDForOBS = Common.CurrentResource.ObjectID.ToString();

            }
            else
            {
                viewModel.ProcedureDoctorObjectIDForOBS = viewModel._PatientExamination.ProcedureDoctor.ObjectID.ToString();
            }

            //Ketem


            if (patientExamination != null
                && patientExamination.PatientAdmission != null
                && patientExamination.PatientAdmission.SEP != null
                && patientExamination.PatientAdmission.SEP.MedulaTedaviTipi != null
                && patientExamination.PatientAdmission.SEP.MedulaTedaviTipi.tedaviTipiKodu == "10")
            {
                viewModel.IsKetem = true;
            }
            else
                viewModel.IsKetem = false;

            if (patientExamination.Episode.Patient.Sex != null)
                viewModel.GenderCode = patientExamination.Episode.Patient.Sex.KODU;

            double limit = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("CLOSEEPISODELASTUPDATEDAYLIMIT", "10"));
            double templimit = (double)(-1 * limit);
            DateTime LimitLastUpdateDate = Convert.ToDateTime(Common.RecTime()).AddDays(templimit);

            if (patientExamination.RequestDate < LimitLastUpdateDate)
                viewModel.DayLimitExceeded = limit;
            else
                viewModel.DayLimitExceeded = 0;

            viewModel.HasPaidPayerTypeSEPExists = viewModel._PatientExamination.SubEpisode.HasPaidPayerTypeSEPExists;

            if (viewModel.HasPaidPayerTypeSEPExists == true)
            {
                SubEpisode subEpisode = viewModel._PatientExamination.Episode.SubEpisodes.Where(x => x.OldSubEpisode != null && x.OldSubEpisode == viewModel._PatientExamination.SubEpisode && x.InpatientStatus != null && x.InpatientStatus == InpatientStatusEnum.Discharged).LastOrDefault();
                if (subEpisode != null)
                {
                    viewModel.IsDischarged = true;
                }
                else
                    viewModel.IsDischarged = false;
            }

            //Hastada başlatılmış morg işlemi olup olmadığını tutmak için eklendi
            foreach (BaseAction action in viewModel._PatientExamination.LinkedActions)
            {
                if (action is Morgue && !action.IsCancelled)
                {
                    viewModel.HasMorgue = true;
                    break;
                }
            }
            SKRSCikisSekli[] CikisSekli = SKRSCikisSekli.GetSKRSCikisSekliByCode(objectContext).ToArray();
            if (CikisSekli.Length > 0)
                viewModel.DeathDefinition = CikisSekli[0];

            viewModel.isRadiologyAppointmentActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("RADIOLOGYAPPOINTMENTACTIVE", "FALSE"));

            viewModel.IsPcrRequested = false;


            if ((patientExamination as EpisodeAction).SubactionProcedures.Count() > 0)
            {
                var labreqList = (patientExamination as EpisodeAction).SubactionProcedures[0].SubEpisode.EpisodeActions.Where(c => c.ActionType == ActionTypeEnum.LaboratoryRequest && (c as LaboratoryRequest).MasterAction == patientExamination && c.CurrentStateDefID != LaboratoryRequest.States.Cancelled);
                foreach (var labre in labreqList)
                {
                    if (labre.SubactionProcedures.Where(c => c.ProcedureObject.Code == "901260").Count() > 0)
                    {
                        viewModel.IsPcrRequested = true;
                    }
                }
            }
            viewModel.isNewMHRS =  Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE"));
        }

        partial void PostScript_PatientExaminationDoctorFormNew(PatientExaminationDoctorFormNewViewModel viewModel, PatientExamination patientExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //TANI için
            patientExamination.DiagnosisGrid_PostScript(viewModel.GridEpisodeDiagnosisGridList);


            //uss servislerinden yüksek riskli bilgisi geldi ise veya yüksek riskli tanısı girildi ise
            if (patientExamination.Episode.Diagnosis.Any(x => x.Diagnose.HighRiskPregnancy == true) || !string.IsNullOrEmpty(viewModel.HighRiskPregnancyMessage))
            {
                if (patientExamination.Episode.Patient.MedicalInformation == null)
                    patientExamination.Episode.Patient.MedicalInformation = new MedicalInformation(objectContext);

                //patientExamination.Episode.Patient.MedicalInformation.Pregnancy = true;
                patientExamination.Episode.Patient.MedicalInformation.HighRiskPregnancy = true;
            }

            if (patientExamination.EmergencyIntervention == null)
            {
                patientExamination.SetVitalSingsFormViewModel(viewModel.anamnesisFormViewModel.vitalSingsViewModel);
                patientExamination.Complaint = viewModel.anamnesisFormViewModel._PhysicianApplication.Complaint;
                patientExamination.PatientHistory = viewModel.anamnesisFormViewModel._PhysicianApplication.PatientHistory;
                patientExamination.PhysicalExamination = viewModel.anamnesisFormViewModel._PhysicianApplication.PhysicalExamination;
                patientExamination.MTSConclusion = viewModel.anamnesisFormViewModel._PhysicianApplication.MTSConclusion;
            }
            else
            {
                if (transDef != null && PatientExamination.States.Examination == transDef.FromStateDefID)
                {
                    //Emergency Intervention doktoru da değişssin
                    patientExamination.EmergencyIntervention.ProcedureDoctor = patientExamination.ProcedureDoctor;
                    patientExamination.PatientAdmission.ProcedureDoctor = patientExamination.ProcedureDoctor;
                    #region işleme ait doktor değiştirme
                    //foreach (SubActionProcedure item in patientExamination.SubactionProcedures.Where(x => x.ProcedureObject.ObjectID == ProcedureDefinition.GreenAreaExaminationProcedureObjectId ||
                    //                    x.ProcedureObject.ObjectID == ProcedureDefinition.EmergencyExaminationProcedureObjectId || x.ProcedureObject.ObjectID == ProcedureDefinition.ExaminationProcedureObjectId))
                    //{
                    //    if (item.ProcedureDoctor != patientExamination.ProcedureDoctor)
                    //    {
                    //        item.ProcedureDoctor = patientExamination.ProcedureDoctor;
                    //    }
                    //}

                    //foreach (SubActionProcedure item in patientExamination.EmergencyIntervention.SubactionProcedures.Where(x => x.ProcedureObject.ObjectID == ProcedureDefinition.GreenAreaExaminationProcedureObjectId ||
                    //                    x.ProcedureObject.ObjectID == ProcedureDefinition.EmergencyExaminationProcedureObjectId || x.ProcedureObject.ObjectID == ProcedureDefinition.ExaminationProcedureObjectId))
                    //{
                    //    if (item.ProcedureDoctor != patientExamination.EmergencyIntervention.ProcedureDoctor)
                    //    {
                    //        item.ProcedureDoctor = patientExamination.ProcedureDoctor;
                    //    }
                    //}
                    #endregion
                }
                //else if (transDef == null && PatientExamination.States.Examination == patientExamination.CurrentStateDefID)
                //{

                //}

                CheckEmergencySubActionprocedureByTriage(patientExamination.EmergencyIntervention);
            }
            //if (viewModel.HCExaminationComponents != null && viewModel.HCExaminationComponents[0].Is != null)
            //{
            //    if (viewModel.Height != null)
            //    {
            //        Height height = null;
            //        if (viewModel._HCExaminationComponent.PatientExamination[0].Heights.Count == 0)
            //        {
            //            height = new Height(objectContext);
            //            height.EpisodeAction = viewModel._HCExaminationComponent.PatientExamination[0];
            //        }
            //        else
            //        {
            //            height = viewModel._HCExaminationComponent.PatientExamination[0].Heights[0];
            //        }

            //        height.Value = Convert.ToInt32(viewModel.Height);
            //        height.ExecutionDate = Common.RecTime();
            //    }

            //    if (viewModel.Weight != null)
            //    {
            //        Weight weight = null;
            //        if (viewModel._HCExaminationComponent.PatientExamination[0].Weights.Count == 0)
            //        {
            //            weight = new Weight(objectContext);
            //            weight.EpisodeAction = viewModel._HCExaminationComponent.PatientExamination[0];
            //        }
            //        else
            //        {
            //            weight = viewModel._HCExaminationComponent.PatientExamination[0].Weights[0];
            //        }

            //        weight.Value = Convert.ToInt32(viewModel.Weight);
            //        weight.ExecutionDate = Common.RecTime();
            //    }
            //}
            //Çıkış şekli değiştirildiyse morg işlemi iptal ediliyor. Methodun içinde dischargetype kontrol edildiği için tekrar eklenmedi
            if (viewModel._MorgueViewModel != null && viewModel._MorgueViewModel._Morgue != null)
            {
                viewModel._MorgueViewModel.AddMorgueViewModelToContext(objectContext, patientExamination);
            }

            if (viewModel.HasMorgue)
            {
                patientExamination.CheckAndCancelMorgue(patientExamination.TreatmentResult);
            }


        }

        public void CheckEmergencySubActionprocedureByTriage(EmergencyIntervention ei)
        {
            if (ei.HasMemberChanged("Triage"))//Yeşil alan muayene değişti ise cancel et
            {
                if ((ei.Triage != null && ei.Triage.KODU == "1") || (((TTObjectClasses.EmergencyIntervention)((((TTInstanceManagement.ITTObject)ei).Original))).Triage != null) &&
                    ((TTObjectClasses.EmergencyIntervention)((((TTInstanceManagement.ITTObject)ei).Original))).Triage.KODU == "1")
                {
                    foreach (var innerItem in ei.SubactionProcedures.Where(x => x.CurrentStateDefID != SubActionProcedure.States.Cancelled))
                    {
                        if (innerItem is EmergencyInterventionProcedure)
                        {
                            innerItem.ReasonOfCancel = "Triaj kod alanı değiştirildi.";
                            ((ITTObject)innerItem).Cancel();
                        }
                    }
                    ((EmergencyIntervention)ei).AddEmergencyInterventionProcedure();
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Muayenesi_Muayene)]
        public List<PatientReportInfo> GetPatientReport([FromQuery] Guid patientObjectID, Guid subepisodeObjectID, bool includedCancelledReports, bool currentActionReports)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<EpisodeAction> reportList = new BindingList<EpisodeAction>();
                if (includedCancelledReports) // İptal olmuş raporlar da gelsin
                    reportList = EpisodeAction.GetAllReportsOfPatientCancelled(objectContext, patientObjectID.ToString());
                else if (currentActionReports)//mevcut kabulün raporlarını getir
                    reportList = EpisodeAction.GetAllReportsOfSubEpisode(objectContext, subepisodeObjectID.ToString());
                else //hastanın raporlarını getir
                    reportList = EpisodeAction.GetAllReportsOfPatient(objectContext, patientObjectID.ToString());
                List<PatientReportInfo> patientReportInfoList = new List<PatientReportInfo>();
                if (reportList.Count > 0)
                {

                    foreach (EpisodeAction report in reportList)
                    {

                        PatientReportInfo patientReportInfo = new PatientReportInfo();
                        patientReportInfo.ObjectID = report.ObjectID;
                        patientReportInfo.ObjectDefName = report.ObjectDef.Name;
                        patientReportInfo.ID = report.ID.ToString();
                        patientReportInfo.MasterResource = report.MasterResource.Name;
                        patientReportInfo.ProcedureByUser = report.ProcedureByUser == null ? "" : report.ProcedureByUser.Name;

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
                            patientReportInfo.RequestReason = "İlaç Raporu";
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
                            patientReportInfo.RequestReason = "Tıbbi Malzeme Raporu";
                        }
                        if (patientReportInfo.CancelledReport)
                            patientReportInfo.ReportName += patientReportInfo.ReportName + " ( İPTAL EDİLDİ )";

                        patientReportInfoList.Add(patientReportInfo);
                    }
                }
                return patientReportInfoList;
            }
        }

        private EpisodeAction.SUTRuleResult ValidateSutRules(Episode episode, List<SubActionProcedure> subActionProcedureList)
        {
            return EpisodeAction.ValidateSutRules(episode, subActionProcedureList);
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Muayenesi_Muayene)]
        public ENabizDataSets[] CheckENabizForSave([FromQuery] Guid ExaminationObjectID)
        {
            List<ENabizDataSets> nabizList = new List<ENabizDataSets>();
            //Tedavi Tipi EVDE BAKIM HIZMETI(Kod:17) olan  ve daha önce evde bakım veri seti doldurulmamış hastalarda nabız ekranı açılmalı
            using (var objectContext = new TTObjectContext(false))
            {
                bool isENabizActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("ISNABIZACTIVE", "TRUE"));
                if (isENabizActive)
                {
                    PatientExamination patientExamination = objectContext.GetObject<PatientExamination>(ExaminationObjectID);
                    if (patientExamination != null
                        && patientExamination.PatientAdmission != null
                        && patientExamination.PatientAdmission.SEP != null
                        && patientExamination.PatientAdmission.SEP.MedulaTedaviTipi != null
                        && patientExamination.PatientAdmission.SEP.MedulaTedaviTipi.tedaviTipiKodu == "17")
                    {
                        ENabizDataSets dataset = new ENabizDataSets();
                        dataset.PackageID = 219;
                        dataset.PackageName = "Evde Sağlık Hizmeti İlk İzlem";
                        dataset.DiagnosisObjectID = Guid.Empty; // Bu veri setinin tanı ile ilişkisi olmadığı için
                        nabizList.Add(dataset);
                    }
                }
            }

            return nabizList.ToArray();
        }

        [HttpGet]
        public PhysiotherapyRequest StartPhysiotherapyRequest(Guid episodeActionId, Boolean IsRequestAcceptionByDoctor)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                //Fizyoterapi İsteği Başlatmak için  viewModel.StartPhysiotherapyRequest == true && 

                bool isPhysiotherapyRequest = false;

                EpisodeAction _masterEpisodeAction = objectContext.GetObject<EpisodeAction>(episodeActionId);

                if (_masterEpisodeAction.SubEpisode.IsInvoicedCompletely)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M25838", "Hastanın faturası kesilmiş olduğu için F.T.R. isteği başlatamazsınız!"));
                }

                if (!_masterEpisodeAction.SubEpisode.IsDiagnosisExists())
                {
                    string[] hataParamList = new string[] { "'F.T.R. İsteği'" };
                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(1128, hataParamList));
                }

                foreach (var episodeaction in _masterEpisodeAction.LinkedActions)
                {
                    if (episodeaction is PhysiotherapyRequest)
                    {
                        if (((PhysiotherapyRequest)episodeaction).CurrentStateDefID == PhysiotherapyRequest.States.RequestAcceptionByDoctor)
                        {

                            isPhysiotherapyRequest = true;
                            PhysiotherapyRequest _physiotherapyRequest = objectContext.GetObject<PhysiotherapyRequest>(episodeaction.ObjectID);
                            objectContext.FullPartialllyLoadedObjects();
                            return _physiotherapyRequest;
                        }
                        else if (((PhysiotherapyRequest)episodeaction).CurrentStateDefID != PhysiotherapyRequest.States.RequestAcceptionByDoctor && ((PhysiotherapyRequest)episodeaction).CurrentStateDefID != PhysiotherapyRequest.States.Cancelled)
                        {
                            throw new Exception(TTUtils.CultureService.GetText("M25427", "Devam eden F.T.R. olduğu için yenisini başlatamazsınız!"));
                        }
                    }

                }

                if (isPhysiotherapyRequest != true)
                {
                    try
                    {
                        PhysiotherapyRequest physiotherapyRequest = new PhysiotherapyRequest(objectContext, _masterEpisodeAction);
                        physiotherapyRequest.PhysiotherapyRequestDate = DateTime.Now;
                        if (IsRequestAcceptionByDoctor == true)
                        {
                            physiotherapyRequest.CurrentStateDefID = PhysiotherapyRequest.States.RequestAcceptionByDoctor;
                        }
                        else
                        {
                            physiotherapyRequest.CurrentStateDefID = PhysiotherapyRequest.States.RequestAcception;
                        }
                        objectContext.Save();
                        //PhysiotherapyRequest request = objectContext.GetObject<PhysiotherapyRequest>(physiotherapyRequest.ObjectID);
                        return physiotherapyRequest;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    return null;
                }

            }

        }


        [HttpGet]
        public Guid GetPhysiotherapyTreatmentNote(Guid episodeActionId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction _masterEpisodeAction = objectContext.GetObject<EpisodeAction>(episodeActionId);

                foreach (var episodeaction in _masterEpisodeAction.LinkedActions)
                {
                    if (episodeaction is PhysiotherapyRequest)
                    {
                        if (((PhysiotherapyRequest)episodeaction).CurrentStateDefID != PhysiotherapyRequest.States.RequestAcceptionByDoctor && ((PhysiotherapyRequest)episodeaction).CurrentStateDefID != PhysiotherapyRequest.States.Cancelled)
                        {
                            return episodeaction.ObjectID;
                        }
                    }

                }

                throw new Exception("Hastanın F.T.R. tedavi seyri bulunamamıştır!");

            }
        }

        [HttpGet]
        public void setPatientNoShown(Guid episodeActionId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    EpisodeAction _episodeAction = objectContext.GetObject<EpisodeAction>(episodeActionId);
                    _episodeAction.SetPatientNoShown();
                    objectContext.Save();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        [HttpGet]
        public void undoCompletedExamination(Guid episodeActionId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    PatientExamination _patientExamination = objectContext.GetObject<PatientExamination>(episodeActionId);
                    if (_patientExamination.CurrentStateDefID != PatientExamination.States.Completed)
                        throw new Exception("'Tamamlandı' adımında olmayan işlem geri alınamaz.");
                    DateTime completeLimitLastUpdateDate = Convert.ToDateTime(Common.RecTime()).AddDays(-10).Date;
                    if (_patientExamination.RequestDate.Value.Date < completeLimitLastUpdateDate)
                        throw new TTUtils.TTException("İstek tarihi üzerinden 10 gün geçmiş muayeneler geri alınamaz.");
                    ((ITTObject)_patientExamination).UndoLastTransition();
                    objectContext.Save();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        //public PhysiotherapyRequest CancelPhysiotherapyRequest(PatientExaminationDoctorFormNewViewModel viewModel)
        //{
        //    using (var objectContext = new TTObjectContext(false))
        //    {
        //        //Fizyoterapi İsteği İptal Etme
        //        if (viewModel.HasAuthorityForPhysiotherapyRequest == true)
        //        {
        //            bool isPhysiotherapyRequest = false;

        //            foreach (var episodeaction in viewModel._PatientExamination.LinkedActions)
        //            {
        //                if (episodeaction is PhysiotherapyRequest)
        //                {
        //                    if (((PhysiotherapyRequest)episodeaction).CurrentStateDefID == PhysiotherapyRequest.States.Cancelled)
        //                    {
        //                        isPhysiotherapyRequest = false;
        //                    }
        //                    else if (((PhysiotherapyRequest)episodeaction).CurrentStateDefID == PhysiotherapyRequest.States.RequestAcceptionByDoctor || ((PhysiotherapyRequest)episodeaction).CurrentStateDefID == PhysiotherapyRequest.States.RequestAcception)
        //                    {

        //                        isPhysiotherapyRequest = true;
        //                        return (PhysiotherapyRequest)episodeaction;
        //                        //break;
        //                    }
        //                    else
        //                    {
        //                        throw new Exception("Devam eden fizyoterapi olduğu için yenisini başlatamazsınız!");
        //                    }
        //                }

        //            }

        //            if (isPhysiotherapyRequest != true)
        //            {
        //                try
        //                {
        //                    PhysiotherapyRequest physiotherapyRequest = new PhysiotherapyRequest(objectContext, viewModel._PatientExamination);
        //                    physiotherapyRequest.PhysiotherapyRequestDate = DateTime.Now;
        //                    objectContext.Save();

        //                    return physiotherapyRequest;
        //                }
        //                catch (Exception)
        //                {
        //                    throw;
        //                }
        //            }
        //            else
        //            {
        //                return null;
        //            }
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }

        //}

        #region SAĞLIK KURULU EK ALANLAR
        [HttpGet]
        public DynamicComponentInfoDVO GetDynamicComponentHCEBasedObjectInfo(PatientExamination patientExamination) //Uzmanlık için
        {
            DynamicComponentInfoDVO dynamicComponentInfo = null;

            if (patientExamination.BaseHCEDynamics.Count > 0)
            {
                dynamicComponentInfo = new DynamicComponentInfoDVO();

                BaseHCExaminationDynamicObject baseHCExaminationDynamicObject = patientExamination.BaseHCEDynamics[0];
                var subFolders = Common.GetParentFolders(baseHCExaminationDynamicObject.ObjectDef.ModuleDef);
                var folderPath = string.Empty;
                var moduleName = string.Empty;
                if (baseHCExaminationDynamicObject is LowerExtremity)
                {
                    folderPath = "Tibbi_Surec/Saglik_Kurulu_Modulu";
                    moduleName = "SaglikKuruluModule"; //obj.ObjectDef.ModuleDef.Name.GetTsModuleName();             
                    dynamicComponentInfo.ComponentName = "LowerExtremityForm"; // obj.CurrentStateDef.FormDef.CodeName;
                }
                else if (baseHCExaminationDynamicObject is UpperExtremity)
                {
                    folderPath = "Tibbi_Surec/Saglik_Kurulu_Modulu";
                    moduleName = "SaglikKuruluModule"; //obj.ObjectDef.ModuleDef.Name.GetTsModuleName();             
                    dynamicComponentInfo.ComponentName = "UpperExtremityForm"; // obj.CurrentStateDef.FormDef.CodeName;
                }


                if (!string.IsNullOrEmpty(folderPath))
                {
                    var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
                    dynamicComponentInfo.ModuleName = moduleName;
                    dynamicComponentInfo.ModulePath = modulePath;
                    dynamicComponentInfo.objectID = baseHCExaminationDynamicObject.ObjectID.ToString();
                    //patientExamination.ObjectContext.FullPartialllyLoadedObjects();
                }
            }

            return dynamicComponentInfo;
        }
        #endregion

        [HttpPost]
        public bool ChangeProvisionType(ChangeProvisionTypeClass changeProvisionTypeClass)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                SubEpisode subEpisode = objectContext.GetObject<SubEpisode>(new Guid(changeProvisionTypeClass.SubepisodeID));

                SubEpisodeProtocol subEpisodeProtocol = subEpisode.SGKSEP == null ? subEpisode.LastActiveSubEpisodeProtocol : subEpisode.SGKSEP;
                Invoice.InvoiceTopMenuApiController ınvoiceTopMenuApiController = new Invoice.InvoiceTopMenuApiController();

                try
                {
                    MedulaResult medulaResult = null;
                    if (!string.IsNullOrEmpty(subEpisodeProtocol.MedulaTakipNo))
                    {
                        medulaResult = ınvoiceTopMenuApiController.takipSil(subEpisodeProtocol.ObjectID);
                    }

                    if (medulaResult != null && medulaResult.Succes == false)//medulatakipno yoksa vrya hata alındı ise
                    {
                        throw new Exception(medulaResult.SonucKodu + " " + medulaResult.SonucMesaji);
                    }
                    else if (medulaResult == null || medulaResult.Succes != false)//medula takip no null ise veya üstte başarılı şekilde silindi ise
                    {
                        subEpisodeProtocol.MedulaProvizyonTipi = (ProvizyonTipi)changeProvisionTypeClass.AdmissionType;
                        subEpisodeProtocol.MedulaIstisnaiHal = changeProvisionTypeClass.MedulaIstisnaiHal;
                        subEpisodeProtocol.MedulaVakaTarihi = changeProvisionTypeClass.MedulaVakaTarihi;
                        subEpisode.PatientAdmission.Sevkli112 = changeProvisionTypeClass.Sevkli112;
                        subEpisode.PatientAdmission.Emergency112RefNo = changeProvisionTypeClass.Emergency112RefNo;
                        subEpisode.PatientAdmission.AdmissionType = (ProvizyonTipi)changeProvisionTypeClass.AdmissionType;

                        if (changeProvisionTypeClass.AdmissionType != null && changeProvisionTypeClass.AdmissionType.provizyonTipiKodu != null)
                        {
                            if (changeProvisionTypeClass.AdmissionType.provizyonTipiKodu != "S")
                            {
                                subEpisodeProtocol.MedulaIstisnaiHal = null;
                                subEpisode.PatientAdmission.MedulaIstisnaiHal = null;
                            }
                            if (changeProvisionTypeClass.AdmissionType.provizyonTipiKodu != "T")
                            {
                                subEpisodeProtocol.MedulaPlakaNo = null;
                                if (changeProvisionTypeClass.AdmissionType.provizyonTipiKodu != "V" && changeProvisionTypeClass.AdmissionType.provizyonTipiKodu != "I")
                                {
                                    subEpisode.PatientAdmission.MedulaVakaTarihi = null;
                                    subEpisodeProtocol.MedulaVakaTarihi = null;
                                }
                            }
                            if (changeProvisionTypeClass.AdmissionType.provizyonTipiKodu != "V")
                            {
                                subEpisode.PatientAdmission.SKRSAdliVaka = null;
                                if (changeProvisionTypeClass.AdmissionType.provizyonTipiKodu != "T" && changeProvisionTypeClass.AdmissionType.provizyonTipiKodu != "I")
                                {
                                    subEpisode.PatientAdmission.MedulaVakaTarihi = null;
                                    subEpisodeProtocol.MedulaVakaTarihi = null;
                                }
                            }
                            if (changeProvisionTypeClass.AdmissionType.provizyonTipiKodu != "I" && changeProvisionTypeClass.AdmissionType.provizyonTipiKodu != "T" && changeProvisionTypeClass.AdmissionType.provizyonTipiKodu != "V")
                            {
                                subEpisode.PatientAdmission.MedulaVakaTarihi = null;
                                subEpisode.PatientAdmission.SEP.MedulaVakaTarihi = null;

                            }
                        }

                        if (changeProvisionTypeClass.MedulaIstisnaiHal != null && changeProvisionTypeClass.MedulaIstisnaiHal.Kodu.Equals("B"))
                            subEpisodeProtocol.MedulaTedaviTipi = TedaviTipi.GetTedaviTipi("21");

                        objectContext.Save();

                        objectContext.FullPartialllyLoadedObjects();

                        medulaResult = ınvoiceTopMenuApiController.takipAl(subEpisodeProtocol.ObjectID);

                        if (medulaResult.Succes == false)
                        {
                            throw new Exception(medulaResult.SonucKodu + " " + medulaResult.SonucMesaji);
                        }
                    }

                }
                catch (Exception ex)
                {
                    string _exception = ex.Message + (ex.InnerException == null ? " " : ex.InnerException.Message);
                    throw new Exception(_exception);
                }


            }
            return true;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Muayenesi_Muayene)]
        public ProcedureAdditionalInfo[] GetProceduresWithAdditionalInfo(Guid PatientID)
        {
            List<ProcedureAdditionalInfo> result = new List<ProcedureAdditionalInfo>();
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<AdditionalReport.GetAdditionalReportInfoByPatientID_Class> reportList = AdditionalReport.GetAdditionalReportInfoByPatientID(PatientID, null);
                foreach (AdditionalReport.GetAdditionalReportInfoByPatientID_Class info in reportList)
                {
                    ProcedureAdditionalInfo p = new ProcedureAdditionalInfo();
                    p.ObjectID = info.ObjectID;
                    p.BaseAdditionalApplicationObjectID = info.Baseaddappobjectid;
                    p.SubepisodeOpeningDate = Convert.ToDateTime(info.OpeningDate).ToString("dd.MM.yyyy HH:mm");
                    p.CreationDate = Convert.ToDateTime(info.CreationDate).ToString("dd.MM.yyyy HH:mm");
                    p.ProtocolNo = info.ProtocolNo;
                    p.ProcedureCode = info.Procedurecode;
                    p.ProcedureName = info.Procedurename;
                    p.DoctorName = info.Doctorname;
                    result.Add(p);
                }
            }
            return result.ToArray();
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Muayenesi_Muayene)]
        public object GetAdditionalInfoReport(Guid AdditionalInfoObjectID)
        {
            object result = new object();
            using (var objectContext = new TTObjectContext(false))
            {
                AdditionalReport report = objectContext.GetObject<AdditionalReport>(AdditionalInfoObjectID);
                result = report.Report;
            }
            return result;
        }

        [HttpGet]
        public List<RadiologyAppointmentInfo> CheckScheduledRadiologyAppointments(string EpisodeActionObjectID)
        {
            List<RadiologyAppointmentInfo> appointmentList = new List<RadiologyAppointmentInfo>();

            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(new Guid(EpisodeActionObjectID));
                SubEpisode subepisode = episodeAction.SubEpisode;
                Patient patient = subepisode.Episode.Patient;

                AppointmentServiceController appointmentController = new AppointmentServiceController();

                if (patient.UniqueRefNo != null)
                {
                    try
                    {
                        appointmentController.checkTCKNo(Convert.ToInt64(patient.UniqueRefNo)); //Hastanın Kimlik numarası uygun değilse randevuya bakmasın. 
                                                                                                //PS: Kioks randevusunda randevu kaydedilirken kontrol ediliyordu.    
                    }
                    catch
                    {

                        return appointmentList;
                    }
                }
                BindingList<RadiologyTest> radiologyList = RadiologyTest.GetRadTestWithEquipmentBySE(objectContext, subepisode.ObjectID, "  ");

                foreach (RadiologyTest test in radiologyList)
                {


                    if (((RadiologyTestDefinition)test.ProcedureObject).Equipments.Count > 0)
                    {
                        if (((RadiologyTestDefinition)test.ProcedureObject).Equipments[0].Equipment != null)
                        {



                            ResRadiologyEquipment equipment = ((RadiologyTestDefinition)test.ProcedureObject).Equipments[0].Equipment;

                            AppointmentInputDVO appointmentInput = new AppointmentInputDVO();
                            appointmentInput.ownerObjectID = equipment.ObjectID;
                            appointmentInput.masterOwnerObjectID = equipment.ObservationUnit.ObjectID;
                            appointmentInput.SelectedOwnerResources = new List<Guid>();
                            appointmentInput.SelectedOwnerResources.Add(equipment.ObjectID);
                            appointmentInput.AllResourcesAndColors = new List<ResourceAndColorDVO>();
                            appointmentInput.AppDate = DateTime.Now;
                            appointmentInput.appointmentType = AppointmentTypeEnum.Test;
                            appointmentInput.showAppointmentsOfPatient = false;
                            appointmentInput.currentView = "week";

                            GivenAppointmentsAndSchedules appointmentsAndSchedules = appointmentController.GetEmptyWorkingSchedules(appointmentInput);

                            if (appointmentsAndSchedules.GivenAppointments.Count > 0)
                            {
                                RadiologyAppointmentInfo appInfo = new RadiologyAppointmentInfo();
                                appInfo.RadiologyTestObjectID = test.ObjectID.ToString();
                                appInfo.ProcedureName = test.ProcedureObject.Name;
                                appInfo.ProcedureCode = test.ProcedureObject.Code;
                                appInfo.AppointmentDate = appointmentsAndSchedules.GivenAppointments[0].strAppDate;
                                appInfo.AppointmentTime = appointmentsAndSchedules.GivenAppointments[0].strAppTime;
                                appInfo.givenAppointment = new GivenAppointment();
                                appInfo.givenAppointment = appointmentsAndSchedules.GivenAppointments[0];

                                appointmentList.Add(appInfo);
                            }
                        }
                    }
                }

            }

            return appointmentList;
        }


        [HttpPost]
        public void ApproveRadiologyAppointment(RadiologyAppointmentInfo AppointmentInfo)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                RadiologyTest radiologyTest = objectContext.GetObject<RadiologyTest>(new Guid(AppointmentInfo.RadiologyTestObjectID));

                Patient patient = radiologyTest.Episode.Patient;

                AppointmentServiceController appointmentController = new AppointmentServiceController();
                AppointmentToSaveDVO input = new AppointmentToSaveDVO();

                Schedule selectedAppointmentSchedule = objectContext.GetObject<Schedule>(new Guid(AppointmentInfo.givenAppointment.objectID.ToString())); ;

                input.appointmentToSave = new Appointment(objectContext);

                DateTime appDate = selectedAppointmentSchedule.ScheduleDate.Value;
                DateTime appStartTime = AppointmentInfo.givenAppointment.startDate;
                DateTime appEndTime = AppointmentInfo.givenAppointment.endDate;

                input.appointmentToSave.AppDate = new DateTime(appDate.Year, appDate.Month, appDate.Day, 0, 0, 0);
                input.appointmentToSave.StartTime = new DateTime(appStartTime.Year, appStartTime.Month, appStartTime.Day, appStartTime.Hour, appStartTime.Minute, appStartTime.Second);
                input.appointmentToSave.EndTime = new DateTime(appEndTime.Year, appEndTime.Month, appEndTime.Day, appEndTime.Hour, appEndTime.Minute, appEndTime.Second);
                input.appointmentToSave.AppointmentDefinition = selectedAppointmentSchedule.AppointmentDefinition;

                if (selectedAppointmentSchedule.AppointmentDefinition.AppointmentCarriers != null && selectedAppointmentSchedule.AppointmentDefinition.AppointmentCarriers.Count > 0)
                {
                    input.appointmentToSave.AppointmentCarrier = selectedAppointmentSchedule.AppointmentDefinition.AppointmentCarriers.FirstOrDefault(p => p.IsDefault == true);
                    if (input.appointmentToSave.AppointmentCarrier == null)
                        input.appointmentToSave.AppointmentCarrier = selectedAppointmentSchedule.AppointmentDefinition.AppointmentCarriers[0];
                }

                input.appointmentToSave.MasterResource = selectedAppointmentSchedule.MasterResource;
                input.appointmentToSave.Resource = selectedAppointmentSchedule.Resource;
                input.appointmentToSave.Schedule = selectedAppointmentSchedule;
                input.appointmentToSave.AppointmentType = AppointmentTypeEnum.Test;
                input.appointmentToSave.Notes = "Radyoloji İşlem Randevusu";
                input.appointmentToSave.Patient = patient;
                input.txtPatient = patient.FullName;

                input.appointmentToSave.SubActionProcedure = radiologyTest;
                input.CurrentObject = (TTObject)radiologyTest;

                input.isBreak = false;
                input.osPhoneType = PhoneTypeEnum.GSM;
                input.PhoneNumber = patient.MobilePhone;
                input.selectedCalendarItems = null;
                input.TCKNo = Convert.ToInt64(patient.UniqueRefNo);
                input._myOldAppointment = null;
                input._retAppointment = null;
                try
                {
                    appointmentController.SaveAppointment(input);
                    radiologyTest.CurrentStateDefID = RadiologyTest.States.Appointment;
                    objectContext.Save();
                }
                catch
                {

                }


            }

        }


        #region Yüksek Riskli Grup
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public Sonuc HasHighRiskPregnancy(bool IsWomanSpecialityExam, long? UniqueRefNo)
        {
            HttpClient client = new HttpClient();
            var cts = new CancellationTokenSource();

            RiskligebelikOutput_Class response = new RiskligebelikOutput_Class();
            GebelikIzlem_Output response2 = new GebelikIzlem_Output();

            string retunrMessage = "";

            if (UniqueRefNo != null)
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = TimeSpan.FromSeconds(5);

                string username = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
                string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
      
                string applicationcode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");

                client.DefaultRequestHeaders.Add("KullaniciAdi", username);
                client.DefaultRequestHeaders.Add("Sifre", password);
                client.DefaultRequestHeaders.Add("UygulamaKodu", applicationcode);

                try
                {
                    HttpResponseMessage message = client.GetAsync("http://xxxxxx.com/api/gebelik/GetKisiyeAitGebelikBildirimListesi?tcKimlikNo=" + UniqueRefNo).GetAwaiter().GetResult();
                    //HttpResponseMessage message2 = client.GetAsync("http://xxxxxx.com/api/gebelik/GetKisiyeAitGebelikIzlemListesi?tcKimlikNo="+ UniqueRefNo).GetAwaiter().GetResult();

                    //string result2 = message2.Content.ReadAsStringAsync().Result;
                    //response2 = JsonConvert.DeserializeObject<GebelikIzlem_Output>(result2);

                    //HttpResponseMessage message3 = client.GetAsync("http://xxxxxx.com/api/gebelik/GetKisiyeAitGebelikSonucListesi?tcKimlikNo=10000000000").GetAwaiter().GetResult();


                    if (message.IsSuccessStatusCode)
                    {
                        string result = message.Content.ReadAsStringAsync().Result;
                        response = JsonConvert.DeserializeObject<RiskligebelikOutput_Class>(result);

                        if (response.sonuc != null)
                        {
                            if (IsWomanSpecialityExam)
                            {
                                if (response.sonuc.gebelikBildirim != null && response.sonuc.gebelikBildirim.Count > 0 && response.sonuc.riskliGebelik == true)
                                {
                                    response.sonuc.returnMessage = response.sonuc.riskliGebelikDetayi == null ? "Hastaya ait riskli gebelik bilgisi mevcuttur" : response.sonuc.riskliGebelikDetayi;
                                }
                            }
                            else
                            {
                                if (response.sonuc.riskliGebelik == true)
                                {
                                    response.sonuc.returnMessage = response.sonuc.riskliGebelikDetayi == null ? "Hastaya ait riskli gebelik bilgisi mevcuttur" : response.sonuc.riskliGebelikDetayi;
                                }
                            }
                        }
                    }
                }
                catch (TaskCanceledException ex)
                {
                    if (ex.CancellationToken == cts.Token)
                    {
                        //TODO
                    }
                    else
                    {
                    }
                }


            }

            return response.sonuc;
        }


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<GebelikIzlem> GetGebelikIzlemList(Guid FollowID)
        {
            HttpClient client = new HttpClient();
            GebelikIzlem_Output response = new GebelikIzlem_Output();
            List<GebelikIzlem> gebelikIzlems = new List<GebelikIzlem>();
            long? UniqueRefNo = PregnancyFollow.GetUniqueRefNoByID(FollowID.ToString()).FirstOrDefault().UniqueRefNo;
            if (UniqueRefNo != null)
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string username = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
                string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
     
                string applicationcode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");

                client.DefaultRequestHeaders.Add("KullaniciAdi", username);
                client.DefaultRequestHeaders.Add("Sifre", password);
                client.DefaultRequestHeaders.Add("UygulamaKodu", applicationcode);


                HttpResponseMessage message = client.GetAsync("http://xxxxxx.com/api/gebelik/GetKisiyeAitGebelikIzlemListesi?tcKimlikNo=" + UniqueRefNo).GetAwaiter().GetResult();

                if (message.IsSuccessStatusCode)
                {
                    string result = message.Content.ReadAsStringAsync().Result;
                    response = JsonConvert.DeserializeObject<GebelikIzlem_Output>(result);

                    if (response.sonuc != null && response.sonuc.gebelikIzlem != null)
                    {
                        foreach (GebelikIzlem item in response.sonuc.gebelikIzlem)
                        {
                            GebelikIzlem gebelikIzlem = new GebelikIzlem();

                            gebelikIzlem.bilgiAlinanKisiAdSoyad = item.bilgiAlinanKisiAdSoyad;
                            gebelikIzlem.bilgiAlinanKisiTelefonNumarasi = item.bilgiAlinanKisiTelefonNumarasi;
                            gebelikIzlem.boy = item.boy;
                            gebelikIzlem.gebelikBildirimSYSTakipNo = item.gebelikBildirimSYSTakipNo;
                            gebelikIzlem.gonderimZamani = item.gonderimZamani;
                            gebelikIzlem.hekimAdSoyad = item.hekimAdSoyad;
                            gebelikIzlem.hemoglobin = item.hemoglobin;
                            gebelikIzlem.idrardaProtein = item.idrardaProtein;
                            gebelikIzlem.islemiYapan = item.islemiYapan;
                            gebelikIzlem.islemzamani = item.islemzamani;
                            gebelikIzlem.izleminYapildigiYer = item.izleminYapildigiYer;
                            gebelikIzlem.kacinciGebeIzlem = item.kacinciGebeIzlem;
                            gebelikIzlem.kilo = item.kilo;
                            gebelikIzlem.kurumAdi = item.kurumAdi;
                            gebelikIzlem.sonadettarihi = item.sonadettarihi;
                            gebelikIzlem.sysTakipNo = item.sysTakipNo;

                            if (!string.IsNullOrEmpty(item.gestasyonelDiyabetTaramasi))
                            {
                                SKRSGestasyonelDiyabetTaramasi.GetSKRSGestasyonelDiyabetTaramasi_Class sKRS = SKRSGestasyonelDiyabetTaramasi.GetSKRSGestasyonelDiyabetTaramasi(" WHERE KODU=" + item.gestasyonelDiyabetTaramasi).FirstOrDefault();

                                if (sKRS == null)
                                    gebelikIzlem.gestasyonelDiyabetTaramasi = "";
                                else
                                    gebelikIzlem.gestasyonelDiyabetTaramasi = sKRS.ADI;
                            }
                            else
                                gebelikIzlem.gestasyonelDiyabetTaramasi = "";

                            if (!string.IsNullOrEmpty(item.dvitaminilojistigivedestegi))
                            {
                                SKRSDVitaminiLojistigiveDestegi.GetSKRSDVitaminiLojistigiveDestegi_Class sKRS = SKRSDVitaminiLojistigiveDestegi.GetSKRSDVitaminiLojistigiveDestegi(" WHERE KODU=" + item.dvitaminilojistigivedestegi).FirstOrDefault();

                                if (sKRS == null)
                                    gebelikIzlem.dvitaminilojistigivedestegi = "";
                                else
                                    gebelikIzlem.dvitaminilojistigivedestegi = sKRS.ADI;
                            }
                            else
                                gebelikIzlem.dvitaminilojistigivedestegi = "";

                            if (!string.IsNullOrEmpty(item.demirlojistigivedestegi))
                            {
                                SKRSDemirLojistigiveDestegi.GetSKRSDemirLojistigiveDestegi_Class sKRS = SKRSDemirLojistigiveDestegi.GetSKRSDemirLojistigiveDestegi(" WHERE KODU=" + item.demirlojistigivedestegi).FirstOrDefault();

                                if (sKRS == null)
                                    gebelikIzlem.demirlojistigivedestegi = "";
                                else
                                    gebelikIzlem.demirlojistigivedestegi = sKRS.ADI;
                            }
                            else
                                gebelikIzlem.demirlojistigivedestegi = "";

                            if (!string.IsNullOrEmpty(item.gebelikteRiskDurumu))
                            {
                                SKRSGebelikteRiskDurumu.GetSKRSGebelikteRiskDurumu_Class sKRS = SKRSGebelikteRiskDurumu.GetSKRSGebelikteRiskDurumu(" WHERE KODU=" + item.gebelikteRiskDurumu).FirstOrDefault();

                                if (sKRS == null)
                                    gebelikIzlem.gebelikteRiskDurumu = "";
                                else
                                    gebelikIzlem.gebelikteRiskDurumu = sKRS.ADI;
                            }
                            else
                                gebelikIzlem.gebelikteRiskDurumu = "";

                            if (!string.IsNullOrEmpty(item.konjenitalanomalilidogumvarligi))
                            {
                                SKRSKonjenitalAnomaliliDogumVarligi.GetSKRSKonjenitalAnomaliliDogumVarligi_Class sKRS = SKRSKonjenitalAnomaliliDogumVarligi.GetSKRSKonjenitalAnomaliliDogumVarligi(" WHERE KODU=" + item.konjenitalanomalilidogumvarligi).FirstOrDefault();

                                if (sKRS == null)
                                    gebelikIzlem.konjenitalanomalilidogumvarligi = "";
                                else
                                    gebelikIzlem.konjenitalanomalilidogumvarligi = sKRS.ADI;
                            }
                            else
                                gebelikIzlem.konjenitalanomalilidogumvarligi = "";

                            gebelikIzlems.Add(gebelikIzlem);

                        }

                        return gebelikIzlems;
                    }
                }
            }

            return null;
        }
        #endregion

    }
}

namespace Core.Models
{
    public class PatientExaminationDoctorFormNewViewModel : BaseNewDoctorExaminationFormViewModel
    {
        // Fizyoterapi İşlemleri
        public Boolean StartPhysiotherapyRequest { get; set; }
        public bool IsPhysiotherapyRequestFormUsing { get; set; }
        public bool SavePhysiotherapyRequest { get; set; }
        public Boolean HasAuthorityForPhysiotherapyRequest { get; set; } //Fizyoterapi İstek Yapma Yetkisi
                                                                         // .\ Fizyoterapi İşlemleri

        public bool IsPatientAdmissionEmergengy { get; set; }
        public bool IsIndustrialAccident { get; set; }
        public Boolean IsAuthorizedToWriteTreatmentReport { get; set; }
        public Boolean isENabizActive
        {
            get;
            set;
        }

        public bool isNewMHRS
        {
            get;
            set;
        }

        public bool isRadiologyAppointmentActive { get; set; }

        public TTObjectClasses.EpisodeAction.VitalSingsFormViewModel vitalSingsViewModel;
        public AnamnesisFormViewModel anamnesisFormViewModel = new AnamnesisFormViewModel();
        public TTObjectClasses.PatientExamination _PatientExamination
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisGrid[] DiagnosisHistoryGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList
        {
            get;
            set;
        }

        //public TTObjectClasses.PatientExaminationAdditionalApplication[] GridAdditionalApplicationsGridList
        //{
        //    get;
        //    set;
        //}

        public TTObjectClasses.PatientExaminationTreatmentMaterial[] GridTreatmentMaterialsGridList
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

        public TTObjectClasses.DentalExamination[] GrdDentalExaminationGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ConsultationFromExternalHospital[] GrdExternalConsultationGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DoctorGrid[] ttgridSevkEdenDoktorlarGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SingleNursingOrder[] GridNursingOrdersGridList
        {
            get;
            set;
        }

        public TTObjectClasses.PatientExaminationForensicProcedure[] ForensicProceduresGridGridList
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

        public TTObjectClasses.HCExaminationComponent[] HCExaminationComponents
        {
            get;
            set;
        }

        public TTObjectClasses.HCExaminationDisabledRatio[] HCExaminationDisabledRatios
        {
            get;
            set;
        }

        public TTObjectClasses.DietMaterialDefinition[] DietMaterialDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ActiveIngredientDefinition[] ActiveIngredientDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ImportantMedicalInformation[] ImportantMedicalInformations
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.OzelDurum[] OzelDurums
        {
            get;
            set;
        }

        public TTObjectClasses.EmergencyIntervention[] EmergencyInterventions
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSCikisSekli[] SKRSCikisSeklis
        {
            get;
            set;
        }

        public TTObjectClasses.SpecialityDefinition[] SpecialityDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResSection[] ResSections
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.PatientExamination[] PatientExaminations
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.StockCard[] StockCards
        {
            get;
            set;
        }

        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.SevkVasitasi[] SevkVasitasis
        {
            get;
            set;
        }

        public TTObjectClasses.VitalSignAndNursingDefinition[] VitalSignAndNursingDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.SingleNursingOrderDetail[] SingleNursingOrderDetails
        {
            get;
            set;
        }

        public object _selectedMaterialValue
        {
            get;
            set;
        }

        public object _selectedMedicalInfoFoodAllergyValue
        {
            get;
            set;
        }

        public object _selectedMedicalInfoDrugAllergyValue
        {
            get;
            set;
        }

        public ReportTypeEnum reportType
        {
            get;
            set;
        }

        //public TTObjectClasses.SpecialityBasedObject[] SpecialityBasedObjects { get; set; }
        public Guid _EpisodeActionObjectId;
        public EpisodeActionRequestedProcedureInfo EpisodeActionRequestedProcedureInfo;
        public List<OldConsultationInfo> ConsultationsHistory = new List<OldConsultationInfo>();
        public NewConsultationRequestInfo[] NewConsultationRequests;
        public string ExaminationProcessAndEndDate;
        public string FormattedRequestDate { get; set; }
        public List<PatientReportInfo> PatientReportInfoList = new List<PatientReportInfo>();
        public double? Height
        {
            get;
            set;
        }

        public double? Weight
        {
            get;
            set;
        }

        public Guid? PatientId
        {
            get;
            set;
        }

        public bool IsExaminationCompleted
        {
            get;
            set;
        }

        public bool createNewProcedure
        {
            get;
            set;
        }

        public bool hasSavedDiagnosis
        {
            get;
            set;
        }

        public bool includeDrugDefinition
        {
            get;
            set;
        }

        public bool physicianSuggestionsIsActive
        {
            get;
            set;
        }

        public BaseHCExaminationDynamicObjectFormViewModel[] BaseHCExaminationDynamicObjectFormViewModelList { get; set; }

        public DynamicComponentInfoDVO baseHCEComponentInfo = new DynamicComponentInfoDVO();//dinamşik sağlık kurulu ek alanlar

        public bool hasDoctorKotaRole { get; set; }
        public bool hasDoctorEAthleteRole { get; set; }
        public bool hasDoctorEDriverRole { get; set; }
        public bool hasDoctorEPsychotecnicsRole { get; set; }

        public bool hasOrthesisRequestRole { get; set; }
        public bool hasGiveAppointmentRole { get; set; }


        public Guid GreenAreaExaminationProcedureObjectId { get; set; }//yeşil alan işlemi olarak tanımlanan GUID
        public Guid EmergencyExaminationProcedureObjectId { get; set; }//yeşil alan işlemi olarak tanımlanan GUID

        public bool ISSinglePhysicianReport { get; set; }//Tek hekim raporu :)
        public string SubepisodeID { get; set; }

        public string ProcedureDoctorObjectIDForOBS;
        public bool IsKetem { get; set; }
        public string GenderCode { get; set; }
        public double DayLimitExceeded { get; set; }
        public bool IsWomanSpecialityExam { get; set; }//Kadın hastalıkları
        public string HighRiskPregnancyMessage { get; set; }
        public bool HasMorgue = false;
        public MorgueExDischargeFormViewModel _MorgueViewModel = new MorgueExDischargeFormViewModel();
        public SKRSCikisSekli DeathDefinition = new SKRSCikisSekli();

        public bool IsPcrRequested { get; set; }//PCR tetkiki istendi mi?
    }

    public class OldConsultationInfo
    {
        public Guid consultationObjectID;
        public DateTime consultationActionDate;
        public string consultationRequesterResource;
        public string consultationMasterResource;
        public string consultationRequestDescription;
        public string consultationResult;
        public string consultationState;
        public int consultationStateStatus;
        public List<ConsultationDiagnosis> consultationDiagnosis;
    }

    public class ENabizButtonResponseModel
    {
        public bool isResponseSuccess { get; set; }
        public string responseMessage { get; set; }
        public string responseLink { get; set; }
    }

    public class PatientReportInfo
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public string ObjectDefName
        {
            get;
            set;
        }

        public string ID
        {
            get;
            set;
        }

        public string StartDate
        {
            get;
            set;
        }

        public string EndDate
        {
            get;
            set;
        }

        public string ReportName
        {
            get;
            set;
        }
        public bool CancelledReport
        {
            get;
            set;
        }
        public string RequestReason
        {
            get;
            set;
        }

        public string MasterResource
        {
            get;
            set;
        }

        public string AdmissionDate
        {
            get;
            set;
        }

        public string ProcedureByUser { get; set; }
    }

    public class EpisodeActionRequestedProcedureInfo
    {
        public Guid EpisodeActionObjectID;
        public bool Emergency;
        public List<RequestedProcedureRequestInfo> ProcedureRequestFormDetailDefinitions = new List<RequestedProcedureRequestInfo>();
        public List<AdditionalApplicationRequestInfo> ProcedureRequestAdditionalApplications = new List<AdditionalApplicationRequestInfo>();
        public List<vmRequestedBloodBankProcedureInfo> RequestedBloodProducts = new List<vmRequestedBloodBankProcedureInfo>();
        public bool ignoreSUTRules;
        public List<Guid> DiagnosisObjectIdList = new List<Guid>();
    }

    public class EpisodeActionFireRequestedProceduresResultInfo
    {
        public EpisodeAction.SUTRuleResult SutRuleResult = new EpisodeAction.SUTRuleResult();
        public List<FiredProcedureRequestInfo> FiredProcedureRequestInfoList = new List<FiredProcedureRequestInfo>();
        public string GeneralValidationMsg;
    }

    public class vmRequestedBloodBankProcedureInfo
    {
        public Guid procedureRequestFormDetailDefinitionID;
        public string externalSystemBloodProductID; //Kan urun ID
        public Guid procedureDefinitionID;
    }

    public class FiredProcedureRequestInfo
    {
        public Guid SubActionProcedureObjectID;
        public Guid ProcedureObjectDefinitionID;
        public Guid ProcedureObjectID;
        public Guid EpisodeActionObjectID;
        public string TestTypeName;
        public bool isDescriptionNeeded;
    }

    public class AdditionalApplicationRequestInfo
    {
        public Guid ProcedureObjectID;
        public int Amount;
        public DateTime RequestDate;
        public Guid ProcedureUserId;
        public List<BaseAdditionalInfoFormViewModel> BaseAdditionalInfoFormViewModels = new List<BaseAdditionalInfoFormViewModel>();
        public string Description;
        //FTR Rapor bilgisi ile ilgili alanlar
        public string MedulaReportNo;
        public Guid ReportApplicationArea;
        public RightLeftEnum? RightLeftInformation;

    }

    public class RequestedProcedureRequestInfo
    {
        public Guid ProcedureRequestFormDetailDefinitionID;
        public DateTime RequestDate;
        public Guid ProcedureUserId;
        public RightLeftEnum? RightLeftInformation;
        public SKRSTekrarTetkikIstemGerekcesi ReasonForRepetition;
    }

    public class NewConsultationRequestInfo
    {
        public ResSection consultationMasterResource;
        public ResUser consultationProcedureDoctor;
        public bool consultationEmergency;
        public bool consultationInBed;
    }

    public class NewTreatmentMaterialInfo
    {
        public Material Material;
        public string Barcode;
        public DateTime ActionDate;
        public string DistributionType;
        public double? Amount;
        public StockCard StockCard;
        public DistributionTypeDefinition DistributionTypeDef;
    }

    public class ConsultationDiagnosis
    {
        public string consultationDiagnose;
        public string consultationFreeDiagnose;
    }

    public class DoktorErisimResponse
    {

        [JsonProperty("durum")]
        public int Durum { get; set; }

        [JsonProperty("sonuc")]
        public string Sonuc { get; set; }

        [JsonProperty("mesaj")]
        public string Mesaj { get; set; }
    }

    public class ChangeProvisionTypeClass
    {
        public ProvizyonTipi AdmissionType;
        public DateTime MedulaVakaTarihi;
        public IstisnaiHal MedulaIstisnaiHal;
        public SKRSAdliVakaGelisSekli SKRSAdliVaka;
        public bool Sevkli112;
        public string Emergency112RefNo;
        public string MedulaPlakaNo;
        public string SubepisodeID { get; set; }
    }

    public class ProcedureAdditionalInfo
    {
        public Guid? ObjectID { get; set; }
        public Guid? BaseAdditionalApplicationObjectID { get; set; }
        public string SubepisodeOpeningDate { get; set; }
        public string CreationDate { get; set; }
        public string ProtocolNo { get; set; }
        public string ProcedureCode { get; set; }
        public string ProcedureName { get; set; }
        public string DoctorName { get; set; }

    }

    #region Yüksek Riskli Gebelik

    public class RiskligebelikOutput_Class
    {
        public int? durum { get; set; }
        public Sonuc sonuc { get; set; }
        public object mesaj { get; set; }
    }

    public class Hasta
    {
        public string hastaTC { get; set; }
        public string adSoyad { get; set; }
        public DateTime? birimeAtanmaTarihi { get; set; }
    }

    public class GebelikBildirim
    {
        public string sysTakipNo { get; set; }
        public string hekimAdSoyad { get; set; }
        public string kurumAdi { get; set; }
        public int? kangrubu { get; set; }
        public DateTime? islemzamani { get; set; }
        public DateTime? sonadettarihi { get; set; }
        public DateTime? gonderimZamani { get; set; }
    }

    public class Sonuc
    {
        public Hasta hasta { get; set; }
        public List<GebelikBildirim> gebelikBildirim { get; set; }
        public bool? riskliGebelik { get; set; }
        public string riskliGebelikDetayi { get; set; }
        public string returnMessage { get; set; }//extradan eklendi serviste yok

    }
    #endregion
    #region Gebelik İzlem

    public class GebelikIzlem
    {
        public string gebelikBildirimSYSTakipNo { get; set; }
        public string sysTakipNo { get; set; }
        public string hekimAdSoyad { get; set; }
        public string kurumAdi { get; set; }
        public DateTime? islemzamani { get; set; }
        public string gestasyonelDiyabetTaramasi { get; set; }
        public string islemiYapan { get; set; }
        public string bilgiAlinanKisiAdSoyad { get; set; }
        public string bilgiAlinanKisiTelefonNumarasi { get; set; }
        public DateTime? sonadettarihi { get; set; }
        public string dvitaminilojistigivedestegi { get; set; }
        public string demirlojistigivedestegi
        {
            get;
            set;
        }
        public string gebelikteRiskDurumu
        {
            get;
            set;
        }
        public string hemoglobin { get; set; }
        public string idrardaProtein { get; set; }
        public string konjenitalanomalilidogumvarligi
        {
            get;
            set;
        }
        public string kacinciGebeIzlem { get; set; }
        public string izleminYapildigiYer { get; set; }
        public string boy { get; set; }
        public string kilo { get; set; }
        public DateTime? gonderimZamani { get; set; }
    }

    public class SonucGebelikIzlem
    {
        public Hasta hasta { get; set; }
        public List<GebelikIzlem> gebelikIzlem { get; set; }
    }

    public class GebelikIzlem_Output
    {
        public int? durum { get; set; }
        public SonucGebelikIzlem sonuc { get; set; }
        public string mesaj { get; set; }
    }
    #endregion

    public class RadiologyAppointmentInfo
    {
        public string RadiologyTestObjectID { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureCode { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public GivenAppointment givenAppointment { get; set; }
    }


    public class MHRS_YesilListeEkle_Input
    {
        public int eklenmeSuresi { get; set; }
        public Int64 hastaKimlikNo { get; set; }
        public string hekimAciklama { get; set; }
        public List<string> icdTanilar { get; set; }
        public Int64 islemYapanHekimTcKimlikNo { get; set; }
        public int islemYapanKlinikKodu { get; set; }
        public int islemYapilanKlinikKodu { get; set; }
        public int islemYapilanKurumKodu { get; set; }
        public Int64 islemYapanTcKimlikNo { get; set; }
    }

    public class MHRS_YesilListeSorgula_Input
    {
        public Int64 hastaKimlikNo { get; set; }
        public int klinikKodu { get; set; }
        public int islemYapilanKurumKodu { get; set; }
        public Int64 islemYapanTcKimlikNo { get; set; }
    }

    public class MHRS_YesilListeOnayla_Input
    {
        public Int64 hastaKimlikNo { get; set; }
        public string hekimAciklama { get; set; }
        public List<string> icdTanilar { get; set; }
        public Int64 islemYapanHekimTcKimlikNo { get; set; }
        public int islemYapanKlinikKodu { get; set; }
        public int islemYapilanKlinikKodu { get; set; }
        public int islemYapilanKurumKodu { get; set; }
        public Int64 islemYapanTcKimlikNo { get; set; }
    }

    public class MHRS_Info
    {
        public string kodu { get; set; }
        public string mesaj { get; set; }
    }

    public class MHRS_YesilListeSorgula_Data
    {
        public int klinikKodu { get; set; }
        public string klinikAdi { get; set; }
        public string gecerlilikTarihi { get; set; }
        public string kayitZamani { get; set; }
        public int lyesilListeDurum { get; set; }
        public List<string> icdTanilar { get; set; }
        public string hekimAciklama { get; set; }
    }

    public class MHRS_YesilListeSorgula_Response
    {
        public string lang { get; set; }
        public bool success { get; set; }
        public List<MHRS_Info> infos { get; set; }
        public List<object> warnings { get; set; }
        public List<object> errors { get; set; }
        public List<MHRS_YesilListeSorgula_Data> data { get; set; }
    }

    public class MHRS_YesilListeSorgula_OutPut
    {
        public string result;

        public int yesilListeDurum { get; set; }

    }


}

