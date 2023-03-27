//$B08D055E
import { CostAction, Material, MKYSControlEnum, DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { CostActionMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { Type } from 'NebulaClient/ClassTransformer';

export class CostActionService {
    public static async CostActionCreateTS(costAction: CostAction, dateStart: Date, dateEnd: Date): Promise<CostAction> {
        let url: string = '/api/CostActionService/CostActionCreateTS';
        let input = { "costAction": costAction, "dateStart": dateStart, "dateEnd": dateEnd };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<CostAction>(url, input);
        return result;
    }
    public static async AyIsmi(ay: number): Promise<string> {
        let url: string = '/api/CostActionService/AyIsmi';
        let input = { "ay": ay };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async GetCostActionByEndDate(STOREOBJECTID: Guid): Promise<Array<CostAction.GetCostActionByEndDate_Class>> {
        let url: string = '/api/CostActionService/GetCostActionByEndDate';
        let input = { "STOREOBJECTID": STOREOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<CostAction.GetCostActionByEndDate_Class>>(url, input);
        return result;
    }
    public static async CostActionDateCreatTS(costAction: CostAction): Promise<CostActionCreateTS_Output> {
        let url: string = '/api/CostActionService/CostActionDateCreatTS';
        let input = { "costAction": costAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<CostActionCreateTS_Output>(url, input);
        return result;
    }

    public static async StockActionData(costAction: CostAction): Promise<Array<StockActionData_Output>> {
        let url: string = '/api/CostActionService/StockActionData';
        let input = { "costAction": costAction, "storeID": costAction.Store.ObjectID.toString() };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockActionData_Output>>(url, input);
        return result;
    }

    public static async GetActiveStockAction(storeID: Guid): Promise<Array<GetActiveStockAction_Output>> {
        let url: string = '/api/CostActionService/GetActiveStockAction';
        let input = { "storeID": storeID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<GetActiveStockAction_Output>>(url, input);
        return result;
    }

}
export class CostActionCreateTS_Output {
    public dateStart: Date;
    public dateEnd: Date;
    public costActionMaterials: Array<CostActionMaterial>;
    public desctiption: string;
    public materials: Array<Material>;
    public stockActionData_Outputs: Array<StockActionData_Output>;

}
export class StockActionData_Output {
    public StockActionID: string;
    public DocumentRecordLogNumber: string;
    public Desciption: string;
    public mkysControlEnum: MKYSControlEnum;
    public StockActionObjectId: string;
    public documentTransactionType: DocumentTransactionTypeEnum;
}
export class GetActiveStockAction_Output {
    @Type(() => Guid)
    public objectID: Guid;
    @Type(() => Guid)
    public objectDefID: Guid;
    public displayText: string;
    public stockActionID: number;
}