//$C6BD0547
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { BaseExtendExpDateFormViewModel } from './BaseExtendExpDateFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseChattelDocumentForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentForm";
import { ExtendExpirationDate, StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { ExtendExpirationDateDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_ECikisIslemTuruEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_ECikisStokHareketTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_ETedarikTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";
import { StockLevelTypeService } from "ObjectClassService/StockLevelTypeService";
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelService } from "ObjectClassService/StockLevelService";
import { MKYS_EAlimYontemiEnum } from 'NebulaClient/Model/AtlasClientModel';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";


import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { DxDataGridComponent } from 'devextreme-angular';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';

@Component({
    selector: 'BaseExtendExpDateForm',
    templateUrl: './BaseExtendExpDateForm.html',
    providers: [MessageService]
})
export class BaseExtendExpDateForm extends BaseChattelDocumentForm implements OnInit {
    Amount: TTVisual.ITTTextBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    CurrentExpirationDate: TTVisual.ITTDateTimePickerColumn;
    ExtendExpirationDateDetails: TTVisual.ITTGrid;
    labelStore: TTVisual.ITTLabel;
    MaterialExtendExpirationDateDetail: TTVisual.ITTListBoxColumn;
    MaterialTabPage: TTVisual.ITTTabPage;
    NewDateForExpirationExtendExpirationDateDetail: TTVisual.ITTDateTimePickerColumn;
    RestAmount: TTVisual.ITTTextBoxColumn;
    StockLevelType: TTVisual.ITTListBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    //public ExtendExpirationDateDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public baseExtendExpDateFormViewModel: BaseExtendExpDateFormViewModel = new BaseExtendExpDateFormViewModel();

    //#region dx-data-grid çevirme
    public selectedMaterial: Material;
    public selectedStockLevelType: StockLevelType;
    public stockLeveltypeArray: Array<StockLevelType> = new Array<StockLevelType>();
    public expirationMinDate: Date = new Date(Date.now());

    public ExtendExpirationDateDetailsColumns = [
        {
            caption: i18n("M18550", "Malzeme Adı"),
            dataField: 'Material.Name',
            allowEditing: false,
            //width: 'auto'
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
            //width: 'auto'
        },
        {
            caption: i18n("M15008", "Güncelleme Öncesi Lot Miktarı"),
            dataField: 'SelectedLotRestAmount',
            allowEditing: false,
            //width: 'auto'
        },
        {
            caption: i18n("M15015", "Güncellenen Miktar"),
            dataField: 'Amount',
            allowEditing: true,
            //width: 'auto'
        },
        {
            caption: i18n("M15009", "Güncelleme Öncesi Son Kullanma Tarihi"),
            dataField: 'CurrentExpirationDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowEditing: false,
            //width: 'auto'
        },
        {
            caption: i18n("M24591", "Yeni Son Kullanma Tarihi"),
            dataField: 'NewDateForExpiration',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowEditing: true,
            editorOptions: {
                min: this.expirationMinDate,
            }
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
            //width: 'auto',
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
        if (this.ReadOnly != true) {
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

    public get _ExtendExpirationDate(): ExtendExpirationDate {
        return this._TTObject as ExtendExpirationDate;
    }
    protected BaseExtendExpDateForm_DocumentUrl: string = '/api/ExtendExpirationDateService/BaseExtendExpDateForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone,protected objectContextService: ObjectContextService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseExtendExpDateForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }
//extendExpDateNewFormViewModel?._ExtendExpirationDate?.ExtendExpirationDateDetails
//ExtendExpirationDateDetails

    public async onMaterialSelectionChange(event: any) {
        if (this.stockLeveltypeArray.length == 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
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

        let extendExpirationDateDetail: ExtendExpirationDateDetail = <ExtendExpirationDateDetail>(data.Row.TTObject);
        if (extendExpirationDateDetail.Status === undefined) {
            extendExpirationDateDetail.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            extendExpirationDateDetail.StockLevelType = stockLeveltypeArray[0];
        }


        



        if (data.Column.Name === "MaterialExtendExpirationDateDetail" || data.Column.Name === "StockLevelType") {

            if (extendExpirationDateDetail.Material != null && extendExpirationDateDetail.StockLevelType != null) {
                if (extendExpirationDateDetail.Material.ObjectID != null) {

                    let stockCardObj: Guid = <any>extendExpirationDateDetail.Material['StockCard'];
                    let stockCard: StockCard = await this.objectContextService.getObject(stockCardObj, StockCard.ObjectDefID);
                    extendExpirationDateDetail.Material.StockCard = stockCard;

                    let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(extendExpirationDateDetail.Material.ObjectID, this._ExtendExpirationDate.Store.ObjectID, extendExpirationDateDetail.StockLevelType.ObjectID);
                    extendExpirationDateDetail.StoreStock = stockInheld;
                }
            }
        }

        if (data.Column.Name === "NewDateForExpirationExtendExpirationDateDetail") {
            let endOfMonth: Date = new Date(extendExpirationDateDetail.NewDateForExpiration.getFullYear(), extendExpirationDateDetail.NewDateForExpiration.getMonth() + 1, 1).AddDays(-1);
            extendExpirationDateDetail.NewDateForExpiration = endOfMonth;
        }
    }
    protected async PreScript() {
        super.PreScript();

        this._ExtendExpirationDate.MKYS_EAlimYontemi = MKYS_EAlimYontemiEnum.bos;
        this.baseExtendExpDateFormViewModel._ExtendExpirationDate.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.MiadUzatimi;
    }

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        this._ExtendExpirationDate.MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.cikis;
        this._ExtendExpirationDate.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.MiadUzatimi;
        this._ExtendExpirationDate.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckMiadUzatimiCikis;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ExtendExpirationDate();
        this.baseExtendExpDateFormViewModel = new BaseExtendExpDateFormViewModel();
        this._ViewModel = this.baseExtendExpDateFormViewModel;
        this.baseExtendExpDateFormViewModel._ExtendExpirationDate = this._TTObject as ExtendExpirationDate;
        this.baseExtendExpDateFormViewModel._ExtendExpirationDate.Store = new Store();
        this.baseExtendExpDateFormViewModel._ExtendExpirationDate.ExtendExpirationDateDetails = new Array<ExtendExpirationDateDetail>();
        this.baseExtendExpDateFormViewModel._ExtendExpirationDate.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.baseExtendExpDateFormViewModel = this._ViewModel as BaseExtendExpDateFormViewModel;
        that._TTObject = this.baseExtendExpDateFormViewModel._ExtendExpirationDate;
        if (this.baseExtendExpDateFormViewModel == null)
            this.baseExtendExpDateFormViewModel = new BaseExtendExpDateFormViewModel();
        if (this.baseExtendExpDateFormViewModel._ExtendExpirationDate == null)
            this.baseExtendExpDateFormViewModel._ExtendExpirationDate = new ExtendExpirationDate();
        let storeObjectID = that.baseExtendExpDateFormViewModel._ExtendExpirationDate["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.baseExtendExpDateFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.baseExtendExpDateFormViewModel._ExtendExpirationDate.Store = store;
            }
        }
        that.baseExtendExpDateFormViewModel._ExtendExpirationDate.ExtendExpirationDateDetails = that.baseExtendExpDateFormViewModel.ExtendExpirationDateDetailsGridList;
        for (let detailItem of that.baseExtendExpDateFormViewModel.ExtendExpirationDateDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.baseExtendExpDateFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.baseExtendExpDateFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.baseExtendExpDateFormViewModel._ExtendExpirationDate.StockActionSignDetails = that.baseExtendExpDateFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.baseExtendExpDateFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.baseExtendExpDateFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(BaseExtendExpDateFormViewModel);
  
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

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.MaterialExtendExpirationDateDetail = new TTVisual.TTListBoxColumn();
        this.MaterialExtendExpirationDateDetail.ListDefName = "MaterialListDefinition";
        this.MaterialExtendExpirationDateDetail.DataMember = "Material";
        this.MaterialExtendExpirationDateDetail.AutoCompleteDialogHeight = "60%";
        this.MaterialExtendExpirationDateDetail.AutoCompleteDialogWidth = "50%";
        this.MaterialExtendExpirationDateDetail.DisplayIndex = 0;
        this.MaterialExtendExpirationDateDetail.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialExtendExpirationDateDetail.Name = "MaterialExtendExpirationDateDetail";
        this.MaterialExtendExpirationDateDetail.Width = 330;

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
        this.Barcode.Width = 140;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.RestAmount = new TTVisual.TTTextBoxColumn();
        this.RestAmount.DataMember = "SelectedLotRestAmount";
        this.RestAmount.DisplayIndex = 2;
        this.RestAmount.HeaderText = i18n("M15007", "Güncelleme Öncesi Lot Miktar");
        this.RestAmount.Name = "RestAmount";
        this.RestAmount.ReadOnly = true;
        this.RestAmount.Width = 100;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 3;
        this.Amount.HeaderText = i18n("M15015", "Güncellenen Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Width = 100;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.CurrentExpirationDate = new TTVisual.TTDateTimePickerColumn();
        this.CurrentExpirationDate.Format = DateTimePickerFormat.Custom;
        this.CurrentExpirationDate.CustomFormat = "MM/yyyy";
        this.CurrentExpirationDate.DataMember = "CurrentExpirationDate";
        this.CurrentExpirationDate.DisplayIndex = 4;
        this.CurrentExpirationDate.HeaderText = i18n("M15009", "Güncelleme Öncesi Son Kullanma Tarihi");
        this.CurrentExpirationDate.Name = "CurrentExpirationDate";
        this.CurrentExpirationDate.ReadOnly = true;
        this.CurrentExpirationDate.Width = 100;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.NewDateForExpirationExtendExpirationDateDetail = new TTVisual.TTDateTimePickerColumn();
        this.NewDateForExpirationExtendExpirationDateDetail.Format = DateTimePickerFormat.Custom;
        this.NewDateForExpirationExtendExpirationDateDetail.CustomFormat = "dd/MM/yyyy";
        this.NewDateForExpirationExtendExpirationDateDetail.DataMember = "NewDateForExpiration";
        this.NewDateForExpirationExtendExpirationDateDetail.DisplayIndex = 5;
        this.NewDateForExpirationExtendExpirationDateDetail.HeaderText = i18n("M24591", "Yeni Son Kullanma Tarihi");
        this.NewDateForExpirationExtendExpirationDateDetail.Name = "NewDateForExpirationExtendExpirationDateDetail";
        this.NewDateForExpirationExtendExpirationDateDetail.Width = 150;

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
        this.StockLevelType.Width = 100;

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

       // this.ExtendExpirationDateDetailsColumns = [this.MaterialExtendExpirationDateDetail, this.Barcode, this.RestAmount, this.Amount, this.CurrentExpirationDate, this.NewDateForExpirationExtendExpirationDateDetail, this.StockLevelType];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.tttabcontrol1.Controls = [this.MaterialTabPage];
        this.MaterialTabPage.Controls = [this.ExtendExpirationDateDetails];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.labelStore, this.TTTeslimEdenButon, this.Store, this.TTTeslimAlanButon, this.tttabcontrol1, this.labelMKYS_TeslimEden, this.MaterialTabPage, this.MKYS_TeslimEden, this.ExtendExpirationDateDetails, this.MKYS_TeslimAlan, this.MaterialExtendExpirationDateDetail, this.Description, this.Barcode, this.StockActionID, this.RestAmount, this.labelMKYS_TeslimAlan, this.Amount, this.labelTransactionDate, this.CurrentExpirationDate, this.TransactionDate, this.NewDateForExpirationExtendExpirationDateDetail, this.labelStockActionID, this.StockLevelType, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.ttlabel1];

    }


}
