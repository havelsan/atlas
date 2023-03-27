//$0B63AD95
import { Component, ViewChild, OnInit, ApplicationRef, NgZone, ChangeDetectorRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ExtendExpDateInFormViewModel } from './ExtendExpDateInFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseExtendExpDateInForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Miad_Uzatim_Giris_Modulu/BaseExtendExpDateInForm";
import { ExtendExpDateIn, MainStoreDefinition, PharmacyStoreDefinition, SelectStoreUsageEnum, MKYS_EButceTurEnum, StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ExtendExpDateInDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { ExtendExpDateNewFormViewModel } from '../Miad_Uzatim_Modulu/ExtendExpDateNewFormViewModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';
import { StockActionService } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { ServiceLocator } from "Fw/Services/ServiceLocator";

@Component({
    selector: 'ExtendExpDateInForm',
    templateUrl: './ExtendExpDateInForm.html',
    providers: [MessageService]
})
export class ExtendExpDateInForm extends BaseExtendExpDateInForm implements OnInit {
    //public ExtendExpDateInDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public extendExpDateInFormViewModel: ExtendExpDateInFormViewModel = new ExtendExpDateInFormViewModel();
    public get _ExtendExpDateIn(): ExtendExpDateIn {
        return this._TTObject as ExtendExpDateIn;
    }
    private ExtendExpDateInForm_DocumentUrl: string = '/api/ExtendExpDateInService/ExtendExpDateInForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone,
        private changeDetectorRef: ChangeDetectorRef, private objectContextService: ObjectContextService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ExtendExpDateInForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected async ClientSidePreScript() {
        super.ClientSidePreScript();

    }

    inputStore: Store;
    public setInputParam(value: Store) {
        if (value != null) {
            if (value.ObjectDefID.toString() === MainStoreDefinition.ObjectDefID.id || value.ObjectDefID.toString() === PharmacyStoreDefinition.ObjectDefID.id)
                this.inputStore = value;
        }
    }


    protected async PreScript() {
        super.PreScript();

        let isApproved: string = (await SystemParameterService.GetParameterValue('STOCKACTIONSTATENEWTOCOMPLETED', 'TRUE'));
        if (isApproved === 'TRUE') {
            this.DropStateButton(ExtendExpDateIn.ExtendExpDateInStates.Approved);
        } else {
            this.DropStateButton(ExtendExpDateIn.ExtendExpDateInStates.Completed);
        }

        if (this._ExtendExpDateIn.Store == null) {
            this._ExtendExpDateIn.Store = this.inputStore;
            await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
        }

        if ((<MainStoreDefinition>this._ExtendExpDateIn.Store).MKYS_ButceTuru != null) {
            if ((<MainStoreDefinition>this._ExtendExpDateIn.Store).MKYS_ButceTuru === MKYS_EButceTurEnum.donerSermaye) {
                let budgetObj: Guid = new Guid("3511171d-06ae-4434-ad44-3579ee616ecb");
                let budgetTypeDef: any = await this.objectContextService.getObject(budgetObj, BudgetTypeDefinition.ObjectDefID);
                this._ExtendExpDateIn.BudgetTypeDefinition = budgetTypeDef;
            }
            if ((<MainStoreDefinition>this._ExtendExpDateIn.Store).MKYS_ButceTuru === MKYS_EButceTurEnum.genelButce) {
                let budgetObj: Guid = new Guid("57c410cc-afea-487a-8327-76e91a696a02");
                let budgetTypeDef: any = await this.objectContextService.getObject(budgetObj, BudgetTypeDefinition.ObjectDefID);
                this._ExtendExpDateIn.BudgetTypeDefinition = budgetTypeDef;
            }
            this.BudgetTypeDefinition.ReadOnly = true;
        }
    }

    public async getOuts() {
        if (this._ExtendExpDateIn.Supplier != null) {
            let inDetail: Array<ExtendExpDateInDetail> = await StockActionService.GetExtendExpDateIn(this._ExtendExpDateIn.Supplier.ObjectID.toString(), this._ExtendExpDateIn.ExtendExpDateOutID);
            if (inDetail != null && inDetail.length > 0) {
                for (let detail of inDetail) {
                    let guidMaterial: Guid = new Guid(detail["Material"].toString());
                    detail.Material = await this.objectContextService.getObject<Material>(guidMaterial, Material.ObjectDefID);

                    let stockCardObj: Guid = <any>detail.Material['StockCard'];
                    let stockCard: StockCard = await this.objectContextService.getObject(stockCardObj, StockCard.ObjectDefID);
                    detail.Material.StockCard = stockCard;

                    //this.extendExpDateInFormViewModel.ExtendExpDateInDetailsGridList.push(detail);
                    this.extendExpDateInFormViewModel._ExtendExpDateIn.ExtendExpDateInDetails.push(detail);
                }
            }
        } else {
            ServiceLocator.MessageService.showError("Tedarikçi seçmeden getir yapamazsınız");
        }
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ExtendExpDateIn();
        this.extendExpDateInFormViewModel = new ExtendExpDateInFormViewModel();
        this._ViewModel = this.extendExpDateInFormViewModel;
        this.extendExpDateInFormViewModel._ExtendExpDateIn = this._TTObject as ExtendExpDateIn;
        this.extendExpDateInFormViewModel._ExtendExpDateIn.ExtendExpDateInDetails = new Array<ExtendExpDateInDetail>();
        this.extendExpDateInFormViewModel._ExtendExpDateIn.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.extendExpDateInFormViewModel._ExtendExpDateIn.Store = new Store();
        this.extendExpDateInFormViewModel._ExtendExpDateIn.Supplier = new Supplier();
        this.extendExpDateInFormViewModel._ExtendExpDateIn.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.extendExpDateInFormViewModel = this._ViewModel as ExtendExpDateInFormViewModel;
        that._TTObject = this.extendExpDateInFormViewModel._ExtendExpDateIn;
        if (this.extendExpDateInFormViewModel == null)
            this.extendExpDateInFormViewModel = new ExtendExpDateInFormViewModel();
        if (this.extendExpDateInFormViewModel._ExtendExpDateIn == null)
            this.extendExpDateInFormViewModel._ExtendExpDateIn = new ExtendExpDateIn();
        that.extendExpDateInFormViewModel._ExtendExpDateIn.ExtendExpDateInDetails = that.extendExpDateInFormViewModel.ExtendExpDateInDetailsGridList;
        for (let detailItem of that.extendExpDateInFormViewModel.ExtendExpDateInDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.extendExpDateInFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
        }

        let budgetTypeDefinitionObjectID = that.extendExpDateInFormViewModel._ExtendExpDateIn["BudgetTypeDefinition"];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === "string")) {
            let budgetTypeDefinition = that.extendExpDateInFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.extendExpDateInFormViewModel._ExtendExpDateIn.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }

        let storeObjectID = that.extendExpDateInFormViewModel._ExtendExpDateIn["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.extendExpDateInFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.extendExpDateInFormViewModel._ExtendExpDateIn.Store = store;
            }
        }

        let supplierObjectID = that.extendExpDateInFormViewModel._ExtendExpDateIn["Supplier"];
        if (supplierObjectID != null && (typeof supplierObjectID === "string")) {
            let supplier = that.extendExpDateInFormViewModel.Suppliers.find(o => o.ObjectID.toString() === supplierObjectID.toString());
            if (supplier) {
                that.extendExpDateInFormViewModel._ExtendExpDateIn.Supplier = supplier;
            }
        }

        that.extendExpDateInFormViewModel._ExtendExpDateIn.StockActionSignDetails = that.extendExpDateInFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.extendExpDateInFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === "string")) {
                let signUser = that.extendExpDateInFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }

    async ngOnInit() {
        await this.load();
        let that = this;
        await this.load(ExtendExpDateNewFormViewModel);
        if (this._ExtendExpDateIn.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ExtendExpDateIn.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M21380", "Miad Uzatım Giriş ( Yeni )");
        this.changeDetectorRef.detectChanges();
    }

    public onBudgetTypeDefinitionChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.BudgetTypeDefinition != event) {
            this._ExtendExpDateIn.BudgetTypeDefinition = event;
        }
    }

    public onDescriptionChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.Description != event) {
            this._ExtendExpDateIn.Description = event;
        }
    }

    public onExtendExpDateOutIDChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.ExtendExpDateOutID != event) {
            this._ExtendExpDateIn.ExtendExpDateOutID = event;
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.MKYS_TeslimAlan != event) {
            this._ExtendExpDateIn.MKYS_TeslimAlan = event;
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.MKYS_TeslimEden != event) {
            this._ExtendExpDateIn.MKYS_TeslimEden = event;
        }
    }

    public onStockActionIDChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.StockActionID != event) {
            this._ExtendExpDateIn.StockActionID = event;
        }
    }

    public onStoreChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.Store != event) {
            this._ExtendExpDateIn.Store = event;
        }
    }

    public onSupplierChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.Supplier != event) {
            this._ExtendExpDateIn.Supplier = event;
        }
    }

    public onTransactionDateChanged(event): void {
        if (this._ExtendExpDateIn != null && this._ExtendExpDateIn.TransactionDate != event) {
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

        //this.ExtendExpDateInDetailsColumns = [this.MaterialExtendExpDateInDetail, this.AmountExtendExpDateInDetail, this.UnitPriceExtendExpDateInDetail, this.VatRateExtendExpDateInDetail, this.ExpirationDateExtendExpDateInDetail, this.LotNoExtendExpDateInDetail, this.StatusExtendExpDateInDetail];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.tttabcontrol1.Controls = [this.tttabpage1];
        this.tttabpage1.Controls = [this.ExtendExpDateInDetails];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.tttabcontrol1, this.TTTeslimEdenButon, this.tttabpage1, this.TTTeslimAlanButon, this.ExtendExpDateInDetails,
        this.labelMKYS_TeslimEden, this.MaterialExtendExpDateInDetail, this.MKYS_TeslimEden, this.AmountExtendExpDateInDetail,
        this.MKYS_TeslimAlan, this.UnitPriceExtendExpDateInDetail, this.Description, this.VatRateExtendExpDateInDetail, this.StockActionID,
        this.ExpirationDateExtendExpDateInDetail, this.labelMKYS_TeslimAlan, this.LotNoExtendExpDateInDetail, this.labelTransactionDate,
        this.StatusExtendExpDateInDetail, this.TransactionDate, this.ExtendExpDateOutID, this.labelStockActionID, this.labelBudgetTypeDefinition, this.DescriptionAndSignTabControl, this.BudgetTypeDefinition, this.SignTabpage, this.labelStore, this.StockActionSignDetails, this.Store, this.SignUserType, this.labelSupplier, this.SignUser, this.Supplier, this.IsDeputy, this.labelExtendExpDateOutID, this.ttlabel1];

    }


}
