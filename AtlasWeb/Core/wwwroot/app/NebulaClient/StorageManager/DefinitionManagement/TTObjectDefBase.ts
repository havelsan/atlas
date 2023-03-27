import { Guid } from "../../Mscorlib/Guid";

export class TTObjectDefBase {

    private _objectDefID: Guid;
    public get ID(): Guid {
        return this._objectDefID;
    }

    protected _name: string;
    public get Name(): string {
        return this._name;
    }
    public set Name(value: string) {
        this._name = value;
    }

    public IsOfType(objectDefName: string): boolean;
    public IsOfType(objectDefID: Guid ): boolean;
    public IsOfType(objectDef: TTObjectDefBase ): boolean;
    public IsOfType(firstParam: string | Guid | TTObjectDefBase ): boolean {
        return null;
    }
}