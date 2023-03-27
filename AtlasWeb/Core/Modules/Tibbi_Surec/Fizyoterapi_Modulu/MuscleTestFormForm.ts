//$149AAEB8
import { Component, OnInit  } from '@angular/core';
import { MuscleTestFormViewModel } from './MuscleTestFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { MuscleTestForm } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ModalStateService } from "Fw/Models/ModalInfo";

import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';

@Component({
    selector: 'MuscleTestForm',
    templateUrl: './MuscleTestFormForm.html',
    providers: [MessageService]
})
export class MuscleTestFormForm extends BaseAdditionalInfoForm implements OnInit {
    Abduction: TTVisual.ITTEnumComboBox;
    Code: TTVisual.ITTTextBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    Extension: TTVisual.ITTEnumComboBox;
    Flexion: TTVisual.ITTEnumComboBox;
    labelAbduction: TTVisual.ITTLabel;
    labelCode: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    labelExtension: TTVisual.ITTLabel;
    labelFlexion: TTVisual.ITTLabel;
    labelRotation: TTVisual.ITTLabel;
    Rotation: TTVisual.ITTEnumComboBox;
    public muscleTestFormViewModel: MuscleTestFormViewModel = new MuscleTestFormViewModel();
    public get _MuscleTestForm(): MuscleTestForm {
        return this._TTObject as MuscleTestForm;
    }
    private MuscleTestForm_DocumentUrl: string = '/api/MuscleTestFormService/MuscleTestForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.MuscleTestForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MuscleTestForm();
        this.muscleTestFormViewModel = new MuscleTestFormViewModel();
        this._ViewModel = this.muscleTestFormViewModel;
        this.muscleTestFormViewModel._MuscleTestForm = this._TTObject as MuscleTestForm;
    }

    protected loadViewModel() {
        let that = this;
        that.muscleTestFormViewModel = this._ViewModel as MuscleTestFormViewModel;
        that._TTObject = this.muscleTestFormViewModel._MuscleTestForm;
        if (this.muscleTestFormViewModel == null)
            this.muscleTestFormViewModel = new MuscleTestFormViewModel();
        if (this.muscleTestFormViewModel._MuscleTestForm == null)
            this.muscleTestFormViewModel._MuscleTestForm = new MuscleTestForm();

    }

    async ngOnInit() {
        await this.load(MuscleTestFormViewModel);
        //this.baseAdditionalInfoFormViewModel.resDoctorName
    }



    public onAbductionChanged(event): void {
        if (event != null) {
            if (this._MuscleTestForm != null && this._MuscleTestForm.Abduction != event) {
                this._MuscleTestForm.Abduction = event;
            }
        }
    }

    public onCodeChanged(event): void {
        if (event != null) {
            if (this._MuscleTestForm != null && this._MuscleTestForm.Code != event) {
                this._MuscleTestForm.Code = event;
            }
        }
    }

    public onCreationDateChanged(event): void {
        if (event != null) {
            if (this._MuscleTestForm != null && this._MuscleTestForm.CreationDate != event) {
                this._MuscleTestForm.CreationDate = event;
            }
        }
    }

    public onExtensionChanged(event): void {
        if (event != null) {
            if (this._MuscleTestForm != null && this._MuscleTestForm.Extension != event) {
                this._MuscleTestForm.Extension = event;
            }
        }
    }

    public onFlexionChanged(event): void {
        if (event != null) {
            if (this._MuscleTestForm != null && this._MuscleTestForm.Flexion != event) {
                this._MuscleTestForm.Flexion = event;
            }
        }
    }

    public onRotationChanged(event): void {
        if (event != null) {
            if (this._MuscleTestForm != null && this._MuscleTestForm.Rotation != event) {
                this._MuscleTestForm.Rotation = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.Extension, "Value", this.__ttObject, "Extension");
        redirectProperty(this.Abduction, "Value", this.__ttObject, "Abduction");
        redirectProperty(this.Flexion, "Value", this.__ttObject, "Flexion");
        redirectProperty(this.Rotation, "Value", this.__ttObject, "Rotation");
    }

    public initFormControls(): void {
        this.labelCreationDate = new TTVisual.TTLabel();
        this.labelCreationDate.Text = i18n("M13548", "Ekleme Tarihi / Saati");
        this.labelCreationDate.Name = "labelCreationDate";
        this.labelCreationDate.TabIndex = 11;

        this.CreationDate = new TTVisual.TTDateTimePicker();
        this.CreationDate.Format = DateTimePickerFormat.Long;
        this.CreationDate.Name = "CreationDate";
        this.CreationDate.TabIndex = 10;

        this.labelCode = new TTVisual.TTLabel();
        this.labelCode.Text = "Kodu";
        this.labelCode.Name = "labelCode";
        this.labelCode.TabIndex = 9;

        this.Code = new TTVisual.TTTextBox();
        this.Code.Name = "Code";
        this.Code.TabIndex = 8;

        this.labelRotation = new TTVisual.TTLabel();
        this.labelRotation.Text = i18n("M21056", "Rotasyon");
        this.labelRotation.Name = "labelRotation";
        this.labelRotation.TabIndex = 7;

        this.Rotation = new TTVisual.TTEnumComboBox();
        this.Rotation.DataTypeName = "MuscleTestEnum";
        this.Rotation.Name = "Rotation";
        this.Rotation.TabIndex = 6;

        this.labelAbduction = new TTVisual.TTLabel();
        this.labelAbduction.Text = i18n("M10409", "Abduksiyon");
        this.labelAbduction.Name = "labelAbduction";
        this.labelAbduction.TabIndex = 5;

        this.Abduction = new TTVisual.TTEnumComboBox();
        this.Abduction.DataTypeName = "MuscleTestEnum";
        this.Abduction.Name = "Abduction";
        this.Abduction.TabIndex = 4;

        this.labelFlexion = new TTVisual.TTLabel();
        this.labelFlexion.Text = i18n("M14435", "Fleksiyon");
        this.labelFlexion.Name = "labelFlexion";
        this.labelFlexion.TabIndex = 3;

        this.Flexion = new TTVisual.TTEnumComboBox();
        this.Flexion.DataTypeName = "MuscleTestEnum";
        this.Flexion.Name = "Flexion";
        this.Flexion.TabIndex = 2;

        this.labelExtension = new TTVisual.TTLabel();
        this.labelExtension.Text = i18n("M13594", "Ekstansiyon");
        this.labelExtension.Name = "labelExtension";
        this.labelExtension.TabIndex = 1;

        this.Extension = new TTVisual.TTEnumComboBox();
        this.Extension.DataTypeName = "MuscleTestEnum";
        this.Extension.Name = "Extension";
        this.Extension.TabIndex = 0;

        this.Controls = [this.labelCreationDate, this.CreationDate, this.labelCode, this.Code, this.labelRotation, this.Rotation, this.labelAbduction, this.Abduction, this.labelFlexion, this.Flexion, this.labelExtension, this.Extension];

    }


}
