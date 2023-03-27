//$DB89F690
import { BaseModel } from 'Fw/Models/BaseModel';
import { ResUser, ResSection, UserOptionType, ResSterilizationDevice} from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { TTObjectStateDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateDef';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';

export class SterilizationWorkListViewModel extends BaseModel {
    @Type(() => SterilizationWorkListItemModel)
    sterilizationActionList: Array<SterilizationWorkListItemModel> = new Array<SterilizationWorkListItemModel>();
    _sterilizationWorkListSearchCriteria: SterilizationWorkListSearchCriteria = new SterilizationWorkListSearchCriteria();
    _sterilizationFilterList: SterilizationFilterList = new SterilizationFilterList();
    @Type(() => GridDataSources)
    gridDataSources: GridDataSources = new GridDataSources();
}

export class SterilizationWorkListItemModel {

    public ObjectID: string;
    public MaterialName: string;
    public MaterialID: string;
    @Type(() => Date)
    public RequestDate: Date;
    public CurrentState: string;
    public ResSectionName: string;
    public PackageMethod: string;
    public IndicatorSelection: string;
    public Sterilization: string;
    public ResSterilizationDevice: string;
    public DeviceLoopNo: number;
    public SterilizationUser: string;
    public DeliveredUserAfterUser: string;

    public nextStateText: string;
}

export class SterilizationWorkListSearchCriteria {
    @Type(() => Date)
    public workListStartDate: Date;
    @Type(() => Date)
    public workListEndDate: Date;

    @Type(() => ResUser)
    public requesterDoctor: ResUser;


    @Type(() => ResSection)
    public selectedResourceList: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResSterilizationDevice)
    public selectedDeviceList: Array<ResSterilizationDevice> = new Array<ResSterilizationDevice>();
    @Type(() => Guid)
    public selectedSterilizationWorkListStateItem: Guid;

    constructor() {
    }

}

export class SterilizationFilterList
{
    @Type(() => TTObjectStateDef)
    public sterilizationWorkListStateItem: Array<StateDef> = new Array<StateDef>();
    @Type(() => ResSection)
    public resourceList: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResSterilizationDevice)
    public deviceList: Array<ResSterilizationDevice> = new Array<ResSterilizationDevice>();
    @Type(() => ResUser)
    public sterilizationUserList: Array<ResUser> = new Array<ResUser>();
    @Type(() => ResSection)
    public deliveredUserAfterUserList: Array<ResUser> = new Array<ResUser>();
}

export class UserOptionInputDVO {
    public UserOptionType: UserOptionType;
    public OptionValue: string;
}

export class StateDef {
    public StateDefID: Guid;
    public DisplayText: string;
}

export class GridDataSources {
  public sterilizationPackageMethodEnumItems:  Array<EnumItem>;
  public indicatorSelectionEnumItems:  Array<EnumItem>;
  public sterilizasyonSelectionEnumItems:  Array<EnumItem>;
}