import { Guid } from "../../Mscorlib/Guid";
import { TTControl } from "./TTControl";
import { ITTListBox } from "../ControlInterfaces/ITTListBox";
import { ListBoxModeEnum } from "../../Utils/Enums/ListBoxModeEnum";
import { SearchMode, AutoCompleteMode, ListBoxSearchCriteria } from 'NebulaClient/Visual/Controls/TTAutoCompleteGrid';

export class TTListBox extends TTControl implements ITTListBox {
    public ForceLinkedParentSelection: boolean;
    public LinkedControlName: string;
    public LinkedRelationDefID: Guid;
    public LinkedRelationPath: string;
    public ListBoxMode: ListBoxModeEnum;
    public ListDefName: string;
    public ListFilterExpression: string;
    public AutoCompleteMode?: AutoCompleteMode = AutoCompleteMode.List;
    public Columns?: Array<any>;
    public SearchMode?: SearchMode;
    public AutoCompleteDialogWidth?: String;
    public AutoCompleteDialogHeight?: String;
    public SearchTimeout?: Number;
    public MinSearchLength?: Number;

    public PopupDialogFieldConfig?: Array<ListBoxSearchCriteria>;
    public PopupDialogGridColumns?: Array<any>;
    public PopupDialogWidth?: any;
    public PopupDialogHeight?: any;
    public PopupDialogTitle?: String;
    public Filter?: ITTListBox;
}