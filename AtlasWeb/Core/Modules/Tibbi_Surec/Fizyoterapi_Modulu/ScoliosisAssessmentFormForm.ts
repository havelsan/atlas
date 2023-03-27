//$68256D8B
import { Component, OnInit  } from '@angular/core';
import { ScoliosisAssessmentFormViewModel } from './ScoliosisAssessmentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ScoliosisAssessmentForm } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'ScoliosisAssessmentForm',
    templateUrl: './ScoliosisAssessmentFormForm.html',
    providers: [MessageService]
})
export class ScoliosisAssessmentFormForm extends BaseAdditionalInfoForm implements OnInit {
    ChestPosture: TTVisual.ITTEnumComboBox;
    Code: TTVisual.ITTTextBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    FeetPosture: TTVisual.ITTEnumComboBox;
    HeadPosture: TTVisual.ITTEnumComboBox;
    labelChestPosture: TTVisual.ITTLabel;
    labelCode: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    labelFeetPosture: TTVisual.ITTLabel;
    labelHeadPosture: TTVisual.ITTLabel;
    labelLegPosture: TTVisual.ITTLabel;
    labelLegsLength: TTVisual.ITTLabel;
    labelScapulaPosture: TTVisual.ITTLabel;
    labelShoulderPosture: TTVisual.ITTLabel;
    labelSpinePosture: TTVisual.ITTLabel;
    LegPosture: TTVisual.ITTEnumComboBox;
    LegsLength: TTVisual.ITTEnumComboBox;
    ScapulaPosture: TTVisual.ITTEnumComboBox;
    ShoulderPosture: TTVisual.ITTEnumComboBox;
    SpinePosture: TTVisual.ITTEnumComboBox;
    public scoliosisAssessmentFormViewModel: ScoliosisAssessmentFormViewModel = new ScoliosisAssessmentFormViewModel();
    public get _ScoliosisAssessmentForm(): ScoliosisAssessmentForm {
        return this._TTObject as ScoliosisAssessmentForm;
    }
    private ScoliosisAssessmentForm_DocumentUrl: string = '/api/ScoliosisAssessmentFormService/ScoliosisAssessmentForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.ScoliosisAssessmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ScoliosisAssessmentForm();
        this.scoliosisAssessmentFormViewModel = new ScoliosisAssessmentFormViewModel();
        this._ViewModel = this.scoliosisAssessmentFormViewModel;
        this.scoliosisAssessmentFormViewModel._ScoliosisAssessmentForm = this._TTObject as ScoliosisAssessmentForm;
    }

    protected loadViewModel() {
        let that = this;
        that.scoliosisAssessmentFormViewModel = this._ViewModel as ScoliosisAssessmentFormViewModel;
        that._TTObject = this.scoliosisAssessmentFormViewModel._ScoliosisAssessmentForm;
        if (this.scoliosisAssessmentFormViewModel == null)
            this.scoliosisAssessmentFormViewModel = new ScoliosisAssessmentFormViewModel();
        if (this.scoliosisAssessmentFormViewModel._ScoliosisAssessmentForm == null)
            this.scoliosisAssessmentFormViewModel._ScoliosisAssessmentForm = new ScoliosisAssessmentForm();

    }

    async ngOnInit() {
        await this.load(ScoliosisAssessmentFormViewModel);
    }

    public onChestPostureChanged(event): void {
        if (event != null) {
            if (this._ScoliosisAssessmentForm != null && this._ScoliosisAssessmentForm.ChestPosture != event) {
                this._ScoliosisAssessmentForm.ChestPosture = event;
            }
        }
    }

    public onCodeChanged(event): void {
        if (event != null) {
            if (this._ScoliosisAssessmentForm != null && this._ScoliosisAssessmentForm.Code != event) {
                this._ScoliosisAssessmentForm.Code = event;
            }
        }
    }

    public onCreationDateChanged(event): void {
        if (event != null) {
            if (this._ScoliosisAssessmentForm != null && this._ScoliosisAssessmentForm.CreationDate != event) {
                this._ScoliosisAssessmentForm.CreationDate = event;
            }
        }
    }

    public onFeetPostureChanged(event): void {
        if (event != null) {
            if (this._ScoliosisAssessmentForm != null && this._ScoliosisAssessmentForm.FeetPosture != event) {
                this._ScoliosisAssessmentForm.FeetPosture = event;
            }
        }
    }

    public onHeadPostureChanged(event): void {
        if (event != null) {
            if (this._ScoliosisAssessmentForm != null && this._ScoliosisAssessmentForm.HeadPosture != event) {
                this._ScoliosisAssessmentForm.HeadPosture = event;
            }
        }
    }

    public onLegPostureChanged(event): void {
        if (event != null) {
            if (this._ScoliosisAssessmentForm != null && this._ScoliosisAssessmentForm.LegPosture != event) {
                this._ScoliosisAssessmentForm.LegPosture = event;
            }
        }
    }

    public onLegsLengthChanged(event): void {
        if (event != null) {
            if (this._ScoliosisAssessmentForm != null && this._ScoliosisAssessmentForm.LegsLength != event) {
                this._ScoliosisAssessmentForm.LegsLength = event;
            }
        }
    }

    public onScapulaPostureChanged(event): void {
        if (event != null) {
            if (this._ScoliosisAssessmentForm != null && this._ScoliosisAssessmentForm.ScapulaPosture != event) {
                this._ScoliosisAssessmentForm.ScapulaPosture = event;
            }
        }
    }

    public onShoulderPostureChanged(event): void {
        if (event != null) {
            if (this._ScoliosisAssessmentForm != null && this._ScoliosisAssessmentForm.ShoulderPosture != event) {
                this._ScoliosisAssessmentForm.ShoulderPosture = event;
            }
        }
    }

    public onSpinePostureChanged(event): void {
        if (event != null) {
            if (this._ScoliosisAssessmentForm != null && this._ScoliosisAssessmentForm.SpinePosture != event) {
                this._ScoliosisAssessmentForm.SpinePosture = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.HeadPosture, "Value", this.__ttObject, "HeadPosture");
        redirectProperty(this.SpinePosture, "Value", this.__ttObject, "SpinePosture");
        redirectProperty(this.ChestPosture, "Value", this.__ttObject, "ChestPosture");
        redirectProperty(this.LegPosture, "Value", this.__ttObject, "LegPosture");
        redirectProperty(this.ShoulderPosture, "Value", this.__ttObject, "ShoulderPosture");
        redirectProperty(this.FeetPosture, "Value", this.__ttObject, "FeetPosture");
        redirectProperty(this.ScapulaPosture, "Value", this.__ttObject, "ScapulaPosture");
        redirectProperty(this.LegsLength, "Value", this.__ttObject, "LegsLength");
    }

    public initFormControls(): void {
        this.labelLegsLength = new TTVisual.TTLabel();
        this.labelLegsLength.Text = i18n("M11398", "Bacak Uzunlukları");
        this.labelLegsLength.Name = "labelLegsLength";
        this.labelLegsLength.TabIndex = 19;

        this.LegsLength = new TTVisual.TTEnumComboBox();
        this.LegsLength.DataTypeName = "LegsLengthEnum";
        this.LegsLength.Name = "LegsLength";
        this.LegsLength.TabIndex = 18;

        this.labelFeetPosture = new TTVisual.TTLabel();
        this.labelFeetPosture.Text = i18n("M11278", "Ayaklar");
        this.labelFeetPosture.Name = "labelFeetPosture";
        this.labelFeetPosture.TabIndex = 17;

        this.FeetPosture = new TTVisual.TTEnumComboBox();
        this.FeetPosture.DataTypeName = "FeetPostureEnum";
        this.FeetPosture.Name = "FeetPosture";
        this.FeetPosture.TabIndex = 16;

        this.labelLegPosture = new TTVisual.TTLabel();
        this.labelLegPosture.Text = i18n("M11399", "Bacaklar");
        this.labelLegPosture.Name = "labelLegPosture";
        this.labelLegPosture.TabIndex = 15;

        this.LegPosture = new TTVisual.TTEnumComboBox();
        this.LegPosture.DataTypeName = "LegPostureEnum";
        this.LegPosture.Name = "LegPosture";
        this.LegPosture.TabIndex = 14;

        this.labelSpinePosture = new TTVisual.TTLabel();
        this.labelSpinePosture.Text = i18n("M19649", "Omurga");
        this.labelSpinePosture.Name = "labelSpinePosture";
        this.labelSpinePosture.TabIndex = 13;

        this.SpinePosture = new TTVisual.TTEnumComboBox();
        this.SpinePosture.DataTypeName = "SpinePostureEnum";
        this.SpinePosture.Name = "SpinePosture";
        this.SpinePosture.TabIndex = 12;

        this.labelScapulaPosture = new TTVisual.TTLabel();
        this.labelScapulaPosture.Text = i18n("M21964", "Skapula");
        this.labelScapulaPosture.Name = "labelScapulaPosture";
        this.labelScapulaPosture.TabIndex = 11;

        this.ScapulaPosture = new TTVisual.TTEnumComboBox();
        this.ScapulaPosture.DataTypeName = "ScapulaPostureEnum";
        this.ScapulaPosture.Name = "ScapulaPosture";
        this.ScapulaPosture.TabIndex = 10;

        this.labelShoulderPosture = new TTVisual.TTLabel();
        this.labelShoulderPosture.Text = i18n("M19650", "Omuz");
        this.labelShoulderPosture.Name = "labelShoulderPosture";
        this.labelShoulderPosture.TabIndex = 9;

        this.ShoulderPosture = new TTVisual.TTEnumComboBox();
        this.ShoulderPosture.DataTypeName = "ShoulderPostureEnum";
        this.ShoulderPosture.Name = "ShoulderPosture";
        this.ShoulderPosture.TabIndex = 8;

        this.labelChestPosture = new TTVisual.TTLabel();
        this.labelChestPosture.Text = i18n("M14846", "Göğüs");
        this.labelChestPosture.Name = "labelChestPosture";
        this.labelChestPosture.TabIndex = 7;

        this.ChestPosture = new TTVisual.TTEnumComboBox();
        this.ChestPosture.DataTypeName = "ChestPostureEnum";
        this.ChestPosture.Name = "ChestPosture";
        this.ChestPosture.TabIndex = 6;

        this.labelHeadPosture = new TTVisual.TTLabel();
        this.labelHeadPosture.Text = i18n("M11583", "Baş");
        this.labelHeadPosture.Name = "labelHeadPosture";
        this.labelHeadPosture.TabIndex = 5;

        this.HeadPosture = new TTVisual.TTEnumComboBox();
        this.HeadPosture.DataTypeName = "HeadPostureEnum";
        this.HeadPosture.Name = "HeadPosture";
        this.HeadPosture.TabIndex = 4;

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

        this.Controls = [this.labelLegsLength, this.LegsLength, this.labelFeetPosture, this.FeetPosture, this.labelLegPosture, this.LegPosture, this.labelSpinePosture, this.SpinePosture, this.labelScapulaPosture, this.ScapulaPosture, this.labelShoulderPosture, this.ShoulderPosture, this.labelChestPosture, this.ChestPosture, this.labelHeadPosture, this.HeadPosture, this.labelCreationDate, this.CreationDate, this.labelCode, this.Code];

    }


}
