import { ITTToolStripItem } from "./ITTToolStripItem";
/*[TTBrowsableInterface]*/
export interface ITTToolStripDropDownItem extends ITTToolStripItem {
    DropDownItems?: Array<ITTToolStripItem>;
}