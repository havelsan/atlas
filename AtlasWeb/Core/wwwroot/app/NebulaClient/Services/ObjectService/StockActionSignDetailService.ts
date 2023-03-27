//$BCCF7E41
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SignUserTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';

export class StockActionSignDetailService {
    public static async StockActionSignUsersMethod(signUserTypes: SignUserTypeEnum[]): Promise<Array<StockActionSignDetail>> {
        let url: string = "/api/StockActionSignDetailService/StockActionSignUsersMethod";
        let input = { "signUserTypes": signUserTypes };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockActionSignDetail>>(url, input);
        return result;
    }
}