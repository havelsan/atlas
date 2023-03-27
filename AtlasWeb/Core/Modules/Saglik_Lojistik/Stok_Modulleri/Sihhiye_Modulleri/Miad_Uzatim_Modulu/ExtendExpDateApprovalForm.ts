//$F16371BA
import { Component, OnInit, NgZone } from '@angular/core';
import { ExtendExpDateApprovalFormViewModel } from './ExtendExpDateApprovalFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseExtendExpDateForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Miad_Uzatim_Modulu/BaseExtendExpDateForm";
import { ExtendExpirationDate } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';

import { ExtendExpirationDateDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';



import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';

@Component({
    selector: 'ExtendExpDateApprovalForm',
    templateUrl: './ExtendExpDateApprovalForm.html',
    providers: [MessageService]
})
export class ExtendExpDateApprovalForm extends BaseExtendExpDateForm implements OnInit {
    public ExtendExpirationDateDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public extendExpDateApprovalFormViewModel: ExtendExpDateApprovalFormViewModel = new ExtendExpDateApprovalFormViewModel();
    public get _ExtendExpirationDate(): ExtendExpirationDate {
        return this._TTObject as ExtendExpirationDate;
    }
    private ExtendExpDateApprovalForm_DocumentUrl: string = '/api/ExtendExpirationDateService/ExtendExpDateApprovalForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone,protected objectContextService: ObjectContextService) {
        super(httpService, messageService, ngZone,objectContextService);
        this._DocumentServiceUrl = this.ExtendExpDateApprovalForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);

    }
    protected async PreScript() {
        super.PreScript();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ExtendExpirationDate();
        this.extendExpDateApprovalFormViewModel = new ExtendExpDateApprovalFormViewModel();
        this._ViewModel = this.extendExpDateApprovalFormViewModel;
        this.extendExpDateApprovalFormViewModel._ExtendExpirationDate = this._TTObject as ExtendExpirationDate;
        this.extendExpDateApprovalFormViewModel._ExtendExpirationDate.Store = new Store();
        this.extendExpDateApprovalFormViewModel._ExtendExpirationDate.ExtendExpirationDateDetails = new Array<ExtendExpirationDateDetail>();
        this.extendExpDateApprovalFormViewModel._ExtendExpirationDate.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.extendExpDateApprovalFormViewModel = this._ViewModel as ExtendExpDateApprovalFormViewModel;
        that._TTObject = this.extendExpDateApprovalFormViewModel._ExtendExpirationDate;
        if (this.extendExpDateApprovalFormViewModel == null)
            this.extendExpDateApprovalFormViewModel = new ExtendExpDateApprovalFormViewModel();
        if (this.extendExpDateApprovalFormViewModel._ExtendExpirationDate == null)
            this.extendExpDateApprovalFormViewModel._ExtendExpirationDate = new ExtendExpirationDate();
        let storeObjectID = that.extendExpDateApprovalFormViewModel._ExtendExpirationDate["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.extendExpDateApprovalFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.extendExpDateApprovalFormViewModel._ExtendExpirationDate.Store = store;
            }
        }
        that.extendExpDateApprovalFormViewModel._ExtendExpirationDate.ExtendExpirationDateDetails = that.extendExpDateApprovalFormViewModel.ExtendExpirationDateDetailsGridList;
        for (let detailItem of that.extendExpDateApprovalFormViewModel.ExtendExpirationDateDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.extendExpDateApprovalFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.extendExpDateApprovalFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                 if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.extendExpDateApprovalFormViewModel._ExtendExpirationDate.StockActionSignDetails = that.extendExpDateApprovalFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.extendExpDateApprovalFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.extendExpDateApprovalFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                 if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(ExtendExpDateApprovalFormViewModel);
        if (this._ExtendExpirationDate.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ExtendExpirationDate.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M19017", "Miad Güncelleme İşlemi ( Onay )");

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
    this.MaterialExtendExpirationDateDetail.AutoCompleteDialogHeight = "60%";
        this.MaterialExtendExpirationDateDetail.AutoCompleteDialogWidth = "50%";
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

        this.CurrentExpirationDate = new TTVisual.TTDateTimePickerColumn();
        this.CurrentExpirationDate.Format = DateTimePickerFormat.Custom;
        this.CurrentExpirationDate.CustomFormat = "MM/yyyy";
        this.CurrentExpirationDate.DataMember = "CurrentExpirationDate";
        this.CurrentExpirationDate.DisplayIndex = 4;
        this.CurrentExpirationDate.HeaderText = i18n("M15009", "Güncelleme Öncesi Son Kullanma Tarihi");
        this.CurrentExpirationDate.Name = "CurrentExpirationDate";
        this.CurrentExpirationDate.ReadOnly = true;
        this.CurrentExpirationDate.Width = 280;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.NewDateForExpirationExtendExpirationDateDetail = new TTVisual.TTDateTimePickerColumn();
        this.NewDateForExpirationExtendExpirationDateDetail.Format = DateTimePickerFormat.Custom;
        this.NewDateForExpirationExtendExpirationDateDetail.CustomFormat = "MM/yyyy";
        this.NewDateForExpirationExtendExpirationDateDetail.DataMember = "NewDateForExpiration";
        this.NewDateForExpirationExtendExpirationDateDetail.DisplayIndex = 5;
        this.NewDateForExpirationExtendExpirationDateDetail.HeaderText = i18n("M24591", "Yeni Son Kullanma Tarihi");
        this.NewDateForExpirationExtendExpirationDateDetail.Name = "NewDateForExpirationExtendExpirationDateDetail";
        this.NewDateForExpirationExtendExpirationDateDetail.Width = 180;

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

        this.ExtendExpirationDateDetailsColumns = [this.MaterialExtendExpirationDateDetail, this.Barcode, this.RestAmount, this.Amount, this.CurrentExpirationDate, this.NewDateForExpirationExtendExpirationDateDetail, this.StockLevelType];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.tttabcontrol1.Controls = [this.MaterialTabPage];
        this.MaterialTabPage.Controls = [this.ExtendExpirationDateDetails];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.labelStore, this.TTTeslimEdenButon, this.Store, this.TTTeslimAlanButon, this.tttabcontrol1, this.labelMKYS_TeslimEden, this.MaterialTabPage, this.MKYS_TeslimEden, this.ExtendExpirationDateDetails, this.MKYS_TeslimAlan, this.MaterialExtendExpirationDateDetail, this.Description, this.Barcode, this.StockActionID, this.RestAmount, this.labelMKYS_TeslimAlan, this.Amount, this.labelTransactionDate, this.CurrentExpirationDate, this.TransactionDate, this.NewDateForExpirationExtendExpirationDateDetail, this.labelStockActionID, this.StockLevelType, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.ttlabel1];

    }


}
