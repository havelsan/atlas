import { ITTLinkableObject } from "../ITTLinkableObject";
import { ITTErrorChecker } from "../ITTErrorChecker";
import { ITTGridColumn } from "./Columns/ITTGridColumn";
import { ITTGridRow } from "./ITTGridRow";
//import { Font } from "../../../Mscorlib/Font";

export interface ITTGridCell extends ITTLinkableObject, ITTErrorChecker {
    ColumnIndex?: number;
    RowIndex?: number;
    ErrorText?: string;
    //Font: Font;
    BackColor?: string;
    ForeColor?: string;
    ReadOnly?: boolean;
    Required?: boolean;
    Selected?: boolean;
    Value?: Object;
    OwningRow?: ITTGridRow;
    OwningColumn?: ITTGridColumn;
}