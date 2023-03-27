import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { DynamicComponentInfoDVO } from '../Models/LogisticMainViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';

@Component({
    selector: 'dashboard-action-component',
    template: `
<div class="col-xs-12">
    <comp-compose [Info]="componentInfo"></comp-compose>
</div>
 `
})
export class DashboardActionComponent implements IModal {

    public componentInfo: DynamicComponentInfo;
    private _modalInfo: ModalInfo;


    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
    }

    public async setInputParam(value: Object) {
        await this.http.get<DynamicComponentInfoDVO>('api/LogisticWorkList/GetDynamicComponentInfo?ObjectId=' + value).then((res: DynamicComponentInfoDVO) => {
            let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
            compInfo.ComponentName = res.ComponentName;
            compInfo.ModuleName = res.ModuleName;
            compInfo.ModulePath = res.ModulePath;
            compInfo.objectID = res.objectID;
            this.componentInfo = compInfo;
        });
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public closeClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }
}