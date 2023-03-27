﻿/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */


import {IReadOnlyCollection} from "./IReadOnlyCollection";
import {IEnumerableOrArray} from "./IEnumerableOrArray";

export interface ICollection<T> extends IReadOnlyCollection<T>
{
	add(entry:T):void;
	remove(entry:T, max?:number):number;  // Number of times removed.
	clear():number;

	importEntries(entries:IEnumerableOrArray<T>):number;
	toArray():T[];
}

export default ICollection;