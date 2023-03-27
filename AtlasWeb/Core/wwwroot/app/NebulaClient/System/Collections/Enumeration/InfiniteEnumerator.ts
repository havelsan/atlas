/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */


import {SimpleEnumerableBase} from "./SimpleEnumerableBase";
import __extendsImport from "../../../extends";
const __extends = __extendsImport;

const VOID0: any = void 0;

/**
 * An aggregate/reduce style factory function that expects a previous value and the current index of the enumeration.
 */
export interface InfiniteValueFactory<T>
{
	(previous?: T, index?: number): T;
}

/**
 * A simplified stripped down enumerator that until disposed will infinitely return the provided factory.
 * This is analogous to a 'generator' and has a compatible interface.
 */
export class InfiniteEnumerator<T> extends SimpleEnumerableBase<T>
{
	/**
	 * See InfiniteValueFactory
	 * @param _factory
	 */
	constructor(private _factory: InfiniteValueFactory<T>)
	{
		super();
	}

	protected canMoveNext(): boolean
	{
		return this._factory != null;
	}

	moveNext(): boolean
	{
		const _ = this;
		let f = _._factory;
		if (f) _._current = f(_._current, _.incrementIndex());
		return f != VOID0;
	}

	dispose(): void
	{
		super.dispose();
		this._factory = VOID0;
	}

}

export default InfiniteEnumerator;