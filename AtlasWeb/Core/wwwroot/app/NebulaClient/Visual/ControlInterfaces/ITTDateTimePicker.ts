import { ITTBindableControl } from "./ITTBindableControl";
import { DateTimePickerFormat } from "../../Utils/Enums/DateTimePickerFormat";
/*[TTBrowsableInterface]*/
export interface ITTDateTimePicker extends ITTBindableControl {
    CustomFormat?: string;
    Format?: DateTimePickerFormat;
    NullableValue?: Date;
    Min?: any;
    Max?: any;
    /*[TTValueChanged]
           event TTControlEventDelegate ValueChaned;*/
}