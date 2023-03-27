/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Based upon .NET source.
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */


import {Primitive} from "./Primitive";

export interface IComparable<T>
{
	compareTo(other:T):number;
}

export declare type Comparable = Primitive|IComparable<any>;

export default IComparable;