import { Component, ViewChild } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { NursingOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DxDataGridComponent } from 'devextreme-angular';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import { NeSerializer } from 'NebulaClient/ClassTransformer/NeSerializer';


@Component({
    selector: 'nodtimeline-component',
    template: `
<p class="navbar-text" style="color:red"></p>
<div class="col-sm-12">
    <div class="col-sm-3" style="padding:0">
        <label>Zaman Çizelgesini Kaydır</label>
    </div>
    <div class="col-sm-1" style="padding:0" *ngIf="allowUpdate">
        <dx-check-box [(value)]="moveSchedule"></dx-check-box>
    </div>
</div>
<div class="col-xs-12">
    <dx-data-grid #nursingOrderDetailGrid [height]="250" [dataSource]="changedDrugOrderDetails" [columns]="NursingOrderDetailGridColumns"
    (onRowUpdating)="onRowUpdating($event)">
        <dxo-paging [pageSize]="100" id="A31078"></dxo-paging>
        <dxo-editing mode="cell" [allowUpdating]="allowUpdate" [allowAdding]="false">
        </dxo-editing>
    </dx-data-grid>
    <br />
    <div style="float: left" *ngIf="allowUpdate">
        <dx-button type="default" text="Değiştir" style="width:60px" (onClick)="okClick()"></dx-button>
    </div>
    <div style="float: right">
        <dx-button type="danger" text="Vazgeç" style="width:60px" (onClick)="cancelClick()"></dx-button>
    </div>
</div>
 `
})
export class NODTimeLineComponent implements IModal {

    public componentInfo: DynamicComponentInfo;
    private _modalInfo: ModalInfo;
    changedDrugOrderDetails: Array<NursingOrderDetail>;
    originalDrugOrderDetails: Array<NursingOrderDetail> = new Array<NursingOrderDetail>();
    @ViewChild('nursingOrderDetailGrid') nursingOrderDetailGrid: DxDataGridComponent;
    public moveSchedule = false;
    public allowUpdate = false;
    public NursingOrderDetailGridColumns = [
        // {
        //     caption: 'T',
        //     dataField: 'DetailNo',
        //     dataType: 'number',
        //     allowEditing: false,
        //     width: 'auto'
        // },
        {
            caption: 'Tarih',
            dataField: 'WorkListDate',
            dataType: "date",
            format: "shortDate"        },
        {
            caption: 'Saat',
            dataField: 'WorkListDate',
            dataType: "date",
            format: "shortTime",
            editorOptions: { type: "time" }
        }
    ];

    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
    }

    public onRowUpdating(event: any) {
        if (this.moveSchedule && event.oldData.WorkListDate != null && this.changedDrugOrderDetails.filter(x => x.WorkListDate > event.oldData.WorkListDate).length > 0) {
            if (new Date(event.newData.WorkListDate) < new Date(Date.now())) {
                //TODO error
                event.newData.WorkListDate = event.oldData.WorkListDate;
                ServiceLocator.MessageService.showError("Eski tarihli order veremezsiniz!");
            }
            else {
                let diff = +(new Date(event.newData.WorkListDate)) - +(new Date(event.oldData.WorkListDate));
                this.changedDrugOrderDetails.filter(x => x.WorkListDate > event.oldData.WorkListDate).forEach(element => {
                    element.WorkListDate = new Date(element.WorkListDate.toString()).AddMinutes(diff / 1000 / 60);
                });
            }
        }
        else{
            if (new Date(event.newData.WorkListDate) < new Date(Date.now())) {
                //TODO error
                event.newData.WorkListDate = event.oldData.WorkListDate;
                ServiceLocator.MessageService.showError("Eski tarihli order veremezsiniz!");
            }
        }
    }

    public async setInputParam(value: Array<NursingOrderDetail>) {
        let cloneArray = JSON.parse(NeSerializer.stringify(value));
        let typedCloneArray = plainToClass(NursingOrderDetail, cloneArray) as Array<NursingOrderDetail>;
        // typedCloneArray.forEach(element => {
        //     element.WorkListDate.setHours(element.WorkListDate.getHours() - element.WorkListDate.getTimezoneOffset() / 60)
        // });
        this.originalDrugOrderDetails = typedCloneArray;
        this.changedDrugOrderDetails = value as Array<NursingOrderDetail>;
        this.allowUpdate = typedCloneArray[0].IsNew;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, this.originalDrugOrderDetails);
    }

    public okClick(): void {
        this.nursingOrderDetailGrid.instance.closeEditCell();
        this.nursingOrderDetailGrid.instance.saveEditData();
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.changedDrugOrderDetails);
    }
}