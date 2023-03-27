//$50A83B26
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { MagistralPreparationAction } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationUsedDrug } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationUsedChemical } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationUsedMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationDetail } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationUsedDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DrugDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralChemicalDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ConsumableMaterialDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPackagingType } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPackagingSubType } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationSubType } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationType } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class MagistralPreparationActionCompletedFormViewModel extends BaseViewModel {
  @Type(() => MagistralPreparationAction)
    public _MagistralPreparationAction: MagistralPreparationAction = new MagistralPreparationAction();
     @Type(() => MagistralPreparationUsedDrug)
    public MagistralPreparationUsedDrugsGridList: Array<MagistralPreparationUsedDrug> = new Array<MagistralPreparationUsedDrug>();
     @Type(() => MagistralPreparationUsedChemical)
    public MagistralPreparationUsedChemicalsGridList: Array<MagistralPreparationUsedChemical> = new Array<MagistralPreparationUsedChemical>();
     @Type(() => MagistralPreparationUsedMaterial)
    public MagistralPreparationUsedMaterialsGridList: Array<MagistralPreparationUsedMaterial> = new Array<MagistralPreparationUsedMaterial>();
     @Type(() => MagistralPreparationDetail)
    public MagistralPreparationDetailsGridList: Array<MagistralPreparationDetail> = new Array<MagistralPreparationDetail>();
     @Type(() => MagistralPreparationUsedDetail)
    public StockActionDetailsGridList: Array<MagistralPreparationUsedDetail> = new Array<MagistralPreparationUsedDetail>();
     @Type(() => DrugDefinition)
    public DrugDefinitions: Array<DrugDefinition> = new Array<DrugDefinition>();
     @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
     @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
     @Type(() => MagistralChemicalDefinition)
    public MagistralChemicalDefinitions: Array<MagistralChemicalDefinition> = new Array<MagistralChemicalDefinition>();
     @Type(() => ConsumableMaterialDefinition)
    public ConsumableMaterialDefinitions: Array<ConsumableMaterialDefinition> = new Array<ConsumableMaterialDefinition>();
     @Type(() => MagistralPreparationDefinition)
    public MagistralPreparationDefinitions: Array<MagistralPreparationDefinition> = new Array<MagistralPreparationDefinition>();
     @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
     @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
     @Type(() => MagistralPackagingType)
    public MagistralPackagingTypes: Array<MagistralPackagingType> = new Array<MagistralPackagingType>();
     @Type(() => MagistralPackagingSubType)
    public MagistralPackagingSubTypes: Array<MagistralPackagingSubType> = new Array<MagistralPackagingSubType>();
     @Type(() => MagistralPreparationSubType)
    public MagistralPreparationSubTypes: Array<MagistralPreparationSubType> = new Array<MagistralPreparationSubType>();
     @Type(() => MagistralPreparationType)
    public MagistralPreparationTypes: Array<MagistralPreparationType> = new Array<MagistralPreparationType>();
}
