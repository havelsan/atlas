import { Guid } from "../../Mscorlib/Guid";
import { TTControl } from "./TTControl";
import { TTComboBoxItem } from "./TTComboBoxItem";
import { ITTListDefComboBox } from "../ControlInterfaces/ITTListDefComboBox";
import { ITTComboBoxItem } from "../ControlInterfaces/ITTComboBoxItem";
import { ListBoxModeEnum } from "../../Utils/Enums/ListBoxModeEnum";

export class TTListDefComboBox extends TTControl implements ITTListDefComboBox {
    private _itemCollection: Array<TTComboBoxItem> = new Array<TTComboBoxItem>();
    //public get ContainerLinkableObject(): ITTLinkableObject {
    //    // throw new NotImplementedException();
    //    return null;
    //}
    public ForceLinkedParentSelection: boolean;
    public get Items(): Array<ITTComboBoxItem> {
        return this._itemCollection;
    }
    public LinkedControlName: string;
    public LinkedRelationDefID: Guid;
    public LinkedRelationPath: string;
    public ListBoxMode: ListBoxModeEnum;
    public ListDefName: string;
    public ListFilterExpression: string;
    public SelectedIndex: number;
    public SelectedItem: ITTComboBoxItem;
    public SelectedText: string;
    public SelectedValue: Object;
    /*public event TTControlEventDelegate SelectedIndexChanged;*/
    public SearchMode: string;
    public RefreshItems(): void {

    }

    //public GetListDef(): TTListDef {
    //    return null;
    //}
}