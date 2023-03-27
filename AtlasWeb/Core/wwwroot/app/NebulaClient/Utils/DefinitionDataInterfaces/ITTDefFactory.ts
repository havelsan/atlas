import { Guid } from "../../Mscorlib/Guid";
import { ITTObjectDefBaseData } from "./ITTObjectDefBaseData";
import { ITTDataTypeData } from "./ITTDataTypeData";

export interface ITTDefFactory {
    GetObjectDef(objectDefID: Guid): ITTObjectDefBaseData;
    GetObjectDef(objectDefName: string): ITTObjectDefBaseData;
    GetDataType(dataTypeID: Guid): ITTDataTypeData;
    GetDataType(dataTypeName: string): ITTDataTypeData;
}