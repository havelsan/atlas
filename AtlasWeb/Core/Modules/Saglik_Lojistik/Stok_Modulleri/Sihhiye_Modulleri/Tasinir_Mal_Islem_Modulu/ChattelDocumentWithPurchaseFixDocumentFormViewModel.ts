//$C593CF70
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ChattelDocumentWithPurchase, PTSStockActionDetail } from "NebulaClient/Model/AtlasClientModel";
import { ChattelDocumentDetailWithPurchase } from "NebulaClient/Model/AtlasClientModel";
import { ChattelDocumentDistribution } from "NebulaClient/Model/AtlasClientModel";
import { StockActionSignDetail } from "NebulaClient/Model/AtlasClientModel";
import { BudgetTypeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Store } from "NebulaClient/Model/AtlasClientModel";
import { Supplier } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { StockCard } from "NebulaClient/Model/AtlasClientModel";
import { DistributionTypeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { StockLevelType } from "NebulaClient/Model/AtlasClientModel";
import { DemandDetail } from "NebulaClient/Model/AtlasClientModel";
import { Demand } from "NebulaClient/Model/AtlasClientModel";
import { ResSection } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { PTSMaterial } from "./BaseChattelDocumentWithPurchaseForm";

export class ChattelDocumentWithPurchaseFixDocumentFormViewModel extends BaseViewModel {
    public _ChattelDocumentWithPurchase: ChattelDocumentWithPurchase = new ChattelDocumentWithPurchase();
    public ChattelDocumentDetailsWithPurchaseGridList: Array<ChattelDocumentDetailWithPurchase> = new Array<ChattelDocumentDetailWithPurchase>();
    public DemandAmountsGridGridList: Array<ChattelDocumentDistribution> = new Array<ChattelDocumentDistribution>();
    public StockActionSignDetailsGridList: Array<StockActionSignDetail> = new Array<StockActionSignDetail>();
    public BudgetTypeDefinitions: Array<BudgetTypeDefinition> = new Array<BudgetTypeDefinition>();
    public Stores: Array<Store> = new Array<Store>();
    public Suppliers: Array<Supplier> = new Array<Supplier>();
    public Materials: Array<Material> = new Array<Material>();
    public StockCards: Array<StockCard> = new Array<StockCard>();
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    public StockLevelTypes: Array<StockLevelType> = new Array<StockLevelType>();
    public DemandDetails: Array<DemandDetail> = new Array<DemandDetail>();
    public Demands: Array<Demand> = new Array<Demand>();
    public ResSections: Array<ResSection> = new Array<ResSection>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public PTSStockActionDetails: Array<PTSStockActionDetail> = new Array<PTSStockActionDetail>();
    public PTSMaterials: Array<PTSMaterial> = new Array<PTSMaterial>();
}
