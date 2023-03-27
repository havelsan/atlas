import { Guid } from "../../../Mscorlib/Guid";
import { TTControl } from "../TTControl";
import { ITTGridRow } from "../../ControlInterfaces/TTGrid/ITTGridRow";
import { ITTGridColumn } from "../../ControlInterfaces/TTGrid/Columns/ITTGridColumn";
import { TTComboBoxItem } from "../TTComboBoxItem";
import { ITTComboBoxItem } from "../../ControlInterfaces/ITTComboBoxItem";
import { ITTGridComboBoxCell } from "../../ControlInterfaces/TTGrid/ITTGridComboBoxCell";

export class TTGridComboBoxCell extends TTControl implements ITTGridComboBoxCell {
    private _itemCollection: Array<TTComboBoxItem> = new Array<TTComboBoxItem>();
    public get Items(): Array<ITTComboBoxItem> {
        return this._itemCollection;
    }
    public ColumnIndex: number;
    //public get ContainerLinkableObject(): ITTLinkableObject {
    //    //throw new NotImplementedException();
    //    return null;
    //}
    public ErrorText: string;
    public ForceLinkedParentSelection: boolean;
    public LinkedControlName: string;
    public LinkedRelationDefID: Guid;
    public LinkedRelationPath: string;
    public OwningColumn: ITTGridColumn;
    public OwningRow: ITTGridRow;
    public RowIndex: number;
    public Selected: boolean;
    public Value: Object;
}