import { TTControl } from "../TTControl";
import { ITTTabControl } from "../../ControlInterfaces/TTTabControl/ITTTabControl";
import { ITTTabPage } from "../../ControlInterfaces/TTTabControl/ITTTabPage";

export class TTTabControl extends TTControl implements ITTTabControl {
    private _tabPages: Array<ITTTabPage> = new Array<ITTTabPage>();
    public get TabPages(): Array<ITTTabPage> {
        return this._tabPages;
    }
    /*[Browsable(false)]*/
    public SelectedTab: ITTTabPage;
    /*[Browsable(false)]*/
    public SelectedIndex: number;
    /*public event TTControlEventDelegate SelectedTabChanged;*/
    public HideTabPage(tabPage: ITTTabPage): void {
        tabPage.Visible = false;
    }
    public ShowTabPage(tabPage: ITTTabPage): void {
        tabPage.Visible = true;
    }
}