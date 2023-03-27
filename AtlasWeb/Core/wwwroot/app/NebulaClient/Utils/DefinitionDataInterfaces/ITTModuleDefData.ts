import { Guid } from "../../Mscorlib/Guid";

export interface ITTModuleDefData {
    ModuleDefID: Guid;
    FolderDefID: Guid;
    Name: string;
    Description: string;
    Version: number;
    PTNodeID: Guid;
    AssemblyDefID: Guid;
}