import { BaseModel } from 'Fw/Models/BaseModel';
import { MenuDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TTListDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTListDef';
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

export class LogisticMainViewModel extends BaseModel {

    stockactionlist: Array<StockActionWorkListItemModel> = new Array<StockActionWorkListItemModel>();
    @Type(() => Date)
    StartDate: Date;
    @Type(() => Date)
    EndDate: Date;
    StockActionId: string;
    TIFId: string;
    WorkListCount: number;
    StateType: string;
    menulist: Array<MenuDefinition>;
    workListItems: Array<WorkListItem>;
    selectedWorkListItems: Array<WorkListItem>;
    PartialCancel: boolean;
    EHUWait: boolean;
    IsEmergencyMaterial: boolean;
}

export class StockActionWorkListItemModel {

    public ObjectID: string;
    public StockActionID: number;
    public Store: string;
    public DestinationStore: string;
    public StockactionName: string;
    @Type(() => Date)
    public TransactionDate: Date;
    public StateName: string;
    public StateFormName: string;
    public PatientName: string;
}

export class QueryInputDVO {
    @Type(() => Guid)
    public StoreID: Guid;
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
    public StateType: string;
    public StockActionId: string;
    public TIFId: string;
    public WorkListCount: number;
    public SelectedWorkListItems: Array<WorkListItem>;
    public MKYSState: string;
    public PartialCancel: boolean;
    public EHUWait: boolean;
    public IsEmergencyMaterial: boolean;
}

export class MenuOutputDVO {
    public StockActionMenuItems: Array<MenuDefinition>;
    public WorkListSearchItem: Array<WorkListItem>;
    public StockDefinitionMenuItems: Array<TTListDef>;
}

export class WorkListItem {
    public ObjectDefName: string;
    public ObjectDefId: string;
}

export class DynamicComponentInfoDVO {
    public ComponentName: string;
    public ModuleName: string;
    public ModulePath: string;
    public objectID: string;
}

export enum WorkListResultColorEnum {
    red = 0,
    white = 1
}

export class StockMenuItem {
    public Name: string;
    public Value: number;
}

