import { ITTBindableControl } from "./ITTBindableControl";
import { CharacterCasing } from "../../Utils/Enums/CharacterCasing";
import { HorizontalAlignment } from "../../Utils/Enums/HorizontalAlignment";

/*[TTBrowsableInterface]*/
export interface ITTTextBox extends ITTBindableControl  {
    /*[TTTextChanged]
event TTControlEventDelegate TextChanged;*/
    Multiline?: boolean;
    CharacterCasing?: CharacterCasing;
    InputFormat?: number;
    InputTurkishCharacter?: boolean;
    TextAlign?: HorizontalAlignment;
    PasswordChar?: string;
    Height?: string;
    IsNonNumeric?: Boolean;
    Mask?: string;
    TemplateGroupName: any;
    ListDefDisplayExpressions: any;
    /*[Browsable(false)]
           event TTAutoTextSelectedDelegate AutoTextSelected;*/
    /*[Browsable(false)]
           event TTShowTextSelectedDelegate ShowTexSelected;*/
}