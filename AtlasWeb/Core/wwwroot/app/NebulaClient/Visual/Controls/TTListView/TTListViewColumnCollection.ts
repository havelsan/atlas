import { ITTListViewColumn } from "../../ControlInterfaces/TTListView/ITTListViewColumn";

export class TTListViewColumnCollection  {
    private _listViewColumns: Array<ITTListViewColumn> = new Array<ITTListViewColumn>();
    private pointer = 0;
    public Add(item: ITTListViewColumn): number {
        return this._listViewColumns.push(item);
    }
    public IndexOf(item: ITTListViewColumn): number {
        return this._listViewColumns.indexOf(item);
    }
    public Insert(index: number, item: ITTListViewColumn): void {
        this._listViewColumns.splice(index, 0, item);
    }

    public Remove(item: ITTListViewColumn): void {
        let itemIndex: number = this._listViewColumns.indexOf(item);
        if (itemIndex != undefined) {
            if (itemIndex > -1)
                this._listViewColumns.splice(itemIndex, 1);
        }
    }
    public next(): IteratorResult<ITTListViewColumn> {
        if (this.pointer < this._listViewColumns.length) {
            return {
                done: false,
                value: this._listViewColumns[this.pointer++]
            };
        } else {
            return {
                done: true,
                value: null,
            };
        }
    }
    /*
    public Add(text: string): ITTListViewColumn {
        let listViewColumn = new TTListViewColumn();
        listViewColumn.Text = text;
        this._listViewColumns.push(listViewColumn);
        return listViewColumn;
    }
    public Add(text: string, width: number): ITTListViewColumn {
        let listViewColumn = new TTListViewColumn();
        listViewColumn.Text = text;
        listViewColumn.Width = width;
        this._listViewColumns.push(listViewColumn);
        return listViewColumn;
    }
    public Add(text: string, width: number, textAlign: HorizontalAlignment): ITTListViewColumn {
        let listViewColumn = new TTListViewColumn();
        listViewColumn.Text = text;
        listViewColumn.Width = width;
        listViewColumn.TextAlign = textAlign;
        this._listViewColumns.push(listViewColumn);
        return listViewColumn;
    }
    public $get$(i: number): ITTListViewColumn {
        return <ITTListViewColumn>this._listViewColumns[i];
    }
    public $get$(name: string): ITTListViewColumn {
        let listViewColumn = this._listViewColumns.Where(i => i.Name === name).FirstOrDefault();
        return listViewColumn;
    }
    public get Count(): number {
        return this._listViewColumns.length;
    }
    public Add(listViewColumn: ITTListViewColumn): number {
        this._listViewColumns.push(listViewColumn);
        return this._listViewColumns.indexOf(listViewColumn);
    }
    public Insert(index: number, listViewColumn: ITTListViewColumn): void {
        this._listViewColumns.Insert(index, listViewColumn);
    }
    public Remove(listViewItem: ITTListViewColumn): void {
        this._listViewColumns.Remove(listViewItem);
    }
    public RemoveAt(index: number): void {
        this._listViewColumns.RemoveAt(index);
    }
    public Clear(): void {
        this._listViewColumns.Clear();
    }
    public IndexOf(listViewItem: ITTListViewColumn): number {
        return this._listViewColumns.indexOf(listViewItem);
    }
    public GetEnumerator(): IEnumerator {
        return this._listViewColumns.GetEnumerator();
    }
    Add(value: Object): number {
        return this.Add(<ITTListViewColumn>value);
    }
    Contains(value: Object): boolean {
        return (<Array<any>>this._listViewColumns).Contains(value);
    }
    IndexOf(value: Object): number {
        return (<Array<any>>this._listViewColumns).indexOf(value);
    }
    Insert(index: number, value: Object): void {
        this.Insert(index, <ITTListViewColumn>value);
    }
    get IsFixedSize(): boolean {
        return (<Array<any>>this._listViewColumns).IsFixedSize;
    }
    get IsReadOnly(): boolean {
        return (<Array<any>>this._listViewColumns).IsReadOnly;
    }
    Remove(value: Object): void {
        this.Remove(<ITTListViewColumn>value);
    }
    $get$(index: number): Object {
        return (<Array<any>>this._listViewColumns)[index];
    }
    $set$(index: number, value: Object): void {
        (<Array<any>>this._listViewColumns)[index] = value;
    }
    public CopyTo(array: Array, index: number): void {
        (<ICollection>this._listViewColumns).CopyTo(array, index);
    }
    public get IsSynchronized(): boolean {
        return (<ICollection>this._listViewColumns).IsSynchronized;
    }
    public get SyncRoot(): Object {
        return (<ICollection>this._listViewColumns).SyncRoot;
    }*/
}