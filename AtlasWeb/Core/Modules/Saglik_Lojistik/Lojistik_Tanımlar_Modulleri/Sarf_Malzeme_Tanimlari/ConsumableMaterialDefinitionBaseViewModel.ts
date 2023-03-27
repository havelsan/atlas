//$ADD2B22C
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class ConsumableMaterialDefinitionBaseFormViewModel extends BaseViewModel {
    @Type(() => ConsumableMaterialDefinitionQueryFilter)
    QueryModel: ConsumableMaterialDefinitionQueryFilter;
    GridDataSource: any;

}

export class ConsumableMaterialDefinitionQueryFilter {
    public IsActive: number = -1;
    public StoreID:string;
    public IsInheld: number = -1;
    public MaterialTree: string;
    public ShowZeroDistributionInfo: number = -1;
    public ActionStatus: number = -1;
}
