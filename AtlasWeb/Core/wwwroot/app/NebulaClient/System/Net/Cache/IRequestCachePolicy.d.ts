/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 * Based on: http://xxxxxx.com/en-us/library/system.net.cache.requestcachepolicy%28v=vs.110%29.aspx
 */


import {RequestCacheLevel} from "./RequestCacheLevel";

export interface IRequestCachePolicy
{
	/**
	 * Gets the RequestCacheLevel value specified when this instance was constructed.
	 */
	level: RequestCacheLevel;
}

export default IRequestCachePolicy;