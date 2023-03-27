import { Guid } from "../../Mscorlib/Guid";
import { TTObjectDef } from "./TTObjectDef";
import { TTObjectRelationDef } from "./TTObjectRelationDef";

export class TTObjectRelationSubtypeDef {
    public RelationSubtypeDefID: Guid;
    public RelationDef: TTObjectRelationDef;
    public RelationDefID: Guid;
    public ChildObjectDef: TTObjectDef;
    public ChildObjectDefID: Guid;
    public ParentObjectDef: TTObjectDef;
    public ParentObjectDefID: Guid;
    public CodeName: string;
    public ParentName: string;
    public ChildrenName: string;
}
