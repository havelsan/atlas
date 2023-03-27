import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";
import { InputFormModel } from "Fw/Models/InputFormModel";
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { ComboListItem } from "NebulaClient/Visual/ComboListItem";

@Component({
    selector: "hvl-inputformgettext-component",
    template: `
    <div>
        <div class="col-sm-12" style="text-align: center">
            <dx-text-box [(value)]="txtVal"></dx-text-box>
             <br />
        </div>
        <div class="col-sm-8" style="float: left">
            <dx-button type="default" text="Tamam" (onClick)="okClick()"></dx-button>
        </div>
        <div class="col-sm-4" style="float: right">
            <dx-button type="danger" text="İptal" (onClick)="cancelClick()"></dx-button>
        </div>
    </div>
    `,
})
export class GetTextComponent implements IModal {
    public _getText: InputFormModel;
    public _modalInfo: ModalInfo;
    public txtVal: string;

    constructor(private modalStateService: ModalStateService) {
        this.txtVal = "";
    }

    public setInputParam(value: Object) {
        this._getText = value as InputFormModel;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }


    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, null);
    }

    public okClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.txtVal);
    }

}

@Component({
    selector: "hvl-inputformgettext-component",
    template: `
    <div>
        <div class="col-sm-12" style="text-align: center">
            <dx-text-area [(value)]="txtVal"></dx-text-area>
             <br />
        </div>
        <div class="col-sm-8" style="float: left">
            <dx-button type="default" text="Tamam"  style="width:70px" (onClick)="okClick()"></dx-button>
        </div>
        <div class="col-sm-4" style="float: right">
            <dx-button type="danger" text="İptal"  style="width:60px" (onClick)="cancelClick()"></dx-button>
        </div>
    </div>
    `,
})
export class GetTextComponentMultiple implements IModal {
    public _getText: InputFormModel;
    public _modalInfo: ModalInfo;
    public txtVal: string;

    constructor(private modalStateService: ModalStateService) {
        this.txtVal = "";
    }

    public setInputParam(value: Object) {
        this._getText = value as InputFormModel;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }


    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, null);
    }

    public okClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.txtVal);
    }

}

@Component({
    selector: "hvl-inputformgetdate-component",
    template: `
    <div>
        <div class="col-sm-8" style="text-align: center">
            <dx-date-box type="date" width="230.1375px" [(value)]="dateVal"></dx-date-box>
            <br />
        </div>
        <div class="col-sm-8" style="float: left">
            <dx-button type="default" text="Tamam"  style="width:70px" (onClick)="okClick()"></dx-button>
        </div>
        <div class="col-sm-4" style="float: right">
            <dx-button type="danger" text="İptal"  style="width:60px" (onClick)="cancelClick()"></dx-button>
        </div>
    </div>
    `,
})
export class GetDateComponent implements IModal {
    public _getDate: InputFormModel;
    public _modalInfo: ModalInfo;
    public dateVal: Date;

    constructor(private modalStateService: ModalStateService) {
        this.dateVal = new Date();
    }

    public setInputParam(value: Object) {
        this._getDate = value as InputFormModel;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }


    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, null);
    }

    public okClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.dateVal);
    }

}

@Component({
    selector: "hvl-inputformgetvalue-component",
    template: `
    <div>
        <div class="col-sm-12" style="text-align: center">
               <dx-select-box [(value)]="selectedVal" searchEnabled="true" [dataSource]="_getValue?.list" displayExpr="_displayText" placeholder="Seçim Yapınız..." valueExpr="_dataValue" (onSelectionChanged)="select($event)"></dx-select-box>
            <br />
        </div>
        <div class="col-sm-8" style="float: left">
            <dx-button type="default" text="Tamam"  style="width:70px" (onClick)="okClick()"></dx-button>
        </div>
        <div class="col-sm-4" style="float: right">
            <dx-button type="danger" text="İptal" style="width:60px" (onClick)="cancelClick()"></dx-button>
        </div>
    </div>
    `,
})
export class GetValueListComponent implements IModal {
    public _getValue: InputFormModel;
    public _modalInfo: ModalInfo;
    public selectedVal: ComboListItem;
    public selectedData: any = null;
    constructor(private modalStateService: ModalStateService) {

    }

    public setInputParam(value: Object) {
        this._getValue = value as InputFormModel;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public select(data: any) {
        this.selectedData = data.selectedItem;
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
    }

    public okClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.selectedData);
    }

}