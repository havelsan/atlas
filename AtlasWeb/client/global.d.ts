export { };

declare global {

    interface StringConstructor {
        isNullOrEmpty(text: string): boolean;
        Length: any;
    }

    interface String {
        isNullOrEmpty(text: string): boolean;
        Equals(text: string): boolean;
        Contains(text: string): boolean;
        Length: any;
        Value: number;
        ToUpper(): string;
    }
    interface Number {
        Value: number;
        HasValue(): boolean;
        Equals(text: number): boolean;
    }

    interface Boolean {
        HasValue: boolean;
    }

    interface DateConstructor {
        daysinMonth(): number;
        Now: Date;
        MinValue: Date;
        MaxValue: Date;
        HasValue(): boolean;
        Today: number;
        Subtract(val: Date): any;
        Compare(val: Date, val2: Date): number;
        Parse(val: string): Date;
    }

    interface Date {
        HasValue(): boolean;
        Equals(target: Date): boolean;
        AddDays(numDays: number): Date;
        AddYears(numYears: number): Date;
        AddMonths(numMonths: number): Date;
        AddHours(numHours: number): Date;
        AddMinutes(numMinutes: number): Date;
        //Subtract(d: Date): TimeSpan;
        daysinMonth(): number;
        Date: Date;
        DayOfYear: any;
        DayOfWeek: any;
        TotalDays: any;
        Year: number;
        Month: number;
        Day: number;
        Today: number;
        Hour: number;
        Minute: number;
        ToShortDateString(): string;
        Value: string;
        Subtract(val: number): any;
        getWeekNumber(): number;
    }

    interface Array<T> {
        AddNew();
        Clear();
        Contains(text: any): boolean;
    }

    interface ConnectionManager {
        GuidToString(val: any): string;
    }

    class RTFEntryForm {
        ShowAndGetRTF(val: string): string;
    }

    interface DateUtil {
        Now: Date;
        dayDiff(first: Date, second: Date);
    }

    interface Globals {
        IsDate(val: string): boolean;
        CreateNQLToDateParameter(d: Date): string;
    }

    interface Object {
        Index: number;
        NewValue: string;
        Equals(text: string): boolean;
    }

    interface Math {
        Round(value: number, radix: number): number;
        Floor(value: number): number;
        Truncate(value: number): number;
        Ceiling(value: number): number;
        Abs(value: number): number;
    }

    type Currency = number;
    type BigCurrency = number;

}

declare var ApplicationGlobals: any;
declare function redirectProperty(source: any, sourcePropertyName: string, target: any, targetPropertyName: string): void;    
declare var Globalize: any;
