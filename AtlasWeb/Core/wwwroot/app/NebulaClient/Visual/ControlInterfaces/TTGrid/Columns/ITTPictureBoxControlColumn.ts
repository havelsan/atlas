import { ITTBindableGridColumn } from "./ITTBindableGridColumn";

/*[TTBrowsableInterface]*/
export interface ITTPictureBoxControlColumn extends ITTBindableGridColumn {
    DisplayText?: string;
    Iconized?: boolean;
    TemplateGroupName?: string;
    Image?: ArrayBuffer;
    // SizeMode: PictureBoxSizeMode;
    /*[Browsable(false)]*/
    // GetTemplates: TTGetTemplatesDelegate;
    /*[Browsable(false)]*/
    // SaveTemplate: TTSaveTemplateDelegate;
    /*[Browsable(false)]
           event TTTemplateSelectedDelegate TemplateSeleced;*/
}