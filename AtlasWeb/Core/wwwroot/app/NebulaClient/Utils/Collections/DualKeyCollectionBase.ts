import { IDictionary } from "../../System/Collections/Dictionaries/IDictionary";
import { Exception } from "../../System/Exception";
import { ArgumentException } from "../../System/Exceptions/ArgumentException";
/*[Serializable]*/
export class DualKeyCollectionBase<TKey1, TKey2>
{
    protected __dictByKey1: IDictionary<TKey1, Object>;
    protected __dictByKey2: IDictionary<TKey2, Object>;

    protected GetItemByKey1(key: TKey1): Object {
        if (false === this.__dictByKey1.containsKey(key)) {
            let message: string = `Object with key1 ${key} not found.`;
            throw new Exception(message);
        }
        return this.__dictByKey1.getValue(key);
    }
    protected GetItemByKey2(key: TKey2): Object {
        if (false === this.__dictByKey2.containsKey(key)) {
            let message: string = `Object with key2 ${key} not found.`;
            throw new Exception(message);
        }
        return this.__dictByKey2.getValue(key);
    }
    public get Count(): number {
        return this.__dictByKey2.count;
    }
    public ContainsKey1(key: TKey1): boolean {
        return this.__dictByKey1.containsKey(key);
    }
    public ContainsKey2(key: TKey2): boolean {
        return this.__dictByKey2.containsKey(key);
    }
    constructor() {

    }
    protected RemoveItem(key1: TKey1, key2: TKey2): boolean {
        if (false === this.__dictByKey1.containsKey(key1))
            return false;
        if (false === this.__dictByKey2.containsKey(key2))
            return false;
        let ttObject: Object = this.__dictByKey1.getValue(key1);
        if (false === (ttObject === this.__dictByKey2.getValue(key2)))
            return false;
        this.__dictByKey1.removeByKey(key1);
        this.__dictByKey2.removeByKey(key2);
        return true;
    }
    protected AddItem(key1: TKey1, key2: TKey2, item: Object): void {
        try {
            this.__dictByKey1.addByKeyValue(key1, item);
        }
        catch (err) {
            let message: string = `Object with key ${key1} already exists.`;
            throw new ArgumentException(message);
        }

        try {
            this.__dictByKey2.addByKeyValue(key2, item);
        }
        catch (err) {
            this.__dictByKey1.removeByKey(key1);
            let message: string = `Object with key ${key2} already exists.`;
            throw new ArgumentException(message);
        }

    }
    protected ClearItems(): void {
        this.__dictByKey1.clear();
        this.__dictByKey2.clear();
    }
}