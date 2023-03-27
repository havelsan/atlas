/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import {ITimeMeasurement} from "./ITimeMeasurement";

export interface ITimeQuantity {
	getTotalMilliseconds(): number;
	total: ITimeMeasurement;
}

export default ITimeQuantity;
