import { TTControl } from "./TTControl";
import { TTComboBoxItem } from "./TTComboBoxItem";
import { ITTStateComboBox } from "../ControlInterfaces/ITTStateComboBox";
import { ITTComboBoxItem } from "../ControlInterfaces/ITTComboBoxItem";

export class TTStateComboBox extends TTControl implements ITTStateComboBox {
    private _itemCollection: Array<TTComboBoxItem> = new Array<TTComboBoxItem>();
    public get Items(): Array<ITTComboBoxItem> {
        return this._itemCollection;
    }
    public SelectedIndex: number;
    public SelectedItem: ITTComboBoxItem;
    public SelectedText: string;
    public SelectedValue: Object;
    /*public event TTControlEventDelegate SelectedIndexChanged;*/ }