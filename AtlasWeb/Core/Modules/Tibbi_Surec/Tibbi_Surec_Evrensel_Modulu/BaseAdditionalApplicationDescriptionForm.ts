//$9F8CFEF8
import { Component, OnInit } from '@angular/core';
import { BaseAdditionalApplicationDescriptionFormViewModel } from './BaseAdditionalApplicationDescriptionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseAdditionalApplication } from 'NebulaClient/Model/AtlasClientModel';

import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { IModal, ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'BaseAdditionalApplicationDescriptionForm',
    templateUrl: './BaseAdditionalApplicationDescriptionForm.html',
    providers: [MessageService]
})
export class BaseAdditionalApplicationDescriptionForm extends TTVisual.TTForm implements OnInit, IModal {
    Description: string = '';
    labelDescription: TTVisual.ITTLabel;
    public baseAdditionalApplicationDescriptionFormViewModel: BaseAdditionalApplicationDescriptionFormViewModel = new BaseAdditionalApplicationDescriptionFormViewModel();
    public get _BaseAdditionalApplication(): BaseAdditionalApplication {
        return this._TTObject as BaseAdditionalApplication;
    }
    private BaseAdditionalApplicationDescriptionForm_DocumentUrl: string = '/api/BaseAdditionalApplicationService/BaseAdditionalApplicationDescriptionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super('BASEADDITIONALAPPLICATION', 'BaseAdditionalApplicationDescriptionForm');
        this._DocumentServiceUrl = this.BaseAdditionalApplicationDescriptionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BaseAdditionalApplication();
        this.baseAdditionalApplicationDescriptionFormViewModel = new BaseAdditionalApplicationDescriptionFormViewModel();
        this._ViewModel = this.baseAdditionalApplicationDescriptionFormViewModel;
        this.baseAdditionalApplicationDescriptionFormViewModel._BaseAdditionalApplication = this._TTObject as BaseAdditionalApplication;
    }

    protected loadViewModel() {
        let that = this;
        that.baseAdditionalApplicationDescriptionFormViewModel = this._ViewModel as BaseAdditionalApplicationDescriptionFormViewModel;
        that._TTObject = this.baseAdditionalApplicationDescriptionFormViewModel._BaseAdditionalApplication;
        if (this.baseAdditionalApplicationDescriptionFormViewModel == null)
            this.baseAdditionalApplicationDescriptionFormViewModel = new BaseAdditionalApplicationDescriptionFormViewModel();
        if (this.baseAdditionalApplicationDescriptionFormViewModel._BaseAdditionalApplication == null)
            this.baseAdditionalApplicationDescriptionFormViewModel._BaseAdditionalApplication = new BaseAdditionalApplication();

    }

    async ngOnInit() {
        await this.load();
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._BaseAdditionalApplication != null && this._BaseAdditionalApplication.Description != event) {
                this._BaseAdditionalApplication.Description = event;
            }
        }
    }


    // Popup olarak açıldığında Vievmodelini bunu açılan forma aktarabilmek için;
    protected _modalInfo: ModalInfo;

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }


    // Popup olarak açıldığında bunu çan formdan Input alabilmek için ;
    public async setInputParam(value: string) {
        this.Description = value;
    }



    //protected redirectProperties(): void {
    //    redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    //}

    public initFormControls(): void {
        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = "Lütfen Açıklama Giriniz!";
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 1;

    }

    public async save() {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.Description);
    }


}
