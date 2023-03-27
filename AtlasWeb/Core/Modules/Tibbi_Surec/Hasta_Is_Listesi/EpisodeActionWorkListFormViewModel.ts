import { BaseModel } from 'Fw/Models/BaseModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ResSection, LCDNotificationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class EpisodeActionWorkListFormViewModel extends BaseModel {

    EpisodeActionList: Array<EpisodeActionWorkListItemModel> = new Array<EpisodeActionWorkListItemModel>();
    txtPatient: string;
    @Type(() => Date)
    StartDate: Date;
    @Type(() => Date)
    EndDate: Date;
    ID: number;
    WorkListCount: number;
    StateType: string;
    PatientStatus: string;
    TriageCode: string;
    @Type(() => EpisodeActionWorkListItem)
    EpisodeActionWorkListItems: Array<EpisodeActionWorkListItem>;
    @Type(() => EpisodeActionWorkListStateItem)
    EpisodeActionWorkListStateItems: Array<EpisodeActionWorkListStateItem>;
    @Type(() => EpisodeActionWorkListStateItem)
    EpisodeActionWorkListStateItemsAll: Array<EpisodeActionWorkListStateItem>;
    @Type(() => EpisodeActionWorkListItem)
    SelectedEpisodeActionWorkListItems: Array<EpisodeActionWorkListItem>;
    @Type(() => EpisodeActionWorkListStateItem)
    SelectedEpisodeActionWorkListStateItems: Array<EpisodeActionWorkListStateItem>;
    @Type(() => UserResourceItem)
    UserResourceItems: Array<UserResourceItem>;
    @Type(() => UserResourceItem)
    SelectedUserResourceItems: Array<UserResourceItem>;
    private _specialPanelListItems: Array<SpecialPanelListItem>;
      public get SpecialPanelListItems(): Array<SpecialPanelListItem>{
        return this._specialPanelListItems;
    }
    public set SpecialPanelListItems(value: Array<SpecialPanelListItem>) {
        this._specialPanelListItems = value;
    }
    @Type(() => SpecialPanelListItem)
    LastSelectedSpecialPanel: SpecialPanelListItem;
    LastSelectedSpecialPanelCaption: string;
    PriorityIcon: string;
    SelectedStateTypes: Array<string>;
    SelectedStateTypesEM: Array<string>;
    WorkListMaxDayToSearch: number;
    maxWorklistItemCount: number;
    timerPeriod: number;
    autoRefreshWorkList: boolean;

    public PatientCallStatus: string;
    public TriageColor: string;
    @Type(() => LCDNotificationDefinition)
    LCDNotificationList: Array<LCDNotificationDefinition> = new Array<LCDNotificationDefinition>();
    @Type(() => LCDNotificationDefinition)
    LCDNotification: LCDNotificationDefinition;
    isNewLcd: string;


}

export class EpisodeActionWorkListItemModel {

    public ObjectID: string;
    public ObjectDefName: string;
    public PatientIdentityNumber: string;
    public PatientNameSurname: string;
    public ID: number;
    public AdmissionQueueNumber: string;
    public EpisodeActionName: string;
    @Type(() => Date)
    public TransactionDate: Date;
    public StateName: string;
    @Type(() => Boolean)
    public isPregnant: boolean;
    @Type(() => Boolean)
    public isEmergency: boolean;
    @Type(() => Boolean)
    public isYoung: boolean;
    @Type(() => Boolean)
    public isOld: boolean;
    @Type(() => Boolean)
    public isVetera: boolean;
    @Type(() => Boolean)
    public isDisabled: boolean;
    @Type(() => Boolean)
    public hasMedicalInformation: boolean;
    public AdmissionResourceName: string;
    public RequestDateStr: Date;
    @Type(() => Guid)
    public EpisodeObjectID: Guid;
    // Yatan hasta i�in
    public HasTightContactIsolation: boolean;
    public HasFallingRisk: boolean;
    public HasDropletIsolation: boolean;
    public HasAirborneContactIsolation: boolean;
    public HasContactIsolation: boolean;
    public RowColor: string;
    public AdmissionDoctorName: string;
    public ResponsibleNurseName: string;

    public CurrentStateDefID: string;
    public ReasonOfCancel: string; 
    //public priorityStatusList: Array<PriorityStatusDefinition>;
    //public StateFormName: string;
    public isEmergencyManipulationRequest: boolean;

}


export class EpisodeActionWorkListSharedItemModel {

    public ObjectID: string;
    public ObjectDefName: string;
    public FormDefID: string;
    public InputParam: any;

}

export class QueryInputDVO {
    public txtPatient: string;
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
    public StateType: string;
    public PatientStatus: string;
    public TriageCode: string;
    public ID: number;
    public WorkListCount: number;
    @Type(() => EpisodeActionWorkListItem)
    public SelectedWorkListItems: Array<EpisodeActionWorkListItem>;
    @Type(() => EpisodeActionWorkListStateItem)
    public SelectedWorkListStateItems: Array<EpisodeActionWorkListStateItem>;
    @Type(() => EpisodeActionWorkListItem)
    public WorkListItems: Array<EpisodeActionWorkListItem>;
    @Type(() => EpisodeActionWorkListStateItem)
    public WorkListStateItems: Array<EpisodeActionWorkListStateItem>;
    @Type(() => UserResourceItem)
    public UserResourceItems: Array<UserResourceItem>;
    @Type(() => UserResourceItem)
    public SelectedUserResourceItems: Array<UserResourceItem>;
    public activeResUserObjectID: string;
    @Type(() => ResSection)
    public userSelectedOutPatientResource: ResSection;
    @Type(() => ResSection)
    public userSelectedInPatientResource: ResSection;
    @Type(() => ResSection)
    public userSelectedSecMasterResource: ResSection;
    public SelectedStateTypes: Array<string>;
    public SelectedStateTypesEM: Array<string>;
    public SEProtocolNo: string;
    //public LastSelectedSpecialPanel: SpecialPanelListItem;
}

export class MenuOutputDVO {
    @Type(() => EpisodeActionWorkListItem)
    public WorkListSearchItem: Array<EpisodeActionWorkListItem>;
    @Type(() => EpisodeActionWorkListStateItem)
    public WorkListSearchStateItem: Array<EpisodeActionWorkListStateItem>;
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
public WorkListMaxDayToSearch: number;
}

export class StateOutputDVO {
    @Type(() => EpisodeActionWorkListStateItem)
    public WorkListSearchStateItem: Array<EpisodeActionWorkListStateItem>;
}

export class LCDNotificationOutputDVO {
    @Type(() => LCDNotificationDefinition)
    public LCDNotificationList: Array<LCDNotificationDefinition>;
    isNewLcd: string;
}

export class UserResourceOutputDVO {
    @Type(() => UserResourceItem)
    public WorkListSearchUserResourceItem: Array<UserResourceItem>;
    @Type(() => UserResourceItem)
    public SelectedWorkListSearchUserResourceItem: Array<UserResourceItem>;
}

export class EpisodeActionWorkListItem {
    public ObjectDefName: string;
    public ObjectDefID: string;
}

export class EpisodeActionWorkListStateItem {
    public StateDefName: string;
    public StateDefID: string;
}

export class UserResourceItem {
    public ResourceName: string;
    public ResourceID: string;
}

export class DynamicComponentInfoDVO {
    public ComponentName: string;
    public ModuleName: string;
    public ModulePath: string;
    public objectID: string;
    @Type(() => Guid)
    public episodeObjectID: Guid;
    @Type(() => Guid)
    public patientObjectID: Guid;

}

export class SpecialPanelListItem {
    public Name: string;
    public Caption: string;
    public ObjectID: string;
    public User: string;
    @Type(() => SpecialPanelCriteriaVal)
    public SpecialPanelCriteriaValues: Array<SpecialPanelCriteriaVal>;
}

export class SpecialPanelCriteriaVal {
    public Name: string;
    public ObjectID: string;
    public Value: string;
}
export class SpecialPanelOutputDVO {
    @Type(() => SpecialPanelListItem)
    public SpecialPanelList: Array<SpecialPanelListItem>;
    @Type(() => SpecialPanelListItem)
    public LastSelectedSpecialPanel: SpecialPanelListItem;
}
export class SpecialPanelInputDVO {
    @Type(() => EpisodeActionWorkListItem)
    public SelectedWorkListItems: Array<EpisodeActionWorkListItem>;
    @Type(() => EpisodeActionWorkListStateItem)
    public SelectedWorkListStateItems: Array<EpisodeActionWorkListStateItem>;
    @Type(() => SpecialPanelListItem)
    public SpecialPanelListItems: Array<SpecialPanelListItem>;
    @Type(() => SpecialPanelListItem)
    public LastSelectedSpecialPanel: SpecialPanelListItem;
    public isNew: boolean;
    public SpecialPanelListItemCaption: string;
    public activeResUserObjectID: string;
}

export class ActiveInfoDVO {
    @Type(() => Guid)
    public EpisodeActionObjectID: Guid;
    @Type(() => Guid)
    public EpisodeObjectID: Guid;
    @Type(() => Guid)
    public PatientObjectID: Guid;
}