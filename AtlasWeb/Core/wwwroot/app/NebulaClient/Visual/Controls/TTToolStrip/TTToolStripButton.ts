import { TTControl } from "../TTControl";
import { ITTToolStripButton } from "../../ControlInterfaces/TTToolStrip/ITTToolStripButton";
import { ToolStripItemDisplayStyle } from "../../../Utils/Enums/ToolStripItemDisplayStyle";

export class TTToolStripButton extends TTControl implements ITTToolStripButton {
    public AutoSize: boolean;
    public DisplayStyle: ToolStripItemDisplayStyle;
}