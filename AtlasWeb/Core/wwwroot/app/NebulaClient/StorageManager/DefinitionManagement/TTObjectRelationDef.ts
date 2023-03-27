import { Guid } from "../../Mscorlib/Guid";
import { IDictionary } from "../../System/Collections/Dictionaries/IDictionary";
import { TTObjectDef } from "./TTObjectDef";
import { RelationCardinalityEnum } from "../../Utils/Enums/RelationCardinalityEnum";
import { TTObjectPropertyDef } from "./TTObjectPropertyDef";
import { TTDefCollection } from "./TTDefCollection";
import { TTObjectRelationSubtypeDef } from "./TTObjectRelationSubtypeDef";
import { TTObjectStateDef } from "./TTObjectStateDef";

export class TTObjectRelationDef {
    public RelationDefID: Guid;
    public CodeName: string;
    public Description: string;
    public ParentCaption: string;
    public ChildrenCaption: string;
    public SetParentScript: string;
    public ParentName: string;
    public ChildrenName: string;
    public IsEmbedded: boolean;
    public Cardinality: RelationCardinalityEnum;
    public ParentObjectDef: TTObjectDef;
    public ParentObjectDefID: Guid;
    public ChildObjectDef: TTObjectDef;
    public ChildObjectDefID: Guid;
    public OverridesRelationDef: TTObjectRelationDef;
    public OverridesRelationDefID: Guid;
    public IsParentRequired: boolean;
    public IsDynamic: boolean;
    public IsProtected: boolean;
    public IsNoLock: boolean;
    public SortChildrenByProperty: TTObjectPropertyDef;
    public SortChildrenByPropertyID: Guid;
    public SubtypeDefs: TTDefCollection<TTObjectRelationSubtypeDef>;
    //public PropertyPropagationDefs: ReadOnlyCollection<TTPropertyPropagationDef>;
    //public RelationPropagationDefs: ReadOnlyCollection<TTRelationPropagationDef>;
    //public ParentPropagations: ReadOnlyCollection<TTRelationPropagationDef>;
    //public ChildPropagations: ReadOnlyCollection<TTRelationPropagationDef>;
    public RootRelationDef: TTObjectRelationDef;
    public AllMemberNames: string[];
    public IsProtectedOnState(stateDef: TTObjectStateDef): boolean {
        return null;
    }
    public GetAllOverridingRelationDefs(): IDictionary<Guid, TTObjectRelationDef> {
        return null;
    }
    public ToString(): string {
        return null;
    }
}
