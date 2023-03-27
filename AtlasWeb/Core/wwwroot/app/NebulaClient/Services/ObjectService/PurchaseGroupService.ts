//$4EE7CDA6
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { PurchaseGroup } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class PurchaseGroupService {
    public static async GetPurchaseGroupList(injectionSQL: string): Promise<Array<PurchaseGroup.GetPurchaseGroupList_Class>> {
        let url: string = "/api/PurchaseGroupService/GetPurchaseGroupList";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PurchaseGroup.GetPurchaseGroupList_Class>>(url, input);
        return result;
    }
}