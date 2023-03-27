/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 * Based upon Parallel.js: http://xxxxxx.com/adambom/parallel.js/blob/master/lib/Worker.js
 */

import {WorkerLike} from "./WorkerType";
import {ObservableBase} from "../Observable/ObservableBase";
import __extendsImport from "../../extends";
const __extends = __extendsImport;

declare const require: any;
const ps = require("child_process");

/**
 * This class takes the place of a WebWorker
 */
export class NodeJSWorker extends ObservableBase<any> implements WorkerLike
{
	private _process: any;
	onmessage: (message: {data: any}) => void;
	onerror: (error: any) => void;

	constructor(url: string)
	{
		super();
		let process = this._process = ps.fork(url);
		process.on('message', (msg: string) => this._onNext(JSON.parse(msg)));
		process.on('error', (err: any) => this._onError(err));
	}

	protected _onNext(data: any): void
	{
		super._onNext(data);
		if (this.onmessage)
			this.onmessage({data: data});

	}

	protected _onError(error: any): void
	{
		super._onError(error);
		if (this.onerror)
			this.onerror(error);
	}

	protected _onDispose()
	{
		super._onDispose();
		this._process.removeAllListeners(); // just to satisfy paranoia.
		this._process.kill();
		this._process = null;
	}

	postMessage(obj: any): void
	{
		this.throwIfDisposed();
		this._process.send(JSON.stringify({data: obj}));
	}

	terminate()
	{
		this.dispose();
	}

}

export default NodeJSWorker;
