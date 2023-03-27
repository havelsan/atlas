import { Guid } from "../../Mscorlib/Guid";
import { TTModuleDef } from "./TTModuleDef";
import { TTPermissionDef } from "./TTPermissionDef";
import { TTDefCollection } from "./TTDefCollection";
import { TTFormFieldDef } from "./TTFormFieldDef";

export class TTUnboundFormDef {
    public ModuleDefID: Guid;
    public ModuleDef: TTModuleDef;
    public ID: Guid;
    public PermissionDefID: Guid;
    public PermissionDef: TTPermissionDef;
    public FormDefID: Guid;
    public Name: string;
    public NameSpace: string;
    public Description: string;
    public Caption: string;
    public ApplicationName: string;
    public FormNO: string;
    public HelpNameSpace: string;
    public BaseFormDef: TTUnboundFormDef;
    public BaseFormDefID: Guid;
    public Width: number;
    public Height: number;
    public Methods: string;
    public ClientSideMethods: string;
    public DifferenceXML: string;
    public FieldDefs: TTDefCollection<TTFormFieldDef>;
    public ToString(): string {
        return null;
    }
    public GetFieldDef(fieldNameorID: Object): TTFormFieldDef {
        return null;
    }
}
