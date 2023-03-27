//$CEDFC4C7
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { BaseExtendExpDateInFormViewModel } from './BaseExtendExpDateInFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseChattelDocumentForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentForm";
import { ExtendExpDateIn, MKYS_EAlimYontemiEnum, MKYS_ETedarikTurEnum, MKYS_ECikisIslemTuruEnum, MKYS_ECikisStokHareketTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ExtendExpDateInDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { DxDataGridComponent } from 'devextreme-angular';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';
import { ExtendExpDateInCompForm } from './ExtendExpDateInCompForm';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';

@Component({
    selector: 'BaseExtendExpDateInForm',
    templateUrl: './BaseExtendExpDateInForm.html',
    providers: [MessageService]
})
export class BaseExtendExpDateInForm extends BaseChattelDocumentForm implements OnInit {
    AmountExtendExpDateInDetail: TTVisual.ITTTextBoxColumn;
    BudgetTypeDefinition: TTVisual.ITTObjectListBox;
    ExpirationDateExtendExpDateInDetail: TTVisual.ITTDateTimePickerColumn;
    ExtendExpDateInDetails: TTVisual.ITTGrid;
    ExtendExpDateOutID: TTVisual.ITTTextBox;
    labelBudgetTypeDefinition: TTVisual.ITTLabel;
    labelExtendExpDateOutID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelSupplier: TTVisual.ITTLabel;
    LotNoExtendExpDateInDetail: TTVisual.ITTTextBoxColumn;
    MaterialExtendExpDateInDetail: TTVisual.ITTListBoxColumn;
    StatusExtendExpDateInDetail: TTVisual.ITTEnumComboBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    Supplier: TTVisual.ITTObjectListBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    UnitPriceExtendExpDateInDetail: TTVisual.ITTTextBoxColumn;
    VatRateExtendExpDateInDetail: TTVisual.ITTTextBoxColumn;
    //public ExtendExpDateInDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public expirationMinDate: Date = new Date(Date.now());
    public baseExtendExpDateInFormViewModel: BaseExtendExpDateInFormViewModel = new BaseExtendExpDateInFormViewModel();
    public get _ExtendExpDateIn(): ExtendExpDateIn {
        return this._TTObject as ExtendExpDateIn;
    }

    public ExtendExpDateInDetailsColumns = [
        {
            caption: ' ',
            dataField: 'ObjectID',
            cellTemplate: 'buttonCellTemplate',
            visible: false,
            allowEditing: false,
           // width: 'auto'
        },
        {
            caption: i18n("M18550", "Malzeme Adı"),
            dataField: 'Material.Name',
            allowEditing: false,
          //  width: 'auto'
        },
        {
            caption: 'Taşınır Kodu',
            dataField: 'Material.StockCard.NATOStockNO',
            allowEditing: false,
            width: 120
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false,
         //   width: 'auto'
        },
        {
            caption: i18n("M19908", "Ölçü Birimi"),
            dataField: 'Material.DistributionTypeName',
            allowEditing: false,
        //    width: 'auto'
        },
        {
            caption: i18n("M19030", "Miktar"),
            dataField: 'Amount',
            dataType: 'number',
         //   width: 'auto'
        },
        {
            caption: i18n("M17457", "KDV Oranı"),
            dataField: 'VatRate',
            dataType: 'number',
        //    width: 'auto'
        },
        {
            caption: i18n("M16504", "İndirimli Birim Fiyat"),
            dataField: 'UnitPrice',
            dataType: 'number',
            allowEditing: false,
          //  width: 'auto'
        },
        {
            caption: 'Lot No.',
            dataField: 'LotNo',
          //  width: 'auto'
        },
        {
            caption: 'Seri No.',
            dataField: 'SerialNo',
          //  width: 'auto'
        },
        {
            caption: i18n("M22057", "Son Kullanma Tarihi"),
            dataField: 'ExpirationDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            editorOptions: {
                min: this.expirationMinDate,
            }
        },
    ];
    private BaseExtendExpDateInForm_DocumentUrl: string = '/api/ExtendExpDateInService/BaseExtendExpDateInForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseExtendExpDateInForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    @ViewChild('materialGrid') materialGrid: DxDataGridComponent;
    public async stateChange(event: FormSaveInfo) {
        this.materialGrid.instance.closeEditCell();
        this.materialGrid.instance.saveEditData();
        await super.setState(event.transDef, event);
    }

    public async onSaveButtonClick(event: FormSaveInfo) {
        this.materialGrid.instance.closeEditCell();
        this.materialGrid.instance.saveEditData();
        await super.saveForm(event);
    }

    // ***** Method declarations start *****
    public async onMaterialSelectionChange(event: any) {

    }

    public MaterialGridCellChanged(event: any) {

    }

    public onMaterialGridRowRemoving(event: any) {
        if (event.key.ObjectID != null && this._ExtendExpDateIn.CurrentStateDefID === ExtendExpDateIn.ExtendExpDateInStates.New) {
            this._ExtendExpDateIn.ExtendExpDateInDetails.find(x => x.ObjectID === event.data.ObjectID).EntityState = EntityStateEnum.Deleted;
            this.materialGrid.instance.filter(['EntityState', '<>', 1]);
            event.cancel = true;
        }
    }

    public onMaterialGridRowRemoved(event: any) {
    }

    public onMaterialGridRowUpdated(event: any) {
        //console.log(event);
        this.MaterialGridCellChanged(event);
    }

    protected async PreScript() {
        super.PreScript();

        this._ExtendExpDateIn.MKYS_EAlimYontemi = MKYS_EAlimYontemiEnum.bos;
        this.baseExtendExpDateInFormViewModel._ExtendExpDateIn.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.MiadUzatimi;
    }

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        this._ExtendExpDateIn.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.MiadUzatimi;
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ExtendExpDateIn();
        this.baseExtendExpDateInFormViewModel = new BaseExtendExpDateInFormViewModel();
        this._ViewModel = this.baseExtendExpDateInFormViewModel;
        this.baseExtendExpDateInFormViewModel._ExtendExpDateIn = this._TTObject as ExtendExpDateIn;
        this.baseExtendExpDateInFormViewModel._ExtendExpDateIn.ExtendExpDateInDetails = new Array<ExtendExpDateInDetail>();
        this.baseExtendExpDateInFormViewModel._ExtendExpDateIn.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.baseExtendExpDateInFormViewModel._ExtendExpDateIn.Store = new Store();
        this.baseExtendExpDateInFormViewModel._ExtendExpDateIn.Supplier = new Supplier();
        this.baseExtendExpDateInFormViewModel._ExtendExpDateIn.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.baseExtendExpDateInFormViewModel = this._ViewModel as BaseExtendExpDateInFormViewModel;
        that._TTObject = this.baseExtendExpDateInFormViewModel._ExtendExpDateIn;
        if (this.baseExtendExpDateInFormViewModel == null)
            this.baseExtendExpDateInFormViewModel = new BaseExtendExpDateInFormViewModel();
        if (this.baseExtendExpDateInFormViewModel._ExtendExpDateIn == null)
            this.baseExtendExpDateInFormViewModel._ExtendExpDateIn = new ExtendExpDateIn();
        that.baseExtendExpDateInFormViewModel._ExtendExpDateIn.ExtendExpDateInDetails = that.baseExtendExpDateInFormViewModel.ExtendExpDateInDetailsGridList;
        for (let detailItem of that.baseExtendExpDateInFormViewModel.ExtendExpDateInDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.baseExtendExpDateInFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
        }

        let budgetTypeDefinitionObjectID = that.baseExtendExpDateInFormViewModel._ExtendExpDateIn["BudgetTypeDefinition"];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === "string")) {
            let budgetTypeDefinition = that.baseExtendExpDateInFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.baseExtendExpDateInFormViewModel._ExtendExpDateIn.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }

        let storeObjectID = that.baseExtendExpDateInFormViewModel._ExtendExpDateIn["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.baseExtendExpDateInFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.baseExtendExpDateInFormViewModel._ExtendExpDateIn.Store = store;
            }
        }

        let supplierObjectID = that.baseExtendExpDateInFormViewModel._ExtendExpDateIn["Supplier"];
        if (supplierObjectID != null && (typeof supplierObjectID === "string")) {
            let supplier = that.baseExtendExpDateInFormViewModel.Suppliers.find(o => o.ObjectID.toString() === supplierObjectID.toString());
            if (supplier) {
                that.baseExtendExpDateInFormViewModel._ExtendExpDateIn.Supplier = supplier;
            }
        }

        that.baseExtendExpDateInFormViewModel._ExtendExpDateIn.StockActionSignDetails = that.baseExtendExpDateInFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.baseExtendExpDateInFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === "string")) {
                let signUser = that.baseExtendExpDateInFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }

    async ngOnInit() {
        await this.load();
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
        this.BudgetTypeDefinition.ListDefName = "BudgetListDef";
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
        this.Controls = [this.tttabcontrol1, this.TTTeslimEdenButon, this.tttabpage1, this.TTTeslimAlanButon, this.ExtendExpDateInDetails, this.labelMKYS_TeslimEden, this.MaterialExtendExpDateInDetail, this.MKYS_TeslimEden, this.AmountExtendExpDateInDetail, this.MKYS_TeslimAlan, this.UnitPriceExtendExpDateInDetail, this.Description, this.VatRateExtendExpDateInDetail, this.StockActionID, this.ExpirationDateExtendExpDateInDetail, this.labelMKYS_TeslimAlan, this.LotNoExtendExpDateInDetail, this.labelTransactionDate, this.StatusExtendExpDateInDetail, this.TransactionDate, this.ExtendExpDateOutID, this.labelStockActionID, this.labelBudgetTypeDefinition, this.DescriptionAndSignTabControl, this.BudgetTypeDefinition, this.SignTabpage, this.labelStore, this.StockActionSignDetails, this.Store, this.SignUserType, this.labelSupplier, this.SignUser, this.Supplier, this.IsDeputy, this.labelExtendExpDateOutID, this.ttlabel1];

    }


}
