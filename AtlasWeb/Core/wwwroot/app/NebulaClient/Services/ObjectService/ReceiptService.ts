//$23415A43
import { NeHttpService } from "Fw/Services/NeHttpService";
import { Receipt } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class ReceiptService {
    public static async ReceiptReportQuery(PARAMDEBFOLOBJID: string): Promise<Array<Receipt.ReceiptReportQuery_Class>> {
        let url: string = "/api/ReceiptService/ReceiptReportQuery";
        let input = { "PARAMDEBFOLOBJID": PARAMDEBFOLOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Receipt.ReceiptReportQuery_Class>>(url, input);
        return result;
    }
    public static async EmergentPatientRecordFormQuery(PARAMDEBFOLOBJID: string): Promise<Array<Receipt.EmergentPatientRecordFormQuery_Class>> {
        let url: string = "/api/ReceiptService/EmergentPatientRecordFormQuery";
        let input = { "PARAMDEBFOLOBJID": PARAMDEBFOLOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Receipt.EmergentPatientRecordFormQuery_Class>>(url, input);
        return result;
    }
    public static async ReceiptCreditCardReportQuery(PARAMDEBFOLOBJID: string): Promise<Array<Receipt.ReceiptCreditCardReportQuery_Class>> {
        let url: string = "/api/ReceiptService/ReceiptCreditCardReportQuery";
        let input = { "PARAMDEBFOLOBJID": PARAMDEBFOLOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Receipt.ReceiptCreditCardReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetByObjectID(PARAMOBJECTID: string): Promise<Array<Receipt>> {
        let url: string = "/api/ReceiptService/GetByObjectID";
        let input = { "PARAMOBJECTID": PARAMOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Receipt>>(url, input);
        return result;
    }
    public static async ReceiptDetailsQuery(PARAMDEBFOLOBJID: string): Promise<Array<Receipt.ReceiptDetailsQuery_Class>> {
        let url: string = "/api/ReceiptService/ReceiptDetailsQuery";
        let input = { "PARAMDEBFOLOBJID": PARAMDEBFOLOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Receipt.ReceiptDetailsQuery_Class>>(url, input);
        return result;
    }
    public static async GetByEpisode(PARAMEPISODE: string, PARAMSTATE: string): Promise<Array<Receipt>> {
        let url: string = "/api/ReceiptService/GetByEpisode";
        let input = { "PARAMEPISODE": PARAMEPISODE, "PARAMSTATE": PARAMSTATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Receipt>>(url, input);
        return result;
    }
    public static async GetReceiptDebentures(PARAMOBJID: string): Promise<Array<Receipt.GetReceiptDebentures_Class>> {
        let url: string = "/api/ReceiptService/GetReceiptDebentures";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Receipt.GetReceiptDebentures_Class>>(url, input);
        return result;
    }
    public static async GetReceipts(injectionSQL: string): Promise<Array<Receipt.GetReceipts_Class>> {
        let url: string = "/api/ReceiptService/GetReceipts";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Receipt.GetReceipts_Class>>(url, input);
        return result;
    }
    public static async OrthesisToothIVFPatientParticipationReport(STARTDATE: Date, ENDDATE: Date, RESOURCEFLAG: number, RESOURCE: Array<string>): Promise<Array<Receipt.OrthesisToothIVFPatientParticipationReport_Class>> {
        let url: string = "/api/ReceiptService/OrthesisToothIVFPatientParticipationReport";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "RESOURCEFLAG": RESOURCEFLAG, "RESOURCE": RESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Receipt.OrthesisToothIVFPatientParticipationReport_Class>>(url, input);
        return result;
    }
    public static async GetForeignSgkPatientParticipationByDate(STARTDATE: Date, ENDDATE: Date, RESOURCE: Array<string>, RESOURCEFLAG: number): Promise<Array<Receipt.GetForeignSgkPatientParticipationByDate_Class>> {
        let url: string = "/api/ReceiptService/GetForeignSgkPatientParticipationByDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "RESOURCE": RESOURCE, "RESOURCEFLAG": RESOURCEFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Receipt.GetForeignSgkPatientParticipationByDate_Class>>(url, input);
        return result;
    }
    public static async GetByEpisodeStateAndDocumentNo(EPISODE: string, STATE: string, DOCUMENTNO: string): Promise<Array<Receipt>> {
        let url: string = "/api/ReceiptService/GetByEpisodeStateAndDocumentNo";
        let input = { "EPISODE": EPISODE, "STATE": STATE, "DOCUMENTNO": DOCUMENTNO };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Receipt>>(url, input);
        return result;
    }
    public static async GetByEpisodeStateAndCreditCardDocumentNo(EPISODE: string, STATE: string, DOCUMENTNO: string): Promise<Array<Receipt>> {
        let url: string = "/api/ReceiptService/GetByEpisodeStateAndCreditCardDocumentNo";
        let input = { "EPISODE": EPISODE, "STATE": STATE, "DOCUMENTNO": DOCUMENTNO };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Receipt>>(url, input);
        return result;
    }
}