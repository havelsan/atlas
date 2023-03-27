/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import {Primitive} from "../Primitive";
import {ISerializable} from "../Serialization/ISerializable";
import {IMap} from "../Collections/Dictionaries/IDictionary";

export interface Formattable
{
	toUriComponent(): string;
}

export declare type Value
	= Primitive|ISerializable|Formattable;

export interface Map extends IMap<Value|Value[]>
{

}

