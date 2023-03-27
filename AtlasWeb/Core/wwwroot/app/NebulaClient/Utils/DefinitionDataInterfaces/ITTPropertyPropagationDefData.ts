import { Guid } from "../../Mscorlib/Guid";

export interface ITTPropertyPropagationDefData {
    RelationDefID: Guid;
    RelationSubtypeDefID: Guid;
    ParentPropertyDefID: Guid;
    ChildPropertyDefID: Guid;
}