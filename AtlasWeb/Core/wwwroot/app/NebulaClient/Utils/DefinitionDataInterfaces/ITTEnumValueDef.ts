import { Guid } from "../../Mscorlib/Guid";

export interface ITTEnumValueDef {
    DataTypeID: Guid;
    Description: string;
    Name: string;
    Value: number;
    DisplayText: string;
}