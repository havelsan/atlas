import { TTControl } from "../TTControl";
import { ITTPictureBoxControl } from "../../ControlInterfaces/TTPictureBoxControl/ITTPictureBoxControl";
import { PictureBoxSizeMode } from "../../../Utils/Enums/PictureBoxSizeMode";
export class TTPictureBoxControl extends TTControl implements ITTPictureBoxControl {
    public DisplayText: string;
    public Iconized: boolean;
    public MaxFileSize: number;
    public TemplateGroupName: string;
    public Image: ArrayBuffer;
    public SizeMode: PictureBoxSizeMode;
    /*[Browsable(false)]*/
    public GetTemplates: Function;
    /*[Browsable(false)]*/
    public SaveTemplate: Function;
    /*public event TTTemplateSelectedDelegate TemplateSelected;*/
}