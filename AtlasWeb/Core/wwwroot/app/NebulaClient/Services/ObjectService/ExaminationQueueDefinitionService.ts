//$F79A0403
import { ExaminationQueueDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { Resource } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class ExaminationQueueDefinitionService {
    public static async GetWorkingResourcesByQueueID(queueID: Guid): Promise<Array<Resource>> {
        let url: string = "/api/ExaminationQueueDefinitionService/GetWorkingResourcesByQueueID";
        let input = { "queueID": queueID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Resource>>(url, input);
        return result;
    }
    public static async GetWorkingResources(examinationQueueDefinition: ExaminationQueueDefinition): Promise<Array<Resource>> {
        let url: string = "/api/ExaminationQueueDefinitionService/GetWorkingResources";
        let input = { "examinationQueueDefinition": examinationQueueDefinition };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Resource>>(url, input);
        return result;
    }
    public static async GetMyExaminationQueueDefs(WindowsUserName: string): Promise<Array<ExaminationQueueDefinition>> {
        let url: string = "/api/ExaminationQueueDefinitionService/GetMyExaminationQueueDefs";
        let input = { "WindowsUserName": WindowsUserName };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueDefinition>>(url, input);
        return result;
    }
    public static async GetExaminationQueueDefs(injectionSQL: string): Promise<Array<ExaminationQueueDefinition>> {
        let url: string = "/api/ExaminationQueueDefinitionService/GetExaminationQueueDefs";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueDefinition>>(url, input);
        return result;
    }
    public static async GetQueueByResource(RESOURCE: string): Promise<Array<ExaminationQueueDefinition>> {
        let url: string = "/api/ExaminationQueueDefinitionService/GetQueueByResource";
        let input = { "RESOURCE": RESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueDefinition>>(url, input);
        return result;
    }
    public static async GetExaminationQueues(injectionSQL: string): Promise<Array<ExaminationQueueDefinition.GetExaminationQueues_Class>> {
        let url: string = "/api/ExaminationQueueDefinitionService/GetExaminationQueues";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueDefinition.GetExaminationQueues_Class>>(url, input);
        return result;
    }
    public static async GetEmergencyQueues(): Promise<Array<ExaminationQueueDefinition>> {
        let url: string = "/api/ExaminationQueueDefinitionService/GetEmergencyQueues";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueDefinition>>(url, input);
        return result;
    }
    public static async GetQueuesByResources(RESOURCES: Array<Guid>): Promise<Array<ExaminationQueueDefinition>> {
        let url: string = "/api/ExaminationQueueDefinitionService/GetQueuesByResources";
        let input = { "RESOURCES": RESOURCES };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueDefinition>>(url, input);
        return result;
    }
}