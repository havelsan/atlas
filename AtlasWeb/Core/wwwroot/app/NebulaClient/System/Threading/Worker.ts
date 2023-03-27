/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT
 */

import {isNodeJS} from "../Environment";
import {WorkerConstructor} from "./WorkerType";

declare const require: any;
declare const self: any;

export const Worker: WorkerConstructor = isNodeJS ? require('./NodeJSWorker').default : self.Worker;
export default Worker;