//$E978F964
import { Component, ViewChild, OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { GivenInpatientAppointmentFormViewModel } from './GivenInpatientAppointmentFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { InpatientAppointment } from 'NebulaClient/Model/AtlasClientModel';

import { ModalInfo, ModalStateService } from '../../../wwwroot/app/Fw/Models/ModalInfo';
import { DialogResult } from '../../../wwwroot/app/NebulaClient/Utils/Enums/DialogResult';

@Component({
    selector: 'GivenInpatientAppointmentForm',
    templateUrl: './GivenInpatientAppointmentForm.html',
    providers: [MessageService]
})
export class GivenInpatientAppointmentForm extends TTVisual.TTForm implements OnInit {
    public givenInpatientAppointmentFormViewModel: GivenInpatientAppointmentFormViewModel = new GivenInpatientAppointmentFormViewModel();
    public get _InpatientAppointment(): InpatientAppointment {
        return this._TTObject as InpatientAppointment;
    }
    private GivenInpatientAppointmentForm_DocumentUrl: string = '/api/InpatientAppointmentService/GivenInpatientAppointmentForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super('INPATIENTAPPOINTMENT', 'GivenInpatientAppointmentForm');
        this._DocumentServiceUrl = this.GivenInpatientAppointmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected _modalInfo: ModalInfo;

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    inputParam: any;
    public async setInputParam(value: any) {
        this.inputParam = value;
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InpatientAppointment();
        this.givenInpatientAppointmentFormViewModel = new GivenInpatientAppointmentFormViewModel();
        this._ViewModel = this.givenInpatientAppointmentFormViewModel;
        this.givenInpatientAppointmentFormViewModel._InpatientAppointment = this._TTObject as InpatientAppointment;
    }

    protected loadViewModel() {
        let that = this;
        that.givenInpatientAppointmentFormViewModel = this._ViewModel as GivenInpatientAppointmentFormViewModel;
        that._TTObject = this.givenInpatientAppointmentFormViewModel._InpatientAppointment;
        if (this.givenInpatientAppointmentFormViewModel == null)
            this.givenInpatientAppointmentFormViewModel = new GivenInpatientAppointmentFormViewModel();
        if (this.givenInpatientAppointmentFormViewModel._InpatientAppointment == null)
            this.givenInpatientAppointmentFormViewModel._InpatientAppointment = new InpatientAppointment();

    }

    async ngOnInit() {
        await this.load(GivenInpatientAppointmentFormViewModel);
    }
    protected async save() {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.givenInpatientAppointmentFormViewModel.selectedRowKeysResultList);
    }
    public async cancel() {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, null);
    }


    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
