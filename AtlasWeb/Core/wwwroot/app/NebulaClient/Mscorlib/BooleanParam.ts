export class BooleanParam {
    protected __type__ = 'Infrastructure.Models.BooleanParam, Infrastructure';
    private paramValue: boolean;

    constructor(value?: boolean) {
        if (value != null) {
            this.paramValue = value;
        }
    }

    valueOf() {
        return this.paramValue;
    }
}
