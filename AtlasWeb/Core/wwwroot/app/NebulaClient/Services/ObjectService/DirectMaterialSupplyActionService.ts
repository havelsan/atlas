//$0090F051
import { DirectMaterialSupplyAction } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class DirectMaterialSupplyActionService {
    public static async Send22F_SupplyRequestToXXXXXX_TS(_DirectMaterialSupplyAction: DirectMaterialSupplyAction): Promise<string> {
        let url: string = "/api/DirectMaterialSupplyActionService/Send22F_SupplyRequestToXXXXXX_TS";
        let input = { "_DirectMaterialSupplyAction": _DirectMaterialSupplyAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async GetDirectMatSupplyByXXXXXXId(XXXXXXID: number): Promise<Array<DirectMaterialSupplyAction>> {
        let url: string = "/api/DirectMaterialSupplyActionService/GetDirectMatSupplyByXXXXXXId";
        let input = { "XXXXXXID": XXXXXXID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DirectMaterialSupplyAction>>(url, input);
        return result;
    }
}