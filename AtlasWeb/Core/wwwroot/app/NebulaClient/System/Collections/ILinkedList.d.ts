/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Based Upon: http://xxxxxx.com/en-us/library/he2s3bh7%28v=vs.110%29.aspx
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import {ICollection} from "./ICollection";
import {ILinkedListNode, ILinkedNode} from "./ILinkedListNode";
import {IEnumerateEach} from "./Enumeration/IEnumerateEach";

export interface ILinkedNodeList<TNode extends ILinkedNode<TNode>>
{
	first:TNode;
	last:TNode;

	getNodeAt(index:number):TNode;
	removeNode(node:TNode):boolean;
}

export interface ILinkedList<T>
extends ILinkedNodeList<ILinkedListNode<T>>,
	ICollection<T>,
	IEnumerateEach<T>
{
	first:ILinkedListNode<T>;
	last:ILinkedListNode<T>;

	getValueAt(index:number):T;
	find(entry:T):ILinkedListNode<T>;
	findLast(entry:T):ILinkedListNode<T>;
	addFirst(entry:T):void;
	addLast(entry:T):void;
	removeFirst():void;
	removeLast():void;
	addAfter(node:ILinkedListNode<T>, entry:T):void;

}

export default ILinkedList;