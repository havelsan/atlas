//$4CEE71CA
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { CigaretteAssessmentFormViewModel } from './CigaretteAssessmentFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { CigaretteExamination } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMedeniHali } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisode } from 'NebulaClient/Model/AtlasClientModel';

import { DynamicReportParameters } from 'Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'Fw/Models/ParameterDefinitionModel';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';

@Component({
    selector: 'CigaretteAssessmentForm',
    templateUrl: './CigaretteAssessmentForm.html',
    providers: [MessageService]
})
export class CigaretteAssessmentForm extends TTVisual.TTForm implements OnInit {
    Challenges: TTVisual.ITTTextBox;
    CigaretteType: TTVisual.ITTEnumComboBox;
    Constipation: TTVisual.ITTCheckBox;
    ContinueSmoking: TTVisual.ITTEnumComboBox;
    DailyCigaretteAmount: TTVisual.ITTTextBox;
    EducationStatusC: TTVisual.ITTObjectListBox;
    EMailPatient: TTVisual.ITTTextBox;
    ExcessiveSmoking: TTVisual.ITTCheckBox;
    FirstSmokeAfterWakeUp: TTVisual.ITTTextBox;
    FirstsmokeAfterWakeUpType: TTVisual.ITTEnumComboBox;
    FreeTime: TTVisual.ITTTextBox;
    gb1: TTVisual.ITTGroupBox;
    GiveUpTime: TTVisual.ITTEnumComboBox;
    HeadacheAndDizziness: TTVisual.ITTCheckBox;
    HeadAndFacialNumbness: TTVisual.ITTCheckBox;
    Imbalance: TTVisual.ITTCheckBox;
    IncreasedAppetite: TTVisual.ITTCheckBox;
    IncreaseSmokingReasons: TTVisual.ITTEnumComboBox;
    Irritability: TTVisual.ITTCheckBox;
    Job: TTVisual.ITTTextBox;
    labelCigaretteType: TTVisual.ITTLabel;
    labelContinueSmoking: TTVisual.ITTLabel;
    labelDailyCigaretteAmount: TTVisual.ITTLabel;
    labelEducationStatusC: TTVisual.ITTLabel;
    labelEMailPatient: TTVisual.ITTLabel;
    labelFirstSmokeAfterWakeUp: TTVisual.ITTLabel;
    labelFreeTime: TTVisual.ITTLabel;
    labelGiveUpTime: TTVisual.ITTLabel;
    labelIncreaseSmokingReasons: TTVisual.ITTLabel;
    labelJob: TTVisual.ITTLabel;
    labelMaritalStatusC: TTVisual.ITTLabel;
    labelOccupationC: TTVisual.ITTLabel;
    labelOtherSmokersAtHome: TTVisual.ITTLabel;
    labelOtherSmokersAtWorkPlace: TTVisual.ITTLabel;
    labelPassiveSmokersAtHome: TTVisual.ITTLabel;
    labelPlacesThatBanSmoking: TTVisual.ITTLabel;
    labelProfessionalSupport: TTVisual.ITTLabel;
    labelQuitSmokingMethod: TTVisual.ITTLabel;
    labelQuitSmokingReason: TTVisual.ITTLabel;
    labelSmokingAmountChange: TTVisual.ITTLabel;
    labelSmokingAtWorkPlaceAmount: TTVisual.ITTLabel;
    labelSmokingStartAge: TTVisual.ITTLabel;
    labelSmokingYearRate: TTVisual.ITTLabel;
    labelStartSmokingReason: TTVisual.ITTLabel;
    labelThinkingOfQuitSmoking: TTVisual.ITTLabel;
    labelTryingQuitSmoking: TTVisual.ITTLabel;
    labelUsedAddictiveDrugs: TTVisual.ITTLabel;
    LossOfConcentration: TTVisual.ITTCheckBox;
    MouthSore: TTVisual.ITTCheckBox;
    NoDifficulty: TTVisual.ITTCheckBox;
    OccupationPatientC: TTVisual.ITTObjectListBox;
    Other: TTVisual.ITTCheckBox;
    OtherSmokersAtHome: TTVisual.ITTEnumComboBox;
    OtherSmokersAtWorkPlace: TTVisual.ITTEnumComboBox;
    PassiveSmokersAtHome: TTVisual.ITTTextBox;
    PlacesThatBanSmoking: TTVisual.ITTEnumComboBox;
    ProfessionalSupport: TTVisual.ITTEnumComboBox;
    QuitSmokingMethod: TTVisual.ITTEnumComboBox;
    QuitSmokingReason: TTVisual.ITTEnumComboBox;
    SKRSMaritalStatus: TTVisual.ITTObjectListBox;
    SleepingDisorder: TTVisual.ITTCheckBox;
    SmokingAmountChange: TTVisual.ITTEnumComboBox;
    SmokingAtWorkPlaceAmount: TTVisual.ITTTextBox;
    SmokingAtWorkPlaceAmountType: TTVisual.ITTEnumComboBox;
    SmokingStartAge: TTVisual.ITTTextBox;
    SmokingYearRate: TTVisual.ITTTextBox;
    StartSmokingReason: TTVisual.ITTEnumComboBox;
    ThinkingOfQuitSmoking: TTVisual.ITTEnumComboBox;
    TryingQuitSmoking: TTVisual.ITTEnumComboBox;
    TryingQuitSmokingAmount: TTVisual.ITTTextBox;
    UsedAddictiveDrugs: TTVisual.ITTEnumComboBox;
    public statesPanelClass: string = "col-lg-6";
    public cigaretteAssessmentFormViewModel: CigaretteAssessmentFormViewModel = new CigaretteAssessmentFormViewModel();
    public get _CigaretteExamination(): CigaretteExamination {
        return this._TTObject as CigaretteExamination;
    }
    private CigaretteAssessmentForm_DocumentUrl: string = '/api/CigaretteExaminationService/CigaretteAssessmentForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalService: IModalService) {
        super('CIGARETTEEXAMINATION', 'CigaretteAssessmentForm');
        this._DocumentServiceUrl = this.CigaretteAssessmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new CigaretteExamination();
        this.cigaretteAssessmentFormViewModel = new CigaretteAssessmentFormViewModel();
        this._ViewModel = this.cigaretteAssessmentFormViewModel;
        this.cigaretteAssessmentFormViewModel._CigaretteExamination = this._TTObject as CigaretteExamination;
        this.cigaretteAssessmentFormViewModel._CigaretteExamination.SubEpisode = new SubEpisode();
        this.cigaretteAssessmentFormViewModel._CigaretteExamination.SubEpisode.Episode = new Episode();
        this.cigaretteAssessmentFormViewModel._CigaretteExamination.SubEpisode.Episode.Patient = new Patient();
        this.cigaretteAssessmentFormViewModel._CigaretteExamination.SubEpisode.Episode.Patient.SKRSMaritalStatus = new SKRSMedeniHali();
        this.cigaretteAssessmentFormViewModel._CigaretteExamination.SubEpisode.Episode.Patient.EducationStatus = new SKRSOgrenimDurumu();
        this.cigaretteAssessmentFormViewModel._CigaretteExamination.SubEpisode.Episode.Patient.Occupation = new SKRSMeslekler();
    }

    protected loadViewModel() {
        let that = this;
        that.cigaretteAssessmentFormViewModel = this._ViewModel as CigaretteAssessmentFormViewModel;
        that._TTObject = this.cigaretteAssessmentFormViewModel._CigaretteExamination;
        if (this.cigaretteAssessmentFormViewModel == null)
            this.cigaretteAssessmentFormViewModel = new CigaretteAssessmentFormViewModel();
        if (this.cigaretteAssessmentFormViewModel._CigaretteExamination == null)
            this.cigaretteAssessmentFormViewModel._CigaretteExamination = new CigaretteExamination();
        let subEpisodeObjectID = that.cigaretteAssessmentFormViewModel._CigaretteExamination["SubEpisode"];
        if (subEpisodeObjectID != null && (typeof subEpisodeObjectID === "string")) {
            let subEpisode = that.cigaretteAssessmentFormViewModel.SubEpisodes.find(o => o.ObjectID.toString() === subEpisodeObjectID.toString());
            if (subEpisode) {
                that.cigaretteAssessmentFormViewModel._CigaretteExamination.SubEpisode = subEpisode;
            }
            if (subEpisode != null) {
                let episodeObjectID = subEpisode["Episode"];
                if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
                    let episode = that.cigaretteAssessmentFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
                    if (episode) {
                        subEpisode.Episode = episode;
                    }


                    if (episode != null) {
                        let patientObjectID = episode["Patient"];
                        if (patientObjectID != null && (typeof patientObjectID === "string")) {
                            let patient = that.cigaretteAssessmentFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                            if (patient) {
                                episode.Patient = patient;
                            }

                            if (patient != null) {
                                let sKRSMaritalStatusObjectID = patient["SKRSMaritalStatus"];
                                if (sKRSMaritalStatusObjectID != null && (typeof sKRSMaritalStatusObjectID === "string")) {
                                    let sKRSMaritalStatus = that.cigaretteAssessmentFormViewModel.SKRSMedeniHalis.find(o => o.ObjectID.toString() === sKRSMaritalStatusObjectID.toString());
                                    if (sKRSMaritalStatus) {
                                        patient.SKRSMaritalStatus = sKRSMaritalStatus;
                                    }
                                }

                                let educationStatusObjectID = patient["EducationStatus"];
                                if (educationStatusObjectID != null && (typeof educationStatusObjectID === "string")) {
                                    let educationStatus = that.cigaretteAssessmentFormViewModel.SKRSOgrenimDurumus.find(o => o.ObjectID.toString() === educationStatusObjectID.toString());
                                    if (educationStatus) {
                                        patient.EducationStatus = educationStatus;
                                    }
                                }

                                let occupationObjectID = patient["Occupation"];
                                if (occupationObjectID != null && (typeof occupationObjectID === "string")) {
                                    let occupation = that.cigaretteAssessmentFormViewModel.SKRSMesleklers.find(o => o.ObjectID.toString() === occupationObjectID.toString());
                                    if (occupation) {
                                        patient.Occupation = occupation;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


    }

async ngOnInit() {
    await this.load(CigaretteAssessmentFormViewModel);
}

public onChallengesChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.Challenges != event) { 
    this._CigaretteExamination.Challenges = event;
}
}

public onCigaretteTypeChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.CigaretteType != event) { 
    this._CigaretteExamination.CigaretteType = event;
}
}

public onConstipationChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.Constipation != event) { 
    this._CigaretteExamination.Constipation = event;
}
}

public onContinueSmokingChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.ContinueSmoking != event) { 
    this._CigaretteExamination.ContinueSmoking = event;
}
}

public onDailyCigaretteAmountChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.DailyCigaretteAmount != event) { 
    this._CigaretteExamination.DailyCigaretteAmount = event;
}
}

public onEducationStatusCChanged(event): void {
    if(this._CigaretteExamination != null &&
    this._CigaretteExamination.SubEpisode != null &&
    this._CigaretteExamination.SubEpisode.Episode != null &&
    this._CigaretteExamination.SubEpisode.Episode.Patient != null && this._CigaretteExamination.SubEpisode.Episode.Patient.EducationStatus != event) { 
    this._CigaretteExamination.SubEpisode.Episode.Patient.EducationStatus = event;
}
}

public onEMailPatientChanged(event): void {
    if(this._CigaretteExamination != null &&
    this._CigaretteExamination.SubEpisode != null &&
    this._CigaretteExamination.SubEpisode.Episode != null &&
    this._CigaretteExamination.SubEpisode.Episode.Patient != null && this._CigaretteExamination.SubEpisode.Episode.Patient.EMail != event) { 
    this._CigaretteExamination.SubEpisode.Episode.Patient.EMail = event;
}
}

public onExcessiveSmokingChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.ExcessiveSmoking != event) { 
    this._CigaretteExamination.ExcessiveSmoking = event;
}
}

public onFirstSmokeAfterWakeUpChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.FirstSmokeAfterWakeUp != event) { 
    this._CigaretteExamination.FirstSmokeAfterWakeUp = event;
}
}

public onFirstsmokeAfterWakeUpTypeChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.FirstsmokeAfterWakeUpType != event) { 
    this._CigaretteExamination.FirstsmokeAfterWakeUpType = event;
}
}

public onFreeTimeChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.FreeTime != event) { 
    this._CigaretteExamination.FreeTime = event;
}
}

public onGiveUpTimeChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.GiveUpTime != event) { 
    this._CigaretteExamination.GiveUpTime = event;
}
}

public onHeadacheAndDizzinessChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.HeadacheAndDizziness != event) { 
    this._CigaretteExamination.HeadacheAndDizziness = event;
}
}

public onHeadAndFacialNumbnessChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.HeadAndFacialNumbness != event) { 
    this._CigaretteExamination.HeadAndFacialNumbness = event;
}
}

public onImbalanceChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.Imbalance != event) { 
    this._CigaretteExamination.Imbalance = event;
}
}

public onIncreasedAppetiteChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.IncreasedAppetite != event) { 
    this._CigaretteExamination.IncreasedAppetite = event;
}
}

public onIncreaseSmokingReasonsChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.IncreaseSmokingReasons != event) { 
    this._CigaretteExamination.IncreaseSmokingReasons = event;
}
}

public onIrritabilityChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.Irritability != event) { 
    this._CigaretteExamination.Irritability = event;
}
}

public onJobChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.Job != event) { 
    this._CigaretteExamination.Job = event;
}
}

public onLossOfConcentrationChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.LossOfConcentration != event) { 
    this._CigaretteExamination.LossOfConcentration = event;
}
}

public onMouthSoreChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.MouthSore != event) { 
    this._CigaretteExamination.MouthSore = event;
}
}

public onNoDifficultyChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.NoDifficulty != event) { 
    this._CigaretteExamination.NoDifficulty = event;
}
}

public onOccupationPatientCChanged(event): void {
    if(this._CigaretteExamination != null &&
    this._CigaretteExamination.SubEpisode != null &&
    this._CigaretteExamination.SubEpisode.Episode != null &&
    this._CigaretteExamination.SubEpisode.Episode.Patient != null && this._CigaretteExamination.SubEpisode.Episode.Patient.Occupation != event) { 
    this._CigaretteExamination.SubEpisode.Episode.Patient.Occupation = event;
}
}

public onOtherChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.Other != event) { 
    this._CigaretteExamination.Other = event;
}
}

public onOtherSmokersAtHomeChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.OtherSmokersAtHome != event) { 
    this._CigaretteExamination.OtherSmokersAtHome = event;
}
}

public onOtherSmokersAtWorkPlaceChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.OtherSmokersAtWorkPlace != event) { 
    this._CigaretteExamination.OtherSmokersAtWorkPlace = event;
}
}

public onPassiveSmokersAtHomeChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.PassiveSmokersAtHome != event) { 
    this._CigaretteExamination.PassiveSmokersAtHome = event;
}
}

public onPlacesThatBanSmokingChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.PlacesThatBanSmoking != event) { 
    this._CigaretteExamination.PlacesThatBanSmoking = event;
}
}

public onProfessionalSupportChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.ProfessionalSupport != event) { 
    this._CigaretteExamination.ProfessionalSupport = event;
}
}

public onQuitSmokingMethodChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.QuitSmokingMethod != event) { 
    this._CigaretteExamination.QuitSmokingMethod = event;
}
}

public onQuitSmokingReasonChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.QuitSmokingReason != event) { 
    this._CigaretteExamination.QuitSmokingReason = event;
}
}

public onSKRSMaritalStatusChanged(event): void {
    if(this._CigaretteExamination != null &&
    this._CigaretteExamination.SubEpisode != null &&
    this._CigaretteExamination.SubEpisode.Episode != null &&
    this._CigaretteExamination.SubEpisode.Episode.Patient != null && this._CigaretteExamination.SubEpisode.Episode.Patient.SKRSMaritalStatus != event) { 
    this._CigaretteExamination.SubEpisode.Episode.Patient.SKRSMaritalStatus = event;
}
}

public onSleepingDisorderChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.SleepingDisorder != event) { 
    this._CigaretteExamination.SleepingDisorder = event;
}
}

public onSmokingAmountChangeChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.SmokingAmountChange != event) { 
    this._CigaretteExamination.SmokingAmountChange = event;
}
}

public onSmokingAtWorkPlaceAmountChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.SmokingAtWorkPlaceAmount != event) { 
    this._CigaretteExamination.SmokingAtWorkPlaceAmount = event;
}
}

public onSmokingAtWorkPlaceAmountTypeChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.SmokingAtWorkPlaceAmountType != event) { 
    this._CigaretteExamination.SmokingAtWorkPlaceAmountType = event;
}
}

public onSmokingStartAgeChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.SmokingStartAge != event) { 
    this._CigaretteExamination.SmokingStartAge = event;
}
}

public onSmokingYearRateChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.SmokingYearRate != event) { 
    this._CigaretteExamination.SmokingYearRate = event;
}
}

public onStartSmokingReasonChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.StartSmokingReason != event) { 
    this._CigaretteExamination.StartSmokingReason = event;
}
}

public onThinkingOfQuitSmokingChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.ThinkingOfQuitSmoking != event) { 
    this._CigaretteExamination.ThinkingOfQuitSmoking = event;
}
}

public onTryingQuitSmokingAmountChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.TryingQuitSmokingAmount != event) { 
    this._CigaretteExamination.TryingQuitSmokingAmount = event;
}
}

public onTryingQuitSmokingChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.TryingQuitSmoking != event) { 
    this._CigaretteExamination.TryingQuitSmoking = event;
}
}

public onUsedAddictiveDrugsChanged(event): void {
    if(this._CigaretteExamination != null && this._CigaretteExamination.UsedAddictiveDrugs != event) { 
    this._CigaretteExamination.UsedAddictiveDrugs = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.SmokingStartAge, "Text", this.__ttObject, "SmokingStartAge");
    redirectProperty(this.CigaretteType, "Value", this.__ttObject, "CigaretteType");
    redirectProperty(this.UsedAddictiveDrugs, "Value", this.__ttObject, "UsedAddictiveDrugs");
    redirectProperty(this.SmokingYearRate, "Text", this.__ttObject, "SmokingYearRate");
    redirectProperty(this.DailyCigaretteAmount, "Text", this.__ttObject, "DailyCigaretteAmount");
    redirectProperty(this.FirstSmokeAfterWakeUp, "Text", this.__ttObject, "FirstSmokeAfterWakeUp");
    redirectProperty(this.FirstsmokeAfterWakeUpType, "Value", this.__ttObject, "FirstsmokeAfterWakeUpType");
    redirectProperty(this.StartSmokingReason, "Value", this.__ttObject, "StartSmokingReason");
    redirectProperty(this.ThinkingOfQuitSmoking, "Value", this.__ttObject, "ThinkingOfQuitSmoking");
    redirectProperty(this.PlacesThatBanSmoking, "Value", this.__ttObject, "PlacesThatBanSmoking");
    redirectProperty(this.Job, "Text", this.__ttObject, "Job");
    redirectProperty(this.QuitSmokingReason, "Value", this.__ttObject, "QuitSmokingReason");
    redirectProperty(this.TryingQuitSmoking, "Value", this.__ttObject, "TryingQuitSmoking");
    redirectProperty(this.TryingQuitSmokingAmount, "Text", this.__ttObject, "TryingQuitSmokingAmount");
    redirectProperty(this.GiveUpTime, "Value", this.__ttObject, "GiveUpTime");
    redirectProperty(this.EMailPatient, "Text", this.__ttObject, "SubEpisode.Episode.Patient.EMail");
    redirectProperty(this.SmokingAmountChange, "Value", this.__ttObject, "SmokingAmountChange");
    redirectProperty(this.QuitSmokingMethod, "Value", this.__ttObject, "QuitSmokingMethod");
    redirectProperty(this.ContinueSmoking, "Value", this.__ttObject, "ContinueSmoking");
    redirectProperty(this.Irritability, "Value", this.__ttObject, "Irritability");
    redirectProperty(this.HeadAndFacialNumbness, "Value", this.__ttObject, "HeadAndFacialNumbness");
    redirectProperty(this.SleepingDisorder, "Value", this.__ttObject, "SleepingDisorder");
    redirectProperty(this.Imbalance, "Value", this.__ttObject, "Imbalance");
    redirectProperty(this.ExcessiveSmoking, "Value", this.__ttObject, "ExcessiveSmoking");
    redirectProperty(this.LossOfConcentration, "Value", this.__ttObject, "LossOfConcentration");
    redirectProperty(this.Constipation, "Value", this.__ttObject, "Constipation");
    redirectProperty(this.HeadacheAndDizziness, "Value", this.__ttObject, "HeadacheAndDizziness");
    redirectProperty(this.NoDifficulty, "Value", this.__ttObject, "NoDifficulty");
    redirectProperty(this.Other, "Value", this.__ttObject, "Other");
    redirectProperty(this.IncreasedAppetite, "Value", this.__ttObject, "IncreasedAppetite");
    redirectProperty(this.MouthSore, "Value", this.__ttObject, "MouthSore");
    redirectProperty(this.Challenges, "Text", this.__ttObject, "Challenges");
    redirectProperty(this.IncreaseSmokingReasons, "Value", this.__ttObject, "IncreaseSmokingReasons");
    redirectProperty(this.OtherSmokersAtHome, "Value", this.__ttObject, "OtherSmokersAtHome");
    redirectProperty(this.SmokingAtWorkPlaceAmount, "Text", this.__ttObject, "SmokingAtWorkPlaceAmount");
    redirectProperty(this.SmokingAtWorkPlaceAmountType, "Value", this.__ttObject, "SmokingAtWorkPlaceAmountType");
    redirectProperty(this.OtherSmokersAtWorkPlace, "Value", this.__ttObject, "OtherSmokersAtWorkPlace");
    redirectProperty(this.PassiveSmokersAtHome, "Text", this.__ttObject, "PassiveSmokersAtHome");
    redirectProperty(this.FreeTime, "Text", this.__ttObject, "FreeTime");
    redirectProperty(this.ProfessionalSupport, "Value", this.__ttObject, "ProfessionalSupport");
}

public initFormControls() : void {
    this.SKRSMaritalStatus = new TTVisual.TTObjectListBox();
    this.SKRSMaritalStatus.ListDefName = "SKRSMesleklerList";
    this.SKRSMaritalStatus.Name = "SKRSMaritalStatus";
    this.SKRSMaritalStatus.TabIndex = 78;

    this.labelProfessionalSupport = new TTVisual.TTLabel();
    this.labelProfessionalSupport.Text = "Profosyonel Destek Aldınız Mı?";
    this.labelProfessionalSupport.Name = "labelProfessionalSupport";
    this.labelProfessionalSupport.TabIndex = 77;

    this.ProfessionalSupport = new TTVisual.TTEnumComboBox();
    this.ProfessionalSupport.DataTypeName = "YesNoEnum";
    this.ProfessionalSupport.Name = "ProfessionalSupport";
    this.ProfessionalSupport.TabIndex = 76;

    this.labelPassiveSmokersAtHome = new TTVisual.TTLabel();
    this.labelPassiveSmokersAtHome.Text = "Evde sigara İçmeyen Ancak Dumana Maruz Kalan Kişi Sayısı";
    this.labelPassiveSmokersAtHome.Name = "labelPassiveSmokersAtHome";
    this.labelPassiveSmokersAtHome.TabIndex = 75;

    this.PassiveSmokersAtHome = new TTVisual.TTTextBox();
    this.PassiveSmokersAtHome.Name = "PassiveSmokersAtHome";
    this.PassiveSmokersAtHome.TabIndex = 74;

    this.FirstSmokeAfterWakeUp = new TTVisual.TTTextBox();
    this.FirstSmokeAfterWakeUp.Name = "FirstSmokeAfterWakeUp";
    this.FirstSmokeAfterWakeUp.TabIndex = 60;

    this.FreeTime = new TTVisual.TTTextBox();
    this.FreeTime.Multiline = true;
    this.FreeTime.Name = "FreeTime";
    this.FreeTime.TabIndex = 56;

    this.SmokingAtWorkPlaceAmount = new TTVisual.TTTextBox();
    this.SmokingAtWorkPlaceAmount.Name = "SmokingAtWorkPlaceAmount";
    this.SmokingAtWorkPlaceAmount.TabIndex = 52;

    this.TryingQuitSmokingAmount = new TTVisual.TTTextBox();
    this.TryingQuitSmokingAmount.Name = "TryingQuitSmokingAmount";
    this.TryingQuitSmokingAmount.TabIndex = 46;

    this.DailyCigaretteAmount = new TTVisual.TTTextBox();
    this.DailyCigaretteAmount.Name = "DailyCigaretteAmount";
    this.DailyCigaretteAmount.TabIndex = 38;

    this.SmokingYearRate = new TTVisual.TTTextBox();
    this.SmokingYearRate.Name = "SmokingYearRate";
    this.SmokingYearRate.TabIndex = 30;

    this.SmokingStartAge = new TTVisual.TTTextBox();
    this.SmokingStartAge.Name = "SmokingStartAge";
    this.SmokingStartAge.TabIndex = 28;

    this.Job = new TTVisual.TTTextBox();
    this.Job.Name = "Job";
    this.Job.TabIndex = 26;

    this.EMailPatient = new TTVisual.TTTextBox();
    this.EMailPatient.Name = "EMailPatient";
    this.EMailPatient.TabIndex = 24;

    this.labelOtherSmokersAtWorkPlace = new TTVisual.TTLabel();
    this.labelOtherSmokersAtWorkPlace.Text = "İş Yerinde Aynı Ortamda Sigara İçen Var Mı?";
    this.labelOtherSmokersAtWorkPlace.Name = "labelOtherSmokersAtWorkPlace";
    this.labelOtherSmokersAtWorkPlace.TabIndex = 73;

    this.OtherSmokersAtWorkPlace = new TTVisual.TTEnumComboBox();
    this.OtherSmokersAtWorkPlace.DataTypeName = "YesNoEnum";
    this.OtherSmokersAtWorkPlace.Name = "OtherSmokersAtWorkPlace";
    this.OtherSmokersAtWorkPlace.TabIndex = 72;

    this.labelOtherSmokersAtHome = new TTVisual.TTLabel();
    this.labelOtherSmokersAtHome.Text = "Evde Sizden Başka Sigara İçen Var Mı?";
    this.labelOtherSmokersAtHome.Name = "labelOtherSmokersAtHome";
    this.labelOtherSmokersAtHome.TabIndex = 71;

    this.OtherSmokersAtHome = new TTVisual.TTEnumComboBox();
    this.OtherSmokersAtHome.DataTypeName = "YesNoEnum";
    this.OtherSmokersAtHome.Name = "OtherSmokersAtHome";
    this.OtherSmokersAtHome.TabIndex = 70;

    this.labelContinueSmoking = new TTVisual.TTLabel();
    this.labelContinueSmoking.Text = "Yatalak Ağır Hasta Olacağınızı Bilseniz Yine de Sigara İçer Misiniz?";
    this.labelContinueSmoking.Name = "labelContinueSmoking";
    this.labelContinueSmoking.TabIndex = 69;

    this.ContinueSmoking = new TTVisual.TTEnumComboBox();
    this.ContinueSmoking.DataTypeName = "YesNoEnum";
    this.ContinueSmoking.Name = "ContinueSmoking";
    this.ContinueSmoking.TabIndex = 68;

    this.labelGiveUpTime = new TTVisual.TTLabel();
    this.labelGiveUpTime.Text = "Vazgeçmek İstediğiniz Zaman Dilimi";
    this.labelGiveUpTime.Name = "labelGiveUpTime";
    this.labelGiveUpTime.TabIndex = 67;

    this.GiveUpTime = new TTVisual.TTEnumComboBox();
    this.GiveUpTime.DataTypeName = "GiveUpTimeEnum";
    this.GiveUpTime.Name = "GiveUpTime";
    this.GiveUpTime.TabIndex = 66;

    this.labelPlacesThatBanSmoking = new TTVisual.TTLabel();
    this.labelPlacesThatBanSmoking.Text = "Sigara Yasağı Olan Yerlerde İçmediğiniz Zaman Rahat Ediyor Musunuz?";
    this.labelPlacesThatBanSmoking.Name = "labelPlacesThatBanSmoking";
    this.labelPlacesThatBanSmoking.TabIndex = 65;

    this.PlacesThatBanSmoking = new TTVisual.TTEnumComboBox();
    this.PlacesThatBanSmoking.DataTypeName = "YesNoEnum";
    this.PlacesThatBanSmoking.Name = "PlacesThatBanSmoking";
    this.PlacesThatBanSmoking.TabIndex = 64;

    this.FirstsmokeAfterWakeUpType = new TTVisual.TTEnumComboBox();
    this.FirstsmokeAfterWakeUpType.DataTypeName = "MinuteHourEnum";
    this.FirstsmokeAfterWakeUpType.Name = "FirstsmokeAfterWakeUpType";
    this.FirstsmokeAfterWakeUpType.TabIndex = 62;

    this.labelFirstSmokeAfterWakeUp = new TTVisual.TTLabel();
    this.labelFirstSmokeAfterWakeUp.Text = "İlk sigarayı Sabah Kalktıktan Ne Kadar Sonra İçiyorsunuz?";
    this.labelFirstSmokeAfterWakeUp.Name = "labelFirstSmokeAfterWakeUp";
    this.labelFirstSmokeAfterWakeUp.TabIndex = 61;

    this.labelUsedAddictiveDrugs = new TTVisual.TTLabel();
    this.labelUsedAddictiveDrugs.Text = "Devamlı Kulandığınız Bağımlılık Yapıcı Madde Var Mı?";
    this.labelUsedAddictiveDrugs.Name = "labelUsedAddictiveDrugs";
    this.labelUsedAddictiveDrugs.TabIndex = 59;

    this.UsedAddictiveDrugs = new TTVisual.TTEnumComboBox();
    this.UsedAddictiveDrugs.DataTypeName = "YesNoEnum";
    this.UsedAddictiveDrugs.Name = "UsedAddictiveDrugs";
    this.UsedAddictiveDrugs.TabIndex = 58;

    this.labelFreeTime = new TTVisual.TTLabel();
    this.labelFreeTime.Text = "Boş Zamanlarını Nasıl Değerlendirirsiniz?";
    this.labelFreeTime.Name = "labelFreeTime";
    this.labelFreeTime.TabIndex = 57;

    this.SmokingAtWorkPlaceAmountType = new TTVisual.TTEnumComboBox();
    this.SmokingAtWorkPlaceAmountType.DataTypeName = "CigaretteAmountTypeEnum";
    this.SmokingAtWorkPlaceAmountType.Name = "SmokingAtWorkPlaceAmountType";
    this.SmokingAtWorkPlaceAmountType.TabIndex = 54;

    this.labelSmokingAtWorkPlaceAmount = new TTVisual.TTLabel();
    this.labelSmokingAtWorkPlaceAmount.Text = "İş Yerinde İçilen Sigara Miktarı/Türü";
    this.labelSmokingAtWorkPlaceAmount.Name = "labelSmokingAtWorkPlaceAmount";
    this.labelSmokingAtWorkPlaceAmount.TabIndex = 53;

    this.labelIncreaseSmokingReasons = new TTVisual.TTLabel();
    this.labelIncreaseSmokingReasons.Text = "Sigarayı İçme İsteğini Arttıran Nedenler";
    this.labelIncreaseSmokingReasons.Name = "labelIncreaseSmokingReasons";
    this.labelIncreaseSmokingReasons.TabIndex = 51;

    this.IncreaseSmokingReasons = new TTVisual.TTEnumComboBox();
    this.IncreaseSmokingReasons.DataTypeName = "IncreaseSmokingReasonEnum";
    this.IncreaseSmokingReasons.Name = "IncreaseSmokingReasons";
    this.IncreaseSmokingReasons.TabIndex = 50;

    this.labelQuitSmokingMethod = new TTVisual.TTLabel();
    this.labelQuitSmokingMethod.Text = "Sigarayı Bırakma Yöntemi";
    this.labelQuitSmokingMethod.Name = "labelQuitSmokingMethod";
    this.labelQuitSmokingMethod.TabIndex = 49;

    this.QuitSmokingMethod = new TTVisual.TTEnumComboBox();
    this.QuitSmokingMethod.DataTypeName = "QuitSmokingMethodEnum";
    this.QuitSmokingMethod.Name = "QuitSmokingMethod";
    this.QuitSmokingMethod.TabIndex = 48;

    this.gb1 = new TTVisual.TTGroupBox();
    this.gb1.Text = "Karşılaşılan Güçlükler";
    this.gb1.Name = "gb1";
    this.gb1.TabIndex = 47;

    this.Challenges = new TTVisual.TTTextBox();
    this.Challenges.Name = "Challenges";
    this.Challenges.TabIndex = 12;

    this.Other = new TTVisual.TTCheckBox();
    this.Other.Value = false;
    this.Other.Title = "Diğer";
    this.Other.Name = "Other";
    this.Other.TabIndex = 11;

    this.NoDifficulty = new TTVisual.TTCheckBox();
    this.NoDifficulty.Value = false;
    this.NoDifficulty.Title = "Zorluk Yok";
    this.NoDifficulty.Name = "NoDifficulty";
    this.NoDifficulty.TabIndex = 10;

    this.MouthSore = new TTVisual.TTCheckBox();
    this.MouthSore.Value = false;
    this.MouthSore.Title = "Ağız Yaraları";
    this.MouthSore.Name = "MouthSore";
    this.MouthSore.TabIndex = 9;

    this.IncreasedAppetite = new TTVisual.TTCheckBox();
    this.IncreasedAppetite.Value = false;
    this.IncreasedAppetite.Title = "İştah Artması";
    this.IncreasedAppetite.Name = "IncreasedAppetite";
    this.IncreasedAppetite.TabIndex = 8;

    this.ExcessiveSmoking = new TTVisual.TTCheckBox();
    this.ExcessiveSmoking.Value = false;
    this.ExcessiveSmoking.Title = "Aşırı Sigara İçme";
    this.ExcessiveSmoking.Name = "ExcessiveSmoking";
    this.ExcessiveSmoking.TabIndex = 7;

    this.Imbalance = new TTVisual.TTCheckBox();
    this.Imbalance.Value = false;
    this.Imbalance.Title = "Dengesizlik";
    this.Imbalance.Name = "Imbalance";
    this.Imbalance.TabIndex = 6;

    this.SleepingDisorder = new TTVisual.TTCheckBox();
    this.SleepingDisorder.Value = false;
    this.SleepingDisorder.Title = "Uyku Bozukluğu";
    this.SleepingDisorder.Name = "SleepingDisorder";
    this.SleepingDisorder.TabIndex = 5;

    this.HeadAndFacialNumbness = new TTVisual.TTCheckBox();
    this.HeadAndFacialNumbness.Value = false;
    this.HeadAndFacialNumbness.Title = "Yüz ve Başta Uyuşma";
    this.HeadAndFacialNumbness.Name = "HeadAndFacialNumbness";
    this.HeadAndFacialNumbness.TabIndex = 4;

    this.LossOfConcentration = new TTVisual.TTCheckBox();
    this.LossOfConcentration.Value = false;
    this.LossOfConcentration.Title = "KonsantrasyonBozukluğu";
    this.LossOfConcentration.Name = "LossOfConcentration";
    this.LossOfConcentration.TabIndex = 3;

    this.Irritability = new TTVisual.TTCheckBox();
    this.Irritability.Value = false;
    this.Irritability.Title = "Sinirlilik";
    this.Irritability.Name = "Irritability";
    this.Irritability.TabIndex = 2;

    this.HeadacheAndDizziness = new TTVisual.TTCheckBox();
    this.HeadacheAndDizziness.Value = false;
    this.HeadacheAndDizziness.Title = "Baş Ağrısı";
    this.HeadacheAndDizziness.Name = "HeadacheAndDizziness";
    this.HeadacheAndDizziness.TabIndex = 1;

    this.Constipation = new TTVisual.TTCheckBox();
    this.Constipation.Value = false;
    this.Constipation.Title = "Kabız";
    this.Constipation.Name = "Constipation";
    this.Constipation.TabIndex = 0;

    this.labelTryingQuitSmoking = new TTVisual.TTLabel();
    this.labelTryingQuitSmoking.Text = "Sigarayı Bırakmayı Denediniz Mi? Kaç Kere?";
    this.labelTryingQuitSmoking.Name = "labelTryingQuitSmoking";
    this.labelTryingQuitSmoking.TabIndex = 45;

    this.TryingQuitSmoking = new TTVisual.TTEnumComboBox();
    this.TryingQuitSmoking.DataTypeName = "YesNoEnum";
    this.TryingQuitSmoking.Name = "TryingQuitSmoking";
    this.TryingQuitSmoking.TabIndex = 44;

    this.labelThinkingOfQuitSmoking = new TTVisual.TTLabel();
    this.labelThinkingOfQuitSmoking.Text = "Sigarayı Bırakmayı Düşündünüz Mü?";
    this.labelThinkingOfQuitSmoking.Name = "labelThinkingOfQuitSmoking";
    this.labelThinkingOfQuitSmoking.TabIndex = 43;

    this.ThinkingOfQuitSmoking = new TTVisual.TTEnumComboBox();
    this.ThinkingOfQuitSmoking.DataTypeName = "YesNoEnum";
    this.ThinkingOfQuitSmoking.Name = "ThinkingOfQuitSmoking";
    this.ThinkingOfQuitSmoking.TabIndex = 42;

    this.labelCigaretteType = new TTVisual.TTLabel();
    this.labelCigaretteType.Text = "Sigara Tipi";
    this.labelCigaretteType.Name = "labelCigaretteType";
    this.labelCigaretteType.TabIndex = 41;

    this.CigaretteType = new TTVisual.TTEnumComboBox();
    this.CigaretteType.DataTypeName = "CigaretteTypeEnum";
    this.CigaretteType.Name = "CigaretteType";
    this.CigaretteType.TabIndex = 40;

    this.labelDailyCigaretteAmount = new TTVisual.TTLabel();
    this.labelDailyCigaretteAmount.Text = "Günde İçilen Sigara Miktarı";
    this.labelDailyCigaretteAmount.Name = "labelDailyCigaretteAmount";
    this.labelDailyCigaretteAmount.TabIndex = 39;

    this.labelSmokingAmountChange = new TTVisual.TTLabel();
    this.labelSmokingAmountChange.Text = "Sigara Miktarındaki Değişim";
    this.labelSmokingAmountChange.Name = "labelSmokingAmountChange";
    this.labelSmokingAmountChange.TabIndex = 37;

    this.SmokingAmountChange = new TTVisual.TTEnumComboBox();
    this.SmokingAmountChange.DataTypeName = "SmokingAmountChangeEnum";
    this.SmokingAmountChange.Name = "SmokingAmountChange";
    this.SmokingAmountChange.TabIndex = 36;

    this.labelQuitSmokingReason = new TTVisual.TTLabel();
    this.labelQuitSmokingReason.Text = "Sigara Bırakma İstek Nedeni";
    this.labelQuitSmokingReason.Name = "labelQuitSmokingReason";
    this.labelQuitSmokingReason.TabIndex = 35;

    this.QuitSmokingReason = new TTVisual.TTEnumComboBox();
    this.QuitSmokingReason.DataTypeName = "QuitSmokingMethodEnum";
    this.QuitSmokingReason.Name = "QuitSmokingReason";
    this.QuitSmokingReason.TabIndex = 34;

    this.labelStartSmokingReason = new TTVisual.TTLabel();
    this.labelStartSmokingReason.Text = "Sigara Başlama Nedeni";
    this.labelStartSmokingReason.Name = "labelStartSmokingReason";
    this.labelStartSmokingReason.TabIndex = 33;

    this.StartSmokingReason = new TTVisual.TTEnumComboBox();
    this.StartSmokingReason.DataTypeName = "SmokingStartReasonEnum";
    this.StartSmokingReason.Name = "StartSmokingReason";
    this.StartSmokingReason.TabIndex = 32;

    this.labelSmokingYearRate = new TTVisual.TTLabel();
    this.labelSmokingYearRate.Text = "Yılda İçilen Sigara Miktarı";
    this.labelSmokingYearRate.Name = "labelSmokingYearRate";
    this.labelSmokingYearRate.TabIndex = 31;

    this.labelSmokingStartAge = new TTVisual.TTLabel();
    this.labelSmokingStartAge.Text = "Sigara Başlama Yaşı";
    this.labelSmokingStartAge.Name = "labelSmokingStartAge";
    this.labelSmokingStartAge.TabIndex = 29;

    this.labelJob = new TTVisual.TTLabel();
    this.labelJob.Text = "Yaptığı İş";
    this.labelJob.Name = "labelJob";
    this.labelJob.TabIndex = 27;

    this.labelEMailPatient = new TTVisual.TTLabel();
    this.labelEMailPatient.Text = "E-Posta";
    this.labelEMailPatient.Name = "labelEMailPatient";
    this.labelEMailPatient.TabIndex = 25;

    this.labelMaritalStatusC = new TTVisual.TTLabel();
    this.labelMaritalStatusC.Text = "Medeni Durumu";
    this.labelMaritalStatusC.Name = "labelMaritalStatusC";
    this.labelMaritalStatusC.TabIndex = 23;

    this.EducationStatusC = new TTVisual.TTObjectListBox();
    this.EducationStatusC.ListDefName = "SKRSOgrenimDurumuList";
    this.EducationStatusC.Name = "EducationStatusC";
    this.EducationStatusC.TabIndex = 2;

    this.labelEducationStatusC = new TTVisual.TTLabel();
    this.labelEducationStatusC.Text = "Öğrenim Durumu";
    this.labelEducationStatusC.Name = "labelEducationStatusC";
    this.labelEducationStatusC.TabIndex = 3;

    this.OccupationPatientC = new TTVisual.TTObjectListBox();
    this.OccupationPatientC.ListDefName = "SKRSMesleklerList";
    this.OccupationPatientC.Name = "OccupationPatientC";
    this.OccupationPatientC.TabIndex = 4;

    this.labelOccupationC = new TTVisual.TTLabel();
    this.labelOccupationC.Text = "Mesleği";
    this.labelOccupationC.Name = "labelOccupationC";
    this.labelOccupationC.TabIndex = 5;

    this.gb1.Controls = [this.Challenges, this.Other, this.NoDifficulty, this.MouthSore, this.IncreasedAppetite, this.ExcessiveSmoking, this.Imbalance, this.SleepingDisorder, this.HeadAndFacialNumbness, this.LossOfConcentration, this.Irritability, this.HeadacheAndDizziness, this.Constipation];
    this.Controls = [this.SKRSMaritalStatus, this.labelProfessionalSupport, this.ProfessionalSupport, this.labelPassiveSmokersAtHome, this.PassiveSmokersAtHome, this.FirstSmokeAfterWakeUp, this.FreeTime, this.SmokingAtWorkPlaceAmount, this.TryingQuitSmokingAmount, this.DailyCigaretteAmount, this.SmokingYearRate, this.SmokingStartAge, this.Job, this.EMailPatient, this.labelOtherSmokersAtWorkPlace, this.OtherSmokersAtWorkPlace, this.labelOtherSmokersAtHome, this.OtherSmokersAtHome, this.labelContinueSmoking, this.ContinueSmoking, this.labelGiveUpTime, this.GiveUpTime, this.labelPlacesThatBanSmoking, this.PlacesThatBanSmoking, this.FirstsmokeAfterWakeUpType, this.labelFirstSmokeAfterWakeUp, this.labelUsedAddictiveDrugs, this.UsedAddictiveDrugs, this.labelFreeTime, this.SmokingAtWorkPlaceAmountType, this.labelSmokingAtWorkPlaceAmount, this.labelIncreaseSmokingReasons, this.IncreaseSmokingReasons, this.labelQuitSmokingMethod, this.QuitSmokingMethod, this.gb1, this.Challenges, this.Other, this.NoDifficulty, this.MouthSore, this.IncreasedAppetite, this.ExcessiveSmoking, this.Imbalance, this.SleepingDisorder, this.HeadAndFacialNumbness, this.LossOfConcentration, this.Irritability, this.HeadacheAndDizziness, this.Constipation, this.labelTryingQuitSmoking, this.TryingQuitSmoking, this.labelThinkingOfQuitSmoking, this.ThinkingOfQuitSmoking, this.labelCigaretteType, this.CigaretteType, this.labelDailyCigaretteAmount, this.labelSmokingAmountChange, this.SmokingAmountChange, this.labelQuitSmokingReason, this.QuitSmokingReason, this.labelStartSmokingReason, this.StartSmokingReason, this.labelSmokingYearRate, this.labelSmokingStartAge, this.labelJob, this.labelEMailPatient, this.labelMaritalStatusC, this.EducationStatusC, this.labelEducationStatusC, this.OccupationPatientC, this.labelOccupationC];

}
    printCigaretteAssessmentForm() {

        let reportData: DynamicReportParameters = {

            Code: 'SIGARADEGERLENDIRMEFORMU',
            ReportParams: { ObjectID: this._CigaretteExamination.ObjectID.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "SİGARA DEĞERLENDİRME FORMU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

}
