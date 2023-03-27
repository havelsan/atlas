import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { ShowBoxModel } from 'Fw/Models/ShowBoxModel';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';

@Component({
    selector: 'hvl-showbox-component',
    template: `
    <div style="height: 100%; width: 100%">
    <dx-box direction="col" width="100%" height="100%" style="line-height: normal">
        <dxi-item [ratio]="80">
            <dx-scroll-view #scrollView style="margin-bottom: 10px">
                <div [innerHtml]="_showBox?.value"></div>
            </dx-scroll-view>
        </dxi-item>
        <dxi-item [ratio]="20">
            <dx-box direction="row" style="line-height: normal">
                <dxi-item [ratio]="50" align="center" crossAlign="center">
                    <dx-button type="default" [text]="_showBox?.okButtonCaption" id="SB15973" style="margin-left: 25%; margin-right: auto" (onClick)="okClick()"></dx-button>
                </dxi-item>
                <dxi-item [ratio]="50" align="center" crossAlign="center">
                    <dx-button type="danger" [text]="_showBox?.cancelButtonCaption" id="SB17382" style="margin-left: auto; margin-right: 25%" (onClick)="cancelClick()"></dx-button>
                </dxi-item>
            </dx-box>
        </dxi-item>
    </dx-box>
</div>
    `,
})
export class ShowBoxComponent implements IModal {
    public _showBox: ShowBoxModel;
    private _modalInfo: ModalInfo;
    private cancelRetVal: string;
    private okRetVal: string;

    constructor(private modalStateService: ModalStateService) {
        this.okRetVal = '';
        this.cancelRetVal = '';
    }

    public setInputParam(value: Object) {
        this._showBox = value as ShowBoxModel;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }


    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, this._showBox.cancelRetValue);
    }

    public okClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._showBox.okRetValue);
    }

}