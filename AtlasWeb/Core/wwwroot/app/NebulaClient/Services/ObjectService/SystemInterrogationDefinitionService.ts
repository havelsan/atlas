//$3B0F4E9F
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { SystemInterrogationDefinition } from 'NebulaClient/Model/AtlasClientModel';

export class SystemInterrogationDefinitionService {
    public static async GetSystemInterrogationDefinitionList(injectionSQL: string): Promise<Array<SystemInterrogationDefinition.GetSystemInterrogationDefinitionList_Class>> {
        let url: string = '/api/SystemInterrogationDefinitionService/GetSystemInterrogationDefinitionList';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SystemInterrogationDefinition.GetSystemInterrogationDefinitionList_Class>>(url, input);
        return result;
    }
}