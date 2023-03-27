import { Guid } from "../../../Mscorlib/Guid";
import { TTControl } from "../TTControl";
import { ITTGridRow } from "../../ControlInterfaces/TTGrid/ITTGridRow";
import { ITTGridColumn } from "../../ControlInterfaces/TTGrid/Columns/ITTGridColumn";

export class TTGridCell extends TTControl implements ITTGridColumn {
    public Type: string;
    public HeaderText: string;
    public DisplayIndex: number;
    public Width: number;
    public MinimumWidth: number;
    public Sortable: boolean;
    public ToolTipText: string;
    public ColumnIndex: number;
    public RowIndex: number;
    public ErrorText: string;
    public Selected: boolean;
    public Value: Object;
    public OwningRow: ITTGridRow;
    public OwningColumn: ITTGridColumn;
    public LinkedControlName: string;
    public LinkedRelationDefID: Guid;
    public LinkedRelationPath: string;
    public ForceLinkedParentSelection: boolean;
    //public get ContainerLinkableObject(): ITTLinkableObject {
    //    // throw new NotImplementedException();
    //    return null;
    //}
}