import { TTGridColumn } from "./TTGridColumn";
import { ITTButtonColumn } from "../../../ControlInterfaces/TTGrid/Columns/ITTButtonColumn";
export class TTButtonColumn extends TTGridColumn implements ITTButtonColumn {
    public UseColumnTextForButtonValue?: boolean;
    public Clicked?: Function;
    public ComponentReference?: any;
    public ButtonWidth?: string;
    public Height?: String;
}