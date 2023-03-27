export class Globals {

    public static IsDate(date: string): boolean {
        let myDateStr = new Date(date);
        if (!isNaN(myDateStr.getMonth())) {
            return true;
        }
        else {
            return false;
        }
    }

    public static IsNumeric(s: string): boolean {
        return !isNaN(parseFloat(s));
    }

    public static IsDouble(s: string): boolean {
        let n = Number(s);
        return n === +n && n !== (n | 0);
    }

    public static isNumber(value): boolean {
        if ((undefined === value) || (null === value)) {
            return false;
        }
        if (typeof value == 'number') {
            return true;
        }
        return !isNaN(value - 0);
    }

}