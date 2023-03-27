//$98AE82FE
import { Component, ViewChild, OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { LongInpatientReasonFormViewModel } from './LongInpatientReasonFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { InPatientTreatmentClinicApplication } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'LongInpatientReasonForm',
    templateUrl: './LongInpatientReasonForm.html',
    providers: [MessageService]
})
export class LongInpatientReasonForm extends TTVisual.TTForm implements OnInit {
    LongInpatientReason: TTVisual.ITTTextBox;
    labelLongInpatientReason: TTVisual.ITTLabel;
    public longInpatientReasonFormViewModel: LongInpatientReasonFormViewModel = new LongInpatientReasonFormViewModel();
    public get _InPatientTreatmentClinicApplication(): InPatientTreatmentClinicApplication {
        return this._TTObject as InPatientTreatmentClinicApplication;
    }
    private LongInpatientReasonForm_DocumentUrl: string = '/api/InPatientTreatmentClinicApplicationService/LongInpatientReasonForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('INPATIENTTREATMENTCLINICAPPLICATION', 'LongInpatientReasonForm');
        this._DocumentServiceUrl = this.LongInpatientReasonForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PreScript(): Promise<void> {
        super.PreScript();
        this.DropStateButton(InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Acception);
        this.DropStateButton(InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Cancelled);
        this.DropStateButton(InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Discharged);
        this.DropStateButton(InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.PreAcception);
        this.DropStateButton(InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Procedure);
        this.DropStateButton(InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Rejected);
        this.DropStateButton(InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Transferred);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InPatientTreatmentClinicApplication();
        this.longInpatientReasonFormViewModel = new LongInpatientReasonFormViewModel();
        this._ViewModel = this.longInpatientReasonFormViewModel;
        this.longInpatientReasonFormViewModel._InPatientTreatmentClinicApplication = this._TTObject as InPatientTreatmentClinicApplication;
    }

    protected loadViewModel() {
        let that = this;
        that.longInpatientReasonFormViewModel = this._ViewModel as LongInpatientReasonFormViewModel;
        that._TTObject = this.longInpatientReasonFormViewModel._InPatientTreatmentClinicApplication;
        if (this.longInpatientReasonFormViewModel == null)
            this.longInpatientReasonFormViewModel = new LongInpatientReasonFormViewModel();
        if (this.longInpatientReasonFormViewModel._InPatientTreatmentClinicApplication == null)
            this.longInpatientReasonFormViewModel._InPatientTreatmentClinicApplication = new InPatientTreatmentClinicApplication();

    }

    async ngOnInit() {
        await this.load();
    }

    public onLongInpatientReasonChanged(event): void {
        if (this._InPatientTreatmentClinicApplication != null && this._InPatientTreatmentClinicApplication.LongInpatientReason != event) {
            this._InPatientTreatmentClinicApplication.LongInpatientReason = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.LongInpatientReason, "Text", this.__ttObject, "LongInpatientReason");
    }

    public initFormControls(): void {
        this.labelLongInpatientReason = new TTVisual.TTLabel();
        this.labelLongInpatientReason.Text = "Uzun Yatış Nedeni";
        this.labelLongInpatientReason.Name = "labelLongInpatientReason";
        this.labelLongInpatientReason.TabIndex = 1;

        this.LongInpatientReason = new TTVisual.TTTextBox();
        this.LongInpatientReason.Multiline = true;
        this.LongInpatientReason.Name = "LongInpatientReason";
        this.LongInpatientReason.TabIndex = 0;

        this.Controls = [this.labelLongInpatientReason, this.LongInpatientReason];

    }


}
