//$48D352AE
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { PrismScoreFormViewModel } from './PrismScoreFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseMultipleDataEntryForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseMultipleDataEntryForm";
import { Prism, PrismCalciumEnum, PrismGlucoseEnum, PrismHeartRateEnum, PrismPotassiumEnum, PrismPTTEnum, PrismPupilEnum, PrismRespirationRateEnum, PrismSystolicEnum, PrismBilirubinEnum, PrismDiastolicEnum, PrismHCO3Enum, PrismPaCO2Enum, PrismPaO2FIO2Enum } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'PrismScoreForm',
    templateUrl: './PrismScoreForm.html',
    providers: [MessageService]
})
export class PrismScoreForm extends BaseMultipleDataEntryForm implements OnInit {
    Bilirubin: TTVisual.ITTEnumComboBox;
    Calcium: TTVisual.ITTEnumComboBox;
    DiastolicPressure: TTVisual.ITTEnumComboBox;
    EntryDate: TTVisual.ITTDateTimePicker;
    Glucose: TTVisual.ITTEnumComboBox;
    HCO3: TTVisual.ITTEnumComboBox;
    HeartRate: TTVisual.ITTEnumComboBox;
    labelBilirubin: TTVisual.ITTLabel;
    labelCalcium: TTVisual.ITTLabel;
    labelDiastolicPressure: TTVisual.ITTLabel;
    labelEntryDate: TTVisual.ITTLabel;
    labelGlucose: TTVisual.ITTLabel;
    labelHCO3: TTVisual.ITTLabel;
    labelHeartRate: TTVisual.ITTLabel;
    labelMortalityRate: TTVisual.ITTLabel;
    labelPaCO2: TTVisual.ITTLabel;
    labelPaO2FIO2: TTVisual.ITTLabel;
    labelPotassium: TTVisual.ITTLabel;
    labelPTT: TTVisual.ITTLabel;
    labelPupil: TTVisual.ITTLabel;
    labelRespirationRate: TTVisual.ITTLabel;
    labelSystolicPressure: TTVisual.ITTLabel;
    labelTotalScore: TTVisual.ITTLabel;
    MortalityRate: TTVisual.ITTTextBox;
    PaCO2: TTVisual.ITTEnumComboBox;
    PaO2FIO2: TTVisual.ITTEnumComboBox;
    Potassium: TTVisual.ITTEnumComboBox;
    PTT: TTVisual.ITTEnumComboBox;
    Pupil: TTVisual.ITTEnumComboBox;
    RespirationRate: TTVisual.ITTEnumComboBox;
    SystolicPressure: TTVisual.ITTEnumComboBox;
    TotalScore: TTVisual.ITTTextBox;

    P_SystolicPressure: TTVisual.ITTTextBox;
    P_RespirationRate: TTVisual.ITTTextBox;
    P_PTT: TTVisual.ITTTextBox;
    P_Potassium: TTVisual.ITTTextBox;
    P_Pupil: TTVisual.ITTTextBox;
    P_DiastolicPressure: TTVisual.ITTTextBox;
    P_PaO2FIO2: TTVisual.ITTTextBox;
    P_Bilirubin: TTVisual.ITTTextBox;
    P_Glucose: TTVisual.ITTTextBox;
    P_HeartRate: TTVisual.ITTTextBox;
    P_PaCO2: TTVisual.ITTTextBox;
    P_Calcium: TTVisual.ITTTextBox;
    P_HCO3: TTVisual.ITTTextBox;

    public prismScoreFormViewModel: PrismScoreFormViewModel = new PrismScoreFormViewModel();
    public get _Prism(): Prism {
        return this._TTObject as Prism;
    }
    private PrismScoreForm_DocumentUrl: string = '/api/PrismService/PrismScoreForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.PrismScoreForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected async PreScript() {
        this.SetAllPrismPoints();
        this.CalculatePrismPoint();
        this.CalculateMortalityRate();
    }
    protected CalculateMortalityRate() {
        let PrismPoint = this._Prism.TotalScore != null ? this._Prism.TotalScore : 0;
        let Logit = (0.207 * PrismPoint) - (0.005 * this.prismScoreFormViewModel.age) - 0.433 - 4.782;
        var eLogit = Math.exp(Logit);
        let _calculatedMortalityRate = Math.Round((eLogit / (1 + eLogit)), 3);
        this._Prism.MortalityRate = Math.Round((_calculatedMortalityRate * 100), 3);
    }

    protected CalculatePrismPoint() {
        let PrismPoint = 0;

        if (this.P_Bilirubin.Text == null)
            this.P_Bilirubin.Text = "0";
        PrismPoint += parseFloat(this.P_Bilirubin.Text);

        if (this.P_Calcium.Text == null)
            this.P_Calcium.Text = "0";
        PrismPoint += parseFloat(this.P_Calcium.Text);

        if (this.P_DiastolicPressure.Text == null)
            this.P_DiastolicPressure.Text = "0";
        PrismPoint += parseFloat(this.P_DiastolicPressure.Text);

        if (this.P_Glucose.Text == null)
            this.P_Glucose.Text = "0";
        PrismPoint += parseFloat(this.P_Glucose.Text);

        if (this.P_HCO3.Text == null)
            this.P_HCO3.Text = "0";
        PrismPoint += parseFloat(this.P_HCO3.Text);

        if (this.P_HeartRate.Text == null)
            this.P_HeartRate.Text = "0";
        PrismPoint += parseFloat(this.P_HeartRate.Text);

        if (this.P_PaCO2.Text == null)
            this.P_PaCO2.Text = "0";
        PrismPoint += parseFloat(this.P_PaCO2.Text);

        if (this.P_PaO2FIO2.Text == null)
            this.P_PaO2FIO2.Text = "0";
        PrismPoint += parseFloat(this.P_PaO2FIO2.Text);

        if (this.P_Potassium.Text == null)
            this.P_Potassium.Text = "0";
        PrismPoint += parseFloat(this.P_Potassium.Text);

        if (this.P_PTT.Text == null)
            this.P_PTT.Text = "0";
        PrismPoint += parseFloat(this.P_PTT.Text);

        if (this.P_Pupil.Text == null)
            this.P_Pupil.Text = "0";
        PrismPoint += parseFloat(this.P_Pupil.Text);

        if (this.P_RespirationRate.Text == null)
            this.P_RespirationRate.Text = "0";
        PrismPoint += parseFloat(this.P_RespirationRate.Text);

        if (this.P_SystolicPressure.Text == null)
            this.P_SystolicPressure.Text = "0";
        PrismPoint += parseFloat(this.P_SystolicPressure.Text);

        this._Prism.TotalScore = PrismPoint;
    }

    protected SetAllPrismPoints() {
        this.SetP_BilirubinForPrism(this.Bilirubin["Value"]);

        this.SetP_CalciumForPrism(this.Calcium["Value"]);

        this.SetP_DiastolicPressureForPrism(this.DiastolicPressure["Value"]);

        this.SetP_GlucoseForPrism(this.Glucose["Value"]);

        this.SetP_HCO3ForPrism(this.HCO3["Value"]);

        this.SetP_HeartRateForPrism(this.HeartRate["Value"]);

        this.SetP_PaCO2ForPrism(this.PaCO2["Value"]);

        this.SetP_PaO2FIO2ForPrism(this.PaO2FIO2["Value"]);

        this.SetP_PotassiumForPrism(this.Potassium["Value"]);

        this.SetP_PTTForPrism(this.PTT["Value"]);

        this.SetP_PupilForPrism(this.Pupil["Value"]);

        this.SetP_RespirationRateForPrism(this.RespirationRate["Value"]);

        this.SetP_SystolicPressureForPrism(this.SystolicPressure["Value"]);

    }

    //Bilirubin
    protected SetP_BilirubinForPrism(value: number) {
        let point = 0;
        if (value != null) {
            if (value == PrismBilirubinEnum.More35)
                point = 0;
        }
        if (value != null) {
            if (value == PrismBilirubinEnum.More60)
                point = 1;
        }
        this.P_Bilirubin.Text = point.toString();
    }

    //Kalsiyum
    protected SetP_CalciumForPrism(value: number) {
        let point = 0;
        if (value != null) {
            if (value == PrismCalciumEnum.Less7)
                point = 6;
            if (value == PrismCalciumEnum._7to8)
                point = 2;
            if (value == PrismCalciumEnum._12to15)
                point = 2;
            if (value == PrismCalciumEnum.More15)
                point = 6;
            if (value == PrismCalciumEnum.Less175)
                point = 6;
            if (value == PrismCalciumEnum._175to2)
                point = 2;
            if (value == PrismCalciumEnum._3to375)
                point = 2;
            if (value == PrismCalciumEnum.More375)
                point = 6;
        }
        this.P_Calcium.Text = point.toString();
    }

    //Diastolik Kan Basıncı
    protected SetP_DiastolicPressureForPrism(value: number) {
        let point = 0;
        if (value != null) {
            if (value == PrismDiastolicEnum.Less110)
                point = 0;
        }
        if (value != null) {
            if (value == PrismDiastolicEnum.More110)
                point = 6;
        }
        this.P_DiastolicPressure.Text = point.toString();
    }

    //Glukoz
    protected SetP_GlucoseForPrism(value: number) {
        let point = 0;
        if (value != null) {
            if (value == PrismGlucoseEnum.Less40)
                point = 8;
            if (value == PrismGlucoseEnum._40to60)
                point = 4;
            if (value == PrismGlucoseEnum._250to400)
                point = 4;
            if (value == PrismGlucoseEnum.More400)
                point = 8;
            if (value == PrismGlucoseEnum.Less222)
                point = 8;
            if (value == PrismGlucoseEnum._222to333)
                point = 4;
            if (value == PrismGlucoseEnum._125to222)
                point = 4;
            if (value == PrismGlucoseEnum.More222)
                point = 8;
        }
        this.P_Glucose.Text = point.toString();
    }

    //HCO3
    protected SetP_HCO3ForPrism(value: number) {
        let point = 0;
        if (value != null) {
            if (value == PrismHCO3Enum.Less16)
                point = 0;
        }
        if (value != null) {
            if (value == PrismHCO3Enum.More32)
                point = 1;
        }
        this.P_HCO3.Text = point.toString();
    }

    //Kalp Hızı
    protected SetP_HeartRateForPrism(value: number) {
        let point = 0;
        if (value != null) {
            if (value == PrismHeartRateEnum.NewBornMore160)
                point = 8;
            if (value == PrismHeartRateEnum.NewBorn91to159)
                point = 4;
            if (value == PrismHeartRateEnum.NewBornLess90)
                point = 4;
            if (value == PrismHeartRateEnum.KidMore150)
                point = 8;
            if (value == PrismHeartRateEnum.Kid81to149)
                point = 8;
            if (value == PrismHeartRateEnum.KidLess80)
                point = 8;
        }
        this.P_HeartRate.Text = point.toString();
    }

    //PaCO2
    protected SetP_PaCO2ForPrism(value: number) {
        let point = 0;
        if (value != null) {
            if (value == PrismPaCO2Enum._51to65)
                point = 1;
        }
        if (value != null) {
            if (value == PrismPaCO2Enum.More65)
                point = 5;
        }
        this.P_PaCO2.Text = point.toString();
    }

    //PaO2FIO2
    protected SetP_PaO2FIO2ForPrism(value: number) {
        let point = 0;
        if (value != null) {
            if (value == PrismPaO2FIO2Enum._200to300)
                point = 2;
        }
        if (value != null) {
            if (value == PrismPaO2FIO2Enum.Less200)
                point = 3;
        }
        this.P_PaO2FIO2.Text = point.toString();
    }

    //Potasyum
    protected SetP_PotassiumForPrism(value: number) {
        let point = 0;
        if (value != null) {
            if (value == PrismPotassiumEnum.Less3)
                point = 5;
            if (value == PrismPotassiumEnum._3to35)
                point = 1;
            if (value == PrismPotassiumEnum._65to75)
                point = 1;
            if (value == PrismPotassiumEnum.More75)
                point = 5;
        }
        this.P_Potassium.Text = point.toString();
    }

    //PT/PTT
    protected SetP_PTTForPrism(value: number) {
        let point = 0;
        if (value != null) {
            if (value == PrismPTTEnum.MoreTimeControl)
                point = 2;
        }
        this.P_PTT.Text = point.toString();
    }

    //PT/PTT
    protected SetP_PupilForPrism(value: number) {
        let point = 0;
        if (value != null) {
            if (value == PrismPupilEnum.Fikse)
                point = 10;
            if (value == PrismPupilEnum.NotEqual)
                point = 4;
        }
        this.P_Pupil.Text = point.toString();
    }

    //Solunum Hızı
    protected SetP_RespirationRateForPrism(value: number) {
        let point = 0;
        if (value != null) {
            if (value == PrismRespirationRateEnum.NewBorn61to90)
                point = 1;
            if (value == PrismRespirationRateEnum.NewBornMore90)
                point = 5;
            if (value == PrismRespirationRateEnum.NewBornApnea)
                point = 5;
            if (value == PrismRespirationRateEnum.Kid51to70)
                point = 1;
            if (value == PrismRespirationRateEnum.KidMore70)
                point = 5;
            if (value == PrismRespirationRateEnum.KidApnea)
                point = 5;
        }
        this.P_RespirationRate.Text = point.toString();
    }

    //Sistolik Kan Basıncı
    protected SetP_SystolicPressureForPrism(value: number) {
        let point = 0;
        if (value != null) {
            if (value == PrismSystolicEnum.NewBornMore160)
                point = 6;
            if (value == PrismSystolicEnum.NewBorn130to160)
                point = 2;
            if (value == PrismSystolicEnum.NewBorn66to129)
                point = 0;
            if (value == PrismSystolicEnum.NewBorn55to65)
                point = 2;
            if (value == PrismSystolicEnum.NewBorn40to54)
                point = 6;
            if (value == PrismSystolicEnum.NewBornLess40)
                point = 7;
            if (value == PrismSystolicEnum.KidMore200)
                point = 6;
            if (value == PrismSystolicEnum.Kid150to200)
                point = 2;
            if (value == PrismSystolicEnum.Kid76to149)
                point = 0;
            if (value == PrismSystolicEnum.Kid65to75)
                point = 2;
            if (value == PrismSystolicEnum.Kid50to64)
                point = 6;
            if (value == PrismSystolicEnum.KidLess50)
                point = 7;
        }
        this.P_SystolicPressure.Text = point.toString();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Prism();
        this.prismScoreFormViewModel = new PrismScoreFormViewModel();
        this._ViewModel = this.prismScoreFormViewModel;
        this.prismScoreFormViewModel._Prism = this._TTObject as Prism;
    }

    protected loadViewModel() {
        let that = this;
        that.prismScoreFormViewModel = this._ViewModel as PrismScoreFormViewModel;
        that._TTObject = this.prismScoreFormViewModel._Prism;
        if (this.prismScoreFormViewModel == null)
            this.prismScoreFormViewModel = new PrismScoreFormViewModel();
        if (this.prismScoreFormViewModel._Prism == null)
            this.prismScoreFormViewModel._Prism = new Prism();

    }

    async ngOnInit() {
        await this.load();
    }

    public onBilirubinChanged(event): void {
        if (this._Prism != null && this._Prism.Bilirubin != event) {
            this._Prism.Bilirubin = event;

            this.SetP_BilirubinForPrism(event);
            this.CalculatePrismPoint();
        }
    }

    public onCalciumChanged(event): void {
        if (this._Prism != null && this._Prism.Calcium != event) {
            this._Prism.Calcium = event;

            this.SetP_CalciumForPrism(event);
            this.CalculatePrismPoint();
        }
    }

    public onDiastolicPressureChanged(event): void {
        if (this._Prism != null && this._Prism.DiastolicPressure != event) {
            this._Prism.DiastolicPressure = event;

            this.SetP_DiastolicPressureForPrism(event);
            this.CalculatePrismPoint();
        }
    }

    public onEntryDateChanged(event): void {
        if (this._Prism != null && this._Prism.EntryDate != event) {
            this._Prism.EntryDate = event;
        }
    }

    public onGlucoseChanged(event): void {
        if (this._Prism != null && this._Prism.Glucose != event) {
            this._Prism.Glucose = event;

            this.SetP_GlucoseForPrism(event);
            this.CalculatePrismPoint();
        }
    }

    public onHCO3Changed(event): void {
        if (this._Prism != null && this._Prism.HCO3 != event) {
            this._Prism.HCO3 = event;

            this.SetP_HCO3ForPrism(event);
            this.CalculatePrismPoint();
        }
    }

    public onHeartRateChanged(event): void {
        if (this._Prism != null && this._Prism.HeartRate != event) {
            this._Prism.HeartRate = event;

            this.SetP_HeartRateForPrism(event);
            this.CalculatePrismPoint();
        }
    }

    public onMortalityRateChanged(event): void {
        if (this._Prism != null && this._Prism.MortalityRate != event) {
            this._Prism.MortalityRate = event;
        }
    }

    public onPaCO2Changed(event): void {
        if (this._Prism != null && this._Prism.PaCO2 != event) {
            this._Prism.PaCO2 = event;

            this.SetP_PaCO2ForPrism(event);
            this.CalculatePrismPoint();
        }
    }

    public onPaO2FIO2Changed(event): void {
        if (this._Prism != null && this._Prism.PaO2FIO2 != event) {
            this._Prism.PaO2FIO2 = event;

            this.SetP_PaO2FIO2ForPrism(event);
            this.CalculatePrismPoint();
        }
    }

    public onPotassiumChanged(event): void {
        if (this._Prism != null && this._Prism.Potassium != event) {
            this._Prism.Potassium = event;

            this.SetP_PotassiumForPrism(event);
            this.CalculatePrismPoint();
        }
    }

    public onPTTChanged(event): void {
        if (this._Prism != null && this._Prism.PTT != event) {
            this._Prism.PTT = event;

            this.SetP_PTTForPrism(event);
            this.CalculatePrismPoint();
        }
    }

    public onPupilChanged(event): void {
        if (this._Prism != null && this._Prism.Pupil != event) {
            this._Prism.Pupil = event;

            this.SetP_PupilForPrism(event);
            this.CalculatePrismPoint();
        }
    }

    public onRespirationRateChanged(event): void {
        if (this._Prism != null && this._Prism.RespirationRate != event) {
            this._Prism.RespirationRate = event;

            this.SetP_RespirationRateForPrism(event);
            this.CalculatePrismPoint();
        }
    }

    public onSystolicPressureChanged(event): void {
        if (this._Prism != null && this._Prism.SystolicPressure != event) {
            this._Prism.SystolicPressure = event;

            this.SetP_SystolicPressureForPrism(event);
            this.CalculatePrismPoint();
        }
    }

    public onTotalScoreChanged(event): void {
        if (this._Prism != null && this._Prism.TotalScore != event) {
            this._Prism.TotalScore = event;
        }

        this.CalculateMortalityRate();
    }



    protected redirectProperties(): void {
        redirectProperty(this.EntryDate, "Value", this.__ttObject, "EntryDate");
        redirectProperty(this.Potassium, "Value", this.__ttObject, "Potassium");
        redirectProperty(this.Bilirubin, "Value", this.__ttObject, "Bilirubin");
        redirectProperty(this.PTT, "Value", this.__ttObject, "PTT");
        redirectProperty(this.Calcium, "Value", this.__ttObject, "Calcium");
        redirectProperty(this.Pupil, "Value", this.__ttObject, "Pupil");
        redirectProperty(this.DiastolicPressure, "Value", this.__ttObject, "DiastolicPressure");
        redirectProperty(this.RespirationRate, "Value", this.__ttObject, "RespirationRate");
        redirectProperty(this.Glucose, "Value", this.__ttObject, "Glucose");
        redirectProperty(this.SystolicPressure, "Value", this.__ttObject, "SystolicPressure");
        redirectProperty(this.HCO3, "Value", this.__ttObject, "HCO3");
        redirectProperty(this.PaCO2, "Value", this.__ttObject, "PaCO2");
        redirectProperty(this.HeartRate, "Value", this.__ttObject, "HeartRate");
        redirectProperty(this.PaO2FIO2, "Value", this.__ttObject, "PaO2FIO2");
        redirectProperty(this.TotalScore, "Text", this.__ttObject, "TotalScore");
        redirectProperty(this.MortalityRate, "Text", this.__ttObject, "MortalityRate");
    }

    public initFormControls(): void {
        this.labelMortalityRate = new TTVisual.TTLabel();
        this.labelMortalityRate.Text = "Beklenen Ölüm Oranı";
        this.labelMortalityRate.Name = "labelMortalityRate";
        this.labelMortalityRate.TabIndex = 31;

        this.MortalityRate = new TTVisual.TTTextBox();
        this.MortalityRate.Name = "MortalityRate";
        this.MortalityRate.TabIndex = 30;

        this.TotalScore = new TTVisual.TTTextBox();
        this.TotalScore.Name = "TotalScore";
        this.TotalScore.TabIndex = 28;

        this.labelTotalScore = new TTVisual.TTLabel();
        this.labelTotalScore.Text = "Toplam Skor";
        this.labelTotalScore.Name = "labelTotalScore";
        this.labelTotalScore.TabIndex = 29;

        this.labelEntryDate = new TTVisual.TTLabel();
        this.labelEntryDate.Text = "Giriş Yapılan Zaman";
        this.labelEntryDate.Name = "labelEntryDate";
        this.labelEntryDate.TabIndex = 27;

        this.EntryDate = new TTVisual.TTDateTimePicker();
        this.EntryDate.Format = DateTimePickerFormat.Long;
        this.EntryDate.Name = "EntryDate";
        this.EntryDate.TabIndex = 26;

        this.labelSystolicPressure = new TTVisual.TTLabel();
        this.labelSystolicPressure.Text = "Sistolik Kan Basıncı (mmHg)";
        this.labelSystolicPressure.Name = "labelSystolicPressure";
        this.labelSystolicPressure.TabIndex = 25;

        this.SystolicPressure = new TTVisual.TTEnumComboBox();
        this.SystolicPressure.DataTypeName = "PrismSystolicEnum";
        this.SystolicPressure.Name = "SystolicPressure";
        this.SystolicPressure.TabIndex = 24;

        this.labelRespirationRate = new TTVisual.TTLabel();
        this.labelRespirationRate.Text = "Solunum Sayısı (breaths/ min)";
        this.labelRespirationRate.Name = "labelRespirationRate";
        this.labelRespirationRate.TabIndex = 23;

        this.RespirationRate = new TTVisual.TTEnumComboBox();
        this.RespirationRate.DataTypeName = "PrismRespirationRateEnum";
        this.RespirationRate.Name = "RespirationRate";
        this.RespirationRate.TabIndex = 22;

        this.labelPupil = new TTVisual.TTLabel();
        this.labelPupil.Text = "Pupil Reaksiyonu";
        this.labelPupil.Name = "labelPupil";
        this.labelPupil.TabIndex = 21;

        this.Pupil = new TTVisual.TTEnumComboBox();
        this.Pupil.DataTypeName = "PrismPupilEnum";
        this.Pupil.Name = "Pupil";
        this.Pupil.TabIndex = 20;

        this.labelPTT = new TTVisual.TTLabel();
        this.labelPTT.Text = "PT / PTT";
        this.labelPTT.Name = "labelPTT";
        this.labelPTT.TabIndex = 19;

        this.PTT = new TTVisual.TTEnumComboBox();
        this.PTT.DataTypeName = "PrismPTTEnum";
        this.PTT.Name = "PTT";
        this.PTT.TabIndex = 18;

        this.labelPotassium = new TTVisual.TTLabel();
        this.labelPotassium.Text = "Potasyum (mEq/L)";
        this.labelPotassium.Name = "labelPotassium";
        this.labelPotassium.TabIndex = 17;

        this.Potassium = new TTVisual.TTEnumComboBox();
        this.Potassium.DataTypeName = "PrismPotassiumEnum";
        this.Potassium.Name = "Potassium";
        this.Potassium.TabIndex = 16;

        this.labelPaO2FIO2 = new TTVisual.TTLabel();
        this.labelPaO2FIO2.Text = "Pa O2 / FI O2 (mmHg)";
        this.labelPaO2FIO2.Name = "labelPaO2FIO2";
        this.labelPaO2FIO2.TabIndex = 15;

        this.PaO2FIO2 = new TTVisual.TTEnumComboBox();
        this.PaO2FIO2.DataTypeName = "PrismPaO2FIO2Enum";
        this.PaO2FIO2.Name = "PaO2FIO2";
        this.PaO2FIO2.TabIndex = 14;

        this.labelPaCO2 = new TTVisual.TTLabel();
        this.labelPaCO2.Text = "Pa CO2 (mmHg)";
        this.labelPaCO2.Name = "labelPaCO2";
        this.labelPaCO2.TabIndex = 13;

        this.PaCO2 = new TTVisual.TTEnumComboBox();
        this.PaCO2.DataTypeName = "PrismPaCO2Enum";
        this.PaCO2.Name = "PaCO2";
        this.PaCO2.TabIndex = 12;

        this.labelHeartRate = new TTVisual.TTLabel();
        this.labelHeartRate.Text = "Kalp Hızı (beats/ min)";
        this.labelHeartRate.Name = "labelHeartRate";
        this.labelHeartRate.TabIndex = 11;

        this.HeartRate = new TTVisual.TTEnumComboBox();
        this.HeartRate.DataTypeName = "PrismHeartRateEnum";
        this.HeartRate.Name = "HeartRate";
        this.HeartRate.TabIndex = 10;

        this.labelHCO3 = new TTVisual.TTLabel();
        this.labelHCO3.Text = "HCO3- (mEq/L)";
        this.labelHCO3.Name = "labelHCO3";
        this.labelHCO3.TabIndex = 9;

        this.HCO3 = new TTVisual.TTEnumComboBox();
        this.HCO3.DataTypeName = "PrismHCO3Enum";
        this.HCO3.Name = "HCO3";
        this.HCO3.TabIndex = 8;

        this.labelGlucose = new TTVisual.TTLabel();
        this.labelGlucose.Text = "Glukoz";
        this.labelGlucose.Name = "labelGlucose";
        this.labelGlucose.TabIndex = 7;

        this.Glucose = new TTVisual.TTEnumComboBox();
        this.Glucose.DataTypeName = "PrismGlucoseEnum";
        this.Glucose.Name = "Glucose";
        this.Glucose.TabIndex = 6;

        this.labelDiastolicPressure = new TTVisual.TTLabel();
        this.labelDiastolicPressure.Text = "Diastolik Kan Basıncı (mmHg)";
        this.labelDiastolicPressure.Name = "labelDiastolicPressure";
        this.labelDiastolicPressure.TabIndex = 5;

        this.DiastolicPressure = new TTVisual.TTEnumComboBox();
        this.DiastolicPressure.DataTypeName = "PrismDiastolicEnum";
        this.DiastolicPressure.Name = "DiastolicPressure";
        this.DiastolicPressure.TabIndex = 4;

        this.labelCalcium = new TTVisual.TTLabel();
        this.labelCalcium.Text = "Kalsiyum";
        this.labelCalcium.Name = "labelCalcium";
        this.labelCalcium.TabIndex = 3;

        this.Calcium = new TTVisual.TTEnumComboBox();
        this.Calcium.DataTypeName = "PrismCalciumEnum";
        this.Calcium.Name = "Calcium";
        this.Calcium.TabIndex = 2;

        this.labelBilirubin = new TTVisual.TTLabel();
        this.labelBilirubin.Text = "Total Bilirubin";
        this.labelBilirubin.Name = "labelBilirubin";
        this.labelBilirubin.TabIndex = 1;

        this.Bilirubin = new TTVisual.TTEnumComboBox();
        this.Bilirubin.DataTypeName = "PrismBilirubinEnum";
        this.Bilirubin.Name = "Bilirubin";
        this.Bilirubin.TabIndex = 0;

        this.P_SystolicPressure = new TTVisual.TTTextBox();
        this.P_SystolicPressure.BackColor = "#F0F0F0";
        this.P_SystolicPressure.ReadOnly = true;
        this.P_SystolicPressure.Name = "P_SystolicPressure";
        this.P_SystolicPressure.TabIndex = 32;

        this.P_RespirationRate = new TTVisual.TTTextBox();
        this.P_RespirationRate.BackColor = "#F0F0F0";
        this.P_RespirationRate.ReadOnly = true;
        this.P_RespirationRate.Name = "P_RespirationRate";
        this.P_RespirationRate.TabIndex = 33;

        this.P_PTT = new TTVisual.TTTextBox();
        this.P_PTT.BackColor = "#F0F0F0";
        this.P_PTT.ReadOnly = true;
        this.P_PTT.Name = "P_PTT";
        this.P_PTT.TabIndex = 34;

        this.P_Potassium = new TTVisual.TTTextBox();
        this.P_Potassium.BackColor = "#F0F0F0";
        this.P_Potassium.ReadOnly = true;
        this.P_Potassium.Name = "P_Potassium";
        this.P_Potassium.TabIndex = 35;

        this.P_Pupil = new TTVisual.TTTextBox();
        this.P_Pupil.BackColor = "#F0F0F0";
        this.P_Pupil.ReadOnly = true;
        this.P_Pupil.Name = "P_Pupil";
        this.P_Pupil.TabIndex = 36;

        this.P_DiastolicPressure = new TTVisual.TTTextBox();
        this.P_DiastolicPressure.BackColor = "#F0F0F0";
        this.P_DiastolicPressure.ReadOnly = true;
        this.P_DiastolicPressure.Name = "P_DiastolicPressure";
        this.P_DiastolicPressure.TabIndex = 37;

        this.P_PaO2FIO2 = new TTVisual.TTTextBox();
        this.P_PaO2FIO2.BackColor = "#F0F0F0";
        this.P_PaO2FIO2.ReadOnly = true;
        this.P_PaO2FIO2.Name = "P_PaO2FIO2";
        this.P_PaO2FIO2.TabIndex = 38;

        this.P_Bilirubin = new TTVisual.TTTextBox();
        this.P_Bilirubin.BackColor = "#F0F0F0";
        this.P_Bilirubin.ReadOnly = true;
        this.P_Bilirubin.Name = "P_Bilirubin";
        this.P_Bilirubin.TabIndex = 39;

        this.P_Glucose = new TTVisual.TTTextBox();
        this.P_Glucose.BackColor = "#F0F0F0";
        this.P_Glucose.ReadOnly = true;
        this.P_Glucose.Name = "P_Glucose";
        this.P_Glucose.TabIndex = 40;

        this.P_HeartRate = new TTVisual.TTTextBox();
        this.P_HeartRate.BackColor = "#F0F0F0";
        this.P_HeartRate.ReadOnly = true;
        this.P_HeartRate.Name = "P_HeartRate";
        this.P_HeartRate.TabIndex = 41;

        this.P_PaCO2 = new TTVisual.TTTextBox();
        this.P_PaCO2.BackColor = "#F0F0F0";
        this.P_PaCO2.ReadOnly = true;
        this.P_PaCO2.Name = "P_PaCO2";
        this.P_PaCO2.TabIndex = 42;

        this.P_Calcium = new TTVisual.TTTextBox();
        this.P_Calcium.BackColor = "#F0F0F0";
        this.P_Calcium.ReadOnly = true;
        this.P_Calcium.Name = "P_Calcium";
        this.P_Calcium.TabIndex = 43;

        this.P_HCO3 = new TTVisual.TTTextBox();
        this.P_HCO3.BackColor = "#F0F0F0";
        this.P_HCO3.ReadOnly = true;
        this.P_HCO3.Name = "P_HCO3";
        this.P_HCO3.TabIndex = 44;

        this.Controls = [this.labelMortalityRate, this.MortalityRate, this.TotalScore, this.labelTotalScore, this.labelEntryDate, this.EntryDate, this.labelSystolicPressure, this.SystolicPressure, this.labelRespirationRate, this.RespirationRate, this.labelPupil, this.Pupil, this.labelPTT, this.PTT, this.labelPotassium, this.Potassium, this.labelPaO2FIO2, this.PaO2FIO2, this.labelPaCO2, this.PaCO2, this.labelHeartRate, this.HeartRate, this.labelHCO3, this.HCO3, this.labelGlucose, this.Glucose, this.labelDiastolicPressure, this.DiastolicPressure, this.labelCalcium, this.Calcium, this.labelBilirubin, this.Bilirubin];

    }


}
