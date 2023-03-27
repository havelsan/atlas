import { TTControl } from "../TTControl";
import { ITTToolStripDropDownItem } from "../../ControlInterfaces/TTToolStrip/ITTToolStripDropDownItem";
import { ITTToolStripItem } from "../../ControlInterfaces/TTToolStrip/ITTToolStripItem";
import { ToolStripItemDisplayStyle } from "../../../Utils/Enums/ToolStripItemDisplayStyle";

export class TTToolStripDropDownItem extends TTControl implements ITTToolStripDropDownItem {
    public AutoSize: boolean;
    public DisplayStyle: ToolStripItemDisplayStyle;
    public DropDownItems: Array<ITTToolStripItem>;
}