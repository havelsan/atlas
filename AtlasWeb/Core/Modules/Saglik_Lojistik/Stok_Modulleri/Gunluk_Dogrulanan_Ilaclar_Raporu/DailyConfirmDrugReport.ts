import { Component, Input, ViewChild } from '@angular/core';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "app/Fw/Services/MessageService";
import { IModalService } from "app/Fw/Services/IModalService";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { DrugSpecificationEnum, ResClinic, ActiveIngredientDefinition } from 'app/NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { Headers, RequestOptions } from '@angular/http';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { DrugOrderDailyConf } from './DailyConfirmDrugReportViewModel';
import { DxDropDownBoxComponent } from 'devextreme-angular';

@Component({
    selector: "DailyConfirmDrugReport",
    templateUrl: './DailyConfirmDrugReport.html',
    providers: [SystemApiService, MessageService]
})

export class DailyConfirmDrugReport {
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz...';
    private _StoreObjectId: string;
    public showLoadPanel: boolean;
    selectedDrugDefItem: any = {};
    public StartDate: Date;
    public SelectedDoctorListItems: Array<any> = new Array<any>();
    public DoctorList;
    MasterResourceList: Array<ResClinic>;
    masterResourceIDList: Array<Guid> = new Array<Guid>();
    doctorIDList: Array<Guid> = new Array<Guid>();
    DrugIDList: Array<Guid> = new Array<Guid>();
    public TotalNumberOfRows: number;
    public statusID: number;
    DrugOrderDataSource: Array<DrugOrderDailyConf> = new Array<DrugOrderDailyConf>();
    @ViewChild('drugDrop') drugDrop:DxDropDownBoxComponent;

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
        this.setDefaultDates();
        this.FillDataSources();

    }

    public setDefaultDates() {
        this.StartDate = new Date();
        this.StartDate.setHours(0, 0, 0, 0);

    }

    async ngOnInit() {

    }

    DrugOrderDataColumns = [
        {
            caption: "Barkodu",
            dataField: 'Barcode',
        },
        {
            caption: "İlaç Adı",
            dataField: 'DrugName',
        },
        {
            caption: "Kabul No",
            dataField: 'ProtocolNo',
        },
        {
            caption: "Hasta Adı Soyadı",
            dataField: 'PatientNameSurname',
        },
        {
            caption: "Order Tarihi",
            dataField: 'PlannedStartTime',
        },
        {
            caption: "Doz Aralığı",
            dataField: 'Frequency',
        },
        {
            caption: "Miktar",
            dataField: 'DoseAmount',
        },
        {
            caption: "Klinik",
            dataField: 'Clinic',
        },
        {
            caption: "Doktor",
            dataField: 'DoctorName',
        },
        {
            caption: "Durumu",
            dataField: 'State',
        },
    ];

    selectBoxValue: any[] = [{
        "ID": 1,
        "Name": "Doğrulanan İlaçlar",
    }, {
        "ID": 2,
        "Name": "Doğrulanmayan İlaçlar",
    }, {
        "ID": 3,
        "Name": "Durdurulan İstemler",
    }, {
        "ID": 4,
        "Name": "Uygulanmayan İlaçlar",
    }, {
        "ID": 5,
        "Name": "Tamamlanmış İlaçlar",
    }
    ];


    openDrugDefDropDown() {
        this.getDrugDefDataSource();
    }

    public onClearDrug(event: any) {
        if (event != null && event.value != null) {

        }
        else {
            this.selectedDrugDefItem = {};
            this.DrugIDList = new Array<Guid>();
        }
    }

    public onClearSelectBoxValue(event: any) {
        if (event != null && event.value != null) {

        }
        else {
            this.statusID = 0;
        }
    }

    drugDefDataSource: DataSource;
    getDrugDefDataSource() {
        this.drugDefDataSource = new DataSource({
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
                    return this.httpService.post<any>('/api/DailyConfirmDrugReportService/GetDrugDefinitionList', loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    selectDrugDef(e) {
        var component = e.component;
        component.lastClickTime = new Date();
        this.selectedDrugDefItem = e.data;
        this.DrugIDList.push(this.selectedDrugDefItem.ObjectID);
        this.drugDrop.instance.close();
    }


    public onMasterResourceSelectionChanged(data) {
        if (data.addedItems.length > 0) {
            this.masterResourceIDList.push(data.addedItems[0].ObjectID);
        }
        else if (data.removedItems.length > 0) {
            this.masterResourceIDList.splice(this.masterResourceIDList.findIndex(x => x.Equals(data.removedItems[0].ObjectID)), 1);
        }
    }


    async FillDataSources() {
        try {
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/DailyConfirmDrugReportService/FillDataSources';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.DoctorList = result.DoctorList;
                    this.MasterResourceList = result.MasterResourceList;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public onDoctorSelectionChanged(data) {
        if (data.addedItems.length > 0) {
            this.doctorIDList.push(data.addedItems[0].ObjectID);
        }
        else if (data.removedItems.length > 0) {
            this.doctorIDList.splice(this.doctorIDList.findIndex(x => x.Equals(data.removedItems[0].ObjectID)), 1);
        }
    }

    public GetDrugList() {
        try {
            this.showLoadPanel = true;
            let that = this;
            if (this.statusID == null) {
                this.statusID = 0;
            }
            let apiUrlForPASearchUrl: string = '/api/DailyConfirmDrugReportService/GetDrugOrderDailyConf';
            let body = { 'StartDate': this.StartDate, 'DoctorIDList': this.doctorIDList, 'DrugIDList': this.DrugIDList, 'ServiceIDList': this.masterResourceIDList, 'StatusID': this.statusID };
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            this.httpService.post<Array<DrugOrderDailyConf>>(apiUrlForPASearchUrl, body).then(response => {
                this.DrugOrderDataSource = response;
                this.TotalNumberOfRows = this.DrugOrderDataSource.length;
                this.showLoadPanel = false;
            }).catch(error => {
                this.showLoadPanel = false;
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }
        catch (ex) {
            this.showLoadPanel = false;
            ServiceLocator.MessageService.showError("Hata : " + ex);
        }
    }


}