import { BaseModel } from 'Fw/Models/BaseModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

export class SupplyRequestManagerViewModel extends BaseModel {
    public SupplyRequestStatusList: Array<SupplyRequestStatus>;
    public SupplyRequestStatusFastSoftList: Array<SupplyRequestStatusFastSoft>;
}
export class QueryInput {
    @Type(() => Date)
    public startDate: Date;
    @Type(() => Date)
    public endDate: Date;
    @Type(() => Guid)
    public storeObjID: Guid;

}
export class SupplyRequestStatus {
    public stockActionID: string;
    @Type(() => Date)
    public stockActionDate: Date;
    public isImmediate: boolean;
    public requestedUser: string;
    public description: string;
    public XXXXXXKayitId: string;
    public islemSonucs: Array<IslemSonuc>;
}
export class IslemSonuc {
    public etkilenenAdetField: number;
    public islemBasariliField: boolean;
    public mesajField: string;
    public kayitIDField: number;
    public tabloPkIdField: number;
}

export class SupplyRequestStatusFastSoft {
    public InvoiceNumber: string;
    @Type(() => Date)
    public ActionDate: Date;
    public ItemCount: number;
    public SupplierName: string;
    public ItemInfos: Array<SupplyRequestStatusFastSoftItemInfo>;
    public Status: string;
}

export class SupplyRequestStatusFastSoftItemInfo {
    public MaterialName: string;
    public Barcode: string;
    public Amount: number;
    public Price: number;
}