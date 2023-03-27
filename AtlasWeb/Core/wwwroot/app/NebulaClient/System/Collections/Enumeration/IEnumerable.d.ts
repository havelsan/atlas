/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import {IEnumerator} from "./IEnumerator";

export interface IEnumerable<T>
{
	getEnumerator(): IEnumerator<T>;

	/**
	 * Provides a way of flagging endless enumerations that may cause issues.
	 */
	isEndless?:boolean;
}

export default IEnumerable;