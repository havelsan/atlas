import { TTGridColumn } from "./TTGridColumn";
import { ITTDateTimePickerColumn } from "../../../ControlInterfaces/TTGrid/Columns/ITTDateTimePickerColumn";
import { DateTimePickerFormat } from  "../../../../Utils/Enums/DateTimePickerFormat";

export class TTDateTimePickerColumn extends TTGridColumn implements ITTDateTimePickerColumn {
    public CustomFormat?: string;
    public Format?: DateTimePickerFormat;
    public Min?: any;
    public Max?: any;
    public ShowCheckBox?: boolean;
}