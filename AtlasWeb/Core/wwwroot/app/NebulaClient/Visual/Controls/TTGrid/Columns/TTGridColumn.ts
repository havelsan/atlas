import { TTControl } from "../../TTControl";
import { ITTGridColumn } from "../../../ControlInterfaces/TTGrid/Columns/ITTGridColumn";
import { ITTBindableGridColumn } from "../../../ControlInterfaces/TTGrid/Columns/ITTBindableGridColumn";
import { Font } from "../../../Font";

export class TTGridColumn extends TTControl implements ITTGridColumn, ITTBindableGridColumn {
    public Type?: string;
    public HeaderText?: string;
    /*[ReadOnly(false)]*/
    public Index?: number;
    /*[ReadOnly(false)]*/
    public DisplayIndex?: number;
    public Font?: Font;
    public BackColor?: string;
    public ForeColor?: string;
    public Width?: any;
    public MinimumWidth?: number;
    public Sortable?: boolean;
    public Required?: boolean;
    public Visible?: boolean;
    public ToolTipText?: string;
    public EnabledBindingPath?: string;
}