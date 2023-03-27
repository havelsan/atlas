import { Guid } from "../../Mscorlib/Guid";
import { ITTDataTypeData } from "./ITTDataTypeData";

export interface ITTQueryParameterDefData {
    QueryDefID: Guid;
    ParameterDefID: Guid;
    Name: string;
    Description: string;
    DataTypeID: Guid;
    DataType: ITTDataTypeData;
    IsArray: boolean;
    SqlTestValue: string;
}