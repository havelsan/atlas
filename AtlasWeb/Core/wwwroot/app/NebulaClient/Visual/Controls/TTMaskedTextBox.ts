import { TTControl } from "./TTControl";
import { ITTMaskedTextBox } from "../ControlInterfaces/ITTMaskedTextBox";
import { MaskFormat} from "../../Utils/Enums/MaskFormat";
import { HorizontalAlignment} from "../../Utils/Enums/HorizontalAlignment";

export class TTMaskedTextBox extends TTControl implements ITTMaskedTextBox {
    public AsciiOnly: boolean;
    public BeepOnError: boolean;
    public SkipLiterals: boolean;
    public Mask: string;
    public CutCopyMaskFormat: MaskFormat;
    public TextMaskFormat: MaskFormat;
    public TextAlign: HorizontalAlignment;
    /*[Browsable(false)]*/
    public MaskCompleted: boolean;
    CustomFormat: string;
    public InputTurkishCharacter: boolean;
    /*public event TTControlEventDelegate TextChanged;*/
}