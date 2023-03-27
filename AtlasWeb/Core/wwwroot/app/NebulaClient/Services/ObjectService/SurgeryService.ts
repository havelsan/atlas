//$50AF90E5
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { Surgery } from 'NebulaClient/Model/AtlasClientModel';

export class SurgeryService {
    public static async GetSUTPointByProcedureObjectId(procedureObjId: Guid): Promise<number> {
        let url: string = '/api/SurgeryService/GetSUTPointByProcedureObjectId';
        let input = { "procedureObjId": procedureObjId };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<number>(url, input);
        return result;
    }
    public static async OLAP_GetSurgeryByDate(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<Surgery.OLAP_GetSurgeryByDate_Class>> {
        let url: string = '/api/SurgeryService/OLAP_GetSurgeryByDate';
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Surgery.OLAP_GetSurgeryByDate_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetSurgery10Day(EID: string, DEATHTIME: Date): Promise<Array<Surgery.OLAP_GetSurgery10Day_Class>> {
        let url: string = '/api/SurgeryService/OLAP_GetSurgery10Day';
        let input = { "EID": EID, "DEATHTIME": DEATHTIME };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Surgery.OLAP_GetSurgery10Day_Class>>(url, input);
        return result;
    }
    public static async SurgeryReportNQL(SURGERY: string): Promise<Array<Surgery.SurgeryReportNQL_Class>> {
        let url: string = '/api/SurgeryService/SurgeryReportNQL';
        let input = { "SURGERY": SURGERY };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Surgery.SurgeryReportNQL_Class>>(url, input);
        return result;
    }
    public static async SurgeryPatientByDateNQL(STARTDATE: Date, ENDDATE: Date, SURGERYROOM: Guid): Promise<Array<Surgery.SurgeryPatientByDateNQL_Class>> {
        let url: string = '/api/SurgeryService/SurgeryPatientByDateNQL';
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "SURGERYROOM": SURGERYROOM };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Surgery.SurgeryPatientByDateNQL_Class>>(url, input);
        return result;
    }
    public static async GetByEpisode(EPISODE: Guid): Promise<Array<Surgery>> {
        let url: string = '/api/SurgeryService/GetByEpisode';
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Surgery>>(url, input);
        return result;
    }
    public static async DirectPurchaseExpenditureInfoNQL(OBJECTID: string): Promise<Array<Surgery.DirectPurchaseExpenditureInfoNQL_Class>> {
        let url: string = '/api/SurgeryService/DirectPurchaseExpenditureInfoNQL';
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Surgery.DirectPurchaseExpenditureInfoNQL_Class>>(url, input);
        return result;
    }
    public static async SurgeryCountQuery(STARTDATE: Date, ENDDATE: Date): Promise<Array<Surgery.SurgeryCountQuery_Class>> {
        let url: string = '/api/SurgeryService/SurgeryCountQuery';
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Surgery.SurgeryCountQuery_Class>>(url, input);
        return result;
    }
    public static async InCompleteSurgeryPatientListNQL(ENDDATE: Date, STARTDATE: Date): Promise<Array<Surgery.InCompleteSurgeryPatientListNQL_Class>> {
        let url: string = '/api/SurgeryService/InCompleteSurgeryPatientListNQL';
        let input = { "ENDDATE": ENDDATE, "STARTDATE": STARTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Surgery.InCompleteSurgeryPatientListNQL_Class>>(url, input);
        return result;
    }
}