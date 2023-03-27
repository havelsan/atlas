import { Guid } from "../../Mscorlib/Guid";
import { TTControl } from "./TTControl";
import { ITTLinkableObject } from "../ControlInterfaces/ITTLinkableObject";

export class TTLinkableObject extends TTControl implements ITTLinkableObject {
    public LinkedControlName: string;
    public LinkedRelationDefID: Guid;
    public LinkedRelationPath: string;
    public ForceLinkedParentSelection: boolean;
    /*[Browsable(false)]*/
    //public ContainerLinkableObject: ITTLinkableObject;
}