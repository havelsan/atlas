import { ITTTabPage } from "../../ControlInterfaces/TTTabControl/ITTTabPage";
import { ITTTabControl } from "../../ControlInterfaces/TTTabControl/ITTTabControl";

export class TTTabPageCollection  {
    private pointer = 0;
    public Parent: ITTTabControl;
    private _tabPages: Array<ITTTabPage> = new Array<ITTTabPage>();

    public Add(item: ITTTabPage): number {
        return this._tabPages.push(item);
    }
    public IndexOf(item: ITTTabPage): number {
        return this._tabPages.indexOf(item);
    }
    public Insert(index: number, item: ITTTabPage): void {
        this._tabPages.splice(index, 0, item);
    }

    public Remove(item: ITTTabPage): void {
        let itemIndex: number = this._tabPages.indexOf(item);
        if (itemIndex != undefined) {
            if (itemIndex > -1)
                this._tabPages.splice(itemIndex, 1);
        }
    }
    public next(): IteratorResult<ITTTabPage> {
        if (this.pointer < this._tabPages.length) {
            return {
                done: false,
                value: this._tabPages[this.pointer++]
            };
        } else {
            return {
                done: true,
                value: null,
            };
        }
    }
}