import { ITTLinkedControl } from "./ITTLinkedControl";

/*[TTBrowsableInterface]*/
export interface ITTListBoxBase extends ITTLinkedControl {
    /*[TTListDefName]*/
    ListDefName?: string;
    ListFilterExpression?: string;
}