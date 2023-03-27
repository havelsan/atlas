//$21CF78DD
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { Stock } from 'NebulaClient/Model/AtlasClientModel';

export class StockService {
    public static async GetTotalInHeldByYear(STOREID: string, YEAR: number, STOCKCARDOBJECTID: string, STOCKCARDCLASSOBJECTID: string): Promise<Array<Stock.GetTotalInHeldByYear_Class>> {
        let url: string = "/api/StockService/GetTotalInHeldByYear";
        let input = { "STOREID": STOREID, "YEAR": YEAR, "STOCKCARDOBJECTID": STOCKCARDOBJECTID, "STOCKCARDCLASSOBJECTID": STOCKCARDCLASSOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.GetTotalInHeldByYear_Class>>(url, input);
        return result;
    }
    public static async GetStockForStore(STOREID: string): Promise<Array<Stock.GetStockForStore_Class>> {
        let url: string = "/api/StockService/GetStockForStore";
        let input = { "STOREID": STOREID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.GetStockForStore_Class>>(url, input);
        return result;
    }
    public static async SearchStocks(injectionSQL: string): Promise<Array<Stock.SearchStocks_Class>> {
        let url: string = "/api/StockService/SearchStocks";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.SearchStocks_Class>>(url, input);
        return result;
    }
    public static async GetStockForStockCard(STOREOBJECTID: string): Promise<Array<Stock.GetStockForStockCard_Class>> {
        let url: string = "/api/StockService/GetStockForStockCard";
        let input = { "STOREOBJECTID": STOREOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.GetStockForStockCard_Class>>(url, input);
        return result;
    }
    public static async GetStoreMaterial(STORE: Guid, MATERIAL: Guid): Promise<Array<Stock>> {
        let url: string = "/api/StockService/GetStoreMaterial";
        let input = { "STORE": STORE, "MATERIAL": MATERIAL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock>>(url, input);
        return result;
    }
    public static async MinMaxForStockCardQuery(): Promise<Array<Stock.MinMaxForStockCardQuery_Class>> {
        let url: string = "/api/StockService/MinMaxForStockCardQuery";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.MinMaxForStockCardQuery_Class>>(url, input);
        return result;
    }
    public static async GetStockDefinitions(injectionSQL: string): Promise<Array<Stock.GetStockDefinitions_Class>> {
        let url: string = "/api/StockService/GetStockDefinitions";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.GetStockDefinitions_Class>>(url, input);
        return result;
    }
    public static async GetCensusOrderStocks(STOREID: Guid, CARDDRAWERID: Guid, injectionSQL: string): Promise<Array<Stock>> {
        let url: string = "/api/StockService/GetCensusOrderStocks";
        let input = { "STOREID": STOREID, "CARDDRAWERID": CARDDRAWERID, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock>>(url, input);
        return result;
    }
    public static async GetTotalInOutStockByYear(STOCKCARDCLASSOBJECTID: Guid, STOREID: Guid, ACCOUNTINGTERM: Guid): Promise<Array<Stock.GetTotalInOutStockByYear_Class>> {
        let url: string = "/api/StockService/GetTotalInOutStockByYear";
        let input = { "STOCKCARDCLASSOBJECTID": STOCKCARDCLASSOBJECTID, "STOREID": STOREID, "ACCOUNTINGTERM": ACCOUNTINGTERM };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.GetTotalInOutStockByYear_Class>>(url, input);
        return result;
    }
    public static async GetStock(MATERIAL: string): Promise<Array<Stock>> {
        let url: string = "/api/StockService/GetStock";
        let input = { "MATERIAL": MATERIAL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock>>(url, input);
        return result;
    }
    public static async GetTotalInOutStock(STOREID: string, STOCKCARDCLASSOBJECTID: string): Promise<Array<Stock.GetTotalInOutStock_Class>> {
        let url: string = "/api/StockService/GetTotalInOutStock";
        let input = { "STOREID": STOREID, "STOCKCARDCLASSOBJECTID": STOCKCARDCLASSOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.GetTotalInOutStock_Class>>(url, input);
        return result;
    }
    public static async GetStockForStoreStockCard(STORE: string): Promise<Array<Stock>> {
        let url: string = "/api/StockService/GetStockForStoreStockCard";
        let input = { "STORE": STORE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock>>(url, input);
        return result;
    }
    public static async GetStockByStockCardClass(STORE: string, CLASSES: Array<string>): Promise<Array<Stock>> {
        let url: string = "/api/StockService/GetStockByStockCardClass";
        let input = { "STORE": STORE, "CLASSES": CLASSES };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock>>(url, input);
        return result;
    }
    public static async GetStockFromStoreAndMaterial(MATERIAL: Guid, STORE: Guid): Promise<Array<Stock.GetStockFromStoreAndMaterial_Class>> {
        let url: string = "/api/StockService/GetStockFromStoreAndMaterial";
        let input = { "MATERIAL": MATERIAL, "STORE": STORE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.GetStockFromStoreAndMaterial_Class>>(url, input);
        return result;
    }
    public static async GetStockByCardDrawer(STORE: string, CARDDRAWER: string): Promise<Array<Stock>> {
        let url: string = "/api/StockService/GetStockByCardDrawer";
        let input = { "STORE": STORE, "CARDDRAWER": CARDDRAWER };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock>>(url, input);
        return result;
    }
    public static async GetStockForStoreByTree(STOREID: string, MATERIALTREE: string): Promise<Array<Stock.GetStockForStoreByTree_Class>> {
        let url: string = "/api/StockService/GetStockForStoreByTree";
        let input = { "STOREID": STOREID, "MATERIALTREE": MATERIALTREE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.GetStockForStoreByTree_Class>>(url, input);
        return result;
    }
    public static async GetStockForStoreByCardDrawer(STOREID: Guid, CARDDRAWERID: Guid, INCLUDEZEROAMOUNTS: boolean): Promise<Array<Stock.GetStockForStoreByCardDrawer_Class>> {
        let url: string = "/api/StockService/GetStockForStoreByCardDrawer";
        let input = { "STOREID": STOREID, "CARDDRAWERID": CARDDRAWERID, "INCLUDEZEROAMOUNTS": INCLUDEZEROAMOUNTS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.GetStockForStoreByCardDrawer_Class>>(url, input);
        return result;
    }
    public static async GetStockForStoreByCardDrawerGMDNGroup(CARDDRAWERID: Guid, INCLUDEZEROAMOUNTS: boolean, STOREID: Guid): Promise<Array<Stock.GetStockForStoreByCardDrawerGMDNGroup_Class>> {
        let url: string = "/api/StockService/GetStockForStoreByCardDrawerGMDNGroup";
        let input = { "CARDDRAWERID": CARDDRAWERID, "INCLUDEZEROAMOUNTS": INCLUDEZEROAMOUNTS, "STOREID": STOREID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.GetStockForStoreByCardDrawerGMDNGroup_Class>>(url, input);
        return result;
    }
    public static async GetStockForStoreByCardDrawerNSNGroup(CARDDRAWERID: Guid, INCLUDEZEROAMOUNTS: boolean, STOREID: Guid): Promise<Array<Stock.GetStockForStoreByCardDrawerNSNGroup_Class>> {
        let url: string = "/api/StockService/GetStockForStoreByCardDrawerNSNGroup";
        let input = { "CARDDRAWERID": CARDDRAWERID, "INCLUDEZEROAMOUNTS": INCLUDEZEROAMOUNTS, "STOREID": STOREID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.GetStockForStoreByCardDrawerNSNGroup_Class>>(url, input);
        return result;
    }
    public static async GetCensusOrderStocksByStore(STOREID: Guid, injectionSQL: string): Promise<Array<Stock>> {
        let url: string = "/api/StockService/GetCensusOrderStocksByStore";
        let input = { "STOREID": STOREID, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock>>(url, input);
        return result;
    }
    public static async UnitePriceOfReportQueryNew(STOREID: string, MATERIAL: Guid, MATERIALFLAG: number): Promise<Array<Stock.UnitePriceOfReportQueryNew_Class>> {
        let url: string = "/api/StockService/UnitePriceOfReportQueryNew";
        let input = { "STOREID": STOREID, "MATERIAL": MATERIAL, "MATERIALFLAG": MATERIALFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.UnitePriceOfReportQueryNew_Class>>(url, input);
        return result;
    }
    public static async GetStockByCardDrawerForZeroCensus(CARDDRAWER: string, STORE: string): Promise<Array<Stock>> {
        let url: string = "/api/StockService/GetStockByCardDrawerForZeroCensus";
        let input = { "CARDDRAWER": CARDDRAWER, "STORE": STORE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock>>(url, input);
        return result;
    }
    public static async GetStockForStoreByCardDrawerWithLevel(CARDDRAWERID: Guid, STOREID: Guid): Promise<Array<Stock.GetStockForStoreByCardDrawerWithLevel_Class>> {
        let url: string = "/api/StockService/GetStockForStoreByCardDrawerWithLevel";
        let input = { "CARDDRAWERID": CARDDRAWERID, "STOREID": STOREID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.GetStockForStoreByCardDrawerWithLevel_Class>>(url, input);
        return result;
    }
    public static async NoMatchOldMaterailQuery(STORE: Guid, ALL: string): Promise<Array<Stock.NoMatchOldMaterailQuery_Class>> {
        let url: string = "/api/StockService/NoMatchOldMaterailQuery";
        let input = { "STORE": STORE, "ALL": ALL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.NoMatchOldMaterailQuery_Class>>(url, input);
        return result;
    }
    public static async GetMaterialDistributeReportQuery(MATERIAL: Guid, ALL: number): Promise<Array<Stock.GetMaterialDistributeReportQuery_Class>> {
        let url: string = "/api/StockService/GetMaterialDistributeReportQuery";
        let input = { "MATERIAL": MATERIAL, "ALL": ALL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.GetMaterialDistributeReportQuery_Class>>(url, input);
        return result;
    }
    public static async VEM_STOK_DURUM(): Promise<Array<Stock.VEM_STOK_DURUM_Class>> {
        let url: string = "/api/StockService/VEM_STOK_DURUM";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Stock.VEM_STOK_DURUM_Class>>(url, input);
        return result;
    }
}