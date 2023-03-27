/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Based upon .NET source.
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

export interface IComparer<T>
{
	compare(a: T, b: T): number;
}

export default IComparer;
