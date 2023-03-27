import { ITTBindableControl } from "../ITTBindableControl";
import { PictureBoxSizeMode } from "../../../Utils/Enums/PictureBoxSizeMode";
/*[TTBrowsableInterface]*/
export interface ITTPictureBoxControl extends ITTBindableControl {
    DisplayText?: string;
    Iconized?: boolean;
    MaxFileSize?: number;
    TemplateGroupName?: string;
    Image?: ArrayBuffer;
    SizeMode?: PictureBoxSizeMode;
    /*[Browsable(false)]*/
    //GetTemplates: TTGetTemplatesDelegate;
    /*[Browsable(false)]*/
    //SaveTemplate: TTSaveTemplateDelegate;
    /*[Browsable(false)]
           event TTTemplateSelectedDelegate TemplateSeleced;*/
}