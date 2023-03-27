//$99BA40A2
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { SystemForDisabledReportDefinition } from 'NebulaClient/Model/AtlasClientModel';

export class SystemForDisabledReportDefinitionService {
    public static async GetAllSystemForDisabledReportDef(): Promise<Array<SystemForDisabledReportDefinition>> {
        let url: string = "/api/SystemForDisabledReportDefinitionService/GetAllSystemForDisabledReportDef";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SystemForDisabledReportDefinition>>(url, input);
        return result;
    }
    public static async GetSystemForDisabledReportDef(injectionSQL: string): Promise<Array<SystemForDisabledReportDefinition.GetSystemForDisabledReportDef_Class>> {
        let url: string = "/api/SystemForDisabledReportDefinitionService/GetSystemForDisabledReportDef";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SystemForDisabledReportDefinition.GetSystemForDisabledReportDef_Class>>(url, input);
        return result;
    }
}