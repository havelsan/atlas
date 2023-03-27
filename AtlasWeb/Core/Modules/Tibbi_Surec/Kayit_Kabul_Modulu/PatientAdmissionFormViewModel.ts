//$49A16229
import { PatientAdmission, EngelliRaporuMuracaatTipiEnum, EngelliRaporuMuracaatNedeniEnum, EngelliRaporuKurumsalMuracaatTuruEnum, EngelliRaporuKisiselMuracaatTuruEnum, EngelliRaporuTerorKazaMuracaatNedeniEnum, EngelliRaporuTerorKazaMuracaatTipiEnum, HCReportTypeDefinition, EpisodeAction, EDisabledReport, EStatusNotRepCommitteeObj } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisode } from 'NebulaClient/Model/AtlasClientModel';
import { PatientAdmissionResourcesToBeReferred } from 'NebulaClient/Model/AtlasClientModel';
import { Appointment } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { TownDefinitions } from 'NebulaClient/Model/AtlasClientModel';
import { MedulaProvision } from 'NebulaClient/Model/AtlasClientModel';
import { PatientIdentityAndAddress } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMahalleKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKoyKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCSBMTipi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBucakKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSIlceKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSILKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAdresTipi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDogumSirasi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSUlkeKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCinsiyet } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSTRIAJKODU } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKanGrubu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAdliVakaGelisSekli } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSYabanciHastaTuru } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMedeniHali } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisodeProtocol } from 'NebulaClient/Model/AtlasClientModel';
import { SigortaliTuru } from 'NebulaClient/Model/AtlasClientModel';
import { IstisnaiHal } from 'NebulaClient/Model/AtlasClientModel';
import { ProvizyonTipi } from 'NebulaClient/Model/AtlasClientModel';
import { EmergencyIntervention } from 'NebulaClient/Model/AtlasClientModel';
import { ProtocolDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PayerDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ResPoliclinic, SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PriorityStatusDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResBuilding } from 'NebulaClient/Model/AtlasClientModel';
import { ResDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { HCRequestReason } from 'NebulaClient/Model/AtlasClientModel';
import { ReasonForExaminationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { HospitalsUnitsDefinitionGrid } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOzurlulukDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { ExternalHospitalDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class PatientAdmissionFormViewModel extends BaseViewModel {

    @Type(() => PatientAdmission)
    public _PatientAdmission: PatientAdmission = new PatientAdmission();
    @Type(() => SubEpisodeProtocol)
    public SubEpisodeProtocol: SubEpisodeProtocol = new SubEpisodeProtocol();
    @Type(() => SubEpisodeProtocol.GetPaBySearchPatient_Class)
    public HistoryPatientAdmission: Array<SubEpisodeProtocol.GetPaBySearchPatient_Class> = new Array<SubEpisodeProtocol.GetPaBySearchPatient_Class>();
    @Type(() => SubEpisode)
    public SubEpisodesSubEpisodeGridList: Array<SubEpisode> = new Array<SubEpisode>();
    @Type(() => PatientAdmissionResourcesToBeReferred)
    public ResourcesToBeReferredGridList: Array<PatientAdmissionResourcesToBeReferred> = new Array<PatientAdmissionResourcesToBeReferred>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => SKRSOgrenimDurumu)
    public SKRSOgrenimDurumus: Array<SKRSOgrenimDurumu> = new Array<SKRSOgrenimDurumu>();
    @Type(() => SKRSMeslekler)
    public SKRSMesleklers: Array<SKRSMeslekler> = new Array<SKRSMeslekler>();
    @Type(() => TownDefinitions)
    public TownDefinitionss: Array<TownDefinitions> = new Array<TownDefinitions>();
    @Type(() => SKRSILKodlari)
    public Citys: Array<SKRSILKodlari> = new Array<SKRSILKodlari>();
    @Type(() => MedulaProvision)
    public MedulaProvisions: Array<MedulaProvision> = new Array<MedulaProvision>();
    @Type(() => PatientIdentityAndAddress)
    public PatientIdentityAndAddresss: Array<PatientIdentityAndAddress> = new Array<PatientIdentityAndAddress>();
    @Type(() => SKRSMahalleKodlari)
    public SKRSMahalleKodlaris: Array<SKRSMahalleKodlari> = new Array<SKRSMahalleKodlari>();
    @Type(() => SKRSKoyKodlari)
    public SKRSKoyKodlaris: Array<SKRSKoyKodlari> = new Array<SKRSKoyKodlari>();
    @Type(() => SKRSCSBMTipi)
    public SKRSCSBMTipis: Array<SKRSCSBMTipi> = new Array<SKRSCSBMTipi>();
    @Type(() => SKRSBucakKodlari)
    public SKRSBucakKodlaris: Array<SKRSBucakKodlari> = new Array<SKRSBucakKodlari>();
    @Type(() => SKRSIlceKodlari)
    public SKRSIlceKodlaris: Array<SKRSIlceKodlari> = new Array<SKRSIlceKodlari>();
    @Type(() => SKRSILKodlari)
    public SKRSILKodlaris: Array<SKRSILKodlari> = new Array<SKRSILKodlari>();
    @Type(() => SKRSDogumSirasi)
    public SKRSDogumSirasis: Array<SKRSDogumSirasi> = new Array<SKRSDogumSirasi>();
    @Type(() => SKRSKanGrubu)
    public SKRSKanGrubus: Array<SKRSKanGrubu> = new Array<SKRSKanGrubu>();
    @Type(() => SKRSAdresTipi)
    public SKRSAdresTipis: Array<SKRSAdresTipi> = new Array<SKRSAdresTipi>();
    @Type(() => SKRSOzurlulukDurumu)
    public SKRSOzurlulukDurumus: Array<SKRSOzurlulukDurumu> = new Array<SKRSOzurlulukDurumu>();
    @Type(() => SigortaliTuru)
    public SigortaliTurus: Array<SigortaliTuru> = new Array<SigortaliTuru>();
    @Type(() => IstisnaiHal)
    public IstisnaiHals: Array<IstisnaiHal> = new Array<IstisnaiHal>();
    @Type(() => ProvizyonTipi)
    public ProvizyonTipis: Array<ProvizyonTipi> = new Array<ProvizyonTipi>();
    @Type(() => EmergencyIntervention)
    public EmergencyInterventions: Array<EmergencyIntervention> = new Array<EmergencyIntervention>();
    @Type(() => ProtocolDefinition)
    public ProtocolDefinitions: Array<ProtocolDefinition> = new Array<ProtocolDefinition>();
    @Type(() => PayerDefinition)
    public PayerDefinitions: Array<PayerDefinition> = new Array<PayerDefinition>();
    @Type(() => PayerDefinition)
    public PaidPayerDefinition: PayerDefinition = new PayerDefinition();
    @Type(() => PayerDefinition)
    public HealthTourismPayerDefinition: PayerDefinition = new PayerDefinition();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => ResPoliclinic)
    public ResPoliclinics: Array<ResPoliclinic> = new Array<ResPoliclinic>();
    @Type(() => EDisabledReport)
    public EDisabledReports: Array<EDisabledReport> = new Array<EDisabledReport>();
    @Type(() => EStatusNotRepCommitteeObj)
    public EStatusNotRepCommitteeObjs: Array<EStatusNotRepCommitteeObj> = new Array<EStatusNotRepCommitteeObj>();
    @Type(() => PriorityStatusDefinition)
    public PriorityStatusDefinitions: Array<PriorityStatusDefinition> = new Array<PriorityStatusDefinition>();
    @Type(() => ResBuilding)
    public ResBuildings: Array<ResBuilding> = new Array<ResBuilding>();
    @Type(() => ResDepartment)
    public ResDepartments: Array<ResDepartment> = new Array<ResDepartment>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => HCRequestReason)
    public HCRequestReasons: Array<HCRequestReason> = new Array<HCRequestReason>();
    @Type(() => ReasonForExaminationDefinition)
    public ReasonForExaminationDefinitions: Array<ReasonForExaminationDefinition> = new Array<ReasonForExaminationDefinition>();
    @Type(() => SKRSUlkeKodlari)
    public SKRSUlkeKodlaris: Array<SKRSUlkeKodlari> = new Array<SKRSUlkeKodlari>();
    @Type(() => SKRSCinsiyet)
    public SKRSCinsiyets: Array<SKRSCinsiyet> = new Array<SKRSCinsiyet>();
    @Type(() => SKRSTRIAJKODU)
    public SKRSTRIAJKODUs: Array<SKRSTRIAJKODU> = new Array<SKRSTRIAJKODU>();
    @Type(() => SKRSAdliVakaGelisSekli)
    public SKRSAdliVakaGelisSeklis: Array<SKRSAdliVakaGelisSekli> = new Array<SKRSAdliVakaGelisSekli>();
    @Type(() => SKRSYabanciHastaTuru)
    public SKRSYabanciHastaTurus: Array<SKRSYabanciHastaTuru> = new Array<SKRSYabanciHastaTuru>();
    @Type(() => SKRSMedeniHali)
    public SKRSMaritalStatuss: Array<SKRSMedeniHali> = new Array<SKRSMedeniHali>();
    public returnMessage: string = "";
    public SEProtocolNo: string = "";
    public SEPCount: string = "";
    @Type(() => ProvizyonTipi)
    public EmergencyProvisionType: ProvizyonTipi = new ProvizyonTipi();
    @Type(() => ProvizyonTipi)
    public NormalProvisionType: ProvizyonTipi = new ProvizyonTipi();
    @Type(() => ProvizyonTipi)
    public ProvizyonType3713: ProvizyonTipi = new ProvizyonTipi();
    @Type(() => HCRequestReasonDetail)
    public HCRequestReasonDetail: HCRequestReasonDetail;
    @Type(() => MedulaResult)
    public MedulaResult: MedulaResult;
    @Type(() => PatientAdmissionResourcesToBeReferred)
    public ResourcesToBeReferredList: Array<PatientAdmissionResourcesToBeReferred> = new Array<PatientAdmissionResourcesToBeReferred>();
    @Type(() => Appointment.GetAppointmentByDateAndPatient_Class)
    public AppointmentList: Array<Appointment.GetAppointmentByDateAndPatient_Class> = new Array<Appointment.GetAppointmentByDateAndPatient_Class>();
    @Type(() => vmAppointmentListInfo)
    public AppointmentListInfo: Array<vmAppointmentListInfo> = new Array<vmAppointmentListInfo>();
    @Type(() => MernisPatientModel)
    public MernisPatientModel: MernisPatientModel;
    @Type(() => Boolean)
    public CheckMernisRole: boolean;
    @Type(() => Boolean)
    public HasBuilding: boolean;
    @Type(() => Boolean)
    public GetTotalSepCount: boolean;
    @Type(() => Boolean)
    public HasTriageArea: boolean;
    @Type(() => Boolean)
    public GizliHastaKabulRole: boolean;
    @Type(() => Boolean)
    public IsSuperUser: boolean;
    @Type(() => Boolean)
    public RehabilitationApplication: boolean;
    @Type(() => Boolean)
    public DispatchTabActive: boolean;
    @Type(() => Boolean)
    public HealthCommissionTabActive: boolean;
    @Type(() => Boolean)
    public MainTabActive: boolean;
    public tempName: string = "";
    public tempSurname: string = "";
    public tempPrivacyName: string = "";
    public tempPrivacySurname: string = "";
    public tempHomeAddress: string = "";
    public tempMobilePhone: string = "";
    @Type(() => PayerDefinition)
    public tempDispatchPayer: PayerDefinition = new PayerDefinition();
    @Type(() => PayerDefinition)
    public tempPayer: PayerDefinition = new PayerDefinition();
    //@Type(() => Number)
    public tempUniqueRefNo: number;
    public PaCountByUser: number;
    public activeTab: number;
    @Type(() => Boolean)
    public GetProvisionFromMedula: boolean;
    @Type(() => Boolean)
    public showPayerAlert: boolean = false;
    @Type(() => Boolean)
    public ModifyPatientInfoRole: boolean = false;
    public PhotoString: string = '';
    @Type(() => Guid)
    public StarterEpisodeAction: Guid;
    public AllProceduresLink: string;
    public AllLabProceduresLink: string;
    public tempBranch: DepartmentModel;
    @Type('ResPoliclinic')
    public tempPoliclinic: ResPoliclinic;
    @Type('ResPoliclinic')
    public tempDispatchPoliclinic: ResPoliclinic;
    @Type('ResUser')
    public tempProcedureDoctor: ResUser;
    @Type('ResUser')
    public tempDispatchProcedureDoctor: ResUser;
    @Type(() => Boolean)
    public hasDoctorKotaRole: boolean;

    @Type(() => Boolean)
    public ControlPreviousHcExam: boolean;
    @Type(() => Number)
    public HCControlDayLimit: number;

    @Type(() => Boolean)
    public openKPSLoginInfo: boolean;

    @Type(() => Boolean)
    public fromVerifiedKPSBtn: boolean = false;

    @Type(() => Boolean)
    public canGetEpicrisisReport: boolean;
    @Type(() => DisabledReportProperties)
    public disabledReportProperties: DisabledReportProperties;  

    @Type(() => Boolean)
    public getRelatedResourceParam: boolean;

    public relatedBransList: string = "";
    public relatedPoliclinicList: string = "";
    public relatedPoliclinicDoctorList: string = "";    

    @Type(() => Boolean)
    public getLastSelectedDoctorandPoliclinic:boolean;

    @Type(() => Boolean)
    public hasGiveAppointmentRole: boolean;

    @Type(() => ResUser)
    public ProcedureDoctorToBeReferred: Array<ResUser> = new Array<ResUser>();

    @Type(() => ResPoliclinic)
    public ResourcesToBeReferredPoliclinic: Array<ResPoliclinic> = new Array<ResPoliclinic>();

    @Type(() => ResPoliclinic)
    public PoliclinicListForFilter: Array<ResPoliclinic> = new Array<ResPoliclinic>();
       
    public HospitalName: string;

    @Type(() => SubEpisode)
    public subEpisode: SubEpisode;

    @Type(() => EpisodeAction)
    public episodeAction: EpisodeAction;

    @Type(() => Boolean)
    public VerifiedKpsWithoutApprove: boolean;

    @Type(() => Boolean)
    public AddProcedureToHC: boolean;

    @Type(() => Boolean)
    public PrintMedulaCodeReport: boolean;

    @Type(() => Boolean)
    public IsPandemicPatient: boolean;

    @Type(() => ExternalHospitalDefinition)
    public ExternalHospitalDefinitions: Array<ExternalHospitalDefinition> = new Array<ExternalHospitalDefinition>();
    @Type(() => Boolean)
    public NewPatientBarcode: boolean; 

    @Type(() => Boolean)
    public AcilDoktorSecimiZorla: boolean;

    public KurumSevkTalepNo: string;//clietn model convert olmadığı için veri taşımakta kullanılıyor

    @Type(() => Boolean)
    public KurumSevkTalepNoZorla: boolean;
    
}

export class DisabledReportProperties{
    public ApplicationExplanation : string;
    public ApplicationReason: EngelliRaporuMuracaatNedeniEnum;
    public ApplicationType: EngelliRaporuMuracaatTipiEnum;
    public CorporateApplicationType: EngelliRaporuKurumsalMuracaatTuruEnum;
    public PersonalApplicationType: EngelliRaporuKisiselMuracaatTuruEnum;
    public TerrorAccidentInjuryAppReason: EngelliRaporuTerorKazaMuracaatNedeniEnum;
    public TerrorAccidentInjuryAppType: EngelliRaporuTerorKazaMuracaatTipiEnum;
}

export class vmAppointmentListInfo {
    @Type(() => Guid)
    Id: Guid;
    Masterresourcename: string;
    DoctorName: string;
    Notes: string;
    @Type(() => Date)
    AppDate: Date = new Date();
    AppTime: string;
}
export class MernisPatientModel {
    public KPSName: string = "";
    public KPSSurname: string = "";
    public KPSMotherName: string = "";
    public KPSFatherName: string = "";
    public KPSBirthPlace: string = "";
    @Type(() => Boolean)
    public KPSAlive: boolean;
    @Type(() => Boolean)
    public KPSForeign: boolean;
    @Type(() => Number)
    public KPsForeignUniqueRefNo: number;
    @Type(() => Number)
    public KPSUniqueRefNo: number;

    @Type('SKRSUlkeKodlari')
    public KPSNationality: SKRSUlkeKodlari = new SKRSUlkeKodlari();
    @Type('SKRSCinsiyet')
    public KPSSex: SKRSCinsiyet = new SKRSCinsiyet();
    @Type('SKRSMedeniHali')
    public SKRSMaritalStatus: SKRSMedeniHali = new SKRSMedeniHali();

    public KPSNationalityName: string = "";
    public KPSSexName: string = "";
    public KPSCityOfBirth: string = "";
    public SKRSMaritalStatusName: string = "";

    @Type(() => Date)
    public KPSBirthDate: Date;
    @Type(() => Date)
    public KPSExDate: Date;
    public HomeAddress: string = "";

}

export class GetHCRequestReasonDetailsResponse {
    @Type(() => HCRequestReasonDetail)
    public requestReasonDetail: HCRequestReasonDetail = new HCRequestReasonDetail();
    @Type(() => HCReportTypeDefinition)
    public reportTypeDefinition: HCReportTypeDefinition = new HCReportTypeDefinition();
}

export class HCRequestReasonDetail {
    @Type(() => ReasonForExaminationDefinition)
    public ReasonForExaminationDefinition: ReasonForExaminationDefinition;
    @Type(() => HCHospitalUnit)
    public HospitalsUnits: Array<HCHospitalUnit> = new Array<HCHospitalUnit>();
}

export class HCHospitalUnit {
    @Type(() => HospitalsUnitsDefinitionGrid)
    public HospitalsUnit: HospitalsUnitsDefinitionGrid;
    @Type(() => ResUser)
    public ProcedureDoctor: ResUser;
    @Type(() => ResPoliclinic)
    public Policlinic: ResPoliclinic;
    @Type(() => SpecialityDefinition)
    public Speciality: SpecialityDefinition;
    public AdmissionQueueNumber: string;

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
export class FazlaTakipDTO {
    public ID: string;
    public hastaBasvuruNo: string;
    public takipNo: string;
    public takipTarihi: string;
    public bransKodu: string;
    public tedaviTuru: string;
    public durum: string;
}
export class FazlaTakipBilgileriDTO {
    public tc: string;
    public ilkTarih: Date;
    public sonTarih: Date;
    public takipListesi: Array<FazlaTakipDTO>;

    constructor() {
        this.takipListesi = new Array<FazlaTakipDTO>();
    }
}

export class SearchWithPatientIDResult {
    @Type(() => Patient)
    public Patient: Array<Patient> = new Array<Patient>();
}

export class PersonnelTakeOff_Input {
    @Type(() => Date)
    public ControlDate: Date;
    public ResuserID:string;

}

export class PatientAdmissionListModel {
    @Type(() => Guid)
    public SepObjectID: Guid;
    @Type(() => Guid)
    public Patientid:Guid;
    public Paid:any;
    public ProvisionType:string;
    public Fullname:string;
    public Patientadmissionnumber:string;
    @Type(() => Date)
    public ActionDate:Date;
    public Policlinic:string;
    public MedulaTakipNo:string;
    public AdmissionType: string; //Geliş Sebebi
    public Forensiccasetype: string;  //Geliş Şekli
    public UniqueRefNo: string;
    public Triage: string;


}

export class DepartmentModel
{
    public Name: string;
    public ObjectID: Guid;
    public IsEmergencyDepartment: boolean;
    public NameShadow: string;
}


export class PoliclinicModel
{
    public Name: string;
    public ObjectID: Guid;
    public Department: DepartmentModel;
}

export class InputModelForQueries
{
    public filter: string;
}

export class branchValue
{
    public branchvalue : DepartmentModel;
}
 
export class EpicrisisReport_Class {
    @Type(() => Guid)
    public ObjectID: Guid;
    public MasterResource: string; //Yattığı Klinik
    @Type(() => Guid)
    public MasterResourceID: Guid;
}

export class MergeEmergencyClass
{
    @Type(() => Patient)
    public patient:Patient;

    public emergencyDoctor:string;
    
    public emergencyPoliclinic:string;
    @Type(() => SKRSTRIAJKODU)
    public emergencyTriage:SKRSTRIAJKODU;

}

export class YurtDisiYardimHakki
{
    public Aciklama:string;
    public Formul:string;
    @Type(() => Number)
    public YardimHakID: number;
}

export class HastaTemasDurumuResultModel
{
    @Type(() => Boolean)
    public isResponseSuccess:boolean;
    public responseMessage:string;
}

export class SevkTalepNoSonucDetay {
    public kurumSevkTalepNo: string;
    public sevkTarihi: string;
    public saglikTesisKodu: string;
    public hastaBasvuruNo: string;
    public aciklama: string;
}
export class SevkTalepNoSonuc {
    public sonucKodu: string;
    public sonucMesaji: string;
    public SevkTalepNoSonucDetay: Array<SevkTalepNoSonucDetay>;
}

export class FilterDoctorModel {
    public Name: string;
    public ObjectID: Guid;
}