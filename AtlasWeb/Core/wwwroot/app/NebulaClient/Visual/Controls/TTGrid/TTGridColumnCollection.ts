import { ITTGridColumn } from "../../ControlInterfaces/TTGrid/Columns/ITTGridColumn";
import { ITTGrid } from "../../ControlInterfaces/TTGrid/ITTGrid";

export class TTGridColumnCollection {
    private pointer = 0;
    public TTGrid: ITTGrid;
    private _gridColumns: Array<ITTGridColumn> = new Array<ITTGridColumn>();
    public ContainsValue(item: ITTGridColumn | Object): boolean {
        let checkItem: ITTGridColumn = item as ITTGridColumn;
        if (checkItem == null)
            return false;
        return this._gridColumns.Contains(checkItem);
    }
    public Contains(name: string): boolean {
        let checkItem: ITTGridColumn = this._gridColumns.find(c => c.Name === name);
        return checkItem != null;
    }

    public Add(item: ITTGridColumn): number {
        return this._gridColumns.push(item);
    }
    public IndexOf(item: ITTGridColumn): number {
        return this._gridColumns.indexOf(item);
    }
    public Insert(index: number, item: ITTGridColumn): void {
        this._gridColumns.splice(index, 0, item);
    }
    public next(): IteratorResult<ITTGridColumn> {
        if (this.pointer < this._gridColumns.length) {
            return {
                done: false,
                value: this._gridColumns[this.pointer++]
            };
        } else {
            return {
                done: true,
                value: null,
            };
        }
    }
    public RemoveByName(name: string): boolean {
        let removeItem: ITTGridColumn = this._gridColumns.find(c => c.Name === name);

        let itemIndex: number = this._gridColumns.indexOf(removeItem);
        if (itemIndex != undefined) {
            if (itemIndex > -1) {
                this._gridColumns.splice(itemIndex, 1);
                return true;
            }
        }

        return false;
    }

    public Remove(item: ITTGridColumn): void {
        let itemIndex: number = this._gridColumns.indexOf(item);
        if (itemIndex != undefined) {
            if (itemIndex > -1)
                this._gridColumns.splice(itemIndex, 1);
        }
    }
    /*public get(i: number): ITTGridColumn {
        return <ITTGridColumn>this._gridColumns[i];
    }
    public get2(name: string): ITTGridColumn {
        let gridColumnItem = this._gridColumns.find(i => i.Name === name);
        return gridColumnItem;
    }
    public get Count(): number {
        return this._gridColumns.length;
    }
    public Add(gridColumn: ITTGridColumn | Object): number {
        let newGridColumn : ITTGridColumn = gridColumn as ITTGridColumn;
        this._gridColumns.push(newGridColumn);
        return this._gridColumns.indexOf(newGridColumn);
    }
    public Insert(index: number, gridColumn: ITTGridColumn | Object): void {
        let newGridColumn : ITTGridColumn = gridColumn as ITTGridColumn;
        this._gridColumns.splice(index, 0, newGridColumn);
    }
    public Remove(gridColumn: ITTGridColumn | Object): void {
        let targetGridColumn : ITTGridColumn = gridColumn as ITTGridColumn;
        let index : number = this._gridColumns.indexOf(targetGridColumn);
        this._gridColumns.splice(index, 1);
    }
    public RemoveAt(index: number): void {
        this._gridColumns.RemoveAt(index);
    }
    public Clear(): void {
        this._gridColumns.Clear();
    }
    public IndexOf(gridColumn: ITTGridColumn): number {
        return this._gridColumns.indexOf(gridColumn);
    }
    public GetEnumerator(): IEnumerator {
        return this._gridColumns.GetEnumerator();
    }
    public Contains(value: Object): boolean {
        return (<Array<any>>this._gridColumns).Contains(value);
    }
    public IndexOf(value: Object): number {
        return (<Array<any>>this._gridColumns).indexOf(value);
    }
    get IsFixedSize(): boolean {
        return (<Array<any>>this._gridColumns).IsFixedSize;
    }
    get IsReadOnly(): boolean {
        return (<Array<any>>this._gridColumns).IsReadOnly;
    }
    get3(index: number): Object {
        return (<Array<any>>this._gridColumns)[index];
    }
    set(index: number, value: Object): void {
        (<Array<any>>this._gridColumns)[index] = value;
    }

    public CopyTo(array: Array, index: number): void {
        (<ICollection>this._gridColumns).CopyTo(array, index);
    }
    public Contains(name: string): boolean {
        let gridColumnItem = this._gridColumns.Where(c => c.Name === name).FirstOrDefault();
        return gridColumnItem !== null;
    }
    public RemoveByName(name: string): boolean {
        let gridColumnItem = this._gridColumns.Where(c => c.Name === name).FirstOrDefault();
        if (gridColumnItem !== null) {
            this._gridColumns.Remove(gridColumnItem);
            return true;
        }
        return false;
    }
    public get IsSynchronized(): boolean {
        return (<ICollection>this._gridColumns).IsSynchronized;
    }
    public get SyncRoot(): Object {
        return (<ICollection>this._gridColumns).SyncRoot;
    }*/
}