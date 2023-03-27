import { Component, OnInit, Input } from '@angular/core';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { MKYSInputModel } from './CreateEntryTicketComponent';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { UTSReceiveNotificationResultViewModel, UTSReceiveNotificationSendViewModel } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/ChattelDocumentWithPurchaseCompletedFormViewModel';

@Component({
    selector: 'other-operations',
    templateUrl: './OtherOperationsComponent.html'
})

export class OtherOperationsComponent implements OnInit {
    @Input("input") InputModel: MKYSInputModel;
    XMLIn: string = "";
    XMLOut: string = "";
    showUTSButton: boolean = true;
    isXMLReaderOpen: boolean = false;
    isSatinAlmadanSorgulaOpen: boolean = false;
    constructor(protected httpService: NeHttpService) { }

    ngOnInit() {

    }

    async receivedNotification() {
        var updateList: Array<UTSReceiveNotificationSendViewModel> = new Array<UTSReceiveNotificationSendViewModel>();
        var record: UTSReceiveNotificationSendViewModel;

        for (let material of this.InputModel.MaterialList) {
            if (material.IsIndividualTrackingRequired && (material.ReceiveNotificationID == null || material.ReceiveNotificationID == "")) {
                record = new UTSReceiveNotificationSendViewModel();
                record.ObjectId = material.ObjectID.toString();
                record.Amount = material.Amount;
                record.IncomingDeliveryNotifID = material.IncomingDeliveryNotifID;
                updateList.push(record);
            }
        }

        try {
            await this.httpService.post<any>('/api/UTSIslemleriService/MakeUTSReceiveNotificationForAll', updateList).then(response => {
                let result: Array<UTSReceiveNotificationResultViewModel> = response;
                if (result) {
                    for (let item of result) {
                        if (item.ReceiveNotificationID != null) {
                            this.InputModel.MaterialList.find(p => p.ObjectID.toString() == item.ObjectId).ReceiveNotificationID = item.ReceiveNotificationID;
                        } else {
                            ServiceLocator.MessageService.showError("Hata : " + item.Message);
                        }

                    }
                }
            });
        } catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    query() {
        this.isSatinAlmadanSorgulaOpen = true;
    }

    readXML() {
        this.isXMLReaderOpen = true;
        this.httpService.get('/api/EntryOperation/GetXMLForStockAction?stockActionId=' + this.InputModel.StockActionId).then(p => {
            let result = p as any;
            this.XMLIn = result.XMLIn;
            this.XMLOut = result.XMLOut;
        });
    }
}