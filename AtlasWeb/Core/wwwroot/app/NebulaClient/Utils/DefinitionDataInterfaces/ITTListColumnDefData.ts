import { Guid } from "../../Mscorlib/Guid";

export interface ITTListColumnDefData {
    ListColumnDefID: Guid;
    ListDefID: Guid;
    MemberName: string;
    Caption: string;
    ColumnOrder: number;
    ColumnWidth: number;
}