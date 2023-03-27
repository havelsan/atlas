//$96CFDD3C
import { Component, OnInit, NgZone } from '@angular/core';
import { MagistralPreparationActionCompletedFormViewModel } from './MagistralPreparationActionCompletedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { MagistralPreparationAction } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPackagingSubType } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPackagingType } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationDetail } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationSubType } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationType } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationUsedChemical } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationUsedDetail } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationUsedDrug } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationUsedMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'MagistralPreparationActionCompletedForm',
    templateUrl: './MagistralPreparationActionCompletedForm.html',
    providers: [MessageService]
})
export class MagistralPreparationActionCompletedForm extends TTVisual.TTForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    Amount: TTVisual.ITTTextBoxColumn;
    ChemicalAmount: TTVisual.ITTTextBoxColumn;
    ChemicalDistributionType: TTVisual.ITTListBoxColumn;
    cmdCalculateAmount: TTVisual.ITTButton;
    ConsumableMaterial: TTVisual.ITTListBoxColumn;
    ConsumableMaterialDistType: TTVisual.ITTListBoxColumn;
    Description: TTVisual.ITTTextBox;
    DestinationStore: TTVisual.ITTObjectListBox;
    DistributionType: TTVisual.ITTListBoxColumn;
    DrugAmount: TTVisual.ITTTextBoxColumn;
    ExpairDate: TTVisual.ITTDateTimePickerColumn;
    labelActionDate: TTVisual.ITTLabel;
    labelMagistralAmount: TTVisual.ITTLabel;
    labelProducedAmount: TTVisual.ITTLabel;
    labelStockActionID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelVolume: TTVisual.ITTLabel;
    labelVolumeGram: TTVisual.ITTLabel;
    MagistralAmount: TTVisual.ITTTextBox;
    MagistralPackagingSubType: TTVisual.ITTListDefComboBox;
    MagistralPackagingType: TTVisual.ITTListDefComboBox;
    MagistralPreparationDef: TTVisual.ITTListBoxColumn;
    MagistralPreparationDetails: TTVisual.ITTGrid;
    MagistralPreparationSubType: TTVisual.ITTListDefComboBox;
    MagistralPreparationType: TTVisual.ITTListDefComboBox;
    MagistralPreparationUsedChemicals: TTVisual.ITTGrid;
    MagistralPreparationUsedDrugs: TTVisual.ITTGrid;
    MagistralPreparationUsedMaterials: TTVisual.ITTGrid;
    MagistralPrice: TTVisual.ITTTextBox;
    MagistralVolume: TTVisual.ITTTextBox;
    Material: TTVisual.ITTListBoxColumn;
    MaterialAmount: TTVisual.ITTTextBoxColumn;
    NightShift: TTVisual.ITTCheckBox;
    ProducedAmount: TTVisual.ITTTextBox;
    Sterilization: TTVisual.ITTCheckBox;
    StockActionDetails: TTVisual.ITTGrid;
    StockActionID: TTVisual.ITTTextBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabcontrol2: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttabpage4: TTVisual.ITTTabPage;
    tttabpage5: TTVisual.ITTTabPage;
    tttabpage6: TTVisual.ITTTabPage;
    UsedChemical: TTVisual.ITTListBoxColumn;
    UsedDistributionType: TTVisual.ITTListBoxColumn;
    UsedDrug: TTVisual.ITTListBoxColumn;
    UsedMaterialAmount: TTVisual.ITTTextBoxColumn;
    public MagistralPreparationDetailsColumns = [];
    public MagistralPreparationUsedChemicalsColumns = [];
    public MagistralPreparationUsedDrugsColumns = [];
    public MagistralPreparationUsedMaterialsColumns = [];
    public StockActionDetailsColumns = [];
    public magistralPreparationActionCompletedFormViewModel: MagistralPreparationActionCompletedFormViewModel = new MagistralPreparationActionCompletedFormViewModel();
    public get _MagistralPreparationAction(): MagistralPreparationAction {
        return this._TTObject as MagistralPreparationAction;
    }
    private MagistralPreparationActionCompletedForm_DocumentUrl: string = '/api/MagistralPreparationActionService/MagistralPreparationActionCompletedForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('MAGISTRALPREPARATIONACTION', 'MagistralPreparationActionCompletedForm');
        this._DocumentServiceUrl = this.MagistralPreparationActionCompletedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MagistralPreparationAction();
        this.magistralPreparationActionCompletedFormViewModel = new MagistralPreparationActionCompletedFormViewModel();
        this._ViewModel = this.magistralPreparationActionCompletedFormViewModel;
        this.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction = this._TTObject as MagistralPreparationAction;
        this.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPreparationUsedDrugs = new Array<MagistralPreparationUsedDrug>();
        this.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPreparationUsedChemicals = new Array<MagistralPreparationUsedChemical>();
        this.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPreparationUsedMaterials = new Array<MagistralPreparationUsedMaterial>();
        this.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPreparationDetails = new Array<MagistralPreparationDetail>();
        this.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPreparationUsedDetails = new Array<MagistralPreparationUsedDetail>();
        this.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.Store = new Store();
        this.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPackagingType = new MagistralPackagingType();
        this.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPackagingSubType = new MagistralPackagingSubType();
        this.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPreparationSubType = new MagistralPreparationSubType();
        this.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPreparationType = new MagistralPreparationType();
    }

    protected loadViewModel() {
        let that = this;

        that.magistralPreparationActionCompletedFormViewModel = this._ViewModel as MagistralPreparationActionCompletedFormViewModel;
        that._TTObject = this.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction;
        if (this.magistralPreparationActionCompletedFormViewModel == null)
            this.magistralPreparationActionCompletedFormViewModel = new MagistralPreparationActionCompletedFormViewModel();
        if (this.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction == null)
            this.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction = new MagistralPreparationAction();
        that.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPreparationUsedDrugs = that.magistralPreparationActionCompletedFormViewModel.MagistralPreparationUsedDrugsGridList;
        for (let detailItem of that.magistralPreparationActionCompletedFormViewModel.MagistralPreparationUsedDrugsGridList) {
            let drugDefinitionObjectID = detailItem["DrugDefinition"];
            if (drugDefinitionObjectID != null && (typeof drugDefinitionObjectID === 'string')) {
                let drugDefinition = that.magistralPreparationActionCompletedFormViewModel.DrugDefinitions.find(o => o.ObjectID.toString() === drugDefinitionObjectID.toString());
                 if (drugDefinition) {
                    detailItem.DrugDefinition = drugDefinition;
                }
                if (drugDefinition != null) {
                    let stockCardObjectID = drugDefinition["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.magistralPreparationActionCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            drugDefinition.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.magistralPreparationActionCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                 if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        that.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPreparationUsedChemicals = that.magistralPreparationActionCompletedFormViewModel.MagistralPreparationUsedChemicalsGridList;
        for (let detailItem of that.magistralPreparationActionCompletedFormViewModel.MagistralPreparationUsedChemicalsGridList) {
            let magistralChemicalDefinitionObjectID = detailItem["MagistralChemicalDefinition"];
            if (magistralChemicalDefinitionObjectID != null && (typeof magistralChemicalDefinitionObjectID === 'string')) {
                let magistralChemicalDefinition = that.magistralPreparationActionCompletedFormViewModel.MagistralChemicalDefinitions.find(o => o.ObjectID.toString() === magistralChemicalDefinitionObjectID.toString());
                 if (magistralChemicalDefinition) {
                    detailItem.MagistralChemicalDefinition = magistralChemicalDefinition;
                }
                if (magistralChemicalDefinition != null) {
                    let materialObjectID = magistralChemicalDefinition["Material"];
                    if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                        let material = that.magistralPreparationActionCompletedFormViewModel.ConsumableMaterialDefinitions.find(o => o.ObjectID.toString() === materialObjectID.toString());
                         if (material) {
                            magistralChemicalDefinition.Material = material;
                        }
                        if (material != null) {
                            let stockCardObjectID = material["StockCard"];
                            if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                                let stockCard = that.magistralPreparationActionCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                                 if (stockCard) {
                                    material.StockCard = stockCard;
                                }
                                if (stockCard != null) {
                                    let distributionTypeObjectID = stockCard["DistributionType"];
                                    if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                        let distributionType = that.magistralPreparationActionCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
        }
        that.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPreparationUsedMaterials = that.magistralPreparationActionCompletedFormViewModel.MagistralPreparationUsedMaterialsGridList;
        for (let detailItem of that.magistralPreparationActionCompletedFormViewModel.MagistralPreparationUsedMaterialsGridList) {
            let consumableMaterialObjectID = detailItem["ConsumableMaterial"];
            if (consumableMaterialObjectID != null && (typeof consumableMaterialObjectID === 'string')) {
                let consumableMaterial = that.magistralPreparationActionCompletedFormViewModel.ConsumableMaterialDefinitions.find(o => o.ObjectID.toString() === consumableMaterialObjectID.toString());
                 if (consumableMaterial) {
                    detailItem.ConsumableMaterial = consumableMaterial;
                }
                if (consumableMaterial != null) {
                    let stockCardObjectID = consumableMaterial["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.magistralPreparationActionCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            consumableMaterial.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.magistralPreparationActionCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                 if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        that.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPreparationDetails = that.magistralPreparationActionCompletedFormViewModel.MagistralPreparationDetailsGridList;
        for (let detailItem of that.magistralPreparationActionCompletedFormViewModel.MagistralPreparationDetailsGridList) {
            let magistralPreparationDefObjectID = detailItem["MagistralPreparationDef"];
            if (magistralPreparationDefObjectID != null && (typeof magistralPreparationDefObjectID === 'string')) {
                let magistralPreparationDef = that.magistralPreparationActionCompletedFormViewModel.MagistralPreparationDefinitions.find(o => o.ObjectID.toString() === magistralPreparationDefObjectID.toString());
                 if (magistralPreparationDef) {
                    detailItem.MagistralPreparationDef = magistralPreparationDef;
                }
            }
        }
        that.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPreparationUsedDetails = that.magistralPreparationActionCompletedFormViewModel.StockActionDetailsGridList;
        for (let detailItem of that.magistralPreparationActionCompletedFormViewModel.StockActionDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.magistralPreparationActionCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.magistralPreparationActionCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.magistralPreparationActionCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                 if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        let storeObjectID = that.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.magistralPreparationActionCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.Store = store;
            }
        }
        let magistralPackagingTypeObjectID = that.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction["MagistralPackagingType"];
        if (magistralPackagingTypeObjectID != null && (typeof magistralPackagingTypeObjectID === 'string')) {
            let magistralPackagingType = that.magistralPreparationActionCompletedFormViewModel.MagistralPackagingTypes.find(o => o.ObjectID.toString() === magistralPackagingTypeObjectID.toString());
             if (magistralPackagingType) {
                that.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPackagingType = magistralPackagingType;
            }
        }
        let magistralPackagingSubTypeObjectID = that.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction["MagistralPackagingSubType"];
        if (magistralPackagingSubTypeObjectID != null && (typeof magistralPackagingSubTypeObjectID === 'string')) {
            let magistralPackagingSubType = that.magistralPreparationActionCompletedFormViewModel.MagistralPackagingSubTypes.find(o => o.ObjectID.toString() === magistralPackagingSubTypeObjectID.toString());
             if (magistralPackagingSubType) {
                that.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPackagingSubType = magistralPackagingSubType;
            }
        }
        let magistralPreparationSubTypeObjectID = that.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction["MagistralPreparationSubType"];
        if (magistralPreparationSubTypeObjectID != null && (typeof magistralPreparationSubTypeObjectID === 'string')) {
            let magistralPreparationSubType = that.magistralPreparationActionCompletedFormViewModel.MagistralPreparationSubTypes.find(o => o.ObjectID.toString() === magistralPreparationSubTypeObjectID.toString());
             if (magistralPreparationSubType) {
                that.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPreparationSubType = magistralPreparationSubType;
            }
        }
        let magistralPreparationTypeObjectID = that.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction["MagistralPreparationType"];
        if (magistralPreparationTypeObjectID != null && (typeof magistralPreparationTypeObjectID === 'string')) {
            let magistralPreparationType = that.magistralPreparationActionCompletedFormViewModel.MagistralPreparationTypes.find(o => o.ObjectID.toString() === magistralPreparationTypeObjectID.toString());
             if (magistralPreparationType) {
                that.magistralPreparationActionCompletedFormViewModel._MagistralPreparationAction.MagistralPreparationType = magistralPreparationType;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(MagistralPreparationActionCompletedFormViewModel);
        this.FormCaption = i18n("M18463", "Majistral İlaç Hazırlama");
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._MagistralPreparationAction != null && this._MagistralPreparationAction.ActionDate != event) {
                this._MagistralPreparationAction.ActionDate = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._MagistralPreparationAction != null && this._MagistralPreparationAction.Description != event) {
                this._MagistralPreparationAction.Description = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._MagistralPreparationAction != null && this._MagistralPreparationAction.Store != event) {
                this._MagistralPreparationAction.Store = event;
            }
        }
    }

    public onMagistralAmountChanged(event): void {
        if (event != null) {
            if (this._MagistralPreparationAction != null && this._MagistralPreparationAction.MagistralAmount != event) {
                this._MagistralPreparationAction.MagistralAmount = event;
            }
        }
    }

    public onMagistralPackagingSubTypeChanged(event): void {
        if (event != null) {
            if (this._MagistralPreparationAction != null && this._MagistralPreparationAction.MagistralPackagingSubType != event) {
                this._MagistralPreparationAction.MagistralPackagingSubType = event;
            }
        }
    }

    public onMagistralPackagingTypeChanged(event): void {
        if (event != null) {
            if (this._MagistralPreparationAction != null && this._MagistralPreparationAction.MagistralPackagingType != event) {
                this._MagistralPreparationAction.MagistralPackagingType = event;
            }
        }
    }

    public onMagistralPreparationSubTypeChanged(event): void {
        if (event != null) {
            if (this._MagistralPreparationAction != null && this._MagistralPreparationAction.MagistralPreparationSubType != event) {
                this._MagistralPreparationAction.MagistralPreparationSubType = event;
            }
        }
    }

    public onMagistralPreparationTypeChanged(event): void {
        if (event != null) {
            if (this._MagistralPreparationAction != null && this._MagistralPreparationAction.MagistralPreparationType != event) {
                this._MagistralPreparationAction.MagistralPreparationType = event;
            }
        }
    }

    public onMagistralPriceChanged(event): void {
        if (event != null) {
            if (this._MagistralPreparationAction != null && this._MagistralPreparationAction.MagistralPrice != event) {
                this._MagistralPreparationAction.MagistralPrice = event;
            }
        }
    }

    public onMagistralVolumeChanged(event): void {
        if (event != null) {
            if (this._MagistralPreparationAction != null && this._MagistralPreparationAction.Volume != event) {
                this._MagistralPreparationAction.Volume = event;
            }
        }
    }

    public onNightShiftChanged(event): void {
        if (event != null) {
            if (this._MagistralPreparationAction != null && this._MagistralPreparationAction.NightShift != event) {
                this._MagistralPreparationAction.NightShift = event;
            }
        }
    }

    public onProducedAmountChanged(event): void {
        if (event != null) {
            if (this._MagistralPreparationAction != null && this._MagistralPreparationAction.ProducedAmount != event) {
                this._MagistralPreparationAction.ProducedAmount = event;
            }
        }
    }

    public onSterilizationChanged(event): void {
        if (event != null) {
            if (this._MagistralPreparationAction != null && this._MagistralPreparationAction.Sterilization != event) {
                this._MagistralPreparationAction.Sterilization = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._MagistralPreparationAction != null && this._MagistralPreparationAction.StockActionID != event) {
                this._MagistralPreparationAction.StockActionID = event;
            }
        }
    }


    cmdCalculateAmount_Click(){}
    MagistralPreparationUsedDrugs_CellValueChangedEmitted(data: any){}
    MagistralPreparationUsedChemicals_CellValueChangedEmitted(data: any){}
    MagistralPreparationUsedMaterials_CellValueChangedEmitted(data: any){}
    MagistralPreparationDetails_CellValueChangedEmitted(data: any){}


    protected redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.Sterilization, "Value", this.__ttObject, "Sterilization");
        redirectProperty(this.NightShift, "Value", this.__ttObject, "NightShift");
        redirectProperty(this.MagistralPreparationType, "SelectedObject", this.__ttObject, "MagistralPreparationType");
        redirectProperty(this.MagistralVolume, "Text", this.__ttObject, "Volume");
        redirectProperty(this.MagistralPackagingType, "SelectedObject", this.__ttObject, "MagistralPackagingType");
        redirectProperty(this.MagistralPrice, "Text", this.__ttObject, "MagistralPrice");
        redirectProperty(this.MagistralPreparationSubType, "SelectedObject", this.__ttObject, "MagistralPreparationSubType");
        redirectProperty(this.ProducedAmount, "Text", this.__ttObject, "ProducedAmount");
        redirectProperty(this.MagistralPackagingSubType, "SelectedObject", this.__ttObject, "MagistralPackagingSubType");
        redirectProperty(this.MagistralAmount, "Text", this.__ttObject, "MagistralAmount");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.cmdCalculateAmount = new TTVisual.TTButton();
        this.cmdCalculateAmount.Text = i18n("M15755", "Hesapla");
        this.cmdCalculateAmount.Name = "cmdCalculateAmount";
        this.cmdCalculateAmount.TabIndex = 45;

        this.labelMagistralAmount = new TTVisual.TTLabel();
        this.labelMagistralAmount.Text = i18n("M23963", "Üretim Miktarı");
        this.labelMagistralAmount.Name = "labelMagistralAmount";
        this.labelMagistralAmount.TabIndex = 44;

        this.MagistralAmount = new TTVisual.TTTextBox();
        this.MagistralAmount.Name = "MagistralAmount";
        this.MagistralAmount.TabIndex = 43;

        this.MagistralVolume = new TTVisual.TTTextBox();
        this.MagistralVolume.Name = "MagistralVolume";
        this.MagistralVolume.TabIndex = 41;
        this.MagistralVolume.Visible = false;

        this.MagistralPrice = new TTVisual.TTTextBox();
        this.MagistralPrice.BackColor = "#F0F0F0";
        this.MagistralPrice.ReadOnly = true;
        this.MagistralPrice.Name = "MagistralPrice";
        this.MagistralPrice.TabIndex = 40;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M18468", "Majistral Üretim Fiyatı");
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 42;

        this.Sterilization = new TTVisual.TTCheckBox();
        this.Sterilization.Value = false;
        this.Sterilization.Title = i18n("M22279", "Sterilizasyon");
        this.Sterilization.Name = "Sterilization";
        this.Sterilization.TabIndex = 39;

        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = "tttabcontrol2";
        this.tttabcontrol2.TabIndex = 37;

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 0;
        this.tttabpage3.TabIndex = 0;
        this.tttabpage3.Text = i18n("M17936", "Kullanılan İlaçlar");
        this.tttabpage3.Name = "tttabpage3";

        this.MagistralPreparationUsedDrugs = new TTVisual.TTGrid();
        this.MagistralPreparationUsedDrugs.Name = "MagistralPreparationUsedDrugs";
        this.MagistralPreparationUsedDrugs.TabIndex = 0;
        this.MagistralPreparationUsedDrugs.Height = 100;
        this.MagistralPreparationUsedDrugs.ReadOnly = true;
        this.MagistralPreparationUsedDrugs.AllowUserToAddRows = false;


        this.UsedDrug = new TTVisual.TTListBoxColumn();
        this.UsedDrug.ListDefName = "DrugList";
        this.UsedDrug.DataMember = "DrugDefinition";
        this.UsedDrug.DisplayIndex = 0;
        this.UsedDrug.HeaderText = i18n("M16287", "İlaç");
        this.UsedDrug.Name = "UsedDrug";
        this.UsedDrug.Width = 500;

        this.DrugAmount = new TTVisual.TTTextBoxColumn();
        this.DrugAmount.DataMember = "Amount";
        this.DrugAmount.Required = true;
        this.DrugAmount.DisplayIndex = 1;
        this.DrugAmount.HeaderText = i18n("M19030", "Miktar");
        this.DrugAmount.Name = "DrugAmount";
        this.DrugAmount.Width = 100;

        this.DistributionType = new TTVisual.TTListBoxColumn();
        this.DistributionType.ListDefName = "DistributionTypeList";
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 2;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.tttabpage4 = new TTVisual.TTTabPage();
        this.tttabpage4.DisplayIndex = 1;
        this.tttabpage4.TabIndex = 1;
        this.tttabpage4.Text = i18n("M17933", "Kullanılan Hammaddeler");
        this.tttabpage4.Name = "tttabpage4";

        this.MagistralPreparationUsedChemicals = new TTVisual.TTGrid();
        this.MagistralPreparationUsedChemicals.Name = "MagistralPreparationUsedChemicals";
        this.MagistralPreparationUsedChemicals.TabIndex = 0;
        this.MagistralPreparationUsedChemicals.Height = 100;
        this.MagistralPreparationUsedChemicals.ReadOnly = true;
        this.MagistralPreparationUsedChemicals.AllowUserToAddRows = false;

        this.UsedChemical = new TTVisual.TTListBoxColumn();
        this.UsedChemical.ListDefName = "MagistralChemicalDefinitionListDefinition";
        this.UsedChemical.DataMember = "MagistralChemicalDefinition";
        this.UsedChemical.DisplayIndex = 0;
        this.UsedChemical.HeaderText = i18n("M15099", "Hammadde");
        this.UsedChemical.Name = "UsedChemical";
        this.UsedChemical.Width = 500;

        this.ChemicalAmount = new TTVisual.TTTextBoxColumn();
        this.ChemicalAmount.DataMember = "Amount";
        this.ChemicalAmount.Required = true;
        this.ChemicalAmount.DisplayIndex = 1;
        this.ChemicalAmount.HeaderText = i18n("M19030", "Miktar");
        this.ChemicalAmount.Name = "ChemicalAmount";
        this.ChemicalAmount.Width = 100;

        this.ChemicalDistributionType = new TTVisual.TTListBoxColumn();
        this.ChemicalDistributionType.ListDefName = "DistributionTypeList";
        this.ChemicalDistributionType.DataMember = "DistributionType";
        this.ChemicalDistributionType.DisplayIndex = 2;
        this.ChemicalDistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.ChemicalDistributionType.Name = "ChemicalDistributionType";
        this.ChemicalDistributionType.ReadOnly = true;
        this.ChemicalDistributionType.Width = 100;

        this.tttabpage6 = new TTVisual.TTTabPage();
        this.tttabpage6.DisplayIndex = 2;
        this.tttabpage6.TabIndex = 3;
        this.tttabpage6.Text = i18n("M17947", "Kullanılan Sarf Malzemeler");
        this.tttabpage6.Name = "tttabpage6";

        this.MagistralPreparationUsedMaterials = new TTVisual.TTGrid();
        this.MagistralPreparationUsedMaterials.Name = "MagistralPreparationUsedMaterials";
        this.MagistralPreparationUsedMaterials.TabIndex = 46;
        this.MagistralPreparationUsedMaterials.Height = 100;
        this.MagistralPreparationUsedMaterials.ReadOnly = true;
        this.MagistralPreparationUsedMaterials.AllowUserToAddRows = false;

        this.ConsumableMaterial = new TTVisual.TTListBoxColumn();
        this.ConsumableMaterial.ListDefName = "ConsumableMaterialList";
        this.ConsumableMaterial.DataMember = "ConsumableMaterial";
        this.ConsumableMaterial.DisplayIndex = 0;
        this.ConsumableMaterial.HeaderText = i18n("M21326", "Sarf Malzeme");
        this.ConsumableMaterial.Name = "ConsumableMaterial";
        this.ConsumableMaterial.Width = 500;

        this.MaterialAmount = new TTVisual.TTTextBoxColumn();
        this.MaterialAmount.DataMember = "Amount";
        this.MaterialAmount.Required = true;
        this.MaterialAmount.DisplayIndex = 1;
        this.MaterialAmount.HeaderText = i18n("M19030", "Miktar");
        this.MaterialAmount.Name = "MaterialAmount";
        this.MaterialAmount.Width = 100;

        this.ConsumableMaterialDistType = new TTVisual.TTListBoxColumn();
        this.ConsumableMaterialDistType.ListDefName = "DistributionTypeList";
        this.ConsumableMaterialDistType.DataMember = "DistributionType";
        this.ConsumableMaterialDistType.DisplayIndex = 2;
        this.ConsumableMaterialDistType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.ConsumableMaterialDistType.Name = "ConsumableMaterialDistType";
        this.ConsumableMaterialDistType.ReadOnly = true;
        this.ConsumableMaterialDistType.Width = 100;

        this.tttabpage5 = new TTVisual.TTTabPage();
        this.tttabpage5.DisplayIndex = 3;
        this.tttabpage5.TabIndex = 2;
        this.tttabpage5.Text = i18n("M10469", "Açıklama");
        this.tttabpage5.Name = "tttabpage5";

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;
        //this.Description.Height = 100;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 36;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M23950", "Üretilen Majistral");
        this.tttabpage1.Name = "tttabpage1";

        this.MagistralPreparationDetails = new TTVisual.TTGrid();
        this.MagistralPreparationDetails.Required = true;
        this.MagistralPreparationDetails.Name = "MagistralPreparationDetails";
        this.MagistralPreparationDetails.TabIndex = 34;
        this.MagistralPreparationDetails.Height = 350;

        this.MagistralPreparationDef = new TTVisual.TTListBoxColumn();
        this.MagistralPreparationDef.ListDefName = "MagistralPreparationList";
        this.MagistralPreparationDef.DataMember = "MagistralPreparationDef";
        this.MagistralPreparationDef.Required = true;
        this.MagistralPreparationDef.DisplayIndex = 0;
        this.MagistralPreparationDef.HeaderText = i18n("M23947", "Üretilecek Majistral İlaç");
        this.MagistralPreparationDef.Name = "MagistralPreparationDef";
        this.MagistralPreparationDef.Width = 500;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.Required = true;
        this.Amount.DisplayIndex = 1;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.ReadOnly = true;
        this.Amount.Width = 80;

        this.ExpairDate = new TTVisual.TTDateTimePickerColumn();
        this.ExpairDate.Format = DateTimePickerFormat.Custom;
        this.ExpairDate.CustomFormat = "MM/yyyy";
        this.ExpairDate.DataMember = "ExpirationDate";
        this.ExpairDate.Required = true;
        this.ExpairDate.DisplayIndex = 2;
        this.ExpairDate.HeaderText = "S.K.Tarihi";
        this.ExpairDate.Name = "ExpairDate";
        this.ExpairDate.Width = 100;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.TabIndex = 1;
        this.tttabpage2.Text = i18n("M17939", "Kullanılan Malzeme");
        this.tttabpage2.Name = "tttabpage2";

        this.StockActionDetails = new TTVisual.TTGrid();
        this.StockActionDetails.Required = true;
        this.StockActionDetails.ReadOnly = true;
        this.StockActionDetails.Name = "StockActionDetails";
        this.StockActionDetails.TabIndex = 35;
        this.StockActionDetails.Height = 350;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "MaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 0;
        this.Material.HeaderText = i18n("M18545", "Malzeme");
        this.Material.Name = "Material";
        this.Material.Width = 500;

        this.UsedMaterialAmount = new TTVisual.TTTextBoxColumn();
        this.UsedMaterialAmount.DataMember = "Amount";
        this.UsedMaterialAmount.DisplayIndex = 1;
        this.UsedMaterialAmount.HeaderText = i18n("M19030", "Miktar");
        this.UsedMaterialAmount.Name = "UsedMaterialAmount";
        this.UsedMaterialAmount.Width = 80;

        this.UsedDistributionType = new TTVisual.TTListBoxColumn();
        this.UsedDistributionType.ListDefName = "DistributionTypeList";
        this.UsedDistributionType.DataMember = "DistributionType";
        this.UsedDistributionType.DisplayIndex = 2;
        this.UsedDistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.UsedDistributionType.Name = "UsedDistributionType";
        this.UsedDistributionType.ReadOnly = true;
        this.UsedDistributionType.Width = 100;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 10;

        this.ProducedAmount = new TTVisual.TTTextBox();
        this.ProducedAmount.Name = "ProducedAmount";
        this.ProducedAmount.TabIndex = 41;
        this.ProducedAmount.Visible = false;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 29;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ReadOnly = true;
        this.DestinationStore.ListDefName = "StoresList";
        this.DestinationStore.Name = "DestinationStore";
        this.DestinationStore.TabIndex = 28;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 15;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 14;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 11;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M20471", "Preparat Türü");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 11;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M20469", "Preparat Alt Türü");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 11;

        this.MagistralPackagingType = new TTVisual.TTListDefComboBox();
        this.MagistralPackagingType.ListDefName = "MagistralPackagingTypeListDefinition";
        this.MagistralPackagingType.Required = true;
        this.MagistralPackagingType.BackColor = "#FFE3C6";
        this.MagistralPackagingType.Name = "MagistralPackagingType";
        this.MagistralPackagingType.TabIndex = 38;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M10764", "Ambalaj");
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 11;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M12001", "Boyut");
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 11;

        this.MagistralPackagingSubType = new TTVisual.TTListDefComboBox();
        this.MagistralPackagingSubType.ListDefName = "MagistralPackagingSubTypeListDefinition";
        this.MagistralPackagingSubType.LinkedControlName = "MagistralPackagingType";
        this.MagistralPackagingSubType.Required = true;
        this.MagistralPackagingSubType.BackColor = "#FFE3C6";
        this.MagistralPackagingSubType.Name = "MagistralPackagingSubType";
        this.MagistralPackagingSubType.TabIndex = 38;

        this.NightShift = new TTVisual.TTCheckBox();
        this.NightShift.Value = false;
        this.NightShift.Title = i18n("M19491", "Nöbet");
        this.NightShift.Name = "NightShift";
        this.NightShift.TabIndex = 39;

        this.labelVolume = new TTVisual.TTLabel();
        this.labelVolume.Text = i18n("M19030", "Miktar");
        this.labelVolume.Name = "labelVolume";
        this.labelVolume.TabIndex = 11;
        this.labelVolume.Visible = false;

        this.labelProducedAmount = new TTVisual.TTLabel();
        this.labelProducedAmount.Text = i18n("M10505", "Adet");
        this.labelProducedAmount.Name = "labelProducedAmount";
        this.labelProducedAmount.TabIndex = 11;
        this.labelProducedAmount.Visible = false;

        this.labelVolumeGram = new TTVisual.TTLabel();
        this.labelVolumeGram.Text = i18n("M14966", "gram");
        this.labelVolumeGram.Name = "labelVolumeGram";
        this.labelVolumeGram.TabIndex = 11;
        this.labelVolumeGram.Visible = false;

        this.MagistralPreparationSubType = new TTVisual.TTListDefComboBox();
        this.MagistralPreparationSubType.ListDefName = "MagistralPreparationSubTypeListDefinition";
        this.MagistralPreparationSubType.LinkedControlName = "MagistralPreparationType";
        this.MagistralPreparationSubType.Name = "MagistralPreparationSubType";
        this.MagistralPreparationSubType.TabIndex = 38;

        this.MagistralPreparationType = new TTVisual.TTListDefComboBox();
        this.MagistralPreparationType.ListDefName = "MagistralPreparationTypeListDefinition";
        this.MagistralPreparationType.Required = true;
        this.MagistralPreparationType.BackColor = "#FFE3C6";
        this.MagistralPreparationType.Name = "MagistralPreparationType";
        this.MagistralPreparationType.TabIndex = 38;

        this.MagistralPreparationUsedDrugsColumns = [this.UsedDrug, this.DrugAmount, this.DistributionType];
        this.MagistralPreparationUsedChemicalsColumns = [this.UsedChemical, this.ChemicalAmount, this.ChemicalDistributionType];
        this.MagistralPreparationUsedMaterialsColumns = [this.ConsumableMaterial, this.MaterialAmount, this.ConsumableMaterialDistType];
        this.MagistralPreparationDetailsColumns = [this.MagistralPreparationDef, this.Amount, this.ExpairDate];
        this.StockActionDetailsColumns = [this.Material, this.UsedMaterialAmount, this.UsedDistributionType];
        this.tttabcontrol2.Controls = [this.tttabpage3, this.tttabpage4, this.tttabpage6, this.tttabpage5];
        this.tttabpage3.Controls = [this.MagistralPreparationUsedDrugs];
        this.tttabpage4.Controls = [this.MagistralPreparationUsedChemicals];
        this.tttabpage6.Controls = [this.MagistralPreparationUsedMaterials];
        this.tttabpage5.Controls = [this.Description];
        this.tttabcontrol1.Controls = [this.tttabpage1, this.tttabpage2];
        this.tttabpage1.Controls = [this.MagistralPreparationDetails];
        this.tttabpage2.Controls = [this.StockActionDetails];
        this.Controls = [this.cmdCalculateAmount, this.labelMagistralAmount, this.MagistralAmount, this.MagistralVolume, this.MagistralPrice, this.ttlabel5, this.Sterilization, this.tttabcontrol2, this.tttabpage3, this.MagistralPreparationUsedDrugs, this.UsedDrug, this.DrugAmount, this.DistributionType, this.tttabpage4, this.MagistralPreparationUsedChemicals, this.UsedChemical, this.ChemicalAmount, this.ChemicalDistributionType, this.tttabpage6, this.MagistralPreparationUsedMaterials, this.ConsumableMaterial, this.MaterialAmount, this.ConsumableMaterialDistType, this.tttabpage5, this.Description, this.tttabcontrol1, this.tttabpage1, this.MagistralPreparationDetails, this.MagistralPreparationDef, this.Amount, this.ExpairDate, this.tttabpage2, this.StockActionDetails, this.Material, this.UsedMaterialAmount, this.UsedDistributionType, this.StockActionID, this.ProducedAmount, this.labelStore, this.DestinationStore, this.labelActionDate, this.ActionDate, this.labelStockActionID, this.ttlabel1, this.ttlabel2, this.MagistralPackagingType, this.ttlabel3, this.ttlabel4, this.MagistralPackagingSubType, this.NightShift, this.labelVolume, this.labelProducedAmount, this.labelVolumeGram, this.MagistralPreparationSubType, this.MagistralPreparationType];
        for (let control of this.Controls) {
                control.ReadOnly = true;
                control.Enabled = false;
        }
    }
}
