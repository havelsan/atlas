//$195641CE
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { HealthCommittee } from 'NebulaClient/Model/AtlasClientModel';
import { HealthCommitteeTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class HealthCommitteeService {
    public static async CalculateFunctionRatio(healthCommittee: HealthCommittee): Promise<number> {
        let url: string = "/api/HealthCommitteeService/CalculateFunctionRatio";
        let input = { "healthCommittee": healthCommittee };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<number>(url, input);
        return result;
    }
    public static async UnCompletedExaminationExists(healthCommittee: HealthCommittee): Promise<boolean> {
        let url: string = "/api/HealthCommitteeService/UnCompletedExaminationExists";
        let input = { "healthCommittee": healthCommittee };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async CheckIfAllCancelledOrNotExists(healthCommittee: HealthCommittee): Promise<boolean> {
        let url: string = "/api/HealthCommitteeService/CheckIfAllCancelledOrNotExists";
        let input = { "healthCommittee": healthCommittee };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async SendToLab(healthCommittee: HealthCommittee): Promise<void> {
        let url: string = "/api/HealthCommitteeService/SendToLab";
        let input = { "healthCommittee": healthCommittee };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async GetCurrentHealthCommittee(OBJECTID: Guid): Promise<Array<HealthCommittee.GetCurrentHealthCommittee_Class>> {
        let url: string = "/api/HealthCommitteeService/GetCurrentHealthCommittee";
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.GetCurrentHealthCommittee_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetHealthCommitteeByEpisode(EPISODEID: string): Promise<Array<HealthCommittee.OLAP_GetHealthCommitteeByEpisode_Class>> {
        let url: string = "/api/HealthCommitteeService/OLAP_GetHealthCommitteeByEpisode";
        let input = { "EPISODEID": EPISODEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.OLAP_GetHealthCommitteeByEpisode_Class>>(url, input);
        return result;
    }
    public static async GetHealthCommittees(STARTDATE: Date, ENDDATE: Date): Promise<Array<HealthCommittee.GetHealthCommittees_Class>> {
        let url: string = "/api/HealthCommitteeService/GetHealthCommittees";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.GetHealthCommittees_Class>>(url, input);
        return result;
    }
    public static async GetAllHealthCommiteesOfPatient(PATIENTOBJECTID: string): Promise<Array<HealthCommittee>> {
        let url: string = "/api/HealthCommitteeService/GetAllHealthCommiteesOfPatient";
        let input = { "PATIENTOBJECTID": PATIENTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee>>(url, input);
        return result;
    }
    public static async GetXXXXXXApprovalHCsByDate(PARAMSTARTDATE: Date, PARAMENDDATE: Date): Promise<Array<HealthCommittee.GetXXXXXXApprovalHCsByDate_Class>> {
        let url: string = "/api/HealthCommitteeService/GetXXXXXXApprovalHCsByDate";
        let input = { "PARAMSTARTDATE": PARAMSTARTDATE, "PARAMENDDATE": PARAMENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.GetXXXXXXApprovalHCsByDate_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetCancelledHealthCommittees(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<HealthCommittee.OLAP_GetCancelledHealthCommittees_Class>> {
        let url: string = "/api/HealthCommitteeService/OLAP_GetCancelledHealthCommittees";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.OLAP_GetCancelledHealthCommittees_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetHealthCommittesByDate(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<HealthCommittee.OLAP_GetHealthCommittesByDate_Class>> {
        let url: string = "/api/HealthCommitteeService/OLAP_GetHealthCommittesByDate";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.OLAP_GetHealthCommittesByDate_Class>>(url, input);
        return result;
    }
    public static async GetHCsByDateAndUniqueRefNo(STARTDATE: Date, ENDDATE: Date, UNIQUEREFNO: string, UNIQUEREFNOFLAG: number, HEALTHCOMITEETYPEFLAG: number, HEALTHCOMITEETYPE: HealthCommitteeTypeEnum): Promise<Array<HealthCommittee.GetHCsByDateAndUniqueRefNo_Class>> {
        let url: string = "/api/HealthCommitteeService/GetHCsByDateAndUniqueRefNo";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "UNIQUEREFNO": UNIQUEREFNO, "UNIQUEREFNOFLAG": UNIQUEREFNOFLAG, "HEALTHCOMITEETYPEFLAG": HEALTHCOMITEETYPEFLAG, "HEALTHCOMITEETYPE": HEALTHCOMITEETYPE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.GetHCsByDateAndUniqueRefNo_Class>>(url, input);
        return result;
    }
    public static async GetMSBApprovalHCsByDate(PARAMSTARTDATE: Date, PARAMENDDATE: Date): Promise<Array<HealthCommittee.GetMSBApprovalHCsByDate_Class>> {
        let url: string = "/api/HealthCommitteeService/GetMSBApprovalHCsByDate";
        let input = { "PARAMSTARTDATE": PARAMSTARTDATE, "PARAMENDDATE": PARAMENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.GetMSBApprovalHCsByDate_Class>>(url, input);
        return result;
    }
    public static async GetHCReportGroupNameByPatient(PATIENT: string): Promise<Array<HealthCommittee.GetHCReportGroupNameByPatient_Class>> {
        let url: string = "/api/HealthCommitteeService/GetHCReportGroupNameByPatient";
        let input = { "PATIENT": PATIENT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.GetHCReportGroupNameByPatient_Class>>(url, input);
        return result;
    }
    public static async GetByWLFilterExpression(injectionSQL: string): Promise<Array<HealthCommittee>> {
        let url: string = "/api/HealthCommitteeService/GetByWLFilterExpression";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee>>(url, input);
        return result;
    }
    public static async GetHealthCommitteeWL(STARTDATE: Date, ENDDATE: Date, injectionSQL: string): Promise<Array<HealthCommittee>> {
        let url: string = "/api/HealthCommitteeService/GetHealthCommitteeWL";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee>>(url, input);
        return result;
    }
    public static async GetHealthCommitteesByDate(STARTDATE: Date, ENDDATE: Date): Promise<Array<HealthCommittee.GetHealthCommitteesByDate_Class>> {
        let url: string = "/api/HealthCommitteeService/GetHealthCommitteesByDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.GetHealthCommitteesByDate_Class>>(url, input);
        return result;
    }
    public static async GetHealthCommiteesOfEpisode(EPISODE: string): Promise<Array<HealthCommittee>> {
        let url: string = "/api/HealthCommitteeService/GetHealthCommiteesOfEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee>>(url, input);
        return result;
    }
    public static async GetHcBySlice(STARTDATE: Date, ENDDATE: Date, SLICEORDER: number, SLICEFLAG: number): Promise<Array<HealthCommittee.GetHcBySlice_Class>> {
        let url: string = "/api/HealthCommitteeService/GetHcBySlice";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "SLICEORDER": SLICEORDER, "SLICEFLAG": SLICEFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.GetHcBySlice_Class>>(url, input);
        return result;
    }
    public static async GetNotCollectedInvoicableHealthCommitteeRQ(EPISODEID: Guid): Promise<Array<HealthCommittee.GetNotCollectedInvoicableHealthCommitteeRQ_Class>> {
        let url: string = "/api/HealthCommitteeService/GetNotCollectedInvoicableHealthCommitteeRQ";
        let input = { "EPISODEID": EPISODEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.GetNotCollectedInvoicableHealthCommitteeRQ_Class>>(url, input);
        return result;
    }
    public static async GetByPatientHProtNoAndActionID(PATIENT: Guid, EPISODEHOSPROTOCOLNO: number, ACTIONID: number): Promise<Array<HealthCommittee>> {
        let url: string = "/api/HealthCommitteeService/GetByPatientHProtNoAndActionID";
        let input = { "PATIENT": PATIENT, "EPISODEHOSPROTOCOLNO": EPISODEHOSPROTOCOLNO, "ACTIONID": ACTIONID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee>>(url, input);
        return result;
    }
    public static async GetHealthCommitteesByType(ENDDATE: Date, HEALTHCOMITEETYPE: HealthCommitteeTypeEnum, HEALTHCOMITEETYPEFLAG: number, STARTDATE: Date): Promise<Array<HealthCommittee.GetHealthCommitteesByType_Class>> {
        let url: string = "/api/HealthCommitteeService/GetHealthCommitteesByType";
        let input = { "ENDDATE": ENDDATE, "HEALTHCOMITEETYPE": HEALTHCOMITEETYPE, "HEALTHCOMITEETYPEFLAG": HEALTHCOMITEETYPEFLAG, "STARTDATE": STARTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.GetHealthCommitteesByType_Class>>(url, input);
        return result;
    }
    public static async GetHCsForPeriodicExaminationResultReport(STARTDATE: Date, ENDDATE: Date): Promise<Array<HealthCommittee.GetHCsForPeriodicExaminationResultReport_Class>> {
        let url: string = "/api/HealthCommitteeService/GetHCsForPeriodicExaminationResultReport";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.GetHCsForPeriodicExaminationResultReport_Class>>(url, input);
        return result;
    }
    public static async GetHCsForAdditionalReport(injectionSQL: string): Promise<Array<HealthCommittee.GetHCsForAdditionalReport_Class>> {
        let url: string = "/api/HealthCommitteeService/GetHCsForAdditionalReport";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.GetHCsForAdditionalReport_Class>>(url, input);
        return result;
    }
    public static async GetSuccessfulHCsByDateTypePatientGroup(STARTDATE: Date, ENDDATE: Date, HEALTHCOMITEETYPE: HealthCommitteeTypeEnum, HEALTHCOMITEETYPEFLAG: number): Promise<Array<HealthCommittee.GetSuccessfulHCsByDateTypePatientGroup_Class>> {
        let url: string = "/api/HealthCommitteeService/GetSuccessfulHCsByDateTypePatientGroup";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "HEALTHCOMITEETYPE": HEALTHCOMITEETYPE, "HEALTHCOMITEETYPEFLAG": HEALTHCOMITEETYPEFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.GetSuccessfulHCsByDateTypePatientGroup_Class>>(url, input);
        return result;
    }
    public static async GetHCsToSendSummary(STARTDATE: Date, ENDDATE: Date): Promise<Array<HealthCommittee>> {
        let url: string = "/api/HealthCommitteeService/GetHCsToSendSummary";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee>>(url, input);
        return result;
    }
    public static async GetUncompletedHCsToSend(STARTDATE: Date, ENDDATE: Date): Promise<Array<HealthCommittee>> {
        let url: string = "/api/HealthCommitteeService/GetUncompletedHCsToSend";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee>>(url, input);
        return result;
    }
    public static async GetUnsuccessfulHCsByDateTypePatientGroup(STARTDATE: Date, ENDDATE: Date, HEALTHCOMITEETYPE: HealthCommitteeTypeEnum, HEALTHCOMITEETYPEFLAG: number): Promise<Array<HealthCommittee.GetUnsuccessfulHCsByDateTypePatientGroup_Class>> {
        let url: string = "/api/HealthCommitteeService/GetUnsuccessfulHCsByDateTypePatientGroup";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "HEALTHCOMITEETYPE": HEALTHCOMITEETYPE, "HEALTHCOMITEETYPEFLAG": HEALTHCOMITEETYPEFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<HealthCommittee.GetUnsuccessfulHCsByDateTypePatientGroup_Class>>(url, input);
        return result;
    }
}