import { ITTBindableControl } from "./ITTBindableControl";
import { MaskFormat} from "../../Utils/Enums/MaskFormat";
import { HorizontalAlignment } from "../../Utils/Enums/HorizontalAlignment";
/*[TTBrowsableInterface]*/
export interface ITTMaskedTextBox extends ITTBindableControl {
    /*[TTTextChanged]
event TTControlEventDelegate TextChanged;*/
    AsciiOnly?: boolean;
    BeepOnError?: boolean;
    SkipLiterals?: boolean;
    Mask?: string;
    Min?: number;
    Max?: number;
    Format?: string;
    CutCopyMaskFormat?: MaskFormat;
    TextMaskFormat?: MaskFormat;
    TextAlign?: HorizontalAlignment;
    /*[Browsable(false)]*/
    MaskCompleted?: boolean;
    InputTurkishCharacter?: boolean;
    CustomFormat?: any;
}