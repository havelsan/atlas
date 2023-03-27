import { TTControl } from "../TTControl";
import { ITTRichTextBoxControl } from "../../ControlInterfaces/TTRichTextBoxControl/ITTRichTextBoxControl";

export class TTRichTextBoxControl extends TTControl implements ITTRichTextBoxControl {
    public DisplayText: string;
    public Rtf: string;
    public Iconized: boolean;
    public TemplateGroupName: string;
    public ShowInPlaceToolbar: boolean;
    /*[Browsable(false)]*/
    public GetTemplates: Function;
    /*[Browsable(false)]*/
    public SaveTemplate: Function;
    /*public event TTControlEventDelegate TextChanged;*/
    /*public event TTTemplateSelectedDelegate TemplateSelected;*/
    /*public event TTAutoTextSelectedDelegate AutoTextSelected;*/
}