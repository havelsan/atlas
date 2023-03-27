import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { DrugUsageTypeEnum } from "app/NebulaClient/Model/AtlasClientModel";

export class StoreOutTotalReportViewModel extends BaseViewModel {

}

export class  StoreOutTotalInputDTO {
    public storeIDList: Array<string>;
    public materialID: Guid;
    public budgettypeID: Guid;
    public startDate:Date;
    public endDate:Date;
    public drugSpecificationList: Array<number>;
    public stockTransactionDefList: Array<Guid>;
}

export class  StoreOutTotalOutputDTO {
    public MaterialName: string;
    public Barcode: string;
    public StockCardNo: string;
    public Amount: number;
    public UnitePrice: number;
    public TotalPrice: number;
    public StoreName: string;
    public BudgetTypeName: string;
    public DistributionType: string;
    public MaterialObjectId:Guid;
    public StocktransactionDefName:string;
}
