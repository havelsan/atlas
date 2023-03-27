//$5D31D6EE
import { ChangeStockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { ChangeStockLevelTypeDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from "NebulaClient/ClassTransformer";
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";


export class ChngeStockLvlTypeComlatedFormViewModel extends BaseViewModel {
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
     @Type(() => DocumentRecordLog)
        public DocumentRecordLogsGridList: Array<DocumentRecordLog> = new Array<DocumentRecordLog>();
}
