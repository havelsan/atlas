/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */


import {IndexEnumerator} from "./IndexEnumerator";
import {Type} from "../../Types";
import {IArray} from "../Array/IArray";
import __extendsImport from "../../../extends";
const __extends = __extendsImport;

export class ArrayEnumerator<T> extends IndexEnumerator<T>
{
	constructor(arrayFactory: () => IArray<T>, start?: number, step?: number);
	constructor(array: IArray<T>, start?: number, step?: number);
	constructor(arrayOrFactory: any, start: number = 0, step: number = 1)
	{
		super(
			() =>
			{
				let array = Type.isFunction(arrayOrFactory) ? arrayOrFactory() : arrayOrFactory;
				return {
					source: array,
					pointer: start,
					length: array ? array.length : 0,
					step: step
				};
			}
		);
	}
}

export default ArrayEnumerator;