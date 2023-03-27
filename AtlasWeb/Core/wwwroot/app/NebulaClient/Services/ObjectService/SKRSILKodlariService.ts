//$5A80DBD0
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SKRSILKodlari } from 'NebulaClient/Model/AtlasClientModel';

export class SKRSILKodlariService {
    public static async GetSKRSIlKodlariByKodu(KODU: number): Promise<Array<SKRSILKodlari>> {
        let url: string = "/api/SKRSILKodlariService/GetSKRSIlKodlariByKodu";
        let input = { "KODU": KODU };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SKRSILKodlari>>(url, input);
        return result;
    }
    public static async GetSKRSILKodlari(injectionSQL: string): Promise<Array<SKRSILKodlari.GetSKRSILKodlari_Class>> {
        let url: string = "/api/SKRSILKodlariService/GetSKRSILKodlari";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SKRSILKodlari.GetSKRSILKodlari_Class>>(url, input);
        return result;
    }
}