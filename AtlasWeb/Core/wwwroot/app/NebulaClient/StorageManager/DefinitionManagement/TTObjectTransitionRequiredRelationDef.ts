import { TTObjectStateTransitionDef } from "./TTObjectStateTransitionDef";
import { TTObjectRelationDef } from "./TTObjectRelationDef";
import { Guid } from "../../Mscorlib/Guid";

export class TTObjectTransitionRequiredRelationDef {
    public StateTransitionDef: TTObjectStateTransitionDef;
    public StateTransitionDefID: Guid;
    public RelationDef: TTObjectRelationDef;
    public RelationDefID: Guid;
}
