import { Component, ViewChild } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DrugOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DxDataGridComponent } from 'devextreme-angular';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import { NeSerializer } from 'NebulaClient/ClassTransformer/NeSerializer';
import { asapScheduler } from 'rxjs';


@Component({
    selector: 'drugorderschedule-component',
    template: `
<p class="navbar-text" style="color:red"></p>
<div class="col-sm-12">
    <div class="col-sm-3" style="padding:0">
        <label>Zaman Çizelgesini Kaydır</label>
    </div>
    <div class="col-sm-1" style="padding:0">
        <dx-check-box [(value)]="moveSchedule"></dx-check-box>
    </div>
</div>
<div class="col-xs-12">
    <dx-data-grid #drugOrderDetailGrid [height]="250" [dataSource]="changedDrugOrderDetails" [columns]="DrugOrderDetailGridColumns"
    (onRowUpdating)="onRowUpdating($event)">
        <dxo-paging [pageSize]="100" id="A31078"></dxo-paging>
        <dxo-editing mode="cell" [allowUpdating]="true" [allowAdding]="false">
        </dxo-editing>
    </dx-data-grid>
    <br />
    <div style="float: left">
        <dx-button type="default" text="Değiştir" style="width:70px" (onClick)="okClick()"></dx-button>
    </div>
    <div style="float: right">
        <dx-button type="danger" text="Vazgeç" style="width:70px" (onClick)="cancelClick()"></dx-button>
    </div>
</div>
 `
})
export class DrugOrderScheduleComponent implements IModal {

    public componentInfo: DynamicComponentInfo;
    private _modalInfo: ModalInfo;
    changedDrugOrderDetails: Array<DrugOrderDetail>;
    originalDrugOrderDetails: Array<DrugOrderDetail> = new Array<DrugOrderDetail>();
    @ViewChild('drugOrderDetailGrid') drugOrderDetailGrid: DxDataGridComponent;
    public moveSchedule = false;
    public DrugOrderDetailGridColumns = [
        {
            caption: 'T',
            dataField: 'DetailNo',
            dataType: 'number',
            sortOrder: "asc",
            allowSorting: false,
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'Tarih',
            dataField: 'OrderPlannedDate',
            dataType: "date",
            format: "shortDateShortTime",
            allowSorting: false,
        },
        {
            caption: 'Saat',
            dataField: 'OrderPlannedDate',
            dataType: "date",
            format: "shortTime",
            allowSorting: false,
            editorOptions: { type: "time" }
        }
    ];

    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
    }

    public onRowUpdating(event: any) {
        if (event.oldData.OrderPlannedDate != null && this.changedDrugOrderDetails.filter(x => x.DetailNo > event.oldData.DetailNo).length > 0) {
            if (event.newData.OrderPlannedDate < new Date(Date.now())) {
                //TODO error
                event.newData.OrderPlannedDate = event.key.OrderPlannedDate;
                ServiceLocator.MessageService.showError("Eski tarihli order veremezsiniz!");
            }
            else {
                if (this.moveSchedule) {
                    let diff = +(new Date(event.newData.OrderPlannedDate)) - +(new Date(event.key.OrderPlannedDate));
                    this.changedDrugOrderDetails.filter(x => x.DetailNo > event.oldData.DetailNo).forEach(element => {
                        element.OrderPlannedDate = new Date(element.OrderPlannedDate.toString()).AddMinutes(diff / 1000 / 60);
                    });
                }
            }
        }
    }

    public async setInputParam(value: Array<DrugOrderDetail>) {
        let cloneArray = JSON.parse(NeSerializer.stringify(value));
        let typedCloneArray = plainToClass(DrugOrderDetail, cloneArray) as Array<DrugOrderDetail>;
       
        this.originalDrugOrderDetails = typedCloneArray;
        this.changedDrugOrderDetails = value as Array<DrugOrderDetail>;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, this.originalDrugOrderDetails);
    }

    public okClick(): void {
        this.drugOrderDetailGrid.instance.closeEditCell();
        this.drugOrderDetailGrid.instance.saveEditData();
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.changedDrugOrderDetails);
    }
}