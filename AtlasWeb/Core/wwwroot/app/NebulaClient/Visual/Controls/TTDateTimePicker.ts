import { TTControl } from './TTControl';
import { ITTDateTimePicker } from '../ControlInterfaces/ITTDateTimePicker';
import { DateTimePickerFormat } from '../../Utils/Enums/DateTimePickerFormat';

export class TTDateTimePicker extends TTControl implements ITTDateTimePicker {
    public CustomFormat: string;
    public Format: DateTimePickerFormat;
    public NullableValue: Date;
    public get ControlValue() {
        return this.NullableValue;
    }
    public set ControlValue(value: any) {
        this.NullableValue = value;
    }
    public Min?: any;
    public Max?: any;
}