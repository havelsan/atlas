import { ITTBindableGridColumn } from "./ITTBindableGridColumn";
import { ITTComboBoxItem } from "../../ITTComboBoxItem";

/*[TTBrowsableInterface]*/
export interface ITTComboBoxColumn extends ITTBindableGridColumn {
    /*[Browsable(false)]*/
    Items?: Array<ITTComboBoxItem>;
    ItemsSource?: string;
    ComponentReference?: any;
    Enabled?: any;
    TabIndex?: any;
    IncludeOnly?: any;
}