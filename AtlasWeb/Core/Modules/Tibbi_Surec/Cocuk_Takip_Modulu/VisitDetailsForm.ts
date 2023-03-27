//$D1B541A6
import { Component, OnInit  } from '@angular/core';
import { VisitDetailsFormViewModel, VisitDetailsComponentInfoViewModel } from './VisitDetailsFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ChildGrowthVisits } from 'NebulaClient/Model/AtlasClientModel';
import { ChildBrainDevelopmentRiskFactors } from 'NebulaClient/Model/AtlasClientModel';
import { InfantRiskFactors } from 'NebulaClient/Model/AtlasClientModel';
import { ParentalActivitiesForPsychologicalDevelopment } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBebeginBeslenmeDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDemirLojistigiveDestegi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDVitaminiLojistigiveDestegi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGelisimTablosuBilgilerininSorgulanmasi } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';

@Component({
    selector: 'VisitDetailsForm',
    templateUrl: './VisitDetailsForm.html',
    providers: [MessageService]
})
export class VisitDetailsForm extends TTVisual.TTForm implements OnInit {
    chartTypes: string[] = ["spline", "stackedSpline", "fullStackedSpline"];
    showPopup: boolean;
    graphInfo: GraphInfo[];
    percentileInfo: any;
    AbdomenExaminationPhysicalExamination: TTVisual.ITTTextBox;
    AlcoholUseInFamilyChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    AmnioticFluidAbnormalitiesInfantRiskFactors: TTVisual.ITTCheckBoxColumn;
    AnalGenitalLocalExaminationPhysicalExamination: TTVisual.ITTTextBox;
    AnemiaChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    ArmCircle: TTVisual.ITTTextBox;
    Assessments: TTVisual.ITTTextBox;
    BabyComplaintChildGrowthComplaintInfo: TTVisual.ITTTextBox;
    BMI: TTVisual.ITTTextBox;
    CardiovascularSystemPhysicalExamination: TTVisual.ITTTextBox;
    ChildAbuseSuspicionChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    ChildBrainDevelopmentRiskFactors: TTVisual.ITTGrid;
    ComplaintInfo: TTVisual.ITTTabPage;
    ComplaintStartDateChildGrowthComplaintInfo: TTVisual.ITTDateTimePicker;
    ConsanguineousMarriageInfantRiskFactors: TTVisual.ITTCheckBoxColumn;
    Crawling1MotorDevelopment: TTVisual.ITTCheckBox;
    Crawling2MotorDevelopment: TTVisual.ITTCheckBox;
    Crawling3MotorDevelopment: TTVisual.ITTCheckBox;
    CrawlingCheckAllMotorDevelopment: TTVisual.ITTCheckBox;
    DailyObservationsPhysicalExamination: TTVisual.ITTTextBox;
    Date: TTVisual.ITTDateTimePicker;
    DetailsPhysicalExamination: TTVisual.ITTTextBox;
    DownSyndromeInFamilyChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    ExtremitiesPhysicalExamination: TTVisual.ITTTextBox;
    FamilyHistoryChildGrowthComplaintInfo: TTVisual.ITTTextBox;
    FatherAlcoholUseChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    FatherAnxietyDisorderChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    FatherDepressionChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    FatherDrugAddictionChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    FatherHasHereditaryIllnessInfantRiskFactors: TTVisual.ITTCheckBoxColumn;
    FatherHemoglobinopathyCarrierInfantRiskFactors: TTVisual.ITTCheckBoxColumn;
    FatherMentalDeficiencyChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    FatherMentalDisorderChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    FeetDeformitiesInfantRiskFactors: TTVisual.ITTCheckBoxColumn;
    GKDInfantRiskFactors: TTVisual.ITTCheckBoxColumn;
    HeadCircle: TTVisual.ITTTextBox;
    HeadNeckThyroidInfoPhysicalExamination: TTVisual.ITTTextBox;
    Height: TTVisual.ITTTextBox;
    HereditaryHearingLossInfantRiskFactors: TTVisual.ITTCheckBoxColumn;
    InfantGrowthStatusInfo: TTVisual.ITTObjectListBox;
    InfantNutritionalStatus: TTVisual.ITTObjectListBox;
    InfantRiskFactors: TTVisual.ITTGrid;
    IronSupplementationInfo: TTVisual.ITTObjectListBox;
    IrregularHouseholdIncomeChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    labelAbdomenExaminationPhysicalExamination: TTVisual.ITTLabel;
    labelAnalGenitalLocalExaminationPhysicalExamination: TTVisual.ITTLabel;
    labelArmCircle: TTVisual.ITTLabel;
    labelAssessments: TTVisual.ITTLabel;
    labelBabyComplaintChildGrowthComplaintInfo: TTVisual.ITTLabel;
    labelBMI: TTVisual.ITTLabel;
    labelCardiovascularSystemPhysicalExamination: TTVisual.ITTLabel;
    labelComplaintStartDateChildGrowthComplaintInfo: TTVisual.ITTLabel;
    labelDailyObservationsPhysicalExamination: TTVisual.ITTLabel;
    labelDate: TTVisual.ITTLabel;
    labelDetailsPhysicalExamination: TTVisual.ITTLabel;
    labelExtremitiesPhysicalExamination: TTVisual.ITTLabel;
    labelFamilyHistoryChildGrowthComplaintInfo: TTVisual.ITTLabel;
    labelHeadCircle: TTVisual.ITTLabel;
    labelHeadNeckThyroidInfoPhysicalExamination: TTVisual.ITTLabel;
    labelHeight: TTVisual.ITTLabel;
    labelInfantGrowthStatusInfo: TTVisual.ITTLabel;
    labelInfantNutritionalStatus: TTVisual.ITTLabel;
    labelIronSupplementationInfo: TTVisual.ITTLabel;
    labelMeasurementType: TTVisual.ITTLabel;
    labelMotorAssesmentDateMotorDevelopment: TTVisual.ITTLabel;
    labelNatalHistoryChildGrowthComplaintInfo: TTVisual.ITTLabel;
    labelNeurologicalExaminationPhysicalExamination: TTVisual.ITTLabel;
    labelNotes: TTVisual.ITTLabel;
    labelOedema: TTVisual.ITTLabel;
    labelPostnatalHistoryChildGrowthComplaintInfo: TTVisual.ITTLabel;
    labelPrenatalHistoryChildGrowthComplaintInfo: TTVisual.ITTLabel;
    labelQuestion1NurseVisitsInfo: TTVisual.ITTLabel;
    labelQuestion2NurseVisitsInfo: TTVisual.ITTLabel;
    labelQuestion3NurseVisitsInfo: TTVisual.ITTLabel;
    labelQuestion4NurseVisitsInfo: TTVisual.ITTLabel;
    labelQuestion5NurseVisitsInfo: TTVisual.ITTLabel;
    labelQuestion6NurseVisitsInfo: TTVisual.ITTLabel;
    labelQuestion7NurseVisitsInfo: TTVisual.ITTLabel;
    labelRespiratorySystemPhysicalExamination: TTVisual.ITTLabel;
    labelResUserNurseVisitsInfo: TTVisual.ITTLabel;
    labelSubscapular: TTVisual.ITTLabel;
    labelSuggestionsNurseVisitsInfo: TTVisual.ITTLabel;
    labelSuggestionsPhysicalExamination: TTVisual.ITTLabel;
    labelTricepsSkinfold: TTVisual.ITTLabel;
    labelVisitDate: TTVisual.ITTLabel;
    labelVitaminDSupplementationInfo: TTVisual.ITTLabel;
    labelWeight: TTVisual.ITTLabel;
    MaternalSmokingChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    MeasurementInfo: TTVisual.ITTTabPage;
    MeasurementType: TTVisual.ITTEnumComboBox;
    MotherAbuseSuspicionChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    MotherAlcoholUseChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    MotherAnxietyDisorderChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    MotherDepressionChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    MotherDrugAddictionChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    MotherHasHereditaryIllnessInfantRiskFactors: TTVisual.ITTCheckBoxColumn;
    MotherHemoglobinopathyCarrierInfantRiskFactors: TTVisual.ITTCheckBoxColumn;
    MotherMentalDeficiencyChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    MotherMentalDisorderChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    MotherXRayExposureInfantRiskFactors: TTVisual.ITTCheckBoxColumn;
    MotorAssesmentDateMotorDevelopment: TTVisual.ITTDateTimePicker;
    MotorImprovementInfo: TTVisual.ITTTabPage;
    NatalHistoryChildGrowthComplaintInfo: TTVisual.ITTTextBox;
    NeurologicalExaminationPhysicalExamination: TTVisual.ITTTextBox;
    NoHealthInsuranceChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    NoneParentalActivitiesForPsychologicalDevelopment: TTVisual.ITTCheckBoxColumn;
    Notes: TTVisual.ITTTextBox;
    NurseVisitInfo: TTVisual.ITTTabPage;
    Oedema: TTVisual.ITTEnumComboBox;
    OldChildBrainDevelopmentRiskFactors: TTVisual.ITTGrid;
    OldInfantRiskFactors: TTVisual.ITTGrid;
    OldParentalActivitiesForPsychologicalDevelopment: TTVisual.ITTGrid;
    OtherParentalActivitiesForPsychologicalDevelopment: TTVisual.ITTCheckBoxColumn;
    OtherPoorFeedingSignsChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    OutsideActivitiesParentalActivitiesForPsychologicalDevelopment: TTVisual.ITTCheckBoxColumn;
    ParentalActivities: TTVisual.ITTTabPage;
    ParentalActivitiesForPsychologicalDevelopment: TTVisual.ITTGrid;
    PhysicalExaminationInfo: TTVisual.ITTTabPage;
    PlaytimeParentalActivitiesForPsychologicalDevelopment: TTVisual.ITTCheckBoxColumn;
    PoorMaternalWeightGainChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    PoorWeightGainChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    PostnatalHistoryChildGrowthComplaintInfo: TTVisual.ITTTextBox;
    PovertyChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    PrenatalHistoryChildGrowthComplaintInfo: TTVisual.ITTTextBox;
    Question1NurseVisitsInfo: TTVisual.ITTTextBox;
    Question2NurseVisitsInfo: TTVisual.ITTTextBox;
    Question3NurseVisitsInfo: TTVisual.ITTTextBox;
    Question4NurseVisitsInfo: TTVisual.ITTTextBox;
    Question5NurseVisitsInfo: TTVisual.ITTTextBox;
    Question6NurseVisitsInfo: TTVisual.ITTTextBox;
    Question7NurseVisitsInfo: TTVisual.ITTTextBox;
    ReadingParentalActivitiesForPsychologicalDevelopment: TTVisual.ITTCheckBoxColumn;
    RegularBondingTimeParentalActivitiesForPsychologicalDevelopment: TTVisual.ITTCheckBoxColumn;
    RespiratorySystemPhysicalExamination: TTVisual.ITTTextBox;
    ResUserNurseVisitsInfo: TTVisual.ITTObjectListBox;
    RiskFactors: TTVisual.ITTTabPage;
    Seperator1: TTVisual.ITTGroupBox;
    Seperator2: TTVisual.ITTGroupBox;
    Seperator3: TTVisual.ITTGroupBox;
    Seperator4: TTVisual.ITTGroupBox;
    Seperator5: TTVisual.ITTGroupBox;
    Seperator6: TTVisual.ITTGroupBox;
    SingingParentalActivitiesForPsychologicalDevelopment: TTVisual.ITTCheckBoxColumn;
    SittingWoSupport1MotorDevelopment: TTVisual.ITTCheckBox;
    SittingWoSupport2MotorDevelopment: TTVisual.ITTCheckBox;
    SittingWoSupportCheckAllMotorDevelopment: TTVisual.ITTCheckBox;
    SKRSBebeginBeyinGlsEtkRisklerChildBrainDevelopmentRiskFactors: TTVisual.ITTListBoxColumn;
    SKRSBebekteRiskFaktorleriInfantRiskFactors: TTVisual.ITTListBoxColumn;
    SKRSEbeveynPsikoGlsmDestkAktvParentalActivitiesForPsychologicalDevelopment: TTVisual.ITTListBoxColumn;
    SmokingInFamilyChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    StandingAlone1MotorDevelopment: TTVisual.ITTCheckBox;
    StandingAlone2MotorDevelopment: TTVisual.ITTCheckBox;
    StandingAlone3MotorDevelopment: TTVisual.ITTCheckBox;
    StandingAlone4MotorDevelopment: TTVisual.ITTCheckBox;
    StandingAloneCheckAllMotorDevelopment: TTVisual.ITTCheckBox;
    StandingWAssistance1MotorDevelopment: TTVisual.ITTCheckBox;
    StandingWAssistance2MotorDevelopment: TTVisual.ITTCheckBox;
    StandingWAssistance3MotorDevelopment: TTVisual.ITTCheckBox;
    StandingWAssistanceCheckAllMotorDevelopment: TTVisual.ITTCheckBox;
    StorytellingParentalActivitiesForPsychologicalDevelopment: TTVisual.ITTCheckBoxColumn;
    Subscapular: TTVisual.ITTTextBox;
    SuggestionsNurseVisitsInfo: TTVisual.ITTTextBox;
    SuggestionsPhysicalExamination: TTVisual.ITTTextBox;
    TalkingParentalActivitiesForPsychologicalDevelopment: TTVisual.ITTCheckBoxColumn;
    TricepsSkinfold: TTVisual.ITTTextBox;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    ttobjectlistbox2: TTVisual.ITTObjectListBox;
    ttobjectlistbox3: TTVisual.ITTObjectListBox;
    ttobjectlistbox4: TTVisual.ITTObjectListBox;
    ttobjectlistbox5: TTVisual.ITTObjectListBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    UndesiredPregnancyChildBrainDevelopmentRiskFactors: TTVisual.ITTCheckBoxColumn;
    VisitDate: TTVisual.ITTDateTimePicker;
    VitaminDSupplementationInfo: TTVisual.ITTObjectListBox;
    WalkingAlone1MotorDevelopment: TTVisual.ITTCheckBox;
    WalkingAlone2MotorDevelopment: TTVisual.ITTCheckBox;
    WalkingAlone3MotorDevelopment: TTVisual.ITTCheckBox;
    WalkingAloneCheckAllMotorDevelopment: TTVisual.ITTCheckBox;
    WalkingWAssistance1MotorDevelopment: TTVisual.ITTCheckBox;
    WalkingWAssistance2MotorDevelopment: TTVisual.ITTCheckBox;
    WalkingWAssistance3MotorDevelopment: TTVisual.ITTCheckBox;
    WalkingWAssistance4MotorDevelopment: TTVisual.ITTCheckBox;
    WalkingWAssistanceCheckAllMotorDevelopment: TTVisual.ITTCheckBox;
    Weight: TTVisual.ITTTextBox;
    public ChildBrainDevelopmentRiskFactorsColumns = [];
    public InfantRiskFactorsColumns = [];
    public OldChildBrainDevelopmentRiskFactorsColumns = [];
    public OldInfantRiskFactorsColumns = [];
    public OldParentalActivitiesForPsychologicalDevelopmentColumns = [];
    public ParentalActivitiesForPsychologicalDevelopmentColumns = [];
    public visitDetailsFormViewModel: VisitDetailsFormViewModel = new VisitDetailsFormViewModel();
    public get _ChildGrowthVisits(): ChildGrowthVisits {
        return this._TTObject as ChildGrowthVisits;
    }
    private VisitDetailsForm_DocumentUrl: string = '/api/ChildGrowthVisitsService/VisitDetailsForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('CHILDGROWTHVISITS', 'VisitDetailsForm');
        this._DocumentServiceUrl = this.VisitDetailsForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
        this.graphInfo = graphInfo;
        let emptyArray: any;
        this.percentileInfo = new Array<any>();
    }


    // ***** Method declarations start *****

    private async CrawlingCheckAllMotorDevelopment_CheckedChanged(): Promise<void> {
        if (((this.CrawlingCheckAllMotorDevelopment)).Checked) {
            ((this.Crawling1MotorDevelopment)).Checked = true;
            ((this.Crawling2MotorDevelopment)).Checked = true;
            ((this.Crawling3MotorDevelopment)).Checked = true;
        }
        else {
            ((this.Crawling1MotorDevelopment)).Checked = false;
            ((this.Crawling2MotorDevelopment)).Checked = false;
            ((this.Crawling3MotorDevelopment)).Checked = false;
        }
    }

    private async SittingWoSupportCheckAllMotorDevelopment_CheckedChanged(): Promise<void> {
        if (((this.SittingWoSupportCheckAllMotorDevelopment)).Checked) {
            ((this.SittingWoSupport1MotorDevelopment)).Checked = true;
            ((this.SittingWoSupport2MotorDevelopment)).Checked = true;
        }
        else {
            ((this.SittingWoSupport1MotorDevelopment)).Checked = false;
            ((this.SittingWoSupport2MotorDevelopment)).Checked = false;
        }
    }
    private async StandingAloneCheckAllMotorDevelopment_CheckedChanged(): Promise<void> {
        if (((this.StandingAloneCheckAllMotorDevelopment)).Checked) {
            ((this.StandingAlone1MotorDevelopment)).Checked = true;
            ((this.StandingAlone2MotorDevelopment)).Checked = true;
            ((this.StandingAlone3MotorDevelopment)).Checked = true;
            ((this.StandingAlone4MotorDevelopment)).Checked = true;
        }
        else {
            ((this.StandingAlone1MotorDevelopment)).Checked = false;
            ((this.StandingAlone2MotorDevelopment)).Checked = false;
            ((this.StandingAlone3MotorDevelopment)).Checked = false;
            ((this.StandingAlone4MotorDevelopment)).Checked = false;
        }
    }
    private async StandingWAssistanceCheckAllMotorDevelopment_CheckedChanged(): Promise<void> {
        if (((this.StandingWAssistanceCheckAllMotorDevelopment)).Checked) {
            ((this.StandingWAssistance1MotorDevelopment)).Checked = true;
            ((this.StandingWAssistance2MotorDevelopment)).Checked = true;
            ((this.StandingWAssistance3MotorDevelopment)).Checked = true;
        }
        else {
            ((this.StandingWAssistance1MotorDevelopment)).Checked = false;
            ((this.StandingWAssistance2MotorDevelopment)).Checked = false;
            ((this.StandingWAssistance3MotorDevelopment)).Checked = false;
        }
    }
    private async WalkingAloneCheckAllMotorDevelopment_CheckedChanged(): Promise<void> {
        if (((this.WalkingAloneCheckAllMotorDevelopment)).Checked) {
            ((this.WalkingAlone1MotorDevelopment)).Checked = true;
            ((this.WalkingAlone2MotorDevelopment)).Checked = true;
            ((this.WalkingAlone3MotorDevelopment)).Checked = true;
        }
        else {
            ((this.WalkingAlone1MotorDevelopment)).Checked = false;
            ((this.WalkingAlone2MotorDevelopment)).Checked = false;
            ((this.WalkingAlone3MotorDevelopment)).Checked = false;
        }
    }
    private async WalkingWAssistanceCheckAllMotorDevelopment_CheckedChanged(): Promise<void> {
        if (((this.WalkingWAssistanceCheckAllMotorDevelopment)).Checked) {
            ((this.WalkingWAssistance1MotorDevelopment)).Checked = true;
            ((this.WalkingWAssistance2MotorDevelopment)).Checked = true;
            ((this.WalkingWAssistance3MotorDevelopment)).Checked = true;
            ((this.WalkingWAssistance4MotorDevelopment)).Checked = true;
        }
        else {
            ((this.WalkingWAssistance1MotorDevelopment)).Checked = false;
            ((this.WalkingWAssistance2MotorDevelopment)).Checked = false;
            ((this.WalkingWAssistance3MotorDevelopment)).Checked = false;
            ((this.WalkingWAssistance4MotorDevelopment)).Checked = false;
        }
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChildGrowthVisits();
        this.visitDetailsFormViewModel = new VisitDetailsFormViewModel();
        this._ViewModel = this.visitDetailsFormViewModel;
        this.visitDetailsFormViewModel._ChildGrowthVisits = this._TTObject as ChildGrowthVisits;
        this.visitDetailsFormViewModel._ChildGrowthVisits.InfantNutritionalStatus = new SKRSBebeginBeslenmeDurumu();
        this.visitDetailsFormViewModel._ChildGrowthVisits.InfantGrowthStatusInfo = new SKRSGelisimTablosuBilgilerininSorgulanmasi();
        this.visitDetailsFormViewModel._ChildGrowthVisits.VitaminDSupplementationInfo = new SKRSDVitaminiLojistigiveDestegi();
        this.visitDetailsFormViewModel._ChildGrowthVisits.IronSupplementationInfo = new SKRSDemirLojistigiveDestegi();
        this.visitDetailsFormViewModel._ChildGrowthVisits.ResUser = new ResUser();
        this.visitDetailsFormViewModel._ChildGrowthVisits.InfantRiskFactors = new Array<InfantRiskFactors>();
        this.visitDetailsFormViewModel._ChildGrowthVisits.ChildBrainDevelopmentRiskFactors = new Array<ChildBrainDevelopmentRiskFactors>();
        this.visitDetailsFormViewModel._ChildGrowthVisits.ParentalActivitiesForPsychologicalDevelopment = new Array<ParentalActivitiesForPsychologicalDevelopment>();
    }

    protected loadViewModel() {
        let that = this;
        that.visitDetailsFormViewModel = this._ViewModel as VisitDetailsFormViewModel;
        that._TTObject = this.visitDetailsFormViewModel._ChildGrowthVisits;
        if (this.visitDetailsFormViewModel == null)
            this.visitDetailsFormViewModel = new VisitDetailsFormViewModel();
        if (this.visitDetailsFormViewModel._ChildGrowthVisits == null)
            this.visitDetailsFormViewModel._ChildGrowthVisits = new ChildGrowthVisits();
        let infantNutritionalStatusObjectID = that.visitDetailsFormViewModel._ChildGrowthVisits["InfantNutritionalStatus"];
        if (infantNutritionalStatusObjectID != null && (typeof infantNutritionalStatusObjectID === "string")) {
            let infantNutritionalStatus = that.visitDetailsFormViewModel.SKRSBebeginBeslenmeDurumus.find(o => o.ObjectID.toString() === infantNutritionalStatusObjectID.toString());
            if (infantNutritionalStatus) {
                that.visitDetailsFormViewModel._ChildGrowthVisits.InfantNutritionalStatus = infantNutritionalStatus;
            }
        }
        let infantGrowthStatusInfoObjectID = that.visitDetailsFormViewModel._ChildGrowthVisits["InfantGrowthStatusInfo"];
        if (infantGrowthStatusInfoObjectID != null && (typeof infantGrowthStatusInfoObjectID === "string")) {
            let infantGrowthStatusInfo = that.visitDetailsFormViewModel.SKRSGelisimTablosuBilgilerininSorgulanmasis.find(o => o.ObjectID.toString() === infantGrowthStatusInfoObjectID.toString());
            if (infantGrowthStatusInfo) {
                that.visitDetailsFormViewModel._ChildGrowthVisits.InfantGrowthStatusInfo = infantGrowthStatusInfo;
            }
        }
        let vitaminDSupplementationInfoObjectID = that.visitDetailsFormViewModel._ChildGrowthVisits["VitaminDSupplementationInfo"];
        if (vitaminDSupplementationInfoObjectID != null && (typeof vitaminDSupplementationInfoObjectID === "string")) {
            let vitaminDSupplementationInfo = that.visitDetailsFormViewModel.SKRSDVitaminiLojistigiveDestegis.find(o => o.ObjectID.toString() === vitaminDSupplementationInfoObjectID.toString());
            if (vitaminDSupplementationInfo) {
                that.visitDetailsFormViewModel._ChildGrowthVisits.VitaminDSupplementationInfo = vitaminDSupplementationInfo;
            }
        }
        let ironSupplementationInfoObjectID = that.visitDetailsFormViewModel._ChildGrowthVisits["IronSupplementationInfo"];
        if (ironSupplementationInfoObjectID != null && (typeof ironSupplementationInfoObjectID === "string")) {
            let ironSupplementationInfo = that.visitDetailsFormViewModel.SKRSDemirLojistigiveDestegis.find(o => o.ObjectID.toString() === ironSupplementationInfoObjectID.toString());
            if (ironSupplementationInfo) {
                that.visitDetailsFormViewModel._ChildGrowthVisits.IronSupplementationInfo = ironSupplementationInfo;
            }
        }
        let resUserObjectID = that.visitDetailsFormViewModel._ChildGrowthVisits["ResUser"];
        if (resUserObjectID != null && (typeof resUserObjectID === "string")) {
            let resUser = that.visitDetailsFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
            if (resUser) {
                that.visitDetailsFormViewModel._ChildGrowthVisits.ResUser = resUser;
            }
        }
        that.visitDetailsFormViewModel._ChildGrowthVisits.InfantRiskFactors = that.visitDetailsFormViewModel.InfantRiskFactorsGridList;
        for (let detailItem of that.visitDetailsFormViewModel.InfantRiskFactorsGridList) {
            let sKRSBebekteRiskFaktorleriObjectID = detailItem["SKRSBebekteRiskFaktorleri"];
            if (sKRSBebekteRiskFaktorleriObjectID != null && (typeof sKRSBebekteRiskFaktorleriObjectID === "string")) {
                let sKRSBebekteRiskFaktorleri = that.visitDetailsFormViewModel.SKRSBebekteRiskFaktorleris.find(o => o.ObjectID.toString() === sKRSBebekteRiskFaktorleriObjectID.toString());
                if (sKRSBebekteRiskFaktorleri) {
                    detailItem.SKRSBebekteRiskFaktorleri = sKRSBebekteRiskFaktorleri;
                }
            }
        }
        that.visitDetailsFormViewModel._ChildGrowthVisits.ChildBrainDevelopmentRiskFactors = that.visitDetailsFormViewModel.ChildBrainDevelopmentRiskFactorsGridList;
        for (let detailItem of that.visitDetailsFormViewModel.ChildBrainDevelopmentRiskFactorsGridList) {
            let sKRSBebeginBeyinGlsEtkRisklerObjectID = detailItem["SKRSBebeginBeyinGlsEtkRiskler"];
            if (sKRSBebeginBeyinGlsEtkRisklerObjectID != null && (typeof sKRSBebeginBeyinGlsEtkRisklerObjectID === "string")) {
                let sKRSBebeginBeyinGlsEtkRiskler = that.visitDetailsFormViewModel.SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRisklers.find(o => o.ObjectID.toString() === sKRSBebeginBeyinGlsEtkRisklerObjectID.toString());
                if (sKRSBebeginBeyinGlsEtkRiskler) {
                    detailItem.SKRSBebeginBeyinGlsEtkRiskler = sKRSBebeginBeyinGlsEtkRiskler;
                }
            }
        }
        that.visitDetailsFormViewModel._ChildGrowthVisits.ParentalActivitiesForPsychologicalDevelopment = that.visitDetailsFormViewModel.ParentalActivitiesForPsychologicalDevelopmentGridList;
        for (let detailItem of that.visitDetailsFormViewModel.ParentalActivitiesForPsychologicalDevelopmentGridList) {
            let sKRSEbeveynPsikoGlsmDestkAktvObjectID = detailItem["SKRSEbeveynPsikoGlsmDestkAktv"];
            if (sKRSEbeveynPsikoGlsmDestkAktvObjectID != null && (typeof sKRSEbeveynPsikoGlsmDestkAktvObjectID === "string")) {
                let sKRSEbeveynPsikoGlsmDestkAktv = that.visitDetailsFormViewModel.SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleris.find(o => o.ObjectID.toString() === sKRSEbeveynPsikoGlsmDestkAktvObjectID.toString());
                if (sKRSEbeveynPsikoGlsmDestkAktv) {
                    detailItem.SKRSEbeveynPsikoGlsmDestkAktv = sKRSEbeveynPsikoGlsmDestkAktv;
                }
            }
        }

    }

    async ngOnInit() {
        await this.load();
    }

    // ***** Method declarations start *****

    private Height_TextChanged(): void {

        this.CalculateBMI();
    }
    private Weight_TextChanged(): void {

        this.CalculateBMI();
    }
    public CalculateBMI(): void {
        if (this._ChildGrowthVisits.Weight != undefined && this._ChildGrowthVisits.Height != undefined && this._ChildGrowthVisits.Weight != null && this._ChildGrowthVisits.Height != null) {
            if (this._ChildGrowthVisits.Weight.toString() != "" && this._ChildGrowthVisits.Height.toString() != "") {
                let weight = this._ChildGrowthVisits.Weight;
                let height = this._ChildGrowthVisits.Height / 100;
                let bmi = weight / (height * height);
                this._ChildGrowthVisits.BMI = +bmi.toFixed(2);
            }

            if (this._ChildGrowthVisits.Weight.toString() == "" && this._ChildGrowthVisits.Height.toString() == "") {
                this._ChildGrowthVisits.BMI = 0;
            }
        }
    }

    // *****Method declarations end *****




    public onAbdomenExaminationPhysicalExaminationChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.AbdomenExamination != event) {
                this._ChildGrowthVisits.AbdomenExamination = event;
            }
        }
    }

    public onAnalGenitalLocalExaminationPhysicalExaminationChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.AnalGenitalLocalExamination != event) {
                this._ChildGrowthVisits.AnalGenitalLocalExamination = event;
            }
        }
    }

    public onArmCircleChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.ArmCircle != event) {
                this._ChildGrowthVisits.ArmCircle = event;
            }
        }
    }

    public onAssessmentsChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.Assessments != event) {
                this._ChildGrowthVisits.Assessments = event;
            }
        }
    }

    public onBabyComplaintChildGrowthComplaintInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.BabyComplaint != event) {
                this._ChildGrowthVisits.BabyComplaint = event;
            }
        }
    }

    public onBMIChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.BMI != event) {
                this._ChildGrowthVisits.BMI = event;
            }
        }
    }

    public onCardiovascularSystemPhysicalExaminationChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.CardiovascularSystem != event) {
                this._ChildGrowthVisits.CardiovascularSystem = event;
            }
        }
    }

    public onComplaintStartDateChildGrowthComplaintInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.ComplaintStartDate != event) {
                this._ChildGrowthVisits.ComplaintStartDate = event;
            }
        }
    }

    public onCrawling1MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.Crawling1 != event) {
                this._ChildGrowthVisits.Crawling1 = event;
            }
        }
    }

    public onCrawling2MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.Crawling2 != event) {
                this._ChildGrowthVisits.Crawling2 = event;
            }
        }
    }

    public onCrawling3MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.Crawling3 != event) {
                this._ChildGrowthVisits.Crawling3 = event;
            }
        }
    }

    public onDailyObservationsPhysicalExaminationChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.DailyObservations != event) {
                this._ChildGrowthVisits.DailyObservations = event;
            }
        }
    }

    public onDateChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.Date != event) {
                this._ChildGrowthVisits.Date = event;
            }
        }
    }

    public onDetailsPhysicalExaminationChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.Details != event) {
                this._ChildGrowthVisits.Details = event;
            }
        }
    }

    public onExtremitiesPhysicalExaminationChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.Extremities != event) {
                this._ChildGrowthVisits.Extremities = event;
            }
        }
    }

    public onFamilyHistoryChildGrowthComplaintInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.FamilyHistory != event) {
                this._ChildGrowthVisits.FamilyHistory = event;
            }
        }
    }

    public onHeadCircleChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.HeadCircle != event) {
                this._ChildGrowthVisits.HeadCircle = event;
            }
        }
    }

    public onHeadNeckThyroidInfoPhysicalExaminationChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.HeadNeckThyroidInfo != event) {
                this._ChildGrowthVisits.HeadNeckThyroidInfo = event;
            }
        }
    }

    public onHeightChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.Height != event) {
                this._ChildGrowthVisits.Height = event;
            }
        }
        this.Height_TextChanged();
    }

    public onInfantNutritionalStatusChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.InfantNutritionalStatus != event) {
                this._ChildGrowthVisits.InfantNutritionalStatus = event;
            }
        }
    }

    public onIronSupplementationInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.IronSupplementationInfo != event) {
                this._ChildGrowthVisits.IronSupplementationInfo = event;
            }
        }
    }

    public onMeasurementTypeChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.MeasurementType != event) {
                this._ChildGrowthVisits.MeasurementType = event;
            }
        }
    }

    public onMotorAssesmentDateMotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.MotorAssesmentDate != event) {
                this._ChildGrowthVisits.MotorAssesmentDate = event;
            }
        }
    }

    public onNatalHistoryChildGrowthComplaintInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.NatalHistory != event) {
                this._ChildGrowthVisits.NatalHistory = event;
            }
        }
    }

    public onNeurologicalExaminationPhysicalExaminationChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.NeurologicalExamination != event) {
                this._ChildGrowthVisits.NeurologicalExamination = event;
            }
        }
    }

    public onNotesChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.Notes != event) {
                this._ChildGrowthVisits.Notes = event;
            }
        }
    }

    public onOedemaChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.Oedema != event) {
                this._ChildGrowthVisits.Oedema = event;
            }
        }
    }

    public onPostnatalHistoryChildGrowthComplaintInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.PostnatalHistory != event) {
                this._ChildGrowthVisits.PostnatalHistory = event;
            }
        }
    }

    public onPrenatalHistoryChildGrowthComplaintInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.PrenatalHistory != event) {
                this._ChildGrowthVisits.PrenatalHistory = event;
            }
        }
    }

    public onQuestion1NurseVisitsInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.NurseObservationQ1 != event) {
                this._ChildGrowthVisits.NurseObservationQ1 = event;
            }
        }
    }

    public onQuestion2NurseVisitsInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.NurseObservationQ2 != event) {
                this._ChildGrowthVisits.NurseObservationQ2 = event;
            }
        }
    }

    public onQuestion3NurseVisitsInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.NurseObservationQ3 != event) {
                this._ChildGrowthVisits.NurseObservationQ3 = event;
            }
        }
    }

    public onQuestion4NurseVisitsInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.NurseObservationQ4 != event) {
                this._ChildGrowthVisits.NurseObservationQ4 = event;
            }
        }
    }

    public onQuestion5NurseVisitsInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.NurseObservationQ5 != event) {
                this._ChildGrowthVisits.NurseObservationQ5 = event;
            }
        }
    }

    public onQuestion6NurseVisitsInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.NurseObservationQ6 != event) {
                this._ChildGrowthVisits.NurseObservationQ6 = event;
            }
        }
    }

    public onQuestion7NurseVisitsInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.NurseObservationQ7 != event) {
                this._ChildGrowthVisits.NurseObservationQ7 = event;
            }
        }
    }

    public onRespiratorySystemPhysicalExaminationChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.RespiratorySystem != event) {
                this._ChildGrowthVisits.RespiratorySystem = event;
            }
        }
    }

    public onResUserNurseVisitsInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.ResUser != event) {
                this._ChildGrowthVisits.ResUser = event;
            }
        }
    }

    public onSittingWoSupport1MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.SittingWoSupport1 != event) {
                this._ChildGrowthVisits.SittingWoSupport1 = event;
            }
        }
    }

    public onSittingWoSupport2MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.SittingWoSupport2 != event) {
                this._ChildGrowthVisits.SittingWoSupport2 = event;
            }
        }
    }

    public onStandingAlone1MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.StandingAlone1 != event) {
                this._ChildGrowthVisits.StandingAlone1 = event;
            }
        }
    }

    public onStandingAlone2MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.StandingAlone2 != event) {
                this._ChildGrowthVisits.StandingAlone2 = event;
            }
        }
    }

    public onStandingAlone3MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.StandingAlone3 != event) {
                this._ChildGrowthVisits.StandingAlone3 = event;
            }
        }
    }

    public onStandingAlone4MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.StandingAlone4 != event) {
                this._ChildGrowthVisits.StandingAlone4 = event;
            }
        }
    }

    public onStandingWAssistance1MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.StandingWAssistance1 != event) {
                this._ChildGrowthVisits.StandingWAssistance1 = event;
            }
        }
    }

    public onStandingWAssistance2MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.StandingWAssistance2 != event) {
                this._ChildGrowthVisits.StandingWAssistance2 = event;
            }
        }
    }

    public onStandingWAssistance3MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.StandingWAssistance3 != event) {
                this._ChildGrowthVisits.StandingWAssistance3 = event;
            }
        }
    }

    public onSubscapularChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.Subscapular != event) {
                this._ChildGrowthVisits.Subscapular = event;
            }
        }
    }

    public onSuggestionsNurseVisitsInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.NurseSuggestions != event) {
                this._ChildGrowthVisits.NurseSuggestions = event;
            }
        }
    }

    public onSuggestionsPhysicalExaminationChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.PhysicalExamSuggestions != event) {
                this._ChildGrowthVisits.PhysicalExamSuggestions = event;
            }
        }
    }

    public onTricepsSkinfoldChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.TricepsSkinfold != event) {
                this._ChildGrowthVisits.TricepsSkinfold = event;
            }
        }
    }


    public onttobjectlistbox1Changed(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.InfantGrowthStatusInfo != event) {
                this._ChildGrowthVisits.InfantGrowthStatusInfo = event;
            }
        }
    }


    public onVisitDateChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.VisitDate != event) {
                this._ChildGrowthVisits.VisitDate = event;
            }
        }
    }

    public onVitaminDSupplementationInfoChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.VitaminDSupplementationInfo != event) {
                this._ChildGrowthVisits.VitaminDSupplementationInfo = event;
            }
        }
    }

    public onWalkingAlone1MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.WalkingAlone1 != event) {
                this._ChildGrowthVisits.WalkingAlone1 = event;
            }
        }
    }

    public onWalkingAlone2MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.WalkingAlone2 != event) {
                this._ChildGrowthVisits.WalkingAlone2 = event;
            }
        }
    }

    public onWalkingAlone3MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.WalkingAlone3 != event) {
                this._ChildGrowthVisits.WalkingAlone3 = event;
            }
        }
    }

    public onWalkingWAssistance1MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.WalkingWAssistance1 != event) {
                this._ChildGrowthVisits.WalkingWAssistance1 = event;
            }
        }
    }

    public onWalkingWAssistance2MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.WalkingWAssistance2 != event) {
                this._ChildGrowthVisits.WalkingWAssistance2 = event;
            }
        }
    }

    public onWalkingWAssistance3MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.WalkingWAssistance3 != event) {
                this._ChildGrowthVisits.WalkingWAssistance3 = event;
            }
        }
    }

    public onWalkingWAssistance4MotorDevelopmentChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.WalkingWAssistance4 != event) {
                this._ChildGrowthVisits.WalkingWAssistance4 = event;
            }
        }
    }

    public onWeightChanged(event): void {
        if (event != null) {
            if (this._ChildGrowthVisits != null && this._ChildGrowthVisits.Weight != event) {
                this._ChildGrowthVisits.Weight = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.VisitDate, "Value", this.__ttObject, "VisitDate");
        redirectProperty(this.MeasurementType, "Value", this.__ttObject, "MeasurementType");
        redirectProperty(this.Date, "Value", this.__ttObject, "Date");
        redirectProperty(this.Oedema, "Value", this.__ttObject, "Oedema");
        redirectProperty(this.Weight, "Text", this.__ttObject, "Weight");
        redirectProperty(this.HeadCircle, "Text", this.__ttObject, "HeadCircle");
        redirectProperty(this.Subscapular, "Text", this.__ttObject, "Subscapular");
        redirectProperty(this.Height, "Text", this.__ttObject, "Height");
        redirectProperty(this.ArmCircle, "Text", this.__ttObject, "ArmCircle");
        redirectProperty(this.TricepsSkinfold, "Text", this.__ttObject, "TricepsSkinfold");
        redirectProperty(this.BMI, "Text", this.__ttObject, "BMI");
        redirectProperty(this.Notes, "Text", this.__ttObject, "Notes");
        redirectProperty(this.Assessments, "Text", this.__ttObject, "Assessments");
        redirectProperty(this.ComplaintStartDateChildGrowthComplaintInfo, "Value", this.__ttObject, "ComplaintStartDate");
        redirectProperty(this.BabyComplaintChildGrowthComplaintInfo, "Text", this.__ttObject, "BabyComplaint");
        redirectProperty(this.FamilyHistoryChildGrowthComplaintInfo, "Text", this.__ttObject, "FamilyHistory");
        redirectProperty(this.PrenatalHistoryChildGrowthComplaintInfo, "Text", this.__ttObject, "PrenatalHistory");
        redirectProperty(this.NatalHistoryChildGrowthComplaintInfo, "Text", this.__ttObject, "NatalHistory");
        redirectProperty(this.PostnatalHistoryChildGrowthComplaintInfo, "Text", this.__ttObject, "PostnatalHistory");
        redirectProperty(this.HeadNeckThyroidInfoPhysicalExamination, "Text", this.__ttObject, "HeadNeckThyroidInfo");
        redirectProperty(this.NeurologicalExaminationPhysicalExamination, "Text", this.__ttObject, "NeurologicalExamination");
        redirectProperty(this.RespiratorySystemPhysicalExamination, "Text", this.__ttObject, "RespiratorySystem");
        redirectProperty(this.ExtremitiesPhysicalExamination, "Text", this.__ttObject, "Extremities");
        redirectProperty(this.CardiovascularSystemPhysicalExamination, "Text", this.__ttObject, "CardiovascularSystem");
        redirectProperty(this.DailyObservationsPhysicalExamination, "Text", this.__ttObject, "DailyObservations");
        redirectProperty(this.AbdomenExaminationPhysicalExamination, "Text", this.__ttObject, "AbdomenExamination");
        redirectProperty(this.SuggestionsPhysicalExamination, "Text", this.__ttObject, "PhysicalExamSuggestions");
        redirectProperty(this.AnalGenitalLocalExaminationPhysicalExamination, "Text", this.__ttObject, "AnalGenitalLocalExamination");
        redirectProperty(this.DetailsPhysicalExamination, "Text", this.__ttObject, "Details");
        redirectProperty(this.MotorAssesmentDateMotorDevelopment, "Value", this.__ttObject, "MotorAssesmentDate");
        redirectProperty(this.SittingWoSupport1MotorDevelopment, "Value", this.__ttObject, "SittingWoSupport1");
        redirectProperty(this.SittingWoSupport2MotorDevelopment, "Value", this.__ttObject, "SittingWoSupport2");
        redirectProperty(this.StandingWAssistance2MotorDevelopment, "Value", this.__ttObject, "StandingWAssistance2");
        redirectProperty(this.StandingWAssistance3MotorDevelopment, "Value", this.__ttObject, "StandingWAssistance3");
        redirectProperty(this.StandingWAssistance1MotorDevelopment, "Value", this.__ttObject, "StandingWAssistance1");
        redirectProperty(this.WalkingWAssistance1MotorDevelopment, "Value", this.__ttObject, "WalkingWAssistance1");
        redirectProperty(this.WalkingWAssistance3MotorDevelopment, "Value", this.__ttObject, "WalkingWAssistance3");
        redirectProperty(this.WalkingWAssistance4MotorDevelopment, "Value", this.__ttObject, "WalkingWAssistance4");
        redirectProperty(this.WalkingWAssistance2MotorDevelopment, "Value", this.__ttObject, "WalkingWAssistance2");
        redirectProperty(this.StandingAlone2MotorDevelopment, "Value", this.__ttObject, "StandingAlone2");
        redirectProperty(this.StandingAlone3MotorDevelopment, "Value", this.__ttObject, "StandingAlone3");
        redirectProperty(this.StandingAlone4MotorDevelopment, "Value", this.__ttObject, "StandingAlone4");
        redirectProperty(this.StandingAlone1MotorDevelopment, "Value", this.__ttObject, "StandingAlone1");
        redirectProperty(this.WalkingAlone1MotorDevelopment, "Value", this.__ttObject, "WalkingAlone1");
        redirectProperty(this.WalkingAlone3MotorDevelopment, "Value", this.__ttObject, "WalkingAlone3");
        redirectProperty(this.WalkingAlone2MotorDevelopment, "Value", this.__ttObject, "WalkingAlone2");
        redirectProperty(this.Crawling2MotorDevelopment, "Value", this.__ttObject, "Crawling2");
        redirectProperty(this.Crawling3MotorDevelopment, "Value", this.__ttObject, "Crawling3");
        redirectProperty(this.Crawling1MotorDevelopment, "Value", this.__ttObject, "Crawling1");
        redirectProperty(this.Question1NurseVisitsInfo, "Text", this.__ttObject, "NurseObservationQ1");
        redirectProperty(this.Question2NurseVisitsInfo, "Text", this.__ttObject, "NurseObservationQ2");
        redirectProperty(this.Question3NurseVisitsInfo, "Text", this.__ttObject, "NurseObservationQ3");
        redirectProperty(this.Question4NurseVisitsInfo, "Text", this.__ttObject, "NurseObservationQ4");
        redirectProperty(this.Question5NurseVisitsInfo, "Text", this.__ttObject, "NurseObservationQ5");
        redirectProperty(this.Question6NurseVisitsInfo, "Text", this.__ttObject, "NurseObservationQ6");
        redirectProperty(this.Question7NurseVisitsInfo, "Text", this.__ttObject, "NurseObservationQ7");
        redirectProperty(this.SuggestionsNurseVisitsInfo, "Text", this.__ttObject, "NurseSuggestions");
    }

    public initFormControls(): void {
        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 0;

        this.MeasurementInfo = new TTVisual.TTTabPage();
        this.MeasurementInfo.DisplayIndex = 0;
        this.MeasurementInfo.TabIndex = 0;
        this.MeasurementInfo.Text = i18n("M19911", "Ölçüm Bilgileri");
        this.MeasurementInfo.Name = "MeasurementInfo";

        this.InfantNutritionalStatus = new TTVisual.TTObjectListBox();
        this.InfantNutritionalStatus.ListDefName = "SKRSBebeginBeslenmeDurumuList";
        this.InfantNutritionalStatus.Name = "InfantNutritionalStatus";
        this.InfantNutritionalStatus.TabIndex = 30;
        this.InfantNutritionalStatus.AutoCompleteDialogHeight = "50%";


        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ListDefName = "SKRSGelisimTablosuBilgilerininSorgulanmasiList";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 30;
        this.ttobjectlistbox1.AutoCompleteDialogHeight = "50%";

        this.labelInfantGrowthStatusInfo = new TTVisual.TTLabel();
        this.labelInfantGrowthStatusInfo.Text = "Gelişim Durumu ";
        this.labelInfantGrowthStatusInfo.Name = "labelInfantGrowthStatusInfo";
        this.labelInfantGrowthStatusInfo.TabIndex = 29;

        this.labelInfantNutritionalStatus = new TTVisual.TTLabel();
        this.labelInfantNutritionalStatus.Text = "Bebeğin beslenme durumu";
        this.labelInfantNutritionalStatus.Name = "labelInfantNutritionalStatus";
        this.labelInfantNutritionalStatus.TabIndex = 27;

        this.labelWeight = new TTVisual.TTLabel();
        this.labelWeight.Text = i18n("M17566", "Kilo(kg)");
        this.labelWeight.Name = "labelWeight";
        this.labelWeight.TabIndex = 25;

        this.Weight = new TTVisual.TTTextBox();
        this.Weight.Name = "Weight";
        this.Weight.TabIndex = 24;

        this.labelVisitDate = new TTVisual.TTLabel();
        this.labelVisitDate.Text = i18n("M24177", "Vizit Tarihi");
        this.labelVisitDate.Name = "labelVisitDate";
        this.labelVisitDate.TabIndex = 23;

        this.VisitDate = new TTVisual.TTDateTimePicker();
        this.VisitDate.Format = DateTimePickerFormat.Long;
        this.VisitDate.Name = "VisitDate";
        this.VisitDate.TabIndex = 22;

        this.labelTricepsSkinfold = new TTVisual.TTLabel();
        this.labelTricepsSkinfold.Text = "Kıvrım Kalınlığı(mm)";
        this.labelTricepsSkinfold.Name = "labelTricepsSkinfold";
        this.labelTricepsSkinfold.TabIndex = 21;

        this.TricepsSkinfold = new TTVisual.TTTextBox();
        this.TricepsSkinfold.Name = "TricepsSkinfold";
        this.TricepsSkinfold.TabIndex = 20;

        this.labelSubscapular = new TTVisual.TTLabel();
        this.labelSubscapular.Text = i18n("M12660", "Deri Kıvrımı(mm)");
        this.labelSubscapular.Name = "labelSubscapular";
        this.labelSubscapular.TabIndex = 19;

        this.Subscapular = new TTVisual.TTTextBox();
        this.Subscapular.Name = "Subscapular";
        this.Subscapular.TabIndex = 18;

        this.labelOedema = new TTVisual.TTLabel();
        this.labelOedema.Text = i18n("M19842", "Ödem Bilgisi");
        this.labelOedema.Name = "labelOedema";
        this.labelOedema.TabIndex = 17;

        this.Oedema = new TTVisual.TTEnumComboBox();
        this.Oedema.DataTypeName = "OedemaEnum";
        this.Oedema.Name = "Oedema";
        this.Oedema.TabIndex = 16;

        this.labelNotes = new TTVisual.TTLabel();
        this.labelNotes.Text = i18n("M19485", "Notlar");
        this.labelNotes.Name = "labelNotes";
        this.labelNotes.TabIndex = 15;

        this.Notes = new TTVisual.TTTextBox();
        this.Notes.Multiline = true;
        this.Notes.Name = "Notes";
        this.Notes.TabIndex = 14;

        this.labelMeasurementType = new TTVisual.TTLabel();
        this.labelMeasurementType.Text = i18n("M19912", "Ölçüm Şekli");
        this.labelMeasurementType.Name = "labelMeasurementType";
        this.labelMeasurementType.TabIndex = 13;

        this.MeasurementType = new TTVisual.TTEnumComboBox();
        this.MeasurementType.DataTypeName = "MeasurementTypeEnum";
        this.MeasurementType.Name = "MeasurementType";
        this.MeasurementType.TabIndex = 12;

        this.labelHeight = new TTVisual.TTLabel();
        this.labelHeight.Text = i18n("M11992", "Boy(cm)");
        this.labelHeight.Name = "labelHeight";
        this.labelHeight.TabIndex = 11;

        this.Height = new TTVisual.TTTextBox();
        this.Height.Name = "Height";
        this.Height.TabIndex = 10;

        this.labelHeadCircle = new TTVisual.TTLabel();
        this.labelHeadCircle.Text = i18n("M17068", "Kafa Çevresi(cm)");
        this.labelHeadCircle.Name = "labelHeadCircle";
        this.labelHeadCircle.TabIndex = 9;

        this.HeadCircle = new TTVisual.TTTextBox();
        this.HeadCircle.Name = "HeadCircle";
        this.HeadCircle.TabIndex = 8;

        this.labelDate = new TTVisual.TTLabel();
        this.labelDate.Text = "Tarih";
        this.labelDate.Name = "labelDate";
        this.labelDate.TabIndex = 7;

        this.Date = new TTVisual.TTDateTimePicker();
        this.Date.Format = DateTimePickerFormat.Long;
        this.Date.Name = "Date";
        this.Date.TabIndex = 6;

        this.labelBMI = new TTVisual.TTLabel();
        this.labelBMI.Text = i18n("M24196", "Vücut Kitle İndeksi");
        this.labelBMI.Name = "labelBMI";
        this.labelBMI.TabIndex = 5;

        this.BMI = new TTVisual.TTTextBox();
        this.BMI.BackColor = "#F0F0F0";
        this.BMI.ReadOnly = true;
        this.BMI.Name = "BMI";
        this.BMI.TabIndex = 4;

        this.labelAssessments = new TTVisual.TTLabel();
        this.labelAssessments.Text = i18n("M12528", "Değerlendirme");
        this.labelAssessments.Name = "labelAssessments";
        this.labelAssessments.TabIndex = 3;

        this.Assessments = new TTVisual.TTTextBox();
        this.Assessments.Multiline = true;
        this.Assessments.Name = "Assessments";
        this.Assessments.TabIndex = 2;

        this.labelArmCircle = new TTVisual.TTLabel();
        this.labelArmCircle.Text = i18n("M17695", "Kol Çevresi(cm)");
        this.labelArmCircle.Name = "labelArmCircle";
        this.labelArmCircle.TabIndex = 1;

        this.ArmCircle = new TTVisual.TTTextBox();
        this.ArmCircle.Name = "ArmCircle";
        this.ArmCircle.TabIndex = 0;

        this.ComplaintInfo = new TTVisual.TTTabPage();
        this.ComplaintInfo.DisplayIndex = 1;
        this.ComplaintInfo.TabIndex = 1;
        this.ComplaintInfo.Text = i18n("M22487", "Şikayet Bilgileri");
        this.ComplaintInfo.Name = "ComplaintInfo";

        this.labelPostnatalHistoryChildGrowthComplaintInfo = new TTVisual.TTLabel();
        this.labelPostnatalHistoryChildGrowthComplaintInfo.Text = i18n("M20456", "Postnatal Geçmiş");
        this.labelPostnatalHistoryChildGrowthComplaintInfo.Name = "labelPostnatalHistoryChildGrowthComplaintInfo";
        this.labelPostnatalHistoryChildGrowthComplaintInfo.TabIndex = 11;

        this.PostnatalHistoryChildGrowthComplaintInfo = new TTVisual.TTTextBox();
        this.PostnatalHistoryChildGrowthComplaintInfo.Multiline = true;
        this.PostnatalHistoryChildGrowthComplaintInfo.Name = "PostnatalHistoryChildGrowthComplaintInfo";
        this.PostnatalHistoryChildGrowthComplaintInfo.TabIndex = 10;

        this.labelNatalHistoryChildGrowthComplaintInfo = new TTVisual.TTLabel();
        this.labelNatalHistoryChildGrowthComplaintInfo.Text = i18n("M19421", "Natal Geçmiş");
        this.labelNatalHistoryChildGrowthComplaintInfo.Name = "labelNatalHistoryChildGrowthComplaintInfo";
        this.labelNatalHistoryChildGrowthComplaintInfo.TabIndex = 9;

        this.NatalHistoryChildGrowthComplaintInfo = new TTVisual.TTTextBox();
        this.NatalHistoryChildGrowthComplaintInfo.Multiline = true;
        this.NatalHistoryChildGrowthComplaintInfo.Name = "NatalHistoryChildGrowthComplaintInfo";
        this.NatalHistoryChildGrowthComplaintInfo.TabIndex = 8;

        this.labelPrenatalHistoryChildGrowthComplaintInfo = new TTVisual.TTLabel();
        this.labelPrenatalHistoryChildGrowthComplaintInfo.Text = i18n("M20468", "Prenatal Geçmiş");
        this.labelPrenatalHistoryChildGrowthComplaintInfo.Name = "labelPrenatalHistoryChildGrowthComplaintInfo";
        this.labelPrenatalHistoryChildGrowthComplaintInfo.TabIndex = 7;

        this.PrenatalHistoryChildGrowthComplaintInfo = new TTVisual.TTTextBox();
        this.PrenatalHistoryChildGrowthComplaintInfo.Multiline = true;
        this.PrenatalHistoryChildGrowthComplaintInfo.Name = "PrenatalHistoryChildGrowthComplaintInfo";
        this.PrenatalHistoryChildGrowthComplaintInfo.TabIndex = 6;

        this.labelFamilyHistoryChildGrowthComplaintInfo = new TTVisual.TTLabel();
        this.labelFamilyHistoryChildGrowthComplaintInfo.Text = i18n("M22485", "Şikayet Aile Geçmişi");
        this.labelFamilyHistoryChildGrowthComplaintInfo.Name = "labelFamilyHistoryChildGrowthComplaintInfo";
        this.labelFamilyHistoryChildGrowthComplaintInfo.TabIndex = 5;

        this.FamilyHistoryChildGrowthComplaintInfo = new TTVisual.TTTextBox();
        this.FamilyHistoryChildGrowthComplaintInfo.Multiline = true;
        this.FamilyHistoryChildGrowthComplaintInfo.Name = "FamilyHistoryChildGrowthComplaintInfo";
        this.FamilyHistoryChildGrowthComplaintInfo.TabIndex = 4;

        this.labelBabyComplaintChildGrowthComplaintInfo = new TTVisual.TTLabel();
        this.labelBabyComplaintChildGrowthComplaintInfo.Text = i18n("M11687", "Bebeğin Şikayeti");
        this.labelBabyComplaintChildGrowthComplaintInfo.Name = "labelBabyComplaintChildGrowthComplaintInfo";
        this.labelBabyComplaintChildGrowthComplaintInfo.TabIndex = 3;

        this.BabyComplaintChildGrowthComplaintInfo = new TTVisual.TTTextBox();
        this.BabyComplaintChildGrowthComplaintInfo.Multiline = true;
        this.BabyComplaintChildGrowthComplaintInfo.Name = "BabyComplaintChildGrowthComplaintInfo";
        this.BabyComplaintChildGrowthComplaintInfo.TabIndex = 2;

        this.labelComplaintStartDateChildGrowthComplaintInfo = new TTVisual.TTLabel();
        this.labelComplaintStartDateChildGrowthComplaintInfo.Text = i18n("M22486", "Şikayet Başlangıç Tarihi");
        this.labelComplaintStartDateChildGrowthComplaintInfo.Name = "labelComplaintStartDateChildGrowthComplaintInfo";
        this.labelComplaintStartDateChildGrowthComplaintInfo.TabIndex = 1;

        this.ComplaintStartDateChildGrowthComplaintInfo = new TTVisual.TTDateTimePicker();
        this.ComplaintStartDateChildGrowthComplaintInfo.Format = DateTimePickerFormat.Long;
        this.ComplaintStartDateChildGrowthComplaintInfo.Name = "ComplaintStartDateChildGrowthComplaintInfo";
        this.ComplaintStartDateChildGrowthComplaintInfo.TabIndex = 0;

        this.PhysicalExaminationInfo = new TTVisual.TTTabPage();
        this.PhysicalExaminationInfo.DisplayIndex = 2;
        this.PhysicalExaminationInfo.TabIndex = 2;
        this.PhysicalExaminationInfo.Text = i18n("M14398", "Fiziksel Muayene Bilgileri");
        this.PhysicalExaminationInfo.Name = "PhysicalExaminationInfo";

        this.labelVitaminDSupplementationInfo = new TTVisual.TTLabel();
        this.labelVitaminDSupplementationInfo.Text = "D vitamini Lojistiği ve Desteği";
        this.labelVitaminDSupplementationInfo.Name = "labelVitaminDSupplementationInfo";
        this.labelVitaminDSupplementationInfo.TabIndex = 34;

        this.VitaminDSupplementationInfo = new TTVisual.TTObjectListBox();
        this.VitaminDSupplementationInfo.ListDefName = "SKRSDVitaminiLojistigiveDestegiList";
        this.VitaminDSupplementationInfo.Name = "VitaminDSupplementationInfo";
        this.VitaminDSupplementationInfo.TabIndex = 33;
        this.VitaminDSupplementationInfo.AutoCompleteDialogHeight = "50%";

        this.labelIronSupplementationInfo = new TTVisual.TTLabel();
        this.labelIronSupplementationInfo.Text = "Demir Lojistiği ve Desteği";
        this.labelIronSupplementationInfo.Name = "labelIronSupplementationInfo";
        this.labelIronSupplementationInfo.TabIndex = 32;

        this.IronSupplementationInfo = new TTVisual.TTObjectListBox();
        this.IronSupplementationInfo.ListDefName = "SKRSDemirLojistigiveDestegiList";
        this.IronSupplementationInfo.Name = "IronSupplementationInfo";
        this.IronSupplementationInfo.TabIndex = 31;
        this.IronSupplementationInfo.AutoCompleteDialogHeight = "50%";

        this.labelAnalGenitalLocalExaminationPhysicalExamination = new TTVisual.TTLabel();
        this.labelAnalGenitalLocalExaminationPhysicalExamination.Text = i18n("M10936", "Anal, Genital, Lokal Muayene");
        this.labelAnalGenitalLocalExaminationPhysicalExamination.Name = "labelAnalGenitalLocalExaminationPhysicalExamination";
        this.labelAnalGenitalLocalExaminationPhysicalExamination.TabIndex = 21;

        this.AnalGenitalLocalExaminationPhysicalExamination = new TTVisual.TTTextBox();
        this.AnalGenitalLocalExaminationPhysicalExamination.Multiline = true;
        this.AnalGenitalLocalExaminationPhysicalExamination.Name = "AnalGenitalLocalExaminationPhysicalExamination";
        this.AnalGenitalLocalExaminationPhysicalExamination.TabIndex = 20;

        this.labelDetailsPhysicalExamination = new TTVisual.TTLabel();
        this.labelDetailsPhysicalExamination.Text = i18n("M12673", "Detaylar");
        this.labelDetailsPhysicalExamination.Name = "labelDetailsPhysicalExamination";
        this.labelDetailsPhysicalExamination.TabIndex = 19;

        this.DetailsPhysicalExamination = new TTVisual.TTTextBox();
        this.DetailsPhysicalExamination.Multiline = true;
        this.DetailsPhysicalExamination.Name = "DetailsPhysicalExamination";
        this.DetailsPhysicalExamination.TabIndex = 18;

        this.labelSuggestionsPhysicalExamination = new TTVisual.TTLabel();
        this.labelSuggestionsPhysicalExamination.Text = i18n("M20029", "Öneriler");
        this.labelSuggestionsPhysicalExamination.Name = "labelSuggestionsPhysicalExamination";
        this.labelSuggestionsPhysicalExamination.TabIndex = 17;

        this.SuggestionsPhysicalExamination = new TTVisual.TTTextBox();
        this.SuggestionsPhysicalExamination.Multiline = true;
        this.SuggestionsPhysicalExamination.Name = "SuggestionsPhysicalExamination";
        this.SuggestionsPhysicalExamination.TabIndex = 16;

        this.labelDailyObservationsPhysicalExamination = new TTVisual.TTLabel();
        this.labelDailyObservationsPhysicalExamination.Text = i18n("M15037", "Günlük İzlem");
        this.labelDailyObservationsPhysicalExamination.Name = "labelDailyObservationsPhysicalExamination";
        this.labelDailyObservationsPhysicalExamination.TabIndex = 15;

        this.DailyObservationsPhysicalExamination = new TTVisual.TTTextBox();
        this.DailyObservationsPhysicalExamination.Multiline = true;
        this.DailyObservationsPhysicalExamination.Name = "DailyObservationsPhysicalExamination";
        this.DailyObservationsPhysicalExamination.TabIndex = 14;

        this.labelExtremitiesPhysicalExamination = new TTVisual.TTLabel();
        this.labelExtremitiesPhysicalExamination.Text = "Ekstremiteler";
        this.labelExtremitiesPhysicalExamination.Name = "labelExtremitiesPhysicalExamination";
        this.labelExtremitiesPhysicalExamination.TabIndex = 13;

        this.ExtremitiesPhysicalExamination = new TTVisual.TTTextBox();
        this.ExtremitiesPhysicalExamination.Multiline = true;
        this.ExtremitiesPhysicalExamination.Name = "ExtremitiesPhysicalExamination";
        this.ExtremitiesPhysicalExamination.TabIndex = 12;

        this.labelNeurologicalExaminationPhysicalExamination = new TTVisual.TTLabel();
        this.labelNeurologicalExaminationPhysicalExamination.Text = i18n("M19508", "Nörolojik Muayene");
        this.labelNeurologicalExaminationPhysicalExamination.Name = "labelNeurologicalExaminationPhysicalExamination";
        this.labelNeurologicalExaminationPhysicalExamination.TabIndex = 11;

        this.NeurologicalExaminationPhysicalExamination = new TTVisual.TTTextBox();
        this.NeurologicalExaminationPhysicalExamination.Multiline = true;
        this.NeurologicalExaminationPhysicalExamination.Name = "NeurologicalExaminationPhysicalExamination";
        this.NeurologicalExaminationPhysicalExamination.TabIndex = 10;

        this.labelAbdomenExaminationPhysicalExamination = new TTVisual.TTLabel();
        this.labelAbdomenExaminationPhysicalExamination.Text = i18n("M17304", "Karın Muayenesi");
        this.labelAbdomenExaminationPhysicalExamination.Name = "labelAbdomenExaminationPhysicalExamination";
        this.labelAbdomenExaminationPhysicalExamination.TabIndex = 7;

        this.AbdomenExaminationPhysicalExamination = new TTVisual.TTTextBox();
        this.AbdomenExaminationPhysicalExamination.Multiline = true;
        this.AbdomenExaminationPhysicalExamination.Name = "AbdomenExaminationPhysicalExamination";
        this.AbdomenExaminationPhysicalExamination.TabIndex = 6;

        this.labelCardiovascularSystemPhysicalExamination = new TTVisual.TTLabel();
        this.labelCardiovascularSystemPhysicalExamination.Text = i18n("M17296", "Kardiyovasküler Sistem");
        this.labelCardiovascularSystemPhysicalExamination.Name = "labelCardiovascularSystemPhysicalExamination";
        this.labelCardiovascularSystemPhysicalExamination.TabIndex = 5;

        this.CardiovascularSystemPhysicalExamination = new TTVisual.TTTextBox();
        this.CardiovascularSystemPhysicalExamination.Multiline = true;
        this.CardiovascularSystemPhysicalExamination.Name = "CardiovascularSystemPhysicalExamination";
        this.CardiovascularSystemPhysicalExamination.TabIndex = 4;

        this.labelRespiratorySystemPhysicalExamination = new TTVisual.TTLabel();
        this.labelRespiratorySystemPhysicalExamination.Text = i18n("M22034", "Solunum Sistemi");
        this.labelRespiratorySystemPhysicalExamination.Name = "labelRespiratorySystemPhysicalExamination";
        this.labelRespiratorySystemPhysicalExamination.TabIndex = 3;

        this.RespiratorySystemPhysicalExamination = new TTVisual.TTTextBox();
        this.RespiratorySystemPhysicalExamination.Multiline = true;
        this.RespiratorySystemPhysicalExamination.Name = "RespiratorySystemPhysicalExamination";
        this.RespiratorySystemPhysicalExamination.TabIndex = 2;

        this.labelHeadNeckThyroidInfoPhysicalExamination = new TTVisual.TTLabel();
        this.labelHeadNeckThyroidInfoPhysicalExamination.Text = i18n("M11597", "Baş, Boyun, Tiroid");
        this.labelHeadNeckThyroidInfoPhysicalExamination.Name = "labelHeadNeckThyroidInfoPhysicalExamination";
        this.labelHeadNeckThyroidInfoPhysicalExamination.TabIndex = 1;

        this.HeadNeckThyroidInfoPhysicalExamination = new TTVisual.TTTextBox();
        this.HeadNeckThyroidInfoPhysicalExamination.Multiline = true;
        this.HeadNeckThyroidInfoPhysicalExamination.Name = "HeadNeckThyroidInfoPhysicalExamination";
        this.HeadNeckThyroidInfoPhysicalExamination.TabIndex = 0;

        this.MotorImprovementInfo = new TTVisual.TTTabPage();
        this.MotorImprovementInfo.DisplayIndex = 3;
        this.MotorImprovementInfo.TabIndex = 3;
        this.MotorImprovementInfo.Text = i18n("M19141", "Motor Gelişim Bilgileri");
        this.MotorImprovementInfo.Name = "MotorImprovementInfo";

        this.labelMotorAssesmentDateMotorDevelopment = new TTVisual.TTLabel();
        this.labelMotorAssesmentDateMotorDevelopment.Text = "Tarih";
        this.labelMotorAssesmentDateMotorDevelopment.Name = "labelMotorAssesmentDateMotorDevelopment";
        this.labelMotorAssesmentDateMotorDevelopment.TabIndex = 7;

        this.MotorAssesmentDateMotorDevelopment = new TTVisual.TTDateTimePicker();
        this.MotorAssesmentDateMotorDevelopment.Format = DateTimePickerFormat.Long;
        this.MotorAssesmentDateMotorDevelopment.Name = "MotorAssesmentDateMotorDevelopment";
        this.MotorAssesmentDateMotorDevelopment.TabIndex = 6;

        this.Seperator6 = new TTVisual.TTGroupBox();
        this.Seperator6.Text = i18n("M24742", "Yürüme");
        this.Seperator6.Name = "Seperator6";
        this.Seperator6.TabIndex = 5;

        this.WalkingAloneCheckAllMotorDevelopment = new TTVisual.TTCheckBox();
        this.WalkingAloneCheckAllMotorDevelopment.Value = false;
        this.WalkingAloneCheckAllMotorDevelopment.Title = i18n("M23657", "Tümünü İşaretle");
        this.WalkingAloneCheckAllMotorDevelopment.Name = "WalkingAloneCheckAllMotorDevelopment";
        this.WalkingAloneCheckAllMotorDevelopment.TabIndex = 3;

        this.WalkingAlone3MotorDevelopment = new TTVisual.TTCheckBox();
        this.WalkingAlone3MotorDevelopment.Value = false;
        this.WalkingAlone3MotorDevelopment.Title = i18n("M11684", "Bebeğin herhangi bir obje veya kişi ile teması bulunmamaktadır.");
        this.WalkingAlone3MotorDevelopment.Name = "WalkingAlone3MotorDevelopment";
        this.WalkingAlone3MotorDevelopment.TabIndex = 2;

        this.WalkingAlone2MotorDevelopment = new TTVisual.TTCheckBox();
        this.WalkingAlone2MotorDevelopment.Value = false;
        this.WalkingAlone2MotorDevelopment.Title = i18n("M11681", "Bebeğin bir ayağı ileri doğru adım atarken diğer ayağından destek almaktadır.");
        this.WalkingAlone2MotorDevelopment.Name = "WalkingAlone2MotorDevelopment";
        this.WalkingAlone2MotorDevelopment.TabIndex = 1;

        this.WalkingAlone1MotorDevelopment = new TTVisual.TTCheckBox();
        this.WalkingAlone1MotorDevelopment.Value = false;
        this.WalkingAlone1MotorDevelopment.Title = i18n("M11697", "Bebek dik pozisyonda ve sırtı dik şekilde en az beş adım atabilmektedir.");
        this.WalkingAlone1MotorDevelopment.Name = "WalkingAlone1MotorDevelopment";
        this.WalkingAlone1MotorDevelopment.TabIndex = 0;

        this.Seperator5 = new TTVisual.TTGroupBox();
        this.Seperator5.Text = i18n("M11280", "Ayakta Durma");
        this.Seperator5.Name = "Seperator5";
        this.Seperator5.TabIndex = 4;

        this.StandingAloneCheckAllMotorDevelopment = new TTVisual.TTCheckBox();
        this.StandingAloneCheckAllMotorDevelopment.Value = false;
        this.StandingAloneCheckAllMotorDevelopment.Title = i18n("M23657", "Tümünü İşaretle");
        this.StandingAloneCheckAllMotorDevelopment.Name = "StandingAloneCheckAllMotorDevelopment";
        this.StandingAloneCheckAllMotorDevelopment.TabIndex = 4;

        this.StandingAlone4MotorDevelopment = new TTVisual.TTCheckBox();
        this.StandingAlone4MotorDevelopment.Value = false;
        this.StandingAlone4MotorDevelopment.Title = i18n("M11693", "Bebek ayakta en az on saniye durabilmektedir.");
        this.StandingAlone4MotorDevelopment.Name = "StandingAlone4MotorDevelopment";
        this.StandingAlone4MotorDevelopment.TabIndex = 3;

        this.StandingAlone1MotorDevelopment = new TTVisual.TTCheckBox();
        this.StandingAlone1MotorDevelopment.Value = false;
        this.StandingAlone1MotorDevelopment.Title = i18n("M11704", "Bebek iki ayağı yere basarken sırtı dik olacak şekilde ayakta durabilmektedir.");
        this.StandingAlone1MotorDevelopment.Name = "StandingAlone1MotorDevelopment";
        this.StandingAlone1MotorDevelopment.TabIndex = 0;

        this.StandingAlone2MotorDevelopment = new TTVisual.TTCheckBox();
        this.StandingAlone2MotorDevelopment.Value = false;
        this.StandingAlone2MotorDevelopment.Title = i18n("M11678", "Bebeğin ayakları vücut ağırlığının %100ünü taşımaktadır.");
        this.StandingAlone2MotorDevelopment.Name = "StandingAlone2MotorDevelopment";
        this.StandingAlone2MotorDevelopment.TabIndex = 1;

        this.StandingAlone3MotorDevelopment = new TTVisual.TTCheckBox();
        this.StandingAlone3MotorDevelopment.Value = false;
        this.StandingAlone3MotorDevelopment.Title = i18n("M11684", "Bebeğin herhangi bir obje veya kişi ile teması bulunmamaktadır.");
        this.StandingAlone3MotorDevelopment.Name = "StandingAlone3MotorDevelopment";
        this.StandingAlone3MotorDevelopment.TabIndex = 2;

        this.Seperator4 = new TTVisual.TTGroupBox();
        this.Seperator4.Text = "Tutunarak Yürüme";
        this.Seperator4.Name = "Seperator4";
        this.Seperator4.TabIndex = 3;

        this.WalkingWAssistanceCheckAllMotorDevelopment = new TTVisual.TTCheckBox();
        this.WalkingWAssistanceCheckAllMotorDevelopment.Value = false;
        this.WalkingWAssistanceCheckAllMotorDevelopment.Title = i18n("M23657", "Tümünü İşaretle");
        this.WalkingWAssistanceCheckAllMotorDevelopment.Name = "WalkingWAssistanceCheckAllMotorDevelopment";
        this.WalkingWAssistanceCheckAllMotorDevelopment.TabIndex = 4;

        this.WalkingWAssistance4MotorDevelopment = new TTVisual.TTCheckBox();
        this.WalkingWAssistance4MotorDevelopment.Value = false;
        this.WalkingWAssistance4MotorDevelopment.Title = i18n("M11701", "Bebek en az beş adım atabilmektedir.");
        this.WalkingWAssistance4MotorDevelopment.Name = "WalkingWAssistance4MotorDevelopment";
        this.WalkingWAssistance4MotorDevelopment.TabIndex = 3;

        this.WalkingWAssistance3MotorDevelopment = new TTVisual.TTCheckBox();
        this.WalkingWAssistance3MotorDevelopment.Value = false;
        this.WalkingWAssistance3MotorDevelopment.Title = i18n("M11712", "Bebek tek ayağını hareket ettirirken diğer ayağından destek almaktadır.");
        this.WalkingWAssistance3MotorDevelopment.Name = "WalkingWAssistance3MotorDevelopment";
        this.WalkingWAssistance3MotorDevelopment.TabIndex = 2;

        this.WalkingWAssistance2MotorDevelopment = new TTVisual.TTCheckBox();
        this.WalkingWAssistance2MotorDevelopment.Value = false;
        this.WalkingWAssistance2MotorDevelopment.Title = i18n("M11694", "Bebek bir objeye tek elle veya iki elle tutunarak ileri ya da geri hareket edebilmektedir.");
        this.WalkingWAssistance2MotorDevelopment.Name = "WalkingWAssistance2MotorDevelopment";
        this.WalkingWAssistance2MotorDevelopment.TabIndex = 1;

        this.WalkingWAssistance1MotorDevelopment = new TTVisual.TTCheckBox();
        this.WalkingWAssistance1MotorDevelopment.Value = false;
        this.WalkingWAssistance1MotorDevelopment.Title = i18n("M11710", "Bebek sırtı dik pozisyonda ayakta durabilmektedir.");
        this.WalkingWAssistance1MotorDevelopment.Name = "WalkingWAssistance1MotorDevelopment";
        this.WalkingWAssistance1MotorDevelopment.TabIndex = 0;

        this.Seperator3 = new TTVisual.TTGroupBox();
        this.Seperator3.Text = i18n("M13639", "Emekleme");
        this.Seperator3.Name = "Seperator3";
        this.Seperator3.TabIndex = 2;

        this.Crawling3MotorDevelopment = new TTVisual.TTCheckBox();
        this.Crawling3MotorDevelopment.Value = false;
        this.Crawling3MotorDevelopment.Title = i18n("M11711", "Bebek sürekli ve ardışık en az üç hareket yapabilmektedir.");
        this.Crawling3MotorDevelopment.Name = "Crawling3MotorDevelopment";
        this.Crawling3MotorDevelopment.TabIndex = 5;

        this.CrawlingCheckAllMotorDevelopment = new TTVisual.TTCheckBox();
        this.CrawlingCheckAllMotorDevelopment.Value = false;
        this.CrawlingCheckAllMotorDevelopment.Title = i18n("M23657", "Tümünü İşaretle");
        this.CrawlingCheckAllMotorDevelopment.Name = "CrawlingCheckAllMotorDevelopment";
        this.CrawlingCheckAllMotorDevelopment.TabIndex = 6;

        this.Crawling2MotorDevelopment = new TTVisual.TTCheckBox();
        this.Crawling2MotorDevelopment.Value = false;
        this.Crawling2MotorDevelopment.Title = i18n("M11685", "Bebeğin karnı emekleme esnasında yere temas etmemektedir.");
        this.Crawling2MotorDevelopment.Name = "Crawling2MotorDevelopment";
        this.Crawling2MotorDevelopment.TabIndex = 4;

        this.Crawling1MotorDevelopment = new TTVisual.TTCheckBox();
        this.Crawling1MotorDevelopment.Value = false;
        this.Crawling1MotorDevelopment.Title = i18n("M11700", "Bebek ellerini ve dizlerini kullanarak ileriye ya da geriye doğru hareket edebilmektedir.");
        this.Crawling1MotorDevelopment.Name = "Crawling1MotorDevelopment";
        this.Crawling1MotorDevelopment.TabIndex = 3;

        this.Seperator2 = new TTVisual.TTGroupBox();
        this.Seperator2.Text = "Tutunarak Ayakta Durma";
        this.Seperator2.Name = "Seperator2";
        this.Seperator2.TabIndex = 1;

        this.StandingWAssistanceCheckAllMotorDevelopment = new TTVisual.TTCheckBox();
        this.StandingWAssistanceCheckAllMotorDevelopment.Value = false;
        this.StandingWAssistanceCheckAllMotorDevelopment.Title = i18n("M23657", "Tümünü İşaretle");
        this.StandingWAssistanceCheckAllMotorDevelopment.Name = "StandingWAssistanceCheckAllMotorDevelopment";
        this.StandingWAssistanceCheckAllMotorDevelopment.TabIndex = 3;

        this.StandingWAssistance3MotorDevelopment = new TTVisual.TTCheckBox();
        this.StandingWAssistance3MotorDevelopment.Value = false;
        this.StandingWAssistance3MotorDevelopment.Title = i18n("M11713", "Bebek tutunarak en az 10 saniye ayakta durabilmektedir.");
        this.StandingWAssistance3MotorDevelopment.Name = "StandingWAssistance3MotorDevelopment";
        this.StandingWAssistance3MotorDevelopment.TabIndex = 2;

        this.StandingWAssistance2MotorDevelopment = new TTVisual.TTCheckBox();
        this.StandingWAssistance2MotorDevelopment.Value = false;
        this.StandingWAssistance2MotorDevelopment.Title = i18n("M11692", "Bebek ayakta dururken vücudu tutunduğu objeye temas etmeden, ağırlığını sadece bacaklarına vererek ayakta durabilmektedir.");
        this.StandingWAssistance2MotorDevelopment.Name = "StandingWAssistance2MotorDevelopment";
        this.StandingWAssistance2MotorDevelopment.TabIndex = 1;

        this.StandingWAssistance1MotorDevelopment = new TTVisual.TTCheckBox();
        this.StandingWAssistance1MotorDevelopment.Value = false;
        this.StandingWAssistance1MotorDevelopment.Title = i18n("M11696", "Bebek dik pozisyonda iki ayağının üstüne bakarak, sabit bir objeye tutunarak, mobilya sandalye gibi bir objeye dayanmadan ayağa kalkabilmektedir.");
        this.StandingWAssistance1MotorDevelopment.Name = "StandingWAssistance1MotorDevelopment";
        this.StandingWAssistance1MotorDevelopment.TabIndex = 0;

        this.Seperator1 = new TTVisual.TTGroupBox();
        this.Seperator1.Text = i18n("M12670", "Desteksiz Oturma");
        this.Seperator1.Name = "Seperator1";
        this.Seperator1.TabIndex = 0;

        this.SittingWoSupport2MotorDevelopment = new TTVisual.TTCheckBox();
        this.SittingWoSupport2MotorDevelopment.Value = false;
        this.SittingWoSupport2MotorDevelopment.Title = i18n("M19830", "Oturur pozisyonda iken dengesini kurmak için ellerine ve ayaklarına ihtiyaç duymaz.");
        this.SittingWoSupport2MotorDevelopment.Name = "SittingWoSupport2MotorDevelopment";
        this.SittingWoSupport2MotorDevelopment.TabIndex = 2;

        this.SittingWoSupportCheckAllMotorDevelopment = new TTVisual.TTCheckBox();
        this.SittingWoSupportCheckAllMotorDevelopment.Value = false;
        this.SittingWoSupportCheckAllMotorDevelopment.Title = i18n("M23657", "Tümünü İşaretle");
        this.SittingWoSupportCheckAllMotorDevelopment.Name = "SittingWoSupportCheckAllMotorDevelopment";
        this.SittingWoSupportCheckAllMotorDevelopment.TabIndex = 3;

        this.SittingWoSupport1MotorDevelopment = new TTVisual.TTCheckBox();
        this.SittingWoSupport1MotorDevelopment.Value = false;
        this.SittingWoSupport1MotorDevelopment.Title = i18n("M11706", "Bebek kafasını dik tutarak en az 10 saniye oturabilmektedir.");
        this.SittingWoSupport1MotorDevelopment.Name = "SittingWoSupport1MotorDevelopment";
        this.SittingWoSupport1MotorDevelopment.TabIndex = 1;

        this.NurseVisitInfo = new TTVisual.TTTabPage();
        this.NurseVisitInfo.DisplayIndex = 4;
        this.NurseVisitInfo.TabIndex = 4;
        this.NurseVisitInfo.Text = i18n("M15665", "Hemşire Vizit Bilgileri");
        this.NurseVisitInfo.Name = "NurseVisitInfo";

        this.labelResUserNurseVisitsInfo = new TTVisual.TTLabel();
        this.labelResUserNurseVisitsInfo.Text = "Hemşire";
        this.labelResUserNurseVisitsInfo.Name = "labelResUserNurseVisitsInfo";
        this.labelResUserNurseVisitsInfo.TabIndex = 17;

        this.ResUserNurseVisitsInfo = new TTVisual.TTObjectListBox();
        this.ResUserNurseVisitsInfo.ListDefName = "NurseListDefinition";
        this.ResUserNurseVisitsInfo.Name = "ResUserNurseVisitsInfo";
        this.ResUserNurseVisitsInfo.TabIndex = 16;

        this.labelSuggestionsNurseVisitsInfo = new TTVisual.TTLabel();
        this.labelSuggestionsNurseVisitsInfo.Text = i18n("M12790", "Diğer Detaylar, Öneriler");
        this.labelSuggestionsNurseVisitsInfo.Name = "labelSuggestionsNurseVisitsInfo";
        this.labelSuggestionsNurseVisitsInfo.TabIndex = 15;

        this.SuggestionsNurseVisitsInfo = new TTVisual.TTTextBox();
        this.SuggestionsNurseVisitsInfo.Multiline = true;
        this.SuggestionsNurseVisitsInfo.Name = "SuggestionsNurseVisitsInfo";
        this.SuggestionsNurseVisitsInfo.TabIndex = 14;

        this.labelQuestion7NurseVisitsInfo = new TTVisual.TTLabel();
        this.labelQuestion7NurseVisitsInfo.Text = "Gelişimi ile ilgili bir sorun olduğu düşünülüyor mu?";
        this.labelQuestion7NurseVisitsInfo.Name = "labelQuestion7NurseVisitsInfo";
        this.labelQuestion7NurseVisitsInfo.TabIndex = 13;

        this.Question7NurseVisitsInfo = new TTVisual.TTTextBox();
        this.Question7NurseVisitsInfo.Multiline = true;
        this.Question7NurseVisitsInfo.Name = "Question7NurseVisitsInfo";
        this.Question7NurseVisitsInfo.TabIndex = 12;

        this.labelQuestion6NurseVisitsInfo = new TTVisual.TTLabel();
        this.labelQuestion6NurseVisitsInfo.Text = i18n("M13991", "Evde hemşire ziyaretine ihtiyacı var mı?");
        this.labelQuestion6NurseVisitsInfo.Name = "labelQuestion6NurseVisitsInfo";
        this.labelQuestion6NurseVisitsInfo.TabIndex = 11;

        this.Question6NurseVisitsInfo = new TTVisual.TTTextBox();
        this.Question6NurseVisitsInfo.Multiline = true;
        this.Question6NurseVisitsInfo.Name = "Question6NurseVisitsInfo";
        this.Question6NurseVisitsInfo.TabIndex = 10;

        this.labelQuestion5NurseVisitsInfo = new TTVisual.TTLabel();
        this.labelQuestion5NurseVisitsInfo.Text = i18n("M24765", "Zekayla ilgili bir sorun olduğu düşünülüyor mu?");
        this.labelQuestion5NurseVisitsInfo.Name = "labelQuestion5NurseVisitsInfo";
        this.labelQuestion5NurseVisitsInfo.TabIndex = 9;

        this.Question5NurseVisitsInfo = new TTVisual.TTTextBox();
        this.Question5NurseVisitsInfo.Multiline = true;
        this.Question5NurseVisitsInfo.Name = "Question5NurseVisitsInfo";
        this.Question5NurseVisitsInfo.TabIndex = 8;

        this.labelQuestion4NurseVisitsInfo = new TTVisual.TTLabel();
        this.labelQuestion4NurseVisitsInfo.Text = i18n("M22466", "Şaşılık ile ilgili bir sorun olduğu düşünülüyor mu?");
        this.labelQuestion4NurseVisitsInfo.Name = "labelQuestion4NurseVisitsInfo";
        this.labelQuestion4NurseVisitsInfo.TabIndex = 7;

        this.Question4NurseVisitsInfo = new TTVisual.TTTextBox();
        this.Question4NurseVisitsInfo.Multiline = true;
        this.Question4NurseVisitsInfo.Name = "Question4NurseVisitsInfo";
        this.Question4NurseVisitsInfo.TabIndex = 6;

        this.labelQuestion3NurseVisitsInfo = new TTVisual.TTLabel();
        this.labelQuestion3NurseVisitsInfo.Text = i18n("M14591", "Geç konuşma ile ilgili bir sorunu olduğu düşünülüyor mu?");
        this.labelQuestion3NurseVisitsInfo.Name = "labelQuestion3NurseVisitsInfo";
        this.labelQuestion3NurseVisitsInfo.TabIndex = 5;

        this.Question3NurseVisitsInfo = new TTVisual.TTTextBox();
        this.Question3NurseVisitsInfo.Multiline = true;
        this.Question3NurseVisitsInfo.Name = "Question3NurseVisitsInfo";
        this.Question3NurseVisitsInfo.TabIndex = 4;

        this.labelQuestion2NurseVisitsInfo = new TTVisual.TTLabel();
        this.labelQuestion2NurseVisitsInfo.Text = i18n("M13379", "Duyma ile ilgili herhangi bir sorunu olduğu düşünülüyor mu?");
        this.labelQuestion2NurseVisitsInfo.Name = "labelQuestion2NurseVisitsInfo";
        this.labelQuestion2NurseVisitsInfo.TabIndex = 3;

        this.Question2NurseVisitsInfo = new TTVisual.TTTextBox();
        this.Question2NurseVisitsInfo.Multiline = true;
        this.Question2NurseVisitsInfo.Name = "Question2NurseVisitsInfo";
        this.Question2NurseVisitsInfo.TabIndex = 2;

        this.labelQuestion1NurseVisitsInfo = new TTVisual.TTLabel();
        this.labelQuestion1NurseVisitsInfo.Text = i18n("M11826", "Bir ayda hehangi bir sebepten ikiden fazla ilaç alıyor mu?");
        this.labelQuestion1NurseVisitsInfo.Name = "labelQuestion1NurseVisitsInfo";
        this.labelQuestion1NurseVisitsInfo.TabIndex = 1;

        this.Question1NurseVisitsInfo = new TTVisual.TTTextBox();
        this.Question1NurseVisitsInfo.Multiline = true;
        this.Question1NurseVisitsInfo.Name = "Question1NurseVisitsInfo";
        this.Question1NurseVisitsInfo.TabIndex = 0;

        this.RiskFactors = new TTVisual.TTTabPage();
        this.RiskFactors.DisplayIndex = 5;
        this.RiskFactors.TabIndex = 5;
        this.RiskFactors.Text = "Risk Faktörleri";
        this.RiskFactors.Name = "RiskFactors";

        this.InfantRiskFactors = new TTVisual.TTGrid();
        this.InfantRiskFactors.Name = "InfantRiskFactors";
        this.InfantRiskFactors.TabIndex = 3;

        this.SKRSBebekteRiskFaktorleriInfantRiskFactors = new TTVisual.TTListBoxColumn();
        this.SKRSBebekteRiskFaktorleriInfantRiskFactors.ListDefName = "SKRSBebekteRiskFaktorleriList";
        this.SKRSBebekteRiskFaktorleriInfantRiskFactors.DataMember = "SKRSBebekteRiskFaktorleri";
        this.SKRSBebekteRiskFaktorleriInfantRiskFactors.DisplayIndex = 0;
        this.SKRSBebekteRiskFaktorleriInfantRiskFactors.HeaderText = "";
        this.SKRSBebekteRiskFaktorleriInfantRiskFactors.Name = "SKRSBebekteRiskFaktorleriInfantRiskFactors";
        this.SKRSBebekteRiskFaktorleriInfantRiskFactors.Width = 300;

        this.ChildBrainDevelopmentRiskFactors = new TTVisual.TTGrid();
        this.ChildBrainDevelopmentRiskFactors.Name = "ChildBrainDevelopmentRiskFactors";
        this.ChildBrainDevelopmentRiskFactors.TabIndex = 2;

        this.SKRSBebeginBeyinGlsEtkRisklerChildBrainDevelopmentRiskFactors = new TTVisual.TTListBoxColumn();
        this.SKRSBebeginBeyinGlsEtkRisklerChildBrainDevelopmentRiskFactors.ListDefName = "SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRi";
        this.SKRSBebeginBeyinGlsEtkRisklerChildBrainDevelopmentRiskFactors.DataMember = "SKRSBebeginBeyinGlsEtkRiskler";
        this.SKRSBebeginBeyinGlsEtkRisklerChildBrainDevelopmentRiskFactors.DisplayIndex = 0;
        this.SKRSBebeginBeyinGlsEtkRisklerChildBrainDevelopmentRiskFactors.HeaderText = "";
        this.SKRSBebeginBeyinGlsEtkRisklerChildBrainDevelopmentRiskFactors.Name = "SKRSBebeginBeyinGlsEtkRisklerChildBrainDevelopmentRiskFactors";
        this.SKRSBebeginBeyinGlsEtkRisklerChildBrainDevelopmentRiskFactors.Width = 300;

        this.OldInfantRiskFactors = new TTVisual.TTGrid();
        this.OldInfantRiskFactors.Name = "OldInfantRiskFactors";
        this.OldInfantRiskFactors.TabIndex = 1;

        this.HereditaryHearingLossInfantRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.HereditaryHearingLossInfantRiskFactors.DataMember = "HereditaryHearingLoss";
        this.HereditaryHearingLossInfantRiskFactors.DisplayIndex = 0;
        this.HereditaryHearingLossInfantRiskFactors.HeaderText = "Ailede Kalıtsal İşitme Kaybı Öyküsü";
        this.HereditaryHearingLossInfantRiskFactors.Name = "HereditaryHearingLossInfantRiskFactors";
        this.HereditaryHearingLossInfantRiskFactors.Width = 80;

        this.GKDInfantRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.GKDInfantRiskFactors.DataMember = "GKD";
        this.GKDInfantRiskFactors.DisplayIndex = 1;
        this.GKDInfantRiskFactors.HeaderText = "Ailede ve 1. derece akrabalarda GKD öyküsü";
        this.GKDInfantRiskFactors.Name = "GKDInfantRiskFactors";
        this.GKDInfantRiskFactors.Width = 80;

        this.ConsanguineousMarriageInfantRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.ConsanguineousMarriageInfantRiskFactors.DataMember = "ConsanguineousMarriage";
        this.ConsanguineousMarriageInfantRiskFactors.DisplayIndex = 2;
        this.ConsanguineousMarriageInfantRiskFactors.HeaderText = "Akraba evliliği";
        this.ConsanguineousMarriageInfantRiskFactors.Name = "ConsanguineousMarriageInfantRiskFactors";
        this.ConsanguineousMarriageInfantRiskFactors.Width = 80;

        this.AmnioticFluidAbnormalitiesInfantRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.AmnioticFluidAbnormalitiesInfantRiskFactors.DataMember = "AmnioticFluidAbnormalities";
        this.AmnioticFluidAbnormalitiesInfantRiskFactors.DisplayIndex = 3;
        this.AmnioticFluidAbnormalitiesInfantRiskFactors.HeaderText = "Amniyon sıvı anormallikleri";
        this.AmnioticFluidAbnormalitiesInfantRiskFactors.Name = "AmnioticFluidAbnormalitiesInfantRiskFactors";
        this.AmnioticFluidAbnormalitiesInfantRiskFactors.Width = 80;

        this.MotherHemoglobinopathyCarrierInfantRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.MotherHemoglobinopathyCarrierInfantRiskFactors.DataMember = "MotherHemoglobinopathyCarrier";
        this.MotherHemoglobinopathyCarrierInfantRiskFactors.DisplayIndex = 4;
        this.MotherHemoglobinopathyCarrierInfantRiskFactors.HeaderText = "Anne hemoglobinopati taşıyıcısı";
        this.MotherHemoglobinopathyCarrierInfantRiskFactors.Name = "MotherHemoglobinopathyCarrierInfantRiskFactors";
        this.MotherHemoglobinopathyCarrierInfantRiskFactors.Width = 80;

        this.MotherHasHereditaryIllnessInfantRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.MotherHasHereditaryIllnessInfantRiskFactors.DataMember = "MotherHasHereditaryIllness";
        this.MotherHasHereditaryIllnessInfantRiskFactors.DisplayIndex = 5;
        this.MotherHasHereditaryIllnessInfantRiskFactors.HeaderText = "Annede genetik geçiş gösteren hastalık varlığı";
        this.MotherHasHereditaryIllnessInfantRiskFactors.Name = "MotherHasHereditaryIllnessInfantRiskFactors";
        this.MotherHasHereditaryIllnessInfantRiskFactors.Width = 80;

        this.MotherXRayExposureInfantRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.MotherXRayExposureInfantRiskFactors.DataMember = "MotherXRayExposure";
        this.MotherXRayExposureInfantRiskFactors.DisplayIndex = 6;
        this.MotherXRayExposureInfantRiskFactors.HeaderText = "Annenin maruz kaldığı X-ray";
        this.MotherXRayExposureInfantRiskFactors.Name = "MotherXRayExposureInfantRiskFactors";
        this.MotherXRayExposureInfantRiskFactors.Width = 80;

        this.FeetDeformitiesInfantRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.FeetDeformitiesInfantRiskFactors.DataMember = "FeetDeformities";
        this.FeetDeformitiesInfantRiskFactors.DisplayIndex = 7;
        this.FeetDeformitiesInfantRiskFactors.HeaderText = "Ayak deformiteleri";
        this.FeetDeformitiesInfantRiskFactors.Name = "FeetDeformitiesInfantRiskFactors";
        this.FeetDeformitiesInfantRiskFactors.Width = 80;

        this.FatherHasHereditaryIllnessInfantRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.FatherHasHereditaryIllnessInfantRiskFactors.DataMember = "FatherHasHereditaryIllness";
        this.FatherHasHereditaryIllnessInfantRiskFactors.DisplayIndex = 8;
        this.FatherHasHereditaryIllnessInfantRiskFactors.HeaderText = "Babada genetik geçiş gösteren hastalık varlığı";
        this.FatherHasHereditaryIllnessInfantRiskFactors.Name = "FatherHasHereditaryIllnessInfantRiskFactors";
        this.FatherHasHereditaryIllnessInfantRiskFactors.Width = 80;

        this.FatherHemoglobinopathyCarrierInfantRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.FatherHemoglobinopathyCarrierInfantRiskFactors.DataMember = "FatherHemoglobinopathyCarrier";
        this.FatherHemoglobinopathyCarrierInfantRiskFactors.DisplayIndex = 9;
        this.FatherHemoglobinopathyCarrierInfantRiskFactors.HeaderText = "Baba hemoglobinopati taşıyıcısı";
        this.FatherHemoglobinopathyCarrierInfantRiskFactors.Name = "FatherHemoglobinopathyCarrierInfantRiskFactors";
        this.FatherHemoglobinopathyCarrierInfantRiskFactors.Width = 80;

        this.OldChildBrainDevelopmentRiskFactors = new TTVisual.TTGrid();
        this.OldChildBrainDevelopmentRiskFactors.Name = "OldChildBrainDevelopmentRiskFactors";
        this.OldChildBrainDevelopmentRiskFactors.TabIndex = 0;

        this.AlcoholUseInFamilyChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.AlcoholUseInFamilyChildBrainDevelopmentRiskFactors.DataMember = "AlcoholUseInFamily";
        this.AlcoholUseInFamilyChildBrainDevelopmentRiskFactors.DisplayIndex = 0;
        this.AlcoholUseInFamilyChildBrainDevelopmentRiskFactors.HeaderText = "Ailede alkol kullanımı";
        this.AlcoholUseInFamilyChildBrainDevelopmentRiskFactors.Name = "AlcoholUseInFamilyChildBrainDevelopmentRiskFactors";
        this.AlcoholUseInFamilyChildBrainDevelopmentRiskFactors.Width = 80;

        this.DownSyndromeInFamilyChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.DownSyndromeInFamilyChildBrainDevelopmentRiskFactors.DataMember = "DownSyndromeInFamily";
        this.DownSyndromeInFamilyChildBrainDevelopmentRiskFactors.DisplayIndex = 1;
        this.DownSyndromeInFamilyChildBrainDevelopmentRiskFactors.HeaderText = "Ailede Down Sendromu";
        this.DownSyndromeInFamilyChildBrainDevelopmentRiskFactors.Name = "DownSyndromeInFamilyChildBrainDevelopmentRiskFactors";
        this.DownSyndromeInFamilyChildBrainDevelopmentRiskFactors.Width = 80;

        this.SmokingInFamilyChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.SmokingInFamilyChildBrainDevelopmentRiskFactors.DataMember = "SmokingInFamily";
        this.SmokingInFamilyChildBrainDevelopmentRiskFactors.DisplayIndex = 2;
        this.SmokingInFamilyChildBrainDevelopmentRiskFactors.HeaderText = "Ailede sigara kullanımı";
        this.SmokingInFamilyChildBrainDevelopmentRiskFactors.Name = "SmokingInFamilyChildBrainDevelopmentRiskFactors";
        this.SmokingInFamilyChildBrainDevelopmentRiskFactors.Width = 80;

        this.IrregularHouseholdIncomeChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.IrregularHouseholdIncomeChildBrainDevelopmentRiskFactors.DataMember = "IrregularHouseholdIncome";
        this.IrregularHouseholdIncomeChildBrainDevelopmentRiskFactors.DisplayIndex = 3;
        this.IrregularHouseholdIncomeChildBrainDevelopmentRiskFactors.HeaderText = "Ailenin düzenli gelirinin bulunmaması";
        this.IrregularHouseholdIncomeChildBrainDevelopmentRiskFactors.Name = "IrregularHouseholdIncomeChildBrainDevelopmentRiskFactors";
        this.IrregularHouseholdIncomeChildBrainDevelopmentRiskFactors.Width = 80;

        this.NoHealthInsuranceChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.NoHealthInsuranceChildBrainDevelopmentRiskFactors.DataMember = "NoHealthInsurance";
        this.NoHealthInsuranceChildBrainDevelopmentRiskFactors.DisplayIndex = 4;
        this.NoHealthInsuranceChildBrainDevelopmentRiskFactors.HeaderText = "Ailenin sağlık güvencesinin bulunmaması";
        this.NoHealthInsuranceChildBrainDevelopmentRiskFactors.Name = "NoHealthInsuranceChildBrainDevelopmentRiskFactors";
        this.NoHealthInsuranceChildBrainDevelopmentRiskFactors.Width = 80;

        this.PovertyChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.PovertyChildBrainDevelopmentRiskFactors.DataMember = "Poverty";
        this.PovertyChildBrainDevelopmentRiskFactors.DisplayIndex = 5;
        this.PovertyChildBrainDevelopmentRiskFactors.HeaderText = "Ailenin temel ihtiyaçlarını karşılayamaması";
        this.PovertyChildBrainDevelopmentRiskFactors.Name = "PovertyChildBrainDevelopmentRiskFactors";
        this.PovertyChildBrainDevelopmentRiskFactors.Width = 80;

        this.AnemiaChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.AnemiaChildBrainDevelopmentRiskFactors.DataMember = "Anemia";
        this.AnemiaChildBrainDevelopmentRiskFactors.DisplayIndex = 6;
        this.AnemiaChildBrainDevelopmentRiskFactors.HeaderText = "Anemi (Beslenme yetersizliği bulgusu olarak)";
        this.AnemiaChildBrainDevelopmentRiskFactors.Name = "AnemiaChildBrainDevelopmentRiskFactors";
        this.AnemiaChildBrainDevelopmentRiskFactors.Width = 80;

        this.MotherMentalDisorderChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.MotherMentalDisorderChildBrainDevelopmentRiskFactors.DataMember = "MotherMentalDisorder";
        this.MotherMentalDisorderChildBrainDevelopmentRiskFactors.DisplayIndex = 7;
        this.MotherMentalDisorderChildBrainDevelopmentRiskFactors.HeaderText = "Annede psikolojik bozukluk (şizofreni vb.) şüphesi";
        this.MotherMentalDisorderChildBrainDevelopmentRiskFactors.Name = "MotherMentalDisorderChildBrainDevelopmentRiskFactors";
        this.MotherMentalDisorderChildBrainDevelopmentRiskFactors.Width = 80;

        this.MotherMentalDeficiencyChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.MotherMentalDeficiencyChildBrainDevelopmentRiskFactors.DataMember = "MotherMentalDeficiency";
        this.MotherMentalDeficiencyChildBrainDevelopmentRiskFactors.DisplayIndex = 8;
        this.MotherMentalDeficiencyChildBrainDevelopmentRiskFactors.HeaderText = "Annede zeka geriliği şüphesi";
        this.MotherMentalDeficiencyChildBrainDevelopmentRiskFactors.Name = "MotherMentalDeficiencyChildBrainDevelopmentRiskFactors";
        this.MotherMentalDeficiencyChildBrainDevelopmentRiskFactors.Width = 80;

        this.MotherAnxietyDisorderChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.MotherAnxietyDisorderChildBrainDevelopmentRiskFactors.DataMember = "MotherAnxietyDisorder";
        this.MotherAnxietyDisorderChildBrainDevelopmentRiskFactors.DisplayIndex = 9;
        this.MotherAnxietyDisorderChildBrainDevelopmentRiskFactors.HeaderText = "Annede anksiyete bozukluğu şüphesi";
        this.MotherAnxietyDisorderChildBrainDevelopmentRiskFactors.Name = "MotherAnxietyDisorderChildBrainDevelopmentRiskFactors";
        this.MotherAnxietyDisorderChildBrainDevelopmentRiskFactors.Width = 80;

        this.MotherDepressionChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.MotherDepressionChildBrainDevelopmentRiskFactors.DataMember = "MotherDepression";
        this.MotherDepressionChildBrainDevelopmentRiskFactors.DisplayIndex = 10;
        this.MotherDepressionChildBrainDevelopmentRiskFactors.HeaderText = "Annede depresyon şüphesi";
        this.MotherDepressionChildBrainDevelopmentRiskFactors.Name = "MotherDepressionChildBrainDevelopmentRiskFactors";
        this.MotherDepressionChildBrainDevelopmentRiskFactors.Width = 80;

        this.MotherAlcoholUseChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.MotherAlcoholUseChildBrainDevelopmentRiskFactors.DataMember = "MotherAlcoholUse";
        this.MotherAlcoholUseChildBrainDevelopmentRiskFactors.DisplayIndex = 11;
        this.MotherAlcoholUseChildBrainDevelopmentRiskFactors.HeaderText = "Annenin alkol kullanımı";
        this.MotherAlcoholUseChildBrainDevelopmentRiskFactors.Name = "MotherAlcoholUseChildBrainDevelopmentRiskFactors";
        this.MotherAlcoholUseChildBrainDevelopmentRiskFactors.Width = 80;

        this.MotherDrugAddictionChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.MotherDrugAddictionChildBrainDevelopmentRiskFactors.DataMember = "MotherDrugAddiction";
        this.MotherDrugAddictionChildBrainDevelopmentRiskFactors.DisplayIndex = 12;
        this.MotherDrugAddictionChildBrainDevelopmentRiskFactors.HeaderText = "Annede madde bağımlılığı";
        this.MotherDrugAddictionChildBrainDevelopmentRiskFactors.Name = "MotherDrugAddictionChildBrainDevelopmentRiskFactors";
        this.MotherDrugAddictionChildBrainDevelopmentRiskFactors.Width = 80;

        this.FatherAlcoholUseChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.FatherAlcoholUseChildBrainDevelopmentRiskFactors.DataMember = "FatherAlcoholUse";
        this.FatherAlcoholUseChildBrainDevelopmentRiskFactors.DisplayIndex = 13;
        this.FatherAlcoholUseChildBrainDevelopmentRiskFactors.HeaderText = "Babanın alkol kullanımı";
        this.FatherAlcoholUseChildBrainDevelopmentRiskFactors.Name = "FatherAlcoholUseChildBrainDevelopmentRiskFactors";
        this.FatherAlcoholUseChildBrainDevelopmentRiskFactors.Width = 80;

        this.FatherAnxietyDisorderChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.FatherAnxietyDisorderChildBrainDevelopmentRiskFactors.DataMember = "FatherAnxietyDisorder";
        this.FatherAnxietyDisorderChildBrainDevelopmentRiskFactors.DisplayIndex = 14;
        this.FatherAnxietyDisorderChildBrainDevelopmentRiskFactors.HeaderText = "Babada anksiyete bozukluğu şüphesi";
        this.FatherAnxietyDisorderChildBrainDevelopmentRiskFactors.Name = "FatherAnxietyDisorderChildBrainDevelopmentRiskFactors";
        this.FatherAnxietyDisorderChildBrainDevelopmentRiskFactors.Width = 80;

        this.FatherDepressionChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.FatherDepressionChildBrainDevelopmentRiskFactors.DataMember = "FatherDepression";
        this.FatherDepressionChildBrainDevelopmentRiskFactors.DisplayIndex = 15;
        this.FatherDepressionChildBrainDevelopmentRiskFactors.HeaderText = "Babada depresyon şüphesi";
        this.FatherDepressionChildBrainDevelopmentRiskFactors.Name = "FatherDepressionChildBrainDevelopmentRiskFactors";
        this.FatherDepressionChildBrainDevelopmentRiskFactors.Width = 80;

        this.FatherDrugAddictionChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.FatherDrugAddictionChildBrainDevelopmentRiskFactors.DataMember = "FatherDrugAddiction";
        this.FatherDrugAddictionChildBrainDevelopmentRiskFactors.DisplayIndex = 16;
        this.FatherDrugAddictionChildBrainDevelopmentRiskFactors.HeaderText = "Babada madde bağımlılığı";
        this.FatherDrugAddictionChildBrainDevelopmentRiskFactors.Name = "FatherDrugAddictionChildBrainDevelopmentRiskFactors";
        this.FatherDrugAddictionChildBrainDevelopmentRiskFactors.Width = 80;

        this.FatherMentalDeficiencyChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.FatherMentalDeficiencyChildBrainDevelopmentRiskFactors.DataMember = "FatherMentalDeficiency";
        this.FatherMentalDeficiencyChildBrainDevelopmentRiskFactors.DisplayIndex = 17;
        this.FatherMentalDeficiencyChildBrainDevelopmentRiskFactors.HeaderText = "Babada zeka geriliği şüphesi";
        this.FatherMentalDeficiencyChildBrainDevelopmentRiskFactors.Name = "FatherMentalDeficiencyChildBrainDevelopmentRiskFactors";
        this.FatherMentalDeficiencyChildBrainDevelopmentRiskFactors.Width = 80;

        this.FatherMentalDisorderChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.FatherMentalDisorderChildBrainDevelopmentRiskFactors.DataMember = "FatherMentalDisorder";
        this.FatherMentalDisorderChildBrainDevelopmentRiskFactors.DisplayIndex = 18;
        this.FatherMentalDisorderChildBrainDevelopmentRiskFactors.HeaderText = "Babada psikolojik bozukluk (şizofreni vb.) şüphesi";
        this.FatherMentalDisorderChildBrainDevelopmentRiskFactors.Name = "FatherMentalDisorderChildBrainDevelopmentRiskFactors";
        this.FatherMentalDisorderChildBrainDevelopmentRiskFactors.Width = 80;

        this.PoorWeightGainChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.PoorWeightGainChildBrainDevelopmentRiskFactors.DataMember = "PoorWeightGain";
        this.PoorWeightGainChildBrainDevelopmentRiskFactors.DisplayIndex = 19;
        this.PoorWeightGainChildBrainDevelopmentRiskFactors.HeaderText = "Çocuğun uygun kilo alamaması";
        this.PoorWeightGainChildBrainDevelopmentRiskFactors.Name = "PoorWeightGainChildBrainDevelopmentRiskFactors";
        this.PoorWeightGainChildBrainDevelopmentRiskFactors.Width = 80;

        this.ChildAbuseSuspicionChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.ChildAbuseSuspicionChildBrainDevelopmentRiskFactors.DataMember = "ChildAbuseSuspicion";
        this.ChildAbuseSuspicionChildBrainDevelopmentRiskFactors.DisplayIndex = 20;
        this.ChildAbuseSuspicionChildBrainDevelopmentRiskFactors.HeaderText = "Çocuğun vücudunda fiziksel istismar belirtisi";
        this.ChildAbuseSuspicionChildBrainDevelopmentRiskFactors.Name = "ChildAbuseSuspicionChildBrainDevelopmentRiskFactors";
        this.ChildAbuseSuspicionChildBrainDevelopmentRiskFactors.Width = 80;

        this.OtherPoorFeedingSignsChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.OtherPoorFeedingSignsChildBrainDevelopmentRiskFactors.DataMember = "OtherPoorFeedingSigns";
        this.OtherPoorFeedingSignsChildBrainDevelopmentRiskFactors.DisplayIndex = 21;
        this.OtherPoorFeedingSignsChildBrainDevelopmentRiskFactors.HeaderText = "Diğer beslenme yetersizliği bulguları";
        this.OtherPoorFeedingSignsChildBrainDevelopmentRiskFactors.Name = "OtherPoorFeedingSignsChildBrainDevelopmentRiskFactors";
        this.OtherPoorFeedingSignsChildBrainDevelopmentRiskFactors.Width = 80;

        this.MaternalSmokingChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.MaternalSmokingChildBrainDevelopmentRiskFactors.DataMember = "MaternalSmoking";
        this.MaternalSmokingChildBrainDevelopmentRiskFactors.DisplayIndex = 22;
        this.MaternalSmokingChildBrainDevelopmentRiskFactors.HeaderText = "Gebe / Annenin sigara kullanımı";
        this.MaternalSmokingChildBrainDevelopmentRiskFactors.Name = "MaternalSmokingChildBrainDevelopmentRiskFactors";
        this.MaternalSmokingChildBrainDevelopmentRiskFactors.Width = 80;

        this.MotherAbuseSuspicionChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.MotherAbuseSuspicionChildBrainDevelopmentRiskFactors.DataMember = "MotherAbuseSuspicion";
        this.MotherAbuseSuspicionChildBrainDevelopmentRiskFactors.DisplayIndex = 23;
        this.MotherAbuseSuspicionChildBrainDevelopmentRiskFactors.HeaderText = "Gebelikte, annede fiziksel istismar bulgusu";
        this.MotherAbuseSuspicionChildBrainDevelopmentRiskFactors.Name = "MotherAbuseSuspicionChildBrainDevelopmentRiskFactors";
        this.MotherAbuseSuspicionChildBrainDevelopmentRiskFactors.Width = 80;

        this.PoorMaternalWeightGainChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.PoorMaternalWeightGainChildBrainDevelopmentRiskFactors.DataMember = "PoorMaternalWeightGain";
        this.PoorMaternalWeightGainChildBrainDevelopmentRiskFactors.DisplayIndex = 24;
        this.PoorMaternalWeightGainChildBrainDevelopmentRiskFactors.HeaderText = "Gebelikte, annenin uygun kilo alamaması";
        this.PoorMaternalWeightGainChildBrainDevelopmentRiskFactors.Name = "PoorMaternalWeightGainChildBrainDevelopmentRiskFactors";
        this.PoorMaternalWeightGainChildBrainDevelopmentRiskFactors.Width = 80;

        this.UndesiredPregnancyChildBrainDevelopmentRiskFactors = new TTVisual.TTCheckBoxColumn();
        this.UndesiredPregnancyChildBrainDevelopmentRiskFactors.DataMember = "UndesiredPregnancy";
        this.UndesiredPregnancyChildBrainDevelopmentRiskFactors.DisplayIndex = 25;
        this.UndesiredPregnancyChildBrainDevelopmentRiskFactors.HeaderText = "İstenmeyen gebelik / çocuk";
        this.UndesiredPregnancyChildBrainDevelopmentRiskFactors.Name = "UndesiredPregnancyChildBrainDevelopmentRiskFactors";
        this.UndesiredPregnancyChildBrainDevelopmentRiskFactors.Width = 80;

        this.ParentalActivities = new TTVisual.TTTabPage();
        this.ParentalActivities.DisplayIndex = 6;
        this.ParentalActivities.TabIndex = 6;
        this.ParentalActivities.Text = "Ebeveyn Aktiviteleri";
        this.ParentalActivities.Name = "ParentalActivities";

        this.ParentalActivitiesForPsychologicalDevelopment = new TTVisual.TTGrid();
        this.ParentalActivitiesForPsychologicalDevelopment.Name = "ParentalActivitiesForPsychologicalDevelopment";
        this.ParentalActivitiesForPsychologicalDevelopment.TabIndex = 1;

        this.SKRSEbeveynPsikoGlsmDestkAktvParentalActivitiesForPsychologicalDevelopment = new TTVisual.TTListBoxColumn();
        this.SKRSEbeveynPsikoGlsmDestkAktvParentalActivitiesForPsychologicalDevelopment.ListDefName = "SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktivit";
        this.SKRSEbeveynPsikoGlsmDestkAktvParentalActivitiesForPsychologicalDevelopment.DataMember = "SKRSEbeveynPsikoGlsmDestkAktv";
        this.SKRSEbeveynPsikoGlsmDestkAktvParentalActivitiesForPsychologicalDevelopment.DisplayIndex = 0;
        this.SKRSEbeveynPsikoGlsmDestkAktvParentalActivitiesForPsychologicalDevelopment.HeaderText = "";
        this.SKRSEbeveynPsikoGlsmDestkAktvParentalActivitiesForPsychologicalDevelopment.Name = "SKRSEbeveynPsikoGlsmDestkAktvParentalActivitiesForPsychologicalDevelopment";
        this.SKRSEbeveynPsikoGlsmDestkAktvParentalActivitiesForPsychologicalDevelopment.Width = 300;

        this.OldParentalActivitiesForPsychologicalDevelopment = new TTVisual.TTGrid();
        this.OldParentalActivitiesForPsychologicalDevelopment.Name = "OldParentalActivitiesForPsychologicalDevelopment";
        this.OldParentalActivitiesForPsychologicalDevelopment.TabIndex = 0;

        this.ReadingParentalActivitiesForPsychologicalDevelopment = new TTVisual.TTCheckBoxColumn();
        this.ReadingParentalActivitiesForPsychologicalDevelopment.DataMember = "Reading";
        this.ReadingParentalActivitiesForPsychologicalDevelopment.DisplayIndex = 0;
        this.ReadingParentalActivitiesForPsychologicalDevelopment.HeaderText = "Bebeğe / Çocuğa kitap okuma";
        this.ReadingParentalActivitiesForPsychologicalDevelopment.Name = "ReadingParentalActivitiesForPsychologicalDevelopment";
        this.ReadingParentalActivitiesForPsychologicalDevelopment.Width = 80;

        this.StorytellingParentalActivitiesForPsychologicalDevelopment = new TTVisual.TTCheckBoxColumn();
        this.StorytellingParentalActivitiesForPsychologicalDevelopment.DataMember = "Storytelling";
        this.StorytellingParentalActivitiesForPsychologicalDevelopment.DisplayIndex = 1;
        this.StorytellingParentalActivitiesForPsychologicalDevelopment.HeaderText = "Bebeğe / çocuğa masal anlatma";
        this.StorytellingParentalActivitiesForPsychologicalDevelopment.Name = "StorytellingParentalActivitiesForPsychologicalDevelopment";
        this.StorytellingParentalActivitiesForPsychologicalDevelopment.Width = 80;

        this.SingingParentalActivitiesForPsychologicalDevelopment = new TTVisual.TTCheckBoxColumn();
        this.SingingParentalActivitiesForPsychologicalDevelopment.DataMember = "Singing";
        this.SingingParentalActivitiesForPsychologicalDevelopment.DisplayIndex = 2;
        this.SingingParentalActivitiesForPsychologicalDevelopment.HeaderText = "Bebeğe / çocuğa ninni, şarkı söyleme";
        this.SingingParentalActivitiesForPsychologicalDevelopment.Name = "SingingParentalActivitiesForPsychologicalDevelopment";
        this.SingingParentalActivitiesForPsychologicalDevelopment.Width = 80;

        this.OutsideActivitiesParentalActivitiesForPsychologicalDevelopment = new TTVisual.TTCheckBoxColumn();
        this.OutsideActivitiesParentalActivitiesForPsychologicalDevelopment.DataMember = "OutsideActivities";
        this.OutsideActivitiesParentalActivitiesForPsychologicalDevelopment.DisplayIndex = 3;
        this.OutsideActivitiesParentalActivitiesForPsychologicalDevelopment.HeaderText = "Bebekle / çocukla ev dışında zaman geçirme";
        this.OutsideActivitiesParentalActivitiesForPsychologicalDevelopment.Name = "OutsideActivitiesParentalActivitiesForPsychologicalDevelopment";
        this.OutsideActivitiesParentalActivitiesForPsychologicalDevelopment.Width = 80;

        this.TalkingParentalActivitiesForPsychologicalDevelopment = new TTVisual.TTCheckBoxColumn();
        this.TalkingParentalActivitiesForPsychologicalDevelopment.DataMember = "Talking";
        this.TalkingParentalActivitiesForPsychologicalDevelopment.DisplayIndex = 4;
        this.TalkingParentalActivitiesForPsychologicalDevelopment.HeaderText = "Bebekle / çocukla konuşma";
        this.TalkingParentalActivitiesForPsychologicalDevelopment.Name = "TalkingParentalActivitiesForPsychologicalDevelopment";
        this.TalkingParentalActivitiesForPsychologicalDevelopment.Width = 80;

        this.PlaytimeParentalActivitiesForPsychologicalDevelopment = new TTVisual.TTCheckBoxColumn();
        this.PlaytimeParentalActivitiesForPsychologicalDevelopment.DataMember = "Playtime";
        this.PlaytimeParentalActivitiesForPsychologicalDevelopment.DisplayIndex = 5;
        this.PlaytimeParentalActivitiesForPsychologicalDevelopment.HeaderText = "Bebekle / çocukla oyun oynama";
        this.PlaytimeParentalActivitiesForPsychologicalDevelopment.Name = "PlaytimeParentalActivitiesForPsychologicalDevelopment";
        this.PlaytimeParentalActivitiesForPsychologicalDevelopment.Width = 80;

        this.RegularBondingTimeParentalActivitiesForPsychologicalDevelopment = new TTVisual.TTCheckBoxColumn();
        this.RegularBondingTimeParentalActivitiesForPsychologicalDevelopment.DataMember = "RegularBondingTime";
        this.RegularBondingTimeParentalActivitiesForPsychologicalDevelopment.DisplayIndex = 6;
        this.RegularBondingTimeParentalActivitiesForPsychologicalDevelopment.HeaderText = "Düzenli olarak yalnızca bebeğe/çocuğa zaman ayırma";
        this.RegularBondingTimeParentalActivitiesForPsychologicalDevelopment.Name = "RegularBondingTimeParentalActivitiesForPsychologicalDevelopment";
        this.RegularBondingTimeParentalActivitiesForPsychologicalDevelopment.Width = 80;

        this.NoneParentalActivitiesForPsychologicalDevelopment = new TTVisual.TTCheckBoxColumn();
        this.NoneParentalActivitiesForPsychologicalDevelopment.DataMember = "None";
        this.NoneParentalActivitiesForPsychologicalDevelopment.DisplayIndex = 7;
        this.NoneParentalActivitiesForPsychologicalDevelopment.HeaderText = "Yok";
        this.NoneParentalActivitiesForPsychologicalDevelopment.Name = "NoneParentalActivitiesForPsychologicalDevelopment";
        this.NoneParentalActivitiesForPsychologicalDevelopment.Width = 80;

        this.OtherParentalActivitiesForPsychologicalDevelopment = new TTVisual.TTCheckBoxColumn();
        this.OtherParentalActivitiesForPsychologicalDevelopment.DataMember = "Other";
        this.OtherParentalActivitiesForPsychologicalDevelopment.DisplayIndex = 8;
        this.OtherParentalActivitiesForPsychologicalDevelopment.HeaderText = "Diğer";
        this.OtherParentalActivitiesForPsychologicalDevelopment.Name = "OtherParentalActivitiesForPsychologicalDevelopment";
        this.OtherParentalActivitiesForPsychologicalDevelopment.Width = 80;

        this.InfantRiskFactorsColumns = [this.SKRSBebekteRiskFaktorleriInfantRiskFactors];
        this.ChildBrainDevelopmentRiskFactorsColumns = [this.SKRSBebeginBeyinGlsEtkRisklerChildBrainDevelopmentRiskFactors];
        this.OldInfantRiskFactorsColumns = [this.HereditaryHearingLossInfantRiskFactors, this.GKDInfantRiskFactors, this.ConsanguineousMarriageInfantRiskFactors, this.AmnioticFluidAbnormalitiesInfantRiskFactors, this.MotherHemoglobinopathyCarrierInfantRiskFactors, this.MotherHasHereditaryIllnessInfantRiskFactors, this.MotherXRayExposureInfantRiskFactors, this.FeetDeformitiesInfantRiskFactors, this.FatherHasHereditaryIllnessInfantRiskFactors, this.FatherHemoglobinopathyCarrierInfantRiskFactors];
        this.OldChildBrainDevelopmentRiskFactorsColumns = [this.AlcoholUseInFamilyChildBrainDevelopmentRiskFactors, this.DownSyndromeInFamilyChildBrainDevelopmentRiskFactors, this.SmokingInFamilyChildBrainDevelopmentRiskFactors, this.IrregularHouseholdIncomeChildBrainDevelopmentRiskFactors, this.NoHealthInsuranceChildBrainDevelopmentRiskFactors, this.PovertyChildBrainDevelopmentRiskFactors, this.AnemiaChildBrainDevelopmentRiskFactors, this.MotherMentalDisorderChildBrainDevelopmentRiskFactors, this.MotherMentalDeficiencyChildBrainDevelopmentRiskFactors, this.MotherAnxietyDisorderChildBrainDevelopmentRiskFactors, this.MotherDepressionChildBrainDevelopmentRiskFactors, this.MotherAlcoholUseChildBrainDevelopmentRiskFactors, this.MotherDrugAddictionChildBrainDevelopmentRiskFactors, this.FatherAlcoholUseChildBrainDevelopmentRiskFactors, this.FatherAnxietyDisorderChildBrainDevelopmentRiskFactors, this.FatherDepressionChildBrainDevelopmentRiskFactors, this.FatherDrugAddictionChildBrainDevelopmentRiskFactors, this.FatherMentalDeficiencyChildBrainDevelopmentRiskFactors, this.FatherMentalDisorderChildBrainDevelopmentRiskFactors, this.PoorWeightGainChildBrainDevelopmentRiskFactors, this.ChildAbuseSuspicionChildBrainDevelopmentRiskFactors, this.OtherPoorFeedingSignsChildBrainDevelopmentRiskFactors, this.MaternalSmokingChildBrainDevelopmentRiskFactors, this.MotherAbuseSuspicionChildBrainDevelopmentRiskFactors, this.PoorMaternalWeightGainChildBrainDevelopmentRiskFactors, this.UndesiredPregnancyChildBrainDevelopmentRiskFactors];
        this.ParentalActivitiesForPsychologicalDevelopmentColumns = [this.SKRSEbeveynPsikoGlsmDestkAktvParentalActivitiesForPsychologicalDevelopment];
        this.OldParentalActivitiesForPsychologicalDevelopmentColumns = [this.ReadingParentalActivitiesForPsychologicalDevelopment, this.StorytellingParentalActivitiesForPsychologicalDevelopment, this.SingingParentalActivitiesForPsychologicalDevelopment, this.OutsideActivitiesParentalActivitiesForPsychologicalDevelopment, this.TalkingParentalActivitiesForPsychologicalDevelopment, this.PlaytimeParentalActivitiesForPsychologicalDevelopment, this.RegularBondingTimeParentalActivitiesForPsychologicalDevelopment, this.NoneParentalActivitiesForPsychologicalDevelopment, this.OtherParentalActivitiesForPsychologicalDevelopment];
        this.tttabcontrol1.Controls = [this.MeasurementInfo, this.ComplaintInfo, this.PhysicalExaminationInfo, this.MotorImprovementInfo, this.NurseVisitInfo, this.RiskFactors, this.ParentalActivities];
        this.MeasurementInfo.Controls = [this.InfantNutritionalStatus, this.ttobjectlistbox1, this.labelInfantGrowthStatusInfo, this.labelInfantNutritionalStatus, this.labelWeight, this.Weight, this.labelVisitDate, this.VisitDate, this.labelTricepsSkinfold, this.TricepsSkinfold, this.labelSubscapular, this.Subscapular, this.labelOedema, this.Oedema, this.labelNotes, this.Notes, this.labelMeasurementType, this.MeasurementType, this.labelHeight, this.Height, this.labelHeadCircle, this.HeadCircle, this.labelDate, this.Date, this.labelBMI, this.BMI, this.labelAssessments, this.Assessments, this.labelArmCircle, this.ArmCircle];
        this.ComplaintInfo.Controls = [this.labelPostnatalHistoryChildGrowthComplaintInfo, this.PostnatalHistoryChildGrowthComplaintInfo, this.labelNatalHistoryChildGrowthComplaintInfo, this.NatalHistoryChildGrowthComplaintInfo, this.labelPrenatalHistoryChildGrowthComplaintInfo, this.PrenatalHistoryChildGrowthComplaintInfo, this.labelFamilyHistoryChildGrowthComplaintInfo, this.FamilyHistoryChildGrowthComplaintInfo, this.labelBabyComplaintChildGrowthComplaintInfo, this.BabyComplaintChildGrowthComplaintInfo, this.labelComplaintStartDateChildGrowthComplaintInfo, this.ComplaintStartDateChildGrowthComplaintInfo];
        this.PhysicalExaminationInfo.Controls = [this.labelVitaminDSupplementationInfo, this.VitaminDSupplementationInfo, this.labelIronSupplementationInfo, this.IronSupplementationInfo, this.labelAnalGenitalLocalExaminationPhysicalExamination, this.AnalGenitalLocalExaminationPhysicalExamination, this.labelDetailsPhysicalExamination, this.DetailsPhysicalExamination, this.labelSuggestionsPhysicalExamination, this.SuggestionsPhysicalExamination, this.labelDailyObservationsPhysicalExamination, this.DailyObservationsPhysicalExamination, this.labelExtremitiesPhysicalExamination, this.ExtremitiesPhysicalExamination, this.labelNeurologicalExaminationPhysicalExamination, this.NeurologicalExaminationPhysicalExamination, this.labelAbdomenExaminationPhysicalExamination, this.AbdomenExaminationPhysicalExamination, this.labelCardiovascularSystemPhysicalExamination, this.CardiovascularSystemPhysicalExamination, this.labelRespiratorySystemPhysicalExamination, this.RespiratorySystemPhysicalExamination, this.labelHeadNeckThyroidInfoPhysicalExamination, this.HeadNeckThyroidInfoPhysicalExamination];
        this.MotorImprovementInfo.Controls = [this.labelMotorAssesmentDateMotorDevelopment, this.MotorAssesmentDateMotorDevelopment, this.Seperator6, this.Seperator5, this.Seperator4, this.Seperator3, this.Seperator2, this.Seperator1];
        this.Seperator6.Controls = [this.WalkingAloneCheckAllMotorDevelopment, this.WalkingAlone3MotorDevelopment, this.WalkingAlone2MotorDevelopment, this.WalkingAlone1MotorDevelopment];
        this.Seperator5.Controls = [this.StandingAloneCheckAllMotorDevelopment, this.StandingAlone4MotorDevelopment, this.StandingAlone1MotorDevelopment, this.StandingAlone2MotorDevelopment, this.StandingAlone3MotorDevelopment];
        this.Seperator4.Controls = [this.WalkingWAssistanceCheckAllMotorDevelopment, this.WalkingWAssistance4MotorDevelopment, this.WalkingWAssistance3MotorDevelopment, this.WalkingWAssistance2MotorDevelopment, this.WalkingWAssistance1MotorDevelopment];
        this.Seperator3.Controls = [this.Crawling3MotorDevelopment, this.CrawlingCheckAllMotorDevelopment, this.Crawling2MotorDevelopment, this.Crawling1MotorDevelopment];
        this.Seperator2.Controls = [this.StandingWAssistanceCheckAllMotorDevelopment, this.StandingWAssistance3MotorDevelopment, this.StandingWAssistance2MotorDevelopment, this.StandingWAssistance1MotorDevelopment];
        this.Seperator1.Controls = [this.SittingWoSupport2MotorDevelopment, this.SittingWoSupportCheckAllMotorDevelopment, this.SittingWoSupport1MotorDevelopment];
        this.NurseVisitInfo.Controls = [this.labelResUserNurseVisitsInfo, this.ResUserNurseVisitsInfo, this.labelSuggestionsNurseVisitsInfo, this.SuggestionsNurseVisitsInfo, this.labelQuestion7NurseVisitsInfo, this.Question7NurseVisitsInfo, this.labelQuestion6NurseVisitsInfo, this.Question6NurseVisitsInfo, this.labelQuestion5NurseVisitsInfo, this.Question5NurseVisitsInfo, this.labelQuestion4NurseVisitsInfo, this.Question4NurseVisitsInfo, this.labelQuestion3NurseVisitsInfo, this.Question3NurseVisitsInfo, this.labelQuestion2NurseVisitsInfo, this.Question2NurseVisitsInfo, this.labelQuestion1NurseVisitsInfo, this.Question1NurseVisitsInfo];
        this.RiskFactors.Controls = [this.InfantRiskFactors, this.ChildBrainDevelopmentRiskFactors, this.OldInfantRiskFactors, this.OldChildBrainDevelopmentRiskFactors];
        this.ParentalActivities.Controls = [this.ParentalActivitiesForPsychologicalDevelopment, this.OldParentalActivitiesForPsychologicalDevelopment];
        this.Controls = [this.tttabcontrol1, this.MeasurementInfo, this.InfantNutritionalStatus, this.ttobjectlistbox1, this.labelInfantGrowthStatusInfo, this.labelInfantNutritionalStatus, this.labelWeight, this.Weight, this.labelVisitDate, this.VisitDate, this.labelTricepsSkinfold, this.TricepsSkinfold, this.labelSubscapular, this.Subscapular, this.labelOedema, this.Oedema, this.labelNotes, this.Notes, this.labelMeasurementType, this.MeasurementType, this.labelHeight, this.Height, this.labelHeadCircle, this.HeadCircle, this.labelDate, this.Date, this.labelBMI, this.BMI, this.labelAssessments, this.Assessments, this.labelArmCircle, this.ArmCircle, this.ComplaintInfo, this.labelPostnatalHistoryChildGrowthComplaintInfo, this.PostnatalHistoryChildGrowthComplaintInfo, this.labelNatalHistoryChildGrowthComplaintInfo, this.NatalHistoryChildGrowthComplaintInfo, this.labelPrenatalHistoryChildGrowthComplaintInfo, this.PrenatalHistoryChildGrowthComplaintInfo, this.labelFamilyHistoryChildGrowthComplaintInfo, this.FamilyHistoryChildGrowthComplaintInfo, this.labelBabyComplaintChildGrowthComplaintInfo, this.BabyComplaintChildGrowthComplaintInfo, this.labelComplaintStartDateChildGrowthComplaintInfo, this.ComplaintStartDateChildGrowthComplaintInfo, this.PhysicalExaminationInfo, this.labelVitaminDSupplementationInfo, this.VitaminDSupplementationInfo, this.labelIronSupplementationInfo, this.IronSupplementationInfo, this.labelAnalGenitalLocalExaminationPhysicalExamination, this.AnalGenitalLocalExaminationPhysicalExamination, this.labelDetailsPhysicalExamination, this.DetailsPhysicalExamination, this.labelSuggestionsPhysicalExamination, this.SuggestionsPhysicalExamination, this.labelDailyObservationsPhysicalExamination, this.DailyObservationsPhysicalExamination, this.labelExtremitiesPhysicalExamination, this.ExtremitiesPhysicalExamination, this.labelNeurologicalExaminationPhysicalExamination, this.NeurologicalExaminationPhysicalExamination, this.labelAbdomenExaminationPhysicalExamination, this.AbdomenExaminationPhysicalExamination, this.labelCardiovascularSystemPhysicalExamination, this.CardiovascularSystemPhysicalExamination, this.labelRespiratorySystemPhysicalExamination, this.RespiratorySystemPhysicalExamination, this.labelHeadNeckThyroidInfoPhysicalExamination, this.HeadNeckThyroidInfoPhysicalExamination, this.MotorImprovementInfo, this.labelMotorAssesmentDateMotorDevelopment, this.MotorAssesmentDateMotorDevelopment, this.Seperator6, this.WalkingAloneCheckAllMotorDevelopment, this.WalkingAlone3MotorDevelopment, this.WalkingAlone2MotorDevelopment, this.WalkingAlone1MotorDevelopment, this.Seperator5, this.StandingAloneCheckAllMotorDevelopment, this.StandingAlone4MotorDevelopment, this.StandingAlone1MotorDevelopment, this.StandingAlone2MotorDevelopment, this.StandingAlone3MotorDevelopment, this.Seperator4, this.WalkingWAssistanceCheckAllMotorDevelopment, this.WalkingWAssistance4MotorDevelopment, this.WalkingWAssistance3MotorDevelopment, this.WalkingWAssistance2MotorDevelopment, this.WalkingWAssistance1MotorDevelopment, this.Seperator3, this.Crawling3MotorDevelopment, this.CrawlingCheckAllMotorDevelopment, this.Crawling2MotorDevelopment, this.Crawling1MotorDevelopment, this.Seperator2, this.StandingWAssistanceCheckAllMotorDevelopment, this.StandingWAssistance3MotorDevelopment, this.StandingWAssistance2MotorDevelopment, this.StandingWAssistance1MotorDevelopment, this.Seperator1, this.SittingWoSupport2MotorDevelopment, this.SittingWoSupportCheckAllMotorDevelopment, this.SittingWoSupport1MotorDevelopment, this.NurseVisitInfo, this.labelResUserNurseVisitsInfo, this.ResUserNurseVisitsInfo, this.labelSuggestionsNurseVisitsInfo, this.SuggestionsNurseVisitsInfo, this.labelQuestion7NurseVisitsInfo, this.Question7NurseVisitsInfo, this.labelQuestion6NurseVisitsInfo, this.Question6NurseVisitsInfo, this.labelQuestion5NurseVisitsInfo, this.Question5NurseVisitsInfo, this.labelQuestion4NurseVisitsInfo, this.Question4NurseVisitsInfo, this.labelQuestion3NurseVisitsInfo, this.Question3NurseVisitsInfo, this.labelQuestion2NurseVisitsInfo, this.Question2NurseVisitsInfo, this.labelQuestion1NurseVisitsInfo, this.Question1NurseVisitsInfo, this.RiskFactors, this.InfantRiskFactors, this.SKRSBebekteRiskFaktorleriInfantRiskFactors, this.ChildBrainDevelopmentRiskFactors, this.SKRSBebeginBeyinGlsEtkRisklerChildBrainDevelopmentRiskFactors, this.OldInfantRiskFactors, this.HereditaryHearingLossInfantRiskFactors, this.GKDInfantRiskFactors, this.ConsanguineousMarriageInfantRiskFactors, this.AmnioticFluidAbnormalitiesInfantRiskFactors, this.MotherHemoglobinopathyCarrierInfantRiskFactors, this.MotherHasHereditaryIllnessInfantRiskFactors, this.MotherXRayExposureInfantRiskFactors, this.FeetDeformitiesInfantRiskFactors, this.FatherHasHereditaryIllnessInfantRiskFactors, this.FatherHemoglobinopathyCarrierInfantRiskFactors, this.OldChildBrainDevelopmentRiskFactors, this.AlcoholUseInFamilyChildBrainDevelopmentRiskFactors, this.DownSyndromeInFamilyChildBrainDevelopmentRiskFactors, this.SmokingInFamilyChildBrainDevelopmentRiskFactors, this.IrregularHouseholdIncomeChildBrainDevelopmentRiskFactors, this.NoHealthInsuranceChildBrainDevelopmentRiskFactors, this.PovertyChildBrainDevelopmentRiskFactors, this.AnemiaChildBrainDevelopmentRiskFactors, this.MotherMentalDisorderChildBrainDevelopmentRiskFactors, this.MotherMentalDeficiencyChildBrainDevelopmentRiskFactors, this.MotherAnxietyDisorderChildBrainDevelopmentRiskFactors, this.MotherDepressionChildBrainDevelopmentRiskFactors, this.MotherAlcoholUseChildBrainDevelopmentRiskFactors, this.MotherDrugAddictionChildBrainDevelopmentRiskFactors, this.FatherAlcoholUseChildBrainDevelopmentRiskFactors, this.FatherAnxietyDisorderChildBrainDevelopmentRiskFactors, this.FatherDepressionChildBrainDevelopmentRiskFactors, this.FatherDrugAddictionChildBrainDevelopmentRiskFactors, this.FatherMentalDeficiencyChildBrainDevelopmentRiskFactors, this.FatherMentalDisorderChildBrainDevelopmentRiskFactors, this.PoorWeightGainChildBrainDevelopmentRiskFactors, this.ChildAbuseSuspicionChildBrainDevelopmentRiskFactors, this.OtherPoorFeedingSignsChildBrainDevelopmentRiskFactors, this.MaternalSmokingChildBrainDevelopmentRiskFactors, this.MotherAbuseSuspicionChildBrainDevelopmentRiskFactors, this.PoorMaternalWeightGainChildBrainDevelopmentRiskFactors, this.UndesiredPregnancyChildBrainDevelopmentRiskFactors, this.ParentalActivities, this.ParentalActivitiesForPsychologicalDevelopment, this.SKRSEbeveynPsikoGlsmDestkAktvParentalActivitiesForPsychologicalDevelopment, this.OldParentalActivitiesForPsychologicalDevelopment, this.ReadingParentalActivitiesForPsychologicalDevelopment, this.StorytellingParentalActivitiesForPsychologicalDevelopment, this.SingingParentalActivitiesForPsychologicalDevelopment, this.OutsideActivitiesParentalActivitiesForPsychologicalDevelopment, this.TalkingParentalActivitiesForPsychologicalDevelopment, this.PlaytimeParentalActivitiesForPsychologicalDevelopment, this.RegularBondingTimeParentalActivitiesForPsychologicalDevelopment, this.NoneParentalActivitiesForPsychologicalDevelopment, this.OtherParentalActivitiesForPsychologicalDevelopment, this.ttobjectlistbox2, this.ttobjectlistbox3, this.ttobjectlistbox4, this.ttobjectlistbox5];

    }

  public static getComponentInfoViewModel(patientID: Guid): VisitDetailsComponentInfoViewModel {
    
        let componentInfoViewModel = new VisitDetailsComponentInfoViewModel();
        let queryParameters = new QueryParams();
        queryParameters.ObjectDefID = new Guid('27cdfb0a-64ca-4466-ad10-86bee55e67d4');
        queryParameters.QueryDefID = new Guid('cd2745bd-25d9-4df0-8df0-a582f774022c'); //PatientVisitsList
        let parameters = {};
        parameters['PATIENT'] = new GuidParam(patientID);
        queryParameters.Parameters = parameters;
        componentInfoViewModel.visitQueryParameters = queryParameters;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'VisitDetailsForm';
        componentInfo.ModuleName = 'CocukTakipModule';
        componentInfo.ModulePath = '/Modules/Tibbi_Surec/Cocuk_Takip_Modulu/CocukTakipModule';
        componentInfo.InputParam = new DynamicComponentInputParam("", new ActiveIDsModel(null,null,patientID));
  
      componentInfoViewModel.visitComponentInfo = componentInfo;

        return componentInfoViewModel;
    }

    public static queryResultLoaded(e: any) {

        let columns = e as Array<any>;
        for (let column of columns) {
            if (column.dataField === "VISITDATE") {
                column.caption = i18n("M19914", "Ölçüm Tarihi");
            }
            if (column.dataField === "DATE") {
                column.caption = 'Tarih';
            }
            if (column.dataField === "WEIGHT") {
                column.caption = 'Kilo';
            }
            if (column.dataField === "HEIGHT") {
                column.caption = 'Boy';
            }
            if (column.dataField === "BMI") {
                column.caption = 'BMI';
            }


        }
    }

    openGraphInfo(): void {
        this.showPopup = true;
    }

    public GraphInfoChanged(event): void {

        if (event.selectedItem != null) {

            let that = this;
            //let apiUrlForSelectedGraph: string = '/api/ChildGrowthVisitsService/GetPercentileInfo?graphName=' + event.selectedItem.Name + '&sex=' + this.visitDetailsFormViewModel.PatientSex.KODU + '&PatientID=' + this.visitDetailsFormViewModel.Patient.ObjectID.toString();
            let apiUrlForSelectedGraph: string = '/api/ChildGrowthVisitsService/GetPercentileInfo';

            let obj = new TempObject();
            obj.graphName = event.selectedItem.Name;
            obj.sex = this.visitDetailsFormViewModel.PatientSex.KODU;
            obj.PatientID = this.visitDetailsFormViewModel.PatientID.toString();

            that.httpService.post<any>(apiUrlForSelectedGraph, obj)
                .then(response => {

                    let result = JSON.parse(response);
                    this.percentileInfo = result;


                })
                .catch(error => {
                    console.log(error);
                });

        } else {
            let emptyArray: any;
            this.percentileInfo = emptyArray;
        }
    }

    protected async PostScript(transDef: TTObjectStateTransitionDef) {

        if (this.visitDetailsFormViewModel._ChildGrowthVisits.VisitDate == null || this.visitDetailsFormViewModel._ChildGrowthVisits.VisitDate == undefined)
            throw new Exception('Visit Tarihi Girilmeden İşleme Devam Edemezsiniz.');

        if (this.visitDetailsFormViewModel._ChildGrowthVisits.Date == null || this.visitDetailsFormViewModel._ChildGrowthVisits.Date == undefined)
            throw new Exception('Tarih Girilmeden İşleme Devam Edemezsiniz.');

        //if (this.visitDetailsFormViewModel._ChildGrowthVisits.BabyComplaint == null || this.visitDetailsFormViewModel._ChildGrowthVisits.BabyComplaint == undefined)
        //    throw new Exception('Bebeğin Şikayeti İşleme Devam Edemezsiniz.');

    }

}

export class PercentileInfo {
    age: number;
    P3: number;
    P15: number;
    P50: number;
    P85: number;
    P97: number;
    PatientInfo?: number;

}

export class GraphInfo {
    ID: number;
    Name: string;
    Description: string;
}

export class TempObject {
    graphName: string;
    sex: string;
    PatientID: string;
}

let graphInfo: GraphInfo[] = [{
    ID: 0,
    Name: "LHFA",
    Description: "Boy - Yaş Eğrisi"

}, {
    ID: 1,
    Name: "WFA",
    Description: "Kilo - Yaş Eğrisi"
},
{
    ID: 2,
    Name: "WFH",
    Description: "Kilo - Boy Eğrisi"
},
{
    ID: 3,
    Name: "BFA",
    Description: "Vucüt Kitle İndeksi - Yaş Eğrisi"
},
{
    ID: 4,
    Name: "HCFA",
    Description: "Kafa Çevresi - Yaş Eğrisi"
}, {
    ID: 5,
    Name: "ACFA",
    Description: "Kol Çevresi - Yaş Eğrisi"
}, {
    ID: 6,
    Name: "SSFA",
    Description: "Deri Kıvrımı - Yaş Eğrisi"
}, {
    ID: 7,
    Name: "TSFA",
    Description: "Cilt Kıvrım Kalınlığı - Yaş Eğrisi"
}];

