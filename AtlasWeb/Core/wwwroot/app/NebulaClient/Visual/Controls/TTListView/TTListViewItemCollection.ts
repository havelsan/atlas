import { ITTListViewItem } from "../../ControlInterfaces/TTListView/ITTListViewItem";

export class TTListViewItemCollection {
    private _listViewItems: Array<ITTListViewItem> = new Array<ITTListViewItem>();
    private pointer = 0;

    public Add(item: ITTListViewItem): number {
        return this._listViewItems.push(item);
    }
    public IndexOf(item: ITTListViewItem): number {
        return this._listViewItems.indexOf(item);
    }
    public Insert(index: number, item: ITTListViewItem): void {
        this._listViewItems.splice(index, 0, item);
    }
    public Remove(item: ITTListViewItem): void {
        let itemIndex: number = this._listViewItems.indexOf(item);
        if (itemIndex != undefined) {
            if (itemIndex > -1)
                this._listViewItems.splice(itemIndex, 1);
        }
    }
    public next(): IteratorResult<ITTListViewItem> {
        if (this.pointer < this._listViewItems.length) {
            return {
                done: false,
                value: this._listViewItems[this.pointer++]
            };
        } else {
            return {
                done: true,
                value: null,
            };
        }
    }
  /*  public Add(text: string): ITTListViewItem {
        let listViewItem = new TTListViewItem();
        listViewItem.Text = text;
        this._listViewItems.push(listViewItem);
        return listViewItem;
    }
    Add(listViewItem: ITTListViewItem): ITTListViewItem {
        this._listViewItems.push(listViewItem);
        return listViewItem;
    }
    public $get$(i: number): ITTListViewItem {
        return <ITTListViewItem>this._listViewItems[i];
    }
    public $get$(name: string): ITTListViewItem {
        let listViewItem = this._listViewItems.Where(i => i.Name === name).FirstOrDefault();
        return listViewItem;
    }
    public get Count(): number {
        return this._listViewItems.length;
    }
    public Add(listViewItem: ITTListViewItem): number {
        this._listViewItems.push(listViewItem);
        return this._listViewItems.indexOf(listViewItem);
    }
    public Insert(index: number, listViewItem: ITTListViewItem): void {
        this._listViewItems.Insert(index, listViewItem);
    }
    public Remove(listViewItem: ITTListViewItem): void {
        this._listViewItems.Remove(listViewItem);
    }
    public RemoveAt(index: number): void {
        this._listViewItems.RemoveAt(index);
    }
    public Clear(): void {
        this._listViewItems.Clear();
    }
    public IndexOf(listViewItem: ITTListViewItem): number {
        return this._listViewItems.indexOf(listViewItem);
    }
    public GetEnumerator(): IEnumerator {
        return this._listViewItems.GetEnumerator();
    }
    Add(value: Object): number {
        return this.Add(<ITTListViewItem>value);
    }
    Contains(value: Object): boolean {
        return (<Array<any>>this._listViewItems).Contains(value);
    }
    IndexOf(value: Object): number {
        return (<Array<any>>this._listViewItems).indexOf(value);
    }
    Insert(index: number, value: Object): void {
        this.Insert(index, <ITTListViewItem>value);
    }
    get IsFixedSize(): boolean {
        return (<Array<any>>this._listViewItems).IsFixedSize;
    }
    get IsReadOnly(): boolean {
        return (<Array<any>>this._listViewItems).IsReadOnly;
    }
    Remove(value: Object): void {
        this.Remove(<ITTListViewItem>value);
    }
    get(index: number): Object {
        return null;
        //return (<Array<any>this.listViewItems)[index] = value;
    }
    public CopyTo(array: Array, index: number): void {
        (<ICollection>this._listViewItems).CopyTo(array, index);
    }
    public get IsSynchronized(): boolean {
        return (<ICollection>this._listViewItems).IsSynchronized;
    }
    public get SyncRoot(): Object {
        return (<ICollection>this._listViewItems).SyncRoot;
    } */
}