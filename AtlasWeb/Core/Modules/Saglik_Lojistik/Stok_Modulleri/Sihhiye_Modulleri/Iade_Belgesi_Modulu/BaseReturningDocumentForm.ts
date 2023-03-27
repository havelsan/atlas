//$86E15891
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { BaseReturningDocumentFormViewModel } from './BaseReturningDocumentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { ProductTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResUserService } from "ObjectClassService/ResUserService";
import { ReturningDocument } from 'NebulaClient/Model/AtlasClientModel';
import { ReturningDocumentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionBaseForm } from "Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StockActionBaseForm";
import { StockActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';

import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { StockLevelService } from "ObjectClassService/StockLevelService";
import { StockLevelTypeService } from "ObjectClassService/StockLevelTypeService";
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';

import { DxDataGridComponent } from "devextreme-angular";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";



import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';

@Component({
    selector: 'BaseReturningDocumentForm',
    templateUrl: './BaseReturningDocumentForm.html',
    providers: [MessageService]
})
export class BaseReturningDocumentForm extends StockActionBaseForm implements OnInit {
    Amount: TTVisual.ITTTextBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    ChooseProductsFromTheTree: TTVisual.ITTButton;
    cmdHEKReport: TTVisual.ITTButton;
    Description: TTVisual.ITTTextBox;
    DescriptionAndSignTabControl: TTVisual.ITTTabControl;
    DescriptionTabpage: TTVisual.ITTTabPage;
    DestinationStore: TTVisual.ITTObjectListBox;
    Detail: TTVisual.ITTButtonColumn;
    DistributionType: TTVisual.ITTTextBoxColumn;
    Existing: TTVisual.ITTTextBoxColumn;
    IsDeputy: TTVisual.ITTCheckBoxColumn;
    labelDestinationStore: TTVisual.ITTLabel;
    labelMKYS_EMalzemeGrup: TTVisual.ITTLabel;
    labelMKYS_TeslimAlan: TTVisual.ITTLabel;
    labelMKYS_TeslimEden: TTVisual.ITTLabel;
    labelStockActionID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelTransactionDate: TTVisual.ITTLabel;
    public Material: TTVisual.ITTListBoxColumn;
    MaterialTabPage: TTVisual.ITTTabPage;
    MKYS_EMalzemeGrup: TTVisual.ITTEnumComboBox;
    MKYS_TeslimAlan: TTButtonTextBox;
    MKYS_TeslimEden: TTButtonTextBox;
    RequireAmount: TTVisual.ITTTextBoxColumn;
    SignTabpage: TTVisual.ITTTabPage;
    SignUser: TTVisual.ITTListBoxColumn;
    SignUserType: TTVisual.ITTEnumComboBoxColumn;
    StockActionID: TTVisual.ITTTextBox;
    StockActionOutDetails: TTVisual.ITTGrid;
    StockActionSignDetails: TTVisual.ITTGrid;
    StockLevelType: TTVisual.ITTListDefComboBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    TransactionDate: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    TTTeslimAlanButon: TTVisual.ITTButton;
    TTTeslimEdenButon: TTVisual.ITTButton;
    // public StockActionOutDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public baseReturningDocumentFormViewModel: BaseReturningDocumentFormViewModel = new BaseReturningDocumentFormViewModel();
    public get _ReturningDocument(): ReturningDocument {
        return this._TTObject as ReturningDocument;
    }
    private BaseReturningDocumentForm_DocumentUrl: string = '/api/ReturningDocumentService/BaseReturningDocumentForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseReturningDocumentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    //#region dx-data-grid çevirme
    public selectedMaterial: Material;
    public selectedStockLevelType: StockLevelType;
    public stockLeveltypeArray: Array<StockLevelType> = new Array<StockLevelType>();

    public async onMaterialSelectionChange(event: any) {
        if (event != null) {
            if (this.stockLeveltypeArray.length == 0)
                this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
            if (this.selectedMaterial == null || this.selectedMaterial.ObjectID == null)
                ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
            else {
                if (!this._ReturningDocument.ReturningDocumentMaterials.find(x => x.Material.ObjectID == this.selectedMaterial.ObjectID)) {
                    let newRow: ReturningDocumentMaterial = new ReturningDocumentMaterial();
                    newRow.Material = this.selectedMaterial;
                    newRow.StockLevelType = this.selectedStockLevelType;
                    newRow.Status = StockActionDetailStatusEnum.New;
                    newRow.IsNew = true; // delete ederken yeni eklendi ise viewmodelden tamamen silsin yoksa sadece EntityStateini değiştirsin diye
                    let stockInheld: number = await StockLevelService.StockInheldWithStockLevelByBudgetType(newRow.Material.ObjectID, this._ReturningDocument.Store.ObjectID, newRow.StockLevelType.ObjectID, this._ReturningDocument.DestinationStore.ObjectID);
                    newRow.StoreStock = stockInheld;
                    this._ReturningDocument.ReturningDocumentMaterials.push(newRow);
                    this.selectedMaterial == null;
                    let that = this;
                    window.setTimeout(t => {
                        if (this.selectedMaterial === null)
                            this.selectedMaterial = undefined;
                        else
                            this.selectedMaterial = null;
                        //that.detector.tick();
                    }, 0);
                } else
                    ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
            }
        }
    }

    /*  public async btnAddClick() {
          if (this.selectedMaterial == null || this.selectedMaterial.ObjectID == null)
              ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
          else {
              if (!this._ReturningDocument.ReturningDocumentMaterials.find(x => x.Material.ObjectID == this.selectedMaterial.ObjectID)) {
                  let newRow: ReturningDocumentMaterial = new ReturningDocumentMaterial();
                  newRow.Material = this.selectedMaterial;
                  newRow.StockLevelType = this.selectedStockLevelType;
                  newRow.Status = StockActionDetailStatusEnum.New;
                  newRow.IsNew = true; // delete ederken yeni eklendi ise viewmodelden tamamen silsin yoksa sadece EntityStateini değiştirsin diye
                  let stockInheld: number = await StockLevelService.StockInheldWithStockLevelByBudgetType(newRow.Material.ObjectID, this._ReturningDocument.Store.ObjectID, newRow.StockLevelType.ObjectID, this._ReturningDocument.DestinationStore.ObjectID);
                  newRow.StoreStock = stockInheld;
                  this._ReturningDocument.ReturningDocumentMaterials.push(newRow);
                  this.selectedMaterial == null
                  let that = this;
                  window.setTimeout(t => {
                      if (this.selectedMaterial === null)
                          this.selectedMaterial = undefined;
                      else
                          this.selectedMaterial = null;
                      //that.detector.tick();
                  }, 0);
              } else
                  ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
          }
  
      }*/

    @ViewChild('gridStockActionOutDetail') gridStockActionOutDetail: DxDataGridComponent;
    async gridStockActionOutDetail_CellContentClicked(data: any) {
        let that = this;
        if (this.ReadOnly != true) {
            if (data.column.name = "RowDelete") {
                if (data.row != null) {
                    if (data.row.key != null) {
                        if (data.row.key.IsNew) {
                            this.gridStockActionOutDetail.instance.deleteRow(data.rowIndex);
                        }
                        else {
                            data.key.EntityState = EntityStateEnum.Deleted;
                            this.gridStockActionOutDetail.instance.filter(['EntityState', '<>', 1]);
                            this.gridStockActionOutDetail.instance.refresh();

                        }
                    }
                }

            }

        }
    }

    public async stateChange(event: FormSaveInfo) {
        this.gridStockActionOutDetail.instance.closeEditCell();
        this.gridStockActionOutDetail.instance.saveEditData();
        await super.setState(event.transDef, event);
    }

    public async onSaveButtonClick(event: FormSaveInfo) {
        this.gridStockActionOutDetail.instance.closeEditCell();
        this.gridStockActionOutDetail.instance.saveEditData();
        await super.saveForm(event);
    }

    //public onStockActionOutDetailsRowRemoved(data: any) {
    //    data.key.EntityState = EntityStateEnum.Deleted;
    //}

    public onStockActionOutDetailsGridRowUpdating(event: any) {
        let returningDocumentMaterial = <ReturningDocumentMaterial>event.key;
        // Zaten sadece "RequireAmount" alanı update edilebiliyor
        if (returningDocumentMaterial.RequireAmount == null) {
            ServiceLocator.MessageService.showError('İade Miktarı boş olmaz!');
        } else if (returningDocumentMaterial.RequireAmount <= 0) {
            ServiceLocator.MessageService.showError('İade Miktarı 0 dan küçük olmaz!');
        }
        else {
            returningDocumentMaterial.Amount = returningDocumentMaterial.RequireAmount;
            if (returningDocumentMaterial.RequireAmount > returningDocumentMaterial.StoreStock) {
                returningDocumentMaterial.RequireAmount = returningDocumentMaterial.StoreStock;
            }

        }
    }



    // Detail Butonunun içi boştu kaldırıldı, Amount Alanının Visibleı false olduğu için kaldırıldı
    public StockActionOutDetailsColumns = [
        {
            name: 'GetDetail',
            width: 'auto',
            cellTemplate: 'detailCellTemplate',
        },
        {
            caption: i18n("M18550", "Malzeme Adı"),
            dataField: 'Material.Name',
            allowEditing: false,
            //width: 'auto'
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false,
            //width: 'auto'
        },
        {
            caption: i18n("M12449", "Dağıtım Şekli"),
            dataField: 'Material.DistributionTypeName',
            allowEditing: false,
            //width: 'auto'
        },
        {
            caption: i18n("M22360", "Stok Miktarı"),
            dataField: 'StoreStock',
            dataType: 'number',
            allowEditing: false,
            //width: 'auto'
        },
        {
            caption: i18n("M16068", "İade Miktarı "),
            dataField: 'RequireAmount',
            dataType: 'number',
            format: '#',
            editorOptions: {
                onKeyPress: function (e) {
                    let event = e.event,
                        str = String.fromCharCode(event.keyCode);
                    if (!/[0-9]/.test(str))
                        event.preventDefault();
                }
            },
            allowEditing: this.ReadOnly != true,
            //width: 'auto'
        },
        {
            caption: i18n("M18519", "Malın Durumu"),
            dataField: 'StockLevelType.Description',
            allowEditing: false,
            //width: 'auto'
        },
        {
            caption: i18n("M27286", "Sil"),
            name: "RowDelete",
            width: 50,
            visible: this.ReadOnly != true,
            cellTemplate: "deleteCellTemplate",
        },



        //{
        //    caption: 'Miktar',
        //    dataField: 'Amount',
        //    dataType: 'number',
        //    format: '#',
        //    editorOptions: {
        //        onKeyPress: function (e) {
        //            var event = e.event,
        //                str = String.fromCharCode(event.keyCode);
        //            if (!/[0-9]/.test(str))
        //                event.preventDefault();
        //        }
        //    },
        //    width: 'auto'
        //},


    ];

    //#endregion

    //<this.StockActionOutDetail gridde kullanılıyordu dx-gride çevrilince kullanılmıyore çevrildi

    StockActionOutDetails_CellValueChangedEmitted(data: any) {
        if (data && this.StockActionOutDetails_CellValueChanged && data.Row && data.Column) {
            this.StockActionOutDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    public async StockActionOutDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        let returningDocumentMaterial: ReturningDocumentMaterial = data.Row.TTObject as ReturningDocumentMaterial;
        if (returningDocumentMaterial.Status === undefined) {
            returningDocumentMaterial.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            returningDocumentMaterial.StockLevelType = stockLeveltypeArray[0];
        }
        if (data.Column.Name === "RequireAmount") {
            if (returningDocumentMaterial.RequireAmount !== null) {
                /*let returningDocumentMaterialRow: TTVisual.ITTGridRow = this.StockActionOutDetails.Rows[this.StockActionOutDetails.CurrentCell.RowIndex];
                let returningDocumentMaterial: ReturningDocumentMaterial = (<ReturningDocumentMaterial>returningDocumentMaterialRow.TTObject);*/
                returningDocumentMaterial.Amount = returningDocumentMaterial.RequireAmount;
                if (returningDocumentMaterial.RequireAmount > returningDocumentMaterial.StoreStock) {
                    returningDocumentMaterial.RequireAmount = returningDocumentMaterial.StoreStock;
                }
            }
        }
        if (data.Column.Name === "Material" || data.Column.Name === "StockLevelType") {

            if (returningDocumentMaterial.Material != null && returningDocumentMaterial.StockLevelType != null) {
                if (returningDocumentMaterial.Material.ObjectID != null) {
                    let stockInheld: number = await StockLevelService.StockInheldWithStockLevelByBudgetType(returningDocumentMaterial.Material.ObjectID, this._ReturningDocument.Store.ObjectID, returningDocumentMaterial.StockLevelType.ObjectID, this._ReturningDocument.DestinationStore.ObjectID);
                    returningDocumentMaterial.StoreStock = stockInheld;
                }
            }
        }
    }
    //this.StockActionOutDetail gridde kullanılıyordu >

    // ***** Method declarations start *****

    public async ChooseProductsFromTheTree_Click(): Promise<void> {
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        let productTreeDefinitions: Array<any> = this._ReturningDocument.ObjectContext.QueryObjects(typeof ProductTreeDefinition, "");
        for (let productTreeDefinition of productTreeDefinitions) { multiSelectForm.AddMSItem(productTreeDefinition.Material.Name, productTreeDefinition.ObjectID.toString(), productTreeDefinition); }
        multiSelectForm.GetMSItem(this, i18n("M23980", "Ürünü Seçiniz..."));
        if (multiSelectForm.MSSelectedItemObject !== null) {
            let productTreeDefinition: ProductTreeDefinition = multiSelectForm.MSSelectedItemObject as ProductTreeDefinition;
            if (productTreeDefinition !== null) {
                for (let productTreeDetail of productTreeDefinition.ProductTreeDetails) {
                    let returningDocumentMaterial: ReturningDocumentMaterial = this._ReturningDocument.ReturningDocumentMaterials.AddNew();
                    returningDocumentMaterial.Material = productTreeDetail.ConsumableMaterial;
                    //returningDocumentMaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                }
                this.ChooseProductsFromTheTree.Enabled = false;
            }
        }
    }
    public async cmdHEKReport_Click(): Promise<void> {
        /*if (this._ReturningDocument.RepairObjectID !== null) {
            let parameters: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
            let objectID: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
            objectID.push("VALUE", this._ReturningDocument.RepairObjectID.toString());
            parameters.push("TTOBJECTID", objectID);
            TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_KayitSilmeyeEsasTeknikRapor, true, 1, parameters);
        }
        if (this._ReturningDocument.MaterialRepairObjectID !== null) {
            let parameters: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
            let objectID: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
            objectID.push("VALUE", this._ReturningDocument.MaterialRepairObjectID.toString());
            parameters.push("TTOBJECTID", objectID);
            TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_KayitSilmeyeEsasTeknikRapor, true, 1, parameters);
        }*/
    }
    public async StockActionOutDetails_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        if (this.StockActionOutDetails.CurrentCell.OwningColumn.Name === "Detail")
            this.ShowStockActionDetailForm(<StockActionDetail>this.StockActionOutDetails.CurrentCell.OwningRow.TTObject);
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
            this._ReturningDocument.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;
        }
    }
    public async TTTeslimEdenButon_Click(): Promise<void> {

        let resUser: Array<ResUser> = (await ResUserService.GetAllUser("WHERE ISACTIVE = 1 "));
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
            this._ReturningDocument.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
        }
    }
    protected async PreScript() {
        if (this._ReturningDocument.MaterialRepairObjectID === null && this._ReturningDocument.RepairObjectID === null)
            this.cmdHEKReport.ReadOnly = true;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ReturningDocument();
        this.baseReturningDocumentFormViewModel = new BaseReturningDocumentFormViewModel();
        this._ViewModel = this.baseReturningDocumentFormViewModel;
        this.baseReturningDocumentFormViewModel._ReturningDocument = this._TTObject as ReturningDocument;
        this.baseReturningDocumentFormViewModel._ReturningDocument.Store = new Store();
        this.baseReturningDocumentFormViewModel._ReturningDocument.DestinationStore = new Store();
        this.baseReturningDocumentFormViewModel._ReturningDocument.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.baseReturningDocumentFormViewModel._ReturningDocument.ReturningDocumentMaterials = new Array<ReturningDocumentMaterial>();
    }

    protected loadViewModel() {
        let that = this;

        that.baseReturningDocumentFormViewModel = this._ViewModel as BaseReturningDocumentFormViewModel;
        that._TTObject = this.baseReturningDocumentFormViewModel._ReturningDocument;
        if (this.baseReturningDocumentFormViewModel == null)
            this.baseReturningDocumentFormViewModel = new BaseReturningDocumentFormViewModel();
        if (this.baseReturningDocumentFormViewModel._ReturningDocument == null)
            this.baseReturningDocumentFormViewModel._ReturningDocument = new ReturningDocument();
        let storeObjectID = that.baseReturningDocumentFormViewModel._ReturningDocument["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.baseReturningDocumentFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.baseReturningDocumentFormViewModel._ReturningDocument.Store = store;
            }
        }
        let destinationStoreObjectID = that.baseReturningDocumentFormViewModel._ReturningDocument["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.baseReturningDocumentFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.baseReturningDocumentFormViewModel._ReturningDocument.DestinationStore = destinationStore;
            }
        }
        that.baseReturningDocumentFormViewModel._ReturningDocument.StockActionSignDetails = that.baseReturningDocumentFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.baseReturningDocumentFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.baseReturningDocumentFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
        that.baseReturningDocumentFormViewModel._ReturningDocument.ReturningDocumentMaterials = that.baseReturningDocumentFormViewModel.StockActionOutDetailsGridList;
        for (let detailItem of that.baseReturningDocumentFormViewModel.StockActionOutDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.baseReturningDocumentFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.baseReturningDocumentFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.baseReturningDocumentFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.baseReturningDocumentFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(BaseReturningDocumentFormViewModel);

    }


    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.Description != event) {
                this._ReturningDocument.Description = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.DestinationStore != event) {
                this._ReturningDocument.DestinationStore = event;
            }
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.MKYS_EMalzemeGrup != event) {
                this._ReturningDocument.MKYS_EMalzemeGrup = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._ReturningDocument != null && this._ReturningDocument.MKYS_TeslimAlan != event) {
                this._ReturningDocument.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._ReturningDocument != null && this._ReturningDocument.MKYS_TeslimEden != event) {
                this._ReturningDocument.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.StockActionID != event) {
                this._ReturningDocument.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.Store != event) {
                this._ReturningDocument.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.TransactionDate != event) {
                this._ReturningDocument.TransactionDate = event;
            }
        }
    }



    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.MKYS_EMalzemeGrup, "Value", this.__ttObject, "MKYS_EMalzemeGrup");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 37;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 36;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 34;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 6;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 35;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 33;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "SubStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 32;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M10678", "Alan Depo");
        this.labelDestinationStore.Name = "labelDestinationStore";
        this.labelDestinationStore.TabIndex = 31;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ReadOnly = true;
        this.DestinationStore.ListDefName = "MainStoreList";
        this.DestinationStore.Name = "DestinationStore";
        this.DestinationStore.TabIndex = 30;

        this.cmdHEKReport = new TTVisual.TTButton();
        this.cmdHEKReport.Text = i18n("M15614", "HEK Raporu Bas");
        this.cmdHEKReport.Name = "cmdHEKReport";
        this.cmdHEKReport.TabIndex = 29;
        this.cmdHEKReport.Visible = false;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.BackColor = "#DCDCDC";
        this.labelTransactionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelTransactionDate.ForeColor = "#000000";
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 7;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.CustomFormat = "";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.BackColor = "#DCDCDC";
        this.labelStockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelStockActionID.ForeColor = "#000000";
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 3;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
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

        //<this.StockActionOutDetailsColumns dxgrid e taşındı
        this.StockActionOutDetails = new TTVisual.TTGrid();
        this.StockActionOutDetails.Required = true;
        this.StockActionOutDetails.BackColor = "#FFE3C6";
        this.StockActionOutDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionOutDetails.Name = "StockActionOutDetails";
        this.StockActionOutDetails.TabIndex = 0;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.AllowMultiSelect = true;
        this.Material.ListDefName = "MaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.AutoCompleteDialogHeight = "60%";
        this.Material.AutoCompleteDialogWidth = "90%";
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M18550", "Malzeme Adı");
        this.Material.Name = "Material";
        this.Material.Width = 500;
        this.Material.ReadOnly = this.ReadOnly;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Material.Barcode";
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "Material.DistributionTypeName";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M12449", "Dağıtım Şekli");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.Existing = new TTVisual.TTTextBoxColumn();
        this.Existing.DataMember = "StoreStock";
        this.Existing.Format = "N2";
        this.Existing.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Existing.DisplayIndex = 4;
        this.Existing.HeaderText = i18n("M22360", "Stok Miktarı");
        this.Existing.Name = "Existing";
        this.Existing.ReadOnly = true;
        this.Existing.Width = 100;

        this.RequireAmount = new TTVisual.TTTextBoxColumn();
        this.RequireAmount.DataMember = "RequireAmount";
        this.RequireAmount.Required = true;
        this.RequireAmount.Format = "N2";
        this.RequireAmount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.RequireAmount.DisplayIndex = 5;
        this.RequireAmount.HeaderText = i18n("M16061", "İade Edilecek Miktar");
        this.RequireAmount.Name = "RequireAmount";
        this.RequireAmount.Width = 100;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.Format = "N2";
        this.Amount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Amount.DisplayIndex = 6;
        this.Amount.HeaderText = i18n("M10707", "Alınan Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Visible = false;
        this.Amount.Width = 100;

        this.StockLevelType = new TTVisual.TTListDefComboBoxColumn();
        this.StockLevelType.ListDefName = "StockLevelTypeList";
        this.StockLevelType.DataMember = "StockLevelType";
        this.StockLevelType.DisplayIndex = 7;
        this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelType.Name = "StockLevelType";
        this.StockLevelType.ReadOnly = true;
        this.StockLevelType.Width = 100;
        //this.StockActionOutDetailsColumns>

        this.ChooseProductsFromTheTree = new TTVisual.TTButton();
        this.ChooseProductsFromTheTree.Text = i18n("M23971", "Ürün Ağacından Seç");
        this.ChooseProductsFromTheTree.Name = "ChooseProductsFromTheTree";
        this.ChooseProductsFromTheTree.TabIndex = 27;
        this.ChooseProductsFromTheTree.Visible = false;

        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = "MKYS_EMalzemeGrupEnum";
        this.MKYS_EMalzemeGrup.BackColor = "#F0F0F0";
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = "MKYS_EMalzemeGrup";
        this.MKYS_EMalzemeGrup.TabIndex = 17;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = i18n("M18581", "Malzeme Grup");
        this.labelMKYS_EMalzemeGrup.Name = "labelMKYS_EMalzemeGrup";
        this.labelMKYS_EMalzemeGrup.TabIndex = 16;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 16;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        // this.StockActionOutDetailsColumns = [this.Detail, this.Material, this.Barcode, this.DistributionType, this.Existing, this.RequireAmount, this.Amount, this.StockLevelType];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage, this.DescriptionTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.tttabcontrol1.Controls = [this.MaterialTabPage];
        this.MaterialTabPage.Controls = [this.StockActionOutDetails, this.ChooseProductsFromTheTree];
        this.Controls = [this.labelMKYS_TeslimEden, this.MKYS_TeslimEden, this.MKYS_TeslimAlan, this.Description, this.StockActionID, this.labelMKYS_TeslimAlan, this.labelStore, this.Store, this.labelDestinationStore, this.DestinationStore, this.cmdHEKReport, this.labelTransactionDate, this.TransactionDate, this.labelStockActionID, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.DescriptionTabpage, this.tttabcontrol1, this.MaterialTabPage, this.StockActionOutDetails, this.Detail, this.Material, this.Barcode, this.DistributionType, this.Existing, this.RequireAmount, this.Amount, this.StockLevelType, this.ChooseProductsFromTheTree, this.MKYS_EMalzemeGrup, this.labelMKYS_EMalzemeGrup, this.ttlabel1, this.TTTeslimAlanButon, this.TTTeslimEdenButon];

    }


}
