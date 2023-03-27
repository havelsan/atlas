/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Based upon .NET source.
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 * Source: http://xxxxxx.com/#mscorlib/system/IEquatable.cs
 */

export interface IEquatable<T>
{
	equals(other:T): boolean;
}

export default IEquatable;
