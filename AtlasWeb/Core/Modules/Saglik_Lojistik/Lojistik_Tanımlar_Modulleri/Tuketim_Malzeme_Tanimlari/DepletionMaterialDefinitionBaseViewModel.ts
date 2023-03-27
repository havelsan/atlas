//$ADD2B22C
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class DepletionMaterialDefinitionBaseFormViewModel extends BaseViewModel {
    @Type(() => DepletionMaterialDefinitionQueryFilter)
    QueryModel: DepletionMaterialDefinitionQueryFilter;
    GridDataSource: any;

}

export class DepletionMaterialDefinitionQueryFilter {
    public IsActive: number = -1;
    public StoreID:string;
    public StockInheld: number = -1;
    public MaterialTree: string;
    public ShowZeroDistributionInfo: number = -1;
    public ActionStatus: number = -1;
}
