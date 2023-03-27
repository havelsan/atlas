//$45930D84
import { Component, OnInit, NgZone  } from '@angular/core';
import { NursingNutritionalRiskAssessmentFormViewModel } from './NursingNutritionalRiskAssessmentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { NursingNutritionalRiskAssessment, NutritionIntakeAssessmentEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from "app/NebulaClient/Mscorlib/GuidParam";
import { ArrayParam } from 'app/NebulaClient/Mscorlib/ArrayParam';
import { StringParam } from 'app/NebulaClient/Mscorlib/QueryParam';
import Integer from 'app/NebulaClient/System/Integer';


@Component({
    selector: 'NursingNutritionalRiskAssessmentForm',
    templateUrl: './NursingNutritionalRiskAssessmentForm.html',
    providers: [MessageService]
})
export class NursingNutritionalRiskAssessmentForm extends BaseNursingDataEntryForm implements OnInit {
    ApplicationDate: TTVisual.ITTDateTimePicker;
    BMI: TTVisual.ITTCheckBox;
    DiseaseLevelHigh: TTVisual.ITTCheckBox;
    DiseaseLevelLow: TTVisual.ITTCheckBox;
    DiseaseLevelMedium: TTVisual.ITTCheckBox;
    DiseaseLevelNormal: TTVisual.ITTCheckBox;
    labelApplicationDate: TTVisual.ITTLabel;
    labelNutritionIntake: TTVisual.ITTLabel;
    labelTotalScore: TTVisual.ITTLabel;
    NutritionIntake: TTVisual.ITTEnumComboBox;
    SevereDiseaseInfo: TTVisual.ITTCheckBox;
    ThreeMonthWeightLoss: TTVisual.ITTCheckBox;
    TotalScore: TTVisual.ITTTextBox;
    ttpanel1: TTVisual.ITTPanel;
    WeeklyIntakeDecrease: TTVisual.ITTCheckBox;
    hidePanel = true;
    BMIValue: any;
    printButtonVisible: boolean = false;
    public nursingNutritionalRiskAssessmentFormViewModel: NursingNutritionalRiskAssessmentFormViewModel = new NursingNutritionalRiskAssessmentFormViewModel();
    public get _NursingNutritionalRiskAssessment(): NursingNutritionalRiskAssessment {
        return this._TTObject as NursingNutritionalRiskAssessment;
    }
    private NursingNutritionalRiskAssessmentForm_DocumentUrl: string = '/api/NursingNutritionalRiskAssessmentService/NursingNutritionalRiskAssessmentForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone, protected reportService: AtlasReportService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NursingNutritionalRiskAssessmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NursingNutritionalRiskAssessment();
        this.nursingNutritionalRiskAssessmentFormViewModel = new NursingNutritionalRiskAssessmentFormViewModel();
        this._ViewModel = this.nursingNutritionalRiskAssessmentFormViewModel;
        this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment = this._TTObject as NursingNutritionalRiskAssessment;
    }

    protected loadViewModel() {
        let that = this;
        that.nursingNutritionalRiskAssessmentFormViewModel = this._ViewModel as NursingNutritionalRiskAssessmentFormViewModel;
        that._TTObject = this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment;
        if (this.nursingNutritionalRiskAssessmentFormViewModel == null)
            this.nursingNutritionalRiskAssessmentFormViewModel = new NursingNutritionalRiskAssessmentFormViewModel();
        if (this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment == null)
            this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment = new NursingNutritionalRiskAssessment();
        if (this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore == undefined) {
            this.initTotalScore();
        }
        if (this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.BMI || this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.ThreeMonthWeightLoss || this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.WeeklyIntakeDecrease || this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.SevereDiseaseInfo) {
            this.hidePanel = false;
        }
        else {
            this.hidePanel = true;
            this.initTotalScore();
        }
        this.calculateBMI();
        if (!this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.IsNew)
            this.printButtonVisible = true;
    }

    printReport() {
        let objectList = null;
        let objects = [];
     //   const TTOBJECTID = new GuidParam(this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.ObjectID);
        objects.push(new StringParam(this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.ObjectID.toString()));
        objectList = new ArrayParam (objects);
        let reportParameters: any = { 'Objects': objectList};
        this.reportService.showReport('NursingNTReport', reportParameters);
    }
    
    public printAllReports () {   
        let objectList = null;
        let objects = [];

        if(this.nursingNutritionalRiskAssessmentFormViewModel.NursingAppProgressSummaryInfoList != undefined)
        {
             this.nursingNutritionalRiskAssessmentFormViewModel.NursingAppProgressSummaryInfoList.forEach((formElement) => {
                objects.push (new StringParam(formElement.ObjectID.toString()));
        });
        }
        
       
       objectList = new ArrayParam (objects);
        let reportparameters: any = {'Objects': objectList};
        this.reportService.showReport('NursingNTReport', reportparameters);
      /*  this.nursingNutritionalRiskAssessmentFormViewModel.NursingAppProgressSummaryInfoList.forEach((formElement) => {
            const TTOBJECTID = new GuidParam(formElement.ObjectID);
            let reportParameters: any = { 'TTOBJECTID': TTOBJECTID};
            this.reportService.showReport('NursingNTReport', reportParameters);
        });*/
    }

    

    initTotalScore() {
        if (this.nursingNutritionalRiskAssessmentFormViewModel.PatientAge > 70)
            this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore = 1;
        else
            this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore = 0;
    }

    async ngOnInit() {
        await this.load();
    }

    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionalRiskAssessment != null && this._NursingNutritionalRiskAssessment.ApplicationDate != event) {
                this._NursingNutritionalRiskAssessment.ApplicationDate = event;
            }
        }
    }

    public onBMIChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionalRiskAssessment != null && this._NursingNutritionalRiskAssessment.BMI != event) {
                this._NursingNutritionalRiskAssessment.BMI = event;

                if (this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.BMI || this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.ThreeMonthWeightLoss || this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.WeeklyIntakeDecrease || this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.SevereDiseaseInfo) {
                    this.hidePanel = false;
                }
                else {
                    this.hidePanel = true;
                    this.initTotalScore();
                }
            }
        }
    }

    public onDiseaseLevelHighChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionalRiskAssessment != null && this._NursingNutritionalRiskAssessment.DiseaseLevelHigh != event) {
                this._NursingNutritionalRiskAssessment.DiseaseLevelHigh = event;

                if (event)
                    this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore += 3;
                else
                    this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore -= 3;
            }
        }
    }

    public onDiseaseLevelLowChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionalRiskAssessment != null && this._NursingNutritionalRiskAssessment.DiseaseLevelLow != event) {
                this._NursingNutritionalRiskAssessment.DiseaseLevelLow = event;

                if (event)
                    this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore += 1;
                else
                    this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore -= 1;
            }
        }
    }

    public onDiseaseLevelMediumChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionalRiskAssessment != null && this._NursingNutritionalRiskAssessment.DiseaseLevelMedium != event) {
                this._NursingNutritionalRiskAssessment.DiseaseLevelMedium = event;

                if (event)
                    this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore += 2;
                else
                    this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore -= 2;
            }
        }
    }

    public onDiseaseLevelNormalChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionalRiskAssessment != null && this._NursingNutritionalRiskAssessment.DiseaseLevelNormal != event) {
                this._NursingNutritionalRiskAssessment.DiseaseLevelNormal = event;

                if (event)
                    this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore += 0;
                else
                    this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore -= 0;
            }
        }
    }

    public onHeightChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionalRiskAssessment != null && this._NursingNutritionalRiskAssessment.Height != event) {
                this._NursingNutritionalRiskAssessment.Height = event;
                this.calculateBMI();
            }
        }
    }

    public onWeightChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionalRiskAssessment != null && this._NursingNutritionalRiskAssessment.Weight != event) {
                this._NursingNutritionalRiskAssessment.Weight = event;
                this.calculateBMI();
            }
        }
    }

    calculateBMI() {
        if (this._NursingNutritionalRiskAssessment.Height != undefined && this._NursingNutritionalRiskAssessment.Weight != undefined) {
            let weight = this._NursingNutritionalRiskAssessment.Weight;
            let height = this._NursingNutritionalRiskAssessment.Height;
            this.BMIValue = weight / ((height / 100) ** 2);

            if (this.BMIValue < 20.5) {
                this.BMIValue = this.BMIValue.toFixed(2);
                this.onBMIChanged(true);
            }
            else {
                this.BMIValue = this.BMIValue.toFixed(2);
                this.onBMIChanged(false);
            }
        }
    }

    public onNutritionIntakeChanged(event): void {
        if (event != null) {
            let oldValue = this._NursingNutritionalRiskAssessment.NutritionIntake;
            if (this._NursingNutritionalRiskAssessment != null && this._NursingNutritionalRiskAssessment.NutritionIntake != event) {
                this._NursingNutritionalRiskAssessment.NutritionIntake = event;
                if (oldValue == NutritionIntakeAssessmentEnum._ThreeMonths.code)
                    this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore -= 1;
                else if (oldValue == NutritionIntakeAssessmentEnum._TwoMonths.code)
                    this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore -= 2;
                else if (oldValue == NutritionIntakeAssessmentEnum._OneMonth.code)
                    this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore -= 3;

                if (event == NutritionIntakeAssessmentEnum._ThreeMonths.code)
                    this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore += 1;
                else if (event == NutritionIntakeAssessmentEnum._TwoMonths.code)
                    this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore += 2;
                else if (event == NutritionIntakeAssessmentEnum._OneMonth.code)
                    this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.TotalScore += 3;
            }
        }
    }

    public onSevereDiseaseInfoChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionalRiskAssessment != null && this._NursingNutritionalRiskAssessment.SevereDiseaseInfo != event) {
                this._NursingNutritionalRiskAssessment.SevereDiseaseInfo = event;

                if (this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.BMI || this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.ThreeMonthWeightLoss || this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.WeeklyIntakeDecrease || this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.SevereDiseaseInfo) {
                    this.hidePanel = false;
                }
                else {
                    this.hidePanel = true;
                    this.initTotalScore();
                }
            }
        }
    }

    public onThreeMonthWeightLossChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionalRiskAssessment != null && this._NursingNutritionalRiskAssessment.ThreeMonthWeightLoss != event) {
                this._NursingNutritionalRiskAssessment.ThreeMonthWeightLoss = event;

                if (this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.BMI || this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.ThreeMonthWeightLoss || this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.WeeklyIntakeDecrease || this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.SevereDiseaseInfo) {
                    this.hidePanel = false;
                }
                else {
                    this.hidePanel = true;
                    this.initTotalScore();
                }
            }
        }
    }

    public onTotalScoreChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionalRiskAssessment != null && this._NursingNutritionalRiskAssessment.TotalScore != event) {
                this._NursingNutritionalRiskAssessment.TotalScore = event;
            }
        }
    }

    public onWeeklyIntakeDecreaseChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionalRiskAssessment != null && this._NursingNutritionalRiskAssessment.WeeklyIntakeDecrease != event) {
                this._NursingNutritionalRiskAssessment.WeeklyIntakeDecrease = event;

                if (this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.BMI || this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.ThreeMonthWeightLoss || this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.WeeklyIntakeDecrease || this.nursingNutritionalRiskAssessmentFormViewModel._NursingNutritionalRiskAssessment.SevereDiseaseInfo) {
                    this.hidePanel = false;
                }
                else {
                    this.hidePanel = true;
                    this.initTotalScore();
                }
            }
        }
    }

    
  
    protected redirectProperties(): void {
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
        redirectProperty(this.BMI, "Value", this.__ttObject, "BMI");
        redirectProperty(this.ThreeMonthWeightLoss, "Value", this.__ttObject, "ThreeMonthWeightLoss");
        redirectProperty(this.WeeklyIntakeDecrease, "Value", this.__ttObject, "WeeklyIntakeDecrease");
        redirectProperty(this.SevereDiseaseInfo, "Value", this.__ttObject, "SevereDiseaseInfo");
        redirectProperty(this.TotalScore, "Text", this.__ttObject, "TotalScore");
        redirectProperty(this.DiseaseLevelNormal, "Value", this.__ttObject, "DiseaseLevelNormal");
        redirectProperty(this.NutritionIntake, "Value", this.__ttObject, "NutritionIntake");
        redirectProperty(this.DiseaseLevelLow, "Value", this.__ttObject, "DiseaseLevelLow");
        redirectProperty(this.DiseaseLevelMedium, "Value", this.__ttObject, "DiseaseLevelMedium");
        redirectProperty(this.DiseaseLevelHigh, "Value", this.__ttObject, "DiseaseLevelHigh");
    }

    public initFormControls(): void {
        this.ttpanel1 = new TTVisual.TTPanel();
        this.ttpanel1.AutoSize = true;
        this.ttpanel1.Name = "ttpanel1";
        this.ttpanel1.TabIndex = 8;

        this.DiseaseLevelHigh = new TTVisual.TTCheckBox();
        this.DiseaseLevelHigh.Value = false;
        this.DiseaseLevelHigh.Title = "Kafa travması, kemik iliği transplantasyonu, Yoğun Bakım hastaları (APACHE > 10)";
        this.DiseaseLevelHigh.Name = "DiseaseLevelHigh";
        this.DiseaseLevelHigh.TabIndex = 5;

        this.DiseaseLevelMedium = new TTVisual.TTCheckBox();
        this.DiseaseLevelMedium.Value = false;
        this.DiseaseLevelMedium.Title = "Majör abdominal cerrahi, İnme, Şiddetli Pnömoni, Hematolojik Malignite";
        this.DiseaseLevelMedium.Name = "DiseaseLevelMedium";
        this.DiseaseLevelMedium.TabIndex = 4;

        this.DiseaseLevelLow = new TTVisual.TTCheckBox();
        this.DiseaseLevelLow.Value = false;
        this.DiseaseLevelLow.Title = "Kalça fraktürü, Özellikle akut komplikasyonları olan kronik hastalar: Siroz, KOAH, Kronik Hemodiyaliz, Diyabet, Onkoloji";
        this.DiseaseLevelLow.Name = "DiseaseLevelLow";
        this.DiseaseLevelLow.TabIndex = 3;

        this.DiseaseLevelNormal = new TTVisual.TTCheckBox();
        this.DiseaseLevelNormal.Value = false;
        this.DiseaseLevelNormal.Title = i18n("M19459", "Normal besin gereksinimi");
        this.DiseaseLevelNormal.Name = "DiseaseLevelNormal";
        this.DiseaseLevelNormal.TabIndex = 2;

        this.labelNutritionIntake = new TTVisual.TTLabel();
        this.labelNutritionIntake.Text = i18n("M11765", "Beslenme Durumundaki Bozulma");
        this.labelNutritionIntake.Name = "labelNutritionIntake";
        this.labelNutritionIntake.TabIndex = 1;

        this.NutritionIntake = new TTVisual.TTEnumComboBox();
        this.NutritionIntake.DataTypeName = "";
        this.NutritionIntake.Name = "NutritionIntake";
        this.NutritionIntake.TabIndex = 0;

        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = i18n("M23772", "Uygulama Zamanı");
        this.labelApplicationDate.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 7;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 6;

        this.labelTotalScore = new TTVisual.TTLabel();
        this.labelTotalScore.Text = i18n("M23521", "Toplam Skor");
        this.labelTotalScore.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelTotalScore.Name = "labelTotalScore";
        this.labelTotalScore.TabIndex = 5;

        this.TotalScore = new TTVisual.TTTextBox();
        this.TotalScore.Name = "TotalScore";
        this.TotalScore.TabIndex = 4;
        this.TotalScore.ReadOnly = true;

        this.SevereDiseaseInfo = new TTVisual.TTCheckBox();
        this.SevereDiseaseInfo.Value = false;
        this.SevereDiseaseInfo.Title = i18n("M27726", "Hasta ileri derecede hasta mı? (Örneğin yoğun bakımda mı?)");
        this.SevereDiseaseInfo.Name = "SevereDiseaseInfo";
        this.SevereDiseaseInfo.TabIndex = 3;

        this.WeeklyIntakeDecrease = new TTVisual.TTCheckBox();
        this.WeeklyIntakeDecrease.Value = false;
        this.WeeklyIntakeDecrease.Title = i18n("M14593", "Geçen Hafta Gıda Alımında Azalma Oldu Mu?");
        this.WeeklyIntakeDecrease.Name = "WeeklyIntakeDecrease";
        this.WeeklyIntakeDecrease.TabIndex = 2;

        this.ThreeMonthWeightLoss = new TTVisual.TTCheckBox();
        this.ThreeMonthWeightLoss.Value = false;
        this.ThreeMonthWeightLoss.Title = i18n("M15299", "Hasta son 3 ayda kilo kaybetti mi?");
        this.ThreeMonthWeightLoss.Name = "ThreeMonthWeightLoss";
        this.ThreeMonthWeightLoss.TabIndex = 1;

        this.BMI = new TTVisual.TTCheckBox();
        this.BMI.Value = false;
        this.BMI.Title = i18n("M24198", "Vücut Kitle İndeksi (VKİ) < 20,5 kg/m2 mi?");
        this.BMI.Name = "BMI";
        this.BMI.TabIndex = 0;

        this.ttpanel1.Controls = [this.DiseaseLevelHigh, this.DiseaseLevelMedium, this.DiseaseLevelLow, this.DiseaseLevelNormal, this.labelNutritionIntake, this.NutritionIntake];
        this.Controls = [this.ttpanel1, this.DiseaseLevelHigh, this.DiseaseLevelMedium, this.DiseaseLevelLow, this.DiseaseLevelNormal, this.labelNutritionIntake, this.NutritionIntake, this.labelApplicationDate, this.ApplicationDate, this.labelTotalScore, this.TotalScore, this.SevereDiseaseInfo, this.WeeklyIntakeDecrease, this.ThreeMonthWeightLoss, this.BMI];
       
    }


}
