import { Guid } from "../../Mscorlib/Guid";
import { TTListDef } from "./TTListDef";
import { TTObjectPropertyDef } from "./TTObjectPropertyDef";
import { TTObjectCodedPropertyDef } from "./TTObjectCodedPropertyDef";

export class TTListColumnDef {
    public ListDef: TTListDef;
    public ListDefID: Guid;
    public ListColumnDefID: Guid;
    public PropertyDef: TTObjectPropertyDef;
    public CodedPropertyDef: TTObjectCodedPropertyDef;
    public MemberName: string;
    public Caption: string;
    public ColumnOrder: number;
    public ColumnWidth: number;
    public ToString(): string {
        return null;
    }
}
