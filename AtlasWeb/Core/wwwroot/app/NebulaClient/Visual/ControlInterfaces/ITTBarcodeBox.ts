import { ITTBindableControl } from "./ITTBindableControl";

/*[TTBrowsableInterface]*/
export interface ITTBarcodeBox extends ITTBindableControl {
    WriteBarcode?(value: string): void;
    EncodedValue?: string;
}