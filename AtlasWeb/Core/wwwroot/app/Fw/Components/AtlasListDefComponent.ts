import { Component, Input, OnInit, SimpleChange } from '@angular/core';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { AtlasObjectDefinitionService } from 'Fw/Services/AtlasObjectDefinitionService';
import { AtlasListDefinition } from 'Fw/Models/AtlasListDefinition';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { ListDefinitionWithResultInput } from "Fw/Models/ListDefinitionWithResultInput";

@Component({
    selector: 'atlas-listdef-component',
    template: `
<dx-box direction="col" width="100%" [height]="'420px'">
    <dxi-item [ratio]="1">
        <h4 style='margin: 0px'>{{listDefinition?.Caption}}</h4>
    </dxi-item>
    <dxi-item [ratio]="8">
        <dx-data-grid [height]='300' [dataSource]="gridList" [columns]="gridColumns" (onSelectionChanged)="selectionChanged($event)"
         (onRowClick)="rowClick($event)" >
            <dxo-selection mode="single"></dxo-selection>
            <dxo-load-panel [enabled]="true"></dxo-load-panel>
            <dxo-scrolling mode="virtual"></dxo-scrolling>
            <dxo-filter-row [visible]="showFilterRow" [applyFilter]="'auto'"></dxo-filter-row>
            <dxo-header-filter [visible]="showHeaderFilter"></dxo-header-filter>
            <dxo-search-panel [visible]="showSearchPanel" [width]="240" placeholder="Aranacak terim..."></dxo-search-panel>
        </dx-data-grid>
    </dxi-item>
    <dxi-item [ratio]="1">
        <dx-box direction="row" width="100%" [height]="25">
            <dxi-item [ratio]="40"></dxi-item>
            <dxi-item [ratio]="10">
                <dx-button type="danger" text="İptal" (onClick)="cancelClick()"></dx-button>
            </dxi-item>
            <dxi-item [ratio]="10">
                <dx-button type="default" text="Seç" (onClick)="selectClick()"></dx-button>
            </dxi-item>
        </dx-box>
    </dxi-item>
</dx-box>
`
})
export class AtlasListDefComponent implements OnInit, IModal {

    private _listDefID: Guid;
    @Input() set ListDefID(value: Guid) {
        this._listDefID = value;
    }
    get ListDefID(): Guid {
        return this._listDefID;
    }

    private _listDefName: string;
    @Input() set ListDefName(value: string) {
        this._listDefName = value;
    }
    get ListDefName(): string {
        return this._listDefName;
    }

    private _userFilterExpression: string;
    @Input() set UserFilterExpression(value: string) {
        this._userFilterExpression = value;
    }
    get UserFilterExpression(): string {
        return this._userFilterExpression;
    }

    private _inputParam: Object;
    public setInputParam(value: Object) {
        this._inputParam = value;

        if (typeof value === 'string') {
            const listDefName = value as string;
            this.ListDefName = listDefName;
        } else {
            if (value.hasOwnProperty('ListDefID')) {
                this.ListDefID = value['ListDefID'];
            }
            if (value.hasOwnProperty('ListDefName')) {
                this.ListDefName = value['ListDefName'];
            }
            if ( value.hasOwnProperty('UserFilterExpression')) {
                this.UserFilterExpression = value['UserFilterExpression'];
            }
        }
        if (this.ListDefID || this.ListDefName) {
            const input = new ListDefinitionWithResultInput();
            input.listDefID = this.ListDefID;
            input.listDefName = this.ListDefName;
            input.userFilterExpression = this.UserFilterExpression;
            this.loadListDefinition(input);
        }
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public listDefinition: AtlasListDefinition;
    public gridList: any = [];
    public gridColumns: Array<any> = [];
    public selectedRowsData: Array<any> = [];
    public showHeaderFilter = true;
    public showFilterRow = true;
    public showSearchPanel = false;
    private clickTimer: any;
    private lastRowCLickedId: any;

    constructor(private objecDefService: AtlasObjectDefinitionService, private modalStateService: ModalStateService) {
    }

    private setupGrid(listDef: AtlasListDefinition) {
        let gridColumns: Array<any> = new Array<any>();
        for (let listColumnDefinition of listDef.Columns) {
            let gridColumn: any = {};
            gridColumn.caption = listColumnDefinition.Caption;
            gridColumn.dataField = listColumnDefinition.MemberName;
            // gridColumn.dataType =
            // gridColumn.format
            gridColumn.name = listColumnDefinition.Name;
            gridColumn.visibleIndex = listColumnDefinition.ColumnOrder;
            if (listColumnDefinition.Name.toUpperCase() === 'OBJECTDEFNAME' || listColumnDefinition.Name.toUpperCase() === 'OBJECTID') {
                gridColumn.visible = false;
            }
            const colLookup = listColumnDefinition.Lookup;
            if (colLookup != null) {
                gridColumn.lookup = { dataSource: colLookup.DataSource, displayExpr: colLookup.DisplayExpression, valueExpr: colLookup.ValueExpression };
            }
            gridColumns.push(gridColumn);
        }
        this.gridColumns = gridColumns;
    }

    private loadListDefinition(input: ListDefinitionWithResultInput) {
        let that = this;
        this.objecDefService.getListDefinitionWithResult(input).then(result => {
            that.listDefinition = result;
            that.gridList = result.DataSource;
            that.setupGrid(result);
        }).catch(err => {
            console.log(err);
        });

    }

    ngOnChanges(changes: { [propName: string]: SimpleChange }) {
        let listDefID: Guid;
        let listDefName: string;
        let userFilterExpression: string;

        if (changes.hasOwnProperty('ListDefID')) {
            listDefID = changes['ListDefID'].currentValue;
        }
        if (changes.hasOwnProperty('ListDefName')) {
            listDefName = changes['ListDefName'].currentValue;
        }
        if (changes.hasOwnProperty('UserFilterExpression')) {
            userFilterExpression = changes['UserFilterExpression'].currentValue;
        }

        if (listDefID == null && listDefName == null) {
            this.listDefinition = null;
        }

        if ((listDefID != null && listDefID.toString() !== '') || (listDefName != null && listDefName !== '')) {
            const input = new ListDefinitionWithResultInput();
            input.listDefID = this.ListDefID;
            input.listDefName = this.ListDefName;
            input.userFilterExpression = this.UserFilterExpression;
            this.loadListDefinition(input);
        }
    }

    ngOnInit() {
    }

    cancelClick() {
        if (this._modalInfo != null) {
            this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, null);
        }
    }

    private getValue(obj: any) {
        if (this.listDefinition.ValuePropertyName) {
            return obj[this.listDefinition.ValuePropertyName];
        }

        const keys = Object.getOwnPropertyNames(obj);
        const objectIDKeyName = keys.find(item => item.toUpperCase() === 'OBJECTID');
        if (objectIDKeyName) {
            return obj[objectIDKeyName];
        }
        return null;
    }

    private getDisplayExpression(obj: any) {
        if (this.listDefinition.DisplayExpression) {
            let func = new Function('o', `return ${this.listDefinition.DisplayExpression}`);
            const displayExpression = func(obj);
            return displayExpression;
        } else if (this.listDefinition.Columns.length === 1) {
            const column = this.listDefinition.Columns[0];
            return obj[column.MemberName];
        }
        return null;
    }

    selectClick() {
        if (this._modalInfo != null) {
            let result: any = {};
            const obj = this.selectedRowsData[0];
            if (obj) {
                result = { DisplayText: this.getDisplayExpression(obj), Value: this.getValue(obj) };
            }
            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, result);
        }
    }

    selectionChanged(event: any) {
        this.selectedRowsData = [];
        if (event && event.selectedRowsData) {
            this.selectedRowsData = event.selectedRowsData;
        }
    }

    rowClick(event: any) {
        if (this.clickTimer && this.lastRowCLickedId === event.rowIndex) {
            clearTimeout(this.clickTimer);
            this.clickTimer = null;
            this.lastRowCLickedId = event.rowIndex;
            this.selectClick();
        } else {
            this.clickTimer = setTimeout(Function.prototype, 250);
        }
        this.lastRowCLickedId = event.rowIndex;
    }

}