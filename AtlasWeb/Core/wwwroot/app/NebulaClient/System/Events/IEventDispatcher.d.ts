/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */


import {IDisposable} from "../Disposable/IDisposable";
import {IEventListener} from "./IEventListener";

interface IEventDispatcher extends IDisposable {
	addEventListener(type: string, listener: IEventListener): void;
	dispatchEvent(event: Event): boolean;
	hasEventListener(type: string): boolean;
	removeEventListener(type: string, listener: IEventListener): void;
}
