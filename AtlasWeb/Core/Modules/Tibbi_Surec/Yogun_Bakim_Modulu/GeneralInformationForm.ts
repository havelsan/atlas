//$6A47F2DE
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { GeneralInformationFormViewModel } from './GeneralInformationFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseMultipleDataEntryForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseMultipleDataEntryForm";
import { GeneralInformation } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'GeneralInformationForm',
    templateUrl: './GeneralInformationForm.html',
    providers: [MessageService]
})
export class GeneralInformationForm extends BaseMultipleDataEntryForm implements OnInit {
    AnalRegion: TTVisual.ITTTextBox;
    EntryDate: TTVisual.ITTDateTimePicker;
    labelAnalRegion: TTVisual.ITTLabel;
    labelEntryDate: TTVisual.ITTLabel;
    labelMurmur: TTVisual.ITTLabel;
    labelNatal: TTVisual.ITTLabel;
    labelNavel: TTVisual.ITTLabel;
    labelNavelCord: TTVisual.ITTLabel;
    labelPostnatal: TTVisual.ITTLabel;
    labelPrenatal: TTVisual.ITTLabel;
    labelSkin: TTVisual.ITTLabel;
    labelSuckingReflex: TTVisual.ITTLabel;
    labelTreatmentPlan: TTVisual.ITTLabel;
    Murmur: TTVisual.ITTTextBox;
    Natal: TTVisual.ITTTextBox;
    Navel: TTVisual.ITTTextBox;
    NavelCord: TTVisual.ITTTextBox;
    Postnatal: TTVisual.ITTTextBox;
    Prenatal: TTVisual.ITTTextBox;
    Skin: TTVisual.ITTTextBox;
    SuckingReflex: TTVisual.ITTTextBox;
    TreatmentPlan: TTVisual.ITTTextBox;
    public generalInformationFormViewModel: GeneralInformationFormViewModel = new GeneralInformationFormViewModel();
    public get _GeneralInformation(): GeneralInformation {
        return this._TTObject as GeneralInformation;
    }
    private GeneralInformationForm_DocumentUrl: string = '/api/GeneralInformationService/GeneralInformationForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.GeneralInformationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new GeneralInformation();
        this.generalInformationFormViewModel = new GeneralInformationFormViewModel();
        this._ViewModel = this.generalInformationFormViewModel;
        this.generalInformationFormViewModel._GeneralInformation = this._TTObject as GeneralInformation;
    }

    protected loadViewModel() {
        let that = this;
        that.generalInformationFormViewModel = this._ViewModel as GeneralInformationFormViewModel;
        that._TTObject = this.generalInformationFormViewModel._GeneralInformation;
        if (this.generalInformationFormViewModel == null)
            this.generalInformationFormViewModel = new GeneralInformationFormViewModel();
        if (this.generalInformationFormViewModel._GeneralInformation == null)
            this.generalInformationFormViewModel._GeneralInformation = new GeneralInformation();

    }

    async ngOnInit() {
        await this.load();
    }

    public onAnalRegionChanged(event): void {
        if (this._GeneralInformation != null && this._GeneralInformation.AnalRegion != event) {
            this._GeneralInformation.AnalRegion = event;
        }
    }

    public onEntryDateChanged(event): void {
        if (this._GeneralInformation != null && this._GeneralInformation.EntryDate != event) {
            this._GeneralInformation.EntryDate = event;
        }
    }

    public onMurmurChanged(event): void {
        if (this._GeneralInformation != null && this._GeneralInformation.Murmur != event) {
            this._GeneralInformation.Murmur = event;
        }
    }

    public onNatalChanged(event): void {
        if (this._GeneralInformation != null && this._GeneralInformation.Natal != event) {
            this._GeneralInformation.Natal = event;
        }
    }

    public onNavelChanged(event): void {
        if (this._GeneralInformation != null && this._GeneralInformation.Navel != event) {
            this._GeneralInformation.Navel = event;
        }
    }

    public onNavelCordChanged(event): void {
        if (this._GeneralInformation != null && this._GeneralInformation.NavelCord != event) {
            this._GeneralInformation.NavelCord = event;
        }
    }

    public onPostnatalChanged(event): void {
        if (this._GeneralInformation != null && this._GeneralInformation.Postnatal != event) {
            this._GeneralInformation.Postnatal = event;
        }
    }

    public onPrenatalChanged(event): void {
        if (this._GeneralInformation != null && this._GeneralInformation.Prenatal != event) {
            this._GeneralInformation.Prenatal = event;
        }
    }

    public onSkinChanged(event): void {
        if (this._GeneralInformation != null && this._GeneralInformation.Skin != event) {
            this._GeneralInformation.Skin = event;
        }
    }

    public onSuckingReflexChanged(event): void {
        if (this._GeneralInformation != null && this._GeneralInformation.SuckingReflex != event) {
            this._GeneralInformation.SuckingReflex = event;
        }
    }

    public onTreatmentPlanChanged(event): void {
        if (this._GeneralInformation != null && this._GeneralInformation.TreatmentPlan != event) {
            this._GeneralInformation.TreatmentPlan = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.EntryDate, "Value", this.__ttObject, "EntryDate");
        redirectProperty(this.AnalRegion, "Text", this.__ttObject, "AnalRegion");
        redirectProperty(this.Murmur, "Text", this.__ttObject, "Murmur");
        redirectProperty(this.Natal, "Text", this.__ttObject, "Natal");
        redirectProperty(this.Navel, "Text", this.__ttObject, "Navel");
        redirectProperty(this.NavelCord, "Text", this.__ttObject, "NavelCord");
        redirectProperty(this.Postnatal, "Text", this.__ttObject, "Postnatal");
        redirectProperty(this.Prenatal, "Text", this.__ttObject, "Prenatal");
        redirectProperty(this.Skin, "Text", this.__ttObject, "Skin");
        redirectProperty(this.SuckingReflex, "Text", this.__ttObject, "SuckingReflex");
        redirectProperty(this.TreatmentPlan, "Text", this.__ttObject, "TreatmentPlan");
    }

    public initFormControls(): void {
        this.labelEntryDate = new TTVisual.TTLabel();
        this.labelEntryDate.Text = "Giriş Yapılan Zaman";
        this.labelEntryDate.Name = "labelEntryDate";
        this.labelEntryDate.TabIndex = 21;

        this.EntryDate = new TTVisual.TTDateTimePicker();
        this.EntryDate.Format = DateTimePickerFormat.Long;
        this.EntryDate.Name = "EntryDate";
        this.EntryDate.TabIndex = 20;

        this.labelTreatmentPlan = new TTVisual.TTLabel();
        this.labelTreatmentPlan.Text = "Tedavi Planı";
        this.labelTreatmentPlan.Name = "labelTreatmentPlan";
        this.labelTreatmentPlan.TabIndex = 19;

        this.TreatmentPlan = new TTVisual.TTTextBox();
        this.TreatmentPlan.Name = "TreatmentPlan";
        this.TreatmentPlan.TabIndex = 18;

        this.SuckingReflex = new TTVisual.TTTextBox();
        this.SuckingReflex.Name = "SuckingReflex";
        this.SuckingReflex.TabIndex = 16;

        this.Skin = new TTVisual.TTTextBox();
        this.Skin.Name = "Skin";
        this.Skin.TabIndex = 14;

        this.Prenatal = new TTVisual.TTTextBox();
        this.Prenatal.Name = "Prenatal";
        this.Prenatal.TabIndex = 12;

        this.Postnatal = new TTVisual.TTTextBox();
        this.Postnatal.Name = "Postnatal";
        this.Postnatal.TabIndex = 10;

        this.NavelCord = new TTVisual.TTTextBox();
        this.NavelCord.Name = "NavelCord";
        this.NavelCord.TabIndex = 8;

        this.Navel = new TTVisual.TTTextBox();
        this.Navel.Name = "Navel";
        this.Navel.TabIndex = 6;

        this.Natal = new TTVisual.TTTextBox();
        this.Natal.Name = "Natal";
        this.Natal.TabIndex = 4;

        this.Murmur = new TTVisual.TTTextBox();
        this.Murmur.Name = "Murmur";
        this.Murmur.TabIndex = 2;

        this.AnalRegion = new TTVisual.TTTextBox();
        this.AnalRegion.Name = "AnalRegion";
        this.AnalRegion.TabIndex = 0;

        this.labelSuckingReflex = new TTVisual.TTLabel();
        this.labelSuckingReflex.Text = "Emme Refleksi";
        this.labelSuckingReflex.Name = "labelSuckingReflex";
        this.labelSuckingReflex.TabIndex = 17;

        this.labelSkin = new TTVisual.TTLabel();
        this.labelSkin.Text = "Cilt";
        this.labelSkin.Name = "labelSkin";
        this.labelSkin.TabIndex = 15;

        this.labelPrenatal = new TTVisual.TTLabel();
        this.labelPrenatal.Text = "Prenatal";
        this.labelPrenatal.Name = "labelPrenatal";
        this.labelPrenatal.TabIndex = 13;

        this.labelPostnatal = new TTVisual.TTLabel();
        this.labelPostnatal.Text = "Postnatal";
        this.labelPostnatal.Name = "labelPostnatal";
        this.labelPostnatal.TabIndex = 11;

        this.labelNavelCord = new TTVisual.TTLabel();
        this.labelNavelCord.Text = "Göbek Düşmesi";
        this.labelNavelCord.Name = "labelNavelCord";
        this.labelNavelCord.TabIndex = 9;

        this.labelNavel = new TTVisual.TTLabel();
        this.labelNavel.Text = "Göbek";
        this.labelNavel.Name = "labelNavel";
        this.labelNavel.TabIndex = 7;

        this.labelNatal = new TTVisual.TTLabel();
        this.labelNatal.Text = "Natal";
        this.labelNatal.Name = "labelNatal";
        this.labelNatal.TabIndex = 5;

        this.labelMurmur = new TTVisual.TTLabel();
        this.labelMurmur.Text = "Üfürüm";
        this.labelMurmur.Name = "labelMurmur";
        this.labelMurmur.TabIndex = 3;

        this.labelAnalRegion = new TTVisual.TTLabel();
        this.labelAnalRegion.Text = "Anal Bölge";
        this.labelAnalRegion.Name = "labelAnalRegion";
        this.labelAnalRegion.TabIndex = 1;

        this.Controls = [this.labelEntryDate, this.EntryDate, this.labelTreatmentPlan, this.TreatmentPlan, this.SuckingReflex, this.Skin, this.Prenatal, this.Postnatal, this.NavelCord, this.Navel, this.Natal, this.Murmur, this.AnalRegion, this.labelSuckingReflex, this.labelSkin, this.labelPrenatal, this.labelPostnatal, this.labelNavelCord, this.labelNavel, this.labelNatal, this.labelMurmur, this.labelAnalRegion];

    }


}
