import { ITTComponentBase } from "./ITTComponentBase";
import { ITTBindableObject } from "./ITTBindableObject";
import { TTObjectDef } from "../../StorageManager/DefinitionManagement/TTObjectDef";

export interface ITTBindableComponent extends ITTComponentBase, ITTBindableObject {
    PropertyName?: string;
    ObjectDef?: TTObjectDef;
}