//$EDC5827C
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { PathologyRequest } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class PathologyRequestService {
    public static async PathologyReqStateInfoNQL(PARAMPATHOBJID: string): Promise<Array<PathologyRequest.PathologyReqStateInfoNQL_Class>> {
        let url: string = "/api/PathologyRequestService/PathologyReqStateInfoNQL";
        let input = { "PARAMPATHOBJID": PARAMPATHOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PathologyRequest.PathologyReqStateInfoNQL_Class>>(url, input);
        return result;
    }
    public static async PathologyResultReportQuery(PARAMOBJID: string): Promise<Array<PathologyRequest.PathologyResultReportQuery_Class>> {
        let url: string = "/api/PathologyRequestService/PathologyResultReportQuery";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PathologyRequest.PathologyResultReportQuery_Class>>(url, input);
        return result;
    }
    public static async PathologyRequestPatientInfoReportQuery(PARAMPATOBJID: string): Promise<Array<PathologyRequest.PathologyRequestPatientInfoReportQuery_Class>> {
        let url: string = "/api/PathologyRequestService/PathologyRequestPatientInfoReportQuery";
        let input = { "PARAMPATOBJID": PARAMPATOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PathologyRequest.PathologyRequestPatientInfoReportQuery_Class>>(url, input);
        return result;
    }
    public static async PathologyRequestInfoStickerNQL(PARAMPATHOBJID: string): Promise<Array<PathologyRequest.PathologyRequestInfoStickerNQL_Class>> {
        let url: string = "/api/PathologyRequestService/PathologyRequestInfoStickerNQL";
        let input = { "PARAMPATHOBJID": PARAMPATHOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PathologyRequest.PathologyRequestInfoStickerNQL_Class>>(url, input);
        return result;
    }
    public static async PathologyResultPatientInfoReportQuery(PARAMPATOBJID: string): Promise<Array<PathologyRequest.PathologyResultPatientInfoReportQuery_Class>> {
        let url: string = "/api/PathologyRequestService/PathologyResultPatientInfoReportQuery";
        let input = { "PARAMPATOBJID": PARAMPATOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PathologyRequest.PathologyResultPatientInfoReportQuery_Class>>(url, input);
        return result;
    }
    public static async SearchPathologies(injectionSQL: string): Promise<Array<PathologyRequest.SearchPathologies_Class>> {
        let url: string = "/api/PathologyRequestService/SearchPathologies";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PathologyRequest.SearchPathologies_Class>>(url, input);
        return result;
    }
    public static async PathologyRequestBarcodeNQL(PARAMOBJID: string): Promise<Array<PathologyRequest.PathologyRequestBarcodeNQL_Class>> {
        let url: string = "/api/PathologyRequestService/PathologyRequestBarcodeNQL";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PathologyRequest.PathologyRequestBarcodeNQL_Class>>(url, input);
        return result;
    }
}