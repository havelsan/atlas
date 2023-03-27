import { TTControl } from "../TTControl";
import { ITTListViewColumn } from "../../ControlInterfaces/TTListView/ITTListViewColumn";
import { HorizontalAlignment } from "../../../Utils/Enums/HorizontalAlignment";

export class TTListViewColumn extends TTControl implements ITTListViewColumn {
    public TextAlign: HorizontalAlignment;
    public Width: number;
}