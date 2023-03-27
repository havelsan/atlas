import { ITTBindableGridColumn } from "./ITTBindableGridColumn";

/*[TTBrowsableInterface]*/
export interface ITTMaskedTextBoxColumn extends ITTBindableGridColumn {
    AsciiOnly?: boolean;
    BeepOnError?: boolean;
    SkipLiterals?: boolean;
    Mask?: string;
    CutCopyMaskFormat?: string;
    TextMaskFormat?: string;
}