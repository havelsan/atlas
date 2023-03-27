/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Based on Netjs mscorlib.ts
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */


import {IDisposable} from "../Disposable/IDisposable";
import __extendsImport from "../../extends";
const __extends = __extendsImport;

/**
 * A simple event dispatcher provided as an alternative to built-in event.
 * If just dispatching a payload to a uniform set of functions, it may be better to just use the utilities in System/Collections/Array/Dispatch.
 */
export default class EventSimple<T extends Function> implements IDisposable
{
	private _listeners: T[] = [];

	add(listener: T): void
	{
		this._listeners.push(listener);
	}

	remove(listener: T): void
	{
		let index = this._listeners.indexOf(listener);
		if (index < 0) return;
		this._listeners.splice(index, 1);
	}

	dispatch(...params: any[]): void
	{
		let listeners = this._listeners;
		for (let f of listeners)
		{
			f.call(params);
		}
	}

	toMulticastFunction(): Function
	{
		let listeners = this._listeners;
		return function()
		{
			for (let f of listeners)
			{
				f.call(arguments);
			}
		};
	}

	dispose(): void
	{
		this._listeners.length = 0;
	}
}