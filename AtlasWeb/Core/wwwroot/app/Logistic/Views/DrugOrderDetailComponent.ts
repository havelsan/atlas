import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
@Component({
    selector: 'drugorderdetail-component',
    template: `
<div class="col-xs-12">
    <comp-compose [Info]="componentInfo"></comp-compose>
</div>
 `
})
export class DrugOrderDetailComponent implements IModal {

    public componentInfo: DynamicComponentInfo;
    private _modalInfo: ModalInfo;


    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
    }

    public async setInputParam(value: Object) {
        let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
        compInfo.ComponentName = 'DrugOrderDetailForm';
        compInfo.ModuleName = 'TedaviIlacUgulamaModule';
        compInfo.ModulePath = 'Modules/Saglik_Lojistik/Eczane_Modulleri/Tedavi_Ilac_Ugulama_Modulu/TedaviIlacUgulamaModule';
        compInfo.objectID = value.toString();
        this.componentInfo = compInfo;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public closeClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }
}