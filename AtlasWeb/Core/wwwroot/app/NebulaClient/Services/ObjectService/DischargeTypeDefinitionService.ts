//$11A713DF
import { DischargeTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class DischargeTypeDefinitionService {
    public static async GetDischargeTypeDefinitionList(injectionSQL: string): Promise<Array<DischargeTypeDefinition.GetDischargeTypeDefinitionList_Class>> {
        let url: string = "/api/DischargeTypeDefinitionService/GetDischargeTypeDefinitionList";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DischargeTypeDefinition.GetDischargeTypeDefinitionList_Class>>(url, input);
        return result;
    }
}