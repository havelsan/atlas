//$331B6D5F
import { Component, OnInit  } from '@angular/core';
import { StockOutFormViewModel } from './StockOutFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { StockOut } from 'NebulaClient/Model/AtlasClientModel';
import { StockOutMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { StockActionService } from 'app/NebulaClient/Services/ObjectService/StockActionService';


@Component({
    selector: 'StockOutForm',
    templateUrl: './StockOutForm.html',
    providers: [MessageService]
})
export class StockOutForm extends TTVisual.TTForm implements OnInit {
    Amount: TTVisual.ITTTextBoxColumn;
    Description: TTVisual.ITTTextBox;
    labelDescription: TTVisual.ITTLabel;
    labelStockActionID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelTransactionDate: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    Status: TTVisual.ITTEnumComboBoxColumn;
    StockActionID: TTVisual.ITTTextBox;
    StockActionOutDetails: TTVisual.ITTGrid;
    StockLevelType: TTVisual.ITTListBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    TransactionDate: TTVisual.ITTDateTimePicker;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    public StockActionOutDetailsColumns = [];
    public episodeActionID: string;
    public stockOutFormViewModel: StockOutFormViewModel = new StockOutFormViewModel();
    public get _StockOut(): StockOut {
        return this._TTObject as StockOut;
    }
    private StockOutForm_DocumentUrl: string = '/api/StockOutService/StockOutForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('STOCKOUT', 'StockOutForm');
        this._DocumentServiceUrl = this.StockOutForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PreScript(): Promise<void> {
        
        super.PreScript();
        this.DropStateButton(StockOut.StockOutStates.Cancelled);
    }

    protected async ClientSidePreScript(): Promise<void> {
        
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new StockOut();
        this.stockOutFormViewModel = new StockOutFormViewModel();
        this._ViewModel = this.stockOutFormViewModel;
        this.stockOutFormViewModel._StockOut = this._TTObject as StockOut;
        this.stockOutFormViewModel._StockOut.StockOutMaterials = new Array<StockOutMaterial>();
        this.stockOutFormViewModel._StockOut.Store = new Store();
    }

    protected loadViewModel() {
        let that = this;
        that.stockOutFormViewModel = this._ViewModel as StockOutFormViewModel;
        that._TTObject = this.stockOutFormViewModel._StockOut;
        if (this.stockOutFormViewModel == null)
            this.stockOutFormViewModel = new StockOutFormViewModel();
        if (this.stockOutFormViewModel._StockOut == null)
            this.stockOutFormViewModel._StockOut = new StockOut();
        that.stockOutFormViewModel._StockOut.StockOutMaterials = that.stockOutFormViewModel.StockActionOutDetailsGridList;
        for (let detailItem of that.stockOutFormViewModel.StockActionOutDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.stockOutFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === "string")) {
                let stockLevelType = that.stockOutFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                 if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        let storeObjectID = that.stockOutFormViewModel._StockOut["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.stockOutFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.stockOutFormViewModel._StockOut.Store = store;
            }
        }

    }

    async ngOnInit() {
        await this.load();
        this.episodeActionID = await StockActionService.GetEpisodeActionIDForStockOut(this._StockOut.ObjectID);
        this.FormCaption = i18n("M22292", "Stok Çıkış");
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._StockOut != null && this._StockOut.Description != event) {
                this._StockOut.Description = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._StockOut != null && this._StockOut.StockActionID != event) {
                this._StockOut.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._StockOut != null && this._StockOut.Store != event) {
                this._StockOut.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._StockOut != null && this._StockOut.TransactionDate != event) {
                this._StockOut.TransactionDate = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 5;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 6;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M18631", "Malzemeler");
        this.tttabpage1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage1.Name = "tttabpage1";

        this.StockActionOutDetails = new TTVisual.TTGrid();
        this.StockActionOutDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionOutDetails.Name = "StockActionOutDetails";
        this.StockActionOutDetails.TabIndex = 0;
        this.StockActionOutDetails.AllowUserToDeleteRows = false;
        this.StockActionOutDetails.AllowUserToAddRows = false;
        this.StockActionOutDetails.ReadOnly = true;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "MaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 0;
        this.Material.HeaderText = i18n("M18545", "Malzeme");
        this.Material.Name = "Material";
        this.Material.Width = 400;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 1;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Width = 80;

        this.StockLevelType = new TTVisual.TTListBoxColumn();
        this.StockLevelType.ListDefName = "StockLevelTypeList";
        this.StockLevelType.DataMember = "StockLevelType";
        this.StockLevelType.DisplayIndex = 2;
        this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelType.Name = "StockLevelType";
        this.StockLevelType.Width = 100;

        this.Status = new TTVisual.TTEnumComboBoxColumn();
        this.Status.DataTypeName = "StockActionDetailStatusEnum";
        this.Status.DataMember = "Status";
        this.Status.DisplayIndex = 3;
        this.Status.HeaderText = "Durum";
        this.Status.Name = "Status";
        this.Status.Width = 100;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M10469", "Açıklama");
        this.labelDescription.BackColor = "#F0F0F0";
        this.labelDescription.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelDescription.ForeColor = "#000000";
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 30;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.BackColor = "#F0F0F0";
        this.labelStockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelStockActionID.ForeColor = "#000000";
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 28;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ListDefName = "StoreListDefinition";
        this.Store.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Store.Name = "Store";
        this.Store.TabIndex = 2;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.CustomFormat = "";
        this.TransactionDate.Format = DateTimePickerFormat.Long;
        this.TransactionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.BackColor = "#F0F0F0";
        this.labelTransactionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelTransactionDate.ForeColor = "#000000";
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 34;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.BackColor = "#F0F0F0";
        this.labelStore.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelStore.ForeColor = "#000000";
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 37;

        this.StockActionOutDetailsColumns = [this.Material, this.Amount, this.StockLevelType, this.Status];
        this.tttabcontrol1.Controls = [this.tttabpage1];
        this.tttabpage1.Controls = [this.StockActionOutDetails];
        this.Controls = [this.Description, this.StockActionID, this.tttabcontrol1, this.tttabpage1, this.StockActionOutDetails, this.Material, this.Amount, this.StockLevelType, this.Status, this.labelDescription, this.labelStockActionID, this.Store, this.TransactionDate, this.labelTransactionDate, this.labelStore];

    }


}
