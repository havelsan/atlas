import { Guid } from "../../Mscorlib/Guid";

export interface ITTFolderDefData {
    FolderDefID: Guid;
    ParentFolderDefID: Guid;
    Name: string;
    Description: string;
    PTNodeID: Guid;
}