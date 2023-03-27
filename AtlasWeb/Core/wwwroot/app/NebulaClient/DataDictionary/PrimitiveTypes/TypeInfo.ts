export class TypeInfo {
    public static IsValueType: boolean = true;
    public static CodeType: string = "int";
    public static FullCodeType: string = "System.Int32";
    public static NullableCodeType: string = TypeInfo.CodeType + (TypeInfo.IsValueType ? "?" : "");
    public static NullableFullCodeType: string = TypeInfo.FullCodeType + (TypeInfo.IsValueType ? "?" : "");
    public static PropertyTableName: string = "TTOBJECTPROPERTYINT";
}