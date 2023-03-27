//$BECF03B5
import { Component, OnInit, NgZone } from '@angular/core';
import { ChattelDocumentWithPurchaseApproveFormViewModel } from './ChattelDocumentWithPurchaseApproveFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseChattelDocumentWithPurchaseForm, UTSBatchGridDataType, RespectiveIncomingUTSNotification } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentWithPurchaseForm';
import { ChattelDocumentWithPurchase, StockActionDetailStatusEnum, StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { BudgetTypeDefinition, } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentDetailWithPurchase } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentDistribution } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { StockActionService } from 'ObjectClassService/StockActionService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';


import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { MaterialService } from 'app/NebulaClient/Services/ObjectService/MaterialService';
import { StockLevelTypeService } from 'app/NebulaClient/Services/ObjectService/StockLevelTypeService';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';

@Component({
    selector: 'ChattelDocumentWithPurchaseApproveForm',
    templateUrl: './ChattelDocumentWithPurchaseApproveForm.html',
    providers: [MessageService]
})
export class ChattelDocumentWithPurchaseApproveForm extends BaseChattelDocumentWithPurchaseForm implements OnInit {
    chkFreeEntry: TTVisual.ITTCheckBox;
    public ChattelDocumentDetailsWithPurchaseColumns = [];
    public DemandAmountsGridColumns = [];
    public StockActionSignDetailsColumns = [];

    public chattelDocumentWithPurchaseApproveFormViewModel: ChattelDocumentWithPurchaseApproveFormViewModel = new ChattelDocumentWithPurchaseApproveFormViewModel();
    public get _ChattelDocumentWithPurchase(): ChattelDocumentWithPurchase {
        return this._TTObject as ChattelDocumentWithPurchase;
    }
    private ChattelDocumentWithPurchaseApproveForm_DocumentUrl: string = '/api/ChattelDocumentWithPurchaseService/ChattelDocumentWithPurchaseApproveForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone, protected objectContextService: ObjectContextService) {
        super(httpService, messageService, ngZone, objectContextService);
        this._DocumentServiceUrl = this.ChattelDocumentWithPurchaseApproveForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef != null) {
            super.AfterContextSavedScript(transDef);
            let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ChattelDocumentWithPurchase.ObjectID.toString());
            for (let document of documentRecordLogs) {
                if (document.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                    const objectIdParam = new GuidParam(document['ObjectID']);
                    const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                    let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                    this.reportService.showReport('ChattelDocumentInDetailReport', reportParameters);
                    this.reportService.showReport('ExaminationChattelDocumentInDetailReport', reportParameters);
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

    public async controlFreeEnty() {
        if (<boolean>this.chkFreeEntry.Value) {
            this.ConclusionNumber.ReadOnly = false;
            this.ConclusionDateTime.ReadOnly = false;
            this.Supplier.ReadOnly = false;
            this.MaterialStockActionDetailIn.ReadOnly = false;
            this.AmountStockActionDetailIn.ReadOnly = false;
            this.UnitPriceStockActionDetailIn.ReadOnly = false;
            this.ValueAddedTax.ReadOnly = false;
            this.Supplier.BackColor = "#FFE3C6";
            this.Store.BackColor = "#F0F0F0";
            this.ChattelDocumentDetailsWithPurchase.AllowUserToAddRows = true;

        }
        else {
            this.ConclusionNumber.ReadOnly = true;
            this.ConclusionDateTime.ReadOnly = true;
            this.Supplier.ReadOnly = true;
            this.MaterialStockActionDetailIn.ReadOnly = true;
            this.AmountStockActionDetailIn.ReadOnly = true;
            this.UnitPriceStockActionDetailIn.ReadOnly = true;
            this.ValueAddedTax.ReadOnly = true;
            this.ConclusionDateTime.BackColor = "#F0F0F0";
            this.ConclusionNumber.BackColor = "#F0F0F0";
            this.Supplier.BackColor = "#F0F0F0";
            this.Store.BackColor = "#F0F0F0";
            this.ChattelDocumentDetailsWithPurchase.AllowUserToAddRows = false;
        }
    }


    protected async PreScript() {
        super.PreScript();
        await this.controlFreeEnty();
        let priceCalc: Array<number> = new Array<number>();
        let totalWithoutKDV: number = 0, totalWithKDV = 0, salesTotal = 0, totalPrice = 0;
        priceCalc.push(totalWithoutKDV);
        priceCalc.push(totalWithKDV);
        priceCalc.push(salesTotal);
        priceCalc.push(totalPrice);
        priceCalc = await this.CalcFinalPriceWithKDV(priceCalc);
        this.txtNotKDV.Text = priceCalc[0].toFixed(2);
        this.txtWithKDV.Text = priceCalc[1].toFixed(2);
        this.txtDiscount.Text = priceCalc[2].toFixed(2);
        //this.txtTotalPrice.Text = priceCalc[3].toFixed(2);

        if (this._ChattelDocumentWithPurchase.FreeEntry !== true) {
            this.ExaminationReportDate.ReadOnly = true;
            this.ExaminationReportNo.ReadOnly = true;
            this.MKYS_EAlimYontemi.ReadOnly = true;
            this.RegistrationAuctionNo.ReadOnly = true;
            this.AuctionDate.ReadOnly = true;
            this.BudgetTypeDefinition.ReadOnly = true;
            this.Waybill.ReadOnly = true;
            this.GetWaybill.ReadOnly = true;
            this.WaybillDate.ReadOnly = true;
            this.ChattelDocumentDetailsWithPurchase.ReadOnly = true;
            this.ChattelDocumentDetailsWithPurchase.AllowUserToAddRows = false;
            this.ChattelDocumentDetailsWithPurchase.AllowUserToDeleteRows = true;
            this.ExaminationReportDate.BackColor = '#F0F0F0';
            this.ExaminationReportNo.BackColor = '#F0F0F0';
            this.MKYS_EAlimYontemi.BackColor = '#F0F0F0';
            this.RegistrationAuctionNo.BackColor = '#F0F0F0';
            this.AuctionDate.BackColor = '#F0F0F0';
            this.BudgetTypeDefinition.BackColor = '#F0F0F0';
            this.Waybill.BackColor = '#F0F0F0';
            this.GetWaybill.BackColor = '#F0F0F0';
            this.WaybillDate.BackColor = '#F0F0F0';
            this.ChattelDocumentDetailsWithPurchase.BackColor = '#F0F0F0';
        }

        if (this._ChattelDocumentWithPurchase.InPatientPhysicianApplication != null) {
            this.Description.Enabled = false;
        }
    }


    onchkFreeEntryChanged(data: any) { }

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChattelDocumentWithPurchase();
        this.chattelDocumentWithPurchaseApproveFormViewModel = new ChattelDocumentWithPurchaseApproveFormViewModel();
        this._ViewModel = this.chattelDocumentWithPurchaseApproveFormViewModel;
        this.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase = this._TTObject as ChattelDocumentWithPurchase;
        this.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase.Store = new Store();
        this.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase.Supplier = new Supplier();
        this.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase = new Array<ChattelDocumentDetailWithPurchase>();
        this.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDistributions = new Array<ChattelDocumentDistribution>();
        this.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.chattelDocumentWithPurchaseApproveFormViewModel = this._ViewModel as ChattelDocumentWithPurchaseApproveFormViewModel;
        that._TTObject = this.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase;
        if (this.chattelDocumentWithPurchaseApproveFormViewModel == null)
            this.chattelDocumentWithPurchaseApproveFormViewModel = new ChattelDocumentWithPurchaseApproveFormViewModel();
        if (this.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase == null)
            this.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase = new ChattelDocumentWithPurchase();
        let budgetTypeDefinitionObjectID = that.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase['BudgetTypeDefinition'];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === 'string')) {
            let budgetTypeDefinition = that.chattelDocumentWithPurchaseApproveFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.chattelDocumentWithPurchaseApproveFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase.Store = store;
            }
        }
        let supplierObjectID = that.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase['Supplier'];
        if (supplierObjectID != null && (typeof supplierObjectID === 'string')) {
            let supplier = that.chattelDocumentWithPurchaseApproveFormViewModel.Suppliers.find(o => o.ObjectID.toString() === supplierObjectID.toString());
            if (supplier) {
                that.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase.Supplier = supplier;
            }
        }
        that.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase =
            that.chattelDocumentWithPurchaseApproveFormViewModel.ChattelDocumentDetailsWithPurchaseGridList;
        for (let detailItem of that.chattelDocumentWithPurchaseApproveFormViewModel.ChattelDocumentDetailsWithPurchaseGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.chattelDocumentWithPurchaseApproveFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.chattelDocumentWithPurchaseApproveFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.chattelDocumentWithPurchaseApproveFormViewModel.DistributionTypeDefinitions
                                    .find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.chattelDocumentWithPurchaseApproveFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDistributions = that.chattelDocumentWithPurchaseApproveFormViewModel.DemandAmountsGridGridList;
        for (let detailItem of that.chattelDocumentWithPurchaseApproveFormViewModel.DemandAmountsGridGridList) {
            let demandDetailObjectID = detailItem['DemandDetail'];
            if (demandDetailObjectID != null && (typeof demandDetailObjectID === 'string')) {
                let demandDetail = that.chattelDocumentWithPurchaseApproveFormViewModel.DemandDetails.find(o => o.ObjectID.toString() === demandDetailObjectID.toString());
                if (demandDetail) {
                    detailItem.DemandDetail = demandDetail;
                }
                if (demandDetail != null) {
                    let demandObjectID = demandDetail['Demand'];
                    if (demandObjectID != null && (typeof demandObjectID === 'string')) {
                        let demand = that.chattelDocumentWithPurchaseApproveFormViewModel.Demands.find(o => o.ObjectID.toString() === demandObjectID.toString());
                        if (demand) {
                            demandDetail.Demand = demand;
                        }
                        if (demand != null) {
                            let masterResourceObjectID = demand['MasterResource'];
                            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                                let masterResource = that.chattelDocumentWithPurchaseApproveFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                                if (masterResource) {
                                    demand.MasterResource = masterResource;
                                }
                            }
                        }
                    }
                }
            }
        }
        that.chattelDocumentWithPurchaseApproveFormViewModel._ChattelDocumentWithPurchase.StockActionSignDetails = that.chattelDocumentWithPurchaseApproveFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.chattelDocumentWithPurchaseApproveFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem['SignUser'];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.chattelDocumentWithPurchaseApproveFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }
    // UTS için eklendi
    ShowReceiveNotifications: boolean = false;
    incomingUTSReceiveNotificationList: Array<UTSBatchGridDataType> = new Array<UTSBatchGridDataType>();
    public getIncomingReceiveNotifications() {
        let param: any;
        let apiUrl: string = '/api/ChattelDocumentWithPurchaseService/GetUTSIncomingReceiveNotifications';
        this.httpService.post<any>(apiUrl, param).then(
            x => {
                this.incomingUTSReceiveNotificationList.push(x);
            }
        );
    }

    async onReceiveNotifAddButtonClick(data) {
        if (data != undefined) {
            if (this.stockLeveltypeArray.length == 0)
                this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
            let newRow: ChattelDocumentDetailWithPurchase = new ChattelDocumentDetailWithPurchase();
            newRow.Material = data.ReceivedMaterial;
            newRow.StockLevelType = this.selectedStockLevelType;
            newRow.Status = StockActionDetailStatusEnum.New;
            if (this._ChattelDocumentWithPurchase.TransactionDate != null)
                newRow.VatRate = await MaterialService.GetVatrateFromMaterialTS(data.ReceivedMaterial, this._ChattelDocumentWithPurchase.TransactionDate);
            //newRow.VatRate = this.selectedMaterial.MaterialVatRates.find(x => x.StartDate <= this._ChattelDocumentWithPurchase.TransactionDate && x.EndDate >= this._ChattelDocumentWithPurchase.TransactionDate).VatRate;
            this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.push(newRow);
            let respectiveIncomingUTSNotification: RespectiveIncomingUTSNotification = new RespectiveIncomingUTSNotification();
            respectiveIncomingUTSNotification.IncomingReceiveNotificationID = data.IncomingDeliveryNotifID;
            respectiveIncomingUTSNotification.chattelDocumentDetailsWithPurchase = newRow;
            this.chattelDocumentWithPurchaseApproveFormViewModel.RespectiveIncomingUTSNotificationList.push(respectiveIncomingUTSNotification);

        }
        this.ShowReceiveNotifications = false;

    }

    onShowReceiveNotifButtonClick() {
        this.getIncomingReceiveNotifications();
        this.ShowReceiveNotifications = true;
    }

    public BildirimGridColumns = [
        {
            'caption': "Verme Bildirim ID",
            dataField: 'IncomingDeliveryNotifID',
            allowSorting: true,
        },
        {
            'caption': "Malzeme Adı",
            dataField: 'ReceivedMaterial.Name',
            allowSorting: true
        },
        {
            'caption': "Hasta TC Kimlik Numarası",
            dataField: 'PatientUniqueID',
            allowSorting: true
        },
        {
            'caption': "Hasta Adı",
            dataField: 'PatientName',
            allowSorting: true
        },
        {
            'caption': "Ürün Numarası",
            dataField: 'ProductNo',
            allowSorting: true
        },

        {
            'caption': "Gönderen Kurum Numarası",
            dataField: 'SendingOrganizationNo',
            allowSorting: true
        },
        {
            'caption': "Eşsiz Kimlik",
            dataField: 'UniqueDeviceIdentifier',
            allowSorting: true
        },
        {
            'caption': "Lot/Batch Numarası",
            dataField: 'LotNumber',
            allowSorting: true
        },
        {
            'caption': "Seri/Sıra Numarası",
            dataField: 'SerialNumber',
            allowSorting: true
        }

    ];


    async ngOnInit() {
        let that = this;
        await this.load(ChattelDocumentWithPurchaseApproveFormViewModel);
        if (this._ChattelDocumentWithPurchase.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ChattelDocumentWithPurchase.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = '#F0F0F0';
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M21378", "Satınalma Yoluyla Giriş ( Onay )");

    }


    public onAdditionalDocumentCountChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.AdditionalDocumentCount !== event) {
                this._ChattelDocumentWithPurchase.AdditionalDocumentCount = event;
            }
        }
    }

    public onAuctionDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.AuctionDate !== event) {
                this._ChattelDocumentWithPurchase.AuctionDate = event;
            }
        }
    }

    public onBudgetTypeDefinitionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.BudgetTypeDefinition !== event) {
                this._ChattelDocumentWithPurchase.BudgetTypeDefinition = event;
            }
        }
    }

    public onConclusionDateTimeChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ConclusionDateTime !== event) {
                this._ChattelDocumentWithPurchase.ConclusionDateTime = event;
            }
        }
    }

    public onConclusionNumberChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ConclusionNumber !== event) {
                this._ChattelDocumentWithPurchase.ConclusionNumber = event;
            }
        }
    }

    public onContractDateTimeChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ContractDateTime !== event) {
                this._ChattelDocumentWithPurchase.ContractDateTime = event;
            }
        }
    }

    public onContractNumberChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ContractNumber !== event) {
                this._ChattelDocumentWithPurchase.ContractNumber = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Description !== event) {
                this._ChattelDocumentWithPurchase.Description = event;
            }
        }
    }

    public onExaminationReportDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ExaminationReportDate !== event) {
                this._ChattelDocumentWithPurchase.ExaminationReportDate = event;
            }
        }
    }

    public onExaminationReportNoChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ExaminationReportNo !== event) {
                this._ChattelDocumentWithPurchase.ExaminationReportNo = event;
            }
        }
    }

    public onMKYS_EAlimYontemiChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_EAlimYontemi !== event) {
                this._ChattelDocumentWithPurchase.MKYS_EAlimYontemi = event;
            }
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup !== event) {
                this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup = event;
            }
        }
    }

    public onMKYS_ETedarikTuruChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_ETedarikTuru !== event) {
                this._ChattelDocumentWithPurchase.MKYS_ETedarikTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_TeslimAlan !== event) {
                this._ChattelDocumentWithPurchase.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = '#F0F0F0';
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_TeslimEden !== event) {
                this._ChattelDocumentWithPurchase.MKYS_TeslimEden = event;
            }
        }
    }

    public onRegistrationAuctionNoChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.RegistrationAuctionNo !== event) {
                this._ChattelDocumentWithPurchase.RegistrationAuctionNo = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.StockActionID !== event) {
                this._ChattelDocumentWithPurchase.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Store !== event) {
                this._ChattelDocumentWithPurchase.Store = event;
            }
        }
    }

    public onSupplierChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Supplier !== event) {
                this._ChattelDocumentWithPurchase.Supplier = event;
            }
        }

    }

    /*public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.TransactionDate !== event) {
                this._ChattelDocumentWithPurchase.TransactionDate = event;
            }
        }
    }*/
    public onTransactionDateChanged(event): void {
        if (event != null) {
            let dateNow: Date = new Date();
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.TransactionDate != event) {
                if (event.getTime() <= dateNow.getTime()) {
                    this._ChattelDocumentWithPurchase.TransactionDate = event;
                } else {
                    ServiceLocator.MessageService.showError(i18n("M16402", "İleri Tarihe giriş yapılamaz."));
                    this._ChattelDocumentWithPurchase.TransactionDate = dateNow;
                }
            }
        }
    }

    public onWaybillChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Waybill !== event) {
                this._ChattelDocumentWithPurchase.Waybill = event;
            }
        }
    }

    public onWaybillDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.WaybillDate !== event) {
                this._ChattelDocumentWithPurchase.WaybillDate = event;
            }
        }
    }


    ChattelDocumentDetailsWithPurchase_CellValueChangedEmitted(data: any) {
        if (data && this.ChattelDocumentDetailsWithPurchase_CellValueChanged && data.Row && data.Column) {
            this.ChattelDocumentDetailsWithPurchase_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    onSelectionChange(data: any) {
    }
    public async GrantMaterialDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.ChattelDocumentDetailsWithPurchase_CellValueChanged(data, rowIndex, columnIndex);
    }

    onRowInserting(data: ChattelDocumentDetailWithPurchase) {
    }

    onCellContentClicked(data: any) {
    }
    async initNewRow(data: any) {
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.TransactionDate, 'Value', this.__ttObject, 'TransactionDate');
        redirectProperty(this.MKYS_TeslimEden, 'Text', this.__ttObject, 'MKYS_TeslimEden');
        redirectProperty(this.MKYS_TeslimAlan, 'Text', this.__ttObject, 'MKYS_TeslimAlan');
        redirectProperty(this.ConclusionNumber, 'Text', this.__ttObject, 'ConclusionNumber');
        redirectProperty(this.ConclusionDateTime, 'Value', this.__ttObject, 'ConclusionDateTime');
        redirectProperty(this.RegistrationAuctionNo, 'Text', this.__ttObject, 'RegistrationAuctionNo');
        redirectProperty(this.AuctionDate, 'Value', this.__ttObject, 'AuctionDate');
        redirectProperty(this.ExaminationReportDate, 'Value', this.__ttObject, 'ExaminationReportDate');
        redirectProperty(this.ExaminationReportNo, 'Text', this.__ttObject, 'ExaminationReportNo');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
        redirectProperty(this.MKYS_EMalzemeGrup, 'Value', this.__ttObject, 'MKYS_EMalzemeGrup');
        redirectProperty(this.MKYS_ETedarikTuru, 'Value', this.__ttObject, 'MKYS_ETedarikTuru');
        redirectProperty(this.MKYS_EAlimYontemi, 'Value', this.__ttObject, 'MKYS_EAlimYontemi');
        redirectProperty(this.GetWaybill, 'Text', this.__ttObject, 'Waybill');
        redirectProperty(this.WaybillDate, 'Value', this.__ttObject, 'WaybillDate');
        redirectProperty(this.chkFreeEntry, 'Value', this.__ttObject, 'FreeEntry');
    }

    public initFormControls(): void {
        this.PictureTabpage = new TTVisual.TTTabPage();
        this.PictureTabpage.DisplayIndex = 2;
        this.PictureTabpage.TabIndex = 2;
        this.PictureTabpage.Text = 'Fatura';
        this.PictureTabpage.Name = 'PictureTabpage';

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = 'TE';
        this.TTTeslimEdenButon.Name = 'TTTeslimEdenButon';
        this.TTTeslimEdenButon.TabIndex = 121;

        this.invoicePictureControl = new TTVisual.TTPictureBoxControl();
        this.invoicePictureControl.Name = 'invoicePictureControl';
        this.invoicePictureControl.TabIndex = 0;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = 'TA';
        this.TTTeslimAlanButon.Name = 'TTTeslimAlanButon';
        this.TTTeslimAlanButon.TabIndex = 120;

        this.Waybill = new TTVisual.TTTextBox();
        this.Waybill.Name = 'Waybill';
        this.Waybill.TabIndex = 145;

        this.RegistrationAuctionNo = new TTVisual.TTTextBox();
        this.RegistrationAuctionNo.Required = true;
        this.RegistrationAuctionNo.BackColor = "#FFE3C6";
        this.RegistrationAuctionNo.Name = 'RegistrationAuctionNo';
        this.RegistrationAuctionNo.TabIndex = 139;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = 'labelMKYS_TeslimEden';
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.txtTotalPrice = new TTVisual.TTTextBox();
        this.txtTotalPrice.BackColor = '#F0F0F0';
        this.txtTotalPrice.ReadOnly = true;
        this.txtTotalPrice.Name = 'txtTotalPrice';
        this.txtTotalPrice.TabIndex = 134;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Name = 'MKYS_TeslimEden';
        this.MKYS_TeslimEden.TabIndex = 118;

        this.ExaminationReportNo = new TTVisual.TTTextBox();
        this.ExaminationReportNo.Name = 'ExaminationReportNo';
        this.ExaminationReportNo.TabIndex = 130;
        this.ExaminationReportNo.Required = false;


        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Name = 'MKYS_TeslimAlan';
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.ConclusionNumber = new TTVisual.TTTextBox();
        this.ConclusionNumber.ReadOnly = true;
        this.ConclusionNumber.Name = 'ConclusionNumber';
        this.ConclusionNumber.TabIndex = 5;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = 'Description';
        this.Description.TabIndex = 0;

        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = i18n("M12146", "Bütçe Türü");
        this.labelBudgetTypeDefinition.Name = 'labelBudgetTypeDefinition';
        this.labelBudgetTypeDefinition.TabIndex = 144;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = '#F0F0F0';
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = 'StockActionID';
        this.StockActionID.TabIndex = 0;


        this.labelWaybillDate = new TTVisual.TTLabel();
        this.labelWaybillDate.Text = i18n("M16573", "İrsaliye Tarihi");
        this.labelWaybillDate.Name = 'labelWaybillDate';
        this.labelWaybillDate.TabIndex = 149;


        this.WaybillDate = new TTVisual.TTDateTimePicker();
        this.WaybillDate.Format = DateTimePickerFormat.Short;
        this.WaybillDate.Name = 'WaybillDate';
        this.WaybillDate.TabIndex = 148;
        this.WaybillDate.Required = true;
        this.WaybillDate.BackColor = "#FFE3C6";


        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.Name = 'BudgetTypeDefinition';
        this.BudgetTypeDefinition.TabIndex = 143;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = '10%';
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = '20%';

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = 'labelMKYS_TeslimAlan';
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14807", "Giriş Yapılan Depo");
        this.labelStore.Name = 'labelStore';
        this.labelStore.TabIndex = 142;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = 'labelTransactionDate';
        this.labelTransactionDate.TabIndex = 115;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = 'MainStoreList';
        this.Store.Name = 'Store';
        this.Store.TabIndex = 141;


        this.GetWaybill = new TTButtonTextBox();
        this.GetWaybill.ButtonText = 'B.G.';
        this.GetWaybill.Name = 'GetWaybill';
        this.GetWaybill.TabIndex = 147;
        this.GetWaybill.ButtonWidth = '10px';
        this.GetWaybill.Required = true;
        this.GetWaybill.BackColor = "#FFE3C6";


        this.labelWaybill = new TTVisual.TTLabel();
        this.labelWaybill.Text = i18n("M16572", "İrsaliye Numarası");
        this.labelWaybill.Name = 'labelWaybill';
        this.labelWaybill.TabIndex = 146;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        //this.TransactionDate.BackColor = '#F0F0F0';
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        //this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = 'TransactionDate';
        this.TransactionDate.TabIndex = 1;

        this.labelRegistrationAuctionNo = new TTVisual.TTLabel();
        this.labelRegistrationAuctionNo.Text = i18n("M16214", "İhale No");
        this.labelRegistrationAuctionNo.Name = 'labelRegistrationAuctionNo';
        this.labelRegistrationAuctionNo.TabIndex = 140;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = 'labelStockActionID';
        this.labelStockActionID.TabIndex = 113;

        this.labelAuctionDate = new TTVisual.TTLabel();
        this.labelAuctionDate.Text = i18n("M16199", "İhale  Tarihi");
        this.labelAuctionDate.Name = 'labelAuctionDate';
        this.labelAuctionDate.TabIndex = 138;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = 'DescriptionAndSignTabControl';
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.AuctionDate = new TTVisual.TTDateTimePicker();
        this.AuctionDate.Required = true;
        this.AuctionDate.BackColor = "#FFE3C6";
        this.AuctionDate.Format = DateTimePickerFormat.Short;
        this.AuctionDate.Name = 'AuctionDate';
        this.AuctionDate.TabIndex = 137;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = 'SignTabpage';

        this.labelExaminationReportNo = new TTVisual.TTLabel();
        this.labelExaminationReportNo.Text = i18n("M19210", "Muayene Rapor Sayısı");
        this.labelExaminationReportNo.Name = 'labelExaminationReportNo';
        this.labelExaminationReportNo.TabIndex = 131;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = 'StockActionSignDetails';
        this.StockActionSignDetails.TabIndex = 0;

        this.labelExaminationReportDate = new TTVisual.TTLabel();
        this.labelExaminationReportDate.Text = i18n("M19211", "Muayene Rapor Tarihi");
        this.labelExaminationReportDate.Name = 'labelExaminationReportDate';
        this.labelExaminationReportDate.TabIndex = 129;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = 'SignUserTypeEnum';
        this.SignUserType.DataMember = 'SignUserType';
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = 'SignUserType';
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.ExaminationReportDate = new TTVisual.TTDateTimePicker();
        this.ExaminationReportDate.Format = DateTimePickerFormat.Short;
        this.ExaminationReportDate.Name = 'ExaminationReportDate';
        this.ExaminationReportDate.TabIndex = 128;
        this.ExaminationReportDate.Required = false;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = 'UserListDefinition';
        this.SignUser.DataMember = 'SignUser';
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = 'SignUser';
        this.SignUser.Width = 400;

        this.labelConclusionNumber = new TTVisual.TTLabel();
        this.labelConclusionNumber.Text = i18n("M17276", "Karar Numarası");
        this.labelConclusionNumber.Name = 'labelConclusionNumber';
        this.labelConclusionNumber.TabIndex = 123;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = 'IsDeputy';
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = 'IsDeputy';
        this.IsDeputy.Width = 50;

        this.labelConclusionDateTime = new TTVisual.TTLabel();
        this.labelConclusionDateTime.Text = i18n("M17284", "Karar Tarihi");
        this.labelConclusionDateTime.Name = 'labelConclusionDateTime';
        this.labelConclusionDateTime.TabIndex = 121;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 111;

        this.ConclusionDateTime = new TTVisual.TTDateTimePicker();
        this.ConclusionDateTime.Format = DateTimePickerFormat.Short;
        this.ConclusionDateTime.Enabled = false;
        this.ConclusionDateTime.Name = 'ConclusionDateTime';
        this.ConclusionDateTime.TabIndex = 6;

        this.labelSupplier = new TTVisual.TTLabel();
        this.labelSupplier.Text = i18n("M14301", "Firma");
        this.labelSupplier.Name = 'labelSupplier';
        this.labelSupplier.TabIndex = 119;

        this.Supplier = new TTVisual.TTObjectListBox();
        this.Supplier.ReadOnly = true;
        this.Supplier.ListDefName = 'SupplierListDefinition';
        this.Supplier.Name = 'Supplier';
        this.Supplier.TabIndex = 9;

        this.ChattelDocumentTabcontrol = new TTVisual.TTTabControl();
        this.ChattelDocumentTabcontrol.Name = 'ChattelDocumentTabcontrol';
        this.ChattelDocumentTabcontrol.TabIndex = 10;

        this.ChattelDocumentDetailTabpage = new TTVisual.TTTabPage();
        this.ChattelDocumentDetailTabpage.DisplayIndex = 0;
        this.ChattelDocumentDetailTabpage.TabIndex = 0;
        this.ChattelDocumentDetailTabpage.Text = 'Taşınır Malın';
        this.ChattelDocumentDetailTabpage.Name = 'ChattelDocumentDetailTabpage';

        this.ChattelDocumentDetailsWithPurchase = new TTVisual.TTGrid();
        this.ChattelDocumentDetailsWithPurchase.Required = true;
        this.ChattelDocumentDetailsWithPurchase.Text = i18n("M12146", "Bütçe Türü");
        this.ChattelDocumentDetailsWithPurchase.Name = 'ChattelDocumentDetailsWithPurchase';
        this.ChattelDocumentDetailsWithPurchase.TabIndex = 0;
        this.ChattelDocumentDetailsWithPurchase.Height = 350;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = '';
        this.Detail.Name = 'Detail';
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.MaterialStockActionDetailIn = new TTVisual.TTListBoxColumn();
        this.MaterialStockActionDetailIn.AllowMultiSelect = true;
        this.MaterialStockActionDetailIn.ListDefName = 'MaterialListDefinition';
        this.MaterialStockActionDetailIn.DataMember = 'Material';
        this.MaterialStockActionDetailIn.AutoCompleteDialogHeight = '60%';
        this.MaterialStockActionDetailIn.AutoCompleteDialogWidth = '90%';
        this.MaterialStockActionDetailIn.DisplayIndex = 1;
        this.MaterialStockActionDetailIn.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialStockActionDetailIn.Name = 'MaterialStockActionDetailIn';
        this.MaterialStockActionDetailIn.Width = 500;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = 'Material.Barcode';
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = 'Barkod';
        this.Barcode.Name = 'Barcode';
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = 'Material.DistributionTypeName';
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = 'DistributionType';
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 120;

        this.AmountStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.AmountStockActionDetailIn.DataMember = 'Amount';
        this.AmountStockActionDetailIn.Required = true;
        this.AmountStockActionDetailIn.Format = 'N2';
        this.AmountStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountStockActionDetailIn.DisplayIndex = 4;
        this.AmountStockActionDetailIn.HeaderText = i18n("M19030", "Miktar");
        this.AmountStockActionDetailIn.Name = 'AmountStockActionDetailIn';
        this.AmountStockActionDetailIn.Width = 120;
        this.AmountStockActionDetailIn.IsNumeric = true;

        this.UnitPriceStockActionDetailInWithOutVat = new TTVisual.TTTextBoxColumn();
        this.UnitPriceStockActionDetailInWithOutVat.DataMember = 'UnitPriceWithOutVat';
        this.UnitPriceStockActionDetailInWithOutVat.Required = true;
        this.UnitPriceStockActionDetailInWithOutVat.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPriceStockActionDetailInWithOutVat.DisplayIndex = 5;
        this.UnitPriceStockActionDetailInWithOutVat.HeaderText = i18n("M17464", "KDV\'siz Fiyatı");
        this.UnitPriceStockActionDetailInWithOutVat.Name = 'UnitPriceStockActionDetailInWithOutVat';
        this.UnitPriceStockActionDetailInWithOutVat.Width = 120;
        this.UnitPriceStockActionDetailInWithOutVat.IsNumeric = true;

        this.ValueAddedTax = new TTVisual.TTTextBoxColumn();
        this.ValueAddedTax.DataMember = 'VatRate';
        this.ValueAddedTax.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ValueAddedTax.DisplayIndex = 6;
        this.ValueAddedTax.HeaderText = i18n("M17457", "KDV Oranı");
        this.ValueAddedTax.Name = 'ValueAddedTax';
        this.ValueAddedTax.ReadOnly = true;
        this.ValueAddedTax.Width = 120;
        this.ValueAddedTax.IsNumeric = true;

        this.UnitePriceWithVatNoDiscount = new TTVisual.TTTextBoxColumn();
        this.UnitePriceWithVatNoDiscount.DataMember = 'UnitPriceWithInVat';
        this.UnitePriceWithVatNoDiscount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitePriceWithVatNoDiscount.DisplayIndex = 7;
        this.UnitePriceWithVatNoDiscount.HeaderText = i18n("M17462", "KDV\'li Fiyatı");
        this.UnitePriceWithVatNoDiscount.Name = 'UnitePriceWithVatNoDiscount';
        this.UnitePriceWithVatNoDiscount.ReadOnly = true;
        this.UnitePriceWithVatNoDiscount.Width = 120;
        this.UnitePriceWithVatNoDiscount.IsNumeric = true;

        this.MKYS_IndirimOranı = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimOranı.DataMember = 'DiscountRate';
        this.MKYS_IndirimOranı.DisplayIndex = 8;
        this.MKYS_IndirimOranı.HeaderText = i18n("M16491", "İndirim Oranı");
        this.MKYS_IndirimOranı.Name = 'MKYS_IndirimOranı';
        this.MKYS_IndirimOranı.Width = 120;
        this.MKYS_IndirimOranı.IsNumeric = true;

        this.UnitPriceStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.UnitPriceStockActionDetailIn.DataMember = 'UnitPrice';
        this.UnitPriceStockActionDetailIn.Format = '#,###.#########';
        this.UnitPriceStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPriceStockActionDetailIn.DisplayIndex = 9;
        this.UnitPriceStockActionDetailIn.HeaderText = i18n("M16484", "İnd. Birim Fiyat");
        this.UnitPriceStockActionDetailIn.Name = 'UnitPriceStockActionDetailIn';
        this.UnitPriceStockActionDetailIn.ReadOnly = true;
        this.UnitPriceStockActionDetailIn.Width = 120;
        this.UnitPriceStockActionDetailIn.IsNumeric = true;

        this.MKYS_IndirimTutari = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimTutari.DataMember = 'DiscountAmount';
        this.MKYS_IndirimTutari.DisplayIndex = 10;
        this.MKYS_IndirimTutari.HeaderText = i18n("M16006", "Indirim Tutarı");
        this.MKYS_IndirimTutari.Name = 'MKYS_IndirimTutari';
        this.MKYS_IndirimTutari.ReadOnly = true;
        this.MKYS_IndirimTutari.Width = 100;
        this.MKYS_IndirimTutari.IsNumeric = true;

        this.TotalPrice = new TTVisual.TTTextBoxColumn();
        this.TotalPrice.DataMember = 'Price';
        this.TotalPrice.DisplayIndex = 11;
        this.TotalPrice.HeaderText = i18n("M23526", "Toplam Tutar");
        this.TotalPrice.Name = 'TotalPrice';
        this.TotalPrice.ReadOnly = true;
        this.TotalPrice.Width = 120;
        this.TotalPrice.IsNumeric = true;

        this.LotNo = new TTVisual.TTTextBoxColumn();
        this.LotNo.DataMember = 'LotNo';
        this.LotNo.DisplayIndex = 12;
        this.LotNo.HeaderText = 'Lot No.';
        this.LotNo.Name = 'LotNo';
        this.LotNo.Width = 100;

        this.ExpirationDateStockActionDetailIn = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDateStockActionDetailIn.Format = DateTimePickerFormat.Custom;
        this.ExpirationDateStockActionDetailIn.CustomFormat = 'MM/yyyy';
        this.ExpirationDateStockActionDetailIn.DataMember = 'ExpirationDate';
        this.ExpirationDateStockActionDetailIn.DisplayIndex = 13;
        this.ExpirationDateStockActionDetailIn.HeaderText = i18n("M22057", "Son Kullanma Tarihi");
        this.ExpirationDateStockActionDetailIn.Name = 'ExpirationDateStockActionDetailIn';
        this.ExpirationDateStockActionDetailIn.Width = 180;

        this.StockLevelTypeStockActionDetailIn = new TTVisual.TTListDefComboBoxColumn();
        this.StockLevelTypeStockActionDetailIn.ListDefName = 'StockLevelTypeList';
        this.StockLevelTypeStockActionDetailIn.DataMember = 'StockLevelType';
        this.StockLevelTypeStockActionDetailIn.DisplayIndex = 14;
        this.StockLevelTypeStockActionDetailIn.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeStockActionDetailIn.Name = 'StockLevelTypeStockActionDetailIn';
        this.StockLevelTypeStockActionDetailIn.Visible = false;
        this.StockLevelTypeStockActionDetailIn.Width = 100;

        this.StatusStockActionDetailIn = new TTVisual.TTEnumComboBoxColumn();
        this.StatusStockActionDetailIn.DataTypeName = 'StockActionDetailStatusEnum';
        this.StatusStockActionDetailIn.DataMember = 'Status';
        this.StatusStockActionDetailIn.DisplayIndex = 15;
        this.StatusStockActionDetailIn.HeaderText = 'Durum';
        this.StatusStockActionDetailIn.Name = 'StatusStockActionDetailIn';
        this.StatusStockActionDetailIn.Visible = false;
        this.StatusStockActionDetailIn.Width = 80;

        this.MKYS_EdinimYili = new TTVisual.TTTextBoxColumn();
        this.MKYS_EdinimYili.DataMember = 'RetrievalYear';
        this.MKYS_EdinimYili.DisplayIndex = 16;
        this.MKYS_EdinimYili.HeaderText = i18n("M13475", "Edinim Yılı");
        this.MKYS_EdinimYili.Name = 'MKYS_EdinimYili';
        this.MKYS_EdinimYili.Width = 100;

        this.MKYS_UretimTarihi = new TTVisual.TTDateTimePickerColumn();
        this.MKYS_UretimTarihi.DataMember = 'ProductionDate';
        this.MKYS_UretimTarihi.DisplayIndex = 17;
        this.MKYS_UretimTarihi.HeaderText = i18n("M23966", "Üretim Tarihi");
        this.MKYS_UretimTarihi.Name = 'MKYS_UretimTarihi';
        this.MKYS_UretimTarihi.Width = 180;

        this.DistributionsTab = new TTVisual.TTTabPage();
        this.DistributionsTab.DisplayIndex = 1;
        this.DistributionsTab.TabIndex = 1;
        this.DistributionsTab.Text = i18n("M16634", "İstek Miktarları");
        this.DistributionsTab.Name = 'DistributionsTab';

        this.DemandAmountsGrid = new TTVisual.TTGrid();
        this.DemandAmountsGrid.AllowUserToDeleteRows = false;
        this.DemandAmountsGrid.RowHeadersVisible = false;
        this.DemandAmountsGrid.Name = 'DemandAmountsGrid';
        this.DemandAmountsGrid.TabIndex = 0;
        this.DemandAmountsGrid.Height = 350;

        this.DA_Material = new TTVisual.TTListBoxColumn();
        this.DA_Material.ListDefName = 'MaterialListDefinition';
        this.DA_Material.DisplayIndex = 0;
        this.DA_Material.HeaderText = i18n("M18545", "Malzeme");
        this.DA_Material.Name = 'DA_Material';
        this.DA_Material.ReadOnly = true;
        this.DA_Material.Visible = false;
        this.DA_Material.Width = 350;

        this.DA_MasterResource = new TTVisual.TTListBoxColumn();
        this.DA_MasterResource.ListDefName = 'ResourceListDefinition';
        this.DA_MasterResource.DataMember = 'MasterResource';
        this.DA_MasterResource.DisplayIndex = 1;
        this.DA_MasterResource.HeaderText = 'Birim';
        this.DA_MasterResource.Name = 'DA_MasterResource';
        this.DA_MasterResource.ReadOnly = true;
        this.DA_MasterResource.Width = 350;

        this.DA_DemandAmount = new TTVisual.TTTextBoxColumn();
        this.DA_DemandAmount.DataMember = 'Amount';
        this.DA_DemandAmount.DisplayIndex = 2;
        this.DA_DemandAmount.HeaderText = i18n("M16632", "İstek Miktarı");
        this.DA_DemandAmount.Name = 'DA_DemandAmount';
        this.DA_DemandAmount.ReadOnly = true;
        this.DA_DemandAmount.Width = 100;

        this.DA_DistributionAmount = new TTVisual.TTTextBoxColumn();
        this.DA_DistributionAmount.DataMember = 'DistributionAmount';
        this.DA_DistributionAmount.DisplayIndex = 3;
        this.DA_DistributionAmount.HeaderText = i18n("M12443", "Dağıtım Miktarı");
        this.DA_DistributionAmount.Name = 'DA_DistributionAmount';
        this.DA_DistributionAmount.Visible = false;
        this.DA_DistributionAmount.Width = 100;
        this.DA_DistributionAmount.IsNumeric = true;

        this.txtDiscount = new TTVisual.TTTextBox();
        this.txtDiscount.BackColor = '#F0F0F0';
        this.txtDiscount.ReadOnly = true;
        this.txtDiscount.Name = 'txtDiscount';
        this.txtDiscount.TabIndex = 124;

        this.txtWithKDV = new TTVisual.TTTextBox();
        this.txtWithKDV.BackColor = '#F0F0F0';
        this.txtWithKDV.ReadOnly = true;
        this.txtWithKDV.Name = 'txtWithKDV';
        this.txtWithKDV.TabIndex = 134;

        this.txtNotKDV = new TTVisual.TTTextBox();
        this.txtNotKDV.BackColor = '#F0F0F0';
        this.txtNotKDV.ReadOnly = true;
        this.txtNotKDV.Name = 'txtNotKDV';
        this.txtNotKDV.TabIndex = 124;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M23503", "Toplam İndirim Tutarı");
        this.ttlabel2.Font = 'Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel2.Name = 'ttlabel2';
        this.ttlabel2.TabIndex = 125;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M14100", "Fatura  Tutarı");
        this.ttlabel3.Font = 'Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel3.Name = 'ttlabel3';
        this.ttlabel3.TabIndex = 125;

        this.MKYS_EAlimYontemi = new TTVisual.TTEnumComboBox();
        this.MKYS_EAlimYontemi.DataTypeName = 'MKYS_EAlimYontemiEnum';
        this.MKYS_EAlimYontemi.Required = true;
        this.MKYS_EAlimYontemi.BackColor = '#FFE3C6';
        this.MKYS_EAlimYontemi.Name = 'MKYS_EAlimYontemi';
        this.MKYS_EAlimYontemi.TabIndex = 19;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = i18n("M18581", "Malzeme Grup");
        this.labelMKYS_EMalzemeGrup.Name = 'labelMKYS_EMalzemeGrup';
        this.labelMKYS_EMalzemeGrup.TabIndex = 16;

        this.MKYS_ETedarikTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_ETedarikTuru.DataTypeName = 'MKYS_ETedarikTurEnum';
        this.MKYS_ETedarikTuru.Required = true;
        this.MKYS_ETedarikTuru.BackColor = '#F0F0F0';
        this.MKYS_ETedarikTuru.Enabled = false;
        this.MKYS_ETedarikTuru.Name = 'MKYS_ETedarikTuru';
        this.MKYS_ETedarikTuru.TabIndex = 15;

        this.labelMKYS_ETedarikTuru = new TTVisual.TTLabel();
        this.labelMKYS_ETedarikTuru.Text = i18n("M14804", "Giriş Türü");
        this.labelMKYS_ETedarikTuru.Name = 'labelMKYS_ETedarikTuru';
        this.labelMKYS_ETedarikTuru.TabIndex = 14;

        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = 'MKYS_EMalzemeGrupEnum';
        this.MKYS_EMalzemeGrup.BackColor = '#F0F0F0';
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = 'MKYS_EMalzemeGrup';
        this.MKYS_EMalzemeGrup.TabIndex = 17;

        this.labelMKYS_EAlimYontemi = new TTVisual.TTLabel();
        this.labelMKYS_EAlimYontemi.Text = i18n("M10699", "Alım Yöntemi");
        this.labelMKYS_EAlimYontemi.Name = 'labelMKYS_EAlimYontemi';
        this.labelMKYS_EAlimYontemi.TabIndex = 18;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M17463", "KDV\'siz Birim Fiyatlar Toplamı");
        this.ttlabel4.Font = 'Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel4.Name = 'ttlabel4';
        this.ttlabel4.TabIndex = 125;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M17461", "KDV\'li Birim Fiyatlar Toplamı");
        this.ttlabel5.Font = 'Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel5.Name = 'ttlabel5';
        this.ttlabel5.TabIndex = 125;

        this.chkFreeEntry = new TTVisual.TTCheckBox();
        this.chkFreeEntry.Value = false;
        this.chkFreeEntry.Title = i18n("M21628", "Serbest Giriş");
        this.chkFreeEntry.Name = 'chkFreeEntry';
        this.chkFreeEntry.TabIndex = 128;
        this.chkFreeEntry.ReadOnly = true;

        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.ChattelDocumentDetailsWithPurchaseColumns = [this.Detail, this.MaterialStockActionDetailIn, this.Barcode, this.DistributionType,
        this.AmountStockActionDetailIn, this.UnitPriceStockActionDetailInWithOutVat, this.ValueAddedTax, this.UnitePriceWithVatNoDiscount,
        this.MKYS_IndirimOranı, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimTutari, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn,
        this.StockLevelTypeStockActionDetailIn, this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi];
        this.DemandAmountsGridColumns = [this.DA_Material, this.DA_MasterResource, this.DA_DemandAmount, this.DA_DistributionAmount];
        this.PictureTabpage.Controls = [this.invoicePictureControl];
        this.DescriptionAndSignTabControl.Controls = [this.PictureTabpage, this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.ChattelDocumentTabcontrol.Controls = [this.ChattelDocumentDetailTabpage, this.DistributionsTab];
        this.ChattelDocumentDetailTabpage.Controls = [this.ChattelDocumentDetailsWithPurchase];
        this.DistributionsTab.Controls = [this.DemandAmountsGrid];
        this.Controls = [this.chkFreeEntry, this.PictureTabpage, this.TTTeslimEdenButon, this.invoicePictureControl, this.TTTeslimAlanButon, this.Waybill,
        this.labelMKYS_TeslimEden, this.RegistrationAuctionNo, this.MKYS_TeslimEden, this.txtTotalPrice, this.MKYS_TeslimAlan, this.ExaminationReportNo,
        this.Description, this.ConclusionNumber, this.StockActionID, this.labelWaybillDate, this.labelMKYS_TeslimAlan, this.WaybillDate, this.labelTransactionDate,
        this.GetWaybill, this.TransactionDate, this.labelWaybill, this.labelStockActionID, this.labelBudgetTypeDefinition, this.DescriptionAndSignTabControl,
        this.BudgetTypeDefinition, this.SignTabpage, this.labelStore, this.StockActionSignDetails, this.Store, this.SignUserType, this.labelRegistrationAuctionNo,
        this.SignUser, this.labelAuctionDate, this.IsDeputy, this.AuctionDate, this.ttlabel1, this.labelExaminationReportNo, this.labelExaminationReportDate,
        this.ExaminationReportDate, this.labelConclusionNumber, this.labelConclusionDateTime, this.ConclusionDateTime, this.labelSupplier, this.Supplier,
        this.ChattelDocumentTabcontrol, this.ChattelDocumentDetailTabpage, this.ChattelDocumentDetailsWithPurchase, this.Detail, this.MaterialStockActionDetailIn,
        this.Barcode, this.DistributionType, this.AmountStockActionDetailIn, this.UnitPriceStockActionDetailInWithOutVat, this.ValueAddedTax, this.UnitePriceWithVatNoDiscount,
        this.MKYS_IndirimOranı, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimTutari, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn,
        this.StockLevelTypeStockActionDetailIn, this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi, this.DistributionsTab,
        this.DemandAmountsGrid, this.DA_Material, this.DA_MasterResource, this.DA_DemandAmount, this.DA_DistributionAmount, this.txtDiscount, this.txtWithKDV,
        this.txtNotKDV, this.ttlabel2, this.ttlabel3, this.MKYS_EAlimYontemi, this.labelMKYS_EMalzemeGrup, this.MKYS_ETedarikTuru, this.labelMKYS_ETedarikTuru,
        this.MKYS_EMalzemeGrup, this.labelMKYS_EAlimYontemi, this.ttlabel4, this.ttlabel5];

    }


}

