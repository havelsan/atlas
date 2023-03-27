import { BaseModel } from 'Fw/Models/BaseModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';

export class NuclearMedicineWorkListFormViewModel extends BaseModel {
    @Type(() => NuclearMedicineWorkListItemModel)
    NuclearMedicineList: Array<NuclearMedicineWorkListItemModel> = new Array<NuclearMedicineWorkListItemModel>();
    @Type(() => Boolean)
    public OnlyOwnPatient: boolean;
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
    ProtocolNo: string;
    @Type(() => NuclearMedicineWorkListItem)
    NuclearMedicineWorkListItems: Array<NuclearMedicineWorkListItem>;
    @Type(() => NuclearMedicineWorkListStateItem)
    NuclearMedicineWorkListStateItems: Array<NuclearMedicineWorkListStateItem>;
    @Type(() => NuclearMedicineWorkListStateItem)
    NuclearMedicineWorkListStateItemsAll: Array<NuclearMedicineWorkListStateItem>;
    @Type(() => NuclearMedicineWorkListItem)
    SelectedNuclearMedicineWorkListItems: Array<NuclearMedicineWorkListItem>;
    @Type(() => NuclearMedicineWorkListStateItem)
    SelectedNuclearMedicineWorkListStateItems: Array<NuclearMedicineWorkListStateItem>;
    @Type(() => UserResourceItem)
    UserResourceItems: Array<UserResourceItem>;
    @Type(() => UserResourceItem)
    SelectedUserResourceItems: Array<UserResourceItem>;
    @Type(() => EquipmentItem)
    RadiologyEquipmentItems: Array<EquipmentItem>;
    @Type(() => EquipmentItem)
    SelectedNuclearMedicineEquipmentItems: Array<EquipmentItem>;
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

export class NuclearMedicineWorkListItemModel {
    public ObjectID: string;
    public ObjectDefName: string;
    public PatientNameSurname: string;
    public ID: string;
    public AdmissionQueueNumber: string;
    public EpisodeActionObjectID: string;
    public EpisodeActionName: string;
    public NuclearMedicineTestName: string;
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
    public isNuclearMedicineTestEmergency: boolean;
    public ActionDate: string;
    public RowColor: string;
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

export class StateOutputDVO {
    @Type(() => NuclearMedicineWorkListStateItem)
    public WorkListSearchStateItem: Array<NuclearMedicineWorkListStateItem>;
}

export class NuclearMedicineWorkListStateItem {
    public StateDefName: string;
    public StateDefID: string;
}

export class NuclearMedicineWorkListItem {
    public ObjectDefName: string;
    public ObjectDefID: string;
}

export class NuclearMedicineInputDVO {
    public OnlyOwnPatient: boolean;
    public txtPatient: string;
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
    public StateType: string;
    public PatientStatus: string;
    public ProtocolNo: string;
    public ID: string;
    @Type(() => Number)
    public WorkListCount: number;
    @Type(() => NuclearMedicineWorkListItem)
    public SelectedWorkListItems: Array<NuclearMedicineWorkListItem>;
    @Type(() => NuclearMedicineWorkListStateItem)
    public SelectedWorkListStateItems: Array<NuclearMedicineWorkListStateItem>;
    @Type(() => NuclearMedicineWorkListItem)
    public WorkListItems: Array<NuclearMedicineWorkListItem>;
    @Type(() => NuclearMedicineWorkListStateItem)
    public WorkListStateItems: Array<NuclearMedicineWorkListStateItem>;
    @Type(() => UserResourceItem)
    UserResourceItems: Array<UserResourceItem>;
    @Type(() => UserResourceItem)
    SelectedUserResourceItems: Array<UserResourceItem>;
    @Type(() => EquipmentItem)
    NuclearMedicineEquipmentItems: Array<EquipmentItem>;
    @Type(() => EquipmentItem)
    SelectedNuclearMedicineEquipmentItems: Array<EquipmentItem>;
    public activeResUserObjectID: string;
    public userSelectedOutPatientResource: ResSection;
    public userSelectedInPatientResource: ResSection;
    public userSelectedSecMasterResource: ResSection;
    public SelectedStateTypes: Array<string>;
    public SelectedStateTypesEM: Array<string>;
    public SelectedQueueObjectID: string;
}

export class UserResourceItem {
    public ResourceName: string;
    public ResourceID: string;
}

export class EquipmentItem {
    public EquipmentName: string;
    public EquipmentResourceID: string;
}

export class UserResourceOutputDVO {
    public WorkListSearchUserResourceItem: Array<UserResourceItem>;
    public SelectedWorkListSearchUserResourceItem: Array<UserResourceItem>;
}
