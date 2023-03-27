/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */


export interface IYield<T> {
	current: T;
	yieldReturn(value: T): boolean;
	yieldBreak(): boolean;
}

export default IYield;
