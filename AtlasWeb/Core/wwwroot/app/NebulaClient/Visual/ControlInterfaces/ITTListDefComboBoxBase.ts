import { ITTListBoxBase } from "./ITTListBoxBase";

/*[TTBrowsableInterface]*/
export interface ITTListDefComboBoxBase extends ITTListBoxBase {
    RefreshItems?(): void;
}