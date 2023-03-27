//$F4F1D41B
import { Component, OnInit } from '@angular/core';
import { BabyInformationFormViewModel } from './BabyInformationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BabyObstetricInformation } from 'NebulaClient/Model/AtlasClientModel';
import { Apgar } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBebekOlumNedenleri } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCinsiyet } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDogumSirasi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDogumunGerceklestigiYer } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDogumYontemi } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { FormSaveInfo } from 'NebulaClient/Mscorlib/FormSaveInfo';
import { RegularObstetric, Patient, BirthReportBabyStatus } from 'NebulaClient/Model/AtlasClientModel';
import { ObjectContextService } from "Fw/Services/ObjectContextService";
import { Guid } from 'NebulaClient/Mscorlib/Guid';

@Component({
    selector: 'BabyInformationForm',
    templateUrl: './BabyInformationForm.html',
    providers: [MessageService]
})
export class BabyInformationForm extends TTVisual.TTForm implements OnInit {
    AbnormalBaby: TTVisual.ITTCheckBox;
    AnesthesiaTechnique: TTVisual.ITTEnumComboBox;
    Asphyxia: TTVisual.ITTCheckBox;
    BabyProblems: TTVisual.ITTTextBox;
    BabyStatus: TTVisual.ITTEnumComboBox;
    BirthDateTime: TTVisual.ITTDateTimePicker;
    BirthLocation: TTVisual.ITTObjectListBox;
    BirthOrder: TTVisual.ITTObjectListBox;
    BirthType: TTVisual.ITTObjectListBox;
    CauseOfDeath: TTVisual.ITTObjectListBox;
    DatetimeOfDeath: TTVisual.ITTDateTimePicker;
    FatherName: TTVisual.ITTTextBox;
    FetalAnomalies: TTVisual.ITTEnumComboBox;
    FontanelExamination: TTVisual.ITTCheckBox;
    Gender: TTVisual.ITTObjectListBox;
    HeadCircumference: TTVisual.ITTTextBox;
    HearingScreening: TTVisual.ITTCheckBox;
    HeartRateApgar1: TTVisual.ITTEnumComboBox;
    HeartRateApgar5: TTVisual.ITTEnumComboBox;
    Height: TTVisual.ITTTextBox;
    HepatitisB: TTVisual.ITTCheckBox;
    HepatitisImmunoglobulin: TTVisual.ITTCheckBox;
    HypothyroidisBlood: TTVisual.ITTCheckBox;
    IronSupplement: TTVisual.ITTCheckBox;
    labelAnesthesiaTechnique: TTVisual.ITTLabel;
    labelBabyProblems: TTVisual.ITTLabel;
    labelBabyStatus: TTVisual.ITTLabel;
    labelBirthDateTime: TTVisual.ITTLabel;
    labelBirthLocation: TTVisual.ITTLabel;
    labelBirthOrder: TTVisual.ITTLabel;
    labelBirthType: TTVisual.ITTLabel;
    labelCauseOfDeath: TTVisual.ITTLabel;
    labelDatetimeOfDeath: TTVisual.ITTLabel;
    labelFatherName: TTVisual.ITTLabel;
    labelFetalAnomalies: TTVisual.ITTLabel;
    labelGender: TTVisual.ITTLabel;
    labelHeadCircumference: TTVisual.ITTLabel;
    labelHeartRateApgar1: TTVisual.ITTLabel;
    labelHeartRateApgar5: TTVisual.ITTLabel;
    labelHeight: TTVisual.ITTLabel;
    labelMuscularTonusApgar1: TTVisual.ITTLabel;
    labelMuscularTonusApgar5: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelPlacentaDecollementType: TTVisual.ITTLabel;
    labelPregnancyWeek: TTVisual.ITTLabel;
    labelPresentationType: TTVisual.ITTLabel;
    labelRespirationApgar1: TTVisual.ITTLabel;
    labelRespirationApgar5: TTVisual.ITTLabel;
    labelSkinColorApgar1: TTVisual.ITTLabel;
    labelSkinColorApgar5: TTVisual.ITTLabel;
    labelStimulusResponseApgar1: TTVisual.ITTLabel;
    labelStimulusResponseApgar5: TTVisual.ITTLabel;
    labelSurname: TTVisual.ITTLabel;
    labelTotalScoreApgar1: TTVisual.ITTLabel;
    labelTotalScoreApgar5: TTVisual.ITTLabel;
    labelWeigth: TTVisual.ITTLabel;
    labelWristbandNumber: TTVisual.ITTLabel;
    LactationInfo: TTVisual.ITTCheckBox;
    MuscularTonusApgar1: TTVisual.ITTEnumComboBox;
    MuscularTonusApgar5: TTVisual.ITTEnumComboBox;
    Name: TTVisual.ITTTextBox;
    PhenylketonuriaBlood: TTVisual.ITTCheckBox;
    PlacentaDecollementType: TTVisual.ITTEnumComboBox;
    PregnancyWeek: TTVisual.ITTTextBox;
    PrematureBaby: TTVisual.ITTCheckBox;
    PresentationType: TTVisual.ITTEnumComboBox;
    RespirationApgar1: TTVisual.ITTEnumComboBox;
    RespirationApgar5: TTVisual.ITTEnumComboBox;
    ShowLCD: TTVisual.ITTCheckBox;
    SkinColorApgar1: TTVisual.ITTEnumComboBox;
    SkinColorApgar5: TTVisual.ITTEnumComboBox;
    StimulusResponseApgar1: TTVisual.ITTEnumComboBox;
    StimulusResponseApgar5: TTVisual.ITTEnumComboBox;
    SuckledTheFirstHalfHour: TTVisual.ITTCheckBox;
    Surname: TTVisual.ITTTextBox;
    TesticleExamination: TTVisual.ITTCheckBox;
    TotalScoreApgar1: TTVisual.ITTTextBox;
    TotalScoreApgar5: TTVisual.ITTTextBox;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttgroupbox2: TTVisual.ITTGroupBox;
    VisionScreening: TTVisual.ITTCheckBox;
    VitaminDSupplement: TTVisual.ITTCheckBox;
    VitaminKApplied: TTVisual.ITTCheckBox;
    Weigth: TTVisual.ITTTextBox;
    WithoutBreastMilk: TTVisual.ITTCheckBox;
    WristbandNumber: TTVisual.ITTTextBox;
    public babyInformationFormViewModel: BabyInformationFormViewModel = new BabyInformationFormViewModel();

    public babyProblemsControl: boolean = false;

    public get _BabyObstetricInformation(): BabyObstetricInformation {
        return this._TTObject as BabyObstetricInformation;
    }
    private BabyInformationForm_DocumentUrl: string = '/api/BabyObstetricInformationService/BabyInformationForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected objectContextService: ObjectContextService) {
        super('BABYOBSTETRICINFORMATION', 'BabyInformationForm');
        this._DocumentServiceUrl = this.BabyInformationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    _data: RegularObstetric;
    public _saveButtonCaption: string = 'Ekle';
    public setInputParam(value: any) {
        if (value != null && value != undefined) {
            this._data = value as RegularObstetric;
            this.babyInformationFormViewModel._RegularObstetric = this._data;
        }

        if (value != null && value['isSelectBabyInfo'] != null && value['isSelectBabyInfo'] == true) {
            this._saveButtonCaption = 'Güncelle';
        }
    }
    public IsBabyAlive: boolean = true;
    protected async PreScript(): Promise<void> {
        super.PreScript();
        if (this._data != null && this._data.Patient != null && this.babyInformationFormViewModel._BabyObstetricInformation.Surname == null) {
            let _patient: any = this._data.Patient;
            if ((typeof _patient) === 'string') {
                _patient = await this.objectContextService.getObjectWithDefName<Patient>(new Guid(_patient as string), 'Patient') as Patient;

            }
            this.babyInformationFormViewModel._BabyObstetricInformation.Surname = _patient.Surname;
        }

        if (this.babyInformationFormViewModel._BabyObstetricInformation.BabyStatus == BirthReportBabyStatus.Alive) {
            this.IsBabyAlive = true;
            this.BabyStatusAlive();
        } else {
            this.IsBabyAlive = false;
            this.BabyStatusDead();
        }
    }

    public CalculateApgar1TotalScore() {//Apgar Skoru 1. Dakika
        let total = 0;
        if (this._BabyObstetricInformation.Apgar1.MuscularTonus != null)
            total = total + this._BabyObstetricInformation.Apgar1.MuscularTonus;
        if (this._BabyObstetricInformation.Apgar1.HeartRate != null)
            total = total + this._BabyObstetricInformation.Apgar1.HeartRate;
        if (this._BabyObstetricInformation.Apgar1.StimulusResponse != null)
            total = total + this._BabyObstetricInformation.Apgar1.StimulusResponse;
        if (this._BabyObstetricInformation.Apgar1.SkinColor != null)
            total = total + this._BabyObstetricInformation.Apgar1.SkinColor;
        if (this._BabyObstetricInformation.Apgar1.Respiration != null)
            total = total + this._BabyObstetricInformation.Apgar1.Respiration;
        this._BabyObstetricInformation.Apgar1.TotalScore = total;
    }
    public CalculateApgar5TotalScore() {//Apgar Skoru 5. Dakika
        let total = 0;
        if (this._BabyObstetricInformation.Apgar5.MuscularTonus != null)
            total = total + this._BabyObstetricInformation.Apgar5.MuscularTonus;
        if (this._BabyObstetricInformation.Apgar5.HeartRate != null)
            total = total + this._BabyObstetricInformation.Apgar5.HeartRate;
        if (this._BabyObstetricInformation.Apgar5.StimulusResponse != null)
            total = total + this._BabyObstetricInformation.Apgar5.StimulusResponse;
        if (this._BabyObstetricInformation.Apgar5.SkinColor != null)
            total = total + this._BabyObstetricInformation.Apgar5.SkinColor;
        if (this._BabyObstetricInformation.Apgar5.Respiration != null)
            total = total + this._BabyObstetricInformation.Apgar5.Respiration;
        this._BabyObstetricInformation.Apgar5.TotalScore = total;
    }

    protected async save(saveInfo?: FormSaveInfo) {
        try {
            if (this.IsBabyAlive == true && (//yaşayan bebek zorunlu alanları dolu değil ise exception ver.
                this._BabyObstetricInformation.Surname == null ||
                this._BabyObstetricInformation.HeadCircumference == null ||
                this._BabyObstetricInformation.Weigth == null ||
                this._BabyObstetricInformation.Gender == null ||
                this._BabyObstetricInformation.PresentationType == null ||
                //this._BabyObstetricInformation.AnesthesiaTechnique == null ||
                this._BabyObstetricInformation.BirthType == null ||
                this._BabyObstetricInformation.PlacentaDecollementType == null
            )) {

                let message = (this._BabyObstetricInformation.Surname == null ? ("'" + this.labelSurname.Text + "'") : "") +
                    (this._BabyObstetricInformation.HeadCircumference == null ? ("'" + this.labelHeadCircumference.Text + "'") : "") +
                    (this._BabyObstetricInformation.Weigth == null ? ("'" + this.labelWeigth.Text + "'") : "") +
                    (this._BabyObstetricInformation.Gender == null ? ("'" + this.labelGender.Text + "'") : "") +
                    (this._BabyObstetricInformation.PresentationType == null ? ("'" + this.labelPresentationType.Text + "'") : "") +
                    //(this._BabyObstetricInformation.AnesthesiaTechnique == null ? ("'" + this.labelAnesthesiaTechnique.Text + "'") : "") +
                    (this._BabyObstetricInformation.BirthType == null ? ("'" + this.labelBirthType.Text + "'") : "") +
                    (this._BabyObstetricInformation.PlacentaDecollementType == null ? ("'" + this.labelPlacentaDecollementType.Text + "'") : "") + " alanı boş geçilemez!";
                throw message;

            } else if (this.IsBabyAlive == false && (//ölü bebek zorunlu alanları dolu değil ise exception ver.
                this._BabyObstetricInformation.CauseOfDeath == null ||
                this._BabyObstetricInformation.DatetimeOfDeath == null)) {

                let message = (this._BabyObstetricInformation.CauseOfDeath == null ? ("'" + this.labelCauseOfDeath.Text + "'") : "") +
                    (this._BabyObstetricInformation.DatetimeOfDeath == null ? ("'" + this.labelDatetimeOfDeath.Text + "'") : "") + " alanı boş geçilemez!";
                throw message;
            } else {

                if (this.IsBabyAlive == true) {
                    //ölü bebek alanları boşaltılıyor.
                    this._BabyObstetricInformation.CauseOfDeath = null;
                    this._BabyObstetricInformation.DatetimeOfDeath = null;
                } else {
                    this._BabyObstetricInformation.HeadCircumference = null;
                    this._BabyObstetricInformation.Weigth = null;
                    this._BabyObstetricInformation.Gender = null;
                    this._BabyObstetricInformation.PresentationType = null;
                    this._BabyObstetricInformation.AnesthesiaTechnique = null;
                    this._BabyObstetricInformation.BirthType = null;
                    this._BabyObstetricInformation.PlacentaDecollementType = null;
                }

                this.ActionExecuted.emit(this.babyInformationFormViewModel);
            }
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
            this.ActionFailed.emit(err);
            throw err;
        }
    }

    public cancelForm() {
        this.ActionExecuted.emit({ Cancelled: true });
    }

    public BabyStatusAlive() {//Canlı Bebek Zorunlu Alanlar
        this.CauseOfDeath.Required = false;
        this.DatetimeOfDeath.Required = false;

        this.HeadCircumference.Required = true;
        this.Weigth.Required = true;
        this.Gender.Required = true;
        this.PresentationType.Required = true;
        //this.AnesthesiaTechnique.Required = true;
        this.BirthType.Required = true;
        this.PlacentaDecollementType.Required = true;
    }

    public BabyStatusDead() {//Ölü Bebek Zorunlu Alanlar
        this.CauseOfDeath.Required = true;
        this.DatetimeOfDeath.Required = true;

        this.HeadCircumference.Required = false;
        this.Weigth.Required = false;
        this.Gender.Required = false;
        this.PresentationType.Required = false;
        this.AnesthesiaTechnique.Required = false;
        this.BirthType.Required = false;
        this.PlacentaDecollementType.Required = false;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BabyObstetricInformation();
        this.babyInformationFormViewModel = new BabyInformationFormViewModel();
        this._ViewModel = this.babyInformationFormViewModel;
        this.babyInformationFormViewModel._BabyObstetricInformation = this._TTObject as BabyObstetricInformation;
        this.babyInformationFormViewModel._BabyObstetricInformation.Apgar5 = new Apgar();
        this.babyInformationFormViewModel._BabyObstetricInformation.Apgar1 = new Apgar();
        this.babyInformationFormViewModel._BabyObstetricInformation.Gender = new SKRSCinsiyet();
        this.babyInformationFormViewModel._BabyObstetricInformation.BirthType = new SKRSDogumYontemi();
        this.babyInformationFormViewModel._BabyObstetricInformation.BirthOrder = new SKRSDogumSirasi();
        this.babyInformationFormViewModel._BabyObstetricInformation.BirthLocation = new SKRSDogumunGerceklestigiYer();
        this.babyInformationFormViewModel._BabyObstetricInformation.CauseOfDeath = new SKRSBebekOlumNedenleri();
    }

    protected loadViewModel() {
        let that = this;
        that.babyInformationFormViewModel = this._ViewModel as BabyInformationFormViewModel;
        that._TTObject = this.babyInformationFormViewModel._BabyObstetricInformation;
        if (this.babyInformationFormViewModel == null)
            this.babyInformationFormViewModel = new BabyInformationFormViewModel();
        if (this.babyInformationFormViewModel._BabyObstetricInformation == null)
            this.babyInformationFormViewModel._BabyObstetricInformation = new BabyObstetricInformation();
        let apgar5ObjectID = that.babyInformationFormViewModel._BabyObstetricInformation["Apgar5"];
        if (apgar5ObjectID != null && (typeof apgar5ObjectID === "string")) {
            let apgar5 = that.babyInformationFormViewModel.Apgars.find(o => o.ObjectID.toString() === apgar5ObjectID.toString());
            if (apgar5) {
                that.babyInformationFormViewModel._BabyObstetricInformation.Apgar5 = apgar5;
            }
        }
        let apgar1ObjectID = that.babyInformationFormViewModel._BabyObstetricInformation["Apgar1"];
        if (apgar1ObjectID != null && (typeof apgar1ObjectID === "string")) {
            let apgar1 = that.babyInformationFormViewModel.Apgars.find(o => o.ObjectID.toString() === apgar1ObjectID.toString());
            if (apgar1) {
                that.babyInformationFormViewModel._BabyObstetricInformation.Apgar1 = apgar1;
            }
        }
        let genderObjectID = that.babyInformationFormViewModel._BabyObstetricInformation["Gender"];
        if (genderObjectID != null && (typeof genderObjectID === "string")) {
            let gender = that.babyInformationFormViewModel.SKRSCinsiyets.find(o => o.ObjectID.toString() === genderObjectID.toString());
            if (gender) {
                that.babyInformationFormViewModel._BabyObstetricInformation.Gender = gender;
            }
        }
        let birthTypeObjectID = that.babyInformationFormViewModel._BabyObstetricInformation["BirthType"];
        if (birthTypeObjectID != null && (typeof birthTypeObjectID === "string")) {
            let birthType = that.babyInformationFormViewModel.SKRSDogumYontemis.find(o => o.ObjectID.toString() === birthTypeObjectID.toString());
            if (birthType) {
                that.babyInformationFormViewModel._BabyObstetricInformation.BirthType = birthType;
            }
        }
        let birthOrderObjectID = that.babyInformationFormViewModel._BabyObstetricInformation["BirthOrder"];
        if (birthOrderObjectID != null && (typeof birthOrderObjectID === "string")) {
            let birthOrder = that.babyInformationFormViewModel.SKRSDogumSirasis.find(o => o.ObjectID.toString() === birthOrderObjectID.toString());
            if (birthOrder) {
                that.babyInformationFormViewModel._BabyObstetricInformation.BirthOrder = birthOrder;
            }
        }
        let birthLocationObjectID = that.babyInformationFormViewModel._BabyObstetricInformation["BirthLocation"];
        if (birthLocationObjectID != null && (typeof birthLocationObjectID === "string")) {
            let birthLocation = that.babyInformationFormViewModel.SKRSDogumunGerceklestigiYers.find(o => o.ObjectID.toString() === birthLocationObjectID.toString());
            if (birthLocation) {
                that.babyInformationFormViewModel._BabyObstetricInformation.BirthLocation = birthLocation;
            }
        }
        let causeOfDeathObjectID = that.babyInformationFormViewModel._BabyObstetricInformation["CauseOfDeath"];
        if (causeOfDeathObjectID != null && (typeof causeOfDeathObjectID === "string")) {
            let causeOfDeath = that.babyInformationFormViewModel.SKRSBebekOlumNedenleris.find(o => o.ObjectID.toString() === causeOfDeathObjectID.toString());
            if (causeOfDeath) {
                that.babyInformationFormViewModel._BabyObstetricInformation.CauseOfDeath = causeOfDeath;
            }
        }

    }

    async ngOnInit() {
        await this.load();
    }

    public onAbnormalBabyChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.AbnormalBaby != event) {
            this._BabyObstetricInformation.AbnormalBaby = event;
        }
    }

    public onAnesthesiaTechniqueChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.AnesthesiaTechnique != event) {
            this._BabyObstetricInformation.AnesthesiaTechnique = event;
        }
    }

    public onAsphyxiaChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.Asphyxia != event) {
            this._BabyObstetricInformation.Asphyxia = event;
        }
    }

    public onBabyProblemsChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.BabyProblems != event) {
            this._BabyObstetricInformation.BabyProblems = event;
        }
    }

    public onBabyStatusChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.BabyStatus != event) {
            this._BabyObstetricInformation.BabyStatus = event;
            if (this._BabyObstetricInformation.BabyStatus == BirthReportBabyStatus.Alive) {
                this.IsBabyAlive = true;
                this.BabyStatusAlive();
            } else {
                this.IsBabyAlive = false;
                this.BabyStatusDead();
            }
        }
    }

    public onBirthDateTimeChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.BirthDateTime != event) {
            this._BabyObstetricInformation.BirthDateTime = event;
        }
    }

    public onBirthLocationChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.BirthLocation != event) {
            this._BabyObstetricInformation.BirthLocation = event;
        }
    }

    public onBirthOrderChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.BirthOrder != event) {
            this._BabyObstetricInformation.BirthOrder = event;
        }
    }

    public onBirthTypeChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.BirthType != event) {
            this._BabyObstetricInformation.BirthType = event;
        }
    }

    public onCauseOfDeathChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.CauseOfDeath != event) {
            this._BabyObstetricInformation.CauseOfDeath = event;
        }
    }

    public onDatetimeOfDeathChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.DatetimeOfDeath != event) {
            this._BabyObstetricInformation.DatetimeOfDeath = event;
        }
    }

    public onFatherNameChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.FatherName != event) {
            this._BabyObstetricInformation.FatherName = event;
        }
    }

    public onFetalAnomaliesChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.FetalAnomalies != event) {
            this._BabyObstetricInformation.FetalAnomalies = event;
        }
    }

    public onFontanelExaminationChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.FontanelExamination != event) {
            this._BabyObstetricInformation.FontanelExamination = event;
        }
    }

    public onGenderChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.Gender != event) {
            this._BabyObstetricInformation.Gender = event;
        }
    }

    public onHeadCircumferenceChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.HeadCircumference != event) {
            this._BabyObstetricInformation.HeadCircumference = event;
        }
    }

    public onHearingScreeningChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.HearingScreening != event) {
            this._BabyObstetricInformation.HearingScreening = event;
        }
    }

    public onHeartRateApgar1Changed(event): void {
        if (this._BabyObstetricInformation != null &&
            this._BabyObstetricInformation.Apgar1 != null /*&& this._BabyObstetricInformation.Apgar1.HeartRate != event*/) {
            this.CalculateApgar1TotalScore();
            this._BabyObstetricInformation.Apgar1.HeartRate = event;
        }
    }

    public onHeartRateApgar5Changed(event): void {
        if (this._BabyObstetricInformation != null &&
            this._BabyObstetricInformation.Apgar5 != null /*&& this._BabyObstetricInformation.Apgar5.HeartRate != event*/) {
            this.CalculateApgar5TotalScore();
            this._BabyObstetricInformation.Apgar5.HeartRate = event;
        }
    }

    public onHeightChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.Height != event) {
            this._BabyObstetricInformation.Height = event;
        }
    }

    public onHepatitisBChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.HepatitisB != event) {
            this._BabyObstetricInformation.HepatitisB = event;
        }
    }

    public onHepatitisImmunoglobulinChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.HepatitisImmunoglobulin != event) {
            this._BabyObstetricInformation.HepatitisImmunoglobulin = event;
        }
    }

    public onHypothyroidisBloodChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.HypothyroidisBlood != event) {
            this._BabyObstetricInformation.HypothyroidisBlood = event;
        }
    }

    public onIronSupplementChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.IronSupplement != event) {
            this._BabyObstetricInformation.IronSupplement = event;
        }
    }

    public onLactationInfoChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.LactationInfo != event) {
            this._BabyObstetricInformation.LactationInfo = event;
        }
    }

    public onMuscularTonusApgar1Changed(event): void {
        if (this._BabyObstetricInformation != null &&
            this._BabyObstetricInformation.Apgar1 != null /*&& this._BabyObstetricInformation.Apgar1.MuscularTonus != event*/) {
            this.CalculateApgar1TotalScore();
            this._BabyObstetricInformation.Apgar1.MuscularTonus = event;
        }
    }

    public onMuscularTonusApgar5Changed(event): void {
        if (this._BabyObstetricInformation != null &&
            this._BabyObstetricInformation.Apgar5 != null /*&& this._BabyObstetricInformation.Apgar5.MuscularTonus != event*/) {
            this.CalculateApgar5TotalScore();
            this._BabyObstetricInformation.Apgar5.MuscularTonus = event;
        }
    }

    public onNameChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.Name != event) {
            this._BabyObstetricInformation.Name = event;
        }
    }

    public onPhenylketonuriaBloodChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.PhenylketonuriaBlood != event) {
            this._BabyObstetricInformation.PhenylketonuriaBlood = event;
        }
    }

    public onPlacentaDecollementTypeChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.PlacentaDecollementType != event) {
            this._BabyObstetricInformation.PlacentaDecollementType = event;
        }
    }

    public onPregnancyWeekChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.PregnancyWeek != event) {
            this._BabyObstetricInformation.PregnancyWeek = event;
        }
    }

    public onPrematureBabyChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.PrematureBaby != event) {
            this._BabyObstetricInformation.PrematureBaby = event;
        }
    }

    public onPresentationTypeChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.PresentationType != event) {
            this._BabyObstetricInformation.PresentationType = event;
        }
    }

    public onRespirationApgar1Changed(event): void {
        if (this._BabyObstetricInformation != null &&
            this._BabyObstetricInformation.Apgar1 != null /*&& this._BabyObstetricInformation.Apgar1.Respiration != event*/) {
            this.CalculateApgar1TotalScore();
            this._BabyObstetricInformation.Apgar1.Respiration = event;
        }
    }

    public onRespirationApgar5Changed(event): void {
        if (this._BabyObstetricInformation != null &&
            this._BabyObstetricInformation.Apgar5 != null /*&& this._BabyObstetricInformation.Apgar5.Respiration != event*/) {
            this.CalculateApgar5TotalScore();
            this._BabyObstetricInformation.Apgar5.Respiration = event;
        }
    }

    public onShowLCDChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.ShowLCD != event) {
            this._BabyObstetricInformation.ShowLCD = event;
        }
    }

    public onSkinColorApgar1Changed(event): void {
        if (this._BabyObstetricInformation != null &&
            this._BabyObstetricInformation.Apgar1 != null /*&& this._BabyObstetricInformation.Apgar1.SkinColor != event*/) {
            this.CalculateApgar1TotalScore();
            this._BabyObstetricInformation.Apgar1.SkinColor = event;
        }
    }

    public onSkinColorApgar5Changed(event): void {
        if (this._BabyObstetricInformation != null &&
            this._BabyObstetricInformation.Apgar5 != null /*&& this._BabyObstetricInformation.Apgar5.SkinColor != event*/) {
            this.CalculateApgar5TotalScore();
            this._BabyObstetricInformation.Apgar5.SkinColor = event;
        }
    }

    public onStimulusResponseApgar1Changed(event): void {
        if (this._BabyObstetricInformation != null &&
            this._BabyObstetricInformation.Apgar1 != null /*&& this._BabyObstetricInformation.Apgar1.StimulusResponse != event*/) {
            this.CalculateApgar1TotalScore();
            this._BabyObstetricInformation.Apgar1.StimulusResponse = event;
        }
    }

    public onStimulusResponseApgar5Changed(event): void {
        if (this._BabyObstetricInformation != null &&
            this._BabyObstetricInformation.Apgar5 != null /*&& this._BabyObstetricInformation.Apgar5.StimulusResponse != event*/) {
            this.CalculateApgar5TotalScore();
            this._BabyObstetricInformation.Apgar5.StimulusResponse = event;
        }
    }

    public onSuckledTheFirstHalfHourChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.SuckledTheFirstHalfHour != event) {
            this._BabyObstetricInformation.SuckledTheFirstHalfHour = event;
        }
    }

    public onSurnameChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.Surname != event) {
            this._BabyObstetricInformation.Surname = event;
        }
    }

    public onTesticleExaminationChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.TesticleExamination != event) {
            this._BabyObstetricInformation.TesticleExamination = event;
        }
    }

    public onTotalScoreApgar1Changed(event): void {
        if (this._BabyObstetricInformation != null &&
            this._BabyObstetricInformation.Apgar1 != null && this._BabyObstetricInformation.Apgar1.TotalScore != event) {
            this._BabyObstetricInformation.Apgar1.TotalScore = event;
        }
    }

    public onTotalScoreApgar5Changed(event): void {
        if (this._BabyObstetricInformation != null &&
            this._BabyObstetricInformation.Apgar5 != null && this._BabyObstetricInformation.Apgar5.TotalScore != event) {
            this._BabyObstetricInformation.Apgar5.TotalScore = event;
        }
    }

    public onVisionScreeningChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.VisionScreening != event) {
            this._BabyObstetricInformation.VisionScreening = event;
        }
    }

    public onVitaminDSupplementChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.VitaminDSupplement != event) {
            this._BabyObstetricInformation.VitaminDSupplement = event;
        }
    }

    public onVitaminKAppliedChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.VitaminKApplied != event) {
            this._BabyObstetricInformation.VitaminKApplied = event;
        }
    }

    public onWeigthChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.Weigth != event) {
            this._BabyObstetricInformation.Weigth = event;
        }
    }

    public onWithoutBreastMilkChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.WithoutBreastMilk != event) {
            this._BabyObstetricInformation.WithoutBreastMilk = event;
        }
    }

    public onWristbandNumberChanged(event): void {
        if (this._BabyObstetricInformation != null && this._BabyObstetricInformation.WristbandNumber != event) {
            this._BabyObstetricInformation.WristbandNumber = event;
        }
    }

    photoCaptured(data) {
        this.babyInformationFormViewModel.PhotoString = data;
    }



    protected redirectProperties(): void {
        redirectProperty(this.BabyStatus, "Value", this.__ttObject, "BabyStatus");
        redirectProperty(this.DatetimeOfDeath, "Value", this.__ttObject, "DatetimeOfDeath");
        redirectProperty(this.FatherName, "Text", this.__ttObject, "FatherName");
        redirectProperty(this.Surname, "Text", this.__ttObject, "Surname");
        redirectProperty(this.HepatitisB, "Value", this.__ttObject, "HepatitisB");
        redirectProperty(this.Asphyxia, "Value", this.__ttObject, "Asphyxia");
        redirectProperty(this.HepatitisImmunoglobulin, "Value", this.__ttObject, "HepatitisImmunoglobulin");
        redirectProperty(this.HypothyroidisBlood, "Value", this.__ttObject, "HypothyroidisBlood");
        redirectProperty(this.LactationInfo, "Value", this.__ttObject, "LactationInfo");
        redirectProperty(this.HearingScreening, "Value", this.__ttObject, "HearingScreening");
        redirectProperty(this.BirthDateTime, "Value", this.__ttObject, "BirthDateTime");
        redirectProperty(this.WithoutBreastMilk, "Value", this.__ttObject, "WithoutBreastMilk");
        redirectProperty(this.VisionScreening, "Value", this.__ttObject, "VisionScreening");
        redirectProperty(this.WristbandNumber, "Text", this.__ttObject, "WristbandNumber");
        redirectProperty(this.Height, "Text", this.__ttObject, "Height");
        redirectProperty(this.Weigth, "Text", this.__ttObject, "Weigth");
        redirectProperty(this.AbnormalBaby, "Value", this.__ttObject, "AbnormalBaby");
        redirectProperty(this.TesticleExamination, "Value", this.__ttObject, "TesticleExamination");
        redirectProperty(this.HeadCircumference, "Text", this.__ttObject, "HeadCircumference");
        redirectProperty(this.FontanelExamination, "Value", this.__ttObject, "FontanelExamination");
        redirectProperty(this.PregnancyWeek, "Text", this.__ttObject, "PregnancyWeek");
        redirectProperty(this.BabyProblems, "Text", this.__ttObject, "BabyProblems");
        redirectProperty(this.Name, "Text", this.__ttObject, "Name");
        redirectProperty(this.HeartRateApgar1, "Value", this.__ttObject, "Apgar1.HeartRate");
        redirectProperty(this.MuscularTonusApgar1, "Value", this.__ttObject, "Apgar1.MuscularTonus");
        redirectProperty(this.RespirationApgar1, "Value", this.__ttObject, "Apgar1.Respiration");
        redirectProperty(this.SkinColorApgar1, "Value", this.__ttObject, "Apgar1.SkinColor");
        redirectProperty(this.StimulusResponseApgar1, "Value", this.__ttObject, "Apgar1.StimulusResponse");
        redirectProperty(this.TotalScoreApgar1, "Text", this.__ttObject, "Apgar1.TotalScore");
        redirectProperty(this.PresentationType, "Value", this.__ttObject, "PresentationType");
        redirectProperty(this.PlacentaDecollementType, "Value", this.__ttObject, "PlacentaDecollementType");
        redirectProperty(this.AnesthesiaTechnique, "Value", this.__ttObject, "AnesthesiaTechnique");
        redirectProperty(this.FetalAnomalies, "Value", this.__ttObject, "FetalAnomalies");
        redirectProperty(this.ShowLCD, "Value", this.__ttObject, "ShowLCD");
        redirectProperty(this.VitaminKApplied, "Value", this.__ttObject, "VitaminKApplied");
        redirectProperty(this.SuckledTheFirstHalfHour, "Value", this.__ttObject, "SuckledTheFirstHalfHour");
        redirectProperty(this.PhenylketonuriaBlood, "Value", this.__ttObject, "PhenylketonuriaBlood");
        redirectProperty(this.HeartRateApgar5, "Value", this.__ttObject, "Apgar5.HeartRate");
        redirectProperty(this.MuscularTonusApgar5, "Value", this.__ttObject, "Apgar5.MuscularTonus");
        redirectProperty(this.RespirationApgar5, "Value", this.__ttObject, "Apgar5.Respiration");
        redirectProperty(this.SkinColorApgar5, "Value", this.__ttObject, "Apgar5.SkinColor");
        redirectProperty(this.StimulusResponseApgar5, "Value", this.__ttObject, "Apgar5.StimulusResponse");
        redirectProperty(this.TotalScoreApgar5, "Text", this.__ttObject, "Apgar5.TotalScore");
        redirectProperty(this.IronSupplement, "Value", this.__ttObject, "IronSupplement");
        redirectProperty(this.VitaminDSupplement, "Value", this.__ttObject, "VitaminDSupplement");
        redirectProperty(this.PrematureBaby, "Value", this.__ttObject, "PrematureBaby");
    }

    public initFormControls(): void {
        this.ShowLCD = new TTVisual.TTCheckBox();
        this.ShowLCD.Value = false;
        this.ShowLCD.Text = "LCD ekranda gösterme durumu";
        this.ShowLCD.Title = "LCD ekranda gösterme";
        this.ShowLCD.Name = "ShowLCD";
        this.ShowLCD.TabIndex = 61;

        this.labelName = new TTVisual.TTLabel();
        this.labelName.Text = "Bebeğin Adı";
        this.labelName.Name = "labelName";
        this.labelName.TabIndex = 60;

        this.Name = new TTVisual.TTTextBox();
        this.Name.Name = "Name";
        this.Name.TabIndex = 59;


        this.WristbandNumber = new TTVisual.TTTextBox();
        this.WristbandNumber.Name = "WristbandNumber";
        this.WristbandNumber.TabIndex = 30;

        this.BabyProblems = new TTVisual.TTTextBox();
        this.BabyProblems.Name = "BabyProblems";
        this.BabyProblems.TabIndex = 28;
        this.BabyProblems.Multiline = true;


        this.Height = new TTVisual.TTTextBox();
        this.Height.Name = "Height";
        this.Height.TabIndex = 26;

        this.Surname = new TTVisual.TTTextBox();
        this.Surname.Required = true;
        this.Surname.BackColor = "#FFE3C6";
        this.Surname.Name = "Surname";
        this.Surname.TabIndex = 24;

        this.FatherName = new TTVisual.TTTextBox();
        this.FatherName.Name = "FatherName";
        this.FatherName.TabIndex = 22;
        this.FatherName.Required = true;

        this.Weigth = new TTVisual.TTTextBox();
        this.Weigth.Name = "Weigth";
        this.Weigth.TabIndex = 20;

        this.PregnancyWeek = new TTVisual.TTTextBox();
        this.PregnancyWeek.Name = "PregnancyWeek";
        this.PregnancyWeek.TabIndex = 16;

        this.HeadCircumference = new TTVisual.TTTextBox();
        this.HeadCircumference.Name = "HeadCircumference";
        this.HeadCircumference.TabIndex = 12;

        this.ttgroupbox2 = new TTVisual.TTGroupBox();
        this.ttgroupbox2.Text = "Apgar Skoru 5. Dakika";
        this.ttgroupbox2.Name = "ttgroupbox2";
        this.ttgroupbox2.TabIndex = 1;

        this.labelTotalScoreApgar5 = new TTVisual.TTLabel();
        this.labelTotalScoreApgar5.Text = "Toplam Skor";
        this.labelTotalScoreApgar5.Name = "labelTotalScoreApgar5";
        this.labelTotalScoreApgar5.TabIndex = 11;

        this.TotalScoreApgar5 = new TTVisual.TTTextBox();
        this.TotalScoreApgar5.Name = "TotalScoreApgar5";
        this.TotalScoreApgar5.TabIndex = 10;

        this.labelStimulusResponseApgar5 = new TTVisual.TTLabel();
        this.labelStimulusResponseApgar5.Text = "Uyarılara Cevap";
        this.labelStimulusResponseApgar5.Name = "labelStimulusResponseApgar5";
        this.labelStimulusResponseApgar5.TabIndex = 9;

        this.StimulusResponseApgar5 = new TTVisual.TTEnumComboBox();
        this.StimulusResponseApgar5.DataTypeName = "ApgarStimulusResponseEnum";
        this.StimulusResponseApgar5.Name = "StimulusResponseApgar5";
        this.StimulusResponseApgar5.TabIndex = 8;

        this.labelSkinColorApgar5 = new TTVisual.TTLabel();
        this.labelSkinColorApgar5.Text = "Cilt Rengi";
        this.labelSkinColorApgar5.Name = "labelSkinColorApgar5";
        this.labelSkinColorApgar5.TabIndex = 7;

        this.SkinColorApgar5 = new TTVisual.TTEnumComboBox();
        this.SkinColorApgar5.DataTypeName = "ApgarSkinColorEnum";
        this.SkinColorApgar5.Name = "SkinColorApgar5";
        this.SkinColorApgar5.TabIndex = 6;

        this.labelRespirationApgar5 = new TTVisual.TTLabel();
        this.labelRespirationApgar5.Text = "Solunum";
        this.labelRespirationApgar5.Name = "labelRespirationApgar5";
        this.labelRespirationApgar5.TabIndex = 5;

        this.RespirationApgar5 = new TTVisual.TTEnumComboBox();
        this.RespirationApgar5.DataTypeName = "ApgarRespirationEnum";
        this.RespirationApgar5.Name = "RespirationApgar5";
        this.RespirationApgar5.TabIndex = 4;

        this.labelMuscularTonusApgar5 = new TTVisual.TTLabel();
        this.labelMuscularTonusApgar5.Text = "Kas Tonusu";
        this.labelMuscularTonusApgar5.Name = "labelMuscularTonusApgar5";
        this.labelMuscularTonusApgar5.TabIndex = 3;

        this.MuscularTonusApgar5 = new TTVisual.TTEnumComboBox();
        this.MuscularTonusApgar5.DataTypeName = "ApgarMuscularTonusEnum";
        this.MuscularTonusApgar5.Name = "MuscularTonusApgar5";
        this.MuscularTonusApgar5.TabIndex = 2;

        this.labelHeartRateApgar5 = new TTVisual.TTLabel();
        this.labelHeartRateApgar5.Text = "Kalp Hızı";
        this.labelHeartRateApgar5.Name = "labelHeartRateApgar5";
        this.labelHeartRateApgar5.TabIndex = 1;

        this.HeartRateApgar5 = new TTVisual.TTEnumComboBox();
        this.HeartRateApgar5.DataTypeName = "ApgarHeartRateEnum";
        this.HeartRateApgar5.Name = "HeartRateApgar5";
        this.HeartRateApgar5.TabIndex = 0;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = "Apgar Skoru 1. Dakika";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 0;

        this.labelTotalScoreApgar1 = new TTVisual.TTLabel();
        this.labelTotalScoreApgar1.Text = "Toplam Skor";
        this.labelTotalScoreApgar1.Name = "labelTotalScoreApgar1";
        this.labelTotalScoreApgar1.TabIndex = 11;

        this.TotalScoreApgar1 = new TTVisual.TTTextBox();
        this.TotalScoreApgar1.Name = "TotalScoreApgar1";
        this.TotalScoreApgar1.TabIndex = 10;

        this.labelStimulusResponseApgar1 = new TTVisual.TTLabel();
        this.labelStimulusResponseApgar1.Text = "Uyarılara Cevap";
        this.labelStimulusResponseApgar1.Name = "labelStimulusResponseApgar1";
        this.labelStimulusResponseApgar1.TabIndex = 9;

        this.StimulusResponseApgar1 = new TTVisual.TTEnumComboBox();
        this.StimulusResponseApgar1.DataTypeName = "ApgarStimulusResponseEnum";
        this.StimulusResponseApgar1.Name = "StimulusResponseApgar1";
        this.StimulusResponseApgar1.TabIndex = 8;

        this.labelSkinColorApgar1 = new TTVisual.TTLabel();
        this.labelSkinColorApgar1.Text = "Cilt Rengi";
        this.labelSkinColorApgar1.Name = "labelSkinColorApgar1";
        this.labelSkinColorApgar1.TabIndex = 7;

        this.SkinColorApgar1 = new TTVisual.TTEnumComboBox();
        this.SkinColorApgar1.DataTypeName = "ApgarSkinColorEnum";
        this.SkinColorApgar1.Name = "SkinColorApgar1";
        this.SkinColorApgar1.TabIndex = 6;

        this.labelRespirationApgar1 = new TTVisual.TTLabel();
        this.labelRespirationApgar1.Text = "Solunum";
        this.labelRespirationApgar1.Name = "labelRespirationApgar1";
        this.labelRespirationApgar1.TabIndex = 5;

        this.RespirationApgar1 = new TTVisual.TTEnumComboBox();
        this.RespirationApgar1.DataTypeName = "ApgarRespirationEnum";
        this.RespirationApgar1.Name = "RespirationApgar1";
        this.RespirationApgar1.TabIndex = 4;

        this.labelMuscularTonusApgar1 = new TTVisual.TTLabel();
        this.labelMuscularTonusApgar1.Text = "Kas Tonusu";
        this.labelMuscularTonusApgar1.Name = "labelMuscularTonusApgar1";
        this.labelMuscularTonusApgar1.TabIndex = 3;

        this.MuscularTonusApgar1 = new TTVisual.TTEnumComboBox();
        this.MuscularTonusApgar1.DataTypeName = "ApgarMuscularTonusEnum";
        this.MuscularTonusApgar1.Name = "MuscularTonusApgar1";
        this.MuscularTonusApgar1.TabIndex = 2;

        this.labelHeartRateApgar1 = new TTVisual.TTLabel();
        this.labelHeartRateApgar1.Text = "Kalp Hızı";
        this.labelHeartRateApgar1.Name = "labelHeartRateApgar1";
        this.labelHeartRateApgar1.TabIndex = 1;

        this.HeartRateApgar1 = new TTVisual.TTEnumComboBox();
        this.HeartRateApgar1.DataTypeName = "ApgarHeartRateEnum";
        this.HeartRateApgar1.Name = "HeartRateApgar1";
        this.HeartRateApgar1.TabIndex = 0;

        this.labelGender = new TTVisual.TTLabel();
        this.labelGender.Text = "Cinsiyet";
        this.labelGender.Name = "labelGender";
        this.labelGender.TabIndex = 58;

        this.Gender = new TTVisual.TTObjectListBox();
        this.Gender.ListDefName = "SKRSCinsiyetList";
        this.Gender.Name = "Gender";
        this.Gender.TabIndex = 57;

        this.labelBirthType = new TTVisual.TTLabel();
        this.labelBirthType.Text = "Doğum Yöntemi";
        this.labelBirthType.Name = "labelBirthType";
        this.labelBirthType.TabIndex = 56;

        this.BirthType = new TTVisual.TTObjectListBox();
        this.BirthType.ListDefName = "SKRSDogumYontemiList";
        this.BirthType.Name = "BirthType";
        this.BirthType.TabIndex = 55;

        this.labelBirthOrder = new TTVisual.TTLabel();
        this.labelBirthOrder.Text = "Doğum Sırası";
        this.labelBirthOrder.Name = "labelBirthOrder";
        this.labelBirthOrder.TabIndex = 54;

        this.BirthOrder = new TTVisual.TTObjectListBox();
        this.BirthOrder.ListDefName = "SKRSDogumSirasiList";
        this.BirthOrder.Name = "BirthOrder";
        this.BirthOrder.TabIndex = 53;

        this.labelBirthLocation = new TTVisual.TTLabel();
        this.labelBirthLocation.Text = "Doğumun Gerçekleştiği Yer";
        this.labelBirthLocation.Name = "labelBirthLocation";
        this.labelBirthLocation.TabIndex = 52;

        this.BirthLocation = new TTVisual.TTObjectListBox();
        this.BirthLocation.ListDefName = "SKRSDogumunGerceklestigiYerList";
        this.BirthLocation.Name = "BirthLocation";
        this.BirthLocation.TabIndex = 51;

        this.labelCauseOfDeath = new TTVisual.TTLabel();
        this.labelCauseOfDeath.Text = "Ölüm Nedeni";
        this.labelCauseOfDeath.Name = "labelCauseOfDeath";
        this.labelCauseOfDeath.TabIndex = 50;

        this.CauseOfDeath = new TTVisual.TTObjectListBox();
        this.CauseOfDeath.ListDefName = "SKRSBebekOlumNedenleriList";
        this.CauseOfDeath.Name = "CauseOfDeath";
        this.CauseOfDeath.TabIndex = 49;

        this.FontanelExamination = new TTVisual.TTCheckBox();
        this.FontanelExamination.Value = false;
        this.FontanelExamination.Text = "Fontanel Muayenesi";
        this.FontanelExamination.Title = "Fontanel Muayenesi";
        this.FontanelExamination.Name = "FontanelExamination";
        this.FontanelExamination.TabIndex = 48;

        this.TesticleExamination = new TTVisual.TTCheckBox();
        this.TesticleExamination.Value = false;
        this.TesticleExamination.Text = "Testis Muayenesi";
        this.TesticleExamination.Title = "Testis Muayenesi";
        this.TesticleExamination.Name = "TesticleExamination";
        this.TesticleExamination.TabIndex = 47;

        this.IronSupplement = new TTVisual.TTCheckBox();
        this.IronSupplement.Value = false;
        this.IronSupplement.Text = "Demir Takviyesi";
        this.IronSupplement.Title = "Demir Takviyesi";
        this.IronSupplement.Name = "IronSupplement";
        this.IronSupplement.TabIndex = 46;

        this.VitaminDSupplement = new TTVisual.TTCheckBox();
        this.VitaminDSupplement.Value = false;
        this.VitaminDSupplement.Text = "D Vitamini Takviyesi";
        this.VitaminDSupplement.Title = "D Vitamini Takviyesi";
        this.VitaminDSupplement.Name = "VitaminDSupplement";
        this.VitaminDSupplement.TabIndex = 45;

        this.VisionScreening = new TTVisual.TTCheckBox();
        this.VisionScreening.Value = false;
        this.VisionScreening.Text = "Görme Taraması Yapıldı";
        this.VisionScreening.Title = "Görme Taraması Yapıldı";
        this.VisionScreening.Name = "VisionScreening";
        this.VisionScreening.TabIndex = 44;

        this.HearingScreening = new TTVisual.TTCheckBox();
        this.HearingScreening.Value = false;
        this.HearingScreening.Text = "İşitme Taraması Yapıldı";
        this.HearingScreening.Title = "İşitme Taraması Yapıldı";
        this.HearingScreening.Name = "HearingScreening";
        this.HearingScreening.TabIndex = 43;

        this.HypothyroidisBlood = new TTVisual.TTCheckBox();
        this.HypothyroidisBlood.Value = false;
        this.HypothyroidisBlood.Text = "Hipotiroidi İçin Kan Alındı";
        this.HypothyroidisBlood.Title = "Hipotiroidi İçin Kan Alındı";
        this.HypothyroidisBlood.Name = "HypothyroidisBlood";
        this.HypothyroidisBlood.TabIndex = 42;

        this.Asphyxia = new TTVisual.TTCheckBox();
        this.Asphyxia.Value = false;
        this.Asphyxia.Text = "Asfiktik Doğan Bebek";
        this.Asphyxia.Title = "Asfiktik Doğan Bebek";
        this.Asphyxia.Name = "Asphyxia";
        this.Asphyxia.TabIndex = 41;

        this.PrematureBaby = new TTVisual.TTCheckBox();
        this.PrematureBaby.Value = false;
        this.PrematureBaby.Text = "Prematüre Doğan Bebek";
        this.PrematureBaby.Title = "Prematüre Doğan Bebek";
        this.PrematureBaby.Name = "PrematureBaby";
        this.PrematureBaby.TabIndex = 40;

        this.AbnormalBaby = new TTVisual.TTCheckBox();
        this.AbnormalBaby.Value = false;
        this.AbnormalBaby.Text = "Anormal Doğan Bebek";
        this.AbnormalBaby.Title = "Anormal Doğan Bebek";
        this.AbnormalBaby.Name = "AbnormalBaby";
        this.AbnormalBaby.TabIndex = 39;

        this.VitaminKApplied = new TTVisual.TTCheckBox();
        this.VitaminKApplied.Value = false;
        this.VitaminKApplied.Text = "K Vitamini Uygulandı";
        this.VitaminKApplied.Title = "K Vitamini Uygulandı";
        this.VitaminKApplied.Name = "VitaminKApplied";
        this.VitaminKApplied.TabIndex = 38;

        this.SuckledTheFirstHalfHour = new TTVisual.TTCheckBox();
        this.SuckledTheFirstHalfHour.Value = false;
        this.SuckledTheFirstHalfHour.Text = "İlk Yarım Saatte Emdi";
        this.SuckledTheFirstHalfHour.Title = "İlk Yarım Saatte Emdi";
        this.SuckledTheFirstHalfHour.Name = "SuckledTheFirstHalfHour";
        this.SuckledTheFirstHalfHour.TabIndex = 37;

        this.WithoutBreastMilk = new TTVisual.TTCheckBox();
        this.WithoutBreastMilk.Value = false;
        this.WithoutBreastMilk.Text = "Anne Sütü Almayan Bebek";
        this.WithoutBreastMilk.Title = "Anne Sütü Almayan Bebek";
        this.WithoutBreastMilk.Name = "WithoutBreastMilk";
        this.WithoutBreastMilk.TabIndex = 36;

        this.LactationInfo = new TTVisual.TTCheckBox();
        this.LactationInfo.Value = false;
        this.LactationInfo.Text = "Anne Emzirme Danışmanlığı Aldı";
        this.LactationInfo.Title = "Anne Emzirme Danışmanlığı Aldı";
        this.LactationInfo.Name = "LactationInfo";
        this.LactationInfo.TabIndex = 35;

        this.HepatitisImmunoglobulin = new TTVisual.TTCheckBox();
        this.HepatitisImmunoglobulin.Value = false;
        this.HepatitisImmunoglobulin.Text = "Hepatit İmmunoglobülin Yapıldı";
        this.HepatitisImmunoglobulin.Title = "Hepatit İmmunoglobülin Yapıldı";
        this.HepatitisImmunoglobulin.Name = "HepatitisImmunoglobulin";
        this.HepatitisImmunoglobulin.TabIndex = 34;

        this.HepatitisB = new TTVisual.TTCheckBox();
        this.HepatitisB.Value = false;
        this.HepatitisB.Text = "Hepatit B Yapıldı";
        this.HepatitisB.Title = "Hepatit B Yapıldı";
        this.HepatitisB.Name = "HepatitisB";
        this.HepatitisB.TabIndex = 33;

        this.PhenylketonuriaBlood = new TTVisual.TTCheckBox();
        this.PhenylketonuriaBlood.Value = false;
        this.PhenylketonuriaBlood.Text = "Fenilketonüri İçin Kan Alındı";
        this.PhenylketonuriaBlood.Title = "Fenilketonüri İçin Kan Alındı";
        this.PhenylketonuriaBlood.Name = "PhenylketonuriaBlood";
        this.PhenylketonuriaBlood.TabIndex = 32;

        this.labelWristbandNumber = new TTVisual.TTLabel();
        this.labelWristbandNumber.Text = "Kol Bandı Numarası";
        this.labelWristbandNumber.Name = "labelWristbandNumber";
        this.labelWristbandNumber.TabIndex = 31;

        this.labelBabyProblems = new TTVisual.TTLabel();
        this.labelBabyProblems.Text = "Bebekte Yaşanan Sorun/Tespit Edilen Riskler";
        this.labelBabyProblems.Name = "labelBabyProblems";
        this.labelBabyProblems.TabIndex = 29;

        this.labelHeight = new TTVisual.TTLabel();
        this.labelHeight.Text = "Boy";
        this.labelHeight.Name = "labelHeight";
        this.labelHeight.TabIndex = 27;

        this.labelSurname = new TTVisual.TTLabel();
        this.labelSurname.Text = "Bebeğin Soyadı";
        this.labelSurname.Name = "labelSurname";
        this.labelSurname.TabIndex = 25;

        this.labelFatherName = new TTVisual.TTLabel();
        this.labelFatherName.Text = "Baba Adı";
        this.labelFatherName.Name = "labelFatherName";
        this.labelFatherName.TabIndex = 23;

        this.labelWeigth = new TTVisual.TTLabel();
        this.labelWeigth.Text = "Kilo";
        this.labelWeigth.Name = "labelWeigth";
        this.labelWeigth.TabIndex = 21;

        this.labelPresentationType = new TTVisual.TTLabel();
        this.labelPresentationType.Text = "Geliş Şekli";
        this.labelPresentationType.Name = "labelPresentationType";
        this.labelPresentationType.TabIndex = 19;

        this.PresentationType = new TTVisual.TTEnumComboBox();
        this.PresentationType.DataTypeName = "PresentationTypeEnum";
        this.PresentationType.Name = "PresentationType";
        this.PresentationType.TabIndex = 18;

        this.labelPregnancyWeek = new TTVisual.TTLabel();
        this.labelPregnancyWeek.Text = "Gebelik Süresi Haftası";
        this.labelPregnancyWeek.Name = "labelPregnancyWeek";
        this.labelPregnancyWeek.TabIndex = 17;

        this.labelPlacentaDecollementType = new TTVisual.TTLabel();
        this.labelPlacentaDecollementType.Text = "Plasenta Ayrılış Şekli";
        this.labelPlacentaDecollementType.Name = "labelPlacentaDecollementType";
        this.labelPlacentaDecollementType.TabIndex = 15;

        this.PlacentaDecollementType = new TTVisual.TTEnumComboBox();
        this.PlacentaDecollementType.DataTypeName = "PlacentaDecollementTypeEnum";
        this.PlacentaDecollementType.Name = "PlacentaDecollementType";
        this.PlacentaDecollementType.TabIndex = 14;

        this.labelHeadCircumference = new TTVisual.TTLabel();
        this.labelHeadCircumference.Text = "Baş Çevresi";
        this.labelHeadCircumference.Name = "labelHeadCircumference";
        this.labelHeadCircumference.TabIndex = 13;

        this.labelFetalAnomalies = new TTVisual.TTLabel();
        this.labelFetalAnomalies.Text = "Fetal Anomaliler";
        this.labelFetalAnomalies.Name = "labelFetalAnomalies";
        this.labelFetalAnomalies.TabIndex = 9;

        this.FetalAnomalies = new TTVisual.TTEnumComboBox();
        this.FetalAnomalies.DataTypeName = "FetalAnomaliesTypeEnum";
        this.FetalAnomalies.Name = "FetalAnomalies";
        this.FetalAnomalies.TabIndex = 8;

        this.labelDatetimeOfDeath = new TTVisual.TTLabel();
        this.labelDatetimeOfDeath.Text = "Ölüm Tarihi ve Saati";
        this.labelDatetimeOfDeath.Name = "labelDatetimeOfDeath";
        this.labelDatetimeOfDeath.TabIndex = 7;

        this.DatetimeOfDeath = new TTVisual.TTDateTimePicker();
        this.DatetimeOfDeath.Format = DateTimePickerFormat.Long;
        this.DatetimeOfDeath.Name = "DatetimeOfDeath";
        this.DatetimeOfDeath.TabIndex = 6;

        this.labelBirthDateTime = new TTVisual.TTLabel();
        this.labelBirthDateTime.Text = "Doğum Tarihi ve Saati";
        this.labelBirthDateTime.Name = "labelBirthDateTime";
        this.labelBirthDateTime.TabIndex = 5;

        this.BirthDateTime = new TTVisual.TTDateTimePicker();
        this.BirthDateTime.Format = DateTimePickerFormat.Long;
        this.BirthDateTime.Name = "BirthDateTime";
        this.BirthDateTime.TabIndex = 4;

        this.labelBabyStatus = new TTVisual.TTLabel();
        this.labelBabyStatus.Text = "Yaşam Durumu";
        this.labelBabyStatus.Name = "labelBabyStatus";
        this.labelBabyStatus.TabIndex = 3;

        this.BabyStatus = new TTVisual.TTEnumComboBox();
        this.BabyStatus.DataTypeName = "BirthReportBabyStatus";
        this.BabyStatus.Required = true;
        this.BabyStatus.BackColor = "#FFE3C6";
        this.BabyStatus.Name = "BabyStatus";
        this.BabyStatus.TabIndex = 2;

        this.labelAnesthesiaTechnique = new TTVisual.TTLabel();
        this.labelAnesthesiaTechnique.Text = "Anestezi";
        this.labelAnesthesiaTechnique.Name = "labelAnesthesiaTechnique";
        this.labelAnesthesiaTechnique.TabIndex = 1;

        this.AnesthesiaTechnique = new TTVisual.TTEnumComboBox();
        this.AnesthesiaTechnique.DataTypeName = "AnesthesiaTechniqueEnum";
        this.AnesthesiaTechnique.Name = "AnesthesiaTechnique";
        this.AnesthesiaTechnique.TabIndex = 0;

        this.ttgroupbox2.Controls = [this.labelTotalScoreApgar5, this.TotalScoreApgar5, this.labelStimulusResponseApgar5, this.StimulusResponseApgar5, this.labelSkinColorApgar5, this.SkinColorApgar5, this.labelRespirationApgar5, this.RespirationApgar5, this.labelMuscularTonusApgar5, this.MuscularTonusApgar5, this.labelHeartRateApgar5, this.HeartRateApgar5];
        this.ttgroupbox1.Controls = [this.labelTotalScoreApgar1, this.TotalScoreApgar1, this.labelStimulusResponseApgar1, this.StimulusResponseApgar1, this.labelSkinColorApgar1, this.SkinColorApgar1, this.labelRespirationApgar1, this.RespirationApgar1, this.labelMuscularTonusApgar1, this.MuscularTonusApgar1, this.labelHeartRateApgar1, this.HeartRateApgar1];
        this.Controls = [this.ShowLCD, this.labelName, this.Name, this.WristbandNumber, this.BabyProblems, this.Height, this.Surname, this.FatherName, this.Weigth, this.PregnancyWeek, this.HeadCircumference, this.ttgroupbox2, this.labelTotalScoreApgar5, this.TotalScoreApgar5, this.labelStimulusResponseApgar5, this.StimulusResponseApgar5, this.labelSkinColorApgar5, this.SkinColorApgar5, this.labelRespirationApgar5, this.RespirationApgar5, this.labelMuscularTonusApgar5, this.MuscularTonusApgar5, this.labelHeartRateApgar5, this.HeartRateApgar5, this.ttgroupbox1, this.labelTotalScoreApgar1, this.TotalScoreApgar1, this.labelStimulusResponseApgar1, this.StimulusResponseApgar1, this.labelSkinColorApgar1, this.SkinColorApgar1, this.labelRespirationApgar1, this.RespirationApgar1, this.labelMuscularTonusApgar1, this.MuscularTonusApgar1, this.labelHeartRateApgar1, this.HeartRateApgar1, this.labelGender, this.Gender, this.labelBirthType, this.BirthType, this.labelBirthOrder, this.BirthOrder, this.labelBirthLocation, this.BirthLocation, this.labelCauseOfDeath, this.CauseOfDeath, this.FontanelExamination, this.TesticleExamination, this.IronSupplement, this.VitaminDSupplement, this.VisionScreening, this.HearingScreening, this.HypothyroidisBlood, this.Asphyxia, this.PrematureBaby, this.AbnormalBaby, this.VitaminKApplied, this.SuckledTheFirstHalfHour, this.WithoutBreastMilk, this.LactationInfo, this.HepatitisImmunoglobulin, this.HepatitisB, this.PhenylketonuriaBlood, this.labelWristbandNumber, this.labelBabyProblems, this.labelHeight, this.labelSurname, this.labelFatherName, this.labelWeigth, this.labelPresentationType, this.PresentationType, this.labelPregnancyWeek, this.labelPlacentaDecollementType, this.PlacentaDecollementType, this.labelHeadCircumference, this.labelFetalAnomalies, this.FetalAnomalies, this.labelDatetimeOfDeath, this.DatetimeOfDeath, this.labelBirthDateTime, this.BirthDateTime, this.labelBabyStatus, this.BabyStatus, this.labelAnesthesiaTechnique, this.AnesthesiaTechnique];

    }


}
