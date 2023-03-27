import { Guid } from './Guid';

export class GuidParam {
    protected __type__ = 'Infrastructure.Models.GuidParam, Infrastructure';
    private paramValue: Guid;

    constructor(value?: Guid | string) {
        if (value != null) {
            if ((typeof value) === 'string') {
                this.paramValue = new Guid(<any>value as string);
            } else if (value instanceof Guid) {
                this.paramValue = value;
            }
        }
    }

    valueOf() {
        if (this.paramValue != null) {
            return this.paramValue.valueOf();
        }
        return undefined;
    }
}
