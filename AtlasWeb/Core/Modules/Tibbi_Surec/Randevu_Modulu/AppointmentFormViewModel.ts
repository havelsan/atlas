//$6FD87177
import { Appointment, SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SubActionProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { BaseModel } from 'Fw/Models/BaseModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { AppointmentDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { AppointmentCarrier } from 'NebulaClient/Model/AtlasClientModel';
import { AppointmentType } from 'NebulaClient/Model/AtlasClientModel';
import { AppointmentTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PhoneTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Resource } from 'NebulaClient/Model/AtlasClientModel';
import { TTObject } from 'NebulaClient/StorageManager/InstanceManagement/TTObject';
import { PlannedAction } from 'NebulaClient/Model/AtlasClientModel';
import { IAppointmentDef } from 'app/Interfaces/IAppointmentDef';
import { ISplitBySubActionProcedureAppointment } from 'app/Interfaces/ISplitBySubActionProcedureAppointment';
import { IAdmissionAppointmentDef } from 'app/Interfaces/IAdmissionAppointmentDef';
import { IPlanPlannedAction } from 'app/Interfaces/IPlanPlannedAction';
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

export class AppointmentFormViewModel extends BaseModel {
    @Type(() => Appointment)
    public _Appointment: Appointment = new Appointment();
    public txtPatient: string;
    @Type(() => Patient)
    public currentPatient: Patient = new Patient();
    //@Type(() => Number)
    public TCKNo: number;
    public PhoneNumber: string;
    public Note: string;
    @Type(() => AppointmentDefinition)
    public AppointmentDefinitionList: Array<AppointmentDefinition> = new Array<AppointmentDefinition>();
    @Type(() => AppointmentCarrier)
    public AppointmentCarrierList: Array<AppointmentCarrier> = new Array<AppointmentCarrier>();
    @Type(() => AppointmentTypeListDVO)
    public AppointmentTypeList: Array<AppointmentTypeListDVO> = new Array<AppointmentTypeListDVO>();
    @Type(() => IAppointmentDef)
    public AppointmentDef: IAppointmentDef;
    @Type(() => Resource)
    public MasterResourceList: Array<Resource> = new Array<Resource>();
    @Type(() => Resource)
    public SubResourceList: Array<Resource> = new Array<Resource>();
    //TODO : Ameliyat ve yatak randevusu i�in kullan�labilir
    public SelectedMasterResourceList: Array<string>; // = new Array<string>();
    public SelectedSubResourceList: Array<string>; //= new Array<string>();
    @Type(() => AppointmentTypeListDVO)
    public AppointmentType: AppointmentTypeListDVO;
    @Type(() => TTObject)
    public CurrentObject: TTObject;
    @Type(() => TTObject)
    public StarterObject: TTObject;
    @Type(() => Guid)
    public CurrentObjectTransDefID: Guid;
    @Type(() => Boolean)
    public isAdmissionAppointment: boolean;
    public osPhoneType: PhoneTypeEnum;
    @Type(() => GivenAppointment)
    public selectedAppointmentSchedule: GivenAppointment;
    @Type(() => GivenAppointment)
    public _myOldAppointment: GivenAppointment;
    @Type(() => ResourceAndColorDVO)
    public AllResourcesAndColors: Array<ResourceAndColorDVO> = new Array<ResourceAndColorDVO>();
    public MasterResourceCaption: string = i18n("M20431", "Poliklinik");
    public SubResourceCaption: string = "Doktor";
    @Type(() => Boolean)
    public showBreakAppButton: boolean = false;
    @Type(() => Boolean)
    public showFirstAvailableButton: boolean = false;
    @Type(() => Boolean)
    public labelSubResourceVisible: boolean = true;
    @Type(() => Boolean)
    public subResourceVisible: boolean = true;
    @Type(() => AppointmentToUpdateDVO)
    public appointmentToUpdateDVO: AppointmentToUpdateDVO;
    @Type(() => Boolean)
    public appCarrierDisabled: boolean = false;
    @Type(() => ISplitBySubActionProcedureAppointment)
    public _splitBySubActionProcedureAppointmentDef: ISplitBySubActionProcedureAppointment;
    @Type(() => Boolean)
    public appDefDisabled: boolean = false;
    @Type(() => Boolean)
    public appMasterResourceDisabled: boolean = false;
    @Type(() => Boolean)
    public txtPatientDisabled: boolean = false;
    @Type(() => IAdmissionAppointmentDef)
    public _admissionAppointmentDef: IAdmissionAppointmentDef;
    @Type(() => IAppointmentDef)
    public _appointmentDef: IAppointmentDef;
    @Type(() => PlannedAction)
    public plannedActions: Array<PlannedAction> = new Array<PlannedAction>();
    @Type(() => SubActionProcedure)
    public subActionProcedures: Array<SubActionProcedure> = new Array<SubActionProcedure>();
    @Type(() => IPlanPlannedAction)
    public _plannedAppointmentDef: IPlanPlannedAction;
    @Type(() => Boolean)
    public TCKNoDisabled: boolean = false;
    @Type(() => Boolean)
    public allowAdding: boolean = true;
    @Type(() => Boolean)
    public allowDeleting: boolean = true;
    @Type(() => Boolean)
    public allowDragging: boolean = true;
    @Type(() => Boolean)
    public allowUpdating: boolean = true;
    @Type(() => Boolean)
    public recurrenceVisible: boolean;
    @Type(() => TTObject)
    public objectsList: Array<TTObject> = new Array<TTObject>();
    @Type(() => Boolean)
    public objectsVisible: boolean = false;
    @Type(() => Boolean)
    public lblPlannedActionsVisible: boolean = false;
    @Type(() => Boolean)
    public chkGroupPlanVisible: boolean = false;
    @Type(() => Date)
    public appListStartDate: Date;
    @Type(() => Date)
    public appListEndDate: Date;
    //public AppointmentListItems: Array<AppointmentListItem> = new Array<AppointmentListItem>();
    @Type(() => Boolean)
    public filterAppListByAppDef: boolean = true;
    //public criteria: string;
    //public appListAppointmentType: AppointmentTypeEnum;
    @Type(() => GivenAppointment)
    public selectedAppointmentListItem: GivenAppointment = null;
    @Type(() => Boolean)
    public isAppointmentListForm: boolean = false;
    @Type(() => Boolean)
    public patientSearchFormVisible: boolean = true;


    @Type('AppointmentDefinition')
    public AppointmentDefinitionToList: AppointmentDefinition;
    @Type('AppointmentCarrier')
    public AppointmentCarrierToList: AppointmentCarrier;
    @Type('Patient')
    public PatientToList: Patient;
    @Type('Resource')
    public ResourceToList: Resource;
    @Type('Resource')
    public MasterResourceToList: Resource;
    public txtPatientToList: string;
    @Type(() => AppointmentTypeListDVO)
    public AppointmentTypeToList: AppointmentTypeListDVO;
    @Type(() => AppointmentStateItem)
    AppointmentStateItems: Array<AppointmentStateItem>;
    @Type(() => AppointmentStateItem)
    SelectedAppointmentStateItems: Array<AppointmentStateItem> = new Array<AppointmentStateItem>();
}

export class AppointmentStateItem {
    public StateDefName: string;
    public StateDefID: string;
}

export class ResourceAndColorDVO {
    public resourceObjectID: string;
    public resourceColor: string;
}

export class AppointmentToSaveDVO {
    @Type(() => Appointment)
    public appointmentToSave: Appointment;
    public txtPatient: string;
    //@Type(() => Number)
    public TCKNo: number;
    public PhoneNumber: string;
    public osPhoneType: PhoneTypeEnum;
    @Type(() => TTObject)
    public CurrentObject: TTObject;
    @Type(() => GivenAppointment)
    public selectedCalendarItems: Array<GivenAppointment> = new Array<GivenAppointment>();
    @Type(() => GivenAppointment)
    public _myOldAppointment: GivenAppointment;
    @Type(() => Number)
    public nextAvailableAppointmentOrder: number;
    @Type(() => Appointment)
    public _retAppointment: Appointment;
    @Type(() => AppointmentCarrier)
    public _carrierList: Array<AppointmentCarrier> = new Array<AppointmentCarrier>();
    @Type(() => Boolean)
    public isBreak: boolean;
    @Type(() => IAppointmentDef)
    public AppointmentDef: IAppointmentDef;
}

export class AppointmentCarrierDVO {
    @Type(() => AppointmentCarrier)
    public defaultCarrier: AppointmentCarrier;
    @Type(() => AppointmentCarrier)
    public AppointmentCarrierList: Array<AppointmentCarrier>;
}
export class AppointmentTypeDVO {
    @Type(() => AppointmentTypeListDVO)
    public defaultAppType: AppointmentTypeListDVO;
    @Type(() => AppointmentTypeListDVO)
    public AppointmentTypeList: Array<AppointmentTypeListDVO>;
}

export class AppointmentTypeListDVO {
    @Type(() => Number)
    public id: number;
    public text: string;
    public AppointmentTypeDisplayText: string;
    public AppointmentTypeEnumValue: AppointmentTypeEnum;
    @Type(() => AppointmentType)
    public AppointmentType: AppointmentType;
}

export class MasterResourceInputDVO  {
    public masterResourceType: string;
    public subResourceType: string;
    public masterResourceFilter: string;
    public relationParentName: string;
    public appointmentDefObjectID: string;
    public appointmentCarrierObjectID: string;
    public currentPlannedActionMasterResourceID: string;
    @Type(() => Boolean)
    public currentObjectIsPlannedAction: boolean;
    @Type(() => Boolean)
    public isAppointmentListForm: boolean;
    public defaultMasterResourceObjectID: string;
    public defaultSubResourceObjectID: string;
    @Type(() => Boolean)
    public isKioskAppointment: boolean = false;
    public defaultSpecialityObjectID: string;
}
export class MasterResourceDVO {
    @Type(() => Resource)
    public defaultMasterResource: Resource;
    @Type(() => Resource)
    public MasterResourceList: Array<Resource>;
    @Type(() => SpecialityDefinition)
    public SpecialityList: Array<SpecialityDefinition>;
}

export class SubResourceInputDVO  {
    public subResourceType: string;
    public appointmentDefObjectID: string;
    public appointmentCarrierObjectID: string;
    public relationParentName: string;
    public defaultMasterResourceObjectID: string;
    @Type(() => Boolean)
    public isAppointmentListForm: boolean;
    public defaultSubResourceObjectID: string;
    public isKioskAppointment: boolean = false;
}

export class SubResourceDVO {
    @Type(() => Resource)
    public defaultSubResource: Resource;
    @Type(() => Resource)
    public SubResourceList: Array<Resource>;
}

export class AppointmentInputDVO {
    public ownerObjectID: string;
    public masterOwnerObjectID: string;
    public SelectedOwnerResources: Array<string> = new Array<string>();
    @Type(() => ResourceAndColorDVO)
    public AllResourcesAndColors: Array<ResourceAndColorDVO> = new Array<ResourceAndColorDVO>();
    @Type(() => Date)
    AppDate: Date;
    public appointmentType: AppointmentTypeEnum;
    //TODO Hastan�n t�m randevular�n� g�stermek i�in kullan�labilir.(sonra)
    @Type(() => Boolean)
    public showAppointmentsOfPatient: boolean;
    public currentView: string;
}

export class AppointmentToUpdateDVO {

    @Type(() => TTObject)
    public objectList: Array<TTObject> = new Array<TTObject>();
    @Type(() => Boolean)
    public appCarrierDisabled: boolean;
    @Type(() => ISplitBySubActionProcedureAppointment)
    public _splitBySubActionProcedureAppointmentDef: ISplitBySubActionProcedureAppointment;
    @Type(() => Boolean)
    public appDefDisabled: boolean;
    @Type(() => Boolean)
    public appMasterResourceDisabled: boolean;
    @Type(() => Boolean)
    public txtPatientDisabled: boolean;
    @Type(() => IAdmissionAppointmentDef)
    public _admissionAppointmentDef: IAdmissionAppointmentDef;
    @Type(() => IAppointmentDef)
    public _appointmentDef: IAppointmentDef;
    @Type(() => PlannedAction)
    public plannedActions: Array<PlannedAction>;
    @Type(() => SubActionProcedure)
    public subActionProcedures: Array<SubActionProcedure>;
    @Type(() => IPlanPlannedAction)
    public _plannedAppointmentDef: IPlanPlannedAction;
    @Type(() => Boolean)
    public TCKNoDisabled: boolean;
    @Type(() => TTObject)
    public CurrentObject: TTObject;
}

export class GivenAppointmentsAndSchedules {
    @Type(() => GivenAppointment)
    public GivenAppointments: Array<GivenAppointment>;
    @Type(() => GivenResource)
    public SubResources: Array<GivenResource>;
    @Type(() => GivenResource)
    public MasterResources: Array<GivenResource>;
    @Type(() => AppOrSchType)
    public AppOrSchTypes: Array<AppOrSchType>;
}

export class GivenResource {
    text: string;
    id: string;
    color: string;
}

export class AppOrSchType {
    text: string;
    id: string;
}

export class GivenAppointment {
    @Type(() => Number)
    id: number;
    text: string;
    objectID: string;
    ownerObjectID: string;
    @Type(() => Resource)
    ownerObject: Resource;
    @Type(() => Patient)
    patient: Patient;
    txtPatient: string;
    //@Type(() => Number)
    TCKNo: number;
    PhoneNumber: string;
    osPhoneType: PhoneTypeEnum;
    masterOwnerObjectID: string;
    appointmentTypeEnum: AppointmentTypeEnum;
    objectDefID: string;
    objectDefName: string;
    @Type(() => Date)
    startDate: Date;
    @Type(() => Date)
    endDate: Date;
    recurrenceRule?: string;
    color: string;
    appOrSchTypeID: string;
    notes: string;
    @Type(() => Boolean)
    enabled: boolean;
    strAppDate: string;
    strAppTime: string;
    strType: string;
    appResources: string;
    appStatus: string;
    appCategory: string;
    rowColor: string;
    rowButtonType: number;
}

export class AppointmentListInputDVO {
    @Type('AppointmentDefinition')
    public appListAppointmentDefinition: AppointmentDefinition;
    @Type('AppointmentCarrier')
    public appListAppointmentCarrier: AppointmentCarrier;
    @Type('Resource')
    public appListMasterResource: Resource;
    @Type('Resource')
    public appListResource: Resource;
    @Type(() => Date)
    public appListStartDate: Date;
    @Type(() => Date)
    public appListEndDate: Date;
    @Type(() => GivenAppointment)
    public appointmentListItems: Array<GivenAppointment> = new Array<GivenAppointment>();
    @Type(() => Boolean)
    public filterAppListByAppDef: boolean = true;
    public criteria: string;
    @Type(() => AppointmentTypeListDVO)
    public appListAppointmentType: AppointmentTypeListDVO;
    public appointmentType: AppointmentTypeEnum;
    public MasterResourceCaption: string;
    public SubResourceCaption: string;
    @Type(() => Patient)
    public currentPatient: Patient;
    @Type(() => Resource)
    public MasterResourceList: Array<Resource> = new Array<Resource>();
    public SelectedOwnerResources: Array<string> = new Array<string>();
    @Type(() => AppointmentStateItem)
    SelectedAppointmentStateItems: Array<AppointmentStateItem> = new Array<AppointmentStateItem>();
}
export class AppointmentForUpdateDeleteApproveDVO
{
    appointmentObjectID: string ;
}

export class AppointmentListItem {
    @Type(() => Appointment)
    appointment: Appointment;
    strAppDate: string;
    strAppTime: string;
    strType: string;
    patientFullName: string;
    appResources: string;
    appStatus: string;
    appCategory: string;
    appNotes: string;
}