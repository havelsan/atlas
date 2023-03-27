import { Guid } from "../../Mscorlib/Guid";

export interface ITTPermissionData {
    PermissionID: Guid;
    SecurityID: Guid;
    SubSecurityID: Guid;
    RoleID: Guid;
    RightDefID: number;
    PermissionDefID: Guid;
    Parameters: string;
}