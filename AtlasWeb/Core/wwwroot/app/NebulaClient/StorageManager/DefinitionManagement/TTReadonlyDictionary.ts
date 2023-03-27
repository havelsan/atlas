import { Dictionary } from "../../System/Collections/Dictionaries/Dictionary";
export class TTReadonlyDictionary<KeyType, ValueType>  {

private _dictionary: Dictionary<KeyType, ValueType>;

    public Count: number;
    //public Values: Dictionary.ValueCollection<KeyType, ValueType>;
    // public Keys: Dictionary.KeyCollection<KeyType, ValueType>;
    public ContainsKey(key: KeyType): boolean {
        return this._dictionary.containsKey(key);
    }
}
