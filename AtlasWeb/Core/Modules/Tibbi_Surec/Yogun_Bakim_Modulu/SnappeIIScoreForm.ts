//$539DDE2B
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { SnappeIIScoreFormViewModel } from './SnappeIIScoreFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseMultipleDataEntryForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseMultipleDataEntryForm";
import { Snappe } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'SnappeIIScoreForm',
    templateUrl: './SnappeIIScoreForm.html',
    providers: [MessageService]
})
export class SnappeIIScoreForm extends BaseMultipleDataEntryForm implements OnInit {
    Apgar: TTVisual.ITTEnumComboBox;
    BirthWeight: TTVisual.ITTEnumComboBox;
    Diuresis: TTVisual.ITTEnumComboBox;
    EntryDate: TTVisual.ITTDateTimePicker;
    labelApgar: TTVisual.ITTLabel;
    labelBirthWeight: TTVisual.ITTLabel;
    labelDiuresis: TTVisual.ITTLabel;
    labelEntryDate: TTVisual.ITTLabel;
    labelLowestTemperature: TTVisual.ITTLabel;
    labelMeanBloodPressure: TTVisual.ITTLabel;
    labelMultipleConvulsion: TTVisual.ITTLabel;
    labelPo2FiO2: TTVisual.ITTLabel;
    labelSerumPH: TTVisual.ITTLabel;
    labelSGA: TTVisual.ITTLabel;
    labelTotalScore: TTVisual.ITTLabel;
    LowestTemperature: TTVisual.ITTEnumComboBox;
    MeanBloodPressure: TTVisual.ITTEnumComboBox;
    MultipleConvulsion: TTVisual.ITTEnumComboBox;
    Po2FiO2: TTVisual.ITTEnumComboBox;
    SerumPH: TTVisual.ITTEnumComboBox;
    SGA: TTVisual.ITTEnumComboBox;
    TotalScore: TTVisual.ITTTextBox;
    TotalSnapScore: TTVisual.ITTTextBox;
    public snappeIIScoreFormViewModel: SnappeIIScoreFormViewModel = new SnappeIIScoreFormViewModel();
    public get _Snappe(): Snappe {
        return this._TTObject as Snappe;
    }
    private SnappeIIScoreForm_DocumentUrl: string = '/api/SnappeService/SnappeIIScoreForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.SnappeIIScoreForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public CalculateSnappeTotalScore() {//Snap-pe II
        let total = 0;
        if (this._Snappe.MeanBloodPressure != null)
            total = total + this._Snappe.MeanBloodPressure;
        if (this._Snappe.LowestTemperature != null)
            total = total + this._Snappe.LowestTemperature;
        if (this._Snappe.Po2FiO2 != null)
            total = total + this._Snappe.Po2FiO2;
        if (this._Snappe.SerumPH != null)
            total = total + this._Snappe.SerumPH;
        if (this._Snappe.MultipleConvulsion != null)
            total = total + this._Snappe.MultipleConvulsion;
        if (this._Snappe.Diuresis != null)
            total = total + this._Snappe.Diuresis;
        if (this._Snappe.BirthWeight != null)
            total = total + this._Snappe.BirthWeight;
        if (this._Snappe.Apgar != null)
            total = total + this._Snappe.Apgar;
        if (this._Snappe.SGA != null)
            total = total + this._Snappe.SGA;
        this._Snappe.TotalScore = total;
    }

    public CalculateSnapTotalScore() {//Snap II
        let total = 0;
        if (this._Snappe.MeanBloodPressure != null)
            total = total + this._Snappe.MeanBloodPressure;
        if (this._Snappe.LowestTemperature != null)
            total = total + this._Snappe.LowestTemperature;
        if (this._Snappe.Po2FiO2 != null)
            total = total + this._Snappe.Po2FiO2;
        if (this._Snappe.SerumPH != null)
            total = total + this._Snappe.SerumPH;
        if (this._Snappe.MultipleConvulsion != null)
            total = total + this._Snappe.MultipleConvulsion;
        if (this._Snappe.Diuresis != null)
            total = total + this._Snappe.Diuresis;
        //if (this._Snappe.BirthWeight != null)
        //    total = total + this._Snappe.BirthWeight;
        //if (this._Snappe.Apgar != null)
        //    total = total + this._Snappe.Apgar;
        //if (this._Snappe.SGA != null)
        //    total = total + this._Snappe.SGA;
        this._Snappe.TotalSnapScore = total;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Snappe();
        this.snappeIIScoreFormViewModel = new SnappeIIScoreFormViewModel();
        this._ViewModel = this.snappeIIScoreFormViewModel;
        this.snappeIIScoreFormViewModel._Snappe = this._TTObject as Snappe;
    }

    protected loadViewModel() {
        let that = this;
        that.snappeIIScoreFormViewModel = this._ViewModel as SnappeIIScoreFormViewModel;
        that._TTObject = this.snappeIIScoreFormViewModel._Snappe;
        if (this.snappeIIScoreFormViewModel == null)
            this.snappeIIScoreFormViewModel = new SnappeIIScoreFormViewModel();
        if (this.snappeIIScoreFormViewModel._Snappe == null)
            this.snappeIIScoreFormViewModel._Snappe = new Snappe();

    }

    async ngOnInit() {
        await this.load();
    }

    public onApgarChanged(event): void {
        if (event != null && this._Snappe != null/* && this._Snappe.Apgar != event*/) {
            this._Snappe.Apgar = event;
            this.CalculateSnappeTotalScore();
            this.CalculateSnapTotalScore();
        }
    }

    public onBirthWeightChanged(event): void {
        if (event != null && this._Snappe != null /*&& this._Snappe.BirthWeight != event*/) {
            this._Snappe.BirthWeight = event;
            this.CalculateSnappeTotalScore();
            this.CalculateSnapTotalScore();
        }
    }

    public onDiuresisChanged(event): void {
        if (event != null && this._Snappe != null /*&& this._Snappe.Diuresis != event*/) {
            this._Snappe.Diuresis = event;
            this.CalculateSnappeTotalScore();
            this.CalculateSnapTotalScore();
        }
    }

    public onEntryDateChanged(event): void {
        if (this._Snappe != null && this._Snappe.EntryDate != event) {
            this._Snappe.EntryDate = event;
        }
    }

    public onLowestTemperatureChanged(event): void {
        if (event != null && this._Snappe != null /*&& this._Snappe.LowestTemperature != event*/) {
            this._Snappe.LowestTemperature = event;
            this.CalculateSnappeTotalScore();
            this.CalculateSnapTotalScore();
        }
    }

    public onMeanBloodPressureChanged(event): void {
        if (event != null && this._Snappe != null /*&& this._Snappe.MeanBloodPressure != event*/) {
            this._Snappe.MeanBloodPressure = event;
            this.CalculateSnappeTotalScore();
            this.CalculateSnapTotalScore();
        }
    }

    public onMultipleConvulsionChanged(event): void {
        if (event != null && this._Snappe != null /*&& this._Snappe.MultipleConvulsion != event*/) {
            this._Snappe.MultipleConvulsion = event;
            this.CalculateSnappeTotalScore();
            this.CalculateSnapTotalScore();
        }
    }

    public onPo2FiO2Changed(event): void {
        if (event != null && this._Snappe != null /*&& this._Snappe.Po2FiO2 != event*/) {
            this._Snappe.Po2FiO2 = event;
            this.CalculateSnappeTotalScore();
            this.CalculateSnapTotalScore();
        }
    }

    public onSerumPHChanged(event): void {
        if (event != null && this._Snappe != null /*&& this._Snappe.SerumPH != event*/) {
            this._Snappe.SerumPH = event;
            this.CalculateSnappeTotalScore();
            this.CalculateSnapTotalScore();
        }
    }

    public onSGAChanged(event): void {
        if (event != null && this._Snappe != null /*&& this._Snappe.SGA != event*/) {
            this._Snappe.SGA = event;
            this.CalculateSnappeTotalScore();
            this.CalculateSnapTotalScore();
        }
    }

    public onTotalScoreChanged(event): void {
        if (this._Snappe != null && this._Snappe.TotalScore != event) {
            this._Snappe.TotalScore = event;
        }
    }

    public onTotalSnapScoreChanged(event): void {
        if (this._Snappe != null && this._Snappe.TotalSnapScore != event) {
            this._Snappe.TotalSnapScore = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.EntryDate, "Value", this.__ttObject, "EntryDate");
        redirectProperty(this.Apgar, "Value", this.__ttObject, "Apgar");
        redirectProperty(this.BirthWeight, "Value", this.__ttObject, "BirthWeight");
        redirectProperty(this.Diuresis, "Value", this.__ttObject, "Diuresis");
        redirectProperty(this.LowestTemperature, "Value", this.__ttObject, "LowestTemperature");
        redirectProperty(this.MeanBloodPressure, "Value", this.__ttObject, "MeanBloodPressure");
        redirectProperty(this.MultipleConvulsion, "Value", this.__ttObject, "MultipleConvulsion");
        redirectProperty(this.Po2FiO2, "Value", this.__ttObject, "Po2FiO2");
        redirectProperty(this.SerumPH, "Value", this.__ttObject, "SerumPH");
        redirectProperty(this.SGA, "Value", this.__ttObject, "SGA");
        redirectProperty(this.TotalScore, "Text", this.__ttObject, "TotalScore");
        redirectProperty(this.TotalSnapScore, "Text", this.__ttObject, "TotalSnapScore");
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

        this.labelTotalScore = new TTVisual.TTLabel();
        this.labelTotalScore.Text = "Toplam Skor";
        this.labelTotalScore.Name = "labelTotalScore";
        this.labelTotalScore.TabIndex = 19;

        this.TotalScore = new TTVisual.TTTextBox();
        this.TotalScore.Name = "TotalScore";
        this.TotalScore.TabIndex = 18;

        this.TotalSnapScore = new TTVisual.TTTextBox();
        this.TotalSnapScore.Name = "TotalSnapScore";
        this.TotalSnapScore.TabIndex = 18;

        this.labelSGA = new TTVisual.TTLabel();
        this.labelSGA.Text = "SGA";
        this.labelSGA.Name = "labelSGA";
        this.labelSGA.TabIndex = 17;

        this.SGA = new TTVisual.TTEnumComboBox();
        this.SGA.DataTypeName = "SnappeSGAEnum";
        this.SGA.Name = "SGA";
        this.SGA.TabIndex = 16;

        this.labelSerumPH = new TTVisual.TTLabel();
        this.labelSerumPH.Text = "Serum PH";
        this.labelSerumPH.Name = "labelSerumPH";
        this.labelSerumPH.TabIndex = 15;

        this.SerumPH = new TTVisual.TTEnumComboBox();
        this.SerumPH.DataTypeName = "SnappeSerumPHEnum";
        this.SerumPH.Name = "SerumPH";
        this.SerumPH.TabIndex = 14;

        this.labelPo2FiO2 = new TTVisual.TTLabel();
        this.labelPo2FiO2.Text = "Po2/FiO2";
        this.labelPo2FiO2.Name = "labelPo2FiO2";
        this.labelPo2FiO2.TabIndex = 13;

        this.Po2FiO2 = new TTVisual.TTEnumComboBox();
        this.Po2FiO2.DataTypeName = "SnappePo2FiO2Enum";
        this.Po2FiO2.Name = "Po2FiO2";
        this.Po2FiO2.TabIndex = 12;

        this.labelMultipleConvulsion = new TTVisual.TTLabel();
        this.labelMultipleConvulsion.Text = "Çok Sayıda Konvülsiyon";
        this.labelMultipleConvulsion.Name = "labelMultipleConvulsion";
        this.labelMultipleConvulsion.TabIndex = 11;

        this.MultipleConvulsion = new TTVisual.TTEnumComboBox();
        this.MultipleConvulsion.DataTypeName = "SnappeMultipleConvulsionEnum";
        this.MultipleConvulsion.Name = "MultipleConvulsion";
        this.MultipleConvulsion.TabIndex = 10;

        this.labelMeanBloodPressure = new TTVisual.TTLabel();
        this.labelMeanBloodPressure.Text = "Ortalama Kan Basıncı (mmHg)";
        this.labelMeanBloodPressure.Name = "labelMeanBloodPressure";
        this.labelMeanBloodPressure.TabIndex = 9;

        this.MeanBloodPressure = new TTVisual.TTEnumComboBox();
        this.MeanBloodPressure.DataTypeName = "SnappeMeanBloodPressureEnum";
        this.MeanBloodPressure.Name = "MeanBloodPressure";
        this.MeanBloodPressure.TabIndex = 8;

        this.labelLowestTemperature = new TTVisual.TTLabel();
        this.labelLowestTemperature.Text = "En Düşük Isı";
        this.labelLowestTemperature.Name = "labelLowestTemperature";
        this.labelLowestTemperature.TabIndex = 7;

        this.LowestTemperature = new TTVisual.TTEnumComboBox();
        this.LowestTemperature.DataTypeName = "SnappeLowestTemperatureEnum";
        this.LowestTemperature.Name = "LowestTemperature";
        this.LowestTemperature.TabIndex = 6;

        this.labelDiuresis = new TTVisual.TTLabel();
        this.labelDiuresis.Text = "Diürez";
        this.labelDiuresis.Name = "labelDiuresis";
        this.labelDiuresis.TabIndex = 5;

        this.Diuresis = new TTVisual.TTEnumComboBox();
        this.Diuresis.DataTypeName = "SnappeDiuresisEnum";
        this.Diuresis.Name = "Diuresis";
        this.Diuresis.TabIndex = 4;

        this.labelBirthWeight = new TTVisual.TTLabel();
        this.labelBirthWeight.Text = "Doğum Ağırlığı";
        this.labelBirthWeight.Name = "labelBirthWeight";
        this.labelBirthWeight.TabIndex = 3;

        this.BirthWeight = new TTVisual.TTEnumComboBox();
        this.BirthWeight.DataTypeName = "SnappeBirthWeightEnum";
        this.BirthWeight.Name = "BirthWeight";
        this.BirthWeight.TabIndex = 2;

        this.labelApgar = new TTVisual.TTLabel();
        this.labelApgar.Text = "Apgar Skoru 5. Dakika";
        this.labelApgar.Name = "labelApgar";
        this.labelApgar.TabIndex = 1;

        this.Apgar = new TTVisual.TTEnumComboBox();
        this.Apgar.DataTypeName = "SnappeApgarEnum";
        this.Apgar.Name = "Apgar";
        this.Apgar.TabIndex = 0;

        this.Controls = [this.labelEntryDate, this.EntryDate, this.labelTotalScore, this.TotalScore, this.TotalSnapScore, this.labelSGA, this.SGA, this.labelSerumPH, this.SerumPH, this.labelPo2FiO2, this.Po2FiO2, this.labelMultipleConvulsion, this.MultipleConvulsion, this.labelMeanBloodPressure, this.MeanBloodPressure, this.labelLowestTemperature, this.LowestTemperature, this.labelDiuresis, this.Diuresis, this.labelBirthWeight, this.BirthWeight, this.labelApgar, this.Apgar];

    }


}
