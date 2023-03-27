//$3AB8952D
import { Component, ViewChild, Input, AfterViewInit, Output, EventEmitter } from '@angular/core';
import { AnamnesisFormViewModel, AnamnesisListInfo, AnamnesisPopUp } from './AnamnesisFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PhysicianApplication } from 'NebulaClient/Model/AtlasClientModel';
import { ModalInfo, IModal } from "Fw/Models/ModalInfo";


import { AtlasRichTextBox } from "Fw/Components/AtlasRichTextBox";

@Component({
    selector: 'AnamnesisHistoryForm',
    templateUrl: './AnamnesisHistoryForm.html',
    providers: [MessageService]
})
export class AnamnesisHistoryForm extends TTVisual.TTForm implements AfterViewInit, IModal {
    Complaint: TTVisual.ITTRichTextBoxControl;
    labelComplaint: TTVisual.ITTLabel;
    labelMTSConclusion: TTVisual.ITTLabel;
    labelPatientHistory: TTVisual.ITTLabel;
    labelPhysicalExamination: TTVisual.ITTLabel;
    MTSConclusion: TTVisual.ITTRichTextBoxControl;
    PatientHistory: TTVisual.ITTRichTextBoxControl;
    PhysicalExamination: TTVisual.ITTRichTextBoxControl;

    public get _PhysicianApplication(): PhysicianApplication {
        return this._TTObject as PhysicianApplication;
    }
    private AnamnesisForm_DocumentUrl: string = '/api/PhysicianApplicationService/AnamnesisForm';

    public _anamnesisFormViewModel: AnamnesisFormViewModel = new AnamnesisFormViewModel();
    @Input() set anamnesisFormViewModel(value: AnamnesisFormViewModel) {
        this._anamnesisFormViewModel = value;
        if (value != null)
            this.loadAnamnesisHistory(value);

        this.oldAnamnesisInfo = new AnamnesisPopUp();
        this.OldAnamnesisListType = i18n("M23632", "Tüm Branşlar");

    }
    private _modalInfo: ModalInfo;
    public setInputParam(value: AnamnesisFormViewModel) {
        this._anamnesisFormViewModel = value;
        if (value != null)
            this.loadAnamnesisHistory(value);

        this.oldAnamnesisInfo = new AnamnesisPopUp();
        this.OldAnamnesisListType = i18n("M23632", "Tüm Branşlar");

    }

    // private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {

    }

    @Input() showVitals = true;

    get anamnesisFormViewModel(): AnamnesisFormViewModel {
        return this._anamnesisFormViewModel;
    }

    oldAnamnesisInfo: AnamnesisPopUp = new AnamnesisPopUp();

    private oldAnamnesisConfig: any = {
        removePlugins: 'elementspath',
        height: '200px'
    };
    AnamnesisListColumns = [
        {
            caption: 'Tarih',
            dataField: 'ProcessDate',
            allowEditing: false,
            fixed: true,
            allowSorting: false,
            width: '30 % '
        }, {
            caption: 'Doktor',
            dataField: 'DoctorName',
            allowEditing: false,
            allowSorting: false,
            fixed: true,
            width: '40%'
        }, {
            caption: 'Birim',
            dataField: 'UnitName',
            allowEditing: false,
            allowSorting: false,
            fixed: true,
            width: '40%'
        }

    ];
    AnamnesisHistoryList: Array<AnamnesisListInfo> = [];

    ListType: string[] = [
        i18n("M17481", "Kendi Kabullerim"),
        i18n("M17480", "Kendi Branşım"),
        i18n("M23632", "Tüm Branşlar")
    ];
    OldAnamnesisListType: string = i18n("M23632", "Tüm Branşlar");
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('PHYSICIANAPPLICATION', 'AnamnesisForm');
        this._DocumentServiceUrl = this.AnamnesisForm_DocumentUrl;

        //this.initFormControls();
    }

    public async loadAnamnesisHistory(model: AnamnesisFormViewModel) {
        if (model.PatientID != null) {
            let that = this;
            let apiUrl: string = "/api/PhysicianApplicationService/GetAnamnesisHistory?PatientID=" + model.PatientID + "&EpisodeActionID=" + model._PhysicianApplication.ObjectID + "&ListType=" + this.OldAnamnesisListType;
            that.httpService.get<any>(apiUrl)
                .then(response => {
                    let result = response;
                    this.AnamnesisHistoryList = result;

                })
                .catch(error => {
                    console.log(error);
                });
        }

    }

    ngAfterViewInit(): void {

    }
    // ***** Method declarations start *****

    //Şikayet
    @ViewChild('oldComplaint') rtbOldComplaint: AtlasRichTextBox;
    @Output() complaintHistoryChange = new EventEmitter();
    public copyComplaintHistory() {
        if (this.oldAnamnesisInfo.Complaint != null) {
            this.complaintHistoryChange.emit(this.oldAnamnesisInfo.Complaint);
        }
        TTVisual.InfoBox.Alert("Şikayet Kopyalandı!");
    }

    //Özgeçmiş/Soygeçmiş
    @ViewChild('OldPatientHistory') rtbOldPatientHistory: AtlasRichTextBox;
    @Output() patientHistoryChange = new EventEmitter();
    public copyPatientHistory() {
        if (this.oldAnamnesisInfo.PatientHistory != null) {
            this.patientHistoryChange.emit(this.oldAnamnesisInfo.PatientHistory);
        }
        TTVisual.InfoBox.Alert("Özgeçmiş/Soygeçmiş Kopyalandı!");
    }

    //Fizik Muayene
    @ViewChild('oldPhysicalExamination') rtbOldPhysicalExamination: AtlasRichTextBox;
    @Output() physicalExaminationChange = new EventEmitter();
    public copyPhysicalExamination() {
        if (this.oldAnamnesisInfo.PhysicalExamination) {
            this.physicalExaminationChange.emit(this.oldAnamnesisInfo.PhysicalExamination);
        }
        TTVisual.InfoBox.Alert("Fizik Muayene Kopyalandı!");
    }

    //Tedavi Karar
    @ViewChild('oldMTSConclusion') rtbOldMTSConclusion: AtlasRichTextBox;
    @Output() mTSConclusionChange = new EventEmitter();
    public copyMTSConclusion() {
        if (this.oldAnamnesisInfo.MTSConclusion) {
            this.mTSConclusionChange.emit(this.oldAnamnesisInfo.MTSConclusion);
        }
        TTVisual.InfoBox.Alert("Tedavi Karar Kopyalandı!");
    }

    // *****Method declarations end *****

    public onComplaintChanged(event): void {
        if (event != null) {
            if (this.anamnesisFormViewModel._PhysicianApplication != null && this.anamnesisFormViewModel._PhysicianApplication.Complaint != event) {
                this.anamnesisFormViewModel._PhysicianApplication.Complaint = event;
            }
        }
    }

    public onMTSConclusionChanged(event): void {
        if (event != null) {
            if (this.anamnesisFormViewModel._PhysicianApplication != null && this.anamnesisFormViewModel._PhysicianApplication.MTSConclusion != event) {
                this.anamnesisFormViewModel._PhysicianApplication.MTSConclusion = event;
            }
        }
    }

    public onPatientHistoryChanged(event): void {
        if (event != null) {
            if (this.anamnesisFormViewModel._PhysicianApplication != null && this.anamnesisFormViewModel._PhysicianApplication.PatientHistory != event) {
                this.anamnesisFormViewModel._PhysicianApplication.PatientHistory = event;
            }
        }
    }

    public onPhysicalExaminationChanged(event): void {
        if (event != null) {
            if (this.anamnesisFormViewModel._PhysicianApplication != null && this.anamnesisFormViewModel._PhysicianApplication.PhysicalExamination != event) {
                this.anamnesisFormViewModel._PhysicianApplication.PhysicalExamination = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Complaint, "Rtf", this.__ttObject, "Complaint");
        redirectProperty(this.PatientHistory, "Rtf", this.__ttObject, "PatientHistory");
        redirectProperty(this.PhysicalExamination, "Rtf", this.__ttObject, "PhysicalExamination");
        redirectProperty(this.MTSConclusion, "Rtf", this.__ttObject, "MTSConclusion");
    }

    public initFormControls(): void {
        this.labelMTSConclusion = new TTVisual.TTLabel();
        this.labelMTSConclusion.Text = i18n("M22996", "Tedavi Karar");
        this.labelMTSConclusion.Name = "labelMTSConclusion";
        this.labelMTSConclusion.TabIndex = 7;

        this.MTSConclusion = new TTVisual.TTRichTextBoxControl();
        this.MTSConclusion.Name = "MTSConclusion";
        this.MTSConclusion.TabIndex = 6;

        this.labelPhysicalExamination = new TTVisual.TTLabel();
        this.labelPhysicalExamination.Text = i18n("M14383", "Fizik Muayene");
        this.labelPhysicalExamination.Name = "labelPhysicalExamination";
        this.labelPhysicalExamination.TabIndex = 5;

        this.PhysicalExamination = new TTVisual.TTRichTextBoxControl();
        this.PhysicalExamination.Name = "PhysicalExamination";
        this.PhysicalExamination.TabIndex = 4;

        this.labelPatientHistory = new TTVisual.TTLabel();
        this.labelPatientHistory.Text = i18n("M20118", "Özgeçmiş / Soygeçmiş");
        this.labelPatientHistory.Name = "labelPatientHistory";
        this.labelPatientHistory.TabIndex = 3;

        this.PatientHistory = new TTVisual.TTRichTextBoxControl();
        this.PatientHistory.Name = "PatientHistory";
        this.PatientHistory.TabIndex = 2;

        this.labelComplaint = new TTVisual.TTLabel();
        this.labelComplaint.Text = i18n("M22483", "Şikayet");
        this.labelComplaint.Name = "labelComplaint";
        this.labelComplaint.TabIndex = 1;

        this.Complaint = new TTVisual.TTRichTextBoxControl();
        this.Complaint.Name = "Complaint";
        this.Complaint.TabIndex = 0;

        this.Controls = [this.labelMTSConclusion, this.MTSConclusion, this.labelPhysicalExamination, this.PhysicalExamination, this.labelPatientHistory, this.PatientHistory, this.labelComplaint, this.Complaint];

    }

    selectAnamnesis(data) {
        if (data != null) {

            let that = this;
            let apiUrl: string = '/api/PhysicianApplicationService/GetOldAnamnesisInfo?PhysicianApplicationID=' + data.currentSelectedRowKeys[0].ObjectID;
            this.httpService.get<any>(apiUrl)
                .then(response => {
                    let result = response;
                    that.oldAnamnesisInfo = result;

                })
                .catch(error => {
                    console.log(error);
                });




        }
    }

    onRadioSelectChanged() {
        this.loadAnamnesisHistory(this.anamnesisFormViewModel);
    }
}
