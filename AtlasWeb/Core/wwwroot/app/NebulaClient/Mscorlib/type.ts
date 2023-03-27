export class Type {
    private id: string;

    constructor(id: string) {
        this.id = id.toLowerCase();
    }

    valueOf() {
        return this.id;
    }
}