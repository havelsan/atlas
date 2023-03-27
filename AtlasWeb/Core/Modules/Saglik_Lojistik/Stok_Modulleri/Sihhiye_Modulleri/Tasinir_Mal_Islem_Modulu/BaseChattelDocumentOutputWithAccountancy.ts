//$E728B910
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { BaseChattelDocumentOutputWithAccountancyViewModel } from './BaseChattelDocumentOutputWithAccountancyViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Accountancy, OuttableLot } from 'NebulaClient/Model/AtlasClientModel';
import { BaseChattelDocumentForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentForm";
import { ChattelDocumentOutputWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelService } from "ObjectClassService/StockLevelService";
import { ChattelDocumentOutputDetailWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { StockLevelTypeService } from "ObjectClassService/StockLevelTypeService";
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MaterialService } from "ObjectClassService/MaterialService";
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DxDataGridComponent } from 'devextreme-angular';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";



@Component({
    selector: 'BaseChattelDocumentOutputWithAccountancy',
    templateUrl: './BaseChattelDocumentOutputWithAccountancy.html',
    providers: [MessageService]
})
export class BaseChattelDocumentOutputWithAccountancy extends BaseChattelDocumentForm implements OnInit {
    Accountancy: TTVisual.ITTObjectListBox;
    AmountChattelDocumentDetailWithAccountancy: TTVisual.ITTTextBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    ChattelDocumentDetailsWithAccountancy: TTVisual.ITTGrid;
    ChattelDocumentTabcontrol: TTVisual.ITTTabControl;
    ChattelDocumentTabpage: TTVisual.ITTTabPage;
    Detail: TTVisual.ITTButtonColumn;
    DistributionType: TTVisual.ITTTextBoxColumn;
    labelAccountancy: TTVisual.ITTLabel;
    labeloutputStockMovementType: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelWaybill: TTVisual.ITTLabel;
    labelWaybillDate: TTVisual.ITTLabel;
    lblMKYS_CikisIslemTuru: TTVisual.ITTLabel;
    lblMKYS_CikisStokHareketTuru: TTVisual.ITTLabel;
    MaterialChattelDocumentDetailWithAccountancy: TTVisual.ITTListBoxColumn;
    MKYS_CikisIslemTuru: TTVisual.ITTEnumComboBox;
    MKYS_CikisStokHareketTuru: TTVisual.ITTEnumComboBox;
    outputStockMovementType: TTVisual.ITTEnumComboBox;
    Price: TTVisual.ITTTextBoxColumn;
    StatusChattelDocumentDetailWithAccountancy: TTVisual.ITTEnumComboBoxColumn;
    StockLevelTypeChattelDocumentDetailWithAccountancy: TTVisual.ITTListBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    StoreStock: TTVisual.ITTTextBoxColumn;
    UnitPrice: TTVisual.ITTTextBoxColumn;
    Waybill: TTVisual.ITTTextBox;
    WaybillDate: TTVisual.ITTDateTimePicker;
    InvoiceNumberSec: TTVisual.ITTTextBox;

    ValueAddedTax: TTVisual.ITTTextBoxColumn;
    IsContainsContributions: TTVisual.ITTCheckBox;

    public StockActionSignDetailsColumns = [];
    public baseChattelDocumentOutputWithAccountancyViewModel: BaseChattelDocumentOutputWithAccountancyViewModel = new BaseChattelDocumentOutputWithAccountancyViewModel();

    //#region dx-data-grid çevirme
    public selectedMaterial: Material;
    public selectedStockLevelType: StockLevelType;
    public stockLeveltypeArray: Array<StockLevelType> = new Array<StockLevelType>();

    public get _ChattelDocumentOutputWithAccountancy(): ChattelDocumentOutputWithAccountancy {
        return this._TTObject as ChattelDocumentOutputWithAccountancy;
    }
    private BaseChattelDocumentOutputWithAccountancy_DocumentUrl: string = '/api/ChattelDocumentOutputWithAccountancyService/BaseChattelDocumentOutputWithAccountancy';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseChattelDocumentOutputWithAccountancy_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    public onMaterialGridRowRemoved(event: any) {
    }

    public onMaterialGridRowUpdated(event: any) {
        //console.log(event);
        let data = <ChattelDocumentOutputDetailWithAccountancy>event.key;
        //let detail: ChattelDocumentInputDetailWithAccountancy = <ChattelDocumentInputDetailWithAccountancy>data.Row.TTObject;
        if (data.Amount <= 0) {
            ServiceLocator.MessageService.showError('Miktar Birim Fiyat sıfırdan küçük olamaz!');
            event.cancel = true;
            return;
        }
        if (data.VatRate < 0) {
            ServiceLocator.MessageService.showError('KDV Oranı sıfırdan küçük olamaz!');
            event.cancel = true;
            return;
        }

    }

    public async onMaterialSelectionChange(event: any) {
        if (this.stockLeveltypeArray.length == 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
        if (this.selectedMaterial == null)
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        else {
            let newRow: ChattelDocumentOutputDetailWithAccountancy = new ChattelDocumentOutputDetailWithAccountancy();
            newRow.Material = this.selectedMaterial;
            newRow.StockLevelType = this.selectedStockLevelType;
            newRow.Status = StockActionDetailStatusEnum.New;
            newRow.IsNew = true;

            if (this._ChattelDocumentOutputWithAccountancy.TransactionDate != null)
                newRow.VatRate = await MaterialService.GetVatrateFromMaterialTS(this.selectedMaterial, this._ChattelDocumentOutputWithAccountancy.TransactionDate);

            if (this.selectedStockLevelType != null) {
                let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(this.selectedMaterial.ObjectID, this._ChattelDocumentOutputWithAccountancy.Store.ObjectID, this.selectedStockLevelType.ObjectID);
                newRow.StoreStock = stockInheld;
            }

            this._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy.push(newRow);
        }
    }

    onStockLevelTypeChange(event: any) {

    }
    public async btnAddClick() {
        if (this.selectedMaterial == null)
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        else {
            let newRow: ChattelDocumentOutputDetailWithAccountancy = new ChattelDocumentOutputDetailWithAccountancy();
            newRow.Material = this.selectedMaterial;
            newRow.StockLevelType = this.selectedStockLevelType;
            newRow.Status = StockActionDetailStatusEnum.New;
            newRow.IsNew = true;

            if (this._ChattelDocumentOutputWithAccountancy.TransactionDate != null)
                newRow.VatRate = await MaterialService.GetVatrateFromMaterialTS(this.selectedMaterial, this._ChattelDocumentOutputWithAccountancy.TransactionDate);

            if (this.selectedStockLevelType != null) {
                let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(this.selectedMaterial.ObjectID, this._ChattelDocumentOutputWithAccountancy.Store.ObjectID, this.selectedStockLevelType.ObjectID);
                newRow.StoreStock = stockInheld;
            }

            this._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy.push(newRow);
        }

    }

    private async Accountancy_SelectedObjectChanged(): Promise<void> {
        // this._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy.DeleteChildren();
    }
    private async ChattelDocumentDetailsWithAccountancy_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        if (this.ChattelDocumentDetailsWithAccountancy.CurrentCell.OwningColumn.Name === "Detail")
            this.ShowStockActionDetailForm(<StockActionDetail>this.ChattelDocumentDetailsWithAccountancy.CurrentCell.OwningRow.TTObject);
    }
    private async ChattelDocumentDetailsWithAccountancy_CellDoubleClick(rowIndex: number, columnIndex: number): Promise<void> {
        this.CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, this.ChattelDocumentDetailsWithAccountancy);
    }
    public async ChattelDocumentDetailsWithAccountancy_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        let chattelDocumentOutputDetailWithAccountancy: ChattelDocumentOutputDetailWithAccountancy = <ChattelDocumentOutputDetailWithAccountancy>(data.Row.TTObject);
        if (chattelDocumentOutputDetailWithAccountancy.Status === undefined) {
            chattelDocumentOutputDetailWithAccountancy.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            chattelDocumentOutputDetailWithAccountancy.StockLevelType = stockLeveltypeArray[0];
        }


        if (data.Column.Name === "MaterialChattelDocumentDetailWithAccountancy") {
            if (this._ChattelDocumentOutputWithAccountancy.TransactionDate !== null && chattelDocumentOutputDetailWithAccountancy.Material !== null) {
                chattelDocumentOutputDetailWithAccountancy.VatRate = 0; //await MaterialService.GetVatrateFromMaterialTS(chattelDocumentOutputDetailWithAccountancy.Material, this._ChattelDocumentOutputWithAccountancy.TransactionDate);
            }
        }


        if (data.Column.Name === "MaterialChattelDocumentDetailWithAccountancy" || data.Column.Name === "StockLevelTypeChattelDocumentDetailWithAccountancy") {
            if (chattelDocumentOutputDetailWithAccountancy.Material != null && chattelDocumentOutputDetailWithAccountancy.StockLevelType != null) {
                if (chattelDocumentOutputDetailWithAccountancy.Material.ObjectID != null) {
                    let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(chattelDocumentOutputDetailWithAccountancy.Material.ObjectID, this._ChattelDocumentOutputWithAccountancy.Store.ObjectID, chattelDocumentOutputDetailWithAccountancy.StockLevelType.ObjectID);
                    chattelDocumentOutputDetailWithAccountancy.StoreStock = stockInheld;
                }
            }
        }
        if (data.Column.Name === 'AmountChattelDocumentDetailWithAccountancy') {
            if (chattelDocumentOutputDetailWithAccountancy.Amount > chattelDocumentOutputDetailWithAccountancy.StoreStock) {
                chattelDocumentOutputDetailWithAccountancy.Amount = chattelDocumentOutputDetailWithAccountancy.StoreStock;
            }
        }

    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChattelDocumentOutputWithAccountancy();
        this.baseChattelDocumentOutputWithAccountancyViewModel = new BaseChattelDocumentOutputWithAccountancyViewModel();
        this._ViewModel = this.baseChattelDocumentOutputWithAccountancyViewModel;
        this.baseChattelDocumentOutputWithAccountancyViewModel._ChattelDocumentOutputWithAccountancy = this._TTObject as ChattelDocumentOutputWithAccountancy;
        this.baseChattelDocumentOutputWithAccountancyViewModel._ChattelDocumentOutputWithAccountancy.Store = new Store();
        this.baseChattelDocumentOutputWithAccountancyViewModel._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy = new Array<ChattelDocumentOutputDetailWithAccountancy>();
        this.baseChattelDocumentOutputWithAccountancyViewModel._ChattelDocumentOutputWithAccountancy.Accountancy = new Accountancy();
        this.baseChattelDocumentOutputWithAccountancyViewModel._ChattelDocumentOutputWithAccountancy.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.baseChattelDocumentOutputWithAccountancyViewModel = this._ViewModel as BaseChattelDocumentOutputWithAccountancyViewModel;
        that._TTObject = this.baseChattelDocumentOutputWithAccountancyViewModel._ChattelDocumentOutputWithAccountancy;
        if (this.baseChattelDocumentOutputWithAccountancyViewModel == null)
            this.baseChattelDocumentOutputWithAccountancyViewModel = new BaseChattelDocumentOutputWithAccountancyViewModel();
        if (this.baseChattelDocumentOutputWithAccountancyViewModel._ChattelDocumentOutputWithAccountancy == null)
            this.baseChattelDocumentOutputWithAccountancyViewModel._ChattelDocumentOutputWithAccountancy = new ChattelDocumentOutputWithAccountancy();
        let storeObjectID = that.baseChattelDocumentOutputWithAccountancyViewModel._ChattelDocumentOutputWithAccountancy["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.baseChattelDocumentOutputWithAccountancyViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.baseChattelDocumentOutputWithAccountancyViewModel._ChattelDocumentOutputWithAccountancy.Store = store;
            }
        }
        that.baseChattelDocumentOutputWithAccountancyViewModel._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy = that.baseChattelDocumentOutputWithAccountancyViewModel.ChattelDocumentDetailsWithAccountancyGridList;
        for (let detailItem of that.baseChattelDocumentOutputWithAccountancyViewModel.ChattelDocumentDetailsWithAccountancyGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.baseChattelDocumentOutputWithAccountancyViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.baseChattelDocumentOutputWithAccountancyViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.baseChattelDocumentOutputWithAccountancyViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === "string")) {
                let stockLevelType = that.baseChattelDocumentOutputWithAccountancyViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        let accountancyObjectID = that.baseChattelDocumentOutputWithAccountancyViewModel._ChattelDocumentOutputWithAccountancy["Accountancy"];
        if (accountancyObjectID != null && (typeof accountancyObjectID === "string")) {
            let accountancy = that.baseChattelDocumentOutputWithAccountancyViewModel.Accountancys.find(o => o.ObjectID.toString() === accountancyObjectID.toString());
            if (accountancy) {
                that.baseChattelDocumentOutputWithAccountancyViewModel._ChattelDocumentOutputWithAccountancy.Accountancy = accountancy;
            }
        }
        that.baseChattelDocumentOutputWithAccountancyViewModel._ChattelDocumentOutputWithAccountancy.StockActionSignDetails = that.baseChattelDocumentOutputWithAccountancyViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.baseChattelDocumentOutputWithAccountancyViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === "string")) {
                let signUser = that.baseChattelDocumentOutputWithAccountancyViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }

    }

    async ngOnInit() {
        let that = this;
        await this.load(BaseChattelDocumentOutputWithAccountancyViewModel);

    }


    public onAccountancyChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.Accountancy != event) {
                this._ChattelDocumentOutputWithAccountancy.Accountancy = event;
            }
        }
        this.Accountancy_SelectedObjectChanged();
    }

    public onAdditionalDocumentCountChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.AdditionalDocumentCount != event) {
                this._ChattelDocumentOutputWithAccountancy.AdditionalDocumentCount = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.Description != event) {
                this._ChattelDocumentOutputWithAccountancy.Description = event;
            }
        }
    }

    public onMKYS_CikisIslemTuruChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_CikisIslemTuru != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_CikisIslemTuru = event;
            }
        }
    }

    public onMKYS_CikisStokHareketTuruChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_CikisStokHareketTuru != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_CikisStokHareketTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimAlan != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimEden != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimEden = event;
            }
        }
    }

    public onoutputStockMovementTypeChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.outputStockMovementType != event) {
                this._ChattelDocumentOutputWithAccountancy.outputStockMovementType = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.StockActionID != event) {
                this._ChattelDocumentOutputWithAccountancy.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.Store != event) {
                this._ChattelDocumentOutputWithAccountancy.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.TransactionDate != event) {
                this._ChattelDocumentOutputWithAccountancy.TransactionDate = event;
            }
        }
    }

    public onWaybillChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.Waybill != event) {
                this._ChattelDocumentOutputWithAccountancy.Waybill = event;
            }
        }
    }

    public onWaybillDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.WaybillDate != event) {
                this._ChattelDocumentOutputWithAccountancy.WaybillDate = event;
            }
        }
    }

    ChattelDocumentDetailsWithAccountancy_CellValueChangedEmitted(data: any) {
        if (data && this.ChattelDocumentDetailsWithAccountancy_CellValueChanged && data.Row && data.Column) {
            this.ChattelDocumentDetailsWithAccountancy_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_CikisIslemTuru, "Value", this.__ttObject, "MKYS_CikisIslemTuru");
        redirectProperty(this.MKYS_CikisStokHareketTuru, "Value", this.__ttObject, "MKYS_CikisStokHareketTuru");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.outputStockMovementType, "Value", this.__ttObject, "outputStockMovementType");
        redirectProperty(this.Waybill, "Text", this.__ttObject, "Waybill");
        redirectProperty(this.WaybillDate, "Value", this.__ttObject, "WaybillDate");
    }

    public ChattelDocumentDetailsWithAccountancyColumns = [

        {
            name: 'GetDetail',
            width: 'auto',
            cellTemplate: 'detailCellTemplate',
            visible: !this.getIsReadOnly()
        },
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
            //   width: 'auto'
        },
        {
            caption: i18n("M19908", "Ölçü Birimi"),
            dataField: 'Material.DistributionTypeName',
            allowEditing: false,
            //  width: 'auto'
        },
        {
            caption: i18n("M18519", "Malın Durumu"),
            dataField: 'StockLevelType.Description',
            allowEditing: false,
            //  width: 'auto'
        },
        {
            caption: i18n("M18957", "Mevcut"),
            dataField: 'StoreStock',
            allowEditing: false,
            //   width: 'auto'
        },
        {
            caption: i18n("M17457", "KDV Oranı"),
            dataField: 'VatRate',
            dataType: 'number',
            //   width: 'auto'
        },
        {
            caption: i18n("M19030", "Miktar"),
            dataField: 'Amount',
            dataType: 'number',
            //format: "#",
            // editorOptions: {
            //     onKeyPress: function (e) {
            //         var event = e.event,
            //             str = String.fromCharCode(event.keyCode);
            //         if (!/[0-9]/.test(str))
            //             event.preventDefault();
            //     }
            // },
            //   width: 'auto'
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
            //  width: 'auto',
            cellTemplate: 'deleteCellTemplate',
            visible: !this.getIsReadOnly()
        },

    ];
    public getIsReadOnly() {
        return false;
    }

    @ViewChild('gridChattelDocumentOutput') gridChattelDocumentOutput: DxDataGridComponent;
    async gridChattelDocumentOutput_CellContentClicked(data: any) {
        let that = this;
        if (this.ReadOnly != true) {
            if (data.column.name = "RowDelete") {
                if (data.row != null) {
                    if (data.row.key != null) {
                        if (data.row.key.IsNew) {
                            this.gridChattelDocumentOutput.instance.deleteRow(data.rowIndex);
                        }
                        else {
                            data.key.EntityState = EntityStateEnum.Deleted;
                            this.gridChattelDocumentOutput.instance.filter(['EntityState', '<>', 1]);
                            this.gridChattelDocumentOutput.instance.refresh();

                        }
                    }
                }

            }

        }
    }


    public async stateChange(event: FormSaveInfo) {
        if (this.gridChattelDocumentOutput != null) {
            this.gridChattelDocumentOutput.instance.closeEditCell();
            this.gridChattelDocumentOutput.instance.saveEditData();
        }
        await super.setState(event.transDef, event);
    }

    public async onSaveButtonClick(event: FormSaveInfo) {
        if (this.gridChattelDocumentOutput != null) {
            this.gridChattelDocumentOutput.instance.closeEditCell();
            this.gridChattelDocumentOutput.instance.saveEditData();
        }
        await super.saveForm(event);
    }

    public initFormControls(): void {
        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 131;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.Waybill = new TTVisual.TTTextBox();
        this.Waybill.Name = "Waybill";
        this.Waybill.TabIndex = 134;
        this.labelWaybillDate = new TTVisual.TTLabel();
        this.labelWaybillDate.Text = i18n("M16573", "İrsaliye Tarihi");
        this.labelWaybillDate.Name = "labelWaybillDate";
        this.labelWaybillDate.TabIndex = 137;
        this.labeloutputStockMovementType = new TTVisual.TTLabel();
        this.labeloutputStockMovementType.Text = i18n("M12372", "Çıkış Hareket Türü");
        this.labeloutputStockMovementType.Name = "labeloutputStockMovementType";
        this.labeloutputStockMovementType.TabIndex = 133;

        this.labeloutputStockMovementType = new TTVisual.TTLabel();
        this.labeloutputStockMovementType.Text = i18n("M12372", "Çıkış Hareket Türü");
        this.labeloutputStockMovementType.Name = "labeloutputStockMovementType";
        this.labeloutputStockMovementType.TabIndex = 133;

        this.outputStockMovementType = new TTVisual.TTEnumComboBox();
        this.outputStockMovementType.DataTypeName = "TasinirCikisHareketTurEnum";
        this.outputStockMovementType.Name = "outputStockMovementType";
        this.outputStockMovementType.TabIndex = 132;


        this.WaybillDate = new TTVisual.TTDateTimePicker();
        this.WaybillDate.Format = DateTimePickerFormat.Long;
        this.WaybillDate.Name = "WaybillDate";
        this.WaybillDate.TabIndex = 136;
        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 130;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.ChattelDocumentTabcontrol = new TTVisual.TTTabControl();
        this.ChattelDocumentTabcontrol.Name = "ChattelDocumentTabcontrol";
        this.ChattelDocumentTabcontrol.TabIndex = 6;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.ChattelDocumentTabpage = new TTVisual.TTTabPage();
        this.ChattelDocumentTabpage.DisplayIndex = 0;
        this.ChattelDocumentTabpage.TabIndex = 0;
        this.ChattelDocumentTabpage.Text = "Taşınır Malın";
        this.ChattelDocumentTabpage.Name = "ChattelDocumentTabpage";

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 118;

        this.ChattelDocumentDetailsWithAccountancy = new TTVisual.TTGrid();
        this.ChattelDocumentDetailsWithAccountancy.Required = true;
        this.ChattelDocumentDetailsWithAccountancy.Name = "ChattelDocumentDetailsWithAccountancy";
        this.ChattelDocumentDetailsWithAccountancy.TabIndex = 0;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.MaterialChattelDocumentDetailWithAccountancy = new TTVisual.TTListBoxColumn();
        this.MaterialChattelDocumentDetailWithAccountancy.AllowMultiSelect = true;
        this.MaterialChattelDocumentDetailWithAccountancy.ListDefName = "MaterialListDefinition";
        this.MaterialChattelDocumentDetailWithAccountancy.DataMember = "Material";
        this.MaterialChattelDocumentDetailWithAccountancy.AutoCompleteDialogHeight = "60%";
        this.MaterialChattelDocumentDetailWithAccountancy.AutoCompleteDialogWidth = "50%";
        this.MaterialChattelDocumentDetailWithAccountancy.DisplayIndex = 1;
        this.MaterialChattelDocumentDetailWithAccountancy.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialChattelDocumentDetailWithAccountancy.Name = "MaterialChattelDocumentDetailWithAccountancy";
        this.MaterialChattelDocumentDetailWithAccountancy.Width = 500;
        this.MaterialChattelDocumentDetailWithAccountancy.ListFilterExpression = 'STOCKS.STORE=\'' + this._ChattelDocumentOutputWithAccountancy.Store.ObjectID + '\' AND STOCKS.INHELD > 0';

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.StoreStock = new TTVisual.TTTextBoxColumn();
        this.StoreStock.DataMember = "StoreStock";
        this.StoreStock.Format = "N2";
        this.StoreStock.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreStock.DisplayIndex = 4;
        this.StoreStock.HeaderText = i18n("M18957", "Mevcut");
        this.StoreStock.Name = "StoreStock";
        this.StoreStock.ReadOnly = true;
        this.StoreStock.Width = 100;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.AmountChattelDocumentDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.AmountChattelDocumentDetailWithAccountancy.DataMember = "Amount";
        this.AmountChattelDocumentDetailWithAccountancy.Format = "N2";
        this.AmountChattelDocumentDetailWithAccountancy.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountChattelDocumentDetailWithAccountancy.DisplayIndex = 5;
        this.AmountChattelDocumentDetailWithAccountancy.HeaderText = i18n("M19030", "Miktar");
        this.AmountChattelDocumentDetailWithAccountancy.Name = "AmountChattelDocumentDetailWithAccountancy";
        this.AmountChattelDocumentDetailWithAccountancy.Width = 80;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 113;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = "UnitPrice";
        this.UnitPrice.Format = "#,###.#########";
        this.UnitPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPrice.DisplayIndex = 6;
        this.UnitPrice.HeaderText = i18n("M11868", "Birim Maliyet Bedeli");
        this.UnitPrice.Name = "UnitPrice";
        this.UnitPrice.ReadOnly = true;
        this.UnitPrice.Visible = false;
        this.UnitPrice.Width = 100;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DataMember = "Price";
        this.Price.Format = "#,###.#########";
        this.Price.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Price.DisplayIndex = 7;
        this.Price.HeaderText = i18n("M23613", "Tutarı");
        this.Price.Name = "Price";
        this.Price.ReadOnly = true;
        this.Price.Visible = false;
        this.Price.Width = 100;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.StockLevelTypeChattelDocumentDetailWithAccountancy = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.DataMember = "StockLevelType";
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.DisplayIndex = 8;
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.Name = "StockLevelTypeChattelDocumentDetailWithAccountancy";
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.Width = 100;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;

        this.StatusChattelDocumentDetailWithAccountancy = new TTVisual.TTEnumComboBoxColumn();
        this.StatusChattelDocumentDetailWithAccountancy.DataTypeName = "StockActionDetailStatusEnum";
        this.StatusChattelDocumentDetailWithAccountancy.DataMember = "Status";
        this.StatusChattelDocumentDetailWithAccountancy.DisplayIndex = 9;
        this.StatusChattelDocumentDetailWithAccountancy.HeaderText = "Durum";
        this.StatusChattelDocumentDetailWithAccountancy.Name = "StatusChattelDocumentDetailWithAccountancy";
        this.StatusChattelDocumentDetailWithAccountancy.Visible = false;
        this.StatusChattelDocumentDetailWithAccountancy.Width = 80;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.labelAccountancy = new TTVisual.TTLabel();
        this.labelAccountancy.Text = i18n("M14873", "Gönderildiği Yer");
        this.labelAccountancy.Name = "labelAccountancy";
        this.labelAccountancy.TabIndex = 121;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;

        this.Accountancy = new TTVisual.TTObjectListBox();
        this.Accountancy.ListDefName = "AccountancyList";
        this.Accountancy.Name = "Accountancy";
        this.Accountancy.TabIndex = 5;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.MKYS_CikisStokHareketTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisStokHareketTuru.DataTypeName = "MKYS_ECikisStokHareketTurEnum";
        this.MKYS_CikisStokHareketTuru.Name = "MKYS_CikisStokHareketTuru";
        this.MKYS_CikisStokHareketTuru.TabIndex = 128;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 111;

        this.lblMKYS_CikisIslemTuru = new TTVisual.TTLabel();
        this.lblMKYS_CikisIslemTuru.Text = i18n("M12381", "Çıkış Türü");
        this.lblMKYS_CikisIslemTuru.Name = "lblMKYS_CikisIslemTuru";
        this.lblMKYS_CikisIslemTuru.TabIndex = 125;

        this.MKYS_CikisIslemTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisIslemTuru.DataTypeName = "MKYS_ECikisIslemTuruEnum";
        this.MKYS_CikisIslemTuru.BackColor = "#F0F0F0";
        this.MKYS_CikisIslemTuru.Enabled = false;
        this.MKYS_CikisIslemTuru.Name = "MKYS_CikisIslemTuru";
        this.MKYS_CikisIslemTuru.TabIndex = 124;

        this.lblMKYS_CikisStokHareketTuru = new TTVisual.TTLabel();
        this.lblMKYS_CikisStokHareketTuru.Text = i18n("M12372", "Çıkış Hareket Türü");
        this.lblMKYS_CikisStokHareketTuru.Name = "lblMKYS_CikisStokHareketTuru";
        this.lblMKYS_CikisStokHareketTuru.TabIndex = 129;

        this.ValueAddedTax = new TTVisual.TTTextBoxColumn();
        this.ValueAddedTax.DataMember = "VatRate";
        this.ValueAddedTax.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ValueAddedTax.DisplayIndex = 6;
        this.ValueAddedTax.HeaderText = i18n("M17457", "KDV Oranı");
        this.ValueAddedTax.Name = "ValueAddedTax";
        this.ValueAddedTax.Width = 100;
        this.ValueAddedTax.ReadOnly = false;
        this.ValueAddedTax.Enabled = false;

        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.ChattelDocumentTabcontrol.Controls = [this.ChattelDocumentTabpage];
        this.ChattelDocumentTabpage.Controls = [this.ChattelDocumentDetailsWithAccountancy];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.Waybill, this.TTTeslimEdenButon, this.labelWaybillDate, this.TTTeslimAlanButon, this.WaybillDate, this.labelMKYS_TeslimEden, this.labelWaybill, this.MKYS_TeslimEden, this.labeloutputStockMovementType, this.MKYS_TeslimAlan, this.outputStockMovementType, this.Description, this.labelStore, this.StockActionID, this.Store, this.labelMKYS_TeslimAlan, this.ChattelDocumentTabcontrol, this.labelTransactionDate, this.ChattelDocumentTabpage, this.TransactionDate, this.ChattelDocumentDetailsWithAccountancy, this.labelStockActionID, this.Detail, this.DescriptionAndSignTabControl, this.MaterialChattelDocumentDetailWithAccountancy, this.SignTabpage, this.Barcode, this.StockActionSignDetails, this.DistributionType, this.SignUserType, this.StoreStock, this.SignUser, this.AmountChattelDocumentDetailWithAccountancy, this.IsDeputy, this.UnitPrice, this.ttlabel1, this.Price, this.StockLevelTypeChattelDocumentDetailWithAccountancy, this.StatusChattelDocumentDetailWithAccountancy, this.labelAccountancy, this.Accountancy, this.MKYS_CikisStokHareketTuru, this.lblMKYS_CikisIslemTuru, this.MKYS_CikisIslemTuru, this.lblMKYS_CikisStokHareketTuru];

    }


}
