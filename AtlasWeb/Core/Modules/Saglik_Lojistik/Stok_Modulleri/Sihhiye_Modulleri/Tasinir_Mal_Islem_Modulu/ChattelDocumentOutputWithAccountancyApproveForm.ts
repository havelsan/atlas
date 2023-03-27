//$6A4652E3
import { Component, OnInit, NgZone } from '@angular/core';
import { ChattelDocumentOutputWithAccountancyApproveFormViewModel } from './ChattelDocumentOutputWithAccountancyApproveFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseChattelDocumentOutputWithAccountancy } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentOutputWithAccountancy";
import { ChattelDocumentOutputWithAccountancy, TasinirCikisHareketTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Accountancy } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentOutputDetailWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { StockActionService } from 'ObjectClassService/StockActionService';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { BooleanParam } from 'NebulaClient/Mscorlib/BooleanParam';
import { MKYS_ECikisStokHareketTurEnum } from 'NebulaClient/Model/AtlasClientModel';
@Component({
    selector: 'ChattelDocumentOutputWithAccountancyApproveForm',
    templateUrl: './ChattelDocumentOutputWithAccountancyApproveForm.html',
    providers: [MessageService]
})
export class ChattelDocumentOutputWithAccountancyApproveForm extends BaseChattelDocumentOutputWithAccountancy implements OnInit {
    //public ChattelDocumentDetailsWithAccountancyColumns = [];
    public StockActionSignDetailsColumns = [];
    public chattelDocumentOutputWithAccountancyApproveFormViewModel: ChattelDocumentOutputWithAccountancyApproveFormViewModel = new ChattelDocumentOutputWithAccountancyApproveFormViewModel();
    public get _ChattelDocumentOutputWithAccountancy(): ChattelDocumentOutputWithAccountancy {
        return this._TTObject as ChattelDocumentOutputWithAccountancy;
    }
    private ChattelDocumentOutputWithAccountancyApproveForm_DocumentUrl: string = '/api/ChattelDocumentOutputWithAccountancyService/ChattelDocumentOutputWithAccountancyApproveForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ChattelDocumentOutputWithAccountancyApproveForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }
    public rowVisible: boolean;

    // ***** Method declarations start *****
    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        this.rowVisible = true;

        /*if (this._ChattelDocumentOutputWithAccountancy.Store.ObjectDefID.valueOf() !== PharmacyStoreDefinition.ObjectDefID.id) {
            this.rowVisible = false;
        } else {
            this.rowVisible = true;
        }*/

    }


    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef != null) {
            super.AfterContextSavedScript(transDef);
            let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ChattelDocumentOutputWithAccountancy.ObjectID.toString());
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
            //if (this._ChattelDocumentOutputWithAccountancy.Store.ObjectDefID.valueOf() === PharmacyStoreDefinition.ObjectDefID.id) {
            if (this._ChattelDocumentOutputWithAccountancy.outputStockMovementType === TasinirCikisHareketTurEnum.stokFazlasiDevir) {
                const objectIdParam = new GuidParam(this._ChattelDocumentOutputWithAccountancy.ObjectID);
                const IsContributionMarginParam = new BooleanParam(this._ChattelDocumentOutputWithAccountancy.IsContainsContributions);
                let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'IsContributionMargin': IsContributionMarginParam };
                this.reportService.showReport('PharmacyInvoiceReport', reportParameters);
            }
        }
    }

    cellContentClicked(data: any) { }
    rowInserting(data: any) { }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChattelDocumentOutputWithAccountancy();
        this.chattelDocumentOutputWithAccountancyApproveFormViewModel = new ChattelDocumentOutputWithAccountancyApproveFormViewModel();
        this._ViewModel = this.chattelDocumentOutputWithAccountancyApproveFormViewModel;
        this.chattelDocumentOutputWithAccountancyApproveFormViewModel._ChattelDocumentOutputWithAccountancy = this._TTObject as ChattelDocumentOutputWithAccountancy;
        this.chattelDocumentOutputWithAccountancyApproveFormViewModel._ChattelDocumentOutputWithAccountancy.Store = new Store();
        this.chattelDocumentOutputWithAccountancyApproveFormViewModel._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy = new Array<ChattelDocumentOutputDetailWithAccountancy>();
        this.chattelDocumentOutputWithAccountancyApproveFormViewModel._ChattelDocumentOutputWithAccountancy.Accountancy = new Accountancy();
        this.chattelDocumentOutputWithAccountancyApproveFormViewModel._ChattelDocumentOutputWithAccountancy.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.chattelDocumentOutputWithAccountancyApproveFormViewModel = this._ViewModel as ChattelDocumentOutputWithAccountancyApproveFormViewModel;
        that._TTObject = this.chattelDocumentOutputWithAccountancyApproveFormViewModel._ChattelDocumentOutputWithAccountancy;
        if (this.chattelDocumentOutputWithAccountancyApproveFormViewModel == null)
            this.chattelDocumentOutputWithAccountancyApproveFormViewModel = new ChattelDocumentOutputWithAccountancyApproveFormViewModel();
        if (this.chattelDocumentOutputWithAccountancyApproveFormViewModel._ChattelDocumentOutputWithAccountancy == null)
            this.chattelDocumentOutputWithAccountancyApproveFormViewModel._ChattelDocumentOutputWithAccountancy = new ChattelDocumentOutputWithAccountancy();
        let storeObjectID = that.chattelDocumentOutputWithAccountancyApproveFormViewModel._ChattelDocumentOutputWithAccountancy["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.chattelDocumentOutputWithAccountancyApproveFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.chattelDocumentOutputWithAccountancyApproveFormViewModel._ChattelDocumentOutputWithAccountancy.Store = store;
            }
        }
        that.chattelDocumentOutputWithAccountancyApproveFormViewModel._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy = that.chattelDocumentOutputWithAccountancyApproveFormViewModel.ChattelDocumentDetailsWithAccountancyGridList;
        for (let detailItem of that.chattelDocumentOutputWithAccountancyApproveFormViewModel.ChattelDocumentDetailsWithAccountancyGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.chattelDocumentOutputWithAccountancyApproveFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.chattelDocumentOutputWithAccountancyApproveFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.chattelDocumentOutputWithAccountancyApproveFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === "string")) {
                let stockLevelType = that.chattelDocumentOutputWithAccountancyApproveFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        let accountancyObjectID = that.chattelDocumentOutputWithAccountancyApproveFormViewModel._ChattelDocumentOutputWithAccountancy["Accountancy"];
        if (accountancyObjectID != null && (typeof accountancyObjectID === "string")) {
            let accountancy = that.chattelDocumentOutputWithAccountancyApproveFormViewModel.Accountancys.find(o => o.ObjectID.toString() === accountancyObjectID.toString());
            if (accountancy) {
                that.chattelDocumentOutputWithAccountancyApproveFormViewModel._ChattelDocumentOutputWithAccountancy.Accountancy = accountancy;
            }
        }
        that.chattelDocumentOutputWithAccountancyApproveFormViewModel._ChattelDocumentOutputWithAccountancy.StockActionSignDetails = that.chattelDocumentOutputWithAccountancyApproveFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.chattelDocumentOutputWithAccountancyApproveFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === "string")) {
                let signUser = that.chattelDocumentOutputWithAccountancyApproveFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }

    }

    async ngOnInit() {
        let that = this;
        await this.load(ChattelDocumentOutputWithAccountancyApproveFormViewModel);
        if (this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = "Taşınır Mal Çıkış (Onay)";

    }


    public onAccountancyChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.Accountancy != event) {
                this._ChattelDocumentOutputWithAccountancy.Accountancy = event;
            }
        }
        // this.Accountancy_SelectedObjectChanged();
    }

    public onAdditionalDocumentCountChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.AdditionalDocumentCount != event) {
                this._ChattelDocumentOutputWithAccountancy.AdditionalDocumentCount = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.Description != event) {
                this._ChattelDocumentOutputWithAccountancy.Description = event;
            }
        }
    }

    public onMKYS_CikisIslemTuruChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_CikisIslemTuru != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_CikisIslemTuru = event;
            }
        }
    }

    public onMKYS_CikisStokHareketTuruChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_CikisStokHareketTuru != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_CikisStokHareketTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimAlan != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimEden != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimEden = event;
            }
        }
    }

    public onoutputStockMovementTypeChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.outputStockMovementType != event) {
                this._ChattelDocumentOutputWithAccountancy.outputStockMovementType = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.StockActionID != event) {
                this._ChattelDocumentOutputWithAccountancy.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.Store != event) {
                this._ChattelDocumentOutputWithAccountancy.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.TransactionDate != event) {
                this._ChattelDocumentOutputWithAccountancy.TransactionDate = event;
            }
        }
    }

    public onWaybillChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.Waybill != event) {
                this._ChattelDocumentOutputWithAccountancy.Waybill = event;
            }
        }
    }

    public onWaybillDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.WaybillDate != event) {
                this._ChattelDocumentOutputWithAccountancy.WaybillDate = event;
            }
        }
    }

    ChattelDocumentDetailsWithAccountancy_CellValueChangedEmitted(data: any) {
        if (data && this.ChattelDocumentDetailsWithAccountancy_CellValueChanged && data.Row && data.Column) {
            this.ChattelDocumentDetailsWithAccountancy_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    onSelectionChange(data: any) {

    }
    public async ChattelDocumentDetailsWithAccountancy_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.ChattelDocumentDetailsWithAccountancy_CellValueChanged(data, rowIndex, columnIndex);
    }

    onRowInsertting(data: ChattelDocumentOutputDetailWithAccountancy) {
    }

    onCellContentClicked(data: any) {
    }

    async initNewRow(data: any) {
    }

    public onIsContainsContributionsChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.IsContainsContributions != event) {
                this._ChattelDocumentOutputWithAccountancy.IsContainsContributions = event;
            }
        }
        this.IsContainsContributions_CheckedChanged();
    }

    private async IsContainsContributions_CheckedChanged(): Promise<void> {
        //await this.controlFreeEnty();
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_CikisIslemTuru, "Value", this.__ttObject, "MKYS_CikisIslemTuru");
        redirectProperty(this.MKYS_CikisStokHareketTuru, "Value", this.__ttObject, "MKYS_CikisStokHareketTuru");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.outputStockMovementType, "Value", this.__ttObject, "outputStockMovementType");
        redirectProperty(this.Waybill, "Text", this.__ttObject, "Waybill");
        redirectProperty(this.WaybillDate, "Value", this.__ttObject, "WaybillDate");
        redirectProperty(this.IsContainsContributions, "Value", this.__ttObject, "IsContainsContributions");
    }

    public initFormControls(): void {
        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 131;

        this.Waybill = new TTVisual.TTTextBox();
        this.Waybill.Name = "Waybill";
        this.Waybill.TabIndex = 134;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.labelWaybillDate = new TTVisual.TTLabel();
        this.labelWaybillDate.Text = i18n("M16573", "İrsaliye Tarihi");
        this.labelWaybillDate.Name = "labelWaybillDate";
        this.labelWaybillDate.TabIndex = 137;

        this.WaybillDate = new TTVisual.TTDateTimePicker();
        this.WaybillDate.Format = DateTimePickerFormat.Short;
        this.WaybillDate.Name = "WaybillDate";
        this.WaybillDate.TabIndex = 136;

        this.labelWaybill = new TTVisual.TTLabel();
        this.labelWaybill.Text = i18n("M16572", "İrsaliye Numarası");
        this.labelWaybill.Name = "labelWaybill";
        this.labelWaybill.TabIndex = 135;

        this.labeloutputStockMovementType = new TTVisual.TTLabel();
        this.labeloutputStockMovementType.Text = i18n("M12372", "Çıkış Hareket Türü");
        this.labeloutputStockMovementType.Name = "labeloutputStockMovementType";
        this.labeloutputStockMovementType.TabIndex = 133;

        this.outputStockMovementType = new TTVisual.TTEnumComboBox();
        this.outputStockMovementType.DataTypeName = "TasinirCikisHareketTurEnum";
        this.outputStockMovementType.Name = "outputStockMovementType";
        this.outputStockMovementType.TabIndex = 132;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 130;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.ChattelDocumentTabcontrol = new TTVisual.TTTabControl();
        this.ChattelDocumentTabcontrol.Name = "ChattelDocumentTabcontrol";
        this.ChattelDocumentTabcontrol.TabIndex = 6;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.ChattelDocumentTabpage = new TTVisual.TTTabPage();
        this.ChattelDocumentTabpage.DisplayIndex = 0;
        this.ChattelDocumentTabpage.TabIndex = 0;
        this.ChattelDocumentTabpage.Text = "Taşınır Malın";
        this.ChattelDocumentTabpage.Name = "ChattelDocumentTabpage";

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 118;

        this.ChattelDocumentDetailsWithAccountancy = new TTVisual.TTGrid();
        this.ChattelDocumentDetailsWithAccountancy.Required = true;
        this.ChattelDocumentDetailsWithAccountancy.Name = "ChattelDocumentDetailsWithAccountancy";
        this.ChattelDocumentDetailsWithAccountancy.TabIndex = 0;
        this.ChattelDocumentDetailsWithAccountancy.Height = 350;
        this.ChattelDocumentDetailsWithAccountancy.AllowUserToDeleteRows = true;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.MaterialChattelDocumentDetailWithAccountancy = new TTVisual.TTListBoxColumn();
        this.MaterialChattelDocumentDetailWithAccountancy.AllowMultiSelect = true;
        this.MaterialChattelDocumentDetailWithAccountancy.ListDefName = "MaterialListDefinition";
        this.MaterialChattelDocumentDetailWithAccountancy.DataMember = "Material";
        this.MaterialChattelDocumentDetailWithAccountancy.AutoCompleteDialogHeight = '60%';
        this.MaterialChattelDocumentDetailWithAccountancy.AutoCompleteDialogWidth = '90%';
        this.MaterialChattelDocumentDetailWithAccountancy.DisplayIndex = 1;
        this.MaterialChattelDocumentDetailWithAccountancy.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialChattelDocumentDetailWithAccountancy.Name = "MaterialChattelDocumentDetailWithAccountancy";
        this.MaterialChattelDocumentDetailWithAccountancy.Width = 450;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Material.Barcode";
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "Material.DistributionTypeName";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 120;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.StoreStock = new TTVisual.TTTextBoxColumn();
        this.StoreStock.DataMember = "StoreStock";
        this.StoreStock.Format = "N2";
        this.StoreStock.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreStock.DisplayIndex = 4;
        this.StoreStock.HeaderText = i18n("M18957", "Mevcut");
        this.StoreStock.Name = "StoreStock";
        this.StoreStock.ReadOnly = true;
        this.StoreStock.Width = 120;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.AmountChattelDocumentDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.AmountChattelDocumentDetailWithAccountancy.DataMember = "Amount";
        this.AmountChattelDocumentDetailWithAccountancy.Format = "N2";
        this.AmountChattelDocumentDetailWithAccountancy.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountChattelDocumentDetailWithAccountancy.DisplayIndex = 5;
        this.AmountChattelDocumentDetailWithAccountancy.HeaderText = i18n("M19030", "Miktar");
        this.AmountChattelDocumentDetailWithAccountancy.Name = "AmountChattelDocumentDetailWithAccountancy";
        this.AmountChattelDocumentDetailWithAccountancy.Width = 120;
        this.AmountChattelDocumentDetailWithAccountancy.IsNumeric = true;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 113;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = "UnitPrice";
        this.UnitPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPrice.DisplayIndex = 6;
        this.UnitPrice.HeaderText = i18n("M11868", "Birim Maliyet Bedeli");
        this.UnitPrice.Name = "UnitPrice";
        this.UnitPrice.ReadOnly = true;
        this.UnitPrice.Visible = false;
        this.UnitPrice.Width = 120;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DataMember = "Price";
        this.Price.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Price.DisplayIndex = 7;
        this.Price.HeaderText = i18n("M23613", "Tutarı");
        this.Price.Name = "Price";
        this.Price.ReadOnly = true;
        this.Price.Visible = false;
        this.Price.Width = 120;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.StockLevelTypeChattelDocumentDetailWithAccountancy = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.DataMember = "StockLevelType";
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.DisplayIndex = 8;
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.Name = "StockLevelTypeChattelDocumentDetailWithAccountancy";
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.Width = 100;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;

        this.StatusChattelDocumentDetailWithAccountancy = new TTVisual.TTEnumComboBoxColumn();
        this.StatusChattelDocumentDetailWithAccountancy.DataTypeName = "StockActionDetailStatusEnum";
        this.StatusChattelDocumentDetailWithAccountancy.DataMember = "Status";
        this.StatusChattelDocumentDetailWithAccountancy.DisplayIndex = 9;
        this.StatusChattelDocumentDetailWithAccountancy.HeaderText = "Durum";
        this.StatusChattelDocumentDetailWithAccountancy.Name = "StatusChattelDocumentDetailWithAccountancy";
        this.StatusChattelDocumentDetailWithAccountancy.Visible = false;
        this.StatusChattelDocumentDetailWithAccountancy.Width = 80;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.labelAccountancy = new TTVisual.TTLabel();
        this.labelAccountancy.Text = i18n("M14873", "Gönderildiği Yer");
        this.labelAccountancy.Name = "labelAccountancy";
        this.labelAccountancy.TabIndex = 121;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;

        this.Accountancy = new TTVisual.TTObjectListBox();
        this.Accountancy.ListDefName = "AccountancyList";
        this.Accountancy.Name = "Accountancy";
        this.Accountancy.TabIndex = 5;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.MKYS_CikisStokHareketTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisStokHareketTuru.DataTypeName = "MKYS_ECikisStokHareketTurEnum";
        this.MKYS_CikisStokHareketTuru.Name = "MKYS_CikisStokHareketTuru";
        this.MKYS_CikisStokHareketTuru.TabIndex = 128;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 111;

        this.lblMKYS_CikisIslemTuru = new TTVisual.TTLabel();
        this.lblMKYS_CikisIslemTuru.Text = i18n("M12381", "Çıkış Türü");
        this.lblMKYS_CikisIslemTuru.Name = "lblMKYS_CikisIslemTuru";
        this.lblMKYS_CikisIslemTuru.TabIndex = 125;

        this.MKYS_CikisIslemTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisIslemTuru.DataTypeName = "MKYS_ECikisIslemTuruEnum";
        this.MKYS_CikisIslemTuru.BackColor = "#F0F0F0";
        this.MKYS_CikisIslemTuru.Enabled = false;
        this.MKYS_CikisIslemTuru.Name = "MKYS_CikisIslemTuru";
        this.MKYS_CikisIslemTuru.TabIndex = 124;

        this.lblMKYS_CikisStokHareketTuru = new TTVisual.TTLabel();
        this.lblMKYS_CikisStokHareketTuru.Text = i18n("M12372", "Çıkış Hareket Türü");
        this.lblMKYS_CikisStokHareketTuru.Name = "lblMKYS_CikisStokHareketTuru";
        this.lblMKYS_CikisStokHareketTuru.TabIndex = 129;

        this.ValueAddedTax = new TTVisual.TTTextBoxColumn();
        this.ValueAddedTax.DataMember = "VatRate";
        this.ValueAddedTax.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ValueAddedTax.DisplayIndex = 6;
        this.ValueAddedTax.HeaderText = i18n("M17457", "KDV Oranı");
        this.ValueAddedTax.Name = "ValueAddedTax";
        this.ValueAddedTax.ReadOnly = true;
        this.ValueAddedTax.Width = 100;

        this.IsContainsContributions = new TTVisual.TTCheckBox();
        this.IsContainsContributions.Value = false;
        this.IsContainsContributions.Title = "Katkı Payı İçerir";
        this.IsContainsContributions.Name = "IsContainsContributions";
        this.IsContainsContributions.TabIndex = 128;

        //this.ChattelDocumentDetailsWithAccountancyColumns = [this.Detail, this.MaterialChattelDocumentDetailWithAccountancy, this.Barcode, this.DistributionType, this.StoreStock, this.ValueAddedTax, this.AmountChattelDocumentDetailWithAccountancy, this.UnitPrice, this.Price, this.StockLevelTypeChattelDocumentDetailWithAccountancy, this.StatusChattelDocumentDetailWithAccountancy];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.ChattelDocumentTabcontrol.Controls = [this.ChattelDocumentTabpage];
        this.ChattelDocumentTabpage.Controls = [this.ChattelDocumentDetailsWithAccountancy];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.IsContainsContributions, this.Waybill, this.TTTeslimEdenButon, this.labelWaybillDate, this.TTTeslimAlanButon, this.WaybillDate, this.labelMKYS_TeslimEden, this.labelWaybill, this.MKYS_TeslimEden, this.labeloutputStockMovementType, this.MKYS_TeslimAlan, this.outputStockMovementType, this.Description, this.labelStore, this.StockActionID, this.Store, this.labelMKYS_TeslimAlan, this.ChattelDocumentTabcontrol, this.labelTransactionDate, this.ChattelDocumentTabpage, this.TransactionDate, this.ChattelDocumentDetailsWithAccountancy, this.labelStockActionID, this.Detail, this.DescriptionAndSignTabControl, this.MaterialChattelDocumentDetailWithAccountancy, this.SignTabpage, this.Barcode, this.StockActionSignDetails, this.DistributionType, this.SignUserType, this.StoreStock, this.SignUser, this.AmountChattelDocumentDetailWithAccountancy, this.IsDeputy, this.UnitPrice, this.ttlabel1, this.Price, this.StockLevelTypeChattelDocumentDetailWithAccountancy, this.StatusChattelDocumentDetailWithAccountancy, this.labelAccountancy, this.Accountancy, this.MKYS_CikisStokHareketTuru, this.lblMKYS_CikisIslemTuru, this.MKYS_CikisIslemTuru, this.lblMKYS_CikisStokHareketTuru];

    }


}
