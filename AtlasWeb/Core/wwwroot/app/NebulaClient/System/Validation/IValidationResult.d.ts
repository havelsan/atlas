/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

export interface IValidationResult {
	isValid: boolean;
	message: string;
	data: any;
}

export default IValidationResult;