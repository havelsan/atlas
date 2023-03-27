import { Guid } from "../../Mscorlib/Guid";
import { TTAssemblyDef } from "./TTAssemblyDef";

export class TTModuleDef {
    public ModuleDefID: Guid;
    public FolderDefID: Guid;
    public Name: string;
    public Description: string;
    public Version: number;
    public AssemblyDefID: Guid;
    public AssemblyDef: TTAssemblyDef;
    public PTNodeID: Guid;
    public LastBuildDate: Date;
    public ToString(): string {
        return null;
    }
}
