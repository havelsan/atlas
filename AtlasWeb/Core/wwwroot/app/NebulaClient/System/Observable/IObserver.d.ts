/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Based upon .NET source.
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 * Source: http://xxxxxx.com/#mscorlib/system/IObserver.cs
 */

export interface IObserver<T>
{
	// onNext is optional because an observer may only care about onCompleted.
	onNext?: (value: T) => void;
	onError?: (error: any) => void;
	onCompleted?: () => void;
}

export default IObserver;