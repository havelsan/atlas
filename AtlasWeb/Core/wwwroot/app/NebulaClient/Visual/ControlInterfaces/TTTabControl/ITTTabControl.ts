import { ITTControlBase } from "../ITTControlBase";
import { ITTTabPage } from "./ITTTabPage";

/*[TTBrowsableInterface]*/
export interface ITTTabControl extends ITTControlBase {
    //TabPages: ITTTabPageCollection;
    TabPages?: Array<ITTTabPage>;
    /*[Browsable(false)]*/
    SelectedTab?: ITTTabPage;
    /*[Browsable(false)]*/
    SelectedIndex?: number;
    /*[TTSelectedTabChanged]
           event TTControlEventDelegate SelectedTabChanged;*/
    //HideTabPage(tabPage: ITTTabPage): void;
    //ShowTabPage(tabPage: ITTTabPage): void;
}