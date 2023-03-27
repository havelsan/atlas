import { ITTComboBox } from "./ITTComboBox";
import { ITTListDefComboBoxBase } from "./ITTListDefComboBoxBase";

/*[TTBrowsableInterface]*/
export interface ITTListDefComboBox extends ITTComboBox, ITTListDefComboBoxBase {
    Width?: any;
    AutoCompleteDialogWidth?: any;
    MinSearchLength?: any;
    SearchTimeout?: any;
    AutoCompleteMode?: any;
    AutoCompleteDialogHeight?: any;
    PopupDialogFieldConfig?: any;
    PopupDialogGridColumns?: any;
    PopupDialogWidth?: any;
    PopupDialogHeight?: any;
    PopupDialogTitle?: any;

    SelectedObject?: any;
}