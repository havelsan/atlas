import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { Type } from 'app/NebulaClient/Mscorlib/type';
import { Dictionary } from 'NebulaClient/System/Collections/Dictionaries/Dictionary';
import { TTObject } from './TTObject';
import { TTObjectDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectDef';

export class TTObjectContext {
    private _objectList: Dictionary<Guid, TTObject>;
    public get ObjectCount(): number {
        return this._objectList.count;
    }
    constructor(isReadOnly: boolean) {
        this._isReadOnly = isReadOnly;
    }
    public ContainsObject(objectID: Guid): boolean {
        return false;
    }
    public Update(): void {
    }
    public Save(): void {
    }
    public CreateObject(objectDefName?: string, objectDefID?: Guid): TTObject {
        return null;
    }
    public AddObject(sourceTTObject: TTObject): void {
    }
    public Dispose(): void {
    }
    public BeginSavePoint(): Guid {
        return null;
    }
    public HasSavePoint(savePointID: Guid): boolean {
        return null;

    }
    public RollbackSavePoint(savePointID: Guid): void {
        return null;
    }

    private _isReadOnly: boolean;
    public get IsReadOnly(): boolean {
        return this._isReadOnly;
    }

    public GetObject<T>(objectID: Guid): T;
    public GetObject(objectID: Guid, objectDefName: string): TTObject;
    public GetObject(objectID: Guid, objectType: Type): TTObject;
    public GetObject(objectID: Guid, objectDefID: Guid): TTObject;
    public GetObject(objectID: Guid, objectDef: TTObjectDef): TTObject;
    public GetObject(objectID: Guid, objectDef: TTObjectDef, throwExceptionIfNotFound: boolean): TTObject;
    public GetObject(...prms): TTObject {
        return null;
    }

    public QueryObjects(objectDefName: string): Array<any>;
    public QueryObjects(objectDef: TTObjectDef): Array<any>;
    public QueryObjects(objectDefName: string, filterExpression: string): Array<any>;
    public QueryObjects(objectDef: TTObjectDef, filterExpression: string): Array<any>;
    public QueryObjects(objectDefName: string, filterExpression: string, orderBy: string): Array<any>;
    public QueryObjects(objectDef: TTObjectDef, filterExpression: string, orderBy: string): Array<any>;
    public QueryObjects(...prms): Array<any> {
        return null;
    }
}
