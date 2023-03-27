import { Guid } from './Guid';

export class ArrayParam {
    protected __type__ = 'Infrastructure.Models.ArrayParam, Infrastructure';
    private paramValue: Array<Object>;

    constructor(value?: Array<Object>) {
        if (value != null) {
            this.paramValue = value;
        }
    }

    valueOf() {
        if (this.paramValue != null) {
            return this.paramValue;
        }
        return undefined;
    }
}
