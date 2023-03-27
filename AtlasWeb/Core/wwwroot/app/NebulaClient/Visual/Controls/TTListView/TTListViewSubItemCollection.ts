import { ITTListViewSubItem } from "../../ControlInterfaces/TTListView/ITTListViewSubItem";

export class TTListViewSubItemCollection  {
    private _listViewSubItems: Array<ITTListViewSubItem> = new Array<ITTListViewSubItem>();
    private pointer = 0;
    public Add(item: ITTListViewSubItem): number {
        return this._listViewSubItems.push(item);
    }
    public IndexOf(item: ITTListViewSubItem): number {
        return this._listViewSubItems.indexOf(item);
    }
    public Insert(index: number, item: ITTListViewSubItem): void {
        this._listViewSubItems.splice(index, 0, item);
    }
    public Remove(item: ITTListViewSubItem): void {
        let itemIndex: number = this._listViewSubItems.indexOf(item);
        if (itemIndex != undefined) {
            if (itemIndex > -1)
                this._listViewSubItems.splice(itemIndex, 1);
        }
    }
    public next(): IteratorResult<ITTListViewSubItem> {
        if (this.pointer < this._listViewSubItems.length) {
            return {
                done: false,
                value: this._listViewSubItems[this.pointer++]
            };
        } else {
            return {
                done: true,
                value: null,
            };
        }
    }
    /* public Add(text: string): ITTListViewSubItem {
         let listViewSubItem = new TTListViewSubItem();
         listViewSubItem.Text = text;
         this._listViewSubItems.push(listViewSubItem);
         return listViewSubItem;
     }
     Add(listViewSubItem: ITTListViewSubItem): ITTListViewSubItem {
         this._listViewSubItems.push(listViewSubItem);
         return listViewSubItem;
     }
     public $get$(i: number): ITTListViewSubItem {
         return <ITTListViewSubItem>this._listViewSubItems[i];
     }
     public $get$(name: string): ITTListViewSubItem {
         let listViewSubItem = this._listViewSubItems.Where(i => i.Name === name).FirstOrDefault();
         return listViewSubItem;
     }
     public get Count(): number {
         return this._listViewSubItems.length;
     }
     public Add(listViewSubItem: ITTListViewSubItem): number {
         this._listViewSubItems.push(listViewSubItem);
         return this._listViewSubItems.indexOf(listViewSubItem);
     }
     public Insert(index: number, listViewSubItem: ITTListViewSubItem): void {
         this._listViewSubItems.Insert(index, listViewSubItem);
     }
     public Remove(listViewSubItem: ITTListViewSubItem): void {
         this._listViewSubItems.Remove(listViewSubItem);
     }
     public RemoveAt(index: number): void {
         this._listViewSubItems.RemoveAt(index);
     }
     public Clear(): void {
         this._listViewSubItems.Clear();
     }
     public IndexOf(listViewSubItem: ITTListViewSubItem): number {
         return this._listViewSubItems.indexOf(listViewSubItem);
     }
     public GetEnumerator(): IEnumerator {
         return this._listViewSubItems.GetEnumerator();
     }
     Add(value: Object): number {
         return this.Add(<ITTListViewSubItem>value);
     }
     Contains(value: Object): boolean {
         return (<Array<any>>this._listViewSubItems).Contains(value);
     }
     IndexOf(value: Object): number {
         return (<Array<any>>this._listViewSubItems).indexOf(value);
     }
     Insert(index: number, value: Object): void {
         this.Insert(index, <ITTListViewSubItem>value);
     }
     get IsFixedSize(): boolean {
         return (<Array<any>>this._listViewSubItems).IsFixedSize;
     }
     get IsReadOnly(): boolean {
         return (<Array<any>>this._listViewSubItems).IsReadOnly;
     }
     Remove(value: Object): void {
         this.Remove(<ITTListViewSubItem>value);
     }
     $get$(index: number): Object {
         return (<Array<any>>this._listViewSubItems)[index];
     }
     $set$(index: number, value: Object): void {
         (<Array<any>>this._listViewSubItems)[index] = value;
     }
      public CopyTo(array: Array, index: number): void {
         (<ICollection>this._listViewSubItems).CopyTo(array, index);
     }
     public get IsSynchronized(): boolean {
         return (<ICollection>this._listViewSubItems).IsSynchronized;
     }
     public get SyncRoot(): Object {
         return (<ICollection>this._listViewSubItems).SyncRoot;
     }*/
}