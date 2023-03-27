//$6B5BC7CA
import { Component, OnInit, NgZone } from '@angular/core';
import { VerbalAndPerformanceTestsFormViewModel } from './VerbalAndPerformanceTestsFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { VerbalAndPerformanceTests } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { PsychologyBasedObject } from 'NebulaClient/Model/AtlasClientModel';



@Component({
    selector: 'VerbalAndPerformanceTestsForm',
    templateUrl: './VerbalAndPerformanceTestsForm.html',
    providers: [MessageService]
})
export class VerbalAndPerformanceTestsForm extends TTVisual.TTForm implements OnInit {
    AddedUser: TTVisual.ITTObjectListBox;
    Arithmetic: TTVisual.ITTTextBox;
    GeneralInformation: TTVisual.ITTTextBox;
    ImageCompletion: TTVisual.ITTTextBox;
    ImageEditing: TTVisual.ITTTextBox;
    labelAddedUser: TTVisual.ITTLabel;
    labelArithmetic: TTVisual.ITTLabel;
    labelGeneralInformation: TTVisual.ITTLabel;
    labelImageCompletion: TTVisual.ITTLabel;
    labelImageEditing: TTVisual.ITTLabel;
    labelMazes: TTVisual.ITTLabel;
    labelNumberSequence: TTVisual.ITTLabel;
    labelPassword: TTVisual.ITTLabel;
    labelPatternWithCubes: TTVisual.ITTLabel;
    labelPerformanceSystem: TTVisual.ITTLabel;
    labelPieceAssembly: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelSimilarities: TTVisual.ITTLabel;
    labelTrial: TTVisual.ITTLabel;
    labelVerbalTests: TTVisual.ITTLabel;
    labelVocabulary: TTVisual.ITTLabel;
    Mazes: TTVisual.ITTTextBox;
    NumberSequence: TTVisual.ITTTextBox;
    Password: TTVisual.ITTTextBox;
    PatternWithCubes: TTVisual.ITTTextBox;
    PieceAssembly: TTVisual.ITTTextBox;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    Similarities: TTVisual.ITTTextBox;
    Trial: TTVisual.ITTTextBox;
    Vocabulary: TTVisual.ITTTextBox;
    public verbalAndPerformanceTestsFormViewModel: VerbalAndPerformanceTestsFormViewModel = new VerbalAndPerformanceTestsFormViewModel();
    public get _VerbalAndPerformanceTests(): VerbalAndPerformanceTests {
        return this._TTObject as VerbalAndPerformanceTests;
    }
    private VerbalAndPerformanceTestsForm_DocumentUrl: string = '/api/VerbalAndPerformanceTestsService/VerbalAndPerformanceTestsForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('VERBALANDPERFORMANCETESTS', 'VerbalAndPerformanceTestsForm');
        this._DocumentServiceUrl = this.VerbalAndPerformanceTestsForm_DocumentUrl;
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
        if (this._VerbalAndPerformanceTests != null)
            this._VerbalAndPerformanceTests.PsychologyBasedObject = this.psychologyBasedObject;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new VerbalAndPerformanceTests();
        this.verbalAndPerformanceTestsFormViewModel = new VerbalAndPerformanceTestsFormViewModel();
        this._ViewModel = this.verbalAndPerformanceTestsFormViewModel;
        this.verbalAndPerformanceTestsFormViewModel._VerbalAndPerformanceTests = this._TTObject as VerbalAndPerformanceTests;
        this.verbalAndPerformanceTestsFormViewModel._VerbalAndPerformanceTests.ProcedureDoctor = new ResUser();
        this.verbalAndPerformanceTestsFormViewModel._VerbalAndPerformanceTests.AddedUser = new ResUser();
    }

    protected loadViewModel() {
        let that = this;

        that.verbalAndPerformanceTestsFormViewModel = this._ViewModel as VerbalAndPerformanceTestsFormViewModel;
        that._TTObject = this.verbalAndPerformanceTestsFormViewModel._VerbalAndPerformanceTests;
        if (this.verbalAndPerformanceTestsFormViewModel == null)
            this.verbalAndPerformanceTestsFormViewModel = new VerbalAndPerformanceTestsFormViewModel();
        if (this.verbalAndPerformanceTestsFormViewModel._VerbalAndPerformanceTests == null)
            this.verbalAndPerformanceTestsFormViewModel._VerbalAndPerformanceTests = new VerbalAndPerformanceTests();
        let procedureDoctorObjectID = that.verbalAndPerformanceTestsFormViewModel._VerbalAndPerformanceTests["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.verbalAndPerformanceTestsFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.verbalAndPerformanceTestsFormViewModel._VerbalAndPerformanceTests.ProcedureDoctor = procedureDoctor;
            }
        }
        let addedUserObjectID = that.verbalAndPerformanceTestsFormViewModel._VerbalAndPerformanceTests["AddedUser"];
        if (addedUserObjectID != null && (typeof addedUserObjectID === 'string')) {
            let addedUser = that.verbalAndPerformanceTestsFormViewModel.ResUsers.find(o => o.ObjectID.toString() === addedUserObjectID.toString());
             if (addedUser) {
                that.verbalAndPerformanceTestsFormViewModel._VerbalAndPerformanceTests.AddedUser = addedUser;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(VerbalAndPerformanceTestsFormViewModel);
  
    }


    public onAddedUserChanged(event): void {
        if (event != null) {
            if (this._VerbalAndPerformanceTests != null && this._VerbalAndPerformanceTests.AddedUser != event) {
                this._VerbalAndPerformanceTests.AddedUser = event;
            }
        }
    }

    public onArithmeticChanged(event): void {
        if (event != null) {
            if (this._VerbalAndPerformanceTests != null && this._VerbalAndPerformanceTests.Arithmetic != event) {
                this._VerbalAndPerformanceTests.Arithmetic = event;
            }
        }
    }

    public onGeneralInformationChanged(event): void {
        if (event != null) {
            if (this._VerbalAndPerformanceTests != null && this._VerbalAndPerformanceTests.GeneralInformation != event) {
                this._VerbalAndPerformanceTests.GeneralInformation = event;
            }
        }
    }

    public onImageCompletionChanged(event): void {
        if (event != null) {
            if (this._VerbalAndPerformanceTests != null && this._VerbalAndPerformanceTests.ImageCompletion != event) {
                this._VerbalAndPerformanceTests.ImageCompletion = event;
            }
        }
    }

    public onImageEditingChanged(event): void {
        if (event != null) {
            if (this._VerbalAndPerformanceTests != null && this._VerbalAndPerformanceTests.ImageEditing != event) {
                this._VerbalAndPerformanceTests.ImageEditing = event;
            }
        }
    }

    public onMazesChanged(event): void {
        if (event != null) {
            if (this._VerbalAndPerformanceTests != null && this._VerbalAndPerformanceTests.Mazes != event) {
                this._VerbalAndPerformanceTests.Mazes = event;
            }
        }
    }

    public onNumberSequenceChanged(event): void {
        if (event != null) {
            if (this._VerbalAndPerformanceTests != null && this._VerbalAndPerformanceTests.NumberSequence != event) {
                this._VerbalAndPerformanceTests.NumberSequence = event;
            }
        }
    }

    public onPasswordChanged(event): void {
        if (event != null) {
            if (this._VerbalAndPerformanceTests != null && this._VerbalAndPerformanceTests.Password != event) {
                this._VerbalAndPerformanceTests.Password = event;
            }
        }
    }

    public onPatternWithCubesChanged(event): void {
        if (event != null) {
            if (this._VerbalAndPerformanceTests != null && this._VerbalAndPerformanceTests.PatternWithCubes != event) {
                this._VerbalAndPerformanceTests.PatternWithCubes = event;
            }
        }
    }

    public onPieceAssemblyChanged(event): void {
        if (event != null) {
            if (this._VerbalAndPerformanceTests != null && this._VerbalAndPerformanceTests.PieceAssembly != event) {
                this._VerbalAndPerformanceTests.PieceAssembly = event;
            }
        }
    }

    public onProcedureDoctorChanged(event): void {
        if (event != null) {
            if (this._VerbalAndPerformanceTests != null && this._VerbalAndPerformanceTests.ProcedureDoctor != event) {
                this._VerbalAndPerformanceTests.ProcedureDoctor = event;
            }
        }
    }

    public onSimilaritiesChanged(event): void {
        if (event != null) {
            if (this._VerbalAndPerformanceTests != null && this._VerbalAndPerformanceTests.Similarities != event) {
                this._VerbalAndPerformanceTests.Similarities = event;
            }
        }
    }

    public onTrialChanged(event): void {
        if (event != null) {
            if (this._VerbalAndPerformanceTests != null && this._VerbalAndPerformanceTests.Trial != event) {
                this._VerbalAndPerformanceTests.Trial = event;
            }
        }
    }

    public onVocabularyChanged(event): void {
        if (event != null) {
            if (this._VerbalAndPerformanceTests != null && this._VerbalAndPerformanceTests.Vocabulary != event) {
                this._VerbalAndPerformanceTests.Vocabulary = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.GeneralInformation, "Text", this.__ttObject, "GeneralInformation");
        redirectProperty(this.Similarities, "Text", this.__ttObject, "Similarities");
        redirectProperty(this.Arithmetic, "Text", this.__ttObject, "Arithmetic");
        redirectProperty(this.ImageCompletion, "Text", this.__ttObject, "ImageCompletion");
        redirectProperty(this.ImageEditing, "Text", this.__ttObject, "ImageEditing");
        redirectProperty(this.PatternWithCubes, "Text", this.__ttObject, "PatternWithCubes");
        redirectProperty(this.Vocabulary, "Text", this.__ttObject, "Vocabulary");
        redirectProperty(this.Trial, "Text", this.__ttObject, "Trial");
        redirectProperty(this.NumberSequence, "Text", this.__ttObject, "NumberSequence");
        redirectProperty(this.PieceAssembly, "Text", this.__ttObject, "PieceAssembly");
        redirectProperty(this.Password, "Text", this.__ttObject, "Password");
        redirectProperty(this.Mazes, "Text", this.__ttObject, "Mazes");
    }

    public initFormControls(): void {
        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M23275", "Testi Uygulayan Psikolog");
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 29;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ListDefName = "PsychologistList";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 28;

        this.labelAddedUser = new TTVisual.TTLabel();
        this.labelAddedUser.Text = "Ekleyen Kullanıcı";
        this.labelAddedUser.Name = "labelAddedUser";
        this.labelAddedUser.TabIndex = 27;

        this.AddedUser = new TTVisual.TTObjectListBox();
        this.AddedUser.ListDefName = "ResUserListDefinition";
        this.AddedUser.Name = "AddedUser";
        this.AddedUser.TabIndex = 26;

        this.labelPerformanceSystem = new TTVisual.TTLabel();
        this.labelPerformanceSystem.Text = i18n("M20297", "Performans Sistemi");
        this.labelPerformanceSystem.Name = "labelPerformanceSystem";
        this.labelPerformanceSystem.TabIndex = 25;

        this.labelVerbalTests = new TTVisual.TTLabel();
        this.labelVerbalTests.Text = i18n("M22213", "Sözel Testler");
        this.labelVerbalTests.Name = "labelVerbalTests";
        this.labelVerbalTests.TabIndex = 24;

        this.labelVocabulary = new TTVisual.TTLabel();
        this.labelVocabulary.Text = i18n("M22211", "Sözcük Dağarcığı");
        this.labelVocabulary.Name = "labelVocabulary";
        this.labelVocabulary.TabIndex = 23;

        this.Vocabulary = new TTVisual.TTTextBox();
        this.Vocabulary.Name = "Vocabulary";
        this.Vocabulary.TabIndex = 22;

        this.Trial = new TTVisual.TTTextBox();
        this.Trial.Name = "Trial";
        this.Trial.TabIndex = 20;

        this.Similarities = new TTVisual.TTTextBox();
        this.Similarities.Name = "Similarities";
        this.Similarities.TabIndex = 18;

        this.PieceAssembly = new TTVisual.TTTextBox();
        this.PieceAssembly.Name = "PieceAssembly";
        this.PieceAssembly.TabIndex = 16;

        this.PatternWithCubes = new TTVisual.TTTextBox();
        this.PatternWithCubes.Name = "PatternWithCubes";
        this.PatternWithCubes.TabIndex = 14;

        this.Password = new TTVisual.TTTextBox();
        this.Password.Name = "Password";
        this.Password.TabIndex = 12;

        this.NumberSequence = new TTVisual.TTTextBox();
        this.NumberSequence.Name = "NumberSequence";
        this.NumberSequence.TabIndex = 10;

        this.Mazes = new TTVisual.TTTextBox();
        this.Mazes.Name = "Mazes";
        this.Mazes.TabIndex = 8;

        this.ImageEditing = new TTVisual.TTTextBox();
        this.ImageEditing.Name = "ImageEditing";
        this.ImageEditing.TabIndex = 6;

        this.ImageCompletion = new TTVisual.TTTextBox();
        this.ImageCompletion.Name = "ImageCompletion";
        this.ImageCompletion.TabIndex = 4;

        this.GeneralInformation = new TTVisual.TTTextBox();
        this.GeneralInformation.Name = "GeneralInformation";
        this.GeneralInformation.TabIndex = 2;

        this.Arithmetic = new TTVisual.TTTextBox();
        this.Arithmetic.Name = "Arithmetic";
        this.Arithmetic.TabIndex = 0;

        this.labelTrial = new TTVisual.TTLabel();
        this.labelTrial.Text = i18n("M24324", "Yargılama");
        this.labelTrial.Name = "labelTrial";
        this.labelTrial.TabIndex = 21;

        this.labelSimilarities = new TTVisual.TTLabel();
        this.labelSimilarities.Text = i18n("M11761", "Benzerlikler");
        this.labelSimilarities.Name = "labelSimilarities";
        this.labelSimilarities.TabIndex = 19;

        this.labelPieceAssembly = new TTVisual.TTLabel();
        this.labelPieceAssembly.Text = i18n("M20206", "Parça Birleştirme");
        this.labelPieceAssembly.Name = "labelPieceAssembly";
        this.labelPieceAssembly.TabIndex = 17;

        this.labelPatternWithCubes = new TTVisual.TTLabel();
        this.labelPatternWithCubes.Text = i18n("M18139", "Küplerle Desen");
        this.labelPatternWithCubes.Name = "labelPatternWithCubes";
        this.labelPatternWithCubes.TabIndex = 15;

        this.labelPassword = new TTVisual.TTLabel();
        this.labelPassword.Text = i18n("M22480", "Şifre");
        this.labelPassword.Name = "labelPassword";
        this.labelPassword.TabIndex = 13;

        this.labelNumberSequence = new TTVisual.TTLabel();
        this.labelNumberSequence.Text = i18n("M21401", "Sayı Dizisi");
        this.labelNumberSequence.Name = "labelNumberSequence";
        this.labelNumberSequence.TabIndex = 11;

        this.labelMazes = new TTVisual.TTLabel();
        this.labelMazes.Text = i18n("M18158", "Labirentler");
        this.labelMazes.Name = "labelMazes";
        this.labelMazes.TabIndex = 9;

        this.labelImageEditing = new TTVisual.TTLabel();
        this.labelImageEditing.Text = i18n("M21028", "Resim Düzenleme");
        this.labelImageEditing.Name = "labelImageEditing";
        this.labelImageEditing.TabIndex = 7;

        this.labelImageCompletion = new TTVisual.TTLabel();
        this.labelImageCompletion.Text = i18n("M21030", "Resim Tamamlama");
        this.labelImageCompletion.Name = "labelImageCompletion";
        this.labelImageCompletion.TabIndex = 5;

        this.labelGeneralInformation = new TTVisual.TTLabel();
        this.labelGeneralInformation.Text = i18n("M14680", "Genel Bilgi");
        this.labelGeneralInformation.Name = "labelGeneralInformation";
        this.labelGeneralInformation.TabIndex = 3;

        this.labelArithmetic = new TTVisual.TTLabel();
        this.labelArithmetic.Text = i18n("M11094", "Aritmetik");
        this.labelArithmetic.Name = "labelArithmetic";
        this.labelArithmetic.TabIndex = 1;

        this.Controls = [this.labelProcedureDoctor, this.ProcedureDoctor, this.labelAddedUser, this.AddedUser, this.labelPerformanceSystem, this.labelVerbalTests, this.labelVocabulary, this.Vocabulary, this.Trial, this.Similarities, this.PieceAssembly, this.PatternWithCubes, this.Password, this.NumberSequence, this.Mazes, this.ImageEditing, this.ImageCompletion, this.GeneralInformation, this.Arithmetic, this.labelTrial, this.labelSimilarities, this.labelPieceAssembly, this.labelPatternWithCubes, this.labelPassword, this.labelNumberSequence, this.labelMazes, this.labelImageEditing, this.labelImageCompletion, this.labelGeneralInformation, this.labelArithmetic];

    }


}
