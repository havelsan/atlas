import { Component, OnInit, ViewChild } from '@angular/core';
import { ServiceContainer } from 'app/Fw/Services/ServiceContainer';
import { BaseComponent } from 'app/Fw/Components/BaseComponent';
import { MainViewModel } from 'app/Logistic/Models/MainViewModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';
import { DxAccordionComponent } from 'devextreme-angular';
import { MKYS_EMalzemeGrupEnum } from 'app/NebulaClient/Model/AtlasClientModel';
import DateTime from 'app/NebulaClient/System/Time/DateTime';
import { Convert } from 'app/NebulaClient/Mscorlib/Convert';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { IActiveUserService } from 'app/Fw/Services/IActiveUserService';
import { EntryTicketModel } from './CreateEntryTicketComponent';
import { StockActionService, GetInPatientPhysicianApplications_Output } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DynamicComponentInfoDVO } from 'app/Logistic/Models/LogisticMainViewModel';

@Component({
    selector: 'entry-ticket-list',
    templateUrl: './EntryTicketListComponent.html'
})

export class EntryTicketListComponent extends BaseComponent<MainViewModel> implements OnInit {
    budgetTypeSource: any[] = [];
    model: StockActionQueryModel;
    supplierGridDataSource: DataSource;
    stockActionDataSource: StockActionDataModel[];
    selectedCompanyItem: any;
    selectedSupplierItem: any;
    selectedMaterialItem: any;
    isSupplierOpened: boolean = false;
    showMaterialSelectGrid: boolean = false;
    isCompanyOpened: boolean = false;
    isCreate: boolean = false;
    materialDataSource: DataSource;
    materialGroup: MKYS_EMalzemeGrupEnum;
    askForMaterialGroup: boolean = false;
    stateSource: any[] = [
        {
            ObjectID: 0,
            Name: 'Tümü'
        },
        {
            ObjectID: 1,
            Name: 'MKYS\'ye Gönderilenler'
        },
        {
            ObjectID: 2,
            Name: 'MKYS\'ye Gönderilmeyenler'
        },
        {
            ObjectID: 3,
            Name: 'Alma Bildirimi Olanlar'
        },
        {
            ObjectID: 4,
            Name: 'Alma Bildirimi Olmayanlar'
        },
        {
            ObjectID: 5,
            Name: 'İptaller'
        },
    ];
    @ViewChild('topAccordion') accordion: DxAccordionComponent;

    constructor(container: ServiceContainer, protected httpService: NeHttpService, protected activeUserService: IActiveUserService) {
        super(container);
    }

    ngOnInit() {
        this.reloadModel();
        this.activeUserService.onStoreChangeEvent.subscribe(() => {
            this.model.StoreID = this.activeUserService.SelectedUserStore.ObjectID;
        });
    }

    onEditClose() {
        this.accordion.instance.expandItem(0);
        this.isCreate = false;
    }

    reloadModel(){
        this.model = new StockActionQueryModel();
        this.model.StoreID = this.activeUserService.SelectedUserStore.ObjectID;
        let now: Date = new Date();
        this.model.StartDate = Convert.ToDateTime(now);
        this.model.EndDate = Convert.ToDateTime(now);
    }

    clientPreScript(): void {
    }
    clientPostScript(state: String): void {
    }

    getData() {
        this.httpService.post('/api/EntryOperation/GetStockActionInData', this.model).then(p => {
            if (p) {
                this.stockActionDataSource = p as StockActionDataModel[];
            }
        }).catch(e => {
            ServiceLocator.MessageService.showError("Veri getirilirken hata oluştu.")
        })
    }

    clearForm(){
        this.reloadModel();
    }

    budgetTypeOpened() {
        if (this.budgetTypeSource.length == 0) {
            this.getBudgetTypes();
        }
    }

    createScreen(isEdit) {
        this.askForMaterialGroup = isEdit;
        this.accordion.instance.collapseItem(0);
        this.isCreate = true;
        StockActionService.onCreateClicked.emit();
    }

    getBudgetTypes() {
        this.httpService.get<any>('/api/EntryOperation/GetBudgetTypes').then(p => {
            if (p) {
                for (var item of p) {
                    this.budgetTypeSource.push({
                        ObjectID: item.ObjectID,
                        Name: item.Name,
                        Code: item.Code
                    });
                }
            }
        }).catch(e => console.log(e));
    }

    selectSupplier(e) {
        var component = e.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        this.selectedSupplierItem = e.data;
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code 
            this.model.Supplier = e.data.Name;
            this.model.SupplierId = e.data.ObjectID;
            this.isSupplierOpened = false;
        }
    }
    selectCompany(e) {
        var component = e.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        this.selectedCompanyItem = e.data;
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code 
            this.model.Accountancy = e.data.Name;
            this.model.AccountancyId = e.data.ObjectID;
            this.isCompanyOpened = false;
        }
    }

    setSupplier() {
        if (this.selectedSupplierItem) {
            this.model.Supplier = this.selectedSupplierItem.Name;
            this.model.SupplierId = this.selectedSupplierItem.ObjectID;
        }
        this.isSupplierOpened = false;
    }

    setCompany() {
        if (this.selectedCompanyItem) {
            this.model.Accountancy = this.selectedCompanyItem.Name;
            this.model.AccountancyId = this.selectedCompanyItem.ObjectID;
        }
        this.isCompanyOpened = false;
    }

    getSuppliers() {
        this.supplierGridDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'SupplierList'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.httpService.post<any>('/api/EntryOperation/GetSuppliers', loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    onEditClick(event) {
        var component = event.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code  
            this.askForMaterialGroup = true;
            this.createScreen(true);
            let queryString = 'StockActionObjectDefID=' + event.data.StockActionObjectDefID + '&StockActionObjectID=' + event.data.StockActionObjectID;
            this.httpService.get('/api/EntryOperation/GetStockAction?' + queryString).then(p => {
                if(p) {
                    let response = p as EntryTicketModel;
                    StockActionService.onRowClicked.emit({model: response});
                }
            }).catch(e => {
                ServiceLocator.MessageService.showError('Veri getirilemedi.');
            });
        }
    }



    openCompanyList() {
        this.isSupplierOpened = true;
        this.getSuppliers();
    }

    openCompanyFromList() {
        this.isCompanyOpened = true;
        this.getSuppliers();
    }

    selectMaterial(e) {
        var component = e.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        this.selectedMaterialItem = e.data;
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code  
            this.setMaterial();
        }
    }

    setMaterial() {
        if (this.selectedMaterialItem) {
            this.model.MaterialName = this.selectedMaterialItem.Name;
            this.model.Material = this.selectedMaterialItem.ObjectID;
        }
        this.showMaterialSelectGrid = false;
    }

    openMaterialList() {
        this.showMaterialSelectGrid = true;
        this.getMaterialDataSource();
    }

    getMaterialDataSource() {
        this.materialDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'MaterialList'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.httpService.post<any>('/api/EntryOperation/GetMaterialList?materialGroup=' + this.materialGroup, loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    public async findPatientClick() {

        let inApps: Array<GetInPatientPhysicianApplications_Output> = await StockActionService.GetInPatientPhysicianApplications(this.model.PatientProtocolNumber);
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();

        let count: number = 0;
        for (let inApp of inApps) {
            multiSelectForm.AddMSItem(inApp.Key, inApp.Key, inApp);
            count++;
        }

        let mlotKey: string = await multiSelectForm.GetMSItem(null, "Yatış Seçiniz", true);
        if (multiSelectForm.MSSelectedItemObject !== null) {
            let selectedInApp: GetInPatientPhysicianApplications_Output = multiSelectForm.MSSelectedItemObject as GetInPatientPhysicianApplications_Output;
            if (selectedInApp.InvoiceControl == false) {
                this.model.InPatientPhysicianApplication = selectedInApp.InPatientPhysicianApplication.ObjectID;
                this.model.PatientProtocolNumber = selectedInApp.PatientInfo;
            } else {
                TTVisual.InfoBox.Alert("Seçilen Hastanın Faturası Kesilmiştir. Önce Faturanın İptali Gerekmektedir");
            }
        }
    }
}

export class StockActionQueryModel {
    StartDate: Date;
    EndDate: Date;
    TIFNumber: number;
    OperationNumber: number;
    BillNumber: number;
    BudgetType: Guid;
    Supplier: string;
    SupplierId: Guid;
    AccountancyId: Guid;
    Accountancy: string;
    Material: Guid;
    MaterialName: string;
    State: number;
    PatientSpecial: boolean;
    PatientProtocolNumber: string;
    StockHareketId: Guid;
    ReceiptNumber: number;
    StoreID: Guid;
    RecordType: number;
    InPatientPhysicianApplication: Guid;
}

export class StockActionDataModel {
    StockActionObjectDefID: Guid;
    StockActionObjectID: Guid;
    StockActionID: string;
    Store: string;
    DestinationStore: string;
    CurrentStateDefID: string;
    ReceiptNumber: string;
    TransactionDate: string;
    PatientNameSurname: string;
    PatientProtocolNumber: string;
    TIFNumber: string;
    State: string;
}