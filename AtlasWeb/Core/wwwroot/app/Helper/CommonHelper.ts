import { Guid } from "NebulaClient/Mscorlib/Guid";
import { StringBuilder } from "NebulaClient/System/Text/StringBuilder";
import { TTObjectDefManager } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectDefManager";
import * as FileSaver from 'file-saver';

export class CommonHelper {

    private static async CreateFilterExpression(filterExpression: string, guidList: Array<Guid>): Promise<string> {
        let criteriaList: Array<StringBuilder> = new Array<StringBuilder>();
        let sbObjIDs: StringBuilder = new StringBuilder();
        let i: number = 0;
        for (let ID of guidList) {
            i++;
            if (sbObjIDs.Length > 0)
                sbObjIDs.append(',');
            //  sbObjIDs.append(ConnectionManager.GuidToString(ID));
            if (i === 1000) {
                i = 0;
                criteriaList.push(sbObjIDs);
                sbObjIDs = new StringBuilder();
            }
        }
        if (i > 0 && i < 1000)
            criteriaList.push(sbObjIDs);
        if (filterExpression !== null)
            filterExpression += " AND ";
        i = 1;
        for (let ids of criteriaList) {
            if (i === 1)
                filterExpression += "(";
            filterExpression += "OBJECTID IN (" + ids + ")";
            if (i < criteriaList.length)
                filterExpression += " OR ";
            if (i === criteriaList.length)
                filterExpression += ")";
            i++;
        }
        return filterExpression;
    }

    public static CheckMernisNumber(x: number): boolean {
        let a = x.toString();
        if (parseInt(a.substr(0, 1)) === 0 && a.length != 11) {
            return false;
        }
        let i = 9, md = '', mc = '', digit, mr = '';
        while (digit = a.charAt(--i)) {
            i % 2 == 0 ? md += digit : mc += digit;
        }
        if (((eval(md.split('').join('+')) * 7) - eval(mc.split('').join('+'))) % 10 != parseInt(a.substr(9, 1), 10)) {
            return false;
        }
        for (let c = 0; c <= 9; c++) {
            mr += a.charAt(c);
        }
        if (eval(mr.split('').join('+')) % 10 != parseInt(a.substr(10, 1), 10)) {
            return false;
        }
        return true;

    }


    public static IsNumeric(s: string): boolean {
        return !isNaN(parseFloat(s));
    }

    public static LatinAlphabetUsed: boolean = true;
    public static Tokenize(s: string, wildCard: boolean): Array<any> {
        let ts: string;
        let tmpToken: string = "";
        let subChar: string;
        let Tokens: Array<any> = new Array<any>();
        if (s != null) {
            ts = this.CUCase(s, false, false);
            for (let i: number = 0; i <= ts.length - 1; i++) {
                subChar = ts.substring(i, 1).split("", 1)[0]; // buradan çok emin olamadım.
                if (this.LatinAlphabetUsed && ((subChar >= 'A' && subChar <= 'Z') || (subChar >= 'a' && subChar <= 'z')))
                    tmpToken += subChar.toString();
                else if (!this.LatinAlphabetUsed && subChar != ' ')
                    tmpToken += subChar.toString();
                else if (wildCard && subChar == '%')
                    tmpToken += subChar.toString();
                else {
                    if (tmpToken.length > 0)
                        Tokens.push(tmpToken);
                    tmpToken = "";
                }
            }
            if (tmpToken.length > 0)
                Tokens.push(tmpToken);
        }
        return Tokens;
    }

    public static RecTime(): Date {
        return TTObjectDefManager.GetServerTime(false);
    }

    public static ConvertHourToString(hour: number): string {
        let hourShow: string = "";
        if (hour == 24) {
            hourShow = "00";
        }
        else {
            if (hour < 10) {
                hourShow = "0";
            }
            hourShow = hourShow + hour;
        }
        hourShow = hourShow + ":00";
        return hourShow;
    }

    public static daysinMonthfromInput(year: number, month: number): number {
        return (new Date(year, month - 1, 1)).daysinMonth();
    }

    public static DateDiff(dateIntervalEnum: DateIntervalEnum, Date1: Date, Date2: Date): number {
        if (Date1 < Date2) {
            let tempDate: Date = Date1;
            Date1 = Date2;
            Date2 = tempDate;
        }
        let _years: number = <number>(Date1.Year - Date2.Year);
        let _months: number = <number>(Date1.Month - Date2.Month);
        let _days: number = <number>(Date1.Day - Date2.Day);
        let _date1Year: number = Date1.Year;
        let _date1Month: number = Date1.Month;
        while (_days < 0) {
            _months--;
            _days += this.daysinMonthfromInput(_date1Year, _date1Month);
            _date1Month--;
            if (_date1Month < 1) {
                _date1Month = 12;
                _date1Year--;
            }
        }
        while (_months < 0) {
            _years--;
            _months += 12;
        }
        switch (dateIntervalEnum) {
            case DateIntervalEnum.Day:
                let ts: Date; //= Date1.Subtract(Date2);
                return <number>ts.TotalDays;
            case DateIntervalEnum.Month:
                return (_years * 12) + _months;
            case DateIntervalEnum.Year:
                return <number>(Date1.Year - Date2.Year);
            case DateIntervalEnum.DayLeftOver:
                return _days;
            case DateIntervalEnum.MonthLeftOver:
                return _months;
            case DateIntervalEnum.YearCompleted:
                return _years;
            default:
            // throw new TTException(await SystemMessageService.GetMessage(656,""));
        }
    }

    public static CUCase(s: string, saveTurkish: boolean, AlphaOnly: boolean): string {
        let r: string;
        let i: number;
        if ((s == null)) {
            return "";
        }

        r = "";
        for (i = 0; (i < s.length); i++) {
            let substr: string = s.substring(i, 1);
            switch (substr) {
                case "Ğ":
                case "ğ":
                    r = r + (saveTurkish ? "Ğ" : "G");
                    break;
                case "Ü":
                case "ü":
                    r = r + (saveTurkish ? "Ü" : "U");
                    break;
                case "Ş":
                case "ş":
                    r = r + (saveTurkish ? "Ş" : "S");
                    break;
                case "Ö":
                case "ö":
                    r = r + (saveTurkish ? "Ö" : "O");
                    break;
                case "Ç":
                case "ç":
                    r = r + (saveTurkish ? "Ç" : "C");
                    break;
                case "İ":
                case "i":
                    r = r + (saveTurkish ? "İ" : "I");
                    break;
                case "ı":
                    r = r + (saveTurkish ? "I" : "I");
                    break;
                default:
                    if (this.Ucase(substr).localeCompare("A") >= 0 && this.Ucase(substr).localeCompare("Z") <= 0) {
                        r = r + this.Ucase(substr);
                    }
                    else {
                        if (substr == " ") {
                            r = r + substr;
                        }
                        else {
                            if (!AlphaOnly) {
                                r = r + substr;
                            }
                        }
                    }
                    break;
            }
        }
        return r;
    }

    public static Ucase(instr: string): string {
        let flag: boolean = instr === null;
        let result: string;
        if (flag) {
            result = "";
        }
        else {
            result = instr.toUpperCase();
        }
        return result;
    }

    public static saveFile(data: Blob, fileName: string, disableAutoBOM?: boolean) {
        if (typeof (<any>FileSaver).default === 'function') {
            (<any>FileSaver).default(data, fileName, disableAutoBOM);
        } else  if (typeof FileSaver === 'function') {
            (<any>FileSaver)(data, fileName, disableAutoBOM);
        } else {
            FileSaver.saveAs(data, fileName, disableAutoBOM);
        }

    }

    public static getInnerText(html : string){
        let div = document.createElement("div");
        div.innerHTML = html;
        return div.innerText;
    }

}

export enum DateIntervalEnum {
    Day = 0,

    Month = 1,

    Year = 2,

    DayLeftOver = 3,

    MonthLeftOver = 4,

    YearCompleted = 5
}