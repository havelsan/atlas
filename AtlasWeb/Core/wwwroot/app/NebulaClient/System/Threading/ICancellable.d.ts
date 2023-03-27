/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import {IDisposable} from "../Disposable/IDisposable";

export interface ICancellable extends IDisposable {

	/**
	 * Returns true if cancelled.
	 * Returns false if already run or already cancelled or unable to cancel.
 	 */
	cancel(): boolean;
}

export default ICancellable;