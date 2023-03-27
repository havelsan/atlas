//$3DA6E44C
import { Component, OnInit, NgZone } from '@angular/core';
import { ChattelDocumentWithPurchaseCompletedFormViewModel, UTSReceiveNotificationSendViewModel, UTSReceiveNotificationResultViewModel } from './ChattelDocumentWithPurchaseCompletedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseChattelDocumentWithPurchaseForm, PTSMaterial } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentWithPurchaseForm";
import { ChattelDocumentWithPurchase, Material, DistributionTypeDefinition, StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentDetailWithPurchase } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentDistribution } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { ChattelDocumentWithPurchaseService } from "ObjectClassService/ChattelDocumentWithPurchaseService";
import Exception from 'app/NebulaClient/System/Exception';
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { MkysServis } from 'NebulaClient/Services/External/MkysServis';
import { StockActionService, DocumentRecordLogReceiptNumber_Input, OutputForReGeneration, OutputForRePhysicianApplication, SendUTSUpdateTS_Input, CheckDocumentRecordLogForDelete_Output, DocumentRecordLogCheckComponent_Input } from 'ObjectClassService/StockActionService';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { IModalService } from "Fw/Services/IModalService";
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DocumentTransactionTypeEnum, StockActionDetailIn } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { UsernamePwdBox } from 'NebulaClient/Visual/UsernamePwdBox';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { forEach } from 'app/NebulaClient/System/Collections/Enumeration/Enumerator';
import { Headers, RequestOptions } from '@angular/http';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { rejects } from 'assert';
import { LogisticDocumentUploadFormInput } from 'app/Logistic/Views/LogiscticDocumentComponents/LogisticPatientDocumentUploadForm';

@Component({
    selector: 'ChattelDocumentWithPurchaseCompletedForm',
    templateUrl: './ChattelDocumentWithPurchaseCompletedForm.html',
    providers: [MessageService]
})

export class ChattelDocumentWithPurchaseCompletedForm extends BaseChattelDocumentWithPurchaseForm implements OnInit {
    BudgeTypeEnum: TTVisual.ITTEnumComboBoxColumn;
    DescriptionsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentDateTimeDocumentRecordLog: TTVisual.ITTDateTimePickerColumn;
    DocumentRecordLogNumberDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogs: TTVisual.ITTGrid;
    DocumentRecordLogTab: TTVisual.ITTTabPage;
    DocumentTransactionTypeDocumentRecordLog: TTVisual.ITTEnumComboBoxColumn;
    NumberOfRowsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    ReceiptNumber: TTVisual.ITTTextBoxColumn;
    SendToMKYS: TTVisual.ITTButton;
    SubjectDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    TakenGivenPlaceDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    txtBarkod: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogSearch: TTVisual.ITTButtonColumn;
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;

    txtUTSLot: TTVisual.ITTTextBoxColumn;
    txtUTSAlma: TTVisual.ITTTextBoxColumn;
    txtUTSVerme: TTVisual.ITTTextBoxColumn;

    public ChattelDocumentDetailsWithPurchaseColumns = [];
    public DemandAmountsGridColumns = [];
    public DocumentRecordLogsColumns = [];
    public StockActionSignDetailsColumns = [];
    public showUTSButton = false;
    public showPCButton = false;
    public chattelDocumentWithPurchaseCompletedFormViewModel: ChattelDocumentWithPurchaseCompletedFormViewModel = new ChattelDocumentWithPurchaseCompletedFormViewModel();

    public get _ChattelDocumentWithPurchase(): ChattelDocumentWithPurchase {
        return this._TTObject as ChattelDocumentWithPurchase;
    }

    private ChattelDocumentWithPurchaseCompletedForm_DocumentUrl: string = '/api/ChattelDocumentWithPurchaseService/ChattelDocumentWithPurchaseCompletedForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone, protected objectContextService: ObjectContextService) {
        super(httpService, messageService, ngZone, objectContextService);
        this._DocumentServiceUrl = this.ChattelDocumentWithPurchaseCompletedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public mkysSonucMesaj: string;
    public XXXXXXSonucMesaj: string;
    popupVisible: boolean = false;
    reGenerateButtonVisible: boolean = true;
    hasAuctionDateChanged: boolean = false;
    hasRegistrationAuctionNumberChanged: boolean = false;

    public showLoadPanel: boolean = false;
    public LoadPanelMessage: string = "MKYS İşlemi yapılıyor Lütfen Bekleyiniz...";

    public async SendToMKYS_Click(): Promise<void> {
        //-TODO İlaydax
        this.mkysSonucMesaj = '';
        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result == DialogResult.OK) {
            this.showLoadPanel = true;
            let params = <any>(<ModalActionResult>result).Param;
            if (this._ChattelDocumentWithPurchase.CurrentStateDefID.toString() === ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.Completed.id) {
                for (let log of this._ChattelDocumentWithPurchase.DocumentRecordLogs) {
                    if (log.ReceiptNumber == null) {
                        this._ChattelDocumentWithPurchase.MKYS_MuayeneNo = this._ChattelDocumentWithPurchase.ExaminationReportNo;
                        this._ChattelDocumentWithPurchase.MKYS_MuayeneTarihi = this._ChattelDocumentWithPurchase.ExaminationReportDate;
                        this.mkysSonucMesaj = await StockActionService.SendMKYSForInputDocumentTS(this._ChattelDocumentWithPurchase, params.password);
                    }
                    if (log.ReceiptNumber != null) {
                        this.mkysSonucMesaj += log.ReceiptNumber.toString() + " Ayniyat numarası ile MKYSye kaydolmuştur.";
                    }


                    if (this._ChattelDocumentWithPurchase.FreeEntry != null || this._ChattelDocumentWithPurchase.FreeEntry != undefined) {
                        if (this._ChattelDocumentWithPurchase.FreeEntry == false) {
                            if (log.ReceiptNumber != null && !this._ChattelDocumentWithPurchase.XXXXXXIslemBasarili) {
                                this.XXXXXXSonucMesaj += await ChattelDocumentWithPurchaseService.SendMuayeneKabulCevapToXXXXXXTS(this._ChattelDocumentWithPurchase);
                            }
                        }
                    }
                }

                if (String.isNullOrEmpty(this.mkysSonucMesaj) == false)
                    this.popupVisible = true;
            }
            //-TODO İlaydax
            if (this._ChattelDocumentWithPurchase.CurrentStateDefID.toString() === ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.Cancelled.id) {
                for (let log of this._ChattelDocumentWithPurchase.DocumentRecordLogs) {
                    if (log.ReceiptNumber != null) {
                        this.mkysSonucMesaj = await StockActionService.SendDeleteMessageToMkysTS(this._ChattelDocumentWithPurchase, false, log.ReceiptNumber.Value, params.password);
                    }
                    if (String.isNullOrEmpty(this.mkysSonucMesaj) == false)
                        this.popupVisible = true;

                }
            }
            this.showLoadPanel = false;
        }
    }


    public async prepareDocument_Click(): Promise<void> {
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ChattelDocumentWithPurchase.ObjectID.toString());
        for (let document of documentRecordLogs) {
            if (this._ChattelDocumentWithPurchase.IsPTSAction == false) {
                if (document.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                    const objectIdParam = new GuidParam(document['ObjectID']);
                    const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                    let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                    this.reportService.showReport('ChattelDocumentInDetailReport', reportParameters);
                    this.reportService.showReport('ExaminationChattelDocumentInDetailReport', reportParameters);
                }
                if (document.DocumentTransactionType === DocumentTransactionTypeEnum.Out) {
                    const objectIdParam = new GuidParam(document['ObjectID']);
                    const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                    let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                    this.reportService.showReport('ChattelDocumentOutDetailReport', reportParameters);
                }
            }
            else {
                if (document.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                    const objectIdParam = new GuidParam(document['ObjectID']);
                    const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                    let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                    this.reportService.showReport('ChattelDocumentInDetailReportPTS', reportParameters);
                    this.reportService.showReport('ExaminationChattelDocumentInDetailReportPTS', reportParameters);
                }
            }
        }
    }

    public async reGenerateAction_Click(): Promise<void> {
        if (this._ChattelDocumentWithPurchase.IsPTSAction != true) {
            let result: OutputForReGeneration = null;
            try {
                result = await StockActionService.ReGenerateMyChattelDocumentWithPurchase(this._ChattelDocumentWithPurchase.ObjectID.toString());
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
        } else {
            ServiceLocator.MessageService.showError("PTS girişi tekrar oluşturulamaz.");
        }
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef) {
        super.AfterContextSavedScript(transDef);
    }

    receiptNumberError: string = "";
    controlOfCancelMKYS: boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        for (let log of this._ChattelDocumentWithPurchase.DocumentRecordLogs) {
            if (log.ReceiptNumber != null) {
                this.receiptNumberError = this.receiptNumberError + "." + log.ReceiptNumber.toString();
                this.controlOfCancelMKYS = false;
            }
        }

        if (this.controlOfCancelMKYS) {
            await super.ClientSidePostScript(transDef);
            if (this._ChattelDocumentWithPurchase.CurrentStateDefID.toString() == ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.Completed.id.toString()) {
                if (this.hasAuctionDateChanged || this.hasRegistrationAuctionNumberChanged) {
                    let hasSentToMKYS: boolean = true;

                    for (let log of this._ChattelDocumentWithPurchase.DocumentRecordLogs) {
                        if (log.ReceiptNumber == null) {
                            hasSentToMKYS = false;
                        }
                    }
                    if (hasSentToMKYS) {
                        await this.SendIhaleTarihiVeNumarasiUpdate();
                    }
                }
            }
        }
        else {
            throw new Exception("MKYS'den silinmeyen fiş iptal edilemez. Lütfen önce fişi siliniz!" + this.receiptNumberError + " Ayniyatlı Kayıtları Siliniz.!");
            this.receiptNumberError = "";
        }
    }

    protected async SendIhaleTarihiVeNumarasiUpdate(): Promise<void> {
        try {
            this.mkysSonucMesaj = '';
            let result = await UsernamePwdBox.Show(true);
            if ((<ModalActionResult>result).Result == DialogResult.OK) {
                let params = <any>(<ModalActionResult>result).Param;
                await StockActionService.SendIhaleTarihiVeNumarasiUpdateTS(this._ChattelDocumentWithPurchase, params.password).then(response => { let result = <string>response; ServiceLocator.MessageService.showInfo(result); }).catch(error => { throw error; });
            }
        }
        catch (ex) {
            //ServiceLocator.MessageService.showError(ex.toString());
            throw ex;
        }
    }


    protected async ClientSidePreScript() {
        if (this._ChattelDocumentWithPurchase.CurrentStateDefID.toString() == ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.Completed.id.toString()) {
            this.reGenerateButtonVisible = false;
            this.AuctionDate.ReadOnly = false;
            this.RegistrationAuctionNo.ReadOnly = false;

        }
        super.ClientSidePreScript();
    }

    protected async PreScript() {
        super.PreScript();
        let priceCalc: Array<number> = new Array<number>();
        let totalWithoutKDV: number = 0, totalWithKDV = 0, salesTotal = 0, totalPrice = 0;
        priceCalc.push(totalWithoutKDV);
        priceCalc.push(totalWithKDV);
        priceCalc.push(salesTotal);
        priceCalc.push(totalPrice);
        priceCalc = await this.CalcFinalPriceWithKDV(priceCalc);
        this.txtNotKDV.Text = priceCalc[0].toFixed(2);
        this.txtWithKDV.Text = priceCalc[1].toFixed(2);
        this.txtDiscount.Text = priceCalc[2].toFixed(2);
        //this.txtTotalPrice.Text = priceCalc[3].toFixed(2);
        this.SendToMKYS.ReadOnly = false;
        if (this._ChattelDocumentWithPurchase.CurrentStateDefID.toString() == ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.Completed.id.toString()) {
            for (let detailItem of this.chattelDocumentWithPurchaseCompletedFormViewModel.ChattelDocumentDetailsWithPurchaseGridList) {
                if (detailItem.Material.IsIndividualTrackingRequired && (detailItem.ReceiveNotificationID == null || detailItem.ReceiveNotificationID == "")) {
                    this.showUTSButton = true;
                    break;
                }
            }
        }


        if (this._ChattelDocumentWithPurchase.InPatientPhysicianApplication != null) {
            this.showPCButton = true;
        }
    }

    DocumentRecordLogs_CellValueChangedEmitted(data: any) { }
    initDocumentRecordLogsNewRow(data: any) { }
    onDocumentRecordLogsRowInserting(data: any) { }
    onSelectionChangeDocumentRecordLogs(data: any) { }
    onSelectionChange(data: any) { }
    onRowInserting(data: any) { }
    initNewRow(data: any) { }
    onCellContentClicked(data: any) { }

    // *****Method declarations end *****


    public ChattelMaterialGridColumns = [
        {
            caption: ' ',
            dataField: 'ObjectID',
            cellTemplate: 'buttonCellTemplate',
            visible: true,
            allowEditing: false,
            width: 50
        },
        {
            caption: i18n("M18550", "Malzeme Adı"),
            dataField: 'Material.Name',
            allowEditing: false,
            width: 300
        },
        {
            caption: 'Taşınır Kodu',
            dataField: 'Material.StockCard.NATOStockNO',
            allowEditing: false,
            width: 120
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false,
            width: 120
        },
        {
            caption: i18n("M19908", "Ölçü Birimi"),
            dataField: 'Material.DistributionTypeName',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: i18n("M19030", "Miktar"),
            dataField: 'Amount',
            dataType: 'number',
            // format: "#",
            // editorOptions: {
            //     onKeyPress: function (e) {
            //         var event = e.event,
            //             str = String.fromCharCode(event.keyCode);
            //         if (!/[0-9]/.test(str))
            //             event.preventDefault();
            //     }
            // },
            width: 120
        },
        {
            caption: i18n("M17464", "KDV\'siz Fiyatı"),
            dataField: 'UnitPriceWithOutVat',
            dataType: 'number',
            // editorOptions: {
            //     format: function (value) {
            //         return Math.Round(value, 6) + ' TL';
            //     }
            //     //format: "#,##0.## TL",
            // },
            width: 'auto'
        },
        {
            caption: i18n("M17457", "KDV Oranı"),
            dataField: 'VatRate',
            dataType: 'number',
            // editorOptions: {
            //     format: function (value) {
            //         return Math.Round(value, 5) + ' %';
            //     }
            //     //format: "#,##0.## TL",
            // },
            width: 100
        },
        {
            caption: i18n("M17462", "KDV\'li Fiyatı"),
            dataField: 'UnitPriceWithInVat',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: i18n("M16491", "İndirim Oranı"),
            dataField: 'DiscountRate',
            dataType: 'number',
            width: 'auto'
        },
        {
            caption: i18n("M16504", "İndirimli Birim Fiyat"),
            dataField: 'UnitPrice',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: i18n("M16006", "Indirim Tutarı"),
            dataField: 'DiscountAmount',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: i18n("M23526", "Toplam Tutar"),
            dataField: 'Price',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'Lot No.',
            dataField: 'LotNo',
            width: 85
        },
        {
            caption: 'ÜTS Alma Bildirim ID',
            dataField: 'ReceiveNotificationID',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'Seri No.',
            dataField: 'SerialNo',
            width: 85
        },
        {
            caption: i18n("M22057", "Son Kullanma Tarihi"),
            dataField: 'ExpirationDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width: 150
        },
        // {
        //     caption: i18n("M18519", "Malın Durumu"),
        //     dataField: 'StockLevelType.Description',
        //     allowEditing: false,
        //     width: 'auto'
        // },
        {
            caption: i18n("M13475", "Edinim Yılı"),
            dataField: 'RetrievalYear',
            dataType: 'number',
            width: 85
        },
        {
            caption: i18n("M23966", "Üretim Tarihi"),
            dataField: 'ProductionDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width: 150
        },
    ];




    public initViewModel(): void {
        this._TTObject = new ChattelDocumentWithPurchase();
        this.chattelDocumentWithPurchaseCompletedFormViewModel = new ChattelDocumentWithPurchaseCompletedFormViewModel();
        this._ViewModel = this.chattelDocumentWithPurchaseCompletedFormViewModel;
        this.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase = this._TTObject as ChattelDocumentWithPurchase;
        this.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase.DocumentRecordLogs = new Array<DocumentRecordLog>();
        this.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase.Store = new Store();
        this.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase.Supplier = new Supplier();
        this.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase = new Array<ChattelDocumentDetailWithPurchase>();
        this.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDistributions = new Array<ChattelDocumentDistribution>();
        this.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.chattelDocumentWithPurchaseCompletedFormViewModel = this._ViewModel as ChattelDocumentWithPurchaseCompletedFormViewModel;
        that._TTObject = this.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase;
        if (this.chattelDocumentWithPurchaseCompletedFormViewModel == null)
            this.chattelDocumentWithPurchaseCompletedFormViewModel = new ChattelDocumentWithPurchaseCompletedFormViewModel();
        if (this.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase == null)
            this.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase = new ChattelDocumentWithPurchase();
        that.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase.DocumentRecordLogs = that.chattelDocumentWithPurchaseCompletedFormViewModel.DocumentRecordLogsGridList;
        for (let detailItem of that.chattelDocumentWithPurchaseCompletedFormViewModel.DocumentRecordLogsGridList) {
        }
        let budgetTypeDefinitionObjectID = that.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase["BudgetTypeDefinition"];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === 'string')) {
            let budgetTypeDefinition = that.chattelDocumentWithPurchaseCompletedFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.chattelDocumentWithPurchaseCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase.Store = store;
            }
        }
        let supplierObjectID = that.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase["Supplier"];
        if (supplierObjectID != null && (typeof supplierObjectID === 'string')) {
            let supplier = that.chattelDocumentWithPurchaseCompletedFormViewModel.Suppliers.find(o => o.ObjectID.toString() === supplierObjectID.toString());
            if (supplier) {
                that.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase.Supplier = supplier;
            }
        }
        if (that.chattelDocumentWithPurchaseCompletedFormViewModel.ChattelDocumentDetailsWithPurchaseGridList != null) {
            that.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase = that.chattelDocumentWithPurchaseCompletedFormViewModel.ChattelDocumentDetailsWithPurchaseGridList;
            for (let detailItem of that.chattelDocumentWithPurchaseCompletedFormViewModel.ChattelDocumentDetailsWithPurchaseGridList) {
                let materialObjectID = detailItem["Material"];
                if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                    let material = that.chattelDocumentWithPurchaseCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                    if (material) {
                        detailItem.Material = material;
                    }
                    if (material != null) {
                        let stockCardObjectID = material["StockCard"];
                        if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                            let stockCard = that.chattelDocumentWithPurchaseCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                            if (stockCard) {
                                material.StockCard = stockCard;
                            }
                            if (stockCard != null) {
                                let distributionTypeObjectID = stockCard["DistributionType"];
                                if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                    let distributionType = that.chattelDocumentWithPurchaseCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                    if (distributionType) {
                                        stockCard.DistributionType = distributionType;
                                    }
                                }
                            }
                        }
                    }
                }
                let stockLevelTypeObjectID = detailItem["StockLevelType"];
                if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                    let stockLevelType = that.chattelDocumentWithPurchaseCompletedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                    if (stockLevelType) {
                        detailItem.StockLevelType = stockLevelType;
                    }
                }
            }
        } else {
            that.chattelDocumentWithPurchaseCompletedFormViewModel.ChattelDocumentDetailsWithPurchaseGridList = new Array<ChattelDocumentDetailWithPurchase>();
        }
        that.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDistributions = that.chattelDocumentWithPurchaseCompletedFormViewModel.DemandAmountsGridGridList;
        for (let detailItem of that.chattelDocumentWithPurchaseCompletedFormViewModel.DemandAmountsGridGridList) {
            let demandDetailObjectID = detailItem["DemandDetail"];
            if (demandDetailObjectID != null && (typeof demandDetailObjectID === 'string')) {
                let demandDetail = that.chattelDocumentWithPurchaseCompletedFormViewModel.DemandDetails.find(o => o.ObjectID.toString() === demandDetailObjectID.toString());
                if (demandDetail) {
                    detailItem.DemandDetail = demandDetail;
                }
                if (demandDetail != null) {
                    let demandObjectID = demandDetail["Demand"];
                    if (demandObjectID != null && (typeof demandObjectID === 'string')) {
                        let demand = that.chattelDocumentWithPurchaseCompletedFormViewModel.Demands.find(o => o.ObjectID.toString() === demandObjectID.toString());
                        if (demand) {
                            demandDetail.Demand = demand;
                        }
                        if (demand != null) {
                            let masterResourceObjectID = demand["MasterResource"];
                            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                                let masterResource = that.chattelDocumentWithPurchaseCompletedFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                                if (masterResource) {
                                    demand.MasterResource = masterResource;
                                }
                            }
                        }
                    }
                }
            }
        }
        that.chattelDocumentWithPurchaseCompletedFormViewModel._ChattelDocumentWithPurchase.StockActionSignDetails = that.chattelDocumentWithPurchaseCompletedFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.chattelDocumentWithPurchaseCompletedFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.chattelDocumentWithPurchaseCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }

    }
    ItsPackageNo: string = "";
    titleGrid: string = "Taşınır Malın";
    incomingITSReceiptNotificationList = new Array<PTSMaterial>();
    ShowITSReceiveNotifications: boolean = false;
    
    async ngOnInit() {
        let that = this;
        await that.load(ChattelDocumentWithPurchaseCompletedFormViewModel);
        that.MKYS_TeslimAlan.ButtonEnabled = false;
        that.MKYS_TeslimEden.ButtonEnabled = false;
        that.DocumentRecordLogSearch.ReadOnly = false;
        that.DocumentRecordLogDeleteMKYS.ReadOnly = false;
        if (that._ChattelDocumentWithPurchase.MKYS_TeslimAlanObjID != null) {
            that.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            that.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (that._ChattelDocumentWithPurchase.MKYS_TeslimEdenObjID != null) {
            that.MKYS_TeslimEden.BackColor = "#F0F0F0";
            that.MKYS_TeslimEden.ReadOnly = true;
        }
        if (that._ChattelDocumentWithPurchase.CurrentStateDefID.toString() == ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.Completed.id.toString()) {
            that.FormCaption = i18n("M21379", "Satınalma Yoluyla Giriş ( Tamamlandı )");
        }
        if (that._ChattelDocumentWithPurchase.CurrentStateDefID.toString() == ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.Cancelled.id.toString()) {
            that.FormCaption = i18n("M21377", "Satınalma Yoluyla Giriş ( İptal Edildi )");
        }

        that.incomingITSReceiptNotificationList = new Array<PTSMaterial>();
        that.incomingITSReceiptNotificationList = that.chattelDocumentWithPurchaseCompletedFormViewModel.PTSMaterials;
        if (that.incomingITSReceiptNotificationList) {
            if (that.incomingITSReceiptNotificationList.length > 0)
                that.CalculateFormTotalPriceForITS();
        }
        if (that._ChattelDocumentWithPurchase.IsPTSAction === true) {
            that.ShowITSReceiveNotifications = true;
            that.titleGrid = "PTS Giriş";
            if (String.isNullOrEmpty(that._ChattelDocumentWithPurchase.PTSNumber))
                this.ItsPackageNo = "PTS XML Girişi";
            else
                that._ChattelDocumentWithPurchase.PTSNumber = this.ItsPackageNo;

            /*for (let item of that.chattelDocumentWithPurchaseCompletedFormViewModel.PTSStockActionDetails) {

                let ptsMAterialExist: PTSMaterial = that.incomingITSReceiptNotificationList.find(x => x.lotNO == item.LotNo && x.barcode == item.Material.Barcode && x.expirationDate.toString() === item.ExpirationDate.toString())
                if (ptsMAterialExist != null) {
                    ptsMAterialExist.amount = ptsMAterialExist.amount + item.Amount;
                    ptsMAterialExist.DiscountAmount = Math.Round(ptsMAterialExist.DiscountAmount + item.DiscountAmount, 6);
                    ptsMAterialExist.UnitPrice = Math.Round(ptsMAterialExist.UnitPrice + item.UnitPrice, 6);
                    //ptsMAterialExist.price = Math.Round(ptsMAterialExist.price + item.Price, 6);
                }
                else {
                    let pTSMaterial: PTSMaterial = new PTSMaterial();
                    pTSMaterial.amount = item.Amount;
                   let material: Material ; 
                    if (item.Material != null) {
                        material = that.chattelDocumentWithPurchaseCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === item.Material.toString());
                        let stockCardObjectID = material["StockCard"];
                        if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                            let stockCard = that.chattelDocumentWithPurchaseCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                            if (stockCard) {
                                material.StockCard = stockCard;
                            }
                            if (stockCard != null) {
                                let distributionTypeObjectID = stockCard["DistributionType"];
                                if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                    let distributionType = that.chattelDocumentWithPurchaseCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                    if (distributionType) {
                                        stockCard.DistributionType = distributionType;
                                    }
                                }
                            }
                        }
                    }
                    pTSMaterial.materialName = material.Name;
                    pTSMaterial.NatoStockNo = material.StockCard.NATOStockNO;
                    pTSMaterial.DiscountAmount = item.DiscountAmount;
                    pTSMaterial.DiscountRate = item.DiscountRate;
                    pTSMaterial.expirationDate = item.ExpirationDate;
                    pTSMaterial.material = material;
                    pTSMaterial.barcode = material.Barcode;
                    pTSMaterial.material.StockCard = material.StockCard;
                    pTSMaterial.material.StockCard.DistributionType = material.StockCard.DistributionType;
                    pTSMaterial.DistributionTypeName = material.StockCard.DistributionType.DistributionType;
                    //pTSMaterial.UnitPriceWithInVat = item.UnitPriceWithInVat;
                    //pTSMaterial.UnitPriceWithOutVat = item.UnitPriceWithOutVat;
                    pTSMaterial.VatRate = item.VatRate;
                    pTSMaterial.DiscountAmount = item.DiscountAmount;
                    pTSMaterial.lotNO = item.LotNo;
                    pTSMaterial.RetrievalYear = item.RetrievalYear;
                    pTSMaterial.ProductionDate = item.ProductionDate;
                    //pTSMaterial.price = item.Price;
                    pTSMaterial.UnitPrice = item.UnitPrice;
                    that.incomingITSReceiptNotificationList.push(pTSMaterial);
                }
            }*/
        }
    }

    public CalculateFormTotalPriceForITS() {
        let prices: Array<number> = new Array<number>();
        let total: number = 0, salesTotal = 0, totalPrice = 0;
        prices.push(total);
        prices.push(salesTotal);
        prices.push(totalPrice);
        for (let data of this.chattelDocumentWithPurchaseCompletedFormViewModel.PTSMaterials) {
            if (data.UnitPriceWithOutVat == null || data.VatRate == null)
                continue;
            prices[0] += data.amount * data.UnitPriceWithOutVat;
            prices[1] += data.amount * (data.UnitPriceWithOutVat + (data.UnitPriceWithOutVat * data.VatRate / 100));
            prices[2] += data.DiscountAmount;
        }
        prices[3] = prices[1] - prices[2];

        this.txtNotKDV.Text = prices[0].toFixed(2);
        this.txtWithKDV.Text = prices[1].toFixed(2);
        this.txtDiscount.Text = prices[2].toFixed(2);
        this.txtTotalPrice.Text = prices[3].toFixed(2);
        //this.txtTotalNotDiscount.Text = prices[0].toFixed(2);
        //this.txtSalesTotal.Text = prices[1].toFixed(2);
        //this.txtTotalPrice.Text = prices[1].toFixed(2);
    }

    public async addLogisticPatientDocument() {
        if (this._ChattelDocumentWithPurchase.InPatientPhysicianApplication != null) {
            let objId: Guid;
            if (this._ChattelDocumentWithPurchase.InPatientPhysicianApplication.ObjectID != null)
                objId = this._ChattelDocumentWithPurchase.InPatientPhysicianApplication.ObjectID;
            else{
                let objIdstr: any = this._ChattelDocumentWithPurchase["InPatientPhysicianApplication"];
                objId = new Guid(objIdstr);
            }
            let input: LogisticDocumentUploadFormInput = await StockActionService.GetLogisticPatientDocumentInputDVO(objId);
            this.openLogisticPatientDocument(input);
        } else {
            ServiceLocator.MessageService.showError("Hasta seçilmemiş işlemler de döküman ekleyemezsiniz.")
        }
    }

    public openLogisticPatientDocument(input: LogisticDocumentUploadFormInput) {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'LogisticPatientDocumentUploadForm';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = input;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M15185", "Hasta Dosyasına Yükle");
            modalInfo.Width = 700;
            modalInfo.Height = 500;

            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    async onDocumentRecordLogsCellContentClicked(data: any) {
        if (data && this.onDocumentRecordLogsCellContentClicked && data.Row && data.Column) {
            let documentLog: DocumentRecordLog = <DocumentRecordLog>(data.Row.TTObject);
            if (documentLog.ReceiptNumber != null) {
                let input: DocumentRecordLogReceiptNumber_Input = new DocumentRecordLogReceiptNumber_Input();
                input.receiptNumber = documentLog.ReceiptNumber;
                if (data.Column.Name === 'GetLogFromMkys') {
                    let result = await UsernamePwdBox.Show(true);
                    if ((<ModalActionResult>result).Result == DialogResult.OK) {
                        let params = <any>(<ModalActionResult>result).Param;
                        input.password = params.password;
                        let getLogs: Array<MkysServis.stokHareketLogItem> = await StockActionService.GetMkysLogSearch(input);
                        this.showSelectMkysLog(getLogs);
                    }
                }
                if (data.Column.Name === 'DeleteMkysRow') {
                    let resultMessage: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '', documentLog.DocumentRecordLogNumber + " Tif numaralı fişi silmek istediğinizden emin misiniz?");
                    if (resultMessage === "OK") {
                        let result = await UsernamePwdBox.Show(true);
                        if ((<ModalActionResult>result).Result == DialogResult.OK) {
                            let params = <any>(<ModalActionResult>result).Param;
                            let check: Array<CheckDocumentRecordLogForDelete_Output> = await StockActionService.CheckDocumentRecordLogForDelete(documentLog.ObjectID);
                            if (check != null && check.length > 0) {
                                let inputParameter: DocumentRecordLogCheckComponent_Input = new DocumentRecordLogCheckComponent_Input();
                                inputParameter.DeleteDocumentRecordLog = check;
                                inputParameter.Password = params.password;
                                this.showDocumentRecordLogCheckComponent(inputParameter).then(result => {
                                    let modalActionResult = result as ModalActionResult;
                                    if (modalActionResult.Result === DialogResult.OK) {
                                        input.password = params.password;
                                        input.documentRecordLogObjectID = documentLog.ObjectID.toString()
                                        StockActionService.DeleteMkysSelectedRow(input).then(res => {
                                            if (res === true) {
                                                ServiceLocator.MessageService.showInfo("MKYS'den Silme yapılmıştır.");
                                                documentLog.ReceiptNumber = null;
                                            } else {
                                                ServiceLocator.MessageService.showError("Tekrar Deneyiniz Silme İşlemi Sırasında Hata Alındı.");
                                            }
                                        });

                                    } else {
                                        ServiceLocator.MessageService.showError("MKYS'den Silme işleminden vazgeçildi.");
                                    }
                                }).catch(err => rejects(err));
                            } else {
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
            }
            else {
                ServiceLocator.MessageService.showInfo("Ayniyat ID Boş olduğundan bu işlem yapılamaz!");
            }
        }
    }

    private showDocumentRecordLogCheckComponent(data: DocumentRecordLogCheckComponent_Input): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DocumentRecordLogCheckComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Kontrol Sonuç";
            modalInfo.Width = 600;
            modalInfo.Height = 400;

            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    private showSelectMkysLog(data: Array<MkysServis.stokHareketLogItem>): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "MkysLogComponent";
            componentInfo.ModuleName = "LogisticFormsModule";
            componentInfo.ModulePath = "/app/Logistic/LogisticFormsModule";
            componentInfo.InputParam = new DynamicComponentInputParam(data, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "MKYS Log Sorgu";
            modalInfo.Width = 1200;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    showBarkodUpdatePopup: boolean = false;
    showUTSUpdatePopup: boolean = false;
    activeInputDetail: StockActionDetailIn = null;

    async ShowBarkodUpdateModal(value: any): Promise<void> {
        this.txtBarkod.Text = "";
        if (value) {
            this.activeInputDetail = <StockActionDetailIn>value.data;
            if (this.activeInputDetail.MKYS_StokHareketID)
                this.showBarkodUpdatePopup = true;
            else {
                this.showBarkodUpdatePopup = false;
                this.activeInputDetail = null;
                TTVisual.InfoBox.Alert("İlgili satıra ait Stok Hareket ID bulunamadı. Barkod güncelleme yapılamaz.");
            }
        }
        else {
            this.showBarkodUpdatePopup = false;
            this.activeInputDetail = null;
            TTVisual.InfoBox.Alert("Barkodunu güncellemeye çalıştığınız işlem boş olamaz.");
        }
    }

    public stockactionDetainInObjID: string = "";
    async ShowUTSUpdateModal(value: any): Promise<void> {
        this.txtUTSLot.Text = "";
        this.txtUTSAlma.Text = "";
        this.txtUTSVerme.Text = "";

        if (value) {
            this.activeInputDetail = <StockActionDetailIn>value.data;
            this.stockactionDetainInObjID = this.activeInputDetail.ObjectID.toString();
            this.showUTSUpdatePopup = true;
            this.txtUTSLot.Text = this.activeInputDetail.LotNo;
            this.txtUTSAlma.Text = this.activeInputDetail.ReceiveNotificationID;
            this.txtUTSVerme.Text = this.activeInputDetail.IncomingDeliveryNotifID;
        }
        else {
            this.showUTSUpdatePopup = false;
            this.activeInputDetail = null;
            TTVisual.InfoBox.Alert("İlgili satıra ait güncelleme yapılamaz.");
        }
    }

    public async MakePatientConsumable_Click(): Promise<void> {
        let result: OutputForRePhysicianApplication = null;
        try {
            result = await StockActionService.ReInPatientPhysicianApplicationChattelDocumentWithPurchase(this._ChattelDocumentWithPurchase.ObjectID.toString());
            ServiceLocator.MessageService.showInfo(result.OutputMessage);
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex.toString());
        }
    }


    public async MakeUTSReceiveNotificationUnsaved_Click(): Promise<void> {


        var updateList: Array<UTSReceiveNotificationSendViewModel> = new Array<UTSReceiveNotificationSendViewModel>();
        var record: UTSReceiveNotificationSendViewModel;

        for (let detailItem of this.chattelDocumentWithPurchaseCompletedFormViewModel.ChattelDocumentDetailsWithPurchaseGridList) {
            if (detailItem.Material.IsIndividualTrackingRequired && (detailItem.ReceiveNotificationID == null || detailItem.ReceiveNotificationID == "")) {
                record = new UTSReceiveNotificationSendViewModel();
                record.ObjectId = detailItem.ObjectID.toString();
                record.Amount = detailItem.Amount;
                record.IncomingDeliveryNotifID = detailItem.IncomingDeliveryNotifID;
                updateList.push(record);

            }
        }

        try {
            let apiUrl = '/api/UTSIslemleriService/MakeUTSReceiveNotificationForAll';

            await this.httpService.post<any>(apiUrl, updateList).then(response => {
                let result: Array<UTSReceiveNotificationResultViewModel> = response;
                if (result != null) {
                    for (var item of result) {
                        if (item.ReceiveNotificationID != null) {
                            this.chattelDocumentWithPurchaseCompletedFormViewModel.ChattelDocumentDetailsWithPurchaseGridList.find(x => x.ObjectID.toString() == item.ObjectId).ReceiveNotificationID = item.ReceiveNotificationID;
                        }
                        else {
                            ServiceLocator.MessageService.showError("Hata : " + item.Message);
                        }
                    }

                    this.showUTSButton = false;
                    if (this._ChattelDocumentWithPurchase.CurrentStateDefID.toString() == ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.Completed.id.toString()) {
                        for (let detailItem of this.chattelDocumentWithPurchaseCompletedFormViewModel.ChattelDocumentDetailsWithPurchaseGridList) {
                            if (detailItem.Material.IsIndividualTrackingRequired && (detailItem.ReceiveNotificationID == null || detailItem.ReceiveNotificationID == "")) {
                                this.showUTSButton = true;
                                break;
                            }
                        }
                    }
                    if (this.showUTSButton == false) {
                        ServiceLocator.MessageService.showSuccess("İşlem Gerçekleştirildi.");
                    }

                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }


    async CancelBarkodUpdate() {
        this.showBarkodUpdatePopup = false;
        this.activeInputDetail = null;
        TTVisual.InfoBox.Alert("İşlemden vazgeçildi.");
    }

    async CancelUTSUpdate() {
        this.showUTSUpdatePopup = false;
        this.activeInputDetail = null;
        TTVisual.InfoBox.Alert("İşlemden vazgeçildi.");
    }


    async SaveUTSUpdate() {
        if (String.isNullOrEmpty(this.txtUTSLot.Text) == false && String.isNullOrEmpty(this.txtUTSVerme.Text) == false) {
            try {
                let input: SendUTSUpdateTS_Input = new SendUTSUpdateTS_Input();
                input.StockActionDetailInObjID = this.stockactionDetainInObjID;
                input.newLot = this.txtUTSLot.Text;
                input.newUTSAlma = this.txtUTSAlma.Text;
                input.newUTSVerme = this.txtUTSVerme.Text;
                await StockActionService.SendUTSUpdateTS(input).then(response => {
                    let result = <boolean>response;
                    if (result) {
                        ServiceLocator.MessageService.showInfo("İşlem Başarılı");
                        this.showUTSUpdatePopup = false;
                        this.activeInputDetail.LotNo = input.newLot;
                        this.activeInputDetail.ReceiveNotificationID = input.newUTSAlma;
                        this.activeInputDetail.IncomingDeliveryNotifID = input.newUTSVerme;
                    }
                    else {
                        ServiceLocator.MessageService.showError("İşlem Başarısız");
                    }
                }).catch(error => { throw error; });
            }
            catch (ex) {
                this.showUTSUpdatePopup = false;
                this.activeInputDetail = null;
                throw ex;
            }
        } else {
            this.activeInputDetail = null;
            TTVisual.InfoBox.Alert("Alanlar Boş bırakılamaz.");
        }
    }

    async SaveBarkodUpdate() {
        if (!String.isNullOrEmpty(this.txtBarkod.Text)) {
            try {
                this.mkysSonucMesaj = '';
                let result = await UsernamePwdBox.Show(true);
                if ((<ModalActionResult>result).Result == DialogResult.OK) {
                    let params = <any>(<ModalActionResult>result).Param;
                    await StockActionService.SendBarkodUpdateTS(this.activeInputDetail.MKYS_StokHareketID, this.txtBarkod.Text, params.password).then(response => {
                        let result = <string>response; ServiceLocator.MessageService.showInfo(result); this.showBarkodUpdatePopup = false;
                        this.activeInputDetail = null;
                    }).catch(error => { throw error; });
                }
            }
            catch (ex) {
                this.showBarkodUpdatePopup = false;
                this.activeInputDetail = null;
                throw ex;
            }
        } else {
            this.showBarkodUpdatePopup = false;
            this.activeInputDetail = null;
            TTVisual.InfoBox.Alert("Barkod boş olamaz.");

        }
    }

    

    public async SendToITS_Click() {
        this.showLoadPanel = true;
        StockActionService.ITSSendReceiptNotification(this._ChattelDocumentWithPurchase).then(res => {
            if (String.isNullOrEmpty(res) === false) {
                TTVisual.InfoBox.Alert("Alma bildirimi ITS sistemine bildirilmiştir.");
            } else {
                TTVisual.InfoBox.Alert(res);
            }
            this.showLoadPanel = false;
        }).catch(error => {
            this.showLoadPanel = false;
            TTVisual.InfoBox.Alert(error);
        });
    }

    public onAdditionalDocumentCountChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.AdditionalDocumentCount != event) {
                this._ChattelDocumentWithPurchase.AdditionalDocumentCount = event;
            }
        }
    }

    public onAuctionDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.AuctionDate != event) {
                this._ChattelDocumentWithPurchase.AuctionDate = event;
                this.hasAuctionDateChanged = true;
            }
            else
                this.hasAuctionDateChanged = false;
        }
    }

    public onBudgetTypeDefinitionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.BudgetTypeDefinition != event) {
                this._ChattelDocumentWithPurchase.BudgetTypeDefinition = event;
            }
        }
    }

    public onConclusionDateTimeChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ConclusionDateTime != event) {
                this._ChattelDocumentWithPurchase.ConclusionDateTime = event;
            }
        }
    }

    public onConclusionNumberChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ConclusionNumber != event) {
                this._ChattelDocumentWithPurchase.ConclusionNumber = event;
            }
        }
    }

    public onContractDateTimeChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ContractDateTime != event) {
                this._ChattelDocumentWithPurchase.ContractDateTime = event;
            }
        }
    }

    public onContractNumberChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ContractNumber != event) {
                this._ChattelDocumentWithPurchase.ContractNumber = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Description != event) {
                this._ChattelDocumentWithPurchase.Description = event;
            }
        }
    }

    public onExaminationReportDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ExaminationReportDate != event) {
                this._ChattelDocumentWithPurchase.ExaminationReportDate = event;
            }
        }
    }

    public onExaminationReportNoChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ExaminationReportNo != event) {
                this._ChattelDocumentWithPurchase.ExaminationReportNo = event;
            }
        }
    }

    public onMKYS_AyniyatMakbuzIDChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_AyniyatMakbuzID != event) {
                this._ChattelDocumentWithPurchase.MKYS_AyniyatMakbuzID = event;
            }
        }
    }

    public onMKYS_EAlimYontemiChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_EAlimYontemi != event) {
                this._ChattelDocumentWithPurchase.MKYS_EAlimYontemi = event;
            }
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup != event) {
                this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup = event;
            }
        }
    }

    public onMKYS_ETedarikTuruChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_ETedarikTuru != event) {
                this._ChattelDocumentWithPurchase.MKYS_ETedarikTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_TeslimAlan != event) {
                this._ChattelDocumentWithPurchase.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_TeslimEden != event) {
                this._ChattelDocumentWithPurchase.MKYS_TeslimEden = event;
            }
        }
    }

    public onRegistrationAuctionNoChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.RegistrationAuctionNo != event) {
                this._ChattelDocumentWithPurchase.RegistrationAuctionNo = event;
                this.hasRegistrationAuctionNumberChanged = true;
            }
            else
                this.hasRegistrationAuctionNumberChanged = false;
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.StockActionID != event) {
                this._ChattelDocumentWithPurchase.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Store != event) {
                this._ChattelDocumentWithPurchase.Store = event;
            }
        }
    }

    public onSupplierChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Supplier != event) {
                this._ChattelDocumentWithPurchase.Supplier = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.TransactionDate != event) {
                this._ChattelDocumentWithPurchase.TransactionDate = event;
            }
        }
    }

    public onWaybillChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Waybill != event) {
                this._ChattelDocumentWithPurchase.Waybill = event;
            }
        }
    }

    public onWaybillDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.WaybillDate != event) {
                this._ChattelDocumentWithPurchase.WaybillDate = event;
            }
        }
    }

    ChattelDocumentDetailsWithPurchase_CellValueChangedEmitted(data: any) {
        if (data && this.ChattelDocumentDetailsWithPurchase_CellValueChanged && data.Row && data.Column) {
            this.ChattelDocumentDetailsWithPurchase_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.ConclusionNumber, "Text", this.__ttObject, "ConclusionNumber");
        redirectProperty(this.ConclusionDateTime, "Value", this.__ttObject, "ConclusionDateTime");
        redirectProperty(this.RegistrationAuctionNo, "Text", this.__ttObject, "RegistrationAuctionNo");
        redirectProperty(this.AuctionDate, "Value", this.__ttObject, "AuctionDate");
        redirectProperty(this.ExaminationReportDate, "Value", this.__ttObject, "ExaminationReportDate");
        redirectProperty(this.ExaminationReportNo, "Text", this.__ttObject, "ExaminationReportNo");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.MKYS_EMalzemeGrup, "Value", this.__ttObject, "MKYS_EMalzemeGrup");
        redirectProperty(this.MKYS_ETedarikTuru, "Value", this.__ttObject, "MKYS_ETedarikTuru");
        redirectProperty(this.MKYS_EAlimYontemi, "Value", this.__ttObject, "MKYS_EAlimYontemi");
        redirectProperty(this.GetWaybill, "Text", this.__ttObject, "Waybill");
        redirectProperty(this.WaybillDate, "Value", this.__ttObject, "WaybillDate");
    }

    public initFormControls(): void {
        this.DocumentRecordLogTab = new TTVisual.TTTabPage();
        this.DocumentRecordLogTab.DisplayIndex = 2;
        this.DocumentRecordLogTab.TabIndex = 2;
        this.DocumentRecordLogTab.Text = "Taşınır Mal İşlem Belgeleri";
        this.DocumentRecordLogTab.Name = "DocumentRecordLogTab";

        this.PictureTabpage = new TTVisual.TTTabPage();
        this.PictureTabpage.DisplayIndex = 2;
        this.PictureTabpage.TabIndex = 2;
        this.PictureTabpage.Text = "Fatura";
        this.PictureTabpage.Name = "PictureTabpage";

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.DocumentRecordLogs = new TTVisual.TTGrid();
        this.DocumentRecordLogs.HideCancelledData = false;
        this.DocumentRecordLogs.AllowUserToDeleteRows = false;
        this.DocumentRecordLogs.ReadOnly = true;
        this.DocumentRecordLogs.Name = "DocumentRecordLogs";
        this.DocumentRecordLogs.TabIndex = 0;
        this.DocumentRecordLogs.Height = 350;
        this.DocumentRecordLogs.AllowUserToAddRows = false;

        this.invoicePictureControl = new TTVisual.TTPictureBoxControl();
        this.invoicePictureControl.Name = "invoicePictureControl";
        this.invoicePictureControl.TabIndex = 0;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.DocumentRecordLogNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DocumentRecordLogNumberDocumentRecordLog.DataMember = "DocumentRecordLogNumber";
        this.DocumentRecordLogNumberDocumentRecordLog.DisplayIndex = 0;
        this.DocumentRecordLogNumberDocumentRecordLog.HeaderText = i18n("M11746", "Belge Numarası");
        this.DocumentRecordLogNumberDocumentRecordLog.Name = "DocumentRecordLogNumberDocumentRecordLog";
        this.DocumentRecordLogNumberDocumentRecordLog.Width = 100;


        this.Waybill = new TTVisual.TTTextBox();
        this.Waybill.Name = "Waybill";
        this.Waybill.TabIndex = 145;



        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.DocumentDateTimeDocumentRecordLog = new TTVisual.TTDateTimePickerColumn();
        this.DocumentDateTimeDocumentRecordLog.DataMember = "DocumentDateTime";
        this.DocumentDateTimeDocumentRecordLog.DisplayIndex = 1;
        this.DocumentDateTimeDocumentRecordLog.HeaderText = i18n("M11748", "Belge Tarihi");
        this.DocumentDateTimeDocumentRecordLog.Name = "DocumentDateTimeDocumentRecordLog";
        this.DocumentDateTimeDocumentRecordLog.Width = 140;

        this.RegistrationAuctionNo = new TTVisual.TTTextBox();
        this.RegistrationAuctionNo.Required = true;
        this.RegistrationAuctionNo.BackColor = "#FFE3C6";
        this.RegistrationAuctionNo.Name = "RegistrationAuctionNo";
        this.RegistrationAuctionNo.TabIndex = 139;

        this.txtTotalPrice = new TTVisual.TTTextBox();
        this.txtTotalPrice.BackColor = "#F0F0F0";
        this.txtTotalPrice.ReadOnly = true;
        this.txtTotalPrice.Name = "txtTotalPrice";
        this.txtTotalPrice.TabIndex = 134;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 118;

        this.DocumentTransactionTypeDocumentRecordLog = new TTVisual.TTEnumComboBoxColumn();
        this.DocumentTransactionTypeDocumentRecordLog.DataTypeName = "DocumentTransactionTypeEnum";
        this.DocumentTransactionTypeDocumentRecordLog.DataMember = "DocumentTransactionType";
        this.DocumentTransactionTypeDocumentRecordLog.DisplayIndex = 2;
        this.DocumentTransactionTypeDocumentRecordLog.HeaderText = i18n("M16834", "İşlem Çeşidi");
        this.DocumentTransactionTypeDocumentRecordLog.Name = "DocumentTransactionTypeDocumentRecordLog";
        this.DocumentTransactionTypeDocumentRecordLog.Width = 120;

        this.ExaminationReportNo = new TTVisual.TTTextBox();
        this.ExaminationReportNo.Name = "ExaminationReportNo";
        this.ExaminationReportNo.TabIndex = 130;
        this.ExaminationReportNo.Required = false;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.BudgeTypeEnum = new TTVisual.TTEnumComboBoxColumn();
        this.BudgeTypeEnum.DataTypeName = "MKYS_EButceTurEnum";
        this.BudgeTypeEnum.DataMember = "BudgeType";
        this.BudgeTypeEnum.DisplayIndex = 3;
        this.BudgeTypeEnum.HeaderText = i18n("M12145", "Bütçe Tipi");
        this.BudgeTypeEnum.Name = "BudgeTypeEnum";
        this.BudgeTypeEnum.ReadOnly = true;
        this.BudgeTypeEnum.Width = 200;

        this.ConclusionNumber = new TTVisual.TTTextBox();
        this.ConclusionNumber.Name = "ConclusionNumber";
        this.ConclusionNumber.TabIndex = 5;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.SubjectDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.SubjectDocumentRecordLog.DataMember = "Subject";
        this.SubjectDocumentRecordLog.DisplayIndex = 4;
        this.SubjectDocumentRecordLog.HeaderText = i18n("M14805", "Giriş ve Çıkış Nedenleri");
        this.SubjectDocumentRecordLog.Name = "SubjectDocumentRecordLog";
        this.SubjectDocumentRecordLog.Width = 200;
        this.SubjectDocumentRecordLog.Visible = false;

        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = i18n("M12146", "Bütçe Türü");
        this.labelBudgetTypeDefinition.Name = "labelBudgetTypeDefinition";
        this.labelBudgetTypeDefinition.TabIndex = 144;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.NumberOfRowsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.NumberOfRowsDocumentRecordLog.DataMember = "NumberOfRows";
        this.NumberOfRowsDocumentRecordLog.DisplayIndex = 5;
        this.NumberOfRowsDocumentRecordLog.HeaderText = i18n("M17091", "Kalem Adedi");
        this.NumberOfRowsDocumentRecordLog.Name = "NumberOfRowsDocumentRecordLog";
        this.NumberOfRowsDocumentRecordLog.Width = 50;
        this.NumberOfRowsDocumentRecordLog.Visible = false;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.Name = "BudgetTypeDefinition";
        this.BudgetTypeDefinition.TabIndex = 143;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = "10%";
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = "20%";

        this.labelWaybillDate = new TTVisual.TTLabel();
        this.labelWaybillDate.Text = i18n("M16573", "İrsaliye Tarihi");
        this.labelWaybillDate.Name = "labelWaybillDate";
        this.labelWaybillDate.TabIndex = 149;


        this.WaybillDate = new TTVisual.TTDateTimePicker();
        this.WaybillDate.Format = DateTimePickerFormat.Short;
        this.WaybillDate.Name = "WaybillDate";
        this.WaybillDate.TabIndex = 148;
        this.WaybillDate.Required = true;
        this.WaybillDate.BackColor = "#FFE3C6";


        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.TakenGivenPlaceDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.TakenGivenPlaceDocumentRecordLog.DataMember = "TakenGivenPlace";
        this.TakenGivenPlaceDocumentRecordLog.DisplayIndex = 6;
        this.TakenGivenPlaceDocumentRecordLog.HeaderText = i18n("M10714", "Alındığı / Verildiği Yer");
        this.TakenGivenPlaceDocumentRecordLog.Name = "TakenGivenPlaceDocumentRecordLog";
        this.TakenGivenPlaceDocumentRecordLog.Width = 200;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14807", "Giriş Yapılan Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 142;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.ReceiptNumber = new TTVisual.TTTextBoxColumn();
        this.ReceiptNumber.DataMember = "ReceiptNumber";
        this.ReceiptNumber.DisplayIndex = 7;
        this.ReceiptNumber.HeaderText = "Ayniyat Makbuz No";
        this.ReceiptNumber.Name = "ReceiptNumber";
        this.ReceiptNumber.ReadOnly = true;
        this.ReceiptNumber.Width = 150;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 141;


        this.GetWaybill = new TTButtonTextBox();
        this.GetWaybill.ButtonText = "B.G.";
        this.GetWaybill.Name = "GetWaybill";
        this.GetWaybill.TabIndex = 147;
        this.GetWaybill.ButtonWidth = "10px";
        this.GetWaybill.Required = true;
        this.GetWaybill.BackColor = "#FFE3C6";




        this.labelWaybill = new TTVisual.TTLabel();
        this.labelWaybill.Text = i18n("M16572", "İrsaliye Numarası");
        this.labelWaybill.Name = "labelWaybill";
        this.labelWaybill.TabIndex = 146;


        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.DescriptionsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DescriptionsDocumentRecordLog.DataMember = "Descriptions";
        this.DescriptionsDocumentRecordLog.DisplayIndex = 8;
        this.DescriptionsDocumentRecordLog.HeaderText = i18n("M10483", "Açıklamalar");
        this.DescriptionsDocumentRecordLog.Name = "DescriptionsDocumentRecordLog";
        this.DescriptionsDocumentRecordLog.Width = 180;

        this.labelRegistrationAuctionNo = new TTVisual.TTLabel();
        this.labelRegistrationAuctionNo.Text = i18n("M16214", "İhale No");
        this.labelRegistrationAuctionNo.Name = "labelRegistrationAuctionNo";
        this.labelRegistrationAuctionNo.TabIndex = 140;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 113;

        this.SendToMKYS = new TTVisual.TTButton();
        this.SendToMKYS.Text = "MKYS ve XXXXXX Gönder";
        this.SendToMKYS.Name = "SendToMKYS";
        this.SendToMKYS.TabIndex = 126;

        this.labelAuctionDate = new TTVisual.TTLabel();
        this.labelAuctionDate.Text = i18n("M16199", "İhale  Tarihi");
        this.labelAuctionDate.Name = "labelAuctionDate";
        this.labelAuctionDate.TabIndex = 138;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.AuctionDate = new TTVisual.TTDateTimePicker();
        this.AuctionDate.Required = true;
        this.AuctionDate.BackColor = "#FFE3C6";
        this.AuctionDate.Format = DateTimePickerFormat.Short;
        this.AuctionDate.Name = "AuctionDate";
        this.AuctionDate.TabIndex = 137;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.labelExaminationReportNo = new TTVisual.TTLabel();
        this.labelExaminationReportNo.Text = i18n("M19210", "Muayene Rapor Sayısı");
        this.labelExaminationReportNo.Name = "labelExaminationReportNo";
        this.labelExaminationReportNo.TabIndex = 131;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.AllowUserToAddRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;
        this.StockActionSignDetails.Height = "500px";

        this.labelExaminationReportDate = new TTVisual.TTLabel();
        this.labelExaminationReportDate.Text = i18n("M19211", "Muayene Rapor Tarihi");
        this.labelExaminationReportDate.Name = "labelExaminationReportDate";
        this.labelExaminationReportDate.TabIndex = 129;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.ExaminationReportDate = new TTVisual.TTDateTimePicker();
        this.ExaminationReportDate.Format = DateTimePickerFormat.Short;
        this.ExaminationReportDate.Name = "ExaminationReportDate";
        this.ExaminationReportDate.TabIndex = 128;
        this.ExaminationReportDate.Required = false;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;

        this.labelConclusionNumber = new TTVisual.TTLabel();
        this.labelConclusionNumber.Text = i18n("M17276", "Karar Numarası");
        this.labelConclusionNumber.Name = "labelConclusionNumber";
        this.labelConclusionNumber.TabIndex = 123;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.labelConclusionDateTime = new TTVisual.TTLabel();
        this.labelConclusionDateTime.Text = i18n("M17284", "Karar Tarihi");
        this.labelConclusionDateTime.Name = "labelConclusionDateTime";
        this.labelConclusionDateTime.TabIndex = 121;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 111;

        this.ConclusionDateTime = new TTVisual.TTDateTimePicker();
        this.ConclusionDateTime.BackColor = "#F0F0F0";
        this.ConclusionDateTime.Format = DateTimePickerFormat.Short;
        this.ConclusionDateTime.Enabled = false;
        this.ConclusionDateTime.Name = "ConclusionDateTime";
        this.ConclusionDateTime.TabIndex = 6;

        this.labelSupplier = new TTVisual.TTLabel();
        this.labelSupplier.Text = i18n("M14301", "Firma");
        this.labelSupplier.Name = "labelSupplier";
        this.labelSupplier.TabIndex = 119;

        this.Supplier = new TTVisual.TTObjectListBox();
        this.Supplier.ReadOnly = true;
        this.Supplier.ListDefName = "SupplierListDefinition";
        this.Supplier.Name = "Supplier";
        this.Supplier.TabIndex = 9;
        this.Supplier.BackColor = "#FFE3C6";

        this.ChattelDocumentTabcontrol = new TTVisual.TTTabControl();
        this.ChattelDocumentTabcontrol.Name = "ChattelDocumentTabcontrol";
        this.ChattelDocumentTabcontrol.TabIndex = 10;

        this.ChattelDocumentDetailTabpage = new TTVisual.TTTabPage();
        this.ChattelDocumentDetailTabpage.DisplayIndex = 0;
        this.ChattelDocumentDetailTabpage.TabIndex = 0;
        this.ChattelDocumentDetailTabpage.Text = "Taşınır Malın";
        this.ChattelDocumentDetailTabpage.Name = "ChattelDocumentDetailTabpage";


        this.ChattelDocumentDetailsWithPurchase = new TTVisual.TTGrid();
        this.ChattelDocumentDetailsWithPurchase.Required = true;
        this.ChattelDocumentDetailsWithPurchase.Text = i18n("M12146", "Bütçe Türü");
        this.ChattelDocumentDetailsWithPurchase.Name = "ChattelDocumentDetailsWithPurchase";
        this.ChattelDocumentDetailsWithPurchase.TabIndex = 0;
        this.ChattelDocumentDetailsWithPurchase.Height = 350;
        this.ChattelDocumentDetailsWithPurchase.AllowUserToAddRows = false;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.MaterialStockActionDetailIn = new TTVisual.TTListBoxColumn();
        this.MaterialStockActionDetailIn.AllowMultiSelect = true;
        this.MaterialStockActionDetailIn.ListDefName = "MaterialListDefinition";
        this.MaterialStockActionDetailIn.DataMember = "Material";
        this.MaterialStockActionDetailIn.AutoCompleteDialogHeight = '60%';
        this.MaterialStockActionDetailIn.AutoCompleteDialogWidth = '90%';
        this.MaterialStockActionDetailIn.DisplayIndex = 1;
        this.MaterialStockActionDetailIn.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialStockActionDetailIn.Name = "MaterialStockActionDetailIn";
        this.MaterialStockActionDetailIn.Width = 500;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Material.Barcode";
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "Material.DistributionTypeName";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 120;

        this.AmountStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.AmountStockActionDetailIn.DataMember = "Amount";
        this.AmountStockActionDetailIn.Required = true;
        this.AmountStockActionDetailIn.Format = "N2";
        this.AmountStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountStockActionDetailIn.DisplayIndex = 4;
        this.AmountStockActionDetailIn.HeaderText = i18n("M19030", "Miktar");
        this.AmountStockActionDetailIn.Name = "AmountStockActionDetailIn";
        this.AmountStockActionDetailIn.Width = 120;
        this.AmountStockActionDetailIn.IsNumeric = true;

        this.UnitPriceStockActionDetailInWithOutVat = new TTVisual.TTTextBoxColumn();
        this.UnitPriceStockActionDetailInWithOutVat.DataMember = "UnitPriceWithOutVat";
        this.UnitPriceStockActionDetailInWithOutVat.Required = true;
        this.UnitPriceStockActionDetailInWithOutVat.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPriceStockActionDetailInWithOutVat.DisplayIndex = 5;
        this.UnitPriceStockActionDetailInWithOutVat.HeaderText = i18n("M17472", "KDV'siz Fiyatı");
        this.UnitPriceStockActionDetailInWithOutVat.Name = "UnitPriceStockActionDetailInWithOutVat";
        this.UnitPriceStockActionDetailInWithOutVat.Width = 120;
        this.UnitPriceStockActionDetailInWithOutVat.IsNumeric = true;

        this.ValueAddedTax = new TTVisual.TTTextBoxColumn();
        this.ValueAddedTax.DataMember = "VatRate";
        this.ValueAddedTax.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ValueAddedTax.DisplayIndex = 6;
        this.ValueAddedTax.HeaderText = i18n("M17457", "KDV Oranı");
        this.ValueAddedTax.Name = "ValueAddedTax";
        this.ValueAddedTax.ReadOnly = true;
        this.ValueAddedTax.Width = 120;
        this.ValueAddedTax.IsNumeric = true;

        this.UnitePriceWithVatNoDiscount = new TTVisual.TTTextBoxColumn();
        this.UnitePriceWithVatNoDiscount.DataMember = "UnitPriceWithInVat";
        this.UnitePriceWithVatNoDiscount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitePriceWithVatNoDiscount.DisplayIndex = 7;
        this.UnitePriceWithVatNoDiscount.HeaderText = i18n("M17468", "KDV'li Fiyatı");
        this.UnitePriceWithVatNoDiscount.Name = "UnitePriceWithVatNoDiscount";
        this.UnitePriceWithVatNoDiscount.ReadOnly = true;
        this.UnitePriceWithVatNoDiscount.Width = 120;
        this.UnitePriceWithVatNoDiscount.IsNumeric = true;

        this.MKYS_IndirimOranı = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimOranı.DataMember = "DiscountRate";
        this.MKYS_IndirimOranı.DisplayIndex = 8;
        this.MKYS_IndirimOranı.HeaderText = i18n("M16491", "İndirim Oranı");
        this.MKYS_IndirimOranı.Name = "MKYS_IndirimOranı";
        this.MKYS_IndirimOranı.Width = 120;
        this.MKYS_IndirimOranı.IsNumeric = true;

        this.UnitPriceStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.UnitPriceStockActionDetailIn.DataMember = "UnitPrice";
        this.UnitPriceStockActionDetailIn.Format = "#,###.#########";
        this.UnitPriceStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPriceStockActionDetailIn.DisplayIndex = 9;
        this.UnitPriceStockActionDetailIn.HeaderText = i18n("M16484", "İnd. Birim Fiyat");
        this.UnitPriceStockActionDetailIn.Name = "UnitPriceStockActionDetailIn";
        this.UnitPriceStockActionDetailIn.ReadOnly = true;
        this.UnitPriceStockActionDetailIn.Width = 120;
        this.UnitPriceStockActionDetailIn.IsNumeric = true;

        this.MKYS_IndirimTutari = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimTutari.DataMember = "DiscountAmount";
        this.MKYS_IndirimTutari.DisplayIndex = 10;
        this.MKYS_IndirimTutari.HeaderText = i18n("M16006", "Indirim Tutarı");
        this.MKYS_IndirimTutari.Name = "MKYS_IndirimTutari";
        this.MKYS_IndirimTutari.ReadOnly = true;
        this.MKYS_IndirimTutari.Width = 120;
        this.MKYS_IndirimTutari.IsNumeric = true;

        this.TotalPrice = new TTVisual.TTTextBoxColumn();
        this.TotalPrice.DataMember = "Price";
        this.TotalPrice.DisplayIndex = 11;
        this.TotalPrice.HeaderText = i18n("M23526", "Toplam Tutar");
        this.TotalPrice.Name = "TotalPrice";
        this.TotalPrice.ReadOnly = true;
        this.TotalPrice.Width = 120;
        this.TotalPrice.IsNumeric = true;

        this.LotNo = new TTVisual.TTTextBoxColumn();
        this.LotNo.DataMember = "LotNo";
        this.LotNo.DisplayIndex = 12;
        this.LotNo.HeaderText = "Lot No.";
        this.LotNo.Name = "LotNo";
        this.LotNo.Width = 100;

        this.ExpirationDateStockActionDetailIn = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDateStockActionDetailIn.Format = DateTimePickerFormat.Custom;
        this.ExpirationDateStockActionDetailIn.CustomFormat = "MM/yyyy";
        this.ExpirationDateStockActionDetailIn.DataMember = "ExpirationDate";
        this.ExpirationDateStockActionDetailIn.DisplayIndex = 13;
        this.ExpirationDateStockActionDetailIn.HeaderText = i18n("M22057", "Son Kullanma Tarihi");
        this.ExpirationDateStockActionDetailIn.Name = "ExpirationDateStockActionDetailIn";
        this.ExpirationDateStockActionDetailIn.Width = 180;

        this.StockLevelTypeStockActionDetailIn = new TTVisual.TTListDefComboBoxColumn();
        this.StockLevelTypeStockActionDetailIn.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeStockActionDetailIn.DataMember = "StockLevelType";
        this.StockLevelTypeStockActionDetailIn.DisplayIndex = 14;
        this.StockLevelTypeStockActionDetailIn.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeStockActionDetailIn.Name = "StockLevelTypeStockActionDetailIn";
        this.StockLevelTypeStockActionDetailIn.Visible = false;
        this.StockLevelTypeStockActionDetailIn.Width = 100;

        this.StatusStockActionDetailIn = new TTVisual.TTEnumComboBoxColumn();
        this.StatusStockActionDetailIn.DataTypeName = "StockActionDetailStatusEnum";
        this.StatusStockActionDetailIn.DataMember = "Status";
        this.StatusStockActionDetailIn.DisplayIndex = 15;
        this.StatusStockActionDetailIn.HeaderText = "Durum";
        this.StatusStockActionDetailIn.Name = "StatusStockActionDetailIn";
        this.StatusStockActionDetailIn.Visible = false;
        this.StatusStockActionDetailIn.Width = 80;

        this.MKYS_EdinimYili = new TTVisual.TTTextBoxColumn();
        this.MKYS_EdinimYili.DataMember = "RetrievalYear";
        this.MKYS_EdinimYili.DisplayIndex = 16;
        this.MKYS_EdinimYili.HeaderText = i18n("M13475", "Edinim Yılı");
        this.MKYS_EdinimYili.Name = "MKYS_EdinimYili";
        this.MKYS_EdinimYili.Width = 100;

        this.MKYS_UretimTarihi = new TTVisual.TTDateTimePickerColumn();
        this.MKYS_UretimTarihi.DataMember = "ProductionDate";
        this.MKYS_UretimTarihi.DisplayIndex = 17;
        this.MKYS_UretimTarihi.HeaderText = i18n("M23966", "Üretim Tarihi");
        this.MKYS_UretimTarihi.Name = "MKYS_UretimTarihi";
        this.MKYS_UretimTarihi.Width = 180;

        this.DistributionsTab = new TTVisual.TTTabPage();
        this.DistributionsTab.DisplayIndex = 1;
        this.DistributionsTab.TabIndex = 1;
        this.DistributionsTab.Text = i18n("M16634", "İstek Miktarları");
        this.DistributionsTab.Name = "DistributionsTab";


        this.DemandAmountsGrid = new TTVisual.TTGrid();
        this.DemandAmountsGrid.AllowUserToDeleteRows = false;
        this.DemandAmountsGrid.RowHeadersVisible = false;
        this.DemandAmountsGrid.Name = "DemandAmountsGrid";
        this.DemandAmountsGrid.TabIndex = 0;
        this.DemandAmountsGrid.Height = 350;
        this.DemandAmountsGrid.AllowUserToAddRows = false;

        this.DA_Material = new TTVisual.TTListBoxColumn();
        this.DA_Material.ListDefName = "MaterialListDefinition";
        this.DA_Material.DisplayIndex = 0;
        this.DA_Material.HeaderText = i18n("M18545", "Malzeme");
        this.DA_Material.Name = "DA_Material";
        this.DA_Material.ReadOnly = true;
        this.DA_Material.Visible = false;
        this.DA_Material.Width = 350;

        this.DA_MasterResource = new TTVisual.TTListBoxColumn();
        this.DA_MasterResource.ListDefName = "ResourceListDefinition";
        this.DA_MasterResource.DataMember = "MasterResource";
        this.DA_MasterResource.DisplayIndex = 1;
        this.DA_MasterResource.HeaderText = "Birim";
        this.DA_MasterResource.Name = "DA_MasterResource";
        this.DA_MasterResource.ReadOnly = true;
        this.DA_MasterResource.Width = 350;

        this.DA_DemandAmount = new TTVisual.TTTextBoxColumn();
        this.DA_DemandAmount.DataMember = "Amount";
        this.DA_DemandAmount.DisplayIndex = 2;
        this.DA_DemandAmount.HeaderText = i18n("M16632", "İstek Miktarı");
        this.DA_DemandAmount.Name = "DA_DemandAmount";
        this.DA_DemandAmount.ReadOnly = true;
        this.DA_DemandAmount.Width = 100;
        this.DA_DemandAmount.IsNumeric = true;

        this.DA_DistributionAmount = new TTVisual.TTTextBoxColumn();
        this.DA_DistributionAmount.DataMember = "DistributionAmount";
        this.DA_DistributionAmount.DisplayIndex = 3;
        this.DA_DistributionAmount.HeaderText = i18n("M12443", "Dağıtım Miktarı");
        this.DA_DistributionAmount.Name = "DA_DistributionAmount";
        this.DA_DistributionAmount.Visible = false;
        this.DA_DistributionAmount.Width = 100;
        this.DA_DistributionAmount.IsNumeric = true;

        this.txtDiscount = new TTVisual.TTTextBox();
        this.txtDiscount.BackColor = "#F0F0F0";
        this.txtDiscount.ReadOnly = true;
        this.txtDiscount.Name = "txtDiscount";
        this.txtDiscount.TabIndex = 124;

        this.txtWithKDV = new TTVisual.TTTextBox();
        this.txtWithKDV.BackColor = "#F0F0F0";
        this.txtWithKDV.ReadOnly = true;
        this.txtWithKDV.Name = "txtWithKDV";
        this.txtWithKDV.TabIndex = 134;

        this.txtNotKDV = new TTVisual.TTTextBox();
        this.txtNotKDV.BackColor = "#F0F0F0";
        this.txtNotKDV.ReadOnly = true;
        this.txtNotKDV.Name = "txtNotKDV";
        this.txtNotKDV.TabIndex = 124;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M23503", "Toplam İndirim Tutarı");
        this.ttlabel2.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 125;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M14100", "Fatura  Tutarı");
        this.ttlabel3.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 125;

        this.MKYS_EAlimYontemi = new TTVisual.TTEnumComboBox();
        this.MKYS_EAlimYontemi.DataTypeName = "MKYS_EAlimYontemiEnum";
        this.MKYS_EAlimYontemi.Name = "MKYS_EAlimYontemi";
        this.MKYS_EAlimYontemi.TabIndex = 19;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = i18n("M18581", "Malzeme Grup");
        this.labelMKYS_EMalzemeGrup.Name = "labelMKYS_EMalzemeGrup";
        this.labelMKYS_EMalzemeGrup.TabIndex = 16;

        this.MKYS_ETedarikTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_ETedarikTuru.DataTypeName = "MKYS_ETedarikTurEnum";
        this.MKYS_ETedarikTuru.Required = true;
        this.MKYS_ETedarikTuru.BackColor = "#F0F0F0";
        this.MKYS_ETedarikTuru.Enabled = false;
        this.MKYS_ETedarikTuru.Name = "MKYS_ETedarikTuru";
        this.MKYS_ETedarikTuru.TabIndex = 15;

        this.labelMKYS_ETedarikTuru = new TTVisual.TTLabel();
        this.labelMKYS_ETedarikTuru.Text = i18n("M14804", "Giriş Türü");
        this.labelMKYS_ETedarikTuru.Name = "labelMKYS_ETedarikTuru";
        this.labelMKYS_ETedarikTuru.TabIndex = 14;

        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = "MKYS_EMalzemeGrupEnum";
        this.MKYS_EMalzemeGrup.BackColor = "#F0F0F0";
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = "MKYS_EMalzemeGrup";
        this.MKYS_EMalzemeGrup.TabIndex = 17;

        this.labelMKYS_EAlimYontemi = new TTVisual.TTLabel();
        this.labelMKYS_EAlimYontemi.Text = i18n("M10699", "Alım Yöntemi");
        this.labelMKYS_EAlimYontemi.Name = "labelMKYS_EAlimYontemi";
        this.labelMKYS_EAlimYontemi.TabIndex = 18;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M17470", "KDV'siz Birim Fiyatlar Toplamı");
        this.ttlabel4.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 125;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M17465", "KDV'li Birim Fiyatlar Toplamı");
        this.ttlabel5.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 125;

        this.DocumentRecordLogSearch = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogSearch.Text = 'MKYS Log Sorgula';
        this.DocumentRecordLogSearch.Name = 'GetLogFromMkys';
        this.DocumentRecordLogSearch.Width = '10%';

        this.DocumentRecordLogDeleteMKYS = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogDeleteMKYS.Text = 'MKYS Kayıt Sil';
        this.DocumentRecordLogDeleteMKYS.Name = 'DeleteMkysRow';

        this.txtBarkod = new TTVisual.TTTextBox();
        this.txtBarkod.ReadOnly = false;
        this.txtBarkod.Name = "txtBarkod";
        this.txtBarkod.TabIndex = 124;

        this.txtUTSAlma = new TTVisual.TTTextBox();
        this.txtUTSAlma.ReadOnly = false;
        this.txtUTSAlma.Name = "txtUTSAlma";
        this.txtUTSAlma.TabIndex = 124;

        this.txtUTSLot = new TTVisual.TTTextBox();
        this.txtUTSLot.ReadOnly = false;
        this.txtUTSLot.Name = "txtUTSLot";
        this.txtUTSLot.TabIndex = 124;


        this.txtUTSVerme = new TTVisual.TTTextBox();
        this.txtUTSVerme.ReadOnly = false;
        this.txtUTSVerme.Name = "txtUTSVerme";
        this.txtUTSVerme.TabIndex = 124;

        this.DocumentRecordLogsColumns = [this.DocumentRecordLogNumberDocumentRecordLog, this.DocumentDateTimeDocumentRecordLog, this.DocumentTransactionTypeDocumentRecordLog, this.BudgeTypeEnum, this.SubjectDocumentRecordLog, this.NumberOfRowsDocumentRecordLog, this.TakenGivenPlaceDocumentRecordLog, this.ReceiptNumber, this.DescriptionsDocumentRecordLog, this.DocumentRecordLogDeleteMKYS, this.DocumentRecordLogSearch];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.ChattelDocumentDetailsWithPurchaseColumns = [this.Detail, this.MaterialStockActionDetailIn, this.Barcode, this.DistributionType, this.AmountStockActionDetailIn, this.UnitPriceStockActionDetailInWithOutVat, this.ValueAddedTax, this.UnitePriceWithVatNoDiscount, this.MKYS_IndirimOranı, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimTutari, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn, this.StockLevelTypeStockActionDetailIn, this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi];
        this.DemandAmountsGridColumns = [this.DA_Material, this.DA_MasterResource, this.DA_DemandAmount, this.DA_DistributionAmount];
        this.DocumentRecordLogTab.Controls = [this.DocumentRecordLogs];
        this.PictureTabpage.Controls = [this.invoicePictureControl];
        this.DescriptionAndSignTabControl.Controls = [this.PictureTabpage, this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.ChattelDocumentTabcontrol.Controls = [this.DocumentRecordLogTab, this.ChattelDocumentDetailTabpage, this.DistributionsTab];
        this.ChattelDocumentDetailTabpage.Controls = [this.ChattelDocumentDetailsWithPurchase];
        this.DistributionsTab.Controls = [this.DemandAmountsGrid];
        this.Controls = [this.DocumentRecordLogTab, this.PictureTabpage, this.txtBarkod, this.TTTeslimEdenButon, this.DocumentRecordLogs, this.invoicePictureControl, this.TTTeslimAlanButon, this.DocumentRecordLogNumberDocumentRecordLog, this.Waybill, this.labelMKYS_TeslimEden, this.DocumentDateTimeDocumentRecordLog, this.RegistrationAuctionNo, this.MKYS_TeslimEden, this.DocumentTransactionTypeDocumentRecordLog, this.txtTotalPrice, this.MKYS_TeslimAlan, this.BudgeTypeEnum, this.ExaminationReportNo, this.Description, this.SubjectDocumentRecordLog, this.ConclusionNumber, this.StockActionID, this.NumberOfRowsDocumentRecordLog, this.labelWaybillDate, this.labelMKYS_TeslimAlan, this.TakenGivenPlaceDocumentRecordLog, this.WaybillDate, this.labelTransactionDate, this.ReceiptNumber, this.GetWaybill, this.TransactionDate, this.DescriptionsDocumentRecordLog, this.labelWaybill, this.labelStockActionID, this.SendToMKYS, this.labelBudgetTypeDefinition, this.DescriptionAndSignTabControl, this.BudgetTypeDefinition, this.SignTabpage, this.labelStore, this.StockActionSignDetails, this.Store, this.SignUserType, this.labelRegistrationAuctionNo, this.SignUser, this.labelAuctionDate, this.IsDeputy, this.AuctionDate, this.ttlabel1, this.labelExaminationReportNo, this.labelExaminationReportDate, this.ExaminationReportDate, this.labelConclusionNumber, this.labelConclusionDateTime, this.ConclusionDateTime, this.labelSupplier, this.Supplier, this.ChattelDocumentTabcontrol, this.ChattelDocumentDetailTabpage, this.ChattelDocumentDetailsWithPurchase, this.Detail, this.MaterialStockActionDetailIn, this.Barcode, this.DistributionType, this.AmountStockActionDetailIn, this.UnitPriceStockActionDetailInWithOutVat, this.ValueAddedTax, this.UnitePriceWithVatNoDiscount, this.MKYS_IndirimOranı, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimTutari, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn, this.StockLevelTypeStockActionDetailIn, this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi, this.DistributionsTab, this.DemandAmountsGrid, this.DA_Material, this.DA_MasterResource, this.DA_DemandAmount, this.DA_DistributionAmount, this.txtDiscount, this.txtWithKDV, this.txtNotKDV, this.ttlabel2, this.ttlabel3, this.MKYS_EAlimYontemi, this.labelMKYS_EMalzemeGrup, this.MKYS_ETedarikTuru, this.labelMKYS_ETedarikTuru, this.MKYS_EMalzemeGrup, this.labelMKYS_EAlimYontemi, this.ttlabel4, this.ttlabel5, this.DocumentRecordLogDeleteMKYS, this.DocumentRecordLogSearch];


    }

}
