import { Guid } from "../../Mscorlib/Guid";
import { TTObjectDef } from "./TTObjectDef";
import { TTDataType } from "../../DataDictionary/TTDataType";

export class TTObjectCodedPropertyDef {
    public ObjectDef: TTObjectDef;
    public ObjectDefID: Guid;
    public CodedPropertyDefID: Guid;
    public Name: string;
    public Description: string;
    public DataType: TTDataType;
    public DataTypeID: Guid;
    public GetScript: string;
    public SetScript: string;
    public ToString(): string {
        return null;
    }
}
