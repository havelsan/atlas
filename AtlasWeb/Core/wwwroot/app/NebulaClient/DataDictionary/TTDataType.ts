import { Guid } from "../Mscorlib/Guid";
import { ITTDataTypeData } from "../Utils/DefinitionDataInterfaces/ITTDataTypeData";
import { Exception } from "../System/Exception";
import { PrimitiveTypeEnum } from "../Utils/Enums/PrimitiveTypeEnum";
import { DBProviderTypeEnum } from "../Utils/Enums/DBProviderTypeEnum";
import { DataTypeCompatibilityEnum } from "../Utils/Enums/DataTypeCompatibilityEnum";
import { TTException } from "../Utils/Exceptions/TTException";
import { TTCallAdminException } from "../Utils/Exceptions/TTCallAdminException";
import { IncompatibleValueException } from "./Exceptions/IncompatibleValueException";
import { BigCurrency } from "./CorePrimitives/BigCurrency";
import { TTUtils } from "../Utils/Collections/DualKeyCollection";
import { ITTConverter } from "./PrimitiveTypes/ITTConverter";
import { UnsupportedProviderType } from "./Exceptions/UnsupportedProviderType";
import { DataDictionaryException } from "./Exceptions/DataDictionaryException";
import { EnumValueDef } from "./EnumValueDef";
import { Globals } from "../Utils/Globals";

export class PrimitiveTypeBase {
    public PrimitiveTypeEnum: PrimitiveTypeEnum;
    public PropertyTableName: string;
    public IsValueType: boolean;
    public CodeType: string;
    public FullCodeType: string;
    public get NullableCodeType(): string {
        return this.CodeType + (this.IsValueType ? "?" : "");
    }
    public get NullableFullCodeType(): string {
        return this.FullCodeType + (this.IsValueType ? "?" : "");
    }
    public get Length(): number {
        throw new Exception("'Length' is not implemented.");
    }
    public get Precision(): number {
        throw new Exception("'Precision' is not implemented.");
    }
    public get DefaultValue(): Object {
        return null;
    }
    private _dataType: TTDataType;
    protected get DataType(): TTDataType {
        return this._dataType;
    }
    protected getDataType(): TTDataType {
        return this._dataType;
    }
    constructor(dataType: TTDataType) {
        this._dataType = dataType;
    }
    public IsCompatibleValue(value: Object): boolean { throw new Error('not implemented'); }
    public GetDbType(providerType: DBProviderTypeEnum): string { throw new Error('not implemented'); }
    public GetSqlLiteral(value: Object, providerType: DBProviderTypeEnum): string { throw new Error('not implemented'); }
    public GetNqlLiteral(value: Object): string { throw new Error('not implemented'); }
    public GetCompatibility(dataType: ITTDataTypeData): DataTypeCompatibilityEnum { throw new Error('not implemented'); }
}

export class PrimitiveType<TValue> extends PrimitiveTypeBase implements ITTConverter {
    protected _minValue: TValue;
    public get MinValue(): TValue {
        return this._minValue;
    }
    protected _maxValue: TValue;
    public get MaxValue(): TValue {
        return this._maxValue;
    }
    protected CheckConstraints(value: TValue): boolean {
        if (value !== null) {
            if (this._minValue !== null && value < this._minValue)
                return false;
            if (this._maxValue !== null && value > this._maxValue)
                return false;
        }
        return true;
    }
    public IsCompatibleValue(value: Object): boolean {
        let convValue: TValue;
        if (this.TryConvertValue(value, false, convValue))
            return this.CheckConstraints(convValue);
        return false;
    }
    public TryConvertValue(value: Object, doInternationalParse: boolean, convertedValue: TValue): boolean { throw new Error('not implemented'); }
    public ConvertValue(value: Object, doInternationalParse?: boolean): TValue {
        let convertedValue: TValue;
        if (this.TryConvertValue(value, doInternationalParse, convertedValue) && this.CheckConstraints(convertedValue))
            return convertedValue;
        throw new IncompatibleValueException(typeof this.DataType, value);
    }
    public FromDBValue(value: Object): TValue {
        if (value === null)
            return <TValue><Object>null;
        return <TValue>value;
    }
    public ToDBValue(value: TValue): Object {
        if (value === null)
            return null;
        return value;
    }
    public FromInternationalString(value: string): TValue {
        return this.ConvertValue(value, true);
    }
    public ToInternationalString(value: TValue): string {
        if (value === null )
            return null;
        return value.toString();
    }
    public ToString(value: TValue): string {
        if (value === null)
            return null;
        return value.toString();
    }

    constructor(dataType: TTDataType) {
        super(dataType);

    }
}

export class TTDataType implements ITTDataTypeData {
    public static DynamicTableNames: string[] = ["TTOBJECTPROPERTYTEXT", "TTOBJECTPROPERTYINT", "TTOBJECTPROPERTYDATE", "TTOBJECTPROPERTYFLOAT", "TTOBJECTPROPERTYLONGTEXT", "TTOBJECTPROPERTYBINARY", "TTOBJECTPROPERTYGUID"];
    get Length(): number {
        return this._primitiveType.Length;
    }
    get Precision(): number {
        return this._primitiveType.Precision;
    }
    get MinValue(): string {
        throw new Exception("The method or operation is not implemented.");
    }
    get MaxValue(): string {
        throw new Exception("The method or operation is not implemented.");
    }
    get PrimitiveTypeEnum(): PrimitiveTypeEnum {
        return this._primitiveType.PrimitiveTypeEnum;
    }
    get NameSpace(): string {
        return "TTObjectClasses";
    }
    get ObjectType(): string {
        return "TTDataTypeData";
    }
    private _moduleDefID: Guid;
    public get ModuleDefID(): Guid {
        return this._moduleDefID;
    }
    public get ID(): Guid {
        return this._dataTypeID;
    }
    private _dataTypeID: Guid;
    public get DataTypeID(): Guid {
        return this._dataTypeID;
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
    private _primitiveType: PrimitiveTypeBase;
    public get PrimitiveType(): PrimitiveTypeBase {
        return this._primitiveType;
    }
    public get PropertyTableName(): string {
        return this._primitiveType.PropertyTableName;
    }
    public get IsValueType(): boolean {
        return this._primitiveType.IsValueType;
    }
    private _defaultValue: string;
    public get DefaultValue(): string {
        if (this._defaultValue === null)
            return this._primitiveType.DefaultValue.toString();
        else return this._defaultValue;
    }
    public get IsBinary(): boolean {
        return (this._primitiveType.PrimitiveTypeEnum === PrimitiveTypeEnum.Binary);
    }
    public get IsEnum(): boolean {
        return (this._primitiveType.PrimitiveTypeEnum === PrimitiveTypeEnum.Enum);
    }
    public get IsInt32(): boolean {
        return (this._primitiveType.PrimitiveTypeEnum === PrimitiveTypeEnum.Integer);
    }
    public get IsInt64(): boolean {
        return (this._primitiveType.PrimitiveTypeEnum === PrimitiveTypeEnum.Long);
    }
    public get IsSequence(): boolean {
        return (this._primitiveType.PrimitiveTypeEnum === PrimitiveTypeEnum.Sequence);
    }
    public get IsInteger(): boolean {
        return this.IsInt32 || this.IsInt64 || this.IsSequence;
    }
    public get IsDouble(): boolean {
        return this._primitiveType.PrimitiveTypeEnum === PrimitiveTypeEnum.Double;
    }
    public get IsDecimal(): boolean {
        return this._primitiveType.PrimitiveTypeEnum === PrimitiveTypeEnum.Decimal;
    }
    public get IsSmallCurrency(): boolean {
        return this._primitiveType.PrimitiveTypeEnum === PrimitiveTypeEnum.Currency;
    }
    public get IsBigCurrency(): boolean {
        return this._primitiveType.PrimitiveTypeEnum === PrimitiveTypeEnum.BigCurrency;
    }
    public get IsCurrency(): boolean {
        return this.IsBigCurrency || this.IsSmallCurrency;
    }
    public get IsFloat(): boolean {
        return this.IsCurrency || this.IsDouble || this.IsDecimal;
    }
    public get IsDateTime(): boolean {
        return (this._primitiveType.PrimitiveTypeEnum === PrimitiveTypeEnum.DateTime);
    }
    public get IsLongText(): boolean {
        return (this._primitiveType.PrimitiveTypeEnum === PrimitiveTypeEnum.LongText);
    }
    public get IsShortText(): boolean {
        return (this._primitiveType.PrimitiveTypeEnum === PrimitiveTypeEnum.Text);
    }
    public get IsText(): boolean {
        return this.IsLongText || this.IsShortText || this.IsLargeText;
    }
    public get IsBoolean(): boolean {
        return (this._primitiveType.PrimitiveTypeEnum === PrimitiveTypeEnum.Boolean);
    }
    public get IsGuid(): boolean {
        return (this._primitiveType.PrimitiveTypeEnum === PrimitiveTypeEnum.Guid);
    }
    public get IsLargeText(): boolean {
        return (this._primitiveType.PrimitiveTypeEnum === PrimitiveTypeEnum.LargeText);
    }
    public GetDbType(providerType: DBProviderTypeEnum): string {
        return this._primitiveType.GetDbType(providerType);
    }
    public GetSqlLiteral(value: Object, providerType: DBProviderTypeEnum): string {
        return this._primitiveType.GetSqlLiteral(value, providerType);
    }
    public GetNqlLiteral(value: Object): string {
        return this._primitiveType.GetNqlLiteral(value);
    }
    public IsCompatibleValue(value: Object): boolean {
        return this._primitiveType.IsCompatibleValue(value);
    }
    public TryConvertValue(value: Object, doInternationalParse: boolean, convertedValue: Object): boolean {
        return false;
    }
    public ConvertValue(value: Object): Object {
        return null;
    }
    public FromDBValue(value: Object): Object {
        return null;
    }
    public ToDBValue(value: Object): Object {
        return null;
    }
    public FromInternationalString(value: string): Object {
        return null;
    }
    public ToInternationalString(value: Object): string {
        return value.toString();
    }
    public GetCompatibility(dataType: ITTDataTypeData): DataTypeCompatibilityEnum {
        return this._primitiveType.GetCompatibility(dataType);
    }
    public get CodeType(): string {
        return this._primitiveType.CodeType;
    }
    public get FullCodeType(): string {
        return this._primitiveType.FullCodeType;
    }
    public get NullableCodeType(): string {
        return this._primitiveType.NullableCodeType;
    }
    public get NullableFullCodeType(): string {
        return this._primitiveType.NullableFullCodeType;
    }

    private NewPrimitiveType(primitiveTypeEnum: PrimitiveTypeEnum): PrimitiveTypeBase {
        switch (primitiveTypeEnum) {
            case PrimitiveTypeEnum.Boolean:
                return new BooleanType(this);
            case PrimitiveTypeEnum.DateTime:
                return new DateTimeType(this);
            case PrimitiveTypeEnum.Decimal:
                return new DecimalType(this);
            case PrimitiveTypeEnum.Double:
                return new DoubleType(this);
            case PrimitiveTypeEnum.Integer:
                return new IntegerType(this);
            case PrimitiveTypeEnum.Long:
                return new LongType(this);
            case PrimitiveTypeEnum.Sequence:
                return new SequenceType(this);
            case PrimitiveTypeEnum.Text:
                return new TextType(this);
            case PrimitiveTypeEnum.LongText:
                return new TextType(this);
            case PrimitiveTypeEnum.Enum:
                return new EnumType(this);
            case PrimitiveTypeEnum.Binary:
                return new BinaryType(this);
            case PrimitiveTypeEnum.Guid:
                return new GuidType(this);
            case PrimitiveTypeEnum.Currency:
                return new CurrencyType(this);
            case PrimitiveTypeEnum.BigCurrency:
                return new BigCurrencyType(this);
            case PrimitiveTypeEnum.LargeText:
                return new LargeTextType(this);
            default:
                return null;
        }
    }
    constructor(primitiveTypeEnum: PrimitiveTypeEnum) {
        this._dataTypeID = Guid.empty();
        this._name = null;
        this._description = null;
        this._defaultValue = null;
        this._primitiveType = this.NewPrimitiveType(primitiveTypeEnum);
    }
}


export class BigCurrencyType extends PrimitiveType<BigCurrency>
{
    public static TryConvertFrom(value: Object, doInternationalParse: boolean, bigCurrencyValue: BigCurrency): boolean {
        bigCurrencyValue = null;
        return false;
    }
    public static ConvertFrom(value: Object, doInternationalParse?: boolean): BigCurrency {
        let bigCurValue: BigCurrency;
        if (BigCurrencyType.TryConvertFrom(value, doInternationalParse, bigCurValue))
            return bigCurValue;
        throw new IncompatibleValueException("BigCurrencyType", value);
    }
    public get PrimitiveTypeEnum(): PrimitiveTypeEnum {
        return PrimitiveTypeEnum.BigCurrency;
    }
    public get PropertyTableName(): string {
        return BigCurrencyType.TypeInfo.PropertyTableName;
    }
    public get IsValueType(): boolean {
        return BigCurrencyType.TypeInfo.IsValueType;
    }
    public get CodeType(): string {
        return BigCurrencyType.TypeInfo.CodeType;
    }
    public get FullCodeType(): string {
        return BigCurrencyType.TypeInfo.FullCodeType;
    }
    public get Length(): number {
        return BigCurrency.Length;
    }
    public get Precision(): number {
        return BigCurrency.Precision;
    }
    public GetDbType(providerType: DBProviderTypeEnum): string {
        switch (providerType) {
            case DBProviderTypeEnum.MSSqlServer:
                return "decimal(" + this.Length + "," + this.Precision + ")";
            case DBProviderTypeEnum.Oracle:
                return "NUMBER(" + this.Length + "," + this.Precision + ")";
            default:
                throw new UnsupportedProviderType(providerType);
        }
    }
    public GetSqlLiteral(value: Object, providerType: DBProviderTypeEnum): string {
        return this.GetNqlLiteral(value);
    }
    public GetNqlLiteral(value: Object): string {
        let bigCurVal: BigCurrency;
        if (BigCurrencyType.TryConvertFrom(value, false, bigCurVal))
            return super.ToInternationalString(bigCurVal);
        return null;
    }
    public TryConvertValue(value: Object, doInternationalParse: boolean, convertedValue: BigCurrency): boolean {
        return BigCurrencyType.TryConvertFrom(value, doInternationalParse, convertedValue);
    }
    public GetCompatibility(dataType: ITTDataTypeData): DataTypeCompatibilityEnum {
        switch (dataType.PrimitiveTypeEnum) {
            case PrimitiveTypeEnum.BigCurrency:
                return DataTypeCompatibilityEnum.Same;
            case PrimitiveTypeEnum.Decimal:
                let length: number = dataType.Length;
                let precision: number = dataType.Precision;
                if (this.Length === length && this.Precision === precision)
                    return DataTypeCompatibilityEnum.Same;
                if (this.Length >= length && this.Precision >= precision)
                    return DataTypeCompatibilityEnum.Compatible;
                return DataTypeCompatibilityEnum.Different;
            case PrimitiveTypeEnum.Boolean:
            case PrimitiveTypeEnum.Enum:
            case PrimitiveTypeEnum.Integer:
            case PrimitiveTypeEnum.Sequence:
            case PrimitiveTypeEnum.Long:
            case PrimitiveTypeEnum.Currency:
                return DataTypeCompatibilityEnum.Compatible;
            case PrimitiveTypeEnum.Double:
            case PrimitiveTypeEnum.Text:
            case PrimitiveTypeEnum.LongText:
            case PrimitiveTypeEnum.LargeText:
            case PrimitiveTypeEnum.DateTime:
            case PrimitiveTypeEnum.Guid:
            case PrimitiveTypeEnum.Binary:
                return DataTypeCompatibilityEnum.Different;
            default:
                throw new TTCallAdminException();
        }
    }
    constructor(dataType: TTDataType) {
        super(dataType);
        //_minValue = null;
        //_maxValue = null;
    }

}
export namespace BigCurrencyType {
    export class TypeInfo {
        public static IsValueType: boolean = true;
        public static CodeType: string = "BigCurrency";
        public static FullCodeType: string = "TTDataDictionary.BigCurrency";
        public static NullableCodeType: string = TypeInfo.CodeType + (TypeInfo.IsValueType ? "?" : "");
        public static NullableFullCodeType: string = TypeInfo.FullCodeType + (TypeInfo.IsValueType ? "?" : "");
        public static PropertyTableName: string = "TTOBJECTPROPERTYFLOAT";
    }
}

export class BinaryType extends PrimitiveType<Object>
{
    public get PrimitiveTypeEnum(): PrimitiveTypeEnum {
        return PrimitiveTypeEnum.Binary;
    }
    public get PropertyTableName(): string {
        return BinaryType.TypeInfo.PropertyTableName;
    }
    public get IsValueType(): boolean {
        return BinaryType.TypeInfo.IsValueType;
    }
    public get CodeType(): string {
        return BinaryType.TypeInfo.CodeType;
    }
    public get FullCodeType(): string {
        return BinaryType.TypeInfo.FullCodeType;
    }
    public GetDbType(providerType: DBProviderTypeEnum): string {
        switch (providerType) {
            case DBProviderTypeEnum.MSSqlServer:
                return "uniqueidentifier";
            case DBProviderTypeEnum.Oracle:
                return "CHAR(36)";
            default:
                throw new UnsupportedProviderType(providerType);
        }
    }
    public GetSqlLiteral(value: Object, providerType: DBProviderTypeEnum): string {
        throw new TTException("Method not supported.");
    }
    public GetNqlLiteral(value: Object): string {
        throw new TTException("Method not supported.");
    }
    public TryConvertValue(value: Object, doInternationalParse: boolean, convertedValue: Object): boolean {
        convertedValue = value;
        return true;
    }
    protected CheckConstraints(value: Object): boolean {
        return true;
    }
    public FromInternationalString(value: string): Object {
        if (!value)
            return null;
        throw new TTException("Binary data cannot be converted from string.");
    }
    public ToInternationalString(binaryVal: Object): string {
        throw new TTException("Binary data cannot be converted to string.");
    }
    public ToString(value: Object): string {
        throw new TTException("Binary data cannot be converted to string.");
    }
    public GetCompatibility(dataType: ITTDataTypeData): DataTypeCompatibilityEnum {
        switch (dataType.PrimitiveTypeEnum) {
            case PrimitiveTypeEnum.Binary:
                return DataTypeCompatibilityEnum.Same;
            case PrimitiveTypeEnum.Integer:
            case PrimitiveTypeEnum.Enum:
            case PrimitiveTypeEnum.Sequence:
            case PrimitiveTypeEnum.Long:
            case PrimitiveTypeEnum.Double:
            case PrimitiveTypeEnum.Currency:
            case PrimitiveTypeEnum.BigCurrency:
            case PrimitiveTypeEnum.Guid:
            case PrimitiveTypeEnum.Decimal:
            case PrimitiveTypeEnum.Text:
            case PrimitiveTypeEnum.LongText:
            case PrimitiveTypeEnum.LargeText:
            case PrimitiveTypeEnum.DateTime:
            case PrimitiveTypeEnum.Boolean:
                return DataTypeCompatibilityEnum.Compatible;
            default:
                throw new TTCallAdminException();
        }
    }
    constructor(dataType: TTDataType) {
        super(dataType);
        //_minValue = null;
        //_maxValue = null;
    }
}
export namespace BinaryType {
    export class TypeInfo {
        public static IsValueType: boolean = false;
        public static CodeType: string = "object";
        public static FullCodeType: string = "System.Object";
        public static NullableCodeType: string = TypeInfo.CodeType + (TypeInfo.IsValueType ? "?" : "");
        public static NullableFullCodeType: string = TypeInfo.FullCodeType + (TypeInfo.IsValueType ? "?" : "");
        public static PropertyTableName: string = "TTOBJECTPROPERTYBINARY";
    }
}

export class BooleanType extends PrimitiveType<boolean>
{
    public static TryConvertFrom(value: Object, doInternationalParse: boolean, boolValue: boolean): boolean {
        boolValue = null;
        return false;
    }
    public static ConvertFrom(value: Object, doInternationalParse?: boolean): boolean {
        let boolValue: boolean;
        if (BooleanType.TryConvertFrom(value, doInternationalParse, boolValue))
            return boolValue;
        throw new IncompatibleValueException(typeof BooleanType, value);
    }
    public get PrimitiveTypeEnum(): PrimitiveTypeEnum {
        return PrimitiveTypeEnum.Boolean;
    }
    public get PropertyTableName(): string {
        return BooleanType.TypeInfo.PropertyTableName;
    }
    public get IsValueType(): boolean {
        return BooleanType.TypeInfo.IsValueType;
    }
    public get CodeType(): string {
        return BooleanType.TypeInfo.CodeType;
    }
    public get FullCodeType(): string {
        return BooleanType.TypeInfo.FullCodeType;
    }
    public GetDbType(providerType: DBProviderTypeEnum): string {
        switch (providerType) {
            case DBProviderTypeEnum.MSSqlServer:
                return "tinyint";
            case DBProviderTypeEnum.Oracle:
                return "NUMBER(1)";
            default:
                throw new UnsupportedProviderType(providerType);
        }
    }
    public GetSqlLiteral(value: Object, providerType: DBProviderTypeEnum): string {
        return this.GetNqlLiteral(value);
    }
    public GetNqlLiteral(value: Object): string {
        let boolVal: boolean;
        if (BooleanType.TryConvertFrom(value, false, boolVal))
            return this.ToInternationalString(boolVal);
        return null;
    }
    protected CheckConstraints(value: boolean): boolean {
        return true;
    }
    public TryConvertValue(value: Object, doInternationalParse: boolean, convertedValue: boolean): boolean {
        return BooleanType.TryConvertFrom(value, doInternationalParse, convertedValue);
    }
    public ToDBValue(value: boolean): any {
        return value ? <number>1 : <number>0;
    }
    public ToInternationalString(value: boolean): string {
        return value ? "1" : "0";
    }
    public ToString(value: boolean): string {
        return value ? i18n("M14018", "Evet") : i18n("M15570", "Hayır");
    }
    public GetCompatibility(dataType: ITTDataTypeData): DataTypeCompatibilityEnum {
        switch (dataType.PrimitiveTypeEnum) {
            case PrimitiveTypeEnum.Boolean:
                return DataTypeCompatibilityEnum.Same;
            case PrimitiveTypeEnum.Integer:
            case PrimitiveTypeEnum.Enum:
            case PrimitiveTypeEnum.Sequence:
            case PrimitiveTypeEnum.Long:
            case PrimitiveTypeEnum.Double:
            case PrimitiveTypeEnum.Currency:
            case PrimitiveTypeEnum.BigCurrency:
            case PrimitiveTypeEnum.Guid:
            case PrimitiveTypeEnum.Decimal:
            case PrimitiveTypeEnum.Text:
            case PrimitiveTypeEnum.LongText:
            case PrimitiveTypeEnum.LargeText:
            case PrimitiveTypeEnum.DateTime:
            case PrimitiveTypeEnum.Binary:
                return DataTypeCompatibilityEnum.Different;
            default:
                throw new TTCallAdminException();
        }
    }
    constructor(dataType: TTDataType) {
        super(dataType);
        //_minValue = null;
        //_maxValue = null;
    }
}
export namespace BooleanType {
    export class TypeInfo {
        public static IsValueType: boolean = true;
        public static CodeType: string = "bool";
        public static FullCodeType: string = "System.Boolean";
        public static NullableCodeType: string = TypeInfo.CodeType + (TypeInfo.IsValueType ? "?" : "");
        public static NullableFullCodeType: string = TypeInfo.FullCodeType + (TypeInfo.IsValueType ? "?" : "");
        public static PropertyTableName: string = "TTOBJECTPROPERTYINT";
    }
}


export class CurrencyType extends PrimitiveType<Currency>
{
    public static TryConvertFrom(value: Object, doInternationalParse: boolean, currencyValue: Currency): boolean {
        currencyValue = null;
        return false;
    }
    public static ConvertFrom(value: Object, doInternationalParse?: boolean): Currency {
        let curValue: Currency;
        if (CurrencyType.TryConvertFrom(value, doInternationalParse, curValue))
            return curValue;
        throw new IncompatibleValueException(typeof CurrencyType, value);
    }
    public get PrimitiveTypeEnum(): PrimitiveTypeEnum {
        return PrimitiveTypeEnum.Currency;
    }
    public get PropertyTableName(): string {
        return CurrencyType.TypeInfo.PropertyTableName;
    }
    public get IsValueType(): boolean {
        return CurrencyType.TypeInfo.IsValueType;
    }
    public get CodeType(): string {
        return CurrencyType.TypeInfo.CodeType;
    }
    public get FullCodeType(): string {
        return CurrencyType.TypeInfo.FullCodeType;
    }
    public get Length(): number {
        return 15;
    }
    private _precision: number;
    public get Precision(): number {
        return this._precision;
    }
    public GetDbType(providerType: DBProviderTypeEnum): string {
        switch (providerType) {
            case DBProviderTypeEnum.MSSqlServer:
                return "decimal(" + this.Length + "," + this.Precision + ")";
            case DBProviderTypeEnum.Oracle:
                return "NUMBER(" + this.Length + "," + this.Precision + ")";
            default:
                throw new UnsupportedProviderType(providerType);
        }
    }
    public GetSqlLiteral(value: Object, providerType: DBProviderTypeEnum): string {
        return this.GetNqlLiteral(value);
    }
    public GetNqlLiteral(value: Object): string {
        let curVal: Currency;
        if (CurrencyType.TryConvertFrom(value, false, curVal))
            return super.ToInternationalString(curVal);
        return null;
    }
    public TryConvertValue(value: Object, doInternationalParse: boolean, convertedValue: Currency): boolean {
        if (CurrencyType.TryConvertFrom(value, doInternationalParse, convertedValue)) {
            return true;
        }
        return false;
    }
    public GetCompatibility(dataType: ITTDataTypeData): DataTypeCompatibilityEnum {
        switch (dataType.PrimitiveTypeEnum) {
            case PrimitiveTypeEnum.Currency:
                return DataTypeCompatibilityEnum.Same;
            case PrimitiveTypeEnum.Sequence:
            case PrimitiveTypeEnum.Enum:
            case PrimitiveTypeEnum.Boolean:
            case PrimitiveTypeEnum.Integer:
            case PrimitiveTypeEnum.Long:
                return DataTypeCompatibilityEnum.Compatible;
            case PrimitiveTypeEnum.DateTime:
            case PrimitiveTypeEnum.Text:
            case PrimitiveTypeEnum.LongText:
            case PrimitiveTypeEnum.LargeText:
            case PrimitiveTypeEnum.Decimal:
            case PrimitiveTypeEnum.Double:
            case PrimitiveTypeEnum.BigCurrency:
            case PrimitiveTypeEnum.Guid:
            case PrimitiveTypeEnum.Binary:
                return DataTypeCompatibilityEnum.Different;
            default:
                throw new TTCallAdminException();
        }
    }
    constructor(dataType: TTDataType) {
        super(dataType);
        //_minValue = null;
        //_maxValue = null;
        this._precision = 2;
    }
}
export namespace CurrencyType {
    export class TypeInfo {
        public static IsValueType: boolean = true;
        public static CodeType: string = "Currency";
        public static FullCodeType: string = "TTDataDictionary.Currency";
        public static NullableCodeType: string = TypeInfo.CodeType + (TypeInfo.IsValueType ? "?" : "");
        public static NullableFullCodeType: string = TypeInfo.FullCodeType + (TypeInfo.IsValueType ? "?" : "");
        public static PropertyTableName: string = "TTOBJECTPROPERTYFLOAT";
    }
}



export class DateTimeType extends PrimitiveType<Date>
{
    public static TryConvertFrom(value: Object, doInternationalParse: boolean, dateTimeValue: Date): boolean {
        dateTimeValue = null;
        return false;
    }
    public static ConvertFrom(value: Object, doInternationalParse?: boolean): Date {
        let dtValue: Date;
        if (DateTimeType.TryConvertFrom(value, doInternationalParse, dtValue))
            return dtValue;
        throw new IncompatibleValueException(typeof DateTimeType, value);
    }
    public get PrimitiveTypeEnum(): PrimitiveTypeEnum {
        return PrimitiveTypeEnum.DateTime;
    }
    public get PropertyTableName(): string {
        return DateTimeType.TypeInfo.PropertyTableName;
    }
    public get IsValueType(): boolean {
        return DateTimeType.TypeInfo.IsValueType;
    }
    public get CodeType(): string {
        return DateTimeType.TypeInfo.CodeType;
    }
    public get FullCodeType(): string {
        return DateTimeType.TypeInfo.FullCodeType;
    }
    public GetDbType(providerType: DBProviderTypeEnum): string {
        switch (providerType) {
            case DBProviderTypeEnum.MSSqlServer:
                return "datetime";
            case DBProviderTypeEnum.Oracle:
                return "DATE";
            default:
                throw new UnsupportedProviderType(providerType);
        }
    }

    public ToInternationalString(value: Date): string {
        if (value === null )
            return null;
        return value.toString();
    }
    public TryConvertValue(value: Object, doInternationalParse: boolean, convertedValue: Date): boolean {
        return DateTimeType.TryConvertFrom(value, doInternationalParse, convertedValue);
    }
    public GetCompatibility(dataType: ITTDataTypeData): DataTypeCompatibilityEnum {
        switch (dataType.PrimitiveTypeEnum) {
            case PrimitiveTypeEnum.DateTime:
                return DataTypeCompatibilityEnum.Same;
            case PrimitiveTypeEnum.Boolean:
            case PrimitiveTypeEnum.Enum:
            case PrimitiveTypeEnum.Sequence:
            case PrimitiveTypeEnum.Integer:
            case PrimitiveTypeEnum.Long:
            case PrimitiveTypeEnum.Double:
            case PrimitiveTypeEnum.Decimal:
            case PrimitiveTypeEnum.Text:
            case PrimitiveTypeEnum.LongText:
            case PrimitiveTypeEnum.LargeText:
            case PrimitiveTypeEnum.Binary:
            case PrimitiveTypeEnum.Currency:
            case PrimitiveTypeEnum.BigCurrency:
            case PrimitiveTypeEnum.Guid:
                return DataTypeCompatibilityEnum.Different;
            default:
                throw new TTCallAdminException();
        }
    }
    constructor(dataType: TTDataType) {
        super(dataType);
        //_minValue = null;
        //_maxValue = null;
    }
}
export namespace DateTimeType {
    export class TypeInfo {
        public static IsValueType: boolean = true;
        public static CodeType: string = "DateTime";
        public static FullCodeType: string = "System.DateTime";
        public static NullableCodeType: string = TypeInfo.CodeType + (TypeInfo.IsValueType ? "?" : "");
        public static NullableFullCodeType: string = TypeInfo.FullCodeType + (TypeInfo.IsValueType ? "?" : "");
        public static PropertyTableName: string = "TTOBJECTPROPERTYDATE";
    }
}



export class DecimalType extends PrimitiveType<number>
{
    public static TryConvertFrom(value: Object, doInternationalParse: boolean, decimalValue: number): boolean {
        decimalValue = null;
        return false;
    }
    public static ConvertFrom(value: Object, doInternationalParse?: boolean): number {
        let decValue: number;
        if (DecimalType.TryConvertFrom(value, doInternationalParse, decValue))
            return decValue;
        throw new IncompatibleValueException(typeof DecimalType, value);
    }
    public get PrimitiveTypeEnum(): PrimitiveTypeEnum {
        return PrimitiveTypeEnum.Decimal;
    }
    public get PropertyTableName(): string {
        return DecimalType.TypeInfo.PropertyTableName;
    }
    public get IsValueType(): boolean {
        return DecimalType.TypeInfo.IsValueType;
    }
    public get CodeType(): string {
        return DecimalType.TypeInfo.CodeType;
    }
    public get FullCodeType(): string {
        return DecimalType.TypeInfo.FullCodeType;
    }
    private _length: number;
    public get Length(): number {
        return this._length;
    }
    private _precision: number;
    public get Precision(): number {
        return this._precision;
    }
    public GetDbType(providerType: DBProviderTypeEnum): string {
        switch (providerType) {
            case DBProviderTypeEnum.MSSqlServer:
                return "decimal(" + this._length.toString() + "," + this._precision.toString() + ")";
            case DBProviderTypeEnum.Oracle:
                return "NUMBER(" + this._length.toString() + "," + this._precision.toString() + ")";
            default:
                throw new UnsupportedProviderType(providerType);
        }
    }
    public GetSqlLiteral(value: Object, providerType: DBProviderTypeEnum): string {
        return this.GetNqlLiteral(value);
    }
    public GetNqlLiteral(value: Object): string {
        let decVal: number;
        if (DecimalType.TryConvertFrom(value, false, decVal))
            return super.ToInternationalString(decVal);
        return null;
    }
    public TryConvertValue(value: Object, doInternationalParse: boolean, convertedValue: number): boolean {
        return DecimalType.TryConvertFrom(value, doInternationalParse, convertedValue);
    }
    public GetCompatibility(dataType: ITTDataTypeData): DataTypeCompatibilityEnum {
        switch (dataType.PrimitiveTypeEnum) {
            case PrimitiveTypeEnum.Currency:
            case PrimitiveTypeEnum.BigCurrency:
            case PrimitiveTypeEnum.Decimal:
                let length: number = dataType.Length;
                let precision: number = dataType.Precision;
                if (this._length === length && this._precision === precision)
                    return DataTypeCompatibilityEnum.Same;
                if (this._length >= length && this._precision >= precision)
                    return DataTypeCompatibilityEnum.Compatible;
                return DataTypeCompatibilityEnum.Different;
            case PrimitiveTypeEnum.Boolean:
                if (this._length - this._precision >= 1)
                    return DataTypeCompatibilityEnum.Compatible;
                return DataTypeCompatibilityEnum.Different;
            case PrimitiveTypeEnum.Enum:
            case PrimitiveTypeEnum.Integer:
                if (this._length - this._precision >= 10)
                    return DataTypeCompatibilityEnum.Compatible;
                return DataTypeCompatibilityEnum.Different;
            case PrimitiveTypeEnum.Sequence:
            case PrimitiveTypeEnum.Long:
                if (this._length - this._precision >= 18)
                    return DataTypeCompatibilityEnum.Compatible;
                return DataTypeCompatibilityEnum.Different;
            case PrimitiveTypeEnum.DateTime:
            case PrimitiveTypeEnum.Binary:
            case PrimitiveTypeEnum.Guid:
            case PrimitiveTypeEnum.Double:
            case PrimitiveTypeEnum.Text:
            case PrimitiveTypeEnum.LongText:
            case PrimitiveTypeEnum.LargeText:
                return DataTypeCompatibilityEnum.Different;
            default:
                throw new TTCallAdminException();
        }
    }
    constructor(dataType: TTDataType) {
        super(dataType);
        //_minValue = null;
        //_maxValue = null;
        this._length = 38;
        this._precision = 8;
    }
}
export namespace DecimalType {
    export class TypeInfo {
        public static IsValueType: boolean = true;
        public static CodeType: string = "decimal";
        public static FullCodeType: string = "System.Decimal";
        public static NullableCodeType: string = TypeInfo.CodeType + (TypeInfo.IsValueType ? "?" : "");
        public static NullableFullCodeType: string = TypeInfo.FullCodeType + (TypeInfo.IsValueType ? "?" : "");
        public static PropertyTableName: string = "TTOBJECTPROPERTYFLOAT";
    }
}



export class DoubleType extends PrimitiveType<number>
{
    public static TryConvertFrom(value: Object, doInternationalParse: boolean, doubleValue: number): boolean {
        if (value === null) {
            doubleValue = null;
            return true;
        }
        if (typeof value === "string") {
            let strVal: string = value.toString().trim();
            if (strVal.length === 0) {
                doubleValue = null;
                return true;
            }
            let dblVal: number;
            dblVal = parseFloat(strVal);
            doubleValue = dblVal;
            return true;
        }
        doubleValue = null;
        return false;
    }
    public static ConvertFrom(value: Object, doInternationalParse?: boolean): number {
        let dblValue: number;
        if (DoubleType.TryConvertFrom(value, doInternationalParse, dblValue))
            return dblValue;
        throw new IncompatibleValueException(typeof DoubleType, value);
    }
    public get PrimitiveTypeEnum(): PrimitiveTypeEnum {
        return PrimitiveTypeEnum.Double;
    }
    public get PropertyTableName(): string {
        return DoubleType.TypeInfo.PropertyTableName;
    }
    public get IsValueType(): boolean {
        return DoubleType.TypeInfo.IsValueType;
    }
    public get CodeType(): string {
        return DoubleType.TypeInfo.CodeType;
    }
    public get FullCodeType(): string {
        return DoubleType.TypeInfo.FullCodeType;
    }
    public GetDbType(providerType: DBProviderTypeEnum): string {
        switch (providerType) {
            case DBProviderTypeEnum.MSSqlServer:
                return "float";
            case DBProviderTypeEnum.Oracle:
                return "FLOAT";
            default:
                throw new UnsupportedProviderType(providerType);
        }
    }
    public GetSqlLiteral(value: Object, providerType: DBProviderTypeEnum): string {
        return this.GetNqlLiteral(value);
    }
    public GetNqlLiteral(value: Object): string {
        let dblVal: number;
        if (DoubleType.TryConvertFrom(value, false, dblVal))
            return super.ToInternationalString(dblVal);
        return null;
    }
    public TryConvertValue(value: Object, doInternationalParse: boolean, convertedValue: number): boolean {
        return DoubleType.TryConvertFrom(value, doInternationalParse, convertedValue);
    }
    public GetCompatibility(dataType: ITTDataTypeData): DataTypeCompatibilityEnum {
        switch (dataType.PrimitiveTypeEnum) {
            case PrimitiveTypeEnum.Double:
                return DataTypeCompatibilityEnum.Same;
            case PrimitiveTypeEnum.Sequence:
            case PrimitiveTypeEnum.Enum:
            case PrimitiveTypeEnum.Boolean:
            case PrimitiveTypeEnum.Integer:
            case PrimitiveTypeEnum.Long:
                return DataTypeCompatibilityEnum.Compatible;
            case PrimitiveTypeEnum.DateTime:
            case PrimitiveTypeEnum.Text:
            case PrimitiveTypeEnum.LongText:
            case PrimitiveTypeEnum.LargeText:
            case PrimitiveTypeEnum.Decimal:
            case PrimitiveTypeEnum.Currency:
            case PrimitiveTypeEnum.BigCurrency:
            case PrimitiveTypeEnum.Binary:
            case PrimitiveTypeEnum.Guid:
                return DataTypeCompatibilityEnum.Different;
            default:
                throw new TTCallAdminException();
        }
    }
    constructor(dataType: TTDataType) {
        super(dataType);
        //_minValue = null;
        //_maxValue = null;
    }
}
export namespace DoubleType {
    export class TypeInfo {
        public static IsValueType: boolean = true;
        public static CodeType: string = "double";
        public static FullCodeType: string = "System.Double";
        public static NullableCodeType: string = TypeInfo.CodeType + (TypeInfo.IsValueType ? "?" : "");
        public static NullableFullCodeType: string = TypeInfo.FullCodeType + (TypeInfo.IsValueType ? "?" : "");
        public static PropertyTableName: string = "TTOBJECTPROPERTYFLOAT";
    }
}

export class IntegerType extends PrimitiveType<number>
{
    public static TryConvertFrom(value: Object, doInternationalParse: boolean, intValue: number): boolean {
        intValue = null;
        return false;
    }
    public static ConvertFrom(value: Object, doInternationalParse?: boolean): number {
        let intValue: number;
        if (IntegerType.TryConvertFrom(value, doInternationalParse, intValue))
            return intValue;
        throw new IncompatibleValueException(typeof IntegerType, value);
    }
    public get PrimitiveTypeEnum(): PrimitiveTypeEnum {
        return PrimitiveTypeEnum.Integer;
    }
    public get PropertyTableName(): string {
        return IntegerType.TypeInfo.PropertyTableName;
    }
    public get IsValueType(): boolean {
        return IntegerType.TypeInfo.IsValueType;
    }
    public get CodeType(): string {
        return IntegerType.TypeInfo.CodeType;
    }
    public get FullCodeType(): string {
        return IntegerType.TypeInfo.FullCodeType;
    }
    public GetDbType(providerType: DBProviderTypeEnum): string {
        switch (providerType) {
            case DBProviderTypeEnum.MSSqlServer:
                return "int";
            case DBProviderTypeEnum.Oracle:
                return "NUMBER(10)";
            default:
                throw new UnsupportedProviderType(providerType);
        }
    }
    public GetSqlLiteral(value: Object, providerType: DBProviderTypeEnum): string {
        return this.GetNqlLiteral(value);
    }
    public GetNqlLiteral(value: Object): string {
        let intVal: number;
        if (IntegerType.TryConvertFrom(value, false, intVal))
            return super.ToInternationalString(intVal);
        return null;
    }
    public TryConvertValue(value: Object, doInternationalParse: boolean, convertedValue: number): boolean {
        return IntegerType.TryConvertFrom(value, doInternationalParse, convertedValue);
    }
    public GetCompatibility(dataType: ITTDataTypeData): DataTypeCompatibilityEnum {
        switch (dataType.PrimitiveTypeEnum) {
            case PrimitiveTypeEnum.Enum:
            case PrimitiveTypeEnum.Integer:
                return DataTypeCompatibilityEnum.Same;
            case PrimitiveTypeEnum.Boolean:
                return DataTypeCompatibilityEnum.Compatible;
            case PrimitiveTypeEnum.Decimal:
                let length: number = dataType.Length;
                let precision: number = dataType.Precision;
                if (length <= 10 && precision === 0)
                    return DataTypeCompatibilityEnum.Compatible;
                return DataTypeCompatibilityEnum.Different;
            case PrimitiveTypeEnum.Double:
            case PrimitiveTypeEnum.Sequence:
            case PrimitiveTypeEnum.Long:
            case PrimitiveTypeEnum.DateTime:
            case PrimitiveTypeEnum.Text:
            case PrimitiveTypeEnum.LongText:
            case PrimitiveTypeEnum.LargeText:
            case PrimitiveTypeEnum.Currency:
            case PrimitiveTypeEnum.BigCurrency:
            case PrimitiveTypeEnum.Guid:
            case PrimitiveTypeEnum.Binary:
                return DataTypeCompatibilityEnum.Different;
            default:
                throw new TTCallAdminException();
        }
    }
    constructor(dataType: TTDataType) {
        super(dataType);
        //_minValue = null;
        //_maxValue = null;
    }
}
export namespace IntegerType {
    export class TypeInfo {
        public static IsValueType: boolean = true;
        public static CodeType: string = "int";
        public static FullCodeType: string = "System.Int32";
        public static NullableCodeType: string = TypeInfo.CodeType + (TypeInfo.IsValueType ? "?" : "");
        public static NullableFullCodeType: string = TypeInfo.FullCodeType + (TypeInfo.IsValueType ? "?" : "");
        public static PropertyTableName: string = "TTOBJECTPROPERTYINT";
    }
}

export class GuidType extends PrimitiveType<Guid>
{
    public static TryConvertFrom(value: Object, guidValue: Guid): boolean {
        guidValue = null;
        return false;
    }
    public static ConvertFrom(value: Object): Guid {
        let guidValue: Guid;
        if (GuidType.TryConvertFrom(value, guidValue))
            return guidValue;
        throw new IncompatibleValueException("GuidType", value);
    }
    public get PrimitiveTypeEnum(): PrimitiveTypeEnum {
        return PrimitiveTypeEnum.Guid;
    }
    public get PropertyTableName(): string {
        return GuidType.TypeInfo.PropertyTableName;
    }
    public get IsValueType(): boolean {
        return GuidType.TypeInfo.IsValueType;
    }
    public get CodeType(): string {
        return GuidType.TypeInfo.CodeType;
    }
    public get FullCodeType(): string {
        return GuidType.TypeInfo.FullCodeType;
    }
    public GetDbType(providerType: DBProviderTypeEnum): string {
        switch (providerType) {
            case DBProviderTypeEnum.MSSqlServer:
                return "uniqueidentifier";
            case DBProviderTypeEnum.Oracle:
                return "CHAR(36)";
            default:
                throw new UnsupportedProviderType(providerType);
        }
    }
    public GetSqlLiteral(value: Object, providerType: DBProviderTypeEnum): string {
        return this.GetNqlLiteral(value);
    }
    public GetNqlLiteral(value: Object): string {
        let guidVal: Guid;
        if (GuidType.TryConvertFrom(value, guidVal))
            return super.ToInternationalString(guidVal);
        return null;
    }
    protected CheckConstraints(value: Guid): boolean {
        return true;
    }
    public TryConvertValue(value: Object, doInternationalParse: boolean, convertedValue: Guid): boolean {
        return GuidType.TryConvertFrom(value, convertedValue);
    }
    public GetCompatibility(dataType: ITTDataTypeData): DataTypeCompatibilityEnum {
        switch (dataType.PrimitiveTypeEnum) {
            case PrimitiveTypeEnum.Guid:
                return DataTypeCompatibilityEnum.Same;
            case PrimitiveTypeEnum.Integer:
            case PrimitiveTypeEnum.Enum:
            case PrimitiveTypeEnum.Sequence:
            case PrimitiveTypeEnum.Long:
            case PrimitiveTypeEnum.Double:
            case PrimitiveTypeEnum.Currency:
            case PrimitiveTypeEnum.BigCurrency:
            case PrimitiveTypeEnum.Binary:
            case PrimitiveTypeEnum.Decimal:
            case PrimitiveTypeEnum.Text:
            case PrimitiveTypeEnum.LongText:
            case PrimitiveTypeEnum.LargeText:
            case PrimitiveTypeEnum.DateTime:
            case PrimitiveTypeEnum.Boolean:
                return DataTypeCompatibilityEnum.Different;
            default:
                throw new TTCallAdminException();
        }
    }
    constructor(dataType: TTDataType) {
        super(dataType);
        //_minValue = null;
        //_maxValue = null;
    }
}
export namespace GuidType {
    export class TypeInfo {
        public static IsValueType: boolean = true;
        public static CodeType: string = "Guid";
        public static FullCodeType: string = "System.Guid";
        public static NullableCodeType: string = TypeInfo.CodeType + (TypeInfo.IsValueType ? "?" : "");
        public static NullableFullCodeType: string = TypeInfo.FullCodeType + (TypeInfo.IsValueType ? "?" : "");
        public static PropertyTableName: string = "TTOBJECTPROPERTYGUID";
    }
}


export class LongTextType extends PrimitiveType<string>
{
    public static TryConvertFrom(value: Object, useInternationalFormat: boolean, stringValue: string): boolean {
        stringValue = null;
        return false;
    }
    public static ConvertFrom(value: Object, useInternationalFormat: boolean): string {
        let strValue: string;
        if (LongTextType.TryConvertFrom(value, useInternationalFormat, strValue))
            return strValue;
        throw new IncompatibleValueException(typeof LongTextType, value);
    }
    private _trimLeft: boolean;
    public get TrimLeft(): boolean {
        return this._trimLeft;
    }
    private _trimRight: boolean;
    public get TrimRight(): boolean {
        return this._trimRight;
    }
    private _trimMiddle: boolean;
    public get TrimMiddle(): boolean {
        return this._trimMiddle;
    }
    private _upperCase: boolean;
    public get UpperCase(): boolean {
        return this._upperCase;
    }
    private _unTurkish: boolean;
    public get UnTurkish(): boolean {
        return this._unTurkish;
    }
    public get PrimitiveTypeEnum(): PrimitiveTypeEnum {
        return PrimitiveTypeEnum.LongText;
    }
    public get PropertyTableName(): string {
        return LongTextType.TypeInfo.PropertyTableName;
    }
    public get IsValueType(): boolean {
        return LongTextType.TypeInfo.IsValueType;
    }
    public get CodeType(): string {
        return LongTextType.TypeInfo.CodeType;
    }
    public get FullCodeType(): string {
        return LongTextType.TypeInfo.FullCodeType;
    }
    public GetDbType(providerType: DBProviderTypeEnum): string {
        switch (providerType) {
            case DBProviderTypeEnum.MSSqlServer:
                return "varchar(MAX)";
            case DBProviderTypeEnum.Oracle:
                return "VARCHAR2(4000)";
            default:
                throw new UnsupportedProviderType(providerType);
        }
    }
    public GetSqlLiteral(value: Object, providerType: DBProviderTypeEnum): string {
        return this.GetNqlLiteral(value);
    }
    public GetNqlLiteral(value: Object): string {
        if (value === null)
            return null;
        return "'" + this.ToDBValue(value.toString().replace("'", "''")) + "'";
    }
    public TryConvertValue(value: Object, doInternationalParse: boolean, convertedValue: string): boolean {
        let ret: boolean = LongTextType.TryConvertFrom(value, doInternationalParse, convertedValue);

        return ret;
    }
    public FromDBValue(value: Object): string {
        if (value === null)
            return null;
        let stringValue: string = <string>value;
        if (stringValue.length === 0)
            return null;
        return stringValue;
    }
    public ToDBValue(value: string): Object {
        if (value === null)
            return null;
        return value;
    }
    public GetCompatibility(dataType: ITTDataTypeData): DataTypeCompatibilityEnum {
        switch (dataType.PrimitiveTypeEnum) {
            case PrimitiveTypeEnum.LongText:
                return DataTypeCompatibilityEnum.Same;
            case PrimitiveTypeEnum.Boolean:
            case PrimitiveTypeEnum.DateTime:
            case PrimitiveTypeEnum.Decimal:
            case PrimitiveTypeEnum.Double:
            case PrimitiveTypeEnum.Enum:
            case PrimitiveTypeEnum.Integer:
            case PrimitiveTypeEnum.Long:
            case PrimitiveTypeEnum.Sequence:
            case PrimitiveTypeEnum.Text:
            case PrimitiveTypeEnum.LargeText:
            case PrimitiveTypeEnum.Currency:
            case PrimitiveTypeEnum.BigCurrency:
            case PrimitiveTypeEnum.Guid:
                return DataTypeCompatibilityEnum.Convertible;
            case PrimitiveTypeEnum.Binary:
                return DataTypeCompatibilityEnum.Different;
            default:
                throw new TTCallAdminException();
        }
    }
    constructor(dataType: TTDataType) {
        super(dataType);
        //_minValue = null;
        //_maxValue = null;
    }
}
export namespace LongTextType {
    export class TypeInfo {
        public static IsValueType: boolean = false;
        public static CodeType: string = "string";
        public static FullCodeType: string = "System.String";
        public static NullableCodeType: string = TypeInfo.CodeType + (TypeInfo.IsValueType ? "?" : "");
        public static NullableFullCodeType: string = TypeInfo.FullCodeType + (TypeInfo.IsValueType ? "?" : "");
        public static PropertyTableName: string = "TTOBJECTPROPERTYLONGTEXT";
    }
}


export class LargeTextType extends LongTextType {
    public static TryConvertFrom(value: Object, useInternationalFormat: boolean, stringValue: string): boolean {
        stringValue = null;
        return false;
    }
    public static ConvertFrom(value: Object, useInternationalFormat?: boolean): string {
        let strValue: string;
        if (LargeTextType.TryConvertFrom(value, useInternationalFormat, strValue))
            return strValue;
        throw new IncompatibleValueException(typeof LargeTextType, value);
    }
    public get PrimitiveTypeEnum(): PrimitiveTypeEnum {
        return PrimitiveTypeEnum.LargeText;
    }
    public get PropertyTableName(): string {
        return LargeTextType.TypeInfo.PropertyTableName;
    }
    public get IsValueType(): boolean {
        return LargeTextType.TypeInfo.IsValueType;
    }
    public get CodeType(): string {
        return LargeTextType.TypeInfo.CodeType;
    }
    public get FullCodeType(): string {
        return LargeTextType.TypeInfo.FullCodeType;
    }
    public GetDbType(providerType: DBProviderTypeEnum): string {
        switch (providerType) {
            case DBProviderTypeEnum.MSSqlServer:
                return "text";
            case DBProviderTypeEnum.Oracle:
                return "CLOB";
            default:
                throw new UnsupportedProviderType(providerType);
        }
    }
    public GetCompatibility(dataType: ITTDataTypeData): DataTypeCompatibilityEnum {
        switch (dataType.PrimitiveTypeEnum) {
            case PrimitiveTypeEnum.LargeText:
                return DataTypeCompatibilityEnum.Same;
            case PrimitiveTypeEnum.Boolean:
            case PrimitiveTypeEnum.DateTime:
            case PrimitiveTypeEnum.Decimal:
            case PrimitiveTypeEnum.Double:
            case PrimitiveTypeEnum.Enum:
            case PrimitiveTypeEnum.Integer:
            case PrimitiveTypeEnum.Long:
            case PrimitiveTypeEnum.Sequence:
            case PrimitiveTypeEnum.Text:
            case PrimitiveTypeEnum.Currency:
            case PrimitiveTypeEnum.BigCurrency:
            case PrimitiveTypeEnum.Guid:
            case PrimitiveTypeEnum.LongText:
            case PrimitiveTypeEnum.Binary:
                return DataTypeCompatibilityEnum.NonCastable;
            default:
                throw new TTCallAdminException();
        }
    }
    constructor(dataType: TTDataType) {
        super(dataType);

    }
}
export namespace LargeTextType {
    export class TypeInfo {
        public static IsValueType: boolean = false;
        public static CodeType: string = "string";
        public static FullCodeType: string = "System.String";
        public static NullableCodeType: string = TypeInfo.CodeType + (TypeInfo.IsValueType ? "?" : "");
        public static NullableFullCodeType: string = TypeInfo.FullCodeType + (TypeInfo.IsValueType ? "?" : "");
        public static PropertyTableName: string = "TTOBJECTPROPERTYLARGETEXT";
    }
}

export class LongType extends PrimitiveType<number>
{
    public static TryConvertFrom(value: Object, doInternationalParse: boolean, longValue: number): boolean {
        longValue = null;
        return false;
    }
    public static ConvertFrom(value: Object, doInternationalParse?: boolean): number {
        let longValue: number;
        if (LongType.TryConvertFrom(value, doInternationalParse, longValue))
            return longValue;
        throw new IncompatibleValueException(typeof LongType, value);
    }
    public get PrimitiveTypeEnum(): PrimitiveTypeEnum {
        return PrimitiveTypeEnum.Long;
    }
    public get PropertyTableName(): string {
        return LongType.TypeInfo.PropertyTableName;
    }
    public get IsValueType(): boolean {
        return LongType.TypeInfo.IsValueType;
    }
    public get CodeType(): string {
        return LongType.TypeInfo.CodeType;
    }
    public get FullCodeType(): string {
        return LongType.TypeInfo.FullCodeType;
    }
    public GetDbType(providerType: DBProviderTypeEnum): string {
        switch (providerType) {
            case DBProviderTypeEnum.MSSqlServer:
                return "bigint";
            case DBProviderTypeEnum.Oracle:
                return "NUMBER(18)";
            default:
                throw new UnsupportedProviderType(providerType);
        }
    }
    public GetSqlLiteral(value: Object, providerType: DBProviderTypeEnum): string {
        return this.GetNqlLiteral(value);
    }
    public GetNqlLiteral(value: Object): string {
        let longVal: number;
        if (LongType.TryConvertFrom(value, false, longVal))
            return super.ToInternationalString(longVal);
        return null;
    }
    public TryConvertValue(value: Object, doInternationalParse: boolean, convertedValue: number): boolean {
        return LongType.TryConvertFrom(value, doInternationalParse, convertedValue);
    }
    public GetCompatibility(dataType: ITTDataTypeData): DataTypeCompatibilityEnum {
        switch (dataType.PrimitiveTypeEnum) {
            case PrimitiveTypeEnum.Sequence:
            case PrimitiveTypeEnum.Long:
                return DataTypeCompatibilityEnum.Same;
            case PrimitiveTypeEnum.Enum:
            case PrimitiveTypeEnum.Integer:
            case PrimitiveTypeEnum.Boolean:
                return DataTypeCompatibilityEnum.Compatible;
            case PrimitiveTypeEnum.Double:
            case PrimitiveTypeEnum.Decimal:
            case PrimitiveTypeEnum.Text:
            case PrimitiveTypeEnum.LongText:
            case PrimitiveTypeEnum.LargeText:
            case PrimitiveTypeEnum.DateTime:
            case PrimitiveTypeEnum.Binary:
            case PrimitiveTypeEnum.Guid:
            case PrimitiveTypeEnum.Currency:
            case PrimitiveTypeEnum.BigCurrency:
                return DataTypeCompatibilityEnum.Different;
            default:
                throw new TTCallAdminException();
        }
    }
    constructor(dataType: TTDataType) {
        super(dataType);
        //_minValue = null;
        //_maxValue = null;
    }
}
export namespace LongType {
    export class TypeInfo {
        public static IsValueType: boolean = true;
        public static CodeType: string = "long";
        public static FullCodeType: string = "System.Int64";
        public static NullableCodeType: string = TypeInfo.CodeType + (TypeInfo.IsValueType ? "?" : "");
        public static NullableFullCodeType: string = TypeInfo.FullCodeType + (TypeInfo.IsValueType ? "?" : "");
        public static PropertyTableName: string = "TTOBJECTPROPERTYINT";
    }
}

export class SequenceType extends LongType {
    private _isDBSequence: boolean;
    public get IsDBSequence(): boolean {
        return this._isDBSequence;
    }
    private _isYearly: boolean;
    public get IsYearly(): boolean {
        return this._isYearly;
    }
    private _allowGrouping: boolean;
    public get AllowGrouping(): boolean {
        return this._allowGrouping;
    }
    public get PrimitiveTypeEnum(): PrimitiveTypeEnum {
        return PrimitiveTypeEnum.Sequence;
    }
    public get DBSequenceName(): string {
        return Globals.MakeVariableName(super.getDataType().Name).toUpperCase();
    }
    constructor(dataType: TTDataType) {
        super(dataType);

    }
}


export class TextType extends LongTextType {
    public get PrimitiveTypeEnum(): PrimitiveTypeEnum {
        return PrimitiveTypeEnum.Text;
    }
    public get PropertyTableName(): string {
        return TextType.TypeInfo.PropertyTableName;
    }
    private _length: number;
    public get Length(): number {
        return this._length;
    }
    public GetDbType(providerType: DBProviderTypeEnum): string {
        switch (providerType) {
            case DBProviderTypeEnum.MSSqlServer:
                return "varchar(" + this._length + ")";
            case DBProviderTypeEnum.Oracle:
                return "VARCHAR2(" + this._length + ")";
            default:
                throw new UnsupportedProviderType(providerType);
        }
    }
    public GetCompatibility(dataType: ITTDataTypeData): DataTypeCompatibilityEnum {
        switch (dataType.PrimitiveTypeEnum) {
            case PrimitiveTypeEnum.Text:
                let length: number = dataType.Length;
                if (this._length === length)
                    return DataTypeCompatibilityEnum.Same;
                if (this._length > length)
                    return DataTypeCompatibilityEnum.Compatible;
                return DataTypeCompatibilityEnum.Convertible;
            case PrimitiveTypeEnum.Boolean:
            case PrimitiveTypeEnum.DateTime:
            case PrimitiveTypeEnum.Decimal:
            case PrimitiveTypeEnum.Double:
            case PrimitiveTypeEnum.Enum:
            case PrimitiveTypeEnum.Integer:
            case PrimitiveTypeEnum.Long:
            case PrimitiveTypeEnum.Sequence:
            case PrimitiveTypeEnum.Guid:
            case PrimitiveTypeEnum.Currency:
            case PrimitiveTypeEnum.BigCurrency:
                return DataTypeCompatibilityEnum.Convertible;
            case PrimitiveTypeEnum.Binary:
            case PrimitiveTypeEnum.LongText:
            case PrimitiveTypeEnum.LargeText:
                return DataTypeCompatibilityEnum.Different;
            default:
                throw new TTCallAdminException();
        }
    }
    private CheckLength(): void {
        if (this._length > TextType.TypeInfo.MaxLength)
            throw new DataDictionaryException("Length cannot be greater than " + TextType.TypeInfo.MaxLength + ".");
        if (this._length <= 0)
            throw new DataDictionaryException("Length cannot be 0.");
    }
    constructor(dataType: TTDataType) {
        super(dataType);
        //_minValue = null;
        //_maxValue = null;
        this._length = TextType.TypeInfo.DefaultLength;
    }
}
export namespace TextType {
    export class TypeInfo {
        public static IsValueType: boolean = LongTextType.TypeInfo.IsValueType;
        public static CodeType: string = LongTextType.TypeInfo.CodeType;
        public static FullCodeType: string = LongTextType.TypeInfo.FullCodeType;
        public static NullableCodeType: string = LongTextType.TypeInfo.NullableCodeType;
        public static NullableFullCodeType: string = LongTextType.TypeInfo.NullableFullCodeType;
        public static PropertyTableName: string = "TTOBJECTPROPERTYTEXT";
        public static DefaultLength: number = 255;
        public static MaxLength: number = 2000;
    }
}

export class EnumType extends IntegerType {
    public get PrimitiveTypeEnum(): PrimitiveTypeEnum {
        return PrimitiveTypeEnum.Enum;
    }
    public get IsValueType(): boolean {
        return EnumType.TypeInfo.IsValueType;
    }
    public get CodeType(): string {
        return EnumType.TypeInfo.GetCodeType(super.getDataType().Name);
    }
    public get FullCodeType(): string {
        return EnumType.TypeInfo.GetFullCodeType(super.getDataType().Name);
    }
    private _isFlagTypeEnum: boolean;
    public get IsFlagTypeEnum(): boolean {
        return this._isFlagTypeEnum;
    }
    public set IsFlagTypeEnum(value: boolean) {
        this._isFlagTypeEnum = value;
    }
    private _valueDefs: TTUtils.Collections.DualKeyCollection<string, number, EnumValueDef>;
    public get ValueDefs(): TTUtils.Collections.DualKeyCollection<string, number, EnumValueDef> {
        return this._valueDefs;
    }
    protected CheckConstraints(value: number): boolean {
        if (value)
            return this._valueDefs.ContainsKey2(value);
        return true;
    }
    constructor(dataType: TTDataType) {
        super(dataType);
        //_minValue = null;
        //_maxValue = null;
        this._valueDefs = null;
    }

    public TryConvertValue(value: Object, doInternationalParse: boolean, convertedValue: number): boolean {
        if (typeof value === "string") {
            let sVal: string = <string>value;
            if (this._valueDefs.ContainsKey1(sVal)) {
                convertedValue = this._valueDefs[sVal].Value;
                return true;
            }
        }
    }
    public ToString(value: number): string {
        if (this._valueDefs.ContainsKey2(value))
            return this._valueDefs[value].DisplayText;
        return value.toString();
    }
}
export namespace EnumType {
    export class TypeInfo {
        public static IsValueType: boolean = true;
        public static CodeType: string = "int";
        public static FullCodeType: string = "System.Int32";
        public static NullableCodeType: string = TypeInfo.CodeType + (TypeInfo.IsValueType ? "?" : "");
        public static NullableFullCodeType: string = TypeInfo.FullCodeType + (TypeInfo.IsValueType ? "?" : "");
        public static PropertyTableName: string = "TTOBJECTPROPERTYINT";
        public static GetCodeType(dataTypeName: string): string {
            return Globals.MakeVariableName(dataTypeName);
        }
        public static GetFullCodeType(dataTypeName: string): string {
            return "TTObjectClasses." + TypeInfo.GetCodeType(dataTypeName);
        }
        public static GetNullableCodeType(dataTypeName: string): string {
            return TypeInfo.GetCodeType(dataTypeName) + (TypeInfo.IsValueType ? "?" : "");
        }
        public static GetNullableFullCodeType(dataTypeName: string): string {
            return TypeInfo.GetFullCodeType(dataTypeName) + (TypeInfo.IsValueType ? "?" : "");
        }
    }
}
