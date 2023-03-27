/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */
/* tslint:disable */
import { Type } from "../Types";
import { ITimeStamp } from "./ITimeStamp";
import { Ticks } from "./HowMany";
import { IDateTime } from "./IDateTime";
import { Gregorian } from "./Calendars";

/**
 * An alternative to Date or DateTime.  Is a model representing the exact date and time.
 */
export class TimeStamp implements ITimeStamp, IDateTime {

    constructor(
        public year: number,
        public month: Gregorian.Month,
        public day: number = 1,
        public hour: number = 0,
        public minute: number = 0,
        public second: number = 0,
        public millisecond: number = 0,
        public tick: number = 0) {

        // TODO: Add validation or properly carry out of range values...

        Object.freeze(this);
    }

    toJsDate(): Date {
        const _ = this;
        return new Date(_.year, _.month, _.day, _.hour, _.minute, _.second, _.millisecond + _.tick / Ticks.Per.Millisecond);
    }

    static from(d: Date | IDateTime): TimeStamp {
        if (!(Object.prototype.toString.call(d) === '[object Date]') && Type.hasMember(d, 'toJsDate'))
            d = (<IDateTime>d).toJsDate();
        if (Object.prototype.toString.call(d) === '[object Date]') {
            let dateValue: Date = d as Date;
            return new TimeStamp(
                dateValue.getFullYear(),
                dateValue.getMonth(),
                dateValue.getDate(),
                dateValue.getHours(),
                dateValue.getMinutes(),
                dateValue.getSeconds(),
                dateValue.getMilliseconds()
            );
        }
        else {
            throw Error('Invalid date type.');
        }
    }
}

export default TimeStamp;