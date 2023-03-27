import { TTControl } from "../TTControl";
import { ITTToolStripItem } from "../../ControlInterfaces/TTToolStrip/ITTToolStripItem";
import { TTToolStripItem } from "./TTToolStripItem";
import { ITTToolStripMenuItem } from "../../ControlInterfaces/TTToolStrip/ITTToolStripMenuItem";
import { ToolStripItemDisplayStyle } from "../../../Utils/Enums/ToolStripItemDisplayStyle";

export class TTToolStripMenuItem extends TTControl implements ITTToolStripMenuItem {
    private _itemCollection: Array<TTToolStripItem> = new Array<TTToolStripItem>();
    public AutoSize: boolean;
    public DisplayStyle: ToolStripItemDisplayStyle;
    public get DropDownItems(): Array<ITTToolStripItem> {
        return this._itemCollection;
    }
}