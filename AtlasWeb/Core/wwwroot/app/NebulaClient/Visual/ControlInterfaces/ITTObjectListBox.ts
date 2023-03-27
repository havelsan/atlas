import { Guid } from "../../Mscorlib/Guid";
import { ITTListBox } from "./ITTListBox";
import { ITTBindableControl } from "./ITTBindableControl";
import { TTObject } from "../../StorageManager/InstanceManagement/TTObject";

export interface ITTObjectListBox extends ITTListBox, ITTBindableControl {
    Columns?: Array<any>;
    SelectedObjectID?: Guid;
    SelectedValue?: Object;
    SelectedObject?: TTObject;
    IsNonNumeric?: any;
    Multiline?: any;
    CharacterCasing?: any;
    InputFormat?: any;
    InputTurkishCharacter?: any;
    TextAlign?: any;
    Height?: any;



}