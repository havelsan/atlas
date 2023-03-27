import { ITTBindableControl } from "../ITTBindableControl";
import { ITTGridCell } from "./ITTGridCell";
import { ITTListBox } from "../ITTListBox";

/*[TTBrowsableInterface]*/
export interface ITTGrid extends ITTBindableControl {
    /*[TTSelectionChanged]
event TTControlEventDelegate SelectionChanged;*/
    /*[TTCellDoubleClick]
           event TTGridCellEventDelegate CellDoubleClick;*/

    CellValueChanged?(rowIndex: number, colIndex: number);
    /*[TTCurrentCellChanged]
           event TTControlEventDelegate CurrentCellChanged;*/
    /*[TTRowLeave]
           event TTGridCellEventDelegate RowLeave;*/
    /*[TTRowValidating]
           event TTGridCellCancelEventDelegate RowValidating;*/
    /*[TTRowEnter]
           event TTGridCellEventDelegate RowEnter;*/
    /*[TTCellContentClick]
           event TTGridCellEventDelegate CellContentClick;*/
    /*[TTUserDeletedRow]
           event TTGridRowEventDelegate UserDeletedRow;*/
    Columns?: Array<any>;
    AllowUserToAddRows?: boolean;
    AllowUserToDeleteRows?: boolean;
    HideUncompletedData?: boolean;
    HideCompletedSuccessfullyData?: boolean;
    HideCompletedUnsuccessfullyData?: boolean;
    HideCancelledData?: boolean;
    OnRowMarkerDoubleClickShowTTObjectForm?: boolean;
    AllowUserToOrderColumns?: boolean;
    AllowUserToResizeColumns?: boolean;
    AllowUserToResizeRows?: boolean;
    ColumnHeadersVisible?: boolean;
    RowHeadersVisible?: boolean;
    ChildObjectDefName?: string;
    ShowFilterRow?: boolean;
    Height?: any;
    ShowTotalNumberOfRows?: Boolean;
    IsFilterLabelSingleLine?: Boolean;
    // RowHeadersWidthSizeMode: DataGridViewRowHeadersWidthSizeMode;
    // AutoSizeRowsMode: DataGridViewAutoSizeRowsMode;
    // AutoSizeColumnsMode: DataGridViewAutoSizeColumnsMode;
    Rows?: Array<any>;
    CurrentCell?: ITTGridCell;
    //RefreshRows(): void;
    //ShowTTObject(rowIndex: number, NotDrawStateButtons: boolean): void;
    //ExportGridToExcel(fileName: string, isProtected: boolean): void;
    //Sort(columnIndex: number): void;
    //SetDataSource(dataSource: IBindingList): void;
    FilterLabel?: string;
    DeleteButtonWidth?: any;
    Filter?: ITTListBox;
    ShowFilterCombo?: Boolean;
    FilterColumnName?: string;
}