//$AAE5C212
import { Component, OnInit, NgZone } from '@angular/core';
import { BaseGeneralProductionActionFromViewModel } from './BaseGeneralProductionActionFromViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { GeneralProductionAction } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResUserService } from 'ObjectClassService/ResUserService';
import { StockActionBaseForm } from 'Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StockActionBaseForm';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { GeneralProductionOutDet } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { StockLevelTypeService } from 'ObjectClassService/StockLevelTypeService';
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { StockLevelService } from 'ObjectClassService/StockLevelService';

@Component({
    selector: 'BaseGeneralProductionActionFrom',
    templateUrl: './BaseGeneralProductionActionFrom.html',
    providers: [MessageService]
})
export class BaseGeneralProductionActionFrom extends StockActionBaseForm implements OnInit {
    Amount: TTVisual.ITTTextBox;
    AmountGeneralProductionOutDet: TTVisual.ITTTextBoxColumn;
    Description: TTVisual.ITTTextBox;
    BudgetTypeDefinition: TTVisual.ITTObjectListBox;
    DistributionType: TTVisual.ITTListDefComboBoxColumn;
    Exiting: TTVisual.ITTTextBoxColumn;
    GeneralProductionOutDets: TTVisual.ITTGrid;
    labelAmount: TTVisual.ITTLabel;
    labelMaterial: TTVisual.ITTLabel;
    labelMKYS_TeslimAlan: TTVisual.ITTLabel;
    labelMKYS_TeslimEden: TTVisual.ITTLabel;
    labelStockActionID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelTransactionDate: TTVisual.ITTLabel;
    labelUnitPrice: TTVisual.ITTLabel;
    Material: TTVisual.ITTObjectListBox;
    MaterialDet: TTVisual.ITTListBoxColumn;
    MKYS_TeslimAlan:  TTButtonTextBox;
    MKYS_TeslimEden:  TTButtonTextBox;
    StockActionID: TTVisual.ITTTextBox;
    Store: TTVisual.ITTObjectListBox;
    TransactionDate: TTVisual.ITTDateTimePicker;
    ttlabel7: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    TTTeslimAlanButon: TTVisual.ITTButton;
    TTTeslimEdenButon: TTVisual.ITTButton;
    UnitPrice: TTVisual.ITTTextBox;
    public GeneralProductionOutDetsColumns = [];
    public baseGeneralProductionActionFromViewModel: BaseGeneralProductionActionFromViewModel = new BaseGeneralProductionActionFromViewModel();
    public get _GeneralProductionAction(): GeneralProductionAction {
        return this._TTObject as GeneralProductionAction;
    }
    private BaseGeneralProductionActionFrom_DocumentUrl: string = '/api/GeneralProductionActionService/BaseGeneralProductionActionFrom';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseGeneralProductionActionFrom_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async TTTeslimAlanButon_Click(): Promise<void> {

        let resUser: Array<ResUser> = (await ResUserService.GetAllUser(' WHERE ISACTIVE = 1 '));
        let selectedPersonel: ResUser = null;
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let user of resUser) {
            multiSelectForm.AddMSItem(user.Name, user.ObjectID.toString(), user);
        }
        let key: string = await multiSelectForm.GetMSItem(this.ParentForm, i18n("M23225", "Teslim Alan Personel Seçin"));
        if (String.isNullOrEmpty(key)) {
            TTVisual.InfoBox.Show(i18n("M15736", "Herhangibir Personel Seçilmedi."), MessageIconEnum.ErrorMessage);
        } else {
            selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
            this.MKYS_TeslimAlan.Text = selectedPersonel.Name.toString();
            this._GeneralProductionAction.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;
        }
    }
    public async TTTeslimEdenButon_Click(): Promise<void> {

        let resUser: Array<ResUser> = (await ResUserService.GetAllUser(' WHERE ISACTIVE = 1 '));
        let selectedPersonel: ResUser = null;
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let user of resUser) {
            multiSelectForm.AddMSItem(user.Name, user.ObjectID.toString(), user);
        }
        let key: string = await multiSelectForm.GetMSItem(this.ParentForm, i18n("M23234", "Teslim Eden Personeli Seçin"));
        if (String.isNullOrEmpty(key)) {
            TTVisual.InfoBox.Show(i18n("M15736", "Herhangibir Personel Seçilmedi."), MessageIconEnum.ErrorMessage);
        } else {
            selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
            this.MKYS_TeslimEden.Text = selectedPersonel.Name.toString();
            this._GeneralProductionAction.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new GeneralProductionAction();
        this.baseGeneralProductionActionFromViewModel = new BaseGeneralProductionActionFromViewModel();
        this._ViewModel = this.baseGeneralProductionActionFromViewModel;
        this.baseGeneralProductionActionFromViewModel._GeneralProductionAction = this._TTObject as GeneralProductionAction;
        this.baseGeneralProductionActionFromViewModel._GeneralProductionAction.Store = new Store();
        this.baseGeneralProductionActionFromViewModel._GeneralProductionAction.Material = new Material();
        this.baseGeneralProductionActionFromViewModel._GeneralProductionAction.GeneralProductionOutDets = new Array<GeneralProductionOutDet>();
    }

    protected loadViewModel() {
        let that = this;
        that.baseGeneralProductionActionFromViewModel = this._ViewModel as BaseGeneralProductionActionFromViewModel;
        that._TTObject = this.baseGeneralProductionActionFromViewModel._GeneralProductionAction;
        if (this.baseGeneralProductionActionFromViewModel == null) {
            this.baseGeneralProductionActionFromViewModel = new BaseGeneralProductionActionFromViewModel();
        }
        if (this.baseGeneralProductionActionFromViewModel._GeneralProductionAction == null) {
            this.baseGeneralProductionActionFromViewModel._GeneralProductionAction = new GeneralProductionAction();
        }
        let storeObjectID = that.baseGeneralProductionActionFromViewModel._GeneralProductionAction['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.baseGeneralProductionActionFromViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.baseGeneralProductionActionFromViewModel._GeneralProductionAction.Store = store;
            }
        }
        let materialObjectID = that.baseGeneralProductionActionFromViewModel._GeneralProductionAction['Material'];
        if (materialObjectID != null && (typeof materialObjectID === 'string')) {
            let material = that.baseGeneralProductionActionFromViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
             if (material) {
                that.baseGeneralProductionActionFromViewModel._GeneralProductionAction.Material = material;
            }
        }
        that.baseGeneralProductionActionFromViewModel._GeneralProductionAction.GeneralProductionOutDets = that.baseGeneralProductionActionFromViewModel.GeneralProductionOutDetsGridList;
        for (let detailItem of that.baseGeneralProductionActionFromViewModel.GeneralProductionOutDetsGridList) {
            let materialObjID = detailItem['Material'];
            if (materialObjID != null) {
                let material = that.baseGeneralProductionActionFromViewModel.Materials.find(o => o.ObjectID.toString() === materialObjID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.baseGeneralProductionActionFromViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType =
                                    that.baseGeneralProductionActionFromViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                 if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(BaseGeneralProductionActionFromViewModel);

    }


    public onAmountChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.Amount !== event) {
                this._GeneralProductionAction.Amount = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.Description !== event) {
                this._GeneralProductionAction.Description = event;
            }
        }
    }

    public onMaterialChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.Material !== event) {
                this._GeneralProductionAction.Material = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.MKYS_TeslimAlan !== event) {
                this._GeneralProductionAction.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = '#F0F0F0';
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.MKYS_TeslimEden !== event) {
                this._GeneralProductionAction.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.StockActionID !== event) {
                this._GeneralProductionAction.StockActionID = event;
            }
        }
    }
    public onBudgetTypeDefinitionChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.BudgetTypeDefinition !== event) {
                this._GeneralProductionAction.BudgetTypeDefinition = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.Store !== event) {
                this._GeneralProductionAction.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.TransactionDate !== event) {
                this._GeneralProductionAction.TransactionDate = event;
            }
        }
    }

    public onUnitPriceChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.UnitPrice !== event) {
                this._GeneralProductionAction.UnitPrice = event;
            }
        }
    }

    public async GeneralProductionOutDets_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        let generalProductionOutDet: GeneralProductionOutDet = <GeneralProductionOutDet>(data.Row.TTObject);
        if (generalProductionOutDet.Status === undefined) {
            generalProductionOutDet.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            generalProductionOutDet.StockLevelType = stockLeveltypeArray[0];
        }
        if (data.Column.Name === 'MaterialDet' || data.Column.Name === 'StockLevelType') {

            if (generalProductionOutDet.Material != null && generalProductionOutDet.StockLevelType != null) {
                if (generalProductionOutDet.Material.ObjectID != null) {
                    let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(generalProductionOutDet.Material.ObjectID,
                        this._GeneralProductionAction.Store.ObjectID, generalProductionOutDet.StockLevelType.ObjectID);
                    generalProductionOutDet.StoreStock = stockInheld;
                }
            }
        }
    }


    public redirectProperties(): void {
        redirectProperty(this.StockActionID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.TransactionDate, 'Value', this.__ttObject, 'TransactionDate');
        redirectProperty(this.Amount, 'Text', this.__ttObject, 'Amount');
        redirectProperty(this.UnitPrice, 'Text', this.__ttObject, 'UnitPrice');
        redirectProperty(this.MKYS_TeslimAlan, 'Text', this.__ttObject, 'MKYS_TeslimAlan');
        redirectProperty(this.MKYS_TeslimEden, 'Text', this.__ttObject, 'MKYS_TeslimEden');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
    }

    public initFormControls(): void {
        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = 'tttabcontrol1';
        this.tttabcontrol1.TabIndex = 19;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M10469", "Açıklama");
        this.tttabpage1.Name = 'tttabpage1';

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = 'Description';
        this.Description.TabIndex = 2;

        this.UnitPrice = new TTVisual.TTTextBox();
        this.UnitPrice.Required = true;
        this.UnitPrice.BackColor = '#FFE3C6';
        this.UnitPrice.Name = 'UnitPrice';
        this.UnitPrice.TabIndex = 17;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = '#F0F0F0';
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = 'StockActionID';
        this.StockActionID.TabIndex = 4;

        this.Amount = new TTVisual.TTTextBox();
        this.Amount.Required = true;
        this.Amount.BackColor = '#FFE3C6';
        this.Amount.Name = 'Amount';
        this.Amount.TabIndex = 0;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = '#FFE3C6';
        this.MKYS_TeslimAlan.Name = 'MKYS_TeslimAlan';
        this.MKYS_TeslimAlan.TabIndex = 136;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = '#FFE3C6';
        this.MKYS_TeslimEden.Name = 'MKYS_TeslimEden';
        this.MKYS_TeslimEden.TabIndex = 138;

        this.labelUnitPrice = new TTVisual.TTLabel();
        this.labelUnitPrice.Text = i18n("M11860", "Birim Fiyatı");
        this.labelUnitPrice.Name = 'labelUnitPrice';
        this.labelUnitPrice.TabIndex = 18;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = 'labelStore';
        this.labelStore.TabIndex = 16;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = 'MainStoreList';
        this.Store.Name = 'Store';
        this.Store.TabIndex = 15;

        this.labelMaterial = new TTVisual.TTLabel();
        this.labelMaterial.Text = i18n("M23948", "Üretilecek Malzeme");
        this.labelMaterial.Name = 'labelMaterial';
        this.labelMaterial.TabIndex = 10;

        this.Material = new TTVisual.TTObjectListBox();
        this.Material.Required = true;
        this.Material.ListFilterExpression = 'IsOldMaterial = 0';
        this.Material.ListDefName = 'ConsumableMaterialDefinitionList';
        this.Material.Name = 'Material';
        this.Material.TabIndex = 9;

        this.GeneralProductionOutDets = new TTVisual.TTGrid();
        this.GeneralProductionOutDets.Name = 'GeneralProductionOutDets';
        this.GeneralProductionOutDets.TabIndex = 8;

        this.MaterialDet = new TTVisual.TTListBoxColumn();
        this.MaterialDet.ListDefName = 'MaterialListDefinition';
        this.MaterialDet.ListFilterExpression = 'IsOldMaterial = 0';
        this.MaterialDet.DataMember = 'Material';
        this.MaterialDet.AutoCompleteDialogHeight = '60%';
        this.MaterialDet.AutoCompleteDialogWidth = '50%';
        this.MaterialDet.Required = true;
        this.MaterialDet.DisplayIndex = 0;
        this.MaterialDet.HeaderText = i18n("M18545", "Malzeme");
        this.MaterialDet.Name = 'MaterialDet';
        this.MaterialDet.Width = 400;

        this.AmountGeneralProductionOutDet = new TTVisual.TTTextBoxColumn();
        this.AmountGeneralProductionOutDet.DataMember = 'Amount';
        this.AmountGeneralProductionOutDet.Required = true;
        this.AmountGeneralProductionOutDet.DisplayIndex = 1;
        this.AmountGeneralProductionOutDet.HeaderText = i18n("M19030", "Miktar");
        this.AmountGeneralProductionOutDet.Name = 'AmountGeneralProductionOutDet';
        this.AmountGeneralProductionOutDet.Width = 80;

        this.DistributionType = new TTVisual.TTListDefComboBoxColumn();
        this.DistributionType.ListDefName = 'DistributionTypeList';
        this.DistributionType.DataMember = 'DistributionType';
        this.DistributionType.DisplayIndex = 2;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = 'DistributionType';
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.Exiting = new TTVisual.TTTextBoxColumn();
        this.Exiting.DataMember = 'StoreStock';
        this.Exiting.DisplayIndex = 3;
        this.Exiting.HeaderText = i18n("M18957", "Mevcut");
        this.Exiting.Name = 'Exiting';
        this.Exiting.Width = 100;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = 'labelTransactionDate';
        this.labelTransactionDate.TabIndex = 7;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = '#F0F0F0';
        this.TransactionDate.Format = DateTimePickerFormat.Long;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = 'TransactionDate';
        this.TransactionDate.TabIndex = 6;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = 'labelStockActionID';
        this.labelStockActionID.TabIndex = 5;

        this.labelAmount = new TTVisual.TTLabel();
        this.labelAmount.Text = i18n("M19030", "Miktar");
        this.labelAmount.Name = 'labelAmount';
        this.labelAmount.TabIndex = 1;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M23960", "Üretim Esnasında Tüketilen Malzemler");
        this.ttlabel7.Name = 'ttlabel7';
        this.ttlabel7.TabIndex = 10;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = 'labelMKYS_TeslimEden';
        this.labelMKYS_TeslimEden.TabIndex = 139;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = 'labelMKYS_TeslimAlan';
        this.labelMKYS_TeslimAlan.TabIndex = 137;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = 'TA';
        this.TTTeslimAlanButon.Name = 'TTTeslimAlanButon';
        this.TTTeslimAlanButon.TabIndex = 120;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = 'TE';
        this.TTTeslimEdenButon.Name = 'TTTeslimEdenButon';
        this.TTTeslimEdenButon.TabIndex = 121;

        this.GeneralProductionOutDetsColumns = [this.MaterialDet, this.AmountGeneralProductionOutDet, this.DistributionType, this.Exiting];
        this.tttabcontrol1.Controls = [this.tttabpage1];
        this.tttabpage1.Controls = [this.Description];
        this.Controls = [this.tttabcontrol1, this.tttabpage1, this.Description, this.UnitPrice, this.StockActionID, this.Amount, this.MKYS_TeslimAlan,
        this.MKYS_TeslimEden, this.labelUnitPrice, this.labelStore, this.Store, this.labelMaterial, this.Material, this.GeneralProductionOutDets, this.MaterialDet,
        this.AmountGeneralProductionOutDet, this.DistributionType, this.Exiting, this.labelTransactionDate, this.TransactionDate, this.labelStockActionID, this.labelAmount,
        this.ttlabel7, this.labelMKYS_TeslimEden, this.labelMKYS_TeslimAlan, this.TTTeslimAlanButon, this.TTTeslimEdenButon];
    }
}