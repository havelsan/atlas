//$A302437A
import { MainStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class MainStoreDefinitionService {
    public static async GetMainStoreDefinition(injectionSQL: string): Promise<Array<MainStoreDefinition.GetMainStoreDefinition_Class>> {
        let url: string = "/api/MainStoreDefinitionService/GetMainStoreDefinition";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<MainStoreDefinition.GetMainStoreDefinition_Class>>(url, input);
        return result;
    }
    public static async GetAllMainStores(): Promise<Array<MainStoreDefinition>> {
        let url: string = "/api/MainStoreDefinitionService/GetAllMainStores";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<MainStoreDefinition>>(url, input);
        return result;
    }
}