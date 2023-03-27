//$DC8662D9
import { Component, OnInit, NgZone } from '@angular/core';
import { CognitiveEvaluationFormViewModel } from './CognitiveEvaluationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { CognitiveEvaluation } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { PsychologyBasedObject } from 'NebulaClient/Model/AtlasClientModel';



@Component({
    selector: 'CognitiveEvaluationForm',
    templateUrl: './CognitiveEvaluationForm.html',
    providers: [MessageService]
})
export class CognitiveEvaluationForm extends TTVisual.TTForm implements OnInit {
    AddedUser: TTVisual.ITTObjectListBox;
    AttentionAndCalculation: TTVisual.ITTTextBox;
    DetectionFunction: TTVisual.ITTRichTextBoxControl;
    EducationStatus: TTVisual.ITTObjectListBox;
    IQIntelligenceLevel: TTVisual.ITTRichTextBoxControl;
    JudgmentFunction: TTVisual.ITTRichTextBoxControl;
    labelAddedUser: TTVisual.ITTLabel;
    labelAttentionAndCalculation: TTVisual.ITTLabel;
    labelDetectionFunction: TTVisual.ITTLabel;
    labelEducationStatus: TTVisual.ITTLabel;
    labelIQIntelligenceLevel: TTVisual.ITTLabel;
    labelJudgmentFunction: TTVisual.ITTLabel;
    labelLanguage: TTVisual.ITTLabel;
    labelLongTermMemoryFunction: TTVisual.ITTLabel;
    labelObservationDiscussionEvalNote: TTVisual.ITTLabel;
    labelOrientation: TTVisual.ITTLabel;
    labelOther: TTVisual.ITTLabel;
    labelPatientJob: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelReasoningFunction: TTVisual.ITTLabel;
    labelRecordingMemory: TTVisual.ITTLabel;
    labelRemembrance: TTVisual.ITTLabel;
    labelShortTermMemoryFunction: TTVisual.ITTLabel;
    labelSocialEducationRetardationSit: TTVisual.ITTLabel;
    Language: TTVisual.ITTTextBox;
    LongTermMemoryFunction: TTVisual.ITTRichTextBoxControl;
    ObservationDiscussionEvalNote: TTVisual.ITTRichTextBoxControl;
    Orientation: TTVisual.ITTTextBox;
    Other: TTVisual.ITTRichTextBoxControl;
    PatientJob: TTVisual.ITTObjectListBox;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ReasoningFunction: TTVisual.ITTRichTextBoxControl;
    RecordingMemory: TTVisual.ITTTextBox;
    Remembrance: TTVisual.ITTTextBox;
    ShortTermMemoryFunction: TTVisual.ITTRichTextBoxControl;
    SocialEducationRetardationSit: TTVisual.ITTRichTextBoxControl;
    public cognitiveEvaluationFormViewModel: CognitiveEvaluationFormViewModel = new CognitiveEvaluationFormViewModel();
    public get _CognitiveEvaluation(): CognitiveEvaluation {
        return this._TTObject as CognitiveEvaluation;
    }
    private CognitiveEvaluationForm_DocumentUrl: string = '/api/CognitiveEvaluationService/CognitiveEvaluationForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('COGNITIVEEVALUATION', 'CognitiveEvaluationForm');
        this._DocumentServiceUrl = this.CognitiveEvaluationForm_DocumentUrl;
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
        if (this._CognitiveEvaluation != null)
            this._CognitiveEvaluation.PsychologyBasedObject = this.psychologyBasedObject;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new CognitiveEvaluation();
        this.cognitiveEvaluationFormViewModel = new CognitiveEvaluationFormViewModel();
        this._ViewModel = this.cognitiveEvaluationFormViewModel;
        this.cognitiveEvaluationFormViewModel._CognitiveEvaluation = this._TTObject as CognitiveEvaluation;
        this.cognitiveEvaluationFormViewModel._CognitiveEvaluation.AddedUser = new ResUser();
        this.cognitiveEvaluationFormViewModel._CognitiveEvaluation.PatientJob = new SKRSMeslekler();
        this.cognitiveEvaluationFormViewModel._CognitiveEvaluation.EducationStatus = new SKRSOgrenimDurumu();
        this.cognitiveEvaluationFormViewModel._CognitiveEvaluation.ProcedureDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;

        that.cognitiveEvaluationFormViewModel = this._ViewModel as CognitiveEvaluationFormViewModel;
        that._TTObject = this.cognitiveEvaluationFormViewModel._CognitiveEvaluation;
        if (this.cognitiveEvaluationFormViewModel == null)
            this.cognitiveEvaluationFormViewModel = new CognitiveEvaluationFormViewModel();
        if (this.cognitiveEvaluationFormViewModel._CognitiveEvaluation == null)
            this.cognitiveEvaluationFormViewModel._CognitiveEvaluation = new CognitiveEvaluation();
        let addedUserObjectID = that.cognitiveEvaluationFormViewModel._CognitiveEvaluation["AddedUser"];
        if (addedUserObjectID != null && (typeof addedUserObjectID === 'string')) {
            let addedUser = that.cognitiveEvaluationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === addedUserObjectID.toString());
             if (addedUser) {
                that.cognitiveEvaluationFormViewModel._CognitiveEvaluation.AddedUser = addedUser;
            }
        }
        let patientJobObjectID = that.cognitiveEvaluationFormViewModel._CognitiveEvaluation["PatientJob"];
        if (patientJobObjectID != null && (typeof patientJobObjectID === 'string')) {
            let patientJob = that.cognitiveEvaluationFormViewModel.SKRSMesleklers.find(o => o.ObjectID.toString() === patientJobObjectID.toString());
             if (patientJob) {
                that.cognitiveEvaluationFormViewModel._CognitiveEvaluation.PatientJob = patientJob;
            }
        }
        let educationStatusObjectID = that.cognitiveEvaluationFormViewModel._CognitiveEvaluation["EducationStatus"];
        if (educationStatusObjectID != null && (typeof educationStatusObjectID === 'string')) {
            let educationStatus = that.cognitiveEvaluationFormViewModel.SKRSOgrenimDurumus.find(o => o.ObjectID.toString() === educationStatusObjectID.toString());
             if (educationStatus) {
                that.cognitiveEvaluationFormViewModel._CognitiveEvaluation.EducationStatus = educationStatus;
            }
        }
        let procedureDoctorObjectID = that.cognitiveEvaluationFormViewModel._CognitiveEvaluation["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.cognitiveEvaluationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.cognitiveEvaluationFormViewModel._CognitiveEvaluation.ProcedureDoctor = procedureDoctor;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(CognitiveEvaluationFormViewModel);
  
    }


    public onAddedUserChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.AddedUser != event) {
                this._CognitiveEvaluation.AddedUser = event;
            }
        }
    }

    public onAttentionAndCalculationChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.AttentionAndCalculation != event) {
                this._CognitiveEvaluation.AttentionAndCalculation = event;
            }
        }
    }

    public onDetectionFunctionChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.DetectionFunction != event) {
                this._CognitiveEvaluation.DetectionFunction = event;
            }
        }
    }

    public onEducationStatusChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.EducationStatus != event) {
                this._CognitiveEvaluation.EducationStatus = event;
            }
        }
    }

    public onIQIntelligenceLevelChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.IQIntelligenceLevel != event) {
                this._CognitiveEvaluation.IQIntelligenceLevel = event;
            }
        }
    }

    public onJudgmentFunctionChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.JudgmentFunction != event) {
                this._CognitiveEvaluation.JudgmentFunction = event;
            }
        }
    }

    public onLanguageChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.Language != event) {
                this._CognitiveEvaluation.Language = event;
            }
        }
    }

    public onLongTermMemoryFunctionChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.LongTermMemoryFunction != event) {
                this._CognitiveEvaluation.LongTermMemoryFunction = event;
            }
        }
    }

    public onObservationDiscussionEvalNoteChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.ObservationDiscussionEvalNote != event) {
                this._CognitiveEvaluation.ObservationDiscussionEvalNote = event;
            }
        }
    }

    public onOrientationChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.Orientation != event) {
                this._CognitiveEvaluation.Orientation = event;
            }
        }
    }

    public onOtherChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.Other != event) {
                this._CognitiveEvaluation.Other = event;
            }
        }
    }

    public onPatientJobChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.PatientJob != event) {
                this._CognitiveEvaluation.PatientJob = event;
            }
        }
    }

    public onProcedureDoctorChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.ProcedureDoctor != event) {
                this._CognitiveEvaluation.ProcedureDoctor = event;
            }
        }
    }

    public onReasoningFunctionChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.ReasoningFunction != event) {
                this._CognitiveEvaluation.ReasoningFunction = event;
            }
        }
    }

    public onRecordingMemoryChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.RecordingMemory != event) {
                this._CognitiveEvaluation.RecordingMemory = event;
            }
        }
    }

    public onRemembranceChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.Remembrance != event) {
                this._CognitiveEvaluation.Remembrance = event;
            }
        }
    }

    public onShortTermMemoryFunctionChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.ShortTermMemoryFunction != event) {
                this._CognitiveEvaluation.ShortTermMemoryFunction = event;
            }
        }
    }

    public onSocialEducationRetardationSitChanged(event): void {
        if (event != null) {
            if (this._CognitiveEvaluation != null && this._CognitiveEvaluation.SocialEducationRetardationSit != event) {
                this._CognitiveEvaluation.SocialEducationRetardationSit = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Orientation, "Text", this.__ttObject, "Orientation");
        redirectProperty(this.RecordingMemory, "Text", this.__ttObject, "RecordingMemory");
        redirectProperty(this.AttentionAndCalculation, "Text", this.__ttObject, "AttentionAndCalculation");
        redirectProperty(this.Remembrance, "Text", this.__ttObject, "Remembrance");
        redirectProperty(this.Language, "Text", this.__ttObject, "Language");
        redirectProperty(this.DetectionFunction, "Rtf", this.__ttObject, "DetectionFunction");
        redirectProperty(this.ReasoningFunction, "Rtf", this.__ttObject, "ReasoningFunction");
        redirectProperty(this.JudgmentFunction, "Rtf", this.__ttObject, "JudgmentFunction");
        redirectProperty(this.ShortTermMemoryFunction, "Rtf", this.__ttObject, "ShortTermMemoryFunction");
        redirectProperty(this.LongTermMemoryFunction, "Rtf", this.__ttObject, "LongTermMemoryFunction");
        redirectProperty(this.IQIntelligenceLevel, "Rtf", this.__ttObject, "IQIntelligenceLevel");
        redirectProperty(this.SocialEducationRetardationSit, "Rtf", this.__ttObject, "SocialEducationRetardationSit");
        redirectProperty(this.Other, "Rtf", this.__ttObject, "Other");
        redirectProperty(this.ObservationDiscussionEvalNote, "Rtf", this.__ttObject, "ObservationDiscussionEvalNote");
    }

    public initFormControls(): void {
        this.labelAddedUser = new TTVisual.TTLabel();
        this.labelAddedUser.Text = "Ekleyen Kullanıcı";
        this.labelAddedUser.Name = "labelAddedUser";
        this.labelAddedUser.TabIndex = 46;

        this.AddedUser = new TTVisual.TTObjectListBox();
        this.AddedUser.ListDefName = "ResUserListDefinition";
        this.AddedUser.Name = "AddedUser";
        this.AddedUser.TabIndex = 45;

        this.ObservationDiscussionEvalNote = new TTVisual.TTRichTextBoxControl();
        this.ObservationDiscussionEvalNote.Name = "ObservationDiscussionEvalNote";
        this.ObservationDiscussionEvalNote.TabIndex = 44;

        this.labelObservationDiscussionEvalNote = new TTVisual.TTLabel();
        this.labelObservationDiscussionEvalNote.Text = i18n("M14955", "Gözlem Görüşmeye ve Değerlendirmeye Ait Not");
        this.labelObservationDiscussionEvalNote.Name = "labelObservationDiscussionEvalNote";
        this.labelObservationDiscussionEvalNote.TabIndex = 43;

        this.labelRemembrance = new TTVisual.TTLabel();
        this.labelRemembrance.Text = i18n("M15555", "Hatırlama");
        this.labelRemembrance.Name = "labelRemembrance";
        this.labelRemembrance.TabIndex = 41;

        this.Remembrance = new TTVisual.TTTextBox();
        this.Remembrance.Name = "Remembrance";
        this.Remembrance.TabIndex = 40;

        this.RecordingMemory = new TTVisual.TTTextBox();
        this.RecordingMemory.Name = "RecordingMemory";
        this.RecordingMemory.TabIndex = 38;

        this.Orientation = new TTVisual.TTTextBox();
        this.Orientation.Name = "Orientation";
        this.Orientation.TabIndex = 36;

        this.Language = new TTVisual.TTTextBox();
        this.Language.Name = "Language";
        this.Language.TabIndex = 34;

        this.AttentionAndCalculation = new TTVisual.TTTextBox();
        this.AttentionAndCalculation.Name = "AttentionAndCalculation";
        this.AttentionAndCalculation.TabIndex = 32;

        this.labelRecordingMemory = new TTVisual.TTLabel();
        this.labelRecordingMemory.Text = i18n("M17395", "Kayıt Hafıza");
        this.labelRecordingMemory.Name = "labelRecordingMemory";
        this.labelRecordingMemory.TabIndex = 39;

        this.labelOrientation = new TTVisual.TTLabel();
        this.labelOrientation.Text = i18n("M19807", "Oryantasyon");
        this.labelOrientation.Name = "labelOrientation";
        this.labelOrientation.TabIndex = 37;

        this.labelLanguage = new TTVisual.TTLabel();
        this.labelLanguage.Text = i18n("M12852", "Dil");
        this.labelLanguage.Name = "labelLanguage";
        this.labelLanguage.TabIndex = 35;

        this.labelAttentionAndCalculation = new TTVisual.TTLabel();
        this.labelAttentionAndCalculation.Text = i18n("M12850", "Dikkat ve Hesap Yapma");
        this.labelAttentionAndCalculation.Name = "labelAttentionAndCalculation";
        this.labelAttentionAndCalculation.TabIndex = 33;

        this.Other = new TTVisual.TTRichTextBoxControl();
        this.Other.Name = "Other";
        this.Other.TabIndex = 31;

        this.labelOther = new TTVisual.TTLabel();
        this.labelOther.Text = i18n("M12780", "Diğer");
        this.labelOther.Name = "labelOther";
        this.labelOther.TabIndex = 30;

        this.SocialEducationRetardationSit = new TTVisual.TTRichTextBoxControl();
        this.SocialEducationRetardationSit.Name = "SocialEducationRetardationSit";
        this.SocialEducationRetardationSit.TabIndex = 28;

        this.labelSocialEducationRetardationSit = new TTVisual.TTLabel();
        this.labelSocialEducationRetardationSit.Text = i18n("M22171", "Sosyal Eğitimsel Retardasyon Durumu");
        this.labelSocialEducationRetardationSit.Name = "labelSocialEducationRetardationSit";
        this.labelSocialEducationRetardationSit.TabIndex = 27;

        this.IQIntelligenceLevel = new TTVisual.TTRichTextBoxControl();
        this.IQIntelligenceLevel.Name = "IQIntelligenceLevel";
        this.IQIntelligenceLevel.TabIndex = 25;

        this.labelIQIntelligenceLevel = new TTVisual.TTLabel();
        this.labelIQIntelligenceLevel.Text = i18n("M16016", "IQ Zeka Düzeyi");
        this.labelIQIntelligenceLevel.Name = "labelIQIntelligenceLevel";
        this.labelIQIntelligenceLevel.TabIndex = 24;

        this.LongTermMemoryFunction = new TTVisual.TTRichTextBoxControl();
        this.LongTermMemoryFunction.Name = "LongTermMemoryFunction";
        this.LongTermMemoryFunction.TabIndex = 22;

        this.labelLongTermMemoryFunction = new TTVisual.TTLabel();
        this.labelLongTermMemoryFunction.Text = i18n("M23885", "Uzun Süreli Bellek Fonskiyonu");
        this.labelLongTermMemoryFunction.Name = "labelLongTermMemoryFunction";
        this.labelLongTermMemoryFunction.TabIndex = 21;

        this.ShortTermMemoryFunction = new TTVisual.TTRichTextBoxControl();
        this.ShortTermMemoryFunction.Name = "ShortTermMemoryFunction";
        this.ShortTermMemoryFunction.TabIndex = 19;

        this.labelShortTermMemoryFunction = new TTVisual.TTLabel();
        this.labelShortTermMemoryFunction.Text = i18n("M17532", "Kısa Süreli Bellek Fonksiyonu");
        this.labelShortTermMemoryFunction.Name = "labelShortTermMemoryFunction";
        this.labelShortTermMemoryFunction.TabIndex = 18;

        this.JudgmentFunction = new TTVisual.TTRichTextBoxControl();
        this.JudgmentFunction.Name = "JudgmentFunction";
        this.JudgmentFunction.TabIndex = 16;

        this.labelJudgmentFunction = new TTVisual.TTLabel();
        this.labelJudgmentFunction.Text = i18n("M24323", "Yargı İşlevi");
        this.labelJudgmentFunction.Name = "labelJudgmentFunction";
        this.labelJudgmentFunction.TabIndex = 15;

        this.ReasoningFunction = new TTVisual.TTRichTextBoxControl();
        this.ReasoningFunction.Name = "ReasoningFunction";
        this.ReasoningFunction.TabIndex = 13;

        this.labelReasoningFunction = new TTVisual.TTLabel();
        this.labelReasoningFunction.Text = i18n("M19274", "Muhakeme İşlevi");
        this.labelReasoningFunction.Name = "labelReasoningFunction";
        this.labelReasoningFunction.TabIndex = 12;

        this.DetectionFunction = new TTVisual.TTRichTextBoxControl();
        this.DetectionFunction.Name = "DetectionFunction";
        this.DetectionFunction.TabIndex = 10;

        this.labelDetectionFunction = new TTVisual.TTLabel();
        this.labelDetectionFunction.Text = i18n("M10690", "Algılama İşlevi");
        this.labelDetectionFunction.Name = "labelDetectionFunction";
        this.labelDetectionFunction.TabIndex = 9;

        this.labelPatientJob = new TTVisual.TTLabel();
        this.labelPatientJob.Text = i18n("M18928", "Mesleği");
        this.labelPatientJob.Name = "labelPatientJob";
        this.labelPatientJob.TabIndex = 7;

        this.PatientJob = new TTVisual.TTObjectListBox();
        this.PatientJob.ListDefName = "SKRSMesleklerList";
        this.PatientJob.Name = "PatientJob";
        this.PatientJob.TabIndex = 6;

        this.labelEducationStatus = new TTVisual.TTLabel();
        this.labelEducationStatus.Text = i18n("M19901", "Öğrenim Durumu");
        this.labelEducationStatus.Name = "labelEducationStatus";
        this.labelEducationStatus.TabIndex = 5;

        this.EducationStatus = new TTVisual.TTObjectListBox();
        this.EducationStatus.ListDefName = "SKRSOgrenimDurumuList";
        this.EducationStatus.Name = "EducationStatus";
        this.EducationStatus.TabIndex = 4;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M23274", "Testi Uygulayan Doktor");
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 1;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ListDefName = "PsychologistList";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 0;

        this.Controls = [this.labelAddedUser, this.AddedUser, this.ObservationDiscussionEvalNote, this.labelObservationDiscussionEvalNote, this.labelRemembrance, this.Remembrance, this.RecordingMemory, this.Orientation, this.Language, this.AttentionAndCalculation, this.labelRecordingMemory, this.labelOrientation, this.labelLanguage, this.labelAttentionAndCalculation, this.Other, this.labelOther, this.SocialEducationRetardationSit, this.labelSocialEducationRetardationSit, this.IQIntelligenceLevel, this.labelIQIntelligenceLevel, this.LongTermMemoryFunction, this.labelLongTermMemoryFunction, this.ShortTermMemoryFunction, this.labelShortTermMemoryFunction, this.JudgmentFunction, this.labelJudgmentFunction, this.ReasoningFunction, this.labelReasoningFunction, this.DetectionFunction, this.labelDetectionFunction, this.labelPatientJob, this.PatientJob, this.labelEducationStatus, this.EducationStatus, this.labelProcedureDoctor, this.ProcedureDoctor];

    }


}
