import { TTControl } from "../TTControl";
import { ITTListViewColumnSorter } from "../../ControlInterfaces/TTListView/ITTListViewColumnSorter";
import { SortOrder } from "../../../Utils/Enums/SortOrder";

export class TTListViewColumnSorter extends TTControl implements ITTListViewColumnSorter {
    public SortColumn: number;
    public Order: SortOrder;
    public Compare(x: Object, y: Object): number {
        //throw new NotImplementedException();
        return null;
    }
}