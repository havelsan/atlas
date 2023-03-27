//$B0F54848
import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { OutStockTransactionDVO, OutTransactionViewModel } from '../Models/OutTransactionViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DxDataGridComponent } from 'devextreme-angular';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DatePipe } from '@angular/common';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
@Component({
    selector: 'Out-Transaction-Modal-select-component',
    providers: [DatePipe],
    template: `
<div class="container-fluid">
    <div class="row">
    <dx-data-grid #grid id="outTrxGrid" [dataSource]="OutStockTransactionGridData" keyExpr="stockTransactionObjectID" [hoverStateEnabled]="true" [showBorders]="true">
        <dxo-export [enabled]="true" fileName="Cikis"></dxo-export>
        <dxo-filter-row [visible]="true"></dxo-filter-row>
        <dxi-column dataField="transactionDate" caption="Tarih" dataType="date"></dxi-column>
        <dxi-column dataField="trxType" caption="Tür" [width]="200"></dxi-column>
        <dxi-column dataField="trxDescription" caption="Hareket Türü" [width]="250"></dxi-column>
        <dxi-column dataField="storeName" caption="Geldiği/Gittiği Yer"></dxi-column>
        <dxi-column dataField="documentLogID" caption="Belge No"></dxi-column>
        <dxi-column dataField="stockActionID" caption="İşlem No"></dxi-column>
        <dxi-column dataField="amount" caption="Miktar"></dxi-column>
        <dxi-column dataField="expirationDate" caption="Son Kul.Tar." dataType="date"></dxi-column>
        <dxo-summary>
            <dxi-total-item column="transactionDate" summaryType="count" displayFormat="{0} satır">
            </dxi-total-item>
            <dxi-total-item column="amount" summaryType="sum" displayFormat="T.M.: {0}">
            </dxi-total-item>
        </dxo-summary>
    </dx-data-grid>
    </div>
    <br />
    <div class="row">
        <div style="float: right">
            <dx-button type="btn btn-default"  text="Kapat" style="width:60px" (onClick)="cancelClick()"></dx-button>
        </div>
    </div>
</div>
 `
})
export class OutTransactionModalComponent implements IModal {
    private _modalInfo: ModalInfo;
    private viewModel: OutTransactionViewModel;
    private store: any;
    private IncludeDrugDefinition: boolean;
    OutStockTransactionGridData: Array<OutStockTransactionDVO>;



    constructor(private modalStateService: ModalStateService, private http: NeHttpService, private datePipe: DatePipe) {
    }

    ngOnInit() {
        //this.getTreeList();
    }
    public setInputParam(value: Array<OutStockTransactionDVO>) {
        this.OutStockTransactionGridData = value;

    }
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    onAmountChanged(data, row) {
        row.data.Amount = data.value;
    }
}