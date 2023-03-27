//$58A479B3
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { OutPatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class OutPatientPrescriptionService {
    public static async GetOutPatientDrugPrescriptionTotalReportQuery(STARTDATE: Date, ENDDATE: Date): Promise<Array<OutPatientPrescription.GetOutPatientDrugPrescriptionTotalReportQuery_Class>> {
        let url: string = "/api/OutPatientPrescriptionService/GetOutPatientDrugPrescriptionTotalReportQuery";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OutPatientPrescription.GetOutPatientDrugPrescriptionTotalReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetReceiptNoNQL(RECEIPTNO: string): Promise<Array<OutPatientPrescription>> {
        let url: string = "/api/OutPatientPrescriptionService/GetReceiptNoNQL";
        let input = { "RECEIPTNO": RECEIPTNO };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OutPatientPrescription>>(url, input);
        return result;
    }
    public static async GetOutpatientPrescriptionReportQuery(TTOBJECTID: Guid): Promise<Array<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class>> {
        let url: string = "/api/OutPatientPrescriptionService/GetOutpatientPrescriptionReportQuery";
        let input = { "TTOBJECTID": TTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetOutPatientPrescriptionByEpisodeIDs(OBJECTIDS: Guid): Promise<Array<OutPatientPrescription>> {
        let url: string = "/api/OutPatientPrescriptionService/GetOutPatientPrescriptionByEpisodeIDs";
        let input = { "OBJECTIDS": OBJECTIDS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OutPatientPrescription>>(url, input);
        return result;
    }
    public static async GetOutPatientPrescriptionByObjectIDs(OBJECTIDS: Guid): Promise<Array<OutPatientPrescription.GetOutPatientPrescriptionByObjectIDs_Class>> {
        let url: string = "/api/OutPatientPrescriptionService/GetOutPatientPrescriptionByObjectIDs";
        let input = { "OBJECTIDS": OBJECTIDS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OutPatientPrescription.GetOutPatientPrescriptionByObjectIDs_Class>>(url, input);
        return result;
    }
    public static async GetDetailOutPresciprtionReportQuery(PRESCRIPTIONID: Guid): Promise<Array<OutPatientPrescription.GetDetailOutPresciprtionReportQuery_Class>> {
        let url: string = "/api/OutPatientPrescriptionService/GetDetailOutPresciprtionReportQuery";
        let input = { "PRESCRIPTIONID": PRESCRIPTIONID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OutPatientPrescription.GetDetailOutPresciprtionReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetOutpatientPrescriptionByEpisode(EPISODE: Guid): Promise<Array<OutPatientPrescription>> {
        let url: string = "/api/OutPatientPrescriptionService/GetOutpatientPrescriptionByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OutPatientPrescription>>(url, input);
        return result;
    }
    public static async GetBySubEpisode(SUBEPISODE: Guid): Promise<Array<OutPatientPrescription>> {
        let url: string = "/api/OutPatientPrescriptionService/GetBySubEpisode";
        let input = { "SUBEPISODE": SUBEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OutPatientPrescription>>(url, input);
        return result;
    }
}