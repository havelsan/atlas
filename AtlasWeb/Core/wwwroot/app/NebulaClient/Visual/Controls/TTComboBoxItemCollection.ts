import { ITTComboBoxItem } from "../ControlInterfaces/ITTComboBoxItem";

export class TTComboBoxItemCollection  {
    private pointer = 0;
    private _comboBoxItems: Array<ITTComboBoxItem> = new Array<ITTComboBoxItem>();
    public get length(): number {
        return this._comboBoxItems.length;
    }
    public ContainsValue(item: ITTComboBoxItem | Object): boolean {
        let checkItem: ITTComboBoxItem = item as ITTComboBoxItem;
        if (checkItem == null)
            return false;
        return this._comboBoxItems.Contains(checkItem);
    }
    public Add(item: ITTComboBoxItem): number {
        return this._comboBoxItems.push(item);
    }
    public IndexOf(item: ITTComboBoxItem): number {
        return this._comboBoxItems.indexOf(item);
    }
    public Insert(index: number, item: ITTComboBoxItem): void {
        this._comboBoxItems.splice(index, 0, item);
    }
    public Remove(item: ITTComboBoxItem): void {
        let itemIndex: number = this._comboBoxItems.indexOf(item);
        if (itemIndex != undefined) {
            if (itemIndex > -1)
                this._comboBoxItems.splice(itemIndex, 1);
        }
    }
    public next(): IteratorResult<ITTComboBoxItem> {
        if (this.pointer < this._comboBoxItems.length) {
            return {
                done: false,
                value: this._comboBoxItems[this.pointer++]
            };
        } else {
            return {
                done: true,
                value: null,
            };
        }
    }
    /*
    public $get$(i: number): ITTComboBoxItem {
        return <TTVisual.ITTComboBoxItem>this._comboBoxItems[i];
    }
    public $set$(i: number, value: ITTComboBoxItem): void {
        this._comboBoxItems[i] = value;
    }
    public get Count(): number {
        return this._comboBoxItems.length;
    }
    public Add(gridColumn: TTVisual.ITTComboBoxItem): number {
        this._comboBoxItems.push(gridColumn);
        return this._comboBoxItems.indexOf(gridColumn);
    }
    public Insert(index: number, gridColumn: TTVisual.ITTComboBoxItem): void {
        this._comboBoxItems.Insert(index, gridColumn);
    }
    public Remove(gridColumn: TTVisual.ITTComboBoxItem): void {
        this._comboBoxItems.Remove(gridColumn);
    }
    public RemoveAt(index: number): void {
        this._comboBoxItems.RemoveAt(index);
    }
    public Clear(): void {
        this._comboBoxItems.Clear();
    }
    public IndexOf(gridColumn: TTVisual.ITTComboBoxItem): number {
        return this._comboBoxItems.indexOf(gridColumn);
    }
    public GetEnumerator(): IEnumerator {
        return this._comboBoxItems.GetEnumerator();
    }
    public CopyTo(array: Array, index: number): void {
        (<ICollection>this._comboBoxItems).CopyTo(array, index);
    }
    public Add(item: TTVisual.ITTComboBoxItem): void {
        this._comboBoxItems.push(item);
    }
    public Contains(item: TTVisual.ITTComboBoxItem): boolean {
        return this._comboBoxItems.Contains(item);
    }
    public CopyTo(array: TTVisual.ITTComboBoxItem[], arrayIndex: number): void {
        this._comboBoxItems.CopyTo(array, arrayIndex);
    }
    public Remove(item: TTVisual.ITTComboBoxItem): boolean {
        return this._comboBoxItems.Remove(item);
    }
    public GetEnumerator(): IEnumerator<ITTComboBoxItem> {
        return this._comboBoxItems.GetEnumerator();
    }
    public get IsSynchronized(): boolean {
        return (<ICollection>this._comboBoxItems).IsSynchronized;
    }
    public get SyncRoot(): Object {
        return (<ICollection>this._comboBoxItems).SyncRoot;
    }
    private _isReadonly: boolean;
    public get IsReadOnly(): boolean {
        return this._isReadonly;
    }*/
}