//$75C6057F
import { BaseChattelDocument } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class BaseChattelDocumentFormViewModel extends BaseViewModel {
    @Type(() => BaseChattelDocument)
    public _BaseChattelDocument: BaseChattelDocument = new BaseChattelDocument();
    @Type(() => StockActionSignDetail)
    public StockActionSignDetailsGridList: Array<StockActionSignDetail> = new Array<StockActionSignDetail>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}
