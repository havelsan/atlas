import { TTControl } from "./TTControl";
import { ITTComboBox } from "../ControlInterfaces/ITTComboBox";
import { ITTComboBoxItem } from "../ControlInterfaces/ITTComboBoxItem";

export class TTComboBox extends TTControl implements ITTComboBox {
    /*[Browsable(false)]*/
    public Items: Array<ITTComboBoxItem>;
    /*[Browsable(false)]*/
    public SelectedIndex: number;
    /*[Browsable(false)]*/
    public SelectedItem: ITTComboBoxItem;
    /*[Browsable(false)]*/
    public SelectedText: string;
    /*[Browsable(false)]*/
    public SelectedValue: Object;
    /*public event TTControlEventDelegate SelectedIndexChanged;*/
    public ShowClearButton?: boolean;
}