import { BaseModel } from 'Fw/Models/BaseModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';

export class RadiologyWorkListFormViewModel extends BaseModel {

    @Type(() => RadiologyWorkListItemModel)
    RadiologyList: Array<RadiologyWorkListItemModel> = new Array<RadiologyWorkListItemModel>();
    txtPatient: string;
    SEProtocolNo: string;
    @Type(() => Date)
    StartDate: Date;
    @Type(() => Date)
    EndDate: Date;
    ID: string;
    @Type(() => Number)
    WorkListCount: number;
    StateType: string;
    PatientStatus: string;
    @Type(() => RadiologyWorkListItem)
    RadiologyWorkListItems: Array<RadiologyWorkListItem>;
    @Type(() => RadiologyWorkListStateItem)
    RadiologyWorkListStateItems: Array<RadiologyWorkListStateItem>;
    @Type(() => RadiologyWorkListStateItem)
    RadiologyWorkListStateItemsAll: Array<RadiologyWorkListStateItem>;
    @Type(() => RadiologyWorkListItem)
    SelectedRadiologyWorkListItems: Array<RadiologyWorkListItem>;
    @Type(() => RadiologyWorkListStateItem)
    SelectedRadiologyWorkListStateItems: Array<RadiologyWorkListStateItem>;
    @Type(() => UserResourceItem)
    UserResourceItems: Array<UserResourceItem>;
    @Type(() => UserResourceItem)
    SelectedUserResourceItems: Array<UserResourceItem>;
    @Type(() => EquipmentItem)
    RadiologyEquipmentItems: Array<EquipmentItem>;
    @Type(() => EquipmentItem)
    SelectedRadiologyEquipmentItems: Array<EquipmentItem>;
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
    public RowColor: string;
}

export class RadiologyWorkListItemModel {

    public ObjectID: string;
    public ObjectDefName: string;
    public PatientNameSurname: string;
    public ID: string;
    public AdmissionQueueNumber: string;
    public EpisodeActionObjectID: string;
    public EpisodeActionName: string;
    public RadiologyTestName: string;
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
    @Type(() => Boolean)
    public Pandemic: boolean ;
    //public priorityStatusList: Array<PriorityStatusDefinition>;
    //public StateFormName: string;
}

export class QueryInputDVO {
    public txtPatient: string;
    public SEProtocolNo: string;
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
    public StateType: string;
    public PatientStatus: string;
    public ID: string;
    @Type(() => Number)
    public WorkListCount: number;
    @Type(() => RadiologyWorkListItem)
    public SelectedWorkListItems: Array<RadiologyWorkListItem>;
    @Type(() => RadiologyWorkListStateItem)
    public SelectedWorkListStateItems: Array<RadiologyWorkListStateItem>;
    @Type(() => RadiologyWorkListItem)
    public WorkListItems: Array<RadiologyWorkListItem>;
    @Type(() => RadiologyWorkListStateItem)
    public WorkListStateItems: Array<RadiologyWorkListStateItem>;
    @Type(() => UserResourceItem)
    UserResourceItems: Array<UserResourceItem>;
    @Type(() => UserResourceItem)
    SelectedUserResourceItems: Array<UserResourceItem>;
    @Type(() => EquipmentItem)
    RadiologyEquipmentItems: Array<EquipmentItem>;
    @Type(() => EquipmentItem)
    SelectedRadiologyEquipmentItems: Array<EquipmentItem>;
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
    @Type(() => RadiologyWorkListItem)
    public WorkListSearchItem: Array<RadiologyWorkListItem>;
    @Type(() => RadiologyWorkListStateItem)
    public WorkListSearchStateItem: Array<RadiologyWorkListStateItem>;
}

export class StateOutputDVO {
    @Type(() => RadiologyWorkListStateItem)
    public WorkListSearchStateItem: Array<RadiologyWorkListStateItem>;
}

export class UserResourceOutputDVO {
    public WorkListSearchUserResourceItem: Array<UserResourceItem>;
    public SelectedWorkListSearchUserResourceItem: Array<UserResourceItem>;
}
export class RadiologyWorkListItem {
    public ObjectDefName: string;
    public ObjectDefID: string;
}

export class RadiologyWorkListStateItem {
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
    @Type(() => RadiologyWorkListItem)
    public SelectedWorkListItems: Array<RadiologyWorkListItem>;
    @Type(() => RadiologyWorkListStateItem)
    public SelectedWorkListStateItems: Array<RadiologyWorkListStateItem>;
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

export class RadiologyEquipmentOutputDVO {
    public EquipmentItemList: Array<EquipmentItem>;
}


export class RadiologyStatisticReportViewModel {
    @Type(() => RadiologyStatisticBaseObject)
    public TestTypeList: Array<RadiologyStatisticBaseObject>;
    @Type(() => RadiologyStatisticBaseObject)
    public RadiologyTestList: Array<RadiologyStatisticBaseObject>;
    @Type(() => RadiologyStatisticBaseObject)
    public GenderList: Array<RadiologyStatisticBaseObject>;
    @Type(() => RadiologyStatisticBaseObject)
    public PayerList: Array<RadiologyStatisticBaseObject>;
    @Type(() => RadiologyStatisticBaseObject)
    public ResourceList: Array<RadiologyStatisticBaseObject>;
    @Type(() => RadiologyStatisticBaseObject)
    public EquipmentList: Array<RadiologyStatisticBaseObject>;
    @Type(() => RadiologyStatisticBaseObject)
    public ProcedureDoctorList: Array<RadiologyStatisticBaseObject>;
}
export class RadiologyStatisticBaseObject {

    public ObjectID: string;
    public Name: string;
}
