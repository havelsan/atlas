//$8A73C2FC
import { Component, OnInit  } from '@angular/core';
import { AmputeeAssessmentFormViewModel } from './AmputeeAssessmentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AmputeeAssessmentForm } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'AmputeeAssessmentForm',
    templateUrl: './AmputeeAssessmentFormForm.html',
    providers: [MessageService]
})
export class AmputeeAssessmentFormForm extends BaseAdditionalInfoForm implements OnInit {
    Code: TTVisual.ITTTextBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    GroningenScale: TTVisual.ITTTextBox;
    labelCode: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    labelGroningenScale: TTVisual.ITTLabel;
    labelMGFCScale: TTVisual.ITTLabel;
    labelProstheticIpperExtremityIndex: TTVisual.ITTLabel;
    labelTheSicknessImpactProfile: TTVisual.ITTLabel;
    labelTrinityExperienceScale: TTVisual.ITTLabel;
    MGFCScale: TTVisual.ITTTextBox;
    ProstheticIpperExtremityIndex: TTVisual.ITTTextBox;
    TheSicknessImpactProfile: TTVisual.ITTTextBox;
    TrinityExperienceScale: TTVisual.ITTTextBox;
    public amputeeAssessmentFormViewModel: AmputeeAssessmentFormViewModel = new AmputeeAssessmentFormViewModel();
    public get _AmputeeAssessmentForm(): AmputeeAssessmentForm {
        return this._TTObject as AmputeeAssessmentForm;
    }
    private AmputeeAssessmentForm_DocumentUrl: string = '/api/AmputeeAssessmentFormService/AmputeeAssessmentForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.AmputeeAssessmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new AmputeeAssessmentForm();
        this.amputeeAssessmentFormViewModel = new AmputeeAssessmentFormViewModel();
        this._ViewModel = this.amputeeAssessmentFormViewModel;
        this.amputeeAssessmentFormViewModel._AmputeeAssessmentForm = this._TTObject as AmputeeAssessmentForm;
    }

    protected loadViewModel() {
        let that = this;
        that.amputeeAssessmentFormViewModel = this._ViewModel as AmputeeAssessmentFormViewModel;
        that._TTObject = this.amputeeAssessmentFormViewModel._AmputeeAssessmentForm;
        if (this.amputeeAssessmentFormViewModel == null)
            this.amputeeAssessmentFormViewModel = new AmputeeAssessmentFormViewModel();
        if (this.amputeeAssessmentFormViewModel._AmputeeAssessmentForm == null)
            this.amputeeAssessmentFormViewModel._AmputeeAssessmentForm = new AmputeeAssessmentForm();

    }

    async ngOnInit() {
        await this.load(AmputeeAssessmentFormViewModel);
    }

    public onCodeChanged(event): void {
        if (event != null) {
            if (this._AmputeeAssessmentForm != null && this._AmputeeAssessmentForm.Code != event) {
                this._AmputeeAssessmentForm.Code = event;
            }
        }
    }

    public onCreationDateChanged(event): void {
        if (event != null) {
            if (this._AmputeeAssessmentForm != null && this._AmputeeAssessmentForm.CreationDate != event) {
                this._AmputeeAssessmentForm.CreationDate = event;
            }
        }
    }

    public onGroningenScaleChanged(event): void {
        if (event != null) {
            if (this._AmputeeAssessmentForm != null && this._AmputeeAssessmentForm.GroningenScale != event) {
                this._AmputeeAssessmentForm.GroningenScale = event;
            }
        }
    }

    public onMGFCScaleChanged(event): void {
        if (event != null) {
            if (this._AmputeeAssessmentForm != null && this._AmputeeAssessmentForm.MGFCScale != event) {
                this._AmputeeAssessmentForm.MGFCScale = event;
            }
        }
    }

    public onProstheticIpperExtremityIndexChanged(event): void {
        if (event != null) {
            if (this._AmputeeAssessmentForm != null && this._AmputeeAssessmentForm.ProstheticIpperExtremityIndex != event) {
                this._AmputeeAssessmentForm.ProstheticIpperExtremityIndex = event;
            }
        }
    }

    public onTheSicknessImpactProfileChanged(event): void {
        if (event != null) {
            if (this._AmputeeAssessmentForm != null && this._AmputeeAssessmentForm.TheSicknessImpactProfile != event) {
                this._AmputeeAssessmentForm.TheSicknessImpactProfile = event;
            }
        }
    }

    public onTrinityExperienceScaleChanged(event): void {
        if (event != null) {
            if (this._AmputeeAssessmentForm != null && this._AmputeeAssessmentForm.TrinityExperienceScale != event) {
                this._AmputeeAssessmentForm.TrinityExperienceScale = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.TrinityExperienceScale, "Text", this.__ttObject, "TrinityExperienceScale");
        redirectProperty(this.ProstheticIpperExtremityIndex, "Text", this.__ttObject, "ProstheticIpperExtremityIndex");
        redirectProperty(this.TheSicknessImpactProfile, "Text", this.__ttObject, "TheSicknessImpactProfile");
        redirectProperty(this.GroningenScale, "Text", this.__ttObject, "GroningenScale");
        redirectProperty(this.MGFCScale, "Text", this.__ttObject, "MGFCScale");
    }

    public initFormControls(): void {
        this.labelCreationDate = new TTVisual.TTLabel();
        this.labelCreationDate.Text = i18n("M13548", "Ekleme Tarihi / Saati");
        this.labelCreationDate.Name = "labelCreationDate";
        this.labelCreationDate.TabIndex = 17;

        this.CreationDate = new TTVisual.TTDateTimePicker();
        this.CreationDate.Format = DateTimePickerFormat.Long;
        this.CreationDate.Name = "CreationDate";
        this.CreationDate.TabIndex = 16;

        this.labelCode = new TTVisual.TTLabel();
        this.labelCode.Text = "Kodu";
        this.labelCode.Name = "labelCode";
        this.labelCode.TabIndex = 15;

        this.Code = new TTVisual.TTTextBox();
        this.Code.Name = "Code";
        this.Code.TabIndex = 14;

        this.labelMGFCScale = new TTVisual.TTLabel();
        this.labelMGFCScale.Text = i18n("M14502", "Function Classificarin Scale");
        this.labelMGFCScale.Name = "labelMGFCScale";
        this.labelMGFCScale.TabIndex = 13;

        this.MGFCScale = new TTVisual.TTTextBox();
        this.MGFCScale.Name = "MGFCScale";
        this.MGFCScale.TabIndex = 12;

        this.GroningenScale = new TTVisual.TTTextBox();
        this.GroningenScale.Name = "GroningenScale";
        this.GroningenScale.TabIndex = 10;

        this.TheSicknessImpactProfile = new TTVisual.TTTextBox();
        this.TheSicknessImpactProfile.Name = "TheSicknessImpactProfile";
        this.TheSicknessImpactProfile.TabIndex = 8;

        this.ProstheticIpperExtremityIndex = new TTVisual.TTTextBox();
        this.ProstheticIpperExtremityIndex.Name = "ProstheticIpperExtremityIndex";
        this.ProstheticIpperExtremityIndex.TabIndex = 6;

        this.TrinityExperienceScale = new TTVisual.TTTextBox();
        this.TrinityExperienceScale.Name = "TrinityExperienceScale";
        this.TrinityExperienceScale.TabIndex = 4;

        this.labelGroningenScale = new TTVisual.TTLabel();
        this.labelGroningenScale.Text = "Groningen Activity Restriction Scale";
        this.labelGroningenScale.Name = "labelGroningenScale";
        this.labelGroningenScale.TabIndex = 11;

        this.labelTheSicknessImpactProfile = new TTVisual.TTLabel();
        this.labelTheSicknessImpactProfile.Text = "The Sickness Impact Profile";
        this.labelTheSicknessImpactProfile.Name = "labelTheSicknessImpactProfile";
        this.labelTheSicknessImpactProfile.TabIndex = 9;

        this.labelProstheticIpperExtremityIndex = new TTVisual.TTLabel();
        this.labelProstheticIpperExtremityIndex.Text = i18n("M20557", "Prosthetic Ipper Extremity Functional Index");
        this.labelProstheticIpperExtremityIndex.Name = "labelProstheticIpperExtremityIndex";
        this.labelProstheticIpperExtremityIndex.TabIndex = 7;

        this.labelTrinityExperienceScale = new TTVisual.TTLabel();
        this.labelTrinityExperienceScale.Text = "Trinity Amputation, Prostheesis Experience Scales";
        this.labelTrinityExperienceScale.Name = "labelTrinityExperienceScale";
        this.labelTrinityExperienceScale.TabIndex = 5;

        this.Controls = [this.labelCreationDate, this.CreationDate, this.labelCode, this.Code, this.labelMGFCScale, this.MGFCScale, this.GroningenScale, this.TheSicknessImpactProfile, this.ProstheticIpperExtremityIndex, this.TrinityExperienceScale, this.labelGroningenScale, this.labelTheSicknessImpactProfile, this.labelProstheticIpperExtremityIndex, this.labelTrinityExperienceScale];

    }


}
