//$4CAF1DEC
import { Component, OnInit, NgZone } from '@angular/core';
import { DistributionDocumentCompletedFormViewModel } from './DistributionDocumentCompletedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { StockActionService, OutputForReGeneration, DocumentRecordLogReceiptNumber_Input } from 'ObjectClassService/StockActionService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseDistributionDocumentForm } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Dagitim_Belgesi_Modulu/BaseDistributionDocumentForm';
import { DistributionDocument } from 'NebulaClient/Model/AtlasClientModel';
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DistributionDocumentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { IModalService } from 'Fw/Services/IModalService';
import { UsernamePwdBox } from 'NebulaClient/Visual/UsernamePwdBox';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { ModalActionResult } from "Fw/Models/ModalInfo";
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import Exception from 'app/NebulaClient/System/Exception';

@Component({
    selector: 'DistributionDocumentCompletedForm',
    templateUrl: './DistributionDocumentCompletedForm.html',
    providers: [MessageService]
})
export class DistributionDocumentCompletedForm extends BaseDistributionDocumentForm implements OnInit {
    BudgeTypeEnum: TTVisual.ITTEnumComboBoxColumn;
    DescriptionsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentDateTimeDocumentRecordLog: TTVisual.ITTDateTimePickerColumn;
    DocumentRecordLogNumberDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogs: TTVisual.ITTGrid;
    DocumentrecordLogTab: TTVisual.ITTTabPage;
    DocumentTransactionTypeDocumentRecordLog: TTVisual.ITTEnumComboBoxColumn;
    IsAutoDistribution: TTVisual.ITTCheckBox;
    labelRegistrationNumber: TTVisual.ITTLabel;
    labelSequenceNumber: TTVisual.ITTLabel;
    NumberOfRowsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    ReceiptNumber: TTVisual.ITTTextBoxColumn;
    RegistrationNumber: TTVisual.ITTTextBox;
    SequenceNumber: TTVisual.ITTTextBox;
    SubjectDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;
    ttMkysSend: TTVisual.ITTButton;
    tttabpage1: TTVisual.ITTTabPage;
    //public DistributionDocumentMaterialsColumns = [];
    public DocumentRecordLogsColumns = [];
    public DistributionDocumentMaterialsColumns = [
        {
            caption: 'Malzeme Adı',
            dataField: 'Material.Name',
            allowEditing: false,
            width: 350
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false
        },
        {
            caption: 'Ölçü Birimi',
            dataField: 'Material.DistributionTypeName',
            allowEditing: false
        },
        {
            caption: 'İstenen Miktar',
            dataField: 'AcceptedAmount',
            dataType: 'number'
        },
        {
            caption: 'Verilen Miktar',
            dataField: 'Amount',
            dataType: 'number',
        },
        {
            caption: 'Toplam Tutar',
            dataField: 'TotalPrice',
            dataType: 'number',
        },
        {
            caption: 'Künye No',
            dataField: 'TagNo',
            allowEditing: false
        },
        {
            caption: 'Malın Durumu',
            dataField: 'StockLevelType.Description',
            allowEditing: false
            //width: 250
        }
    ];
    public StockActionSignDetailsColumns = [];
    public distributionDocumentCompletedFormViewModel: DistributionDocumentCompletedFormViewModel = new DistributionDocumentCompletedFormViewModel();
    public get _DistributionDocument(): DistributionDocument {
        return this._TTObject as DistributionDocument;
    }
    private DistributionDocumentCompletedForm_DocumentUrl: string = '/api/DistributionDocumentService/DistributionDocumentCompletedForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private reportService: AtlasReportService, protected modalService: IModalService, protected objectContextService: ObjectContextService,
        protected ngZone: NgZone) {
        super(httpService, messageService, modalService, objectContextService, ngZone);
        this._DocumentServiceUrl = this.DistributionDocumentCompletedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    public mkysSonucMesaj: string;
    popupVisible: boolean = false;
    reGenerateButtonVisible: boolean = true;
    public async ttMkysSend_Click(): Promise<void> {
        this.mkysSonucMesaj = '';
        if (this._DistributionDocument.CurrentStateDefID.toString() === DistributionDocument.DistributionDocumentStates.Completed.id) {
            let result = await UsernamePwdBox.Show(true);
            for (let log of this._DistributionDocument.DocumentRecordLogs) {
                if (log.ReceiptNumber == null) {
                    if ((<ModalActionResult>result).Result == DialogResult.OK) {
                        let params = <any>(<ModalActionResult>result).Param;
                        this.mkysSonucMesaj += await StockActionService.SendMKYSForOutputDocumentTS(this._DistributionDocument, params.password);
                    }
                }
                if (log.ReceiptNumber != null) {
                    this.mkysSonucMesaj += log.ReceiptNumber.toString() + ' Ayniyat numarası ile MKYSye kaydolmuştur.';
                }
            }
        }
        if (this._DistributionDocument.CurrentStateDefID.toString() === DistributionDocument.DistributionDocumentStates.Cancelled.id) {
            let result = await UsernamePwdBox.Show(true);
            for (let log of this._DistributionDocument.DocumentRecordLogs) {
                if (log.ReceiptNumber != null) {
                    if ((<ModalActionResult>result).Result == DialogResult.OK) {
                        let params = <any>(<ModalActionResult>result).Param;
                        this.mkysSonucMesaj = await StockActionService.SendDeleteMessageToMkysTS(this._DistributionDocument, true, log.ReceiptNumber.Value, params.password);
                    }
                }
            }
        }
        if (String.isNullOrEmpty(this.mkysSonucMesaj) == false)
            this.popupVisible = true;
    }
    public async prepareDocument_Click(): Promise<void> {
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._DistributionDocument.ObjectID.toString());
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

    protected async ClientSidePreScript(): Promise<void> {

        if (this._DistributionDocument.CurrentStateDefID.toString() == DistributionDocument.DistributionDocumentStates.Completed.id.toString()) {
            this.reGenerateButtonVisible = false;
        }

    }

    public async reGenerateAction_Click(): Promise<void> {
        let result: OutputForReGeneration = null;
        try {
            result = await StockActionService.ReGenerateMyDistributionDocument(this._DistributionDocument.ObjectID.toString());
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

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);

    }
    receiptNumberError: string ="";
    controlOfCancelMKYS: boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        for (let log of this._DistributionDocument.DocumentRecordLogs) {
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

    onCellContentClicked(data: any) { }
    DistributionDocumentMaterials_CellValueChangedEmitted(data: any) { }
    initNewRow(data: any) { }
    onRowInserting(data: any) { }
    onSelectionChange(data: any) { }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DistributionDocument();
        this.distributionDocumentCompletedFormViewModel = new DistributionDocumentCompletedFormViewModel();
        this._ViewModel = this.distributionDocumentCompletedFormViewModel;
        this.distributionDocumentCompletedFormViewModel._DistributionDocument = this._TTObject as DistributionDocument;
        this.distributionDocumentCompletedFormViewModel._DistributionDocument.DocumentRecordLogs = new Array<DocumentRecordLog>();
        this.distributionDocumentCompletedFormViewModel._DistributionDocument.Store = new Store();
        this.distributionDocumentCompletedFormViewModel._DistributionDocument.DestinationStore = new Store();
        this.distributionDocumentCompletedFormViewModel._DistributionDocument.DistributionDocumentMaterials = new Array<DistributionDocumentMaterial>();
        this.distributionDocumentCompletedFormViewModel._DistributionDocument.StockActionSignDetails = new Array<StockActionSignDetail>();
    }
    public IsEmergencyMaterial:boolean;
    protected loadViewModel() {
        let that = this;
        that.distributionDocumentCompletedFormViewModel = this._ViewModel;
        this.IsEmergencyMaterial = this.distributionDocumentCompletedFormViewModel._DistributionDocument.IsEmergencyMaterial;
        that._TTObject = this.distributionDocumentCompletedFormViewModel._DistributionDocument;
        if (this.distributionDocumentCompletedFormViewModel == null) {
            this.distributionDocumentCompletedFormViewModel = new DistributionDocumentCompletedFormViewModel();
        }
        if (this.distributionDocumentCompletedFormViewModel._DistributionDocument == null) {
            this.distributionDocumentCompletedFormViewModel._DistributionDocument = new DistributionDocument();
        }
        that.distributionDocumentCompletedFormViewModel._DistributionDocument.DocumentRecordLogs = that.distributionDocumentCompletedFormViewModel.DocumentRecordLogsGridList;
        for (let detailItem of that.distributionDocumentCompletedFormViewModel.DocumentRecordLogsGridList) {
        }
        let storeObjectID = that.distributionDocumentCompletedFormViewModel._DistributionDocument['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.distributionDocumentCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.distributionDocumentCompletedFormViewModel._DistributionDocument.Store = store;
            }
        }
        let destinationStoreObjectID = that.distributionDocumentCompletedFormViewModel._DistributionDocument['DestinationStore'];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.distributionDocumentCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.distributionDocumentCompletedFormViewModel._DistributionDocument.DestinationStore = destinationStore;
            }
        }
        that.distributionDocumentCompletedFormViewModel._DistributionDocument.DistributionDocumentMaterials = that.distributionDocumentCompletedFormViewModel.DistributionDocumentMaterialsGridList;
        for (let detailItem of that.distributionDocumentCompletedFormViewModel.DistributionDocumentMaterialsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.distributionDocumentCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.distributionDocumentCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType =
                                    that.distributionDocumentCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.distributionDocumentCompletedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.distributionDocumentCompletedFormViewModel._DistributionDocument.StockActionSignDetails = that.distributionDocumentCompletedFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.distributionDocumentCompletedFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem['SignUser'];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.distributionDocumentCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(DistributionDocumentCompletedFormViewModel);
        this.MKYS_TeslimAlan.ButtonEnabled = false;
        this.MKYS_TeslimEden.ButtonEnabled = false;
        this.DocumentRecordLogDeleteMKYS.ReadOnly = false;
        if (this._DistributionDocument.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._DistributionDocument.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = '#F0F0F0';
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        if (this._DistributionDocument.CurrentStateDefID.toString() == DistributionDocument.DistributionDocumentStates.Completed.id.toString()) {
            this.FormCaption = i18n("M12437", "Dağıtım Belgesi ( Tamamlandı )");
        }
        if (this._DistributionDocument.CurrentStateDefID.toString() == DistributionDocument.DistributionDocumentStates.Cancelled.id.toString()) {
            this.FormCaption = i18n("M12435", "Dağıtım Belgesi ( İptal Edildi )");
        }

    }


    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.Description !== event) {
                this._DistributionDocument.Description = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.DestinationStore !== event) {
                this._DistributionDocument.DestinationStore = event;
            }
        }
    }

    public onIsAutoDistributionChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this.IsAutoDistribution !== event) {
                this.IsAutoDistribution = event;
            }
        }
    }

    public onMKYS_CikisIslemTuruChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.MKYS_CikisIslemTuru !== event) {
                this._DistributionDocument.MKYS_CikisIslemTuru = event;
            }
        }
    }

    public onMKYS_CikisStokHareketTuruChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.MKYS_CikisStokHareketTuru !== event) {
                this._DistributionDocument.MKYS_CikisStokHareketTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._DistributionDocument != null && this._DistributionDocument.MKYS_TeslimAlan !== event) {
                this._DistributionDocument.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = '#F0F0F0';
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._DistributionDocument != null && this._DistributionDocument.MKYS_TeslimEden !== event) {
                this._DistributionDocument.MKYS_TeslimEden = event;
            }
        }
    }

    public onRegistrationNumberChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.RegistrationNumber !== event) {
                this._DistributionDocument.RegistrationNumber = event;
            }
        }
    }

    public onSequenceNumberChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.SequenceNumber !== event) {
                this._DistributionDocument.SequenceNumber = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.StockActionID !== event) {
                this._DistributionDocument.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.Store !== event) {
                this._DistributionDocument.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.TransactionDate !== event) {
                this._DistributionDocument.TransactionDate = event;
            }
        }
    }



    public redirectProperties(): void {
        redirectProperty(this.StockActionID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.TransactionDate, 'Value', this.__ttObject, 'TransactionDate');
        redirectProperty(this.MKYS_CikisStokHareketTuru, 'Value', this.__ttObject, 'MKYS_CikisStokHareketTuru');
        redirectProperty(this.MKYS_CikisIslemTuru, 'Value', this.__ttObject, 'MKYS_CikisIslemTuru');
        redirectProperty(this.MKYS_TeslimAlan, 'Text', this.__ttObject, 'MKYS_TeslimAlan');
        redirectProperty(this.MKYS_TeslimEden, 'Text', this.__ttObject, 'MKYS_TeslimEden');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
        redirectProperty(this.RegistrationNumber, 'Text', this.__ttObject, 'RegistrationNumber');
        redirectProperty(this.SequenceNumber, 'Text', this.__ttObject, 'SequenceNumber');
        redirectProperty(this.IsAutoDistribution, 'Value', this.__ttObject, 'IsAutoDistribution');
    }

    public initFormControls(): void {


        this.IsAutoDistribution = new TTVisual.TTCheckBox();
        this.IsAutoDistribution.Value = false;
        this.IsAutoDistribution.Enabled = false;
        this.IsAutoDistribution.Name = 'IsAutoDistribution';
        this.IsAutoDistribution.TabIndex = 140;
        this.IsAutoDistribution.Title = i18n("M19814", "Otomatik Dağıtım Belgesi");
        this.IsAutoDistribution.ReadOnly = true;




        this.DocumentrecordLogTab = new TTVisual.TTTabPage();
        this.DocumentrecordLogTab.DisplayIndex = 1;
        this.DocumentrecordLogTab.TabIndex = 1;
        this.DocumentrecordLogTab.Text = 'Taşınır Mal İşlem Belgeleri';
        this.DocumentrecordLogTab.Name = 'DocumentrecordLogTab';

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = 'labelMKYS_TeslimEden';
        this.labelMKYS_TeslimEden.TabIndex = 139;

        this.DocumentRecordLogs = new TTVisual.TTGrid();
        this.DocumentRecordLogs.Name = 'DocumentRecordLogs';
        this.DocumentRecordLogs.TabIndex = 0;
        this.DocumentRecordLogs.Height = 350;
        this.DocumentRecordLogs.AllowUserToAddRows = false;
        this.DocumentRecordLogs.AllowUserToDeleteRows = false;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = '#FFE3C6';
        this.MKYS_TeslimEden.Name = 'MKYS_TeslimEden';
        this.MKYS_TeslimEden.TabIndex = 138;

        this.DocumentDateTimeDocumentRecordLog = new TTVisual.TTDateTimePickerColumn();
        this.DocumentDateTimeDocumentRecordLog.DataMember = 'DocumentDateTime';
        this.DocumentDateTimeDocumentRecordLog.DisplayIndex = 0;
        this.DocumentDateTimeDocumentRecordLog.HeaderText = i18n("M11748", "Belge Tarihi");
        this.DocumentDateTimeDocumentRecordLog.Name = 'DocumentDateTimeDocumentRecordLog';
        this.DocumentDateTimeDocumentRecordLog.Width = 180;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = '#FFE3C6';
        this.MKYS_TeslimAlan.Name = 'MKYS_TeslimAlan';
        this.MKYS_TeslimAlan.TabIndex = 136;

        this.DocumentRecordLogNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DocumentRecordLogNumberDocumentRecordLog.DataMember = 'DocumentRecordLogNumber';
        this.DocumentRecordLogNumberDocumentRecordLog.DisplayIndex = 1;
        this.DocumentRecordLogNumberDocumentRecordLog.HeaderText = i18n("M11746", "Belge Numarası");
        this.DocumentRecordLogNumberDocumentRecordLog.Name = 'DocumentRecordLogNumberDocumentRecordLog';
        this.DocumentRecordLogNumberDocumentRecordLog.Width = 120;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.Description.Name = 'Description';
        this.Description.TabIndex = 6;

        this.DocumentTransactionTypeDocumentRecordLog = new TTVisual.TTEnumComboBoxColumn();
        this.DocumentTransactionTypeDocumentRecordLog.DataTypeName = 'DocumentTransactionTypeEnum';
        this.DocumentTransactionTypeDocumentRecordLog.DataMember = 'DocumentTransactionType';
        this.DocumentTransactionTypeDocumentRecordLog.DisplayIndex = 2;
        this.DocumentTransactionTypeDocumentRecordLog.HeaderText = i18n("M16834", "İşlem Çeşidi");
        this.DocumentTransactionTypeDocumentRecordLog.Name = 'DocumentTransactionTypeDocumentRecordLog';
        this.DocumentTransactionTypeDocumentRecordLog.Width = 140;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = 'labelMKYS_TeslimAlan';
        this.labelMKYS_TeslimAlan.TabIndex = 137;

        this.NumberOfRowsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.NumberOfRowsDocumentRecordLog.DataMember = 'NumberOfRows';
        this.NumberOfRowsDocumentRecordLog.DisplayIndex = 3;
        this.NumberOfRowsDocumentRecordLog.HeaderText = i18n("M17091", "Kalem Adedi");
        this.NumberOfRowsDocumentRecordLog.Name = 'NumberOfRowsDocumentRecordLog';
        this.NumberOfRowsDocumentRecordLog.Width = 120;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = 'labelStore';
        this.labelStore.TabIndex = 135;

        this.BudgeTypeEnum = new TTVisual.TTEnumComboBoxColumn();
        this.BudgeTypeEnum.DataTypeName = 'MKYS_EButceTurEnum';
        this.BudgeTypeEnum.DataMember = 'BudgeType';
        this.BudgeTypeEnum.DisplayIndex = 4;
        this.BudgeTypeEnum.HeaderText = i18n("M12145", "Bütçe Tipi");
        this.BudgeTypeEnum.Name = 'BudgeTypeEnum';
        this.BudgeTypeEnum.ReadOnly = true;
        this.BudgeTypeEnum.Width = 140;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = 'MainStoreList';
        this.Store.Name = 'Store';
        this.Store.TabIndex = 134;

        this.SubjectDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.SubjectDocumentRecordLog.DataMember = 'Subject';
        this.SubjectDocumentRecordLog.DisplayIndex = 5;
        this.SubjectDocumentRecordLog.HeaderText = i18n("M14805", "Giriş ve Çıkış Nedenleri");
        this.SubjectDocumentRecordLog.Name = 'SubjectDocumentRecordLog';
        this.SubjectDocumentRecordLog.Width = 160;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M10678", "Alan Depo");
        this.labelDestinationStore.Name = 'labelDestinationStore';
        this.labelDestinationStore.TabIndex = 133;

        this.ReceiptNumber = new TTVisual.TTTextBoxColumn();
        this.ReceiptNumber.DataMember = 'ReceiptNumber';
        this.ReceiptNumber.DisplayIndex = 6;
        this.ReceiptNumber.HeaderText = 'Ayniyat MakbuzNo';
        this.ReceiptNumber.Name = 'ReceiptNumber';
        this.ReceiptNumber.ReadOnly = true;
        this.ReceiptNumber.Width = 120;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ReadOnly = true;
        this.DestinationStore.ListDefName = 'SubStoreList';
        this.DestinationStore.Name = 'DestinationStore';
        this.DestinationStore.TabIndex = 132;

        this.DescriptionsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DescriptionsDocumentRecordLog.DataMember = 'Descriptions';
        this.DescriptionsDocumentRecordLog.DisplayIndex = 7;
        this.DescriptionsDocumentRecordLog.HeaderText = i18n("M10483", "Açıklamalar");
        this.DescriptionsDocumentRecordLog.Name = 'DescriptionsDocumentRecordLog';
        this.DescriptionsDocumentRecordLog.Width = 120;

        this.DistributionDocumentMaterialsTabcontrol = new TTVisual.TTTabControl();
        this.DistributionDocumentMaterialsTabcontrol.Name = 'DistributionDocumentMaterialsTabcontrol';
        this.DistributionDocumentMaterialsTabcontrol.TabIndex = 30;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 2;
        this.tttabpage1.TabIndex = 2;
        this.tttabpage1.Text = 'Taşınır Mal İşlem Belgeleri';
        this.tttabpage1.Name = 'tttabpage1';

        this.DistributionDocumentMaterialsTabpage = new TTVisual.TTTabPage();
        this.DistributionDocumentMaterialsTabpage.DisplayIndex = 0;
        this.DistributionDocumentMaterialsTabpage.TabIndex = 0;
        this.DistributionDocumentMaterialsTabpage.Text = 'Taşınır Malın';
        this.DistributionDocumentMaterialsTabpage.Name = 'DistributionDocumentMaterialsTabpage';

        this.RegistrationNumber = new TTVisual.TTTextBox();
        this.RegistrationNumber.BackColor = '#F0F0F0';
        this.RegistrationNumber.ReadOnly = true;
        this.RegistrationNumber.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.RegistrationNumber.Name = 'RegistrationNumber';
        this.RegistrationNumber.TabIndex = 2;

        this.DistributionDocumentMaterials = new TTVisual.TTGrid();
        this.DistributionDocumentMaterials.Name = 'DistributionDocumentMaterials';
        this.DistributionDocumentMaterials.TabIndex = 29;
        this.DistributionDocumentMaterials.Height = 350;
        this.DistributionDocumentMaterials.AllowUserToAddRows = false;
        this.DistributionDocumentMaterials.AllowUserToDeleteRows = false;

        this.SequenceNumber = new TTVisual.TTTextBox();
        this.SequenceNumber.BackColor = '#F0F0F0';
        this.SequenceNumber.ReadOnly = true;
        this.SequenceNumber.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.SequenceNumber.Name = 'SequenceNumber';
        this.SequenceNumber.TabIndex = 3;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = '';
        this.Detail.Name = 'Detail';
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.ttMkysSend = new TTVisual.TTButton();
        this.ttMkysSend.Text = 'MKYS ye Gönder';
        this.ttMkysSend.Name = 'ttMkysSend';
        this.ttMkysSend.TabIndex = 133;

        this.MaterialDistributionDocumentMaterial = new TTVisual.TTListBoxColumn();
        this.MaterialDistributionDocumentMaterial.AllowMultiSelect = true;
        this.MaterialDistributionDocumentMaterial.ListDefName = 'MaterialListDefinition';
        this.MaterialDistributionDocumentMaterial.DataMember = 'Material';
        this.MaterialDistributionDocumentMaterial.AutoCompleteDialogHeight = '60%';
        this.MaterialDistributionDocumentMaterial.AutoCompleteDialogWidth = '90%';
        this.MaterialDistributionDocumentMaterial.DisplayIndex = 1;
        this.MaterialDistributionDocumentMaterial.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialDistributionDocumentMaterial.Name = 'MaterialDistributionDocumentMaterial';
        this.MaterialDistributionDocumentMaterial.Width = 300;

        this.labelSequenceNumber = new TTVisual.TTLabel();
        this.labelSequenceNumber.Text = i18n("M11745", "Belge No");
        this.labelSequenceNumber.BackColor = '#DCDCDC';
        this.labelSequenceNumber.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelSequenceNumber.ForeColor = '#000000';
        this.labelSequenceNumber.Name = 'labelSequenceNumber';
        this.labelSequenceNumber.TabIndex = 10;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = 'Material.Barcode';
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = 'Barkod';
        this.Barcode.Name = 'Barcode';
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.TagNo = new TTVisual.TTTextBoxColumn();
        this.TagNo.DataMember = 'TagNo';
        this.TagNo.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.TagNo.DisplayIndex = 2;
        this.TagNo.HeaderText = 'Künye No';
        this.TagNo.Name = 'TagNo';
        this.TagNo.ReadOnly = true;
        this.TagNo.Width = 120;


        this.labelRegistrationNumber = new TTVisual.TTLabel();
        this.labelRegistrationNumber.Text = i18n("M11742", "Belge Kayıt No");
        this.labelRegistrationNumber.BackColor = '#DCDCDC';
        this.labelRegistrationNumber.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelRegistrationNumber.ForeColor = '#000000';
        this.labelRegistrationNumber.Name = 'labelRegistrationNumber';
        this.labelRegistrationNumber.TabIndex = 12;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = 'Material.DistributionTypeName';
        this.DistributionType.DisplayIndex = 4;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = 'DistributionType';
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 120;

        this.AcceptedAmountDistributionDocumentMaterial = new TTVisual.TTTextBoxColumn();
        this.AcceptedAmountDistributionDocumentMaterial.DataMember = 'AcceptedAmount';
        this.AcceptedAmountDistributionDocumentMaterial.Required = true;
        this.AcceptedAmountDistributionDocumentMaterial.Format = 'N4';
        this.AcceptedAmountDistributionDocumentMaterial.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AcceptedAmountDistributionDocumentMaterial.DisplayIndex = 4;
        this.AcceptedAmountDistributionDocumentMaterial.HeaderText = i18n("M16713", "İstenen Miktar");
        this.AcceptedAmountDistributionDocumentMaterial.Name = 'AcceptedAmountDistributionDocumentMaterial';
        this.AcceptedAmountDistributionDocumentMaterial.Width = 120;
        this.AcceptedAmountDistributionDocumentMaterial.IsNumeric = true;

        this.AmountDistributionDocumentMaterial = new TTVisual.TTTextBoxColumn();
        this.AmountDistributionDocumentMaterial.DataMember = 'Amount';
        this.AmountDistributionDocumentMaterial.Format = 'N4';
        this.AmountDistributionDocumentMaterial.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountDistributionDocumentMaterial.DisplayIndex = 5;
        this.AmountDistributionDocumentMaterial.HeaderText = i18n("M24114", "Verilen Miktar");
        this.AmountDistributionDocumentMaterial.Name = 'AmountDistributionDocumentMaterial';
        this.AmountDistributionDocumentMaterial.Width = 120;
        this.AmountDistributionDocumentMaterial.IsNumeric = true;

        this.StoreInheld = new TTVisual.TTTextBoxColumn();
        this.StoreInheld.DataMember = 'StoreStock';
        this.StoreInheld.Format = 'N4';
        this.StoreInheld.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreInheld.DisplayIndex = 6;
        this.StoreInheld.HeaderText = i18n("M12625", "Depo Mevcudu");
        this.StoreInheld.Name = 'StoreInheld';
        this.StoreInheld.ReadOnly = true;
        this.StoreInheld.Visible = true;
        this.StoreInheld.Width = 120;

        this.StockLevelTypeDistributionDocumentMaterial = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeDistributionDocumentMaterial.ListDefName = 'StockLevelTypeList';
        this.StockLevelTypeDistributionDocumentMaterial.DataMember = 'StockLevelType';
        this.StockLevelTypeDistributionDocumentMaterial.DisplayIndex = 7;
        this.StockLevelTypeDistributionDocumentMaterial.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeDistributionDocumentMaterial.Name = 'StockLevelTypeDistributionDocumentMaterial';
        this.StockLevelTypeDistributionDocumentMaterial.ReadOnly = true;
        this.StockLevelTypeDistributionDocumentMaterial.Width = 140;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = 'UnitPrice';
        this.UnitPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPrice.DisplayIndex = 8;
        this.UnitPrice.HeaderText = i18n("M11860", "Birim Fiyatı");
        this.UnitPrice.Name = 'UnitPrice';
        this.UnitPrice.ReadOnly = true;
        this.UnitPrice.Width = 120;
        this.UnitPrice.Visible = false;
        this.UnitPrice.IsNumeric = true;

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DataMember = 'Price';
        this.Price.Format = 'N4';
        this.Price.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Price.DisplayIndex = 9;
        this.Price.HeaderText = i18n("M23613", "Tutarı");
        this.Price.Name = 'Price';
        this.Price.ReadOnly = true;
        this.Price.Width = 120;
        this.Price.Visible = false;
        this.Price.IsNumeric = true;

        this.StatusDistributionDocumentMaterial = new TTVisual.TTEnumComboBoxColumn();
        this.StatusDistributionDocumentMaterial.DataTypeName = 'StockActionDetailStatusEnum';
        this.StatusDistributionDocumentMaterial.DataMember = 'Status';
        this.StatusDistributionDocumentMaterial.DisplayIndex = 10;
        this.StatusDistributionDocumentMaterial.HeaderText = 'Durum';
        this.StatusDistributionDocumentMaterial.Name = 'StatusDistributionDocumentMaterial';
        this.StatusDistributionDocumentMaterial.ReadOnly = true;
        this.StatusDistributionDocumentMaterial.Visible = false;
        this.StatusDistributionDocumentMaterial.Width = 120;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = '#F0F0F0';
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.StockActionID.Name = 'StockActionID';
        this.StockActionID.TabIndex = 0;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = '#F0F0F0';
        this.TransactionDate.CustomFormat = '';
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.TransactionDate.Name = 'TransactionDate';
        this.TransactionDate.TabIndex = 1;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16869", "İşlem Nu.");
        this.labelStockActionID.BackColor = '#DCDCDC';
        this.labelStockActionID.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelStockActionID.ForeColor = '#000000';
        this.labelStockActionID.Name = 'labelStockActionID';
        this.labelStockActionID.TabIndex = 4;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.BackColor = '#DCDCDC';
        this.labelTransactionDate.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelTransactionDate.ForeColor = '#000000';
        this.labelTransactionDate.Name = 'labelTransactionDate';
        this.labelTransactionDate.TabIndex = 8;

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
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = 'StockActionSignDetails';
        this.StockActionSignDetails.TabIndex = 0;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = 'SignUserTypeEnum';
        this.SignUserType.DataMember = 'SignUserType';
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = 'SignUserType';
        this.SignUserType.ReadOnly = true;
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

        this.MKYS_CikisStokHareketTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisStokHareketTuru.DataTypeName = 'MKYS_ECikisStokHareketTurEnum';
        this.MKYS_CikisStokHareketTuru.Required = true;
        this.MKYS_CikisStokHareketTuru.BackColor = '#F0F0F0';
        this.MKYS_CikisStokHareketTuru.Enabled = false;
        this.MKYS_CikisStokHareketTuru.Name = 'MKYS_CikisStokHareketTuru';
        this.MKYS_CikisStokHareketTuru.TabIndex = 128;

        this.MKYS_CikisIslemTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisIslemTuru.DataTypeName = 'MKYS_ECikisIslemTuruEnum';
        this.MKYS_CikisIslemTuru.Required = true;
        this.MKYS_CikisIslemTuru.BackColor = '#F0F0F0';
        this.MKYS_CikisIslemTuru.Enabled = false;
        this.MKYS_CikisIslemTuru.Name = 'MKYS_CikisIslemTuru';
        this.MKYS_CikisIslemTuru.TabIndex = 124;

        this.lblMKYS_CikisIslemTuru = new TTVisual.TTLabel();
        this.lblMKYS_CikisIslemTuru.Text = i18n("M16895", "İşlem Türü");
        this.lblMKYS_CikisIslemTuru.Name = 'lblMKYS_CikisIslemTuru';
        this.lblMKYS_CikisIslemTuru.TabIndex = 125;

        this.lblMKYS_CikisStokHareketTuru = new TTVisual.TTLabel();
        this.lblMKYS_CikisStokHareketTuru.Text = i18n("M22325", "Stok Hareket Türü");
        this.lblMKYS_CikisStokHareketTuru.Name = 'lblMKYS_CikisStokHareketTuru';
        this.lblMKYS_CikisStokHareketTuru.TabIndex = 129;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 129;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = 'TA';
        this.TTTeslimAlanButon.Name = 'TTTeslimAlanButon';
        this.TTTeslimAlanButon.TabIndex = 120;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = 'TE';
        this.TTTeslimEdenButon.Name = 'TTTeslimEdenButon';
        this.TTTeslimEdenButon.TabIndex = 121;

        this.DocumentRecordLogDeleteMKYS = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogDeleteMKYS.Text = 'MKYS Kayıt Sil';
        this.DocumentRecordLogDeleteMKYS.Name = 'DeleteMkysRow';

        this.DocumentRecordLogsColumns = [this.DocumentDateTimeDocumentRecordLog, this.DocumentRecordLogNumberDocumentRecordLog,
        this.DocumentTransactionTypeDocumentRecordLog, this.NumberOfRowsDocumentRecordLog, this.BudgeTypeEnum, this.SubjectDocumentRecordLog,
        this.ReceiptNumber, this.DescriptionsDocumentRecordLog,this.DocumentRecordLogDeleteMKYS];
        //this.DistributionDocumentMaterialsColumns = [this.Detail, this.MaterialDistributionDocumentMaterial, this.Barcode, this.DistributionType,
        //this.AcceptedAmountDistributionDocumentMaterial, this.AmountDistributionDocumentMaterial, this.StoreInheld, this.TagNo, this.StockLevelTypeDistributionDocumentMaterial,
        //this.UnitPrice, this.Price, this.StatusDistributionDocumentMaterial];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.DocumentrecordLogTab.Controls = [this.DocumentRecordLogs];
        this.DistributionDocumentMaterialsTabcontrol.Controls = [this.DocumentrecordLogTab, this.DistributionDocumentMaterialsTabpage];
        this.DistributionDocumentMaterialsTabpage.Controls = [this.DistributionDocumentMaterials];
        this.DescriptionAndSignTabControl.Controls = [this.tttabpage1, this.SignTabpage, this.DescriptionTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.IsAutoDistribution, this.labelMKYS_TeslimEden, this.DocumentrecordLogTab, this.MKYS_TeslimEden, this.DocumentRecordLogs,
        this.MKYS_TeslimAlan, this.DocumentDateTimeDocumentRecordLog, this.Description, this.DocumentRecordLogNumberDocumentRecordLog, this.labelMKYS_TeslimAlan,
        this.DocumentTransactionTypeDocumentRecordLog, this.labelStore, this.NumberOfRowsDocumentRecordLog, this.Store, this.BudgeTypeEnum, this.labelDestinationStore,
        this.SubjectDocumentRecordLog, this.DestinationStore, this.ReceiptNumber, this.DistributionDocumentMaterialsTabcontrol, this.DescriptionsDocumentRecordLog,
        this.DistributionDocumentMaterialsTabpage, this.tttabpage1, this.DistributionDocumentMaterials, this.RegistrationNumber, this.Detail, this.SequenceNumber,
        this.MaterialDistributionDocumentMaterial, this.ttMkysSend, this.Barcode, this.labelSequenceNumber, this.DistributionType, this.labelRegistrationNumber, this.TagNo,
        this.AcceptedAmountDistributionDocumentMaterial, this.AmountDistributionDocumentMaterial, this.StoreInheld, this.StockLevelTypeDistributionDocumentMaterial,
        this.UnitPrice, this.Price, this.StatusDistributionDocumentMaterial, this.StockActionID, this.TransactionDate, this.labelStockActionID,
        this.labelTransactionDate, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser,
        this.IsDeputy, this.DescriptionTabpage, this.MKYS_CikisStokHareketTuru, this.MKYS_CikisIslemTuru, this.lblMKYS_CikisIslemTuru,
        this.lblMKYS_CikisStokHareketTuru, this.ttlabel1, this.TTTeslimAlanButon, this.TTTeslimEdenButon,this.DocumentRecordLogDeleteMKYS];
    }
}