//$465C6A06
import { Component, OnInit, NgZone } from '@angular/core';
import { BaseNursingFallingDownRiskFormViewModel } from './BaseNursingFallingDownRiskFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { BaseNursingFallingDownRisk } from 'NebulaClient/Model/AtlasClientModel';
import { NursingFallingDownRisk } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Exception } from 'NebulaClient/Mscorlib/Exception';

import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from "app/NebulaClient/Mscorlib/GuidParam";

import { IModal, ModalInfo } from "Fw/Models/ModalInfo";
import { IModalService } from 'Fw/Services/IModalService';

@Component({
    selector: 'BaseNursingFallingDownRiskForm',
    templateUrl: './BaseNursingFallingDownRiskForm.html',
    providers: [MessageService]
})
export class BaseNursingFallingDownRiskForm extends BaseNursingDataEntryForm implements OnInit, IModal {
    ApplicationDate: TTVisual.ITTDateTimePicker;
    FallingDownRiskReason: TTVisual.ITTEnumComboBox;
    labelApplicationDate: TTVisual.ITTLabel;
    labelFallingDownRiskReason: TTVisual.ITTLabel;
    labelNote: TTVisual.ITTLabel;
    labelTotalScore: TTVisual.ITTLabel;
    Note: TTVisual.ITTTextBox;
    NursingFallingDownRisks: TTVisual.ITTGrid;
    RiskFactorNursingFallingDownRisk: TTVisual.ITTListBoxColumn;
    TotalScore: TTVisual.ITTTextBox;

    private _modalInfo: ModalInfo;

    public NursingFallingDownRisksColumns = [];
    public printButtonVisible: boolean = false;
    public baseNursingFallingDownRiskFormViewModel: BaseNursingFallingDownRiskFormViewModel = new BaseNursingFallingDownRiskFormViewModel();
    public get _BaseNursingFallingDownRisk(): BaseNursingFallingDownRisk {
        return this._TTObject as BaseNursingFallingDownRisk;
    }
    private BaseNursingFallingDownRiskForm_DocumentUrl: string = '/api/BaseNursingFallingDownRiskService/BaseNursingFallingDownRiskForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone,
        protected modalService: IModalService,
        protected reportService: AtlasReportService
    ) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseNursingFallingDownRiskForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BaseNursingFallingDownRisk();
        this.baseNursingFallingDownRiskFormViewModel = new BaseNursingFallingDownRiskFormViewModel();
        this._ViewModel = this.baseNursingFallingDownRiskFormViewModel;
        this.baseNursingFallingDownRiskFormViewModel._BaseNursingFallingDownRisk = this._TTObject as BaseNursingFallingDownRisk;
        this.baseNursingFallingDownRiskFormViewModel._BaseNursingFallingDownRisk.NursingFallingDownRisks = new Array<NursingFallingDownRisk>();
    }

    protected loadViewModel() {
        let that = this;

        that.baseNursingFallingDownRiskFormViewModel = this._ViewModel as BaseNursingFallingDownRiskFormViewModel;
        that._TTObject = this.baseNursingFallingDownRiskFormViewModel._BaseNursingFallingDownRisk;
        if (this.baseNursingFallingDownRiskFormViewModel == null)
            this.baseNursingFallingDownRiskFormViewModel = new BaseNursingFallingDownRiskFormViewModel();
        if (this.baseNursingFallingDownRiskFormViewModel._BaseNursingFallingDownRisk == null)
            this.baseNursingFallingDownRiskFormViewModel._BaseNursingFallingDownRisk = new BaseNursingFallingDownRisk();
        that.baseNursingFallingDownRiskFormViewModel._BaseNursingFallingDownRisk.NursingFallingDownRisks = that.baseNursingFallingDownRiskFormViewModel.NursingFallingDownRisksGridList;
        for (let detailItem of that.baseNursingFallingDownRiskFormViewModel.NursingFallingDownRisksGridList) {
            let riskFactorObjectID = detailItem["RiskFactor"];
            if (riskFactorObjectID != null && (typeof riskFactorObjectID === 'string')) {
                let riskFactor = that.baseNursingFallingDownRiskFormViewModel.FallingDownRiskDefinitions.find(o => o.ObjectID.toString() === riskFactorObjectID.toString());
                 if (riskFactor) {
                    detailItem.RiskFactor = riskFactor;
                }
            }
        }
        if (!this.baseNursingFallingDownRiskFormViewModel._BaseNursingFallingDownRisk.IsNew)
            this.printButtonVisible = true;
    }


    async ngOnInit() {
        let that = this;
        await this.load(BaseNursingFallingDownRiskFormViewModel);
  
    }

    public setInputParam(value: any) {
        if (value != undefined) {
            this.baseNursingFallingDownRiskFormViewModel._BaseNursingFallingDownRisk.NursingApplication = value;
            this._nursingApplication = value;
        }
    }
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }


    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        //if (transDef != null) {
        if (this.baseNursingFallingDownRiskFormViewModel._BaseNursingFallingDownRisk.FallingDownRiskReason == undefined)
            throw new Exception(i18n("M13390", "Düşme riski doldurma nedenini seçmeden işleme devan edemezsiniz."));

        //}
        this.baseNursingFallingDownRiskFormViewModel.FallingDownRiskDefinitionList = null;

        super.ClientSidePostScript(transDef);
    }

    protected async ClientSidePreScript(): Promise<void> {
        //TODO:ismail isteğin detayına göre açılacak
        //this.ReadOnly = true;
        if (this["NursAppReadOnly"] != null)
            this.baseNursingFallingDownRiskFormViewModel.ReadOnly = (this.baseNursingFallingDownRiskFormViewModel.ReadOnly || this["NursAppReadOnly"]);

        if (this.baseNursingFallingDownRiskFormViewModel.ReadOnly)
            this.DropStateButton(BaseNursingFallingDownRisk.BaseNursingDataEntryStates.Cancelled);
        super.ClientSidePreScript();
    }

    printReport() {
        let a: any = this.baseNursingFallingDownRiskFormViewModel._BaseNursingFallingDownRisk["NursingApplication"];
        const TTOBJECTID = new GuidParam(a);
        let reportParameters: any = { 'TTOBJECTID': TTOBJECTID };
        this.reportService.showReport('NursingFallingDownRiskReport', reportParameters);
    }

    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._BaseNursingFallingDownRisk != null && this._BaseNursingFallingDownRisk.ApplicationDate != event) {
                this._BaseNursingFallingDownRisk.ApplicationDate = event;
            }
        }
    }

    public onFallingDownRiskReasonChanged(event): void {
        if (event != null) {
            if (this._BaseNursingFallingDownRisk != null && this._BaseNursingFallingDownRisk.FallingDownRiskReason != event) {
                this._BaseNursingFallingDownRisk.FallingDownRiskReason = event;
            }
        }
    }

    public onNoteChanged(event): void {
        if (event != null) {
            if (this._BaseNursingFallingDownRisk != null && this._BaseNursingFallingDownRisk.Note != event) {
                this._BaseNursingFallingDownRisk.Note = event;
            }
        }
    }

    public onTotalScoreChanged(event): void {
        if (event != null) {
            if (this._BaseNursingFallingDownRisk != null && this._BaseNursingFallingDownRisk.TotalScore != event) {
                this._BaseNursingFallingDownRisk.TotalScore = event;
            }
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
        redirectProperty(this.TotalScore, "Text", this.__ttObject, "TotalScore");
        redirectProperty(this.FallingDownRiskReason, "Value", this.__ttObject, "FallingDownRiskReason");
        redirectProperty(this.Note, "Text", this.__ttObject, "Note");
    }

    public initFormControls(): void {
        this.labelFallingDownRiskReason = new TTVisual.TTLabel();
        this.labelFallingDownRiskReason.Text = i18n("M13391", "Düşme Riski Seçim Nedeni");
        this.labelFallingDownRiskReason.Name = "labelFallingDownRiskReason";
        this.labelFallingDownRiskReason.TabIndex = 8;

        this.FallingDownRiskReason = new TTVisual.TTEnumComboBox();
        this.FallingDownRiskReason.DataTypeName = "FallingDownRiskReasonEnum";
        this.FallingDownRiskReason.Name = "FallingDownRiskReason";
        this.FallingDownRiskReason.TabIndex = 7;

        this.NursingFallingDownRisks = new TTVisual.TTGrid();
        this.NursingFallingDownRisks.Name = "NursingFallingDownRisks";
        this.NursingFallingDownRisks.TabIndex = 6;

        this.RiskFactorNursingFallingDownRisk = new TTVisual.TTListBoxColumn();
        this.RiskFactorNursingFallingDownRisk.ListDefName = "FallingDownRiskFactorListDefinition";
        this.RiskFactorNursingFallingDownRisk.DataMember = "RiskFactor";
        this.RiskFactorNursingFallingDownRisk.DisplayIndex = 0;
        this.RiskFactorNursingFallingDownRisk.HeaderText = i18n("M21046", "Risk Faktörü");
        this.RiskFactorNursingFallingDownRisk.Name = "RiskFactorNursingFallingDownRisk";
        this.RiskFactorNursingFallingDownRisk.Width = 300;

        this.labelTotalScore = new TTVisual.TTLabel();
        this.labelTotalScore.Text = i18n("M23518", "Toplam Puan");
        this.labelTotalScore.Name = "labelTotalScore";
        this.labelTotalScore.TabIndex = 5;

        this.TotalScore = new TTVisual.TTTextBox();
        this.TotalScore.Name = "TotalScore";
        this.TotalScore.TabIndex = 4;

        this.Note = new TTVisual.TTTextBox();
        this.Note.Name = "Note";
        this.Note.TabIndex = 2;
        this.Note.Multiline = true;
        this.Note.Height = "140";

        this.labelNote = new TTVisual.TTLabel();
        this.labelNote.Text = i18n("M19476", "Not");
        this.labelNote.Name = "labelNote";
        this.labelNote.TabIndex = 3;

        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = i18n("M23772", "Uygulama Zamanı");
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 1;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 0;

        this.NursingFallingDownRisksColumns = [this.RiskFactorNursingFallingDownRisk];
        this.Controls = [this.labelFallingDownRiskReason, this.FallingDownRiskReason, this.NursingFallingDownRisks, this.RiskFactorNursingFallingDownRisk, this.labelTotalScore, this.TotalScore, this.Note, this.labelNote, this.labelApplicationDate, this.ApplicationDate];

    }

    public onCheckValueChanged(event, obj) {
        if (event != undefined) {

            if (event) {
                let _tempObj: NursingFallingDownRisk = new NursingFallingDownRisk();
                _tempObj.RiskFactor = obj;

                this.baseNursingFallingDownRiskFormViewModel.NursingFallingDownRisksGridList.push(_tempObj);
                this.CalcFallingDownRiskTotalScore(obj.Score);
            }
            else {
                //var index = this.baseNursingFallingDownRiskFormViewModel.NursingFallingDownRisksGridList.indexOf(_tempObj, 0);// işe yaramadı
                let index = this.baseNursingFallingDownRiskFormViewModel.NursingFallingDownRisksGridList.map(function (x) { return x.RiskFactor.ObjectID.toString(); }).indexOf(obj.ObjectID.toString());
                if (index > -1) {
                    this.baseNursingFallingDownRiskFormViewModel.NursingFallingDownRisksGridList.splice(index, 1);
                    this.CalcFallingDownRiskTotalScore((obj.Score * -1));
                }
            }
        }
    }

    public isValueExists(ObjectID: string): boolean {
        if (this.baseNursingFallingDownRiskFormViewModel.NursingFallingDownRisksGridList.length > 0)
            if (this.baseNursingFallingDownRiskFormViewModel.NursingFallingDownRisksGridList.find(o => o.RiskFactor.ObjectID.toString() == ObjectID) != undefined)
                return true;

        return false;
    }

    public CalcFallingDownRiskTotalScore(score) {
        if (this.baseNursingFallingDownRiskFormViewModel._BaseNursingFallingDownRisk.TotalScore)
            this.baseNursingFallingDownRiskFormViewModel._BaseNursingFallingDownRisk.TotalScore += score;
        else
            this.baseNursingFallingDownRiskFormViewModel._BaseNursingFallingDownRisk.TotalScore = score;
    }

    public onRiskReasonChanged(event) {
        let that = this;

        if (event != null) {
            if (this._BaseNursingFallingDownRisk != null && this._BaseNursingFallingDownRisk.FallingDownRiskReason != event) {
                this._BaseNursingFallingDownRisk.FallingDownRiskReason = event.value.Value;
            }
        }
    }

}
