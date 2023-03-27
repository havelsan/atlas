/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Based on .NET DateTime's interface.
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import { ICalendarDate, ITimeStamp } from './ITimeStamp';
import { TimeSpan } from './TimeSpan';
import { ClockTime } from './ClockTime';
import { Milliseconds } from './HowMany';
import { TimeStamp } from './TimeStamp';
import { IDateTime } from './IDateTime';
import { Gregorian } from './Calendars';
import { ITimeQuantity } from './ITimeQuantity';

export class DateTime implements ICalendarDate, IDateTime {
    private _value: Date;

    toJsDate(): Date {
        return new Date(this._value.getTime()); // return a clone.
    }

    private _setJsDate(value: Date) {
        this._time = null;
        this._value = new Date(value.getTime());
    }

    constructor();
    constructor(dateString: string, kind?: DateTime.Kind);
    constructor(milliseconds: number, kind?: DateTime.Kind);
    constructor(source: Date, kind?: DateTime.Kind);
    constructor(source: DateTime, kind?: DateTime.Kind);
    constructor(value: any = new Date(), kind: DateTime.Kind = DateTime.Kind.Local) {
        const _ = this;
        _._kind = kind;
        if (value instanceof DateTime) {
            _._value = value.toJsDate();
        } else if (Object.prototype.toString.call(value) === '[object Date]') {
            _._setJsDate(value);
        } else {
            _._value = value === void (0)
                ? new Date()
                : new Date(value);
        }
    }

    private _kind: DateTime.Kind;
    get kind(): DateTime.Kind {
        return this._kind;
    }

    get year(): number {
        return this._value.getFullYear();
    }

    /**
         * Returns the Gregorian Month (zero indexed).
         * @returns {number}
         */
    get month(): Gregorian.Month {
        return this._value.getMonth();
    }

    /**
         * Returns the month number (1-12).
         * @returns {number}
         */
    get calendarMonth(): number {
        return this._value.getMonth() + 1;
    }

    get calendar(): ICalendarDate {
        return {
            year: this.year,
            month: this.calendarMonth,
            day: this.day
        };
    }

    /**
         * Returns the day of the month.  An integer between 1 and 31.
         * @returns {number}
         */
    get day(): number {
        return this._value.getDate();
    }

    /**
         * Returns the day of the month indexed starting at zero.
         * @returns {number}
         */
    get dayIndex(): number {
        return this._value.getDate() - 1;
    }

    /**
         * Returns the zero indexed day of the week. (Sunday == 0)
         * @returns {number}
         */
    get dayOfWeek(): Gregorian.DayOfWeek {
        return this._value.getDay();
    }


    addMilliseconds(ms: number): DateTime {
        ms = ms || 0;
        return new DateTime(this._value.getTime() + ms, this._kind);
    }

    addSeconds(seconds: number): DateTime {
        seconds = seconds || 0;
        return this.addMilliseconds(seconds * Milliseconds.Per.Second);
    }

    addMinutes(minutes: number): DateTime {
        minutes = minutes || 0;
        return this.addMilliseconds(minutes * Milliseconds.Per.Minute);
    }

    addHours(hours: number): DateTime {
        hours = hours || 0;
        return this.addMilliseconds(hours * Milliseconds.Per.Hour);
    }

    addDays(days: number): DateTime {
        days = days || 0;
        return this.addMilliseconds(days * Milliseconds.Per.Day);
    }

    addMonths(months: number): DateTime {
        months = months || 0;
        let d = this.toJsDate();
        d.setMonth(d.getMonth() + months);
        return new DateTime(d, this._kind);
    }

    addYears(years: number): DateTime {
        years = years || 0;
        let d = this.toJsDate();
        d.setFullYear(d.getFullYear() + years);
        return new DateTime(d, this._kind);
    }


    /**
         * Receives an ITimeQuantity value and adds based on the total milliseconds.
         * @param {ITimeQuantity} time
         * @returns {DateTime}
         */
    add(time: ITimeQuantity): DateTime {
        return this.addMilliseconds(time.getTotalMilliseconds());
    }

    /**
         * Receives an ITimeQuantity value and subtracts based on the total milliseconds.
         * @param {ITimeQuantity} time
         * @returns {DateTime}
         */
    subtract(time: ITimeQuantity): DateTime {
        return this.addMilliseconds(-time.getTotalMilliseconds());
    }

    /**
         * Returns a TimeSpan representing the amount of time between two dates.
         * @param previous
         * @returns {TimeSpan}
         */
    timePassedSince(previous: Date | DateTime): TimeSpan {
        return DateTime.between(previous, this);
    }

    /**
         * Returns a DateTime object for 00:00 of this date.
         */
    get date(): DateTime {
        const _ = this;
        return new DateTime(
            new Date(
                _.year,
                _.month,
                _.day
            )
            , _._kind
        );
    }

    private _time: ClockTime;

    /**
         * Returns the time of day represented by a ClockTime object.
         * @returns {ClockTime}
         */
    get timeOfDay(): ClockTime {
        let _ = this, t = _._time;
        if (!t) {
            let d = this._value;
            _._time = t = new ClockTime(
                d.getHours(),
                d.getMinutes(),
                d.getSeconds(),
                d.getMilliseconds());
        }
        return t;
    }

    /**
         * Returns a readonly object which contains all the date and time components.
         */
    toTimeStamp(): ITimeStamp {
        return TimeStamp.from(this);
    }

    /**
         * Returns the now local time.
         * @returns {DateTime}
         */
    static get now(): DateTime {
        return new DateTime();
    }

    /**
         * Returns a UTC version of this date if its kind is local.
         * @returns {DateTime}
         */
    get toUniversalTime(): DateTime {
        const _ = this;
        if (_._kind !== DateTime.Kind.Local) {
            return new DateTime(_, _._kind);
        }

        let d = _._value;
        return new DateTime(
            new Date(
                d.getUTCFullYear(),
                d.getUTCMonth(),
                d.getUTCDate(),
                d.getUTCHours(),
                d.getUTCMinutes(),
                d.getUTCSeconds(),
                d.getUTCMilliseconds()
            ),
            DateTime.Kind.Utc
        );
    }

    /**
         * The date component for now.
         * @returns {DateTime}
         */
    static get today(): DateTime {
        return DateTime.now.date;
    }

    /**
         * Midnight tomorrow.
         * @returns {DateTime}
         */
    static get tomorrow(): DateTime {
        let today: DateTime = DateTime.today;
        return today.addDays(1);
    }

    /**
         * Measures the difference between two dates as a TimeSpan.
         * @param first
         * @param last
         */
    static between(first: Date | DateTime, last: Date | DateTime): TimeSpan {
        let f: Date = first instanceof DateTime ? first._value : <Date>first,
            l: Date = last instanceof DateTime ? last._value : <Date>last;

        return new TimeSpan(l.getTime() - f.getTime());
    }

    /**
         * Calculates if the given year is a leap year using the formula:
         * ((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)
         * @param year
         * @returns {boolean}
         */
    static isLeapYear(year: number): boolean {
        return ((year % 4 === 0) && (year % 100 !== 0)) || (year % 400 === 0);
    }

    /**
         * Returns the number of days for the specific year and month.
         * @param year
         * @param month
         * @returns {any}
         */
    static daysInMonth(year: number, month: Gregorian.Month): number {
        // Basically, add 1 month, subtract a day... What's the date?
        return (new Date(year, month + 1, 0)).getDate();
    }

    static from(calendarDate: ICalendarDate): DateTime;
    static from(year: number, month: Gregorian.Month, day: number): DateTime;
    static from(
        yearOrDate: number | ICalendarDate,
        month?: number,
        day?: number): DateTime {
        let year: number;
        if (typeof yearOrDate === 'object') {
            day = (<ICalendarDate>yearOrDate).day;
            month = (<ICalendarDate>yearOrDate).month;
            year = (<ICalendarDate>yearOrDate).year;
        }

        return new DateTime(new Date(year, month, day));

    }


    static fromCalendarDate(calendarDate: ICalendarDate): DateTime;
    static fromCalendarDate(year: number, month: number, day: number): DateTime;
    static fromCalendarDate(
        yearOrDate: number | ICalendarDate,
        month?: number,
        day?: number): DateTime {
        let year: number;
        if (typeof yearOrDate === 'object') {
            day = (<ICalendarDate>yearOrDate).day;
            month = (<ICalendarDate>yearOrDate).month;
            year = (<ICalendarDate>yearOrDate).year;
        }

        return new DateTime(new Date(year, month - 1, day));

    }

}

// Extend DateTime's usefulness.
export module DateTime {
    export const enum Kind {
        Unspecified,
        Local,
        Utc,
    }
}

Object.freeze(DateTime);

export default DateTime;
