//$27D9A3BB
import { ExtendExpirationDate } from 'NebulaClient/Model/AtlasClientModel';
import { ExtendExpirationDateDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class ExtendExpDateNewFormViewModel extends BaseViewModel {
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
    //@Type(() => OuttableLot)
    //public OuttableLots: Array<OuttableLot> = new Array<OuttableLot>();
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
