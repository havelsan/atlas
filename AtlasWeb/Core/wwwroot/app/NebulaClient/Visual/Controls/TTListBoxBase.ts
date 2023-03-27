import { Guid } from "../../Mscorlib/Guid";
import { TTControl } from "./TTControl";
import { ITTListBoxBase } from "../ControlInterfaces/ITTListBoxBase";
import { ListBoxModeEnum } from "../../Utils/Enums/ListBoxModeEnum";

export class TTListBoxBase extends TTControl implements ITTListBoxBase {
    //public get ContainerLinkableObject(): ITTLinkableObject {
    //    //throw new NotImplementedException();
    //    return null;
    //}
    public ForceLinkedParentSelection: boolean;
    public LinkedControlName: string;
    public LinkedRelationDefID: Guid;
    public LinkedRelationPath: string;
    public ListBoxMode: ListBoxModeEnum;
    public ListDefName: string;
    public ListFilterExpression: string;

    //public GetListDef(): TTListDef {
    //    return null;
    //}
}