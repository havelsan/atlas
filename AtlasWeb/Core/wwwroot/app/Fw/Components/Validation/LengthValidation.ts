import {Validation} from './Validation';

export class LengthValidation extends Validation {
    constructor(Message: String,
        private Min: Number,
        private Max: Number) {
        super(Message);
    }

    public IsValid(field: any): Boolean {
        if (!field) {
            return false;
        }
        let strField = field.toString();
        //if (typeof field === "string") {
        return strField && strField.length >= this.Min && strField.length <= this.Max;
        //}
    }
}