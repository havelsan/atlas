import { TTGridColumn } from "./TTGridColumn";
import { ITTTextBoxColumn } from "../../../ControlInterfaces/TTGrid/Columns/ITTTextBoxColumn";
import { DataGridViewContentAlignment } from "../../../../Utils/Enums/DataGridViewContentAlignment";
import { DataGridViewTriState } from "../../../../Utils/Enums/DataGridViewTriState";

export class TTTextBoxColumn extends TTGridColumn implements ITTTextBoxColumn {
    public Format?: string;
    public Alignment?: DataGridViewContentAlignment;
    public WrapMode?: DataGridViewTriState;
    public IsNumeric?: Boolean;
    /*public event TTAutoTextSelectedDelegate AutoTextSelected;*/
}