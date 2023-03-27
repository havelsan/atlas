//$024A31D0
import { Component, OnInit, NgZone, ChangeDetectorRef } from '@angular/core';
import { ExtendExpDateOutFormViewModel, TempOuttableLot } from './ExtendExpDateOutFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseExtendExpDateOutForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Miad_Uzatim_Cikis_Modulu/BaseExtendExpDateOutForm";
import { ExtendExpDateOut, MainStoreDefinition, PharmacyStoreDefinition, SelectStoreUsageEnum, StockLevelTypeEnum, StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ExtendExpDateOutDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { StockLevelTypeService } from 'app/NebulaClient/Services/ObjectService/StockLevelTypeService';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { StockLevelService } from 'app/NebulaClient/Services/ObjectService/StockLevelService';
import { OutableStockTransaction_Response, StockActionService } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DatePipe } from '@angular/common';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';

@Component({
    selector: 'ExtendExpDateOutForm',
    templateUrl: './ExtendExpDateOutForm.html',
    providers: [MessageService]
})
export class ExtendExpDateOutForm extends BaseExtendExpDateOutForm implements OnInit {
    public ExtendExpDateOutDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public extendExpDateOutFormViewModel: ExtendExpDateOutFormViewModel = new ExtendExpDateOutFormViewModel();
    public get _ExtendExpDateOut(): ExtendExpDateOut {
        return this._TTObject as ExtendExpDateOut;
    }
    private ExtendExpDateOutForm_DocumentUrl: string = '/api/ExtendExpDateOutService/ExtendExpDateOutForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone,
        private changeDetectorRef: ChangeDetectorRef) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ExtendExpDateOutForm_DocumentUrl;
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
            this.DropStateButton(ExtendExpDateOut.ExtendExpDateOutStates.Approved);
        } else {
            this.DropStateButton(ExtendExpDateOut.ExtendExpDateOutStates.Completed);
        }

        if (this._ExtendExpDateOut.Store == null) {
            this._ExtendExpDateOut.Store = this.inputStore;
            await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
        }

        this.MaterialExtendExpDateOutDetail.ListFilterExpression = "STOCKS.STORE= '" + this._ExtendExpDateOut.Store.ObjectID + "' AND STOCKS.INHELD > 0"; // + "AND STOCKCARD.STOCKMETHOD = 1";
        if (this._ExtendExpDateOut.Store instanceof MainStoreDefinition) {
            if ((<MainStoreDefinition>this._ExtendExpDateOut.Store).GoodsAccountant != null) {
                this._ExtendExpDateOut.MKYS_TeslimEden = (<MainStoreDefinition>this._ExtendExpDateOut.Store).GoodsAccountant.Name;
                this._ExtendExpDateOut.MKYS_TeslimEdenObjID = (<MainStoreDefinition>this._ExtendExpDateOut.Store).GoodsAccountant.ObjectID;
            }
            if ((<MainStoreDefinition>this._ExtendExpDateOut.DestinationStore).GoodsAccountant != null) {
                this._ExtendExpDateOut.MKYS_TeslimAlan = (<MainStoreDefinition>this._ExtendExpDateOut.DestinationStore).GoodsAccountant.Name;
                this._ExtendExpDateOut.MKYS_TeslimAlanObjID = (<MainStoreDefinition>this._ExtendExpDateOut.DestinationStore).GoodsAccountant.ObjectID;
            }
        }


    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ExtendExpDateOut();
        this.extendExpDateOutFormViewModel = new ExtendExpDateOutFormViewModel();
        this._ViewModel = this.extendExpDateOutFormViewModel;
        this.extendExpDateOutFormViewModel._ExtendExpDateOut = this._TTObject as ExtendExpDateOut;
        this.extendExpDateOutFormViewModel._ExtendExpDateOut.Store = new Store();
        this.extendExpDateOutFormViewModel._ExtendExpDateOut.Supplier = new Supplier();
        this.extendExpDateOutFormViewModel._ExtendExpDateOut.ExtendExpDateOutDetails = new Array<ExtendExpDateOutDetail>();
        this.extendExpDateOutFormViewModel._ExtendExpDateOut.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.extendExpDateOutFormViewModel = this._ViewModel as ExtendExpDateOutFormViewModel;
        that._TTObject = this.extendExpDateOutFormViewModel._ExtendExpDateOut;
        if (this.extendExpDateOutFormViewModel == null)
            this.extendExpDateOutFormViewModel = new ExtendExpDateOutFormViewModel();
        if (this.extendExpDateOutFormViewModel._ExtendExpDateOut == null)
            this.extendExpDateOutFormViewModel._ExtendExpDateOut = new ExtendExpDateOut();
        let storeObjectID = that.extendExpDateOutFormViewModel._ExtendExpDateOut["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.extendExpDateOutFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.extendExpDateOutFormViewModel._ExtendExpDateOut.Store = store;
            }
        }


        let supplierObjectID = that.extendExpDateOutFormViewModel._ExtendExpDateOut["Supplier"];
        if (supplierObjectID != null && (typeof supplierObjectID === "string")) {
            let supplier = that.extendExpDateOutFormViewModel.Suppliers.find(o => o.ObjectID.toString() === supplierObjectID.toString());
            if (supplier) {
                that.extendExpDateOutFormViewModel._ExtendExpDateOut.Supplier = supplier;
            }
        }

        that.extendExpDateOutFormViewModel._ExtendExpDateOut.ExtendExpDateOutDetails = that.extendExpDateOutFormViewModel.ExtendExpDateOutDetailsGridList;
        for (let detailItem of that.extendExpDateOutFormViewModel.ExtendExpDateOutDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.extendExpDateOutFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }

        }

        that.extendExpDateOutFormViewModel._ExtendExpDateOut.StockActionSignDetails = that.extendExpDateOutFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.extendExpDateOutFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === "string")) {
                let signUser = that.extendExpDateOutFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }

        }


    }

    async ngOnInit() {
        await this.load(ExtendExpDateOutFormViewModel);
        this.FormCaption = i18n("M19019", "Miad Uzatım Çıkış ( Yeni )");
        this.changeDetectorRef.detectChanges();
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
    public async onMaterialSelectionChange(event: any) {
        if (this.stockLeveltypeArray.length === 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value === StockLevelTypeEnum.New);
        if (this.selectedMaterial == null)
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        else if (!this._ExtendExpDateOut.ExtendExpDateOutDetails.find(x => x.Material.ObjectID === this.selectedMaterial.ObjectID && x.EntityState !== EntityStateEnum.Deleted)) {
            let extendExpDateOutDetail: ExtendExpDateOutDetail = new ExtendExpDateOutDetail();
            extendExpDateOutDetail.Material = this.selectedMaterial;
            extendExpDateOutDetail.StockLevelType = this.selectedStockLevelType;
            extendExpDateOutDetail.Status = StockActionDetailStatusEnum.New;
            extendExpDateOutDetail.IsNew = true;

            if (this.selectedStockLevelType != null) {
                let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(this.selectedMaterial.ObjectID, this._ExtendExpDateOut.Store.ObjectID, this.selectedStockLevelType.ObjectID);
                extendExpDateOutDetail.StoreStock = stockInheld;
            }


            let outableStockTransactions: Array<OutableStockTransaction_Response> = await StockActionService.GetOutableStockTransactions(this._ExtendExpDateOut.Store.ObjectID.toString(), extendExpDateOutDetail.Material.ObjectID.toString());
            let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();

            let count: number = 0;
            for (let outableStockTransaction of outableStockTransactions) {
                let outtableLot: TempOuttableLot = new TempOuttableLot();
                outtableLot.LotNo = outableStockTransaction.LotNo;
                if (outableStockTransaction.ExpirationDate == null)
                    outtableLot.ExpirationDate = Date.MinValue;
                else outtableLot.ExpirationDate = outableStockTransaction.ExpirationDate;
                outtableLot.RestAmount = outableStockTransaction.Restamount;
                outtableLot.Amount = outableStockTransaction.Restamount;
                outtableLot.isUse = false;
                //outtableLot.StockActionDetailOutID = extendExpirationDateDetail.ObjectID.toString();
                let datePipe = new DatePipe("en-US");
                multiSelectForm.AddMSItem("MIAD : " + datePipe.transform(outtableLot.ExpirationDate, "M/yyyy") + " || " + i18n("M19031", "Miktar : ") + outtableLot.RestAmount.toString(), count.toString(), outtableLot);
                count++;
            }

            let mlotKey: string = await multiSelectForm.GetMSItem(null, i18n("M22058", "Son Kullanma Tarihi / Mevcut Miktar"), true);
            if (multiSelectForm.MSSelectedItemObject != null) {
                let lotSelected: TempOuttableLot = multiSelectForm.MSSelectedItemObject as TempOuttableLot;
                //extendExpirationDateDetail = <Date>lotSelected.ExpirationDate;
                //extendExpirationDateDetail.SelectedLotRestAmount = lotSelected.RestAmount.Value;
                extendExpDateOutDetail.Amount = lotSelected.RestAmount.Value;
                extendExpDateOutDetail.OutExpirationDate = <Date>lotSelected.ExpirationDate;
                //lotSelected.StockActionDetailOut = extendExpirationDateDetail;
                lotSelected.isUse = true;

                if (this.extendExpDateOutFormViewModel.TempOuttableLots == null)
                    this.extendExpDateOutFormViewModel.TempOuttableLots = new Array<TempOuttableLot>();
                this.extendExpDateOutFormViewModel.TempOuttableLots.push(lotSelected);
            }
            // let endOfMonth: Date = new Date(extendExpirationDateDetail.NewDateForExpiration.getFullYear(), extendExpirationDateDetail.NewDateForExpiration.getMonth() + 1, 1).AddDays(-1);
            // extendExpirationDateDetail.NewDateForExpiration = endOfMonth;

            this._ExtendExpDateOut.ExtendExpDateOutDetails.push(extendExpDateOutDetail);
        }
        else
            ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
    }

    public async ExtendExpirationDateDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.ExtendExpirationDateDetails_CellValueChanged(data, rowIndex, columnIndex);

    }

    onSelectionChange() {
    }
    onRowInsertting() {
    }
    onCellContentClicked() {
    }
    async initNewRow() {
    }
    onRowInserting() {
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

        //this.ExtendExpDateOutDetailsColumns = [this.MaterialExtendExpDateOutDetail, this.OutExpirationDateExtendExpDateOutDetail, this.AmountExtendExpDateOutDetail, this.StatusExtendExpDateOutDetail];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.tttabcontrol1.Controls = [this.tttabpage1];
        this.tttabpage1.Controls = [this.ExtendExpDateOutDetails];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.labelStore, this.TTTeslimEdenButon, this.Store, this.TTTeslimAlanButon, this.labelSupplier,
            this.labelMKYS_TeslimEden, this.Supplier, this.MKYS_TeslimEden, this.tttabcontrol1, this.MKYS_TeslimAlan, this.tttabpage1,
            this.Description, this.ExtendExpDateOutDetails, this.StockActionID, this.MaterialExtendExpDateOutDetail, this.labelMKYS_TeslimAlan, this.OutExpirationDateExtendExpDateOutDetail, this.labelTransactionDate, this.AmountExtendExpDateOutDetail, this.TransactionDate, this.StatusExtendExpDateOutDetail, this.labelStockActionID, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.ttlabel1];

    }


}
