//$2134574A
import { Component, OnInit, NgZone } from '@angular/core';
import { ChattelDocumentInputWithAccountancyCompletedFormViewModel } from './ChattelDocumentInputWithAccountancyCompletedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseChattelDocumentInputWithAccountancyForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentInputWithAccountancyForm";
import { ChattelDocumentInputWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Accountancy } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentInputDetailWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import Exception from 'app/NebulaClient/System/Exception';
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { MkysServis } from 'NebulaClient/Services/External/MkysServis';
import { StockActionService, DocumentRecordLogReceiptNumber_Input, OutputForReGeneration, CheckDocumentRecordLogForDelete_Output, DocumentRecordLogCheckComponent_Input } from 'ObjectClassService/StockActionService';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { IModalService } from "Fw/Services/IModalService";
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DocumentTransactionTypeEnum, StockActionDetailIn } from 'NebulaClient/Model/AtlasClientModel';
import { UsernamePwdBox } from 'NebulaClient/Visual/UsernamePwdBox';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';
import { Convert } from "app/NebulaClient/Mscorlib/Convert";
import { PTSMaterial } from './BaseChattelDocumentWithPurchaseForm';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';

@Component({
    selector: 'ChattelDocumentInputWithAccountancyCompletedForm',
    templateUrl: './ChattelDocumentInputWithAccountancyCompletedForm.html',
    providers: [MessageService]
})
export class ChattelDocumentInputWithAccountancyCompletedForm extends BaseChattelDocumentInputWithAccountancyForm implements OnInit {
    BudgeTypeEnum: TTVisual.ITTEnumComboBoxColumn;
    DescriptionsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentDateTimeDocumentRecordLog: TTVisual.ITTDateTimePickerColumn;
    DocumentRecordLogNumberDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogs: TTVisual.ITTGrid;
    DocumentRecordLogTab: TTVisual.ITTTabPage;
    DocumentRecordLogTabpage: TTVisual.ITTTabPage;
    DocumentTransactionTypeDocumentRecordLog: TTVisual.ITTEnumComboBoxColumn;
    NumberOfRowsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    ReceiptNumber: TTVisual.ITTTextBoxColumn;
    SendToMKYS: TTVisual.ITTButton;
    SubjectDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    TakenGivenPlaceDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogSearch: TTVisual.ITTButtonColumn;
    public ChattelDocumentDetailsWithAccountancyColumns = [];
    public DocumentRecordLogsColumns = [];
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;
    public StockActionSignDetailsColumns = [];
    public chattelDocumentInputWithAccountancyCompletedFormViewModel: ChattelDocumentInputWithAccountancyCompletedFormViewModel = new ChattelDocumentInputWithAccountancyCompletedFormViewModel();
    public get _ChattelDocumentInputWithAccountancy(): ChattelDocumentInputWithAccountancy {
        return this._TTObject as ChattelDocumentInputWithAccountancy;
    }
    private ChattelDocumentInputWithAccountancyCompletedForm_DocumentUrl: string = '/api/ChattelDocumentInputWithAccountancyService/ChattelDocumentInputWithAccountancyCompletedForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone, protected objectContextService: ObjectContextService) {
        super(httpService, messageService, ngZone, objectContextService);
        this._DocumentServiceUrl = this.ChattelDocumentInputWithAccountancyCompletedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();


    }


    // ***** Method declarations start *****
    public mkysSonucMesaj: string;
    popupVisible: boolean = false;
    buttonText = "MKYS'ye GÖNDER";
    loadIndicatorVisible = false;
    reGenerateButtonVisible: boolean = true;
    showBarkodUpdatePopup: boolean = false;
    activeInputDetail: StockActionDetailIn = null;

    public async prepareDocument_Click(): Promise<void> {
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ChattelDocumentInputWithAccountancy.ObjectID.toString());
        for (let document of documentRecordLogs) {
            if (this._ChattelDocumentInputWithAccountancy.IsPTSAction == false) {
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
            } else {
                if (document.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                    const objectIdParam = new GuidParam(document['ObjectID']);
                    const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                    let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                    this.reportService.showReport('ChattelDocumentInDetailReportPTS', reportParameters);
                }
            }
        }
    }

    public async reGenerateAction_Click(): Promise<void> {
        let result: OutputForReGeneration = null;
        try {
            result = await StockActionService.ReGenerateMyChattelDocumentInputWithAccountancy(this._ChattelDocumentInputWithAccountancy.ObjectID.toString());
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

    public showLoadPanel: boolean = false;
    public LoadPanelMessage: string = "MKYS İşlemi yapılıyor Lütfen Bekleyiniz...";

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
                if (this._ChattelDocumentInputWithAccountancy.CurrentStateDefID.toString() === ChattelDocumentInputWithAccountancy.ChattelDocumentInputWithAccountancyStates.Completed.id) {
                    for (let log of this._ChattelDocumentInputWithAccountancy.DocumentRecordLogs) {
                        if (log.ReceiptNumber == null) {
                            this.mkysSonucMesaj = await StockActionService.SendMKYSForInputDocumentTS(this._ChattelDocumentInputWithAccountancy, params.password);
                        }
                        if (log.ReceiptNumber != null) {
                            this.mkysSonucMesaj += log.ReceiptNumber.toString() + " Ayniyat numarası ile MKYSye kaydolmuştur.";
                        }
                    }
                }
                //-TODO İlaydax
                if (this._ChattelDocumentInputWithAccountancy.CurrentStateDefID.toString() === ChattelDocumentInputWithAccountancy.ChattelDocumentInputWithAccountancyStates.Cancelled.id) {
                    for (let log of this._ChattelDocumentInputWithAccountancy.DocumentRecordLogs) {
                        if (log.ReceiptNumber != null) {
                            this.mkysSonucMesaj = await StockActionService.SendDeleteMessageToMkysTS(this._ChattelDocumentInputWithAccountancy, false, log.ReceiptNumber.Value, params.password);
                        }
                    }
                }

                this.buttonText = "MKYS'ye GÖNDER";
                this.loadIndicatorVisible = false;
                this.showLoadPanel = false;
                if (String.isNullOrEmpty(this.mkysSonucMesaj) == false)
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

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);

    }

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();

        if (this._ChattelDocumentInputWithAccountancy.CurrentStateDefID.toString() == ChattelDocumentInputWithAccountancy.ChattelDocumentInputWithAccountancyStates.Completed.id.toString()) {
            this.reGenerateButtonVisible = false;
        }

        for (let detIn of this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy) {
            let price: number = 0;
            if (detIn.Amount != null && detIn.UnitPrice != null) {
                if (detIn.Amount > 0 && detIn.UnitPrice > 0) {
                    price = detIn.Amount * detIn.UnitPrice;
                    detIn.Price = Convert.ToInt32(price.toFixed(2));
                }
            }
        }


        let priceCalc: Array<number> = new Array<number>();
        let total: number = 0, salesTotal = 0, totalPrice = 0;
        priceCalc.push(total);
        priceCalc.push(salesTotal);
        priceCalc.push(totalPrice);
        priceCalc = await this.CalcFinalPrice(priceCalc);
        this.txtTotalNotDiscount.Text = priceCalc[0].toFixed(2);
        this.txtSalesTotal.Text = priceCalc[1].toFixed(2);
        this.txtTotalPrice.Text = priceCalc[2].toFixed(2);

        this.SendToMKYS.ReadOnly = false;
    }

    DocumentRecordLogs_CellValueChangedEmitted(data: any) { }
    initDocumentRecordLogsNewRow(data: any) { }
    onDocumentRecordLogsRowInserting(data: any) { }
    onSelectionChangeDocumentRecordLogs(data: any) { }
    // *****Method declarations end *****


    public initViewModel(): void {
        this._TTObject = new ChattelDocumentInputWithAccountancy();
        this.chattelDocumentInputWithAccountancyCompletedFormViewModel = new ChattelDocumentInputWithAccountancyCompletedFormViewModel();
        this._ViewModel = this.chattelDocumentInputWithAccountancyCompletedFormViewModel;
        this.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy = this._TTObject as ChattelDocumentInputWithAccountancy;
        this.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy.DocumentRecordLogs = new Array<DocumentRecordLog>();
        this.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy.Store = new Store();
        this.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy.Accountancy = new Accountancy();
        this.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy = new Array<ChattelDocumentInputDetailWithAccountancy>();
        this.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.chattelDocumentInputWithAccountancyCompletedFormViewModel = this._ViewModel as ChattelDocumentInputWithAccountancyCompletedFormViewModel;
        that._TTObject = this.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy;
        if (this.chattelDocumentInputWithAccountancyCompletedFormViewModel == null)
            this.chattelDocumentInputWithAccountancyCompletedFormViewModel = new ChattelDocumentInputWithAccountancyCompletedFormViewModel();
        if (this.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy == null)
            this.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy = new ChattelDocumentInputWithAccountancy();
        that.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy.DocumentRecordLogs = that.chattelDocumentInputWithAccountancyCompletedFormViewModel.DocumentRecordLogsGridList;
        for (let detailItem of that.chattelDocumentInputWithAccountancyCompletedFormViewModel.DocumentRecordLogsGridList) {
        }
        let budgetTypeDefinitionObjectID = that.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy["BudgetTypeDefinition"];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === "string")) {
            let budgetTypeDefinition = that.chattelDocumentInputWithAccountancyCompletedFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.chattelDocumentInputWithAccountancyCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy.Store = store;
            }
        }
        let accountancyObjectID = that.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy["Accountancy"];
        if (accountancyObjectID != null && (typeof accountancyObjectID === "string")) {
            let accountancy = that.chattelDocumentInputWithAccountancyCompletedFormViewModel.Accountancys.find(o => o.ObjectID.toString() === accountancyObjectID.toString());
            if (accountancy) {
                that.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy.Accountancy = accountancy;
            }
        }
        that.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy = that.chattelDocumentInputWithAccountancyCompletedFormViewModel.ChattelDocumentDetailsWithAccountancyGridList;
        for (let detailItem of that.chattelDocumentInputWithAccountancyCompletedFormViewModel.ChattelDocumentDetailsWithAccountancyGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.chattelDocumentInputWithAccountancyCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.chattelDocumentInputWithAccountancyCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.chattelDocumentInputWithAccountancyCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.chattelDocumentInputWithAccountancyCompletedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
            let SupplierID = detailItem['Supplier'];
            if (SupplierID != null && (typeof SupplierID === 'string')) {
                let Supplier = that.chattelDocumentInputWithAccountancyCompletedFormViewModel.Suppliers.find(o => o.ObjectID.toString() === SupplierID.toString());
                if (Supplier) {
                    detailItem.Supplier = Supplier;
                }
            }
        }
        that.chattelDocumentInputWithAccountancyCompletedFormViewModel._ChattelDocumentInputWithAccountancy.StockActionSignDetails = that.chattelDocumentInputWithAccountancyCompletedFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.chattelDocumentInputWithAccountancyCompletedFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === "string")) {
                let signUser = that.chattelDocumentInputWithAccountancyCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
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
        await this.load(ChattelDocumentInputWithAccountancyCompletedFormViewModel);
        this.MKYS_TeslimAlan.ButtonEnabled = false;
        this.MKYS_TeslimEden.ButtonEnabled = false;
        this.DocumentRecordLogSearch.ReadOnly = false;
        that.DocumentRecordLogDeleteMKYS.ReadOnly = false;
        if (this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        if (this._ChattelDocumentInputWithAccountancy.CurrentStateDefID.toString() == ChattelDocumentInputWithAccountancy.ChattelDocumentInputWithAccountancyStates.Completed.id.toString()) {
            this.FormCaption = 'Taşınır Mal Giriş ( Tamamlandı )';
        }
        if (this._ChattelDocumentInputWithAccountancy.CurrentStateDefID.toString() == ChattelDocumentInputWithAccountancy.ChattelDocumentInputWithAccountancyStates.Cancelled.id.toString()) {
            this.FormCaption = 'Taşınır Mal Giriş ( İptal Edildi )';
        }

        that.incomingITSReceiptNotificationList = new Array<PTSMaterial>();
        if (that._ChattelDocumentInputWithAccountancy.IsPTSAction === true) {
            that.ShowITSReceiveNotifications = true;
            that.titleGrid = "PTS Giriş";
            if (String.isNullOrEmpty(that._ChattelDocumentInputWithAccountancy.PTSNumber))
                this.ItsPackageNo = "PTS XML Girişi";
            else
                this.ItsPackageNo = that._ChattelDocumentInputWithAccountancy.PTSNumber;

            for (let item of that._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy) {

                let ptsMAterialExist: PTSMaterial = that.incomingITSReceiptNotificationList.find(x => x.lotNO == item.LotNo && x.barcode == item.Material.Barcode && x.expirationDate.toString() === item.ExpirationDate.toString())
                if (ptsMAterialExist != null) {
                    ptsMAterialExist.amount = ptsMAterialExist.amount + item.Amount;
                    ptsMAterialExist.DiscountAmount = Math.Round(ptsMAterialExist.DiscountAmount + item.DiscountAmount, 6);
                    ptsMAterialExist.UnitPrice = Math.Round(ptsMAterialExist.UnitPrice + item.UnitPrice, 6);
                    ptsMAterialExist.price = Math.Round(ptsMAterialExist.price + item.Price, 6);
                }
                else {
                    let pTSMaterial: PTSMaterial = new PTSMaterial();
                    pTSMaterial.amount = item.Amount;
                    pTSMaterial.materialName = item.Material.Name;
                    pTSMaterial.NatoStockNo = item.Material.StockCard.NATOStockNO;
                    pTSMaterial.DiscountAmount = item.DiscountAmount;
                    pTSMaterial.DiscountRate = item.DiscountRate;
                    pTSMaterial.expirationDate = item.ExpirationDate;
                    pTSMaterial.material = item.Material;
                    pTSMaterial.barcode = item.Material.Barcode;
                    pTSMaterial.material.StockCard = item.Material.StockCard;
                    pTSMaterial.material.StockCard.DistributionType = item.Material.StockCard.DistributionType;
                    pTSMaterial.DistributionTypeName = item.Material.StockCard.DistributionType.DistributionType;
                    pTSMaterial.UnitPriceWithInVat = item.UnitPrice;
                    pTSMaterial.UnitPriceWithOutVat = item.UnitPrice - (item.VatRate / 100);
                    pTSMaterial.VatRate = item.VatRate;
                    pTSMaterial.DiscountAmount = item.DiscountAmount;
                    pTSMaterial.lotNO = item.LotNo;
                    pTSMaterial.RetrievalYear = item.RetrievalYear;
                    pTSMaterial.ProductionDate = item.ProductionDate;
                    pTSMaterial.price = item.Price;
                    pTSMaterial.UnitPrice = item.UnitPrice;
                    that.incomingITSReceiptNotificationList.push(pTSMaterial);
                }
            }
        }

    }

    receiptNumberError: string = "";
    controlOfCancelMKYS: boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        for (let log of this._ChattelDocumentInputWithAccountancy.DocumentRecordLogs) {
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


    public async SendToITS_Click() {
        this.showLoadPanel = true;
        StockActionService.ITSSendReceiptNotification(this._ChattelDocumentInputWithAccountancy).then(res => {
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
                                }).catch();
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
    async CancelBarkodUpdate() {
        this.showBarkodUpdatePopup = false;
        this.activeInputDetail = null;
        TTVisual.InfoBox.Alert("İşlemden vazgeçildi.");
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

    public onAccountancyChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Accountancy != event) {
                this._ChattelDocumentInputWithAccountancy.Accountancy = event;
            }
        }
        this.Accountancy_SelectedObjectChanged();
    }

    public onBudgetTypeDefinitionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition != event) {
                this._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = event;
            }
        }
    }
    public onAdditionalDocumentCountChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.AdditionalDocumentCount != event) {
                this._ChattelDocumentInputWithAccountancy.AdditionalDocumentCount = event;
            }
        }
    }
    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Description != event) {
                this._ChattelDocumentInputWithAccountancy.Description = event;
            }
        }
    }

    public onMKYS_AyniyatMakbuzIDChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_AyniyatMakbuzID != event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_AyniyatMakbuzID = event;
            }
        }
    }

    public oninputWithAccountancyTypeChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType != event) {
                this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType = event;
            }
        }
    }
    public onMKYS_EAlimYontemiChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_EAlimYontemi != event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_EAlimYontemi = event;
            }
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup != event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup = event;
            }
        }
    }

    public onMKYS_ETedarikTuruChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru != event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlan != event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEden != event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.StockActionID != event) {
                this._ChattelDocumentInputWithAccountancy.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Store != event) {
                this._ChattelDocumentInputWithAccountancy.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.TransactionDate != event) {
                this._ChattelDocumentInputWithAccountancy.TransactionDate = event;
            }
        }
    }

    public onWaybillChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Waybill != event) {
                this._ChattelDocumentInputWithAccountancy.Waybill = event;
            }
        }
    }

    public onWaybillDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.WaybillDate != event) {
                this._ChattelDocumentInputWithAccountancy.WaybillDate = event;
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
        redirectProperty(this.MKYS_EMalzemeGrup, "Value", this.__ttObject, "MKYS_EMalzemeGrup");
        redirectProperty(this.MKYS_ETedarikTuru, "Value", this.__ttObject, "MKYS_ETedarikTuru");
        redirectProperty(this.MKYS_EAlimYontemi, "Value", this.__ttObject, "MKYS_EAlimYontemi");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.inputWithAccountancyType, "Value", this.__ttObject, "inputWithAccountancyType");
        redirectProperty(this.Waybill, "Text", this.__ttObject, "Waybill");
        redirectProperty(this.WaybillDate, "Value", this.__ttObject, "WaybillDate");
    }

    public initFormControls(): void {
        this.DocumentRecordLogTabpage = new TTVisual.TTTabPage();
        this.DocumentRecordLogTabpage.DisplayIndex = 0;
        this.DocumentRecordLogTabpage.TabIndex = 2;
        this.DocumentRecordLogTabpage.Text = "Taşınır Mal İşlem Belgeleri";
        this.DocumentRecordLogTabpage.Name = "DocumentRecordLogTabpage";

        this.Waybill = new TTButtonTextBox();
        this.Waybill.Name = "Waybill";
        this.Waybill.TabIndex = 132;

        this.txtTotalPrice = new TTVisual.TTTextBox();
        this.txtTotalPrice.BackColor = "#F0F0F0";
        this.txtTotalPrice.ReadOnly = true;
        this.txtTotalPrice.Name = "txtTotalPrice";
        this.txtTotalPrice.TabIndex = 124;

        this.txtBarkod = new TTVisual.TTTextBox();
        this.txtBarkod.ReadOnly = false;
        this.txtBarkod.Name = "txtBarkod";
        this.txtBarkod.TabIndex = 124;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.DocumentRecordLogTab = new TTVisual.TTTabPage();
        this.DocumentRecordLogTab.DisplayIndex = 1;
        this.DocumentRecordLogTab.TabIndex = 1;
        this.DocumentRecordLogTab.Text = "Taşınır Mal İşlem Belgeleri";
        this.DocumentRecordLogTab.Name = "DocumentRecordLogTab";

        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = i18n("M12146", "Bütçe Türü");
        this.labelBudgetTypeDefinition.Name = "labelBudgetTypeDefinition";
        this.labelBudgetTypeDefinition.TabIndex = 129;

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

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.Required = true;
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.BackColor = '#FFE3C6';
        this.BudgetTypeDefinition.Name = "BudgetTypeDefinition";
        this.BudgetTypeDefinition.TabIndex = 128;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = "10%";
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = "20%";

        this.labelWaybillDate = new TTVisual.TTLabel();
        this.labelWaybillDate.Text = i18n("M16573", "İrsaliye Tarihi");
        this.labelWaybillDate.Name = "labelWaybillDate";
        this.labelWaybillDate.TabIndex = 135;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.DocumentRecordLogNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DocumentRecordLogNumberDocumentRecordLog.DataMember = "DocumentRecordLogNumber";
        this.DocumentRecordLogNumberDocumentRecordLog.DisplayIndex = 0;
        this.DocumentRecordLogNumberDocumentRecordLog.HeaderText = i18n("M11746", "Belge Numarası");
        this.DocumentRecordLogNumberDocumentRecordLog.Name = "DocumentRecordLogNumberDocumentRecordLog";
        this.DocumentRecordLogNumberDocumentRecordLog.Width = 120;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14807", "Giriş Yapılan Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 127;

        this.WaybillDate = new TTVisual.TTDateTimePicker();
        this.WaybillDate.Format = DateTimePickerFormat.Long;
        this.WaybillDate.Name = "WaybillDate";
        this.WaybillDate.TabIndex = 134;

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
        this.DocumentDateTimeDocumentRecordLog.Width = 180;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreDefinitionList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 126;

        this.labelWaybill = new TTVisual.TTLabel();
        this.labelWaybill.Text = i18n("M16572", "İrsaliye Numarası");
        this.labelWaybill.Name = "labelWaybill";
        this.labelWaybill.TabIndex = 133;

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
        this.DocumentTransactionTypeDocumentRecordLog.Width = 180;


        this.labelinputWithAccountancyType = new TTVisual.TTLabel();
        this.labelinputWithAccountancyType.Text = i18n("M14804", "Giriş Türü");
        this.labelinputWithAccountancyType.Name = "labelinputWithAccountancyType";
        this.labelinputWithAccountancyType.TabIndex = 131;


        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M14220", "Fatura Tutarı");
        this.ttlabel2.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 125;

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
        this.BudgeTypeEnum.Width = 140;

        this.inputWithAccountancyType = new TTVisual.TTEnumComboBox();
        this.inputWithAccountancyType.DataTypeName = "TasinirMalGirisTurEnum";
        this.inputWithAccountancyType.Name = "inputWithAccountancyType";
        this.inputWithAccountancyType.TabIndex = 130;

        this.labelAccountancy = new TTVisual.TTLabel();
        this.labelAccountancy.Text = "Geldiği Yer";
        this.labelAccountancy.Name = "labelAccountancy";
        this.labelAccountancy.TabIndex = 122;

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

        this.Accountancy = new TTVisual.TTObjectListBox();
        this.Accountancy.ReadOnly = true;
        this.Accountancy.ListDefName = "AccountancyList";
        this.Accountancy.Name = "Accountancy";
        this.Accountancy.TabIndex = 121;

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
        this.NumberOfRowsDocumentRecordLog.Visible = false;


        this.ChattelDocumentTabcontrol = new TTVisual.TTTabControl();
        this.ChattelDocumentTabcontrol.Name = "ChattelDocumentTabcontrol";
        this.ChattelDocumentTabcontrol.TabIndex = 120;

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
        this.TakenGivenPlaceDocumentRecordLog.Visible = false;

        this.ChattelDocumentDetailTabpage = new TTVisual.TTTabPage();
        this.ChattelDocumentDetailTabpage.DisplayIndex = 0;
        this.ChattelDocumentDetailTabpage.TabIndex = 0;
        this.ChattelDocumentDetailTabpage.Text = "Taşınır Malın";
        this.ChattelDocumentDetailTabpage.Name = "ChattelDocumentDetailTabpage";

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
        this.ReceiptNumber.Width = 140;

        this.ChattelDocumentDetailsWithAccountancy = new TTVisual.TTGrid();
        this.ChattelDocumentDetailsWithAccountancy.Required = true;
        this.ChattelDocumentDetailsWithAccountancy.Name = "ChattelDocumentDetailsWithAccountancy";
        this.ChattelDocumentDetailsWithAccountancy.TabIndex = 0;
        this.ChattelDocumentDetailsWithAccountancy.Height = 350;
        this.ChattelDocumentDetailsWithAccountancy.AllowUserToAddRows = false;

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

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ReadOnly = true;
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.SendToMKYS = new TTVisual.TTButton();
        this.SendToMKYS.Text = "MKYS'ye Gönder";
        this.SendToMKYS.Name = "SendToMKYS";
        this.SendToMKYS.TabIndex = 126;

        this.MaterialStockActionDetailIn = new TTVisual.TTListBoxColumn();
        this.MaterialStockActionDetailIn.AllowMultiSelect = true;
        this.MaterialStockActionDetailIn.ListDefName = "MaterialListDefinition";
        this.MaterialStockActionDetailIn.DataMember = "Material";
        this.MaterialStockActionDetailIn.AutoCompleteDialogHeight = '60%';
        this.MaterialStockActionDetailIn.AutoCompleteDialogWidth = '90%';
        this.MaterialStockActionDetailIn.DisplayIndex = 1;
        this.MaterialStockActionDetailIn.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialStockActionDetailIn.Name = "MaterialStockActionDetailIn";
        this.MaterialStockActionDetailIn.Width = 300;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Material.Barcode";
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "Material.DistributionTypeName";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 120;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.SentAmountChattelDocumentInputDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.SentAmountChattelDocumentInputDetailWithAccountancy.DataMember = "SentAmount";
        //this.SentAmountChattelDocumentInputDetailWithAccountancy.Format = "#,###.####";
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.SentAmountChattelDocumentInputDetailWithAccountancy.DisplayIndex = 4;
        this.SentAmountChattelDocumentInputDetailWithAccountancy.HeaderText = i18n("M14895", "Gönderilen Miktar");
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Name = "SentAmountChattelDocumentInputDetailWithAccountancy";
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Width = 120;
        //this.SentAmountChattelDocumentInputDetailWithAccountancy.IsNumeric = true;
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Visible = false;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;

        this.AmountStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.AmountStockActionDetailIn.DataMember = "Amount";
        this.AmountStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountStockActionDetailIn.DisplayIndex = 5;
        this.AmountStockActionDetailIn.HeaderText = i18n("M19030", "Miktar");
        this.AmountStockActionDetailIn.Name = "AmountStockActionDetailIn";
        this.AmountStockActionDetailIn.Width = 75;
        //this.AmountStockActionDetailIn.IsNumeric = true;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.NotDiscountedUnitPrice = new TTVisual.TTTextBoxColumn();
        this.NotDiscountedUnitPrice.DataMember = "NotDiscountedUnitPrice";
        this.NotDiscountedUnitPrice.DisplayIndex = 6;
        this.NotDiscountedUnitPrice.HeaderText = i18n("M16509", "İndirimsiz Birim Fiyatı");
        this.NotDiscountedUnitPrice.Name = "NotDiscountedUnitPrice";
        this.NotDiscountedUnitPrice.Width = 120;
        //this.NotDiscountedUnitPrice.IsNumeric = true;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 111;

        this.UnitPriceStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.UnitPriceStockActionDetailIn.DataMember = "UnitPrice";
        this.UnitPriceStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPriceStockActionDetailIn.DisplayIndex = 7;
        this.UnitPriceStockActionDetailIn.HeaderText = i18n("M11868", "Birim Maliyet Bedeli");
        this.UnitPriceStockActionDetailIn.Name = "UnitPriceStockActionDetailIn";
        this.UnitPriceStockActionDetailIn.ReadOnly = true;
        this.UnitPriceStockActionDetailIn.Width = 120;
        //this.UnitPriceStockActionDetailIn.IsNumeric = true;

        this.MKYS_IndirimOranı = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimOranı.DataMember = "DiscountRate";
        this.MKYS_IndirimOranı.DisplayIndex = 8;
        this.MKYS_IndirimOranı.HeaderText = i18n("M16491", "İndirim Oranı");
        this.MKYS_IndirimOranı.Name = "MKYS_IndirimOranı";
        this.MKYS_IndirimOranı.Width = 120;
        //this.MKYS_IndirimOranı.IsNumeric = true;

        this.MKYS_IndirimTutari = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimTutari.DataMember = "DiscountAmount";
        this.MKYS_IndirimTutari.DisplayIndex = 9;
        this.MKYS_IndirimTutari.HeaderText = i18n("M16501", "İndirim Tutarı");
        this.MKYS_IndirimTutari.Name = "MKYS_IndirimTutari";
        this.MKYS_IndirimTutari.ReadOnly = true;
        this.MKYS_IndirimTutari.Visible = false;
        this.MKYS_IndirimTutari.Width = 120;
        //this.MKYS_IndirimTutari.IsNumeric = true;

        this.TotalPriceNotDiscount = new TTVisual.TTTextBoxColumn();
        this.TotalPriceNotDiscount.DataMember = "TotalPriceNotDiscount";
        this.TotalPriceNotDiscount.DisplayIndex = 10;
        this.TotalPriceNotDiscount.HeaderText = i18n("M16510", "İndirimsiz Toplam Fiyat");
        this.TotalPriceNotDiscount.Name = "TotalPriceNotDiscount";
        this.TotalPriceNotDiscount.ReadOnly = true;
        this.TotalPriceNotDiscount.Width = 120;
        //this.TotalPriceNotDiscount.IsNumeric = true;

        this.TotalDiscountAmount = new TTVisual.TTTextBoxColumn();
        this.TotalDiscountAmount.DataMember = "TotalDiscountAmount";
        this.TotalDiscountAmount.DisplayIndex = 11;
        this.TotalDiscountAmount.HeaderText = i18n("M23503", "Toplam İndirim Tutarı");
        this.TotalDiscountAmount.Name = "TotalDiscountAmount";
        this.TotalDiscountAmount.ReadOnly = true;
        this.TotalDiscountAmount.Width = 120;
        //this.TotalDiscountAmount.IsNumeric = true;

        this.TotalPrice = new TTVisual.TTTextBoxColumn();
        this.TotalPrice.DataMember = "Price";
        this.TotalPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.TotalPrice.DisplayIndex = 12;
        this.TotalPrice.HeaderText = i18n("M23613", "Tutarı");
        this.TotalPrice.Name = "TotalPrice";
        this.TotalPrice.ReadOnly = true;
        this.TotalPrice.Width = 120;
        //this.TotalPrice.IsNumeric = true;

        this.LotNo = new TTVisual.TTTextBoxColumn();
        this.LotNo.DataMember = "LotNo";
        this.LotNo.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.LotNo.DisplayIndex = 13;
        this.LotNo.HeaderText = "Lot No.";
        this.LotNo.Name = "LotNo";
        this.LotNo.Width = 100;

        this.ExpirationDateStockActionDetailIn = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDateStockActionDetailIn.Format = DateTimePickerFormat.Custom;
        this.ExpirationDateStockActionDetailIn.CustomFormat = "MM/yyyy";
        this.ExpirationDateStockActionDetailIn.DataMember = "ExpirationDate";
        this.ExpirationDateStockActionDetailIn.DisplayIndex = 14;
        this.ExpirationDateStockActionDetailIn.HeaderText = i18n("M22057", "Son Kullanma Tarihi");
        this.ExpirationDateStockActionDetailIn.Name = "ExpirationDateStockActionDetailIn";
        this.ExpirationDateStockActionDetailIn.Width = 180;

        this.StockLevelTypeStockActionDetailIn = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeStockActionDetailIn.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeStockActionDetailIn.DataMember = "StockLevelType";
        this.StockLevelTypeStockActionDetailIn.Required = true;
        this.StockLevelTypeStockActionDetailIn.DisplayIndex = 15;
        this.StockLevelTypeStockActionDetailIn.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeStockActionDetailIn.Name = "StockLevelTypeStockActionDetailIn";
        this.StockLevelTypeStockActionDetailIn.Width = 180;

        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.DataMember = "ConflictSubject";
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.DisplayIndex = 16;
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.HeaderText = i18n("M23821", "Uyuşmazlık Konusu");
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.Name = "ConflictSubjectChattelDocumentInputDetailWithAccountancy";
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.Width = 120;
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.Visible = false;

        this.StatusStockActionDetailIn = new TTVisual.TTEnumComboBoxColumn();
        this.StatusStockActionDetailIn.DataTypeName = "StockActionDetailStatusEnum";
        this.StatusStockActionDetailIn.DataMember = "Status";
        this.StatusStockActionDetailIn.DisplayIndex = 17;
        this.StatusStockActionDetailIn.HeaderText = "Durum";
        this.StatusStockActionDetailIn.Name = "StatusStockActionDetailIn";
        this.StatusStockActionDetailIn.Visible = false;
        this.StatusStockActionDetailIn.Width = 80;

        this.MKYS_EdinimYili = new TTVisual.TTTextBoxColumn();
        this.MKYS_EdinimYili.DataMember = "RetrievalYear";
        this.MKYS_EdinimYili.DisplayIndex = 18;
        this.MKYS_EdinimYili.HeaderText = i18n("M13475", "Edinim Yılı");
        this.MKYS_EdinimYili.Name = "MKYS_EdinimYili";
        this.MKYS_EdinimYili.Width = 100;

        this.MKYS_UretimTarihi = new TTVisual.TTDateTimePickerColumn();
        this.MKYS_UretimTarihi.DataMember = "ProductionDate";
        this.MKYS_UretimTarihi.DisplayIndex = 19;
        this.MKYS_UretimTarihi.HeaderText = i18n("M23966", "Üretim Tarihi");
        this.MKYS_UretimTarihi.Name = "MKYS_UretimTarihi";
        this.MKYS_UretimTarihi.Width = 180;

        this.ConflictAmountChattelDocumentInputDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.DataMember = "ConflictAmount";
        //this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Format = "#,###.####";
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.DisplayIndex = 20;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.HeaderText = i18n("M23822", "Uyuşmazlık Miktarı");
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Name = "ConflictAmountChattelDocumentInputDetailWithAccountancy";
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.ReadOnly = true;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Visible = false;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Width = 100;
        //this.ConflictAmountChattelDocumentInputDetailWithAccountancy.IsNumeric = true;

        this.txtSalesTotal = new TTVisual.TTTextBox();
        this.txtSalesTotal.BackColor = "#F0F0F0";
        this.txtSalesTotal.ReadOnly = true;
        this.txtSalesTotal.Name = "txtSalesTotal";
        this.txtSalesTotal.TabIndex = 124;

        this.txtTotalNotDiscount = new TTVisual.TTTextBox();
        this.txtTotalNotDiscount.BackColor = "#F0F0F0";
        this.txtTotalNotDiscount.ReadOnly = true;
        this.txtTotalNotDiscount.Name = "txtTotalNotDiscount";
        this.txtTotalNotDiscount.TabIndex = 124;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M16501", "İndirim Tutarı");
        this.ttlabel3.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 125;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M23526", "Toplam Tutar");
        this.ttlabel4.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 125;

        this.labelMKYS_ETedarikTuru = new TTVisual.TTLabel();
        this.labelMKYS_ETedarikTuru.Text = i18n("M22969", "Tedarik Türü");
        this.labelMKYS_ETedarikTuru.Name = "labelMKYS_ETedarikTuru";
        this.labelMKYS_ETedarikTuru.TabIndex = 14;

        this.MKYS_ETedarikTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_ETedarikTuru.DataTypeName = "MKYS_ETedarikTurEnum";
        this.MKYS_ETedarikTuru.Required = true;
        this.MKYS_ETedarikTuru.BackColor = "#FFE3C6";
        this.MKYS_ETedarikTuru.Name = "MKYS_ETedarikTuru";
        this.MKYS_ETedarikTuru.TabIndex = 15;

        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = "MKYS_EMalzemeGrupEnum";
        this.MKYS_EMalzemeGrup.BackColor = "#F0F0F0";
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = "MKYS_EMalzemeGrup";
        this.MKYS_EMalzemeGrup.TabIndex = 17;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = i18n("M18581", "Malzeme Grup");
        this.labelMKYS_EMalzemeGrup.Name = "labelMKYS_EMalzemeGrup";
        this.labelMKYS_EMalzemeGrup.TabIndex = 16;

        this.MKYS_EAlimYontemi = new TTVisual.TTEnumComboBox();
        this.MKYS_EAlimYontemi.DataTypeName = "MKYS_EAlimYontemiEnum";
        this.MKYS_EAlimYontemi.Required = true;
        this.MKYS_EAlimYontemi.BackColor = "#FFE3C6";
        this.MKYS_EAlimYontemi.Name = "MKYS_EAlimYontemi";
        this.MKYS_EAlimYontemi.TabIndex = 19;

        this.labelMKYS_EAlimYontemi = new TTVisual.TTLabel();
        this.labelMKYS_EAlimYontemi.Text = i18n("M10699", "Alım Yöntemi");
        this.labelMKYS_EAlimYontemi.Name = "labelMKYS_EAlimYontemi";
        this.labelMKYS_EAlimYontemi.TabIndex = 18;

        this.DocumentRecordLogSearch = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogSearch.Text = 'MKYS Log Sorgula';
        this.DocumentRecordLogSearch.Name = 'GetLogFromMkys';

        this.ValueAddedTax = new TTVisual.TTTextBoxColumn();
        this.ValueAddedTax.DataMember = "VatRate";
        this.ValueAddedTax.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ValueAddedTax.DisplayIndex = 6;
        this.ValueAddedTax.HeaderText = i18n("M17457", "KDV Oranı");
        this.ValueAddedTax.Name = "ValueAddedTax";
        this.ValueAddedTax.ReadOnly = true;
        this.ValueAddedTax.Width = 100;

        this.DocumentRecordLogDeleteMKYS = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogDeleteMKYS.Text = 'MKYS Kayıt Sil';
        this.DocumentRecordLogDeleteMKYS.Name = 'DeleteMkysRow';

        this.DocumentRecordLogsColumns = [this.DocumentRecordLogNumberDocumentRecordLog, this.DocumentDateTimeDocumentRecordLog, this.DocumentTransactionTypeDocumentRecordLog, this.BudgeTypeEnum, this.SubjectDocumentRecordLog, this.NumberOfRowsDocumentRecordLog, this.TakenGivenPlaceDocumentRecordLog, this.ReceiptNumber, this.DescriptionsDocumentRecordLog, this.DocumentRecordLogDeleteMKYS, this.DocumentRecordLogSearch];
        this.ChattelDocumentDetailsWithAccountancyColumns = [this.Detail, this.MaterialStockActionDetailIn, this.Barcode,
        this.DistributionType, this.SentAmountChattelDocumentInputDetailWithAccountancy, this.AmountStockActionDetailIn,
        this.NotDiscountedUnitPrice, this.ValueAddedTax, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimOranı, this.MKYS_IndirimTutari,
        this.TotalPriceNotDiscount, this.TotalDiscountAmount, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn,
        this.StockLevelTypeStockActionDetailIn, this.ConflictSubjectChattelDocumentInputDetailWithAccountancy,
        this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi,
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.DocumentRecordLogTab.Controls = [this.DocumentRecordLogs];
        this.ChattelDocumentTabcontrol.Controls = [this.DocumentRecordLogTab, this.ChattelDocumentDetailTabpage];
        this.ChattelDocumentDetailTabpage.Controls = [this.ChattelDocumentDetailsWithAccountancy];
        this.DescriptionAndSignTabControl.Controls = [this.DocumentRecordLogTabpage, this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.DocumentRecordLogTabpage, this.Waybill, this.txtTotalPrice, this.txtBarkod, this.TTTeslimEdenButon, this.DocumentRecordLogTab, this.labelBudgetTypeDefinition, this.TTTeslimAlanButon, this.DocumentRecordLogs, this.labelWaybillDate, this.BudgetTypeDefinition, this.labelMKYS_TeslimEden, this.WaybillDate, this.DocumentRecordLogNumberDocumentRecordLog, this.labelStore, this.labelWaybill, this.MKYS_TeslimEden, this.DocumentDateTimeDocumentRecordLog, this.inputWithAccountancyType, this.Store, this.labelinputWithAccountancyType, this.MKYS_TeslimAlan, this.DocumentTransactionTypeDocumentRecordLog, this.ttlabel2, this.Description, this.BudgeTypeEnum, this.labelAccountancy, this.StockActionID, this.SubjectDocumentRecordLog, this.Accountancy, this.labelMKYS_TeslimAlan, this.NumberOfRowsDocumentRecordLog, this.ChattelDocumentTabcontrol, this.labelTransactionDate, this.TakenGivenPlaceDocumentRecordLog, this.ChattelDocumentDetailTabpage, this.TransactionDate, this.ReceiptNumber, this.ChattelDocumentDetailsWithAccountancy, this.labelStockActionID, this.DescriptionsDocumentRecordLog, this.Detail, this.DescriptionAndSignTabControl, this.SendToMKYS, this.MaterialStockActionDetailIn, this.SignTabpage, this.Barcode, this.StockActionSignDetails, this.DistributionType, this.SignUserType, this.SentAmountChattelDocumentInputDetailWithAccountancy, this.SignUser, this.AmountStockActionDetailIn, this.IsDeputy, this.NotDiscountedUnitPrice, this.ttlabel1, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimOranı, this.MKYS_IndirimTutari, this.TotalPriceNotDiscount, this.TotalDiscountAmount, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn, this.StockLevelTypeStockActionDetailIn, this.ConflictSubjectChattelDocumentInputDetailWithAccountancy, this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi, this.ConflictAmountChattelDocumentInputDetailWithAccountancy, this.txtSalesTotal, this.txtTotalNotDiscount, this.ttlabel3, this.ttlabel4, this.labelMKYS_ETedarikTuru, this.MKYS_ETedarikTuru, this.MKYS_EMalzemeGrup, this.labelMKYS_EMalzemeGrup, this.MKYS_EAlimYontemi, this.labelMKYS_EAlimYontemi, this.GetWaybill, this.DocumentRecordLogDeleteMKYS, this.DocumentRecordLogSearch];


    }


}
