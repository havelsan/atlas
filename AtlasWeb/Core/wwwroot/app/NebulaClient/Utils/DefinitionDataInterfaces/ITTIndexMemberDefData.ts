import { Guid } from "../../Mscorlib/Guid";

export interface ITTIndexMemberDefData {
    IndexMemberDefID: Guid;
    IndexDefID: Guid;
    MemberID: Guid;
    OrderNo: number;
}