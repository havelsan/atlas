//$847DC903
import { Component, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { SubStoreStockTransferNewFormViewModel } from './SubStoreStockTransferNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Material, StockLevelType, StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseSubStoreStockTransferForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/XXXXXXici_Dagitim_Belgesi_Modulu/BaseSubStoreStockTransferForm";
import { MainStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { SubStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SubStoreStockTransfer } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { SelectStoreUsageEnum } from 'NebulaClient/Model/AtlasClientModel';
import { SubStoreStockTransferMat } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelService } from "ObjectClassService/StockLevelService";
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { TTUser } from 'app/NebulaClient/StorageManager/Security/TTUser';
import { StockLevelTypeService } from 'app/NebulaClient/Services/ObjectService/StockLevelTypeService';
@Component({
    selector: 'SubStoreStockTransferNewForm',
    templateUrl: './SubStoreStockTransferNewForm.html',
    providers: [MessageService]
})
export class SubStoreStockTransferNewForm extends BaseSubStoreStockTransferForm implements OnInit {
    public StockActionSignDetailsColumns = [];
    public SubStoreStockTransferMaterialsColumns = [];
    public subStoreStockTransferNewFormViewModel: SubStoreStockTransferNewFormViewModel = new SubStoreStockTransferNewFormViewModel();
    public get _SubStoreStockTransfer(): SubStoreStockTransfer {
        return this._TTObject as SubStoreStockTransfer;
    }
    public storeListFiltred: string ="";
    public visible: boolean = false;
    public selectedStockLevelType: StockLevelType;
    private SubStoreStockTransferNewForm_DocumentUrl: string = '/api/SubStoreStockTransferService/SubStoreStockTransferNewForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private changeDetectorRef: ChangeDetectorRef,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.SubStoreStockTransferNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
       
    }


    // ***** Method declarations start *****
    inputStore: Store;
    public setInputParam(value: Store) {
        if (value != null) {
            if (value.ObjectDefID.toString() === SubStoreDefinition.ObjectDefID.id)
                this.inputStore = value;
        }
    }

    protected async ClientSidePostScript(): Promise<void> {
        for (let detailItem of this._SubStoreStockTransfer.SubStoreStockTransferMaterials) {
            detailItem.Amount = detailItem.RequestAmount;
        }
    }

    protected async PreScript() {
        super.PreScript();

        if (this._SubStoreStockTransfer.DestinationStore == null) {
            this._SubStoreStockTransfer.DestinationStore = this.inputStore;
            await this.SelectStoreUsage(SelectStoreUsageEnum.Nothing, SelectStoreUsageEnum.UseUserResources);
        }

        this.Store.ListFilterExpression = "OBJECTID <> '" + this._SubStoreStockTransfer.DestinationStore.ObjectID.toString() + "'";

        if (this._SubStoreStockTransfer.DestinationStore instanceof SubStoreDefinition) {
            this._SubStoreStockTransfer.MKYS_TeslimAlan = (<SubStoreDefinition>this._SubStoreStockTransfer.DestinationStore).StoreResponsible.Name;
            this._SubStoreStockTransfer.MKYS_TeslimAlanObjID = (<SubStoreDefinition>this._SubStoreStockTransfer.DestinationStore).StoreResponsible.ObjectID;
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SubStoreStockTransfer();
        this.subStoreStockTransferNewFormViewModel = new SubStoreStockTransferNewFormViewModel();
        this._ViewModel = this.subStoreStockTransferNewFormViewModel;
        this.subStoreStockTransferNewFormViewModel._SubStoreStockTransfer = this._TTObject as SubStoreStockTransfer;
        this.subStoreStockTransferNewFormViewModel._SubStoreStockTransfer.DestinationStore = new Store();
        this.subStoreStockTransferNewFormViewModel._SubStoreStockTransfer.Store = new Store();
        this.subStoreStockTransferNewFormViewModel._SubStoreStockTransfer.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.subStoreStockTransferNewFormViewModel._SubStoreStockTransfer.SubStoreStockTransferMaterials = new Array<SubStoreStockTransferMat>();
    }

    protected loadViewModel() {
        let that = this;

        that.subStoreStockTransferNewFormViewModel = this._ViewModel as SubStoreStockTransferNewFormViewModel;
        that._TTObject = this.subStoreStockTransferNewFormViewModel._SubStoreStockTransfer;
        if (this.subStoreStockTransferNewFormViewModel == null)
            this.subStoreStockTransferNewFormViewModel = new SubStoreStockTransferNewFormViewModel();
        if (this.subStoreStockTransferNewFormViewModel._SubStoreStockTransfer == null)
            this.subStoreStockTransferNewFormViewModel._SubStoreStockTransfer = new SubStoreStockTransfer();
        let destinationStoreObjectID = that.subStoreStockTransferNewFormViewModel._SubStoreStockTransfer["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.subStoreStockTransferNewFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.subStoreStockTransferNewFormViewModel._SubStoreStockTransfer.DestinationStore = destinationStore;
            }
        }
        let storeObjectID = that.subStoreStockTransferNewFormViewModel._SubStoreStockTransfer["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.subStoreStockTransferNewFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.subStoreStockTransferNewFormViewModel._SubStoreStockTransfer.Store = store;
            }
        }
        that.subStoreStockTransferNewFormViewModel._SubStoreStockTransfer.StockActionSignDetails = that.subStoreStockTransferNewFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.subStoreStockTransferNewFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.subStoreStockTransferNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
        that.subStoreStockTransferNewFormViewModel._SubStoreStockTransfer.SubStoreStockTransferMaterials = that.subStoreStockTransferNewFormViewModel.SubStoreStockTransferMaterialsGridList;
        for (let detailItem of that.subStoreStockTransferNewFormViewModel.SubStoreStockTransferMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.subStoreStockTransferNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.subStoreStockTransferNewFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.subStoreStockTransferNewFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.subStoreStockTransferNewFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(SubStoreStockTransferNewFormViewModel);
        if (this._SubStoreStockTransfer.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._SubStoreStockTransfer.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M21674", "Servisler Arası Transfer Belgesi ( Yeni )");
        this.changeDetectorRef.detectChanges();

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
        // this.DestinationStore_SelectedObjectChanged();
    }

    public showMaterialMultiSelectForm: boolean = false;
    OpenMaterialMultiSelectComponent() {
        if(this.subStoreStockTransferNewFormViewModel._SubStoreStockTransfer.Store!=null)
        {
            this.showMaterialMultiSelectForm = true;
            this.storeListFiltred = this.subStoreStockTransferNewFormViewModel._SubStoreStockTransfer.Store.ObjectID.toString();
        }
        
        else
        ServiceLocator.MessageService.showError("İstek Yapılan Servis Depoyu Seçiniz!!");
    }
    async MaterialsCleared(){
        
    }
    
    async MaterialsSelected(event) {
        if (this.stockLeveltypeArray.length == 0)
        {
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
        }
        
        this.showMaterialMultiSelectForm = false;
        let selectedMaterials = event;
        this._SubStoreStockTransfer.SubStoreStockTransferMaterials = new Array<SubStoreStockTransferMat>();
        for (var i = 0; i < selectedMaterials.length; i++) {
            let selectedItem = selectedMaterials[i];
            let newRow: SubStoreStockTransferMat = new SubStoreStockTransferMat();
            newRow.Material = selectedItem;
            newRow.Material.DistributionTypeName = selectedItem.Distributiontypename
            newRow.StockLevelType = this.selectedStockLevelType;
            newRow.Status = StockActionDetailStatusEnum.New;
            if (selectedItem.Inheld != null) {
                newRow.StoreStock = Number.parseInt(selectedItem.Inheld);
            }
            if (newRow.Material.ObjectID != null) {
                let stockInheldSubStore: number = await StockLevelService.StockInheldWithStockLevel(newRow.Material.ObjectID, this._SubStoreStockTransfer.DestinationStore.ObjectID, newRow.StockLevelType.ObjectID);
                newRow.DestinationStoreStock = stockInheldSubStore;
            }

            
            this._SubStoreStockTransfer.SubStoreStockTransferMaterials.push(newRow);
            this._ViewModel.SubStoreStockTransferMaterialsGridList.push(newRow);
        }

        let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this._SubStoreStockTransfer.SubStoreStockTransferMaterials.forEach(element => {
            element.StockLevelType = stockLeveltypeArray[0];
        });
        
        
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

            if (this._SubStoreStockTransfer.CurrentStateDefID.toString() === SubStoreStockTransfer.SubStoreStockTransferStates.New.id)
                this.MaterialSubStoreStockTransferMat.ListFilterExpression = "STOCKS.STORE= '" + this._SubStoreStockTransfer.Store.ObjectID + "' AND STOCKS.INHELD > 0";
            if (this._SubStoreStockTransfer.Store instanceof SubStoreDefinition) {
                this._SubStoreStockTransfer.MKYS_TeslimEden = (<SubStoreDefinition>this._SubStoreStockTransfer.Store).StoreResponsible.Name;
                this._SubStoreStockTransfer.MKYS_TeslimEdenObjID = (<SubStoreDefinition>this._SubStoreStockTransfer.Store).StoreResponsible.ObjectID;
            }
        }
    }


    SubStoreStockTransferMaterials_CellValueChangedEmitted(data: any) {
        if (data && this.SubStoreStockTransferMaterials_CellValueChanged && data.Row && data.Column) {
            this.SubStoreStockTransferMaterials_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    onSelectionChange(data: any) {
    }
    public async SubStoreStockTransferMaterials_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.StockActionOutDetails_CellValueChanged(data, rowIndex, columnIndex);
    }

    onRowInserting(data: SubStoreStockTransferMat) {
    }

    onCellContentClicked(data: any) {
    }
    async initNewRow(data: any) {
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
        this.DestinationStore.ReadOnly = true;
        this.DestinationStore.ListDefName = "SubStoreList";
        this.DestinationStore.Name = "DestinationStore";
        this.DestinationStore.TabIndex = 6;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 5;

        this.Store = new TTVisual.TTObjectListBox();
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
        this.SubStoreStockTransferMaterials.Height = 350;

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
        this.MaterialSubStoreStockTransferMat.AutoCompleteDialogHeight = '60%';
        this.MaterialSubStoreStockTransferMat.AutoCompleteDialogWidth = '90%';
        this.MaterialSubStoreStockTransferMat.DisplayIndex = 1;
        this.MaterialSubStoreStockTransferMat.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialSubStoreStockTransferMat.Name = "MaterialSubStoreStockTransferMat";
        this.MaterialSubStoreStockTransferMat.Width = 400;

        this.MaterialBarcode = new TTVisual.TTTextBoxColumn();
        this.MaterialBarcode.DataMember = "Material.Barcode";
        this.MaterialBarcode.DisplayIndex = 2;
        this.MaterialBarcode.HeaderText = "Barkod";
        this.MaterialBarcode.Name = "MaterialBarcode";
        this.MaterialBarcode.ReadOnly = true;
        this.MaterialBarcode.Width = 120;

        this.Distrubitontype = new TTVisual.TTTextBoxColumn();
        this.Distrubitontype.DataMember = "Material.DistributionTypeName";
        this.Distrubitontype.DisplayIndex = 3;
        this.Distrubitontype.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.Distrubitontype.Name = "Distrubitontype";
        this.Distrubitontype.ReadOnly = true;
        this.Distrubitontype.Width = 140;

        this.RequestAmountSubStoreStockTransferMat = new TTVisual.TTTextBoxColumn();
        this.RequestAmountSubStoreStockTransferMat.DataMember = "RequestAmount";
        this.RequestAmountSubStoreStockTransferMat.Required = true;
        this.RequestAmountSubStoreStockTransferMat.DisplayIndex = 4;
        this.RequestAmountSubStoreStockTransferMat.HeaderText = i18n("M16713", "İstenen Miktar");
        this.RequestAmountSubStoreStockTransferMat.Name = "RequestAmountSubStoreStockTransferMat";
        this.RequestAmountSubStoreStockTransferMat.Width = 120;
        this.RequestAmountSubStoreStockTransferMat.IsNumeric = true;

        this.AmountSubStoreStockTransferMat = new TTVisual.TTTextBoxColumn();
        this.AmountSubStoreStockTransferMat.DataMember = "StoreStock";
        this.AmountSubStoreStockTransferMat.DisplayIndex = 5;
        this.AmountSubStoreStockTransferMat.HeaderText = i18n("M12625", "Depo Mevcudu");
        this.AmountSubStoreStockTransferMat.Name = "AmountSubStoreStockTransferMat";
        this.AmountSubStoreStockTransferMat.Width = 120;
        this.AmountSubStoreStockTransferMat.IsNumeric = true;
        this.AmountSubStoreStockTransferMat.ReadOnly = true;



        this.SubStoreInheld = new TTVisual.TTTextBoxColumn();
        this.SubStoreInheld.DataMember = 'DestinationStoreStock';
        this.SubStoreInheld.Format = 'N4';
        this.SubStoreInheld.DisplayIndex = 6;
        this.SubStoreInheld.HeaderText = i18n("M12625", "Cep Depo Mevcudu");
        this.SubStoreInheld.Name = 'StoreInheld';
        this.SubStoreInheld.ReadOnly = true;
        this.SubStoreInheld.Visible = true;
        this.SubStoreInheld.Width = 120;



        this.StockLevelType = new TTVisual.TTListBoxColumn();
        this.StockLevelType.ListDefName = "StockLevelTypeList";
        this.StockLevelType.DataMember = "StockLevelType";
        this.StockLevelType.DisplayIndex = 6;
        this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelType.Name = "StockLevelType";
        this.StockLevelType.Width = 120;

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
        this.SubStoreStockTransferMaterialsColumns = [this.Detail, this.MaterialSubStoreStockTransferMat, this.MaterialBarcode, this.Distrubitontype, this.RequestAmountSubStoreStockTransferMat, this.AmountSubStoreStockTransferMat,this.SubStoreInheld, this.StockLevelType];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage, this.DescriptionTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.tttabcontrol1.Controls = [this.MaterialTabPage];
        this.MaterialTabPage.Controls = [this.SubStoreStockTransferMaterials];
        this.Controls = [this.Description, this.StockActionID, this.labelDestinationStore, this.DestinationStore, this.labelStore, this.Store, this.labelActionDate, this.ActionDate, this.labelStockActionID, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.DescriptionTabpage, this.tttabcontrol1, this.MaterialTabPage, this.SubStoreStockTransferMaterials, this.Detail, this.MaterialSubStoreStockTransferMat, this.MaterialBarcode, this.Distrubitontype, this.RequestAmountSubStoreStockTransferMat, this.AmountSubStoreStockTransferMat, this.StockLevelType, this.MKYS_TeslimAlan, this.MKYS_TeslimEden, this.ttlabel1, this.labelMKYS_TeslimEden, this.labelMKYS_TeslimAlan, this.TTTeslimAlanButon, this.TTTeslimEdenButon];

    }


}
