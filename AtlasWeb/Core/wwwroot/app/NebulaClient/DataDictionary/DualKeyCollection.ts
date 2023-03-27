import { TTUtils } from "../Utils/Collections/DualKeyCollection";
/*[Serializable]*/
export class DualKeyCollection<TKey1, TKey2, ItemType> extends TTUtils.Collections.DualKeyCollection<TKey1, TKey2, ItemType>
{
    public Add(key1: TKey1, key2: TKey2, item: ItemType): void {
        super.AddItem(key1, key2, item);
    }
    public Remove(key1: TKey1, key2: TKey2): void {
        super.RemoveItem(key1, key2);
    }
}