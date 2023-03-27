//$6292655B
import { Component, OnInit, NgZone } from '@angular/core';
import { ExtendExpDateCompletedFormViewModel } from './ExtendExpDateCompletedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseExtendExpDateForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Miad_Uzatim_Modulu/BaseExtendExpDateForm";
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { ExtendExpirationDate } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { ExtendExpirationDateDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
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
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';

@Component({
    selector: 'ExtendExpDateCompletedForm',
    templateUrl: './ExtendExpDateCompletedForm.html',
    providers: [MessageService]
})
export class ExtendExpDateCompletedForm extends BaseExtendExpDateForm implements OnInit {
    BUDGETYPE: TTVisual.ITTEnumComboBoxColumn;
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
    tttabpage1: TTVisual.ITTTabPage;
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;
    DocumentRecordLogSearch: TTVisual.ITTButtonColumn;
    
    public DocumentRecordLogsColumns = [];
    public StockActionSignDetailsColumns = [];
    public extendExpDateCompletedFormViewModel: ExtendExpDateCompletedFormViewModel = new ExtendExpDateCompletedFormViewModel();
    public get _ExtendExpirationDate(): ExtendExpirationDate {
        return this._TTObject as ExtendExpirationDate;
    }
    private ExtendExpDateCompletedForm_DocumentUrl: string = '/api/ExtendExpirationDateService/ExtendExpDateCompletedForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone,protected objectContextService: ObjectContextService) {
        super(httpService, messageService, ngZone,objectContextService);
        this._DocumentServiceUrl = this.ExtendExpDateCompletedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }
    protected async PreScript() {
        super.PreScript();
    }

    // ***** Method declarations start *****

    public mkysSonucMesaj: string;
    popupVisible: boolean = false;
    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        this.SendToMKYS.ReadOnly = false;
    }

    public async prepareDocument_Click(): Promise<void> {
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ExtendExpirationDate.ObjectID.toString());
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
    //dx-data-grid çevirme
    public getIsReadOnly() {
        return true;
    }
    //dx-data-grid çevirme son
    public showLoadPanel:boolean = false;
    public LoadPanelMessage: string = "MKYS İşlemi yapılıyor Lütfen Bekleyiniz...";

    public async SendToMKYS_Click(): Promise<void> {
        this.mkysSonucMesaj = '';
        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result == DialogResult.OK) {
            this.showLoadPanel =true;
            let params = <any>(<ModalActionResult>result).Param;
            let documetrecords: Array<DocumentRecordLog> = await this._ExtendExpirationDate.DocumentRecordLogs.sort((a, b) => a.DocumentRecordLogNumber - b.DocumentRecordLogNumber);
            for (let log_1 of documetrecords) {
                if (log_1.DocumentTransactionType === DocumentTransactionTypeEnum.Out) {
                    if (log_1.ReceiptNumber == null) {
                        this.mkysSonucMesaj += await StockActionService.SendMKYSForOutputDocumentTS(this._ExtendExpirationDate, params.password);
                        this.mkysSonucMesaj += log_1.ReceiptNumber.toString() + " Ayniyat numarası ile MKYSye kaydolmuştur.";
                    }
                }
            }

            this.popupVisible = true;
            for (let log_2 of documetrecords) {
                if (log_2.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                    if (log_2.ReceiptNumber == null) {
                        let resultFor = await UsernamePwdBox.Show(true);
                        this.mkysSonucMesaj += await StockActionService.SendMKYSForInputDocumentTS(this._ExtendExpirationDate, params.password);
                    }
                    if (log_2.ReceiptNumber != null)
                        this.mkysSonucMesaj += log_2.ReceiptNumber.toString() + " Ayniyat numarası ile MKYSye kaydolmuştur.";
                }
            }
            this.showLoadPanel =false;
            if (String.isNullOrEmpty(this.mkysSonucMesaj) == false)
                this.popupVisible = true;
        }
    }

    public async SendUpdateMessageToMKYS_Click(): Promise<void> {

        this.mkysSonucMesaj = '';
        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result == DialogResult.OK) {
            let params = <any>(<ModalActionResult>result).Param;
            this.mkysSonucMesaj += await StockActionService.SendUpdateMessageToMKYSTS(this._ExtendExpirationDate, params.password);
        }
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);

    }
    onSelectionChangeDocumentRecordLogs(data: any) { }
    onDocumentRecordLogsRowInserting(data: any) { }
    DocumentRecordLogs_CellValueChangedEmitted(data: any) { }
    initDocumentRecordLogsNewRow(data: any) { }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ExtendExpirationDate();
        this.extendExpDateCompletedFormViewModel = new ExtendExpDateCompletedFormViewModel();
        this._ViewModel = this.extendExpDateCompletedFormViewModel;
        this.extendExpDateCompletedFormViewModel._ExtendExpirationDate = this._TTObject as ExtendExpirationDate;
        this.extendExpDateCompletedFormViewModel._ExtendExpirationDate.DocumentRecordLogs = new Array<DocumentRecordLog>();
        this.extendExpDateCompletedFormViewModel._ExtendExpirationDate.Store = new Store();
        this.extendExpDateCompletedFormViewModel._ExtendExpirationDate.ExtendExpirationDateDetails = new Array<ExtendExpirationDateDetail>();
        this.extendExpDateCompletedFormViewModel._ExtendExpirationDate.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.extendExpDateCompletedFormViewModel = this._ViewModel as ExtendExpDateCompletedFormViewModel;
        that._TTObject = this.extendExpDateCompletedFormViewModel._ExtendExpirationDate;
        that.extendExpDateCompletedFormViewModel = this._ViewModel;
        if (this.extendExpDateCompletedFormViewModel == null)
            this.extendExpDateCompletedFormViewModel = new ExtendExpDateCompletedFormViewModel();
        if (this.extendExpDateCompletedFormViewModel._ExtendExpirationDate == null)
            this.extendExpDateCompletedFormViewModel._ExtendExpirationDate = new ExtendExpirationDate();
        that.extendExpDateCompletedFormViewModel._ExtendExpirationDate.DocumentRecordLogs = that.extendExpDateCompletedFormViewModel.DocumentRecordLogsGridList;
        for (let detailItem of that.extendExpDateCompletedFormViewModel.DocumentRecordLogsGridList) {
        }
        let storeObjectID = that.extendExpDateCompletedFormViewModel._ExtendExpirationDate["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.extendExpDateCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.extendExpDateCompletedFormViewModel._ExtendExpirationDate.Store = store;
            }
        }
        that.extendExpDateCompletedFormViewModel._ExtendExpirationDate.ExtendExpirationDateDetails = that.extendExpDateCompletedFormViewModel.ExtendExpirationDateDetailsGridList;
        for (let detailItem of that.extendExpDateCompletedFormViewModel.ExtendExpirationDateDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.extendExpDateCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.extendExpDateCompletedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.extendExpDateCompletedFormViewModel._ExtendExpirationDate.StockActionSignDetails = that.extendExpDateCompletedFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.extendExpDateCompletedFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.extendExpDateCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(ExtendExpDateCompletedFormViewModel);
        that.DocumentRecordLogDeleteMKYS.ReadOnly = false;
        this.MKYS_TeslimAlan.ButtonEnabled = false;
        this.MKYS_TeslimEden.ButtonEnabled = false;
        this.DocumentRecordLogSearch.ReadOnly = false;
        if (this._ExtendExpirationDate.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ExtendExpirationDate.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M19018", "Miad Güncelleme İşlemi ( Tamamlandı )");
  
    }
    receiptNumberError: string ="";
    controlOfCancelMKYS: boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        for (let log of this._ExtendExpirationDate.DocumentRecordLogs) {
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

    public onAdditionalDocumentCountChanged(event): void {
        if (event != null) {
            if (this._ExtendExpirationDate != null && this._ExtendExpirationDate.AdditionalDocumentCount != event) {
                this._ExtendExpirationDate.AdditionalDocumentCount = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ExtendExpirationDate != null && this._ExtendExpirationDate.Description != event) {
                this._ExtendExpirationDate.Description = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ExtendExpirationDate.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._ExtendExpirationDate != null && this._ExtendExpirationDate.MKYS_TeslimAlan != event) {
                this._ExtendExpirationDate.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ExtendExpirationDate.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._ExtendExpirationDate != null && this._ExtendExpirationDate.MKYS_TeslimEden != event) {
                this._ExtendExpirationDate.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ExtendExpirationDate != null && this._ExtendExpirationDate.StockActionID != event) {
                this._ExtendExpirationDate.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ExtendExpirationDate != null && this._ExtendExpirationDate.Store != event) {
                this._ExtendExpirationDate.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ExtendExpirationDate != null && this._ExtendExpirationDate.TransactionDate != event) {
                this._ExtendExpirationDate.TransactionDate = event;
            }
        }
    }

    ExtendExpirationDateDetails_CellValueChangedEmitted(data: any) {
        if (data && this.ExtendExpirationDateDetails_CellValueChanged && data.Row && data.Column) {
            this.ExtendExpirationDateDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    public async ExtendExpirationDateDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.ExtendExpirationDateDetails_CellValueChanged(data, rowIndex, columnIndex);
    }

    onSelectionChange(data: any) {
    }
    onRowInsertting(data: ExtendExpirationDateDetail) {
    }
    onCellContentClicked(data: any) {
    }
    async initNewRow(data: any) {
    }
    onRowInserting(data: any) {
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 2;
        this.tttabpage1.TabIndex = 2;
        this.tttabpage1.Text = "Taşınır Mal İşlem Belgeleri";
        this.tttabpage1.Name = "tttabpage1";

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M12615", "Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 123;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.DocumentRecordLogTab = new TTVisual.TTTabPage();
        this.DocumentRecordLogTab.DisplayIndex = 1;
        this.DocumentRecordLogTab.TabIndex = 1;
        this.DocumentRecordLogTab.Text = "Taşınır Mal İşlem Belgeleri";
        this.DocumentRecordLogTab.Name = "DocumentRecordLogTab";

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 122;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.DocumentRecordLogs = new TTVisual.TTGrid();
        this.DocumentRecordLogs.Name = "DocumentRecordLogs";
        this.DocumentRecordLogs.TabIndex = 0;
        this.DocumentRecordLogs.Height = 350;
        this.DocumentRecordLogs.AllowUserToAddRows = false;
        this.DocumentRecordLogs.AllowUserToDeleteRows = false;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 4;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.DocumentDateTimeDocumentRecordLog = new TTVisual.TTDateTimePickerColumn();
        this.DocumentDateTimeDocumentRecordLog.DataMember = "DocumentDateTime";
        this.DocumentDateTimeDocumentRecordLog.DisplayIndex = 0;
        this.DocumentDateTimeDocumentRecordLog.HeaderText = i18n("M11748", "Belge Tarihi");
        this.DocumentDateTimeDocumentRecordLog.Name = "DocumentDateTimeDocumentRecordLog";
        this.DocumentDateTimeDocumentRecordLog.Width = 150;

        this.MaterialTabPage = new TTVisual.TTTabPage();
        this.MaterialTabPage.DisplayIndex = 0;
        this.MaterialTabPage.BackColor = "#FFFFFF";
        this.MaterialTabPage.TabIndex = 0;
        this.MaterialTabPage.Text = "Taşınır Malın";
        this.MaterialTabPage.Name = "MaterialTabPage";

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 118;

        this.DocumentRecordLogNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DocumentRecordLogNumberDocumentRecordLog.DataMember = "DocumentRecordLogNumber";
        this.DocumentRecordLogNumberDocumentRecordLog.DisplayIndex = 1;
        this.DocumentRecordLogNumberDocumentRecordLog.HeaderText = i18n("M11743", "Belge Kayıt Numarası");
        this.DocumentRecordLogNumberDocumentRecordLog.Name = "DocumentRecordLogNumberDocumentRecordLog";
        this.DocumentRecordLogNumberDocumentRecordLog.Width = 150;

        this.ExtendExpirationDateDetails = new TTVisual.TTGrid();
        this.ExtendExpirationDateDetails.Name = "ExtendExpirationDateDetails";
        this.ExtendExpirationDateDetails.TabIndex = 0;
        this.ExtendExpirationDateDetails.Height = 350;
        this.ExtendExpirationDateDetails.AllowUserToAddRows = false;
        this.ExtendExpirationDateDetails.AllowUserToDeleteRows = false;

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

        this.MaterialExtendExpirationDateDetail = new TTVisual.TTListBoxColumn();
        this.MaterialExtendExpirationDateDetail.ListDefName = "MaterialListDefinition";
        this.MaterialExtendExpirationDateDetail.DataMember = "Material";
        this.MaterialExtendExpirationDateDetail.AutoCompleteDialogHeight = "60%";
        this.MaterialExtendExpirationDateDetail.AutoCompleteDialogWidth = "50%";
        this.MaterialExtendExpirationDateDetail.DisplayIndex = 0;
        this.MaterialExtendExpirationDateDetail.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialExtendExpirationDateDetail.Name = "MaterialExtendExpirationDateDetail";
        this.MaterialExtendExpirationDateDetail.Width = 300;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.BUDGETYPE = new TTVisual.TTEnumComboBoxColumn();
        this.BUDGETYPE.DataTypeName = "MKYS_EButceTurEnum";
        this.BUDGETYPE.DataMember = "BudgeType";
        this.BUDGETYPE.DisplayIndex = 3;
        this.BUDGETYPE.HeaderText = i18n("M12145", "Bütçe Tipi");
        this.BUDGETYPE.Name = "BUDGETYPE";
        this.BUDGETYPE.ReadOnly = true;
        this.BUDGETYPE.Width = 120;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Material.Barcode";
        this.Barcode.DisplayIndex = 1;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.NumberOfRowsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.NumberOfRowsDocumentRecordLog.DataMember = "NumberOfRows";
        this.NumberOfRowsDocumentRecordLog.DisplayIndex = 4;
        this.NumberOfRowsDocumentRecordLog.HeaderText = i18n("M17091", "Kalem Adedi");
        this.NumberOfRowsDocumentRecordLog.Name = "NumberOfRowsDocumentRecordLog";
        this.NumberOfRowsDocumentRecordLog.Width = 120;

        this.RestAmount = new TTVisual.TTTextBoxColumn();
        this.RestAmount.DataMember = "SelectedLotRestAmount";
        this.RestAmount.DisplayIndex = 2;
        this.RestAmount.HeaderText = i18n("M15007", "Güncelleme Öncesi Lot Miktar");
        this.RestAmount.Name = "RestAmount";
        this.RestAmount.ReadOnly = true;
        this.RestAmount.Width = 200;
        this.RestAmount.IsNumeric = true;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.SubjectDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.SubjectDocumentRecordLog.DataMember = "Subject";
        this.SubjectDocumentRecordLog.DisplayIndex = 5;
        this.SubjectDocumentRecordLog.HeaderText = i18n("M14805", "Giriş ve Çıkış Nedenleri");
        this.SubjectDocumentRecordLog.Name = "SubjectDocumentRecordLog";
        this.SubjectDocumentRecordLog.Width = 200;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 3;
        this.Amount.HeaderText = i18n("M15015", "Güncellenen Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Width = 150;
        this.Amount.IsNumeric = true;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.DescriptionsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DescriptionsDocumentRecordLog.DataMember = "Descriptions";
        this.DescriptionsDocumentRecordLog.DisplayIndex = 6;
        this.DescriptionsDocumentRecordLog.HeaderText = i18n("M10483", "Açıklamalar");
        this.DescriptionsDocumentRecordLog.Name = "DescriptionsDocumentRecordLog";
        this.DescriptionsDocumentRecordLog.Width = 200;

        this.CurrentExpirationDate = new TTVisual.TTDateTimePickerColumn();
        this.CurrentExpirationDate.Format = DateTimePickerFormat.Custom;
        this.CurrentExpirationDate.CustomFormat = "MM/yyyy";
        this.CurrentExpirationDate.DataMember = "CurrentExpirationDate";
        this.CurrentExpirationDate.DisplayIndex = 4;
        this.CurrentExpirationDate.HeaderText = i18n("M15009", "Güncelleme Öncesi Son Kullanma Tarihi");
        this.CurrentExpirationDate.Name = "CurrentExpirationDate";
        this.CurrentExpirationDate.ReadOnly = true;
        this.CurrentExpirationDate.Width = 280;

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
        this.ReceiptNumber.Width = 150;

        this.NewDateForExpirationExtendExpirationDateDetail = new TTVisual.TTDateTimePickerColumn();
        this.NewDateForExpirationExtendExpirationDateDetail.Format = DateTimePickerFormat.Custom;
        this.NewDateForExpirationExtendExpirationDateDetail.CustomFormat = "MM/yyyy";
        this.NewDateForExpirationExtendExpirationDateDetail.DataMember = "NewDateForExpiration";
        this.NewDateForExpirationExtendExpirationDateDetail.DisplayIndex = 5;
        this.NewDateForExpirationExtendExpirationDateDetail.HeaderText = i18n("M24591", "Yeni Son Kullanma Tarihi");
        this.NewDateForExpirationExtendExpirationDateDetail.Name = "NewDateForExpirationExtendExpirationDateDetail";
        this.NewDateForExpirationExtendExpirationDateDetail.Width = 150;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 113;

        this.SendToMKYS = new TTVisual.TTButton();
        this.SendToMKYS.Text = "MKYS'ye Gönder";
        this.SendToMKYS.Name = "SendToMKYS";
        this.SendToMKYS.TabIndex = 126;

        this.StockLevelType = new TTVisual.TTListBoxColumn();
        this.StockLevelType.ListDefName = "StockLevelTypeList";
        this.StockLevelType.DataMember = "StockLevelType";
        this.StockLevelType.DisplayIndex = 6;
        this.StockLevelType.HeaderText = i18n("M13372", "Durumu");
        this.StockLevelType.Name = "StockLevelType";
        this.StockLevelType.ReadOnly = true;
        this.StockLevelType.Width = 120;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 111;

        this.DocumentRecordLogSearch = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogSearch.Text = 'MKYS Log Sorgula';
        this.DocumentRecordLogSearch.Name = 'GetLogFromMkys';

        this.DocumentRecordLogDeleteMKYS = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogDeleteMKYS.Text = 'MKYS Kayıt Sil';
        this.DocumentRecordLogDeleteMKYS.Name = 'DeleteMkysRow';

        this.DocumentRecordLogsColumns = [this.DocumentDateTimeDocumentRecordLog, this.DocumentRecordLogNumberDocumentRecordLog, this.DocumentTransactionTypeDocumentRecordLog, this.BUDGETYPE, this.NumberOfRowsDocumentRecordLog, this.SubjectDocumentRecordLog, this.DescriptionsDocumentRecordLog, this.ReceiptNumber,this.DocumentRecordLogDeleteMKYS, this.DocumentRecordLogSearch];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.DocumentRecordLogTab.Controls = [this.DocumentRecordLogs];
        this.tttabcontrol1.Controls = [this.DocumentRecordLogTab, this.MaterialTabPage];
        this.MaterialTabPage.Controls = [this.ExtendExpirationDateDetails];
        this.DescriptionAndSignTabControl.Controls = [this.tttabpage1, this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.tttabpage1, this.labelStore, this.TTTeslimEdenButon, this.DocumentRecordLogTab, this.Store, this.TTTeslimAlanButon, this.DocumentRecordLogs, this.tttabcontrol1, this.labelMKYS_TeslimEden, this.DocumentDateTimeDocumentRecordLog, this.MaterialTabPage, this.MKYS_TeslimEden, this.DocumentRecordLogNumberDocumentRecordLog, this.ExtendExpirationDateDetails, this.MKYS_TeslimAlan, this.DocumentTransactionTypeDocumentRecordLog, this.MaterialExtendExpirationDateDetail, this.Description, this.BUDGETYPE, this.Barcode, this.StockActionID, this.NumberOfRowsDocumentRecordLog, this.RestAmount, this.labelMKYS_TeslimAlan, this.SubjectDocumentRecordLog, this.Amount, this.labelTransactionDate, this.DescriptionsDocumentRecordLog, this.CurrentExpirationDate, this.TransactionDate, this.ReceiptNumber, this.NewDateForExpirationExtendExpirationDateDetail, this.labelStockActionID, this.SendToMKYS, this.StockLevelType, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.ttlabel1,this.DocumentRecordLogDeleteMKYS, this.DocumentRecordLogSearch];


    }


}
