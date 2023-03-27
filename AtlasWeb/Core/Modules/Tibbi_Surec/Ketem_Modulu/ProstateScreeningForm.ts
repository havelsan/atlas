//$E10CA490
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ProstateScreeningFormViewModel } from './ProstateScreeningFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ProstateScreening } from 'NebulaClient/Model/AtlasClientModel';
import { AnamnesisInfo } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAlkolKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSSigaraKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisode } from 'NebulaClient/Model/AtlasClientModel';

import { DynamicReportParameters } from '../../../wwwroot/app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from '../../../wwwroot/app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from '../../../wwwroot/app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from '../../../wwwroot/app/Fw/Models/ParameterDefinitionModel';
import { ModalInfo } from '../../../wwwroot/app/Fw/Models/ModalInfo';
import { IModalService } from '../../../wwwroot/app/Fw/Services/IModalService';

@Component({
    selector: 'ProstateScreeningForm',
    templateUrl: './ProstateScreeningForm.html',
    providers: [MessageService]
})
export class ProstateScreeningForm extends TTVisual.TTForm implements OnInit {
    ChronicDiseases: TTVisual.ITTTextBox;
    Examination: TTVisual.ITTTextBox;
    FamilyCancerHistory: TTVisual.ITTEnumComboBox;
    FreePSA: TTVisual.ITTTextBox;
    FrequentUrination: TTVisual.ITTCheckBox;
    labelChronicDiseases: TTVisual.ITTLabel;
    labelExamination: TTVisual.ITTLabel;
    labelFamilyCancerHistory: TTVisual.ITTLabel;
    labelFreePSA: TTVisual.ITTLabel;
    labelOccupationPatient: TTVisual.ITTLabel;
    labelPSA: TTVisual.ITTLabel;
    labelScreeningResult: TTVisual.ITTLabel;
    labelSKRSAlkolKullanimiAnamnesisInfo: TTVisual.ITTLabel;
    labelSKRSSigaraKullanimiAnamnesisInfo: TTVisual.ITTLabel;
    labelTotalPSA: TTVisual.ITTLabel;
    labelUsedMedicines: TTVisual.ITTLabel;
    OccupationPatient: TTVisual.ITTObjectListBox;
    PainfulUrination: TTVisual.ITTCheckBox;
    PreviousScreeningGB: TTVisual.ITTGroupBox;
    ProstateAnamnesisGB: TTVisual.ITTGroupBox;
    ProstateResultGB: TTVisual.ITTGroupBox;
    PSA: TTVisual.ITTTextBox;
    ReductionInUrineFlow: TTVisual.ITTCheckBox;
    RetentionOfUrine: TTVisual.ITTCheckBox;
    ScreeningResult: TTVisual.ITTTextBox;
    ScreeningResultGB: TTVisual.ITTGroupBox;
    SKRSAlkolKullanimiAnamnesisInfo: TTVisual.ITTObjectListBox;
    SKRSSigaraKullanimiAnamnesisInfo: TTVisual.ITTObjectListBox;
    TotalPSA: TTVisual.ITTTextBox;
    UsedMedicines: TTVisual.ITTTextBox;
    public statesPanelClass: string = "col-lg-6";
    public _buttonCaption: string = "Yazdır";
    public _buttonIcon: string = "fa fa-print";
    public prostateScreeningFormViewModel: ProstateScreeningFormViewModel = new ProstateScreeningFormViewModel();
    public get _ProstateScreening(): ProstateScreening {
        return this._TTObject as ProstateScreening;
    }
    private ProstateScreeningForm_DocumentUrl: string = '/api/ProstateScreeningService/ProstateScreeningForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalService: IModalService) {
        super('PROSTATESCREENING', 'ProstateScreeningForm');
        this._DocumentServiceUrl = this.ProstateScreeningForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ProstateScreening();
        this.prostateScreeningFormViewModel = new ProstateScreeningFormViewModel();
        this._ViewModel = this.prostateScreeningFormViewModel;
        this.prostateScreeningFormViewModel._ProstateScreening = this._TTObject as ProstateScreening;
        this.prostateScreeningFormViewModel._ProstateScreening.AnamnesisInfo = new AnamnesisInfo();
        this.prostateScreeningFormViewModel._ProstateScreening.AnamnesisInfo.SKRSAlkolKullanimi = new SKRSAlkolKullanimi();
        this.prostateScreeningFormViewModel._ProstateScreening.AnamnesisInfo.SKRSSigaraKullanimi = new SKRSSigaraKullanimi();
        this.prostateScreeningFormViewModel._ProstateScreening.SubEpisode = new SubEpisode();
        this.prostateScreeningFormViewModel._ProstateScreening.SubEpisode.Episode = new Episode();
        this.prostateScreeningFormViewModel._ProstateScreening.SubEpisode.Episode.Patient = new Patient();
        this.prostateScreeningFormViewModel._ProstateScreening.SubEpisode.Episode.Patient.Occupation = new SKRSMeslekler();
    }

    protected loadViewModel() {
        let that = this;
        that.prostateScreeningFormViewModel = this._ViewModel as ProstateScreeningFormViewModel;
        that._TTObject = this.prostateScreeningFormViewModel._ProstateScreening;
        if (this.prostateScreeningFormViewModel == null)
            this.prostateScreeningFormViewModel = new ProstateScreeningFormViewModel();
        if (this.prostateScreeningFormViewModel._ProstateScreening == null)
            this.prostateScreeningFormViewModel._ProstateScreening = new ProstateScreening();
        let anamnesisInfoObjectID = that.prostateScreeningFormViewModel._ProstateScreening["AnamnesisInfo"];
        if (anamnesisInfoObjectID != null && (typeof anamnesisInfoObjectID === "string")) {
            let anamnesisInfo = that.prostateScreeningFormViewModel.AnamnesisInfos.find(o => o.ObjectID.toString() === anamnesisInfoObjectID.toString());
            if (anamnesisInfo) {
                that.prostateScreeningFormViewModel._ProstateScreening.AnamnesisInfo = anamnesisInfo;
            }

            if (anamnesisInfo != null) {
                let sKRSAlkolKullanimiObjectID = anamnesisInfo["SKRSAlkolKullanimi"];
                if (sKRSAlkolKullanimiObjectID != null && (typeof sKRSAlkolKullanimiObjectID === "string")) {
                    let sKRSAlkolKullanimi = that.prostateScreeningFormViewModel.SKRSAlkolKullanimis.find(o => o.ObjectID.toString() === sKRSAlkolKullanimiObjectID.toString());
                    if (sKRSAlkolKullanimi) {
                        anamnesisInfo.SKRSAlkolKullanimi = sKRSAlkolKullanimi;
                    }
                }

                let sKRSSigaraKullanimiObjectID = anamnesisInfo["SKRSSigaraKullanimi"];
                if (sKRSSigaraKullanimiObjectID != null && (typeof sKRSSigaraKullanimiObjectID === "string")) {
                    let sKRSSigaraKullanimi = that.prostateScreeningFormViewModel.SKRSSigaraKullanimis.find(o => o.ObjectID.toString() === sKRSSigaraKullanimiObjectID.toString());
                    if (sKRSSigaraKullanimi) {
                        anamnesisInfo.SKRSSigaraKullanimi = sKRSSigaraKullanimi;
                    }
                }

            }
        }

        let subEpisodeObjectID = that.prostateScreeningFormViewModel._ProstateScreening["SubEpisode"];
        if (subEpisodeObjectID != null && (typeof subEpisodeObjectID === "string")) {
            let subEpisode = that.prostateScreeningFormViewModel.SubEpisodes.find(o => o.ObjectID.toString() === subEpisodeObjectID.toString());
            if (subEpisode) {
                that.prostateScreeningFormViewModel._ProstateScreening.SubEpisode = subEpisode;
            }

            if (subEpisode != null) {
                let episodeObjectID = subEpisode["Episode"];
                if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
                    let episode = that.prostateScreeningFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
                    if (episode) {
                        subEpisode.Episode = episode;
                    }


                    if (episode != null) {
                        let patientObjectID = episode["Patient"];
                        if (patientObjectID != null && (typeof patientObjectID === "string")) {
                            let patient = that.prostateScreeningFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                            if (patient) {
                                episode.Patient = patient;
                            }

                            if (patient != null) {
                                let occupationObjectID = patient["Occupation"];
                                if (occupationObjectID != null && (typeof occupationObjectID === "string")) {
                                    let occupation = that.prostateScreeningFormViewModel.SKRSMesleklers.find(o => o.ObjectID.toString() === occupationObjectID.toString());
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
    await this.load();
}

public onChronicDiseasesChanged(event): void {
    if(this._ProstateScreening != null && this._ProstateScreening.ChronicDiseases != event) { 
    this._ProstateScreening.ChronicDiseases = event;
}
}

public onExaminationChanged(event): void {
    if(this._ProstateScreening != null && this._ProstateScreening.Examination != event) { 
    this._ProstateScreening.Examination = event;
}
}

public onFamilyCancerHistoryChanged(event): void {
    if(this._ProstateScreening != null && this._ProstateScreening.FamilyCancerHistory != event) { 
    this._ProstateScreening.FamilyCancerHistory = event;
}
}

public onFreePSAChanged(event): void {
    if(this._ProstateScreening != null && this._ProstateScreening.FreePSA != event) { 
    this._ProstateScreening.FreePSA = event;
}
}

public onFrequentUrinationChanged(event): void {
    if(this._ProstateScreening != null && this._ProstateScreening.FrequentUrination != event) { 
    this._ProstateScreening.FrequentUrination = event;
}
}

public onOccupationPatientChanged(event): void {
    if(this._ProstateScreening != null &&
    this._ProstateScreening.SubEpisode != null &&
    this._ProstateScreening.SubEpisode.Episode != null &&
    this._ProstateScreening.SubEpisode.Episode.Patient != null && this._ProstateScreening.SubEpisode.Episode.Patient.Occupation != event) { 
    this._ProstateScreening.SubEpisode.Episode.Patient.Occupation = event;
}
}

public onPainfulUrinationChanged(event): void {
    if(this._ProstateScreening != null && this._ProstateScreening.PainfulUrination != event) { 
    this._ProstateScreening.PainfulUrination = event;
}
}

public onPSAChanged(event): void {
    if(this._ProstateScreening != null && this._ProstateScreening.PSA != event) { 
    this._ProstateScreening.PSA = event;
}
}

public onReductionInUrineFlowChanged(event): void {
    if(this._ProstateScreening != null && this._ProstateScreening.ReductionInUrineFlow != event) { 
    this._ProstateScreening.ReductionInUrineFlow = event;
}
}

public onRetentionOfUrineChanged(event): void {
    if(this._ProstateScreening != null && this._ProstateScreening.RetentionOfUrine != event) { 
    this._ProstateScreening.RetentionOfUrine = event;
}
}

public onScreeningResultChanged(event): void {
    if(this._ProstateScreening != null && this._ProstateScreening.ScreeningResult != event) { 
    this._ProstateScreening.ScreeningResult = event;
}
}

public onSKRSAlkolKullanimiAnamnesisInfoChanged(event): void {
    if(this._ProstateScreening != null &&
    this._ProstateScreening.AnamnesisInfo != null && this._ProstateScreening.AnamnesisInfo.SKRSAlkolKullanimi != event) { 
    this._ProstateScreening.AnamnesisInfo.SKRSAlkolKullanimi = event;
}
}

public onSKRSSigaraKullanimiAnamnesisInfoChanged(event): void {
    if(this._ProstateScreening != null &&
    this._ProstateScreening.AnamnesisInfo != null && this._ProstateScreening.AnamnesisInfo.SKRSSigaraKullanimi != event) { 
    this._ProstateScreening.AnamnesisInfo.SKRSSigaraKullanimi = event;
}
}

public onTotalPSAChanged(event): void {
    if(this._ProstateScreening != null && this._ProstateScreening.TotalPSA != event) { 
    this._ProstateScreening.TotalPSA = event;
}
}

public onUsedMedicinesChanged(event): void {
    if(this._ProstateScreening != null && this._ProstateScreening.UsedMedicines != event) { 
    this._ProstateScreening.UsedMedicines = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.FrequentUrination, "Value", this.__ttObject, "FrequentUrination");
    redirectProperty(this.UsedMedicines, "Text", this.__ttObject, "UsedMedicines");
    redirectProperty(this.FamilyCancerHistory, "Value", this.__ttObject, "FamilyCancerHistory");
    redirectProperty(this.PainfulUrination, "Value", this.__ttObject, "PainfulUrination");
    redirectProperty(this.RetentionOfUrine, "Value", this.__ttObject, "RetentionOfUrine");
    redirectProperty(this.ChronicDiseases, "Text", this.__ttObject, "ChronicDiseases");
    redirectProperty(this.ReductionInUrineFlow, "Value", this.__ttObject, "ReductionInUrineFlow");
    redirectProperty(this.PSA, "Text", this.__ttObject, "PSA");
    redirectProperty(this.Examination, "Text", this.__ttObject, "Examination");
    redirectProperty(this.TotalPSA, "Text", this.__ttObject, "TotalPSA");
    redirectProperty(this.FreePSA, "Text", this.__ttObject, "FreePSA");
    redirectProperty(this.ScreeningResult, "Text", this.__ttObject, "ScreeningResult");
}

public initFormControls() : void {
    this.ProstateResultGB = new TTVisual.TTGroupBox();
    this.ProstateResultGB.Text = "Prostat, PSA ve Tarama Sonu Muayene Bulguları";
    this.ProstateResultGB.Name = "ProstateResultGB";
    this.ProstateResultGB.TabIndex = 1;

    this.labelScreeningResult = new TTVisual.TTLabel();
    this.labelScreeningResult.Text = "Tarama Sonu Muayene Bulguları";
    this.labelScreeningResult.Name = "labelScreeningResult";
    this.labelScreeningResult.TabIndex = 3;

    this.ScreeningResult = new TTVisual.TTTextBox();
    this.ScreeningResult.Multiline = true;
    this.ScreeningResult.Name = "ScreeningResult";
    this.ScreeningResult.TabIndex = 2;

    this.ScreeningResultGB = new TTVisual.TTGroupBox();
    this.ScreeningResultGB.Text = "Tarama sonucu PSA Değerleri";
    this.ScreeningResultGB.Name = "ScreeningResultGB";
    this.ScreeningResultGB.TabIndex = 1;

    this.labelFreePSA = new TTVisual.TTLabel();
    this.labelFreePSA.Text = "Serbest PSA";
    this.labelFreePSA.Name = "labelFreePSA";
    this.labelFreePSA.TabIndex = 3;

    this.FreePSA = new TTVisual.TTTextBox();
    this.FreePSA.Multiline = true;
    this.FreePSA.Name = "FreePSA";
    this.FreePSA.TabIndex = 2;

    this.labelTotalPSA = new TTVisual.TTLabel();
    this.labelTotalPSA.Text = "Total PSA";
    this.labelTotalPSA.Name = "labelTotalPSA";
    this.labelTotalPSA.TabIndex = 1;

    this.TotalPSA = new TTVisual.TTTextBox();
    this.TotalPSA.Multiline = true;
    this.TotalPSA.Name = "TotalPSA";
    this.TotalPSA.TabIndex = 0;

    this.PreviousScreeningGB = new TTVisual.TTGroupBox();
    this.PreviousScreeningGB.Text = "Önceki Prostat Taraması";
    this.PreviousScreeningGB.Name = "PreviousScreeningGB";
    this.PreviousScreeningGB.TabIndex = 0;

    this.labelExamination = new TTVisual.TTLabel();
    this.labelExamination.Text = "Muayene";
    this.labelExamination.Name = "labelExamination";
    this.labelExamination.TabIndex = 3;

    this.Examination = new TTVisual.TTTextBox();
    this.Examination.Multiline = true;
    this.Examination.Name = "Examination";
    this.Examination.TabIndex = 2;
    this.Examination.Height = "65px";

    this.labelPSA = new TTVisual.TTLabel();
    this.labelPSA.Text = "PSA";
    this.labelPSA.Name = "labelPSA";
    this.labelPSA.TabIndex = 1;

    this.PSA = new TTVisual.TTTextBox();
    this.PSA.Multiline = true;
    this.PSA.Name = "PSA";
    this.PSA.TabIndex = 0;
    this.PSA.Height = "65px";

    this.ProstateAnamnesisGB = new TTVisual.TTGroupBox();
    this.ProstateAnamnesisGB.Text = "Meslek ve Anemnez Bilgileri";
    this.ProstateAnamnesisGB.Name = "ProstateAnamnesisGB";
    this.ProstateAnamnesisGB.TabIndex = 0;

    this.ReductionInUrineFlow = new TTVisual.TTCheckBox();
    this.ReductionInUrineFlow.Value = false;
    this.ReductionInUrineFlow.Title = "İdrar Akışında Azamla";
    this.ReductionInUrineFlow.Name = "ReductionInUrineFlow";
    this.ReductionInUrineFlow.TabIndex = 15;

    this.RetentionOfUrine = new TTVisual.TTCheckBox();
    this.RetentionOfUrine.Value = false;
    this.RetentionOfUrine.Title = "İdrarı Tam Boşaltamama Hissi";
    this.RetentionOfUrine.Name = "RetentionOfUrine";
    this.RetentionOfUrine.TabIndex = 14;

    this.PainfulUrination = new TTVisual.TTCheckBox();
    this.PainfulUrination.Value = false;
    this.PainfulUrination.Title = "Kesik, Ağrılı İdrar Yapma";
    this.PainfulUrination.Name = "PainfulUrination";
    this.PainfulUrination.TabIndex = 13;

    this.FrequentUrination = new TTVisual.TTCheckBox();
    this.FrequentUrination.Value = false;
    this.FrequentUrination.Title = "Sık İdrara Çıkma";
    this.FrequentUrination.Name = "FrequentUrination";
    this.FrequentUrination.TabIndex = 12;

    this.labelChronicDiseases = new TTVisual.TTLabel();
    this.labelChronicDiseases.Text = "Kronik Hastalıklar";
    this.labelChronicDiseases.Name = "labelChronicDiseases";
    this.labelChronicDiseases.TabIndex = 11;

    this.ChronicDiseases = new TTVisual.TTTextBox();
    this.ChronicDiseases.Multiline = true;
    this.ChronicDiseases.Name = "ChronicDiseases";
    this.ChronicDiseases.TabIndex = 10;

    this.labelUsedMedicines = new TTVisual.TTLabel();
    this.labelUsedMedicines.Text = "Sürekli Kullandığı İlaçlar";
    this.labelUsedMedicines.Name = "labelUsedMedicines";
    this.labelUsedMedicines.TabIndex = 9;

    this.UsedMedicines = new TTVisual.TTTextBox();
    this.UsedMedicines.Multiline = true;
    this.UsedMedicines.Name = "UsedMedicines";
    this.UsedMedicines.TabIndex = 8;

    this.labelSKRSAlkolKullanimiAnamnesisInfo = new TTVisual.TTLabel();
    this.labelSKRSAlkolKullanimiAnamnesisInfo.Text = "Alkol Kullanımı";
    this.labelSKRSAlkolKullanimiAnamnesisInfo.Name = "labelSKRSAlkolKullanimiAnamnesisInfo";
    this.labelSKRSAlkolKullanimiAnamnesisInfo.TabIndex = 7;

    this.SKRSAlkolKullanimiAnamnesisInfo = new TTVisual.TTObjectListBox();
    this.SKRSAlkolKullanimiAnamnesisInfo.ListDefName = "SKRSAlkolKullanimiList";
    this.SKRSAlkolKullanimiAnamnesisInfo.Name = "SKRSAlkolKullanimiAnamnesisInfo";
    this.SKRSAlkolKullanimiAnamnesisInfo.TabIndex = 6;

    this.labelSKRSSigaraKullanimiAnamnesisInfo = new TTVisual.TTLabel();
    this.labelSKRSSigaraKullanimiAnamnesisInfo.Text = "Sigara Kullanımı";
    this.labelSKRSSigaraKullanimiAnamnesisInfo.Name = "labelSKRSSigaraKullanimiAnamnesisInfo";
    this.labelSKRSSigaraKullanimiAnamnesisInfo.TabIndex = 5;

    this.SKRSSigaraKullanimiAnamnesisInfo = new TTVisual.TTObjectListBox();
    this.SKRSSigaraKullanimiAnamnesisInfo.ListDefName = "SKRSSigaraKullanimiList";
    this.SKRSSigaraKullanimiAnamnesisInfo.Name = "SKRSSigaraKullanimiAnamnesisInfo";
    this.SKRSSigaraKullanimiAnamnesisInfo.TabIndex = 4;

    this.labelFamilyCancerHistory = new TTVisual.TTLabel();
    this.labelFamilyCancerHistory.Text = "Ailede Kanser Öyküsü";
    this.labelFamilyCancerHistory.Name = "labelFamilyCancerHistory";
    this.labelFamilyCancerHistory.TabIndex = 3;

    this.FamilyCancerHistory = new TTVisual.TTEnumComboBox();
    this.FamilyCancerHistory.DataTypeName = "VarYokGarantiEnum";
    this.FamilyCancerHistory.Name = "FamilyCancerHistory";
    this.FamilyCancerHistory.TabIndex = 2;

    this.labelOccupationPatient = new TTVisual.TTLabel();
    this.labelOccupationPatient.Text = "Meslek";
    this.labelOccupationPatient.Name = "labelOccupationPatient";
    this.labelOccupationPatient.TabIndex = 1;

    this.OccupationPatient = new TTVisual.TTObjectListBox();
    this.OccupationPatient.ListDefName = "SKRSMesleklerList";
    this.OccupationPatient.Name = "OccupationPatient";
    this.OccupationPatient.TabIndex = 0;

    this.ProstateResultGB.Controls = [this.labelScreeningResult, this.ScreeningResult, this.ScreeningResultGB, this.PreviousScreeningGB];
    this.ScreeningResultGB.Controls = [this.labelFreePSA, this.FreePSA, this.labelTotalPSA, this.TotalPSA];
    this.PreviousScreeningGB.Controls = [this.labelExamination, this.Examination, this.labelPSA, this.PSA];
    this.ProstateAnamnesisGB.Controls = [this.ReductionInUrineFlow, this.RetentionOfUrine, this.PainfulUrination, this.FrequentUrination, this.labelChronicDiseases, this.ChronicDiseases, this.labelUsedMedicines, this.UsedMedicines, this.labelSKRSAlkolKullanimiAnamnesisInfo, this.SKRSAlkolKullanimiAnamnesisInfo, this.labelSKRSSigaraKullanimiAnamnesisInfo, this.SKRSSigaraKullanimiAnamnesisInfo, this.labelFamilyCancerHistory, this.FamilyCancerHistory, this.labelOccupationPatient, this.OccupationPatient];
    this.Controls = [this.ProstateResultGB, this.labelScreeningResult, this.ScreeningResult, this.ScreeningResultGB, this.labelFreePSA, this.FreePSA, this.labelTotalPSA, this.TotalPSA, this.PreviousScreeningGB, this.labelExamination, this.Examination, this.labelPSA, this.PSA, this.ProstateAnamnesisGB, this.ReductionInUrineFlow, this.RetentionOfUrine, this.PainfulUrination, this.FrequentUrination, this.labelChronicDiseases, this.ChronicDiseases, this.labelUsedMedicines, this.UsedMedicines, this.labelSKRSAlkolKullanimiAnamnesisInfo, this.SKRSAlkolKullanimiAnamnesisInfo, this.labelSKRSSigaraKullanimiAnamnesisInfo, this.SKRSSigaraKullanimiAnamnesisInfo, this.labelFamilyCancerHistory, this.FamilyCancerHistory, this.labelOccupationPatient, this.OccupationPatient];

}
    printProstateScreeningForm() {

        let reportData: DynamicReportParameters = {

            Code: 'PROSTATTARAMAFORMU',
            ReportParams: { ObjectID: this._ProstateScreening.ObjectID.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "PROSTAT TARAMA FORMU"

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
