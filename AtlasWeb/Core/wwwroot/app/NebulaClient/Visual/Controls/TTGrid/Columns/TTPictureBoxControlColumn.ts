import { TTGridColumn } from "./TTGridColumn";
import { ITTPictureBoxControlColumn } from "../../../ControlInterfaces/TTGrid/Columns/ITTPictureBoxControlColumn";
import { PictureBoxSizeMode } from "../../../../Utils/Enums/PictureBoxSizeMode";

export class TTPictureBoxControlColumn extends TTGridColumn implements ITTPictureBoxControlColumn {
    public DisplayText: string;
    public Iconized: boolean;
    public TemplateGroupName: string;
    public Image: ArrayBuffer;
    public SizeMode: PictureBoxSizeMode;
    /*[Browsable(false)]*/
    public GetTemplates: Function;
    /*[Browsable(false)]*/
    public SaveTemplate: Function;
    /*public event TTTemplateSelectedDelegate TemplateSelected;*/
}