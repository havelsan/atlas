import { TTGridColumn } from "./TTGridColumn";
import { ITTRichTextBoxControlColumn } from "../../../ControlInterfaces/TTGrid/Columns/ITTRichTextBoxControlColumn";

export class TTRichTextBoxControlColumn extends TTGridColumn implements ITTRichTextBoxControlColumn {
    public DisplayText?: string;
    public Rtf?: string;
    /*[Browsable(false)]*/
    public Iconized?: boolean;
    public TemplateGroupName?: string;
    /*[Browsable(false)]*/
    public GetTemplates?: Function;
    /*[Browsable(false)]*/
    public SaveTemplate?: Function;
    /*public event TTTemplateSelectedDelegate TemplateSelected;*/
}