//$9052ED0B
import { Component, OnInit, NgZone } from '@angular/core';
import { SupplyRequestPoolApprovalFormViewModel } from './SupplyRequestPoolApprovalFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseSupplyRequestPoolForm } from "Modules/Saglik_Lojistik/Satinalma_Modulleri/Satinalma_Istek_Modulu/BaseSupplyRequestPoolForm";
import { SupplyRequestPool } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRequestPoolDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { IModalService } from "Fw/Services/IModalService";



@Component({
    selector: 'SupplyRequestPoolApprovalForm',
    templateUrl: './SupplyRequestPoolApprovalForm.html',
    providers: [MessageService]
})
export class SupplyRequestPoolApprovalForm extends BaseSupplyRequestPoolForm implements OnInit {
    public SupplyRequestPoolDetailsColumns = [];
    public supplyRequestPoolApprovalFormViewModel: SupplyRequestPoolApprovalFormViewModel = new SupplyRequestPoolApprovalFormViewModel();
    public get _SupplyRequestPool(): SupplyRequestPool {
        return this._TTObject as SupplyRequestPool;
    }
    private SupplyRequestPoolApprovalForm_DocumentUrl: string = '/api/SupplyRequestPoolService/SupplyRequestPoolApprovalForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected modalService: IModalService,
                protected ngZone: NgZone) {
        super(httpService, messageService, modalService, ngZone);
        this._DocumentServiceUrl = this.SupplyRequestPoolApprovalForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****



    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SupplyRequestPool();
        this.supplyRequestPoolApprovalFormViewModel = new SupplyRequestPoolApprovalFormViewModel();
        this._ViewModel = this.supplyRequestPoolApprovalFormViewModel;
        this.supplyRequestPoolApprovalFormViewModel._SupplyRequestPool = this._TTObject as SupplyRequestPool;
        this.supplyRequestPoolApprovalFormViewModel._SupplyRequestPool.SupplyRequestPoolDetails = new Array<SupplyRequestPoolDetail>();
        this.supplyRequestPoolApprovalFormViewModel._SupplyRequestPool.Store = new Store();
        this.supplyRequestPoolApprovalFormViewModel._SupplyRequestPool.SignUser = new ResUser();
    }

    protected loadViewModel() {
        let that = this;

        that.supplyRequestPoolApprovalFormViewModel = this._ViewModel as SupplyRequestPoolApprovalFormViewModel;
        that._TTObject = this.supplyRequestPoolApprovalFormViewModel._SupplyRequestPool;
        if (this.supplyRequestPoolApprovalFormViewModel == null)
            this.supplyRequestPoolApprovalFormViewModel = new SupplyRequestPoolApprovalFormViewModel();
        if (this.supplyRequestPoolApprovalFormViewModel._SupplyRequestPool == null)
            this.supplyRequestPoolApprovalFormViewModel._SupplyRequestPool = new SupplyRequestPool();
        that.supplyRequestPoolApprovalFormViewModel._SupplyRequestPool.SupplyRequestPoolDetails = that.supplyRequestPoolApprovalFormViewModel.SupplyRequestPoolDetailsGridList;
        for (let detailItem of that.supplyRequestPoolApprovalFormViewModel.SupplyRequestPoolDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.supplyRequestPoolApprovalFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
            let distributionTypeObjectID = detailItem["DistributionType"];
            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                let distributionType = that.supplyRequestPoolApprovalFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                 if (distributionType) {
                    detailItem.DistributionType = distributionType;
                }
            }
        }
        let storeObjectID = that.supplyRequestPoolApprovalFormViewModel._SupplyRequestPool["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.supplyRequestPoolApprovalFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.supplyRequestPoolApprovalFormViewModel._SupplyRequestPool.Store = store;
            }
        }
        let signUserObjectID = that.supplyRequestPoolApprovalFormViewModel._SupplyRequestPool["SignUser"];
        if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
            let signUser = that.supplyRequestPoolApprovalFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
             if (signUser) {
                that.supplyRequestPoolApprovalFormViewModel._SupplyRequestPool.SignUser = signUser;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(SupplyRequestPoolApprovalFormViewModel);
        this.FormCaption = i18n("M21372", "Satınalma Talepleri Havuzu ( Detay İnceleme )");
  
    }


    public onDateOfSupplyChanged(event): void {
        if (event != null) {
            if (this._SupplyRequestPool != null && this._SupplyRequestPool.DateOfSupply != event) {
                this._SupplyRequestPool.DateOfSupply = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._SupplyRequestPool != null && this._SupplyRequestPool.Description != event) {
                this._SupplyRequestPool.Description = event;
            }
        }
    }

    public onIsImmediateChanged(event): void {
        if (event != null) {
            if (this._SupplyRequestPool != null && this._SupplyRequestPool.IsImmediate != event) {
                this._SupplyRequestPool.IsImmediate = event;
            }
        }
    }

    public onRequestTypeChanged(event): void {
        if (event != null) {
            if (this._SupplyRequestPool != null && this._SupplyRequestPool.RequestType != event) {
                this._SupplyRequestPool.RequestType = event;
            }
        }
    }

    public onSignUserChanged(event): void {
        if (event != null) {
            if (this._SupplyRequestPool != null && this._SupplyRequestPool.SignUser != event) {
                this._SupplyRequestPool.SignUser = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._SupplyRequestPool != null && this._SupplyRequestPool.StockActionID != event) {
                this._SupplyRequestPool.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._SupplyRequestPool != null && this._SupplyRequestPool.Store != event) {
                this._SupplyRequestPool.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._SupplyRequestPool != null && this._SupplyRequestPool.TransactionDate != event) {
                this._SupplyRequestPool.TransactionDate = event;
            }
        }
    }



    SupplyRequestPoolDetails_CellValueChangedEmitted(data: any) {
        if (data && this.SupplyRequestPoolDetails_CellValueChanged && data.Row && data.Column) {
            this.SupplyRequestPoolDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }
    public async SupplyRequestPoolDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.SupplyRequestPoolDetails_CellValueChanged(data, rowIndex, columnIndex);
    }
    onSelectionChange(data: any) {
    }

    onRowInserting(data: any) {
    }
    onCellContentClicked(data: any) {
    }
    async initNewRow(data: any) {
    }

    SupplyRequestPoolDetails_CellContentClickEmitted(data: any) {
        if (data && this.SupplyRequestPoolDetails_CellContentClick && data.Row && data.Column) {
            this.SupplyRequestPoolDetails_CellContentClick(data, data.RowIndex, data.ColIndex);
        }
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.RequestType, "Value", this.__ttObject, "RequestType");
        redirectProperty(this.DateOfSupply, "Value", this.__ttObject, "DateOfSupply");
        redirectProperty(this.IsImmediate, "Value", this.__ttObject, "IsImmediate");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.labelDateOfSupply = new TTVisual.TTLabel();
        this.labelDateOfSupply.Text = i18n("M17317", "Karşılanma Tarihi");
        this.labelDateOfSupply.Name = "labelDateOfSupply";
        this.labelDateOfSupply.TabIndex = 14;

        this.DateOfSupply = new TTVisual.TTDateTimePicker();
        this.DateOfSupply.Format = DateTimePickerFormat.Long;
        this.DateOfSupply.Name = "DateOfSupply";
        this.DateOfSupply.TabIndex = 13;
        this.DateOfSupply.BackColor = "#FFE3C6";

        this.IsImmediate = new TTVisual.TTCheckBox();
        this.IsImmediate.Value = false;
        this.IsImmediate.Title = "ACİL İSTEK";
        this.IsImmediate.Name = "IsImmediate";
        this.IsImmediate.TabIndex = 12;

        this.labelRequestType = new TTVisual.TTLabel();
        this.labelRequestType.Text = i18n("M10698", "Alım Türü");
        this.labelRequestType.Name = "labelRequestType";
        this.labelRequestType.TabIndex = 11;

        this.RequestType = new TTVisual.TTEnumComboBox();
        this.RequestType.DataTypeName = "SupplyRequestTypeEnum";
        this.RequestType.BackColor = "#F0F0F0";
        this.RequestType.Enabled = false;
        this.RequestType.Name = "RequestType";
        this.RequestType.TabIndex = 10;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M16629", "İstek Kalemleri");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 9;

        this.SupplyRequestPoolDetails = new TTVisual.TTGrid();
        this.SupplyRequestPoolDetails.Name = "SupplyRequestPoolDetails";
        this.SupplyRequestPoolDetails.TabIndex = 0;
        this.SupplyRequestPoolDetails.Height = 350;
        this.SupplyRequestPoolDetails.AllowUserToAddRows = false;
        this.SupplyRequestPoolDetails.AllowUserToDeleteRows = false;

        this.SupplyRequestPoolDetailBtn = new TTVisual.TTButtonColumn();
        this.SupplyRequestPoolDetailBtn.Text = i18n("M12671", "Detay");
        this.SupplyRequestPoolDetailBtn.DisplayIndex = 0;
        this.SupplyRequestPoolDetailBtn.HeaderText = i18n("M16615", "İstek Detayı");
        this.SupplyRequestPoolDetailBtn.Name = "SupplyRequestPoolDetailBtn";
        this.SupplyRequestPoolDetailBtn.Width = 100;

        this.BaseMaterialGroupSupplyRequestPoolDetail = new TTVisual.TTListBoxColumn();
        this.BaseMaterialGroupSupplyRequestPoolDetail.ListDefName = "MaterialListDefinition";
        this.BaseMaterialGroupSupplyRequestPoolDetail.DataMember = "Material";
        this.BaseMaterialGroupSupplyRequestPoolDetail.DisplayIndex = 1;
        this.BaseMaterialGroupSupplyRequestPoolDetail.HeaderText = i18n("M18545", "Malzeme");
        this.BaseMaterialGroupSupplyRequestPoolDetail.Name = "BaseMaterialGroupSupplyRequestPoolDetail";
        this.BaseMaterialGroupSupplyRequestPoolDetail.Width = 300;

        this.DistributionTypeSupplyRequestPoolDetail = new TTVisual.TTTextBoxColumn();
        //this.DistributionTypeSupplyRequestPoolDetail.ListDefName = "DistributionTypeList";
        this.DistributionTypeSupplyRequestPoolDetail.DataMember = "Material.DistributionTypeName";
        this.DistributionTypeSupplyRequestPoolDetail.DisplayIndex = 2;
        this.DistributionTypeSupplyRequestPoolDetail.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionTypeSupplyRequestPoolDetail.Name = "DistributionTypeSupplyRequestPoolDetail";
        this.DistributionTypeSupplyRequestPoolDetail.Width = 120;

        this.TotalRequestAmountSupplyRequestPoolDetail = new TTVisual.TTTextBoxColumn();
        this.TotalRequestAmountSupplyRequestPoolDetail.DataMember = "TotalRequestAmount";
        this.TotalRequestAmountSupplyRequestPoolDetail.DisplayIndex = 3;
        this.TotalRequestAmountSupplyRequestPoolDetail.HeaderText = i18n("M23523", "Toplam Talep Miktarı");
        this.TotalRequestAmountSupplyRequestPoolDetail.Name = "TotalRequestAmountSupplyRequestPoolDetail";
        this.TotalRequestAmountSupplyRequestPoolDetail.ReadOnly = true;
        this.TotalRequestAmountSupplyRequestPoolDetail.Width = 150;

        this.AmountSupplyRequestPoolDetail = new TTVisual.TTTextBoxColumn();
        this.AmountSupplyRequestPoolDetail.DataMember = "Amount";
        this.AmountSupplyRequestPoolDetail.DisplayIndex = 4;
        this.AmountSupplyRequestPoolDetail.HeaderText = i18n("M16708", "İstenecek Miktar");
        this.AmountSupplyRequestPoolDetail.Name = "AmountSupplyRequestPoolDetail";
        this.AmountSupplyRequestPoolDetail.ReadOnly = true;
        this.AmountSupplyRequestPoolDetail.Width = 150;
        this.AmountSupplyRequestPoolDetail.IsNumeric = true;

        this.PurchaseAmountSupplyRequestPoolDetail = new TTVisual.TTTextBoxColumn();
        this.PurchaseAmountSupplyRequestPoolDetail.DataMember = "PurchaseAmount";
        this.PurchaseAmountSupplyRequestPoolDetail.Required = true;
        this.PurchaseAmountSupplyRequestPoolDetail.DisplayIndex = 5;
        this.PurchaseAmountSupplyRequestPoolDetail.HeaderText = i18n("M21358", "Satınalma Miktarı");
        this.PurchaseAmountSupplyRequestPoolDetail.Name = "PurchaseAmountSupplyRequestPoolDetail";
        this.PurchaseAmountSupplyRequestPoolDetail.Width = 150;
        this.PurchaseAmountSupplyRequestPoolDetail.IsNumeric = true;

        this.ExcessAmountSupplyRequestPoolDetail = new TTVisual.TTTextBoxColumn();
        this.ExcessAmountSupplyRequestPoolDetail.DataMember = "ExcessAmount";
        this.ExcessAmountSupplyRequestPoolDetail.DisplayIndex = 6;
        this.ExcessAmountSupplyRequestPoolDetail.HeaderText = i18n("M15972", "I.F. ile Temin");
        this.ExcessAmountSupplyRequestPoolDetail.Name = "ExcessAmountSupplyRequestPoolDetail";
        this.ExcessAmountSupplyRequestPoolDetail.Width = 150;
        this.ExcessAmountSupplyRequestPoolDetail.IsNumeric = true;

        this.MKYSExcessQueryBtn = new TTVisual.TTButtonColumn();
        this.MKYSExcessQueryBtn.Text = i18n("M22125", "Sorgula");
        this.MKYSExcessQueryBtn.DisplayIndex = 7;
        this.MKYSExcessQueryBtn.HeaderText = "MKYS I.F. Sorgu";
        this.MKYSExcessQueryBtn.Name = "MKYSExcessQueryBtn";
        this.MKYSExcessQueryBtn.Width = 120;

        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail = new TTVisual.TTEnumComboBoxColumn();
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.DataTypeName = "SupplyRqstPlDetStatusEnum";
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.DataMember = "SupplyRqstPlDetStatus";
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.DisplayIndex = 8;
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.HeaderText = i18n("M22692", "Talep Durumu");
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.Name = "SupplyRqstPlDetStatusSupplyRequestPoolDetail";
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.Width = 120;

        this.DetailDescriptionSupplyRequestPoolDetail = new TTVisual.TTTextBoxColumn();
        this.DetailDescriptionSupplyRequestPoolDetail.DataMember = "DetailDescription";
        this.DetailDescriptionSupplyRequestPoolDetail.Required = true;
        this.DetailDescriptionSupplyRequestPoolDetail.DisplayIndex = 9;
        this.DetailDescriptionSupplyRequestPoolDetail.HeaderText = i18n("M10469", "Açıklama");
        this.DetailDescriptionSupplyRequestPoolDetail.Name = "DetailDescriptionSupplyRequestPoolDetail";
        this.DetailDescriptionSupplyRequestPoolDetail.Width = 120;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M10896", "Ana Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 8;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 7;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 5;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Long;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 4;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 3;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 2;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Required = true;
        this.Description.Multiline = true;
        this.Description.BackColor = "#FFE3C6";
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M22696", "Talep Nedeni");
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 1;

        this.SignUser = new TTVisual.TTObjectListBox();
        this.SignUser.Required = true;
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.Name = "SignUser";
        this.SignUser.TabIndex = 14;

        this.labelSignUser = new TTVisual.TTLabel();
        this.labelSignUser.Text = i18n("M16666", "İstek Yapan Personel");
        this.labelSignUser.Name = "labelSignUser";
        this.labelSignUser.TabIndex = 15;

        this.SupplyRequestPoolDetailsColumns = [this.SupplyRequestPoolDetailBtn, this.BaseMaterialGroupSupplyRequestPoolDetail, this.DistributionTypeSupplyRequestPoolDetail, this.TotalRequestAmountSupplyRequestPoolDetail, this.AmountSupplyRequestPoolDetail, this.PurchaseAmountSupplyRequestPoolDetail, this.ExcessAmountSupplyRequestPoolDetail, this.SupplyRqstPlDetStatusSupplyRequestPoolDetail, this.DetailDescriptionSupplyRequestPoolDetail];
        this.ttgroupbox1.Controls = [this.SupplyRequestPoolDetails];
        this.Controls = [this.labelDateOfSupply, this.DateOfSupply, this.IsImmediate, this.labelRequestType, this.RequestType, this.ttgroupbox1, this.SupplyRequestPoolDetails, this.SupplyRequestPoolDetailBtn, this.BaseMaterialGroupSupplyRequestPoolDetail, this.DistributionTypeSupplyRequestPoolDetail, this.TotalRequestAmountSupplyRequestPoolDetail, this.AmountSupplyRequestPoolDetail, this.PurchaseAmountSupplyRequestPoolDetail, this.ExcessAmountSupplyRequestPoolDetail, this.MKYSExcessQueryBtn, this.SupplyRqstPlDetStatusSupplyRequestPoolDetail, this.DetailDescriptionSupplyRequestPoolDetail, this.labelStore, this.Store, this.labelTransactionDate, this.TransactionDate, this.labelStockActionID, this.StockActionID, this.Description, this.labelDescription, this.SignUser, this.labelSignUser];

        for (let control of this.Controls) {
            if (control.Name == this.BaseMaterialGroupSupplyRequestPoolDetail.Name || control.Name == this.DistributionTypeSupplyRequestPoolDetail.Name) {
                this.BaseMaterialGroupSupplyRequestPoolDetail.ReadOnly = true;
                this.DistributionTypeSupplyRequestPoolDetail.ReadOnly = true;

            }

        }
    }


}
