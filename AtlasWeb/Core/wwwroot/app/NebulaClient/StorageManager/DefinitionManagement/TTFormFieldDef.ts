import { Guid } from "../../Mscorlib/Guid";
import { TTDefCollection } from "./TTDefCollection";
import { TTFormFieldEventDef } from "./TTFormFieldEventDef";
import { TTUnboundFormDef } from "./TTUnboundFormDef";

export class TTFormFieldDef {
    public FieldDefID: Guid;
    public FormDef: TTUnboundFormDef;
    public FormDefID: Guid;
    public ParentFieldDef: TTFormFieldDef;
    public ParentFieldDefID: Guid;
    public Name: string;
    public OrderNo: number;
    public ControlClass: string;
    public ControlInterface: string;
    public DataMember: string;
    public ControlProperties: string;
    public EventDefs: TTDefCollection<TTFormFieldEventDef>;
    public IsGrid: boolean;
    public IsGridColumn: boolean;
    public ToString(): string {
        return null;
    }
}
