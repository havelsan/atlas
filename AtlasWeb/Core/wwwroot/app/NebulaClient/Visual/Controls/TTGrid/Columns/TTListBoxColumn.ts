import { Guid } from "../../../../Mscorlib/Guid";
import { TTGridColumn } from "./TTGridColumn";
import { ITTListBoxColumn } from "../../../ControlInterfaces/TTGrid/Columns/ITTListBoxColumn";
import { ListBoxModeEnum } from "../../../../Utils/Enums/ListBoxModeEnum";

export class TTListBoxColumn extends TTGridColumn implements ITTListBoxColumn {
    public AllowMultiSelect?: boolean;
    //public get ContainerLinkableObject(): ITTLinkableObject {
    //   // throw new NotImplementedException();
    //   return null;
    //}
    public ForceLinkedParentSelection?: boolean;
    public Enabled?: boolean;
    public LinkedControlName?: string;
    public LinkedRelationDefID?: Guid;
    public LinkedRelationPath?: string;
    public ListBoxMode?: ListBoxModeEnum;
    public ListDefName?: string;
    public ListFilterExpression?: string;
    public ListFilterExpressionPath?: string;
    public AutoCompleteDialogWidth?: String;
    public AutoCompleteDialogHeight?: String;
    //public GetListDef(): TTListDef {
    //    return null;
    //}
}