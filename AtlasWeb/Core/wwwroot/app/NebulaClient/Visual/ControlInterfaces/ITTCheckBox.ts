import { ITTBindableControl } from "./ITTBindableControl";

/*[TTBrowsableInterface]*/
export interface ITTCheckBox extends ITTBindableControl {
    /*[TTCheckedChanged]
event TTControlEventDelegate CheckedChanged;*/
    ThreeState?: boolean;
    Value?: boolean;
    Checked?: boolean;
    IsTitleLeft?: boolean;
    Title?: String;
    Margin?: String;
    TitleTopPadding?: String;
}