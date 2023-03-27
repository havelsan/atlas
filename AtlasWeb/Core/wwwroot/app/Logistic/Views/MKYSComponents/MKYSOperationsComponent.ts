import { Component, OnInit, Input } from '@angular/core';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { DocumentRecordLogReceiptNumber_Input, StockActionService } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { MkysServis } from 'app/NebulaClient/Services/External/MkysServis';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { MKYSInputModel } from '../GirisIslemleriComponents/CreateEntryTicketComponent';
import { UsernamePwdBox } from 'app/NebulaClient/Visual/UsernamePwdBox';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';

@Component({
    selector: 'mkys-operations',
    templateUrl: './MKYSOperationsComponent.html'
})

export class MKYSOperationsComponent implements OnInit {

    @Input("input") InputModel: MKYSInputModel;
    mkysSonucMesaj: string = "";
    isSearchComponentOpen: boolean = false;
    constructor(protected httpService: NeHttpService, protected modalService: IModalService) {

    }

    ngOnInit() { }


    async sendMKYS() {
        let result = await UsernamePwdBox.Show(true);
        let params = <any>(<ModalActionResult>result).Param;
        this.mkysSonucMesaj = await StockActionService.SendMKYSForInputDocument(this.InputModel.StockActionId, params.password);

    }

    async removeFromMKYS() {
        let result = await UsernamePwdBox.Show(true);
        let params = <any>(<ModalActionResult>result).Param;
        this.mkysSonucMesaj = await StockActionService.SendDeleteToMkys(this.InputModel.StockActionId, params.password, this.InputModel.ReceiptNumber);
        ServiceLocator.MessageService.showInfo(this.mkysSonucMesaj);
    }

    searchMKYS() {
        this.isSearchComponentOpen = true;
    }

    async MKYSLogs() {
        let input: DocumentRecordLogReceiptNumber_Input = new DocumentRecordLogReceiptNumber_Input();
        input.receiptNumber = this.InputModel.ReceiptNumber;
        let getLogs: Array<MkysServis.stokHareketLogItem> = await StockActionService.GetMkysLogSearch(input);
        this.showSelectMkysLog(getLogs);
    }

    private showSelectMkysLog(data: Array<MkysServis.stokHareketLogItem>): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "MkysLogComponent";
            componentInfo.ModuleName = "LogisticFormsModule";
            componentInfo.ModulePath = "/app/Logistic/LogisticFormsModule";
            componentInfo.InputParam = new DynamicComponentInputParam(data, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "MKYS Log Sorgu";
            modalInfo.Width = 1200;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
}