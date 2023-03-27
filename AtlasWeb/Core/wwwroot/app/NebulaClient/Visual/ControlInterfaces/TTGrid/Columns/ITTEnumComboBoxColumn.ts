import { ITTComboBoxColumn } from "./ITTComboBoxColumn";
import { SortByEnum } from "../../../../Utils/Enums/SortByEnum";
/*[TTBrowsableInterface]*/
export interface ITTEnumComboBoxColumn extends ITTComboBoxColumn {
    /*[TTDataTypeName]*/
    DataTypeName?: string;
    SortBy?: SortByEnum;
    ShowClearButton?: boolean;
}