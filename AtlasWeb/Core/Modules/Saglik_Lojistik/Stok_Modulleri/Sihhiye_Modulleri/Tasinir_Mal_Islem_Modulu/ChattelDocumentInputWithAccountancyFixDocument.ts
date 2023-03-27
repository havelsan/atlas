//$38F75779
import { Component, ViewChild, OnInit, ApplicationRef, NgZone, ChangeDetectorRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ChattelDocumentInputWithAccountancyFixDocumentViewModel } from './ChattelDocumentInputWithAccountancyFixDocumentViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseChattelDocumentInputWithAccountancyForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentInputWithAccountancyForm";
import { ChattelDocumentInputWithAccountancy, ConsumableMaterialDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Accountancy } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentInputDetailWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';

import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';
import { IActiveUserService } from 'app/Fw/Services/IActiveUserService';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { IModalService } from 'app/Fw/Services/IModalService';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { TTException } from 'app/NebulaClient/Utils/Exceptions/TTException';

@Component({
    selector: 'ChattelDocumentInputWithAccountancyFixDocument',
    templateUrl: './ChattelDocumentInputWithAccountancyFixDocument.html',
    providers: [MessageService]
})
export class ChattelDocumentInputWithAccountancyFixDocument extends BaseChattelDocumentInputWithAccountancyForm implements OnInit {
    public ChattelDocumentDetailsWithAccountancyColumns = [];
    public StockActionSignDetailsColumns = [];
    public chattelDocumentInputWithAccountancyFixDocumentViewModel: ChattelDocumentInputWithAccountancyFixDocumentViewModel = new ChattelDocumentInputWithAccountancyFixDocumentViewModel();
    public get _ChattelDocumentInputWithAccountancy(): ChattelDocumentInputWithAccountancy {
        return this._TTObject as ChattelDocumentInputWithAccountancy;
    }
    private ChattelDocumentInputWithAccountancyFixDocument_DocumentUrl: string = '/api/ChattelDocumentInputWithAccountancyService/ChattelDocumentInputWithAccountancyFixDocument';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private modalService: IModalService,
        private reportService: AtlasReportService,
        private changeDetectorRef: ChangeDetectorRef,
        private activeUserService: IActiveUserService,
        protected ngZone: NgZone, protected objectContextService: ObjectContextService) {
        super(httpService, messageService, ngZone, objectContextService);
        this._DocumentServiceUrl = this.ChattelDocumentInputWithAccountancyFixDocument_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
    }
    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        for (let detIn of this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy) {
            let price: number = 0;
            if (detIn.Amount != null && detIn.UnitPrice != null) {
                if (detIn.Amount > 0 && detIn.UnitPrice > 0) {
                    price = detIn.Amount * detIn.UnitPrice;
                    detIn.Price = price;
                }
            }
        }

        let priceCalc: Array<number> = new Array<number>();
        let total: number = 0, salesTotal = 0, totalPrice = 0;
        priceCalc.push(total);
        priceCalc.push(salesTotal);
        priceCalc.push(totalPrice);
        priceCalc = await this.CalcFinalPrice(priceCalc);
        this.txtTotalNotDiscount.Text = priceCalc[0].toFixed(2);
        this.txtSalesTotal.Text = priceCalc[1].toFixed(2);
        this.txtTotalPrice.Text = priceCalc[2].toFixed(2);
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        for (let detail of this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy) {
            if (detail.ExpirationDate === null || detail.ExpirationDate == Date.MinValue || detail.ExpirationDate == undefined) {
                if (detail.Material.ObjectDefID != ConsumableMaterialDefinition.ObjectDefID) {
                    throw new TTException(detail.Material.Name + " isimli malzemenin Son Kullanma tarihi boş geçilemez.");
                } else {
                    let mat: ConsumableMaterialDefinition = detail.Material as ConsumableMaterialDefinition;
                    if (mat.HasEstimatedTime == true) {
                        throw new TTException(detail.Material.Name + " isimli malzemenin Son Kullanma tarihi boş geçilemez.");
                    }
                }
            }
            if (detail.VatRate === null || detail.VatRate == undefined) {
                throw new TTException(detail.Material.Name + " isimli malzemenin KDV alanı geçilemez.");
            }
        }

        this._ViewModel.ChattelDocumentDetailsWithPurchaseGridList = this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy;
        this._ViewModel.PTSStockActionDetails = this._ChattelDocumentInputWithAccountancy.PTSStockActionDetails;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChattelDocumentInputWithAccountancy();
        this.chattelDocumentInputWithAccountancyFixDocumentViewModel = new ChattelDocumentInputWithAccountancyFixDocumentViewModel();
        this._ViewModel = this.chattelDocumentInputWithAccountancyFixDocumentViewModel;
        this.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy = this._TTObject as ChattelDocumentInputWithAccountancy;
        this.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy.Store = new Store();
        this.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy.Accountancy = new Accountancy();
        this.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy = new Array<ChattelDocumentInputDetailWithAccountancy>();
        this.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.chattelDocumentInputWithAccountancyFixDocumentViewModel = this._ViewModel as ChattelDocumentInputWithAccountancyFixDocumentViewModel;
        that._TTObject = this.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy;
        if (this.chattelDocumentInputWithAccountancyFixDocumentViewModel == null)
            this.chattelDocumentInputWithAccountancyFixDocumentViewModel = new ChattelDocumentInputWithAccountancyFixDocumentViewModel();
        if (this.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy == null)
            this.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy = new ChattelDocumentInputWithAccountancy();
        let budgetTypeDefinitionObjectID = that.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy["BudgetTypeDefinition"];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === "string")) {
            let budgetTypeDefinition = that.chattelDocumentInputWithAccountancyFixDocumentViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.chattelDocumentInputWithAccountancyFixDocumentViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy.Store = store;
            }
        }

        let accountancyObjectID = that.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy["Accountancy"];
        if (accountancyObjectID != null && (typeof accountancyObjectID === "string")) {
            let accountancy = that.chattelDocumentInputWithAccountancyFixDocumentViewModel.Accountancys.find(o => o.ObjectID.toString() === accountancyObjectID.toString());
            if (accountancy) {
                that.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy.Accountancy = accountancy;
            }
        }

        that.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy = that.chattelDocumentInputWithAccountancyFixDocumentViewModel.ChattelDocumentDetailsWithAccountancyGridList;
        for (let detailItem of that.chattelDocumentInputWithAccountancyFixDocumentViewModel.ChattelDocumentDetailsWithAccountancyGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.chattelDocumentInputWithAccountancyFixDocumentViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.chattelDocumentInputWithAccountancyFixDocumentViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.chattelDocumentInputWithAccountancyFixDocumentViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.chattelDocumentInputWithAccountancyFixDocumentViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }

        that.chattelDocumentInputWithAccountancyFixDocumentViewModel._ChattelDocumentInputWithAccountancy.StockActionSignDetails = that.chattelDocumentInputWithAccountancyFixDocumentViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.chattelDocumentInputWithAccountancyFixDocumentViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === "string")) {
                let signUser = that.chattelDocumentInputWithAccountancyFixDocumentViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }

        }

    }

    async ngOnInit() {
        await this.load();
        if (this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = '#F0F0F0';
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = 'Taşınır Mal Giriş ( Belge Düzeltme )';
        this.changeDetectorRef.detectChanges();
    }

    public onAccountancyChanged(event): void {
        if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Accountancy != event) {
            this._ChattelDocumentInputWithAccountancy.Accountancy = event;
        }
    }

    public onBudgetTypeDefinitionChanged(event): void {
        if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition != event) {
            this._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = event;
        }
    }

    public onDescriptionChanged(event): void {
        if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Description != event) {
            this._ChattelDocumentInputWithAccountancy.Description = event;
        }
    }

    public oninputWithAccountancyTypeChanged(event): void {
        if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType != event) {
            this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType = event;
        }
    }

    public onMKYS_EAlimYontemiChanged(event): void {
        if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_EAlimYontemi != event) {
            this._ChattelDocumentInputWithAccountancy.MKYS_EAlimYontemi = event;
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup != event) {
            this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup = event;
        }
    }

    public onMKYS_ETedarikTuruChanged(event): void {
        if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru != event) {
            this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru = event;
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlan != event) {
            this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlan = event;
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEden != event) {
            this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEden = event;
        }
    }

    public onStockActionIDChanged(event): void {
        if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.StockActionID != event) {
            this._ChattelDocumentInputWithAccountancy.StockActionID = event;
        }
    }

    public onStoreChanged(event): void {
        if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Store != event) {
            this._ChattelDocumentInputWithAccountancy.Store = event;
        }
    }

    public onTransactionDateChanged(event): void {
        if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.TransactionDate != event) {
            this._ChattelDocumentInputWithAccountancy.TransactionDate = event;
        }
    }

    public onWaybillChanged(event): void {
        if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Waybill != event) {
            this._ChattelDocumentInputWithAccountancy.Waybill = event;
        }
    }

    public onWaybillDateChanged(event): void {
        if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.WaybillDate != event) {
            this._ChattelDocumentInputWithAccountancy.WaybillDate = event;
        }
    }



    ChattelDocumentDetailsWithAccountancy_CellValueChangedEmitted(data: any) {
        /*if (data && this.ChattelDocumentDetailsWithAccountancy_CellValueChanged && data.Row && data.Column) {
            this.ChattelDocumentDetailsWithAccountancy.CurrentCell =
                {
                    OwningRow: data.Row,
                    OwningColumn: data.Column
                };
            this.ChattelDocumentDetailsWithAccountancy_CellValueChanged(data.RowIndex, data.ColIndex);
        }*/
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_EMalzemeGrup, "Value", this.__ttObject, "MKYS_EMalzemeGrup");
        redirectProperty(this.MKYS_ETedarikTuru, "Value", this.__ttObject, "MKYS_ETedarikTuru");
        redirectProperty(this.MKYS_EAlimYontemi, "Value", this.__ttObject, "MKYS_EAlimYontemi");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.inputWithAccountancyType, "Value", this.__ttObject, "inputWithAccountancyType");
        redirectProperty(this.Waybill, "Text", this.__ttObject, "Waybill");
        redirectProperty(this.WaybillDate, "Value", this.__ttObject, "WaybillDate");
    }

    public initFormControls(): void {
        this.Waybill = new TTVisual.TTTextBox();
        this.Waybill.Name = "Waybill";
        this.Waybill.TabIndex = 132;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.txtTotalPrice = new TTVisual.TTTextBox();
        this.txtTotalPrice.BackColor = "#F0F0F0";
        this.txtTotalPrice.ReadOnly = true;
        this.txtTotalPrice.Name = "txtTotalPrice";
        this.txtTotalPrice.TabIndex = 124;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.labelWaybillDate = new TTVisual.TTLabel();
        this.labelWaybillDate.Text = "İrsaliye Tarihi";
        this.labelWaybillDate.Name = "labelWaybillDate";
        this.labelWaybillDate.TabIndex = 135;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = "Teslim Eden";
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.WaybillDate = new TTVisual.TTDateTimePicker();
        this.WaybillDate.Format = DateTimePickerFormat.Long;
        this.WaybillDate.Name = "WaybillDate";
        this.WaybillDate.TabIndex = 134;

        this.MKYS_TeslimEden = new TTVisual.TTTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 118;

        this.labelWaybill = new TTVisual.TTLabel();
        this.labelWaybill.Text = "İrsaliye Numarası";
        this.labelWaybill.Name = "labelWaybill";
        this.labelWaybill.TabIndex = 133;

        this.MKYS_TeslimAlan = new TTVisual.TTTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.labelinputWithAccountancyType = new TTVisual.TTLabel();
        this.labelinputWithAccountancyType.Text = "Giriş Türü";
        this.labelinputWithAccountancyType.Name = "labelinputWithAccountancyType";
        this.labelinputWithAccountancyType.TabIndex = 131;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.inputWithAccountancyType = new TTVisual.TTEnumComboBox();
        this.inputWithAccountancyType.DataTypeName = "TasinirMalGirisTurEnum";
        this.inputWithAccountancyType.Name = "inputWithAccountancyType";
        this.inputWithAccountancyType.TabIndex = 130;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = "Bütçe Türü";
        this.labelBudgetTypeDefinition.Name = "labelBudgetTypeDefinition";
        this.labelBudgetTypeDefinition.TabIndex = 129;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = "Teslim Alan";
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.Required = true;
        this.BudgetTypeDefinition.ListDefName = "BugdetTypeList";
        this.BudgetTypeDefinition.Name = "BudgetTypeDefinition";
        this.BudgetTypeDefinition.TabIndex = 128;
        this.BudgetTypeDefinition.Enabled = false;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = "İşlem Tarihi";
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = "Giriş Yapılan Depo";
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 127;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreDefinitionList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 126;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = "İşlem No";
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 113;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "Fatura Tutarı";
        this.ttlabel2.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 125;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.labelAccountancy = new TTVisual.TTLabel();
        this.labelAccountancy.Text = "Geldiği Yer";
        this.labelAccountancy.Name = "labelAccountancy";
        this.labelAccountancy.TabIndex = 122;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = "İmzalar";
        this.SignTabpage.Name = "SignTabpage";

        this.Accountancy = new TTVisual.TTObjectListBox();
        this.Accountancy.ReadOnly = true;
        this.Accountancy.ListDefName = "AccountancyList";
        this.Accountancy.Name = "Accountancy";
        this.Accountancy.TabIndex = 121;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;

        this.ChattelDocumentTabcontrol = new TTVisual.TTTabControl();
        this.ChattelDocumentTabcontrol.Name = "ChattelDocumentTabcontrol";
        this.ChattelDocumentTabcontrol.TabIndex = 120;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = "İmza Tipi";
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.ChattelDocumentDetailTabpage = new TTVisual.TTTabPage();
        this.ChattelDocumentDetailTabpage.DisplayIndex = 0;
        this.ChattelDocumentDetailTabpage.TabIndex = 0;
        this.ChattelDocumentDetailTabpage.Text = "Taşınır Malın";
        this.ChattelDocumentDetailTabpage.Name = "ChattelDocumentDetailTabpage";

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = "Personelin Adı, Soyadı";
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;

        this.ChattelDocumentDetailsWithAccountancy = new TTVisual.TTGrid();
        this.ChattelDocumentDetailsWithAccountancy.Required = true;
        this.ChattelDocumentDetailsWithAccountancy.Name = "ChattelDocumentDetailsWithAccountancy";
        this.ChattelDocumentDetailsWithAccountancy.TabIndex = 0;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = "Vekil";
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = "Detay";
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ReadOnly = true;
        this.Detail.ToolTipText = "Detay";
        this.Detail.Width = 80;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Açıklama";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 111;

        this.MaterialStockActionDetailIn = new TTVisual.TTListBoxColumn();
        this.MaterialStockActionDetailIn.AllowMultiSelect = true;
        this.MaterialStockActionDetailIn.ListDefName = "MaterialListDefinition";
        this.MaterialStockActionDetailIn.DataMember = "Material";
        this.MaterialStockActionDetailIn.DisplayIndex = 1;
        this.MaterialStockActionDetailIn.HeaderText = "Malzeme Adı";
        this.MaterialStockActionDetailIn.Name = "MaterialStockActionDetailIn";
        this.MaterialStockActionDetailIn.Width = 300;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = "Ölçü Birimi";
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.SentAmountChattelDocumentInputDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.SentAmountChattelDocumentInputDetailWithAccountancy.DataMember = "SentAmount";
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Format = "#,###.####";
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.SentAmountChattelDocumentInputDetailWithAccountancy.DisplayIndex = 4;
        this.SentAmountChattelDocumentInputDetailWithAccountancy.HeaderText = "Gönderilen Miktar";
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Name = "SentAmountChattelDocumentInputDetailWithAccountancy";
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Width = 100;

        this.AmountStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.AmountStockActionDetailIn.DataMember = "Amount";
        this.AmountStockActionDetailIn.Format = "#,###.####";
        this.AmountStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountStockActionDetailIn.DisplayIndex = 5;
        this.AmountStockActionDetailIn.HeaderText = "Alınan Miktar";
        this.AmountStockActionDetailIn.Name = "AmountStockActionDetailIn";
        this.AmountStockActionDetailIn.Width = 75;

        this.NotDiscountedUnitPrice = new TTVisual.TTTextBoxColumn();
        this.NotDiscountedUnitPrice.DataMember = "NotDiscountedUnitPrice";
        this.NotDiscountedUnitPrice.Format = "#,###.#########";
        this.NotDiscountedUnitPrice.DisplayIndex = 6;
        this.NotDiscountedUnitPrice.HeaderText = "İndirimsiz Birim Fiyatı";
        this.NotDiscountedUnitPrice.Name = "NotDiscountedUnitPrice";
        this.NotDiscountedUnitPrice.Width = 100;

        this.UnitPriceStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.UnitPriceStockActionDetailIn.DataMember = "UnitPrice";
        this.UnitPriceStockActionDetailIn.Format = "#,###.#########";
        this.UnitPriceStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPriceStockActionDetailIn.DisplayIndex = 7;
        this.UnitPriceStockActionDetailIn.HeaderText = "Birim Maliyet Bedeli";
        this.UnitPriceStockActionDetailIn.Name = "UnitPriceStockActionDetailIn";
        this.UnitPriceStockActionDetailIn.ReadOnly = true;
        this.UnitPriceStockActionDetailIn.Width = 75;

        this.MKYS_IndirimOranı = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimOranı.DataMember = "DiscountRate";
        this.MKYS_IndirimOranı.DisplayIndex = 8;
        this.MKYS_IndirimOranı.HeaderText = "İndirim Oranı";
        this.MKYS_IndirimOranı.Name = "MKYS_IndirimOranı";
        this.MKYS_IndirimOranı.Width = 100;

        this.MKYS_IndirimTutari = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimTutari.DataMember = "DiscountAmount";
        this.MKYS_IndirimTutari.Format = "#,###.#########";
        this.MKYS_IndirimTutari.DisplayIndex = 9;
        this.MKYS_IndirimTutari.HeaderText = "İndirim Tutarı";
        this.MKYS_IndirimTutari.Name = "MKYS_IndirimTutari";
        this.MKYS_IndirimTutari.ReadOnly = true;
        this.MKYS_IndirimTutari.Visible = false;
        this.MKYS_IndirimTutari.Width = 100;

        this.TotalPriceNotDiscount = new TTVisual.TTTextBoxColumn();
        this.TotalPriceNotDiscount.DataMember = "TotalPriceNotDiscount";
        this.TotalPriceNotDiscount.Format = "#,###.#########";
        this.TotalPriceNotDiscount.DisplayIndex = 10;
        this.TotalPriceNotDiscount.HeaderText = "İndirimsiz Toplam Fiyat";
        this.TotalPriceNotDiscount.Name = "TotalPriceNotDiscount";
        this.TotalPriceNotDiscount.ReadOnly = true;
        this.TotalPriceNotDiscount.Width = 100;

        this.TotalDiscountAmount = new TTVisual.TTTextBoxColumn();
        this.TotalDiscountAmount.DataMember = "TotalDiscountAmount";
        this.TotalDiscountAmount.Format = "#,###.#########";
        this.TotalDiscountAmount.DisplayIndex = 11;
        this.TotalDiscountAmount.HeaderText = "Toplam İndirim Tutarı";
        this.TotalDiscountAmount.Name = "TotalDiscountAmount";
        this.TotalDiscountAmount.ReadOnly = true;
        this.TotalDiscountAmount.Width = 100;

        this.TotalPrice = new TTVisual.TTTextBoxColumn();
        this.TotalPrice.DataMember = "Price";
        this.TotalPrice.Format = "#,###.#########";
        this.TotalPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.TotalPrice.DisplayIndex = 12;
        this.TotalPrice.HeaderText = "Tutarı";
        this.TotalPrice.Name = "TotalPrice";
        this.TotalPrice.ReadOnly = true;
        this.TotalPrice.Width = 120;

        this.LotNo = new TTVisual.TTTextBoxColumn();
        this.LotNo.DataMember = "LotNo";
        this.LotNo.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.LotNo.DisplayIndex = 13;
        this.LotNo.HeaderText = "Lot No.";
        this.LotNo.Name = "LotNo";
        this.LotNo.Width = 100;

        this.ExpirationDateStockActionDetailIn = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDateStockActionDetailIn.Format = DateTimePickerFormat.Custom;
        this.ExpirationDateStockActionDetailIn.CustomFormat = "MM/yyyy";
        this.ExpirationDateStockActionDetailIn.DataMember = "ExpirationDate";
        this.ExpirationDateStockActionDetailIn.DisplayIndex = 14;
        this.ExpirationDateStockActionDetailIn.HeaderText = "Son Kullanma Tarihi";
        this.ExpirationDateStockActionDetailIn.Name = "ExpirationDateStockActionDetailIn";
        this.ExpirationDateStockActionDetailIn.Width = 120;

        this.StockLevelTypeStockActionDetailIn = new TTVisual.TTListDefComboBoxColumn();
        this.StockLevelTypeStockActionDetailIn.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeStockActionDetailIn.DataMember = "StockLevelType";
        this.StockLevelTypeStockActionDetailIn.Required = true;
        this.StockLevelTypeStockActionDetailIn.DisplayIndex = 15;
        this.StockLevelTypeStockActionDetailIn.HeaderText = "Malın Durumu";
        this.StockLevelTypeStockActionDetailIn.Name = "StockLevelTypeStockActionDetailIn";
        this.StockLevelTypeStockActionDetailIn.Width = 100;

        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.DataMember = "ConflictSubject";
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.DisplayIndex = 16;
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.HeaderText = "Uyuşmazlık Konusu";
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.Name = "ConflictSubjectChattelDocumentInputDetailWithAccountancy";
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.Width = 100;

        this.StatusStockActionDetailIn = new TTVisual.TTEnumComboBoxColumn();
        this.StatusStockActionDetailIn.DataTypeName = "StockActionDetailStatusEnum";
        this.StatusStockActionDetailIn.DataMember = "Status";
        this.StatusStockActionDetailIn.DisplayIndex = 17;
        this.StatusStockActionDetailIn.HeaderText = "Durum";
        this.StatusStockActionDetailIn.Name = "StatusStockActionDetailIn";
        this.StatusStockActionDetailIn.Visible = false;
        this.StatusStockActionDetailIn.Width = 80;

        this.MKYS_EdinimYili = new TTVisual.TTTextBoxColumn();
        this.MKYS_EdinimYili.DataMember = "RetrievalYear";
        this.MKYS_EdinimYili.DisplayIndex = 18;
        this.MKYS_EdinimYili.HeaderText = "Edinim Yılı";
        this.MKYS_EdinimYili.Name = "MKYS_EdinimYili";
        this.MKYS_EdinimYili.Width = 100;

        this.MKYS_UretimTarihi = new TTVisual.TTDateTimePickerColumn();
        this.MKYS_UretimTarihi.DataMember = "ProductionDate";
        this.MKYS_UretimTarihi.DisplayIndex = 19;
        this.MKYS_UretimTarihi.HeaderText = "Üretim Tarihi";
        this.MKYS_UretimTarihi.Name = "MKYS_UretimTarihi";
        this.MKYS_UretimTarihi.Width = 100;

        this.ConflictAmountChattelDocumentInputDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.DataMember = "ConflictAmount";
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Format = "#,###.####";
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.DisplayIndex = 20;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.HeaderText = "Uyuşmazlık Miktarı";
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Name = "ConflictAmountChattelDocumentInputDetailWithAccountancy";
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.ReadOnly = true;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Visible = false;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Width = 100;

        this.txtSalesTotal = new TTVisual.TTTextBox();
        this.txtSalesTotal.BackColor = "#F0F0F0";
        this.txtSalesTotal.ReadOnly = true;
        this.txtSalesTotal.Name = "txtSalesTotal";
        this.txtSalesTotal.TabIndex = 124;

        this.txtTotalNotDiscount = new TTVisual.TTTextBox();
        this.txtTotalNotDiscount.BackColor = "#F0F0F0";
        this.txtTotalNotDiscount.ReadOnly = true;
        this.txtTotalNotDiscount.Name = "txtTotalNotDiscount";
        this.txtTotalNotDiscount.TabIndex = 124;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "İndirim Tutarı";
        this.ttlabel3.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 125;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Toplam Tutar";
        this.ttlabel4.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 125;

        this.labelMKYS_ETedarikTuru = new TTVisual.TTLabel();
        this.labelMKYS_ETedarikTuru.Text = "Tedarik Türü";
        this.labelMKYS_ETedarikTuru.Name = "labelMKYS_ETedarikTuru";
        this.labelMKYS_ETedarikTuru.TabIndex = 14;

        this.MKYS_ETedarikTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_ETedarikTuru.DataTypeName = "MKYS_ETedarikTurEnum";
        this.MKYS_ETedarikTuru.Required = true;
        this.MKYS_ETedarikTuru.BackColor = "#FFE3C6";
        this.MKYS_ETedarikTuru.Name = "MKYS_ETedarikTuru";
        this.MKYS_ETedarikTuru.TabIndex = 15;

        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = "MKYS_EMalzemeGrupEnum";
        this.MKYS_EMalzemeGrup.BackColor = "#F0F0F0";
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = "MKYS_EMalzemeGrup";
        this.MKYS_EMalzemeGrup.TabIndex = 17;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = "Malzeme Grup";
        this.labelMKYS_EMalzemeGrup.Name = "labelMKYS_EMalzemeGrup";
        this.labelMKYS_EMalzemeGrup.TabIndex = 16;

        this.MKYS_EAlimYontemi = new TTVisual.TTEnumComboBox();
        this.MKYS_EAlimYontemi.DataTypeName = "MKYS_EAlimYontemiEnum";
        this.MKYS_EAlimYontemi.Required = true;
        this.MKYS_EAlimYontemi.BackColor = "#FFE3C6";
        this.MKYS_EAlimYontemi.Name = "MKYS_EAlimYontemi";
        this.MKYS_EAlimYontemi.TabIndex = 19;

        this.labelMKYS_EAlimYontemi = new TTVisual.TTLabel();
        this.labelMKYS_EAlimYontemi.Text = "Alım Yöntemi";
        this.labelMKYS_EAlimYontemi.Name = "labelMKYS_EAlimYontemi";
        this.labelMKYS_EAlimYontemi.TabIndex = 18;

        this.GetWaybill = new TTVisual.TTButton();
        this.GetWaybill.Text = "İrsaliye Getir";
        this.GetWaybill.Name = "GetWaybill";
        this.GetWaybill.TabIndex = 147;

        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.ChattelDocumentDetailsWithAccountancyColumns = [this.Detail, this.MaterialStockActionDetailIn, this.Barcode, this.DistributionType, this.SentAmountChattelDocumentInputDetailWithAccountancy, this.AmountStockActionDetailIn, this.NotDiscountedUnitPrice, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimOranı, this.MKYS_IndirimTutari, this.TotalPriceNotDiscount, this.TotalDiscountAmount, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn, this.StockLevelTypeStockActionDetailIn, this.ConflictSubjectChattelDocumentInputDetailWithAccountancy, this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi, this.ConflictAmountChattelDocumentInputDetailWithAccountancy];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.ChattelDocumentTabcontrol.Controls = [this.ChattelDocumentDetailTabpage];
        this.ChattelDocumentDetailTabpage.Controls = [this.ChattelDocumentDetailsWithAccountancy];
        this.Controls = [this.Waybill, this.TTTeslimEdenButon, this.txtTotalPrice, this.TTTeslimAlanButon, this.labelWaybillDate, this.labelMKYS_TeslimEden, this.WaybillDate, this.MKYS_TeslimEden, this.labelWaybill, this.MKYS_TeslimAlan, this.labelinputWithAccountancyType, this.Description, this.inputWithAccountancyType, this.StockActionID, this.labelBudgetTypeDefinition, this.labelMKYS_TeslimAlan, this.BudgetTypeDefinition, this.labelTransactionDate, this.labelStore, this.TransactionDate, this.Store, this.labelStockActionID, this.ttlabel2, this.DescriptionAndSignTabControl, this.labelAccountancy, this.SignTabpage, this.Accountancy, this.StockActionSignDetails, this.ChattelDocumentTabcontrol, this.SignUserType, this.ChattelDocumentDetailTabpage, this.SignUser, this.ChattelDocumentDetailsWithAccountancy, this.IsDeputy, this.Detail, this.ttlabel1, this.MaterialStockActionDetailIn, this.Barcode, this.DistributionType, this.SentAmountChattelDocumentInputDetailWithAccountancy, this.AmountStockActionDetailIn, this.NotDiscountedUnitPrice, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimOranı, this.MKYS_IndirimTutari, this.TotalPriceNotDiscount, this.TotalDiscountAmount, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn, this.StockLevelTypeStockActionDetailIn, this.ConflictSubjectChattelDocumentInputDetailWithAccountancy, this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi, this.ConflictAmountChattelDocumentInputDetailWithAccountancy, this.txtSalesTotal, this.txtTotalNotDiscount, this.ttlabel3, this.ttlabel4, this.labelMKYS_ETedarikTuru, this.MKYS_ETedarikTuru, this.MKYS_EMalzemeGrup, this.labelMKYS_EMalzemeGrup, this.MKYS_EAlimYontemi, this.labelMKYS_EAlimYontemi, this.GetWaybill];

    }


}
