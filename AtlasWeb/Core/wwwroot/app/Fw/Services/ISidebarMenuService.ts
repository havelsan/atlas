import { Observable } from 'rxjs';
import { EventEmitter } from '@angular/core';


export abstract class ISidebarMenuService {
    public abstract addOrRemoveMenu: Observable<any>;
    public abstract addMenu(parentMenuKey: string, SidebarMenuItem);
    public abstract removeMenu(menuKey: string);
    abstract onRequestEvent : EventEmitter<any>;
}