import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { DrugUsageTypeEnum } from "app/NebulaClient/Model/AtlasClientModel";

export class StoreInTotalReportViewModel extends BaseViewModel {

}

export class StoreInTotalInputDTO {
    public storeIDList: Array<string>;
    public materialID: Guid;
    public budgettypeID: Guid;
    public startDate:Date;
    public endDate:Date;
    public drugSpecificationList: Array<number>;
}

export class StoreInTotalOutputDTO {
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
}