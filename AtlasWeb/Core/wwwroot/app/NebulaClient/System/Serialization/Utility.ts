/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import {Type} from "../Types";
import {InvalidOperationException} from "../Exceptions/InvalidOperationException";
import {ISerializable} from "./ISerializable";
import {Primitive} from "../Primitive";


const EMPTY = '', TRUE = 'true', FALSE = 'false';

export function toString(
	value: Primitive|ISerializable,
	defaultForUnknown?: string): string
{

	let v = <any>value;
	switch (typeof v)
	{
		case Type.UNDEFINED:
		case Type.STRING:
			return v;
		case Type.BOOLEAN:
			return v ? TRUE : FALSE;
		case Type.NUMBER:
			return EMPTY + v;
		default:

			if (v === null)
				return v;

			if (isSerializable(v))
				return v.serialize();
			else if (arguments.length > 1)
				return defaultForUnknown;

			let ex = new InvalidOperationException('Attempting to serialize unidentifiable type.');
			ex.data['value'] = v;
			throw ex;

	}

}

export function isSerializable(instance: any): instance is ISerializable {
	return Type.hasMemberOfType<ISerializable>(instance, 'serialize', Type.FUNCTION);
}

export function toPrimitive(
	value: string,
	caseInsensitive?: boolean,
	unknownHandler?: (v: string) => string): Primitive
{


	if (value)
	{
		if (caseInsensitive) value = value.toLowerCase();

		switch (value)
		{
			case 'null':
				return null;
			case Type.UNDEFINED:
				return undefined;
			case TRUE:
				return true;
			case FALSE:
				return false;
			default:

				let cleaned = value.replace(/^\s+|,|\s+$/g, EMPTY);
				if (cleaned) {

					if (/^\d+$/g.test(cleaned)) {
						let int = parseInt(cleaned);
						if (!isNaN(int)) return int;
					} else {
						let number = parseFloat(value);
						if (!isNaN(number)) return number;
					}

				}

				// TODO: Handle Dates...  Possibly JSON?

				// Instead of throwing we allow for handling...
				if (unknownHandler) value = unknownHandler(value);

				break;
		}

	}

	return value;

}
