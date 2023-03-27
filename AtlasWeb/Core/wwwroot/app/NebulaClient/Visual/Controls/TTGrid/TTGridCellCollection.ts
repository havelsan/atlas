import { ITTGridCell } from "../../ControlInterfaces/TTGrid/ITTGridCell";

export class TTGridCellCollection {
    private pointer = 0;
    private _cellList: Array<ITTGridCell> = new Array<ITTGridCell>();

    public Add(item: ITTGridCell): number {
        return this._cellList.push(item);
    }
    public IndexOf(item: ITTGridCell): number {
        return this._cellList.indexOf(item);
    }
    public Insert(index: number, item: ITTGridCell): void {
        this._cellList.splice(index, 0, item);
    }
    public Remove(item: ITTGridCell): void {
        let itemIndex: number = this._cellList.indexOf(item);
        if (itemIndex != undefined) {
            if (itemIndex > -1)
                this._cellList.splice(itemIndex, 1);
        }
    }
    public next(): IteratorResult<ITTGridCell> {
        if (this.pointer < this._cellList.length) {
            return {
                done: false,
                value: this._cellList[this.pointer++]
            };
        } else {
            return {
                done: true,
                value: null,
            };
        }
    }
}