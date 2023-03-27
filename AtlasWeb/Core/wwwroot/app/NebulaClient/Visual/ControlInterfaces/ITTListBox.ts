import { ITTListBoxBase } from "./ITTListBoxBase";
import { ListBoxModeEnum } from "../../Utils/Enums/ListBoxModeEnum";
import { SearchMode, AutoCompleteMode, ListBoxSearchCriteria} from 'NebulaClient/Visual/Controls/TTAutoCompleteGrid';

export interface ITTListBox extends ITTListBoxBase {
    AutoCompleteMode?: AutoCompleteMode;
    ListBoxMode?: ListBoxModeEnum;
    Width?: any;
    SearchMode?: SearchMode;
    AutoCompleteDialogWidth?: String;
    AutoCompleteDialogHeight?: String;
    SearchTimeout?: Number;
    MinSearchLength?: Number;

    PopupDialogFieldConfig?: Array<ListBoxSearchCriteria>;
    PopupDialogGridColumns?: Array<any>;
    PopupDialogWidth?: any;
    PopupDialogHeight?: any;
    PopupDialogTitle?: String;
}