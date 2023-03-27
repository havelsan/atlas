//$DAE60243
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { BallardNeuromuscularScoreFormViewModel } from './BallardNeuromuscularScoreFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BallardNeuromuscular } from 'NebulaClient/Model/AtlasClientModel';
import { BaseMultipleDataEntryForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseMultipleDataEntryForm";
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'BallardNeuromuscularScoreForm',
    templateUrl: './BallardNeuromuscularScoreForm.html',
    providers: [MessageService]
})
export class BallardNeuromuscularScoreForm extends BaseMultipleDataEntryForm implements OnInit {
    Arm: TTVisual.ITTEnumComboBox;
    EntryDate: TTVisual.ITTDateTimePicker;
    Heel: TTVisual.ITTEnumComboBox;
    labelArm: TTVisual.ITTLabel;
    labelEntryDate: TTVisual.ITTLabel;
    labelHeel: TTVisual.ITTLabel;
    labelPopliteal: TTVisual.ITTLabel;
    labelPosture: TTVisual.ITTLabel;
    labelScarf: TTVisual.ITTLabel;
    labelSquare: TTVisual.ITTLabel;
    labelTotalScore: TTVisual.ITTLabel;
    Popliteal: TTVisual.ITTEnumComboBox;
    Posture: TTVisual.ITTEnumComboBox;
    Scarf: TTVisual.ITTEnumComboBox;
    Square: TTVisual.ITTEnumComboBox;
    TotalScore: TTVisual.ITTTextBox;
    public ballardNeuromuscularScoreFormViewModel: BallardNeuromuscularScoreFormViewModel = new BallardNeuromuscularScoreFormViewModel();
    public get _BallardNeuromuscular(): BallardNeuromuscular {
        return this._TTObject as BallardNeuromuscular;
    }
    private BallardNeuromuscularScoreForm_DocumentUrl: string = '/api/BallardNeuromuscularService/BallardNeuromuscularScoreForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BallardNeuromuscularScoreForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    public CalculateBallardNeuromuscularTotalScore() {//Ballard Nöromusküler Maturasyon
        let total = 0;
        if (this._BallardNeuromuscular.Posture != null)
            total = total + this._BallardNeuromuscular.Posture;
        if (this._BallardNeuromuscular.Square != null)
            total = total + this._BallardNeuromuscular.Square;
        if (this._BallardNeuromuscular.Arm != null)
            total = total + this._BallardNeuromuscular.Arm;
        if (this._BallardNeuromuscular.Popliteal != null)
            total = total + this._BallardNeuromuscular.Popliteal;
        if (this._BallardNeuromuscular.Scarf != null)
            total = total + this._BallardNeuromuscular.Scarf;
        if (this._BallardNeuromuscular.Heel != null)
            total = total + this._BallardNeuromuscular.Heel;
        this._BallardNeuromuscular.TotalScore = total;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BallardNeuromuscular();
        this.ballardNeuromuscularScoreFormViewModel = new BallardNeuromuscularScoreFormViewModel();
        this._ViewModel = this.ballardNeuromuscularScoreFormViewModel;
        this.ballardNeuromuscularScoreFormViewModel._BallardNeuromuscular = this._TTObject as BallardNeuromuscular;
    }

    protected loadViewModel() {
        let that = this;
        that.ballardNeuromuscularScoreFormViewModel = this._ViewModel as BallardNeuromuscularScoreFormViewModel;
        that._TTObject = this.ballardNeuromuscularScoreFormViewModel._BallardNeuromuscular;
        if (this.ballardNeuromuscularScoreFormViewModel == null)
            this.ballardNeuromuscularScoreFormViewModel = new BallardNeuromuscularScoreFormViewModel();
        if (this.ballardNeuromuscularScoreFormViewModel._BallardNeuromuscular == null)
            this.ballardNeuromuscularScoreFormViewModel._BallardNeuromuscular = new BallardNeuromuscular();

    }

    async ngOnInit() {
        await this.load();
    }

    public onArmChanged(event): void {
        if (event != null && this._BallardNeuromuscular != null /*&& this._BallardNeuromuscular.Arm != event*/) {
            this._BallardNeuromuscular.Arm = event;
            this.CalculateBallardNeuromuscularTotalScore();
        }
    }

    public onEntryDateChanged(event): void {
        if (this._BallardNeuromuscular != null && this._BallardNeuromuscular.EntryDate != event) {
            this._BallardNeuromuscular.EntryDate = event;
            this.CalculateBallardNeuromuscularTotalScore();
        }
    }

    public onHeelChanged(event): void {
        if (event != null && this._BallardNeuromuscular != null /*&& this._BallardNeuromuscular.Heel != event*/) {
            this._BallardNeuromuscular.Heel = event;
            this.CalculateBallardNeuromuscularTotalScore();
        }
    }

    public onPoplitealChanged(event): void {
        if (event != null && this._BallardNeuromuscular != null /*&& this._BallardNeuromuscular.Popliteal != event*/) {
            this._BallardNeuromuscular.Popliteal = event;
            this.CalculateBallardNeuromuscularTotalScore();
        }
    }

    public onPostureChanged(event): void {
        if (event != null && this._BallardNeuromuscular != null/* && this._BallardNeuromuscular.Posture != event*/) {
            this._BallardNeuromuscular.Posture = event;
            this.CalculateBallardNeuromuscularTotalScore();
        }
    }

    public onScarfChanged(event): void {
        if (event != null && this._BallardNeuromuscular != null /*&& this._BallardNeuromuscular.Scarf != event*/) {
            this._BallardNeuromuscular.Scarf = event;
            this.CalculateBallardNeuromuscularTotalScore();
        }
    }

    public onSquareChanged(event): void {
        if (event != null && this._BallardNeuromuscular != null /*&& this._BallardNeuromuscular.Square != event*/) {
            this._BallardNeuromuscular.Square = event;
            this.CalculateBallardNeuromuscularTotalScore();
        }
    }

    public onTotalScoreChanged(event): void {
        if (this._BallardNeuromuscular != null && this._BallardNeuromuscular.TotalScore != event) {
            this._BallardNeuromuscular.TotalScore = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.EntryDate, "Value", this.__ttObject, "EntryDate");
        redirectProperty(this.Arm, "Value", this.__ttObject, "Arm");
        redirectProperty(this.Heel, "Value", this.__ttObject, "Heel");
        redirectProperty(this.Popliteal, "Value", this.__ttObject, "Popliteal");
        redirectProperty(this.Posture, "Value", this.__ttObject, "Posture");
        redirectProperty(this.Scarf, "Value", this.__ttObject, "Scarf");
        redirectProperty(this.Square, "Value", this.__ttObject, "Square");
        redirectProperty(this.TotalScore, "Text", this.__ttObject, "TotalScore");
    }

    public initFormControls(): void {
        this.TotalScore = new TTVisual.TTTextBox();
        this.TotalScore.Name = "TotalScore";
        this.TotalScore.TabIndex = 12;

        this.labelEntryDate = new TTVisual.TTLabel();
        this.labelEntryDate.Text = "Giriş Yapılan Zaman";
        this.labelEntryDate.Name = "labelEntryDate";
        this.labelEntryDate.TabIndex = 15;

        this.EntryDate = new TTVisual.TTDateTimePicker();
        this.EntryDate.Format = DateTimePickerFormat.Long;
        this.EntryDate.Name = "EntryDate";
        this.EntryDate.TabIndex = 14;

        this.labelTotalScore = new TTVisual.TTLabel();
        this.labelTotalScore.Text = "Toplam Skor";
        this.labelTotalScore.Name = "labelTotalScore";
        this.labelTotalScore.TabIndex = 13;

        this.labelSquare = new TTVisual.TTLabel();
        this.labelSquare.Text = "Dörtgen Pencere";
        this.labelSquare.Name = "labelSquare";
        this.labelSquare.TabIndex = 11;

        this.Square = new TTVisual.TTEnumComboBox();
        this.Square.DataTypeName = "BallardNeuroSquareEnum";
        this.Square.Name = "Square";
        this.Square.TabIndex = 10;

        this.labelScarf = new TTVisual.TTLabel();
        this.labelScarf.Text = "Eşarp Belirtisi";
        this.labelScarf.Name = "labelScarf";
        this.labelScarf.TabIndex = 9;

        this.Scarf = new TTVisual.TTEnumComboBox();
        this.Scarf.DataTypeName = "BallardNeuroScarfEnum";
        this.Scarf.Name = "Scarf";
        this.Scarf.TabIndex = 8;

        this.labelPosture = new TTVisual.TTLabel();
        this.labelPosture.Text = "Postur";
        this.labelPosture.Name = "labelPosture";
        this.labelPosture.TabIndex = 7;

        this.Posture = new TTVisual.TTEnumComboBox();
        this.Posture.DataTypeName = "BallardNeuroPostureEnum";
        this.Posture.Name = "Posture";
        this.Posture.TabIndex = 6;

        this.labelPopliteal = new TTVisual.TTLabel();
        this.labelPopliteal.Text = "Popliteal Açı";
        this.labelPopliteal.Name = "labelPopliteal";
        this.labelPopliteal.TabIndex = 5;

        this.Popliteal = new TTVisual.TTEnumComboBox();
        this.Popliteal.DataTypeName = "BallardNeuroPoplitealEnum";
        this.Popliteal.Name = "Popliteal";
        this.Popliteal.TabIndex = 4;

        this.labelHeel = new TTVisual.TTLabel();
        this.labelHeel.Text = "Topuktan Kulağa";
        this.labelHeel.Name = "labelHeel";
        this.labelHeel.TabIndex = 3;

        this.Heel = new TTVisual.TTEnumComboBox();
        this.Heel.DataTypeName = "BallardNeuroHeelEnum";
        this.Heel.Name = "Heel";
        this.Heel.TabIndex = 2;

        this.labelArm = new TTVisual.TTLabel();
        this.labelArm.Text = "Kolun Geriye Kıvrılması";
        this.labelArm.Name = "labelArm";
        this.labelArm.TabIndex = 1;

        this.Arm = new TTVisual.TTEnumComboBox();
        this.Arm.DataTypeName = "BallardNeuroArmEnum";
        this.Arm.Name = "Arm";
        this.Arm.TabIndex = 0;

        this.Controls = [this.TotalScore, this.labelEntryDate, this.EntryDate, this.labelTotalScore, this.labelSquare, this.Square, this.labelScarf, this.Scarf, this.labelPosture, this.Posture, this.labelPopliteal, this.Popliteal, this.labelHeel, this.Heel, this.labelArm, this.Arm];

    }


}
