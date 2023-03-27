//$57BF5316
import { ExtendExpirationDate } from 'NebulaClient/Model/AtlasClientModel';
import { ExtendExpirationDateDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class ExtendExpDateApprovalFormViewModel extends BaseViewModel {
    @Type(() => ExtendExpirationDate)
    public _ExtendExpirationDate: ExtendExpirationDate = new ExtendExpirationDate();
    @Type(() => ExtendExpirationDateDetail)
    public ExtendExpirationDateDetailsGridList: Array<ExtendExpirationDateDetail> = new Array<ExtendExpirationDateDetail>();
    @Type(() => StockActionSignDetail)
    public StockActionSignDetailsGridList: Array<StockActionSignDetail> = new Array<StockActionSignDetail>();
    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockLevelType)
    public StockLevelTypes: Array<StockLevelType> = new Array<StockLevelType>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}
