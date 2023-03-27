//$80F44719
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { StockLevelTypeEnum, StockLevelType } from "app/NebulaClient/Model/AtlasClientModel";

export class StockLevelService {
    public static async StockInheld(materialID: Guid, storeID: Guid): Promise<number> {
        let url: string = "/api/StockLevelService/StockInheld";
        let input = { "materialID": materialID, "storeID": storeID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<number>(url, input);
        return result;
    }
    public static async StockInheldWithStockLevel(materialID: Guid, storeID: Guid, stockLevelTypeID: Guid): Promise<number> {
        let url: string = "/api/StockLevelService/StockInheldWithStockLevel";
        let input = { "materialID": materialID, "storeID": storeID, "stockLevelTypeID": stockLevelTypeID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<number>(url, input);
        return result;
    }
    public static async StockInheldWithStockLevelByBudgetType(materialID: Guid, storeID: Guid, stockLevelTypeID: Guid, destinationStoreID: Guid): Promise<number> {
        let url: string = "/api/StockLevelService/StockInheldWithStockLevelByBudgetType";
        let input = { "materialID": materialID, "storeID": storeID, "stockLevelTypeID": stockLevelTypeID, "destinationStoreID": destinationStoreID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<number>(url, input);
        return result;
    }
    public static async GetStockValues(materialID: Guid, storeID: Guid, stockLevelType: StockLevelTypeEnum, destinationStoreID: Guid): Promise<GetStockValues_Output> {
        let url: string = "/api/StockLevelService/GetStockValues";
        let input = { "materialID": materialID, "storeID": storeID, "stockLevelType": stockLevelType, "destinationStoreID": destinationStoreID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<GetStockValues_Output>(url, input);
        return result;
    }
}
export class GetStockValues_Output{
    public StockLevelType:StockLevelType;
    public StoreStock:number;
    public DestinationStoreStock:number;
    public DestinationStoreMaxLevel:number;
}