import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { Observable } from 'rxjs';
import { IQuickActionsMenuService } from 'app/Fw/Services/IQuickActionsMenuService';
import { QuickActionsMenuItem } from 'app/template/content/layout/header/topbar/quick-action/QuickActionsMenuItem';

@Injectable()
export class QuickActionsMenuService implements IQuickActionsMenuService {

    private _OnInsert: ReplaySubject<any> = new ReplaySubject<any>(1);
    public OnInsert: Observable<any> = this._OnInsert.asObservable();

    private _OnRemove: ReplaySubject<any> = new ReplaySubject<any>(1);
    public OnRemove: Observable<any> = this._OnRemove.asObservable();

    public items: Array<QuickActionsMenuItem> = [];

    constructor() {}

    public addItem(menuItem: QuickActionsMenuItem) {
        this.items.push(menuItem);
        this._OnInsert.next(menuItem);
    }

    public removeItem(menuKey: string) {
        let index = this.items.findIndex(x => x.Key == menuKey);
        if (index > -1){
            let removedItem = this.items.splice(index, 1);
            this._OnRemove.next(removedItem);
        }
    }

    public getItems(): Array<QuickActionsMenuItem>{
        return this.items;
    }
}
