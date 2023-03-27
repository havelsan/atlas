/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

export interface IKeyValuePair<TKey, TValue>
{
	key: TKey;
	value: TValue;
}

export declare type KeyValuePair<TKey,TValue> = IKeyValuePair<TKey,TValue> | [TKey,TValue];

export interface IStringKeyValuePair<TValue> extends IKeyValuePair<string, TValue>
{ }

export declare type StringKeyValuePair<TValue> = IStringKeyValuePair<TValue> | [string,TValue];

export default IKeyValuePair;