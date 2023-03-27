import { DualKeyCollectionBase } from "./DualKeyCollectionBase";
import { IDictionary } from "../../System/Collections/Dictionaries/IDictionary";
import { Dictionary } from "../../System/Collections/Dictionaries/Dictionary";

export namespace TTUtils {
    export namespace Collections {
        /*[Serializable]*/
        export class DualKeyCollection<TKey1, TKey2, ItemType> extends DualKeyCollectionBase<TKey1, TKey2>
        {
            private _dictByKey1: Dictionary<TKey1, ItemType>;
            private _dictByKey2: Dictionary<TKey2, ItemType>;

            protected get __dictByKey1(): IDictionary<TKey1, ItemType> {
                return this._dictByKey1;
            }
            protected get __dictByKey2(): IDictionary<TKey2, ItemType> {
                return this._dictByKey2;
            }
            public get Values(): ItemType[] {
                return this._dictByKey1.values;
            }
            public get Keys1(): TKey1[] {
                return this._dictByKey1.keys;
            }
            public get Keys2(): TKey2[] {
                return this._dictByKey2.keys;
            }
            constructor() {
                super();
                this._dictByKey1 = new Dictionary<TKey1, ItemType>();
                this._dictByKey2 = new Dictionary<TKey2, ItemType>();
            }
            public Add(key1: TKey1, key2: TKey2, item: ItemType): void {
                super.AddItem(key1, key2, item);
            }
            public Remove(key1: TKey1, key2: TKey2): void {
                super.RemoveItem(key1, key2);
            }
        }
    }
}