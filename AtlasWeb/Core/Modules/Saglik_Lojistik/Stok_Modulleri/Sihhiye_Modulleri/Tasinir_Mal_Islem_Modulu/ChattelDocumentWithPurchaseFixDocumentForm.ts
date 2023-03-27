//$3081495A
import { Component, ViewChild, OnInit, ApplicationRef, NgZone, ChangeDetectorRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ChattelDocumentWithPurchaseFixDocumentFormViewModel } from './ChattelDocumentWithPurchaseFixDocumentFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseChattelDocumentWithPurchaseForm, PTSMaterial } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentWithPurchaseForm";
import { ChattelDocumentWithPurchase, MKYS_EMalzemeGrupEnum, CommisionTypeEnum, SignUserTypeEnum, ConsumableMaterialDefinition, PTSStockActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentDetailWithPurchase } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentDistribution } from 'NebulaClient/Model/AtlasClientModel';
import { Demand } from 'NebulaClient/Model/AtlasClientModel';
import { DemandDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';

import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';
import { TTException } from 'app/NebulaClient/Utils/Exceptions/TTException';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { CommisionDefinitionInputDTO } from 'app/Logistic/Views/LogisticDefinitionComponents/CommisionDefinitionComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { GetWaybillForInputDetailDocument_Output, ChattelDocumentWithPurchaseService } from 'app/NebulaClient/Services/ObjectService/ChattelDocumentWithPurchaseService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { TTButtonTextBox } from 'app/NebulaClient/Visual/Controls/TTButtonTextBox';
import { StockActionService, GetInPatientPhysicianApplications_Output } from 'app/NebulaClient/Services/ObjectService/StockActionService';

@Component({
    selector: 'ChattelDocumentWithPurchaseFixDocumentForm',
    templateUrl: './ChattelDocumentWithPurchaseFixDocumentForm.html',
    providers: [MessageService]
})
export class ChattelDocumentWithPurchaseFixDocumentForm extends BaseChattelDocumentWithPurchaseForm implements OnInit {
    public ChattelDocumentDetailsWithPurchaseColumns = [];
    public DemandAmountsGridColumns = [];
    public StockActionSignDetailsColumns = [];
    public IsPatientSpecial: Boolean = false;
    public PatientSpecialKey: string;
    public findPatient: boolean = false;
    IsPatientSpecialCheck: boolean = true;
    public chattelDocumentWithPurchaseFixDocumentFormViewModel: ChattelDocumentWithPurchaseFixDocumentFormViewModel = new ChattelDocumentWithPurchaseFixDocumentFormViewModel();
    public get _ChattelDocumentWithPurchase(): ChattelDocumentWithPurchase {
        return this._TTObject as ChattelDocumentWithPurchase;
    }
    private ChattelDocumentWithPurchaseFixDocumentForm_DocumentUrl: string = '/api/ChattelDocumentWithPurchaseService/ChattelDocumentWithPurchaseFixDocumentForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone,
        protected objectContextService: ObjectContextService, private changeDetectorRef: ChangeDetectorRef, ) {
        super(httpService, messageService, ngZone, objectContextService);
        this._DocumentServiceUrl = this.ChattelDocumentWithPurchaseFixDocumentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();

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
        this.txtTotalPrice.Text = priceCalc[3].toFixed(2);

        let useExaminationReportNoSeq: string = await SystemParameterService.GetParameterValue("USEEXAMINATIONREPORTNOSEQ", "FALSE");
        if (useExaminationReportNoSeq === "TRUE") {
            this.ExaminationReportNo.ReadOnly = true;
        }
        if (this._ChattelDocumentWithPurchase.InPatientPhysicianApplication != null)
            this.findPatient = true;
    }


    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
        let count: number = 20;

        if (this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.tibbiSarf) {
            if (this._ChattelDocumentWithPurchase.Supplier == null) {
                throw new TTException("Firma Seçimi Yapılmalı!");
            }
            else if (String.isNullOrEmpty(this._ChattelDocumentWithPurchase.Supplier.SupplierNumber)) {
                throw new TTException("Seçilen firma için bayi no bilgisi bulunmamaktadır. Tıbbi Sarf malzemeler için bayi no bilgisi " + this._ChattelDocumentWithPurchase.Supplier.Name + " firması için tanımlanmalı.");
            }
        }

        if (this._ChattelDocumentWithPurchase.MKYS_EAlimYontemi === null || this._ChattelDocumentWithPurchase.MKYS_EAlimYontemi == undefined) {
            throw new TTException(" Malzemenin Alım Yöntemi Seçilmelidir!");
        }

        for (let detail of this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase) {
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

        for (let signUser of this._ChattelDocumentWithPurchase.StockActionSignDetails) {
            if (signUser.SignUser == null)
                throw new TTException("Muayene Komisyonu boş geçilemez.");
        }

        this._ViewModel.ChattelDocumentDetailsWithPurchaseGridList = this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase;
        this._ViewModel.PTSStockActionDetails = this._ChattelDocumentWithPurchase.PTSStockActionDetails;
        this._ViewModel.StockActionSignDetailsGridList = this._ChattelDocumentWithPurchase.StockActionSignDetails;
    }

    public async findPatientClick() {

        let inApps: Array<GetInPatientPhysicianApplications_Output> = await StockActionService.GetInPatientPhysicianApplications(this.PatientSpecialKey);
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();

        let count: number = 0;
        for (let inApp of inApps) {
            multiSelectForm.AddMSItem(inApp.Key, inApp.Key, inApp);
            count++;
        }

        let mlotKey: string = await multiSelectForm.GetMSItem(null, "Yatış Seçiniz", true);
        if (multiSelectForm.MSSelectedItemObject !== null) {
            let selectedInApp: GetInPatientPhysicianApplications_Output = multiSelectForm.MSSelectedItemObject as GetInPatientPhysicianApplications_Output;
            if (selectedInApp != null) {
                if (selectedInApp.InvoiceControl == false) {
                    this._ChattelDocumentWithPurchase.InPatientPhysicianApplication = selectedInApp.InPatientPhysicianApplication;
                    this.PatientSpecialKey = selectedInApp.PatientInfo;
                    this._ChattelDocumentWithPurchase.Description = selectedInApp.Description;
                    this.findPatient = true;
                    //this.Description.Enabled = false;
                } else {
                    TTVisual.InfoBox.Alert(selectedInApp.Description);
                }
            }
        }
    }

    public async selectCommision() {
        let useCommision: string = (await SystemParameterService.GetParameterValue('USEEXAMINATIONCOMMISION', 'FALSE'));
        if (useCommision === "TRUE") {
            this.showCommisionComponent(CommisionTypeEnum.PurchaseExaminationCommision).then(res => {
                let modalActionResult = res as ModalActionResult;
                if (modalActionResult.Result === DialogResult.OK) {
                    let commision = res.Param as CommisionDefinitionInputDTO;
                    this._ChattelDocumentWithPurchase.StockActionSignDetails = new Array<StockActionSignDetail>();
                    for (let member of commision.CommisionMembers) {
                        let signDetail: StockActionSignDetail = new StockActionSignDetail();
                        signDetail.SignUser = member.ResUser;
                        signDetail.SignUserType = member.SignUserType;
                        signDetail.IsDeputy = false;
                        this._ChattelDocumentWithPurchase.StockActionSignDetails.push(signDetail);
                    }
                }
            });
        } else {
            if (this._ChattelDocumentWithPurchase.StockActionSignDetails.length == 0) {
                for (let index = 0; index < 3; index++) {
                    let signDetail: StockActionSignDetail = new StockActionSignDetail();
                    if (index === 0)
                        signDetail.SignUserType = SignUserTypeEnum.Baskan;
                    else
                        signDetail.SignUserType = SignUserTypeEnum.Uye;
                    signDetail.IsDeputy = false;
                    this._ChattelDocumentWithPurchase.StockActionSignDetails.push(signDetail);
                }
            }
        }
    }

    private showCommisionComponent(data: CommisionTypeEnum): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'CommisionSelectComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Komisyon';
            modalInfo.Width = 800;
            modalInfo.Height = 500;
            modalInfo.IsShowCloseButton = false;

            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChattelDocumentWithPurchase();
        this.chattelDocumentWithPurchaseFixDocumentFormViewModel = new ChattelDocumentWithPurchaseFixDocumentFormViewModel();
        this._ViewModel = this.chattelDocumentWithPurchaseFixDocumentFormViewModel;
        this.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase = this._TTObject as ChattelDocumentWithPurchase;
        this.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase.Store = new Store();
        this.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase.Supplier = new Supplier();
        this.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase = new Array<ChattelDocumentDetailWithPurchase>();
        this.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDistributions = new Array<ChattelDocumentDistribution>();
        this.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase.PTSStockActionDetails = new Array<PTSStockActionDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.chattelDocumentWithPurchaseFixDocumentFormViewModel = this._ViewModel as ChattelDocumentWithPurchaseFixDocumentFormViewModel;
        that._TTObject = this.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase;
        if (this.chattelDocumentWithPurchaseFixDocumentFormViewModel == null)
            this.chattelDocumentWithPurchaseFixDocumentFormViewModel = new ChattelDocumentWithPurchaseFixDocumentFormViewModel();
        if (this.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase == null)
            this.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase = new ChattelDocumentWithPurchase();
        let budgetTypeDefinitionObjectID = that.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase["BudgetTypeDefinition"];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === "string")) {
            let budgetTypeDefinition = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase.Store = store;
            }
        }

        let supplierObjectID = that.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase["Supplier"];
        if (supplierObjectID != null && (typeof supplierObjectID === "string")) {
            let supplier = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.Suppliers.find(o => o.ObjectID.toString() === supplierObjectID.toString());
            if (supplier) {
                that.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase.Supplier = supplier;
            }
        }

        that.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.ChattelDocumentDetailsWithPurchaseGridList;
        for (let detailItem of that.chattelDocumentWithPurchaseFixDocumentFormViewModel.ChattelDocumentDetailsWithPurchaseGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }

                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase.PTSStockActionDetails = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.PTSStockActionDetails;
        for (let detailItem of that.chattelDocumentWithPurchaseFixDocumentFormViewModel.PTSStockActionDetails) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                            material.NATOStockNO = stockCard.NATOStockNO;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }

        that.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDistributions = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.DemandAmountsGridGridList;
        for (let detailItem of that.chattelDocumentWithPurchaseFixDocumentFormViewModel.DemandAmountsGridGridList) {
            let demandDetailObjectID = detailItem["DemandDetail"];
            if (demandDetailObjectID != null && (typeof demandDetailObjectID === "string")) {
                let demandDetail = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.DemandDetails.find(o => o.ObjectID.toString() === demandDetailObjectID.toString());
                if (demandDetail) {
                    detailItem.DemandDetail = demandDetail;
                }
                if (demandDetail != null) {
                    let demandObjectID = demandDetail["Demand"];
                    if (demandObjectID != null && (typeof demandObjectID === "string")) {
                        let demand = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.Demands.find(o => o.ObjectID.toString() === demandObjectID.toString());
                        if (demand) {
                            demandDetail.Demand = demand;
                        }
                        if (demand != null) {
                            let masterResourceObjectID = demand["MasterResource"];
                            if (masterResourceObjectID != null && (typeof masterResourceObjectID === "string")) {
                                let masterResource = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                                if (masterResource) {
                                    demand.MasterResource = masterResource;
                                }
                            }

                        }
                    }
                }
            }
        }

        that.chattelDocumentWithPurchaseFixDocumentFormViewModel._ChattelDocumentWithPurchase.StockActionSignDetails = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.chattelDocumentWithPurchaseFixDocumentFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === "string")) {
                let signUser = that.chattelDocumentWithPurchaseFixDocumentFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }

    public ShowITSReceiveNotifications: boolean = false;
    public incomingITSReceiptNotificationList = new Array<PTSMaterial>();
    async ngOnInit() {
        await this.load();
        if (this._ChattelDocumentWithPurchase.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ChattelDocumentWithPurchase.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M21380", "Satınalma Yoluyla Giriş ( Belge Düzeltme )");
        this.changeDetectorRef.detectChanges();
        if (this._ChattelDocumentWithPurchase.IsPTSAction) {
            this.ShowITSReceiveNotifications = true;
            this.incomingITSReceiptNotificationList = new Array<PTSMaterial>();
            for (let item of this.chattelDocumentWithPurchaseFixDocumentFormViewModel.PTSMaterials) {
                let ptsStockActionDetailObjectID = item["PTSStockActionDetail"];
                if (ptsStockActionDetailObjectID != null && (typeof ptsStockActionDetailObjectID === "string")) {
                    let ptsStockActionDetail = this.chattelDocumentWithPurchaseFixDocumentFormViewModel.PTSStockActionDetails.find(o => o.ObjectID.toString() === ptsStockActionDetailObjectID.toString());
                    if (ptsStockActionDetail) {
                        item.PTSStockActionDetail = ptsStockActionDetail;
                    }
                }
            }
            
            this.incomingITSReceiptNotificationList = this.chattelDocumentWithPurchaseFixDocumentFormViewModel.PTSMaterials;
            if (this.incomingITSReceiptNotificationList) {
                if (this.incomingITSReceiptNotificationList.length > 0)
                    this.CalculateFormTotalPriceForITS();
            }
        }
    }

    public onAuctionDateChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.AuctionDate != event) {
            this._ChattelDocumentWithPurchase.AuctionDate = event;
        }
    }

    public onBudgetTypeDefinitionChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.BudgetTypeDefinition != event) {
            this._ChattelDocumentWithPurchase.BudgetTypeDefinition = event;
        }
    }

    public onConclusionDateTimeChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ConclusionDateTime != event) {
            this._ChattelDocumentWithPurchase.ConclusionDateTime = event;
        }
    }

    public onConclusionNumberChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ConclusionNumber != event) {
            this._ChattelDocumentWithPurchase.ConclusionNumber = event;
        }
    }

    public onDescriptionChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Description != event) {
            this._ChattelDocumentWithPurchase.Description = event;
        }
    }

    public onExaminationReportDateChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ExaminationReportDate != event) {
            this._ChattelDocumentWithPurchase.ExaminationReportDate = event;
        }
    }

    public onExaminationReportNoChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ExaminationReportNo != event) {
            this._ChattelDocumentWithPurchase.ExaminationReportNo = event;
        }
    }

    public onMKYS_EAlimYontemiChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_EAlimYontemi != event) {
            this._ChattelDocumentWithPurchase.MKYS_EAlimYontemi = event;
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup != event) {
            this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup = event;
        }
    }

    public onMKYS_ETedarikTuruChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_ETedarikTuru != event) {
            this._ChattelDocumentWithPurchase.MKYS_ETedarikTuru = event;
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_TeslimAlan != event) {
            this._ChattelDocumentWithPurchase.MKYS_TeslimAlan = event;
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_TeslimEden != event) {
            this._ChattelDocumentWithPurchase.MKYS_TeslimEden = event;
        }
    }

    public onRegistrationAuctionNoChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.RegistrationAuctionNo != event) {
            this._ChattelDocumentWithPurchase.RegistrationAuctionNo = event;
        }
    }

    public onStockActionIDChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.StockActionID != event) {
            this._ChattelDocumentWithPurchase.StockActionID = event;
        }
    }

    public onStoreChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Store != event) {
            this._ChattelDocumentWithPurchase.Store = event;
        }
    }

    public onSupplierChanged(event): void {

        if (event != null && this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Supplier != event) {
            let supplier = <Supplier>event;
            if (this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.tibbiSarf) // mevzuat gereği tıbbi sarf malzemelerde bayi no alanı zorunlu hale geldi.
            {
                if (String.isNullOrEmpty(supplier.SupplierNumber)) {
                    ServiceLocator.MessageService.showError("Seçilen firma için bayi no bilgisi bulunmamaktadır. Tıbbi Sarf malzemeler için bayi no bilgisi " + supplier.Name + " firması için tanımlanmalı.");
                    this._ChattelDocumentWithPurchase.Supplier = event;
                }
            }
            this._ChattelDocumentWithPurchase.Supplier = event;
            this._ChattelDocumentWithPurchase.MKYS_TeslimEden = this._ChattelDocumentWithPurchase.Supplier.Name;
        }
        else
            this._ChattelDocumentWithPurchase.Supplier = event;
    }

    public onTransactionDateChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.TransactionDate != event) {
            this._ChattelDocumentWithPurchase.TransactionDate = event;
        }
    }

    public async GetWaybill_Click(): Promise<void> {

        let PurchaseEServiceName: string = (await SystemParameterService.GetParameterValue('PURCHASESERVICENAME', ''));
        if (PurchaseEServiceName == 'XXXXXX') {
            if (this._ChattelDocumentWithPurchase.CurrentStateDefID.toString() === ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.New.id) {
                if (!String.isNullOrEmpty(this._ChattelDocumentWithPurchase.Waybill)) {
                    let inputDetailDocument: GetWaybillForInputDetailDocument_Output = await ChattelDocumentWithPurchaseService.GetWaybillForInputDocumentTS(this._ChattelDocumentWithPurchase);
                    if (inputDetailDocument != null) {
                        let purchaseDocument: ChattelDocumentWithPurchase = inputDetailDocument.chattelDocumentWithPurchase;
                        let purchaseDocumentDetails: Array<ChattelDocumentDetailWithPurchase> = inputDetailDocument.chattelDocumentDetailWithPurchase;
                        let budgetObj: Guid = <any>purchaseDocument["BudgetTypeDefinition"];
                        let budgetTypeDef: any = await this.objectContextService.getObject(budgetObj, BudgetTypeDefinition.ObjectDefID);
                        this._ChattelDocumentWithPurchase.BudgetTypeDefinition = budgetTypeDef;
                        let supplierObj: Guid = <any>purchaseDocument["Supplier"];
                        let SupplierDef: any = await this.objectContextService.getObject(supplierObj, Supplier.ObjectDefID);
                        this._ChattelDocumentWithPurchase.Supplier = SupplierDef;
                        this._ChattelDocumentWithPurchase.MKYS_EAlimYontemi = purchaseDocument.MKYS_EAlimYontemi;
                        this._ChattelDocumentWithPurchase.AuctionDate = purchaseDocument.AuctionDate;
                        this._ChattelDocumentWithPurchase.ExaminationReportNo = purchaseDocument.ExaminationReportNo;
                        this._ChattelDocumentWithPurchase.ExaminationReportDate = purchaseDocument.ExaminationReportDate;
                        this._ChattelDocumentWithPurchase.MKYS_TeslimAlan = purchaseDocument.MKYS_TeslimAlan;
                        this._ChattelDocumentWithPurchase.MKYS_TeslimEden = purchaseDocument.MKYS_TeslimEden;
                        this._ChattelDocumentWithPurchase.WaybillDate = purchaseDocument.WaybillDate;
                        this._ChattelDocumentWithPurchase.Description = purchaseDocument.Description;
                        this._ChattelDocumentWithPurchase.FreeEntry = false;
                        this._ChattelDocumentWithPurchase.RegistrationAuctionNo = purchaseDocument.RegistrationAuctionNo;
                        this._ChattelDocumentWithPurchase.ConclusionDateTime = purchaseDocument.ConclusionDateTime;
                        this._ChattelDocumentWithPurchase.ConclusionNumber = purchaseDocument.ConclusionNumber;
                        this._ChattelDocumentWithPurchase.PatientFullName = purchaseDocument.PatientFullName;
                        this._ChattelDocumentWithPurchase.PatientUniqueNo = purchaseDocument.PatientUniqueNo;

                        for (let detail of purchaseDocumentDetails) {
                            let chattelDocumentDetailWithPurchase: ChattelDocumentDetailWithPurchase = new ChattelDocumentDetailWithPurchase();
                            chattelDocumentDetailWithPurchase.Amount = detail.Amount;
                            chattelDocumentDetailWithPurchase.DiscountAmount = detail.DiscountAmount;
                            chattelDocumentDetailWithPurchase.DiscountRate = detail.DiscountRate;
                            chattelDocumentDetailWithPurchase.ExpirationDate = detail.ExpirationDate;
                            let mat: Guid = <any>detail["Material"];
                            let material: any = await this.objectContextService.getObject(mat, Material.ObjectDefID);
                            chattelDocumentDetailWithPurchase.Material = material;
                            let stockCardObj: Guid = <any>material["StockCard"];
                            let stockCard: any = await this.objectContextService.getObject(stockCardObj, StockCard.ObjectDefID);
                            chattelDocumentDetailWithPurchase.Material.StockCard = stockCard;
                            let dist: Guid = <any>stockCard["DistributionType"];
                            let distributionType: any = await this.objectContextService.getObject(dist, DistributionTypeDefinition.ObjectDefID);
                            chattelDocumentDetailWithPurchase.Material.StockCard.DistributionType = distributionType;
                            chattelDocumentDetailWithPurchase.NotDiscountedUnitPrice = detail.NotDiscountedUnitPrice;
                            chattelDocumentDetailWithPurchase.TotalDiscountAmount = detail.TotalDiscountAmount;
                            chattelDocumentDetailWithPurchase.TotalPriceNotDiscount = detail.TotalPriceNotDiscount;
                            chattelDocumentDetailWithPurchase.UnitPriceWithInVat = detail.UnitPriceWithInVat;
                            chattelDocumentDetailWithPurchase.UnitPriceWithOutVat = detail.UnitPriceWithOutVat;
                            chattelDocumentDetailWithPurchase.VatRate = detail.VatRate;
                            chattelDocumentDetailWithPurchase.DiscountAmount = detail.DiscountAmount;
                            chattelDocumentDetailWithPurchase.LotNo = detail.LotNo;
                            chattelDocumentDetailWithPurchase.StockLevelType = detail.StockLevelType;
                            chattelDocumentDetailWithPurchase.Status = detail.Status;
                            chattelDocumentDetailWithPurchase.RetrievalYear = detail.RetrievalYear;
                            //chattelDocumentDetailWithPurchase.ProductionDate = detail.ProductionDate;

                            this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.push(chattelDocumentDetailWithPurchase);

                            await this.CalculatePricesWithKdv(chattelDocumentDetailWithPurchase);
                            let priceCalc: Array<number> = new Array<number>();
                            let totalWithoutKDV: number = 0, totalWithKDV = 0, salesTotal = 0, totalPrice = 0;
                            priceCalc.push(totalWithoutKDV);
                            priceCalc.push(totalWithKDV);
                            priceCalc.push(salesTotal);
                            priceCalc.push(totalPrice);
                            priceCalc = await this.CalcFinalPriceWithKDV(priceCalc);
                            this.txtNotKDV.Text = priceCalc[0].toString();
                            this.txtWithKDV.Text = priceCalc[1].toString();
                            this.txtDiscount.Text = priceCalc[2].toString();
                            this.txtTotalPrice.Text = priceCalc[3].toString();
                            this.ChattelDocumentDetailsWithPurchase.AllowUserToAddRows = false;
                            this.ChattelDocumentDetailsWithPurchase.AllowUserToDeleteRows = false;
                        }
                    }
                }
            }
        }
        else if (PurchaseEServiceName == 'FASTSOFT') {
            if (this._ChattelDocumentWithPurchase.CurrentStateDefID.toString() === ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.New.id) {
                if (!String.isNullOrEmpty(this._ChattelDocumentWithPurchase.Waybill)) {
                    try {
                        let inputDetailDocument: GetWaybillForInputDetailDocument_Output = await ChattelDocumentWithPurchaseService.GetWaybillForInputDocumentTSFastSoft(this._ChattelDocumentWithPurchase);
                        if (inputDetailDocument != null) {
                            if (inputDetailDocument.chattelDocumentDetailWithPurchase.length > 0) {
                                let purchaseDocument: ChattelDocumentWithPurchase = inputDetailDocument.chattelDocumentWithPurchase;
                                let purchaseDocumentDetails: Array<ChattelDocumentDetailWithPurchase> = inputDetailDocument.chattelDocumentDetailWithPurchase;
                                let budgetObj: Guid = <any>purchaseDocument["BudgetTypeDefinition"];
                                let budgetTypeDef: any = await this.objectContextService.getObject(budgetObj, BudgetTypeDefinition.ObjectDefID);
                                this._ChattelDocumentWithPurchase.BudgetTypeDefinition = budgetTypeDef;
                                let supplierObj: Guid = <any>purchaseDocument["Supplier"];
                                let SupplierDef: any = await this.objectContextService.getObject(supplierObj, Supplier.ObjectDefID);
                                this._ChattelDocumentWithPurchase.Supplier = SupplierDef;
                                this._ChattelDocumentWithPurchase.MKYS_EAlimYontemi = purchaseDocument.MKYS_EAlimYontemi;
                                this._ChattelDocumentWithPurchase.AuctionDate = purchaseDocument.AuctionDate;
                                this._ChattelDocumentWithPurchase.ExaminationReportNo = purchaseDocument.ExaminationReportNo;
                                this._ChattelDocumentWithPurchase.ExaminationReportDate = purchaseDocument.ExaminationReportDate;
                                this._ChattelDocumentWithPurchase.MKYS_TeslimAlan = purchaseDocument.MKYS_TeslimAlan;
                                this._ChattelDocumentWithPurchase.MKYS_TeslimEden = purchaseDocument.MKYS_TeslimEden;
                                this._ChattelDocumentWithPurchase.WaybillDate = purchaseDocument.WaybillDate;
                                this._ChattelDocumentWithPurchase.Description = purchaseDocument.Description;
                                this._ChattelDocumentWithPurchase.FreeEntry = false;
                                this._ChattelDocumentWithPurchase.RegistrationAuctionNo = purchaseDocument.RegistrationAuctionNo;
                                this._ChattelDocumentWithPurchase.ConclusionDateTime = purchaseDocument.ConclusionDateTime;
                                this._ChattelDocumentWithPurchase.ConclusionNumber = purchaseDocument.ConclusionNumber;
                                this._ChattelDocumentWithPurchase.PatientFullName = purchaseDocument.PatientFullName;
                                this._ChattelDocumentWithPurchase.PatientUniqueNo = purchaseDocument.PatientUniqueNo;
                                this._ChattelDocumentWithPurchase.IsFastSoft = true;
                                this._ChattelDocumentWithPurchase.FastSoftFaturaId = purchaseDocument.FastSoftFaturaId;
                                this._ChattelDocumentWithPurchase.FastSoftUygulamaId = purchaseDocument.FastSoftUygulamaId;

                                for (let detail of purchaseDocumentDetails) {
                                    let chattelDocumentDetailWithPurchase: ChattelDocumentDetailWithPurchase = new ChattelDocumentDetailWithPurchase();
                                    chattelDocumentDetailWithPurchase.Amount = detail.Amount;
                                    chattelDocumentDetailWithPurchase.DiscountAmount = detail.DiscountAmount;
                                    chattelDocumentDetailWithPurchase.DiscountRate = detail.DiscountRate;
                                    chattelDocumentDetailWithPurchase.ExpirationDate = detail.ExpirationDate;
                                    let mat: Guid = <any>detail["Material"];
                                    let material: any = await this.objectContextService.getObject(mat, Material.ObjectDefID);
                                    chattelDocumentDetailWithPurchase.Material = material;
                                    let stockCardObj: Guid = <any>material["StockCard"];
                                    let stockCard: any = await this.objectContextService.getObject(stockCardObj, StockCard.ObjectDefID);
                                    chattelDocumentDetailWithPurchase.Material.StockCard = stockCard;
                                    let dist: Guid = <any>stockCard["DistributionType"];
                                    let distributionType: any = await this.objectContextService.getObject(dist, DistributionTypeDefinition.ObjectDefID);
                                    chattelDocumentDetailWithPurchase.Material.StockCard.DistributionType = distributionType;
                                    chattelDocumentDetailWithPurchase.NotDiscountedUnitPrice = detail.NotDiscountedUnitPrice;
                                    chattelDocumentDetailWithPurchase.TotalDiscountAmount = detail.TotalDiscountAmount;
                                    chattelDocumentDetailWithPurchase.TotalPriceNotDiscount = detail.TotalPriceNotDiscount;
                                    chattelDocumentDetailWithPurchase.UnitPriceWithInVat = detail.UnitPriceWithInVat;
                                    chattelDocumentDetailWithPurchase.UnitPriceWithOutVat = detail.UnitPriceWithOutVat;
                                    chattelDocumentDetailWithPurchase.VatRate = detail.VatRate;
                                    chattelDocumentDetailWithPurchase.DiscountAmount = detail.DiscountAmount;
                                    chattelDocumentDetailWithPurchase.LotNo = detail.LotNo;
                                    chattelDocumentDetailWithPurchase.StockLevelType = detail.StockLevelType;
                                    chattelDocumentDetailWithPurchase.Status = detail.Status;
                                    chattelDocumentDetailWithPurchase.RetrievalYear = detail.RetrievalYear;
                                    //chattelDocumentDetailWithPurchase.ProductionDate = detail.ProductionDate;

                                    this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.push(chattelDocumentDetailWithPurchase);

                                    await this.CalculatePricesWithKdv(chattelDocumentDetailWithPurchase);
                                    let priceCalc: Array<number> = new Array<number>();
                                    let totalWithoutKDV: number = 0, totalWithKDV = 0, salesTotal = 0, totalPrice = 0;
                                    priceCalc.push(totalWithoutKDV);
                                    priceCalc.push(totalWithKDV);
                                    priceCalc.push(salesTotal);
                                    priceCalc.push(totalPrice);
                                    priceCalc = await this.CalcFinalPriceWithKDV(priceCalc);
                                    this.txtNotKDV.Text = priceCalc[0].toString();
                                    this.txtWithKDV.Text = priceCalc[1].toString();
                                    this.txtDiscount.Text = priceCalc[2].toString();
                                    this.txtTotalPrice.Text = priceCalc[3].toString();


                                    this.ChattelDocumentDetailsWithPurchase.AllowUserToAddRows = false;
                                    this.ChattelDocumentDetailsWithPurchase.AllowUserToDeleteRows = false;
                                }

                            }
                            else {
                                TTVisual.InfoBox.Alert(" İrsaliyeli Kayıt Bulunamamıştır.!");
                            }
                        }
                        else {
                            TTVisual.InfoBox.Alert(" İrsaliyeli Kayıt Bulunamamıştır.!");
                        }
                    }
                    catch (ex) {
                        ServiceLocator.MessageService.showError(ex);
                    }
                }
            }
        }
        else {
            TTVisual.InfoBox.Alert(" PURCHASESERVICENAME parametresini kontrol ediniz!");
        }
    }

    public onWaybillChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Waybill != event) {
            this._ChattelDocumentWithPurchase.Waybill = event;
        }
    }

    public onWaybillDateChanged(event): void {
        if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.WaybillDate != event) {
            this._ChattelDocumentWithPurchase.WaybillDate = event;
        }
    }

    public PTSMaterialPriceUpdate(event: any) {
        let data = <PTSMaterial>event.data;
        if (data.amount <= 0 || data.UnitPriceWithOutVat <= 0) {
            ServiceLocator.MessageService.showError('Miktar ve İndirimsiz Birim Fiyat sıfırdan küçük olamaz!');
            event.cancel = true;
            return;
        }
        if (data.VatRate < 0) {
            ServiceLocator.MessageService.showError('KDV Oranı sıfırdan küçük olamaz!');
            event.cancel = true;
            return;
        }

        if (data.amount != null && data.PTSStockActionDetail.VatRate != null && data.UnitPriceWithOutVat != null) {

            let miktar: number = data.amount;
            let birimfiyati: number = data.UnitPriceWithOutVat;
            let toplam: number = miktar * birimfiyati;
            let kdvOrani: number = data.PTSStockActionDetail.VatRate;
            let kdvBirimFiyati: number = birimfiyati + (birimfiyati * (kdvOrani / 100));
            let kdvliToplamFiyat: number = miktar * kdvBirimFiyati;
            let indirimOrani: number = 0;
            let toplamSatirFiyat: number = 0;
            if ((data.PTSStockActionDetail.DiscountRate != null)) {
                indirimOrani = data.PTSStockActionDetail.DiscountRate;
            }
            let indirimliBirimFiyat: number = kdvBirimFiyati - (kdvBirimFiyati * (indirimOrani / 100));
            let indirimliToplamFiyat: number = miktar * indirimliBirimFiyat;
            let toplamindirimTutati: number = kdvliToplamFiyat - indirimliToplamFiyat;
            data.UnitPriceWithInVat = Math.Round(kdvBirimFiyati, 6);
            data.PTSStockActionDetail.UnitPrice = Math.Round(indirimliBirimFiyat, 6);
            data.PTSStockActionDetail.DiscountAmount = Math.Round(toplamindirimTutati, 6);
            data.VatRate = data.PTSStockActionDetail.VatRate;
            toplamSatirFiyat = indirimliBirimFiyat * miktar;
            data.price = Math.Round(toplamSatirFiyat, 6);
            data.UnitPrice = data.UnitPriceWithOutVat;
            data.PTSStockActionDetail.NotDiscountedUnitPrice = Math.Round(kdvliToplamFiyat, 6);
            data.PTSStockActionDetail.TotalDiscountAmount = Math.Round(toplamindirimTutati, 6);
            data.PTSStockActionDetail.TotalPriceNotDiscount = Math.Round(kdvBirimFiyati, 6);

            this._ChattelDocumentWithPurchase.PTSStockActionDetails.find(x=>x.ObjectID == data.PTSStockActionDetail.ObjectID).UnitPrice = data.UnitPrice;
            this._ChattelDocumentWithPurchase.PTSStockActionDetails.find(x=>x.ObjectID == data.PTSStockActionDetail.ObjectID).TotalDiscountAmount = Math.Round(toplamindirimTutati, 6);
            this._ChattelDocumentWithPurchase.PTSStockActionDetails.find(x=>x.ObjectID == data.PTSStockActionDetail.ObjectID).TotalPriceNotDiscount = Math.Round(kdvBirimFiyati, 6);
            this._ChattelDocumentWithPurchase.PTSStockActionDetails.find(x=>x.ObjectID == data.PTSStockActionDetail.ObjectID).VatRate = data.VatRate;


        }

        if (data.RetrievalYear == null) {
            let today = new Date();
            data.RetrievalYear = today.getFullYear();
            data.PTSStockActionDetail.RetrievalYear = today.getFullYear();
        }
        /*
                for (let detail of data.PTSStockActionDetail.StockActionDetails) {
                    let purchaseDetail: ChattelDocumentDetailWithPurchase = <ChattelDocumentDetailWithPurchase>detail;
                    purchaseDetail.UnitPriceWithOutVat = data.UnitPriceWithOutVat;
                    purchaseDetail.VatRate = data.PTSStockActionDetail.VatRate;
                    purchaseDetail.DiscountRate = data.DiscountRate;
                    purchaseDetail.RetrievalYear = data.RetrievalYear;
                    purchaseDetail.ProductionDate = data.ProductionDate;
                    purchaseDetail.DiscountAmount = data.PTSStockActionDetail.DiscountAmount;
                    purchaseDetail.UnitPrice= data.PTSStockActionDetail.UnitPrice;
                    this.MaterialRowUpdatePriceGridCellChanged(purchaseDetail);
                }
        */
        
        

        this.CalculateFormTotalPriceForITS();
    }

    public CalculateFormTotalPriceForITS() {
        let priceCalc: Array<number> = new Array<number>();
        let totalWithoutKDV: number = 0, totalWithKDV = 0, salesTotal = 0, totalPrice = 0;
        priceCalc.push(totalWithoutKDV);
        priceCalc.push(totalWithKDV);
        priceCalc.push(salesTotal);
        priceCalc.push(totalPrice);
        for (let data of this.chattelDocumentWithPurchaseFixDocumentFormViewModel.PTSMaterials) {
            if (data.UnitPriceWithOutVat === null || data.PTSStockActionDetail.DiscountAmount === null)
                continue;
            priceCalc[0] += data.amount * data.UnitPriceWithOutVat;
            priceCalc[1] += data.amount * (data.UnitPriceWithOutVat + (data.UnitPriceWithOutVat * data.PTSStockActionDetail.VatRate / 100));
            priceCalc[2] += data.PTSStockActionDetail.DiscountAmount;
        }
        priceCalc[3] = priceCalc[1] - priceCalc[2];
        this.txtNotKDV.Text = priceCalc[0].toFixed(2);
        this.txtWithKDV.Text = priceCalc[1].toFixed(2);
        this.txtDiscount.Text = priceCalc[2].toFixed(2);
        this.txtTotalPrice.Text = priceCalc[3].toFixed(2);
    }

    public ChattelDocumentDetailsWithPurchase_CellValueChangedEmitted(data: any) {
        /* if (data && this.ChattelDocumentDetailsWithPurchase_CellValueChanged && data.Row && data.Column) {
             this.ChattelDocumentDetailsWithPurchase.CurrentCell =
                 {
                     OwningRow: data.Row,
                     OwningColumn: data.Column
                 };
             this.ChattelDocumentDetailsWithPurchase_CellValueChanged(data.RowIndex, data.ColIndex);
         }*/
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.ConclusionNumber, "Text", this.__ttObject, "ConclusionNumber");
        redirectProperty(this.ConclusionDateTime, "Value", this.__ttObject, "ConclusionDateTime");
        redirectProperty(this.RegistrationAuctionNo, "Text", this.__ttObject, "RegistrationAuctionNo");
        redirectProperty(this.AuctionDate, "Value", this.__ttObject, "AuctionDate");
        redirectProperty(this.ExaminationReportDate, "Value", this.__ttObject, "ExaminationReportDate");
        redirectProperty(this.ExaminationReportNo, "Text", this.__ttObject, "ExaminationReportNo");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.MKYS_EMalzemeGrup, "Value", this.__ttObject, "MKYS_EMalzemeGrup");
        redirectProperty(this.MKYS_ETedarikTuru, "Value", this.__ttObject, "MKYS_ETedarikTuru");
        redirectProperty(this.MKYS_EAlimYontemi, "Value", this.__ttObject, "MKYS_EAlimYontemi");
        redirectProperty(this.GetWaybill, "Text", this.__ttObject, "Waybill");
        redirectProperty(this.WaybillDate, "Value", this.__ttObject, "WaybillDate");
    }

    public initFormControls(): void {
        this.PictureTabpage = new TTVisual.TTTabPage();
        this.PictureTabpage.DisplayIndex = 2;
        this.PictureTabpage.TabIndex = 2;
        this.PictureTabpage.Text = "Fatura";
        this.PictureTabpage.Name = "PictureTabpage";

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.invoicePictureControl = new TTVisual.TTPictureBoxControl();
        this.invoicePictureControl.Name = "invoicePictureControl";
        this.invoicePictureControl.TabIndex = 0;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.Waybill = new TTVisual.TTTextBox();
        this.Waybill.Name = "Waybill";
        this.Waybill.TabIndex = 145;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = "Teslim Eden";
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.RegistrationAuctionNo = new TTVisual.TTTextBox();
        this.RegistrationAuctionNo.Required = true;
        this.RegistrationAuctionNo.BackColor = "#FFE3C6";
        this.RegistrationAuctionNo.Name = "RegistrationAuctionNo";
        this.RegistrationAuctionNo.TabIndex = 139;

        this.MKYS_TeslimEden = new TTVisual.TTTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 118;

        this.txtTotalPrice = new TTVisual.TTTextBox();
        this.txtTotalPrice.BackColor = "#F0F0F0";
        this.txtTotalPrice.ReadOnly = true;
        this.txtTotalPrice.Name = "txtTotalPrice";
        this.txtTotalPrice.TabIndex = 134;

        this.MKYS_TeslimAlan = new TTVisual.TTTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.ExaminationReportNo = new TTVisual.TTTextBox();
        this.ExaminationReportNo.Name = "ExaminationReportNo";
        this.ExaminationReportNo.TabIndex = 130;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.ConclusionNumber = new TTVisual.TTTextBox();
        this.ConclusionNumber.Required = true;
        //this.ConclusionNumber.BackColor = "#F0F0F0";
        //this.ConclusionNumber.ReadOnly = true;
        this.ConclusionNumber.Name = "ConclusionNumber";
        this.ConclusionNumber.TabIndex = 5;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.labelWaybillDate = new TTVisual.TTLabel();
        this.labelWaybillDate.Text = "İrsaliye Tarihi";
        this.labelWaybillDate.Name = "labelWaybillDate";
        this.labelWaybillDate.TabIndex = 149;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = "Teslim Alan";
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.WaybillDate = new TTVisual.TTDateTimePicker();
        this.WaybillDate.Format = DateTimePickerFormat.Long;
        this.WaybillDate.Name = "WaybillDate";
        this.WaybillDate.TabIndex = 148;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = "İşlem Tarihi";
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.GetWaybill = new TTButtonTextBox();
        this.GetWaybill.ButtonText = 'B.G.';
        this.GetWaybill.Name = 'GetWaybill';
        this.GetWaybill.TabIndex = 147;
        this.GetWaybill.ButtonWidth = '10px';
        this.GetWaybill.Required = true;
        this.GetWaybill.BackColor = "#FFE3C6";

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.labelWaybill = new TTVisual.TTLabel();
        this.labelWaybill.Text = "İrsaliye Numarası";
        this.labelWaybill.Name = "labelWaybill";
        this.labelWaybill.TabIndex = 146;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = "İşlem No";
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 113;

        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = "Bütçe Türü";
        this.labelBudgetTypeDefinition.Name = "labelBudgetTypeDefinition";
        this.labelBudgetTypeDefinition.TabIndex = 144;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.Required = true;
        this.BudgetTypeDefinition.ListDefName = "BugdetTypeList";
        this.BudgetTypeDefinition.Name = "BudgetTypeDefinition";
        this.BudgetTypeDefinition.TabIndex = 143;
        this.BudgetTypeDefinition.Enabled = false;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = "İmzalar";
        this.SignTabpage.Name = "SignTabpage";

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = "Giriş Yapılan Depo";
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 142;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.AllowUserToAddRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;
        this.StockActionSignDetails.Height = "500px";

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 141;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = "İmza Tipi";
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.labelRegistrationAuctionNo = new TTVisual.TTLabel();
        this.labelRegistrationAuctionNo.Text = "İhale No";
        this.labelRegistrationAuctionNo.Name = "labelRegistrationAuctionNo";
        this.labelRegistrationAuctionNo.TabIndex = 140;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = "Personelin Adı, Soyadı";
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;

        this.labelAuctionDate = new TTVisual.TTLabel();
        this.labelAuctionDate.Text = "İhale  Tarihi";
        this.labelAuctionDate.Name = "labelAuctionDate";
        this.labelAuctionDate.TabIndex = 138;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = "Vekil";
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.AuctionDate = new TTVisual.TTDateTimePicker();
        this.AuctionDate.Required = true;
        this.AuctionDate.BackColor = "#FFE3C6";
        this.AuctionDate.Format = DateTimePickerFormat.Short;
        this.AuctionDate.Name = "AuctionDate";
        this.AuctionDate.TabIndex = 137;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Açıklama";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 111;

        this.labelExaminationReportNo = new TTVisual.TTLabel();
        this.labelExaminationReportNo.Text = "Muayene Sayısı";
        this.labelExaminationReportNo.Name = "labelExaminationReportNo";
        this.labelExaminationReportNo.TabIndex = 131;

        this.labelExaminationReportDate = new TTVisual.TTLabel();
        this.labelExaminationReportDate.Text = "Muayene Tarihi";
        this.labelExaminationReportDate.Name = "labelExaminationReportDate";
        this.labelExaminationReportDate.TabIndex = 129;

        this.ExaminationReportDate = new TTVisual.TTDateTimePicker();
        this.ExaminationReportDate.Format = DateTimePickerFormat.Long;
        this.ExaminationReportDate.Name = "ExaminationReportDate";
        this.ExaminationReportDate.TabIndex = 128;

        this.labelConclusionNumber = new TTVisual.TTLabel();
        this.labelConclusionNumber.Text = "Karar Numarası";
        this.labelConclusionNumber.Name = "labelConclusionNumber";
        this.labelConclusionNumber.TabIndex = 123;

        this.labelConclusionDateTime = new TTVisual.TTLabel();
        this.labelConclusionDateTime.Text = "Karar Tarihi";
        this.labelConclusionDateTime.Name = "labelConclusionDateTime";
        this.labelConclusionDateTime.TabIndex = 121;

        this.ConclusionDateTime = new TTVisual.TTDateTimePicker();
        //this.ConclusionDateTime.BackColor = "#F0F0F0";
        this.ConclusionDateTime.Format = DateTimePickerFormat.Short;
        //this.ConclusionDateTime.Enabled = false;
        this.ConclusionDateTime.Name = "ConclusionDateTime";
        this.ConclusionDateTime.TabIndex = 6;

        this.labelSupplier = new TTVisual.TTLabel();
        this.labelSupplier.Text = "Firma";
        this.labelSupplier.Name = "labelSupplier";
        this.labelSupplier.TabIndex = 119;

        this.Supplier = new TTVisual.TTObjectListBox();
        this.Supplier.ReadOnly = true;
        this.Supplier.ListDefName = "SupplierListDefinition";
        this.Supplier.Name = "Supplier";
        this.Supplier.TabIndex = 9;

        this.ChattelDocumentTabcontrol = new TTVisual.TTTabControl();
        this.ChattelDocumentTabcontrol.Name = "ChattelDocumentTabcontrol";
        this.ChattelDocumentTabcontrol.TabIndex = 10;

        this.ChattelDocumentDetailTabpage = new TTVisual.TTTabPage();
        this.ChattelDocumentDetailTabpage.DisplayIndex = 0;
        this.ChattelDocumentDetailTabpage.TabIndex = 0;
        this.ChattelDocumentDetailTabpage.Text = "Taşınır Malın";
        this.ChattelDocumentDetailTabpage.Name = "ChattelDocumentDetailTabpage";

        this.ChattelDocumentDetailsWithPurchase = new TTVisual.TTGrid();
        this.ChattelDocumentDetailsWithPurchase.Required = true;
        this.ChattelDocumentDetailsWithPurchase.Text = "Bütçe Türü";
        this.ChattelDocumentDetailsWithPurchase.Name = "ChattelDocumentDetailsWithPurchase";
        this.ChattelDocumentDetailsWithPurchase.TabIndex = 0;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = "Detay";
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = "Detay";
        this.Detail.Width = 80;

        this.MaterialStockActionDetailIn = new TTVisual.TTListBoxColumn();
        this.MaterialStockActionDetailIn.AllowMultiSelect = true;
        this.MaterialStockActionDetailIn.ListDefName = "MaterialListDefinition";
        this.MaterialStockActionDetailIn.DataMember = "Material";
        this.MaterialStockActionDetailIn.DisplayIndex = 1;
        this.MaterialStockActionDetailIn.HeaderText = "Malzeme Adı";
        this.MaterialStockActionDetailIn.Name = "MaterialStockActionDetailIn";
        this.MaterialStockActionDetailIn.Width = 500;

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

        this.AmountStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.AmountStockActionDetailIn.DataMember = "Amount";
        this.AmountStockActionDetailIn.Required = true;
        this.AmountStockActionDetailIn.Format = "N2";
        this.AmountStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountStockActionDetailIn.DisplayIndex = 4;
        this.AmountStockActionDetailIn.HeaderText = "Miktar";
        this.AmountStockActionDetailIn.Name = "AmountStockActionDetailIn";
        this.AmountStockActionDetailIn.Width = 75;

        this.UnitPriceStockActionDetailInWithOutVat = new TTVisual.TTTextBoxColumn();
        this.UnitPriceStockActionDetailInWithOutVat.DataMember = "UnitPriceWithOutVat";
        this.UnitPriceStockActionDetailInWithOutVat.Required = true;
        this.UnitPriceStockActionDetailInWithOutVat.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPriceStockActionDetailInWithOutVat.DisplayIndex = 5;
        this.UnitPriceStockActionDetailInWithOutVat.HeaderText = "Kdvsiz Fiyatı";
        this.UnitPriceStockActionDetailInWithOutVat.Name = "UnitPriceStockActionDetailInWithOutVat";
        this.UnitPriceStockActionDetailInWithOutVat.Width = 100;

        this.ValueAddedTax = new TTVisual.TTTextBoxColumn();
        this.ValueAddedTax.DataMember = "VatRate";
        this.ValueAddedTax.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ValueAddedTax.DisplayIndex = 6;
        this.ValueAddedTax.HeaderText = "KDV Oranı";
        this.ValueAddedTax.Name = "ValueAddedTax";
        this.ValueAddedTax.ReadOnly = true;
        this.ValueAddedTax.Width = 100;

        this.UnitePriceWithVatNoDiscount = new TTVisual.TTTextBoxColumn();
        this.UnitePriceWithVatNoDiscount.DataMember = "UnitPriceWithInVat";
        this.UnitePriceWithVatNoDiscount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitePriceWithVatNoDiscount.DisplayIndex = 7;
        this.UnitePriceWithVatNoDiscount.HeaderText = "Kdvli Fiyatı";
        this.UnitePriceWithVatNoDiscount.Name = "UnitePriceWithVatNoDiscount";
        this.UnitePriceWithVatNoDiscount.ReadOnly = true;
        this.UnitePriceWithVatNoDiscount.Width = 120;

        this.MKYS_IndirimOranı = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimOranı.DataMember = "DiscountRate";
        this.MKYS_IndirimOranı.DisplayIndex = 8;
        this.MKYS_IndirimOranı.HeaderText = "İndirim Oranı";
        this.MKYS_IndirimOranı.Name = "MKYS_IndirimOranı";
        this.MKYS_IndirimOranı.Width = 100;

        this.UnitPriceStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.UnitPriceStockActionDetailIn.DataMember = "UnitPrice";
        this.UnitPriceStockActionDetailIn.Format = "#,###.#########";
        this.UnitPriceStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPriceStockActionDetailIn.DisplayIndex = 9;
        this.UnitPriceStockActionDetailIn.HeaderText = "İndirimli Birim Fiyat";
        this.UnitPriceStockActionDetailIn.Name = "UnitPriceStockActionDetailIn";
        this.UnitPriceStockActionDetailIn.ReadOnly = true;
        this.UnitPriceStockActionDetailIn.Width = 75;

        this.MKYS_IndirimTutari = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimTutari.DataMember = "DiscountAmount";
        this.MKYS_IndirimTutari.DisplayIndex = 10;
        this.MKYS_IndirimTutari.HeaderText = "Indirim Tutarı";
        this.MKYS_IndirimTutari.Name = "MKYS_IndirimTutari";
        this.MKYS_IndirimTutari.ReadOnly = true;
        this.MKYS_IndirimTutari.Width = 100;

        this.TotalPrice = new TTVisual.TTTextBoxColumn();
        this.TotalPrice.DataMember = "Price";
        this.TotalPrice.DisplayIndex = 11;
        this.TotalPrice.HeaderText = "Toplam Tutar";
        this.TotalPrice.Name = "TotalPrice";
        this.TotalPrice.ReadOnly = true;
        this.TotalPrice.Width = 100;

        this.LotNo = new TTVisual.TTTextBoxColumn();
        this.LotNo.DataMember = "LotNo";
        this.LotNo.DisplayIndex = 12;
        this.LotNo.HeaderText = "Lot No.";
        this.LotNo.Name = "LotNo";
        this.LotNo.Width = 100;

        this.ExpirationDateStockActionDetailIn = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDateStockActionDetailIn.Format = DateTimePickerFormat.Custom;
        this.ExpirationDateStockActionDetailIn.CustomFormat = "MM/yyyy";
        this.ExpirationDateStockActionDetailIn.DataMember = "ExpirationDate";
        this.ExpirationDateStockActionDetailIn.DisplayIndex = 13;
        this.ExpirationDateStockActionDetailIn.HeaderText = "Son Kullanma Tarihi";
        this.ExpirationDateStockActionDetailIn.Name = "ExpirationDateStockActionDetailIn";
        this.ExpirationDateStockActionDetailIn.Width = 120;

        this.StockLevelTypeStockActionDetailIn = new TTVisual.TTListDefComboBoxColumn();
        this.StockLevelTypeStockActionDetailIn.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeStockActionDetailIn.DataMember = "StockLevelType";
        this.StockLevelTypeStockActionDetailIn.DisplayIndex = 14;
        this.StockLevelTypeStockActionDetailIn.HeaderText = "Malın Durumu";
        this.StockLevelTypeStockActionDetailIn.Name = "StockLevelTypeStockActionDetailIn";
        this.StockLevelTypeStockActionDetailIn.Visible = false;
        this.StockLevelTypeStockActionDetailIn.Width = 100;

        this.StatusStockActionDetailIn = new TTVisual.TTEnumComboBoxColumn();
        this.StatusStockActionDetailIn.DataTypeName = "StockActionDetailStatusEnum";
        this.StatusStockActionDetailIn.DataMember = "Status";
        this.StatusStockActionDetailIn.DisplayIndex = 15;
        this.StatusStockActionDetailIn.HeaderText = "Durum";
        this.StatusStockActionDetailIn.Name = "StatusStockActionDetailIn";
        this.StatusStockActionDetailIn.Visible = false;
        this.StatusStockActionDetailIn.Width = 80;

        this.MKYS_EdinimYili = new TTVisual.TTTextBoxColumn();
        this.MKYS_EdinimYili.DataMember = "RetrievalYear";
        this.MKYS_EdinimYili.DisplayIndex = 16;
        this.MKYS_EdinimYili.HeaderText = "Edinim Yılı";
        this.MKYS_EdinimYili.Name = "MKYS_EdinimYili";
        this.MKYS_EdinimYili.Width = 100;

        this.MKYS_UretimTarihi = new TTVisual.TTDateTimePickerColumn();
        this.MKYS_UretimTarihi.DataMember = "ProductionDate";
        this.MKYS_UretimTarihi.DisplayIndex = 17;
        this.MKYS_UretimTarihi.HeaderText = "Üretim Tarihi";
        this.MKYS_UretimTarihi.Name = "MKYS_UretimTarihi";
        this.MKYS_UretimTarihi.Width = 100;

        this.DistributionsTab = new TTVisual.TTTabPage();
        this.DistributionsTab.DisplayIndex = 1;
        this.DistributionsTab.TabIndex = 1;
        this.DistributionsTab.Text = "İstek Miktarları";
        this.DistributionsTab.Name = "DistributionsTab";

        this.DemandAmountsGrid = new TTVisual.TTGrid();
        this.DemandAmountsGrid.AllowUserToDeleteRows = false;
        this.DemandAmountsGrid.RowHeadersVisible = false;
        this.DemandAmountsGrid.Name = "DemandAmountsGrid";
        this.DemandAmountsGrid.TabIndex = 0;

        this.DA_Material = new TTVisual.TTListBoxColumn();
        this.DA_Material.ListDefName = "MaterialListDefinition";
        this.DA_Material.DisplayIndex = 0;
        this.DA_Material.HeaderText = "Malzeme";
        this.DA_Material.Name = "DA_Material";
        this.DA_Material.ReadOnly = true;
        this.DA_Material.Visible = false;
        this.DA_Material.Width = 350;

        this.DA_MasterResource = new TTVisual.TTListBoxColumn();
        this.DA_MasterResource.ListDefName = "ResourceListDefinition";
        this.DA_MasterResource.DataMember = "MasterResource";
        this.DA_MasterResource.DisplayIndex = 1;
        this.DA_MasterResource.HeaderText = "Birim";
        this.DA_MasterResource.Name = "DA_MasterResource";
        this.DA_MasterResource.ReadOnly = true;
        this.DA_MasterResource.Width = 350;

        this.DA_DemandAmount = new TTVisual.TTTextBoxColumn();
        this.DA_DemandAmount.DataMember = "Amount";
        this.DA_DemandAmount.DisplayIndex = 2;
        this.DA_DemandAmount.HeaderText = "İstek Miktarı";
        this.DA_DemandAmount.Name = "DA_DemandAmount";
        this.DA_DemandAmount.ReadOnly = true;
        this.DA_DemandAmount.Width = 100;

        this.DA_DistributionAmount = new TTVisual.TTTextBoxColumn();
        this.DA_DistributionAmount.DataMember = "DistributionAmount";
        this.DA_DistributionAmount.DisplayIndex = 3;
        this.DA_DistributionAmount.HeaderText = "Dağıtım Miktarı";
        this.DA_DistributionAmount.Name = "DA_DistributionAmount";
        this.DA_DistributionAmount.Visible = false;
        this.DA_DistributionAmount.Width = 100;

        this.txtDiscount = new TTVisual.TTTextBox();
        this.txtDiscount.BackColor = "#F0F0F0";
        this.txtDiscount.ReadOnly = true;
        this.txtDiscount.Name = "txtDiscount";
        this.txtDiscount.TabIndex = 124;

        this.txtWithKDV = new TTVisual.TTTextBox();
        this.txtWithKDV.BackColor = "#F0F0F0";
        this.txtWithKDV.ReadOnly = true;
        this.txtWithKDV.Name = "txtWithKDV";
        this.txtWithKDV.TabIndex = 134;

        this.txtNotKDV = new TTVisual.TTTextBox();
        this.txtNotKDV.BackColor = "#F0F0F0";
        this.txtNotKDV.ReadOnly = true;
        this.txtNotKDV.Name = "txtNotKDV";
        this.txtNotKDV.TabIndex = 124;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "Toplam İndirim Tutarı";
        this.ttlabel2.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 125;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Fatura  Tutarı";
        this.ttlabel3.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 125;

        this.MKYS_EAlimYontemi = new TTVisual.TTEnumComboBox();
        this.MKYS_EAlimYontemi.DataTypeName = "MKYS_EAlimYontemiEnum";
        this.MKYS_EAlimYontemi.Required = true;
        this.MKYS_EAlimYontemi.BackColor = "#FFE3C6";
        this.MKYS_EAlimYontemi.Name = "MKYS_EAlimYontemi";
        this.MKYS_EAlimYontemi.TabIndex = 19;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = "Malzeme Grup";
        this.labelMKYS_EMalzemeGrup.Name = "labelMKYS_EMalzemeGrup";
        this.labelMKYS_EMalzemeGrup.TabIndex = 16;

        this.MKYS_ETedarikTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_ETedarikTuru.DataTypeName = "MKYS_ETedarikTurEnum";
        this.MKYS_ETedarikTuru.Required = true;
        this.MKYS_ETedarikTuru.BackColor = "#F0F0F0";
        this.MKYS_ETedarikTuru.Enabled = false;
        this.MKYS_ETedarikTuru.Name = "MKYS_ETedarikTuru";
        this.MKYS_ETedarikTuru.TabIndex = 15;

        this.labelMKYS_ETedarikTuru = new TTVisual.TTLabel();
        this.labelMKYS_ETedarikTuru.Text = "Giriş Türü";
        this.labelMKYS_ETedarikTuru.Name = "labelMKYS_ETedarikTuru";
        this.labelMKYS_ETedarikTuru.TabIndex = 14;

        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = "MKYS_EMalzemeGrupEnum";
        this.MKYS_EMalzemeGrup.BackColor = "#F0F0F0";
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = "MKYS_EMalzemeGrup";
        this.MKYS_EMalzemeGrup.TabIndex = 17;

        this.labelMKYS_EAlimYontemi = new TTVisual.TTLabel();
        this.labelMKYS_EAlimYontemi.Text = "Alım Yöntemi";
        this.labelMKYS_EAlimYontemi.Name = "labelMKYS_EAlimYontemi";
        this.labelMKYS_EAlimYontemi.TabIndex = 18;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "KDV'siz Birim Fiyatlar Toplamı";
        this.ttlabel4.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 125;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "KDV'li Birim Fiyatlar Toplamı";
        this.ttlabel5.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 125;

        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.ChattelDocumentDetailsWithPurchaseColumns = [this.Detail, this.MaterialStockActionDetailIn, this.Barcode, this.DistributionType, this.AmountStockActionDetailIn, this.UnitPriceStockActionDetailInWithOutVat, this.ValueAddedTax, this.UnitePriceWithVatNoDiscount, this.MKYS_IndirimOranı, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimTutari, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn, this.StockLevelTypeStockActionDetailIn, this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi];
        this.DemandAmountsGridColumns = [this.DA_Material, this.DA_MasterResource, this.DA_DemandAmount, this.DA_DistributionAmount];
        this.PictureTabpage.Controls = [this.invoicePictureControl];
        this.DescriptionAndSignTabControl.Controls = [this.PictureTabpage, this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.ChattelDocumentTabcontrol.Controls = [this.ChattelDocumentDetailTabpage, this.DistributionsTab];
        this.ChattelDocumentDetailTabpage.Controls = [this.ChattelDocumentDetailsWithPurchase];
        this.DistributionsTab.Controls = [this.DemandAmountsGrid];
        this.Controls = [this.PictureTabpage, this.TTTeslimEdenButon, this.invoicePictureControl, this.TTTeslimAlanButon, this.Waybill, this.labelMKYS_TeslimEden, this.RegistrationAuctionNo, this.MKYS_TeslimEden, this.txtTotalPrice, this.MKYS_TeslimAlan, this.ExaminationReportNo, this.Description, this.ConclusionNumber, this.StockActionID, this.labelWaybillDate, this.labelMKYS_TeslimAlan, this.WaybillDate, this.labelTransactionDate, this.GetWaybill, this.TransactionDate, this.labelWaybill, this.labelStockActionID, this.labelBudgetTypeDefinition, this.DescriptionAndSignTabControl, this.BudgetTypeDefinition, this.SignTabpage, this.labelStore, this.StockActionSignDetails, this.Store, this.SignUserType, this.labelRegistrationAuctionNo, this.SignUser, this.labelAuctionDate, this.IsDeputy, this.AuctionDate, this.ttlabel1, this.labelExaminationReportNo, this.labelExaminationReportDate, this.ExaminationReportDate, this.labelConclusionNumber, this.labelConclusionDateTime, this.ConclusionDateTime, this.labelSupplier, this.Supplier, this.ChattelDocumentTabcontrol, this.ChattelDocumentDetailTabpage, this.ChattelDocumentDetailsWithPurchase, this.Detail, this.MaterialStockActionDetailIn, this.Barcode, this.DistributionType, this.AmountStockActionDetailIn, this.UnitPriceStockActionDetailInWithOutVat, this.ValueAddedTax, this.UnitePriceWithVatNoDiscount, this.MKYS_IndirimOranı, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimTutari, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn, this.StockLevelTypeStockActionDetailIn, this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi, this.DistributionsTab, this.DemandAmountsGrid, this.DA_Material, this.DA_MasterResource, this.DA_DemandAmount, this.DA_DistributionAmount, this.txtDiscount, this.txtWithKDV, this.txtNotKDV, this.ttlabel2, this.ttlabel3, this.MKYS_EAlimYontemi, this.labelMKYS_EMalzemeGrup, this.MKYS_ETedarikTuru, this.labelMKYS_ETedarikTuru, this.MKYS_EMalzemeGrup, this.labelMKYS_EAlimYontemi, this.ttlabel4, this.ttlabel5];

    }


}
