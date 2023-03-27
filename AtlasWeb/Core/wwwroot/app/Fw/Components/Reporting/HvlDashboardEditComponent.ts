import { Component, ViewEncapsulation, OnInit, ViewChild, Input, Output, EventEmitter, ChangeDetectorRef } from '@angular/core';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { DxTextBoxComponent } from 'devextreme-angular';

@Component({
    selector: 'hvl-dashboard-edit',
    templateUrl: './HvlDashboardEditComponent.html'
})
export class HvlDashboardEditComponent implements OnInit {
    public reports: Array<DashboardDataSourceDto> = [];
    public showCreateReport: boolean = false;
    public showDesigner: boolean = false;

    @ViewChild('txtReportName') txtReportName: DxTextBoxComponent;
    @ViewChild('txtClassName') txtClassName: DxTextBoxComponent;
    @ViewChild('txtReportComment') txtReportComment: DxTextBoxComponent;

    constructor(private httpService: NeHttpService, private changeDetector : ChangeDetectorRef
        ) {
        this.emptyReports();
    }

    emptyReports() {
        this.reports.Clear();
        this.reports.push({ ObjectID: '-1', Name: 'Lütfen Veri Kaynağı Seçiniz', DashboardClassName: ''});
        this.reports.push({ ObjectID: '0', Name: 'Yeni Veri Kaynağı', DashboardClassName: ''});
    }


    ngOnInit() {
        this.loadReports();
    }
    loadReports() {
        this.httpService.get<Array<DashboardDataSourceDto>>("/api/AtlasDashboard/GetDashboardDataSources?getAll=true").then(x => {
            if (x && x.length > 0) {
                this.emptyReports();
                this.reports = this.reports.concat(x);
            }
        });
    }
    enableDisableButtonClicked(){

        this.setEnableDisable(this.selectedItem.ObjectID, !this.selectedItem.Enabled);
    }

    setEnableDisable(objectID : string, enabled : boolean){
        this.httpService.get<Boolean>("/api/AtlasDashboard/SetEnableDisable?objectID=" + objectID + "&enable=" + enabled).then(x => {
            this.loadReports();
        });
    }

    saveReport() {
        let reportName = this.txtReportName.value;
        let className = this.txtClassName.value;

        if (reportName.length < 1 || className.length < 1) {
            console.warn("reportName and className must be filled.");
            return;
        }
        let dto: DashboardDataSourceDto = { Name: this.txtReportName.value, DashboardClassName: this.txtClassName.value };

        this.httpService.post<Boolean>("/api/AtlasDashboard/SaveDashboardDataSource", dto).then(x => {
            this.loadReports();
        });
    }

    clearReportObject(){

    }

    selectedItem : DashboardDataSourceDto;

    reportChanged(e) {

        this.selectedItem = e.value as DashboardDataSourceDto;

        if (this.selectedItem.ObjectID == '0') {
            //New Report
            this.showCreateReport = true;
        }
        else if (this.selectedItem.ObjectID == '-1') {
            //Please Select
            this.showCreateReport = false;
        }
        else {
            //A Report
            this.showCreateReport = false;

        }
        
        console.log(e);
    }
}

export class DashboardDataSourceDto {
    public Name: string;
    public DashboardClassName: string;
    public ObjectID?: string;
    public Enabled?: boolean;

}