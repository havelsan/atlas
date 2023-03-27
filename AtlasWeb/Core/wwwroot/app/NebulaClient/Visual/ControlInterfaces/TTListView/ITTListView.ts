import { ITTControlBase } from "../ITTControlBase";
import { ITTListViewItem } from "./ITTListViewItem";
import { ITTListViewColumn } from "./ITTListViewColumn";

/*[TTBrowsableInterface]*/
export interface ITTListView extends ITTControlBase {
    CheckBoxes?: boolean;
    FullRowSelect?: boolean;
    MultiSelect?: boolean;
    // View: View;
    Sort?(): void;
    // ListViewItemSorter: IComparer;
    Items?: Array<ITTListViewItem>;
    SelectedItems?: Array<ITTListViewItem>;
    Columns?: Array<ITTListViewColumn>;
    ShowFilterRow?: boolean;
    Height?: any;
    EnablePaging?: boolean;
    PageSize?: number;
    RowDisablePath?: string;
    AllowUserToDeleteRows?: Boolean;
    /*[TTSelectedIndexChanged]
           event TTControlEventDelegate SelectedIndexChanged;*/
    /*[TTItemChecked]
           event TTItemCheckedEventDelegate ItemChecked;*/
    /*[TTDoubleClick]
           event TTControlEventDelegate DoubleClick;*/
    /*[TTColumnClick]
           event TTListViewColumnClickEvenDelegate ColumnClick;*/
}