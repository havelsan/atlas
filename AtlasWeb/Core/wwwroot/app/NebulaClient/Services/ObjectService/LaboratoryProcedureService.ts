//$C4F619FE
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class LaboratoryProcedureService {
    //public static async MicrobiologyTestOrder(testOrderInfo: MicrobiologyTestOrderInfo): Promise<void> {
    //    let url: string = "/api/LaboratoryProcedureService/MicrobiologyTestOrder";
    //    let input = { "testOrderInfo": testOrderInfo };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<void>(url, input);
    //}
    public static async CompleteLaboratoryRequest(episodeActionID: Guid): Promise<void> {
        let url: string = "/api/LaboratoryProcedureService/CompleteLaboratoryRequest";
        let input = { "episodeActionID": episodeActionID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async UpdateEpisodeStateToOpen(episodeActionID: Guid): Promise<void> {
        let url: string = "/api/LaboratoryProcedureService/UpdateEpisodeStateToOpen";
        let input = { "episodeActionID": episodeActionID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async UpdateEpisodeToOldState(episodeActionID: Guid): Promise<void> {
        let url: string = "/api/LaboratoryProcedureService/UpdateEpisodeToOldState";
        let input = { "episodeActionID": episodeActionID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    //public static async SaveLabResult(labResult: LabResultInfo): Promise<void> {
    //    let url: string = "/api/LaboratoryProcedureService/SaveLabResult";
    //    let input = { "labResult": labResult };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<void>(url, input);
    //}
    //public static async SaveLabState(labState: LabStateInfo): Promise<void> {
    //    let url: string = "/api/LaboratoryProcedureService/SaveLabState";
    //    let input = { "labState": labState };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<void>(url, input);
    //}
    public static async GetLabTestsByPatientByDate(PATIENTID: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<LaboratoryProcedure>> {
        let url: string = "/api/LaboratoryProcedureService/GetLabTestsByPatientByDate";
        let input = { "PATIENTID": PATIENTID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure>>(url, input);
        return result;
    }
    public static async OLAP_GetLabProcedure(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<LaboratoryProcedure.OLAP_GetLabProcedure_Class>> {
        let url: string = "/api/LaboratoryProcedureService/OLAP_GetLabProcedure";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure.OLAP_GetLabProcedure_Class>>(url, input);
        return result;
    }
    public static async GetLabTestByPatient(PATIENTID: string): Promise<Array<LaboratoryProcedure>> {
        let url: string = "/api/LaboratoryProcedureService/GetLabTestByPatient";
        let input = { "PATIENTID": PATIENTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure>>(url, input);
        return result;
    }
    public static async GetLabTestByPatientByTestByDate(PATIENTID: string, TESTID: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<LaboratoryProcedure>> {
        let url: string = "/api/LaboratoryProcedureService/GetLabTestByPatientByTestByDate";
        let input = { "PATIENTID": PATIENTID, "TESTID": TESTID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure>>(url, input);
        return result;
    }
    public static async LaboratoryProcedureReportNQL(PARAMOBJID: string): Promise<Array<LaboratoryProcedure.LaboratoryProcedureReportNQL_Class>> {
        let url: string = "/api/LaboratoryProcedureService/LaboratoryProcedureReportNQL";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure.LaboratoryProcedureReportNQL_Class>>(url, input);
        return result;
    }
    public static async GetLaboratoryProcedureForLaboratoryAccept(): Promise<Array<LaboratoryProcedure>> {
        let url: string = "/api/LaboratoryProcedureService/GetLaboratoryProcedureForLaboratoryAccept";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure>>(url, input);
        return result;
    }
    public static async GetLabProcedureByBarcodeId(BARCODEID: number): Promise<Array<LaboratoryProcedure.GetLabProcedureByBarcodeId_Class>> {
        let url: string = "/api/LaboratoryProcedureService/GetLabProcedureByBarcodeId";
        let input = { "BARCODEID": BARCODEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure.GetLabProcedureByBarcodeId_Class>>(url, input);
        return result;
    }
    public static async GetLabResults(injectionSQL: string): Promise<Array<LaboratoryProcedure>> {
        let url: string = "/api/LaboratoryProcedureService/GetLabResults";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure>>(url, input);
        return result;
    }
    public static async OLAP_GetCancelledLabProcedure(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<LaboratoryProcedure.OLAP_GetCancelledLabProcedure_Class>> {
        let url: string = "/api/LaboratoryProcedureService/OLAP_GetCancelledLabProcedure";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure.OLAP_GetCancelledLabProcedure_Class>>(url, input);
        return result;
    }
    public static async GetLaboratoryResultsBySubepisodeId(SUBEPISODE: string): Promise<Array<LaboratoryProcedure.GetLaboratoryResultsBySubepisodeId_Class>> {
        let url: string = "/api/LaboratoryProcedureService/GetLaboratoryResultsBySubepisodeId";
        let input = { "SUBEPISODE": SUBEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure.GetLaboratoryResultsBySubepisodeId_Class>>(url, input);
        return result;
    }
    public static async GetLaboratoryProcedureByEpisode(EPISODE: Guid): Promise<Array<LaboratoryProcedure.GetLaboratoryProcedureByEpisode_Class>> {
        let url: string = "/api/LaboratoryProcedureService/GetLaboratoryProcedureByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure.GetLaboratoryProcedureByEpisode_Class>>(url, input);
        return result;
    }
    public static async GetLabProcByPatientByTestByDate(PATIENTID: string, TESTID: string, STARTDATE: Date, ENDDATE: Date, injectionSQL: string): Promise<Array<LaboratoryProcedure.GetLabProcByPatientByTestByDate_Class>> {
        let url: string = "/api/LaboratoryProcedureService/GetLabProcByPatientByTestByDate";
        let input = { "PATIENTID": PATIENTID, "TESTID": TESTID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure.GetLabProcByPatientByTestByDate_Class>>(url, input);
        return result;
    }
    public static async GetLabProceduresBySubEpisode(SUBEPISODE: Guid, EPISODE: Guid): Promise<Array<LaboratoryProcedure>> {
        let url: string = "/api/LaboratoryProcedureService/GetLabProceduresBySubEpisode";
        let input = { "SUBEPISODE": SUBEPISODE, "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure>>(url, input);
        return result;
    }
    public static async GetLaboratoryProcedureBySubEpisode(SUBEPISODE: string): Promise<Array<LaboratoryProcedure.GetLaboratoryProcedureBySubEpisode_Class>> {
        let url: string = "/api/LaboratoryProcedureService/GetLaboratoryProcedureBySubEpisode";
        let input = { "SUBEPISODE": SUBEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure.GetLaboratoryProcedureBySubEpisode_Class>>(url, input);
        return result;
    }
    public static async GetLabProcedureByTestAndRequest(PARAMOBJID: Guid, TEST: Guid): Promise<Array<LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class>> {
        let url: string = "/api/LaboratoryProcedureService/GetLabProcedureByTestAndRequest";
        let input = { "PARAMOBJID": PARAMOBJID, "TEST": TEST };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class>>(url, input);
        return result;
    }
    public static async GetLabProceduresByEpisode(EPISODE: Guid): Promise<Array<LaboratoryProcedure>> {
        let url: string = "/api/LaboratoryProcedureService/GetLabProceduresByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure>>(url, input);
        return result;
    }
    public static async GetLabProcedureByTabAndRequest(PARAMOBJID: Guid, TAB: Guid): Promise<Array<LaboratoryProcedure.GetLabProcedureByTabAndRequest_Class>> {
        let url: string = "/api/LaboratoryProcedureService/GetLabProcedureByTabAndRequest";
        let input = { "PARAMOBJID": PARAMOBJID, "TAB": TAB };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure.GetLabProcedureByTabAndRequest_Class>>(url, input);
        return result;
    }
    public static async GetRejectedLaboratoryProceduresByDate(STARTDATE: Date, ENDDATE: Date): Promise<Array<LaboratoryProcedure.GetRejectedLaboratoryProceduresByDate_Class>> {
        let url: string = "/api/LaboratoryProcedureService/GetRejectedLaboratoryProceduresByDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure.GetRejectedLaboratoryProceduresByDate_Class>>(url, input);
        return result;
    }
    public static async GetLabProcedureByFilter(injectionSQL: string): Promise<Array<LaboratoryProcedure.GetLabProcedureByFilter_Class>> {
        let url: string = "/api/LaboratoryProcedureService/GetLabProcedureByFilter";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure.GetLabProcedureByFilter_Class>>(url, input);
        return result;
    }
    public static async GetLabTestsByPatientForGraph(PATIENT: Guid, STARTDATE: Date, ENDDATE: Date): Promise<Array<LaboratoryProcedure>> {
        let url: string = "/api/LaboratoryProcedureService/GetLabTestsByPatientForGraph";
        let input = { "PATIENT": PATIENT, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure>>(url, input);
        return result;
    }
    public static async GetOnlyApprovedProcedures(PARAMOBJID: string): Promise<Array<LaboratoryProcedure.GetOnlyApprovedProcedures_Class>> {
        let url: string = "/api/LaboratoryProcedureService/GetOnlyApprovedProcedures";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure.GetOnlyApprovedProcedures_Class>>(url, input);
        return result;
    }
    public static async GetLabProcedureByRequestTab(REQUESTTAB: Guid, PATIENT: Guid, WORKLISTDATE: Date): Promise<Array<LaboratoryProcedure.GetLabProcedureByRequestTab_Class>> {
        let url: string = "/api/LaboratoryProcedureService/GetLabProcedureByRequestTab";
        let input = { "REQUESTTAB": REQUESTTAB, "PATIENT": PATIENT, "WORKLISTDATE": WORKLISTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure.GetLabProcedureByRequestTab_Class>>(url, input);
        return result;
    }
    public static async GetLabProcedureByWorklistDate(STARTDATE: Date, ENDDATE: Date, injectionSQL: string): Promise<Array<LaboratoryProcedure.GetLabProcedureByWorklistDate_Class>> {
        let url: string = "/api/LaboratoryProcedureService/GetLabProcedureByWorklistDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<LaboratoryProcedure.GetLabProcedureByWorklistDate_Class>>(url, input);
        return result;
    }
}