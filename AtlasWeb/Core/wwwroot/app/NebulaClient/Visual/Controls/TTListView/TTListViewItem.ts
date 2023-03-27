import { TTControl } from "../TTControl";
import { ITTListViewItem } from "../../ControlInterfaces/TTListView/ITTListViewItem";
import { ITTListViewSubItem } from "../../ControlInterfaces/TTListView/ITTListViewSubItem";

export class TTListViewItem extends TTControl implements ITTListViewItem {
    public SubItems: Array<ITTListViewSubItem> = new Array<ITTListViewSubItem>();
    public Selected: boolean;
    public Checked: boolean;
}