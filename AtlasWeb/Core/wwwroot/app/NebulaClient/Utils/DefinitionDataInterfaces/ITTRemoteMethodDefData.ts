import { Guid } from "../../Mscorlib/Guid";
import { RemoteMethodCallModeEnum } from "../Enums/RemoteMethodCallModeEnum";
import { TTMessagePriorityEnum } from "../Enums/TTMessagePriorityEnum";

export interface ITTRemoteMethodDefData {
    ObjectDefID: Guid;
    RemoteMethodDefID: Guid;
    Name: string;
    Description: string;
    DisplayText: string;
    Body: string;
    CallbackBody: string;
    ReturnType: string;
    CallMode: RemoteMethodCallModeEnum;
    Priority: TTMessagePriorityEnum;
}