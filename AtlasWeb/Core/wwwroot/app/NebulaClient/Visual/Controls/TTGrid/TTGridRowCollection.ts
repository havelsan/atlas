import { ITTGridRow } from "../../ControlInterfaces/TTGrid/ITTGridRow";

export class TTGridRowCollection  {
    private pointer = 0;
    private _gridRows: Array<ITTGridRow> = new Array<ITTGridRow>();
    public Add(item: ITTGridRow): number {
        return this._gridRows.push(item);
    }
    public IndexOf(item: ITTGridRow): number {
        return this._gridRows.indexOf(item);
    }
    public Insert(index: number, item: ITTGridRow): void {
        this._gridRows.splice(index, 0, item);
    }

    public Remove(item: ITTGridRow): void {
        let itemIndex: number = this._gridRows.indexOf(item);
        if (itemIndex != undefined) {
            if (itemIndex > -1)
                this._gridRows.splice(itemIndex, 1);
        }
    }
    [Symbol.iterator](): IterableIterator<ITTGridRow> {
        return this;
    }
    public next(): IteratorResult<ITTGridRow> {
        if (this.pointer < this._gridRows.length) {
            return {
                done: false,
                value: this._gridRows[this.pointer++]
            };
        } else {
            return {
                done: true,
                value: null,
            };
        }
    }
}