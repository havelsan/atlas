//$1A4F27FC
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { SmearScreeningFormViewModel } from './SmearScreeningFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { SmearScreening } from 'NebulaClient/Model/AtlasClientModel';
import { AnamnesisInfo } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAlkolKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKullanilanAilePlanlamasiAPYontemi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMaddeKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMedeniHali } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSSigaraKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSSigortaliTuru } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisode } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { DynamicReportParameters } from 'Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'Fw/Models/ParameterDefinitionModel';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';

@Component({
    selector: 'SmearScreeningForm',
    templateUrl: './SmearScreeningForm.html',
    providers: [MessageService]
})
export class SmearScreeningForm extends TTVisual.TTForm implements OnInit {
    AilePlanlamasiAPYontemi: TTVisual.ITTObjectListBox;
    BleedingAfterIntercourse: TTVisual.ITTEnumComboBox;
    Description: TTVisual.ITTTextBox;
    EducationStatusPatient: TTVisual.ITTObjectListBox;
    FamilyCancerHistory: TTVisual.ITTEnumComboBox;
    FamilyCancerHistoryDesc: TTVisual.ITTTextBox;
    FirstGestationalAge: TTVisual.ITTTextBox;
    FirstMarriageAge: TTVisual.ITTTextBox;
    GestationalNumber: TTVisual.ITTTextBox;
    GynecologicCancerHistory: TTVisual.ITTEnumComboBox;
    GynecologicCancerHistoryDesc: TTVisual.ITTTextBox;
    HPVResult: TTVisual.ITTEnumComboBox;
    InsuranceTypePatient: TTVisual.ITTObjectListBox;
    labelAilePlanlamasiAPYontemi: TTVisual.ITTLabel;
    labelBleedingAfterIntercourse: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelEducationStatusPatient: TTVisual.ITTLabel;
    labelFamilyCancerHistory: TTVisual.ITTLabel;
    labelFirstGestationalAge: TTVisual.ITTLabel;
    labelFirstMarriageAge: TTVisual.ITTLabel;
    labelGestationalNumber: TTVisual.ITTLabel;
    labelGynecologicCancerHistory: TTVisual.ITTLabel;
    labelHPVResult: TTVisual.ITTLabel;
    labelInsuranceTypePatient: TTVisual.ITTLabel;
    labelLastMenstruationDate: TTVisual.ITTLabel;
    labelLiveBirthNumber: TTVisual.ITTLabel;
    labelMaritalStatusPerson: TTVisual.ITTLabel;
    labelMenarcheAge: TTVisual.ITTLabel;
    labelMenopauseAge: TTVisual.ITTLabel;
    labelMenstrualCycle: TTVisual.ITTLabel;
    labelOccupationPatient: TTVisual.ITTLabel;
    labelPainDuringIntercourse: TTVisual.ITTLabel;
    labelPersonalCancerHistory: TTVisual.ITTLabel;
    labelSKRSAlkolKullanimiAnamnesisInfo: TTVisual.ITTLabel;
    labelSKRSMaddeKullanimiAnamnesisInfo: TTVisual.ITTLabel;
    labelSKRSSigaraKullanimiAnamnesisInfo: TTVisual.ITTLabel;
    labelSmearResult: TTVisual.ITTLabel;
    LastMenstruationDate: TTVisual.ITTDateTimePicker;
    LiveBirthNumber: TTVisual.ITTTextBox;
    MenarcheAge: TTVisual.ITTTextBox;
    MenopauseAge: TTVisual.ITTTextBox;
    MenstrualCycle: TTVisual.ITTTextBox;
    OccupationPatient: TTVisual.ITTObjectListBox;
    PainDuringIntercourse: TTVisual.ITTEnumComboBox;
    PainDuringIntercourseText: TTVisual.ITTTextBox;
    PersonalCancerHistory: TTVisual.ITTEnumComboBox;
    PersonalCancerHistoryDesc: TTVisual.ITTTextBox;
    SKRSAlkolKullanimiAnamnesisInfo: TTVisual.ITTObjectListBox;
    SKRSMaddeKullanimiAnamnesisInfo: TTVisual.ITTObjectListBox;
    SKRSMaritalStatus: TTVisual.ITTObjectListBox;
    SKRSSigaraKullanimiAnamnesisInfo: TTVisual.ITTObjectListBox;
    SmearAnamnezGB: TTVisual.ITTGroupBox;
    SmearCancerGB: TTVisual.ITTGroupBox;
    SmearEducationGB: TTVisual.ITTGroupBox;
    SmearResult: TTVisual.ITTEnumComboBox;
    SmearResultGB: TTVisual.ITTGroupBox;
    SmearScreeningGB: TTVisual.ITTGroupBox;
    public statesPanelClass: string = "col-lg-6";
    public _buttonCaption: string = "Yazdır";
    public _buttonIcon: string = "fa fa-print";
    public smearScreeningFormViewModel: SmearScreeningFormViewModel = new SmearScreeningFormViewModel();
    public get _SmearScreening(): SmearScreening {
        return this._TTObject as SmearScreening;
    }
    private SmearScreeningForm_DocumentUrl: string = '/api/SmearScreeningService/SmearScreeningForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalService: IModalService) {
        super('SMEARSCREENING', 'SmearScreeningForm');
        this._DocumentServiceUrl = this.SmearScreeningForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SmearScreening();
        this.smearScreeningFormViewModel = new SmearScreeningFormViewModel();
        this._ViewModel = this.smearScreeningFormViewModel;
        this.smearScreeningFormViewModel._SmearScreening = this._TTObject as SmearScreening;
        this.smearScreeningFormViewModel._SmearScreening.AnamnesisInfo = new AnamnesisInfo();
        this.smearScreeningFormViewModel._SmearScreening.AnamnesisInfo.SKRSAlkolKullanimi = new SKRSAlkolKullanimi();
        this.smearScreeningFormViewModel._SmearScreening.AnamnesisInfo.SKRSMaddeKullanimi = new SKRSMaddeKullanimi();
        this.smearScreeningFormViewModel._SmearScreening.AnamnesisInfo.SKRSSigaraKullanimi = new SKRSSigaraKullanimi();
        this.smearScreeningFormViewModel._SmearScreening.SubEpisode = new SubEpisode();
        this.smearScreeningFormViewModel._SmearScreening.SubEpisode.Episode = new Episode();
        this.smearScreeningFormViewModel._SmearScreening.SubEpisode.Episode.Patient = new Patient();
        this.smearScreeningFormViewModel._SmearScreening.SubEpisode.Episode.Patient.Occupation = new SKRSMeslekler();
        this.smearScreeningFormViewModel._SmearScreening.SubEpisode.Episode.Patient.EducationStatus = new SKRSOgrenimDurumu();
        this.smearScreeningFormViewModel._SmearScreening.SubEpisode.Episode.Patient.InsuranceType = new SKRSSigortaliTuru();
        this.smearScreeningFormViewModel._SmearScreening.SubEpisode.Episode.Patient.SKRSMaritalStatus = new SKRSMedeniHali();
        this.smearScreeningFormViewModel._SmearScreening.AilePlanlamasiAPYontemi = new SKRSKullanilanAilePlanlamasiAPYontemi();
    }

    protected loadViewModel() {
        let that = this;
        that.smearScreeningFormViewModel = this._ViewModel as SmearScreeningFormViewModel;
        that._TTObject = this.smearScreeningFormViewModel._SmearScreening;
        if (this.smearScreeningFormViewModel == null)
            this.smearScreeningFormViewModel = new SmearScreeningFormViewModel();
        if (this.smearScreeningFormViewModel._SmearScreening == null)
            this.smearScreeningFormViewModel._SmearScreening = new SmearScreening();
        let anamnesisInfoObjectID = that.smearScreeningFormViewModel._SmearScreening["AnamnesisInfo"];
        if (anamnesisInfoObjectID != null && (typeof anamnesisInfoObjectID === "string")) {
            let anamnesisInfo = that.smearScreeningFormViewModel.AnamnesisInfos.find(o => o.ObjectID.toString() === anamnesisInfoObjectID.toString());
            if (anamnesisInfo) {
                that.smearScreeningFormViewModel._SmearScreening.AnamnesisInfo = anamnesisInfo;
            }
            if (anamnesisInfo != null) {
                let sKRSAlkolKullanimiObjectID = anamnesisInfo["SKRSAlkolKullanimi"];
                if (sKRSAlkolKullanimiObjectID != null && (typeof sKRSAlkolKullanimiObjectID === "string")) {
                    let sKRSAlkolKullanimi = that.smearScreeningFormViewModel.SKRSAlkolKullanimis.find(o => o.ObjectID.toString() === sKRSAlkolKullanimiObjectID.toString());
                    if (sKRSAlkolKullanimi) {
                        anamnesisInfo.SKRSAlkolKullanimi = sKRSAlkolKullanimi;
                    }
                }
                let sKRSMaddeKullanimiObjectID = anamnesisInfo["SKRSMaddeKullanimi"];
                if (sKRSMaddeKullanimiObjectID != null && (typeof sKRSMaddeKullanimiObjectID === "string")) {
                    let sKRSMaddeKullanimi = that.smearScreeningFormViewModel.SKRSMaddeKullanimis.find(o => o.ObjectID.toString() === sKRSMaddeKullanimiObjectID.toString());
                    if (sKRSMaddeKullanimi) {
                        anamnesisInfo.SKRSMaddeKullanimi = sKRSMaddeKullanimi;
                    }
                }
                let sKRSSigaraKullanimiObjectID = anamnesisInfo["SKRSSigaraKullanimi"];
                if (sKRSSigaraKullanimiObjectID != null && (typeof sKRSSigaraKullanimiObjectID === "string")) {
                    let sKRSSigaraKullanimi = that.smearScreeningFormViewModel.SKRSSigaraKullanimis.find(o => o.ObjectID.toString() === sKRSSigaraKullanimiObjectID.toString());
                    if (sKRSSigaraKullanimi) {
                        anamnesisInfo.SKRSSigaraKullanimi = sKRSSigaraKullanimi;
                    }
                }

            }
        }

        let subEpisodeObjectID = that.smearScreeningFormViewModel._SmearScreening["SubEpisode"];
        if (subEpisodeObjectID != null && (typeof subEpisodeObjectID === "string")) {
            let subEpisode = that.smearScreeningFormViewModel.SubEpisodes.find(o => o.ObjectID.toString() === subEpisodeObjectID.toString());
            if (subEpisode) {
                that.smearScreeningFormViewModel._SmearScreening.SubEpisode = subEpisode;
            }

            if (subEpisode != null) {
                let episodeObjectID = subEpisode["Episode"];
                if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
                    let episode = that.smearScreeningFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
                    if (episode) {
                        subEpisode.Episode = episode;
                    }


                    if (episode != null) {
                        let patientObjectID = episode["Patient"];
                        if (patientObjectID != null && (typeof patientObjectID === "string")) {
                            let patient = that.smearScreeningFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                            if (patient) {
                                episode.Patient = patient;
                            }

                            if (patient != null) {
                                let occupationObjectID = patient["Occupation"];
                                if (occupationObjectID != null && (typeof occupationObjectID === "string")) {
                                    let occupation = that.smearScreeningFormViewModel.SKRSMesleklers.find(o => o.ObjectID.toString() === occupationObjectID.toString());
                                    if (occupation) {
                                        patient.Occupation = occupation;
                                    }
                                }

                                let educationStatusObjectID = patient["EducationStatus"];
                                if (educationStatusObjectID != null && (typeof educationStatusObjectID === "string")) {
                                    let educationStatus = that.smearScreeningFormViewModel.SKRSOgrenimDurumus.find(o => o.ObjectID.toString() === educationStatusObjectID.toString());
                                    if (educationStatus) {
                                        patient.EducationStatus = educationStatus;
                                    }
                                }

                                let insuranceTypeObjectID = patient["InsuranceType"];
                                if (insuranceTypeObjectID != null && (typeof insuranceTypeObjectID === "string")) {
                                    let insuranceType = that.smearScreeningFormViewModel.SKRSSigortaliTurus.find(o => o.ObjectID.toString() === insuranceTypeObjectID.toString());
                                    if (insuranceType) {
                                        patient.InsuranceType = insuranceType;
                                    }
                                }

                                let sKRSMaritalStatusObjectID = patient["SKRSMaritalStatus"];
                                if (sKRSMaritalStatusObjectID != null && (typeof sKRSMaritalStatusObjectID === "string")) {
                                    let sKRSMaritalStatus = that.smearScreeningFormViewModel.SKRSMedeniHalis.find(o => o.ObjectID.toString() === sKRSMaritalStatusObjectID.toString());
                                    if (sKRSMaritalStatus) {
                                        patient.SKRSMaritalStatus = sKRSMaritalStatus;
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }

        let ailePlanlamasiAPYontemiObjectID = that.smearScreeningFormViewModel._SmearScreening["AilePlanlamasiAPYontemi"];
        if (ailePlanlamasiAPYontemiObjectID != null && (typeof ailePlanlamasiAPYontemiObjectID === "string")) {
            let ailePlanlamasiAPYontemi = that.smearScreeningFormViewModel.SKRSKullanilanAilePlanlamasiAPYontemis.find(o => o.ObjectID.toString() === ailePlanlamasiAPYontemiObjectID.toString());
            if (ailePlanlamasiAPYontemi) {
                that.smearScreeningFormViewModel._SmearScreening.AilePlanlamasiAPYontemi = ailePlanlamasiAPYontemi;
            }
        }
     
    }
  
async ngOnInit() {
    await this.load();
}

public onAilePlanlamasiAPYontemiChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.AilePlanlamasiAPYontemi != event) { 
    this._SmearScreening.AilePlanlamasiAPYontemi = event;
}
}

public onBleedingAfterIntercourseChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.BleedingAfterIntercourse != event) { 
    this._SmearScreening.BleedingAfterIntercourse = event;
}
}

public onDescriptionChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.Description != event) { 
    this._SmearScreening.Description = event;
}
}

public onEducationStatusPatientChanged(event): void {
    if(this._SmearScreening != null &&
    this._SmearScreening.SubEpisode != null &&
    this._SmearScreening.SubEpisode.Episode != null &&
    this._SmearScreening.SubEpisode.Episode.Patient != null && this._SmearScreening.SubEpisode.Episode.Patient.EducationStatus != event) { 
    this._SmearScreening.SubEpisode.Episode.Patient.EducationStatus = event;
}
}

public onFamilyCancerHistoryChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.FamilyCancerHistory != event) { 
    this._SmearScreening.FamilyCancerHistory = event;
}
}

public onFamilyCancerHistoryDescChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.FamilyCancerHistoryDesc != event) { 
    this._SmearScreening.FamilyCancerHistoryDesc = event;
}
}

public onFirstGestationalAgeChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.FirstGestationalAge != event) { 
    this._SmearScreening.FirstGestationalAge = event;
}
}

public onFirstMarriageAgeChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.FirstMarriageAge != event) { 
    this._SmearScreening.FirstMarriageAge = event;
}
}

public onGestationalNumberChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.GestationalNumber != event) { 
    this._SmearScreening.GestationalNumber = event;
}
}

public onGynecologicCancerHistoryChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.GynecologicCancerHistory != event) { 
    this._SmearScreening.GynecologicCancerHistory = event;
}
}

public onGynecologicCancerHistoryDescChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.GynecologicCancerHistoryDesc != event) { 
    this._SmearScreening.GynecologicCancerHistoryDesc = event;
}
}

public onHPVResultChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.HPVResult != event) { 
    this._SmearScreening.HPVResult = event;
}
}

public onInsuranceTypePatientChanged(event): void {
    if(this._SmearScreening != null &&
    this._SmearScreening.SubEpisode != null &&
    this._SmearScreening.SubEpisode.Episode != null &&
    this._SmearScreening.SubEpisode.Episode.Patient != null && this._SmearScreening.SubEpisode.Episode.Patient.InsuranceType != event) { 
    this._SmearScreening.SubEpisode.Episode.Patient.InsuranceType = event;
}
}

public onLastMenstruationDateChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.LastMenstruationDate != event) { 
    this._SmearScreening.LastMenstruationDate = event;
}
}

public onLiveBirthNumberChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.LiveBirthNumber != event) { 
    this._SmearScreening.LiveBirthNumber = event;
}
}

public onMenarcheAgeChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.MenarcheAge != event) { 
    this._SmearScreening.MenarcheAge = event;
}
}

public onMenopauseAgeChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.MenopauseAge != event) { 
    this._SmearScreening.MenopauseAge = event;
}
}

public onMenstrualCycleChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.MenstrualCycle != event) { 
    this._SmearScreening.MenstrualCycle = event;
}
}

public onOccupationPatientChanged(event): void {
    if(this._SmearScreening != null &&
    this._SmearScreening.SubEpisode != null &&
    this._SmearScreening.SubEpisode.Episode != null &&
    this._SmearScreening.SubEpisode.Episode.Patient != null && this._SmearScreening.SubEpisode.Episode.Patient.Occupation != event) { 
    this._SmearScreening.SubEpisode.Episode.Patient.Occupation = event;
}
}

public onPainDuringIntercourseChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.PainDuringIntercourse != event) { 
    this._SmearScreening.PainDuringIntercourse = event;
}
}

public onPainDuringIntercourseTextChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.PainDuringIntercourseText != event) { 
    this._SmearScreening.PainDuringIntercourseText = event;
}
}

public onPersonalCancerHistoryChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.PersonalCancerHistory != event) { 
    this._SmearScreening.PersonalCancerHistory = event;
}
}

public onPersonalCancerHistoryDescChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.PersonalCancerHistoryDesc != event) { 
    this._SmearScreening.PersonalCancerHistoryDesc = event;
}
}

public onSKRSAlkolKullanimiAnamnesisInfoChanged(event): void {
    if(this._SmearScreening != null &&
    this._SmearScreening.AnamnesisInfo != null && this._SmearScreening.AnamnesisInfo.SKRSAlkolKullanimi != event) { 
    this._SmearScreening.AnamnesisInfo.SKRSAlkolKullanimi = event;
}
}

public onSKRSMaddeKullanimiAnamnesisInfoChanged(event): void {
    if(this._SmearScreening != null &&
    this._SmearScreening.AnamnesisInfo != null && this._SmearScreening.AnamnesisInfo.SKRSMaddeKullanimi != event) { 
    this._SmearScreening.AnamnesisInfo.SKRSMaddeKullanimi = event;
}
}

public onSKRSMaritalStatusChanged(event): void {
    if(this._SmearScreening != null &&
    this._SmearScreening.SubEpisode != null &&
    this._SmearScreening.SubEpisode.Episode != null &&
    this._SmearScreening.SubEpisode.Episode.Patient != null && this._SmearScreening.SubEpisode.Episode.Patient.SKRSMaritalStatus != event) { 
    this._SmearScreening.SubEpisode.Episode.Patient.SKRSMaritalStatus = event;
}
}

public onSKRSSigaraKullanimiAnamnesisInfoChanged(event): void {
    if(this._SmearScreening != null &&
    this._SmearScreening.AnamnesisInfo != null && this._SmearScreening.AnamnesisInfo.SKRSSigaraKullanimi != event) { 
    this._SmearScreening.AnamnesisInfo.SKRSSigaraKullanimi = event;
}
}

public onSmearResultChanged(event): void {
    if(this._SmearScreening != null && this._SmearScreening.SmearResult != event) { 
    this._SmearScreening.SmearResult = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.MenstrualCycle, "Text", this.__ttObject, "MenstrualCycle");
    redirectProperty(this.FirstMarriageAge, "Text", this.__ttObject, "FirstMarriageAge");
    redirectProperty(this.PainDuringIntercourse, "Value", this.__ttObject, "PainDuringIntercourse");
    redirectProperty(this.PainDuringIntercourseText, "Text", this.__ttObject, "PainDuringIntercourseText");
    redirectProperty(this.MenarcheAge, "Text", this.__ttObject, "MenarcheAge");
    redirectProperty(this.FirstGestationalAge, "Text", this.__ttObject, "FirstGestationalAge");
    redirectProperty(this.LiveBirthNumber, "Text", this.__ttObject, "LiveBirthNumber");
    redirectProperty(this.BleedingAfterIntercourse, "Value", this.__ttObject, "BleedingAfterIntercourse");
    redirectProperty(this.MenopauseAge, "Text", this.__ttObject, "MenopauseAge");
    redirectProperty(this.GestationalNumber, "Text", this.__ttObject, "GestationalNumber");
    redirectProperty(this.LastMenstruationDate, "Value", this.__ttObject, "LastMenstruationDate");
    redirectProperty(this.FamilyCancerHistory, "Value", this.__ttObject, "FamilyCancerHistory");
    redirectProperty(this.FamilyCancerHistoryDesc, "Text", this.__ttObject, "FamilyCancerHistoryDesc");
    redirectProperty(this.PersonalCancerHistory, "Value", this.__ttObject, "PersonalCancerHistory");
    redirectProperty(this.PersonalCancerHistoryDesc, "Text", this.__ttObject, "PersonalCancerHistoryDesc");
    redirectProperty(this.GynecologicCancerHistory, "Value", this.__ttObject, "GynecologicCancerHistory");
    redirectProperty(this.GynecologicCancerHistoryDesc, "Text", this.__ttObject, "GynecologicCancerHistoryDesc");
    redirectProperty(this.SmearResult, "Value", this.__ttObject, "SmearResult");
    redirectProperty(this.HPVResult, "Value", this.__ttObject, "HPVResult");
    redirectProperty(this.Description, "Text", this.__ttObject, "Description");
}

public initFormControls() : void {
    this.SmearResultGB = new TTVisual.TTGroupBox();
    this.SmearResultGB.Text = "Sonuç Bilgileri";
    this.SmearResultGB.Name = "SmearResultGB";
    this.SmearResultGB.TabIndex = 4;

    this.labelDescription = new TTVisual.TTLabel();
    this.labelDescription.Text = "Açıklama";
    this.labelDescription.Name = "labelDescription";
    this.labelDescription.TabIndex = 5;

    this.Description = new TTVisual.TTTextBox();
    this.Description.Multiline = true;
    this.Description.Name = "Description";
    this.Description.TabIndex = 4;

    this.labelHPVResult = new TTVisual.TTLabel();
    this.labelHPVResult.Text = "HPV";
    this.labelHPVResult.Name = "labelHPVResult";
    this.labelHPVResult.TabIndex = 3;

    this.HPVResult = new TTVisual.TTEnumComboBox();
    this.HPVResult.DataTypeName = "HPVEnum";
    this.HPVResult.Name = "HPVResult";
    this.HPVResult.TabIndex = 2;

    this.labelSmearResult = new TTVisual.TTLabel();
    this.labelSmearResult.Text = "Sonuç";
    this.labelSmearResult.Name = "labelSmearResult";
    this.labelSmearResult.TabIndex = 1;

    this.SmearResult = new TTVisual.TTEnumComboBox();
    this.SmearResult.DataTypeName = "SmearResultEnum";
    this.SmearResult.Name = "SmearResult";
    this.SmearResult.TabIndex = 0;

    this.SmearCancerGB = new TTVisual.TTGroupBox();
    this.SmearCancerGB.Text = "Kanser Öykü Bilgileri";
    this.SmearCancerGB.Name = "SmearCancerGB";
    this.SmearCancerGB.TabIndex = 3;

    this.GynecologicCancerHistoryDesc = new TTVisual.TTTextBox();
    this.GynecologicCancerHistoryDesc.Name = "GynecologicCancerHistoryDesc";
    this.GynecologicCancerHistoryDesc.TabIndex = 10;

    this.PersonalCancerHistoryDesc = new TTVisual.TTTextBox();
    this.PersonalCancerHistoryDesc.Name = "PersonalCancerHistoryDesc";
    this.PersonalCancerHistoryDesc.TabIndex = 8;

    this.FamilyCancerHistoryDesc = new TTVisual.TTTextBox();
    this.FamilyCancerHistoryDesc.Name = "FamilyCancerHistoryDesc";
    this.FamilyCancerHistoryDesc.TabIndex = 6;

    this.labelGynecologicCancerHistory = new TTVisual.TTLabel();
    this.labelGynecologicCancerHistory.Text = "Jinekolojik Kanser Öyküsü";
    this.labelGynecologicCancerHistory.Name = "labelGynecologicCancerHistory";
    this.labelGynecologicCancerHistory.TabIndex = 5;

    this.GynecologicCancerHistory = new TTVisual.TTEnumComboBox();
    this.GynecologicCancerHistory.DataTypeName = "VarYokGarantiEnum";
    this.GynecologicCancerHistory.Name = "GynecologicCancerHistory";
    this.GynecologicCancerHistory.TabIndex = 4;

    this.labelPersonalCancerHistory = new TTVisual.TTLabel();
    this.labelPersonalCancerHistory.Text = "Kişisel Kanser Öyküsü";
    this.labelPersonalCancerHistory.Name = "labelPersonalCancerHistory";
    this.labelPersonalCancerHistory.TabIndex = 3;

    this.PersonalCancerHistory = new TTVisual.TTEnumComboBox();
    this.PersonalCancerHistory.DataTypeName = "VarYokGarantiEnum";
    this.PersonalCancerHistory.Name = "PersonalCancerHistory";
    this.PersonalCancerHistory.TabIndex = 2;

    this.labelFamilyCancerHistory = new TTVisual.TTLabel();
    this.labelFamilyCancerHistory.Text = "Ailede Kanser Öyküsü";
    this.labelFamilyCancerHistory.Name = "labelFamilyCancerHistory";
    this.labelFamilyCancerHistory.TabIndex = 1;

    this.FamilyCancerHistory = new TTVisual.TTEnumComboBox();
    this.FamilyCancerHistory.DataTypeName = "VarYokGarantiEnum";
    this.FamilyCancerHistory.Name = "FamilyCancerHistory";
    this.FamilyCancerHistory.TabIndex = 0;

    this.SmearAnamnezGB = new TTVisual.TTGroupBox();
    this.SmearAnamnezGB.Text = "Anamnez Bilgileri";
    this.SmearAnamnezGB.Name = "SmearAnamnezGB";
    this.SmearAnamnezGB.TabIndex = 2;

    this.labelSKRSAlkolKullanimiAnamnesisInfo = new TTVisual.TTLabel();
    this.labelSKRSAlkolKullanimiAnamnesisInfo.Text = "Alkol Kullanımı";
    this.labelSKRSAlkolKullanimiAnamnesisInfo.Name = "labelSKRSAlkolKullanimiAnamnesisInfo";
    this.labelSKRSAlkolKullanimiAnamnesisInfo.TabIndex = 7;

    this.SKRSAlkolKullanimiAnamnesisInfo = new TTVisual.TTObjectListBox();
    this.SKRSAlkolKullanimiAnamnesisInfo.ListDefName = "SKRSAlkolKullanimiList";
    this.SKRSAlkolKullanimiAnamnesisInfo.Name = "SKRSAlkolKullanimiAnamnesisInfo";
    this.SKRSAlkolKullanimiAnamnesisInfo.TabIndex = 6;

    this.labelSKRSMaddeKullanimiAnamnesisInfo = new TTVisual.TTLabel();
    this.labelSKRSMaddeKullanimiAnamnesisInfo.Text = "Madde Kullanımı";
    this.labelSKRSMaddeKullanimiAnamnesisInfo.Name = "labelSKRSMaddeKullanimiAnamnesisInfo";
    this.labelSKRSMaddeKullanimiAnamnesisInfo.TabIndex = 5;

    this.SKRSMaddeKullanimiAnamnesisInfo = new TTVisual.TTObjectListBox();
    this.SKRSMaddeKullanimiAnamnesisInfo.ListDefName = "SKRSMaddeKullanimiList";
    this.SKRSMaddeKullanimiAnamnesisInfo.Name = "SKRSMaddeKullanimiAnamnesisInfo";
    this.SKRSMaddeKullanimiAnamnesisInfo.TabIndex = 4;

    this.labelSKRSSigaraKullanimiAnamnesisInfo = new TTVisual.TTLabel();
    this.labelSKRSSigaraKullanimiAnamnesisInfo.Text = "Sigara Kullanımı";
    this.labelSKRSSigaraKullanimiAnamnesisInfo.Name = "labelSKRSSigaraKullanimiAnamnesisInfo";
    this.labelSKRSSigaraKullanimiAnamnesisInfo.TabIndex = 3;

    this.SKRSSigaraKullanimiAnamnesisInfo = new TTVisual.TTObjectListBox();
    this.SKRSSigaraKullanimiAnamnesisInfo.ListDefName = "SKRSSigaraKullanimiList";
    this.SKRSSigaraKullanimiAnamnesisInfo.Name = "SKRSSigaraKullanimiAnamnesisInfo";
    this.SKRSSigaraKullanimiAnamnesisInfo.TabIndex = 2;

    this.SmearEducationGB = new TTVisual.TTGroupBox();
    this.SmearEducationGB.Text = "Öğrenim ve İş Bilgileri";
    this.SmearEducationGB.Name = "SmearEducationGB";
    this.SmearEducationGB.TabIndex = 1;

    this.labelOccupationPatient = new TTVisual.TTLabel();
    this.labelOccupationPatient.Text = "Mesleği";
    this.labelOccupationPatient.Name = "labelOccupationPatient";
    this.labelOccupationPatient.TabIndex = 5;

    this.OccupationPatient = new TTVisual.TTObjectListBox();
    this.OccupationPatient.ListDefName = "SKRSMesleklerList";
    this.OccupationPatient.Name = "OccupationPatient";
    this.OccupationPatient.TabIndex = 4;

    this.labelEducationStatusPatient = new TTVisual.TTLabel();
    this.labelEducationStatusPatient.Text = "Öğrenim Durumu";
    this.labelEducationStatusPatient.Name = "labelEducationStatusPatient";
    this.labelEducationStatusPatient.TabIndex = 3;

    this.EducationStatusPatient = new TTVisual.TTObjectListBox();
    this.EducationStatusPatient.ListDefName = "SKRSOgrenimDurumuList";
    this.EducationStatusPatient.Name = "EducationStatusPatient";
    this.EducationStatusPatient.TabIndex = 2;

    this.labelInsuranceTypePatient = new TTVisual.TTLabel();
    this.labelInsuranceTypePatient.Text = "İş Durumu";
    this.labelInsuranceTypePatient.Name = "labelInsuranceTypePatient";
    this.labelInsuranceTypePatient.TabIndex = 1;

    this.InsuranceTypePatient = new TTVisual.TTObjectListBox();
    this.InsuranceTypePatient.ListDefName = "SKRSSigortaliTuruList";
    this.InsuranceTypePatient.Name = "InsuranceTypePatient";
    this.InsuranceTypePatient.TabIndex = 0;

    this.SmearScreeningGB = new TTVisual.TTGroupBox();
    this.SmearScreeningGB.Text = "Tarama Bilgileri";
    this.SmearScreeningGB.Name = "SmearScreeningGB";
    this.SmearScreeningGB.TabIndex = 0;

    this.SKRSMaritalStatus = new TTVisual.TTObjectListBox();
    this.SKRSMaritalStatus.ListDefName = "";
    this.SKRSMaritalStatus.Name = "SKRSMaritalStatus";
    this.SKRSMaritalStatus.TabIndex = 42;

    this.labelAilePlanlamasiAPYontemi = new TTVisual.TTLabel();
    this.labelAilePlanlamasiAPYontemi.Text = "Aile Planlaması Yöntemi";
    this.labelAilePlanlamasiAPYontemi.Name = "labelAilePlanlamasiAPYontemi";
    this.labelAilePlanlamasiAPYontemi.TabIndex = 41;

    this.AilePlanlamasiAPYontemi = new TTVisual.TTObjectListBox();
    this.AilePlanlamasiAPYontemi.ListDefName = "SKRSKullanilanAilePlanlamasiAPYontemiList";
    this.AilePlanlamasiAPYontemi.Name = "AilePlanlamasiAPYontemi";
    this.AilePlanlamasiAPYontemi.TabIndex = 40;

    this.labelMenstrualCycle = new TTVisual.TTLabel();
    this.labelMenstrualCycle.Text = "Menstrüel Siklus";
    this.labelMenstrualCycle.Name = "labelMenstrualCycle";
    this.labelMenstrualCycle.TabIndex = 39;

    this.MenstrualCycle = new TTVisual.TTTextBox();
    this.MenstrualCycle.Name = "MenstrualCycle";
    this.MenstrualCycle.TabIndex = 38;

    this.labelMenopauseAge = new TTVisual.TTLabel();
    this.labelMenopauseAge.Text = "Menopoz Yaşı";
    this.labelMenopauseAge.Name = "labelMenopauseAge";
    this.labelMenopauseAge.TabIndex = 37;

    this.MenopauseAge = new TTVisual.TTTextBox();
    this.MenopauseAge.Name = "MenopauseAge";
    this.MenopauseAge.TabIndex = 36;

    this.labelMenarcheAge = new TTVisual.TTLabel();
    this.labelMenarcheAge.Text = "Menarş Yaşı";
    this.labelMenarcheAge.Name = "labelMenarcheAge";
    this.labelMenarcheAge.TabIndex = 35;

    this.MenarcheAge = new TTVisual.TTTextBox();
    this.MenarcheAge.Name = "MenarcheAge";
    this.MenarcheAge.TabIndex = 34;

    this.labelLiveBirthNumber = new TTVisual.TTLabel();
    this.labelLiveBirthNumber.Text = "Canlı Doğum Sayısı";
    this.labelLiveBirthNumber.Name = "labelLiveBirthNumber";
    this.labelLiveBirthNumber.TabIndex = 33;

    this.LiveBirthNumber = new TTVisual.TTTextBox();
    this.LiveBirthNumber.Name = "LiveBirthNumber";
    this.LiveBirthNumber.TabIndex = 32;

    this.labelLastMenstruationDate = new TTVisual.TTLabel();
    this.labelLastMenstruationDate.Text = "Son Adet Tarihi";
    this.labelLastMenstruationDate.Name = "labelLastMenstruationDate";
    this.labelLastMenstruationDate.TabIndex = 31;

    this.LastMenstruationDate = new TTVisual.TTDateTimePicker();
    this.LastMenstruationDate.Format = DateTimePickerFormat.Long;
    this.LastMenstruationDate.Name = "LastMenstruationDate";
    this.LastMenstruationDate.TabIndex = 30;

    this.labelGestationalNumber = new TTVisual.TTLabel();
    this.labelGestationalNumber.Text = "Gebelik Sayısı";
    this.labelGestationalNumber.Name = "labelGestationalNumber";
    this.labelGestationalNumber.TabIndex = 29;

    this.GestationalNumber = new TTVisual.TTTextBox();
    this.GestationalNumber.Name = "GestationalNumber";
    this.GestationalNumber.TabIndex = 28;

    this.labelFirstMarriageAge = new TTVisual.TTLabel();
    this.labelFirstMarriageAge.Text = "İlk Evlilik Yaşı";
    this.labelFirstMarriageAge.Name = "labelFirstMarriageAge";
    this.labelFirstMarriageAge.TabIndex = 27;

    this.FirstMarriageAge = new TTVisual.TTTextBox();
    this.FirstMarriageAge.Name = "FirstMarriageAge";
    this.FirstMarriageAge.TabIndex = 26;

    this.labelFirstGestationalAge = new TTVisual.TTLabel();
    this.labelFirstGestationalAge.Text = "İlk Gebelik Yaşı";
    this.labelFirstGestationalAge.Name = "labelFirstGestationalAge";
    this.labelFirstGestationalAge.TabIndex = 25;

    this.FirstGestationalAge = new TTVisual.TTTextBox();
    this.FirstGestationalAge.Name = "FirstGestationalAge";
    this.FirstGestationalAge.TabIndex = 24;

    this.labelMaritalStatusPerson = new TTVisual.TTLabel();
    this.labelMaritalStatusPerson.Text = "Medeni Durumu";
    this.labelMaritalStatusPerson.Name = "labelMaritalStatusPerson";
    this.labelMaritalStatusPerson.TabIndex = 23;

    this.PainDuringIntercourseText = new TTVisual.TTTextBox();
    this.PainDuringIntercourseText.Name = "PainDuringIntercourseText";
    this.PainDuringIntercourseText.TabIndex = 4;

    this.labelBleedingAfterIntercourse = new TTVisual.TTLabel();
    this.labelBleedingAfterIntercourse.Text = "Cinsel İlişki Sonrası Kanama";
    this.labelBleedingAfterIntercourse.Name = "labelBleedingAfterIntercourse";
    this.labelBleedingAfterIntercourse.TabIndex = 3;

    this.BleedingAfterIntercourse = new TTVisual.TTEnumComboBox();
    this.BleedingAfterIntercourse.DataTypeName = "VarYokGarantiEnum";
    this.BleedingAfterIntercourse.Name = "BleedingAfterIntercourse";
    this.BleedingAfterIntercourse.TabIndex = 2;

    this.labelPainDuringIntercourse = new TTVisual.TTLabel();
    this.labelPainDuringIntercourse.Text = "Cinsel İlişkide Ağrı";
    this.labelPainDuringIntercourse.Name = "labelPainDuringIntercourse";
    this.labelPainDuringIntercourse.TabIndex = 1;

    this.PainDuringIntercourse = new TTVisual.TTEnumComboBox();
    this.PainDuringIntercourse.DataTypeName = "VarYokGarantiEnum";
    this.PainDuringIntercourse.Name = "PainDuringIntercourse";
    this.PainDuringIntercourse.TabIndex = 0;

    this.SmearResultGB.Controls = [this.labelDescription, this.Description, this.labelHPVResult, this.HPVResult, this.labelSmearResult, this.SmearResult];
    this.SmearCancerGB.Controls = [this.GynecologicCancerHistoryDesc, this.PersonalCancerHistoryDesc, this.FamilyCancerHistoryDesc, this.labelGynecologicCancerHistory, this.GynecologicCancerHistory, this.labelPersonalCancerHistory, this.PersonalCancerHistory, this.labelFamilyCancerHistory, this.FamilyCancerHistory];
    this.SmearAnamnezGB.Controls = [this.labelSKRSAlkolKullanimiAnamnesisInfo, this.SKRSAlkolKullanimiAnamnesisInfo, this.labelSKRSMaddeKullanimiAnamnesisInfo, this.SKRSMaddeKullanimiAnamnesisInfo, this.labelSKRSSigaraKullanimiAnamnesisInfo, this.SKRSSigaraKullanimiAnamnesisInfo];
    this.SmearEducationGB.Controls = [this.labelOccupationPatient, this.OccupationPatient, this.labelEducationStatusPatient, this.EducationStatusPatient, this.labelInsuranceTypePatient, this.InsuranceTypePatient];
    this.SmearScreeningGB.Controls = [this.SKRSMaritalStatus, this.labelAilePlanlamasiAPYontemi, this.AilePlanlamasiAPYontemi, this.labelMenstrualCycle, this.MenstrualCycle, this.labelMenopauseAge, this.MenopauseAge, this.labelMenarcheAge, this.MenarcheAge, this.labelLiveBirthNumber, this.LiveBirthNumber, this.labelLastMenstruationDate, this.LastMenstruationDate, this.labelGestationalNumber, this.GestationalNumber, this.labelFirstMarriageAge, this.FirstMarriageAge, this.labelFirstGestationalAge, this.FirstGestationalAge, this.labelMaritalStatusPerson, this.PainDuringIntercourseText, this.labelBleedingAfterIntercourse, this.BleedingAfterIntercourse, this.labelPainDuringIntercourse, this.PainDuringIntercourse];
    this.Controls = [this.SmearResultGB, this.labelDescription, this.Description, this.labelHPVResult, this.HPVResult, this.labelSmearResult, this.SmearResult, this.SmearCancerGB, this.GynecologicCancerHistoryDesc, this.PersonalCancerHistoryDesc, this.FamilyCancerHistoryDesc, this.labelGynecologicCancerHistory, this.GynecologicCancerHistory, this.labelPersonalCancerHistory, this.PersonalCancerHistory, this.labelFamilyCancerHistory, this.FamilyCancerHistory, this.SmearAnamnezGB, this.labelSKRSAlkolKullanimiAnamnesisInfo, this.SKRSAlkolKullanimiAnamnesisInfo, this.labelSKRSMaddeKullanimiAnamnesisInfo, this.SKRSMaddeKullanimiAnamnesisInfo, this.labelSKRSSigaraKullanimiAnamnesisInfo, this.SKRSSigaraKullanimiAnamnesisInfo, this.SmearEducationGB, this.labelOccupationPatient, this.OccupationPatient, this.labelEducationStatusPatient, this.EducationStatusPatient, this.labelInsuranceTypePatient, this.InsuranceTypePatient, this.SmearScreeningGB, this.SKRSMaritalStatus, this.labelAilePlanlamasiAPYontemi, this.AilePlanlamasiAPYontemi, this.labelMenstrualCycle, this.MenstrualCycle, this.labelMenopauseAge, this.MenopauseAge, this.labelMenarcheAge, this.MenarcheAge, this.labelLiveBirthNumber, this.LiveBirthNumber, this.labelLastMenstruationDate, this.LastMenstruationDate, this.labelGestationalNumber, this.GestationalNumber, this.labelFirstMarriageAge, this.FirstMarriageAge, this.labelFirstGestationalAge, this.FirstGestationalAge, this.labelMaritalStatusPerson, this.PainDuringIntercourseText, this.labelBleedingAfterIntercourse, this.BleedingAfterIntercourse, this.labelPainDuringIntercourse, this.PainDuringIntercourse];

}
    printSmearScreeningForm() {

        let reportData: DynamicReportParameters = {

            Code: 'SMEARTARAMAFORMU',
            ReportParams: { ObjectID: this._SmearScreening.ObjectID.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "SMEAR TARAMA FORMU"

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
