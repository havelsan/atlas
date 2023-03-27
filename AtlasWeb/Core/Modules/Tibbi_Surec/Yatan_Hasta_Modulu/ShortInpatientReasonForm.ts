//$4AB27AFE
import { Component, ViewChild, OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ShortInpatientReasonFormViewModel } from './ShortInpatientReasonFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { InPatientTreatmentClinicApplication } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'ShortInpatientReasonForm',
    templateUrl: './ShortInpatientReasonForm.html',
    providers: [MessageService]
})
export class ShortInpatientReasonForm extends TTVisual.TTForm implements OnInit {
    ShotInpatientReason: TTVisual.ITTTextBox;
    labelShotInpatientReason: TTVisual.ITTLabel;
    public shortInpatientReasonFormViewModel: ShortInpatientReasonFormViewModel = new ShortInpatientReasonFormViewModel();
    public get _InPatientTreatmentClinicApplication(): InPatientTreatmentClinicApplication {
        return this._TTObject as InPatientTreatmentClinicApplication;
    }
    private ShortInpatientReasonForm_DocumentUrl: string = '/api/InPatientTreatmentClinicApplicationService/ShortInpatientReasonForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('INPATIENTTREATMENTCLINICAPPLICATION', 'ShortInpatientReasonForm');
        this._DocumentServiceUrl = this.ShortInpatientReasonForm_DocumentUrl;
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
        this.shortInpatientReasonFormViewModel = new ShortInpatientReasonFormViewModel();
        this._ViewModel = this.shortInpatientReasonFormViewModel;
        this.shortInpatientReasonFormViewModel._InPatientTreatmentClinicApplication = this._TTObject as InPatientTreatmentClinicApplication;
    }

    protected loadViewModel() {
        let that = this;
        that.shortInpatientReasonFormViewModel = this._ViewModel as ShortInpatientReasonFormViewModel;
        that._TTObject = this.shortInpatientReasonFormViewModel._InPatientTreatmentClinicApplication;
        if (this.shortInpatientReasonFormViewModel == null)
            this.shortInpatientReasonFormViewModel = new ShortInpatientReasonFormViewModel();
        if (this.shortInpatientReasonFormViewModel._InPatientTreatmentClinicApplication == null)
            this.shortInpatientReasonFormViewModel._InPatientTreatmentClinicApplication = new InPatientTreatmentClinicApplication();

    }

    async ngOnInit() {
        await this.load();
    }

    public onShotInpatientReasonChanged(event): void {
        if (this._InPatientTreatmentClinicApplication != null && this._InPatientTreatmentClinicApplication.ShotInpatientReason != event) {
            this._InPatientTreatmentClinicApplication.ShotInpatientReason = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ShotInpatientReason, "Text", this.__ttObject, "ShotInpatientReason");
    }

    public initFormControls(): void {
        this.labelShotInpatientReason = new TTVisual.TTLabel();
        this.labelShotInpatientReason.Text = "Kısa Yatış Nedeni";
        this.labelShotInpatientReason.Name = "labelShotInpatientReason";
        this.labelShotInpatientReason.TabIndex = 1;

        this.ShotInpatientReason = new TTVisual.TTTextBox();
        this.ShotInpatientReason.Multiline = true;
        this.ShotInpatientReason.Name = "ShotInpatientReason";
        this.ShotInpatientReason.TabIndex = 0;

        this.Controls = [this.labelShotInpatientReason, this.ShotInpatientReason];

    }


}
