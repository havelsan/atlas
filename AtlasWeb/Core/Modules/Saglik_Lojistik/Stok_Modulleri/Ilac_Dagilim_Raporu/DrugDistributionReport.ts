import { Component, Input, ViewChild } from '@angular/core';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "app/Fw/Services/MessageService";
import { IModalService } from "app/Fw/Services/IModalService";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { DrugDistributionInputDTO, patientHasDrugListDTO } from './DrugDistributionReportViewModel';
import { DrugOrderTypeEnum, AntibioticTypeEnum } from 'app/NebulaClient/Model/AtlasClientModel';
import { DxDropDownBoxComponent } from 'devextreme-angular';

@Component({
    selector: "DrugDistributionReport",
    templateUrl: './DrugDistributionReport.html',
    providers: [SystemApiService, MessageService]
})

export class DrugDistributionReport {
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz...';
    private _StoreObjectId: string;
    public showLoadPanel: boolean;
    public TotalNumberOfRows: number;
    selectedDrugDefItem: any = {};
    public StartDate: Date;
    public EndDate: Date;
    public patientHasDrugList: Array<patientHasDrugListDTO> = new Array<patientHasDrugListDTO>();
   
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
    }

    public setDefaultDates() {
        this.StartDate = new Date();
        this.StartDate.setHours(0, 0, 0, 0);
        this.EndDate = new Date();
        this.EndDate.setHours(23, 59, 59, 0);
    }

    async ngOnInit() {

    }

    public patientHasDrugListColumn = [
        {
            caption: 'Çıkış Şekli',
            dataField: 'OutStatus',
            allowEditing: false,
            width: 90,
        },
        {
            caption: "Başlangıç Tarihi",
            dataField: 'PlannedStartTime',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowEditing: false,
            sortOrder: 'asc',
            width: 110,
        },
        {
            caption: "Bitiş Tarihi",
            dataField: 'PlannedEndTime',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowEditing: false,
            width: 110,
        },
        {
            caption: 'İlaç Adı',
            dataField: 'DrugName',
            allowEditing: false,
            width: 350,
        },

        {
            caption: 'Doz Aralığı',
            dataField: 'Dose',
            allowEditing: false,
            width: 90,
        },
        {
            caption: 'Doz Miktarı',
            dataField: 'DoseAmount',
            allowEditing: false,
            width: 90,
        },
        {
            caption: 'Gün',
            dataField: 'Day',
            allowEditing: false,
            width: 90,
        },
        {
            caption: 'Miktar',
            dataField: 'Amount',
            allowEditing: false,
            width: 90,
        },
        {
            caption: 'Doktor',
            dataField: 'DoctorName',
            allowEditing: false,
            width: 180,
        },
        {
            caption: 'Hasta',
            dataField: 'PatientNameSurname',
            allowEditing: false,
            width: 180,
        },
        {
            caption: 'Klinik',
            dataField: 'ClinikName',
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
                    return this.httpService.post<any>('/api/DrugDistributionReportService/GetDrugDefList', loadOptions);
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
        this.drugDrop.instance.close();
    }

    async GetDrugList() {
        try {
            this.showLoadPanel = true;
            let input: DrugDistributionInputDTO = new DrugDistributionInputDTO();
            if (this.selectedDrugDefItem != null) {
                input.selectedDrugObjectID = this.selectedDrugDefItem.ObjectID;
            }
            input.startDate = this.StartDate;
            input.endDate = this.EndDate;

            let apiUrl: string = 'api/DrugDistributionReportService/GetInpatientHasDrugList';
            this.httpService.post<Array<patientHasDrugListDTO>>(apiUrl, input).then(
                result => {
                    this.patientHasDrugList = result;
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