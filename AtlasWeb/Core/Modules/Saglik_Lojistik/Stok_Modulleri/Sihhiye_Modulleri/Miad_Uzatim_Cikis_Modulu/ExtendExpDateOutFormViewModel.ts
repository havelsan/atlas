//$A45A39CE
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ExtendExpDateOut } from "NebulaClient/Model/AtlasClientModel";
import { ExtendExpDateOutDetail } from "NebulaClient/Model/AtlasClientModel";
import { StockActionSignDetail } from "NebulaClient/Model/AtlasClientModel";
import { Store } from "NebulaClient/Model/AtlasClientModel";
import { Supplier } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class ExtendExpDateOutFormViewModel extends BaseViewModel {
    @Type(() => ExtendExpDateOut)
    public _ExtendExpDateOut: ExtendExpDateOut = new ExtendExpDateOut();
    @Type(() => ExtendExpDateOutDetail)
    public ExtendExpDateOutDetailsGridList: Array<ExtendExpDateOutDetail> = new Array<ExtendExpDateOutDetail>();
    @Type(() => StockActionSignDetail)
    public StockActionSignDetailsGridList: Array<StockActionSignDetail> = new Array<StockActionSignDetail>();
    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
    @Type(() => Supplier)
    public Suppliers: Array<Supplier> = new Array<Supplier>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => TempOuttableLot)
    public TempOuttableLots: Array<TempOuttableLot> = new Array<TempOuttableLot>();
}

export class TempOuttableLot {
    public Amount: Currency;
    public RestAmount: Currency;
    public ExpirationDate: Date;
    public LotNo: string;
    public isUse: boolean;
    public StockActionDetailOutID: string;
}