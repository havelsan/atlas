import { Guid } from "../../Mscorlib/Guid";

export interface ITTRemoteMethodParamDef {
    RemoteMethodDefID: Guid;
    ParameterName: string;
    ParameterType: string;
}