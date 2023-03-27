//$96E0FE85
import { ChangeStockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { ChangeStockLevelTypeDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class ChangeStockLevelTypeFormViewModel extends BaseViewModel {
    @Type(() => ChangeStockLevelType)
    public _ChangeStockLevelType: ChangeStockLevelType = new ChangeStockLevelType();
    @Type(() => ChangeStockLevelTypeDetail)
    public MaterialDetailsGridList: Array<ChangeStockLevelTypeDetail> = new Array<ChangeStockLevelTypeDetail>();
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
    @Type(() => BudgetTypeDefinition)
    public BudgetTypeDefinitions: Array<BudgetTypeDefinition> = new Array<BudgetTypeDefinition>();

}
