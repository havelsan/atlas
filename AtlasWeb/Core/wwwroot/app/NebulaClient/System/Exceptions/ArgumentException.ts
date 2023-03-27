/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 * Based upon: http://xxxxxx.com/en-us/library/System.Exception%28v=vs.110%29.aspx
 */


import {SystemException} from "./SystemException";
import {trim} from "../Text/Utility";
import __extendsImport from "../../extends";
const __extends = __extendsImport;

const NAME: string = 'ArgumentException';

export class ArgumentException extends SystemException
{

	paramName: string;

	// For simplicity and consistency, lets stick with 1 signature.
	constructor(
		paramName: string,
		message: string = null,
		innerException: Error = null,
		beforeSealing?: (ex: any) => void)
	{
		let pn = paramName ? ('{' + paramName + '} ') : '';
		super(trim(pn + (message || '')), innerException, (_) => {
			_.paramName = paramName;
			if (beforeSealing) beforeSealing(_);
		});
	}


	protected getName(): string
	{
		return NAME;
	}

}

export default ArgumentException;