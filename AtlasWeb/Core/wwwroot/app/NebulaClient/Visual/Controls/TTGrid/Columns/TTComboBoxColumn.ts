import { TTGridColumn } from "./TTGridColumn";
import { ITTComboBoxColumn } from "../../../ControlInterfaces/TTGrid/Columns/ITTComboBoxColumn";
import { ITTComboBoxItem } from "../../../ControlInterfaces/ITTComboBoxItem";

export class TTComboBoxColumn extends TTGridColumn implements ITTComboBoxColumn {
    /*[Browsable(false)]*/
    public Items?: Array<ITTComboBoxItem>;
    public ItemsSource?: string;
    public ComponentReference?: any;
}