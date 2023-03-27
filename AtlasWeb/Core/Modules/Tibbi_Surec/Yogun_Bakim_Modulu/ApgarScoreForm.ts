//$A7C86367
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ApgarScoreFormViewModel } from './ApgarScoreFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Apgar } from 'NebulaClient/Model/AtlasClientModel';
import { BaseMultipleDataEntryForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseMultipleDataEntryForm";
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'ApgarScoreForm',
    templateUrl: './ApgarScoreForm.html',
    providers: [MessageService]
})
export class ApgarScoreForm extends BaseMultipleDataEntryForm implements OnInit {
    EntryDate: TTVisual.ITTDateTimePicker;
    HeartRate: TTVisual.ITTEnumComboBox;
    labelEntryDate: TTVisual.ITTLabel;
    labelHeartRate: TTVisual.ITTLabel;
    labelMuscularTonus: TTVisual.ITTLabel;
    labelRespiration: TTVisual.ITTLabel;
    labelSkinColor: TTVisual.ITTLabel;
    labelStimulusResponse: TTVisual.ITTLabel;
    labelTotalScore: TTVisual.ITTLabel;
    MuscularTonus: TTVisual.ITTEnumComboBox;
    Respiration: TTVisual.ITTEnumComboBox;
    SkinColor: TTVisual.ITTEnumComboBox;
    StimulusResponse: TTVisual.ITTEnumComboBox;
    TotalScore: TTVisual.ITTTextBox;
    public apgarScoreFormViewModel: ApgarScoreFormViewModel = new ApgarScoreFormViewModel();
    public get _Apgar(): Apgar {
        return this._TTObject as Apgar;
    }
    private ApgarScoreForm_DocumentUrl: string = '/api/ApgarService/ApgarScoreForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ApgarScoreForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    public CalculateTotalScore() {//Apgar Skoru
        let total = 0;
        if (this.apgarScoreFormViewModel._Apgar.MuscularTonus != null)
            total = total + this.apgarScoreFormViewModel._Apgar.MuscularTonus;
        if (this.apgarScoreFormViewModel._Apgar.HeartRate != null)
            total = total + this.apgarScoreFormViewModel._Apgar.HeartRate;
        if (this.apgarScoreFormViewModel._Apgar.StimulusResponse != null)
            total = total + this.apgarScoreFormViewModel._Apgar.StimulusResponse;
        if (this.apgarScoreFormViewModel._Apgar.SkinColor != null)
            total = total + this.apgarScoreFormViewModel._Apgar.SkinColor;
        if (this.apgarScoreFormViewModel._Apgar.Respiration != null)
            total = total + this.apgarScoreFormViewModel._Apgar.Respiration;
        this.apgarScoreFormViewModel._Apgar.TotalScore = total;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Apgar();
        this.apgarScoreFormViewModel = new ApgarScoreFormViewModel();
        this._ViewModel = this.apgarScoreFormViewModel;
        this.apgarScoreFormViewModel._Apgar = this._TTObject as Apgar;
    }

    protected loadViewModel() {
        let that = this;
        that.apgarScoreFormViewModel = this._ViewModel as ApgarScoreFormViewModel;
        that._TTObject = this.apgarScoreFormViewModel._Apgar;
        if (this.apgarScoreFormViewModel == null)
            this.apgarScoreFormViewModel = new ApgarScoreFormViewModel();
        if (this.apgarScoreFormViewModel._Apgar == null)
            this.apgarScoreFormViewModel._Apgar = new Apgar();

    }

    async ngOnInit() {
        await this.load();
    }

    public onEntryDateChanged(event): void {
        if (this._Apgar != null && this._Apgar.EntryDate != event) {
            this._Apgar.EntryDate = event;
        }
    }

    public onHeartRateChanged(event): void {
        if (event != null && this._Apgar != null /*&& this._Apgar.HeartRate != event*/) {
            this._Apgar.HeartRate = event;
            this.CalculateTotalScore();
        }
    }
    //public onHeartRateApgar1Changed(event): void {
    //    if (event != null) {
    //        if (this._NewBornIntensiveCare != null &&
    //            this._NewBornIntensiveCare.Apgar1 != null /*&& this._NewBornIntensiveCare.Apgar1.HeartRate != event*/) {
    //            this.CalculateApgar1TotalScore();
    //            this._NewBornIntensiveCare.Apgar1.HeartRate = event;
    //        }
    //    }
    //}

    public onMuscularTonusChanged(event): void {
        if (event != null && this._Apgar != null /*&& this._Apgar.MuscularTonus != event*/) {
            this._Apgar.MuscularTonus = event;
            this.CalculateTotalScore();
        }
    }

    public onRespirationChanged(event): void {
        if (event != null && this._Apgar != null /*&& this._Apgar.Respiration != event*/) {
            this._Apgar.Respiration = event;
            this.CalculateTotalScore();
        }
    }

    public onSkinColorChanged(event): void {
        if (event != null && this._Apgar != null /*&& this._Apgar.SkinColor != event*/) {
            this._Apgar.SkinColor = event;
            this.CalculateTotalScore();
        }
    }

    public onStimulusResponseChanged(event): void {
        if (event != null && this._Apgar != null) {
            this._Apgar.StimulusResponse = event;
            this.CalculateTotalScore();
        }
    }

    public onTotalScoreChanged(event): void {
        if (this._Apgar != null && this._Apgar.TotalScore != event) {
            this._Apgar.TotalScore = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.HeartRate, "Value", this.__ttObject, "HeartRate");
        redirectProperty(this.StimulusResponse, "Value", this.__ttObject, "StimulusResponse");
        redirectProperty(this.MuscularTonus, "Value", this.__ttObject, "MuscularTonus");
        redirectProperty(this.TotalScore, "Text", this.__ttObject, "TotalScore");
        redirectProperty(this.Respiration, "Value", this.__ttObject, "Respiration");
        redirectProperty(this.EntryDate, "Value", this.__ttObject, "EntryDate");
        redirectProperty(this.SkinColor, "Value", this.__ttObject, "SkinColor");
    }

    public initFormControls(): void {
        this.TotalScore = new TTVisual.TTTextBox();
        this.TotalScore.Name = "TotalScore";
        this.TotalScore.TabIndex = 10;

        this.labelEntryDate = new TTVisual.TTLabel();
        this.labelEntryDate.Text = "Giriş Yapılan Zaman";
        this.labelEntryDate.Name = "labelEntryDate";
        this.labelEntryDate.TabIndex = 13;

        this.EntryDate = new TTVisual.TTDateTimePicker();
        this.EntryDate.Format = DateTimePickerFormat.Long;
        this.EntryDate.Name = "EntryDate";
        this.EntryDate.TabIndex = 12;

        this.labelTotalScore = new TTVisual.TTLabel();
        this.labelTotalScore.Text = "Toplam Skor";
        this.labelTotalScore.Name = "labelTotalScore";
        this.labelTotalScore.TabIndex = 11;

        this.labelStimulusResponse = new TTVisual.TTLabel();
        this.labelStimulusResponse.Text = "Uyarılara Cevap";
        this.labelStimulusResponse.Name = "labelStimulusResponse";
        this.labelStimulusResponse.TabIndex = 9;

        this.StimulusResponse = new TTVisual.TTEnumComboBox();
        this.StimulusResponse.DataTypeName = "ApgarStimulusResponseEnum";
        this.StimulusResponse.Name = "StimulusResponse";
        this.StimulusResponse.TabIndex = 8;

        this.labelSkinColor = new TTVisual.TTLabel();
        this.labelSkinColor.Text = "Cilt Rengi";
        this.labelSkinColor.Name = "labelSkinColor";
        this.labelSkinColor.TabIndex = 7;

        this.SkinColor = new TTVisual.TTEnumComboBox();
        this.SkinColor.DataTypeName = "ApgarSkinColorEnum";
        this.SkinColor.Name = "SkinColor";
        this.SkinColor.TabIndex = 6;

        this.labelRespiration = new TTVisual.TTLabel();
        this.labelRespiration.Text = "Solunum";
        this.labelRespiration.Name = "labelRespiration";
        this.labelRespiration.TabIndex = 5;

        this.Respiration = new TTVisual.TTEnumComboBox();
        this.Respiration.DataTypeName = "ApgarRespirationEnum";
        this.Respiration.Name = "Respiration";
        this.Respiration.TabIndex = 4;

        this.labelMuscularTonus = new TTVisual.TTLabel();
        this.labelMuscularTonus.Text = "Kas Tonusu";
        this.labelMuscularTonus.Name = "labelMuscularTonus";
        this.labelMuscularTonus.TabIndex = 3;

        this.MuscularTonus = new TTVisual.TTEnumComboBox();
        this.MuscularTonus.DataTypeName = "ApgarMuscularTonusEnum";
        this.MuscularTonus.Name = "MuscularTonus";
        this.MuscularTonus.TabIndex = 2;

        this.labelHeartRate = new TTVisual.TTLabel();
        this.labelHeartRate.Text = "Kalp Hızı";
        this.labelHeartRate.Name = "labelHeartRate";
        this.labelHeartRate.TabIndex = 1;

        this.HeartRate = new TTVisual.TTEnumComboBox();
        this.HeartRate.DataTypeName = "ApgarHeartRateEnum";
        this.HeartRate.Name = "HeartRate";
        this.HeartRate.TabIndex = 0;

        this.Controls = [this.TotalScore, this.labelEntryDate, this.EntryDate, this.labelTotalScore, this.labelStimulusResponse, this.StimulusResponse, this.labelSkinColor, this.SkinColor, this.labelRespiration, this.Respiration, this.labelMuscularTonus, this.MuscularTonus, this.labelHeartRate, this.HeartRate];

    }


}
