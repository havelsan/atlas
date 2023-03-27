import { ITTBindableGridColumn } from "./ITTBindableGridColumn";
import { DateTimePickerFormat } from "../../../../Utils/Enums/DateTimePickerFormat";
/*[TTBrowsableInterface]*/
export interface ITTDateTimePickerColumn extends ITTBindableGridColumn {
    CustomFormat?: string;
    Format?: DateTimePickerFormat;
    /*[Browsable(false)]*/
    ShowCheckBox?: boolean;
    Min?: any;
    Max?: any;
}