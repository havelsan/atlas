import { ITTComboBox } from "./ITTComboBox";
import { SortByEnum } from "../../Utils/Enums/SortByEnum";
/*[TTBrowsableInterface]*/
export interface ITTEnumComboBox extends ITTComboBox {
    /*[TTDataTypeName]*/
    DataTypeName?: string;
    SortBy?: SortByEnum;
    IncludeOnly?: Array<any>;
}