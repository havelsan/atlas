//$ADD2B22C
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class MaterialDefinitionViewModel extends BaseViewModel {
    @Type(() => QueryFilter)
    QueryModel: QueryFilter;
    GridDataSource: any;

}

export class QueryFilter {
    public IsActive: number = -1;
    public ShowZeroOnDrugOrder: number = -1;
    public DrugSpecs: Array<number>;
    public IsInheld: number = -1;
    public ShowZeroDistributionInfo: number = -1;
    public ActionStatus: number = -1;
    public AllDrugSpecifications:boolean=false;
    public AllDrugShapeType:boolean=false;
    public DrugShape:Array<number>;
   // public AllShowZeroOnDrugOrder:boolean=false;
  //  public AllIsInheld:boolean=false;
   // public AllShowZeroDistributionInfo:boolean=false;
   // public AllActionStatus:boolean=false;
    //public AllIsActive:boolean=false;
    public DrugShapeTypeList;
    public DrugSpecificationEnumDef;
    public StoreID:string;
}
