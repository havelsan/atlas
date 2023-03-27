//$FA48995F
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { NuclearMedicine } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class NuclearMedicineService {
    public static async PrintNuclearBarcode(nuclearMedicine: NuclearMedicine): Promise<void> {
        let url: string = '/api/NuclearMedicineService/PrintNuclearBarcode';
        let input = { "nuclearMedicine": nuclearMedicine };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async NuclearMedicinePatientInfoNQL(PARAMOBJID: string): Promise<Array<NuclearMedicine.NuclearMedicinePatientInfoNQL_Class>> {
        let url: string = '/api/NuclearMedicineService/NuclearMedicinePatientInfoNQL';
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<NuclearMedicine.NuclearMedicinePatientInfoNQL_Class>>(url, input);
        return result;
    }
    public static async NuclearMedicineReportNQL(PARAMOBJID: string): Promise<Array<NuclearMedicine.NuclearMedicineReportNQL_Class>> {
        let url: string = '/api/NuclearMedicineService/NuclearMedicineReportNQL';
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<NuclearMedicine.NuclearMedicineReportNQL_Class>>(url, input);
        return result;
    }
    public static async WorkListNQL(STARTDATE: Date, ENDDATE: Date, injectionSQL: string): Promise<Array<NuclearMedicine>> {
        let url: string = '/api/NuclearMedicineService/WorkListNQL';
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<NuclearMedicine>>(url, input);
        return result;
    }
    public static async GetByWLFilterExpression(injectionSQL: string): Promise<Array<NuclearMedicine>> {
        let url: string = '/api/NuclearMedicineService/GetByWLFilterExpression';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<NuclearMedicine>>(url, input);
        return result;
    }
    public static async GetByNuclearMedicineWorklistDateReport(STARTDATE: Date, ENDDATE: Date, injectionSQL: string): Promise<Array<NuclearMedicine.GetByNuclearMedicineWorklistDateReport_Class>> {
        let url: string = '/api/NuclearMedicineService/GetByNuclearMedicineWorklistDateReport';
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<NuclearMedicine.GetByNuclearMedicineWorklistDateReport_Class>>(url, input);
        return result;
    }
    public static async GetByWLFilterExpressionReport(injectionSQL: string): Promise<Array<NuclearMedicine.GetByWLFilterExpressionReport_Class>> {
        let url: string = '/api/NuclearMedicineService/GetByWLFilterExpressionReport';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<NuclearMedicine.GetByWLFilterExpressionReport_Class>>(url, input);
        return result;
    }
}