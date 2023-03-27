export interface IItemArray<T> extends Iterator<T> {
    Add(item: T): number;
    IndexOf(item: T ): number;
    Insert(index: number, item: T): void;
    Remove(item: T): void;
}