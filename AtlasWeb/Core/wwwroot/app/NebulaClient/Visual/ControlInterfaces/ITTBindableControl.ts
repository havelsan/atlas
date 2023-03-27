import { ITTObject } from "../../StorageManager/InstanceManagement/ITTObject";
import { ITTControl } from "./ITTControl";
import { ITTBindableComponent } from "./ITTBindableComponent";

export interface ITTBindableControl extends ITTControl, ITTBindableComponent {
    TTObject?: ITTObject;
    //AddBindingEventHandlers(): void;
    //RemoveBindingEventHandlers(): void;
}