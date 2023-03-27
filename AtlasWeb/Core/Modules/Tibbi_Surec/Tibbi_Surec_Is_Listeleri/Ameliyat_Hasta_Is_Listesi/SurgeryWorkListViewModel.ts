//$DB89F690
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseEpisodeActionWorkListFormViewModel, BaseEpisodeActionWorkListSearchCriteria, BaseEpisodeActionWorkListItem } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel";
import { ResSection, ResUser, SurgeryDefinition, ProvizyonTipi, SurgeryStatusDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

export class SurgeryWorkListViewModel extends BaseEpisodeActionWorkListFormViewModel {

    @Type(() => SurgeryWorkListItem)
    WorkList: Array<SurgeryWorkListItem> = new Array<SurgeryWorkListItem>();
    _SearchCriteria: SurgeryWorkListSearchCriteria = new SurgeryWorkListSearchCriteria();
    // _SearchCriteria  dx-tag-box 'ý doldurmak için
    @Type(() => ResSection)
    ResourceList: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResSection)
    SurgeryDepartmentList: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResSection)
    SurgeryRoomList: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResSection)
    SurgeryDeskList: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResUser)
    InpatientDoctorList: Array<ResUser> = new Array<ResUser>();
    @Type(() => ResUser)
    SurgeryDoctorList: Array<ResUser> = new Array<ResUser>();
    @Type(() => ResUser)
    AnesthesiaDoctorList: Array<ResUser> = new Array<ResUser>();
    @Type(() => SurgeryDefinition)
    SurgeryProcedureList: Array<SurgeryDefinition> = new Array<SurgeryDefinition>();
    @Type(() => ProvizyonTipi)
    AdmissionTypeList: Array<ProvizyonTipi> = new Array<ProvizyonTipi>();

    @Type(() => SurgeryStatusDefinition)
    public SurgeryStatusDefinitionList: Array<SurgeryStatusDefinition> = new Array<SurgeryStatusDefinition>();

    @Type(() => SelectedSurgeryStatusItem)
    public SelectedSurgeryStatusItem: SelectedSurgeryStatusItem;
}
export class SelectedSurgeryStatusItem {
    @Type(() => Guid)
    public SurgeryObjectIdList: Array<Guid> = new Array<Guid>();

    public SurgeryObjectDefName: string;

    @Type(() => SurgeryStatusDefinition)
    public SelectedSurgeryStatusDefinition: SurgeryStatusDefinition;
}



export class SurgeryWorkListSearchCriteria extends BaseEpisodeActionWorkListSearchCriteria {

    public Surgery_EA: boolean;
    public AnesthesiaAndReanimation_EA: boolean;
    public Request: boolean;
    public Surgery: boolean;
    public Postponed: boolean;
    public Completed: boolean;
    public Waiting: boolean;
    public Continue: boolean;
    public Reanimation: boolean;
    public AnesthesiaCompleted: boolean;
    public Rejected: boolean;
    public OnlyOwnPatient: boolean;
    public SEProtocolNo: string;
    public PatientNo: string;
    public selectedSurgeryProcedures: any = [];
    public selectedSurgeryProceduresStr: string;
    @Type(() => Date)
    public AdmissionStartDate: Date;
    @Type(() => Date)
    public AdmissionEndDate: Date;
    @Type(() => ResSection)
    public Resources: Array<ResSection>;
    @Type(() => ResSection)
    public SurgeryDepartments: Array<ResSection>
    @Type(() => ResSection)
    public SurgeryRooms: Array<ResSection>
    @Type(() => ResSection)
    public SurgeryDesks: Array<ResSection>
    @Type(() => ResUser)
    public InpatientDoctors: Array<ResUser>
    @Type(() => ResUser)
    public SurgeryDoctors: Array<ResUser>
    @Type(() => ResUser)
    public AnesthesiaDoctors: Array<ResUser>
    @Type(() => SurgeryDefinition)
    public SurgeryProcedures: Array<SurgeryDefinition>
    @Type(() => ProvizyonTipi)
    public AdmissionTypes: Array<ProvizyonTipi>
}

//export class SurgeryProcedureCarrier

export class SurgeryWorkListItem extends BaseEpisodeActionWorkListItem {

    public HasTightContactIsolation: boolean;
    public HasFallingRisk: boolean;
    public HasDropletIsolation: boolean;
    public HasAirborneContactIsolation: boolean;
    public HasContactIsolation: boolean;
    @Type(() => Date)
    public Date: Date;
    @Type(() => Date)
    public SurgeryStartTime: Date;
    @Type(() => Date)
    public SurgeryEndTime: Date;
    public PatientNameSurname: string;
    public EpisodeActionName: string;
    public StateName: string;
    public StatusName: string;
    public SurgeryDepartment: string;
    public SurgeryRoom: string;
    public SurgeryDesk: string;
    public SurgeryDoctorName: string;
    public AnesthesiaDoctorName: string;
    public InpatientClinic: string;
    public InpatientDoctorName: string;
    public SurgeryNote: string;
    public SurgeryResult: string;
    public UniqueRefno: string;
    public KabulNo: string;
    public AdmissionType: string;
    public PayerName: string;
    @Type(() => Date)
    public BirthDate: Date;
    public FatherName: string;
    public TelNo: string;
    public HastaTuru: string;
    public BasvuruTuru: string;
    public OncelikDurumu: string;
    public Diagnosis: string;
}


