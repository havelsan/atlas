//$5F3C0CAA
import { Component, OnInit, NgZone } from '@angular/core';
import { ReturningDocumentCompletedFormViewModel } from './ReturningDocumentCompletedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseReturningDocumentForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Iade_Belgesi_Modulu/BaseReturningDocumentForm";
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { ReturningDocument } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { ReturningDocumentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { MkysServis } from 'NebulaClient/Services/External/MkysServis';
import { StockActionService, DocumentRecordLogReceiptNumber_Input, OutputForReGeneration } from 'ObjectClassService/StockActionService';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { IModalService } from "Fw/Services/IModalService";
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { UsernamePwdBox } from 'NebulaClient/Visual/UsernamePwdBox';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import Exception from 'app/NebulaClient/System/Exception';

@Component({
    selector: 'ReturningDocumentCompletedForm',
    templateUrl: './ReturningDocumentCompletedForm.html',
    providers: [MessageService]
})
export class ReturningDocumentCompletedForm extends BaseReturningDocumentForm implements OnInit {
    BudgeType: TTVisual.ITTEnumComboBoxColumn;
    DescriptionsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentDateTimeDocumentRecordLog: TTVisual.ITTDateTimePickerColumn;
    DocumentRecordLogNumberDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogs: TTVisual.ITTGrid;
    DocumentRecordLogTab: TTVisual.ITTTabPage;
    DocumentTransactionTypeDocumentRecordLog: TTVisual.ITTEnumComboBoxColumn;
    labelRegistrationNumber: TTVisual.ITTLabel;
    labelSequenceNumber: TTVisual.ITTLabel;
    ReceiptNumber: TTVisual.ITTTextBoxColumn;
    RegistrationNumber: TTVisual.ITTTextBox;
    SendToMKYS: TTVisual.ITTButton;
    SequenceNumber: TTVisual.ITTTextBox;
    SubjectDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    tttabpage2: TTVisual.ITTTabPage;
    DocumentRecordLogSearch: TTVisual.ITTButtonColumn;
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;
    
    public DocumentRecordLogsColumns = [];
   // public StockActionOutDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public returningDocumentCompletedFormViewModel: ReturningDocumentCompletedFormViewModel = new ReturningDocumentCompletedFormViewModel();
    public get _ReturningDocument(): ReturningDocument {
        return this._TTObject as ReturningDocument;
    }
    private ReturningDocumentCompletedForm_DocumentUrl: string = '/api/ReturningDocumentService/ReturningDocumentCompletedForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ReturningDocumentCompletedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    public mkysSonucMesaj: string;
    popupVisible: boolean = false;
    reGenerateButtonVisible: boolean = true;

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();

        if (this._ReturningDocument.CurrentStateDefID.toString() == ReturningDocument.ReturningDocumentStates.Completed.id.toString()) {
            this.reGenerateButtonVisible = false;
        }

        this.SendToMKYS.ReadOnly = false;
    }

    public async prepareDocument_Click(): Promise<void> {
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ReturningDocument.ObjectID.toString());
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
        this.mkysSonucMesaj = '';
        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result == DialogResult.OK) {
            this.showLoadPanel = true;
            let params = <any>(<ModalActionResult>result).Param;
            if (this._ReturningDocument.CurrentStateDefID.toString() === ReturningDocument.ReturningDocumentStates.Completed.id) {
                // this._ReturningDocument.SendMYKSProperties();
                //-TODO İlaydax
                for (let log of this._ReturningDocument.DocumentRecordLogs) {
                    if (log.ReceiptNumber == null) {
                        this.mkysSonucMesaj = await StockActionService.SendMKYSForInputDocumentTS(this._ReturningDocument, params.password);
                    }

                    if (log.ReceiptNumber != null)
                        this.mkysSonucMesaj += log.ReceiptNumber.toString() + " Ayniyat numarası ile MKYSye kaydolmuştur.";
                }
            }
            if (this._ReturningDocument.CurrentStateDefID.toString() === ReturningDocument.ReturningDocumentStates.Cancelled.id) {
                for (let log of this._ReturningDocument.DocumentRecordLogs) {
                    if (log.ReceiptNumber != null)
                        this.mkysSonucMesaj = await StockActionService.SendDeleteMessageToMkysTS(this._ReturningDocument, false, log.ReceiptNumber.Value, params.password);
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

    public async reGenerateAction_Click(): Promise<void> {
        let result: OutputForReGeneration = null;
        try {
            result = await StockActionService.ReGenerateMyReturningDocument(this._ReturningDocument.ObjectID.toString());
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

    DocumentRecordLogs_CellValueChangedEmitted(data: any) { }
    initDocumentRecordLogsNewRow(data: any) { }
    onDocumentRecordLogsRowInserting(data: any) { }
    onSelectionChangeDocumentRecordLogs(data: any) { }




    //<this.StockActionOutDetail gridde kullanılıyordu
    //onCellContentClicked(data: any) {
    //}
    //StockActionOutDetails_CellValueChangedEmitted(data: any) {
    //    if (data && this.StockActionOutDetails_CellValueChanged && data.Row && data.Column) {
    //        this.StockActionOutDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
    //    }
    //}
    //initNewRow(data: any) { }
    //onRowInserting(data: any) { }
    //onSelectionChange(data: any) { }
    //this.StockActionOutDetail gridde kullanılıyordu >



    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ReturningDocument();
        this.returningDocumentCompletedFormViewModel = new ReturningDocumentCompletedFormViewModel();
        this._ViewModel = this.returningDocumentCompletedFormViewModel;
        this.returningDocumentCompletedFormViewModel._ReturningDocument = this._TTObject as ReturningDocument;
        this.returningDocumentCompletedFormViewModel._ReturningDocument.DocumentRecordLogs = new Array<DocumentRecordLog>();
        this.returningDocumentCompletedFormViewModel._ReturningDocument.Store = new Store();
        this.returningDocumentCompletedFormViewModel._ReturningDocument.DestinationStore = new Store();
        this.returningDocumentCompletedFormViewModel._ReturningDocument.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.returningDocumentCompletedFormViewModel._ReturningDocument.ReturningDocumentMaterials = new Array<ReturningDocumentMaterial>();
    }

    protected loadViewModel() {
        let that = this;
        that.returningDocumentCompletedFormViewModel = this._ViewModel;
        that._TTObject = this.returningDocumentCompletedFormViewModel._ReturningDocument;
        if (this.returningDocumentCompletedFormViewModel == null)
            this.returningDocumentCompletedFormViewModel = new ReturningDocumentCompletedFormViewModel();
        if (this.returningDocumentCompletedFormViewModel._ReturningDocument == null)
            this.returningDocumentCompletedFormViewModel._ReturningDocument = new ReturningDocument();
        that.returningDocumentCompletedFormViewModel._ReturningDocument.DocumentRecordLogs = that.returningDocumentCompletedFormViewModel.DocumentRecordLogsGridList;
        for (let detailItem of that.returningDocumentCompletedFormViewModel.DocumentRecordLogsGridList) {
        }
        let storeObjectID = that.returningDocumentCompletedFormViewModel._ReturningDocument["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.returningDocumentCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.returningDocumentCompletedFormViewModel._ReturningDocument.Store = store;
            }
        }
        let destinationStoreObjectID = that.returningDocumentCompletedFormViewModel._ReturningDocument["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.returningDocumentCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.returningDocumentCompletedFormViewModel._ReturningDocument.DestinationStore = destinationStore;
            }
        }
        that.returningDocumentCompletedFormViewModel._ReturningDocument.StockActionSignDetails = that.returningDocumentCompletedFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.returningDocumentCompletedFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.returningDocumentCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
        that.returningDocumentCompletedFormViewModel._ReturningDocument.ReturningDocumentMaterials = that.returningDocumentCompletedFormViewModel.StockActionOutDetailsGridList;
        for (let detailItem of that.returningDocumentCompletedFormViewModel.StockActionOutDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.returningDocumentCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.returningDocumentCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.returningDocumentCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.returningDocumentCompletedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(ReturningDocumentCompletedFormViewModel);
        this.MKYS_TeslimAlan.ButtonEnabled = false;
        this.MKYS_TeslimEden.ButtonEnabled = false;
        this.DocumentRecordLogSearch.ReadOnly = false;
        that.DocumentRecordLogDeleteMKYS.ReadOnly = false;
        if (this._ReturningDocument.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ReturningDocument.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        if (this._ReturningDocument.CurrentStateDefID.toString() == ReturningDocument.ReturningDocumentStates.Completed.id.toString()) {
            this.FormCaption = i18n("M16050", "İade Belgesi   ( Tamamlandı )");
        }
        if (this._ReturningDocument.CurrentStateDefID.toString() == ReturningDocument.ReturningDocumentStates.Cancelled.id.toString()) {
            this.FormCaption = i18n("M16049", "İade Belgesi   ( İptal Edildi )");
        }

    }

    receiptNumberError: string ="";
    controlOfCancelMKYS: boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        for (let log of this._ReturningDocument.DocumentRecordLogs) {
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

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.Description != event) {
                this._ReturningDocument.Description = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.DestinationStore != event) {
                this._ReturningDocument.DestinationStore = event;
            }
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.MKYS_EMalzemeGrup != event) {
                this._ReturningDocument.MKYS_EMalzemeGrup = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._ReturningDocument != null && this._ReturningDocument.MKYS_TeslimAlan != event) {
                this._ReturningDocument.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._ReturningDocument != null && this._ReturningDocument.MKYS_TeslimEden != event) {
                this._ReturningDocument.MKYS_TeslimEden = event;
            }
        }
    }

    public onRegistrationNumberChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.RegistrationNumber != event) {
                this._ReturningDocument.RegistrationNumber = event;
            }
        }
    }

    public onSequenceNumberChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.SequenceNumber != event) {
                this._ReturningDocument.SequenceNumber = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.StockActionID != event) {
                this._ReturningDocument.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.Store != event) {
                this._ReturningDocument.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.TransactionDate != event) {
                this._ReturningDocument.TransactionDate = event;
            }
        }
    }





    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.MKYS_EMalzemeGrup, "Value", this.__ttObject, "MKYS_EMalzemeGrup");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.RegistrationNumber, "Text", this.__ttObject, "RegistrationNumber");
        redirectProperty(this.SequenceNumber, "Text", this.__ttObject, "SequenceNumber");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 2;
        this.tttabpage2.TabIndex = 2;
        this.tttabpage2.Text = "Taşınır Mal İşlem Belgeleri";
        this.tttabpage2.Name = "tttabpage2";

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 37;

        this.DocumentRecordLogTab = new TTVisual.TTTabPage();
        this.DocumentRecordLogTab.DisplayIndex = 1;
        this.DocumentRecordLogTab.TabIndex = 1;
        this.DocumentRecordLogTab.Text = "Taşınır Mal İşlem Belgeleri";
        this.DocumentRecordLogTab.Name = "DocumentRecordLogTab";

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 36;

        this.DocumentRecordLogs = new TTVisual.TTGrid();
        this.DocumentRecordLogs.Name = "DocumentRecordLogs";
        this.DocumentRecordLogs.TabIndex = 129;
        this.DocumentRecordLogs.Height = 350;
        this.DocumentRecordLogs.AllowUserToAddRows = false;
        this.DocumentRecordLogs.AllowUserToDeleteRows = false;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 34;

        this.DocumentDateTimeDocumentRecordLog = new TTVisual.TTDateTimePickerColumn();
        this.DocumentDateTimeDocumentRecordLog.DataMember = "DocumentDateTime";
        this.DocumentDateTimeDocumentRecordLog.DisplayIndex = 0;
        this.DocumentDateTimeDocumentRecordLog.HeaderText = i18n("M11748", "Belge Tarihi");
        this.DocumentDateTimeDocumentRecordLog.Name = "DocumentDateTimeDocumentRecordLog";
        this.DocumentDateTimeDocumentRecordLog.Width = 180;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 6;

        this.DocumentRecordLogNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DocumentRecordLogNumberDocumentRecordLog.DataMember = "DocumentRecordLogNumber";
        this.DocumentRecordLogNumberDocumentRecordLog.DisplayIndex = 1;
        this.DocumentRecordLogNumberDocumentRecordLog.HeaderText = i18n("M11746", "Belge Numarası");
        this.DocumentRecordLogNumberDocumentRecordLog.Name = "DocumentRecordLogNumberDocumentRecordLog";
        this.DocumentRecordLogNumberDocumentRecordLog.Width = 120;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.DocumentTransactionTypeDocumentRecordLog = new TTVisual.TTEnumComboBoxColumn();
        this.DocumentTransactionTypeDocumentRecordLog.DataTypeName = "DocumentTransactionTypeEnum";
        this.DocumentTransactionTypeDocumentRecordLog.DataMember = "DocumentTransactionType";
        this.DocumentTransactionTypeDocumentRecordLog.DisplayIndex = 2;
        this.DocumentTransactionTypeDocumentRecordLog.HeaderText = i18n("M16834", "İşlem Çeşidi");
        this.DocumentTransactionTypeDocumentRecordLog.Name = "DocumentTransactionTypeDocumentRecordLog";
        this.DocumentTransactionTypeDocumentRecordLog.Width = 140;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 35;

        this.BudgeType = new TTVisual.TTEnumComboBoxColumn();
        this.BudgeType.DataTypeName = "MKYS_EButceTurEnum";
        this.BudgeType.DataMember = "BudgeType";
        this.BudgeType.DisplayIndex = 3;
        this.BudgeType.HeaderText = i18n("M12145", "Bütçe Tipi");
        this.BudgeType.Name = "BudgeType";
        this.BudgeType.ReadOnly = true;
        this.BudgeType.Width = 120;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 33;

        this.SubjectDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.SubjectDocumentRecordLog.DataMember = "Subject";
        this.SubjectDocumentRecordLog.DisplayIndex = 4;
        this.SubjectDocumentRecordLog.HeaderText = i18n("M14805", "Giriş ve Çıkış Nedenleri");
        this.SubjectDocumentRecordLog.Name = "SubjectDocumentRecordLog";
        this.SubjectDocumentRecordLog.Width = 140;
        this.SubjectDocumentRecordLog.Visible = false;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "SubStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 32;

        this.ReceiptNumber = new TTVisual.TTTextBoxColumn();
        this.ReceiptNumber.DataMember = "ReceiptNumber";
        this.ReceiptNumber.DisplayIndex = 5;
        this.ReceiptNumber.HeaderText = "Ayniyat Makbuz No";
        this.ReceiptNumber.Name = "ReceiptNumber";
        this.ReceiptNumber.ReadOnly = true;
        this.ReceiptNumber.Width = 140;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M10678", "Alan Depo");
        this.labelDestinationStore.Name = "labelDestinationStore";
        this.labelDestinationStore.TabIndex = 31;

        this.DescriptionsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DescriptionsDocumentRecordLog.DataMember = "Descriptions";
        this.DescriptionsDocumentRecordLog.DisplayIndex = 6;
        this.DescriptionsDocumentRecordLog.HeaderText = i18n("M10483", "Açıklamalar");
        this.DescriptionsDocumentRecordLog.Name = "DescriptionsDocumentRecordLog";
        this.DescriptionsDocumentRecordLog.Width = 80;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ReadOnly = true;
        this.DestinationStore.ListDefName = "MainStoreList";
        this.DestinationStore.Name = "DestinationStore";
        this.DestinationStore.TabIndex = 30;

        this.SequenceNumber = new TTVisual.TTTextBox();
        this.SequenceNumber.BackColor = "#F0F0F0";
        this.SequenceNumber.ReadOnly = true;
        this.SequenceNumber.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SequenceNumber.Name = "SequenceNumber";
        this.SequenceNumber.TabIndex = 3;

        this.cmdHEKReport = new TTVisual.TTButton();
        this.cmdHEKReport.Text = i18n("M15614", "HEK Raporu Bas");
        this.cmdHEKReport.Name = "cmdHEKReport";
        this.cmdHEKReport.TabIndex = 29;
        this.cmdHEKReport.Visible = false;

        this.RegistrationNumber = new TTVisual.TTTextBox();
        this.RegistrationNumber.BackColor = "#F0F0F0";
        this.RegistrationNumber.ReadOnly = true;
        this.RegistrationNumber.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RegistrationNumber.Name = "RegistrationNumber";
        this.RegistrationNumber.TabIndex = 2;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.BackColor = "#DCDCDC";
        this.labelTransactionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelTransactionDate.ForeColor = "#000000";
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 7;

        this.labelRegistrationNumber = new TTVisual.TTLabel();
        this.labelRegistrationNumber.Text = i18n("M20637", "R.Belge Kayıt Nu.");
        this.labelRegistrationNumber.BackColor = "#DCDCDC";
        this.labelRegistrationNumber.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRegistrationNumber.ForeColor = "#000000";
        this.labelRegistrationNumber.Name = "labelRegistrationNumber";
        this.labelRegistrationNumber.TabIndex = 12;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.CustomFormat = "";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.labelSequenceNumber = new TTVisual.TTLabel();
        this.labelSequenceNumber.Text = i18n("M20638", "R.Belge Sıra Nu.");
        this.labelSequenceNumber.BackColor = "#DCDCDC";
        this.labelSequenceNumber.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSequenceNumber.ForeColor = "#000000";
        this.labelSequenceNumber.Name = "labelSequenceNumber";
        this.labelSequenceNumber.TabIndex = 10;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.BackColor = "#DCDCDC";
        this.labelStockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelStockActionID.ForeColor = "#000000";
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 3;

        this.SendToMKYS = new TTVisual.TTButton();
        this.SendToMKYS.Text = "MKYS'ye Gönder";
        this.SendToMKYS.Name = "SendToMKYS";
        this.SendToMKYS.TabIndex = 126;

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

        this.DescriptionTabpage = new TTVisual.TTTabPage();
        this.DescriptionTabpage.DisplayIndex = 1;
        this.DescriptionTabpage.TabIndex = 0;
        this.DescriptionTabpage.Text = i18n("M10469", "Açıklama");
        this.DescriptionTabpage.Name = "DescriptionTabpage";

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 4;

        this.MaterialTabPage = new TTVisual.TTTabPage();
        this.MaterialTabPage.DisplayIndex = 0;
        this.MaterialTabPage.BackColor = "#FFFFFF";
        this.MaterialTabPage.TabIndex = 0;
        this.MaterialTabPage.Text = "Taşınır Malın";
        this.MaterialTabPage.Name = "MaterialTabPage";
         //<this.StockActionOutDetailsColumns dxgrid e taşındı
        //this.StockActionOutDetails = new TTVisual.TTGrid();
        //this.StockActionOutDetails.Required = true;
        //this.StockActionOutDetails.BackColor = "#FFE3C6";
        //this.StockActionOutDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.StockActionOutDetails.Name = "StockActionOutDetails";
        //this.StockActionOutDetails.TabIndex = 0;
        //this.StockActionOutDetails.Height = 350;
        //this.StockActionOutDetails.AllowUserToAddRows = false;
        //this.StockActionOutDetails.AllowUserToDeleteRows = false;

        //this.Detail = new TTVisual.TTButtonColumn();
        //this.Detail.Text = i18n("M12671", "Detay");
        //this.Detail.UseColumnTextForButtonValue = true;
        //this.Detail.DisplayIndex = 0;
        //this.Detail.HeaderText = "";
        //this.Detail.Name = "Detail";
        //this.Detail.ToolTipText = i18n("M12671", "Detay");
        //this.Detail.Width = 80;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.AllowMultiSelect = true;
        this.Material.ListDefName = "MaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.AutoCompleteDialogHeight = '60%';
        this.Material.AutoCompleteDialogWidth = '90%';
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M22362", "Stok Nu., Cins ve Özellikleri");
        this.Material.Name = "Material";
        this.Material.Width = 400;
        this.Material.ReadOnly = true;

        //this.Barcode = new TTVisual.TTTextBoxColumn();
        //this.Barcode.DataMember = "Material.Barcode";
        //this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //this.Barcode.DisplayIndex = 2;
        //this.Barcode.HeaderText = "Barkod";
        //this.Barcode.Name = "Barcode";
        //this.Barcode.ReadOnly = true;
        //this.Barcode.Width = 120;

        //this.DistributionType = new TTVisual.TTTextBoxColumn();
        //this.DistributionType.DataMember = "Material.DistributionTypeName";
        //this.DistributionType.DisplayIndex = 3;
        //this.DistributionType.HeaderText = i18n("M12449", "Dağıtım Şekli");
        //this.DistributionType.Name = "DistributionType";
        //this.DistributionType.ReadOnly = true;
        //this.DistributionType.Width = 120;

        //this.Existing = new TTVisual.TTTextBoxColumn();
        //this.Existing.DataMember = "StoreStock";
        //this.Existing.Format = "N2";
        //this.Existing.Alignment = DataGridViewContentAlignment.MiddleRight;
        //this.Existing.DisplayIndex = 4;
        //this.Existing.HeaderText = i18n("M22360", "Stok Miktarı");
        //this.Existing.Name = "Existing";
        //this.Existing.ReadOnly = true;
        //this.Existing.Width = 120;
        //this.Existing.IsNumeric = true;

        //this.RequireAmount = new TTVisual.TTTextBoxColumn();
        //this.RequireAmount.DataMember = "RequireAmount";
        //this.RequireAmount.Required = true;
        //this.RequireAmount.Format = "N2";
        //this.RequireAmount.Alignment = DataGridViewContentAlignment.MiddleRight;
        //this.RequireAmount.DisplayIndex = 5;
        //this.RequireAmount.HeaderText = i18n("M16061", "İade Edilecek Miktar");
        //this.RequireAmount.Name = "RequireAmount";
        //this.RequireAmount.Width = 120;
        //this.RequireAmount.IsNumeric = true;

        //this.Amount = new TTVisual.TTTextBoxColumn();
        //this.Amount.DataMember = "Amount";
        //this.Amount.Format = "N2";
        //this.Amount.Alignment = DataGridViewContentAlignment.MiddleRight;
        //this.Amount.DisplayIndex = 6;
        //this.Amount.HeaderText = i18n("M10707", "Alınan Miktar");
        //this.Amount.Name = "Amount";
        //this.Amount.Visible = false;
        //this.Amount.Width = 120;
        //this.Amount.IsNumeric = true;

        //this.StockLevelType = new TTVisual.TTListBoxColumn();
        //this.StockLevelType.ListDefName = "StockLevelTypeList";
        //this.StockLevelType.DataMember = "StockLevelType";
        //this.StockLevelType.DisplayIndex = 7;
        //this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        //this.StockLevelType.Name = "StockLevelType";
        //this.StockLevelType.ReadOnly = true;
        //this.StockLevelType.Width = 120;
         //this.StockActionOutDetailsColumns>


        this.ChooseProductsFromTheTree = new TTVisual.TTButton();
        this.ChooseProductsFromTheTree.Text = i18n("M23971", "Ürün Ağacından Seç");
        this.ChooseProductsFromTheTree.Name = "ChooseProductsFromTheTree";
        this.ChooseProductsFromTheTree.TabIndex = 27;
        this.ChooseProductsFromTheTree.Visible = false;

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

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 16;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.DocumentRecordLogSearch = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogSearch.Text = 'MKYS Log Sorgula';
        this.DocumentRecordLogSearch.Name = 'GetLogFromMkys';

        this.DocumentRecordLogDeleteMKYS = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogDeleteMKYS.Text = 'MKYS Kayıt Sil';
        this.DocumentRecordLogDeleteMKYS.Name = 'DeleteMkysRow';

        this.DocumentRecordLogsColumns = [this.DocumentDateTimeDocumentRecordLog, this.DocumentRecordLogNumberDocumentRecordLog,
        this.DocumentTransactionTypeDocumentRecordLog, this.BudgeType, this.SubjectDocumentRecordLog, this.ReceiptNumber, this.DescriptionsDocumentRecordLog, this.DocumentRecordLogDeleteMKYS ,this.DocumentRecordLogSearch];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        //this.StockActionOutDetailsColumns = [this.Detail, this.Material, this.Barcode, this.DistributionType, this.Existing, this.RequireAmount,this.Amount, this.StockLevelType];
        this.DocumentRecordLogTab.Controls = [this.DocumentRecordLogs];
        this.DescriptionAndSignTabControl.Controls = [this.tttabpage2, this.SignTabpage, this.DescriptionTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.tttabcontrol1.Controls = [this.DocumentRecordLogTab, this.MaterialTabPage];
        this.MaterialTabPage.Controls = [this.StockActionOutDetails, this.ChooseProductsFromTheTree];
        this.Controls = [this.tttabpage2, this.labelMKYS_TeslimEden, this.DocumentRecordLogTab, this.MKYS_TeslimEden, this.DocumentRecordLogs,
        this.MKYS_TeslimAlan, this.DocumentDateTimeDocumentRecordLog, this.Description, this.DocumentRecordLogNumberDocumentRecordLog,
        this.StockActionID, this.DocumentTransactionTypeDocumentRecordLog, this.labelMKYS_TeslimAlan, this.BudgeType, this.labelStore,
        this.SubjectDocumentRecordLog, this.Store, this.ReceiptNumber, this.labelDestinationStore, this.DescriptionsDocumentRecordLog,
        this.DestinationStore, this.SequenceNumber, this.cmdHEKReport, this.RegistrationNumber, this.labelTransactionDate,
        this.labelRegistrationNumber, this.TransactionDate, this.labelSequenceNumber, this.labelStockActionID, this.SendToMKYS,
        this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy,
        this.DescriptionTabpage, this.tttabcontrol1, this.MaterialTabPage, this.StockActionOutDetails, this.Detail, this.Material, this.Barcode,
        this.DistributionType, this.Existing, this.RequireAmount, this.Amount, this.StockLevelType, this.ChooseProductsFromTheTree, this.MKYS_EMalzemeGrup,
        this.labelMKYS_EMalzemeGrup, this.ttlabel1, this.TTTeslimAlanButon, this.TTTeslimEdenButon,this.DocumentRecordLogDeleteMKYS , this.DocumentRecordLogSearch];


    }
}
