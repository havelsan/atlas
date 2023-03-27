import { TTControl } from "./TTControl";
import { ITTCheckBox } from "../ControlInterfaces/ITTCheckBox";

export class TTCheckBox extends TTControl implements ITTCheckBox {
    public ThreeState: boolean;
    public Value: boolean;
    public Checked: boolean;
    public IsTitleLeft: boolean;
    public Title?: String;
    public Margin?: String;
    public TitleTopPadding?: String;
}