import { ITTComponent } from "../ITTComponent";
import { Font } from "../../Font";

/*[TTBrowsableInterface]*/
export interface ITTToolStripItem extends ITTComponent {
    AutoSize?: boolean;
    //DisplayStyle: ToolStripItemDisplayStyle;
    BackColor?: string;
    Font?: Font | string;
    ForeColor?: string;
    //Size: Size;
    Visible?: boolean;
}