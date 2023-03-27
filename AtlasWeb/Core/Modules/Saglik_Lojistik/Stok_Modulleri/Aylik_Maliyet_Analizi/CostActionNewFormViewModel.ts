//$BA13E138
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { CostAction } from 'NebulaClient/Model/AtlasClientModel';
import { CostActionMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class CostActionNewFormViewModel extends BaseViewModel {
     @Type(() => CostAction)
    public _CostAction: CostAction = new CostAction();
    @Type(() => CostActionMaterial)
    public CostActionMaterialsGridList: Array<CostActionMaterial> = new Array<CostActionMaterial>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
}
