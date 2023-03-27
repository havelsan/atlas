//$3F1B88ED
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ChattelDocumentInputWithAccountancy } from "NebulaClient/Model/AtlasClientModel";
import { ChattelDocumentInputDetailWithAccountancy } from "NebulaClient/Model/AtlasClientModel";
import { StockActionSignDetail } from "NebulaClient/Model/AtlasClientModel";
import { BudgetTypeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Store } from "NebulaClient/Model/AtlasClientModel";
import { Accountancy } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { StockCard } from "NebulaClient/Model/AtlasClientModel";
import { DistributionTypeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { StockLevelType } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";

export class ChattelDocumentInputWithAccountancyFixDocumentViewModel extends BaseViewModel {
    public _ChattelDocumentInputWithAccountancy: ChattelDocumentInputWithAccountancy = new ChattelDocumentInputWithAccountancy();
    public ChattelDocumentDetailsWithAccountancyGridList: Array<ChattelDocumentInputDetailWithAccountancy> = new Array<ChattelDocumentInputDetailWithAccountancy>();
    public StockActionSignDetailsGridList: Array<StockActionSignDetail> = new Array<StockActionSignDetail>();
    public BudgetTypeDefinitions: Array<BudgetTypeDefinition> = new Array<BudgetTypeDefinition>();
    public Stores: Array<Store> = new Array<Store>();
    public Accountancys: Array<Accountancy> = new Array<Accountancy>();
    public Materials: Array<Material> = new Array<Material>();
    public StockCards: Array<StockCard> = new Array<StockCard>();
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    public StockLevelTypes: Array<StockLevelType> = new Array<StockLevelType>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}
