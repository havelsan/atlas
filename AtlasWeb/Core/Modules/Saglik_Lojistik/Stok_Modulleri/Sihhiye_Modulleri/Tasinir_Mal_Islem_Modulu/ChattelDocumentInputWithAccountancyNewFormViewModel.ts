//$702FBACE
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ChattelDocumentInputWithAccountancy, PTSStockActionDetail } from 'NebulaClient/Model/AtlasClientModel';
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
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { PTSMaterial } from "./BaseChattelDocumentWithPurchaseForm";


export class ChattelDocumentInputWithAccountancyNewFormViewModel extends BaseViewModel {
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

    public chattelDocumentInputWithAccountancyGridViewModel: Array<ChattelDocumentInputWithAccountancyGridViewModel> = new Array<ChattelDocumentInputWithAccountancyGridViewModel>();
    @Type(() => PTSStockActionDetail)
    public PTSStockActionDetails: Array<PTSStockActionDetail> = new Array<PTSStockActionDetail>();
    @Type(() => PTSMaterial)
    public PTSMaterials: Array<PTSMaterial> = new Array<PTSMaterial>();

}

export class ChattelDocumentInputWithAccountancyGridViewModel {
    public MaterialObjectID: Guid;
    public MaterialName: string;
    public Material: Material;
    public Barcode: string;
    public UnitType: string;
    public Amount: number;
    public NotDiscountedUnitPrice: number;
    public KDV: number;
    public DiscountRate: number;
    //İndirim ve Kdv Oranı ile hesaplanan birim fiyat
    public CalculatedUnitPriceOfMaterial: number;
    public TotalPriceNotDiscount: number;
    public TotalDiscountAmount: number;
    public TotalPrice: number;
    public LotNo: string;
    public ExpirationDate: Date;
    public StockLevelType: string;
    public StockLevelTypeObjectID: Guid;
    public RetrievalYear: number;
    public ProductionDate: Date;
}
