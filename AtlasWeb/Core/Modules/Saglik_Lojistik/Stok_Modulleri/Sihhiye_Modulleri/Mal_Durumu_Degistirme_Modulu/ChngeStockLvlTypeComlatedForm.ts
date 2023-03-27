//$BB6D4A34
import { Component, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { ChngeStockLvlTypeComlatedFormViewModel } from './ChngeStockLvlTypeComlatedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { StockActionService, DocumentRecordLogReceiptNumber_Input } from "ObjectClassService/StockActionService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ChangeStockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { ChangeStockLevelTypeForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Mal_Durumu_Degistirme_Modulu/ChangeStockLevelTypeForm";
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ChangeStockLevelTypeDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import Exception from 'app/NebulaClient/System/Exception';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { UsernamePwdBox } from 'NebulaClient/Visual/UsernamePwdBox';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { ModalActionResult } from "Fw/Models/ModalInfo";
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';

@Component({
    selector: 'ChngeStockLvlTypeComlatedForm',
    templateUrl: './ChngeStockLvlTypeComlatedForm.html',
    providers: [MessageService]
})
export class ChngeStockLvlTypeComlatedForm extends ChangeStockLevelTypeForm implements OnInit {
    BUDGETYPE: TTVisual.ITTEnumComboBoxColumn;
    DocumentDateTimeDocumentRecordLog: TTVisual.ITTDateTimePickerColumn;
    DocumentRecordLogNumberDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogs: TTVisual.ITTGrid;
    DocumentRecordLogTab: TTVisual.ITTTabPage;
    DocumentTransactionTypeDocumentRecordLog: TTVisual.ITTEnumComboBoxColumn;
    ReceiptNumber: TTVisual.ITTTextBoxColumn;
    SendToMKYS: TTVisual.ITTButton;
    SubjectDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    tttabcontrol1: TTVisual.ITTTabControl;
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;
    public DocumentRecordLogsColumns = [];
    public MaterialDetailsColumns = [];
    public chngeStockLvlTypeComlatedFormViewModel: ChngeStockLvlTypeComlatedFormViewModel = new ChngeStockLvlTypeComlatedFormViewModel();
    public get _ChangeStockLevelType(): ChangeStockLevelType {
        return this._TTObject as ChangeStockLevelType;
    }
    private ChngeStockLvlTypeComlatedForm_DocumentUrl: string = '/api/ChangeStockLevelTypeService/ChngeStockLvlTypeComlatedForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected objectContextService: ObjectContextService,
        protected changeDetectorRef: ChangeDetectorRef,
        protected reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super(httpService, messageService, objectContextService, changeDetectorRef, reportService, ngZone);
        this._DocumentServiceUrl = this.ChngeStockLvlTypeComlatedForm_DocumentUrl;
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
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ChangeStockLevelType.ObjectID.toString());
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
    receiptNumberError: string ="";
    controlOfCancelMKYS: boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        for (let log of this._ChangeStockLevelType.DocumentRecordLogs) {
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
                    let resultMessage: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '',documentLog.DocumentRecordLogNumber + " Tif numaralı fişi silmek istediğinizden emin misiniz?");
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


    public showLoadPanel:boolean = false;
    public LoadPanelMessage: string = "MKYS İşlemi yapılıyor Lütfen Bekleyiniz...";

    public async SendToMKYS_Click(): Promise<void> {
        //-TODO İlaydax
        this.mkysSonucMesaj = '';
        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result == DialogResult.OK) {
            this.showLoadPanel=true;
            let params = <any>(<ModalActionResult>result).Param;
            if (this._ChangeStockLevelType.CurrentStateDefID.toString() === ChangeStockLevelType.ChangeStockLevelTypeStates.Completed.id) {
                for (let log of this._ChangeStockLevelType.DocumentRecordLogs) {
                    if (log.ReceiptNumber == null) {
                        this.mkysSonucMesaj += await StockActionService.SendMKYSForOutputDocumentTS(this._ChangeStockLevelType, params.password);
                    }
                    if (log.ReceiptNumber != null)
                        this.mkysSonucMesaj += log.ReceiptNumber.toString() + " Ayniyat numarası ile MKYSye kaydolmuştur.";
                }
            }
            //-TODO İlaydax
            if (this._ChangeStockLevelType.CurrentStateDefID.toString() === ChangeStockLevelType.ChangeStockLevelTypeStates.Cancel.id) {
                for (let log of this._ChangeStockLevelType.DocumentRecordLogs) {
                    if (log.ReceiptNumber != null) {
                        this.mkysSonucMesaj += await StockActionService.SendDeleteMessageToMkysTS(this._ChangeStockLevelType, true, log.ReceiptNumber.Value, params.password);
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

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChangeStockLevelType();
        this.chngeStockLvlTypeComlatedFormViewModel = new ChngeStockLvlTypeComlatedFormViewModel();
        this._ViewModel = this.chngeStockLvlTypeComlatedFormViewModel;
        this.chngeStockLvlTypeComlatedFormViewModel._ChangeStockLevelType = this._TTObject as ChangeStockLevelType;
        this.chngeStockLvlTypeComlatedFormViewModel._ChangeStockLevelType.DocumentRecordLogs = new Array<DocumentRecordLog>();
        this.chngeStockLvlTypeComlatedFormViewModel._ChangeStockLevelType.ChangeStockLevelTypeDetails = new Array<ChangeStockLevelTypeDetail>();
        this.chngeStockLvlTypeComlatedFormViewModel._ChangeStockLevelType.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.chngeStockLvlTypeComlatedFormViewModel._ChangeStockLevelType.Store = new Store();
    }

    protected loadViewModel() {
        let that = this;
        that.chngeStockLvlTypeComlatedFormViewModel = this._ViewModel;
        that._TTObject = this.chngeStockLvlTypeComlatedFormViewModel._ChangeStockLevelType;
        if (this.chngeStockLvlTypeComlatedFormViewModel == null)
            this.chngeStockLvlTypeComlatedFormViewModel = new ChngeStockLvlTypeComlatedFormViewModel();
        if (this.chngeStockLvlTypeComlatedFormViewModel._ChangeStockLevelType == null)
            this.chngeStockLvlTypeComlatedFormViewModel._ChangeStockLevelType = new ChangeStockLevelType();
        that.chngeStockLvlTypeComlatedFormViewModel._ChangeStockLevelType.DocumentRecordLogs = that.chngeStockLvlTypeComlatedFormViewModel.DocumentRecordLogsGridList;
        for (let detailItem of that.chngeStockLvlTypeComlatedFormViewModel.DocumentRecordLogsGridList) {
        }
        that.chngeStockLvlTypeComlatedFormViewModel._ChangeStockLevelType.ChangeStockLevelTypeDetails = that.chngeStockLvlTypeComlatedFormViewModel.MaterialDetailsGridList;
        for (let detailItem of that.chngeStockLvlTypeComlatedFormViewModel.MaterialDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.chngeStockLvlTypeComlatedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.chngeStockLvlTypeComlatedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.chngeStockLvlTypeComlatedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.chngeStockLvlTypeComlatedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        let budgetTypeDefinitionObjectID = that.chngeStockLvlTypeComlatedFormViewModel._ChangeStockLevelType["BudgetTypeDefinition"];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === 'string')) {
            let budgetTypeDefinition = that.chngeStockLvlTypeComlatedFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.chngeStockLvlTypeComlatedFormViewModel._ChangeStockLevelType.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.chngeStockLvlTypeComlatedFormViewModel._ChangeStockLevelType["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.chngeStockLvlTypeComlatedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.chngeStockLvlTypeComlatedFormViewModel._ChangeStockLevelType.Store = store;
            }
        }
    }

    public getIsCompleted(){
        return true;
    }


    async ngOnInit() {
        let that = this;
        that.DocumentRecordLogDeleteMKYS.ReadOnly = false;
        await this.load(ChngeStockLvlTypeComlatedFormViewModel);
        this.FormCaption = i18n("M16242", "İhtiyaç Fazlası Bildirim ( Tamamlandı )");
  
    }


    public onBudgetTypeDefinitionChanged(event): void {
        if (event != null) {
            if (this._ChangeStockLevelType != null && this._ChangeStockLevelType.BudgetTypeDefinition != event) {
                this._ChangeStockLevelType.BudgetTypeDefinition = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ChangeStockLevelType != null && this._ChangeStockLevelType.Description != event) {
                this._ChangeStockLevelType.Description = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ChangeStockLevelType != null && this._ChangeStockLevelType.StockActionID != event) {
                this._ChangeStockLevelType.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ChangeStockLevelType != null && this._ChangeStockLevelType.Store != event) {
                this._ChangeStockLevelType.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ChangeStockLevelType != null && this._ChangeStockLevelType.TransactionDate != event) {
                this._ChangeStockLevelType.TransactionDate = event;
            }
        }
    }

    onRowInsertting(data: ChangeStockLevelTypeDetail) {
    }

    onCellContentClicked(data: any) {
    }

    async initNewRow(data: any) {
    }

    onSelectionChange(data: any) {
    }
    onRowInserting(data: any) { }

    MaterialDetails_CellValueChangedEmitted(data: any) {
        if (data && this.MaterialDetails_CellValueChanged && data.Row && data.Column) {
            this.MaterialDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.SendToMKYS = new TTVisual.TTButton();
        this.SendToMKYS.Text = "MKYS'ye Gönder";
        this.SendToMKYS.Name = "SendToMKYS";
        this.SendToMKYS.TabIndex = 133;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M10469", "Açıklama");
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 13;


        this.DocumentRecordLogTab = new TTVisual.TTTabPage();
        this.DocumentRecordLogTab.DisplayIndex = 1;
        this.DocumentRecordLogTab.TabIndex = 1;
        this.DocumentRecordLogTab.Text = "Taşınır Mal İşlem Belgesi";
        this.DocumentRecordLogTab.Name = "DocumentRecordLogTab";


        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 12;



        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.DocumentRecordLogs = new TTVisual.TTGrid();
        this.DocumentRecordLogs.ReadOnly = true;
        this.DocumentRecordLogs.Name = "DocumentRecordLogs";
        this.DocumentRecordLogs.TabIndex = 0;
        this.DocumentRecordLogs.Height = 350;
        this.DocumentRecordLogs.AllowUserToDeleteRows = false;
        this.DocumentRecordLogs.AllowUserToAddRows = false;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M10896", "Ana Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 11;

        this.DocumentDateTimeDocumentRecordLog = new TTVisual.TTDateTimePickerColumn();
        this.DocumentDateTimeDocumentRecordLog.DataMember = "DocumentDateTime";
        this.DocumentDateTimeDocumentRecordLog.DisplayIndex = 0;
        this.DocumentDateTimeDocumentRecordLog.HeaderText = i18n("M11748", "Belge Tarihi");
        this.DocumentDateTimeDocumentRecordLog.Name = "DocumentDateTimeDocumentRecordLog";
        this.DocumentDateTimeDocumentRecordLog.Width = 180;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 10;

        this.DocumentRecordLogNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DocumentRecordLogNumberDocumentRecordLog.DataMember = "DocumentRecordLogNumber";
        this.DocumentRecordLogNumberDocumentRecordLog.DisplayIndex = 1;
        this.DocumentRecordLogNumberDocumentRecordLog.HeaderText = i18n("M11734", "Belge  Numarası");
        this.DocumentRecordLogNumberDocumentRecordLog.Name = "DocumentRecordLogNumberDocumentRecordLog";
        this.DocumentRecordLogNumberDocumentRecordLog.Width = 120;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.CustomFormat = "";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.DocumentTransactionTypeDocumentRecordLog = new TTVisual.TTEnumComboBoxColumn();
        this.DocumentTransactionTypeDocumentRecordLog.DataTypeName = "DocumentTransactionTypeEnum";
        this.DocumentTransactionTypeDocumentRecordLog.DataMember = "DocumentTransactionType";
        this.DocumentTransactionTypeDocumentRecordLog.DisplayIndex = 2;
        this.DocumentTransactionTypeDocumentRecordLog.HeaderText = i18n("M16834", "İşlem Çeşidi");
        this.DocumentTransactionTypeDocumentRecordLog.Name = "DocumentTransactionTypeDocumentRecordLog";
        this.DocumentTransactionTypeDocumentRecordLog.Width = 120;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.BackColor = "#DCDCDC";
        this.labelStockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelStockActionID.ForeColor = "#000000";
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 5;

        this.BUDGETYPE = new TTVisual.TTEnumComboBoxColumn();
        this.BUDGETYPE.DataTypeName = "MKYS_EButceTurEnum";
        this.BUDGETYPE.DataMember = "BudgeType";
        this.BUDGETYPE.DisplayIndex = 3;
        this.BUDGETYPE.HeaderText = i18n("M12145", "Bütçe Tipi");
        this.BUDGETYPE.Name = "BUDGETYPE";
        this.BUDGETYPE.ReadOnly = true;
        this.BUDGETYPE.Width = 120;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.BackColor = "#DCDCDC";
        this.labelTransactionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelTransactionDate.ForeColor = "#000000";
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 9;

        this.SubjectDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.SubjectDocumentRecordLog.DataMember = "Subject";
        this.SubjectDocumentRecordLog.DisplayIndex = 4;
        this.SubjectDocumentRecordLog.HeaderText = i18n("M14805", "Giriş ve Çıkış Nedenleri");
        this.SubjectDocumentRecordLog.Name = "SubjectDocumentRecordLog";
        this.SubjectDocumentRecordLog.Width = 120;

        this.MaterialDetails = new TTVisual.TTGrid();
        this.MaterialDetails.Required = true;
        this.MaterialDetails.Name = "MaterialDetails";
        this.MaterialDetails.TabIndex = 0;
        this.MaterialDetails.Height = 350;
        this.MaterialDetails.AllowUserToAddRows = false;
        this.MaterialDetails.AllowUserToDeleteRows = false;

        this.ReceiptNumber = new TTVisual.TTTextBoxColumn();
        this.ReceiptNumber.DataMember = "ReceiptNumber";
        this.ReceiptNumber.DisplayIndex = 5;
        this.ReceiptNumber.HeaderText = "Ayniyat Makbuz No";
        this.ReceiptNumber.Name = "ReceiptNumber";
        this.ReceiptNumber.ReadOnly = true;
        this.ReceiptNumber.Width = 140;

        this.MaterialStockActionDetail = new TTVisual.TTListBoxColumn();
        this.MaterialStockActionDetail.ListDefName = "MaterialListDefinition";
        this.MaterialStockActionDetail.DataMember = "Material";
        this.MaterialStockActionDetail.AutoCompleteDialogHeight = "60%";
        this.MaterialStockActionDetail.AutoCompleteDialogWidth = "50%";
        this.MaterialStockActionDetail.DisplayIndex = 0;
        this.MaterialStockActionDetail.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialStockActionDetail.Name = "MaterialStockActionDetail";
        this.MaterialStockActionDetail.Width = 500;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "Material.DistributionTypeName";
        this.DistributionType.DisplayIndex = 1;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 140;

        this.StoreStock = new TTVisual.TTTextBoxColumn();
        this.StoreStock.DataMember = "StoreStock";
        this.StoreStock.DisplayIndex = 2;
        this.StoreStock.HeaderText = i18n("M22360", "Stok Miktarı");
        this.StoreStock.Name = "StoreStock";
        this.StoreStock.ReadOnly = true;
        this.StoreStock.Width = 120;

        this.MaterialTabPanel = new TTVisual.TTTabPage();
        this.MaterialTabPanel.DisplayIndex = 0;
        this.MaterialTabPanel.TabIndex = 0;
        this.MaterialTabPanel.Text = "Taşınır Malın";
        this.MaterialTabPanel.Name = "MaterialTabPanel";

        this.AmountStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.AmountStockActionDetailIn.DataMember = "Amount";
        this.AmountStockActionDetailIn.Format = "#,###.####";
        this.AmountStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountStockActionDetailIn.DisplayIndex = 3;
        this.AmountStockActionDetailIn.HeaderText = i18n("M19030", "Miktar");
        this.AmountStockActionDetailIn.Name = "AmountStockActionDetailIn";
        this.AmountStockActionDetailIn.Width = 120;
        this.AmountStockActionDetailIn.IsNumeric = true;


        this.MaterialTabPanel = new TTVisual.TTTabPage();
        this.MaterialTabPanel.DisplayIndex = 0;
        this.MaterialTabPanel.TabIndex = 0;
        this.MaterialTabPanel.Text = "Taşınır Malın";
        this.MaterialTabPanel.Name = "MaterialTabPanel";

        this.StockLevelTypeStockActionDetailIn = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeStockActionDetailIn.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeStockActionDetailIn.DataMember = "StockLevelType";
        this.StockLevelTypeStockActionDetailIn.Required = true;
        this.StockLevelTypeStockActionDetailIn.DisplayIndex = 4;
        this.StockLevelTypeStockActionDetailIn.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeStockActionDetailIn.Name = "StockLevelTypeStockActionDetailIn";
        this.StockLevelTypeStockActionDetailIn.ReadOnly = true;
        this.StockLevelTypeStockActionDetailIn.Width = 140;

        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = i18n("M12146", "Bütçe Türü");
        this.labelBudgetTypeDefinition.Name = "labelBudgetTypeDefinition";
        this.labelBudgetTypeDefinition.TabIndex = 15;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.Required = true;
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.BackColor = '#FFE3C6';
        this.BudgetTypeDefinition.Name = "BudgetTypeDefinition";
        this.BudgetTypeDefinition.TabIndex = 14;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = "10%";
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = "20%";

        this.DocumentRecordLogDeleteMKYS = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogDeleteMKYS.Text = 'MKYS Kayıt Sil';
        this.DocumentRecordLogDeleteMKYS.Name = 'DeleteMkysRow';

        this.DocumentRecordLogsColumns = [this.DocumentDateTimeDocumentRecordLog, this.DocumentRecordLogNumberDocumentRecordLog, this.DocumentTransactionTypeDocumentRecordLog, this.BUDGETYPE, this.SubjectDocumentRecordLog, this.ReceiptNumber,this.DocumentRecordLogDeleteMKYS];
        this.MaterialDetailsColumns = [this.MaterialStockActionDetail, this.DistributionType, this.StoreStock, this.AmountStockActionDetailIn, this.StockLevelTypeStockActionDetailIn];
        // this.DocumentRecordLogTab.Controls = [this.DocumentRecordLogs];
        // this.tttabcontrol1.Controls = [this.DocumentRecordLogTab, this.MaterialTabPanel];
        this.MaterialTabPanel.Controls = [this.MaterialDetails];
        this.Controls = [this.DocumentRecordLogs, this.MaterialTabPanel, this.DocumentDateTimeDocumentRecordLog, this.MaterialDetails, this.DocumentRecordLogNumberDocumentRecordLog, this.MaterialStockActionDetail, this.DocumentTransactionTypeDocumentRecordLog, this.DistributionType, this.BUDGETYPE, this.StoreStock, this.SubjectDocumentRecordLog, this.AmountStockActionDetailIn, this.ReceiptNumber, this.StockLevelTypeStockActionDetailIn, this.SendToMKYS, this.Description, this.StockActionID, this.labelBudgetTypeDefinition, this.BudgetTypeDefinition, this.labelDescription, this.labelStore, this.Store, this.TransactionDate, this.labelStockActionID, this.labelTransactionDate,this.DocumentRecordLogDeleteMKYS];


    }


}
