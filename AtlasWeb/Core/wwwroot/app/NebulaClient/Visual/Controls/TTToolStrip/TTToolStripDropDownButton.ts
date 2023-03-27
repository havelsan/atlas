import { TTControl } from "../TTControl";
import { ITTToolStripDropDownButton } from "../../ControlInterfaces/TTToolStrip/ITTToolStripDropDownButton";
import { ITTToolStripItem } from "../../ControlInterfaces/TTToolStrip/ITTToolStripItem";
import { TTToolStripItem } from "./TTToolStripItem";
import { ToolStripItemDisplayStyle } from "../../../Utils/Enums/ToolStripItemDisplayStyle";

export class TTToolStripDropDownButton extends TTControl implements ITTToolStripDropDownButton {
    private _itemCollection: Array<TTToolStripItem> = new Array<TTToolStripItem>();
    public AutoSize: boolean;
    public DisplayStyle: ToolStripItemDisplayStyle;
    public get DropDownItems(): Array<ITTToolStripItem> {
        return this._itemCollection;
    }
}