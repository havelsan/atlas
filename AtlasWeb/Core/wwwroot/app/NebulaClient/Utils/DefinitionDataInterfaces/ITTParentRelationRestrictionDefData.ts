import { Guid } from "../../Mscorlib/Guid";
import { ITTRelationRestrictionDefData } from "./ITTRelationRestrictionDefData";

export interface ITTParentRelationRestrictionDefData extends ITTRelationRestrictionDefData {
    RelationDefID: Guid;
}