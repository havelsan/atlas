//$C13F3C6C
import { BaseViewModel } from "../../../wwwroot/app/NebulaClient/Model/BaseViewModel";
import { EpisodeActionWorkListStateItem } from "../Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { SKRSDiyalizeGirmeSikligi, PackageProcedureDefinition, PeriodUnitTypeEnum, ResEquipment, HemodialysisOrder, Resource, PhoneTypeEnum, AppointmentTypeEnum, AppointmentDefinition, AppointmentCarrier, Patient, Appointment, AppointmentType, PlannedAction, SubActionProcedure, SKRSDiyalizTedavisiYontemi } from "../../../wwwroot/app/NebulaClient/Model/AtlasClientModel";
import { Guid } from "../../../wwwroot/app/NebulaClient/Mscorlib/Guid";
import { TTObject } from "../../../wwwroot/app/NebulaClient/StorageManager/InstanceManagement/TTObject";
import { IAppointmentDef } from "../../../wwwroot/app/Interfaces/IAppointmentDef";
import { ISplitBySubActionProcedureAppointment } from "../../../wwwroot/app/Interfaces/ISplitBySubActionProcedureAppointment";
import { IAdmissionAppointmentDef } from "../../../wwwroot/app/Interfaces/IAdmissionAppointmentDef";
import { IPlanPlannedAction } from "../../../wwwroot/app/Interfaces/IPlanPlannedAction";

export class HemodialysisAppointmentFormViewModel extends BaseViewModel {
    @Type(() => EpisodeActionWorkListStateItem)
    public HemodialysisStateItems: Array<EpisodeActionWorkListStateItem>;
    @Type(() => HemodialysisAppointmentItem)
    public HemodialysisAppointmentItemList: Array<HemodialysisAppointmentItem>;
    @Type(() => HemodialysisSearchCriteria)
    public _hemodialysisSearchCriteria: HemodialysisSearchCriteria;

    @Type(() => HemodialysisOrder)
    public _HemodialysisOrder: HemodialysisOrder;

    @Type(() => Appointment)
    public _Appointment: Appointment;

    //#region Takvim
    public SelectedSubResourceList: Array<string>;
    @Type(() => ResourceAndColorDVO)
    public AllResourcesAndColors: Array<ResourceAndColorDVO> = new Array<ResourceAndColorDVO>();
    @Type(() => Resource)
    public SubResourceList: Array<Resource> = new Array<Resource>();
    //#endregion

    public _GivenHemodialysisAppointmentDVO: GivenHemodialysisAppointmentDVO = new GivenHemodialysisAppointmentDVO();

    @Type(() => GivenAppointment)
    public selectedAppointmentSchedule: GivenAppointment;
    @Type(() => GivenAppointment)
    public _myOldAppointment: GivenAppointment;

    @Type(() => SKRSDiyalizeGirmeSikligi)
    public SKRSDiyalizeGirmeSikligiList: Array<SKRSDiyalizeGirmeSikligi> = new Array<SKRSDiyalizeGirmeSikligi>();

    @Type(() => PackageProcedureDefinition)
    public PackageProcedureList: Array<PackageProcedureDefinition> = new Array<PackageProcedureDefinition>();

    @Type(() => ResEquipment)
    public TreatmentEquipmentList: Array<ResEquipment> = new Array<ResEquipment>();
}
export class HemodialysisSearchCriteria {
    @Type(() => EpisodeActionWorkListStateItem)
    public HemodialysisState: Array<EpisodeActionWorkListStateItem>;
}
export class HemodialysisAppointmentItem {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Guid)
    public ObjectDefID: Guid;
    public ObjectDefName: string;
    public PatientNameSurname: string;
    public AdmissionNumber: string;
    public HemodialysisStateName: string;
    @Type(() => Date)
    public TreatmentStartDateTime: Date;
}

export class GivenHemodialysisAppointmentDVO {
    @Type(() => Guid)
    public hemodialysisOrderObjectId: Guid;

    @Type(() => Appointment)
    public _Appointment: Appointment;
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

export class MasterResourceInputDVO {
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
}
export class MasterResourceDVO {
    @Type(() => Resource)
    public defaultMasterResource: Resource;
    @Type(() => Resource)
    public MasterResourceList: Array<Resource>;
}

export class SubResourceInputDVO {
    public subResourceType: string;
    public appointmentDefObjectID: string;
    public appointmentCarrierObjectID: string;
    public relationParentName: string;
    public defaultMasterResourceObjectID: string;
    @Type(() => Boolean)
    public isAppointmentListForm: boolean;
    public defaultSubResourceObjectID: string;
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
export class AppointmentForUpdateDeleteApproveDVO {
    appointmentObjectID: string;
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