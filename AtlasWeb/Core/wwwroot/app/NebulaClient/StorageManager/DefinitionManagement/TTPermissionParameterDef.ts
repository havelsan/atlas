import { Guid } from "../../Mscorlib/Guid";
import { TTPermissionDef } from "./TTPermissionDef";
import { TTDataType } from "../../DataDictionary/TTDataType";

export class TTPermissionParameterDef {
    public ParameterDefID: Guid;
    public PermissionDef: TTPermissionDef;
    public PermissionDefID: Guid;
    public DataType: TTDataType;
    public DataTypeID: Guid;
    public Name: string;
    public OrderNo: number;
    public ToString(): string {
        return null;
    }
}
