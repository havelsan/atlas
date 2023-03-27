import { TTGridColumn } from "./TTGridColumn";
import { TTComboBoxItem } from "../../TTComboBoxItem";
import { ITTComboBoxItem } from "../../../ControlInterfaces/ITTComboBoxItem";
import { ITTStateComboBoxColumn } from "../../../ControlInterfaces/TTGrid/Columns/ITTStateComboBoxColumn";

export class TTStateComboBoxColumn extends TTGridColumn implements ITTStateComboBoxColumn {
    private _itemCollection: Array<TTComboBoxItem> = new Array<TTComboBoxItem>();
    public get Items(): Array<ITTComboBoxItem> {
        return this._itemCollection;
    }
    public ItemsSource: string;
    public ComponentReference: string;
}