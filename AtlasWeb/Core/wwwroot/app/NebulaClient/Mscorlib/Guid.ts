
export class Guid {

    private static emptyGuid = new Guid('00000000-0000-0000-0000-000000000000');
    public static get Empty(): Guid {
        return Guid.emptyGuid;
    }

    public id: string;

    public static empty() {
        return Guid.emptyGuid;
    }

    public static newGuid() {
        return new Guid(
            Guid.s4() + Guid.s4() + '-' + Guid.s4() + '-' + Guid.s4() + '-' +
            Guid.s4() + '-' + Guid.s4() + Guid.s4() + Guid.s4()
        );
    }

    public static regex(format?: string) {
        switch (format) {
            case 'x':
            case 'X':
                return (/\{[a-z0-9]{8}(?:-[a-z0-9]{4}){3}-[a-z0-9]{12}\}/i);

            default:
                return (/[a-z0-9]{8}(?:-[a-z0-9]{4}){3}-[a-z0-9]{12}/i);
        }
    }

    private static s4() {
        return Math
            .floor((1 + Math.random()) * 0x10000)
            .toString(16)
            .substring(1);
    }

    constructor(value?: string | Guid) {

        if (value != null) {
            if (value instanceof Guid) {
                this.id = (<Guid>value).id;
            } else {
                this.id = (<string>value).toLowerCase();
            }
        }
    }

    toString(format?: string) {
        switch (format) {
            case 'x':
            case 'X':
                return '{' + this.id + '}';
        }
        return this.id;
    }

    valueOf() {
        return this.id;
    }

    Equals(source: Guid): boolean {
        return this.id === source.id;
    }

    toJSON() {
        return this.valueOf();
    }
}
