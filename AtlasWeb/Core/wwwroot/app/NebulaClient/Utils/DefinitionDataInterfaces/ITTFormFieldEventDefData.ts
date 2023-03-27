import { Guid } from "../../Mscorlib/Guid";

export interface ITTFormFieldEventDefData {
    EventDefID: Guid;
    FieldDefID: Guid;
    Name: string;
    Body: string;
}