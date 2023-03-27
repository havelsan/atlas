import { ITTBindableGridColumn } from "./ITTBindableGridColumn";

/*[TTBrowsableInterface]*/
export interface ITTButtonColumn extends ITTBindableGridColumn {
    UseColumnTextForButtonValue?: boolean;
    Clicked?: Function;
    ComponentReference?: any;
    ButtonWidth?: string;
    Height?: String;
}