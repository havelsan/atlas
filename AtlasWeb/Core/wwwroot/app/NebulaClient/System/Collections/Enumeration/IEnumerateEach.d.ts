/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import {Action, Predicate} from "../../FunctionTypes";

export interface IEnumerateEach<T>
{
	// Enforcing an interface that allows operating on a copy can prevent changing underlying data while enumerating.
	forEach(action: Predicate<T> | Action<T>, useCopy?: boolean): number;
}

export default IEnumerateEach;

