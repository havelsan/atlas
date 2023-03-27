//$CB5E8D08
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { SubSurgery } from 'NebulaClient/Model/AtlasClientModel';

export class SubSurgeryService {
    public static async SubSurgeryReportNQL(SUBSURGERY: string): Promise<Array<SubSurgery.SubSurgeryReportNQL_Class>> {
        let url: string = '/api/SubSurgeryService/SubSurgeryReportNQL';
        let input = { "SUBSURGERY": SUBSURGERY };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubSurgery.SubSurgeryReportNQL_Class>>(url, input);
        return result;
    }
    public static async SubSurgeryReportBySurgeryNQL(SURGERY: string): Promise<Array<SubSurgery.SubSurgeryReportBySurgeryNQL_Class>> {
        let url: string = '/api/SubSurgeryService/SubSurgeryReportBySurgeryNQL';
        let input = { "SURGERY": SURGERY };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubSurgery.SubSurgeryReportBySurgeryNQL_Class>>(url, input);
        return result;
    }
    public static async GetByEpisode(EPISODE: Guid): Promise<Array<SubSurgery>> {
        let url: string = '/api/SubSurgeryService/GetByEpisode';
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubSurgery>>(url, input);
        return result;
    }
}