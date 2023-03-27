//$575B08D8
import { Component, OnInit, NgZone } from '@angular/core';
import { LaboratoryRequestInfoFormViewModel } from "./LaboratoryRequestInfoFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { LaboratoryRequest } from 'NebulaClient/Model/AtlasClientModel';

import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";



@Component({
    selector: 'LaboratoryRequestInfoForm',
    templateUrl: './LaboratoryRequestInfoForm.html',
    providers: [MessageService]
})
export class LaboratoryRequestInfoForm extends TTVisual.TTForm implements OnInit {
    Gebelik: TTVisual.ITTEnumComboBox;
    labelGebelik: TTVisual.ITTLabel;
    labelPreInformation: TTVisual.ITTLabel;
    labelSonAdetTarihi: TTVisual.ITTLabel;
    Note: TTVisual.ITTTextBox;
    PreDiagnosis: TTVisual.ITTTextBox;
    SonAdetTarihi: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    Urgent: TTVisual.ITTCheckBox;
    public laboratoryRequestInfoFormViewModel: LaboratoryRequestInfoFormViewModel = new LaboratoryRequestInfoFormViewModel();
    public get _LaboratoryRequest(): LaboratoryRequest {
        return this._TTObject as LaboratoryRequest;
    }
    private LaboratoryRequestInfoForm_DocumentUrl: string = '/api/LaboratoryRequestService/LaboratoryRequestInfoForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super("LABORATORYREQUEST", "LaboratoryRequestInfoForm");
        this._DocumentServiceUrl = this.LaboratoryRequestInfoForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new LaboratoryRequest();
        this.laboratoryRequestInfoFormViewModel = new LaboratoryRequestInfoFormViewModel();
        this._ViewModel = this.laboratoryRequestInfoFormViewModel;
        this.laboratoryRequestInfoFormViewModel._LaboratoryRequest = this._TTObject as LaboratoryRequest;
    }

    protected loadViewModel() {
        let that = this;
        that.laboratoryRequestInfoFormViewModel = this._ViewModel as LaboratoryRequestInfoFormViewModel;
        that._TTObject = this.laboratoryRequestInfoFormViewModel._LaboratoryRequest;
        if (this.laboratoryRequestInfoFormViewModel == null)
            this.laboratoryRequestInfoFormViewModel = new LaboratoryRequestInfoFormViewModel();
        if (this.laboratoryRequestInfoFormViewModel._LaboratoryRequest == null)
            this.laboratoryRequestInfoFormViewModel._LaboratoryRequest = new LaboratoryRequest();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(LaboratoryRequestInfoFormViewModel);
  
    }


    public onGebelikChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.Pregnancy != event) {
                this._LaboratoryRequest.Pregnancy = event;
            }
        }
    }

    public onNoteChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.Notes != event) {
                this._LaboratoryRequest.Notes = event;
            }
        }
    }

    public onPreDiagnosisChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.Prediagnosis != event) {
                this._LaboratoryRequest.Prediagnosis = event;
            }
        }
    }

    public onSonAdetTarihiChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.LastMensturationDate != event) {
                this._LaboratoryRequest.LastMensturationDate = event;
            }
        }
    }

    public onUrgentChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.Urgent != event) {
                this._LaboratoryRequest.Urgent = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.PreDiagnosis, "Text", this.__ttObject, "Prediagnosis");
        redirectProperty(this.Urgent, "Value", this.__ttObject, "Urgent");
        redirectProperty(this.Note, "Text", this.__ttObject, "Notes");
        redirectProperty(this.Gebelik, "Value", this.__ttObject, "Pregnancy");
        redirectProperty(this.SonAdetTarihi, "Value", this.__ttObject, "LastMensturationDate");
    }

    public initFormControls(): void {
        this.PreDiagnosis = new TTVisual.TTTextBox();
        this.PreDiagnosis.Multiline = true;
        this.PreDiagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PreDiagnosis.Name = "PreDiagnosis";
        this.PreDiagnosis.TabIndex = 4;

        this.Note = new TTVisual.TTTextBox();
        this.Note.Multiline = true;
        this.Note.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Note.Name = "Note";
        this.Note.TabIndex = 5;

        this.Urgent = new TTVisual.TTCheckBox();
        this.Urgent.Value = false;
        this.Urgent.Text = "Acil";
        this.Urgent.Name = "Urgent";
        this.Urgent.TabIndex = 8;

        this.labelPreInformation = new TTVisual.TTLabel();
        this.labelPreInformation.Text = i18n("M17529", "Kısa Anamnez ve Klinik Bulgular");
        this.labelPreInformation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelPreInformation.ForeColor = "#000000";
        this.labelPreInformation.Name = "labelPreInformation";
        this.labelPreInformation.TabIndex = 37;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M19476", "Not");
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 40;

        this.Gebelik = new TTVisual.TTEnumComboBox();
        this.Gebelik.DataTypeName = "LaboratoryPregnancyEnum";
        this.Gebelik.Name = "Gebelik";
        this.Gebelik.TabIndex = 52;

        this.labelGebelik = new TTVisual.TTLabel();
        this.labelGebelik.Text = "Gebelik";
        this.labelGebelik.ForeColor = "#000080";
        this.labelGebelik.Name = "labelGebelik";
        this.labelGebelik.TabIndex = 53;

        this.labelSonAdetTarihi = new TTVisual.TTLabel();
        this.labelSonAdetTarihi.Text = i18n("M22037", "Son Adet Tarihi");
        this.labelSonAdetTarihi.ForeColor = "#000080";
        this.labelSonAdetTarihi.Name = "labelSonAdetTarihi";
        this.labelSonAdetTarihi.TabIndex = 55;

        this.SonAdetTarihi = new TTVisual.TTDateTimePicker();
        this.SonAdetTarihi.Format = DateTimePickerFormat.Long;
        this.SonAdetTarihi.Name = "SonAdetTarihi";
        this.SonAdetTarihi.TabIndex = 54;

        this.Controls = [this.PreDiagnosis, this.Note, this.Urgent, this.labelPreInformation, this.ttlabel1, this.Gebelik, this.labelGebelik, this.labelSonAdetTarihi, this.SonAdetTarihi];

    }


}
