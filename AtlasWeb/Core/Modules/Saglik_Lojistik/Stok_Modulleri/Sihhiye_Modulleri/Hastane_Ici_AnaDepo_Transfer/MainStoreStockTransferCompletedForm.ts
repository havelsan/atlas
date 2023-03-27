//$5B19FA2D
import { Component, OnInit, NgZone } from '@angular/core';
import { MainStoreStockTransferCompletedFormViewModel } from './MainStoreStockTransferCompletedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseMainStoreStockTransferForm } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/XXXXXX_Ici_AnaDepo_Transfer/BaseMainStoreStockTransferForm';
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { MainStoreStockTransfer } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { MainStoreStockTransferMat } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

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
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import Exception from 'app/NebulaClient/System/Exception';

@Component({
    selector: 'MainStoreStockTransferCompletedForm',
    templateUrl: './MainStoreStockTransferCompletedForm.html',
    providers: [MessageService]
})
export class MainStoreStockTransferCompletedForm extends BaseMainStoreStockTransferForm implements OnInit {
    BUDGETYPE: TTVisual.ITTEnumComboBoxColumn;
    DocumentDateTimeDocumentRecordLog: TTVisual.ITTDateTimePickerColumn;
    DocumentRecordLog: TTVisual.ITTTabPage;
    DocumentRecordLogNumberDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogs: TTVisual.ITTGrid;
    DocumentRecordLogTab: TTVisual.ITTTabPage;
    DocumentTransactionTypeDocumentRecordLog: TTVisual.ITTEnumComboBoxColumn;
    NumberOfRowsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    ReceiptNumber: TTVisual.ITTTextBoxColumn;
    SendToMKYS: TTVisual.ITTButton;
    SubjectDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    TakenGivenPlaceDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogSearch: TTVisual.ITTButtonColumn;
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;
    public DocumentRecordLogsColumns = [];
    public StockActionSignDetailsColumns = [];
    public mainStoreStockTransferCompletedFormViewModel: MainStoreStockTransferCompletedFormViewModel = new MainStoreStockTransferCompletedFormViewModel();
    public get _MainStoreStockTransfer(): MainStoreStockTransfer {
        return this._TTObject as MainStoreStockTransfer;
    }
    private MainStoreStockTransferCompletedForm_DocumentUrl: string = '/api/MainStoreStockTransferService/MainStoreStockTransferCompletedForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.MainStoreStockTransferCompletedForm_DocumentUrl;
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
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._MainStoreStockTransfer.ObjectID.toString());
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
            this.showLoadPanel = true;
            let params = <any>(<ModalActionResult>result).Param;
            let documetrecords: Array<DocumentRecordLog> = await this._MainStoreStockTransfer.DocumentRecordLogs.sort((a, b) => a.DocumentRecordLogNumber - b.DocumentRecordLogNumber);
            if (this._MainStoreStockTransfer.CurrentStateDefID.toString() === MainStoreStockTransfer.MainStoreStockTransferStates.Completed.id) {
                for (let log_1 of documetrecords) {
                    if (log_1.DocumentTransactionType === DocumentTransactionTypeEnum.Out) {
                        if (log_1.ReceiptNumber == null) {
                            let result = await UsernamePwdBox.Show(true);

                            this.mkysSonucMesaj = await StockActionService.SendMKYSForOutputDocumentTS(this._MainStoreStockTransfer, params.password);
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
                            this.mkysSonucMesaj += await StockActionService.SendMKYSForInputDocumentTS(this._MainStoreStockTransfer, params.password);
                        }
                        if (log_2.ReceiptNumber != null) {
                            this.mkysSonucMesaj += log_2.ReceiptNumber.toString() + ' Ayniyat numarası ile MKYSye kaydolmuştur.';
                        }
                    }
                }
            }
            //-TODO İlaydax
            if (this._MainStoreStockTransfer.CurrentStateDefID.id === MainStoreStockTransfer.MainStoreStockTransferStates.Cancelled.toString()) {
                for (let log_1 of documetrecords) {
                    if (log_1.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                        if (log_1.ReceiptNumber != null) {
                            this.mkysSonucMesaj = await StockActionService.SendDeleteMessageToMkysTS(this._MainStoreStockTransfer, false, log_1.ReceiptNumber.Value, params.password);
                        }
                    }
                }
                //-TODO İlaydax
                for (let log_2 of documetrecords) {
                    if (log_2.DocumentTransactionType === DocumentTransactionTypeEnum.Out) {
                        if (log_2.ReceiptNumber != null) {
                                this.mkysSonucMesaj += await StockActionService.SendDeleteMessageToMkysTS(this._MainStoreStockTransfer, true, log_2.ReceiptNumber.Value, params.password);
                        }
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

    DocumentRecordLogs_CellValueChangedEmitted(data: any) { }
    initDocumentRecordLogsNewRow(data: any) { }
    onDocumentRecordLogsRowInserting(data: any) { }
    onSelectionChangeDocumentRecordLogs(data: any) { }
    onSelectionChange(data: any) { }
    onRowInsertting(data: any) { }
    initNewRow(data: any) { }
    MainStoreStockTransferMaterials_CellValueChangedEmitted(data: any) { }
    onCellContentClicked(data: any) { }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MainStoreStockTransfer();
        this.mainStoreStockTransferCompletedFormViewModel = new MainStoreStockTransferCompletedFormViewModel();
        this._ViewModel = this.mainStoreStockTransferCompletedFormViewModel;
        this.mainStoreStockTransferCompletedFormViewModel._MainStoreStockTransfer = this._TTObject as MainStoreStockTransfer;
        this.mainStoreStockTransferCompletedFormViewModel._MainStoreStockTransfer.DocumentRecordLogs = new Array<DocumentRecordLog>();
        this.mainStoreStockTransferCompletedFormViewModel._MainStoreStockTransfer.Store = new Store();
        this.mainStoreStockTransferCompletedFormViewModel._MainStoreStockTransfer.DestinationStore = new Store();
        this.mainStoreStockTransferCompletedFormViewModel._MainStoreStockTransfer.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.mainStoreStockTransferCompletedFormViewModel._MainStoreStockTransfer.MainStoreStockTransferMats = new Array<MainStoreStockTransferMat>();
    }

    protected loadViewModel() {
        let that = this;
        that.mainStoreStockTransferCompletedFormViewModel = this._ViewModel;
        that._TTObject = this.mainStoreStockTransferCompletedFormViewModel._MainStoreStockTransfer;
        if (this.mainStoreStockTransferCompletedFormViewModel == null) {
            this.mainStoreStockTransferCompletedFormViewModel = new MainStoreStockTransferCompletedFormViewModel();
        }
        if (this.mainStoreStockTransferCompletedFormViewModel._MainStoreStockTransfer == null) {
            this.mainStoreStockTransferCompletedFormViewModel._MainStoreStockTransfer = new MainStoreStockTransfer();
        }
        that.mainStoreStockTransferCompletedFormViewModel._MainStoreStockTransfer.DocumentRecordLogs = that.mainStoreStockTransferCompletedFormViewModel.DocumentRecordLogsGridList;
        for (let detailItem of that.mainStoreStockTransferCompletedFormViewModel.DocumentRecordLogsGridList) {
        }
        let storeObjectID = that.mainStoreStockTransferCompletedFormViewModel._MainStoreStockTransfer['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.mainStoreStockTransferCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.mainStoreStockTransferCompletedFormViewModel._MainStoreStockTransfer.Store = store;
            }
        }
        let destinationStoreObjectID = that.mainStoreStockTransferCompletedFormViewModel._MainStoreStockTransfer['DestinationStore'];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.mainStoreStockTransferCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.mainStoreStockTransferCompletedFormViewModel._MainStoreStockTransfer.DestinationStore = destinationStore;
            }
        }
        that.mainStoreStockTransferCompletedFormViewModel._MainStoreStockTransfer.StockActionSignDetails = that.mainStoreStockTransferCompletedFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.mainStoreStockTransferCompletedFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem['SignUser'];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.mainStoreStockTransferCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
        that.mainStoreStockTransferCompletedFormViewModel._MainStoreStockTransfer.MainStoreStockTransferMats =
            that.mainStoreStockTransferCompletedFormViewModel.MainStoreStockTransferMaterialsGridList;
        for (let detailItem of that.mainStoreStockTransferCompletedFormViewModel.MainStoreStockTransferMaterialsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.mainStoreStockTransferCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.mainStoreStockTransferCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType =
                                    that.mainStoreStockTransferCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let stockLevelTypeObjectID = detailItem['StockLevelType'];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.mainStoreStockTransferCompletedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
    }

    receiptNumberError: string ="";
    controlOfCancelMKYS: boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        for (let log of this._MainStoreStockTransfer.DocumentRecordLogs) {
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


    async ngOnInit() {
        let that = this;
        await this.load(MainStoreStockTransferCompletedFormViewModel);
        this.MKYS_TeslimAlan.ButtonEnabled = false;
        this.MKYS_TeslimEden.ButtonEnabled = false;
        this.DocumentRecordLogSearch.ReadOnly = false;
        that.DocumentRecordLogDeleteMKYS.ReadOnly = false;
        if (this._MainStoreStockTransfer.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._MainStoreStockTransfer.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = '#F0F0F0';
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M10908", "Ana Depolar Arası Transfer ( Tamamlandı )");

    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.ActionDate !== event) {
                this._MainStoreStockTransfer.ActionDate = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.Description !== event) {
                this._MainStoreStockTransfer.Description = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.DestinationStore !== event) {
                this._MainStoreStockTransfer.DestinationStore = event;
            }
        }
    }

    public onIDChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.StockActionID !== event) {
                this._MainStoreStockTransfer.StockActionID = event;
            }
        }
    }

    public onMKYS_AyniyatMakbuzIDChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.MKYS_AyniyatMakbuzID !== event) {
                this._MainStoreStockTransfer.MKYS_AyniyatMakbuzID = event;
            }
        }
    }

    public onMKYS_AyniyatMakbuzIDGirisChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.MKYS_AyniyatMakbuzIDGiris !== event) {
                this._MainStoreStockTransfer.MKYS_AyniyatMakbuzIDGiris = event;
            }
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.MKYS_EMalzemeGrup !== event) {
                this._MainStoreStockTransfer.MKYS_EMalzemeGrup = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.MKYS_TeslimAlan !== event) {
                this._MainStoreStockTransfer.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = '#F0F0F0';
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.MKYS_TeslimEden !== event) {
                this._MainStoreStockTransfer.MKYS_TeslimEden = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.Store !== event) {
                this._MainStoreStockTransfer.Store = event;
            }
        }
    }



    public redirectProperties(): void {
        redirectProperty(this.ID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.ActionDate, 'Value', this.__ttObject, 'ActionDate');
        redirectProperty(this.MKYS_EMalzemeGrup, 'Value', this.__ttObject, 'MKYS_EMalzemeGrup');
        redirectProperty(this.MKYS_TeslimAlan, 'Text', this.__ttObject, 'MKYS_TeslimAlan');
        redirectProperty(this.MKYS_TeslimEden, 'Text', this.__ttObject, 'MKYS_TeslimEden');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
    }

    public initFormControls(): void {
        this.DocumentRecordLog = new TTVisual.TTTabPage();
        this.DocumentRecordLog.DisplayIndex = 0;
        this.DocumentRecordLog.TabIndex = 2;
        this.DocumentRecordLog.Text = 'Taşınır Mal İşlemi';
        this.DocumentRecordLog.Name = 'DocumentRecordLog';

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.Description.Name = 'Description';
        this.Description.TabIndex = 6;

        this.DocumentRecordLogTab = new TTVisual.TTTabPage();
        this.DocumentRecordLogTab.DisplayIndex = 1;
        this.DocumentRecordLogTab.TabIndex = 1;
        this.DocumentRecordLogTab.Text = 'Taşınır Mal İşlem Belgeleri';
        this.DocumentRecordLogTab.Name = 'DocumentRecordLogTab';

        this.ID = new TTVisual.TTTextBox();
        this.ID.BackColor = '#F0F0F0';
        this.ID.ReadOnly = true;
        this.ID.Name = 'ID';
        this.ID.TabIndex = 0;

        this.DocumentRecordLogs = new TTVisual.TTGrid();
        this.DocumentRecordLogs.Name = 'DocumentRecordLogs';
        this.DocumentRecordLogs.TabIndex = 1;
        this.DocumentRecordLogs.Height = 350;
        this.DocumentRecordLogs.AllowUserToAddRows = false;
        this.DocumentRecordLogs.AllowUserToDeleteRows = false;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = i18n("M18581", "Malzeme Grup");
        this.labelMKYS_EMalzemeGrup.Name = 'labelMKYS_EMalzemeGrup';
        this.labelMKYS_EMalzemeGrup.TabIndex = 9;

        this.DocumentDateTimeDocumentRecordLog = new TTVisual.TTDateTimePickerColumn();
        this.DocumentDateTimeDocumentRecordLog.DataMember = 'DocumentDateTime';
        this.DocumentDateTimeDocumentRecordLog.DisplayIndex = 0;
        this.DocumentDateTimeDocumentRecordLog.HeaderText = i18n("M11748", "Belge Tarihi");
        this.DocumentDateTimeDocumentRecordLog.Name = 'DocumentDateTimeDocumentRecordLog';
        this.DocumentDateTimeDocumentRecordLog.Width = 180;

        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = 'MKYS_EMalzemeGrupEnum';
        this.MKYS_EMalzemeGrup.BackColor = '#F0F0F0';
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = 'MKYS_EMalzemeGrup';
        this.MKYS_EMalzemeGrup.TabIndex = 8;

        this.DocumentRecordLogNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DocumentRecordLogNumberDocumentRecordLog.DataMember = 'DocumentRecordLogNumber';
        this.DocumentRecordLogNumberDocumentRecordLog.DisplayIndex = 1;
        this.DocumentRecordLogNumberDocumentRecordLog.HeaderText = i18n("M11746", "Belge Numarası");
        this.DocumentRecordLogNumberDocumentRecordLog.Name = 'DocumentRecordLogNumberDocumentRecordLog';
        this.DocumentRecordLogNumberDocumentRecordLog.Width = 120;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = 'labelStore';
        this.labelStore.TabIndex = 7;

        this.DocumentTransactionTypeDocumentRecordLog = new TTVisual.TTEnumComboBoxColumn();
        this.DocumentTransactionTypeDocumentRecordLog.DataTypeName = 'DocumentTransactionTypeEnum';
        this.DocumentTransactionTypeDocumentRecordLog.DataMember = 'DocumentTransactionType';
        this.DocumentTransactionTypeDocumentRecordLog.DisplayIndex = 2;
        this.DocumentTransactionTypeDocumentRecordLog.HeaderText = i18n("M16834", "İşlem Çeşidi");
        this.DocumentTransactionTypeDocumentRecordLog.Name = 'DocumentTransactionTypeDocumentRecordLog';
        this.DocumentTransactionTypeDocumentRecordLog.Width = 120;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = 'MainStoreList';
        this.Store.Name = 'Store';
        this.Store.TabIndex = 6;

        this.BUDGETYPE = new TTVisual.TTEnumComboBoxColumn();
        this.BUDGETYPE.DataTypeName = 'MKYS_EButceTurEnum';
        this.BUDGETYPE.DataMember = 'BudgeType';
        this.BUDGETYPE.DisplayIndex = 3;
        this.BUDGETYPE.HeaderText = i18n("M12145", "Bütçe Tipi");
        this.BUDGETYPE.Name = 'BUDGETYPE';
        this.BUDGETYPE.ReadOnly = true;
        this.BUDGETYPE.Width = 140;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M10678", "Alan Depo");
        this.labelDestinationStore.Name = 'labelDestinationStore';
        this.labelDestinationStore.TabIndex = 5;

        this.NumberOfRowsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.NumberOfRowsDocumentRecordLog.DataMember = 'NumberOfRows';
        this.NumberOfRowsDocumentRecordLog.DisplayIndex = 4;
        this.NumberOfRowsDocumentRecordLog.HeaderText = i18n("M17091", "Kalem Adedi");
        this.NumberOfRowsDocumentRecordLog.Name = 'NumberOfRowsDocumentRecordLog';
        this.NumberOfRowsDocumentRecordLog.Width = 80;
        this.NumberOfRowsDocumentRecordLog.Visible = false;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ReadOnly = true;
        this.DestinationStore.ListDefName = 'MainStoreList';
        this.DestinationStore.Name = 'DestinationStore';
        this.DestinationStore.TabIndex = 4;

        this.SubjectDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.SubjectDocumentRecordLog.DataMember = 'Subject';
        this.SubjectDocumentRecordLog.DisplayIndex = 5;
        this.SubjectDocumentRecordLog.HeaderText = i18n("M14805", "Giriş ve Çıkış Nedenleri");
        this.SubjectDocumentRecordLog.Name = 'SubjectDocumentRecordLog';
        this.SubjectDocumentRecordLog.Width = 140;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = 'labelActionDate';
        this.labelActionDate.TabIndex = 3;

        this.TakenGivenPlaceDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.TakenGivenPlaceDocumentRecordLog.DataMember = 'TakenGivenPlace';
        this.TakenGivenPlaceDocumentRecordLog.DisplayIndex = 6;
        this.TakenGivenPlaceDocumentRecordLog.HeaderText = i18n("M10714", "Alındığı / Verildiği Yer");
        this.TakenGivenPlaceDocumentRecordLog.Name = 'TakenGivenPlaceDocumentRecordLog';
        this.TakenGivenPlaceDocumentRecordLog.Width = 80;
        this.TakenGivenPlaceDocumentRecordLog.Visible = false;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = '#F0F0F0';
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = 'ActionDate';
        this.ActionDate.TabIndex = 2;

        this.ReceiptNumber = new TTVisual.TTTextBoxColumn();
        this.ReceiptNumber.DataMember = 'ReceiptNumber';
        this.ReceiptNumber.DisplayIndex = 7;
        this.ReceiptNumber.HeaderText = 'Ayniyat Makbuz No';
        this.ReceiptNumber.Name = 'ReceiptNumber';
        this.ReceiptNumber.ReadOnly = true;
        this.ReceiptNumber.Width = 120;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = i18n("M16869", "İşlem Nu.");
        this.labelID.Name = 'labelID';
        this.labelID.TabIndex = 1;

        this.SendToMKYS = new TTVisual.TTButton();
        this.SendToMKYS.Text = 'MKYS\'ye Gönder';
        this.SendToMKYS.Name = 'SendToMKYS';
        this.SendToMKYS.TabIndex = 126;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = 'DescriptionAndSignTabControl';
        this.DescriptionAndSignTabControl.TabIndex = 4;
        this.DescriptionAndSignTabControl.Visible = false;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = 'SignTabpage';

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.Name = 'StockActionSignDetails';
        this.StockActionSignDetails.TabIndex = 0;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = 'SignUserTypeEnum';
        this.SignUserType.DataMember = 'SignUserType';
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = 'SignUserType';
        this.SignUserType.Width = 120;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = 'UserListDefinition';
        this.SignUser.DataMember = 'SignUser';
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = 'SignUser';
        this.SignUser.Width = 400;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = 'IsDeputy';
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = 'IsDeputy';
        this.IsDeputy.Width = 50;

        this.DescriptionTabpage = new TTVisual.TTTabPage();
        this.DescriptionTabpage.DisplayIndex = 1;
        this.DescriptionTabpage.TabIndex = 0;
        this.DescriptionTabpage.Text = i18n("M10469", "Açıklama");
        this.DescriptionTabpage.Name = 'DescriptionTabpage';

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = 'tttabcontrol1';
        this.tttabcontrol1.TabIndex = 4;

        this.MaterialTabPage = new TTVisual.TTTabPage();
        this.MaterialTabPage.DisplayIndex = 0;
        this.MaterialTabPage.BackColor = '#FFFFFF';
        this.MaterialTabPage.TabIndex = 0;
        this.MaterialTabPage.Text = 'Taşınır Malın';
        this.MaterialTabPage.Name = 'MaterialTabPage';

        this.MainStoreStockTransferMaterials = new TTVisual.TTGrid();
        this.MainStoreStockTransferMaterials.Name = 'MainStoreStockTransferMaterials';
        this.MainStoreStockTransferMaterials.TabIndex = 8;
        this.MainStoreStockTransferMaterials.Height = 350;
        this.MainStoreStockTransferMaterials.AllowUserToAddRows = false;
        this.MainStoreStockTransferMaterials.AllowUserToDeleteRows = false;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = '';
        this.Detail.Name = 'Detail';
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 100;

        this.MaterialMainStoreStockTransferMat = new TTVisual.TTListBoxColumn();
        this.MaterialMainStoreStockTransferMat.ListDefName = 'MaterialListDefinition';
        this.MaterialMainStoreStockTransferMat.DataMember = 'Material';
        this.MaterialMainStoreStockTransferMat.AutoCompleteDialogHeight = '60%';
        this.MaterialMainStoreStockTransferMat.AutoCompleteDialogWidth = '90%';
        this.MaterialMainStoreStockTransferMat.DisplayIndex = 1;
        this.MaterialMainStoreStockTransferMat.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialMainStoreStockTransferMat.Name = 'MaterialMainStoreStockTransferMat';
        this.MaterialMainStoreStockTransferMat.Width = 400;

        this.MaterialBarcode = new TTVisual.TTTextBoxColumn();
        this.MaterialBarcode.DataMember = 'Material.Barcode';
        this.MaterialBarcode.DisplayIndex = 2;
        this.MaterialBarcode.HeaderText = 'Barkod';
        this.MaterialBarcode.Name = 'MaterialBarcode';
        this.MaterialBarcode.ReadOnly = true;
        this.MaterialBarcode.Width = 130;

        this.Distrubitontype = new TTVisual.TTTextBoxColumn();
        this.Distrubitontype.DataMember = 'Material.DistributionTypeName';
        this.Distrubitontype.DisplayIndex = 3;
        this.Distrubitontype.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.Distrubitontype.Name = 'Distrubitontype';
        this.Distrubitontype.ReadOnly = true;
        this.Distrubitontype.Width = 140;

        this.RequestAmountSubStoreStockTransferMat = new TTVisual.TTTextBoxColumn();
        this.RequestAmountSubStoreStockTransferMat.DataMember = 'RequestAmount';
        this.RequestAmountSubStoreStockTransferMat.Required = true;
        this.RequestAmountSubStoreStockTransferMat.DisplayIndex = 4;
        this.RequestAmountSubStoreStockTransferMat.HeaderText = i18n("M16713", "İstenen Miktar");
        this.RequestAmountSubStoreStockTransferMat.Name = 'RequestAmountSubStoreStockTransferMat';
        this.RequestAmountSubStoreStockTransferMat.Width = 140;
        this.RequestAmountSubStoreStockTransferMat.IsNumeric = true;

        this.AmountSubStoreStockTransferMat = new TTVisual.TTTextBoxColumn();
        this.AmountSubStoreStockTransferMat.DataMember = 'Amount';
        this.AmountSubStoreStockTransferMat.DisplayIndex = 5;
        this.AmountSubStoreStockTransferMat.HeaderText = i18n("M19030", "Miktar");
        this.AmountSubStoreStockTransferMat.Name = 'AmountSubStoreStockTransferMat';
        this.AmountSubStoreStockTransferMat.Width = 130;
        this.AmountSubStoreStockTransferMat.IsNumeric = true;

        this.StockLevelType = new TTVisual.TTListBoxColumn();
        this.StockLevelType.ListDefName = 'StockLevelTypeList';
        this.StockLevelType.DataMember = 'StockLevelType';
        this.StockLevelType.DisplayIndex = 6;
        this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelType.Name = 'StockLevelType';
        this.StockLevelType.Width = 130;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = '#FFE3C6';
        this.MKYS_TeslimAlan.Name = 'MKYS_TeslimAlan';
        this.MKYS_TeslimAlan.TabIndex = 136;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = '#FFE3C6';
        this.MKYS_TeslimEden.Name = 'MKYS_TeslimEden';
        this.MKYS_TeslimEden.TabIndex = 138;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 5;

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

        this.DocumentRecordLogSearch = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogSearch.Text = 'MKYS Log Sorgula';
        this.DocumentRecordLogSearch.Name = 'GetLogFromMkys';

        this.DocumentRecordLogDeleteMKYS = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogDeleteMKYS.Text = 'MKYS Kayıt Sil';
        this.DocumentRecordLogDeleteMKYS.Name = 'DeleteMkysRow';

        this.DocumentRecordLogsColumns = [this.DocumentDateTimeDocumentRecordLog, this.DocumentRecordLogNumberDocumentRecordLog,
        this.DocumentTransactionTypeDocumentRecordLog, this.BUDGETYPE, this.NumberOfRowsDocumentRecordLog, this.SubjectDocumentRecordLog, this.TakenGivenPlaceDocumentRecordLog, this.ReceiptNumber,this.DocumentRecordLogDeleteMKYS , this.DocumentRecordLogSearch];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.DocumentRecordLogTab.Controls = [this.DocumentRecordLogs];
        this.DescriptionAndSignTabControl.Controls = [this.DocumentRecordLog, this.SignTabpage, this.DescriptionTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.tttabcontrol1.Controls = [this.DocumentRecordLogTab, this.MaterialTabPage];
        this.MaterialTabPage.Controls = [this.MainStoreStockTransferMaterials];
        this.Controls = [this.DocumentRecordLog, this.Description, this.DocumentRecordLogTab, this.ID, this.DocumentRecordLogs, this.labelMKYS_EMalzemeGrup,
        this.DocumentDateTimeDocumentRecordLog, this.MKYS_EMalzemeGrup, this.DocumentRecordLogNumberDocumentRecordLog, this.labelStore, this.DocumentTransactionTypeDocumentRecordLog,
        this.Store, this.BUDGETYPE, this.labelDestinationStore, this.NumberOfRowsDocumentRecordLog, this.DestinationStore, this.SubjectDocumentRecordLog, this.labelActionDate,
        this.TakenGivenPlaceDocumentRecordLog, this.ActionDate, this.ReceiptNumber, this.labelID, this.SendToMKYS, this.DescriptionAndSignTabControl, this.SignTabpage,
        this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.DescriptionTabpage, this.tttabcontrol1, this.MaterialTabPage,
        this.MainStoreStockTransferMaterials, this.MKYS_TeslimAlan, this.MKYS_TeslimEden,
        this.ttlabel1, this.labelMKYS_TeslimEden, this.labelMKYS_TeslimAlan, this.TTTeslimAlanButon, this.TTTeslimEdenButon,this.DocumentRecordLogDeleteMKYS , this.DocumentRecordLogSearch];


    }
}