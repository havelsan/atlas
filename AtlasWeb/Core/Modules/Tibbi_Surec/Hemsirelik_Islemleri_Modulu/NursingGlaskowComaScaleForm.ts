//$8E0D1BF2
import { Component, OnInit, NgZone } from '@angular/core';
import { NursingGlaskowComaScaleFormViewModel } from './NursingGlaskowComaScaleFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { NursingGlaskowComaScale } from 'NebulaClient/Model/AtlasClientModel';
import { NursingGlaskowComaScaleService } from "ObjectClassService/NursingGlaskowComaScaleService";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { GlaskowComaScaleDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';




@Component({
    selector: 'NursingGlaskowComaScaleForm',
    templateUrl: './NursingGlaskowComaScaleForm.html',
    providers: [MessageService]
})
export class NursingGlaskowComaScaleForm extends BaseNursingDataEntryForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    ApplicationDate: TTVisual.ITTDateTimePicker;
    Eyes: TTVisual.ITTObjectListBox;
    labelActionDate: TTVisual.ITTLabel;
    labelApplicationDate: TTVisual.ITTLabel;
    labelEyes: TTVisual.ITTLabel;
    labelMotorAnswer: TTVisual.ITTLabel;
    labelNote: TTVisual.ITTLabel;
    labelOralAnswer: TTVisual.ITTLabel;
    labelTotalScore: TTVisual.ITTLabel;
    MotorAnswer: TTVisual.ITTObjectListBox;
    Note: TTVisual.ITTTextBox;
    OralAnswer: TTVisual.ITTObjectListBox;
    TotalScore: TTVisual.ITTEnumComboBox;
    public nursingGlaskowComaScaleFormViewModel: NursingGlaskowComaScaleFormViewModel = new NursingGlaskowComaScaleFormViewModel();
    public get _NursingGlaskowComaScale(): NursingGlaskowComaScale {
        return this._TTObject as NursingGlaskowComaScale;
    }
    private NursingGlaskowComaScaleForm_DocumentUrl: string = '/api/NursingGlaskowComaScaleService/NursingGlaskowComaScaleForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NursingGlaskowComaScaleForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    public EyesLastSpanCount: Array<number> = [1, 2]; //son iki cell'i boş bırak
    public OralLastSpanCount: Array<number> = [1]; //son iki cell'i boş bırak
    public glaskowComaScoreEnumArray: Array<any> = [];
    public glaskowComaScoreEnumArrayCache: any;
    public _totalScoreName: string = "";

    // ***** Method declarations start *****

    private async Eyes_SelectedObjectChanged(): Promise<void> {
        let that = this;
        that.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale.TotalScore = (await NursingGlaskowComaScaleService.CalcGlaskowComaScaleTotalScore(this._NursingGlaskowComaScale));
        //this.onTotalScoreChanged(that.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale.TotalScore);
        this.getEnumName();
    }
    private async MotorAnswer_SelectedObjectChanged(): Promise<void> {
        let that = this;
        that.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale.TotalScore = (await NursingGlaskowComaScaleService.CalcGlaskowComaScaleTotalScore(this._NursingGlaskowComaScale));
        //this.onTotalScoreChanged(that.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale.TotalScore);
        this.getEnumName();
    }
    private async OralAnswer_SelectedObjectChanged(): Promise<void> {
        let that = this;
        that.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale.TotalScore = (await NursingGlaskowComaScaleService.CalcGlaskowComaScaleTotalScore(this._NursingGlaskowComaScale));
        //this.onTotalScoreChanged(that.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale.TotalScore);
        this.getEnumName();
    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
    }
    protected async ClientSidePreScript(): Promise<void> {
        //TODO:ismail isteğin detayına göre açılacak
        //this.ReadOnly = true;
        if (this["NursAppReadOnly"] != null)
            this.nursingGlaskowComaScaleFormViewModel.ReadOnly = (this.nursingGlaskowComaScaleFormViewModel.ReadOnly || this["NursAppReadOnly"]);

        if (this.nursingGlaskowComaScaleFormViewModel.ReadOnly)
            this.DropStateButton(NursingGlaskowComaScale.NursingGlaskowComaScaleStates.Cancelled);
        super.ClientSidePreScript();
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NursingGlaskowComaScale();
        this.nursingGlaskowComaScaleFormViewModel = new NursingGlaskowComaScaleFormViewModel();
        this._ViewModel = this.nursingGlaskowComaScaleFormViewModel;
        this.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale = this._TTObject as NursingGlaskowComaScale;
        this.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale.MotorAnswer = new GlaskowComaScaleDefinition();
        this.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale.Eyes = new GlaskowComaScaleDefinition();
        this.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale.OralAnswer = new GlaskowComaScaleDefinition();
    }

    protected loadViewModel() {
        let that = this;

        that.nursingGlaskowComaScaleFormViewModel = this._ViewModel as NursingGlaskowComaScaleFormViewModel;
        that._TTObject = this.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale;
        if (this.nursingGlaskowComaScaleFormViewModel == null)
            this.nursingGlaskowComaScaleFormViewModel = new NursingGlaskowComaScaleFormViewModel();
        if (this.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale == null)
            this.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale = new NursingGlaskowComaScale();
        let motorAnswerObjectID = that.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale["MotorAnswer"];
        if (motorAnswerObjectID != null && (typeof motorAnswerObjectID === 'string')) {
            let motorAnswer = that.nursingGlaskowComaScaleFormViewModel.GlaskowComaScaleDefinitions.find(o => o.ObjectID.toString() === motorAnswerObjectID.toString());
             if (motorAnswer) {
                that.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale.MotorAnswer = motorAnswer;
            }
        }
        let eyesObjectID = that.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale["Eyes"];
        if (eyesObjectID != null && (typeof eyesObjectID === 'string')) {
            let eyes = that.nursingGlaskowComaScaleFormViewModel.GlaskowComaScaleDefinitions.find(o => o.ObjectID.toString() === eyesObjectID.toString());
             if (eyes) {
                that.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale.Eyes = eyes;
            }
        }
        let oralAnswerObjectID = that.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale["OralAnswer"];
        if (oralAnswerObjectID != null && (typeof oralAnswerObjectID === 'string')) {
            let oralAnswer = that.nursingGlaskowComaScaleFormViewModel.GlaskowComaScaleDefinitions.find(o => o.ObjectID.toString() === oralAnswerObjectID.toString());
             if (oralAnswer) {
                that.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale.OralAnswer = oralAnswer;
            }
        }
        this.getEnumName();
    }


    async ngOnInit()  {
        let that = this;
        let promiseArray: Array<Promise<any>> = new Array<any>();
        promiseArray.push(this.GetGlaskowComaScaleScoreEnum());
        Promise.all(promiseArray).then((sonuc: Array<any>) => {
            that.glaskowComaScoreEnumArray = sonuc[0];
            this.load(NursingGlaskowComaScaleFormViewModel);
        }).catch(error => {
            this.messageService.showError(error);
        });
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._NursingGlaskowComaScale != null && this._NursingGlaskowComaScale.ActionDate != event) {
                this._NursingGlaskowComaScale.ActionDate = event;
            }
        }
    }

    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._NursingGlaskowComaScale != null && this._NursingGlaskowComaScale.ApplicationDate != event) {
                this._NursingGlaskowComaScale.ApplicationDate = event;
            }
        }
    }

    public onEyesChanged(event): void {
        if (event != null) {
            if (this._NursingGlaskowComaScale != null && this._NursingGlaskowComaScale.Eyes != event) {
                this._NursingGlaskowComaScale.Eyes = event;
            }
        }
        this.Eyes_SelectedObjectChanged();
    }

    public onMotorAnswerChanged(event): void {
        if (event != null) {
            if (this._NursingGlaskowComaScale != null && this._NursingGlaskowComaScale.MotorAnswer != event) {
                this._NursingGlaskowComaScale.MotorAnswer = event;
            }
        }
        this.MotorAnswer_SelectedObjectChanged();
    }

    public onNoteChanged(event): void {
        if (event != null) {
            if (this._NursingGlaskowComaScale != null && this._NursingGlaskowComaScale.Note != event) {
                this._NursingGlaskowComaScale.Note = event;
            }
        }
    }

    public onOralAnswerChanged(event): void {
        if (event != null) {
            if (this._NursingGlaskowComaScale != null && this._NursingGlaskowComaScale.OralAnswer != event) {
                this._NursingGlaskowComaScale.OralAnswer = event;
            }
        }
        this.OralAnswer_SelectedObjectChanged();
    }

    public onTotalScoreChanged(event): void {
        if (event != null) {
            if (this._NursingGlaskowComaScale != null && this._NursingGlaskowComaScale.TotalScore != event) {
                this._NursingGlaskowComaScale.TotalScore = event;
            }
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
        redirectProperty(this.TotalScore, "Value", this.__ttObject, "TotalScore");
        redirectProperty(this.Note, "Text", this.__ttObject, "Note");
    }

    public initFormControls(): void {
        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = i18n("M23773", "Uygulama Zamanı(Base)");
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 15;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Custom;
        this.ApplicationDate.CustomFormat = "dd.MM.yyyy hh:mm";
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 14;

        this.labelMotorAnswer = new TTVisual.TTLabel();
        this.labelMotorAnswer.Text = i18n("M19140", "Motor Cevap");
        this.labelMotorAnswer.Name = "labelMotorAnswer";
        this.labelMotorAnswer.TabIndex = 13;

        this.MotorAnswer = new TTVisual.TTObjectListBox();
        this.MotorAnswer.ListDefName = "GKSMotorAnswerListDefinition";
        this.MotorAnswer.Name = "MotorAnswer";
        this.MotorAnswer.TabIndex = 4;

        this.labelEyes = new TTVisual.TTLabel();
        this.labelEyes.Text = i18n("M14956", "Gözler");
        this.labelEyes.Name = "labelEyes";
        this.labelEyes.TabIndex = 11;

        this.Eyes = new TTVisual.TTObjectListBox();
        this.Eyes.ListDefName = "GKSEyesListDefinition";
        this.Eyes.Name = "Eyes";
        this.Eyes.TabIndex = 2;

        this.labelOralAnswer = new TTVisual.TTLabel();
        this.labelOralAnswer.Text = i18n("M22212", "Sözel Cevap");
        this.labelOralAnswer.Name = "labelOralAnswer";
        this.labelOralAnswer.TabIndex = 7;

        this.OralAnswer = new TTVisual.TTObjectListBox();
        this.OralAnswer.ListDefName = "GKSOralAnswerListDefinition";
        this.OralAnswer.Name = "OralAnswer";
        this.OralAnswer.TabIndex = 3;

        this.labelTotalScore = new TTVisual.TTLabel();
        this.labelTotalScore.Text = i18n("M23518", "Toplam Puan");
        this.labelTotalScore.Name = "labelTotalScore";
        this.labelTotalScore.TabIndex = 5;

        this.TotalScore = new TTVisual.TTEnumComboBox();
        this.TotalScore.DataTypeName = "GlaskowComaScaleScoreEnum";
        this.TotalScore.BackColor = "#F0F0F0";
        this.TotalScore.Enabled = false;
        this.TotalScore.Name = "TotalScore";
        this.TotalScore.TabIndex = 1;

        this.labelNote = new TTVisual.TTLabel();
        this.labelNote.Text = i18n("M19476", "Not");
        this.labelNote.Name = "labelNote";
        this.labelNote.TabIndex = 3;

        this.Note = new TTVisual.TTTextBox();
        this.Note.Name = "Note";
        this.Note.TabIndex = 5;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M14828", "Glaskowun Kendi Tarihi");
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 1;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.Controls = [this.labelApplicationDate, this.ApplicationDate, this.labelMotorAnswer, this.MotorAnswer, this.labelEyes, this.Eyes, this.labelOralAnswer, this.OralAnswer, this.labelTotalScore, this.TotalScore, this.labelNote, this.Note, this.labelActionDate, this.ActionDate];

    }

    public async GetGlaskowComaScaleScoreEnum(): Promise<any> {
        let enumName: string = "GlaskowComaScaleScoreEnum";
        if (!this.glaskowComaScoreEnumArrayCache) {
            this.glaskowComaScoreEnumArrayCache = await this.httpService.get('/api/NursingGlaskowComaScaleService/GetEnumValues?enumName=' + enumName);
            return this.glaskowComaScoreEnumArrayCache;
        }
        else {
            return this.glaskowComaScoreEnumArrayCache;
        }
    }

    public getEnumName()
    {
        let _tempValue = this.glaskowComaScoreEnumArray.find(p => p.Value == this.nursingGlaskowComaScaleFormViewModel._NursingGlaskowComaScale.TotalScore);
        this._totalScoreName = _tempValue == undefined ? "" : _tempValue.Name;
    }

}
