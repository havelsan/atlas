//$ADD2B22C
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class DrugDefinitionBaseFormViewModel extends BaseViewModel {
    @Type(() => DrugDefinitionQueryFilter)
    QueryModel: DrugDefinitionQueryFilter;
    GridDataSource: any;

}

export class DrugDefinitionQueryFilter {
    public IsActive: number = -1;
    public ShowZeroOnDrugOrder: number = -1;
    public DrugSpecs: Array<number>;
    public IsInheld: number = -1;
    public ShowZeroDistributionInfo: number = -1;
    public ActionStatus: number = -1;
    public AllDrugSpecifications:boolean=false;
    public AllDrugShapeType:boolean=false;
    public DrugShape:Array<number>;
    public DrugShapeTypeList;
    public DrugSpecificationEnumDef;
    public StoreID:string;
}


