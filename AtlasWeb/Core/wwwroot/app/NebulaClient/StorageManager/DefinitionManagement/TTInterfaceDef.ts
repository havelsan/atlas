import { Guid } from "../../Mscorlib/Guid";
import { TTModuleDef } from "./TTModuleDef";
import { TTReadonlyDictionary } from "./TTReadonlyDictionary";
import { TTInterfaceMemberDef } from "./TTInterfaceMemberDef";
import { TTDefCollection } from "./TTDefCollection";

export class TTInterfaceDef {
    public ModuleDefID: Guid;
    public ModuleDef: TTModuleDef;
    public ID: Guid;
    public InterfaceDefID: Guid;
    public BaseInterfaceDef: TTInterfaceDef;
    public BaseInterfaceDefID: Guid;
    public Name: string;
    public Methods: string;
    public Description: string;
    public IsBuiltIn: boolean;
    public Members: TTReadonlyDictionary<string, TTInterfaceMemberDef>;
    public AllDerivedInterfaceDefs: TTDefCollection<TTInterfaceDef>;

    /*public IsOfType(interfaceDefName: string): boolean {
        return null;
    }
    public IsOfType(interfaceDefID: Guid): boolean {
        return null;
    }
    public IsOfType(interfaceDef: TTInterfaceDef): boolean {
        return null;
    }*/
    public ToString(): string {
        return null;
    }
}
