//$CDCFB980
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { Resource } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { Store } from 'NebulaClient/Model/AtlasClientModel';

export class ResourceService {
    public static async GetStore(OBJECTID: string): Promise<Store> {
        let url: string = "/api/ResourceService/GetStore";
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Store>(url, input);
        return result;
    }
    public static async GetResource(OBJECTID: string): Promise<Array<Resource>> {
        let url: string = "/api/ResourceService/GetResource";
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Resource>>(url, input);
        return result;
    }
    public static async GetResources(injectionSQL: string): Promise<Array<Resource>> {
        let url: string = "/api/ResourceService/GetResources";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Resource>>(url, input);
        return result;
    }
    public static async GetResourcesForQueueInDate(QUEUE: Guid, WORKDATE: Date): Promise<Array<Resource>> {
        let url: string = "/api/ResourceService/GetResourcesForQueueInDate";
        let input = { "QUEUE": QUEUE, "WORKDATE": WORKDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Resource>>(url, input);
        return result;
    }
    public static async GetResourceByStore(STOREID: Guid): Promise<Array<Resource>> {
        let url: string = "/api/ResourceService/GetResourceByStore";
        let input = { "STOREID": STOREID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Resource>>(url, input);
        return result;
    }
}