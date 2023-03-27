//$EA115E3A
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { InpatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class InpatientPrescriptionService {
    public static async GetDrugsFromExternalPharmacyReportQuery(STARTDATE: Date, ENDDATE: Date, PHARMACYID: string): Promise<Array<InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery_Class>> {
        let url: string = "/api/InpatientPrescriptionService/GetDrugsFromExternalPharmacyReportQuery";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "PHARMACYID": PHARMACYID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetInPatientDrugPrescriptionTotalReportQuery(STARTDATE: Date, ENDDATE: Date): Promise<Array<InpatientPrescription.GetInPatientDrugPrescriptionTotalReportQuery_Class>> {
        let url: string = "/api/InpatientPrescriptionService/GetInPatientDrugPrescriptionTotalReportQuery";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientPrescription.GetInPatientDrugPrescriptionTotalReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetInpatientPrescriptionDrugsQuery(PRESCRIPTIONID: Guid): Promise<Array<InpatientPrescription.GetInpatientPrescriptionDrugsQuery_Class>> {
        let url: string = "/api/InpatientPrescriptionService/GetInpatientPrescriptionDrugsQuery";
        let input = { "PRESCRIPTIONID": PRESCRIPTIONID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientPrescription.GetInpatientPrescriptionDrugsQuery_Class>>(url, input);
        return result;
    }
    public static async GetInpatientPrescriptionReportQuery(TTOBJECTID: Guid): Promise<Array<InpatientPrescription.GetInpatientPrescriptionReportQuery_Class>> {
        let url: string = "/api/InpatientPrescriptionService/GetInpatientPrescriptionReportQuery";
        let input = { "TTOBJECTID": TTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientPrescription.GetInpatientPrescriptionReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetDetailInPresciprtionReportQuery(PRESCRIPTIONID: Guid): Promise<Array<InpatientPrescription.GetDetailInPresciprtionReportQuery_Class>> {
        let url: string = "/api/InpatientPrescriptionService/GetDetailInPresciprtionReportQuery";
        let input = { "PRESCRIPTIONID": PRESCRIPTIONID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientPrescription.GetDetailInPresciprtionReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetBySubEpisode(SUBEPISODE: Guid): Promise<Array<InpatientPrescription>> {
        let url: string = "/api/InpatientPrescriptionService/GetBySubEpisode";
        let input = { "SUBEPISODE": SUBEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InpatientPrescription>>(url, input);
        return result;
    }
}