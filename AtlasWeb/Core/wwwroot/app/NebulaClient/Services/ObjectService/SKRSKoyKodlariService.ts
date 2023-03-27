//$F607EB4C
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SKRSKoyKodlari } from 'NebulaClient/Model/AtlasClientModel';

export class SKRSKoyKodlariService {
    public static async GetSKRSKoyKodlari(injectionSQL: string): Promise<Array<SKRSKoyKodlari.GetSKRSKoyKodlari_Class>> {
        let url: string = "/api/SKRSKoyKodlariService/GetSKRSKoyKodlari";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SKRSKoyKodlari.GetSKRSKoyKodlari_Class>>(url, input);
        return result;
    }
    public static async GetSKRSKoyKodlariByKodu(KODU: number): Promise<Array<SKRSKoyKodlari>> {
        let url: string = "/api/SKRSKoyKodlariService/GetSKRSKoyKodlariByKodu";
        let input = { "KODU": KODU };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SKRSKoyKodlari>>(url, input);
        return result;
    }
}