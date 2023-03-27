import { Guid } from "../../Mscorlib/Guid";

export interface ITTPermissionParameterDefData {
    ParameterDefID: Guid;
    PermissionDefID: Guid;
    DataTypeID: Guid;
    OrderNo: number;
    Name: string;
}