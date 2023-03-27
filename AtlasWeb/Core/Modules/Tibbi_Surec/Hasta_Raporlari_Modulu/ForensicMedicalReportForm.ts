//$5F3B0179
import { Component, OnInit, NgZone } from '@angular/core';
import { ForensicMedicalReportFormViewModel } from './ForensicMedicalReportFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { ForensicMedicalReport } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ReasonExaminationTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { MilitaryUnit } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { ModalStateService, ModalInfo, IModal, ModalActionResult } from "Fw/Models/ModalInfo";
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';


@Component({
    selector: 'ForensicMedicalReportForm',
    templateUrl: './ForensicMedicalReportForm.html',
    providers: [MessageService]
})
export class ForensicMedicalReportForm extends EpisodeActionForm implements OnInit, IModal {
    Abdominal: TTVisual.ITTCheckBox;
    AddedReportsAndDocumantation: TTVisual.ITTTabPage;
    AddedReportsAndDocumantationNote1: TTVisual.ITTLabel;
    AddedReportsAndDocumantationNote2: TTVisual.ITTLabel;
    ArterialBloodPresure: TTVisual.ITTTextBox;
    Attaches1: TTVisual.ITTCheckBox;
    Attaches2: TTVisual.ITTCheckBox;
    Attaches2Text: TTVisual.ITTTextBox;
    Attaches3: TTVisual.ITTCheckBox;
    Attaches3Text1: TTVisual.ITTTextBox;
    Attaches3Text2: TTVisual.ITTTextBox;
    Attaches4: TTVisual.ITTCheckBox;
    Attaches5: TTVisual.ITTTextBox;
    Awareness: TTVisual.ITTEnumComboBox;
    AttendantNameSurname: TTVisual.ITTTextBox;
    labelAttendantNameSurname: TTVisual.ITTLabel;
    Back: TTVisual.ITTCheckBox;
    CardiovascularSystem: TTVisual.ITTCheckBox;
    CentralNervousSystem: TTVisual.ITTCheckBox;
    CertainReport: TTVisual.ITTCheckBox;
    Chest: TTVisual.ITTCheckBox;
    ChkBiopsy: TTVisual.ITTCheckBox;
    ChkBTMR: TTVisual.ITTCheckBox;
    ChkDirectGraph: TTVisual.ITTCheckBox;
    ChkLabProcedures: TTVisual.ITTCheckBox;
    ChkOther: TTVisual.ITTCheckBox;
    ChkUltrasonography: TTVisual.ITTCheckBox;
    ClothesOfPatient1: TTVisual.ITTCheckBox;
    ClothesOfPatient2: TTVisual.ITTCheckBox;
    ClothesOfPatient3: TTVisual.ITTCheckBox;
    ComplaintEpisode: TTVisual.ITTRichTextBoxControl;
    DigestiveSys: TTVisual.ITTCheckBox;
    DocumentNumber: TTVisual.ITTTextBox;
    DocumetDate: TTVisual.ITTDateTimePicker;
    EventHistoryNote: TTVisual.ITTLabel;
    EventInfo: TTVisual.ITTTabPage;
    EventInfoNote: TTVisual.ITTLabel;
    ExaminationConditions: TTVisual.ITTTabPage;
    ExaminationConditionsNote: TTVisual.ITTLabel;
    Explanation1: TTVisual.ITTTextBox;
    Explanation2: TTVisual.ITTTextBox;
    FindingsOfExamination: TTVisual.ITTTabPage;
    FindingsOfExamination2: TTVisual.ITTLabel;
    FindingsOfExaminationNote: TTVisual.ITTLabel;
    FindingsOnLesions: TTVisual.ITTTabPage;
    FindingsOnLesionsNote: TTVisual.ITTLabel;
    GeneralConditionOfPatient: TTVisual.ITTEnumComboBox;
    GenitalArea: TTVisual.ITTCheckBox;
    HeadNeck: TTVisual.ITTCheckBox;
    HealthCommitteeStartDateEpisode: TTVisual.ITTDateTimePicker;
    HistoryOfEvent: TTVisual.ITTTextBox;
    labelArterialBloodPresure: TTVisual.ITTLabel;
    labelAwareness: TTVisual.ITTLabel;
    labelBeingPeopleInExamination1: TTVisual.ITTLabel;
    labelClothesOfPatient: TTVisual.ITTLabel;
    labelGeneralConditionOfPatient: TTVisual.ITTLabel;
    labelHealthCommitteeStartDateEpisode: TTVisual.ITTLabel;
    labelHistoryOfEvent: TTVisual.ITTLabel;
    labelJudicialDate: TTVisual.ITTLabel;
    labelJudicialNo: TTVisual.ITTLabel;
    labelLightReflex: TTVisual.ITTLabel;
    labelMedicalHistory: TTVisual.ITTLabel;
    labelPatientComplaints: TTVisual.ITTLabel;
    labelPatientIdentity: TTVisual.ITTLabel;
    labelPatientIdentityNote: TTVisual.ITTLabel;
    labelPermissionDepartment: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    labelPulse: TTVisual.ITTLabel;
    labelPupilProperties: TTVisual.ITTLabel;
    labelReasonExaminationReportType: TTVisual.ITTLabel;
    labelReportNo: TTVisual.ITTLabel;
    LabelRequestDate: TTVisual.ITTLabel;
    labelRespitory: TTVisual.ITTLabel;
    labelResUser: TTVisual.ITTLabel;
    labelSenderChair: TTVisual.ITTLabel;
    labelSuitableEnvirement: TTVisual.ITTLabel;
    labelSuitableEnvirNote: TTVisual.ITTLabel;
    labelTendonReflexes: TTVisual.ITTLabel;
    LightReflex: TTVisual.ITTEnumComboBox;
    LowerExtremity: TTVisual.ITTCheckBox;
    Minutes: TTVisual.ITTLabel;
    mmHg: TTVisual.ITTLabel;
    Need: TTVisual.ITTCheckBox;
    NoEvidancePsycho: TTVisual.ITTCheckBox;
    NoNeed: TTVisual.ITTCheckBox;
    OtherReasonExamination: TTVisual.ITTTextBox;
    PatientHistoryEpisode: TTVisual.ITTRichTextBoxControl;
    PatientIdentity: TTVisual.ITTTextBox;
    PeopleInExamination1: TTVisual.ITTCheckBox;
    PeopleInExamination2: TTVisual.ITTCheckBox;
    PeopleInExamination3: TTVisual.ITTCheckBox;
    PeopleInExamination4: TTVisual.ITTCheckBox;
    PermissionDepartment: TTVisual.ITTEnumComboBox;
    ReportType: TTVisual.ITTEnumComboBox;
    PropertiesOfLesions: TTVisual.ITTTextBox;
    ProtocolNo: TTVisual.ITTTextBox;
    PsychiatricConsultation: TTVisual.ITTCheckBox;
    PsychiatricExamination: TTVisual.ITTTabPage;
    PsychiatricExamination2: TTVisual.ITTLabel;
    PsychiatricExamination3: TTVisual.ITTLabel;
    PsychiatricExaminationNote1: TTVisual.ITTLabel;
    Pulse: TTVisual.ITTTextBox;
    PupilProperties: TTVisual.ITTEnumComboBox;
    PyschiatricExamination: TTVisual.ITTCheckBox;
    ReasonExaminationReportType: TTVisual.ITTEnumComboBox;
    Report: TTVisual.ITTRichTextBoxControl;
    ReportNo: TTVisual.ITTTextBox;
    RequestDate: TTVisual.ITTDateTimePicker;
    ResonOfDispatch: TTVisual.ITTTextBox;
    RespiratorySys: TTVisual.ITTCheckBox;
    Respitory: TTVisual.ITTEnumComboBox;
    Result: TTVisual.ITTTabPage;
    ResultNote1: TTVisual.ITTLabel;
    ResultNote2: TTVisual.ITTLabel;
    rtfProcedures: TTVisual.ITTRichTextBoxControl;
    SenderChair: TTVisual.ITTObjectListBox;
    SensoryOrgansSys: TTVisual.ITTCheckBox;
    SkeletalSys: TTVisual.ITTCheckBox;
    SuitableEnvironment1: TTVisual.ITTCheckBox;
    SuitableEnvironment2: TTVisual.ITTCheckBox;
    SystemExaminations: TTVisual.ITTTabPage;
    SystemExaminationsNote: TTVisual.ITTLabel;
    SystemFindings: TTVisual.ITTTextBox;
    TendonReflexes: TTVisual.ITTEnumComboBox;
    Test: TTVisual.ITTTabPage;
    TestsNote: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    ttpictureboxcontrol: TTVisual.ITTPictureBoxControl;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabcontrol2: TTVisual.ITTTabControl;
    UncertainReport: TTVisual.ITTCheckBox;
    UpperExtrimity: TTVisual.ITTCheckBox;
    UrogenitalSys: TTVisual.ITTCheckBox;

    public _suitableEnvironment: string[ ] = ["Evet","Hayır"];
    public _CertainReportDisabled = false;
    public _UncertainReportDisabled = false;
    public _NoNeedDisabled = false;
    public _NeedDisabled = false;
    public _isReadOnly = false;
    public _isReportCompleted = false;
    public _buttonCaption :string = "Yazdır";
    public _buttonIcon: string = "fa fa-print";

    public forensicMedicalReportFormViewModel: ForensicMedicalReportFormViewModel = new ForensicMedicalReportFormViewModel();
    public get _ForensicMedicalReport(): ForensicMedicalReport {
        return this._TTObject as ForensicMedicalReport;
    }
    private ForensicMedicalReportForm_DocumentUrl: string = '/api/ForensicMedicalReportService/ForensicMedicalReportForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone, protected modalStateService: ModalStateService,protected modalService: IModalService,) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ForensicMedicalReportForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }
    public _inputParam: Object;
  
    setInputParam(value: string) {
     
        
    }

    protected _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    // ***** Method declarations start *****

    private async Attaches4_CheckedChanged(): Promise<void> {
        if (this.Attaches4.Value === true) {
            this.Attaches5.Enabled = true;
            this.Attaches5.Required = true;
        }
        else {
            this.Attaches5.Text = null;
            this.Attaches5.Enabled = false;
            this.Attaches5.Required = false;
        }
    }
    private async ForensicReportType_SelectedIndexChanged(): Promise<void> {
        this.InitializeStateButton();
    }
    private async Need_CheckedChanged(): Promise<void> {
        if (this.Need.Value === true) {
            this.ResonOfDispatch.Enabled = true;
            this.ResonOfDispatch.Required = true;
            this.NoNeed.Value = false;
        }
        else {
            this.ResonOfDispatch.Text = null;
            this.ResonOfDispatch.Enabled = false;
            this.ResonOfDispatch.Required = false;
        }
    }
    private async NoEvidancePsycho_CheckedChanged(): Promise<void> {
        if (this.NoEvidancePsycho.Value === true) {
            this.PyschiatricExamination.Value = false;
            this.PsychiatricConsultation.Value = false;
        }
    }
    private async NoNeed_CheckedChanged(): Promise<void> {
        if (this.NoNeed.Value === true) {
            this.Need.Value = false;
        }
    }
    private async OtherReasonExamination_TextChanged(): Promise<void> {

    }
    private async PsychiatricConsultation_CheckedChanged(): Promise<void> {
        if (this.PsychiatricConsultation.Value === true) {
            this.NoEvidancePsycho.Value = false;
            this.PyschiatricExamination.Value = false;
        }
    }
    private async PyschiatricExamination_CheckedChanged(): Promise<void> {
        if (this.PyschiatricExamination.Value === true) {
            this.NoEvidancePsycho.Value = false;
            this.PsychiatricConsultation.Value = false;
        }
    }
    private async ReasonExaminationReportType_SelectedIndexChanged(): Promise<void> {
        if (this._ForensicMedicalReport.ReasonExaminationReportType.Value === ReasonExaminationTypeEnum.Others) {
            this.OtherReasonExamination.Enabled = true;
            this.OtherReasonExamination.Required = true;
        }
        else {
            this.OtherReasonExamination.Text = null;
            this.OtherReasonExamination.Enabled = false;
            this.OtherReasonExamination.Required = false;
        }
    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);

        if (transDef !== null && transDef.ToStateDefID !== null && transDef.ToStateDefID !== undefined) {
            if (transDef.ToStateDefID.valueOf() == ForensicMedicalReport.ForensicMedicalReportStates.Completed.id) {

                this.openForensicMedicalReport(this.forensicMedicalReportFormViewModel._ForensicMedicalReport.ObjectID);
            }
        }
        /*if (transDef !== null && transDef.ToStateDefID === ForensicMedicalReport.ForensicMedicalReportStates.Completed) {
            let parameter: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
            let objectID: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
            objectID.push('VALUE', this._ForensicMedicalReport.ObjectID.toString());
            parameter.push('TTOBJECTID', objectID);
            // if(this._ForensicMedicalReport.ForensicMedicalReportType == ForensicMedicalReportTypeEnum.Uncertain)
            // TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_TemporaryForensicReport), true, 1, parameter);
            // else if (this._ForensicMedicalReport.ForensicMedicalReportType == ForensicMedicalReportTypeEnum.Certain)
            //TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_TemporaryForensicReport), true, 1, parameter);



            //hastanın var olan konsültasyon raporlarının da yazdırlması
            let context: TTObjectContext = new TTObjectContext(true);
            let episode: Guid = new Guid();
            episode = this._ForensicMedicalReport.Episode.ObjectID;
            let consultationProcedures: Array<any> = (await ConsultationProcedureService.GetConsultationProcedureByEpisode(context, episode));
            for (let cp of consultationProcedures) {
                let parameter2: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
                let objectID2: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
                objectID2.push('VALUE', cp.ObjectID.toString());
                parameter2.push('TTOBJECTID', objectID2);
                TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_ConsultationProcedureReport, true, 1, parameter2);
            }
        }*/
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);

        



    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
       
    }

openForensicMedicalReport(ObjectID:any): Promise<ModalActionResult>
{
    let reportData: DynamicReportParameters = {

        Code: 'ADLIVAKA',
        ReportParams: { ObjectID: ObjectID.toString() },
        ViewerMode: true
    };

    return new Promise((resolve, reject) => {

        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'HvlDynamicReportComponent';
        componentInfo.ModuleName = 'DevexpressReportingModule';
        componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
        componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(this._ForensicMedicalReport.ObjectID, null, null));

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = "ADLİ VAKA FORMU"

        modalInfo.fullScreen = true;

        let result = this.modalService.create(componentInfo, modalInfo);
        result.then(inner => {
            resolve(inner);
        }).catch(err => {
            reject(err);
        });
    });
}

    protected async PreScript(): Promise<void> {
        super.PreScript();

        if (this._ForensicMedicalReport.CurrentStateDefID != null && this._ForensicMedicalReport.CurrentStateDefID == ForensicMedicalReport.ForensicMedicalReportStates.Completed) {
            this._isReportCompleted = true;
        }

        //this.OtherReasonExamination.Enabled = false;
        //this.ResonOfDispatch.Enabled = false;
        //this.Attaches5.Enabled = false;
        //this.InitializeStateButton();
        //this.SetProcedureDoctorAsCurrentResource();
        //if (this._ForensicMedicalReport.CurrentStateDefID !== null && this._ForensicMedicalReport.CurrentStateDefID.Value.Equals(ForensicMedicalReport.ForensicMedicalReportStates.ReportEntry)) {

        //}
        ////            if(this._ForensicMedicalReport.CurrentStateDefID != null && this._ForensicMedicalReport.CurrentStateDefID.Value.Equals(ForensicMedicalReport.States.Completed))
        ////            {
        ////                if(this._ForensicMedicalReport.ForensicMedicalReportType ==ForensicMedicalReportTypeEnum.Uncertain)
        ////                {
        ////                    this.DropCurrentStateReport(typeof(TTReportClasses.I_TemporaryForensicReport));
        ////                }
        ////                else if(this._ForensicMedicalReport.ForensicMedicalReportType == ForensicMedicalReportTypeEnum.Certain)
        ////                {
        ////                    this.DropCurrentStateReport(typeof(TTReportClasses.I_TemporaryForensicReport));
        ////                }
        ////                
        ////            }
        ///******************bu kysym silinecek. test amaçly konuldu.******///o halde silindi...YY
        ////            if (_ForensicMedicalReport.Episode == null)
        ////            {
        ////                TTObjectContext con = _ForensicMedicalReport.ObjectContext;
        ////                IList episodes = con.QueryObjects("Episode");
        ////                if (episodes.Count == 0)
        ////                    throw new TTException("Episode bulunamady.");
        ////                _ForensicMedicalReport.Episode = (Episode)episodes[0];
        ////            }
        ///***************************************************************/
        ////CopyToE  Episodedaki Evrak Sayısı, Evrak Tarihi ve  Muayeneye Gönderen Makam Class propertylerine atılır
        //if (this._ForensicMedicalReport.DocumentDate === null) {
        //    this._ForensicMedicalReport.DocumentDate = this._ForensicMedicalReport.Episode.DocumentDate;
        //}
        //if (String.isNullOrEmpty(this._ForensicMedicalReport.DocumentNumber)) {
        //    this._ForensicMedicalReport.DocumentNumber = this._ForensicMedicalReport.Episode.DocumentNumber;
        //}
        ////            if (_ForensicMedicalReport.SenderChair == null)
        ////            {
        ////                _ForensicMedicalReport.SenderChair = _ForensicMedicalReport.Episode.SenderChair;
        ////            }
        ////todo bg
        ///*
        //            if (this._ForensicMedicalReport.SubEpisode.PatientAdmission.AdmissionType.Value == AdmissionTypeEnum.MaterialAdmission)
        //            {
        //                this.Report.DisplayText="Materyal Sonuç";
        //                this.labelMaterialSendDate.Visible=true;
        //                this.MaterialSendDate.Visible=true;
        //                this.labelMaterialSender.Visible=true;
        //                this.MaterialSender.Visible=true;
        //            }
        //            else*/



        ////Muayene Buluguları ve Muayene Özeti

        //if (this._ForensicMedicalReport.Episode !== null && this._ForensicMedicalReport.Episode.PhysicalExamination !== null) {
        //    this.PropertiesOfLesions.Text = (await CommonService.GetTextOfRTFString(this._ForensicMedicalReport.Episode.PhysicalExamination.toString())) + '\r\n';
        //}
        //if (this._ForensicMedicalReport.Episode !== null && this._ForensicMedicalReport.Episode.ExaminationSummary !== null) {
        //    this.PropertiesOfLesions.Text += (await CommonService.GetTextOfRTFString(this._ForensicMedicalReport.Episode.ExaminationSummary.toString())) + '\r\n';
        //}
        ////TETKİKLER
        //let context: TTObjectContext = new TTObjectContext(true);
        //let EPISODE: Guid = new Guid();
        //EPISODE = this._ForensicMedicalReport.Episode.ObjectID;
        //let labProcedureList: Array<TTObjectClasses.LaboratoryProcedure> = (await LaboratoryProcedureService.GetLabProceduresByEpisode(context, EPISODE));
        //if (labProcedureList.length > 0) {
        //    let builder: StringBuilder = new StringBuilder();
        //    for (let labProc of labProcedureList) {
        //        builder.append(Convert.ToDateTime(labProc.ActionDate).ToShortDateString() + ' ');
        //        builder.append(labProc.ProcedureObject.Name + ' ');
        //        builder.append('(' + labProc.ProcedureObject.SUTCode + ') ');
        //        if (labProc.Result !== null && labProc.Result !== '') {
        //            builder.append(':' + labProc.Result + ' ');
        //            builder.append(labProc.Unit + ' ');
        //            if (labProc.Warning !== null)
        //                builder.append((await CommonService.GetDisplayTextOfDataTypeEnum(labProc.Warning.Value)));
        //        }
        //        if (labProc.LaboratorySubProcedures.length > 0) {
        //            builder.append('(');
        //            for (let subLabProc of labProc.LaboratorySubProcedures) {
        //                builder.append(subLabProc.ProcedureObject.Name + ' ');
        //                builder.append('(' + subLabProc.ProcedureObject.SUTCode + ') ');
        //                if (subLabProc.Result !== null && subLabProc.Result !== '') {
        //                    builder.append(':' + subLabProc.Result + ' ');
        //                    builder.append(subLabProc.Unit + ' ');
        //                    if (subLabProc.Warning !== null)
        //                        builder.append((await CommonService.GetDisplayTextOfDataTypeEnum(subLabProc.Warning.Value)));
        //                    builder.append(',');
        //                }
        //            }
        //            builder.append(')');
        //        }
        //        builder.append(', ');
        //    }
        //    this.rtfProcedures.Text = 'LABORATUVAR TETKİKLERİ:' + '\r\n';
        //    this.rtfProcedures.Text += builder.toString() + '\r\n';
        //}
        //this.rtfProcedures.Text += 'RADYOLOJİ TETKİKLERİ:' + '\r\n'; 

    }
    public async InitializeStateButton(): Promise<void> {

    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ForensicMedicalReport();
        this.forensicMedicalReportFormViewModel = new ForensicMedicalReportFormViewModel();
        this._ViewModel = this.forensicMedicalReportFormViewModel;
        this.forensicMedicalReportFormViewModel._ForensicMedicalReport = this._TTObject as ForensicMedicalReport;
        this.forensicMedicalReportFormViewModel._ForensicMedicalReport.Episode = new Episode();
        this.forensicMedicalReportFormViewModel._ForensicMedicalReport.SenderChair = new MilitaryUnit();
        this.forensicMedicalReportFormViewModel._ForensicMedicalReport.ProcedureDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.forensicMedicalReportFormViewModel = this._ViewModel as ForensicMedicalReportFormViewModel;
        that._TTObject = this.forensicMedicalReportFormViewModel._ForensicMedicalReport;
        if (this.forensicMedicalReportFormViewModel == null)
            this.forensicMedicalReportFormViewModel = new ForensicMedicalReportFormViewModel();
        if (this.forensicMedicalReportFormViewModel._ForensicMedicalReport == null)
            this.forensicMedicalReportFormViewModel._ForensicMedicalReport = new ForensicMedicalReport();
        let episodeObjectID = that.forensicMedicalReportFormViewModel._ForensicMedicalReport["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.forensicMedicalReportFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.forensicMedicalReportFormViewModel._ForensicMedicalReport.Episode = episode;
            }
        }


        let senderChairObjectID = that.forensicMedicalReportFormViewModel._ForensicMedicalReport["SenderChair"];
        if (senderChairObjectID != null && (typeof senderChairObjectID === "string")) {
            let senderChair = that.forensicMedicalReportFormViewModel.MilitaryUnits.find(o => o.ObjectID.toString() === senderChairObjectID.toString());
            if (senderChair) {
                that.forensicMedicalReportFormViewModel._ForensicMedicalReport.SenderChair = senderChair;
            }
        }


        let procedureDoctorObjectID = that.forensicMedicalReportFormViewModel._ForensicMedicalReport["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.forensicMedicalReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.forensicMedicalReportFormViewModel._ForensicMedicalReport.ProcedureDoctor = procedureDoctor;
            }
        }

        if(this.forensicMedicalReportFormViewModel._ForensicMedicalReport.CurrentStateDefID == ForensicMedicalReport.ForensicMedicalReportStates.Completed){
            this.ReadOnly = true;
            this._ViewModel.ReadOnly = true;
            this._isReadOnly = true;
        }

    }



    async ngOnInit() {
        await this.load(ForensicMedicalReportFormViewModel);
    }

    

    public onAttaches5Changed(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.Attaches5 != event) {
            this._ForensicMedicalReport.Attaches5 = event;
        }
    }

    public onAwarenessChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.Awareness != event) {
            this._ForensicMedicalReport.Awareness = event;
        }
    }

    public onBackChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.Back != event) {
            this._ForensicMedicalReport.Back = event;
        }
    }

    public onCardiovascularSystemChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.CardiovascularSystem != event) {
            this._ForensicMedicalReport.CardiovascularSystem = event;
        }
    }

 


    public onComplaintEpisodeChanged(event): void {
        // if(this._ForensicMedicalReport != null &&
        //this._ForensicMedicalReport.Episode != null && this._ForensicMedicalReport.Episode.Complaint != event) { 
        //this._ForensicMedicalReport.Episode.Complaint = event;
        //}
    }




    public onGeneralConditionOfPatientChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.GeneralConditionOfPatient != event) {
            this._ForensicMedicalReport.GeneralConditionOfPatient = event;
        }
    }

    public onGenitalAreaChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.GenitalArea != event) {
            this._ForensicMedicalReport.GenitalArea = event;
        }
    }

   

    public onLightReflexChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.LightReflex != event) {
            this._ForensicMedicalReport.LightReflex = event;
        }
    }

    

    public onPatientHistoryEpisodeChanged(event): void {
        if (this._ForensicMedicalReport != null &&
            this._ForensicMedicalReport.Episode != null && this._ForensicMedicalReport.Episode.PatientHistory != event) {
            this._ForensicMedicalReport.Episode.PatientHistory = event;
        }
    }



    public onPermissionDepartmentChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.PermissionDepartment != event) {
            this._ForensicMedicalReport.PermissionDepartment = event;
        }
    }

    public onReportTypeChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.ReportType != event) {
            this._ForensicMedicalReport.ReportType = event;
        }
    }

    public onAttendantNameSurnameChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.AttendantNameSurname != event) {
            this._ForensicMedicalReport.AttendantNameSurname = event;
        }
    }



    public onPupilPropertiesChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.PupilProperties != event) {
            this._ForensicMedicalReport.PupilProperties = event;
        }
    }



    public onReasonExaminationReportTypeChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.ReasonExaminationReportType != event) {
            this._ForensicMedicalReport.ReasonExaminationReportType = event;
        }
    }

    public onReportChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.Report != event) {
            this._ForensicMedicalReport.Report = event;
        }
    }


    public onRespitoryChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.Respitory != event) {
            this._ForensicMedicalReport.Respitory = event;
        }
    }

    public onrtfProceduresChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.LaboratoryProcedures != event) {
            this._ForensicMedicalReport.LaboratoryProcedures = event;
        }
    }

    public onSenderChairChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.SenderChair != event) {
            this._ForensicMedicalReport.SenderChair = event;
        }
    }

    // public onSensoryOrgansSysChanged(event): void {
    //     if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.SensoryOrgansSys != event) {
    //         this._ForensicMedicalReport.SensoryOrgansSys = event;
    //     }
    // }

    // public onSkeletalSysChanged(event): void {
    //     if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.SkeletalSys != event) {
    //         this._ForensicMedicalReport.SkeletalSys = event;
    //     }
    // }

    public onSuitableEnvironment1Changed(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.SuitableEnvironment1 != event) {
            this._ForensicMedicalReport.SuitableEnvironment1 = event;
        }
    }

    public onSuitableEnvironment2Changed(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.SuitableEnvironment2 != event) {
            this._ForensicMedicalReport.SuitableEnvironment2 = event;
        }
    }

    // public onSystemFindingsChanged(event): void {
    //     if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.SystemFindings != event) {
    //         this._ForensicMedicalReport.SystemFindings = event;
    //     }
    // }

    public onTendonReflexesChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.TendonReflexes != event) {
            this._ForensicMedicalReport.TendonReflexes = event;
        }
    }

    public onttobjectlistbox1Changed(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.ProcedureDoctor != event) {
            this._ForensicMedicalReport.ProcedureDoctor = event;
        }
    }

    // public onUncertainReportChanged(event): void {
    //     if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.UncertainReport != event) {
    //         this._ForensicMedicalReport.UncertainReport = event;
    //     }
    // }

    public onUpperExtrimityChanged(event): void {
        if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.UpperExtrimity != event) {
            this._ForensicMedicalReport.UpperExtrimity = event;
        }
    }

    // public onUrogenitalSysChanged(event): void {
    //     if (this._ForensicMedicalReport != null && this._ForensicMedicalReport.UrogenitalSys != event) {
    //         this._ForensicMedicalReport.UrogenitalSys = event;
    //     }
    // }



    protected redirectProperties(): void {
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "RequestDate");
        redirectProperty(this.ReportNo, "Text", this.__ttObject, "ReportNo");
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.PermissionDepartment, "Value", this.__ttObject, "PermissionDepartment");
        redirectProperty(this.ReportType, "Value", this.__ttObject, "ReportType");
        redirectProperty(this.DocumetDate, "Value", this.__ttObject, "DocumentDate");
        redirectProperty(this.DocumentNumber, "Text", this.__ttObject, "DocumentNumber");
        redirectProperty(this.ReasonExaminationReportType, "Value", this.__ttObject, "ReasonExaminationReportType");
        redirectProperty(this.OtherReasonExamination, "Text", this.__ttObject, "OtherReasonExamination");
        redirectProperty(this.PatientIdentity, "Text", this.__ttObject, "PatientIdentity");
        redirectProperty(this.Explanation1, "Text", this.__ttObject, "Explanation1");
        redirectProperty(this.AttendantNameSurname, "Text", this.__ttObject, "AttendantNameSurname");
        redirectProperty(this.SuitableEnvironment1, "Value", this.__ttObject, "SuitableEnvironment1");
        redirectProperty(this.SuitableEnvironment2, "Value", this.__ttObject, "SuitableEnvironment2");
        redirectProperty(this.PeopleInExamination1, "Value", this.__ttObject, "PeopleInExamination1");
        redirectProperty(this.PeopleInExamination2, "Value", this.__ttObject, "PeopleInExamination2");
        redirectProperty(this.PeopleInExamination4, "Value", this.__ttObject, "PeopleInExamination4");
        redirectProperty(this.PeopleInExamination3, "Value", this.__ttObject, "PeopleInExamination3");
        redirectProperty(this.Explanation2, "Text", this.__ttObject, "Explanation2");
        redirectProperty(this.ClothesOfPatient1, "Value", this.__ttObject, "ClothesOfPatient1");
        redirectProperty(this.ClothesOfPatient2, "Value", this.__ttObject, "ClothesOfPatient2");
        redirectProperty(this.ClothesOfPatient3, "Value", this.__ttObject, "ClothesOfPatient3");
        redirectProperty(this.HistoryOfEvent, "Text", this.__ttObject, "HistoryOfEvent");
        redirectProperty(this.ComplaintEpisode, "Rtf", this.__ttObject, "Episode.Complaint");
        redirectProperty(this.PatientHistoryEpisode, "Rtf", this.__ttObject, "Episode.PatientHistory");
        redirectProperty(this.HealthCommitteeStartDateEpisode, "Value", this.__ttObject, "Episode.HealthCommitteeStartDate");
        redirectProperty(this.HeadNeck, "Value", this.__ttObject, "HeadNeck");
        redirectProperty(this.Chest, "Value", this.__ttObject, "Chest");
        redirectProperty(this.Abdominal, "Value", this.__ttObject, "Abdominal");
        redirectProperty(this.Back, "Value", this.__ttObject, "Back");
        redirectProperty(this.UpperExtrimity, "Value", this.__ttObject, "UpperExtrimity");
        redirectProperty(this.LowerExtremity, "Value", this.__ttObject, "LowerExtremity");
        redirectProperty(this.GenitalArea, "Value", this.__ttObject, "GenitalArea");
        redirectProperty(this.PropertiesOfLesions, "Text", this.__ttObject, "PropertiesOfLesions");
        redirectProperty(this.CentralNervousSystem, "Value", this.__ttObject, "CentralNervousSystem");
        redirectProperty(this.CardiovascularSystem, "Value", this.__ttObject, "CardiovascularSystem");
        redirectProperty(this.DigestiveSys, "Value", this.__ttObject, "DigestiveSys");
        redirectProperty(this.RespiratorySys, "Value", this.__ttObject, "RespiratorySys");
        redirectProperty(this.SkeletalSys, "Value", this.__ttObject, "SkeletalSys");
        redirectProperty(this.UrogenitalSys, "Value", this.__ttObject, "UrogenitalSys");
        redirectProperty(this.SensoryOrgansSys, "Value", this.__ttObject, "SensoryOrgansSys");
        redirectProperty(this.GeneralConditionOfPatient, "Value", this.__ttObject, "GeneralConditionOfPatient");
        redirectProperty(this.Awareness, "Value", this.__ttObject, "Awareness");
        redirectProperty(this.ArterialBloodPresure, "Text", this.__ttObject, "ArterialBloodPresure");
        redirectProperty(this.Pulse, "Text", this.__ttObject, "Pulse");
        redirectProperty(this.Respitory, "Value", this.__ttObject, "Respitory");
        redirectProperty(this.PupilProperties, "Value", this.__ttObject, "PupilProperties");
        redirectProperty(this.LightReflex, "Value", this.__ttObject, "LightReflex");
        redirectProperty(this.TendonReflexes, "Value", this.__ttObject, "TendonReflexes");
        redirectProperty(this.SystemFindings, "Text", this.__ttObject, "SystemFindings");
        redirectProperty(this.NoEvidancePsycho, "Value", this.__ttObject, "NoEvidancePsycho");
        redirectProperty(this.PyschiatricExamination, "Value", this.__ttObject, "PyschiatricExamination");
        redirectProperty(this.PsychiatricConsultation, "Value", this.__ttObject, "PsychiatricConsultation");
        redirectProperty(this.ChkLabProcedures, "Value", this.__ttObject, "ChkLabProcedures");
        redirectProperty(this.ChkDirectGraph, "Value", this.__ttObject, "ChkDirectGraph");
        redirectProperty(this.ChkBTMR, "Value", this.__ttObject, "ChkBTMR");
        redirectProperty(this.ChkUltrasonography, "Value", this.__ttObject, "ChkUltrasonography");
        redirectProperty(this.ChkBiopsy, "Value", this.__ttObject, "ChkBiopsy");
        redirectProperty(this.ChkOther, "Value", this.__ttObject, "ChkOther");
        redirectProperty(this.rtfProcedures, "Rtf", this.__ttObject, "LaboratoryProcedures");
        redirectProperty(this.Attaches1, "Value", this.__ttObject, "Attaches1");
        redirectProperty(this.Attaches4, "Value", this.__ttObject, "Attaches4");
        redirectProperty(this.Attaches5, "Text", this.__ttObject, "Attaches5");
        redirectProperty(this.Attaches2, "Value", this.__ttObject, "Attaches2");
        redirectProperty(this.Attaches2Text, "Text", this.__ttObject, "Attaches2Text");
        redirectProperty(this.Attaches3, "Value", this.__ttObject, "Attaches3");
        redirectProperty(this.Attaches3Text1, "Text", this.__ttObject, "Attaches3Text1");
        redirectProperty(this.Attaches3Text2, "Text", this.__ttObject, "Attaches3Text2");
        redirectProperty(this.NoNeed, "Value", this.__ttObject, "NoNeed");
        redirectProperty(this.CertainReport, "Value", this.__ttObject, "CertainReport");
        redirectProperty(this.Need, "Value", this.__ttObject, "Need");
        redirectProperty(this.UncertainReport, "Value", this.__ttObject, "UncertainReport");
        redirectProperty(this.Report, "Rtf", this.__ttObject, "Report");
        redirectProperty(this.ResonOfDispatch, "Text", this.__ttObject, "ResonOfDispatch");
    }

    public initFormControls(): void {
        this.labelAttendantNameSurname = new TTVisual.TTLabel();
        this.labelAttendantNameSurname.Text = "Eşlik Eden Görevlinin Adı Soyadı";
        this.labelAttendantNameSurname.Name = "labelAttendantNameSurname";
        this.labelAttendantNameSurname.TabIndex = 67;

        this.AttendantNameSurname = new TTVisual.TTTextBox();
        this.AttendantNameSurname.Name = "AttendantNameSurname";
        this.AttendantNameSurname.TabIndex = 66;

        this.PatientIdentity = new TTVisual.TTTextBox();
        this.PatientIdentity.Multiline = true;
        this.PatientIdentity.Name = "PatientIdentity";
        this.PatientIdentity.TabIndex = 11;

        this.OtherReasonExamination = new TTVisual.TTTextBox();
        this.OtherReasonExamination.Name = "OtherReasonExamination";
        this.OtherReasonExamination.TabIndex = 10;

        this.labelResUser = new TTVisual.TTLabel();
        this.labelResUser.Text = "Sorumlu Kişi";
        this.labelResUser.Name = "labelResUser";
        this.labelResUser.TabIndex = 65;

        this.labelPermissionDepartment = new TTVisual.TTLabel();
        this.labelPermissionDepartment.Text = "Raporun İstendiği Makam";
        this.labelPermissionDepartment.Name = "labelPermissionDepartment";
        this.labelPermissionDepartment.TabIndex = 61;

        this.PermissionDepartment = new TTVisual.TTEnumComboBox();
        this.PermissionDepartment.DataTypeName = "PemissionDepartmentEnum";
        this.PermissionDepartment.Name = "PermissionDepartment";
        this.PermissionDepartment.TabIndex = 4;

        this.ReportType = new TTVisual.TTEnumComboBox();
        this.ReportType.DataTypeName = "MedicalReportTypeEnum";
        this.ReportType.Name = "ReportType";
        this.ReportType.TabIndex = 4;

        this.labelPatientIdentity = new TTVisual.TTLabel();
        this.labelPatientIdentity.Text = "Muayene Edilenin Tıbbi Kimliği";
        this.labelPatientIdentity.Name = "labelPatientIdentity";
        this.labelPatientIdentity.TabIndex = 59;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 56;

        this.ExaminationConditions = new TTVisual.TTTabPage();
        this.ExaminationConditions.DisplayIndex = 0;
        this.ExaminationConditions.TabIndex = 0;
        this.ExaminationConditions.Text = "Muayene Koşulları";
        this.ExaminationConditions.Name = "ExaminationConditions";

        this.ClothesOfPatient3 = new TTVisual.TTCheckBox();
        this.ClothesOfPatient3.Value = false;
        this.ClothesOfPatient3.Text = "Çıkartılmadı";
        this.ClothesOfPatient3.Name = "ClothesOfPatient3";
        this.ClothesOfPatient3.TabIndex = 24;

        this.ClothesOfPatient2 = new TTVisual.TTCheckBox();
        this.ClothesOfPatient2.Value = false;
        this.ClothesOfPatient2.Text = "Kısmen çıkartıldı";
        this.ClothesOfPatient2.Name = "ClothesOfPatient2";
        this.ClothesOfPatient2.TabIndex = 23;

        this.ClothesOfPatient1 = new TTVisual.TTCheckBox();
        this.ClothesOfPatient1.Value = false;
        this.ClothesOfPatient1.Text = "Tamamen çıkartıldı";
        this.ClothesOfPatient1.Name = "ClothesOfPatient1";
        this.ClothesOfPatient1.TabIndex = 22;

        this.PeopleInExamination4 = new TTVisual.TTCheckBox();
        this.PeopleInExamination4.Value = false;
        this.PeopleInExamination4.Text = "Muayene edilenin müdafii";
        this.PeopleInExamination4.Name = "PeopleInExamination4";
        this.PeopleInExamination4.TabIndex = 21;

        this.PeopleInExamination3 = new TTVisual.TTCheckBox();
        this.PeopleInExamination3.Value = false;
        this.PeopleInExamination3.Text = "Sağlık mesleği mensubu personel";
        this.PeopleInExamination3.Name = "PeopleInExamination3";
        this.PeopleInExamination3.TabIndex = 20;

        this.PeopleInExamination2 = new TTVisual.TTCheckBox();
        this.PeopleInExamination2.Value = false;
        this.PeopleInExamination2.Text = "Güvenlik Görevlisi";
        this.PeopleInExamination2.Name = "PeopleInExamination2";
        this.PeopleInExamination2.TabIndex = 19;

        this.PeopleInExamination1 = new TTVisual.TTCheckBox();
        this.PeopleInExamination1.Value = false;
        this.PeopleInExamination1.Text = "Tabip ve muayene edilen";
        this.PeopleInExamination1.Name = "PeopleInExamination1";
        this.PeopleInExamination1.TabIndex = 18;

        this.SuitableEnvironment2 = new TTVisual.TTCheckBox();
        this.SuitableEnvironment2.Value = false;
        this.SuitableEnvironment2.Text = "Hayır";
        this.SuitableEnvironment2.Name = "SuitableEnvironment2";
        this.SuitableEnvironment2.TabIndex = 17;

        this.SuitableEnvironment1 = new TTVisual.TTCheckBox();
        this.SuitableEnvironment1.Value = false;
        this.SuitableEnvironment1.Text = "Evet";
        this.SuitableEnvironment1.Name = "SuitableEnvironment1";
        this.SuitableEnvironment1.TabIndex = 16;

        this.Explanation2 = new TTVisual.TTTextBox();
        this.Explanation2.Multiline = true;
        this.Explanation2.Name = "Explanation2";
        this.Explanation2.TabIndex = 15;

        this.Explanation1 = new TTVisual.TTTextBox();
        this.Explanation1.Multiline = true;
        this.Explanation1.Name = "Explanation1";
        this.Explanation1.TabIndex = 13;

        this.ExaminationConditionsNote = new TTVisual.TTLabel();
        this.ExaminationConditionsNote.Text = "Bu bölümüi gözaltı işlemi ve insan hakları ihlali iddiası nedeniyle muayeneye getirilen kişiler için mutlaka doldurunuz.";
        this.ExaminationConditionsNote.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ExaminationConditionsNote.ForeColor = "#B22222";
        this.ExaminationConditionsNote.Name = "ExaminationConditionsNote";
        this.ExaminationConditionsNote.TabIndex = 12;

        this.labelSuitableEnvirNote = new TTVisual.TTLabel();
        this.labelSuitableEnvirNote.Text = "Açıklamalar";
        this.labelSuitableEnvirNote.Name = "labelSuitableEnvirNote";
        this.labelSuitableEnvirNote.TabIndex = 9;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "Açıklamalar";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 8;

        this.labelSuitableEnvirement = new TTVisual.TTLabel();
        this.labelSuitableEnvirement.Text = "Uygun ortam sağlandı mı?";
        this.labelSuitableEnvirement.Name = "labelSuitableEnvirement";
        this.labelSuitableEnvirement.TabIndex = 7;

        this.labelClothesOfPatient = new TTVisual.TTLabel();
        this.labelClothesOfPatient.Text = "Muayene edilenin giysileri";
        this.labelClothesOfPatient.Name = "labelClothesOfPatient";
        this.labelClothesOfPatient.TabIndex = 5;

        this.labelBeingPeopleInExamination1 = new TTVisual.TTLabel();
        this.labelBeingPeopleInExamination1.Text = "Muayene sırasında bulunan kişiler";
        this.labelBeingPeopleInExamination1.Name = "labelBeingPeopleInExamination1";
        this.labelBeingPeopleInExamination1.TabIndex = 1;

        this.EventInfo = new TTVisual.TTTabPage();
        this.EventInfo.DisplayIndex = 1;
        this.EventInfo.TabIndex = 1;
        this.EventInfo.Text = "Muayeneye Esas Olayla İlgili Bilgiler";
        this.EventInfo.Name = "EventInfo";

        this.HistoryOfEvent = new TTVisual.TTTextBox();
        this.HistoryOfEvent.Multiline = true;
        this.HistoryOfEvent.Name = "HistoryOfEvent";
        this.HistoryOfEvent.TabIndex = 16;

        this.PatientHistoryEpisode = new TTVisual.TTRichTextBoxControl();
        this.PatientHistoryEpisode.Name = "PatientHistoryEpisode";
        this.PatientHistoryEpisode.TabIndex = 15;

        this.ComplaintEpisode = new TTVisual.TTRichTextBoxControl();
        this.ComplaintEpisode.Name = "ComplaintEpisode";
        this.ComplaintEpisode.TabIndex = 14;

        this.labelMedicalHistory = new TTVisual.TTLabel();
        this.labelMedicalHistory.Text = "Hastanın Tıbbi Özgeçmişi";
        this.labelMedicalHistory.Name = "labelMedicalHistory";
        this.labelMedicalHistory.TabIndex = 13;

        this.labelPatientComplaints = new TTVisual.TTLabel();
        this.labelPatientComplaints.Text = "Muayene Edilenin Şikayetleri";
        this.labelPatientComplaints.Name = "labelPatientComplaints";
        this.labelPatientComplaints.TabIndex = 11;

        this.EventInfoNote = new TTVisual.TTLabel();
        this.EventInfoNote.Text = "Bu bölümdeki bilgileri, muayeneye getirilen kişinin ifadelerine göre doldurunuz.";
        this.EventInfoNote.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.EventInfoNote.ForeColor = "#B22222";
        this.EventInfoNote.Name = "EventInfoNote";
        this.EventInfoNote.TabIndex = 9;

        this.EventHistoryNote = new TTVisual.TTLabel();
        this.EventHistoryNote.Text = "(Tarih ve saat bilgilerini belirtmeyi unutmayınız)";
        this.EventHistoryNote.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.EventHistoryNote.Name = "EventHistoryNote";
        this.EventHistoryNote.TabIndex = 8;

        this.labelHistoryOfEvent = new TTVisual.TTLabel();
        this.labelHistoryOfEvent.Text = "Olayın Öyküsü ";
        this.labelHistoryOfEvent.Name = "labelHistoryOfEvent";
        this.labelHistoryOfEvent.TabIndex = 7;

        this.FindingsOfExamination = new TTVisual.TTTabPage();
        this.FindingsOfExamination.DisplayIndex = 2;
        this.FindingsOfExamination.TabIndex = 3;
        this.FindingsOfExamination.Text = "Muayene Bulguları";
        this.FindingsOfExamination.Name = "FindingsOfExamination";

        this.FindingsOfExamination2 = new TTVisual.TTLabel();
        this.FindingsOfExamination2.Text = "görülenleri yapınız ve ilgili kısmı doldurunuz.";
        this.FindingsOfExamination2.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.FindingsOfExamination2.ForeColor = "#B22222";
        this.FindingsOfExamination2.Name = "FindingsOfExamination2";
        this.FindingsOfExamination2.TabIndex = 4;

        this.FindingsOfExaminationNote = new TTVisual.TTLabel();
        this.FindingsOfExaminationNote.Text = "Bu bölümde, bütün kısımların doldurulması gerekmemektedir. Olaya, iddiaya, talebe ve muayene bulgulalrına göre gerekli";
        this.FindingsOfExaminationNote.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.FindingsOfExaminationNote.ForeColor = "#B22222";
        this.FindingsOfExaminationNote.Name = "FindingsOfExaminationNote";
        this.FindingsOfExaminationNote.TabIndex = 3;

        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = "tttabcontrol2";
        this.tttabcontrol2.TabIndex = 2;

        this.FindingsOnLesions = new TTVisual.TTTabPage();
        this.FindingsOnLesions.DisplayIndex = 0;
        this.FindingsOnLesions.TabIndex = 0;
        this.FindingsOnLesions.Text = "Lezyon(lar İle İlgili Bulgular)";
        this.FindingsOnLesions.Name = "FindingsOnLesions";

        this.PropertiesOfLesions = new TTVisual.TTTextBox();
        this.PropertiesOfLesions.Multiline = true;
        this.PropertiesOfLesions.Name = "PropertiesOfLesions";
        this.PropertiesOfLesions.TabIndex = 18;

        this.UpperExtrimity = new TTVisual.TTCheckBox();
        this.UpperExtrimity.Value = false;
        this.UpperExtrimity.Text = "Üst Ekstremite";
        this.UpperExtrimity.Name = "UpperExtrimity";
        this.UpperExtrimity.TabIndex = 17;

        this.LowerExtremity = new TTVisual.TTCheckBox();
        this.LowerExtremity.Value = false;
        this.LowerExtremity.Text = "Alt Ekstremite";
        this.LowerExtremity.Name = "LowerExtremity";
        this.LowerExtremity.TabIndex = 16;

        this.GenitalArea = new TTVisual.TTCheckBox();
        this.GenitalArea.Value = false;
        this.GenitalArea.Text = "Genital Bölge";
        this.GenitalArea.Name = "GenitalArea";
        this.GenitalArea.TabIndex = 15;

        this.Chest = new TTVisual.TTCheckBox();
        this.Chest.Value = false;
        this.Chest.Text = "Göğüs";
        this.Chest.Name = "Chest";
        this.Chest.TabIndex = 14;

        this.Back = new TTVisual.TTCheckBox();
        this.Back.Value = false;
        this.Back.Text = "Sırt-Bel";
        this.Back.Name = "Back";
        this.Back.TabIndex = 13;

        this.Abdominal = new TTVisual.TTCheckBox();
        this.Abdominal.Value = false;
        this.Abdominal.Text = "Batın";
        this.Abdominal.Name = "Abdominal";
        this.Abdominal.TabIndex = 12;

        this.HeadNeck = new TTVisual.TTCheckBox();
        this.HeadNeck.Value = false;
        this.HeadNeck.Text = "Baş-Boyun";
        this.HeadNeck.Name = "HeadNeck";
        this.HeadNeck.TabIndex = 2;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = "Lezyon yoksa saptanmadığını belirtiniz.";
        this.ttlabel6.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel6.ForeColor = "#B22222";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 1;

        this.FindingsOnLesionsNote = new TTVisual.TTLabel();
        this.FindingsOnLesionsNote.Text = "Olaya ve iddiaya göre muayene yaparak, varsa lezyon bulunanan bölgeyi işaretleyiniz ve lezyonun özelliklerini tanımlayınız.";
        this.FindingsOnLesionsNote.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.FindingsOnLesionsNote.ForeColor = "#B22222";
        this.FindingsOnLesionsNote.Name = "FindingsOnLesionsNote";
        this.FindingsOnLesionsNote.TabIndex = 0;

        this.SystemExaminations = new TTVisual.TTTabPage();
        this.SystemExaminations.DisplayIndex = 1;
        this.SystemExaminations.TabIndex = 1;
        this.SystemExaminations.Text = "Sistem Muayeneleri";
        this.SystemExaminations.Name = "SystemExaminations";

        this.SystemFindings = new TTVisual.TTTextBox();
        this.SystemFindings.Multiline = true;
        this.SystemFindings.Name = "SystemFindings";
        this.SystemFindings.TabIndex = 26;

        this.UrogenitalSys = new TTVisual.TTCheckBox();
        this.UrogenitalSys.Value = false;
        this.UrogenitalSys.Text = "Ürogenital S.";
        this.UrogenitalSys.Name = "UrogenitalSys";
        this.UrogenitalSys.TabIndex = 25;

        this.SkeletalSys = new TTVisual.TTCheckBox();
        this.SkeletalSys.Value = false;
        this.SkeletalSys.Text = "Kas İskelet S.";
        this.SkeletalSys.Name = "SkeletalSys";
        this.SkeletalSys.TabIndex = 24;

        this.SensoryOrgansSys = new TTVisual.TTCheckBox();
        this.SensoryOrgansSys.Value = false;
        this.SensoryOrgansSys.Text = "Duyu Organları S.";
        this.SensoryOrgansSys.Name = "SensoryOrgansSys";
        this.SensoryOrgansSys.TabIndex = 23;

        this.RespiratorySys = new TTVisual.TTCheckBox();
        this.RespiratorySys.Value = false;
        this.RespiratorySys.Text = "Solunum S.";
        this.RespiratorySys.Name = "RespiratorySys";
        this.RespiratorySys.TabIndex = 22;

        this.DigestiveSys = new TTVisual.TTCheckBox();
        this.DigestiveSys.Value = false;
        this.DigestiveSys.Text = "Sindirim S.";
        this.DigestiveSys.Name = "DigestiveSys";
        this.DigestiveSys.TabIndex = 21;

        this.CardiovascularSystem = new TTVisual.TTCheckBox();
        this.CardiovascularSystem.Value = false;
        this.CardiovascularSystem.Text = " Kalp Damar S.";
        this.CardiovascularSystem.Name = "CardiovascularSystem";
        this.CardiovascularSystem.TabIndex = 20;

        this.CentralNervousSystem = new TTVisual.TTCheckBox();
        this.CentralNervousSystem.Value = false;
        this.CentralNervousSystem.Text = "Merkezi Siinir S.";
        this.CentralNervousSystem.Name = "CentralNervousSystem";
        this.CentralNervousSystem.TabIndex = 19;

        this.Minutes = new TTVisual.TTLabel();
        this.Minutes.Text = "/dk";
        this.Minutes.Name = "Minutes";
        this.Minutes.TabIndex = 18;

        this.labelPulse = new TTVisual.TTLabel();
        this.labelPulse.Text = "Nabız";
        this.labelPulse.Name = "labelPulse";
        this.labelPulse.TabIndex = 17;

        this.Pulse = new TTVisual.TTTextBox();
        this.Pulse.Name = "Pulse";
        this.Pulse.TabIndex = 16;

        this.labelArterialBloodPresure = new TTVisual.TTLabel();
        this.labelArterialBloodPresure.Text = "Tansiyon Arteryel";
        this.labelArterialBloodPresure.Name = "labelArterialBloodPresure";
        this.labelArterialBloodPresure.TabIndex = 15;

        this.ArterialBloodPresure = new TTVisual.TTTextBox();
        this.ArterialBloodPresure.Name = "ArterialBloodPresure";
        this.ArterialBloodPresure.TabIndex = 14;

        this.mmHg = new TTVisual.TTLabel();
        this.mmHg.Text = "mmHg";
        this.mmHg.Name = "mmHg";
        this.mmHg.TabIndex = 13;

        this.labelTendonReflexes = new TTVisual.TTLabel();
        this.labelTendonReflexes.Text = "Tendon Refleksi";
        this.labelTendonReflexes.Name = "labelTendonReflexes";
        this.labelTendonReflexes.TabIndex = 12;

        this.TendonReflexes = new TTVisual.TTEnumComboBox();
        this.TendonReflexes.DataTypeName = "TendonReflexesEnum";
        this.TendonReflexes.Name = "TendonReflexes";
        this.TendonReflexes.TabIndex = 11;

        this.labelPupilProperties = new TTVisual.TTLabel();
        this.labelPupilProperties.Text = "Pupiller";
        this.labelPupilProperties.Name = "labelPupilProperties";
        this.labelPupilProperties.TabIndex = 10;

        this.PupilProperties = new TTVisual.TTEnumComboBox();
        this.PupilProperties.DataTypeName = "PupilPropertiesEnum";
        this.PupilProperties.Name = "PupilProperties";
        this.PupilProperties.TabIndex = 9;

        this.labelRespitory = new TTVisual.TTLabel();
        this.labelRespitory.Text = "Solunum";
        this.labelRespitory.Name = "labelRespitory";
        this.labelRespitory.TabIndex = 8;

        this.Respitory = new TTVisual.TTEnumComboBox();
        this.Respitory.DataTypeName = "RespitoryEnum";
        this.Respitory.Name = "Respitory";
        this.Respitory.TabIndex = 7;

        this.labelLightReflex = new TTVisual.TTLabel();
        this.labelLightReflex.Text = "Işık Refleksi";
        this.labelLightReflex.Name = "labelLightReflex";
        this.labelLightReflex.TabIndex = 6;

        this.LightReflex = new TTVisual.TTEnumComboBox();
        this.LightReflex.DataTypeName = "LightReflexEnum";
        this.LightReflex.Name = "LightReflex";
        this.LightReflex.TabIndex = 5;

        this.labelAwareness = new TTVisual.TTLabel();
        this.labelAwareness.Text = "Bilinci";
        this.labelAwareness.Name = "labelAwareness";
        this.labelAwareness.TabIndex = 4;

        this.Awareness = new TTVisual.TTEnumComboBox();
        this.Awareness.DataTypeName = "AwarenessEnum";
        this.Awareness.Name = "Awareness";
        this.Awareness.TabIndex = 3;

        this.labelGeneralConditionOfPatient = new TTVisual.TTLabel();
        this.labelGeneralConditionOfPatient.Text = "Genel Durumu";
        this.labelGeneralConditionOfPatient.Name = "labelGeneralConditionOfPatient";
        this.labelGeneralConditionOfPatient.TabIndex = 2;

        this.GeneralConditionOfPatient = new TTVisual.TTEnumComboBox();
        this.GeneralConditionOfPatient.DataTypeName = "GeneralConditionOfPatientEnum";
        this.GeneralConditionOfPatient.Name = "GeneralConditionOfPatient";
        this.GeneralConditionOfPatient.TabIndex = 1;

        this.SystemExaminationsNote = new TTVisual.TTLabel();
        this.SystemExaminationsNote.Text = "Tepit edilen diğer bulgularla ilgili sistemi işaretleyiniz ve bulguları belirtiniz.";
        this.SystemExaminationsNote.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SystemExaminationsNote.ForeColor = "#B22222";
        this.SystemExaminationsNote.Name = "SystemExaminationsNote";
        this.SystemExaminationsNote.TabIndex = 0;

        this.PsychiatricExamination = new TTVisual.TTTabPage();
        this.PsychiatricExamination.DisplayIndex = 2;
        this.PsychiatricExamination.TabIndex = 2;
        this.PsychiatricExamination.Text = "Psikiyatrik Muayene";
        this.PsychiatricExamination.Name = "PsychiatricExamination";

        this.PsychiatricConsultation = new TTVisual.TTCheckBox();
        this.PsychiatricConsultation.Value = false;
        this.PsychiatricConsultation.Text = "Psikiyatrik konsültasyonu istendi.";
        this.PsychiatricConsultation.Name = "PsychiatricConsultation";
        this.PsychiatricConsultation.TabIndex = 6;

        this.PyschiatricExamination = new TTVisual.TTCheckBox();
        this.PyschiatricExamination.Value = false;
        this.PyschiatricExamination.Text = "Ayrıntılı psikiyatrik muayeneye gerek duyuldu.";
        this.PyschiatricExamination.Name = "PyschiatricExamination";
        this.PyschiatricExamination.TabIndex = 5;

        this.NoEvidancePsycho = new TTVisual.TTCheckBox();
        this.NoEvidancePsycho.Value = false;
        this.NoEvidancePsycho.Text = "Belirgin bir psikopatolojik bulgu saptanmadı.";
        this.NoEvidancePsycho.Name = "NoEvidancePsycho";
        this.NoEvidancePsycho.TabIndex = 4;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = "Temel psikiyatrik muayene yapıldı";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 3;

        this.PsychiatricExamination3 = new TTVisual.TTLabel();
        this.PsychiatricExamination3.Text = "Bu durumda, rapora PSİKİATRİK MUAYENE/KONSÜLTASYON RAPORU formu ilave ediniz.";
        this.PsychiatricExamination3.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PsychiatricExamination3.ForeColor = "#B22222";
        this.PsychiatricExamination3.Name = "PsychiatricExamination3";
        this.PsychiatricExamination3.TabIndex = 2;

        this.PsychiatricExamination2 = new TTVisual.TTLabel();
        this.PsychiatricExamination2.Text = "bulgu saptamanız durumunda ayrıntılı psikiyatrik muayeneye geçiniz veya psikiatri konsültasyonu isteyiniz.";
        this.PsychiatricExamination2.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PsychiatricExamination2.ForeColor = "#B22222";
        this.PsychiatricExamination2.Name = "PsychiatricExamination2";
        this.PsychiatricExamination2.TabIndex = 1;

        this.PsychiatricExaminationNote1 = new TTVisual.TTLabel();
        this.PsychiatricExaminationNote1.Text = "Temel psiyatrik değerlendirmeyi/muayeneyi her vaka için yapıp, olayın mahiyetine göre veya herhangi bir psikopatolojik";
        this.PsychiatricExaminationNote1.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PsychiatricExaminationNote1.ForeColor = "#B22222";
        this.PsychiatricExaminationNote1.Name = "PsychiatricExaminationNote1";
        this.PsychiatricExaminationNote1.TabIndex = 0;

        this.labelHealthCommitteeStartDateEpisode = new TTVisual.TTLabel();
        this.labelHealthCommitteeStartDateEpisode.Text = "Muayeneye Başlandığı Tarih";
        this.labelHealthCommitteeStartDateEpisode.Name = "labelHealthCommitteeStartDateEpisode";
        this.labelHealthCommitteeStartDateEpisode.TabIndex = 1;

        this.HealthCommitteeStartDateEpisode = new TTVisual.TTDateTimePicker();
        this.HealthCommitteeStartDateEpisode.Format = DateTimePickerFormat.Long;
        this.HealthCommitteeStartDateEpisode.Name = "HealthCommitteeStartDateEpisode";
        this.HealthCommitteeStartDateEpisode.TabIndex = 0;

        this.Test = new TTVisual.TTTabPage();
        this.Test.DisplayIndex = 3;
        this.Test.TabIndex = 4;
        this.Test.Text = "Tetkikler";
        this.Test.Name = "Test";

        this.ChkOther = new TTVisual.TTCheckBox();
        this.ChkOther.Value = false;
        this.ChkOther.Text = "Diğer";
        this.ChkOther.Name = "ChkOther";
        this.ChkOther.TabIndex = 11;

        this.ChkBiopsy = new TTVisual.TTCheckBox();
        this.ChkBiopsy.Value = false;
        this.ChkBiopsy.Text = "Biyopsi";
        this.ChkBiopsy.Name = "ChkBiopsy";
        this.ChkBiopsy.TabIndex = 10;

        this.ChkUltrasonography = new TTVisual.TTCheckBox();
        this.ChkUltrasonography.Value = false;
        this.ChkUltrasonography.Text = "Ultrasonografi";
        this.ChkUltrasonography.Name = "ChkUltrasonography";
        this.ChkUltrasonography.TabIndex = 9;

        this.ChkBTMR = new TTVisual.TTCheckBox();
        this.ChkBTMR.Value = false;
        this.ChkBTMR.Text = "BT/MR";
        this.ChkBTMR.Name = "ChkBTMR";
        this.ChkBTMR.TabIndex = 8;

        this.ChkDirectGraph = new TTVisual.TTCheckBox();
        this.ChkDirectGraph.Value = false;
        this.ChkDirectGraph.Text = "Direkt Grafi";
        this.ChkDirectGraph.Name = "ChkDirectGraph";
        this.ChkDirectGraph.TabIndex = 7;

        this.ChkLabProcedures = new TTVisual.TTCheckBox();
        this.ChkLabProcedures.Value = false;
        this.ChkLabProcedures.Text = "Laboratuvar";
        this.ChkLabProcedures.Name = "ChkLabProcedures";
        this.ChkLabProcedures.TabIndex = 6;

        this.rtfProcedures = new TTVisual.TTRichTextBoxControl();
        this.rtfProcedures.Name = "rtfProcedures";
        this.rtfProcedures.TabIndex = 5;

        this.TestsNote = new TTVisual.TTLabel();
        this.TestsNote.Text = "İstediğiniz Tetkikleri İşaterleyerek sonuçları yazınız.";
        this.TestsNote.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TestsNote.ForeColor = "#B22222";
        this.TestsNote.Name = "TestsNote";
        this.TestsNote.TabIndex = 0;
        this.TestsNote.Visible = false;

        this.AddedReportsAndDocumantation = new TTVisual.TTTabPage();
        this.AddedReportsAndDocumantation.DisplayIndex = 4;
        this.AddedReportsAndDocumantation.TabIndex = 5;
        this.AddedReportsAndDocumantation.Text = "Eklenen Konsültasyon Raporları ve Tıbbi Belge Örnekleri";
        this.AddedReportsAndDocumantation.Name = "AddedReportsAndDocumantation";

        this.Attaches3Text2 = new TTVisual.TTTextBox();
        this.Attaches3Text2.Name = "Attaches3Text2";
        this.Attaches3Text2.TabIndex = 11;

        this.Attaches3Text1 = new TTVisual.TTTextBox();
        this.Attaches3Text1.Name = "Attaches3Text1";
        this.Attaches3Text1.TabIndex = 9;

        this.Attaches2Text = new TTVisual.TTTextBox();
        this.Attaches2Text.Name = "Attaches2Text";
        this.Attaches2Text.TabIndex = 7;

        this.Attaches5 = new TTVisual.TTTextBox();
        this.Attaches5.Multiline = true;
        this.Attaches5.Name = "Attaches5";
        this.Attaches5.TabIndex = 6;

        this.Attaches4 = new TTVisual.TTCheckBox();
        this.Attaches4.Value = false;
        this.Attaches4.Text = "Diğer(Numaralandırarak Sırayla belirtiniz)";
        this.Attaches4.Name = "Attaches4";
        this.Attaches4.TabIndex = 5;

        this.Attaches3 = new TTVisual.TTCheckBox();
        this.Attaches3.Value = false;
        this.Attaches3.Text = "Konsültasyon Raporu";
        this.Attaches3.Name = "Attaches3";
        this.Attaches3.TabIndex = 4;

        this.Attaches2 = new TTVisual.TTCheckBox();
        this.Attaches2.Value = false;
        this.Attaches2.Text = "Psikiyatrik Muayene/Konsültasyon Raporu(2 sayfa)";
        this.Attaches2.Name = "Attaches2";
        this.Attaches2.TabIndex = 3;

        this.Attaches1 = new TTVisual.TTCheckBox();
        this.Attaches1.Value = false;
        this.Attaches1.Text = "Vücut Diyagramı";
        this.Attaches1.Name = "Attaches1";
        this.Attaches1.TabIndex = 2;

        this.AddedReportsAndDocumantationNote2 = new TTVisual.TTLabel();
        this.AddedReportsAndDocumantationNote2.Text = "tıbbi belge örneklerini belirtiniz.";
        this.AddedReportsAndDocumantationNote2.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AddedReportsAndDocumantationNote2.ForeColor = "#B22222";
        this.AddedReportsAndDocumantationNote2.Name = "AddedReportsAndDocumantationNote2";
        this.AddedReportsAndDocumantationNote2.TabIndex = 1;

        this.AddedReportsAndDocumantationNote1 = new TTVisual.TTLabel();
        this.AddedReportsAndDocumantationNote1.Text = "Varsa Rapora Eklenen Vücut Diyagramı, Konsültasyon Muayene  Raporu,Psikiyatrik Muayene/Konsültasyon Raporu ve diğer";
        this.AddedReportsAndDocumantationNote1.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AddedReportsAndDocumantationNote1.ForeColor = "#B22222";
        this.AddedReportsAndDocumantationNote1.Name = "AddedReportsAndDocumantationNote1";
        this.AddedReportsAndDocumantationNote1.TabIndex = 0;

        this.Result = new TTVisual.TTTabPage();
        this.Result.DisplayIndex = 5;
        this.Result.TabIndex = 6;
        this.Result.Text = "Sonuç";
        this.Result.Name = "Result";

        this.CertainReport = new TTVisual.TTCheckBox();
        this.CertainReport.Value = false;
        this.CertainReport.Text = "Kesin Rapor";
        this.CertainReport.Name = "CertainReport";
        this.CertainReport.TabIndex = 13;

        this.UncertainReport = new TTVisual.TTCheckBox();
        this.UncertainReport.Value = false;
        this.UncertainReport.Text = "Durumu bildirir geçici rapor";
        this.UncertainReport.Name = "UncertainReport";
        this.UncertainReport.TabIndex = 12;

        this.ResonOfDispatch = new TTVisual.TTTextBox();
        this.ResonOfDispatch.Multiline = true;
        this.ResonOfDispatch.Name = "ResonOfDispatch";
        this.ResonOfDispatch.TabIndex = 5;

        this.Need = new TTVisual.TTCheckBox();
        this.Need.Value = false;
        this.Need.Text = "Gerek görüldü(Gerekçesini aşağıda açıklayınız)";
        this.Need.Name = "Need";
        this.Need.TabIndex = 4;

        this.NoNeed = new TTVisual.TTCheckBox();
        this.NoNeed.Value = false;
        this.NoNeed.Text = "Gerek görülmedi";
        this.NoNeed.Name = "NoNeed";
        this.NoNeed.TabIndex = 3;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Bir başka sağlık kuruluşuna sevkine";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 2;

        this.ResultNote2 = new TTVisual.TTLabel();
        this.ResultNote2.Text = "Talep edilmişse veya gerek görülmüşse, kişinin ALKOL MUAYENESİ sonucunu bu kısımda belirtiniz.";
        this.ResultNote2.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ResultNote2.ForeColor = "#B22222";
        this.ResultNote2.Name = "ResultNote2";
        this.ResultNote2.TabIndex = 1;

        this.ResultNote1 = new TTVisual.TTLabel();
        this.ResultNote1.Text = "Bu kısmı, Genelge ve Rehberde belirtilen hususları dikkate alarak doldurunuz. Tıbbi terimleri kısaltma yapmadan tam  olarak yapınız.";
        this.ResultNote1.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ResultNote1.ForeColor = "#B22222";
        this.ResultNote1.Name = "ResultNote1";
        this.ResultNote1.TabIndex = 0;

        this.ttpictureboxcontrol = new TTVisual.TTPictureBoxControl();
        this.ttpictureboxcontrol.TemplateGroupName = "Adli Rapor Resimleri";
        this.ttpictureboxcontrol.BackColor = "#FFFFFF";
        this.ttpictureboxcontrol.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttpictureboxcontrol.Name = "ttpictureboxcontrol";
        this.ttpictureboxcontrol.TabIndex = 11;

        this.Report = new TTVisual.TTRichTextBoxControl();
        this.Report.DisplayText = "Rapor";
        this.Report.TemplateGroupName = "Adlı Tıp Raporu";
        this.Report.BackColor = "#FFFFFF";
        this.Report.Name = "Report";
        this.Report.TabIndex = 10;

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 3;

        this.DocumentNumber = new TTVisual.TTTextBox();
        this.DocumentNumber.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DocumentNumber.Name = "DocumentNumber";
        this.DocumentNumber.TabIndex = 7;

        this.ReportNo = new TTVisual.TTTextBox();
        this.ReportNo.BackColor = "#F0F0F0";
        this.ReportNo.ReadOnly = true;
        this.ReportNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ReportNo.Name = "ReportNo";
        this.ReportNo.TabIndex = 2;

        this.labelPatientIdentityNote = new TTVisual.TTLabel();
        this.labelPatientIdentityNote.Text = "(Geçerli Kimlik Belgesi Olmayanlar İçin Doldurulacak)";
        this.labelPatientIdentityNote.Font = "Name=Tahoma, Size=7,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelPatientIdentityNote.Name = "labelPatientIdentityNote";
        this.labelPatientIdentityNote.TabIndex = 40;

        this.labelReasonExaminationReportType = new TTVisual.TTLabel();
        this.labelReasonExaminationReportType.Text = "Muayene Sebebi ";
        this.labelReasonExaminationReportType.Name = "labelReasonExaminationReportType";
        this.labelReasonExaminationReportType.TabIndex = 36;

        this.ReasonExaminationReportType = new TTVisual.TTEnumComboBox();
        this.ReasonExaminationReportType.DataTypeName = "ReasonExaminationTypeEnum";
        this.ReasonExaminationReportType.Required = true;
        this.ReasonExaminationReportType.BackColor = "#FFE3C6";
        this.ReasonExaminationReportType.Name = "ReasonExaminationReportType";
        this.ReasonExaminationReportType.TabIndex = 9;

        this.LabelRequestDate = new TTVisual.TTLabel();
        this.LabelRequestDate.Text = "İstek Tarihi";
        this.LabelRequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.LabelRequestDate.ForeColor = "#000000";
        this.LabelRequestDate.Name = "LabelRequestDate";
        this.LabelRequestDate.TabIndex = 34;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.BackColor = "#F0F0F0";
        this.RequestDate.CustomFormat = "dd.MM.yyyy HH:mm";
        this.RequestDate.Format = DateTimePickerFormat.Custom;
        this.RequestDate.Enabled = false;
        this.RequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 0;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = "Protokol No";
        this.labelProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 9;

        this.labelJudicialNo = new TTVisual.TTLabel();
        this.labelJudicialNo.Text = "Evrak Sayısı";
        this.labelJudicialNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelJudicialNo.ForeColor = "#000000";
        this.labelJudicialNo.Name = "labelJudicialNo";
        this.labelJudicialNo.TabIndex = 5;

        this.labelJudicialDate = new TTVisual.TTLabel();
        this.labelJudicialDate.Text = "Evrak Tarihi";
        this.labelJudicialDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelJudicialDate.ForeColor = "#000000";
        this.labelJudicialDate.Name = "labelJudicialDate";
        this.labelJudicialDate.TabIndex = 11;

        this.labelReportNo = new TTVisual.TTLabel();
        this.labelReportNo.Text = "Rapor No";
        this.labelReportNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelReportNo.ForeColor = "#000000";
        this.labelReportNo.Name = "labelReportNo";
        this.labelReportNo.TabIndex = 1;

        this.DocumetDate = new TTVisual.TTDateTimePicker();
        this.DocumetDate.CustomFormat = "dd.MM.yyyy HH:mm";
        this.DocumetDate.Format = DateTimePickerFormat.Custom;
        this.DocumetDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DocumetDate.Name = "DocumetDate";
        this.DocumetDate.TabIndex = 6;

        this.SenderChair = new TTVisual.TTObjectListBox();
        this.SenderChair.ListDefName = "SenderChairListDefinition";
        this.SenderChair.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SenderChair.Name = "SenderChair";
        this.SenderChair.TabIndex = 5;

        this.labelSenderChair = new TTVisual.TTLabel();
        this.labelSenderChair.Text = "Gönderen Makam";
        this.labelSenderChair.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSenderChair.ForeColor = "#000000";
        this.labelSenderChair.Name = "labelSenderChair";
        this.labelSenderChair.TabIndex = 19;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.LinkedControlName = "MasterResource";
        this.ttobjectlistbox1.LinkedRelationPath = "USERRESOURCES.RESOURCE";
        this.ttobjectlistbox1.ListDefName = "DoctorListDefinition";
        this.ttobjectlistbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 9;

        this.tttabcontrol1.Controls = [this.ExaminationConditions, this.EventInfo, this.FindingsOfExamination, this.Test, this.AddedReportsAndDocumantation, this.Result];
        this.ExaminationConditions.Controls = [this.ClothesOfPatient3, this.ClothesOfPatient2, this.ClothesOfPatient1, this.PeopleInExamination4, this.PeopleInExamination3, this.PeopleInExamination2, this.PeopleInExamination1, this.SuitableEnvironment2, this.SuitableEnvironment1, this.Explanation2, this.Explanation1, this.ExaminationConditionsNote, this.labelSuitableEnvirNote, this.ttlabel2, this.labelSuitableEnvirement, this.labelClothesOfPatient, this.labelBeingPeopleInExamination1];
        this.EventInfo.Controls = [this.HistoryOfEvent, this.PatientHistoryEpisode, this.ComplaintEpisode, this.labelMedicalHistory, this.labelPatientComplaints, this.EventInfoNote, this.EventHistoryNote, this.labelHistoryOfEvent];
        this.FindingsOfExamination.Controls = [this.FindingsOfExamination2, this.FindingsOfExaminationNote, this.tttabcontrol2, this.labelHealthCommitteeStartDateEpisode, this.HealthCommitteeStartDateEpisode];
        this.tttabcontrol2.Controls = [this.FindingsOnLesions, this.SystemExaminations, this.PsychiatricExamination];
        this.FindingsOnLesions.Controls = [this.PropertiesOfLesions, this.UpperExtrimity, this.LowerExtremity, this.GenitalArea, this.Chest, this.Back, this.Abdominal, this.HeadNeck, this.ttlabel6, this.FindingsOnLesionsNote];
        this.SystemExaminations.Controls = [this.SystemFindings, this.UrogenitalSys, this.SkeletalSys, this.SensoryOrgansSys, this.RespiratorySys, this.DigestiveSys, this.CardiovascularSystem, this.CentralNervousSystem, this.Minutes, this.labelPulse, this.Pulse, this.labelArterialBloodPresure, this.ArterialBloodPresure, this.mmHg, this.labelTendonReflexes, this.TendonReflexes, this.labelPupilProperties, this.PupilProperties, this.labelRespitory, this.Respitory, this.labelLightReflex, this.LightReflex, this.labelAwareness, this.Awareness, this.labelGeneralConditionOfPatient, this.GeneralConditionOfPatient, this.SystemExaminationsNote];
        this.PsychiatricExamination.Controls = [this.PsychiatricConsultation, this.PyschiatricExamination, this.NoEvidancePsycho, this.ttlabel7, this.PsychiatricExamination3, this.PsychiatricExamination2, this.PsychiatricExaminationNote1];
        this.Test.Controls = [this.ChkOther, this.ChkBiopsy, this.ChkUltrasonography, this.ChkBTMR, this.ChkDirectGraph, this.ChkLabProcedures, this.rtfProcedures, this.TestsNote];
        this.AddedReportsAndDocumantation.Controls = [this.Attaches3Text2, this.Attaches3Text1, this.Attaches2Text, this.Attaches5, this.Attaches4, this.Attaches3, this.Attaches2, this.Attaches1, this.AddedReportsAndDocumantationNote2, this.AddedReportsAndDocumantationNote1];
        this.Result.Controls = [this.CertainReport, this.UncertainReport, this.ResonOfDispatch, this.Need, this.NoNeed, this.ttlabel4, this.ResultNote2, this.ResultNote1, this.ttpictureboxcontrol, this.Report];
        this.Controls = [this.labelAttendantNameSurname, this.AttendantNameSurname, this.PatientIdentity, this.OtherReasonExamination, this.labelResUser, this.labelPermissionDepartment, this.PermissionDepartment, this.ReportType, this.labelPatientIdentity, this.tttabcontrol1, this.ExaminationConditions, this.ClothesOfPatient3, this.ClothesOfPatient2, this.ClothesOfPatient1, this.PeopleInExamination4, this.PeopleInExamination3, this.PeopleInExamination2, this.PeopleInExamination1, this.SuitableEnvironment2, this.SuitableEnvironment1, this.Explanation2, this.Explanation1, this.ExaminationConditionsNote, this.labelSuitableEnvirNote, this.ttlabel2, this.labelSuitableEnvirement, this.labelClothesOfPatient, this.labelBeingPeopleInExamination1, this.EventInfo, this.HistoryOfEvent, this.PatientHistoryEpisode, this.ComplaintEpisode, this.labelMedicalHistory, this.labelPatientComplaints, this.EventInfoNote, this.EventHistoryNote, this.labelHistoryOfEvent, this.FindingsOfExamination, this.FindingsOfExamination2, this.FindingsOfExaminationNote, this.tttabcontrol2, this.FindingsOnLesions, this.PropertiesOfLesions, this.UpperExtrimity, this.LowerExtremity, this.GenitalArea, this.Chest, this.Back, this.Abdominal, this.HeadNeck, this.ttlabel6, this.FindingsOnLesionsNote, this.SystemExaminations, this.SystemFindings, this.UrogenitalSys, this.SkeletalSys, this.SensoryOrgansSys, this.RespiratorySys, this.DigestiveSys, this.CardiovascularSystem, this.CentralNervousSystem, this.Minutes, this.labelPulse, this.Pulse, this.labelArterialBloodPresure, this.ArterialBloodPresure, this.mmHg, this.labelTendonReflexes, this.TendonReflexes, this.labelPupilProperties, this.PupilProperties, this.labelRespitory, this.Respitory, this.labelLightReflex, this.LightReflex, this.labelAwareness, this.Awareness, this.labelGeneralConditionOfPatient, this.GeneralConditionOfPatient, this.SystemExaminationsNote, this.PsychiatricExamination, this.PsychiatricConsultation, this.PyschiatricExamination, this.NoEvidancePsycho, this.ttlabel7, this.PsychiatricExamination3, this.PsychiatricExamination2, this.PsychiatricExaminationNote1, this.labelHealthCommitteeStartDateEpisode, this.HealthCommitteeStartDateEpisode, this.Test, this.ChkOther, this.ChkBiopsy, this.ChkUltrasonography, this.ChkBTMR, this.ChkDirectGraph, this.ChkLabProcedures, this.rtfProcedures, this.TestsNote, this.AddedReportsAndDocumantation, this.Attaches3Text2, this.Attaches3Text1, this.Attaches2Text, this.Attaches5, this.Attaches4, this.Attaches3, this.Attaches2, this.Attaches1, this.AddedReportsAndDocumantationNote2, this.AddedReportsAndDocumantationNote1, this.Result, this.CertainReport, this.UncertainReport, this.ResonOfDispatch, this.Need, this.NoNeed, this.ttlabel4, this.ResultNote2, this.ResultNote1, this.ttpictureboxcontrol, this.Report, this.ProtocolNo, this.DocumentNumber, this.ReportNo, this.labelPatientIdentityNote, this.labelReasonExaminationReportType, this.ReasonExaminationReportType, this.LabelRequestDate, this.RequestDate, this.labelProtocolNo, this.labelJudicialNo, this.labelJudicialDate, this.labelReportNo, this.DocumetDate, this.SenderChair, this.labelSenderChair, this.ttobjectlistbox1];

    }

    public actionIdForDemografic(): Guid
    {
            if (this._ForensicMedicalReport.MasterAction != null)
            {
                if (typeof this._ForensicMedicalReport.MasterAction === "string") {
                    return this._ForensicMedicalReport.MasterAction;
                }
                else
                {
                    return this._ForensicMedicalReport.MasterAction.ObjectID;
                }
            }

            return this._ForensicMedicalReport.ObjectID;
    }

    onCertainReportChanged(event)
    {
        if(!this._isReadOnly)
             this._UncertainReportDisabled = event.value;
        else
            this._UncertainReportDisabled = this._isReadOnly;
    }

    onUncertainReportChanged(event)
    {
        if(!this._isReadOnly)
            this._CertainReportDisabled = event.value;
        else
             this._CertainReportDisabled = this._isReadOnly;
    }

    onNoNeedChanged(event)
    {
        if(!this._isReadOnly)
            this._NeedDisabled = event.value;
        else
            this._NeedDisabled =this._isReadOnly;
    }
    onNeedChanged(event)
    {
        if(!this._isReadOnly)
            this._NoNeedDisabled = event.value;
        else
            this._NoNeedDisabled =this._isReadOnly;
    }

    printForensicMedicalReport() {
        this.openForensicMedicalReport(this._ForensicMedicalReport.ObjectID);
    }
}
