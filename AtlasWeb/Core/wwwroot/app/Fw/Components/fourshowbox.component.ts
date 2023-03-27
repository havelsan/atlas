import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { ShowBoxModel } from 'Fw/Models/ShowBoxModel';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';

@Component({
    selector: 'hvl-four-showbox-component',
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
                    <dx-button type="success" [text]="_showBox?.applyButtonCaption" style="margin-left: 25%; margin-right: auto" (onClick)="applyClick()"></dx-button>
                </dxi-item>
                <dxi-item [ratio]="50" align="center" crossAlign="center">
                    <dx-button type="default" [text]="_showBox?.okButtonCaption" style=" margin-left: 25%; margin-right: auto" (onClick)="okClick()"></dx-button>
                </dxi-item>
                <dxi-item [ratio]="50" align="center" crossAlign="center">
                    <dx-button type="danger" [text]="_showBox?.cancelButtonCaption" style="margin-left: auto; margin-right: 25%" (onClick)="cancelClick()"></dx-button>
                </dxi-item>
                <dxi-item [ratio]="50" align="center" crossAlign="center">
                    <dx-button type="default" [text]="_showBox?.extraButtonCaption" style=" margin-left: 25%; margin-right: auto" (onClick)="extraClick()"></dx-button>
                </dxi-item>
            </dx-box>
        </dxi-item>
    </dx-box>
</div>
    `,
})
export class FourShowBoxComponent implements IModal {
    public _showBox: ShowBoxModel;
    private _modalInfo: ModalInfo;
    private cancelRetVal: string;
    private okRetVal: string;
    private applyRetVal: string;
    private extraRetVal: string;

    constructor(private modalStateService: ModalStateService) {
        this.okRetVal = '';
        this.cancelRetVal = '';
        this.applyRetVal = '';
        this.extraRetVal = '';
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

    public applyClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._showBox.applyRetValue);
    }

    public extraClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._showBox.extraRetValue);
    }

}