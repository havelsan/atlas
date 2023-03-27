import { Guid } from "../../Mscorlib/Guid";
import { PrimitiveTypeEnum } from "../Enums/PrimitiveTypeEnum";
import { DBProviderTypeEnum } from "../Enums/DBProviderTypeEnum";
import { DataTypeCompatibilityEnum } from "../Enums/DataTypeCompatibilityEnum";

export interface ITTDataTypeData {
    DataTypeID: Guid;
    Name: string;
    Description: string;
    PrimitiveTypeEnum: PrimitiveTypeEnum;
    Length: number;
    Precision: number;
    MinValue: string;
    MaxValue: string;
    DefaultValue: string;
    //Properties: string;
    PropertyTableName: string;
    IsValueType: boolean;
    CodeType: string;
    FullCodeType: string;
    NullableCodeType: string;
    NullableFullCodeType: string;
    GetDbType(providerType: DBProviderTypeEnum): string;
    GetCompatibility(dataType: ITTDataTypeData): DataTypeCompatibilityEnum;
    FromInternationalString(value: string): Object;
    ToInternationalString(value: Object): string;
    ConvertValue(value: Object): Object;
    FromDBValue(value: Object): Object;
    ToDBValue(value: Object): Object;
    /*[Browsable(false)]*/
    IsBinary: boolean;
    /*[Browsable(false)]*/
    IsBoolean: boolean;
    /*[Browsable(false)]*/
    IsEnum: boolean;
    /*[Browsable(false)]*/
    IsInt32: boolean;
    /*[Browsable(false)]*/
    IsInt64: boolean;
    /*[Browsable(false)]*/
    IsSequence: boolean;
    /*[Browsable(false)]*/
    IsInteger: boolean;
    /*[Browsable(false)]*/
    IsDouble: boolean;
    /*[Browsable(false)]*/
    IsDecimal: boolean;
    /*[Browsable(false)]*/
    IsSmallCurrency: boolean;
    /*[Browsable(false)]*/
    IsBigCurrency: boolean;
    /*[Browsable(false)]*/
    IsCurrency: boolean;
    /*[Browsable(false)]*/
    IsFloat: boolean;
    /*[Browsable(false)]*/
    IsDateTime: boolean;
    /*[Browsable(false)]*/
    IsLongText: boolean;
    /*[Browsable(false)]*/
    IsShortText: boolean;
    /*[Browsable(false)]*/
    IsText: boolean;
    /*[Browsable(false)]*/
    IsGuid: boolean;
    /*[Browsable(false)]*/
    //GetEnumValueDef(valueName: string): ITTEnumValueDef;
}