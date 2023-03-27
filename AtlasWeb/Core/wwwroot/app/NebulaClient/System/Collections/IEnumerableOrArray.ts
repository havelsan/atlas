/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import {IArray} from "./Array/IArray";
import {IEnumerable} from "./Enumeration/IEnumerable";

// Place IArray<T> in front for efficiency.

export declare type IEnumerableOrArray<T> =  IArray<T> | IEnumerable<T>;

export default IEnumerableOrArray;