import { Component, Input, ViewChild } from '@angular/core';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "app/Fw/Services/MessageService";
import { IModalService } from "app/Fw/Services/IModalService";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';

import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { DrugListGeneric, DrugGenericListInputDTO } from './DrugGenericReportViewModel';
import { DxDropDownBoxComponent } from 'devextreme-angular';

@Component({
    selector: "DrugGenericReport",
    templateUrl: './DrugGenericReport.html',
    providers: [SystemApiService, MessageService]
})

export class DrugGenericReport {
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz';
    private _StoreObjectId: string;
    public showLoadPanel: boolean;
    public TotalNumberOfRows:number;
    public drugLists:Array<DrugListGeneric>= new Array<DrugListGeneric>();

    @ViewChild('genericDrug') genericDrug:DxDropDownBoxComponent;
    

    @Input() set SelectedMainStore(value: any) {
        if (value != null && value != undefined)
            this._StoreObjectId = value.ObjectID;
    }
    get SelectedMainStore(): any {
        return this._StoreObjectId;
    }

    constructor(protected httpService: NeHttpService, private reportService: AtlasReportService, protected messageService: MessageService, public systemApiService: SystemApiService, private modalService: IModalService) {
        this.initViewModel();
    }

    public initViewModel(): void {

    }

    async ngOnInit() {

    }

    public setDefaultDates() {

    }

    DrugListColumn = [
        {
            caption: 'Jenerik Adı',
            dataField: 'GenericName',
            groupIndex: "0",
        },
        {
            caption: 'İlaç Barkodu',
            dataField: 'Barcode',
        },
        {
            caption: 'İlaç Adı',
            dataField: 'DrugName',
        },
        {
            caption: 'Depo Mitarı',
            dataField: 'Inheld',
        },
    ];

    public onClearGeneric(event: any) {
        if (event != null && event.value != null) {
           
        }
        else {
            this.selectedGenericItem = {};
        }
    }

    genericDefDataSource: DataSource;
    GetDrugGenericList() {
        this.genericDefDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'DrugGenericList'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 50;
                    }
                    return this.httpService.post<any>('/api/DrugGenericReportService/GetDrugGenericList', loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    openGenericDefDropDown() {
        this.GetDrugGenericList();
    }

    selectedGenericItem: any = {};
    selectGeneric(e) {
        var component = e.component;
        component.lastClickTime = new Date();
        this.selectedGenericItem = e.data;
        this.genericDrug.instance.close();
    }

    async GetDrugList() {
        try {
            this.showLoadPanel = true;
            let input: DrugGenericListInputDTO = new DrugGenericListInputDTO();
            if (this.selectedGenericItem != null)
                input.genericID = this.selectedGenericItem.ObjectID;
            input.storeID = this._StoreObjectId;

            let apiUrl: string = 'api/DrugGenericReportService/GetDrugList';
            this.httpService.post<Array<DrugListGeneric>>(apiUrl, input).then(
                result => {
                    this.drugLists = result;
                    this.TotalNumberOfRows = result.length;
                    this.showLoadPanel = false;

                }).catch(error => {
                    ServiceLocator.MessageService.showError(error);
                    this.showLoadPanel = false;
                });
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
            this.showLoadPanel = false;
        }
    }

}