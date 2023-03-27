/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import {TaskHandlerBase} from "./TaskHandlerBase";
import {ArgumentNullException} from "../../Exceptions/ArgumentNullException";
import {Closure} from "../../FunctionTypes";
import __extendsImport from "../../../extends";
const __extends = __extendsImport;

export class TaskHandler extends TaskHandlerBase
{

	constructor(private _action: Closure)
	{
		super();
		if (!_action) throw new ArgumentNullException('action');
	}

	protected _onExecute(): void
	{
		this._action();
	}

	protected _onDispose(): void
	{
		super._onDispose();
		this._action = null;
	}
}

export default TaskHandler;