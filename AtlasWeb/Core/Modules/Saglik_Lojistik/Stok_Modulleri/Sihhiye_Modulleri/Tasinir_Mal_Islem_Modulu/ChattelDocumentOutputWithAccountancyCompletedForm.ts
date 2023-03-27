//$A0E1578D
import { Component, OnInit, NgZone } from '@angular/core';
import { ChattelDocumentOutputWithAccountancyCompletedFormViewModel } from './ChattelDocumentOutputWithAccountancyCompletedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Accountancy, TasinirCikisHareketTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { BaseChattelDocumentOutputWithAccountancy } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentOutputWithAccountancy";
import { ChattelDocumentOutputWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { Store, PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { StockActionService, OutputForReGeneration, DocumentRecordLogReceiptNumber_Input, SendITSTo_Input } from "ObjectClassService/StockActionService";
import { ChattelDocumentOutputDetailWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { BooleanParam } from 'NebulaClient/Mscorlib/BooleanParam';
import { MKYS_ECikisStokHareketTurEnum } from 'NebulaClient/Model/AtlasClientModel';

import Exception from 'app/NebulaClient/System/Exception';
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { UsernamePwdBox } from 'NebulaClient/Visual/UsernamePwdBox';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { ModalActionResult } from "Fw/Models/ModalInfo";
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { Headers, RequestOptions, ResponseContentType } from '@angular/http';
import { CommonHelper } from 'app/Helper/CommonHelper';
import { AtlasHttpService } from 'app/Fw/Services/AtlasHttpService';
@Component({
    selector: 'ChattelDocumentOutputWithAccountancyCompletedForm',
    templateUrl: './ChattelDocumentOutputWithAccountancyCompletedForm.html',
    providers: [MessageService]
})
export class ChattelDocumentOutputWithAccountancyCompletedForm extends BaseChattelDocumentOutputWithAccountancy implements OnInit {
    BudgeTypeEnum: TTVisual.ITTEnumComboBoxColumn;
    cmdSendAgain: TTVisual.ITTButton;
    DescriptionsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentDateTimeDocumentRecordLog: TTVisual.ITTDateTimePickerColumn;
    DocumentRecordLogNumberDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogs: TTVisual.ITTGrid;
    DocumentRecordLogTabpage: TTVisual.ITTTabPage;
    DocumentRerocdLogTab: TTVisual.ITTTabPage;
    DocumentTransactionTypeDocumentRecordLog: TTVisual.ITTEnumComboBoxColumn;
    NumberOfRowsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    ReceiptNumber: TTVisual.ITTTextBoxColumn;
    SendToMKYS: TTVisual.ITTButton;
    SubjectDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    TakenGivenPlaceDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;

    public rowVisible: boolean;
    public rowPTSVisible: boolean;
    public PTSNumber: string;


    //public ChattelDocumentDetailsWithAccountancyColumns = [];
    public DocumentRecordLogsColumns = [];
    public StockActionSignDetailsColumns = [];
    public chattelDocumentOutputWithAccountancyCompletedFormViewModel: ChattelDocumentOutputWithAccountancyCompletedFormViewModel = new ChattelDocumentOutputWithAccountancyCompletedFormViewModel();
    public get _ChattelDocumentOutputWithAccountancy(): ChattelDocumentOutputWithAccountancy {
        return this._TTObject as ChattelDocumentOutputWithAccountancy;
    }
    private ChattelDocumentOutputWithAccountancyCompletedForm_DocumentUrl: string = '/api/ChattelDocumentOutputWithAccountancyService/ChattelDocumentOutputWithAccountancyCompletedForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private reportService: AtlasReportService,
        private http2: AtlasHttpService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ChattelDocumentOutputWithAccountancyCompletedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    receiptNumberError: string = "";
    controlOfCancelMKYS: boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        for (let log of this._ChattelDocumentOutputWithAccountancy.DocumentRecordLogs) {
            if (log.ReceiptNumber != null) {
                this.receiptNumberError = this.receiptNumberError + "." + log.ReceiptNumber.toString();
                this.controlOfCancelMKYS = false;
            }
        }

        if (this.controlOfCancelMKYS) {
            await super.ClientSidePostScript(transDef);
        }
        else {
            throw new Exception("MKYS'den silinmeyen fiş iptal edilemez. Lütfen önce fişi siliniz!" + this.receiptNumberError + " Ayniyatlı Kayıtları Siliniz.!");
            this.receiptNumberError = "";
        }
    }

    async onDocumentRecordLogsCellContentClicked(data: any) {
        if (data && this.onDocumentRecordLogsCellContentClicked && data.Row && data.Column) {
            let documentLog: DocumentRecordLog = <DocumentRecordLog>(data.Row.TTObject);
            if (documentLog.ReceiptNumber != null) {
                let input: DocumentRecordLogReceiptNumber_Input = new DocumentRecordLogReceiptNumber_Input();
                input.receiptNumber = documentLog.ReceiptNumber;
                if (data.Column.Name === 'DeleteMkysRow') {
                    let resultMessage: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '', documentLog.DocumentRecordLogNumber + " Tif numaralı fişi silmek istediğinizden emin misiniz?");
                    if (resultMessage === "OK") {
                        let result = await UsernamePwdBox.Show(true);
                        if ((<ModalActionResult>result).Result == DialogResult.OK) {
                            let params = <any>(<ModalActionResult>result).Param;
                            input.password = params.password;
                            input.documentRecordLogObjectID = documentLog.ObjectID.toString()
                            let deleteMessage: boolean = await StockActionService.DeleteMkysSelectedRow(input);
                            if (deleteMessage) {
                                ServiceLocator.MessageService.showInfo("MKYS'den Silme yapılmıştır.");
                                documentLog.ReceiptNumber = null;
                            } else {
                                ServiceLocator.MessageService.showError("Tekrar Deneyiniz Silme İşlemi Sırasında Hata Alındı.");
                            }
                        }
                    }
                }
            }
            else {
                ServiceLocator.MessageService.showInfo("Ayniyat ID Boş olduğundan bu işlem yapılamaz!");
            }
        }
    }

    // ***** Method declarations start *****

    public async prepareDocument_Click(): Promise<void> {
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ChattelDocumentOutputWithAccountancy.ObjectID.toString());
        for (let document of documentRecordLogs) {
            if (document.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                const objectIdParam = new GuidParam(document['ObjectID']);
                const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                this.reportService.showReport('ChattelDocumentInDetailReport', reportParameters);
            }
            if (document.DocumentTransactionType === DocumentTransactionTypeEnum.Out) {
                const objectIdParam = new GuidParam(document['ObjectID']);
                const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                this.reportService.showReport('ChattelDocumentOutDetailReport', reportParameters);
            }
        }
        // if (this._ChattelDocumentOutputWithAccountancy.Store.ObjectDefID.valueOf() === PharmacyStoreDefinition.ObjectDefID.id) {
        if (this._ChattelDocumentOutputWithAccountancy.outputStockMovementType === TasinirCikisHareketTurEnum.stokFazlasiDevir) {
            const objectIdParam = new GuidParam(this._ChattelDocumentOutputWithAccountancy.ObjectID);
            const IsContributionMarginParam = new BooleanParam(this._ChattelDocumentOutputWithAccountancy.IsContainsContributions);
            let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'IsContributionMargin': IsContributionMarginParam };
            this.reportService.showReport('PharmacyInvoiceReport', reportParameters);
        }
        // }
    }

    //dx-data-grid çevirme
    public getIsReadOnly() {
        return true;
    }
    //

    public mkysSonucMesaj: string;
    popupVisible: boolean = false;
    buttonText = "MKYS'ye GÖNDER";
    loadIndicatorVisible = false;
    reGenerateButtonVisible: boolean = true;


    public showLoadPanel: boolean = false;
    public LoadPanelMessage: string = "İşlemi yapılıyor Lütfen Bekleyiniz...";

    public async SendToITS_Click() {
        this.showLoadPanel = true;
        StockActionService.ITSForOutDocument(this._ChattelDocumentOutputWithAccountancy).then(res => {
            if (String.isNullOrEmpty(res) === false) {
                this.PTSNumber = "";
                this.itsButtonText = "ITS'ye Gönder";
                TTVisual.InfoBox.Alert(this.PTSNumber + " Numarası ile ITS sistemine bildirilmiştir.");
            } else {
                TTVisual.InfoBox.Alert(res);
            }
            this.showLoadPanel = false;
        }).catch(error => {
            this.showLoadPanel = false;
            TTVisual.InfoBox.Alert(error);
        });
    }

    public CreateXMLForPTS() {
        if (this._ChattelDocumentOutputWithAccountancy.PTSNumber != null) {
            let headers = new Headers();
            headers.set('Content-Type', 'application/json');
            let url: string = '/api/ChattelDocumentOutputWithAccountancyService/CreateITSXmlFile';
            let input = { id: this._ChattelDocumentOutputWithAccountancy.ObjectID };

            this.httpService.post<string>(url, input).then(
                x => {
                    const blob = new Blob([x], { type: 'text/plain' });
                    CommonHelper.saveFile(blob, this._ChattelDocumentOutputWithAccountancy.PTSNumber + ".xml");
                })
        }
        else {
            TTVisual.InfoBox.Alert("Önce ITS Sistemine Bildirmeniz Gerekmektedir.");
        }
    }





    public async SendToMKYS_Click(): Promise<void> {
        this.mkysSonucMesaj = '';
        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result == DialogResult.OK) {
            this.showLoadPanel = true;
            let params = <any>(<ModalActionResult>result).Param;
            try {

                this.buttonText = "GÖNDERİLİYOR...";
                this.loadIndicatorVisible = true;

                //-TODO İlaydax

                if (this._ChattelDocumentOutputWithAccountancy.CurrentStateDefID.toString() === ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputWithAccountancyStates.Completed.id) {
                    for (let log of this._ChattelDocumentOutputWithAccountancy.DocumentRecordLogs) {
                        if (log.ReceiptNumber == undefined) {
                            this.mkysSonucMesaj = await StockActionService.SendMKYSForOutputDocumentTS(this._ChattelDocumentOutputWithAccountancy, params.password);
                        }
                        if (log.ReceiptNumber != undefined)
                            this.mkysSonucMesaj += log.ReceiptNumber.toString() + " Ayniyat numarası ile MKYSye kaydolmuştur.";

                    }
                }
                //-TODO İlaydax
                if (this._ChattelDocumentOutputWithAccountancy.CurrentStateDefID.toString() === ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputWithAccountancyStates.Cancelled.id) {
                    for (let log of this._ChattelDocumentOutputWithAccountancy.DocumentRecordLogs) {
                        if (log.ReceiptNumber != undefined) {
                            this.mkysSonucMesaj = await StockActionService.SendDeleteMessageToMkysTS(this._ChattelDocumentOutputWithAccountancy, true, log.ReceiptNumber.Value, params.password);
                        }
                    }
                }

                this.showLoadPanel = false;
                this.buttonText = "MKYS'ye GÖNDER";
                this.loadIndicatorVisible = false;

                this.popupVisible = true;
            }
            catch (error) {
                this.showLoadPanel = false;
                this.buttonText = "MKYS'ye GÖNDER";
                this.loadIndicatorVisible = false;
                ServiceLocator.MessageService.showError(error);
            }
        }
    }

    public async reGenerateAction_Click(): Promise<void> {
        let result: OutputForReGeneration = null;
        try {
            result = await StockActionService.ReGenerateMyChattelDocumentOutputWithAccountancy(this._ChattelDocumentOutputWithAccountancy.ObjectID.toString());
            if (result.IsTheActionGenerated == true) {
                ServiceLocator.MessageService.showInfo(result.OutputMessage);
            }
            else {
                ServiceLocator.MessageService.showError(result.OutputMessage);
            }
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex.toString());
        }
    }

    public itsButtonText = "";
    public checkBoxValuePTS: boolean = false;
    public InvoiceNumberSecNo;
    public IsContainsContribution: boolean;
    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();

        if (this._ChattelDocumentOutputWithAccountancy.CurrentStateDefID.toString() == ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputWithAccountancyStates.Completed.id.toString()) {
            this.reGenerateButtonVisible = false;
        }

        if (this._ChattelDocumentOutputWithAccountancy.IsPTSAction === true) {
            this.rowPTSVisible = true;
            this.checkBoxValuePTS = true;
        } else {
            this.rowPTSVisible = false;
            this.checkBoxValuePTS = false;
        }

        //if (this._ChattelDocumentOutputWithAccountancy.Store.ObjectDefID.valueOf() !== PharmacyStoreDefinition.ObjectDefID.id) {
        //   this.rowVisible = false;
        //} else {
        this.rowVisible = true;
        // }

        if (this._ChattelDocumentOutputWithAccountancy.InvoiceNumberSec !== null && this._ChattelDocumentOutputWithAccountancy.InvoiceNumberSec !== undefined)
            this.InvoiceNumberSecNo = this._ChattelDocumentOutputWithAccountancy.InvoiceNumberSec.toString();

        if (this._ChattelDocumentOutputWithAccountancy.IsContainsContributions !== null && this._ChattelDocumentOutputWithAccountancy.IsContainsContributions !== undefined)
            this.IsContainsContribution = this._ChattelDocumentOutputWithAccountancy.IsContainsContributions;
        else
            this.IsContainsContribution = false;

        this.PTSNumber = this._ChattelDocumentOutputWithAccountancy.PTSNumber;

        if (this.PTSNumber == null)
            this.itsButtonText = "ITS'ye Gönder";
        else
            this.itsButtonText = "ITS'den Sil";

        this.SendToMKYS.ReadOnly = false;
    }


    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);

    }

    DocumentRecordLogs_CellValueChangedEmitted(data: any) { }
    onRowInsertting(data: any) { }
    onDocumentRecordLogsRowInserting(data: any) { }
    onSelectionChangeDocumentRecordLogs(data: any) { }
    onSelectionChange(data: any) { }
    onRowInserting(data: any) { }
    initNewRow(data: any) { }
    onCellContentClicked(data: any) { }
    initDocumentRecordLogsNewRow(data: any) { }



    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChattelDocumentOutputWithAccountancy();
        this.chattelDocumentOutputWithAccountancyCompletedFormViewModel = new ChattelDocumentOutputWithAccountancyCompletedFormViewModel();
        this._ViewModel = this.chattelDocumentOutputWithAccountancyCompletedFormViewModel;
        this.chattelDocumentOutputWithAccountancyCompletedFormViewModel._ChattelDocumentOutputWithAccountancy = this._TTObject as ChattelDocumentOutputWithAccountancy;
        this.chattelDocumentOutputWithAccountancyCompletedFormViewModel._ChattelDocumentOutputWithAccountancy.DocumentRecordLogs = new Array<DocumentRecordLog>();
        this.chattelDocumentOutputWithAccountancyCompletedFormViewModel._ChattelDocumentOutputWithAccountancy.Store = new Store();
        this.chattelDocumentOutputWithAccountancyCompletedFormViewModel._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy = new Array<ChattelDocumentOutputDetailWithAccountancy>();
        this.chattelDocumentOutputWithAccountancyCompletedFormViewModel._ChattelDocumentOutputWithAccountancy.Accountancy = new Accountancy();
        this.chattelDocumentOutputWithAccountancyCompletedFormViewModel._ChattelDocumentOutputWithAccountancy.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.chattelDocumentOutputWithAccountancyCompletedFormViewModel = this._ViewModel as ChattelDocumentOutputWithAccountancyCompletedFormViewModel;
        that._TTObject = this.chattelDocumentOutputWithAccountancyCompletedFormViewModel._ChattelDocumentOutputWithAccountancy;
        if (this.chattelDocumentOutputWithAccountancyCompletedFormViewModel == null)
            this.chattelDocumentOutputWithAccountancyCompletedFormViewModel = new ChattelDocumentOutputWithAccountancyCompletedFormViewModel();
        if (this.chattelDocumentOutputWithAccountancyCompletedFormViewModel._ChattelDocumentOutputWithAccountancy == null)
            this.chattelDocumentOutputWithAccountancyCompletedFormViewModel._ChattelDocumentOutputWithAccountancy = new ChattelDocumentOutputWithAccountancy();
        that.chattelDocumentOutputWithAccountancyCompletedFormViewModel._ChattelDocumentOutputWithAccountancy.DocumentRecordLogs = that.chattelDocumentOutputWithAccountancyCompletedFormViewModel.DocumentRecordLogsGridList;
        for (let detailItem of that.chattelDocumentOutputWithAccountancyCompletedFormViewModel.DocumentRecordLogsGridList) {
        }
        let storeObjectID = that.chattelDocumentOutputWithAccountancyCompletedFormViewModel._ChattelDocumentOutputWithAccountancy["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.chattelDocumentOutputWithAccountancyCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.chattelDocumentOutputWithAccountancyCompletedFormViewModel._ChattelDocumentOutputWithAccountancy.Store = store;
            }
        }
        that.chattelDocumentOutputWithAccountancyCompletedFormViewModel._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy = that.chattelDocumentOutputWithAccountancyCompletedFormViewModel.ChattelDocumentDetailsWithAccountancyGridList;
        for (let detailItem of that.chattelDocumentOutputWithAccountancyCompletedFormViewModel.ChattelDocumentDetailsWithAccountancyGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.chattelDocumentOutputWithAccountancyCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.chattelDocumentOutputWithAccountancyCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.chattelDocumentOutputWithAccountancyCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === "string")) {
                let stockLevelType = that.chattelDocumentOutputWithAccountancyCompletedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        let accountancyObjectID = that.chattelDocumentOutputWithAccountancyCompletedFormViewModel._ChattelDocumentOutputWithAccountancy["Accountancy"];
        if (accountancyObjectID != null && (typeof accountancyObjectID === "string")) {
            let accountancy = that.chattelDocumentOutputWithAccountancyCompletedFormViewModel.Accountancys.find(o => o.ObjectID.toString() === accountancyObjectID.toString());
            if (accountancy) {
                that.chattelDocumentOutputWithAccountancyCompletedFormViewModel._ChattelDocumentOutputWithAccountancy.Accountancy = accountancy;
            }
        }
        that.chattelDocumentOutputWithAccountancyCompletedFormViewModel._ChattelDocumentOutputWithAccountancy.StockActionSignDetails = that.chattelDocumentOutputWithAccountancyCompletedFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.chattelDocumentOutputWithAccountancyCompletedFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === "string")) {
                let signUser = that.chattelDocumentOutputWithAccountancyCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }

    }

    async ngOnInit() {
        let that = this;
        await this.load(ChattelDocumentOutputWithAccountancyCompletedFormViewModel);
        this.MKYS_TeslimAlan.ButtonEnabled = false;
        that.DocumentRecordLogDeleteMKYS.ReadOnly = false;
        this.MKYS_TeslimEden.ButtonEnabled = false;
        if (this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        if (this._ChattelDocumentOutputWithAccountancy.CurrentStateDefID.toString() == ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputWithAccountancyStates.Completed.id.toString()) {
            this.FormCaption = 'Taşınır Mal Çıkış  ( Tamamlandı )';
        }
        if (this._ChattelDocumentOutputWithAccountancy.CurrentStateDefID.toString() == ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputWithAccountancyStates.Cancelled.id.toString()) {
            this.FormCaption = 'Taşınır Mal Çıkış  ( İptal Edildi )';
        }
    }


    public onAccountancyChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.Accountancy != event) {
                this._ChattelDocumentOutputWithAccountancy.Accountancy = event;
            }
        }
        // this.Accountancy_SelectedObjectChanged();
    }

    public onAdditionalDocumentCountChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.AdditionalDocumentCount != event) {
                this._ChattelDocumentOutputWithAccountancy.AdditionalDocumentCount = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.Description != event) {
                this._ChattelDocumentOutputWithAccountancy.Description = event;
            }
        }
    }

    public onMKYS_AyniyatMakbuzIDChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_AyniyatMakbuzID != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_AyniyatMakbuzID = event;
            }
        }
    }

    public onMKYS_CikisIslemTuruChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_CikisIslemTuru != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_CikisIslemTuru = event;
            }
        }
    }

    public onMKYS_CikisStokHareketTuruChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_CikisStokHareketTuru != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_CikisStokHareketTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimAlan != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimEden != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimEden = event;
            }
        }
    }

    public onoutputStockMovementTypeChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.outputStockMovementType != event) {
                this._ChattelDocumentOutputWithAccountancy.outputStockMovementType = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.StockActionID != event) {
                this._ChattelDocumentOutputWithAccountancy.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.Store != event) {
                this._ChattelDocumentOutputWithAccountancy.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.TransactionDate != event) {
                this._ChattelDocumentOutputWithAccountancy.TransactionDate = event;
            }
        }
    }

    public onWaybillChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.Waybill != event) {
                this._ChattelDocumentOutputWithAccountancy.Waybill = event;
            }
        }
    }

    public onWaybillDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.WaybillDate != event) {
                this._ChattelDocumentOutputWithAccountancy.WaybillDate = event;
            }
        }
    }

    ChattelDocumentDetailsWithAccountancy_CellValueChangedEmitted(data: any) {
        if (data && this.ChattelDocumentDetailsWithAccountancy_CellValueChanged && data.Row && data.Column) {
            this.ChattelDocumentDetailsWithAccountancy_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.outputStockMovementType, "Value", this.__ttObject, "outputStockMovementType");
        redirectProperty(this.Waybill, "Text", this.__ttObject, "Waybill");
        redirectProperty(this.WaybillDate, "Value", this.__ttObject, "WaybillDate");
        redirectProperty(this.MKYS_CikisIslemTuru, "Value", this.__ttObject, "MKYS_CikisIslemTuru");
        redirectProperty(this.MKYS_CikisStokHareketTuru, "Value", this.__ttObject, "MKYS_CikisStokHareketTuru");
        redirectProperty(this.InvoiceNumberSec, "Text", this.__ttObject, "InvoiceNumberSec");
    }

    public initFormControls(): void {

        this.InvoiceNumberSec = new TTVisual.TTTextBox();
        this.InvoiceNumberSec.BackColor = "#F0F0F0";
        this.InvoiceNumberSec.ReadOnly = true;
        this.InvoiceNumberSec.Name = "InvoiceNumberSec";
        this.InvoiceNumberSec.TabIndex = 0;



        this.DocumentRecordLogTabpage = new TTVisual.TTTabPage();
        this.DocumentRecordLogTabpage.DisplayIndex = 2;
        this.DocumentRecordLogTabpage.TabIndex = 2;
        this.DocumentRecordLogTabpage.Text = "Taşınır Mal İşlem Belgeleri";
        this.DocumentRecordLogTabpage.Name = "DocumentRecordLogTabpage";


        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 131;

        this.Waybill = new TTVisual.TTTextBox();
        this.Waybill.Name = "Waybill";
        this.Waybill.TabIndex = 134;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.DocumentRerocdLogTab = new TTVisual.TTTabPage();
        this.DocumentRerocdLogTab.DisplayIndex = 1;
        this.DocumentRerocdLogTab.TabIndex = 1;
        this.DocumentRerocdLogTab.Text = "Taşınır Mal İşlem Belgeleri";
        this.DocumentRerocdLogTab.Name = "DocumentRerocdLogTab";


        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 130;

        this.labelWaybillDate = new TTVisual.TTLabel();
        this.labelWaybillDate.Text = i18n("M16573", "İrsaliye Tarihi");
        this.labelWaybillDate.Name = "labelWaybillDate";
        this.labelWaybillDate.TabIndex = 137;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.DocumentRecordLogs = new TTVisual.TTGrid();
        this.DocumentRecordLogs.HideCancelledData = false;
        this.DocumentRecordLogs.AllowUserToDeleteRows = false;
        this.DocumentRecordLogs.ReadOnly = true;
        this.DocumentRecordLogs.Name = "DocumentRecordLogs";
        this.DocumentRecordLogs.TabIndex = 0;
        this.DocumentRecordLogs.Height = 350;
        this.DocumentRecordLogs.AllowUserToAddRows = false;

        this.ChattelDocumentTabcontrol = new TTVisual.TTTabControl();
        this.ChattelDocumentTabcontrol.Name = "ChattelDocumentTabcontrol";
        this.ChattelDocumentTabcontrol.TabIndex = 6;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.WaybillDate = new TTVisual.TTDateTimePicker();
        this.WaybillDate.Format = DateTimePickerFormat.Short;
        this.WaybillDate.Name = "WaybillDate";
        this.WaybillDate.TabIndex = 136;


        this.DocumentRecordLogNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DocumentRecordLogNumberDocumentRecordLog.DataMember = "DocumentRecordLogNumber";
        this.DocumentRecordLogNumberDocumentRecordLog.DisplayIndex = 0;
        this.DocumentRecordLogNumberDocumentRecordLog.HeaderText = i18n("M11746", "Belge Numarası");
        this.DocumentRecordLogNumberDocumentRecordLog.Name = "DocumentRecordLogNumberDocumentRecordLog";
        this.DocumentRecordLogNumberDocumentRecordLog.Width = 120;

        this.ChattelDocumentTabpage = new TTVisual.TTTabPage();
        this.ChattelDocumentTabpage.DisplayIndex = 0;
        this.ChattelDocumentTabpage.TabIndex = 0;
        this.ChattelDocumentTabpage.Text = "Taşınır Malın";
        this.ChattelDocumentTabpage.Name = "ChattelDocumentTabpage";

        this.labelWaybill = new TTVisual.TTLabel();
        this.labelWaybill.Text = i18n("M16572", "İrsaliye Numarası");
        this.labelWaybill.Name = "labelWaybill";
        this.labelWaybill.TabIndex = 135;


        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 118;

        this.DocumentDateTimeDocumentRecordLog = new TTVisual.TTDateTimePickerColumn();
        this.DocumentDateTimeDocumentRecordLog.DataMember = "DocumentDateTime";
        this.DocumentDateTimeDocumentRecordLog.DisplayIndex = 1;
        this.DocumentDateTimeDocumentRecordLog.HeaderText = i18n("M11748", "Belge Tarihi");
        this.DocumentDateTimeDocumentRecordLog.Name = "DocumentDateTimeDocumentRecordLog";
        this.DocumentDateTimeDocumentRecordLog.Width = 120;

        this.ChattelDocumentDetailsWithAccountancy = new TTVisual.TTGrid();
        this.ChattelDocumentDetailsWithAccountancy.Required = true;
        this.ChattelDocumentDetailsWithAccountancy.Name = "ChattelDocumentDetailsWithAccountancy";
        this.ChattelDocumentDetailsWithAccountancy.TabIndex = 0;
        this.ChattelDocumentDetailsWithAccountancy.Height = 350;
        this.ChattelDocumentDetailsWithAccountancy.AllowUserToAddRows = false;
        this.ChattelDocumentDetailsWithAccountancy.AllowUserToDeleteRows = false;


        this.labeloutputStockMovementType = new TTVisual.TTLabel();
        this.labeloutputStockMovementType.Text = i18n("M12372", "Çıkış Hareket Türü");
        this.labeloutputStockMovementType.Name = "labeloutputStockMovementType";
        this.labeloutputStockMovementType.TabIndex = 133;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.DocumentTransactionTypeDocumentRecordLog = new TTVisual.TTEnumComboBoxColumn();
        this.DocumentTransactionTypeDocumentRecordLog.DataTypeName = "DocumentTransactionTypeEnum";
        this.DocumentTransactionTypeDocumentRecordLog.DataMember = "DocumentTransactionType";
        this.DocumentTransactionTypeDocumentRecordLog.DisplayIndex = 2;
        this.DocumentTransactionTypeDocumentRecordLog.HeaderText = i18n("M16834", "İşlem Çeşidi");
        this.DocumentTransactionTypeDocumentRecordLog.Name = "DocumentTransactionTypeDocumentRecordLog";
        this.DocumentTransactionTypeDocumentRecordLog.Width = 120;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;


        this.outputStockMovementType = new TTVisual.TTEnumComboBox();
        this.outputStockMovementType.DataTypeName = "TasinirCikisHareketTurEnum";
        this.outputStockMovementType.Name = "outputStockMovementType";
        this.outputStockMovementType.TabIndex = 132;


        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.BudgeTypeEnum = new TTVisual.TTEnumComboBoxColumn();
        this.BudgeTypeEnum.DataTypeName = "MKYS_EButceTurEnum";
        this.BudgeTypeEnum.DataMember = "BudgeType";
        this.BudgeTypeEnum.DisplayIndex = 3;
        this.BudgeTypeEnum.HeaderText = i18n("M12145", "Bütçe Tipi");
        this.BudgeTypeEnum.Name = "BudgeTypeEnum";
        this.BudgeTypeEnum.ReadOnly = true;
        this.BudgeTypeEnum.Width = 120;

        this.MaterialChattelDocumentDetailWithAccountancy = new TTVisual.TTListBoxColumn();
        this.MaterialChattelDocumentDetailWithAccountancy.AllowMultiSelect = true;
        this.MaterialChattelDocumentDetailWithAccountancy.ListDefName = "MaterialListDefinition";
        this.MaterialChattelDocumentDetailWithAccountancy.DataMember = "Material";
        this.MaterialChattelDocumentDetailWithAccountancy.AutoCompleteDialogHeight = '60%';
        this.MaterialChattelDocumentDetailWithAccountancy.AutoCompleteDialogWidth = '90%';
        this.MaterialChattelDocumentDetailWithAccountancy.DisplayIndex = 1;
        this.MaterialChattelDocumentDetailWithAccountancy.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialChattelDocumentDetailWithAccountancy.Name = "MaterialChattelDocumentDetailWithAccountancy";
        this.MaterialChattelDocumentDetailWithAccountancy.Width = 500;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.SubjectDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.SubjectDocumentRecordLog.DataMember = "Subject";
        this.SubjectDocumentRecordLog.DisplayIndex = 4;
        this.SubjectDocumentRecordLog.HeaderText = i18n("M14805", "Giriş ve Çıkış Nedenleri");
        this.SubjectDocumentRecordLog.Name = "SubjectDocumentRecordLog";
        this.SubjectDocumentRecordLog.Width = 200;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Material.Barcode";
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.NumberOfRowsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.NumberOfRowsDocumentRecordLog.DataMember = "NumberOfRows";
        this.NumberOfRowsDocumentRecordLog.DisplayIndex = 5;
        this.NumberOfRowsDocumentRecordLog.HeaderText = i18n("M17091", "Kalem Adedi");
        this.NumberOfRowsDocumentRecordLog.Name = "NumberOfRowsDocumentRecordLog";
        this.NumberOfRowsDocumentRecordLog.Width = 80;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "Material.DistributionTypeName";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 120;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.TakenGivenPlaceDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.TakenGivenPlaceDocumentRecordLog.DataMember = "TakenGivenPlace";
        this.TakenGivenPlaceDocumentRecordLog.DisplayIndex = 6;
        this.TakenGivenPlaceDocumentRecordLog.HeaderText = i18n("M10714", "Alındığı / Verildiği Yer");
        this.TakenGivenPlaceDocumentRecordLog.Name = "TakenGivenPlaceDocumentRecordLog";
        this.TakenGivenPlaceDocumentRecordLog.Width = 200;

        this.StoreStock = new TTVisual.TTTextBoxColumn();
        this.StoreStock.DataMember = "StoreStock";
        this.StoreStock.Format = "N2";
        this.StoreStock.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreStock.DisplayIndex = 4;
        this.StoreStock.HeaderText = i18n("M18957", "Mevcut");
        this.StoreStock.Name = "StoreStock";
        this.StoreStock.ReadOnly = true;
        this.StoreStock.Width = 120;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.ReceiptNumber = new TTVisual.TTTextBoxColumn();
        this.ReceiptNumber.DataMember = "ReceiptNumber";
        this.ReceiptNumber.DisplayIndex = 7;
        this.ReceiptNumber.HeaderText = "Ayniyat Makbuz No";
        this.ReceiptNumber.Name = "ReceiptNumber";
        this.ReceiptNumber.ReadOnly = true;
        this.ReceiptNumber.Width = 120;

        this.AmountChattelDocumentDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.AmountChattelDocumentDetailWithAccountancy.DataMember = "Amount";
        this.AmountChattelDocumentDetailWithAccountancy.Format = "N2";
        this.AmountChattelDocumentDetailWithAccountancy.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountChattelDocumentDetailWithAccountancy.DisplayIndex = 5;
        this.AmountChattelDocumentDetailWithAccountancy.HeaderText = i18n("M19030", "Miktar");
        this.AmountChattelDocumentDetailWithAccountancy.Name = "AmountChattelDocumentDetailWithAccountancy";
        this.AmountChattelDocumentDetailWithAccountancy.Width = 120;
        this.AmountChattelDocumentDetailWithAccountancy.IsNumeric = true;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 113;

        this.DescriptionsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DescriptionsDocumentRecordLog.DataMember = "Descriptions";
        this.DescriptionsDocumentRecordLog.DisplayIndex = 8;
        this.DescriptionsDocumentRecordLog.HeaderText = i18n("M10483", "Açıklamalar");
        this.DescriptionsDocumentRecordLog.Name = "DescriptionsDocumentRecordLog";
        this.DescriptionsDocumentRecordLog.Width = 200;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = "UnitPrice";
        this.UnitPrice.Format = "#,###.#########";
        this.UnitPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPrice.DisplayIndex = 6;
        this.UnitPrice.HeaderText = i18n("M11868", "Birim Maliyet Bedeli");
        this.UnitPrice.Name = "UnitPrice";
        this.UnitPrice.ReadOnly = true;
        this.UnitPrice.Visible = false;
        this.UnitPrice.Width = 120;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.SendToMKYS = new TTVisual.TTButton();
        this.SendToMKYS.Text = "MKYS'ye Gönder";
        this.SendToMKYS.Name = "SendToMKYS";
        this.SendToMKYS.TabIndex = 133;

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DataMember = "Price";
        this.Price.Format = "#,###.#########";
        this.Price.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Price.DisplayIndex = 7;
        this.Price.HeaderText = i18n("M23613", "Tutarı");
        this.Price.Name = "Price";
        this.Price.ReadOnly = true;
        this.Price.Visible = false;
        this.Price.Width = 120;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.cmdSendAgain = new TTVisual.TTButton();
        this.cmdSendAgain.Text = i18n("M23124", "Tekrar Gönder");
        this.cmdSendAgain.Name = "cmdSendAgain";
        this.cmdSendAgain.TabIndex = 122;
        this.cmdSendAgain.Visible = false;

        this.StockLevelTypeChattelDocumentDetailWithAccountancy = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.DataMember = "StockLevelType";
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.DisplayIndex = 8;
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.Name = "StockLevelTypeChattelDocumentDetailWithAccountancy";
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.Width = 120;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;

        this.StatusChattelDocumentDetailWithAccountancy = new TTVisual.TTEnumComboBoxColumn();
        this.StatusChattelDocumentDetailWithAccountancy.DataTypeName = "StockActionDetailStatusEnum";
        this.StatusChattelDocumentDetailWithAccountancy.DataMember = "Status";
        this.StatusChattelDocumentDetailWithAccountancy.DisplayIndex = 9;
        this.StatusChattelDocumentDetailWithAccountancy.HeaderText = "Durum";
        this.StatusChattelDocumentDetailWithAccountancy.Name = "StatusChattelDocumentDetailWithAccountancy";
        this.StatusChattelDocumentDetailWithAccountancy.Visible = false;
        this.StatusChattelDocumentDetailWithAccountancy.Width = 80;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.labelAccountancy = new TTVisual.TTLabel();
        this.labelAccountancy.Text = i18n("M14873", "Gönderildiği Yer");
        this.labelAccountancy.Name = "labelAccountancy";
        this.labelAccountancy.TabIndex = 121;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;

        this.Accountancy = new TTVisual.TTObjectListBox();
        this.Accountancy.ListDefName = "AccountancyList";
        this.Accountancy.Name = "Accountancy";
        this.Accountancy.TabIndex = 5;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.MKYS_CikisStokHareketTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisStokHareketTuru.DataTypeName = "MKYS_ECikisStokHareketTurEnum";
        this.MKYS_CikisStokHareketTuru.Name = "MKYS_CikisStokHareketTuru";
        this.MKYS_CikisStokHareketTuru.TabIndex = 128;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 111;

        this.lblMKYS_CikisIslemTuru = new TTVisual.TTLabel();
        this.lblMKYS_CikisIslemTuru.Text = i18n("M12381", "Çıkış Türü");
        this.lblMKYS_CikisIslemTuru.Name = "lblMKYS_CikisIslemTuru";
        this.lblMKYS_CikisIslemTuru.TabIndex = 125;

        this.MKYS_CikisIslemTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisIslemTuru.DataTypeName = "MKYS_ECikisIslemTuruEnum";
        this.MKYS_CikisIslemTuru.BackColor = "#F0F0F0";
        this.MKYS_CikisIslemTuru.Enabled = false;
        this.MKYS_CikisIslemTuru.Name = "MKYS_CikisIslemTuru";
        this.MKYS_CikisIslemTuru.TabIndex = 124;

        this.lblMKYS_CikisStokHareketTuru = new TTVisual.TTLabel();
        this.lblMKYS_CikisStokHareketTuru.Text = i18n("M12372", "Çıkış Hareket Türü");
        this.lblMKYS_CikisStokHareketTuru.Name = "lblMKYS_CikisStokHareketTuru";
        this.lblMKYS_CikisStokHareketTuru.TabIndex = 129;

        this.ValueAddedTax = new TTVisual.TTTextBoxColumn();
        this.ValueAddedTax.DataMember = "VatRate";
        this.ValueAddedTax.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ValueAddedTax.DisplayIndex = 6;
        this.ValueAddedTax.HeaderText = i18n("M17457", "KDV Oranı");
        this.ValueAddedTax.Name = "ValueAddedTax";
        this.ValueAddedTax.ReadOnly = true;
        this.ValueAddedTax.Width = 100;


        this.IsContainsContributions = new TTVisual.TTCheckBox();
        this.IsContainsContributions.Value = false;
        this.IsContainsContributions.Title = "Katkı Payı İçerir";
        this.IsContainsContributions.Name = "IsContainsContributions";
        this.IsContainsContributions.TabIndex = 128;
        this.IsContainsContributions.ReadOnly = true;

        this.DocumentRecordLogDeleteMKYS = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogDeleteMKYS.Text = 'MKYS Kayıt Sil';
        this.DocumentRecordLogDeleteMKYS.Name = 'DeleteMkysRow';

        this.DocumentRecordLogsColumns = [this.DocumentRecordLogNumberDocumentRecordLog, this.DocumentDateTimeDocumentRecordLog, this.DocumentTransactionTypeDocumentRecordLog, this.BudgeTypeEnum, this.SubjectDocumentRecordLog, this.NumberOfRowsDocumentRecordLog, this.TakenGivenPlaceDocumentRecordLog, this.ReceiptNumber, this.DocumentRecordLogDeleteMKYS, this.DescriptionsDocumentRecordLog];
        //  this.ChattelDocumentDetailsWithAccountancyColumns = [this.Detail, this.MaterialChattelDocumentDetailWithAccountancy, this.Barcode, this.DistributionType, this.StoreStock, this.ValueAddedTax, this.AmountChattelDocumentDetailWithAccountancy, this.UnitPrice, this.Price, this.StockLevelTypeChattelDocumentDetailWithAccountancy, this.StatusChattelDocumentDetailWithAccountancy];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.DocumentRerocdLogTab.Controls = [this.DocumentRecordLogs];
        this.ChattelDocumentTabcontrol.Controls = [this.DocumentRerocdLogTab, this.ChattelDocumentTabpage];
        this.ChattelDocumentTabpage.Controls = [this.ChattelDocumentDetailsWithAccountancy];
        this.DescriptionAndSignTabControl.Controls = [this.DocumentRecordLogTabpage, this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.InvoiceNumberSec, this.DocumentRecordLogTabpage, this.Waybill, this.TTTeslimEdenButon, this.DocumentRerocdLogTab, this.labelWaybillDate, this.TTTeslimAlanButon, this.DocumentRecordLogs, this.WaybillDate, this.labelMKYS_TeslimEden, this.DocumentRecordLogNumberDocumentRecordLog, this.labelWaybill, this.MKYS_TeslimEden, this.DocumentDateTimeDocumentRecordLog, this.labeloutputStockMovementType, this.MKYS_TeslimAlan, this.DocumentTransactionTypeDocumentRecordLog, this.outputStockMovementType, this.Description, this.BudgeTypeEnum, this.labelStore, this.StockActionID, this.SubjectDocumentRecordLog, this.Store, this.labelMKYS_TeslimAlan, this.NumberOfRowsDocumentRecordLog, this.ChattelDocumentTabcontrol, this.labelTransactionDate, this.TakenGivenPlaceDocumentRecordLog, this.ChattelDocumentTabpage, this.TransactionDate, this.ReceiptNumber, this.ChattelDocumentDetailsWithAccountancy, this.labelStockActionID, this.DescriptionsDocumentRecordLog, this.Detail, this.DescriptionAndSignTabControl, this.SendToMKYS, this.MaterialChattelDocumentDetailWithAccountancy, this.SignTabpage, this.cmdSendAgain, this.Barcode, this.StockActionSignDetails, this.DistributionType, this.SignUserType, this.StoreStock, this.SignUser, this.AmountChattelDocumentDetailWithAccountancy, this.IsDeputy, this.UnitPrice, this.ttlabel1, this.Price, this.StockLevelTypeChattelDocumentDetailWithAccountancy, this.StatusChattelDocumentDetailWithAccountancy, this.labelAccountancy, this.Accountancy, this.MKYS_CikisStokHareketTuru, this.lblMKYS_CikisIslemTuru, this.MKYS_CikisIslemTuru, this.DocumentRecordLogDeleteMKYS, this.lblMKYS_CikisStokHareketTuru];


    }


}
