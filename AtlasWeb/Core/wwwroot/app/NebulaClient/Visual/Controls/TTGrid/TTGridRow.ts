import { TTControl } from "../TTControl";
import { ITTGridRow } from "../../ControlInterfaces/TTGrid/ITTGridRow";
import { ITTGridCell } from "../../ControlInterfaces/TTGrid/ITTGridCell";
import { TTObject } from "../../../StorageManager/InstanceManagement/TTObject";

export class TTGridRow extends TTControl implements ITTGridRow {
    public Cells: Array<ITTGridCell>;
    public ErrorText: string;
    public Height: number;
    public Index: number;
    public MinimumHeight: number;
    public ReadOnly: boolean;
    public IsVisible: boolean;
    public Selected: boolean;
    public TTObject: TTObject;
}