import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { DrugUsageTypeEnum } from "app/NebulaClient/Model/AtlasClientModel";

export class StoreInheldReportViewModel extends BaseViewModel {

}

export class StockInheldInputDTO {
    public storeIDList: Array<string>;
    public materialID: Guid;
    public budgettypeID: Guid;
}

export class StockInheld {
    public MaterialName: string;
    public Barcode: string;
    public StockCardNo: string;
    public Inheld: number;
    public StoreName: string;
    public BudgetTypeName: string;
    public DistributionType: string;
}
