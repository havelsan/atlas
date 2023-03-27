//$BDD29273
import { NeHttpService } from "Fw/Services/NeHttpService";
import { RadiologyGridEquipmentDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class RadiologyGridEquipmentDefinitionService {
    public static async GetRadGridEquipments(injectionSQL: string): Promise<Array<RadiologyGridEquipmentDefinition>> {
        let url: string = "/api/RadiologyGridEquipmentDefinitionService/GetRadGridEquipments";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyGridEquipmentDefinition>>(url, input);
        return result;
    }
}