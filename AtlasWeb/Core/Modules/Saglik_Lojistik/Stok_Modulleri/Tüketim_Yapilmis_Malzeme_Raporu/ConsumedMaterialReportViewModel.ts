import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";


export class ConsumedMaterialReportViewModel extends BaseViewModel {

}

export class  ConsumedMaterialReportInputDTO {
    public storeIDList: Array<string>;
    public budgettypeID: Guid;
    public startDate:Date;
    public endDate:Date;
}

export class  ConsumedMaterialReportOutputDTO {
    public StockCardClassName: string;
    public StockCardClassCode: string;
    public Amount: number;
    public UnitePrice: number;
    public StoreName: string;
    public BudgetTypeName: string;
}
