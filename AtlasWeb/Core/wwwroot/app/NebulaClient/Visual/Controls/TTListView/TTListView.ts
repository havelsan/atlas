import { TTControl } from "../TTControl";
import { ITTListViewItem } from "../../ControlInterfaces/TTListView/ITTListViewItem";
import { ITTListViewColumn } from "../../ControlInterfaces/TTListView/ITTListViewColumn";
import { ITTListView } from "../../ControlInterfaces/TTListView/ITTListView";

export class TTListView extends TTControl implements ITTListView {
    public CheckBoxes?: boolean;
    public FullRowSelect?: boolean;
    public MultiSelect?: boolean;
    public ShowFilterRow?: boolean;
    public EnablePaging?: boolean;
    public PageSize?: number;
    public View?: Object;
    public ListViewItemSorter?: Object;
    public Items?: Array<ITTListViewItem> = new Array<ITTListViewItem>();
    public SelectedItems?: Array<ITTListViewItem>;
    public Height?: any;
    public Columns?: Array<ITTListViewColumn> = new Array<ITTListViewColumn>();
    public RowDisablePath?: string;
    public AllowUserToDeleteRows?: Boolean;
    /*public event TTControlEventDelegate SelectedIndexChanged;*/
    /*public event TTItemCheckedEventDelegate ItemChecked;*/
    /*public event TTControlEventDelegate DoubleClick;*/
    /*public event TTListViewColumnClickEventDelegate ColumnClick;*/
    public Sort?(): void {

    }
}