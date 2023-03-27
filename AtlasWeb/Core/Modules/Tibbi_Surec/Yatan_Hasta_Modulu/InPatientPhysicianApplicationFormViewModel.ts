//$0FA0F59A
import { InPatientPhysicianApplication, NursingOrderDetail, EmergencyIntervention, EpisodeAction, HealthCommittee, SKRSDurum, TedaviTipi, SKRSCikisSekli, EpisodeFolder, BaseInpatientAdmission, ApacheScore, GlaskowScore, Snappe, Prism } from 'NebulaClient/Model/AtlasClientModel';
import { DietOrder, IntensiveCareTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { InPatientRtfBySpeciality } from 'NebulaClient/Model/AtlasClientModel';
import { InPatientPhysicianProgresses } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { NursingOrder } from 'NebulaClient/Model/AtlasClientModel';
import { BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { DietDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MealTypes } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisode } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { InPatientTreatmentClinicApplication } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Consultation } from 'NebulaClient/Model/AtlasClientModel';
import { VitalSignAndNursingDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Type } from "NebulaClient/ClassTransformer";
import { OrderTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { TreatmentDischarge } from 'NebulaClient/Model/AtlasClientModel';
import { BaseNewDoctorExaminationFormViewModel } from 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseNewDoctorExaminationFormViewModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PatientInterviewForm, ConsultationFromExternalHospital, DentalExamination } from 'NebulaClient/Model/AtlasClientModel';
import { vmProcedureRequestFormDefinition } from '../Tetkik_Istem_Modulu/ProcedureRequestViewModel';
import { NursingOrderTemplateDetail } from 'NebulaClient/Model/AtlasClientModel';
import { NursingOrderTemplate } from 'NebulaClient/Model/AtlasClientModel';
import { NursingApplication, WhoPaysEnum, ResPoliclinic } from 'NebulaClient/Model/AtlasClientModel';
import { PatientReportInfo } from "../Poliklinik_Modulu/PatientExaminationDoctorFormNewViewModel";
import { EnumItem } from "app/NebulaClient/Mscorlib/EnumItem";
import { SubEpisodeProtocol } from 'NebulaClient/Model/AtlasClientModel';
import { MorgueExDischargeFormViewModel } from '../Morg_Modulu/MorgueExDischargeFormViewModel';

export class InPatientPhysicianApplicationFormViewModel extends BaseNewDoctorExaminationFormViewModel {
    @Type(() => InPatientPhysicianApplication)
    public _InPatientPhysicianApplication: InPatientPhysicianApplication = new InPatientPhysicianApplication();
    @Type(() => DietOrder)
    public DietOrdersGridList: Array<DietOrder> = new Array<DietOrder>();
    @Type(() => InPatientRtfBySpeciality)
    public InPatientRtfBySpecialitiesGridList: Array<InPatientRtfBySpeciality> = new Array<InPatientRtfBySpeciality>();
    @Type(() => InPatientPhysicianProgresses)
    public ProgressesGridList: Array<InPatientPhysicianProgresses> = new Array<InPatientPhysicianProgresses>();
    @Type(() => Consultation)
    public GrdConsultationGridList: Array<Consultation> = new Array<Consultation>();
    @Type(() => DiagnosisGrid)
    public GridDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => NursingOrder)
    public NursingOrderGridGridList: Array<NursingOrder> = new Array<NursingOrder>();
    @Type(() => BaseTreatmentMaterial)
    public GridTreatmentMaterialsGridList: Array<BaseTreatmentMaterial> = new Array<BaseTreatmentMaterial>();
    @Type(() => DietDefinition)
    public DietDefinitions: Array<DietDefinition> = new Array<DietDefinition>();
    @Type(() => MealTypes)
    public MealTypess: Array<MealTypes> = new Array<MealTypes>();
    @Type(() => SubEpisode)
    public SubEpisodes: Array<SubEpisode> = new Array<SubEpisode>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => InPatientTreatmentClinicApplication)
    public InPatientTreatmentClinicApplications: Array<InPatientTreatmentClinicApplication> = new Array<InPatientTreatmentClinicApplication>();
    public BaseInpatientAdmissions: Array<BaseInpatientAdmission> = new Array<BaseInpatientAdmission>();
    //public ResBeds: Array<ResBed> = new Array<ResBed>();
    //public ResRoomGroups: Array<ResRoomGroup> = new Array<ResRoomGroup>();
    //public ResRooms: Array<ResRoom> = new Array<ResRoom>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => VitalSignAndNursingDefinition)
    public VitalSignAndNursingDefinitions: Array<VitalSignAndNursingDefinition> = new Array<VitalSignAndNursingDefinition>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => OzelDurum)
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();
    /**/
    @Type(() => PatientInterviewForm)
    public GrdPatientInterviewFormGridList: Array<PatientInterviewForm> = new Array<PatientInterviewForm>();
    @Type(() => ConsultationFromExternalHospital)
    public GrdExternalConsultationGridList: Array<ConsultationFromExternalHospital> = new Array<ConsultationFromExternalHospital>();
    @Type(() => EpisodeAction)
    public GrdConsAndPatientInterviewFormGridList: Array<EpisodeAction> = new Array<EpisodeAction>();
    @Type(() => DentalExamination)
    public GrdDentalExaminationGridList: Array<DentalExamination> = new Array<DentalExamination>();
    /**/
    @Type(() => Guid)
    public ProcedureRequestFormResourceIDs: Array<Guid> = new Array<Guid>();
    public ProgressDescription: string;
    @Type(() => Date)
    public ProgressDate: Date;
    @Type(() => VitalSignAndNursingDefinition)
    public VitalSignAndNursingDefinitionList: Array<VitalSignAndNursingDefinition> = new Array<VitalSignAndNursingDefinition>();
    @Type(() => OrderScheduleDetail)
    public _nursingOrderScheduleDetail: Array<OrderScheduleDetail> = new Array<OrderScheduleDetail>();
    @Type(() => TreatmentDischarge)
    public myTreatmentDischarge: TreatmentDischarge;
    @Type(() => DietDefinition)
    public DietDefinitionList: Array<DietDefinition> = new Array<DietDefinition>();
    @Type(() => OrderScheduleDetail)
    public _dietOrderScheduleDetail: Array<OrderScheduleDetail> = new Array<OrderScheduleDetail>();
    @Type(() => Boolean)
    public IsNewBorn: boolean;
    @Type(() => Patient)
    public _Patient: Patient;
    //public ENabizViewModels: Array<any> = new Array<any>();  BaseNewDoctorExaminationFormViewModel dan kullanılıyor
    public UserMostUsedFormDefinitions: Array<vmProcedureRequestFormDefinition> = new Array<vmProcedureRequestFormDefinition>();

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

    // Doğum İşlemleri
    public HasAuthorityForObstetricInformationForm: Boolean;
    public StartObstetric: Boolean;
    // .\ Doğum İşlemleri

    //#region Pandemi
    public IsPandemicRequired: boolean;
    public IsIntensiveCare: boolean;
    @Type(() => DiagnosisGrid)
    public CovidDiagnose: DiagnosisGrid;
    @Type(() => DiagnosisDefinition)
    public CovidDiagnoseDef: DiagnosisDefinition;
    public IsNonInpatient: boolean;
    //#endregion Pandemi

    public reportType: EnumItem = null;
    @Type(() => PatientReportInfo)
    public PatientReportInfoList: Array<PatientReportInfo> = new Array<PatientReportInfo>();
    public NursingApplicationObjectID: string;
    @Type(() => Boolean)
    public includeDrugDefinition: boolean;
    @Type(() => Boolean)
    public HasFalling: boolean;
    @Type(() => Number)
    public fallingWarningAge: number;
    @Type(() => Boolean)
    public physicianSuggestionsIsActive: boolean;
    @Type(() => NursingApplication)
    public _nursingApplication: NursingApplication;
    @Type(() => Date)
    public lastLoadedProgressesInfoDate: Date;

    //@Type(() => BaseTreatmentMaterial)
    //public MergedTreatmentMaterialGridList: Array<BaseTreatmentMaterial> = new Array<BaseTreatmentMaterial>();
    @Type(() => Boolean)
    public IsAuthorizedToWriteTreatmentReport: boolean;

    public HCModeOfPayment: WhoPaysEnum = 0;

    @Type(() => ResPoliclinic)
    public HCResPoliclinic: Array<ResPoliclinic> = new Array<ResPoliclinic>();

    @Type(() => ResUser)
    public HCDoctorList: Array<ResUser> = new Array<ResUser>();

    @Type(() => InpatientPhysicianAppWithResource)
    public PatientOldInpatients: Array<InpatientPhysicianAppWithResource> = new Array<InpatientPhysicianAppWithResource>();
    @Type(() => ResUser)
    ReportSelectedDoctor: ResUser = new ResUser();

    public ShowNewDrugOrderForm: string = "FALSE";
    @Type(() => Boolean)
    public hasOrthesisRequestRole: boolean;

    @Type(() => NewNursingOrderDetail)
    public newNursingOrderDetailList: Array<NewNursingOrderDetail> = new Array<NewNursingOrderDetail>();

    @Type(() => SubEpisodeProtocol)
    public SubEpisodeProtocol: SubEpisodeProtocol;
    public bagliTakipNo: string;

    @Type(() => EmergencyIntervention)
    public EmergencyInterventions: Array<EmergencyIntervention> = new Array<EmergencyIntervention>();

    @Type(() => Boolean)
    public showFallingRiskParameter: boolean;

    public GreenAreaExaminationProcedureObjectId: Guid;

    public EmergencyExaminationProcedureObjectId: Guid;

    @Type(() => SubEpisode)
    public SubEpisodeList: Array<SubEpisode> = new Array<SubEpisode>();
    @Type(() => EpisodeAction)
    public EpisodeActionList: Array<EpisodeAction> = new Array<EpisodeAction>();

    @Type(() => HealthCommittee)
    public healthCommittees: Array<HealthCommittee> = new Array<HealthCommittee>();

    public IsLongInpatient: boolean;//uzun yatış-> sebep girilecek
    public IsShortInpatient: boolean;//kısa yatış->sebep girilecek


    @Type(() => SKRSDurum)
    public SKRSDurums: Array<SKRSDurum> = new Array<SKRSDurum>();
    @Type(() => TedaviTipi)
    public TedaviTipis: Array<TedaviTipi> = new Array<TedaviTipi>();

    @Type(() => SKRSCikisSekli)
    public TreatmentResult: SKRSCikisSekli;
    public HasMorgue: boolean;
    public _MorgueViewModel: MorgueExDischargeFormViewModel;
    @Type(() => SKRSCikisSekli)
    public DeathDefinition: SKRSCikisSekli = new SKRSCikisSekli();


    public IntensiveCareType: IntensiveCareTypeEnum;
    public ClinicInpatientDateAdded: Date;
    public HasCovidDiagnosisOnPatient: boolean = false;
    public HasTodayCovidProgress: boolean = false;

    @Type(() => ApacheScore)
    public ApacheScoreList: Array<ApacheScore> = new Array<ApacheScore>();
    @Type(() => GlaskowScore)
    public GlaskowScoreList: Array<GlaskowScore> = new Array<GlaskowScore>();
    @Type(() => Snappe)
    public SnappeScoreList: Array<Snappe> = new Array<Snappe>();
    @Type(() => Prism)
    public PrismScoreList: Array<Prism> = new Array<Prism>();
}

export class NursinOrderScheduleObj {
    @Type(() => Guid)
    id: Guid;
    text: string;
    @Type(() => Guid)
    ownerId: Guid;
    @Type(() => Date)
    startDate: Date;
    @Type(() => Date)
    endDate: Date;
    stateID: string;
}

export class OrderScheduleDetail {
    @Type(() => Guid)
    id: Guid;
    text: string;
    typeId: OrderTypeEnum;
    @Type(() => Date)
    startDate: Date;
    @Type(() => Date)
    endDate: Date;
    statusName: string;
    @Type(() => Date)
    periodStartTime: Date;
    @Type(() => Boolean)
    isChanged: boolean;
    doctorDescription: string;
    @Type(() => Boolean)
    allDay: boolean;
    Result: string;
    StateID: string;
    color: string;
    ProcedureByUser: string;
    @Type(() => Boolean)
    isStoped: boolean;
}

export class SaveNursingOrderTemplateViewModel {
    @Type(() => NursingOrderTemplate)
    public PackageTemplateDef: NursingOrderTemplate = new NursingOrderTemplate();
    @Type(() => NursingOrderTemplateDetail)
    public OrderTemplateDetails: Array<NursingOrderTemplateDetail> = new Array<NursingOrderTemplateDetail>();
}

export class OrdersToCancelParameterViewModel {
    @Type(() => Boolean)
    public IsPreDischarge: boolean;
    @Type(() => Date)
    public DischargeDate: Date;
    public InPatientTreatmentClinicAppObjectID: string;
    public InPatientPhysicianAppObjectID: string;
}


export class InPatientPhysicianProgressesInfoViewModel {
    @Type(() => InPatientPhysicianProgresses)
    public ProgressesGridList: Array<InPatientPhysicianProgresses> = new Array<InPatientPhysicianProgresses>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Date)
    public lastLoadedProgressesInfoDate: Date;
}

export class InpatientPhysicianAppWithResource {
    @Type(() => Guid)
    public ObjectID: Guid;
    public MasterResource: string; //Yattığı Klinik
}

export class NewNursingOrderDetail {
    @Type(() => Guid)
    public NursingOrderID: Guid;
    @Type(() => NursingOrderDetail)
    public newNursingOrderDetail: Array<NursingOrderDetail> = new Array<NursingOrderDetail>();
}


export class MedulaResult {
    @Type(() => Boolean)
    public Succes: boolean;
    public BasvuruNo: string;
    public TakipNo: string;
    public SonucMesaji: string;
    public SonucKodu: string;
    public BagliTakipNo: string;
    public SEPObjectID: string;

    constructor() {
        this.SonucKodu = "";
        this.SonucMesaji = "";
        this.Succes = false;
        this.TakipNo = "";
        this.BasvuruNo = "";
        this.SEPObjectID = "";
    }
}

export class TakipDVO {
    public faturaTeslimNo: string;
    public ilkTakipNo: string;
    public bransKodu: string;
    public donorTCKimlikNo: string;
    public hastaBasvuruNo: string;
    public hastaBilgileri: hastaBilgileriDVO;
    public kayitTarihi: string;
    public provizyonTipi: string;
    public takipDurumu: string;
    public takipNo: string;
    public takipTarihi: string;
    public takipTipi: string;
    public tedaviTipi: string;
    public tedaviTuru: string;
    public tesisKodu: number;
    public sevkDurumu: string;
    public yeniDoganCocukSiraNo: string;
    public yeniDoganDogumTarihi: string;
    public arvFlag: string;
    public evrakID: number;
    public istisnaiHal: string;
    public fatutaIptalHakki: number;
    public faturaTarihi: string;
    public sonucKodu: string;
    public sonucMesaji: string;
}

export class hastaBilgileriDVO {
    public tcKimlikNo: string;
    public ad: string;
    public soyad: string;
    public cinsiyet: string;
    public dogumTarihi: string;
    public sigortaliTuru: string;
    public devredilenKurum: string;
    public katilimPayindanMuaf: string;
    public kapsamAdi: string;
}

export class EpisodeFolderModel {
    public ObjectID: Guid;
    public ArchiveNo: string;
    public ProtocolNo: string;
    @Type(() => Date)
    public InpatientDate: Date;
    @Type(() => Date)
    public DischargeDate: Date;
    public ClinicName: string;
    public Location: string;
    public FileCreationAndAnalysis: Guid;
    public Status: string;


}

export class ArchiveRequestModel {
    @Type(() => EpisodeFolderModel)
    public PatientEpisodeFolders: Array<EpisodeFolderModel> = new Array<EpisodeFolderModel>();
    public PatientAddress: string;
    public PatientMobilePhone: string;
}

export class ArchiveRequestInputModel {
    public EpisodeFolder: Guid;
    public FileCreationAndAnalysis: Guid;

}