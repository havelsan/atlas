import { ITTGrid } from "./ITTGrid";
//import { IItemArray } from "../../../Utils/IItemArray";

export interface ITTGridColumnCollection /*extends IItemArray<ITTGridColumn>*/ {
    //[name: string]: ITTGridColumn;
    //[index: number]: ITTGridColumn;
    TTGrid?: ITTGrid;
    Contains?(name: string): boolean;
    RemoveByName?(name: string): boolean;
}