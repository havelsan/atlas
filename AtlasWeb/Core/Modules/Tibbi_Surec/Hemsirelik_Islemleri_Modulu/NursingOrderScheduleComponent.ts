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
import { DatePipe } from '@angular/common';


@Component({
    selector: 'nursingorderschedule-component',
    providers: [DatePipe],
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
export class NursingOrderScheduleComponent implements IModal {

    public componentInfo: DynamicComponentInfo;
    private _modalInfo: ModalInfo;
    changedDrugOrderDetails: Array<NursingOrderDetail>;
    originalDrugOrderDetails: Array<NursingOrderDetail> = new Array<NursingOrderDetail>();
    @ViewChild('drugOrderDetailGrid') drugOrderDetailGrid: DxDataGridComponent;
    public moveSchedule = false;
    public DrugOrderDetailGridColumns = [
        {
            caption: 'T',
            dataField: 'ID',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'Tarih',
            dataField: 'WorkListDate',
            dataType: "date",
            format: "shortDateShortTime"
            // allowEditing: false

        },
        {
            caption: 'Saat',
            dataField: 'WorkListDate',
            dataType: "date",
            format: "shortTime",
            editorOptions: { type: "time" }
        }
    ];

    constructor(private modalStateService: ModalStateService, private http: NeHttpService, private datePipe: DatePipe) {
    }

    public onRowUpdating(event: any) {
        if (event.oldData.WorkListDate != null && this.changedDrugOrderDetails.filter(x => x.ID > event.oldData.ID).length > 0) {
            if (event.newData.WorkListDate < new Date(Date.now())) {
                //TODO error
                event.newData.WorkListDate = event.key.WorkListDate;
                ServiceLocator.MessageService.showError("Eski tarihli order veremezsiniz!");
            }
            else {
                if (this.moveSchedule) {
                    let diff = +(new Date(event.newData.WorkListDate)) - +(new Date(event.key.WorkListDate));
                    this.changedDrugOrderDetails.filter(x => x.ID > event.oldData.ID).forEach(element => {
                       
                        // console.log(this.datePipe.transform(element.WorkListDate.getTimezoneOffset, 'yyyy-MM-dd'));
                        // console.log(new Date(this.datePipe.transform(element.WorkListDate, 'yyyy-MM-dd')));    
                        element.WorkListDate = new Date(element.WorkListDate.toString()).AddMinutes(diff / 1000 / 60);
                        // console.log(this.datePipe.transform(element.WorkListDate, 'yyyy-MM-dd'));
                        // console.log(new Date(this.datePipe.transform(element.WorkListDate, 'yyyy-MM-dd')));                        
                        // console.log(element.WorkListDate);
                    });
                }
            }
        }
    }

    public async setInputParam(value: Array<NursingOrderDetail>) {
        let cloneArray = JSON.parse(NeSerializer.stringify(value));
        let typedCloneArray = plainToClass(NursingOrderDetail, cloneArray) as Array<NursingOrderDetail>;
       
        this.originalDrugOrderDetails = typedCloneArray;
        this.changedDrugOrderDetails = value as Array<NursingOrderDetail>;
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