/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import {ObjectDisposedException} from "./ObjectDisposedException";
import {IDisposableAware} from "./IDisposableAware";

export abstract class DisposableBase implements IDisposableAware
{

	constructor(private __finalizer?: () => void)
	{
	}

	private __wasDisposed: boolean = false;

	get wasDisposed(): boolean
	{
		return this.__wasDisposed;
	}

	// Allow for simple override of name.
	protected _disposableObjectName: string;

	protected throwIfDisposed(
		message?: string,
		objectName: string = this._disposableObjectName): boolean
	{
		if (this.__wasDisposed)
			throw new ObjectDisposedException(objectName, message);
		return true;
	}


	dispose(): void
	{
		const _ = this;
		if (!_.__wasDisposed)
		{
			// Preemptively set wasDisposed in order to prevent repeated disposing.
			// NOTE: in true multi-threaded scenarios, this needs to be synchronized.
			_.__wasDisposed = true;
			try
			{
				_._onDispose(); // Protected override.
			}
			finally
			{
				if (_.__finalizer) // Private finalizer...
				{
					_.__finalizer();
					_.__finalizer = void 0;
				}
			}
		}
	}

	// Placeholder for overrides.
	protected _onDispose(): void { }

}

export default DisposableBase;