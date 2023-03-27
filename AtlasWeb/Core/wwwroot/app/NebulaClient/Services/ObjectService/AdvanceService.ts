//$F00DE4E0
import { Advance } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class AdvanceService {
    public static async AdvanceDocumentCreditCardReportQuery(PARAMADVANCEOBJID: string): Promise<Array<Advance.AdvanceDocumentCreditCardReportQuery_Class>> {
        let url: string = "/api/AdvanceService/AdvanceDocumentCreditCardReportQuery";
        let input = { "PARAMADVANCEOBJID": PARAMADVANCEOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Advance.AdvanceDocumentCreditCardReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetAdvanceDebentures(PARAMOBJID: string): Promise<Array<Advance.GetAdvanceDebentures_Class>> {
        let url: string = "/api/AdvanceService/GetAdvanceDebentures";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Advance.GetAdvanceDebentures_Class>>(url, input);
        return result;
    }
    public static async GetByEpisode(PARAMEPISODE: string, PARAMSTATE: string): Promise<Array<Advance>> {
        let url: string = "/api/AdvanceService/GetByEpisode";
        let input = { "PARAMEPISODE": PARAMEPISODE, "PARAMSTATE": PARAMSTATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Advance>>(url, input);
        return result;
    }
    public static async AdvanceDocumentCashReportQuery(PARAMADVANCEOBJID: string): Promise<Array<Advance.AdvanceDocumentCashReportQuery_Class>> {
        let url: string = "/api/AdvanceService/AdvanceDocumentCashReportQuery";
        let input = { "PARAMADVANCEOBJID": PARAMADVANCEOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Advance.AdvanceDocumentCashReportQuery_Class>>(url, input);
        return result;
    }
}