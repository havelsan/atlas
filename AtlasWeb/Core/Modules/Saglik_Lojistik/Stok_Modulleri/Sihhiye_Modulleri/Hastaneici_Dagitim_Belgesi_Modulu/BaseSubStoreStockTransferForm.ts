//$DDA6402F
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { BaseSubStoreStockTransferFormViewModel } from './BaseSubStoreStockTransferFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResUserService } from "ObjectClassService/ResUserService";
import { StockActionBaseForm } from "Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StockActionBaseForm";
import { StockActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { SubStoreStockTransfer } from 'NebulaClient/Model/AtlasClientModel';

import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { SubStoreStockTransferMat } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { StockLevelTypeService } from "ObjectClassService/StockLevelTypeService";
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelService } from "ObjectClassService/StockLevelService";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DxDataGridComponent } from 'devextreme-angular';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";
import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';



import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';

@Component({
    selector: 'BaseSubStoreStockTransferForm',
    templateUrl: './BaseSubStoreStockTransferForm.html',
    providers: [MessageService]
})
export class BaseSubStoreStockTransferForm extends StockActionBaseForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    AmountSubStoreStockTransferMat: TTVisual.ITTTextBoxColumn;
    SubStoreInheld:TTVisual.ITTTextBoxColumn;
    Description: TTVisual.ITTTextBox;
    DescriptionAndSignTabControl: TTVisual.ITTTabControl;
    DescriptionTabpage: TTVisual.ITTTabPage;
    DestinationStore: TTVisual.ITTObjectListBox;
    Detail: TTVisual.ITTButtonColumn;
    Distrubitontype: TTVisual.ITTTextBoxColumn;
    IsDeputy: TTVisual.ITTCheckBoxColumn;
    labelActionDate: TTVisual.ITTLabel;
    labelDestinationStore: TTVisual.ITTLabel;
    labelMKYS_TeslimAlan: TTVisual.ITTLabel;
    labelMKYS_TeslimEden: TTVisual.ITTLabel;
    labelStockActionID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    MaterialBarcode: TTVisual.ITTTextBoxColumn;
    MaterialSubStoreStockTransferMat: TTVisual.ITTListBoxColumn;
    MaterialTabPage: TTVisual.ITTTabPage;
    MKYS_TeslimAlan: TTButtonTextBox;
    MKYS_TeslimEden: TTButtonTextBox;
    RequestAmountSubStoreStockTransferMat: TTVisual.ITTTextBoxColumn;
    SignTabpage: TTVisual.ITTTabPage;
    SignUser: TTVisual.ITTListBoxColumn;
    SignUserType: TTVisual.ITTEnumComboBoxColumn;
    StockActionID: TTVisual.ITTTextBox;
    StockActionSignDetails: TTVisual.ITTGrid;
    StockLevelType: TTVisual.ITTListBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    SubStoreStockTransferMaterials: TTVisual.ITTGrid;
    ttlabel1: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    TTTeslimAlanButon: TTVisual.ITTButton;
    TTTeslimEdenButon: TTVisual.ITTButton;
    public StockActionSignDetailsColumns = [];
    public SubStoreStockTransferMaterialsColumns = [];
    public baseSubStoreStockTransferFormViewModel: BaseSubStoreStockTransferFormViewModel = new BaseSubStoreStockTransferFormViewModel();
    public get _SubStoreStockTransfer(): SubStoreStockTransfer {
        return this._TTObject as SubStoreStockTransfer;
    }
    private BaseSubStoreStockTransferForm_DocumentUrl: string = '/api/SubStoreStockTransferService/BaseSubStoreStockTransferForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseSubStoreStockTransferForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    //#region dx-data-grid çevirme
    public selectedMaterial: Material;
    public selectedStockLevelType: StockLevelType;
    public stockLeveltypeArray: Array<StockLevelType> = new Array<StockLevelType>();

    @ViewChild('materialGrid') materialGrid: DxDataGridComponent;
    public async stateChange(event: FormSaveInfo) {
        this.materialGrid.instance.closeEditCell();
        this.materialGrid.instance.saveEditData();
        await super.setState(event.transDef, event);
    }

    public async onSaveButtonClick(event: FormSaveInfo) {
        this.materialGrid.instance.closeEditCell();
        this.materialGrid.instance.saveEditData();
        await super.saveForm(event);
    }

    public async onMaterialSelectionChange(event: any) {
        if (this.stockLeveltypeArray.length == 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
    }

    public async btnAddClick() {
        if (this.selectedMaterial == null)
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        else
            if (!this._SubStoreStockTransfer.SubStoreStockTransferMaterials.find(x => x.Material.ObjectID == this.selectedMaterial.ObjectID)) {
                if (this._SubStoreStockTransfer.Store == null) {
                    this.selectedMaterial = null;
                    ServiceLocator.MessageService.showError("İstek yapacağınız depoyu seçmeden malzeme ekleyemezsiniz.");
                } else {
                    let newRow: SubStoreStockTransferMat = new SubStoreStockTransferMat();
                    newRow.Material = this.selectedMaterial;
                    newRow.StockLevelType = this.selectedStockLevelType;
                    newRow.Status = StockActionDetailStatusEnum.New;
                    let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(newRow.Material.ObjectID, this._SubStoreStockTransfer.Store.ObjectID, newRow.StockLevelType.ObjectID);
                    newRow.StoreStock = stockInheld;
                    let stockInheldSubStore: number = await StockLevelService.StockInheldWithStockLevel(newRow.Material.ObjectID, this._SubStoreStockTransfer.DestinationStore.ObjectID, newRow.StockLevelType.ObjectID);
                    newRow.DestinationStoreStock = stockInheldSubStore;
                    //newRow.VatRate = this.selectedMaterial.MaterialVatRates.find(x => x.StartDate <= this._ChattelDocumentWithPurchase.TransactionDate && x.EndDate >= this._ChattelDocumentWithPurchase.TransactionDate).VatRate;
                    this._SubStoreStockTransfer.SubStoreStockTransferMaterials.push(newRow);
                    this.Store.ReadOnly = true;
                }
            }
            else
                ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
    }

    public onMaterialGridRowRemoving(event: any) {
        if (event.key.ObjectID != null && this._SubStoreStockTransfer.CurrentStateDefID == SubStoreStockTransfer.SubStoreStockTransferStates.New) {
            this._SubStoreStockTransfer.SubStoreStockTransferMaterials.find(x => x.ObjectID == event.data.ObjectID).EntityState = EntityStateEnum.Deleted;
            this.materialGrid.instance.filter(['EntityState', '<>', 1]);
            event.cancel = true;
        }
    }

    public onMaterialGridRowRemoved(event: any) {
        //this.CalculateFormTotalPrice();
    }

    public onMaterialGridRowUpdated(event: any) {
        //console.log(event);
        this.MaterialGridCellChanged(event);
    }

    public async MaterialGridCellChanged(event: any) {
        let subStoreStockTransferMat = <SubStoreStockTransferMat>event.key;
        if (subStoreStockTransferMat.RequestAmount > subStoreStockTransferMat.Amount) {
            subStoreStockTransferMat.RequestAmount = subStoreStockTransferMat.Amount;
        }
    }

    public MaterialGridColumns = null;

    public CreateGridColumns(showStoreStockColumn?: boolean): Array<any> {
        if (this.MaterialGridColumns == null)
            return this.MaterialGridColumns = [
                {
                    caption: i18n("M18550", "Malzeme Adı"),
                    dataField: 'Material.Name',
                    allowEditing: false,
                    width: 300
                },
                {
                    caption: 'Barkod',
                    dataField: 'Material.Barcode',
                    allowEditing: false,
                    width: 120
                },
                {
                    caption: i18n("M19908", "Ölçü Birimi"),
                    dataField: 'Material.DistributionTypeName',
                    allowEditing: false,
                    //width: 'auto'
                },
                {
                    caption: i18n("M16713", "İstenen Miktar"),
                    dataField: 'RequestAmount',
                    dataType: 'number',
                    allowEditing: showStoreStockColumn != null ? showStoreStockColumn : false,
                    //allowEditing: showStoreStockColumn != null ? showStoreStockColumn : true,
                    // format: "#",
                    // editorOptions: {
                    //     onKeyPress: function (e) {
                    //         var event = e.event,
                    //             str = String.fromCharCode(event.keyCode);
                    //         if (!/[0-9]/.test(str))
                    //             event.preventDefault();
                    //     }
                    // },
                    width: 120
                },
                {
                    caption: i18n("M12625", "Depo Mevcudu"),
                    dataField: 'StoreStock',
                    dataType: 'number',
                    visible: showStoreStockColumn != null ? showStoreStockColumn : false,
                    allowEditing: false,
                    // editorOptions: {
                    //     format: function (value) {
                    //         return Math.Round(value, 6) + ' TL';
                    //     }
                    //     //format: "#,##0.## TL",
                    // },
                    //width: 'auto'
                },
                {
                    caption: 'Cep Depo Mevcudu',
                    dataField: 'DestinationStoreStock',
                    dataType: 'number',
                    visible: showStoreStockColumn != null ? showStoreStockColumn : false,
                    allowEditing: false  
                },
                {
                    caption: i18n("M19030", "Miktar"),
                    dataField: 'Amount',
                    dataType: 'number',
                    allowEditing: showStoreStockColumn != null ? !showStoreStockColumn : false,
                    visible: showStoreStockColumn != null ? !showStoreStockColumn : true,
                    // editorOptions: {
                    //     format: function (value) {
                    //         return Math.Round(value, 6) + ' TL';
                    //     }
                    //     //format: "#,##0.## TL",
                    // },
                    //width: 'auto'
                },
                {
                    caption: i18n("M18519", "Malın Durumu"),
                    dataField: 'StockLevelType.Description',
                    // editorOptions: {
                    //     format: function (value) {
                    //         return Math.Round(value, 5) + ' %';
                    //     }
                    //     //format: "#,##0.## TL",
                    // },
                    width: 100
                }
            ];
    }

    //#endregion

    // ***** Method declarations start *****

    private async DestinationStore_SelectedObjectChanged(): Promise<void> {
        if (this.DestinationStore.SelectedObjectID === this.Store.SelectedObjectID)
            throw new Exception(i18n("M11340", "Aynı Depoya İşlem Başlatılamaz!"));
    }
    private async SubStoreStockTransferMaterials_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        if (this.SubStoreStockTransferMaterials.CurrentCell.OwningColumn.Name === "Detail")
            this.ShowStockActionDetailForm(<StockActionDetail>this.SubStoreStockTransferMaterials.CurrentCell.OwningRow.TTObject);
    }
    private async SubStoreStockTransferMaterials_CellDoubleClick(rowIndex: number, columnIndex: number): Promise<void> {
        /*if (this instanceof SubStoreStockTransferApprovalForm)
            CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, this.SubStoreStockTransferMaterials);*/
    }
    public async TTTeslimAlanButon_Click(): Promise<void> {

        let resUser: Array<ResUser> = (await ResUserService.GetAllUser(" WHERE ISACTIVE = 1 "));
        let selectedPersonel: ResUser = null;
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let user of resUser) {
            multiSelectForm.AddMSItem(user.Name, user.ObjectID.toString(), user);
        }
        let key: string = await multiSelectForm.GetMSItem(this.ParentForm, i18n("M23225", "Teslim Alan Personel Seçin"));
        if (String.isNullOrEmpty(key))
            TTVisual.InfoBox.Show(i18n("M15736", "Herhangibir Personel Seçilmedi."), MessageIconEnum.ErrorMessage);
        else {
            selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
            this.MKYS_TeslimAlan.Text = selectedPersonel.Name.toString();
            this._SubStoreStockTransfer.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;
        }
    }
    public async TTTeslimEdenButon_Click(): Promise<void> {

        let resUser: Array<ResUser> = (await ResUserService.GetAllUser(" WHERE ISACTIVE = 1 "));
        let selectedPersonel: ResUser = null;
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let user of resUser) {
            multiSelectForm.AddMSItem(user.Name, user.ObjectID.toString(), user);
        }
        let key: string = await multiSelectForm.GetMSItem(this.ParentForm, i18n("M23234", "Teslim Eden Personeli Seçin"));
        if (String.isNullOrEmpty(key))
            TTVisual.InfoBox.Show(i18n("M15736", "Herhangibir Personel Seçilmedi."), MessageIconEnum.ErrorMessage);
        else {
            selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
            this.MKYS_TeslimEden.Text = selectedPersonel.Name.toString();
            this._SubStoreStockTransfer.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
        }
    }
    protected async PreScript() {
        await super.PreScript();

    }
    public async StockActionOutDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        let subStoreStockTransferMat: SubStoreStockTransferMat = <SubStoreStockTransferMat>(data.Row.TTObject);
        if (subStoreStockTransferMat.Status === undefined) {
            subStoreStockTransferMat.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            subStoreStockTransferMat.StockLevelType = stockLeveltypeArray[0];
        }
        if (data.Column.Name === "MaterialSubStoreStockTransferMat" || data.Column.Name === "StockLevelType") {
            if (subStoreStockTransferMat.Material != null && subStoreStockTransferMat.StockLevelType != null) {
                if (subStoreStockTransferMat.Material.ObjectID != null) {
                    let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(subStoreStockTransferMat.Material.ObjectID, this._SubStoreStockTransfer.Store.ObjectID, subStoreStockTransferMat.StockLevelType.ObjectID);
                    subStoreStockTransferMat.StoreStock = stockInheld;
                }
                if (subStoreStockTransferMat.Material.ObjectID != null) {
                    let stockInheldSubStore: number = await StockLevelService.StockInheldWithStockLevel(subStoreStockTransferMat.Material.ObjectID, this._SubStoreStockTransfer.DestinationStore.ObjectID, subStoreStockTransferMat.StockLevelType.ObjectID);
                    subStoreStockTransferMat.DestinationStoreStock = stockInheldSubStore;
                }
                this.AmountSubStoreStockTransferMat.ReadOnly = true;
            }
        }
        if (data.Column.Name === 'RequestAmountSubStoreStockTransferMat') {
            if (subStoreStockTransferMat.RequestAmount > subStoreStockTransferMat.Amount) {
                subStoreStockTransferMat.RequestAmount = subStoreStockTransferMat.Amount;
            }
        }
        
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SubStoreStockTransfer();
        this.baseSubStoreStockTransferFormViewModel = new BaseSubStoreStockTransferFormViewModel();
        this._ViewModel = this.baseSubStoreStockTransferFormViewModel;
        this.baseSubStoreStockTransferFormViewModel._SubStoreStockTransfer = this._TTObject as SubStoreStockTransfer;
        this.baseSubStoreStockTransferFormViewModel._SubStoreStockTransfer.DestinationStore = new Store();
        this.baseSubStoreStockTransferFormViewModel._SubStoreStockTransfer.Store = new Store();
        this.baseSubStoreStockTransferFormViewModel._SubStoreStockTransfer.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.baseSubStoreStockTransferFormViewModel._SubStoreStockTransfer.SubStoreStockTransferMaterials = new Array<SubStoreStockTransferMat>();
    }

    protected loadViewModel() {
        let that = this;

        that.baseSubStoreStockTransferFormViewModel = this._ViewModel as BaseSubStoreStockTransferFormViewModel;
        that._TTObject = this.baseSubStoreStockTransferFormViewModel._SubStoreStockTransfer;
        if (this.baseSubStoreStockTransferFormViewModel == null)
            this.baseSubStoreStockTransferFormViewModel = new BaseSubStoreStockTransferFormViewModel();
        if (this.baseSubStoreStockTransferFormViewModel._SubStoreStockTransfer == null)
            this.baseSubStoreStockTransferFormViewModel._SubStoreStockTransfer = new SubStoreStockTransfer();
        let destinationStoreObjectID = that.baseSubStoreStockTransferFormViewModel._SubStoreStockTransfer["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.baseSubStoreStockTransferFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.baseSubStoreStockTransferFormViewModel._SubStoreStockTransfer.DestinationStore = destinationStore;
            }
        }
        let storeObjectID = that.baseSubStoreStockTransferFormViewModel._SubStoreStockTransfer["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.baseSubStoreStockTransferFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.baseSubStoreStockTransferFormViewModel._SubStoreStockTransfer.Store = store;
            }
        }
        that.baseSubStoreStockTransferFormViewModel._SubStoreStockTransfer.StockActionSignDetails = that.baseSubStoreStockTransferFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.baseSubStoreStockTransferFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.baseSubStoreStockTransferFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
        that.baseSubStoreStockTransferFormViewModel._SubStoreStockTransfer.SubStoreStockTransferMaterials = that.baseSubStoreStockTransferFormViewModel.SubStoreStockTransferMaterialsGridList;
        for (let detailItem of that.baseSubStoreStockTransferFormViewModel.SubStoreStockTransferMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.baseSubStoreStockTransferFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.baseSubStoreStockTransferFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.baseSubStoreStockTransferFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.baseSubStoreStockTransferFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(BaseSubStoreStockTransferFormViewModel);

    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._SubStoreStockTransfer != null && this._SubStoreStockTransfer.ActionDate != event) {
                this._SubStoreStockTransfer.ActionDate = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._SubStoreStockTransfer != null && this._SubStoreStockTransfer.Description != event) {
                this._SubStoreStockTransfer.Description = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._SubStoreStockTransfer != null && this._SubStoreStockTransfer.DestinationStore != event) {
                this._SubStoreStockTransfer.DestinationStore = event;
            }
        }
        this.DestinationStore_SelectedObjectChanged();
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._SubStoreStockTransfer.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._SubStoreStockTransfer != null && this._SubStoreStockTransfer.MKYS_TeslimAlan != event) {
                this._SubStoreStockTransfer.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._SubStoreStockTransfer.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._SubStoreStockTransfer != null && this._SubStoreStockTransfer.MKYS_TeslimEden != event) {
                this._SubStoreStockTransfer.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._SubStoreStockTransfer != null && this._SubStoreStockTransfer.StockActionID != event) {
                this._SubStoreStockTransfer.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._SubStoreStockTransfer != null && this._SubStoreStockTransfer.Store != event) {
                this._SubStoreStockTransfer.Store = event;
            }
        }
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 6;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M10678", "Alan Depo");
        this.labelDestinationStore.Name = "labelDestinationStore";
        this.labelDestinationStore.TabIndex = 7;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ListDefName = "SubStoreList";
        this.DestinationStore.Name = "DestinationStore";
        this.DestinationStore.TabIndex = 6;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 5;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "SubStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 4;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 3;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 2;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 1;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 4;
        this.DescriptionAndSignTabControl.Visible = false;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.Width = 120;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.DescriptionTabpage = new TTVisual.TTTabPage();
        this.DescriptionTabpage.DisplayIndex = 1;
        this.DescriptionTabpage.TabIndex = 0;
        this.DescriptionTabpage.Text = i18n("M10469", "Açıklama");
        this.DescriptionTabpage.Name = "DescriptionTabpage";

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 4;

        this.MaterialTabPage = new TTVisual.TTTabPage();
        this.MaterialTabPage.DisplayIndex = 0;
        this.MaterialTabPage.BackColor = "#FFFFFF";
        this.MaterialTabPage.TabIndex = 0;
        this.MaterialTabPage.Text = "Taşınır Malın";
        this.MaterialTabPage.Name = "MaterialTabPage";

        this.SubStoreStockTransferMaterials = new TTVisual.TTGrid();
        this.SubStoreStockTransferMaterials.Name = "SubStoreStockTransferMaterials";
        this.SubStoreStockTransferMaterials.TabIndex = 8;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 100;

        this.MaterialSubStoreStockTransferMat = new TTVisual.TTListBoxColumn();
        this.MaterialSubStoreStockTransferMat.ListDefName = "MaterialListDefinition";
        this.MaterialSubStoreStockTransferMat.DataMember = "Material";
        this.MaterialSubStoreStockTransferMat.AutoCompleteDialogHeight = "60%";
        this.MaterialSubStoreStockTransferMat.AutoCompleteDialogWidth = "50%";
        this.MaterialSubStoreStockTransferMat.DisplayIndex = 1;
        this.MaterialSubStoreStockTransferMat.HeaderText = i18n("M22362", "Stok Nu., Cins ve Özellikleri");
        this.MaterialSubStoreStockTransferMat.Name = "MaterialSubStoreStockTransferMat";
        this.MaterialSubStoreStockTransferMat.Width = 300;

        this.MaterialBarcode = new TTVisual.TTTextBoxColumn();
        this.MaterialBarcode.DataMember = "Barcode";
        this.MaterialBarcode.DisplayIndex = 2;
        this.MaterialBarcode.HeaderText = "Barkod";
        this.MaterialBarcode.Name = "MaterialBarcode";
        this.MaterialBarcode.ReadOnly = true;
        this.MaterialBarcode.Width = 100;

        this.Distrubitontype = new TTVisual.TTTextBoxColumn();
        this.Distrubitontype.DataMember = "DistributionType";
        this.Distrubitontype.DisplayIndex = 3;
        this.Distrubitontype.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.Distrubitontype.Name = "Distrubitontype";
        this.Distrubitontype.ReadOnly = true;
        this.Distrubitontype.Width = 100;

        this.RequestAmountSubStoreStockTransferMat = new TTVisual.TTTextBoxColumn();
        this.RequestAmountSubStoreStockTransferMat.DataMember = "RequestAmount";
        this.RequestAmountSubStoreStockTransferMat.Required = true;
        this.RequestAmountSubStoreStockTransferMat.DisplayIndex = 4;
        this.RequestAmountSubStoreStockTransferMat.HeaderText = i18n("M16713", "İstenen Miktar");
        this.RequestAmountSubStoreStockTransferMat.Name = "RequestAmountSubStoreStockTransferMat";
        this.RequestAmountSubStoreStockTransferMat.Width = 80;

        this.AmountSubStoreStockTransferMat = new TTVisual.TTTextBoxColumn();
        this.AmountSubStoreStockTransferMat.DataMember = "StoreStock";
        this.AmountSubStoreStockTransferMat.DisplayIndex = 5;
        this.AmountSubStoreStockTransferMat.HeaderText = i18n("M19030", "Miktar");
        this.AmountSubStoreStockTransferMat.Name = "AmountSubStoreStockTransferMat";
        this.AmountSubStoreStockTransferMat.Width = 80;

        this.StockLevelType = new TTVisual.TTListBoxColumn();
        this.StockLevelType.ListDefName = "StockLevelTypeList";
        this.StockLevelType.DataMember = "StockLevelType";
        this.StockLevelType.DisplayIndex = 6;
        this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelType.Name = "StockLevelType";
        this.StockLevelType.Width = 100;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 136;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 138;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 7;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 139;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 137;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.SubStoreStockTransferMaterialsColumns = [this.Detail, this.MaterialSubStoreStockTransferMat, this.MaterialBarcode, this.Distrubitontype, this.RequestAmountSubStoreStockTransferMat, this.AmountSubStoreStockTransferMat, this.StockLevelType];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage, this.DescriptionTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.tttabcontrol1.Controls = [this.MaterialTabPage];
        this.MaterialTabPage.Controls = [this.SubStoreStockTransferMaterials];
        this.Controls = [this.Description, this.StockActionID, this.labelDestinationStore, this.DestinationStore, this.labelStore, this.Store, this.labelActionDate, this.ActionDate, this.labelStockActionID, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.DescriptionTabpage, this.tttabcontrol1, this.MaterialTabPage, this.SubStoreStockTransferMaterials, this.Detail, this.MaterialSubStoreStockTransferMat, this.MaterialBarcode, this.Distrubitontype, this.RequestAmountSubStoreStockTransferMat, this.AmountSubStoreStockTransferMat, this.StockLevelType, this.MKYS_TeslimAlan, this.MKYS_TeslimEden, this.ttlabel1, this.labelMKYS_TeslimEden, this.labelMKYS_TeslimAlan, this.TTTeslimAlanButon, this.TTTeslimEdenButon];

    }


}
