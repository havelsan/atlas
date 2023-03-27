import { ListPropertyDefAccessEnum } from '../Utils/Enums/ListPropertyDefAccessEnum';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { ModalInfo } from 'Fw/Models/ModalInfo';

export class MultiSelectForm {
    public selectedData: any = null;
    MSSelectedItemObject: any;
    _storageItems: Array<any>;
    _storageItemsDict: Map<string, string>;
    _MSItemStorage: any;
    _MSItemDictionaryStorage: Map<string, string>;
    MSSelectedItems: Array<any>;
    MSSelectedItem: string;
    MSSelectedItemObjects: Array<any>;
    _isMultiSelect: boolean = false;

    constructor() {
        this.MSSelectedItem = '';
        this._storageItems = new Array<any>();
        this._storageItemsDict = new Map<string, string>();
        this._MSItemDictionaryStorage = new Map<string, string>();
        this.MSSelectedItems = new Array<any>();
        this.MSSelectedItemObjects = new Array<any>();
        //this.MSSelectedItemObject = any;
    }
    private _accessType: ListPropertyDefAccessEnum;
    public get AccessType(): ListPropertyDefAccessEnum {
        return this._accessType;
    }

    public set AccessType(value: ListPropertyDefAccessEnum) {
        this._accessType = value;
    }

    set IsMultiSelect(value: boolean) {
        this._isMultiSelect = value;
        let isMultiSelect: boolean = this._isMultiSelect;
    }

    get IsMultiSelect(): boolean {
        return this._isMultiSelect;
    }

    AddMSItem(item: string, Key: string): void;
    AddMSItem(item: string, Key: string, itemObject: any): void;
    AddMSItem(item: string, Key: string, itemObject?: any): void {
        if (arguments.length === 2 && (item === null || item.constructor === String) && (Key === null || Key.constructor === String)) {
            this.AddMSItem_0(item, Key);
            return;
        }
        this.AddMSItem_1(item, Key, itemObject);
    }

    private AddMSItem_0(item: string, Key: string): void {
        let flag: boolean = !this.IsItemExists(Key);
        if (flag) {
            this._storageItems.push(new MultiSelectForm_StorageItem(item, Key, null));
        }
        this.AddToDictionary(Key, item);
    }

    private AddMSItem_1(item: string, Key: string, itemObject: any): void {
        let flag: boolean = !this.IsItemExists(Key);
        if (flag) {
            this._storageItems.push(new MultiSelectForm_StorageItem(item, Key, itemObject));
        }
        this.AddToDictionary(Key, item);
    }

    AddToDictionary(Key: string, item: string): void {
        let flag: boolean = !this.IsItemExists(Key);
        if (flag) {
            this._storageItemsDict.set(Key, item);
        }
    }

    GetMSItemKey(index: number): any {
        let flag: boolean = index >= 0 && this._storageItems.length < index;
        let result: any;
        if (flag) {
            result = this._storageItems[index].MSKey;
        } else {
            result = null;
        }
        return result;
    }

    RemoveFromDictionary(Key: string): void {
        this._storageItemsDict.delete(Key);
    }

    GetMSItemObject(key: string): Object {
        return this._storageItemsDict.get(key);
    }

    DeleteMSItem(Key: string): void {
        this.RemoveFromDictionary(Key);
    }

    GetMSItemCount(): number {
        return this._storageItems.length;
    }

    ClearMSItems(): void {
        this._storageItems = new Array<any>();
        this._storageItemsDict = new Map<string, string>();
    }

    SaveMsItems(): void {
        this._MSItemStorage = this._storageItems;
        this._MSItemDictionaryStorage = this._storageItemsDict;
        this.ClearMSItems();
    }

    RestoreMsItems(): void {
        this._storageItems = this._MSItemStorage;
        this._storageItemsDict = this._MSItemDictionaryStorage;
    }

    IsItemExists(Key: string): boolean {
        if (this._storageItemsDict.get(Key) != null) {
            return true;
        } else {
            return false;
        }
    }

    GetMSItem(parent: Object, windowCaption: string): Promise<string>;
    GetMSItem(parent: Object, windowCaption: string, AutoSelect: boolean): Promise<string>;
    GetMSItem(parent: Object, windowCaption: string, AutoSelect: boolean, QAccess: boolean): Promise<string>;
    GetMSItem(parent: Object, windowCaption: string, AutoSelect: boolean, QAccess: boolean, MultiSelect: boolean): Promise<string>;
    GetMSItem(parent: Object, windowCaption: string, AutoSelect: boolean, QAccess: boolean, MultiSelect: boolean, DeleteAllowed: boolean): Promise<string>;
    GetMSItem(parent: Object, windowCaption: string, AutoSelect: boolean, QAccess: boolean, MultiSelect: boolean, DeleteAllowed: boolean, Sorted: boolean): Promise<string>;
    GetMSItem(parent: Object, windowCaption: string, AutoSelect: boolean, QAccess: boolean, MultiSelect: boolean, DeleteAllowed: boolean, Sorted: boolean, ForceToChoose: boolean): Promise<string>;
    GetMSItem(parent: Object, windowCaption: string, AutoSelect: boolean, QAccess: boolean, MultiSelect: boolean, DeleteAllowed: boolean, CommandCaption: string, CancelCap: string, QAccessStartWith: string, Sorted: boolean, ForceToChoose: boolean): Promise<string>;
    GetMSItem(parent: Object, windowCaption: string, AutoSelect?: boolean, QAccess?: boolean, MultiSelect?: boolean, DeleteAllowed?: boolean, SortedOrCommandCaption?: any, ForceToChooseOrCancelCap?: any, QAccessStartWith?: string, Sorted?: boolean, ForceToChoose?: boolean): Promise<string> {
        if (arguments.length === 2 && (parent === null || parent instanceof Object) && (windowCaption === null || windowCaption.constructor === String)) {
            return this.GetMSItem_0(parent, windowCaption);
        }
        if (arguments.length === 3 && (parent === null || parent instanceof Object)
            && (windowCaption === null || windowCaption.constructor === String) && (AutoSelect === null || AutoSelect.constructor === Boolean)) {
            return this.GetMSItem_1(parent, windowCaption, AutoSelect);
        }
        if (arguments.length === 4 && (parent === null || parent instanceof Object)
            && (windowCaption === null || windowCaption.constructor === String) && (AutoSelect === null || AutoSelect.constructor === Boolean)
            && (QAccess === null || QAccess.constructor === Boolean)) {
            return this.GetMSItem_2(parent, windowCaption, AutoSelect, QAccess);
        }
        if (arguments.length === 5 && (parent === null || parent instanceof Object)
            && (windowCaption === null || windowCaption.constructor === String) && (AutoSelect === null || AutoSelect.constructor === Boolean)
            && (QAccess === null || QAccess.constructor === Boolean) && (MultiSelect === null || MultiSelect.constructor === Boolean)) {
            return this.GetMSItem_3(parent, windowCaption, AutoSelect, QAccess, MultiSelect);
        }
        if (arguments.length === 6 && (parent === null || parent instanceof Object)
            && (windowCaption === null || windowCaption.constructor === String) && (AutoSelect === null || AutoSelect.constructor === Boolean)
            && (QAccess === null || QAccess.constructor === Boolean) && (MultiSelect === null || MultiSelect.constructor === Boolean)
            && (DeleteAllowed === null || DeleteAllowed.constructor === Boolean)) {
            return this.GetMSItem_4(parent, windowCaption, AutoSelect, QAccess, MultiSelect, DeleteAllowed);
        }
        if (arguments.length === 7 && (parent === null || parent instanceof Object)
            && (windowCaption === null || windowCaption.constructor === String)
            && (AutoSelect === null || AutoSelect.constructor === Boolean) && (QAccess === null || QAccess.constructor === Boolean)
            && (MultiSelect === null || MultiSelect.constructor === Boolean) && (DeleteAllowed === null || DeleteAllowed.constructor === Boolean)
            && (SortedOrCommandCaption === null || SortedOrCommandCaption.constructor === Boolean)) {
            return this.GetMSItem_5(parent, windowCaption, AutoSelect, QAccess, MultiSelect, DeleteAllowed, SortedOrCommandCaption);
        }
        if (arguments.length === 8 && (parent === null || parent instanceof Object)
            && (windowCaption === null || windowCaption.constructor === String)
            && (AutoSelect === null || AutoSelect.constructor === Boolean) && (QAccess === null || QAccess.constructor === Boolean)
            && (MultiSelect === null || MultiSelect.constructor === Boolean) && (DeleteAllowed === null || DeleteAllowed.constructor === Boolean)
            && (SortedOrCommandCaption === null || SortedOrCommandCaption.constructor === Boolean) && (ForceToChooseOrCancelCap === null || ForceToChooseOrCancelCap.constructor === Boolean)) {
            return this.GetMSItem_6(parent, windowCaption, AutoSelect, QAccess, MultiSelect, DeleteAllowed, SortedOrCommandCaption, ForceToChooseOrCancelCap);
        }
        return this.GetMSItem_7(parent, windowCaption, AutoSelect, QAccess, MultiSelect, DeleteAllowed, SortedOrCommandCaption, ForceToChooseOrCancelCap, QAccessStartWith, Sorted, ForceToChoose);
    }
    private GetMSItem_0(parent: Object, windowCaption: string): Promise<string> {
        return this.GetMSItem(parent, windowCaption, true, true, false, false, '', '', '', true, false);
    }
    private GetMSItem_1(parent: Object, windowCaption: string, AutoSelect: boolean): Promise<string> {
        return this.GetMSItem(parent, windowCaption, AutoSelect, true, false, false, '', '', '', true, false);
    }
    private GetMSItem_2(parent: Object, windowCaption: string, AutoSelect: boolean, QAccess: boolean): Promise<string> {
        return this.GetMSItem(parent, windowCaption, AutoSelect, QAccess, false, false, '', '', '', true, false);
    }
    private GetMSItem_3(parent: Object, windowCaption: string, AutoSelect: boolean, QAccess: boolean, MultiSelect: boolean): Promise<string> {
        return this.GetMSItem(parent, windowCaption, AutoSelect, QAccess, MultiSelect, false, '', '', '', true, false);
    }
    private GetMSItem_4(parent: Object, windowCaption: string, AutoSelect: boolean, QAccess: boolean, MultiSelect: boolean, DeleteAllowed: boolean): Promise<string> {
        return this.GetMSItem(parent, windowCaption, AutoSelect, QAccess, MultiSelect, DeleteAllowed, '', '', '', true, false);
    }
    private GetMSItem_5(parent: Object, windowCaption: string, AutoSelect: boolean, QAccess: boolean, MultiSelect: boolean, DeleteAllowed: boolean, Sorted: boolean): Promise<string> {
        return this.GetMSItem(parent, windowCaption, AutoSelect, QAccess, MultiSelect, DeleteAllowed, '', '', '', Sorted, false);
    }
    private GetMSItem_6(parent: Object, windowCaption: string, AutoSelect: boolean, QAccess: boolean, MultiSelect: boolean, DeleteAllowed: boolean, Sorted: boolean, ForceToChoose: boolean): Promise<string> {
        return this.GetMSItem(parent, windowCaption, AutoSelect, QAccess, MultiSelect, DeleteAllowed, '', '', '', Sorted, ForceToChoose);
    }

    private async GetMSItem_7(parent: Object, windowCaption: string, AutoSelect: boolean, QAccess: boolean, MultiSelect: boolean, DeleteAllowed: boolean, CommandCaption: string, CancelCap: string, QAccessStartWith: string, Sorted: boolean, ForceToChoose: boolean): Promise<string> {
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'MultiSelectComponent';
        componentInfo.ModuleName = 'CoreModule';
        componentInfo.ModulePath = '/app/Fw/CoreModule';
        componentInfo.InputParam = this;
        this._isMultiSelect = MultiSelect;
        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = windowCaption;
        modalInfo.Width = 500;
        modalInfo.Height = 410;
        let that = this;
        let promise = new Promise<string>(function (resolve, reject) {

            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(res => {
                let modalActionResult: MultiSelectForm_StorageItem[] = res.Param as MultiSelectForm_StorageItem[];
                if (modalActionResult !== undefined) {
                    if (modalActionResult.length === 1) {
                        that.MSSelectedItem = modalActionResult[0].MSKey;
                        that.MSSelectedItemObject = modalActionResult[0].MSObject;
                        resolve(modalActionResult[0].MSKey);
                    } else {
                        for (let i: number = 0; i <= modalActionResult.length - 1; i = i + 1) {
                            let storageItem: MultiSelectForm_StorageItem = modalActionResult[i];
                            that.MSSelectedItem += storageItem.MSItem + '\r\n';
                            that.MSSelectedItemObject = null;
                            that.MSSelectedItems.push(storageItem.MSKey);
                            that.MSSelectedItemObjects.push(storageItem.MSObject);
                        }
                        resolve(that.MSSelectedItem);
                    }

                }
            }).catch(err => {
                reject(err);
            });
        });
        return promise;
    }

    private GetMSItem_8(parent: Object, windowCaption: string, AutoSelect: boolean, QAccess: boolean,
        MultiSelect: boolean, DeleteAllowed: boolean, CommandCaption: string, CancelCap: string, QAccessStartWith: string,
        Sorted: boolean, ForceToChoose: boolean): string {
        let index: number = 0;
        let text: string = '';
        this.MSSelectedItem = '';
        this.MSSelectedItemObject = null;
        this.MSSelectedItemObjects = null;

        let num: number = 0;
        for (let i: number = 0; i < this._storageItems.length; i = i + 1) {
            let flag4: boolean = this._storageItems[i].MSKey !== '';
            if (flag4) {
                num = num + 1;
                index = i;
            }
        }
        let flag5: boolean = num === 0;
        let result: any;
        if (flag5) {
            text = '';
        } else {
            let flag6: boolean = num === 1 && AutoSelect;
            if (flag6) {
                text = this._storageItems[index].MSKey;
                this.MSSelectedItem = this._storageItems[index].MSItem;
                this.MSSelectedItemObject = this._storageItems[index].MSObject;
                this.MSSelectedItems.push(this._storageItems[index].MSKey, this._storageItems[index].MSItem);
                this.MSSelectedItemObjects = this._storageItems[index].MSObject;
            } else {
                if (MultiSelect) {
                    for (let i: number = 0; i <= this._storageItems.length - 1; i = i + 1) {
                        let storageItem: MultiSelectForm_StorageItem = this._storageItems[i];
                        this.MSSelectedItem = this.MSSelectedItem + storageItem.MSItem + '\r\n';
                        this.MSSelectedItemObject = null;
                        this.MSSelectedItems.push(storageItem.MSKey, storageItem.MSItem);
                        this.MSSelectedItemObjects = storageItem.MSObject;
                    }
                } else {
                    let storageItem2 = this._storageItems[0];
                    text = storageItem2.MSKey;
                    this.MSSelectedItem = storageItem2.MSItem;
                    this.MSSelectedItemObject = storageItem2.MSObject;
                    this.MSSelectedItems.push(storageItem2.MSKey, storageItem2.MSItem);
                    this.MSSelectedItemObjects = storageItem2.MSObject;
                }
            }
        }
        result = text;
        return result;
    }
}

class MultiSelectForm_StorageItem {
    MSItem: string = null;
    MSKey: string = null;
    MSObject: any = null;
    constructor(msItem: string, msKey: string, mSObject: any) {
        this.MSItem = msItem;
        this.MSKey = msKey;
        this.MSObject = mSObject;
    }
}