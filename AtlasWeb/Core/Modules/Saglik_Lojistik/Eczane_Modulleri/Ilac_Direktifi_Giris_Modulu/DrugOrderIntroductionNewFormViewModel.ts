//$B6481080
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { DrugOrderIntroduction, DrugOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { OldDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientPresDetail } from 'NebulaClient/Model/AtlasClientModel';
import { OutpatientPresDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisForPresc } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderIntroductionDet } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { OutPatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { OutPatientDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisode } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';


export class DrugOrderIntroductionNewFormViewModel extends BaseViewModel {
    public _DrugOrderIntroduction: DrugOrderIntroduction = new DrugOrderIntroduction();
    public OldDrugOrdersGridList: Array<OldDrugOrder> = new Array<OldDrugOrder>();
    public InpatientPresDetailsGridList: Array<InpatientPresDetail> = new Array<InpatientPresDetail>();
    public OutpatientPresDetailsGridList: Array<OutpatientPresDetail> = new Array<OutpatientPresDetail>();
    public DiagnosisForPrescriptionsGridList: Array<DiagnosisForPresc> = new Array<DiagnosisForPresc>();
    public DrugOrderIntroductionDetailsGridList: Array<DrugOrderIntroductionDet> = new Array<DrugOrderIntroductionDet>();
    public ResSections: Array<ResSection> = new Array<ResSection>();
    public Stores: Array<Store> = new Array<Store>();
    public DrugOrders: Array<DrugOrder> = new Array<DrugOrder>();
    public Materials: Array<Material> = new Array<Material>();
    public InpatientPrescriptions: Array<InpatientPrescription> = new Array<InpatientPrescription>();
    public OutPatientPrescriptions: Array<OutPatientPrescription> = new Array<OutPatientPrescription>();
    public Episodes: Array<Episode> = new Array<Episode>();
    public Patients: Array<Patient> = new Array<Patient>();
    public InpatientDrugOrders: Array<InpatientDrugOrder> = new Array<InpatientDrugOrder>();
    public OutPatientDrugOrders: Array<OutPatientDrugOrder> = new Array<OutPatientDrugOrder>();
    public PrescriptionSignContentList: Array<PrescriptionSignContent> = new Array<PrescriptionSignContent>();
    public DiagnosisDefinitionList: Array<DiagnosisDefinitionList> = new Array<DiagnosisDefinitionList>();
    public SubEpisodes: Array<SubEpisode> = new Array<SubEpisode>();
    public DrugOrderDetails: Array<DrugOrderDetail> = new Array<DrugOrderDetail>();
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();


}

export class PrescriptionSignContent {
    public PrescriptionObjectID: Guid;
    public SignContent: string;
    public OrderNo: number;
}

export class DiagnosisDefinitionList {
    public DiagnosisName: string;
    public DiagnosisObjID: Guid;
}

export class GetPatientDiagnosisGrid_output {

    public diagnosisGrid: DiagnosisGrid;
    public diagnosis: DiagnosisDefinition;
    public responsibleDoctor: ResUser;
}

export class DrugOrderObjectModel {
    public drugOrder: DrugOrder;
    public material: Material;
}
export class CreateDrugOrderTS_Input {
    public IsImmediate: boolean;
    public DrugObjectID: Guid;
    public PlannedStartTime: Date;
    public DrugDescription: string;
    public EpisodeObjectID: Guid;
    public MasterResourceObjectID: Guid;
    public SecondaryMasterResourceObjectID: Guid;
    public SubEpisodeObjectID: Guid;
    public ActiveInPatientPhysicianAppObjectID: Guid;
    public CaseOfNeed: boolean;
    public drugOrderIntroductionDet: DrugOrderIntroductionDet;

}
export class SignedPrescriptionOutput {
    public PrescriptionSignContentList: Array<PrescriptionSignContent>;
}

export class PrepareSignedDeletePrescriptionContent_Input {
    public eReceteNo: string;
}

export class SendSignedDeletePrescriptionContent_Input {
    public singContent: string;
}



export class PrepareSignedDiagPrescriptionContent_Input {
    public eReceteNo: string;
    public diagnosisObjID: Guid;
}

export class SendSignedDiagPrescriptionContent_Input {
    public singContent: string;
}

export class PrepareSignedRecipeDescriptionPrescriptionContent_Input {
    public eReceteNo: string;
    public drugDescriptionType: number;
    public desciption: string;
}
export class SendSignedRecipeDescriptionPrescriptionContent_Input {
    public singContent: string;
}

export class PrepareSignedDrugDescriptionPrescriptionContent_Input {
    public eReceteNo: string;
    public drugDesciption: string;
    public barcode: string;
    public drugDescriptionType: number;
}
export class SendSignedDrugDescriptionPrescriptionContent_Input {
    public singContent: string;
}


export class DiagnosisByEpisode_Output {
    public diagnosisList: DiagnosisItem[];
    //public characteristicModel: PatientCharacteristics;
}
export class DiagnosisItem {
    public diagnosisName: string;
    public diagnosisCode: string;
}