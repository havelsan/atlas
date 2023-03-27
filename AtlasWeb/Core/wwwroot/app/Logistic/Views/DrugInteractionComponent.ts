import { Component,  ElementRef } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';

@Component({
    selector: 'drug-introduction-component',
    template: `
<div style="height:700px; width:100%" [innerHTML]="htmlContent | keepHtml"></div>
 <div style="float: left">
            <dx-button type="default" text="Devam" style="width:80px" (onClick)="okClick()"></dx-button>
        </div>
        <div style="float: right">
            <dx-button type="danger" text="Vazgeç" style="width:80px" (onClick)="cancelClick()"></dx-button>
        </div>
 `
})
export class DrugInteractionComponent implements IModal {
    private htmlContent: string;
    private _modalInfo: ModalInfo;

    private editorConfig: any = {
        height: '700px',
        removePlugins: 'toolbar,elementspath',
        resize_enabled: false,
        readOnly: true
    };

    constructor(private modalStateService: ModalStateService) {
    }

    public setInputParam(value: any) {
        this.htmlContent = value as string;
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