//$9AF44FC9
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { SupplyRequestPool } from 'NebulaClient/Model/AtlasClientModel';

export class SupplyRequestPoolService {
    public static async SendSupplyRequestPoolToXXXXXX_TS(supplyRequestPool: SupplyRequestPool): Promise<string> {
        let url: string = "/api/SupplyRequestPoolService/SendSupplyRequestPoolToXXXXXX_TS";
        let input = { "supplyRequestPool": supplyRequestPool };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
}