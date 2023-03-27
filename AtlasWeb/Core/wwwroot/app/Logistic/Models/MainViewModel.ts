import { BaseModel } from 'Fw/Models/BaseModel';
import { EnumItem } from 'NebulaClient/Mscorlib/EnumItem';
import { IEnumList } from 'NebulaClient/Mscorlib/IEnumList';
import { ClassType } from 'NebulaClient/ClassTransformer';

export class MainViewModel extends BaseModel {
    public hasRoleStockWorkList: boolean;
    public hasRoleDashboard: boolean;
    public hasRoleMkysIntegration: boolean;
    public hasRoleSupplyRequestManager: boolean;
    public hasRoleLogisticAddAndUpdate: boolean;
    public hasRoleDefinitions:boolean;
}

export enum CriticalStockLevelTypeEnum
{
    GetStockLevelUnderMin = 0,
    GetStockLevelOverCritical = 1,
    GetStockLevelUnderCritical = 2,
    GetStockLevelOverMax = 3
}

export namespace CriticalStockLevelTypeEnum {
    export const _GetStockLevelUnderMin = new EnumItem(CriticalStockLevelTypeEnum.GetStockLevelUnderMin, 'Under Minimum Stock', 'Minimum Stok Seviyesi Altında', 0);
    export const _GetStockLevelOverCritical = new EnumItem(CriticalStockLevelTypeEnum.GetStockLevelOverCritical, 'Over Critical', 'Kritik Stok Seviyesi Üzerinde', 1);
    export const _GetStockLevelUnderCritical = new EnumItem(CriticalStockLevelTypeEnum.GetStockLevelUnderCritical, 'Under Critical', 'Kritik Stok Seviyesi Altında', 2);
    export const _GetStockLevelOverMax = new EnumItem(CriticalStockLevelTypeEnum.GetStockLevelOverMax, 'Over Maximum', 'Maksimum Stok Seviyesi Üzerinde', 3);

    export const Items: Array<EnumItem> = [ _GetStockLevelUnderMin, _GetStockLevelOverCritical, _GetStockLevelUnderCritical, _GetStockLevelOverMax ];

    @ClassType()
    export class CriticalStockLevelTypeEnumList implements IEnumList {
        get Items(): Array<EnumItem> {
            return CriticalStockLevelTypeEnum.Items;
        }
    }
}

export class TabTreeModel {
    public id: number;
    public text: string;
    public expanded: boolean;
    public items: Array<TabTreeModel>;
}

export class ControlOfDefinitionRole{
    public DrugDefinitionNewAdd:boolean;
    public ConsumableMaterialNewAdd:boolean;
    public SupplierAndProducreNewAdd:boolean;
    public  MaterialTreeDefinitionAdd:boolean;
}