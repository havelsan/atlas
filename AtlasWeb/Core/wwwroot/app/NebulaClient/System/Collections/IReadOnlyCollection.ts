/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */


import {IEnumerable} from "./Enumeration/IEnumerable";
import {IArray} from "./Array/IArray";

export interface IReadOnlyCollection<T>
extends IEnumerable<T>
{
	count: number;
	isReadOnly: boolean;

	contains(entry: T): boolean;
	copyTo<TTarget extends IArray<any>>(target: TTarget, index?: number): TTarget;
	toArray(): T[];
}

export default IReadOnlyCollection;