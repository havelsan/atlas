import { ITTBindableControl } from "../ITTBindableControl";

/*[TTBrowsableInterface]*/
export interface ITTRichTextBoxControl extends ITTBindableControl {
    /*[TTTextChanged]
event TTControlEventDelegate TextChanged;*/
    DisplayText?: string;
    Rtf?: string;
    Iconized?: boolean;
    TemplateGroupName?: string;
    ShowInPlaceToolbar?: boolean;
    /*[Browsable(false)]*/
    //GetTemplates: TTGetTemplatesDelegate;
    /*[Browsable(false)]*/
    //SaveTemplate: TTSaveTemplateDelegate;
    /*[Browsable(false)]
           event TTTemplateSelectedDelegate TemplateSelected;*/
    /*[Browsable(false)]
           event TTAutoTextSelectedDelegate AutoTexSelected;*/
}