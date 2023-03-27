import { Guid } from "../../Mscorlib/Guid";
import { TTObjectStateDef } from "../DefinitionManagement/TTObjectStateDef";

export class TTObjectState {
    public ObjectID: Guid;
    public StateDefID: Guid;
    public StateDef: TTObjectStateDef;
    public IsUndo: boolean;
    public BranchDateTimeTick: number;
    public BranchDate: Date;
    public PrevState: TTObjectState;
    public Description: string;
    public UserID: Guid;
    //public User: TTUser;
}
