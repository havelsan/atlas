
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { SubEpisodeProtocol } from 'NebulaClient/Model/AtlasClientModel';

export class SubEpisodeProtocolService {
    public static async UpdateInvoiceSEPDetail(id: Guid, newData: Guid, type: number): Promise<boolean> {
        let url: string = "/api/SubEpisodeProtocolService/UpdateInvoiceSEPDetail";
        let input = { "id": id, "newData": newData, "type": type };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async GetChildSEP(sep: SubEpisodeProtocol, childSEPHasProvisionNo: boolean): Promise<SubEpisodeProtocol> {
        let url: string = "/api/SubEpisodeProtocolService/GetChildSEP";
        let input = { "sep": sep, "childSEPHasProvisionNo": childSEPHasProvisionNo };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<SubEpisodeProtocol>(url, input);
        return result;
    }
    public static async GetSEPByProvisionNo(ProvisionNo: string): Promise<SubEpisodeProtocol> {
        let url: string = "/api/SubEpisodeProtocolService/GetSEPByProvisionNo";
        let input = { "ProvisionNo": ProvisionNo };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<SubEpisodeProtocol>(url, input);
        return result;
    }
    public static async GetSEPByEpisode(EPISODE: Guid): Promise<Array<SubEpisodeProtocol>> {
        let url: string = "/api/SubEpisodeProtocolService/GetSEPByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisodeProtocol>>(url, input);
        return result;
    }
    public static async GetByObjectID(OBJECTID: Guid): Promise<Array<SubEpisodeProtocol.GetByObjectID_Class>> {
        let url: string = "/api/SubEpisodeProtocolService/GetByObjectID";
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisodeProtocol.GetByObjectID_Class>>(url, input);
        return result;
    }
    public static async GetSEPByPatient(STARTDATE: Date, ENDDATE: Date, PATIENT: Guid, injectionSQL: string): Promise<Array<SubEpisodeProtocol>> {
        let url: string = "/api/SubEpisodeProtocolService/GetSEPByPatient";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "PATIENT": PATIENT, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisodeProtocol>>(url, input);
        return result;
    }
    public static async GetBySEPMaster(SEPMASTER: Guid): Promise<Array<SubEpisodeProtocol.GetBySEPMaster_Class>> {
        let url: string = "/api/SubEpisodeProtocolService/GetBySEPMaster";
        let input = { "SEPMASTER": SEPMASTER };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisodeProtocol.GetBySEPMaster_Class>>(url, input);
        return result;
    }
    public static async GetSEPBySEPMaster(SEPMASTER: Guid): Promise<Array<SubEpisodeProtocol>> {
        let url: string = "/api/SubEpisodeProtocolService/GetSEPBySEPMaster";
        let input = { "SEPMASTER": SEPMASTER };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisodeProtocol>>(url, input);
        return result;
    }
    public static async GetAllPatientInfoByDate(STARTDATE: Date, ENDDATE: Date): Promise<Array<SubEpisodeProtocol.GetAllPatientInfoByDate_Class>> {
        let url: string = "/api/SubEpisodeProtocolService/GetAllPatientInfoByDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisodeProtocol.GetAllPatientInfoByDate_Class>>(url, input);
        return result;
    }
    public static async GetAllPatientInfoByDateWithoutUser(STARTDATE: Date, ENDDATE: Date): Promise<Array<SubEpisodeProtocol.GetAllPatientInfoByDateWithoutUser_Class>> {
        let url: string = "/api/SubEpisodeProtocolService/GetAllPatientInfoByDateWithoutUser";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisodeProtocol.GetAllPatientInfoByDateWithoutUser_Class>>(url, input);
        return result;
    }
    public static async GetPAInfoByDateWithProvision(STARTDATE: Date, ENDDATE: Date): Promise<Array<SubEpisodeProtocol.GetPAInfoByDateWithProvision_Class>> {
        let url: string = "/api/SubEpisodeProtocolService/GetPAInfoByDateWithProvision";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisodeProtocol.GetPAInfoByDateWithProvision_Class>>(url, input);
        return result;
    }
    public static async GetPAInfoByDateWithoutProvision(STARTDATE: Date, ENDDATE: Date): Promise<Array<SubEpisodeProtocol.GetPAInfoByDateWithProvision_Class>> {
        let url: string = "/api/SubEpisodeProtocolService/GetPAInfoByDateWithoutProvision";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisodeProtocol.GetPAInfoByDateWithoutProvision_Class>>(url, input);
        return result;
    }
    public static async GetSepCountByDate(STARTDATE: Date, ENDDATE: Date): Promise<Array<SubEpisodeProtocol.GetSepCountByDate_Class>> {
        let url: string = "/api/SubEpisodeProtocolService/GetSepCountByDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisodeProtocol.GetSepCountByDate_Class>>(url, input);
        return result;
    }
    public static async GetPaBySearchPatient(injectionSQL: string): Promise<Array<SubEpisodeProtocol.GetPaBySearchPatient_Class>> {
        let url: string = "/api/SubEpisodeProtocolService/GetPaBySearchPatient";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisodeProtocol.GetPaBySearchPatient_Class>>(url, input);
        return result;
    }
    public static async GetSEPByInjection(injectionSQL: string): Promise<Array<SubEpisodeProtocol.GetSEPByInjection_Class>> {
        let url: string = "/api/SubEpisodeProtocolService/GetSEPByInjection";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisodeProtocol.GetSEPByInjection_Class>>(url, input);
        return result;
    }
    public static async GetPaBySearchPatientForTreatmentReport(injectionSQL: string): Promise<Array<SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport_Class>> {
        let url: string = "/api/SubEpisodeProtocolService/GetPaBySearchPatientForTreatmentReport";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport_Class>>(url, input);
        return result;
    }
    public static async GetEpisodeByInjection(injectionSQL: string): Promise<Array<SubEpisodeProtocol.GetEpisodeByInjection_Class>> {
        let url: string = "/api/SubEpisodeProtocolService/GetEpisodeByInjection";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisodeProtocol.GetEpisodeByInjection_Class>>(url, input);
        return result;
    }
}