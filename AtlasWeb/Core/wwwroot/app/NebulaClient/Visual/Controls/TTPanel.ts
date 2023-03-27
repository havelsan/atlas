import { TTControl } from "./TTControl";
import { ITTPanel } from "../ControlInterfaces/ITTPanel";
import { BorderStyle } from "../../Utils/Enums/BorderStyle";

export class TTPanel extends TTControl implements ITTPanel {
    public BorderStyle: BorderStyle;
    public AutoSize: boolean;
    public AutoScroll: boolean;
}