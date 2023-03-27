/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 * Based upon: http://xxxxxx.com/en-us/library/System.Exception%28v=vs.110%29.aspx
 */

import {SystemException} from "../../Exceptions/SystemException";
import __extendsImport from "../../../extends";
const __extends = __extendsImport;

const NAME: string = 'UnsupportedEnumerableException';

export class UnsupportedEnumerableException extends SystemException
{

	constructor(message?: string)
	{
		super(message || "Unsupported enumerable.");
	}

	protected getName(): string
	{
		return NAME;
	}
}

export default UnsupportedEnumerableException;