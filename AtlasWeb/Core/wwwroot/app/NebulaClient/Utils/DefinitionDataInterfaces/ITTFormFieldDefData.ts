import { Guid } from "../../Mscorlib/Guid";

export interface ITTFormFieldDefData {
    FieldDefID: Guid;
    FormDefID: Guid;
    OrderNo: number;
    ControlClass: string;
    DataMember: string;
    ControlProperties: string;
    Name: string;
    ParentFieldDefID: Guid;
}