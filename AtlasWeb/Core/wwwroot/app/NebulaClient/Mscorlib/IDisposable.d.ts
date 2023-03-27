/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET-Core/blob/master/LICENSE.md
 */

// Allows for simple type checking that includes types that don't declare themselves as IDisposable but do have a dispose() method.
export default interface IDisposable
{
	dispose():void;
}