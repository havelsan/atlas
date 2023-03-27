/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Based upon .NET source.
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 * Source: http://xxxxxx.com/#mscorlib/system/IFormattable.cs
 */


import {IFormatProvider} from "./IFormatProvider";
export interface IFormattable
{
	toString(format?:string, formatProvider?:IFormatProvider): string;
}

export default IFormattable;
