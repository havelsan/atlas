import { ITTGridCell } from "./ITTGridCell";
import { ITTComboBoxItem } from "../ITTComboBoxItem";

export interface ITTGridComboBoxCell extends ITTGridCell {
    /*[Browsable(false)]*/
    Items?: Array<ITTComboBoxItem>;
}