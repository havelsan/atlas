//$72EC67FA
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SKRSUlkeKodlari } from 'NebulaClient/Model/AtlasClientModel';

export class SKRSUlkeKodlariService {
    public static async GetSKRSUlkeKodlari(injectionSQL: string): Promise<Array<SKRSUlkeKodlari.GetSKRSUlkeKodlari_Class>> {
        let url: string = "/api/SKRSUlkeKodlariService/GetSKRSUlkeKodlari";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SKRSUlkeKodlari.GetSKRSUlkeKodlari_Class>>(url, input);
        return result;
    }
    public static async GetByMernisKodu(MERNISKODU: string): Promise<Array<SKRSUlkeKodlari>> {
        let url: string = "/api/SKRSUlkeKodlariService/GetByMernisKodu";
        let input = { "MERNISKODU": MERNISKODU };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SKRSUlkeKodlari>>(url, input);
        return result;
    }
}