/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 * Based on: http://xxxxxx.com/en-us/library/system.uri.scheme%28v=vs.110%29.aspx
 */

export declare type File = 'file';
export declare type Gopher = 'gopher';
export declare type FTP = 'ftp';
export declare type HTTP = 'http';
export declare type HTTPS = 'https';
export declare type LDAP = 'ldap';
export declare type MailTo = 'mailto';
export declare type Pipe = 'net.pipe';
export declare type TCP = 'net.tcp';
export declare type NNTP = 'nntp' | 'news';
export declare type Telnet = 'telnet';
export declare type UUID = 'uuid';

/**
 * The allowed HTTP Method values.
 */
export declare type SchemeValue
	= File
	| Gopher
	| FTP
	| HTTP
	| HTTPS
	| LDAP
	| MailTo
	| Pipe
	| TCP
	| NNTP
	| Telnet
	| UUID;

export default SchemeValue;