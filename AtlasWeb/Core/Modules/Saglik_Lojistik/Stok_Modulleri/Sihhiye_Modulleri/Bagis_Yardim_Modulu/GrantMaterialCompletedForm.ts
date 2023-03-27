//$871E2190
import { Component, OnInit, NgZone } from '@angular/core';
import { GrantMaterialCompletedFormViewModel } from './GrantMaterialCompletedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseGrantMaterialForm } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Bagis_Yardim_Modulu/BaseGrantMaterialForm';
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { GrantMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { GrantMaterialDetail } from 'NebulaClient/Model/AtlasClientModel';
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
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import Exception from 'app/NebulaClient/System/Exception';

@Component({
    selector: 'GrantMaterialCompletedForm',
    templateUrl: './GrantMaterialCompletedForm.html',
    providers: [MessageService]
})
export class GrantMaterialCompletedForm extends BaseGrantMaterialForm implements OnInit {
    BudgeTypeEnum: TTVisual.ITTEnumComboBoxColumn;
    TakenGivenPlaceDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    NumberOfRowsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    BUDGETYPE: TTVisual.ITTEnumComboBoxColumn;
    DescriptionsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentDateTimeDocumentRecordLog: TTVisual.ITTDateTimePickerColumn;
    DocumentRecordLogNumberDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogs: TTVisual.ITTGrid;
    DocumentRecordLogTab: TTVisual.ITTTabPage;
    DocumentTransactionTypeDocumentRecordLog: TTVisual.ITTEnumComboBoxColumn;
    ReceiptNumber: TTVisual.ITTTextBoxColumn;
    SendToMKYS: TTVisual.ITTButton;
    SubjectDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    tttabpage1: TTVisual.ITTTabPage;
    DocumentRecordLogSearch: TTVisual.ITTButtonColumn;
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;
    public DocumentRecordLogsColumns = [];
    public GrantMaterialDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public grantMaterialCompletedFormViewModel: GrantMaterialCompletedFormViewModel = new GrantMaterialCompletedFormViewModel();
    public get _GrantMaterial(): GrantMaterial {
        return this._TTObject as GrantMaterial;
    }
    private GrantMaterialCompletedForm_DocumentUrl: string = '/api/GrantMaterialService/GrantMaterialCompletedForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.GrantMaterialCompletedForm_DocumentUrl;
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


    public showLoadPanel:boolean = false;
    public LoadPanelMessage: string = "MKYS İşlemi yapılıyor Lütfen Bekleyiniz...";

    public async SendToMKYS_Click(): Promise<void> {

        this.mkysSonucMesaj = '';
        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result === DialogResult.OK) {
            let params = <any>(<ModalActionResult>result).Param;
            try {
                this.showLoadPanel = true;
                for (let log of this._GrantMaterial.DocumentRecordLogs) {
                    if (log.ReceiptNumber == null) {
                        this.mkysSonucMesaj = await StockActionService.SendMKYSForInputDocumentTS(this._GrantMaterial, params.password);
                    }
                    if (log.ReceiptNumber != null) {
                        this.mkysSonucMesaj += log.ReceiptNumber.toString() + " Ayniyat numarası ile MKYSye kaydolmuştur.";
                    }
                }
                this.showLoadPanel = false;
            }
            catch (error) {
                this.showLoadPanel = false;
                ServiceLocator.MessageService.showError(error);
                
            }
            this.popupVisible = true;
        }






        /*for (let log of this._GrantMaterial.DocumentRecordLogs) {
            if (log.ReceiptNumber == null) {
                this.mkysSonucMesaj = await StockActionService.SendMKYSForInputDocumentTS(this._GrantMaterial, "Buraya componentten gelen şifre verilecek");
            }
            if (this._GrantMaterial.MKYS_AyniyatMakbuzID != null && log.ReceiptNumber != null) {
                this.mkysSonucMesaj += log.ReceiptNumber.toString() + ' Ayniyat numarası ile MKYSye kaydolmuştur.';
            }
        }
        this.popupVisible = true;*/
    }

    public async prepareDocument_Click(): Promise<void> {
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._GrantMaterial.ObjectID.toString());
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

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
    }

    onCellContentClicked(data: any) { }
    GrantMaterialDetails_CellValueChangedEmitted(data: any) { }
    initNewRow(data: any) { }
    onRowInserting(data: any) { }
    onSelectionChange(data: any) { }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new GrantMaterial();
        this.grantMaterialCompletedFormViewModel = new GrantMaterialCompletedFormViewModel();
        this._ViewModel = this.grantMaterialCompletedFormViewModel;
        this.grantMaterialCompletedFormViewModel._GrantMaterial = this._TTObject as GrantMaterial;
        this.grantMaterialCompletedFormViewModel._GrantMaterial.DocumentRecordLogs = new Array<DocumentRecordLog>();
        this.grantMaterialCompletedFormViewModel._GrantMaterial.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.grantMaterialCompletedFormViewModel._GrantMaterial.Store = new Store();
        this.grantMaterialCompletedFormViewModel._GrantMaterial.GrantMaterialDetails = new Array<GrantMaterialDetail>();
        this.grantMaterialCompletedFormViewModel._GrantMaterial.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.grantMaterialCompletedFormViewModel = this._ViewModel as GrantMaterialCompletedFormViewModel;
        that._TTObject = this.grantMaterialCompletedFormViewModel._GrantMaterial;
        if (this.grantMaterialCompletedFormViewModel == null) {
            this.grantMaterialCompletedFormViewModel = new GrantMaterialCompletedFormViewModel();
        }
        if (this.grantMaterialCompletedFormViewModel._GrantMaterial == null) {
            this.grantMaterialCompletedFormViewModel._GrantMaterial = new GrantMaterial();
        }
        that.grantMaterialCompletedFormViewModel._GrantMaterial.DocumentRecordLogs = that.grantMaterialCompletedFormViewModel.DocumentRecordLogsGridList;
        for (let detailItem of that.grantMaterialCompletedFormViewModel.DocumentRecordLogsGridList) {
        }
        let budgetTypeDefinitionObjectID = that.grantMaterialCompletedFormViewModel._GrantMaterial['BudgetTypeDefinition'];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === 'string')) {
            let budgetTypeDefinition = that.grantMaterialCompletedFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.grantMaterialCompletedFormViewModel._GrantMaterial.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.grantMaterialCompletedFormViewModel._GrantMaterial['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.grantMaterialCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.grantMaterialCompletedFormViewModel._GrantMaterial.Store = store;
            }
        }
        that.grantMaterialCompletedFormViewModel._GrantMaterial.GrantMaterialDetails = that.grantMaterialCompletedFormViewModel.GrantMaterialDetailsGridList;
        for (let detailItem of that.grantMaterialCompletedFormViewModel.GrantMaterialDetailsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.grantMaterialCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.grantMaterialCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.grantMaterialCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.grantMaterialCompletedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.grantMaterialCompletedFormViewModel._GrantMaterial.StockActionSignDetails = that.grantMaterialCompletedFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.grantMaterialCompletedFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem['SignUser'];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.grantMaterialCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(GrantMaterialCompletedFormViewModel);
        this.DocumentRecordLogSearch.ReadOnly = false;
        this.SendToMKYS.ReadOnly = false;
        this.SendToMKYS.Enabled = true;
        this.MKYS_TeslimAlan.ButtonEnabled = false;
        this.MKYS_TeslimEden.ButtonEnabled = false;
        this.MaterialGranttedBy.ButtonEnabled = false;
        this.DocumentRecordLogDeleteMKYS.ReadOnly = false;
        if (this._GrantMaterial.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._GrantMaterial.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = '#F0F0F0';
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        if (this._GrantMaterial.MaterialGranttedBy != null) {
            this.MaterialGranttedBy.BackColor = '#F0F0F0';
            this.MaterialGranttedBy.ReadOnly = true;
        }
        if (this._GrantMaterial.GranttedByUniqNo != null) {
            this.GranttedByUniqNo.BackColor = '#F0F0F0';
            this.GranttedByUniqNo.ReadOnly = true;
        }
        this.FormCaption = i18n("M11409", "Bağış / Yardım ( Tamamlandı )");

    }

    //dx-data-grid çevirme
    public getIsReadOnly() {
        return true;
    }

    public onBudgetTypeDefinitionChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.BudgetTypeDefinition !== event) {
                this._GrantMaterial.BudgetTypeDefinition = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.Description !== event) {
                this._GrantMaterial.Description = event;
            }
        }
    }

    public onGranttedByUniqNoChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.GranttedByUniqNo !== event) {
                this._GrantMaterial.GranttedByUniqNo = event;
            }
        }
    }

    public onMaterialGranttedByChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial.MaterialGranttedBy != null) {
                this.MaterialGranttedBy.BackColor = '#F0F0F0';
                this.MaterialGranttedBy.ReadOnly = true;
            }
            if (this._GrantMaterial.GranttedByUniqNo != null) {
                this.GranttedByUniqNo.BackColor = '#F0F0F0';
                this.GranttedByUniqNo.ReadOnly = true;
            }
            if (this._GrantMaterial != null && this._GrantMaterial.MaterialGranttedBy !== event) {
                this._GrantMaterial.MaterialGranttedBy = event;
            }
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.MKYS_EMalzemeGrup !== event) {
                this._GrantMaterial.MKYS_EMalzemeGrup = event;
            }
        }
    }

    public onMKYS_ETedarikTuruChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.MKYS_ETedarikTuru !== event) {
                this._GrantMaterial.MKYS_ETedarikTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._GrantMaterial != null && this._GrantMaterial.MKYS_TeslimAlan !== event) {
                this._GrantMaterial.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = '#F0F0F0';
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._GrantMaterial != null && this._GrantMaterial.MKYS_TeslimEden !== event) {
                this._GrantMaterial.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.StockActionID !== event) {
                this._GrantMaterial.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.Store !== event) {
                this._GrantMaterial.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.TransactionDate !== event) {
                this._GrantMaterial.TransactionDate = event;
            }
        }
    }


    public onDocumentRecordLogsRowInserting(data: any): void {

    }
    receiptNumberError: string ="";
    controlOfCancelMKYS: boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        for (let log of this._GrantMaterial.DocumentRecordLogs) {
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







    public onSelectionChangeDocumentRecordLogs(data: any): void {

    }

    DocumentRecordLogs_CellValueChangedEmitted(data: any) {

    }

    public redirectProperties(): void {
        redirectProperty(this.MaterialGranttedBy, 'Text', this.__ttObject, 'MaterialGranttedBy');
        redirectProperty(this.GranttedByUniqNo, 'Text', this.__ttObject, 'GranttedByUniqNo');
        redirectProperty(this.MKYS_EMalzemeGrup, 'Value', this.__ttObject, 'MKYS_EMalzemeGrup');
        redirectProperty(this.MKYS_ETedarikTuru, 'Value', this.__ttObject, 'MKYS_ETedarikTuru');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
        redirectProperty(this.StockActionID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.TransactionDate, 'Value', this.__ttObject, 'TransactionDate');
        redirectProperty(this.MKYS_TeslimEden, 'Text', this.__ttObject, 'MKYS_TeslimEden');
        redirectProperty(this.MKYS_TeslimAlan, 'Text', this.__ttObject, 'MKYS_TeslimAlan');
    }

    public initFormControls(): void {
        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 2;
        this.tttabpage1.TabIndex = 2;
        this.tttabpage1.Text = 'Taşınır Mal İşlem Belgeleri';
        this.tttabpage1.Name = 'tttabpage1';

        this.GranttedByUniqNo = new TTVisual.TTTextBox();
        this.GranttedByUniqNo.Required = true;
        this.GranttedByUniqNo.BackColor = '#FFE3C6';
        this.GranttedByUniqNo.Name = 'GranttedByUniqNo';
        this.GranttedByUniqNo.TabIndex = 129;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = 'TE';
        this.TTTeslimEdenButon.Name = 'TTTeslimEdenButon';
        this.TTTeslimEdenButon.TabIndex = 121;
        this.TTTeslimEdenButon.Height = '20px';

        this.DocumentRecordLogTab = new TTVisual.TTTabPage();
        this.DocumentRecordLogTab.DisplayIndex = 1;
        this.DocumentRecordLogTab.TabIndex = 1;
        this.DocumentRecordLogTab.Text = 'Taşınır Mal İşlem Belgeleri';
        this.DocumentRecordLogTab.Name = 'DocumentRecordLogTab';

        this.MaterialGranttedBy = new TTButtonTextBox();
        this.MaterialGranttedBy.Required = true;
        this.MaterialGranttedBy.BackColor = '#FFE3C6';
        this.MaterialGranttedBy.Name = 'MaterialGranttedBy';
        this.MaterialGranttedBy.TabIndex = 122;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = 'TA';
        this.TTTeslimAlanButon.Name = 'TTTeslimAlanButon';
        this.TTTeslimAlanButon.TabIndex = 120;
        this.TTTeslimAlanButon.Height = '20px';

        this.DocumentRecordLogs = new TTVisual.TTGrid();
        this.DocumentRecordLogs.Name = 'DocumentRecordLogs';
        this.DocumentRecordLogs.TabIndex = 0;
        this.DocumentRecordLogs.Height = 350;
        this.DocumentRecordLogs.AllowUserToAddRows = false;
        this.DocumentRecordLogs.AllowUserToDeleteRows = false;

        this.TTFirma = new TTVisual.TTButton();
        this.TTFirma.Text = i18n("M14301", "Firma");
        this.TTFirma.Name = 'TTFirma';
        this.TTFirma.TabIndex = 133;
        this.TTFirma.Height = '20px';

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = 'labelMKYS_TeslimEden';
        this.labelMKYS_TeslimEden.TabIndex = 119;



        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = i18n("M12146", "Bütçe Türü");
        this.labelBudgetTypeDefinition.Name = 'labelBudgetTypeDefinition';
        this.labelBudgetTypeDefinition.TabIndex = 132;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = '#FFE3C6';
        this.MKYS_TeslimEden.Name = 'MKYS_TeslimEden';
        this.MKYS_TeslimEden.TabIndex = 118;



        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.ReadOnly = true;
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.BackColor = '#FFE3C6';
        this.BudgetTypeDefinition.Name = 'BudgetTypeDefinition';
        this.BudgetTypeDefinition.TabIndex = 131;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = '10%';
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = '20%';

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = '#FFE3C6';
        this.MKYS_TeslimAlan.Name = 'MKYS_TeslimAlan';
        this.MKYS_TeslimAlan.TabIndex = 116;



        this.labelGranttedByUniqNo = new TTVisual.TTLabel();
        this.labelGranttedByUniqNo.Text = i18n("M11416", "Bağış Yapan TC / Kurum Vergi No");
        this.labelGranttedByUniqNo.Name = 'labelGranttedByUniqNo';
        this.labelGranttedByUniqNo.TabIndex = 130;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = 'Description';
        this.Description.TabIndex = 0;

        this.BUDGETYPE = new TTVisual.TTEnumComboBoxColumn();
        this.BUDGETYPE.DataTypeName = 'MKYS_EButceTurEnum';
        this.BUDGETYPE.DataMember = 'BudgeType';
        this.BUDGETYPE.DisplayIndex = 3;
        this.BUDGETYPE.HeaderText = i18n("M12145", "Bütçe Tipi");
        this.BUDGETYPE.Name = 'BUDGETYPE';
        this.BUDGETYPE.ReadOnly = true;
        this.BUDGETYPE.Width = 100;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = i18n("M18581", "Malzeme Grup");
        this.labelMKYS_EMalzemeGrup.Name = 'labelMKYS_EMalzemeGrup';
        this.labelMKYS_EMalzemeGrup.TabIndex = 128;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = '#F0F0F0';
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = 'StockActionID';
        this.StockActionID.TabIndex = 0;



        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = 'MKYS_EMalzemeGrupEnum';
        this.MKYS_EMalzemeGrup.BackColor = '#F0F0F0';
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = 'MKYS_EMalzemeGrup';
        this.MKYS_EMalzemeGrup.TabIndex = 127;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = 'labelMKYS_TeslimAlan';
        this.labelMKYS_TeslimAlan.TabIndex = 117;



        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = 'MainStoreList';
        this.Store.Name = 'Store';
        this.Store.TabIndex = 126;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = 'labelTransactionDate';
        this.labelTransactionDate.TabIndex = 115;



        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M11412", "Bağış / Yardım Yapılan Depo");
        this.labelDestinationStore.Name = 'labelDestinationStore';
        this.labelDestinationStore.TabIndex = 125;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = '#F0F0F0';
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = 'TransactionDate';
        this.TransactionDate.TabIndex = 1;

        this.SendToMKYS = new TTVisual.TTButton();
        this.SendToMKYS.Text = 'MKYS\'ye Gönder';
        this.SendToMKYS.Name = 'SendToMKYS';
        this.SendToMKYS.TabIndex = 126;




        this.labelMaterialGranttedBy = new TTVisual.TTLabel();
        this.labelMaterialGranttedBy.Text = i18n("M11415", "Bağış Yapan Kişi / Kurum");
        this.labelMaterialGranttedBy.Name = 'labelMaterialGranttedBy';
        this.labelMaterialGranttedBy.TabIndex = 123;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = 'labelStockActionID';
        this.labelStockActionID.TabIndex = 113;

        this.ChattelDocumentTabcontrol = new TTVisual.TTTabControl();
        this.ChattelDocumentTabcontrol.Name = 'ChattelDocumentTabcontrol';
        this.ChattelDocumentTabcontrol.TabIndex = 120;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = 'DescriptionAndSignTabControl';
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.ChattelDocumentDetailTabpage = new TTVisual.TTTabPage();
        this.ChattelDocumentDetailTabpage.DisplayIndex = 0;
        this.ChattelDocumentDetailTabpage.TabIndex = 0;
        this.ChattelDocumentDetailTabpage.Text = 'Taşınır Malın';
        this.ChattelDocumentDetailTabpage.Name = 'ChattelDocumentDetailTabpage';

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = 'SignTabpage';

        this.GrantMaterialDetails = new TTVisual.TTGrid();
        this.GrantMaterialDetails.Name = 'GrantMaterialDetails';
        this.GrantMaterialDetails.TabIndex = 127;
        this.GrantMaterialDetails.Height = 350;
        this.GrantMaterialDetails.AllowUserToAddRows = false;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = 'StockActionSignDetails';
        this.StockActionSignDetails.TabIndex = 0;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = '';
        this.Detail.Name = 'Detail';
        this.Detail.Width = 100;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = 'SignUserTypeEnum';
        this.SignUserType.DataMember = 'SignUserType';
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = 'SignUserType';
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.MaterialGrantMaterialDetail = new TTVisual.TTListBoxColumn();
        this.MaterialGrantMaterialDetail.ListDefName = 'MaterialListDefinition';
        this.MaterialGrantMaterialDetail.DataMember = 'Material';
        this.MaterialGrantMaterialDetail.DisplayIndex = 1;
        this.MaterialGrantMaterialDetail.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialGrantMaterialDetail.AutoCompleteDialogHeight = '60%';
        this.MaterialGrantMaterialDetail.AutoCompleteDialogWidth = '90%';
        this.MaterialGrantMaterialDetail.Name = 'MaterialGrantMaterialDetail';
        this.MaterialGrantMaterialDetail.Width = 300;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = 'UserListDefinition';
        this.SignUser.DataMember = 'SignUser';
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = 'SignUser';
        this.SignUser.Width = 400;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = 'Material.Barcode';
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = 'Barkod';
        this.Barcode.Name = 'Barcode';
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = 'IsDeputy';
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = 'IsDeputy';
        this.IsDeputy.Width = 50;

        this.DistiributionType = new TTVisual.TTTextBoxColumn();
        this.DistiributionType.DataMember = 'Material.DistributionTypeName';
        this.DistiributionType.DisplayIndex = 3;
        this.DistiributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistiributionType.Name = 'DistiributionType';
        this.DistiributionType.ReadOnly = true;
        this.DistiributionType.Width = 140;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 111;

        this.AmountGrantMaterialDetail = new TTVisual.TTTextBoxColumn();
        this.AmountGrantMaterialDetail.DataMember = 'Amount';
        this.AmountGrantMaterialDetail.Format = '#,###.#########';
        this.AmountGrantMaterialDetail.DisplayIndex = 4;
        this.AmountGrantMaterialDetail.HeaderText = i18n("M10707", "Alınan Miktar");
        this.AmountGrantMaterialDetail.Name = 'AmountGrantMaterialDetail';
        this.AmountGrantMaterialDetail.Width = 120;
        this.AmountGrantMaterialDetail.IsNumeric = true;

        this.NotDiscountedUnitPrice = new TTVisual.TTTextBoxColumn();
        this.NotDiscountedUnitPrice.DataMember = 'NotDiscountedUnitPrice';
        this.NotDiscountedUnitPrice.DisplayIndex = 5;
        this.NotDiscountedUnitPrice.HeaderText = i18n("M16508", "İndirimsiz Birim Fiyat");
        this.NotDiscountedUnitPrice.Name = 'NotDiscountedUnitPrice';
        this.NotDiscountedUnitPrice.Width = 140;
        this.NotDiscountedUnitPrice.IsNumeric = true;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = 'UnitPrice';
        this.UnitPrice.DisplayIndex = 6;
        this.UnitPrice.HeaderText = i18n("M11855", "Birim Fiyat");
        this.UnitPrice.Name = 'UnitPrice';
        this.UnitPrice.Width = 120;
        this.UnitPrice.IsNumeric = true;

        this.LotNoGrantMaterialDetail = new TTVisual.TTTextBoxColumn();
        this.LotNoGrantMaterialDetail.DataMember = 'LotNo';
        this.LotNoGrantMaterialDetail.DisplayIndex = 7;
        this.LotNoGrantMaterialDetail.HeaderText = i18n("M18356", "Lot Nu.");
        this.LotNoGrantMaterialDetail.Name = 'LotNoGrantMaterialDetail';
        this.LotNoGrantMaterialDetail.Width = 120;

        this.ExpirationDateGrantMaterialDetail = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDateGrantMaterialDetail.CustomFormat = 'MM/yyyy';
        this.ExpirationDateGrantMaterialDetail.DataMember = 'ExpirationDate';
        this.ExpirationDateGrantMaterialDetail.DisplayIndex = 8;
        this.ExpirationDateGrantMaterialDetail.HeaderText = i18n("M22057", "Son Kullanma Tarihi");
        this.ExpirationDateGrantMaterialDetail.Name = 'ExpirationDateGrantMaterialDetail';
        this.ExpirationDateGrantMaterialDetail.Width = 180;

        this.StockLevelType = new TTVisual.TTListBoxColumn();
        this.StockLevelType.ListDefName = 'StockLevelTypeList';
        this.StockLevelType.DataMember = 'StockLevelType';
        this.StockLevelType.DisplayIndex = 9;
        this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelType.Name = 'StockLevelType';
        this.StockLevelType.Width = 120;

        this.RetrievalYearGrantMaterialDetail = new TTVisual.TTTextBoxColumn();
        this.RetrievalYearGrantMaterialDetail.DataMember = 'RetrievalYear';
        this.RetrievalYearGrantMaterialDetail.DisplayIndex = 10;
        this.RetrievalYearGrantMaterialDetail.HeaderText = 'EdinimYili';
        this.RetrievalYearGrantMaterialDetail.Name = 'RetrievalYearGrantMaterialDetail';
        this.RetrievalYearGrantMaterialDetail.Width = 120;

        this.ProductionDateGrantMaterialDetail = new TTVisual.TTDateTimePickerColumn();
        this.ProductionDateGrantMaterialDetail.DataMember = 'ProductionDate';
        this.ProductionDateGrantMaterialDetail.DisplayIndex = 11;
        this.ProductionDateGrantMaterialDetail.HeaderText = 'UretimTarihi';
        this.ProductionDateGrantMaterialDetail.Name = 'ProductionDateGrantMaterialDetail';
        this.ProductionDateGrantMaterialDetail.Width = 180;

        this.MKYS_ETedarikTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_ETedarikTuru.DataTypeName = 'MKYS_ETedarikTurEnum';
        this.MKYS_ETedarikTuru.Required = true;
        this.MKYS_ETedarikTuru.BackColor = '#F0F0F0';
        this.MKYS_ETedarikTuru.Enabled = false;
        this.MKYS_ETedarikTuru.Name = 'MKYS_ETedarikTuru';
        this.MKYS_ETedarikTuru.TabIndex = 15;

        this.labelMKYS_ETedarikTuru = new TTVisual.TTLabel();
        this.labelMKYS_ETedarikTuru.Text = i18n("M22969", "Tedarik Türü");
        this.labelMKYS_ETedarikTuru.Name = 'labelMKYS_ETedarikTuru';
        this.labelMKYS_ETedarikTuru.TabIndex = 14;


        this.DocumentRecordLogNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DocumentRecordLogNumberDocumentRecordLog.DataMember = 'DocumentRecordLogNumber';
        this.DocumentRecordLogNumberDocumentRecordLog.DisplayIndex = 1;
        this.DocumentRecordLogNumberDocumentRecordLog.HeaderText = i18n("M11746", "Belge Numarası");
        this.DocumentRecordLogNumberDocumentRecordLog.Name = 'DocumentRecordLogNumberDocumentRecordLog';
        this.DocumentRecordLogNumberDocumentRecordLog.Width = 120;

        this.DocumentDateTimeDocumentRecordLog = new TTVisual.TTDateTimePickerColumn();
        this.DocumentDateTimeDocumentRecordLog.DataMember = 'DocumentDateTime';
        this.DocumentDateTimeDocumentRecordLog.DisplayIndex = 0;
        this.DocumentDateTimeDocumentRecordLog.HeaderText = i18n("M11748", "Belge Tarihi");
        this.DocumentDateTimeDocumentRecordLog.Name = 'DocumentDateTimeDocumentRecordLog';
        this.DocumentDateTimeDocumentRecordLog.Width = 180;

        this.DocumentTransactionTypeDocumentRecordLog = new TTVisual.TTEnumComboBoxColumn();
        this.DocumentTransactionTypeDocumentRecordLog.DataMember = 'DocumentTransactionType';
        this.DocumentTransactionTypeDocumentRecordLog.DisplayIndex = 2;
        this.DocumentTransactionTypeDocumentRecordLog.HeaderText = i18n("M16834", "İşlem Çeşidi");
        this.DocumentTransactionTypeDocumentRecordLog.Name = 'DocumentTransactionTypeDocumentRecordLog';
        this.DocumentTransactionTypeDocumentRecordLog.Width = 180;

        this.BudgeTypeEnum = new TTVisual.TTEnumComboBoxColumn();
        this.BudgeTypeEnum.DataTypeName = "MKYS_EButceTurEnum";
        this.BudgeTypeEnum.DataMember = "BudgeType";
        this.BudgeTypeEnum.DisplayIndex = 3;
        this.BudgeTypeEnum.HeaderText = i18n("M12145", "Bütçe Tipi");
        this.BudgeTypeEnum.Name = "BudgeTypeEnum";
        this.BudgeTypeEnum.ReadOnly = true;
        this.BudgeTypeEnum.Width = 140;

        this.SubjectDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.SubjectDocumentRecordLog.DataMember = 'Subject';
        this.SubjectDocumentRecordLog.DisplayIndex = 4;
        this.SubjectDocumentRecordLog.HeaderText = i18n("M14797", "Giriş ,Çıkış Nedenleri");
        this.SubjectDocumentRecordLog.Name = 'SubjectDocumentRecordLog';
        this.SubjectDocumentRecordLog.Width = 200;

        this.NumberOfRowsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.NumberOfRowsDocumentRecordLog.DataMember = "NumberOfRows";
        this.NumberOfRowsDocumentRecordLog.DisplayIndex = 5;
        this.NumberOfRowsDocumentRecordLog.HeaderText = i18n("M17091", "Kalem Adedi");
        this.NumberOfRowsDocumentRecordLog.Name = "NumberOfRowsDocumentRecordLog";
        this.NumberOfRowsDocumentRecordLog.Width = 80;
        this.NumberOfRowsDocumentRecordLog.Visible = false;

        this.TakenGivenPlaceDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.TakenGivenPlaceDocumentRecordLog.DataMember = "TakenGivenPlace";
        this.TakenGivenPlaceDocumentRecordLog.DisplayIndex = 6;
        this.TakenGivenPlaceDocumentRecordLog.HeaderText = i18n("M10714", "Alındığı / Verildiği Yer");
        this.TakenGivenPlaceDocumentRecordLog.Name = "TakenGivenPlaceDocumentRecordLog";
        this.TakenGivenPlaceDocumentRecordLog.Width = 200;
        this.TakenGivenPlaceDocumentRecordLog.Visible = false;

        this.ReceiptNumber = new TTVisual.TTTextBoxColumn();
        this.ReceiptNumber.DataMember = 'ReceiptNumber';
        this.ReceiptNumber.DisplayIndex = 5;
        this.ReceiptNumber.HeaderText = 'Ayniyat Makbuz No';
        this.ReceiptNumber.Name = 'ReceiptNumber';
        this.ReceiptNumber.ReadOnly = true;
        this.ReceiptNumber.Width = 140;

        this.DescriptionsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DescriptionsDocumentRecordLog.DataMember = 'Descriptions';
        this.DescriptionsDocumentRecordLog.DisplayIndex = 6;
        this.DescriptionsDocumentRecordLog.HeaderText = i18n("M10483", "Açıklamalar");
        this.DescriptionsDocumentRecordLog.Name = 'DescriptionsDocumentRecordLog';
        this.DescriptionsDocumentRecordLog.Width = 200;

        this.DocumentRecordLogSearch = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogSearch.Text = 'MKYS Log Sorgula';
        this.DocumentRecordLogSearch.Name = 'GetLogFromMkys';

        this.DocumentRecordLogDeleteMKYS = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogDeleteMKYS.Text = 'MKYS Kayıt Sil';
        this.DocumentRecordLogDeleteMKYS.Name = 'DeleteMkysRow';

        this.DocumentRecordLogsColumns = [this.DocumentRecordLogNumberDocumentRecordLog, this.DocumentDateTimeDocumentRecordLog,
            this.DocumentTransactionTypeDocumentRecordLog, this.BudgeTypeEnum, this.SubjectDocumentRecordLog, this.NumberOfRowsDocumentRecordLog,
            this.TakenGivenPlaceDocumentRecordLog, this.ReceiptNumber, this.DescriptionsDocumentRecordLog,this.DocumentRecordLogDeleteMKYS, this.DocumentRecordLogSearch];
        this.GrantMaterialDetailsColumns = [this.MaterialGrantMaterialDetail, this.Barcode, this.DistiributionType,
        this.AmountGrantMaterialDetail, this.NotDiscountedUnitPrice, this.UnitPrice, this.LotNoGrantMaterialDetail,
        this.ExpirationDateGrantMaterialDetail, this.StockLevelType, this.RetrievalYearGrantMaterialDetail, this.ProductionDateGrantMaterialDetail];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.DocumentRecordLogTab.Controls = [this.DocumentRecordLogs];
        this.ChattelDocumentTabcontrol.Controls = [this.DocumentRecordLogTab, this.ChattelDocumentDetailTabpage];
        this.DescriptionAndSignTabControl.Controls = [this.tttabpage1, this.SignTabpage];
        this.ChattelDocumentDetailTabpage.Controls = [this.GrantMaterialDetails];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.tttabpage1, this.GranttedByUniqNo, this.TTTeslimEdenButon, this.DocumentRecordLogTab, this.MaterialGranttedBy,
        this.TTTeslimAlanButon, this.DocumentRecordLogs, this.TTFirma, this.labelMKYS_TeslimEden, this.DocumentDateTimeDocumentRecordLog,
        this.labelBudgetTypeDefinition, this.MKYS_TeslimEden, this.DocumentRecordLogNumberDocumentRecordLog, this.BudgetTypeDefinition,
        this.MKYS_TeslimAlan, this.DocumentTransactionTypeDocumentRecordLog, this.labelGranttedByUniqNo, this.Description, this.BUDGETYPE,
        this.labelMKYS_EMalzemeGrup, this.StockActionID, this.SubjectDocumentRecordLog, this.MKYS_EMalzemeGrup, this.labelMKYS_TeslimAlan,
        this.ReceiptNumber, this.Store, this.labelTransactionDate, this.DescriptionsDocumentRecordLog, this.labelDestinationStore, this.TransactionDate,
        this.SendToMKYS, this.labelMaterialGranttedBy, this.labelStockActionID, this.ChattelDocumentTabcontrol, this.DescriptionAndSignTabControl,
        this.ChattelDocumentDetailTabpage, this.SignTabpage, this.GrantMaterialDetails, this.StockActionSignDetails, this.SignUserType,
        this.MaterialGrantMaterialDetail, this.SignUser, this.Barcode, this.IsDeputy, this.DistiributionType, this.ttlabel1, this.AmountGrantMaterialDetail,
        this.NotDiscountedUnitPrice, this.UnitPrice, this.LotNoGrantMaterialDetail, this.ExpirationDateGrantMaterialDetail, this.StockLevelType,
        this.RetrievalYearGrantMaterialDetail, this.ProductionDateGrantMaterialDetail, this.MKYS_ETedarikTuru, this.labelMKYS_ETedarikTuru, this.DocumentRecordLogSearch];

    }
}
