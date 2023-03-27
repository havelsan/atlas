//$47F169A8
import { GrantMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { GrantMaterialDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class GrantMaterialCompletedFormViewModel extends BaseViewModel {
     @Type(() => GrantMaterial)
    public _GrantMaterial: GrantMaterial = new GrantMaterial();
    @Type(() => GrantMaterialDetail)
    public GrantMaterialDetailsGridList: Array<GrantMaterialDetail> = new Array<GrantMaterialDetail>();
    @Type(() => StockActionSignDetail)
    public StockActionSignDetailsGridList: Array<StockActionSignDetail> = new Array<StockActionSignDetail>();
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
    @Type(() => DocumentRecordLog)
    public DocumentRecordLogsGridList: Array<DocumentRecordLog> = new Array<DocumentRecordLog>();
}
