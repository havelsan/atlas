//$0801F76F
import { Component, ViewChild, OnInit, NgZone, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ApacheScoreFormViewModel } from './ApacheScoreFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ApacheScore } from 'NebulaClient/Model/AtlasClientModel';
import { BaseMultipleDataEntryForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseMultipleDataEntryForm";
import { SortByEnum } from 'NebulaClient/Utils/Enums/SortByEnum';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';



import { ApacheAgeEnum, ApacheArterialpHEnum, ApacheBodyTemperatureEnum, ApacheBreathRateEnum, ApacheChronicOrganFailureEnum, ApacheFIO2OverEnum, ApacheFIO2UnderEnum, ApacheGlasgowComaScaleEnum, ApacheHeartRateEnum, ApacheHtEnum, ApacheMeanBloodPressureEnum, ApacheNoAKGEnum, ApacheSerumCreatinineEnum, ApacheSerumPotassiumEnum, ApacheSerumSodiumEnum, ApacheWBCEnum } from 'NebulaClient/Model/AtlasClientModel';

@Component({
    selector: 'ApacheScoreForm',
    templateUrl: './ApacheScoreForm.html',
    providers: [MessageService]
})
export class ApacheScoreForm extends BaseMultipleDataEntryForm implements OnInit {
    Age: TTVisual.ITTEnumComboBox;
    ApacheIITotal: TTVisual.ITTTextBox;
    ArterialpH: TTVisual.ITTEnumComboBox;
    BodyTemperature: TTVisual.ITTEnumComboBox;
    BreathRate: TTVisual.ITTEnumComboBox;
    ChronicOrganFailure: TTVisual.ITTEnumComboBox;
    EntryDate: TTVisual.ITTDateTimePicker;
    ExpectedMortalityRate: TTVisual.ITTTextBox;
    FIO2: TTVisual.ITTTextBox;
    FIO2Over: TTVisual.ITTEnumComboBox;
    FIO2Under: TTVisual.ITTEnumComboBox;
    GlasgowComaScale: TTVisual.ITTEnumComboBox;
    HeartRate: TTVisual.ITTEnumComboBox;
    Ht: TTVisual.ITTEnumComboBox;
    labelAge: TTVisual.ITTLabel;
    labelApacheIITotal: TTVisual.ITTLabel;
    labelArterialpH: TTVisual.ITTLabel;
    labelBodyTemperature: TTVisual.ITTLabel;
    labelBreathRate: TTVisual.ITTLabel;
    labelChronicOrganFailure: TTVisual.ITTLabel;
    labelEntryDate: TTVisual.ITTLabel;
    labelExpectedMortalityRate: TTVisual.ITTLabel;
    labelFIO2: TTVisual.ITTLabel;
    labelFIO2Over: TTVisual.ITTLabel;
    labelFIO2Under: TTVisual.ITTLabel;
    labelGlasgowComaScale: TTVisual.ITTLabel;
    labelHeartRate: TTVisual.ITTLabel;
    labelHt: TTVisual.ITTLabel;
    labelMeanBloodPressure: TTVisual.ITTLabel;
    labelNoAKG: TTVisual.ITTLabel;
    labelPaCO2: TTVisual.ITTLabel;
    labelPaO2: TTVisual.ITTLabel;
    labelSerumCreatinineNoFailure: TTVisual.ITTLabel;
    labelSerumCreatinineYesFailure: TTVisual.ITTLabel;
    labelSerumPotassium: TTVisual.ITTLabel;
    labelSerumSodium: TTVisual.ITTLabel;
    labelWBC: TTVisual.ITTLabel;
    MeanBloodPressure: TTVisual.ITTEnumComboBox;
    NoAKG: TTVisual.ITTEnumComboBox;
    P_Age: TTVisual.ITTTextBox;
    P_ArterialpH: TTVisual.ITTTextBox;
    P_BodyTemperature: TTVisual.ITTTextBox;
    P_BreathRate: TTVisual.ITTTextBox;
    P_ChronicOrganFailure: TTVisual.ITTTextBox;
    P_FIO2Over: TTVisual.ITTTextBox;
    P_FIO2Under: TTVisual.ITTTextBox;
    P_GlasgowComaScale: TTVisual.ITTTextBox;
    P_HeartRate: TTVisual.ITTTextBox;
    P_Ht: TTVisual.ITTTextBox;
    P_MeanBloodPressure: TTVisual.ITTTextBox;
    P_NoAKG: TTVisual.ITTTextBox;
    P_SerumCreatinineNoFailure: TTVisual.ITTTextBox;
    P_SerumCreatinineYesFailure: TTVisual.ITTTextBox;
    P_SerumPotassium: TTVisual.ITTTextBox;
    P_SerumSodium: TTVisual.ITTTextBox;
    P_WBC: TTVisual.ITTTextBox;
    PaCO2: TTVisual.ITTTextBox;
    PaO2: TTVisual.ITTTextBox;
    SerumCreatinineNoFailure: TTVisual.ITTEnumComboBox;
    SerumCreatinineYesFailure: TTVisual.ITTEnumComboBox;
    SerumPotassium: TTVisual.ITTEnumComboBox;
    SerumSodium: TTVisual.ITTEnumComboBox;
    WBC: TTVisual.ITTEnumComboBox;
    public apacheScoreFormViewModel: ApacheScoreFormViewModel = new ApacheScoreFormViewModel();
    public get _ApacheScore(): ApacheScore {
        return this._TTObject as ApacheScore;
    }
    private ApacheScoreForm_DocumentUrl: string = '/api/ApacheScoreService/ApacheScoreForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ApacheScoreForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected async PreScript() {
        this.SetAllApachePoints();
        this.CalculateApachePoint();
        this.CalculateWaitingMortalite();
        if (this._ApacheScore.FIO2 != null && this._ApacheScore.PaCO2 != null && this._ApacheScore.PaO2 != null) {
            this.CalculateO2GradientmmHg(this._ApacheScore.FIO2, this._ApacheScore.PaCO2, this._ApacheScore.PaO2);
        }
    }
    public CalculateO2GradientmmHg(FIO2: number, PaCO2: number, PaO2: number) {
        let dg = (100 - 6.2);
        this.apacheScoreFormViewModel.O2GradientmmHg = ((100 - 6.2) * FIO2) - PaCO2 - PaO2;
        this.apacheScoreFormViewModel.O2GradientKPa = ((760 - 47) * FIO2) - PaCO2 - PaO2;
    }

    /***********************    T�m Puanlar� Belirleme  ************************/
    protected SetAllApachePoints() {
        //V�cut Is�s�
        this.SetP_BodyTemperatureForApache(this.BodyTemperature["Value"]);

        //Ortalama Kan Bas�nc�
        this.SetP_MeanBloodPressureForApache(this.MeanBloodPressure["Value"]);

        //Kalp H�z�
        this.SetP_HeartRateForApache(this.HeartRate["Value"]);

        //Solunum H�z�
        this.SetP_BreathRateForApache(this.BreathRate["Value"]);

        //FIO2 >= 0,5 ise (A-a) O2
        this.SetP_FIO2OverForApache(this.FIO2Over["Value"]);

        //FIO2 < 0,5 ise PaO2
        this.SetP_FIO2UnderForApache(this.FIO2Under["Value"]);

        //AKG yok ise
        this.SetP_NoAKGForApache(this.NoAKG["Value"]);

        //Arterial pH
        this.SetP_ArterialpHForApache(this.ArterialpH["Value"]);

        //Serum Sodyum
        this.SetP_SerumSodiumForApache(this.SerumSodium["Value"]);

        //Serum Potasyum
        this.SetP_SerumPotassiumForApache(this.SerumPotassium["Value"]);

        //Serum Kreatin ( Akut B�brek Yetmezli�i Var )
        this.SetP_SerumCreatinineYesFailureForApache(this.SerumCreatinineYesFailure["Value"]);

        //Serum Kreatin ( Akut B�brek Yetmezli�i Yok )
        this.SetP_SerumCreatinineNoFailureForApache(this.SerumCreatinineNoFailure["Value"]);

        //Ht
        this.SetP_HtForApache(this.Ht["Value"]);

        //W.B.C.
        this.SetP_WBCForApache(this.WBC["Value"]);

        //Glasgow Koma Skore
        this.SetP_GlasgowComaScaleForApache(this.GlasgowComaScale["Value"]);

        //Ya�
        this.SetP_AgeForApache(this.Age["Value"]);

        //Kronik Organ Yetmezil�i
        this.SetP_ChronicOrganFailureForApache(this.ChronicOrganFailure["Value"]);
    }

    /***********************    T�m Puanlar� Toplama  ************************/
    protected CalculateApachePoint() {
        // Apache II i�in Puan
        let ApachePoint = 0;

        //V�cut Is�s�
        if (this.P_BodyTemperature.Text == null)
            this.P_BodyTemperature.Text = "0";
        ApachePoint += parseFloat(this.P_BodyTemperature.Text);

        //Ortalama Kan Bas�nc�
        if (this.P_MeanBloodPressure.Text == null)
            this.P_MeanBloodPressure.Text = "0";
        ApachePoint += parseFloat(this.P_MeanBloodPressure.Text);

        //Kalp H�z�
        if (this.P_HeartRate.Text == null)
            this.P_HeartRate.Text = "0";
        ApachePoint += parseFloat(this.P_HeartRate.Text);

        //Solunum H�z�
        if (this.P_BreathRate.Text == null)
            this.P_BreathRate.Text = "0";
        ApachePoint += parseFloat(this.P_BreathRate.Text);

        //FIO2 >= 0,5 ise (A-a) O2
        if (this.P_FIO2Over.Text == null)
            this.P_FIO2Over.Text = "0";
        ApachePoint += parseFloat(this.P_FIO2Over.Text);

        //FIO2 < 0,5 ise PaO2
        if (this.P_FIO2Under.Text == null)
            this.P_FIO2Under.Text = "0";
        ApachePoint += parseFloat(this.P_FIO2Under.Text);

        //AKG yok ise
        if (this.P_NoAKG.Text == null)
            this.P_NoAKG.Text = "0";
        ApachePoint += parseFloat(this.P_NoAKG.Text);

        //Arterial pH
        if (this.P_ArterialpH.Text == null)
            this.P_ArterialpH.Text = "0";
        ApachePoint += parseFloat(this.P_ArterialpH.Text);

        //Serum Sodyum
        if (this.P_SerumSodium.Text == null)
            this.P_SerumSodium.Text = "0";
        ApachePoint += parseFloat(this.P_SerumSodium.Text);

        //Serum Potasyum
        if (this.P_SerumPotassium.Text == null)
            this.P_SerumPotassium.Text = "0";
        ApachePoint += parseFloat(this.P_SerumPotassium.Text);

        //Serum Kreatin ( Akut B�brek Yetmezli�i Var )
        if (this.P_SerumCreatinineYesFailure.Text == null)
            this.P_SerumCreatinineYesFailure.Text = "0";
        ApachePoint += parseFloat(this.P_SerumCreatinineYesFailure.Text);

        //Serum Kreatin ( Akut B�brek Yetmezli�i Yok )
        if (this.P_SerumCreatinineNoFailure.Text == null)
            this.P_SerumCreatinineNoFailure.Text = "0";
        ApachePoint += parseFloat(this.P_SerumCreatinineNoFailure.Text);

        //Ht
        if (this.P_Ht.Text == null)
            this.P_Ht.Text = "0";
        ApachePoint += parseFloat(this.P_Ht.Text);

        //W.B.C.
        if (this.P_WBC.Text == null)
            this.P_WBC.Text = "0";
        ApachePoint += parseFloat(this.P_WBC.Text);

        //Glasgow Koma Skore
        if (this.P_GlasgowComaScale.Text == null)
            this.P_GlasgowComaScale.Text = "0";
        ApachePoint += parseFloat(this.P_GlasgowComaScale.Text);

        //Ya�
        if (this.P_Age.Text == null)
            this.P_Age.Text = "0";
        ApachePoint += parseFloat(this.P_Age.Text);

        //Kronik Organ Yetmezil�i
        if (this.P_ChronicOrganFailure.Text == null)
            this.P_ChronicOrganFailure.Text = "0";
        ApachePoint += parseFloat(this.P_ChronicOrganFailure.Text);

        this._ApacheScore.ApacheIITotal = ApachePoint;
    }

    protected CalculateWaitingMortalite() {

        let ApachePoint = this._ApacheScore.ApacheIITotal != null ? this._ApacheScore.ApacheIITotal : 0;

        let Logit = -3.517 + (ApachePoint * 0.146);
        let eLogit = Math.exp(Logit);
        let _calculatedMortalityRate = Math.Round((eLogit / (1 + eLogit)), 3);
        this._ApacheScore.ExpectedMortalityRate = Math.Round((_calculatedMortalityRate * 100), 3);
    }

    /***********************************************    Apache Puan E�le�tirmeleri  ************************************************/
    //Vücut Isısı
    protected SetP_BodyTemperatureForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheBodyTemperatureEnum.Under29)
                point = 4;
            else if (value == ApacheBodyTemperatureEnum._30to31)
                point = 3;
            else if (value == ApacheBodyTemperatureEnum._32to33)
                point = 2;
            else if (value == ApacheBodyTemperatureEnum._34to35)
                point = 1;
            else if (value == ApacheBodyTemperatureEnum._36to38)
                point = 0;
            else if (value == ApacheBodyTemperatureEnum._38to38)
                point = 1;
            else if (value == ApacheBodyTemperatureEnum._39to40)
                point = 3;
            else if (value == ApacheBodyTemperatureEnum.Over41)
                point = 4;
        }
        this.P_BodyTemperature.Text = point.toString();
    }

    //Ortalama Kan Bas�nc�
    protected SetP_MeanBloodPressureForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheMeanBloodPressureEnum.Under49)
                point = 4;
            else if (value == ApacheMeanBloodPressureEnum._50to69)
                point = 2;
            else if (value == ApacheMeanBloodPressureEnum._70to109)
                point = 0;
            else if (value == ApacheMeanBloodPressureEnum._110to129)
                point = 2;
            else if (value == ApacheMeanBloodPressureEnum._130to159)
                point = 3;
            else if (value == ApacheMeanBloodPressureEnum.Over160)
                point = 4;
        }
        this.P_MeanBloodPressure.Text = point.toString();
    }

    //Kalp H�z�
    protected SetP_HeartRateForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheHeartRateEnum.Under39)
                point = 4;
            else if (value == ApacheHeartRateEnum._40to54)
                point = 3;
            else if (value == ApacheHeartRateEnum._55to69)
                point = 2;
            else if (value == ApacheHeartRateEnum._70to109)
                point = 0;
            else if (value == ApacheHeartRateEnum._110to139)
                point = 2;
            else if (value == ApacheHeartRateEnum._140to179)
                point = 3;
            else if (value == ApacheHeartRateEnum.Over180)
                point = 4;
        }
        this.P_HeartRate.Text = point.toString();
    }

    //Solunum H�z�
    protected SetP_BreathRateForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheBreathRateEnum.Under5)
                point = 4;
            else if (value == ApacheBreathRateEnum._6to9)
                point = 2;
            else if (value == ApacheBreathRateEnum._10to11)
                point = 1;
            else if (value == ApacheBreathRateEnum._12to24)
                point = 0;
            else if (value == ApacheBreathRateEnum._25to34)
                point = 1;
            else if (value == ApacheBreathRateEnum._35to49)
                point = 3;
            else if (value == ApacheBreathRateEnum.Over50)
                point = 4;
        }
        this.P_BreathRate.Text = point.toString();
    }

    //FIO2 >= 0,5 ise (A-a) O2
    protected SetP_FIO2OverForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheFIO2OverEnum.Under200)
                point = 0;
            else if (value == ApacheFIO2OverEnum._200to349)
                point = 2;
            else if (value == ApacheFIO2OverEnum._350to499)
                point = 3;
            else if (value == ApacheFIO2OverEnum.Over500)
                point = 4;
        }
        this.P_FIO2Over.Text = point.toString();
    }

    //FIO2 < 0,5 ise PaO2
    protected SetP_FIO2UnderForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheFIO2UnderEnum.Under55)
                point = 4;
            else if (value == ApacheFIO2UnderEnum._55to60)
                point = 3;
            else if (value == ApacheFIO2UnderEnum._61to70)
                point = 1;
            else if (value == ApacheFIO2UnderEnum.Over70)
                point = 0;
        }
        this.P_FIO2Under.Text = point.toString();
    }

    //AKG yok ise
    protected SetP_NoAKGForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheNoAKGEnum.Over52)
                point = 4;
            else if (value == ApacheNoAKGEnum._41to51)
                point = 3;
            else if (value == ApacheNoAKGEnum._32to40)
                point = 1;
            else if (value == ApacheNoAKGEnum._22to31)
                point = 0;
            else if (value == ApacheNoAKGEnum._18to21)
                point = 2;
            else if (value == ApacheNoAKGEnum._15to17)
                point = 3;
            else if (value == ApacheNoAKGEnum.Under15)
                point = 4;
        }
        this.P_NoAKG.Text = point.toString();
    }

    //Arterial pH
    protected SetP_ArterialpHForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheArterialpHEnum.Over77)
                point = 4;
            else if (value == ApacheArterialpHEnum._76to769)
                point = 3;
            else if (value == ApacheArterialpHEnum._75to759)
                point = 1;
            else if (value == ApacheArterialpHEnum._733to749)
                point = 0;
            else if (value == ApacheArterialpHEnum._725to732)
                point = 2;
            else if (value == ApacheArterialpHEnum._715to724)
                point = 3;
            else if (value == ApacheArterialpHEnum.Under715)
                point = 4;
        }
        this.P_ArterialpH.Text = point.toString();
    }

    //Serum Sodyum
    protected SetP_SerumSodiumForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheSerumSodiumEnum.Over180)
                point = 4;
            else if (value == ApacheSerumSodiumEnum._160to179)
                point = 3;
            else if (value == ApacheSerumSodiumEnum._155to159)
                point = 2;
            else if (value == ApacheSerumSodiumEnum._150to154)
                point = 1;
            else if (value == ApacheSerumSodiumEnum._130to149)
                point = 0;
            else if (value == ApacheSerumSodiumEnum._120to129)
                point = 2;
            else if (value == ApacheSerumSodiumEnum._111to119)
                point = 3;
            else if (value == ApacheSerumSodiumEnum.Under110)
                point = 4;
        }
        this.P_SerumSodium.Text = point.toString();
    }

    //Serum Potasyum
    protected SetP_SerumPotassiumForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheSerumPotassiumEnum.Over7)
                point = 4;
            else if (value == ApacheSerumPotassiumEnum._6to69)
                point = 3;
            else if (value == ApacheSerumPotassiumEnum._55to59)
                point = 1;
            else if (value == ApacheSerumPotassiumEnum._34to54)
                point = 0;
            else if (value == ApacheSerumPotassiumEnum._3to34)
                point = 1;
            else if (value == ApacheSerumPotassiumEnum._25to29)
                point = 2;
            else if (value == ApacheSerumPotassiumEnum.Under25)
                point = 4;
        }
        this.P_SerumPotassium.Text = point.toString();
    }

    //Serum Kreatin ( Akut B�brek Yetmezli�i Var )
    protected SetP_SerumCreatinineYesFailureForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheSerumCreatinineEnum._54)
                point = 4;
            else if (value == ApacheSerumCreatinineEnum._54to129)
                point = 0;
            else if (value == ApacheSerumCreatinineEnum._130to169)
                point = 4;
            else if (value == ApacheSerumCreatinineEnum._170to304)
                point = 6;
            else if (value == ApacheSerumCreatinineEnum._305)
                point = 8;
        }
        this.P_SerumCreatinineYesFailure.Text = point.toString();
    }

    //Serum Kreatin ( Akut B�brek Yetmezli�i Yok )
    protected SetP_SerumCreatinineNoFailureForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheSerumCreatinineEnum._54)
                point = 4;
            else if (value == ApacheSerumCreatinineEnum._54to129)
                point = 0;
            else if (value == ApacheSerumCreatinineEnum._130to169)
                point = 4;
            else if (value == ApacheSerumCreatinineEnum._170to304)
                point = 6;
            else if (value == ApacheSerumCreatinineEnum._305)
                point = 8;
        }
        this.P_SerumCreatinineNoFailure.Text = point.toString();
    }

    //Ht
    protected SetP_HtForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheHtEnum.Under20)
                point = 4;
            else if (value == ApacheHtEnum._20to29)
                point = 2;
            else if (value == ApacheHtEnum._30to45)
                point = 0;
            else if (value == ApacheHtEnum._46to49)
                point = 1;
            else if (value == ApacheHtEnum._50to59)
                point = 2;
            else if (value == ApacheHtEnum.Over60)
                point = 4;
        }
        this.P_Ht.Text = point.toString();
    }

    //W.B.C.
    protected SetP_WBCForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheWBCEnum.Under1)
                point = 4;
            else if (value == ApacheWBCEnum._1to2)
                point = 2;
            else if (value == ApacheWBCEnum._3to14)
                point = 0;
            else if (value == ApacheWBCEnum._15to19)
                point = 1;
            else if (value == ApacheWBCEnum._20to39)
                point = 2;
            else if (value == ApacheWBCEnum.Over40)
                point = 4;
        }
        this.P_WBC.Text = point.toString();
    }

    //Glasgow Koma Skore
    protected SetP_GlasgowComaScaleForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheGlasgowComaScaleEnum._15)
                point = 0;
            else if (value == ApacheGlasgowComaScaleEnum._14)
                point = 1;
            else if (value == ApacheGlasgowComaScaleEnum._13)
                point = 2;
            else if (value == ApacheGlasgowComaScaleEnum._12)
                point = 3;
            else if (value == ApacheGlasgowComaScaleEnum._11)
                point = 4;
            else if (value == ApacheGlasgowComaScaleEnum._10)
                point = 5;
            else if (value == ApacheGlasgowComaScaleEnum._9)
                point = 6;
            else if (value == ApacheGlasgowComaScaleEnum._8)
                point = 7;
            else if (value == ApacheGlasgowComaScaleEnum._7)
                point = 8;
            else if (value == ApacheGlasgowComaScaleEnum._6)
                point = 9;
            else if (value == ApacheGlasgowComaScaleEnum._5)
                point = 10;
            else if (value == ApacheGlasgowComaScaleEnum._4)
                point = 11;
            else if (value == ApacheGlasgowComaScaleEnum._3)
                point = 12;
        }
        this.P_GlasgowComaScale.Text = point.toString();
    }

    //Ya�
    protected SetP_AgeForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheAgeEnum.Under44)
                point = 0;
            else if (value == ApacheAgeEnum._45to54)
                point = 2;
            else if (value == ApacheAgeEnum._55to64)
                point = 3;
            else if (value == ApacheAgeEnum._65to74)
                point = 5;
            else if (value == ApacheAgeEnum.Over75)
                point = 6;
        }
        this.P_Age.Text = point.toString();
    }

    //Kronik Organ Yetmezil�i
    protected SetP_ChronicOrganFailureForApache(value: number) {
        let point = 0;
        if (value != null) {
            if (value == ApacheChronicOrganFailureEnum.AndNonOperative)
                point = 5;
            else if (value == ApacheChronicOrganFailureEnum.AndEmergPostoperative)
                point = 5;
            else if (value == ApacheChronicOrganFailureEnum.AndElectPostoperative)
                point = 2;
        }
        this.P_ChronicOrganFailure.Text = point.toString();
    }
    /***********************************************   .\ Apache Puan E�le�tirmeleri  ************************************************/


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ApacheScore();
        this.apacheScoreFormViewModel = new ApacheScoreFormViewModel();
        this._ViewModel = this.apacheScoreFormViewModel;
        this.apacheScoreFormViewModel._ApacheScore = this._TTObject as ApacheScore;
    }

    protected loadViewModel() {
        let that = this;
        that.apacheScoreFormViewModel = this._ViewModel as ApacheScoreFormViewModel;
        that._TTObject = this.apacheScoreFormViewModel._ApacheScore;
        if (this.apacheScoreFormViewModel == null)
            this.apacheScoreFormViewModel = new ApacheScoreFormViewModel();
        if (this.apacheScoreFormViewModel._ApacheScore == null)
            this.apacheScoreFormViewModel._ApacheScore = new ApacheScore();

    }

    async ngOnInit() {
        let that = this;
        await this.load(ApacheScoreFormViewModel);

    }

    public onAgeChanged(event): void {
        if (event != null) {
            if (this._ApacheScore != null && this._ApacheScore.Age != event) {
                this._ApacheScore.Age = event;

                //Hesaplamalar
                this.SetP_AgeForApache(event);
                this.CalculateApachePoint();
            }
        }
    }

    public onApacheIITotalChanged(event): void {
        if (event != null) {
            if (this._ApacheScore != null && this._ApacheScore.ApacheIITotal != event) {
                this._ApacheScore.ApacheIITotal = event;
            }
            this.CalculateWaitingMortalite();
        }
    }

    public onArterialpHChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.ArterialpH != event) {
            this._ApacheScore.ArterialpH = event;

            //Hesaplamalar
            this.SetP_ArterialpHForApache(event);
            this.CalculateApachePoint();
        }
    }

    public onBodyTemperatureChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.BodyTemperature != event) {
            this._ApacheScore.BodyTemperature = event;

            //Hesaplamalar
            this.SetP_BodyTemperatureForApache(event);
            this.CalculateApachePoint();
        }
    }

    public onBreathRateChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.BreathRate != event) {
            this._ApacheScore.BreathRate = event;

            //Hesaplamalar
            this.SetP_BreathRateForApache(event);
            this.CalculateApachePoint();
        }
    }

    public onChronicOrganFailureChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.ChronicOrganFailure != event) {
            this._ApacheScore.ChronicOrganFailure = event;

            //Hesaplamalar
            this.SetP_ChronicOrganFailureForApache(event);
            this.CalculateApachePoint();
        }
    }

    public onEntryDateChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.EntryDate != event) {
            this._ApacheScore.EntryDate = event;
        }
    }

    public onExpectedMortalityRateChanged(event): void {
        if (event != null) {
            if (this._ApacheScore != null && this._ApacheScore.ExpectedMortalityRate != event) {
                this._ApacheScore.ExpectedMortalityRate = event;
            }
        }
    }

    public onFIO2Changed(event): void {
        if (this._ApacheScore != null && this._ApacheScore.FIO2 != event) {
            this._ApacheScore.FIO2 = event;
            if (this._ApacheScore.FIO2 != null && this._ApacheScore.PaCO2 != null && this._ApacheScore.PaO2 != null) {
                this.CalculateO2GradientmmHg(this._ApacheScore.FIO2, this._ApacheScore.PaCO2, this._ApacheScore.PaO2);
            }
        }
    }

    public onFIO2OverChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.FIO2Over != event) {
            this._ApacheScore.FIO2Over = event;

            //Hesaplamalar
            this.SetP_FIO2OverForApache(event);
            this.CalculateApachePoint();
        }
    }

    public onFIO2UnderChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.FIO2Under != event) {
            this._ApacheScore.FIO2Under = event;

            //Hesaplamalar
            this.SetP_FIO2UnderForApache(event);
            this.CalculateApachePoint();
        }
    }

    public onGlasgowComaScaleChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.GlasgowComaScale != event) {
            this._ApacheScore.GlasgowComaScale = event;

            //Hesaplamalar
            this.SetP_GlasgowComaScaleForApache(event);
            this.CalculateApachePoint();
        }
    }

    public onHeartRateChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.HeartRate != event) {
            this._ApacheScore.HeartRate = event;

            //Hesaplamalar
            this.SetP_HeartRateForApache(event);
            this.CalculateApachePoint();
        }
    }

    public onHtChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.Ht != event) {
            this._ApacheScore.Ht = event;

            //Hesaplamalar
            this.SetP_HtForApache(event);
            this.CalculateApachePoint();
        }
    }

    public onMeanBloodPressureChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.MeanBloodPressure != event) {
            this._ApacheScore.MeanBloodPressure = event;

            //Hesaplamalar
            this.SetP_MeanBloodPressureForApache(event);
            this.CalculateApachePoint();
        }
    }

    public onNoAKGChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.NoAKG != event) {
            this._ApacheScore.NoAKG = event;

            //Hesaplamalar
            this.SetP_NoAKGForApache(event);
            this.CalculateApachePoint();
        }
    }

    public onPaCO2Changed(event): void {
        if (this._ApacheScore != null && this._ApacheScore.PaCO2 != event) {
            this._ApacheScore.PaCO2 = event;
            if (this._ApacheScore.FIO2 != null && this._ApacheScore.PaCO2 != null && this._ApacheScore.PaO2 != null) {
                this.CalculateO2GradientmmHg(this._ApacheScore.FIO2, this._ApacheScore.PaCO2, this._ApacheScore.PaO2);
            }
        }
    }

    public onPaO2Changed(event): void {
        if (this._ApacheScore != null && this._ApacheScore.PaO2 != event) {
            this._ApacheScore.PaO2 = event;
            if (this._ApacheScore.FIO2 != null && this._ApacheScore.PaCO2 != null && this._ApacheScore.PaO2 != null) {
                this.CalculateO2GradientmmHg(this._ApacheScore.FIO2, this._ApacheScore.PaCO2, this._ApacheScore.PaO2);
            }
        }
    }

    public onSerumCreatinineNoFailureChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.SerumCreatinineNoFailure != event) {
            this._ApacheScore.SerumCreatinineNoFailure = event;

            //Hesaplamalar
            this.SetP_SerumCreatinineNoFailureForApache(event);
            this.CalculateApachePoint();
        }
    }

    public onSerumCreatinineYesFailureChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.SerumCreatinineYesFailure != event) {
            this._ApacheScore.SerumCreatinineYesFailure = event;

            //Hesaplamalar
            this.SetP_SerumCreatinineYesFailureForApache(event);
            this.CalculateApachePoint();
        }
    }

    public onSerumPotassiumChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.SerumPotassium != event) {
            this._ApacheScore.SerumPotassium = event;

            //Hesaplamalar
            this.SetP_SerumPotassiumForApache(event);
            this.CalculateApachePoint();
        }
    }

    public onSerumSodiumChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.SerumSodium != event) {
            this._ApacheScore.SerumSodium = event;

            //Hesaplamalar
            this.SetP_SerumSodiumForApache(event);
            this.CalculateApachePoint();
        }
    }

    public onWBCChanged(event): void {
        if (this._ApacheScore != null && this._ApacheScore.WBC != event) {
            this._ApacheScore.WBC = event;

            //Hesaplamalar
            this.SetP_WBCForApache(event);
            this.CalculateApachePoint();
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.EntryDate, "Value", this.__ttObject, "EntryDate");
        redirectProperty(this.ApacheIITotal, "Text", this.__ttObject, "ApacheIITotal");
        redirectProperty(this.ExpectedMortalityRate, "Text", this.__ttObject, "ExpectedMortalityRate");
        redirectProperty(this.BodyTemperature, "Value", this.__ttObject, "BodyTemperature");
        redirectProperty(this.MeanBloodPressure, "Value", this.__ttObject, "MeanBloodPressure");
        redirectProperty(this.HeartRate, "Value", this.__ttObject, "HeartRate");
        redirectProperty(this.BreathRate, "Value", this.__ttObject, "BreathRate");
        redirectProperty(this.FIO2Over, "Value", this.__ttObject, "FIO2Over");
        redirectProperty(this.FIO2Under, "Value", this.__ttObject, "FIO2Under");
        redirectProperty(this.NoAKG, "Value", this.__ttObject, "NoAKG");
        redirectProperty(this.ArterialpH, "Value", this.__ttObject, "ArterialpH");
        redirectProperty(this.SerumSodium, "Value", this.__ttObject, "SerumSodium");
        redirectProperty(this.SerumPotassium, "Value", this.__ttObject, "SerumPotassium");
        redirectProperty(this.SerumCreatinineYesFailure, "Value", this.__ttObject, "SerumCreatinineYesFailure");
        redirectProperty(this.SerumCreatinineNoFailure, "Value", this.__ttObject, "SerumCreatinineNoFailure");
        redirectProperty(this.Ht, "Value", this.__ttObject, "Ht");
        redirectProperty(this.WBC, "Value", this.__ttObject, "WBC");
        redirectProperty(this.GlasgowComaScale, "Value", this.__ttObject, "GlasgowComaScale");
        redirectProperty(this.Age, "Value", this.__ttObject, "Age");
        redirectProperty(this.ChronicOrganFailure, "Value", this.__ttObject, "ChronicOrganFailure");
        redirectProperty(this.PaCO2, "Text", this.__ttObject, "PaCO2");
        redirectProperty(this.PaO2, "Text", this.__ttObject, "PaO2");
        redirectProperty(this.FIO2, "Text", this.__ttObject, "FIO2");
    }

    public initFormControls(): void {
        this.labelPaO2 = new TTVisual.TTLabel();
        this.labelPaO2.Text = "PaO2";
        this.labelPaO2.Name = "labelPaO2";
        this.labelPaO2.TabIndex = 51;

        this.PaO2 = new TTVisual.TTTextBox();
        this.PaO2.Name = "PaO2";
        this.PaO2.TabIndex = 50;

        this.PaCO2 = new TTVisual.TTTextBox();
        this.PaCO2.Name = "PaCO2";
        this.PaCO2.TabIndex = 48;

        this.FIO2 = new TTVisual.TTTextBox();
        this.FIO2.Name = "FIO2";
        this.FIO2.TabIndex = 46;
        this.labelPaCO2 = new TTVisual.TTLabel();
        this.labelPaCO2.Text = "PaCO2";
        this.labelPaCO2.Name = "labelPaCO2";
        this.labelPaCO2.TabIndex = 49;

        this.labelFIO2 = new TTVisual.TTLabel();
        this.labelFIO2.Text = "FIO2";
        this.labelFIO2.Name = "labelFIO2";
        this.labelFIO2.TabIndex = 47;

        this.labelSerumCreatinineNoFailure = new TTVisual.TTLabel();
        this.labelSerumCreatinineNoFailure.Text = "Serum Kreatin Akut Böbrek Yetmezliği Yok";
        this.labelSerumCreatinineNoFailure.Name = "labelSerumCreatinineNoFailure";
        this.labelSerumCreatinineNoFailure.TabIndex = 45;

        this.SerumCreatinineNoFailure = new TTVisual.TTEnumComboBox();
        this.SerumCreatinineNoFailure.DataTypeName = "ApacheSerumCreatinineEnum";
        this.SerumCreatinineNoFailure.SortBy = SortByEnum.Value;
        this.SerumCreatinineNoFailure.Name = "SerumCreatinineNoFailure";
        this.SerumCreatinineNoFailure.TabIndex = 44;

        this.labelSerumCreatinineYesFailure = new TTVisual.TTLabel();
        this.labelSerumCreatinineYesFailure.Text = "Serum Kreatin Akut Böbrek Yetmezliği Var";
        this.labelSerumCreatinineYesFailure.Name = "labelSerumCreatinineYesFailure";
        this.labelSerumCreatinineYesFailure.TabIndex = 43;

        this.SerumCreatinineYesFailure = new TTVisual.TTEnumComboBox();
        this.SerumCreatinineYesFailure.DataTypeName = "ApacheSerumCreatinineEnum";
        this.SerumCreatinineYesFailure.SortBy = SortByEnum.Value;
        this.SerumCreatinineYesFailure.Name = "SerumCreatinineYesFailure";
        this.SerumCreatinineYesFailure.TabIndex = 42;

        this.labelEntryDate = new TTVisual.TTLabel();
        this.labelEntryDate.Text = "Giriş Yapılan Zaman";
        this.labelEntryDate.Name = "labelEntryDate";
        this.labelEntryDate.TabIndex = 41;

        this.EntryDate = new TTVisual.TTDateTimePicker();
        this.EntryDate.Format = DateTimePickerFormat.Long;
        this.EntryDate.Name = "EntryDate";
        this.EntryDate.TabIndex = 40;

        this.labelExpectedMortalityRate = new TTVisual.TTLabel();
        this.labelExpectedMortalityRate.Text = "Beklenen Ölüm Oranı";
        this.labelExpectedMortalityRate.Name = "labelExpectedMortalityRate";
        this.labelExpectedMortalityRate.TabIndex = 35;

        this.ExpectedMortalityRate = new TTVisual.TTTextBox();
        this.ExpectedMortalityRate.BackColor = "#F0F0F0";
        this.ExpectedMortalityRate.ReadOnly = true;
        this.ExpectedMortalityRate.Name = "ExpectedMortalityRate";
        this.ExpectedMortalityRate.TabIndex = 34;

        this.ApacheIITotal = new TTVisual.TTTextBox();
        this.ApacheIITotal.BackColor = "#F0F0F0";
        this.ApacheIITotal.ReadOnly = true;
        this.ApacheIITotal.Name = "ApacheIITotal";
        this.ApacheIITotal.TabIndex = 32;

        this.P_BodyTemperature = new TTVisual.TTTextBox();
        this.P_BodyTemperature.BackColor = "#F0F0F0";
        this.P_BodyTemperature.ReadOnly = true;
        this.P_BodyTemperature.Name = "P_BodyTemperature";
        this.P_BodyTemperature.TabIndex = 39;

        this.P_BreathRate = new TTVisual.TTTextBox();
        this.P_BreathRate.BackColor = "#F0F0F0";
        this.P_BreathRate.ReadOnly = true;
        this.P_BreathRate.Name = "P_BreathRate";
        this.P_BreathRate.TabIndex = 39;

        this.P_NoAKG = new TTVisual.TTTextBox();
        this.P_NoAKG.BackColor = "#F0F0F0";
        this.P_NoAKG.ReadOnly = true;
        this.P_NoAKG.Name = "P_NoAKG";
        this.P_NoAKG.TabIndex = 39;

        this.P_SerumPotassium = new TTVisual.TTTextBox();
        this.P_SerumPotassium.BackColor = "#F0F0F0";
        this.P_SerumPotassium.ReadOnly = true;
        this.P_SerumPotassium.Name = "P_SerumPotassium";
        this.P_SerumPotassium.TabIndex = 39;

        this.P_Ht = new TTVisual.TTTextBox();
        this.P_Ht.BackColor = "#F0F0F0";
        this.P_Ht.ReadOnly = true;
        this.P_Ht.Name = "P_Ht";
        this.P_Ht.TabIndex = 39;

        this.P_Age = new TTVisual.TTTextBox();
        this.P_Age.BackColor = "#F0F0F0";
        this.P_Age.ReadOnly = true;
        this.P_Age.Name = "P_Age";
        this.P_Age.TabIndex = 39;

        this.P_MeanBloodPressure = new TTVisual.TTTextBox();
        this.P_MeanBloodPressure.BackColor = "#F0F0F0";
        this.P_MeanBloodPressure.ReadOnly = true;
        this.P_MeanBloodPressure.Name = "P_MeanBloodPressure";
        this.P_MeanBloodPressure.TabIndex = 39;

        this.P_FIO2Over = new TTVisual.TTTextBox();
        this.P_FIO2Over.BackColor = "#F0F0F0";
        this.P_FIO2Over.ReadOnly = true;
        this.P_FIO2Over.Name = "P_FIO2Over";
        this.P_FIO2Over.TabIndex = 39;

        this.P_ArterialpH = new TTVisual.TTTextBox();
        this.P_ArterialpH.BackColor = "#F0F0F0";
        this.P_ArterialpH.ReadOnly = true;
        this.P_ArterialpH.Name = "P_ArterialpH";
        this.P_ArterialpH.TabIndex = 39;

        this.P_SerumCreatinineYesFailure = new TTVisual.TTTextBox();
        this.P_SerumCreatinineYesFailure.BackColor = "#F0F0F0";
        this.P_SerumCreatinineYesFailure.ReadOnly = true;
        this.P_SerumCreatinineYesFailure.Name = "P_SerumCreatinineYesFailure";
        this.P_SerumCreatinineYesFailure.TabIndex = 39;

        this.P_WBC = new TTVisual.TTTextBox();
        this.P_WBC.BackColor = "#F0F0F0";
        this.P_WBC.ReadOnly = true;
        this.P_WBC.Name = "P_WBC";
        this.P_WBC.TabIndex = 39;

        this.P_HeartRate = new TTVisual.TTTextBox();
        this.P_HeartRate.BackColor = "#F0F0F0";
        this.P_HeartRate.ReadOnly = true;
        this.P_HeartRate.Name = "P_HeartRate";
        this.P_HeartRate.TabIndex = 39;

        this.P_FIO2Under = new TTVisual.TTTextBox();
        this.P_FIO2Under.BackColor = "#F0F0F0";
        this.P_FIO2Under.ReadOnly = true;
        this.P_FIO2Under.Name = "P_FIO2Under";
        this.P_FIO2Under.TabIndex = 39;

        this.P_SerumSodium = new TTVisual.TTTextBox();
        this.P_SerumSodium.BackColor = "#F0F0F0";
        this.P_SerumSodium.ReadOnly = true;
        this.P_SerumSodium.Name = "P_SerumSodium";
        this.P_SerumSodium.TabIndex = 39;

        this.P_SerumCreatinineNoFailure = new TTVisual.TTTextBox();
        this.P_SerumCreatinineNoFailure.BackColor = "#F0F0F0";
        this.P_SerumCreatinineNoFailure.ReadOnly = true;
        this.P_SerumCreatinineNoFailure.Name = "P_SerumCreatinineNoFailure";
        this.P_SerumCreatinineNoFailure.TabIndex = 39;

        this.P_GlasgowComaScale = new TTVisual.TTTextBox();
        this.P_GlasgowComaScale.BackColor = "#F0F0F0";
        this.P_GlasgowComaScale.ReadOnly = true;
        this.P_GlasgowComaScale.Name = "P_GlasgowComaScale";
        this.P_GlasgowComaScale.TabIndex = 39;

        this.P_ChronicOrganFailure = new TTVisual.TTTextBox();
        this.P_ChronicOrganFailure.BackColor = "#F0F0F0";
        this.P_ChronicOrganFailure.ReadOnly = true;
        this.P_ChronicOrganFailure.Name = "P_ChronicOrganFailure";
        this.P_ChronicOrganFailure.TabIndex = 39;

        this.labelApacheIITotal = new TTVisual.TTLabel();
        this.labelApacheIITotal.Text = "Apache II";
        this.labelApacheIITotal.Name = "labelApacheIITotal";
        this.labelApacheIITotal.TabIndex = 33;

        this.labelChronicOrganFailure = new TTVisual.TTLabel();
        this.labelChronicOrganFailure.Text = "Kronik Organ Yetmezilği";
        this.labelChronicOrganFailure.Name = "labelChronicOrganFailure";
        this.labelChronicOrganFailure.TabIndex = 31;

        this.ChronicOrganFailure = new TTVisual.TTEnumComboBox();
        this.ChronicOrganFailure.DataTypeName = "ApacheChronicOrganFailureEnum";
        this.ChronicOrganFailure.SortBy = SortByEnum.Value;
        this.ChronicOrganFailure.Name = "ChronicOrganFailure";
        this.ChronicOrganFailure.TabIndex = 30;

        this.labelAge = new TTVisual.TTLabel();
        this.labelAge.Text = "Yaş";
        this.labelAge.Name = "labelAge";
        this.labelAge.TabIndex = 29;

        this.Age = new TTVisual.TTEnumComboBox();
        this.Age.DataTypeName = "ApacheAgeEnum";
        this.Age.SortBy = SortByEnum.Value;
        this.Age.Name = "Age";
        this.Age.TabIndex = 28;

        this.labelGlasgowComaScale = new TTVisual.TTLabel();
        this.labelGlasgowComaScale.Text = "Glasgow Koma Skore";
        this.labelGlasgowComaScale.Name = "labelGlasgowComaScale";
        this.labelGlasgowComaScale.TabIndex = 27;

        this.GlasgowComaScale = new TTVisual.TTEnumComboBox();
        this.GlasgowComaScale.DataTypeName = "ApacheGlasgowComaScaleEnum";
        this.GlasgowComaScale.SortBy = SortByEnum.Value;
        this.GlasgowComaScale.Name = "GlasgowComaScale";
        this.GlasgowComaScale.TabIndex = 26;

        this.labelWBC = new TTVisual.TTLabel();
        this.labelWBC.Text = "W.B.C (x103/ mm3 )";
        this.labelWBC.Name = "labelWBC";
        this.labelWBC.TabIndex = 25;

        this.WBC = new TTVisual.TTEnumComboBox();
        this.WBC.DataTypeName = "ApacheWBCEnum";
        this.WBC.SortBy = SortByEnum.Value;
        this.WBC.Name = "WBC";
        this.WBC.TabIndex = 24;

        this.labelHt = new TTVisual.TTLabel();
        this.labelHt.Text = "Ht";
        this.labelHt.Name = "labelHt";
        this.labelHt.TabIndex = 23;

        this.Ht = new TTVisual.TTEnumComboBox();
        this.Ht.DataTypeName = "ApacheHtEnum";
        this.Ht.SortBy = SortByEnum.Value;
        this.Ht.Name = "Ht";
        this.Ht.TabIndex = 22;

        this.labelSerumPotassium = new TTVisual.TTLabel();
        this.labelSerumPotassium.Text = "Serum Potasyum (mmol/L)";
        this.labelSerumPotassium.Name = "labelSerumPotassium";
        this.labelSerumPotassium.TabIndex = 19;

        this.SerumPotassium = new TTVisual.TTEnumComboBox();
        this.SerumPotassium.DataTypeName = "ApacheSerumPotassiumEnum";
        this.SerumPotassium.SortBy = SortByEnum.Value;
        this.SerumPotassium.Name = "SerumPotassium";
        this.SerumPotassium.TabIndex = 18;

        this.labelSerumSodium = new TTVisual.TTLabel();
        this.labelSerumSodium.Text = "Serum Sodyum (mmol/L)";
        this.labelSerumSodium.Name = "labelSerumSodium";
        this.labelSerumSodium.TabIndex = 17;

        this.SerumSodium = new TTVisual.TTEnumComboBox();
        this.SerumSodium.DataTypeName = "ApacheSerumSodiumEnum";
        this.SerumSodium.SortBy = SortByEnum.Value;
        this.SerumSodium.Name = "SerumSodium";
        this.SerumSodium.TabIndex = 16;

        this.labelArterialpH = new TTVisual.TTLabel();
        this.labelArterialpH.Text = "Arterial pH";
        this.labelArterialpH.Name = "labelArterialpH";
        this.labelArterialpH.TabIndex = 15;

        this.ArterialpH = new TTVisual.TTEnumComboBox();
        this.ArterialpH.DataTypeName = "ApacheArterialpHEnum";
        this.ArterialpH.SortBy = SortByEnum.Value;
        this.ArterialpH.Name = "ArterialpH";
        this.ArterialpH.TabIndex = 14;

        this.labelNoAKG = new TTVisual.TTLabel();
        this.labelNoAKG.Text = "AKG yok ise";
        this.labelNoAKG.Name = "labelNoAKG";
        this.labelNoAKG.TabIndex = 13;

        this.NoAKG = new TTVisual.TTEnumComboBox();
        this.NoAKG.DataTypeName = "ApacheNoAKGEnum";
        this.NoAKG.SortBy = SortByEnum.Value;
        this.NoAKG.Name = "NoAKG";
        this.NoAKG.TabIndex = 12;

        this.labelFIO2Under = new TTVisual.TTLabel();
        this.labelFIO2Under.Text = "FIO2 < 0,5 ise PaO2";
        this.labelFIO2Under.Name = "labelFIO2Under";
        this.labelFIO2Under.TabIndex = 11;

        this.FIO2Under = new TTVisual.TTEnumComboBox();
        this.FIO2Under.DataTypeName = "ApacheFIO2UnderEnum";
        this.FIO2Under.SortBy = SortByEnum.Value;
        this.FIO2Under.Name = "FIO2Under";
        this.FIO2Under.TabIndex = 10;

        this.labelFIO2Over = new TTVisual.TTLabel();
        this.labelFIO2Over.Text = "FIO2 >= 0,5 ise (A-a) O2";
        this.labelFIO2Over.Name = "labelFIO2Over";
        this.labelFIO2Over.TabIndex = 9;

        this.FIO2Over = new TTVisual.TTEnumComboBox();
        this.FIO2Over.DataTypeName = "ApacheFIO2OverEnum";
        this.FIO2Over.SortBy = SortByEnum.Value;
        this.FIO2Over.Name = "FIO2Over";
        this.FIO2Over.TabIndex = 8;

        this.labelBreathRate = new TTVisual.TTLabel();
        this.labelBreathRate.Text = "Solunum Hızı";
        this.labelBreathRate.Name = "labelBreathRate";
        this.labelBreathRate.TabIndex = 7;

        this.BreathRate = new TTVisual.TTEnumComboBox();
        this.BreathRate.DataTypeName = "ApacheBreathRateEnum";
        this.BreathRate.SortBy = SortByEnum.Value;
        this.BreathRate.Name = "BreathRate";
        this.BreathRate.TabIndex = 6;

        this.labelHeartRate = new TTVisual.TTLabel();
        this.labelHeartRate.Text = "Kalp Hızı";
        this.labelHeartRate.Name = "labelHeartRate";
        this.labelHeartRate.TabIndex = 5;

        this.HeartRate = new TTVisual.TTEnumComboBox();
        this.HeartRate.DataTypeName = "ApacheHeartRateEnum";
        this.HeartRate.SortBy = SortByEnum.Value;
        this.HeartRate.Name = "HeartRate";
        this.HeartRate.TabIndex = 4;

        this.labelMeanBloodPressure = new TTVisual.TTLabel();
        this.labelMeanBloodPressure.Text = "Ortalama Kan Basıncı";
        this.labelMeanBloodPressure.Name = "labelMeanBloodPressure";
        this.labelMeanBloodPressure.TabIndex = 3;

        this.MeanBloodPressure = new TTVisual.TTEnumComboBox();
        this.MeanBloodPressure.DataTypeName = "ApacheMeanBloodPressureEnum";
        this.MeanBloodPressure.SortBy = SortByEnum.Value;
        this.MeanBloodPressure.Name = "MeanBloodPressure";
        this.MeanBloodPressure.TabIndex = 2;

        this.labelBodyTemperature = new TTVisual.TTLabel();
        this.labelBodyTemperature.Text = "Vücut Isısı";
        this.labelBodyTemperature.Name = "labelBodyTemperature";
        this.labelBodyTemperature.TabIndex = 1;

        this.BodyTemperature = new TTVisual.TTEnumComboBox();
        this.BodyTemperature.DataTypeName = "ApacheBodyTemperatureEnum";
        this.BodyTemperature.SortBy = SortByEnum.Value;
        this.BodyTemperature.Name = "BodyTemperature";
        this.BodyTemperature.TabIndex = 0;

        this.Controls = [this.labelPaO2, this.PaO2, this.PaCO2, this.FIO2, this.ExpectedMortalityRate, this.ApacheIITotal, this.P_BodyTemperature, this.P_BreathRate, this.P_NoAKG, this.P_SerumPotassium, this.P_Ht, this.P_Age, this.P_MeanBloodPressure, this.P_FIO2Over, this.P_ArterialpH, this.P_SerumCreatinineYesFailure, this.P_WBC, this.P_HeartRate, this.P_FIO2Under, this.P_SerumSodium, this.P_SerumCreatinineNoFailure, this.P_GlasgowComaScale, this.P_ChronicOrganFailure, this.labelPaCO2, this.labelFIO2, this.labelSerumCreatinineNoFailure, this.SerumCreatinineNoFailure, this.labelSerumCreatinineYesFailure, this.SerumCreatinineYesFailure, this.labelEntryDate, this.EntryDate, this.labelExpectedMortalityRate, this.labelApacheIITotal, this.labelChronicOrganFailure, this.ChronicOrganFailure, this.labelAge, this.Age, this.labelGlasgowComaScale, this.GlasgowComaScale, this.labelWBC, this.WBC, this.labelHt, this.Ht, this.labelSerumPotassium, this.SerumPotassium, this.labelSerumSodium, this.SerumSodium, this.labelArterialpH, this.ArterialpH, this.labelNoAKG, this.NoAKG, this.labelFIO2Under, this.FIO2Under, this.labelFIO2Over, this.FIO2Over, this.labelBreathRate, this.BreathRate, this.labelHeartRate, this.HeartRate, this.labelMeanBloodPressure, this.MeanBloodPressure, this.labelBodyTemperature, this.BodyTemperature];

    }


}
