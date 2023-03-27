import { Component, ViewChild, OnInit, Input, EventEmitter, Renderer2 } from '@angular/core';
import { Headers, RequestOptions } from '@angular/http';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { MaterialMultiSelectFormViewModel } from './MaterialMultiSelectFormViewModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { DxDataGridComponent } from 'devextreme-angular';
import { Observable } from 'rxjs'; // Angular 5
import { Subscription } from 'rxjs';
import { interval } from 'rxjs';
import { ActiveIngredientDefinition } from "app/NebulaClient/Model/AtlasClientModel";
import { DxSelectBoxModule } from "devextreme-angular";
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';

@Component({
    selector: 'MaterialMultiSelectForm',
    templateUrl: './MaterialMultiSelectForm.html',
    providers: [MessageService, SystemApiService],
    outputs: ['SelectedMaterialsChanged', 'SelectedMaterialsClear', 'CloseComponent']
})

export class MaterialMultiSelectForm extends TTUnboundForm implements OnInit {

    public DrugActiveIngredientList: TTVisual.ITTObjectListBox;
    public ActiveSubstanceList: Array<Material> = new Array<Material>();
    public SelectedActiveSubstance: Material = null;
    public MaterialList: Array<Material> = new Array<Material>();
    public MaterialList_Muadil: Array<Material> = new Array<Material>();
    public Name: string;
    public selectedRows: Array<Material> = new Array<Material>();
    public selectedRowElements: Array<any> = new Array<any>();
    private subscription: Subscription;
  //  public  ActiveIngredientList: Array<any> = new Array<any>();
    public selectionChangedBySelectbox: boolean;
    public SelectedMaterialsChanged: EventEmitter<Array<Material>> = new EventEmitter<Array<Material>>();
    public SelectedMaterialsClear: EventEmitter<any> = new EventEmitter<any>();
    public CloseComponent: EventEmitter<any> = new EventEmitter<any>();
    public MaterialMultiSelectFormViewModel: MaterialMultiSelectFormViewModel = new MaterialMultiSelectFormViewModel();
    private MaterialMultiSelectForm_DocumentUrl: string = '/api/MaterialMultiSelectService/MaterialMultiSelectForm';

    @ViewChild('materialGrid') materialGrid: DxDataGridComponent;
    public MaterialGridFilterList: Array<any> = new Array<any>();
    ActiveIngredientList: any;
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, private renderer: Renderer2) {
        super('MaterialMultiSelect', 'MaterialMultiSelectForm');

        this.DrugActiveIngredientList = new TTVisual.TTObjectListBox();
        this.DrugActiveIngredientList.ListFilterExpression = "";
        this.DrugActiveIngredientList.ListDefName = "ActiveIngredientList";
        this.DrugActiveIngredientList.Name = "DrugActiveIngredientList";
        this.DrugActiveIngredientList.TabIndex = 4;
        this._CanZeroMaterialSelect = false;
        this.initViewModel();     

        this.ActiveIngredientList = new DataSource({
            store: new CustomStore({
                key: "ObjectID",

                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'ActiveIngredientListDefinition'
                    }

                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }

                    return this.httpService.post<any>("/api/EquivalentMaterialConsumptionService/FillDataSources", loadOptions);

                },
            }),
            paginate: true,
            pageSize: 10
        })
           

        // async FillDataSources() {
        //     try {
        //         let that = this;
        //         let apiUrlForPASearchUrl: string = '/api/EquivalentMaterialConsumptionService/FillDataSources';
        //         let body = "";
        //         let headers = new Headers({ 'Content-Type': 'application/json' });
        //         let options = new RequestOptions({ headers: headers });
        //         if(this.ActiveIngredientList.length==0)
        //         await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
        //             let result = response;
        //             if (result) {
        //                 this.ActiveIngredientList = result;
        //             }
        //         }).catch(error => {
        //             ServiceLocator.MessageService.showError("Hata : " + error);
        //         });
                
        //     }
    
        //     catch (ex) {
        //         ServiceLocator.MessageService.showError(ex);
        //     }
        // }
    }

    public initViewModel(): void {
        this.MaterialMultiSelectFormViewModel = new MaterialMultiSelectFormViewModel();
    }

    async ngOnInit() {
    }

    private _ShowMuadilMedicineFilter: boolean = false;
    @Input() set ShowMuadilMedicineFilter(object: boolean) {
        if (object != null && this._ShowMuadilMedicineFilter != object) {
            this._ShowMuadilMedicineFilter = object;
        }
    }

    get ShowMuadilMedicineFilter(): boolean {
        return this._ShowMuadilMedicineFilter;
    }

    private _ExpendableMaterialFilter: boolean = false;
    @Input() set ExpendableMaterialFilter(object: boolean) {
        if (object != null && this._ExpendableMaterialFilter != object) {
            this._ExpendableMaterialFilter = object;
        }
    }

    get ExpendableMaterialFilter(): boolean {
        return this._ExpendableMaterialFilter;
    }

    private _StoreObjectId: string;
    @Input() set StoreObjectId(object: string) {
        if (object != null && this._StoreObjectId != object) {
            this._StoreObjectId = object;
            if (this._FilterByStockInheld != null && this._FilterByStockCard != null)
                this.GetMaterialListWithFilter(Guid.Empty);
        }
    }

    get StoreObjectId(): string {
        return this._StoreObjectId;
    }

    private _ClearListOnSave: boolean = false;
    @Input() set ClearListOnSave(object: boolean) {
        if (object != null && this._ClearListOnSave != object) {
            this._ClearListOnSave = object;
        }
    }

    get ClearListOnSave(): boolean {
        return this._ClearListOnSave;
    }


    private _ShowZeroOnDistributionInfo: boolean = false;
    @Input() set ShowZeroOnDistributionInfo(object: boolean) {
        if (object != null && this._ShowZeroOnDistributionInfo != object) {
            this._ShowZeroOnDistributionInfo = object;
            if (this._FilterByStockInheld != null && this._FilterByStockCard != null) {
                this.GetMaterialListWithFilter(Guid.Empty);
            }
        }
    }

    get ShowZeroOnDistributionInfo(): boolean {
        return this._ShowZeroOnDistributionInfo;
    }

    private _FilterByStockCard: boolean;
    @Input() set FilterByStockCard(object: boolean) {
        if (object != null && this._FilterByStockCard != object) {
            this._FilterByStockCard = object;
            if (this._FilterByStockInheld != null && this._StoreObjectId != null)
                this.GetMaterialListWithFilter(Guid.Empty);
        }
    }

    get FilterByStockCard(): boolean {
        return this._FilterByStockCard;
    }

    private _FilterByStockInheld: boolean;
    @Input() set FilterByStockInheld(object: boolean) {
        if (object != null && this._FilterByStockInheld != object) {
            this._FilterByStockInheld = object;
            if (this._StoreObjectId != null && this._FilterByStockCard != null)
                this.GetMaterialListWithFilter(Guid.Empty);

        }
    }

    get FilterByStockInheld(): boolean {
        return this._FilterByStockInheld;
    }

    private _CanZeroMaterialSelect: boolean;
    @Input() set CanZeroMaterialSelect(object: boolean) {
        if (object != null && this._CanZeroMaterialSelect != object) {
            this._CanZeroMaterialSelect = object;
            if (this._CanZeroMaterialSelect != null && this._CanZeroMaterialSelect != null)
                this.GetMaterialListWithFilter(Guid.Empty);
        }
    }

    get CanZeroMaterialSelect(): boolean {
        return this._CanZeroMaterialSelect;
    }


    async GetActiveSubstanceList() {

        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/MaterialMultiSelectService/GetDrugActiveIngredient';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.ActiveSubstanceList = result;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public EmitSelectedRows() {
        if (this.selectedRows != null) {
            this.SelectedMaterialsChanged.emit(this.selectedRows);
            if (this.ClearListOnSave) {
                this.selectedRowElements = [];
                this.selectedRows = [];
               // this.materialGrid.selectedRowKeys = [];
            }

           /* if (this.selectedRows.length > 0) {
                this.SelectedMaterialsChanged.emit(this.selectedRows);
                if (this.ClearListOnSave) {
                    this.selectedRowElements = [];
                    this.selectedRows = [];
                   // this.materialGrid.selectedRowKeys = [];
                }
            }
            else if (this.selectedRows.length == 0){
                this.messageService.showError("En az bir malzeme secmeniz gerekmektedir.");
            }*/
        }
    }

    public ClearSelectedRows() {
        this.selectedRowElements = [];
        this.selectedRows = [];
        this.SelectedMaterialsClear.emit();
        this.materialGrid.selectedRowKeys = [];
    }

    public Close() {
        this.CloseComponent.emit();
    }

    filterSelected(event) {
        this.selectionChangedBySelectbox = true;

        let Name = event.value;

        if (!Name)
            return;
        else if (Name === "All")
            this.selectedRows = this.MaterialList.map(material => material);
        else {
            this.selectedRows = this.MaterialList.filter(material => material.Name === Name).map(material => material);
        }

        this.Name = Name;
    }

    public async selectMuadilMedicineSelected(event) {
        if (event.value != null) {
            try {
                let that = this;
                let apiUrlForPASearchUrl: string = '/api/MaterialMultiSelectService/GetEquivalentDrug';
                let body = { 'storeObjectID': this._StoreObjectId, 'materialObjectID': event.value.toString() };
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: headers });

                await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(async response => {
                    let result = response;
                    if (result) {
                        this.MaterialList = result;
                        this.HideAllZeroStock = false;
                    }
                }).catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                });

            }
            catch (ex) {
                ServiceLocator.MessageService.showError(ex);
            }
        } else {
            this.GetMaterialListWithFilter(Guid.Empty);
        }

    }


    public HideAllZeroStock: boolean = false;
    async HideAllZeroStock_event(event: any) {
        this.subscription.unsubscribe();
        if (this.MaterialGridFilterList.length > 0)
            //this.materialGrid.instance.clearFilter();
        this.MaterialGridFilterList = new Array<any>();

        if (this.HideAllZeroStock) {
            this.MaterialGridFilterList.push(['Inheld', '>', 0]);
        }

        if (this.ShowZeroOnDistributionInfo) {
            this.MaterialGridFilterList.push(['ShowZeroOnDistributionInfo', '<>', true]);
        }

        // if (this.MaterialGridFilterList.length > 0) {
        //     this.materialGrid.instance.filter(this.MaterialGridFilterList);
        // }
    }


    selectionChangedHandler(event) {
        this.selectedRows = event.selectedRowsData;
    }

    public ShowMuadilMedicineFilterByStoreType:boolean;

    async GetMaterialListWithFilter(substanceMaterialId: Guid) {

        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/MaterialMultiSelectService/MaterialListByStore';
            let body = { 'StoreObjectId': this._StoreObjectId, 'SubstanceMaterialId': substanceMaterialId.toString(), 'FilterByStockInheld': this.FilterByStockInheld, 'FilterByStockCard': this.FilterByStockCard, 'FilterByExpendableMaterial': this.ExpendableMaterialFilter };
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    if(this.MaterialList)
                    {
                        this.MaterialList.Clear();
                    }
                    this.MaterialList = result.materialList;
                    this.MaterialList_Muadil = result.materialList;
                    this.HideAllZeroStock = true;
                    this.ShowMuadilMedicineFilterByStoreType = result.storeType;
                    this.visibleShowMuadilMedicineFilterByStoreType(this.ShowMuadilMedicineFilterByStoreType);
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
            this.subscription = interval(100).subscribe(x => {
                this.HideAllZeroStock_event(null);
            });
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public ShowActiveIngredientFilter:boolean = true;
    public visibleShowMuadilMedicineFilterByStoreType(storetype: boolean){
        this.ShowMuadilMedicineFilter = storetype;
        this.ShowActiveIngredientFilter = storetype;
    }

    public async onActiveSubstanceChanged(event) {

        if (event != null) {
            this.GetMaterialListWithFilter(event.ObjectID);
        } else {
            this.GetMaterialListWithFilter(Guid.Empty);
        }

    }
   
   
    public async selectActiveIngredient(e) {
        if (e.value != null) {
               
            this.GetMaterialListWithFilter(e.value);
            
        } else {
            this.GetMaterialListWithFilter(Guid.Empty);
        }

    }

}