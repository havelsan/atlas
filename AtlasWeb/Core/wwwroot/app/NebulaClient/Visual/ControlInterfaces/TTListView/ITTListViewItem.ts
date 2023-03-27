import { ITTComponentBase } from "../ITTComponentBase";
import { ITTListViewSubItem } from "./ITTListViewSubItem";

/*[TTBrowsableInterface]*/
export interface ITTListViewItem extends ITTComponentBase {
    SubItems?: Array<ITTListViewSubItem>;
    Selected?: boolean;
    Checked?: boolean;
}