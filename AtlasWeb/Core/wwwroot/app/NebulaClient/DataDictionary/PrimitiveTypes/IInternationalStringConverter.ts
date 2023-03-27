export interface IInternationalStringConverter {
    FromInternationalString(value: string): Object;
    ToInternationalString(value: Object): string;
}