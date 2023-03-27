import { ITTToolStripItem } from "../../ControlInterfaces/TTToolStrip/ITTToolStripItem";

export class TTToolStripItemCollection {
    private pointer = 0;
    private _toolStripItems: Array<ITTToolStripItem> = new Array<ITTToolStripItem>();

    public Add(item: ITTToolStripItem): number {
        return this._toolStripItems.push(item);
    }
    public IndexOf(item: ITTToolStripItem): number {
        return this._toolStripItems.indexOf(item);
    }
    public Insert(index: number, item: ITTToolStripItem): void {
        this._toolStripItems.splice(index, 0, item);
    }
    public Remove(item: ITTToolStripItem): void {
        let itemIndex: number = this._toolStripItems.indexOf(item);
        if (itemIndex != undefined) {
            if (itemIndex > -1)
                this._toolStripItems.splice(itemIndex, 1);
        }
    }
    public next(): IteratorResult<ITTToolStripItem> {
        if (this.pointer < this._toolStripItems.length) {
            return {
                done: false,
                value: this._toolStripItems[this.pointer++]
            };
        } else {
            return {
                done: true,
                value: null,
            };
        }
    }
    /*public $get$(i: number): ITTToolStripItem {
        return <ITTToolStripItem>this._toolStripItems[i];
    }
    public $get$(name: string): ITTToolStripItem {
        let toolStripItem = this._toolStripItems.Where(i => i.Name === name).FirstOrDefault();
        return toolStripItem;
    }
    public get Count(): number {
        return this._toolStripItems.length;
    }
    public Add(toolStripItem: ITTToolStripItem): number {
        this._toolStripItems.push(toolStripItem);
        return this._toolStripItems.indexOf(toolStripItem);
    }
    public Insert(index: number, toolStripItem: ITTToolStripItem): void {
        this._toolStripItems.Insert(index, toolStripItem);
    }
    public Remove(toolStripItem: ITTToolStripItem): void {
        this._toolStripItems.Remove(toolStripItem);
    }
    public RemoveAt(index: number): void {
        this._toolStripItems.RemoveAt(index);
    }
    public Clear(): void {
        this._toolStripItems.Clear();
    }
    public IndexOf(toolStripItem: ITTToolStripItem): number {
        return this._toolStripItems.indexOf(toolStripItem);
    }
    public GetEnumerator(): IEnumerator {
        return this._toolStripItems.GetEnumerator();
    }
    Add(value: Object): number {
        return this.Add(<ITTToolStripItem>value);
    }
    Contains(value: Object): boolean {
        return (<Array<any>>this._toolStripItems).Contains(value);
    }
    IndexOf(value: Object): number {
        return (<Array<any>>this._toolStripItems).indexOf(value);
    }
    Insert(index: number, value: Object): void {
        this.Insert(index, <ITTToolStripItem>value);
    }
    get IsFixedSize(): boolean {
        return (<Array<any>>this._toolStripItems).IsFixedSize;
    }
    get IsReadOnly(): boolean {
        return (<Array<any>>this._toolStripItems).IsReadOnly;
    }
    Remove(value: Object): void {
        this.Remove(<ITTToolStripItem>value);
    }
    $get$(index: number): Object {
        return (<Array<any>>this._toolStripItems)[index];
    }
    $set$(index: number, value: Object): void {
        (<Array<any>>this._toolStripItems)[index] = value;
    }
    public CopyTo(array: Array, index: number): void {
        (<ICollection>this._toolStripItems).CopyTo(array, index);
    }
    public get IsSynchronized(): boolean {
        return (<ICollection>this._toolStripItems).IsSynchronized;
    }
    public get SyncRoot(): Object {
        return (<ICollection>this._toolStripItems).SyncRoot;
    }*/
}