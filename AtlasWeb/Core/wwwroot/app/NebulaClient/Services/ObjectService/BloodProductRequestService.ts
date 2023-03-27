//$489D99C6
import { BloodProductRequest } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class BloodProductRequestService {
    public static async SendToBloodBank(bloodProductRequest: BloodProductRequest): Promise<void> {
        let url: string = '/api/BloodProductRequestService/SendToBloodBank';
        let input = { "bloodProductRequest": bloodProductRequest };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    //public static async SaveBloodBankProductToNebula(product: BloodBankProduct): Promise<void> {
    //    let url: string = '/api/BloodProductRequestService/SaveBloodBankProductToNebula';
    //    let input = { "product": product };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<void>(url, input);
    //}
}