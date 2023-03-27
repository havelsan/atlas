import {
    Component, SimpleChanges, OnChanges, KeyValueDiffers,
    IterableDiffers, ElementRef, DoCheck, EventEmitter
} from '@angular/core';
import { BaseGridControl } from './BaseControls/BaseGridControl';

@Component({
    selector: 'hvl-list-view',
    inputs: ['ReadOnly', 'Visible', 'BackColor', 'ForeColor', 'Enabled', 'EnablePaging', 'PageSize', 'AllowUserToDeleteRows',
        'Columns', 'Font', 'Items', 'SelectedObject', 'TabIndex', 'EnableFilter', 'height', 'RowDisablePath'],
    outputs: ['SelectedObjectChange', 'RowPrepared', 'RowRemoving'],
    template: '<dx-data-grid showColumnLines="true" showRowLines="true" [dataSource]="Items" [disabled]="!Enabled" [columns]="GridColumns" [height]="height" [selection]="{mode: \'single\',allowSelectAll: false}"\
    [allowColumnResizing]="true" allowColumnReordering="true" [paging]="PagingSettings" [editing]="Editing" [filterRow]="FilterConfig"\
    (onRowClick)="selectionChanged($event)" (onRowPrepared)="rowPrepared($event)" (onRowRemoving)="rowRemoving($event)">\
    </dx-data-grid>'
})
export class HvlListView extends BaseGridControl implements DoCheck, OnChanges {
    Items: Array<any>;
    EnableFilter: Boolean = false;
    FilterConfig: any;
    RowPrepared: EventEmitter<any> = new EventEmitter<any>();
    RowRemoving: EventEmitter<any> = new EventEmitter<any>();
    Editing: any;

    constructor(differs: KeyValueDiffers,
        element: ElementRef,
        iterableDiffers: IterableDiffers) {
        super(differs, element, iterableDiffers);
    }

    ngDoCheck() {
        super.ngDoCheck();
        let columnChanges: any = this.columnDifferences.diff(this.Columns);
        if (columnChanges) {
            this.RefreshColumns();
            this.columnDifferences = columnChanges;
        }
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['EnableFilter']) {
            if (this.EnableFilter) {
                this.FilterConfig = { visible: true };
            }
            else if (this.EnableFilter == undefined || this.EnableFilter == false) {
                this.FilterConfig = null;
            }
        }
        if (changes['AllowUserToDeleteRows']) {
            if (this.AllowUserToDeleteRows == undefined) {
                this.AllowUserToDeleteRows = false;
            }
            this.Editing = { allowAdding: false, allowDeleting: this.AllowUserToDeleteRows, allowUpdating: false, texts: { confirmDeleteMessage: ''} };
        }
        super.ngOnChanges(changes);
    }

    createColumn(column: any, index: number): any {
        let dataMember = "SubItems[" + index + "].Text";
        return {
            //filterOperations: ['contains', 'startswith', '='],
            dataField: dataMember,
            caption: column.Text,
            dataType: column.DataType,
            format: column.Format
        };
    }

    rowPrepared(event: any) {
        if (event.rowType == "data") {
            //if (this.RowDisablePath) {
            //    if (Util.ResolveProperty(this.RowDisablePath, event.data) == true) {
            //        event.rowElement.firstItem().css('background-color', 'gray');
            //    }
            //}
            this.RowPrepared.emit(event);
        }
    }

    rowRemoving(data: any) {
        this.RowRemoving.emit(data);
    }
}