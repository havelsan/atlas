
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { DiagnosisDefinition, ResDepartment, InpatientAdmission, SubActionProcedure, ResClinic, EpisodeAction, ResUser, RightLeftEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ActionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { UserOptionType } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BaseAdditionalInfoFormViewModel } from "./BaseAdditionalInfoFormViewModel";
import { SKRSCinsiyet, SKRSTekrarTetkikIstemGerekcesi } from 'NebulaClient/Model/AtlasClientModel';



export class ProcedureRequestViewModel extends BaseViewModel {
    savingResult: string;
    @Type(() => vmProcedureRequestFormDefinition)
    FormDefinitions: Array<vmProcedureRequestFormDefinition> = new Array<vmProcedureRequestFormDefinition>();
    @Type(() => vmProcedureRequestFormDefinition)
    UserMostUsedFormDefinitions: Array<vmProcedureRequestFormDefinition> = new Array<vmProcedureRequestFormDefinition>();
    @Type(() => Object)
    _selectedValue: Object;
    @Type(() => Object)
    _selectedPackageValue: Object;
    @Type(() => Boolean)
    isEmergency: boolean;
    @Type(() => Date)
    requestDate: Date;
    @Type(() => Date)
    startDate: Date;
    @Type(() => Date)
    endDate: Date;
    @Type(() => Object)
    _selectedDoctorValue: Object;
    LastSpecimenId: string = '0';
    @Type(() => Boolean)
    IsSGKPatient: boolean;
    PatientTCNo: string;
    PatientObjectID: string;
    TestTypesCheckedParam: string; //geçmiş tetkikleri kontrol edilecek radyoloji tiplerini tutar
    IgnoreMukerrerException: boolean;//mükerrerlik sorgusunda alınan hatayı göz ardı etve devam et
    DailyProvisionInputModel: DailyProvisionInputModel;
    countForDailyOperations: number = 0;
}
export class vmProcedureRequestFormDefinition {
    @Type(() => Guid)
    Id: Guid;
    Name: string;
    @Type(() => vmProcedureRequestCategoryDefinition)
    FormCategories: Array<vmProcedureRequestCategoryDefinition> = new Array<vmProcedureRequestCategoryDefinition>();
}
export class vmProcedureRequestCategoryDefinition {
    @Type(() => Guid)
    Id: Guid;
    Name: string;
    IsPassiveNow: boolean ;
    ReasonForPassive: string ;
    @Type(() => vmProcedureRequestDetailDefinition)
    FormDetails: Array<vmProcedureRequestDetailDefinition> = new Array<vmProcedureRequestDetailDefinition>();

    //istem panelini 3 gride bolme calismasi
    @Type(() => vmProcedureRequestDetailDefinition)
    Grid1FormDetails: Array<vmProcedureRequestDetailDefinition> = new Array<vmProcedureRequestDetailDefinition>();
    @Type(() => vmProcedureRequestDetailDefinition)
    Grid2FormDetails: Array<vmProcedureRequestDetailDefinition> = new Array<vmProcedureRequestDetailDefinition>();
    @Type(() => vmProcedureRequestDetailDefinition)
    Grid3FormDetails: Array<vmProcedureRequestDetailDefinition> = new Array<vmProcedureRequestDetailDefinition>();
}
export class vmProcedureRequestDetailDefinition {
    @Type(() => Guid)
    Id: Guid;
    Code: string;
    Name: string;
    @Type(() => Guid)
    ProcedureObjectDefID: Guid;
    @Type(() => Boolean)
    Checked: boolean;
    @Type(() => Boolean)
    IsActive: boolean;
    Color: any;
    @Type(() => Boolean)
    RequestedLastXDays: boolean;
    @Type(() => vmProcedureRequestDetailDefinition)
    BoundedProcedureRequestDetails: Array<vmProcedureRequestDetailDefinition> = new Array<vmProcedureRequestDetailDefinition>();
    @Type(() => Boolean)
    IsReadOnly: boolean;
    @Type(() => Boolean)
    IsWorkingDay: boolean;
    IsPassiveNow: boolean;
    @Type(() => Guid)
    ResObservationUnitId: Guid;
    @Type(() => vmProcedureRequestDetailDefinition)
    GroupProcedureRequestDetails: Array<vmProcedureRequestDetailDefinition> = new Array<vmProcedureRequestDetailDefinition>();
    @Type(() => Boolean)
    IsSexControl: boolean;
    @Type(() => SKRSCinsiyet)
    Sex: SKRSCinsiyet;
    @Type(() => Boolean)
    IsDurationControl: boolean;
    @Type(() => Number)
    DurationValue: Number;
    TestType: string;
    @Type(() => Boolean)
    RepetitionQueryNeeded: boolean;

}

export class vmRequestedProcedure {
    @Type(() => Guid)
    public Id: Guid;
    @Type(() => Guid)
    public SubActionProcedureObjectId: Guid;
    @Type(() => Guid)
    public ProcedureObjectId: Guid;
    public ProcedureCode: string;
    public ProcedureName: string;
    @Type(() => Number)
    public Amount: number;
    @Type(() => Number)
    public UnitPrice: Currency;
    @Type(() => Date)
    public RequestDate: Date;
    public RequestedByResUser: string;
    @Type(() => Guid)
    public RequestedById: Guid;
    @Type(() => Guid)
    public ProcedureUserId: Guid;
    public ProcedureResUser: string;
    public MasterResource: string;
    @Type(() => Guid)
    public MasterResourceObjectId: Guid;
    @Type(() => Date)
    public EstimatedResultDate: Date;
    public ActionStatus: string;
    @Type(() => Guid)
    public CurrentStateDefID: Guid;
    public StateStatus: number;
    public ProcedureResultLink: string;
    public ProcedureReportLink: string;
    @Type(() => Boolean)
    public isResultShown: boolean;
    @Type(() => Boolean)
    public canAnalyzeWithAI: boolean = false;
    @Type(() => Boolean)
    public isReportShown: boolean;
    @Type(() => Boolean)
    public isResultSeen: boolean;
    @Type(() => Boolean)
    public isAdditionalApplication: boolean;
    public ProcedureType: string;
    @Type(() => Boolean)
    public isEmergency: boolean;
    public ExternalProcedureId: string;  //ThirdParty entegrasyonu olan hizmetler icin dis sistemdeki ID tutmak icin.
    @Type(() => Guid)
    public ProcedureObjectDefId: Guid;
    @Type(() => Boolean)
    public hasProcedureInstruction: boolean;
    public ProcedureInstructions: string;
    public ProcedureInstructionReportName: string;
    @Type(() => Boolean)
    public isExternalProcedureRequest: Boolean;
    @Type(() => Guid)
    public EpisodeActionObjectId: Guid;
    @Type(() => Boolean)
    public hasPanicValue: Boolean;
    public PanicValue: string;
    @Type(() => Boolean)
    public isProcedureRejected: Boolean;
    public RejectReason: string;
    public ResultValue: string;
    public isBoundedTest: Boolean;
    public useSelectedDataByUser: Boolean;
    public AlertMessage: string;
    @Type(() => ProcedureSuggestionInputDVO)
    public ProcedureSuggestionInputDVOList: ProcedureSuggestionInputDVO[];
    //vmAdditionalProcedureInfo a aktarmak için kullanılır
    @Type(() => BaseAdditionalInfoFormViewModel)
    public BaseAdditionalInfoFormViewModels: Array<BaseAdditionalInfoFormViewModel> = new Array<BaseAdditionalInfoFormViewModel>();
    @Type(() => Guid)
    public BaseAdditionalInfoFormGuids: Array<Guid> = new Array<Guid>();
    @Type(() => String)
    public Description: string;
    @Type(() => String)
    public MedulaReportNo: string;
    @Type(() => Guid)
    public ReportApplicationArea: Guid;
    public isAddedToMostUsedRequest: Boolean;
    public isGroupTest: Boolean; //Laboratuvar testlerinde group test ise istem panelinden isaretlendiginde tetkigin kendisi eklenmemei icin. Altında tanımlı tetkıklerın eklenecek
    public isDateChanged: Boolean = false;     //İstem gridinde değişiklik yapıldığını kontrol etmek için eklendiler isDateChanged,isAmountChanged,isProcedureUserChanged
    public isAmountChanged: Boolean = false;
    public isProcedureUserChanged: Boolean = false;
    public isProcedureReadOnly: Boolean; //Tetkiklerde değişiklik yapılıp yapılamayacağını tutmak için eklendi
    public isNew: Boolean; //Yeni eklenen tetkiklerde güncellemeye gerek olmadığı için eklendi.
    @Type(() => Boolean)
    public isPanelTest: Boolean;
 @Type(() => vmProcedureRequestDetailDefinition)
    BoundedProcedureRequestDetails: Array<vmProcedureRequestDetailDefinition> = new Array<vmProcedureRequestDetailDefinition>();
    @Type(() => Boolean)
    public DailyMedulaProvisionNecessity: Boolean;
    @Type(() => Boolean)
    public isReportRequired: boolean;
    public ProtocolNo: string;
    public ActionType: ActionTypeEnum;
    @Type(() => Boolean)
    public isRISIntegrated: boolean;
    @Type(() => Boolean)
    public isRadiologyProcedure: boolean; 
    @Type(() => Boolean)
    public isPathologyRequired: boolean; 
    @Type(() => Boolean)
    public isResultNeeded: boolean; 
    @Type(() => Boolean)
    public isSkinPrickTest: boolean; 
    @Type(() => Boolean)
    public isObserved: boolean; 
    @Type(() => Boolean)
    public RightLeftInfoNeeded: boolean; 
    public RightLeftInformation: RightLeftEnum;
    public ReasonForRepetition: SKRSTekrarTetkikIstemGerekcesi;
    @Type(() => Boolean)
    public isMikrobiyolojiTest: boolean; 
    public mikrobiyolojiResult: string;
}

export class vmPackageProcedure
{
    @Type(() => Guid)
    public Id: Guid;
    public ProcedureCode: string;
    public ProcedureName: string;
    @Type(() => Boolean)
    public isSelected: boolean;
    @Type(() => Boolean)
    public isAdditionalApplication: boolean;
}

export class vmPackageTemplateDefinition {
    public Code: string;
    public Name: string;
    @Type(() => Guid)
    public ObjectId: Guid;
    @Type(() => Guid)
    public PackageICDs: Array<Guid> = new Array<Guid>();
    @Type(() => Guid)
    public PackageRequestedProcedures: Array<Guid> = new Array<Guid>();
}

export class vmPackageTemplateICD {
    @Type(() => Guid)
    public DiagnoseObjectId: Guid;
    public DiagnoseCode: string;
    public DiagnoseName: string;
    @Type(() => DiagnosisDefinition)
    public Diagnose: DiagnosisDefinition;
    public DiagnoseType: DiagnosisTypeEnum;
    @Type(() => Boolean)
    public isSelected: boolean;
}

export class vmPackageTemplate
{
    @Type(() => vmPackageProcedure)
    public PackageProcedures: Array<vmPackageProcedure> = new Array<vmPackageProcedure>();
    @Type(() => vmPackageTemplateICD)
    public PackageICDs: Array<vmPackageTemplateICD> = new Array<vmPackageTemplateICD>();
}

export class vmRequiredInfoFormProcedure {
    @Type(() => Guid)
    public SubActionProcedureObjectId: Guid;
    public ProcedureCode: string;
    public ProcedureName: string;
    public ProcedureType: string;
}

export class vmRequestedBloodBankProcedureInfo
{
    @Type(() => Guid)
    public procedureRequestFormDetailDefinitionID: Guid;
    public externalSystemBloodProductID: string;  //Kan urun ID
    @Type(() => Guid)
    public procedureDefinitionID: Guid;
    //TODO: kan urun objesının dıger bılgılerı de buraya eklenecek
}

export class vmAdditionalProcedureInfo {
    @Type(() => Guid)
    public ProcedureObjectId: Guid;
    @Type(() => Number)
    public Amount: number;
    @Type(() => Date)
    public RequestDate: Date;
    @Type(() => Guid)
    public ProcedureUserId: Guid;
    @Type(() => BaseAdditionalInfoFormViewModel)
    public BaseAdditionalInfoFormViewModels: Array<BaseAdditionalInfoFormViewModel>;
    @Type(() => String)
    public Description: string;
    @Type(() => String)
    public MedulaReportNo: string;
    @Type(() => Guid)
    public ReportApplicationArea: Guid;
    public RightLeftInformation: RightLeftEnum;


}


export class vmRequestedProcedureInfo {
    @Type(() => Guid)
    public ProcedureRequestFormDetailDefinitionID: Guid;
    @Type(() => Date)
    public RequestDate: Date;
    @Type(() => Guid)
    public ProcedureUserId: Guid;
    @Type(() => Boolean)
    public isExternalProcedureRequest: Boolean;
    @Type(() => Guid)
    public ProcedureDefinitionObjectID: Guid;
    public RightLeftInformation: RightLeftEnum;
    @Type(() => SKRSTekrarTetkikIstemGerekcesi)
    public ReasonForRepetition: SKRSTekrarTetkikIstemGerekcesi;
}


export class EpisodeActionRequestedProcedureInfo {
    @Type(() => Guid)
    public episodeActionObjectID: Guid;
    @Type(() => Boolean)
    public emergency: boolean;
    @Type(() => vmRequestedProcedureInfo)
    public procedureRequestFormDetailDefinitions: Array<vmRequestedProcedureInfo> = new Array<vmRequestedProcedureInfo>();
    @Type(() => vmAdditionalProcedureInfo)
    public procedureRequestAdditionalApplications: Array<vmAdditionalProcedureInfo> = new Array<vmAdditionalProcedureInfo>();
    @Type(() => vmRequestedBloodBankProcedureInfo)
    public requestedBloodProducts: Array<vmRequestedBloodBankProcedureInfo> = new Array<vmRequestedBloodBankProcedureInfo>();
    @Type(() => Boolean)
    public ignoreSUTRules: boolean;
    @Type(() => Guid)
    public DiagnosisObjectIdList: Array<Guid> = new Array<Guid>();
}

export class FiredProcedureRequestInfo {
    @Type(() => Guid)
    public SubActionProcedureObjectID: Guid;
    @Type(() => Guid)
    public ProcedureObjectDefinitionID: Guid;
    @Type(() => Guid)
    public ProcedureObjectID: Guid;
    @Type(() => Guid)
    public EpisodeActionObjectID: Guid;
    public TestTypeName: string;
    @Type(() => Boolean)
    public isDescriptionNeeded: boolean;
}

export class SUTRuleResult {
    @Type(() => Boolean)
    public validateSutRules: boolean;
    @Type(() => Boolean)
    public BlockRequest: boolean;
    @Type(() => SUTRuleViolateMessage)
    public SUTRuleViolateMessages: Array<SUTRuleViolateMessage>  = new Array<SUTRuleViolateMessage>();
}

export class SUTRuleViolateMessage
    {
    public ProcedureDate: string;    
    public ProcedureCode: string;
    public Message: string;
    }

export class EpisodeActionFireRequestedProceduresResultInfo {
    @Type(() => SUTRuleResult)
    public SutRuleResult: SUTRuleResult;
    @Type(() => FiredProcedureRequestInfo)
    public FiredProcedureRequestInfoList: Array<FiredProcedureRequestInfo> = new Array<FiredProcedureRequestInfo>();
    public GeneralValidationMsg: string;
    
}

export class QueryInputDVO {
    @Type(() => Guid)
    public EpisodeActionObjectID: Guid;
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
    @Type(() => Boolean)
    public PhysicianSuggestionsIsActive: Boolean;
    @Type(() => Boolean)
    public IsCancelledIncluded: Boolean;
}

export class ProcedureReqInfoInputDVO {
    public EpisodeActionObjectId: string;
    public CheckedFormDetailObjectId: string;
    public ProcedureByUserId: string;
    public IsAdditionalApplication: boolean;
}

export class AdditionalAppInfoInputDVO {
    public EpisodeActionObjectId: string;
    public ProcedureDefObjectId: string;
}

export class TestResultQueryInputDVO {
    public ViewType: string;
    public EpisodeID: string;
    public PatientTCKN: string;
}

export class ProcedureSuggestionInputDVO {
    public Message: string;
    public ActionType: ActionTypeEnum;
    @Type(() => ResSection)
    public MasterResource: ResSection;
    @Type(() => Guid)
    public MasterResourceGuidList: Guid[];
}

export class vmRequestedProcedureForm {
    @Type(() => vmRequestedProcedure)
    public RequestedProcedureList: vmRequestedProcedure[];
    @Type(() => vmRequestedProcedure)
    public ExaminationsRequestedProcedureList: vmRequestedProcedure[];
    @Type(() => vmRequestedProcedure)
    public ControlRequestedProcedureList: vmRequestedProcedure[];
    @Type(() => vmRequestedProcedure)
    public InpatientRequestedProcedureList: vmRequestedProcedure[];
    @Type(() => ProcedureSuggestionInputDVO)
    public ProcedureSuggestionInputDVOList: ProcedureSuggestionInputDVO[];
    @Type(() => Date)
    public SubEpisodeOpeningDate: Date;
    @Type(() => Date)
    public SubEpisodeClosingDate: Date;
    @Type(() => Date)
    public RequestDate: Date;
    public LastSpecimenId: string;
    @Type(() => Boolean)
    IsSGKPatient: boolean;
    public PatientTCNo: string;
    public PatientObjectId: string;
    public countForDailyOperations: number = 0;
    public ProtocolNo: string;
    @Type(() => Date)
    public ClosingDate: Date;
}

export class UserOptionInputDVO {
    public UserOptionType: UserOptionType;
    public OptionValue: string;
}

export class RepeatedProceduresQueryInputDVO {
    public PatientID: string;
    public RequestedProceduresObjectIDList: Array<string> = new Array<string>();
}

export class DurationLimitedProceduresQueryParam {
    public PatientObjectID: string;
    public ProcedureObjectID: string;
    public Duration: number;
}

export class ProcedureUserObj {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
}

export class TeletipResult_Output{

    public OrderId:string;
    public InstitutionName:string;
    public SKRS:string;
    public AccessionNumber:string;
    
    ScheduleDate: string;
    
    PerformedDate: string;
    public RequestedProcedureDescription:string;
    @Type(() => Boolean)
    IsStudyExist: boolean;//Görüntü
    @Type(() => Boolean)
    IsReportExist: boolean;//rapor
}

export class TeletipImaj_Input{
    public AccessionNumber:string;
    public PatientCitizenId:string;
    public DoctorCitizenId:string;
    public AccessToken:string;

}
export class DailyProvisionInputModel
{
    public Epicrisis: string;
    public TreatmentClinic: Guid;
    public EpisodeAction: EpisodeAction;
    public ProcedureDoctorID: Guid;
    public DailyInpatientControl: boolean;
    public InpatientDate: Date;
    public NormalInpatientControl: boolean;
}

export class DailyProcedureModel
    {
    public provisionModel: DailyProvisionInputModel;
    public procedure: SubActionProcedure;
}

export class DailyProvisionSubscribeModel
{
    public Epicrisis: string;
    @Type(() => ResClinic)
    TreatmentClinic: ResClinic;
    public DailyInpatientControl: boolean;
    public NormalInpatientControl: boolean;
}

export class QuickProcedureEntryViewModel
{
    @Type(() => ResUser)
    public ProcedureDoctor: ResUser;
}

export class ControlVitaminDResult {
    @Type(() => TetkikMukerrerOutput)
    public VitaminD_Response: TetkikMukerrerOutput;
    @Type(() => Boolean)
    public hasPermissionToRequest: boolean;
    public Alert: string;
       
}

export class TetkikMukerrerOutput {
    public durum: number;
    @Type(() => TetkikMukerrerSonuc)
    public sonuc: TetkikMukerrerSonuc = new TetkikMukerrerSonuc();
    public mesaj: string;
}

export class TetkikMukerrerSonuc {
    @Type(() => TetkikSonuc)
    public tetkikSonuc: Array<TetkikSonuc> = new Array<TetkikSonuc>();
}

export class TetkikSonuc {
    public sutKodu: string;
    public sonucKodu: number;
    public sonucMesaji: string;
    @Type(() => TetkikSonucBilgileri)
    public tetkikSonucBilgileri: Array<TetkikSonucBilgileri> = new Array<TetkikSonucBilgileri>();
}
export class TetkikSonucBilgileri {
    public XXXXXXAdi: string;
    public klinikAdi: string;
    public gerceklesmeZamani: string;
    public tetkikSonucTarihi: string;
    @Type(() => TetkikSonucDetaylari)
    public tetkikSonucDetaylari: Array<TetkikSonucDetaylari> = new Array<TetkikSonucDetaylari>();    
    }

export class TetkikSonucDetaylari {
    public loincKodu: string;
    public tetkikSonucParametreAdi: string;
    public tetkikSonucu: string;
    public tetkikSonucuBirimi: string;
    public tetkikSonucuReferansDegeri: string;
    public tetkikSonucuReferansDegerAraligindaMi: string;
}