/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import {ArgumentNullException} from "../Exceptions/ArgumentNullException";
import {ReadOnlyCollectionBase} from "./ReadOnlyCollectionBase";
import {ICollection} from "./ICollection";
import __extendsImport from "../../extends";
const __extends = __extendsImport;

export default class ReadOnlyCollectionWrapper<T> extends ReadOnlyCollectionBase<T>
{
	constructor(c: ICollection<T>)
	{
		super();

		if (!c)
			throw new ArgumentNullException('collection');

		const _ = this;
		_._getCount = () => c.count;
		_.getEnumerator = () => c.getEnumerator();
	}
}
