import { TTGridColumn } from "./TTGridColumn";
import { ITTEnumComboBoxColumn } from "../../../ControlInterfaces/TTGrid/Columns/ITTEnumComboBoxColumn";
import { ITTComboBoxItem } from "../../../ControlInterfaces/ITTComboBoxItem";
import { SortByEnum } from "../../../../Utils/Enums/SortByEnum";

export class TTEnumComboBoxColumn extends TTGridColumn implements ITTEnumComboBoxColumn {
    /*[TTDataTypeName]*/
    public DataTypeName?: string;
    //private _itemCollection?: Array<TTComboBoxItem> = new Array<TTComboBoxItem>();
    public Items?: Array<ITTComboBoxItem>;
    public SortBy?: SortByEnum;
    public ItemsSource?: string;
    public ComponentReference?: any;
    public ShowClearButton?: boolean;
}