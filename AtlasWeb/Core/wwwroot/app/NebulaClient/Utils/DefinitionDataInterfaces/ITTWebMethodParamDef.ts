import { Guid } from "../../Mscorlib/Guid";

export interface ITTWebMethodParamDef {
    WebMethodDefID: Guid;
    ParameterName: string;
    ParameterType: string;
}