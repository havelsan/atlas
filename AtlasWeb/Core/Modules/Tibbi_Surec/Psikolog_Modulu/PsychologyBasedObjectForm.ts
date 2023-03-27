//$5E2E48D1
import { Component, OnInit, Input, NgZone } from '@angular/core';
import { PsychologyBasedObjectFormViewModel } from './PsychologyBasedObjectFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { PsychologyBasedObject } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityBasedObjectForm } from 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/SpecialityBasedObjectForm';
import { CognitiveEvaluation } from 'NebulaClient/Model/AtlasClientModel';
import { IQIntelligenceTestReport } from 'NebulaClient/Model/AtlasClientModel';
import { PsychologicEvaluation } from 'NebulaClient/Model/AtlasClientModel';
import { PsychologyAuthorizedUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { VerbalAndPerformanceTests } from 'NebulaClient/Model/AtlasClientModel';
import { NqlQueryService } from 'app/QueryList/Services/nql-query.service';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';


@Component({
    selector: 'PsychologyBasedObjectForm',
    templateUrl: './PsychologyBasedObjectForm.html',
    providers: [MessageService, NqlQueryService]
})
export class PsychologyBasedObjectForm extends SpecialityBasedObjectForm implements OnInit {
    AddedDateCognitiveEvaluation: TTVisual.ITTDateTimePickerColumn;
    AddedDateEarlyChildGrowthEvaluation: TTVisual.ITTDateTimePickerColumn;
    AddedDateIQIntelligenceTestReport: TTVisual.ITTDateTimePickerColumn;
    AddedDatePsychologicEvaluation: TTVisual.ITTDateTimePickerColumn;
    AddedUserCognitiveEvaluation: TTVisual.ITTListBoxColumn;
    AddedUserEarlyChildGrowthEvaluation: TTVisual.ITTListBoxColumn;
    AddedUserIQIntelligenceTestReport: TTVisual.ITTListBoxColumn;
    AddedUserPsychologicEvaluation: TTVisual.ITTListBoxColumn;
    AppliedTestsHeader: TTVisual.ITTLabel;
    ArithmeticVerbalAndPerformanceTests: TTVisual.ITTTextBoxColumn;
    AttentionAndCalculationCognitiveEvaluation: TTVisual.ITTTextBoxColumn;
    BinetTermanTest: TTVisual.ITTCheckBox;
    CattelIntelligenceTest: TTVisual.ITTCheckBox;
    CognitiveEvaluation: TTVisual.ITTTabPage;
    CognitiveEvolutionEarlyChildGrowthEvaluation: TTVisual.ITTTextBoxColumn;
    CommentIQIntelligenceTestReport: TTVisual.ITTTextBoxColumn;
    CriticalLifeEventIQIntelligenceTestReport: TTVisual.ITTTextBoxColumn;
    DetectionFunctionCognitiveEvaluation: TTVisual.ITTTextBoxColumn;
    DoctorStatement: TTVisual.ITTRichTextBoxControl;
    EarlyChildGrowthEvalTab: TTVisual.ITTTabPage;
    EarlyChildGrowthEvaluation: TTVisual.ITTGrid;
    EducationStatusCognitiveEvaluation: TTVisual.ITTListBoxColumn;
    EducationStatusIQIntelligenceTestReport: TTVisual.ITTListBoxColumn;
    EducationStatusPsychologicEvaluation: TTVisual.ITTListBoxColumn;
    GeneralEvolutionLevelEarlyChildGrowthEvaluation: TTVisual.ITTTextBoxColumn;
    GeneralInformationVerbalAndPerformanceTests: TTVisual.ITTTextBoxColumn;
    GoodEnoughHarrisDrawingTest: TTVisual.ITTCheckBox;
    ImageCompletionVerbalAndPerformanceTests: TTVisual.ITTTextBoxColumn;
    ImageEditingVerbalAndPerformanceTests: TTVisual.ITTTextBoxColumn;
    ImportantNoteAboutApplication: TTVisual.ITTEnumComboBox;
    InformationTakenFromParent: TTVisual.ITTRichTextBoxControl;
    IQIntelligenceLevelCognitiveEvaluation: TTVisual.ITTTextBoxColumn;
    IQIntelligenceLevelPsychologicEvaluation: TTVisual.ITTTextBoxColumn;
    IQIntelligenceTestReport: TTVisual.ITTGrid;
    IQIntelligenceTestTab: TTVisual.ITTTabPage;
    IQTestObjectiveResultIQLevel: TTVisual.ITTEnumComboBox;
    JudgmentFunctionCognitiveEvaluation: TTVisual.ITTTextBoxColumn;
    KentEGYTest: TTVisual.ITTCheckBox;
    labelDoctorStatement: TTVisual.ITTLabel;
    labelImportantNoteAboutApplication: TTVisual.ITTLabel;
    labelInformationTakenFromParent: TTVisual.ITTLabel;
    labelIQTestObjectiveResultIQLevel: TTVisual.ITTLabel;
    labelRequestDoctor: TTVisual.ITTLabel;
    LanguageCognitiveEvaluation: TTVisual.ITTTextBoxColumn;
    LearnDifficultyDetermination: TTVisual.ITTCheckBox;
    LongTermMemoryFunctionCognitiveEvaluation: TTVisual.ITTTextBoxColumn;
    LongTermMemoryFunctionPsychologicEvaluation: TTVisual.ITTTextBoxColumn;
    MajorMotorEvolutionEarlyChildGrowthEvaluation: TTVisual.ITTTextBoxColumn;
    MazesVerbalAndPerformanceTests: TTVisual.ITTTextBoxColumn;
    MoodDisorderPsychologicEvaluation: TTVisual.ITTTextBoxColumn;
    ObservationDiscussionEvalNoteCognitiveEvaluation: TTVisual.ITTTextBoxColumn;
    ObservationDiscussionEvalNotePsychologicEvaluation: TTVisual.ITTTextBoxColumn;
    OrientationCognitiveEvaluation: TTVisual.ITTTextBoxColumn;
    OtherCognitiveEvaluation: TTVisual.ITTTextBoxColumn;
    PasswordVerbalAndPerformanceTests: TTVisual.ITTTextBoxColumn;
    PatientJobCognitiveEvaluation: TTVisual.ITTListBoxColumn;
    PatientJobIQIntelligenceTestReport: TTVisual.ITTListBoxColumn;
    PatientJobPsychologicEvaluation: TTVisual.ITTListBoxColumn;
    PatternWithCubesVerbalAndPerformanceTests: TTVisual.ITTTextBoxColumn;
    PeabodyPictureVocabularyTest: TTVisual.ITTCheckBox;
    PerformanceIntelligenceIQIntelligenceTestReport: TTVisual.ITTTextBoxColumn;
    PersonalPathologyOrDeviationPsychologicEvaluation: TTVisual.ITTTextBoxColumn;
    PieceAssemblyVerbalAndPerformanceTests: TTVisual.ITTTextBoxColumn;
    ProcedureDoctorCognitiveEvaluation: TTVisual.ITTListBoxColumn;
    ProcedureDoctorEarlyChildGrowthEvaluation: TTVisual.ITTListBoxColumn;
    ProcedureDoctorIQIntelligenceTestReport: TTVisual.ITTListBoxColumn;
    ProcedureDoctorPsychologicEvaluation: TTVisual.ITTListBoxColumn;
    ProteusMazeTest: TTVisual.ITTCheckBox;
    PsychologicEvaluation: TTVisual.ITTGrid;
    PsychologicEvaluationTab: TTVisual.ITTTabPage;
    PsychologyAuthorizedUsers: TTVisual.ITTGrid;
    PsychologyBasedObjectCognitiveEvaluation: TTVisual.ITTListBoxColumn;
    PsychologyBasedObjectIQIntelligenceTestReport: TTVisual.ITTListBoxColumn;
    PsychologyBasedObjectPsychologicEvaluation: TTVisual.ITTListBoxColumn;
    PsychologyBasedObjectVerbalAndPerformanceTests: TTVisual.ITTListBoxColumn;
    PsychomotorEvolutionEarlyChildGrowthEvaluation: TTVisual.ITTTextBoxColumn;
    PsychopathologicalDeviationPsychologicEvaluation: TTVisual.ITTTextBoxColumn;
    PsychopathologicalDisorderPsychologicEvaluation: TTVisual.ITTTextBoxColumn;
    ReasoningFunctionCognitiveEvaluation: TTVisual.ITTTextBoxColumn;
    RecordingMemory: TTVisual.ITTTextBoxColumn;
    RemembranceCognitiveEvaluation: TTVisual.ITTTextBoxColumn;
    RequestDoctor: TTVisual.ITTObjectListBox;
    RequestDoctorCognitiveEvaluation: TTVisual.ITTListBoxColumn;
    RequestDoctorEarlyChildGrowthEvaluation: TTVisual.ITTListBoxColumn;
    RequestDoctorIQIntelligenceTestReport: TTVisual.ITTListBoxColumn;
    RequestDoctorPsychologicEvaluation: TTVisual.ITTListBoxColumn;
    ResultCognitiveEvaluation: TTVisual.ITTTextBoxColumn;
    ResultEarlyChildGrowthEvaluation: TTVisual.ITTTextBoxColumn;
    ResultPsychologicEvaluation: TTVisual.ITTTextBoxColumn;
    ResUserPsychologyAuthorizedUser: TTVisual.ITTListBoxColumn;
    ShortTermMemoryFunctionCognitiveEvaluation: TTVisual.ITTTextBoxColumn;
    ShortTermMemoryFunctionPsychologicEvaluation: TTVisual.ITTTextBoxColumn;
    SimilaritiesVerbalAndPerformanceTests: TTVisual.ITTTextBoxColumn;
    SocialEducationRetardationSitCognitiveEvaluation: TTVisual.ITTTextBoxColumn;
    SocialEducationRetardationSitPsychologicEvaluation: TTVisual.ITTTextBoxColumn;
    SocialSkillSelfCareEvolLevelEarlyChildGrowthEvaluation: TTVisual.ITTTextBoxColumn;
    TestXXXXXXIQIntelligenceTestReport: TTVisual.ITTTextBoxColumn;
    TestPurposeIQIntelligenceTestReport: TTVisual.ITTTextBoxColumn;
    TherapyReport: TTVisual.ITTRichTextBoxControl;
    ThinMotorEvolutionEarlyChildGrowthEvaluation: TTVisual.ITTTextBoxColumn;
    TongueCognitiveEvolutionLevelEarlyChildGrowthEvaluation: TTVisual.ITTTextBoxColumn;
    TotalIntelligenceIQIntelligenceTestReport: TTVisual.ITTTextBoxColumn;
    TrialVerbalAndPerformanceTests: TTVisual.ITTTextBoxColumn;
    ttgrid1: TTVisual.ITTGrid;
    tttabcontrol1: TTVisual.ITTTabControl;
    VerbalAndPerformanceTests: TTVisual.ITTGrid;
    VerbalAndPerformanceTestTab: TTVisual.ITTTabPage;
    VerbalIntelligenceIQIntelligenceTestReport: TTVisual.ITTTextBoxColumn;
    VisibleForProcAndRequestDoc: TTVisual.ITTCheckBox;
    VisibleForProcedureDoctor: TTVisual.ITTCheckBox;
    VisibleForPsychologyUnit: TTVisual.ITTCheckBox;
    VisibleForSelectedUsers: TTVisual.ITTCheckBox;
    VocabularyVerbalAndPerformanceTests: TTVisual.ITTTextBoxColumn;
    WISCR: TTVisual.ITTCheckBox;
    public InformationTakenFromParentVisibility: boolean = false;
    public SelectedUsersVisibility: boolean = false;
    public EarlyChildGrowthEvaluationColumns = [];
    public IQIntelligenceTestReportColumns = [];
    public PsychologicEvaluationColumns = [];
    public PsychologyAuthorizedUsersColumns = [];
    public ttgrid1Columns = [];
    public VerbalAndPerformanceTestsColumns = [];
    public psychologyBasedObjectFormViewModel: PsychologyBasedObjectFormViewModel = new PsychologyBasedObjectFormViewModel();
    public get _PsychologyBasedObject(): PsychologyBasedObject {
        return this._TTObject as PsychologyBasedObject;
    }
    private PsychologyBasedObjectForm_DocumentUrl: string = '/api/PsychologyBasedObjectService/PsychologyBasedObjectForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService); //super('PSYCHOLOGYBASEDOBJECT', 'PsychologyBasedObjectForm');
        this._DocumentServiceUrl = this.PsychologyBasedObjectForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }
    // ***** Method declarations start *****
isloaded: boolean = false;
    @Input() set objectId(value: Guid) {
        if (value != null && this.isloaded == false) {
            this.ObjectID = value;
            this.load();
            this.isloaded = true;
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PsychologyBasedObject();
        this.psychologyBasedObjectFormViewModel = new PsychologyBasedObjectFormViewModel();
        this._ViewModel = this.psychologyBasedObjectFormViewModel;
        this.psychologyBasedObjectFormViewModel._PsychologyBasedObject = this._TTObject as PsychologyBasedObject;
        this.psychologyBasedObjectFormViewModel._PsychologyBasedObject.PsychologyAuthorizedUsers = new Array<PsychologyAuthorizedUser>();
        this.psychologyBasedObjectFormViewModel._PsychologyBasedObject.RequestDoctor = new ResUser();
        this.psychologyBasedObjectFormViewModel._PsychologyBasedObject.IQIntelligenceTestReport = new Array<IQIntelligenceTestReport>();
        this.psychologyBasedObjectFormViewModel._PsychologyBasedObject.VerbalAndPerformanceTests = new Array<VerbalAndPerformanceTests>();
        this.psychologyBasedObjectFormViewModel._PsychologyBasedObject.CognitiveEvaluation = new Array<CognitiveEvaluation>();
        this.psychologyBasedObjectFormViewModel._PsychologyBasedObject.PsychologicEvaluation = new Array<PsychologicEvaluation>();
    }

    protected loadViewModel() {
        let that = this;

        that.psychologyBasedObjectFormViewModel = this._ViewModel as PsychologyBasedObjectFormViewModel;
        that._TTObject = this.psychologyBasedObjectFormViewModel._PsychologyBasedObject;
        if (this.psychologyBasedObjectFormViewModel == null)
            this.psychologyBasedObjectFormViewModel = new PsychologyBasedObjectFormViewModel();
        if (this.psychologyBasedObjectFormViewModel._PsychologyBasedObject == null)
            this.psychologyBasedObjectFormViewModel._PsychologyBasedObject = new PsychologyBasedObject();
        that.psychologyBasedObjectFormViewModel._PsychologyBasedObject.PsychologyAuthorizedUsers = that.psychologyBasedObjectFormViewModel.PsychologyAuthorizedUsersGridList;
        for (let detailItem of that.psychologyBasedObjectFormViewModel.PsychologyAuthorizedUsersGridList) {
            let resUserObjectID = detailItem["ResUser"];
            if (resUserObjectID != null && (typeof resUserObjectID === "string")) {
                let resUser = that.psychologyBasedObjectFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
                 if (resUser) {
                    detailItem.ResUser = resUser;
                }
            }
        }
        let requestDoctorObjectID = that.psychologyBasedObjectFormViewModel._PsychologyBasedObject["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === "string")) {
            let requestDoctor = that.psychologyBasedObjectFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
             if (requestDoctor) {
                that.psychologyBasedObjectFormViewModel._PsychologyBasedObject.RequestDoctor = requestDoctor;
            }
        }
        that.psychologyBasedObjectFormViewModel._PsychologyBasedObject.IQIntelligenceTestReport = that.psychologyBasedObjectFormViewModel.IQIntelligenceTestReportGridList;
        /*for (let detailItem of that.psychologyBasedObjectFormViewModel.IQIntelligenceTestReportGridList) {
            let addedUserObjectID = detailItem["AddedUser"];
            if (addedUserObjectID != null && (typeof addedUserObjectID === "string")) {
                let addedUser = that.psychologyBasedObjectFormViewModel.ResUsers.find(o => o.ObjectID.toString() === addedUserObjectID.toString());
                detailItem.AddedUser = addedUser;
            }
            let procedureDoctorObjectID = detailItem["ProcedureDoctor"];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
                let procedureDoctor = that.psychologyBasedObjectFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                detailItem.ProcedureDoctor = procedureDoctor;
            }
            let psychologyBasedObjectObjectID = detailItem["PsychologyBasedObject"];
            if (psychologyBasedObjectObjectID != null && (typeof psychologyBasedObjectObjectID === "string")) {
                let psychologyBasedObject = that.psychologyBasedObjectFormViewModel.PsychologyBasedObjects.find(o => o.ObjectID.toString() === psychologyBasedObjectObjectID.toString());
                detailItem.PsychologyBasedObject = psychologyBasedObject;
                if (psychologyBasedObject != null) {
                    let requestDoctorObjectID = psychologyBasedObject["RequestDoctor"];
                    if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === "string")) {
                        let requestDoctor = that.psychologyBasedObjectFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
                        psychologyBasedObject.RequestDoctor = requestDoctor;
                    }
                }
            }
            let educationStatusObjectID = detailItem["EducationStatus"];
            if (educationStatusObjectID != null && (typeof educationStatusObjectID === "string")) {
                let educationStatus = that.psychologyBasedObjectFormViewModel.SKRSOgrenimDurumus.find(o => o.ObjectID.toString() === educationStatusObjectID.toString());
                detailItem.EducationStatus = educationStatus;
            }
            let patientJobObjectID = detailItem["PatientJob"];
            if (patientJobObjectID != null && (typeof patientJobObjectID === "string")) {
                let patientJob = that.psychologyBasedObjectFormViewModel.SKRSMesleklers.find(o => o.ObjectID.toString() === patientJobObjectID.toString());
                detailItem.PatientJob = patientJob;
            }
        }
        that.psychologyBasedObjectFormViewModel._PsychologyBasedObject.VerbalAndPerformanceTests = that.psychologyBasedObjectFormViewModel.VerbalAndPerformanceTestsGridList;
        for (let detailItem of that.psychologyBasedObjectFormViewModel.VerbalAndPerformanceTestsGridList) {
            let psychologyBasedObjectObjectID = detailItem["PsychologyBasedObject"];
            if (psychologyBasedObjectObjectID != null && (typeof psychologyBasedObjectObjectID === "string")) {
                let psychologyBasedObject = that.psychologyBasedObjectFormViewModel.PsychologyBasedObjects.find(o => o.ObjectID.toString() === psychologyBasedObjectObjectID.toString());
                detailItem.PsychologyBasedObject = psychologyBasedObject;
            }
        }
        that.psychologyBasedObjectFormViewModel._PsychologyBasedObject.CognitiveEvaluation = that.psychologyBasedObjectFormViewModel.ttgrid1GridList;
        for (let detailItem of that.psychologyBasedObjectFormViewModel.ttgrid1GridList) {
            let addedUserObjectID = detailItem["AddedUser"];
            if (addedUserObjectID != null && (typeof addedUserObjectID === "string")) {
                let addedUser = that.psychologyBasedObjectFormViewModel.ResUsers.find(o => o.ObjectID.toString() === addedUserObjectID.toString());
                detailItem.AddedUser = addedUser;
            }
            let procedureDoctorObjectID = detailItem["ProcedureDoctor"];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
                let procedureDoctor = that.psychologyBasedObjectFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                detailItem.ProcedureDoctor = procedureDoctor;
            }
            let psychologyBasedObjectObjectID = detailItem["PsychologyBasedObject"];
            if (psychologyBasedObjectObjectID != null && (typeof psychologyBasedObjectObjectID === "string")) {
                let psychologyBasedObject = that.psychologyBasedObjectFormViewModel.PsychologyBasedObjects.find(o => o.ObjectID.toString() === psychologyBasedObjectObjectID.toString());
                detailItem.PsychologyBasedObject = psychologyBasedObject;
                if (psychologyBasedObject != null) {
                    let requestDoctorObjectID = psychologyBasedObject["RequestDoctor"];
                    if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === "string")) {
                        let requestDoctor = that.psychologyBasedObjectFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
                        psychologyBasedObject.RequestDoctor = requestDoctor;
                    }
                }
            }
            let educationStatusObjectID = detailItem["EducationStatus"];
            if (educationStatusObjectID != null && (typeof educationStatusObjectID === "string")) {
                let educationStatus = that.psychologyBasedObjectFormViewModel.SKRSOgrenimDurumus.find(o => o.ObjectID.toString() === educationStatusObjectID.toString());
                detailItem.EducationStatus = educationStatus;
            }
            let patientJobObjectID = detailItem["PatientJob"];
            if (patientJobObjectID != null && (typeof patientJobObjectID === "string")) {
                let patientJob = that.psychologyBasedObjectFormViewModel.SKRSMesleklers.find(o => o.ObjectID.toString() === patientJobObjectID.toString());
                detailItem.PatientJob = patientJob;
            }
        }
        that.psychologyBasedObjectFormViewModel._PsychologyBasedObject.PsychologicEvaluation = that.psychologyBasedObjectFormViewModel.PsychologicEvaluationGridList;
        for (let detailItem of that.psychologyBasedObjectFormViewModel.PsychologicEvaluationGridList) {
            let addedUserObjectID = detailItem["AddedUser"];
            if (addedUserObjectID != null && (typeof addedUserObjectID === "string")) {
                let addedUser = that.psychologyBasedObjectFormViewModel.ResUsers.find(o => o.ObjectID.toString() === addedUserObjectID.toString());
                detailItem.AddedUser = addedUser;
            }
            let procedureDoctorObjectID = detailItem["ProcedureDoctor"];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
                let procedureDoctor = that.psychologyBasedObjectFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                detailItem.ProcedureDoctor = procedureDoctor;
            }
            let psychologyBasedObjectObjectID = detailItem["PsychologyBasedObject"];
            if (psychologyBasedObjectObjectID != null && (typeof psychologyBasedObjectObjectID === "string")) {
                let psychologyBasedObject = that.psychologyBasedObjectFormViewModel.PsychologyBasedObjects.find(o => o.ObjectID.toString() === psychologyBasedObjectObjectID.toString());
                detailItem.PsychologyBasedObject = psychologyBasedObject;
                if (psychologyBasedObject != null) {
                    let requestDoctorObjectID = psychologyBasedObject["RequestDoctor"];
                    if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === "string")) {
                        let requestDoctor = that.psychologyBasedObjectFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
                        psychologyBasedObject.RequestDoctor = requestDoctor;
                    }
                }
            }
            let patientJobObjectID = detailItem["PatientJob"];
            if (patientJobObjectID != null && (typeof patientJobObjectID === "string")) {
                let patientJob = that.psychologyBasedObjectFormViewModel.SKRSMesleklers.find(o => o.ObjectID.toString() === patientJobObjectID.toString());
                detailItem.PatientJob = patientJob;
            }
            let educationStatusObjectID = detailItem["EducationStatus"];
            if (educationStatusObjectID != null && (typeof educationStatusObjectID === "string")) {
                let educationStatus = that.psychologyBasedObjectFormViewModel.SKRSOgrenimDurumus.find(o => o.ObjectID.toString() === educationStatusObjectID.toString());
                detailItem.EducationStatus = educationStatus;
            }
        }*/

        if (this.psychologyBasedObjectFormViewModel._PsychologyBasedObject.VisibleForSelectedUsers == true)
            this.SelectedUsersVisibility = true;

    }
             //------------------------------------------
    public saveComponentForms: boolean;
    public evalFormComponentInfo: DynamicComponentInfo;
    public evalFormQueryParameters: QueryParams;
    public verbalAndPerformanceTestsFormComponentInfo: DynamicComponentInfo;
    public verbalAndPerformanceTestsFormQueryParameters: QueryParams;
    public cognitiveEvaluationFormComponentInfo: DynamicComponentInfo;
    public cognitiveEvaluationFormQueryParameters: QueryParams;
    public earlyChildGrowthEvalFormComponentInfo: DynamicComponentInfo;
    public earlyChildGrowthEvalFormQueryParameters: QueryParams;
    public iqIntelligenceTestReportFormComponentInfo: DynamicComponentInfo;
    public iqIntelligenceTestReportFormQueryParameters: QueryParams;

    protected getPsychologicEvaluationFormInfo() {
        let queryParameters = new QueryParams();
        queryParameters.ObjectDefID = new Guid('36a11fb1-689d-4d12-b4c6-ba744b4f6a5a');
        queryParameters.QueryDefID = new Guid('ece33fd5-abf0-4ffe-ad83-4b4e5aefe024');
        let parameters = {};
        parameters['EPISODE'] = new GuidParam(this.psychologyBasedObjectFormViewModel.EpisodeId);
        queryParameters.Parameters = parameters;
        this.evalFormQueryParameters = queryParameters;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'PsychologicEvaluationForm';
        componentInfo.ModuleName = 'PsikologModule';
        componentInfo.ModulePath = '/Modules/Tibbi_Surec/Psikolog_Modulu/PsikologModule';
        componentInfo.InputParam = new DynamicComponentInputParam(<any>this.psychologyBasedObjectFormViewModel._PsychologyBasedObject, null);
        this.evalFormComponentInfo = componentInfo;
    }
    protected getCognitiveEvaluationFormInfo() {
        let queryParameters = new QueryParams();
        queryParameters.ObjectDefID = new Guid('655732ac-5572-4f6a-9016-86fd419e0d7c');
        queryParameters.QueryDefID = new Guid('e48347f1-804f-42c0-9628-f29b8a09f69c');
        let parameters = {};
        parameters['EPISODE'] = new GuidParam(this.psychologyBasedObjectFormViewModel.EpisodeId);
        queryParameters.Parameters = parameters;
        this.cognitiveEvaluationFormQueryParameters = queryParameters;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'CognitiveEvaluationForm';
        componentInfo.ModuleName = 'PsikologModule';
        componentInfo.ModulePath = '/Modules/Tibbi_Surec/Psikolog_Modulu/PsikologModule';
        componentInfo.InputParam = new DynamicComponentInputParam(<any>this.psychologyBasedObjectFormViewModel._PsychologyBasedObject, null);
        this.cognitiveEvaluationFormComponentInfo = componentInfo;
    }
    protected getIQIntelligenceTestReportFormInfo() {
        let queryParameters = new QueryParams();
        queryParameters.ObjectDefID = new Guid('ca2bde5d-9cb5-4966-9b43-57323066a6cd');
        queryParameters.QueryDefID = new Guid('a3c1f4eb-b78d-471b-afaf-370ccfa53352');
        let parameters = {};
        parameters['EPISODE'] = new GuidParam(this.psychologyBasedObjectFormViewModel.EpisodeId);
        queryParameters.Parameters = parameters;
        this.iqIntelligenceTestReportFormQueryParameters = queryParameters;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'IQIntelligenceTestReportForm';
        componentInfo.ModuleName = 'PsikologModule';
        componentInfo.ModulePath = '/Modules/Tibbi_Surec/Psikolog_Modulu/PsikologModule';
        componentInfo.InputParam = new DynamicComponentInputParam(<any>this.psychologyBasedObjectFormViewModel._PsychologyBasedObject, null);
        this.iqIntelligenceTestReportFormComponentInfo = componentInfo;
    }
    protected getEarlyChildGrowthEvalFormInfo() {
        let queryParameters = new QueryParams();
        queryParameters.ObjectDefID = new Guid('35f0634b-e209-4561-82f5-3fb402a7235e');
        queryParameters.QueryDefID = new Guid('8a387763-13b6-4f85-a1bc-ca1b0922f283');
        let parameters = {};
        parameters['EPISODE'] = new GuidParam(this.psychologyBasedObjectFormViewModel.EpisodeId);
        queryParameters.Parameters = parameters;
        this.earlyChildGrowthEvalFormQueryParameters = queryParameters;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'EarlyChildGrowthEvalForm';
        componentInfo.ModuleName = 'PsikologModule';
        componentInfo.ModulePath = '/Modules/Tibbi_Surec/Psikolog_Modulu/PsikologModule';
        componentInfo.InputParam = new DynamicComponentInputParam(<any>this.psychologyBasedObjectFormViewModel._PsychologyBasedObject, null);
        this.earlyChildGrowthEvalFormComponentInfo = componentInfo;
    }
    protected getVerbalAndPerformanceTestsFormInfo() {
        let queryParameters = new QueryParams();
        queryParameters.ObjectDefID = new Guid('97786850-2114-4548-a638-ee5f4332f5af');
        queryParameters.QueryDefID = new Guid('200a3bd2-004f-4be9-aef6-ea04d45c5e2f');
        let parameters = {};
        parameters['EPISODE'] = new GuidParam(this.psychologyBasedObjectFormViewModel.EpisodeId);
        queryParameters.Parameters = parameters;
        this.verbalAndPerformanceTestsFormQueryParameters = queryParameters;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'VerbalAndPerformanceTestsForm';
        componentInfo.ModuleName = 'PsikologModule';
        componentInfo.ModulePath = '/Modules/Tibbi_Surec/Psikolog_Modulu/PsikologModule';
        componentInfo.InputParam = new DynamicComponentInputParam(<any>this.psychologyBasedObjectFormViewModel._PsychologyBasedObject, null);
        this.verbalAndPerformanceTestsFormComponentInfo = componentInfo;
    }
    protected async PreScript() {
        super.PreScript();
        this.getPsychologicEvaluationFormInfo();
        this.getVerbalAndPerformanceTestsFormInfo();
        this.getCognitiveEvaluationFormInfo();
        this.getEarlyChildGrowthEvalFormInfo();
        this.getIQIntelligenceTestReportFormInfo();
    }

    componentQueryResultLoaded(e: any) {
        this.queryResultLoaded(e);
    }
    public queryResultLoaded(e: any) {


        let columns = e as Array<any>;
        for (let column of columns) {
            if (column.dataField === "ADDEDDATE") {
                column.caption = i18n("M13552", "Eklendiği Tarih");
                column.Width = '550px';
            }
            if (column.dataField === "ADDEDUSER") {
                column.caption = 'Ekleyen Kullanıcı';
                column.Width = '550px';
            }
            if (column.dataField === "PROCEDUREDOCTOR") {
                column.caption = i18n("M23275", "Testi Uygulayan Psikolog");
                column.Width = '550px';
            }

        }
    }

    //------------------------------------------


    async ngOnInit()  {
        let that = this;
        if (this.isloaded == false) {
            if (this.ObjectID != null && this.ObjectID != Guid.Empty)
                await this.load(PsychologyBasedObjectFormViewModel);
        }
  
    }


    public onBinetTermanTestChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.BinetTermanTest != event) {
                this._PsychologyBasedObject.BinetTermanTest = event;
            }
        }
    }

    public onCattelIntelligenceTestChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.CattelIntelligenceTest != event) {
                this._PsychologyBasedObject.CattelIntelligenceTest = event;
            }
        }
    }

    public onDoctorStatementChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.DoctorStatement != event) {
                this._PsychologyBasedObject.DoctorStatement = event;
            }
        }
    }

    /*public onFormAuthorityChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.FormAuthority != event) {
                this._PsychologyBasedObject.FormAuthority = event;
            }
        }
        if (event === 3) {
                this.SelectedUsersVisibility = true;
            } else {
                this.SelectedUsersVisibility = false;
            }
    }*/

    public onGoodEnoughHarrisDrawingTestChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.GoodEnoughHarrisDrawingTest != event) {
                this._PsychologyBasedObject.GoodEnoughHarrisDrawingTest = event;
            }
        }
    }

    public onTherapyReportChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.TherapyReport != event) {
                this._PsychologyBasedObject.TherapyReport = event;
            }
        }
    }

    public onImportantNoteAboutApplicationChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.ImportantNoteAboutApplication != event) {
                this._PsychologyBasedObject.ImportantNoteAboutApplication = event;
            }
            if (event === 3) {
                this.InformationTakenFromParentVisibility = true;
            } else {
                this.InformationTakenFromParentVisibility = false;
            }
        }
    }

    public onInformationTakenFromParentChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.InformationTakenFromParent != event) {
                this._PsychologyBasedObject.InformationTakenFromParent = event;
            }
        }
    }

    public onIQTestObjectiveResultIQLevelChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.IQTestObjectiveResultIQLevel != event) {
                this._PsychologyBasedObject.IQTestObjectiveResultIQLevel = event;
            }
        }
    }

    public onKentEGYTestChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.KentEGYTest != event) {
                this._PsychologyBasedObject.KentEGYTest = event;
            }
        }
    }

    public onLearnDifficultyDeterminationChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.LearnDifficultyDetermination != event) {
                this._PsychologyBasedObject.LearnDifficultyDetermination = event;
            }
        }
    }

    public onPeabodyPictureVocabularyTestChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.PeabodyPictureVocabularyTest != event) {
                this._PsychologyBasedObject.PeabodyPictureVocabularyTest = event;
            }
        }
    }

    public onProteusMazeTestChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.ProteusMazeTest != event) {
                this._PsychologyBasedObject.ProteusMazeTest = event;
            }
        }
    }

    public onRequestDoctorChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.RequestDoctor != event) {
                this._PsychologyBasedObject.RequestDoctor = event;
            }
        }
    }

    public onWISCRChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.WISCR != event) {
                this._PsychologyBasedObject.WISCR = event;
            }
        }
    }

public onVisibleForProcAndRequestDocChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.VisibleForProcAndRequestDoc != event) {
                this._PsychologyBasedObject.VisibleForProcAndRequestDoc = event;
            }
        }
    }

    public onVisibleForProcedureDoctorChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.VisibleForProcedureDoctor != event) {
                this._PsychologyBasedObject.VisibleForProcedureDoctor = event;
            }
        }
    }

    public onVisibleForPsychologyUnitChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.VisibleForPsychologyUnit != event) {
                this._PsychologyBasedObject.VisibleForPsychologyUnit = event;
            }
        }
    }

    public onVisibleForSelectedUsersChanged(event): void {
        if (event != null) {
            if (this._PsychologyBasedObject != null && this._PsychologyBasedObject.VisibleForSelectedUsers != event) {
                this._PsychologyBasedObject.VisibleForSelectedUsers = event;
            }
            if (event === true) {
                this.SelectedUsersVisibility = true;
            } else {
                this.SelectedUsersVisibility = false;
            }
        }

    }

    protected redirectProperties(): void {
        redirectProperty(this.BinetTermanTest, "Value", this.__ttObject, "BinetTermanTest");
        redirectProperty(this.CattelIntelligenceTest, "Value", this.__ttObject, "CattelIntelligenceTest");
        redirectProperty(this.KentEGYTest, "Value", this.__ttObject, "KentEGYTest");
        redirectProperty(this.PeabodyPictureVocabularyTest, "Value", this.__ttObject, "PeabodyPictureVocabularyTest");
        redirectProperty(this.ProteusMazeTest, "Value", this.__ttObject, "ProteusMazeTest");
        redirectProperty(this.WISCR, "Value", this.__ttObject, "WISCR");
        redirectProperty(this.GoodEnoughHarrisDrawingTest, "Value", this.__ttObject, "GoodEnoughHarrisDrawingTest");
        redirectProperty(this.LearnDifficultyDetermination, "Value", this.__ttObject, "LearnDifficultyDetermination");
        redirectProperty(this.ImportantNoteAboutApplication, "Value", this.__ttObject, "ImportantNoteAboutApplication");
        redirectProperty(this.IQTestObjectiveResultIQLevel, "Value", this.__ttObject, "IQTestObjectiveResultIQLevel");
        redirectProperty(this.InformationTakenFromParent, "Rtf", this.__ttObject, "InformationTakenFromParent");
        redirectProperty(this.DoctorStatement, "Rtf", this.__ttObject, "DoctorStatement");
        redirectProperty(this.VisibleForProcedureDoctor, "Value", this.__ttObject, "VisibleForProcedureDoctor");
        redirectProperty(this.VisibleForProcAndRequestDoc, "Value", this.__ttObject, "VisibleForProcAndRequestDoc");
        redirectProperty(this.VisibleForSelectedUsers, "Value", this.__ttObject, "VisibleForSelectedUsers");
        redirectProperty(this.VisibleForPsychologyUnit, "Value", this.__ttObject, "VisibleForPsychologyUnit");
        redirectProperty(this.TherapyReport, "Rtf", this.__ttObject, "TherapyReport");

    }

    public initFormControls(): void {

        this.TherapyReport = new TTVisual.TTRichTextBoxControl();
        this.TherapyReport.Name = "TherapyReport";
        this.TherapyReport.TabIndex = 31;


        this.VisibleForSelectedUsers = new TTVisual.TTCheckBox();
        this.VisibleForSelectedUsers.Value = false;
        this.VisibleForSelectedUsers.Text = i18n("M21107", "Sadece Seçtiğim Kullanıcılar Görebilir");
        this.VisibleForSelectedUsers.Title = i18n("M21107", "Sadece Seçtiğim Kullanıcılar Görebilir");
        this.VisibleForSelectedUsers.Name = "VisibleForSelectedUsers";
        this.VisibleForSelectedUsers.TabIndex = 28;

        this.VisibleForPsychologyUnit = new TTVisual.TTCheckBox();
        this.VisibleForPsychologyUnit.Value = false;
        this.VisibleForPsychologyUnit.Text = i18n("M21106", "Sadece Psikiyatri Branşı ve Psikologlar Görebilir");
        this.VisibleForPsychologyUnit.Title = i18n("M21106", "Sadece Psikiyatri Branşı ve Psikologlar Görebilir");
        this.VisibleForPsychologyUnit.Name = "VisibleForPsychologyUnit";
        this.VisibleForPsychologyUnit.TabIndex = 27;

        this.VisibleForProcAndRequestDoc = new TTVisual.TTCheckBox();
        this.VisibleForProcAndRequestDoc.Value = false;
        this.VisibleForProcAndRequestDoc.Text = i18n("M21101", "Sadece Ben ve İstemi Yapan Hekim Görebilir");
        this.VisibleForProcAndRequestDoc.Title = i18n("M21101", "Sadece Ben ve İstemi Yapan Hekim Görebilir");
        this.VisibleForProcAndRequestDoc.Name = "VisibleForProcAndRequestDoc";
        this.VisibleForProcAndRequestDoc.TabIndex = 26;

        this.VisibleForProcedureDoctor = new TTVisual.TTCheckBox();
        this.VisibleForProcedureDoctor.Value = false;
        this.VisibleForProcedureDoctor.Text = i18n("M21100", "Sadece Ben Görebilirim");
        this.VisibleForProcedureDoctor.Title = i18n("M21100", "Sadece Ben Görebilirim");
        this.VisibleForProcedureDoctor.Name = "VisibleForProcedureDoctor";
        this.VisibleForProcedureDoctor.TabIndex = 25;

        this.PsychologyAuthorizedUsers = new TTVisual.TTGrid();
        this.PsychologyAuthorizedUsers.Name = "PsychologyAuthorizedUsers";
        this.PsychologyAuthorizedUsers.TabIndex = 24;
        this.PsychologyAuthorizedUsers.Height = '175px';
        this.PsychologyAuthorizedUsers.FilterColumnName = "ResUserPsychologyAuthorizedUser";
        this.PsychologyAuthorizedUsers.ShowFilterCombo = true;
        this.PsychologyAuthorizedUsers.AllowUserToAddRows = false;
        this.PsychologyAuthorizedUsers.Filter = { ListDefName: "ResUserListDefinition" };

        this.ResUserPsychologyAuthorizedUser = new TTVisual.TTListBoxColumn();
        this.ResUserPsychologyAuthorizedUser.ListDefName = "ResUserListDefinition";
        this.ResUserPsychologyAuthorizedUser.DataMember = "ResUser";
        this.ResUserPsychologyAuthorizedUser.DisplayIndex = 0;
        this.ResUserPsychologyAuthorizedUser.HeaderText = i18n("M17893", "Kullanıcı");
        this.ResUserPsychologyAuthorizedUser.Name = "ResUserPsychologyAuthorizedUser";
        this.ResUserPsychologyAuthorizedUser.Width = 250;

        /*this.labelFormAuthority = new TTVisual.TTLabel();
        this.labelFormAuthority.Text = "Doldurulan Formları Kimler Görebilir";
        this.labelFormAuthority.Name = "labelFormAuthority";
        this.labelFormAuthority.TabIndex = 23;

        this.FormAuthority = new TTVisual.TTEnumComboBox();
        this.FormAuthority.DataTypeName = "PsychologyFormAuthorityTypesEnum";
        this.FormAuthority.Name = "FormAuthority";
        this.FormAuthority.TabIndex = 22;
*/
        this.DoctorStatement = new TTVisual.TTRichTextBoxControl();
        this.DoctorStatement.Name = "DoctorStatement";
        this.DoctorStatement.TabIndex = 21;

        this.labelDoctorStatement = new TTVisual.TTLabel();
        this.labelDoctorStatement.Text = i18n("M13154", "Doktor Açıklaması");
        this.labelDoctorStatement.Name = "labelDoctorStatement";
        this.labelDoctorStatement.TabIndex = 20;

        this.labelRequestDoctor = new TTVisual.TTLabel();
        this.labelRequestDoctor.Text = i18n("M16690", "İstekte Bulunan Doktor");
        this.labelRequestDoctor.Name = "labelRequestDoctor";
        this.labelRequestDoctor.TabIndex = 18;

        this.RequestDoctor = new TTVisual.TTObjectListBox();
        this.RequestDoctor.ReadOnly = true;
        this.RequestDoctor.ListDefName = "ResUserListDefinition";
        this.RequestDoctor.Name = "RequestDoctor";
        this.RequestDoctor.TabIndex = 17;

        this.AppliedTestsHeader = new TTVisual.TTLabel();
        this.AppliedTestsHeader.Text = i18n("M23790", "Uygulanan Testler");
        this.AppliedTestsHeader.Name = "AppliedTestsHeader";
        this.AppliedTestsHeader.TabIndex = 16;

        this.labelIQTestObjectiveResultIQLevel = new TTVisual.TTLabel();
        this.labelIQTestObjectiveResultIQLevel.Text = i18n("M16015", "IQ Testi Nesnel Sonucu ve IQ Seviyesi");
        this.labelIQTestObjectiveResultIQLevel.Name = "labelIQTestObjectiveResultIQLevel";
        this.labelIQTestObjectiveResultIQLevel.TabIndex = 15;

        this.IQTestObjectiveResultIQLevel = new TTVisual.TTEnumComboBox();
        this.IQTestObjectiveResultIQLevel.DataTypeName = "IQTestResultsAndIQLevelEnum";
        this.IQTestObjectiveResultIQLevel.Name = "IQTestObjectiveResultIQLevel";
        this.IQTestObjectiveResultIQLevel.TabIndex = 14;

        this.InformationTakenFromParent = new TTVisual.TTRichTextBoxControl();
        this.InformationTakenFromParent.Name = "InformationTakenFromParent";
        this.InformationTakenFromParent.TabIndex = 13;
        this.InformationTakenFromParent.Visible = true;


        this.labelInformationTakenFromParent = new TTVisual.TTLabel();
        this.labelInformationTakenFromParent.Text = i18n("M24062", "Veliden Alınan Bilgi");
        this.labelInformationTakenFromParent.Name = "labelInformationTakenFromParent";
        this.labelInformationTakenFromParent.Visible = false;

        this.labelInformationTakenFromParent.TabIndex = 12;

        this.labelImportantNoteAboutApplication = new TTVisual.TTLabel();
        this.labelImportantNoteAboutApplication.Text = i18n("M23777", "Uygulamaya Dair Önemli Not");
        this.labelImportantNoteAboutApplication.Name = "labelImportantNoteAboutApplication";
        this.labelImportantNoteAboutApplication.TabIndex = 10;

        this.ImportantNoteAboutApplication = new TTVisual.TTEnumComboBox();
        this.ImportantNoteAboutApplication.DataTypeName = "ImportantNoteAboutApplicationEnum";
        this.ImportantNoteAboutApplication.Name = "ImportantNoteAboutApplication";
        this.ImportantNoteAboutApplication.TabIndex = 9;

        this.WISCR = new TTVisual.TTCheckBox();
        this.WISCR.Value = false;
        this.WISCR.Text = "WISCR";
        this.WISCR.Title = "WISCR";

        this.WISCR.Name = "WISCR";
        this.WISCR.TabIndex = 8;

        this.ProteusMazeTest = new TTVisual.TTCheckBox();
        this.ProteusMazeTest.Value = false;
        this.ProteusMazeTest.Text = i18n("M20558", "Proteus Labirent Testi");
        this.ProteusMazeTest.Title = i18n("M20558", "Proteus Labirent Testi");

        this.ProteusMazeTest.Name = "ProteusMazeTest";
        this.ProteusMazeTest.TabIndex = 7;

        this.PeabodyPictureVocabularyTest = new TTVisual.TTCheckBox();
        this.PeabodyPictureVocabularyTest.Value = false;
        this.PeabodyPictureVocabularyTest.Text = i18n("M20289", "Peabody Resim Kelime Testi");
        this.PeabodyPictureVocabularyTest.Title = i18n("M20289", "Peabody Resim Kelime Testi");

        this.PeabodyPictureVocabularyTest.Name = "PeabodyPictureVocabularyTest";
        this.PeabodyPictureVocabularyTest.TabIndex = 6;

        this.LearnDifficultyDetermination = new TTVisual.TTCheckBox();
        this.LearnDifficultyDetermination.Value = false;
        this.LearnDifficultyDetermination.Text = i18n("M19902", "Öğrenme Güçlüğü Seviye Tespit Formu");
        this.LearnDifficultyDetermination.Title = i18n("M19902", "Öğrenme Güçlüğü Seviye Tespit Formu");

        this.LearnDifficultyDetermination.Name = "LearnDifficultyDetermination";
        this.LearnDifficultyDetermination.TabIndex = 5;

        this.KentEGYTest = new TTVisual.TTCheckBox();
        this.KentEGYTest.Value = false;
        this.KentEGYTest.Text = "Kent EGY Testi";
        this.KentEGYTest.Title = "Kent EGY Testi";

        this.KentEGYTest.Name = "KentEGYTest";
        this.KentEGYTest.TabIndex = 4;

        this.GoodEnoughHarrisDrawingTest = new TTVisual.TTCheckBox();
        this.GoodEnoughHarrisDrawingTest.Value = false;
        this.GoodEnoughHarrisDrawingTest.Text = i18n("M14841", "Good Enough Harris Adam Çizme Testi");
        this.GoodEnoughHarrisDrawingTest.Title = i18n("M14841", "Good Enough Harris Adam Çizme Testi");

        this.GoodEnoughHarrisDrawingTest.Name = "GoodEnoughHarrisDrawingTest";
        this.GoodEnoughHarrisDrawingTest.TabIndex = 3;

        this.CattelIntelligenceTest = new TTVisual.TTCheckBox();
        this.CattelIntelligenceTest.Value = false;
        this.CattelIntelligenceTest.Text = i18n("M12178", "Cattel Zeka Testi");
        this.CattelIntelligenceTest.Title = i18n("M12178", "Cattel Zeka Testi");

        this.CattelIntelligenceTest.Name = "CattelIntelligenceTest";
        this.CattelIntelligenceTest.TabIndex = 2;

        this.BinetTermanTest = new TTVisual.TTCheckBox();
        this.BinetTermanTest.Value = false;
        this.BinetTermanTest.Text = i18n("M11822", "Binet Terman Testi");
        this.BinetTermanTest.Title = i18n("M11822", "Binet Terman Testi");

        this.BinetTermanTest.Name = "BinetTermanTest";
        this.BinetTermanTest.TabIndex = 1;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 0;

        this.EarlyChildGrowthEvalTab = new TTVisual.TTTabPage();
        this.EarlyChildGrowthEvalTab.DisplayIndex = 0;
        this.EarlyChildGrowthEvalTab.TabIndex = 0;
        this.EarlyChildGrowthEvalTab.Text = i18n("M13841", "Erken Çocuk Gelişim Değerlendirme Formu");
        this.EarlyChildGrowthEvalTab.Name = "EarlyChildGrowthEvalTab";

        this.EarlyChildGrowthEvaluation = new TTVisual.TTGrid();
        this.EarlyChildGrowthEvaluation.Name = "EarlyChildGrowthEvaluation";
        this.EarlyChildGrowthEvaluation.TabIndex = 0;

        this.AddedUserEarlyChildGrowthEvaluation = new TTVisual.TTListBoxColumn();
        this.AddedUserEarlyChildGrowthEvaluation.DataMember = "ADDEDUSER";
        this.AddedUserEarlyChildGrowthEvaluation.DisplayIndex = 0;
        this.AddedUserEarlyChildGrowthEvaluation.HeaderText = "Ekleyen Kullanıcı";
        this.AddedUserEarlyChildGrowthEvaluation.Name = "AddedUserEarlyChildGrowthEvaluation";
        this.AddedUserEarlyChildGrowthEvaluation.Width = 300;

        this.ProcedureDoctorEarlyChildGrowthEvaluation = new TTVisual.TTListBoxColumn();
        this.ProcedureDoctorEarlyChildGrowthEvaluation.DataMember = "PROCEDUREDOCTOR";
        this.ProcedureDoctorEarlyChildGrowthEvaluation.DisplayIndex = 1;
        this.ProcedureDoctorEarlyChildGrowthEvaluation.HeaderText = i18n("M23274", "Testi Uygulayan Doktor");
        this.ProcedureDoctorEarlyChildGrowthEvaluation.Name = "ProcedureDoctorEarlyChildGrowthEvaluation";
        this.ProcedureDoctorEarlyChildGrowthEvaluation.Width = 300;

        this.RequestDoctorEarlyChildGrowthEvaluation = new TTVisual.TTListBoxColumn();
        this.RequestDoctorEarlyChildGrowthEvaluation.DataMember = "PSYCHOLOGYBASEDOBJECT.REQUESTDOCTOR";
        this.RequestDoctorEarlyChildGrowthEvaluation.DisplayIndex = 2;
        this.RequestDoctorEarlyChildGrowthEvaluation.HeaderText = i18n("M16690", "İstekte Bulunan Doktor");
        this.RequestDoctorEarlyChildGrowthEvaluation.Name = "RequestDoctorEarlyChildGrowthEvaluation";
        this.RequestDoctorEarlyChildGrowthEvaluation.ReadOnly = true;
        this.RequestDoctorEarlyChildGrowthEvaluation.Width = 100;

        this.AddedDateEarlyChildGrowthEvaluation = new TTVisual.TTDateTimePickerColumn();
        this.AddedDateEarlyChildGrowthEvaluation.DataMember = "ADDEDDATE";
        this.AddedDateEarlyChildGrowthEvaluation.DisplayIndex = 3;
        this.AddedDateEarlyChildGrowthEvaluation.HeaderText = i18n("M13568", "Eklenme Tarihi");
        this.AddedDateEarlyChildGrowthEvaluation.Name = "AddedDateEarlyChildGrowthEvaluation";
        this.AddedDateEarlyChildGrowthEvaluation.Width = 180;

        this.CognitiveEvolutionEarlyChildGrowthEvaluation = new TTVisual.TTTextBoxColumn();
        this.CognitiveEvolutionEarlyChildGrowthEvaluation.DataMember = "COGNITIVEEVOLUTION";
        this.CognitiveEvolutionEarlyChildGrowthEvaluation.DisplayIndex = 4;
        this.CognitiveEvolutionEarlyChildGrowthEvaluation.HeaderText = i18n("M11809", "Bilişsel Gelişimi");
        this.CognitiveEvolutionEarlyChildGrowthEvaluation.Name = "CognitiveEvolutionEarlyChildGrowthEvaluation";
        this.CognitiveEvolutionEarlyChildGrowthEvaluation.Width = 80;

        this.GeneralEvolutionLevelEarlyChildGrowthEvaluation = new TTVisual.TTTextBoxColumn();
        this.GeneralEvolutionLevelEarlyChildGrowthEvaluation.DataMember = "GENERALEVOLUTIONLEVEL";
        this.GeneralEvolutionLevelEarlyChildGrowthEvaluation.DisplayIndex = 5;
        this.GeneralEvolutionLevelEarlyChildGrowthEvaluation.HeaderText = i18n("M14690", "Genel Gelişim Düzeyi");
        this.GeneralEvolutionLevelEarlyChildGrowthEvaluation.Name = "GeneralEvolutionLevelEarlyChildGrowthEvaluation";
        this.GeneralEvolutionLevelEarlyChildGrowthEvaluation.Width = 80;

        this.MajorMotorEvolutionEarlyChildGrowthEvaluation = new TTVisual.TTTextBoxColumn();
        this.MajorMotorEvolutionEarlyChildGrowthEvaluation.DataMember = "MAJORMOTOREVOLUTION";
        this.MajorMotorEvolutionEarlyChildGrowthEvaluation.DisplayIndex = 6;
        this.MajorMotorEvolutionEarlyChildGrowthEvaluation.HeaderText = i18n("M17003", "Kaba Motor Gelişimi");
        this.MajorMotorEvolutionEarlyChildGrowthEvaluation.Name = "MajorMotorEvolutionEarlyChildGrowthEvaluation";
        this.MajorMotorEvolutionEarlyChildGrowthEvaluation.Width = 80;

        this.PsychomotorEvolutionEarlyChildGrowthEvaluation = new TTVisual.TTTextBoxColumn();
        this.PsychomotorEvolutionEarlyChildGrowthEvaluation.DataMember = "PSYCHOMOTOREVOLUTION";
        this.PsychomotorEvolutionEarlyChildGrowthEvaluation.DisplayIndex = 7;
        this.PsychomotorEvolutionEarlyChildGrowthEvaluation.HeaderText = i18n("M20614", "Psikomotor Gelişimi");
        this.PsychomotorEvolutionEarlyChildGrowthEvaluation.Name = "PsychomotorEvolutionEarlyChildGrowthEvaluation";
        this.PsychomotorEvolutionEarlyChildGrowthEvaluation.Width = 80;

        this.ResultEarlyChildGrowthEvaluation = new TTVisual.TTTextBoxColumn();
        this.ResultEarlyChildGrowthEvaluation.DataMember = "RESULT";
        this.ResultEarlyChildGrowthEvaluation.DisplayIndex = 8;
        this.ResultEarlyChildGrowthEvaluation.HeaderText = i18n("M22078", "Sonuç");
        this.ResultEarlyChildGrowthEvaluation.Name = "ResultEarlyChildGrowthEvaluation";
        this.ResultEarlyChildGrowthEvaluation.Width = 80;

        this.SocialSkillSelfCareEvolLevelEarlyChildGrowthEvaluation = new TTVisual.TTTextBoxColumn();
        this.SocialSkillSelfCareEvolLevelEarlyChildGrowthEvaluation.DataMember = "SOCIALSKILLSELFCAREEVOLLEVEL";
        this.SocialSkillSelfCareEvolLevelEarlyChildGrowthEvaluation.DisplayIndex = 9;
        this.SocialSkillSelfCareEvolLevelEarlyChildGrowthEvaluation.HeaderText = i18n("M22168", "Sosyal Beceri / Özbakım Gelişim Düzeyi");
        this.SocialSkillSelfCareEvolLevelEarlyChildGrowthEvaluation.Name = "SocialSkillSelfCareEvolLevelEarlyChildGrowthEvaluation";
        this.SocialSkillSelfCareEvolLevelEarlyChildGrowthEvaluation.Width = 80;

        this.ThinMotorEvolutionEarlyChildGrowthEvaluation = new TTVisual.TTTextBoxColumn();
        this.ThinMotorEvolutionEarlyChildGrowthEvaluation.DataMember = "THINMOTOREVOLUTION";
        this.ThinMotorEvolutionEarlyChildGrowthEvaluation.DisplayIndex = 10;
        this.ThinMotorEvolutionEarlyChildGrowthEvaluation.HeaderText = i18n("M16482", "İnce Motor Gelişimi");
        this.ThinMotorEvolutionEarlyChildGrowthEvaluation.Name = "ThinMotorEvolutionEarlyChildGrowthEvaluation";
        this.ThinMotorEvolutionEarlyChildGrowthEvaluation.Width = 80;

        this.TongueCognitiveEvolutionLevelEarlyChildGrowthEvaluation = new TTVisual.TTTextBoxColumn();
        this.TongueCognitiveEvolutionLevelEarlyChildGrowthEvaluation.DataMember = "TONGUECOGNITIVEEVOLUTIONLEVEL";
        this.TongueCognitiveEvolutionLevelEarlyChildGrowthEvaluation.DisplayIndex = 11;
        this.TongueCognitiveEvolutionLevelEarlyChildGrowthEvaluation.HeaderText = i18n("M12853", "Dil / Bilişsel Gelişim Düzeyi");
        this.TongueCognitiveEvolutionLevelEarlyChildGrowthEvaluation.Name = "TongueCognitiveEvolutionLevelEarlyChildGrowthEvaluation";
        this.TongueCognitiveEvolutionLevelEarlyChildGrowthEvaluation.Width = 80;

        this.IQIntelligenceTestTab = new TTVisual.TTTabPage();
        this.IQIntelligenceTestTab.DisplayIndex = 1;
        this.IQIntelligenceTestTab.TabIndex = 1;
        this.IQIntelligenceTestTab.Text = i18n("M16018", "IQ Zeka Testi Raporu");
        this.IQIntelligenceTestTab.Name = "IQIntelligenceTestTab";

        this.IQIntelligenceTestReport = new TTVisual.TTGrid();
        this.IQIntelligenceTestReport.Name = "IQIntelligenceTestReport";
        this.IQIntelligenceTestReport.TabIndex = 0;

        this.AddedUserIQIntelligenceTestReport = new TTVisual.TTListBoxColumn();
        this.AddedUserIQIntelligenceTestReport.DataMember = "AddedUser";
        this.AddedUserIQIntelligenceTestReport.DisplayIndex = 0;
        this.AddedUserIQIntelligenceTestReport.HeaderText = "Ekleyen Kullanıcı";
        this.AddedUserIQIntelligenceTestReport.Name = "AddedUserIQIntelligenceTestReport";
        this.AddedUserIQIntelligenceTestReport.Width = 300;

        this.ProcedureDoctorIQIntelligenceTestReport = new TTVisual.TTListBoxColumn();
        this.ProcedureDoctorIQIntelligenceTestReport.DataMember = "ProcedureDoctor";
        this.ProcedureDoctorIQIntelligenceTestReport.DisplayIndex = 1;
        this.ProcedureDoctorIQIntelligenceTestReport.HeaderText = i18n("M23274", "Testi Uygulayan Doktor");
        this.ProcedureDoctorIQIntelligenceTestReport.Name = "ProcedureDoctorIQIntelligenceTestReport";
        this.ProcedureDoctorIQIntelligenceTestReport.Width = 300;

        this.RequestDoctorIQIntelligenceTestReport = new TTVisual.TTListBoxColumn();
        this.RequestDoctorIQIntelligenceTestReport.DataMember = "RequestDoctor";
        this.RequestDoctorIQIntelligenceTestReport.DisplayIndex = 2;
        this.RequestDoctorIQIntelligenceTestReport.HeaderText = i18n("M16690", "İstekte Bulunan Doktor");
        this.RequestDoctorIQIntelligenceTestReport.Name = "RequestDoctorIQIntelligenceTestReport";
        this.RequestDoctorIQIntelligenceTestReport.ReadOnly = true;
        this.RequestDoctorIQIntelligenceTestReport.Width = 100;

        this.EducationStatusIQIntelligenceTestReport = new TTVisual.TTListBoxColumn();
        this.EducationStatusIQIntelligenceTestReport.DataMember = "EducationStatus";
        this.EducationStatusIQIntelligenceTestReport.DisplayIndex = 3;
        this.EducationStatusIQIntelligenceTestReport.HeaderText = i18n("M19901", "Öğrenim Durumu");
        this.EducationStatusIQIntelligenceTestReport.Name = "EducationStatusIQIntelligenceTestReport";
        this.EducationStatusIQIntelligenceTestReport.Width = 300;

        this.PatientJobIQIntelligenceTestReport = new TTVisual.TTListBoxColumn();
        this.PatientJobIQIntelligenceTestReport.DataMember = "PatientJob";
        this.PatientJobIQIntelligenceTestReport.DisplayIndex = 4;
        this.PatientJobIQIntelligenceTestReport.HeaderText = i18n("M18928", "Mesleği");
        this.PatientJobIQIntelligenceTestReport.Name = "PatientJobIQIntelligenceTestReport";
        this.PatientJobIQIntelligenceTestReport.Width = 300;

        this.PsychologyBasedObjectIQIntelligenceTestReport = new TTVisual.TTListBoxColumn();
        this.PsychologyBasedObjectIQIntelligenceTestReport.DataMember = "PsychologyBasedObject";
        this.PsychologyBasedObjectIQIntelligenceTestReport.DisplayIndex = 5;
        this.PsychologyBasedObjectIQIntelligenceTestReport.HeaderText = "";
        this.PsychologyBasedObjectIQIntelligenceTestReport.Name = "PsychologyBasedObjectIQIntelligenceTestReport";
        this.PsychologyBasedObjectIQIntelligenceTestReport.Width = 300;

        this.AddedDateIQIntelligenceTestReport = new TTVisual.TTDateTimePickerColumn();
        this.AddedDateIQIntelligenceTestReport.DataMember = "AddedDate";
        this.AddedDateIQIntelligenceTestReport.DisplayIndex = 6;
        this.AddedDateIQIntelligenceTestReport.HeaderText = i18n("M13568", "Eklenme Tarihi");
        this.AddedDateIQIntelligenceTestReport.Name = 'AddedDateIQIntelligenceTestReport';
        this.AddedDateIQIntelligenceTestReport.Width = 180;

        this.CommentIQIntelligenceTestReport = new TTVisual.TTTextBoxColumn();
        this.CommentIQIntelligenceTestReport.DataMember = 'Comment';
        this.CommentIQIntelligenceTestReport.DisplayIndex = 7;
        this.CommentIQIntelligenceTestReport.HeaderText = i18n("M24713", "Yorum");
        this.CommentIQIntelligenceTestReport.Name = 'CommentIQIntelligenceTestReport';
        this.CommentIQIntelligenceTestReport.Width = 80;

        this.CriticalLifeEventIQIntelligenceTestReport = new TTVisual.TTTextBoxColumn();
        this.CriticalLifeEventIQIntelligenceTestReport.DataMember = 'CriticalLifeEvent';
        this.CriticalLifeEventIQIntelligenceTestReport.DisplayIndex = 8;
        this.CriticalLifeEventIQIntelligenceTestReport.HeaderText = i18n("M17872", "Kritik Yaşam Olayı");
        this.CriticalLifeEventIQIntelligenceTestReport.Name = 'CriticalLifeEventIQIntelligenceTestReport';
        this.CriticalLifeEventIQIntelligenceTestReport.Width = 80;

        this.PerformanceIntelligenceIQIntelligenceTestReport = new TTVisual.TTTextBoxColumn();
        this.PerformanceIntelligenceIQIntelligenceTestReport.DataMember = 'PerformanceIntelligence';
        this.PerformanceIntelligenceIQIntelligenceTestReport.DisplayIndex = 9;
        this.PerformanceIntelligenceIQIntelligenceTestReport.HeaderText = i18n("M20298", "Performans Zeka");
        this.PerformanceIntelligenceIQIntelligenceTestReport.Name = 'PerformanceIntelligenceIQIntelligenceTestReport';
        this.PerformanceIntelligenceIQIntelligenceTestReport.Width = 80;

        this.TestXXXXXXIQIntelligenceTestReport = new TTVisual.TTTextBoxColumn();
        this.TestXXXXXXIQIntelligenceTestReport.DataMember = 'TestXXXXXX';
        this.TestXXXXXXIQIntelligenceTestReport.DisplayIndex = 10;
        this.TestXXXXXXIQIntelligenceTestReport.HeaderText = i18n("M23273", "Testi İsteyen Kişi yada Kurum");
        this.TestXXXXXXIQIntelligenceTestReport.Name = 'TestXXXXXXIQIntelligenceTestReport';
        this.TestXXXXXXIQIntelligenceTestReport.Width = 80;

        this.TestPurposeIQIntelligenceTestReport = new TTVisual.TTTextBoxColumn();
        this.TestPurposeIQIntelligenceTestReport.DataMember = 'TestPurpose';
        this.TestPurposeIQIntelligenceTestReport.DisplayIndex = 11;
        this.TestPurposeIQIntelligenceTestReport.HeaderText = i18n("M23272", "Teste Ne Amaçla Alındığı");
        this.TestPurposeIQIntelligenceTestReport.Name = 'TestPurposeIQIntelligenceTestReport';
        this.TestPurposeIQIntelligenceTestReport.Width = 80;

        this.TotalIntelligenceIQIntelligenceTestReport = new TTVisual.TTTextBoxColumn();
        this.TotalIntelligenceIQIntelligenceTestReport.DataMember = 'TotalIntelligence';
        this.TotalIntelligenceIQIntelligenceTestReport.DisplayIndex = 12;
        this.TotalIntelligenceIQIntelligenceTestReport.HeaderText = i18n("M23527", "Toplam Zeka");
        this.TotalIntelligenceIQIntelligenceTestReport.Name = 'TotalIntelligenceIQIntelligenceTestReport';
        this.TotalIntelligenceIQIntelligenceTestReport.Width = 80;

        this.VerbalIntelligenceIQIntelligenceTestReport = new TTVisual.TTTextBoxColumn();
        this.VerbalIntelligenceIQIntelligenceTestReport.DataMember = 'VerbalIntelligence';
        this.VerbalIntelligenceIQIntelligenceTestReport.DisplayIndex = 13;
        this.VerbalIntelligenceIQIntelligenceTestReport.HeaderText = i18n("M22215", "Sözel Zeka");
        this.VerbalIntelligenceIQIntelligenceTestReport.Name = 'VerbalIntelligenceIQIntelligenceTestReport';
        this.VerbalIntelligenceIQIntelligenceTestReport.Width = 80;

        this.VerbalAndPerformanceTestTab = new TTVisual.TTTabPage();
        this.VerbalAndPerformanceTestTab.DisplayIndex = 2;
        this.VerbalAndPerformanceTestTab.TabIndex = 3;
        this.VerbalAndPerformanceTestTab.Text = i18n("M22214", "Sözel ve Performans Testleri");
        this.VerbalAndPerformanceTestTab.Name = 'VerbalAndPerformanceTestTab';

        this.VerbalAndPerformanceTests = new TTVisual.TTGrid();
        this.VerbalAndPerformanceTests.Name = 'VerbalAndPerformanceTests';
        this.VerbalAndPerformanceTests.TabIndex = 0;

        this.PsychologyBasedObjectVerbalAndPerformanceTests = new TTVisual.TTListBoxColumn();
        this.PsychologyBasedObjectVerbalAndPerformanceTests.DataMember = 'PsychologyBasedObject';
        this.PsychologyBasedObjectVerbalAndPerformanceTests.DisplayIndex = 0;
        this.PsychologyBasedObjectVerbalAndPerformanceTests.HeaderText = '';
        this.PsychologyBasedObjectVerbalAndPerformanceTests.Name = 'PsychologyBasedObjectVerbalAndPerformanceTests';
        this.PsychologyBasedObjectVerbalAndPerformanceTests.Width = 300;

        this.ArithmeticVerbalAndPerformanceTests = new TTVisual.TTTextBoxColumn();
        this.ArithmeticVerbalAndPerformanceTests.DataMember = 'Arithmetic';
        this.ArithmeticVerbalAndPerformanceTests.DisplayIndex = 1;
        this.ArithmeticVerbalAndPerformanceTests.HeaderText = i18n("M11094", "Aritmetik");
        this.ArithmeticVerbalAndPerformanceTests.Name = 'ArithmeticVerbalAndPerformanceTests';
        this.ArithmeticVerbalAndPerformanceTests.Width = 80;

        this.GeneralInformationVerbalAndPerformanceTests = new TTVisual.TTTextBoxColumn();
        this.GeneralInformationVerbalAndPerformanceTests.DataMember = 'GeneralInformation';
        this.GeneralInformationVerbalAndPerformanceTests.DisplayIndex = 2;
        this.GeneralInformationVerbalAndPerformanceTests.HeaderText = i18n("M14680", "Genel Bilgi");
        this.GeneralInformationVerbalAndPerformanceTests.Name = 'GeneralInformationVerbalAndPerformanceTests';
        this.GeneralInformationVerbalAndPerformanceTests.Width = 80;

        this.ImageCompletionVerbalAndPerformanceTests = new TTVisual.TTTextBoxColumn();
        this.ImageCompletionVerbalAndPerformanceTests.DataMember = 'ImageCompletion';
        this.ImageCompletionVerbalAndPerformanceTests.DisplayIndex = 3;
        this.ImageCompletionVerbalAndPerformanceTests.HeaderText = i18n("M21030", "Resim Tamamlama");
        this.ImageCompletionVerbalAndPerformanceTests.Name = 'ImageCompletionVerbalAndPerformanceTests';
        this.ImageCompletionVerbalAndPerformanceTests.Width = 80;

        this.ImageEditingVerbalAndPerformanceTests = new TTVisual.TTTextBoxColumn();
        this.ImageEditingVerbalAndPerformanceTests.DataMember = 'ImageEditing';
        this.ImageEditingVerbalAndPerformanceTests.DisplayIndex = 4;
        this.ImageEditingVerbalAndPerformanceTests.HeaderText = i18n("M21028", "Resim Düzenleme");
        this.ImageEditingVerbalAndPerformanceTests.Name = 'ImageEditingVerbalAndPerformanceTests';
        this.ImageEditingVerbalAndPerformanceTests.Width = 80;

        this.MazesVerbalAndPerformanceTests = new TTVisual.TTTextBoxColumn();
        this.MazesVerbalAndPerformanceTests.DataMember = 'Mazes';
        this.MazesVerbalAndPerformanceTests.DisplayIndex = 5;
        this.MazesVerbalAndPerformanceTests.HeaderText = i18n("M18158", "Labirentler");
        this.MazesVerbalAndPerformanceTests.Name = 'MazesVerbalAndPerformanceTests';
        this.MazesVerbalAndPerformanceTests.Width = 80;

        this.PasswordVerbalAndPerformanceTests = new TTVisual.TTTextBoxColumn();
        this.PasswordVerbalAndPerformanceTests.DataMember = 'Password';
        this.PasswordVerbalAndPerformanceTests.DisplayIndex = 6;
        this.PasswordVerbalAndPerformanceTests.HeaderText = i18n("M22480", "Şifre");
        this.PasswordVerbalAndPerformanceTests.Name = 'PasswordVerbalAndPerformanceTests';
        this.PasswordVerbalAndPerformanceTests.Width = 80;

        this.PatternWithCubesVerbalAndPerformanceTests = new TTVisual.TTTextBoxColumn();
        this.PatternWithCubesVerbalAndPerformanceTests.DataMember = 'PatternWithCubes';
        this.PatternWithCubesVerbalAndPerformanceTests.DisplayIndex = 7;
        this.PatternWithCubesVerbalAndPerformanceTests.HeaderText = i18n("M18139", "Küplerle Desen");
        this.PatternWithCubesVerbalAndPerformanceTests.Name = 'PatternWithCubesVerbalAndPerformanceTests';
        this.PatternWithCubesVerbalAndPerformanceTests.Width = 80;

        this.PieceAssemblyVerbalAndPerformanceTests = new TTVisual.TTTextBoxColumn();
        this.PieceAssemblyVerbalAndPerformanceTests.DataMember = 'PieceAssembly';
        this.PieceAssemblyVerbalAndPerformanceTests.DisplayIndex = 8;
        this.PieceAssemblyVerbalAndPerformanceTests.HeaderText = i18n("M20206", "Parça Birleştirme");
        this.PieceAssemblyVerbalAndPerformanceTests.Name = 'PieceAssemblyVerbalAndPerformanceTests';
        this.PieceAssemblyVerbalAndPerformanceTests.Width = 80;

        this.SimilaritiesVerbalAndPerformanceTests = new TTVisual.TTTextBoxColumn();
        this.SimilaritiesVerbalAndPerformanceTests.DataMember = 'Similarities';
        this.SimilaritiesVerbalAndPerformanceTests.DisplayIndex = 9;
        this.SimilaritiesVerbalAndPerformanceTests.HeaderText = i18n("M11761", "Benzerlikler");
        this.SimilaritiesVerbalAndPerformanceTests.Name = 'SimilaritiesVerbalAndPerformanceTests';
        this.SimilaritiesVerbalAndPerformanceTests.Width = 80;

        this.TrialVerbalAndPerformanceTests = new TTVisual.TTTextBoxColumn();
        this.TrialVerbalAndPerformanceTests.DataMember = 'Trial';
        this.TrialVerbalAndPerformanceTests.DisplayIndex = 10;
        this.TrialVerbalAndPerformanceTests.HeaderText = i18n("M24324", "Yargılama");
        this.TrialVerbalAndPerformanceTests.Name = 'TrialVerbalAndPerformanceTests';
        this.TrialVerbalAndPerformanceTests.Width = 80;

        this.VocabularyVerbalAndPerformanceTests = new TTVisual.TTTextBoxColumn();
        this.VocabularyVerbalAndPerformanceTests.DataMember = 'Vocabulary';
        this.VocabularyVerbalAndPerformanceTests.DisplayIndex = 11;
        this.VocabularyVerbalAndPerformanceTests.HeaderText = i18n("M22211", "Sözcük Dağarcığı");
        this.VocabularyVerbalAndPerformanceTests.Name = 'VocabularyVerbalAndPerformanceTests';
        this.VocabularyVerbalAndPerformanceTests.Width = 80;

        this.CognitiveEvaluation = new TTVisual.TTTabPage();
        this.CognitiveEvaluation.DisplayIndex = 3;
        this.CognitiveEvaluation.TabIndex = 2;
        this.CognitiveEvaluation.Text = i18n("M17691", "Kognitif Değerlendirme");
        this.CognitiveEvaluation.Name = 'CognitiveEvaluation';

        this.ttgrid1 = new TTVisual.TTGrid();
        this.ttgrid1.Name = 'ttgrid1';
        this.ttgrid1.TabIndex = 0;

        this.AddedUserCognitiveEvaluation = new TTVisual.TTListBoxColumn();
        this.AddedUserCognitiveEvaluation.DataMember = 'AddedUser';
        this.AddedUserCognitiveEvaluation.DisplayIndex = 0;
        this.AddedUserCognitiveEvaluation.HeaderText = 'Ekleyen Kullanıcı';
        this.AddedUserCognitiveEvaluation.Name = 'AddedUserCognitiveEvaluation';
        this.AddedUserCognitiveEvaluation.Width = 300;

        this.ProcedureDoctorCognitiveEvaluation = new TTVisual.TTListBoxColumn();
        this.ProcedureDoctorCognitiveEvaluation.DataMember = 'ProcedureDoctor';
        this.ProcedureDoctorCognitiveEvaluation.DisplayIndex = 1;
        this.ProcedureDoctorCognitiveEvaluation.HeaderText = i18n("M23274", "Testi Uygulayan Doktor");
        this.ProcedureDoctorCognitiveEvaluation.Name = 'ProcedureDoctorCognitiveEvaluation';
        this.ProcedureDoctorCognitiveEvaluation.Width = 300;

        this.RequestDoctorCognitiveEvaluation = new TTVisual.TTListBoxColumn();
        this.RequestDoctorCognitiveEvaluation.DataMember = 'RequestDoctor';
        this.RequestDoctorCognitiveEvaluation.DisplayIndex = 2;
        this.RequestDoctorCognitiveEvaluation.HeaderText = i18n("M16690", "İstekte Bulunan Doktor");
        this.RequestDoctorCognitiveEvaluation.Name = 'RequestDoctorCognitiveEvaluation';
        this.RequestDoctorCognitiveEvaluation.ReadOnly = true;
        this.RequestDoctorCognitiveEvaluation.Width = 100;

        this.EducationStatusCognitiveEvaluation = new TTVisual.TTListBoxColumn();
        this.EducationStatusCognitiveEvaluation.DataMember = 'EducationStatus';
        this.EducationStatusCognitiveEvaluation.DisplayIndex = 3;
        this.EducationStatusCognitiveEvaluation.HeaderText = i18n("M19901", "Öğrenim Durumu");
        this.EducationStatusCognitiveEvaluation.Name = 'EducationStatusCognitiveEvaluation';
        this.EducationStatusCognitiveEvaluation.Width = 300;

        this.PatientJobCognitiveEvaluation = new TTVisual.TTListBoxColumn();
        this.PatientJobCognitiveEvaluation.DataMember = 'PatientJob';
        this.PatientJobCognitiveEvaluation.DisplayIndex = 4;
        this.PatientJobCognitiveEvaluation.HeaderText = i18n("M18928", "Mesleği");
        this.PatientJobCognitiveEvaluation.Name = 'PatientJobCognitiveEvaluation';
        this.PatientJobCognitiveEvaluation.Width = 300;

        this.PsychologyBasedObjectCognitiveEvaluation = new TTVisual.TTListBoxColumn();
        this.PsychologyBasedObjectCognitiveEvaluation.DataMember = 'PsychologyBasedObject';
        this.PsychologyBasedObjectCognitiveEvaluation.DisplayIndex = 5;
        this.PsychologyBasedObjectCognitiveEvaluation.HeaderText = '';
        this.PsychologyBasedObjectCognitiveEvaluation.Name = 'PsychologyBasedObjectCognitiveEvaluation';
        this.PsychologyBasedObjectCognitiveEvaluation.Width = 300;

        this.AddedDateCognitiveEvaluation = new TTVisual.TTDateTimePickerColumn();
        this.AddedDateCognitiveEvaluation.DataMember = 'AddedDate';
        this.AddedDateCognitiveEvaluation.DisplayIndex = 6;
        this.AddedDateCognitiveEvaluation.HeaderText = i18n("M13568", "Eklenme Tarihi");
        this.AddedDateCognitiveEvaluation.Name = 'AddedDateCognitiveEvaluation';
        this.AddedDateCognitiveEvaluation.Width = 180;

        this.AttentionAndCalculationCognitiveEvaluation = new TTVisual.TTTextBoxColumn();
        this.AttentionAndCalculationCognitiveEvaluation.DataMember = 'AttentionAndCalculation';
        this.AttentionAndCalculationCognitiveEvaluation.DisplayIndex = 7;
        this.AttentionAndCalculationCognitiveEvaluation.HeaderText = i18n("M12850", "Dikkat ve Hesap Yapma");
        this.AttentionAndCalculationCognitiveEvaluation.Name = 'AttentionAndCalculationCognitiveEvaluation';
        this.AttentionAndCalculationCognitiveEvaluation.Width = 80;

        this.DetectionFunctionCognitiveEvaluation = new TTVisual.TTTextBoxColumn();
        this.DetectionFunctionCognitiveEvaluation.DataMember = 'DetectionFunction';
        this.DetectionFunctionCognitiveEvaluation.DisplayIndex = 8;
        this.DetectionFunctionCognitiveEvaluation.HeaderText = i18n("M10690", "Algılama İşlevi");
        this.DetectionFunctionCognitiveEvaluation.Name = 'DetectionFunctionCognitiveEvaluation';
        this.DetectionFunctionCognitiveEvaluation.Width = 80;

        this.IQIntelligenceLevelCognitiveEvaluation = new TTVisual.TTTextBoxColumn();
        this.IQIntelligenceLevelCognitiveEvaluation.DataMember = 'IQIntelligenceLevel';
        this.IQIntelligenceLevelCognitiveEvaluation.DisplayIndex = 9;
        this.IQIntelligenceLevelCognitiveEvaluation.HeaderText = i18n("M16016", "IQ Zeka Düzeyi");
        this.IQIntelligenceLevelCognitiveEvaluation.Name = 'IQIntelligenceLevelCognitiveEvaluation';
        this.IQIntelligenceLevelCognitiveEvaluation.Width = 80;

        this.JudgmentFunctionCognitiveEvaluation = new TTVisual.TTTextBoxColumn();
        this.JudgmentFunctionCognitiveEvaluation.DataMember = 'JudgmentFunction';
        this.JudgmentFunctionCognitiveEvaluation.DisplayIndex = 10;
        this.JudgmentFunctionCognitiveEvaluation.HeaderText = i18n("M24323", "Yargı İşlevi");
        this.JudgmentFunctionCognitiveEvaluation.Name = 'JudgmentFunctionCognitiveEvaluation';
        this.JudgmentFunctionCognitiveEvaluation.Width = 80;

        this.LanguageCognitiveEvaluation = new TTVisual.TTTextBoxColumn();
        this.LanguageCognitiveEvaluation.DataMember = 'Language';
        this.LanguageCognitiveEvaluation.DisplayIndex = 11;
        this.LanguageCognitiveEvaluation.HeaderText = i18n("M12852", "Dil");
        this.LanguageCognitiveEvaluation.Name = 'LanguageCognitiveEvaluation';
        this.LanguageCognitiveEvaluation.Width = 80;

        this.LongTermMemoryFunctionCognitiveEvaluation = new TTVisual.TTTextBoxColumn();
        this.LongTermMemoryFunctionCognitiveEvaluation.DataMember = 'LongTermMemoryFunction';
        this.LongTermMemoryFunctionCognitiveEvaluation.DisplayIndex = 12;
        this.LongTermMemoryFunctionCognitiveEvaluation.HeaderText = i18n("M23885", "Uzun Süreli Bellek Fonskiyonu");
        this.LongTermMemoryFunctionCognitiveEvaluation.Name = 'LongTermMemoryFunctionCognitiveEvaluation';
        this.LongTermMemoryFunctionCognitiveEvaluation.Width = 80;

        this.ObservationDiscussionEvalNoteCognitiveEvaluation = new TTVisual.TTTextBoxColumn();
        this.ObservationDiscussionEvalNoteCognitiveEvaluation.DataMember = 'ObservationDiscussionEvalNote';
        this.ObservationDiscussionEvalNoteCognitiveEvaluation.DisplayIndex = 13;
        this.ObservationDiscussionEvalNoteCognitiveEvaluation.HeaderText = i18n("M14955", "Gözlem Görüşmeye ve Değerlendirmeye Ait Not");
        this.ObservationDiscussionEvalNoteCognitiveEvaluation.Name = 'ObservationDiscussionEvalNoteCognitiveEvaluation';
        this.ObservationDiscussionEvalNoteCognitiveEvaluation.Width = 80;

        this.OrientationCognitiveEvaluation = new TTVisual.TTTextBoxColumn();
        this.OrientationCognitiveEvaluation.DataMember = 'Orientation';
        this.OrientationCognitiveEvaluation.DisplayIndex = 14;
        this.OrientationCognitiveEvaluation.HeaderText = i18n("M19807", "Oryantasyon");
        this.OrientationCognitiveEvaluation.Name = 'OrientationCognitiveEvaluation';
        this.OrientationCognitiveEvaluation.Width = 80;

        this.OtherCognitiveEvaluation = new TTVisual.TTTextBoxColumn();
        this.OtherCognitiveEvaluation.DataMember = 'Other';
        this.OtherCognitiveEvaluation.DisplayIndex = 15;
        this.OtherCognitiveEvaluation.HeaderText = i18n("M12780", "Diğer");
        this.OtherCognitiveEvaluation.Name = 'OtherCognitiveEvaluation';
        this.OtherCognitiveEvaluation.Width = 80;

        this.ReasoningFunctionCognitiveEvaluation = new TTVisual.TTTextBoxColumn();
        this.ReasoningFunctionCognitiveEvaluation.DataMember = 'ReasoningFunction';
        this.ReasoningFunctionCognitiveEvaluation.DisplayIndex = 16;
        this.ReasoningFunctionCognitiveEvaluation.HeaderText = i18n("M19274", "Muhakeme İşlevi");
        this.ReasoningFunctionCognitiveEvaluation.Name = 'ReasoningFunctionCognitiveEvaluation';
        this.ReasoningFunctionCognitiveEvaluation.Width = 80;

        this.RecordingMemory = new TTVisual.TTTextBoxColumn();
        this.RecordingMemory.DataMember = 'RecordingMemory';
        this.RecordingMemory.DisplayIndex = 17;
        this.RecordingMemory.HeaderText = i18n("M17395", "Kayıt Hafıza");
        this.RecordingMemory.Name = 'RecordingMemory';
        this.RecordingMemory.Width = 80;

        this.RemembranceCognitiveEvaluation = new TTVisual.TTTextBoxColumn();
        this.RemembranceCognitiveEvaluation.DataMember = 'Remembrance';
        this.RemembranceCognitiveEvaluation.DisplayIndex = 18;
        this.RemembranceCognitiveEvaluation.HeaderText = i18n("M15555", "Hatırlama");
        this.RemembranceCognitiveEvaluation.Name = 'RemembranceCognitiveEvaluation';
        this.RemembranceCognitiveEvaluation.Width = 80;

        this.ResultCognitiveEvaluation = new TTVisual.TTTextBoxColumn();
        this.ResultCognitiveEvaluation.DataMember = 'Result';
        this.ResultCognitiveEvaluation.DisplayIndex = 19;
        this.ResultCognitiveEvaluation.HeaderText = i18n("M22078", "Sonuç");
        this.ResultCognitiveEvaluation.Name = 'ResultCognitiveEvaluation';
        this.ResultCognitiveEvaluation.Width = 80;

        this.ShortTermMemoryFunctionCognitiveEvaluation = new TTVisual.TTTextBoxColumn();
        this.ShortTermMemoryFunctionCognitiveEvaluation.DataMember = 'ShortTermMemoryFunction';
        this.ShortTermMemoryFunctionCognitiveEvaluation.DisplayIndex = 20;
        this.ShortTermMemoryFunctionCognitiveEvaluation.HeaderText = i18n("M17532", "Kısa Süreli Bellek Fonksiyonu");
        this.ShortTermMemoryFunctionCognitiveEvaluation.Name = 'ShortTermMemoryFunctionCognitiveEvaluation';
        this.ShortTermMemoryFunctionCognitiveEvaluation.Width = 80;

        this.SocialEducationRetardationSitCognitiveEvaluation = new TTVisual.TTTextBoxColumn();
        this.SocialEducationRetardationSitCognitiveEvaluation.DataMember = 'SocialEducationRetardationSit';
        this.SocialEducationRetardationSitCognitiveEvaluation.DisplayIndex = 21;
        this.SocialEducationRetardationSitCognitiveEvaluation.HeaderText = i18n("M22171", "Sosyal Eğitimsel Retardasyon Durumu");
        this.SocialEducationRetardationSitCognitiveEvaluation.Name = 'SocialEducationRetardationSitCognitiveEvaluation';
        this.SocialEducationRetardationSitCognitiveEvaluation.Width = 80;

        this.PsychologicEvaluationTab = new TTVisual.TTTabPage();
        this.PsychologicEvaluationTab.DisplayIndex = 4;
        this.PsychologicEvaluationTab.TabIndex = 4;
        this.PsychologicEvaluationTab.Text = i18n("M20607", "Psikolojik Değerlendirme");
        this.PsychologicEvaluationTab.Name = 'PsychologicEvaluationTab';

        this.PsychologicEvaluation = new TTVisual.TTGrid();
        this.PsychologicEvaluation.Name = 'PsychologicEvaluation';
        this.PsychologicEvaluation.TabIndex = 0;

        this.AddedUserPsychologicEvaluation = new TTVisual.TTListBoxColumn();
        this.AddedUserPsychologicEvaluation.DataMember = 'AddedUser';
        this.AddedUserPsychologicEvaluation.DisplayIndex = 0;
        this.AddedUserPsychologicEvaluation.HeaderText = 'Ekleyen Kullanıcı';
        this.AddedUserPsychologicEvaluation.Name = 'AddedUserPsychologicEvaluation';
        this.AddedUserPsychologicEvaluation.Width = 300;

        this.ProcedureDoctorPsychologicEvaluation = new TTVisual.TTListBoxColumn();
        this.ProcedureDoctorPsychologicEvaluation.DataMember = 'ProcedureDoctor';
        this.ProcedureDoctorPsychologicEvaluation.DisplayIndex = 1;
        this.ProcedureDoctorPsychologicEvaluation.HeaderText = i18n("M23274", "Testi Uygulayan Doktor");
        this.ProcedureDoctorPsychologicEvaluation.Name = 'ProcedureDoctorPsychologicEvaluation';
        this.ProcedureDoctorPsychologicEvaluation.Width = 300;

        this.RequestDoctorPsychologicEvaluation = new TTVisual.TTListBoxColumn();
        this.RequestDoctorPsychologicEvaluation.DataMember = 'RequestDoctor';
        this.RequestDoctorPsychologicEvaluation.DisplayIndex = 2;
        this.RequestDoctorPsychologicEvaluation.HeaderText = i18n("M16690", "İstekte Bulunan Doktor");
        this.RequestDoctorPsychologicEvaluation.Name = 'RequestDoctorPsychologicEvaluation';
        this.RequestDoctorPsychologicEvaluation.ReadOnly = true;
        this.RequestDoctorPsychologicEvaluation.Width = 100;

        this.PatientJobPsychologicEvaluation = new TTVisual.TTListBoxColumn();
        this.PatientJobPsychologicEvaluation.DataMember = 'PatientJob';
        this.PatientJobPsychologicEvaluation.DisplayIndex = 3;
        this.PatientJobPsychologicEvaluation.HeaderText = i18n("M18928", "Mesleği");
        this.PatientJobPsychologicEvaluation.Name = 'PatientJobPsychologicEvaluation';
        this.PatientJobPsychologicEvaluation.Width = 300;

        this.EducationStatusPsychologicEvaluation = new TTVisual.TTListBoxColumn();
        this.EducationStatusPsychologicEvaluation.DataMember = 'EducationStatus';
        this.EducationStatusPsychologicEvaluation.DisplayIndex = 4;
        this.EducationStatusPsychologicEvaluation.HeaderText = i18n("M19901", "Öğrenim Durumu");
        this.EducationStatusPsychologicEvaluation.Name = 'EducationStatusPsychologicEvaluation';
        this.EducationStatusPsychologicEvaluation.Width = 300;

        this.PsychologyBasedObjectPsychologicEvaluation = new TTVisual.TTListBoxColumn();
        this.PsychologyBasedObjectPsychologicEvaluation.DataMember = 'PsychologyBasedObject';
        this.PsychologyBasedObjectPsychologicEvaluation.DisplayIndex = 5;
        this.PsychologyBasedObjectPsychologicEvaluation.HeaderText = '';
        this.PsychologyBasedObjectPsychologicEvaluation.Name = 'PsychologyBasedObjectPsychologicEvaluation';
        this.PsychologyBasedObjectPsychologicEvaluation.Width = 300;

        this.AddedDatePsychologicEvaluation = new TTVisual.TTDateTimePickerColumn();
        this.AddedDatePsychologicEvaluation.DataMember = 'AddedDate';
        this.AddedDatePsychologicEvaluation.DisplayIndex = 6;
        this.AddedDatePsychologicEvaluation.HeaderText = i18n("M13568", "Eklenme Tarihi");
        this.AddedDatePsychologicEvaluation.Name = 'AddedDatePsychologicEvaluation';
        this.AddedDatePsychologicEvaluation.Width = 180;

        this.IQIntelligenceLevelPsychologicEvaluation = new TTVisual.TTTextBoxColumn();
        this.IQIntelligenceLevelPsychologicEvaluation.DataMember = 'IQIntelligenceLevel';
        this.IQIntelligenceLevelPsychologicEvaluation.DisplayIndex = 7;
        this.IQIntelligenceLevelPsychologicEvaluation.HeaderText = i18n("M16016", "IQ Zeka Düzeyi");
        this.IQIntelligenceLevelPsychologicEvaluation.Name = 'IQIntelligenceLevelPsychologicEvaluation';
        this.IQIntelligenceLevelPsychologicEvaluation.Width = 80;

        this.LongTermMemoryFunctionPsychologicEvaluation = new TTVisual.TTTextBoxColumn();
        this.LongTermMemoryFunctionPsychologicEvaluation.DataMember = 'LongTermMemoryFunction';
        this.LongTermMemoryFunctionPsychologicEvaluation.DisplayIndex = 8;
        this.LongTermMemoryFunctionPsychologicEvaluation.HeaderText = i18n("M23884", "Uzun Süreli Bellek Fonksiyonu");
        this.LongTermMemoryFunctionPsychologicEvaluation.Name = 'LongTermMemoryFunctionPsychologicEvaluation';
        this.LongTermMemoryFunctionPsychologicEvaluation.Width = 80;

        this.MoodDisorderPsychologicEvaluation = new TTVisual.TTTextBoxColumn();
        this.MoodDisorderPsychologicEvaluation.DataMember = 'MoodDisorder';
        this.MoodDisorderPsychologicEvaluation.DisplayIndex = 9;
        this.MoodDisorderPsychologicEvaluation.HeaderText = i18n("M13378", "Duygu Durum Bozukluğu");
        this.MoodDisorderPsychologicEvaluation.Name = 'MoodDisorderPsychologicEvaluation';
        this.MoodDisorderPsychologicEvaluation.Width = 80;

        this.ObservationDiscussionEvalNotePsychologicEvaluation = new TTVisual.TTTextBoxColumn();
        this.ObservationDiscussionEvalNotePsychologicEvaluation.DataMember = 'ObservationDiscussionEvalNote';
        this.ObservationDiscussionEvalNotePsychologicEvaluation.DisplayIndex = 10;
        this.ObservationDiscussionEvalNotePsychologicEvaluation.HeaderText = i18n("M14955", "Gözlem Görüşmeye ve Değerlendirmeye Ait Not");
        this.ObservationDiscussionEvalNotePsychologicEvaluation.Name = 'ObservationDiscussionEvalNotePsychologicEvaluation';
        this.ObservationDiscussionEvalNotePsychologicEvaluation.Width = 80;

        this.PersonalPathologyOrDeviationPsychologicEvaluation = new TTVisual.TTTextBoxColumn();
        this.PersonalPathologyOrDeviationPsychologicEvaluation.DataMember = 'PersonalPathologyOrDeviation';
        this.PersonalPathologyOrDeviationPsychologicEvaluation.DisplayIndex = 11;
        this.PersonalPathologyOrDeviationPsychologicEvaluation.HeaderText = i18n("M17596", "Kişilik Patolojisi ya da Sapması");
        this.PersonalPathologyOrDeviationPsychologicEvaluation.Name = 'PersonalPathologyOrDeviationPsychologicEvaluation';
        this.PersonalPathologyOrDeviationPsychologicEvaluation.Width = 80;

        this.PsychopathologicalDeviationPsychologicEvaluation = new TTVisual.TTTextBoxColumn();
        this.PsychopathologicalDeviationPsychologicEvaluation.DataMember = 'PsychopathologicalDeviation';
        this.PsychopathologicalDeviationPsychologicEvaluation.DisplayIndex = 12;
        this.PsychopathologicalDeviationPsychologicEvaluation.HeaderText = i18n("M20616", "Psikopatolojik Sapma");
        this.PsychopathologicalDeviationPsychologicEvaluation.Name = 'PsychopathologicalDeviationPsychologicEvaluation';
        this.PsychopathologicalDeviationPsychologicEvaluation.Width = 80;

        this.PsychopathologicalDisorderPsychologicEvaluation = new TTVisual.TTTextBoxColumn();
        this.PsychopathologicalDisorderPsychologicEvaluation.DataMember = 'PsychopathologicalDisorder';
        this.PsychopathologicalDisorderPsychologicEvaluation.DisplayIndex = 13;
        this.PsychopathologicalDisorderPsychologicEvaluation.HeaderText = i18n("M20615", "Psikopatolojik Bozukluk");
        this.PsychopathologicalDisorderPsychologicEvaluation.Name = 'PsychopathologicalDisorderPsychologicEvaluation';
        this.PsychopathologicalDisorderPsychologicEvaluation.Width = 80;

        this.ResultPsychologicEvaluation = new TTVisual.TTTextBoxColumn();
        this.ResultPsychologicEvaluation.DataMember = 'Result';
        this.ResultPsychologicEvaluation.DisplayIndex = 14;
        this.ResultPsychologicEvaluation.HeaderText = i18n("M22078", "Sonuç");
        this.ResultPsychologicEvaluation.Name = 'ResultPsychologicEvaluation';
        this.ResultPsychologicEvaluation.Width = 80;

        this.ShortTermMemoryFunctionPsychologicEvaluation = new TTVisual.TTTextBoxColumn();
        this.ShortTermMemoryFunctionPsychologicEvaluation.DataMember = 'ShortTermMemoryFunction';
        this.ShortTermMemoryFunctionPsychologicEvaluation.DisplayIndex = 15;
        this.ShortTermMemoryFunctionPsychologicEvaluation.HeaderText = i18n("M17532", "Kısa Süreli Bellek Fonksiyonu");
        this.ShortTermMemoryFunctionPsychologicEvaluation.Name = 'ShortTermMemoryFunctionPsychologicEvaluation';
        this.ShortTermMemoryFunctionPsychologicEvaluation.Width = 80;

        this.SocialEducationRetardationSitPsychologicEvaluation = new TTVisual.TTTextBoxColumn();
        this.SocialEducationRetardationSitPsychologicEvaluation.DataMember = 'SocialEducationRetardationSit';
        this.SocialEducationRetardationSitPsychologicEvaluation.DisplayIndex = 16;
        this.SocialEducationRetardationSitPsychologicEvaluation.HeaderText = i18n("M22171", "Sosyal Eğitimsel Retardasyon Durumu");
        this.SocialEducationRetardationSitPsychologicEvaluation.Name = 'SocialEducationRetardationSitPsychologicEvaluation';
        this.SocialEducationRetardationSitPsychologicEvaluation.Width = 80;

        this.PsychologyAuthorizedUsersColumns = [this.ResUserPsychologyAuthorizedUser];
        this.EarlyChildGrowthEvaluationColumns = [this.AddedUserEarlyChildGrowthEvaluation, this.ProcedureDoctorEarlyChildGrowthEvaluation, this.RequestDoctorEarlyChildGrowthEvaluation, this.AddedDateEarlyChildGrowthEvaluation, this.CognitiveEvolutionEarlyChildGrowthEvaluation, this.GeneralEvolutionLevelEarlyChildGrowthEvaluation, this.MajorMotorEvolutionEarlyChildGrowthEvaluation, this.PsychomotorEvolutionEarlyChildGrowthEvaluation, this.ResultEarlyChildGrowthEvaluation, this.SocialSkillSelfCareEvolLevelEarlyChildGrowthEvaluation, this.ThinMotorEvolutionEarlyChildGrowthEvaluation, this.TongueCognitiveEvolutionLevelEarlyChildGrowthEvaluation];
        this.IQIntelligenceTestReportColumns = [this.AddedUserIQIntelligenceTestReport, this.ProcedureDoctorIQIntelligenceTestReport, this.RequestDoctorIQIntelligenceTestReport, this.EducationStatusIQIntelligenceTestReport, this.PatientJobIQIntelligenceTestReport, this.PsychologyBasedObjectIQIntelligenceTestReport, this.AddedDateIQIntelligenceTestReport, this.CommentIQIntelligenceTestReport, this.CriticalLifeEventIQIntelligenceTestReport, this.PerformanceIntelligenceIQIntelligenceTestReport, this.TestXXXXXXIQIntelligenceTestReport, this.TestPurposeIQIntelligenceTestReport, this.TotalIntelligenceIQIntelligenceTestReport, this.VerbalIntelligenceIQIntelligenceTestReport];
        this.VerbalAndPerformanceTestsColumns = [this.PsychologyBasedObjectVerbalAndPerformanceTests, this.ArithmeticVerbalAndPerformanceTests, this.GeneralInformationVerbalAndPerformanceTests, this.ImageCompletionVerbalAndPerformanceTests, this.ImageEditingVerbalAndPerformanceTests, this.MazesVerbalAndPerformanceTests, this.PasswordVerbalAndPerformanceTests, this.PatternWithCubesVerbalAndPerformanceTests, this.PieceAssemblyVerbalAndPerformanceTests, this.SimilaritiesVerbalAndPerformanceTests, this.TrialVerbalAndPerformanceTests, this.VocabularyVerbalAndPerformanceTests];
        this.ttgrid1Columns = [this.AddedUserCognitiveEvaluation, this.ProcedureDoctorCognitiveEvaluation, this.RequestDoctorCognitiveEvaluation, this.EducationStatusCognitiveEvaluation, this.PatientJobCognitiveEvaluation, this.PsychologyBasedObjectCognitiveEvaluation, this.AddedDateCognitiveEvaluation, this.AttentionAndCalculationCognitiveEvaluation, this.DetectionFunctionCognitiveEvaluation, this.IQIntelligenceLevelCognitiveEvaluation, this.JudgmentFunctionCognitiveEvaluation, this.LanguageCognitiveEvaluation, this.LongTermMemoryFunctionCognitiveEvaluation, this.ObservationDiscussionEvalNoteCognitiveEvaluation, this.OrientationCognitiveEvaluation, this.OtherCognitiveEvaluation, this.ReasoningFunctionCognitiveEvaluation, this.RecordingMemory, this.RemembranceCognitiveEvaluation, this.ResultCognitiveEvaluation, this.ShortTermMemoryFunctionCognitiveEvaluation, this.SocialEducationRetardationSitCognitiveEvaluation];
        this.PsychologicEvaluationColumns = [this.AddedUserPsychologicEvaluation, this.ProcedureDoctorPsychologicEvaluation, this.RequestDoctorPsychologicEvaluation, this.PatientJobPsychologicEvaluation, this.EducationStatusPsychologicEvaluation, this.PsychologyBasedObjectPsychologicEvaluation, this.AddedDatePsychologicEvaluation, this.IQIntelligenceLevelPsychologicEvaluation, this.LongTermMemoryFunctionPsychologicEvaluation, this.MoodDisorderPsychologicEvaluation, this.ObservationDiscussionEvalNotePsychologicEvaluation, this.PersonalPathologyOrDeviationPsychologicEvaluation, this.PsychopathologicalDeviationPsychologicEvaluation, this.PsychopathologicalDisorderPsychologicEvaluation, this.ResultPsychologicEvaluation, this.ShortTermMemoryFunctionPsychologicEvaluation, this.SocialEducationRetardationSitPsychologicEvaluation];
        this.tttabcontrol1.Controls = [this.EarlyChildGrowthEvalTab, this.IQIntelligenceTestTab, this.VerbalAndPerformanceTestTab, this.CognitiveEvaluation, this.PsychologicEvaluationTab];
        this.EarlyChildGrowthEvalTab.Controls = [this.EarlyChildGrowthEvaluation];
        this.IQIntelligenceTestTab.Controls = [this.IQIntelligenceTestReport];
        this.VerbalAndPerformanceTestTab.Controls = [this.VerbalAndPerformanceTests];
        this.CognitiveEvaluation.Controls = [this.ttgrid1];
        this.PsychologicEvaluationTab.Controls = [this.PsychologicEvaluation];
        this.Controls = [this.TherapyReport, this.VisibleForSelectedUsers, this.VisibleForPsychologyUnit, this.VisibleForProcAndRequestDoc, this.VisibleForProcedureDoctor, this.PsychologyAuthorizedUsers, this.ResUserPsychologyAuthorizedUser, /*this.labelFormAuthority, this.FormAuthority,*/ this.DoctorStatement, this.labelDoctorStatement, this.labelRequestDoctor, this.RequestDoctor, this.AppliedTestsHeader, this.labelIQTestObjectiveResultIQLevel, this.IQTestObjectiveResultIQLevel, this.InformationTakenFromParent, this.labelInformationTakenFromParent, this.labelImportantNoteAboutApplication, this.ImportantNoteAboutApplication, this.WISCR, this.ProteusMazeTest, this.PeabodyPictureVocabularyTest, this.LearnDifficultyDetermination, this.KentEGYTest, this.GoodEnoughHarrisDrawingTest, this.CattelIntelligenceTest, this.BinetTermanTest, this.tttabcontrol1, this.EarlyChildGrowthEvalTab, this.EarlyChildGrowthEvaluation, this.AddedUserEarlyChildGrowthEvaluation, this.ProcedureDoctorEarlyChildGrowthEvaluation, this.RequestDoctorEarlyChildGrowthEvaluation, this.AddedDateEarlyChildGrowthEvaluation, this.CognitiveEvolutionEarlyChildGrowthEvaluation, this.GeneralEvolutionLevelEarlyChildGrowthEvaluation, this.MajorMotorEvolutionEarlyChildGrowthEvaluation, this.PsychomotorEvolutionEarlyChildGrowthEvaluation, this.ResultEarlyChildGrowthEvaluation, this.SocialSkillSelfCareEvolLevelEarlyChildGrowthEvaluation, this.ThinMotorEvolutionEarlyChildGrowthEvaluation, this.TongueCognitiveEvolutionLevelEarlyChildGrowthEvaluation, this.IQIntelligenceTestTab, this.IQIntelligenceTestReport, this.AddedUserIQIntelligenceTestReport, this.ProcedureDoctorIQIntelligenceTestReport, this.RequestDoctorIQIntelligenceTestReport, this.EducationStatusIQIntelligenceTestReport, this.PatientJobIQIntelligenceTestReport, this.PsychologyBasedObjectIQIntelligenceTestReport, this.AddedDateIQIntelligenceTestReport, this.CommentIQIntelligenceTestReport, this.CriticalLifeEventIQIntelligenceTestReport, this.PerformanceIntelligenceIQIntelligenceTestReport, this.TestXXXXXXIQIntelligenceTestReport, this.TestPurposeIQIntelligenceTestReport, this.TotalIntelligenceIQIntelligenceTestReport, this.VerbalIntelligenceIQIntelligenceTestReport, this.VerbalAndPerformanceTestTab, this.VerbalAndPerformanceTests, this.PsychologyBasedObjectVerbalAndPerformanceTests, this.ArithmeticVerbalAndPerformanceTests, this.GeneralInformationVerbalAndPerformanceTests, this.ImageCompletionVerbalAndPerformanceTests, this.ImageEditingVerbalAndPerformanceTests, this.MazesVerbalAndPerformanceTests, this.PasswordVerbalAndPerformanceTests, this.PatternWithCubesVerbalAndPerformanceTests, this.PieceAssemblyVerbalAndPerformanceTests, this.SimilaritiesVerbalAndPerformanceTests, this.TrialVerbalAndPerformanceTests, this.VocabularyVerbalAndPerformanceTests, this.CognitiveEvaluation, this.ttgrid1, this.AddedUserCognitiveEvaluation, this.ProcedureDoctorCognitiveEvaluation, this.RequestDoctorCognitiveEvaluation, this.EducationStatusCognitiveEvaluation, this.PatientJobCognitiveEvaluation, this.PsychologyBasedObjectCognitiveEvaluation, this.AddedDateCognitiveEvaluation, this.AttentionAndCalculationCognitiveEvaluation, this.DetectionFunctionCognitiveEvaluation, this.IQIntelligenceLevelCognitiveEvaluation, this.JudgmentFunctionCognitiveEvaluation, this.LanguageCognitiveEvaluation, this.LongTermMemoryFunctionCognitiveEvaluation, this.ObservationDiscussionEvalNoteCognitiveEvaluation, this.OrientationCognitiveEvaluation, this.OtherCognitiveEvaluation, this.ReasoningFunctionCognitiveEvaluation, this.RecordingMemory, this.RemembranceCognitiveEvaluation, this.ResultCognitiveEvaluation, this.ShortTermMemoryFunctionCognitiveEvaluation, this.SocialEducationRetardationSitCognitiveEvaluation, this.PsychologicEvaluationTab, this.PsychologicEvaluation, this.AddedUserPsychologicEvaluation, this.ProcedureDoctorPsychologicEvaluation, this.RequestDoctorPsychologicEvaluation, this.PatientJobPsychologicEvaluation, this.EducationStatusPsychologicEvaluation, this.PsychologyBasedObjectPsychologicEvaluation, this.AddedDatePsychologicEvaluation, this.IQIntelligenceLevelPsychologicEvaluation, this.LongTermMemoryFunctionPsychologicEvaluation, this.MoodDisorderPsychologicEvaluation, this.ObservationDiscussionEvalNotePsychologicEvaluation, this.PersonalPathologyOrDeviationPsychologicEvaluation, this.PsychopathologicalDeviationPsychologicEvaluation, this.PsychopathologicalDisorderPsychologicEvaluation, this.ResultPsychologicEvaluation, this.ShortTermMemoryFunctionPsychologicEvaluation, this.SocialEducationRetardationSitPsychologicEvaluation];

    }


}
