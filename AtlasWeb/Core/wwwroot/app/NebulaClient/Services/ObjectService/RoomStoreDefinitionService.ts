//$8B86D181
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { RoomStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class RoomStoreDefinitionService {
    public static async GetRoomStore(injectionSQL: string): Promise<Array<RoomStoreDefinition.GetRoomStore_Class>> {
        let url: string = "/api/RoomStoreDefinitionService/GetRoomStore";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RoomStoreDefinition.GetRoomStore_Class>>(url, input);
        return result;
    }
    public static async GetParentStoreByRoomStore(STOREID: Guid): Promise<Array<RoomStoreDefinition>> {
        let url: string = "/api/RoomStoreDefinitionService/GetParentStoreByRoomStore";
        let input = { "STOREID": STOREID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RoomStoreDefinition>>(url, input);
        return result;
    }
}