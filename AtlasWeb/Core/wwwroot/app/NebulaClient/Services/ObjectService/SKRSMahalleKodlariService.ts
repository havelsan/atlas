//$15F86A93
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SKRSMahalleKodlari } from 'NebulaClient/Model/AtlasClientModel';

export class SKRSMahalleKodlariService {
    public static async GetSKRSMahalleKodlari(injectionSQL: string): Promise<Array<SKRSMahalleKodlari.GetSKRSMahalleKodlari_Class>> {
        let url: string = "/api/SKRSMahalleKodlariService/GetSKRSMahalleKodlari";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SKRSMahalleKodlari.GetSKRSMahalleKodlari_Class>>(url, input);
        return result;
    }
    public static async GetSKRSMahalleKodlariByKodu(KODU: number): Promise<Array<SKRSMahalleKodlari>> {
        let url: string = "/api/SKRSMahalleKodlariService/GetSKRSMahalleKodlariByKodu";
        let input = { "KODU": KODU };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SKRSMahalleKodlari>>(url, input);
        return result;
    }
}