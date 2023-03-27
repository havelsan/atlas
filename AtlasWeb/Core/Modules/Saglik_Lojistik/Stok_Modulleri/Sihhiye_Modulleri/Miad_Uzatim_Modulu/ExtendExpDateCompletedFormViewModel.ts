//$838A051A
import { ExtendExpirationDate } from 'NebulaClient/Model/AtlasClientModel';
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { ExtendExpirationDateDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from "NebulaClient/ClassTransformer";
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class ExtendExpDateCompletedFormViewModel extends BaseViewModel {
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
      @Type(() => DocumentRecordLog)
        public DocumentRecordLogsGridList: Array<DocumentRecordLog> = new Array<DocumentRecordLog>();
}
