import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';

import { ResSection, ResUser, ProcedureDefinition, Material } from 'app/NebulaClient/Model/AtlasClientModel';
import Store from 'devextreme/data/abstract_store';

export class SurgeryAppointmentComponentFormViewModel {
    @Type(() => SurgeryAppointmentListSearchCriteria)
    _SearchCriteria: SurgeryAppointmentListSearchCriteria = new SurgeryAppointmentListSearchCriteria();
    @Type(() => ResSection)
    SurgeryDepartmentList: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResSection)
    SurgeryRoomList: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResSection)
    ResourceList: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResUser)
    DoctorList: Array<ResUser> = new Array<ResUser>();
}

export class SurgeryAppointmentListItem {
    public AppointmentObjectId: Guid;
    public ObjectDefName: string;
    public ProtocolNo: string;
    public PatientName: string;
    public Clinic: string;
    public SurgeryDepartment: string;
    public SurgeryRoom: string;
    public SurgeryProcedure: string;
    public AppointmentDate: Date;
    public AppointmentDoctor: string;
    public Status: string;
    public isApprovedByDoctor: boolean;
    public isApprovedByHeadDoctor: boolean;
    public isApproveCompleted: boolean;
    public isCompleted: boolean;
    public isCancelled: boolean;
    @Type(() => SurgeryAppointmentMaterial)
    public SurgeryMaterials: Array<SurgeryAppointmentMaterial>; 
    @Type(() => MasterView)
    public MasterData: Array<MasterView>; 

}

export class SurgeryAppointmentListSearchCriteria {

    @Type(() => Date)
    public AppointmentStartDate: Date;
    @Type(() => Date)
    public AppointmentEndDate: Date;
    @Type(() => ResSection)
    public SurgeryDepartments: Array<ResSection>;
    @Type(() => ResSection)
    public SurgeryRooms: ResSection;
    public SubEpisodeProtocolNo: string;
    @Type(() => Guid)
    public PatientId: Guid;
    @Type(() => ResSection)
    public Resources: Array<ResSection>;
    @Type(() => ResUser)
    public Doctors: ResUser;
    public isCalledByAppointmentForm: boolean = false;
    public searchForAppointmentCount: boolean = false;
}

export class SurgeryAppointmentMaterial {

    @Type(() => ProcedureDefinition)
    public Procedure: ProcedureDefinition;
    @Type(() => Material)
    public Material: Material;
    @Type(() => Store)
    public Store: Store;
    public Amount: number;
}

export class MasterView
{
    @Type(() => ProcedureDefinition)
    public Procedure: ProcedureDefinition;
    @Type(() => DetailView)
    public Details: Array<DetailView>;
}

export class DetailView
{
    public MaterialName: string;
    public StoreName: string;
    public Amount: number;
}