//$CCAE12BB
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ChattelDocumentWithPurchase } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentDetailWithPurchase } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentDistribution } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { DemandDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Demand } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';

import { Type } from 'NebulaClient/ClassTransformer';

export class BaseChattelDocumentWithPurchaseFormViewModel extends BaseViewModel {
     @Type(() => ChattelDocumentWithPurchase)
    public _ChattelDocumentWithPurchase: ChattelDocumentWithPurchase = new ChattelDocumentWithPurchase();
     @Type(() => ChattelDocumentDetailWithPurchase)
    public ChattelDocumentDetailsWithPurchaseGridList: Array<ChattelDocumentDetailWithPurchase> = new Array<ChattelDocumentDetailWithPurchase>();
     @Type(() => ChattelDocumentDistribution)
    public DemandAmountsGridGridList: Array<ChattelDocumentDistribution> = new Array<ChattelDocumentDistribution>();
     @Type(() => StockActionSignDetail)
    public StockActionSignDetailsGridList: Array<StockActionSignDetail> = new Array<StockActionSignDetail>();
     @Type(() => BudgetTypeDefinition)
    public BudgetTypeDefinitions: Array<BudgetTypeDefinition> = new Array<BudgetTypeDefinition>();
     @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
     @Type(() => Supplier)
    public Suppliers: Array<Supplier> = new Array<Supplier>();
     @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
     @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
     @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
     @Type(() => StockLevelType)
    public StockLevelTypes: Array<StockLevelType> = new Array<StockLevelType>();
     @Type(() => DemandDetail)
    public DemandDetails: Array<DemandDetail> = new Array<DemandDetail>();
     @Type(() => Demand)
    public Demands: Array<Demand> = new Array<Demand>();
     @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
     @Type(() => ResUser)
     public ResUsers: Array<ResUser> = new Array<ResUser>();
     public VermeBildirimID: string;
}
