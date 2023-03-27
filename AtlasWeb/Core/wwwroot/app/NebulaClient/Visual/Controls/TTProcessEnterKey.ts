import { TTControl } from "./TTControl";
import { ITTProcessEnterKey } from "../ControlInterfaces/ITTProcessEnterKey";

export class TTProcessEnterKey extends TTControl implements ITTProcessEnterKey {
    public ProcessEnterKey(): boolean {
        return false;
    }
}