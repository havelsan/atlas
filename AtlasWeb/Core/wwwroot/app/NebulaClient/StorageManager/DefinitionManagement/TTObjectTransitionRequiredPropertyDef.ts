import { Guid } from "../../Mscorlib/Guid";
import { TTObjectStateTransitionDef } from "./TTObjectStateTransitionDef";
import { TTObjectPropertyDef } from "./TTObjectPropertyDef";

export class TTObjectTransitionRequiredPropertyDef {
    public StateTransitionDef: TTObjectStateTransitionDef;
    public StateTransitionDefID: Guid;
    public PropertyDef: TTObjectPropertyDef;
    public PropertyDefID: Guid;
}
