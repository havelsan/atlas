import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";

@Component({
    selector: "hvl-infobox-component",
    template: `
<div style="height: 75%; width: 100%">
    <dx-scroll-view #scrollView style="margin-bottom: 10px">
        <div [innerHtml]="messageDetails"></div>
    </dx-scroll-view>
    <div style="padding-left:190px">
        <dx-button type="btn btn-default" text="Tamam" (onClick)="okClick()"></dx-button>
    </div>
</div>
    `,
})
export class InfoBoxComponent implements IModal {
    public _infoBox: any;
    private _modalInfo: ModalInfo;
    public messageDetails: string = "";
    constructor(private modalStateService: ModalStateService) {

    }

    public setInputParam(value: any) {
        this._infoBox = value;
        this.messageDetails = this._infoBox.messageDetails;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }


    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    public okClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
    }

}