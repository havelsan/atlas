//$27A27F77
import { Component, OnInit  } from '@angular/core';
import { SensoryPerceptionAssessmentFormViewModel } from './SensoryPerceptionAssessmentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { SensoryPerceptionAssessmentForm } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'SensoryPerceptionAssessmentForm',
    templateUrl: './SensoryPerceptionAssessmentFormForm.html',
    providers: [MessageService]
})
export class SensoryPerceptionAssessmentFormForm extends BaseAdditionalInfoForm implements OnInit {
    ASIAImpairmentScale: TTVisual.ITTTextBox;
    Code: TTVisual.ITTTextBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    FuglMeyerTest: TTVisual.ITTTextBox;
    KurtzkeScale: TTVisual.ITTTextBox;
    labelASIAImpairmentScale: TTVisual.ITTLabel;
    labelCode: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    labelFuglMeyerTest: TTVisual.ITTLabel;
    labelKurtzkeScale: TTVisual.ITTLabel;
    labelMiniMentalStateExamination: TTVisual.ITTLabel;
    labelRivemeadIndex: TTVisual.ITTLabel;
    labelStarCancellationTest: TTVisual.ITTLabel;
    MiniMentalStateExamination: TTVisual.ITTTextBox;
    RivemeadIndex: TTVisual.ITTTextBox;
    StarCancellationTest: TTVisual.ITTTextBox;
    public sensoryPerceptionAssessmentFormViewModel: SensoryPerceptionAssessmentFormViewModel = new SensoryPerceptionAssessmentFormViewModel();
    public get _SensoryPerceptionAssessmentForm(): SensoryPerceptionAssessmentForm {
        return this._TTObject as SensoryPerceptionAssessmentForm;
    }
    private SensoryPerceptionAssessmentForm_DocumentUrl: string = '/api/SensoryPerceptionAssessmentFormService/SensoryPerceptionAssessmentForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.SensoryPerceptionAssessmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SensoryPerceptionAssessmentForm();
        this.sensoryPerceptionAssessmentFormViewModel = new SensoryPerceptionAssessmentFormViewModel();
        this._ViewModel = this.sensoryPerceptionAssessmentFormViewModel;
        this.sensoryPerceptionAssessmentFormViewModel._SensoryPerceptionAssessmentForm = this._TTObject as SensoryPerceptionAssessmentForm;
    }

    protected loadViewModel() {
        let that = this;
        that.sensoryPerceptionAssessmentFormViewModel = this._ViewModel as SensoryPerceptionAssessmentFormViewModel;
        that._TTObject = this.sensoryPerceptionAssessmentFormViewModel._SensoryPerceptionAssessmentForm;
        if (this.sensoryPerceptionAssessmentFormViewModel == null)
            this.sensoryPerceptionAssessmentFormViewModel = new SensoryPerceptionAssessmentFormViewModel();
        if (this.sensoryPerceptionAssessmentFormViewModel._SensoryPerceptionAssessmentForm == null)
            this.sensoryPerceptionAssessmentFormViewModel._SensoryPerceptionAssessmentForm = new SensoryPerceptionAssessmentForm();

    }

    async ngOnInit() {
        await this.load(SensoryPerceptionAssessmentFormViewModel);
    }

    public onASIAImpairmentScaleChanged(event): void {
        if (event != null) {
            if (this._SensoryPerceptionAssessmentForm != null && this._SensoryPerceptionAssessmentForm.ASIAImpairmentScale != event) {
                this._SensoryPerceptionAssessmentForm.ASIAImpairmentScale = event;
            }
        }
    }

    public onCodeChanged(event): void {
        if (event != null) {
            if (this._SensoryPerceptionAssessmentForm != null && this._SensoryPerceptionAssessmentForm.Code != event) {
                this._SensoryPerceptionAssessmentForm.Code = event;
            }
        }
    }

    public onCreationDateChanged(event): void {
        if (event != null) {
            if (this._SensoryPerceptionAssessmentForm != null && this._SensoryPerceptionAssessmentForm.CreationDate != event) {
                this._SensoryPerceptionAssessmentForm.CreationDate = event;
            }
        }
    }

    public onFuglMeyerTestChanged(event): void {
        if (event != null) {
            if (this._SensoryPerceptionAssessmentForm != null && this._SensoryPerceptionAssessmentForm.FuglMeyerTest != event) {
                this._SensoryPerceptionAssessmentForm.FuglMeyerTest = event;
            }
        }
    }

    public onKurtzkeScaleChanged(event): void {
        if (event != null) {
            if (this._SensoryPerceptionAssessmentForm != null && this._SensoryPerceptionAssessmentForm.KurtzkeScale != event) {
                this._SensoryPerceptionAssessmentForm.KurtzkeScale = event;
            }
        }
    }

    public onMiniMentalStateExaminationChanged(event): void {
        if (event != null) {
            if (this._SensoryPerceptionAssessmentForm != null && this._SensoryPerceptionAssessmentForm.MiniMentalStateExamination != event) {
                this._SensoryPerceptionAssessmentForm.MiniMentalStateExamination = event;
            }
        }
    }

    public onRivemeadIndexChanged(event): void {
        if (event != null) {
            if (this._SensoryPerceptionAssessmentForm != null && this._SensoryPerceptionAssessmentForm.RivemeadIndex != event) {
                this._SensoryPerceptionAssessmentForm.RivemeadIndex = event;
            }
        }
    }

    public onStarCancellationTestChanged(event): void {
        if (event != null) {
            if (this._SensoryPerceptionAssessmentForm != null && this._SensoryPerceptionAssessmentForm.StarCancellationTest != event) {
                this._SensoryPerceptionAssessmentForm.StarCancellationTest = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.ASIAImpairmentScale, "Text", this.__ttObject, "ASIAImpairmentScale");
        redirectProperty(this.RivemeadIndex, "Text", this.__ttObject, "RivemeadIndex");
        redirectProperty(this.KurtzkeScale, "Text", this.__ttObject, "KurtzkeScale");
        redirectProperty(this.MiniMentalStateExamination, "Text", this.__ttObject, "MiniMentalStateExamination");
        redirectProperty(this.FuglMeyerTest, "Text", this.__ttObject, "FuglMeyerTest");
        redirectProperty(this.StarCancellationTest, "Text", this.__ttObject, "StarCancellationTest");
    }

    public initFormControls(): void {
        this.labelStarCancellationTest = new TTVisual.TTLabel();
        this.labelStarCancellationTest.Text = i18n("M24667", "Yıldız Testi");
        this.labelStarCancellationTest.Name = "labelStarCancellationTest";
        this.labelStarCancellationTest.TabIndex = 15;

        this.StarCancellationTest = new TTVisual.TTTextBox();
        this.StarCancellationTest.Name = "StarCancellationTest";
        this.StarCancellationTest.TabIndex = 14;

        this.labelMiniMentalStateExamination = new TTVisual.TTLabel();
        this.labelMiniMentalStateExamination.Text = i18n("M19042", "Mini Mental Test");
        this.labelMiniMentalStateExamination.Name = "labelMiniMentalStateExamination";
        this.labelMiniMentalStateExamination.TabIndex = 13;

        this.MiniMentalStateExamination = new TTVisual.TTTextBox();
        this.MiniMentalStateExamination.Name = "MiniMentalStateExamination";
        this.MiniMentalStateExamination.TabIndex = 12;

        this.labelRivemeadIndex = new TTVisual.TTLabel();
        this.labelRivemeadIndex.Text = i18n("M21052", "Rivemead Mibilite İndeksi");
        this.labelRivemeadIndex.Name = "labelRivemeadIndex";
        this.labelRivemeadIndex.TabIndex = 11;

        this.RivemeadIndex = new TTVisual.TTTextBox();
        this.RivemeadIndex.Name = "RivemeadIndex";
        this.RivemeadIndex.TabIndex = 10;

        this.labelFuglMeyerTest = new TTVisual.TTLabel();
        this.labelFuglMeyerTest.Text = i18n("M14501", "Fugl Meyer Testi");
        this.labelFuglMeyerTest.Name = "labelFuglMeyerTest";
        this.labelFuglMeyerTest.TabIndex = 9;

        this.FuglMeyerTest = new TTVisual.TTTextBox();
        this.FuglMeyerTest.Name = "FuglMeyerTest";
        this.FuglMeyerTest.TabIndex = 8;

        this.labelKurtzkeScale = new TTVisual.TTLabel();
        this.labelKurtzkeScale.Text = "Kurtzke Expanded Disability Status Scale";
        this.labelKurtzkeScale.Name = "labelKurtzkeScale";
        this.labelKurtzkeScale.TabIndex = 7;

        this.KurtzkeScale = new TTVisual.TTTextBox();
        this.KurtzkeScale.Name = "KurtzkeScale";
        this.KurtzkeScale.TabIndex = 6;

        this.labelASIAImpairmentScale = new TTVisual.TTLabel();
        this.labelASIAImpairmentScale.Text = i18n("M11125", "ASIA Bozukluk Skalası");
        this.labelASIAImpairmentScale.Name = "labelASIAImpairmentScale";
        this.labelASIAImpairmentScale.TabIndex = 5;

        this.ASIAImpairmentScale = new TTVisual.TTTextBox();
        this.ASIAImpairmentScale.Name = "ASIAImpairmentScale";
        this.ASIAImpairmentScale.TabIndex = 4;

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

        this.Controls = [this.labelStarCancellationTest, this.StarCancellationTest, this.labelMiniMentalStateExamination, this.MiniMentalStateExamination, this.labelRivemeadIndex, this.RivemeadIndex, this.labelFuglMeyerTest, this.FuglMeyerTest, this.labelKurtzkeScale, this.KurtzkeScale, this.labelASIAImpairmentScale, this.ASIAImpairmentScale, this.labelCreationDate, this.CreationDate, this.labelCode, this.Code];

    }


}
