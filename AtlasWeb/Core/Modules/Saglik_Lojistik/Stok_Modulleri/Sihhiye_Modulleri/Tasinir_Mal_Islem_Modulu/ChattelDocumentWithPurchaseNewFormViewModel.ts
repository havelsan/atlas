//$D19F5AD9
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ChattelDocumentWithPurchase, PTSStockActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { TmpOrderedSupplier } from 'NebulaClient/Model/AtlasClientModel';
import { TmpOrderedDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentDetailWithPurchase } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentDistribution } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { PurchaseOrder } from 'NebulaClient/Model/AtlasClientModel';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';
import { PurchaseOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { PurchaseItemDef } from 'NebulaClient/Model/AtlasClientModel';
import { PurchaseProjectDetail } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { DemandDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Demand } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';

import { Type } from 'NebulaClient/ClassTransformer';
import { RespectiveIncomingUTSNotification, PTSMaterial } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentWithPurchaseForm";

export class ChattelDocumentWithPurchaseNewFormViewModel extends BaseViewModel {
    @Type(() => ChattelDocumentWithPurchase)
    public _ChattelDocumentWithPurchase: ChattelDocumentWithPurchase = new ChattelDocumentWithPurchase();
    @Type(() => TmpOrderedSupplier)
    public OrderedSuppliersGridGridList: Array<TmpOrderedSupplier> = new Array<TmpOrderedSupplier>();
    @Type(() => TmpOrderedDetail)
    public OrderedDetailsGridList: Array<TmpOrderedDetail> = new Array<TmpOrderedDetail>();
    @Type(() => ChattelDocumentDetailWithPurchase)
    public ChattelDocumentDetailsWithPurchaseGridList: Array<ChattelDocumentDetailWithPurchase> = new Array<ChattelDocumentDetailWithPurchase>();
    @Type(() => ChattelDocumentDistribution)
    public DemandAmountsGridGridList: Array<ChattelDocumentDistribution> = new Array<ChattelDocumentDistribution>();
    @Type(() => StockActionSignDetail)
    public StockActionSignDetailsGridList: Array<StockActionSignDetail> = new Array<StockActionSignDetail>();
    @Type(() => PurchaseOrder)
    public PurchaseOrders: Array<PurchaseOrder> = new Array<PurchaseOrder>();
    @Type(() => Supplier)
    public Suppliers: Array<Supplier> = new Array<Supplier>();
    @Type(() => PurchaseOrderDetail)
    public PurchaseOrderDetails: Array<PurchaseOrderDetail> = new Array<PurchaseOrderDetail>();
    @Type(() => PurchaseItemDef)
    public PurchaseItemDefs: Array<PurchaseItemDef> = new Array<PurchaseItemDef>();
    @Type(() => PurchaseProjectDetail)
    public PurchaseProjectDetails: Array<PurchaseProjectDetail> = new Array<PurchaseProjectDetail>();
    @Type(() => BudgetTypeDefinition)
    public BudgetTypeDefinitions: Array<BudgetTypeDefinition> = new Array<BudgetTypeDefinition>();
    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
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
    @Type(() => RespectiveIncomingUTSNotification)
    public RespectiveIncomingUTSNotificationList: Array<RespectiveIncomingUTSNotification> = new Array<RespectiveIncomingUTSNotification>();
    public UTSEntegration: boolean;
    @Type(() => PTSStockActionDetail)
    public PTSStockActionDetails: Array<PTSStockActionDetail> = new Array<PTSStockActionDetail>();
    @Type(() => PTSMaterial)
    public PTSMaterials: Array<PTSMaterial> = new Array<PTSMaterial>();

}
