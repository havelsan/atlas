//$395F414A
import { Component, OnInit  } from '@angular/core';
import { GaitAnalysisComputerBasedFormViewModel } from './GaitAnalysisComputerBasedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { GaitAnalysisComputerBasedForm } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'GaitAnalysisComputerBasedForm',
    templateUrl: './GaitAnalysisComputerBasedFormForm.html',
    providers: [MessageService]
})
export class GaitAnalysisComputerBasedFormForm extends BaseAdditionalInfoForm implements OnInit {
    Code: TTVisual.ITTTextBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    GaitAnalysis: TTVisual.ITTTextBox;
    labelCode: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    labelGaitAnalysis: TTVisual.ITTLabel;
    public gaitAnalysisComputerBasedFormViewModel: GaitAnalysisComputerBasedFormViewModel = new GaitAnalysisComputerBasedFormViewModel();
    public get _GaitAnalysisComputerBasedForm(): GaitAnalysisComputerBasedForm {
        return this._TTObject as GaitAnalysisComputerBasedForm;
    }
    private GaitAnalysisComputerBasedForm_DocumentUrl: string = '/api/GaitAnalysisComputerBasedFormService/GaitAnalysisComputerBasedForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.GaitAnalysisComputerBasedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new GaitAnalysisComputerBasedForm();
        this.gaitAnalysisComputerBasedFormViewModel = new GaitAnalysisComputerBasedFormViewModel();
        this._ViewModel = this.gaitAnalysisComputerBasedFormViewModel;
        this.gaitAnalysisComputerBasedFormViewModel._GaitAnalysisComputerBasedForm = this._TTObject as GaitAnalysisComputerBasedForm;
    }

    protected loadViewModel() {
        let that = this;
        that.gaitAnalysisComputerBasedFormViewModel = this._ViewModel as GaitAnalysisComputerBasedFormViewModel;
        that._TTObject = this.gaitAnalysisComputerBasedFormViewModel._GaitAnalysisComputerBasedForm;
        if (this.gaitAnalysisComputerBasedFormViewModel == null)
            this.gaitAnalysisComputerBasedFormViewModel = new GaitAnalysisComputerBasedFormViewModel();
        if (this.gaitAnalysisComputerBasedFormViewModel._GaitAnalysisComputerBasedForm == null)
            this.gaitAnalysisComputerBasedFormViewModel._GaitAnalysisComputerBasedForm = new GaitAnalysisComputerBasedForm();

    }

    async ngOnInit() {
        await this.load(GaitAnalysisComputerBasedFormViewModel);
    }

    public onCodeChanged(event): void {
        if (event != null) {
            if (this._GaitAnalysisComputerBasedForm != null && this._GaitAnalysisComputerBasedForm.Code != event) {
                this._GaitAnalysisComputerBasedForm.Code = event;
            }
        }
    }

    public onCreationDateChanged(event): void {
        if (event != null) {
            if (this._GaitAnalysisComputerBasedForm != null && this._GaitAnalysisComputerBasedForm.CreationDate != event) {
                this._GaitAnalysisComputerBasedForm.CreationDate = event;
            }
        }
    }

    public onGaitAnalysisChanged(event): void {
        if (event != null) {
            if (this._GaitAnalysisComputerBasedForm != null && this._GaitAnalysisComputerBasedForm.GaitAnalysis != event) {
                this._GaitAnalysisComputerBasedForm.GaitAnalysis = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.GaitAnalysis, "Text", this.__ttObject, "GaitAnalysis");
    }

    public initFormControls(): void {
        this.labelGaitAnalysis = new TTVisual.TTLabel();
        this.labelGaitAnalysis.Text = i18n("M24743", "Yürüme Analizi");
        this.labelGaitAnalysis.Name = "labelGaitAnalysis";
        this.labelGaitAnalysis.TabIndex = 5;

        this.GaitAnalysis = new TTVisual.TTTextBox();
        this.GaitAnalysis.Name = "GaitAnalysis";
        this.GaitAnalysis.TabIndex = 4;

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

        this.Code = new TTVisual.TTTextBox();
        this.Code.Name = "Code";
        this.Code.TabIndex = 0;

        this.Controls = [this.labelGaitAnalysis, this.GaitAnalysis, this.labelCreationDate, this.CreationDate, this.labelCode, this.Code];

    }


}
