import { Component, OnInit, Input } from '@angular/core';
import { Headers, RequestOptions } from '@angular/http';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { DrugOutForRecipeTypeFormViewModel, DrugOutForInputReciepeTypeFormViewModel, DrugOutForRecipeTypeResultModel, InputModelForSecondLevel, OutVoucherSecondLevelResultModel, InputModelForThirdLevel, MaterialModel } from './DrugOutForRecipeTypeFormViewModel';
import { DrugSpecificationEnum,ActiveIngredientDefinition, TransactionTypeEnum, PrescriptionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { UserHelper } from 'app/Helper/UserHelper';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { DateParam } from 'app/NebulaClient/Mscorlib/DateParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { IntegerParam, BooleanParam, StringParam } from 'app/NebulaClient/Mscorlib/QueryParam';
import { ArrayParam } from 'app/NebulaClient/Mscorlib/ArrayParam';




@Component({
    selector: "DrugOutForRecipeTypeForm",
    templateUrl: './DrugOutForRecipeTypeForm.html',
    providers: [SystemApiService, MessageService]
})
export class DrugOutForRecipeTypeForm extends TTUnboundForm implements OnInit {
    public CurrentPanelName: string = 'DrugOutForRecipeTypeForm';
    public BudgetTypeDefinition: TTVisual.TTObjectListBox;
    public DrugOutForRecipeTypeFormViewModel = new DrugOutForRecipeTypeFormViewModel();
    public DrugOutForInputReciepeTypeFormViewModel = new DrugOutForInputReciepeTypeFormViewModel();
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
    public SelectedStockOutTypeList: Array<Guid> = new Array<Guid>();
    public StoresName: Array<string> = new Array<string>();
    public selectedItems: Array<Store> = new Array<Store>();
    public selectedOutStores: Array<Store> = new Array<Store>();
    public selectedMaterials: Array<MaterialModel> = new Array<MaterialModel>();
    public ConsultationRequestedUserList: Array<MaterialModel> = new Array<MaterialModel>();
    public filterAmount: number;
    MKYS_CikisIslemTuru: TTVisual.ITTEnumComboBox;
    doctorIDList: Array<Guid> = new Array<Guid>();
    outStoreIDList: Array<Guid> = new Array<Guid>();
    VademecumList: Array<number> = new Array<number>();
    public doctorID: Guid;
    public storeID: Guid;
    public SelectedDoctor: any;
    public DrugActiveIngredientList: TTVisual.ITTObjectListBox;
    public SelectedStore: any;
    public DrugSpecificationEnumDef;
    public TransactionEnumDef;
    public LoadPanelMessage: string = 'Kayıtlar Yükleniyor, Lütfen Bekleyiniz.';
    public showLoadPanel = false;
    public getEHU: boolean = false;
    public StockOutTypeList: Array<StockOutType> = new Array<StockOutType>();
    public PrescriptionTypeEnumDef;
    ActiveSubstanceIDList: Array<Guid> = new Array<Guid>();
    public SelectedActiveIngredients: Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> = new Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>();
    public storeListFiltred: string ="";


    private DrugOutForRecipeTypeForm_DocumentUrl: string = '/api/DrugOutForRecipeTypeService/DrugOutForRecipeTypeForm';
    constructor(protected httpService: NeHttpService, private reportService: AtlasReportService, protected messageService: MessageService, public systemApiService: SystemApiService, private modalService: IModalService) {
        super('DrugOutForRecipeType', 'DrugOutForRecipeTypeForm');
        this.DrugActiveIngredientList = new TTVisual.TTObjectListBox();
        this.DrugActiveIngredientList.ListFilterExpression = "";
        this.DrugActiveIngredientList.ListDefName = "ActiveIngredientList";
        this.DrugActiveIngredientList.Name = "DrugActiveIngredientList";
        this.DrugActiveIngredientList.TabIndex = 4;
        this.initViewModel();
       
    }


    public initViewModel(): void {
        this.DrugSpecificationEnumDef = DrugSpecificationEnum.Items;
        this.PrescriptionTypeEnumDef = PrescriptionTypeEnum.Items;
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

    public initStockOutTypeList() {
        this.StockOutTypeList.push(new StockOutType("Dağıtım Belgesi", new Guid("eeb68b1e-fb6e-4348-a2e3-6e0b0f6b1c60")));
        this.StockOutTypeList.push(new StockOutType("Günlük İlaç Çizelgesi", new Guid("f8155e0a-8527-4886-89b8-3aa7c25bc267")));
    }
    // public redirectProperties(): void {
    //     redirectProperty(this.MKYS_CikisIslemTuru, "Value", this.DrugOutForRecipeTypeFormViewModel, "MKYS_CikisIslemTuru");
    // }

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



    async ngOnInit(): Promise<void> {
        this.FillDataSources();
        this.FillStoreDataSources();

    }

    @Input() set SelectedMainStore(value: any) {
        if (value != null && value != undefined)
            this.DrugOutForRecipeTypeFormViewModel.StoreID = value.ObjectID;
            this.DrugOutForRecipeTypeFormViewModel.SelectedFilterStores.push(value.ObjectID);
    }
    get SelectedMainStore(): any {
        return this.DrugOutForRecipeTypeFormViewModel.StoreID;
    }
    //public SelectedMainStore;
    // @Input() set SelectedMainStore(value: any) {
    //     if (value != null && value != undefined) {
    //         this.DrugOutForRecipeTypeFormViewModel.StoreID = value.ObjectID;
    //      //   this.DrugOutForInputReciepeTypeFormViewModel.Store=value.ObjectID;
    //     }
    //     else {
    //         this.DrugOutForRecipeTypeFormViewModel.StoreID = new Guid('00000000-0000-0000-0000-000000000000');
    //         this.DrugOutForRecipeTypeFormViewModel.StoreID = new Guid('00000000-0000-0000-0000-000000000000');
    //     }
    // }
    // get SelectedMainStore(): any {
    //     // return this.DrugOutForRecipeTypeFormViewModel.StoreID;
    //     return this.DrugOutForRecipeTypeFormViewModel.StoreID;
    // }


    // onBudgetTypeChanged(event) {
    //     if (event != null) {
    //         if (this.DrugOutForRecipeTypeFormViewModel.BudgetTypeDefinitionObjectID !== event.ObjectID) {
    //             this.DrugOutForRecipeTypeFormViewModel.BudgetTypeDefinitionObjectID = event.ObjectID;
    //         }
    //     }
    // }
    private showMaterialMultiSelectForm: boolean = false;
    OpenMaterialMultiSelectComponent() {
        this.storeListFiltred =this.DrugOutForRecipeTypeFormViewModel.StoreID.toString();
        if (this.mList == undefined || this.mList.length==0)
            this.GetMaterials();
        this.showMaterialMultiSelectForm = true;
    }

    private showActiveIngredientsMaterialMultiSelectForm: boolean = false;
    OpenActiveIngredientsMaterialMultiSelectComponent() {
        this.showActiveIngredientsMaterialMultiSelectForm = true;

    }
    public selectedChangeOnActiveIngredient() {

        this.ActiveSubstanceIDList = new Array<Guid>();
        for (let selectedItem of this.SelectedActiveIngredients) {
            this.ActiveSubstanceIDList.push(selectedItem.ObjectID);
        }
       // this.visibility = true;
        this.showActiveIngredientsMaterialMultiSelectForm = false;

    }


    public selectedMaterialsText: string = "";

    async MaterialsSelected(event) {
        let selectedMaterials = event;
        this.DrugOutForRecipeTypeFormViewModel.SelectedMaterialList = new Array<MaterialModel>();
        this.DrugOutForRecipeTypeFormViewModel.MaterialList = new Array<any>();
        for (let selectedItem of this.selectedMaterials) {
            let model:MaterialModel =  new MaterialModel();
            model.ID = selectedItem.ID;
            model.Name = selectedItem.Name;
             this.DrugOutForRecipeTypeFormViewModel.MaterialList.push(model.ID.toString());
        }
        this.showMaterialMultiSelectForm = false;

        if (this.DrugOutForRecipeTypeFormViewModel.SelectedMaterialList.length != 0) {
            this.visible = true;

        }


    }


    public showUnused = false;
    public clearSelectedMaterials() {
        this.DrugOutForRecipeTypeFormViewModel.SelectedMaterialList = new Array<MaterialModel>();
        this.selectedMaterialsText = "";

    }
    public showUnusedMaterial(event): void {
        if (event.value === true) {
            this.DrugOutForRecipeTypeFormViewModel.showUnused = true;
        }
        else {
            this.DrugOutForRecipeTypeFormViewModel.showUnused = false;
        }
    }
    public onPrescriptionTypeChanged(event): void {
        if (event != null) {
            if (this.DrugOutForInputReciepeTypeFormViewModel != null && this.DrugOutForInputReciepeTypeFormViewModel.PrescriptionType != event) {
                this.DrugOutForInputReciepeTypeFormViewModel.PrescriptionType = event;
            }
        }
    }
    public mList;
    public async GetMaterials() {
        try {
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/DrugOutForRecipeTypeService/GetMaterialsBySelectedStores';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });
            //this.DrugOutForRecipeTypeFormViewModel.StoreID = this.SelectedMainStore;
            // let result = await this.httpService.post(apiUrlForPASearchUrl, this.DrugOutForRecipeTypeFormViewModel);
            // that.mList = result;
            await this.httpService.post<any>(apiUrlForPASearchUrl, this.DrugOutForRecipeTypeFormViewModel).then(response => {
                let result = response;
                if (result) {
                    that.mList = result;
                    
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }

    }

    public SelectedDoctorListItems: Array<Guid> = new Array<Guid>();
    public StockTrancationInList;
    public DrugOutForRecipeStartDate: Date = new Date();
    public DrugOutForRecipeEndDate: Date = new Date();
    


    async GetOutVoucherList() {
        if(this.SelectedStore == null || this.DrugOutForInputReciepeTypeFormViewModel.PrescriptionType == null || this.DrugOutForRecipeTypeFormViewModel.SelectedStockOutTypeList== null){
            TTVisual.InfoBox.Alert("Çıkış Türü, Reçete Türü ve Çıkış Yapılan Depo Seçilmelidir!");
            return;
        }
        try {

            // let allMaterials=this.selectedMaterials != null? 0:1;
            let apiUrlForPASearchUrl: string;
            this.DrugOutForInputReciepeTypeFormViewModel.PrescriptionType;
            this.DrugOutForInputReciepeTypeFormViewModel.DoctorID = this.SelectedDoctor != null ? this.SelectedDoctor.ObjectID : new Guid();
            this.DrugOutForInputReciepeTypeFormViewModel.Store = this.SelectedStore != null ? this.SelectedStore.ObjectID : new Guid();
            this.DrugOutForInputReciepeTypeFormViewModel.StartDate = new Date(this.DrugOutForRecipeStartDate.getFullYear(), this.DrugOutForRecipeStartDate.getMonth(), this.DrugOutForRecipeStartDate.getDate(), 0, 0, 0);
            this.DrugOutForInputReciepeTypeFormViewModel.EndDate = new Date(this.DrugOutForRecipeEndDate.getFullYear(), this.DrugOutForRecipeEndDate.getMonth(), this.DrugOutForRecipeEndDate.getDate(), 23, 59, 59);
           
         //   this.DrugOutForInputReciepeTypeFormViewModel.DrugSpecifications = this.VademecumList;
            this.DrugOutForInputReciepeTypeFormViewModel.SelectedStockOutTypeList = this.DrugOutForRecipeTypeFormViewModel.SelectedStockOutTypeList.value.toString();
         //   if (this.DrugOutForInputReciepeTypeFormViewModel.DrugSpecifications == null || this.DrugOutForInputReciepeTypeFormViewModel.DrugSpecifications.length == 0) {
          //      this.DrugOutForInputReciepeTypeFormViewModel.allDrugSpecification = true;
          //  }
            // this.DrugOutForInputReciepeTypeFormViewModel.MaterialList = this.selectedMaterials;
            for (let selectedItem of this.selectedMaterials) {
                this.DrugOutForInputReciepeTypeFormViewModel.MaterialList.push(selectedItem.ID.toString());
               this.selectedMaterialsText += selectedItem.Name + " - ";
           }
            if (this.DrugOutForInputReciepeTypeFormViewModel.MaterialList == null || this.DrugOutForInputReciepeTypeFormViewModel.MaterialList.length == 0) {
                this.DrugOutForInputReciepeTypeFormViewModel.allMaterials = true;
            }

            this.showLoadPanel = true;
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });
            apiUrlForPASearchUrl = '/api/DrugOutForRecipeTypeService/GetDrugOutForRecipeTypes';
            let result = await this.httpService.post(apiUrlForPASearchUrl, this.DrugOutForInputReciepeTypeFormViewModel);
            this.StockTrancationInList = result;
            this.showLoadPanel = false;


        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
            this.showLoadPanel = false;

        }
    }

    public async prepareDocument_Click(): Promise<void> {
        var startDate = new DateParam(this.DrugOutForInputReciepeTypeFormViewModel.StartDate);
        var endDate = new DateParam(this.DrugOutForInputReciepeTypeFormViewModel.EndDate);
        this.doctorID = this.SelectedDoctor != null ? this.SelectedDoctor.ObjectID : Guid.Empty;
        var doctor = new GuidParam(this.doctorID);
        //this.storeID=this.SelectedMainStore != null ? this.SelectedMainStore.ObjectID: Guid.Empty;
        var store = new GuidParam(this.DrugOutForInputReciepeTypeFormViewModel.Store);
        var m = [];
        var PrescriptionType = new IntegerParam(this.DrugOutForInputReciepeTypeFormViewModel.PrescriptionType);
        var allMaterials = new BooleanParam(this.DrugOutForInputReciepeTypeFormViewModel.allMaterials);

        var matList: Array<StringParam> = new Array<StringParam>();
        if (this.selectedMaterials != null) {
            if (this.selectedMaterials.length > 0) {
                for (var i = 0; i < this.selectedMaterials.length; i++) {
                    const objectIdParam = new StringParam(this.selectedMaterials[i].ID.toString());
                    matList.push(objectIdParam);
                }
            }
        }

        const MaterialList = new ArrayParam(matList);
        // var speci: Array<StringParam> = new Array<StringParam>();
        // for (var i = 0; i < this.DrugOutForInputReciepeTypeFormViewModel.DrugSpecifications.length; i++) {
        //     const tmp = new StringParam(this.DrugOutForInputReciepeTypeFormViewModel.DrugSpecifications[i].toString());
        //     speci.push(tmp);
        // }
        // const drugspecification = new ArrayParam(speci);

       // var allDrugSpecification = new BooleanParam(this.DrugOutForInputReciepeTypeFormViewModel.allDrugSpecification);
        var tmp: number;

        if (this.DrugOutForInputReciepeTypeFormViewModel.SelectedStockOutTypeList == "f8155e0a-8527-4886-89b8-3aa7c25bc267") {
            let reportParameters: any = {
                'STARTDATE': startDate, 'ENDDATE': endDate, 'PRESCRIPTIONTYPE': PrescriptionType, 'DOCTOR': doctor,
                'MATERIALS': MaterialList, 'ALLMATERIALS': allMaterials, 'STORE': store};
            this.reportService.showReport('DailyDrugForPrescriptionReport', reportParameters);

        }

        else if (this.DrugOutForInputReciepeTypeFormViewModel.SelectedStockOutTypeList == "eeb68b1e-fb6e-4348-a2e3-6e0b0f6b1c60") {
            let reportParameters: any = {
                'STARTDATE': startDate, 'ENDDATE': endDate, 'PRESCRIPTIONTYPE': PrescriptionType,
                'MATERIALS': MaterialList, 'ALLMATERIALS': allMaterials, 'STORE': store
            };
            this.reportService.showReport('DistributionDocumentForPrescriptionReport', reportParameters);


        }
    }





    // public selectedStoreText: string = "";


    // async selectStore() {
    //     this.DrugOutForRecipeTypeFormViewModel.MaterialList;
    //     let getStore: Store;
    //     this.selecttableStores = await UserHelper.UseUserResourcesStores;
    //     if (this.DrugOutForRecipeTypeFormViewModel.StoresName != null) {
    //         for (let selecetedStore of this.selecttableStores) {
    //             this.DrugOutForRecipeTypeFormViewModel.StoreList.push(selecetedStore);
    //             this.DrugOutForRecipeTypeFormViewModel.StoresName.push(selecetedStore.Name);
    //         }

    //     }
    //     this.DrugOutForRecipeTypeFormViewModel.StoresName = null;
    // }

    // public mStores = this.DrugOutForRecipeTypeFormViewModel.StoreList;

    // public SelectedStores() {
    //     this.DrugOutForRecipeTypeFormViewModel.SelectedFilterStores = new Array<Guid>();
    //     this.selectedStoreText = "";
    //     for (let selectedItem of this.selectedItems) {
    //         this.DrugOutForRecipeTypeFormViewModel.SelectedFilterStores.push(selectedItem.ObjectID);
    //         this.selectedStoreText += selectedItem.Name + " - ";
    //     }
    //     this.visibility = true;
    //     this.showStockMultiSelectForm = false;

    // }




    // public clearSelectedStore() {
    //     this.DrugOutForRecipeTypeFormViewModel.SelectedFilterStores = new Array<Guid>();
    //     this.selectedStoreText = "";
    // }

    public onMKYS_CikisIslemTuruChanged(event): void {
        if (event != null) {
            if (this.DrugOutForRecipeTypeFormViewModel.MKYS_CikisIslemTuru != event) {
                this.DrugOutForRecipeTypeFormViewModel.MKYS_CikisIslemTuru = event;
            }
        }
    }

    public DoctorList;
    public ActiveIngredientList:Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>;
    ;
    async FillDataSources() {
        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/DrugOutForRecipeTypeService/FillDataSources';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });
            /*

            let result = await this.httpService.post(apiUrlForPASearchUrl, body);
            this.DoctorList = result;

            */
            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.DoctorList = result.DoctorList;
                    this.ActiveIngredientList=result.ActiveIngredientList;
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
            let apiUrlForPASearchUrl: string = '/api/DrugOutForRecipeTypeService/FillStoreDataSources';
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


    // public OzellikChanged(data) {
    //     if (data.addedItems.length >= 1) {
    //         // this.VademecumList.push(data.addedItems[0].code);
    //         this.DrugOutForInputReciepeTypeFormViewModel.DrugSpecifications.push(data);
    //         this.DrugOutForInputReciepeTypeFormViewModel.allDrugSpecification = false;
    //     }
    //     else if (data.addedItems.length === 0) {
    //         this.DrugOutForInputReciepeTypeFormViewModel.allDrugSpecification = true;
    //     }



    //     this.DrugOutForRecipeTypeFormViewModel.VademecumList = this.VademecumList;
    // }

   
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