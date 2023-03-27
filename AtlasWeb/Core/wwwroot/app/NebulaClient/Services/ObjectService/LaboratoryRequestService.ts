//$37939EAF
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryRequest } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratorySubProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class LaboratoryRequestService {
    public static async SendToLabASync(laboratoryRequest: LaboratoryRequest): Promise<Guid> {
        let url: string = "/api/LaboratoryRequestService/SendToLabASync";
        let input = { "laboratoryRequest": laboratoryRequest };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Guid>(url, input);
        return result;
    }
    public static async RollbackCancelLabSubProcedure(labProcedure: LaboratorySubProcedure): Promise<void> {
        let url: string = "/api/LaboratoryRequestService/RollbackCancelLabSubProcedure";
        let input = { "labProcedure": labProcedure };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async CancelLabSubProcedure(labProcedure: LaboratorySubProcedure): Promise<void> {
        let url: string = "/api/LaboratoryRequestService/CancelLabSubProcedure";
        let input = { "labProcedure": labProcedure };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async RollbackCancelLabProcedure(labProcedure: LaboratoryProcedure): Promise<void> {
        let url: string = "/api/LaboratoryRequestService/RollbackCancelLabProcedure";
        let input = { "labProcedure": labProcedure };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async CancelLabProcedure(labProcedure: LaboratoryProcedure): Promise<void> {
        let url: string = "/api/LaboratoryRequestService/CancelLabProcedure";
        let input = { "labProcedure": labProcedure };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
  /*  public static async HISKabul(hisKabul: HISKabulInfo): Promise<void> {
        let url: string = "/api/LaboratoryRequestService/HISKabul";
        let input = { "hisKabul": hisKabul };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    } */
    public static async LaboratoryReportNQL(PARAMOBJID: string): Promise<Array<LaboratoryRequest.LaboratoryReportNQL_Class>> {
        let url: string = "/api/LaboratoryRequestService/LaboratoryReportNQL";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryRequest.LaboratoryReportNQL_Class>>(url, input);
        return result;
    }
    public static async GetLastTwoLaboratoryRequests(PATIENTID: Guid, MASTERRESOURCE: Guid, WORKLISTDATE: Date): Promise<Array<LaboratoryRequest.GetLastTwoLaboratoryRequests_Class>> {
        let url: string = "/api/LaboratoryRequestService/GetLastTwoLaboratoryRequests";
        let input = { "PATIENTID": PATIENTID, "MASTERRESOURCE": MASTERRESOURCE, "WORKLISTDATE": WORKLISTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryRequest.GetLastTwoLaboratoryRequests_Class>>(url, input);
        return result;
    }
    public static async GetLaboratoryRequestByBarcode(BARCODEID: number): Promise<Array<LaboratoryRequest.GetLaboratoryRequestByBarcode_Class>> {
        let url: string = "/api/LaboratoryRequestService/GetLaboratoryRequestByBarcode";
        let input = { "BARCODEID": BARCODEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryRequest.GetLaboratoryRequestByBarcode_Class>>(url, input);
        return result;
    }
    public static async LaboratoryResultsTrackingScreenNQL(injectionSQL: string): Promise<Array<LaboratoryRequest.LaboratoryResultsTrackingScreenNQL_Class>> {
        let url: string = "/api/LaboratoryRequestService/LaboratoryResultsTrackingScreenNQL";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryRequest.LaboratoryResultsTrackingScreenNQL_Class>>(url, input);
        return result;
    }
    public static async GetLaboratoryRequestByFilter(injectionSQL: string): Promise<Array<LaboratoryRequest.GetLaboratoryRequestByFilter_Class>> {
        let url: string = "/api/LaboratoryRequestService/GetLaboratoryRequestByFilter";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryRequest.GetLaboratoryRequestByFilter_Class>>(url, input);
        return result;
    }
    public static async LaboratoryTripleTestInfoNQL(PARAMOBJID: string): Promise<Array<LaboratoryRequest.LaboratoryTripleTestInfoNQL_Class>> {
        let url: string = "/api/LaboratoryRequestService/LaboratoryTripleTestInfoNQL";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryRequest.LaboratoryTripleTestInfoNQL_Class>>(url, input);
        return result;
    }
    public static async LaboratoryBinaryScanInfoNQL(PARAMOBJID: string): Promise<Array<LaboratoryRequest.LaboratoryBinaryScanInfoNQL_Class>> {
        let url: string = "/api/LaboratoryRequestService/LaboratoryBinaryScanInfoNQL";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryRequest.LaboratoryBinaryScanInfoNQL_Class>>(url, input);
        return result;
    }
}