//$B82DA0FE
import { Component, OnInit  } from '@angular/core';
import { GaitAnalysisFormViewModel } from './GaitAnalysisFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { GaitAnalysisForm } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'GaitAnalysisForm',
    templateUrl: './GaitAnalysisFormForm.html',
    providers: [MessageService]
})
export class GaitAnalysisFormForm extends BaseAdditionalInfoForm implements OnInit {
    BarthelIndex: TTVisual.ITTTextBox;
    Code: TTVisual.ITTTextBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    FAC: TTVisual.ITTTextBox;
    FIM: TTVisual.ITTTextBox;
    GMFCS: TTVisual.ITTTextBox;
    labelBarthelIndex: TTVisual.ITTLabel;
    labelCode: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    labelFAC: TTVisual.ITTLabel;
    labelFIM: TTVisual.ITTLabel;
    labelGMFCS: TTVisual.ITTLabel;
    labelPULSESProfile: TTVisual.ITTLabel;
    labelRivermeadAssessment: TTVisual.ITTLabel;
    PULSESProfile: TTVisual.ITTTextBox;
    RivermeadAssessment: TTVisual.ITTTextBox;
    public gaitAnalysisFormViewModel: GaitAnalysisFormViewModel = new GaitAnalysisFormViewModel();
    public get _GaitAnalysisForm(): GaitAnalysisForm {
        return this._TTObject as GaitAnalysisForm;
    }
    private GaitAnalysisForm_DocumentUrl: string = '/api/GaitAnalysisFormService/GaitAnalysisForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.GaitAnalysisForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new GaitAnalysisForm();
        this.gaitAnalysisFormViewModel = new GaitAnalysisFormViewModel();
        this._ViewModel = this.gaitAnalysisFormViewModel;
        this.gaitAnalysisFormViewModel._GaitAnalysisForm = this._TTObject as GaitAnalysisForm;
    }

    protected loadViewModel() {
        let that = this;
        that.gaitAnalysisFormViewModel = this._ViewModel as GaitAnalysisFormViewModel;
        that._TTObject = this.gaitAnalysisFormViewModel._GaitAnalysisForm;
        if (this.gaitAnalysisFormViewModel == null)
            this.gaitAnalysisFormViewModel = new GaitAnalysisFormViewModel();
        if (this.gaitAnalysisFormViewModel._GaitAnalysisForm == null)
            this.gaitAnalysisFormViewModel._GaitAnalysisForm = new GaitAnalysisForm();

    }

    async ngOnInit() {
        await this.load(GaitAnalysisFormViewModel);
    }

    public onBarthelIndexChanged(event): void {
        if (event != null) {
            if (this._GaitAnalysisForm != null && this._GaitAnalysisForm.BarthelIndex != event) {
                this._GaitAnalysisForm.BarthelIndex = event;
            }
        }
    }

    public onCodeChanged(event): void {
        if (event != null) {
            if (this._GaitAnalysisForm != null && this._GaitAnalysisForm.Code != event) {
                this._GaitAnalysisForm.Code = event;
            }
        }
    }

    public onCreationDateChanged(event): void {
        if (event != null) {
            if (this._GaitAnalysisForm != null && this._GaitAnalysisForm.CreationDate != event) {
                this._GaitAnalysisForm.CreationDate = event;
            }
        }
    }

    public onFACChanged(event): void {
        if (event != null) {
            if (this._GaitAnalysisForm != null && this._GaitAnalysisForm.FAC != event) {
                this._GaitAnalysisForm.FAC = event;
            }
        }
    }

    public onFIMChanged(event): void {
        if (event != null) {
            if (this._GaitAnalysisForm != null && this._GaitAnalysisForm.FIM != event) {
                this._GaitAnalysisForm.FIM = event;
            }
        }
    }

    public onGMFCSChanged(event): void {
        if (event != null) {
            if (this._GaitAnalysisForm != null && this._GaitAnalysisForm.GMFCS != event) {
                this._GaitAnalysisForm.GMFCS = event;
            }
        }
    }

    public onPULSESProfileChanged(event): void {
        if (event != null) {
            if (this._GaitAnalysisForm != null && this._GaitAnalysisForm.PULSESProfile != event) {
                this._GaitAnalysisForm.PULSESProfile = event;
            }
        }
    }

    public onRivermeadAssessmentChanged(event): void {
        if (event != null) {
            if (this._GaitAnalysisForm != null && this._GaitAnalysisForm.RivermeadAssessment != event) {
                this._GaitAnalysisForm.RivermeadAssessment = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.FAC, "Text", this.__ttObject, "FAC");
        redirectProperty(this.BarthelIndex, "Text", this.__ttObject, "BarthelIndex");
        redirectProperty(this.PULSESProfile, "Text", this.__ttObject, "PULSESProfile");
        redirectProperty(this.RivermeadAssessment, "Text", this.__ttObject, "RivermeadAssessment");
        redirectProperty(this.FIM, "Text", this.__ttObject, "FIM");
        redirectProperty(this.GMFCS, "Text", this.__ttObject, "GMFCS");
    }

    public initFormControls(): void {
        this.labelGMFCS = new TTVisual.TTLabel();
        this.labelGMFCS.Text = "Gross Motor Function Classiflcation System (GMFCS)";
        this.labelGMFCS.Name = "labelGMFCS";
        this.labelGMFCS.TabIndex = 15;

        this.GMFCS = new TTVisual.TTTextBox();
        this.GMFCS.Name = "GMFCS";
        this.GMFCS.TabIndex = 14;

        this.PULSESProfile = new TTVisual.TTTextBox();
        this.PULSESProfile.Name = "PULSESProfile";
        this.PULSESProfile.TabIndex = 12;

        this.FIM = new TTVisual.TTTextBox();
        this.FIM.Name = "FIM";
        this.FIM.TabIndex = 10;

        this.BarthelIndex = new TTVisual.TTTextBox();
        this.BarthelIndex.Name = "BarthelIndex";
        this.BarthelIndex.TabIndex = 8;

        this.RivermeadAssessment = new TTVisual.TTTextBox();
        this.RivermeadAssessment.Name = "RivermeadAssessment";
        this.RivermeadAssessment.TabIndex = 6;

        this.FAC = new TTVisual.TTTextBox();
        this.FAC.Name = "FAC";
        this.FAC.TabIndex = 4;

        this.Code = new TTVisual.TTTextBox();
        this.Code.Name = "Code";
        this.Code.TabIndex = 0;

        this.labelPULSESProfile = new TTVisual.TTLabel();
        this.labelPULSESProfile.Text = i18n("M20628", "PULSES Profili");
        this.labelPULSESProfile.Name = "labelPULSESProfile";
        this.labelPULSESProfile.TabIndex = 13;

        this.labelFIM = new TTVisual.TTLabel();
        this.labelFIM.Text = "FIM";
        this.labelFIM.Name = "labelFIM";
        this.labelFIM.TabIndex = 11;

        this.labelBarthelIndex = new TTVisual.TTLabel();
        this.labelBarthelIndex.Text = i18n("M11550", "Barthel İndeksi");
        this.labelBarthelIndex.Name = "labelBarthelIndex";
        this.labelBarthelIndex.TabIndex = 9;

        this.labelRivermeadAssessment = new TTVisual.TTLabel();
        this.labelRivermeadAssessment.Text = i18n("M21053", "Rivermead Görsel Yürüme Değerlendirmesi");
        this.labelRivermeadAssessment.Name = "labelRivermeadAssessment";
        this.labelRivermeadAssessment.TabIndex = 7;

        this.labelFAC = new TTVisual.TTLabel();
        this.labelFAC.Text = i18n("M14453", "Fonksiyonel Ambulasyon Sınıflanması (FAC)");
        this.labelFAC.Name = "labelFAC";
        this.labelFAC.TabIndex = 5;

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

        this.Controls = [this.labelGMFCS, this.GMFCS, this.PULSESProfile, this.FIM, this.BarthelIndex, this.RivermeadAssessment, this.FAC, this.Code, this.labelPULSESProfile, this.labelFIM, this.labelBarthelIndex, this.labelRivermeadAssessment, this.labelFAC, this.labelCreationDate, this.CreationDate, this.labelCode];

    }


}
