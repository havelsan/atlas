export class IntegerParam {
    protected __type__ = 'Infrastructure.Models.IntegerParam, Infrastructure';
    private paramValue: number;

    constructor(value?: number) {
        if (value != null) {
            this.paramValue = value;
        }
    }

    valueOf() {
        return this.paramValue;
    }

}
