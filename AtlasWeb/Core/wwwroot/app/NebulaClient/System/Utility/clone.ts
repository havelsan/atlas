/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import {Type} from "../Types";

export default function clone(source: any, depth: number = 0): any
{
	if (depth < 0)
		return source;

	// return primitives as is.
	if (!Type.isObject(source)) return source;

	let result: any;
	if (Array.isArray(source))
	{
		result = (<any>source).slice();
		if (depth > 0)
		{
			for (let i = 0; i < result.length; i++)
			{
				result[i] = clone(result[i], depth - 1);
			}
		}
	}
	else
	{
		result = {};
		if (depth > 0) for (let k in source)
		{
			//noinspection JSUnfilteredForInLoop
			result[k] = clone(source[k], depth - 1);
		}
	}

	return result;

}
