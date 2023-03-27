//$93834E0F
import { CensusFixed } from 'NebulaClient/Model/AtlasClientModel';
import { CensusFixedMaterialIn } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { CensusFixedMaterialOut } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class CensusFixedNewFormViewModel extends BaseViewModel {
    @Type(() => CensusFixed)
    public _CensusFixed: CensusFixed = new CensusFixed();
    @Type(() => CensusFixedMaterialIn)
    public StockActionInDetailsGridList: Array<CensusFixedMaterialIn> = new Array<CensusFixedMaterialIn>();
    @Type(() => StockActionSignDetail)
    public StockActionSignDetailsGridList: Array<StockActionSignDetail> = new Array<StockActionSignDetail>();
    @Type(() => CensusFixedMaterialOut)
    public StockActionOutDetailsGridList: Array<CensusFixedMaterialOut> = new Array<CensusFixedMaterialOut>();
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
     @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}
