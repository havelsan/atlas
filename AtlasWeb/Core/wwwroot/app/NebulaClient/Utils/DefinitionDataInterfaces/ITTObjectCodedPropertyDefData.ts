import { Guid } from "../../Mscorlib/Guid";
import { ITTDataTypeData } from "./ITTDataTypeData";

export interface ITTObjectCodedPropertyDefData {
    ObjectDefID: Guid;
    CodedPropertyDefID: Guid;
    Name: string;
    Description: string;
    DataType: ITTDataTypeData;
    DataTypeID: Guid;
    GetScript: string;
    SetScript: string;
}