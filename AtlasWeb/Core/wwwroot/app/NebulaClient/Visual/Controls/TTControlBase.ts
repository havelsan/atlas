import { TTComponent } from "./TTComponent";
import { ITTControlBase } from "../ControlInterfaces/ITTControlBase";
import { ITTComponentBase } from "../ControlInterfaces/ITTComponentBase";
import { Font } from "../Font";

export class TTControlBase extends TTComponent implements ITTControlBase {
    public Size?: Object;
    public Location?: Object;
    /*[Browsable(false)]*/
    public Enabled?: boolean;
    /*[ReadOnly(false)]*/
    public TabIndex?: number;
    public Visible?: boolean;
    public Font?: Font | string;
    public BackColor?: string;
    public ForeColor?: string;
    public Dock?: Object;
    public Anchor?: Object;
    /*[Browsable(false)]*/
    public Children?: Array<ITTComponentBase>;
    public Controls?: Array<ITTControlBase>;
    public Focus?(): boolean {
        return false;
    }
    public AddChildComponent?(childComponent: ITTComponentBase): void {

    }
}