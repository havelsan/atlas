import { Guid } from "../../Mscorlib/Guid";
import { TTControl } from "./TTControl";
import { ITTObjectListBox } from "../ControlInterfaces/ITTObjectListBox";
import { TTObject } from "../../StorageManager/InstanceManagement/TTObject";
import { ListBoxModeEnum } from "../../Utils/Enums/ListBoxModeEnum";
import { SearchMode, AutoCompleteMode, ListBoxSearchCriteria} from 'NebulaClient/Visual/Controls/TTAutoCompleteGrid';

export class TTObjectListBox extends TTControl implements ITTObjectListBox {
    public SelectedObjectID: Guid;
    public SelectedValue: Object;
    public SelectedObject: TTObject;
    //public get ContainerLinkableObject(): ITTLinkableObject {
    //    // throw new NotImplementedException();
    //    return null;
    //}
    AutoCompleteMode?: AutoCompleteMode;
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

    public ForceLinkedParentSelection: boolean;
    public LinkedControlName: string;
    public LinkedRelationDefID: Guid;
    public LinkedRelationPath: string;
    public ListBoxMode: ListBoxModeEnum;
    public ListDefName: string;
    public ListFilterExpression: string;
    /*public event TTControlEventDelegate SelectedObjectChanged;*/
    //public GetListDef(): TTListDef {
    //    return null;
    //}
}