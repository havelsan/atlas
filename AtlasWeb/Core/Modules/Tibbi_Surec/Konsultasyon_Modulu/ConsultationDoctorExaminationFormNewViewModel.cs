//$5C123732
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using System.Collections.Generic;
using TTUtils;
using Core.Security;
using TTDefinitionManagement;

namespace Core.Controllers
{
    public partial class ConsultationServiceController : Controller
    {

        [HttpGet]
        public ConsultationDoctorExaminationFormNewViewModel ConsultationDoctorExaminationFormNew(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return ConsultationDoctorExaminationFormNewInternal(input);
        }

        [HttpPost]
        public ConsultationDoctorExaminationFormNewViewModel ConsultationDoctorExaminationFormNewLoad(FormLoadInput input)
        {
            return ConsultationDoctorExaminationFormNewInternal(input);
        }

        [HttpGet]
        public ConsultationDoctorExaminationFormNewViewModel ConsultationDoctorExaminationFormNewInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("023e5cf1-722c-4dc1-9d59-0485a96a208f");
            var objectDefID = Guid.Parse("7a58decc-e858-41eb-87f8-61f97512f3ab");
            var viewModel = new ConsultationDoctorExaminationFormNewViewModel();
            viewModel.ActiveIDsModel = input.Model;

            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._Consultation = objectContext.GetObject(id.Value, objectDefID) as Consultation;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Consultation, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Consultation, formDefID);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Consultation);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Consultation);
                    PreScript_ConsultationDoctorExaminationFormNew(viewModel, viewModel._Consultation, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._Consultation = new Consultation(objectContext);
                    var entryStateID = Guid.Parse("35722241-407f-4891-a5d0-ab738e5fb997");
                    viewModel._Consultation.CurrentStateDefID = entryStateID;
                    viewModel.DiagnosisHistoryGridList = new TTObjectClasses.DiagnosisGrid[]{};
                    viewModel.GridEpisodeDiagnosisGridList = new TTObjectClasses.DiagnosisGrid[]{};
                    viewModel.GridTreatmentMaterialsGridList = new TTObjectClasses.BaseTreatmentMaterial[]{};
               //     viewModel.NewGridTreatmentMaterialsGridList = new TTObjectClasses.BaseTreatmentMaterial[] { };
                    viewModel.GrdConsultationGridList = new TTObjectClasses.Consultation[]{};
                    viewModel.GridNursingOrdersGridList = new TTObjectClasses.SingleNursingOrder[]{};
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Consultation, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Consultation, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Consultation);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Consultation);
                    PreScript_ConsultationDoctorExaminationFormNew(viewModel, viewModel._Consultation, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void ConsultationDoctorExaminationFormNew(ConsultationDoctorExaminationFormNewViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.Episodes);
                objectContext.AddToRawObjectList(viewModel.Patients);
                objectContext.AddToRawObjectList(viewModel.DietMaterialDefinitions);
                objectContext.AddToRawObjectList(viewModel.ActiveIngredientDefinitions);
                objectContext.AddToRawObjectList(viewModel.ImportantMedicalInformations);
                objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
                objectContext.AddToRawObjectList(viewModel.ResUsers);
                objectContext.AddToRawObjectList(viewModel.ResSections);
                objectContext.AddToRawObjectList(viewModel.SpecialityDefinitions);
                objectContext.AddToRawObjectList(viewModel.Materials);
                objectContext.AddToRawObjectList(viewModel.OzelDurums);
                objectContext.AddToRawObjectList(viewModel.VitalSignAndNursingDefinitions);
                objectContext.AddToRawObjectList(viewModel.SingleNursingOrderDetails);
                objectContext.AddToRawObjectList(viewModel.DiagnosisHistoryGridList);
                objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
                objectContext.AddToRawObjectList(viewModel.GridTreatmentMaterialsGridList);
           //     objectContext.AddToRawObjectList(viewModel.NewGridTreatmentMaterialsGridList);
                objectContext.AddToRawObjectList(viewModel.GrdConsultationGridList);
                objectContext.AddToRawObjectList(viewModel.GridNursingOrdersGridList);
                var entryStateID = Guid.Parse("35722241-407f-4891-a5d0-ab738e5fb997");
                objectContext.AddToRawObjectList(viewModel._Consultation, entryStateID);
                objectContext.ProcessRawObjects(false);
                var formDefID = Guid.Parse("023e5cf1-722c-4dc1-9d59-0485a96a208f");
                var consultation = (Consultation)objectContext.AddObject(viewModel._Consultation);
                viewModel._Consultation = (Consultation)objectContext.AddObject(viewModel._Consultation);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(consultation, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Consultation, formDefID);
                var episode = viewModel._Consultation.Episode;
                if (episode != null)
                {
                    var episodeImported = episode; //(Episode)objectContext.AddObject(episode);
                    var patient = episode.Patient;
                    if (patient != null)
                    {
                        var patientImported = patient; //(Patient)objectContext.AddObject(patient);
                        var importantMedicalInformation = patient.ImportantMedicalInformation;
                        if (importantMedicalInformation != null)
                        {
                            var importantMedicalInformationImported = (ImportantMedicalInformation)objectContext.AddObject(importantMedicalInformation);
                            if (viewModel.DiagnosisHistoryGridList != null)
                            {
                                foreach (var item in viewModel.DiagnosisHistoryGridList)
                                {
                                    var diagnosisHistoryImported = (DiagnosisGrid)objectContext.AddObject(item);
                                    diagnosisHistoryImported.ImportantMedicalInformation = importantMedicalInformationImported;
                                }
                            }
                        }
                    }

                    if (viewModel.GridEpisodeDiagnosisGridList != null)
                    {
                        foreach (var item in viewModel.GridEpisodeDiagnosisGridList)
                        {
                            var diagnosisImported = (DiagnosisGrid)objectContext.AddObject(item);
                            diagnosisImported.Episode = episodeImported;
                            if (diagnosisImported.EpisodeAction == null)
                                diagnosisImported.EpisodeAction = consultation;
                        }
                    }
                }

                if (viewModel.GridTreatmentMaterialsGridList != null)
                {
                    foreach (var item in viewModel.GridTreatmentMaterialsGridList)
                   {
                       var treatmentMaterialsImported = (BaseTreatmentMaterial)objectContext.AddObject(item);
                      treatmentMaterialsImported.EpisodeAction = consultation;
                   }
                }

           /*      if (viewModel.NewGridTreatmentMaterialsGridList != null)
                {
                    foreach (var item in viewModel.NewGridTreatmentMaterialsGridList)
                    {
                      //  var treatmentMaterialsImported = (BaseTreatmentMaterial)objectContext.AddObject(item);
                        var treatmentMaterialsImported = (BaseTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)treatmentMaterialsImported).IsDeleted || treatmentMaterialsImported.EpisodeAction != null)
                            continue;
                        treatmentMaterialsImported.EpisodeAction = consultation;
                    }
                } */

                if (viewModel.GrdConsultationGridList != null)
                {
                    foreach (var item in viewModel.GrdConsultationGridList)
                    {
                        var consultationsImported = (Consultation)objectContext.AddObject(item);
                        consultationsImported.PhysicianApplication = consultation;
                    }
                }

                if (viewModel.GridNursingOrdersGridList != null)
                {
                    foreach (var item in viewModel.GridNursingOrdersGridList)
                    {
                        var singleNursingOrdersImported = (SingleNursingOrder)objectContext.AddObject(item);
                        singleNursingOrdersImported.PhysicianApplication = consultation;
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
                //ENabız Kaydetmek için
                if (viewModel.ENabizViewModels != null)
                {
                    foreach (var enabizViewModel in viewModel.ENabizViewModels)
                    {
                        enabizViewModel.AddENabizObjectViewModelToContext(objectContext);
                    }
                }

                //if (consultation.PatientAdmission!= null && consultation.PatientAdmission.PAStatus == PAStatusEnum.Sirada)
                //    consultation.PatientAdmission.PAStatus = PAStatusEnum.Muayenede;
                
                //if((consultation.CurrentStateDefID == Consultation.States.RequestAcception || consultation.CurrentStateDefID == Consultation.States.InsertedIntoQueue || consultation.CurrentStateDefID == Consultation.States.Appointment) && consultation.ConsultationResultAndOffers != null)
                //    consultation.CurrentStateDefID = Consultation.States.Consultation;
                var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(consultation);
                PostScript_ConsultationDoctorExaminationFormNew(viewModel, consultation, transDef, objectContext);
                objectContext.AdvanceStateForNewObjects();
                objectContext.Save();
                AfterContextSaveScript_ConsultationDoctorExaminationFormNew(viewModel, consultation, transDef, objectContext);
            }
        }

        partial void PreScript_ConsultationDoctorExaminationFormNew(ConsultationDoctorExaminationFormNewViewModel viewModel, Consultation consultation, TTObjectContext objectContext);
        partial void PostScript_ConsultationDoctorExaminationFormNew(ConsultationDoctorExaminationFormNewViewModel viewModel, Consultation consultation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ConsultationDoctorExaminationFormNew(ConsultationDoctorExaminationFormNewViewModel viewModel, Consultation consultation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(ConsultationDoctorExaminationFormNewViewModel viewModel, TTObjectContext objectContext)
        {
            var episode = viewModel._Consultation.Episode;
            if (episode != null)
            {
                var patient = episode.Patient;
                if (patient != null)
                {
                    var importantMedicalInformation = patient.ImportantMedicalInformation;
                    if (importantMedicalInformation != null)
                    {
                        viewModel.DiagnosisHistoryGridList = importantMedicalInformation.DiagnosisHistory.OfType<DiagnosisGrid>().ToArray();
                    }
                }

                viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
            }

            viewModel.GridTreatmentMaterialsGridList = viewModel._Consultation.ConsultationTreatmentMaterials.OfType<BaseTreatmentMaterial>().ToArray();
            viewModel.GrdConsultationGridList = viewModel._Consultation.Consultations.OfType<Consultation>().ToArray();
            viewModel.GridNursingOrdersGridList = viewModel._Consultation.SingleNursingOrders.OfType<SingleNursingOrder>().ToArray();
            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
            viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
            viewModel.DietMaterialDefinitions = objectContext.LocalQuery<DietMaterialDefinition>().ToArray();
            viewModel.ActiveIngredientDefinitions = objectContext.LocalQuery<ActiveIngredientDefinition>().ToArray();
            viewModel.ImportantMedicalInformations = objectContext.LocalQuery<ImportantMedicalInformation>().ToArray();
            viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
            viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
            viewModel.VitalSignAndNursingDefinitions = objectContext.LocalQuery<VitalSignAndNursingDefinition>().ToArray();
            viewModel.SingleNursingOrderDetails = objectContext.LocalQuery<SingleNursingOrderDetail>().ToArray();
            viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
            viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
            if (viewModel._Consultation.ProcessDate.HasValue == false)
                viewModel._Consultation.ProcessDate = Common.RecTime();
        }
        partial void PreScript_ConsultationDoctorExaminationFormNew(ConsultationDoctorExaminationFormNewViewModel viewModel, Consultation consultation, TTObjectContext objectContext)
        {
            //Uzmanlık için
            viewModel.SetHasSpecialityBasedObject(consultation);
            //Hastanın var olan Raporları
            PatientExaminationDoctorFormNewViewModel pe = new PatientExaminationDoctorFormNewViewModel();

            BindingList<EpisodeAction> reportList = new BindingList<EpisodeAction>();
            reportList = EpisodeAction.GetAllReportsOfSubEpisode(objectContext, consultation.SubEpisode.ObjectID.ToString());

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

                    if (report.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient)
                    {
                        patientReportInfo.AdmissionDate = report.SubEpisode.InpatientAdmission.HospitalInPatientDate.Value.ToShortDateString();
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
            viewModel.PatientReportInfoList = patientReportInfoList;

            ContextToViewModel(viewModel, objectContext);
       
            if (consultation.ProcedureSpeciality != null)
                viewModel.IsAuthorizedToWriteTreatmentReport = EpisodeAction.IsAuthorizedToWriteTreatmentReport(consultation.ProcedureSpeciality);
            else
                viewModel.IsAuthorizedToWriteTreatmentReport = false;
            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalışmamalı
            viewModel.GridTreatmentMaterialsGridList = viewModel.GridTreatmentMaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
            //ContextToViewModel den sonra çağırılmalı //TANI için
            viewModel.GridEpisodeDiagnosisGridList = consultation.DiagnosisGrid_PreScript();

            //viewModel.NewGridTreatmentMaterialsGridList = consultation.Episode.SubActionMaterials.OfType<BaseTreatmentMaterial>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            //viewModel.SubEpisodeList = new List<SubEpisode>();
            //viewModel.EpisodeActionList = new List<EpisodeAction>();
            //viewModel.NewGridTreatmentMaterialsGridList = viewModel.NewGridTreatmentMaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
            //viewModel.NewGridTreatmentMaterialsGridList = viewModel.NewGridTreatmentMaterialsGridList.Where(material => viewModel.ControlTreatmentMaterialActions(material) == true).ToArray();


            var inpatientAdmissions = consultation.Episode.InpatientAdmissions;

            if (inpatientAdmissions != null && inpatientAdmissions.Count > 0)
            {
                var inpatientAdmission = inpatientAdmissions[inpatientAdmissions.Count - 1];
                if (inpatientAdmission.ActiveInPatientTrtmentClcApp != null)
                {
                    if(inpatientAdmission.ActiveInPatientTrtmentClcApp.IsDailyOperation != true )
                    {
                        if (inpatientAdmission.Room != null && inpatientAdmission.Bed != null)
                            viewModel.BedRoomInfo = inpatientAdmission.Room.Name + " / " + inpatientAdmission.Bed.Name;
                    }
                }
                else
                {
                    if (inpatientAdmission.Room != null && inpatientAdmission.Bed != null)
                        viewModel.BedRoomInfo = inpatientAdmission.Room.Name + " / " + inpatientAdmission.Bed.Name;
                }
            }
        }


        partial void PostScript_ConsultationDoctorExaminationFormNew(ConsultationDoctorExaminationFormNewViewModel viewModel, Consultation consultation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //TANI için
            consultation.DiagnosisGrid_PostScript(viewModel.GridEpisodeDiagnosisGridList);
        }
    }
}

namespace Core.Models
{
    public class ConsultationDoctorExaminationFormNewViewModel : BaseNewDoctorExaminationFormViewModel
    {
        public TTObjectClasses.Consultation _Consultation
        {
            get;
            set;
        }
        public ReportTypeEnum reportType
        {
            get;
            set;
        }
        public List<PatientReportInfo> PatientReportInfoList = new List<PatientReportInfo>();

        //public TTObjectClasses.MedicalInfoFoodAllergies[] MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesGridList { get; set; }
        //public TTObjectClasses.MedicalInfoDrugAllergies[] MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesGridList { get; set; }
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

        public TTObjectClasses.BaseTreatmentMaterial[] GridTreatmentMaterialsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.Consultation[] GrdConsultationGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SingleNursingOrder[] GridNursingOrdersGridList
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

        //public TTObjectClasses.MedicalInformation[] MedicalInformations { get; set; }
        //public TTObjectClasses.MedicalInfoHabits[] MedicalInfoHabitss { get; set; }
        //public TTObjectClasses.SKRSSigaraKullanimi[] SKRSSigaraKullanimis { get; set; }
        //public TTObjectClasses.SKRSAlkolKullanimi[] SKRSAlkolKullanimis { get; set; }
        //public TTObjectClasses.MedicalInfoDisabledGroup[] MedicalInfoDisabledGroups { get; set; }
        //public TTObjectClasses.MedicalInfoAllergies[] MedicalInfoAllergiess { get; set; }
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

        public TTObjectClasses.ResSection[] ResSections
        {
            get;
            set;
        }

        public TTObjectClasses.SpecialityDefinition[] SpecialityDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.OzelDurum[] OzelDurums
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

        //   public bool _isComplete { get; set; }
        public Guid _ConsultationMasterResourseID
        {
            get;
            set;
        }

        public Modules.Tibbi_Surec.Tetkik_Istem_Modulu.vmRequestedProcedure[] RequestedProcedures
        {
            get;
            set;
        }

        public Guid _EpisodeActionObjectId;
        public object _selectedMaterialValue
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

        public IENabizViewModel[] ENabizViewModels
        {
            get;
            set;
        }
        public Boolean IsAuthorizedToWriteTreatmentReport { get; set; }
        public string BedRoomInfo { get; set; }

    }
   
}