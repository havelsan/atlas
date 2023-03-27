/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

/**
 * This interface guarantees there will be a value property for all time units.
 */
export interface ITimeMeasurement
{
	ticks: number;
	milliseconds: number;
	seconds: number;
	minutes: number;
	hours: number;
	days: number;
}

export default ITimeMeasurement;
