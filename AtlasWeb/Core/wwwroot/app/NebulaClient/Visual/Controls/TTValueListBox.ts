import { Guid } from "../../Mscorlib/Guid";
import { TTControl } from "./TTControl";
import { ITTValueListBox } from "../ControlInterfaces/ITTValueListBox";
import { ListBoxModeEnum } from "../../Utils/Enums/ListBoxModeEnum";
import { SearchMode } from 'NebulaClient/Visual/Controls/TTAutoCompleteGrid';

export class TTValueListBox extends TTControl implements ITTValueListBox {
    public ForceLinkedParentSelection: boolean;
    public LinkedControlName: string;
    public LinkedRelationDefID: Guid;
    public LinkedRelationPath: string;
    public ListBoxMode: ListBoxModeEnum;
    public ListDefName: string;
    public ListFilterExpression: string;
    public SelectedObjectID: Guid;
    public SelectedValue: Object;
    public SelectedObject: any;
    public DialogWidth?: String;
    public SearchMode?: SearchMode;
    public SearchTimeout?: Number;

    Width?: any;
    AutoCompleteDialogWidth?: any;
    MinSearchLength?: any;
    AutoCompleteMode?: any;
    AutoCompleteDialogHeight?: any;
    PopupDialogFieldConfig?: any;
    PopupDialogGridColumns?: any;
    PopupDialogWidth?: any;
    PopupDialogHeight?: any;
    PopupDialogTitle?: any;


}