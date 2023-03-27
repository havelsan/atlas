import { Component, OnInit, Input, AfterViewInit, ViewChild, Output, EventEmitter } from "@angular/core";
import { MessageService } from "app/Fw/Services/MessageService";
import { SystemApiService } from "app/Fw/Services/SystemApiService";
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { PricingListDefinition, PricingListGroupDefinition, CurrencyTypeDefinition, Store, ProcedureDefinition, Material } from "app/NebulaClient/Model/AtlasClientModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DxDataGridComponent, DxDropDownBoxComponent } from "devextreme-angular";
import { ShowBox } from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ShowBoxTypeEnum } from "app/NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import { Type } from "app/NebulaClient/ClassTransformer";
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import { MessageIconEnum } from "app/NebulaClient/Utils/Enums/MessageIconEnum";

@Component({
    selector: 'procedure-material-matching-form',
    templateUrl: './ProcedureMaterialMatchingForm.html',
    providers: [MessageService, SystemApiService]
})
export class ProcedureMaterialMatchingForm implements OnInit, AfterViewInit {
    matchingViewModel: MatchingFormViewModel = new MatchingFormViewModel();
    disableControl: boolean = false;

    @Input() set ProcedureDefInfo(propVal: any) {
        this._procedureDefInfo = propVal;
        if (this._procedureDefInfo != null) {
            this.CreateListDataSources();
            this.selectedProcedure = this._procedureDefInfo;
        }
    }

    get ProcedureDefInfo(): any {
        return this._procedureDefInfo;
    }

    public _procedureDefInfo: any;
    public stores: Array<Store> = new Array<Store>();
    public selectedStore: Store;
    public materialListFilter: string = "";
    public materialAmount: number;
    public selectedProcedure: ProcedureDefinition;
    public MatchingGridColumns = [
        {
            caption: i18n("M19030", "Malzeme"),
            dataField: 'Material.Name',
            dataType: 'string',
            allowEditing: false,
            width: 250
        },
        {
            caption: i18n("M17462", "Miktar"),
            dataField: 'Amount',
            dataType: 'number',
            allowEditing: false,
            width: 250
        },
        {
            caption: i18n("M17462", "Depo"),
            dataField: 'Store.Name',
            dataType: 'string',
            allowEditing: false,
            width: 250
        }
    ];



    constructor(private http: NeHttpService) {
    }

    public async CreateListDataSources() {
        try {
            let apiUrl: string = '/api/ProcedureDefinitionService/GetStoresForMaterialMatching?ProcedureID=' + this.ProcedureDefInfo.ObjectID;
            await this.http.post<MatchingFormViewModel>(apiUrl, "").then(result => {
                if (result != null)
                    this.matchingViewModel = result;
                this.stores = result.stores;
                this.disableControl = true;
            });
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    public GenerateColumns() {

    }

    public async selectedStoreChange() {
        if (this.selectedStore) {
            this.materialListFilter = 'THIS.OBJECTDEFNAME IN (\'CONSUMABLEMATERIALDEFINITION\',\'DRUGDEFINITION\') ';

            if (this.selectedStore.ObjectID == null) {
                this.materialListFilter = this.materialListFilter + ' AND STOCKS.INHELD>0 AND STOCKS.STORE = \'' + await this.selectedStore + '\'';
            } else {
                this.materialListFilter = this.materialListFilter + ' AND STOCKS.INHELD>0 AND STOCKS.STORE = \'' + await this.selectedStore.ObjectID.toString() + '\'';
            }
            //}
        } else {
            this.materialListFilter = '1=0';
        }
    }


    async ngOnInit() {
    }


    ngAfterViewInit(): void {

    }

    selectedMaterialItem: any = {};
    public onClearMaterial(event: any) {
        if (event != null && event.value != null) {

        }
        else {
            this.selectedMaterialItem = {};
        }
    }

    openMaterialDropDown(e: any) {
        this.getMaterialDataSource();
    }

    materialDataSource: DataSource;
    getMaterialDataSource() {
        this.materialDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'AllowedConsumableMaterialAndDrugList'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.http.post<any>('/api/TreatmentMaterialService/GetMaterialList?storeID=' + this.materialListFilter, loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    @ViewChild('materialDrop') materialDrop: DxDropDownBoxComponent;
    selectMaterial(e) {
        var component = e.component;
        component.lastClickTime = new Date();
        this.selectedMaterialItem = e.data;
        this.materialDrop.instance.close();
    }

    public matchingDataSource: Array<ProcedureMaterialMatchData> = new Array<ProcedureMaterialMatchData>();
    public AddOrUpdateMatching() {

        if (this.selectedStore == null) {
            ServiceLocator.MessageService.showError("Depo seçimi yapınız");
            return;
        }

        if (this.selectedMaterialItem.ObjectID == null) {
            ServiceLocator.MessageService.showError("Hizmet ile eşleşecek malzemeyi seçiniz");
            return;
        }

        if (this.materialAmount == null) {
            ServiceLocator.MessageService.showError("Miktar alanı boş bırakılamaz");
            return;
        }
        let that = this;
        let requestString: string = "";
        let storeID: Guid;
        let materialID: Guid;
        let procedureID: Guid;
        if(typeof this.selectedStore == "string"){
            storeID = new Guid(this.selectedStore);
        }
        else{
            storeID = this.selectedStore.ObjectID;
        }
        if(typeof this.selectedMaterialItem == "string"){
            materialID = new Guid(this.selectedMaterialItem);
        }
        else{
            materialID = this.selectedMaterialItem.ObjectID;
        }
        if(typeof this.selectedProcedure == "string"){
            procedureID = new Guid(this.selectedProcedure);
        }
        else{
            procedureID = this.selectedProcedure.ObjectID;
        }
        if (this.selectedMatching == null)
            requestString = "api/ProcedureDefinitionService/SaveOrUpdateMatch?ProcedureID=" + procedureID + "&MaterialID=" + materialID + "&StoreID=" + storeID + "&Amount=" + this.materialAmount;
        else {
            requestString = "api/ProcedureDefinitionService/SaveOrUpdateMatch?ProcedureID=" + procedureID + "&MaterialID=" + materialID + "&StoreID=" + storeID + "&Amount=" + this.materialAmount + "&MatchObjectID=" + this.selectedMatching.MatchID;
        }
        that.http.get<Array<ProcedureMaterialMatchData>>(requestString)
            .then(response => {
                that.matchingDataSource = response;
                that.matchingViewModel.matches = response;
                ServiceLocator.MessageService.showSuccess("İşlem başarılı bir şekilde kaydedildi");
                this.LoadObject(that.matchingViewModel.matches);
                this.createNewMatchData();
                //    this.createNewMatchingData();
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);

            });
    }

    public LoadObject(list: Array<ProcedureMaterialMatchData>) {
        for (let item of list) {
            let storeObjectID = item['Store'];
            if (storeObjectID != null && (typeof storeObjectID === 'string')) {
                let match = this.matchingViewModel.matches.find(o => o.Store.ObjectID.toString() === storeObjectID.toString());
                if (match) {
                    item.Store = match.Store;
                }
            }
            let materialObjectID = item['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let matchObj = this.matchingViewModel.matches.find(o => o.Material.ObjectID.toString() === materialObjectID.toString());
                if (matchObj) {
                    item.Material = matchObj.Material;
                }
            }
        }
    }

    public createNewMatchData() {
        this.selectedMatching = null;
        this.selectedStore = null;
        this.selectedMaterialItem = new Object();
        this.materialAmount = null;
    }

    public deleteMatchData() {
        if (this.selectedMatching == null) {
            ServiceLocator.MessageService.showInfo('Lütfen silinecek kaydı seçiniz');
            return;
        }

        const confirmResult = confirm('Seçilen kayıt silinecek. Devam etmek istiyor musunuz?');
        if (confirmResult === false) {
            return;
        }

        let requestString = "api/ProcedureDefinitionService/DeleteMatchObject?MatchObjectID=" + this.selectedMatching.MatchID + "&ProcedureID=" + this._procedureDefInfo.ObjectID;
        let that = this;
        that.http.get<Array<ProcedureMaterialMatchData>>(requestString)
            .then(response => {
                that.matchingDataSource = response;
                that.matchingViewModel.matches = response;
                ServiceLocator.MessageService.showSuccess("Kayıt başarı ile silindi")
                this.LoadObject(that.matchingViewModel.matches);
                this.createNewMatchData();
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);

            });
    }

    public selectedMatching: ProcedureMaterialMatchData;
    public async onMatchingGridRowClick(event) {
        this.selectedMatching = event.data;
        this.selectedStore = event.data.Store;
        this.selectedMaterialItem = event.data.Material;
        this.materialAmount = event.data.Amount;
    }

}

export class ProcedureMaterialMatch {
    @Type(() => ProcedureDefinition)
    public Procedure: ProcedureDefinition;
    @Type(() => Material)
    public Material: Material;
    @Type(() => Store)
    public Store: Store;
    public Amount: number;
}

export class ProcedureMaterialMatchData {
    public MatchID: Guid;
    @Type(() => Material)
    public Material: Material;
    @Type(() => Store)
    public Store: Store;
    public Amount: number;
}

export class MatchingFormViewModel {
    @Type(() => Store)
    public stores: Array<Store>;
    public matches: Array<ProcedureMaterialMatchData>;
}