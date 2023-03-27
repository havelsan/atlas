import { EventEmitter } from '@angular/core';

export abstract class SidebarMenuItem {

    abstract isFavorited?: boolean;
    abstract get ParentInstance(): any;
    abstract get parameterFunctionInstance(): any;
    abstract get getParamsFunction(): Function;
    abstract get index(): number;
    abstract get key(): string;
    abstract get label(): string;
    abstract get icon(): string;
    abstract get ItemType(): string;
    abstract items: Array<SidebarMenuItem>;

}

export abstract class SidebarMenuItemClickable extends SidebarMenuItem {
    abstract click: EventEmitter<SidebarMenuItem>;
}