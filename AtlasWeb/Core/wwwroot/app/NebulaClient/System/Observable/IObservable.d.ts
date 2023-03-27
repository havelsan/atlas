/*!
* @author electricessence / http://xxxxxx.com/electricessence/
* Based upon .NET source.
* Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
* Source:
*   http://xxxxxx.com/#mscorlib/system/IObservable.cs
*   http://xxxxxx.com/en-us/library/dd990377.aspx
*/


import {ISubscribable} from "./ISubscribable";
import {IObserver} from "./IObserver";

export interface IObservable<T> extends ISubscribable<IObserver<T>>
{
}

export default IObservable;
