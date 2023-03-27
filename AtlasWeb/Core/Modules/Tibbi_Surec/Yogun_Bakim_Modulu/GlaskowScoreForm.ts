//$0B4D863C
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { GlaskowScoreFormViewModel } from './GlaskowScoreFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { GlaskowScore, GlaskowComaScaleScoreEnum } from 'NebulaClient/Model/AtlasClientModel';
import { GlaskowComaScaleDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { BaseMultipleDataEntryForm } from '../Tibbi_Surec_Evrensel_Modulu/BaseMultipleDataEntryForm';

@Component({
    selector: 'GlaskowScoreForm',
    templateUrl: './GlaskowScoreForm.html',
    providers: [MessageService]
})
export class GlaskowScoreForm extends BaseMultipleDataEntryForm implements OnInit {
    EntryDate: TTVisual.ITTDateTimePicker;
    Eyes: TTVisual.ITTObjectListBox;
    labelEntryDate: TTVisual.ITTLabel;
    labelEyes: TTVisual.ITTLabel;
    labelMotorAnswer: TTVisual.ITTLabel;
    labelOralAnswer: TTVisual.ITTLabel;
    labelTotal: TTVisual.ITTLabel;
    labelTotalScore: TTVisual.ITTLabel;
    MotorAnswer: TTVisual.ITTObjectListBox;
    OralAnswer: TTVisual.ITTObjectListBox;
    Total: TTVisual.ITTTextBox;
    TotalScore: TTVisual.ITTEnumComboBox;
    public glaskowScoreFormViewModel: GlaskowScoreFormViewModel = new GlaskowScoreFormViewModel();
    public get _GlaskowScore(): GlaskowScore {
        return this._TTObject as GlaskowScore;
    }
    private GlaskowScoreForm_DocumentUrl: string = '/api/GlaskowScoreService/GlaskowScoreForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.GlaskowScoreForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public EyesLastSpanCount: Array<number> = [1, 2]; //son iki cell'i boş bırak
    public OralLastSpanCount: Array<number> = [1]; //son iki cell'i boş bırak
    public glaskowComaScoreEnumArray: Array<any> = [];
    public glaskowComaScoreEnumArrayCache: any;

    public eyeScore: number;
    public oralScore: number;
    public motorScore: number;
    public _totalScoreName: string = "";
    public _totalScoreNumber: number;


    public async SetTotalScore(eyeScore, oralScore, motorScore) {
        let toplam = 0;

        if (eyeScore != null)
            toplam += eyeScore;
        if (motorScore != null)
            toplam += motorScore;
        if (oralScore != null)
            toplam += oralScore;

        this._totalScoreNumber = toplam;
        this.glaskowScoreFormViewModel._GlaskowScore.Total = toplam;
        this._GlaskowScore.Total = toplam;

        if (toplam >= 15) {
            this.TotalScore.SelectedValue = GlaskowComaScaleScoreEnum.Normal; //oryante
            this.glaskowScoreFormViewModel._GlaskowScore.TotalScore = GlaskowComaScaleScoreEnum.Normal;
            this._GlaskowScore.TotalScore = GlaskowComaScaleScoreEnum.Normal;
        } else if (toplam >= 13) {
            this.TotalScore.SelectedValue = GlaskowComaScaleScoreEnum.Weak; //konfüze
            this.glaskowScoreFormViewModel._GlaskowScore.TotalScore = GlaskowComaScaleScoreEnum.Weak;
            this._GlaskowScore.TotalScore = GlaskowComaScaleScoreEnum.Weak;
        } else if (toplam >= 8) {
            this.TotalScore.SelectedValue = GlaskowComaScaleScoreEnum.Medium; //stupor
            this.glaskowScoreFormViewModel._GlaskowScore.TotalScore = GlaskowComaScaleScoreEnum.Medium;
            this._GlaskowScore.TotalScore = GlaskowComaScaleScoreEnum.Medium;
        } else if (toplam >= 4) {
            this.TotalScore.SelectedValue = GlaskowComaScaleScoreEnum.Perikoma; //perikoma
            this.glaskowScoreFormViewModel._GlaskowScore.TotalScore = GlaskowComaScaleScoreEnum.Perikoma;
            this._GlaskowScore.TotalScore = GlaskowComaScaleScoreEnum.Perikoma;
        }
        else {
            this.TotalScore.SelectedValue = GlaskowComaScaleScoreEnum.Coma; //koma
            this.glaskowScoreFormViewModel._GlaskowScore.TotalScore = GlaskowComaScaleScoreEnum.Coma;
            this._GlaskowScore.TotalScore = GlaskowComaScaleScoreEnum.Coma;
        }
        await this.getEnumName();
    }
    public async getEnumName() {
        let _tempValue = this.glaskowComaScoreEnumArray.find(p => p.Value == this.glaskowScoreFormViewModel._GlaskowScore.TotalScore);
        let scoreName = _tempValue == undefined ? "" : _tempValue.Name;
        this._totalScoreName = "Toplam Skor: " + this.glaskowScoreFormViewModel._GlaskowScore.Total + " - " + scoreName;
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

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new GlaskowScore();
        this.glaskowScoreFormViewModel = new GlaskowScoreFormViewModel();
        this._ViewModel = this.glaskowScoreFormViewModel;
        this.glaskowScoreFormViewModel._GlaskowScore = this._TTObject as GlaskowScore;
        this.glaskowScoreFormViewModel._GlaskowScore.OralAnswer = new GlaskowComaScaleDefinition();
        this.glaskowScoreFormViewModel._GlaskowScore.MotorAnswer = new GlaskowComaScaleDefinition();
        this.glaskowScoreFormViewModel._GlaskowScore.Eyes = new GlaskowComaScaleDefinition();
    }

    protected loadViewModel() {
        let that = this;
        that.glaskowScoreFormViewModel = this._ViewModel as GlaskowScoreFormViewModel;
        that._TTObject = this.glaskowScoreFormViewModel._GlaskowScore;
        if (this.glaskowScoreFormViewModel == null)
            this.glaskowScoreFormViewModel = new GlaskowScoreFormViewModel();
        if (this.glaskowScoreFormViewModel._GlaskowScore == null)
            this.glaskowScoreFormViewModel._GlaskowScore = new GlaskowScore();
        let oralAnswerObjectID = that.glaskowScoreFormViewModel._GlaskowScore["OralAnswer"];
        if (oralAnswerObjectID != null && (typeof oralAnswerObjectID === "string")) {
            let oralAnswer = that.glaskowScoreFormViewModel.GlaskowComaScaleDefinitions.find(o => o.ObjectID.toString() === oralAnswerObjectID.toString());
            if (oralAnswer) {
                that.glaskowScoreFormViewModel._GlaskowScore.OralAnswer = oralAnswer;
            }
        }

        let motorAnswerObjectID = that.glaskowScoreFormViewModel._GlaskowScore["MotorAnswer"];
        if (motorAnswerObjectID != null && (typeof motorAnswerObjectID === "string")) {
            let motorAnswer = that.glaskowScoreFormViewModel.GlaskowComaScaleDefinitions.find(o => o.ObjectID.toString() === motorAnswerObjectID.toString());
            if (motorAnswer) {
                that.glaskowScoreFormViewModel._GlaskowScore.MotorAnswer = motorAnswer;
            }
        }

        let eyesObjectID = that.glaskowScoreFormViewModel._GlaskowScore["Eyes"];
        if (eyesObjectID != null && (typeof eyesObjectID === "string")) {
            let eyes = that.glaskowScoreFormViewModel.GlaskowComaScaleDefinitions.find(o => o.ObjectID.toString() === eyesObjectID.toString());
            if (eyes) {
                that.glaskowScoreFormViewModel._GlaskowScore.Eyes = eyes;
            }
        }

        if (that.glaskowScoreFormViewModel._GlaskowScore.Total == null && (this.glaskowScoreFormViewModel._GlaskowScore.Eyes != null || this.glaskowScoreFormViewModel._GlaskowScore.OralAnswer != null || this.glaskowScoreFormViewModel._GlaskowScore.MotorAnswer != null)) {
            this.SetTotalScore(this.glaskowScoreFormViewModel._GlaskowScore.Eyes, this.glaskowScoreFormViewModel._GlaskowScore.OralAnswer, this.glaskowScoreFormViewModel._GlaskowScore.MotorAnswer);
        } else if (that.glaskowScoreFormViewModel._GlaskowScore.Total != null) {
            this.getEnumName();
        }
    }

    async ngOnInit() {
        let that = this;
        let promiseArray: Array<Promise<any>> = new Array<any>();
        promiseArray.push(this.GetGlaskowComaScaleScoreEnum());
        Promise.all(promiseArray).then((sonuc: Array<any>) => {
            that.glaskowComaScoreEnumArray = sonuc[0];
            this.load(GlaskowScoreFormViewModel);
        }).catch(error => {
            this.messageService.showError(error);
        });
    }

    public onEntryDateChanged(event): void {
        if (this._GlaskowScore != null && this._GlaskowScore.EntryDate != event) {
            this._GlaskowScore.EntryDate = event;
        }
    }

    public onEyesChanged(event): void {
        if (event != null) {
            if (this._GlaskowScore != null) {
                this._GlaskowScore.Eyes = event;
                this.eyeScore = event.Score;
                this.SetTotalScore(this.eyeScore, this.oralScore, this.motorScore);

            }
        }
    }

    public onMotorAnswerChanged(event): void {
        if (event != null) {
            if (this._GlaskowScore != null) {
                this._GlaskowScore.MotorAnswer = event;
                this.motorScore = event.Score;
                this.SetTotalScore(this.eyeScore, this.oralScore, this.motorScore);
            }
        }
    }

    public onOralAnswerChanged(event): void {
        if (event != null) {
            if (this._GlaskowScore != null) {
                this._GlaskowScore.OralAnswer = event;
                this.oralScore = event.Score;

                this.SetTotalScore(this.eyeScore, this.oralScore, this.motorScore);
            }
        }
    }

    public onTotalChanged(event): void {
        if (this._GlaskowScore != null && this._GlaskowScore.Total != event) {
            this._GlaskowScore.Total = event;
        }
    }

    public onTotalScoreChanged(event): void {
        if (this._GlaskowScore != null && this._GlaskowScore.TotalScore != event) {
            this._GlaskowScore.TotalScore = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.TotalScore, "Value", this.__ttObject, "TotalScore");
        redirectProperty(this.Total, "Text", this.__ttObject, "Total");
        redirectProperty(this.EntryDate, "Value", this.__ttObject, "EntryDate");
    }

    public initFormControls(): void {

        this.labelTotal = new TTVisual.TTLabel();
        this.labelTotal.Text = "Toplam Puan";
        this.labelTotal.Name = "labelTotal";
        this.labelTotal.TabIndex = 11;

        this.Total = new TTVisual.TTTextBox();
        this.Total.Name = "Total";
        this.Total.TabIndex = 10;

        this.labelOralAnswer = new TTVisual.TTLabel();
        this.labelOralAnswer.Text = "Sözel Cevap";
        this.labelOralAnswer.Name = "labelOralAnswer";
        this.labelOralAnswer.TabIndex = 9;

        this.OralAnswer = new TTVisual.TTObjectListBox();
        this.OralAnswer.ListDefName = "GKSOralAnswerListDefinition";
        this.OralAnswer.Name = "OralAnswer";
        this.OralAnswer.TabIndex = 8;

        this.labelMotorAnswer = new TTVisual.TTLabel();
        this.labelMotorAnswer.Text = "Motor Cevap";
        this.labelMotorAnswer.Name = "labelMotorAnswer";
        this.labelMotorAnswer.TabIndex = 7;

        this.MotorAnswer = new TTVisual.TTObjectListBox();
        this.MotorAnswer.ListDefName = "GKSMotorAnswerListDefinition";
        this.MotorAnswer.Name = "MotorAnswer";
        this.MotorAnswer.TabIndex = 6;

        this.labelEyes = new TTVisual.TTLabel();
        this.labelEyes.Text = "Gözler";
        this.labelEyes.Name = "labelEyes";
        this.labelEyes.TabIndex = 5;

        this.Eyes = new TTVisual.TTObjectListBox();
        this.Eyes.ListDefName = "GKSEyesListDefinition";
        this.Eyes.Name = "Eyes";
        this.Eyes.TabIndex = 4;

        this.labelEntryDate = new TTVisual.TTLabel();
        this.labelEntryDate.Text = "Giriş Yapılan Zaman";
        this.labelEntryDate.Name = "labelEntryDate";
        this.labelEntryDate.TabIndex = 3;

        this.EntryDate = new TTVisual.TTDateTimePicker();
        this.EntryDate.Format = DateTimePickerFormat.Long;
        this.EntryDate.Name = "EntryDate";
        this.EntryDate.TabIndex = 2;

        this.labelTotalScore = new TTVisual.TTLabel();
        this.labelTotalScore.Text = "Toplam Skor";
        this.labelTotalScore.Name = "labelTotalScore";
        this.labelTotalScore.TabIndex = 1;

        this.TotalScore = new TTVisual.TTEnumComboBox();
        this.TotalScore.DataTypeName = "GlaskowComaScaleScoreEnum";
        this.TotalScore.Name = "TotalScore";
        this.TotalScore.TabIndex = 0;

        this.Controls = [this.labelTotalScore, this.labelTotal, this.Total, this.labelOralAnswer, this.OralAnswer, this.labelMotorAnswer, this.MotorAnswer, this.labelEyes, this.Eyes, this.labelEntryDate, this.EntryDate, this.TotalScore];

    }


}
