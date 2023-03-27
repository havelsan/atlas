import { Guid } from "../Mscorlib/Guid";
import { ITTEnumValueDef } from "../Utils/DefinitionDataInterfaces/ITTEnumValueDef";
import { TTDataType } from "./TTDataType";
import { NotImplementedException } from "../System/Exceptions/NotImplementedException";

/*[Serializable]*/
export class EnumValueDef implements ITTEnumValueDef {
    private _dataType: TTDataType;
    public get DataType(): TTDataType {
        return this._dataType;
    }
    public get DataTypeID(): Guid {
        return this._dataType.DataTypeID;
    }
    private _name: string;
    public get Name(): string {
        return this._name;
    }
    public set Name(value: string) {
        this._name = value;
        if (this._name !== null) {
            this._name = this._name.trim();
            if (this._name.length === 0)
                this._name = null;
        }
    }
    private _description: string;
    public get Description(): string {
        return this._description;
    }
    private _value: number;
    public get Value(): number {
        return this._value;
    }
    private _displayText: string;
    public get DisplayText(): string {
        if (this._displayText === null)
            return (this._name === null ? "" : this._name);
        return this._displayText;
    }
    public set DisplayText(value: string) {
        this._displayText = value;
        if (this._displayText !== null) {
            this._displayText = this._displayText.trim();
            if (this._displayText.length === 0)
                this._displayText = null;
        }
    }
    public get EnumValue(): Object {
        //TODO: Implement EnumValue
        throw new NotImplementedException();
    }
    public ToString(): string {
        return this.DisplayText;
    }
}