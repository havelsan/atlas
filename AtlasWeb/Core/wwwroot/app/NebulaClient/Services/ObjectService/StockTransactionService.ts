//$EEE8545C
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { StockTransaction } from 'NebulaClient/Model/AtlasClientModel';

export class StockTransactionService {
    public static async GetSpendByStoreIDForMaterialRequestReportQuery(STARTDATE: Date, ENDDATE: Date, STOCKCARDID: string, STOREID: string): Promise<Array<StockTransaction.GetSpendByStoreIDForMaterialRequestReportQuery_Class>> {
        let url: string = "/api/StockTransactionService/GetSpendByStoreIDForMaterialRequestReportQuery";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "STOCKCARDID": STOCKCARDID, "STOREID": STOREID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetSpendByStoreIDForMaterialRequestReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetMonthlyConsumptionReportQuery(MATERIALID: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<StockTransaction.GetMonthlyConsumptionReportQuery_Class>> {
        let url: string = "/api/StockTransactionService/GetMonthlyConsumptionReportQuery";
        let input = { "MATERIALID": MATERIALID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetMonthlyConsumptionReportQuery_Class>>(url, input);
        return result;
    }
    public static async ConsumableStockCardQuery(STOREID: string, CLASSOBJECTID: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<StockTransaction.ConsumableStockCardQuery_Class>> {
        let url: string = "/api/StockTransactionService/ConsumableStockCardQuery";
        let input = { "STOREID": STOREID, "CLASSOBJECTID": CLASSOBJECTID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.ConsumableStockCardQuery_Class>>(url, input);
        return result;
    }
    public static async GetStockTransactionsFromStock(STOCKIDS: Array<string>): Promise<Array<StockTransaction>> {
        let url: string = "/api/StockTransactionService/GetStockTransactionsFromStock";
        let input = { "STOCKIDS": STOCKIDS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction>>(url, input);
        return result;
    }
    public static async StockTransactionReportQuery(STOREOBJECTID: string, STOCKCARDOBJECTID: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<StockTransaction.StockTransactionReportQuery_Class>> {
        let url: string = "/api/StockTransactionService/StockTransactionReportQuery";
        let input = { "STOREOBJECTID": STOREOBJECTID, "STOCKCARDOBJECTID": STOCKCARDOBJECTID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.StockTransactionReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetMaterialConsumptionAmount(STARTDATE: Date, ENDDATE: Date, MATERIALID: string): Promise<Array<StockTransaction.GetMaterialConsumptionAmount_Class>> {
        let url: string = "/api/StockTransactionService/GetMaterialConsumptionAmount";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "MATERIALID": MATERIALID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetMaterialConsumptionAmount_Class>>(url, input);
        return result;
    }
    public static async ConsumableMaterialForStoreQuery(STOREID: string, OBJECTID: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<StockTransaction.ConsumableMaterialForStoreQuery_Class>> {
        let url: string = "/api/StockTransactionService/ConsumableMaterialForStoreQuery";
        let input = { "STOREID": STOREID, "OBJECTID": OBJECTID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.ConsumableMaterialForStoreQuery_Class>>(url, input);
        return result;
    }
    public static async GetStockCardForMaterialRequestReportQuery(STARTDATE: Date, ENDDATE: Date, STOCKCARDID: string): Promise<Array<StockTransaction.GetStockCardForMaterialRequestReportQuery_Class>> {
        let url: string = "/api/StockTransactionService/GetStockCardForMaterialRequestReportQuery";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "STOCKCARDID": STOCKCARDID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetStockCardForMaterialRequestReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetStockTransactionToProductionConsumption(CHECKEDSTOCKTRANSACTIONDEFS: Array<Guid>, FIRSTDATE: Date, LASTDATE: Date, STOREID: Guid): Promise<Array<StockTransaction>> {
        let url: string = "/api/StockTransactionService/GetStockTransactionToProductionConsumption";
        let input = { "CHECKEDSTOCKTRANSACTIONDEFS": CHECKEDSTOCKTRANSACTIONDEFS, "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE, "STOREID": STOREID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction>>(url, input);
        return result;
    }
    public static async GetChequeDocumentForStatisticReportQuery(MATERIALID: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<StockTransaction.GetChequeDocumentForStatisticReportQuery_Class>> {
        let url: string = "/api/StockTransactionService/GetChequeDocumentForStatisticReportQuery";
        let input = { "MATERIALID": MATERIALID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetChequeDocumentForStatisticReportQuery_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetCancelledStockTransactions_Old(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<StockTransaction.OLAP_GetCancelledStockTransactions_Old_Class>> {
        let url: string = "/api/StockTransactionService/OLAP_GetCancelledStockTransactions_Old";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.OLAP_GetCancelledStockTransactions_Old_Class>>(url, input);
        return result;
    }
    public static async GetMainFieldsForStatisticReportQuery(MATERIALID: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<StockTransaction.GetMainFieldsForStatisticReportQuery_Class>> {
        let url: string = "/api/StockTransactionService/GetMainFieldsForStatisticReportQuery";
        let input = { "MATERIALID": MATERIALID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetMainFieldsForStatisticReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetReturningDocumentForStatisticReportQuery(MATERIALID: string, ENDDATE: Date, STARTDATE: Date): Promise<Array<StockTransaction.GetReturningDocumentForStatisticReportQuery_Class>> {
        let url: string = "/api/StockTransactionService/GetReturningDocumentForStatisticReportQuery";
        let input = { "MATERIALID": MATERIALID, "ENDDATE": ENDDATE, "STARTDATE": STARTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetReturningDocumentForStatisticReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetConsumptionDocumentForStatisticReportQuery(MATERIALID: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<StockTransaction.GetConsumptionDocumentForStatisticReportQuery_Class>> {
        let url: string = "/api/StockTransactionService/GetConsumptionDocumentForStatisticReportQuery";
        let input = { "MATERIALID": MATERIALID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetConsumptionDocumentForStatisticReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetDistributionDocumentForStatisticReportQuery(MATERIALID: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<StockTransaction.GetDistributionDocumentForStatisticReportQuery_Class>> {
        let url: string = "/api/StockTransactionService/GetDistributionDocumentForStatisticReportQuery";
        let input = { "MATERIALID": MATERIALID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetDistributionDocumentForStatisticReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetOtherDocumentsForStatisticReportQuery(MATERIALID: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<StockTransaction.GetOtherDocumentsForStatisticReportQuery_Class>> {
        let url: string = "/api/StockTransactionService/GetOtherDocumentsForStatisticReportQuery";
        let input = { "MATERIALID": MATERIALID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetOtherDocumentsForStatisticReportQuery_Class>>(url, input);
        return result;
    }
    public static async FIFOOutableStockTransactionsRQ(STOCKID: Guid, STOCKLEVELTYPEID: Guid): Promise<Array<StockTransaction.FIFOOutableStockTransactionsRQ_Class>> {
        let url: string = "/api/StockTransactionService/FIFOOutableStockTransactionsRQ";
        let input = { "STOCKID": STOCKID, "STOCKLEVELTYPEID": STOCKLEVELTYPEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.FIFOOutableStockTransactionsRQ_Class>>(url, input);
        return result;
    }
    public static async GetSpendAmountForMaterialRequestReportQuery(STARTDATE: Date, ENDDATE: Date, STOCKCARDID: string): Promise<Array<StockTransaction.GetSpendAmountForMaterialRequestReportQuery_Class>> {
        let url: string = "/api/StockTransactionService/GetSpendAmountForMaterialRequestReportQuery";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "STOCKCARDID": STOCKCARDID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetSpendAmountForMaterialRequestReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetMaterialIDQuery(STARTDATE: Date, ENDDATE: Date, PARENTCLASSID: string): Promise<Array<StockTransaction.GetMaterialIDQuery_Class>> {
        let url: string = "/api/StockTransactionService/GetMaterialIDQuery";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "PARENTCLASSID": PARENTCLASSID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetMaterialIDQuery_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetStockTransactions(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<StockTransaction.OLAP_GetStockTransactions_Class>> {
        let url: string = "/api/StockTransactionService/OLAP_GetStockTransactions";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.OLAP_GetStockTransactions_Class>>(url, input);
        return result;
    }
    public static async GetTransactionsForCardPresentationReportQuery(STOCKCARDID: Guid, STOREID: Guid, ACCOUNTINGTERM: Guid): Promise<Array<StockTransaction.GetTransactionsForCardPresentationReportQuery_Class>> {
        let url: string = "/api/StockTransactionService/GetTransactionsForCardPresentationReportQuery";
        let input = { "STOCKCARDID": STOCKCARDID, "STOREID": STOREID, "ACCOUNTINGTERM": ACCOUNTINGTERM };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetTransactionsForCardPresentationReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetTransactionRestAmountRQ(TRXOBJECTID: Guid): Promise<Array<StockTransaction.GetTransactionRestAmountRQ_Class>> {
        let url: string = "/api/StockTransactionService/GetTransactionRestAmountRQ";
        let input = { "TRXOBJECTID": TRXOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetTransactionRestAmountRQ_Class>>(url, input);
        return result;
    }
    public static async LIFOOutableStockTransactionsRQ(STOCKID: Guid, STOCKLEVELTYPEID: Guid): Promise<Array<StockTransaction.LIFOOutableStockTransactionsRQ_Class>> {
        let url: string = "/api/StockTransactionService/LIFOOutableStockTransactionsRQ";
        let input = { "STOCKID": STOCKID, "STOCKLEVELTYPEID": STOCKLEVELTYPEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.LIFOOutableStockTransactionsRQ_Class>>(url, input);
        return result;
    }
    public static async GetCompletedOUTStockTransactionsByStockActionDet(STOCKACTIONDETAILID: Guid, injectionSQL: string): Promise<Array<StockTransaction>> {
        let url: string = "/api/StockTransactionService/GetCompletedOUTStockTransactionsByStockActionDet";
        let input = { "STOCKACTIONDETAILID": STOCKACTIONDETAILID, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction>>(url, input);
        return result;
    }
    public static async GetCompletedINStockTransactionsByStockActionDet(STOCKACTIONDETAILID: Guid, injectionSQL: string): Promise<Array<StockTransaction>> {
        let url: string = "/api/StockTransactionService/GetCompletedINStockTransactionsByStockActionDet";
        let input = { "STOCKACTIONDETAILID": STOCKACTIONDETAILID, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction>>(url, input);
        return result;
    }
    public static async GetCompletedStockTransactions(STOCKID: Guid, injectionSQL: string): Promise<Array<StockTransaction>> {
        let url: string = "/api/StockTransactionService/GetCompletedStockTransactions";
        let input = { "STOCKID": STOCKID, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction>>(url, input);
        return result;
    }
    public static async GetCompletedOUTStockTransactions(STOCKID: Guid, injectionSQL: string): Promise<Array<StockTransaction>> {
        let url: string = "/api/StockTransactionService/GetCompletedOUTStockTransactions";
        let input = { "STOCKID": STOCKID, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction>>(url, input);
        return result;
    }
    public static async GetCompletedINStockTransactions(STOCKID: Guid, injectionSQL: string): Promise<Array<StockTransaction>> {
        let url: string = "/api/StockTransactionService/GetCompletedINStockTransactions";
        let input = { "STOCKID": STOCKID, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction>>(url, input);
        return result;
    }
    public static async RestFIFOStockTransactionsRQ(STOCKID: Guid): Promise<Array<StockTransaction.RestFIFOStockTransactionsRQ_Class>> {
        let url: string = "/api/StockTransactionService/RestFIFOStockTransactionsRQ";
        let input = { "STOCKID": STOCKID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.RestFIFOStockTransactionsRQ_Class>>(url, input);
        return result;
    }
    public static async RestLIFOStockTransactionsRQ(STOCKID: Guid): Promise<Array<StockTransaction.RestLIFOStockTransactionsRQ_Class>> {
        let url: string = "/api/StockTransactionService/RestLIFOStockTransactionsRQ";
        let input = { "STOCKID": STOCKID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.RestLIFOStockTransactionsRQ_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetCancelledStockTransactions(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<StockTransaction.OLAP_GetCancelledStockTransactions_Class>> {
        let url: string = "/api/StockTransactionService/OLAP_GetCancelledStockTransactions";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.OLAP_GetCancelledStockTransactions_Class>>(url, input);
        return result;
    }
    public static async ExpirationDateApproachingQuery(STOREID: Guid, EXPIRATIONDATE: Date): Promise<Array<StockTransaction.ExpirationDateApproachingQuery_Class>> {
        let url: string = "/api/StockTransactionService/ExpirationDateApproachingQuery";
        let input = { "STOREID": STOREID, "EXPIRATIONDATE": EXPIRATIONDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.ExpirationDateApproachingQuery_Class>>(url, input);
        return result;
    }
    public static async GetStockTransactionsByAccountingTerm(TERM: Guid, CARDDRAWER: Guid): Promise<Array<StockTransaction>> {
        let url: string = "/api/StockTransactionService/GetStockTransactionsByAccountingTerm";
        let input = { "TERM": TERM, "CARDDRAWER": CARDDRAWER };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction>>(url, input);
        return result;
    }
    public static async GetMaterialExpirationScheduleReportQuery(STOREID: Guid, STARTDATE: Date, ENDDATE: Date, CLASSID: Guid): Promise<Array<StockTransaction.GetMaterialExpirationScheduleReportQuery_Class>> {
        let url: string = "/api/StockTransactionService/GetMaterialExpirationScheduleReportQuery";
        let input = { "STOREID": STOREID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "CLASSID": CLASSID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetMaterialExpirationScheduleReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetStockTransactionsByStockAccountingTerm(STOCKID: Guid, ACCOUNTINGTERMID: Guid): Promise<Array<StockTransaction>> {
        let url: string = "/api/StockTransactionService/GetStockTransactionsByStockAccountingTerm";
        let input = { "STOCKID": STOCKID, "ACCOUNTINGTERMID": ACCOUNTINGTERMID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction>>(url, input);
        return result;
    }
    public static async GetStockTransactionsWithCollectedTRXRQ(STOREID: Guid, CHECKEDSTOCKTRANSACTIONDEFS: Array<Guid>): Promise<Array<StockTransaction.GetStockTransactionsWithCollectedTRXRQ_Class>> {
        let url: string = "/api/StockTransactionService/GetStockTransactionsWithCollectedTRXRQ";
        let input = { "STOREID": STOREID, "CHECKEDSTOCKTRANSACTIONDEFS": CHECKEDSTOCKTRANSACTIONDEFS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetStockTransactionsWithCollectedTRXRQ_Class>>(url, input);
        return result;
    }
    public static async LIFOLotOutableStockTransactionsRQ(LOTNO: Array<string>, STOCKID: Guid, STOCKLEVELTYPEID: Guid): Promise<Array<StockTransaction.LIFOLotOutableStockTransactionsRQ_Class>> {
        let url: string = "/api/StockTransactionService/LIFOLotOutableStockTransactionsRQ";
        let input = { "LOTNO": LOTNO, "STOCKID": STOCKID, "STOCKLEVELTYPEID": STOCKLEVELTYPEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.LIFOLotOutableStockTransactionsRQ_Class>>(url, input);
        return result;
    }
    public static async LIFOExpirationOutableStockTransactionsRQ(EXPIRATIONDATE: Array<Date>, STOCKID: Guid, STOCKLEVELTYPEID: Guid, INCLUDENULL: number): Promise<Array<StockTransaction.LIFOExpirationOutableStockTransactionsRQ_Class>> {
        let url: string = "/api/StockTransactionService/LIFOExpirationOutableStockTransactionsRQ";
        let input = { "EXPIRATIONDATE": EXPIRATIONDATE, "STOCKID": STOCKID, "STOCKLEVELTYPEID": STOCKLEVELTYPEID, "INCLUDENULL": INCLUDENULL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.LIFOExpirationOutableStockTransactionsRQ_Class>>(url, input);
        return result;
    }
    public static async GetCompletedStockTransactionsByTerm(STOCKID: Guid, ACCOUNTINGTERMID: Guid, injectionSQL: string): Promise<Array<StockTransaction>> {
        let url: string = "/api/StockTransactionService/GetCompletedStockTransactionsByTerm";
        let input = { "STOCKID": STOCKID, "ACCOUNTINGTERMID": ACCOUNTINGTERMID, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction>>(url, input);
        return result;
    }
    public static async UnitePriceOfZero(STOREID: string): Promise<Array<StockTransaction.UnitePriceOfZero_Class>> {
        let url: string = "/api/StockTransactionService/UnitePriceOfZero";
        let input = { "STOREID": STOREID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.UnitePriceOfZero_Class>>(url, input);
        return result;
    }
    public static async GetE1ReportQuery2(STOREID: Guid, BEGINDATE: string, ENDDATE: string): Promise<Array<StockTransaction.GetE1ReportQuery2_Class>> {
        let url: string = "/api/StockTransactionService/GetE1ReportQuery2";
        let input = { "STOREID": STOREID, "BEGINDATE": BEGINDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetE1ReportQuery2_Class>>(url, input);
        return result;
    }
    public static async LOTOutableStockTransactions(STOCKID: Guid): Promise<Array<StockTransaction.LOTOutableStockTransactions_Class>> {
        let url: string = "/api/StockTransactionService/LOTOutableStockTransactions";
        let input = { "STOCKID": STOCKID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.LOTOutableStockTransactions_Class>>(url, input);
        return result;
    }
    public static async LOTOutableStockTransactionsWithZeroPrice(STOCKID: Guid): Promise<Array<StockTransaction.LOTOutableStockTransactionsWithZeroPrice_Class>> {
        let url: string = "/api/StockTransactionService/LOTOutableStockTransactionsWithZeroPrice";
        let input = { "STOCKID": STOCKID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.LOTOutableStockTransactionsWithZeroPrice_Class>>(url, input);
        return result;
    }
    public static async MaterialLotDetailRQ(STOREID: Guid, STOCKCARDID: Guid): Promise<Array<StockTransaction.MaterialLotDetailRQ_Class>> {
        let url: string = "/api/StockTransactionService/MaterialLotDetailRQ";
        let input = { "STOREID": STOREID, "STOCKCARDID": STOCKCARDID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.MaterialLotDetailRQ_Class>>(url, input);
        return result;
    }
    public static async FIFOLotOutableStockTransactionsRQ(STOCKID: Guid, STOCKLEVELTYPEID: Guid, LOTNO: Array<string>): Promise<Array<StockTransaction.FIFOLotOutableStockTransactionsRQ_Class>> {
        let url: string = "/api/StockTransactionService/FIFOLotOutableStockTransactionsRQ";
        let input = { "STOCKID": STOCKID, "STOCKLEVELTYPEID": STOCKLEVELTYPEID, "LOTNO": LOTNO };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.FIFOLotOutableStockTransactionsRQ_Class>>(url, input);
        return result;
    }
    public static async GetDocumentSavingRegisterIncompletedReportQuery(STARTDATE: Date, ENDDATE: Date, STOREID: Guid): Promise<Array<StockTransaction.GetDocumentSavingRegisterIncompletedReportQuery_Class>> {
        let url: string = "/api/StockTransactionService/GetDocumentSavingRegisterIncompletedReportQuery";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "STOREID": STOREID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetDocumentSavingRegisterIncompletedReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetE1ReportQuery(DATE: Date, STOREID: Guid): Promise<Array<StockTransaction.GetE1ReportQuery_Class>> {
        let url: string = "/api/StockTransactionService/GetE1ReportQuery";
        let input = { "DATE": DATE, "STOREID": STOREID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetE1ReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetTotalConsumptionAmountForAllStore(ALLCARDDRAWER: number, ALLMATERIAL: number, CARDDRAWER: Guid, ENDDATE: Date, MATERIAL: Guid, STARTDATE: Date): Promise<Array<StockTransaction.GetTotalConsumptionAmountForAllStore_Class>> {
        let url: string = "/api/StockTransactionService/GetTotalConsumptionAmountForAllStore";
        let input = { "ALLCARDDRAWER": ALLCARDDRAWER, "ALLMATERIAL": ALLMATERIAL, "CARDDRAWER": CARDDRAWER, "ENDDATE": ENDDATE, "MATERIAL": MATERIAL, "STARTDATE": STARTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetTotalConsumptionAmountForAllStore_Class>>(url, input);
        return result;
    }
    public static async GetCompletedOUTStockTransactionbyDate(STOCKID: Guid, STARTDATE: string, ENDDATE: string, injectionSQL: string): Promise<Array<StockTransaction>> {
        let url: string = "/api/StockTransactionService/GetCompletedOUTStockTransactionbyDate";
        let input = { "STOCKID": STOCKID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction>>(url, input);
        return result;
    }
    public static async FIFOExpirationOutableStockTransactionsRQ(STOCKID: Guid, STOCKLEVELTYPEID: Guid, EXPIRATIONDATE: Array<Date>, INCLUDENULL: number): Promise<Array<StockTransaction.FIFOExpirationOutableStockTransactionsRQ_Class>> {
        let url: string = "/api/StockTransactionService/FIFOExpirationOutableStockTransactionsRQ";
        let input = { "STOCKID": STOCKID, "STOCKLEVELTYPEID": STOCKLEVELTYPEID, "EXPIRATIONDATE": EXPIRATIONDATE, "INCLUDENULL": INCLUDENULL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.FIFOExpirationOutableStockTransactionsRQ_Class>>(url, input);
        return result;
    }
    public static async GetTransactionsForCensus_InventoryAccountReport(ACCOUNTINGTERM: string, STOCKCARDID: string, STOREID: string): Promise<Array<StockTransaction.GetTransactionsForCensus_InventoryAccountReport_Class>> {
        let url: string = "/api/StockTransactionService/GetTransactionsForCensus_InventoryAccountReport";
        let input = { "ACCOUNTINGTERM": ACCOUNTINGTERM, "STOCKCARDID": STOCKCARDID, "STOREID": STOREID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetTransactionsForCensus_InventoryAccountReport_Class>>(url, input);
        return result;
    }
    public static async LOTOutableStockTransactionsWithPrice(STOCKID: Guid): Promise<Array<StockTransaction.LOTOutableStockTransactionsWithPrice_Class>> {
        let url: string = "/api/StockTransactionService/LOTOutableStockTransactionsWithPrice";
        let input = { "STOCKID": STOCKID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.LOTOutableStockTransactionsWithPrice_Class>>(url, input);
        return result;
    }
    public static async GetMinTransactionDate(STOCKID: Guid): Promise<Array<StockTransaction.GetMinTransactionDate_Class>> {
        let url: string = "/api/StockTransactionService/GetMinTransactionDate";
        let input = { "STOCKID": STOCKID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetMinTransactionDate_Class>>(url, input);
        return result;
    }
    public static async GetTotalConsumptionAmountByTransactionDate(STARTDATE: Date, ENDDATE: Date, STORE: Guid, CARDDRAWER: Guid, ALLCARDDRAWER: number, MATERIAL: Guid, ALLMATERIAL: number): Promise<Array<StockTransaction.GetTotalConsumptionAmountByTransactionDate_Class>> {
        let url: string = "/api/StockTransactionService/GetTotalConsumptionAmountByTransactionDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "STORE": STORE, "CARDDRAWER": CARDDRAWER, "ALLCARDDRAWER": ALLCARDDRAWER, "MATERIAL": MATERIAL, "ALLMATERIAL": ALLMATERIAL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.GetTotalConsumptionAmountByTransactionDate_Class>>(url, input);
        return result;
    }
    public static async VEM_STOK_HAREKET(): Promise<Array<StockTransaction.VEM_STOK_HAREKET_Class>> {
        let url: string = "/api/StockTransactionService/VEM_STOK_HAREKET";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockTransaction.VEM_STOK_HAREKET_Class>>(url, input);
        return result;
    }
}