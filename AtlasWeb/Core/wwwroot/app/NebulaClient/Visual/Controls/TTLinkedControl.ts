import { Guid } from "../../Mscorlib/Guid";
import { TTControl } from "./TTControl";
import { ITTLinkedControl } from "../ControlInterfaces/ITTLinkedControl";
import { ListBoxModeEnum } from "../../Utils/Enums/ListBoxModeEnum";

export class TTLinkedControl extends TTControl implements ITTLinkedControl {
    //public GetListDef(): TTListDef {
    //    return null;
    //}
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
}