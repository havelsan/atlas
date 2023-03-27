import { TTControl } from "./TTControl";
import { ITTEnumComboBox } from "../ControlInterfaces/ITTEnumComboBox";
import { TTComboBoxItem } from "./TTComboBoxItem";
import { ITTComboBoxItem } from "../ControlInterfaces/ITTComboBoxItem";
import { SortByEnum } from "../../Utils/Enums/SortByEnum";

export class TTEnumComboBox extends TTControl implements ITTEnumComboBox {
    /*[TTDataTypeName]*/
    public DataTypeName: string;
    private _itemCollection: Array<TTComboBoxItem> = new Array<TTComboBoxItem>();
    public get Items(): Array<ITTComboBoxItem> {
        return this._itemCollection;
    }
    public SelectedIndex: number;
    public SelectedItem: ITTComboBoxItem;
    public SelectedText: string;
    public SelectedValue: Object;
    public SortBy: SortByEnum /*SortByEnum*/;
    public ShowClearButton?: boolean;
    public IncludeOnly?: Array<any>;
    /*public event TTControlEventDelegate SelectedIndexChanged;*/
}