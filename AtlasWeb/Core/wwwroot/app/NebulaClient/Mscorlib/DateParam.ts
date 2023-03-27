export class DateParam {
    protected __type__ = 'Infrastructure.Models.DateParam, Infrastructure';
    private paramValue: Date;

    constructor(value?: Date) {
        if (value != null) {
            this.paramValue = value;
        }
    }

    valueOf() {
        return this.paramValue;
    }

}
