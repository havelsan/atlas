//$C63C1E81
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { OrthesisProsthesisProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class OrthesisProsthesisProcedureService {
    public static async GetOrthesisProsthesisProcedureByEpisode(EPISODE: Guid): Promise<Array<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByEpisode_Class>> {
        let url: string = '/api/OrthesisProsthesisProcedureService/GetOrthesisProsthesisProcedureByEpisode';
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByEpisode_Class>>(url, input);
        return result;
    }
    public static async GetOrthesisProsthesisProcedure(OBJECTID: string): Promise<Array<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedure_Class>> {
        let url: string = '/api/OrthesisProsthesisProcedureService/GetOrthesisProsthesisProcedure';
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedure_Class>>(url, input);
        return result;
    }
    public static async GetOrthesisProsthesisProcedureByAction(PARENTACTION: string): Promise<Array<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class>> {
        let url: string = '/api/OrthesisProsthesisProcedureService/GetOrthesisProsthesisProcedureByAction';
        let input = { "PARENTACTION": PARENTACTION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class>>(url, input);
        return result;
    }
    public static async GetOrthesisProthesisByEpisode(EPISODE: Guid): Promise<Array<OrthesisProsthesisProcedure>> {
        let url: string = '/api/OrthesisProsthesisProcedureService/GetOrthesisProthesisByEpisode';
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OrthesisProsthesisProcedure>>(url, input);
        return result;
    }
    public static async GetOrthesisProsthesisProcedureBySubEpisode(SUBEPISODE: string): Promise<Array<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureBySubEpisode_Class>> {
        let url: string = '/api/OrthesisProsthesisProcedureService/GetOrthesisProsthesisProcedureBySubEpisode';
        let input = { "SUBEPISODE": SUBEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureBySubEpisode_Class>>(url, input);
        return result;
    }
    public static async GetOrthesisProthesisBySubEpisode(SUBEPISODE: Guid, EPISODE: string): Promise<Array<OrthesisProsthesisProcedure>> {
        let url: string = '/api/OrthesisProsthesisProcedureService/GetOrthesisProthesisBySubEpisode';
        let input = { "SUBEPISODE": SUBEPISODE, "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OrthesisProsthesisProcedure>>(url, input);
        return result;
    }
}