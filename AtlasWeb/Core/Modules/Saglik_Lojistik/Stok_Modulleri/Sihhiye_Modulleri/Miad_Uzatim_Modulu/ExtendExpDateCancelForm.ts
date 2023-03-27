//$B59B0A75
import { Component, OnInit, NgZone } from '@angular/core';
import { ExtendExpDateCancelFormViewModel } from './ExtendExpDateCancelFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';


import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseExtendExpDateForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Miad_Uzatim_Modulu/BaseExtendExpDateForm";
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { ExtendExpirationDate } from 'NebulaClient/Model/AtlasClientModel';

import { ExtendExpirationDateDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import Exception from 'app/NebulaClient/System/Exception';

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';
import { DocumentRecordLogReceiptNumber_Input, StockActionService } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { ModalActionResult } from 'app/Fw/Models/ModalInfo';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { UsernamePwdBox } from 'app/NebulaClient/Visual/UsernamePwdBox';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';

@Component({
    selector: 'ExtendExpDateCancelForm',
    templateUrl: './ExtendExpDateCancelForm.html',
    providers: [MessageService]
})
export class ExtendExpDateCancelForm extends BaseExtendExpDateForm implements OnInit {
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
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;
    public DocumentRecordLogsColumns = [];
    public ExtendExpirationDateDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public extendExpDateCancelFormViewModel: ExtendExpDateCancelFormViewModel = new ExtendExpDateCancelFormViewModel();
    public get _ExtendExpirationDate(): ExtendExpirationDate {
        return this._TTObject as ExtendExpirationDate;
    }
    private ExtendExpDateCancelForm_DocumentUrl: string = '/api/ExtendExpirationDateService/ExtendExpDateCancelForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone,protected objectContextService: ObjectContextService) {
        super(httpService, messageService, ngZone,objectContextService);
        this._DocumentServiceUrl = this.ExtendExpDateCancelForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected async PreScript() {
        super.PreScript();
    }

    public mkysSonucMesaj: string;
    popupVisible: boolean = false;
    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        this.SendToMKYS.ReadOnly = false;
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

    public async SendToMKYS_Click(): Promise<void> {
        //ExtendExpirationDate objesinde Cancelled state i kaldirildi. Bu nedenle asagidaki blok kapatildi.

        //-TODO İlaydax
        //this.mkysSonucMesaj = '';
        //let result = await UsernamePwdBox.Show(true);
        //if ((<ModalActionResult>result).Result == DialogResult.OK) {
        //    let params = <any>(<ModalActionResult>result).Param;
        //    if (this._ExtendExpirationDate.CurrentStateDefID.toString() === ExtendExpirationDate.ExtendExpirationDateStates.Cancelled.id) {
        //        let documetrecords: Array<DocumentRecordLog> = await this._ExtendExpirationDate.DocumentRecordLogs.sort((a, b) => a.DocumentRecordLogNumber - b.DocumentRecordLogNumber);
        //        for (let log of documetrecords) {
        //            if (log.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
        //                if (log.ReceiptNumber != null) {
        //                    this.mkysSonucMesaj += await StockActionService.SendDeleteMessageToMkysTS(this._ExtendExpirationDate, false, log.ReceiptNumber.Value, params.password);
        //                }
        //            }
        //        }
        //        //-TODO İlaydax
        //        this.popupVisible = true;
        //        for (let log of documetrecords) {
        //            if (log.DocumentTransactionType === DocumentTransactionTypeEnum.Out) {
        //                if (log.ReceiptNumber != null) {
        //                    this.mkysSonucMesaj += await StockActionService.SendDeleteMessageToMkysTS(this._ExtendExpirationDate, true, log.ReceiptNumber.Value, params.password);
        //                }
        //            }
        //        }
        //    }
        //    if (!String.isNullOrEmpty(this.mkysSonucMesaj))
        //        this.popupVisible = true;
        //}
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ExtendExpirationDate();
        this.extendExpDateCancelFormViewModel = new ExtendExpDateCancelFormViewModel();
        this._ViewModel = this.extendExpDateCancelFormViewModel;
        this.extendExpDateCancelFormViewModel._ExtendExpirationDate = this._TTObject as ExtendExpirationDate;
        this.extendExpDateCancelFormViewModel._ExtendExpirationDate.DocumentRecordLogs = new Array<DocumentRecordLog>();
        this.extendExpDateCancelFormViewModel._ExtendExpirationDate.Store = new Store();
        this.extendExpDateCancelFormViewModel._ExtendExpirationDate.ExtendExpirationDateDetails = new Array<ExtendExpirationDateDetail>();
        this.extendExpDateCancelFormViewModel._ExtendExpirationDate.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.extendExpDateCancelFormViewModel = this._ViewModel as ExtendExpDateCancelFormViewModel;
        that._TTObject = this.extendExpDateCancelFormViewModel._ExtendExpirationDate;
        if (this.extendExpDateCancelFormViewModel == null)
            this.extendExpDateCancelFormViewModel = new ExtendExpDateCancelFormViewModel();
        if (this.extendExpDateCancelFormViewModel._ExtendExpirationDate == null)
            this.extendExpDateCancelFormViewModel._ExtendExpirationDate = new ExtendExpirationDate();
        that.extendExpDateCancelFormViewModel._ExtendExpirationDate.DocumentRecordLogs = that.extendExpDateCancelFormViewModel.DocumentRecordLogsGridList;
        for (let detailItem of that.extendExpDateCancelFormViewModel.DocumentRecordLogsGridList) {
        }
        let storeObjectID = that.extendExpDateCancelFormViewModel._ExtendExpirationDate["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.extendExpDateCancelFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.extendExpDateCancelFormViewModel._ExtendExpirationDate.Store = store;
            }
        }
        that.extendExpDateCancelFormViewModel._ExtendExpirationDate.ExtendExpirationDateDetails = that.extendExpDateCancelFormViewModel.ExtendExpirationDateDetailsGridList;
        for (let detailItem of that.extendExpDateCancelFormViewModel.ExtendExpirationDateDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.extendExpDateCancelFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.extendExpDateCancelFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.extendExpDateCancelFormViewModel._ExtendExpirationDate.StockActionSignDetails = that.extendExpDateCancelFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.extendExpDateCancelFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.extendExpDateCancelFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        that.DocumentRecordLogDeleteMKYS.ReadOnly = false;
        await this.load(ExtendExpDateCancelFormViewModel);
        this.MKYS_TeslimAlan.ButtonEnabled = false;
        this.MKYS_TeslimEden.ButtonEnabled = false;
        if (this._ExtendExpirationDate.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ExtendExpirationDate.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M19016", "Miad Güncelleme İşlemi ( İptal )");
  
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
        this.DocumentRecordLogTab = new TTVisual.TTTabPage();
        this.DocumentRecordLogTab.DisplayIndex = 1;
        this.DocumentRecordLogTab.TabIndex = 1;
        this.DocumentRecordLogTab.Text = "Taşınır Mal İşlem Belgeleri";
        this.DocumentRecordLogTab.Name = "DocumentRecordLogTab";

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M12615", "Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 123;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.DocumentRecordLogs = new TTVisual.TTGrid();
        this.DocumentRecordLogs.Name = "DocumentRecordLogs";
        this.DocumentRecordLogs.TabIndex = 0;
        this.DocumentRecordLogs.Height = 350;
        this.DocumentRecordLogs.AllowUserToAddRows = false;
        this.DocumentRecordLogs.AllowUserToDeleteRows = false;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 122;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.DocumentDateTimeDocumentRecordLog = new TTVisual.TTDateTimePickerColumn();
        this.DocumentDateTimeDocumentRecordLog.DataMember = "DocumentDateTime";
        this.DocumentDateTimeDocumentRecordLog.DisplayIndex = 0;
        this.DocumentDateTimeDocumentRecordLog.HeaderText = i18n("M11748", "Belge Tarihi");
        this.DocumentDateTimeDocumentRecordLog.Name = "DocumentDateTimeDocumentRecordLog";
        this.DocumentDateTimeDocumentRecordLog.Width = 150;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 4;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.DocumentRecordLogNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DocumentRecordLogNumberDocumentRecordLog.DataMember = "DocumentRecordLogNumber";
        this.DocumentRecordLogNumberDocumentRecordLog.DisplayIndex = 1;
        this.DocumentRecordLogNumberDocumentRecordLog.HeaderText = i18n("M11743", "Belge Kayıt Numarası");
        this.DocumentRecordLogNumberDocumentRecordLog.Name = "DocumentRecordLogNumberDocumentRecordLog";
        this.DocumentRecordLogNumberDocumentRecordLog.Width = 150;

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

        this.DocumentTransactionTypeDocumentRecordLog = new TTVisual.TTEnumComboBoxColumn();
        this.DocumentTransactionTypeDocumentRecordLog.DataTypeName = "DocumentTransactionTypeEnum";
        this.DocumentTransactionTypeDocumentRecordLog.DataMember = "DocumentTransactionType";
        this.DocumentTransactionTypeDocumentRecordLog.DisplayIndex = 2;
        this.DocumentTransactionTypeDocumentRecordLog.HeaderText = i18n("M16834", "İşlem Çeşidi");
        this.DocumentTransactionTypeDocumentRecordLog.Name = "DocumentTransactionTypeDocumentRecordLog";
        this.DocumentTransactionTypeDocumentRecordLog.Width = 120;

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

        this.BUDGETYPE = new TTVisual.TTEnumComboBoxColumn();
        this.BUDGETYPE.DataTypeName = "MKYS_EButceTurEnum";
        this.BUDGETYPE.DataMember = "BudgeType";
        this.BUDGETYPE.DisplayIndex = 3;
        this.BUDGETYPE.HeaderText = i18n("M12145", "Bütçe Tipi");
        this.BUDGETYPE.Name = "BUDGETYPE";
        this.BUDGETYPE.ReadOnly = true;
        this.BUDGETYPE.Width = 120;

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

        this.NumberOfRowsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.NumberOfRowsDocumentRecordLog.DataMember = "NumberOfRows";
        this.NumberOfRowsDocumentRecordLog.DisplayIndex = 4;
        this.NumberOfRowsDocumentRecordLog.HeaderText = i18n("M17091", "Kalem Adedi");
        this.NumberOfRowsDocumentRecordLog.Name = "NumberOfRowsDocumentRecordLog";
        this.NumberOfRowsDocumentRecordLog.Width = 120;

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

        this.SubjectDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.SubjectDocumentRecordLog.DataMember = "Subject";
        this.SubjectDocumentRecordLog.DisplayIndex = 5;
        this.SubjectDocumentRecordLog.HeaderText = i18n("M14805", "Giriş ve Çıkış Nedenleri");
        this.SubjectDocumentRecordLog.Name = "SubjectDocumentRecordLog";
        this.SubjectDocumentRecordLog.Width = 200;

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

        this.DescriptionsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DescriptionsDocumentRecordLog.DataMember = "Descriptions";
        this.DescriptionsDocumentRecordLog.DisplayIndex = 6;
        this.DescriptionsDocumentRecordLog.HeaderText = i18n("M10483", "Açıklamalar");
        this.DescriptionsDocumentRecordLog.Name = "DescriptionsDocumentRecordLog";
        this.DescriptionsDocumentRecordLog.Width = 200;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 3;
        this.Amount.HeaderText = i18n("M15015", "Güncellenen Miktar");
        this.Amount.Name = "Amount";
        this.Amount.IsNumeric = true;
        this.Amount.Width = 150;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.ReceiptNumber = new TTVisual.TTTextBoxColumn();
        this.ReceiptNumber.DataMember = "ReceiptNumber";
        this.ReceiptNumber.DisplayIndex = 7;
        this.ReceiptNumber.HeaderText = "Ayniyat Makbuz No";
        this.ReceiptNumber.Name = "ReceiptNumber";
        this.ReceiptNumber.ReadOnly = true;
        this.ReceiptNumber.Width = 140;

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

        this.SendToMKYS = new TTVisual.TTButton();
        this.SendToMKYS.Text = "MKYS'ye Gönder";
        this.SendToMKYS.Name = "SendToMKYS";
        this.SendToMKYS.TabIndex = 126;

        this.NewDateForExpirationExtendExpirationDateDetail = new TTVisual.TTDateTimePickerColumn();
        this.NewDateForExpirationExtendExpirationDateDetail.Format = DateTimePickerFormat.Custom;
        this.NewDateForExpirationExtendExpirationDateDetail.CustomFormat = "MM/yyyy";
        this.NewDateForExpirationExtendExpirationDateDetail.DataMember = "NewDateForExpiration";
        this.NewDateForExpirationExtendExpirationDateDetail.DisplayIndex = 5;
        this.NewDateForExpirationExtendExpirationDateDetail.HeaderText = i18n("M24591", "Yeni Son Kullanma Tarihi");
        this.NewDateForExpirationExtendExpirationDateDetail.Name = "NewDateForExpirationExtendExpirationDateDetail";
        this.NewDateForExpirationExtendExpirationDateDetail.Width = 180;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 113;

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

        this.DocumentRecordLogDeleteMKYS = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogDeleteMKYS.Text = 'MKYS Kayıt Sil';
        this.DocumentRecordLogDeleteMKYS.Name = 'DeleteMkysRow';

        this.DocumentRecordLogsColumns = [this.DocumentDateTimeDocumentRecordLog, this.DocumentRecordLogNumberDocumentRecordLog, this.DocumentTransactionTypeDocumentRecordLog, this.BUDGETYPE, this.NumberOfRowsDocumentRecordLog, this.SubjectDocumentRecordLog, this.DescriptionsDocumentRecordLog, this.ReceiptNumber,this.DocumentRecordLogDeleteMKYS ];
        this.ExtendExpirationDateDetailsColumns = [this.MaterialExtendExpirationDateDetail, this.Barcode, this.RestAmount, this.Amount, this.CurrentExpirationDate, this.NewDateForExpirationExtendExpirationDateDetail, this.StockLevelType];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.DocumentRecordLogTab.Controls = [this.DocumentRecordLogs];
        this.tttabcontrol1.Controls = [this.DocumentRecordLogTab, this.MaterialTabPage];
        this.MaterialTabPage.Controls = [this.ExtendExpirationDateDetails];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.DocumentRecordLogTab, this.labelStore, this.TTTeslimEdenButon, this.DocumentRecordLogs, this.Store, this.TTTeslimAlanButon, this.DocumentDateTimeDocumentRecordLog, this.tttabcontrol1, this.labelMKYS_TeslimEden, this.DocumentRecordLogNumberDocumentRecordLog, this.MaterialTabPage, this.MKYS_TeslimEden, this.DocumentTransactionTypeDocumentRecordLog, this.ExtendExpirationDateDetails, this.MKYS_TeslimAlan, this.BUDGETYPE, this.MaterialExtendExpirationDateDetail, this.Description, this.NumberOfRowsDocumentRecordLog, this.Barcode, this.StockActionID, this.SubjectDocumentRecordLog, this.RestAmount, this.labelMKYS_TeslimAlan, this.DescriptionsDocumentRecordLog, this.Amount, this.labelTransactionDate, this.ReceiptNumber, this.CurrentExpirationDate, this.TransactionDate, this.SendToMKYS, this.NewDateForExpirationExtendExpirationDateDetail, this.labelStockActionID, this.StockLevelType, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.ttlabel1,this.DocumentRecordLogDeleteMKYS ];

        for (let control of this.Controls) {
            if (control.Name == this.SendToMKYS.Name) {
                this.SendToMKYS.ReadOnly = false;
                this.SendToMKYS.Enabled = true;
            }
            else {
                control.ReadOnly = true;
                control.Enabled = false;
            }
        }
    }


}
