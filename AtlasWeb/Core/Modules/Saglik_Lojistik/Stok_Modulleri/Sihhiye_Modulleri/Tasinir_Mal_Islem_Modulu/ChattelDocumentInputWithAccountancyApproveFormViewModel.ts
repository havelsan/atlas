//$24A8417C
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ChattelDocumentInputWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentInputDetailWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Accountancy } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser, Supplier } from 'NebulaClient/Model/AtlasClientModel';

import { Type } from 'NebulaClient/ClassTransformer';

export class ChattelDocumentInputWithAccountancyApproveFormViewModel extends BaseViewModel {
    @Type(() => ChattelDocumentInputWithAccountancy)
    public _ChattelDocumentInputWithAccountancy: ChattelDocumentInputWithAccountancy = new ChattelDocumentInputWithAccountancy();
    @Type(() => ChattelDocumentInputDetailWithAccountancy)
    public ChattelDocumentDetailsWithAccountancyGridList: Array<ChattelDocumentInputDetailWithAccountancy> = new Array<ChattelDocumentInputDetailWithAccountancy>();
    @Type(() => StockActionSignDetail)
    public StockActionSignDetailsGridList: Array<StockActionSignDetail> = new Array<StockActionSignDetail>();
    @Type(() => BudgetTypeDefinition)
    public BudgetTypeDefinitions: Array<BudgetTypeDefinition> = new Array<BudgetTypeDefinition>();
    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
    @Type(() => Accountancy)
    public Accountancys: Array<Accountancy> = new Array<Accountancy>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => StockLevelType)
    public StockLevelTypes: Array<StockLevelType> = new Array<StockLevelType>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Supplier)
    public Suppliers: Array<Supplier> = new Array<Supplier>();
}
