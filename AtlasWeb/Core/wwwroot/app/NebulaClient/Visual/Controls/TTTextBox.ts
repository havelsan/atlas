import { TTControl } from "./TTControl";
import { ITTTextBox } from "../ControlInterfaces/ITTTextBox";
import { HorizontalAlignment } from "../../Utils/Enums/HorizontalAlignment";
import { CharacterCasing } from "../../Utils/Enums/CharacterCasing";
import { InputFormat } from "../../Utils/Enums/InputFormat";

export class TTTextBox extends TTControl implements ITTTextBox {
    public Multiline: boolean;
    public CharacterCasing: CharacterCasing;
    public InputFormat: InputFormat;
    public InputTurkishCharacter: boolean;
    public TextAlign: HorizontalAlignment;
    public PasswordChar: string;
    public Height?: string;
    public IsNonNumeric?: Boolean;
    TemplateGroupName: any;
    ListDefDisplayExpressions: any;
    /*public event TTControlEventDelegate TextChanged;*/
    /*public event TTAutoTextSelectedDelegate AutoTextSelected;*/
    /*public event TTShowTextSelectedDelegate ShowTextSelected;*/
}