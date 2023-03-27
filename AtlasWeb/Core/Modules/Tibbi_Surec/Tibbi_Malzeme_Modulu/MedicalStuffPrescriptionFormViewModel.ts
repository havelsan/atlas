//$1767B315
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { MedicalStuffPrescription, PeriodUnitTypeEnum, DiagnosisDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { MedicalStuff, MedicalStuffGroup, MedicalStuffPlaceOfUsage, MedicalStuffDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { TibbiMalzemeERaporIslemleri } from 'NebulaClient/Services/External/TibbiMalzemeERaporIslemleri';
import { ReportDiagnosisFormViewModel } from '../Tani_Modulu/ReportDiagnosisFormViewModel';
import { MedicalStuffUsageType } from "NebulaClient/Model/AtlasClientModel";

export class MedicalStuffPrescriptionFormViewModel extends BaseViewModel {
    public _MedicalStuffPrescription: MedicalStuffPrescription = new MedicalStuffPrescription();
    @Type(() => Boolean)
    public IsSuperUser: boolean;
    @Type(() => Guid)
    public ToState: Guid;
    @Type(() => MedicalStuffPrescription.GetMedicalStuffPrescriptionListByID_Class)
    //public MedicalStuffPrescriptionList: Array<MedicalStuffPrescription.GetMedicalStuffPrescriptionListByID_Class> = new Array<MedicalStuffPrescription.GetMedicalStuffPrescriptionListByID_Class>();
    public activeTab: number;
    @Type(() => MedicalStuff)
    public MedicalStuffGridGridList: Array<MedicalStuff> = new Array<MedicalStuff>();
    @Type(() => MedicalStuffGroup)
    public MedicalStuffGroups: Array<MedicalStuffGroup> = new Array<MedicalStuffGroup>();
    @Type(() => MedicalStuffPlaceOfUsage)
    public MedicalStuffPlaceOfUsages: Array<MedicalStuffPlaceOfUsage> = new Array<MedicalStuffPlaceOfUsage>();
    @Type(() => MedicalStuffUsageType)
    public MedicalStuffUsageTypes: Array<MedicalStuffUsageType> = new Array<MedicalStuffUsageType>();
    @Type(() => MedicalStuffDefinition)
    public MedicalStuffDefinitions: Array<MedicalStuffDefinition> = new Array<MedicalStuffDefinition>();
    @Type(() => PrescriptionSignContent)
    public PrescriptionSignContentList: Array<PrescriptionSignContent> = new Array<PrescriptionSignContent>();
    @Type(() => Guid)
    public prescriptionEpisodeAction: Guid;
    @Type(() => Guid)
    public episode: Guid;
    @Type(() => Guid)
    public reportEpisodeAction: Guid;
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public diagnosisCodeList: Array<string> = new Array<string>();
    @Type(() => ReportDiagnosisFormViewModel)
    public reportDiagnosisFormViewModel: ReportDiagnosisFormViewModel = new ReportDiagnosisFormViewModel();
    @Type(() => MedicalStuffDefinitionObject)
    public medicalStuffs: Array<MedicalStuff> = new Array<MedicalStuff>();
    @Type(() => OldMedicalStuffPrescriptionModel)
    public oldMedicalStuffPrescriptions: Array<OldMedicalStuffPrescriptionModel> = new Array<OldMedicalStuffPrescriptionModel>();
    public medulaUsername: string;
    public medulaPassword: string;
}
export class DataModel {
    public ObjectId: string;
    public ObjectName: string;
}

export class MedicalStuffDefinitionObject {
    @Type(() => Guid)
    public MedicalStuffDefId: Guid;
    public MedicalStuffDefName: string;
    public MedicalStuffDefCode: string;
    public MedicalStuffAmount: number;
    public PeriodUnit: string;
    public PreiodUnitType: PeriodUnitTypeEnum;
    public MedicalStuffPlaceOfUsage: string;
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
export class PrescriptionSignContent {
    public PrescriptionObjectID: Guid;
    public SignContent: string;
    public OrderNo: number;
}
export class SignedPrescriptionOutput {
    public PrescriptionSignContentList: Array<PrescriptionSignContent>;
}

export class PrepareSignedPrescriptionContent_Input {
    public eReceteObjectID: Guid;
}

export class SendSignedPrescriptionContent_Input {
    public signContent: string;
}

export class PrepareSignedDiagPrescriptionContent_Input {
    public eReceteNo: string;
    public diagnosisObjID: Guid;
}

export class SendSignedDiagPrescriptionContent_Input {
    public singContent: string;
    public PrescriptionObjectID: Guid;
}

export class PrepareSignedDescriptionPrescriptionContent_Input {
    public eReceteNo: string;
    public drugDescriptionType: number;
    public desciption: string;
}
export class SendSignedDescriptionPrescriptionContent_Input {
    public singContent: string;
    public PrescriptionObjectID: Guid;
}

export class PrepareSignedDeletePrescriptionContent_Input {
    public eReceteNo: string;
}

export class SendSignedDeletePrescriptionContent_Input {
    public singContent: string;
    public PrescriptionObjectID: Guid;
}

export class DiagnosisByEpisode_Output {
    public diagnosisList: DiagnosisItem[];
}
export class DiagnosisItem {
    public diagnosisName: string;
    public diagnosisCode: string;
}

export class DiagnosisDefinitionList {
    public DiagnosisName: string;
    public DiagnosisObjID: Guid;
}

export class OldMedicalStuffPrescriptionModel {
    public ObjectID: Guid;
    public PrescriptionNo: string;
    public ReportNo: string;
    public RaporTakipNo: string;
    public ProcedureDoctor: string;
    public ActionDate: Date;
    public IsSendedMedula: boolean;
}

export class AddDiagnosisToPrescriptionClass {
    public Diagnose: DiagnosisDefinition;
    public PrescriptionObject: MedicalStuffPrescription;
    public medulaUsername: string;
    public medulaPassword: string;
}

export class AddDiagnosisToPrescriptionResponseClass {
    public sonucKodu: string;
    public sonucMesaji: string;
    public uyariMesaji: string;
}

export class eReceteListeSorgulaClass {
    public PrescriptionObject: MedicalStuffPrescription;
    public medulaUsername: string;
    public medulaPassword: string;
}