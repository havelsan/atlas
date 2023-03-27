import { Guid } from "../../../../Mscorlib/Guid";
import { TTGridColumn } from "./TTGridColumn";
import { ITTListDefComboBoxColumn } from "../../../ControlInterfaces/TTGrid/Columns/ITTListDefComboBoxColumn";
import { ITTComboBoxItem } from "../../../ControlInterfaces/ITTComboBoxItem";
import { ListBoxModeEnum } from "../../../../Utils/Enums/ListBoxModeEnum";

export class TTListDefComboBoxColumn extends TTGridColumn implements ITTListDefComboBoxColumn {
    //private _itemCollection?: Array<TTComboBoxItem> = new Array<TTComboBoxItem>();
    public Items?: Array<ITTComboBoxItem>;
    public RefreshItems?(): void {

    }
    //public get ContainerLinkableObject(): ITTLinkableObject {
    //    // throw new NotImplementedException();
    //    return null;
    //}
    public ForceLinkedParentSelection?: boolean;
    public LinkedControlName?: string;
    public LinkedRelationDefID?: Guid;
    public LinkedRelationPath?: string;
    public ListBoxMode?: ListBoxModeEnum;
    public ListDefName?: string;
    public ListFilterExpression?: string;
    public ItemsSource?: string;
    public ComponentReference?: any;

    //public GetListDef(): TTListDef {
    //    return null;
    //}
}