import { Guid } from "../../Mscorlib/Guid";
import { ITTObjectDefData } from "./ITTObjectDefData";

export interface ITTObjectRelationSubtypeDefData {
    RelationSubtypeDefID: Guid;
    RelationDefID: Guid;
    ParentObjectDefID: Guid;
    ChildObjectDefID: Guid;
    ParentName: string;
    ChildrenName: string;
    GetParentObjectDef(): ITTObjectDefData;
    GetChildObjectDef(): ITTObjectDefData;
}