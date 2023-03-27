//$229C856B
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ExtendExpDateInCompFormViewModel } from './ExtendExpDateInCompFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseExtendExpDateInForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Miad_Uzatim_Giris_Modulu/BaseExtendExpDateInForm";
import { ExtendExpDateIn, DocumentTransactionTypeEnum, DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ExtendExpDateInDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { StockActionService, DocumentRecordLogReceiptNumber_Input } from 'ObjectClassService/StockActionService';

import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'app/NebulaClient/Mscorlib/QueryParam';
import { UsernamePwdBox } from 'app/NebulaClient/Visual/UsernamePwdBox';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { MkysServis } from 'app/NebulaClient/Services/External/MkysServis';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import Exception from 'app/NebulaClient/System/Exception';

@Component({
    selector: 'ExtendExpDateInCompForm',
    templateUrl: './ExtendExpDateInCompForm.html',
    providers: [MessageService]
})
export class ExtendExpDateInCompForm extends BaseExtendExpDateInForm implements OnInit {
    public DocumentRecordLogsColumns = [];
    //public ExtendExpDateInDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public extendExpDateInCompFormViewModel: ExtendExpDateInCompFormViewModel = new ExtendExpDateInCompFormViewModel();
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
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;
    SubjectDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    tttabpage1: TTVisual.ITTTabPage;
    DocumentRecordLogSearch: TTVisual.ITTButtonColumn;
    
    MKYS_ETedarikTuru: TTVisual.ITTEnumComboBox;
    public get _ExtendExpDateIn(): ExtendExpDateIn {
        return this._TTObject as ExtendExpDateIn;
    }
    private ExtendExpDateInCompForm_DocumentUrl: string = '/api/ExtendExpDateInService/ExtendExpDateInCompForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone,
        private reportService: AtlasReportService, protected modalService: IModalService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ExtendExpDateInCompForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
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
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ExtendExpDateIn.ObjectID.toString());
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
        if ((<ModalActionResult>result).Result === DialogResult.OK) {
            this.showLoadPanel=true;
            let params = <any>(<ModalActionResult>result).Param;
            if (this._ExtendExpDateIn.CurrentStateDefID.toString() === ExtendExpDateIn.ExtendExpDateInStates.Completed.id) {
                let documetrecords: Array<DocumentRecordLog> = await this._ExtendExpDateIn.DocumentRecordLogs.sort((a, b) => a.DocumentRecordLogNumber - b.DocumentRecordLogNumber);
                for (let log_1 of documetrecords) {
                    if (log_1.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                        if (log_1.ReceiptNumber == null) {
                            this.mkysSonucMesaj += await StockActionService.SendMKYSForInputDocumentTS(this._ExtendExpDateIn, params.password);
                            this.mkysSonucMesaj += log_1.ReceiptNumber.toString() + " Ayniyat numarası ile MKYSye kaydolmuştur.";
                        }
                    }
                }
            }
            if (this._ExtendExpDateIn.CurrentStateDefID.toString() === ExtendExpDateIn.ExtendExpDateInStates.Cancelled.id) {
                for (let log of this._ExtendExpDateIn.DocumentRecordLogs) {
                    if (log.ReceiptNumber != null)
                        this.mkysSonucMesaj = await StockActionService.SendDeleteMessageToMkysTS(this._ExtendExpDateIn, true, log.ReceiptNumber.Value, params.password);
                }
            }

            /*this.popupVisible = true;
            for (let log_2 of documetrecords) {
                if (log_2.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                    if (log_2.ReceiptNumber == null) {
                        let resultFor = await UsernamePwdBox.Show(true);
                        this.mkysSonucMesaj += await StockActionService.SendMKYSForInputDocumentTS(this._ExtendExpDateOut, params.password);
                    }
                    if (log_2.ReceiptNumber != null)
                        this.mkysSonucMesaj += log_2.ReceiptNumber.toString() + " Ayniyat numarası ile MKYSye kaydolmuştur.";
                }
            }*/
            this.showLoadPanel =false;
            if (String.isNullOrEmpty(this.mkysSonucMesaj) == false)
                this.popupVisible = true;
        }
    }

    public async SendUpdateMessageToMKYS_Click(): Promise<void> {

        this.mkysSonucMesaj = '';
        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result === DialogResult.OK) {
            let params = <any>(<ModalActionResult>result).Param;
            this.mkysSonucMesaj += await StockActionService.SendUpdateMessageToMKYSTS(this._ExtendExpDateIn, params.password);
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
        this._TTObject = new ExtendExpDateIn();
        this.extendExpDateInCompFormViewModel = new ExtendExpDateInCompFormViewModel();
        this._ViewModel = this.extendExpDateInCompFormViewModel;
        this.extendExpDateInCompFormViewModel._ExtendExpDateIn = this._TTObject as ExtendExpDateIn;
        this.extendExpDateInCompFormViewModel._ExtendExpDateIn.ExtendExpDateInDetails = new Array<ExtendExpDateInDetail>();
        this.extendExpDateInCompFormViewModel._ExtendExpDateIn.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.extendExpDateInCompFormViewModel._ExtendExpDateIn.Store = new Store();
        this.extendExpDateInCompFormViewModel._ExtendExpDateIn.Supplier = new Supplier();
        this.extendExpDateInCompFormViewModel._ExtendExpDateIn.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.extendExpDateInCompFormViewModel = this._ViewModel as ExtendExpDateInCompFormViewModel;
        that._TTObject = this.extendExpDateInCompFormViewModel._ExtendExpDateIn;
        if (this.extendExpDateInCompFormViewModel == null)
            this.extendExpDateInCompFormViewModel = new ExtendExpDateInCompFormViewModel();
        if (this.extendExpDateInCompFormViewModel._ExtendExpDateIn == null)
            this.extendExpDateInCompFormViewModel._ExtendExpDateIn = new ExtendExpDateIn();
        that.extendExpDateInCompFormViewModel._ExtendExpDateIn.ExtendExpDateInDetails = that.extendExpDateInCompFormViewModel.ExtendExpDateInDetailsGridList;
        for (let detailItem of that.extendExpDateInCompFormViewModel.ExtendExpDateInDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.extendExpDateInCompFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }

        }

        that.extendExpDateInCompFormViewModel._ExtendExpDateIn.DocumentRecordLogs = that.extendExpDateInCompFormViewModel.DocumentRecordLogsGridList;

        let budgetTypeDefinitionObjectID = that.extendExpDateInCompFormViewModel._ExtendExpDateIn["BudgetTypeDefinition"];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === "string")) {
            let budgetTypeDefinition = that.extendExpDateInCompFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.extendExpDateInCompFormViewModel._ExtendExpDateIn.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }


        let storeObjectID = that.extendExpDateInCompFormViewModel._ExtendExpDateIn["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.extendExpDateInCompFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.extendExpDateInCompFormViewModel._ExtendExpDateIn.Store = store;
            }
        }


        let supplierObjectID = that.extendExpDateInCompFormViewModel._ExtendExpDateIn["Supplier"];
        if (supplierObjectID != null && (typeof supplierObjectID === "string")) {
            let supplier = that.extendExpDateInCompFormViewModel.Suppliers.find(o => o.ObjectID.toString() === supplierObjectID.toString());
            if (supplier) {
                that.extendExpDateInCompFormViewModel._ExtendExpDateIn.Supplier = supplier;
            }
        }


        that.extendExpDateInCompFormViewModel._ExtendExpDateIn.StockActionSignDetails = that.extendExpDateInCompFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.extendExpDateInCompFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === "string")) {
                let signUser = that.extendExpDateInCompFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }

        }
    }

    async ngOnInit() {
        let that = this;
        await this.load(ExtendExpDateInCompFormViewModel);
        this.MKYS_TeslimAlan.ButtonEnabled = false;
        this.MKYS_TeslimEden.ButtonEnabled = false;
        this.DocumentRecordLogSearch.ReadOnly = false;
        that.DocumentRecordLogDeleteMKYS.ReadOnly = false;
        if (this._ExtendExpDateIn.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ExtendExpDateIn.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M19018", "Miad Güncelleme Giriş ( Tamamlandı )");
    }

    receiptNumberError: string ="";
    controlOfCancelMKYS: boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        for (let log of this._ExtendExpDateIn.DocumentRecordLogs) {
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

    public onBudgetTypeDefinitionChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.BudgetTypeDefinition !== event) {
            this._ExtendExpDateIn.BudgetTypeDefinition = event;
        }
    }

    public onDescriptionChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.Description !== event) {
            this._ExtendExpDateIn.Description = event;
        }
    }

    public onExtendExpDateOutIDChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.ExtendExpDateOutID !== event) {
            this._ExtendExpDateIn.ExtendExpDateOutID = event;
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.MKYS_TeslimAlan !== event) {
            this._ExtendExpDateIn.MKYS_TeslimAlan = event;
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.MKYS_TeslimEden !== event) {
            this._ExtendExpDateIn.MKYS_TeslimEden = event;
        }
    }

    public onStockActionIDChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.StockActionID !== event) {
            this._ExtendExpDateIn.StockActionID = event;
        }
    }

    public onStoreChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.Store !== event) {
            this._ExtendExpDateIn.Store = event;
        }
    }

    public onSupplierChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.Supplier !== event) {
            this._ExtendExpDateIn.Supplier = event;
        }
    }

    public onTransactionDateChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.TransactionDate !== event) {
            this._ExtendExpDateIn.TransactionDate = event;
        }
    }



    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.ExtendExpDateOutID, "Text", this.__ttObject, "ExtendExpDateOutID");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 131;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = "Taşınır Malın";
        this.tttabpage1.Name = "tttabpage1";

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.ExtendExpDateInDetails = new TTVisual.TTGrid();
        this.ExtendExpDateInDetails.Name = "ExtendExpDateInDetails";
        this.ExtendExpDateInDetails.TabIndex = 124;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = "Teslim Eden";
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.MaterialExtendExpDateInDetail = new TTVisual.TTListBoxColumn();
        this.MaterialExtendExpDateInDetail.ListDefName = "MaterialListDefinition";
        this.MaterialExtendExpDateInDetail.DataMember = "Material";
        this.MaterialExtendExpDateInDetail.DisplayIndex = 0;
        this.MaterialExtendExpDateInDetail.HeaderText = "Malzeme";
        this.MaterialExtendExpDateInDetail.Name = "MaterialExtendExpDateInDetail";
        this.MaterialExtendExpDateInDetail.Width = 300;

        this.MKYS_TeslimEden = new TTVisual.TTTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 118;

        this.AmountExtendExpDateInDetail = new TTVisual.TTTextBoxColumn();
        this.AmountExtendExpDateInDetail.DataMember = "Amount";
        this.AmountExtendExpDateInDetail.DisplayIndex = 1;
        this.AmountExtendExpDateInDetail.HeaderText = "Miktar";
        this.AmountExtendExpDateInDetail.Name = "AmountExtendExpDateInDetail";
        this.AmountExtendExpDateInDetail.Width = 80;

        this.MKYS_TeslimAlan = new TTVisual.TTTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.UnitPriceExtendExpDateInDetail = new TTVisual.TTTextBoxColumn();
        this.UnitPriceExtendExpDateInDetail.DataMember = "UnitPrice";
        this.UnitPriceExtendExpDateInDetail.DisplayIndex = 2;
        this.UnitPriceExtendExpDateInDetail.HeaderText = "Birim Fiyatı";
        this.UnitPriceExtendExpDateInDetail.Name = "UnitPriceExtendExpDateInDetail";
        this.UnitPriceExtendExpDateInDetail.Width = 80;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.VatRateExtendExpDateInDetail = new TTVisual.TTTextBoxColumn();
        this.VatRateExtendExpDateInDetail.DataMember = "VatRate";
        this.VatRateExtendExpDateInDetail.DisplayIndex = 3;
        this.VatRateExtendExpDateInDetail.HeaderText = "KDV";
        this.VatRateExtendExpDateInDetail.Name = "VatRateExtendExpDateInDetail";
        this.VatRateExtendExpDateInDetail.Width = 80;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.ExpirationDateExtendExpDateInDetail = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDateExtendExpDateInDetail.DataMember = "ExpirationDate";
        this.ExpirationDateExtendExpDateInDetail.DisplayIndex = 4;
        this.ExpirationDateExtendExpDateInDetail.HeaderText = "Son Kullanma Tarihi";
        this.ExpirationDateExtendExpDateInDetail.Name = "ExpirationDateExtendExpDateInDetail";
        this.ExpirationDateExtendExpDateInDetail.Width = 180;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = "Teslim Alan";
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.LotNoExtendExpDateInDetail = new TTVisual.TTTextBoxColumn();
        this.LotNoExtendExpDateInDetail.DataMember = "LotNo";
        this.LotNoExtendExpDateInDetail.DisplayIndex = 5;
        this.LotNoExtendExpDateInDetail.HeaderText = "Lot Nu.";
        this.LotNoExtendExpDateInDetail.Name = "LotNoExtendExpDateInDetail";
        this.LotNoExtendExpDateInDetail.Width = 80;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = "İşlem Tarihi";
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.StatusExtendExpDateInDetail = new TTVisual.TTEnumComboBoxColumn();
        this.StatusExtendExpDateInDetail.DataTypeName = "StockActionDetailStatusEnum";
        this.StatusExtendExpDateInDetail.DataMember = "Status";
        this.StatusExtendExpDateInDetail.DisplayIndex = 6;
        this.StatusExtendExpDateInDetail.HeaderText = "Durum";
        this.StatusExtendExpDateInDetail.Name = "StatusExtendExpDateInDetail";
        this.StatusExtendExpDateInDetail.Width = 80;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.ExtendExpDateOutID = new TTVisual.TTTextBox();
        this.ExtendExpDateOutID.Name = "ExtendExpDateOutID";
        this.ExtendExpDateOutID.TabIndex = 122;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = "İşlem No";
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 113;

        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = "Bütçe Tipi";
        this.labelBudgetTypeDefinition.Name = "labelBudgetTypeDefinition";
        this.labelBudgetTypeDefinition.TabIndex = 130;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.ListDefName = "BugdetTypeList";
        this.BudgetTypeDefinition.Name = "BudgetTypeDefinition";
        this.BudgetTypeDefinition.TabIndex = 129;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = "İmzalar";
        this.SignTabpage.Name = "SignTabpage";

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = "Depo";
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 128;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 127;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = "İmza Tipi";
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.labelSupplier = new TTVisual.TTLabel();
        this.labelSupplier.Text = "Tedarikci";
        this.labelSupplier.Name = "labelSupplier";
        this.labelSupplier.TabIndex = 126;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = "Personelin Adı, Soyadı";
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;

        this.Supplier = new TTVisual.TTObjectListBox();
        this.Supplier.ListDefName = "SupplierListDefinition";
        this.Supplier.Name = "Supplier";
        this.Supplier.TabIndex = 125;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = "Vekil";
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.labelExtendExpDateOutID = new TTVisual.TTLabel();
        this.labelExtendExpDateOutID.Text = "Çıkış İşlem ID";
        this.labelExtendExpDateOutID.Name = "labelExtendExpDateOutID";
        this.labelExtendExpDateOutID.TabIndex = 123;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Açıklama";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 111;

        this.MKYS_ETedarikTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_ETedarikTuru.DataTypeName = "MKYS_ETedarikTurEnum";
        this.MKYS_ETedarikTuru.Required = true;
        this.MKYS_ETedarikTuru.BackColor = "#F0F0F0";
        this.MKYS_ETedarikTuru.Enabled = false;
        this.MKYS_ETedarikTuru.Name = "MKYS_ETedarikTuru";
        this.MKYS_ETedarikTuru.TabIndex = 15;

        this.SendToMKYS = new TTVisual.TTButton();
        this.SendToMKYS.Text = "MKYS'ye Gönder";
        this.SendToMKYS.Name = "SendToMKYS";
        this.SendToMKYS.TabIndex = 126;

        this.DocumentRecordLogSearch = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogSearch.Text = 'MKYS Log Sorgula';
        this.DocumentRecordLogSearch.Name = 'GetLogFromMkys';

        this.BUDGETYPE = new TTVisual.TTEnumComboBoxColumn();
        this.BUDGETYPE.DataTypeName = "MKYS_EButceTurEnum";
        this.BUDGETYPE.DataMember = "BudgeType";
        this.BUDGETYPE.DisplayIndex = 3;
        this.BUDGETYPE.HeaderText = i18n("M12145", "Bütçe Tipi");
        this.BUDGETYPE.Name = "BUDGETYPE";
        this.BUDGETYPE.ReadOnly = true;
        this.BUDGETYPE.Width = 120;

        this.DescriptionsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DescriptionsDocumentRecordLog.DataMember = "Descriptions";
        this.DescriptionsDocumentRecordLog.DisplayIndex = 6;
        this.DescriptionsDocumentRecordLog.HeaderText = i18n("M10483", "Açıklamalar");
        this.DescriptionsDocumentRecordLog.Name = "DescriptionsDocumentRecordLog";
        this.DescriptionsDocumentRecordLog.Width = 200;

        this.DocumentDateTimeDocumentRecordLog = new TTVisual.TTDateTimePickerColumn();
        this.DocumentDateTimeDocumentRecordLog.DataMember = "DocumentDateTime";
        this.DocumentDateTimeDocumentRecordLog.DisplayIndex = 0;
        this.DocumentDateTimeDocumentRecordLog.HeaderText = i18n("M11748", "Belge Tarihi");
        this.DocumentDateTimeDocumentRecordLog.Name = "DocumentDateTimeDocumentRecordLog";
        this.DocumentDateTimeDocumentRecordLog.Width = 150;

        this.DocumentRecordLogNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DocumentRecordLogNumberDocumentRecordLog.DataMember = "DocumentRecordLogNumber";
        this.DocumentRecordLogNumberDocumentRecordLog.DisplayIndex = 1;
        this.DocumentRecordLogNumberDocumentRecordLog.HeaderText = i18n("M11743", "Belge Kayıt Numarası");
        this.DocumentRecordLogNumberDocumentRecordLog.Name = "DocumentRecordLogNumberDocumentRecordLog";
        this.DocumentRecordLogNumberDocumentRecordLog.Width = 150;

        this.DocumentRecordLogs = new TTVisual.TTGrid();
        this.DocumentRecordLogs.Name = "DocumentRecordLogs";
        this.DocumentRecordLogs.TabIndex = 0;
        this.DocumentRecordLogs.Height = 350;
        this.DocumentRecordLogs.AllowUserToAddRows = false;
        this.DocumentRecordLogs.AllowUserToDeleteRows = false;

        this.DocumentRecordLogTab = new TTVisual.TTTabPage();
        this.DocumentRecordLogTab.DisplayIndex = 1;
        this.DocumentRecordLogTab.TabIndex = 1;
        this.DocumentRecordLogTab.Text = "Taşınır Mal İşlem Belgeleri";
        this.DocumentRecordLogTab.Name = "DocumentRecordLogTab";

        this.DocumentTransactionTypeDocumentRecordLog = new TTVisual.TTEnumComboBoxColumn();
        this.DocumentTransactionTypeDocumentRecordLog.DataTypeName = "DocumentTransactionTypeEnum";
        this.DocumentTransactionTypeDocumentRecordLog.DataMember = "DocumentTransactionType";
        this.DocumentTransactionTypeDocumentRecordLog.DisplayIndex = 2;
        this.DocumentTransactionTypeDocumentRecordLog.HeaderText = i18n("M16834", "İşlem Çeşidi");
        this.DocumentTransactionTypeDocumentRecordLog.Name = "DocumentTransactionTypeDocumentRecordLog";
        this.DocumentTransactionTypeDocumentRecordLog.Width = 120;

        this.NumberOfRowsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.NumberOfRowsDocumentRecordLog.DataMember = "NumberOfRows";
        this.NumberOfRowsDocumentRecordLog.DisplayIndex = 4;
        this.NumberOfRowsDocumentRecordLog.HeaderText = i18n("M17091", "Kalem Adedi");
        this.NumberOfRowsDocumentRecordLog.Name = "NumberOfRowsDocumentRecordLog";
        this.NumberOfRowsDocumentRecordLog.Width = 120;

        this.ReceiptNumber = new TTVisual.TTTextBoxColumn();
        this.ReceiptNumber.DataMember = "ReceiptNumber";
        this.ReceiptNumber.DisplayIndex = 7;
        this.ReceiptNumber.HeaderText = "Ayniyat Makbuz No";
        this.ReceiptNumber.Name = "ReceiptNumber";
        this.ReceiptNumber.ReadOnly = true;
        this.ReceiptNumber.Width = 150;

        this.SubjectDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.SubjectDocumentRecordLog.DataMember = "Subject";
        this.SubjectDocumentRecordLog.DisplayIndex = 5;
        this.SubjectDocumentRecordLog.HeaderText = i18n("M14805", "Giriş ve Çıkış Nedenleri");
        this.SubjectDocumentRecordLog.Name = "SubjectDocumentRecordLog";
        this.SubjectDocumentRecordLog.Width = 200;

        this.DocumentRecordLogDeleteMKYS = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogDeleteMKYS.Text = 'MKYS Kayıt Sil';
        this.DocumentRecordLogDeleteMKYS.Name = 'DeleteMkysRow';

        

        this.DocumentRecordLogsColumns = [this.DocumentDateTimeDocumentRecordLog, this.DocumentRecordLogNumberDocumentRecordLog, this.DocumentTransactionTypeDocumentRecordLog, this.BUDGETYPE, this.NumberOfRowsDocumentRecordLog, this.SubjectDocumentRecordLog, this.DescriptionsDocumentRecordLog, this.ReceiptNumber,this.DocumentRecordLogDeleteMKYS, this.DocumentRecordLogSearch];
        //this.ExtendExpDateInDetailsColumns = [this.MaterialExtendExpDateInDetail, this.AmountExtendExpDateInDetail, this.UnitPriceExtendExpDateInDetail, this.VatRateExtendExpDateInDetail, this.ExpirationDateExtendExpDateInDetail, this.LotNoExtendExpDateInDetail, this.StatusExtendExpDateInDetail];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.tttabcontrol1.Controls = [this.tttabpage1, this.DocumentRecordLogTab];
        this.tttabpage1.Controls = [this.ExtendExpDateInDetails];
        this.DocumentRecordLogTab.Controls = [this.DocumentRecordLogs];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.tttabcontrol1, this.TTTeslimEdenButon, this.tttabpage1, this.TTTeslimAlanButon, this.ExtendExpDateInDetails,
            this.labelMKYS_TeslimEden, this.MaterialExtendExpDateInDetail, this.MKYS_TeslimEden, this.AmountExtendExpDateInDetail,
            this.MKYS_TeslimAlan, this.UnitPriceExtendExpDateInDetail, this.Description, this.VatRateExtendExpDateInDetail,
            this.StockActionID, this.ExpirationDateExtendExpDateInDetail, this.labelMKYS_TeslimAlan, this.LotNoExtendExpDateInDetail,
            this.labelTransactionDate, this.StatusExtendExpDateInDetail, this.TransactionDate, this.ExtendExpDateOutID, this.labelStockActionID,
            this.labelBudgetTypeDefinition, this.DescriptionAndSignTabControl, this.BudgetTypeDefinition, this.SignTabpage, this.labelStore,
            this.StockActionSignDetails, this.Store, this.SignUserType, this.labelSupplier, this.SignUser, this.Supplier, this.IsDeputy,
            this.labelExtendExpDateOutID, this.ttlabel1, this.DocumentDateTimeDocumentRecordLog, this.DocumentRecordLogNumberDocumentRecordLog,
            this.DocumentTransactionTypeDocumentRecordLog, this.BUDGETYPE, this.NumberOfRowsDocumentRecordLog, this.SubjectDocumentRecordLog,
            this.DescriptionsDocumentRecordLog, this.ReceiptNumber, this.DocumentRecordLogSearch,this.DocumentRecordLogDeleteMKYS, this.MKYS_ETedarikTuru];

    }


}
