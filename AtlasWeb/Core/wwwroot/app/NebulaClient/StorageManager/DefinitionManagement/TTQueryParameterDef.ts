import { Guid } from "../../Mscorlib/Guid";
import { TTQueryDef } from "./TTQueryDef";
import { TTDataType } from "../../DataDictionary/TTDataType";

export class TTQueryParameterDef {
    public QueryDef: TTQueryDef;
    public QueryDefID: Guid;
    public ParameterDefID: Guid;
    public Name: string;
    public Description: string;
    public DataType: TTDataType;
    public DataTypeID: Guid;
    public IsArray: boolean;
    public SqlTestValue: string;
    public ToString(): string {
        return null;
    }
}
