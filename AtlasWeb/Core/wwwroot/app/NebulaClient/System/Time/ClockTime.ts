/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Originally based upon .NET source but with many additions and improvements.
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import { TimeQuantity } from './TimeQuantity';
import { IClockTime } from './ITimeStamp';
import { Minutes, Seconds, Milliseconds, Ticks } from './HowMany';
import __extendsImport from '../../extends';
const __extends = __extendsImport;


export class ClockTime extends TimeQuantity implements IClockTime {

    days: number;
    hour: number;
    minute: number;
    second: number;
    millisecond: number;
    tick: number;

    constructor(milliseconds: number);
    constructor(hours: number, minutes: number, seconds?: number, milliseconds?: number);
    constructor(...args: number[]) {
        super(
            args.length > 1
                ? ClockTime.millisecondsFromTime(
                    args[0] || 0,
                    args[1] || 0,
                    args.length > 2 && args[2] || 0,
                    args.length > 3 && args[3] || 0
                )
                : (args.length > 0 && args[0] || 0)
        );

        const _ = this;
        let ms = Math.abs(_.getTotalMilliseconds());
        let msi = Math.floor(ms);

        _.tick = (ms - msi) * Ticks.Per.Millisecond;

        // tslint:disable-next-line:no-bitwise
        _.days = (msi / Milliseconds.Per.Day) | 0;
        msi -= _.days * Milliseconds.Per.Day;

        // tslint:disable-next-line:no-bitwise
        _.hour = (msi / Milliseconds.Per.Hour) | 0;
        msi -= _.hour * Milliseconds.Per.Hour;

        // tslint:disable-next-line:no-bitwise
        _.minute = (msi / Milliseconds.Per.Minute) | 0;
        msi -= _.minute * Milliseconds.Per.Minute;

        // tslint:disable-next-line:no-bitwise
        _.second = (msi / Milliseconds.Per.Second) | 0;
        msi -= _.second * Milliseconds.Per.Second;

        _.millisecond = msi;

        Object.freeze(_);
    }


    // Static version for relative consistency.  Constructor does allow this format.
    static from(hours: number, minutes: number, seconds: number = 0, milliseconds: number = 0): ClockTime {
        return new ClockTime(hours, minutes, seconds, milliseconds);
    }

    static millisecondsFromTime(
        hours: number,
        minutes: number,
        seconds: number = 0,
        milliseconds: number = 0): number {
        let value = hours;
        value *= Minutes.Per.Hour;
        value += minutes;
        value *= Seconds.Per.Minute;
        value += seconds;
        value *= Milliseconds.Per.Second;
        value += milliseconds;
        return value;
    }

    toString(/*format?:string, formatProvider?:IFormatProvider*/): string {
        /* INSERT CUSTOM FORMATTING CODE HERE */


        let _ = this, a: string[] = [];

        if (_.days) {
            a.push(pluralize(_.days, 'day'));
        }

        if (_.hour) {
            a.push(pluralize(_.hour, 'hour'));
        }

        if (_.minute) {
            a.push(pluralize(_.minute, 'minute'));
        }

        if (_.second) {
            a.push(pluralize(_.second, 'second'));
        }

        if (a.length > 1) {
            a.splice(a.length - 1, 0, 'and');
        }

        return a.join(', ').replace(', and, ', ' and ');
    }

}


// Temporary until the full TimeSpanFormat is available.
function pluralize(value: number, label: string): string {
    if (Math.abs(value) !== 1) {
        label += 's';
    }

    return label;
}

export default ClockTime;