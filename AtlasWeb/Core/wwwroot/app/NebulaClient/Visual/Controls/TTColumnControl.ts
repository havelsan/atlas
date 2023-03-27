import { TTControl } from "./TTControl";
import { ITTColumnControl } from "../ControlInterfaces/ITTColumnControl";

export class TTColumnControl extends TTControl implements ITTColumnControl {
    public ColumnWidth: number;
    public ColumnName: string;
}