//$1374A0FB
import { Component, ViewChild, OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { NewBornIntensiveCareFormViewModel, Age, NewBornIntensiveCareComponentInfoViewModel } from './NewBornIntensiveCareFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { NewBornIntensiveCare, IntensiveCareSpecialityObj } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { InputFormat } from 'NebulaClient/Utils/Enums/InputFormat';

import { Convert } from '../../../wwwroot/app/NebulaClient/Mscorlib/Convert';
import { Guid } from '../../../wwwroot/app/NebulaClient/Mscorlib/Guid';
import { QueryParams } from '../../../wwwroot/app/QueryList/Models/QueryParams';
import { GuidParam } from '../../../wwwroot/app/NebulaClient/Mscorlib/GuidParam';
import { DynamicComponentInfo } from '../../../wwwroot/app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from '../../../wwwroot/app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from '../../../wwwroot/app/Fw/Models/ParameterDefinitionModel';

@Component({
    selector: 'NewBornIntensiveCareForm',
    templateUrl: './NewBornIntensiveCareForm.html',
    providers: [MessageService]
})
export class NewBornIntensiveCareForm extends TTVisual.TTForm implements OnInit {
    BirthDatePerson: TTVisual.ITTDateTimePicker;
    BirthTime: TTVisual.ITTDateTimePicker;
    BirthWeight: TTVisual.ITTTextBox;
    ChestCircumference: TTVisual.ITTTextBox;
    ChronicalAge: TTVisual.ITTTextBox;
    CorrectedAge: TTVisual.ITTTextBox;
    GestationalDay: TTVisual.ITTTextBox;
    GestationalWeek: TTVisual.ITTTextBox;
    HeadCircumference: TTVisual.ITTTextBox;
    IntensiveCareDay: TTVisual.ITTTextBox;
    labelBirthDatePerson: TTVisual.ITTLabel;
    labelBirthTime: TTVisual.ITTLabel;
    labelBirthWeight: TTVisual.ITTLabel;
    labelChestCircumference: TTVisual.ITTLabel;
    labelChronicalAge: TTVisual.ITTLabel;
    labelCorrectedAge: TTVisual.ITTLabel;
    labelGestationalDay: TTVisual.ITTLabel;
    labelGestationalWeek: TTVisual.ITTLabel;
    labelHeadCircumference: TTVisual.ITTLabel;
    labelIntensiveCareDay: TTVisual.ITTLabel;
    labelLength: TTVisual.ITTLabel;
    Length: TTVisual.ITTTextBox;
    tabApgar: TTVisual.ITTTabPage;
    tabBallard: TTVisual.ITTTabPage;
    tabBloodPressure: TTVisual.ITTTabPage;
    tabClinical: TTVisual.ITTTabPage;
    tabGeneralInfo: TTVisual.ITTTabPage;
    tabPhototherapy: TTVisual.ITTTabPage;
    tabSnappe: TTVisual.ITTTabPage;
    tabWeightChart: TTVisual.ITTTabPage;
    tttabcontrol1: TTVisual.ITTTabControl;
    public newBornIntensiveCareFormViewModel: NewBornIntensiveCareFormViewModel = new NewBornIntensiveCareFormViewModel();
    public get _NewBornIntensiveCare(): NewBornIntensiveCare {
        return this._TTObject as NewBornIntensiveCare;
    }
    private NewBornIntensiveCareForm_DocumentUrl: string = '/api/NewBornIntensiveCareService/NewBornIntensiveCareForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('NEWBORNINTENSIVECARE', 'NewBornIntensiveCareForm');
        this._DocumentServiceUrl = this.NewBornIntensiveCareForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PreScript(): Promise<void> {
        super.PreScript();
        if (this._intensiveCareSpeciality != null) {
            this.newBornIntensiveCareFormViewModel._NewBornIntensiveCare.IntensiveCareSpecialityObj = this._intensiveCareSpeciality;
        }
        if (this.newBornIntensiveCareFormViewModel._NewBornIntensiveCare.Patient != null && this.newBornIntensiveCareFormViewModel._NewBornIntensiveCare.Patient.BirthDate != null) {
            this.newBornIntensiveCareFormViewModel._NewBornIntensiveCare.ChronicalAge = this.GetChronologicalAge(this.newBornIntensiveCareFormViewModel._NewBornIntensiveCare.Patient.BirthDate);
        }
    }

    public _intensiveCareSpeciality: IntensiveCareSpecialityObj;
    //public setInputParam(value: string) {
    //    if (value != null) {
    //        this.newBornIntensiveCareFormViewModel.intensiveCareSpecialityObjId = value;
    //        this.newBornIntensiveCareFormViewModel._NewBornIntensiveCare.IntensiveCareSpecialityObj;
    //    }
    //}

    public static newBornIntensiveCareQueryResultLoaded(e: any) {

        let columns = e as Array<any>;
        for (let column of columns) {
            if (column.dataField === "OBJECTID") {
                column.caption = "Obje";
            }
        }
    }

    public static getComponentInfoViewModel(intensiveCareSpecialityObj: IntensiveCareSpecialityObj, newbornIntensiveObjectId: string): NewBornIntensiveCareComponentInfoViewModel {
        let componentInfoViewModel = new NewBornIntensiveCareComponentInfoViewModel();
        let queryParameters = new QueryParams();
        queryParameters.ObjectDefID = new Guid('d7eb5879-8ccd-4576-b46b-1b2cea89f549');
        queryParameters.QueryDefID = new Guid('dcb21c82-181e-4fd7-81ac-e5887cd81283');//GetNewBornIntensiveCare
        let parameters = {};
        parameters['INTENSIVECARESPECIALITYOBJ'] = new GuidParam(intensiveCareSpecialityObj.ObjectID);
        queryParameters.Parameters = parameters;
        componentInfoViewModel.NewBornIntensiveCareQueryParameters = queryParameters;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'NewBornIntensiveCareForm';
        componentInfo.ModuleName = "YogunBakimModule";
        componentInfo.ModulePath = '/Modules/Tibbi_Surec/Yogun_Bakim_Modulu/YogunBakimModule';
        if (typeof (intensiveCareSpecialityObj.PhysicianApplication) == "string") {
            componentInfo.InputParam = new DynamicComponentInputParam(intensiveCareSpecialityObj, new ActiveIDsModel(intensiveCareSpecialityObj.PhysicianApplication, null, null));
        } else {
            componentInfo.InputParam = new DynamicComponentInputParam(intensiveCareSpecialityObj, new ActiveIDsModel(intensiveCareSpecialityObj.PhysicianApplication.ObjectID, null, null));
        }
        if (newbornIntensiveObjectId != null && newbornIntensiveObjectId != "") {
            componentInfo.objectID = newbornIntensiveObjectId;
        }
        componentInfoViewModel.NewBornIntensiveCareComponentInfo = componentInfo;
        return componentInfoViewModel;
    }

    public CalculateAge(birthDate: Date): Age {
        let age = new Age();
        let today: Date = new Date();
        let months = today.getMonth() - birthDate.getMonth();
        let years = today.getFullYear() - birthDate.getFullYear();

        if (today.getDate() < birthDate.getDate()) {
            months--;
        }
        if (months < 0) {
            years--;
            months += 12;
        }
        let calculatedBirthDate = (Convert.ToDateTime(birthDate));
        calculatedBirthDate.setMonth(calculatedBirthDate.getMonth() + ((12 * years) + months));

        let days: number = Math.floor((today.getTime() - calculatedBirthDate.getTime()) / (1000 * 3600 * 24));

        age.Years = years;
        age.Months = months;
        age.Days = days;

        return age;
    }

    public GetChronologicalAge(birthDate: Date): string {
        let age: Age = this.CalculateAge(birthDate);
        let chronologicalAge: string = "";
        if (age.Years > 0) {
            chronologicalAge = chronologicalAge + age.Years.toString();
            chronologicalAge = chronologicalAge + i18n("M24661", " Yıl ");
        }
        if (age.Months > 0) {
            chronologicalAge = chronologicalAge + age.Months.toString();
            chronologicalAge = chronologicalAge + i18n("M11273", " Ay ");
        }
        if (age.Days > 7) {
            let week: number = Math.floor(age.Days / 7);
            let day: number = age.Days % 7;

            chronologicalAge = chronologicalAge + week.toString();
            chronologicalAge = chronologicalAge + i18n("M15059", " Hafta ");

            chronologicalAge = chronologicalAge + day.toString();
            chronologicalAge = chronologicalAge + i18n("M14998", " Gün ");
        }
        else {
            chronologicalAge = chronologicalAge + age.Days.toString();
            chronologicalAge = chronologicalAge + i18n("M14998", " Gün");
        }
        return chronologicalAge;
    }

    public GetCorrectedAge(gestationalWeek: number, gestationalDay: number, birthDate: Date): string {
        let correctedAgeStr: string = "";
        let today: Date = new Date();

        let gestationalAge: number = Convert.ToInt32(gestationalDay) + Convert.ToInt32(gestationalWeek * 7);
        let chronologicalAge: number = Math.floor((today.getTime() - birthDate.getTime()) / (1000 * 3600 * 24));
        let correctedAge: number = Convert.ToInt32(gestationalAge) + Convert.ToInt32(chronologicalAge) - 280;
        let week: number = Math.floor(correctedAge / 7);
        let day: number = correctedAge % 7;

        if (correctedAge < 0) {
            correctedAge = correctedAge * (-1);
            correctedAgeStr = correctedAgeStr + " - ";
        }
        if (correctedAge > 7) {

            correctedAgeStr = correctedAgeStr + week.toString();
            correctedAgeStr = correctedAgeStr + i18n("M15059", " Hafta ");
            correctedAgeStr = correctedAgeStr + day.toString();
            correctedAgeStr = correctedAgeStr + i18n("M14998", " Gün");

        }
        else {
            correctedAgeStr = correctedAgeStr + day.toString();
            correctedAgeStr = correctedAgeStr + i18n("M14998", " Gün");
        }
        return correctedAgeStr;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NewBornIntensiveCare();
        this.newBornIntensiveCareFormViewModel = new NewBornIntensiveCareFormViewModel();
        this._ViewModel = this.newBornIntensiveCareFormViewModel;
        this.newBornIntensiveCareFormViewModel._NewBornIntensiveCare = this._TTObject as NewBornIntensiveCare;
        this.newBornIntensiveCareFormViewModel._NewBornIntensiveCare.Patient = new Patient();
    }

    protected loadViewModel() {
        let that = this;
        that.newBornIntensiveCareFormViewModel = this._ViewModel as NewBornIntensiveCareFormViewModel;
        that._TTObject = this.newBornIntensiveCareFormViewModel._NewBornIntensiveCare;
        if (this.newBornIntensiveCareFormViewModel == null)
            this.newBornIntensiveCareFormViewModel = new NewBornIntensiveCareFormViewModel();
        if (this.newBornIntensiveCareFormViewModel._NewBornIntensiveCare == null)
            this.newBornIntensiveCareFormViewModel._NewBornIntensiveCare = new NewBornIntensiveCare();
        let patientObjectID = that.newBornIntensiveCareFormViewModel._NewBornIntensiveCare["Patient"];
        if (patientObjectID != null && (typeof patientObjectID === "string")) {
            let patient = that.newBornIntensiveCareFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
            if (patient) {
                that.newBornIntensiveCareFormViewModel._NewBornIntensiveCare.Patient = patient;
            }
        }

    }


    async ngOnInit() {
        await this.load();
    }

    public onBirthDatePersonChanged(event): void {
        if (event != null) {
            if (this._NewBornIntensiveCare != null &&
                this._NewBornIntensiveCare.Patient != null && this._NewBornIntensiveCare.Patient.BirthDate != event) {
                this._NewBornIntensiveCare.Patient.BirthDate = event;

                this._NewBornIntensiveCare.ChronicalAge = this.GetChronologicalAge(event);
                if (this._NewBornIntensiveCare.GestationalWeek && this._NewBornIntensiveCare.GestationalDay) {
                    this._NewBornIntensiveCare.CorrectedAge = this.GetCorrectedAge(this._NewBornIntensiveCare.GestationalWeek, this._NewBornIntensiveCare.GestationalDay, this._NewBornIntensiveCare.Patient.BirthDate);
                } else if (this._NewBornIntensiveCare.GestationalWeek) {
                    this._NewBornIntensiveCare.CorrectedAge = this.GetCorrectedAge(this._NewBornIntensiveCare.GestationalWeek, 0, this._NewBornIntensiveCare.Patient.BirthDate);
                } else if (this._NewBornIntensiveCare.GestationalDay) {
                    this._NewBornIntensiveCare.CorrectedAge = this.GetCorrectedAge(0, this._NewBornIntensiveCare.GestationalDay, this._NewBornIntensiveCare.Patient.BirthDate);
                }
            }
        }
    }

    public onBirthTimeChanged(event): void {
        if (this._NewBornIntensiveCare != null && this._NewBornIntensiveCare.BirthTime != event.value) {
            this._NewBornIntensiveCare.BirthTime = event.value;
        }
    }

    public onBirthWeightChanged(event): void {
        if (this._NewBornIntensiveCare != null && this._NewBornIntensiveCare.BirthWeight != event) {
            this._NewBornIntensiveCare.BirthWeight = event;
        }
    }

    public onChestCircumferenceChanged(event): void {
        if (this._NewBornIntensiveCare != null && this._NewBornIntensiveCare.ChestCircumference != event) {
            this._NewBornIntensiveCare.ChestCircumference = event;
        }
    }

    public onChronicalAgeChanged(event): void {
        if (this._NewBornIntensiveCare != null && this._NewBornIntensiveCare.ChronicalAge != event) {
            this._NewBornIntensiveCare.ChronicalAge = event;
        }
    }

    public onCorrectedAgeChanged(event): void {
        if (this._NewBornIntensiveCare != null && this._NewBornIntensiveCare.CorrectedAge != event) {
            this._NewBornIntensiveCare.CorrectedAge = event;
        }
    }

    public onGestationalDayChanged(event): void {
        if (event != null) {
            if (this._NewBornIntensiveCare != null && this._NewBornIntensiveCare.GestationalDay != event) {
                this._NewBornIntensiveCare.GestationalDay = event;
                if (this._NewBornIntensiveCare.GestationalWeek && this._NewBornIntensiveCare.Patient.BirthDate) {
                    this._NewBornIntensiveCare.CorrectedAge = this.GetCorrectedAge(this._NewBornIntensiveCare.GestationalWeek, this._NewBornIntensiveCare.GestationalDay, this._NewBornIntensiveCare.Patient.BirthDate);
                } else if (this._NewBornIntensiveCare.Patient.BirthDate) {
                    this._NewBornIntensiveCare.CorrectedAge = this.GetCorrectedAge(0, this._NewBornIntensiveCare.GestationalDay, this._NewBornIntensiveCare.Patient.BirthDate);
                }
            }
        }
    }

    public onGestationalWeekChanged(event): void {
        if (event != null) {
            if (this._NewBornIntensiveCare != null && this._NewBornIntensiveCare.GestationalWeek != event) {
                this._NewBornIntensiveCare.GestationalWeek = event;
                if (this._NewBornIntensiveCare.GestationalDay && this._NewBornIntensiveCare.Patient.BirthDate) {
                    this._NewBornIntensiveCare.CorrectedAge = this.GetCorrectedAge(this._NewBornIntensiveCare.GestationalWeek, this._NewBornIntensiveCare.GestationalDay, this._NewBornIntensiveCare.Patient.BirthDate);
                } else if (this._NewBornIntensiveCare.Patient.BirthDate) {
                    this._NewBornIntensiveCare.CorrectedAge = this.GetCorrectedAge(this._NewBornIntensiveCare.GestationalWeek, 0, this._NewBornIntensiveCare.Patient.BirthDate);
                }
            }
        }
    }

    public onHeadCircumferenceChanged(event): void {
        if (this._NewBornIntensiveCare != null && this._NewBornIntensiveCare.HeadCircumference != event) {
            this._NewBornIntensiveCare.HeadCircumference = event;
        }
    }

    public onIntensiveCareDayChanged(event): void {
        if (this._NewBornIntensiveCare != null && this._NewBornIntensiveCare.IntensiveCareDay != event) {
            this._NewBornIntensiveCare.IntensiveCareDay = event;
        }
    }

    public onLengthChanged(event): void {
        if (this._NewBornIntensiveCare != null && this._NewBornIntensiveCare.Length != event) {
            this._NewBornIntensiveCare.Length = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.GestationalWeek, "Text", this.__ttObject, "GestationalWeek");
        redirectProperty(this.GestationalDay, "Text", this.__ttObject, "GestationalDay");
        redirectProperty(this.BirthWeight, "Text", this.__ttObject, "BirthWeight");
        redirectProperty(this.HeadCircumference, "Text", this.__ttObject, "HeadCircumference");
        redirectProperty(this.ChronicalAge, "Text", this.__ttObject, "ChronicalAge");
        redirectProperty(this.CorrectedAge, "Text", this.__ttObject, "CorrectedAge");
        redirectProperty(this.Length, "Text", this.__ttObject, "Length");
        redirectProperty(this.ChestCircumference, "Text", this.__ttObject, "ChestCircumference");
        redirectProperty(this.IntensiveCareDay, "Text", this.__ttObject, "IntensiveCareDay");
        redirectProperty(this.BirthTime, "Value", this.__ttObject, "BirthTime");
        redirectProperty(this.BirthDatePerson, "Value", this.__ttObject, "Patient.BirthDate");
    }

    public initFormControls(): void {
        this.labelBirthDatePerson = new TTVisual.TTLabel();
        this.labelBirthDatePerson.Text = "Doğum Tarihi";
        this.labelBirthDatePerson.Name = "labelBirthDatePerson";
        this.labelBirthDatePerson.TabIndex = 24;

        this.BirthDatePerson = new TTVisual.TTDateTimePicker();
        this.BirthDatePerson.Format = DateTimePickerFormat.Long;
        this.BirthDatePerson.Name = "BirthDatePerson";
        this.BirthDatePerson.TabIndex = 23;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 22;

        this.tabApgar = new TTVisual.TTTabPage();
        this.tabApgar.DisplayIndex = 0;
        this.tabApgar.TabIndex = 0;
        this.tabApgar.Text = "Apgar";
        this.tabApgar.Name = "tabApgar";

        this.tabBallard = new TTVisual.TTTabPage();
        this.tabBallard.DisplayIndex = 1;
        this.tabBallard.TabIndex = 1;
        this.tabBallard.Text = "Ballard";
        this.tabBallard.Name = "tabBallard";

        this.tabSnappe = new TTVisual.TTTabPage();
        this.tabSnappe.DisplayIndex = 2;
        this.tabSnappe.TabIndex = 2;
        this.tabSnappe.Text = "Snappe II";
        this.tabSnappe.Name = "tabSnappe";

        this.tabWeightChart = new TTVisual.TTTabPage();
        this.tabWeightChart.DisplayIndex = 3;
        this.tabWeightChart.TabIndex = 3;
        this.tabWeightChart.Text = "Kilo Takip Çizelgesi";
        this.tabWeightChart.Name = "tabWeightChart";

        this.tabBloodPressure = new TTVisual.TTTabPage();
        this.tabBloodPressure.DisplayIndex = 4;
        this.tabBloodPressure.TabIndex = 4;
        this.tabBloodPressure.Text = "Tansiyon Ölçümleri";
        this.tabBloodPressure.Name = "tabBloodPressure";

        this.tabPhototherapy = new TTVisual.TTTabPage();
        this.tabPhototherapy.DisplayIndex = 5;
        this.tabPhototherapy.TabIndex = 5;
        this.tabPhototherapy.Text = "Fototerapi ve Bilirubin Düzeyleri";
        this.tabPhototherapy.Name = "tabPhototherapy";

        this.tabClinical = new TTVisual.TTTabPage();
        this.tabClinical.DisplayIndex = 6;
        this.tabClinical.TabIndex = 6;
        this.tabClinical.Text = "Klinik Gözlem";
        this.tabClinical.Name = "tabClinical";

        this.tabGeneralInfo = new TTVisual.TTTabPage();
        this.tabGeneralInfo.DisplayIndex = 7;
        this.tabGeneralInfo.TabIndex = 7;
        this.tabGeneralInfo.Text = "Genel Bilgiler";
        this.tabGeneralInfo.Name = "tabGeneralInfo";

        this.Length = new TTVisual.TTTextBox();
        this.Length.InputFormat = InputFormat.AlphaOnly;
        this.Length.Name = "Length";
        this.Length.TabIndex = 20;

        this.IntensiveCareDay = new TTVisual.TTTextBox();
        this.IntensiveCareDay.Name = "IntensiveCareDay";
        this.IntensiveCareDay.TabIndex = 18;

        this.HeadCircumference = new TTVisual.TTTextBox();
        this.HeadCircumference.InputFormat = InputFormat.AlphaOnly;
        this.HeadCircumference.Name = "HeadCircumference";
        this.HeadCircumference.TabIndex = 16;

        this.GestationalWeek = new TTVisual.TTTextBox();
        this.GestationalWeek.InputFormat = InputFormat.AlphaOnly;
        this.GestationalWeek.Name = "GestationalWeek";
        this.GestationalWeek.TabIndex = 14;

        this.GestationalDay = new TTVisual.TTTextBox();
        this.GestationalDay.InputFormat = InputFormat.AlphaOnly;
        this.GestationalDay.Name = "GestationalDay";
        this.GestationalDay.TabIndex = 12;

        this.CorrectedAge = new TTVisual.TTTextBox();
        this.CorrectedAge.Name = "CorrectedAge";
        this.CorrectedAge.TabIndex = 8;

        this.ChronicalAge = new TTVisual.TTTextBox();
        this.ChronicalAge.Name = "ChronicalAge";
        this.ChronicalAge.TabIndex = 6;

        this.ChestCircumference = new TTVisual.TTTextBox();
        this.ChestCircumference.InputFormat = InputFormat.AlphaOnly;
        this.ChestCircumference.Name = "ChestCircumference";
        this.ChestCircumference.TabIndex = 4;

        this.BirthWeight = new TTVisual.TTTextBox();
        this.BirthWeight.InputFormat = InputFormat.AlphaOnly;
        this.BirthWeight.Name = "BirthWeight";
        this.BirthWeight.TabIndex = 2;

        this.labelLength = new TTVisual.TTLabel();
        this.labelLength.Text = "Boy";
        this.labelLength.Name = "labelLength";
        this.labelLength.TabIndex = 21;

        this.labelIntensiveCareDay = new TTVisual.TTLabel();
        this.labelIntensiveCareDay.Text = "Yoğun Bakım Günü";
        this.labelIntensiveCareDay.Name = "labelIntensiveCareDay";
        this.labelIntensiveCareDay.TabIndex = 19;

        this.labelHeadCircumference = new TTVisual.TTLabel();
        this.labelHeadCircumference.Text = "Baş Çevresi";
        this.labelHeadCircumference.Name = "labelHeadCircumference";
        this.labelHeadCircumference.TabIndex = 17;

        this.labelGestationalWeek = new TTVisual.TTLabel();
        this.labelGestationalWeek.Text = "Gestasyon Haftası";
        this.labelGestationalWeek.Name = "labelGestationalWeek";
        this.labelGestationalWeek.TabIndex = 15;

        this.labelGestationalDay = new TTVisual.TTLabel();
        this.labelGestationalDay.Text = "Gestasyon Günü";
        this.labelGestationalDay.Name = "labelGestationalDay";
        this.labelGestationalDay.TabIndex = 13;

        this.labelCorrectedAge = new TTVisual.TTLabel();
        this.labelCorrectedAge.Text = "Düzeltilmiş Yaş";
        this.labelCorrectedAge.Name = "labelCorrectedAge";
        this.labelCorrectedAge.TabIndex = 9;

        this.labelChronicalAge = new TTVisual.TTLabel();
        this.labelChronicalAge.Text = "Kronolojik Yaş";
        this.labelChronicalAge.Name = "labelChronicalAge";
        this.labelChronicalAge.TabIndex = 7;

        this.labelChestCircumference = new TTVisual.TTLabel();
        this.labelChestCircumference.Text = "Göğüs Çevresi";
        this.labelChestCircumference.Name = "labelChestCircumference";
        this.labelChestCircumference.TabIndex = 5;

        this.labelBirthWeight = new TTVisual.TTLabel();
        this.labelBirthWeight.Text = "Doğum Ağırlığı";
        this.labelBirthWeight.Name = "labelBirthWeight";
        this.labelBirthWeight.TabIndex = 3;

        this.labelBirthTime = new TTVisual.TTLabel();
        this.labelBirthTime.Text = "Doğum Saati";
        this.labelBirthTime.Name = "labelBirthTime";
        this.labelBirthTime.TabIndex = 1;

        this.BirthTime = new TTVisual.TTDateTimePicker();
        this.BirthTime.Format = DateTimePickerFormat.Long;
        this.BirthTime.Name = "BirthTime";
        this.BirthTime.TabIndex = 0;

        this.tttabcontrol1.Controls = [this.tabApgar, this.tabBallard, this.tabSnappe, this.tabWeightChart, this.tabBloodPressure, this.tabPhototherapy, this.tabClinical, this.tabGeneralInfo];
        this.Controls = [this.labelBirthDatePerson, this.BirthDatePerson, this.tttabcontrol1, this.tabApgar, this.tabBallard, this.tabSnappe, this.tabWeightChart, this.tabBloodPressure, this.tabPhototherapy, this.tabClinical, this.tabGeneralInfo, this.Length, this.IntensiveCareDay, this.HeadCircumference, this.GestationalWeek, this.GestationalDay, this.CorrectedAge, this.ChronicalAge, this.ChestCircumference, this.BirthWeight, this.labelLength, this.labelIntensiveCareDay, this.labelHeadCircumference, this.labelGestationalWeek, this.labelGestationalDay, this.labelCorrectedAge, this.labelChronicalAge, this.labelChestCircumference, this.labelBirthWeight, this.labelBirthTime, this.BirthTime];

    }


}
