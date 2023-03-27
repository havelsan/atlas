import { ITTBindableGridColumn } from "./ITTBindableGridColumn";
import { DataGridViewContentAlignment } from "NebulaClient/Utils/Enums/DataGridViewContentAlignment";
import { DataGridViewTriState } from "NebulaClient/Utils/Enums/DataGridViewTriState";
/*[TTBrowsableInterface]*/
export interface ITTTextBoxColumn extends ITTBindableGridColumn {
    Format?: string;
    Alignment?: DataGridViewContentAlignment;
    WrapMode?: DataGridViewTriState;
    IsNumeric?: Boolean;
    /*[Browsable(false)]
           event TTAutoTextSelectedDelegate AutoTextSeleced;*/
    IsNonNumeric?: any;
    Multiline?: any;
    CharacterCasing?: any;
    InputFormat?: any;
    InputTurkishCharacter?: any;
    TextAlign?: any;
    TabIndex?: any;
    Height?: any;
    Enabled?: any;
}