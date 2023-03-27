export class DecimalParam {
    protected __type__ = 'Infrastructure.Models.DecimalParam, Infrastructure';
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
