import { Component, ViewChild } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DxDataGridComponent } from 'devextreme-angular';
import { DrugOrderInfo_Output, StopDrugOrders_Input, StopDrugOrders_Output } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderGridComponentViewModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';

@Component({
    selector: 'drugorderinfo-component',
    template: `
    <div class="col-sm-12" style="text-align:center">
    <p style="color:red">{{drugOrderInfo.DrugName}}</p>
</div>
<div class="col-sm-12">
    <dx-data-grid #drugOrderInfoGrid [height]="250" [dataSource]="drugOrderInfo.DrugOrderInfoDetails" [columns]="DrugOrderInfoGridColumns">
        <dxo-paging [pageSize]="100" id="A31078"></dxo-paging>
        <div *dxTemplate="let data of 'buttonCellTemplate'">
            <dx-button [ngStyle]="{'height':'22px', 'font-size':'5px', 'padding':'0', 'width':'100%'}" text=""
                icon="trash" hint="iptal Et" (onClick)="StopDrugOrder(data)"></dx-button>
        </div>
    </dx-data-grid>
    <br />
    <div class="col-sm-12" style="text-align:center">
        <dx-button type="default" text="OK" style="width:60px" (onClick)="okClick()"></dx-button>
    </div>
</div>
 `
})
export class DrugOrderInfoComponent implements IModal {

    public componentInfo: DynamicComponentInfo;
    private _modalInfo: ModalInfo;
    drugOrderInfo: DrugOrderInfo_Output;
    @ViewChild('drugOrderInfoGrid') drugOrderInfoGrid: DxDataGridComponent;
    public moveSchedule = false;
    public DrugOrderInfoGridColumns = [
        {
            caption: 'Tedavi Tarih',
            dataField: 'OrderPlannedDate',
            dataType: "date",
            editorOptions: { type: "datetime" },
            allowEditing: false
        },
        {
            caption: 'Tedavi Saati',
            dataField: 'OrderPlannedDate',
            dataType: "date",
            format: "shortTime",
            editorOptions: { type: "time" },
            allowEditing: false
        },
        {
            caption: 'Order Veren Doktor',
            dataField: 'DoctorName',
            dataType: 'string',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'Order Verilme Tarihi',
            dataField: 'ActionDate',
            dataType: "date",
            format: "shortDateShortTime",
            allowEditing: false
        },
        {
            caption: 'Durumu',
            dataField: 'Status',
            dataType: 'string',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'EHU İptal Nedeni',
            dataField: 'EHUCancelReason',
            dataType: 'string',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: '',
            dataField: 'ObjectID',
            cellTemplate: 'buttonCellTemplate',
            alignment: 'center',
            allowResizing: false,
            allowEditing: false,
            fixedPosition: "right",
            fixed: true,
            cssClass: 'remove-padding',
            width: 'auto',
        }
    ];

    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
    }

    public async setInputParam(value: DrugOrderInfo_Output) {
        this.drugOrderInfo = value as DrugOrderInfo_Output;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public okClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, null);
    }

    public async StopDrugOrder(data: any) {
        if (data != null) {
            let rowKey: Guid;
            if (data.data != null)
                rowKey = data.data.ObjectID;

            if (data.data.Status === 'Planlandı') {
                let input: StopDrugOrders_Input = new StopDrugOrders_Input();
                let message = 'Direktif Durdurulacaktır! Devam etmek istiyor musunuz?';
                let result = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), i18n("M20924", "Direktif Durdur"),
                    message);
                if (result === 'T') {
                    input.DrugOrderObjectIDList = new Array<Guid>();
                    input.DrugOrderObjectIDList.push(rowKey);
                    this.http.post<StopDrugOrders_Output>('api/DrugOrderIntroductionService/StopDrugOrders', input).then(res => {
                        if (res.Result) {
                            TTVisual.InfoBox.Alert(res.ResultMessage);
                        }
                        else
                            TTVisual.InfoBox.Alert(res.ResultMessage);
                    });
                }
            }
            else
                TTVisual.InfoBox.Alert('Sadece Planlandı durumundaki direktfiler durdurulabilir!');
        }
    }
}