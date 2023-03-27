//$2777C8C0
import { Component, ViewChild, OnInit, ApplicationRef, Output, EventEmitter } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { KvcRiskScoreFormViewModel } from './KvcRiskScoreFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { KvcRiskScore, Surgery } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { FormSaveInfo } from 'NebulaClient/Mscorlib/FormSaveInfo';
import { ServiceLocator } from '../../../wwwroot/app/Fw/Services/ServiceLocator';
import { KvcResultEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Convert } from '../../../wwwroot/app/NebulaClient/Mscorlib/Convert';

@Component({
    selector: 'KvcRiskScoreForm',
    templateUrl: './KvcRiskScoreForm.html',
    providers: [MessageService]
})
export class KvcRiskScoreForm extends TTVisual.TTForm implements OnInit {
    ActiveEndocarditis: TTVisual.ITTCheckBox;
    AgePoint: TTVisual.ITTTextBox;
    CardiacOperation: TTVisual.ITTCheckBox;
    CriticalPreop: TTVisual.ITTCheckBox;
    DiabetesMellitus: TTVisual.ITTCheckBox;
    EkstrakardiyakArteriopati: TTVisual.ITTCheckBox;
    EntryDate: TTVisual.ITTDateTimePicker;
    IsWoman: TTVisual.ITTCheckBox;
    KahLung: TTVisual.ITTCheckBox;
    KahRaspiration: TTVisual.ITTCheckBox;
    KidneyFailure: TTVisual.ITTCheckBox;
    KidneyFunction: TTVisual.ITTCheckBox;
    labelAgePoint: TTVisual.ITTLabel;
    labelEntryDate: TTVisual.ITTLabel;
    labelTotalScore: TTVisual.ITTLabel;
    LV30to50: TTVisual.ITTCheckBox;
    LVLess30: TTVisual.ITTCheckBox;
    PostMIVSD: TTVisual.ITTCheckBox;
    PulmonaryHypertension: TTVisual.ITTCheckBox;
    ThoracicAorta: TTVisual.ITTCheckBox;
    TotalScore: TTVisual.ITTTextBox;

    P_AgePoint: TTVisual.ITTTextBox;
    P_IsWoman: TTVisual.ITTTextBox;
    P_Kah: TTVisual.ITTTextBox;
    P_EkstrakardiyakArteriopati: TTVisual.ITTTextBox;
    P_CardiacOperation: TTVisual.ITTTextBox;
    P_KidneyFunction: TTVisual.ITTTextBox;
    P_KidneyFailure: TTVisual.ITTTextBox;
    P_ActiveEndocarditis: TTVisual.ITTTextBox;
    P_CriticalPreop: TTVisual.ITTTextBox;
    P_DiabetesMellitus: TTVisual.ITTTextBox;
    P_LVLess30: TTVisual.ITTTextBox;
    P_LV30to50: TTVisual.ITTTextBox;
    P_PulmonaryHypertension: TTVisual.ITTTextBox;
    P_ThoracicAorta: TTVisual.ITTTextBox;
    P_PostMIVSD: TTVisual.ITTTextBox;

    public kvcRiskScoreFormViewModel: KvcRiskScoreFormViewModel = new KvcRiskScoreFormViewModel();
    public get _KvcRiskScore(): KvcRiskScore {
        return this._TTObject as KvcRiskScore;
    }
    private KvcRiskScoreForm_DocumentUrl: string = '/api/KvcRiskScoreService/KvcRiskScoreForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('KVCRISKSCORE', 'KvcRiskScoreForm');
        this._DocumentServiceUrl = this.KvcRiskScoreForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    _surgeryData: Surgery;
    _kvcData: KvcRiskScore;
    public setInputParam(value: any) {
        if (value != null && value['Surgery'] != null) {
            this._surgeryData = value['Surgery'] as Surgery;
            this.kvcRiskScoreFormViewModel._Surgery = this._surgeryData;
        }
        if (value != null && value['KvcRiskScoreParams'] != null) {
            this._kvcData = value['KvcRiskScoreParams'] as KvcRiskScore;
            this.kvcRiskScoreFormViewModel._KvcRiskScore = this._kvcData;
        }
    }

    @Output() sendKvcRiskScore: EventEmitter<KvcRiskScoreFormViewModel> = new EventEmitter<KvcRiskScoreFormViewModel>();
    public SaveKvcRiskScore() {
        this.sendKvcRiskScore.emit();
    }
    protected async save(saveInfo?: FormSaveInfo) {
        try {
            if (this.kvcRiskScoreFormViewModel._KvcRiskScore.Surgery == null && this._surgeryData != null) {
                this.kvcRiskScoreFormViewModel._KvcRiskScore.Surgery = this._surgeryData;
            }
            this.ActionExecuted.emit(this.kvcRiskScoreFormViewModel);
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
            this.ActionFailed.emit(err);
            throw err;
        }
    }

    public cancelForm() {
        this.ActionExecuted.emit({ Cancelled: true });
    }

    protected async PreScript() {
        if (this._kvcData != null) {
            this.kvcRiskScoreFormViewModel._KvcRiskScore.KahLung = this._kvcData.KahLung;
            this.kvcRiskScoreFormViewModel._KvcRiskScore.KahRaspiration = this._kvcData.KahRaspiration;
            this.kvcRiskScoreFormViewModel._KvcRiskScore.EkstrakardiyakArteriopati = this._kvcData.EkstrakardiyakArteriopati;
            this.kvcRiskScoreFormViewModel._KvcRiskScore.CardiacOperation = this._kvcData.CardiacOperation;
            this.kvcRiskScoreFormViewModel._KvcRiskScore.KidneyFunction = this._kvcData.KidneyFunction;
            this.kvcRiskScoreFormViewModel._KvcRiskScore.KidneyFailure = this._kvcData.KidneyFailure;
            this.kvcRiskScoreFormViewModel._KvcRiskScore.ActiveEndocarditis = this._kvcData.ActiveEndocarditis;
            this.kvcRiskScoreFormViewModel._KvcRiskScore.CriticalPreop = this._kvcData.CriticalPreop;
            this.kvcRiskScoreFormViewModel._KvcRiskScore.DiabetesMellitus = this._kvcData.DiabetesMellitus;
            this.kvcRiskScoreFormViewModel._KvcRiskScore.LVLess30 = this._kvcData.LVLess30;
            this.kvcRiskScoreFormViewModel._KvcRiskScore.LV30to50 = this._kvcData.LV30to50;
            this.kvcRiskScoreFormViewModel._KvcRiskScore.PulmonaryHypertension = this._kvcData.PulmonaryHypertension;
            this.kvcRiskScoreFormViewModel._KvcRiskScore.ThoracicAorta = this._kvcData.ThoracicAorta;
            this.kvcRiskScoreFormViewModel._KvcRiskScore.PostMIVSD = this._kvcData.PostMIVSD;
        }

        this.SetAllKvcPoints();
        this.CalculateKvcScore();
    }
    protected SetAllKvcPoints() {

        this.SetP_AgePoint(Convert.ToInt32(this.AgePoint["Text"]));
        this.SetP_IsWoman(this.IsWoman["Value"]);
        this.SetP_Kah(this.KahLung["Value"], this.KahRaspiration["Value"]);
        this.SetP_EkstrakardiyakArteriopati(this.EkstrakardiyakArteriopati["Value"]);
        this.SetP_CardiacOperation(this.CardiacOperation["Value"]);
        this.SetP_KidneyFunction(this.KidneyFunction["Value"]);
        this.SetP_KidneyFailure(this.KidneyFailure["Value"]);
        this.SetP_ActiveEndocarditis(this.ActiveEndocarditis["Value"]);
        this.SetP_CriticalPreop(this.CriticalPreop["Value"]);
        this.SetP_DiabetesMellitus(this.DiabetesMellitus["Value"]);
        this.SetP_LVLess30(this.LVLess30["Value"]);
        this.SetP_LV30to50(this.LV30to50["Value"]);
        this.SetP_PulmonaryHypertension(this.PulmonaryHypertension["Value"]);
        this.SetP_ThoracicAorta(this.ThoracicAorta["Value"]);
        this.SetP_PostMIVSD(this.PostMIVSD["Value"]);

    }

    protected CalculateKvcScore() {
        let KvcPoint = 0;

        if (this.P_AgePoint.Text == null)
            this.P_AgePoint.Text = "0";
        KvcPoint += parseFloat(this.P_AgePoint.Text);

        if (this.P_IsWoman.Text == null)
            this.P_IsWoman.Text = "0";
        KvcPoint += parseFloat(this.P_IsWoman.Text);

        if (this.P_Kah.Text == null)
            this.P_Kah.Text = "0";
        KvcPoint += parseFloat(this.P_Kah.Text);

        if (this.P_EkstrakardiyakArteriopati.Text == null)
            this.P_EkstrakardiyakArteriopati.Text = "0";
        KvcPoint += parseFloat(this.P_EkstrakardiyakArteriopati.Text);

        if (this.P_CardiacOperation.Text == null)
            this.P_CardiacOperation.Text = "0";
        KvcPoint += parseFloat(this.P_CardiacOperation.Text);

        if (this.P_KidneyFunction.Text == null)
            this.P_KidneyFunction.Text = "0";
        KvcPoint += parseFloat(this.P_KidneyFunction.Text);

        if (this.P_KidneyFailure.Text == null)
            this.P_KidneyFailure.Text = "0";
        KvcPoint += parseFloat(this.P_KidneyFailure.Text);

        if (this.P_ActiveEndocarditis.Text == null)
            this.P_ActiveEndocarditis.Text = "0";
        KvcPoint += parseFloat(this.P_ActiveEndocarditis.Text);

        if (this.P_CriticalPreop.Text == null)
            this.P_CriticalPreop.Text = "0";
        KvcPoint += parseFloat(this.P_CriticalPreop.Text);

        if (this.P_DiabetesMellitus.Text == null)
            this.P_DiabetesMellitus.Text = "0";
        KvcPoint += parseFloat(this.P_DiabetesMellitus.Text);

        if (this.P_LVLess30.Text == null)
            this.P_LVLess30.Text = "0";
        KvcPoint += parseFloat(this.P_LVLess30.Text);

        if (this.P_LV30to50.Text == null)
            this.P_LV30to50.Text = "0";
        KvcPoint += parseFloat(this.P_LV30to50.Text);

        if (this.P_PulmonaryHypertension.Text == null)
            this.P_PulmonaryHypertension.Text = "0";
        KvcPoint += parseFloat(this.P_PulmonaryHypertension.Text);

        if (this.P_ThoracicAorta.Text == null)
            this.P_ThoracicAorta.Text = "0";
        KvcPoint += parseFloat(this.P_ThoracicAorta.Text);

        if (this.P_PostMIVSD.Text == null)
            this.P_PostMIVSD.Text = "0";
        KvcPoint += parseFloat(this.P_PostMIVSD.Text);

        this._KvcRiskScore.TotalScore = KvcPoint;

        if (KvcPoint <= 3) {
            this._KvcRiskScore.TotalRisk = KvcResultEnum.LowRisk;
        } else if (KvcPoint <= 6) {
            this._KvcRiskScore.TotalRisk = KvcResultEnum.MiddleRisk;
        } else {
            this._KvcRiskScore.TotalRisk = KvcResultEnum.HighRisk;
        }
    }

    //#region KVC Puan Eşleştirmeleri
    protected SetP_AgePoint(value: number) {
        let point = 0;
        if (value != null && value >= 60) {
            if (value <= 65) {
                point = 1;
            } else if (value <= 70) {
                point = 2;
            } else {
                point = 3;
            }
        }

        this.P_AgePoint.Text = point.toString();
    }

    protected SetP_IsWoman(value: boolean) {
        let point = 0;
        if (value != null && value == true) {
            point = 1;
        }
        this.P_IsWoman.Text = point.toString();
    }

    protected SetP_Kah(value1: boolean, value2: boolean) {
        let point = 0;
        if ((value1 != null && value1 == true) || (value2 != null && value2 == true)) {
            point = 1;
        }
        this.P_Kah.Text = point.toString();
    }

    protected SetP_EkstrakardiyakArteriopati(value: boolean) {
        let point = 0;
        if (value != null && value == true) {
            point = 2;
        }
        this.P_EkstrakardiyakArteriopati.Text = point.toString();
    }

    protected SetP_CardiacOperation(value: boolean) {
        let point = 0;
        if (value != null && value == true) {
            point = 3;
        }
        this.P_CardiacOperation.Text = point.toString();
    }

    protected SetP_KidneyFunction(value: boolean) {
        let point = 0;
        if (value != null && value == true) {
            point = 2;
        }
        this.P_KidneyFunction.Text = point.toString();
    }

    protected SetP_KidneyFailure(value: boolean) {
        let point = 0;
        if (value != null && value == true) {
            point = 5;
        }
        this.P_KidneyFailure.Text = point.toString();
    }

    protected SetP_ActiveEndocarditis(value: boolean) {
        let point = 0;
        if (value != null && value == true) {
            point = 3;
        }
        this.P_ActiveEndocarditis.Text = point.toString();
    }

    protected SetP_CriticalPreop(value: boolean) {
        let point = 0;
        if (value != null && value == true) {
            point = 3;
        }
        this.P_CriticalPreop.Text = point.toString();
    }

    protected SetP_DiabetesMellitus(value: boolean) {
        let point = 0;
        if (value != null && value == true) {
            point = 2;
        }
        this.P_DiabetesMellitus.Text = point.toString();
    }

    protected SetP_LVLess30(value: boolean) {
        let point = 0;
        if (value != null && value == true) {
            point = 1;
        }
        this.P_LVLess30.Text = point.toString();
    }

    protected SetP_LV30to50(value: boolean) {
        let point = 0;
        if (value != null && value == true) {
            point = 3;
        }
        this.P_LV30to50.Text = point.toString();
    }

    protected SetP_PulmonaryHypertension(value: boolean) {
        let point = 0;
        if (value != null && value == true) {
            point = 2;
        }
        this.P_PulmonaryHypertension.Text = point.toString();
    }

    protected SetP_ThoracicAorta(value: boolean) {
        let point = 0;
        if (value != null && value == true) {
            point = 4;
        }
        this.P_ThoracicAorta.Text = point.toString();
    }

    protected SetP_PostMIVSD(value: boolean) {
        let point = 0;
        if (value != null && value == true) {
            point = 5;
        }
        this.P_PostMIVSD.Text = point.toString();
    }

    //#endregion KVC Puan Eşleştirmeleri

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new KvcRiskScore();
        this.kvcRiskScoreFormViewModel = new KvcRiskScoreFormViewModel();
        this._ViewModel = this.kvcRiskScoreFormViewModel;
        this.kvcRiskScoreFormViewModel._KvcRiskScore = this._TTObject as KvcRiskScore;
    }

    protected loadViewModel() {
        let that = this;
        that.kvcRiskScoreFormViewModel = this._ViewModel as KvcRiskScoreFormViewModel;
        that._TTObject = this.kvcRiskScoreFormViewModel._KvcRiskScore;
        if (this.kvcRiskScoreFormViewModel == null)
            this.kvcRiskScoreFormViewModel = new KvcRiskScoreFormViewModel();
        if (this.kvcRiskScoreFormViewModel._KvcRiskScore == null)
            this.kvcRiskScoreFormViewModel._KvcRiskScore = new KvcRiskScore();

    }

    async ngOnInit() {
        await this.load(KvcRiskScoreFormViewModel);
    }

    public onActiveEndocarditisChanged(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.ActiveEndocarditis != event) {
            this._KvcRiskScore.ActiveEndocarditis = event;

            //Hesaplamalar
            this.SetP_ActiveEndocarditis(event);
            this.CalculateKvcScore();
        }
    }

    public onAgePointChanged(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.AgePoint != event) {
            this._KvcRiskScore.AgePoint = event;

            //Hesaplamalar
            this.SetP_AgePoint(event);
            this.CalculateKvcScore();
        }
    }

    public onCardiacOperationChanged(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.CardiacOperation != event) {
            this._KvcRiskScore.CardiacOperation = event;

            //Hesaplamalar
            this.SetP_CardiacOperation(event);
            this.CalculateKvcScore();
        }
    }

    public onCriticalPreopChanged(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.CriticalPreop != event) {
            this._KvcRiskScore.CriticalPreop = event;

            //Hesaplamalar
            this.SetP_CriticalPreop(event);
            this.CalculateKvcScore();
        }
    }

    public onDiabetesMellitusChanged(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.DiabetesMellitus != event) {
            this._KvcRiskScore.DiabetesMellitus = event;

            //Hesaplamalar
            this.SetP_DiabetesMellitus(event);
            this.CalculateKvcScore();
        }
    }

    public onEkstrakardiyakArteriopatiChanged(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.EkstrakardiyakArteriopati != event) {
            this._KvcRiskScore.EkstrakardiyakArteriopati = event;

            //Hesaplamalar
            this.SetP_EkstrakardiyakArteriopati(event);
            this.CalculateKvcScore();
        }
    }

    public onEntryDateChanged(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.EntryDate != event) {
            this._KvcRiskScore.EntryDate = event;
        }
    }

    public onIsWomanChanged(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.IsWoman != event) {
            this._KvcRiskScore.IsWoman = event;

            //Hesaplamalar
            this.SetP_IsWoman(event);
            this.CalculateKvcScore();
        }
    }

    public onKahLungChanged(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.KahLung != event) {
            this._KvcRiskScore.KahLung = event;

            //Hesaplamalar
            this.SetP_Kah(event, this._KvcRiskScore.KahRaspiration);
            this.CalculateKvcScore();
        }
    }

    public onKahRaspirationChanged(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.KahRaspiration != event) {
            this._KvcRiskScore.KahRaspiration = event;

            //Hesaplamalar
            this.SetP_Kah(event, this._KvcRiskScore.KahLung);
            this.CalculateKvcScore();
        }
    }

    public onKidneyFailureChanged(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.KidneyFailure != event) {
            this._KvcRiskScore.KidneyFailure = event;

            //Hesaplamalar
            this.SetP_KidneyFailure(event);
            this.CalculateKvcScore();
        }
    }

    public onKidneyFunctionChanged(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.KidneyFunction != event) {
            this._KvcRiskScore.KidneyFunction = event;

            //Hesaplamalar
            this.SetP_KidneyFunction(event);
            this.CalculateKvcScore();
        }
    }

    public onLV30to50Changed(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.LV30to50 != event) {
            this._KvcRiskScore.LV30to50 = event;

            //Hesaplamalar
            this.SetP_LV30to50(event);
            this.CalculateKvcScore();
        }
    }

    public onLVLess30Changed(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.LVLess30 != event) {
            this._KvcRiskScore.LVLess30 = event;

            //Hesaplamalar
            this.SetP_LVLess30(event);
            this.CalculateKvcScore();
        }
    }

    public onPostMIVSDChanged(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.PostMIVSD != event) {
            this._KvcRiskScore.PostMIVSD = event;

            //Hesaplamalar
            this.SetP_PostMIVSD(event);
            this.CalculateKvcScore();
        }
    }

    public onPulmonaryHypertensionChanged(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.PulmonaryHypertension != event) {
            this._KvcRiskScore.PulmonaryHypertension = event;

            //Hesaplamalar
            this.SetP_PulmonaryHypertension(event);
            this.CalculateKvcScore();
        }
    }

    public onThoracicAortaChanged(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.ThoracicAorta != event) {
            this._KvcRiskScore.ThoracicAorta = event;

            //Hesaplamalar
            this.SetP_ThoracicAorta(event);
            this.CalculateKvcScore();
        }
    }

    public onTotalScoreChanged(event): void {
        if (this._KvcRiskScore != null && this._KvcRiskScore.TotalScore != event) {
            this._KvcRiskScore.TotalScore = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.EntryDate, "Value", this.__ttObject, "EntryDate");
        redirectProperty(this.AgePoint, "Text", this.__ttObject, "AgePoint");
        redirectProperty(this.IsWoman, "Value", this.__ttObject, "IsWoman");
        redirectProperty(this.KahLung, "Value", this.__ttObject, "KahLung");
        redirectProperty(this.EkstrakardiyakArteriopati, "Value", this.__ttObject, "EkstrakardiyakArteriopati");
        redirectProperty(this.KidneyFailure, "Value", this.__ttObject, "KidneyFailure");
        redirectProperty(this.ActiveEndocarditis, "Value", this.__ttObject, "ActiveEndocarditis");
        redirectProperty(this.CriticalPreop, "Value", this.__ttObject, "CriticalPreop");
        redirectProperty(this.DiabetesMellitus, "Value", this.__ttObject, "DiabetesMellitus");
        redirectProperty(this.LVLess30, "Value", this.__ttObject, "LVLess30");
        redirectProperty(this.PulmonaryHypertension, "Value", this.__ttObject, "PulmonaryHypertension");
        redirectProperty(this.ThoracicAorta, "Value", this.__ttObject, "ThoracicAorta");
        redirectProperty(this.PostMIVSD, "Value", this.__ttObject, "PostMIVSD");
        redirectProperty(this.KahRaspiration, "Value", this.__ttObject, "KahRaspiration");
        redirectProperty(this.CardiacOperation, "Value", this.__ttObject, "CardiacOperation");
        redirectProperty(this.KidneyFunction, "Value", this.__ttObject, "KidneyFunction");
        redirectProperty(this.LV30to50, "Value", this.__ttObject, "LV30to50");
        redirectProperty(this.TotalScore, "Text", this.__ttObject, "TotalScore");
    }

    public initFormControls(): void {

        this.P_AgePoint = new TTVisual.TTTextBox();
        this.P_AgePoint.BackColor = "#F0F0F0";
        this.P_AgePoint.ReadOnly = true;
        this.P_AgePoint.Name = "P_BodyTemperature";
        this.P_AgePoint.TabIndex = 39;

        this.P_IsWoman = new TTVisual.TTTextBox();
        this.P_IsWoman.BackColor = "#F0F0F0";
        this.P_IsWoman.ReadOnly = true;
        this.P_IsWoman.Name = "P_BodyTemperature";
        this.P_IsWoman.TabIndex = 39;

        this.P_Kah = new TTVisual.TTTextBox();
        this.P_Kah.BackColor = "#F0F0F0";
        this.P_Kah.ReadOnly = true;
        this.P_Kah.Name = "P_BodyTemperature";
        this.P_Kah.TabIndex = 39;

        this.P_EkstrakardiyakArteriopati = new TTVisual.TTTextBox();
        this.P_EkstrakardiyakArteriopati.BackColor = "#F0F0F0";
        this.P_EkstrakardiyakArteriopati.ReadOnly = true;
        this.P_EkstrakardiyakArteriopati.Name = "P_BodyTemperature";
        this.P_EkstrakardiyakArteriopati.TabIndex = 39;

        this.P_CardiacOperation = new TTVisual.TTTextBox();
        this.P_CardiacOperation.BackColor = "#F0F0F0";
        this.P_CardiacOperation.ReadOnly = true;
        this.P_CardiacOperation.Name = "P_BodyTemperature";
        this.P_CardiacOperation.TabIndex = 39;

        this.P_KidneyFunction = new TTVisual.TTTextBox();
        this.P_KidneyFunction.BackColor = "#F0F0F0";
        this.P_KidneyFunction.ReadOnly = true;
        this.P_KidneyFunction.Name = "P_BodyTemperature";
        this.P_KidneyFunction.TabIndex = 39;

        this.P_KidneyFailure = new TTVisual.TTTextBox();
        this.P_KidneyFailure.BackColor = "#F0F0F0";
        this.P_KidneyFailure.ReadOnly = true;
        this.P_KidneyFailure.Name = "P_BodyTemperature";
        this.P_KidneyFailure.TabIndex = 39;

        this.P_ActiveEndocarditis = new TTVisual.TTTextBox();
        this.P_ActiveEndocarditis.BackColor = "#F0F0F0";
        this.P_ActiveEndocarditis.ReadOnly = true;
        this.P_ActiveEndocarditis.Name = "P_BodyTemperature";
        this.P_ActiveEndocarditis.TabIndex = 39;

        this.P_CriticalPreop = new TTVisual.TTTextBox();
        this.P_CriticalPreop.BackColor = "#F0F0F0";
        this.P_CriticalPreop.ReadOnly = true;
        this.P_CriticalPreop.Name = "P_BodyTemperature";
        this.P_CriticalPreop.TabIndex = 39;

        this.P_DiabetesMellitus = new TTVisual.TTTextBox();
        this.P_DiabetesMellitus.BackColor = "#F0F0F0";
        this.P_DiabetesMellitus.ReadOnly = true;
        this.P_DiabetesMellitus.Name = "P_BodyTemperature";
        this.P_DiabetesMellitus.TabIndex = 39;

        this.P_LVLess30 = new TTVisual.TTTextBox();
        this.P_LVLess30.BackColor = "#F0F0F0";
        this.P_LVLess30.ReadOnly = true;
        this.P_LVLess30.Name = "P_BodyTemperature";
        this.P_LVLess30.TabIndex = 39;

        this.P_LV30to50 = new TTVisual.TTTextBox();
        this.P_LV30to50.BackColor = "#F0F0F0";
        this.P_LV30to50.ReadOnly = true;
        this.P_LV30to50.Name = "P_BodyTemperature";
        this.P_LV30to50.TabIndex = 39;

        this.P_PulmonaryHypertension = new TTVisual.TTTextBox();
        this.P_PulmonaryHypertension.BackColor = "#F0F0F0";
        this.P_PulmonaryHypertension.ReadOnly = true;
        this.P_PulmonaryHypertension.Name = "P_BodyTemperature";
        this.P_PulmonaryHypertension.TabIndex = 39;

        this.P_ThoracicAorta = new TTVisual.TTTextBox();
        this.P_ThoracicAorta.BackColor = "#F0F0F0";
        this.P_ThoracicAorta.ReadOnly = true;
        this.P_ThoracicAorta.Name = "P_BodyTemperature";
        this.P_ThoracicAorta.TabIndex = 39;

        this.P_PostMIVSD = new TTVisual.TTTextBox();
        this.P_PostMIVSD.BackColor = "#F0F0F0";
        this.P_PostMIVSD.ReadOnly = true;
        this.P_PostMIVSD.Name = "P_BodyTemperature";
        this.P_PostMIVSD.TabIndex = 39;

        this.PulmonaryHypertension = new TTVisual.TTCheckBox();
        this.PulmonaryHypertension.Value = false;
        this.PulmonaryHypertension.Text = "Pulmoner hipertansiyon";
        this.PulmonaryHypertension.Title = "Pulmoner hipertansiyon";
        this.PulmonaryHypertension.Name = "PulmonaryHypertension";
        this.PulmonaryHypertension.TabIndex = 21;

        this.IsWoman = new TTVisual.TTCheckBox();
        this.IsWoman.Value = false;
        this.IsWoman.Text = "Hasta kadın mı?";
        this.IsWoman.Title = "Hasta kadın mı?";
        this.IsWoman.Name = "IsWoman";
        this.IsWoman.ReadOnly = true;
        this.IsWoman.TabIndex = 20;

        this.labelEntryDate = new TTVisual.TTLabel();
        this.labelEntryDate.Text = "Giriş Yapılan Zaman";
        this.labelEntryDate.Name = "labelEntryDate";
        this.labelEntryDate.TabIndex = 19;

        this.EntryDate = new TTVisual.TTDateTimePicker();
        this.EntryDate.Format = DateTimePickerFormat.Long;
        this.EntryDate.Name = "EntryDate";
        this.EntryDate.TabIndex = 18;

        this.labelTotalScore = new TTVisual.TTLabel();
        this.labelTotalScore.Text = "TOPLAM PUAN";
        this.labelTotalScore.Name = "labelTotalScore";
        this.labelTotalScore.TabIndex = 17;

        this.TotalScore = new TTVisual.TTTextBox();
        this.TotalScore.Name = "TotalScore";
        this.TotalScore.TabIndex = 16;

        this.AgePoint = new TTVisual.TTTextBox();
        this.AgePoint.Name = "AgePoint";
        this.AgePoint.TabIndex = 1;

        this.ThoracicAorta = new TTVisual.TTCheckBox();
        this.ThoracicAorta.Value = false;
        this.ThoracicAorta.Text = "Torasik aorta cerrahisi";
        this.ThoracicAorta.Title = "Torasik aorta cerrahisi";
        this.ThoracicAorta.Name = "ThoracicAorta";
        this.ThoracicAorta.TabIndex = 15;

        this.PostMIVSD = new TTVisual.TTCheckBox();
        this.PostMIVSD.Value = false;
        this.PostMIVSD.Text = "Post MI VSD";
        this.PostMIVSD.Title = "Post MI VSD";
        this.PostMIVSD.Name = "PostMIVSD";
        this.PostMIVSD.TabIndex = 14;

        this.LVLess30 = new TTVisual.TTCheckBox();
        this.LVLess30.Value = false;
        this.LVLess30.Text = "EF <%30";
        this.LVLess30.Title = "EF <%30";
        this.LVLess30.Name = "LVLess30";
        this.LVLess30.TabIndex = 13;

        this.LV30to50 = new TTVisual.TTCheckBox();
        this.LV30to50.Value = false;
        this.LV30to50.Text = "EF %30-%50 arasında olması";
        this.LV30to50.Title = "EF %30-%50 arasında olması";
        this.LV30to50.Name = "LV30to50";
        this.LV30to50.TabIndex = 12;

        this.KidneyFunction = new TTVisual.TTCheckBox();
        this.KidneyFunction.Value = false;
        this.KidneyFunction.Text = "Böbrek fonksiyon bozukluğu";
        this.KidneyFunction.Title = "Böbrek fonksiyon bozukluğu";
        this.KidneyFunction.Name = "KidneyFunction";
        this.KidneyFunction.TabIndex = 11;

        this.KidneyFailure = new TTVisual.TTCheckBox();
        this.KidneyFailure.Value = false;
        this.KidneyFailure.Text = "Böbrek yetmezliği";
        this.KidneyFailure.Title = "Böbrek yetmezliği";
        this.KidneyFailure.Name = "KidneyFailure";
        this.KidneyFailure.TabIndex = 10;

        this.KahRaspiration = new TTVisual.TTCheckBox();
        this.KahRaspiration.Value = false;
        this.KahRaspiration.Text = "1. Solunum fonksiyon testinde";
        this.KahRaspiration.Title = "1. Solunum fonksiyon testinde";
        this.KahRaspiration.Name = "KahRaspiration";
        this.KahRaspiration.TabIndex = 9;

        this.KahLung = new TTVisual.TTCheckBox();
        this.KahLung.Value = false;
        this.KahLung.Text = "2. Azalmış akciğer hacmi";
        this.KahLung.Title = "2. Azalmış akciğer hacmi";
        this.KahLung.Name = "KahLung";
        this.KahLung.TabIndex = 8;

        this.EkstrakardiyakArteriopati = new TTVisual.TTCheckBox();
        this.EkstrakardiyakArteriopati.Value = false;
        this.EkstrakardiyakArteriopati.Text = "Ekstrakardiyak arteriopati";
        this.EkstrakardiyakArteriopati.Title = "Ekstrakardiyak arteriopati";
        this.EkstrakardiyakArteriopati.Name = "EkstrakardiyakArteriopati";
        this.EkstrakardiyakArteriopati.TabIndex = 6;

        this.DiabetesMellitus = new TTVisual.TTCheckBox();
        this.DiabetesMellitus.Value = false;
        this.DiabetesMellitus.Text = "Diabetes Mellitus";
        this.DiabetesMellitus.Title = "Diabetes Mellitus";
        this.DiabetesMellitus.Name = "DiabetesMellitus";
        this.DiabetesMellitus.TabIndex = 5;

        this.CriticalPreop = new TTVisual.TTCheckBox();
        this.CriticalPreop.Value = false;
        this.CriticalPreop.Text = "Kritik preoperatif durum";
        this.CriticalPreop.Title = "Kritik preoperatif durum";
        this.CriticalPreop.Name = "CriticalPreop";
        this.CriticalPreop.TabIndex = 4;

        this.CardiacOperation = new TTVisual.TTCheckBox();
        this.CardiacOperation.Value = false;
        this.CardiacOperation.Text = "Geçirilmiş kardiyak operasyon";
        this.CardiacOperation.Title = "Geçirilmiş kardiyak operasyon";
        this.CardiacOperation.Name = "CardiacOperation";
        this.CardiacOperation.TabIndex = 3;

        this.labelAgePoint = new TTVisual.TTLabel();
        this.labelAgePoint.Text = "Yaş";
        this.labelAgePoint.Name = "labelAgePoint";
        this.labelAgePoint.TabIndex = 2;

        this.ActiveEndocarditis = new TTVisual.TTCheckBox();
        this.ActiveEndocarditis.Value = false;
        this.ActiveEndocarditis.Text = "Aktif endokardit";
        this.ActiveEndocarditis.Title = "Aktif endokardit";
        this.ActiveEndocarditis.Name = "ActiveEndocarditis";
        this.ActiveEndocarditis.TabIndex = 0;

        this.Controls = [this.PulmonaryHypertension, this.IsWoman, this.labelEntryDate, this.EntryDate, this.labelTotalScore, this.TotalScore, this.AgePoint, this.ThoracicAorta, this.PostMIVSD, this.LVLess30, this.LV30to50, this.KidneyFunction, this.KidneyFailure, this.KahRaspiration, this.KahLung, this.EkstrakardiyakArteriopati, this.DiabetesMellitus, this.CriticalPreop, this.CardiacOperation, this.labelAgePoint, this.ActiveEndocarditis, this.P_AgePoint, this.P_IsWoman, this.P_Kah, this.P_EkstrakardiyakArteriopati, this.P_CardiacOperation, this.P_KidneyFunction, this.P_KidneyFailure, this.P_ActiveEndocarditis, this.P_CriticalPreop, this.P_DiabetesMellitus, this.P_LVLess30, this.P_LV30to50, this.P_PulmonaryHypertension, this.P_ThoracicAorta, this.P_PostMIVSD];

    }
}
