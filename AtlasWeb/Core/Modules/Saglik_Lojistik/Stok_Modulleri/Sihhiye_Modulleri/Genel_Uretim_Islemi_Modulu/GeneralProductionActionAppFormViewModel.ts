//$62CB09EC
import { GeneralProductionAction } from 'NebulaClient/Model/AtlasClientModel';
import { GeneralProductionOutDet } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class GeneralProductionActionAppFormViewModel extends BaseViewModel {
    @Type(() => GeneralProductionAction)
    public _GeneralProductionAction: GeneralProductionAction = new GeneralProductionAction();
    @Type(() => GeneralProductionOutDet)
    public GeneralProductionOutDetsGridList: Array<GeneralProductionOutDet> = new Array<GeneralProductionOutDet>();
    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => BudgetTypeDefinition)
    public BudgetTypeDefinitions: Array<BudgetTypeDefinition> = new Array<BudgetTypeDefinition>();
}
