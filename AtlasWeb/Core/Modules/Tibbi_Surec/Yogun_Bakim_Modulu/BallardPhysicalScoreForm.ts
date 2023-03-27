//$DAD62A8A
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { BallardPhysicalScoreFormViewModel } from './BallardPhysicalScoreFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BallardPhysical } from 'NebulaClient/Model/AtlasClientModel';
import { BaseMultipleDataEntryForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseMultipleDataEntryForm";
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'BallardPhysicalScoreForm',
    templateUrl: './BallardPhysicalScoreForm.html',
    providers: [MessageService]
})
export class BallardPhysicalScoreForm extends BaseMultipleDataEntryForm implements OnInit {
    Breast: TTVisual.ITTEnumComboBox;
    Ear: TTVisual.ITTEnumComboBox;
    EntryDate: TTVisual.ITTDateTimePicker;
    FemaleGenitalia: TTVisual.ITTEnumComboBox;
    labelBreast: TTVisual.ITTLabel;
    labelEar: TTVisual.ITTLabel;
    labelEntryDate: TTVisual.ITTLabel;
    labelFemaleGenitalia: TTVisual.ITTLabel;
    labelLanugo: TTVisual.ITTLabel;
    labelMaleGenitalia: TTVisual.ITTLabel;
    labelPlantarLines: TTVisual.ITTLabel;
    labelSkin: TTVisual.ITTLabel;
    labelTotalScore: TTVisual.ITTLabel;
    Lanugo: TTVisual.ITTEnumComboBox;
    MaleGenitalia: TTVisual.ITTEnumComboBox;
    PlantarLines: TTVisual.ITTEnumComboBox;
    Skin: TTVisual.ITTEnumComboBox;
    TotalScore: TTVisual.ITTTextBox;
    public ballardPhysicalScoreFormViewModel: BallardPhysicalScoreFormViewModel = new BallardPhysicalScoreFormViewModel();
    public get _BallardPhysical(): BallardPhysical {
        return this._TTObject as BallardPhysical;
    }
    private BallardPhysicalScoreForm_DocumentUrl: string = '/api/BallardPhysicalService/BallardPhysicalScoreForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BallardPhysicalScoreForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public CalculateBallardPhysicalTotalScore() {//Ballard Fiziksel Maturasyon
        let total = 0;
        if (this._BallardPhysical.Skin != null)
            total = total + this._BallardPhysical.Skin;
        if (this._BallardPhysical.Lanugo != null)
            total = total + this._BallardPhysical.Lanugo;
        if (this._BallardPhysical.PlantarLines != null)
            total = total + this._BallardPhysical.PlantarLines;
        if (this._BallardPhysical.Breast != null)
            total = total + this._BallardPhysical.Breast;
        if (this._BallardPhysical.Ear != null)
            total = total + this._BallardPhysical.Ear;
        if (this._BallardPhysical.FemaleGenitalia != null)
            total = total + this._BallardPhysical.FemaleGenitalia;
        if (this._BallardPhysical.MaleGenitalia != null)
            total = total + this._BallardPhysical.MaleGenitalia;
        this._BallardPhysical.TotalScore = total;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BallardPhysical();
        this.ballardPhysicalScoreFormViewModel = new BallardPhysicalScoreFormViewModel();
        this._ViewModel = this.ballardPhysicalScoreFormViewModel;
        this.ballardPhysicalScoreFormViewModel._BallardPhysical = this._TTObject as BallardPhysical;
    }

    protected loadViewModel() {
        let that = this;
        that.ballardPhysicalScoreFormViewModel = this._ViewModel as BallardPhysicalScoreFormViewModel;
        that._TTObject = this.ballardPhysicalScoreFormViewModel._BallardPhysical;
        if (this.ballardPhysicalScoreFormViewModel == null)
            this.ballardPhysicalScoreFormViewModel = new BallardPhysicalScoreFormViewModel();
        if (this.ballardPhysicalScoreFormViewModel._BallardPhysical == null)
            this.ballardPhysicalScoreFormViewModel._BallardPhysical = new BallardPhysical();

    }

    async ngOnInit() {
        await this.load();
    }

    public onBreastChanged(event): void {
        if (event != null && this._BallardPhysical != null /*&& this._BallardPhysical.Breast != event*/) {
            this._BallardPhysical.Breast = event;
            this.CalculateBallardPhysicalTotalScore();
        }
    }

    public onEarChanged(event): void {
        if (event != null && this._BallardPhysical != null /*&& this._BallardPhysical.Ear != event*/) {
            this._BallardPhysical.Ear = event;
            this.CalculateBallardPhysicalTotalScore();
        }
    }

    public onEntryDateChanged(event): void {
        if (this._BallardPhysical != null && this._BallardPhysical.EntryDate != event) {
            this._BallardPhysical.EntryDate = event;
            this.CalculateBallardPhysicalTotalScore();
        }
    }

    public onFemaleGenitaliaChanged(event): void {
        if (event != null && this._BallardPhysical != null /*&& this._BallardPhysical.FemaleGenitalia != event*/) {
            this._BallardPhysical.FemaleGenitalia = event;
            this.CalculateBallardPhysicalTotalScore();
        }
    }

    public onLanugoChanged(event): void {
        if (event != null && this._BallardPhysical != null/* && this._BallardPhysical.Lanugo != event*/) {
            this._BallardPhysical.Lanugo = event;
            this.CalculateBallardPhysicalTotalScore();
        }
    }

    public onMaleGenitaliaChanged(event): void {
        if (event != null && this._BallardPhysical != null /*&& this._BallardPhysical.MaleGenitalia != event*/) {
            this._BallardPhysical.MaleGenitalia = event;
            this.CalculateBallardPhysicalTotalScore();
        }
    }

    public onPlantarLinesChanged(event): void {
        if (event != null && this._BallardPhysical != null /*&& this._BallardPhysical.PlantarLines != event*/) {
            this._BallardPhysical.PlantarLines = event;
            this.CalculateBallardPhysicalTotalScore();
        }
    }

    public onSkinChanged(event): void {
        if (event != null && this._BallardPhysical != null /*&& this._BallardPhysical.Skin != event*/) {
            this._BallardPhysical.Skin = event;
            this.CalculateBallardPhysicalTotalScore();
        }
    }

    public onTotalScoreChanged(event): void {
        if (this._BallardPhysical != null && this._BallardPhysical.TotalScore != event) {
            this._BallardPhysical.TotalScore = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.EntryDate, "Value", this.__ttObject, "EntryDate");
        redirectProperty(this.Breast, "Value", this.__ttObject, "Breast");
        redirectProperty(this.Ear, "Value", this.__ttObject, "Ear");
        redirectProperty(this.FemaleGenitalia, "Value", this.__ttObject, "FemaleGenitalia");
        redirectProperty(this.Lanugo, "Value", this.__ttObject, "Lanugo");
        redirectProperty(this.MaleGenitalia, "Value", this.__ttObject, "MaleGenitalia");
        redirectProperty(this.PlantarLines, "Value", this.__ttObject, "PlantarLines");
        redirectProperty(this.Skin, "Value", this.__ttObject, "Skin");
        redirectProperty(this.TotalScore, "Text", this.__ttObject, "TotalScore");
    }

    public initFormControls(): void {
        this.labelEntryDate = new TTVisual.TTLabel();
        this.labelEntryDate.Text = "Giriş Yapılan Zaman";
        this.labelEntryDate.Name = "labelEntryDate";
        this.labelEntryDate.TabIndex = 17;

        this.EntryDate = new TTVisual.TTDateTimePicker();
        this.EntryDate.Format = DateTimePickerFormat.Long;
        this.EntryDate.Name = "EntryDate";
        this.EntryDate.TabIndex = 16;

        this.labelTotalScore = new TTVisual.TTLabel();
        this.labelTotalScore.Text = "Toplam Skor";
        this.labelTotalScore.Name = "labelTotalScore";
        this.labelTotalScore.TabIndex = 15;

        this.TotalScore = new TTVisual.TTTextBox();
        this.TotalScore.Name = "TotalScore";
        this.TotalScore.TabIndex = 14;

        this.labelSkin = new TTVisual.TTLabel();
        this.labelSkin.Text = "Cilt";
        this.labelSkin.Name = "labelSkin";
        this.labelSkin.TabIndex = 13;

        this.Skin = new TTVisual.TTEnumComboBox();
        this.Skin.DataTypeName = "BallardPhysicalSkinEnum";
        this.Skin.Name = "Skin";
        this.Skin.TabIndex = 12;

        this.labelPlantarLines = new TTVisual.TTLabel();
        this.labelPlantarLines.Text = "Ayak Tabanı Çizgileri";
        this.labelPlantarLines.Name = "labelPlantarLines";
        this.labelPlantarLines.TabIndex = 11;

        this.PlantarLines = new TTVisual.TTEnumComboBox();
        this.PlantarLines.DataTypeName = "BallardPhysicalPlantarLinesEnum";
        this.PlantarLines.Name = "PlantarLines";
        this.PlantarLines.TabIndex = 10;

        this.labelMaleGenitalia = new TTVisual.TTLabel();
        this.labelMaleGenitalia.Text = "Erkek Genitalya";
        this.labelMaleGenitalia.Name = "labelMaleGenitalia";
        this.labelMaleGenitalia.TabIndex = 9;

        this.MaleGenitalia = new TTVisual.TTEnumComboBox();
        this.MaleGenitalia.DataTypeName = "BallardPhysicaMaleGenitaliaEnum";
        this.MaleGenitalia.Name = "MaleGenitalia";
        this.MaleGenitalia.TabIndex = 8;

        this.labelLanugo = new TTVisual.TTLabel();
        this.labelLanugo.Text = "Lanugo";
        this.labelLanugo.Name = "labelLanugo";
        this.labelLanugo.TabIndex = 7;

        this.Lanugo = new TTVisual.TTEnumComboBox();
        this.Lanugo.DataTypeName = "BallardPhysicalLanugoEnum";
        this.Lanugo.Name = "Lanugo";
        this.Lanugo.TabIndex = 6;

        this.labelFemaleGenitalia = new TTVisual.TTLabel();
        this.labelFemaleGenitalia.Text = "Dişi Genitalya";
        this.labelFemaleGenitalia.Name = "labelFemaleGenitalia";
        this.labelFemaleGenitalia.TabIndex = 5;

        this.FemaleGenitalia = new TTVisual.TTEnumComboBox();
        this.FemaleGenitalia.DataTypeName = "BallardPhysicalFemaleGenitaliaEnum";
        this.FemaleGenitalia.Name = "FemaleGenitalia";
        this.FemaleGenitalia.TabIndex = 4;

        this.labelEar = new TTVisual.TTLabel();
        this.labelEar.Text = "Göz / Kulak";
        this.labelEar.Name = "labelEar";
        this.labelEar.TabIndex = 3;

        this.Ear = new TTVisual.TTEnumComboBox();
        this.Ear.DataTypeName = "BallardPhysicalEarEnum";
        this.Ear.Name = "Ear";
        this.Ear.TabIndex = 2;

        this.labelBreast = new TTVisual.TTLabel();
        this.labelBreast.Text = "Meme";
        this.labelBreast.Name = "labelBreast";
        this.labelBreast.TabIndex = 1;

        this.Breast = new TTVisual.TTEnumComboBox();
        this.Breast.DataTypeName = "BallardPhysicalBreastEnum";
        this.Breast.Name = "Breast";
        this.Breast.TabIndex = 0;

        this.Controls = [this.labelEntryDate, this.EntryDate, this.labelTotalScore, this.TotalScore, this.labelSkin, this.Skin, this.labelPlantarLines, this.PlantarLines, this.labelMaleGenitalia, this.MaleGenitalia, this.labelLanugo, this.Lanugo, this.labelFemaleGenitalia, this.FemaleGenitalia, this.labelEar, this.Ear, this.labelBreast, this.Breast];

    }


}
