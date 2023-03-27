import { TTGridColumn } from "./TTGridColumn";
import { ITTCheckBoxColumn } from "../../../ControlInterfaces/TTGrid/Columns/ITTCheckBoxColumn";

export class TTCheckBoxColumn extends TTGridColumn implements ITTCheckBoxColumn {
    public ThreeState?: boolean;
    public Margin?: String;
    public TitleTopPadding?: String;
}