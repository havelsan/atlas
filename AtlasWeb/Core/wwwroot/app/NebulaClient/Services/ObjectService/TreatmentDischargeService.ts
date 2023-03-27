//$AF0EC417
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { TreatmentDischarge } from 'NebulaClient/Model/AtlasClientModel';

export class TreatmentDischargeService {
    public static async TreatmentDischargeReport(TREATMENTDISCHARGE: string): Promise<Array<TreatmentDischarge.TreatmentDischargeReport_Class>> {
        let url: string = "/api/TreatmentDischargeService/TreatmentDischargeReport";
        let input = { "TREATMENTDISCHARGE": TREATMENTDISCHARGE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<TreatmentDischarge.TreatmentDischargeReport_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetTreatmentDischarge(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<TreatmentDischarge.OLAP_GetTreatmentDischarge_Class>> {
        let url: string = "/api/TreatmentDischargeService/OLAP_GetTreatmentDischarge";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<TreatmentDischarge.OLAP_GetTreatmentDischarge_Class>>(url, input);
        return result;
    }
    public static async GetTreatmentDischargeByEpisode(EPISODE: Guid): Promise<Array<TreatmentDischarge>> {
        let url: string = "/api/TreatmentDischargeService/GetTreatmentDischargeByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<TreatmentDischarge>>(url, input);
        return result;
    }
    public static async OLAP_Sevk(): Promise<Array<TreatmentDischarge.OLAP_Sevk_Class>> {
        let url: string = "/api/TreatmentDischargeService/OLAP_Sevk";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<TreatmentDischarge.OLAP_Sevk_Class>>(url, input);
        return result;
    }
    public static async GetTreatmentDischargeBySubEpisode(SUBEPISODE: Guid): Promise<Array<TreatmentDischarge>> {
        let url: string = "/api/TreatmentDischargeService/GetTreatmentDischargeBySubEpisode";
        let input = { "SUBEPISODE": SUBEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<TreatmentDischarge>>(url, input);
        return result;
    }
    public static async GetPreDischargedInfoByProcedureDoctor(PROCEDUREDOCTOR: Guid): Promise<Array<TreatmentDischarge.GetPreDischargedInfoByProcedureDoctor_Class>> {
        let url: string = "/api/TreatmentDischargeService/GetPreDischargedInfoByProcedureDoctor";
        let input = { "PROCEDUREDOCTOR": PROCEDUREDOCTOR };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<TreatmentDischarge.GetPreDischargedInfoByProcedureDoctor_Class>>(url, input);
        return result;
    }
    public static async GetPreDischargedInfoByClinic(CLINIC: Guid): Promise<Array<TreatmentDischarge.GetPreDischargedInfoByClinic_Class>> {
        let url: string = "/api/TreatmentDischargeService/GetPreDischargedInfoByClinic";
        let input = { "CLINIC": CLINIC };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<TreatmentDischarge.GetPreDischargedInfoByClinic_Class>>(url, input);
        return result;
    }
}