//$6D993C8C
import { Component, ViewChild,ChangeDetectorRef, OnInit, ApplicationRef, NgZone, EventEmitter } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { MainStoreDistDocNewFormViewModel } from './MainStoreDistDocNewFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseMainStoreDistributionDocForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Ana_Depo_Dagitim_Belgesi_Modulu/BaseMainStoreDistributionDocForm";
import { MainStoreDistributionDoc, StockActionDetailStatusEnum, StockLevelTypeEnum, SelectStoreUsageEnum, DistributionDocument, MainStoreDefinition, MKYS_ECikisIslemTuruEnum, MKYS_ECikisStokHareketTurEnum, SubStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MainStoreDistDocDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';

import { StockLevelTypeService } from 'app/NebulaClient/Services/ObjectService/StockLevelTypeService';
import { DxDataGridComponent } from 'devextreme-angular';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { StockLevelService } from 'app/NebulaClient/Services/ObjectService/StockLevelService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { TTButtonTextBox } from 'app/NebulaClient/Visual/Controls/TTButtonTextBox';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { GetUnsuccessfulDistributionDocumentsInputModel, GetUnsuccessfulDistributionDocument_Class } from '../Dagitim_Belgesi_Modulu/DistributionDocumentNewFormViewModel';
import { TTUser } from 'app/NebulaClient/StorageManager/Security/TTUser';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";


@Component({
    selector: 'MainStoreDistDocNewForm',
    templateUrl: './MainStoreDistDocNewForm.html',
    providers: [MessageService]
})
export class MainStoreDistDocNewForm extends BaseMainStoreDistributionDocForm implements OnInit {
    AutoDistributionButton: TTVisual.ITTButton;
    public TagNoPopupMaterialName: string;
    public TagNoPopupVisible = false;
    public PopupTagNo: string;
    OnInserted: EventEmitter<any> = new EventEmitter<any>();
    public selectedMaterial: Material;
    public storeListFiltred: string ="";
    public selectedStockLevelType: StockLevelType;
    public stockLeveltypeArray: Array<StockLevelType> = new Array<StockLevelType>();
    public MainStoreDistDocDetailsColumns = [];
    public mainStoreDistDocNewFormViewModel: MainStoreDistDocNewFormViewModel = new MainStoreDistDocNewFormViewModel();
    public get _MainStoreDistributionDoc(): MainStoreDistributionDoc {
        return this._TTObject as MainStoreDistributionDoc;
    }
    private MainStoreDistDocNewForm_DocumentUrl: string = '/api/MainStoreDistributionDocService/MainStoreDistDocNewForm';
    constructor(protected httpService: NeHttpService,private changeDetectorRef: ChangeDetectorRef, protected messageService: MessageService,protected ngZone:NgZone) {
        super(httpService, messageService,ngZone);
        this._DocumentServiceUrl = this.MainStoreDistDocNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }
    public MainStoreDistributionDocumentMaterialsColumns = [
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
            caption: 'Gönderilecek Miktar',
            dataField: 'SendedAmount',
            dataType: 'number',
        },
        {
            caption: 'Kabul Edilen Miktar',
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

    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MainStoreDistributionDoc();
        this.mainStoreDistDocNewFormViewModel = new MainStoreDistDocNewFormViewModel();
        this._ViewModel = this.mainStoreDistDocNewFormViewModel;
        this.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc = this._TTObject as MainStoreDistributionDoc;
        this.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc.Store = new Store();
        this.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc.DestinationStore = new Store();
        this.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails = new Array<MainStoreDistDocDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.mainStoreDistDocNewFormViewModel = this._ViewModel as MainStoreDistDocNewFormViewModel;
        that._TTObject = this.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc;
        if (this.mainStoreDistDocNewFormViewModel == null)
            this.mainStoreDistDocNewFormViewModel = new MainStoreDistDocNewFormViewModel();
        if (this.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc == null)
            this.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc = new MainStoreDistributionDoc();
        let storeObjectID = that.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.mainStoreDistDocNewFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc.Store = store;
            }
        }


        let destinationStoreObjectID = that.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === "string")) {
            let destinationStore = that.mainStoreDistDocNewFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc.DestinationStore = destinationStore;
            }
        }


        that.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails = that.mainStoreDistDocNewFormViewModel.MainStoreDistDocDetailsGridList;
        for (let detailItem of that.mainStoreDistDocNewFormViewModel.MainStoreDistDocDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.mainStoreDistDocNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;

                }

                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.mainStoreDistDocNewFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;

                        }

                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.mainStoreDistDocNewFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.mainStoreDistDocNewFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
    }

    async ngOnInit() {
        await this.load(MainStoreDistDocNewFormViewModel);
        this.FormCaption = i18n("M124381", "Ana Depo Dağıtım Belgesi ( Yeni )");
        this.changeDetectorRef.detectChanges();
    }
    NewFormCancel() {
        super.cancel();
    }

    private showMaterialMultiSelectForm: boolean = false;
    OpenMaterialMultiSelectComponent() {
        if( this._MainStoreDistributionDoc.Store!=null)
        {
            this.storeListFiltred = this._MainStoreDistributionDoc.Store.ObjectID.toString();
            this.showMaterialMultiSelectForm = true;
        }
    
        else
        ServiceLocator.MessageService.showError("Gönderen Depoyu Seçiniz!!");
    }
    async MaterialsSelected(event) {
        this.showMaterialMultiSelectForm = false;
        let selectedMaterials = event;

        for (var i = 0; i < selectedMaterials.length; i++) {
            let element = selectedMaterials[i];

            let mainStoreDistributionDocumentMaterial: MainStoreDistDocDetail = new MainStoreDistDocDetail();
            mainStoreDistributionDocumentMaterial.Material = element;
            mainStoreDistributionDocumentMaterial.TagNo = "";
            mainStoreDistributionDocumentMaterial.Material.DistributionTypeName = element.Distributiontypename;
            if (element.Inheld != null) {
                mainStoreDistributionDocumentMaterial.StoreStock = Number.parseInt(element.Inheld);
            }

            mainStoreDistributionDocumentMaterial.Status = StockActionDetailStatusEnum.New;
            this.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails.push(mainStoreDistributionDocumentMaterial);
            if (mainStoreDistributionDocumentMaterial.Material.IsTagNoRequired) {
                let a = await this.GetTagNo(mainStoreDistributionDocumentMaterial.Material.Name);
            }
        }


        let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this._MainStoreDistributionDoc.MainStoreDistDocDetails.forEach(element => {
            element.StockLevelType = stockLeveltypeArray[0];
        });

       // this._MainStoreDistributionDoc.IsAutoDistribution = true;
      //  this.AutoDistributionButton.Enabled = false;
      //  this.AutoDistributionButton.ReadOnly = true;

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


    public async materialGridRowUpdating(event: any) {
        if (event.newData.SendedAmount != null) {
            if (!isNaN(event.newData.SendedAmount)) {
                if (event.newData.SendedAmount > event.oldData.StoreStock) {
                    ServiceLocator.MessageService.showError(i18n("", "Dağıtılan Miktar Depo Mevcudunu aşamaz!"));
                    event.cancel = true;
                }
                else
                    event.oldData.Amount = event.newData.SendedAmount;
            }
        }
        if (event.newData.TagNo != null) {
            event.oldData.TagNo = event.newData.TagNo;
        }
       
    }

    public async setStoreStock(mainStoreDistributionDocumentMaterial: MainStoreDistDocDetail): Promise<any> {
        if (mainStoreDistributionDocumentMaterial.Status === undefined) {
            mainStoreDistributionDocumentMaterial.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            mainStoreDistributionDocumentMaterial.StockLevelType = stockLeveltypeArray[0];
        }
        if (mainStoreDistributionDocumentMaterial.Material.ObjectID != null) {
            let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(mainStoreDistributionDocumentMaterial.Material.ObjectID, this._MainStoreDistributionDoc.Store.ObjectID, mainStoreDistributionDocumentMaterial.StockLevelType.ObjectID);
            mainStoreDistributionDocumentMaterial.StoreStock = stockInheld;
        }

        if (mainStoreDistributionDocumentMaterial.Material.ObjectID != null) {
            let stockInheldSubStore: number = await StockLevelService.StockInheldWithStockLevel(mainStoreDistributionDocumentMaterial.Material.ObjectID, this._MainStoreDistributionDoc.DestinationStore.ObjectID, mainStoreDistributionDocumentMaterial.StockLevelType.ObjectID);
            mainStoreDistributionDocumentMaterial.DestinationStoreStock = stockInheldSubStore;
        }
        
    }

    public async onMaterialSelectionChange(event: any) {
        if (this.stockLeveltypeArray.length == 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
        if (this.selectedMaterial == null)
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        else
            if (!this._MainStoreDistributionDoc.MainStoreDistDocDetails.find(x => x.Material.ObjectID == this.selectedMaterial.ObjectID && x.EntityState != EntityStateEnum.Deleted)) {
                let newRow: MainStoreDistDocDetail = new MainStoreDistDocDetail();
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
                this.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails.push(newRow);
            }
            else
                ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
    }


   

    @ViewChild('mainStoreDistributionDocumentNewFormMaterialGrid') mainStoreDistributionDocumentNewFormMaterialGrid: DxDataGridComponent;
    async mainStoreDistributionDocumentNewFormMaterialGrid_CellContentClicked(data: any) {
        let that = this;
        if (this.ReadOnly != true) {
            if (data.column.name = "RowDelete") {
                if (data.row != null) {
                    if (data.row.key != null) {
                        if (data.row.key.IsNew == null) {
                            this.mainStoreDistributionDocumentNewFormMaterialGrid.instance.deleteRow(data.rowIndex);
                        }
                        else {
                            if (data.row.key.IsNew) {
                                this.mainStoreDistributionDocumentNewFormMaterialGrid.instance.deleteRow(data.rowIndex);
                            }
                            else {
                                data.key.EntityState = EntityStateEnum.Deleted;
                                this.mainStoreDistributionDocumentNewFormMaterialGrid.instance.filter(['EntityState', '<>', 1]);
                                this.mainStoreDistributionDocumentNewFormMaterialGrid.instance.refresh();
                            }
                        }
                    }
                }
            }
        }
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

            if (this._MainStoreDistributionDoc.Store == null) {
                this._MainStoreDistributionDoc.DestinationStore = this.inputStore;
                await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStores, SelectStoreUsageEnum.UseUserResources);
                let result = null;
                let UnsuccessfulDistributionDocuments: string = (await SystemParameterService.GetParameterValue('UNSUCCESSDISTDOC', 'FALSE'));
              
                //UnsuccessfulDistributionDocuments bize lazım mı değil mi bi bak!!!!!
              
                if (UnsuccessfulDistributionDocuments === 'TRUE') {
                    let apiUrlForPASearchUrl: string = '/api/DistributionDocumentService/GetUnsuccessfulDistributionDocuments';
                    let param: GetUnsuccessfulDistributionDocumentsInputModel = new GetUnsuccessfulDistributionDocumentsInputModel();
                    param.StoreId = this._MainStoreDistributionDoc.DestinationStore.ObjectID;
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

                    if (this._MainStoreDistributionDoc.Store == null) {
                        this._MainStoreDistributionDoc.DestinationStore = this.inputStore;
                        await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStores, SelectStoreUsageEnum.UseUserResources);
                    }

                    this.MaterialDistributionDocumentMaterial.ListFilterExpression = ' STOCKS.STORE=\'' + this._MainStoreDistributionDoc.Store.ObjectID + '\' AND STOCKS.INHELD > 0 AND ( ShowZeroOnDistributionInfo IS NULL OR ShowZeroOnDistributionInfo = 0 )';
                    if (this._MainStoreDistributionDoc.Store instanceof MainStoreDefinition) {
                        this._MainStoreDistributionDoc.MKYS_TeslimEden = (<MainStoreDefinition>this._MainStoreDistributionDoc.Store).GoodsAccountant.Name;
                        this._MainStoreDistributionDoc.MKYS_TeslimEdenObjID = (<MainStoreDefinition>this._MainStoreDistributionDoc.Store).GoodsAccountant.ObjectID;
                    }
                    this._MainStoreDistributionDoc.MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.cikis;
                    this._MainStoreDistributionDoc.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckTuketim;
                    if (this._MainStoreDistributionDoc.DestinationStore instanceof SubStoreDefinition) {
                        this._MainStoreDistributionDoc.MKYS_TeslimAlan = (<SubStoreDefinition>this._MainStoreDistributionDoc.DestinationStore).StoreResponsible.Name;
                        this._MainStoreDistributionDoc.MKYS_TeslimAlanObjID = (<SubStoreDefinition>this._MainStoreDistributionDoc.DestinationStore).StoreResponsible.ObjectID;
                    }

                    this._MainStoreDistributionDoc.MKYS_TeslimAlan = TTUser.CurrentUser.Name;
                    this._MainStoreDistributionDoc.MKYS_TeslimAlanObjID = TTUser.CurrentUser.UserObject.ObjectID;


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


    public async stateChange(event: FormSaveInfo) {
        if (this.preventNewForm) {
            ServiceLocator.MessageService.showError(this.resultMessage);
            return;
        }
        let IsTagNoEmpty = false;
        for (var i = 0; i < this.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails.length; i++)
            if (this.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails[i].Material.IsTagNoRequired && (this.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails[i].TagNo == "" || this.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails[i].TagNo == null)) {
                TTVisual.InfoBox.Alert(this.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails[i].Material.Name + " malzemesi için Künye Numarası girmeniz gerekmektedir !");
                IsTagNoEmpty = true;
                return;
            }

        if (!IsTagNoEmpty) {
            if (event.transDef.ToStateDefID.valueOf() === MainStoreDistributionDoc.MainStoreDistributionDocStates.Approval.id) {
                this.mainStoreDistributionDocumentNewFormMaterialGrid.instance.closeEditCell();
                this.mainStoreDistributionDocumentNewFormMaterialGrid.instance.saveEditData();
                let isAmountEligable = true;
                this.mainStoreDistDocNewFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails.forEach(element => {
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

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        //this.MKYS_TeslimEden.BackColor = '#FFE3C6';
        this.MKYS_TeslimAlan.Name = 'TTTeslimAlanButon';
        this.MKYS_TeslimAlan.TabIndex = 138;


        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        //this.MKYS_TeslimEden.BackColor = '#FFE3C6';
        this.MKYS_TeslimEden.Name = 'TTTeslimEdenButon';
        this.MKYS_TeslimEden.TabIndex = 138;


        this.MainStoreDistDocDetailsColumns = [this.Detail, this.MaterialDistributionDocumentMaterial, this.Barcode, this.DistributionType, this.SendedAmountDistributionDocumentMaterial, this.AmountDistributionDocumentMaterial, this.StoreInheld, this.StockLevelTypeDistributionDocumentMaterial, this.UnitPrice, this.Price, this.StatusDistributionDocumentMaterial];
        this.DistributionDocumentMaterialsTabcontrol.Controls = [this.DistributionDocumentMaterialsTabpage];
        this.DistributionDocumentMaterialsTabpage.Controls = [this.MainStoreDistDocDetails];
        this.Controls = [this.labelDescription, this.Description, this.StockActionID, this.labelStore, this.Store, this.labelDestinationStore, this.DestinationStore, this.labelTransactionDate, this.TransactionDate, this.labelStockActionID, this.DistributionDocumentMaterialsTabcontrol, this.DistributionDocumentMaterialsTabpage, this.MainStoreDistDocDetails, this.Detail, this.MaterialDistributionDocumentMaterial, this.Barcode, this.DistributionType, this.SendedAmountDistributionDocumentMaterial, this.AmountDistributionDocumentMaterial, this.StoreInheld, this.StockLevelTypeDistributionDocumentMaterial, this.UnitPrice, this.Price, this.StatusDistributionDocumentMaterial, this.ttlabel2, this.tttextbox2, this.tttextbox3, this.ttlabel3, this.MKYS_TeslimAlan, this.MKYS_TeslimEden];

    }


}
