/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import {IDisposable} from "./IDisposable";

export interface IDisposableAware extends IDisposable
{
	wasDisposed: boolean;
}

export default IDisposableAware;