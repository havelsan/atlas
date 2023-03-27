import { Guid } from "../../Mscorlib/Guid";

export interface ITTRelationRestrictionDefData {
    RestrictionDefID: Guid;
    ObjectDefID: Guid;
    RestrictedObjectDefID: Guid;
    IsParent: boolean;
}