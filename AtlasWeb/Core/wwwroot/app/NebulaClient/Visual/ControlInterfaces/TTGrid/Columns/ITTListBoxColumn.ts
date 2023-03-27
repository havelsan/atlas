import { ITTListBox } from "../../ITTListBox";
import { ITTBindableGridColumn } from "./ITTBindableGridColumn";

/*[TTBrowsableInterface]*/
export interface ITTListBoxColumn extends ITTListBox, ITTBindableGridColumn {
    AllowMultiSelect?: boolean;
    Enabled?: boolean;
}