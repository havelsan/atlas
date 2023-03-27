//$8380F0C5
import { Component, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { ExtendExpDateNewFormViewModel, TempOuttableLot } from './ExtendExpDateNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseExtendExpDateForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Miad_Uzatim_Modulu/BaseExtendExpDateForm";
import { ExtendExpirationDate, StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { MainStoreDefinition, PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SelectStoreUsageEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { ExtendExpirationDateDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { StockLevelTypeService } from "ObjectClassService/StockLevelTypeService";
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionService, OutableStockTransaction_Response } from "NebulaClient/Services/ObjectService/StockActionService";
import { DatePipe } from '@angular/common';
import { StockLevelService } from "ObjectClassService/StockLevelService";

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';

@Component({
    selector: 'ExtendExpDateNewForm',
    templateUrl: './ExtendExpDateNewForm.html',
    providers: [MessageService]
})
export class ExtendExpDateNewForm extends BaseExtendExpDateForm implements OnInit {

    public StockActionSignDetailsColumns = [];
    public extendExpDateNewFormViewModel: ExtendExpDateNewFormViewModel = new ExtendExpDateNewFormViewModel();
    public get _ExtendExpirationDate(): ExtendExpirationDate {
        return this._TTObject as ExtendExpirationDate;
    }
    private ExtendExpDateNewForm_DocumentUrl: string = '/api/ExtendExpirationDateService/ExtendExpDateNewForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private changeDetectorRef: ChangeDetectorRef,
        protected objectContextService: ObjectContextService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone,objectContextService);
        this._DocumentServiceUrl = this.ExtendExpDateNewForm_DocumentUrl;
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

        if (this._ExtendExpirationDate.Store == null) {
            this._ExtendExpirationDate.Store = this.inputStore;
            await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
        }




        this.MaterialExtendExpirationDateDetail.ListFilterExpression = "STOCKS.STORE= '" + this._ExtendExpirationDate.Store.ObjectID + "' AND STOCKS.INHELD > 0"; // + "AND STOCKCARD.STOCKMETHOD = 1";
        if (this._ExtendExpirationDate.Store instanceof MainStoreDefinition) {
            if ((<MainStoreDefinition>this._ExtendExpirationDate.Store).GoodsAccountant != null) {
                this._ExtendExpirationDate.MKYS_TeslimEden = (<MainStoreDefinition>this._ExtendExpirationDate.Store).GoodsAccountant.Name;
                this._ExtendExpirationDate.MKYS_TeslimEdenObjID = (<MainStoreDefinition>this._ExtendExpirationDate.Store).GoodsAccountant.ObjectID;
            }
            if ((<MainStoreDefinition>this._ExtendExpirationDate.DestinationStore).GoodsAccountant != null) {
                this._ExtendExpirationDate.MKYS_TeslimAlan = (<MainStoreDefinition>this._ExtendExpirationDate.DestinationStore).GoodsAccountant.Name;
                this._ExtendExpirationDate.MKYS_TeslimAlanObjID = (<MainStoreDefinition>this._ExtendExpirationDate.DestinationStore).GoodsAccountant.ObjectID;
            }
        }


    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ExtendExpirationDate();
        this.extendExpDateNewFormViewModel = new ExtendExpDateNewFormViewModel();
        this._ViewModel = this.extendExpDateNewFormViewModel;
        this.extendExpDateNewFormViewModel._ExtendExpirationDate = this._TTObject as ExtendExpirationDate;
        this.extendExpDateNewFormViewModel._ExtendExpirationDate.Store = new Store();
        this.extendExpDateNewFormViewModel._ExtendExpirationDate.ExtendExpirationDateDetails = new Array<ExtendExpirationDateDetail>();
        this.extendExpDateNewFormViewModel._ExtendExpirationDate.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.extendExpDateNewFormViewModel = this._ViewModel as ExtendExpDateNewFormViewModel;
        that._TTObject = this.extendExpDateNewFormViewModel._ExtendExpirationDate;
        if (this.extendExpDateNewFormViewModel == null)
            this.extendExpDateNewFormViewModel = new ExtendExpDateNewFormViewModel();
        if (this.extendExpDateNewFormViewModel._ExtendExpirationDate == null)
            this.extendExpDateNewFormViewModel._ExtendExpirationDate = new ExtendExpirationDate();
        let storeObjectID = that.extendExpDateNewFormViewModel._ExtendExpirationDate["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.extendExpDateNewFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.extendExpDateNewFormViewModel._ExtendExpirationDate.Store = store;
            }
        }
        that.extendExpDateNewFormViewModel._ExtendExpirationDate.ExtendExpirationDateDetails = that.extendExpDateNewFormViewModel.ExtendExpirationDateDetailsGridList;
        for (let detailItem of that.extendExpDateNewFormViewModel.ExtendExpirationDateDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.extendExpDateNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.extendExpDateNewFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.extendExpDateNewFormViewModel._ExtendExpirationDate.StockActionSignDetails = that.extendExpDateNewFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.extendExpDateNewFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.extendExpDateNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(ExtendExpDateNewFormViewModel);
        this.FormCaption = i18n("M19019", "Miad Güncelleme İşlemi ( Yeni )");
        this.changeDetectorRef.detectChanges();
  
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
    public async onMaterialSelectionChange(event: any) {
        if (this.stockLeveltypeArray.length === 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value === StockLevelTypeEnum.New);
        if (this.selectedMaterial == null)
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        else if (!this._ExtendExpirationDate.ExtendExpirationDateDetails.find(x => x.Material.ObjectID === this.selectedMaterial.ObjectID && x.EntityState !== EntityStateEnum.Deleted)) {
            let extendExpirationDateDetail: ExtendExpirationDateDetail = new ExtendExpirationDateDetail();
            extendExpirationDateDetail.Material = this.selectedMaterial;

            let stockCardObj: Guid = <any> extendExpirationDateDetail.Material['StockCard'];
            let stockCard: StockCard = await this.objectContextService.getObject(stockCardObj, StockCard.ObjectDefID);
            extendExpirationDateDetail.Material.StockCard = stockCard;


            extendExpirationDateDetail.StockLevelType = this.selectedStockLevelType;
            extendExpirationDateDetail.Status = StockActionDetailStatusEnum.New;
            extendExpirationDateDetail.IsNew = true;

            if (this.selectedStockLevelType != null) {
                let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(this.selectedMaterial.ObjectID, this._ExtendExpirationDate.Store.ObjectID, this.selectedStockLevelType.ObjectID);
                extendExpirationDateDetail.StoreStock = stockInheld;
            }


            let outableStockTransactions: Array<OutableStockTransaction_Response> = await StockActionService.GetOutableStockTransactions(this._ExtendExpirationDate.Store.ObjectID.toString(), extendExpirationDateDetail.Material.ObjectID.toString());
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
            if (multiSelectForm.MSSelectedItemObject !== null) {
                let lotSelected: TempOuttableLot = multiSelectForm.MSSelectedItemObject as TempOuttableLot;
                extendExpirationDateDetail.CurrentExpirationDate = <Date>lotSelected.ExpirationDate;
                extendExpirationDateDetail.SelectedLotRestAmount = lotSelected.RestAmount.Value;
                extendExpirationDateDetail.Amount = lotSelected.RestAmount.Value;
                //lotSelected.StockActionDetailOut = extendExpirationDateDetail;
                lotSelected.isUse = true;

                if (this.extendExpDateNewFormViewModel.TempOuttableLots == null)
                    this.extendExpDateNewFormViewModel.TempOuttableLots = new Array<TempOuttableLot>();
                this.extendExpDateNewFormViewModel.TempOuttableLots.push(lotSelected);
            }
            // let endOfMonth: Date = new Date(extendExpirationDateDetail.NewDateForExpiration.getFullYear(), extendExpirationDateDetail.NewDateForExpiration.getMonth() + 1, 1).AddDays(-1);
            // extendExpirationDateDetail.NewDateForExpiration = endOfMonth;

            this._ExtendExpirationDate.ExtendExpirationDateDetails.push(extendExpirationDateDetail);
        }
        else
            ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
    }

    /*public async btnAddClick() {

        if (this.selectedMaterial == null)
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        else if (!this._ExtendExpirationDate.ExtendExpirationDateDetails.find(x => x.Material.ObjectID == this.selectedMaterial.ObjectID && x.EntityState != EntityStateEnum.Deleted)) {
                let extendExpirationDateDetail: ExtendExpirationDateDetail = new ExtendExpirationDateDetail();
                extendExpirationDateDetail.Material = this.selectedMaterial;
                extendExpirationDateDetail.StockLevelType = this.selectedStockLevelType;
                extendExpirationDateDetail.Status = StockActionDetailStatusEnum.New;
                extendExpirationDateDetail.IsNew = true;

                if (this.selectedStockLevelType != null) {
                    let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(this.selectedMaterial.ObjectID, this._ExtendExpirationDate.Store.ObjectID, this.selectedStockLevelType.ObjectID);
                    extendExpirationDateDetail.StoreStock = stockInheld;
                }


                let outableStockTransactions: Array<OutableStockTransaction_Response> = await StockActionService.GetOutableStockTransactions(this._ExtendExpirationDate.Store.ObjectID.toString(), extendExpirationDateDetail.Material.ObjectID.toString());
                let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();

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
                    var datePipe = new DatePipe("en-US");
                    multiSelectForm.AddMSItem("MIAD : " + datePipe.transform(outtableLot.ExpirationDate, "M/yyyy") + " || " + i18n("M19031", "Miktar : ") + outtableLot.RestAmount.toString(), outtableLot.LotNo + " - " + datePipe.transform(outtableLot.ExpirationDate, "M/yyyy"), outtableLot);
                }

                let mlotKey: string = await multiSelectForm.GetMSItem(null, i18n("M22058", "Son Kullanma Tarihi / Mevcut Miktar"), true);
                if (multiSelectForm.MSSelectedItemObject !== null) {
                    let lotSelected: TempOuttableLot = multiSelectForm.MSSelectedItemObject as TempOuttableLot;
                    extendExpirationDateDetail.CurrentExpirationDate = <Date>lotSelected.ExpirationDate;
                    extendExpirationDateDetail.SelectedLotRestAmount = lotSelected.RestAmount.Value;
                    extendExpirationDateDetail.Amount = lotSelected.RestAmount.Value;
                    //lotSelected.StockActionDetailOut = extendExpirationDateDetail;
                    lotSelected.isUse = true;

                    if (this.extendExpDateNewFormViewModel.TempOuttableLots == null)
                        this.extendExpDateNewFormViewModel.TempOuttableLots = new Array<TempOuttableLot>();
                    this.extendExpDateNewFormViewModel.TempOuttableLots.push(lotSelected);
                 }
               // let endOfMonth: Date = new Date(extendExpirationDateDetail.NewDateForExpiration.getFullYear(), extendExpirationDateDetail.NewDateForExpiration.getMonth() + 1, 1).AddDays(-1);
               // extendExpirationDateDetail.NewDateForExpiration = endOfMonth;

                this._ExtendExpirationDate.ExtendExpirationDateDetails.push(extendExpirationDateDetail);
            }
            else
                ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
    }*/

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
        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M12615", "Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 123;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 122;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 4;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

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

        this.ExtendExpirationDateDetails = new TTVisual.TTGrid();
        this.ExtendExpirationDateDetails.Name = "ExtendExpirationDateDetails";
        this.ExtendExpirationDateDetails.TabIndex = 0;
        this.ExtendExpirationDateDetails.Height = 350;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.MaterialExtendExpirationDateDetail = new TTVisual.TTListBoxColumn();
        this.MaterialExtendExpirationDateDetail.ListDefName = "MaterialListDefinition";
        this.MaterialExtendExpirationDateDetail.DataMember = "Material";
        this.MaterialExtendExpirationDateDetail.AutoCompleteDialogHeight = '60%';
        this.MaterialExtendExpirationDateDetail.AutoCompleteDialogWidth = '90%';
        this.MaterialExtendExpirationDateDetail.DisplayIndex = 0;
        this.MaterialExtendExpirationDateDetail.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialExtendExpirationDateDetail.Name = "MaterialExtendExpirationDateDetail";
        this.MaterialExtendExpirationDateDetail.Width = 300;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

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

        this.RestAmount = new TTVisual.TTTextBoxColumn();
        this.RestAmount.DataMember = "SelectedLotRestAmount";
        this.RestAmount.DisplayIndex = 2;
        this.RestAmount.HeaderText = i18n("M15008", "Güncelleme Öncesi Lot Miktarı");
        this.RestAmount.Name = "RestAmount";
        this.RestAmount.ReadOnly = true;
        this.RestAmount.Width = 200;
        this.RestAmount.IsNumeric = true;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 3;
        this.Amount.HeaderText = i18n("M15015", "Güncellenen Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Width = 150;
        this.Amount.IsNumeric = true;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;



        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;



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

        //   this.ExtendExpirationDateDetailsColumns = [this.MaterialExtendExpirationDateDetail, this.Barcode, this.RestAmount, this.Amount, this.CurrentExpirationDate, this.NewDateForExpirationExtendExpirationDateDetail, this.StockLevelType];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.tttabcontrol1.Controls = [this.MaterialTabPage];
        this.MaterialTabPage.Controls = [this.ExtendExpirationDateDetails];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.labelStore, this.TTTeslimEdenButon, this.Store, this.TTTeslimAlanButon, this.tttabcontrol1, this.labelMKYS_TeslimEden,
        this.MaterialTabPage, this.MKYS_TeslimEden, this.ExtendExpirationDateDetails, this.MKYS_TeslimAlan, this.MaterialExtendExpirationDateDetail,
        this.Description, this.Barcode, this.StockActionID, this.RestAmount, this.labelMKYS_TeslimAlan, this.Amount, this.labelTransactionDate, this.CurrentExpirationDate, this.TransactionDate, this.NewDateForExpirationExtendExpirationDateDetail, this.labelStockActionID, this.StockLevelType, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.ttlabel1];

    }



}
