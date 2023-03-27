import { BaseModel } from 'Fw/Models/BaseModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';

export class NuclearWorkListFormViewModel extends BaseModel {

    @Type(() => NuclearWorkListItemModel)
    NuclearList: Array<NuclearWorkListItemModel> = new Array<NuclearWorkListItemModel>();
    txtPatient: string;
    @Type(() => Date)
    StartDate: Date;
    @Type(() => Date)
    EndDate: Date;
    ID: string;
    @Type(() => Number)
    WorkListCount: number;
    StateType: string;
    PatientStatus: string;
    @Type(() => NuclearWorkListItem)
    NuclearWorkListItems: Array<NuclearWorkListItem>;
    @Type(() => NuclearWorkListStateItem)
    NuclearWorkListStateItems: Array<NuclearWorkListStateItem>;
    @Type(() => NuclearWorkListStateItem)
    NuclearWorkListStateItemsAll: Array<NuclearWorkListStateItem>;
    @Type(() => NuclearWorkListItem)
    SelectedNuclearWorkListItems: Array<NuclearWorkListItem>;
    @Type(() => NuclearWorkListStateItem)
    SelectedNuclearWorkListStateItems: Array<NuclearWorkListStateItem>;
    @Type(() => UserResourceItem)
    UserResourceItems: Array<UserResourceItem>;
    @Type(() => UserResourceItem)
    SelectedUserResourceItems: Array<UserResourceItem>;
    @Type(() => EquipmentItem)
    NuclearEquipmentItems: Array<EquipmentItem>;
    @Type(() => EquipmentItem)
    SelectedNuclearEquipmentItems: Array<EquipmentItem>;
    @Type(() => SpecialPanelListItem)
    private _specialPanelListItems: Array<SpecialPanelListItem>;
    @Type(() => SpecialPanelListItem)
    public get SpecialPanelListItems(): Array<SpecialPanelListItem> {
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
}

export class NuclearWorkListItemModel {

    public ObjectID: string;
    public ObjectDefName: string;
    public PatientNameSurname: string;
    public ID: string;
    public AdmissionQueueNumber: string;
    public EpisodeActionObjectID: string;
    public EpisodeActionName: string;
    public NuclearTestName: string;
    public FromResourceName: string;
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
    public hasMedicalInformation: boolean ;
    @Type(() => Boolean)
    public isRadTestEmergency: boolean;
    public ActionDate: string;
    public RowColor: string;
    //public priorityStatusList: Array<PriorityStatusDefinition>;
    //public StateFormName: string;
}

export class QueryInputDVO {
    public txtPatient: string;
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
    public StateType: string;
    public PatientStatus: string;
    public ID: string;
    @Type(() => Number)
    public WorkListCount: number;
    @Type(() => NuclearWorkListItem)
    public SelectedWorkListItems: Array<NuclearWorkListItem>;
    @Type(() => NuclearWorkListStateItem)
    public SelectedWorkListStateItems: Array<NuclearWorkListStateItem>;
    @Type(() => NuclearWorkListItem)
    public WorkListItems: Array<NuclearWorkListItem>;
    @Type(() => NuclearWorkListStateItem)
    public WorkListStateItems: Array<NuclearWorkListStateItem>;
    @Type(() => UserResourceItem)
    UserResourceItems: Array<UserResourceItem>;
    @Type(() => UserResourceItem)
    SelectedUserResourceItems: Array<UserResourceItem>;
    @Type(() => EquipmentItem)
    NuclearEquipmentItems: Array<EquipmentItem>;
    @Type(() => EquipmentItem)
    SelectedNuclearEquipmentItems: Array<EquipmentItem>;
    public activeResUserObjectID: string;
    public userSelectedOutPatientResource: ResSection;
    public userSelectedInPatientResource: ResSection;
    public userSelectedSecMasterResource: ResSection;
    public SelectedStateTypes: Array<string>;
    public SelectedStateTypesEM: Array<string>;
    public SelectedQueueObjectID: string;
    //public LastSelectedSpecialPanel: SpecialPanelListItem;
}

export class MenuOutputDVO {
    @Type(() => NuclearWorkListItem)
    public WorkListSearchItem: Array<NuclearWorkListItem>;
    @Type(() => NuclearWorkListStateItem)
    public WorkListSearchStateItem: Array<NuclearWorkListStateItem>;
}

export class StateOutputDVO {
    @Type(() => NuclearWorkListStateItem)
    public WorkListSearchStateItem: Array<NuclearWorkListStateItem>;
}

export class UserResourceOutputDVO {
    public WorkListSearchUserResourceItem: Array<UserResourceItem>;
    public SelectedWorkListSearchUserResourceItem: Array<UserResourceItem>;
}
export class NuclearWorkListItem {
    public ObjectDefName: string;
    public ObjectDefID: string;
}

export class NuclearWorkListStateItem {
    public StateDefName: string;
    public StateDefID: string;
}

export class UserResourceItem {
    public ResourceName: string;
    public ResourceID: string;
}

export class EquipmentItem {
    public EquipmentName: string;
    public EquipmentResourceID: string;
}

export class DynamicComponentInfoDVO {
    public ComponentName: string;
    public ModuleName: string;
    public ModulePath: string;
    public objectID: string;
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
    @Type(() => NuclearWorkListItem)
    public SelectedWorkListItems: Array<NuclearWorkListItem>;
    @Type(() => NuclearWorkListStateItem)
    public SelectedWorkListStateItems: Array<NuclearWorkListStateItem>;
    @Type(() => SpecialPanelListItem)
    public SpecialPanelListItems: Array<SpecialPanelListItem>;
    @Type(() => SpecialPanelListItem)
    public LastSelectedSpecialPanel: SpecialPanelListItem;
    @Type(() => Boolean)
    public isNew: boolean;
    public SpecialPanelListItemCaption: string;
    public activeResUserObjectID: string;
}

export class ActiveInfoDVO {
    public EpisodeActionObjectID: Guid;
    public EpisodeObjectID: Guid;
    public PatientObjectID: Guid;
}

export class NuclearEquipmentOutputDVO {
    public EquipmentItemList: Array<EquipmentItem>;
}