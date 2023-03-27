//$55A67336
import { Schedule, ScheduleJobRule, CetvelTipiEnum } from 'NebulaClient/Model/AtlasClientModel';
import { BaseModel } from 'Fw/Models/BaseModel';
import { AppointmentTypeListDVO, ResourceAndColorDVO, GivenResource } from './AppointmentFormViewModel';
import { AppointmentDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { AppointmentCarrier } from 'NebulaClient/Model/AtlasClientModel';
import { Resource } from 'NebulaClient/Model/AtlasClientModel';
import { MHRSActionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { AppointmentTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ScheduleAppointmentType } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class ScheduleFormViewModel extends BaseModel {
    @Type(() => Schedule)
    public _Schedule: Schedule = new Schedule();
    @Type(() => Boolean)
    public txtDurationDisabled: boolean;
    @Type(() => Number)
    public istisnasuresi: number;
    @Type(() => Boolean)
    public txtCountLimitDisabled: boolean;
    @Type(() => Boolean)
    public SentToMHRSVisible: boolean = false;
    @Type(() => Date)
    public SchDate: Date;
    @Type(() => Number)
    public timePeriod: number;
    @Type(() => Number)
    public Number: number;
    public Note: string;
    @Type(() => Boolean)
    public weeklyPlan: boolean = false;
    @Type(() => Boolean)
    public weekendIncluded: boolean = false;
    @Type(() => Date)
    public recurrenceStartDate: Date = new Date();
    @Type(() => Date)
    public recurrenceEndDate: Date = new Date();
    public RepeatNote: string;
    @Type(() => AppointmentCarrier)
    public AppointmentCarrier: AppointmentCarrier;
    @Type(() => ScheduleAppointmentType)
    public ScheduleAppointmentTypes: Array<ScheduleAppointmentType> = new Array<ScheduleAppointmentType>();
    @Type(() => MHRSActionTypeDefinition)
    public MHRSActionList: Array<MHRSActionTypeDefinition> = new Array<MHRSActionTypeDefinition>();
    public MHRSActionFilter: string;
    @Type(() => AppointmentDefinition)
    public AppointmentDefinitionList: Array<AppointmentDefinition> = new Array<AppointmentDefinition>();
    @Type(() => AppointmentCarrier)
    public AppointmentCarrierList: Array<AppointmentCarrier> = new Array<AppointmentCarrier>();
    @Type(() => AppointmentTypeListDVO)
    public AppointmentTypeList: Array<AppointmentTypeListDVO> = new Array<AppointmentTypeListDVO>();
    @Type(() => AppointmentTypeListDVO)
    public SelectedAppointmentTypeList: Array<AppointmentTypeListDVO> = new Array<AppointmentTypeListDVO>();
    @Type(() => Resource)
    public MasterResourceList: Array<Resource> = new Array<Resource>();
    @Type(() => Resource)
    public SubResourceList: Array<Resource> = new Array<Resource>();
    public SelectedMasterResourceList: Array<string>; // = new Array<string>();
    public SelectedSubResourceList: Array<string>; //= new Array<string>();
    @Type(() => AppointmentTypeListDVO)
    public AppointmentType: AppointmentTypeListDVO;
    @Type(() => GivenSchedule)
    public selectedSchedule: GivenSchedule;
    @Type(() => GivenSchedule)
    public _myOldSchedule: GivenSchedule;
    @Type(() => ResourceAndColorDVO)
    public AllResourcesAndColors: Array<ResourceAndColorDVO> = new Array<ResourceAndColorDVO>();
    public MasterResourceCaption: string = i18n("M20431", "Poliklinik");
    public SubResourceCaption: string = "Doktor";
    @Type(() => Boolean)
    public labelSubResourceVisible: boolean = true;
    @Type(() => Boolean)
    public subResourceVisible: boolean = true;
    @Type(() => ScheduleToUpdateDVO)
    public scheduleToUpdateDVO: ScheduleToUpdateDVO;
    @Type(() => Boolean)
    public appCarrierDisabled: boolean = false;
    @Type(() => Boolean)
    public appDefDisabled: boolean = false;
    @Type(() => Boolean)
    public appMasterResourceDisabled: boolean = false;
    @Type(() => Boolean)
    public allowAdding: boolean = true;
    @Type(() => Boolean)
    public allowDeleting: boolean = true;
    @Type(() => Boolean )
    public allowDragging: boolean = true;
    @Type(() => Boolean)
    public allowUpdating: boolean = true;
    @Type(() => Boolean)
    public recurrenceVisible: boolean;
    @Type(() => Boolean)
    public showScheduleJobRuleGrid: boolean;
    @Type(() => Boolean)
    public newMHRSParameter: boolean;
    public cetvelTipi:CetvelTipiEnum;

}

export class MHRSActionInputDVO {
    public MHRSActionFilter: string;
}
export class MHRSActionDVO {
    @Type(() => MHRSActionTypeDefinition)
    public defaultMHRSAction: MHRSActionTypeDefinition;
    @Type(() => MHRSActionTypeDefinition)
    public MHRSActionList: Array<MHRSActionTypeDefinition>;
}

export class ScheduleToSaveDVO {
    @Type(() => Schedule)
    public scheduleToSave: Schedule;
    @Type(() => GivenSchedule)
    public selectedCalendarItems: Array<GivenSchedule> = new Array<GivenSchedule>();
    @Type(() => GivenSchedule)
    public _myOldSchedule: GivenSchedule;
    @Type(() => Schedule)
    public _retSchedule: Schedule;
    @Type(() => AppointmentCarrier)
    public _carrierList: Array<AppointmentCarrier> = new Array<AppointmentCarrier>();
    @Type(() => AppointmentTypeListDVO)
    public SelectedAppointmentTypeList: Array<AppointmentTypeListDVO> = new Array<AppointmentTypeListDVO>();
    @Type(() => ScheduleJobRule)
    public ScheduleJobRules: Array<ScheduleJobRule> = new Array<ScheduleJobRule>();
}

export class CalismaPlaniGuncelleDVO
{
    @Type(() => ScheduleToSaveDVO)
    public scheduleToSaveDVO:ScheduleToSaveDVO = new ScheduleToSaveDVO();
    @Type(() => GivenSchedule)
    public givenSchedule:GivenSchedule = new GivenSchedule();
}

export class ScheduleToCopyDVO {
    @Type(() => Date)
    public ScheduleDate: Date;
    @Type(() => Date)
    public RecurrenceStartDate: Date;
    @Type(() => Date)
    public RecurrenceEndDate: Date;
    @Type(() => Boolean)
    public includeWeekend: boolean;
    @Type(() => Boolean)
    public weeklyPlan: boolean;
    public currentSubResourceObjectID: string;
    @Type(() => Boolean)
    public SentToMHRS: boolean;
}

export class ScheduleRecurrenceToDeleteDVO {
    @Type(() => Date)
    public RecurrenceStartDate: Date;
    @Type(() => Date)
    public RecurrenceEndDate: Date;
    public currentSubResourceObjectID: string;
    @Type(() => Boolean)
    public SentToMHRS: boolean;
}

export class ScheduleInputDVO {
    @Type(() => Resource)
    public res: Resource;
    @Type(() => Date)
    ScheduleDate: Date;
    @Type(() => Date)
    public StartTime: Date;
    @Type(() => Date)
    public EndTime: Date;
    @Type(() => Number)
    public timePeriod: number;
    @Type(() => Number)
    public Number: number;
    public Note: string;
    @Type(() => Boolean)
    public weeklyPlan: boolean;
    @Type(() => Boolean)
    public weekendIncluded: boolean;
    @Type(() => Date)
    public recurrenceStartDate: Date;
    @Type(() => Date)
    public recurrenceEndDate: Date;
    public RepeatNote: string;
    public ownerObjectID: string;
    public masterOwnerObjectID: string;
    public SelectedOwnerResources: Array<string> = new Array<string>();
    public SelectedMasterOwnerResources: Array<string> = new Array<string>();
    @Type(() => ResourceAndColorDVO)
    public AllResourcesAndColors: Array<ResourceAndColorDVO> = new Array<ResourceAndColorDVO>();
    public scheduleType: AppointmentTypeEnum;
    public currentView: string;
}

export class ScheduleToUpdateDVO {
    @Type(() => Boolean)
    public appCarrierDisabled: boolean;
    @Type(() => Boolean)
    public appDefDisabled: boolean;
    @Type(() => Boolean)
    public appMasterResourceDisabled: boolean;
}

export class GivenSchedules {
    @Type(() => GivenSchedule)
    public givenSchedules: Array<GivenSchedule>;
    @Type(() => GivenResource)
    public SubResources: Array<GivenResource>;
    @Type(() => GivenResource)
    public MasterResources: Array<GivenResource>;
}

export class GivenSchedule {
    @Type(() => Number)
    id: number;
    text: string;
    objectID: string;
    ownerObjectID: string;
    @Type(() => Resource)
    ownerObject: Resource;
    masterOwnerObjectID: string;
    @Type(() => Date)
    startDate: Date;
    @Type(() => Date)
    endDate: Date;
    recurrenceRule?: string;
    color: string;
    notes: string;
    @Type(() => Number)
    MHRSKesinCetvelID: number;
}

export class ScheduleToConfirmDVO {
    @Type(() => Date)
    public ScheduleDate: Date;
    public ResourceID: string;
    public MasterResourceID: string;
}



