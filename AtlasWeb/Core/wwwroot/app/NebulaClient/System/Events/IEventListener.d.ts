/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import {Func} from "../FunctionTypes";

export type IEventListener = EventListenerOrEventListenerObject | Func<void>;

export default IEventListener;