//$8F52C4C9
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ExtendExpDateOutCompFomViewModel } from './ExtendExpDateOutCompFomViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseExtendExpDateOutForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Miad_Uzatim_Cikis_Modulu/BaseExtendExpDateOutForm";
import { ExtendExpDateOut, DocumentTransactionTypeEnum, DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { ExtendExpDateOutDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { IModalService } from 'app/Fw/Services/IModalService';
import { StockActionService, DocumentRecordLogReceiptNumber_Input } from 'ObjectClassService/StockActionService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { UsernamePwdBox } from 'app/NebulaClient/Visual/UsernamePwdBox';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { MkysServis } from 'app/NebulaClient/Services/External/MkysServis';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import Exception from 'app/NebulaClient/System/Exception';

@Component({
    selector: 'ExtendExpDateOutCompFom',
    templateUrl: './ExtendExpDateOutCompFom.html',
    providers: [MessageService]
})
export class ExtendExpDateOutCompFom extends BaseExtendExpDateOutForm implements OnInit {
    public DocumentRecordLogsColumns = [];
    public ExtendExpDateOutDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public extendExpDateOutCompFomViewModel: ExtendExpDateOutCompFomViewModel = new ExtendExpDateOutCompFomViewModel();
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
    DocumentRecordLogSearch: TTVisual.ITTButtonColumn;
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;
    public get _ExtendExpDateOut(): ExtendExpDateOut {
        return this._TTObject as ExtendExpDateOut;
    }
    private ExtendExpDateOutCompFom_DocumentUrl: string = '/api/ExtendExpDateOutService/ExtendExpDateOutCompFom';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalService: IModalService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ExtendExpDateOutCompFom_DocumentUrl;
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
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ExtendExpDateOut.ObjectID.toString());
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
            this.showLoadPanel =true;
            let params = <any>(<ModalActionResult>result).Param;
            if (this._ExtendExpDateOut.CurrentStateDefID.toString() === ExtendExpDateOut.ExtendExpDateOutStates.Completed.id) {
                let documetrecords: Array<DocumentRecordLog> = await this._ExtendExpDateOut.DocumentRecordLogs.sort((a, b) => a.DocumentRecordLogNumber - b.DocumentRecordLogNumber);
                for (let log_1 of documetrecords) {
                    if (log_1.DocumentTransactionType === DocumentTransactionTypeEnum.Out) {
                        if (log_1.ReceiptNumber == null) {
                            this.mkysSonucMesaj += await StockActionService.SendMKYSForOutputDocumentTS(this._ExtendExpDateOut, params.password);
                        }
                    }
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
        if ((<ModalActionResult>result).Result === DialogResult.OK) {
            let params = <any>(<ModalActionResult>result).Param;
            this.mkysSonucMesaj += await StockActionService.SendUpdateMessageToMKYSTS(this._ExtendExpDateOut, params.password);
        }
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);

    }
    onSelectionChangeDocumentRecordLogs(data: any) { }
    onDocumentRecordLogsRowInserting(data: any) { }
    DocumentRecordLogs_CellValueChangedEmitted(data: any) { }
    initDocumentRecordLogsNewRow(data: any) { }

    public initViewModel(): void {
        this._TTObject = new ExtendExpDateOut();
        this.extendExpDateOutCompFomViewModel = new ExtendExpDateOutCompFomViewModel();
        this._ViewModel = this.extendExpDateOutCompFomViewModel;
        this.extendExpDateOutCompFomViewModel._ExtendExpDateOut = this._TTObject as ExtendExpDateOut;
        this.extendExpDateOutCompFomViewModel._ExtendExpDateOut.Store = new Store();
        this.extendExpDateOutCompFomViewModel._ExtendExpDateOut.Supplier = new Supplier();
        this.extendExpDateOutCompFomViewModel._ExtendExpDateOut.ExtendExpDateOutDetails = new Array<ExtendExpDateOutDetail>();
        this.extendExpDateOutCompFomViewModel._ExtendExpDateOut.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.extendExpDateOutCompFomViewModel = this._ViewModel as ExtendExpDateOutCompFomViewModel;
        that._TTObject = this.extendExpDateOutCompFomViewModel._ExtendExpDateOut;
        if (this.extendExpDateOutCompFomViewModel == null)
            this.extendExpDateOutCompFomViewModel = new ExtendExpDateOutCompFomViewModel();
        if (this.extendExpDateOutCompFomViewModel._ExtendExpDateOut == null)
            this.extendExpDateOutCompFomViewModel._ExtendExpDateOut = new ExtendExpDateOut();
        let storeObjectID = that.extendExpDateOutCompFomViewModel._ExtendExpDateOut["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.extendExpDateOutCompFomViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.extendExpDateOutCompFomViewModel._ExtendExpDateOut.Store = store;
            }
        }

        that.extendExpDateOutCompFomViewModel._ExtendExpDateOut.DocumentRecordLogs = that.extendExpDateOutCompFomViewModel.DocumentRecordLogsGridList;

        let supplierObjectID = that.extendExpDateOutCompFomViewModel._ExtendExpDateOut["Supplier"];
        if (supplierObjectID != null && (typeof supplierObjectID === "string")) {
            let supplier = that.extendExpDateOutCompFomViewModel.Suppliers.find(o => o.ObjectID.toString() === supplierObjectID.toString());
            if (supplier) {
                that.extendExpDateOutCompFomViewModel._ExtendExpDateOut.Supplier = supplier;
            }
        }


        that.extendExpDateOutCompFomViewModel._ExtendExpDateOut.ExtendExpDateOutDetails = that.extendExpDateOutCompFomViewModel.ExtendExpDateOutDetailsGridList;
        for (let detailItem of that.extendExpDateOutCompFomViewModel.ExtendExpDateOutDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.extendExpDateOutCompFomViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }


        }
        that.extendExpDateOutCompFomViewModel._ExtendExpDateOut.StockActionSignDetails = that.extendExpDateOutCompFomViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.extendExpDateOutCompFomViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === "string")) {
                let signUser = that.extendExpDateOutCompFomViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }


        }

    }

    async ngOnInit() {
        let that = this;
        await this.load(ExtendExpDateOutCompFomViewModel);
        this.MKYS_TeslimAlan.ButtonEnabled = false;
        this.MKYS_TeslimEden.ButtonEnabled = false;
        this.DocumentRecordLogSearch.ReadOnly = false;
        that.DocumentRecordLogDeleteMKYS.ReadOnly = false;
        if (this._ExtendExpDateOut.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ExtendExpDateOut.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }

        if (this._ExtendExpDateOut.CurrentStateDefID.valueOf() === ExtendExpDateOut.ExtendExpDateOutStates.Cancelled.id)
            this.FormCaption = 'Miad Güncelleme Çıkış ( İptal Edildi )';
        else
            this.FormCaption = 'Miad Güncelleme Çıkış ( Tamamlandı )';
    }

    receiptNumberError: string ="";
    controlOfCancelMKYS: boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        for (let log of this._ExtendExpDateOut.DocumentRecordLogs) {
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

    public onDescriptionChanged(event): void {
        if (this._ExtendExpDateOut != null && this._ExtendExpDateOut.Description !== event) {
            this._ExtendExpDateOut.Description = event;
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (this._ExtendExpDateOut != null && this._ExtendExpDateOut.MKYS_TeslimAlan !== event) {
            this._ExtendExpDateOut.MKYS_TeslimAlan = event;
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (this._ExtendExpDateOut != null && this._ExtendExpDateOut.MKYS_TeslimEden !== event) {
            this._ExtendExpDateOut.MKYS_TeslimEden = event;
        }
    }

    public onStockActionIDChanged(event): void {
        if (this._ExtendExpDateOut != null && this._ExtendExpDateOut.StockActionID !== event) {
            this._ExtendExpDateOut.StockActionID = event;
        }
    }

    public onStoreChanged(event): void {
        if (this._ExtendExpDateOut != null && this._ExtendExpDateOut.Store !== event) {
            this._ExtendExpDateOut.Store = event;
        }
    }

    public onSupplierChanged(event): void {
        if (this._ExtendExpDateOut != null && this._ExtendExpDateOut.Supplier !== event) {
            this._ExtendExpDateOut.Supplier = event;
        }
    }

    public onTransactionDateChanged(event): void {
        if (this._ExtendExpDateOut != null && this._ExtendExpDateOut.TransactionDate !== event) {
            this._ExtendExpDateOut.TransactionDate = event;
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
    onRowInsertting(data: ExtendExpDateOutDetail) {
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
        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = "Gönderen Depo";
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 127;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 126;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.labelSupplier = new TTVisual.TTLabel();
        this.labelSupplier.Text = "Tedarikci";
        this.labelSupplier.Name = "labelSupplier";
        this.labelSupplier.TabIndex = 125;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = "Teslim Eden";
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.Supplier = new TTVisual.TTObjectListBox();
        this.Supplier.ListDefName = "SupplierListDefinition";
        this.Supplier.Name = "Supplier";
        this.Supplier.TabIndex = 124;

        this.MKYS_TeslimEden = new TTVisual.TTTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 118;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 122;

        this.MKYS_TeslimAlan = new TTVisual.TTTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = "Taşınır Malın";
        this.tttabpage1.Name = "tttabpage1";

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.ExtendExpDateOutDetails = new TTVisual.TTGrid();
        this.ExtendExpDateOutDetails.Name = "ExtendExpDateOutDetails";
        this.ExtendExpDateOutDetails.TabIndex = 123;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.MaterialExtendExpDateOutDetail = new TTVisual.TTListBoxColumn();
        this.MaterialExtendExpDateOutDetail.ListDefName = "MaterialListDefinition";
        this.MaterialExtendExpDateOutDetail.DataMember = "Material";
        this.MaterialExtendExpDateOutDetail.DisplayIndex = 0;
        this.MaterialExtendExpDateOutDetail.HeaderText = "Malzeme";
        this.MaterialExtendExpDateOutDetail.Name = "MaterialExtendExpDateOutDetail";
        this.MaterialExtendExpDateOutDetail.Width = 300;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = "Teslim Alan";
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.OutExpirationDateExtendExpDateOutDetail = new TTVisual.TTDateTimePickerColumn();
        this.OutExpirationDateExtendExpDateOutDetail.DataMember = "OutExpirationDate";
        this.OutExpirationDateExtendExpDateOutDetail.DisplayIndex = 1;
        this.OutExpirationDateExtendExpDateOutDetail.HeaderText = "Çıkış Yapılan Son Kullanma Tarihi";
        this.OutExpirationDateExtendExpDateOutDetail.Name = "OutExpirationDateExtendExpDateOutDetail";
        this.OutExpirationDateExtendExpDateOutDetail.Width = 180;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = "İşlem Tarihi";
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.AmountExtendExpDateOutDetail = new TTVisual.TTTextBoxColumn();
        this.AmountExtendExpDateOutDetail.DataMember = "Amount";
        this.AmountExtendExpDateOutDetail.DisplayIndex = 2;
        this.AmountExtendExpDateOutDetail.HeaderText = "Miktar";
        this.AmountExtendExpDateOutDetail.Name = "AmountExtendExpDateOutDetail";
        this.AmountExtendExpDateOutDetail.Width = 80;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.StatusExtendExpDateOutDetail = new TTVisual.TTEnumComboBoxColumn();
        this.StatusExtendExpDateOutDetail.DataMember = "Status";
        this.StatusExtendExpDateOutDetail.DisplayIndex = 3;
        this.StatusExtendExpDateOutDetail.HeaderText = "Durum";
        this.StatusExtendExpDateOutDetail.Name = "StatusExtendExpDateOutDetail";
        this.StatusExtendExpDateOutDetail.Width = 80;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = "İşlem No";
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 113;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = "İmzalar";
        this.SignTabpage.Name = "SignTabpage";

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = "İmza Tipi";
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = "Personelin Adı, Soyadı";
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = "Vekil";
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Açıklama";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 111;

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

        this.DocumentRecordLogsColumns = [this.DocumentDateTimeDocumentRecordLog, this.DocumentRecordLogNumberDocumentRecordLog, this.DocumentTransactionTypeDocumentRecordLog, this.BUDGETYPE, this.NumberOfRowsDocumentRecordLog, this.SubjectDocumentRecordLog, this.DescriptionsDocumentRecordLog, this.ReceiptNumber, this.DocumentRecordLogDeleteMKYS, this.DocumentRecordLogSearch];
        this.ExtendExpDateOutDetailsColumns = [this.MaterialExtendExpDateOutDetail, this.OutExpirationDateExtendExpDateOutDetail, this.AmountExtendExpDateOutDetail, this.StatusExtendExpDateOutDetail];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.tttabcontrol1.Controls = [this.tttabpage1, this.DocumentRecordLogTab];
        this.tttabpage1.Controls = [this.ExtendExpDateOutDetails];
        this.DocumentRecordLogTab.Controls = [this.DocumentRecordLogs];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.labelStore, this.TTTeslimEdenButon, this.Store, this.TTTeslimAlanButon, this.labelSupplier,
        this.labelMKYS_TeslimEden, this.Supplier, this.MKYS_TeslimEden, this.tttabcontrol1, this.MKYS_TeslimAlan, this.tttabpage1,
        this.Description, this.ExtendExpDateOutDetails, this.StockActionID, this.MaterialExtendExpDateOutDetail, this.labelMKYS_TeslimAlan,
        this.OutExpirationDateExtendExpDateOutDetail, this.labelTransactionDate, this.AmountExtendExpDateOutDetail, this.TransactionDate,
        this.StatusExtendExpDateOutDetail, this.labelStockActionID, this.DescriptionAndSignTabControl, this.SignTabpage,
        this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.ttlabel1, this.BUDGETYPE, this.DescriptionsDocumentRecordLog,
        this.DocumentDateTimeDocumentRecordLog, this.DocumentRecordLogNumberDocumentRecordLog, this.DocumentRecordLogs, this.DocumentRecordLogTab,
        this.DocumentTransactionTypeDocumentRecordLog, this.NumberOfRowsDocumentRecordLog, this.ReceiptNumber, this.SubjectDocumentRecordLog, this.DocumentRecordLogSearch];

    }


}
