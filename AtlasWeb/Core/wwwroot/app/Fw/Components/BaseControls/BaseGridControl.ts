import {ViewChild, SimpleChanges, OnChanges, KeyValueDiffers,
    IterableDiffers, ElementRef, DoCheck, EventEmitter, Directive
} from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import { BaseControl } from './BaseControl';
import { Util } from '../Util';
@Directive()
export abstract class BaseGridControl extends BaseControl implements DoCheck, OnChanges {

    @ViewChild(DxDataGridComponent) Grid: DxDataGridComponent;
    AllowUserToAddRows: Boolean = false;
    AllowUserToDeleteRows: Boolean = false;
    EnablePaging: Boolean;
    PageSize: Number;
    Columns: Array<any>;
    dataSource: any;
    PagingSettings: any;
    columnDifferences: any;
    columnPropertyDifferences: any = {};
    columnFontPropertyDifferences: any = {};
    RowDisablePath: string;

    GridColumns: any;

    SelectedObject: Array<any>;
    SelectedObjectChange: EventEmitter<any> = new EventEmitter<any>();

    Clear() {
        this.Grid.instance.deselectAll();
        this.ClearFilter();
    }

    public ClearFilter() {
        this.Grid.instance.clearFilter();
        if (this.Columns && this.Columns.length > 0) {
            for (let i = 0; i < this.Columns.length; i++) {
                this.GridColumns[i].filterValue = undefined;
            }
        }
    }

    constructor(differs: KeyValueDiffers,
        element: ElementRef,
        private iterableDiffers: IterableDiffers) {
        super(differs, element);
        this.GridColumns = new Array<any>();
        this.columnDifferences = iterableDiffers.find([]).create(null);
    }

    setHeight() {
        if (this.Grid) {
            this.Grid.height = this.height;
        }
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['height']) {
            this.setHeight();
        }
        if (changes['EnablePaging'] || changes['PageSize']) {
            if (this.EnablePaging) {
                this.PagingSettings = {
                    enabled: this.EnablePaging,
                    pageSize: this.PageSize
                };
            }
            else {
                this.PagingSettings = null;
            }
        }
        super.ngOnChanges(changes);
    }

    ngDoCheck() {
        super.ngDoCheck();
    }

    protected RefreshColumns() {
        this.GridColumns.length = 0;
        let cols = [];
        if (this.Columns) {
            for (let i = 0; i < this.Columns.length; i++) {
                let column = this.Columns[i];
                let col = this.createColumn(column, i);
                if (col) {
                    this.GridColumns.push(col);
                }
            }
        }
        if (this.Grid && this.Grid.instance) {
            this.Grid.instance.refresh();
        }
    }

    abstract createColumn(column: any, index: number): any;

    selectionChanged(rowData: any) {
        if (rowData.rowType == 'data') {
            if (this.RowDisablePath && Util.ResolveProperty(this.RowDisablePath, rowData.data) == true) {
                this.Grid.instance.clearSelection();
                return;
            }
            this.SelectedObject = rowData.data;
            this.SelectedObjectChange.emit(rowData.data);
        }
    }
}