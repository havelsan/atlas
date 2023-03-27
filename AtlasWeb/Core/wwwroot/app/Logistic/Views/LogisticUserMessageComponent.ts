import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseModel } from 'Fw/Models/BaseModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
@Component({
    selector: 'logistic-usermessage-component',
    template: `

<div class="container-fluid">
    <div class="row">
        <div class="col-sm-2">
            <div>Gönderilen</div>
        </div>
        <div class="col-sm-8">
            <dx-text-box [readOnly]="true" [hoverStateEnabled]="false" [value]="sentBy">
            </dx-text-box>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
           <div>Gönderen</div>
        </div>
        <div class="col-sm-8">
            <dx-text-box [readOnly]="true" [hoverStateEnabled]="false" [value]="senderBy">
            </dx-text-box>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
           <div>Konu</div>
        </div>
        <div class="col-sm-8">
             <dx-text-box [readOnly]="false" [hoverStateEnabled]="false" [(value)]="subject">
             </dx-text-box>
        </div>
    </div>
    <br />
    <div class="row">
        <dx-text-area [height]="90" [(value)]="valueForMessage">
        </dx-text-area>
    </div>
    <br />
    <div class="row">
        <div style="float: left">
            <dx-button type="success" icon="fa fa-paper-plane"  text="Gönder"  (onClick)="okClick()"></dx-button>
        </div>
        <div style="float: right">
            <dx-button  type="danger" icon="fa fa-undo" text="Vazgec" (onClick)="cancelClick()"></dx-button>
        </div>
    </div>
</div>
`
})
export class LogisticUserMessageComponent implements IModal {
    private _modalInfo: ModalInfo;
    valueForMessage: string;
    sentBy: string;
    senderBy: string;
    sentByObjectID: string;
    senderByObjectID: string;
    subject: string;

    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
    }

    ngOnInit() {
    }


    public setInputParam(value: LogisticUserMessageData) {
        this.senderBy = value.senderBy;
        this.sentBy = value.sentBy;
        this.sentByObjectID = value.sentByObjectID;
        this.senderByObjectID = value.senderByObjectID;
        this.valueForMessage = value.valueForMessage;
        this.subject = value.subject;
    }
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public okClick(): void {
        let inputDvo = new LogisticUserMessageData();
        inputDvo.sentByObjectID = this.sentByObjectID;
        inputDvo.valueForMessage = this.valueForMessage;
        inputDvo.subject = this.subject;
        let fullApiUrl: string = 'api/LogisticDashboard/SentToUserMessage';
        this.http.post(fullApiUrl, inputDvo)
            .then((res: any) => {
                ServiceLocator.MessageService.showSuccess("Mesaj Gönderildi");
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }
}

export class LogisticUserMessageData extends BaseModel {
    public sentBy: string;
    public senderBy: string;
    public valueForMessage: string;
    public sentByObjectID: string;
    public senderByObjectID: string;
    public subject: string;
}