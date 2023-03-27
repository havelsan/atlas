//$6B72D520
import { Type, ClassType } from 'NebulaClient/ClassTransformer';
import { EpisodeActionWithDiagnosis } from 'NebulaClient/Model/AtlasClientModel';
import { AyniFarkliKesi } from 'NebulaClient/Model/AtlasClientModel';
import { CokluOzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NuclearMedicineTest } from 'NebulaClient/Model/AtlasClientModel';
import { NuclearMedicineTestDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedRadPharmMatGrid } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedTreatmentMat } from 'NebulaClient/Model/AtlasClientModel';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { PatientStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { RadyofarmasotikDirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SagSol } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryDirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectContext } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectContext';

@ClassType(NuclearMedicine.ObjectDefID.toString())
export class NuclearMedicine extends EpisodeActionWithDiagnosis {
    protected __type__: string = 'TTObjectClasses.NuclearMedicine, TTObjectClasses';
    public static ObjectDefName: string = 'NUCLEARMEDICINE';
    public static ObjectDefID: Guid = new Guid('ffb5f11a-93ec-4b54-881c-57ca00f26f63');
    public NucMedDoctorNote: string;
    public Report: Object;
    @Type(() => Number)
    public PatientAge: number;
    public RadioPharmacyDescription: string;
    public NuclearMaterialName: string;
    public RepeatationReason: string;
    @Type(() => Date)
    public InjectionDate: Date;
    public RequestCorrectionReason: string;
    @Type(() => Number)
    public PatientWeight: number;
    @Type(() => Number)
    public ProtocolNo: number;
    @Type(() => Number)
    public TestSequenceNo: number;
    @Type(() => Date)
    public PharmaceuticalPrepDate: Date;
    public PatientPhoneNumber: string;
    @Type(() => Boolean)
    public IsEmergency: boolean;
    public RequestDoctorPhone: string;
    public PreDiagnosis: string;
    @Type(() => Date)
    public ProcedureDate: Date;
    public ReportTxt: string;
    @Type(() => Date)
    public ReportDate: Date;
    public raporTakipNo: string;
    @Type(() => Guid)
    public TargetObjectID: Guid;
    @Type(() => Guid)
    public SourceObjectID: Guid;
    public birim: string;
    public MedulaAciklama: string;
    public drAnesteziTescilNo: string;
    @Type('ResUser')
    public ResponsibleDoctor: ResUser;
    @Type('ResUser')
    public RequestDoctor: ResUser;
    @Type('ResUser')
    public InjectedBy: ResUser;
    @Type('NuclearMedicineTestDefinition')
    public NuclearMedicineTest: NuclearMedicineTestDefinition;
    @Type('ResUser')
    public ResponsibleAcademicStaff: ResUser;
    @Type('OzelDurum')
    public OzelDurum: OzelDurum;
    @Type('SagSol')
    public SagSol: SagSol;
    @Type('ResUser')
    public AnesteziDoktor: ResUser;
    @Type('AyniFarkliKesi')
    public AyniFarkliKesi: AyniFarkliKesi;
    @Type('CokluOzelDurum')
    public CokluOzelDurum: Array<CokluOzelDurum>;
    @Type('NuclearMedicineTest')
    public NuclearMedicineTests: Array<NuclearMedicineTest>;
    @Type('NucMedRadPharmMatGrid')
    public RadPharmMaterials: Array<NucMedRadPharmMatGrid>;
    @Type('NucMedTreatmentMat')
    public NucMedTreatmentMats: Array<NucMedTreatmentMat>;
    @Type('SurgeryDirectPurchaseGrid')
    public NuclearMedicine_SurgeryDirectPurchaseGrids: Array<SurgeryDirectPurchaseGrid>;
    @Type('RadyofarmasotikDirectPurchaseGrid')
    public NuclearMedicine_RadyofarmasotikDirectPurchaseGrids: Array<RadyofarmasotikDirectPurchaseGrid>;
    constructor(objectContext?: TTObjectContext) {
        super(objectContext);

    }
}

export namespace NuclearMedicine {
    export class NuclearMedicinePatientInfoNQL_Class {
        UniqueRefNo: number;
        Name: string;
        Surname: string;
        FatherName: string;
        BirthDate: Date;
        Cityname: Object;
        Townname: string;
        Fromres: string;
        Requestdate: Date;
        Requestdoctor: string;
        ProtocolNo: number;
    }
    export class NuclearMedicineReportNQL_Class {
        ObjectID: Guid;
        ObjectDefID: Guid;
        CurrentStateDefID: Guid;
        LastUpdate: Date;
        ActionDate: Date;
        Cancelled: boolean;
        ReasonOfCancel: string;
        Active: boolean;
        WorkListDate: Date;
        ReasonOfReject: Object;
        ID: number;
        OlapLastUpdate: Date;
        OlapDate: Date;
        ClonedObjectID: Guid;
        WorkListDescription: string;
        IsOldAction: boolean;
        RequestDate: Date;
        Emergency: boolean;
        PatientPay: boolean;
        OrderObject: string;
        DescriptionForWorkList: string;
        IgnoreEpisodeStateOnUpdate: boolean;
        NucMedDoctorNote: string;
        Report: Object;
        PatientAge: number;
        RadioPharmacyDescription: string;
        NuclearMaterialName: string;
        RepeatationReason: string;
        InjectionDate: Date;
        RequestCorrectionReason: string;
        PatientWeight: number;
        ProtocolNo: number;
        TestSequenceNo: number;
        PharmaceuticalPrepDate: Date;
        PatientPhoneNumber: string;
        IsEmergency: boolean;
        RequestDoctorPhone: string;
        PreDiagnosis: string;
        ProcedureDate: Date;
        ReportTxt: string;
        ReportDate: Date;
        raporTakipNo: string;
        TargetObjectID: Guid;
        SourceObjectID: Guid;
        birim: string;
        MedulaAciklama: string;
        drAnesteziTescilNo: string;
        Patientname: string;
        Surname: string;
        Sex: Guid;
        Prediagnosis1: string;
        Reqdoctorname: string;
        Responsibledoct: string;
        Masterresname: string;
        Fromresourcename: string;
    }
    export class GetByNuclearMedicineWorklistDateReport_Class {
        ObjectID: Guid;
        Patientfullname: Object;
        Fromresourcename: string;
        WorkListDate: Date;
        Masterresourcename: string;
        Emergency: boolean;
        Patientobjectid: Guid;
        Patientgroup: Object;
        Foreign: boolean;
        ForeignUniqueRefNo: number;
        UniqueRefNo: number;
        PatientStatus: PatientStatusEnum;
        Proceduredoctorname: string;
        TestSequenceNo: number;
        ID: number;
        RefNo: string;
    }
    export class GetByWLFilterExpressionReport_Class {
        ObjectID: Guid;
        Patientfullname: Object;
        Fromresourcename: string;
        WorkListDate: Date;
        Masterresourcename: string;
        Emergency: boolean;
        Patientobjectid: Guid;
        Patientgroup: Object;
        Foreign: boolean;
        ForeignUniqueRefNo: number;
        UniqueRefNo: number;
        PatientStatus: PatientStatusEnum;
        Proceduredoctorname: string;
        TestSequenceNo: number;
        ID: number;
        RefNo: string;
    }
    export class NuclearMedicineStates {
        public static Approve: Guid = new Guid('552a20d7-a374-4ba6-8b3e-0734cbcb0f18');
        public static Rejected: Guid = new Guid('4c00534c-9e48-4470-be80-2476995fe50f');
        public static AppointmentInfo: Guid = new Guid('1401d87c-2cbe-4bdf-af05-4c18a372bc54');
        public static Preparation: Guid = new Guid('934d28ac-446d-4a1e-917c-598fa00435d9');
        public static RequestAcception: Guid = new Guid('1b6ef70b-004d-4bd8-b63f-292417c8a31d');
        public static RadioPharmacy: Guid = new Guid('05cfe20a-a4a8-4525-a72a-8bc64bd5ada9');
        public static Reported: Guid = new Guid('2617a8b0-dd44-4040-98f4-b7d0c2002c7c');
        public static Procedure: Guid = new Guid('3eb374d0-477e-4084-b7df-b9fb0a6a2cdf');
        public static Cancelled: Guid = new Guid('676bde6d-8727-493a-bc09-a9ed5a19f3e0');
        public static Request: Guid = new Guid('967ec4b5-098b-43a0-b11b-c9be8b3e1e6c');
        public static Doctor: Guid = new Guid('04502d8a-f2ce-4387-9d4f-db2e6d440926');
        public static AdmissionAppointment: Guid = new Guid('b3b6618e-896d-4dcb-a830-dcf3882d717f');
    }
    @ClassType()
    export class NuclearMedicineParentRelations {
        public static MasterAction: Guid = new Guid('85ff4d04-c064-4c33-9d04-a30beaecea63');
        public static SecondaryMasterResource: Guid = new Guid('478d572c-c33a-4f0e-a271-21c9fe5221b3');
        public static MasterResource: Guid = new Guid('3eb39d70-4070-45c5-96c8-7a04f540b89f');
        public static FromResource: Guid = new Guid('a64e1957-f7b1-4ccb-8083-a49d43e9cf6f');
        public static ProcedureSpeciality: Guid = new Guid('3ab87f9f-a63a-4367-825f-c55abb7c7b36');
        public static Episode: Guid = new Guid('47112414-1c22-4ae4-876e-e995cd6a3fc7');
        public static MedulaHastaKabul: Guid = new Guid('48baad19-8383-4179-97e2-2211cb7b0487');
        public static PatientAdmission: Guid = new Guid('6d464855-4319-47e5-ad53-749144d7f77c');
        public static SubEpisode: Guid = new Guid('fd7492c2-d2d2-4918-bcbb-87f3174e9f89');
        public static ProcedureDoctor: Guid = new Guid('6aaf5efd-18cc-4c7e-8766-42408f914393');
        public static ProcedureByUser: Guid = new Guid('6f08469d-2b82-4af5-81a6-671e5e41d44f');
        public static ResponsibleDoctor: Guid = new Guid('b4ab2521-fd33-4127-9a61-093310d4088d');
        public static RequestDoctor: Guid = new Guid('14b61199-a495-4e86-814e-48d4a094e0f1');
        public static InjectedBy: Guid = new Guid('cd2d9118-d0a7-419b-8651-b47f97134543');
        public static NuclearMedicineTest: Guid = new Guid('85796f65-7d94-4c39-95cf-dfdc9223fe73');
        public static ResponsibleAcademicStaff: Guid = new Guid('efcc53cb-2ac8-43e0-af57-5647d4415300');
        public static OzelDurum: Guid = new Guid('d09dea46-839c-403a-9184-612ead259713');
        public static SagSol: Guid = new Guid('4d365834-f7fe-4cce-a55e-80cbd78fd5fe');
        public static AnesteziDoktor: Guid = new Guid('090f1fb3-0958-4a0e-bc2d-ebbf34c62cd2');
        public static AyniFarkliKesi: Guid = new Guid('570e61c2-7672-4cc3-8aa6-0308079d45dc');
    }
}


