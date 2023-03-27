import { Guid } from "../../Mscorlib/Guid";
import { TTDefCollection } from "./TTDefCollection";
/*[Serializable]*/
export class TTAssemblyDef {
    public AssemblyDefID: Guid;
    public Name: string;
    public Description: string;
    public Version: number;
    public LastBuildDate: Date;
    public AssemblyReferenceDefs: TTDefCollection<TTAssemblyDef>;
    public ReferencedByAssemblyDefs: TTDefCollection<TTAssemblyDef>;
    public ToString(): string {
        return (this.Name !== null ? this.Name : "");
    }
}