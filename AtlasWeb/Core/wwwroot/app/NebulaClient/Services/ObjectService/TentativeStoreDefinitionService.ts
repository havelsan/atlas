//$9B3DF39E
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { TentativeStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';

export class TentativeStoreDefinitionService {
    public static async GetTentativeStore(injectionSQL: string): Promise<Array<TentativeStoreDefinition.GetTentativeStore_Class>> {
        let url: string = "/api/TentativeStoreDefinitionService/GetTentativeStore";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<TentativeStoreDefinition.GetTentativeStore_Class>>(url, input);
        return result;
    }
    public static async GetAllTentativeStores(): Promise<Array<TentativeStoreDefinition>> {
        let url: string = "/api/TentativeStoreDefinitionService/GetAllTentativeStores";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<TentativeStoreDefinition>>(url, input);
        return result;
    }
}