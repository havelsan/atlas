import { Component, OnInit } from '@angular/core';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { CovidDrugReportSearchModel, CovidDrugReportFormGridViewModel } from './CovidDrugReportFormViewModel';


@Component({
    selector: "covid-drug-report-form",
    templateUrl: './CovidDrugReportForm.html',
    providers: []
})

export class CovidDrugReportForm implements OnInit {

    public covidDrugReportSearchModel: CovidDrugReportSearchModel = new CovidDrugReportSearchModel();
    public covidDrugReportFormGridViewModel: CovidDrugReportFormGridViewModel = new CovidDrugReportFormGridViewModel();
    public gridDataSource: Array<CovidDrugReportFormGridViewModel> = new Array<CovidDrugReportFormGridViewModel>();
    public showLoadPanel = false;
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz';
    public storeListFiltred: string = "";
    public CovidDrugReportColumns = [
        {
            caption: 'Ayaktan Hidroksiklorokin',
            dataField: 'HidOutpatient'
        },
        {
            caption: 'Ayaktan Favipiravir',
            dataField: 'FavOutpatient'
        },
        {
            caption: 'Ayaktan Hidroksiklorokin + Favipiravir',
            dataField: 'HidFavOutpatient'
        },
        {
            caption: 'Ayaktan Antibiyotik',
            dataField: 'AntiOutpatient'
        },
        {
            caption: 'Ayaktan Steroid',
            dataField: 'SteOutpatient'
        },
        {
            caption: 'Yatan Hidroksiklorokin',
            dataField: 'HidInpatient'
        },
        {
            caption: 'Yatan Favipiravir',
            dataField: 'FavInpatient'
        },
        {
            caption: 'Yatan Hidroksiklorokin + Favipiravir',
            dataField: 'HidFavInpatient'
        },
        {
            caption: 'Yatan Antibiyotik',
            dataField: 'AntiInpatient'
        },
        {
            caption: 'Yatan Steroid',
            dataField: 'SteInpatient'
        }
    ];

    constructor(protected http: NeHttpService, protected activeUserService: IActiveUserService) {
    }

    ngOnInit(): void {
        this.covidDrugReportSearchModel.StartDate = new Date();
        this.covidDrugReportSearchModel.EndDate = new Date();
    }

    public btnSearchClick() {
        this.showLoadPanel = true;
        let url = 'api/CovidDrugReportService/GetCovidList';
        this.http.post<CovidDrugReportFormGridViewModel>(url, this.covidDrugReportSearchModel).then(result => {
            this.gridDataSource = new Array<CovidDrugReportFormGridViewModel>();
            this.gridDataSource.push(result);
            this.showLoadPanel = false;
        });
    }
}