//$25D3B367
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SKRSAdresKoduSeviyesi } from 'NebulaClient/Model/AtlasClientModel';

export class SKRSAdresKoduSeviyesiService {
    public static async GetByKodu(KODU: string, injectionSQL: string): Promise<Array<SKRSAdresKoduSeviyesi>> {
        let url: string = "/api/SKRSAdresKoduSeviyesiService/GetByKodu";
        let input = { "KODU": KODU, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SKRSAdresKoduSeviyesi>>(url, input);
        return result;
    }
    public static async GetSKRSAdresKoduSByKodu(KODU: string): Promise<Array<SKRSAdresKoduSeviyesi>> {
        let url: string = "/api/SKRSAdresKoduSeviyesiService/GetSKRSAdresKoduSByKodu";
        let input = { "KODU": KODU };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SKRSAdresKoduSeviyesi>>(url, input);
        return result;
    }
    public static async GetSKRSAdresKoduSeviyesi(injectionSQL: string): Promise<Array<SKRSAdresKoduSeviyesi.GetSKRSAdresKoduSeviyesi_Class>> {
        let url: string = "/api/SKRSAdresKoduSeviyesiService/GetSKRSAdresKoduSeviyesi";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SKRSAdresKoduSeviyesi.GetSKRSAdresKoduSeviyesi_Class>>(url, input);
        return result;
    }
}