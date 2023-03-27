//$398D7435
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ProcedureResultInfoFormViewModel } from './ProcedureResultInfoFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { ProcedureResultInfo } from 'NebulaClient/Model/AtlasClientModel';

import { IModal, ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'ProcedureResultInfoForm',
    templateUrl: './ProcedureResultInfoForm.html',
    providers: [MessageService]
})
export class ProcedureResultInfoForm extends BaseAdditionalInfoForm implements OnInit {
    labelResult: TTVisual.ITTLabel;
    Result: TTVisual.ITTTextBox;
    public procedureResultInfoFormViewModel: ProcedureResultInfoFormViewModel = new ProcedureResultInfoFormViewModel();
    public get _ProcedureResultInfo(): ProcedureResultInfo {
        return this._TTObject as ProcedureResultInfo;
    }
    private ProcedureResultInfoForm_DocumentUrl: string = '/api/ProcedureResultInfoService/ProcedureResultInfoForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.ProcedureResultInfoForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ProcedureResultInfo();
        this.procedureResultInfoFormViewModel = new ProcedureResultInfoFormViewModel();
        this._ViewModel = this.procedureResultInfoFormViewModel;
        this.procedureResultInfoFormViewModel._ProcedureResultInfo = this._TTObject as ProcedureResultInfo;
    }

    protected loadViewModel() {
        let that = this;
        that.procedureResultInfoFormViewModel = this._ViewModel as ProcedureResultInfoFormViewModel;
        that._TTObject = this.procedureResultInfoFormViewModel._ProcedureResultInfo;
        if (this.procedureResultInfoFormViewModel == null)
            this.procedureResultInfoFormViewModel = new ProcedureResultInfoFormViewModel();
        if (this.procedureResultInfoFormViewModel._ProcedureResultInfo == null)
            this.procedureResultInfoFormViewModel._ProcedureResultInfo = new ProcedureResultInfo();

    }

    async ngOnInit() {
        await this.load(ProcedureResultInfoFormViewModel);
    }

    public onResultChanged(event): void {
        if (this._ProcedureResultInfo != null && this._ProcedureResultInfo.Result != event) {
            this._ProcedureResultInfo.Result = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Result, "Text", this.__ttObject, "Result");
    }

    public initFormControls(): void {
        this.labelResult = new TTVisual.TTLabel();
        this.labelResult.Text = "Sonuç Değeri";
        this.labelResult.Name = "labelResult";
        this.labelResult.TabIndex = 1;

        this.Result = new TTVisual.TTTextBox();
        this.Result.Name = "Result";
        this.Result.TabIndex = 0;

        this.Controls = [this.labelResult, this.Result];

    }


}
