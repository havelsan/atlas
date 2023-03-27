//$05777885
import { NeHttpService } from "Fw/Services/NeHttpService";
import { RadiologyGridDepartmentDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class RadiologyGridDepartmentDefinitionService {
    public static async GetRadGridDepartments(injectionSQL: string): Promise<Array<RadiologyGridDepartmentDefinition>> {
        let url: string = "/api/RadiologyGridDepartmentDefinitionService/GetRadGridDepartments";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyGridDepartmentDefinition>>(url, input);
        return result;
    }
}