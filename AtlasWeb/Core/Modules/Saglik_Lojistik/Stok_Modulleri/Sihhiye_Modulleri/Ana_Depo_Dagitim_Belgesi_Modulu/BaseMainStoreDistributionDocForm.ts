//$E17D1140
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { BaseMainStoreDistributionDocFormViewModel } from './BaseMainStoreDistributionDocFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { MainStoreDistributionDoc, ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionBaseForm } from "Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StockActionBaseForm";
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MainStoreDistDocDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';

import { TTButtonTextBox } from 'app/NebulaClient/Visual/Controls/TTButtonTextBox';
import { ResUserService } from 'app/NebulaClient/Services/ObjectService/ResUserService';
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';

@Component({
    selector: 'BaseMainStoreDistributionDocForm',
    templateUrl: './BaseMainStoreDistributionDocForm.html',
    providers: [MessageService]
})
export class BaseMainStoreDistributionDocForm extends StockActionBaseForm implements OnInit {
    AmountDistributionDocumentMaterial: TTVisual.ITTTextBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    Description: TTVisual.ITTTextBox;
    DestinationStore: TTVisual.ITTObjectListBox;
    Detail: TTVisual.ITTButtonColumn;
    DistributionDocumentMaterialsTabcontrol: TTVisual.ITTTabControl;
    DistributionDocumentMaterialsTabpage: TTVisual.ITTTabPage;
    DistributionType: TTVisual.ITTTextBoxColumn;
    labelDescription: TTVisual.ITTLabel;
    labelDestinationStore: TTVisual.ITTLabel;
    labelStockActionID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelTransactionDate: TTVisual.ITTLabel;
    MainStoreDistDocDetails: TTVisual.ITTGrid;
    MaterialDistributionDocumentMaterial: TTVisual.ITTListBoxColumn;
    Price: TTVisual.ITTTextBoxColumn;
    SendedAmountDistributionDocumentMaterial: TTVisual.ITTTextBoxColumn;
    StatusDistributionDocumentMaterial: TTVisual.ITTEnumComboBoxColumn;
    StockActionID: TTVisual.ITTTextBox;
    StockLevelTypeDistributionDocumentMaterial: TTVisual.ITTListBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    StoreInheld: TTVisual.ITTTextBoxColumn;
    TransactionDate: TTVisual.ITTDateTimePicker;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    MKYS_TeslimAlan:TTButtonTextBox;
    MKYS_TeslimEden:TTButtonTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    UnitPrice: TTVisual.ITTTextBoxColumn;
    public MainStoreDistDocDetailsColumns = [];
    public baseMainStoreDistributionDocFormViewModel: BaseMainStoreDistributionDocFormViewModel = new BaseMainStoreDistributionDocFormViewModel();
    public get _MainStoreDistributionDoc(): MainStoreDistributionDoc {
        return this._TTObject as MainStoreDistributionDoc;
    }
    private BaseMainStoreDistributionDocForm_DocumentUrl: string = '/api/MainStoreDistributionDocService/BaseMainStoreDistributionDocForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService,protected ngZone:NgZone) {
        super(httpService, messageService,ngZone);
        this._DocumentServiceUrl = this.BaseMainStoreDistributionDocForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._MainStoreDistributionDoc.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.MKYS_TeslimAlan !== event) {
                this._MainStoreDistributionDoc.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._MainStoreDistributionDoc.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = '#F0F0F0';
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.MKYS_TeslimEden !== event) {
                this._MainStoreDistributionDoc.MKYS_TeslimEden = event;
            }
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MainStoreDistributionDoc();
        this.baseMainStoreDistributionDocFormViewModel = new BaseMainStoreDistributionDocFormViewModel();
        this._ViewModel = this.baseMainStoreDistributionDocFormViewModel;
        this.baseMainStoreDistributionDocFormViewModel._MainStoreDistributionDoc = this._TTObject as MainStoreDistributionDoc;
        this.baseMainStoreDistributionDocFormViewModel._MainStoreDistributionDoc.Store = new Store();
        this.baseMainStoreDistributionDocFormViewModel._MainStoreDistributionDoc.DestinationStore = new Store();
        this.baseMainStoreDistributionDocFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails = new Array<MainStoreDistDocDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.baseMainStoreDistributionDocFormViewModel = this._ViewModel as BaseMainStoreDistributionDocFormViewModel;
        that._TTObject = this.baseMainStoreDistributionDocFormViewModel._MainStoreDistributionDoc;
        if (this.baseMainStoreDistributionDocFormViewModel == null)
            this.baseMainStoreDistributionDocFormViewModel = new BaseMainStoreDistributionDocFormViewModel();
        if (this.baseMainStoreDistributionDocFormViewModel._MainStoreDistributionDoc == null)
            this.baseMainStoreDistributionDocFormViewModel._MainStoreDistributionDoc = new MainStoreDistributionDoc();
        let storeObjectID = that.baseMainStoreDistributionDocFormViewModel._MainStoreDistributionDoc["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.baseMainStoreDistributionDocFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.baseMainStoreDistributionDocFormViewModel._MainStoreDistributionDoc.Store = store;
            }
        }


        let destinationStoreObjectID = that.baseMainStoreDistributionDocFormViewModel._MainStoreDistributionDoc["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === "string")) {
            let destinationStore = that.baseMainStoreDistributionDocFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.baseMainStoreDistributionDocFormViewModel._MainStoreDistributionDoc.DestinationStore = destinationStore;
            }
        }


        that.baseMainStoreDistributionDocFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails = that.baseMainStoreDistributionDocFormViewModel.MainStoreDistDocDetailsGridList;
        for (let detailItem of that.baseMainStoreDistributionDocFormViewModel.MainStoreDistDocDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.baseMainStoreDistributionDocFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.baseMainStoreDistributionDocFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.baseMainStoreDistributionDocFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.baseMainStoreDistributionDocFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
    }




    async ngOnInit() {
        await this.load();
    }

    public onDescriptionChanged(event): void {
        if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.Description != event) {
            this._MainStoreDistributionDoc.Description = event;
        }
    }

    public onDestinationStoreChanged(event): void {
        if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.DestinationStore != event) {
            this._MainStoreDistributionDoc.DestinationStore = event;
        }
    }

    public onStockActionIDChanged(event): void {
        if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.StockActionID != event) {
            this._MainStoreDistributionDoc.StockActionID = event;
        }
    }

    public async TTTeslimAlanButon_Click(): Promise<void> {

        let resUser: Array<ResUser> = (await ResUserService.GetAllUser('WHERE ISACTIVE = 1 '));
        let selectedPersonel: ResUser = null;
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let user of resUser) {
            multiSelectForm.AddMSItem(user.Name, user.ObjectID.toString(), user);
        }
        let key: string = await multiSelectForm.GetMSItem(this, i18n("M23225", "Teslim Alan Personel Seçin"));
        if (String.isNullOrEmpty(key)) {
            TTVisual.InfoBox.Show(i18n("M15736", "Herhangibir Personel Seçilmedi."), MessageIconEnum.ErrorMessage);
        } else {
            selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
            this.MKYS_TeslimAlan.Text = selectedPersonel.Name.toString();
            this._MainStoreDistributionDoc.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;
        }
    }

    public onStoreChanged(event): void {
        if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.Store != event) {
            this._MainStoreDistributionDoc.Store = event;
        }
    }

    public onTransactionDateChanged(event): void {
        if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.TransactionDate != event) {
            this._MainStoreDistributionDoc.TransactionDate = event;
        }
    }

    public ontttextbox2Changed(event): void {
        if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.MKYS_TeslimEden != event) {
            this._MainStoreDistributionDoc.MKYS_TeslimEden = event;
        }
    }

    public ontttextbox3Changed(event): void {
        if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.MKYS_TeslimAlan != event) {
            this._MainStoreDistributionDoc.MKYS_TeslimAlan = event;
        }
    }

    public async TTTeslimEdenButon_Click(): Promise<void> {

        let resUser: Array<ResUser> = (await ResUserService.GetAllUser('WHERE ISACTIVE = 1 '));
        let selectedPersonel: ResUser = null;
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let user of resUser) {
            multiSelectForm.AddMSItem(user.Name, user.ObjectID.toString(), user);
        }
        let key: string = await multiSelectForm.GetMSItem(this, i18n("M23234", "Teslim Eden Personeli Seçin"));
        if (String.isNullOrEmpty(key)) {
            TTVisual.InfoBox.Show(i18n("M15736", "Herhangibir Personel Seçilmedi."), MessageIconEnum.ErrorMessage);
        } else {
            selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
            this.MKYS_TeslimEden.Text = selectedPersonel.Name.toString();
            this._MainStoreDistributionDoc.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
        }
    }


    

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = "Açıklama";
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 32;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 31;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = "Gönderen Depo";
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 8;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 7;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = "Alan Depo";
        this.labelDestinationStore.Name = "labelDestinationStore";
        this.labelDestinationStore.TabIndex = 6;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ListDefName = "SubStoreList";
        this.DestinationStore.Name = "DestinationStore";
        this.DestinationStore.TabIndex = 5;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = "İşlem Tarihi";
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 3;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.Format = DateTimePickerFormat.Long;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 2;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = "İşlem No";
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 1;

        this.DistributionDocumentMaterialsTabcontrol = new TTVisual.TTTabControl();
        this.DistributionDocumentMaterialsTabcontrol.Name = "DistributionDocumentMaterialsTabcontrol";
        this.DistributionDocumentMaterialsTabcontrol.TabIndex = 30;

        this.DistributionDocumentMaterialsTabpage = new TTVisual.TTTabPage();
        this.DistributionDocumentMaterialsTabpage.DisplayIndex = 0;
        this.DistributionDocumentMaterialsTabpage.TabIndex = 0;
        this.DistributionDocumentMaterialsTabpage.Text = "Taşınır Malın";
        this.DistributionDocumentMaterialsTabpage.Name = "DistributionDocumentMaterialsTabpage";

        this.MainStoreDistDocDetails = new TTVisual.TTGrid();
        this.MainStoreDistDocDetails.Name = "MainStoreDistDocDetails";
        this.MainStoreDistDocDetails.TabIndex = 29;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = "Detay";
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = "Detay";
        this.Detail.Width = 80;

        this.MaterialDistributionDocumentMaterial = new TTVisual.TTListBoxColumn();
        this.MaterialDistributionDocumentMaterial.AllowMultiSelect = true;
        this.MaterialDistributionDocumentMaterial.ListDefName = "MaterialListDefinition";
        this.MaterialDistributionDocumentMaterial.DataMember = "Material";
        this.MaterialDistributionDocumentMaterial.DisplayIndex = 1;
        this.MaterialDistributionDocumentMaterial.HeaderText = "Malzeme Adı";
        this.MaterialDistributionDocumentMaterial.Name = "MaterialDistributionDocumentMaterial";
        this.MaterialDistributionDocumentMaterial.Width = 300;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = "Ölçü Birimi";
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 75;

        this.SendedAmountDistributionDocumentMaterial = new TTVisual.TTTextBoxColumn();
        this.SendedAmountDistributionDocumentMaterial.DataMember = "SendedAmount";
        this.SendedAmountDistributionDocumentMaterial.Required = true;
        this.SendedAmountDistributionDocumentMaterial.Format = "N4";
        this.SendedAmountDistributionDocumentMaterial.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.SendedAmountDistributionDocumentMaterial.DisplayIndex = 4;
        this.SendedAmountDistributionDocumentMaterial.HeaderText = "Gönderilen Miktar";
        this.SendedAmountDistributionDocumentMaterial.Name = "SendedAmountDistributionDocumentMaterial";
        this.SendedAmountDistributionDocumentMaterial.Width = 75;

        this.AmountDistributionDocumentMaterial = new TTVisual.TTTextBoxColumn();
        this.AmountDistributionDocumentMaterial.DataMember = "Amount";
        this.AmountDistributionDocumentMaterial.Format = "N4";
        this.AmountDistributionDocumentMaterial.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountDistributionDocumentMaterial.DisplayIndex = 5;
        this.AmountDistributionDocumentMaterial.HeaderText = "Verilen Miktar";
        this.AmountDistributionDocumentMaterial.Name = "AmountDistributionDocumentMaterial";
        this.AmountDistributionDocumentMaterial.Width = 75;

        this.StoreInheld = new TTVisual.TTTextBoxColumn();
        this.StoreInheld.DataMember = "StoreStock";
        this.StoreInheld.Format = "N4";
        this.StoreInheld.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreInheld.DisplayIndex = 6;
        this.StoreInheld.HeaderText = "Depo Mevcudu";
        this.StoreInheld.Name = "StoreInheld";
        this.StoreInheld.ReadOnly = true;
        this.StoreInheld.Visible = false;
        this.StoreInheld.Width = 75;

        this.StockLevelTypeDistributionDocumentMaterial = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeDistributionDocumentMaterial.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeDistributionDocumentMaterial.DataMember = "StockLevelType";
        this.StockLevelTypeDistributionDocumentMaterial.DisplayIndex = 7;
        this.StockLevelTypeDistributionDocumentMaterial.HeaderText = "Malın Durumu";
        this.StockLevelTypeDistributionDocumentMaterial.Name = "StockLevelTypeDistributionDocumentMaterial";
        this.StockLevelTypeDistributionDocumentMaterial.ReadOnly = true;
        this.StockLevelTypeDistributionDocumentMaterial.Width = 75;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = "UnitPrice";
        this.UnitPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPrice.DisplayIndex = 8;
        this.UnitPrice.HeaderText = "Birim Fiyatı";
        this.UnitPrice.Name = "UnitPrice";
        this.UnitPrice.ReadOnly = true;
        this.UnitPrice.Width = 75;

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DataMember = "Price";
        this.Price.Format = "N4";
        this.Price.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Price.DisplayIndex = 9;
        this.Price.HeaderText = "Tutarı";
        this.Price.Name = "Price";
        this.Price.ReadOnly = true;
        this.Price.Width = 75;

        this.StatusDistributionDocumentMaterial = new TTVisual.TTEnumComboBoxColumn();
        this.StatusDistributionDocumentMaterial.DataTypeName = "StockActionDetailStatusEnum";
        this.StatusDistributionDocumentMaterial.DataMember = "Status";
        this.StatusDistributionDocumentMaterial.DisplayIndex = 10;
        this.StatusDistributionDocumentMaterial.HeaderText = "Durum";
        this.StatusDistributionDocumentMaterial.Name = "StatusDistributionDocumentMaterial";
        this.StatusDistributionDocumentMaterial.ReadOnly = true;
        this.StatusDistributionDocumentMaterial.Visible = false;
        this.StatusDistributionDocumentMaterial.Width = 75;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "Teslim Eden";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 139;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.Required = true;
        this.tttextbox2.BackColor = "#FFE3C6";
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 138;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.Required = true;
        this.tttextbox3.BackColor = "#FFE3C6";
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 136;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Teslim Alan";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 137;

        this.MKYS_TeslimAlan = new TTVisual.TTButton();
        this.MKYS_TeslimAlan.Text = "TA";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 120;

        this.MKYS_TeslimEden = new TTVisual.TTButton();
        this.MKYS_TeslimEden.Text = "TE";
        this.MKYS_TeslimEden.Name = "TTTeslimEdenButon";
        this.MKYS_TeslimEden.TabIndex = 121;

        this.MainStoreDistDocDetailsColumns = [this.Detail, this.MaterialDistributionDocumentMaterial, this.Barcode, this.DistributionType, this.SendedAmountDistributionDocumentMaterial, this.AmountDistributionDocumentMaterial, this.StoreInheld, this.StockLevelTypeDistributionDocumentMaterial, this.UnitPrice, this.Price, this.StatusDistributionDocumentMaterial];
        this.DistributionDocumentMaterialsTabcontrol.Controls = [this.DistributionDocumentMaterialsTabpage];
        this.DistributionDocumentMaterialsTabpage.Controls = [this.MainStoreDistDocDetails];
        this.Controls = [this.labelDescription, this.Description, this.StockActionID, this.labelStore, this.Store, this.labelDestinationStore, this.DestinationStore, this.labelTransactionDate, this.TransactionDate, this.labelStockActionID, this.DistributionDocumentMaterialsTabcontrol, this.DistributionDocumentMaterialsTabpage, this.MainStoreDistDocDetails, this.Detail, this.MaterialDistributionDocumentMaterial, this.Barcode, this.DistributionType, this.SendedAmountDistributionDocumentMaterial, this.AmountDistributionDocumentMaterial, this.StoreInheld, this.StockLevelTypeDistributionDocumentMaterial, this.UnitPrice, this.Price, this.StatusDistributionDocumentMaterial, this.ttlabel2, this.tttextbox2, this.tttextbox3, this.ttlabel3, this. MKYS_TeslimAlan, this.MKYS_TeslimEden];

    }


}
