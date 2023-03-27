//$725B6488
import { NeHttpService } from "Fw/Services/NeHttpService";
import { RadiologyRepeatReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class RadiologyRepeatReasonDefinitionService {
    public static async GetAll(): Promise<Array<RadiologyRepeatReasonDefinition>> {
        let url: string = "/api/RadiologyRepeatReasonDefinitionService/GetAll";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyRepeatReasonDefinition>>(url, input);
        return result;
    }
    public static async GetRadiologyRepeatReasonDefinition(injectionSQL: string): Promise<Array<RadiologyRepeatReasonDefinition.GetRadiologyRepeatReasonDefinition_Class>> {
        let url: string = "/api/RadiologyRepeatReasonDefinitionService/GetRadiologyRepeatReasonDefinition";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyRepeatReasonDefinition.GetRadiologyRepeatReasonDefinition_Class>>(url, input);
        return result;
    }
}