//$2C798E11
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';

export class StockLevelTypeService {
    public static async GetStockLevelTypeList(injectionSQL: string): Promise<Array<StockLevelType.GetStockLevelTypeList_Class>> {
        let url: string = "/api/StockLevelTypeService/GetStockLevelTypeList";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockLevelType.GetStockLevelTypeList_Class>>(url, input);
        return result;
    }
    public static async GetStockLevelType(STOCKLEVELTYPESTATUS: StockLevelTypeEnum): Promise<Array<StockLevelType>> {
        let url: string = "/api/StockLevelTypeService/GetStockLevelType";
        let input = { "STOCKLEVELTYPESTATUS": STOCKLEVELTYPESTATUS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockLevelType>>(url, input);
        return result;
    }
    public static async GetStockLevelTypeDefByLastUpdate(STARTDATE: Date, ENDDATE: Date): Promise<Array<StockLevelType>> {
        let url: string = "/api/StockLevelTypeService/GetStockLevelTypeDefByLastUpdate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockLevelType>>(url, input);
        return result;
    }
}
