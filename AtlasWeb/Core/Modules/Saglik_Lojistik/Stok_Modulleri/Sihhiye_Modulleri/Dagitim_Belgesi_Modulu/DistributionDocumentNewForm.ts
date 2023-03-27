//$A5CF2FF8
import { Component, OnInit, ChangeDetectorRef, NgZone, ViewChild, EventEmitter } from '@angular/core';
import { DistributionDocumentNewFormViewModel, GetUnsuccessfulDistributionDocumentsInputModel, GetUnsuccessfulDistributionDocument_Class } from './DistributionDocumentNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseDistributionDocumentForm } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Dagitim_Belgesi_Modulu/BaseDistributionDocumentForm';
import { DistributionDocument, Stock, MKYS_EMalzemeGrupEnum, TransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionDocumentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { MainStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ProductTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SelectStoreUsageEnum, StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { SubStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SystemMessageService } from 'ObjectClassService/SystemMessageService';
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { MKYS_ECikisIslemTuruEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DoubleType } from 'NebulaClient/DataDictionary/TTDataType';
import { MKYS_ECikisStokHareketTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionService, AutoDistributionCreate_Output } from 'NebulaClient/Services/ObjectService/StockActionService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';

import { TTUser } from 'app/NebulaClient/StorageManager/Security/TTUser';
import { SystemParameterService } from 'ObjectClassService/SystemParameterService';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelTypeService } from 'ObjectClassService/StockLevelTypeService';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { IModalService } from 'Fw/Services/IModalService';
import { DxDataGridComponent } from 'devextreme-angular';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";
import { StockLevelService, GetStockValues_Output } from 'app/NebulaClient/Services/ObjectService/StockLevelService';
import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';

import { resolve } from 'url';
import { DistributionDocumentService } from 'app/NebulaClient/Services/ObjectService/DistributionDocumentService';
import { String } from 'core-js';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { StockService } from 'app/NebulaClient/Services/ObjectService/StockService';
import { MaterialSelectorInput, NewMaterialService } from 'app/Logistic/Views/NewMaterialSelectComponent';


@Component({
    selector: 'DistributionDocumentNewForm',
    templateUrl: './DistributionDocumentNewForm.html',
    providers: [MessageService]
})
export class DistributionDocumentNewForm extends BaseDistributionDocumentForm implements OnInit {
    ChooseProductsFromTheTree: TTVisual.ITTButton;
    AutoDistributionButton: TTVisual.ITTButton;
    IsEmergencyMaterial: boolean = false;
    //public DistributionDocumentMaterialsColumns = [];
    public DistributionDocumentMaterialsColumns = [
        // {
        //     caption: ' ',
        //     dataField: 'ObjectID',
        //     cellTemplate: 'buttonCellTemplate',
        //     width: 100
        // },
        {
            caption: 'Malzeme Adı',
            dataField: 'Material.Name',
            allowEditing: false,
            width: 350
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false
        },
        {
            caption: 'Ölçü Birimi',
            dataField: 'Material.DistributionTypeName',
            allowEditing: false
        },
        {
            caption: 'İstenen Miktar',
            dataField: 'AcceptedAmount',
            dataType: 'number'
        },
        {
            caption: 'Verilen Miktar',
            dataField: 'Amount',
            dataType: 'number',
            visible: false
        },
        {
            caption: 'Ana Depo Mevcudu',
            dataField: 'StoreStock',
            dataType: 'number',
            allowEditing: false
        },
        {
            caption: 'Cep Depo Mevcudu',
            dataField: 'DestinationStoreStock',
            dataType: 'number',
            allowEditing: false
        },
        {
            caption: 'Cep Depo Max Seviye',
            dataField: 'DestinationStoreMaxLevel',
            dataType: 'number',
            allowEditing: false
        },
        {
            caption: 'Künye No',
            dataField: 'TagNo',
            allowEditing: true
        },
        {
            caption: 'Malın Durumu',
            dataField: 'StockLevelType.Description',
            allowEditing: false
            //width: 250
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
            width: 'auto',
            cellTemplate: 'deleteCellTemplate'
        },
    ];

    @ViewChild('distributionDocumentNewFormMaterialGrid') distributionDocumentNewFormMaterialGrid: DxDataGridComponent;
    async distributionDocumentNewFormMaterialGrid_CellContentClicked(data: any) {
        let that = this;
        if (this.ReadOnly != true) {
            if (data.column.name = "RowDelete") {
                if (data.row != null) {
                    if (data.row.key != null) {
                        if (data.row.key.IsNew == null) {
                            this.distributionDocumentNewFormMaterialGrid.instance.deleteRow(data.rowIndex);
                        }
                        else {
                            if (data.row.key.IsNew) {
                                this.distributionDocumentNewFormMaterialGrid.instance.deleteRow(data.rowIndex);
                            }
                            else {
                                data.key.EntityState = EntityStateEnum.Deleted;
                                this.distributionDocumentNewFormMaterialGrid.instance.filter(['EntityState', '<>', 1]);
                                this.distributionDocumentNewFormMaterialGrid.instance.refresh();
                            }
                        }
                    }
                }
            }
        }
    }


    public PopupTagNo: string;
    public TagNoPopupVisible = false;
    public StockActionSignDetailsColumns = [];
    public MaterialInput: MaterialSelectorInput = new MaterialSelectorInput();
    public distributionDocumentNewFormViewModel: DistributionDocumentNewFormViewModel = new DistributionDocumentNewFormViewModel();
    public get _DistributionDocument(): DistributionDocument {
        return this._TTObject as DistributionDocument;
    }
    private DistributionDocumentNewForm_DocumentUrl: string = '/api/DistributionDocumentService/DistributionDocumentNewForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private changeDetectorRef: ChangeDetectorRef, protected modalService: IModalService, protected objectContextService: ObjectContextService,
        protected ngZone: NgZone) {
        super(httpService, messageService, modalService, objectContextService, ngZone);
        this._DocumentServiceUrl = this.DistributionDocumentNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    // ***** Method declarations start *****
    public async AutoDistributionButton_Click(): Promise<void> {
        if (this._DistributionDocument.Store != null && this._DistributionDocument.DestinationStore != null) {

            let result: Array<AutoDistributionCreate_Output> = await StockActionService.AutoDistributionCreate(this._DistributionDocument.Store, this._DistributionDocument.DestinationStore);
            if (result.length > 0) {
                for (let distMaterial of result) {
                    let distributionDocumentMaterial: DistributionDocumentMaterial = new DistributionDocumentMaterial();
                    distributionDocumentMaterial.Material = distMaterial.material;
                    distributionDocumentMaterial.AcceptedAmount = distMaterial.amount;
                    distributionDocumentMaterial.Amount = distMaterial.amount;
                    distributionDocumentMaterial.TagNo = distMaterial.TagNO;
                    distributionDocumentMaterial.StockLevelType = distMaterial.stockLevelType;
                    distributionDocumentMaterial.Material.StockCard = distMaterial.stockCard;
                    distributionDocumentMaterial.Material.StockCard.DistributionType = distMaterial.distributionType;
                    distributionDocumentMaterial.StoreStock = distMaterial.storeInheld;
                    distributionDocumentMaterial.DestinationStoreStock = distMaterial.destinationStoreInheld;
                    distributionDocumentMaterial.DestinationStoreMaxLevel = distMaterial.destinationStoreMaxLevel;

                    this.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials.push(distributionDocumentMaterial);
                    this._DistributionDocument.IsAutoDistribution = true;
                }
                this.AutoDistributionButton.Enabled = false;
                this.AutoDistributionButton.ReadOnly = true;
            } else {
                ServiceLocator.MessageService.showError(i18n("M19816", "Otomatik dağıtım için malzeme bulunamadı."));
                return;
            }
        } else {
            ServiceLocator.MessageService.showError("Ana Depo ve / veya Servis Depo seçilmeden işlem yapılamaz.");
            return;
        }
    }

    public async ChooseProductsFromTheTree_Click(): Promise<void> {
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        let productTreeDefinitions: Array<any> = this._DistributionDocument.ObjectContext.QueryObjects(typeof ProductTreeDefinition, '');
        for (let productTreeDefinition of productTreeDefinitions) { multiSelectForm.AddMSItem(productTreeDefinition.Material.Name, productTreeDefinition.ObjectID.toString(), productTreeDefinition); }
        multiSelectForm.GetMSItem(this, i18n("M23980", "Ürünü Seçiniz..."));
        if (multiSelectForm.MSSelectedItemObject !== null) {
            let productTreeDefinition: ProductTreeDefinition = multiSelectForm.MSSelectedItemObject as ProductTreeDefinition;
            if (productTreeDefinition !== null) {
                let retValue: string = await TTVisual.InputForm.GetText(i18n("M23946", "Üretilecek İlaç/Malzeme miktarını giriniz..."));
                if (retValue !== "") {
                    let amount = 0;
                    if (DoubleType.TryConvertFrom(retValue, true, amount) === false) {
                        throw new TTException((await SystemMessageService.GetMessageV3(1192, [retValue.toString()])));
                    }
                    for (let productTreeDetail of productTreeDefinition.ProductTreeDetails) {
                        let distributionDocumentMaterial: DistributionDocumentMaterial = this._DistributionDocument.DistributionDocumentMaterials.AddNew();
                        distributionDocumentMaterial.Material = productTreeDetail.ConsumableMaterial;
                        let coefficient: number = productTreeDetail.Amount.Value / productTreeDefinition.SampleAmount.Value;
                        distributionDocumentMaterial.AcceptedAmount = amount * coefficient;
                        //distributionDocumentMaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                    }
                    this.ChooseProductsFromTheTree.Enabled = false;
                }
            }
        }
    }

    protected async BarcodeRead(value: string): Promise<void> {
        super.BarcodeRead(value);
        /*let barcode: string = (await CommonService.PrepareBarcode(value));
        let material: Material = null;
        let materials: Array<any> = this._DistributionDocument.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + barcode + "'");
        if (materials.length === 0)
            TTVisual.InfoBox.Show(barcode + " UBB/Barkodlu malzeme bulunamadı.", MessageIconEnum.ErrorMessage);
        else if (materials.length === 1)
            material = <Material>materials[0];
        else {
            let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            for (let m of materials) {
                multiSelectForm.AddMSItem(m.Name, m.Name, m);
            }
            let key: string = multiSelectForm.GetMSItem(ParentForm, "Malzeme seçin");
            if (String.isNullOrEmpty(key))
                TTVisual.InfoBox.Show("Herhangibir malzeme seçilmedi.", MessageIconEnum.ErrorMessage);
            else material = multiSelectForm.MSSelectedItemObject as Material;
        }
        if (material !== null) {
            let getAmount: Currency = 0;
            let retGetAmount: string = TTVisual.InputForm.GetText("İstenen Miktarı Giriniz.");
            if (String.isNullOrEmpty(retGetAmount) === false) {
                if (CurrencyType.TryConvertFrom(retGetAmount, false, getAmount) === false)
                    throw new TTException((await SystemMessageService.GetMessageV3(1192, [retGetAmount.toString()])));
            }
            let returningDocument: DistributionDocumentMaterial = this._DistributionDocument.DistributionDocumentMaterials.AddNew();
            returningDocument.Material = material;
            returningDocument.AcceptedAmount = getAmount;
            returningDocument.Amount = getAmount;
            returningDocument.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
        }*/
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        this.distributionDocumentNewFormMaterialGrid.instance.closeEditCell();
        this.distributionDocumentNewFormMaterialGrid.instance.saveEditData();
    }

    protected async PostScript(transDef: TTObjectStateTransitionDef) {

        super.PostScript(transDef);

        let errorRow: string = "";
        for (let gridData of this._DistributionDocument.DistributionDocumentMaterials) {
            if (gridData.AcceptedAmount === 0) {
                errorRow += gridData.Material.Name + " İstenen Miktar 0'a eşit olamaz.";
            }
        }
        if (errorRow !== "") {
            throw new TTException(errorRow);
        }

        this._DistributionDocument.IsEmergencyMaterial = this.IsEmergencyMaterial;


        /* if (this._DistributionDocument.MKYS_TeslimAlan == null || this._DistributionDocument.MKYS_TeslimAlan === undefined) {
             throw new TTException("Teslim Alan Boş Olamaz");
         }
         if (this._DistributionDocument.MKYS_TeslimEden == null || this._DistributionDocument.MKYS_TeslimEden === undefined) {
             throw new TTException("Teslim Eden Boş Olamaz");
         }*/
    }

    inputStore: Store;
    public setInputParam(value: Store) {
        if (value != null) {
            if (value.ObjectDefID.toString() === SubStoreDefinition.ObjectDefID.id)
                this.inputStore = value;
        }
    }


    public preventNewForm = false;
    public resultMessage = "";
    protected async PreScript() {
        try {

            if (this._DistributionDocument.IsEmergencyMaterial != null)
                this.IsEmergencyMaterial = this._DistributionDocument.IsEmergencyMaterial;

            if (this._DistributionDocument.Store == null) {
                this._DistributionDocument.DestinationStore = this.inputStore;
                await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStores, SelectStoreUsageEnum.UseUserResources);
                let result = null;
                let UnsuccessfulDistributionDocuments: string = (await SystemParameterService.GetParameterValue('UNSUCCESSDISTDOC', 'FALSE'));
                if (UnsuccessfulDistributionDocuments === 'TRUE') {
                    let apiUrlForPASearchUrl: string = '/api/DistributionDocumentService/GetUnsuccessfulDistributionDocuments';
                    let param: GetUnsuccessfulDistributionDocumentsInputModel = new GetUnsuccessfulDistributionDocumentsInputModel();
                    param.StoreId = this._DistributionDocument.DestinationStore.ObjectID;
                    result = await this.httpService.post(apiUrlForPASearchUrl, param) as Array<GetUnsuccessfulDistributionDocument_Class>;
                }
                if (result != null && result.length > 0) {
                    if (result.length == 1) {
                        this.resultMessage = result[0].StockActionID + " Numaralı isteminiz henüz onaylanmamıştır.  Lütfen önce bu isteminizi onaylayınız.";
                    }
                    else {
                        this.resultMessage = "Toplam " + result.length + " adet onaylanmamış isteğiniz bulunmaktadır, lütfen daha önceki isteklerinizi onaylayınız.  İşlem Numaraları:  ";
                        for (var i = 0; i < result.length; i++) {
                            if (i == 0)
                                this.resultMessage += result[i].StockActionID;
                            else
                                this.resultMessage += ", " + result[i].StockActionID;
                        }
                        this.resultMessage += ".";
                    }

                    TTVisual.InfoBox.Alert(this.resultMessage);
                    this.preventNewForm = true;
                    this.NewFormCancel();
                }
                else {
                    super.PreScript();
                    await this.DropStateButton(DistributionDocument.DistributionDocumentStates.Completed);

                    if (this._DistributionDocument.Store == null) {
                        this._DistributionDocument.DestinationStore = this.inputStore;
                        await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStores, SelectStoreUsageEnum.UseUserResources);
                    }

                    this.MaterialDistributionDocumentMaterial.ListFilterExpression = ' STOCKS.STORE=\'' + this._DistributionDocument.Store.ObjectID + '\' AND STOCKS.INHELD > 0 AND ( ShowZeroOnDistributionInfo IS NULL OR ShowZeroOnDistributionInfo = 0 )';
                    if (this._DistributionDocument.Store instanceof MainStoreDefinition) {
                        this._DistributionDocument.MKYS_TeslimEden = (<MainStoreDefinition>this._DistributionDocument.Store).GoodsAccountant.Name;
                        this._DistributionDocument.MKYS_TeslimEdenObjID = (<MainStoreDefinition>this._DistributionDocument.Store).GoodsAccountant.ObjectID;
                    }
                    this._DistributionDocument.MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.cikis;
                    this._DistributionDocument.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckTuketim;
                    if (this._DistributionDocument.DestinationStore instanceof SubStoreDefinition) {
                        this._DistributionDocument.MKYS_TeslimAlan = (<SubStoreDefinition>this._DistributionDocument.DestinationStore).StoreResponsible.Name;
                        this._DistributionDocument.MKYS_TeslimAlanObjID = (<SubStoreDefinition>this._DistributionDocument.DestinationStore).StoreResponsible.ObjectID;
                    }

                    this._DistributionDocument.MKYS_TeslimAlan = TTUser.CurrentUser.Name;
                    this._DistributionDocument.MKYS_TeslimAlanObjID = TTUser.CurrentUser.UserObject.ObjectID;


                    let mainStoreInheld: string = (await SystemParameterService.GetParameterValue('MAINSTOREINHELD', 'TRUE'));
                    if (mainStoreInheld === 'TRUE') {
                        this.StoreInheld.Visible = true;
                    }
                    else {
                        this.StoreInheld.Visible = false;
                    }
                }
            }
        }
        catch (ex) {
            TTVisual.InfoBox.Alert(ex);
        }

        this.MaterialInput.MaterialGroup = MKYS_EMalzemeGrupEnum.diger;
        this.MaterialInput.TransactionType = TransactionTypeEnum.Out;
        this.MaterialInput.StoreID = this._DistributionDocument.Store.ObjectID;
        this.MaterialInput.DestinationStoreID = this._DistributionDocument.DestinationStore.ObjectID;
        this.MaterialInput.TicketDate = this._DistributionDocument.TransactionDate;

        /*if (_DistributionDocument.StockActionSignDetails.Count == 0)
        {
            StockActionSignDetail stockActionSignDetail = _DistributionDocument.StockActionSignDetails.AddNew();
            stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimEden;
            if (_DistributionDocument.Store is MainStoreDefinition)
                stockActionSignDetail.SignUser = ((MainStoreDefinition)_DistributionDocument.Store).GoodsAccountant;

            stockActionSignDetail = _DistributionDocument.StockActionSignDetails.AddNew();
            stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimAlan;
            if (_DistributionDocument.DestinationStore is SubStoreDefinition)
                stockActionSignDetail.SignUser = ((SubStoreDefinition)_DistributionDocument.DestinationStore).StoreResponsible;


        }
        //this._DistributionDocument.SetMKYSProperties();
        this.ChooseProductsFromTheTree.Visible = false;
        if ((await SystemParameterService.GetSite()).ObjectID === Sites.SiteOrduIlac) {
            //DescriptionAndSignTabControl.Size = new Size(DescriptionAndSignTabControl.Size.Width - ChooseProductsFromTheTree.Size.Width - 10, DescriptionAndSignTabControl.Size.Height);
            this.ChooseProductsFromTheTree.Visible = true;
        }*/
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DistributionDocument();
        this.distributionDocumentNewFormViewModel = new DistributionDocumentNewFormViewModel();
        this._ViewModel = this.distributionDocumentNewFormViewModel;
        this.distributionDocumentNewFormViewModel._DistributionDocument = this._TTObject as DistributionDocument;
        this.distributionDocumentNewFormViewModel._DistributionDocument.Store = new Store();
        this.distributionDocumentNewFormViewModel._DistributionDocument.DestinationStore = new Store();
        this.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials = new Array<DistributionDocumentMaterial>();
        this.distributionDocumentNewFormViewModel._DistributionDocument.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    async MaterialsCleared() {
        //this.showMaterialMultiSelectForm = false;
    }

    protected loadViewModel() {
        let that = this;

        that.distributionDocumentNewFormViewModel = this._ViewModel as DistributionDocumentNewFormViewModel;
        that._TTObject = this.distributionDocumentNewFormViewModel._DistributionDocument;
        if (this.distributionDocumentNewFormViewModel == null) {
            this.distributionDocumentNewFormViewModel = new DistributionDocumentNewFormViewModel();
        }
        if (this.distributionDocumentNewFormViewModel._DistributionDocument == null) {
            this.distributionDocumentNewFormViewModel._DistributionDocument = new DistributionDocument();
        }
        let storeObjectID = that.distributionDocumentNewFormViewModel._DistributionDocument['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.distributionDocumentNewFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.distributionDocumentNewFormViewModel._DistributionDocument.Store = store;
            }
        }
        let destinationStoreObjectID = that.distributionDocumentNewFormViewModel._DistributionDocument['DestinationStore'];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.distributionDocumentNewFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.distributionDocumentNewFormViewModel._DistributionDocument.DestinationStore = destinationStore;
            }
        }
        that.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials = that.distributionDocumentNewFormViewModel.DistributionDocumentMaterialsGridList;
        for (let detailItem of that.distributionDocumentNewFormViewModel.DistributionDocumentMaterialsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.distributionDocumentNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.distributionDocumentNewFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.distributionDocumentNewFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let stockLevelTypeObjectID = detailItem['StockLevelType'];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.distributionDocumentNewFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.distributionDocumentNewFormViewModel._DistributionDocument.StockActionSignDetails = that.distributionDocumentNewFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.distributionDocumentNewFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem['SignUser'];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.distributionDocumentNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }

    public ShowNewMaterialList: boolean = false;
    async ngOnInit() {
        let that = this;
        await this.load(DistributionDocumentNewFormViewModel);
        if (this._DistributionDocument.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._DistributionDocument.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = '#F0F0F0';
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M12438", "Dağıtım Belgesi ( Yeni )");
        this.changeDetectorRef.detectChanges();

        let listParameter: string = (await SystemParameterService.GetParameterValue('SHOWNEWMATERIALLIST', 'FALSE'));
        if (listParameter === "TRUE") {
            this.ShowNewMaterialList = true;
        }
        NewMaterialService.onMaterialAdd.subscribe((e) => {
            for (let item of e) {
                if (!this.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials.find(x => x.Material.ObjectID == item.Material.ObjectID && x.EntityState != EntityStateEnum.Deleted)) {
                    let newRow: DistributionDocumentMaterial = new DistributionDocumentMaterial();
                    newRow.Material = item.Material;
                    newRow.Material.StockCard = item.StockCard;
                    newRow.StockLevelType = item.StockLevelType;
                    newRow.Status = StockActionDetailStatusEnum.New;
                    newRow.StoreStock = item.StoreStock;
                    newRow.DestinationStoreStock = item.DestinationStoreStock;
                    newRow.DestinationStoreMaxLevel = item.DestinationStoreMaxLevel;
                    if (item.Material.IsTagNoRequired) {
                        this.TagNoPopupMaterialName = this.selectedMaterial.Name;
                        this.TagNoPopupVisible = true;
                        this.PopupTagNo = "";
                    }
                    this.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials.push(newRow);
                }
                else
                    ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
            }
        });
    }


    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.Description !== event) {
                this._DistributionDocument.Description = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.DestinationStore !== event) {
                this._DistributionDocument.DestinationStore = event;
            }
        }
    }

    public onMKYS_CikisIslemTuruChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.MKYS_CikisIslemTuru !== event) {
                this._DistributionDocument.MKYS_CikisIslemTuru = event;
            }
        }
    }

    public onMKYS_CikisStokHareketTuruChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.MKYS_CikisStokHareketTuru !== event) {
                this._DistributionDocument.MKYS_CikisStokHareketTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._DistributionDocument != null && this._DistributionDocument.MKYS_TeslimAlan !== event) {
                this._DistributionDocument.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = '#F0F0F0';
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._DistributionDocument != null && this._DistributionDocument.MKYS_TeslimEden !== event) {
                this._DistributionDocument.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.StockActionID !== event) {
                this._DistributionDocument.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.Store !== event) {
                this._DistributionDocument.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.TransactionDate !== event) {
                this._DistributionDocument.TransactionDate = event;
            }
        }
    }

    public async stateChange(event: FormSaveInfo) {
        if (this.preventNewForm) {
            ServiceLocator.MessageService.showError(this.resultMessage);
            return;
        }
        let IsTagNoEmpty = false;
        for (var i = 0; i < this.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials.length; i++)
            if (this.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials[i].Material.IsTagNoRequired && (this.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials[i].TagNo == "" || this.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials[i].TagNo == null)) {
                TTVisual.InfoBox.Alert(this.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials[i].Material.Name + " malzemesi için Künye Numarası girmeniz gerekmektedir !");
                IsTagNoEmpty = true;
                return;
            }

        if (!IsTagNoEmpty) {
            if (event.transDef.ToStateDefID.valueOf() === DistributionDocument.DistributionDocumentStates.Approval.id) {

                let isAmountEligable = true;
                this.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials.forEach(element => {
                    if (element.Amount > element.StoreStock)
                        isAmountEligable = false;
                });
                if (isAmountEligable)
                    await super.setState(event.transDef, event);
                else
                    ServiceLocator.MessageService.showError(i18n("", "İstenen Miktar Depo Mevcudunu aşamaz!"));
            }
            else
                await super.setState(event.transDef, event);
        }
    }

    // DistributionDocumentMaterials_CellValueChangedEmitted(data: any) {
    //     if (data && this.DistributionDocumentMaterials_CellValueChanged && data.Row && data.Column) {
    //         this.DistributionDocumentMaterials_CellValueChanged(data, data.RowIndex, data.ColIndex);
    //     }
    // }

    public onEditingStartMaterialGrid(event: any) {
        if (event.data.Material == null) {
            event.cancel = true;
            this.distributionDocumentNewFormMaterialGrid.instance.saveEditData();
        }
    }

    public async materialGridRowUpdating(event: any) {
        if (event.newData.AcceptedAmount != null) {
            if (!isNaN(event.newData.AcceptedAmount)) {
                if (event.key.DestinationStoreMaxLevel > 0) {
                    let totalInheld: number = event.key.DestinationStoreStock + event.newData.AcceptedAmount;
                    if (totalInheld > event.key.DestinationStoreMaxLevel) {
                        let maxRequest: number = event.key.DestinationStoreMaxLevel - event.key.DestinationStoreStock;
                        let errorMessage: string = "Maximum seviye geçiliyor.Depo Mevcudu :" + event.key.DestinationStoreStock.toString() + " - Maxsimum Seviye : " + event.key.DestinationStoreMaxLevel.toString()
                            + "İstenilebilecek Maximum Miktar = " + maxRequest.toString();

                        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), "Maximum Seviye",
                            errorMessage + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
                        if (result === 'V') {
                            event.cancel = true;
                            event.key.AcceptedAmount = 0;
                        }
                    }
                }
                if (event.newData.AcceptedAmount > event.oldData.StoreStock) {
                    ServiceLocator.MessageService.showError(i18n("", "İstenen Miktar Depo Mevcudunu aşamaz!"));
                    event.cancel = true;
                }
                if (event.cancel === false)
                    event.oldData.Amount = event.newData.AcceptedAmount;
            }
        }
        if (event.newData.TagNo != null) {
            event.oldData.TagNo = event.newData.TagNo;
            this.distributionDocumentNewFormMaterialGrid.instance.closeEditCell();
            this.distributionDocumentNewFormMaterialGrid.instance.saveEditData();
        }
    }


    public async MaterialDetails_RowUpdated(event: any) {
    }


    /* public async onSelectionChange(data: any) {
         await super.DistributionDocumentMaterials_CellValueChanged(data, 0, 0);
         this.distributionDocumentNewFormMaterialGrid.instance.closeEditCell();
         this.distributionDocumentNewFormMaterialGrid.instance.saveEditData();
         // this.distributionDocumentNewFormMaterialGrid.instance.refresh();
         // this.distributionDocumentNewFormMaterialGrid.instance.repaint();
     }*/

    public isCompletedForm: boolean = false;
    public TagNoPopupMaterialName: string;
    public selectedMaterial: Material;
    public selectedStockLevelType: StockLevelType;
    public stockLeveltypeArray: Array<StockLevelType> = new Array<StockLevelType>();
    public async onMaterialSelectionChange(event: any) {
        if (this.stockLeveltypeArray.length == 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
        if (this.selectedMaterial == null)
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        else
            if (!this.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials.find(x => x.Material.ObjectID == this.selectedMaterial.ObjectID && x.EntityState != EntityStateEnum.Deleted)) {
                let newRow: DistributionDocumentMaterial = new DistributionDocumentMaterial();
                newRow.IsNew = true;
                newRow.Material = this.selectedMaterial;
                newRow.StockLevelType = this.selectedStockLevelType;
                newRow.Status = StockActionDetailStatusEnum.New;
                this.setStoreStock(newRow);
                if (this.selectedMaterial.IsTagNoRequired) {
                    this.TagNoPopupMaterialName = this.selectedMaterial.Name;
                    this.TagNoPopupVisible = true;
                    this.PopupTagNo = "";
                }
                this.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials.push(newRow);
            }
            else
                ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
    }

    public async setStoreStock(distributionDocumentMaterial: DistributionDocumentMaterial): Promise<any> {
        if (distributionDocumentMaterial.Status === undefined) {
            distributionDocumentMaterial.Status = StockActionDetailStatusEnum.New;
            //let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);

        }
        if (distributionDocumentMaterial.Material.ObjectID != null) {
            let stockValues: GetStockValues_Output = await StockLevelService.GetStockValues(distributionDocumentMaterial.Material.ObjectID, this._DistributionDocument.Store.ObjectID, StockLevelTypeEnum.New, this._DistributionDocument.DestinationStore.ObjectID);
            if (stockValues != null) {
                distributionDocumentMaterial.StockLevelType = stockValues.StockLevelType;
                distributionDocumentMaterial.StoreStock = stockValues.StoreStock;
                distributionDocumentMaterial.DestinationStoreStock = stockValues.DestinationStoreStock;
                distributionDocumentMaterial.DestinationStoreMaxLevel = stockValues.DestinationStoreMaxLevel;
            }
        }
    }

    // public async DistributionDocumentMaterials_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
    //     await super.DistributionDocumentMaterials_CellValueChanged(data, rowIndex, columnIndex);
    // }

    onRowInserting(data: DistributionDocumentMaterial) {
    }

    onCellContentClicked(data: any) {
    }

    async initNewRow(data: any) {
    }


    NewFormCancel() {
        super.cancel();
    }

    private showMaterialMultiSelectForm: boolean = false;
    OpenMaterialMultiSelectComponent() {
        this.showMaterialMultiSelectForm = true;
    }

    //UTS için eklendi
    private showPatientBasedMaterialMultiSelectForm: boolean = false;
    OpenPatientBasedMaterialSelectComponent() {
        this.showPatientBasedMaterialMultiSelectForm = true;
    }


    OnInserted: EventEmitter<any> = new EventEmitter<any>();
    public inserTagNo() {
        this.TagNoPopupVisible = false;
        if (this.PopupTagNo != "")
            for (var i = 0; i < this.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials.length; i++)
                if (this.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials[i].Material.Name == this.TagNoPopupMaterialName) {
                    this.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials[i].TagNo = this.PopupTagNo;
                }

        this.OnInserted.emit();
    }

    async MaterialsSelected(event) {
        this.showMaterialMultiSelectForm = false;
        let selectedMaterials = event;

        for (var i = 0; i < selectedMaterials.length; i++) {
            let element = selectedMaterials[i];

            let distributionDocumentMaterial: DistributionDocumentMaterial = new DistributionDocumentMaterial();
            distributionDocumentMaterial.Material = element;
            distributionDocumentMaterial.TagNo = "";
            distributionDocumentMaterial.Material.DistributionTypeName = element.Distributiontypename;
            if (element.Inheld != null) {
                distributionDocumentMaterial.StoreStock = Number.parseInt(element.Inheld);
            }

            distributionDocumentMaterial.Status = StockActionDetailStatusEnum.New;
            this.distributionDocumentNewFormViewModel._DistributionDocument.DistributionDocumentMaterials.push(distributionDocumentMaterial);
            if (distributionDocumentMaterial.Material.IsTagNoRequired) {
                let a = await this.GetTagNo(distributionDocumentMaterial.Material.Name);
            }
        }


        let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this._DistributionDocument.DistributionDocumentMaterials.forEach(element => {
            element.StockLevelType = stockLeveltypeArray[0];
        });

        this._DistributionDocument.IsAutoDistribution = true;
        this.AutoDistributionButton.Enabled = false;
        this.AutoDistributionButton.ReadOnly = true;

    }

    async GetTagNo(MaterialName: string) {
        this.TagNoPopupMaterialName = MaterialName;
        this.TagNoPopupVisible = true;
        this.PopupTagNo = "";

        return new Promise((resolve, reject) => {
            this.OnInserted.subscribe(x => {
                resolve();
            });
        });
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.TransactionDate, 'Value', this.__ttObject, 'TransactionDate');
        redirectProperty(this.MKYS_CikisStokHareketTuru, 'Value', this.__ttObject, 'MKYS_CikisStokHareketTuru');
        redirectProperty(this.MKYS_CikisIslemTuru, 'Value', this.__ttObject, 'MKYS_CikisIslemTuru');
        redirectProperty(this.MKYS_TeslimAlan, 'Text', this.__ttObject, 'MKYS_TeslimAlan');
        redirectProperty(this.MKYS_TeslimEden, 'Text', this.__ttObject, 'MKYS_TeslimEden');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');

    }

    public initFormControls(): void {



        this.ChooseProductsFromTheTree = new TTVisual.TTButton();
        this.ChooseProductsFromTheTree.Text = i18n("M23971", "Ürün Ağacından Seç");
        this.ChooseProductsFromTheTree.Name = 'ChooseProductsFromTheTree';
        this.ChooseProductsFromTheTree.TabIndex = 27;
        this.ChooseProductsFromTheTree.Visible = false;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = 'labelMKYS_TeslimEden';
        this.labelMKYS_TeslimEden.TabIndex = 139;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        //this.MKYS_TeslimEden.BackColor = '#FFE3C6';
        this.MKYS_TeslimEden.Name = 'MKYS_TeslimEden';
        this.MKYS_TeslimEden.TabIndex = 138;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        //this.MKYS_TeslimAlan.BackColor = '#FFE3C6';
        this.MKYS_TeslimAlan.Name = 'MKYS_TeslimAlan';
        this.MKYS_TeslimAlan.TabIndex = 136;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.Description.Name = 'Description';
        this.Description.TabIndex = 6;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = 'labelMKYS_TeslimAlan';
        this.labelMKYS_TeslimAlan.TabIndex = 137;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = 'labelStore';
        this.labelStore.TabIndex = 135;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = 'MainStoreList';
        this.Store.Name = 'Store';
        this.Store.TabIndex = 134;
        this.Store.BackColor = '#F0F0F0';
        this.Store.Enabled = false;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M10678", "Alan Depo");
        this.labelDestinationStore.Name = 'labelDestinationStore';
        this.labelDestinationStore.TabIndex = 133;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ReadOnly = true;
        this.DestinationStore.ListDefName = 'SubStoreList';
        this.DestinationStore.Name = 'DestinationStore';
        this.DestinationStore.TabIndex = 132;

        this.DistributionDocumentMaterialsTabcontrol = new TTVisual.TTTabControl();
        this.DistributionDocumentMaterialsTabcontrol.Name = 'DistributionDocumentMaterialsTabcontrol';
        this.DistributionDocumentMaterialsTabcontrol.TabIndex = 30;

        this.DistributionDocumentMaterialsTabpage = new TTVisual.TTTabPage();
        this.DistributionDocumentMaterialsTabpage.DisplayIndex = 0;
        this.DistributionDocumentMaterialsTabpage.TabIndex = 0;
        this.DistributionDocumentMaterialsTabpage.Text = 'Taşınır Malın';
        this.DistributionDocumentMaterialsTabpage.Name = 'DistributionDocumentMaterialsTabpage';

        this.DistributionDocumentMaterials = new TTVisual.TTGrid();
        this.DistributionDocumentMaterials.Name = 'DistributionDocumentMaterials';
        this.DistributionDocumentMaterials.TabIndex = 29;
        this.DistributionDocumentMaterials.Height = 540;
        this.DistributionDocumentMaterials.AllowUserToDeleteRows = true;
        this.DistributionDocumentMaterials.DeleteButtonWidth = "%3";

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = '';
        this.Detail.Name = 'Detail';
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.MaterialDistributionDocumentMaterial = new TTVisual.TTListBoxColumn();
        this.MaterialDistributionDocumentMaterial.AllowMultiSelect = true;
        this.MaterialDistributionDocumentMaterial.ListDefName = 'MaterialListDefinition';
        this.MaterialDistributionDocumentMaterial.DataMember = 'Material';
        this.MaterialDistributionDocumentMaterial.AutoCompleteDialogHeight = '60%';
        this.MaterialDistributionDocumentMaterial.AutoCompleteDialogWidth = '90%';
        this.MaterialDistributionDocumentMaterial.DisplayIndex = 1;
        this.MaterialDistributionDocumentMaterial.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialDistributionDocumentMaterial.Name = 'Material';
        this.MaterialDistributionDocumentMaterial.Width = 400;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = 'Material.Barcode';
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = 'Barkod';
        this.Barcode.Name = 'Barcode';
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 110;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = 'Material.DistributionTypeName';
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = 'DistributionType';
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 110;

        this.AcceptedAmountDistributionDocumentMaterial = new TTVisual.TTTextBoxColumn();
        this.AcceptedAmountDistributionDocumentMaterial.DataMember = 'AcceptedAmount';
        this.AcceptedAmountDistributionDocumentMaterial.Required = true;
        this.AcceptedAmountDistributionDocumentMaterial.Format = 'N4';
        this.AcceptedAmountDistributionDocumentMaterial.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AcceptedAmountDistributionDocumentMaterial.DisplayIndex = 4;
        this.AcceptedAmountDistributionDocumentMaterial.HeaderText = i18n("M16713", "İstenen Miktar");
        this.AcceptedAmountDistributionDocumentMaterial.Name = 'AcceptedAmountDistributionDocumentMaterial';
        this.AcceptedAmountDistributionDocumentMaterial.Width = 120;
        this.AcceptedAmountDistributionDocumentMaterial.IsNumeric = true;

        this.AmountDistributionDocumentMaterial = new TTVisual.TTTextBoxColumn();
        this.AmountDistributionDocumentMaterial.DataMember = 'Amount';
        this.AmountDistributionDocumentMaterial.Format = 'N4';
        this.AmountDistributionDocumentMaterial.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountDistributionDocumentMaterial.DisplayIndex = 5;
        this.AmountDistributionDocumentMaterial.HeaderText = i18n("M24114", "Verilen Miktar");
        this.AmountDistributionDocumentMaterial.Name = 'AmountDistributionDocumentMaterial';
        this.AmountDistributionDocumentMaterial.Width = 120;
        this.AmountDistributionDocumentMaterial.Visible = false;
        this.AmountDistributionDocumentMaterial.IsNumeric = true;

        this.StoreInheld = new TTVisual.TTTextBoxColumn();
        this.StoreInheld.DataMember = 'StoreStock';
        this.StoreInheld.Format = 'N4';
        this.StoreInheld.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreInheld.DisplayIndex = 6;
        this.StoreInheld.HeaderText = i18n("M12625", "Depo Mevcudu");
        this.StoreInheld.Name = 'StoreInheld';
        this.StoreInheld.ReadOnly = true;
        this.StoreInheld.Width = 120;

        this.StockLevelTypeDistributionDocumentMaterial = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeDistributionDocumentMaterial.ListDefName = 'StockLevelTypeList';
        this.StockLevelTypeDistributionDocumentMaterial.DataMember = 'StockLevelType';
        this.StockLevelTypeDistributionDocumentMaterial.DisplayIndex = 7;
        this.StockLevelTypeDistributionDocumentMaterial.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeDistributionDocumentMaterial.Name = 'StockLevelType';
        this.StockLevelTypeDistributionDocumentMaterial.ReadOnly = true;
        this.StockLevelTypeDistributionDocumentMaterial.Width = 140;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = 'UnitPrice';
        this.UnitPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPrice.DisplayIndex = 8;
        this.UnitPrice.HeaderText = i18n("M11860", "Birim Fiyatı");
        this.UnitPrice.Name = 'UnitPrice';
        this.UnitPrice.ReadOnly = true;
        this.UnitPrice.Width = 30;
        this.UnitPrice.Visible = false;
        this.UnitPrice.IsNumeric = true;

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DataMember = 'Price';
        this.Price.Format = 'N4';
        this.Price.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Price.DisplayIndex = 9;
        this.Price.HeaderText = i18n("M23613", "Tutarı");
        this.Price.Name = 'Price';
        this.Price.ReadOnly = true;
        this.Price.Width = 30;
        this.Price.Visible = false;
        this.Price.IsNumeric = true;

        this.StatusDistributionDocumentMaterial = new TTVisual.TTEnumComboBoxColumn();
        this.StatusDistributionDocumentMaterial.DataTypeName = 'StockActionDetailStatusEnum';
        this.StatusDistributionDocumentMaterial.DataMember = 'Status';
        this.StatusDistributionDocumentMaterial.DisplayIndex = 10;
        this.StatusDistributionDocumentMaterial.HeaderText = 'Durum';
        this.StatusDistributionDocumentMaterial.Name = 'StatusDistributionDocumentMaterial';
        this.StatusDistributionDocumentMaterial.ReadOnly = true;
        this.StatusDistributionDocumentMaterial.Visible = false;
        this.StatusDistributionDocumentMaterial.Width = 75;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = '#F0F0F0';
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.StockActionID.Name = 'StockActionID';
        this.StockActionID.TabIndex = 0;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = '#F0F0F0';
        this.TransactionDate.CustomFormat = '';
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.TransactionDate.Name = 'TransactionDate';
        this.TransactionDate.TabIndex = 1;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16869", "İşlem Nu.");
        this.labelStockActionID.BackColor = '#DCDCDC';
        this.labelStockActionID.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelStockActionID.ForeColor = '#000000';
        this.labelStockActionID.Name = 'labelStockActionID';
        this.labelStockActionID.TabIndex = 4;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.BackColor = '#DCDCDC';
        this.labelTransactionDate.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelTransactionDate.ForeColor = '#000000';
        this.labelTransactionDate.Name = 'labelTransactionDate';
        this.labelTransactionDate.TabIndex = 8;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = 'DescriptionAndSignTabControl';
        this.DescriptionAndSignTabControl.TabIndex = 4;
        this.DescriptionAndSignTabControl.Visible = false;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = 'SignTabpage';

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = 'StockActionSignDetails';
        this.StockActionSignDetails.TabIndex = 0;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = 'SignUserTypeEnum';
        this.SignUserType.DataMember = 'SignUserType';
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = 'SignUserType';
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = 'UserListDefinition';
        this.SignUser.DataMember = 'SignUser';
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = 'SignUser';
        this.SignUser.Width = 400;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = 'IsDeputy';
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = 'IsDeputy';
        this.IsDeputy.Width = 50;

        this.DescriptionTabpage = new TTVisual.TTTabPage();
        this.DescriptionTabpage.DisplayIndex = 1;
        this.DescriptionTabpage.TabIndex = 0;
        this.DescriptionTabpage.Text = i18n("M10469", "Açıklama");
        this.DescriptionTabpage.Name = 'DescriptionTabpage';

        this.MKYS_CikisStokHareketTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisStokHareketTuru.DataTypeName = 'MKYS_ECikisStokHareketTurEnum';
        this.MKYS_CikisStokHareketTuru.Required = true;
        this.MKYS_CikisStokHareketTuru.BackColor = '#F0F0F0';
        this.MKYS_CikisStokHareketTuru.Enabled = false;
        this.MKYS_CikisStokHareketTuru.Name = 'MKYS_CikisStokHareketTuru';
        this.MKYS_CikisStokHareketTuru.TabIndex = 128;

        this.MKYS_CikisIslemTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisIslemTuru.DataTypeName = 'MKYS_ECikisIslemTuruEnum';
        this.MKYS_CikisIslemTuru.Required = true;
        this.MKYS_CikisIslemTuru.BackColor = '#F0F0F0';
        this.MKYS_CikisIslemTuru.Enabled = false;
        this.MKYS_CikisIslemTuru.Name = 'MKYS_CikisIslemTuru';
        this.MKYS_CikisIslemTuru.TabIndex = 124;

        this.lblMKYS_CikisIslemTuru = new TTVisual.TTLabel();
        this.lblMKYS_CikisIslemTuru.Text = i18n("M16895", "İşlem Türü");
        this.lblMKYS_CikisIslemTuru.Name = 'lblMKYS_CikisIslemTuru';
        this.lblMKYS_CikisIslemTuru.TabIndex = 125;

        this.lblMKYS_CikisStokHareketTuru = new TTVisual.TTLabel();
        this.lblMKYS_CikisStokHareketTuru.Text = i18n("M22325", "Stok Hareket Türü");
        this.lblMKYS_CikisStokHareketTuru.Name = 'lblMKYS_CikisStokHareketTuru';
        this.lblMKYS_CikisStokHareketTuru.TabIndex = 129;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 129;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = 'TA';
        this.TTTeslimAlanButon.Name = 'TTTeslimAlanButon';
        this.TTTeslimAlanButon.TabIndex = 120;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = 'TE';
        this.TTTeslimEdenButon.Name = 'TTTeslimEdenButon';
        this.TTTeslimEdenButon.TabIndex = 121;

        this.AutoDistributionButton = new TTVisual.TTButton();
        this.AutoDistributionButton.Text = i18n("M17871", "Kritik Seviyedeki Malzemeleri Getir");
        this.AutoDistributionButton.Name = 'AutoDistributionButton';
        this.AutoDistributionButton.TabIndex = 121;

        // this.DistributionDocumentMaterialsColumns = [this.Detail, this.MaterialDistributionDocumentMaterial,
        // this.Barcode, this.DistributionType, this.AcceptedAmountDistributionDocumentMaterial, this.AmountDistributionDocumentMaterial,
        // this.StoreInheld, this.StockLevelTypeDistributionDocumentMaterial, this.UnitPrice, this.Price, this.StatusDistributionDocumentMaterial];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy, this.AcceptedAmountDistributionDocumentMaterial];
        this.DistributionDocumentMaterialsTabcontrol.Controls = [this.DistributionDocumentMaterialsTabpage];
        this.DistributionDocumentMaterialsTabpage.Controls = [this.DistributionDocumentMaterials];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage, this.DescriptionTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.ChooseProductsFromTheTree, this.labelMKYS_TeslimEden, this.MKYS_TeslimEden, this.MKYS_TeslimAlan,
        this.Description, this.labelMKYS_TeslimAlan, this.labelStore, this.Store, this.labelDestinationStore, this.DestinationStore,
        this.DistributionDocumentMaterialsTabcontrol, this.DistributionDocumentMaterialsTabpage, this.DistributionDocumentMaterials,
        this.Detail, this.MaterialDistributionDocumentMaterial, this.Barcode, this.DistributionType, this.AcceptedAmountDistributionDocumentMaterial,
        this.AmountDistributionDocumentMaterial, this.StoreInheld, this.StockLevelTypeDistributionDocumentMaterial, this.UnitPrice, this.Price,
        this.StatusDistributionDocumentMaterial, this.StockActionID, this.TransactionDate, this.labelStockActionID, this.labelTransactionDate,
        this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy,
        this.DescriptionTabpage, this.MKYS_CikisStokHareketTuru, this.MKYS_CikisIslemTuru, this.lblMKYS_CikisIslemTuru,
        this.lblMKYS_CikisStokHareketTuru, this.ttlabel1, this.TTTeslimAlanButon, this.TTTeslimEdenButon, this.AutoDistributionButton];
    }
}
