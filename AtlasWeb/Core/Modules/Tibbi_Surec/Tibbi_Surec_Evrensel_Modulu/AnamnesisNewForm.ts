//$3AB8952D
import { Component, ViewChild, Input, AfterViewInit } from '@angular/core';
import { AnamnesisFormViewModel } from './AnamnesisFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PhysicianApplication } from 'NebulaClient/Model/AtlasClientModel';

import { AtlasRichTextBox } from "Fw/Components/AtlasRichTextBox";
import { ModalActionResult, ModalInfo, IModal } from 'app/Fw/Models/ModalInfo';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { IModalService } from "Fw/Services/IModalService";
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';

@Component({
    selector: 'AnamnesisNewForm',
    templateUrl: './AnamnesisNewForm.html',
    providers: [MessageService]
})
export class AnamnesisNewForm extends TTVisual.TTForm implements AfterViewInit, IModal {
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

    }

    @Input() showVitals = true;

    get anamnesisFormViewModel(): AnamnesisFormViewModel {
        return this._anamnesisFormViewModel;
    }

    setModalInfo(value: ModalInfo) {
        let a = value;
    }
    public async setInputParam(value: Object) {
        this._anamnesisFormViewModel = value as AnamnesisFormViewModel;
    }

    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalService: IModalService, ) {
        super('PHYSICIANAPPLICATION', 'AnamnesisForm');
        this._DocumentServiceUrl = this.AnamnesisForm_DocumentUrl;

        this.initFormControls();
    }

    ngAfterViewInit(): void {

    }
    // ***** Method declarations start *****

    //Şikayet
    @ViewChild('complaint') rtbComplaint: AtlasRichTextBox;
    copyComplaintHistory(Complaint) {
        this.rtbComplaint.value = this.rtbComplaint.value + Complaint;
    }

    //Özgeçmiş/Soygeçmiş
    @ViewChild('patientHistory') rtbPatientHistory: AtlasRichTextBox;
    public copyPatientHistory(PatientHistory) {
        this.rtbPatientHistory.value = this.rtbPatientHistory.value + PatientHistory;
    }

    //Fizik Muayene
    @ViewChild('physicalExamination') rtbPhysicalExamination: AtlasRichTextBox;
    public copyPhysicalExamination(PhysicalExamination) {
        this.rtbPhysicalExamination.value = this.rtbPhysicalExamination.value + PhysicalExamination;
    }

    //Tedavi Karar
    @ViewChild('mtsConclusion') rtbMTSConclusion: AtlasRichTextBox;
    public copyMTSConclusion(MTSConclusion) {
        this.rtbMTSConclusion.value = this.rtbMTSConclusion.value + MTSConclusion;
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
        this.MTSConclusion.TemplateGroupName = "Tedavi Karar";
        this.MTSConclusion.TabIndex = 6;

        this.labelPhysicalExamination = new TTVisual.TTLabel();
        this.labelPhysicalExamination.Text = i18n("M14383", "Fizik Muayene");
        this.labelPhysicalExamination.Name = "labelPhysicalExamination";
        this.labelPhysicalExamination.TabIndex = 5;

        this.PhysicalExamination = new TTVisual.TTRichTextBoxControl();
        this.PhysicalExamination.Name = "PhysicalExamination";
        this.PhysicalExamination.TemplateGroupName = "Muayene Fizik";
        this.PhysicalExamination.TabIndex = 4;

        this.labelPatientHistory = new TTVisual.TTLabel();
        this.labelPatientHistory.Text = i18n("M20118", "Özgeçmiş / Soygeçmiş");
        this.labelPatientHistory.Name = "labelPatientHistory";
        this.labelPatientHistory.TabIndex = 3;

        this.PatientHistory = new TTVisual.TTRichTextBoxControl();
        this.PatientHistory.Name = "PatientHistory";
        this.PatientHistory.TemplateGroupName = "Muayene Özgeçmiş";
        this.PatientHistory.TabIndex = 2;

        this.labelComplaint = new TTVisual.TTLabel();
        this.labelComplaint.Text = i18n("M22483", "Şikayet");
        this.labelComplaint.Name = "labelComplaint";
        this.labelComplaint.TabIndex = 1;

        this.Complaint = new TTVisual.TTRichTextBoxControl();
        this.Complaint.Name = "Complaint";
        this.Complaint.TemplateGroupName = "Muayene Şikayet";
        this.Complaint.TabIndex = 0;

        this.Controls = [this.labelMTSConclusion, this.MTSConclusion, this.labelPhysicalExamination, this.PhysicalExamination, this.labelPatientHistory, this.PatientHistory, this.labelComplaint, this.Complaint];

    }


    showAnamnesisHistoryPopup: boolean = false;
    private openAnamnesisHistory(_id: string) {
        this.showAnamnesisHistoryPopup = true;
        //this.createAnamnesisHistoryForm(_id).then(result => {
        //    let modalActionResult = result as ModalActionResult;
        //    if (modalActionResult.Result == DialogResult.OK) {


        //    }
        //});

    } 


    showAnamnesisDetailPopup: boolean = false;
    private openAnamnesisDetail() {
        this.showAnamnesisDetailPopup = true;
        //this.createAnamnesisHistoryForm(_id).then(result => {
        //    let modalActionResult = result as ModalActionResult;
        //    if (modalActionResult.Result == DialogResult.OK) {


        //    }
        //});

    }

    private createAnamnesisHistoryForm(data: string): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'AnamnesisHistoryForm';
            componentInfo.ModuleName = 'AnamnezModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/AnamnezModule';
            componentInfo.InputParam = new DynamicComponentInputParam(<any>that._anamnesisFormViewModel, new ActiveIDsModel(that._anamnesisFormViewModel._PhysicianApplication.ObjectID, null, null));


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M15638", "Anamnez Geçmişi");
            modalInfo.Width = 1200;
            modalInfo.Height = 500;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

}
