import { TTControl } from "./TTControl";
import { ITTMultiRowControl } from "../ControlInterfaces/ITTMultiRowControl";

export class TTMultiRowControl extends TTControl implements ITTMultiRowControl {
    public AllowUserToAddRows: boolean;
    public AllowUserToDeleteRows: boolean;
    public MaximumRowCount: number;
    public AllowUserToAddRowsSecured: boolean;
    public AllowUserToDeleteRowsSecured: boolean;
}