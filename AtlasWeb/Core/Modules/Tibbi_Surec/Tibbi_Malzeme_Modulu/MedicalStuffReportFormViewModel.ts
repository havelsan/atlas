//$693CF46F
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { MedicalStuffReport, DiagnosisDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ReportDiagnosisFormViewModel } from '../Tani_Modulu/ReportDiagnosisFormViewModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalStuffDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalStuffGroup } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalStuffPlaceOfUsage } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalStuff } from "NebulaClient/Model/AtlasClientModel";
import { TibbiMalzemeERaporIslemleri } from 'NebulaClient/Services/External/TibbiMalzemeERaporIslemleri';
import { MedicalStuffUsageType } from "NebulaClient/Model/AtlasClientModel";
import { UserTemplateModel } from "../Hasta_Raporlari_Modulu/ParticipationFreeDrugReportNewFormViewModel";

export class MedicalStuffReportFormViewModel extends BaseViewModel {
    public _MedicalStuffReport: MedicalStuffReport = new MedicalStuffReport();
    @Type(() => Boolean)
    public IsSuperUser: boolean;
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ReportDiagnosisFormViewModel)
    public reportDiagnosisFormViewModel: ReportDiagnosisFormViewModel = new ReportDiagnosisFormViewModel();
    public diagnosisCodeList: Array<string> = new Array<string>();
    @Type(() => MedicalStuffDefinition)
    public MedicalStuffList: Array<MedicalStuffDefinition> = new Array<MedicalStuffDefinition>();
    @Type(() => MedicalStuffGroup)
    public MedicalStuffGroups: Array<MedicalStuffGroup> = new Array<MedicalStuffGroup>();
    @Type(() => MedicalStuffPlaceOfUsage)
    public MedicalStuffPlaceOfUsages: Array<MedicalStuffPlaceOfUsage> = new Array<MedicalStuffPlaceOfUsage>();
    @Type(() => MedicalStuffUsageType)
    public MedicalStuffUsageTypes: Array<MedicalStuffUsageType> = new Array<MedicalStuffUsageType>();
    @Type(() => MedicalStuffDefinition)
    public MedicalStuffDefinitions: Array<MedicalStuffDefinition> = new Array<MedicalStuffDefinition>();
    @Type(() => Guid)
    public ToState: Guid;
    @Type(() => MedicalStuffReport.GetMedicalStuffReportListByID_Class)
    public MedicalStuffReportList: Array<PatientMedicalStuffReportClass> = new Array<PatientMedicalStuffReportClass>();
    public activeTab: number;
    @Type(() => MedicalStuff)
    public MedicalStuffGridGridList: Array<MedicalStuff> = new Array<MedicalStuff>();
    @Type(() => ReportSignContent)
    public ReportSignContentList: Array<ReportSignContent> = new Array<ReportSignContent>();
    public isStateSecondDoctorApproval: boolean;
    public isStateThirddDoctorApproval: boolean;
    public isStateHeadDoctorApproval: boolean;
    public medulaUsername: string;
    public medulaPassword: string;
    public minReportDate: string = "";
    public maxReportDate: string = "";
    @Type(() => UserTemplateModel)
    public userTemplateList: Array<UserTemplateModel> = new Array<UserTemplateModel>();

    @Type(() => UserTemplateModel)
    public selectedUserTemplate: UserTemplateModel;

    public isPrescriptionWriteable: boolean = false;
    public secondDoctor: string;
    public thirdDoctor: string;
}
export class DataModel {
    public ObjectId: string;
    public ObjectName: string;
}

export class eRaporOnayCevapDVO {
    public sonucKodu: string;
    public sonucMesaji: string;
    public uyariMesaji: string;
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
    public eRaporDVO: Array<TibbiMalzemeERaporIslemleri.eRaporDVO> = new Array<TibbiMalzemeERaporIslemleri.eRaporDVO>();

    constructor() {
        this.SonucKodu = "";
        this.SonucMesaji = "";
        this.Succes = false;
        this.TakipNo = "";
        this.BasvuruNo = "";
        this.SEPObjectID = "";
        this.eRaporDVO = new Array<TibbiMalzemeERaporIslemleri.eRaporDVO>();
    }
}

export class ReportSignContent {
    public ReportObjectID: Guid;
    public SignContent: string;
    public OrderNo: number;
}

export class DiagnosisDefinitionList {
    public DiagnosisName: string;
    public DiagnosisObjID: Guid;
}

export class SignedReportOutput {
    public ReportSignContentList: Array<ReportSignContent>;
}


export class DiagnosisByEpisode_Output {
    public diagnosisList: DiagnosisItem[];
}
export class DiagnosisItem {
    public diagnosisName: string;
    public diagnosisCode: string;
}

export class PrepareSignedReportContent_Input {
    public eRaporObjectID: Guid;
}
export class SendSignedReportContent_Input {
    public singContent: string;
    //public ReportObjectID: Guid;
    public MedicalStuffReportFormViewModel: MedicalStuffReportFormViewModel;
}

export class PrepareSignedDeleteReportContent_Input {
    public eRaporTakipNo: string;
}

export class SendSignedDeleteReportContent_Input {
    public singContent: string;
    public ReportObjectID: Guid;
}


export class PrepareSignedSearchReportContent_Input {
    public eRaporTakipNo: string;
}

export class SendSignedSearchReportContent_Input {
    public singContent: string;
    public MedicalStuffReportFormViewModel: MedicalStuffReportFormViewModel;
}

export class MedicalStuffReportApproveModel {
    @Type(() => MedicalStuffReport)
    public medicalStuffReport: MedicalStuffReport = new MedicalStuffReport();
    public medulaUsername: string;
    public medulaPassword: string;
    public isSecondDoctorApprove: boolean = false;
    public isThirdDoctorApprove: boolean = false;
}

export class PatientMedicalStuffReportClass {
    ObjectID: Guid;
    RaporTakipNo: string;
    ReportNo: number;
    StartDate: Date;
    EndDate: Date;
    Proceduredoctor: string;
    Seconddoctor: string;
    Thirddoctor: string;
    IsSendedMedula: boolean;
}

export class AddTibbiMalzemeClass {
    public medicalStuff: MedicalStuff;
    public medulaUsername: string;
    public medulaPassword: string;
}

export class AddDiagnosisClass {
    public Diagnose: DiagnosisDefinition;
    public ReportObject: MedicalStuffReport;
    public medulaUsername: string;
    public medulaPassword: string;
}

export class ChangeReportDescriptionClass {
    public medicalStuffReport: MedicalStuffReport;
    public medulaUsername: string;
    public medulaPassword: string;
}