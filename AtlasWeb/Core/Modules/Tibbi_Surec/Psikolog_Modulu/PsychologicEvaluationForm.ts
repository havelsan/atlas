//$9C09DBBC
import { Component, OnInit, NgZone } from '@angular/core';
import { PsychologicEvaluationFormViewModel } from './PsychologicEvaluationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PsychologicEvaluation } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { PsychologyBasedObject } from 'NebulaClient/Model/AtlasClientModel';



@Component({
    selector: 'PsychologicEvaluationForm',
    templateUrl: './PsychologicEvaluationForm.html',
    providers: [MessageService]
})
export class PsychologicEvaluationForm extends TTVisual.TTForm implements OnInit {
    AddedUser: TTVisual.ITTObjectListBox;
    EducationStatus: TTVisual.ITTObjectListBox;
    IQIntelligenceLevel: TTVisual.ITTRichTextBoxControl;
    labelAddedUser: TTVisual.ITTLabel;
    labelEducationStatus: TTVisual.ITTLabel;
    labelIQIntelligenceLevel: TTVisual.ITTLabel;
    labelLongTermMemoryFunction: TTVisual.ITTLabel;
    labelMoodDisorder: TTVisual.ITTLabel;
    labelObservationDiscussionEvalNote: TTVisual.ITTLabel;
    labelPatientJob: TTVisual.ITTLabel;
    labelPersonalPathologyOrDeviation: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelPsychopathologicalDeviation: TTVisual.ITTLabel;
    labelPsychopathologicalDisorder: TTVisual.ITTLabel;
    labelResult: TTVisual.ITTLabel;
    labelShortTermMemoryFunction: TTVisual.ITTLabel;
    labelSocialEducationRetardationSit: TTVisual.ITTLabel;
    LongTermMemoryFunction: TTVisual.ITTRichTextBoxControl;
    MoodDisorder: TTVisual.ITTRichTextBoxControl;
    ObservationDiscussionEvalNote: TTVisual.ITTRichTextBoxControl;
    PatientJob: TTVisual.ITTObjectListBox;
    PersonalPathologyOrDeviation: TTVisual.ITTRichTextBoxControl;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    PsychopathologicalDeviation: TTVisual.ITTRichTextBoxControl;
    PsychopathologicalDisorder: TTVisual.ITTRichTextBoxControl;
    Result: TTVisual.ITTRichTextBoxControl;
    ShortTermMemoryFunction: TTVisual.ITTRichTextBoxControl;
    SocialEducationRetardationSit: TTVisual.ITTRichTextBoxControl;
    public psychologicEvaluationFormViewModel: PsychologicEvaluationFormViewModel = new PsychologicEvaluationFormViewModel();
    public get _PsychologicEvaluation(): PsychologicEvaluation {
        return this._TTObject as PsychologicEvaluation;
    }
    private PsychologicEvaluationForm_DocumentUrl: string = '/api/PsychologicEvaluationService/PsychologicEvaluationForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('PSYCHOLOGICEVALUATION', 'PsychologicEvaluationForm');
        this._DocumentServiceUrl = this.PsychologicEvaluationForm_DocumentUrl;
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
        if (this._PsychologicEvaluation != null)
            this._PsychologicEvaluation.PsychologyBasedObject = this.psychologyBasedObject;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PsychologicEvaluation();
        this.psychologicEvaluationFormViewModel = new PsychologicEvaluationFormViewModel();
        this._ViewModel = this.psychologicEvaluationFormViewModel;
        this.psychologicEvaluationFormViewModel._PsychologicEvaluation = this._TTObject as PsychologicEvaluation;
        this.psychologicEvaluationFormViewModel._PsychologicEvaluation.ProcedureDoctor = new ResUser();
        this.psychologicEvaluationFormViewModel._PsychologicEvaluation.AddedUser = new ResUser();
        this.psychologicEvaluationFormViewModel._PsychologicEvaluation.EducationStatus = new SKRSOgrenimDurumu();
        this.psychologicEvaluationFormViewModel._PsychologicEvaluation.PatientJob = new SKRSMeslekler();
    }

    protected loadViewModel() {
        let that = this;

        that.psychologicEvaluationFormViewModel = this._ViewModel as PsychologicEvaluationFormViewModel;
        that._TTObject = this.psychologicEvaluationFormViewModel._PsychologicEvaluation;
        if (this.psychologicEvaluationFormViewModel == null)
            this.psychologicEvaluationFormViewModel = new PsychologicEvaluationFormViewModel();
        if (this.psychologicEvaluationFormViewModel._PsychologicEvaluation == null)
            this.psychologicEvaluationFormViewModel._PsychologicEvaluation = new PsychologicEvaluation();
        let procedureDoctorObjectID = that.psychologicEvaluationFormViewModel._PsychologicEvaluation["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.psychologicEvaluationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.psychologicEvaluationFormViewModel._PsychologicEvaluation.ProcedureDoctor = procedureDoctor;
            }
        }
        let addedUserObjectID = that.psychologicEvaluationFormViewModel._PsychologicEvaluation["AddedUser"];
        if (addedUserObjectID != null && (typeof addedUserObjectID === 'string')) {
            let addedUser = that.psychologicEvaluationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === addedUserObjectID.toString());
             if (addedUser) {
                that.psychologicEvaluationFormViewModel._PsychologicEvaluation.AddedUser = addedUser;
            }
        }
        let educationStatusObjectID = that.psychologicEvaluationFormViewModel._PsychologicEvaluation["EducationStatus"];
        if (educationStatusObjectID != null && (typeof educationStatusObjectID === 'string')) {
            let educationStatus = that.psychologicEvaluationFormViewModel.SKRSOgrenimDurumus.find(o => o.ObjectID.toString() === educationStatusObjectID.toString());
             if (educationStatus) {
                that.psychologicEvaluationFormViewModel._PsychologicEvaluation.EducationStatus = educationStatus;
            }
        }
        let patientJobObjectID = that.psychologicEvaluationFormViewModel._PsychologicEvaluation["PatientJob"];
        if (patientJobObjectID != null && (typeof patientJobObjectID === 'string')) {
            let patientJob = that.psychologicEvaluationFormViewModel.SKRSMesleklers.find(o => o.ObjectID.toString() === patientJobObjectID.toString());
             if (patientJob) {
                that.psychologicEvaluationFormViewModel._PsychologicEvaluation.PatientJob = patientJob;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(PsychologicEvaluationFormViewModel);
  
    }


    public onAddedUserChanged(event): void {
        if (event != null) {
            if (this._PsychologicEvaluation != null && this._PsychologicEvaluation.AddedUser != event) {
                this._PsychologicEvaluation.AddedUser = event;
            }
        }
    }

    public onEducationStatusChanged(event): void {
        if (event != null) {
            if (this._PsychologicEvaluation != null && this._PsychologicEvaluation.EducationStatus != event) {
                this._PsychologicEvaluation.EducationStatus = event;
            }
        }
    }

    public onIQIntelligenceLevelChanged(event): void {
        if (event != null) {
            if (this._PsychologicEvaluation != null && this._PsychologicEvaluation.IQIntelligenceLevel != event) {
                this._PsychologicEvaluation.IQIntelligenceLevel = event;
            }
        }
    }

    public onLongTermMemoryFunctionChanged(event): void {
        if (event != null) {
            if (this._PsychologicEvaluation != null && this._PsychologicEvaluation.LongTermMemoryFunction != event) {
                this._PsychologicEvaluation.LongTermMemoryFunction = event;
            }
        }
    }

    public onMoodDisorderChanged(event): void {
        if (event != null) {
            if (this._PsychologicEvaluation != null && this._PsychologicEvaluation.MoodDisorder != event) {
                this._PsychologicEvaluation.MoodDisorder = event;
            }
        }
    }

    public onObservationDiscussionEvalNoteChanged(event): void {
        if (event != null) {
            if (this._PsychologicEvaluation != null && this._PsychologicEvaluation.ObservationDiscussionEvalNote != event) {
                this._PsychologicEvaluation.ObservationDiscussionEvalNote = event;
            }
        }
    }

    public onPatientJobChanged(event): void {
        if (event != null) {
            if (this._PsychologicEvaluation != null && this._PsychologicEvaluation.PatientJob != event) {
                this._PsychologicEvaluation.PatientJob = event;
            }
        }
    }

    public onPersonalPathologyOrDeviationChanged(event): void {
        if (event != null) {
            if (this._PsychologicEvaluation != null && this._PsychologicEvaluation.PersonalPathologyOrDeviation != event) {
                this._PsychologicEvaluation.PersonalPathologyOrDeviation = event;
            }
        }
    }

    public onProcedureDoctorChanged(event): void {
        if (event != null) {
            if (this._PsychologicEvaluation != null && this._PsychologicEvaluation.ProcedureDoctor != event) {
                this._PsychologicEvaluation.ProcedureDoctor = event;
            }
        }
    }

    public onPsychopathologicalDeviationChanged(event): void {
        if (event != null) {
            if (this._PsychologicEvaluation != null && this._PsychologicEvaluation.PsychopathologicalDeviation != event) {
                this._PsychologicEvaluation.PsychopathologicalDeviation = event;
            }
        }
    }

    public onPsychopathologicalDisorderChanged(event): void {
        if (event != null) {
            if (this._PsychologicEvaluation != null && this._PsychologicEvaluation.PsychopathologicalDisorder != event) {
                this._PsychologicEvaluation.PsychopathologicalDisorder = event;
            }
        }
    }

    public onResultChanged(event): void {
        if (event != null) {
            if (this._PsychologicEvaluation != null && this._PsychologicEvaluation.Result != event) {
                this._PsychologicEvaluation.Result = event;
            }
        }
    }

    public onShortTermMemoryFunctionChanged(event): void {
        if (event != null) {
            if (this._PsychologicEvaluation != null && this._PsychologicEvaluation.ShortTermMemoryFunction != event) {
                this._PsychologicEvaluation.ShortTermMemoryFunction = event;
            }
        }
    }

    public onSocialEducationRetardationSitChanged(event): void {
        if (event != null) {
            if (this._PsychologicEvaluation != null && this._PsychologicEvaluation.SocialEducationRetardationSit != event) {
                this._PsychologicEvaluation.SocialEducationRetardationSit = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.PsychopathologicalDeviation, "Rtf", this.__ttObject, "PsychopathologicalDeviation");
        redirectProperty(this.MoodDisorder, "Rtf", this.__ttObject, "MoodDisorder");
        redirectProperty(this.ShortTermMemoryFunction, "Rtf", this.__ttObject, "ShortTermMemoryFunction");
        redirectProperty(this.IQIntelligenceLevel, "Rtf", this.__ttObject, "IQIntelligenceLevel");
        redirectProperty(this.SocialEducationRetardationSit, "Rtf", this.__ttObject, "SocialEducationRetardationSit");
        redirectProperty(this.PsychopathologicalDisorder, "Rtf", this.__ttObject, "PsychopathologicalDisorder");
        redirectProperty(this.PersonalPathologyOrDeviation, "Rtf", this.__ttObject, "PersonalPathologyOrDeviation");
        redirectProperty(this.LongTermMemoryFunction, "Rtf", this.__ttObject, "LongTermMemoryFunction");
        redirectProperty(this.ObservationDiscussionEvalNote, "Rtf", this.__ttObject, "ObservationDiscussionEvalNote");
        redirectProperty(this.Result, "Rtf", this.__ttObject, "Result");
    }

    public initFormControls(): void {
        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M23274", "Testi Uygulayan Doktor");
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 37;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ListDefName = "PsychologistList";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 36;

        this.labelAddedUser = new TTVisual.TTLabel();
        this.labelAddedUser.Text = "Ekleyen Kullanıcı";
        this.labelAddedUser.Name = "labelAddedUser";
        this.labelAddedUser.TabIndex = 35;

        this.AddedUser = new TTVisual.TTObjectListBox();
        this.AddedUser.ListDefName = "ResUserListDefinition";
        this.AddedUser.Name = "AddedUser";
        this.AddedUser.TabIndex = 34;

        this.Result = new TTVisual.TTRichTextBoxControl();
        this.Result.Name = "Result";
        this.Result.TabIndex = 33;

        this.labelResult = new TTVisual.TTLabel();
        this.labelResult.Text = i18n("M22078", "Sonuç");
        this.labelResult.Name = "labelResult";
        this.labelResult.TabIndex = 32;

        this.ObservationDiscussionEvalNote = new TTVisual.TTRichTextBoxControl();
        this.ObservationDiscussionEvalNote.Name = "ObservationDiscussionEvalNote";
        this.ObservationDiscussionEvalNote.TabIndex = 30;

        this.labelObservationDiscussionEvalNote = new TTVisual.TTLabel();
        this.labelObservationDiscussionEvalNote.Text = i18n("M14955", "Gözlem Görüşmeye ve Değerlendirmeye Ait Not");
        this.labelObservationDiscussionEvalNote.Name = "labelObservationDiscussionEvalNote";
        this.labelObservationDiscussionEvalNote.TabIndex = 29;

        this.LongTermMemoryFunction = new TTVisual.TTRichTextBoxControl();
        this.LongTermMemoryFunction.Name = "LongTermMemoryFunction";
        this.LongTermMemoryFunction.TabIndex = 27;

        this.labelLongTermMemoryFunction = new TTVisual.TTLabel();
        this.labelLongTermMemoryFunction.Text = i18n("M23884", "Uzun Süreli Bellek Fonksiyonu");
        this.labelLongTermMemoryFunction.Name = "labelLongTermMemoryFunction";
        this.labelLongTermMemoryFunction.TabIndex = 26;

        this.PersonalPathologyOrDeviation = new TTVisual.TTRichTextBoxControl();
        this.PersonalPathologyOrDeviation.Name = "PersonalPathologyOrDeviation";
        this.PersonalPathologyOrDeviation.TabIndex = 24;

        this.labelPersonalPathologyOrDeviation = new TTVisual.TTLabel();
        this.labelPersonalPathologyOrDeviation.Text = i18n("M17596", "Kişilik Patolojisi ya da Sapması");
        this.labelPersonalPathologyOrDeviation.Name = "labelPersonalPathologyOrDeviation";
        this.labelPersonalPathologyOrDeviation.TabIndex = 23;

        this.PsychopathologicalDisorder = new TTVisual.TTRichTextBoxControl();
        this.PsychopathologicalDisorder.Name = "PsychopathologicalDisorder";
        this.PsychopathologicalDisorder.TabIndex = 21;

        this.labelPsychopathologicalDisorder = new TTVisual.TTLabel();
        this.labelPsychopathologicalDisorder.Text = i18n("M20615", "Psikopatolojik Bozukluk");
        this.labelPsychopathologicalDisorder.Name = "labelPsychopathologicalDisorder";
        this.labelPsychopathologicalDisorder.TabIndex = 20;

        this.SocialEducationRetardationSit = new TTVisual.TTRichTextBoxControl();
        this.SocialEducationRetardationSit.Name = "SocialEducationRetardationSit";
        this.SocialEducationRetardationSit.TabIndex = 18;

        this.labelSocialEducationRetardationSit = new TTVisual.TTLabel();
        this.labelSocialEducationRetardationSit.Text = i18n("M22171", "Sosyal Eğitimsel Retardasyon Durumu");
        this.labelSocialEducationRetardationSit.Name = "labelSocialEducationRetardationSit";
        this.labelSocialEducationRetardationSit.TabIndex = 17;

        this.IQIntelligenceLevel = new TTVisual.TTRichTextBoxControl();
        this.IQIntelligenceLevel.Name = "IQIntelligenceLevel";
        this.IQIntelligenceLevel.TabIndex = 15;

        this.labelIQIntelligenceLevel = new TTVisual.TTLabel();
        this.labelIQIntelligenceLevel.Text = i18n("M16016", "IQ Zeka Düzeyi");
        this.labelIQIntelligenceLevel.Name = "labelIQIntelligenceLevel";
        this.labelIQIntelligenceLevel.TabIndex = 14;

        this.ShortTermMemoryFunction = new TTVisual.TTRichTextBoxControl();
        this.ShortTermMemoryFunction.Name = "ShortTermMemoryFunction";
        this.ShortTermMemoryFunction.TabIndex = 12;

        this.labelShortTermMemoryFunction = new TTVisual.TTLabel();
        this.labelShortTermMemoryFunction.Text = i18n("M17532", "Kısa Süreli Bellek Fonksiyonu");
        this.labelShortTermMemoryFunction.Name = "labelShortTermMemoryFunction";
        this.labelShortTermMemoryFunction.TabIndex = 11;

        this.MoodDisorder = new TTVisual.TTRichTextBoxControl();
        this.MoodDisorder.Name = "MoodDisorder";
        this.MoodDisorder.TabIndex = 9;

        this.labelMoodDisorder = new TTVisual.TTLabel();
        this.labelMoodDisorder.Text = i18n("M13378", "Duygu Durum Bozukluğu");
        this.labelMoodDisorder.Name = "labelMoodDisorder";
        this.labelMoodDisorder.TabIndex = 8;

        this.PsychopathologicalDeviation = new TTVisual.TTRichTextBoxControl();
        this.PsychopathologicalDeviation.Name = "PsychopathologicalDeviation";
        this.PsychopathologicalDeviation.TabIndex = 6;

        this.labelPsychopathologicalDeviation = new TTVisual.TTLabel();
        this.labelPsychopathologicalDeviation.Text = i18n("M20616", "Psikopatolojik Sapma");
        this.labelPsychopathologicalDeviation.Name = "labelPsychopathologicalDeviation";
        this.labelPsychopathologicalDeviation.TabIndex = 5;

        this.labelEducationStatus = new TTVisual.TTLabel();
        this.labelEducationStatus.Text = i18n("M19901", "Öğrenim Durumu");
        this.labelEducationStatus.Name = "labelEducationStatus";
        this.labelEducationStatus.TabIndex = 3;

        this.EducationStatus = new TTVisual.TTObjectListBox();
        this.EducationStatus.ListDefName = "SKRSOgrenimDurumuList";
        this.EducationStatus.Name = "EducationStatus";
        this.EducationStatus.TabIndex = 2;

        this.labelPatientJob = new TTVisual.TTLabel();
        this.labelPatientJob.Text = i18n("M18928", "Mesleği");
        this.labelPatientJob.Name = "labelPatientJob";
        this.labelPatientJob.TabIndex = 1;

        this.PatientJob = new TTVisual.TTObjectListBox();
        this.PatientJob.ListDefName = "SKRSMesleklerList";
        this.PatientJob.Name = "PatientJob";
        this.PatientJob.TabIndex = 0;

        this.Controls = [this.labelProcedureDoctor, this.ProcedureDoctor, this.labelAddedUser, this.AddedUser, this.Result, this.labelResult, this.ObservationDiscussionEvalNote, this.labelObservationDiscussionEvalNote, this.LongTermMemoryFunction, this.labelLongTermMemoryFunction, this.PersonalPathologyOrDeviation, this.labelPersonalPathologyOrDeviation, this.PsychopathologicalDisorder, this.labelPsychopathologicalDisorder, this.SocialEducationRetardationSit, this.labelSocialEducationRetardationSit, this.IQIntelligenceLevel, this.labelIQIntelligenceLevel, this.ShortTermMemoryFunction, this.labelShortTermMemoryFunction, this.MoodDisorder, this.labelMoodDisorder, this.PsychopathologicalDeviation, this.labelPsychopathologicalDeviation, this.labelEducationStatus, this.EducationStatus, this.labelPatientJob, this.PatientJob];

    }


}
