import { Component } from '@angular/core';
import { ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";



@Component({
    selector: 'PopupTextAreaForm',
    templateUrl: './PopupTextAreaForm.html',
})
export class PopupTextAreaForm {
    public _getText: string;
    private _modalInfo: ModalInfo;
    public txtVal: string;

    constructor(private modalStateService: ModalStateService) {
        this.txtVal = "";
    }

    public setInputParam(value: string) {
        this.txtVal = value ;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public okClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.txtVal);
    }








}




