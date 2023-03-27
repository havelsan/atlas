//$C7DC911D
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { SupplyRequest } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRequestDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { PurchaseGroup } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class SupplyRequestApprovalFormViewModel extends BaseViewModel  {
    @Type(() => SupplyRequest)
    public _SupplyRequest: SupplyRequest = new SupplyRequest();
     @Type(() => SupplyRequestDetail)
    public SupplyRequestDetailsGridList: Array<SupplyRequestDetail> = new Array<SupplyRequestDetail>();
     @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
     @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
     @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
     @Type(() => PurchaseGroup)
    public PurchaseGroups: Array<PurchaseGroup> = new Array<PurchaseGroup>();
     @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
}
