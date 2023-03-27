import { ITTControlBase } from "../ITTControlBase";
import { ITTToolStripItem } from "./ITTToolStripItem";
/*[TTBrowsableInterface]*/
export interface ITTToolStrip extends ITTControlBase {
    /*[TTToolStripItemClicked]
event TTToolStripItemClicked ItemClicked;*/
    Items?: Array<ITTToolStripItem>;
}