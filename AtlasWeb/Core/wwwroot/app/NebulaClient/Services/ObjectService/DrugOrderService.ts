//$47637ABD
import { DrugDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { FrequencyEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class DrugOrderService {
    public static async GetDetailCount(pFrequency: FrequencyEnum): Promise<number> {
        let url: string = "/api/DrugOrderService/GetDetailCount";
        let input = { "pFrequency": pFrequency };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<number>(url, input);
        return result;
    }
    public static async GetDetailTimePeriod(pFrequency: FrequencyEnum): Promise<number> {
        let url: string = "/api/DrugOrderService/GetDetailTimePeriod";
        let input = { "pFrequency": pFrequency };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<number>(url, input);
        return result;
    }
    public static async GetDrugUsedType(Drug: DrugDefinition): Promise<boolean> {
        let url: string = "/api/DrugOrderService/GetDrugUsedType";
        let input = { "Drug": Drug };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async GetContinueDrugOrder(drugOrder: DrugOrder, planStart: Date): Promise<boolean> {
        let url: string = "/api/DrugOrderService/GetContinueDrugOrder";
        let input = { "drugOrder": drugOrder, "planStart": planStart };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async GetMaxDose(drugOrder: DrugOrder, dose: number): Promise<boolean> {
        let url: string = "/api/DrugOrderService/GetMaxDose";
        let input = { "drugOrder": drugOrder, "dose": dose };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async GetMaxDoseDay(drugOrder: DrugOrder, day: number): Promise<boolean> {
        let url: string = "/api/DrugOrderService/GetMaxDoseDay";
        let input = { "drugOrder": drugOrder, "day": day };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async GetAllDrugsWithDetailForDoctorReportQuery(STARTDATE: Date, ENDDATE: Date, DOCTORID: string): Promise<Array<DrugOrder.GetAllDrugsWithDetailForDoctorReportQuery_Class>> {
        let url: string = "/api/DrugOrderService/GetAllDrugsWithDetailForDoctorReportQuery";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "DOCTORID": DOCTORID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder.GetAllDrugsWithDetailForDoctorReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetDrugsFromPharmacyReportQuery(STARTDATE: Date, ENDDATE: Date): Promise<Array<DrugOrder.GetDrugsFromPharmacyReportQuery_Class>> {
        let url: string = "/api/DrugOrderService/GetDrugsFromPharmacyReportQuery";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder.GetDrugsFromPharmacyReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetDrugsToPatientWithPrescriptionReportQuery(STARTDATE: Date, ENDDATE: Date, DOCTORID: string, DRUGID: string): Promise<Array<DrugOrder.GetDrugsToPatientWithPrescriptionReportQuery_Class>> {
        let url: string = "/api/DrugOrderService/GetDrugsToPatientWithPrescriptionReportQuery";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "DOCTORID": DOCTORID, "DRUGID": DRUGID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder.GetDrugsToPatientWithPrescriptionReportQuery_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetDrugOrder_OLD(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<DrugOrder>> {
        let url: string = "/api/DrugOrderService/OLAP_GetDrugOrder_OLD";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder>>(url, input);
        return result;
    }
    public static async GetAllDrugsForPatientGroupsReportQuery(STARTDATE: Date, ENDDATE: Date): Promise<Array<DrugOrder.GetAllDrugsForPatientGroupsReportQuery_Class>> {
        let url: string = "/api/DrugOrderService/GetAllDrugsForPatientGroupsReportQuery";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder.GetAllDrugsForPatientGroupsReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetDrugOrderForPatient(EPISODEID: string): Promise<Array<DrugOrder>> {
        let url: string = "/api/DrugOrderService/GetDrugOrderForPatient";
        let input = { "EPISODEID": EPISODEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder>>(url, input);
        return result;
    }
    public static async GetDrugsExceededMaxPackageAmountReportQuery(): Promise<Array<DrugOrder.GetDrugsExceededMaxPackageAmountReportQuery_Class>> {
        let url: string = "/api/DrugOrderService/GetDrugsExceededMaxPackageAmountReportQuery";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder.GetDrugsExceededMaxPackageAmountReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetSequenceDrugOrdes(MATERIAL: string): Promise<Array<DrugOrder>> {
        let url: string = "/api/DrugOrderService/GetSequenceDrugOrdes";
        let input = { "MATERIAL": MATERIAL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder>>(url, input);
        return result;
    }
    public static async GetDrugOrderStates(PLANNED: string): Promise<Array<DrugOrder>> {
        let url: string = "/api/DrugOrderService/GetDrugOrderStates";
        let input = { "PLANNED": PLANNED };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder>>(url, input);
        return result;
    }
    public static async GetDrugsToPatientsForEpisodeReportQuery(STARTDATE: Date, ENDDATE: Date, EPISODEID: number): Promise<Array<DrugOrder.GetDrugsToPatientsForEpisodeReportQuery_Class>> {
        let url: string = "/api/DrugOrderService/GetDrugsToPatientsForEpisodeReportQuery";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "EPISODEID": EPISODEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder.GetDrugsToPatientsForEpisodeReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetDrugsToPatientsForDateReportQuery(STARTDATE: Date, ENDDATE: Date, PATIENTID: string): Promise<Array<DrugOrder.GetDrugsToPatientsForDateReportQuery_Class>> {
        let url: string = "/api/DrugOrderService/GetDrugsToPatientsForDateReportQuery";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "PATIENTID": PATIENTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder.GetDrugsToPatientsForDateReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetDrugOrdersByEpisode(EPISODE: Guid): Promise<Array<DrugOrder>> {
        let url: string = "/api/DrugOrderService/GetDrugOrdersByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder>>(url, input);
        return result;
    }
    public static async OLAP_GetDrugOrder(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<DrugOrder.OLAP_GetDrugOrder_Class>> {
        let url: string = "/api/DrugOrderService/OLAP_GetDrugOrder";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder.OLAP_GetDrugOrder_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetCancelledDrugOrder(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<DrugOrder.OLAP_GetCancelledDrugOrder_Class>> {
        let url: string = "/api/DrugOrderService/OLAP_GetCancelledDrugOrder";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder.OLAP_GetCancelledDrugOrder_Class>>(url, input);
        return result;
    }
    public static async GetDrugOrdersBySubEpisode(SUBEPISODE: Guid, EPISODE: string): Promise<Array<DrugOrder>> {
        let url: string = "/api/DrugOrderService/GetDrugOrdersBySubEpisode";
        let input = { "SUBEPISODE": SUBEPISODE, "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder>>(url, input);
        return result;
    }
    public static async GetDrugOrderForPatientbyDrug(EPISODEID: Guid, DRUGID: Guid): Promise<Array<DrugOrder>> {
        let url: string = "/api/DrugOrderService/GetDrugOrderForPatientbyDrug";
        let input = { "EPISODEID": EPISODEID, "DRUGID": DRUGID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder>>(url, input);
        return result;
    }
    public static async IlacOdemeQuery(ENDDATE: Date, STARTDATE: Date): Promise<Array<DrugOrder.IlacOdemeQuery_Class>> {
        let url: string = "/api/DrugOrderService/IlacOdemeQuery";
        let input = { "ENDDATE": ENDDATE, "STARTDATE": STARTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder.IlacOdemeQuery_Class>>(url, input);
        return result;
    }
    public static async VEM_RECETE_ILAC_ACIKLAMA(): Promise<Array<DrugOrder.VEM_RECETE_ILAC_ACIKLAMA_Class>> {
        let url: string = "/api/DrugOrderService/VEM_RECETE_ILAC_ACIKLAMA";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrder.VEM_RECETE_ILAC_ACIKLAMA_Class>>(url, input);
        return result;
    }
}