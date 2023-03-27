//$AF8FFFE6
import { Component, OnInit  } from '@angular/core';
import { NeurophysiologicalAssessmentFormViewModel } from './NeurophysiologicalAssessmentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { NeurophysiologicalAssessmentForm } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'NeurophysiologicalAssessmentForm',
    templateUrl: './NeurophysiologicalAssessmentFormForm.html',
    providers: [MessageService]
})
export class NeurophysiologicalAssessmentFormForm extends BaseAdditionalInfoForm implements OnInit {
    BobathBrunstrum: TTVisual.ITTTextBox;
    ChedokeStrokeAssessmentScale: TTVisual.ITTTextBox;
    Code: TTVisual.ITTTextBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    Kabat: TTVisual.ITTTextBox;
    labelBobathBrunstrum: TTVisual.ITTLabel;
    labelChedokeStrokeAssessmentScale: TTVisual.ITTLabel;
    labelCode: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    labelKabat: TTVisual.ITTLabel;
    labelRood: TTVisual.ITTLabel;
    labelVojta: TTVisual.ITTLabel;
    Rood: TTVisual.ITTTextBox;
    Vojta: TTVisual.ITTTextBox;
    public neurophysiologicalAssessmentFormViewModel: NeurophysiologicalAssessmentFormViewModel = new NeurophysiologicalAssessmentFormViewModel();
    public get _NeurophysiologicalAssessmentForm(): NeurophysiologicalAssessmentForm {
        return this._TTObject as NeurophysiologicalAssessmentForm;
    }
    private NeurophysiologicalAssessmentForm_DocumentUrl: string = '/api/NeurophysiologicalAssessmentFormService/NeurophysiologicalAssessmentForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.NeurophysiologicalAssessmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NeurophysiologicalAssessmentForm();
        this.neurophysiologicalAssessmentFormViewModel = new NeurophysiologicalAssessmentFormViewModel();
        this._ViewModel = this.neurophysiologicalAssessmentFormViewModel;
        this.neurophysiologicalAssessmentFormViewModel._NeurophysiologicalAssessmentForm = this._TTObject as NeurophysiologicalAssessmentForm;
    }

    protected loadViewModel() {
        let that = this;
        that.neurophysiologicalAssessmentFormViewModel = this._ViewModel as NeurophysiologicalAssessmentFormViewModel;
        that._TTObject = this.neurophysiologicalAssessmentFormViewModel._NeurophysiologicalAssessmentForm;
        if (this.neurophysiologicalAssessmentFormViewModel == null)
            this.neurophysiologicalAssessmentFormViewModel = new NeurophysiologicalAssessmentFormViewModel();
        if (this.neurophysiologicalAssessmentFormViewModel._NeurophysiologicalAssessmentForm == null)
            this.neurophysiologicalAssessmentFormViewModel._NeurophysiologicalAssessmentForm = new NeurophysiologicalAssessmentForm();

    }

    async ngOnInit() {
        await this.load(NeurophysiologicalAssessmentFormViewModel);
    }

    public onBobathBrunstrumChanged(event): void {
        if (event != null) {
            if (this._NeurophysiologicalAssessmentForm != null && this._NeurophysiologicalAssessmentForm.BobathBrunstrum != event) {
                this._NeurophysiologicalAssessmentForm.BobathBrunstrum = event;
            }
        }
    }

    public onChedokeStrokeAssessmentScaleChanged(event): void {
        if (event != null) {
            if (this._NeurophysiologicalAssessmentForm != null && this._NeurophysiologicalAssessmentForm.ChedokeStrokeAssessmentScale != event) {
                this._NeurophysiologicalAssessmentForm.ChedokeStrokeAssessmentScale = event;
            }
        }
    }

    public onCodeChanged(event): void {
        if (event != null) {
            if (this._NeurophysiologicalAssessmentForm != null && this._NeurophysiologicalAssessmentForm.Code != event) {
                this._NeurophysiologicalAssessmentForm.Code = event;
            }
        }
    }

    public onCreationDateChanged(event): void {
        if (event != null) {
            if (this._NeurophysiologicalAssessmentForm != null && this._NeurophysiologicalAssessmentForm.CreationDate != event) {
                this._NeurophysiologicalAssessmentForm.CreationDate = event;
            }
        }
    }

    public onKabatChanged(event): void {
        if (event != null) {
            if (this._NeurophysiologicalAssessmentForm != null && this._NeurophysiologicalAssessmentForm.Kabat != event) {
                this._NeurophysiologicalAssessmentForm.Kabat = event;
            }
        }
    }

    public onRoodChanged(event): void {
        if (event != null) {
            if (this._NeurophysiologicalAssessmentForm != null && this._NeurophysiologicalAssessmentForm.Rood != event) {
                this._NeurophysiologicalAssessmentForm.Rood = event;
            }
        }
    }

    public onVojtaChanged(event): void {
        if (event != null) {
            if (this._NeurophysiologicalAssessmentForm != null && this._NeurophysiologicalAssessmentForm.Vojta != event) {
                this._NeurophysiologicalAssessmentForm.Vojta = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.BobathBrunstrum, "Text", this.__ttObject, "BobathBrunstrum");
        redirectProperty(this.Kabat, "Text", this.__ttObject, "Kabat");
        redirectProperty(this.Vojta, "Text", this.__ttObject, "Vojta");
        redirectProperty(this.ChedokeStrokeAssessmentScale, "Text", this.__ttObject, "ChedokeStrokeAssessmentScale");
        redirectProperty(this.Rood, "Text", this.__ttObject, "Rood");
    }

    public initFormControls(): void {
        this.labelCreationDate = new TTVisual.TTLabel();
        this.labelCreationDate.Text = i18n("M13548", "Ekleme Tarihi / Saati");
        this.labelCreationDate.Name = "labelCreationDate";
        this.labelCreationDate.TabIndex = 13;

        this.CreationDate = new TTVisual.TTDateTimePicker();
        this.CreationDate.Format = DateTimePickerFormat.Long;
        this.CreationDate.Name = "CreationDate";
        this.CreationDate.TabIndex = 12;

        this.labelCode = new TTVisual.TTLabel();
        this.labelCode.Text = "Kodu";
        this.labelCode.Name = "labelCode";
        this.labelCode.TabIndex = 11;

        this.Code = new TTVisual.TTTextBox();
        this.Code.Name = "Code";
        this.Code.TabIndex = 10;

        this.labelVojta = new TTVisual.TTLabel();
        this.labelVojta.Text = "Vojta";
        this.labelVojta.Name = "labelVojta";
        this.labelVojta.TabIndex = 9;

        this.Vojta = new TTVisual.TTTextBox();
        this.Vojta.Name = "Vojta";
        this.Vojta.TabIndex = 8;

        this.labelRood = new TTVisual.TTLabel();
        this.labelRood.Text = "Rood";
        this.labelRood.Name = "labelRood";
        this.labelRood.TabIndex = 7;

        this.Rood = new TTVisual.TTTextBox();
        this.Rood.Name = "Rood";
        this.Rood.TabIndex = 6;

        this.labelKabat = new TTVisual.TTLabel();
        this.labelKabat.Text = "Kabat";
        this.labelKabat.Name = "labelKabat";
        this.labelKabat.TabIndex = 5;

        this.Kabat = new TTVisual.TTTextBox();
        this.Kabat.Name = "Kabat";
        this.Kabat.TabIndex = 4;

        this.labelChedokeStrokeAssessmentScale = new TTVisual.TTLabel();
        this.labelChedokeStrokeAssessmentScale.Text = "Chedoke Mc Master Stroke Assessment Scale";
        this.labelChedokeStrokeAssessmentScale.Name = "labelChedokeStrokeAssessmentScale";
        this.labelChedokeStrokeAssessmentScale.TabIndex = 3;

        this.ChedokeStrokeAssessmentScale = new TTVisual.TTTextBox();
        this.ChedokeStrokeAssessmentScale.Name = "ChedokeStrokeAssessmentScale";
        this.ChedokeStrokeAssessmentScale.TabIndex = 2;

        this.labelBobathBrunstrum = new TTVisual.TTLabel();
        this.labelBobathBrunstrum.Text = i18n("M11963", "Bobath, Brunstrum Evreleme Cetveli");
        this.labelBobathBrunstrum.Name = "labelBobathBrunstrum";
        this.labelBobathBrunstrum.TabIndex = 1;

        this.BobathBrunstrum = new TTVisual.TTTextBox();
        this.BobathBrunstrum.Name = "BobathBrunstrum";
        this.BobathBrunstrum.TabIndex = 0;

        this.Controls = [this.labelCreationDate, this.CreationDate, this.labelCode, this.Code, this.labelVojta, this.Vojta, this.labelRood, this.Rood, this.labelKabat, this.Kabat, this.labelChedokeStrokeAssessmentScale, this.ChedokeStrokeAssessmentScale, this.labelBobathBrunstrum, this.BobathBrunstrum];

    }


}
