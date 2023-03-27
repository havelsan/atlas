/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * From Netjs mscorlib.ts
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

export function isWhiteSpace(ch: number): boolean
{
	return ch === 32 || (ch >= 9 && ch <= 13) || ch === 133 || ch === 160;
}
export function isLetter(ch: number): boolean
{
	return (65 <= ch && ch <= 90) || (97 <= ch && ch <= 122) || (ch >= 128 && ch !== 133 && ch !== 160);
}
export function isLetterOrDigit(ch: number): boolean
{
	return (48 <= ch && ch <= 57) || (65 <= ch && ch <= 90) || (97 <= ch && ch <= 122) || (ch >= 128 && ch !== 133 && ch !== 160);
}
export function isDigit(ch: number): boolean;
export function isDigit(str: string, index: number): boolean;
export function isDigit(chOrStr: any, index?: number): boolean
{
	if (arguments.length == 1)
	{
		return 48 <= chOrStr && chOrStr <= 57;
	}
	else
	{
		let ch = chOrStr.charCodeAt(index);
		return 48 <= ch && ch <= 57;
	}
}
