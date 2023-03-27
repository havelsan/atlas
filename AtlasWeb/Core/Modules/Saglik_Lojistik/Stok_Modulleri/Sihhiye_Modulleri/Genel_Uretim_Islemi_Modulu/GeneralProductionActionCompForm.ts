//$AD562ADA
import { Component, OnInit, NgZone } from '@angular/core';
import { GeneralProductionActionCompFormViewModel } from './GeneralProductionActionCompFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseGeneralProductionActionFrom } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Genel_Uretim_Islemi_Modulu/BaseGeneralProductionActionFrom';
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { GeneralProductionAction } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { GeneralProductionOutDet } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import Exception from 'app/NebulaClient/System/Exception';
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { MkysServis } from 'NebulaClient/Services/External/MkysServis';
import { StockActionService, DocumentRecordLogReceiptNumber_Input } from 'ObjectClassService/StockActionService';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { IModalService } from "Fw/Services/IModalService";
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { UsernamePwdBox } from 'NebulaClient/Visual/UsernamePwdBox';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';

@Component({
    selector: 'GeneralProductionActionCompForm',
    templateUrl: './GeneralProductionActionCompForm.html',
    providers: [MessageService]
})
export class GeneralProductionActionCompForm extends BaseGeneralProductionActionFrom implements OnInit {
    BUDGETYPE: TTVisual.ITTEnumComboBoxColumn;
    DescriptionsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentDateTimeDocumentRecordLog: TTVisual.ITTDateTimePickerColumn;
    DocumentRecordLogNumberDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogs: TTVisual.ITTGrid;
    DocumentTransactionTypeDocumentRecordLog: TTVisual.ITTEnumComboBoxColumn;
    NumberOfRowsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    ReceiptNumber: TTVisual.ITTTextBoxColumn;
    SendToMKYS: TTVisual.ITTButton;
    tttabpage2: TTVisual.ITTTabPage;
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;
    DocumentRecordLogSearch: TTVisual.ITTButtonColumn;
    public DocumentRecordLogsColumns = [];
    public GeneralProductionOutDetsColumns = [];
    public generalProductionActionCompFormViewModel: GeneralProductionActionCompFormViewModel = new GeneralProductionActionCompFormViewModel();
    public get _GeneralProductionAction(): GeneralProductionAction {
        return this._TTObject as GeneralProductionAction;
    }
    private GeneralProductionActionCompForm_DocumentUrl: string = '/api/GeneralProductionActionService/GeneralProductionActionCompForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.GeneralProductionActionCompForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    public mkysSonucMesaj: string;
    popupVisible: boolean = false;
    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        this.SendToMKYS.ReadOnly = false;
    }

    public async prepareDocument_Click(): Promise<void> {
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._GeneralProductionAction.ObjectID.toString());
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
    }

    public showLoadPanel:boolean = false;
    public LoadPanelMessage: string = "MKYS İşlemi yapılıyor Lütfen Bekleyiniz...";
    public async SendToMKYS_Click(): Promise<void> {
        //-TODO İlaydax
        this.mkysSonucMesaj = '';
        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result == DialogResult.OK) {
            let params = <any>(<ModalActionResult>result).Param;

            this.showLoadPanel = true;
            let documetrecords: Array<DocumentRecordLog> = await this._GeneralProductionAction.DocumentRecordLogs.sort((a, b) => a.DocumentRecordLogNumber - b.DocumentRecordLogNumber);
            if (this._GeneralProductionAction.CurrentStateDefID.toString() === GeneralProductionAction.GeneralProductionActionStates.Completed.id) {
                for (let log_1 of documetrecords) {
                    if (log_1.DocumentTransactionType === DocumentTransactionTypeEnum.Out) {
                        if (log_1.ReceiptNumber == null) {
                            this.mkysSonucMesaj = await StockActionService.SendMKYSForOutputDocumentTS(this._GeneralProductionAction, params.password);
                        }
                        if (log_1.ReceiptNumber != null) {
                            this.mkysSonucMesaj += log_1.ReceiptNumber.toString() + ' Ayniyat numarası ile MKYSye kaydolmuştur.';
                        }

                    }
                }
                //-TODO İlaydax
                for (let log_2 of documetrecords) {
                    if (log_2.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                        if (log_2.ReceiptNumber == null) {
                            this.mkysSonucMesaj = await StockActionService.SendMKYSForInputDocumentTS(this._GeneralProductionAction, params.password);
                        }
                        if (log_2.ReceiptNumber != null) {
                            this.mkysSonucMesaj += log_2.ReceiptNumber.toString() + ' Ayniyat numarası ile MKYSye kaydolmuştur.';
                        }

                    }
                }
            }
            //-TODO İlaydax
            if (this._GeneralProductionAction.CurrentStateDefID.toString() === GeneralProductionAction.GeneralProductionActionStates.Cancelled.id) {
                for (let log_1 of documetrecords) {
                    if (log_1.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                        if (log_1.ReceiptNumber != null) {
                            let result = await UsernamePwdBox.Show(true);
                                this.mkysSonucMesaj = await StockActionService.SendDeleteMessageToMkysTS(this._GeneralProductionAction, false, log_1.ReceiptNumber.Value, params.password);
                        }
                    }
                }
                //-TODO İlaydax
                for (let log_2 of documetrecords) {
                    if (log_2.DocumentTransactionType === DocumentTransactionTypeEnum.Out) {
                        if (log_2.ReceiptNumber != null) {
                                this.mkysSonucMesaj = await StockActionService.SendDeleteMessageToMkysTS(this._GeneralProductionAction, true, log_2.ReceiptNumber.Value, params.password);                        }
                    }
                }
            }
            this.showLoadPanel = false;
            if (String.isNullOrEmpty(this.mkysSonucMesaj) == false)
                this.popupVisible = true;
        }
    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);

    }
    protected async PreScript() {
        super.PreScript();
    }

    DocumentRecordLogs_CellValueChangedEmitted(data: any) { }
    initDocumentRecordLogsNewRow(data: any) { }
    onDocumentRecordLogsRowInserting(data: any) { }
    onSelectionChangeDocumentRecordLogs(data: any) { }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new GeneralProductionAction();
        this.generalProductionActionCompFormViewModel = new GeneralProductionActionCompFormViewModel();
        this._ViewModel = this.generalProductionActionCompFormViewModel;
        this.generalProductionActionCompFormViewModel._GeneralProductionAction = this._TTObject as GeneralProductionAction;
        this.generalProductionActionCompFormViewModel._GeneralProductionAction.DocumentRecordLogs = new Array<DocumentRecordLog>();
        this.generalProductionActionCompFormViewModel._GeneralProductionAction.Store = new Store();
        this.generalProductionActionCompFormViewModel._GeneralProductionAction.Material = new Material();
        this.generalProductionActionCompFormViewModel._GeneralProductionAction.GeneralProductionOutDets = new Array<GeneralProductionOutDet>();
        this.generalProductionActionCompFormViewModel._GeneralProductionAction.BudgetTypeDefinition = new BudgetTypeDefinition();
    }

    protected loadViewModel() {
        let that = this;
        that.generalProductionActionCompFormViewModel = this._ViewModel;
        that._TTObject = this.generalProductionActionCompFormViewModel._GeneralProductionAction;
        if (this.generalProductionActionCompFormViewModel == null) {
            this.generalProductionActionCompFormViewModel = new GeneralProductionActionCompFormViewModel();
        }
        if (this.generalProductionActionCompFormViewModel._GeneralProductionAction == null) {
            this.generalProductionActionCompFormViewModel._GeneralProductionAction = new GeneralProductionAction();
        }
        that.generalProductionActionCompFormViewModel._GeneralProductionAction.DocumentRecordLogs = that.generalProductionActionCompFormViewModel.DocumentRecordLogsGridList;
        for (let detailItem of that.generalProductionActionCompFormViewModel.DocumentRecordLogsGridList) {
        }
        let storeObjectID = that.generalProductionActionCompFormViewModel._GeneralProductionAction['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.generalProductionActionCompFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.generalProductionActionCompFormViewModel._GeneralProductionAction.Store = store;
            }
        }
        let materialObjectID = that.generalProductionActionCompFormViewModel._GeneralProductionAction['Material'];
        if (materialObjectID != null && (typeof materialObjectID === 'string')) {
            let material = that.generalProductionActionCompFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
            if (material) {
                that.generalProductionActionCompFormViewModel._GeneralProductionAction.Material = material;
            }
        }
        let budgetTypeDefinitionObjectID = that.generalProductionActionCompFormViewModel._GeneralProductionAction['BudgetTypeDefinition'];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === 'string')) {
            let budgetTypeDefinition = that.generalProductionActionCompFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.generalProductionActionCompFormViewModel._GeneralProductionAction.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        that.generalProductionActionCompFormViewModel._GeneralProductionAction.GeneralProductionOutDets = that.generalProductionActionCompFormViewModel.GeneralProductionOutDetsGridList;
        for (let detailItem of that.generalProductionActionCompFormViewModel.GeneralProductionOutDetsGridList) {
            let materialObjID = detailItem['Material'];
            if (materialObjID != null) {
                let material = that.generalProductionActionCompFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.generalProductionActionCompFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType =
                                    that.generalProductionActionCompFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(GeneralProductionActionCompFormViewModel);
        this.MKYS_TeslimAlan.ButtonEnabled = false;
        this.MKYS_TeslimEden.ButtonEnabled = false;
        this.DocumentRecordLogSearch.ReadOnly = false;
        that.DocumentRecordLogDeleteMKYS.ReadOnly = false;
        if (this._GeneralProductionAction.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._GeneralProductionAction.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = '#F0F0F0';
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M14706", "Genel Üretim İşlemi ( Tamamlandı )");

    }


    public onAmountChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.Amount !== event) {
                this._GeneralProductionAction.Amount = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.Description !== event) {
                this._GeneralProductionAction.Description = event;
            }
        }
    }

    public onMaterialChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.Material !== event) {
                this._GeneralProductionAction.Material = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.MKYS_TeslimAlan !== event) {
                this._GeneralProductionAction.MKYS_TeslimAlan = event;
            }
        }
    }
    receiptNumberError: string ="";
    controlOfCancelMKYS: boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        for (let log of this._GeneralProductionAction.DocumentRecordLogs) {
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
                    if (resultMessage === "OK"){
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

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = '#F0F0F0';
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.MKYS_TeslimEden !== event) {
                this._GeneralProductionAction.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.StockActionID !== event) {
                this._GeneralProductionAction.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.Store !== event) {
                this._GeneralProductionAction.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.TransactionDate !== event) {
                this._GeneralProductionAction.TransactionDate = event;
            }
        }
    }

    public onUnitPriceChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.UnitPrice !== event) {
                this._GeneralProductionAction.UnitPrice = event;
            }
        }
    }



    public redirectProperties(): void {
        redirectProperty(this.StockActionID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.TransactionDate, 'Value', this.__ttObject, 'TransactionDate');
        redirectProperty(this.Amount, 'Text', this.__ttObject, 'Amount');
        redirectProperty(this.UnitPrice, 'Text', this.__ttObject, 'UnitPrice');
        redirectProperty(this.MKYS_TeslimAlan, 'Text', this.__ttObject, 'MKYS_TeslimAlan');
        redirectProperty(this.MKYS_TeslimEden, 'Text', this.__ttObject, 'MKYS_TeslimEden');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
    }

    public initFormControls(): void {
        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.TabIndex = 1;
        this.tttabpage2.Text = 'Taşınır Mal İşlem Belgesi';
        this.tttabpage2.Name = 'tttabpage2';

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = 'tttabcontrol1';
        this.tttabcontrol1.TabIndex = 19;

        this.DocumentRecordLogs = new TTVisual.TTGrid();
        this.DocumentRecordLogs.Name = 'DocumentRecordLogs';
        this.DocumentRecordLogs.TabIndex = 20;
        this.DocumentRecordLogs.AllowUserToAddRows = false;
        this.DocumentRecordLogs.AllowUserToDeleteRows = false;
        this.DocumentRecordLogs.Height = 150;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M10469", "Açıklama");
        this.tttabpage1.Name = 'tttabpage1';

        this.DocumentDateTimeDocumentRecordLog = new TTVisual.TTDateTimePickerColumn();
        this.DocumentDateTimeDocumentRecordLog.DataMember = 'DocumentDateTime';
        this.DocumentDateTimeDocumentRecordLog.DisplayIndex = 0;
        this.DocumentDateTimeDocumentRecordLog.HeaderText = i18n("M11748", "Belge Tarihi");
        this.DocumentDateTimeDocumentRecordLog.Name = 'DocumentDateTimeDocumentRecordLog';
        this.DocumentDateTimeDocumentRecordLog.Width = 180;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = 'Description';
        this.Description.TabIndex = 2;

        this.DocumentRecordLogNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DocumentRecordLogNumberDocumentRecordLog.DataMember = 'DocumentRecordLogNumber';
        this.DocumentRecordLogNumberDocumentRecordLog.DisplayIndex = 1;
        this.DocumentRecordLogNumberDocumentRecordLog.HeaderText = i18n("M11743", "Belge Kayıt Numarası");
        this.DocumentRecordLogNumberDocumentRecordLog.Name = 'DocumentRecordLogNumberDocumentRecordLog';
        this.DocumentRecordLogNumberDocumentRecordLog.Width = 120;

        this.UnitPrice = new TTVisual.TTTextBox();
        this.UnitPrice.Required = true;
        this.UnitPrice.BackColor = '#FFE3C6';
        this.UnitPrice.Name = 'UnitPrice';
        this.UnitPrice.TabIndex = 17;

        this.BUDGETYPE = new TTVisual.TTEnumComboBoxColumn();
        this.BUDGETYPE.DataTypeName = 'MKYS_EButceTurEnum';
        this.BUDGETYPE.DataMember = 'BudgeType';
        this.BUDGETYPE.DisplayIndex = 2;
        this.BUDGETYPE.HeaderText = i18n("M12145", "Bütçe Tipi");
        this.BUDGETYPE.Name = 'BUDGETYPE';
        this.BUDGETYPE.ReadOnly = true;
        this.BUDGETYPE.Width = 120;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = '#F0F0F0';
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = 'StockActionID';
        this.StockActionID.TabIndex = 4;

        this.DocumentTransactionTypeDocumentRecordLog = new TTVisual.TTEnumComboBoxColumn();
        this.DocumentTransactionTypeDocumentRecordLog.DataTypeName = 'DocumentTransactionTypeEnum';
        this.DocumentTransactionTypeDocumentRecordLog.DataMember = 'DocumentTransactionType';
        this.DocumentTransactionTypeDocumentRecordLog.DisplayIndex = 3;
        this.DocumentTransactionTypeDocumentRecordLog.HeaderText = i18n("M16834", "İşlem Çeşidi");
        this.DocumentTransactionTypeDocumentRecordLog.Name = 'DocumentTransactionTypeDocumentRecordLog';
        this.DocumentTransactionTypeDocumentRecordLog.Width = 120;

        this.Amount = new TTVisual.TTTextBox();
        this.Amount.Required = true;
        this.Amount.BackColor = '#FFE3C6';
        this.Amount.Name = 'Amount';
        this.Amount.TabIndex = 0;

        this.NumberOfRowsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.NumberOfRowsDocumentRecordLog.DataMember = 'NumberOfRows';
        this.NumberOfRowsDocumentRecordLog.DisplayIndex = 4;
        this.NumberOfRowsDocumentRecordLog.HeaderText = i18n("M17091", "Kalem Adedi");
        this.NumberOfRowsDocumentRecordLog.Name = 'NumberOfRowsDocumentRecordLog';
        this.NumberOfRowsDocumentRecordLog.Width = 120;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = '#FFE3C6';
        this.MKYS_TeslimAlan.Name = 'MKYS_TeslimAlan';
        this.MKYS_TeslimAlan.TabIndex = 136;

        this.ReceiptNumber = new TTVisual.TTTextBoxColumn();
        this.ReceiptNumber.DataMember = 'ReceiptNumber';
        this.ReceiptNumber.DisplayIndex = 5;
        this.ReceiptNumber.HeaderText = 'Ayniyat Makbuz No';
        this.ReceiptNumber.Name = 'ReceiptNumber';
        this.ReceiptNumber.ReadOnly = true;
        this.ReceiptNumber.Width = 120;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = '#FFE3C6';
        this.MKYS_TeslimEden.Name = 'MKYS_TeslimEden';
        this.MKYS_TeslimEden.TabIndex = 138;

        this.DescriptionsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DescriptionsDocumentRecordLog.DataMember = 'Descriptions';
        this.DescriptionsDocumentRecordLog.DisplayIndex = 6;
        this.DescriptionsDocumentRecordLog.HeaderText = i18n("M10483", "Açıklamalar");
        this.DescriptionsDocumentRecordLog.Name = 'DescriptionsDocumentRecordLog';
        this.DescriptionsDocumentRecordLog.Width = 120;

        this.labelUnitPrice = new TTVisual.TTLabel();
        this.labelUnitPrice.Text = i18n("M11860", "Birim Fiyatı");
        this.labelUnitPrice.Name = 'labelUnitPrice';
        this.labelUnitPrice.TabIndex = 18;

        this.SendToMKYS = new TTVisual.TTButton();
        this.SendToMKYS.Text = 'MKYS\'ye Gönder';
        this.SendToMKYS.Name = 'SendToMKYS';
        this.SendToMKYS.TabIndex = 126;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = 'labelStore';
        this.labelStore.TabIndex = 16;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = 'MainStoreList';
        this.Store.Name = 'Store';
        this.Store.TabIndex = 15;

        this.labelMaterial = new TTVisual.TTLabel();
        this.labelMaterial.Text = i18n("M23948", "Üretilecek Malzeme");
        this.labelMaterial.Name = 'labelMaterial';
        this.labelMaterial.TabIndex = 10;

        this.Material = new TTVisual.TTObjectListBox();
        this.Material.Required = true;
        this.Material.ListFilterExpression = 'IsOldMaterial = 0';
        this.Material.ListDefName = 'ConsumableMaterialDefinitionList';
        this.Material.Name = 'Material';
        this.Material.TabIndex = 9;

        this.GeneralProductionOutDets = new TTVisual.TTGrid();
        this.GeneralProductionOutDets.Name = 'GeneralProductionOutDets';
        this.GeneralProductionOutDets.TabIndex = 8;
        this.GeneralProductionOutDets.AllowUserToAddRows = false;
        this.GeneralProductionOutDets.Height = 350;
        this.GeneralProductionOutDets.AllowUserToDeleteRows = false;

        this.MaterialDet = new TTVisual.TTListBoxColumn();
        this.MaterialDet.ListDefName = 'MaterialListDefinition';
        this.MaterialDet.ListFilterExpression = 'IsOldMaterial = 0';
        this.MaterialDet.DataMember = 'Material';
        this.MaterialDet.AutoCompleteDialogHeight = '60%';
        this.MaterialDet.AutoCompleteDialogWidth = '90%';
        this.MaterialDet.Required = true;
        this.MaterialDet.DisplayIndex = 0;
        this.MaterialDet.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialDet.Name = 'MaterialDet';
        this.MaterialDet.Width = 300;

        this.AmountGeneralProductionOutDet = new TTVisual.TTTextBoxColumn();
        this.AmountGeneralProductionOutDet.DataMember = 'Amount';
        this.AmountGeneralProductionOutDet.Required = true;
        this.AmountGeneralProductionOutDet.DisplayIndex = 1;
        this.AmountGeneralProductionOutDet.HeaderText = i18n("M19030", "Miktar");
        this.AmountGeneralProductionOutDet.Name = 'AmountGeneralProductionOutDet';
        this.AmountGeneralProductionOutDet.Width = 120;
        this.AmountGeneralProductionOutDet.IsNumeric = true;


        this.DistributionType = new TTVisual.TTListDefComboBoxColumn();
        this.DistributionType.ListDefName = 'DistributionTypeList';
        this.DistributionType.DataMember = 'Material.DistributionTypeName';
        this.DistributionType.DisplayIndex = 2;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = 'DistributionType';
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 120;

        this.Exiting = new TTVisual.TTTextBoxColumn();
        this.Exiting.DataMember = 'StoreStock';
        this.Exiting.DisplayIndex = 3;
        this.Exiting.HeaderText = i18n("M18957", "Mevcut");
        this.Exiting.Name = 'Exiting';
        this.Exiting.Width = 120;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = 'labelTransactionDate';
        this.labelTransactionDate.TabIndex = 7;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = '#F0F0F0';
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = 'TransactionDate';
        this.TransactionDate.TabIndex = 6;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = 'labelStockActionID';
        this.labelStockActionID.TabIndex = 5;

        this.labelAmount = new TTVisual.TTLabel();
        this.labelAmount.Text = i18n("M19030", "Miktar");
        this.labelAmount.Name = 'labelAmount';
        this.labelAmount.TabIndex = 1;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M23960", "Üretim Esnasında Tüketilen Malzemler");
        this.ttlabel7.Name = 'ttlabel7';
        this.ttlabel7.TabIndex = 10;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = 'labelMKYS_TeslimEden';
        this.labelMKYS_TeslimEden.TabIndex = 139;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = 'labelMKYS_TeslimAlan';
        this.labelMKYS_TeslimAlan.TabIndex = 137;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = 'TA';
        this.TTTeslimAlanButon.Name = 'TTTeslimAlanButon';
        this.TTTeslimAlanButon.TabIndex = 120;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = 'TE';
        this.TTTeslimEdenButon.Name = 'TTTeslimEdenButon';
        this.TTTeslimEdenButon.TabIndex = 121;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.ReadOnly = true;
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.BackColor = '#FFE3C6';
        this.BudgetTypeDefinition.Name = 'BudgetTypeDefinition';
        this.BudgetTypeDefinition.TabIndex = 131;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = '10%';
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = '20%';

        this.DocumentRecordLogSearch = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogSearch.Text = 'MKYS Log Sorgula';
        this.DocumentRecordLogSearch.Name = 'GetLogFromMkys';

        this.DocumentRecordLogDeleteMKYS = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogDeleteMKYS.Text = 'MKYS Kayıt Sil';
        this.DocumentRecordLogDeleteMKYS.Name = 'DeleteMkysRow';

        this.DocumentRecordLogsColumns = [this.DocumentDateTimeDocumentRecordLog, this.DocumentRecordLogNumberDocumentRecordLog, this.BUDGETYPE,
        this.DocumentTransactionTypeDocumentRecordLog, this.NumberOfRowsDocumentRecordLog, this.ReceiptNumber, this.DescriptionsDocumentRecordLog,this.DocumentRecordLogDeleteMKYS, this.DocumentRecordLogSearch];
        this.GeneralProductionOutDetsColumns = [this.MaterialDet, this.AmountGeneralProductionOutDet, this.DistributionType, this.Exiting];
        this.tttabpage2.Controls = [this.DocumentRecordLogs];
        this.tttabcontrol1.Controls = [this.tttabpage2, this.tttabpage1];
        this.tttabpage1.Controls = [this.Description];
        this.Controls = [this.tttabpage2, this.tttabcontrol1, this.BudgetTypeDefinition, this.DocumentRecordLogs, this.tttabpage1, this.DocumentDateTimeDocumentRecordLog,
        this.Description, this.DocumentRecordLogNumberDocumentRecordLog, this.UnitPrice, this.BUDGETYPE, this.StockActionID, this.DocumentTransactionTypeDocumentRecordLog,
        this.Amount, this.NumberOfRowsDocumentRecordLog, this.MKYS_TeslimAlan, this.ReceiptNumber, this.MKYS_TeslimEden, this.DescriptionsDocumentRecordLog, this.labelUnitPrice,
        this.SendToMKYS, this.labelStore, this.Store, this.labelMaterial, this.Material, this.GeneralProductionOutDets, this.MaterialDet, this.AmountGeneralProductionOutDet,
        this.DistributionType, this.Exiting, this.labelTransactionDate, this.TransactionDate, this.labelStockActionID, this.labelAmount, this.ttlabel7, this.labelMKYS_TeslimEden,
        this.labelMKYS_TeslimAlan, this.TTTeslimAlanButon, this.TTTeslimEdenButon,this.DocumentRecordLogDeleteMKYS, this.DocumentRecordLogSearch];


    }


}
