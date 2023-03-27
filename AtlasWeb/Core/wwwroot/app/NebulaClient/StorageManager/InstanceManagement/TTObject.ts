import { Guid } from '../../Mscorlib/Guid';
import { ITTObject } from './ITTObject';
import { TTObjectDef } from '../DefinitionManagement/TTObjectDef';
import { TTObjectStateDef } from '../DefinitionManagement/TTObjectStateDef';
import { TTObjectState } from './TTObjectState';
import { TTObjectStateTransitionDef } from '../DefinitionManagement/TTObjectStateTransitionDef';
import { TTObjectRelationDef } from '../DefinitionManagement/TTObjectRelationDef';
import { TTObjectPropertyDef } from '../DefinitionManagement/TTObjectPropertyDef';
import { TTObjectMemberInfo } from './TTObjectMemberInfo';
import { TTObjectContext } from './TTObjectContext';
import { TTObjectMemberException } from './TTObjectPropertyException/TTObjectMemberException';
import { Exclude, Expose } from 'NebulaClient/ClassTransformer';
import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';

export class TTObject implements ITTObject {

    constructor(objectContext?: TTObjectContext) {
    }

    public TransDef: TTObjectStateTransitionDef;
    public ObjectID: Guid;
    public ObjectDefID: Guid;
    public ObjectDef: TTObjectDef;
    public OriginalValues: any;
    public EQUIVALENTCRC:Guid;

    @Exclude()
    private _entityState: EntityStateEnum;

    @Expose({ name: 'EntityState' })
    public set EntityState(value: EntityStateEnum) {
        this._entityState = value;
    }
    public get EntityState(): EntityStateEnum {
        return this._entityState;
    }

    @Exclude()
    private _currentStateDefID: Guid;

    @Expose({ name: 'CurrentStateDefID' })
    public set CurrentStateDefID(value: Guid) {
        this._previousStateDefID = this._currentStateDefID;
        this._currentStateDefID = value;
    }
    public get CurrentStateDefID(): Guid {
        return this._currentStateDefID;
    }
    public CurrentStateDef: TTObjectStateDef;
    public OriginalStateDef: TTObjectStateDef;

    @Exclude()
    private _previousStateDefID: Guid;
    public set PreviousStateDefID(value: Guid) {
        this._previousStateDefID = value;
    }
    public get PreviousStateDefID(): Guid {
        return this._previousStateDefID;
    }
    public PrevState: TTObjectState;
    public GetState(stateName: string, firstHit: boolean): TTObjectState {
        return null;
    }
    public FirstState: TTObjectState;
    public LastState: TTObjectState;
    public StartState: TTObjectState;
    public EndState: TTObjectState;
    public IsUncompleted: boolean;
    public IsCompletedSuccessfully: boolean;
    public IsCompletedUnsuccessfully: boolean;
    public IsCancelled: boolean;
    public ObjectDescription: string;
    public IsParentRelationReadonly(relDef: TTObjectRelationDef): boolean {
        return null;
    }
    public IsPropertyReadonly(propDef: TTObjectPropertyDef): boolean {
        return null;
    }
    public ToString(): string {
        return null;
    }
    public Equals(obj: Object): boolean {
        return null;
    }
    public GetHashCode(): number {
        return null;
    }
    public Update(): void {

    }
    public GetMemberInfo(memberName: string): TTObjectMemberInfo {
        return null;
    }
    public get ObjectContext(): TTObjectContext {
        return null;
    }
    public CheckRequiredProperties(): void {
    }
    public Delete(): void {
    }
    public GetMemberError(memberName: string): TTObjectMemberException {
        return null;
    }
    public GetError(): string;
    public GetError(columnName?: string): string {
        return null;
    }
    public GetErrors(): string {
        return null;
    }
    public ClearErrors(): void {
    }
    public get HasErrors(): boolean {
        return false;
    }
    public get HasOriginal(): boolean {
        return false;
    }
    public GetNextStateDefs(): Array<any> {
        return null;
    }
    public GetParent(relationDefName: string): ITTObject {
        return null;
    }
    public GetChildren(relationDefName: string): Array<any> {
        return null;
    }
    private _isNew: boolean;
    public set IsNew(value: boolean) {
        this._isNew = value;
    }
    public get IsNew(): boolean {
        return this._isNew;
    }
    public get IsImported(): boolean {
        return false;
    }
    public get IsOriginal(): boolean {
        return false;
    }
    public get IsReadOnly(): boolean {
        return false;
    }
    public get IsRemoved(): boolean {
        return false;
    }
    public get IsDeleted(): boolean {
        return false;
    }
    public get Original(): ITTObject {
        return null;
    }
    public GetDataMemberValue(memberName: string): Object {
        return null;
    }
    public get CanBeDeleted(): boolean {
        return false;
    }
    public Refresh(): void {
    }
    public UndoLastTransition(): void;
    public UndoLastTransition(description?: string): void {

    }

    public Cancel(): void;
    public Cancel(description?: string): void {
    }
    public FindCancelTransition(): TTObjectStateTransitionDef {
        return null;
    }
    public CreateReadAuditRecord(): void {

    }

    public GetStateHistory(): Array<TTObjectState> {
        return null;
    }
}
