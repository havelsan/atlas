import { Guid } from "NebulaClient/Mscorlib/Guid";
import { TTMessagePriorityEnum } from "NebulaClient/Utils/Enums/TTMessagePriorityEnum";
import { TTMessageStatusEnum } from "NebulaClient/Utils/Enums/TTMessageStatusEnum";
import { Exception } from "NebulaClient/Mscorlib/Exception";

export class TTMessage {
    protected _messageDate: Date;
    public get MessageDate(): Date {
        return this._messageDate;
    }
    protected _assemblyName: string;
    public get AssemblyName(): string {
        return this._assemblyName;
    }
    protected _className: string;
    public get ClassName(): string {
        return this._className;
    }
    protected _methodName: string;
    public get MethodName(): string {
        return this._methodName;
    }
    protected _hasReturnScript: boolean;
    public get HasReturnScript(): boolean {
        return this._hasReturnScript;
    }
    protected _label: string;
    public get Label(): string {
        return this._label;
    }
    protected _fromSite: Guid;
    public get FromSite(): Guid {
        return this._fromSite;
    }
    public set FromSite(value: Guid) {
        this._fromSite = value;
    }
    protected _toSite: Guid;
    public get ToSite(): Guid {
        return this._toSite;
    }
    protected _retryCount: number;
    public get RetryCount(): number {
        return this._retryCount;
    }
    public set RetryCount(value: number) {
        this._retryCount = value;
    }
    protected _parameters: ArrayBuffer;
    public get Parameters(): ArrayBuffer {
        return this._parameters;
    }
    protected _returnValue: ArrayBuffer;
    public get ReturnValue(): ArrayBuffer {
        return this.ReturnValue;
    }
    public set ReturnValue(value: ArrayBuffer) {
        this._returnValue = value;
    }
    protected _encodedReturnValue: ArrayBuffer;
    public get EncodedReturnValue(): ArrayBuffer {
        return this._encodedReturnValue;
    }
    public set EncodedReturnValue(value: ArrayBuffer) {
        this._encodedReturnValue = value;
    }
    protected _binaryDataID: Guid = Guid.Empty;
    public get BinaryDataID(): Guid {
        return this._binaryDataID;
    }
    protected _webMethodDefID: Guid;
    public get WebMethodDefID(): Guid {
        return this._webMethodDefID;
    }
    public set WebMethodDefID(value: Guid) {
        this._webMethodDefID = value;
    }
    protected _resourceObjectID: Guid;
    public get ResourceObjectID(): Guid {
        return this._resourceObjectID;
    }
    public set ResourceObjectID(value: Guid) {
        this._resourceObjectID = value;
    }
    protected _procedureObjectID: Guid;
    public get ProcedureObjectID(): Guid {
        return this._procedureObjectID;
    }
    public set ProcedureObjectID(value: Guid) {
        this._procedureObjectID = value;
    }
    protected _priority: TTMessagePriorityEnum;
    public get Priority(): TTMessagePriorityEnum {
        return this._priority;
    }
    protected _messageStatus: TTMessageStatusEnum;
    public get MessageStatus(): TTMessageStatusEnum {
        return this._messageStatus;
    }
    protected _returnException: Exception;
    public get ReturnException(): Exception {
        return this._returnException;
    }
    public set ReturnException(value: Exception) {
        this._returnException = value;
    }
    protected _messageID: Guid;
    public get MessageID(): Guid {
        return this._messageID;
    }
}