//$88B60ED0
import { Component, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { SupplyRequestPoolNewFormViewModel } from './SupplyRequestPoolNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseSupplyRequestPoolForm } from "Modules/Saglik_Lojistik/Satinalma_Modulleri/Satinalma_Istek_Modulu/BaseSupplyRequestPoolForm";
import { MainStoreDefinition, PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SelectStoreUsageEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRequestDetailService, GetSupplyReqDetsByStoreAndDemandType_Output } from "ObjectClassService/SupplyRequestDetailService";
import { SupplyRequestPool } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRequestPoolDetail } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRequestTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRqstPlDetStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { IModalService } from "Fw/Services/IModalService";


@Component({
    selector: 'SupplyRequestPoolNewForm',
    templateUrl: './SupplyRequestPoolNewForm.html',
    providers: [MessageService]
})
export class SupplyRequestPoolNewForm extends BaseSupplyRequestPoolForm implements OnInit {
    public SupplyRequestPoolDetailsColumns = [];
    public supplyRequestPoolNewFormViewModel: SupplyRequestPoolNewFormViewModel = new SupplyRequestPoolNewFormViewModel();
    public get _SupplyRequestPool(): SupplyRequestPool {
        return this._TTObject as SupplyRequestPool;
    }
    private SupplyRequestPoolNewForm_DocumentUrl: string = '/api/SupplyRequestPoolService/SupplyRequestPoolNewForm';
    constructor(protected messageService: MessageService,
                private objectContextService: ObjectContextService,
                private http: NeHttpService,
                protected modalService: IModalService,
                private changeDetectorRef: ChangeDetectorRef,
                protected ngZone: NgZone) {
        super(http, messageService, modalService, ngZone);
        this._DocumentServiceUrl = this.SupplyRequestPoolNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    inputStore: Store;
    public setInputParam(value: Store) {
        if (value != null) {
            if (value.ObjectDefID.toString() == MainStoreDefinition.ObjectDefID.id || value.ObjectDefID.toString() == PharmacyStoreDefinition.ObjectDefID.id)
                this.inputStore = value;
        }
    }

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();

        if (this._SupplyRequestPool.Store == null) {
            this._SupplyRequestPool.Store = this.inputStore;
            await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStores, SelectStoreUsageEnum.Nothing);
        }

        this._SupplyRequestPool.SignUser = (<MainStoreDefinition>(this._SupplyRequestPool.Store)).AccountManager;

        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        mSelectForm.AddMSItem(i18n("M11981", "Boş"), i18n("M11981", "Boş"), SupplyRequestTypeEnum.None);
        mSelectForm.AddMSItem(i18n("M16287", "İlaç"), i18n("M16287", "İlaç"), SupplyRequestTypeEnum.Ilac);
        mSelectForm.AddMSItem(i18n("M21326", "Sarf Malzeme"), i18n("M21326", "Sarf Malzeme"), SupplyRequestTypeEnum.sarfMalzeme);
        mSelectForm.AddMSItem(i18n("M12555", "Demirbaş"), i18n("M12555", "Demirbaş"), SupplyRequestTypeEnum.demirbas);
        mSelectForm.AddMSItem(i18n("M15818", "Hizmet"), i18n("M15818", "Hizmet"), SupplyRequestTypeEnum.hizmet);
        mSelectForm.AddMSItem(i18n("M12780", "Diğer"), i18n("M12780", "Diğer"), SupplyRequestTypeEnum.diger);
        let mkey: string = await mSelectForm.GetMSItem(this, "Malzeme/Hizmet istek alım türünü seçiniz. ", true);
        if (String.isNullOrEmpty(mkey))
            throw new TTException((await SystemMessageService.GetMessageV2(369, i18n("M16613", "İstek alım türünü seçmeden işleme devam edemezsiniz."))));
        this._SupplyRequestPool.RequestType = <SupplyRequestTypeEnum>mSelectForm.MSSelectedItemObject;
        if (this._SupplyRequestPool.RequestType === SupplyRequestTypeEnum.demirbas || this._SupplyRequestPool.RequestType === SupplyRequestTypeEnum.Ilac || this._SupplyRequestPool.RequestType === SupplyRequestTypeEnum.sarfMalzeme)
            this.BaseMaterialGroupSupplyRequestPoolDetail.ListFilterExpression = "ISMATERIAL = 1";
        else if (this._SupplyRequestPool.RequestType === SupplyRequestTypeEnum.hizmet || this._SupplyRequestPool.RequestType === SupplyRequestTypeEnum.diger || this._SupplyRequestPool.RequestType === SupplyRequestTypeEnum.None)
            this.BaseMaterialGroupSupplyRequestPoolDetail.ListFilterExpression = "ISMATERIAL <> 1";
        else throw new TTException((await SystemMessageService.GetMessageV2(369, i18n("M16612", "İstek alım türünü Demirbaş,İlaç,Sarf Malzeme ve ya hizmet alımı seçilmeli."))));
        let output: GetSupplyReqDetsByStoreAndDemandType_Output = (await SupplyRequestDetailService.GetSupplyReqDetsByStoreAndDemandType(this._SupplyRequestPool.Store.ObjectID, this._SupplyRequestPool.RequestType.Value));
        for (let poolDet of output.supplyRequestPoolDetails) {
            let disttype: Guid = <any>poolDet["DistributionType"];
            let dist: any = await this.objectContextService.getObject(disttype, DistributionTypeDefinition.ObjectDefID);
            poolDet.DistributionType = dist;
            let mat: Guid = <any>poolDet["Material"];
            let material: any = await this.objectContextService.getObject(mat, Material.ObjectDefID);
            poolDet.Material = material;
            poolDet.SupplyRqstPlDetStatus = SupplyRqstPlDetStatusEnum.ToBeSent;
            this.supplyRequestPoolNewFormViewModel.SupplyRequestPoolDetailsGridList.push(poolDet);
        }
        //this.supplyRequestPoolNewFormViewModel.SupplyRequestPoolDetailsGridList = output.supplyRequestPoolDetails;
        this.supplyRequestPoolNewFormViewModel.SupplyRequestDetails = output.supplyRequestDetails;
    }

    protected async PreScript() {


    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SupplyRequestPool();
        this.supplyRequestPoolNewFormViewModel = new SupplyRequestPoolNewFormViewModel();
        this._ViewModel = this.supplyRequestPoolNewFormViewModel;
        this.supplyRequestPoolNewFormViewModel._SupplyRequestPool = this._TTObject as SupplyRequestPool;
        this.supplyRequestPoolNewFormViewModel._SupplyRequestPool.SupplyRequestPoolDetails = new Array<SupplyRequestPoolDetail>();
        this.supplyRequestPoolNewFormViewModel._SupplyRequestPool.Store = new Store();
        this.supplyRequestPoolNewFormViewModel._SupplyRequestPool.SignUser = new ResUser();
    }

    protected loadViewModel() {
        let that = this;

        that.supplyRequestPoolNewFormViewModel = this._ViewModel as SupplyRequestPoolNewFormViewModel;
        that._TTObject = this.supplyRequestPoolNewFormViewModel._SupplyRequestPool;
        if (this.supplyRequestPoolNewFormViewModel == null)
            this.supplyRequestPoolNewFormViewModel = new SupplyRequestPoolNewFormViewModel();
        if (this.supplyRequestPoolNewFormViewModel._SupplyRequestPool == null)
            this.supplyRequestPoolNewFormViewModel._SupplyRequestPool = new SupplyRequestPool();
        that.supplyRequestPoolNewFormViewModel._SupplyRequestPool.SupplyRequestPoolDetails = that.supplyRequestPoolNewFormViewModel.SupplyRequestPoolDetailsGridList;
        for (let detailItem of that.supplyRequestPoolNewFormViewModel.SupplyRequestPoolDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.supplyRequestPoolNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
            let distributionTypeObjectID = detailItem["DistributionType"];
            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                let distributionType = that.supplyRequestPoolNewFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                 if (distributionType) {
                    detailItem.DistributionType = distributionType;
                }
            }
        }
        let storeObjectID = that.supplyRequestPoolNewFormViewModel._SupplyRequestPool["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.supplyRequestPoolNewFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.supplyRequestPoolNewFormViewModel._SupplyRequestPool.Store = store;
            }
        }
        let signUserObjectID = that.supplyRequestPoolNewFormViewModel._SupplyRequestPool["SignUser"];
        if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
            let signUser = that.supplyRequestPoolNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
             if (signUser) {
                that.supplyRequestPoolNewFormViewModel._SupplyRequestPool.SignUser = signUser;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(SupplyRequestPoolNewFormViewModel);
        this.FormCaption = i18n("M21374", "Satınalma Talepleri Havuzu ( Yeni )");
        this.changeDetectorRef.detectChanges();
  
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

    SupplyRequestPoolDetails_CellContentClickEmitted(data: any){}

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
        this.IsImmediate.Name = "IsImmediate";
        this.IsImmediate.TabIndex = 12;
        this.IsImmediate.Title = "ACİL İSTEK";

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
        this.SupplyRequestPoolDetailBtn.Visible = false;

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
        this.TotalRequestAmountSupplyRequestPoolDetail.Width = 120;
        this.TotalRequestAmountSupplyRequestPoolDetail.IsNumeric = true;

        this.AmountSupplyRequestPoolDetail = new TTVisual.TTTextBoxColumn();
        this.AmountSupplyRequestPoolDetail.DataMember = "Amount";
        this.AmountSupplyRequestPoolDetail.DisplayIndex = 4;
        this.AmountSupplyRequestPoolDetail.HeaderText = i18n("M16708", "İstenecek Miktar");
        this.AmountSupplyRequestPoolDetail.Name = "AmountSupplyRequestPoolDetail";
        this.AmountSupplyRequestPoolDetail.ReadOnly = true;
        this.AmountSupplyRequestPoolDetail.Width = 120;
        this.AmountSupplyRequestPoolDetail.IsNumeric = true;

        this.PurchaseAmountSupplyRequestPoolDetail = new TTVisual.TTTextBoxColumn();
        this.PurchaseAmountSupplyRequestPoolDetail.DataMember = "PurchaseAmount";
        this.PurchaseAmountSupplyRequestPoolDetail.Required = true;
        this.PurchaseAmountSupplyRequestPoolDetail.DisplayIndex = 5;
        this.PurchaseAmountSupplyRequestPoolDetail.HeaderText = i18n("M21358", "Satınalma Miktarı");
        this.PurchaseAmountSupplyRequestPoolDetail.Name = "PurchaseAmountSupplyRequestPoolDetail";
        this.PurchaseAmountSupplyRequestPoolDetail.Width = 120;
        this.PurchaseAmountSupplyRequestPoolDetail.IsNumeric = true;

        this.ExcessAmountSupplyRequestPoolDetail = new TTVisual.TTTextBoxColumn();
        this.ExcessAmountSupplyRequestPoolDetail.DataMember = "ExcessAmount";
        this.ExcessAmountSupplyRequestPoolDetail.DisplayIndex = 6;
        this.ExcessAmountSupplyRequestPoolDetail.HeaderText = i18n("M15972", "I.F. ile Temin");
        this.ExcessAmountSupplyRequestPoolDetail.Name = "ExcessAmountSupplyRequestPoolDetail";
        this.ExcessAmountSupplyRequestPoolDetail.Width = 120;

        this.MKYSExcessQueryBtn = new TTVisual.TTButtonColumn();
        this.MKYSExcessQueryBtn.Text = i18n("M22125", "Sorgula");
        this.MKYSExcessQueryBtn.DisplayIndex = 7;
        this.MKYSExcessQueryBtn.HeaderText = "MKYS I.F. Sorgu";
        this.MKYSExcessQueryBtn.Name = "MKYSExcessQueryBtn";
        this.MKYSExcessQueryBtn.Width = 150;
        this.MKYSExcessQueryBtn.Visible = false;

        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail = new TTVisual.TTEnumComboBoxColumn();
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.DataTypeName = "SupplyRqstPlDetStatusEnum";
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.DataMember = "SupplyRqstPlDetStatus";
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.DisplayIndex = 8;
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.HeaderText = i18n("M22692", "Talep Durumu");
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.Name = "SupplyRqstPlDetStatusSupplyRequestPoolDetail";
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.Width = 180;

        this.DetailDescriptionSupplyRequestPoolDetail = new TTVisual.TTTextBoxColumn();
        this.DetailDescriptionSupplyRequestPoolDetail.DataMember = "DetailDescription";
        this.DetailDescriptionSupplyRequestPoolDetail.Required = true;
        this.DetailDescriptionSupplyRequestPoolDetail.DisplayIndex = 9;
        this.DetailDescriptionSupplyRequestPoolDetail.HeaderText = i18n("M10469", "Açıklama");
        this.DetailDescriptionSupplyRequestPoolDetail.Name = "DetailDescriptionSupplyRequestPoolDetail";
        this.DetailDescriptionSupplyRequestPoolDetail.Width = 150;

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
        this.SignUser.BackColor = "#FFE3C6";

        this.labelSignUser = new TTVisual.TTLabel();
        this.labelSignUser.Text = i18n("M16666", "İstek Yapan Personel");
        this.labelSignUser.Name = "labelSignUser";
        this.labelSignUser.TabIndex = 15;

        this.SupplyRequestPoolDetailsColumns = [this.SupplyRequestPoolDetailBtn, this.BaseMaterialGroupSupplyRequestPoolDetail, this.DistributionTypeSupplyRequestPoolDetail, this.TotalRequestAmountSupplyRequestPoolDetail, this.AmountSupplyRequestPoolDetail, this.PurchaseAmountSupplyRequestPoolDetail, this.ExcessAmountSupplyRequestPoolDetail, this.MKYSExcessQueryBtn, this.SupplyRqstPlDetStatusSupplyRequestPoolDetail, this.DetailDescriptionSupplyRequestPoolDetail];
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
