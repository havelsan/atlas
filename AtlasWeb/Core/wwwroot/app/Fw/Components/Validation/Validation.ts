export abstract class Validation {
    constructor(public ErrorMessage: String) {
    }

    public abstract IsValid(field: any): Boolean;
}