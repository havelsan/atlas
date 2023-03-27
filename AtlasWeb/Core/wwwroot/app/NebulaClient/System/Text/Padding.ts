import {Type} from "../Types";
import {repeat, EMPTY} from "./Utility";

const SPACE = ' ';
const ZERO = '0';

export function padStringLeft(source: string, minLength: number, pad: string = SPACE): string
{
	return pad && minLength > 0
		? (repeat(pad, minLength - source.length) + source)
		: source;
}

export function padStringRight(source: string, minLength: number, pad: string = SPACE): string
{
	return pad && minLength > 0
		? (source + repeat(pad, minLength - source.length))
		: source;
}

export function padNumberLeft(source: number, minLength: number, pad: string|number = ZERO): string
{
	if (!Type.isNumber(source))
		throw new Error("Cannot pad non-number.");

	if (!source) source = 0;

	return padStringLeft(source + EMPTY, minLength, pad + EMPTY);
}


export function padNumberRight(source: number, minLength: number, pad: string|number = ZERO): string
{
	if (!Type.isNumber(source))
		throw new Error("Cannot pad non-number.");

	if (!source) source = 0;

	return padStringRight(source + EMPTY, minLength, pad + EMPTY);
}

export function padLeft(source: string, minLength: number, pad?: string): string;
export function padLeft(source: number, minLength: number, pad?: string|number): string;
export function padLeft(source: string|number, minLength: number, pad?: any): string
{
	if (Type.isString(source)) return padStringLeft(source, minLength, pad);
	if (Type.isNumber(source)) return padNumberLeft(source, minLength, pad);
	throw new Error("Invalid source type.");
}

export function padRight(source: string, minLength: number, pad?: string): string;
export function padRight(source: number, minLength: number, pad?: string|number): string;
export function padRight(source: string|number, minLength: number, pad?: any): string
{
	if (Type.isString(source)) return padStringRight(source, minLength, pad);
	if (Type.isNumber(source)) return padNumberRight(source, minLength, pad);
	throw new Error("Invalid source type.");
}