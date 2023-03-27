import { ITTDataMember } from "../../ITTDataMember";
import { ITTComponentBase } from "../../ITTComponentBase";
import { Font } from "../../../../Visual/Font";

/*[TTBrowsableInterface]*/
export interface ITTGridColumn extends ITTDataMember, ITTComponentBase {
    Type?: string;
    HeaderText?: string;
    /*[ReadOnly(false)]*/
    Index?: number;
    /*[ReadOnly(false)]*/
    DisplayIndex?: number;
    Font?: Font | string;
    BackColor?: string;
    ForeColor?: string;
    Width?: any;
    MinimumWidth?: number;
    Sortable?: boolean;
    Required?: boolean;
    Visible?: boolean;
    ToolTipText?: string;
    EnabledBindingPath?: string;
}