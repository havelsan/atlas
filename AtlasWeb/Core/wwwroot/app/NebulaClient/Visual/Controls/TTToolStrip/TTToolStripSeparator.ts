import { TTControl } from "../TTControl";
import { ITTToolStripSeparator } from "../../ControlInterfaces/TTToolStrip/ITTToolStripSeparator";
import { ToolStripItemDisplayStyle } from "../../../Utils/Enums/ToolStripItemDisplayStyle";

export class TTToolStripSeparator extends TTControl implements ITTToolStripSeparator {
    public AutoSize: boolean;
    public DisplayStyle: ToolStripItemDisplayStyle;
}