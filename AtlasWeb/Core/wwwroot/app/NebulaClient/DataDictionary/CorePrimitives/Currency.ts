/*import { IComparable } from "../../System/IComparable";
import { IConvertible } from "../../System/IConvertable";
import { IEquatable } from "../../System/IEquatable";
import { OverflowException } from "../../System/Exceptions/OverflowException";
import { ArgumentException } from "../../System/Exceptions/ArgumentException";
import { NotImplementedException } from "../../System/Exceptions/NotImplementedException";
import { IFormatProvider } from "../../System/IFormatProvider";
*/

export type Currency = number;

/*[Serializable, StructLayout(LayoutKind.Sequential), ComVisible(true)]
export class Currency implements IComparable<any>, IConvertible, IEquatable<number>
{
    public static Length: number = 15;
    public static Precision: number = 4;
    private static _minValue: number = -10000000000.9999;
    private static _maxValue: number = 10000000000.9999;

    public static get MinValue(): Currency {
        return Currency.constructFromNumber(Currency._minValue);
    }
    public static get MaxValue(): Currency {
        return Currency.constructFromNumber(Currency._maxValue);
    }
    private m_value: number;
    private CheckRange(): void {
        if (this.m_value < Currency._minValue || this.m_value > Currency._maxValue)
            throw new OverflowException("Value was either too large or too small for a Currency.");
    }

    public get HasValue(): boolean {
        return this.m_value === undefined;
    }

    public get Value(): number {
        return this.m_value;
    }

    constructor() {
    }

    private static constructFromNumber(d: number): Currency {
        var currency = new Currency();
        currency.m_value = <number>d;
        currency.CheckRange();
        return currency;
    }

    public compareTo(value: any): number {
        if (value === null) {
            return 1;
        }
        if (!(typeof value === "number") && !(value instanceof Currency)) {
            throw new ArgumentException("Value must be double or Currency.");
        }
        let d: number;
        if (typeof value === "number")
            d = <number>value;
        else d = (<Currency>value).m_value;
        if (this.m_value < d) {
            return -1;
        }
        if (this.m_value > d) {
            return 1;
        }
        return 0;
    }

    public equals(obj: number): boolean {
        //TODO: Implement equals
        throw new NotImplementedException();
    }

    public getHashCode(): number {
        //TODO: Implement getHashCode
        throw new NotImplementedException();
    }

    toBoolean(provider: IFormatProvider): boolean {
        //TODO: Implement boolean conversion
        throw new NotImplementedException();
    }

    toNumber(provider?: IFormatProvider): number {
        //TODO: Implement number conversion
        return this.m_value;
    }

    toString(provider: IFormatProvider): string {
        //TODO: Implement string conversion
        return this.m_value.toString();
    }

}
*/