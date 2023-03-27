/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 * Based upon: http://xxxxxx.com/en-us/library/system.systemexception%28v=vs.110%29.aspx
 */

import {Exception} from "../Exception";
import __extendsImport from "../../extends";
const __extends = __extendsImport;

const NAME: string = 'SystemException';

export class SystemException extends Exception
{
	/*
		constructor(
			message:string = null,
			innerException:Error = null,
			beforeSealing?:(ex:any)=>void)
		{
			super(message, innerException, beforeSealing);
		}
	*/

	protected getName(): string
	{
		return NAME;
	}
}

export default SystemException;