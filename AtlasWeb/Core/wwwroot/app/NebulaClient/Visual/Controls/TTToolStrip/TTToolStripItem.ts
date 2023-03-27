import { TTControl } from "../TTControl";
import { ITTToolStripItem } from "../../ControlInterfaces/TTToolStrip/ITTToolStripItem";
import { ToolStripItemDisplayStyle } from "../../../Utils/Enums/ToolStripItemDisplayStyle";
import { Font } from "../../Font";

export class TTToolStripItem extends TTControl implements ITTToolStripItem {
    public AutoSize: boolean;
    public DisplayStyle: ToolStripItemDisplayStyle;
    public BackColor: string;
    public Font: Font;
    public ForeColor: string;
    public Size: Object;
    public Visible: boolean;
}