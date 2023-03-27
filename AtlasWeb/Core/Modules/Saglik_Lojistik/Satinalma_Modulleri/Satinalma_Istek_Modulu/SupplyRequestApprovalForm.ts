//$A799A8F6
import { Component, OnInit, NgZone } from '@angular/core';
import { SupplyRequestApprovalFormViewModel } from './SupplyRequestApprovalFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseSupplyRequest } from "Modules/Saglik_Lojistik/Satinalma_Modulleri/Satinalma_Istek_Modulu/BaseSupplyRequest";
import { SupplyRequest } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRequestDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';



@Component({
    selector: 'SupplyRequestApprovalForm',
    templateUrl: './SupplyRequestApprovalForm.html',
    providers: [MessageService]
})
export class SupplyRequestApprovalForm extends BaseSupplyRequest implements OnInit {
    public SupplyRequestDetailsColumns = [];
    public supplyRequestApprovalFormViewModel: SupplyRequestApprovalFormViewModel = new SupplyRequestApprovalFormViewModel();
    public get _SupplyRequest(): SupplyRequest {
        return this._TTObject as SupplyRequest;
    }
    private SupplyRequestApprovalForm_DocumentUrl: string = '/api/SupplyRequestService/SupplyRequestApprovalForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.SupplyRequestApprovalForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SupplyRequest();
        this.supplyRequestApprovalFormViewModel = new SupplyRequestApprovalFormViewModel();
        this._ViewModel = this.supplyRequestApprovalFormViewModel;
        this.supplyRequestApprovalFormViewModel._SupplyRequest = this._TTObject as SupplyRequest;
        this.supplyRequestApprovalFormViewModel._SupplyRequest.SignUser = new ResUser();
        this.supplyRequestApprovalFormViewModel._SupplyRequest.DestinationStore = new Store();
        this.supplyRequestApprovalFormViewModel._SupplyRequest.SupplyRequestDetails = new Array<SupplyRequestDetail>();
        this.supplyRequestApprovalFormViewModel._SupplyRequest.Store = new Store();
    }

    protected loadViewModel() {
        let that = this;

        that.supplyRequestApprovalFormViewModel = this._ViewModel as SupplyRequestApprovalFormViewModel;
        that._TTObject = this.supplyRequestApprovalFormViewModel._SupplyRequest;
        if (this.supplyRequestApprovalFormViewModel == null)
            this.supplyRequestApprovalFormViewModel = new SupplyRequestApprovalFormViewModel();
        if (this.supplyRequestApprovalFormViewModel._SupplyRequest == null)
            this.supplyRequestApprovalFormViewModel._SupplyRequest = new SupplyRequest();
        let signUserObjectID = that.supplyRequestApprovalFormViewModel._SupplyRequest["SignUser"];
        if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
            let signUser = that.supplyRequestApprovalFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
             if (signUser) {
                that.supplyRequestApprovalFormViewModel._SupplyRequest.SignUser = signUser;
            }
        }
        let destinationStoreObjectID = that.supplyRequestApprovalFormViewModel._SupplyRequest["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.supplyRequestApprovalFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
             if (destinationStore) {
                that.supplyRequestApprovalFormViewModel._SupplyRequest.DestinationStore = destinationStore;
            }
        }
        that.supplyRequestApprovalFormViewModel._SupplyRequest.SupplyRequestDetails = that.supplyRequestApprovalFormViewModel.SupplyRequestDetailsGridList;
        for (let detailItem of that.supplyRequestApprovalFormViewModel.SupplyRequestDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.supplyRequestApprovalFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
            let purchaseGroupObjectID = detailItem["PurchaseGroup"];
            if (purchaseGroupObjectID != null && (typeof purchaseGroupObjectID === 'string')) {
                let purchaseGroup = that.supplyRequestApprovalFormViewModel.PurchaseGroups.find(o => o.ObjectID.toString() === purchaseGroupObjectID.toString());
                 if (purchaseGroup) {
                    detailItem.PurchaseGroup = purchaseGroup;
                }
            }
            let distributionTypeObjectID = detailItem["DistributionType"];
            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                let distributionType = that.supplyRequestApprovalFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                 if (distributionType) {
                    detailItem.DistributionType = distributionType;
                }
            }
        }
        let storeObjectID = that.supplyRequestApprovalFormViewModel._SupplyRequest["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.supplyRequestApprovalFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.supplyRequestApprovalFormViewModel._SupplyRequest.Store = store;
            }
        }
    }


    protected async PostScript(transDef: TTObjectStateTransitionDef) {

        for (let detIn of this._SupplyRequest.SupplyRequestDetails) {
            if (detIn.RequestAmount <= 0)
                throw Error(detIn.Material.Name + " için " + detIn.RequestAmount + i18n("M14602", " geçersiz bir değerdir!"));
            if (detIn.PurchaseAmount <= 0)
                throw Error(detIn.Material.Name + " için " + detIn.PurchaseAmount + i18n("M14602", " geçersiz bir değerdir!"));
        }

    }

    async ngOnInit()  {
        let that = this;
        await this.load(SupplyRequestApprovalFormViewModel);
        this.FormCaption = i18n("M21366", "Satınalma Talep  ( Onay )");
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._SupplyRequest != null && this._SupplyRequest.ActionDate != event) {
                this._SupplyRequest.ActionDate = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._SupplyRequest != null && this._SupplyRequest.Description != event) {
                this._SupplyRequest.Description = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._SupplyRequest != null && this._SupplyRequest.DestinationStore != event) {
                this._SupplyRequest.DestinationStore = event;
            }
        }
    }

    public onIsImmediateChanged(event): void {
        if (event != null) {
            if (this._SupplyRequest != null && this._SupplyRequest.IsImmediate != event) {
                this._SupplyRequest.IsImmediate = event;
            }
        }
    }

    public onRequestTypeChanged(event): void {
        if (event != null) {
            if (this._SupplyRequest != null && this._SupplyRequest.RequestType != event) {
                this._SupplyRequest.RequestType = event;
            }
        }
    }

    public onSignUserChanged(event): void {
        if (event != null) {
            if (this._SupplyRequest != null && this._SupplyRequest.SignUser != event) {
                this._SupplyRequest.SignUser = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._SupplyRequest != null && this._SupplyRequest.StockActionID != event) {
                this._SupplyRequest.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._SupplyRequest != null && this._SupplyRequest.Store != event) {
                this._SupplyRequest.Store = event;
            }
        }
    }


    SupplyRequestDetails_CellValueChangedEmitted(data: any) {
        if (data && this.SupplyRequestDetails_CellValueChangedEmitted && data.Row && data.Column) {
            this.SupplyRequestDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }
    public async SupplyRequestDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.SupplyRequestDetails_CellValueChanged(data, rowIndex, columnIndex);
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
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.RequestType, "Value", this.__ttObject, "RequestType");
        redirectProperty(this.IsImmediate, "Value", this.__ttObject, "IsImmediate");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.IsImmediate = new TTVisual.TTCheckBox();
        this.IsImmediate.Value = false;
        this.IsImmediate.Name = "IsImmediate";
        this.IsImmediate.TabIndex = 16;
        this.IsImmediate.Title = "ACİL İSTEK";

        this.labelSignUser = new TTVisual.TTLabel();
        this.labelSignUser.Text = i18n("M16666", "İstek Yapan Personel");
        this.labelSignUser.Name = "labelSignUser";
        this.labelSignUser.TabIndex = 15;

        this.SignUser = new TTVisual.TTObjectListBox();
        this.SignUser.Required = true;
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.Name = "SignUser";
        this.SignUser.TabIndex = 14;

        this.RequestType = new TTVisual.TTEnumComboBox();
        this.RequestType.DataTypeName = "SupplyRequestTypeEnum";
        this.RequestType.BackColor = "#F0F0F0";
        this.RequestType.Enabled = false;
        this.RequestType.Name = "RequestType";
        this.RequestType.TabIndex = 13;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M16675", "İstek Yapılan Ana Depo");
        this.labelDestinationStore.Name = "labelDestinationStore";
        this.labelDestinationStore.TabIndex = 12;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ReadOnly = true;
        this.DestinationStore.ListDefName = "MainStoreList";
        this.DestinationStore.Name = "DestinationStore";
        this.DestinationStore.TabIndex = 11;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M16616", "İstek Detayları");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 10;

        this.SupplyRequestDetails = new TTVisual.TTGrid();
        this.SupplyRequestDetails.Name = "SupplyRequestDetails";
        this.SupplyRequestDetails.TabIndex = 0;
        this.SupplyRequestDetails.Height = 350;

        this.MaterialSupplyRequestDetail = new TTVisual.TTListBoxColumn();
        this.MaterialSupplyRequestDetail.ListDefName = "MaterialListDefinition";
        this.MaterialSupplyRequestDetail.DataMember = "Material";
        this.MaterialSupplyRequestDetail.DisplayIndex = 0;
        this.MaterialSupplyRequestDetail.HeaderText = i18n("M18545", "Malzeme");
        this.MaterialSupplyRequestDetail.Name = "MaterialSupplyRequestDetail";
        this.MaterialSupplyRequestDetail.Width = 300;

        this.PurchaseGroupSupplyRequestDetail = new TTVisual.TTListBoxColumn();
        this.PurchaseGroupSupplyRequestDetail.ListDefName = "PurchaseGroupList";
        this.PurchaseGroupSupplyRequestDetail.DataMember = "PurchaseGroup";
        this.PurchaseGroupSupplyRequestDetail.DisplayIndex = 1;
        this.PurchaseGroupSupplyRequestDetail.HeaderText = i18n("M16627", "İstek Kalemi");
        this.PurchaseGroupSupplyRequestDetail.Name = "PurchaseGroupSupplyRequestDetail";
        this.PurchaseGroupSupplyRequestDetail.Visible = false;
        this.PurchaseGroupSupplyRequestDetail.Width = 250;

        this.DistributionTypeSupplyRequestDetail = new TTVisual.TTTextBoxColumn();
        //this.DistributionTypeSupplyRequestDetail.ListDefName = "DistributionTypeList";
        this.DistributionTypeSupplyRequestDetail.DataMember = "Material.DistributionTypeName";
        this.DistributionTypeSupplyRequestDetail.DisplayIndex = 2;
        this.DistributionTypeSupplyRequestDetail.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionTypeSupplyRequestDetail.Name = "DistributionTypeSupplyRequestDetail";
        this.DistributionTypeSupplyRequestDetail.Width = 120;

        this.RequestAmountSupplyRequestDetail = new TTVisual.TTTextBoxColumn();
        this.RequestAmountSupplyRequestDetail.DataMember = "RequestAmount";
        this.RequestAmountSupplyRequestDetail.DisplayIndex = 3;
        this.RequestAmountSupplyRequestDetail.HeaderText = i18n("M16632", "İstek Miktarı");
        this.RequestAmountSupplyRequestDetail.Name = "RequestAmountSupplyRequestDetail";
        this.RequestAmountSupplyRequestDetail.Width = 120;
        this.RequestAmountSupplyRequestDetail.IsNumeric = true;

        this.PurchaseAmountSupplyRequestDetail = new TTVisual.TTTextBoxColumn();
        this.PurchaseAmountSupplyRequestDetail.DataMember = "PurchaseAmount";
        this.PurchaseAmountSupplyRequestDetail.DisplayIndex = 4;
        this.PurchaseAmountSupplyRequestDetail.HeaderText = i18n("M21358", "Satınalma Miktarı");
        this.PurchaseAmountSupplyRequestDetail.Name = "PurchaseAmountSupplyRequestDetail";
        this.PurchaseAmountSupplyRequestDetail.Width = 140;
        this.PurchaseAmountSupplyRequestDetail.IsNumeric = true;

        this.SupplyRequestStatusSupplyRequestDetail = new TTVisual.TTEnumComboBoxColumn();
        this.SupplyRequestStatusSupplyRequestDetail.DataTypeName = "SupplyRequestStatusEnum";
        this.SupplyRequestStatusSupplyRequestDetail.DataMember = "SupplyRequestStatus";
        this.SupplyRequestStatusSupplyRequestDetail.DisplayIndex = 5;
        this.SupplyRequestStatusSupplyRequestDetail.HeaderText = i18n("M22962", "Tedarik Talep Durumu");
        this.SupplyRequestStatusSupplyRequestDetail.Name = "SupplyRequestStatusSupplyRequestDetail";
        this.SupplyRequestStatusSupplyRequestDetail.Width = 160;

        this.DetailDescriptionSupplyRequestDetail = new TTVisual.TTTextBoxColumn();
        this.DetailDescriptionSupplyRequestDetail.DataMember = "DetailDescription";
        this.DetailDescriptionSupplyRequestDetail.DisplayIndex = 6;
        this.DetailDescriptionSupplyRequestDetail.HeaderText = i18n("M10469", "Açıklama");
        this.DetailDescriptionSupplyRequestDetail.Name = "DetailDescriptionSupplyRequestDetail";
        this.DetailDescriptionSupplyRequestDetail.Width = 200;

        this.MKYSExcessQueryBtn = new TTVisual.TTButtonColumn();
        this.MKYSExcessQueryBtn.Text = i18n("M22125", "Sorgula");
        this.MKYSExcessQueryBtn.DisplayIndex = 7;
        this.MKYSExcessQueryBtn.HeaderText = "MKYS İ.F. Sorgulama";
        this.MKYSExcessQueryBtn.Name = "MKYSExcessQueryBtn";
        this.MKYSExcessQueryBtn.Width = 140;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M16660", "İstek Yapan Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 9;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "StoreListDefinition";
        this.Store.Name = "Store";
        this.Store.TabIndex = 8;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 7;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 6;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 5;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 4;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 2;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M22694", "Talep Gerekçesi");
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 3;

        this.labelRequestType = new TTVisual.TTLabel();
        this.labelRequestType.Text = i18n("M10698", "Alım Türü");
        this.labelRequestType.Name = "labelRequestType";
        this.labelRequestType.TabIndex = 1;

        this.SupplyRequestDetailsColumns = [this.MaterialSupplyRequestDetail, this.PurchaseGroupSupplyRequestDetail, this.DistributionTypeSupplyRequestDetail, this.RequestAmountSupplyRequestDetail, this.PurchaseAmountSupplyRequestDetail, this.SupplyRequestStatusSupplyRequestDetail, this.DetailDescriptionSupplyRequestDetail];
        this.ttgroupbox1.Controls = [this.SupplyRequestDetails];
        this.Controls = [this.IsImmediate, this.labelSignUser, this.SignUser, this.RequestType, this.labelDestinationStore, this.DestinationStore, this.ttgroupbox1, this.SupplyRequestDetails, this.MaterialSupplyRequestDetail, this.PurchaseGroupSupplyRequestDetail, this.DistributionTypeSupplyRequestDetail, this.RequestAmountSupplyRequestDetail, this.PurchaseAmountSupplyRequestDetail, this.SupplyRequestStatusSupplyRequestDetail, this.DetailDescriptionSupplyRequestDetail, this.MKYSExcessQueryBtn, this.labelStore, this.Store, this.labelActionDate, this.ActionDate, this.labelStockActionID, this.StockActionID, this.Description, this.labelDescription, this.labelRequestType];

    }


}
