//$652A4C36
import { Component, OnInit  } from '@angular/core';
import { RangeOfMotionMeasurementFormViewModel } from './RangeOfMotionMeasurementFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { RangeOfMotionMeasurementForm } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'RangeOfMotionMeasurementForm',
    templateUrl: './RangeOfMotionMeasurementFormForm.html',
    providers: [MessageService]
})
export class RangeOfMotionMeasurementFormForm extends BaseAdditionalInfoForm implements OnInit {
    AbductionEHA: TTVisual.ITTTextBox;
    AbductionHABK: TTVisual.ITTTextBox;
    AbductionHAOK: TTVisual.ITTTextBox;
    AbductionHASK: TTVisual.ITTTextBox;
    Code: TTVisual.ITTTextBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    ExtensionEHA: TTVisual.ITTTextBox;
    ExtensionHABK: TTVisual.ITTTextBox;
    ExtensionHAOK: TTVisual.ITTTextBox;
    ExtensionHASK: TTVisual.ITTTextBox;
    FlexionEHA: TTVisual.ITTTextBox;
    FlexionHABK: TTVisual.ITTTextBox;
    FlexionHAOK: TTVisual.ITTTextBox;
    FlexionHASK: TTVisual.ITTTextBox;
    labelAbductionEHA: TTVisual.ITTLabel;
    labelAbductionHABK: TTVisual.ITTLabel;
    labelAbductionHAOK: TTVisual.ITTLabel;
    labelAbductionHASK: TTVisual.ITTLabel;
    labelCode: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    labelExtensionEHA: TTVisual.ITTLabel;
    labelExtensionHABK: TTVisual.ITTLabel;
    labelExtensionHAOK: TTVisual.ITTLabel;
    labelExtensionHASK: TTVisual.ITTLabel;
    labelFlexionEHA: TTVisual.ITTLabel;
    labelFlexionHABK: TTVisual.ITTLabel;
    labelFlexionHAOK: TTVisual.ITTLabel;
    labelFlexionHASK: TTVisual.ITTLabel;
    labelRotationEHA: TTVisual.ITTLabel;
    labelRotationHABK: TTVisual.ITTLabel;
    labelRotationHAOK: TTVisual.ITTLabel;
    labelRotationHASK: TTVisual.ITTLabel;
    RotationEHA: TTVisual.ITTTextBox;
    RotationHABK: TTVisual.ITTTextBox;
    RotationHAOK: TTVisual.ITTTextBox;
    RotationHASK: TTVisual.ITTTextBox;
    public rangeOfMotionMeasurementFormViewModel: RangeOfMotionMeasurementFormViewModel = new RangeOfMotionMeasurementFormViewModel();
    public get _RangeOfMotionMeasurementForm(): RangeOfMotionMeasurementForm {
        return this._TTObject as RangeOfMotionMeasurementForm;
    }
    private RangeOfMotionMeasurementForm_DocumentUrl: string = '/api/RangeOfMotionMeasurementFormService/RangeOfMotionMeasurementForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.RangeOfMotionMeasurementForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new RangeOfMotionMeasurementForm();
        this.rangeOfMotionMeasurementFormViewModel = new RangeOfMotionMeasurementFormViewModel();
        this._ViewModel = this.rangeOfMotionMeasurementFormViewModel;
        this.rangeOfMotionMeasurementFormViewModel._RangeOfMotionMeasurementForm = this._TTObject as RangeOfMotionMeasurementForm;
    }

    protected loadViewModel() {
        let that = this;
        that.rangeOfMotionMeasurementFormViewModel = this._ViewModel as RangeOfMotionMeasurementFormViewModel;
        that._TTObject = this.rangeOfMotionMeasurementFormViewModel._RangeOfMotionMeasurementForm;
        if (this.rangeOfMotionMeasurementFormViewModel == null)
            this.rangeOfMotionMeasurementFormViewModel = new RangeOfMotionMeasurementFormViewModel();
        if (this.rangeOfMotionMeasurementFormViewModel._RangeOfMotionMeasurementForm == null)
            this.rangeOfMotionMeasurementFormViewModel._RangeOfMotionMeasurementForm = new RangeOfMotionMeasurementForm();

    }

    async ngOnInit() {
        await this.load(RangeOfMotionMeasurementFormViewModel);
    }

    public onAbductionEHAChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.AbductionEHA != event) {
                this._RangeOfMotionMeasurementForm.AbductionEHA = event;
            }
        }
    }

    public onAbductionHABKChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.AbductionHABK != event) {
                this._RangeOfMotionMeasurementForm.AbductionHABK = event;
            }
        }
    }

    public onAbductionHAOKChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.AbductionHAOK != event) {
                this._RangeOfMotionMeasurementForm.AbductionHAOK = event;
            }
        }
    }

    public onAbductionHASKChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.AbductionHASK != event) {
                this._RangeOfMotionMeasurementForm.AbductionHASK = event;
            }
        }
    }

    public onCodeChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.Code != event) {
                this._RangeOfMotionMeasurementForm.Code = event;
            }
        }
    }

    public onCreationDateChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.CreationDate != event) {
                this._RangeOfMotionMeasurementForm.CreationDate = event;
            }
        }
    }

    public onExtensionEHAChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.ExtensionEHA != event) {
                this._RangeOfMotionMeasurementForm.ExtensionEHA = event;
            }
        }
    }

    public onExtensionHABKChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.ExtensionHABK != event) {
                this._RangeOfMotionMeasurementForm.ExtensionHABK = event;
            }
        }
    }

    public onExtensionHAOKChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.ExtensionHAOK != event) {
                this._RangeOfMotionMeasurementForm.ExtensionHAOK = event;
            }
        }
    }

    public onExtensionHASKChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.ExtensionHASK != event) {
                this._RangeOfMotionMeasurementForm.ExtensionHASK = event;
            }
        }
    }

    public onFlexionEHAChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.FlexionEHA != event) {
                this._RangeOfMotionMeasurementForm.FlexionEHA = event;
            }
        }
    }

    public onFlexionHABKChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.FlexionHABK != event) {
                this._RangeOfMotionMeasurementForm.FlexionHABK = event;
            }
        }
    }

    public onFlexionHAOKChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.FlexionHAOK != event) {
                this._RangeOfMotionMeasurementForm.FlexionHAOK = event;
            }
        }
    }

    public onFlexionHASKChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.FlexionHASK != event) {
                this._RangeOfMotionMeasurementForm.FlexionHASK = event;
            }
        }
    }

    public onRotationEHAChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.RotationEHA != event) {
                this._RangeOfMotionMeasurementForm.RotationEHA = event;
            }
        }
    }

    public onRotationHABKChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.RotationHABK != event) {
                this._RangeOfMotionMeasurementForm.RotationHABK = event;
            }
        }
    }

    public onRotationHAOKChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.RotationHAOK != event) {
                this._RangeOfMotionMeasurementForm.RotationHAOK = event;
            }
        }
    }

    public onRotationHASKChanged(event): void {
        if (event != null) {
            if (this._RangeOfMotionMeasurementForm != null && this._RangeOfMotionMeasurementForm.RotationHASK != event) {
                this._RangeOfMotionMeasurementForm.RotationHASK = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.ExtensionEHA, "Text", this.__ttObject, "ExtensionEHA");
        redirectProperty(this.FlexionEHA, "Text", this.__ttObject, "FlexionEHA");
        redirectProperty(this.AbductionEHA, "Text", this.__ttObject, "AbductionEHA");
        redirectProperty(this.RotationEHA, "Text", this.__ttObject, "RotationEHA");
        redirectProperty(this.ExtensionHABK, "Text", this.__ttObject, "ExtensionHABK");
        redirectProperty(this.FlexionHABK, "Text", this.__ttObject, "FlexionHABK");
        redirectProperty(this.AbductionHABK, "Text", this.__ttObject, "AbductionHABK");
        redirectProperty(this.RotationHABK, "Text", this.__ttObject, "RotationHABK");
        redirectProperty(this.ExtensionHASK, "Text", this.__ttObject, "ExtensionHASK");
        redirectProperty(this.FlexionHAOK, "Text", this.__ttObject, "FlexionHAOK");
        redirectProperty(this.AbductionHAOK, "Text", this.__ttObject, "AbductionHAOK");
        redirectProperty(this.RotationHAOK, "Text", this.__ttObject, "RotationHAOK");
        redirectProperty(this.ExtensionHAOK, "Text", this.__ttObject, "ExtensionHAOK");
        redirectProperty(this.FlexionHASK, "Text", this.__ttObject, "FlexionHASK");
        redirectProperty(this.AbductionHASK, "Text", this.__ttObject, "AbductionHASK");
        redirectProperty(this.RotationHASK, "Text", this.__ttObject, "RotationHASK");
    }

    public initFormControls(): void {
        this.labelRotationHASK = new TTVisual.TTLabel();
        this.labelRotationHASK.Text = i18n("M21060", "Rotasyon ? Hareket Arkı Sonunda Kısıtlı");
        this.labelRotationHASK.Name = "labelRotationHASK";
        this.labelRotationHASK.TabIndex = 35;

        this.RotationHASK = new TTVisual.TTTextBox();
        this.RotationHASK.Name = "RotationHASK";
        this.RotationHASK.TabIndex = 34;

        this.RotationHAOK = new TTVisual.TTTextBox();
        this.RotationHAOK.Name = "RotationHAOK";
        this.RotationHAOK.TabIndex = 32;

        this.RotationHABK = new TTVisual.TTTextBox();
        this.RotationHABK.Name = "RotationHABK";
        this.RotationHABK.TabIndex = 30;

        this.RotationEHA = new TTVisual.TTTextBox();
        this.RotationEHA.Name = "RotationEHA";
        this.RotationEHA.TabIndex = 28;

        this.AbductionHASK = new TTVisual.TTTextBox();
        this.AbductionHASK.Name = "AbductionHASK";
        this.AbductionHASK.TabIndex = 26;

        this.AbductionHAOK = new TTVisual.TTTextBox();
        this.AbductionHAOK.Name = "AbductionHAOK";
        this.AbductionHAOK.TabIndex = 24;

        this.AbductionHABK = new TTVisual.TTTextBox();
        this.AbductionHABK.Name = "AbductionHABK";
        this.AbductionHABK.TabIndex = 22;

        this.AbductionEHA = new TTVisual.TTTextBox();
        this.AbductionEHA.Name = "AbductionEHA";
        this.AbductionEHA.TabIndex = 20;

        this.FlexionHASK = new TTVisual.TTTextBox();
        this.FlexionHASK.Name = "FlexionHASK";
        this.FlexionHASK.TabIndex = 18;

        this.FlexionHAOK = new TTVisual.TTTextBox();
        this.FlexionHAOK.Name = "FlexionHAOK";
        this.FlexionHAOK.TabIndex = 16;

        this.FlexionHABK = new TTVisual.TTTextBox();
        this.FlexionHABK.Name = "FlexionHABK";
        this.FlexionHABK.TabIndex = 14;

        this.FlexionEHA = new TTVisual.TTTextBox();
        this.FlexionEHA.Name = "FlexionEHA";
        this.FlexionEHA.TabIndex = 12;

        this.ExtensionHAOK = new TTVisual.TTTextBox();
        this.ExtensionHAOK.Name = "ExtensionHAOK";
        this.ExtensionHAOK.TabIndex = 10;

        this.ExtensionHASK = new TTVisual.TTTextBox();
        this.ExtensionHASK.Name = "ExtensionHASK";
        this.ExtensionHASK.TabIndex = 8;

        this.ExtensionHABK = new TTVisual.TTTextBox();
        this.ExtensionHABK.Name = "ExtensionHABK";
        this.ExtensionHABK.TabIndex = 6;

        this.ExtensionEHA = new TTVisual.TTTextBox();
        this.ExtensionEHA.Name = "ExtensionEHA";
        this.ExtensionEHA.TabIndex = 4;

        this.Code = new TTVisual.TTTextBox();
        this.Code.Name = "Code";
        this.Code.TabIndex = 0;

        this.labelRotationHAOK = new TTVisual.TTLabel();
        this.labelRotationHAOK.Text = i18n("M21059", "Rotasyon ? Hareket Arkı Ortasında Kısıtlı");
        this.labelRotationHAOK.Name = "labelRotationHAOK";
        this.labelRotationHAOK.TabIndex = 33;

        this.labelRotationHABK = new TTVisual.TTLabel();
        this.labelRotationHABK.Text = i18n("M21058", "Rotasyon ? Hareket Arkı Başında Kısıtlı");
        this.labelRotationHABK.Name = "labelRotationHABK";
        this.labelRotationHABK.TabIndex = 31;

        this.labelRotationEHA = new TTVisual.TTLabel();
        this.labelRotationEHA.Text = "Rotasyon ? EHA";
        this.labelRotationEHA.Name = "labelRotationEHA";
        this.labelRotationEHA.TabIndex = 29;

        this.labelAbductionHASK = new TTVisual.TTLabel();
        this.labelAbductionHASK.Text = i18n("M10413", "Abduksiyon ? Hareket Arkı Sonunda Kısıtlı");
        this.labelAbductionHASK.Name = "labelAbductionHASK";
        this.labelAbductionHASK.TabIndex = 27;

        this.labelAbductionHAOK = new TTVisual.TTLabel();
        this.labelAbductionHAOK.Text = i18n("M10412", "Abduksiyon ? Hareket Arkı Ortasında Kısıtlı");
        this.labelAbductionHAOK.Name = "labelAbductionHAOK";
        this.labelAbductionHAOK.TabIndex = 25;

        this.labelAbductionHABK = new TTVisual.TTLabel();
        this.labelAbductionHABK.Text = i18n("M10411", "Abduksiyon ? Hareket Arkı Başında Kısıtlı");
        this.labelAbductionHABK.Name = "labelAbductionHABK";
        this.labelAbductionHABK.TabIndex = 23;

        this.labelAbductionEHA = new TTVisual.TTLabel();
        this.labelAbductionEHA.Text = i18n("M10410", "Abduksiyon - EHA");
        this.labelAbductionEHA.Name = "labelAbductionEHA";
        this.labelAbductionEHA.TabIndex = 21;

        this.labelFlexionHASK = new TTVisual.TTLabel();
        this.labelFlexionHASK.Text = i18n("M14439", "Fleksiyon ? Hareket Arkı Sonunda Kısıtlı");
        this.labelFlexionHASK.Name = "labelFlexionHASK";
        this.labelFlexionHASK.TabIndex = 19;

        this.labelFlexionHAOK = new TTVisual.TTLabel();
        this.labelFlexionHAOK.Text = i18n("M14438", "Fleksiyon ? Hareket Arkı Ortasında Kısıtlı");
        this.labelFlexionHAOK.Name = "labelFlexionHAOK";
        this.labelFlexionHAOK.TabIndex = 17;

        this.labelFlexionHABK = new TTVisual.TTLabel();
        this.labelFlexionHABK.Text = i18n("M14437", "Fleksiyon ? Hareket Arkı Başında Kısıtlı");
        this.labelFlexionHABK.Name = "labelFlexionHABK";
        this.labelFlexionHABK.TabIndex = 15;

        this.labelFlexionEHA = new TTVisual.TTLabel();
        this.labelFlexionEHA.Text = i18n("M14436", "Fleksiyon ? EHA");
        this.labelFlexionEHA.Name = "labelFlexionEHA";
        this.labelFlexionEHA.TabIndex = 13;

        this.labelExtensionHAOK = new TTVisual.TTLabel();
        this.labelExtensionHAOK.Text = "Ekstensiyon ? Hareket Arkı Ortasında Kısıtlı";
        this.labelExtensionHAOK.Name = "labelExtensionHAOK";
        this.labelExtensionHAOK.TabIndex = 11;

        this.labelExtensionHASK = new TTVisual.TTLabel();
        this.labelExtensionHASK.Text = "Ekstensiyon ? Hareket Arkı Sonunda Kısıtlı";
        this.labelExtensionHASK.Name = "labelExtensionHASK";
        this.labelExtensionHASK.TabIndex = 9;

        this.labelExtensionHABK = new TTVisual.TTLabel();
        this.labelExtensionHABK.Text = "Ekstensiyon ? Hareket Arkı Başında Kısıtlı";
        this.labelExtensionHABK.Name = "labelExtensionHABK";
        this.labelExtensionHABK.TabIndex = 7;

        this.labelExtensionEHA = new TTVisual.TTLabel();
        this.labelExtensionEHA.Text = "Ekstensiyon ? EHA";
        this.labelExtensionEHA.Name = "labelExtensionEHA";
        this.labelExtensionEHA.TabIndex = 5;

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

        this.Controls = [this.labelRotationHASK, this.RotationHASK, this.RotationHAOK, this.RotationHABK, this.RotationEHA, this.AbductionHASK, this.AbductionHAOK, this.AbductionHABK, this.AbductionEHA, this.FlexionHASK, this.FlexionHAOK, this.FlexionHABK, this.FlexionEHA, this.ExtensionHAOK, this.ExtensionHASK, this.ExtensionHABK, this.ExtensionEHA, this.Code, this.labelRotationHAOK, this.labelRotationHABK, this.labelRotationEHA, this.labelAbductionHASK, this.labelAbductionHAOK, this.labelAbductionHABK, this.labelAbductionEHA, this.labelFlexionHASK, this.labelFlexionHAOK, this.labelFlexionHABK, this.labelFlexionEHA, this.labelExtensionHAOK, this.labelExtensionHASK, this.labelExtensionHABK, this.labelExtensionEHA, this.labelCreationDate, this.CreationDate, this.labelCode];

    }


}
