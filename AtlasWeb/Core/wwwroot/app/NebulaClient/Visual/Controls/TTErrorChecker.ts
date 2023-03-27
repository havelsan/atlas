import { TTControl } from "./TTControl";
import { ITTErrorChecker } from "../ControlInterfaces/ITTErrorChecker";

export class TTErrorChecker extends TTControl implements ITTErrorChecker {
    public SetErrorText(errorText: string): void {

    }
    public CheckErrors(): string {
        return null;
    }
}