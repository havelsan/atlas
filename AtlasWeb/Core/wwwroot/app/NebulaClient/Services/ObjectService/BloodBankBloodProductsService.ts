//$404A868D
import { BloodBankBloodProducts } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class BloodBankBloodProductsService {
    public static async GetBloodProductBySubEpisode(SUBEPISODE: Guid, EPISODE: string): Promise<Array<BloodBankBloodProducts.GetBloodProductBySubEpisode_Class>> {
        let url: string = '/api/BloodBankBloodProductsService/GetBloodProductBySubEpisode';
        let input = { "SUBEPISODE": SUBEPISODE, "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BloodBankBloodProducts.GetBloodProductBySubEpisode_Class>>(url, input);
        return result;
    }
    public static async GetExpiredBloodProductsToCancel(CHECKDATE: Date): Promise<Array<BloodBankBloodProducts>> {
        let url: string = '/api/BloodBankBloodProductsService/GetExpiredBloodProductsToCancel';
        let input = { "CHECKDATE": CHECKDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BloodBankBloodProducts>>(url, input);
        return result;
    }
    public static async GetBloodProductByEpisode(EPISODE: Guid): Promise<Array<BloodBankBloodProducts.GetBloodProductByEpisode_Class>> {
        let url: string = '/api/BloodBankBloodProductsService/GetBloodProductByEpisode';
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BloodBankBloodProducts.GetBloodProductByEpisode_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetBloodProducts(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<BloodBankBloodProducts.OLAP_GetBloodProducts_Class>> {
        let url: string = '/api/BloodBankBloodProductsService/OLAP_GetBloodProducts';
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BloodBankBloodProducts.OLAP_GetBloodProducts_Class>>(url, input);
        return result;
    }
    public static async GetExpiredBloodProducts(CHECKDATE: Date): Promise<Array<BloodBankBloodProducts>> {
        let url: string = '/api/BloodBankBloodProductsService/GetExpiredBloodProducts';
        let input = { "CHECKDATE": CHECKDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BloodBankBloodProducts>>(url, input);
        return result;
    }
}