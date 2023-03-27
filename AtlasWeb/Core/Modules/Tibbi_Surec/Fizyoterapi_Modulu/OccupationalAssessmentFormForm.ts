//$06D3C303
import { Component, OnInit  } from '@angular/core';
import { OccupationalAssessmentFormViewModel } from './OccupationalAssessmentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { OccupationalAssessmentForm } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'OccupationalAssessmentForm',
    templateUrl: './OccupationalAssessmentFormForm.html',
    providers: [MessageService]
})
export class OccupationalAssessmentFormForm extends BaseAdditionalInfoForm implements OnInit {
    CHART: TTVisual.ITTTextBox;
    Code: TTVisual.ITTTextBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    DASH: TTVisual.ITTTextBox;
    FCE: TTVisual.ITTTextBox;
    labelCHART: TTVisual.ITTLabel;
    labelCode: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    labelDASH: TTVisual.ITTLabel;
    labelFCE: TTVisual.ITTLabel;
    labelPOP: TTVisual.ITTLabel;
    POP: TTVisual.ITTTextBox;
    public occupationalAssessmentFormViewModel: OccupationalAssessmentFormViewModel = new OccupationalAssessmentFormViewModel();
    public get _OccupationalAssessmentForm(): OccupationalAssessmentForm {
        return this._TTObject as OccupationalAssessmentForm;
    }
    private OccupationalAssessmentForm_DocumentUrl: string = '/api/OccupationalAssessmentFormService/OccupationalAssessmentForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.OccupationalAssessmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new OccupationalAssessmentForm();
        this.occupationalAssessmentFormViewModel = new OccupationalAssessmentFormViewModel();
        this._ViewModel = this.occupationalAssessmentFormViewModel;
        this.occupationalAssessmentFormViewModel._OccupationalAssessmentForm = this._TTObject as OccupationalAssessmentForm;
    }

    protected loadViewModel() {
        let that = this;
        that.occupationalAssessmentFormViewModel = this._ViewModel as OccupationalAssessmentFormViewModel;
        that._TTObject = this.occupationalAssessmentFormViewModel._OccupationalAssessmentForm;
        if (this.occupationalAssessmentFormViewModel == null)
            this.occupationalAssessmentFormViewModel = new OccupationalAssessmentFormViewModel();
        if (this.occupationalAssessmentFormViewModel._OccupationalAssessmentForm == null)
            this.occupationalAssessmentFormViewModel._OccupationalAssessmentForm = new OccupationalAssessmentForm();

    }

    async ngOnInit() {
        await this.load(OccupationalAssessmentFormViewModel);
    }

    public onCHARTChanged(event): void {
        if (event != null) {
            if (this._OccupationalAssessmentForm != null && this._OccupationalAssessmentForm.CHART != event) {
                this._OccupationalAssessmentForm.CHART = event;
            }
        }
    }

    public onCodeChanged(event): void {
        if (event != null) {
            if (this._OccupationalAssessmentForm != null && this._OccupationalAssessmentForm.Code != event) {
                this._OccupationalAssessmentForm.Code = event;
            }
        }
    }

    public onCreationDateChanged(event): void {
        if (event != null) {
            if (this._OccupationalAssessmentForm != null && this._OccupationalAssessmentForm.CreationDate != event) {
                this._OccupationalAssessmentForm.CreationDate = event;
            }
        }
    }

    public onDASHChanged(event): void {
        if (event != null) {
            if (this._OccupationalAssessmentForm != null && this._OccupationalAssessmentForm.DASH != event) {
                this._OccupationalAssessmentForm.DASH = event;
            }
        }
    }

    public onFCEChanged(event): void {
        if (event != null) {
            if (this._OccupationalAssessmentForm != null && this._OccupationalAssessmentForm.FCE != event) {
                this._OccupationalAssessmentForm.FCE = event;
            }
        }
    }

    public onPOPChanged(event): void {
        if (event != null) {
            if (this._OccupationalAssessmentForm != null && this._OccupationalAssessmentForm.POP != event) {
                this._OccupationalAssessmentForm.POP = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.CHART, "Text", this.__ttObject, "CHART");
        redirectProperty(this.DASH, "Text", this.__ttObject, "DASH");
        redirectProperty(this.FCE, "Text", this.__ttObject, "FCE");
        redirectProperty(this.POP, "Text", this.__ttObject, "POP");
    }

    public initFormControls(): void {
        this.labelPOP = new TTVisual.TTLabel();
        this.labelPOP.Text = i18n("M11184", "Assessment of Pain and Occupational Performance");
        this.labelPOP.Name = "labelPOP";
        this.labelPOP.TabIndex = 11;

        this.POP = new TTVisual.TTTextBox();
        this.POP.Name = "POP";
        this.POP.TabIndex = 10;

        this.DASH = new TTVisual.TTTextBox();
        this.DASH.Name = "DASH";
        this.DASH.TabIndex = 8;

        this.FCE = new TTVisual.TTTextBox();
        this.FCE.Name = "FCE";
        this.FCE.TabIndex = 6;

        this.CHART = new TTVisual.TTTextBox();
        this.CHART.Name = "CHART";
        this.CHART.TabIndex = 4;

        this.Code = new TTVisual.TTTextBox();
        this.Code.Name = "Code";
        this.Code.TabIndex = 0;

        this.labelDASH = new TTVisual.TTLabel();
        this.labelDASH.Text = "QUICK ? DASH (Disease Arm ? Shoulder - Hand)";
        this.labelDASH.Name = "labelDASH";
        this.labelDASH.TabIndex = 9;

        this.labelFCE = new TTVisual.TTLabel();
        this.labelFCE.Text = i18n("M14503", "Functional Capacity Evaluation (FCE)");
        this.labelFCE.Name = "labelFCE";
        this.labelFCE.TabIndex = 7;

        this.labelCHART = new TTVisual.TTLabel();
        this.labelCHART.Text = i18n("M12288", "Craig handicap and Reporting technique ");
        this.labelCHART.Name = "labelCHART";
        this.labelCHART.TabIndex = 5;

        this.labelCreationDate = new TTVisual.TTLabel();
        this.labelCreationDate.Text = i18n("M13549", "Ekleme Tarihi Saati");
        this.labelCreationDate.Name = "labelCreationDate";
        this.labelCreationDate.TabIndex = 3;

        this.CreationDate = new TTVisual.TTDateTimePicker();
        this.CreationDate.Format = DateTimePickerFormat.Long;
        this.CreationDate.Name = "CreationDate";
        this.CreationDate.TabIndex = 2;

        this.labelCode = new TTVisual.TTLabel();
        this.labelCode.Text = "Kodu";
        this.labelCode.Name = "labelCode";
        this.labelCode.TabIndex = 1;

        this.Controls = [this.labelPOP, this.POP, this.DASH, this.FCE, this.CHART, this.Code, this.labelDASH, this.labelFCE, this.labelCHART, this.labelCreationDate, this.CreationDate, this.labelCode];

    }


}
