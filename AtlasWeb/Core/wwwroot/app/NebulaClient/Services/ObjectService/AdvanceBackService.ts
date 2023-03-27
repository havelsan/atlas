//$3E4304B4
import { AdvanceBack } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class AdvanceBackService {
    public static async GetByEpisode(PARAMEPISODE: string, PARAMSTATE: string): Promise<Array<AdvanceBack>> {
        let url: string = "/api/AdvanceBackService/GetByEpisode";
        let input = { "PARAMEPISODE": PARAMEPISODE, "PARAMSTATE": PARAMSTATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AdvanceBack>>(url, input);
        return result;
    }
}