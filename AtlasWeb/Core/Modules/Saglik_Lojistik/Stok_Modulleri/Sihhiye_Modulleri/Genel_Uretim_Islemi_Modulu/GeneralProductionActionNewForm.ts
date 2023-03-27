//$2D75C10E
import { Component, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { GeneralProductionActionNewFormViewModel } from './GeneralProductionActionNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseGeneralProductionActionFrom } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Genel_Uretim_Islemi_Modulu/BaseGeneralProductionActionFrom';
import { GeneralProductionAction } from 'NebulaClient/Model/AtlasClientModel';
import { MainStoreDefinition, PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_ECikisStokHareketTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_EMalzemeGrupEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_ETedarikTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_EAlimYontemiEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { GeneralProductionOutDet } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { SelectStoreUsageEnum } from 'NebulaClient/Model/AtlasClientModel';

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { MKYS_EButceTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
@Component({
    selector: 'GeneralProductionActionNewForm',
    templateUrl: './GeneralProductionActionNewForm.html',
    providers: [MessageService]
})
export class GeneralProductionActionNewForm extends BaseGeneralProductionActionFrom implements OnInit {
    public GeneralProductionOutDetsColumns = [];
    public generalProductionActionNewFormViewModel: GeneralProductionActionNewFormViewModel = new GeneralProductionActionNewFormViewModel();
    public get _GeneralProductionAction(): GeneralProductionAction {
        return this._TTObject as GeneralProductionAction;
    }
    private GeneralProductionActionNewForm_DocumentUrl: string = '/api/GeneralProductionActionService/GeneralProductionActionNewForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                private changeDetectorRef: ChangeDetectorRef,
                private objectContextService: ObjectContextService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.GeneralProductionActionNewForm_DocumentUrl;
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

    protected async PreScript() {
        super.PreScript();
        if (this._GeneralProductionAction.Store instanceof MainStoreDefinition) {
            this._GeneralProductionAction.MKYS_TeslimEden = (<MainStoreDefinition>this._GeneralProductionAction.Store).GoodsAccountant.Name;
            this._GeneralProductionAction.MKYS_TeslimEdenObjID = (<MainStoreDefinition>this._GeneralProductionAction.Store).GoodsAccountant.ObjectID;
            this._GeneralProductionAction.MKYS_TeslimAlan = (<MainStoreDefinition>this._GeneralProductionAction.DestinationStore).GoodsAccountant.Name;
            this._GeneralProductionAction.MKYS_TeslimAlanObjID = (<MainStoreDefinition>this._GeneralProductionAction.DestinationStore).GoodsAccountant.ObjectID;
        }
        this._GeneralProductionAction.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckTuketim;
        this._GeneralProductionAction.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.icImkanlarlaUretim;
        this._GeneralProductionAction.MKYS_EMalzemeGrup = MKYS_EMalzemeGrupEnum.tibbiSarf;
        this._GeneralProductionAction.MKYS_EAlimYontemi = MKYS_EAlimYontemiEnum.bos;


        if (this._GeneralProductionAction.Store == null) {
            this._GeneralProductionAction.Store = this.inputStore;
            await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
        }

        if ((<MainStoreDefinition>this._GeneralProductionAction.Store).MKYS_ButceTuru != undefined) {
            if ((<MainStoreDefinition>this._GeneralProductionAction.Store).MKYS_ButceTuru === MKYS_EButceTurEnum.donerSermaye) {
                let budgetObj: Guid = new Guid("3511171d-06ae-4434-ad44-3579ee616ecb");
                let budgetTypeDef: any = await this.objectContextService.getObject(budgetObj, BudgetTypeDefinition.ObjectDefID);
                this._GeneralProductionAction.BudgetTypeDefinition = budgetTypeDef;
            }
            if ((<MainStoreDefinition>this._GeneralProductionAction.Store).MKYS_ButceTuru === MKYS_EButceTurEnum.genelButce) {
                let budgetObj: Guid = new Guid("57c410cc-afea-487a-8327-76e91a696a02");
                let budgetTypeDef: any = await this.objectContextService.getObject(budgetObj, BudgetTypeDefinition.ObjectDefID);
                this._GeneralProductionAction.BudgetTypeDefinition = budgetTypeDef;
            }
            this.BudgetTypeDefinition.ReadOnly = true;
        }

        this.MaterialDet.ListFilterExpression = 'STOCKS.STORE= \'' + this._GeneralProductionAction.Store.ObjectID + '\' AND STOCKS.INHELD > 0';
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new GeneralProductionAction();
        this.generalProductionActionNewFormViewModel = new GeneralProductionActionNewFormViewModel();
        this._ViewModel = this.generalProductionActionNewFormViewModel;
        this.generalProductionActionNewFormViewModel._GeneralProductionAction = this._TTObject as GeneralProductionAction;
        this.generalProductionActionNewFormViewModel._GeneralProductionAction.Store = new Store();
        this.generalProductionActionNewFormViewModel._GeneralProductionAction.Material = new Material();
        this.generalProductionActionNewFormViewModel._GeneralProductionAction.GeneralProductionOutDets = new Array<GeneralProductionOutDet>();
        this.generalProductionActionNewFormViewModel._GeneralProductionAction.BudgetTypeDefinition = new BudgetTypeDefinition();
    }

    protected loadViewModel() {
        let that = this;

        that.generalProductionActionNewFormViewModel = this._ViewModel as GeneralProductionActionNewFormViewModel;
        that._TTObject = this.generalProductionActionNewFormViewModel._GeneralProductionAction;
        if (this.generalProductionActionNewFormViewModel == null) {
            this.generalProductionActionNewFormViewModel = new GeneralProductionActionNewFormViewModel();
        }
        if (this.generalProductionActionNewFormViewModel._GeneralProductionAction == null) {
            this.generalProductionActionNewFormViewModel._GeneralProductionAction = new GeneralProductionAction();
        }
        let storeObjectID = that.generalProductionActionNewFormViewModel._GeneralProductionAction['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.generalProductionActionNewFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.generalProductionActionNewFormViewModel._GeneralProductionAction.Store = store;
            }
        }
        let materialObjectID = that.generalProductionActionNewFormViewModel._GeneralProductionAction['Material'];
        if (materialObjectID != null && (typeof materialObjectID === 'string')) {
            let material = that.generalProductionActionNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
             if (material) {
                that.generalProductionActionNewFormViewModel._GeneralProductionAction.Material = material;
            }
        }
        let budgetTypeDefinitionObjectID = that.generalProductionActionNewFormViewModel._GeneralProductionAction['BudgetTypeDefinition'];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === 'string')) {
            let budgetTypeDefinition = that.generalProductionActionNewFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
             if (budgetTypeDefinition) {
                that.generalProductionActionNewFormViewModel._GeneralProductionAction.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        that.generalProductionActionNewFormViewModel._GeneralProductionAction.GeneralProductionOutDets = that.generalProductionActionNewFormViewModel.GeneralProductionOutDetsGridList;
        for (let detailItem of that.generalProductionActionNewFormViewModel.GeneralProductionOutDetsGridList) {
            let materialObjID = detailItem['Material'];
            if (materialObjID != null) {
                let material = that.generalProductionActionNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.generalProductionActionNewFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType =
                                    that.generalProductionActionNewFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
        await this.load(GeneralProductionActionNewFormViewModel);
        if (this._GeneralProductionAction.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._GeneralProductionAction.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = '#F0F0F0';
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M14707", "Genel Üretim İşlemi ( Yeni )");
        this.changeDetectorRef.detectChanges();

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
    public onBudgetTypeDefinitionChanged(event): void {
        if (event != null) {
            if (this._GeneralProductionAction != null && this._GeneralProductionAction.BudgetTypeDefinition !== event) {
                this._GeneralProductionAction.BudgetTypeDefinition = event;
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


    GeneralProductionOutDets_CellValueChangedEmitted(data: any) {
        if (data && this.GeneralProductionOutDets_CellValueChanged && data.Row && data.Column) {
            //this.GeneralProductionOutDets.CurrentCell =
            //    {
            //        OwningRow: data.Row,
            //        OwningColumn: data.Column
            //    };
            this.GeneralProductionOutDets_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    onSelectionChange(data: any) {
    }
    public async GeneralProductionOutDets_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.GeneralProductionOutDets_CellValueChanged(data, rowIndex, columnIndex);
    }

    onRowInserting(data: GeneralProductionOutDet) {
    }

    onCellContentClicked(data: any) {
    }

    async initNewRow(data: any) {
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
        this.GeneralProductionOutDets.Height = 350;

        this.MaterialDet = new TTVisual.TTListBoxColumn();
        this.MaterialDet.ListDefName = 'MaterialListDefinition';
        this.MaterialDet.ListFilterExpression = 'IsOldMaterial = 0';
        this.MaterialDet.DataMember = 'Material';
        this.MaterialDet.AutoCompleteDialogHeight = '60%';
        this.MaterialDet.AutoCompleteDialogWidth = '90%';
        this.MaterialDet.Required = true;
        this.MaterialDet.DisplayIndex = 0;
        this.MaterialDet.HeaderText = i18n("M18545", "Malzeme");
        this.MaterialDet.Name = 'MaterialDet';
        this.MaterialDet.Width = 300;

        this.AmountGeneralProductionOutDet = new TTVisual.TTTextBoxColumn();
        this.AmountGeneralProductionOutDet.DataMember = 'Amount';
        this.AmountGeneralProductionOutDet.Required = true;
        this.AmountGeneralProductionOutDet.DisplayIndex = 1;
        this.AmountGeneralProductionOutDet.HeaderText = i18n("M19030", "Miktar");
        this.AmountGeneralProductionOutDet.Name = 'AmountGeneralProductionOutDet';
        this.AmountGeneralProductionOutDet.Width = 120;
        this.AmountGeneralProductionOutDet.IsNumeric = true;

        this.DistributionType = new TTVisual.TTListDefComboBoxColumn();
        this.DistributionType.ListDefName = 'DistributionTypeList';
        this.DistributionType.DataMember = 'Material.DistributionTypeName';
        this.DistributionType.DisplayIndex = 2;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = 'DistributionType';
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 120;

        this.Exiting = new TTVisual.TTTextBoxColumn();
        this.Exiting.DataMember = 'StoreStock';
        this.Exiting.DisplayIndex = 3;
        this.Exiting.HeaderText = i18n("M18957", "Mevcut");
        this.Exiting.Name = 'Exiting';
        this.Exiting.Width = 120;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = 'labelTransactionDate';
        this.labelTransactionDate.TabIndex = 7;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = '#F0F0F0';
        this.TransactionDate.Format = DateTimePickerFormat.Short;
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

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.ReadOnly = true;
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.BackColor = '#FFE3C6';
        this.BudgetTypeDefinition.Name = 'BudgetTypeDefinition';
        this.BudgetTypeDefinition.TabIndex = 131;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = '10%';
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = '20%';

        this.GeneralProductionOutDetsColumns = [this.MaterialDet, this.AmountGeneralProductionOutDet, this.DistributionType, this.Exiting];
        this.tttabcontrol1.Controls = [this.tttabpage1];
        this.tttabpage1.Controls = [this.Description];
        this.Controls = [this.tttabcontrol1, this.tttabpage1, this.BudgetTypeDefinition, this.Description,
        this.UnitPrice, this.StockActionID, this.Amount, this.MKYS_TeslimAlan, this.MKYS_TeslimEden,
        this.labelUnitPrice, this.labelStore, this.Store, this.labelMaterial, this.Material, this.GeneralProductionOutDets, this.MaterialDet, this.AmountGeneralProductionOutDet,
        this.DistributionType, this.Exiting, this.labelTransactionDate, this.TransactionDate, this.labelStockActionID, this.labelAmount, this.ttlabel7, this.labelMKYS_TeslimEden,
        this.labelMKYS_TeslimAlan, this.TTTeslimAlanButon, this.TTTeslimEdenButon];
    }
}