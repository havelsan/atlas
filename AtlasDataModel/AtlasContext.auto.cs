using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AtlasDataModel
{
    public partial class AtlasContext : DbContext
    {

        #region DbSet Properties
        public virtual DbSet<AtlasModel.InvoiceInclusionNQL> InvoiceInclusionNQL { get; set; }
        public virtual DbSet<AtlasModel.Resource> Resource { get; set; }
        public virtual DbSet<AtlasModel.MainStoreDefinition> MainStoreDefinition { get; set; }
        public virtual DbSet<AtlasModel.RevenueSubAccountCodeDefinition> RevenueSubAccountCodeDefinition { get; set; }
        public virtual DbSet<AtlasModel.SKRSKlinikler> SKRSKlinikler { get; set; }
        public virtual DbSet<AtlasModel.SKRSKurumTuru> SKRSKurumTuru { get; set; }
        public virtual DbSet<AtlasModel.StockTransactionDefinition> StockTransactionDefinition { get; set; }
        public virtual DbSet<AtlasModel.SKRSRaporTuru> SKRSRaporTuru { get; set; }
        public virtual DbSet<AtlasModel.ProcedureDefinition> ProcedureDefinition { get; set; }
        public virtual DbSet<AtlasModel.SKRSICDOYERLESIMYERI> SKRSICDOYERLESIMYERI { get; set; }
        public virtual DbSet<AtlasModel.MKYSMalzemeSiniflandirma> MKYSMalzemeSiniflandirma { get; set; }
        public virtual DbSet<AtlasModel.SKRSAsiKodu> SKRSAsiKodu { get; set; }
        public virtual DbSet<AtlasModel.TaburcuKodu> TaburcuKodu { get; set; }
        public virtual DbSet<AtlasModel.MenuDefinition> MenuDefinition { get; set; }
        public virtual DbSet<AtlasModel.TerminologyManagerDef> TerminologyManagerDef { get; set; }
        public virtual DbSet<AtlasModel.MKYS_ServisDepo> MKYS_ServisDepo { get; set; }
        public virtual DbSet<AtlasModel.MKYSKod> MKYSKod { get; set; }
        public virtual DbSet<AtlasModel.ENabizPackageDefinition> ENabizPackageDefinition { get; set; }
        public virtual DbSet<AtlasModel.NursingTargetDefinition> NursingTargetDefinition { get; set; }
        public virtual DbSet<AtlasModel.LabGridSpecialityDefinition> LabGridSpecialityDefinition { get; set; }
        public virtual DbSet<AtlasModel.AccountPeriodDefinition> AccountPeriodDefinition { get; set; }
        public virtual DbSet<AtlasModel.OlayAfetSMSGonderim> OlayAfetSMSGonderim { get; set; }
        public virtual DbSet<AtlasModel.LCDNotificationDefinition> LCDNotificationDefinition { get; set; }
        public virtual DbSet<AtlasModel.WoundStageDef> WoundStageDef { get; set; }
        public virtual DbSet<AtlasModel.Material> Material { get; set; }
        public virtual DbSet<AtlasModel.SurgeryRobsonDefinition> SurgeryRobsonDefinition { get; set; }
        public virtual DbSet<AtlasModel.MalzemeGetData> MalzemeGetData { get; set; }
        public virtual DbSet<AtlasModel.BaseMedulaDefinition> BaseMedulaDefinition { get; set; }
        public virtual DbSet<AtlasModel.SKRSTELETIPKurumOnEkBilgileri> SKRSTELETIPKurumOnEkBilgileri { get; set; }
        public virtual DbSet<AtlasModel.PathologyJarTypeDef> PathologyJarTypeDef { get; set; }
        public virtual DbSet<AtlasModel.WoundLocalizationDef> WoundLocalizationDef { get; set; }
        public virtual DbSet<AtlasModel.WoundSideInfo> WoundSideInfo { get; set; }
        public virtual DbSet<AtlasModel.SKRSEnfeksiyonEtkeni> SKRSEnfeksiyonEtkeni { get; set; }
        public virtual DbSet<AtlasModel.SKRSYOGUNBAKIMHASTATIPI> SKRSYOGUNBAKIMHASTATIPI { get; set; }
        public virtual DbSet<AtlasModel.SKRSTibbiBiyokimyaAkilciTestIstemiListesi> SKRSTibbiBiyokimyaAkilciTestIstemiListesi { get; set; }
        public virtual DbSet<AtlasModel.SKRSDavranisOnerisi> SKRSDavranisOnerisi { get; set; }
        public virtual DbSet<AtlasModel.SKRSEgitimMateryali> SKRSEgitimMateryali { get; set; }
        public virtual DbSet<AtlasModel.SKRSSHMAltBirim> SKRSSHMAltBirim { get; set; }
        public virtual DbSet<AtlasModel.SKRSTaniTuru> SKRSTaniTuru { get; set; }
        public virtual DbSet<AtlasModel.SKRSTekrarTetkikIstemGerekcesi> SKRSTekrarTetkikIstemGerekcesi { get; set; }
        public virtual DbSet<AtlasModel.SKRSRadyolojikTetkikIstemPeriyoduListesi> SKRSRadyolojikTetkikIstemPeriyoduListesi { get; set; }
        public virtual DbSet<AtlasModel.SKRSTakipTipi> SKRSTakipTipi { get; set; }
        public virtual DbSet<AtlasModel.SKRSKronikHastalikBilgisi> SKRSKronikHastalikBilgisi { get; set; }
        public virtual DbSet<AtlasModel.SKRSNTPTAKIPBILGISI> SKRSNTPTAKIPBILGISI { get; set; }
        public virtual DbSet<AtlasModel.SKRSGKDTARAMASONUCU> SKRSGKDTARAMASONUCU { get; set; }
        public virtual DbSet<AtlasModel.StockTransactionCollectedDefinition> StockTransactionCollectedDefinition { get; set; }
        public virtual DbSet<AtlasModel.SKRSUCUM> SKRSUCUM { get; set; }
        public virtual DbSet<AtlasModel.SKRSOgrenciMuayeneIzlemIslemi> SKRSOgrenciMuayeneIzlemIslemi { get; set; }
        public virtual DbSet<AtlasModel.SKRSOkulCagiPosturMuayeneBilgisi> SKRSOkulCagiPosturMuayeneBilgisi { get; set; }
        public virtual DbSet<AtlasModel.SKRSGormeTaramaSonucu> SKRSGormeTaramaSonucu { get; set; }
        public virtual DbSet<AtlasModel.SKRSSUTVS> SKRSSUTVS { get; set; }
        public virtual DbSet<AtlasModel.SKRSMalnutrisyonTedaviPlani> SKRSMalnutrisyonTedaviPlani { get; set; }
        public virtual DbSet<AtlasModel.SKRSOkulCagiGenclikIzlemTakvimi> SKRSOkulCagiGenclikIzlemTakvimi { get; set; }
        public virtual DbSet<AtlasModel.SurgeryDefinition> SurgeryDefinition { get; set; }
        public virtual DbSet<AtlasModel.SKRSMalnutrisyonDegerlendirmeBilgisi> SKRSMalnutrisyonDegerlendirmeBilgisi { get; set; }
        public virtual DbSet<AtlasModel.ChemotherapyApplyMethod> ChemotherapyApplyMethod { get; set; }
        public virtual DbSet<AtlasModel.MedicalResarchTermDef> MedicalResarchTermDef { get; set; }
        public virtual DbSet<AtlasModel.ChemotherapyApplySubMethod> ChemotherapyApplySubMethod { get; set; }
        public virtual DbSet<AtlasModel.LinenGroup> LinenGroup { get; set; }
        public virtual DbSet<AtlasModel.SKRSKanGrubu> SKRSKanGrubu { get; set; }
        public virtual DbSet<AtlasModel.LinenLocation> LinenLocation { get; set; }
        public virtual DbSet<AtlasModel.LinenType> LinenType { get; set; }
        public virtual DbSet<AtlasModel.RadiotherapyXRayTypeDef> RadiotherapyXRayTypeDef { get; set; }
        public virtual DbSet<AtlasModel.StockLevelType> StockLevelType { get; set; }
        public virtual DbSet<AtlasModel.DPRuleMaster> DPRuleMaster { get; set; }
        public virtual DbSet<AtlasModel.ResDepartment> ResDepartment { get; set; }
        public virtual DbSet<AtlasModel.DpRuleDetail> DpRuleDetail { get; set; }
        public virtual DbSet<AtlasModel.DpRuleProcedure> DpRuleProcedure { get; set; }
        public virtual DbSet<AtlasModel.DpRuleSpeciality> DpRuleSpeciality { get; set; }
        public virtual DbSet<AtlasModel.DietMaterialDefinition> DietMaterialDefinition { get; set; }
        public virtual DbSet<AtlasModel.DrugATC> DrugATC { get; set; }
        public virtual DbSet<AtlasModel.DefinitionConcept> DefinitionConcept { get; set; }
        public virtual DbSet<AtlasModel.MaterialVatRate> MaterialVatRate { get; set; }
        public virtual DbSet<AtlasModel.NursingCareDefinition> NursingCareDefinition { get; set; }
        public virtual DbSet<AtlasModel.ProcedureTypeDefinition> ProcedureTypeDefinition { get; set; }
        public virtual DbSet<AtlasModel.SKRSICD> SKRSICD { get; set; }
        public virtual DbSet<AtlasModel.OrtesisProsthesisDefinition> OrtesisProsthesisDefinition { get; set; }
        public virtual DbSet<AtlasModel.PayerProtocolDefinition> PayerProtocolDefinition { get; set; }
        public virtual DbSet<AtlasModel.SKRSIlac> SKRSIlac { get; set; }
        public virtual DbSet<AtlasModel.SystemParameter> SystemParameter { get; set; }
        public virtual DbSet<AtlasModel.ResObservationUnit> ResObservationUnit { get; set; }
        public virtual DbSet<AtlasModel.PatientAdmissionStartedActions> PatientAdmissionStartedActions { get; set; }
        public virtual DbSet<AtlasModel.SystemInterrogationDefinition> SystemInterrogationDefinition { get; set; }
        public virtual DbSet<AtlasModel.TeshisEtkinMaddeGrid> TeshisEtkinMaddeGrid { get; set; }
        public virtual DbSet<AtlasModel.RadiologyGridDepartmentDefinition> RadiologyGridDepartmentDefinition { get; set; }
        public virtual DbSet<AtlasModel.ResClinic> ResClinic { get; set; }
        public virtual DbSet<AtlasModel.PatientFolderContentDefinition> PatientFolderContentDefinition { get; set; }
        public virtual DbSet<AtlasModel.MainCashOfficePaymentTypeDefinition> MainCashOfficePaymentTypeDefinition { get; set; }
        public virtual DbSet<AtlasModel.DietDefinition> DietDefinition { get; set; }
        public virtual DbSet<AtlasModel.MedulaErrorCodeDefinition> MedulaErrorCodeDefinition { get; set; }
        public virtual DbSet<AtlasModel.ProcedureTreeDefinition> ProcedureTreeDefinition { get; set; }
        public virtual DbSet<AtlasModel.RadiologyGridEquipmentDefinition> RadiologyGridEquipmentDefinition { get; set; }
        public virtual DbSet<AtlasModel.MedicalStuffDefinition> MedicalStuffDefinition { get; set; }
        public virtual DbSet<AtlasModel.InvoiceInclusionMaster> InvoiceInclusionMaster { get; set; }
        public virtual DbSet<AtlasModel.ResPoliclinic> ResPoliclinic { get; set; }
        public virtual DbSet<AtlasModel.ResSection> ResSection { get; set; }
        public virtual DbSet<AtlasModel.Supplier> Supplier { get; set; }
        public virtual DbSet<AtlasModel.FallingDownRiskDefinition> FallingDownRiskDefinition { get; set; }
        public virtual DbSet<AtlasModel.ExternalHospitalDefinition> ExternalHospitalDefinition { get; set; }
        public virtual DbSet<AtlasModel.PhysiotherapyDefinition> PhysiotherapyDefinition { get; set; }
        public virtual DbSet<AtlasModel.ActionDefaultMasterResourceGrid> ActionDefaultMasterResourceGrid { get; set; }
        public virtual DbSet<AtlasModel.DiagnosisDefinition> DiagnosisDefinition { get; set; }
        public virtual DbSet<AtlasModel.DiagnosisDefTeshis> DiagnosisDefTeshis { get; set; }
        public virtual DbSet<AtlasModel.ResAdministrativeUnit> ResAdministrativeUnit { get; set; }
        public virtual DbSet<AtlasModel.PackageTemplateDefinition> PackageTemplateDefinition { get; set; }
        public virtual DbSet<AtlasModel.PackageTemplateICDDetailDefinition> PackageTemplateICDDetailDefinition { get; set; }
        public virtual DbSet<AtlasModel.ActiveIngredientDefinition> ActiveIngredientDefinition { get; set; }
        public virtual DbSet<AtlasModel.WorkDayExceptionDef> WorkDayExceptionDef { get; set; }
        public virtual DbSet<AtlasModel.ResBed> ResBed { get; set; }
        public virtual DbSet<AtlasModel.InvoiceTerm> InvoiceTerm { get; set; }
        public virtual DbSet<AtlasModel.OzelDurum> OzelDurum { get; set; }
        public virtual DbSet<AtlasModel.SKRSAFETOLAYTIPI> SKRSAFETOLAYTIPI { get; set; }
        public virtual DbSet<AtlasModel.ResRoomGroup> ResRoomGroup { get; set; }
        public virtual DbSet<AtlasModel.SKRSPersonelBransKodu> SKRSPersonelBransKodu { get; set; }
        public virtual DbSet<AtlasModel.ReferableResource> ReferableResource { get; set; }
        public virtual DbSet<AtlasModel.GuardFormationDefinition> GuardFormationDefinition { get; set; }
        public virtual DbSet<AtlasModel.ConsumableMaterialDefinition> ConsumableMaterialDefinition { get; set; }
        public virtual DbSet<AtlasModel.LaboratoryGridDepartmentDefinition> LaboratoryGridDepartmentDefinition { get; set; }
        public virtual DbSet<AtlasModel.PackageProcedureDefinition> PackageProcedureDefinition { get; set; }
        public virtual DbSet<AtlasModel.SKRSKurumlar> SKRSKurumlar { get; set; }
        public virtual DbSet<AtlasModel.InvoiceBlockingDefinition> InvoiceBlockingDefinition { get; set; }
        public virtual DbSet<AtlasModel.MaterialTreeDefinition> MaterialTreeDefinition { get; set; }
        public virtual DbSet<AtlasModel.AppointmentDefinition> AppointmentDefinition { get; set; }
        public virtual DbSet<AtlasModel.SKRSSUT> SKRSSUT { get; set; }
        public virtual DbSet<AtlasModel.ResTreatmentDiagnosisUnit> ResTreatmentDiagnosisUnit { get; set; }
        public virtual DbSet<AtlasModel.UserOptionGroup> UserOptionGroup { get; set; }
        public virtual DbSet<AtlasModel.SpecialPanelDefinition> SpecialPanelDefinition { get; set; }
        public virtual DbSet<AtlasModel.ResSurgeryRoom> ResSurgeryRoom { get; set; }
        public virtual DbSet<AtlasModel.SKRSSistemKodlari> SKRSSistemKodlari { get; set; }
        public virtual DbSet<AtlasModel.Stock> Stock { get; set; }
        public virtual DbSet<AtlasModel.NursingReasonDefinition> NursingReasonDefinition { get; set; }
        public virtual DbSet<AtlasModel.NursingProblemReasonRelation> NursingProblemReasonRelation { get; set; }
        public virtual DbSet<AtlasModel.BaseSKRSCommonDef> BaseSKRSCommonDef { get; set; }
        public virtual DbSet<AtlasModel.BaseSKRSDefinition> BaseSKRSDefinition { get; set; }
        public virtual DbSet<AtlasModel.SKRSEnumMatchDefinition> SKRSEnumMatchDefinition { get; set; }
        public virtual DbSet<AtlasModel.EmergencySurveyDefinition> EmergencySurveyDefinition { get; set; }
        public virtual DbSet<AtlasModel.SubStoreDefinition> SubStoreDefinition { get; set; }
        public virtual DbSet<AtlasModel.GuideBookDefinition> GuideBookDefinition { get; set; }
        public virtual DbSet<AtlasModel.MaterialPrice> MaterialPrice { get; set; }
        public virtual DbSet<AtlasModel.LaboratoryGridPanelTestDefinition> LaboratoryGridPanelTestDefinition { get; set; }
        public virtual DbSet<AtlasModel.LaboratoryGridBoundedTestDefinition> LaboratoryGridBoundedTestDefinition { get; set; }
        public virtual DbSet<AtlasModel.SKRSOlayAfetBilgisi> SKRSOlayAfetBilgisi { get; set; }
        public virtual DbSet<AtlasModel.PackageTemplateProcReqFormDetailDefinition> PackageTemplateProcReqFormDetailDefinition { get; set; }
        public virtual DbSet<AtlasModel.DrugActiveIngredient> DrugActiveIngredient { get; set; }
        public virtual DbSet<AtlasModel.SKRSMahalleKodlari> SKRSMahalleKodlari { get; set; }
        public virtual DbSet<AtlasModel.SKRSMSVS> SKRSMSVS { get; set; }
        public virtual DbSet<AtlasModel.ResHeaderShip> ResHeaderShip { get; set; }
        public virtual DbSet<AtlasModel.SKRSICDMSVSIliskisi> SKRSICDMSVSIliskisi { get; set; }
        public virtual DbSet<AtlasModel.ResRoom> ResRoom { get; set; }
        public virtual DbSet<AtlasModel.ProcedureRequestFormDefinition> ProcedureRequestFormDefinition { get; set; }
        public virtual DbSet<AtlasModel.ProcedureRequestFormDetailDefinition> ProcedureRequestFormDetailDefinition { get; set; }
        public virtual DbSet<AtlasModel.ProcedureRequestCategoryDefinition> ProcedureRequestCategoryDefinition { get; set; }
        public virtual DbSet<AtlasModel.SKRSICDOMORFOLOJIKODU> SKRSICDOMORFOLOJIKODU { get; set; }
        public virtual DbSet<AtlasModel.DoctorQuotaDefinition> DoctorQuotaDefinition { get; set; }
        public virtual DbSet<AtlasModel.SKRSICDO> SKRSICDO { get; set; }
        public virtual DbSet<AtlasModel.OLDSKRSIlce> OLDSKRSIlce { get; set; }
        public virtual DbSet<AtlasModel.Producer> Producer { get; set; }
        public virtual DbSet<AtlasModel.ResDivision> ResDivision { get; set; }
        public virtual DbSet<AtlasModel.ReasonForExaminationDefinition> ReasonForExaminationDefinition { get; set; }
        public virtual DbSet<AtlasModel.EstheticAlternativeProcedureDefinition> EstheticAlternativeProcedureDefinition { get; set; }
        public virtual DbSet<AtlasModel.HCRequestReason> HCRequestReason { get; set; }
        public virtual DbSet<AtlasModel.PackageTemplateProcedureDefinition> PackageTemplateProcedureDefinition { get; set; }
        public virtual DbSet<AtlasModel.LaboratoryTestDefinition> LaboratoryTestDefinition { get; set; }
        public virtual DbSet<AtlasModel.WorkListDefinition> WorkListDefinition { get; set; }
        public virtual DbSet<AtlasModel.Accountancy> Accountancy { get; set; }
        public virtual DbSet<AtlasModel.ExaminationQueueDefinition> ExaminationQueueDefinition { get; set; }
        public virtual DbSet<AtlasModel.EtkinMadde> EtkinMadde { get; set; }
        public virtual DbSet<AtlasModel.StockCardClass> StockCardClass { get; set; }
        public virtual DbSet<AtlasModel.SKRSIlceKodlari> SKRSIlceKodlari { get; set; }
        public virtual DbSet<AtlasModel.VaccineDefinition> VaccineDefinition { get; set; }
        public virtual DbSet<AtlasModel.DistributionTypeDefinition> DistributionTypeDefinition { get; set; }
        public virtual DbSet<AtlasModel.PricingDetailDefinition> PricingDetailDefinition { get; set; }
        public virtual DbSet<AtlasModel.TakeOffDatetime> TakeOffDatetime { get; set; }
        public virtual DbSet<AtlasModel.SKRSTibbiIslemPuanBilgisi> SKRSTibbiIslemPuanBilgisi { get; set; }
        public virtual DbSet<AtlasModel.DocumentDefinition> DocumentDefinition { get; set; }
        public virtual DbSet<AtlasModel.VitalSignAndNursingDefinition> VitalSignAndNursingDefinition { get; set; }
        public virtual DbSet<AtlasModel.DrugDefinition> DrugDefinition { get; set; }
        public virtual DbSet<AtlasModel.BudgetDef> BudgetDef { get; set; }
        public virtual DbSet<AtlasModel.QueueResourceWorkPlanDefinition> QueueResourceWorkPlanDefinition { get; set; }
        public virtual DbSet<AtlasModel.RadiologyTestDefinition> RadiologyTestDefinition { get; set; }
        public virtual DbSet<AtlasModel.DevredilenKurum> DevredilenKurum { get; set; }
        public virtual DbSet<AtlasModel.ResWard> ResWard { get; set; }
        public virtual DbSet<AtlasModel.ProcedurePriceDefinition> ProcedurePriceDefinition { get; set; }
        public virtual DbSet<AtlasModel.Store> Store { get; set; }
        public virtual DbSet<AtlasModel.ResSurgeryDesk> ResSurgeryDesk { get; set; }
        public virtual DbSet<AtlasModel.StockGuideCard> StockGuideCard { get; set; }
        public virtual DbSet<AtlasModel.ManuelEquivalentDrug> ManuelEquivalentDrug { get; set; }
        public virtual DbSet<AtlasModel.MHRSActionTypeDefinition> MHRSActionTypeDefinition { get; set; }
        public virtual DbSet<AtlasModel.RadiologyTestTypeDefinition> RadiologyTestTypeDefinition { get; set; }
        public virtual DbSet<AtlasModel.PayerDefinition> PayerDefinition { get; set; }
        public virtual DbSet<AtlasModel.SOSUygulamaKodu> SOSUygulamaKodu { get; set; }
        public virtual DbSet<AtlasModel.ResUser> ResUser { get; set; }
        public virtual DbSet<AtlasModel.BudgetTypeDefinition> BudgetTypeDefinition { get; set; }
        public virtual DbSet<AtlasModel.StockCard> StockCard { get; set; }
        public virtual DbSet<AtlasModel.ExaminationQueueHistory> ExaminationQueueHistory { get; set; }
        public virtual DbSet<AtlasModel.Person> Person { get; set; }
        public virtual DbSet<AtlasModel.CancelledInvoice> CancelledInvoice { get; set; }
        public virtual DbSet<AtlasModel.ConsultationTreatmentMaterial> ConsultationTreatmentMaterial { get; set; }
        public virtual DbSet<AtlasModel.PatientFolderTransaction> PatientFolderTransaction { get; set; }
        public virtual DbSet<AtlasModel.BaseAdditionalApplication> BaseAdditionalApplication { get; set; }
        public virtual DbSet<AtlasModel.ExtendExpirationDate> ExtendExpirationDate { get; set; }
        public virtual DbSet<AtlasModel.HCExaminationComponent> HCExaminationComponent { get; set; }
        public virtual DbSet<AtlasModel.RTFTemplate> RTFTemplate { get; set; }
        public virtual DbSet<AtlasModel.ReviewAction> ReviewAction { get; set; }
        public virtual DbSet<AtlasModel.ReviewActionDetail> ReviewActionDetail { get; set; }
        public virtual DbSet<AtlasModel.PatientOwnDrugTrxDetail> PatientOwnDrugTrxDetail { get; set; }
        public virtual DbSet<AtlasModel.NursingPainScale> NursingPainScale { get; set; }
        public virtual DbSet<AtlasModel.ManipulationProcedure> ManipulationProcedure { get; set; }
        public virtual DbSet<AtlasModel.AmputeeAssessmentForm> AmputeeAssessmentForm { get; set; }
        public virtual DbSet<AtlasModel.NursingInitiative> NursingInitiative { get; set; }
        public virtual DbSet<AtlasModel.AnesthesiaProcedure> AnesthesiaProcedure { get; set; }
        public virtual DbSet<AtlasModel.Surgery> Surgery { get; set; }
        public virtual DbSet<AtlasModel.Schedule> Schedule { get; set; }
        public virtual DbSet<AtlasModel.AdmissionAppointment> AdmissionAppointment { get; set; }
        public virtual DbSet<AtlasModel.OrthesisProthesisRequestTreatmentMaterial> OrthesisProthesisRequestTreatmentMaterial { get; set; }
        public virtual DbSet<AtlasModel.OrthesisProsthesis_ReturnDescriptionsGrid> OrthesisProsthesis_ReturnDescriptionsGrid { get; set; }
        public virtual DbSet<AtlasModel.GrantMaterialDetail> GrantMaterialDetail { get; set; }
        public virtual DbSet<AtlasModel.EmergencyPatientStatusInfo> EmergencyPatientStatusInfo { get; set; }
        public virtual DbSet<AtlasModel.CompanionProcedure> CompanionProcedure { get; set; }
        public virtual DbSet<AtlasModel.StockActionDetailIn> StockActionDetailIn { get; set; }
        public virtual DbSet<AtlasModel.BaseNursingOrderDetails> BaseNursingOrderDetails { get; set; }
        public virtual DbSet<AtlasModel.SubactionProcedureFlowable> SubactionProcedureFlowable { get; set; }
        public virtual DbSet<AtlasModel.StockCensusCardDrawer> StockCensusCardDrawer { get; set; }
        public virtual DbSet<AtlasModel.SurgeryExpend> SurgeryExpend { get; set; }
        public virtual DbSet<AtlasModel.SendToDoctorPerformance> SendToDoctorPerformance { get; set; }
        public virtual DbSet<AtlasModel.AnesthesiaConsultationProcedure> AnesthesiaConsultationProcedure { get; set; }
        public virtual DbSet<AtlasModel.DocumentRecordLog> DocumentRecordLog { get; set; }
        public virtual DbSet<AtlasModel.ChattelDocumentOutputDetailWithAccountancy> ChattelDocumentOutputDetailWithAccountancy { get; set; }
        public virtual DbSet<AtlasModel.AccountTransaction> AccountTransaction { get; set; }
        public virtual DbSet<AtlasModel.DailyDrugUnDrug> DailyDrugUnDrug { get; set; }
        public virtual DbSet<AtlasModel.DailyDrugSchOrderDetail> DailyDrugSchOrderDetail { get; set; }
        public virtual DbSet<AtlasModel.DailyDrugUnDrugDet> DailyDrugUnDrugDet { get; set; }
        public virtual DbSet<AtlasModel.ResponseOfENabiz> ResponseOfENabiz { get; set; }
        public virtual DbSet<AtlasModel.SendMessageToPatient> SendMessageToPatient { get; set; }
        public virtual DbSet<AtlasModel.StockIn> StockIn { get; set; }
        public virtual DbSet<AtlasModel.AccountDocumentDetail> AccountDocumentDetail { get; set; }
        public virtual DbSet<AtlasModel.PatientExamination> PatientExamination { get; set; }
        public virtual DbSet<AtlasModel.SurgeryPersonnel> SurgeryPersonnel { get; set; }
        public virtual DbSet<AtlasModel.DentalExaminationTreatmentMaterial> DentalExaminationTreatmentMaterial { get; set; }
        public virtual DbSet<AtlasModel.SendToENabiz> SendToENabiz { get; set; }
        public virtual DbSet<AtlasModel.BasePhysiotherapyOrder> BasePhysiotherapyOrder { get; set; }
        public virtual DbSet<AtlasModel.ChattelDocumentDetailWithPurchase> ChattelDocumentDetailWithPurchase { get; set; }
        public virtual DbSet<AtlasModel.MemberOfHealthCommiittee> MemberOfHealthCommiittee { get; set; }
        public virtual DbSet<AtlasModel.MedicalInformation> MedicalInformation { get; set; }
        public virtual DbSet<AtlasModel.MedicalInfoContiniousDrugs> MedicalInfoContiniousDrugs { get; set; }
        public virtual DbSet<AtlasModel.MedicalInfoHabits> MedicalInfoHabits { get; set; }
        public virtual DbSet<AtlasModel.LaboratoryProcedure> LaboratoryProcedure { get; set; }
        public virtual DbSet<AtlasModel.VaccineFollowUp> VaccineFollowUp { get; set; }
        public virtual DbSet<AtlasModel.PhysiotherapyOrder> PhysiotherapyOrder { get; set; }
        public virtual DbSet<AtlasModel.VaccineDetails> VaccineDetails { get; set; }
        public virtual DbSet<AtlasModel.ESWLReport> ESWLReport { get; set; }
        public virtual DbSet<AtlasModel.HBTReport> HBTReport { get; set; }
        public virtual DbSet<AtlasModel.DialysisReport> DialysisReport { get; set; }
        public virtual DbSet<AtlasModel.HomeHemodialysisReport> HomeHemodialysisReport { get; set; }
        public virtual DbSet<AtlasModel.TubeBabyReport> TubeBabyReport { get; set; }
        public virtual DbSet<AtlasModel.UserMessageAttachment> UserMessageAttachment { get; set; }
        public virtual DbSet<AtlasModel.StockFirstTransferDetail> StockFirstTransferDetail { get; set; }
        public virtual DbSet<AtlasModel.DailyActivityTestsForm> DailyActivityTestsForm { get; set; }
        public virtual DbSet<AtlasModel.AppointmentWithoutResource> AppointmentWithoutResource { get; set; }
        public virtual DbSet<AtlasModel.OccupationalAssessmentForm> OccupationalAssessmentForm { get; set; }
        public virtual DbSet<AtlasModel.NeurophysiologicalAssessmentForm> NeurophysiologicalAssessmentForm { get; set; }
        public virtual DbSet<AtlasModel.RadiologyTest> RadiologyTest { get; set; }
        public virtual DbSet<AtlasModel.PostureAnalysisForm> PostureAnalysisForm { get; set; }
        public virtual DbSet<AtlasModel.ScoliosisAssessmentForm> ScoliosisAssessmentForm { get; set; }
        public virtual DbSet<AtlasModel.GaitAnalysisForm> GaitAnalysisForm { get; set; }
        public virtual DbSet<AtlasModel.KSchedulePatienOwnDrug> KSchedulePatienOwnDrug { get; set; }
        public virtual DbSet<AtlasModel.GaitAnalysisComputerBasedForm> GaitAnalysisComputerBasedForm { get; set; }
        public virtual DbSet<AtlasModel.BaseAdditionalInfo> BaseAdditionalInfo { get; set; }
        public virtual DbSet<AtlasModel.DiagnosisSubEpisode> DiagnosisSubEpisode { get; set; }
        public virtual DbSet<AtlasModel.MedicalStuff> MedicalStuff { get; set; }
        public virtual DbSet<AtlasModel.NursingNutritionalRiskAssessment> NursingNutritionalRiskAssessment { get; set; }
        public virtual DbSet<AtlasModel.MkysCensusSyncData> MkysCensusSyncData { get; set; }
        public virtual DbSet<AtlasModel.ManipulationRequest> ManipulationRequest { get; set; }
        public virtual DbSet<AtlasModel.HealthCommitteeProcedure> HealthCommitteeProcedure { get; set; }
        public virtual DbSet<AtlasModel.EmergencyInterventionDoctorGroup> EmergencyInterventionDoctorGroup { get; set; }
        public virtual DbSet<AtlasModel.SurgeryProcedure> SurgeryProcedure { get; set; }
        public virtual DbSet<AtlasModel.SurgeryResponsibleDoctor> SurgeryResponsibleDoctor { get; set; }
        public virtual DbSet<AtlasModel.ResourcesToBeReferredGrid> ResourcesToBeReferredGrid { get; set; }
        public virtual DbSet<AtlasModel.Respiration> Respiration { get; set; }
        public virtual DbSet<AtlasModel.PatientInterviewForm> PatientInterviewForm { get; set; }
        public virtual DbSet<AtlasModel.EpisodeFolderTransaction> EpisodeFolderTransaction { get; set; }
        public virtual DbSet<AtlasModel.KScheduleMaterial> KScheduleMaterial { get; set; }
        public virtual DbSet<AtlasModel.EpisodeAccountAction> EpisodeAccountAction { get; set; }
        public virtual DbSet<AtlasModel.UploadedDocument> UploadedDocument { get; set; }
        public virtual DbSet<AtlasModel.PainScaleIncreaseGrid> PainScaleIncreaseGrid { get; set; }
        public virtual DbSet<AtlasModel.PainScaleDecreaseGrid> PainScaleDecreaseGrid { get; set; }
        public virtual DbSet<AtlasModel.TreatmentDischarge> TreatmentDischarge { get; set; }
        public virtual DbSet<AtlasModel.StockControl> StockControl { get; set; }
        public virtual DbSet<AtlasModel.StoreLocation> StoreLocation { get; set; }
        public virtual DbSet<AtlasModel.PathologyMaterial> PathologyMaterial { get; set; }
        public virtual DbSet<AtlasModel.MedulaTreatmentReport> MedulaTreatmentReport { get; set; }
        public virtual DbSet<AtlasModel.ReturnDescriptionsGrid> ReturnDescriptionsGrid { get; set; }
        public virtual DbSet<AtlasModel.DrugReturnAction> DrugReturnAction { get; set; }
        public virtual DbSet<AtlasModel.InpatientResponsibleNurse> InpatientResponsibleNurse { get; set; }
        public virtual DbSet<AtlasModel.PatientAdmission> PatientAdmission { get; set; }
        public virtual DbSet<AtlasModel.DiagnosisGrid> DiagnosisGrid { get; set; }
        public virtual DbSet<AtlasModel.OutPatientPrescription> OutPatientPrescription { get; set; }
        public virtual DbSet<AtlasModel.SubActionPackageProcedure> SubActionPackageProcedure { get; set; }
        public virtual DbSet<AtlasModel.DiyabetVeriSeti> DiyabetVeriSeti { get; set; }
        public virtual DbSet<AtlasModel.DiyabetKompBilgisi> DiyabetKompBilgisi { get; set; }
        public virtual DbSet<AtlasModel.BaseSurgeryProcedure> BaseSurgeryProcedure { get; set; }
        public virtual DbSet<AtlasModel.KSchedule> KSchedule { get; set; }
        public virtual DbSet<AtlasModel.SensoryPerceptionAssessmentForm> SensoryPerceptionAssessmentForm { get; set; }
        public virtual DbSet<AtlasModel.BaseTreatmentMaterial> BaseTreatmentMaterial { get; set; }
        public virtual DbSet<AtlasModel.StockCensus> StockCensus { get; set; }
        public virtual DbSet<AtlasModel.RangeOfMotionMeasurementForm> RangeOfMotionMeasurementForm { get; set; }
        public virtual DbSet<AtlasModel.ManualDexterityTestsForm> ManualDexterityTestsForm { get; set; }
        public virtual DbSet<AtlasModel.CashOfficeReceiptDocument> CashOfficeReceiptDocument { get; set; }
        public virtual DbSet<AtlasModel.InpatientResponsibleDoctor> InpatientResponsibleDoctor { get; set; }
        public virtual DbSet<AtlasModel.Pathology> Pathology { get; set; }
        public virtual DbSet<AtlasModel.StockOutMaterial> StockOutMaterial { get; set; }
        public virtual DbSet<AtlasModel.StockTransactionDetail> StockTransactionDetail { get; set; }
        public virtual DbSet<AtlasModel.ResponseOfENabizWOSYS> ResponseOfENabizWOSYS { get; set; }
        public virtual DbSet<AtlasModel.UTSNotificationDetail> UTSNotificationDetail { get; set; }
        public virtual DbSet<AtlasModel.StockActionDetailOut> StockActionDetailOut { get; set; }
        public virtual DbSet<AtlasModel.DPMaster> DPMaster { get; set; }
        public virtual DbSet<AtlasModel.DPDetail> DPDetail { get; set; }
        public virtual DbSet<AtlasModel.IntensiveCareSpecialityObj> IntensiveCareSpecialityObj { get; set; }
        public virtual DbSet<AtlasModel.SigortaliAdliGecmisi> SigortaliAdliGecmisi { get; set; }
        public virtual DbSet<AtlasModel.StockActionDateCorrection> StockActionDateCorrection { get; set; }
        public virtual DbSet<AtlasModel.MedicalInfoDisabledGroup> MedicalInfoDisabledGroup { get; set; }
        public virtual DbSet<AtlasModel.PatientPaymentDetail> PatientPaymentDetail { get; set; }
        public virtual DbSet<AtlasModel.PsychologyBasedObject> PsychologyBasedObject { get; set; }
        public virtual DbSet<AtlasModel.ServiceLogInfo> ServiceLogInfo { get; set; }
        public virtual DbSet<AtlasModel.PsychologicExamination> PsychologicExamination { get; set; }
        public virtual DbSet<AtlasModel.CheckRadWorkListFirstTime> CheckRadWorkListFirstTime { get; set; }
        public virtual DbSet<AtlasModel.UserTemplate> UserTemplate { get; set; }
        public virtual DbSet<AtlasModel.EmergencyInterventionProcedure> EmergencyInterventionProcedure { get; set; }
        public virtual DbSet<AtlasModel.PsychologyAuthorizedUser> PsychologyAuthorizedUser { get; set; }
        public virtual DbSet<AtlasModel.BaseNursingSystemInterrogation> BaseNursingSystemInterrogation { get; set; }
        public virtual DbSet<AtlasModel.UserBasedGridColumnOption> UserBasedGridColumnOption { get; set; }
        public virtual DbSet<AtlasModel.ResponsibleUsersGrid> ResponsibleUsersGrid { get; set; }
        public virtual DbSet<AtlasModel.ManipulationFormBaseObject> ManipulationFormBaseObject { get; set; }
        public virtual DbSet<AtlasModel.EkokardiografiFormObject> EkokardiografiFormObject { get; set; }
        public virtual DbSet<AtlasModel.MitralKapakBulgu> MitralKapakBulgu { get; set; }
        public virtual DbSet<AtlasModel.AortKapakBulgu> AortKapakBulgu { get; set; }
        public virtual DbSet<AtlasModel.TrikuspitKapakBulgu> TrikuspitKapakBulgu { get; set; }
        public virtual DbSet<AtlasModel.PulmonerKapakBulgu> PulmonerKapakBulgu { get; set; }
        public virtual DbSet<AtlasModel.EkokardiografiBulgu> EkokardiografiBulgu { get; set; }
        public virtual DbSet<AtlasModel.NursingCareGrid> NursingCareGrid { get; set; }
        public virtual DbSet<AtlasModel.DistributionDepStore> DistributionDepStore { get; set; }
        public virtual DbSet<AtlasModel.NursingTargetGrid> NursingTargetGrid { get; set; }
        public virtual DbSet<AtlasModel.NursingReasonGrid> NursingReasonGrid { get; set; }
        public virtual DbSet<AtlasModel.DrugOrder> DrugOrder { get; set; }
        public virtual DbSet<AtlasModel.PhysiotherapySessionInfo> PhysiotherapySessionInfo { get; set; }
        public virtual DbSet<AtlasModel.NursingFallingDownRisk> NursingFallingDownRisk { get; set; }
        public virtual DbSet<AtlasModel.PMAddingProcedure> PMAddingProcedure { get; set; }
        public virtual DbSet<AtlasModel.AuthorizedUser> AuthorizedUser { get; set; }
        public virtual DbSet<AtlasModel.AccountDayTerm> AccountDayTerm { get; set; }
        public virtual DbSet<AtlasModel.StockPrescriptionDetail> StockPrescriptionDetail { get; set; }
        public virtual DbSet<AtlasModel.DrugOrderCollectedTrx> DrugOrderCollectedTrx { get; set; }
        public virtual DbSet<AtlasModel.ExtendExpDateOutDetail> ExtendExpDateOutDetail { get; set; }
        public virtual DbSet<AtlasModel.DrugOrderTransactionDetail> DrugOrderTransactionDetail { get; set; }
        public virtual DbSet<AtlasModel.IIMDetail> IIMDetail { get; set; }
        public virtual DbSet<AtlasModel.Height> Height { get; set; }
        public virtual DbSet<AtlasModel.SkinPrickTestResult> SkinPrickTestResult { get; set; }
        public virtual DbSet<AtlasModel.InpatientDrugOrder> InpatientDrugOrder { get; set; }
        public virtual DbSet<AtlasModel.SkinPrickTestDetail> SkinPrickTestDetail { get; set; }
        public virtual DbSet<AtlasModel.CheckRadWorkListSecondTime> CheckRadWorkListSecondTime { get; set; }
        public virtual DbSet<AtlasModel.PatientExaminationTreatmentMaterial> PatientExaminationTreatmentMaterial { get; set; }
        public virtual DbSet<AtlasModel.SendSMSForEmerGencyIntervention> SendSMSForEmerGencyIntervention { get; set; }
        public virtual DbSet<AtlasModel.ENabizMaterial> ENabizMaterial { get; set; }
        public virtual DbSet<AtlasModel.Appointment> Appointment { get; set; }
        public virtual DbSet<AtlasModel.ReceiptDocument> ReceiptDocument { get; set; }
        public virtual DbSet<AtlasModel.Radiology> Radiology { get; set; }
        public virtual DbSet<AtlasModel.StockOut> StockOut { get; set; }
        public virtual DbSet<AtlasModel.AdditionalReport> AdditionalReport { get; set; }
        public virtual DbSet<AtlasModel.DentalProsthesisRequestSuggestedProsthesis> DentalProsthesisRequestSuggestedProsthesis { get; set; }
        public virtual DbSet<AtlasModel.APRTrx> APRTrx { get; set; }
        public virtual DbSet<AtlasModel.EmergencySpecialityObject> EmergencySpecialityObject { get; set; }
        public virtual DbSet<AtlasModel.MainStoreStockTransfer> MainStoreStockTransfer { get; set; }
        public virtual DbSet<AtlasModel.DentalCommitment> DentalCommitment { get; set; }
        public virtual DbSet<AtlasModel.PsychologyTest> PsychologyTest { get; set; }
        public virtual DbSet<AtlasModel.SendSMSResponsiblePATDelay> SendSMSResponsiblePATDelay { get; set; }
        public virtual DbSet<AtlasModel.SendSMSChiefPATDelay> SendSMSChiefPATDelay { get; set; }
        public virtual DbSet<AtlasModel.DynamicFormRevisionParam> DynamicFormRevisionParam { get; set; }
        public virtual DbSet<AtlasModel.DynamicFormSavedParam> DynamicFormSavedParam { get; set; }
        public virtual DbSet<AtlasModel.MainStoreStockTransferMat> MainStoreStockTransferMat { get; set; }
        public virtual DbSet<AtlasModel.SohaRuleRepoUpdate> SohaRuleRepoUpdate { get; set; }
        public virtual DbSet<AtlasModel.RequestUnitOfProcedureForm> RequestUnitOfProcedureForm { get; set; }
        public virtual DbSet<AtlasModel.BaseSurgeryAndManipulationProcedure> BaseSurgeryAndManipulationProcedure { get; set; }
        public virtual DbSet<AtlasModel.NursingWoundedAssesment> NursingWoundedAssesment { get; set; }
        public virtual DbSet<AtlasModel.HCExaminationDisabledRatio> HCExaminationDisabledRatio { get; set; }
        public virtual DbSet<AtlasModel.WoundPhoto> WoundPhoto { get; set; }
        public virtual DbSet<AtlasModel.SocServAppliedProcedures> SocServAppliedProcedures { get; set; }
        public virtual DbSet<AtlasModel.AccountPayableReceivable> AccountPayableReceivable { get; set; }
        public virtual DbSet<AtlasModel.StockInMaterial> StockInMaterial { get; set; }
        public virtual DbSet<AtlasModel.FileCreationAndAnalysis> FileCreationAndAnalysis { get; set; }
        public virtual DbSet<AtlasModel.PatientFolder> PatientFolder { get; set; }
        public virtual DbSet<AtlasModel.LaboratoryRequest> LaboratoryRequest { get; set; }
        public virtual DbSet<AtlasModel.AppointmentCarrier> AppointmentCarrier { get; set; }
        public virtual DbSet<AtlasModel.BaseDentalEpisodeActionDiagnosisGrid> BaseDentalEpisodeActionDiagnosisGrid { get; set; }
        public virtual DbSet<AtlasModel.PhysiotherapyTreatmentUnitGrid> PhysiotherapyTreatmentUnitGrid { get; set; }
        public virtual DbSet<AtlasModel.NursingPupilSymptoms> NursingPupilSymptoms { get; set; }
        public virtual DbSet<AtlasModel.DrugSpecifications> DrugSpecifications { get; set; }
        public virtual DbSet<AtlasModel.UserOption> UserOption { get; set; }
        public virtual DbSet<AtlasModel.MainStoreProductionConsumptionDocumentMaterial> MainStoreProductionConsumptionDocumentMaterial { get; set; }
        public virtual DbSet<AtlasModel.BulasiciHastaliklarEA> BulasiciHastaliklarEA { get; set; }
        public virtual DbSet<AtlasModel.KScheduleInfectionDrug> KScheduleInfectionDrug { get; set; }
        public virtual DbSet<AtlasModel.Notification> Notification { get; set; }
        public virtual DbSet<AtlasModel.Allocation> Allocation { get; set; }
        public virtual DbSet<AtlasModel.NotificationUser> NotificationUser { get; set; }
        public virtual DbSet<AtlasModel.DynamicReport> DynamicReport { get; set; }
        public virtual DbSet<AtlasModel.Manipulation> Manipulation { get; set; }
        public virtual DbSet<AtlasModel.DynamicReportRevision> DynamicReportRevision { get; set; }
        public virtual DbSet<AtlasModel.StoreSMSUser> StoreSMSUser { get; set; }
        public virtual DbSet<AtlasModel.ResUserUsableStore> ResUserUsableStore { get; set; }
        public virtual DbSet<AtlasModel.BedProcedure> BedProcedure { get; set; }
        public virtual DbSet<AtlasModel.EyeExamination> EyeExamination { get; set; }
        public virtual DbSet<AtlasModel.BaseNursingOrder> BaseNursingOrder { get; set; }
        public virtual DbSet<AtlasModel.NursingLegMeasurement> NursingLegMeasurement { get; set; }
        public virtual DbSet<AtlasModel.IIMNQLProcedureMaterial> IIMNQLProcedureMaterial { get; set; }
        public virtual DbSet<AtlasModel.DistributionDepStoreMat> DistributionDepStoreMat { get; set; }
        public virtual DbSet<AtlasModel.PatientExaminationDoctorInfo> PatientExaminationDoctorInfo { get; set; }
        public virtual DbSet<AtlasModel.DentalCommitmentProsthesis> DentalCommitmentProsthesis { get; set; }
        public virtual DbSet<AtlasModel.FormParam> FormParam { get; set; }
        public virtual DbSet<AtlasModel.WomanSpecialityObject> WomanSpecialityObject { get; set; }
        public virtual DbSet<AtlasModel.SurgeryRejectReason> SurgeryRejectReason { get; set; }
        public virtual DbSet<AtlasModel.SendSMSWorkHealthSecWarn> SendSMSWorkHealthSecWarn { get; set; }
        public virtual DbSet<AtlasModel.DrugDrugInteraction> DrugDrugInteraction { get; set; }
        public virtual DbSet<AtlasModel.DrugFoodInteraction> DrugFoodInteraction { get; set; }
        public virtual DbSet<AtlasModel.Gynecology> Gynecology { get; set; }
        public virtual DbSet<AtlasModel.SubactionProcedureSMSInfo> SubactionProcedureSMSInfo { get; set; }
        public virtual DbSet<AtlasModel.PatientOwnDrugReturn> PatientOwnDrugReturn { get; set; }
        public virtual DbSet<AtlasModel.CreatingEpicrisis> CreatingEpicrisis { get; set; }
        public virtual DbSet<AtlasModel.MKYSTrx> MKYSTrx { get; set; }
        public virtual DbSet<AtlasModel.MKYSTrxDetail> MKYSTrxDetail { get; set; }
        public virtual DbSet<AtlasModel.ReceiptProcedure> ReceiptProcedure { get; set; }
        public virtual DbSet<AtlasModel.ManagerPrescriptionCounts> ManagerPrescriptionCounts { get; set; }
        public virtual DbSet<AtlasModel.EquivalentConsMaterial> EquivalentConsMaterial { get; set; }
        public virtual DbSet<AtlasModel.Patient> Patient { get; set; }
        public virtual DbSet<AtlasModel.PregnantInformation> PregnantInformation { get; set; }
        public virtual DbSet<AtlasModel.BaseHealthCommittee> BaseHealthCommittee { get; set; }
        public virtual DbSet<AtlasModel.EpisodeActionSMSInfo> EpisodeActionSMSInfo { get; set; }
        public virtual DbSet<AtlasModel.ChemotherapyRadiotherapy> ChemotherapyRadiotherapy { get; set; }
        public virtual DbSet<AtlasModel.PayerInvoiceDocument> PayerInvoiceDocument { get; set; }
        public virtual DbSet<AtlasModel.LaboratorySubProcedure> LaboratorySubProcedure { get; set; }
        public virtual DbSet<AtlasModel.MedicalOncology> MedicalOncology { get; set; }
        public virtual DbSet<AtlasModel.NursingOrder> NursingOrder { get; set; }
        public virtual DbSet<AtlasModel.MedicalResarch> MedicalResarch { get; set; }
        public virtual DbSet<AtlasModel.MedicalResarchDoctor> MedicalResarchDoctor { get; set; }
        public virtual DbSet<AtlasModel.MedicalResarchProcedur> MedicalResarchProcedur { get; set; }
        public virtual DbSet<AtlasModel.PatientLastUseDrug> PatientLastUseDrug { get; set; }
        public virtual DbSet<AtlasModel.HospitalsUnitsDefinitionGrid> HospitalsUnitsDefinitionGrid { get; set; }
        public virtual DbSet<AtlasModel.SendSMSDoctorPATDelay> SendSMSDoctorPATDelay { get; set; }
        public virtual DbSet<AtlasModel.TestObj> TestObj { get; set; }
        public virtual DbSet<AtlasModel.PeriodicOrder> PeriodicOrder { get; set; }
        public virtual DbSet<AtlasModel.DrugOrderTransaction> DrugOrderTransaction { get; set; }
        public virtual DbSet<AtlasModel.MainStoreDistributionDoc> MainStoreDistributionDoc { get; set; }
        public virtual DbSet<AtlasModel.MainStoreDistDocDetail> MainStoreDistDocDetail { get; set; }
        public virtual DbSet<AtlasModel.StockLocation> StockLocation { get; set; }
        public virtual DbSet<AtlasModel.GlaskowScore> GlaskowScore { get; set; }
        public virtual DbSet<AtlasModel.TraditionalMedicine> TraditionalMedicine { get; set; }
        public virtual DbSet<AtlasModel.TradititionalMedAppCases> TradititionalMedAppCases { get; set; }
        public virtual DbSet<AtlasModel.TraditionalMedAppRegion> TraditionalMedAppRegion { get; set; }
        public virtual DbSet<AtlasModel.SohaRuleLog> SohaRuleLog { get; set; }
        public virtual DbSet<AtlasModel.HealthCommittee> HealthCommittee { get; set; }
        public virtual DbSet<AtlasModel.AccountVoucher> AccountVoucher { get; set; }
        public virtual DbSet<AtlasModel.StockAction> StockAction { get; set; }
        public virtual DbSet<AtlasModel.SendSMSMaster> SendSMSMaster { get; set; }
        public virtual DbSet<AtlasModel.InPatientPhysicianMaterial> InPatientPhysicianMaterial { get; set; }
        public virtual DbSet<AtlasModel.IntendedUseOfDisabledReport> IntendedUseOfDisabledReport { get; set; }
        public virtual DbSet<AtlasModel.SendSMSDetail> SendSMSDetail { get; set; }
        public virtual DbSet<AtlasModel.ReturningDocumentMaterial> ReturningDocumentMaterial { get; set; }
        public virtual DbSet<AtlasModel.MedicalResarchPatientAd> MedicalResarchPatientAd { get; set; }
        public virtual DbSet<AtlasModel.MedicalResarchPatientEx> MedicalResarchPatientEx { get; set; }
        public virtual DbSet<AtlasModel.ChemoRadiotherapyMaterial> ChemoRadiotherapyMaterial { get; set; }
        public virtual DbSet<AtlasModel.MedicalResarchPatientExPro> MedicalResarchPatientExPro { get; set; }
        public virtual DbSet<AtlasModel.EStatusNotRepCommitteeObj> EStatusNotRepCommitteeObj { get; set; }
        public virtual DbSet<AtlasModel.DentalExaminationProcedure> DentalExaminationProcedure { get; set; }
        public virtual DbSet<AtlasModel.DynamicDataSourceParam> DynamicDataSourceParam { get; set; }
        public virtual DbSet<AtlasModel.DeleteRecordDocumentDestroyableMaterialOut> DeleteRecordDocumentDestroyableMaterialOut { get; set; }
        public virtual DbSet<AtlasModel.AnesthesiaResponsibleDoctor> AnesthesiaResponsibleDoctor { get; set; }
        public virtual DbSet<AtlasModel.UserInfo> UserInfo { get; set; }
        public virtual DbSet<AtlasModel.DentalExamination> DentalExamination { get; set; }
        public virtual DbSet<AtlasModel.InPatientTreatmentClinicApplication> InPatientTreatmentClinicApplication { get; set; }
        public virtual DbSet<AtlasModel.NursingAppliProgress> NursingAppliProgress { get; set; }
        public virtual DbSet<AtlasModel.ChemoRadioCureProtocol> ChemoRadioCureProtocol { get; set; }
        public virtual DbSet<AtlasModel.DynamicFormSubmission> DynamicFormSubmission { get; set; }
        public virtual DbSet<AtlasModel.MedicalWaste> MedicalWaste { get; set; }
        public virtual DbSet<AtlasModel.PhysiotherapyReports> PhysiotherapyReports { get; set; }
        public virtual DbSet<AtlasModel.DistributionDocumentMaterial> DistributionDocumentMaterial { get; set; }
        public virtual DbSet<AtlasModel.ChemoRadioCureProtocolDet> ChemoRadioCureProtocolDet { get; set; }
        public virtual DbSet<AtlasModel.TigEpisode> TigEpisode { get; set; }
        public virtual DbSet<AtlasModel.DynamicForm> DynamicForm { get; set; }
        public virtual DbSet<AtlasModel.InvoiceCollectionDocument> InvoiceCollectionDocument { get; set; }
        public virtual DbSet<AtlasModel.EDisabledReport> EDisabledReport { get; set; }
        public virtual DbSet<AtlasModel.InvoiceCollectionDocumentGroup> InvoiceCollectionDocumentGroup { get; set; }
        public virtual DbSet<AtlasModel.DynamicFormRevision> DynamicFormRevision { get; set; }
        public virtual DbSet<AtlasModel.BaseTemplate> BaseTemplate { get; set; }
        public virtual DbSet<AtlasModel.InvoiceCollectionDocumentDetail> InvoiceCollectionDocumentDetail { get; set; }
        public virtual DbSet<AtlasModel.DynamicDataSource> DynamicDataSource { get; set; }
        public virtual DbSet<AtlasModel.FormField> FormField { get; set; }
        public virtual DbSet<AtlasModel.DynamicFormRevisionField> DynamicFormRevisionField { get; set; }
        public virtual DbSet<AtlasModel.DynamicFormSavedValue> DynamicFormSavedValue { get; set; }
        public virtual DbSet<AtlasModel.CompanionApplication> CompanionApplication { get; set; }
        public virtual DbSet<AtlasModel.StockTrxUpdateAction> StockTrxUpdateAction { get; set; }
        public virtual DbSet<AtlasModel.DailyDrugSchedule> DailyDrugSchedule { get; set; }
        public virtual DbSet<AtlasModel.DynamicFormSavedJSON> DynamicFormSavedJSON { get; set; }
        public virtual DbSet<AtlasModel.StockTrxUpdateActionDetail> StockTrxUpdateActionDetail { get; set; }
        public virtual DbSet<AtlasModel.NursingSpiritualEvaluation> NursingSpiritualEvaluation { get; set; }
        public virtual DbSet<AtlasModel.EpisodeActionWithDiagnosis> EpisodeActionWithDiagnosis { get; set; }
        public virtual DbSet<AtlasModel.NursingOrderTemplateDetail> NursingOrderTemplateDetail { get; set; }
        public virtual DbSet<AtlasModel.NursingNutritionAssessment> NursingNutritionAssessment { get; set; }
        public virtual DbSet<AtlasModel.DailyDrugPatient> DailyDrugPatient { get; set; }
        public virtual DbSet<AtlasModel.NursingSystemInterrogation> NursingSystemInterrogation { get; set; }
        public virtual DbSet<AtlasModel.ReportDiagnosis> ReportDiagnosis { get; set; }
        public virtual DbSet<AtlasModel.BaseNursingDischargingInstructionPlan> BaseNursingDischargingInstructionPlan { get; set; }
        public virtual DbSet<AtlasModel.AccountDocumentGroup> AccountDocumentGroup { get; set; }
        public virtual DbSet<AtlasModel.KScheduleCollectedOrder> KScheduleCollectedOrder { get; set; }
        public virtual DbSet<AtlasModel.BaseHCExaminationDynamicObject> BaseHCExaminationDynamicObject { get; set; }
        public virtual DbSet<AtlasModel.PayerInvoiceDocumentDetail> PayerInvoiceDocumentDetail { get; set; }
        public virtual DbSet<AtlasModel.NursingDischargingInstructionPlan> NursingDischargingInstructionPlan { get; set; }
        public virtual DbSet<AtlasModel.BaseNursingFallingDownRisk> BaseNursingFallingDownRisk { get; set; }
        public virtual DbSet<AtlasModel.ScheduledTaskHistory> ScheduledTaskHistory { get; set; }
        public virtual DbSet<AtlasModel.SocServPatientFamilyInfo> SocServPatientFamilyInfo { get; set; }
        public virtual DbSet<AtlasModel.StockMerge> StockMerge { get; set; }
        public virtual DbSet<AtlasModel.OutPatientDrugOrder> OutPatientDrugOrder { get; set; }
        public virtual DbSet<AtlasModel.CollectiveInvoiceOp> CollectiveInvoiceOp { get; set; }
        public virtual DbSet<AtlasModel.NursingPatientAndFamilyInstruction> NursingPatientAndFamilyInstruction { get; set; }
        public virtual DbSet<AtlasModel.AccountingTerm> AccountingTerm { get; set; }
        public virtual DbSet<AtlasModel.CollectiveInvoiceOpDetail> CollectiveInvoiceOpDetail { get; set; }
        public virtual DbSet<AtlasModel.BaseNursingPatientAndFamilyInstruction> BaseNursingPatientAndFamilyInstruction { get; set; }
        public virtual DbSet<AtlasModel.LowerExtremity> LowerExtremity { get; set; }
        public virtual DbSet<AtlasModel.DrugReturnActionDetail> DrugReturnActionDetail { get; set; }
        public virtual DbSet<AtlasModel.NursingOrderDetail> NursingOrderDetail { get; set; }
        public virtual DbSet<AtlasModel.StockFirstInDetail> StockFirstInDetail { get; set; }
        public virtual DbSet<AtlasModel.SEPDiagnosis> SEPDiagnosis { get; set; }
        public virtual DbSet<AtlasModel.BaseInpatientAdmission> BaseInpatientAdmission { get; set; }
        public virtual DbSet<AtlasModel.ReceiptDocumentGroup> ReceiptDocumentGroup { get; set; }
        public virtual DbSet<AtlasModel.StockMergeMaterialOut> StockMergeMaterialOut { get; set; }
        public virtual DbSet<AtlasModel.MainSurgeryProcedure> MainSurgeryProcedure { get; set; }
        public virtual DbSet<AtlasModel.DistributeDetail> DistributeDetail { get; set; }
        public virtual DbSet<AtlasModel.NursingPatientPreAssessment> NursingPatientPreAssessment { get; set; }
        public virtual DbSet<AtlasModel.InfectionCommittee> InfectionCommittee { get; set; }
        public virtual DbSet<AtlasModel.DrugOrderForReport> DrugOrderForReport { get; set; }
        public virtual DbSet<AtlasModel.InfectionCommitteeDetail> InfectionCommitteeDetail { get; set; }
        public virtual DbSet<AtlasModel.BaseDietOrder> BaseDietOrder { get; set; }
        public virtual DbSet<AtlasModel.Morgue> Morgue { get; set; }
        public virtual DbSet<AtlasModel.DietOrder> DietOrder { get; set; }
        public virtual DbSet<AtlasModel.DrugOtherForm> DrugOtherForm { get; set; }
        public virtual DbSet<AtlasModel.StockMergeMaterialIn> StockMergeMaterialIn { get; set; }
        public virtual DbSet<AtlasModel.BaseMultipleDataEntry> BaseMultipleDataEntry { get; set; }
        public virtual DbSet<AtlasModel.ApacheScore> ApacheScore { get; set; }
        public virtual DbSet<AtlasModel.FTRPackageProcedure> FTRPackageProcedure { get; set; }
        public virtual DbSet<AtlasModel.StockCensusLevel> StockCensusLevel { get; set; }
        public virtual DbSet<AtlasModel.EpisodeFolder> EpisodeFolder { get; set; }
        public virtual DbSet<AtlasModel.BaseAction> BaseAction { get; set; }
        public virtual DbSet<AtlasModel.ExaminationQueueItem> ExaminationQueueItem { get; set; }
        public virtual DbSet<AtlasModel.DentalProcedure> DentalProcedure { get; set; }
        public virtual DbSet<AtlasModel.MedicalStuffReport> MedicalStuffReport { get; set; }
        public virtual DbSet<AtlasModel.AccountDocument> AccountDocument { get; set; }
        public virtual DbSet<AtlasModel.StatusNotificationReport> StatusNotificationReport { get; set; }
        public virtual DbSet<AtlasModel.VemRelation> VemRelation { get; set; }
        public virtual DbSet<AtlasModel.StockLevel> StockLevel { get; set; }
        public virtual DbSet<AtlasModel.InPatientPhysicianProgresses> InPatientPhysicianProgresses { get; set; }
        public virtual DbSet<AtlasModel.SubActionMaterial> SubActionMaterial { get; set; }
        public virtual DbSet<AtlasModel.DentalExaminationSuggestedProsthesis> DentalExaminationSuggestedProsthesis { get; set; }
        public virtual DbSet<AtlasModel.BloodBankBloodProducts> BloodBankBloodProducts { get; set; }
        public virtual DbSet<AtlasModel.BaseOrthesisProsthesisProcedure> BaseOrthesisProsthesisProcedure { get; set; }
        public virtual DbSet<AtlasModel.ChattelDocumentWithPurchase> ChattelDocumentWithPurchase { get; set; }
        public virtual DbSet<AtlasModel.Payment> Payment { get; set; }
        public virtual DbSet<AtlasModel.BaseBedProcedure> BaseBedProcedure { get; set; }
        public virtual DbSet<AtlasModel.TaniTeshisİliskisi> TaniTeshisİliskisi { get; set; }
        public virtual DbSet<AtlasModel.NursingGlaskowComaScale> NursingGlaskowComaScale { get; set; }
        public virtual DbSet<AtlasModel.NursingApplication> NursingApplication { get; set; }
        public virtual DbSet<AtlasModel.NursingFunctionalDailyLifeActivity> NursingFunctionalDailyLifeActivity { get; set; }
        public virtual DbSet<AtlasModel.BaseMedulaObject> BaseMedulaObject { get; set; }
        public virtual DbSet<AtlasModel.StockCensusDetail> StockCensusDetail { get; set; }
        public virtual DbSet<AtlasModel.BaseDataCorrection> BaseDataCorrection { get; set; }
        public virtual DbSet<AtlasModel.ParticipationFreeDrgGrid> ParticipationFreeDrgGrid { get; set; }
        public virtual DbSet<AtlasModel.SpecialPanelCriteriaValue> SpecialPanelCriteriaValue { get; set; }
        public virtual DbSet<AtlasModel.SpecialityBasedObject> SpecialityBasedObject { get; set; }
        public virtual DbSet<AtlasModel.SubEpisode> SubEpisode { get; set; }
        public virtual DbSet<AtlasModel.DailyBedProcedure> DailyBedProcedure { get; set; }
        public virtual DbSet<AtlasModel.ChildGrowthStandards> ChildGrowthStandards { get; set; }
        public virtual DbSet<AtlasModel.StockReservation> StockReservation { get; set; }
        public virtual DbSet<AtlasModel.SEPMaster> SEPMaster { get; set; }
        public virtual DbSet<AtlasModel.BaseAnesthesiaPersonnel> BaseAnesthesiaPersonnel { get; set; }
        public virtual DbSet<AtlasModel.ResUserTakeOffFromWork> ResUserTakeOffFromWork { get; set; }
        public virtual DbSet<AtlasModel.PhysicianApplication> PhysicianApplication { get; set; }
        public virtual DbSet<AtlasModel.IIMSpeciality> IIMSpeciality { get; set; }
        public virtual DbSet<AtlasModel.PatientAdmissionResourcesToBeReferred> PatientAdmissionResourcesToBeReferred { get; set; }
        public virtual DbSet<AtlasModel.MedulaReportResult> MedulaReportResult { get; set; }
        public virtual DbSet<AtlasModel.InvoiceLog> InvoiceLog { get; set; }
        public virtual DbSet<AtlasModel.ParticipatnFreeDrugReport> ParticipatnFreeDrugReport { get; set; }
        public virtual DbSet<AtlasModel.UserMessage> UserMessage { get; set; }
        public virtual DbSet<AtlasModel.SubStoreStockTransfer> SubStoreStockTransfer { get; set; }
        public virtual DbSet<AtlasModel.TemplateGroup> TemplateGroup { get; set; }
        public virtual DbSet<AtlasModel.PathologyTestProcedure> PathologyTestProcedure { get; set; }
        public virtual DbSet<AtlasModel.SubStoreStockTransferMat> SubStoreStockTransferMat { get; set; }
        public virtual DbSet<AtlasModel.BasePhysiotherapyOrderDetail> BasePhysiotherapyOrderDetail { get; set; }
        public virtual DbSet<AtlasModel.PatientOldDebt> PatientOldDebt { get; set; }
        public virtual DbSet<AtlasModel.BaseScheduledTask> BaseScheduledTask { get; set; }
        public virtual DbSet<AtlasModel.FavoriteDiagnosis> FavoriteDiagnosis { get; set; }
        public virtual DbSet<AtlasModel.SubactionProcedureWithDiagnosis> SubactionProcedureWithDiagnosis { get; set; }
        public virtual DbSet<AtlasModel.IIMProtocol> IIMProtocol { get; set; }
        public virtual DbSet<AtlasModel.AccountAction> AccountAction { get; set; }
        public virtual DbSet<AtlasModel.AnesthesiaPersonnel> AnesthesiaPersonnel { get; set; }
        public virtual DbSet<AtlasModel.EmergencyIntervention> EmergencyIntervention { get; set; }
        public virtual DbSet<AtlasModel.PayerInvoiceDocumentGroup> PayerInvoiceDocumentGroup { get; set; }
        public virtual DbSet<AtlasModel.Receipt> Receipt { get; set; }
        public virtual DbSet<AtlasModel.DailyDrugSchOrder> DailyDrugSchOrder { get; set; }
        public virtual DbSet<AtlasModel.ENabiz> ENabiz { get; set; }
        public virtual DbSet<AtlasModel.ChangeStockLevelType> ChangeStockLevelType { get; set; }
        public virtual DbSet<AtlasModel.Prescription> Prescription { get; set; }
        public virtual DbSet<AtlasModel.InPatientRtfBySpeciality> InPatientRtfBySpeciality { get; set; }
        public virtual DbSet<AtlasModel.HospitalTimeScheduleDetail> HospitalTimeScheduleDetail { get; set; }
        public virtual DbSet<AtlasModel.DispatchToOtherHospital> DispatchToOtherHospital { get; set; }
        public virtual DbSet<AtlasModel.InpatientAdmission> InpatientAdmission { get; set; }
        public virtual DbSet<AtlasModel.InPatientPhysicianApplication> InPatientPhysicianApplication { get; set; }
        public virtual DbSet<AtlasModel.PatientToken> PatientToken { get; set; }
        public virtual DbSet<AtlasModel.VaccinePeriodGrid> VaccinePeriodGrid { get; set; }
        public virtual DbSet<AtlasModel.OldDebtReceiptDocument> OldDebtReceiptDocument { get; set; }
        public virtual DbSet<AtlasModel.BloodPressure> BloodPressure { get; set; }
        public virtual DbSet<AtlasModel.RadiologyMaterial> RadiologyMaterial { get; set; }
        public virtual DbSet<AtlasModel.Pulse> Pulse { get; set; }
        public virtual DbSet<AtlasModel.StockFirstTransfer> StockFirstTransfer { get; set; }
        public virtual DbSet<AtlasModel.BaseNursingDataEntry> BaseNursingDataEntry { get; set; }
        public virtual DbSet<AtlasModel.StockCollectedTrx> StockCollectedTrx { get; set; }
        public virtual DbSet<AtlasModel.SurgeryExtension> SurgeryExtension { get; set; }
        public virtual DbSet<AtlasModel.Cash> Cash { get; set; }
        public virtual DbSet<AtlasModel.BaseDrugOrder> BaseDrugOrder { get; set; }
        public virtual DbSet<AtlasModel.LaboratoryProcedureTubeInfo> LaboratoryProcedureTubeInfo { get; set; }
        public virtual DbSet<AtlasModel.InpatientPhysicianApplicationAdditionalApplication> InpatientPhysicianApplicationAdditionalApplication { get; set; }
        public virtual DbSet<AtlasModel.NursingCare> NursingCare { get; set; }
        public virtual DbSet<AtlasModel.MHRSAdmissionAppointment> MHRSAdmissionAppointment { get; set; }
        public virtual DbSet<AtlasModel.BaseDentalEpisodeAction> BaseDentalEpisodeAction { get; set; }
        public virtual DbSet<AtlasModel.ScheduleAppointmentType> ScheduleAppointmentType { get; set; }
        public virtual DbSet<AtlasModel.ChangeStockLevelTypeDetail> ChangeStockLevelTypeDetail { get; set; }
        public virtual DbSet<AtlasModel.BedProcedureWithoutBed> BedProcedureWithoutBed { get; set; }
        public virtual DbSet<AtlasModel.StockActionInspection> StockActionInspection { get; set; }
        public virtual DbSet<AtlasModel.NursingApplicationTreatmentMaterial> NursingApplicationTreatmentMaterial { get; set; }
        public virtual DbSet<AtlasModel.OrthesisProsthesisRequest> OrthesisProsthesisRequest { get; set; }
        public virtual DbSet<AtlasModel.DPDetailLog> DPDetailLog { get; set; }
        public virtual DbSet<AtlasModel.ConsultationProcedure> ConsultationProcedure { get; set; }
        public virtual DbSet<AtlasModel.StockFirstIn> StockFirstIn { get; set; }
        public virtual DbSet<AtlasModel.DrugDeliveryAction> DrugDeliveryAction { get; set; }
        public virtual DbSet<AtlasModel.DrugDeliveryActionDetail> DrugDeliveryActionDetail { get; set; }
        public virtual DbSet<AtlasModel.PatientAuthorizedResource> PatientAuthorizedResource { get; set; }
        public virtual DbSet<AtlasModel.ChattelDocumentDistribution> ChattelDocumentDistribution { get; set; }
        public virtual DbSet<AtlasModel.BaseAnesthesiaProcedure> BaseAnesthesiaProcedure { get; set; }
        public virtual DbSet<AtlasModel.AccountTrxDocument> AccountTrxDocument { get; set; }
        public virtual DbSet<AtlasModel.BaseDeleteRecordDocumentDetail> BaseDeleteRecordDocumentDetail { get; set; }
        public virtual DbSet<AtlasModel.PeriodicOrderDetail> PeriodicOrderDetail { get; set; }
        public virtual DbSet<AtlasModel.StockActionInspectionDetail> StockActionInspectionDetail { get; set; }
        public virtual DbSet<AtlasModel.PatientIdentityAndAddress> PatientIdentityAndAddress { get; set; }
        public virtual DbSet<AtlasModel.ExtendExpirationDateDetail> ExtendExpirationDateDetail { get; set; }
        public virtual DbSet<AtlasModel.PatientOwnDrugEntry> PatientOwnDrugEntry { get; set; }
        public virtual DbSet<AtlasModel.PatientOwnDrugEntryDetail> PatientOwnDrugEntryDetail { get; set; }
        public virtual DbSet<AtlasModel.PatientOwnDrugTrx> PatientOwnDrugTrx { get; set; }
        public virtual DbSet<AtlasModel.PatientAdmissionCount> PatientAdmissionCount { get; set; }
        public virtual DbSet<AtlasModel.TestObject> TestObject { get; set; }
        public virtual DbSet<AtlasModel.BaseDietOrderDetail> BaseDietOrderDetail { get; set; }
        public virtual DbSet<AtlasModel.ReviewActionPatientDet> ReviewActionPatientDet { get; set; }
        public virtual DbSet<AtlasModel.EpisodeAction> EpisodeAction { get; set; }
        public virtual DbSet<AtlasModel.SubSurgery> SubSurgery { get; set; }
        public virtual DbSet<AtlasModel.NursingWoundAssessmentScale> NursingWoundAssessmentScale { get; set; }
        public virtual DbSet<AtlasModel.ESWTReport> ESWTReport { get; set; }
        public virtual DbSet<AtlasModel.InfectiousIllnesesInformation> InfectiousIllnesesInformation { get; set; }
        public virtual DbSet<AtlasModel.ReturningDocument> ReturningDocument { get; set; }
        public virtual DbSet<AtlasModel.DietOrderDetail> DietOrderDetail { get; set; }
        public virtual DbSet<AtlasModel.VitalSign> VitalSign { get; set; }
        public virtual DbSet<AtlasModel.MealTypes> MealTypes { get; set; }
        public virtual DbSet<AtlasModel.SPO2> SPO2 { get; set; }
        public virtual DbSet<AtlasModel.ChattelDocumentInputWithAccountancy> ChattelDocumentInputWithAccountancy { get; set; }
        public virtual DbSet<AtlasModel.NursingDailyLifeActivity> NursingDailyLifeActivity { get; set; }
        public virtual DbSet<AtlasModel.Temperature> Temperature { get; set; }
        public virtual DbSet<AtlasModel.SEPEpicrisis> SEPEpicrisis { get; set; }
        public virtual DbSet<AtlasModel.Weight> Weight { get; set; }
        public virtual DbSet<AtlasModel.ReceiptDocumentDetail> ReceiptDocumentDetail { get; set; }
        public virtual DbSet<AtlasModel.KronikHastaliklarVeriSeti> KronikHastaliklarVeriSeti { get; set; }
        public virtual DbSet<AtlasModel.MedicalInfoDrugAllergies> MedicalInfoDrugAllergies { get; set; }
        public virtual DbSet<AtlasModel.PlannedAction> PlannedAction { get; set; }
        public virtual DbSet<AtlasModel.DistributionTermAction> DistributionTermAction { get; set; }
        public virtual DbSet<AtlasModel.ConsultationFromExternalHospital> ConsultationFromExternalHospital { get; set; }
        public virtual DbSet<AtlasModel.FTRReportDetailGrid> FTRReportDetailGrid { get; set; }
        public virtual DbSet<AtlasModel.FTRReport> FTRReport { get; set; }
        public virtual DbSet<AtlasModel.BaseHealthCommittee_HospitalsUnitsGrid> BaseHealthCommittee_HospitalsUnitsGrid { get; set; }
        public virtual DbSet<AtlasModel.DistributionDocument> DistributionDocument { get; set; }
        public virtual DbSet<AtlasModel.PhysiotherapyRequest> PhysiotherapyRequest { get; set; }
        public virtual DbSet<AtlasModel.SubStoreConsumptionAction> SubStoreConsumptionAction { get; set; }
        public virtual DbSet<AtlasModel.SubStoreConsumptionDetail> SubStoreConsumptionDetail { get; set; }
        public virtual DbSet<AtlasModel.MainStoreProductionConsumptionDocument> MainStoreProductionConsumptionDocument { get; set; }
        public virtual DbSet<AtlasModel.CreditCard> CreditCard { get; set; }
        public virtual DbSet<AtlasModel.PatientExaminationProcedure> PatientExaminationProcedure { get; set; }
        public virtual DbSet<AtlasModel.ResourceSpecialityGrid> ResourceSpecialityGrid { get; set; }
        public virtual DbSet<AtlasModel.Episode> Episode { get; set; }
        public virtual DbSet<AtlasModel.AnesthesiaAndReanimation> AnesthesiaAndReanimation { get; set; }
        public virtual DbSet<AtlasModel.FavoriteDrug> FavoriteDrug { get; set; }
        public virtual DbSet<AtlasModel.ForensicMedicalReport> ForensicMedicalReport { get; set; }
        public virtual DbSet<AtlasModel.PatientExaminationAdditionalApplication> PatientExaminationAdditionalApplication { get; set; }
        public virtual DbSet<AtlasModel.StockLotDetail> StockLotDetail { get; set; }
        public virtual DbSet<AtlasModel.HospitalsUnitsGrid> HospitalsUnitsGrid { get; set; }
        public virtual DbSet<AtlasModel.ProcedureMaterialAdding> ProcedureMaterialAdding { get; set; }
        public virtual DbSet<AtlasModel.UserResource> UserResource { get; set; }
        public virtual DbSet<AtlasModel.KScheduleUnListMaterial> KScheduleUnListMaterial { get; set; }
        public virtual DbSet<AtlasModel.StockGuideCardDetail> StockGuideCardDetail { get; set; }
        public virtual DbSet<AtlasModel.OuttableLot> OuttableLot { get; set; }
        public virtual DbSet<AtlasModel.HealthCommitteeExaminationProcedure> HealthCommitteeExaminationProcedure { get; set; }
        public virtual DbSet<AtlasModel.MainCashOfficeOperation> MainCashOfficeOperation { get; set; }
        public virtual DbSet<AtlasModel.OldDrugOrder> OldDrugOrder { get; set; }
        public virtual DbSet<AtlasModel.ChattelDocumentInputDetailWithAccountancy> ChattelDocumentInputDetailWithAccountancy { get; set; }
        public virtual DbSet<AtlasModel.BaseChattelDocument> BaseChattelDocument { get; set; }
        public virtual DbSet<AtlasModel.ChattelDocumentOutputWithAccountancy> ChattelDocumentOutputWithAccountancy { get; set; }
        public virtual DbSet<AtlasModel.PathologyRequest> PathologyRequest { get; set; }
        public virtual DbSet<AtlasModel.DentalConsultationProcedure> DentalConsultationProcedure { get; set; }
        public virtual DbSet<AtlasModel.StockPrescriptionOut> StockPrescriptionOut { get; set; }
        public virtual DbSet<AtlasModel.StockPrescriptionOutMat> StockPrescriptionOutMat { get; set; }
        public virtual DbSet<AtlasModel.StockActionDetail> StockActionDetail { get; set; }
        public virtual DbSet<AtlasModel.CheckStockCensusAction> CheckStockCensusAction { get; set; }
        public virtual DbSet<AtlasModel.InpatientPrescription> InpatientPrescription { get; set; }
        public virtual DbSet<AtlasModel.SubEpisodeProtocol> SubEpisodeProtocol { get; set; }
        public virtual DbSet<AtlasModel.StockTransaction> StockTransaction { get; set; }
        public virtual DbSet<AtlasModel.EtkinMaddeDVO> EtkinMaddeDVO { get; set; }
        public virtual DbSet<AtlasModel.InvoiceCollectionDetail> InvoiceCollectionDetail { get; set; }
        public virtual DbSet<AtlasModel.MedicalInfoAllergies> MedicalInfoAllergies { get; set; }
        public virtual DbSet<AtlasModel.OutpatientPresDetail> OutpatientPresDetail { get; set; }
        public virtual DbSet<AtlasModel.OrthesisProsthesisProcedure> OrthesisProsthesisProcedure { get; set; }
        public virtual DbSet<AtlasModel.UserMessageGroupUsers> UserMessageGroupUsers { get; set; }
        public virtual DbSet<AtlasModel.DrugOrderIntroduction> DrugOrderIntroduction { get; set; }
        public virtual DbSet<AtlasModel.DrugOrderIntroductionDet> DrugOrderIntroductionDet { get; set; }
        public virtual DbSet<AtlasModel.SubActionProcedure> SubActionProcedure { get; set; }
        public virtual DbSet<AtlasModel.SurgeryPackageProcedure> SurgeryPackageProcedure { get; set; }
        public virtual DbSet<AtlasModel.InpatientPresDetail> InpatientPresDetail { get; set; }
        public virtual DbSet<AtlasModel.Consultation> Consultation { get; set; }
        public virtual DbSet<AtlasModel.DrugOrderDetail> DrugOrderDetail { get; set; }
        #endregion DbSet Properties
        private void ApplyEntityConfigurations(ModelBuilder modelBuilder)
        {

            #region Entity Configurations
            modelBuilder.ApplyConfiguration(new Configurations.InvoiceInclusionNQLConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResourceConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MainStoreDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.RevenueSubAccountCodeDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSKliniklerConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSKurumTuruConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockTransactionDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSRaporTuruConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ProcedureDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSICDOYERLESIMYERIConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MKYSMalzemeSiniflandirmaConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSAsiKoduConfig());
            modelBuilder.ApplyConfiguration(new Configurations.TaburcuKoduConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MenuDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.TerminologyManagerDefConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MKYS_ServisDepoConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MKYSKodConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ENabizPackageDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingTargetDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.LabGridSpecialityDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AccountPeriodDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.OlayAfetSMSGonderimConfig());
            modelBuilder.ApplyConfiguration(new Configurations.LCDNotificationDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.WoundStageDefConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SurgeryRobsonDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MalzemeGetDataConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseMedulaDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSTELETIPKurumOnEkBilgileriConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PathologyJarTypeDefConfig());
            modelBuilder.ApplyConfiguration(new Configurations.WoundLocalizationDefConfig());
            modelBuilder.ApplyConfiguration(new Configurations.WoundSideInfoConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSEnfeksiyonEtkeniConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSYOGUNBAKIMHASTATIPIConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSTibbiBiyokimyaAkilciTestIstemiListesiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSDavranisOnerisiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSEgitimMateryaliConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSSHMAltBirimConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSTaniTuruConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSTekrarTetkikIstemGerekcesiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSRadyolojikTetkikIstemPeriyoduListesiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSTakipTipiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSKronikHastalikBilgisiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSNTPTAKIPBILGISIConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSGKDTARAMASONUCUConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockTransactionCollectedDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSUCUMConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSOgrenciMuayeneIzlemIslemiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSOkulCagiPosturMuayeneBilgisiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSGormeTaramaSonucuConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSSUTVSConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSMalnutrisyonTedaviPlaniConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSOkulCagiGenclikIzlemTakvimiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SurgeryDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSMalnutrisyonDegerlendirmeBilgisiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ChemotherapyApplyMethodConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalResarchTermDefConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ChemotherapyApplySubMethodConfig());
            modelBuilder.ApplyConfiguration(new Configurations.LinenGroupConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSKanGrubuConfig());
            modelBuilder.ApplyConfiguration(new Configurations.LinenLocationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.LinenTypeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.RadiotherapyXRayTypeDefConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockLevelTypeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DPRuleMasterConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResDepartmentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DpRuleDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DpRuleProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DpRuleSpecialityConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DietMaterialDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugATCConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DefinitionConceptConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MaterialVatRateConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingCareDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ProcedureTypeDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSICDConfig());
            modelBuilder.ApplyConfiguration(new Configurations.OrtesisProsthesisDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PayerProtocolDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSIlacConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SystemParameterConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResObservationUnitConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientAdmissionStartedActionsConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SystemInterrogationDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.TeshisEtkinMaddeGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.RadiologyGridDepartmentDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResClinicConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientFolderContentDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MainCashOfficePaymentTypeDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DietDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedulaErrorCodeDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ProcedureTreeDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.RadiologyGridEquipmentDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalStuffDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InvoiceInclusionMasterConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResPoliclinicConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResSectionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SupplierConfig());
            modelBuilder.ApplyConfiguration(new Configurations.FallingDownRiskDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ExternalHospitalDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PhysiotherapyDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ActionDefaultMasterResourceGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DiagnosisDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DiagnosisDefTeshisConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResAdministrativeUnitConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PackageTemplateDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PackageTemplateICDDetailDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ActiveIngredientDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.WorkDayExceptionDefConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResBedConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InvoiceTermConfig());
            modelBuilder.ApplyConfiguration(new Configurations.OzelDurumConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSAFETOLAYTIPIConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResRoomGroupConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSPersonelBransKoduConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ReferableResourceConfig());
            modelBuilder.ApplyConfiguration(new Configurations.GuardFormationDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ConsumableMaterialDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.LaboratoryGridDepartmentDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PackageProcedureDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSKurumlarConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InvoiceBlockingDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MaterialTreeDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AppointmentDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSSUTConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResTreatmentDiagnosisUnitConfig());
            modelBuilder.ApplyConfiguration(new Configurations.UserOptionGroupConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SpecialPanelDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResSurgeryRoomConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSSistemKodlariConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingReasonDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingProblemReasonRelationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseSKRSCommonDefConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseSKRSDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSEnumMatchDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EmergencySurveyDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SubStoreDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.GuideBookDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MaterialPriceConfig());
            modelBuilder.ApplyConfiguration(new Configurations.LaboratoryGridPanelTestDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.LaboratoryGridBoundedTestDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSOlayAfetBilgisiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PackageTemplateProcReqFormDetailDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugActiveIngredientConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSMahalleKodlariConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSMSVSConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResHeaderShipConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSICDMSVSIliskisiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResRoomConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ProcedureRequestFormDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ProcedureRequestFormDetailDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ProcedureRequestCategoryDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSICDOMORFOLOJIKODUConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DoctorQuotaDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSICDOConfig());
            modelBuilder.ApplyConfiguration(new Configurations.OLDSKRSIlceConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ProducerConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResDivisionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ReasonForExaminationDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EstheticAlternativeProcedureDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.HCRequestReasonConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PackageTemplateProcedureDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.LaboratoryTestDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.WorkListDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AccountancyConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ExaminationQueueDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EtkinMaddeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockCardClassConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSIlceKodlariConfig());
            modelBuilder.ApplyConfiguration(new Configurations.VaccineDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DistributionTypeDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PricingDetailDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.TakeOffDatetimeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SKRSTibbiIslemPuanBilgisiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DocumentDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.VitalSignAndNursingDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BudgetDefConfig());
            modelBuilder.ApplyConfiguration(new Configurations.QueueResourceWorkPlanDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.RadiologyTestDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DevredilenKurumConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResWardConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ProcedurePriceDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StoreConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResSurgeryDeskConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockGuideCardConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ManuelEquivalentDrugConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MHRSActionTypeDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.RadiologyTestTypeDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PayerDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SOSUygulamaKoduConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResUserConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BudgetTypeDefinitionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockCardConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ExaminationQueueHistoryConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PersonConfig());
            modelBuilder.ApplyConfiguration(new Configurations.CancelledInvoiceConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ConsultationTreatmentMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientFolderTransactionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseAdditionalApplicationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ExtendExpirationDateConfig());
            modelBuilder.ApplyConfiguration(new Configurations.HCExaminationComponentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.RTFTemplateConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ReviewActionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ReviewActionDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientOwnDrugTrxDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingPainScaleConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ManipulationProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AmputeeAssessmentFormConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingInitiativeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AnesthesiaProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SurgeryConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ScheduleConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AdmissionAppointmentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.OrthesisProthesisRequestTreatmentMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.OrthesisProsthesis_ReturnDescriptionsGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.GrantMaterialDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EmergencyPatientStatusInfoConfig());
            modelBuilder.ApplyConfiguration(new Configurations.CompanionProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockActionDetailInConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseNursingOrderDetailsConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SubactionProcedureFlowableConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockCensusCardDrawerConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SurgeryExpendConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SendToDoctorPerformanceConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AnesthesiaConsultationProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DocumentRecordLogConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ChattelDocumentOutputDetailWithAccountancyConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AccountTransactionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DailyDrugUnDrugConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DailyDrugSchOrderDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DailyDrugUnDrugDetConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResponseOfENabizConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SendMessageToPatientConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockInConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AccountDocumentDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientExaminationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SurgeryPersonnelConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DentalExaminationTreatmentMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SendToENabizConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BasePhysiotherapyOrderConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ChattelDocumentDetailWithPurchaseConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MemberOfHealthCommiitteeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalInformationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalInfoContiniousDrugsConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalInfoHabitsConfig());
            modelBuilder.ApplyConfiguration(new Configurations.LaboratoryProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.VaccineFollowUpConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PhysiotherapyOrderConfig());
            modelBuilder.ApplyConfiguration(new Configurations.VaccineDetailsConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ESWLReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.HBTReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DialysisReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.HomeHemodialysisReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.TubeBabyReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.UserMessageAttachmentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockFirstTransferDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DailyActivityTestsFormConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AppointmentWithoutResourceConfig());
            modelBuilder.ApplyConfiguration(new Configurations.OccupationalAssessmentFormConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NeurophysiologicalAssessmentFormConfig());
            modelBuilder.ApplyConfiguration(new Configurations.RadiologyTestConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PostureAnalysisFormConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ScoliosisAssessmentFormConfig());
            modelBuilder.ApplyConfiguration(new Configurations.GaitAnalysisFormConfig());
            modelBuilder.ApplyConfiguration(new Configurations.KSchedulePatienOwnDrugConfig());
            modelBuilder.ApplyConfiguration(new Configurations.GaitAnalysisComputerBasedFormConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseAdditionalInfoConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DiagnosisSubEpisodeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalStuffConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingNutritionalRiskAssessmentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MkysCensusSyncDataConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ManipulationRequestConfig());
            modelBuilder.ApplyConfiguration(new Configurations.HealthCommitteeProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EmergencyInterventionDoctorGroupConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SurgeryProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SurgeryResponsibleDoctorConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResourcesToBeReferredGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.RespirationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientInterviewFormConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EpisodeFolderTransactionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.KScheduleMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EpisodeAccountActionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.UploadedDocumentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PainScaleIncreaseGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PainScaleDecreaseGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.TreatmentDischargeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockControlConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StoreLocationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PathologyMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedulaTreatmentReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ReturnDescriptionsGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugReturnActionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InpatientResponsibleNurseConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientAdmissionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DiagnosisGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.OutPatientPrescriptionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SubActionPackageProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DiyabetVeriSetiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DiyabetKompBilgisiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseSurgeryProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.KScheduleConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SensoryPerceptionAssessmentFormConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseTreatmentMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockCensusConfig());
            modelBuilder.ApplyConfiguration(new Configurations.RangeOfMotionMeasurementFormConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ManualDexterityTestsFormConfig());
            modelBuilder.ApplyConfiguration(new Configurations.CashOfficeReceiptDocumentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InpatientResponsibleDoctorConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PathologyConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockOutMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockTransactionDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResponseOfENabizWOSYSConfig());
            modelBuilder.ApplyConfiguration(new Configurations.UTSNotificationDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockActionDetailOutConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DPMasterConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DPDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.IntensiveCareSpecialityObjConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SigortaliAdliGecmisiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockActionDateCorrectionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalInfoDisabledGroupConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientPaymentDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PsychologyBasedObjectConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ServiceLogInfoConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PsychologicExaminationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.CheckRadWorkListFirstTimeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.UserTemplateConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EmergencyInterventionProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PsychologyAuthorizedUserConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseNursingSystemInterrogationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.UserBasedGridColumnOptionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResponsibleUsersGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ManipulationFormBaseObjectConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EkokardiografiFormObjectConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MitralKapakBulguConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AortKapakBulguConfig());
            modelBuilder.ApplyConfiguration(new Configurations.TrikuspitKapakBulguConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PulmonerKapakBulguConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EkokardiografiBulguConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingCareGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DistributionDepStoreConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingTargetGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingReasonGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugOrderConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PhysiotherapySessionInfoConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingFallingDownRiskConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PMAddingProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AuthorizedUserConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AccountDayTermConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockPrescriptionDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugOrderCollectedTrxConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ExtendExpDateOutDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugOrderTransactionDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.IIMDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.HeightConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SkinPrickTestResultConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InpatientDrugOrderConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SkinPrickTestDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.CheckRadWorkListSecondTimeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientExaminationTreatmentMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SendSMSForEmerGencyInterventionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ENabizMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AppointmentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ReceiptDocumentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.RadiologyConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockOutConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AdditionalReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DentalProsthesisRequestSuggestedProsthesisConfig());
            modelBuilder.ApplyConfiguration(new Configurations.APRTrxConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EmergencySpecialityObjectConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MainStoreStockTransferConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DentalCommitmentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PsychologyTestConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SendSMSResponsiblePATDelayConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SendSMSChiefPATDelayConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DynamicFormRevisionParamConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DynamicFormSavedParamConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MainStoreStockTransferMatConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SohaRuleRepoUpdateConfig());
            modelBuilder.ApplyConfiguration(new Configurations.RequestUnitOfProcedureFormConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseSurgeryAndManipulationProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingWoundedAssesmentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.HCExaminationDisabledRatioConfig());
            modelBuilder.ApplyConfiguration(new Configurations.WoundPhotoConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SocServAppliedProceduresConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AccountPayableReceivableConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockInMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.FileCreationAndAnalysisConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientFolderConfig());
            modelBuilder.ApplyConfiguration(new Configurations.LaboratoryRequestConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AppointmentCarrierConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseDentalEpisodeActionDiagnosisGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PhysiotherapyTreatmentUnitGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingPupilSymptomsConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugSpecificationsConfig());
            modelBuilder.ApplyConfiguration(new Configurations.UserOptionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MainStoreProductionConsumptionDocumentMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BulasiciHastaliklarEAConfig());
            modelBuilder.ApplyConfiguration(new Configurations.KScheduleInfectionDrugConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NotificationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AllocationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NotificationUserConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DynamicReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ManipulationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DynamicReportRevisionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StoreSMSUserConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResUserUsableStoreConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BedProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EyeExaminationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseNursingOrderConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingLegMeasurementConfig());
            modelBuilder.ApplyConfiguration(new Configurations.IIMNQLProcedureMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DistributionDepStoreMatConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientExaminationDoctorInfoConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DentalCommitmentProsthesisConfig());
            modelBuilder.ApplyConfiguration(new Configurations.FormParamConfig());
            modelBuilder.ApplyConfiguration(new Configurations.WomanSpecialityObjectConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SurgeryRejectReasonConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SendSMSWorkHealthSecWarnConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugDrugInteractionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugFoodInteractionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.GynecologyConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SubactionProcedureSMSInfoConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientOwnDrugReturnConfig());
            modelBuilder.ApplyConfiguration(new Configurations.CreatingEpicrisisConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MKYSTrxConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MKYSTrxDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ReceiptProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ManagerPrescriptionCountsConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EquivalentConsMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PregnantInformationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseHealthCommitteeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EpisodeActionSMSInfoConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ChemotherapyRadiotherapyConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PayerInvoiceDocumentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.LaboratorySubProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalOncologyConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingOrderConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalResarchConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalResarchDoctorConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalResarchProcedurConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientLastUseDrugConfig());
            modelBuilder.ApplyConfiguration(new Configurations.HospitalsUnitsDefinitionGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SendSMSDoctorPATDelayConfig());
            modelBuilder.ApplyConfiguration(new Configurations.TestObjConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PeriodicOrderConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugOrderTransactionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MainStoreDistributionDocConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MainStoreDistDocDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockLocationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.GlaskowScoreConfig());
            modelBuilder.ApplyConfiguration(new Configurations.TraditionalMedicineConfig());
            modelBuilder.ApplyConfiguration(new Configurations.TradititionalMedAppCasesConfig());
            modelBuilder.ApplyConfiguration(new Configurations.TraditionalMedAppRegionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SohaRuleLogConfig());
            modelBuilder.ApplyConfiguration(new Configurations.HealthCommitteeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AccountVoucherConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockActionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SendSMSMasterConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InPatientPhysicianMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.IntendedUseOfDisabledReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SendSMSDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ReturningDocumentMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalResarchPatientAdConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalResarchPatientExConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ChemoRadiotherapyMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalResarchPatientExProConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EStatusNotRepCommitteeObjConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DentalExaminationProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DynamicDataSourceParamConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DeleteRecordDocumentDestroyableMaterialOutConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AnesthesiaResponsibleDoctorConfig());
            modelBuilder.ApplyConfiguration(new Configurations.UserInfoConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DentalExaminationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InPatientTreatmentClinicApplicationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingAppliProgressConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ChemoRadioCureProtocolConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DynamicFormSubmissionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalWasteConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PhysiotherapyReportsConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DistributionDocumentMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ChemoRadioCureProtocolDetConfig());
            modelBuilder.ApplyConfiguration(new Configurations.TigEpisodeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DynamicFormConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InvoiceCollectionDocumentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EDisabledReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InvoiceCollectionDocumentGroupConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DynamicFormRevisionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseTemplateConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InvoiceCollectionDocumentDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DynamicDataSourceConfig());
            modelBuilder.ApplyConfiguration(new Configurations.FormFieldConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DynamicFormRevisionFieldConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DynamicFormSavedValueConfig());
            modelBuilder.ApplyConfiguration(new Configurations.CompanionApplicationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockTrxUpdateActionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DailyDrugScheduleConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DynamicFormSavedJSONConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockTrxUpdateActionDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingSpiritualEvaluationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EpisodeActionWithDiagnosisConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingOrderTemplateDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingNutritionAssessmentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DailyDrugPatientConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingSystemInterrogationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ReportDiagnosisConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseNursingDischargingInstructionPlanConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AccountDocumentGroupConfig());
            modelBuilder.ApplyConfiguration(new Configurations.KScheduleCollectedOrderConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseHCExaminationDynamicObjectConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PayerInvoiceDocumentDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingDischargingInstructionPlanConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseNursingFallingDownRiskConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ScheduledTaskHistoryConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SocServPatientFamilyInfoConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockMergeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.OutPatientDrugOrderConfig());
            modelBuilder.ApplyConfiguration(new Configurations.CollectiveInvoiceOpConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingPatientAndFamilyInstructionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AccountingTermConfig());
            modelBuilder.ApplyConfiguration(new Configurations.CollectiveInvoiceOpDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseNursingPatientAndFamilyInstructionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.LowerExtremityConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugReturnActionDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingOrderDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockFirstInDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SEPDiagnosisConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseInpatientAdmissionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ReceiptDocumentGroupConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockMergeMaterialOutConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MainSurgeryProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DistributeDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingPatientPreAssessmentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InfectionCommitteeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugOrderForReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InfectionCommitteeDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseDietOrderConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MorgueConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DietOrderConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugOtherFormConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockMergeMaterialInConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseMultipleDataEntryConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ApacheScoreConfig());
            modelBuilder.ApplyConfiguration(new Configurations.FTRPackageProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockCensusLevelConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EpisodeFolderConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseActionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ExaminationQueueItemConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DentalProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalStuffReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AccountDocumentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StatusNotificationReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.VemRelationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockLevelConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InPatientPhysicianProgressesConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SubActionMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DentalExaminationSuggestedProsthesisConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BloodBankBloodProductsConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseOrthesisProsthesisProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ChattelDocumentWithPurchaseConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PaymentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseBedProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.TaniTeshisİliskisiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingGlaskowComaScaleConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingApplicationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingFunctionalDailyLifeActivityConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseMedulaObjectConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockCensusDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseDataCorrectionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ParticipationFreeDrgGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SpecialPanelCriteriaValueConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SpecialityBasedObjectConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SubEpisodeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DailyBedProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ChildGrowthStandardsConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockReservationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SEPMasterConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseAnesthesiaPersonnelConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResUserTakeOffFromWorkConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PhysicianApplicationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.IIMSpecialityConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientAdmissionResourcesToBeReferredConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedulaReportResultConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InvoiceLogConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ParticipatnFreeDrugReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.UserMessageConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SubStoreStockTransferConfig());
            modelBuilder.ApplyConfiguration(new Configurations.TemplateGroupConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PathologyTestProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SubStoreStockTransferMatConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BasePhysiotherapyOrderDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientOldDebtConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseScheduledTaskConfig());
            modelBuilder.ApplyConfiguration(new Configurations.FavoriteDiagnosisConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SubactionProcedureWithDiagnosisConfig());
            modelBuilder.ApplyConfiguration(new Configurations.IIMProtocolConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AccountActionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AnesthesiaPersonnelConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EmergencyInterventionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PayerInvoiceDocumentGroupConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ReceiptConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DailyDrugSchOrderConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ENabizConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ChangeStockLevelTypeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PrescriptionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InPatientRtfBySpecialityConfig());
            modelBuilder.ApplyConfiguration(new Configurations.HospitalTimeScheduleDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DispatchToOtherHospitalConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InpatientAdmissionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InPatientPhysicianApplicationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientTokenConfig());
            modelBuilder.ApplyConfiguration(new Configurations.VaccinePeriodGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.OldDebtReceiptDocumentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BloodPressureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.RadiologyMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PulseConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockFirstTransferConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseNursingDataEntryConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockCollectedTrxConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SurgeryExtensionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.CashConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseDrugOrderConfig());
            modelBuilder.ApplyConfiguration(new Configurations.LaboratoryProcedureTubeInfoConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InpatientPhysicianApplicationAdditionalApplicationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingCareConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MHRSAdmissionAppointmentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseDentalEpisodeActionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ScheduleAppointmentTypeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ChangeStockLevelTypeDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BedProcedureWithoutBedConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockActionInspectionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingApplicationTreatmentMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.OrthesisProsthesisRequestConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DPDetailLogConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ConsultationProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockFirstInConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugDeliveryActionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugDeliveryActionDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientAuthorizedResourceConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ChattelDocumentDistributionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseAnesthesiaProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AccountTrxDocumentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseDeleteRecordDocumentDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PeriodicOrderDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockActionInspectionDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientIdentityAndAddressConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ExtendExpirationDateDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientOwnDrugEntryConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientOwnDrugEntryDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientOwnDrugTrxConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientAdmissionCountConfig());
            modelBuilder.ApplyConfiguration(new Configurations.TestObjectConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseDietOrderDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ReviewActionPatientDetConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EpisodeActionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SubSurgeryConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingWoundAssessmentScaleConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ESWTReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InfectiousIllnesesInformationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ReturningDocumentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DietOrderDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.VitalSignConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MealTypesConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SPO2Config());
            modelBuilder.ApplyConfiguration(new Configurations.ChattelDocumentInputWithAccountancyConfig());
            modelBuilder.ApplyConfiguration(new Configurations.NursingDailyLifeActivityConfig());
            modelBuilder.ApplyConfiguration(new Configurations.TemperatureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SEPEpicrisisConfig());
            modelBuilder.ApplyConfiguration(new Configurations.WeightConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ReceiptDocumentDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.KronikHastaliklarVeriSetiConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalInfoDrugAllergiesConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PlannedActionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DistributionTermActionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ConsultationFromExternalHospitalConfig());
            modelBuilder.ApplyConfiguration(new Configurations.FTRReportDetailGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.FTRReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseHealthCommittee_HospitalsUnitsGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DistributionDocumentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PhysiotherapyRequestConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SubStoreConsumptionActionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SubStoreConsumptionDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MainStoreProductionConsumptionDocumentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.CreditCardConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientExaminationProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ResourceSpecialityGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EpisodeConfig());
            modelBuilder.ApplyConfiguration(new Configurations.AnesthesiaAndReanimationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.FavoriteDrugConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ForensicMedicalReportConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PatientExaminationAdditionalApplicationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockLotDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.HospitalsUnitsGridConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ProcedureMaterialAddingConfig());
            modelBuilder.ApplyConfiguration(new Configurations.UserResourceConfig());
            modelBuilder.ApplyConfiguration(new Configurations.KScheduleUnListMaterialConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockGuideCardDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.OuttableLotConfig());
            modelBuilder.ApplyConfiguration(new Configurations.HealthCommitteeExaminationProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MainCashOfficeOperationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.OldDrugOrderConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ChattelDocumentInputDetailWithAccountancyConfig());
            modelBuilder.ApplyConfiguration(new Configurations.BaseChattelDocumentConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ChattelDocumentOutputWithAccountancyConfig());
            modelBuilder.ApplyConfiguration(new Configurations.PathologyRequestConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DentalConsultationProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockPrescriptionOutConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockPrescriptionOutMatConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockActionDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.CheckStockCensusActionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InpatientPrescriptionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SubEpisodeProtocolConfig());
            modelBuilder.ApplyConfiguration(new Configurations.StockTransactionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.EtkinMaddeDVOConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InvoiceCollectionDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.MedicalInfoAllergiesConfig());
            modelBuilder.ApplyConfiguration(new Configurations.OutpatientPresDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.OrthesisProsthesisProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.UserMessageGroupUsersConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugOrderIntroductionConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugOrderIntroductionDetConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SubActionProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.SurgeryPackageProcedureConfig());
            modelBuilder.ApplyConfiguration(new Configurations.InpatientPresDetailConfig());
            modelBuilder.ApplyConfiguration(new Configurations.ConsultationConfig());
            modelBuilder.ApplyConfiguration(new Configurations.DrugOrderDetailConfig());
            #endregion Entity Configurations
        }
    }
}