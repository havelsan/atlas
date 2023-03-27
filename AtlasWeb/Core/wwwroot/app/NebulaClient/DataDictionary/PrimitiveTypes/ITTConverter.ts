export interface ITTConverter {
    IsCompatibleValue(value: Object): boolean;
    TryConvertValue(value: Object, doInternationalParse: boolean, convertedValue: Object): boolean;
    ConvertValue(value: Object): Object;
    FromDBValue(value: Object): Object;
    ToDBValue(value: Object): Object;
    FromInternationalString(value: string): Object;
    ToInternationalString(value: Object): string;
    ToString(value: Object): string;
}