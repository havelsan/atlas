//$5DC7E99B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ExtendExpDateOut } from "NebulaClient/Model/AtlasClientModel";
import { ExtendExpDateOutDetail } from "NebulaClient/Model/AtlasClientModel";
import { StockActionSignDetail } from "NebulaClient/Model/AtlasClientModel";
import { Store } from "NebulaClient/Model/AtlasClientModel";
import { Supplier } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class BaseExtendExpDateOutFormViewModel extends BaseViewModel {
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
}
