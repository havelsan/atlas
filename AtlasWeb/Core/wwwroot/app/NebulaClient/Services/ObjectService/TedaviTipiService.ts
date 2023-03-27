//$6681A3D5
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { TedaviTipi } from 'NebulaClient/Model/AtlasClientModel';

export class TedaviTipiService {
    public static async GetTedaviTipi(tedaviTipiKodu: string): Promise<TedaviTipi> {
        let url: string = "/api/TedaviTipiService/GetTedaviTipi";
        let input = { "tedaviTipiKodu": tedaviTipiKodu };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<TedaviTipi>(url, input);
        return result;
    }
    public static async GetTedaviTipiByTedaviTipiKodu(TEDAVITIPIKODU: string): Promise<Array<TedaviTipi>> {
        let url: string = "/api/TedaviTipiService/GetTedaviTipiByTedaviTipiKodu";
        let input = { "TEDAVITIPIKODU": TEDAVITIPIKODU };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<TedaviTipi>>(url, input);
        return result;
    }
    public static async GetTedaviTipiNql(): Promise<Array<TedaviTipi.GetTedaviTipiNql_Class>> {
        let url: string = "/api/TedaviTipiService/GetTedaviTipiNql";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<TedaviTipi.GetTedaviTipiNql_Class>>(url, input);
        return result;
    }
    public static async GetTedaviTipiDefinitionQuery(injectionSQL: string): Promise<Array<TedaviTipi.GetTedaviTipiDefinitionQuery_Class>> {
        let url: string = "/api/TedaviTipiService/GetTedaviTipiDefinitionQuery";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<TedaviTipi.GetTedaviTipiDefinitionQuery_Class>>(url, input);
        return result;
    }
}