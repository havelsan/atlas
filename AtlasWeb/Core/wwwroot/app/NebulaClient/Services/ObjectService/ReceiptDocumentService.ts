//$2B4E9933
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { PatientPaymentDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ReceiptDocument } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class ReceiptDocumentService {
    public static async GetPatientPaymentDetail(accTrxGuid: Guid, receiptDoc: ReceiptDocument): Promise<PatientPaymentDetail> {
        let url: string = "/api/ReceiptDocumentService/GetPatientPaymentDetail";
        let input = { "accTrxGuid": accTrxGuid, "receiptDoc": receiptDoc };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<PatientPaymentDetail>(url, input);
        return result;
    }
    public static async OLAP_GetCancelledReceiptDocument(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<ReceiptDocument.OLAP_GetCancelledReceiptDocument_Class>> {
        let url: string = "/api/ReceiptDocumentService/OLAP_GetCancelledReceiptDocument";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ReceiptDocument.OLAP_GetCancelledReceiptDocument_Class>>(url, input);
        return result;
    }
    public static async GetReceiptDocument(ROBJECTID: string): Promise<Array<ReceiptDocument.GetReceiptDocument_Class>> {
        let url: string = "/api/ReceiptDocumentService/GetReceiptDocument";
        let input = { "ROBJECTID": ROBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ReceiptDocument.GetReceiptDocument_Class>>(url, input);
        return result;
    }
    public static async GetByDocumentNoAndState(PARAMDOCNO: string, PARAMSTATE: string, PARAMEPISODE: string): Promise<Array<ReceiptDocument>> {
        let url: string = "/api/ReceiptDocumentService/GetByDocumentNoAndState";
        let input = { "PARAMDOCNO": PARAMDOCNO, "PARAMSTATE": PARAMSTATE, "PARAMEPISODE": PARAMEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ReceiptDocument>>(url, input);
        return result;
    }
    public static async OLAP_GetReceiptDocument(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<ReceiptDocument.OLAP_GetReceiptDocument_Class>> {
        let url: string = "/api/ReceiptDocumentService/OLAP_GetReceiptDocument";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ReceiptDocument.OLAP_GetReceiptDocument_Class>>(url, input);
        return result;
    }
    public static async GetByCreditCardDocumentNoAndState(PARAMDOCNO: string, PARAMSTATE: string, PARAMEPISODE: string): Promise<Array<ReceiptDocument>> {
        let url: string = "/api/ReceiptDocumentService/GetByCreditCardDocumentNoAndState";
        let input = { "PARAMDOCNO": PARAMDOCNO, "PARAMSTATE": PARAMSTATE, "PARAMEPISODE": PARAMEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ReceiptDocument>>(url, input);
        return result;
    }
}