import { TTControl } from "../TTControl";
import { ITTGrid } from "../../ControlInterfaces/TTGrid/ITTGrid";
import { ITTGridCell } from "../../ControlInterfaces/TTGrid/ITTGridCell";
import { DataGridViewColumnHeadersHeightSizeMode } from "../../../Utils/Enums/DataGridViewColumnHeadersHeightSizeMode";
import { DataGridViewRowHeadersWidthSizeMode } from "../../../Utils/Enums/DataGridViewRowHeadersWidthSizeMode";
import { DataGridViewAutoSizeRowsMode } from "../../../Utils/Enums/DataGridViewAutoSizeRowsMode";
import { DataGridViewAutoSizeColumnsMode } from "../../../Utils/Enums/DataGridViewAutoSizeColumnsMode";
import { ITTListBox } from "../../ControlInterfaces/ITTListBox";

export class TTGrid extends TTControl implements ITTGrid {
    public Items: any;
    public Columns: Array<any>;
    public AllowUserToAddRows: boolean;
    public AllowUserToDeleteRows: boolean;
    public HideUncompletedData: boolean;
    public HideCompletedSuccessfullyData: boolean;
    public HideCompletedUnsuccessfullyData: boolean;
    public HideCancelledData: boolean;
    public OnRowMarkerDoubleClickShowTTObjectForm: boolean;
    public AllowUserToOrderColumns: boolean;
    public AllowUserToResizeColumns: boolean;
    public AllowUserToResizeRows: boolean;
    public ColumnHeadersVisible: boolean;
    public RowHeadersVisible: boolean;
    public ChildObjectDefName: string;
    public ColumnHeadersHeightSizeMode: DataGridViewColumnHeadersHeightSizeMode;
    public RowHeadersWidthSizeMode: DataGridViewRowHeadersWidthSizeMode;
    public AutoSizeRowsMode: DataGridViewAutoSizeRowsMode;
    public AutoSizeColumnsMode: DataGridViewAutoSizeColumnsMode;
    public Rows: Array<any>;
    public CurrentCell: ITTGridCell;
    public ShowFilterRow: boolean;
    public Height: any;
    public ShowTotalNumberOfRows?: Boolean;
    public DeleteButtonWidth?: any;
    public Filter?: ITTListBox;
    public FilterColumnName?: string;
    public FilterLabel?: string;
    public IsFilterLabelSingleLine?: Boolean;
    /*public event TTControlEventDelegate SelectionChanged;*/
    /*public event TTGridCellEventDelegate CellDoubleClick;*/
    /*public event TTGridCellEventDelegate CellValueChanged;*/
    /*public event TTControlEventDelegate CurrentCellChanged;*/
    /*public event TTGridCellEventDelegate RowLeave;*/
    /*public event TTGridCellCancelEventDelegate RowValidating;*/
    /*public event TTGridCellEventDelegate RowEnter;*/
    /*public event TTGridCellEventDelegate CellContentClick;*/
    /*public event TTGridRowEventDelegate UserDeletedRow;*/
    public RefreshRows(): void {

    }
    public ShowTTObject(rowIndex: number, NotDrawStateButtons: boolean): void {

    }
    public ExportGridToExcel(fileName: string, isProtected: boolean): void {

    }
    public Sort(columnIndex: number): void {

    }
    public SetDataSource(dataSource: Array<any>): void {

    }
    public CellValueChanged?(rowIndex: number, colIndex: number) {

    }
}