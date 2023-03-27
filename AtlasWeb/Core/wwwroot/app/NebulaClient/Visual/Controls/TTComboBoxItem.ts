import { TTControl } from "./TTControl";
import { ITTComboBoxItem } from "../ControlInterfaces/ITTComboBoxItem";

export class TTComboBoxItem extends TTControl implements ITTComboBoxItem {
    public Text: string;
    public Value: Object;
}