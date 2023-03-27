import { TTGridColumn } from "./TTGridColumn";
import { ITTMaskedTextBoxColumn } from "../../../ControlInterfaces/TTGrid/Columns/ITTMaskedTextBoxColumn";

export class TTMaskedTextBoxColumn extends TTGridColumn implements ITTMaskedTextBoxColumn {
    public AsciiOnly?: boolean;
    public BeepOnError?: boolean;
    public SkipLiterals?: boolean;
    public Mask?: string;
    public CutCopyMaskFormat?: string;
    public TextMaskFormat?: string;
}