import { TTControl } from "./TTControl";
import { ITTBarcodeBox } from "../ControlInterfaces/ITTBarcodeBox";

export class TTBarcodeBox extends TTControl implements ITTBarcodeBox {
    public EncodedValue?: string;
    public WriteBarcode(value: string): void {

    }
}