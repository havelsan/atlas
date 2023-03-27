//$D7F9E29F
import { Component, OnInit, NgZone } from '@angular/core';
import { EarlyChildGrowthEvalFormViewModel } from './EarlyChildGrowthEvalFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EarlyChildGrowthEvaluation } from 'NebulaClient/Model/AtlasClientModel';
import { PsychologyBasedObject } from 'NebulaClient/Model/AtlasClientModel';

import { ResUser } from 'NebulaClient/Model/AtlasClientModel';




@Component({
    selector: 'EarlyChildGrowthEvalForm',
    templateUrl: './EarlyChildGrowthEvalForm.html',
    providers: [MessageService]
})
export class EarlyChildGrowthEvalForm extends TTVisual.TTForm implements OnInit {
    AddedUser: TTVisual.ITTObjectListBox;
    CognitiveEvolution: TTVisual.ITTRichTextBoxControl;
    GeneralEvolutionLevel: TTVisual.ITTRichTextBoxControl;
    labelAddedUser: TTVisual.ITTLabel;
    labelCognitiveEvolution: TTVisual.ITTLabel;
    labelGeneralEvolutionLevel: TTVisual.ITTLabel;
    labelMajorMotorEvolution: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelPsychomotorEvolution: TTVisual.ITTLabel;
    labelResult: TTVisual.ITTLabel;
    labelSocialSkillSelfCareEvolLevel: TTVisual.ITTLabel;
    labelThinMotorEvolution: TTVisual.ITTLabel;
    labelTongueCognitiveEvolutionLevel: TTVisual.ITTLabel;
    MajorMotorEvolution: TTVisual.ITTRichTextBoxControl;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    PsychomotorEvolution: TTVisual.ITTRichTextBoxControl;
    Result: TTVisual.ITTRichTextBoxControl;
    SocialSkillSelfCareEvolLevel: TTVisual.ITTRichTextBoxControl;
    ThinMotorEvolution: TTVisual.ITTRichTextBoxControl;
    TongueCognitiveEvolutionLevel: TTVisual.ITTRichTextBoxControl;
    public earlyChildGrowthEvalFormViewModel: EarlyChildGrowthEvalFormViewModel = new EarlyChildGrowthEvalFormViewModel();
    public get _EarlyChildGrowthEvaluation(): EarlyChildGrowthEvaluation {
        return this._TTObject as EarlyChildGrowthEvaluation;
    }
    private EarlyChildGrowthEvalForm_DocumentUrl: string = '/api/EarlyChildGrowthEvaluationService/EarlyChildGrowthEvalForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('EARLYCHILDGROWTHEVALUATION', 'EarlyChildGrowthEvalForm');
        this._DocumentServiceUrl = this.EarlyChildGrowthEvalForm_DocumentUrl;
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
        if (this._EarlyChildGrowthEvaluation != null)
            this._EarlyChildGrowthEvaluation.PsychologyBasedObject = this.psychologyBasedObject;
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new EarlyChildGrowthEvaluation();
        this.earlyChildGrowthEvalFormViewModel = new EarlyChildGrowthEvalFormViewModel();
        this._ViewModel = this.earlyChildGrowthEvalFormViewModel;
        this.earlyChildGrowthEvalFormViewModel._EarlyChildGrowthEvaluation = this._TTObject as EarlyChildGrowthEvaluation;
        this.earlyChildGrowthEvalFormViewModel._EarlyChildGrowthEvaluation.AddedUser = new ResUser();
        this.earlyChildGrowthEvalFormViewModel._EarlyChildGrowthEvaluation.ProcedureDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;

        that.earlyChildGrowthEvalFormViewModel = this._ViewModel as EarlyChildGrowthEvalFormViewModel;
        that._TTObject = this.earlyChildGrowthEvalFormViewModel._EarlyChildGrowthEvaluation;
        if (this.earlyChildGrowthEvalFormViewModel == null)
            this.earlyChildGrowthEvalFormViewModel = new EarlyChildGrowthEvalFormViewModel();
        if (this.earlyChildGrowthEvalFormViewModel._EarlyChildGrowthEvaluation == null)
            this.earlyChildGrowthEvalFormViewModel._EarlyChildGrowthEvaluation = new EarlyChildGrowthEvaluation();
        let addedUserObjectID = that.earlyChildGrowthEvalFormViewModel._EarlyChildGrowthEvaluation["AddedUser"];
        if (addedUserObjectID != null && (typeof addedUserObjectID === 'string')) {
            let addedUser = that.earlyChildGrowthEvalFormViewModel.ResUsers.find(o => o.ObjectID.toString() === addedUserObjectID.toString());
             if (addedUser) {
                that.earlyChildGrowthEvalFormViewModel._EarlyChildGrowthEvaluation.AddedUser = addedUser;
            }
        }
        let procedureDoctorObjectID = that.earlyChildGrowthEvalFormViewModel._EarlyChildGrowthEvaluation["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.earlyChildGrowthEvalFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.earlyChildGrowthEvalFormViewModel._EarlyChildGrowthEvaluation.ProcedureDoctor = procedureDoctor;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(EarlyChildGrowthEvalFormViewModel);
  
    }


    public onAddedUserChanged(event): void {
        if (event != null) {
            if (this._EarlyChildGrowthEvaluation != null && this._EarlyChildGrowthEvaluation.AddedUser != event) {
                this._EarlyChildGrowthEvaluation.AddedUser = event;
            }
        }
    }

    public onCognitiveEvolutionChanged(event): void {
        if (event != null) {
            if (this._EarlyChildGrowthEvaluation != null && this._EarlyChildGrowthEvaluation.CognitiveEvolution != event) {
                this._EarlyChildGrowthEvaluation.CognitiveEvolution = event;
            }
        }
    }

    public onGeneralEvolutionLevelChanged(event): void {
        if (event != null) {
            if (this._EarlyChildGrowthEvaluation != null && this._EarlyChildGrowthEvaluation.GeneralEvolutionLevel != event) {
                this._EarlyChildGrowthEvaluation.GeneralEvolutionLevel = event;
            }
        }
    }

    public onMajorMotorEvolutionChanged(event): void {
        if (event != null) {
            if (this._EarlyChildGrowthEvaluation != null && this._EarlyChildGrowthEvaluation.MajorMotorEvolution != event) {
                this._EarlyChildGrowthEvaluation.MajorMotorEvolution = event;
            }
        }
    }

    public onProcedureDoctorChanged(event): void {
        if (event != null) {
            if (this._EarlyChildGrowthEvaluation != null && this._EarlyChildGrowthEvaluation.ProcedureDoctor != event) {
                this._EarlyChildGrowthEvaluation.ProcedureDoctor = event;
            }
        }
    }

    public onPsychomotorEvolutionChanged(event): void {
        if (event != null) {
            if (this._EarlyChildGrowthEvaluation != null && this._EarlyChildGrowthEvaluation.PsychomotorEvolution != event) {
                this._EarlyChildGrowthEvaluation.PsychomotorEvolution = event;
            }
        }
    }

    public onResultChanged(event): void {
        if (event != null) {
            if (this._EarlyChildGrowthEvaluation != null && this._EarlyChildGrowthEvaluation.Result != event) {
                this._EarlyChildGrowthEvaluation.Result = event;
            }
        }
    }

    public onSocialSkillSelfCareEvolLevelChanged(event): void {
        if (event != null) {
            if (this._EarlyChildGrowthEvaluation != null && this._EarlyChildGrowthEvaluation.SocialSkillSelfCareEvolLevel != event) {
                this._EarlyChildGrowthEvaluation.SocialSkillSelfCareEvolLevel = event;
            }
        }
    }

    public onThinMotorEvolutionChanged(event): void {
        if (event != null) {
            if (this._EarlyChildGrowthEvaluation != null && this._EarlyChildGrowthEvaluation.ThinMotorEvolution != event) {
                this._EarlyChildGrowthEvaluation.ThinMotorEvolution = event;
            }
        }
    }

    public onTongueCognitiveEvolutionLevelChanged(event): void {
        if (event != null) {
            if (this._EarlyChildGrowthEvaluation != null && this._EarlyChildGrowthEvaluation.TongueCognitiveEvolutionLevel != event) {
                this._EarlyChildGrowthEvaluation.TongueCognitiveEvolutionLevel = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.GeneralEvolutionLevel, "Rtf", this.__ttObject, "GeneralEvolutionLevel");
        redirectProperty(this.CognitiveEvolution, "Rtf", this.__ttObject, "CognitiveEvolution");
        redirectProperty(this.PsychomotorEvolution, "Rtf", this.__ttObject, "PsychomotorEvolution");
        redirectProperty(this.TongueCognitiveEvolutionLevel, "Rtf", this.__ttObject, "TongueCognitiveEvolutionLevel");
        redirectProperty(this.ThinMotorEvolution, "Rtf", this.__ttObject, "ThinMotorEvolution");
        redirectProperty(this.SocialSkillSelfCareEvolLevel, "Rtf", this.__ttObject, "SocialSkillSelfCareEvolLevel");
        redirectProperty(this.MajorMotorEvolution, "Rtf", this.__ttObject, "MajorMotorEvolution");
        redirectProperty(this.Result, "Rtf", this.__ttObject, "Result");
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

        this.PsychomotorEvolution = new TTVisual.TTRichTextBoxControl();
        this.PsychomotorEvolution.Name = "PsychomotorEvolution";
        this.PsychomotorEvolution.TabIndex = 28;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M23274", "Testi Uygulayan Doktor");
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 27;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ListDefName = "PsychologistList";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 26;

        this.Result = new TTVisual.TTRichTextBoxControl();
        this.Result.Name = "Result";
        this.Result.TabIndex = 25;

        this.SocialSkillSelfCareEvolLevel = new TTVisual.TTRichTextBoxControl();
        this.SocialSkillSelfCareEvolLevel.Name = "SocialSkillSelfCareEvolLevel";
        this.SocialSkillSelfCareEvolLevel.TabIndex = 24;

        this.TongueCognitiveEvolutionLevel = new TTVisual.TTRichTextBoxControl();
        this.TongueCognitiveEvolutionLevel.Name = "TongueCognitiveEvolutionLevel";
        this.TongueCognitiveEvolutionLevel.TabIndex = 23;

        this.ThinMotorEvolution = new TTVisual.TTRichTextBoxControl();
        this.ThinMotorEvolution.Name = "ThinMotorEvolution";
        this.ThinMotorEvolution.TabIndex = 22;

        this.MajorMotorEvolution = new TTVisual.TTRichTextBoxControl();
        this.MajorMotorEvolution.Name = "MajorMotorEvolution";
        this.MajorMotorEvolution.TabIndex = 20;

        this.GeneralEvolutionLevel = new TTVisual.TTRichTextBoxControl();
        this.GeneralEvolutionLevel.Name = "GeneralEvolutionLevel";
        this.GeneralEvolutionLevel.TabIndex = 19;

        this.CognitiveEvolution = new TTVisual.TTRichTextBoxControl();
        this.CognitiveEvolution.Name = "CognitiveEvolution";
        this.CognitiveEvolution.TabIndex = 18;

        this.labelTongueCognitiveEvolutionLevel = new TTVisual.TTLabel();
        this.labelTongueCognitiveEvolutionLevel.Text = i18n("M12853", "Dil / Bilişsel Gelişim Düzeyi");
        this.labelTongueCognitiveEvolutionLevel.Name = "labelTongueCognitiveEvolutionLevel";
        this.labelTongueCognitiveEvolutionLevel.TabIndex = 17;

        this.labelThinMotorEvolution = new TTVisual.TTLabel();
        this.labelThinMotorEvolution.Text = i18n("M16482", "İnce Motor Gelişimi");
        this.labelThinMotorEvolution.Name = "labelThinMotorEvolution";
        this.labelThinMotorEvolution.TabIndex = 15;

        this.labelSocialSkillSelfCareEvolLevel = new TTVisual.TTLabel();
        this.labelSocialSkillSelfCareEvolLevel.Text = i18n("M22168", "Sosyal Beceri / Özbakım Gelişim Düzeyi");
        this.labelSocialSkillSelfCareEvolLevel.Name = "labelSocialSkillSelfCareEvolLevel";
        this.labelSocialSkillSelfCareEvolLevel.TabIndex = 13;

        this.labelResult = new TTVisual.TTLabel();
        this.labelResult.Text = i18n("M22078", "Sonuç");
        this.labelResult.Name = "labelResult";
        this.labelResult.TabIndex = 11;

        this.labelPsychomotorEvolution = new TTVisual.TTLabel();
        this.labelPsychomotorEvolution.Text = i18n("M20614", "Psikomotor Gelişimi");
        this.labelPsychomotorEvolution.Name = "labelPsychomotorEvolution";
        this.labelPsychomotorEvolution.TabIndex = 9;

        this.labelMajorMotorEvolution = new TTVisual.TTLabel();
        this.labelMajorMotorEvolution.Text = i18n("M17003", "Kaba Motor Gelişimi");
        this.labelMajorMotorEvolution.Name = "labelMajorMotorEvolution";
        this.labelMajorMotorEvolution.TabIndex = 7;

        this.labelGeneralEvolutionLevel = new TTVisual.TTLabel();
        this.labelGeneralEvolutionLevel.Text = i18n("M14690", "Genel Gelişim Düzeyi");
        this.labelGeneralEvolutionLevel.Name = "labelGeneralEvolutionLevel";
        this.labelGeneralEvolutionLevel.TabIndex = 5;

        this.labelCognitiveEvolution = new TTVisual.TTLabel();
        this.labelCognitiveEvolution.Text = i18n("M11809", "Bilişsel Gelişimi");
        this.labelCognitiveEvolution.Name = "labelCognitiveEvolution";
        this.labelCognitiveEvolution.TabIndex = 3;

        this.Controls = [this.labelAddedUser, this.AddedUser, this.PsychomotorEvolution, this.labelProcedureDoctor, this.ProcedureDoctor, this.Result, this.SocialSkillSelfCareEvolLevel, this.TongueCognitiveEvolutionLevel, this.ThinMotorEvolution, this.MajorMotorEvolution, this.GeneralEvolutionLevel, this.CognitiveEvolution, this.labelTongueCognitiveEvolutionLevel, this.labelThinMotorEvolution, this.labelSocialSkillSelfCareEvolLevel, this.labelResult, this.labelPsychomotorEvolution, this.labelMajorMotorEvolution, this.labelGeneralEvolutionLevel, this.labelCognitiveEvolution];

    }


}
