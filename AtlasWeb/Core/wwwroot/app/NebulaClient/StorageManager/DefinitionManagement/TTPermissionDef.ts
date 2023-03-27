import { Guid } from "../../Mscorlib/Guid";
import { TTModuleDef } from "./TTModuleDef";
import { TTInterfaceDef } from "./TTInterfaceDef";
import { TTDefCollection } from "./TTDefCollection";
import { TTPermissionParameterDef } from "./TTPermissionParameterDef";

export class TTPermissionDef {
    public ModuleDefID: Guid;
    public ModuleDef: TTModuleDef;
    public ID: Guid;
    //public SecurityAuthority: TTSecurityAuthority;
    public PermissionDefID: Guid;
    public CodeName: string;
    public Name: string;
    public InterfaceDef: TTInterfaceDef;
    public InterfaceDefID: Guid;
    public BasePermissionDef: TTPermissionDef;
    public BasePermissionDefID: Guid;
    public Body: string;
    public ParameterDefs: TTDefCollection<TTPermissionParameterDef>;
    public AllParameterDefs: TTDefCollection<TTPermissionParameterDef>;
    //public RightDefs: TTDualKeyCollection<number, string, TTRightDef>;
    public ToString(): string {
        return null;
    }
}
