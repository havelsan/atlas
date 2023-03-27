import {
    Component, ViewChild, SimpleChanges, OnChanges,
    KeyValueDiffers, IterableDiffers, ElementRef, DoCheck, EventEmitter, KeyValueChangeRecord, Input, Renderer2
} from '@angular/core';
import { DataGridMessageService, Messages } from '../Services/DataGridMessageService';
import { BaseControl } from './BaseControls/BaseControl';
import { TTTextBoxColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTTextBoxColumn';
import { TTButtonColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTButtonColumn';
import { TTCheckBoxColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTCheckBoxColumn';
import { TTListBoxColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTListBoxColumn';
import { TTMaskedTextBoxColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTMaskedTextBoxColumn';
import { TTDateTimePickerColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTDateTimePickerColumn';
import { TTListDefComboBoxColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTListDefComboBoxColumn';
import { TTEnumComboBoxColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTEnumComboBoxColumn';
import { TTComboBoxColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTComboBoxColumn';
import { TTRichTextBoxControlColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTRichTextBoxControlColumn';
import { TTGridColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTGridColumn';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { TTGridRow } from 'NebulaClient/Visual/Controls/TTGrid/TTGridRow';
import { TTRadioButtonGroupColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTRadioButtonGroupColumn';
import { TTValueListBoxColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTValueListBoxColumn';
import { TTLabelColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTLabelColumn';
import { ITTListBox } from 'NebulaClient/Visual/ControlInterfaces/ITTListBox';
import { Util } from './Util';
import { DxDataGridComponent } from 'devextreme-angular';
import { TTObjectHelper } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectHelper';
import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';
//
@Component({
    selector: 'hvl-datagrid',
    inputs: ['ReadOnly', 'Visible', 'BackColor', 'ForeColor', 'Enabled', 'ShowTotalNumberOfRows', 'FilterColumnName', 'PageSize',
        'Columns', 'dataSource', 'SelectedObject', 'AllowUserToAddRows', 'DeleteButtonWidth', 'FilterLabel', 'IsFilterLabelSingleLine',
        'AllowUserToDeleteRows', 'ShowColumnHeaders', 'EnableFilter', 'height', 'Filter', 'ShowFilterCombo'],
    outputs: ['SelectedObjectChange', 'CellValueChange', 'CellContentClicked', 'RowInserting', 'InitNewRow', 'RowPrepared', 'RowRemoved',  'SelectedFilterChanged'],
    template: `
<div style="width:100%;padding:10px">
    <div class="container-fluid" [style.height]="GetHeight()">
        <div class="row">
            <div class="col-xs-10">
                <div class="container-fluid" style="padding:5px" *ngIf="ShowFilterCombo">
                    <div class="row" *ngIf="IsFilterLabelSingleLine">
                        <div class="col-xs-2">
                            <label class="control-label">{{FilterLabel}}</label>
                        </div>
                        <div class="col-xs-10">
                            <hvl-list-box [(SelectedObject)]="SelectedFilterObject" (SelectedObjectChange)="filterChanged($event)" width="100%" AutoCompleteMode="1"
                                SearchMode="1" [AutoCompleteDialogHeight]="Filter?.AutoCompleteDialogHeight" [ReadOnly]="Filter?.ReadOnly"
                                [AutoCompleteDialogWidth]="Filter?.AutoCompleteDialogWidth" [DefinitionName]="Filter?.ListDefName"
                                [ListFilterExpression]="Filter?.ListFilterExpression"></hvl-list-box>
                        </div>
                    </div>
                    <div class="row" *ngIf="!IsFilterLabelSingleLine">
                        <div class="col-xs-10">
                            <label class="control-label">{{FilterLabel}}</label>
                        </div>
                    </div>
                    <div class="row" *ngIf="!IsFilterLabelSingleLine">
                        <div class="col-xs-10">
                            <hvl-list-box [(SelectedObject)]="SelectedFilterObject" (SelectedObjectChange)="filterChanged($event)" width="100%" AutoCompleteMode="1"
                                SearchMode="1" [AutoCompleteDialogHeight]="Filter?.AutoCompleteDialogHeight" [ReadOnly]="Filter?.ReadOnly"
                                [AutoCompleteDialogWidth]="Filter?.AutoCompleteDialogWidth" [DefinitionName]="Filter?.ListDefName"
                                [ListFilterExpression]="Filter?.ListFilterExpression"></hvl-list-box>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-2">
                <div style="width:100%;padding-top:5px">
                    <dx-button height="20px;" [ngClass]="['pull-right']" [disabled]="!Enabled" *ngIf="_AllowUserToAddRows"
                        icon="plus" (onClick)="addNewClicked()"></dx-button>
                </div>
            </div>
        </div>
    </div>
    <div style="width:100%">
        <dx-data-grid allowColumnReordering="true" cellHintEnabled="true" allowColumnResizing="true" showColumnLines="true" showRowLines="true"
            [showColumnHeaders]="ShowColumnHeaders" columnAutoWidth="true" [dataSource]="dataSource" [columns]="GridColumns" [paging]="PageSize"
            [disabled]="!Enabled" [editing]="{allowAdding: false}" (onRowPrepared)="rowPrepared($event)" (onContentReady)="contentReady($event)"
            [filterRow]="FilterConfig" width="100%"  [selection]="{mode: 'single',allowSelectAll: false}"
            (selectedRowKeysChange)="selectionChanged($event)" (onRowClick)="rowClick($event)" (onCellPrepared)="cellPrepared($event)"
            (onContentReady)="gridReady($event)" (onRowInserting)="rowInserting($event)" (onRowInserted)="rowInserted($event)"
            (onInitNewRow)="initNewRow($event)">
            <div align="left" *dxTemplate='let cellData of "headerTemplate"'>
                {{cellData.column.caption}}
            </div>
            <div *dxTemplate='let cellData of "textBoxTemplate"'>
                <hvl-text-box #Validation *ngIf="!cellData?.column?.columnConfig?.IsNumeric" [Text]="getCellData(cellData)" (TextChange)="setCellData(cellData,$event);CellChanged(cellData.column.columnConfig,$event,cellData?.rowIndex)"
                    [Name]="cellData?.column?.columnConfig?.Name" [BackColor]="cellData?.column?.columnConfig?.BackColor" [Required]="cellData?.column?.columnConfig?.Required"
                    [Enabled]="getCellDataProperty(cellData?.column?.columnConfig?.EnabledBindingPath,cellData)" [Font]="cellData?.column?.columnConfig?.Font"
                    [ForeColor]="cellData?.column?.columnConfig?.ForeColor" [ReadOnly]="cellData?.column?.columnConfig?.ReadOnly"></hvl-text-box>
                <hvl-number-box *ngIf="cellData?.column?.columnConfig?.IsNumeric" [Value]="getCellData(cellData)" [ReadOnly]="cellData?.column?.columnConfig?.ReadOnly"
                    [Enabled]="getCellDataProperty(cellData?.column?.columnConfig?.EnabledBindingPath,cellData)" (ValueChange)="setCellData(cellData,$event);CellChanged(cellData.column.columnConfig,$event,cellData?.rowIndex)"
                    changeEvent="blur"></hvl-number-box>
            </div>
            <div align="center" *dxTemplate='let cellData of "btnTemplate"'>
                <hvl-button [Text]="cellData?.column?.columnConfig?.Text" [height]="cellData?.column?.columnConfig?.Height" (GrdBtnClicked)="contentClicked($event, cellData?.rowIndex, cellData)"
                    [Tag]="getButtonCell(cellData)" [Name]="cellData?.column?.columnConfig?.Name" [BackColor]="cellData?.column?.columnConfig?.BackColor"
                    [width]="cellData?.column?.columnConfig?.ButtonWidth" [Row]="cellData?.data" [Column]="cellData?.column?.columnConfig"
                    [Enabled]="getCellDataProperty(cellData?.column?.columnConfig?.EnabledBindingPath,cellData)" [Font]="cellData?.column?.columnConfig?.Font"
                    [ForeColor]="cellData?.column?.columnConfig?.ForeColor" [ReadOnly]="cellData?.column?.columnConfig?.ReadOnly"></hvl-button>
            </div>
            <div align="center" *dxTemplate='let cellData of "chkTemplate"'>
                <hvl-checkbox [Value]="getCellData(cellData)" (ValueChange)="setCellData(cellData,$event);CellChanged(cellData.column.columnConfig,cellData.data,cellData?.rowIndex)"
                    [Name]="cellData?.column?.columnConfig?.Name" [Required]="cellData?.column?.columnConfig?.Required" [AllowThreeState]="cellData.column.ThreeState"
                    [Margin]="cellData?.column?.columnConfig?.Margin" [TitleTopPadding]="cellData?.column?.columnConfig?.TitleTopPadding"
                    [Enabled]="getCellDataProperty(cellData?.column?.columnConfig?.EnabledBindingPath,cellData)" [ReadOnly]="cellData?.column?.columnConfig?.ReadOnly"></hvl-checkbox>
            </div>
            <div *dxTemplate='let cellData of "lbTemplate"'>
                <hvl-list-box #Validation (SelectedObjectChange)="setCellData(cellData,$event);CellChanged(cellData.column.columnConfig,$event,cellData?.rowIndex)"
                    [SelectedObject]="getCellData(cellData)" width="100%" [Name]="cellData?.column?.columnConfig?.Name" [BackColor]="cellData?.column?.columnConfig?.BackColor"
                    [Required]="cellData?.column?.columnConfig?.Required" AutoCompleteMode="1" SearchMode="1" [AutoCompleteDialogHeight]="cellData?.column?.columnConfig?.AutoCompleteDialogHeight"
                    [Font]="cellData?.column?.columnConfig?.Font" [ForeColor]="cellData?.column?.columnConfig?.ForeColor" [AutoCompleteDialogWidth]="cellData?.column?.columnConfig?.AutoCompleteDialogWidth"
                    [ReadOnly]="cellData?.column?.columnConfig?.ReadOnly" [IsOnPopUp]="OnPopup" [Enabled]="getCellDataProperty(cellData?.column?.columnConfig?.EnabledBindingPath,cellData)"
                    [DisplayExpressionsCache]="displayExpressionsCache"
                    [DefinitionName]="cellData?.column?.columnConfig?.ListDefName" [ListFilterExpression]="GetListFilterExpression(cellData)"></hvl-list-box>
            </div>
            <div align="center" *dxTemplate='let cellData of "dtTemplate"'>
                <hvl-date-picker #Validation (ValueChange)="setCellData(cellData,$event);CellChanged(cellData.column.columnConfig,$event,cellData?.rowIndex)"
                    [Value]="getCellData(cellData)" [Name]="cellData?.column?.columnConfig?.Name" [BackColor]="cellData?.column?.columnConfig?.BackColor"
                    [Required]="cellData?.column?.columnConfig?.Required" [Min]="cellData?.column?.columnConfig?.Min" [Font]="cellData?.column?.columnConfig?.Font"
                    [ForeColor]="cellData?.column?.columnConfig?.ForeColor" [ReadOnly]="cellData?.column?.columnConfig?.ReadOnly"
                    [Max]="cellData?.column?.columnConfig?.Max" [Format]="cellData?.column?.columnConfig?.Format" [Enabled]="getCellDataProperty(cellData?.column?.columnConfig?.EnabledBindingPath,cellData)"
                    [CustomFormat]="cellData?.column?.columnConfig?.CustomFormat"></hvl-date-picker>
            </div>
            <div align="center" *dxTemplate='let cellData of "listDefTemplate"'>
                <hvl-listdef-combobox #Validation (SelectedObjectChange)="setCellData(cellData,$event);CellChanged(cellData.column.columnConfig,$event,cellData?.rowIndex)"
                    [SelectedObject]="getCellData(cellData)" [DefinitionName]="cellData?.column?.columnConfig?.ListDefName" [Name]="cellData?.column?.columnConfig?.Name"
                    [BackColor]="cellData?.column?.columnConfig?.BackColor" [Required]="cellData?.column?.columnConfig?.Required"
                    [DisplayExpressionsCache]="displayExpressionsCache"
                    [Enabled]="getCellDataProperty(cellData?.column?.columnConfig?.EnabledBindingPath,cellData)" [Font]="cellData?.column?.columnConfig?.Font"
                    [ForeColor]="cellData?.column?.columnConfig?.ForeColor" [ReadOnly]="cellData?.column?.columnConfig?.ReadOnly"></hvl-listdef-combobox>
            </div>
            <div align="center" *dxTemplate='let cellData of "enumCmbTemplate"'>
                <hvl-enum-combobox #Validation (ValueChange)="setCellData(cellData,$event);CellChanged(cellData.column.columnConfig,$event,cellData?.rowIndex)"
                    [Enabled]="getCellDataProperty(cellData?.column?.columnConfig?.EnabledBindingPath,cellData)" [Value]="getCellData(cellData)"
                    [DataTypeName]="cellData?.column?.columnConfig?.DataTypeName" [ShowClearButton]="cellData?.column?.columnConfig?.ShowClearButton"
                    [Name]="cellData?.column?.columnConfig?.Name" [BackColor]="cellData?.column?.columnConfig?.BackColor" [Required]="cellData?.column?.columnConfig?.Required"
                    [Font]="cellData?.column?.columnConfig?.Font" [ForeColor]="cellData?.column?.columnConfig?.ForeColor" [ReadOnly]="cellData?.column?.columnConfig?.ReadOnly"></hvl-enum-combobox>
            </div>
            <div align="center" *dxTemplate='let cellData of "cmbTemplate"'>
                <hvl-combobox #Validation (ValueChange)="setCellData(cellData,$event);CellChanged(cellData.column.columnConfig,$event,cellData?.rowIndex)"
                    [Value]="getCellData(cellData)" [Items]="cellData?.column?.Items" [Name]="cellData?.column?.columnConfig?.Name"
                    [BackColor]="cellData?.column?.columnConfig?.BackColor" [Required]="cellData?.column?.columnConfig?.Required"
                    [Font]="cellData?.column?.columnConfig?.Font" [ForeColor]="cellData?.column?.columnConfig?.ForeColor" [ReadOnly]="cellData?.column?.columnConfig?.ReadOnly"></hvl-combobox>
            </div>
            <div align="center" *dxTemplate='let cellData of "maskedTextBoxTemplate"'>
                <hvl-masktext-box #Validation useMaskedValue="true" (TextChange)="setCellData(cellData,$event);CellChanged(cellData.column.columnConfig,$event,cellData?.rowIndex)"
                    [Text]="getCellData(cellData)" [Name]="cellData?.column?.columnConfig?.Name" [BackColor]="cellData?.column?.columnConfig?.BackColor"
                    [Required]="cellData?.column?.columnConfig?.Required" [Font]="cellData?.column?.columnConfig?.Font" [ForeColor]="cellData?.column?.columnConfig?.ForeColor"
                    [Enabled]="getCellDataProperty(cellData?.column?.columnConfig?.EnabledBindingPath,cellData)" [ReadOnly]="cellData?.column?.columnConfig?.ReadOnly"
                    [Mask]="cellData?.column?.columnConfig?.Mask"></hvl-masktext-box>
            </div>
            <div align="center" *dxTemplate='let cellData of "radioButtonGroupTemplate"'>
                <hvl-radio-button-group [Items]="cellData?.column?.columnConfig?.Items" [Value]="getCellData(cellData)" [Enabled]="getCellDataProperty(cellData?.column?.columnConfig?.EnabledBindingPath,cellData)"
                    (ValueChange)="setCellData(cellData,$event);CellChanged(cellData.column.columnConfig,$event,cellData?.rowIndex)"
                    [DisplayPath]="cellData?.column?.columnConfig?.DisplayExpression" [SelectedValuePath]="cellData?.column?.columnConfig?.ValueExpression"
                    [Margin]="cellData?.column?.columnConfig?.Margin"></hvl-radio-button-group>
            </div>
            <div align="center" *dxTemplate='let cellData of "richTextBoxTemplate"'>
                <hvl-rtf-column (TextChange)="setCellData(cellData,$event);CellChanged(cellData.column.columnConfig,$event,cellData?.rowIndex)"
                    [Text]="getCellData(cellData)" [ReadOnly]="cellData?.column?.columnConfig?.ReadOnly" [ButtonText]="cellData?.column?.columnConfig?.Text"
                    [Name]="cellData?.column?.columnConfig?.Name" ngDefaultControl></hvl-rtf-column>
            </div>
            <div *dxTemplate='let cellData of "valueLbTemplate"'>
                <hvl-valuelist-box #Validation (SelectedValueChange)="setCellData(cellData,$event);CellChanged(cellData.column.columnConfig,$event,cellData?.rowIndex)"
                    [SelectedValue]="getCellData(cellData)" [Name]="cellData?.column?.columnConfig?.Name" [BackColor]="cellData?.column?.columnConfig?.BackColor"
                    [Required]="cellData?.column?.columnConfig?.Required" [Enabled]="getCellDataProperty(cellData?.column?.columnConfig?.EnabledBindingPath,cellData)"
                    [Font]="cellData?.column?.columnConfig?.Font" [ForeColor]="cellData?.column?.columnConfig?.ForeColor" [ReadOnly]="cellData?.column?.columnConfig?.ReadOnly"
                    [DefinitionName]="cellData?.column?.columnConfig?.ListDefName"></hvl-valuelist-box>
            </div>
            <div *dxTemplate='let cellData of "labelTemplate"'>
                <div style="white-space:nowrap; padding-left:5px;overflow-x:hidden;line-height:15px; margin:0px; padding:0px;" title="{{getCellData(cellData)}}">
                    {{getCellData(cellData)}}
                </div>
            </div>
        </dx-data-grid>
    </div>
    <div style="width:100%;padding:5px" *ngIf="ShowTotalNumberOfRows">
        Toplam Kayıt Sayısı {{TotalNumberOfRows}}
    </div>
</div>`,
    providers: [DataGridMessageService]
})
export class HvlDataGrid extends BaseControl implements DoCheck, OnChanges {
    @ViewChild(DxDataGridComponent) gridInstance: DxDataGridComponent;

    private displayExpressionsCache: any;
    @Input() set DisplayExpressionsCache(value: any) {
        this.displayExpressionsCache = value;
    }
    get DisplayExpressionsCache(): any {
        return this.displayExpressionsCache;
    }

    @Input() ComfirmRowDeleting: Function;

    @Input() ComfirmAddRowByFilterSelection: Function;

    @Input() OnPopup: Boolean = false;

    _AllowUserToAddRows: Boolean = true;
    EnableFilter: Boolean = false;
    FilterConfig: any;
    Filter: ITTListBox;
    FilterLabel: String;
    ShowColumnHeaders: Boolean = true;
    ShowFilterCombo: Boolean = false;
    FilterColumnName: string;
    IsFilterLabelSingleLine: Boolean = true;
    get AllowUserToAddRows(): Boolean {
        return this._AllowUserToAddRows;
    }
    set AllowUserToAddRows(val: Boolean) {
        if (val == undefined) {
            val = true;
        }
        this._AllowUserToAddRows = val;
    }
    RowPrepared: EventEmitter<any> = new EventEmitter<any>();
    AllowUserToDeleteRows: Boolean = true;
    DeleteButtonWidth: any;
    EditConfig: any = {
        allowAdding: false,
        allowDeleting: true,
        mode: 'row'
    };
    SelectedFilterObject: any;
    Columns: Array<any>;
    dataSource: any;
    RichTextVisibility: any = {};
    ShowTotalNumberOfRows: Boolean;
    TotalNumberOfRows: Number;
    columnDifferences: any;
    columnPropertyDifferences: any = {};
    columnFontPropertyDifferences: any = {};
    GridColumns: Array<any>;
    PageSize: any = { enable: true, pageSize: 20 };
    SelectedObject: any;
    SelectedObjectChange: EventEmitter<any> = new EventEmitter<any>();
    CellValueChange: EventEmitter<any> = new EventEmitter<any>();
    CellContentClicked: EventEmitter<any> = new EventEmitter<any>();
    RowInserting: EventEmitter<any> = new EventEmitter<any>();
    InitNewRow: EventEmitter<any> = new EventEmitter<any>();
    RowRemoved: EventEmitter<any> = new EventEmitter<any>();
    //RowRemoving: EventEmitter<any> = new EventEmitter<any>();
    SelectedFilterChanged: EventEmitter<any> = new EventEmitter<any>();
    ComboboxItemsSourceDifferences: any = {};

    buttonRowIndex: number;
    buttonColIndex: number;
    buttonClicked: boolean;

    owningRow: TTGridRow;
    owningColumn: TTGridColumn;

    _CancelByDeleteButton: Boolean = false;
    @Input() get CancelByDeleteButton(): Boolean {
        return this._CancelByDeleteButton;
    }
    set CancelByDeleteButton(val: Boolean) {
        if (val == undefined) {
            val = false;
        }
        this._CancelByDeleteButton = val;
    }

    constructor(differs: KeyValueDiffers,
        element: ElementRef,
        private iterableDiffers: IterableDiffers,
        private renderer: Renderer2,
        private gridMessageService: DataGridMessageService) {
        super(differs, element);
        this.GridColumns = new Array<any>();
        this.columnDifferences = iterableDiffers.find([]).create(null);
    }
    //TODO {enable: true, pageSize:100}
    GetHeight() {
        //{\'height\': _AllowUserToAddRows || ShowFilterCombo ? \'35px\':\'0px\',\'padding\': _AllowUserToAddRows || ShowFilterCombo ? \'10px\':\'0px\'}
        if (this.AllowUserToAddRows) {
            if (this.ShowFilterCombo) {
                if (this.IsFilterLabelSingleLine) {
                    return 35;
                }
                else {
                    return 75;
                }
            }
            else {
                return 35;
            }
        }
        else {
            return 0;
        }
    }

    contentReady(e: any) {
        if (e.component.hasEditData()) {
            e.component.saveEditData();
        }
        if (e.component.totalCount() == 0)
            e.component.option("height", 60);
        else
            e.component.option("height", 'auto');
    }

    getListDefDisplayExpressionCache(cellData: any) {
        return this.displayExpressionsCache;
    }

    GetListFilterExpression(cellData: any) {
        let cfg: TTListBoxColumn = cellData.column.columnConfig;
        let listExpression: String;
        if (cfg.ListFilterExpressionPath) {
            listExpression = Util.ResolveProperty(cfg.ListFilterExpressionPath, cellData.data);
            if (!listExpression) {
                return cfg.ListFilterExpression;
            }
        }
        else {
            return cfg.ListFilterExpression;
        }
    }

    cellPrepared(event: any) {
        if (event.column.editCellTemplate == 'labelTemplate') {
            //event.cellElement.css('padding-top', '3px');
            this.renderer.setStyle(event.cellElement[0], "padding-top", "3px");
            event.cellElement.css('padding-bottom', '0px');
            this.renderer.setStyle(event.cellElement[0], "padding-bottom", "0px");
        }
    }

    filterChanged(data: any) {
        if (data) {
            let addRow: boolean = true;
            if (this.ComfirmAddRowByFilterSelection != null ) {

                let tempAddRowByFilterRow = this.ComfirmAddRowByFilterSelection(data);
                if (tempAddRowByFilterRow == false) {
                    addRow = false;
                }

            }

            if (addRow == true) {
                this.gridInstance.instance.addRow();
                this.gridInstance.instance.saveEditData();
                //this.SelectedFilterObject = null;
            }
        }
    }

    createColumn(column: TTGridColumn): any {
        //if (this.GridColumns) {
        //    for (let i = 0; i < this.GridColumns.length; i++) {
        //        if (this.GridColumns[i].dataField == column.DataMember) {
        //            return null;
        //        }
        //    }
        //}
        if (column instanceof TTTextBoxColumn) {
            let textBoxColumn: TTTextBoxColumn = <TTTextBoxColumn>column;
            return {
                dataField: textBoxColumn.DataMember,
                width: textBoxColumn.Width,
                filterOperations: ['contains', 'startswith', '='],
                allowSorting: false,
                cellTemplate: 'textBoxTemplate',
                editCellTemplate: 'textBoxTemplate',
                visible: textBoxColumn.Visible,
                caption: textBoxColumn.HeaderText,
                columnConfig: textBoxColumn,
                headerCellTemplate: 'headerTemplate'
            };
        }
        else if (column instanceof TTButtonColumn) {
            let buttonColumn: TTButtonColumn = <TTButtonColumn>column;
            return {
                ComponentReference: buttonColumn.ComponentReference,
                Clicked: buttonColumn.Clicked,
                dataField: buttonColumn.DataMember,
                width: buttonColumn.Width,
                filterOperations: ['contains', 'startswith', '='],
                allowSorting: false,
                cellTemplate: 'btnTemplate',
                editCellTemplate: 'btnTemplate',
                Text: buttonColumn.Text,
                visible: buttonColumn.Visible,
                caption: buttonColumn.HeaderText,
                columnConfig: buttonColumn,
                headerCellTemplate: 'headerTemplate'
            };
        }
        else if (column instanceof TTCheckBoxColumn) {
            let chkColumn: TTCheckBoxColumn = <TTCheckBoxColumn>column;
            return {
                ThreeState: chkColumn.ThreeState,
                dataField: chkColumn.DataMember,
                width: chkColumn.Width,
                filterOperations: ['contains', 'startswith', '='],
                allowSorting: false,
                cellTemplate: 'chkTemplate',
                editCellTemplate: 'chkTemplate',
                Text: chkColumn.Text,
                visible: chkColumn.Visible,
                caption: chkColumn.HeaderText,
                columnConfig: chkColumn,
                headerCellTemplate: 'headerTemplate'
            };
        }
        else if (column instanceof TTListBoxColumn) {
            let lbColumn: TTListBoxColumn = <TTListBoxColumn>column;
            return {
                dataField: lbColumn.DataMember,
                width: lbColumn.Width,
                filterOperations: ['contains', 'startswith', '='],
                allowSorting: false,
                cellTemplate: 'lbTemplate',
                editCellTemplate: 'lbTemplate',
                visible: lbColumn.Visible,
                caption: lbColumn.HeaderText,
                columnConfig: lbColumn,
                headerCellTemplate: 'headerTemplate',
                displayExpressionCacheBinding: '_ViewModel?.ListDefDisplayExpressions'
            };
        }
        else if (column instanceof TTDateTimePickerColumn) {
            let dtColumn: TTDateTimePickerColumn = <TTDateTimePickerColumn>column;
            return {
                dataField: dtColumn.DataMember,
                width: dtColumn.Width,
                filterOperations: ['contains', 'startswith', '='],
                allowSorting: false,
                cellTemplate: 'dtTemplate',
                editCellTemplate: 'dtTemplate',
                visible: dtColumn.Visible,
                caption: dtColumn.HeaderText,
                columnConfig: dtColumn,
                headerCellTemplate: 'headerTemplate'
            };
        }
        else if (column instanceof TTListDefComboBoxColumn) {
            let listDefColumn: TTListDefComboBoxColumn = <TTListDefComboBoxColumn>column;
            return {
                //listDefName: listDefColumn.ListDefName,
                dataField: listDefColumn.DataMember,
                width: listDefColumn.Width,
                filterOperations: ['contains', 'startswith', '='],
                allowSorting: false,
                cellTemplate: 'listDefTemplate',
                editCellTemplate: 'listDefTemplate',
                visible: listDefColumn.Visible,
                caption: listDefColumn.HeaderText,
                columnConfig: listDefColumn,
                headerCellTemplate: 'headerTemplate'
            };
        }
        else if (column instanceof TTEnumComboBoxColumn) {
            let enumColumn: TTEnumComboBoxColumn = <TTEnumComboBoxColumn>column;
            return {
                dataField: enumColumn.DataMember,
                width: enumColumn.Width,
                filterOperations: ['contains', 'startswith', '='],
                allowSorting: false,
                cellTemplate: 'enumCmbTemplate',
                editCellTemplate: 'enumCmbTemplate',
                visible: enumColumn.Visible,
                caption: enumColumn.HeaderText,
                columnConfig: enumColumn,
                headerCellTemplate: 'headerTemplate'
            };
        }
        else if (column instanceof TTComboBoxColumn) {
            let cmbColumn: TTComboBoxColumn = <TTComboBoxColumn>column;
            if (!this.ComboboxItemsSourceDifferences[cmbColumn.Name]) {
                this.ComboboxItemsSourceDifferences[cmbColumn.Name] = this.iterableDiffers.find([]).create(null);
            }
            let cmb = {
                Name: cmbColumn.Name,
                //Items: Util.ResolveProperty(cmbColumn.ItemsSource, cmbColumn.ComponentReference),
                dataField: cmbColumn.DataMember,
                width: cmbColumn.Width,
                filterOperations: ['contains', 'startswith', '='],
                //allowSorting: false,
                cellTemplate: 'cmbTemplate',
                editCellTemplate: 'cmbTemplate',
                visible: cmbColumn.Visible,
                caption: cmbColumn.HeaderText,
                columnConfig: cmbColumn,
                headerCellTemplate: 'headerTemplate'
            };
            if (cmbColumn.ItemsSource && cmbColumn.ComponentReference)
                cmb['Items'] = Util.ResolveProperty(cmbColumn.ItemsSource, cmbColumn.ComponentReference);
            return cmbColumn;
        }
        else if (column instanceof TTMaskedTextBoxColumn) {
            let maskedText: TTMaskedTextBoxColumn = <TTMaskedTextBoxColumn>column;
            return {
                dataField: maskedText.DataMember,
                width: maskedText.Width,
                filterOperations: ['contains', 'startswith', '='],
                allowSorting: false,
                cellTemplate: 'maskedTextBoxTemplate',
                editCellTemplate: 'maskedTextBoxTemplate',
                visible: maskedText.Visible,
                caption: maskedText.HeaderText,
                columnConfig: maskedText,
                headerCellTemplate: 'headerTemplate'
            };
        }
        else if (column instanceof TTRichTextBoxControlColumn) {
            let richTextColumn: TTRichTextBoxControlColumn = <TTRichTextBoxControlColumn>column;
            this.RichTextVisibility[richTextColumn.Name] = false;
            return {
                dataField: richTextColumn.DataMember,
                width: richTextColumn.Width,
                filterOperations: ['contains', 'startswith', '='],
                allowSorting: false,
                cellTemplate: 'richTextBoxTemplate',
                editCellTemplate: 'richTextBoxTemplate',
                visible: richTextColumn.Visible,
                caption: richTextColumn.HeaderText,
                columnConfig: richTextColumn,
                headerCellTemplate: 'headerTemplate'
            };
        }
        else if (column instanceof TTRadioButtonGroupColumn) {
            let radioButtonColumn: TTRadioButtonGroupColumn = <TTRadioButtonGroupColumn>column;
            return {
                dataField: radioButtonColumn.DataMember,
                width: radioButtonColumn.Width,
                filterOperations: ['contains', 'startswith', '='],
                allowSorting: false,
                cellTemplate: 'radioButtonGroupTemplate',
                editCellTemplate: 'radioButtonGroupTemplate',
                visible: radioButtonColumn.Visible,
                caption: radioButtonColumn.HeaderText,
                columnConfig: radioButtonColumn,
                headerCellTemplate: 'headerTemplate'
            };
        }
        else if (column instanceof TTValueListBoxColumn) {
            let valueListBoxColumn: TTValueListBoxColumn = <TTValueListBoxColumn>column;
            return {
                dataField: valueListBoxColumn.DataMember,
                width: valueListBoxColumn.Width,
                filterOperations: ['contains', 'startswith', '='],
                allowSorting: false,
                cellTemplate: 'valueLbTemplate',
                editCellTemplate: 'valueLbTemplate',
                visible: valueListBoxColumn.Visible,
                caption: valueListBoxColumn.HeaderText,
                columnConfig: valueListBoxColumn,
                headerCellTemplate: 'headerTemplate'
            };
        }
        else if (column instanceof TTLabelColumn) {
            let lblColumn: TTLabelColumn = <TTLabelColumn>column;
            return {
                dataField: lblColumn.DataMember,
                width: lblColumn.Width,
                filterOperations: ['contains', 'startswith', '='],
                allowSorting: false,
                cellTemplate: 'labelTemplate',
                editCellTemplate: 'labelTemplate',
                visible: lblColumn.Visible,
                caption: lblColumn.HeaderText,
                columnConfig: lblColumn,
                headerCellTemplate: 'headerTemplate'
            };
        }
    }

    public sendMessage(column: any, key: string, message: any) {
        this.gridMessageService.SendMessage(key, column.Name, message);
    }

    ngDoCheck() {
        let that = this;
        let columnChanges: any = that.columnDifferences.diff(this.Columns);
        if (columnChanges) {
            that.RefreshColumns();
        }
        else {
            if (!that.Columns) {
                return;
            }
            for (let i = 0; i < that.Columns.length; i++) {
                let column: any = that.Columns[i];

                if (!that.columnPropertyDifferences[column.Name]) {
                    that.columnPropertyDifferences[column.Name] = that.differs.find({}).create();
                }
                else {
                    let propertyDifference = that.columnPropertyDifferences[column.Name].diff(column);
                    if (propertyDifference) {
                        that.columnPropertyDifferences[column.Name] = propertyDifference;
                        propertyDifference.forEachChangedItem((r: KeyValueChangeRecord<any, any>) => {
                            if (r.key == "Visible" || r.key == "HeaderText") {
                                that.RefreshColumns();
                            }
                            else {
                                that.sendMessage(column, r.key, r.currentValue);
                            }
                        });
                    }
                }


                if (column.Font) {
                    if (!that.columnFontPropertyDifferences[column.Name]) {
                        that.columnFontPropertyDifferences[column.Name] = that.differs.find({}).create();
                    }
                    else {
                        let fontPropertyDifference = that.columnFontPropertyDifferences[column.Name].diff(column.Font);
                        if (fontPropertyDifference) {
                            that.columnFontPropertyDifferences[column.Name] = fontPropertyDifference;
                            fontPropertyDifference.forEachChangedItem((r: KeyValueChangeRecord<any, any>) => {
                                that.sendMessage(column, "Font." + r.key, r.currentValue);
                            });
                        }
                    }
                }

                if (column.Type == "ITTComboBoxColumn") {
                    if (that.ComboboxItemsSourceDifferences[column.Name]) {
                        let itemsDifferences = that.ComboboxItemsSourceDifferences[column.Name].diff(Util.ResolveProperty(column.ItemsSource, column.ComponentReference));
                        if (itemsDifferences) {
                            that.gridMessageService.SendMessage(Messages.ItemsChangeMessage, column.Name, Util.ResolveProperty(column.ItemsSource, column.ComponentReference));
                        }
                    }
                }
            }
        }
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['ShowFilterCombo'] && this.ShowFilterCombo == undefined) {
            this.ShowFilterCombo = false;
        }
        if (changes['IsFilterLabelSingleLine'] && this.IsFilterLabelSingleLine == undefined) {
            this.IsFilterLabelSingleLine = true;
        }
        if (changes['height']) {
            this.setHeight();
        }
        if (changes['dataSource'] && !this.dataSource) {
            this.dataSource = [];
        }
        if (changes['ShowTotalNumberOfRows'] && this.ShowTotalNumberOfRows == undefined) {
            this.ShowTotalNumberOfRows = true;
        }
        if (changes['ShowColumnHeaders'] && this.ShowColumnHeaders == undefined) {
            this.ShowColumnHeaders = true;
        }
        if (changes['EnableFilter']) {
            if (this.EnableFilter) {
                this.FilterConfig = { visible: true };
            }
            else if (this.EnableFilter == undefined || this.EnableFilter == false) {
                this.FilterConfig = null;
            }
        }
        if (changes['DeleteButtonWidth'] && !this.DeleteButtonWidth) {
            this.DeleteButtonWidth = "5%";
        }
        if (changes['AllowUserToDeleteRows']) {
            if (this.AllowUserToDeleteRows == undefined) {
                this.AllowUserToDeleteRows = true;
            }
            //let cfg: any = {
            //    allowAdding: false,
            //};
            //this.EditConfig = cfg;
            this.RefreshColumns();
        }
    }

    gridReady(data: any) {
        if (this.gridInstance && this.gridInstance.instance)
            this.TotalNumberOfRows = this.gridInstance.instance.totalCount();
        this.setHeight();
    }

    setHeight() {
        if (this.gridInstance) {
            this.gridInstance.height = this.height;
        }
    }

    RefreshColumns() {
        this.GridColumns.length = 0;
        let cols = [];
        if (this.Columns) {
            for (let i = 0; i < this.Columns.length; i++) {
                let column = this.Columns[i];
                let col = this.createColumn(column);
                if (col) {
                    this.GridColumns.push(col);
                }
            }
        }
        if (this.AllowUserToDeleteRows && this.GridColumns.length > 0) {
            this.GridColumns.push({
                columnConfig: {
                    isDeleteButtonColumn: true,
                    //ButtonWidth: "5%",
                    Text: 'Sil'
                },
                width: this.DeleteButtonWidth,
                allowSorting: false,
                allowResizing: false,
                cellTemplate: 'btnTemplate',
                editCellTemplate: 'btnTemplate',
                caption: 'Sil',
                headerCellTemplate: 'headerTemplate'
            });
        }
        if (this.gridInstance != null && this.gridInstance.instance) {
            //let that = this;
            //this.grid.instance.refresh().done(t => {
            //that.grid.instance.repaint();
            //});
            this.Refresh();
        }
    }

    Refresh() {
        let that = this;
        this.gridInstance.instance.refresh().done(t => {
            that.gridInstance.instance.repaint();
        });
    }

    RefreshFilter() {
        if (this.CancelByDeleteButton)
            this.gridInstance.instance.filter(['EntityState', '<>', 4]);
        else
            this.gridInstance.instance.filter(['EntityState', '<>', 1]);
    }

    getCellData(cellData: any) {
        return Util.ResolveProperty(cellData.column.dataField, cellData.data);
    }

    //rowRemoving(data: any) {
    //    this.RowRemoving.emit(data);
    //}

    getCellDataProperty(propertyPath: string, cellData: any) {
        if (propertyPath) {
            return Util.ResolveProperty(propertyPath, cellData.data);
        }
    }

    setCellData(cellData: any, $event: any) {
        Util.SetPropertyValue(cellData.column.dataField, cellData.data, $event);
    }

    getDataFromExpression(data: any, exp: String) {
        if (data) {
            return Util.ResolveProperty(exp, data);
        }
        return undefined;
    }

    setDataFromExpression(data: any, exp: String, val: any) {
        if (data) {
            Util.SetPropertyValue(exp, data, val);
        }
    }

    getButtonCell(cellData: any) {
        if (cellData.column.dataField) {
            Util.ResolveProperty(cellData.column.dataField, cellData.data);
        }
        else {
            return cellData.column.Text;
        }
    }

    rowClick(data: any) {
        if (this.buttonClicked) {
            this.buttonClicked = false;

            for (this.buttonRowIndex = 0; this.buttonRowIndex < this.dataSource.length; this.buttonRowIndex++) {
                if (this.SelectedObject == this.dataSource[this.buttonRowIndex]) {
                    this.owningRow = <TTGridRow>{
                        TTObject: data.data
                    };
                    break;
                }
            }

            this.CellContentClicked.emit({
                RowIndex: this.buttonRowIndex,
                ColIndex: this.buttonColIndex,
                Row: this.owningRow,
                Column: this.owningColumn
            });
        }
    }

    addNewClicked() {
        this.gridInstance.instance.addRow();
        this.gridInstance.instance.saveEditData();
    }

    contentClicked(cfg: any, index: number, cellData: any) {
        let col = cfg.Column;
        let row = cfg.Row;
        if (col.isDeleteButtonColumn) {
            const rowData = cellData.row.data;
            let deleteRow: boolean = true;
            if (this.ComfirmRowDeleting) {
                let tempDeleteRow = this.ComfirmRowDeleting(rowData);
                if (tempDeleteRow == false)
                    deleteRow = false;
            }
            if (deleteRow) {
                    if (rowData && TTObjectHelper.isTTObjectFromProperty(rowData) && rowData.IsNew != true) {
                        //let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', 'Uyarı', 'Kayıt Silinecek',
                        //    'Bu kaydı silmek istediğinize emin misiniz?');
                        //if (result === 'T') {

                        if (this.CancelByDeleteButton) {
                            rowData.EntityState = EntityStateEnum.Cancelled;
                            this.gridInstance.instance.filter(['EntityState', '<>', 4]);
                            this.gridInstance.instance.refresh();
                        }
                        else {
                            rowData.EntityState = EntityStateEnum.Deleted;
                            this.gridInstance.instance.filter(['EntityState', '<>', 1]);
                            this.gridInstance.instance.refresh();
                        }
                        //}
                    } else {
                        //'Bu kaydı silmek istediğinize emin misiniz?' hatası vermesi için tr.json dosyasında  "dxDataGrid-editingConfirmDeleteMessage":  ="Bu kaydı silmek istediğinize emin misiniz?" yazılmalı
                        const targetRowIndex = (<Array<any>>this.gridInstance.dataSource).indexOf(rowData);
                        this.gridInstance.instance.deleteRow(targetRowIndex);
                    }
                    this.deleted(rowData);
            }
            return;
        }
        for (this.buttonColIndex = 0; this.buttonColIndex < this.Columns.length; this.buttonColIndex++) {
            this.owningColumn = <TTGridColumn>this.Columns[this.buttonColIndex];
            if (this.owningColumn && this.owningColumn.Name == col.Name) {
                break;
            }
        }
        for (this.buttonRowIndex = 0; this.buttonRowIndex < this.dataSource.length; this.buttonRowIndex++) {
            if (row == this.dataSource[this.buttonRowIndex]) {
                this.owningRow = <TTGridRow>{
                    TTObject: row
                };
                break;
            }
        }
        this.CellContentClicked.emit({
            RowIndex: this.buttonRowIndex,
            ColIndex: this.buttonColIndex,
            Row: this.owningRow,
            Column: this.owningColumn
        });
    }

    selectionChanged(rowData: any) {
        this.SelectedObject = this.gridInstance.selectedRowKeys[0];
        this.SelectedObjectChange.emit(this.SelectedObject);
    }

    rowInserting(rowData: any) {
        this.RowInserting.emit(rowData.data);
    }

    rowInserted(rowData: any) {
        this.TotalNumberOfRows = this.gridInstance.instance.totalCount();
    }

    initNewRow(rowData: any) {
        if (this.FilterColumnName && this.SelectedFilterObject) {
            let column = this.Columns.find((value): boolean => {
                return value.Name == this.FilterColumnName;
            });
            if (column && column.DataMember) {
                Util.SetPropertyValue(column.DataMember, rowData.data, this.SelectedFilterObject);
            }
            this.SelectedFilterChanged.emit(rowData.data);
            this.SelectedFilterObject = null;
        }
        this.InitNewRow.emit(rowData.data);
    }

    ngAfterViewInit() {
        this.RefreshColumns();
        super.ngAfterViewInit();
        this.RefreshFilter();
    }

    CellChanged(config: any, value: any, rowIndex: number) {
        let colIndex: number;
        //let rowIndex: number;
        let owningColumn: any, owningRow: any;
        for (colIndex = 0; colIndex < this.Columns.length; colIndex++) {
            owningColumn = <TTGridColumn>this.Columns[colIndex];
            if (owningColumn.Name == config.Name) {
                break;
            }
        }

        owningRow = <TTGridRow>{};
        owningRow.TTObject = this.dataSource[rowIndex];

        this.CellValueChange.emit({
            RowIndex: rowIndex,
            ColIndex: colIndex,
            Row: owningRow,
            Column: owningColumn,
            Value: value
        });
    }

    rowPrepared(event: any) {
        if (event.rowType == "data") {
            event.data.RadioGroupName = Guid.newGuid();
        }
        this.RowPrepared.emit(event);
    }

    deleted(event: any) {
        this.TotalNumberOfRows = this.gridInstance.instance.totalCount();
        this.RowRemoved.emit(event);
    }
}