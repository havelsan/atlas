//$5DB20B5B
import { SubStoreConsumptionAction } from 'NebulaClient/Model/AtlasClientModel';
import { SubStoreConsumptionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class BaseSubStoreConsumptionActionFormViewModel extends BaseViewModel {
    @Type(() => SubStoreConsumptionAction)
    public _SubStoreConsumptionAction: SubStoreConsumptionAction = new SubStoreConsumptionAction();
    @Type(() => SubStoreConsumptionDetail)
    public SubStoreConsumptionActionDetailsGridList: Array<SubStoreConsumptionDetail> = new Array<SubStoreConsumptionDetail>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => StockLevelType)
    public StockLevelTypes: Array<StockLevelType> = new Array<StockLevelType>();
    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
}
