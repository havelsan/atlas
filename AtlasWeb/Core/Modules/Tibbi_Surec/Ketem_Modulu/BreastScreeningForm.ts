//$1F828328
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { BreastScreeningFormViewModel } from './BreastScreeningFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BreastScreening } from 'NebulaClient/Model/AtlasClientModel';
import { AnamnesisInfo } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { SigortaliTuru } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAlkolKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKullanilanAilePlanlamasiAPYontemi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMaddeKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMedeniHali } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSSigaraKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisode } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { DynamicReportParameters } from '../../../wwwroot/app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from '../../../wwwroot/app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from '../../../wwwroot/app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from '../../../wwwroot/app/Fw/Models/ParameterDefinitionModel';
import { ModalInfo } from '../../../wwwroot/app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';

@Component({
    selector: 'BreastScreeningForm',
    templateUrl: './BreastScreeningForm.html',
    providers: [MessageService]
})
export class BreastScreeningForm extends TTVisual.TTForm implements OnInit {
    AilePlanlamasiAPYontemi: TTVisual.ITTObjectListBox;
    AnamnesisGB: TTVisual.ITTGroupBox;
    AssessmentCompleted: TTVisual.ITTCheckBox;
    Bening: TTVisual.ITTCheckBox;
    BiopsySuggestion: TTVisual.ITTCheckBox;
    BreastExamination: TTVisual.ITTCheckBox;
    CancerInfoGB: TTVisual.ITTGroupBox;
    Description: TTVisual.ITTTextBox;
    EducationInfoGB: TTVisual.ITTGroupBox;
    EducationStatusPatient: TTVisual.ITTObjectListBox;
    FamilyBreastCA: TTVisual.ITTEnumComboBox;
    FirstGestationalAge: TTVisual.ITTTextBox;
    FirstMarriageAge: TTVisual.ITTTextBox;
    GestationalNumber: TTVisual.ITTTextBox;
    Informed: TTVisual.ITTCheckBox;
    InsufficientResult: TTVisual.ITTCheckBox;
    InsuranceTypePatientAdmission: TTVisual.ITTObjectListBox;
    labelAilePlanlamasiAPYontemi: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelEducationStatusPatient: TTVisual.ITTLabel;
    labelFamilyBreastCA: TTVisual.ITTLabel;
    labelFirstGestationalAge: TTVisual.ITTLabel;
    labelFirstMarriageAge: TTVisual.ITTLabel;
    labelGestationalNumber: TTVisual.ITTLabel;
    labelInsuranceTypePatientAdmission: TTVisual.ITTLabel;
    labelLactation: TTVisual.ITTLabel;
    labelLastMenstruationDate: TTVisual.ITTLabel;
    labelLiveBirthNumber: TTVisual.ITTLabel;
    labelMaritalStatusPerson: TTVisual.ITTLabel;
    labelMastectomy: TTVisual.ITTLabel;
    labelMenarcheAge: TTVisual.ITTLabel;
    labelMenopauseAge: TTVisual.ITTLabel;
    labelMenstrualCycle: TTVisual.ITTLabel;
    labelOccupationPatient: TTVisual.ITTLabel;
    labelPersonalBreastCA: TTVisual.ITTLabel;
    labelSKRSAlkolKullanimiAnamnesisInfo: TTVisual.ITTLabel;
    labelSKRSMaddeKullanimiAnamnesisInfo: TTVisual.ITTLabel;
    labelSKRSSigaraKullanimiAnamnesisInfo: TTVisual.ITTLabel;
    Lactation: TTVisual.ITTEnumComboBox;
    LastMenstruationDate: TTVisual.ITTDateTimePicker;
    LiveBirthNumber: TTVisual.ITTTextBox;
    Malignite: TTVisual.ITTCheckBox;
    Mammography: TTVisual.ITTCheckBox;
    Mastectomy: TTVisual.ITTEnumComboBox;
    MastectomyText: TTVisual.ITTTextBox;
    MenarcheAge: TTVisual.ITTTextBox;
    MenopauseAge: TTVisual.ITTTextBox;
    MenstrualCycle: TTVisual.ITTTextBox;
    OccupationPatient: TTVisual.ITTObjectListBox;
    PersonalBreastCA: TTVisual.ITTEnumComboBox;
    PossibleBening: TTVisual.ITTCheckBox;
    ResultGB: TTVisual.ITTGroupBox;
    SKRSAlkolKullanimiAnamnesisInfo: TTVisual.ITTObjectListBox;
    SKRSMaddeKullanimiAnamnesisInfo: TTVisual.ITTObjectListBox;
    SKRSSigaraKullanimiAnamnesisInfo: TTVisual.ITTObjectListBox;
    SuspiciousAnomaly: TTVisual.ITTCheckBox;
    TaramaBilgileriGB: TTVisual.ITTGroupBox;
    TTListBox: TTVisual.ITTObjectListBox;
    tttextbox1: TTVisual.ITTTextBox;
    public statesPanelClass: string = "col-lg-6";
    public _buttonCaption :string = "Yazdır";
    public _buttonIcon: string = "fa fa-print";
    public breastScreeningFormViewModel: BreastScreeningFormViewModel = new BreastScreeningFormViewModel();
    public get _BreastScreening(): BreastScreening {
        return this._TTObject as BreastScreening;
    }
    private BreastScreeningForm_DocumentUrl: string = '/api/BreastScreeningService/BreastScreeningForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalService: IModalService) {
        super('BREASTSCREENING', 'BreastScreeningForm');
        this._DocumentServiceUrl = this.BreastScreeningForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BreastScreening();
        this.breastScreeningFormViewModel = new BreastScreeningFormViewModel();
        this._ViewModel = this.breastScreeningFormViewModel;
        this.breastScreeningFormViewModel._BreastScreening = this._TTObject as BreastScreening;
        this.breastScreeningFormViewModel._BreastScreening.SubEpisode = new SubEpisode();
        this.breastScreeningFormViewModel._BreastScreening.SubEpisode.Episode = new Episode();
        this.breastScreeningFormViewModel._BreastScreening.SubEpisode.Episode.Patient = new Patient();
        this.breastScreeningFormViewModel._BreastScreening.SubEpisode.Episode.Patient.Occupation = new SKRSMeslekler();
        this.breastScreeningFormViewModel._BreastScreening.SubEpisode.Episode.Patient.EducationStatus = new SKRSOgrenimDurumu();
        this.breastScreeningFormViewModel._BreastScreening.SubEpisode.Episode.Patient.SKRSMaritalStatus = new SKRSMedeniHali();
        this.breastScreeningFormViewModel._BreastScreening.SubEpisode.Episode.MedulaSigortaliTuru = new SigortaliTuru();
        this.breastScreeningFormViewModel._BreastScreening.AnamnesisInfo = new AnamnesisInfo();
        this.breastScreeningFormViewModel._BreastScreening.AnamnesisInfo.SKRSAlkolKullanimi = new SKRSAlkolKullanimi();
        this.breastScreeningFormViewModel._BreastScreening.AnamnesisInfo.SKRSMaddeKullanimi = new SKRSMaddeKullanimi();
        this.breastScreeningFormViewModel._BreastScreening.AnamnesisInfo.SKRSSigaraKullanimi = new SKRSSigaraKullanimi();
        this.breastScreeningFormViewModel._BreastScreening.AilePlanlamasiAPYontemi = new SKRSKullanilanAilePlanlamasiAPYontemi();
    }

    protected loadViewModel() {
        let that = this;
        that.breastScreeningFormViewModel = this._ViewModel as BreastScreeningFormViewModel;
        that._TTObject = this.breastScreeningFormViewModel._BreastScreening;
        if (this.breastScreeningFormViewModel == null)
            this.breastScreeningFormViewModel = new BreastScreeningFormViewModel();
        if (this.breastScreeningFormViewModel._BreastScreening == null)
            this.breastScreeningFormViewModel._BreastScreening = new BreastScreening();
        let subEpisodeObjectID = that.breastScreeningFormViewModel._BreastScreening["SubEpisode"];
        if (subEpisodeObjectID != null && (typeof subEpisodeObjectID === "string")) {
            let subEpisode = that.breastScreeningFormViewModel.SubEpisodes.find(o => o.ObjectID.toString() === subEpisodeObjectID.toString());
            if (subEpisode) {
                that.breastScreeningFormViewModel._BreastScreening.SubEpisode = subEpisode;
            }

            if (subEpisode != null) {
                let episodeObjectID = subEpisode["Episode"];
                if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
                    let episode = that.breastScreeningFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
                    if (episode) {
                        subEpisode.Episode = episode;
                    }

                    if (episode != null) {
                        let patientObjectID = episode["Patient"];
                        if (patientObjectID != null && (typeof patientObjectID === "string")) {
                            let patient = that.breastScreeningFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                            if (patient) {
                                episode.Patient = patient;
                            }

                            if (patient != null) {
                                let occupationObjectID = patient["Occupation"];
                                if (occupationObjectID != null && (typeof occupationObjectID === "string")) {
                                    let occupation = that.breastScreeningFormViewModel.SKRSMesleklers.find(o => o.ObjectID.toString() === occupationObjectID.toString());
                                    if (occupation) {
                                        patient.Occupation = occupation;
                                    }
                                }

                                let educationStatusObjectID = patient["EducationStatus"];
                                if (educationStatusObjectID != null && (typeof educationStatusObjectID === "string")) {
                                    let educationStatus = that.breastScreeningFormViewModel.SKRSOgrenimDurumus.find(o => o.ObjectID.toString() === educationStatusObjectID.toString());
                                    if (educationStatus) {
                                        patient.EducationStatus = educationStatus;
                                    }
                                }

                                let sKRSMaritalStatusObjectID = patient["SKRSMaritalStatus"];
                                if (sKRSMaritalStatusObjectID != null && (typeof sKRSMaritalStatusObjectID === "string")) {
                                    let sKRSMaritalStatus = that.breastScreeningFormViewModel.SKRSMedeniHalis.find(o => o.ObjectID.toString() === sKRSMaritalStatusObjectID.toString());
                                    if (sKRSMaritalStatus) {
                                        patient.SKRSMaritalStatus = sKRSMaritalStatus;
                                    }
                                }

                            }

                        }

                        let medulaSigortaliTuruObjectID = episode["MedulaSigortaliTuru"];
                        if (medulaSigortaliTuruObjectID != null && (typeof medulaSigortaliTuruObjectID === "string")) {
                            let medulaSigortaliTuru = that.breastScreeningFormViewModel.SigortaliTurus.find(o => o.ObjectID.toString() === medulaSigortaliTuruObjectID.toString());
                            if (medulaSigortaliTuru) {
                                episode.MedulaSigortaliTuru = medulaSigortaliTuru;
                            }
                        }
                    }
                }
            }

        }

        let anamnesisInfoObjectID = that.breastScreeningFormViewModel._BreastScreening["AnamnesisInfo"];
        if (anamnesisInfoObjectID != null && (typeof anamnesisInfoObjectID === "string")) {
            let anamnesisInfo = that.breastScreeningFormViewModel.AnamnesisInfos.find(o => o.ObjectID.toString() === anamnesisInfoObjectID.toString());
            if (anamnesisInfo) {
                that.breastScreeningFormViewModel._BreastScreening.AnamnesisInfo = anamnesisInfo;
            }


            if (anamnesisInfo != null) {
                let sKRSAlkolKullanimiObjectID = anamnesisInfo["SKRSAlkolKullanimi"];
                if (sKRSAlkolKullanimiObjectID != null && (typeof sKRSAlkolKullanimiObjectID === "string")) {
                    let sKRSAlkolKullanimi = that.breastScreeningFormViewModel.SKRSAlkolKullanimis.find(o => o.ObjectID.toString() === sKRSAlkolKullanimiObjectID.toString());
                    if (sKRSAlkolKullanimi) {
                        anamnesisInfo.SKRSAlkolKullanimi = sKRSAlkolKullanimi;
                    }
                }

                let sKRSMaddeKullanimiObjectID = anamnesisInfo["SKRSMaddeKullanimi"];
                if (sKRSMaddeKullanimiObjectID != null && (typeof sKRSMaddeKullanimiObjectID === "string")) {
                    let sKRSMaddeKullanimi = that.breastScreeningFormViewModel.SKRSMaddeKullanimis.find(o => o.ObjectID.toString() === sKRSMaddeKullanimiObjectID.toString());
                    if (sKRSMaddeKullanimi) {
                        anamnesisInfo.SKRSMaddeKullanimi = sKRSMaddeKullanimi;
                    }
                }

                let sKRSSigaraKullanimiObjectID = anamnesisInfo["SKRSSigaraKullanimi"];
                if (sKRSSigaraKullanimiObjectID != null && (typeof sKRSSigaraKullanimiObjectID === "string")) {
                    let sKRSSigaraKullanimi = that.breastScreeningFormViewModel.SKRSSigaraKullanimis.find(o => o.ObjectID.toString() === sKRSSigaraKullanimiObjectID.toString());
                    if (sKRSSigaraKullanimi) {
                        anamnesisInfo.SKRSSigaraKullanimi = sKRSSigaraKullanimi;
                    }
                }

            }
        }
        let ailePlanlamasiAPYontemiObjectID = that.breastScreeningFormViewModel._BreastScreening["AilePlanlamasiAPYontemi"];
        if (ailePlanlamasiAPYontemiObjectID != null && (typeof ailePlanlamasiAPYontemiObjectID === "string")) {
            let ailePlanlamasiAPYontemi = that.breastScreeningFormViewModel.SKRSKullanilanAilePlanlamasiAPYontemis.find(o => o.ObjectID.toString() === ailePlanlamasiAPYontemiObjectID.toString());
            if (ailePlanlamasiAPYontemi) {
                that.breastScreeningFormViewModel._BreastScreening.AilePlanlamasiAPYontemi = ailePlanlamasiAPYontemi;
            }
        }


}

async ngOnInit() {
    await this.load();
}

public onAilePlanlamasiAPYontemiChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.AilePlanlamasiAPYontemi != event) { 
    this._BreastScreening.AilePlanlamasiAPYontemi = event;
}
}

public onAssessmentCompletedChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.AssessmentCompleted != event) { 
    this._BreastScreening.AssessmentCompleted = event;
}
}

public onBeningChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.Bening != event) { 
    this._BreastScreening.Bening = event;
}
}

public onBiopsySuggestionChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.BiopsySuggestion != event) { 
    this._BreastScreening.BiopsySuggestion = event;
}
}

public onBreastExaminationChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.BreastExamination != event) { 
    this._BreastScreening.BreastExamination = event;
}
}

public onDescriptionChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.Description != event) { 
    this._BreastScreening.Description = event;
}
}

public onEducationStatusPatientChanged(event): void {
    if(this._BreastScreening != null &&
    this._BreastScreening.SubEpisode != null &&
    this._BreastScreening.SubEpisode.Episode != null &&
    this._BreastScreening.SubEpisode.Episode.Patient != null && this._BreastScreening.SubEpisode.Episode.Patient.EducationStatus != event) { 
    this._BreastScreening.SubEpisode.Episode.Patient.EducationStatus = event;
}
}

public onFamilyBreastCAChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.FamilyBreastCA != event) { 
    this._BreastScreening.FamilyBreastCA = event;
}
}

public onFirstGestationalAgeChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.FirstGestationalAge != event) { 
    this._BreastScreening.FirstGestationalAge = event;
}
}

public onFirstMarriageAgeChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.FirstMarriageAge != event) { 
    this._BreastScreening.FirstMarriageAge = event;
}
}

public onGestationalNumberChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.GestationalNumber != event) { 
    this._BreastScreening.GestationalNumber = event;
}
}

public onInformedChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.Informed != event) { 
    this._BreastScreening.Informed = event;
}
}

public onInsufficientResultChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.InsufficientResult != event) { 
    this._BreastScreening.InsufficientResult = event;
}
}

public onInsuranceTypePatientAdmissionChanged(event): void {
    if(this._BreastScreening != null &&
    this._BreastScreening.SubEpisode != null &&
    this._BreastScreening.SubEpisode.Episode != null && this._BreastScreening.SubEpisode.Episode.MedulaSigortaliTuru != event) { 
    this._BreastScreening.SubEpisode.Episode.MedulaSigortaliTuru = event;
}
}

public onLactationChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.Lactation != event) { 
    this._BreastScreening.Lactation = event;
}
}

public onLastMenstruationDateChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.LastMenstruationDate != event) { 
    this._BreastScreening.LastMenstruationDate = event;
}
}

public onLiveBirthNumberChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.LiveBirthNumber != event) { 
    this._BreastScreening.LiveBirthNumber = event;
}
}

public onMaligniteChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.Malignite != event) { 
    this._BreastScreening.Malignite = event;
}
}

public onMammographyChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.Mammography != event) { 
    this._BreastScreening.Mammography = event;
}
}

public onMastectomyChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.Mastectomy != event) { 
    this._BreastScreening.Mastectomy = event;
}
}

public onMastectomyTextChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.MastectomyText != event) { 
    this._BreastScreening.MastectomyText = event;
}
}

public onMenarcheAgeChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.MenarcheAge != event) { 
    this._BreastScreening.MenarcheAge = event;
}
}

public onMenopauseAgeChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.MenopauseAge != event) { 
    this._BreastScreening.MenopauseAge = event;
}
}

public onMenstrualCycleChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.MenstrualCycle != event) { 
    this._BreastScreening.MenstrualCycle = event;
}
}

public onOccupationPatientChanged(event): void {
    if(this._BreastScreening != null &&
    this._BreastScreening.SubEpisode != null &&
    this._BreastScreening.SubEpisode.Episode != null &&
    this._BreastScreening.SubEpisode.Episode.Patient != null && this._BreastScreening.SubEpisode.Episode.Patient.Occupation != event) { 
    this._BreastScreening.SubEpisode.Episode.Patient.Occupation = event;
}
}

public onPersonalBreastCAChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.PersonalBreastCA != event) { 
    this._BreastScreening.PersonalBreastCA = event;
}
}

public onPossibleBeningChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.PossibleBening != event) { 
    this._BreastScreening.PossibleBening = event;
}
}

public onSKRSAlkolKullanimiAnamnesisInfoChanged(event): void {
    if(this._BreastScreening != null &&
    this._BreastScreening.AnamnesisInfo != null && this._BreastScreening.AnamnesisInfo.SKRSAlkolKullanimi != event) { 
    this._BreastScreening.AnamnesisInfo.SKRSAlkolKullanimi = event;
}
}

public onSKRSMaddeKullanimiAnamnesisInfoChanged(event): void {
    if(this._BreastScreening != null &&
    this._BreastScreening.AnamnesisInfo != null && this._BreastScreening.AnamnesisInfo.SKRSMaddeKullanimi != event) { 
    this._BreastScreening.AnamnesisInfo.SKRSMaddeKullanimi = event;
}
}

public onSKRSSigaraKullanimiAnamnesisInfoChanged(event): void {
    if(this._BreastScreening != null &&
    this._BreastScreening.AnamnesisInfo != null && this._BreastScreening.AnamnesisInfo.SKRSSigaraKullanimi != event) { 
    this._BreastScreening.AnamnesisInfo.SKRSSigaraKullanimi = event;
}
}

public onSuspiciousAnomalyChanged(event): void {
    if(this._BreastScreening != null && this._BreastScreening.SuspiciousAnomaly != event) { 
    this._BreastScreening.SuspiciousAnomaly = event;
}
}

public onTTListBoxChanged(event): void {
    if(this._BreastScreening != null &&
    this._BreastScreening.SubEpisode != null &&
    this._BreastScreening.SubEpisode.Episode != null &&
    this._BreastScreening.SubEpisode.Episode.Patient != null && this._BreastScreening.SubEpisode.Episode.Patient.SKRSMaritalStatus != event) { 
    this._BreastScreening.SubEpisode.Episode.Patient.SKRSMaritalStatus = event;
}
}

    public ontttextbox1Changed(event): void {
        if (this._BreastScreening != null && this._BreastScreening.LactationText != event) { 
            this._BreastScreening.LactationText = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.MenstrualCycle, "Text", this.__ttObject, "MenstrualCycle");
    redirectProperty(this.FirstGestationalAge, "Text", this.__ttObject, "FirstGestationalAge");
    redirectProperty(this.MenarcheAge, "Text", this.__ttObject, "MenarcheAge");
    redirectProperty(this.GestationalNumber, "Text", this.__ttObject, "GestationalNumber");
    redirectProperty(this.MenopauseAge, "Text", this.__ttObject, "MenopauseAge");
    redirectProperty(this.LiveBirthNumber, "Text", this.__ttObject, "LiveBirthNumber");
    redirectProperty(this.LastMenstruationDate, "Value", this.__ttObject, "LastMenstruationDate");
    redirectProperty(this.FirstMarriageAge, "Text", this.__ttObject, "FirstMarriageAge");
    redirectProperty(this.FamilyBreastCA, "Value", this.__ttObject, "FamilyBreastCA");
    redirectProperty(this.PersonalBreastCA, "Value", this.__ttObject, "PersonalBreastCA");
    redirectProperty(this.Mastectomy, "Value", this.__ttObject, "Mastectomy");
    redirectProperty(this.MastectomyText, "Text", this.__ttObject, "MastectomyText");
    redirectProperty(this.Lactation, "Value", this.__ttObject, "Lactation");
    redirectProperty(this.tttextbox1, "Text", this.__ttObject, "Lactation_Text");
    redirectProperty(this.BreastExamination, "Value", this.__ttObject, "BreastExamination");
    redirectProperty(this.Malignite, "Value", this.__ttObject, "Malignite");
    redirectProperty(this.Bening, "Value", this.__ttObject, "Bening");
    redirectProperty(this.AssessmentCompleted, "Value", this.__ttObject, "AssessmentCompleted");
    redirectProperty(this.PossibleBening, "Value", this.__ttObject, "PossibleBening");
    redirectProperty(this.Informed, "Value", this.__ttObject, "Informed");
    redirectProperty(this.Mammography, "Value", this.__ttObject, "Mammography");
    redirectProperty(this.BiopsySuggestion, "Value", this.__ttObject, "BiopsySuggestion");
    redirectProperty(this.SuspiciousAnomaly, "Value", this.__ttObject, "SuspiciousAnomaly");
    redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    redirectProperty(this.InsufficientResult, "Value", this.__ttObject, "InsufficientResult");
}

public initFormControls() : void {
    this.EducationInfoGB = new TTVisual.TTGroupBox();
    this.EducationInfoGB.Text = "Öğrenim ve İş Bilgileri";
    this.EducationInfoGB.Name = "EducationInfoGB";
    this.EducationInfoGB.TabIndex = 24;

    this.labelOccupationPatient = new TTVisual.TTLabel();
    this.labelOccupationPatient.Text = "Mesleği";
    this.labelOccupationPatient.Name = "labelOccupationPatient";
    this.labelOccupationPatient.TabIndex = 9;

    this.OccupationPatient = new TTVisual.TTObjectListBox();
    this.OccupationPatient.ListDefName = "SKRSMesleklerList";
    this.OccupationPatient.Name = "OccupationPatient";
    this.OccupationPatient.TabIndex = 8;

    this.labelEducationStatusPatient = new TTVisual.TTLabel();
    this.labelEducationStatusPatient.Text = "Öğrenim Durumu";
    this.labelEducationStatusPatient.Name = "labelEducationStatusPatient";
    this.labelEducationStatusPatient.TabIndex = 7;

    this.EducationStatusPatient = new TTVisual.TTObjectListBox();
    this.EducationStatusPatient.ListDefName = "SKRSOgrenimDurumuList";
    this.EducationStatusPatient.Name = "EducationStatusPatient";
    this.EducationStatusPatient.TabIndex = 6;

    this.labelInsuranceTypePatientAdmission = new TTVisual.TTLabel();
    this.labelInsuranceTypePatientAdmission.Text = "İş Durumu";
    this.labelInsuranceTypePatientAdmission.Name = "labelInsuranceTypePatientAdmission";
    this.labelInsuranceTypePatientAdmission.TabIndex = 5;

    this.InsuranceTypePatientAdmission = new TTVisual.TTObjectListBox();
    this.InsuranceTypePatientAdmission.ListDefName = "SigortaliTuruDefinitionList";
    this.InsuranceTypePatientAdmission.Name = "InsuranceTypePatientAdmission";
    this.InsuranceTypePatientAdmission.TabIndex = 4;

    this.ResultGB = new TTVisual.TTGroupBox();
    this.ResultGB.Text = "Sonuç Bilgileri";
    this.ResultGB.Name = "ResultGB";
    this.ResultGB.TabIndex = 23;

    this.labelDescription = new TTVisual.TTLabel();
    this.labelDescription.Text = "Açıklama";
    this.labelDescription.Name = "labelDescription";
    this.labelDescription.TabIndex = 11;

    this.Description = new TTVisual.TTTextBox();
    this.Description.Multiline = true;
    this.Description.Name = "Description";
    this.Description.TabIndex = 10;

    this.SuspiciousAnomaly = new TTVisual.TTCheckBox();
    this.SuspiciousAnomaly.Value = false;
    this.SuspiciousAnomaly.Title = "Şüpheli Anomali";
    this.SuspiciousAnomaly.Name = "SuspiciousAnomaly";
    this.SuspiciousAnomaly.TabIndex = 9;

    this.InsufficientResult = new TTVisual.TTCheckBox();
    this.InsufficientResult.Value = false;
    this.InsufficientResult.Title = "Yetersiz Sonuç (Yorumlanamıyor)";
    this.InsufficientResult.Name = "InsufficientResult";
    this.InsufficientResult.TabIndex = 8;

    this.Informed = new TTVisual.TTCheckBox();
    this.Informed.Value = false;
    this.Informed.Title = "Bilgilendirildi ve Evine Gönderildi";
    this.Informed.Name = "Informed";
    this.Informed.TabIndex = 7;

    this.AssessmentCompleted = new TTVisual.TTCheckBox();
    this.AssessmentCompleted.Value = false;
    this.AssessmentCompleted.Title = "Değerlendirme Tamamlandı";
    this.AssessmentCompleted.Name = "AssessmentCompleted";
    this.AssessmentCompleted.TabIndex = 6;

    this.Malignite = new TTVisual.TTCheckBox();
    this.Malignite.Value = false;
    this.Malignite.Title = "Malignite İçin büyük Oranda Fikir Verici";
    this.Malignite.Name = "Malignite";
    this.Malignite.TabIndex = 5;

    this.BiopsySuggestion = new TTVisual.TTCheckBox();
    this.BiopsySuggestion.Value = false;
    this.BiopsySuggestion.Title = "Biyopsi Önerisi Yapıldı";
    this.BiopsySuggestion.Name = "BiopsySuggestion";
    this.BiopsySuggestion.TabIndex = 4;

    this.Mammography = new TTVisual.TTCheckBox();
    this.Mammography.Value = false;
    this.Mammography.Title = "Mamografi Çekildi";
    this.Mammography.Name = "Mammography";
    this.Mammography.TabIndex = 3;

    this.PossibleBening = new TTVisual.TTCheckBox();
    this.PossibleBening.Value = false;
    this.PossibleBening.Title = "Muhtemelen Bening (Kısa Fönemde Takip) Olağan Dışı Takip";
    this.PossibleBening.Name = "PossibleBening";
    this.PossibleBening.TabIndex = 2;

    this.Bening = new TTVisual.TTCheckBox();
    this.Bening.Value = false;
    this.Bening.Title = "Bening Bulgulara Rastlandı";
    this.Bening.Name = "Bening";
    this.Bening.TabIndex = 1;

    this.BreastExamination = new TTVisual.TTCheckBox();
    this.BreastExamination.Value = false;
    this.BreastExamination.Title = "Normal Meme Muayenesi Yapıldı";
    this.BreastExamination.Name = "BreastExamination";
    this.BreastExamination.TabIndex = 0;

    this.CancerInfoGB = new TTVisual.TTGroupBox();
    this.CancerInfoGB.Text = "Kanser ve Laktasyon Öykü Bilgileri";
    this.CancerInfoGB.Name = "CancerInfoGB";
    this.CancerInfoGB.TabIndex = 22;

    this.tttextbox1 = new TTVisual.TTTextBox();
    this.tttextbox1.Name = "tttextbox1";
    this.tttextbox1.TabIndex = 10;

    this.labelLactation = new TTVisual.TTLabel();
    this.labelLactation.Text = "Laktasyon Öyküsü";
    this.labelLactation.Name = "labelLactation";
    this.labelLactation.TabIndex = 9;

    this.Lactation = new TTVisual.TTEnumComboBox();
    this.Lactation.DataTypeName = "VarYokGarantiEnum";
    this.Lactation.Name = "Lactation";
    this.Lactation.TabIndex = 8;

    this.MastectomyText = new TTVisual.TTTextBox();
    this.MastectomyText.Name = "MastectomyText";
    this.MastectomyText.TabIndex = 6;

    this.labelMastectomy = new TTVisual.TTLabel();
    this.labelMastectomy.Text = "Mastektomi Yapılmış Mı?";
    this.labelMastectomy.Name = "labelMastectomy";
    this.labelMastectomy.TabIndex = 5;

    this.Mastectomy = new TTVisual.TTEnumComboBox();
    this.Mastectomy.DataTypeName = "YesNoEnum";
    this.Mastectomy.Name = "Mastectomy";
    this.Mastectomy.TabIndex = 4;

    this.labelPersonalBreastCA = new TTVisual.TTLabel();
    this.labelPersonalBreastCA.Text = "Kişisel Meme CA Öyküsü";
    this.labelPersonalBreastCA.Name = "labelPersonalBreastCA";
    this.labelPersonalBreastCA.TabIndex = 3;

    this.PersonalBreastCA = new TTVisual.TTEnumComboBox();
    this.PersonalBreastCA.DataTypeName = "PersonalBreastCAEnum";
    this.PersonalBreastCA.Name = "PersonalBreastCA";
    this.PersonalBreastCA.TabIndex = 2;

    this.labelFamilyBreastCA = new TTVisual.TTLabel();
    this.labelFamilyBreastCA.Text = "Ailede Meme CA Öyküsü";
    this.labelFamilyBreastCA.Name = "labelFamilyBreastCA";
    this.labelFamilyBreastCA.TabIndex = 1;

    this.FamilyBreastCA = new TTVisual.TTEnumComboBox();
    this.FamilyBreastCA.DataTypeName = "VarYokGarantiEnum";
    this.FamilyBreastCA.Name = "FamilyBreastCA";
    this.FamilyBreastCA.TabIndex = 0;

    this.AnamnesisGB = new TTVisual.TTGroupBox();
    this.AnamnesisGB.Text = "Anemnez Bilgileri";
    this.AnamnesisGB.Name = "AnamnesisGB";
    this.AnamnesisGB.TabIndex = 21;

    this.labelSKRSAlkolKullanimiAnamnesisInfo = new TTVisual.TTLabel();
    this.labelSKRSAlkolKullanimiAnamnesisInfo.Text = "Alkol Kullanımı";
    this.labelSKRSAlkolKullanimiAnamnesisInfo.Name = "labelSKRSAlkolKullanimiAnamnesisInfo";
    this.labelSKRSAlkolKullanimiAnamnesisInfo.TabIndex = 5;

    this.SKRSAlkolKullanimiAnamnesisInfo = new TTVisual.TTObjectListBox();
    this.SKRSAlkolKullanimiAnamnesisInfo.ListDefName = "SKRSAlkolKullanimiList";
    this.SKRSAlkolKullanimiAnamnesisInfo.Name = "SKRSAlkolKullanimiAnamnesisInfo";
    this.SKRSAlkolKullanimiAnamnesisInfo.TabIndex = 4;

    this.labelSKRSMaddeKullanimiAnamnesisInfo = new TTVisual.TTLabel();
    this.labelSKRSMaddeKullanimiAnamnesisInfo.Text = "Madde Kullanımı";
    this.labelSKRSMaddeKullanimiAnamnesisInfo.Name = "labelSKRSMaddeKullanimiAnamnesisInfo";
    this.labelSKRSMaddeKullanimiAnamnesisInfo.TabIndex = 3;

    this.SKRSMaddeKullanimiAnamnesisInfo = new TTVisual.TTObjectListBox();
    this.SKRSMaddeKullanimiAnamnesisInfo.ListDefName = "SKRSMaddeKullanimiList";
    this.SKRSMaddeKullanimiAnamnesisInfo.Name = "SKRSMaddeKullanimiAnamnesisInfo";
    this.SKRSMaddeKullanimiAnamnesisInfo.TabIndex = 2;

    this.labelSKRSSigaraKullanimiAnamnesisInfo = new TTVisual.TTLabel();
    this.labelSKRSSigaraKullanimiAnamnesisInfo.Text = "Sigara Kullanımı";
    this.labelSKRSSigaraKullanimiAnamnesisInfo.Name = "labelSKRSSigaraKullanimiAnamnesisInfo";
    this.labelSKRSSigaraKullanimiAnamnesisInfo.TabIndex = 1;

    this.SKRSSigaraKullanimiAnamnesisInfo = new TTVisual.TTObjectListBox();
    this.SKRSSigaraKullanimiAnamnesisInfo.ListDefName = "SKRSSigaraKullanimiList";
    this.SKRSSigaraKullanimiAnamnesisInfo.Name = "SKRSSigaraKullanimiAnamnesisInfo";
    this.SKRSSigaraKullanimiAnamnesisInfo.TabIndex = 0;

    this.TaramaBilgileriGB = new TTVisual.TTGroupBox();
    this.TaramaBilgileriGB.Text = "Tarama Bilgileri";
    this.TaramaBilgileriGB.Name = "TaramaBilgileriGB";
    this.TaramaBilgileriGB.TabIndex = 20;

    this.TTListBox = new TTVisual.TTObjectListBox();
    this.TTListBox.ListDefName = "SKRSMedeniHaliList";
    this.TTListBox.Name = "TTListBox";
    this.TTListBox.TabIndex = 36;

    this.labelAilePlanlamasiAPYontemi = new TTVisual.TTLabel();
    this.labelAilePlanlamasiAPYontemi.Text = "Kullanılan Aile Planlaması Yöntemi";
    this.labelAilePlanlamasiAPYontemi.Name = "labelAilePlanlamasiAPYontemi";
    this.labelAilePlanlamasiAPYontemi.TabIndex = 35;

    this.AilePlanlamasiAPYontemi = new TTVisual.TTObjectListBox();
    this.AilePlanlamasiAPYontemi.ListDefName = "SKRSKullanilanAilePlanlamasiAPYontemiList";
    this.AilePlanlamasiAPYontemi.Name = "AilePlanlamasiAPYontemi";
    this.AilePlanlamasiAPYontemi.TabIndex = 34;

    this.labelLiveBirthNumber = new TTVisual.TTLabel();
    this.labelLiveBirthNumber.Text = "Canlı Doğum Sayısı";
    this.labelLiveBirthNumber.Name = "labelLiveBirthNumber";
    this.labelLiveBirthNumber.TabIndex = 33;

    this.LiveBirthNumber = new TTVisual.TTTextBox();
    this.LiveBirthNumber.Name = "LiveBirthNumber";
    this.LiveBirthNumber.TabIndex = 32;

    this.labelGestationalNumber = new TTVisual.TTLabel();
    this.labelGestationalNumber.Text = "Gebelik Sayısı";
    this.labelGestationalNumber.Name = "labelGestationalNumber";
    this.labelGestationalNumber.TabIndex = 31;

    this.GestationalNumber = new TTVisual.TTTextBox();
    this.GestationalNumber.Name = "GestationalNumber";
    this.GestationalNumber.TabIndex = 30;

    this.labelFirstGestationalAge = new TTVisual.TTLabel();
    this.labelFirstGestationalAge.Text = "İlk Gebelik Yaşı";
    this.labelFirstGestationalAge.Name = "labelFirstGestationalAge";
    this.labelFirstGestationalAge.TabIndex = 29;

    this.FirstGestationalAge = new TTVisual.TTTextBox();
    this.FirstGestationalAge.Name = "FirstGestationalAge";
    this.FirstGestationalAge.TabIndex = 28;

    this.labelFirstMarriageAge = new TTVisual.TTLabel();
    this.labelFirstMarriageAge.Text = "İlk Evlilik Yaşı";
    this.labelFirstMarriageAge.Name = "labelFirstMarriageAge";
    this.labelFirstMarriageAge.TabIndex = 27;

    this.FirstMarriageAge = new TTVisual.TTTextBox();
    this.FirstMarriageAge.Name = "FirstMarriageAge";
    this.FirstMarriageAge.TabIndex = 26;

    this.labelLastMenstruationDate = new TTVisual.TTLabel();
    this.labelLastMenstruationDate.Text = "Son Adet Tarihi";
    this.labelLastMenstruationDate.Name = "labelLastMenstruationDate";
    this.labelLastMenstruationDate.TabIndex = 25;

    this.LastMenstruationDate = new TTVisual.TTDateTimePicker();
    this.LastMenstruationDate.Format = DateTimePickerFormat.Long;
    this.LastMenstruationDate.Name = "LastMenstruationDate";
    this.LastMenstruationDate.TabIndex = 24;

    this.labelMenopauseAge = new TTVisual.TTLabel();
    this.labelMenopauseAge.Text = "Menopoz Yaşı";
    this.labelMenopauseAge.Name = "labelMenopauseAge";
    this.labelMenopauseAge.TabIndex = 23;

    this.MenopauseAge = new TTVisual.TTTextBox();
    this.MenopauseAge.Name = "MenopauseAge";
    this.MenopauseAge.TabIndex = 22;

    this.labelMenarcheAge = new TTVisual.TTLabel();
    this.labelMenarcheAge.Text = "Menarş Yaşı";
    this.labelMenarcheAge.Name = "labelMenarcheAge";
    this.labelMenarcheAge.TabIndex = 21;

    this.MenarcheAge = new TTVisual.TTTextBox();
    this.MenarcheAge.Name = "MenarcheAge";
    this.MenarcheAge.TabIndex = 20;

    this.labelMenstrualCycle = new TTVisual.TTLabel();
    this.labelMenstrualCycle.Text = "Menstrüel Siklus";
    this.labelMenstrualCycle.Name = "labelMenstrualCycle";
    this.labelMenstrualCycle.TabIndex = 19;

    this.MenstrualCycle = new TTVisual.TTTextBox();
    this.MenstrualCycle.Name = "MenstrualCycle";
    this.MenstrualCycle.TabIndex = 18;

    this.labelMaritalStatusPerson = new TTVisual.TTLabel();
    this.labelMaritalStatusPerson.Text = "Medeni Durumu";
    this.labelMaritalStatusPerson.Name = "labelMaritalStatusPerson";
    this.labelMaritalStatusPerson.TabIndex = 17;

    this.EducationInfoGB.Controls = [this.labelOccupationPatient, this.OccupationPatient, this.labelEducationStatusPatient, this.EducationStatusPatient, this.labelInsuranceTypePatientAdmission, this.InsuranceTypePatientAdmission];
    this.ResultGB.Controls = [this.labelDescription, this.Description, this.SuspiciousAnomaly, this.InsufficientResult, this.Informed, this.AssessmentCompleted, this.Malignite, this.BiopsySuggestion, this.Mammography, this.PossibleBening, this.Bening, this.BreastExamination];
    this.CancerInfoGB.Controls = [this.tttextbox1, this.labelLactation, this.Lactation, this.MastectomyText, this.labelMastectomy, this.Mastectomy, this.labelPersonalBreastCA, this.PersonalBreastCA, this.labelFamilyBreastCA, this.FamilyBreastCA];
    this.AnamnesisGB.Controls = [this.labelSKRSAlkolKullanimiAnamnesisInfo, this.SKRSAlkolKullanimiAnamnesisInfo, this.labelSKRSMaddeKullanimiAnamnesisInfo, this.SKRSMaddeKullanimiAnamnesisInfo, this.labelSKRSSigaraKullanimiAnamnesisInfo, this.SKRSSigaraKullanimiAnamnesisInfo];
    this.TaramaBilgileriGB.Controls = [this.TTListBox, this.labelAilePlanlamasiAPYontemi, this.AilePlanlamasiAPYontemi, this.labelLiveBirthNumber, this.LiveBirthNumber, this.labelGestationalNumber, this.GestationalNumber, this.labelFirstGestationalAge, this.FirstGestationalAge, this.labelFirstMarriageAge, this.FirstMarriageAge, this.labelLastMenstruationDate, this.LastMenstruationDate, this.labelMenopauseAge, this.MenopauseAge, this.labelMenarcheAge, this.MenarcheAge, this.labelMenstrualCycle, this.MenstrualCycle, this.labelMaritalStatusPerson];
    this.Controls = [this.EducationInfoGB, this.labelOccupationPatient, this.OccupationPatient, this.labelEducationStatusPatient, this.EducationStatusPatient, this.labelInsuranceTypePatientAdmission, this.InsuranceTypePatientAdmission, this.ResultGB, this.labelDescription, this.Description, this.SuspiciousAnomaly, this.InsufficientResult, this.Informed, this.AssessmentCompleted, this.Malignite, this.BiopsySuggestion, this.Mammography, this.PossibleBening, this.Bening, this.BreastExamination, this.CancerInfoGB, this.tttextbox1, this.labelLactation, this.Lactation, this.MastectomyText, this.labelMastectomy, this.Mastectomy, this.labelPersonalBreastCA, this.PersonalBreastCA, this.labelFamilyBreastCA, this.FamilyBreastCA, this.AnamnesisGB, this.labelSKRSAlkolKullanimiAnamnesisInfo, this.SKRSAlkolKullanimiAnamnesisInfo, this.labelSKRSMaddeKullanimiAnamnesisInfo, this.SKRSMaddeKullanimiAnamnesisInfo, this.labelSKRSSigaraKullanimiAnamnesisInfo, this.SKRSSigaraKullanimiAnamnesisInfo, this.TaramaBilgileriGB, this.TTListBox, this.labelAilePlanlamasiAPYontemi, this.AilePlanlamasiAPYontemi, this.labelLiveBirthNumber, this.LiveBirthNumber, this.labelGestationalNumber, this.GestationalNumber, this.labelFirstGestationalAge, this.FirstGestationalAge, this.labelFirstMarriageAge, this.FirstMarriageAge, this.labelLastMenstruationDate, this.LastMenstruationDate, this.labelMenopauseAge, this.MenopauseAge, this.labelMenarcheAge, this.MenarcheAge, this.labelMenstrualCycle, this.MenstrualCycle, this.labelMaritalStatusPerson];

}
    printBreastScreeningForm() {
      
        let reportData: DynamicReportParameters = {

            Code: 'MEMETARAMAFORMU',
            ReportParams: { ObjectID: this._BreastScreening.ObjectID.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "MEME TARAMA FORMU"

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
