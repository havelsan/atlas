import {Validation} from './Validation';

export class RequiredValidation extends Validation {
    constructor(Message: String) {
        super(Message);
    }
    public IsValid(field: any): Boolean {
        if (typeof field === "string") {
            if (!field || field.trim().length == 0) {
                return false;
            }
        }
        return true;
    }
}