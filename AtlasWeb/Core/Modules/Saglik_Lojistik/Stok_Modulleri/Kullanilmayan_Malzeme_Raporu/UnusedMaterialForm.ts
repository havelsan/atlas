import { Component, OnInit, Input } from '@angular/core';
import { Headers, RequestOptions } from '@angular/http';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { UnusedMaterialFormViewModel, UnusedResultModel, InputModelForSecondLevel, OutVoucherSecondLevelResultModel,ModelForInfoInput,InventoryInput, InputModelForThirdLevel, MaterialModel } from './UnusedMaterialFormViewModel';
import { DrugSpecificationEnum, TransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { UserHelper } from 'app/Helper/UserHelper';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DateParam } from 'app/NebulaClient/Mscorlib/DateParam';

@Component({
    selector: "UnusedMaterialForm",
    templateUrl: './UnusedMaterialForm.html',
    providers: [SystemApiService, MessageService]
})
export class UnusedMaterialForm extends TTUnboundForm implements OnInit {
    public CurrentPanelName: string = 'UnusedMaterialForm';
    public _ViewModel: UnusedMaterialFormViewModel = new UnusedMaterialFormViewModel();
    public BudgetTypeDefinition: TTVisual.TTObjectListBox;
    public UnusedMaterialFormViewModel = new UnusedMaterialFormViewModel();
    public SelectedFilterMaterials: Array<Material> = new Array<Material>();
    public visibility: boolean = false;
    public visible: boolean = false;
    protected activeUserService: IActiveUserService;
    public store: Store;
    public storeName: string;
    public boolStore: boolean = false;
    public selecttableStores: Array<Store>;
    public SelectedFilterStores: Array<Guid> = new Array<Guid>();
    public months: Array<[string, number]>;
    public StoreList: Array<Store> = new Array<Store>();
    public StoresName: Array<string> = new Array<string>();
    public selectedItems: Array<Store> = new Array<Store>();
    public selectedOutStore: Store;
    public selectedMaterials: Array<MaterialModel> = new Array<MaterialModel>();
    public ConsultationRequestedUserList: Array<MaterialModel> = new Array<MaterialModel>();
    public filterAmount: number;
    MKYS_CikisIslemTuru: TTVisual.ITTEnumComboBox;
    doctorID: Guid;
    outStoreID: Guid;
    VademecumList: Array<number> = new Array<number>();
    public DrugSpecificationEnumDef;
    public TransactionEnumDef;
    public LoadPanelMessage: string = 'Kayıtlar Yükleniyor, Lütfen Bekleyiniz.';
    public showLoadPanel = false;
    public getEHU: boolean = false;
    public StockOutTypeList: Array<StockOutType> = new Array<StockOutType>();


    privateUnusedMaterialForm_DocumentUrl: string = '/api/UnusedMaterialService/UnusedMaterialForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, private modalService: IModalService, private reportService: AtlasReportService) {
        super('Return', 'UnusedMaterialForm');        
        this.initViewModel();
    }


    public initViewModel(): void {
        this.DrugSpecificationEnumDef = DrugSpecificationEnum.Items;
        this.TransactionEnumDef = TransactionTypeEnum.Items;
        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.Name = 'BudgetTypeDefinition';
        this.BudgetTypeDefinition.TabIndex = 128;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = '20%';
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = '20%';

        this.MKYS_CikisIslemTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisIslemTuru.DataTypeName = "MKYS_ECikisStokHareketTurEnum";
        this.MKYS_CikisIslemTuru.BackColor = "#F0F0F0";
        this.MKYS_CikisIslemTuru.Enabled = true;
        this.MKYS_CikisIslemTuru.Name = "MKYS_CikisIslemTuru";
        this.MKYS_CikisIslemTuru.TabIndex = 124;

    }
    public inventoryList;
    private showInventoryDetail: boolean = false;
    public async ChangeVisibility(value: any) {

        try {
            this.showInventoryDetail = true;
            if (value != null) {
                let that = this;
                let input: InventoryInput = new InventoryInput();
                input.MaterialObjectID = value.value;
                input.viewModel = this._ViewModel;
                let apiUrlForPASearchUrl: string = '/api/MovableTransactionInputVoucherService/GetHospitalInventory';
                let body = "";
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: headers });
                let result = await this.httpService.post(apiUrlForPASearchUrl, input);
                this.inventoryList = result;
            }
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }
    public initStockOutTypeList() {
        this.StockOutTypeList.push(new StockOutType("Ana Depolar Arası Transfer", new Guid("7282fb68-22c3-4b94-8dd1-6bf19d305498")));
        this.StockOutTypeList.push(new StockOutType("Dağıtım Belgesi", new Guid("eeb68b1e-fb6e-4348-a2e3-6e0b0f6b1c60")));
        this.StockOutTypeList.push(new StockOutType("Atık Depoya Çıkış", new Guid("ef3cf819-f18a-4b9e-89fe-620641f3ff42")));
        this.StockOutTypeList.push(new StockOutType("Depolar Arası Transfer", new Guid("fe3b0bc0-6558-41ab-8f70-d99ffce60d34")));
        this.StockOutTypeList.push(new StockOutType("Günlük İlaç Çizelgesi", new Guid("f8155e0a-8527-4886-89b8-3aa7c25bc267")));
        this.StockOutTypeList.push(new StockOutType("İade Belgesi", new Guid("0899912a-e828-4e81-a84a-808d20971a22")));
        this.StockOutTypeList.push(new StockOutType("Taşınır Mal İşlem Çıkışı", new Guid("2c1a8b51-4001-43d6-8559-3bbc4771eccb")));
        this.StockOutTypeList.push(new StockOutType("İhtiyaç Fazlası", new Guid("dd8888e4-bd9b-424e-a891-b4e64becc89b")));
    }
    public redirectProperties(): void {
        redirectProperty(this.MKYS_CikisIslemTuru, "Value", this.UnusedMaterialFormViewModel, "MKYS_CikisIslemTuru");
    }

    Menu = [{
        id: "1",
        icon: "btn-default glyphicon glyphicon-list",
        items: [{
            id: "1_1",
            name: "Giriş Fişini Aç",
        }, {
            id: "1_2",
            name: "Çıkış Fişini Aç",

        }
        ]
    }];

    menuItemClick(e, row) {
        if (e.itemData.id == "1_1")
            this.showStockAction(row.data.InStockActionDetail);
        else if (e.itemData.id == "1_2")
            this.showStockAction(row.data.StockActionID);
    }
    itemClick(e, row){
        if (e.itemData.id == "1_1")
            this.selectAction(row);
        else if (e.itemData.id == "1_2")
            this.selectionChangedHandlerOnInMaterial(row);
        else if (e.itemData.id == "1_3")
            this.ChangeVisibility(row);
    }
    private ShowVoucherDetailList: boolean = false;
    public OutTransactionList;
    public showOutTransactionPopUp;
    public async selectionChangedHandlerOnInMaterial(event) {

        try {
            this.ShowVoucherDetailList = false;
            if (event != null && event.selectedRowsData != null && event.selectedRowsData[0] != null) {
                let that = this;
                let input: ModelForInfoInput = new ModelForInfoInput();
                input.MaterialStockTransactionID = event.selectedRowsData[0].StockTransactionID;
                let apiUrlForPASearchUrl: string = '/api/MovableTransactionInputVoucherService/GetOutTransactionForInMaterials';
                let body = "";
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: headers });
                let result = await this.httpService.post(apiUrlForPASearchUrl, input);
                this.OutTransactionList = result;
            }
            this.showOutTransactionPopUp = true;
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }


    }
    async selectAction(value: any): Promise<void> {
        this.showStockAction(value.data.StockActionObjectID);
    }
    private showStockAction(data: any): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DashboardActionComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M16835", "İşlem Detayı");
            modalInfo.Width = 1200;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    async ngOnInit(): Promise<void> {
        this.FillDataSources();
        this.FillStoreDataSources();
        this.UnusedMaterialFormViewModel.DayQueryNumber = 60;
    }

    @Input() set SelectedMainStore(value: any) {
        if (value != null && value != undefined)
            this.UnusedMaterialFormViewModel.StoreID = value.ObjectID;
    }
    get SelectedMainStore(): any {
        return this.UnusedMaterialFormViewModel.StoreID;
    }

    private showMaterialMultiSelectForm: boolean = false;
    OpenMaterialMultiSelectComponent() {
        if (this.mList == undefined)
            this.GetMaterials();
        this.showMaterialMultiSelectForm = true;
    }

    private showStockMultiSelectForm: boolean = false;
    OpenStockMultiSelectComponent() {
        this.showStockMultiSelectForm = true;
        this.selectStore();
    }

    public selectedMaterialsText: string = "";
    async MaterialsSelected(event) {

        let selectedMaterials = event;
        this.UnusedMaterialFormViewModel.SelectedMaterialList = new Array<MaterialModel>();
        for (let selectedItem of selectedMaterials) {
            let model:MaterialModel =  new MaterialModel();
            model.ID = selectedItem.ObjectID;
            model.Name = selectedItem.Name;
            this.UnusedMaterialFormViewModel.SelectedMaterialList.push(model);
        }
        this.showMaterialMultiSelectForm = false;

        if (this.UnusedMaterialFormViewModel.SelectedMaterialList.length != 0) {
            this.visible = true;
        }
    }

    public clearSelectedMaterials() {
        this.UnusedMaterialFormViewModel.SelectedMaterialList = new Array<MaterialModel>();
        this.selectedMaterialsText = "";

    }
    public showUnusedMaterial(event): void {
        if (event.value === true) {
            this.UnusedMaterialFormViewModel.showUnused = true;
        }
        else {
            this.UnusedMaterialFormViewModel.showUnused = false;
        }
    }

    public SelectedDoctor: any;
    public StockTrancationInList;

    async GetOutVoucherList() {

        try {            
            let that = this;
            this.outStoreID = this.selectedOutStore != null ? this.selectedOutStore.ObjectID : new Guid();
            this.UnusedMaterialFormViewModel.OutStoreID = this.outStoreID;

            let apiUrlForPASearchUrl: string;
            this.doctorID = this.SelectedDoctor != null ? this.SelectedDoctor.ObjectID : new Guid();


            this.UnusedMaterialFormViewModel.DoctorID = this.doctorID;


            if (this.UnusedMaterialFormViewModel.DayQueryNumber === undefined) {
                this.UnusedMaterialFormViewModel.DayQueryNumber = 60;
            }
            if (this.UnusedMaterialFormViewModel.filterAmount === undefined) {
                this.UnusedMaterialFormViewModel.filterAmount = 0;
            }
            apiUrlForPASearchUrl = '/api/UnusedMaterialService/GetUnusedMaterials';
            this.showLoadPanel = true;
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            let result = await this.httpService.post(apiUrlForPASearchUrl, this.UnusedMaterialFormViewModel);
            this.StockTrancationInList = result;
            this.showLoadPanel = false;


        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
            this.showLoadPanel = false;

        }
    }
    public SelectedMaterial: UnusedResultModel = new UnusedResultModel();
    public VoucherDetail;
    public async selectionChangedHandlerOnTransaction(event) {
        try {
            if (event != null && event.selectedRowsData != null && event.selectedRowsData[0] != null) {
                this.SelectedMaterial = event.selectedRowsData[0];
                let input: InputModelForSecondLevel = new InputModelForSecondLevel();
                input.StockTransactionObjectID = this.SelectedMaterial.StockTransactionObjectID;
                let that = this;
                let apiUrlForPASearchUrl: string = '/api/UnusedMaterialService/GetOutVoucherForSecondLevel';
                let body = "";
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: headers });
                let result = await this.httpService.post(apiUrlForPASearchUrl, input);
                this.VoucherDetail = result;
            } else {
                this.SelectedMaterial = null;
            }
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public selectedVoucher: OutVoucherSecondLevelResultModel = new OutVoucherSecondLevelResultModel();
    public VoucherDetailList;
    public async selectionChangedHandlerOnVoucher(event) {
        try {
            if (event != null && event.selectedRowsData != null && event.selectedRowsData[0] != null) {
                this.selectedVoucher = event.selectedRowsData[0];
                let input: InputModelForThirdLevel = new InputModelForThirdLevel();
                input.StockActionObjectID = this.selectedVoucher.ObjectID;
                let that = this;
                let apiUrlForPASearchUrl: string = '/api/UnusedMaterialService/GetOutVoucherDetailsForThirdLevel';
                let body = "";
                let headers = new Headers({ 'Content-Type': 'application/json'});
                let options = new RequestOptions({ headers: headers });
                let result = await this.httpService.post(apiUrlForPASearchUrl, input);
                this.VoucherDetailList = result;
            } else {
                this.selectedVoucher = null;
            }
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }



    public selectedStoreText: string = "";


    async selectStore() {
        this.UnusedMaterialFormViewModel.MaterialList;
        let getStore: Store;
        this.selecttableStores = await UserHelper.UseUserResourcesStores;
        if (this.UnusedMaterialFormViewModel.StoresName != null) {
            for (let selecetedStore of this.selecttableStores) {
                this.UnusedMaterialFormViewModel.StoreList.push(selecetedStore);
                this.UnusedMaterialFormViewModel.StoresName.push(selecetedStore.Name);
            }

        }
        this.UnusedMaterialFormViewModel.StoresName = null;
    }

    public mStores = this.UnusedMaterialFormViewModel.StoreList;

    public SelectedStores() {
        this.UnusedMaterialFormViewModel.SelectedFilterStores = new Array<Guid>();
        this.selectedStoreText = "";
        for (let selectedItem of this.selectedItems) {
            this.UnusedMaterialFormViewModel.SelectedFilterStores.push(selectedItem.ObjectID);
            this.selectedStoreText += selectedItem.Name + " - ";
        }
        this.visibility = true;
        this.showStockMultiSelectForm = false;

    }

    public mList;
    public async GetMaterials() {
        try {
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/UnusedMaterialService/GetMaterialsBySelectedStores';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });
            let result = await this.httpService.post(apiUrlForPASearchUrl, this.UnusedMaterialFormViewModel);
            this.mList = result;
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }

    }


    public clearSelectedStore() {
        this.UnusedMaterialFormViewModel.SelectedFilterStores = new Array<Guid>();
        this.selectedStoreText = "";
    }

    public DoctorList;
    async FillDataSources() {
        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/UnusedMaterialService/FillDataSources';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.DoctorList = result;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }

        this.initStockOutTypeList();
    }

    public OutStoreList;
    async FillStoreDataSources() {
        try {

            let that = this;
            //let apiUrlForPASearchUrl: string = '/api/UnusedMaterialService/FillResources';
            let apiUrlForPASearchUrl: string = '/api/UnusedMaterialService/FillStoreDataSources';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });
            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.OutStoreList = result;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }

    }

    public OzellikChanged(data) {
        if (data.addedItems.length === 1) {
            this.VademecumList.push(data.addedItems[0].code);
        }
        else if (data.removedItems.length === 1) {
            this.VademecumList.splice(this.VademecumList.findIndex(x => x === (data.removedItems[0].code)), 1);
        }


        this.UnusedMaterialFormViewModel.VademecumList = this.VademecumList;
    }

    public onSelectionChanged(event): void {
        if (event.value === true) {
            this.getEHU = true;
        }
        else {
            this.getEHU = false;
        }
        this.UnusedMaterialFormViewModel.getEHU = this.getEHU;
    }

    public onStockOutTypeChanged(data) {
        if (data.addedItems.length === 1) {
            this.UnusedMaterialFormViewModel.SelectedStockOutTypeList.push(data.addedItems[0].value);
        }
        else if (data.removedItems.length === 1) {
            this.UnusedMaterialFormViewModel.SelectedStockOutTypeList.splice(this.UnusedMaterialFormViewModel.SelectedStockOutTypeList.findIndex(x => x === (data.removedItems[0].value)), 1);
        }
    }

    public async prepareDocument_Click(): Promise<void> {
        const startDate = new DateParam(this.UnusedMaterialFormViewModel.StartDate);
        const endDate = new DateParam(this.UnusedMaterialFormViewModel.EndDate);
        this.outStoreID = this.selectedOutStore != null ? this.selectedOutStore.ObjectID : new Guid();
        const masterResource = new GuidParam(this.outStoreID);
        this.doctorID = this.SelectedDoctor != null ? this.SelectedDoctor.ObjectID : new Guid();
        const doctor = new GuidParam(this.doctorID);
        let reportParameters: any = { 'STARTDATE': startDate, 'ENDDATE': endDate, 'MASTERRESOURCE': masterResource, 'DOCTOR': doctor };
        this.reportService.showReport('DrugReturnDetailPercentReport', reportParameters);
    }
}

export class StockOutType {
    that = this;
    constructor(text: string, value: Guid) {
        this.text = text;
        this.value = value;
    }
    text: string;
    value: Guid;
}
