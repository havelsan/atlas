import { Component, ViewChild, OnInit, Input, EventEmitter, Renderer2 } from '@angular/core';
import { Headers, RequestOptions } from '@angular/http';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SystemApiService } from 'Fw/Services/SystemApiService';

import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { PatientBasedMaterialSelectFormViewModel } from './PatientBasedMaterialSelectFormViewModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { DxDataGridComponent } from 'devextreme-angular';

@Component({
    selector: 'PatientBasedMaterialSelectForm',
    templateUrl: 'PatientBasedMaterialSelectForm.html',
    providers: [MessageService, SystemApiService],
    outputs: ['SelectedMaterialsChanged']

})

export class PatientBasedMaterialSelectForm extends TTUnboundForm implements OnInit {

    public DrugActiveIngredientList: TTVisual.ITTObjectListBox;
    public ActiveSubstanceList: Array<Material> = new Array<Material>();
    public SelectedActiveSubstance: Material = null;
    public MaterialList: Array<Material> = new Array<Material>();
    public MaterialList_Muadil: Array<Material> = new Array<Material>();
    public Name: string;
    public selectedRows: Array<Material> = new Array<Material>();
    public selectedRowElements: Array<any> = new Array<any>();
    public selectionChangedBySelectbox: boolean;
    public SelectedMaterialsChanged: EventEmitter<Array<Material>> = new EventEmitter<Array<Material>>();
    public PatientBasedMaterialSelectFormViewModel: PatientBasedMaterialSelectFormViewModel = new PatientBasedMaterialSelectFormViewModel();
    private MaterialMultiSelectForm_DocumentUrl: string = '/api/PatientBasedMaterialSelectService/PatientBasedMaterialSelectForm';

    @ViewChild('materialGrid') materialGrid: DxDataGridComponent;

    constructor(protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, private renderer: Renderer2) {
        super('MaterialMultiSelect', 'MaterialMultiSelectForm');

        this.DrugActiveIngredientList = new TTVisual.TTObjectListBox();
        this.DrugActiveIngredientList.ListFilterExpression = "";
        this.DrugActiveIngredientList.ListDefName = "ActiveIngredientList";
        this.DrugActiveIngredientList.Name = "DrugActiveIngredientList";
        this.DrugActiveIngredientList.TabIndex = 4;
        this._CanZeroMaterialSelect = false;
        this.initViewModel();
    }

    public initViewModel(): void {
        this.PatientBasedMaterialSelectFormViewModel = new PatientBasedMaterialSelectFormViewModel();
    }

    async ngOnInit() {
    }
    ////
    private _ShowMuadilMedicineFilter: boolean = false;
    @Input() set ShowMuadilMedicineFilter(object: boolean) {
        if (object != null && this._ShowMuadilMedicineFilter != object) {
            this._ShowMuadilMedicineFilter = object;
        }
    }

    get ShowMuadilMedicineFilter(): boolean {
        return this._ShowMuadilMedicineFilter;
    }
    ////
    ///////

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
    ////


    ////
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
    ////

    private _CanZeroMaterialSelect: boolean;
    @Input() set CanZeroMaterialSelect(object: boolean) {
        if (object != null && this._CanZeroMaterialSelect != object){
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
        if (this.selectedRows != null && this.selectedRows.length > 0) {
            this.SelectedMaterialsChanged.emit(this.selectedRows);
            this.selectedRows.Clear();
            this.selectedRowElements.forEach(element => {
                //element.css({ "background-color": "#fff" });
                this.renderer.setStyle(element, "background-color", "#fff");
            });
            this.selectedRowElements.Clear();
            this.materialGrid.instance.refresh();


        }
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

                await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
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
    HideAllZeroStock_event(event: any) {

        if (this.HideAllZeroStock) {
            this.materialGrid.instance.filter(['Inheld', '>', 0]);
        } else {
            this.materialGrid.instance.clearFilter();
        }

    }


    selectionChangedHandler(event) {
        if (!this.selectionChangedBySelectbox) {
            this.Name = null;

        }
        this.selectionChangedBySelectbox = false;
    }

    onRowClick(event: any) {
        if (event == null) {

        } else if (event.data != null) {
            let material: any = event.data;

            if (this._CanZeroMaterialSelect === false && material.Inheld <= 0){
                ServiceLocator.MessageService.showError(material.Name + " adlı malzemenin depo mevcudu 0'dır. Lütfen muadillerini kontrol ediniz!");
            }
            else {


                let isInsert: boolean = true;
                let isIndexFound: boolean = false;
                let index = 0;
                this.selectedRows.forEach(element => {

                    if (element.ObjectID == material.ObjectID) {
                        isInsert = false;
                        isIndexFound = true;
                    }

                    if (isIndexFound == false)
                        index++;
                });

                if (isInsert) {
                    this.selectedRows.push(material);
                    this.selectedRowElements.push(event.rowElement.firstItem());
                    //event.rowElement.firstItem().css({ "background-color": "#99e2ff" });
                    this.renderer.setStyle(event.rowElement.firstItem(), "background-color", "#99e2ff");
                }
                else {
                    //event.rowElement.firstItem().css({ "background-color": "#fff" });
                    this.renderer.setStyle(event.rowElement.firstItem(), "background-color", "#fff");
                    this.selectedRowElements.splice(index, 1);
                    this.selectedRows.splice(index, 1);
                }
            }
            this.materialGrid.instance.refresh();
        }
    }

    onRowPrepared(event) {
        if (event == null) {

        } else {
            let material: Material = event.data;
            let index = 0;
            if (material != null) {
                this.selectedRows.forEach(element => {
                    if (element.ObjectID == material.ObjectID) {
                        //event.rowElement.firstItem().css({ "background-color": "#99e2ff" });
                        this.renderer.setStyle(event.rowElement.firstItem(), "background-color", "#99e2ff");
                    }
                });
            }
        }
    }

    PatientObjectID: Guid;
    patientChanged(patient: any) {
        if (patient != undefined)
            this.PatientObjectID = patient.ObjectID;
        if (patient == null || patient == undefined)
            this.PatientObjectID = Guid.empty();
    }
    async GetMaterialListWithFilter(substanceMaterialId: Guid) {

        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/MaterialMultiSelectService/MaterialListByStore';
            let body = { 'StoreObjectId': this._StoreObjectId, "PatientObjectID": this.PatientObjectID };
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.MaterialList = result;
                    this.MaterialList_Muadil = result;
                    this.HideAllZeroStock = false;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public async onActiveSubstanceChanged(event) {

        if (event != null) {
            this.GetMaterialListWithFilter(event.ObjectID);
        } else {
            this.GetMaterialListWithFilter(Guid.Empty);
        }

    }

}