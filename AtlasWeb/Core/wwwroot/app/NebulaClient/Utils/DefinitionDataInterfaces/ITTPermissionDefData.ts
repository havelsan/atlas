import { Guid } from "../../Mscorlib/Guid";

export interface ITTPermissionDefData {
    PermissionDefID: Guid;
    BasePermissionDefID: Guid;
    Name: string;
    InterfaceDefID: Guid;
    Body: string;
}