import { Guid } from "../../Mscorlib/Guid";

export interface ITTRelationPropagationDefData {
    RelationDefID: Guid;
    ChildRelationDefID: Guid;
    ParentRelationDefID: Guid;
}