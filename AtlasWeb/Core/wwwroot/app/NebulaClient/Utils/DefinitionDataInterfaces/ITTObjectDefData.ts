import { Guid } from "../../Mscorlib/Guid";
import { ITTObjectDefBaseData } from "./ITTObjectDefBaseData";
import { TTAuditEnabledEnum } from "../Enums/TTAuditEnabledEnum";
import { ITTObjectStateDefData } from "./ITTObjectStateDefData";
import { ITTObjectRelationDefData } from "./ITTObjectRelationDefData";
import { ITTObjectCodedPropertyDefData } from "./ITTObjectCodedPropertyDefData";
import { ITTObjectPropertyDefData } from "./ITTObjectPropertyDefData";
import { ITTObjectRelationSubtypeDefData } from "./ITTObjectRelationSubtypeDefData";
import { ICollection } from "../../System/Collections/ICollection";
import { IList } from "../../System/Collections/IList";


export interface ITTObjectDefData extends ITTObjectDefBaseData {
    PermissionDefID: Guid;
    GenerateDefaultConstructor: boolean;
    PreInsert: string;
    PostInsert: string;
    PreUpdate: string;
    PostUpdate: string;
    PreDelete: string;
    PostDelete: string;
    ViewName: string;
    TableName: string;
    CacheDuration: number;
    AuditEnabled: TTAuditEnabledEnum;
    PropertyDefs: ICollection<any>;
    StateDefs: ICollection<any>;
    CodedPropertyDefs: ICollection<any>;
    AllParentRelationDefs: ICollection<any>;
    AllPropertyDefs: ICollection<any>;
    AllCodedPropertyDefs: ICollection<any>;
    ParentRelationDefs: ICollection<any>;
    ChildRelationDefs: ICollection<any>;
    AllDerivedObjectDefs: ICollection<any>;
    ChildRelationRestrictions: ICollection<any>;
    ParentRelationRestrictions: ICollection<any>;
    IndexDefs: ICollection<any>;
    GetOverridingStateDefIDs(stateName: string): IList<Guid>;
    GetStateDef(stateName: string): ITTObjectStateDefData;
    GetPropertyDef(propertyName: string): ITTObjectPropertyDefData;
    GetCodedPropertyDef(propertyName: string): ITTObjectCodedPropertyDefData;
    GetChildRelationDef(childrenName: string): ITTObjectRelationDefData;
    GetParentRelationDef(parentName: string): ITTObjectRelationDefData;
    GetChildRelationSubtypeDef(childrenName: string, relationDef: ITTObjectRelationDefData): ITTObjectRelationSubtypeDefData;
    GetParentRelationSubtypeDef(parentName: string, relationDef: ITTObjectRelationDefData): ITTObjectRelationSubtypeDefData;
}