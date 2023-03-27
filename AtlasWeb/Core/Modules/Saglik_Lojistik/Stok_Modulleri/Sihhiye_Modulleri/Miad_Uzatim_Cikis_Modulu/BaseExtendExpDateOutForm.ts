//$B930392C
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { BaseExtendExpDateOutFormViewModel } from './BaseExtendExpDateOutFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseChattelDocumentForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentForm";
import { ExtendExpDateOut, StockLevelType, StockLevelTypeEnum, StockActionDetailStatusEnum, MKYS_EAlimYontemiEnum, MKYS_ETedarikTurEnum, MKYS_ECikisIslemTuruEnum, MKYS_ECikisStokHareketTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ExtendExpDateOutDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { DxDataGridComponent } from 'devextreme-angular';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';
import { StockLevelTypeService } from 'app/NebulaClient/Services/ObjectService/StockLevelTypeService';
import { StockLevelService } from 'app/NebulaClient/Services/ObjectService/StockLevelService';

@Component({
    selector: 'BaseExtendExpDateOutForm',
    templateUrl: './BaseExtendExpDateOutForm.html',
    providers: [MessageService]
})
export class BaseExtendExpDateOutForm extends BaseChattelDocumentForm implements OnInit {
    AmountExtendExpDateOutDetail: TTVisual.ITTTextBoxColumn;
    ExtendExpDateOutDetails: TTVisual.ITTGrid;
    labelStore: TTVisual.ITTLabel;
    labelSupplier: TTVisual.ITTLabel;
    MaterialExtendExpDateOutDetail: TTVisual.ITTListBoxColumn;
    OutExpirationDateExtendExpDateOutDetail: TTVisual.ITTDateTimePickerColumn;
    StatusExtendExpDateOutDetail: TTVisual.ITTEnumComboBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    Supplier: TTVisual.ITTObjectListBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    public ExtendExpDateOutDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public baseExtendExpDateOutFormViewModel: BaseExtendExpDateOutFormViewModel = new BaseExtendExpDateOutFormViewModel();

    public selectedMaterial: Material;
    public selectedStockLevelType: StockLevelType;
    public stockLeveltypeArray: Array<StockLevelType> = new Array<StockLevelType>();

    public ExtendExpirationDateDetailsColumns = [
        {
            caption: i18n("M18550", "Malzeme Adı"),
            dataField: 'Material.Name',
            allowEditing: false,
         //   width: 'auto'
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false,
          //  width: 'auto'
        },
        {
            caption: i18n("M15015", "Çıkış Miktarı"),
            dataField: 'Amount',
            allowEditing: true,
          //  width: 'auto'
        },
        {
            caption: i18n("M15009", "Çıkış Yapılan Son Kullanma Tarihi"),
            dataField: 'OutExpirationDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowEditing: false,
          //  width: 'auto'
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
         //   width: 'auto',
            cellTemplate: 'deleteCellTemplate',
            visible: !this.getIsReadOnly()
        },
    ];

    public getIsReadOnly() {
        return false;
    }
    @ViewChild('gridExpDate') gridExpDate: DxDataGridComponent;
    async gridExpDate_CellContentClicked(data: any) {
        let that = this;
        if (this.ReadOnly !== true) {
            if (data.column.name = "RowDelete") {
                if (data.row != null) {
                    if (data.row.key != null) {
                        if (data.row.key.IsNew) {
                            this.gridExpDate.instance.deleteRow(data.rowIndex);
                        }
                        else {
                            data.key.EntityState = EntityStateEnum.Deleted;
                            this.gridExpDate.instance.filter(['EntityState', '<>', 1]);
                            this.gridExpDate.instance.refresh();

                        }
                    }
                }

            }

        }
    }

    public async stateChange(event: FormSaveInfo) {
        this.gridExpDate.instance.closeEditCell();
        this.gridExpDate.instance.saveEditData();
        await super.setState(event.transDef, event);
    }

    public async onSaveButtonClick(event: FormSaveInfo) {
        this.gridExpDate.instance.closeEditCell();
        this.gridExpDate.instance.saveEditData();
        await super.saveForm(event);
    }

    public get _ExtendExpDateOut(): ExtendExpDateOut {
        return this._TTObject as ExtendExpDateOut;
    }
    private BaseExtendExpDateOutForm_DocumentUrl: string = '/api/ExtendExpDateOutService/BaseExtendExpDateOutForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseExtendExpDateOutForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    public async onMaterialSelectionChange(event: any) {
        if (this.stockLeveltypeArray.length === 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value === StockLevelTypeEnum.New);
    }
    // ***** Method declarations start *****

    public async ExtendExpirationDateDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {

        /*
        if (columnIndex === 0) {
            let extendExpirationDateDetail: ExtendExpirationDateDetail = <ExtendExpirationDateDetail>data.Row.TTObject;
            let outableStockTransactions: Array<OutableStockTransaction_Response> = await StockActionService.GetOutableStockTransactions(this._ExtendExpirationDate.Store.ObjectID.toString(), extendExpirationDateDetail.Material.ObjectID.toString());

            let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            for (let outableStockTransaction of outableStockTransactions) {
                let outtableLot: OuttableLot = new OuttableLot(this._ExtendExpirationDate.ObjectContext);
                outtableLot.LotNo = outableStockTransaction.LotNo;
                if (outableStockTransaction.ExpirationDate == null)
                    outtableLot.ExpirationDate = Date.MinValue;
                else outtableLot.ExpirationDate = outableStockTransaction.ExpirationDate;
                outtableLot.RestAmount = outableStockTransaction.Restamount;
                outtableLot.Amount = outableStockTransaction.Restamount;
                outtableLot.isUse = false;
                outtableLot.StockActionDetailOut = extendExpirationDateDetail;
                var datePipe = new DatePipe("en-US");
                multiSelectForm.AddMSItem("MIAD : " + datePipe.transform(outtableLot.ExpirationDate, "M/yyyy") + " || " + "Miktar : " + outtableLot.RestAmount.toString(), outtableLot.LotNo + " - " + datePipe.transform(outtableLot.ExpirationDate, "M/yyyy"), outtableLot);
            }

            let mlotKey: string = await multiSelectForm.GetMSItem(null, "Son Kullanma Tarihi / Mevcut Miktar", true);
            if (multiSelectForm.MSSelectedItemObject !== null) {
                let lotSelected: OuttableLot = multiSelectForm.MSSelectedItemObject as OuttableLot;
                extendExpirationDateDetail.CurrentExpirationDate = <Date>lotSelected.ExpirationDate;
                extendExpirationDateDetail.SelectedLotRestAmount = lotSelected.RestAmount.Value;
                extendExpirationDateDetail.Amount = lotSelected.RestAmount.Value;
                lotSelected.StockActionDetailOut = extendExpirationDateDetail;
                lotSelected.isUse = true;

                if (this.baseExtendExpDateFormViewModel.OuttableLots == null)
                    this.baseExtendExpDateFormViewModel.OuttableLots = new Array<OuttableLot>();
                this.baseExtendExpDateFormViewModel.OuttableLots.push(lotSelected);
            }
        }
        */

        let extendExpDateOutDetail: ExtendExpDateOutDetail = <ExtendExpDateOutDetail>(data.Row.TTObject);
        if (extendExpDateOutDetail.Status === undefined) {
            extendExpDateOutDetail.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            extendExpDateOutDetail.StockLevelType = stockLeveltypeArray[0];
        }
        if (data.Column.Name === "MaterialExtendExpirationDateDetail" || data.Column.Name === "StockLevelType") {

            if (extendExpDateOutDetail.Material != null && extendExpDateOutDetail.StockLevelType != null) {
                if (extendExpDateOutDetail.Material.ObjectID != null) {
                    let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(extendExpDateOutDetail.Material.ObjectID, this._ExtendExpDateOut.Store.ObjectID, extendExpDateOutDetail.StockLevelType.ObjectID);
                    extendExpDateOutDetail.StoreStock = stockInheld;
                }
            }
        }

        /*if (data.Column.Name === "NewDateForExpirationExtendExpirationDateDetail") {
            let endOfMonth: Date = new Date(extendExpDateOutDetail.NewDateForExpiration.getFullYear(), extendExpDateOutDetail.NewDateForExpiration.getMonth() + 1, 1).AddDays(-1);
            extendExpDateOutDetail.NewDateForExpiration = endOfMonth;
        }*/
    }
    protected async PreScript() {
        super.PreScript();

        this._ExtendExpDateOut.MKYS_EAlimYontemi = MKYS_EAlimYontemiEnum.bos;
        this.baseExtendExpDateOutFormViewModel._ExtendExpDateOut.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.MiadUzatimi;
    }

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        this._ExtendExpDateOut.MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.cikis;
        this._ExtendExpDateOut.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.MiadUzatimi;
        this._ExtendExpDateOut.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckMiadUzatimiCikis;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ExtendExpDateOut();
        this.baseExtendExpDateOutFormViewModel = new BaseExtendExpDateOutFormViewModel();
        this._ViewModel = this.baseExtendExpDateOutFormViewModel;
        this.baseExtendExpDateOutFormViewModel._ExtendExpDateOut = this._TTObject as ExtendExpDateOut;
        this.baseExtendExpDateOutFormViewModel._ExtendExpDateOut.Store = new Store();
        this.baseExtendExpDateOutFormViewModel._ExtendExpDateOut.Supplier = new Supplier();
        this.baseExtendExpDateOutFormViewModel._ExtendExpDateOut.ExtendExpDateOutDetails = new Array<ExtendExpDateOutDetail>();
        this.baseExtendExpDateOutFormViewModel._ExtendExpDateOut.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.baseExtendExpDateOutFormViewModel = this._ViewModel as BaseExtendExpDateOutFormViewModel;
        that._TTObject = this.baseExtendExpDateOutFormViewModel._ExtendExpDateOut;
        if (this.baseExtendExpDateOutFormViewModel == null)
            this.baseExtendExpDateOutFormViewModel = new BaseExtendExpDateOutFormViewModel();
        if (this.baseExtendExpDateOutFormViewModel._ExtendExpDateOut == null)
            this.baseExtendExpDateOutFormViewModel._ExtendExpDateOut = new ExtendExpDateOut();
        let storeObjectID = that.baseExtendExpDateOutFormViewModel._ExtendExpDateOut["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.baseExtendExpDateOutFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.baseExtendExpDateOutFormViewModel._ExtendExpDateOut.Store = store;
            }
        }


        let supplierObjectID = that.baseExtendExpDateOutFormViewModel._ExtendExpDateOut["Supplier"];
        if (supplierObjectID != null && (typeof supplierObjectID === "string")) {
            let supplier = that.baseExtendExpDateOutFormViewModel.Suppliers.find(o => o.ObjectID.toString() === supplierObjectID.toString());
            if (supplier) {
                that.baseExtendExpDateOutFormViewModel._ExtendExpDateOut.Supplier = supplier;
            }
        }


        that.baseExtendExpDateOutFormViewModel._ExtendExpDateOut.ExtendExpDateOutDetails = that.baseExtendExpDateOutFormViewModel.ExtendExpDateOutDetailsGridList;
        for (let detailItem of that.baseExtendExpDateOutFormViewModel.ExtendExpDateOutDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.baseExtendExpDateOutFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }

        }

        that.baseExtendExpDateOutFormViewModel._ExtendExpDateOut.StockActionSignDetails = that.baseExtendExpDateOutFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.baseExtendExpDateOutFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === "string")) {
                let signUser = that.baseExtendExpDateOutFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }

    }
    async ngOnInit() {
        await this.load();
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
