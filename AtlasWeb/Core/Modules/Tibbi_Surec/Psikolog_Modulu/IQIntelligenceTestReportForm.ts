//$AFDDCC89
import { Component, OnInit, NgZone } from '@angular/core';
import { IQIntelligenceTestReportFormViewModel } from './IQIntelligenceTestReportFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { IQIntelligenceTestReport } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { PsychologyBasedObject } from 'NebulaClient/Model/AtlasClientModel';



@Component({
    selector: 'IQIntelligenceTestReportForm',
    templateUrl: './IQIntelligenceTestReportForm.html',
    providers: [MessageService]
})
export class IQIntelligenceTestReportForm extends TTVisual.TTForm implements OnInit {
    AddedUser: TTVisual.ITTObjectListBox;
    Comment: TTVisual.ITTRichTextBoxControl;
    CriticalLifeEvent: TTVisual.ITTRichTextBoxControl;
    EducationStatus: TTVisual.ITTObjectListBox;
    labelAddedUser: TTVisual.ITTLabel;
    labelComment: TTVisual.ITTLabel;
    labelCriticalLifeEvent: TTVisual.ITTLabel;
    labelEducationStatus: TTVisual.ITTLabel;
    labelPatientJob: TTVisual.ITTLabel;
    labelPerformanceIntelligence: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelTestXXXXXX: TTVisual.ITTLabel;
    labelTestPurpose: TTVisual.ITTLabel;
    labelTotalIntelligence: TTVisual.ITTLabel;
    labelVerbalIntelligence: TTVisual.ITTLabel;
    PatientJob: TTVisual.ITTObjectListBox;
    PerformanceIntelligence: TTVisual.ITTRichTextBoxControl;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    TestXXXXXX: TTVisual.ITTRichTextBoxControl;
    TestPurpose: TTVisual.ITTRichTextBoxControl;
    TotalIntelligence: TTVisual.ITTRichTextBoxControl;
    VerbalIntelligence: TTVisual.ITTRichTextBoxControl;
    public iQIntelligenceTestReportFormViewModel: IQIntelligenceTestReportFormViewModel = new IQIntelligenceTestReportFormViewModel();
    public get _IQIntelligenceTestReport(): IQIntelligenceTestReport {
        return this._TTObject as IQIntelligenceTestReport;
    }
    private IQIntelligenceTestReportForm_DocumentUrl: string = '/api/IQIntelligenceTestReportService/IQIntelligenceTestReportForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('IQINTELLIGENCETESTREPORT', 'IQIntelligenceTestReportForm');
        this._DocumentServiceUrl = this.IQIntelligenceTestReportForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected psychologyBasedObject: PsychologyBasedObject;
    //IInputParam inputları dinamiccomponentla set etmek için
    setInputParam(value: Object) {
        this.psychologyBasedObject = <any>value;
    }


    protected async PreScript() {
        super.PreScript();
        if (this._IQIntelligenceTestReport != null)
            this._IQIntelligenceTestReport.PsychologyBasedObject = this.psychologyBasedObject;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new IQIntelligenceTestReport();
        this.iQIntelligenceTestReportFormViewModel = new IQIntelligenceTestReportFormViewModel();
        this._ViewModel = this.iQIntelligenceTestReportFormViewModel;
        this.iQIntelligenceTestReportFormViewModel._IQIntelligenceTestReport = this._TTObject as IQIntelligenceTestReport;
        this.iQIntelligenceTestReportFormViewModel._IQIntelligenceTestReport.AddedUser = new ResUser();
        this.iQIntelligenceTestReportFormViewModel._IQIntelligenceTestReport.PatientJob = new SKRSMeslekler();
        this.iQIntelligenceTestReportFormViewModel._IQIntelligenceTestReport.EducationStatus = new SKRSOgrenimDurumu();
        this.iQIntelligenceTestReportFormViewModel._IQIntelligenceTestReport.ProcedureDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;

        that.iQIntelligenceTestReportFormViewModel = this._ViewModel as IQIntelligenceTestReportFormViewModel;
        that._TTObject = this.iQIntelligenceTestReportFormViewModel._IQIntelligenceTestReport;
        if (this.iQIntelligenceTestReportFormViewModel == null)
            this.iQIntelligenceTestReportFormViewModel = new IQIntelligenceTestReportFormViewModel();
        if (this.iQIntelligenceTestReportFormViewModel._IQIntelligenceTestReport == null)
            this.iQIntelligenceTestReportFormViewModel._IQIntelligenceTestReport = new IQIntelligenceTestReport();
        let addedUserObjectID = that.iQIntelligenceTestReportFormViewModel._IQIntelligenceTestReport["AddedUser"];
        if (addedUserObjectID != null && (typeof addedUserObjectID === 'string')) {
            let addedUser = that.iQIntelligenceTestReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === addedUserObjectID.toString());
             if (addedUser) {
                that.iQIntelligenceTestReportFormViewModel._IQIntelligenceTestReport.AddedUser = addedUser;
            }
        }
        let patientJobObjectID = that.iQIntelligenceTestReportFormViewModel._IQIntelligenceTestReport["PatientJob"];
        if (patientJobObjectID != null && (typeof patientJobObjectID === 'string')) {
            let patientJob = that.iQIntelligenceTestReportFormViewModel.SKRSMesleklers.find(o => o.ObjectID.toString() === patientJobObjectID.toString());
             if (patientJob) {
                that.iQIntelligenceTestReportFormViewModel._IQIntelligenceTestReport.PatientJob = patientJob;
            }
        }
        let educationStatusObjectID = that.iQIntelligenceTestReportFormViewModel._IQIntelligenceTestReport["EducationStatus"];
        if (educationStatusObjectID != null && (typeof educationStatusObjectID === 'string')) {
            let educationStatus = that.iQIntelligenceTestReportFormViewModel.SKRSOgrenimDurumus.find(o => o.ObjectID.toString() === educationStatusObjectID.toString());
             if (educationStatus) {
                that.iQIntelligenceTestReportFormViewModel._IQIntelligenceTestReport.EducationStatus = educationStatus;
            }
        }
        let procedureDoctorObjectID = that.iQIntelligenceTestReportFormViewModel._IQIntelligenceTestReport["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.iQIntelligenceTestReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.iQIntelligenceTestReportFormViewModel._IQIntelligenceTestReport.ProcedureDoctor = procedureDoctor;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(IQIntelligenceTestReportFormViewModel);
  
    }


    public onAddedUserChanged(event): void {
        if (event != null) {
            if (this._IQIntelligenceTestReport != null && this._IQIntelligenceTestReport.AddedUser != event) {
                this._IQIntelligenceTestReport.AddedUser = event;
            }
        }
    }

    public onCommentChanged(event): void {
        if (event != null) {
            if (this._IQIntelligenceTestReport != null && this._IQIntelligenceTestReport.Comment != event) {
                this._IQIntelligenceTestReport.Comment = event;
            }
        }
    }

    public onCriticalLifeEventChanged(event): void {
        if (event != null) {
            if (this._IQIntelligenceTestReport != null && this._IQIntelligenceTestReport.CriticalLifeEvent != event) {
                this._IQIntelligenceTestReport.CriticalLifeEvent = event;
            }
        }
    }

    public onEducationStatusChanged(event): void {
        if (event != null) {
            if (this._IQIntelligenceTestReport != null && this._IQIntelligenceTestReport.EducationStatus != event) {
                this._IQIntelligenceTestReport.EducationStatus = event;
            }
        }
    }

    public onPatientJobChanged(event): void {
        if (event != null) {
            if (this._IQIntelligenceTestReport != null && this._IQIntelligenceTestReport.PatientJob != event) {
                this._IQIntelligenceTestReport.PatientJob = event;
            }
        }
    }

    public onPerformanceIntelligenceChanged(event): void {
        if (event != null) {
            if (this._IQIntelligenceTestReport != null && this._IQIntelligenceTestReport.PerformanceIntelligence != event) {
                this._IQIntelligenceTestReport.PerformanceIntelligence = event;
            }
        }
    }

    public onProcedureDoctorChanged(event): void {
        if (event != null) {
            if (this._IQIntelligenceTestReport != null && this._IQIntelligenceTestReport.ProcedureDoctor != event) {
                this._IQIntelligenceTestReport.ProcedureDoctor = event;
            }
        }
    }

    public onTestXXXXXXChanged(event): void {
        if (event != null) {
            if (this._IQIntelligenceTestReport != null && this._IQIntelligenceTestReport.TestXXXXXX != event) {
                this._IQIntelligenceTestReport.TestXXXXXX = event;
            }
        }
    }

    public onTestPurposeChanged(event): void {
        if (event != null) {
            if (this._IQIntelligenceTestReport != null && this._IQIntelligenceTestReport.TestPurpose != event) {
                this._IQIntelligenceTestReport.TestPurpose = event;
            }
        }
    }

    public onTotalIntelligenceChanged(event): void {
        if (event != null) {
            if (this._IQIntelligenceTestReport != null && this._IQIntelligenceTestReport.TotalIntelligence != event) {
                this._IQIntelligenceTestReport.TotalIntelligence = event;
            }
        }
    }

    public onVerbalIntelligenceChanged(event): void {
        if (event != null) {
            if (this._IQIntelligenceTestReport != null && this._IQIntelligenceTestReport.VerbalIntelligence != event) {
                this._IQIntelligenceTestReport.VerbalIntelligence = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.TestXXXXXX, "Rtf", this.__ttObject, "TestXXXXXX");
        redirectProperty(this.CriticalLifeEvent, "Rtf", this.__ttObject, "CriticalLifeEvent");
        redirectProperty(this.TestPurpose, "Rtf", this.__ttObject, "TestPurpose");
        redirectProperty(this.VerbalIntelligence, "Rtf", this.__ttObject, "VerbalIntelligence");
        redirectProperty(this.PerformanceIntelligence, "Rtf", this.__ttObject, "PerformanceIntelligence");
        redirectProperty(this.TotalIntelligence, "Rtf", this.__ttObject, "TotalIntelligence");
        redirectProperty(this.Comment, "Rtf", this.__ttObject, "Comment");
    }

    public initFormControls(): void {
        this.labelAddedUser = new TTVisual.TTLabel();
        this.labelAddedUser.Text = "Ekleyen Kullanıcı";
        this.labelAddedUser.Name = "labelAddedUser";
        this.labelAddedUser.TabIndex = 30;

        this.AddedUser = new TTVisual.TTObjectListBox();
        this.AddedUser.ListDefName = "ResUserListDefinition";
        this.AddedUser.Name = "AddedUser";
        this.AddedUser.TabIndex = 29;
        this.AddedUser.ReadOnly = true;


        this.Comment = new TTVisual.TTRichTextBoxControl();
        this.Comment.Name = "Comment";
        this.Comment.TabIndex = 28;

        this.TotalIntelligence = new TTVisual.TTRichTextBoxControl();
        this.TotalIntelligence.Name = "TotalIntelligence";
        this.TotalIntelligence.TabIndex = 27;

        this.VerbalIntelligence = new TTVisual.TTRichTextBoxControl();
        this.VerbalIntelligence.Name = "VerbalIntelligence";
        this.VerbalIntelligence.TabIndex = 26;

        this.PerformanceIntelligence = new TTVisual.TTRichTextBoxControl();
        this.PerformanceIntelligence.Name = "PerformanceIntelligence";
        this.PerformanceIntelligence.TabIndex = 25;

        this.TestPurpose = new TTVisual.TTRichTextBoxControl();
        this.TestPurpose.Name = "TestPurpose";
        this.TestPurpose.TabIndex = 24;

        this.CriticalLifeEvent = new TTVisual.TTRichTextBoxControl();
        this.CriticalLifeEvent.Name = "CriticalLifeEvent";
        this.CriticalLifeEvent.TabIndex = 23;

        this.TestXXXXXX = new TTVisual.TTRichTextBoxControl();
        this.TestXXXXXX.Name = "TestXXXXXX";
        this.TestXXXXXX.TabIndex = 22;

        this.labelVerbalIntelligence = new TTVisual.TTLabel();
        this.labelVerbalIntelligence.Text = i18n("M22215", "Sözel Zeka");
        this.labelVerbalIntelligence.Name = "labelVerbalIntelligence";
        this.labelVerbalIntelligence.TabIndex = 21;

        this.labelTotalIntelligence = new TTVisual.TTLabel();
        this.labelTotalIntelligence.Text = i18n("M23527", "Toplam Zeka");
        this.labelTotalIntelligence.Name = "labelTotalIntelligence";
        this.labelTotalIntelligence.TabIndex = 19;

        this.labelTestPurpose = new TTVisual.TTLabel();
        this.labelTestPurpose.Text = i18n("M23272", "Teste Ne Amaçla Alındığı");
        this.labelTestPurpose.Name = "labelTestPurpose";
        this.labelTestPurpose.TabIndex = 17;

        this.labelTestXXXXXX = new TTVisual.TTLabel();
        this.labelTestXXXXXX.Text = i18n("M23273", "Testi İsteyen Kişi yada Kurum");
        this.labelTestXXXXXX.Name = "labelTestXXXXXX";
        this.labelTestXXXXXX.TabIndex = 15;

        this.labelPerformanceIntelligence = new TTVisual.TTLabel();
        this.labelPerformanceIntelligence.Text = i18n("M20298", "Performans Zeka");
        this.labelPerformanceIntelligence.Name = "labelPerformanceIntelligence";
        this.labelPerformanceIntelligence.TabIndex = 13;

        this.labelCriticalLifeEvent = new TTVisual.TTLabel();
        this.labelCriticalLifeEvent.Text = i18n("M17872", "Kritik Yaşam Olayı");
        this.labelCriticalLifeEvent.Name = "labelCriticalLifeEvent";
        this.labelCriticalLifeEvent.TabIndex = 9;

        this.labelComment = new TTVisual.TTLabel();
        this.labelComment.Text = i18n("M24713", "Yorum");
        this.labelComment.Name = "labelComment";
        this.labelComment.TabIndex = 7;

        this.labelPatientJob = new TTVisual.TTLabel();
        this.labelPatientJob.Text = i18n("M18928", "Mesleği");
        this.labelPatientJob.Name = "labelPatientJob";
        this.labelPatientJob.TabIndex = 5;

        this.PatientJob = new TTVisual.TTObjectListBox();
        this.PatientJob.ListDefName = "SKRSMesleklerList";
        this.PatientJob.Name = "PatientJob";
        this.PatientJob.TabIndex = 4;

        this.labelEducationStatus = new TTVisual.TTLabel();
        this.labelEducationStatus.Text = i18n("M19901", "Öğrenim Durumu");
        this.labelEducationStatus.Name = "labelEducationStatus";
        this.labelEducationStatus.TabIndex = 3;

        this.EducationStatus = new TTVisual.TTObjectListBox();
        this.EducationStatus.ListDefName = "SKRSOgrenimDurumuList";
        this.EducationStatus.Name = "EducationStatus";
        this.EducationStatus.TabIndex = 2;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M23274", "Testi Uygulayan Doktor");
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 1;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ListDefName = "PsychologistList";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 0;

        this.Controls = [this.labelAddedUser, this.AddedUser, this.Comment, this.TotalIntelligence, this.VerbalIntelligence, this.PerformanceIntelligence, this.TestPurpose, this.CriticalLifeEvent, this.TestXXXXXX, this.labelVerbalIntelligence, this.labelTotalIntelligence, this.labelTestPurpose, this.labelTestXXXXXX, this.labelPerformanceIntelligence, this.labelCriticalLifeEvent, this.labelComment, this.labelPatientJob, this.PatientJob, this.labelEducationStatus, this.EducationStatus, this.labelProcedureDoctor, this.ProcedureDoctor];

    }


}
