import { ITTComponent } from "../ITTComponent";
import { HorizontalAlignment } from "../../../Utils/Enums/HorizontalAlignment";
/*[TTBrowsableInterface]*/
export interface ITTListViewColumn extends ITTComponent {
    TextAlign?: HorizontalAlignment;
    Width?: number;
    Format?: string;
    DataType?: string;
}