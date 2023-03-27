import { TTControl } from "./TTControl";
import { ITTLabel } from "../ControlInterfaces/ITTLabel";

export class TTLabel extends TTControl implements ITTLabel {
    public AutoSize: boolean;
}