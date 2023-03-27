//$3D9BCBE6
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { EmergencySpecialityObjectFormViewModel } from './EmergencySpecialityObjectFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EmergencySpecialityObject } from 'NebulaClient/Model/AtlasClientModel';
import { Allergy } from 'NebulaClient/Model/AtlasClientModel';
import { GlaskowComaScaleDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Vaccination } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSTRIAJKODU } from 'NebulaClient/Model/AtlasClientModel';
import { GlaskowComaScaleScoreEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DxAccordionComponent } from "devextreme-angular";

import { SpecialityBasedObjectForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/SpecialityBasedObjectForm";
import { IActiveTabService } from 'Fw/Services/IActiveTabService';
import { PainFrequencyDefiniton } from 'NebulaClient/Model/AtlasClientModel';
import { PainPlaceDefition } from 'NebulaClient/Model/AtlasClientModel';
import { PainQualityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { EmergencySurveyObject } from 'NebulaClient/Model/AtlasClientModel';
import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';

@Component({
    selector: 'EmergencySpecialityObjectForm',
    templateUrl: './EmergencySpecialityObjectForm.html',
    providers: [MessageService]
})
export class EmergencySpecialityObjectForm extends SpecialityBasedObjectForm implements OnInit {
    AbdominalPain: TTVisual.ITTCheckBox;
    Anorexia: TTVisual.ITTCheckBox;
    Aşı: TTVisual.ITTTextBoxColumn;
    Attack: TTVisual.ITTCheckBox;
    BackPain: TTVisual.ITTCheckBox;
    BehaviourLoss: TTVisual.ITTCheckBox;
    BreastDrainage: TTVisual.ITTCheckBox;
    BreastMass: TTVisual.ITTCheckBox;
    BreastPain: TTVisual.ITTCheckBox;
    cbxGebe: TTVisual.ITTCheckBox;
    cbxTetanoz: TTVisual.ITTCheckBox;
    ChestPain: TTVisual.ITTCheckBox;
    Complaint: TTVisual.ITTObjectListBox;
    ComplaintDuration: TTVisual.ITTTextBox;
    ComplaintDurationType: TTVisual.ITTEnumComboBox;
    ConsciousnessLoss: TTVisual.ITTCheckBox;
    Constipation: TTVisual.ITTCheckBox;
    Contraction: TTVisual.ITTCheckBox;
    Cough: TTVisual.ITTCheckBox;
    Cyanosis: TTVisual.ITTCheckBox;
    DiagnosisTab: TTVisual.ITTTabControl;
    Diarrhea: TTVisual.ITTCheckBox;
    Dismenore: TTVisual.ITTCheckBox;
    Dizziness: TTVisual.ITTCheckBox;
    DoubleVision: TTVisual.ITTCheckBox;
    EarDrainage: TTVisual.ITTCheckBox;
    EarPain: TTVisual.ITTCheckBox;
    Edema: TTVisual.ITTCheckBox;
    EyePain: TTVisual.ITTCheckBox;
    Eyes: TTVisual.ITTObjectListBox;
    FaceScala: TTVisual.ITTTextBox;
    Galactore: TTVisual.ITTCheckBox;
    Geçerliliği: TTVisual.ITTTextBoxColumn;
    GenelDurum: TTVisual.ITTGroupBox;
    GeneralEvaluationBad: TTVisual.ITTCheckBox;
    GeneralEvaluationCold: TTVisual.ITTCheckBox;
    GeneralEvaluationDehidrate: TTVisual.ITTCheckBox;
    GeneralEvaluationDispneic: TTVisual.ITTCheckBox;
    GeneralEvaluationGood: TTVisual.ITTCheckBox;
    GeneralEvaluationMedium: TTVisual.ITTCheckBox;
    GeneralEvaluationPainly: TTVisual.ITTCheckBox;
    GeneralEvaluationSweaty: TTVisual.ITTCheckBox;
    Hallucination: TTVisual.ITTCheckBox;
    HeadAche: TTVisual.ITTCheckBox;
    Hemoptysis: TTVisual.ITTCheckBox;
    Hirsutusmus: TTVisual.ITTCheckBox;
    Hoarseness: TTVisual.ITTCheckBox;
    Imbalance: TTVisual.ITTCheckBox;
    JointPain: TTVisual.ITTCheckBox;
    JointSwelling: TTVisual.ITTCheckBox;
    labelAllergyInformation: TTVisual.ITTLabel;
    labelEyes: TTVisual.ITTLabel;
    labelLastMenstrualPeriod: TTVisual.ITTLabel;
    labelMotorAnswer: TTVisual.ITTLabel;
    labelOralAnswer: TTVisual.ITTLabel;
    labelTotalScore: TTVisual.ITTLabel;
    LaboredBreathing: TTVisual.ITTCheckBox;
    LastEatingInfo: TTVisual.ITTTextBox;
    ContinuousDrugs: TTVisual.ITTRichTextBoxControl;
    Habits: TTVisual.ITTRichTextBoxControl;
    AllergyDescription: TTVisual.ITTRichTextBoxControl;
    ttrichtextboxcontrol1: TTVisual.ITTRichTextBoxControl;
    ttrichtextboxcontrol2: TTVisual.ITTRichTextBoxControl;
    lblAlcohol: TTVisual.ITTLabel;
    lblHabit: TTVisual.ITTLabel;
    LumbarPain: TTVisual.ITTCheckBox;
    Melena: TTVisual.ITTCheckBox;
    MorningMovementLoss: TTVisual.ITTCheckBox;
    MotorAnswer: TTVisual.ITTObjectListBox;
    MovementLoss: TTVisual.ITTCheckBox;
    Name: TTVisual.ITTTextBoxColumn;
    NasalDrainage: TTVisual.ITTCheckBox;
    Nausea: TTVisual.ITTCheckBox;
    NeckMass: TTVisual.ITTCheckBox;
    NeckPain: TTVisual.ITTCheckBox;
    NightSweating: TTVisual.ITTCheckBox;
    NoInfoForHormon: TTVisual.ITTCheckBox;
    NoInfoForMan: TTVisual.ITTCheckBox;
    NoInfoForPhysocology: TTVisual.ITTCheckBox;
    OralAnswer: TTVisual.ITTObjectListBox;
    Orthopnea: TTVisual.ITTCheckBox;
    PainDegree: TTVisual.ITTTextBox;
    PainPeriod: TTVisual.ITTTextBox;
    PainPlace: TTVisual.ITTTextBox;
    Paresthaesia: TTVisual.ITTCheckBox;
    PatientHistory: TTVisual.ITTObjectListBox;
    PenileDischarge: TTVisual.ITTCheckBox;
    PND: TTVisual.ITTCheckBox;
    Prostration: TTVisual.ITTCheckBox;
    Pruritus: TTVisual.ITTCheckBox;
    PsychologicalEvaluationAngry: TTVisual.ITTCheckBox;
    PsychologicalEvaluationIrrelevant: TTVisual.ITTCheckBox;
    PsychologicalEvaluationNormal: TTVisual.ITTCheckBox;
    PsychologicalEvaluationOther: TTVisual.ITTTextBox;
    PsychologicalEvaluationSad: TTVisual.ITTCheckBox;
    PsychologicalEvaluationWorried: TTVisual.ITTCheckBox;
    Reaction: TTVisual.ITTTextBoxColumn;
    RhythmDisorder: TTVisual.ITTCheckBox;
    Risk: TTVisual.ITTEnumComboBoxColumn;
    Risk2: TTVisual.ITTEnumComboBoxColumn;
    Sputum: TTVisual.ITTCheckBox;
    StomachPain: TTVisual.ITTCheckBox;
    Sweating: TTVisual.ITTCheckBox;
    Tachycardia: TTVisual.ITTCheckBox;
    TestisPain: TTVisual.ITTCheckBox;
    ThroatPain: TTVisual.ITTCheckBox;
    ThrowingUp: TTVisual.ITTCheckBox;
    Tinnitus: TTVisual.ITTCheckBox;
    TotalScore: TTVisual.ITTEnumComboBox;
    TriageList: TTVisual.ITTObjectListBox;
    ttdatetimepicker1: TTVisual.ITTDateTimePicker;
    ActionDate: TTVisual.ITTDateTimePicker;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttgroupbox10: TTVisual.ITTGroupBox;
    ttgroupbox11: TTVisual.ITTGroupBox;
    ttgroupbox12: TTVisual.ITTGroupBox;
    ttgroupbox13: TTVisual.ITTGroupBox;
    ttgroupbox15: TTVisual.ITTGroupBox;
    ttgroupbox16: TTVisual.ITTGroupBox;
    ttgroupbox18: TTVisual.ITTGroupBox;
    ttgroupbox17: TTVisual.ITTGroupBox;
    ttgroupbox2: TTVisual.ITTGroupBox;
    ttgroupbox3: TTVisual.ITTGroupBox;
    ttgroupbox4: TTVisual.ITTGroupBox;
    ttgroupbox5: TTVisual.ITTGroupBox;
    ttgroupbox6: TTVisual.ITTGroupBox;
    ttgroupbox7: TTVisual.ITTGroupBox;
    ttgroupbox8: TTVisual.ITTGroupBox;
    ttgroupbox9: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel14: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;

    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    txtAlcoholPromile: TTVisual.ITTTextBox;
    VaginalBleeding: TTVisual.ITTCheckBox;
    VaginalDrainage: TTVisual.ITTCheckBox;
    VisionDefect: TTVisual.ITTCheckBox;
    Weakness: TTVisual.ITTCheckBox;
    Temperature: TTVisual.ITTCheckBox;
    WeightGain: TTVisual.ITTCheckBox;
    WeightLoss: TTVisual.ITTCheckBox;
    Wheezing: TTVisual.ITTCheckBox;
    AchingSide: TTVisual.ITTTextBox;
    ApplicationDate: TTVisual.ITTDateTimePicker;
    DurationofPain: TTVisual.ITTTextBox;
    PainDetail: TTVisual.ITTTextBox;
    PainFaceScale: TTVisual.ITTEnumComboBox;
    PainFrequency: TTVisual.ITTObjectListBox;
    PainPlaces: TTVisual.ITTObjectListBox;
    PainQuality: TTVisual.ITTObjectListBox;
    PainQualityDescription: TTVisual.ITTTextBox;
    PainTime: TTVisual.ITTTextBox;

    BloodPressure_Diastolik: TTVisual.ITTTextBox;
    BloodPressure_Sistolik: TTVisual.ITTTextBox;
    Pulse_Value: TTVisual.ITTTextBox;
    Respiration_Value: TTVisual.ITTTextBox;
    Temperature_Value: TTVisual.ITTTextBox;
    SPO2_Value: TTVisual.ITTTextBox;
    Note: TTVisual.ITTTextBox;

    public EyesLastSpanCount: Array<number> = [1, 2]; //son iki cell'i boş bırak
    public OralLastSpanCount: Array<number> = [1]; //son iki cell'i boş bırak
    public glaskowComaScoreEnumArray: Array<any> = [];
    public glaskowComaScoreEnumArrayCache: any;
    public anamnesisAccordionArr: Array<any> = [{ title: i18n("M10951", "Anamnez") }];
    public triajDetailsAccordionArr: Array<any> = [{ title: i18n("M30305", "Triaj Detayları") }];

    public emergencySpecialityObjectFormViewModel: EmergencySpecialityObjectFormViewModel = new EmergencySpecialityObjectFormViewModel();
    public get _EmergencySpecialityObject(): EmergencySpecialityObject {
        return this._TTObject as EmergencySpecialityObject;
    }
    private EmergencySpecialityObjectForm_DocumentUrl: string = '/api/EmergencySpecialityObjectService/EmergencySpecialityObjectForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected tabService: IActiveTabService,
                protected ngZone: NgZone) {
        super(httpService, messageService);
        this._DocumentServiceUrl = this.EmergencySpecialityObjectForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    public faceScalaPath: string = "../../Content/FaceScala/1.png";
    public faceScala: any = 1;
    public onFaceScalaLeftClicked(event)
    {
        this.faceScala = this.faceScala - 1;

        if (this.faceScala == 0)
            this.faceScala = 6;
        this.faceScalaPath = "../../Content/FaceScala/" + this.faceScala + ".png";
    }

    public onFaceScalaRightClicked(event) {
        this.faceScala = this.faceScala + 1;

        if (this.faceScala == 7)
            this.faceScala = 1;
        this.faceScalaPath = "../../Content/FaceScala/" + this.faceScala + ".png";
    }
    // ***** Method declarations start *****
    public PatientEmergencyStateList: Array<any> = [
        { text: i18n("M16967", "İyi") },
        { text: i18n("M19754", "Orta") },
        { text: i18n("M17846", "Kötü") }
    ];

    public PatientEmergencyState: string = "";

    public onPatientEmergencyStateChanged(event) {

        if (event.value.text == i18n("M16967", "İyi")) {
            this._EmergencySpecialityObject.GeneralEvaluationGood = true;
            this._EmergencySpecialityObject.GeneralEvaluationBad = false;
            this._EmergencySpecialityObject.GeneralEvaluationMedium = false;
            this.PatientEmergencyState = this.PatientEmergencyStateList[0];
        }
        else if (event.value.text == i18n("M19754", "Orta")) {
            this._EmergencySpecialityObject.GeneralEvaluationGood = false;
            this._EmergencySpecialityObject.GeneralEvaluationBad = false;
            this._EmergencySpecialityObject.GeneralEvaluationMedium = true;
            this.PatientEmergencyState = this.PatientEmergencyStateList[1];
        }
        else if (event.value.text == i18n("M17846", "Kötü")) {
            this._EmergencySpecialityObject.GeneralEvaluationGood = false;
            this._EmergencySpecialityObject.GeneralEvaluationBad = true;
            this._EmergencySpecialityObject.GeneralEvaluationMedium = false;
            this.PatientEmergencyState = this.PatientEmergencyStateList[2];
        }

    }
    public SetPatientEmergencyState() {
        if (this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.GeneralEvaluationGood == true)
            this.PatientEmergencyState = this.PatientEmergencyStateList[0];
        else if (this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.GeneralEvaluationMedium == true)
            this.PatientEmergencyState = this.PatientEmergencyStateList[1];
        else if (this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.GeneralEvaluationBad == true)
            this.PatientEmergencyState = this.PatientEmergencyStateList[2];
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new EmergencySpecialityObject();
        this.emergencySpecialityObjectFormViewModel = new EmergencySpecialityObjectFormViewModel();
        this._ViewModel = this.emergencySpecialityObjectFormViewModel;
        this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject = this._TTObject as EmergencySpecialityObject;
        this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.EmergencySurveyObjects = new Array<EmergencySurveyObject>();
        this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.Eyes = new GlaskowComaScaleDefinition();
        this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.OralAnswer = new GlaskowComaScaleDefinition();
        this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.MotorAnswer = new GlaskowComaScaleDefinition();
        this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.Allergies = new Array<Allergy>();
        this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.Vaccinations = new Array<Vaccination>();
        this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.Triage = new SKRSTRIAJKODU();
        this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.PainQuality = new PainQualityDefinition();
        this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.PainFrequency = new PainFrequencyDefiniton();
        this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.PainPlaces = new PainPlaceDefition();
    }

    protected loadViewModel() {
        let that = this;

        that.emergencySpecialityObjectFormViewModel = this._ViewModel as EmergencySpecialityObjectFormViewModel;
        that._TTObject = this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject;
        if (this.emergencySpecialityObjectFormViewModel == null)
            this.emergencySpecialityObjectFormViewModel = new EmergencySpecialityObjectFormViewModel();
        if (this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject == null)
            this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject = new EmergencySpecialityObject();
        let eyesObjectID = that.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject["Eyes"];
        if (eyesObjectID != null && (typeof eyesObjectID === 'string')) {
            let eyes = that.emergencySpecialityObjectFormViewModel.GlaskowComaScaleDefinitions.find(o => o.ObjectID.toString() === eyesObjectID.toString());
             if (eyes) {
                that.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.Eyes = eyes;
            }
        }
        let oralAnswerObjectID = that.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject["OralAnswer"];
        if (oralAnswerObjectID != null && (typeof oralAnswerObjectID === 'string')) {
            let oralAnswer = that.emergencySpecialityObjectFormViewModel.GlaskowComaScaleDefinitions.find(o => o.ObjectID.toString() === oralAnswerObjectID.toString());
             if (oralAnswer) {
                that.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.OralAnswer = oralAnswer;
            }
        }
        let motorAnswerObjectID = that.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject["MotorAnswer"];
        if (motorAnswerObjectID != null && (typeof motorAnswerObjectID === 'string')) {
            let motorAnswer = that.emergencySpecialityObjectFormViewModel.GlaskowComaScaleDefinitions.find(o => o.ObjectID.toString() === motorAnswerObjectID.toString());
             if (motorAnswer) {
                that.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.MotorAnswer = motorAnswer;
            }
        }
        let triageObjectID = that.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject["Triage"];
        if (triageObjectID != null && (typeof triageObjectID === 'string')) {
            let triage = that.emergencySpecialityObjectFormViewModel.SKRSTRIAJKODUs.find(o => o.ObjectID.toString() === triageObjectID.toString());
             if (triage) {
                that.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.Triage = triage;
            }
        }
        let painQualityObjectID = that.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject["PainQuality"];
        if (painQualityObjectID != null && (typeof painQualityObjectID === "string")) {
            let painQuality = that.emergencySpecialityObjectFormViewModel.PainQualityDefinitions.find(o => o.ObjectID.toString() === painQualityObjectID.toString());
             if (painQuality) {
                that.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.PainQuality = painQuality;
            }
        }
        let painFrequencyObjectID = that.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject["PainFrequency"];
        if (painFrequencyObjectID != null && (typeof painFrequencyObjectID === "string")) {
            let painFrequency = that.emergencySpecialityObjectFormViewModel.PainFrequencyDefinitons.find(o => o.ObjectID.toString() === painFrequencyObjectID.toString());
             if (painFrequency) {
                that.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.PainFrequency = painFrequency;
            }
        }
        let painPlacesObjectID = that.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject["PainPlaces"];
        if (painPlacesObjectID != null && (typeof painPlacesObjectID === "string")) {
            let painPlaces = that.emergencySpecialityObjectFormViewModel.PainPlaceDefitions.find(o => o.ObjectID.toString() === painPlacesObjectID.toString());
             if (painPlaces) {
                that.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.PainPlaces = painPlaces;
            }
        }

        that.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.EmergencySurveyObjects = that.emergencySpecialityObjectFormViewModel.EmergencyDefinitionsGridList;
        for (let detailItem of that.emergencySpecialityObjectFormViewModel.EmergencyDefinitionsGridList) {
            let emergencyDefinitionsObjectID = detailItem["EmergencySurveyDefinition"];
            if (emergencyDefinitionsObjectID != null && (typeof emergencyDefinitionsObjectID === 'string')) {
                let emergencyDefinition = that.emergencySpecialityObjectFormViewModel.EmergencySurveyDefinitions.find(o => o.ObjectID.toString() === emergencyDefinitionsObjectID.toString());
                 if (emergencyDefinition) {
                    detailItem.EmergencySurveyDefinitions = emergencyDefinition;
                }

               // detailItem.ActivityGroup = emergencyDefinition.ActivityGroup;

            }
        }
        this.SetPatientEmergencyState();
    }

    public onCheckValueChanged(event, obj) {
        if (event != undefined) {

            if (event) {
                let _tempObj: EmergencySurveyObject = new EmergencySurveyObject();
                _tempObj.EmergencySurveyDefinitions = obj;

                this.emergencySpecialityObjectFormViewModel.EmergencyDefinitionsGridList.push(_tempObj);
            }
            else {
                //var index = this.emergencySpecialityObjectFormViewModel.EmergencyDefinitionsGridList.map(function (x) { return x.EmergencySurveyDefinitions.ObjectID.toString(); }).indexOf(obj.ObjectID.toString());
                //if (index > -1) {
                //    this.emergencySpecialityObjectFormViewModel.EmergencyDefinitionsGridList.splice(index, 1);

                //}

                let _tempObj = this.emergencySpecialityObjectFormViewModel.EmergencyDefinitionsGridList.find(o => o.EmergencySurveyDefinitions.toString() === obj.ObjectID.toString());
                if (obj._isNew == false)
                    _tempObj.EntityState = EntityStateEnum.Deleted;

            }
        }
    }

    public isValueExists(ObjectID: any): boolean {
        if (this.emergencySpecialityObjectFormViewModel.EmergencySurveyDefinitions.length > 0)
            if (this.emergencySpecialityObjectFormViewModel.EmergencySurveyDefinitions.find(o => o.ObjectID === ObjectID) != undefined)
                return true;

        return false;
    }

    async ngOnInit()  {
        let that = this;
        let promiseArray: Array<Promise<any>> = new Array<any>();
        promiseArray.push(this.GetGlaskowComaScaleScoreEnum());
        Promise.all(promiseArray).then((sonuc: Array<any>) => {
            that.glaskowComaScoreEnumArray = sonuc[0];
            this.load(EmergencySpecialityObjectFormViewModel);
        }).catch(error => {
            this.messageService.showError(error);
        });

  

    }

    public async GetGlaskowComaScaleScoreEnum(): Promise<any> {
        let enumName: string = "GlaskowComaScaleScoreEnum";
        if (!this.glaskowComaScoreEnumArrayCache) {
            this.glaskowComaScoreEnumArrayCache = await this.httpService.get('/api/NursingGlaskowComaScaleService/GetEnumValues?enumName=' + enumName);
            return this.glaskowComaScoreEnumArrayCache;
        }
        else {
            return this.glaskowComaScoreEnumArrayCache;
        }
    }

    @ViewChild('triajDetails') triajDetailsAccordion: DxAccordionComponent;
    @ViewChild('anamnesis') anamnesisAccordion: DxAccordionComponent;



    // ***** Method declarations start *****
    ngAfterViewInit() {
        this.triajDetailsAccordion.instance.collapseItem(0);
        this.anamnesisAccordion.instance.collapseItem(0);
    }

    ActiveAcc: string;
    RecentAcc: string;

    AccPinClick(acc) {
        this.tabService.setActiveTab(acc, "esofacc");
        this.RecentAcc = acc;
    }

    public isFemale: boolean = true;
    // ***** Method declarations start *****
    public PatientDemographicInfoLoaded(PatientDemographic: any): boolean {

        if (PatientDemographic != null && PatientDemographic.gender != null)
            this.isFemale = PatientDemographic.gender == "KADIN";

        return this.isFemale;
    }


    public onBehaviourLossChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.BehaviourLoss != event) {
                this._EmergencySpecialityObject.BehaviourLoss = event;
            }
        }
    }


    public oncbxGebeChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.IsPregnant != event) {
                this._EmergencySpecialityObject.IsPregnant = event;
            }
        }
    }

    public onHabitsChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.Habits != event) {
                this._EmergencySpecialityObject.Habits = event;
            }
        }
    }

    public onAllergyDescriptionChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.AllergyDescription != event) {
                this._EmergencySpecialityObject.AllergyDescription = event;
            }
        }
    }

    public oncbxTetanozChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.TetanusVaccine != event) {
                this._EmergencySpecialityObject.TetanusVaccine = event;
            }
        }
    }

    public async onTriageChanged(event) {
        if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.Triage != event) {
            this._EmergencySpecialityObject.Triage = event;
        }
        await this.SetTriageColor(event);
    }

    public async SetTriageColor(event) {
        if (event != null) {
            if (event.KODU == "1") {
                this.TriageList.BackColor = "#84e684";
                this.TriageList.ForeColor = "#000000";
            }
            else if (event.KODU == "2") {
                this.TriageList.BackColor = "#f1f10b";
                this.TriageList.ForeColor = "#000000";
            }
            else if (event.KODU == "3") {
                this.TriageList.BackColor = "#ff5d5d";
                this.TriageList.ForeColor = "#000000";
            }
            else if (event.KODU == "4") {
                this.TriageList.BackColor = "#423939";
                this.TriageList.ForeColor = "#ffffff";
            }
            else {
                this.TriageList.BackColor = "#ffffff";
                this.TriageList.ForeColor = "#000000";
            }
        }
        else {
            this.TriageList.BackColor = "#ffffff";
            this.TriageList.ForeColor = "#000000";
        }
    }

    public onComplaintChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.Complaint != event) {
                this._EmergencySpecialityObject.Complaint = event;
            }
        }
    }

    public onComplaintDurationChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.ComplaintDuration != event) {
                this._EmergencySpecialityObject.ComplaintDuration = event.value;
            }
        }
    }

    public onNoteChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.Note != event) {
                this._EmergencySpecialityObject.Note = event;
            }
        }
    }

    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.ActionDate != event) {
                this._EmergencySpecialityObject.ActionDate = event;
            }
        }
    }

    public eyeScore: number;
    public oralScore: number;
    public motorScore: number;
    public _totalScoreName: string = "";

    public async SetTotalScore(eyeScore, oralScore, motorScore) {
        let toplam = 0;

        if (eyeScore != null)
            toplam += eyeScore;
        if (motorScore != null)
            toplam += motorScore;
        if (oralScore != null)
            toplam += oralScore;


        if (toplam >= 15) {
            this.TotalScore.SelectedValue = GlaskowComaScaleScoreEnum.Normal; //oryante
            this._EmergencySpecialityObject.TotalScore = GlaskowComaScaleScoreEnum.Normal;
        } else if (toplam >= 13) {
            this.TotalScore.SelectedValue = GlaskowComaScaleScoreEnum.Weak; //konfüze
            this._EmergencySpecialityObject.TotalScore = GlaskowComaScaleScoreEnum.Weak;
        } else if (toplam >= 8) {
            this.TotalScore.SelectedValue = GlaskowComaScaleScoreEnum.Medium; //stupor
            this._EmergencySpecialityObject.TotalScore = GlaskowComaScaleScoreEnum.Medium;
        } else if (toplam >= 4) {
            this.TotalScore.SelectedValue = GlaskowComaScaleScoreEnum.Perikoma; //perikoma
            this._EmergencySpecialityObject.TotalScore = GlaskowComaScaleScoreEnum.Perikoma;
        }
        else {
            this.TotalScore.SelectedValue = GlaskowComaScaleScoreEnum.Coma; //koma
            this._EmergencySpecialityObject.TotalScore = GlaskowComaScaleScoreEnum.Coma;
        }
        await this.getEnumName();
    }
    public async getEnumName() {
        let _tempValue = this.glaskowComaScoreEnumArray.find(p => p.Value == this.emergencySpecialityObjectFormViewModel._EmergencySpecialityObject.TotalScore);
        this._totalScoreName = _tempValue == undefined ? "" : _tempValue.Name;
    }


    public onContinuousDrugsChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.ContinuousDrugs != event) {
                this._EmergencySpecialityObject.ContinuousDrugs = event;
            }
        }
    }

    public onEyesChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null) {
                this._EmergencySpecialityObject.Eyes = event;
                this.eyeScore = event.Score;
                this.SetTotalScore(this.eyeScore, this.oralScore, this.motorScore);

            }
        }
    }

    public onFaceScalaChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.FaceScala != event) {
                this._EmergencySpecialityObject.FaceScala = event;
            }
        }
    }

    public onGeneralEvaluationBadChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.GeneralEvaluationBad != event) {
                this._EmergencySpecialityObject.GeneralEvaluationBad = event;
            }
        }
    }

    public onGeneralEvaluationColdChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.GeneralEvaluationCold != event) {
                this._EmergencySpecialityObject.GeneralEvaluationCold = event;
            }
        }
    }

    public onGeneralEvaluationDehidrateChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.GeneralEvaluationDehidrate != event) {
                this._EmergencySpecialityObject.GeneralEvaluationDehidrate = event;
            }
        }
    }

    public onGeneralEvaluationDispneicChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.GeneralEvaluationDispneic != event) {
                this._EmergencySpecialityObject.GeneralEvaluationDispneic = event;
            }
        }
    }

    public onGeneralEvaluationGoodChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.GeneralEvaluationGood != event) {
                this._EmergencySpecialityObject.GeneralEvaluationGood = event;
            }
        }
    }

    public onGeneralEvaluationMediumChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.GeneralEvaluationMedium != event) {
                this._EmergencySpecialityObject.GeneralEvaluationMedium = event;
            }
        }
    }

    public onGeneralEvaluationPainlyChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.GeneralEvaluationPainly != event) {
                this._EmergencySpecialityObject.GeneralEvaluationPainly = event;
            }
        }
    }

    public onGeneralEvaluationSweatyChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.GeneralEvaluationSweaty != event) {
                this._EmergencySpecialityObject.GeneralEvaluationSweaty = event;
            }
        }
    }

    public onHeadAcheChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.HeadAche != event) {
                this._EmergencySpecialityObject.HeadAche = event;
            }
        }
    }

    public onLastEatingInfoChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.LastEatingInfo != event) {
                this._EmergencySpecialityObject.LastEatingInfo = event;
            }
        }
    }
    public onAlcoholPromileChanged(event): void {
        // if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.AlcoholPromile != event) {
                this._EmergencySpecialityObject.AlcoholPromile = event;
            }
        // }
    }

    public onMotorAnswerChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null) {
                this._EmergencySpecialityObject.MotorAnswer = event;
                this.motorScore = event.Score;
                this.SetTotalScore(this.eyeScore, this.oralScore, this.motorScore);
            }
        }

    }

    public onOralAnswerChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null) {
                this._EmergencySpecialityObject.OralAnswer = event;
                this.oralScore = event.Score;

                this.SetTotalScore(this.eyeScore, this.oralScore, this.motorScore);
            }
        }
    }

    public onPainDegreeChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PainDegree != event) {
                this._EmergencySpecialityObject.PainDegree = event;
            }
        }
    }

    public onPainPeriodChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PainPeriod != event) {
                this._EmergencySpecialityObject.PainPeriod = event;
            }
        }
    }

    public onPainPlaceChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PainPlace != event) {
                this._EmergencySpecialityObject.PainPlace = event;
            }
        }
    }

    public onPatientHistoryChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PatientHistory != event) {
                this._EmergencySpecialityObject.PatientHistory = event;
            }
        }
    }

    public onPsychologicalEvaluationAngryChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PsychologicalEvaluationAngry != event) {
                this._EmergencySpecialityObject.PsychologicalEvaluationAngry = event;
            }
        }
    }

    public onPsychologicalEvaluationIrrelevantChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PsychologicalEvalIrrelevant != event) {
                this._EmergencySpecialityObject.PsychologicalEvalIrrelevant = event;
            }
        }
    }

    public onPsychologicalEvaluationNormalChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PsychologicalEvaluationNormal != event) {
                this._EmergencySpecialityObject.PsychologicalEvaluationNormal = event;
            }
        }
    }

    public onPsychologicalEvaluationOtherChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PsychologicalEvaluationOther != event) {
                this._EmergencySpecialityObject.PsychologicalEvaluationOther = event;
            }
        }
    }

    public onPsychologicalEvaluationSadChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PsychologicalEvaluationSad != event) {
                this._EmergencySpecialityObject.PsychologicalEvaluationSad = event;
            }
        }
    }

    public onPsychologicalEvaluationWorriedChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PsychologicalEvalWorried != event) {
                this._EmergencySpecialityObject.PsychologicalEvalWorried = event;
            }
        }
    }

    public onTotalScoreChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.TotalScore != event) {
                this._EmergencySpecialityObject.TotalScore = event;
            }
        }
    }

    public onttdatetimepicker1Changed(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.LastMenstrualPeriod != event) {
                this._EmergencySpecialityObject.LastMenstrualPeriod = event;
            }
        }
    }

    public onttrichtextboxcontrol1Changed(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.ComplaintDescription != event) {
                this._EmergencySpecialityObject.ComplaintDescription = event;
            }
        }
    }

    public onttrichtextboxcontrol2Changed(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PatientHistoryDescription != event) {
                this._EmergencySpecialityObject.PatientHistoryDescription = event;
            }
        }
    }

    public onBloodPressure_SistolikChanged(event): void {
        if (event != null) {
            if (this.emergencySpecialityObjectFormViewModel.BloodPressure_Sistolik != event) {
                this.emergencySpecialityObjectFormViewModel.BloodPressure_Sistolik = event.value;
            }
        }
    }

    public onBloodPressure_DiastolikChanged(event): void {
        if (event != null) {
            if (this.emergencySpecialityObjectFormViewModel.BloodPressure_Diastolik != event) {
                this.emergencySpecialityObjectFormViewModel.BloodPressure_Diastolik = event.value;
            }
        }
    }

    public onPulse_ValueChanged(event): void {
        if (event != null) {
            if (this.emergencySpecialityObjectFormViewModel.Pulse_Value != event) {
                this.emergencySpecialityObjectFormViewModel.Pulse_Value = event;
            }
        }
    }

    public onRespiration_ValueChanged(event): void {
        if (event != null) {
            if (this.emergencySpecialityObjectFormViewModel.Respiration_Value != event) {
                this.emergencySpecialityObjectFormViewModel.Respiration_Value = event;
            }
        }
    }

    public onTemperature_ValueChanged(event): void {
        if (event != null) {
            if (this.emergencySpecialityObjectFormViewModel.Temperature_Value != event) {
                this.emergencySpecialityObjectFormViewModel.Temperature_Value = event;
            }
        }
    }

    public onSPO2_ValueChanged(event): void {
        if (event != null) {
            if (this.emergencySpecialityObjectFormViewModel.SPO2_Value != event) {
                this.emergencySpecialityObjectFormViewModel.SPO2_Value = event;
            }
        }
    }
 public onAchingSideChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.AchingSide != event) {
                this._EmergencySpecialityObject.AchingSide = event;
            }
        }
    }

    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.ApplicationDate != event) {
                this._EmergencySpecialityObject.ApplicationDate = event;
            }
        }
    }

    public onDurationofPainChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.DurationofPain != event) {
                this._EmergencySpecialityObject.DurationofPain = event;
            }
        }
    }

    public onPainDetailChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PainDetail != event) {
                this._EmergencySpecialityObject.PainDetail = event;
            }
        }
    }

    public onPainFaceScaleChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PainFaceScale != event) {
                this._EmergencySpecialityObject.PainFaceScale = event;
            }
        }
    }

    public onPainFrequencyChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PainFrequency != event) {
                this._EmergencySpecialityObject.PainFrequency = event;
            }
        }
    }
    public onPainPlacesChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PainPlaces != event) {
                this._EmergencySpecialityObject.PainPlaces = event;
            }
        }
    }
    public onPainQualityChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PainQuality != event) {
                this._EmergencySpecialityObject.PainQuality = event;
            }
        }
    }

    public onPainQualityDescriptionChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PainQualityDescription != event) {
                this._EmergencySpecialityObject.PainQualityDescription = event;
            }
        }
    }

    public onPainTimeChanged(event): void {
        if (event != null) {
            if (this._EmergencySpecialityObject != null && this._EmergencySpecialityObject.PainTime != event) {
                this._EmergencySpecialityObject.PainTime = event;
            }
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.GeneralEvaluationGood, "Value", this.__ttObject, "GeneralEvaluationGood");
        redirectProperty(this.GeneralEvaluationMedium, "Value", this.__ttObject, "GeneralEvaluationMedium");
        redirectProperty(this.GeneralEvaluationBad, "Value", this.__ttObject, "GeneralEvaluationBad");
        redirectProperty(this.GeneralEvaluationPainly, "Value", this.__ttObject, "GeneralEvaluationPainly");
        redirectProperty(this.GeneralEvaluationDispneic, "Value", this.__ttObject, "GeneralEvaluationDispneic");
        redirectProperty(this.GeneralEvaluationDehidrate, "Value", this.__ttObject, "GeneralEvaluationDehidrate");
        redirectProperty(this.GeneralEvaluationSweaty, "Value", this.__ttObject, "GeneralEvaluationSweaty");
        redirectProperty(this.GeneralEvaluationCold, "Value", this.__ttObject, "GeneralEvaluationCold");
        redirectProperty(this.cbxGebe, "Value", this.__ttObject, "IsPregnant");
        redirectProperty(this.cbxTetanoz, "Value", this.__ttObject, "TetanusVaccine");
        redirectProperty(this.ttdatetimepicker1, "Value", this.__ttObject, "LastMenstrualPeriod");
        redirectProperty(this.ContinuousDrugs, "Rtf", this.__ttObject, "ContinuousDrugs");
        redirectProperty(this.LastEatingInfo, "Text", this.__ttObject, "LastEatingInfo");
        redirectProperty(this.Habits, "Rtf", this.__ttObject, "Habits");
        redirectProperty(this.AllergyDescription, "Rtf", this.__ttObject, "AllergyDescription");
        redirectProperty(this.TriageList, "SelectedObject", this.__ttObject, "Triage");
        redirectProperty(this.PsychologicalEvaluationNormal, "Value", this.__ttObject, "PsychologicalEvaluationNormal");
        redirectProperty(this.PsychologicalEvaluationAngry, "Value", this.__ttObject, "PsychologicalEvaluationAngry");
        redirectProperty(this.PsychologicalEvaluationSad, "Value", this.__ttObject, "PsychologicalEvaluationSad");
        redirectProperty(this.PsychologicalEvaluationWorried, "Value", this.__ttObject, "PsychologicalEvalWorried");
        redirectProperty(this.PsychologicalEvaluationIrrelevant, "Value", this.__ttObject, "PsychologicalEvalIrrelevant");
        redirectProperty(this.PsychologicalEvaluationOther, "Text", this.__ttObject, "PsychologicalEvaluationOther");
        redirectProperty(this.ComplaintDuration, "Text", this.__ttObject, "ComplaintDuration");
        redirectProperty(this.ttrichtextboxcontrol1, "Rtf", this.__ttObject, "ComplaintDescription");
        redirectProperty(this.ttrichtextboxcontrol2, "Rtf", this.__ttObject, "PatientHistoryDescription");
        redirectProperty(this.PainDetail, "Text", this.__ttObject, "PainDetail");
        redirectProperty(this.PainTime, "Text", this.__ttObject, "PainTime");
        redirectProperty(this.DurationofPain, "Text", this.__ttObject, "DurationofPain");
        redirectProperty(this.AchingSide, "Text", this.__ttObject, "AchingSide");
        redirectProperty(this.PainQualityDescription, "Text", this.__ttObject, "PainQualityDescription");
        redirectProperty(this.PainFaceScale, "Value", this.__ttObject, "PainFaceScale");
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");

        redirectProperty(this.Weakness, "Value", this.__ttObject, "Weakness");
        redirectProperty(this.Temperature, "Value", this.__ttObject, "Temperature");
        redirectProperty(this.Pruritus, "Value", this.__ttObject, "Pruritus");
        redirectProperty(this.WeightGain, "Value", this.__ttObject, "WeightGain");
        redirectProperty(this.Sweating, "Value", this.__ttObject, "Sweating");
        redirectProperty(this.Anorexia, "Value", this.__ttObject, "Anorexia");
        redirectProperty(this.WeightLoss, "Value", this.__ttObject, "WeightLoss");
        redirectProperty(this.ThroatPain, "Value", this.__ttObject, "ThroatPain");
        redirectProperty(this.Hoarseness, "Value", this.__ttObject, "Hoarseness");
        redirectProperty(this.NasalDrainage, "Value", this.__ttObject, "NasalDrainage");
        redirectProperty(this.NeckMass, "Value", this.__ttObject, "NeckMass");
        redirectProperty(this.EarPain, "Value", this.__ttObject, "EarPain");
        redirectProperty(this.EarDrainage, "Value", this.__ttObject, "EarDrainage");
        redirectProperty(this.Tinnitus, "Value", this.__ttObject, "Tinnitus");
        redirectProperty(this.ChestPain, "Value", this.__ttObject, "ChestPain");
        redirectProperty(this.Tachycardia, "Value", this.__ttObject, "Tachycardia");
        redirectProperty(this.PND, "Value", this.__ttObject, "PND");
        redirectProperty(this.Orthopnea, "Value", this.__ttObject, "Orthopnea");
        redirectProperty(this.Edema, "Value", this.__ttObject, "Edema");
        redirectProperty(this.RhythmDisorder, "Value", this.__ttObject, "RhythmDisorder");
        redirectProperty(this.LaboredBreathing, "Value", this.__ttObject, "LaboredBreathing");
        redirectProperty(this.Cough, "Value", this.__ttObject, "Cough");
        redirectProperty(this.Sputum, "Value", this.__ttObject, "Sputum");
        redirectProperty(this.Hemoptysis, "Value", this.__ttObject, "Hemoptysis");
        redirectProperty(this.Cyanosis, "Value", this.__ttObject, "Cyanosis");
        redirectProperty(this.Wheezing, "Value", this.__ttObject, "Wheezing");
        redirectProperty(this.NightSweating, "Value", this.__ttObject, "NightSweating");
        redirectProperty(this.Nausea, "Value", this.__ttObject, "Nausea");
        redirectProperty(this.ThrowingUp, "Value", this.__ttObject, "ThrowingUp");
        redirectProperty(this.AbdominalPain, "Value", this.__ttObject, "AbdominalPain");
        redirectProperty(this.Diarrhea, "Value", this.__ttObject, "Diarrhea");
        redirectProperty(this.Constipation, "Value", this.__ttObject, "Constipation");
        redirectProperty(this.Melena, "Value", this.__ttObject, "Melena");
        redirectProperty(this.StomachPain, "Value", this.__ttObject, "StomachPain");
        redirectProperty(this.DoubleVision, "Value", this.__ttObject, "DoubleVision");
        redirectProperty(this.EyePain, "Value", this.__ttObject, "EyePain");
        redirectProperty(this.VisionDefect, "Value", this.__ttObject, "VisionDefect");
        redirectProperty(this.Dismenore, "Value", this.__ttObject, "Dismenore");
        redirectProperty(this.VaginalDrainage, "Value", this.__ttObject, "VaginalDrainage");
        redirectProperty(this.VaginalBleeding, "Value", this.__ttObject, "VaginalBleeding");
        redirectProperty(this.BreastPain, "Value", this.__ttObject, "BreastPain");
        redirectProperty(this.BreastMass, "Value", this.__ttObject, "BreastMass");
        redirectProperty(this.BreastDrainage, "Value", this.__ttObject, "BreastDrainage");
        redirectProperty(this.HeadAche, "Value", this.__ttObject, "HeadAche");
        redirectProperty(this.ConsciousnessLoss, "Value", this.__ttObject, "ConsciousnessLoss");
        redirectProperty(this.Imbalance, "Value", this.__ttObject, "Imbalance");
        redirectProperty(this.Attack, "Value", this.__ttObject, "Attack");
        redirectProperty(this.Contraction, "Value", this.__ttObject, "Contraction");
        redirectProperty(this.Paresthaesia, "Value", this.__ttObject, "Paresthaesia");
        redirectProperty(this.Dizziness, "Value", this.__ttObject, "Dizziness");
        redirectProperty(this.Prostration, "Value", this.__ttObject, "Prostration");
        redirectProperty(this.NeckPain, "Value", this.__ttObject, "NeckPain");
        redirectProperty(this.BackPain, "Value", this.__ttObject, "BackPain");
        redirectProperty(this.LumbarPain, "Value", this.__ttObject, "LumbarPain");
        redirectProperty(this.JointPain, "Value", this.__ttObject, "JointPain");
        redirectProperty(this.JointSwelling, "Value", this.__ttObject, "JointSwelling");
        redirectProperty(this.MovementLoss, "Value", this.__ttObject, "MovementLoss");
        redirectProperty(this.MorningMovementLoss, "Value", this.__ttObject, "MorningMovementLoss");
        redirectProperty(this.NoInfoForPhysocology, "Value", this.__ttObject, "NoInfoForPhysocology");
        redirectProperty(this.Hallucination, "Value", this.__ttObject, "Hallucination");
        redirectProperty(this.BehaviourLoss, "Value", this.__ttObject, "BehaviourLoss");
        redirectProperty(this.NoInfoForMan, "Value", this.__ttObject, "NoInfoForMan");
        redirectProperty(this.PenileDischarge, "Value", this.__ttObject, "PenileDischarge");
        redirectProperty(this.TestisPain, "Value", this.__ttObject, "TestisPain");
        redirectProperty(this.NoInfoForHormon, "Value", this.__ttObject, "NoInfoForHormon");
        redirectProperty(this.Galactore, "Value", this.__ttObject, "Galactore");
        redirectProperty(this.Hirsutusmus, "Value", this.__ttObject, "Hirsutusmus");
        redirectProperty(this.PainPlace, "Text", this.__ttObject, "PainPlace");
        redirectProperty(this.PainDegree, "Text", this.__ttObject, "PainDegree");
        redirectProperty(this.PainPeriod, "Text", this.__ttObject, "PainPeriod");
        redirectProperty(this.FaceScala, "Text", this.__ttObject, "FaceScala");
        redirectProperty(this.TotalScore, "Value", this.__ttObject, "TotalScore");
    }

    public initFormControls(): void {
        this.txtAlcoholPromile = new TTVisual.TTTextBox();
        this.txtAlcoholPromile.Name = "txtAlcoholPromile";
        this.txtAlcoholPromile.TabIndex = 209;

        this.lblAlcohol = new TTVisual.TTLabel();
        this.lblAlcohol.Text = i18n("M10730", "Alkol promil oranı");
        this.lblAlcohol.Name = "lblAlcohol";
        this.lblAlcohol.TabIndex = 208;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        this.ttdatetimepicker1.TabIndex = 207;

        this.ttgroupbox7 = new TTVisual.TTGroupBox();
        this.ttgroupbox7.Text = i18n("M14822", "Glasgow Koma Değerlendirme");
        this.ttgroupbox7.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox7.Name = "ttgroupbox7";
        this.ttgroupbox7.TabIndex = 5;

        this.labelEyes = new TTVisual.TTLabel();
        this.labelEyes.Text = i18n("M14956", "Gözler");
        this.labelEyes.Name = "labelEyes";
        this.labelEyes.TabIndex = 11;

        this.Eyes = new TTVisual.TTObjectListBox();
        this.Eyes.ListDefName = "GKSEyesListDefinition";
        this.Eyes.Name = "Eyes";
        this.Eyes.TabIndex = 2;

        this.labelOralAnswer = new TTVisual.TTLabel();
        this.labelOralAnswer.Text = i18n("M22212", "Sözel Cevap");
        this.labelOralAnswer.Name = "labelOralAnswer";
        this.labelOralAnswer.TabIndex = 7;

        this.OralAnswer = new TTVisual.TTObjectListBox();
        this.OralAnswer.ListDefName = "GKSOralAnswerListDefinition";
        this.OralAnswer.Name = "OralAnswer";
        this.OralAnswer.TabIndex = 3;

        this.labelMotorAnswer = new TTVisual.TTLabel();
        this.labelMotorAnswer.Text = i18n("M19140", "Motor Cevap");
        this.labelMotorAnswer.Name = "labelMotorAnswer";
        this.labelMotorAnswer.TabIndex = 13;

        this.MotorAnswer = new TTVisual.TTObjectListBox();
        this.MotorAnswer.ListDefName = "GKSMotorAnswerListDefinition";
        this.MotorAnswer.Name = "MotorAnswer";
        this.MotorAnswer.TabIndex = 4;

        this.labelTotalScore = new TTVisual.TTLabel();
        this.labelTotalScore.Text = i18n("M23518", "Toplam Puan");
        this.labelTotalScore.Name = "labelTotalScore";
        this.labelTotalScore.TabIndex = 5;

        this.TotalScore = new TTVisual.TTEnumComboBox();
        this.TotalScore.DataTypeName = "GlaskowComaScaleScoreEnum";
        this.TotalScore.BackColor = "#F0F0F0";
        this.TotalScore.Enabled = false;
        this.TotalScore.Name = "TotalScore";
        this.TotalScore.TabIndex = 1;

        this.ttgroupbox16 = new TTVisual.TTGroupBox();
        this.ttgroupbox16.Text = i18n("M10576", "Ağrı Değerlendirme");
        this.ttgroupbox16.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox16.Name = "ttgroupbox16";
        this.ttgroupbox16.TabIndex = 4;

        this.ttgroupbox17 = new TTVisual.TTGroupBox();
        this.ttgroupbox17.Text = "GLASKOW KOMA SKALASI";
        this.ttgroupbox17.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox17.Name = "ttgroupbox17";
        this.ttgroupbox17.TabIndex = 4;

        this.FaceScala = new TTVisual.TTTextBox();
        this.FaceScala.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.FaceScala.Name = "FaceScala";
        this.FaceScala.TabIndex = 2;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M10586", "Ağrı Yeri");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 1;

        this.PainPlace = new TTVisual.TTTextBox();
        this.PainPlace.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PainPlace.Name = "PainPlace";
        this.PainPlace.TabIndex = 0;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M10581", "Ağrı Niteliği");
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 1;

        this.PainDegree = new TTVisual.TTTextBox();
        this.PainDegree.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PainDegree.Name = "PainDegree";
        this.PainDegree.TabIndex = 0;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M10583", "Ağrı Sıklığı");
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 1;

        this.PainPeriod = new TTVisual.TTTextBox();
        this.PainPeriod.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PainPeriod.Name = "PainPeriod";
        this.PainPeriod.TabIndex = 0;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M24745", "Yüz Skalası");
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 1;

        this.GenelDurum = new TTVisual.TTGroupBox();
        this.GenelDurum.Text = i18n("M14687", "Genel Durum");
        this.GenelDurum.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GenelDurum.Name = "GenelDurum";
        this.GenelDurum.TabIndex = 3;

        this.GeneralEvaluationGood = new TTVisual.TTCheckBox();
        this.GeneralEvaluationGood.Value = false;
        this.GeneralEvaluationGood.Text = i18n("M16967", "İyi");
        this.GeneralEvaluationGood.Name = "GeneralEvaluationGood";
        this.GeneralEvaluationGood.TabIndex = 1;

        this.GeneralEvaluationCold = new TTVisual.TTCheckBox();
        this.GeneralEvaluationCold.Value = false;
        this.GeneralEvaluationCold.Text = i18n("M21997", "Soğuk");
        this.GeneralEvaluationCold.Name = "GeneralEvaluationCold";
        this.GeneralEvaluationCold.TabIndex = 1;
        this.GeneralEvaluationCold.IsTitleLeft = true;


        this.GeneralEvaluationSweaty = new TTVisual.TTCheckBox();
        this.GeneralEvaluationSweaty.Value = false;
        this.GeneralEvaluationSweaty.Text = i18n("M23196", "Terli");
        this.GeneralEvaluationSweaty.Name = "GeneralEvaluationSweaty";
        this.GeneralEvaluationSweaty.TabIndex = 1;
        this.GeneralEvaluationSweaty.IsTitleLeft = true;


        this.GeneralEvaluationDehidrate = new TTVisual.TTCheckBox();
        this.GeneralEvaluationDehidrate.Value = false;
        this.GeneralEvaluationDehidrate.Text = "Dehidrate";
        this.GeneralEvaluationDehidrate.Name = "GeneralEvaluationDehidrate";
        this.GeneralEvaluationDehidrate.TabIndex = 1;
        this.GeneralEvaluationDehidrate.IsTitleLeft = true;


        this.GeneralEvaluationDispneic = new TTVisual.TTCheckBox();
        this.GeneralEvaluationDispneic.Value = false;
        this.GeneralEvaluationDispneic.Text = "Dispneik";
        this.GeneralEvaluationDispneic.IsTitleLeft = true;
        this.GeneralEvaluationDispneic.Name = "GeneralEvaluationDispneic";
        this.GeneralEvaluationDispneic.TabIndex = 1;

        this.GeneralEvaluationPainly = new TTVisual.TTCheckBox();
        this.GeneralEvaluationPainly.Value = false;
        this.GeneralEvaluationPainly.IsTitleLeft = true;
        this.GeneralEvaluationPainly.Text = i18n("M10588", "Ağrılı");
        this.GeneralEvaluationPainly.Name = "GeneralEvaluationPainly";
        this.GeneralEvaluationPainly.TabIndex = 1;

        this.GeneralEvaluationBad = new TTVisual.TTCheckBox();
        this.GeneralEvaluationBad.Value = false;
        this.GeneralEvaluationBad.Text = i18n("M17846", "Kötü");
        this.GeneralEvaluationBad.Name = "GeneralEvaluationBad";
        this.GeneralEvaluationBad.TabIndex = 1;

        this.GeneralEvaluationMedium = new TTVisual.TTCheckBox();
        this.GeneralEvaluationMedium.Value = false;
        this.GeneralEvaluationMedium.Text = i18n("M19754", "Orta");
        this.GeneralEvaluationMedium.Name = "GeneralEvaluationMedium";
        this.GeneralEvaluationMedium.TabIndex = 1;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M14676", "Genel");
        this.ttgroupbox1.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 2;

        this.Weakness = new TTVisual.TTCheckBox();
        this.Weakness.Value = false;
        this.Weakness.Text = i18n("M15096", "Halsizlik");
        this.Weakness.Name = "Weakness";
        this.Weakness.TabIndex = 1;
        this.Weakness.IsTitleLeft = true;


        this.Temperature = new TTVisual.TTCheckBox();
        this.Temperature.Value = false;
        this.Temperature.Text = i18n("M11237", "Ateş");
        this.Temperature.Name = "Temperature";
        this.Temperature.TabIndex = 1;
        this.Temperature.IsTitleLeft = true;

        this.Anorexia = new TTVisual.TTCheckBox();
        this.Anorexia.Value = false;
        this.Anorexia.Text = i18n("M16962", "İştahsızlık");
        this.Anorexia.Name = "Anorexia";
        this.Anorexia.TabIndex = 1;
        this.Anorexia.IsTitleLeft = true;

        this.WeightLoss = new TTVisual.TTCheckBox();
        this.WeightLoss.Value = false;
        this.WeightLoss.Text = i18n("M17563", "Kilo Kaybı");
        this.WeightLoss.Name = "WeightLoss";
        this.WeightLoss.TabIndex = 1;
        this.WeightLoss.IsTitleLeft = true;

        this.WeightGain = new TTVisual.TTCheckBox();
        this.WeightGain.Value = false;
        this.WeightGain.Text = i18n("M17561", "Kilo Artışı");
        this.WeightGain.Name = "WeightGain";
        this.WeightGain.TabIndex = 1;
        this.WeightGain.IsTitleLeft = true;

        this.Pruritus = new TTVisual.TTCheckBox();
        this.Pruritus.Value = false;
        this.Pruritus.Text = i18n("M17344", "Kaşıntı");
        this.Pruritus.Name = "Pruritus";
        this.Pruritus.TabIndex = 1;
        this.Pruritus.IsTitleLeft = true;

        this.Sweating = new TTVisual.TTCheckBox();
        this.Sweating.Value = false;
        this.Sweating.Text = i18n("M23195", "Terleme");
        this.Sweating.Name = "Sweating";
        this.Sweating.TabIndex = 1;
        this.Sweating.IsTitleLeft = true;

        this.ttgroupbox2 = new TTVisual.TTGroupBox();
        this.ttgroupbox2.Text = i18n("M11586", "Baş Boyun/Göz");
        this.ttgroupbox2.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox2.Name = "ttgroupbox2";
        this.ttgroupbox2.TabIndex = 2;

        this.ThroatPain = new TTVisual.TTCheckBox();
        this.ThroatPain.Value = false;
        this.ThroatPain.Text = i18n("M11964", "Boğaz Ağrısı");
        this.ThroatPain.Name = "ThroatPain";
        this.ThroatPain.TabIndex = 1;
        this.ThroatPain.IsTitleLeft = true;

        this.Hoarseness = new TTVisual.TTCheckBox();
        this.Hoarseness.Value = false;
        this.Hoarseness.Text = i18n("M21678", "Ses Kısıklığı");
        this.Hoarseness.Name = "Hoarseness";
        this.Hoarseness.TabIndex = 1;
        this.Hoarseness.IsTitleLeft = true;

        this.NasalDrainage = new TTVisual.TTCheckBox();
        this.NasalDrainage.Value = false;
        this.NasalDrainage.Text = "Geniz Akıntısı";
        this.NasalDrainage.Name = "NasalDrainage";
        this.NasalDrainage.TabIndex = 1;
        this.NasalDrainage.IsTitleLeft = true;
        //mmmmmmmm
        this.NeckMass = new TTVisual.TTCheckBox();
        this.NeckMass.Value = false;
        this.NeckMass.Text = i18n("M12000", "Boyunda Kitle");
        this.NeckMass.Name = "NeckMass";
        this.NeckMass.TabIndex = 1;
        this.NeckMass.IsTitleLeft = true;


        this.EarPain = new TTVisual.TTCheckBox();
        this.EarPain.Value = false;
        this.EarPain.Text = i18n("M17883", "Kulak Ağrısı");
        this.EarPain.Name = "EarPain";
        this.EarPain.TabIndex = 1;
        this.EarPain.IsTitleLeft = true;

        this.EarDrainage = new TTVisual.TTCheckBox();
        this.EarDrainage.Value = false;
        this.EarDrainage.Text = i18n("M17884", "Kulak Akıntısı");
        this.EarDrainage.Name = "EarDrainage";
        this.EarDrainage.TabIndex = 1;
        this.EarDrainage.IsTitleLeft = true;

        this.Tinnitus = new TTVisual.TTCheckBox();
        this.Tinnitus.Value = false;
        this.Tinnitus.Text = i18n("M17887", "Kulakta Çınlama");
        this.Tinnitus.Name = "Tinnitus";
        this.Tinnitus.TabIndex = 1;
        this.Tinnitus.IsTitleLeft = true;

        this.ttgroupbox3 = new TTVisual.TTGroupBox();
        this.ttgroupbox3.Text = "KVS";
        this.ttgroupbox3.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox3.Name = "ttgroupbox3";
        this.ttgroupbox3.TabIndex = 2;

        this.ChestPain = new TTVisual.TTCheckBox();
        this.ChestPain.Value = false;
        this.ChestPain.Text = i18n("M14847", "Göğüs Ağrısı");
        this.ChestPain.Name = "ChestPain";
        this.ChestPain.TabIndex = 1;
        this.ChestPain.IsTitleLeft = true;

        this.RhythmDisorder = new TTVisual.TTCheckBox();
        this.RhythmDisorder.Value = false;
        this.RhythmDisorder.Text = i18n("M21050", "Ritim Bozukluğu");
        this.RhythmDisorder.Name = "RhythmDisorder";
        this.RhythmDisorder.TabIndex = 1;
        this.RhythmDisorder.IsTitleLeft = true;

        this.Tachycardia = new TTVisual.TTCheckBox();
        this.Tachycardia.Value = false;
        this.Tachycardia.Text = i18n("M12342", "Çarpıntı");
        this.Tachycardia.Name = "Tachycardia";
        this.Tachycardia.TabIndex = 1;
        this.Tachycardia.IsTitleLeft = true;

        this.PND = new TTVisual.TTCheckBox();
        this.PND.Value = false;
        this.PND.Text = "PND";
        this.PND.Name = "PND";
        this.PND.TabIndex = 1;
        this.PND.IsTitleLeft = true;

        this.Orthopnea = new TTVisual.TTCheckBox();
        this.Orthopnea.Value = false;
        this.Orthopnea.Text = "Ortopne";
        this.Orthopnea.Name = "Orthopnea";
        this.Orthopnea.TabIndex = 1;
        this.Orthopnea.IsTitleLeft = true;

        this.Edema = new TTVisual.TTCheckBox();
        this.Edema.Value = false;
        this.Edema.Text = i18n("M19841", "Ödem");
        this.Edema.Name = "Edema";
        this.Edema.TabIndex = 1;
        this.Edema.IsTitleLeft = true;

        this.ttgroupbox4 = new TTVisual.TTGroupBox();
        this.ttgroupbox4.Text = i18n("M22027", "Solunum");
        this.ttgroupbox4.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox4.Name = "ttgroupbox4";
        this.ttgroupbox4.TabIndex = 2;

        this.LaboredBreathing = new TTVisual.TTCheckBox();
        this.LaboredBreathing.Value = false;
        this.LaboredBreathing.Text = i18n("M19438", "Nefes Darlığı");
        this.LaboredBreathing.Name = "LaboredBreathing";
        this.LaboredBreathing.TabIndex = 1;
        this.LaboredBreathing.IsTitleLeft = true;

        this.Wheezing = new TTVisual.TTCheckBox();
        this.Wheezing.Value = false;
        this.Wheezing.Text = i18n("M15768", "Hırıltılı Solunum");
        this.Wheezing.Name = "Wheezing";
        this.Wheezing.TabIndex = 1;
        this.Wheezing.IsTitleLeft = true;

        this.Cough = new TTVisual.TTCheckBox();
        this.Cough.Value = false;
        this.Cough.Text = i18n("M19907", "Öksürük");
        this.Cough.Name = "Cough";
        this.Cough.TabIndex = 1;
        this.Cough.IsTitleLeft = true;

        this.Sputum = new TTVisual.TTCheckBox();
        this.Sputum.Value = false;
        this.Sputum.Text = i18n("M11499", "Balgam");
        this.Sputum.Name = "Sputum";
        this.Sputum.TabIndex = 1;
        this.Sputum.IsTitleLeft = true;

        this.Hemoptysis = new TTVisual.TTCheckBox();
        this.Hemoptysis.Value = false;
        this.Hemoptysis.Text = "Hemoptizi";
        this.Hemoptysis.Name = "Hemoptysis";
        this.Hemoptysis.TabIndex = 1;
        this.Hemoptysis.IsTitleLeft = true;

        this.NightSweating = new TTVisual.TTCheckBox();
        this.NightSweating.Value = false;
        this.NightSweating.Text = i18n("M14587", "Gece Terlemesi");
        this.NightSweating.Name = "NightSweating";
        this.NightSweating.TabIndex = 1;
        this.NightSweating.IsTitleLeft = true;

        this.Cyanosis = new TTVisual.TTCheckBox();
        this.Cyanosis.Value = false;
        this.Cyanosis.Text = i18n("M21958", "Siyanoz");
        this.Cyanosis.Name = "Cyanosis";
        this.Cyanosis.TabIndex = 1;
        this.Cyanosis.IsTitleLeft = true;

        this.ttgroupbox5 = new TTVisual.TTGroupBox();
        this.ttgroupbox5.Text = "GİS";
        this.ttgroupbox5.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox5.Name = "ttgroupbox5";
        this.ttgroupbox5.TabIndex = 2;

        this.Nausea = new TTVisual.TTCheckBox();
        this.Nausea.Value = false;
        this.Nausea.Text = i18n("M12102", "Bulantı");
        this.Nausea.Name = "Nausea";
        this.Nausea.TabIndex = 1;
        this.Nausea.IsTitleLeft = true;

        this.ThrowingUp = new TTVisual.TTCheckBox();
        this.ThrowingUp.Value = false;
        this.ThrowingUp.Text = i18n("M18118", "Kusma");
        this.ThrowingUp.Name = "ThrowingUp";
        this.ThrowingUp.TabIndex = 1;
        this.ThrowingUp.IsTitleLeft = true;

        this.StomachPain = new TTVisual.TTCheckBox();
        this.StomachPain.Value = false;
        this.StomachPain.Text = i18n("M19024", "Midede Yanma");
        this.StomachPain.Name = "StomachPain";
        this.StomachPain.TabIndex = 1;
        this.StomachPain.IsTitleLeft = true;

        this.AbdominalPain = new TTVisual.TTCheckBox();
        this.AbdominalPain.Value = false;
        this.AbdominalPain.Text = i18n("M17302", "Karın Ağrısı");
        this.AbdominalPain.Name = "AbdominalPain";
        this.AbdominalPain.TabIndex = 1;
        this.AbdominalPain.IsTitleLeft = true;

        this.Diarrhea = new TTVisual.TTCheckBox();
        this.Diarrhea.Value = false;
        this.Diarrhea.Text = i18n("M16577", "İshal");
        this.Diarrhea.Name = "Diarrhea";
        this.Diarrhea.TabIndex = 1;
        this.Diarrhea.IsTitleLeft = true;

        this.Constipation = new TTVisual.TTCheckBox();
        this.Constipation.Value = false;
        this.Constipation.Text = i18n("M17006", "Kabızlık");
        this.Constipation.Name = "Constipation";
        this.Constipation.TabIndex = 1;
        this.Constipation.IsTitleLeft = true;

        this.Melena = new TTVisual.TTCheckBox();
        this.Melena.Value = false;
        this.Melena.Text = "Melena";
        this.Melena.Name = "Melena";
        this.Melena.TabIndex = 1;
        this.Melena.IsTitleLeft = true;

        this.ttgroupbox6 = new TTVisual.TTGroupBox();
        this.ttgroupbox6.Text = i18n("M14938", "Göz");
        this.ttgroupbox6.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox6.Name = "ttgroupbox6";
        this.ttgroupbox6.TabIndex = 2;

        this.VisionDefect = new TTVisual.TTCheckBox();
        this.VisionDefect.Value = false;
        this.VisionDefect.Text = i18n("M14923", "Görme Bozukluğu");
        this.VisionDefect.Name = "VisionDefect";
        this.VisionDefect.TabIndex = 1;
        this.VisionDefect.IsTitleLeft = true;

        this.DoubleVision = new TTVisual.TTCheckBox();
        this.DoubleVision.Value = false;
        this.DoubleVision.Text = i18n("M12390", "Çift Görme");
        this.DoubleVision.Name = "DoubleVision";
        this.DoubleVision.TabIndex = 1;
        this.DoubleVision.IsTitleLeft = true;

        this.EyePain = new TTVisual.TTCheckBox();
        this.EyePain.Value = false;
        this.EyePain.Text = i18n("M14940", "Göz Ağrısı");
        this.EyePain.Name = "EyePain";
        this.EyePain.TabIndex = 1;
        this.EyePain.IsTitleLeft = true;

        this.ttgroupbox8 = new TTVisual.TTGroupBox();
        this.ttgroupbox8.Text = i18n("M17061", "Kadın");
        this.ttgroupbox8.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox8.Name = "ttgroupbox8";
        this.ttgroupbox8.TabIndex = 2;

        this.Dismenore = new TTVisual.TTCheckBox();
        this.Dismenore.Value = false;
        this.Dismenore.Text = "Dismenore";
        this.Dismenore.Name = "Dismenore";
        this.Dismenore.TabIndex = 1;
        this.Dismenore.IsTitleLeft = true;

        this.VaginalDrainage = new TTVisual.TTCheckBox();
        this.VaginalDrainage.Value = false;
        this.VaginalDrainage.Text = i18n("M24012", "Vajinal Akıntı");
        this.VaginalDrainage.Name = "VaginalDrainage";
        this.VaginalDrainage.TabIndex = 1;
        this.VaginalDrainage.IsTitleLeft = true;

        this.VaginalBleeding = new TTVisual.TTCheckBox();
        this.VaginalBleeding.Value = false;
        this.VaginalBleeding.Text = i18n("M24014", "Vajinal Kanama");
        this.VaginalBleeding.Name = "VaginalBleeding";
        this.VaginalBleeding.TabIndex = 1;
        this.VaginalBleeding.IsTitleLeft = true;

        this.ttgroupbox9 = new TTVisual.TTGroupBox();
        this.ttgroupbox9.Text = i18n("M13837", "Erkek");
        this.ttgroupbox9.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox9.Name = "ttgroupbox9";
        this.ttgroupbox9.TabIndex = 2;

        this.NoInfoForMan = new TTVisual.TTCheckBox();
        this.NoInfoForMan.Value = false;
        this.NoInfoForMan.Text = i18n("M20112", "Özellik Yok");
        this.NoInfoForMan.Name = "NoInfoForMan";
        this.NoInfoForMan.TabIndex = 1;
        this.NoInfoForMan.IsTitleLeft = true;

        this.TestisPain = new TTVisual.TTCheckBox();
        this.TestisPain.Value = false;
        this.TestisPain.Text = i18n("M23276", "Testis Ağrısı");
        this.TestisPain.Name = "TestisPain";
        this.TestisPain.TabIndex = 1;
        this.TestisPain.IsTitleLeft = true;

        this.PenileDischarge = new TTVisual.TTCheckBox();
        this.PenileDischarge.Value = false;
        this.PenileDischarge.Text = i18n("M20294", "Penil Akıntı");
        this.PenileDischarge.Name = "PenileDischarge";
        this.PenileDischarge.TabIndex = 1;
        this.PenileDischarge.IsTitleLeft = true;

        this.ttgroupbox10 = new TTVisual.TTGroupBox();
        this.ttgroupbox10.Text = i18n("M18861", "Meme");
        this.ttgroupbox10.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox10.Name = "ttgroupbox10";
        this.ttgroupbox10.TabIndex = 2;

        this.BreastPain = new TTVisual.TTCheckBox();
        this.BreastPain.Value = false;
        this.BreastPain.Text = i18n("M18867", "Memede Ağrı");
        this.BreastPain.Name = "BreastPain";
        this.BreastPain.TabIndex = 1;
        this.BreastPain.IsTitleLeft = true;

        this.BreastDrainage = new TTVisual.TTCheckBox();
        this.BreastDrainage.Value = false;
        this.BreastDrainage.Text = i18n("M18868", "Memede Akıntı");
        this.BreastDrainage.Name = "BreastDrainage";
        this.BreastDrainage.TabIndex = 1;
        this.BreastDrainage.IsTitleLeft = true;

        this.BreastMass = new TTVisual.TTCheckBox();
        this.BreastMass.Value = false;
        this.BreastMass.Text = i18n("M18869", "Memede Kitle");
        this.BreastMass.Name = "BreastMass";
        this.BreastMass.TabIndex = 1;
        this.BreastMass.IsTitleLeft = true;

        this.ttgroupbox11 = new TTVisual.TTGroupBox();
        this.ttgroupbox11.Text = "Hormonal";
        this.ttgroupbox11.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox11.Name = "ttgroupbox11";
        this.ttgroupbox11.TabIndex = 2;

        this.NoInfoForHormon = new TTVisual.TTCheckBox();
        this.NoInfoForHormon.Value = false;
        this.NoInfoForHormon.Text = i18n("M20112", "Özellik Yok");
        this.NoInfoForHormon.Name = "NoInfoForHormon";
        this.NoInfoForHormon.TabIndex = 1;
        this.NoInfoForHormon.IsTitleLeft = true;

        this.Galactore = new TTVisual.TTCheckBox();
        this.Galactore.Value = false;
        this.Galactore.Text = "Galaktore";
        this.Galactore.Name = "Galactore";
        this.Galactore.TabIndex = 1;
        this.Galactore.IsTitleLeft = true;

        this.Hirsutusmus = new TTVisual.TTCheckBox();
        this.Hirsutusmus.Value = false;
        this.Hirsutusmus.Text = "Hirsutusmus";
        this.Hirsutusmus.Name = "Hirsutusmus";
        this.Hirsutusmus.TabIndex = 1;
        this.Hirsutusmus.IsTitleLeft = true;

        this.ttgroupbox12 = new TTVisual.TTGroupBox();
        this.ttgroupbox12.Text = i18n("M21884", "Sinir");
        this.ttgroupbox12.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox12.Name = "ttgroupbox12";
        this.ttgroupbox12.TabIndex = 2;

        this.HeadAche = new TTVisual.TTCheckBox();
        this.HeadAche.Value = false;
        this.HeadAche.Text = i18n("M11584", "Baş Ağrısı");
        this.HeadAche.Name = "HeadAche";
        this.HeadAche.TabIndex = 1;
        this.HeadAche.IsTitleLeft = true;

        this.Dizziness = new TTVisual.TTCheckBox();
        this.Dizziness.Value = false;
        this.Dizziness.Text = i18n("M11588", "Baş Dönmesi");
        this.Dizziness.Name = "Dizziness";
        this.Dizziness.TabIndex = 1;
        this.Dizziness.IsTitleLeft = true;

        this.ConsciousnessLoss = new TTVisual.TTCheckBox();
        this.ConsciousnessLoss.Value = false;
        this.ConsciousnessLoss.Text = i18n("M11806", "Bilinç Kaybı");
        this.ConsciousnessLoss.Name = "ConsciousnessLoss";
        this.ConsciousnessLoss.TabIndex = 1;
        this.ConsciousnessLoss.IsTitleLeft = true;

        this.Imbalance = new TTVisual.TTCheckBox();
        this.Imbalance.Value = false;
        this.Imbalance.Text = i18n("M12609", "Dengesizlik");
        this.Imbalance.Name = "Imbalance";
        this.Imbalance.TabIndex = 1;
        this.Imbalance.IsTitleLeft = true;

        this.Attack = new TTVisual.TTCheckBox();
        this.Attack.Value = false;
        this.Attack.Text = i18n("M19491", "Nöbet");
        this.Attack.Name = "Attack";
        this.Attack.TabIndex = 1;
        this.Attack.IsTitleLeft = true;

        this.Contraction = new TTVisual.TTCheckBox();
        this.Contraction.Value = false;
        this.Contraction.Text = i18n("M17342", "Kasılma");
        this.Contraction.Name = "Contraction";
        this.Contraction.TabIndex = 1;
        this.Contraction.IsTitleLeft = true;

        this.Paresthaesia = new TTVisual.TTCheckBox();
        this.Paresthaesia.Value = false;
        this.Paresthaesia.Text = i18n("M23819", "Uyuşma");
        this.Paresthaesia.Name = "Paresthaesia";
        this.Paresthaesia.TabIndex = 1;
        this.Paresthaesia.IsTitleLeft = true;

        this.Prostration = new TTVisual.TTCheckBox();
        this.Prostration.Value = false;
        this.Prostration.Text = i18n("M18128", "Kuvvetsizlik");
        this.Prostration.Name = "Prostration";
        this.Prostration.TabIndex = 1;
        this.Prostration.IsTitleLeft = true;

        this.ttgroupbox13 = new TTVisual.TTGroupBox();
        this.ttgroupbox13.Text = i18n("M17334", "Kas İskelet");
        this.ttgroupbox13.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox13.Name = "ttgroupbox13";
        this.ttgroupbox13.TabIndex = 2;

        this.NeckPain = new TTVisual.TTCheckBox();
        this.NeckPain.Value = false;
        this.NeckPain.Text = i18n("M11996", "Boyun Ağrısı");
        this.NeckPain.Name = "NeckPain";
        this.NeckPain.TabIndex = 1;
        this.NeckPain.IsTitleLeft = true;

        this.BackPain = new TTVisual.TTCheckBox();
        this.BackPain.Value = false;
        this.BackPain.Text = i18n("M21827", "Sırt Ağrısı ");
        this.BackPain.Name = "BackPain";
        this.BackPain.TabIndex = 1;
        this.BackPain.IsTitleLeft = true;

        this.LumbarPain = new TTVisual.TTCheckBox();
        this.LumbarPain.Value = false;
        this.LumbarPain.Text = i18n("M11731", "Bel Ağrısı");
        this.LumbarPain.Name = "LumbarPain";
        this.LumbarPain.TabIndex = 1;
        this.LumbarPain.IsTitleLeft = true;

        this.JointPain = new TTVisual.TTCheckBox();
        this.JointPain.Value = false;
        this.JointPain.Text = i18n("M13545", "Eklem Ağrısı");
        this.JointPain.Name = "JointPain";
        this.JointPain.TabIndex = 1;
        this.JointPain.IsTitleLeft = true;

        this.JointSwelling = new TTVisual.TTCheckBox();
        this.JointSwelling.Value = false;
        this.JointSwelling.Text = i18n("M13547", "Eklem Şişliği");
        this.JointSwelling.Name = "JointSwelling";
        this.JointSwelling.TabIndex = 1;
        this.JointSwelling.IsTitleLeft = true;

        this.MorningMovementLoss = new TTVisual.TTCheckBox();
        this.MorningMovementLoss.Value = false;
        this.MorningMovementLoss.Text = i18n("M21095", "Sabah Tutkunluğu");
        this.MorningMovementLoss.Name = "MorningMovementLoss";
        this.MorningMovementLoss.TabIndex = 1;
        this.MorningMovementLoss.IsTitleLeft = true;

        this.MovementLoss = new TTVisual.TTCheckBox();
        this.MovementLoss.Value = false;
        this.MovementLoss.Text = "Hareket Kıtlığı";
        this.MovementLoss.Name = "MovementLoss";
        this.MovementLoss.TabIndex = 1;
        this.MovementLoss.IsTitleLeft = true;

        this.ttgroupbox15 = new TTVisual.TTGroupBox();
        this.ttgroupbox15.Text = i18n("M21062", "Ruhsal Değerlendirme");
        this.ttgroupbox15.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox15.Name = "ttgroupbox15";
        this.ttgroupbox15.TabIndex = 3;

        this.PsychologicalEvaluationOther = new TTVisual.TTTextBox();
        this.PsychologicalEvaluationOther.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PsychologicalEvaluationOther.Name = "PsychologicalEvaluationOther";
        this.PsychologicalEvaluationOther.TabIndex = 3;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M12780", "Diğer");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 2;

        this.PsychologicalEvaluationNormal = new TTVisual.TTCheckBox();
        this.PsychologicalEvaluationNormal.Value = false;
        this.PsychologicalEvaluationNormal.Text = "Normal";
        this.PsychologicalEvaluationNormal.Name = "PsychologicalEvaluationNormal";
        this.PsychologicalEvaluationNormal.TabIndex = 1;
        this.PsychologicalEvaluationNormal.IsTitleLeft = true;

        this.PsychologicalEvaluationIrrelevant = new TTVisual.TTCheckBox();
        this.PsychologicalEvaluationIrrelevant.Value = false;
        this.PsychologicalEvaluationIrrelevant.Text = i18n("M17435", "Kayıtsız");
        this.PsychologicalEvaluationIrrelevant.Name = "PsychologicalEvaluationIrrelevant";
        this.PsychologicalEvaluationIrrelevant.TabIndex = 1;
        this.PsychologicalEvaluationIrrelevant.IsTitleLeft = true;

        this.PsychologicalEvaluationWorried = new TTVisual.TTCheckBox();
        this.PsychologicalEvaluationWorried.Value = false;
        this.PsychologicalEvaluationWorried.Text = i18n("M13718", "Endişeli");
        this.PsychologicalEvaluationWorried.Name = "PsychologicalEvaluationWorried";
        this.PsychologicalEvaluationWorried.TabIndex = 1;
        this.PsychologicalEvaluationWorried.IsTitleLeft = true;

        this.PsychologicalEvaluationSad = new TTVisual.TTCheckBox();
        this.PsychologicalEvaluationSad.Value = false;
        this.PsychologicalEvaluationSad.Text = i18n("M24001", "Üzüntülü");
        this.PsychologicalEvaluationSad.Name = "PsychologicalEvaluationSad";
        this.PsychologicalEvaluationSad.TabIndex = 1;
        this.PsychologicalEvaluationSad.IsTitleLeft = true;

        this.PsychologicalEvaluationAngry = new TTVisual.TTCheckBox();
        this.PsychologicalEvaluationAngry.Value = false;
        this.PsychologicalEvaluationAngry.Text = i18n("M19896", "Öfkeli");
        this.PsychologicalEvaluationAngry.Name = "PsychologicalEvaluationAngry";
        this.PsychologicalEvaluationAngry.TabIndex = 1;
        this.PsychologicalEvaluationAngry.IsTitleLeft = true;

        this.ttgroupbox18 = new TTVisual.TTGroupBox();
        this.ttgroupbox18.Text = i18n("M21064", "Ruhsal Durum");
        this.ttgroupbox18.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox18.Name = "ttgroupbox18";
        this.ttgroupbox18.TabIndex = 2;

        this.NoInfoForPhysocology = new TTVisual.TTCheckBox();
        this.NoInfoForPhysocology.Value = false;
        this.NoInfoForPhysocology.Text = i18n("M20112", "Özellik Yok");
        this.NoInfoForPhysocology.Name = "NoInfoForPhysocology";
        this.NoInfoForPhysocology.TabIndex = 1;
        this.NoInfoForPhysocology.IsTitleLeft = true;

        this.Hallucination = new TTVisual.TTCheckBox();
        this.Hallucination.Value = false;
        this.Hallucination.Text = "Halusinasyon";
        this.Hallucination.Name = "Hallucination";
        this.Hallucination.TabIndex = 1;
        this.Hallucination.IsTitleLeft = true;

        this.BehaviourLoss = new TTVisual.TTCheckBox();
        this.BehaviourLoss.Value = false;
        this.BehaviourLoss.Text = i18n("M12499", "Davranış Eksikliği");
        this.BehaviourLoss.Name = "BehaviourLoss";
        this.BehaviourLoss.TabIndex = 1;
        this.BehaviourLoss.IsTitleLeft = true;

        this.cbxGebe = new TTVisual.TTCheckBox();
        this.cbxGebe.Value = false;
        this.cbxGebe.Text = i18n("M14557", "Gebelik Durumu");
        this.cbxGebe.Name = "cbxGebe";
        this.cbxGebe.TabIndex = 240;

        this.cbxTetanoz = new TTVisual.TTCheckBox();
        this.cbxTetanoz.Value = false;
        this.cbxTetanoz.Text = i18n("M14557", "Gebelik Durumu");
        this.cbxTetanoz.Name = "cbxTetanoz";
        this.cbxTetanoz.TabIndex = 206;
        this.cbxTetanoz.IsTitleLeft = true;

        this.lblHabit = new TTVisual.TTLabel();
        this.lblHabit.Text = i18n("M10722", "Alışkanlıklar");
        this.lblHabit.Name = "lblHabit";
        this.lblHabit.TabIndex = 204;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M22070", "Son Yemek Bilgisi");
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 201;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M23584", "Triaj Kodu");
        this.ttlabel6.BackColor = "#DCDCDC";
        this.ttlabel6.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 29;

        this.labelLastMenstrualPeriod = new TTVisual.TTLabel();
        this.labelLastMenstrualPeriod.Text = i18n("M22037", "Son Adet Tarihi");
        this.labelLastMenstrualPeriod.Name = "labelLastMenstrualPeriod";
        this.labelLastMenstrualPeriod.TabIndex = 43;

        this.LastEatingInfo = new TTVisual.TTTextBox();
        this.LastEatingInfo.Multiline = true;
        this.LastEatingInfo.Name = "LastEatingInfo";
        this.LastEatingInfo.TabIndex = 200;

        this.ContinuousDrugs = new TTVisual.TTRichTextBoxControl();
        this.ContinuousDrugs.DisplayText = i18n("M17890", "Kullandığı İlaçlar");
        this.ContinuousDrugs.TemplateGroupName = "CONTINUOUSDRUGS";
        this.ContinuousDrugs.BackColor = "#FFFFFF";
        this.ContinuousDrugs.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ContinuousDrugs.Name = "ContinuousDrugs";

        this.Habits = new TTVisual.TTRichTextBoxControl();
        this.Habits.DisplayText = i18n("M10722", "Alışkanlıklar");
        this.Habits.TemplateGroupName = "HABITS";
        this.Habits.BackColor = "#FFFFFF";
        this.Habits.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Habits.Name = "Habits";

        this.AllergyDescription = new TTVisual.TTRichTextBoxControl();
        this.AllergyDescription.DisplayText = i18n("M10686", "Alerji Öyküsü");
        this.AllergyDescription.TemplateGroupName = "ALLERGYDESCRIPTION";
        this.AllergyDescription.BackColor = "#FFFFFF";
        this.AllergyDescription.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AllergyDescription.Name = "AllergyDescription";

        this.DiagnosisTab = new TTVisual.TTTabControl();
        this.DiagnosisTab.Name = "DiagnosisTab";
        this.DiagnosisTab.TabIndex = 0;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 2;
        this.tttabpage1.Text = i18n("M15275", "Hasta Muayene Bilgileri ");
        this.tttabpage1.Name = "tttabpage1";

        this.ComplaintDurationType = new TTVisual.TTEnumComboBox();
        this.ComplaintDurationType.DataTypeName = "UnitOfTimeEnum";
        this.ComplaintDurationType.Name = "ComplaintDurationType";
        this.ComplaintDurationType.TabIndex = 31;

        this.ComplaintDuration = new TTVisual.TTTextBox();
        this.ComplaintDuration.Name = "ComplaintDuration";
        this.ComplaintDuration.TabIndex = 30;

        this.Complaint = new TTVisual.TTObjectListBox();
        this.Complaint.ListDefName = "ComplaintListDefinition";
        this.Complaint.Name = "Complaint";
        this.Complaint.TabIndex = 3;

        this.ttrichtextboxcontrol1 = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrol1.DisplayText = i18n("M22483", "Şikayet");
        this.ttrichtextboxcontrol1.TemplateGroupName = "EMERGENCYCOMPLAINT";
        this.ttrichtextboxcontrol1.BackColor = "#FFFFFF";
        this.ttrichtextboxcontrol1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttrichtextboxcontrol1.Name = "ttrichtextboxcontrol1";
        this.ttrichtextboxcontrol1.TabIndex = 2;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M22483", "Şikayet");
        this.ttlabel7.BackColor = "#DCDCDC";
        this.ttlabel7.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 29;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M22490", "Şikayet Süresi");
        this.ttlabel9.BackColor = "#DCDCDC";
        this.ttlabel9.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 29;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M20117", "Özgeçmiş");
        this.ttlabel10.BackColor = "#DCDCDC";
        this.ttlabel10.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 29;

        this.PatientHistory = new TTVisual.TTObjectListBox();
        this.PatientHistory.ListDefName = "PatientHistoryListDefinition";
        this.PatientHistory.Name = "PatientHistory";
        this.PatientHistory.TabIndex = 3;

        this.ttrichtextboxcontrol2 = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrol2.DisplayText = i18n("M20117", "Özgeçmiş");
        this.ttrichtextboxcontrol2.TemplateGroupName = "EMERGENCYCOMPLAINT";
        this.ttrichtextboxcontrol2.BackColor = "#FFFFFF";
        this.ttrichtextboxcontrol2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttrichtextboxcontrol2.Name = "ttrichtextboxcontrol2";
        this.ttrichtextboxcontrol2.TabIndex = 2;

        this.TriageList = new TTVisual.TTObjectListBox();
        this.TriageList.ListDefName = "SKRSTRIAJKODUList";
        this.TriageList.AutoCompleteDialogHeight = "250px";
        this.TriageList.Name = "TriageList";
        this.TriageList.TabIndex = 166;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = i18n("M23584", "Triaj Kodu");
        this.ttlabel11.BackColor = "#DCDCDC";
        this.ttlabel11.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel11.ForeColor = "#000000";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 29;

        this.PainQuality = new TTVisual.TTObjectListBox();
        this.PainQuality.ListDefName = "PainQualityListDefinition";
        this.PainQuality.Name = "PainQuality";
        this.PainQuality.TabIndex = 20;

        this.PainFrequency = new TTVisual.TTObjectListBox();
        this.PainFrequency.ListDefName = "PainFrequencyListDefiniton";
        this.PainFrequency.Name = "PainFrequency";
        this.PainFrequency.TabIndex = 18;

        this.PainPlaces = new TTVisual.TTObjectListBox();
        this.PainPlaces.ListDefName = "PainPlaceListDefinition";
        this.PainPlaces.Name = "PainPlaces";
        this.PainPlaces.TabIndex = 16;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 14;

        this.PainFaceScale = new TTVisual.TTEnumComboBox();
        this.PainFaceScale.DataTypeName = "PainFaceScaleEnum";
        this.PainFaceScale.Name = "PainFaceScale";
        this.PainFaceScale.TabIndex = 12;

        this.PainQualityDescription = new TTVisual.TTTextBox();
        this.PainQualityDescription.Name = "PainQualityDescription";
        this.PainQualityDescription.TabIndex = 8;

        this.AchingSide = new TTVisual.TTTextBox();
        this.AchingSide.Name = "AchingSide";
        this.AchingSide.TabIndex = 6;

        this.DurationofPain = new TTVisual.TTTextBox();
        this.DurationofPain.Name = "DurationofPain";
        this.DurationofPain.TabIndex = 4;

        this.PainTime = new TTVisual.TTTextBox();
        this.PainTime.Name = "PainTime";
        this.PainTime.TabIndex = 2;


        this.PainDetail = new TTVisual.TTTextBox();
        this.PainDetail.Name = "PainDetail";
        this.PainDetail.TabIndex = 0;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 3;



        this.ttgroupbox7.Controls = [this.labelEyes, this.Eyes, this.labelOralAnswer, this.OralAnswer, this.labelMotorAnswer, this.MotorAnswer, this.labelTotalScore, this.TotalScore];
        this.ttgroupbox16.Controls = [this.FaceScala, this.ttlabel2, this.PainPlace, this.ttlabel3, this.PainDegree, this.ttlabel4, this.PainPeriod, this.ttlabel5];
        this.GenelDurum.Controls = [this.GeneralEvaluationGood, this.GeneralEvaluationCold, this.GeneralEvaluationSweaty, this.GeneralEvaluationDehidrate, this.GeneralEvaluationDispneic, this.GeneralEvaluationPainly, this.GeneralEvaluationBad, this.GeneralEvaluationMedium];
        this.ttgroupbox1.Controls = [this.Weakness, this.Anorexia, this.WeightLoss, this.WeightGain, this.Pruritus, this.Sweating];
        this.ttgroupbox2.Controls = [this.ThroatPain, this.Hoarseness, this.NasalDrainage, this.NeckMass, this.EarPain, this.EarDrainage, this.Tinnitus];
        this.ttgroupbox3.Controls = [this.ChestPain, this.RhythmDisorder, this.Tachycardia, this.PND, this.Orthopnea, this.Edema];
        this.ttgroupbox4.Controls = [this.LaboredBreathing, this.Wheezing, this.Cough, this.Sputum, this.Hemoptysis, this.NightSweating, this.Cyanosis];
        this.ttgroupbox5.Controls = [this.Nausea, this.ThrowingUp, this.StomachPain, this.AbdominalPain, this.Diarrhea, this.Constipation, this.Melena];
        this.ttgroupbox6.Controls = [this.VisionDefect, this.DoubleVision, this.EyePain];
        this.ttgroupbox8.Controls = [this.Dismenore, this.VaginalDrainage, this.VaginalBleeding];
        this.ttgroupbox9.Controls = [this.NoInfoForMan, this.TestisPain, this.PenileDischarge];
        this.ttgroupbox10.Controls = [this.BreastPain, this.BreastDrainage, this.BreastMass];
        this.ttgroupbox11.Controls = [this.NoInfoForHormon, this.Galactore, this.Hirsutusmus];
        this.ttgroupbox12.Controls = [this.HeadAche, this.Dizziness, this.ConsciousnessLoss, this.Imbalance, this.Attack, this.Contraction, this.Paresthaesia, this.Prostration];
        this.ttgroupbox13.Controls = [this.NeckPain, this.BackPain, this.LumbarPain, this.JointPain, this.JointSwelling, this.MorningMovementLoss, this.MovementLoss];
        this.ttgroupbox15.Controls = [this.PsychologicalEvaluationOther, this.ttlabel1, this.PsychologicalEvaluationNormal, this.PsychologicalEvaluationIrrelevant, this.PsychologicalEvaluationWorried, this.PsychologicalEvaluationSad, this.PsychologicalEvaluationAngry];
        this.ttgroupbox18.Controls = [this.NoInfoForPhysocology, this.Hallucination, this.BehaviourLoss];
        this.DiagnosisTab.Controls = [this.tttabpage1];
        this.tttabpage1.Controls = [this.ComplaintDurationType, this.ComplaintDuration, this.Complaint, this.ttrichtextboxcontrol1, this.ttlabel7, this.ttlabel9, this.ttlabel10, this.PatientHistory, this.ttrichtextboxcontrol2];
        //this.tttabcontrol1.Controls = [this.AllergyVaccination];
        this.Controls = [this.txtAlcoholPromile, this.lblAlcohol, this.ttdatetimepicker1, this.ttgroupbox7, this.labelEyes, this.Eyes, this.labelOralAnswer, this.OralAnswer, this.labelMotorAnswer, this.MotorAnswer, this.labelTotalScore, this.TotalScore, this.ttgroupbox16, this.FaceScala, this.ttlabel2, this.PainPlace, this.ttlabel3, this.PainDegree, this.ttlabel4, this.PainPeriod, this.ttlabel5, this.GenelDurum, this.GeneralEvaluationGood, this.GeneralEvaluationCold, this.GeneralEvaluationSweaty, this.GeneralEvaluationDehidrate, this.GeneralEvaluationDispneic, this.GeneralEvaluationPainly, this.GeneralEvaluationBad, this.GeneralEvaluationMedium, this.ttgroupbox1, this.Weakness, this.Anorexia, this.WeightLoss, this.WeightGain, this.Pruritus, this.Sweating, this.ttgroupbox2, this.ThroatPain, this.Hoarseness, this.NasalDrainage, this.NeckMass, this.EarPain, this.EarDrainage, this.Tinnitus, this.ttgroupbox3, this.ChestPain, this.RhythmDisorder, this.Tachycardia, this.PND, this.Orthopnea, this.Edema, this.ttgroupbox4, this.LaboredBreathing, this.Wheezing, this.Cough, this.Sputum, this.Hemoptysis, this.NightSweating, this.Cyanosis, this.ttgroupbox5, this.Nausea, this.ThrowingUp, this.StomachPain, this.AbdominalPain, this.Diarrhea, this.Constipation, this.Melena, this.ttgroupbox6, this.VisionDefect, this.DoubleVision, this.EyePain, this.ttgroupbox8, this.Dismenore, this.VaginalDrainage, this.VaginalBleeding, this.ttgroupbox9, this.NoInfoForMan, this.TestisPain, this.PenileDischarge, this.ttgroupbox10, this.BreastPain, this.BreastDrainage, this.BreastMass, this.ttgroupbox11, this.NoInfoForHormon, this.Galactore, this.Hirsutusmus, this.ttgroupbox12, this.HeadAche, this.Dizziness, this.ConsciousnessLoss, this.Imbalance, this.Attack, this.Contraction, this.Paresthaesia, this.Prostration, this.ttgroupbox13, this.NeckPain, this.BackPain, this.LumbarPain, this.JointPain, this.JointSwelling, this.MorningMovementLoss, this.MovementLoss, this.ttgroupbox15, this.PsychologicalEvaluationOther, this.ttlabel1, this.PsychologicalEvaluationNormal, this.PsychologicalEvaluationIrrelevant, this.PsychologicalEvaluationWorried, this.PsychologicalEvaluationSad, this.PsychologicalEvaluationAngry, this.ttgroupbox18, this.NoInfoForPhysocology, this.Hallucination, this.BehaviourLoss, this.cbxGebe, this.lblHabit, this.ttlabel8, this.ttlabel6, this.labelLastMenstrualPeriod, this.LastEatingInfo, this.DiagnosisTab, this.tttabpage1, this.ComplaintDurationType, this.ComplaintDuration, this.Complaint, this.ttrichtextboxcontrol1, this.ttlabel7, this.ttlabel9, this.ttlabel10, this.PatientHistory, this.ttrichtextboxcontrol2, this.ttlabel11, this.tttabcontrol1, this.Name, this.Reaction, this.Risk2, this.ttlabel14, this.labelAllergyInformation, this.Aşı, this.Geçerliliği, this.Risk];

    }


}
