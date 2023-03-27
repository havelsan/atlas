import { Component, Input, ViewChild } from '@angular/core';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "app/Fw/Services/MessageService";
import { IModalService } from "app/Fw/Services/IModalService";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { DrugListInputDTO, DrugList } from './DrugAtcReportViewModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { DxDropDownBoxComponent } from 'devextreme-angular';

@Component({
    selector: "DrugAtcReport",
    templateUrl: './DrugAtcReport.html',
    providers: [SystemApiService, MessageService]
})

export class DrugAtcReport {
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz';
    private _StoreObjectId: string;
    public showLoadPanel: boolean;
    public TotalNumberOfRows:number;
    public drugLists:Array<DrugList>= new Array<DrugList>();
    @ViewChild('atcList') atcList: DxDropDownBoxComponent;

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
            caption: 'ATC Adı',
            dataField: 'ATCName',
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

    public onClearAtc(event: any) {
        if (event != null && event.value != null) {
           
        }
        else {
            this.selectedAtcTermDefItem = {};
        }
    }

    atcDefDataSource: DataSource;
    getATCDefDataSource() {
        this.atcDefDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'ATCList'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 50;
                    }
                    return this.httpService.post<any>('/api/DrugAtcReportService/GetAtcDefList', loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    openAtcDefDropDown() {
        this.getATCDefDataSource();
    }

    selectedAtcTermDefItem: any = {};
    selectAtcTermDef(e) {
        var component = e.component;
        component.lastClickTime = new Date();
        this.selectedAtcTermDefItem = e.data;
        this.atcList.instance.close();
    }

    async GetDrugList() {
        try {
            this.showLoadPanel = true;
            let input: DrugListInputDTO = new DrugListInputDTO();
            if (this.selectedAtcTermDefItem != null)
                input.atcID = this.selectedAtcTermDefItem.ObjectID;
            input.storeID = this._StoreObjectId;

            let apiUrl: string = 'api/DrugAtcReportService/GetDrugList';
            this.httpService.post<Array<DrugList>>(apiUrl, input).then(
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