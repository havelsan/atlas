//$1265A901
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { SupplyRequestPool } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRequestPoolDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class SupplyRequestPoolCompletedFormViewModel extends BaseViewModel {
   @Type(() => SupplyRequestPool)
    public _SupplyRequestPool: SupplyRequestPool = new SupplyRequestPool();
      @Type(() => SupplyRequestPoolDetail)
    public SupplyRequestPoolDetailsGridList: Array<SupplyRequestPoolDetail> = new Array<SupplyRequestPoolDetail>();
      @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
      @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
      @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
      @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}
