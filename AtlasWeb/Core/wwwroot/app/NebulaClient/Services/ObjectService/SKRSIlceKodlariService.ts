//$3C57E73B
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SKRSIlceKodlari } from 'NebulaClient/Model/AtlasClientModel';

export class SKRSIlceKodlariService {
    public static async GetSKRSIlceKodlari(injectionSQL: string): Promise<Array<SKRSIlceKodlari.GetSKRSIlceKodlari_Class>> {
        let url: string = "/api/SKRSIlceKodlariService/GetSKRSIlceKodlari";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SKRSIlceKodlari.GetSKRSIlceKodlari_Class>>(url, input);
        return result;
    }
    public static async GetSKRSIlceKodlariByKodu(KODU: number): Promise<Array<SKRSIlceKodlari>> {
        let url: string = "/api/SKRSIlceKodlariService/GetSKRSIlceKodlariByKodu";
        let input = { "KODU": KODU };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SKRSIlceKodlari>>(url, input);
        return result;
    }
}