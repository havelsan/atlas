//$FED23745
import { Component, OnInit  } from '@angular/core';
import { DailyActivityTestsFormViewModel } from './DailyActivityTestsFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DailyActivityTestsForm } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'DailyActivityTestsForm',
    templateUrl: './DailyActivityTestsFormForm.html',
    providers: [MessageService]
})
export class DailyActivityTestsFormForm extends BaseAdditionalInfoForm implements OnInit {
    BarthelTest: TTVisual.ITTTextBox;
    BASFI: TTVisual.ITTTextBox;
    Code: TTVisual.ITTTextBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    FonctionalIndependenceMeasure: TTVisual.ITTTextBox;
    HealthAssessmentQuostionnarie: TTVisual.ITTTextBox;
    KatzIndex: TTVisual.ITTTextBox;
    labelBarthelTest: TTVisual.ITTLabel;
    labelBASFI: TTVisual.ITTLabel;
    labelCode: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    labelFonctionalIndependenceMeasure: TTVisual.ITTLabel;
    labelHealthAssessmentQuostionnarie: TTVisual.ITTLabel;
    labelKatzIndex: TTVisual.ITTLabel;
    public dailyActivityTestsFormViewModel: DailyActivityTestsFormViewModel = new DailyActivityTestsFormViewModel();
    public get _DailyActivityTestsForm(): DailyActivityTestsForm {
        return this._TTObject as DailyActivityTestsForm;
    }
    private DailyActivityTestsForm_DocumentUrl: string = '/api/DailyActivityTestsFormService/DailyActivityTestsForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.DailyActivityTestsForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DailyActivityTestsForm();
        this.dailyActivityTestsFormViewModel = new DailyActivityTestsFormViewModel();
        this._ViewModel = this.dailyActivityTestsFormViewModel;
        this.dailyActivityTestsFormViewModel._DailyActivityTestsForm = this._TTObject as DailyActivityTestsForm;
    }

    protected loadViewModel() {
        let that = this;
        that.dailyActivityTestsFormViewModel = this._ViewModel as DailyActivityTestsFormViewModel;
        that._TTObject = this.dailyActivityTestsFormViewModel._DailyActivityTestsForm;
        if (this.dailyActivityTestsFormViewModel == null)
            this.dailyActivityTestsFormViewModel = new DailyActivityTestsFormViewModel();
        if (this.dailyActivityTestsFormViewModel._DailyActivityTestsForm == null)
            this.dailyActivityTestsFormViewModel._DailyActivityTestsForm = new DailyActivityTestsForm();

    }

    async ngOnInit() {
        await this.load(DailyActivityTestsFormViewModel);
    }

    public onBarthelTestChanged(event): void {
        if (event != null) {
            if (this._DailyActivityTestsForm != null && this._DailyActivityTestsForm.BarthelTest != event) {
                this._DailyActivityTestsForm.BarthelTest = event;
            }
        }
    }

    public onBASFIChanged(event): void {
        if (event != null) {
            if (this._DailyActivityTestsForm != null && this._DailyActivityTestsForm.BASFI != event) {
                this._DailyActivityTestsForm.BASFI = event;
            }
        }
    }

    public onCodeChanged(event): void {
        if (event != null) {
            if (this._DailyActivityTestsForm != null && this._DailyActivityTestsForm.Code != event) {
                this._DailyActivityTestsForm.Code = event;
            }
        }
    }

    public onCreationDateChanged(event): void {
        if (event != null) {
            if (this._DailyActivityTestsForm != null && this._DailyActivityTestsForm.CreationDate != event) {
                this._DailyActivityTestsForm.CreationDate = event;
            }
        }
    }

    public onFonctionalIndependenceMeasureChanged(event): void {
        if (event != null) {
            if (this._DailyActivityTestsForm != null && this._DailyActivityTestsForm.FonctionalIndependenceMeasure != event) {
                this._DailyActivityTestsForm.FonctionalIndependenceMeasure = event;
            }
        }
    }

    public onHealthAssessmentQuostionnarieChanged(event): void {
        if (event != null) {
            if (this._DailyActivityTestsForm != null && this._DailyActivityTestsForm.HealthAssessmentQuostionnarie != event) {
                this._DailyActivityTestsForm.HealthAssessmentQuostionnarie = event;
            }
        }
    }

    public onKatzIndexChanged(event): void {
        if (event != null) {
            if (this._DailyActivityTestsForm != null && this._DailyActivityTestsForm.KatzIndex != event) {
                this._DailyActivityTestsForm.KatzIndex = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.BarthelTest, "Text", this.__ttObject, "BarthelTest");
        redirectProperty(this.BASFI, "Text", this.__ttObject, "BASFI");
        redirectProperty(this.FonctionalIndependenceMeasure, "Text", this.__ttObject, "FonctionalIndependenceMeasure");
        redirectProperty(this.KatzIndex, "Text", this.__ttObject, "KatzIndex");
        redirectProperty(this.HealthAssessmentQuostionnarie, "Text", this.__ttObject, "HealthAssessmentQuostionnarie");
    }

    public initFormControls(): void {
        this.labelKatzIndex = new TTVisual.TTLabel();
        this.labelKatzIndex.Text = i18n("M17375", "Katz İndeksi");
        this.labelKatzIndex.Name = "labelKatzIndex";
        this.labelKatzIndex.TabIndex = 13;

        this.KatzIndex = new TTVisual.TTTextBox();
        this.KatzIndex.Name = "KatzIndex";
        this.KatzIndex.TabIndex = 12;

        this.BASFI = new TTVisual.TTTextBox();
        this.BASFI.Name = "BASFI";
        this.BASFI.TabIndex = 10;

        this.HealthAssessmentQuostionnarie = new TTVisual.TTTextBox();
        this.HealthAssessmentQuostionnarie.Name = "HealthAssessmentQuostionnarie";
        this.HealthAssessmentQuostionnarie.TabIndex = 8;

        this.FonctionalIndependenceMeasure = new TTVisual.TTTextBox();
        this.FonctionalIndependenceMeasure.Name = "FonctionalIndependenceMeasure";
        this.FonctionalIndependenceMeasure.TabIndex = 6;

        this.BarthelTest = new TTVisual.TTTextBox();
        this.BarthelTest.Name = "BarthelTest";
        this.BarthelTest.TabIndex = 4;

        this.Code = new TTVisual.TTTextBox();
        this.Code.Name = "Code";
        this.Code.TabIndex = 0;

        this.labelBASFI = new TTVisual.TTLabel();
        this.labelBASFI.Text = i18n("M11670", "Bath Fonksiyonel İndeksi (BASFI)");
        this.labelBASFI.Name = "labelBASFI";
        this.labelBASFI.TabIndex = 11;

        this.labelHealthAssessmentQuostionnarie = new TTVisual.TTLabel();
        this.labelHealthAssessmentQuostionnarie.Text = "Sağlık Değerlendirme Anketi (HAQ)";
        this.labelHealthAssessmentQuostionnarie.Name = "labelHealthAssessmentQuostionnarie";
        this.labelHealthAssessmentQuostionnarie.TabIndex = 9;

        this.labelFonctionalIndependenceMeasure = new TTVisual.TTLabel();
        this.labelFonctionalIndependenceMeasure.Text = i18n("M14454", "Fonksiyonel Bağımsızlık Ölçümü (FIM)");
        this.labelFonctionalIndependenceMeasure.Name = "labelFonctionalIndependenceMeasure";
        this.labelFonctionalIndependenceMeasure.TabIndex = 7;

        this.labelBarthelTest = new TTVisual.TTLabel();
        this.labelBarthelTest.Text = i18n("M11551", "Barthel Testi");
        this.labelBarthelTest.Name = "labelBarthelTest";
        this.labelBarthelTest.TabIndex = 5;

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

        this.Controls = [this.labelKatzIndex, this.KatzIndex, this.BASFI, this.HealthAssessmentQuostionnarie, this.FonctionalIndependenceMeasure, this.BarthelTest, this.Code, this.labelBASFI, this.labelHealthAssessmentQuostionnarie, this.labelFonctionalIndependenceMeasure, this.labelBarthelTest, this.labelCreationDate, this.CreationDate, this.labelCode];

    }


}
