//$02526D8D
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { InpatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class InpatientAdmissionService {
    public static async GetDischargedConclusion(inpatientAdmission: InpatientAdmission): Promise<string> {
        let url: string = "/api/InpatientAdmissionService/GetDischargedConclusion";
        let input = { "inpatientAdmission": inpatientAdmission };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async GetExcessOfRealBedDayToBedProcedure(inpatientAdmission: InpatientAdmission): Promise<number> {
        let url: string = "/api/InpatientAdmissionService/GetExcessOfRealBedDayToBedProcedure";
        let input = { "inpatientAdmission": inpatientAdmission };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<number>(url, input);
        return result;
    }
    public static async GetLatestDischargeDate(inpatientAdmission: InpatientAdmission): Promise<string> {
        let url: string = "/api/InpatientAdmissionService/GetLatestDischargeDate";
        let input = { "inpatientAdmission": inpatientAdmission };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async GetInpatientFolderInfo(INPATIENTADMISSION: string): Promise<Array<InpatientAdmission.GetInpatientFolderInfo_Class>> {
        let url: string = "/api/InpatientAdmissionService/GetInpatientFolderInfo";
        let input = { "INPATIENTADMISSION": INPATIENTADMISSION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.GetInpatientFolderInfo_Class>>(url, input);
        return result;
    }
    public static async GetInpatientDischargeInfo(INPATIENTADMISSION: string): Promise<Array<InpatientAdmission.GetInpatientDischargeInfo_Class>> {
        let url: string = "/api/InpatientAdmissionService/GetInpatientDischargeInfo";
        let input = { "INPATIENTADMISSION": INPATIENTADMISSION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.GetInpatientDischargeInfo_Class>>(url, input);
        return result;
    }
    public static async GetInpatientPrisonerDelivery(INPATIENTADMISSION: string): Promise<Array<InpatientAdmission.GetInpatientPrisonerDelivery_Class>> {
        let url: string = "/api/InpatientAdmissionService/GetInpatientPrisonerDelivery";
        let input = { "INPATIENTADMISSION": INPATIENTADMISSION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.GetInpatientPrisonerDelivery_Class>>(url, input);
        return result;
    }
    public static async GetInpatientAdmissionDeclaration(INPATIENTADMISSION: string): Promise<Array<InpatientAdmission.GetInpatientAdmissionDeclaration_Class>> {
        let url: string = "/api/InpatientAdmissionService/GetInpatientAdmissionDeclaration";
        let input = { "INPATIENTADMISSION": INPATIENTADMISSION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.GetInpatientAdmissionDeclaration_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetLastTreatmentClinic(EPISODEID: string): Promise<Array<InpatientAdmission.OLAP_GetLastTreatmentClinic_Class>> {
        let url: string = "/api/InpatientAdmissionService/OLAP_GetLastTreatmentClinic";
        let input = { "EPISODEID": EPISODEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.OLAP_GetLastTreatmentClinic_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetDischargedInpatient(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<InpatientAdmission.OLAP_GetDischargedInpatient_Class>> {
        let url: string = "/api/InpatientAdmissionService/OLAP_GetDischargedInpatient";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.OLAP_GetDischargedInpatient_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetFirstTreatmentClinic(EPISODEID: string): Promise<Array<InpatientAdmission.OLAP_GetFirstTreatmentClinic_Class>> {
        let url: string = "/api/InpatientAdmissionService/OLAP_GetFirstTreatmentClinic";
        let input = { "EPISODEID": EPISODEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.OLAP_GetFirstTreatmentClinic_Class>>(url, input);
        return result;
    }
    public static async GetUnacceptedInLimitedTime(LIMITREQUESTDATE: Date): Promise<Array<InpatientAdmission>> {
        let url: string = "/api/InpatientAdmissionService/GetUnacceptedInLimitedTime";
        let input = { "LIMITREQUESTDATE": LIMITREQUESTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission>>(url, input);
        return result;
    }
    public static async GetDischargeNumberForEtiquetteOffice(STARTDATE: Date, ENDDATE: Date): Promise<Array<InpatientAdmission.GetDischargeNumberForEtiquetteOffice_Class>> {
        let url: string = "/api/InpatientAdmissionService/GetDischargeNumberForEtiquetteOffice";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.GetDischargeNumberForEtiquetteOffice_Class>>(url, input);
        return result;
    }
    public static async GetUrgentPatientListByDate(STARTDATE: Date, ENDDATE: Date): Promise<Array<InpatientAdmission.GetUrgentPatientListByDate_Class>> {
        let url: string = "/api/InpatientAdmissionService/GetUrgentPatientListByDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.GetUrgentPatientListByDate_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetCancelledDischargedInpatient(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<InpatientAdmission.OLAP_GetCancelledDischargedInpatient_Class>> {
        let url: string = "/api/InpatientAdmissionService/OLAP_GetCancelledDischargedInpatient";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.OLAP_GetCancelledDischargedInpatient_Class>>(url, input);
        return result;
    }
    public static async GetDischargedPatientListByDischargeNumber(DISCHARGESTARTNO: number, DISCHARGEENDNO: number, FILTER: number, CLINIC: string, STARTDATE: Date): Promise<Array<InpatientAdmission.GetDischargedPatientListByDischargeNumber_Class>> {
        let url: string = "/api/InpatientAdmissionService/GetDischargedPatientListByDischargeNumber";
        let input = { "DISCHARGESTARTNO": DISCHARGESTARTNO, "DISCHARGEENDNO": DISCHARGEENDNO, "FILTER": FILTER, "CLINIC": CLINIC, "STARTDATE": STARTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.GetDischargedPatientListByDischargeNumber_Class>>(url, input);
        return result;
    }
    public static async GetDischargedPatientListByDate(STARTDATE: Date, ENDDATE: Date, CLINIC: string, FILTER: number): Promise<Array<InpatientAdmission.GetDischargedPatientListByDate_Class>> {
        let url: string = "/api/InpatientAdmissionService/GetDischargedPatientListByDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "CLINIC": CLINIC, "FILTER": FILTER };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.GetDischargedPatientListByDate_Class>>(url, input);
        return result;
    }
    public static async GetDischargeNumberForEtiquetteUnit(STARTDATE: Date, ENDDATE: Date): Promise<Array<InpatientAdmission.GetDischargeNumberForEtiquetteUnit_Class>> {
        let url: string = "/api/InpatientAdmissionService/GetDischargeNumberForEtiquetteUnit";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.GetDischargeNumberForEtiquetteUnit_Class>>(url, input);
        return result;
    }
    public static async GetDischargedInPatientAdmissions(): Promise<Array<InpatientAdmission>> {
        let url: string = "/api/InpatientAdmissionService/GetDischargedInPatientAdmissions";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission>>(url, input);
        return result;
    }
    public static async PlastikCerrahiIstatistik(STARTDATE: Date, ENDDATE: Date, CLINIC: string): Promise<Array<InpatientAdmission.PlastikCerrahiIstatistik_Class>> {
        let url: string = "/api/InpatientAdmissionService/PlastikCerrahiIstatistik";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "CLINIC": CLINIC };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.PlastikCerrahiIstatistik_Class>>(url, input);
        return result;
    }
    public static async SelectActiveInpatientAdmissionCollectedInvoiceRQ(EPISODEID: Guid): Promise<Array<InpatientAdmission.SelectActiveInpatientAdmissionCollectedInvoiceRQ_Class>> {
        let url: string = "/api/InpatientAdmissionService/SelectActiveInpatientAdmissionCollectedInvoiceRQ";
        let input = { "EPISODEID": EPISODEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.SelectActiveInpatientAdmissionCollectedInvoiceRQ_Class>>(url, input);
        return result;
    }
    public static async GetForeignInpatientsNQL(ACTIONENDDATE: Date, ACTIONSTARTDATE: Date): Promise<Array<InpatientAdmission.GetForeignInpatientsNQL_Class>> {
        let url: string = "/api/InpatientAdmissionService/GetForeignInpatientsNQL";
        let input = { "ACTIONENDDATE": ACTIONENDDATE, "ACTIONSTARTDATE": ACTIONSTARTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.GetForeignInpatientsNQL_Class>>(url, input);
        return result;
    }
    public static async GetInPatientEtiquette(OBJECTID: string): Promise<Array<InpatientAdmission.GetInPatientEtiquette_Class>> {
        let url: string = "/api/InpatientAdmissionService/GetInPatientEtiquette";
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.GetInPatientEtiquette_Class>>(url, input);
        return result;
    }
    public static async GetDoctorFaultAmount(STARTDATE: Date, ENDDATE: Date): Promise<Array<InpatientAdmission.GetDoctorFaultAmount_Class>> {
        let url: string = "/api/InpatientAdmissionService/GetDoctorFaultAmount";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission.GetDoctorFaultAmount_Class>>(url, input);
        return result;
    }
    public static async GetInpatientAdmissionByEpisode(EPISODE: string): Promise<Array<InpatientAdmission>> {
        let url: string = "/api/InpatientAdmissionService/GetInpatientAdmissionByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientAdmission>>(url, input);
        return result;
    }
}