import { ITTComponent } from "./ITTComponent";
import { ITTComponentBase } from "./ITTComponentBase";

/*[TTBrowsableInterface]*/
export interface ITTControlBase extends ITTComponent {
    // Size: Size;
    // Location: Point;
    /*[Browsable(false)]*/
    Enabled?: boolean;
    /*[ReadOnly(false)]*/
    TabIndex?: number;
    Visible?: boolean;
    BackColor?: string;
    ForeColor?: string;
    Font?: any;
    // Dock: DockStyle;
    // Anchor: AnchorStyles;
    /*[Browsable(false)]*/
    Children?: Array<ITTComponentBase>;
    Focus?(): boolean;
    AddChildComponent?(childComponent: ITTComponentBase): void;
    Controls?: Array<ITTControlBase>;
}