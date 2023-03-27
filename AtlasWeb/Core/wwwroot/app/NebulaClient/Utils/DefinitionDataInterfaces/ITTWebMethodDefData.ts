import { Guid } from "../../Mscorlib/Guid";
import { TTWebMethodAuthenticationTypeEnum } from "../Enums/TTWebMethodAuthenticationTypeEnum";
import { RemoteMethodCallModeEnum } from "../Enums/RemoteMethodCallModeEnum";
import { TTWebMethodResourceParameterEnum } from "../Enums/TTWebMethodResourceParameterEnum";
import { TTMessagePriorityEnum } from "../Enums/TTMessagePriorityEnum";

export interface ITTWebMethodDefData {
    ObjectDefID: Guid;
    WebMethodDefID: Guid;
    Name: string;
    Description: string;
    DisplayText: string;
    AuthenticationType: TTWebMethodAuthenticationTypeEnum;
    UserNameParameterName: string;
    PasswordParameterName: string;
    ReturnType: string;
    CallMode: RemoteMethodCallModeEnum;
    Priority: TTMessagePriorityEnum;
    ResourceParameterType: TTWebMethodResourceParameterEnum;
    GenerateProcedureParameter: boolean;
}