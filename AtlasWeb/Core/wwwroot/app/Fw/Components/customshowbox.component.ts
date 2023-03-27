import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { CustomShowBoxModel } from 'Fw/Models/CustomShowBoxModel';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';

@Component({
    selector: 'hvl-customshowbox-component',
    template: `
<div style="height: 100%; width: 100%">
    <dx-box direction="col" width="100%" height="100%" style="line-height: normal">
        <dxi-item [ratio]="60">
            <dx-scroll-view #scrollView style="margin-bottom: 10px">
                <div [innerHtml]="_customshowBox?.value" style="height:150px;overflow-y: scroll;"></div>
            </dx-scroll-view>
        </dxi-item>
        <dxi-item [ratio]="40">
             <dx-box direction="row" style="line-height: normal">
                    <div class="col-sm-6" style="text-align: center" *ngFor="let button of _customshowBox?.buttons;let i=index">
                        <dxi-item [ratio]="50" align="center" crossAlign="center" style="padding-left:5px;">
                            <dx-button type="default" [text]="button?.buttonCaption" style="margin-right: auto; margin-let:auto;" (onClick)="okClick(button?.buttonValue)"></dx-button>
                         </dxi-item>
                    </div>
            </dx-box>
        </dxi-item>
    </dx-box>
</div>
    `,
})
export class CustomShowBoxComponent implements IModal {
    public _customshowBox: CustomShowBoxModel;
    private _modalInfo: ModalInfo;

    constructor(private modalStateService: ModalStateService) {
    }

    public setInputParam(value: Object) {
        this._customshowBox = value as CustomShowBoxModel;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public okClick(value): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, value);
    }

}