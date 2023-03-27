//$A6E0CD46
import { CompanionApplication } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class CompanionApplicationService {
    public static async GetCompanionApplicationByEpisode(EPISODE: string): Promise<Array<CompanionApplication.GetCompanionApplicationByEpisode_Class>> {
        let url: string = "/api/CompanionApplicationService/GetCompanionApplicationByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<CompanionApplication.GetCompanionApplicationByEpisode_Class>>(url, input);
        return result;
    }
    public static async GetCompanionApplicationBySubEpisode(SUBEPISODE: string, EPISODE: string): Promise<Array<CompanionApplication.GetCompanionApplicationBySubEpisode_Class>> {
        let url: string = "/api/CompanionApplicationService/GetCompanionApplicationBySubEpisode";
        let input = { "SUBEPISODE": SUBEPISODE, "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<CompanionApplication.GetCompanionApplicationBySubEpisode_Class>>(url, input);
        return result;
    }
    public static async CompanionApplicationFormList(EPISODE: Guid): Promise<Array<CompanionApplication.CompanionApplicationFormList_Class>> {
        let url: string = "/api/CompanionApplicationService/CompanionApplicationFormList";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<CompanionApplication.CompanionApplicationFormList_Class>>(url, input);
        return result;
    }
}