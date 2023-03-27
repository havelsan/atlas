import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MkysServis } from 'NebulaClient/Services/External/MkysServis';
@Component({
    selector: 'material-select-component',
    template: `

<div class="container-fluid">
    <div class="row">
        <dx-text-box
            [readOnly]="true"
            [hoverStateEnabled]="false"
            [value]="message">
        </dx-text-box>
    </div>

    <div class="row">
        <dx-data-grid [dataSource]="MkysLogDataList"
            [allowColumnResizing]="true"
            [columnAutoWidth]="true"
            style="height : 300px">
        </dx-data-grid>
    </div>
</div>
`
})
export class MkysLogComponent implements IModal {


    private _modalInfo: ModalInfo;
    private store: Store;
    message: string;
    MkysLogDataList: Array<MkysServis.stokHareketLogItem> = new Array<MkysServis.stokHareketLogItem>();


    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
    }

    ngOnInit() {
    }


    public setInputParam(value: Array<MkysServis.stokHareketLogItem>) {
        this.MkysLogDataList = value;
        if (this.MkysLogDataList.length > 0)
        {
            this.message = "MKYS Log Sorgulama Başarılı.";
        }
        else
        {
            this.message = "Seçilen Ayniyat Numarası için MKYS Log Sorgulama Gerçekleştirilemez.";
        }
    }
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }


}