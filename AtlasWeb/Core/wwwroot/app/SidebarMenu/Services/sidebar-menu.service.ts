import { Injectable, EventEmitter } from '@angular/core';
import { SidebarMenuItem } from '../Models/SidebarMenuItem';
import { ISidebarMenuService } from '../../Fw/Services/ISidebarMenuService';
import { Observable,ReplaySubject } from 'rxjs';


@Injectable()
export class SidebarMenuService implements ISidebarMenuService {
    public onRequestEvent: EventEmitter<any> = new EventEmitter<any>();

    private _addOrRemoveMenu: ReplaySubject<any> = new ReplaySubject<any>(1);
    public addOrRemoveMenu: Observable<any> = this._addOrRemoveMenu.asObservable();

    constructor() {
    }

    public addMenu(parentMenuKey: string, menuItem: SidebarMenuItem) {
        let payload: any = { parentMenuKey: parentMenuKey, menuItem: menuItem, action: 'add' };
        this._addOrRemoveMenu.next(payload);
    }

    public removeMenu(menuKey: string) {
        let payload: any = { menuKey: menuKey, action: 'remove' };
        this._addOrRemoveMenu.next(payload);
    }

}
