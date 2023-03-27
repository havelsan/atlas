import { Guid } from "../../Mscorlib/Guid";
import { RelationCardinalityEnum } from "../Enums/RelationCardinalityEnum";
import { ITTObjectDefData } from "./ITTObjectDefData";

export interface ITTObjectRelationDefData {
    RelationDefID: Guid;
    Description: string;
    Cardinality: RelationCardinalityEnum;
    ParentName: string;
    ChildrenName: string;
    ParentCaption: string;
    ChildrenCaption: string;
    CodeName: string;
    IsEmbedded: boolean;
    ParentObjectDefID: Guid;
    GetParentObjectDef(): ITTObjectDefData;
    ChildObjectDefID: Guid;
    GetChildObjectDef(): ITTObjectDefData;
    OverridesRelationDefID: Guid;
    GetRootRelationDef(): ITTObjectRelationDefData;
    IsParentRequired: boolean;
    IsProtected: boolean;
    IsDynamic: boolean;
    IsNoLock: boolean;
    SetParentScript: string;
    SortChildrenByPropertyID: Guid;
}