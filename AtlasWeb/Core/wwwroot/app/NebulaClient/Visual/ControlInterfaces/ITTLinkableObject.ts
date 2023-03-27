import { Guid } from "../../Mscorlib/Guid";

/*[TTBrowsableInterface]*/
export interface ITTLinkableObject {
    LinkedControlName?: string;
    LinkedRelationDefID?: Guid;
    LinkedRelationPath?: string;
    ForceLinkedParentSelection?: boolean;
    /*[Browsable(false)]*/
    ContainerLinkableObject?: ITTLinkableObject;
}