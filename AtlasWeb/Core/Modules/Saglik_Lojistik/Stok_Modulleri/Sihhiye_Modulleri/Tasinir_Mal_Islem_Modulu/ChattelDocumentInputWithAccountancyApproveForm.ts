//$5D9DB94D
import { Component, OnInit, NgZone } from '@angular/core';
import { ChattelDocumentInputWithAccountancyApproveFormViewModel } from './ChattelDocumentInputWithAccountancyApproveFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Accountancy } from 'NebulaClient/Model/AtlasClientModel';
import { BaseChattelDocumentInputWithAccountancyForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentInputWithAccountancyForm";
import { ChattelDocumentInputWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentInputDetailWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { StockActionService } from 'ObjectClassService/StockActionService';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';

@Component({
    selector: 'ChattelDocumentInputWithAccountancyApproveForm',
    templateUrl: './ChattelDocumentInputWithAccountancyApproveForm.html',
    providers: [MessageService]
})
export class ChattelDocumentInputWithAccountancyApproveForm extends BaseChattelDocumentInputWithAccountancyForm implements OnInit {
    public ChattelDocumentDetailsWithAccountancyColumns = [];
    public StockActionSignDetailsColumns = [];
    public chattelDocumentInputWithAccountancyApproveFormViewModel: ChattelDocumentInputWithAccountancyApproveFormViewModel = new ChattelDocumentInputWithAccountancyApproveFormViewModel();
    public get _ChattelDocumentInputWithAccountancy(): ChattelDocumentInputWithAccountancy {
        return this._TTObject as ChattelDocumentInputWithAccountancy;
    }
    private ChattelDocumentInputWithAccountancyApproveForm_DocumentUrl: string = '/api/ChattelDocumentInputWithAccountancyService/ChattelDocumentInputWithAccountancyApproveForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone, protected objectContextService: ObjectContextService) {
        super(httpService, messageService, ngZone, objectContextService);
        this._DocumentServiceUrl = this.ChattelDocumentInputWithAccountancyApproveForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef != null) {
            super.AfterContextSavedScript(transDef);
            let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ChattelDocumentInputWithAccountancy.ObjectID.toString());
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
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        /*if (transDef !== null) {
            let err: boolean = false;
            let errMsg: string = "\"\"";
            let compInputs: Array<any> = (await ChattelDocumentInputWithAccountancyService.GetSameBaseNumberNQL(this._ChattelDocumentInputWithAccountancy.ObjectContext, this._ChattelDocumentInputWithAccountancy.AccountingTerm.ObjectID, this._ChattelDocumentInputWithAccountancy.StockActionID.Value.toString(), this._ChattelDocumentInputWithAccountancy.Accountancy.ObjectID));
            for (let inputDocument of compInputs) {
                if (inputDocument.ObjectID.Equals(this._ChattelDocumentInputWithAccountancy.ObjectID) === false) {
                    err = true;
                    errMsg = "Bu Dayanak numarası " + inputDocument.StockActionID.toString() + " işlem numarası ile daha önce girilmiştir.\r\nDevam etmek istiyormusunuz?";
                }
            }
            if (err) {
                let result: string = TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Devam,&Vazgeç", "D,V", "Uyarı", "Dayanak Numarası Uyarısı", errMsg);
                if (result === "V") {
                    throw new TTException("Dayanak numarası değiştirirebilirsiniz.");
                }
            }
        }*/
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
    protected async PreScript() {
        super.PreScript();
        /* if (this._ChattelDocumentInputWithAccountancy.IsConflictExist === false)
             DropCurrentStateReport(typeof TTReportClasses.I_ChattelDocumentConflictReport);*/
        if (this._ChattelDocumentInputWithAccountancy.InPatientPhysicianApplication != null) {
            this.Description.Enabled = false;
        }
    }


    DocumentRecordLogs_CellValueChangedEmitted(data: any) { }
    initDocumentRecordLogsNewRow(data: any) { }
    onDocumentRecordLogsRowInserting(data: any) { }
    onSelectionChangeDocumentRecordLogs(data: any) { }
    rowInserting(data: any) { }
    initNewRow(data: any) { }
    cellContentClicked(data: any) { }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChattelDocumentInputWithAccountancy();
        this.chattelDocumentInputWithAccountancyApproveFormViewModel = new ChattelDocumentInputWithAccountancyApproveFormViewModel();
        this._ViewModel = this.chattelDocumentInputWithAccountancyApproveFormViewModel;
        this.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy = this._TTObject as ChattelDocumentInputWithAccountancy;
        this.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy.Store = new Store();
        this.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy.Accountancy = new Accountancy();
        this.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy = new Array<ChattelDocumentInputDetailWithAccountancy>();
        this.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.chattelDocumentInputWithAccountancyApproveFormViewModel = this._ViewModel as ChattelDocumentInputWithAccountancyApproveFormViewModel;
        that._TTObject = this.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy;
        if (this.chattelDocumentInputWithAccountancyApproveFormViewModel == null)
            this.chattelDocumentInputWithAccountancyApproveFormViewModel = new ChattelDocumentInputWithAccountancyApproveFormViewModel();
        if (this.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy == null)
            this.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy = new ChattelDocumentInputWithAccountancy();
        let budgetTypeDefinitionObjectID = that.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy["BudgetTypeDefinition"];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === "string")) {
            let budgetTypeDefinition = that.chattelDocumentInputWithAccountancyApproveFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.chattelDocumentInputWithAccountancyApproveFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy.Store = store;
            }
        }
        let accountancyObjectID = that.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy["Accountancy"];
        if (accountancyObjectID != null && (typeof accountancyObjectID === "string")) {
            let accountancy = that.chattelDocumentInputWithAccountancyApproveFormViewModel.Accountancys.find(o => o.ObjectID.toString() === accountancyObjectID.toString());
            if (accountancy) {
                that.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy.Accountancy = accountancy;
            }
        }
        that.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy = that.chattelDocumentInputWithAccountancyApproveFormViewModel.ChattelDocumentDetailsWithAccountancyGridList;
        for (let detailItem of that.chattelDocumentInputWithAccountancyApproveFormViewModel.ChattelDocumentDetailsWithAccountancyGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.chattelDocumentInputWithAccountancyApproveFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.chattelDocumentInputWithAccountancyApproveFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.chattelDocumentInputWithAccountancyApproveFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.chattelDocumentInputWithAccountancyApproveFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
            let SupplierID = detailItem['Supplier'];
            if (SupplierID != null && (typeof SupplierID === 'string')) {
                let Supplier = that.chattelDocumentInputWithAccountancyApproveFormViewModel.Suppliers.find(o => o.ObjectID.toString() === SupplierID.toString());
                if (Supplier) {
                    detailItem.Supplier = Supplier;
                }
            }
        }
        that.chattelDocumentInputWithAccountancyApproveFormViewModel._ChattelDocumentInputWithAccountancy.StockActionSignDetails = that.chattelDocumentInputWithAccountancyApproveFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.chattelDocumentInputWithAccountancyApproveFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === "string")) {
                let signUser = that.chattelDocumentInputWithAccountancyApproveFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }

    }

    async ngOnInit() {
        let that = this;
        await this.load(ChattelDocumentInputWithAccountancyApproveFormViewModel);
        if (this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = "Taşınır Mal Giriş ( Onay )";

    }


    public onAccountancyChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Accountancy != event) {
                this._ChattelDocumentInputWithAccountancy.Accountancy = event;
            }
        }
        this.Accountancy_SelectedObjectChanged();
    }

    public onBudgetTypeDefinitionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition != event) {
                this._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Description != event) {
                this._ChattelDocumentInputWithAccountancy.Description = event;
            }
        }
    }

    public oninputWithAccountancyTypeChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType != event) {
                this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType = event;
            }
        }
    }

    public onMKYS_EAlimYontemiChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_EAlimYontemi != event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_EAlimYontemi = event;
            }
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup != event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup = event;
            }
        }
    }

    public onMKYS_ETedarikTuruChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru != event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlan != event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEden != event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.StockActionID != event) {
                this._ChattelDocumentInputWithAccountancy.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Store != event) {
                this._ChattelDocumentInputWithAccountancy.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.TransactionDate != event) {
                this._ChattelDocumentInputWithAccountancy.TransactionDate = event;
            }
        }
    }

    public onWaybillChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Waybill != event) {
                this._ChattelDocumentInputWithAccountancy.Waybill = event;
            }
        }
    }

    public onWaybillDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.WaybillDate != event) {
                this._ChattelDocumentInputWithAccountancy.WaybillDate = event;
            }
        }
    }

    ChattelDocumentDetailsWithAccountancy_CellValueChangedEmitted(data: any) {
        if (data && this.ChattelDocumentDetailsWithAccountancy_CellValueChanged && data.Row && data.Column) {
            this.ChattelDocumentDetailsWithAccountancy_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
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
        this.txtTotalPrice = new TTVisual.TTTextBox();
        this.txtTotalPrice.BackColor = "#F0F0F0";
        this.txtTotalPrice.ReadOnly = true;
        this.txtTotalPrice.Name = "txtTotalPrice";
        this.txtTotalPrice.TabIndex = 124;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.labelWaybillDate = new TTVisual.TTLabel();
        this.labelWaybillDate.Text = i18n("M16573", "İrsaliye Tarihi");
        this.labelWaybillDate.Name = "labelWaybillDate";
        this.labelWaybillDate.TabIndex = 135;
        this.WaybillDate = new TTVisual.TTDateTimePicker();
        this.WaybillDate.Format = DateTimePickerFormat.Long;
        this.WaybillDate.Name = "WaybillDate";
        this.WaybillDate.TabIndex = 134;
        this.labelWaybill = new TTVisual.TTLabel();
        this.labelWaybill.Text = i18n("M16572", "İrsaliye Numarası");
        this.labelWaybill.Name = "labelWaybill";
        this.labelWaybill.TabIndex = 133;
        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = i18n("M12146", "Bütçe Türü");
        this.labelBudgetTypeDefinition.Name = "labelBudgetTypeDefinition";
        this.labelBudgetTypeDefinition.TabIndex = 129;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.Required = true;
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.BackColor = '#FFE3C6';
        this.BudgetTypeDefinition.Name = "BudgetTypeDefinition";
        this.BudgetTypeDefinition.TabIndex = 128;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = "10%";
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = "20%";

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14807", "Giriş Yapılan Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 127;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 118;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreDefinitionList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 126;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M14220", "Fatura Tutarı");
        this.ttlabel2.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 125;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.labelAccountancy = new TTVisual.TTLabel();
        this.labelAccountancy.Text = "Geldiği Yer";
        this.labelAccountancy.Name = "labelAccountancy";
        this.labelAccountancy.TabIndex = 122;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.Accountancy = new TTVisual.TTObjectListBox();
        this.Accountancy.ReadOnly = true;
        this.Accountancy.ListDefName = "AccountancyList";
        this.Accountancy.Name = "Accountancy";
        this.Accountancy.TabIndex = 121;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.ChattelDocumentTabcontrol = new TTVisual.TTTabControl();
        this.ChattelDocumentTabcontrol.Name = "ChattelDocumentTabcontrol";
        this.ChattelDocumentTabcontrol.TabIndex = 120;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.ChattelDocumentDetailTabpage = new TTVisual.TTTabPage();
        this.ChattelDocumentDetailTabpage.DisplayIndex = 0;
        this.ChattelDocumentDetailTabpage.TabIndex = 0;
        this.ChattelDocumentDetailTabpage.Text = "Taşınır Malın";
        this.ChattelDocumentDetailTabpage.Name = "ChattelDocumentDetailTabpage";

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.ChattelDocumentDetailsWithAccountancy = new TTVisual.TTGrid();
        this.ChattelDocumentDetailsWithAccountancy.Required = true;
        this.ChattelDocumentDetailsWithAccountancy.Name = "ChattelDocumentDetailsWithAccountancy";
        this.ChattelDocumentDetailsWithAccountancy.TabIndex = 0;
        this.ChattelDocumentDetailsWithAccountancy.Height = 350;
        this.ChattelDocumentDetailsWithAccountancy.AllowUserToDeleteRows = true;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 113;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ReadOnly = true;
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.MaterialStockActionDetailIn = new TTVisual.TTListBoxColumn();
        this.MaterialStockActionDetailIn.AllowMultiSelect = true;
        this.MaterialStockActionDetailIn.ListDefName = "MaterialListDefinition";
        this.MaterialStockActionDetailIn.DataMember = "Material";
        this.MaterialStockActionDetailIn.AutoCompleteDialogHeight = '60%';
        this.MaterialStockActionDetailIn.AutoCompleteDialogWidth = '90%';
        this.MaterialStockActionDetailIn.DisplayIndex = 1;
        this.MaterialStockActionDetailIn.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialStockActionDetailIn.Name = "MaterialStockActionDetailIn";
        this.MaterialStockActionDetailIn.Width = 300;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Material.Barcode";
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "Material.DistributionTypeName";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 120;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.SentAmountChattelDocumentInputDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.SentAmountChattelDocumentInputDetailWithAccountancy.DataMember = "SentAmount";
        //this.SentAmountChattelDocumentInputDetailWithAccountancy.Format = "#,###.####";
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.SentAmountChattelDocumentInputDetailWithAccountancy.DisplayIndex = 4;
        this.SentAmountChattelDocumentInputDetailWithAccountancy.HeaderText = i18n("M14894", "Gönderilen Mik.");
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Name = "SentAmountChattelDocumentInputDetailWithAccountancy";
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Width = 120;
        //this.SentAmountChattelDocumentInputDetailWithAccountancy.IsNumeric = true;
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Visible = false;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;

        this.AmountStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.AmountStockActionDetailIn.DataMember = "Amount";
        //this.AmountStockActionDetailIn.Format = "#,###.####";
        this.AmountStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountStockActionDetailIn.DisplayIndex = 5;
        this.AmountStockActionDetailIn.HeaderText = i18n("M19030", "Miktar");
        this.AmountStockActionDetailIn.Name = "AmountStockActionDetailIn";
        this.AmountStockActionDetailIn.Width = 120;
        //this.AmountStockActionDetailIn.IsNumeric = true;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.NotDiscountedUnitPrice = new TTVisual.TTTextBoxColumn();
        this.NotDiscountedUnitPrice.DataMember = "NotDiscountedUnitPrice";
        //this.NotDiscountedUnitPrice.Format = "#,###.#########";
        this.NotDiscountedUnitPrice.DisplayIndex = 6;
        this.NotDiscountedUnitPrice.HeaderText = i18n("M16509", "İndirimsiz Birim Fiyatı");
        this.NotDiscountedUnitPrice.Name = "NotDiscountedUnitPrice";
        this.NotDiscountedUnitPrice.Width = 120;
        //this.NotDiscountedUnitPrice.IsNumeric = true;


        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 111;

        this.UnitPriceStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.UnitPriceStockActionDetailIn.DataMember = "UnitPrice";
        //this.UnitPriceStockActionDetailIn.Format = "#,###.#########";
        this.UnitPriceStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPriceStockActionDetailIn.DisplayIndex = 7;
        this.UnitPriceStockActionDetailIn.HeaderText = i18n("M11868", "Birim Maliyet Bedeli");
        this.UnitPriceStockActionDetailIn.Name = "UnitPriceStockActionDetailIn";
        this.UnitPriceStockActionDetailIn.ReadOnly = true;
        this.UnitPriceStockActionDetailIn.Width = 120;
        //this.UnitPriceStockActionDetailIn.IsNumeric = true;


        this.MKYS_IndirimOranı = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimOranı.DataMember = "DiscountRate";
        this.MKYS_IndirimOranı.DisplayIndex = 8;
        this.MKYS_IndirimOranı.HeaderText = i18n("M16491", "İndirim Oranı");
        this.MKYS_IndirimOranı.Name = "MKYS_IndirimOranı";
        this.MKYS_IndirimOranı.Width = 100;
        //this.MKYS_IndirimOranı.IsNumeric = true;

        this.MKYS_IndirimTutari = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimTutari.DataMember = "DiscountAmount";
        //this.MKYS_IndirimTutari.Format = "#,###.#########";
        this.MKYS_IndirimTutari.DisplayIndex = 9;
        this.MKYS_IndirimTutari.HeaderText = i18n("M16501", "İndirim Tutarı");
        this.MKYS_IndirimTutari.Name = "MKYS_IndirimTutari";
        this.MKYS_IndirimTutari.ReadOnly = true;
        this.MKYS_IndirimTutari.Visible = false;
        this.MKYS_IndirimTutari.Width = 100;
        //this.MKYS_IndirimTutari.IsNumeric = true;

        this.TotalPriceNotDiscount = new TTVisual.TTTextBoxColumn();
        this.TotalPriceNotDiscount.DataMember = "TotalPriceNotDiscount";
        //this.TotalPriceNotDiscount.Format = "#,###.#########";
        this.TotalPriceNotDiscount.DisplayIndex = 10;
        this.TotalPriceNotDiscount.HeaderText = i18n("M16510", "İndirimsiz Toplam Fiyat");
        this.TotalPriceNotDiscount.Name = "TotalPriceNotDiscount";
        this.TotalPriceNotDiscount.ReadOnly = true;
        this.TotalPriceNotDiscount.Width = 120;
        //this.TotalPriceNotDiscount.IsNumeric = true;

        this.TotalDiscountAmount = new TTVisual.TTTextBoxColumn();
        this.TotalDiscountAmount.DataMember = "TotalDiscountAmount";
        //this.TotalDiscountAmount.Format = "#,###.#########";
        this.TotalDiscountAmount.DisplayIndex = 11;
        this.TotalDiscountAmount.HeaderText = i18n("M23503", "Toplam İndirim Tutarı");
        this.TotalDiscountAmount.Name = "TotalDiscountAmount";
        this.TotalDiscountAmount.ReadOnly = true;
        this.TotalDiscountAmount.Width = 120;
        //this.TotalDiscountAmount.IsNumeric = true;

        this.TotalPrice = new TTVisual.TTTextBoxColumn();
        this.TotalPrice.DataMember = "Price";
        //this.TotalPrice.Format = "#,###.#########";
        this.TotalPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.TotalPrice.DisplayIndex = 12;
        this.TotalPrice.HeaderText = i18n("M23613", "Tutarı");
        this.TotalPrice.Name = "TotalPrice";
        this.TotalPrice.ReadOnly = true;
        this.TotalPrice.Width = 120;
        //this.TotalPrice.IsNumeric = true;

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
        this.ExpirationDateStockActionDetailIn.HeaderText = i18n("M22057", "Son Kullanma Tarihi");
        this.ExpirationDateStockActionDetailIn.Name = "ExpirationDateStockActionDetailIn";
        this.ExpirationDateStockActionDetailIn.Width = 180;

        this.StockLevelTypeStockActionDetailIn = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeStockActionDetailIn.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeStockActionDetailIn.DataMember = "StockLevelType";
        this.StockLevelTypeStockActionDetailIn.Required = true;
        this.StockLevelTypeStockActionDetailIn.DisplayIndex = 15;
        this.StockLevelTypeStockActionDetailIn.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeStockActionDetailIn.Name = "StockLevelTypeStockActionDetailIn";
        this.StockLevelTypeStockActionDetailIn.Width = 140;

        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.DataMember = "ConflictSubject";
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.DisplayIndex = 16;
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.HeaderText = i18n("M23821", "Uyuşmazlık Konusu");
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.Name = "ConflictSubjectChattelDocumentInputDetailWithAccountancy";
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.Width = 120;
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.Visible = false;

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
        this.MKYS_EdinimYili.HeaderText = i18n("M13475", "Edinim Yılı");
        this.MKYS_EdinimYili.Name = "MKYS_EdinimYili";
        this.MKYS_EdinimYili.Width = 120;

        this.MKYS_UretimTarihi = new TTVisual.TTDateTimePickerColumn();
        this.MKYS_UretimTarihi.DataMember = "ProductionDate";
        this.MKYS_UretimTarihi.DisplayIndex = 19;
        this.MKYS_UretimTarihi.HeaderText = i18n("M23966", "Üretim Tarihi");
        this.MKYS_UretimTarihi.Name = "MKYS_UretimTarihi";
        this.MKYS_UretimTarihi.Width = 120;

        this.ConflictAmountChattelDocumentInputDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.DataMember = "ConflictAmount";
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Format = "#,###.####";
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.DisplayIndex = 20;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.HeaderText = i18n("M23822", "Uyuşmazlık Miktarı");
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Name = "ConflictAmountChattelDocumentInputDetailWithAccountancy";
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.ReadOnly = true;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Visible = false;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Width = 120;

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
        this.ttlabel3.Text = i18n("M16501", "İndirim Tutarı");
        this.ttlabel3.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 125;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M23526", "Toplam Tutar");
        this.ttlabel4.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 125;

        this.labelMKYS_ETedarikTuru = new TTVisual.TTLabel();
        this.labelMKYS_ETedarikTuru.Text = i18n("M22969", "Tedarik Türü");
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
        this.labelMKYS_EMalzemeGrup.Text = i18n("M18581", "Malzeme Grup");
        this.labelMKYS_EMalzemeGrup.Name = "labelMKYS_EMalzemeGrup";
        this.labelMKYS_EMalzemeGrup.TabIndex = 16;

        this.MKYS_EAlimYontemi = new TTVisual.TTEnumComboBox();
        this.MKYS_EAlimYontemi.DataTypeName = "MKYS_EAlimYontemiEnum";
        this.MKYS_EAlimYontemi.Required = true;
        this.MKYS_EAlimYontemi.BackColor = "#FFE3C6";
        this.MKYS_EAlimYontemi.Name = "MKYS_EAlimYontemi";
        this.MKYS_EAlimYontemi.TabIndex = 19;

        this.labelMKYS_EAlimYontemi = new TTVisual.TTLabel();
        this.labelMKYS_EAlimYontemi.Text = i18n("M10699", "Alım Yöntemi");
        this.labelMKYS_EAlimYontemi.Name = "labelMKYS_EAlimYontemi";
        this.labelMKYS_EAlimYontemi.TabIndex = 18;

        this.inputWithAccountancyType = new TTVisual.TTEnumComboBox();
        this.inputWithAccountancyType.DataTypeName = "TasinirMalGirisTurEnum";
        this.inputWithAccountancyType.Name = "inputWithAccountancyType";
        this.inputWithAccountancyType.TabIndex = 130;



        this.GetWaybill = new TTVisual.TTButton();
        this.GetWaybill.Text = i18n("M16570", "İrsaliye Getir");
        this.GetWaybill.Name = "GetWaybill";
        this.GetWaybill.TabIndex = 147;

        this.ValueAddedTax = new TTVisual.TTTextBoxColumn();
        this.ValueAddedTax.DataMember = "VatRate";
        this.ValueAddedTax.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ValueAddedTax.DisplayIndex = 6;
        this.ValueAddedTax.HeaderText = i18n("M17457", "KDV Oranı");
        this.ValueAddedTax.Name = "ValueAddedTax";
        this.ValueAddedTax.ReadOnly = false;
        this.ValueAddedTax.Width = 100;

        this.ChattelDocumentDetailsWithAccountancyColumns = [this.Detail, this.MaterialStockActionDetailIn, this.Barcode,
        this.DistributionType, this.SentAmountChattelDocumentInputDetailWithAccountancy, this.AmountStockActionDetailIn,
        this.NotDiscountedUnitPrice, this.ValueAddedTax, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimOranı, this.MKYS_IndirimTutari,
        this.TotalPriceNotDiscount, this.TotalDiscountAmount, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn,
        this.StockLevelTypeStockActionDetailIn, this.ConflictSubjectChattelDocumentInputDetailWithAccountancy,
        this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi,
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.ChattelDocumentTabcontrol.Controls = [this.ChattelDocumentDetailTabpage];
        this.ChattelDocumentDetailTabpage.Controls = [this.ChattelDocumentDetailsWithAccountancy];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.inputWithAccountancyType, this.Waybill, this.txtTotalPrice, this.TTTeslimEdenButon, this.labelBudgetTypeDefinition, this.TTTeslimAlanButon, this.BudgetTypeDefinition, this.labelWaybillDate, this.labelMKYS_TeslimEden, this.labelStore, this.WaybillDate, this.MKYS_TeslimEden, this.Store, this.labelWaybill, this.MKYS_TeslimAlan, this.ttlabel2, this.Description, this.labelAccountancy, this.StockActionID, this.Accountancy, this.labelMKYS_TeslimAlan, this.ChattelDocumentTabcontrol, this.labelTransactionDate, this.ChattelDocumentDetailTabpage, this.TransactionDate, this.ChattelDocumentDetailsWithAccountancy, this.labelStockActionID, this.Detail, this.DescriptionAndSignTabControl, this.MaterialStockActionDetailIn, this.SignTabpage, this.Barcode, this.StockActionSignDetails, this.DistributionType, this.SignUserType, this.SentAmountChattelDocumentInputDetailWithAccountancy, this.SignUser, this.AmountStockActionDetailIn, this.IsDeputy, this.NotDiscountedUnitPrice, this.ttlabel1, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimOranı, this.MKYS_IndirimTutari, this.TotalPriceNotDiscount, this.TotalDiscountAmount, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn, this.StockLevelTypeStockActionDetailIn, this.ConflictSubjectChattelDocumentInputDetailWithAccountancy, this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi, this.ConflictAmountChattelDocumentInputDetailWithAccountancy, this.txtSalesTotal, this.txtTotalNotDiscount, this.ttlabel3, this.ttlabel4, this.labelMKYS_ETedarikTuru, this.MKYS_ETedarikTuru, this.MKYS_EMalzemeGrup, this.labelMKYS_EMalzemeGrup, this.MKYS_EAlimYontemi, this.labelMKYS_EAlimYontemi, this.GetWaybill];

    }


}
