//$3B80AD72
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { SupplyRequestPoolDetail } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRequestDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { PurchaseGroup } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRequest } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class SupplyRqstPlDetailFormViewModel extends BaseViewModel {
     @Type(() => SupplyRequestPoolDetail)
    public _SupplyRequestPoolDetail: SupplyRequestPoolDetail = new SupplyRequestPoolDetail();
     @Type(() => SupplyRequestDetail)
    public SupplyRequestDetailsGridList: Array<SupplyRequestDetail> = new Array<SupplyRequestDetail>();
     @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
     @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
     @Type(() => PurchaseGroup)
    public PurchaseGroups: Array<PurchaseGroup> = new Array<PurchaseGroup>();
     @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
     @Type(() => SupplyRequest)
    public SupplyRequests: Array<SupplyRequest> = new Array<SupplyRequest>();
     @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
}
