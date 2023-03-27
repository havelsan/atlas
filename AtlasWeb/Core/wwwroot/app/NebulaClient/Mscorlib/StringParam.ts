export class StringParam {
    protected __type__ = 'Infrastructure.Models.StringParam, Infrastructure';
    private paramValue: string;

    constructor(value?: string) {
        if (value != null) {
            this.paramValue = value;
        }
    }

    valueOf() {
        return this.paramValue;
    }
}
