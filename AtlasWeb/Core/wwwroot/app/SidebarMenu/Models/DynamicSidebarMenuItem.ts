import { SidebarMenuItem } from './SidebarMenuItem';

export class DynamicSidebarMenuItem extends SidebarMenuItem {

    isFavorited: boolean;
    private _key: string;
    private _label: string;
    private _icon: string;
    private _componentInstance: any;
    private _clickFunction: Function;

    public items: Array<SidebarMenuItem> = new Array<SidebarMenuItem>();
    public dataContext = { $implicit: this.items };

    private _parentInstance: any;
    set ParentInstance(value: any) {
        this._parentInstance = value;
    }
    get ParentInstance(): any {
        return this._parentInstance;
    }

    private _parameterFunctionInstance: any;
    set parameterFunctionInstance(value: any) {
        this._parameterFunctionInstance = value;
    }
    get parameterFunctionInstance(): any {
        return this._parameterFunctionInstance;
    }

    private _getParamsFunction:Function;
    set getParamsFunction(value: Function) {
        this._getParamsFunction = value;
    }
    get getParamsFunction(): Function {
        return this._getParamsFunction;
    } 

    private _index: number;
    set index(value: number) {
        this._index = value;
    }
    get index(): number {
        return this._index;
    }


    set label(value: string) {
        this._label = value;
    }
    get label(): string {
        return this._label;
    }

    set key(value: string) {
        this._key = value;
    }
    get key(): string {
        return this._key;
    }

    set icon(value: string) {
        this._icon = value;
    }
    get icon(): string {
        return this._icon;
    }

    set componentInstance(value: any) {
        this._componentInstance = value;
    }

    get componentInstance(): any {
        return this._componentInstance;
    }

    set clickFunction(value: Function) {
        this._clickFunction = value;
    }

    get clickFunction(): Function {
        return this._clickFunction;
    }

    public get ItemType(): string {
        return 'MenuItem';
    }

    public get isNavToggle(): boolean {
        if (this.items != null && this.items.length > 0) {
            return true;
        }
        return false;
    }

    public get hasIcon(): boolean {
        if (this.icon) {
            return true;
        }
        return false;
    }

    public get classWithIcon(): string {
        if (this.icon) {
            return `fa ${this.icon}`;
        }
        return 'fa';
    }
}