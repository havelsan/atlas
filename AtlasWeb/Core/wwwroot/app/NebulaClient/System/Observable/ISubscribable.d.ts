/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Based upon .NET source.
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import {IDisposable} from "../Disposable/IDisposable";

export interface ISubscribable<TSubscriber> extends IDisposable
{
	subscribe(observer: TSubscriber): IDisposable;
	unsubscribe(observer: TSubscriber): void;
}

export default ISubscribable;