//import { IItemArray } from "../../../Utils/IItemArray";
import { ITTTabControl } from "./ITTTabControl";

/*[TTBrowsableInterface]*/
export interface ITTTabPageCollection /*extends IItemArray<ITTTabPage>*/ {
    Parent?: ITTTabControl;
    //[name: string]: ITTTabPage;
    //[i: number]: ITTTabPage;
   //Add(tabPage: ITTTabPage): number;
    //IndexOf(tabPage: ITTTabPage): number;
    //Insert(index: number, tabPage: ITTTabPage): void;
    //Remove(tabPage: ITTTabPage): void;
}