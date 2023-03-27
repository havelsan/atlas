import { ITTBindableControl } from "./ITTBindableControl";
import { ITTComboBoxItem } from "./ITTComboBoxItem";

/*[TTBrowsableInterface]*/
export interface ITTComboBox extends ITTBindableControl {
    /*[TTSelectedIndexChanged]
event TTControlEventDelegate SelectedIndexChanged;*/
    Items?: Array<ITTComboBoxItem>;
    SelectedIndex?: number;
    SelectedItem?: ITTComboBoxItem;
    SelectedText?: string;
    SelectedValue?: any;
    SearchMode?: string;
    ShowClearButton?: boolean;
}