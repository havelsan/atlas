import { Component, ViewChild } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DxDataGridComponent } from 'devextreme-angular';
import { DrugOrderInfo_Output } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderGridComponentViewModel';
import { DocumentRecordLogCheckComponent_Input, CheckDocumentRecordLogForDelete_Output, DocumentRecordLogReceiptNumber_Input, StockActionService } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';


@Component({
    selector: 'documentrecordlogCheck-component',
    template: `
<div class="col-sm-12">
    <dx-data-grid #documentRecordLogCheckGrid [height]="250" [dataSource]="deleteDocumentRecordLog" [columns]="DocumentRecordLogCheckGridColumns">
        <dxo-paging [pageSize]="100" id="A31078"></dxo-paging>
    </dx-data-grid>
    <br />
    <div class="col-sm-12">
        <div style="float: left">
            <dx-button type="default" text="Tümünü İptal Et" style="width:150px" (onClick)="okClick()"></dx-button>
        </div>
        <div style="float: right">
            <dx-button type="danger" text="Vazgeç" style="width:150px" (onClick)="cancelClick()"></dx-button>
        </div>
    </div>
</div>
 `
})
export class DocumentRecordLogCheckComponent implements IModal {

    public componentInfo: DynamicComponentInfo;
    private _modalInfo: ModalInfo;
    public deleteDocumentRecordLog: Array<CheckDocumentRecordLogForDelete_Output>;
    public password: string;
    @ViewChild('documentRecordLogCheckGrid') documentRecordLogCheckGrid: DxDataGridComponent;
    public moveSchedule = false;
    public DocumentRecordLogCheckGridColumns = [
        {
            caption: 'ObjectID',
            dataField: 'DocumentRecordLogID',
            allowEditing: false,
            visible: false
        },
        {
            caption: 'İşlem No',
            dataField: 'StockActionID',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'TİF NO',
            dataField: 'DocumentRecordLogNo',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'Ayniyat Makbuz No',
            dataField: 'ReceiptNumber',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'İşlem',
            dataField: 'StockActionName',
            dataType: 'string',
            allowEditing: false,
            width: 'auto'
        },
    ];

    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
    }

    public async setInputParam(value: DocumentRecordLogCheckComponent_Input) {
        this.deleteDocumentRecordLog = value.DeleteDocumentRecordLog;
        this.password = value.Password;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public async okClick(): Promise<void> {
        let error: boolean = false;
        for (let deleteDoc of this.deleteDocumentRecordLog) {
            let input: DocumentRecordLogReceiptNumber_Input = new DocumentRecordLogReceiptNumber_Input();
            input.password = this.password;
            input.documentRecordLogObjectID = deleteDoc.DocumentRecordLogID.toString()
            try {
                let deleteMessage: boolean = await StockActionService.DeleteMkysSelectedRow(input);
                if (deleteMessage) {
                    deleteDoc.ReceiptNumber = null;
                } else {
                    error = true;
                }
            } catch {
                error = true;
            }
        }
        if (error) {
            ServiceLocator.MessageService.showError("Tekrar Deneyiniz Silme İşlemi Sırasında Hata Alındı.");
        } else {
            ServiceLocator.MessageService.showInfo("MKYS'den Silme yapılmıştır.");
            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, null);
        }
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, null);
    }
}