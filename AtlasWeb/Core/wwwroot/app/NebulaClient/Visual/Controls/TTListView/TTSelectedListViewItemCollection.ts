import { ITTListViewItem } from "../../ControlInterfaces/TTListView/ITTListViewItem";

export class TTSelectedListViewItemCollection {
    private pointer = 0;
    private _selectedListViewItems: Array<ITTListViewItem> = new Array<ITTListViewItem>();
    public Add(item: ITTListViewItem): number {
        return this._selectedListViewItems.push(item);
    }
    public IndexOf(item: ITTListViewItem): number {
        return this._selectedListViewItems.indexOf(item);
    }
    public Insert(index: number, item: ITTListViewItem): void {
        this._selectedListViewItems.splice(index, 0, item);
    }
    public Remove(item: ITTListViewItem): void {
        let itemIndex: number = this._selectedListViewItems.indexOf(item);
        if (itemIndex != undefined) {
            if (itemIndex > -1)
                this._selectedListViewItems.splice(itemIndex, 1);
        }
    }
    public next(): IteratorResult<ITTListViewItem> {
        if (this.pointer < this._selectedListViewItems.length) {
            return {
                done: false,
                value: this._selectedListViewItems[this.pointer++]
            };
        } else {
            return {
                done: true,
                value: null,
            };
        }
    }
    /* public Add(text: string): ITTListViewItem {
         let listViewItem = new TTListViewItem();
         listViewItem.Text = text;
         this._selectedListViewItems.push(listViewItem);
         return listViewItem;
     }
     public $get$(i: number): ITTListViewItem {
         return <ITTListViewItem>this._selectedListViewItems[i];
     }
     public $get$(name: string): ITTListViewItem {
         let listViewItem = this._selectedListViewItems.Where(i => i.Name === name).FirstOrDefault();
         return listViewItem;
     }
     public get Count(): number {
         return this._selectedListViewItems.length;
     }
     public Add(listViewItem: ITTListViewItem): number {
         this._selectedListViewItems.push(listViewItem);
         return this._selectedListViewItems.indexOf(listViewItem);
     }
     public Insert(index: number, listViewItem: ITTListViewItem): void {
         this._selectedListViewItems.Insert(index, listViewItem);
     }
     public Remove(listViewItem: ITTListViewItem): void {
         this._selectedListViewItems.Remove(listViewItem);
     }
     public RemoveAt(index: number): void {
         this._selectedListViewItems.RemoveAt(index);
     }
     public Clear(): void {
         this._selectedListViewItems.Clear();
     }
     public IndexOf(listViewItem: ITTListViewItem): number {
         return this._selectedListViewItems.indexOf(listViewItem);
     }
     public GetEnumerator(): IEnumerator {
         return this._selectedListViewItems.GetEnumerator();
     }
     Add(value: Object): number {
         return this.Add(<ITTListViewItem>value);
     }
     Contains(value: Object): boolean {
         return (<Array<any>>this._selectedListViewItems).Contains(value);
     }
     IndexOf(value: Object): number {
         return (<Array<any>>this._selectedListViewItems).indexOf(value);
     }
     Insert(index: number, value: Object): void {
         this.Insert(index, <ITTListViewItem>value);
     }
     get IsFixedSize(): boolean {
         return (<Array<any>>this._selectedListViewItems).IsFixedSize;
     }
     get IsReadOnly(): boolean {
         return (<Array<any>>this._selectedListViewItems).IsReadOnly;
     }
     Remove(value: Object): void {
         this.Remove(<ITTListViewItem>value);
     }
     $get$(index: number): Object {
         return (<Array<any>>this._selectedListViewItems)[index];
     }
     $set$(index: number, value: Object): void {
         (<Array<any>>this._selectedListViewItems)[index] = value;
     }
     public CopyTo(array: Array, index: number): void {
         (<ICollection>this._selectedListViewItems).CopyTo(array, index);
     }
     public get IsSynchronized(): boolean {
         return (<ICollection>this._selectedListViewItems).IsSynchronized;
     }
     public get SyncRoot(): Object {
         return (<ICollection>this._selectedListViewItems).SyncRoot;
     }*/
}