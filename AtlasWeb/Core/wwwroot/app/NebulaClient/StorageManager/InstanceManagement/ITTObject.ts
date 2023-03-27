import { TTObjectStateTransitionDef } from "../DefinitionManagement/TTObjectStateTransitionDef";
import { TTObjectMemberException } from "./TTObjectPropertyException/TTObjectMemberException";

export interface ITTObject {
    CheckRequiredProperties(): void;
    Delete(): void;
    GetMemberError(memberName: string): TTObjectMemberException;
    GetError(columnName: string): string;
    GetError(): string;
    GetErrors(): string;
    ClearErrors(): void;
    HasErrors: boolean;
    HasOriginal: boolean;
    GetNextStateDefs(): Array<any>;
    GetParent(relationDefName: string): ITTObject;
    GetChildren(relationDefName: string): Array<any>;
    IsNew: boolean;
    IsImported: boolean;
    IsOriginal: boolean;
    IsReadOnly: boolean;
    IsRemoved: boolean;
    IsCancelled: boolean;
    IsDeleted: boolean;
    Original: ITTObject;
    GetDataMemberValue(memberName: string): Object;
    CanBeDeleted: boolean;
    Refresh(): void;
    UndoLastTransition(): void;
    UndoLastTransition(description: string): void;
    Cancel(): void;
    Cancel(description: string): void;
    FindCancelTransition(): TTObjectStateTransitionDef;
    CreateReadAuditRecord(): void;
}