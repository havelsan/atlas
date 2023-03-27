//$1DB9065E
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { TedaviTuru } from 'NebulaClient/Model/AtlasClientModel';

export class TedaviTuruService {
    public static async GetTedaviTuru(tedaviTuruKodu: string): Promise<TedaviTuru> {
        let url: string = "/api/TedaviTuruService/GetTedaviTuru";
        let input = { "tedaviTuruKodu": tedaviTuruKodu };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<TedaviTuru>(url, input);
        return result;
    }
    public static async GetTedaviTuruByCode(TEDAVITURUKODU: string): Promise<Array<TedaviTuru>> {
        let url: string = "/api/TedaviTuruService/GetTedaviTuruByCode";
        let input = { "TEDAVITURUKODU": TEDAVITURUKODU };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<TedaviTuru>>(url, input);
        return result;
    }
    public static async Olap_GetTedaviTuruDef(): Promise<Array<TedaviTuru.Olap_GetTedaviTuruDef_Class>> {
        let url: string = "/api/TedaviTuruService/Olap_GetTedaviTuruDef";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<TedaviTuru.Olap_GetTedaviTuruDef_Class>>(url, input);
        return result;
    }
    public static async GetTedaviTuruDefinitionQuery(injectionSQL: string): Promise<Array<TedaviTuru.GetTedaviTuruDefinitionQuery_Class>> {
        let url: string = "/api/TedaviTuruService/GetTedaviTuruDefinitionQuery";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<TedaviTuru.GetTedaviTuruDefinitionQuery_Class>>(url, input);
        return result;
    }
}