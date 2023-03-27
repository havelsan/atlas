import { Component, Input, Output, EventEmitter } from '@angular/core';
import { GridQueryResult } from '../Models/GridQueryResult';
import { QueryParams } from '../Models/QueryParams';
import { NqlQueryService } from '../Services/nql-query.service';
import { MessageService } from 'Fw/Services/MessageService';

@Component({
    selector: 'atlas-query-list-component',
    template: `
<div *ngIf="_gridDataSource.length > 0" class="col-sm-12">
    <dx-data-grid
        id="gridContainer"
        [hoverStateEnabled]="true"
        [showColumnLines]="true"
        [showRowLines]="true"
        [showBorders]="true"
        [rowAlternationEnabled]="true"
        (onSelectionChanged)="onSelectionChanged($event)"
        [dataSource]="_gridDataSource"
        [columns]="_gridColumns">
        <dxo-selection mode="single"></dxo-selection>
        <dxo-header-filter [visible]="true"></dxo-header-filter>
        <dxo-paging [pageSize]="10"></dxo-paging>
        <dxo-pager
            [showPageSizeSelector]="true"
            [allowedPageSizes]="[10, 20, 30, 40, 50]"
            [showInfo]="true">
        </dxo-pager>
    </dx-data-grid>
</div>
    `,
})
export class QueryListComponent {

    public _gridQueryResult: GridQueryResult;
    public _gridDataSource: Array<any> = new Array<any>();
    public _gridColumns: any;
    public _queryParams: QueryParams;

    @Input() set QueryParameters(value: QueryParams) {
        if (value != null) {
            if (value.ObjectDefID != null && (value.QueryDefID != null || value.QueryName != null)) {
                let gridQueryParams = new QueryParams();
                Object.assign(gridQueryParams, value);
                this._queryParams = gridQueryParams;
                this.loadList();
            }
        }
    }

    @Output() onSelectedItemChanged: EventEmitter<any> = new EventEmitter<any>();
    @Output() QueryResultLoaded: EventEmitter<any> = new EventEmitter<any>();
    @Output() QueryExecutionCompleted: EventEmitter<boolean> = new EventEmitter<boolean>();

    get QueryParameters(): QueryParams {
        return this._queryParams;
    }

    constructor(private queryService: NqlQueryService, private messageService: MessageService) {
    }

    loadList() {

        this.queryService.runNQL(this._queryParams).then(result => {
            this._gridDataSource = result.QueryResult;
            this._gridQueryResult = result;
            let gridColumns = this._gridQueryResult.QueryColumns.map(c => {
                let dataColumnInfo: any = {};
                dataColumnInfo.dataField = c.DataField;
                dataColumnInfo.dataType = c.DataType;
                dataColumnInfo.caption = c.Caption;
                dataColumnInfo.alignment = c.Alignment;
                dataColumnInfo.visible = c.Visible;
                dataColumnInfo.visibleIndex = c.VisibleIndex;
                dataColumnInfo.width = c.Width;
                return dataColumnInfo;
            });
            this._gridColumns = gridColumns;
            this.QueryResultLoaded.emit(this._gridColumns);
            return true;
        }).catch(error => {
            this.messageService.showError(error);
            return false;
        }).then(p => {
            this.QueryExecutionCompleted.emit(p);
        });
    }

    onSelectionChanged(e: any) {
        if (e.selectedRowsData != null) {
            if (e.selectedRowsData instanceof Array) {
                let rowDataArray = e.selectedRowsData as Array<any>;
                if (rowDataArray.length > 0) {
                    let selectedRowData = rowDataArray[0];
                    this.onSelectedItemChanged.emit(selectedRowData);
                }
            }
        }
    }
    ///// class
}