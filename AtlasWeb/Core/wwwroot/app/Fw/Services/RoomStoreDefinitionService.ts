import { Guid } from "NebulaClient/Mscorlib/Guid";
import { TTObjectContext } from "NebulaClient/StorageManager/InstanceManagement/TTObjectContext";
import { RoomStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';

export class RoomStoreDefinitionService {
    public static GetParentStoreByRoomStore(objectContext: TTObjectContext, STOREID: Guid): Array<RoomStoreDefinition> {
        return null;
    }
}