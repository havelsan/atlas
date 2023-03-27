import { Component, Input } from '@angular/core';
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

@Component({
    selector: "ReceivedDrugReport",
    templateUrl: './ReceivedDrugReport.html',
    providers: [SystemApiService, MessageService]
})

export class ReceivedDrugReport {
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz...';
    private _StoreObjectId: string;
    public showLoadPanel: boolean;
    public TotalNumberOfRows: number;
    selectedDrugDefItem: any = {};
    public StartDate: Date;
    public EndDate: Date;
    public DrugSpecificationEnumDef;
    VademecumList: Array<number> = new Array<number>();
    public SelectedDoctorListItems :Array<any> = new Array<any>();
    public DoctorList;
    MasterResourceList: Array<ResClinic>;
    ActiveIngredientList: Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>;
    ActiveSubstanceIDList: Array<Guid> = new Array<Guid>();
    public SelectedActiveIngredients: Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> = new Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>();
    masterResourceIDList: Array<Guid> = new Array<Guid>();
    doctorIDList: Array<Guid> = new Array<Guid>();
    DrugIDList: Array<Guid> = new Array<Guid>();
    DrugList:any;

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
        this.DrugSpecificationEnumDef = DrugSpecificationEnum.Items;
        this.FillDataSources();
    }

    public setDefaultDates() {
        this.StartDate = new Date();
        this.StartDate.setHours(0, 0, 0, 0);
        this.EndDate = new Date();
        this.EndDate.setHours(23, 59, 59, 0);
    }

    async ngOnInit() {

    }

    public DrugListColumn = [
        {
            caption: "İşlem Tarihi",
            dataField: 'ActionDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowEditing: false,
            sortOrder: 'asc',
            width: 110,
        },
        {
            caption: 'Barkodu',
            dataField: 'Barcode',
            allowEditing: false,
            width: 150,
        },
        {
            caption: 'İlaç Adı',
            dataField: 'Name',
            allowEditing: false,
            width: 350,
        },
        {
            caption: 'Miktarı',
            dataField: 'Amount',
            allowEditing: false,
            width: 90,
        },
       
        {
            caption: 'Doktor',
            dataField: 'MKYS_TeslimAlan',
            allowEditing: false,
            width: 180,
        },
        {
            caption: 'Hasta Adı Soyadı',
            dataField: 'Patientname',
            allowEditing: false,
            width: 180,
        },
        {
            caption: 'Klinik',
            dataField: 'Masterresource',
            allowEditing: false,
            width: 200,
        },
    ];
  

    openDrugDefDropDown() {
        this.getDrugDefDataSource();
    }

    public onClearDrug(event: any) {
        if (event != null && event.value != null) {

        }
        else {
            this.selectedDrugDefItem = {};
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
                    return this.httpService.post<any>('/api/ReceivedDrugReportService/GetDrugDefinitionList', loadOptions);
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
    }

    public OzellikChanged(data) {
        if (data.addedItems.length === 1) {
            this.VademecumList.push(data.addedItems[0].code);
        }
        else if (data.removedItems.length === 1) {
            this.VademecumList.splice(this.VademecumList.findIndex(x => x === (data.removedItems.code)), 1);
        }

       // this._ViewModel.VademecumList = this.VademecumList;
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
        this.showActiveIngredientsMaterialMultiSelectForm = false;

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
            let apiUrlForPASearchUrl: string = '/api/ReceivedDrugReportService/FillDataSources';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.DoctorList = result.DoctorList;
                    this.MasterResourceList = result.MasterResourceList;
                    this.ActiveIngredientList = result.ActiveIngredientList;
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

    public GetDrugList(){
        try {
            this.showLoadPanel = true;
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/ReceivedDrugReportService/GetDrugList';
            let body = { 'StartDate': this.StartDate, 'EndDate': this.EndDate, 'DoctorIDList': this.doctorIDList, 'DrugIDList': this.DrugIDList, 'ActiveIngredientIDList': this.ActiveSubstanceIDList, 'ServiceIDList': this.masterResourceIDList };
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                this.DrugList = response;
                this.TotalNumberOfRows = this.DrugList.length;
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