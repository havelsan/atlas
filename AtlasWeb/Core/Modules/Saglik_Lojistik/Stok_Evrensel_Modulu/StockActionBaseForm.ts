//$006294E8
import { Component, OnInit, NgZone } from '@angular/core';
import { StockActionBaseFormViewModel } from "./StockActionBaseFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/ActionForm";
import { Exception } from "NebulaClient/Mscorlib/Exception";
import { MainStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MainStoreDefinitionService } from "ObjectClassService/MainStoreDefinitionService";
import { PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PharmacyStoreDefinitionService } from "ObjectClassService/PharmacyStoreDefinitionService";
import { ProductionConsumptionDocument } from 'NebulaClient/Model/AtlasClientModel';
import { RoomStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RoomStoreDefinitionService } from "ObjectClassService/RoomStoreDefinitionService";
import { SelectStoreUsageEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockAction } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockMethodEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { TentativeStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TentativeStoreDefinitionService } from "ObjectClassService/TentativeStoreDefinitionService";
import { TTException } from "NebulaClient/Utils/Exceptions/TTException";
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { UnitStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { UserHelper } from "app/Helper/UserHelper";



@Component({
    selector: 'StockActionBaseForm',
    templateUrl: './StockActionBaseForm.html',
    providers: [MessageService]
})
export class StockActionBaseForm extends ActionForm implements OnInit {
    public stockActionBaseFormViewModel: StockActionBaseFormViewModel = new StockActionBaseFormViewModel();
    public get _StockAction(): StockAction {
        return this._TTObject as StockAction;
    }
    private StockActionBaseForm_DocumentUrl: string = '/api/StockActionService/StockActionBaseForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.StockActionBaseForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    public initViewModel(): void {
        this._TTObject = new StockAction();
        this.stockActionBaseFormViewModel = new StockActionBaseFormViewModel();
        this._ViewModel = this.stockActionBaseFormViewModel;
        this.stockActionBaseFormViewModel._StockAction = this._TTObject as StockAction;
    }

    protected loadViewModel() {
        let that = this;
        that.stockActionBaseFormViewModel = this._ViewModel as StockActionBaseFormViewModel;
        that._TTObject = this.stockActionBaseFormViewModel._StockAction;
        if (this.stockActionBaseFormViewModel == null)
            this.stockActionBaseFormViewModel = new StockActionBaseFormViewModel();
        if (this.stockActionBaseFormViewModel._StockAction == null)
            this.stockActionBaseFormViewModel._StockAction = new StockAction();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(StockActionBaseFormViewModel);
        this.redirectProperties();
  
    }


    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
    }
    protected async CheckExpirationDateRequired(): Promise<void> {
        let errorMessage: string = "";
        for (let stockActionDetailIn of this._StockAction.StockActionInDetails) {
            if (stockActionDetailIn.Material.StockCard.StockMethod === StockMethodEnum.ExpirationDated && stockActionDetailIn.ExpirationDate !== null)
                errorMessage += stockActionDetailIn.Material.StockCard.NATOStockNO + " " + stockActionDetailIn.Material.Name + "\r\n";
        }
        if (String.isNullOrEmpty(errorMessage) === false)
            throw new Exception(await SystemMessageService.GetMessageV3(1235, [errorMessage.toString()]));
    }
    protected async CheckLotNoRequired(): Promise<void> {
        let errorMessage: string = "";
        for (let stockActionDetailIn of this._StockAction.StockActionInDetails) {
            if (stockActionDetailIn.Material.StockCard.StockMethod === StockMethodEnum.LotUsed && String.isNullOrEmpty(stockActionDetailIn.LotNo))
                errorMessage += stockActionDetailIn.Material.StockCard.NATOStockNO + " " + stockActionDetailIn.Material.Name + "\r\n";
        }
        if (String.isNullOrEmpty(errorMessage) === false)
            throw new Exception(i18n("M11193", "Aşağıdaki malzemelere Lot numarası girilmesi zorunludur.\r\n") + errorMessage);
    }
    protected async CheckWhetherTheInventoryOfMaterial(rowIndex: number, columnIndex: number, controlledGrid: TTVisual.ITTGrid): Promise<void> {

    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
        if (transDef !== null) {
            //                if (_StockAction.StockActionInDetails.Count > 0)
            //                {
            //                    if (_StockAction is IChattelDocumentInputWithAccountancy || _StockAction is IChattelDocumentWithPurchase || _StockAction is ICensusFixed || _StockAction is IConsignedCensusFixed)
            //                    {
            //                        CheckExpirationDateRequired();
            //                        CheckLotNoRequired() ;
            //                    }
            //                }

            let errMsg: string = "\"\"";
            if (this._StockAction.StockActionDetails != null) {
                for (let stockActionDetail of this._StockAction.StockActionDetails) {
                    if (stockActionDetail.Material !== null) {
                        if (stockActionDetail.Material.StockCard === null)
                            errMsg += "\r\n" + stockActionDetail.Material.Name;
                    }
                }
                if (String.isNullOrEmpty(errMsg) === false)
                    throw new Exception(await SystemMessageService.GetMessageV3(1234, [errMsg.toString()]));
            }
        }
    }
    protected async PreScript() {
        super.PreScript();
        /* if (TTObjectClasses.SystemParameter.IsWorkWithOutStock === true) {
             if (this._StockAction instanceof KSchedule === false)
                 throw new Exception(await SystemMessageService.GetMessage(1233));
         }*/
    }
    public async SelectStoreUsage(storeUsageEnum: SelectStoreUsageEnum, destinationStoreUsageEnum: SelectStoreUsageEnum): Promise<void> {
        if (this._StockAction.Store == null) {
            switch (storeUsageEnum) {
                case SelectStoreUsageEnum.Nothing:
                    this._StockAction.Store = null;
                    break;
                case SelectStoreUsageEnum.UseTentativeStoreResources:
                    let selectableTentativeStores: Array<TentativeStoreDefinition> = await UserHelper.UseTentativeStoreResources;
                    if (selectableTentativeStores.length === 1) {
                        this._StockAction.Store = selectableTentativeStores[0];
                    }
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let tentativeStore of selectableTentativeStores) { mSelectForm.AddMSItem(tentativeStore.Name, tentativeStore.ObjectID.toString(), tentativeStore); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16426", "İlgili Muvakkat Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(369, i18n("M16946", "İşlemin yapılacağı muvakkat depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.Store = mSelectForm.MSSelectedItemObject as TentativeStoreDefinition;
                    }
                    break;
                case SelectStoreUsageEnum.UseTentativeStores:
                    let tentativeStores: Array<any> = await TentativeStoreDefinitionService.GetAllTentativeStores();
                    if (tentativeStores.length === 0)
                        throw new TTException(await SystemMessageService.GetMessageV2(370, i18n("M16945", "İşlemin yapılacağı muvakkat depo bulunamadığından işleme devam edemezsiniz.")));
                    if (tentativeStores.length === 1) {
                        this._StockAction.Store = <TentativeStoreDefinition>tentativeStores[0];
                    }
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let tentativeStore of tentativeStores) { mSelectForm.AddMSItem(tentativeStore.Name, tentativeStore.ObjectID.toString(), tentativeStore); }
                        let mkey: string = await mSelectForm.GetMSItem(this, "İlgili  Muvakkat Depoyu Seçiniz", true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(369, i18n("M16946", "İşlemin yapılacağı muvakkat depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.Store = mSelectForm.MSSelectedItemObject as TentativeStoreDefinition;
                    }
                    break;
                case SelectStoreUsageEnum.UseMainStoreResources:
                    let selectableMainStores: Array<MainStoreDefinition> = await UserHelper.UseMainStoreResources;
                    if (selectableMainStores.length === 1) {
                        this._StockAction.Store = selectableMainStores[0];
                    }
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let mainStore of selectableMainStores) { mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.toString(), mainStore); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16415", "İlgili Ana Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(371, i18n("M16940", "İşlemin yapılacağı ana depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.Store = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
                    }
                    break;
                case SelectStoreUsageEnum.UseMainStores:
                    let mainStores: Array<any> = await MainStoreDefinitionService.GetAllMainStores();
                    if (mainStores.length === 0) {
                        throw new TTException(await SystemMessageService.GetMessageV2(372, i18n("M16939", "İşlemin yapılacağı ana depo bulunamadığından işleme devam edemezsiniz.")));
                    }
                    if (mainStores.length === 1) {
                        this._StockAction.Store = <MainStoreDefinition>mainStores[0];
                    }
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let mainStore of mainStores) 
                        {   if(mainStore.IsActive!=false)
                            {
                                mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.toString(), mainStore); 
                            }
                             
                        }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16415", "İlgili Ana Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(371, i18n("M16940", "İşlemin yapılacağı ana depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.Store = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
                    }
                    break;
                case SelectStoreUsageEnum.UseUserResource:
                    this._StockAction.Store = await UserHelper.Store;
                    break;
                case SelectStoreUsageEnum.UseUserResources:
                    let selectableStore: Array<Store> = await UserHelper.UseUserResourcesStores;
                    if (selectableStore.length === 1) {
                        this._StockAction.Store = selectableStore[0];
                    }
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let store of selectableStore) { mSelectForm.AddMSItem(store.Name, store.ObjectID.toString(), store); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16420", "İlgili Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(249, i18n("M16944", "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.Store = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseInPatientUserResource:
                    let selectableInPatientResourceStore: Array<Store> = await UserHelper.UseInPatientUserResourceStores;
                    if (selectableInPatientResourceStore.length === 1)
                        this._StockAction.Store = selectableInPatientResourceStore[0];
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let store of selectableInPatientResourceStore) { mSelectForm.AddMSItem(store.Name, store.ObjectID.toString(), store); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16420", "İlgili Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(249, i18n("M16944", "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.Store = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseOutPatientUserResource:
                    let selectableOutPatientReourceStore: Array<Store> = await UserHelper.UseOutPatientUserResourceStores;
                    if (selectableOutPatientReourceStore.length === 1)
                        this._StockAction.Store = selectableOutPatientReourceStore[0];
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let store of selectableOutPatientReourceStore) { mSelectForm.AddMSItem(store.Name, store.ObjectID.toString(), store); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16420", "İlgili Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(249, i18n("M16944", "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.Store = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseSecMasterUserResource:
                    let selectableSecMasterResourceStore: Array<Store> = await UserHelper.UseSecMasterUserResourceStores;
                    if (selectableSecMasterResourceStore.length === 1) {
                        this._StockAction.Store = selectableSecMasterResourceStore[0];
                    }
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let store of selectableSecMasterResourceStore) { mSelectForm.AddMSItem(store.Name, store.ObjectID.toString(), store); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16420", "İlgili Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(249, i18n("M16944", "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.Store = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseSelectedInPatientUserResource:
                case SelectStoreUsageEnum.UseSelectedOutPatientUserResource:
                case SelectStoreUsageEnum.UseSelectedSecMasterUserResource:
                    let selectedStore: Store = null;
                    if (storeUsageEnum === SelectStoreUsageEnum.UseSelectedInPatientUserResource)
                        selectedStore = await UserHelper.SelectedInPatientResourceStore;
                    if (storeUsageEnum === SelectStoreUsageEnum.UseSelectedOutPatientUserResource)
                        selectedStore = await UserHelper.SelectedOutPatientResourceStore;
                    if (storeUsageEnum === SelectStoreUsageEnum.UseSelectedSecMasterUserResource)
                        selectedStore = await UserHelper.SelectedSecMasterResourceStore;
                    if (selectedStore === null)
                        throw new Exception(await SystemMessageService.GetMessageV2(373, i18n("M17923", "Kullanıcının oda deposu bulunmamaktadır")));
                    this._StockAction.Store = selectedStore;
                    break;
                case SelectStoreUsageEnum.UseRoomStores:
                    let selectableRoomStore: Array<Store> = await UserHelper.UseRoomStores;
                    if (selectableRoomStore.length === 1)
                        this._StockAction.Store = selectableRoomStore[0];
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let store of selectableRoomStore) { mSelectForm.AddMSItem(store.Name, store.ObjectID.toString(), store); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16420", "İlgili Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(249, i18n("M16944", "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.Store = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseRoomStoreParentSubStore:
                    let selectableParentStore: Array<Store> = await UserHelper.UseRoomStoreParentSubStore;
                    if (selectableParentStore.length === 1)
                        this._StockAction.Store = selectableParentStore[0];
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let store of selectableParentStore) { mSelectForm.AddMSItem(store.Name, store.ObjectID.toString(), store); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16420", "İlgili Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(249, i18n("M16944", "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.Store = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseUnitStoreResources:
                    let selectableUnitStores: Array<UnitStoreDefinition> = await UserHelper.UseUnitStoreResources;
                    if (selectableUnitStores.length === 1) {
                        this._StockAction.Store = <Store>selectableUnitStores[0];
                    }
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let unitStore of selectableUnitStores) { mSelectForm.AddMSItem(unitStore.Name, unitStore.ObjectID.toString(), unitStore); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16416", "İlgili Birlik Deposunu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(371, i18n("M16942", "İşlemin yapılacağı birlik deposu seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.Store = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UsePharmacyMainStore:
                    let pharmacyStores: Array<PharmacyStoreDefinition> = await PharmacyStoreDefinitionService.GetPharmacyStores();
                    if (pharmacyStores.length === 0) {
                        throw new TTException(await SystemMessageService.GetMessageV2(372, i18n("M16939", "İşlemin yapılacağı ana depo bulunamadığından işleme devam edemezsiniz.")));
                    }
                    if (pharmacyStores.length === 1) {
                        this._StockAction.Store = <PharmacyStoreDefinition>pharmacyStores[0];
                    }
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let mainStore of pharmacyStores) { mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.toString(), mainStore); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16415", "İlgili Ana Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(371, i18n("M16940", "İşlemin yapılacağı ana depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.Store = mSelectForm.MSSelectedItemObject as PharmacyStoreDefinition;
                    }
                    break;
                default:
                    throw new Exception(await SystemMessageService.GetMessageV2(374, i18n("M22803", "Tanımsız kriter işlem yapılamaz.")));
            }
        }
        if (this._StockAction.DestinationStore == null) {
            switch (destinationStoreUsageEnum) {
                case SelectStoreUsageEnum.Nothing:
                    this._StockAction.DestinationStore = null;
                    break;
                case SelectStoreUsageEnum.UseMainStoreResources:
                    let selectableMainStores: Array<MainStoreDefinition> = await UserHelper.UseMainStoreResources;
                    if (selectableMainStores.length === 1) {
                        this._StockAction.DestinationStore = selectableMainStores[0];
                    }
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let mainStore of selectableMainStores) { mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.toString(), mainStore); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16415", "İlgili Ana Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(371, i18n("M16940", "İşlemin yapılacağı ana depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.DestinationStore = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
                    }
                    break;
                case SelectStoreUsageEnum.UseMainStores:
                    if (this._StockAction instanceof ProductionConsumptionDocument && this._StockAction.Store instanceof UnitStoreDefinition) {
                        break;
                    }
                    let mainStores: Array<any> = await MainStoreDefinitionService.GetAllMainStores();
                    if (mainStores.length === 0)
                        throw new TTException(await SystemMessageService.GetMessageV2(372, i18n("M16939", "İşlemin yapılacağı ana depo bulunamadığından işleme devam edemezsiniz.")));
                    if (mainStores.length === 1) {
                        this._StockAction.DestinationStore = <MainStoreDefinition>mainStores[0];
                    }
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        if (this._StockAction.Store.ObjectDefID.toString() === MainStoreDefinition.ObjectDefID.id) {
                            for (let mainStore of mainStores) {
                                if ((<MainStoreDefinition>(mainStore)).MKYS_ButceTuru === (<MainStoreDefinition>(this._StockAction.Store)).MKYS_ButceTuru && mainStore.ObjectID !== this._StockAction.Store.ObjectID)
                                    mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.toString(), mainStore);
                            }
                        }
                        else {
                            for (let mainStore of mainStores) {
                                if(mainStore.IsActive!=false)
                                {
                                    mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.toString(), mainStore);
                                }
                               
                            }
                        }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16415", "İlgili Ana Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(371, i18n("M16940", "İşlemin yapılacağı ana depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.DestinationStore = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
                    }
                    break;
                case SelectStoreUsageEnum.UseUserResource:
                    this._StockAction.DestinationStore = await UserHelper.Store;
                    break;
                case SelectStoreUsageEnum.UseUserResources:
                    let selectableStore: Array<Store> = new Array<Store>();
                    selectableStore = await UserHelper.UseUserResourcesStores;
                    if (selectableStore.length === 1)
                        this._StockAction.DestinationStore = selectableStore[0];
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let store of selectableStore) { mSelectForm.AddMSItem(store.Name, store.ObjectID.toString(), store); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16420", "İlgili Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(249, i18n("M16944", "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.DestinationStore = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseInPatientUserResource:
                    selectableStore = new Array<Store>();
                    selectableStore = await UserHelper.UseInPatientUserResourceStores;
                    if (selectableStore.length === 1)
                        this._StockAction.DestinationStore = selectableStore[0];
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let store of selectableStore) { mSelectForm.AddMSItem(store.Name, store.ObjectID.toString(), store); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16420", "İlgili Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(249, i18n("M16944", "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.DestinationStore = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseOutPatientUserResource:
                    selectableStore = new Array<Store>();
                    selectableStore = await UserHelper.UseOutPatientUserResourceStores;
                    if (selectableStore.length === 1)
                        this._StockAction.DestinationStore = selectableStore[0];
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let store of selectableStore) { mSelectForm.AddMSItem(store.Name, store.ObjectID.toString(), store); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16420", "İlgili Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(249, i18n("M16944", "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.DestinationStore = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseSecMasterUserResource:
                    selectableStore = new Array<Store>();
                    selectableStore = await UserHelper.UseSecMasterUserResourceStores;
                    if (selectableStore.length === 1)
                        this._StockAction.DestinationStore = selectableStore[0];
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let store of selectableStore) { mSelectForm.AddMSItem(store.Name, store.ObjectID.toString(), store); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16420", "İlgili Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(249, i18n("M16944", "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.DestinationStore = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseSelectedInPatientUserResource:
                case SelectStoreUsageEnum.UseSelectedOutPatientUserResource:
                case SelectStoreUsageEnum.UseSelectedSecMasterUserResource:
                    let selectedStore: Store = null;
                    if (destinationStoreUsageEnum === SelectStoreUsageEnum.UseSelectedInPatientUserResource)
                        selectedStore = await UserHelper.SelectedInPatientResourceStore;
                    if (destinationStoreUsageEnum === SelectStoreUsageEnum.UseSelectedOutPatientUserResource)
                        selectedStore = await UserHelper.SelectedOutPatientResourceStore;
                    if (destinationStoreUsageEnum === SelectStoreUsageEnum.UseSelectedSecMasterUserResource)
                        selectedStore = await UserHelper.SelectedSecMasterResourceStore;
                    if (selectedStore === null)
                        throw new Exception(await SystemMessageService.GetMessageV2(373, i18n("M17923", "Kullanıcının oda deposu bulunmamaktadır")));
                    this._StockAction.DestinationStore = selectedStore;
                    break;
                case SelectStoreUsageEnum.UseRoomStoreParentSubStore:
                    if (this._StockAction.Store instanceof RoomStoreDefinition)
                        this._StockAction.DestinationStore = (<RoomStoreDefinition>this._StockAction.Store).ParentStore;
                    else if (this._StockAction.Store instanceof PharmacyStoreDefinition)
                        this._StockAction.DestinationStore = (<PharmacyStoreDefinition>this._StockAction.Store).UnitStoreDefinition;
                    break;
                case SelectStoreUsageEnum.UseRoomStores:
                    let selectableRoomStore: Array<Store> = new Array<Store>();
                    let roomStores: Array<any> = await RoomStoreDefinitionService.GetParentStoreByRoomStore(this._StockAction.Store.ObjectID);
                    let pharmacyStores: Array<any> = await PharmacyStoreDefinitionService.GetPharmacyByUnitStore(this._StockAction.Store.ObjectID);
                    for (let rstore of roomStores) {
                        if (selectableRoomStore.Contains(rstore) === false)
                            selectableRoomStore.push(rstore);
                    }
                    for (let pstore of pharmacyStores) {
                        if (selectableRoomStore.Contains(pstore) === false)
                            selectableRoomStore.push(pstore);
                    }
                    if (selectableRoomStore.length === 1)
                        this._StockAction.DestinationStore = selectableRoomStore[0];
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let store of selectableRoomStore) { mSelectForm.AddMSItem(store.Name, store.ObjectID.toString(), store); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16420", "İlgili Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(249, i18n("M16944", "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.DestinationStore = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UsePharmacyMainStore:
                    let mPharmacyStores: Array<PharmacyStoreDefinition> = await PharmacyStoreDefinitionService.GetPharmacyStores();
                    if (mPharmacyStores.length === 0) {
                        throw new TTException(await SystemMessageService.GetMessageV2(372, i18n("M16939", "İşlemin yapılacağı ana depo bulunamadığından işleme devam edemezsiniz.")));
                    }
                    if (mPharmacyStores.length === 1) {
                        this._StockAction.DestinationStore = <PharmacyStoreDefinition>mPharmacyStores[0];
                    }
                    else {
                        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let mainStore of mPharmacyStores) { mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.toString(), mainStore); }
                        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16415", "İlgili Ana Depoyu Seçiniz"), true);
                        if (String.isNullOrEmpty(mkey))
                            throw new TTException(await SystemMessageService.GetMessageV2(371, i18n("M16940", "İşlemin yapılacağı ana depo seçilmeden işleme devam edemezsiniz.")));
                        this._StockAction.DestinationStore = mSelectForm.MSSelectedItemObject as PharmacyStoreDefinition;
                    }
                    break;
                default:
                    throw new Exception(await SystemMessageService.GetMessageV2(374, i18n("M22803", "Tanımsız kriter işlem yapılamaz.")));
            }
        }
    }
    public async ShowStockActionDetailForm(stockActionDetail: StockActionDetail): Promise<void> {
        let frm: TTVisual.TTForm = TTVisual.TTForm.GetEditForm(stockActionDetail);
        if (frm === null)
            return;
        try {
            if (stockActionDetail.ObjectContext.IsReadOnly)
                frm.ShowReadOnly(this, stockActionDetail);
            else frm.ShowEdit(this, stockActionDetail);
        }
        catch (ex) {
            TTVisual.InfoBox.Alert(ex);
        }

    }
    public redirectProperties(): void {

    }

    public initFormControls(): void {

    }


}
