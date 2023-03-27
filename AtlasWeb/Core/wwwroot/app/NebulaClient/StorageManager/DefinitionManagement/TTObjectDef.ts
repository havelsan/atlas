import { TTObjectDefBase } from "./TTObjectDefBase";
import { Guid } from "../../Mscorlib/Guid";
import { ITTObject } from "../InstanceManagement/ITTObject";
import { TTObject } from "../InstanceManagement/TTObject";
import { TTObjectStateDef } from "./TTObjectStateDef";
import { TTObjectSubTypeEnum } from "../../Utils/Enums/TTObjectSubTypeEnum";
import { TTPermissionDef } from "./TTPermissionDef";
import { TTDefCollection } from "./TTDefCollection";
import { TTObjectPropertyDef } from "./TTObjectPropertyDef";
import { TTObjectCodedPropertyDef } from "./TTObjectCodedPropertyDef";
import { TTObjectRelationDef } from "./TTObjectRelationDef";
import { TTFormDef } from "./TTFormDef";
import { TTQueryDef } from "./TTQueryDef";
import { TTObjectMemberInfo } from "../InstanceManagement/TTObjectMemberInfo";

export class TTObjectDef extends TTObjectDefBase {
    public CanAddDeleteChildren(ttObject: TTObject, memberName: string, canAdd: boolean, canRemove: boolean): void {

    }
    public IsMemberUpdatable(ttObject: ITTObject, memberName: string): boolean {
        return null;
    }
    public ViewName: string;
    public TableName: string;
    public ObjectTableName: string;
    public SubType: TTObjectSubTypeEnum;
    public PermissionDefID: Guid;
    public PermissionDef: TTPermissionDef;
    public GenerateDefaultConstructor: boolean;
    public PreInsert: string;
    public PostInsert: string;
    public PreUpdate: string;
    public PostUpdate: string;
    public PreDelete: string;
    public PostDelete: string;
    public CacheDuration: number;
    public IsAuditEnabled: boolean;
    public IsReadAuditEnabled: boolean;
    public StateDefs: TTDefCollection<TTObjectStateDef>;
    public PropertyDefs: TTDefCollection<TTObjectPropertyDef>;
    public AllPropertyDefs: TTDefCollection<TTObjectPropertyDef>;
    public CodedPropertyDefs: TTDefCollection<TTObjectCodedPropertyDef>;
    public AllCodedPropertyDefs: TTDefCollection<TTObjectCodedPropertyDef>;
    public AllStaticPropertyDefs: TTDefCollection<TTObjectPropertyDef>;
    public ParentRelationDefs: TTDefCollection<TTObjectRelationDef>;
    public AllParentRelationDefs: TTDefCollection<TTObjectRelationDef>;
    public ChildRelationDefs: TTDefCollection<TTObjectRelationDef>;
    public AllChildRelationDefs: TTDefCollection<TTObjectRelationDef>;
   // public AllTransitionDefs: TTReadonlyDictionary<string, TTObjectStateTransitionDef>;
    public FormDefs: TTDefCollection<TTFormDef>;
    public ListFormDefs: TTDefCollection<TTFormDef>;
    public DefinitionFormDefs: TTDefCollection<TTFormDef>;
    public QueryDefs: TTDefCollection<TTQueryDef>;
    // public ParentRelationsSubtypeDefs: TTDefCollection<TTObjectRelationSubtypeDef>;
    // public AllParentRelationsSubtypeDefs: TTDefCollection<TTObjectRelationSubtypeDef>;
    // public AllChildRelationsSubtypeDefs: TTDefCollection<TTObjectRelationSubtypeDef>;
    // public ChildRelationsSubtypeDefs: TTDefCollection<TTObjectRelationSubtypeDef>;
    // public ParentRelationRestrictions: TTDefCollection<TTRelationParentRestrictions>;
    // public ChildRelationRestrictions: TTDefCollection<TTRelationChildRestrictions>;
    // public RemoteMethodDefs: TTDefCollection<TTRemoteMethodDef>;
    // public WebMethodDefs: TTDefCollection<TTWebMethodDef>;
    public GetFormDef(formName?: string, formDefID?: Guid): TTFormDef {
        return null;
    }
    public CheckDataMemberPropertyDef(dataMember: string): void {

    }
    public GetDataMemberPropertyDef(dataMember: string, propDef: TTObjectPropertyDef, codedPropDef: TTObjectCodedPropertyDef): void {

    }
    public static FindCommonBaseObjectDef(sourceObjectDef: TTObjectDef, destinationObjectDef: TTObjectDef): TTObjectDef {
        return null;
    }
    public GetMemberInfo(memberName: string): TTObjectMemberInfo {
        return null;
    }
    public HasMember(memberName: string): boolean {
        return null;
    }
}
