//$71456AFF
import { NeHttpService } from "Fw/Services/NeHttpService";
import { RadiologyRejectReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class RadiologyRejectReasonDefinitionService {
    public static async GetRadiologyRejectReasonDefinition(injectionSQL: string): Promise<Array<RadiologyRejectReasonDefinition.GetRadiologyRejectReasonDefinition_Class>> {
        let url: string = "/api/RadiologyRejectReasonDefinitionService/GetRadiologyRejectReasonDefinition";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyRejectReasonDefinition.GetRadiologyRejectReasonDefinition_Class>>(url, input);
        return result;
    }
    public static async GetAll(): Promise<Array<RadiologyRejectReasonDefinition>> {
        let url: string = "/api/RadiologyRejectReasonDefinitionService/GetAll";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyRejectReasonDefinition>>(url, input);
        return result;
    }
}