//$707429DD
import { Component, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { ReturningDocumentFormViewModel } from './ReturningDocumentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseReturningDocumentForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Iade_Belgesi_Modulu/BaseReturningDocumentForm";
import { MainStoreDefinition, TransactionTypeEnum, StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_EMalzemeGrupEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ReturningDocument } from 'NebulaClient/Model/AtlasClientModel';
import { ReturningDocumentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { SelectStoreUsageEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { SubStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';

import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { MKYS_ETedarikTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_EAlimYontemiEnum } from 'NebulaClient/Model/AtlasClientModel';



import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { OpenStockActionDetailOutput_Input, GetOuttableLots_Output } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { OuttableLotDTO } from '../Tasinir_Mal_Islem_Modulu/ChattelDocumentOutputWithAccountancyNewFormViewModel';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { MaterialSelectorInput, NewMaterialService } from 'app/Logistic/Views/NewMaterialSelectComponent';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';

@Component({
    selector: 'ReturningDocumentForm',
    templateUrl: './ReturningDocumentForm.html',
    providers: [MessageService]
})
export class ReturningDocumentForm extends BaseReturningDocumentForm implements OnInit {
    // public StockActionOutDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public stockActionOrderNoCount: number = 0;
    public MaterialInput: MaterialSelectorInput = new MaterialSelectorInput();
    public returningDocumentFormViewModel: ReturningDocumentFormViewModel = new ReturningDocumentFormViewModel();
    public get _ReturningDocument(): ReturningDocument {
        return this._TTObject as ReturningDocument;
    }
    private ReturningDocumentForm_DocumentUrl: string = '/api/ReturningDocumentService/ReturningDocumentForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private changeDetectorRef: ChangeDetectorRef,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ReturningDocumentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async BarcodeRead(value: string): Promise<void> {
        super.BarcodeRead(value);
        /*let barcode: string = (await CommonService.PrepareBarcode(value));
        let material: Material = null;
        let materials: Array<any> = this._ReturningDocument.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + barcode + "'");
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
            let retAmount: string = TTVisual.InputForm.GetText("İade Edilecek Miktarı Giriniz.");
            let amount: Currency = 0;
            if (String.isNullOrEmpty(retAmount) === false) {
                if (CurrencyType.TryConvertFrom(retAmount, false, amount) === false)
                    throw new TTException((await SystemMessageService.GetMessageV3(1192, [retAmount.toString()])));
            }
            let returningDocument: ReturningDocumentMaterial = this._ReturningDocument.ReturningDocumentMaterials.AddNew();
            returningDocument.Material = material;
            returningDocument.RequireAmount = amount;
            returningDocument.Amount = amount;
            returningDocument.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
        }*/
    }

    async getDetail_CellContentClicked(data: any) {

        if (data.data == null) {
            ServiceLocator.MessageService.showInfo('Malzeme seçmediniz.');
            return;
        }
        if (this._ReturningDocument.Store == null) {
            ServiceLocator.MessageService.showInfo('Depo seçmediniz.');
            return;
        }
        if (data.data.Amount == null) {
            ServiceLocator.MessageService.showInfo('Miktar girmediniz.');
            return;
        }
        let inputParam: OpenStockActionDetailOutput_Input = new OpenStockActionDetailOutput_Input();
        inputParam.MaterialID = data.data.Material.ObjectID;
        inputParam.StoreID = this._ReturningDocument.Store.ObjectID;
        inputParam.MaterialName = data.data.Material.Name;
        inputParam.RequestAmount = data.data.Amount;
        inputParam.Barcode = data.data.Material.Barcode;
        inputParam.DistributionTypeName = data.data.Material.DistributionTypeName;
        if (this.returningDocumentFormViewModel.OuttableLotList != null)
            inputParam.selectedOuttableLots = this.returningDocumentFormViewModel.OuttableLotList.filter(x => x.StockActionDetailOrderNo === data.data.ChattelDocDetailOrderNo);
        else
            inputParam.selectedOuttableLots = new Array<OuttableLotDTO>();
        this.showStockActionDetailOutForm(inputParam).then(res => {
            let modalActionResult = res as ModalActionResult;
            if (modalActionResult.Result === DialogResult.OK) {
                this.returningDocumentFormViewModel.OuttableLotList = this.returningDocumentFormViewModel.OuttableLotList.
                    filter(x => x.StockActionDetailOrderNo !== data.data.ChattelDocDetailOrderNo);
                let outtableLots = res.Param as Array<GetOuttableLots_Output>;
                this.stockActionOrderNoCount = this.stockActionOrderNoCount + 1;
                data.data.ChattelDocDetailOrderNo = this.stockActionOrderNoCount;
                data.data.UserSelectedOutableTrx = true;
                for (let outTRX of outtableLots) {
                    let outtableLot: OuttableLotDTO = new OuttableLotDTO();
                    outtableLot.Amount = outTRX.RestAmount;
                    outtableLot.BudgetTypeName = outTRX.BudgetTypeName;
                    outtableLot.ExpirationDate = outTRX.ExpirationDate;
                    outtableLot.LotNo = outTRX.LotNo;
                    outtableLot.RestAmount = outTRX.RestAmount;
                    outtableLot.SerialNo = outTRX.SerialNo;
                    outtableLot.TrxObjectID = outTRX.TrxObjectID;
                    outtableLot.StockActionDetailOrderNo = this.stockActionOrderNoCount;
                    this.returningDocumentFormViewModel.OuttableLotList.push(outtableLot);
                }
            }
        });
    }

    private showStockActionDetailOutForm(data: OpenStockActionDetailOutput_Input): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'StockActionDetailOutForm';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Çıkılabilir Girişler';
            modalInfo.Width = 800;
            modalInfo.Height = 500;
            modalInfo.IsShowCloseButton = false;

            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        if (this._ReturningDocument.MKYS_EMalzemeGrup == null) {
            let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            mSelectForm.AddMSItem(i18n("M23417", "Tıbbi Sarf"), i18n("M23417", "Tıbbi Sarf"), MKYS_EMalzemeGrupEnum.tibbiSarf);
            mSelectForm.AddMSItem(i18n("M16287", "İlaç"), i18n("M16287", "İlaç"), MKYS_EMalzemeGrupEnum.ilac);
            mSelectForm.AddMSItem(i18n("M23359", "Tıbbi Cihaz"), i18n("M23359", "Tıbbi Cihaz"), MKYS_EMalzemeGrupEnum.tibbiCihaz);
            mSelectForm.AddMSItem(i18n("M12780", "Diğer"), i18n("M12780", "Diğer"), MKYS_EMalzemeGrupEnum.diger);
            let mkey: string = await mSelectForm.GetMSItem(this, i18n("M14806", "Giriş Yapılacak Malzeme Grubunu Seçiniz"), true);
            if (String.isNullOrEmpty(mkey))
                this.messageService.showError(i18n("M18579", "Malzeme grubu seçilmeden işleme devam edemezsiniz."));
            //throw new TTException("Malzeme grubu seçilmeden işleme devam edemezsiniz.");
            this._ReturningDocument.MKYS_EMalzemeGrup = <MKYS_EMalzemeGrupEnum>mSelectForm.MSSelectedItemObject;
        }
        if (this._ReturningDocument.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.tibbiSarf)
            this.Material.ListFilterExpression = "OBJECTDEFID ='58d34696-808e-47de-87e0-1f001d0928a7'  AND  MKYSMALZEMEKODU IS NOT NULL";
        if (this._ReturningDocument.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.ilac)
            this.Material.ListFilterExpression = "OBJECTDEFID ='65a2337c-bc3c-4c6b-9575-ad47fa7a9a89'  AND  MKYSMALZEMEKODU IS NOT NULL";
        if (this._ReturningDocument.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.tibbiCihaz)
            this.Material.ListFilterExpression = "OBJECTDEFID ='f38f2111-0ee4-4b9f-9707-a63ac02d29f4'  AND  MKYSMALZEMEKODU IS NOT NULL";
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        await super.PostScript(transDef);
        //this._ReturningDocument.CheckStockCardCardNofCount(30);
    }

    inputStore: Store;
    public setInputParam(value: Store) {
        if (value != null) {
            if (value.ObjectDefID.toString() === SubStoreDefinition.ObjectDefID.id)
                this.inputStore = value;
        }
    }

    protected async PreScript() {
        await super.PreScript();

        this.DropStateButton(ReturningDocument.ReturningDocumentStates.Completed);

        if (this._ReturningDocument.Store == null) {
            this._ReturningDocument.Store = this.inputStore;
            await this.SelectStoreUsage(SelectStoreUsageEnum.UseUserResources, SelectStoreUsageEnum.UseMainStores);
        }

        this._ReturningDocument.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.iadeEdilen;
        this._ReturningDocument.MKYS_EAlimYontemi = MKYS_EAlimYontemiEnum.bos;
        if (this._ReturningDocument.CurrentStateDefID.toString() === ReturningDocument.ReturningDocumentStates.New.id)
            this.Material.ListFilterExpression += " AND STOCKS.STORE= '" + this._ReturningDocument.Store.ObjectID + "' AND STOCKS.INHELD > 0";
        if (this._ReturningDocument.Store instanceof MainStoreDefinition) {
            this._ReturningDocument.MKYS_TeslimEden = (<MainStoreDefinition>this._ReturningDocument.Store).GoodsAccountant.Name;
            this._ReturningDocument.MKYS_TeslimEdenObjID = (<MainStoreDefinition>this._ReturningDocument.Store).GoodsAccountant.ObjectID;
        }
        if (this._ReturningDocument.DestinationStore instanceof SubStoreDefinition) {
            this._ReturningDocument.MKYS_TeslimAlan = (<SubStoreDefinition>this._ReturningDocument.DestinationStore).StoreResponsible.Name;
            this._ReturningDocument.MKYS_TeslimAlanObjID = (<SubStoreDefinition>this._ReturningDocument.DestinationStore).StoreResponsible.ObjectID;
        }

        this.MaterialInput.MaterialGroup = MKYS_EMalzemeGrupEnum.diger;
        this.MaterialInput.TransactionType = TransactionTypeEnum.Out;
        this.MaterialInput.StoreID = this._ReturningDocument.Store.ObjectID;
        this.MaterialInput.DestinationStoreID = this._ReturningDocument.DestinationStore.ObjectID;
        this.MaterialInput.TicketDate = this._ReturningDocument.TransactionDate;
        /* if (_ReturningDocument.StockActionSignDetails.Count == 0)
         {
             StockActionSignDetail stockActionSignDetail = _ReturningDocument.StockActionSignDetails.AddNew();
             stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimEden;
             if (_ReturningDocument.Store is MainStoreDefinition)
                 stockActionSignDetail.SignUser = ((MainStoreDefinition)_ReturningDocument.Store).GoodsAccountant;

             stockActionSignDetail = _ReturningDocument.StockActionSignDetails.AddNew();
             stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimAlan;
             if (_ReturningDocument.DestinationStore is SubStoreDefinition)
                 stockActionSignDetail.SignUser = ((SubStoreDefinition)_ReturningDocument.DestinationStore).StoreResponsible;
         }*/



        // this.ChooseProductsFromTheTree.Visible = false;
        /* if ((await SystemParameterService.GetSite()).ObjectID === Sites.SiteOrduIlac) {
             //DescriptionAndSignTabControl.Size = new Size(DescriptionAndSignTabControl.Size.Width - ChooseProductsFromTheTree.Size.Width - 10, DescriptionAndSignTabControl.Size.Height);
             ChooseProductsFromTheTree.Visible = true;
         }*/
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ReturningDocument();
        this.returningDocumentFormViewModel = new ReturningDocumentFormViewModel();
        this._ViewModel = this.returningDocumentFormViewModel;
        this.returningDocumentFormViewModel._ReturningDocument = this._TTObject as ReturningDocument;
        this.returningDocumentFormViewModel._ReturningDocument.Store = new Store();
        this.returningDocumentFormViewModel._ReturningDocument.DestinationStore = new Store();
        this.returningDocumentFormViewModel._ReturningDocument.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.returningDocumentFormViewModel._ReturningDocument.ReturningDocumentMaterials = new Array<ReturningDocumentMaterial>();
    }

    protected loadViewModel() {
        let that = this;

        that.returningDocumentFormViewModel = this._ViewModel as ReturningDocumentFormViewModel;
        that._TTObject = this.returningDocumentFormViewModel._ReturningDocument;
        if (this.returningDocumentFormViewModel == null)
            this.returningDocumentFormViewModel = new ReturningDocumentFormViewModel();
        if (this.returningDocumentFormViewModel._ReturningDocument == null)
            this.returningDocumentFormViewModel._ReturningDocument = new ReturningDocument();
        let storeObjectID = that.returningDocumentFormViewModel._ReturningDocument["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.returningDocumentFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.returningDocumentFormViewModel._ReturningDocument.Store = store;
            }
        }
        let destinationStoreObjectID = that.returningDocumentFormViewModel._ReturningDocument["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.returningDocumentFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.returningDocumentFormViewModel._ReturningDocument.DestinationStore = destinationStore;
            }
        }
        that.returningDocumentFormViewModel._ReturningDocument.StockActionSignDetails = that.returningDocumentFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.returningDocumentFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.returningDocumentFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
        that.returningDocumentFormViewModel._ReturningDocument.ReturningDocumentMaterials = that.returningDocumentFormViewModel.StockActionOutDetailsGridList;
        for (let detailItem of that.returningDocumentFormViewModel.StockActionOutDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.returningDocumentFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.returningDocumentFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.returningDocumentFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.returningDocumentFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
    }

    public ShowNewMaterialList: boolean = false;
    async ngOnInit() {
        let that = this;
        await this.load(ReturningDocumentFormViewModel);
        if (this._ReturningDocument.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ReturningDocument.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M16052", " İade Belgesi ( Yeni )");
        this.changeDetectorRef.detectChanges();

        this.stockActionOrderNoCount = this._ReturningDocument.ReturningDocumentMaterials.filter(x => x.ChattelDocDetailOrderNo != null).length

        if (this.returningDocumentFormViewModel.OuttableLotList == null) {
            this.returningDocumentFormViewModel.OuttableLotList = new Array<OuttableLotDTO>();
        }

        let listParameter: string = (await SystemParameterService.GetParameterValue('SHOWNEWMATERIALLIST', 'FALSE'));
        if (listParameter === "TRUE") {
            this.ShowNewMaterialList = true;
        }
        NewMaterialService.onMaterialAdd.subscribe((e) => {
            for (let item of e) {
                if (!this._ReturningDocument.ReturningDocumentMaterials.find(x => x.Material.ObjectID == this.selectedMaterial.ObjectID)) {
                    let newRow: ReturningDocumentMaterial = new ReturningDocumentMaterial();
                    newRow.Material = item.Material;
                    newRow.Material.StockCard = item.StockCard;
                    newRow.StockLevelType = item.StockLevelType;
                    newRow.Status = StockActionDetailStatusEnum.New;
                    newRow.StoreStock = item.StoreStock;
                    this._ReturningDocument.ReturningDocumentMaterials.push(newRow);
                } else
                    ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
            }
        });
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







    public async StockActionOutDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.StockActionOutDetails_CellValueChanged(data, rowIndex, columnIndex);
    }



    //<this.StockActionOutDetail gridde kullanılıyordu
    //onCellContentClicked(data: any) {
    //}
    //StockActionOutDetails_CellValueChangedEmitted(data: any) {
    //    if (data && this.StockActionOutDetails_CellValueChanged && data.Row && data.Column) {
    //        this.StockActionOutDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
    //    }
    //}
    //async initNewRow(data: any) {
    //}
    //async onRowInserting(data: ReturningDocumentMaterial) {
    //}
    //onSelectionChange(data: any) {

    //}
    //this.StockActionOutDetail gridde kullanılıyordu >




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
        //this.StockActionOutDetails = new TTVisual.TTGrid();
        //this.StockActionOutDetails.Required = true;
        //this.StockActionOutDetails.BackColor = "#FFE3C6";
        //this.StockActionOutDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.StockActionOutDetails.Name = "StockActionOutDetails";
        //this.StockActionOutDetails.TabIndex = 0;
        //this.StockActionOutDetails.Height = 350;

        //this.Detail = new TTVisual.TTButtonColumn();
        //this.Detail.Text = i18n("M12671", "Detay");
        //this.Detail.UseColumnTextForButtonValue = true;
        //this.Detail.DisplayIndex = 0;
        //this.Detail.HeaderText = "";
        //this.Detail.Name = "Detail";
        //this.Detail.ToolTipText = i18n("M12671", "Detay");
        //this.Detail.Width = 80;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.AllowMultiSelect = true;
        this.Material.ListDefName = "MaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.AutoCompleteDialogHeight = '60%';
        this.Material.AutoCompleteDialogWidth = '90%';
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M18550", "Malzeme Adı");
        this.Material.Name = "Material";
        this.Material.Width = 500;
        this.Material.ReadOnly = this.ReadOnly;


        //this.Barcode = new TTVisual.TTTextBoxColumn();
        //this.Barcode.DataMember = "Material.Barcode";
        //this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //this.Barcode.DisplayIndex = 2;
        //this.Barcode.HeaderText = "Barkod";
        //this.Barcode.Name = "Barcode";
        //this.Barcode.ReadOnly = true;
        //this.Barcode.Width = 120;

        //this.DistributionType = new TTVisual.TTTextBoxColumn();
        //this.DistributionType.DataMember = "Material.DistributionTypeName";
        //this.DistributionType.DisplayIndex = 3;
        //this.DistributionType.HeaderText = i18n("M12449", "Dağıtım Şekli");
        //this.DistributionType.Name = "DistributionType";
        //this.DistributionType.ReadOnly = true;
        //this.DistributionType.Width = 120;

        //this.Existing = new TTVisual.TTTextBoxColumn();
        //this.Existing.DataMember = "StoreStock";
        //this.Existing.Format = "N2";
        //this.Existing.Alignment = DataGridViewContentAlignment.MiddleRight;
        //this.Existing.DisplayIndex = 4;
        //this.Existing.HeaderText = i18n("M22360", "Stok Miktarı");
        //this.Existing.Name = "Existing";
        //this.Existing.ReadOnly = true;
        //this.Existing.Width = 120;
        //this.Existing.IsNumeric = true;

        //this.RequireAmount = new TTVisual.TTTextBoxColumn();
        //this.RequireAmount.DataMember = "RequireAmount";
        //this.RequireAmount.Required = true;
        //this.RequireAmount.Format = "N2";
        //this.RequireAmount.Alignment = DataGridViewContentAlignment.MiddleRight;
        //this.RequireAmount.DisplayIndex = 5;
        //this.RequireAmount.HeaderText = i18n("M16068", "İade Miktarı ");
        //this.RequireAmount.Name = "RequireAmount";
        //this.RequireAmount.Width = 120;
        //this.RequireAmount.IsNumeric = true;

        //this.Amount = new TTVisual.TTTextBoxColumn();
        //this.Amount.DataMember = "Amount";
        //this.Amount.Format = "N2";
        //this.Amount.Alignment = DataGridViewContentAlignment.MiddleRight;
        //this.Amount.DisplayIndex = 6;
        //this.Amount.HeaderText = i18n("M10707", "Alınan Miktar");
        //this.Amount.Name = "Amount";
        //this.Amount.Visible = false;
        //this.Amount.Width = 120;
        //this.Amount.IsNumeric = true;

        //this.StockLevelType = new TTVisual.TTListBoxColumn();
        //this.StockLevelType.ListDefName = "StockLevelTypeList";
        //this.StockLevelType.DataMember = "StockLevelType";
        //this.StockLevelType.DisplayIndex = 7;
        //this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        //this.StockLevelType.Name = "StockLevelType";
        //this.StockLevelType.ReadOnly = true;
        //this.StockLevelType.Width = 120;
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
        //this.StockActionOutDetailsColumns = [this.Detail, this.Material, this.Barcode, this.DistributionType, this.Existing, this.RequireAmount, this.Amount, this.StockLevelType];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage, this.DescriptionTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.tttabcontrol1.Controls = [this.MaterialTabPage];
        this.MaterialTabPage.Controls = [this.StockActionOutDetails, this.ChooseProductsFromTheTree];
        this.Controls = [this.labelMKYS_TeslimEden, this.MKYS_TeslimEden, this.MKYS_TeslimAlan, this.Description, this.StockActionID, this.labelMKYS_TeslimAlan, this.labelStore, this.Store, this.labelDestinationStore, this.DestinationStore, this.cmdHEKReport, this.labelTransactionDate, this.TransactionDate, this.labelStockActionID, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.DescriptionTabpage, this.tttabcontrol1, this.MaterialTabPage, this.StockActionOutDetails, this.Detail, this.Material, this.Barcode, this.DistributionType, this.Existing, this.RequireAmount, this.Amount, this.StockLevelType, this.ChooseProductsFromTheTree, this.MKYS_EMalzemeGrup, this.labelMKYS_EMalzemeGrup, this.ttlabel1, this.TTTeslimAlanButon, this.TTTeslimEdenButon];

    }


}
