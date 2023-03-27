//$F35259CA
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ResBuilding } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class ResBuildingService {
    public static async GetSpecialitiesByBuilding(OBJECTID: string): Promise<Array<ResBuilding.GetSpecialitiesByBuilding_Class>> {
        let url: string = "/api/ResBuildingService/GetSpecialitiesByBuilding";
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBuilding.GetSpecialitiesByBuilding_Class>>(url, input);
        return result;
    }
    public static async GetBuildingList(injectionSQL: string): Promise<Array<ResBuilding.GetBuildingList_Class>> {
        let url: string = "/api/ResBuildingService/GetBuildingList";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBuilding.GetBuildingList_Class>>(url, input);
        return result;
    }
}