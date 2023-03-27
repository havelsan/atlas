/*!
 * @author electricessence / http://xxxxxx.com/electricessence/
 * Based Upon: http://xxxxxx.com/en-us/library/he2s3bh7%28v=vs.110%29.aspx
 * Licensing: MIT http://xxxxxx.com/electricessence/TypeScript.NET/blob/master/LICENSE.md
 */

import {ILinkedList} from "./ILinkedList";

export interface ILinkedNode<TNode extends ILinkedNode<TNode>>
{
	previous?:TNode;
	next?:TNode;
}

export interface INodeWithValue<TValue>
{
	value:TValue;
}

export interface ILinkedNodeWithValue<T>
extends ILinkedNode<ILinkedListNode<T>>, INodeWithValue<T> {

}

// Use an interface in order to prevent external construction of LinkedListNode
export interface ILinkedListNode<T>
extends ILinkedNodeWithValue<T>
{
	previous:ILinkedListNode<T>;
	next:ILinkedListNode<T>;

	list: ILinkedList<T>;

	addBefore(entry:T): void;
	addAfter(entry:T): void;

	remove(): void;
}

export default ILinkedListNode;
