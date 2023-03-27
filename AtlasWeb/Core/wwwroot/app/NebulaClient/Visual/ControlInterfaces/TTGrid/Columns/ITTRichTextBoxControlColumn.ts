import { ITTBindableGridColumn } from "./ITTBindableGridColumn";

/*[TTBrowsableInterface]*/
export interface ITTRichTextBoxControlColumn extends ITTBindableGridColumn {
    DisplayText?: string;
    Rtf?: string;
    /*[Browsable(false)]*/
    Iconized?: boolean;
    TemplateGroupName?: string;
    /*[Browsable(false)]*/
    //GetTemplates: TTGetTemplatesDelegate;
    /*[Browsable(false)]*/
    //SaveTemplate: TTSaveTemplateDelegate;
    /*[Browsable(false)]
           event TTTemplateSelectedDelegate TemplateSeleced;*/
}