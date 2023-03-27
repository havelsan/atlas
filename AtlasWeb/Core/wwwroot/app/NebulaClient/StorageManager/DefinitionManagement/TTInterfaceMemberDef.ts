import { Guid } from "../../Mscorlib/Guid";
import { TTInterfaceDef } from "./TTInterfaceDef";

export class TTInterfaceMemberDef {
    public InterfaceDef: TTInterfaceDef;
    public InterfaceDefID: Guid;
    public Name: string;
    public Description: string;
    public CodeType: string;
    public IsReadOnly: boolean;
    public ToString(): string {
        return null;
    }
}
