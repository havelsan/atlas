/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

export function shallowCopy(source: any, target: any = {}): any
{
	if (target)
	{
		for (let k in source)
		{
			//noinspection JSUnfilteredForInLoop
			target[k] = source[k];
		}
	}

	return target;
}

export default shallowCopy;