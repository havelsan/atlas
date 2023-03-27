//$42778D11
import { Component, OnInit, NgZone } from '@angular/core';
import { BaseSupplyRequestPoolFormViewModel } from './BaseSupplyRequestPoolFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { StockActionBaseForm } from "Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StockActionBaseForm";
import { SupplyRequestPool } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRequestPoolDetail } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRqstPlDetStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { IModalService } from "Fw/Services/IModalService";
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';


@Component({
    selector: 'BaseSupplyRequestPoolForm',
    templateUrl: './BaseSupplyRequestPoolForm.html',
    providers: [MessageService]
})
export class BaseSupplyRequestPoolForm extends StockActionBaseForm implements OnInit {
    AmountSupplyRequestPoolDetail: TTVisual.ITTTextBoxColumn;
    BaseMaterialGroupSupplyRequestPoolDetail: TTVisual.ITTListBoxColumn;
    DateOfSupply: TTVisual.ITTDateTimePicker;
    Description: TTVisual.ITTTextBox;
    DetailDescriptionSupplyRequestPoolDetail: TTVisual.ITTTextBoxColumn;
    DistributionTypeSupplyRequestPoolDetail: TTVisual.ITTTextBoxColumn;
    ExcessAmountSupplyRequestPoolDetail: TTVisual.ITTTextBoxColumn;
    IsImmediate: TTVisual.ITTCheckBox;
    labelDateOfSupply: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelRequestType: TTVisual.ITTLabel;
    labelSignUser: TTVisual.ITTLabel;
    labelStockActionID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelTransactionDate: TTVisual.ITTLabel;
    MKYSExcessQueryBtn: TTVisual.ITTButtonColumn;
    PurchaseAmountSupplyRequestPoolDetail: TTVisual.ITTTextBoxColumn;
    RequestType: TTVisual.ITTEnumComboBox;
    SignUser: TTVisual.ITTObjectListBox;
    StockActionID: TTVisual.ITTTextBox;
    Store: TTVisual.ITTObjectListBox;
    SupplyRequestPoolDetailBtn: TTVisual.ITTButtonColumn;
    SupplyRequestPoolDetails: TTVisual.ITTGrid;
    SupplyRqstPlDetStatusSupplyRequestPoolDetail: TTVisual.ITTEnumComboBoxColumn;
    TotalRequestAmountSupplyRequestPoolDetail: TTVisual.ITTTextBoxColumn;
    TransactionDate: TTVisual.ITTDateTimePicker;
    ttgroupbox1: TTVisual.ITTGroupBox;
    public SupplyRequestPoolDetailsColumns = [];
    public baseSupplyRequestPoolFormViewModel: BaseSupplyRequestPoolFormViewModel = new BaseSupplyRequestPoolFormViewModel();
    public get _SupplyRequestPool(): SupplyRequestPool {
        return this._TTObject as SupplyRequestPool;
    }
    private BaseSupplyRequestPoolForm_DocumentUrl: string = '/api/SupplyRequestPoolService/BaseSupplyRequestPoolForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected modalService: IModalService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseSupplyRequestPoolForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private showDetailOfPoolDetail(objID: string): Promise<ModalActionResult>
    {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "SupplyRqstPlDetailForm";
            componentInfo.ModuleName = "SatinalmaIstekModule";
            componentInfo.ModulePath = "/Modules/Saglik_Lojistik/Satinalma_Modulleri/Satinalma_Istek_Modulu/SatinalmaIstekModule";
            componentInfo.InputParam = new DynamicComponentInputParam(objID, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M21344", "Satınalma İstek Detay");
            modalInfo.Width = 1024;
            modalInfo.Height = 768;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public SupplyRequestPoolDetails_CellContentClick(data: any, rowIndex: number, columnIndex: number) {
        let that = this;
        if (data.Column.Text === i18n("M12671", "Detay")) {
            let supplyRequestPoolDetail: SupplyRequestPoolDetail = new SupplyRequestPoolDetail();
            let objID: string = (<SupplyRequestPoolDetail>data.Row.TTObject).ObjectID.toString();
            supplyRequestPoolDetail = <SupplyRequestPoolDetail>data.Row.TTObject;
            return new Promise<SupplyRequestPoolDetail>((resolve, reject) => {
                    this.showDetailOfPoolDetail(objID).then(result => {
                        let modalActionResult = result as ModalActionResult;
                        if (modalActionResult.Result == DialogResult.OK) {
                            supplyRequestPoolDetail = <SupplyRequestPoolDetail>modalActionResult.Param;
                            that._ViewModel._SupplyRequestPool.SupplyRequestPoolDetails[rowIndex].ExcessAmount = supplyRequestPoolDetail.ExcessAmount;
                            that._ViewModel._SupplyRequestPool.SupplyRequestPoolDetails[rowIndex].PurchaseAmount = supplyRequestPoolDetail.PurchaseAmount;
                               // this.objectContextService.getObject<SupplyRequestPoolDetail>(objGuid, SupplyRequestPoolDetail.ObjectDefID).then(mat => resolve(mat)).catch(error => reject(error));
                        } else {
                            resolve(null);
                        }
                    }).catch(err => reject(err));
            });
        }
        if (data.Column.Text === "MKYSExcessQueryBtn") {
            //  let detailForm: MKYSExcessForm = new MKYSExcessForm();
            //  detailForm.ShowEdit(this, (<SupplyRequestPoolDetail>this.SupplyRequestPoolDetails.CurrentCell.OwningRow.TTObject));
        }
    }
    public async SupplyRequestPoolDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        if (data.Column.Name === "ExcessAmountSupplyRequestPoolDetail") {
            let det: SupplyRequestPoolDetail = <SupplyRequestPoolDetail>data.Row.TTObject;
            if (det.ExcessAmount !== null || det.ExcessAmount.toString() !== "") {
                det.PurchaseAmount = det.Amount - det.ExcessAmount;
                if (det.PurchaseAmount <= 0) {
                    det.PurchaseAmount = 0;
                    det.SupplyRqstPlDetStatus = SupplyRqstPlDetStatusEnum.SupplyWithExcess;
                }
            }
            else {
                det.PurchaseAmount = det.Amount;
                det.SupplyRqstPlDetStatus = SupplyRqstPlDetStatusEnum.ToBeSent;
            }
        }
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SupplyRequestPool();
        this.baseSupplyRequestPoolFormViewModel = new BaseSupplyRequestPoolFormViewModel();
        this._ViewModel = this.baseSupplyRequestPoolFormViewModel;
        this.baseSupplyRequestPoolFormViewModel._SupplyRequestPool = this._TTObject as SupplyRequestPool;
        this.baseSupplyRequestPoolFormViewModel._SupplyRequestPool.SupplyRequestPoolDetails = new Array<SupplyRequestPoolDetail>();
        this.baseSupplyRequestPoolFormViewModel._SupplyRequestPool.Store = new Store();
        this.baseSupplyRequestPoolFormViewModel._SupplyRequestPool.SignUser = new ResUser();
    }

    protected loadViewModel() {
        let that = this;

        that.baseSupplyRequestPoolFormViewModel = this._ViewModel as BaseSupplyRequestPoolFormViewModel;
        that._TTObject = this.baseSupplyRequestPoolFormViewModel._SupplyRequestPool;
        if (this.baseSupplyRequestPoolFormViewModel == null)
            this.baseSupplyRequestPoolFormViewModel = new BaseSupplyRequestPoolFormViewModel();
        if (this.baseSupplyRequestPoolFormViewModel._SupplyRequestPool == null)
            this.baseSupplyRequestPoolFormViewModel._SupplyRequestPool = new SupplyRequestPool();
        that.baseSupplyRequestPoolFormViewModel._SupplyRequestPool.SupplyRequestPoolDetails = that.baseSupplyRequestPoolFormViewModel.SupplyRequestPoolDetailsGridList;
        for (let detailItem of that.baseSupplyRequestPoolFormViewModel.SupplyRequestPoolDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.baseSupplyRequestPoolFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
            let distributionTypeObjectID = detailItem["DistributionType"];
            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                let distributionType = that.baseSupplyRequestPoolFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                 if (distributionType) {
                    detailItem.DistributionType = distributionType;
                }
            }
        }
        let storeObjectID = that.baseSupplyRequestPoolFormViewModel._SupplyRequestPool["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.baseSupplyRequestPoolFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.baseSupplyRequestPoolFormViewModel._SupplyRequestPool.Store = store;
            }
        }
        let signUserObjectID = that.baseSupplyRequestPoolFormViewModel._SupplyRequestPool["SignUser"];
        if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
            let signUser = that.baseSupplyRequestPoolFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
             if (signUser) {
                that.baseSupplyRequestPoolFormViewModel._SupplyRequestPool.SignUser = signUser;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(BaseSupplyRequestPoolFormViewModel);
  
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

        this.IsImmediate = new TTVisual.TTCheckBox();
        this.IsImmediate.Value = false;
        this.IsImmediate.Text = "Acil";
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
        this.DistributionTypeSupplyRequestPoolDetail.Width = 100;

        this.TotalRequestAmountSupplyRequestPoolDetail = new TTVisual.TTTextBoxColumn();
        this.TotalRequestAmountSupplyRequestPoolDetail.DataMember = "TotalRequestAmount";
        this.TotalRequestAmountSupplyRequestPoolDetail.DisplayIndex = 3;
        this.TotalRequestAmountSupplyRequestPoolDetail.HeaderText = i18n("M23523", "Toplam Talep Miktarı");
        this.TotalRequestAmountSupplyRequestPoolDetail.Name = "TotalRequestAmountSupplyRequestPoolDetail";
        this.TotalRequestAmountSupplyRequestPoolDetail.ReadOnly = true;
        this.TotalRequestAmountSupplyRequestPoolDetail.Width = 80;

        this.AmountSupplyRequestPoolDetail = new TTVisual.TTTextBoxColumn();
        this.AmountSupplyRequestPoolDetail.DataMember = "Amount";
        this.AmountSupplyRequestPoolDetail.DisplayIndex = 4;
        this.AmountSupplyRequestPoolDetail.HeaderText = i18n("M16708", "İstenecek Miktar");
        this.AmountSupplyRequestPoolDetail.Name = "AmountSupplyRequestPoolDetail";
        this.AmountSupplyRequestPoolDetail.ReadOnly = true;
        this.AmountSupplyRequestPoolDetail.Width = 80;

        this.PurchaseAmountSupplyRequestPoolDetail = new TTVisual.TTTextBoxColumn();
        this.PurchaseAmountSupplyRequestPoolDetail.DataMember = "PurchaseAmount";
        this.PurchaseAmountSupplyRequestPoolDetail.Required = true;
        this.PurchaseAmountSupplyRequestPoolDetail.DisplayIndex = 5;
        this.PurchaseAmountSupplyRequestPoolDetail.HeaderText = i18n("M21358", "Satınalma Miktarı");
        this.PurchaseAmountSupplyRequestPoolDetail.Name = "PurchaseAmountSupplyRequestPoolDetail";
        this.PurchaseAmountSupplyRequestPoolDetail.Width = 100;

        this.ExcessAmountSupplyRequestPoolDetail = new TTVisual.TTTextBoxColumn();
        this.ExcessAmountSupplyRequestPoolDetail.DataMember = "ExcessAmount";
        this.ExcessAmountSupplyRequestPoolDetail.DisplayIndex = 6;
        this.ExcessAmountSupplyRequestPoolDetail.HeaderText = i18n("M15972", "I.F. ile Temin");
        this.ExcessAmountSupplyRequestPoolDetail.Name = "ExcessAmountSupplyRequestPoolDetail";
        this.ExcessAmountSupplyRequestPoolDetail.Width = 100;

        this.MKYSExcessQueryBtn = new TTVisual.TTButtonColumn();
        this.MKYSExcessQueryBtn.Text = i18n("M22125", "Sorgula");
        this.MKYSExcessQueryBtn.DisplayIndex = 7;
        this.MKYSExcessQueryBtn.HeaderText = "MKYS I.F. Sorgu";
        this.MKYSExcessQueryBtn.Name = "MKYSExcessQueryBtn";
        this.MKYSExcessQueryBtn.Width = 100;

        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail = new TTVisual.TTEnumComboBoxColumn();
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.DataTypeName = "SupplyRqstPlDetStatusEnum";
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.DataMember = "SupplyRqstPlDetStatus";
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.DisplayIndex = 8;
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.HeaderText = i18n("M22692", "Talep Durumu");
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.Name = "SupplyRqstPlDetStatusSupplyRequestPoolDetail";
        this.SupplyRqstPlDetStatusSupplyRequestPoolDetail.Width = 80;

        this.DetailDescriptionSupplyRequestPoolDetail = new TTVisual.TTTextBoxColumn();
        this.DetailDescriptionSupplyRequestPoolDetail.DataMember = "DetailDescription";
        this.DetailDescriptionSupplyRequestPoolDetail.Required = true;
        this.DetailDescriptionSupplyRequestPoolDetail.DisplayIndex = 9;
        this.DetailDescriptionSupplyRequestPoolDetail.HeaderText = i18n("M10469", "Açıklama");
        this.DetailDescriptionSupplyRequestPoolDetail.Name = "DetailDescriptionSupplyRequestPoolDetail";
        this.DetailDescriptionSupplyRequestPoolDetail.Width = 80;

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

        this.SupplyRequestPoolDetailsColumns = [this.SupplyRequestPoolDetailBtn, this.BaseMaterialGroupSupplyRequestPoolDetail, this.DistributionTypeSupplyRequestPoolDetail, this.TotalRequestAmountSupplyRequestPoolDetail, this.AmountSupplyRequestPoolDetail, this.PurchaseAmountSupplyRequestPoolDetail, this.ExcessAmountSupplyRequestPoolDetail, this.MKYSExcessQueryBtn, this.SupplyRqstPlDetStatusSupplyRequestPoolDetail, this.DetailDescriptionSupplyRequestPoolDetail];
        this.ttgroupbox1.Controls = [this.SupplyRequestPoolDetails];
        this.Controls = [this.labelDateOfSupply, this.DateOfSupply, this.IsImmediate, this.labelRequestType, this.RequestType, this.ttgroupbox1, this.SupplyRequestPoolDetails, this.SupplyRequestPoolDetailBtn, this.BaseMaterialGroupSupplyRequestPoolDetail, this.DistributionTypeSupplyRequestPoolDetail, this.TotalRequestAmountSupplyRequestPoolDetail, this.AmountSupplyRequestPoolDetail, this.PurchaseAmountSupplyRequestPoolDetail, this.ExcessAmountSupplyRequestPoolDetail, this.MKYSExcessQueryBtn, this.SupplyRqstPlDetStatusSupplyRequestPoolDetail, this.DetailDescriptionSupplyRequestPoolDetail, this.labelStore, this.Store, this.labelTransactionDate, this.TransactionDate, this.labelStockActionID, this.StockActionID, this.Description, this.labelDescription, this.SignUser, this.labelSignUser];

    }


}
