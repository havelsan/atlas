//$8949F268
import { PatientExamination, ProvizyonTipi, IstisnaiHal, SKRSAdliVakaGelisSekli, InpatientAdmission, InPatientTreatmentClinicApplication, TreatmentDischarge, BaseTreatmentMaterial, SubEpisode, ActionTypeEnum, HCExaminationDisabledRatio } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoFoodAllergies } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoDrugAllergies } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { PatientExaminationAdditionalApplication } from 'NebulaClient/Model/AtlasClientModel';
import { PatientExaminationTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Consultation } from 'NebulaClient/Model/AtlasClientModel';
import { DoctorGrid } from 'NebulaClient/Model/AtlasClientModel';
import { SingleNursingOrder } from 'NebulaClient/Model/AtlasClientModel';
import { PatientExaminationForensicProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { HCExaminationComponent } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { DietMaterialDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIngredientDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ImportantMedicalInformation } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { EmergencyIntervention } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCikisSekli } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SevkVasitasi } from 'NebulaClient/Model/AtlasClientModel';
import { VitalSignAndNursingDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SingleNursingOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { BaseNewDoctorExaminationFormViewModel } from 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseNewDoctorExaminationFormViewModel';
import { vmRequestedProcedure } from '../Tetkik_Istem_Modulu/ProcedureRequestViewModel';
import { vmProcedureRequestFormDefinition } from '../Tetkik_Istem_Modulu/ProcedureRequestViewModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { PatientInterviewForm, ConsultationFromExternalHospital, DentalExamination } from 'NebulaClient/Model/AtlasClientModel';
import { VitalSingsFormViewModel } from 'Modules/Tibbi_Surec/Vital_Bulgular/VitalSingsFormViewModel';
import { ReportTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { AnamnesisFormViewModel } from 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/AnamnesisFormViewModel';
import { DynamicComponentInfoDVO } from 'app/Fw/Models/DynamicComponentInfoDVO';
import { BaseHCExaminationDynamicObjectFormViewModel } from 'Modules/Tibbi_Surec/Saglik_Kurulu_Modulu/BaseHCExaminationDynamicObjectFormViewModel';
import { DailyProvisionInputModel } from '../Tetkik_Istem_Modulu/ProcedureRequestViewModel';
import { MorgueExDischargeFormViewModel } from '../Morg_Modulu/MorgueExDischargeFormViewModel';
import { GivenAppointment } from '../Randevu_Modulu/AppointmentFormViewModel';


export class PatientExaminationDoctorFormNewViewModel extends BaseNewDoctorExaminationFormViewModel {
    @Type(() => PatientExamination)
    public _PatientExamination: PatientExamination = new PatientExamination();
    @Type(() => MedicalInfoFoodAllergies)
    public MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesGridList: Array<MedicalInfoFoodAllergies> = new Array<MedicalInfoFoodAllergies>();
    @Type(() => MedicalInfoDrugAllergies)
    public MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesGridList: Array<MedicalInfoDrugAllergies> = new Array<MedicalInfoDrugAllergies>();
    @Type(() => DiagnosisGrid)
    public DiagnosisHistoryGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => DiagnosisGrid)
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    //public GridDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => PatientExaminationAdditionalApplication)
    public GridAdditionalApplicationsGridList: Array<PatientExaminationAdditionalApplication> = new Array<PatientExaminationAdditionalApplication>();
    @Type(() => PatientExaminationTreatmentMaterial)
    public GridTreatmentMaterialsGridList: Array<PatientExaminationTreatmentMaterial> = new Array<PatientExaminationTreatmentMaterial>();
    @Type(() => Consultation)
    public GrdConsultationGridList: Array<Consultation> = new Array<Consultation>();
    @Type(() => PatientInterviewForm)
    public GrdPatientInterviewFormGridList: Array<PatientInterviewForm> = new Array<PatientInterviewForm>();
    @Type(() => DentalExamination)
    public GrdDentalExaminationGridList: Array<DentalExamination> = new Array<DentalExamination>();
    @Type(() => ConsultationFromExternalHospital)
    public GrdExternalConsultationGridList: Array<ConsultationFromExternalHospital> = new Array<ConsultationFromExternalHospital>();
    @Type(() => EpisodeAction)
    public GrdConsAndPatientInterviewFormGridList: Array<EpisodeAction> = new Array<EpisodeAction>();
    @Type(() => DoctorGrid)
    public ttgridSevkEdenDoktorlarGridList: Array<DoctorGrid> = new Array<DoctorGrid>();
    @Type(() => SingleNursingOrder)
    public GridNursingOrdersGridList: Array<SingleNursingOrder> = new Array<SingleNursingOrder>();
    @Type(() => PatientExaminationForensicProcedure)
    public ForensicProceduresGridGridList: Array<PatientExaminationForensicProcedure> = new Array<PatientExaminationForensicProcedure>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => HCExaminationComponent)
    public HCExaminationComponents: Array<HCExaminationComponent> = new Array<HCExaminationComponent>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => DietMaterialDefinition)
    public DietMaterialDefinitions: Array<DietMaterialDefinition> = new Array<DietMaterialDefinition>();
    @Type(() => ActiveIngredientDefinition)
    public ActiveIngredientDefinitions: Array<ActiveIngredientDefinition> = new Array<ActiveIngredientDefinition>();
    @Type(() => ImportantMedicalInformation)
    public ImportantMedicalInformations: Array<ImportantMedicalInformation> = new Array<ImportantMedicalInformation>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => OzelDurum)
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();
    @Type(() => EmergencyIntervention)
    public EmergencyInterventions: Array<EmergencyIntervention> = new Array<EmergencyIntervention>();
    @Type(() => SKRSCikisSekli)
    public SKRSCikisSeklis: Array<SKRSCikisSekli> = new Array<SKRSCikisSekli>();
    @Type(() => SpecialityDefinition)
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => PatientExamination)
    public PatientExaminations: Array<PatientExamination> = new Array<PatientExamination>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => SevkVasitasi)
    public SevkVasitasis: Array<SevkVasitasi> = new Array<SevkVasitasi>();
    @Type(() => VitalSignAndNursingDefinition)
    public VitalSignAndNursingDefinitions: Array<VitalSignAndNursingDefinition> = new Array<VitalSignAndNursingDefinition>();
    @Type(() => SingleNursingOrderDetail)
    public SingleNursingOrderDetails: Array<SingleNursingOrderDetail> = new Array<SingleNursingOrderDetail>();
    public _selectedMaterialValue: Object;
    public _selectedMedicalInfoFoodAllergyValue: Object;
    public _selectedMedicalInfoDrugAllergyValue: Object;
    //public SpecialityBasedObjects: Array<SpecialityBasedObject> = new Array<SpecialityBasedObject>();
    @Type(() => Guid)
    public _PatientExaminationMasterResourceID: Guid;
    @Type(() => vmRequestedProcedure)
    public RequestedProcedures: Array<vmRequestedProcedure> = new Array<vmRequestedProcedure>();
    @Type(() => EpisodeAction)
    public EpisodeAction: EpisodeAction;
    @Type(() => OldConsultationInfo)
    public ConsultationsHistory: Array<OldConsultationInfo> = new Array<OldConsultationInfo>();
    @Type(() => PatientReportInfo)
    public PatientReportInfoList: Array<PatientReportInfo> = new Array<PatientReportInfo>();
    @Type(() => NewConsultationRequestInfo)
    public NewConsultationRequests: Array<NewConsultationRequestInfo> = new Array<NewConsultationRequestInfo>();
    @Type(() => Guid)
    public ProcedureRequestFormResourceIDs: Array<Guid> = new Array<Guid>();
    public SpecialityBasedObjectViewModels: Array<any> = new Array<any>();
    @Type(() => vmProcedureRequestFormDefinition)
    public UserMostUsedFormDefinitions: Array<vmProcedureRequestFormDefinition> = new Array<vmProcedureRequestFormDefinition>();
    public ExaminationProcessAndEndDate: string;
    @Type(() => Number)
    public Height: number;
    @Type(() => Number)
    public Weight: number;
    @Type(() => Guid)
    public PatientId: Guid;
    @Type(() => Boolean)
    public IsExaminationCompleted: boolean;
    @Type(() => Boolean)
    public createNewProcedure: boolean;
    @Type(() => Boolean)
    public hasSavedDiagnosis: boolean;

    // Fizyoterapi İşlemleri
    @Type(() => Boolean)
    public StartPhysiotherapyRequest: boolean;
    @Type(() => Boolean)
    public IsPhysiotherapyRequestFormUsing: boolean;
    @Type(() => Boolean)
    public SavePhysiotherapyRequest: boolean;
    @Type(() => Boolean)
    public HasAuthorityForPhysiotherapyRequest: Boolean;
    // .\ Fizyoterapi İşlemleri

    @Type(() => Boolean)
    public isENabizActive: boolean;

    @Type(() => VitalSingsFormViewModel)
    public vitalSingsViewModel: VitalSingsFormViewModel;
    @Type(() => AnamnesisFormViewModel)
    public anamnesisFormViewModel: AnamnesisFormViewModel;
    public reportType: ReportTypeEnum = 0;
    @Type(() => Boolean)
    public includeDrugDefinition: boolean;
    @Type(() => Boolean)
    public physicianSuggestionsIsActive: boolean;
    @Type(() => Boolean)
    public IsAuthorizedToWriteTreatmentReport: boolean;

    public BaseHCExaminationDynamicObjectFormViewModelList: Array<BaseHCExaminationDynamicObjectFormViewModel> = new Array<BaseHCExaminationDynamicObjectFormViewModel>();

    public baseHCEComponentInfo: DynamicComponentInfoDVO = new DynamicComponentInfoDVO(); //dinamşik sağlık kurulu ek alanlar

    @Type(() => Boolean)
    public hasDoctorKotaRole: boolean;
    public hasDoctorEAthleteRole: boolean;
    public hasDoctorEDriverRole: boolean;
    public hasDoctorEPsychotecnicsRole: boolean;
    @Type(() => Boolean)
    public hasOrthesisRequestRole: boolean;

    @Type(() => Boolean)
    public IsPatientAdmissionEmergengy: boolean;
    @Type(() => Boolean)
    public IsIndustrialAccident: boolean;

    @Type(() => Boolean)
    public hasGiveAppointmentRole: boolean;

    @Type(() => TreatmentDischarge)
    public DailyPreDischarge: TreatmentDischarge;

    
    public GreenAreaExaminationProcedureObjectId:Guid;

    public EmergencyExaminationProcedureObjectId:Guid;

    @Type(() => Boolean)
    public ISSinglePhysicianReport: boolean;
    public SubepisodeID: string;
    public ProcedureDoctorObjectIDForOBS: string;
    @Type(() => BaseTreatmentMaterial)
    public NewGridTreatmentMaterialsGridList: Array<BaseTreatmentMaterial> = new Array<BaseTreatmentMaterial>();

    @Type(() => SubEpisode)
    public SubEpisodes: Array<SubEpisode> = new Array<SubEpisode>();
    @Type(() => SubEpisode)
    public SubEpisodeList: Array<SubEpisode> = new Array<SubEpisode>();
    @Type(() => EpisodeAction)
    public EpisodeActionList: Array<EpisodeAction> = new Array<EpisodeAction>();
    @Type(() => HCExaminationDisabledRatio)
    public HCExaminationDisabledRatios: Array<HCExaminationDisabledRatio> = new Array<HCExaminationDisabledRatio>();
    @Type(() => Boolean)
    public IsKetem: boolean;
    public GenderCode: string;
    @Type(() => Number)
    public DayLimitExceeded: number;
    @Type(() => Boolean)
    public IsWomanSpecialityExam: boolean;
    public HighRiskPregnancyMessage: string;
    public HasMorgue: boolean;
    public _MorgueViewModel: MorgueExDischargeFormViewModel;
    @Type(() => SKRSCikisSekli)
    public DeathDefinition: SKRSCikisSekli = new SKRSCikisSekli();

    public isRadiologyAppointmentActive: boolean;
    public IsPcrRequested: boolean;
    @Type(() => Boolean)
    public isNewMHRS: boolean;

}

export class OldConsultationInfo {
    @Type(() => Guid)
    public consultationObjectID: Guid;
    @Type(() => Date)
    public consultationActionDate: Date;
    public consultationRequesterResource: string;
    public consultationMasterResource: string;
    public consultationRequestDescription: string;
    public consultationResult: string;
    public consultationState: string;
    @Type(() => Number)
    public consultationStateStatus: number;
    @Type(() => ConsultationDiagnosis)
    public consultationDiagnosis: Array<ConsultationDiagnosis>;
}

export class PatientReportInfo {
    @Type(() => Guid)
    public ObjectID: Guid;
    public ObjectDefName: string;
    public ID: string;
    public StartDate: string;
    public EndDate: string;
    public ReportName: string;
    public RequestReason: string;
    public MasterResource: string;
    public AdmissionDate: string;
    public ProcedureByUser: string;
}

export class NewConsultationRequestInfo {
    @Type(() => ResSection)
    public consultationMasterResource: ResSection;
    @Type(() => ResUser)
    public consultationProcedureDoctor: ResUser;
    @Type(() => Boolean)
    public consultationEmergency: boolean;
    @Type(() => Boolean)
    public consultationInBed: boolean;
}
export class NewTreatmentMaterialInfo {
    @Type(() => Material)
    public Material: Material;
    public Barcode: string;
    @Type(() => Date)
    public ActionDate: Date;
    public DistributionType: string;
    @Type(() => Number)
    public Amount: number;
    @Type(() => StockCard)
    public StockCard: StockCard;
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDef: DistributionTypeDefinition;
}

export class ConsultationDiagnosis {
    public consultationDiagnose: string;
    public consultationFreeDiagnose: string;
}

export class ChangeProvisionTypeClass
{
    @Type(() => ProvizyonTipi)
    public AdmissionType: ProvizyonTipi;
    @Type(() => Date)
    public MedulaVakaTarihi: Date;
    @Type('IstisnaiHal')
    public MedulaIstisnaiHal: IstisnaiHal;
    @Type('SKRSAdliVakaGelisSekli')
    public SKRSAdliVaka: SKRSAdliVakaGelisSekli;
    public Sevkli112: boolean;
    public Emergency112RefNo: string;
    public MedulaPlakaNo: string;
    public SubepisodeID:string;
}

/* GEBELİK BİLDİRİM*/
export class RiskligebelikOutput_Class {
    @Type(() => Number)
    public durum: number;
    public sonuc: Sonuc;
    public mesaj: Object;
}
export class Hasta {
    public hastaTC: string;
    public adSoyad: string;
    public birimeAtanmaTarihi: Date;
}
export class GebelikBildirim {
    public sysTakipNo: string;
    public hekimAdSoyad: string;
    public kurumAdi: string;
    public kangrubu: number;
    public islemzamani: Date;
    public sonadettarihi: Date;
    public gonderimZamani: Date;
}
export class Sonuc {
    public hasta: Hasta;
    public gebelikBildirim: Array<GebelikBildirim>;
    public riskliGebelik: boolean;
    public riskliGebelikDetayi: string;
    public returnMessage: string;
}

export class GebelikIzlem {
    public gebelikBildirimSYSTakipNo: string;
    public sysTakipNo: string;
    public hekimAdSoyad: string;
    public kurumAdi: string;
    public islemzamani: Date;
    public gestasyonelDiyabetTaramasi: string;
    public islemiYapan: string;
    public bilgiAlinanKisiAdSoyad: string;
    public bilgiAlinanKisiTelefonNumarasi: string;
    public sonadettarihi: Date;
    public dvitaminilojistigivedestegi: string;
    public demirlojistigivedestegi: string;
    public gebelikteRiskDurumu: string;
    public hemoglobin: string;
    public idrardaProtein: string;
    public konjenitalanomalilidogumvarligi: string;
    public kacinciGebeIzlem: string;
    public izleminYapildigiYer: string;
    public boy: string;
    public kilo: string;
    public gonderimZamani: Date;
}
export class SonucGebelikIzlem {
    public hasta: Hasta;
    public gebelikIzlem: Array<GebelikIzlem>;
}
export class GebelikIzlem_Output {
    public durum: number;
    public sonuc: SonucGebelikIzlem;
    public mesaj: string;
}

export class RadiologyAppointmentInfo {
    public RadiologyTestObjectID: string;
    public ProcedureName: string;
    public ProcedureCode: string;
    public AppointmentDate: string;
    public AppointmentTime: string;
    public givenAppointment: GivenAppointment;
}

export class MHRS_YesilListeSorgula_OutPut {
    public result: string;
    public yesilListeDurum: number;
}