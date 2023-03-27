import { Guid } from "../../Mscorlib/Guid";
import { TTControl } from "./TTControl";
import { ITTListDefComboBoxBase } from "../ControlInterfaces/ITTListDefComboBoxBase";
import { ListBoxModeEnum } from "../../Utils/Enums/ListBoxModeEnum";

export class TTListDefComboBoxBase extends TTControl implements ITTListDefComboBoxBase {
    public RefreshItems(): void {

    }
    //public get ContainerLinkableObject(): ITTLinkableObject {
    //    // throw new NotImplementedException();
    //    return null;
    //}
    public ForceLinkedParentSelection: boolean;
    public LinkedControlName: string;
    public LinkedRelationDefID: Guid;
    public LinkedRelationPath: string;
    public ListBoxMode: ListBoxModeEnum;
    public ListDefName: string;
    public ListFilterExpression: string;

    // public GetListDef(): TTListDef {
    //    return null;
    //}
}