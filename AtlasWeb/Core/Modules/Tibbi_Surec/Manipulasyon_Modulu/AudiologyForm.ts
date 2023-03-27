//$B8C411C9
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { AudiologyFormViewModel, AudiologyDiagnosisObject } from './AudiologyFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AudiologyObject } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationFormBaseObjectForm } from "Modules/Tibbi_Surec/Manipulasyon_Modulu/ManipulationFormBaseObjectForm";
import { AudiologyDiagnosis } from 'NebulaClient/Model/AtlasClientModel';
import { AudiologyDiagnosisDef } from 'NebulaClient/Model/AtlasClientModel';
import { Manipulation } from 'NebulaClient/Model/AtlasClientModel';
import { ModalStateService, ModalInfo, IModal } from "Fw/Models/ModalInfo";

import { Guid } from 'app/NebulaClient/Mscorlib/Guid';

@Component({
    selector: 'AudiologyForm',
    templateUrl: './AudiologyForm.html',
    providers: [MessageService]
})
export class AudiologyForm extends ManipulationFormBaseObjectForm implements OnInit, IModal {
    AudiologyDiagnosis: TTVisual.ITTGrid;
    AudiologyDiagnosisDefAudiologyDiagnosis: TTVisual.ITTListBoxColumn;
    AudiologyReport: TTVisual.ITTRichTextBoxControl;
    labelAudiologyReport: TTVisual.ITTLabel;
    labelResultNote: TTVisual.ITTLabel;
    labelTherapyNote: TTVisual.ITTLabel;
    ResultNote: TTVisual.ITTTextBox;
    TherapyNote: TTVisual.ITTTextBox;
    AudiologyDiagnosisList: TTVisual.ITTObjectListBox;

    public AudiologyDiagnosisColumns = [];
   

    _showResult: boolean = false;
    _readOnly: boolean = false;

    public audiologyFormViewModel: AudiologyFormViewModel = new AudiologyFormViewModel();
    public get _AudiologyObject(): AudiologyObject {
        return this._TTObject as AudiologyObject;
    }
    private AudiologyForm_DocumentUrl: string = '/api/AudiologyObjectService/AudiologyForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super(httpService, messageService);
        this._DocumentServiceUrl = this.AudiologyForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    setInputParam(value: any) { //Manipulation.CurrentStateDefID

        if (value.toString() == Manipulation.ManipulationStates.ResultEntry.toString()) 
            this._showResult = true;

        if (value.toString() == Manipulation.ManipulationStates.Completed.toString() || value.toString() == Manipulation.ManipulationStates.Cancelled.toString()) {
            this.ReadOnly = true;
            this._readOnly = true;
        }

    }

    protected _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new AudiologyObject();
        this.audiologyFormViewModel = new AudiologyFormViewModel();
        this._ViewModel = this.audiologyFormViewModel;
        this.audiologyFormViewModel._AudiologyObject = this._TTObject as AudiologyObject;
        this.audiologyFormViewModel._AudiologyObject.AudiologyDiagnosis = new Array<AudiologyDiagnosis>();
    }

    protected loadViewModel() {
        let that = this;
        that.audiologyFormViewModel = this._ViewModel as AudiologyFormViewModel;
        that._TTObject = this.audiologyFormViewModel._AudiologyObject;
        if (this.audiologyFormViewModel == null)
            this.audiologyFormViewModel = new AudiologyFormViewModel();
        if (this.audiologyFormViewModel._AudiologyObject == null)
            this.audiologyFormViewModel._AudiologyObject = new AudiologyObject();
        that.audiologyFormViewModel._AudiologyObject.AudiologyDiagnosis = that.audiologyFormViewModel.AudiologyDiagnosisGridList;
        for (let detailItem of that.audiologyFormViewModel.AudiologyDiagnosisGridList) {
            let audiologyDiagnosisDefObjectID = detailItem["AudiologyDiagnosisDef"];
            if (audiologyDiagnosisDefObjectID != null && (typeof audiologyDiagnosisDefObjectID === "string")) {
                let audiologyDiagnosisDef = that.audiologyFormViewModel.AudiologyDiagnosisDefs.find(o => o.ObjectID.toString() === audiologyDiagnosisDefObjectID.toString());
                if (audiologyDiagnosisDef) {
                    detailItem.AudiologyDiagnosisDef = audiologyDiagnosisDef;
                }
            }

        }

        this.createDiagnosisColumns();
    }



async ngOnInit() {
    await this.load(AudiologyFormViewModel);
}

public onAudiologyReportChanged(event): void {
    if(this._AudiologyObject != null && this._AudiologyObject.AudiologyReport != event) { 
    this._AudiologyObject.AudiologyReport = event;
}
}

public onResultNoteChanged(event): void {
    if(this._AudiologyObject != null && this._AudiologyObject.ResultNote != event) { 
    this._AudiologyObject.ResultNote = event;
}
}

public onTherapyNoteChanged(event): void {
    if(this._AudiologyObject != null && this._AudiologyObject.TherapyNote != event) { 
    this._AudiologyObject.TherapyNote = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.ResultNote, "Text", this.__ttObject, "ResultNote");
    redirectProperty(this.TherapyNote, "Text", this.__ttObject, "TherapyNote");
    redirectProperty(this.AudiologyReport, "Rtf", this.__ttObject, "AudiologyReport");
}

public initFormControls() : void {
    this.AudiologyDiagnosis = new TTVisual.TTGrid();
    this.AudiologyDiagnosis.Name = "AudiologyDiagnosis";
    this.AudiologyDiagnosis.TabIndex = 6;

    this.AudiologyDiagnosisDefAudiologyDiagnosis = new TTVisual.TTListBoxColumn();
    this.AudiologyDiagnosisDefAudiologyDiagnosis.ListDefName = "AudiologyDiagnosisDefList";
    this.AudiologyDiagnosisDefAudiologyDiagnosis.DataMember = "AudiologyDiagnosisDef";
    this.AudiologyDiagnosisDefAudiologyDiagnosis.DisplayIndex = 0;
    this.AudiologyDiagnosisDefAudiologyDiagnosis.HeaderText = "Odyoloji Tanıları";
    this.AudiologyDiagnosisDefAudiologyDiagnosis.Name = "AudiologyDiagnosisDefAudiologyDiagnosis";
    this.AudiologyDiagnosisDefAudiologyDiagnosis.Width = 300;

    this.labelTherapyNote = new TTVisual.TTLabel();
    this.labelTherapyNote.Text = "Terapi Notu";
    this.labelTherapyNote.Name = "labelTherapyNote";
    this.labelTherapyNote.TabIndex = 5;

    this.TherapyNote = new TTVisual.TTTextBox();
    this.TherapyNote.Multiline = true;
    this.TherapyNote.Name = "TherapyNote";
    this.TherapyNote.TabIndex = 4;

    this.ResultNote = new TTVisual.TTTextBox();
    this.ResultNote.Multiline = true;
    this.ResultNote.Name = "ResultNote";
    this.ResultNote.TabIndex = 2;

    this.labelResultNote = new TTVisual.TTLabel();
    this.labelResultNote.Text = "Odyoloji Tetkik Sonuç Notu";
    this.labelResultNote.Name = "labelResultNote";
    this.labelResultNote.TabIndex = 3;

    this.labelAudiologyReport = new TTVisual.TTLabel();
    this.labelAudiologyReport.Text = "Odyoloji Raporu";
    this.labelAudiologyReport.Name = "labelAudiologyReport";
    this.labelAudiologyReport.TabIndex = 1;

    this.AudiologyReport = new TTVisual.TTRichTextBoxControl();
    this.AudiologyReport.Name = "AudiologyReport";
    this.AudiologyReport.TabIndex = 0;
    this.AudiologyReport.TemplateGroupName = "Odyoloji Şablon";

    this.AudiologyDiagnosisList = new TTVisual.TTObjectListBox();
    this.AudiologyDiagnosisList.ListDefName = "AudiologyDiagnosisListDef";
    this.AudiologyDiagnosisList.Name = "AudiologyDiagnosisList";

    //this.AudiologyDiagnosisColumns = [this.AudiologyDiagnosisDefAudiologyDiagnosis];
    this.Controls = [this.AudiologyDiagnosis, this.AudiologyDiagnosisDefAudiologyDiagnosis, this.labelTherapyNote, this.TherapyNote, this.ResultNote, this.labelResultNote, this.labelAudiologyReport, this.AudiologyReport];

}

    diagnosisSelected(data: AudiologyDiagnosisDef) {
        this.audiologyFormViewModel._selectedDiagnosis = data;
        let that = this;
        let flag: boolean = false;

        for (var i = 0; i < that.audiologyFormViewModel.DiagnosisArray.length; i++) {
            if (data.ObjectID.toString() == that.audiologyFormViewModel.DiagnosisArray[i].DiagnosisDefObjectID.toString()) {
                flag = true;
                break;
            }
        }
        if (!flag) {
            let diagnosis: AudiologyDiagnosisObject = new AudiologyDiagnosisObject();
            diagnosis.Name = data.DiagnosisName;
            diagnosis.DiagnosisDefObjectID = data.ObjectID;
            diagnosis.DiagnosisObjectID = new Guid();
            that.audiologyFormViewModel.DiagnosisArray.unshift(diagnosis);
        }

       
    }

    createDiagnosisColumns() {
        this.AudiologyDiagnosisColumns = [
            {
                "caption": "Tanı",
                dataField: "Name",
                width: '100%',
                allowSorting: false,
                allowEditing: false
            }]
    }
}
