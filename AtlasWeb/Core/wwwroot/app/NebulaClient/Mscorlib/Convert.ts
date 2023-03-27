export class Convert {
    public static toString(value: number): string {
        return value.toString();
    }
    public static ToBoolean(value: string | number): boolean {
        return Boolean(value);
    }
    public static ToDateTime(value: string | Date): Date {
        if (value == null)
            return null;

        if (typeof value === 'string') {
            value = value.replace(/\./g, '/');
            return new Date(value as string);
        }
        return new Date(value.getTime()); //yeni instance olu�turmas� i�in
    }
    public static ToInt64(value: string | number): number {
        return Number(value);
    }
    public static ToInt32(value: string | boolean | number | any): number {
        return Number(value);
    }
    public static ToDouble(value: string | number): number {
        return Number(value);
    }
}