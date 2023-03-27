import { ITTRelationRestrictionDefData } from "./ITTRelationRestrictionDefData";
import { Guid } from "../../Mscorlib/Guid";

export interface ITTChildRelationRestrictionDefData extends ITTRelationRestrictionDefData {
    RelationDefID: Guid;
}