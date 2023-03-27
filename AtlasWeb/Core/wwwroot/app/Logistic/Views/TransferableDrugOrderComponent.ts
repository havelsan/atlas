import { Component, ViewChild } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DxDataGridComponent } from 'devextreme-angular';
import { DrugOrderInfo_Output } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderGridComponentViewModel';
import { DocumentRecordLogCheckComponent_Input, CheckDocumentRecordLogForDelete_Output, DocumentRecordLogReceiptNumber_Input, StockActionService } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { GetReturnableDrugOrders_Output } from 'app/NebulaClient/Services/ObjectService/DrugReturnActionService';
import { DrugOrderIntroductionService } from 'app/NebulaClient/Services/ObjectService/DrugOrderIntroductionService';


@Component({
    selector: 'transferableDrugOrderComponent-component',
    template: `
<div class="col-sm-12">
    <dx-data-grid #transferableDrugOrderGrid [height]="240" [dataSource]="transferableDrugOrders" [columns]="TransferableDrugOrderGridColumns"
    [(selectedRowKeys)]="selectedTransferableDrugOrders">
        <dxo-selection mode="multiple" id="A31999"></dxo-selection>>
        <dxo-paging [pageSize]="100" id="A31078"></dxo-paging>
    </dx-data-grid>
    <br />
    <p class="navbar-text" style="color:red;font-weight: bold;">Tedavisi devam eden ilaç direktiflerini yeni servise transfer etmek ister misiniz ?</p>
    <br />
    <div class="col-sm-12">
        <div style="float: left">
            <dx-button type="default" text="Evet" style="width:150px" (onClick)="okClick()"></dx-button>
        </div>
        <div style="float: right">
            <dx-button type="danger" text="Hayır" style="width:150px" (onClick)="cancelClick()"></dx-button>
        </div>
    </div>
</div>
 `
})
export class TransferableDrugOrderComponent implements IModal {

    public componentInfo: DynamicComponentInfo;
    private _modalInfo: ModalInfo;
    public transferableDrugOrders: Array<GetReturnableDrugOrders_Output>;
    public selectedTransferableDrugOrders: Array<GetReturnableDrugOrders_Output> = new Array<GetReturnableDrugOrders_Output>();
    @ViewChild('transferableDrugOrderGrid') transferableDrugOrderGrid: DxDataGridComponent;
    public moveSchedule = false;
    public TransferableDrugOrderGridColumns = [
        {
            caption: '',
            dataField: 'objectID',
            allowEditing: false,
            visible: false
        },
        {
            caption: 'Order Tarihi',
            dataField: 'transactionDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'İlaç',
            dataField: 'drugName',
            allowEditing: false,
            width: 200
        },
        {
            caption: 'Doz Aralığı',
            dataField: 'frequency',
            allowEditing: false,
            alignment: 'right',
            width: 80
        },
        {
            caption: 'Doz Miktarı',
            dataField: 'doseAmount',
            dataType: 'number',
            allowEditing: false,
            alignment: 'left',
            width: 80
        },
        {
            caption: 'Kalan Doz',
            dataField: 'amount',
            dataType: 'number',
            allowEditing: false,
            alignment: 'left',
            width: 80
        },
    ];

    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
    }

    public async setInputParam(value: Array<GetReturnableDrugOrders_Output>) {
        this.transferableDrugOrders = value;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public async okClick(): Promise<void> {
        if (this.selectedTransferableDrugOrders.length > 0) {
            DrugOrderIntroductionService.UpdateTransferableDrugOrders(this.selectedTransferableDrugOrders).then(result => {
                if (result==="Transfer edilecek ilaç direktiflerinin seçimi yapıldı.") {
                    this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, null);
                    ServiceLocator.MessageService.showSuccess('result');
                } else {
                    ServiceLocator.MessageService.showError('Güncelleme yapılırken bir hata oluştu! ' + result);
                }
            });
            
        } else {
            ServiceLocator.MessageService.showError('İlaç Direktifi seçmediniz.');
            return;
        }
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, null);
    }
}