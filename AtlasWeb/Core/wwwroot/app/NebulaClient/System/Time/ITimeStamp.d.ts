/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

export interface ICalendarDate {
	year: number;
	month: number;
	day: number;
}

export interface IClockTime {
	hour: number;
	minute: number;
	second: number;
	millisecond: number;
	tick: number;
}

export interface ITimeStamp extends ICalendarDate, IClockTime {

}

export default ITimeStamp;
